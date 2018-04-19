// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using static Nuke.Core.EnvironmentInfo;

namespace Nuke.Core.BuildServers
{
    /// <summary>
    ///     Interface according to the <a href="https://wiki.jenkins.io/display/JENKINS/Building+a+software+project">official website</a>.
    /// </summary>
    [BuildServer]
    public class Jenkins
    {
        private static Lazy<Jenkins> s_instance = new Lazy<Jenkins>(() => new Jenkins());

        public static Jenkins Instance => NukeBuild.Instance?.Host == HostType.Jenkins ? s_instance.Value : null;

        internal static bool IsRunningJenkins => Variable("JENKINS_HOME") != null;

        internal Jenkins()
        {
        }

        /// <summary>
        ///     The current build display name, such as "#14".
        /// </summary>
        public string BuilDisplayName => Variable("BUILD_DISPLAY_NAME");

        /// <summary>
        ///     The current build number, such as "14".
        /// </summary>
        public int BuildNumber => Variable<int>("BUILD_NUMBER");

        /// <summary>
        ///     The current build tag, such as "jenkins-nuke-14".
        /// </summary>
        public string BuildTag => Variable<string>("BUILD_TAG");

        /// <summary>
        ///     The number of the executor this build is running on, Equals '0' for first executor.
        /// </summary>
        public int ExecutorNumber => Variable<int>("EXECUTOR_NUMBER");

        /// <summary>
        ///    For Git-based projects, this variable contains the Git branch that was checked out for the build (normally origin/master) ﻿(all the Git* properties require git plugin).
        /// </summary>
        public string GitBranch => Variable<string>("GIT_BRANCH");

        /// <summary>
        ///    For Git-based projects, this variable contains the Git hash of the commit checked out for the build (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        public string GitCommit => Variable<string>("GIT_COMMIT");

        /// <summary>
        ///    For Git-based projects, this variable contains the Git hash of the previous build commit (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        public string GitPreviousCommit => Variable<string>("GIT_PREVIOUS_COMMIT");

        /// <summary>
        ///    For Git-based projects, this variable contains the Git hash of the last successful build (like ce9a3c1404e8c91be604088670e93434c4253f03) ﻿(all the Git* properties require git plugin).
        /// </summary>
        public string GitPreviousSuccessfulCommit => Variable<string>("GIT_PREVIOUS_SUCCESSFUL_COMMIT");

        /// <summary>
        ///    For Git-based projects, this variable contains the Git url (like git@github.com:user/repo.git or [https://github.com/user/repo.git])  (all the Git* properties require git plugin).
        /// </summary>
        public string GitUrl => Variable<string>("GIT_URL");

        /// <summary>
        ///     The path to the jenkins home directory.
        /// </summary>
        public string JenkinsHome => Variable<string>("JENKINS_HOME");

        /// <summary>
        /// The jenkins server cookie.
        /// </summary>
        public string JenkinsServerCookie => Variable<string>("JENKINS_SERVER_COOKIE");

        /// <summary>
        /// The base name of the current job, such as "Nuke".
        /// </summary>
        public string JobBaseName => Variable<string>("JOB_BASE_NAME");

        /// <summary>
        /// The url to the currents job overview.
        /// </summary>
        public string JobDisplayUrl => Variable<string>("JOB_DISPLAY_URL");

        /// <summary>
        /// The  name of the current job, such as "Nuke".
        /// </summary>
        public string JobName => Variable<string>("JOB_NAME");

        /// <summary>
        /// The  labels of the node this build is running on, such as "win64 msbuild".
        /// </summary>
        public string NodeLabels => Variable<string>("NODE_LABELS");

        /// <summary>
        /// The name of the node this build is running on, such as "master".
        /// </summary>
        public string NodeName => Variable<string>("NODE_NAME");

        /// <summary>
        /// The url to the currents run changes page.
        /// </summary>
        public string RunChangesDisplayUrl => Variable<string>("RUN_CHANGES_DISPLAY_URL");

        /// <summary>
        /// The url to the currents run overview page.
        /// </summary>
        public string RunDisplayUrl => Variable<string>("RUN_DISPLAY_URL");

        /// <summary>
        /// The path to the folder this job is running in.
        /// </summary>
        public string Workspace => Variable<string>("WORKSPACE");
    }
}
