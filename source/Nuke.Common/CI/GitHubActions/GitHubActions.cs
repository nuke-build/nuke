// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions
{
    /// <summary>
    /// Interface according to the <a href="https://docs.github.com/en/actions/configuring-and-managing-workflows/using-environment-variables">official website</a>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public partial class GitHubActions : Host, IBuildServer
    {
        internal static bool IsRunningGitHubActions => EnvironmentInfo.HasVariable("GITHUB_ACTIONS");

        public new static GitHubActions Instance => Host.Instance as GitHubActions;

        private readonly Lazy<JObject> _eventContext;
        private readonly Lazy<HttpClient> _httpClient;
        private readonly Lazy<long> _jobId;

        internal GitHubActions()
        {
            _eventContext = Lazy.Create(() =>
            {
                var content = File.ReadAllText(EventPath);
                return JsonConvert.DeserializeObject<JObject>(content);
            });
            _httpClient = Lazy.Create(() =>
            {
                var base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{Token.NotNull()}"));

                var client = new HttpClient();
                client.BaseAddress = new Uri("https://api.github.com");
                client.DefaultRequestHeaders.UserAgent.ParseAdd("nuke-build");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Auth);
                return client;
            });
            _jobId = Lazy.Create(GetJobId);
        }

        string IBuildServer.Branch => Ref;
        string IBuildServer.Commit => Sha;

        ///<summary>The path to the GitHub home directory used to store user data. For example, <code>/github/home</code>.</summary>
        public string Home => EnvironmentInfo.GetVariable("HOME");

        ///<summary>The name of the workflow.</summary>
        public string Workflow => EnvironmentInfo.GetVariable("GITHUB_WORKFLOW");

        ///<summary>The name of the action.</summary>
        public string Action => EnvironmentInfo.GetVariable("GITHUB_ACTION");

        ///<summary>The name of the person or app that initiated the workflow. For example, <code>octocat</code>.</summary>
        public string Actor => EnvironmentInfo.GetVariable("GITHUB_ACTOR");

        ///<summary>The owner and repository name. For example, <code>octocat/Hello-World</code>.</summary>
        public string Repository => EnvironmentInfo.GetVariable("GITHUB_REPOSITORY");

        ///<summary>The owner name. For example, <code>octocat</code>.</summary>
        public string RepositoryOwner => EnvironmentInfo.GetVariable("GITHUB_REPOSITORY_OWNER");

        ///<summary>The name of the webhook event that triggered the workflow.</summary>
        public string EventName => EnvironmentInfo.GetVariable("GITHUB_EVENT_NAME");

        ///<summary>The path of the file with the complete webhook event payload. For example, <code>/github/workflow/event.json</code>.</summary>
        public string EventPath => EnvironmentInfo.GetVariable("GITHUB_EVENT_PATH");

        ///<summary>The GitHub workspace directory path. The workspace directory contains a subdirectory with a copy of your repository if your workflow uses the <code>actions/checkout</code> action. If you don't use the <code>actions/checkout</code> action, the directory will be empty. For example, <code>/home/runner/work/my-repo-name/my-repo-name</code>.</summary>
        public string Workspace => EnvironmentInfo.GetVariable("GITHUB_WORKSPACE");

        ///<summary>The commit SHA that triggered the workflow. For example, <code>ffac537e6cbbf934b08745a378932722df287a53</code>.</summary>
        public string Sha => EnvironmentInfo.GetVariable("GITHUB_SHA");

        ///<summary>The branch or tag ref that triggered the workflow. For example, <code>refs/heads/feature-branch-1</code>. If neither a branch or tag is available for the event type, the variable will not exist.</summary>
        public string Ref => EnvironmentInfo.GetVariable("GITHUB_REF");

        ///<summary>Only set for forked repositories. The branch of the head repository.</summary>
        public string HeadRef => EnvironmentInfo.GetVariable("GITHUB_HEAD_REF");

        ///<summary>Only set for forked repositories. The branch of the base repository.</summary>
        public string BaseRef => EnvironmentInfo.GetVariable("GITHUB_BASE_REF");

        public long RunNumber => EnvironmentInfo.GetVariable<long>("GITHUB_RUN_NUMBER");
        public long RunId => EnvironmentInfo.GetVariable<long>("GITHUB_RUN_ID");
        public string ServerUrl => EnvironmentInfo.GetVariable("GITHUB_SERVER_URL");
        public string Job => EnvironmentInfo.GetVariable("GITHUB_JOB");

        // https://github.com/actions/toolkit/tree/master/packages/core/src

        public string Token => EnvironmentInfo.GetVariable("GITHUB_TOKEN");
        public long JobId => _jobId.Value;

        public JObject GitHubEvent => _eventContext.Value;
        public bool IsPullRequest => EventName == "pull_request";
        public int? PullRequestNumber => GitHubEvent.GetPropertyValue<int>("number");
        public string PullRequestAction => GitHubEvent.GetPropertyStringValue("action");

        public AbsolutePath StepSummaryFile => EnvironmentInfo.GetVariable("GITHUB_STEP_SUMMARY");

        public void Group(string group)
        {
            WriteCommand("group", group);
        }

        public void EndGroup(string group)
        {
            WriteCommand("endgroup", group);
        }

        public void WriteDebug(string message)
        {
            WriteCommand("debug", message);
        }

        public void WriteWarning(string message)
        {
            WriteCommand("warning", message);
        }

        public void WriteError(string message)
        {
            WriteCommand("error", message);
        }

        public void WriteCommand(
            string command,
            string message = null,
            Configure<IDictionary<string, object>> dictionaryConfigurator = null)
        {
            var parameters = dictionaryConfigurator.InvokeSafe(new Dictionary<string, object>())
                .Select(x => $"{x.Key}={EscapeProperty(x.Value.ToString())}")
                .JoinCommaSpace();

            Console.WriteLine(parameters.IsNullOrEmpty()
                ? $"::{command}::{EscapeData(message)}"
                : $"::{command} {parameters}::{EscapeData(message)}");
        }

        private string EscapeData([CanBeNull] string data)
        {
            return data?
                .Replace("%", "%25")
                .Replace("\r", "%0D")
                .Replace("\n", "%0A");
        }

        private string EscapeProperty(string value)
        {
            return value
                .Replace("%", "%25")
                .Replace("\r", "%0D")
                .Replace("\n", "%0A")
                .Replace(":", "%3A")
                .Replace(",", "%2C");
        }
    }
}
