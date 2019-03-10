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
        /// The current build display name, such as "#14".
        /// </summary>
        public string BuilDisplayName => Variable("BUILD_DISPLAY_NAME");

        /// <summary>
        /// The current build number, such as "14".
        /// </summary>
        public int BuildNumber => Variable<int>("BUILD_NUMBER");

        /// <summary>
        /// The current build tag, such as "jenkins-nuke-14".
        /// </summary>
        public string BuildTag => Variable("BUILD_TAG");

        /// <summary>
        /// The number of the executor this build is running on, Equals '0' for first executor.
        /// </summary>
        public int ExecutorNumber => Variable<int>("EXECUTOR_NUMBER");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git branch that was checked out for the build (normally origin/master) ﻿(all the Git* properties require git plugin).
        /// </summary>
        public string GitBranch => Variable("GIT_BRANCH");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git hash of the commit checked out for the build (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitCommit => Variable("GIT_COMMIT");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git hash of the previous build commit (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitPreviousCommit => Variable("GIT_PREVIOUS_COMMIT");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git hash of the last successful build (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitPreviousSuccessfulCommit => Variable("GIT_PREVIOUS_SUCCESSFUL_COMMIT");

        /// <summary>
        ///  For Git-based projects, this variable contains the Git url (like git@github.com:user/repo.git or [https://github.com/user/repo.git])  (all the Git* properties require git plugin).
        /// </summary>
        [CanBeNull] public string GitUrl => Variable("GIT_URL");

        /// <summary>
        /// The path to the jenkins home directory.
        /// </summary>
        public string JenkinsHome => Variable("JENKINS_HOME");

        /// <summary>
        /// The jenkins server cookie.
        /// </summary>
        public string JenkinsServerCookie => Variable("JENKINS_SERVER_COOKIE");

        /// <summary>
        /// The base name of the current job, such as "Nuke".
        /// </summary>
        public string JobBaseName => Variable("JOB_BASE_NAME");

        /// <summary>
        /// The url to the currents job overview.
        /// </summary>
        public string JobDisplayUrl => Variable("JOB_DISPLAY_URL");

        /// <summary>
        /// The  name of the current job, such as "Nuke".
        /// </summary>
        public string JobName => Variable("JOB_NAME");

        /// <summary>
        /// The  labels of the node this build is running on, such as "win64 msbuild".
        /// </summary>
        public string NodeLabels => Variable("NODE_LABELS");

        /// <summary>
        /// The name of the node this build is running on, such as "master".
        /// </summary>
        public string NodeName => Variable("NODE_NAME");

        /// <summary>
        /// The url to the currents run changes page.
        /// </summary>
        public string RunChangesDisplayUrl => Variable("RUN_CHANGES_DISPLAY_URL");

        /// <summary>
        /// The url to the currents run overview page.
        /// </summary>
        public string RunDisplayUrl => Variable("RUN_DISPLAY_URL");

        /// <summary>
        /// The path to the folder this job is running in.
        /// </summary>
        public string Workspace => Variable("WORKSPACE");
    }
}
