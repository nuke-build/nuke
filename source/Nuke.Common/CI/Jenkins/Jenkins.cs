// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins
{
    /// <summary>
    /// Interface according to the <a href="https://wiki.jenkins.io/display/JENKINS/Building+a+software+project">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class Jenkins : Host, IBuildServer
    {
        internal static bool IsRunningJenkins => !Environment.GetEnvironmentVariable("JENKINS_HOME").IsNullOrEmpty();

        internal Jenkins()
        {
        }

        string IBuildServer.Branch => GitBranch ?? BranchName;
        string IBuildServer.Commit => GitCommit;

        /// <summary>
        /// Name of the branch for which this Pipeline is executing, for example <em>master</em>.
        /// </summary>
        public string BranchName => EnvironmentInfo.GetVariable<string>("BRANCH_NAME");

        /// <summary>
        /// The current build display name, such as "#14".
        /// </summary>
        public string BuilDisplayName => EnvironmentInfo.GetVariable<string>("BUILD_DISPLAY_NAME");

        /// <summary>
        /// The current build number, such as "14".
        /// </summary>
        public int BuildNumber => EnvironmentInfo.GetVariable<int>("BUILD_NUMBER");

        /// <summary>
        /// The current build tag, such as "jenkins-nuke-14".
        /// </summary>
        public string BuildTag => EnvironmentInfo.GetVariable<string>("BUILD_TAG");

        /// <summary>
        /// An identifier corresponding to some kind of change request, such as a pull request number.
        /// </summary>
        public string ChangeId => EnvironmentInfo.GetVariable<string>("CHANGE_ID");

        /// <summary>
        /// The number of the executor this build is running on, Equals '0' for first executor.
        /// </summary>
        public int ExecutorNumber => EnvironmentInfo.GetVariable<int>("EXECUTOR_NUMBER");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git branch that was checked out for the build (normally origin/master) ﻿(all the Git* properties require git plugin).
        /// </summary>
        public string GitBranch => EnvironmentInfo.GetVariable<string>("GIT_BRANCH");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git hash of the commit checked out for the build (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitCommit => EnvironmentInfo.GetVariable<string>("GIT_COMMIT");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git hash of the previous build commit (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitPreviousCommit => EnvironmentInfo.GetVariable<string>("GIT_PREVIOUS_COMMIT");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git hash of the last successful build (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitPreviousSuccessfulCommit => EnvironmentInfo.GetVariable<string>("GIT_PREVIOUS_SUCCESSFUL_COMMIT");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git url (like git@github.com:user/repo.git or [https://github.com/user/repo.git])  (all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitUrl => EnvironmentInfo.GetVariable<string>("GIT_URL");

        /// <summary>
        /// The path to the jenkins home directory.
        /// </summary>
        public string JenkinsHome => EnvironmentInfo.GetVariable<string>("JENKINS_HOME");

        /// <summary>
        /// The jenkins server cookie.
        /// </summary>
        public string JenkinsServerCookie => EnvironmentInfo.GetVariable<string>("JENKINS_SERVER_COOKIE");

        /// <summary>
        /// The base name of the current job, such as "Nuke".
        /// </summary>
        public string JobBaseName => EnvironmentInfo.GetVariable<string>("JOB_BASE_NAME");

        /// <summary>
        /// The url to the currents job overview.
        /// </summary>
        public string JobDisplayUrl => EnvironmentInfo.GetVariable<string>("JOB_DISPLAY_URL");

        /// <summary>
        /// The  name of the current job, such as "Nuke".
        /// </summary>
        public string JobName => EnvironmentInfo.GetVariable<string>("JOB_NAME");

        /// <summary>
        /// The  labels of the node this build is running on, such as "win64 msbuild".
        /// </summary>
        public string NodeLabels => EnvironmentInfo.GetVariable<string>("NODE_LABELS");

        /// <summary>
        /// The name of the node this build is running on, such as "master".
        /// </summary>
        public string NodeName => EnvironmentInfo.GetVariable<string>("NODE_NAME");

        /// <summary>
        /// The url to the currents run changes page.
        /// </summary>
        public string RunChangesDisplayUrl => EnvironmentInfo.GetVariable<string>("RUN_CHANGES_DISPLAY_URL");

        /// <summary>
        /// The url to the currents run overview page.
        /// </summary>
        public string RunDisplayUrl => EnvironmentInfo.GetVariable<string>("RUN_DISPLAY_URL");

        /// <summary>
        /// The path to the folder this job is running in.
        /// </summary>
        public string Workspace => EnvironmentInfo.GetVariable<string>("WORKSPACE");
    }
}
