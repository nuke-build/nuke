// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions
{
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class GitHubActions
    {
        private static Lazy<GitHubActions> s_instance = new Lazy<GitHubActions>(() => new GitHubActions());

        public static GitHubActions Instance => NukeBuild.Host == HostType.GitHubActions ? s_instance.Value : null;

        internal static bool IsRunningGitHubActions => EnvironmentInfo.GetVariable<bool>("GITHUB_ACTIONS");

        internal GitHubActions()
        {
        }

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

        public string GitHubToken => EnvironmentInfo.GetVariable<string>("GITHUB_TOKEN");

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
            Func<IDictionary<string, object>, IDictionary<string, object>> dictionaryConfigurator = null)
        {
            var escapedTokens = new[] { command };
            if (dictionaryConfigurator != null)
            {
                escapedTokens = escapedTokens.Concat(dictionaryConfigurator
                    .Invoke(new Dictionary<string, object>())
                    .Select(x => $"{x.Key}={Escape(x.Value.ToString())}")).ToArray();
            }

            Write(escapedTokens, message);
        }

        private void Write(string[] escapedTokens, string message)
        {
            Console.WriteLine($"##[{escapedTokens.JoinSpace()}]{EscapeData(message)}");
        }

        private string EscapeData(string data)
        {
            return data
                .Replace("\r", "%0D")
                .Replace("\n", "%0A");
        }

        private string Escape(string value)
        {
            return value
                .Replace("\r", "%0D")
                .Replace("\n", "%0A")
                .Replace("]", "%5D")
                .Replace(";", "%3B");
        }
    }
}
