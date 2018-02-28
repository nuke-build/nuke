// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using static Nuke.Core.EnvironmentInfo;

namespace Nuke.Core.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="https://docs.travis-ci.com/user/environment-variables/">official website</a>.
    /// </summary>
    [BuildServer]
    public class Travis
    {
        private static Lazy<Travis> s_instance = new Lazy<Travis>(() => new Travis());

        public static Travis Instance => NukeBuild.Instance?.Host == HostType.Travis ? s_instance.Value : null;

        internal static bool IsRunningTravis => Variable("TRAVIS") != null;

        internal Travis()
        {
        }

        public bool Ci => EnsureVariable<bool>("CI");
        public bool ContinousIntegration => EnsureVariable<bool>("CONTINUOUS_INTEGRATION");

        /// <summary>
        /// Whether you have defined any encrypted variables, including variables defined in the Repository Settings.
        /// </summary>
        public bool SecureEnvVars => EnsureVariable<bool>("TRAVIS_SECURE_ENV_VARS");

        /// <summary>
        /// Set to <c>true</c> if the job is allowed to fail otherwhise <c>false</c>.
        /// </summary>
        public bool AllowFailure => EnsureVariable<bool>("TRAVIS_ALLOW_FAILURE");

        /// <summary>
        /// For push builds, or builds not triggered by a pull request, this is the name of the branch.
        /// For builds triggered by a pull request this is the name of the branch targeted by the pull request.
        /// For builds triggered by a tag, this is the same as the name of the tag (<c>TRAVIS_TAG</c>).
        /// </summary>
        public string Branch => EnsureVariable("TRAVIS_BRANCH");

        /// <summary>
        /// The absolute path to the directory where the repository being built has been copied on the worker.
        /// </summary>
        public string BuildDir => EnsureVariable("TRAVIS_BUILD_DIR");

        /// <summary>
        ///  The id of the current build that Travis CI uses internally.
        /// </summary>
        public string BuildId => EnsureVariable("TRAVIS_BUILD_ID");

        /// <summary>
        /// The number of the current build (for example, “4”).
        /// </summary>
        public int BuildNumber => EnsureVariable<int>("TRAVIS_BUILD_NUMBER");

        /// <summary>
        /// The commit that the current build is testing.
        /// </summary>
        public string Commit => EnsureVariable("TRAVIS_COMMIT");

        /// <summary>
        /// The commit subject and body, unwrapped.
        /// </summary>
        public string CommitMessage => EnsureVariable("TRAVIS_COMMIT_MESSAGE");

        /// <summary>
        /// The range of commits that were included in the push or pull request. (Note that this is empty for builds triggered by the initial commit of a new branch.)
        /// </summary>
        public string CommitRange => Variable("TRAVIS_COMMIT_RANGE");

        /// <summary>
        /// Indicates how the build was triggered. 
        /// </summary>
        public TravisEventType EventType => EnsureVariable<TravisEventType>("TRAVIS_EVENT_TYPE");

        /// <summary>
        /// The id of the current job that Travis CI uses internally.
        /// </summary>
        public string JobId => EnsureVariable("TRAVIS_JOB_ID");

        /// <summary>
        /// The number of the current job (for example, “4.1”).
        /// </summary>
        public string JobNumber => EnsureVariable("TRAVIS_JOB_NUMBER");

        /// <summary>
        /// On multi-OS builds, this value indicates the platform the job is running on. Values are <c>linux</c> and <c>osx</c> currently, to be extended in the future.
        /// </summary>
        public string OsName => Variable("TRAVIS_OS_NAME");

        /// <summary>
        /// <c>TRAVIS_PULL_REQUEST</c> is set to the pull request number if the current job is a pull request build, or <c>false</c> if it’s not.
        /// </summary>
        public string PullRequest => EnsureVariable("TRAVIS_PULL_REQUEST");

        /// <summary>
        /// If the current job is a pull request, the name of the branch from which the PR originated.
        /// If the current job is a push build, this variable is empty(<c>""</c>).
        /// </summary>
        public string PullRequestBranch => EnsureVariable("TRAVIS_PULL_REQUEST_BRANCH");

        /// <summary>
        /// If the current job is a pull request, the commit SHA of the HEAD commit of the PR.
        /// If the current job is a push build, this variable is empty(<c>""</c>).
        /// </summary>
        public string PullRequestSha => EnsureVariable("TRAVIS_PULL_REQUEST_SHA");

        /// <summary>
        /// If the current job is a pull request, the slug (in the form <c>owner_name/repo_name</c>) of the repository from which the PR originated.
        /// If the current job is a push build, this variable is empty(<c>""</c>).
        /// </summary>
        public string PullRequestSlug => EnsureVariable("TRAVIS_PULL_REQUEST_SLUG");

        /// <summary>
        /// The slug (in form: <c>owner_name/repo_name</c>) of the repository currently being built.
        /// </summary>
        public string RepoSlug => EnsureVariable("TRAVIS_REPO_SLUG");

        /// <summary>
        /// <c>true</c> or <c>false</c> based on whether sudo is enabled.
        /// </summary>
        public string Sudo => EnsureVariable("TRAVIS_SUDO");

        /// <summary>
        /// Is set to <em>0</em> if the build is successful and <em>1</em> if the build is broken.
        /// </summary>
        public string TestResult => EnsureVariable("TRAVIS_TEST_RESULT");

        /// <summary>
        /// If the current build is for a git tag, this variable is set to the tag’s name.
        /// </summary>
        public string Tag => Variable("TRAVIS_TAG");

        public string DartVersion => Variable("TRAVIS_DARTVersion");
        public string GoVersion => Variable("TRAVIS_GOVersion");
        public string HaxeVersion => Variable("TRAVIS_HAXEVersion");
        public string JdkVersion => Variable("TRAVIS_JDKVersion");
        public string JuliaVersion => Variable("TRAVIS_JULIAVersion");
        public string NodeVersion => Variable("TRAVIS_NODEVersion");
        public string OtpRelease => Variable("TRAVIS_OTP_RELEASE");
        public string PerlVersion => Variable("TRAVIS_PERLVersion");
        public string PhpVersion => Variable("TRAVIS_PHPVersion");
        public string PythonVersion => Variable("TRAVIS_PYTHONVersion");
        public string RVersion => Variable("TRAVIS_RVersion");
        public string RubyVersion => Variable("TRAVIS_RUBYVersion");
        public string RustVersion => Variable("TRAVIS_RUSTVersion");
        public string ScalaVersion => Variable("TRAVIS_SCALAVersion");
        public string XCodeSdk => Variable("TRAVIS_XCODE_SDK");
        public string XCodeScheme => Variable("TRAVIS_XCODE_SCHEME");
        public string XCodeProject => Variable("TRAVIS_XCODE_PROJECT");
        public string XCodeWorkspace => Variable("TRAVIS_XCODE_WORKSPACE");
    }
}
