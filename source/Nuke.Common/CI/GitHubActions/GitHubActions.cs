// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.GitHubActions
{
    /// <summary>
    /// Interface according to the <a href="https://github.com/actions/toolkit/blob/master/packages/core/src/core.ts">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class GitHubActions: IBuildServer
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
        public string Workflow => EnvironmentInfo.GetVariable<string>("GITHUB_WORKFLOW");
        
        ///<summary>A unique number for each run within a repository. This number does not change if you re-run the workflow run.</summary>
        public int RunId => EnvironmentInfo.GetVariable<int>("GITHUB_RUN_ID");
        
        /// <summary>
        /// A unique number for each run of a particular workflow in a repository. This number begins at 1 for the workflow's first run, and increments with each new run. This number does not change if you re-run the workflow run.
        /// </summary>
        public int RunNumber => EnvironmentInfo.GetVariable<int>("GITHUB_RUN_NUMBER");

        ///<summary>The name of the action.</summary>
        public string Action => EnvironmentInfo.GetVariable<string>("GITHUB_ACTION");

        ///<summary>The name of the person or app that initiated the workflow. For example, <code>octocat</code>.</summary>
        public string Actor => EnvironmentInfo.GetVariable<string>("GITHUB_ACTOR");

        ///<summary>The owner and repository name. For example, <code>octocat/Hello-World</code>.</summary>
        public string Repository => EnvironmentInfo.GetVariable<string>("GITHUB_REPOSITORY");

        ///<summary>The name of the webhook event that triggered the workflow.</summary>
        public string EventName => EnvironmentInfo.GetVariable<string>("GITHUB_EVENT_NAME");

        ///<summary>The path of the file with the complete webhook event payload. For example, <code>/github/workflow/event.json</code>.</summary>
        public string EventPath => EnvironmentInfo.GetVariable<string>("GITHUB_EVENT_PATH");

        ///<summary>The GitHub workspace directory path. The workspace directory contains a subdirectory with a copy of your repository if your workflow uses the <code>actions/checkout</code> action. If you don't use the <code>actions/checkout</code> action, the directory will be empty. For example, <code>/home/runner/work/my-repo-name/my-repo-name</code>.</summary>
        public AbsolutePath Workspace => EnvironmentInfo.GetVariable<AbsolutePath>("GITHUB_WORKSPACE");

        ///<summary>The commit SHA that triggered the workflow. For example, <code>ffac537e6cbbf934b08745a378932722df287a53</code>.</summary>
        public string Sha => EnvironmentInfo.GetVariable<string>("GITHUB_SHA");

        ///<summary>The branch or tag ref that triggered the workflow. For example, <code>refs/heads/feature-branch-1</code>. If neither a branch or tag is available for the event type, the variable will not exist.</summary>
        public string Ref => EnvironmentInfo.GetVariable<string>("GITHUB_REF");

        ///<summary>Only set for forked repositories. The branch of the head repository.</summary>
        public string HeadRef => EnvironmentInfo.GetVariable<string>("GITHUB_HEAD_REF");

        ///<summary>Only set for forked repositories. The branch of the base repository.</summary>
        public string BaseRef => EnvironmentInfo.GetVariable<string>("GITHUB_BASE_REF");

        public string AccessToken => EnvironmentInfo.GetVariable<string>("GITHUB_TOKEN");

        // https://github.com/actions/toolkit/tree/master/packages/core/src
        // https://help.github.com/en/actions/reference/workflow-commands-for-github-actions

        public void SetEnvironmentVariable(string name, string value)
        {
            WriteCommand("set-env", value, c => c.AddPair("name", name));
        }

        public void SetOutputParameter(string name, string value)
        {
            WriteCommand("set-output", value, c => c.AddPair("name", name));
        }

        public void AddPath(AbsolutePath path)
        {
            WriteCommand("add-path", path);
        }

        public void AddMask(string value)
        {
            WriteCommand("add-mask", value);
        }

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
            LogWarning(message);
        }

        public void WriteError(string message)
        {
            LogError(message);
        }

        public void LogWarning(
            string message,
            string file = null,
            int? line = null,
            int? column = null)
        {
            LogIssue(GitHubActionsIssueType.Error, message, file, line, column);
        }

        public void LogError(
            string message,
            string file = null,
            int? line = null,
            int? column = null)
        {
            LogIssue(GitHubActionsIssueType.Warning, message, file, line, column);
        }

        public void LogIssue(
            GitHubActionsIssueType type,
            string message,
            string file = null,
            int? line = null,
            int? column = null)
        {
            WriteCommand(
                GetText(type),
                message,
                dictionaryConfigurator: x => x
                    .AddPairWhenValueNotNull("file", file)
                    .AddPairWhenValueNotNull("line", line)
                    .AddPairWhenValueNotNull("col", column)
                );
        }

        private string GetText(GitHubActionsIssueType type)
        {
            return type switch
            {
                GitHubActionsIssueType.Warning => "warning",
                GitHubActionsIssueType.Error => "error",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, message: null)
            };
        }

        public void WriteCommand(
            string command,
            string message = null,
            Func<IDictionary<string, object>, IDictionary<string, object>> dictionaryConfigurator = null)
        {
            var escapedTokens = Array.Empty<string>();
            if (dictionaryConfigurator != null)
            {
                escapedTokens = escapedTokens.Concat(dictionaryConfigurator
                    .Invoke(new Dictionary<string, object>())
                    .Select(x => $"{x.Key}={Escape(x.Value.ToString())}")).ToArray();
            }

            Write(command, escapedTokens, message);
        }

        private void Write(string command, string[] escapedTokens, [CanBeNull] string message)
        {
            var cmdLine = $"::{command} {escapedTokens.JoinComma()}".Trim();
            Console.WriteLine($"{cmdLine}::{EscapeMessage(message)}");
        }

        private string EscapeMessage([CanBeNull] string data)
        {
            return data?
                .Replace("\r", "%0D")
                .Replace("\n", "%0A");
        }

        private string Escape(string value)
        {
            return value
                .Replace("\r", "%0D")
                .Replace("\n", "%0A")
                .Replace("]", "%5D")
                .Replace(":", "%5D")
                .Replace(";", "%3B");
        }

        #region IBuildServer
        HostType IBuildServer.Host => HostType.GitHubActions;
        string IBuildServer.BuildNumber => RunNumber.ToString();
        AbsolutePath IBuildServer.SourceDirectory => Workspace;
        AbsolutePath IBuildServer.OutputDirectory => null;
        string IBuildServer.SourceBranch => Ref;
        string IBuildServer.TargetBranch => null;

        void IBuildServer.IssueWarning(string message, string file, int? line, int? column, string code)
        {
            LogIssue(GitHubActionsIssueType.Warning, message, file, line, column);
        }

        void IBuildServer.IssueError(string message, string file, int? line, int? column, string code)
        {
            LogIssue(GitHubActionsIssueType.Error, message, file, line, column);
        }

        void IBuildServer.PublishArtifact(AbsolutePath artifactPath)
        {
            // Could dynamically clone https://github.com/actions/upload-artifact/ and call it here.
            Logger.Trace("publishing artifacts are not supported by {0}", ((IBuildServer) this ).Host.ToString());
        }

        void IBuildServer.UpdateBuildNumber(string buildNumber) { }
        #endregion
    }
}
