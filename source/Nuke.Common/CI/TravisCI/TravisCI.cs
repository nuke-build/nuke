// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.TravisCI
{
    /// <summary>
    /// Interface according to the <a href="https://docs.travis-ci.com/user/environment-variables/">official website</a>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public partial class TravisCI : Host, IBuildServer
    {
        public new static TravisCI Instance => Host.Instance as TravisCI;

        internal static bool IsRunningTravisCI => EnvironmentInfo.HasVariable("TRAVIS");

        internal TravisCI()
        {
        }

        string IBuildServer.Branch => Branch;
        string IBuildServer.Commit => Commit;

        public bool Ci => EnvironmentInfo.GetVariable<bool>("CI");
        public bool ContinousIntegration => EnvironmentInfo.GetVariable<bool>("CONTINUOUS_INTEGRATION");

        /// <summary>
        /// Whether you have defined any encrypted variables, including variables defined in the Repository Settings.
        /// </summary>
        public bool SecureEnvVars => EnvironmentInfo.GetVariable<bool>("TRAVIS_SECURE_ENV_VARS");

        /// <summary>
        /// For push builds, or builds not triggered by a pull request, this is the name of the branch.
        /// For builds triggered by a pull request this is the name of the branch targeted by the pull request.
        /// For builds triggered by a tag, this is the same as the name of the tag (<c>TRAVIS_TAG</c>).
        /// </summary>
        public string Branch => EnvironmentInfo.GetVariable("TRAVIS_BRANCH");

        /// <summary>
        /// The absolute path to the directory where the repository being built has been copied on the worker.
        /// </summary>
        public string BuildDir => EnvironmentInfo.GetVariable("TRAVIS_BUILD_DIR");

        /// <summary>
        ///  The id of the current build that Travis CI uses internally.
        /// </summary>
        public long BuildId => EnvironmentInfo.GetVariable<long>("TRAVIS_BUILD_ID");

        /// <summary>
        /// The number of the current build (for example, “4”).
        /// </summary>
        public long BuildNumber => EnvironmentInfo.GetVariable<long>("TRAVIS_BUILD_NUMBER");

        /// <summary>
        /// The commit that the current build is testing.
        /// </summary>
        public string Commit => EnvironmentInfo.GetVariable("TRAVIS_COMMIT");

        /// <summary>
        /// The commit subject and body, unwrapped.
        /// </summary>
        public string CommitMessage => EnvironmentInfo.GetVariable("TRAVIS_COMMIT_MESSAGE");

        /// <summary>
        /// The range of commits that were included in the push or pull request. (Note that this is empty for builds triggered by the initial commit of a new branch.)
        /// </summary>
        public string CommitRange => EnvironmentInfo.GetVariable("TRAVIS_COMMIT_RANGE");

        /// <summary>
        /// Indicates how the build was triggered.
        /// </summary>
        public TravisCIEventType EventType => EnvironmentInfo.GetVariable<TravisCIEventType>("TRAVIS_EVENT_TYPE");

        /// <summary>
        /// The id of the current job that Travis CI uses internally.
        /// </summary>
        public long JobId => EnvironmentInfo.GetVariable<long>("TRAVIS_JOB_ID");

        /// <summary>
        /// The number of the current job (for example, “4.1”).
        /// </summary>
        [NoConvert] public string JobNumber => EnvironmentInfo.GetVariable("TRAVIS_JOB_NUMBER");

        /// <summary>
        /// On multi-OS builds, this value indicates the platform the job is running on. Values are <c>linux</c> and <c>osx</c> currently, to be extended in the future.
        /// </summary>
        public string OsName => EnvironmentInfo.GetVariable("TRAVIS_OS_NAME");

        /// <summary>
        /// <c>TRAVIS_PULL_REQUEST</c> is set to the pull request number if the current job is a pull request build, or <c>false</c> if it’s not.
        /// </summary>
        [NoConvert] public string PullRequest => EnvironmentInfo.GetVariable("TRAVIS_PULL_REQUEST");

        /// <summary>
        /// If the current job is a pull request, the name of the branch from which the PR originated.
        /// If the current job is a push build, this variable is empty(<c>""</c>).
        /// </summary>
        public string PullRequestBranch => EnvironmentInfo.GetVariable("TRAVIS_PULL_REQUEST_BRANCH");

        /// <summary>
        /// If the current job is a pull request, the commit SHA of the HEAD commit of the PR.
        /// If the current job is a push build, this variable is empty(<c>""</c>).
        /// </summary>
        public string PullRequestSha => EnvironmentInfo.GetVariable("TRAVIS_PULL_REQUEST_SHA");

        /// <summary>
        /// If the current job is a pull request, the slug (in the form <c>owner_name/repo_name</c>) of the repository from which the PR originated.
        /// If the current job is a push build, this variable is empty(<c>""</c>).
        /// </summary>
        public string PullRequestSlug => EnvironmentInfo.GetVariable("TRAVIS_PULL_REQUEST_SLUG");

        /// <summary>
        /// The slug (in form: <c>owner_name/repo_name</c>) of the repository currently being built.
        /// </summary>
        public string RepoSlug => EnvironmentInfo.GetVariable("TRAVIS_REPO_SLUG");

        /// <summary>
        /// <c>true</c> or <c>false</c> based on whether sudo is enabled.
        /// </summary>
        public bool Sudo => EnvironmentInfo.GetVariable<bool>("TRAVIS_SUDO");

        /// <summary>
        /// Is set to <em>0</em> if the build is successful and <em>1</em> if the build is broken.
        /// </summary>
        [CanBeNull] public string TestResult => EnvironmentInfo.GetVariable("TRAVIS_TEST_RESULT");

        /// <summary>
        /// If the current build is for a git tag, this variable is set to the tag’s name.
        /// </summary>
        public string Tag => EnvironmentInfo.GetVariable("TRAVIS_TAG");

        [CanBeNull] public string DartVersion => EnvironmentInfo.GetVariable("TRAVIS_DARTVersion");
        [CanBeNull] public string GoVersion => EnvironmentInfo.GetVariable("TRAVIS_GOVersion");
        [CanBeNull] public string HaxeVersion => EnvironmentInfo.GetVariable("TRAVIS_HAXEVersion");
        [CanBeNull] public string JdkVersion => EnvironmentInfo.GetVariable("TRAVIS_JDKVersion");
        [CanBeNull] public string JuliaVersion => EnvironmentInfo.GetVariable("TRAVIS_JULIAVersion");
        [CanBeNull] public string NodeVersion => EnvironmentInfo.GetVariable("TRAVIS_NODEVersion");
        [CanBeNull] public string OtpRelease => EnvironmentInfo.GetVariable("TRAVIS_OTP_RELEASE");
        [CanBeNull] public string PerlVersion => EnvironmentInfo.GetVariable("TRAVIS_PERLVersion");
        [CanBeNull] public string PhpVersion => EnvironmentInfo.GetVariable("TRAVIS_PHPVersion");
        [CanBeNull] public string PythonVersion => EnvironmentInfo.GetVariable("TRAVIS_PYTHONVersion");
        [CanBeNull] public string RVersion => EnvironmentInfo.GetVariable("TRAVIS_RVersion");
        [CanBeNull] public string RubyVersion => EnvironmentInfo.GetVariable("TRAVIS_RUBYVersion");
        [CanBeNull] public string RustVersion => EnvironmentInfo.GetVariable("TRAVIS_RUSTVersion");
        [CanBeNull] public string ScalaVersion => EnvironmentInfo.GetVariable("TRAVIS_SCALAVersion");
        [CanBeNull] public string XCodeSdk => EnvironmentInfo.GetVariable("TRAVIS_XCODE_SDK");
        [CanBeNull] public string XCodeScheme => EnvironmentInfo.GetVariable("TRAVIS_XCODE_SCHEME");
        [CanBeNull] public string XCodeProject => EnvironmentInfo.GetVariable("TRAVIS_XCODE_PROJECT");
        [CanBeNull] public string XCodeWorkspace => EnvironmentInfo.GetVariable("TRAVIS_XCODE_WORKSPACE");
    }
}
