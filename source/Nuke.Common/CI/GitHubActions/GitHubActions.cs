// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
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
        internal static bool IsRunningGitHubActions => EnvironmentInfo.GetVariable<bool>("GITHUB_ACTIONS");

        public new static GitHubActions Instance => Host.Instance as GitHubActions;

        internal GitHubActions()
        {
        }

        string IBuildServer.Branch => GitHubRef;
        string IBuildServer.Commit => GitHubSha;

        ///<summary>The path to the GitHub home directory used to store user data. For example, <code>/github/home</code>.</summary>
        public string Home => EnvironmentInfo.GetVariable<string>("HOME");

        ///<summary>The name of the workflow.</summary>
        public string GitHubWorkflow => EnvironmentInfo.GetVariable<string>("GITHUB_WORKFLOW");

        ///<summary>The name of the action.</summary>
        public string GitHubAction => EnvironmentInfo.GetVariable<string>("GITHUB_ACTION");

        ///<summary>The name of the person or app that initiated the workflow. For example, <code>octocat</code>.</summary>
        public string GitHubActor => EnvironmentInfo.GetVariable<string>("GITHUB_ACTOR");

        ///<summary>The owner and repository name. For example, <code>octocat/Hello-World</code>.</summary>
        public string GitHubRepository => EnvironmentInfo.GetVariable<string>("GITHUB_REPOSITORY");

        ///<summary>The owner name. For example, <code>octocat</code>.</summary>
        public string GitHubRepositoryOwner => EnvironmentInfo.GetVariable<string>("GITHUB_REPOSITORY_OWNER");

        ///<summary>The name of the webhook event that triggered the workflow.</summary>
        public string GitHubEventName => EnvironmentInfo.GetVariable<string>("GITHUB_EVENT_NAME");

        ///<summary>The path of the file with the complete webhook event payload. For example, <code>/github/workflow/event.json</code>.</summary>
        public string GitHubEventPath => EnvironmentInfo.GetVariable<string>("GITHUB_EVENT_PATH");

        ///<summary>The GitHub workspace directory path. The workspace directory contains a subdirectory with a copy of your repository if your workflow uses the <code>actions/checkout</code> action. If you don't use the <code>actions/checkout</code> action, the directory will be empty. For example, <code>/home/runner/work/my-repo-name/my-repo-name</code>.</summary>
        public string GitHubWorkspace => EnvironmentInfo.GetVariable<string>("GITHUB_WORKSPACE");

        ///<summary>The commit SHA that triggered the workflow. For example, <code>ffac537e6cbbf934b08745a378932722df287a53</code>.</summary>
        public string GitHubSha => EnvironmentInfo.GetVariable<string>("GITHUB_SHA");

        ///<summary>The branch or tag ref that triggered the workflow. For example, <code>refs/heads/feature-branch-1</code>. If neither a branch or tag is available for the event type, the variable will not exist.</summary>
        public string GitHubRef => EnvironmentInfo.GetVariable<string>("GITHUB_REF");

        ///<summary>Only set for forked repositories. The branch of the head repository.</summary>
        public string GitHubHeadRef => EnvironmentInfo.GetVariable<string>("GITHUB_HEAD_REF");

        ///<summary>Only set for forked repositories. The branch of the base repository.</summary>
        public string GitHubBaseRef => EnvironmentInfo.GetVariable<string>("GITHUB_BASE_REF");

        public long GitHubRunNumber => EnvironmentInfo.GetVariable<long>("GITHUB_RUN_NUMBER");
        public long GitHubRunId => EnvironmentInfo.GetVariable<long>("GITHUB_RUN_ID");
        public string GitHubServerUrl => EnvironmentInfo.GetVariable<string>("GITHUB_SERVER_URL");
        public string GitHubJob => EnvironmentInfo.GetVariable<string>("GITHUB_JOB");

        // https://github.com/actions/toolkit/tree/master/packages/core/src

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
                .JoinComma();

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
