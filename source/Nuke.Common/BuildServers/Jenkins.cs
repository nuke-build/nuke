// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Common.EnvironmentInfo;

namespace Nuke.Common.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="https://wiki.jenkins.io/display/JENKINS/Building+a+software+project">official website</a>.
    /// </summary>
    [PublicAPI]
    [BuildServer]
    [ExcludeFromCodeCoverage]
    public class Jenkins
    {
        private static Lazy<Jenkins> s_instance = new Lazy<Jenkins>(() => new Jenkins());

        public static Jenkins Instance => NukeBuild.Host == HostType.Jenkins ? s_instance.Value : null;

        internal static bool IsRunningJenkins => Environment.GetEnvironmentVariable("JENKINS_HOME") != null;

        internal Jenkins()
        {
        }

        /// <summary>
        /// Name of the branch for which this Pipeline is executing, for example <em>master</em>.
        /// </summary>
        public string BranchName => GetVariable<string>("BRANCH_NAME");

        /// <summary>
        /// The current build display name, such as "#14".
        /// </summary>
        public string BuilDisplayName => GetVariable<string>("BUILD_DISPLAY_NAME");

        /// <summary>
        /// The current build number, such as "14".
        /// </summary>
        public int BuildNumber => GetVariable<int>("BUILD_NUMBER");

        /// <summary>
        /// The current build tag, such as "jenkins-nuke-14".
        /// </summary>
        public string BuildTag => GetVariable<string>("BUILD_TAG");

        /// <summary>
        /// An identifier corresponding to some kind of change request, such as a pull request number.
        /// </summary>
        public string ChangeId => GetVariable<string>("CHANGE_ID");

        /// <summary>
        /// The number of the executor this build is running on, Equals '0' for first executor.
        /// </summary>
        public int ExecutorNumber => GetVariable<int>("EXECUTOR_NUMBER");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git branch that was checked out for the build (normally origin/master) ﻿(all the Git* properties require git plugin).
        /// </summary>
        public string GitBranch => GetVariable<string>("GIT_BRANCH");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git hash of the commit checked out for the build (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitCommit => GetVariable<string>("GIT_COMMIT");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git hash of the previous build commit (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitPreviousCommit => GetVariable<string>("GIT_PREVIOUS_COMMIT");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git hash of the last successful build (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitPreviousSuccessfulCommit => GetVariable<string>("GIT_PREVIOUS_SUCCESSFUL_COMMIT");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git url (like git@github.com:user/repo.git or [https://github.com/user/repo.git])  (all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitUrl => GetVariable<string>("GIT_URL");

        /// <summary>
        /// The path to the jenkins home directory.
        /// </summary>
        public string JenkinsHome => GetVariable<string>("JENKINS_HOME");

        /// <summary>
        /// The jenkins server cookie.
        /// </summary>
        public string JenkinsServerCookie => GetVariable<string>("JENKINS_SERVER_COOKIE");

        /// <summary>
        /// The base name of the current job, such as "Nuke".
        /// </summary>
        public string JobBaseName => GetVariable<string>("JOB_BASE_NAME");

        /// <summary>
        /// The url to the currents job overview.
        /// </summary>
        public string JobDisplayUrl => GetVariable<string>("JOB_DISPLAY_URL");

        /// <summary>
        /// The  name of the current job, such as "Nuke".
        /// </summary>
        public string JobName => GetVariable<string>("JOB_NAME");

        /// <summary>
        /// The  labels of the node this build is running on, such as "win64 msbuild".
        /// </summary>
        public string NodeLabels => GetVariable<string>("NODE_LABELS");

        /// <summary>
        /// The name of the node this build is running on, such as "master".
        /// </summary>
        public string NodeName => GetVariable<string>("NODE_NAME");

        /// <summary>
        /// The url to the currents run changes page.
        /// </summary>
        public string RunChangesDisplayUrl => GetVariable<string>("RUN_CHANGES_DISPLAY_URL");

        /// <summary>
        /// The url to the currents run overview page.
        /// </summary>
        public string RunDisplayUrl => GetVariable<string>("RUN_DISPLAY_URL");

        /// <summary>
        /// The path to the folder this job is running in.
        /// </summary>
        public string Workspace => GetVariable<string>("WORKSPACE");
    }
}
