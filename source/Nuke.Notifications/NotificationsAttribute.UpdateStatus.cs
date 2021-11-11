// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tools.Slack;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Net;
using Serilog;
using Serilog.Events;

namespace Nuke.Notifications
{
    public partial class NotificationsAttribute
    {
        private void Update(UpdateReason updateReason)
        {
            if (_previouslyFailed ||
                !SendStatus ||
                FunctionsHost.IsNullOrEmpty() ||
                AccessToken.IsNullOrEmpty())
                return;

            TargetStatus GetStatus(ExecutableTarget target) =>
                new TargetStatus
                {
                    Name = target.Name,
                    Status = target.Status,
                    Duration = target.Duration,
                    Data = target.SummaryInformation,
                    PartitionsSize = target.PartitionSize
                };

            var notInitializing = updateReason != UpdateReason.BuildCreated;
            var status =
                new BuildStatus
                {
                    Started = _started,
                    Host = NukeBuild.Host.GetType().Name,
                    HostInformation = JsonConvert.SerializeObject(NukeBuild.Host, _serializerSettings),
                    // TODO: Only pass in when yaml has different configured?
                    OperatingSystem = EnvironmentInfo.Platform.ToString(),
                    Repository = Repository.HttpsUrl.TrimEnd(".git"),
                    Branch = Repository.Branch,
                    Commits = Commits,
                    Partition = Build.Partition.Part,
                    Version = notInitializing ? GetMemberValueOrNull<string>(VersionParameter, Build) : null,
                    Targets = Build.ExecutionPlan?.Select(GetStatus).ToList(),
                    IsFinished = notInitializing && Build.IsFinished,
                    IsSuccessful = notInitializing && Build.IsSuccessful,
                    ErrorMessage = updateReason == UpdateReason.BuildFinished
                        ? Logging.InMemorySink.Instance.LogEvents
                            .Where(x => x.Level >= LogEventLevel.Error)
                            .Select(x => x.RenderMessage()).JoinNewLine()
                        : string.Empty,
                    ExitCode = Build.ExitCode,
                    Actions = notInitializing
                        ? GetAllActions().Where(x => updateReason != UpdateReason.BuildFinished || x.Type == BuildActionType.Remote).ToList()
                        : new List<BuildAction>(),
                    SlackAttachments = notInitializing
                        ? SlackAttachments.ToList()
                        : new List<SlackMessageAttachment>()
                };

            var message =
                new BuildStatusMessage
                {
                    Cookie = _cookie,
                    UpdateReason = updateReason,
                    TimeCreated = DateTime.Now,
                    // TODO: encrypt
                    Status = status
                };

            if (EnableCancellation || status.Actions.Any())
            {
                var _ = _connection.Value;
            }

            try
            {
                var response = _client
                    .CreateRequest(HttpMethod.Post, BuildStatusEndpoint)
                    .WithBearerAuthentication(AccessToken)
                    .WithJsonContent(message)
                    .GetResponse();
                response.AssertStatusCode(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                Log.Warning(exception, "Updating build status to {Endpoint} failed", BuildStatusEndpoint);
                _previouslyFailed = true;
            }
        }
    }
}
