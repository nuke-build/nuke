using System;
using System.Linq;

namespace Nuke.Core.BuildServers
{
    /// <summary>
    ///     Interface according to the
    ///     <a href="https://wiki.jenkins.io/display/JENKINS/Building+a+software+project">official website</a>.
    /// </summary>
    [BuildServer]
    public class Jenkins
    {
        public static Jenkins Instance { get; } =  EnvironmentInfo.Variable("JENKINS_URL") != null ? new Jenkins() : null;

        private Jenkins ()
        {
        }

        /// <summary>
        ///     The current build number, such as "153"
        /// </summary>
        public int BuildNumber => EnvironmentInfo.EnsureVariable<int>("BUILD_NUMBER");

        /// <summary>
        ///     The current build id, such as "2005-08-22_23-59-59" (YYYY-MM-DD_hh-mm-ss,
        ///     <a href="https://issues.jenkins-ci.org/browse/JENKINS-26520">defunct</a> since version 1.597)
        /// </summary>
        public string BuildId => EnvironmentInfo.EnsureVariable("BUILD_ID");

        /// <summary>
        ///     The URL where the results of this build can be found (e.g. http://buildserver/jenkins/job/MyJobName/666/)
        /// </summary>
        public string BuildUrl => EnvironmentInfo.EnsureVariable("BUILD_URL");

        /// <summary>
        ///     The name of the node the current build is running on. Equals 'master' for master node.
        /// </summary>
        public string NodeName => EnvironmentInfo.EnsureVariable("NODE_NAME");

        /// <summary>
        ///     Name of the project of this build. This is the name you gave your job when you first set it up. It's the third
        ///     column of the Jenkins Dashboard main page.
        /// </summary>
        public string JobName => EnvironmentInfo.EnsureVariable("JOB_NAME");

        /// <summary>
        ///     String of jenkins-${JOB_NAME}-${BUILD_NUMBER}. Convenient to put into a resource file, a jar file, etc for easier
        ///     identification.
        /// </summary>
        public string BuildTag => EnvironmentInfo.EnsureVariable("BUILD_TAG");

        /// <summary>
        ///     Set to the URL of the Jenkins master that's running the build. This value is used by Jenkins CLI for exampl
        /// </summary>
        public string JenkinsUrl => EnvironmentInfo.EnsureVariable("JENKINS_URL");

        /// <summary>
        ///     The unique number that identifies the current executor (among executors of the same machine) that's carrying out
        ///     this build. This is the number you see in the "build executor status", except that the number starts from 0, not 1.
        /// </summary>
        public string ExecutorNumber => EnvironmentInfo.EnsureVariable("EXECUTOR_NUMBER");
    }
}
