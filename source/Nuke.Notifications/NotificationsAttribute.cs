// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Git;
using Nuke.Common.Tools.Slack;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.Utilities.Net;
using Serilog;
using Serilog.Events;

namespace Nuke.Notifications
{
    public partial class NotificationsAttribute
        : BuildExtensionAttributeBase,
            IOnBuildCreated,
            IOnTargetRunning,
            IOnBuildFinished
    {
        private string FunctionsHost => Environment.GetEnvironmentVariable("NUKE_FUNCTIONS_HOST");
        private string AccessToken => Environment.GetEnvironmentVariable("NUKE_TOKEN");

        private string BuildEndpoint => $"{FunctionsHost}/api/build";
        private string BuildStatusEndpoint => $"{BuildEndpoint}/status";
        private string BuildInteractionEndpoint => $"{BuildEndpoint}/interaction";

        private readonly HttpClient _client = new HttpClient();
        private readonly Guid _cookie = Guid.NewGuid();
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly Lazy<HubConnection> _connection;
        private readonly DateTime _started = DateTime.Now;

        private bool _previouslyFailed;

        public NotificationsAttribute()
        {
            var configurationId = EnvironmentInfo.GetParameter<string>(BuildServerConfigurationGenerationAttributeBase.ConfigurationParameterName);
            if (configurationId != null)
                return;

            _serializerSettings = new JsonSerializerSettings { ContractResolver = new HostContractResolver(ShouldSerialize) };
            _connection = Lazy.Create(CreateHubConnection);
        }

        public NukeBuild Build { get; private set; }
        public GitRepository Repository { get; private set; }
        public IReadOnlyCollection<Commit> Commits { get; private set; }
        public string VersionParameter { get; set; }

        public virtual bool SendStatus => true;

        public virtual bool EnableAuthorizedActions { get; set; }
        public virtual bool EnableCancellation { get; set; }
        public virtual bool EnableCancellationConfirmation { get; set; }

        public virtual IEnumerable<SlackMessageAttachment> SlackAttachments => new SlackMessageAttachment[0];
        public virtual IEnumerable<BuildAction> Actions => new BuildAction[0];

        public void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            Build = build;
            Repository = GitRepository.FromLocalDirectory(NukeBuild.RootDirectory);
            Commits = GetCommits(Repository.Commit)?.ToList();

            Update(UpdateReason.BuildCreated);
        }

        public void OnTargetRunning(NukeBuild build, ExecutableTarget target)
        {
            Update(UpdateReason.TargetStarted);
        }

        public void OnBuildFinished(NukeBuild build)
        {
            Update(UpdateReason.BuildFinished);
        }

        private IEnumerable<BuildAction> GetAllActions()
        {
            foreach (var action in Actions)
                yield return action;

            if (EnableCancellation)
            {
                yield return CreateLocalAction(
                    caption: "Cancel",
                    action: CancelBuildAction.Cancel,
                    style: BuildActionStyle.Danger,
                    confirmation: EnableCancellationConfirmation
                        ? new BuildActionConfirmation
                          {
                              Title = "Cancel Build?",
                              Text = $"Do you want to cancel the {NukeBuild.Host.GetType().Name} build for the {Repository.Branch} branch?",
                              ConfirmText = "Cancel",
                              DismissText = "Dismiss"
                          }
                        : null);
            }
        }

        [CanBeNull]
        private static IEnumerable<Commit> GetCommits(string commit)
        {
            var regex = new Regex(@"^(?'sha'[^\t]+)\t(?'author'[^\t]+)\t(?'email'[^\t]+)\t(?'message'[^\t]+)$");
            try
            {
                var commitData = GitTasks.Git($"log {commit}^.. --pretty=tformat:{"%H\t%an\t%ae\t%s".DoubleQuote()}")
                    .EnsureOnlyStd()
                    .Select(x => regex.Match(x.Text))
                    .Select(match =>
                        new Commit
                        {
                            Sha = match.Groups["sha"].Value,
                            Message = match.Groups["message"].Value,
                            Author = match.Groups["author"].Value,
                            Email = match.Groups["email"].Value
                        }).ToList();
                Assert.NotEmpty(commitData);
                return commitData;
            }
            catch
            {
                return null;
            }
        }

        // TODO: From ValueInjectionAttributeBase
        [CanBeNull]
        protected T GetMemberValue<T>(string memberName, object instance)
        {
            var type = instance.GetType();
            var member = type.GetMember(memberName, ReflectionUtility.All)
                .SingleOrDefaultOrError($"Found multiple members with the name '{memberName}' in '{type.Name}'")
                .NotNull($"No member '{memberName}' found in '{type.Name}'");
            Assert.True(typeof(T).IsAssignableFrom(member.GetMemberType()), $"Member '{type.Name}.{member.Name}' must be of type '{typeof(T).Name}'");
            return member.GetValue<T>(instance);
        }

        [CanBeNull]
        protected T GetMemberValueOrNull<T>([CanBeNull] string memberName, object instance)
        {
            return memberName != null ? GetMemberValue<T>(memberName, instance) : default;
        }
    }
}
