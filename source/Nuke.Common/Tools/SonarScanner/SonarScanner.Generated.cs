// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/SonarScanner.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.SonarScanner
{
    /// <summary>
    ///   <p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p>
    ///   <p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SonarScannerTasks
    {
        /// <summary>
        ///   Path to the SonarScanner executable.
        /// </summary>
        public static string SonarScannerPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("SONARSCANNER_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> SonarScannerLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p>
        ///   <p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> SonarScanner(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, bool? logTimestamp = null, string logFile = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(SonarScannerPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logTimestamp, logFile, SonarScannerLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p>
        ///   <p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/d:sonar.branch.name</c> via <see cref="SonarScannerBeginSettings.BranchName"/></li>
        ///     <li><c>/d:sonar.coverage.exclusions</c> via <see cref="SonarScannerBeginSettings.CoverageExclusions"/></li>
        ///     <li><c>/d:sonar.coverageReportPaths</c> via <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></li>
        ///     <li><c>/d:sonar.cpd.exclusions</c> via <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></li>
        ///     <li><c>/d:sonar.cs.dotcover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.DotCoverPaths"/></li>
        ///     <li><c>/d:sonar.cs.nunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.NUnitTestReports"/></li>
        ///     <li><c>/d:sonar.cs.opencover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></li>
        ///     <li><c>/d:sonar.cs.vscoveragexml.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></li>
        ///     <li><c>/d:sonar.cs.vstest.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VSTestReports"/></li>
        ///     <li><c>/d:sonar.cs.xunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.XUnitTestReports"/></li>
        ///     <li><c>/d:sonar.exclusions</c> via <see cref="SonarScannerBeginSettings.SourceExclusions"/></li>
        ///     <li><c>/d:sonar.host.url</c> via <see cref="SonarScannerBeginSettings.Server"/></li>
        ///     <li><c>/d:sonar.inclusions</c> via <see cref="SonarScannerBeginSettings.SourceInclusions"/></li>
        ///     <li><c>/d:sonar.links.ci</c> via <see cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/></li>
        ///     <li><c>/d:sonar.links.homepage</c> via <see cref="SonarScannerBeginSettings.Homepage"/></li>
        ///     <li><c>/d:sonar.links.issue</c> via <see cref="SonarScannerBeginSettings.IssueTrackerUrl"/></li>
        ///     <li><c>/d:sonar.links.scm</c> via <see cref="SonarScannerBeginSettings.SCMUrl"/></li>
        ///     <li><c>/d:sonar.login</c> via <see cref="SonarScannerBeginSettings.Login"/></li>
        ///     <li><c>/d:sonar.password</c> via <see cref="SonarScannerBeginSettings.Password"/></li>
        ///     <li><c>/d:sonar.projectDescription</c> via <see cref="SonarScannerBeginSettings.Description"/></li>
        ///     <li><c>/d:sonar.pullrequest.base</c> via <see cref="SonarScannerBeginSettings.PullRequestBase"/></li>
        ///     <li><c>/d:sonar.pullrequest.branch</c> via <see cref="SonarScannerBeginSettings.PullRequestBranch"/></li>
        ///     <li><c>/d:sonar.pullrequest.key</c> via <see cref="SonarScannerBeginSettings.PullRequestKey"/></li>
        ///     <li><c>/d:sonar.sourceEncoding</c> via <see cref="SonarScannerBeginSettings.SourceEncoding"/></li>
        ///     <li><c>/d:sonar.test.exclusions</c> via <see cref="SonarScannerBeginSettings.TestFileExclusions"/></li>
        ///     <li><c>/d:sonar.test.inclusions</c> via <see cref="SonarScannerBeginSettings.TestFileInclusions"/></li>
        ///     <li><c>/d:sonar.verbose</c> via <see cref="SonarScannerBeginSettings.Verbose"/></li>
        ///     <li><c>/d:sonar.ws.timeout</c> via <see cref="SonarScannerBeginSettings.WebServiceTimeout"/></li>
        ///     <li><c>/k</c> via <see cref="SonarScannerBeginSettings.ProjectKey"/></li>
        ///     <li><c>/n</c> via <see cref="SonarScannerBeginSettings.Name"/></li>
        ///     <li><c>/v</c> via <see cref="SonarScannerBeginSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> SonarScannerBegin(SonarScannerBeginSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new SonarScannerBeginSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p>
        ///   <p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/d:sonar.branch.name</c> via <see cref="SonarScannerBeginSettings.BranchName"/></li>
        ///     <li><c>/d:sonar.coverage.exclusions</c> via <see cref="SonarScannerBeginSettings.CoverageExclusions"/></li>
        ///     <li><c>/d:sonar.coverageReportPaths</c> via <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></li>
        ///     <li><c>/d:sonar.cpd.exclusions</c> via <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></li>
        ///     <li><c>/d:sonar.cs.dotcover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.DotCoverPaths"/></li>
        ///     <li><c>/d:sonar.cs.nunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.NUnitTestReports"/></li>
        ///     <li><c>/d:sonar.cs.opencover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></li>
        ///     <li><c>/d:sonar.cs.vscoveragexml.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></li>
        ///     <li><c>/d:sonar.cs.vstest.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VSTestReports"/></li>
        ///     <li><c>/d:sonar.cs.xunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.XUnitTestReports"/></li>
        ///     <li><c>/d:sonar.exclusions</c> via <see cref="SonarScannerBeginSettings.SourceExclusions"/></li>
        ///     <li><c>/d:sonar.host.url</c> via <see cref="SonarScannerBeginSettings.Server"/></li>
        ///     <li><c>/d:sonar.inclusions</c> via <see cref="SonarScannerBeginSettings.SourceInclusions"/></li>
        ///     <li><c>/d:sonar.links.ci</c> via <see cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/></li>
        ///     <li><c>/d:sonar.links.homepage</c> via <see cref="SonarScannerBeginSettings.Homepage"/></li>
        ///     <li><c>/d:sonar.links.issue</c> via <see cref="SonarScannerBeginSettings.IssueTrackerUrl"/></li>
        ///     <li><c>/d:sonar.links.scm</c> via <see cref="SonarScannerBeginSettings.SCMUrl"/></li>
        ///     <li><c>/d:sonar.login</c> via <see cref="SonarScannerBeginSettings.Login"/></li>
        ///     <li><c>/d:sonar.password</c> via <see cref="SonarScannerBeginSettings.Password"/></li>
        ///     <li><c>/d:sonar.projectDescription</c> via <see cref="SonarScannerBeginSettings.Description"/></li>
        ///     <li><c>/d:sonar.pullrequest.base</c> via <see cref="SonarScannerBeginSettings.PullRequestBase"/></li>
        ///     <li><c>/d:sonar.pullrequest.branch</c> via <see cref="SonarScannerBeginSettings.PullRequestBranch"/></li>
        ///     <li><c>/d:sonar.pullrequest.key</c> via <see cref="SonarScannerBeginSettings.PullRequestKey"/></li>
        ///     <li><c>/d:sonar.sourceEncoding</c> via <see cref="SonarScannerBeginSettings.SourceEncoding"/></li>
        ///     <li><c>/d:sonar.test.exclusions</c> via <see cref="SonarScannerBeginSettings.TestFileExclusions"/></li>
        ///     <li><c>/d:sonar.test.inclusions</c> via <see cref="SonarScannerBeginSettings.TestFileInclusions"/></li>
        ///     <li><c>/d:sonar.verbose</c> via <see cref="SonarScannerBeginSettings.Verbose"/></li>
        ///     <li><c>/d:sonar.ws.timeout</c> via <see cref="SonarScannerBeginSettings.WebServiceTimeout"/></li>
        ///     <li><c>/k</c> via <see cref="SonarScannerBeginSettings.ProjectKey"/></li>
        ///     <li><c>/n</c> via <see cref="SonarScannerBeginSettings.Name"/></li>
        ///     <li><c>/v</c> via <see cref="SonarScannerBeginSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> SonarScannerBegin(Configure<SonarScannerBeginSettings> configurator)
        {
            return SonarScannerBegin(configurator(new SonarScannerBeginSettings()));
        }
        /// <summary>
        ///   <p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p>
        ///   <p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/d:sonar.branch.name</c> via <see cref="SonarScannerBeginSettings.BranchName"/></li>
        ///     <li><c>/d:sonar.coverage.exclusions</c> via <see cref="SonarScannerBeginSettings.CoverageExclusions"/></li>
        ///     <li><c>/d:sonar.coverageReportPaths</c> via <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></li>
        ///     <li><c>/d:sonar.cpd.exclusions</c> via <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></li>
        ///     <li><c>/d:sonar.cs.dotcover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.DotCoverPaths"/></li>
        ///     <li><c>/d:sonar.cs.nunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.NUnitTestReports"/></li>
        ///     <li><c>/d:sonar.cs.opencover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></li>
        ///     <li><c>/d:sonar.cs.vscoveragexml.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></li>
        ///     <li><c>/d:sonar.cs.vstest.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VSTestReports"/></li>
        ///     <li><c>/d:sonar.cs.xunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.XUnitTestReports"/></li>
        ///     <li><c>/d:sonar.exclusions</c> via <see cref="SonarScannerBeginSettings.SourceExclusions"/></li>
        ///     <li><c>/d:sonar.host.url</c> via <see cref="SonarScannerBeginSettings.Server"/></li>
        ///     <li><c>/d:sonar.inclusions</c> via <see cref="SonarScannerBeginSettings.SourceInclusions"/></li>
        ///     <li><c>/d:sonar.links.ci</c> via <see cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/></li>
        ///     <li><c>/d:sonar.links.homepage</c> via <see cref="SonarScannerBeginSettings.Homepage"/></li>
        ///     <li><c>/d:sonar.links.issue</c> via <see cref="SonarScannerBeginSettings.IssueTrackerUrl"/></li>
        ///     <li><c>/d:sonar.links.scm</c> via <see cref="SonarScannerBeginSettings.SCMUrl"/></li>
        ///     <li><c>/d:sonar.login</c> via <see cref="SonarScannerBeginSettings.Login"/></li>
        ///     <li><c>/d:sonar.password</c> via <see cref="SonarScannerBeginSettings.Password"/></li>
        ///     <li><c>/d:sonar.projectDescription</c> via <see cref="SonarScannerBeginSettings.Description"/></li>
        ///     <li><c>/d:sonar.pullrequest.base</c> via <see cref="SonarScannerBeginSettings.PullRequestBase"/></li>
        ///     <li><c>/d:sonar.pullrequest.branch</c> via <see cref="SonarScannerBeginSettings.PullRequestBranch"/></li>
        ///     <li><c>/d:sonar.pullrequest.key</c> via <see cref="SonarScannerBeginSettings.PullRequestKey"/></li>
        ///     <li><c>/d:sonar.sourceEncoding</c> via <see cref="SonarScannerBeginSettings.SourceEncoding"/></li>
        ///     <li><c>/d:sonar.test.exclusions</c> via <see cref="SonarScannerBeginSettings.TestFileExclusions"/></li>
        ///     <li><c>/d:sonar.test.inclusions</c> via <see cref="SonarScannerBeginSettings.TestFileInclusions"/></li>
        ///     <li><c>/d:sonar.verbose</c> via <see cref="SonarScannerBeginSettings.Verbose"/></li>
        ///     <li><c>/d:sonar.ws.timeout</c> via <see cref="SonarScannerBeginSettings.WebServiceTimeout"/></li>
        ///     <li><c>/k</c> via <see cref="SonarScannerBeginSettings.ProjectKey"/></li>
        ///     <li><c>/n</c> via <see cref="SonarScannerBeginSettings.Name"/></li>
        ///     <li><c>/v</c> via <see cref="SonarScannerBeginSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(SonarScannerBeginSettings Settings, IReadOnlyCollection<Output> Output)> SonarScannerBegin(CombinatorialConfigure<SonarScannerBeginSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(SonarScannerBegin, SonarScannerLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p>
        ///   <p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/d:sonar.login</c> via <see cref="SonarScannerEndSettings.Login"/></li>
        ///     <li><c>/d:sonar.password</c> via <see cref="SonarScannerEndSettings.Password"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> SonarScannerEnd(SonarScannerEndSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new SonarScannerEndSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p>
        ///   <p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/d:sonar.login</c> via <see cref="SonarScannerEndSettings.Login"/></li>
        ///     <li><c>/d:sonar.password</c> via <see cref="SonarScannerEndSettings.Password"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> SonarScannerEnd(Configure<SonarScannerEndSettings> configurator)
        {
            return SonarScannerEnd(configurator(new SonarScannerEndSettings()));
        }
        /// <summary>
        ///   <p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p>
        ///   <p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>/d:sonar.login</c> via <see cref="SonarScannerEndSettings.Login"/></li>
        ///     <li><c>/d:sonar.password</c> via <see cref="SonarScannerEndSettings.Password"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(SonarScannerEndSettings Settings, IReadOnlyCollection<Output> Output)> SonarScannerEnd(CombinatorialConfigure<SonarScannerEndSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(SonarScannerEnd, SonarScannerLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region SonarScannerBeginSettings
    /// <summary>
    ///   Used within <see cref="SonarScannerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SonarScannerBeginSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the SonarScanner executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => SonarScannerTasks.SonarScannerLogger;
        /// <summary>
        ///   Specifies the key of the analyzed project in SonarQube.
        /// </summary>
        public virtual string ProjectKey { get; internal set; }
        /// <summary>
        ///   Specifies the name of the analyzed project in SonarQube. Adding this argument will overwrite the project name in SonarQube if it already exists.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   Specifies the version of your project.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The project description.
        /// </summary>
        public virtual string Description { get; internal set; }
        /// <summary>
        ///   The server URL. Default is <c>http://localhost:9000</c>
        /// </summary>
        public virtual string Server { get; internal set; }
        /// <summary>
        ///   Specifies the username or access token to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added on the end step.
        /// </summary>
        public virtual string Login { get; internal set; }
        /// <summary>
        ///   Specifies the password for the SonarQube username in the <c>sonar.login</c> argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Sets the logging verbosity to detailed. Add this argument before sending logs for troubleshooting.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Comma separated list of VSTest report files to include.
        /// </summary>
        public virtual IReadOnlyList<string> VSTestReports => VSTestReportsInternal.AsReadOnly();
        internal List<string> VSTestReportsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of NUnit report files to include.
        /// </summary>
        public virtual IReadOnlyList<string> NUnitTestReports => NUnitTestReportsInternal.AsReadOnly();
        internal List<string> NUnitTestReportsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of xUnit report files to include.
        /// </summary>
        public virtual IReadOnlyList<string> XUnitTestReports => XUnitTestReportsInternal.AsReadOnly();
        internal List<string> XUnitTestReportsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of source files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).
        /// </summary>
        public virtual IReadOnlyList<string> SourceExclusions => SourceExclusionsInternal.AsReadOnly();
        internal List<string> SourceExclusionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of source files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).
        /// </summary>
        public virtual IReadOnlyList<string> SourceInclusions => SourceInclusionsInternal.AsReadOnly();
        internal List<string> SourceInclusionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of test files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).
        /// </summary>
        public virtual IReadOnlyList<string> TestFileExclusions => TestFileExclusionsInternal.AsReadOnly();
        internal List<string> TestFileExclusionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of test files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).
        /// </summary>
        public virtual IReadOnlyList<string> TestFileInclusions => TestFileInclusionsInternal.AsReadOnly();
        internal List<string> TestFileInclusionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of files to exclude from coverage calculations. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).
        /// </summary>
        public virtual IReadOnlyList<string> CoverageExclusions => CoverageExclusionsInternal.AsReadOnly();
        internal List<string> CoverageExclusionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of coverage reports in the <a href="https://docs.sonarqube.org/latest/analysis/generic-test/">Generic Test Data</a> format. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).
        /// </summary>
        public virtual IReadOnlyList<string> GenericCoveragePaths => GenericCoveragePathsInternal.AsReadOnly();
        internal List<string> GenericCoveragePathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).
        /// </summary>
        public virtual IReadOnlyList<string> VisualStudioCoveragePaths => VisualStudioCoveragePathsInternal.AsReadOnly();
        internal List<string> VisualStudioCoveragePathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of dotCover HTML-reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).
        /// </summary>
        public virtual IReadOnlyList<string> DotCoverPaths => DotCoverPathsInternal.AsReadOnly();
        internal List<string> DotCoverPathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of OpenCover reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).
        /// </summary>
        public virtual IReadOnlyList<string> OpenCoverPaths => OpenCoverPathsInternal.AsReadOnly();
        internal List<string> OpenCoverPathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Maximum time to wait for the response of a Web Service call (in seconds). Modifying this value from the default is useful only when you're experiencing timeouts during analysis while waiting for the server to respond to Web Service calls.
        /// </summary>
        public virtual int? WebServiceTimeout { get; internal set; }
        /// <summary>
        ///   Project home page.
        /// </summary>
        public virtual string Homepage { get; internal set; }
        /// <summary>
        ///   Link to Continuous integration
        /// </summary>
        public virtual string ContinuousIntegrationUrl { get; internal set; }
        /// <summary>
        ///   Link to Issue tracker.
        /// </summary>
        public virtual string IssueTrackerUrl { get; internal set; }
        /// <summary>
        ///   Link to project source repository
        /// </summary>
        public virtual string SCMUrl { get; internal set; }
        /// <summary>
        ///   Encoding of the source files. Ex: <c>UTF-8</c> , <c>MacRoman</c> , <c>Shift_JIS</c>. This property can be replaced by the standard property <c>project.build.sourceEncoding</c> in Maven projects. The list of available encodings depends on your JVM.
        /// </summary>
        public virtual string SourceEncoding { get; internal set; }
        /// <summary>
        ///   Comma-delimited list of file path patterns to be excluded from duplication detection.
        /// </summary>
        public virtual IReadOnlyList<string> DuplicationExclusions => DuplicationExclusionsInternal.AsReadOnly();
        internal List<string> DuplicationExclusionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Name of the branch (visible in the UI)
        /// </summary>
        public virtual string BranchName { get; internal set; }
        /// <summary>
        ///   Unique identifier of your Pull Request. Must correspond to the key of the Pull Request in your ALM. e.g.: <c>sonar.pullrequest.key=5</c>
        /// </summary>
        public virtual string PullRequestKey { get; internal set; }
        /// <summary>
        ///   The name of the branch that contains the changes to be merged. e.g.: <c>sonar.pullrequest.branch=feature/my-new-feature</c>
        /// </summary>
        public virtual string PullRequestBranch { get; internal set; }
        /// <summary>
        ///   The branch into which the Pull Request will be merged. Default: <c>master</c>. e.g.: <c>sonar.pullrequest.base=master</c>
        /// </summary>
        public virtual string PullRequestBase { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("begin")
              .Add("/k:{value}", ProjectKey)
              .Add("/n:{value}", Name)
              .Add("/v:{value}", Version)
              .Add("/d:sonar.projectDescription={value}", Description)
              .Add("/d:sonar.host.url={value}", Server)
              .Add("/d:sonar.login={value}", Login)
              .Add("/d:sonar.password={value}", Password, secret: true)
              .Add("/d:sonar.verbose={value}", Verbose)
              .Add("/d:sonar.cs.vstest.reportsPaths={value}", VSTestReports, separator: ',')
              .Add("/d:sonar.cs.nunit.reportsPaths={value}", NUnitTestReports, separator: ',')
              .Add("/d:sonar.cs.xunit.reportsPaths={value}", XUnitTestReports, separator: ',')
              .Add("/d:sonar.exclusions={value}", SourceExclusions, separator: ',')
              .Add("/d:sonar.inclusions={value}", SourceInclusions, separator: ',')
              .Add("/d:sonar.test.exclusions={value}", TestFileExclusions, separator: ',')
              .Add("/d:sonar.test.inclusions={value}", TestFileInclusions, separator: ',')
              .Add("/d:sonar.coverage.exclusions={value}", CoverageExclusions, separator: ',')
              .Add("/d:sonar.coverageReportPaths={value}", GenericCoveragePaths, separator: ',')
              .Add("/d:sonar.cs.vscoveragexml.reportsPaths={value}", VisualStudioCoveragePaths, separator: ',')
              .Add("/d:sonar.cs.dotcover.reportsPaths={value}", DotCoverPaths, separator: ',')
              .Add("/d:sonar.cs.opencover.reportsPaths={value}", OpenCoverPaths, separator: ',')
              .Add("/d:sonar.ws.timeout={value}", WebServiceTimeout)
              .Add("/d:sonar.links.homepage={value}", Homepage)
              .Add("/d:sonar.links.ci={value}", ContinuousIntegrationUrl)
              .Add("/d:sonar.links.issue={value}", IssueTrackerUrl)
              .Add("/d:sonar.links.scm={value}", SCMUrl)
              .Add("/d:sonar.sourceEncoding={value}", SourceEncoding)
              .Add("/d:sonar.cpd.exclusions={value}", DuplicationExclusions, separator: ',')
              .Add("/d:sonar.branch.name={value}", BranchName)
              .Add("/d:sonar.pullrequest.key={value}", PullRequestKey)
              .Add("/d:sonar.pullrequest.branch={value}", PullRequestBranch)
              .Add("/d:sonar.pullrequest.base={value}", PullRequestBase);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region SonarScannerEndSettings
    /// <summary>
    ///   Used within <see cref="SonarScannerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SonarScannerEndSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the SonarScanner executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => SonarScannerTasks.SonarScannerLogger;
        /// <summary>
        ///   Specifies the username or access token to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added on the end step.
        /// </summary>
        public virtual string Login { get; internal set; }
        /// <summary>
        ///   Specifies the password for the SonarQube username in the <c>sonar.login</c> argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.
        /// </summary>
        public virtual string Password { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("end")
              .Add("/d:sonar.login={value}", Login)
              .Add("/d:sonar.password={value}", Password, secret: true);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region SonarScannerBeginSettingsExtensions
    /// <summary>
    ///   Used within <see cref="SonarScannerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SonarScannerBeginSettingsExtensions
    {
        #region ProjectKey
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.ProjectKey"/></em></p>
        ///   <p>Specifies the key of the analyzed project in SonarQube.</p>
        /// </summary>
        [Pure]
        public static T SetProjectKey<T>(this T toolSettings, string projectKey) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectKey = projectKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.ProjectKey"/></em></p>
        ///   <p>Specifies the key of the analyzed project in SonarQube.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectKey<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectKey = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Name"/></em></p>
        ///   <p>Specifies the name of the analyzed project in SonarQube. Adding this argument will overwrite the project name in SonarQube if it already exists.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Name"/></em></p>
        ///   <p>Specifies the name of the analyzed project in SonarQube. Adding this argument will overwrite the project name in SonarQube if it already exists.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Version"/></em></p>
        ///   <p>Specifies the version of your project.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Version"/></em></p>
        ///   <p>Specifies the version of your project.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Description"/></em></p>
        ///   <p>The project description.</p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Description"/></em></p>
        ///   <p>The project description.</p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region Server
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Server"/></em></p>
        ///   <p>The server URL. Default is <c>http://localhost:9000</c></p>
        /// </summary>
        [Pure]
        public static T SetServer<T>(this T toolSettings, string server) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = server;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Server"/></em></p>
        ///   <p>The server URL. Default is <c>http://localhost:9000</c></p>
        /// </summary>
        [Pure]
        public static T ResetServer<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = null;
            return toolSettings;
        }
        #endregion
        #region Login
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Login"/></em></p>
        ///   <p>Specifies the username or access token to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static T SetLogin<T>(this T toolSettings, string login) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Login = login;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Login"/></em></p>
        ///   <p>Specifies the username or access token to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static T ResetLogin<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Login = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Password"/></em></p>
        ///   <p>Specifies the password for the SonarQube username in the <c>sonar.login</c> argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Password"/></em></p>
        ///   <p>Specifies the password for the SonarQube username in the <c>sonar.login</c> argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Verbose"/></em></p>
        ///   <p>Sets the logging verbosity to detailed. Add this argument before sending logs for troubleshooting.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Verbose"/></em></p>
        ///   <p>Sets the logging verbosity to detailed. Add this argument before sending logs for troubleshooting.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SonarScannerBeginSettings.Verbose"/></em></p>
        ///   <p>Sets the logging verbosity to detailed. Add this argument before sending logs for troubleshooting.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SonarScannerBeginSettings.Verbose"/></em></p>
        ///   <p>Sets the logging verbosity to detailed. Add this argument before sending logs for troubleshooting.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SonarScannerBeginSettings.Verbose"/></em></p>
        ///   <p>Sets the logging verbosity to detailed. Add this argument before sending logs for troubleshooting.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region VSTestReports
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.VSTestReports"/> to a new list</em></p>
        ///   <p>Comma separated list of VSTest report files to include.</p>
        /// </summary>
        [Pure]
        public static T SetVSTestReports<T>(this T toolSettings, params string[] vstestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VSTestReportsInternal = vstestReports.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.VSTestReports"/> to a new list</em></p>
        ///   <p>Comma separated list of VSTest report files to include.</p>
        /// </summary>
        [Pure]
        public static T SetVSTestReports<T>(this T toolSettings, IEnumerable<string> vstestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VSTestReportsInternal = vstestReports.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.VSTestReports"/></em></p>
        ///   <p>Comma separated list of VSTest report files to include.</p>
        /// </summary>
        [Pure]
        public static T AddVSTestReports<T>(this T toolSettings, params string[] vstestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VSTestReportsInternal.AddRange(vstestReports);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.VSTestReports"/></em></p>
        ///   <p>Comma separated list of VSTest report files to include.</p>
        /// </summary>
        [Pure]
        public static T AddVSTestReports<T>(this T toolSettings, IEnumerable<string> vstestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VSTestReportsInternal.AddRange(vstestReports);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.VSTestReports"/></em></p>
        ///   <p>Comma separated list of VSTest report files to include.</p>
        /// </summary>
        [Pure]
        public static T ClearVSTestReports<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VSTestReportsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.VSTestReports"/></em></p>
        ///   <p>Comma separated list of VSTest report files to include.</p>
        /// </summary>
        [Pure]
        public static T RemoveVSTestReports<T>(this T toolSettings, params string[] vstestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(vstestReports);
            toolSettings.VSTestReportsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.VSTestReports"/></em></p>
        ///   <p>Comma separated list of VSTest report files to include.</p>
        /// </summary>
        [Pure]
        public static T RemoveVSTestReports<T>(this T toolSettings, IEnumerable<string> vstestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(vstestReports);
            toolSettings.VSTestReportsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NUnitTestReports
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.NUnitTestReports"/> to a new list</em></p>
        ///   <p>Comma separated list of NUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T SetNUnitTestReports<T>(this T toolSettings, params string[] nunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NUnitTestReportsInternal = nunitTestReports.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.NUnitTestReports"/> to a new list</em></p>
        ///   <p>Comma separated list of NUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T SetNUnitTestReports<T>(this T toolSettings, IEnumerable<string> nunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NUnitTestReportsInternal = nunitTestReports.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.NUnitTestReports"/></em></p>
        ///   <p>Comma separated list of NUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T AddNUnitTestReports<T>(this T toolSettings, params string[] nunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NUnitTestReportsInternal.AddRange(nunitTestReports);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.NUnitTestReports"/></em></p>
        ///   <p>Comma separated list of NUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T AddNUnitTestReports<T>(this T toolSettings, IEnumerable<string> nunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NUnitTestReportsInternal.AddRange(nunitTestReports);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.NUnitTestReports"/></em></p>
        ///   <p>Comma separated list of NUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T ClearNUnitTestReports<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NUnitTestReportsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.NUnitTestReports"/></em></p>
        ///   <p>Comma separated list of NUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T RemoveNUnitTestReports<T>(this T toolSettings, params string[] nunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(nunitTestReports);
            toolSettings.NUnitTestReportsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.NUnitTestReports"/></em></p>
        ///   <p>Comma separated list of NUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T RemoveNUnitTestReports<T>(this T toolSettings, IEnumerable<string> nunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(nunitTestReports);
            toolSettings.NUnitTestReportsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region XUnitTestReports
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.XUnitTestReports"/> to a new list</em></p>
        ///   <p>Comma separated list of xUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T SetXUnitTestReports<T>(this T toolSettings, params string[] xunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XUnitTestReportsInternal = xunitTestReports.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.XUnitTestReports"/> to a new list</em></p>
        ///   <p>Comma separated list of xUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T SetXUnitTestReports<T>(this T toolSettings, IEnumerable<string> xunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XUnitTestReportsInternal = xunitTestReports.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.XUnitTestReports"/></em></p>
        ///   <p>Comma separated list of xUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T AddXUnitTestReports<T>(this T toolSettings, params string[] xunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XUnitTestReportsInternal.AddRange(xunitTestReports);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.XUnitTestReports"/></em></p>
        ///   <p>Comma separated list of xUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T AddXUnitTestReports<T>(this T toolSettings, IEnumerable<string> xunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XUnitTestReportsInternal.AddRange(xunitTestReports);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.XUnitTestReports"/></em></p>
        ///   <p>Comma separated list of xUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T ClearXUnitTestReports<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XUnitTestReportsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.XUnitTestReports"/></em></p>
        ///   <p>Comma separated list of xUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T RemoveXUnitTestReports<T>(this T toolSettings, params string[] xunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(xunitTestReports);
            toolSettings.XUnitTestReportsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.XUnitTestReports"/></em></p>
        ///   <p>Comma separated list of xUnit report files to include.</p>
        /// </summary>
        [Pure]
        public static T RemoveXUnitTestReports<T>(this T toolSettings, IEnumerable<string> xunitTestReports) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(xunitTestReports);
            toolSettings.XUnitTestReportsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SourceExclusions
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.SourceExclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of source files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetSourceExclusions<T>(this T toolSettings, params string[] sourceExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceExclusionsInternal = sourceExclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.SourceExclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of source files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetSourceExclusions<T>(this T toolSettings, IEnumerable<string> sourceExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceExclusionsInternal = sourceExclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.SourceExclusions"/></em></p>
        ///   <p>Comma separated list of source files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddSourceExclusions<T>(this T toolSettings, params string[] sourceExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceExclusionsInternal.AddRange(sourceExclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.SourceExclusions"/></em></p>
        ///   <p>Comma separated list of source files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddSourceExclusions<T>(this T toolSettings, IEnumerable<string> sourceExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceExclusionsInternal.AddRange(sourceExclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.SourceExclusions"/></em></p>
        ///   <p>Comma separated list of source files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearSourceExclusions<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceExclusionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.SourceExclusions"/></em></p>
        ///   <p>Comma separated list of source files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveSourceExclusions<T>(this T toolSettings, params string[] sourceExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sourceExclusions);
            toolSettings.SourceExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.SourceExclusions"/></em></p>
        ///   <p>Comma separated list of source files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveSourceExclusions<T>(this T toolSettings, IEnumerable<string> sourceExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sourceExclusions);
            toolSettings.SourceExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SourceInclusions
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.SourceInclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of source files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetSourceInclusions<T>(this T toolSettings, params string[] sourceInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInclusionsInternal = sourceInclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.SourceInclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of source files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetSourceInclusions<T>(this T toolSettings, IEnumerable<string> sourceInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInclusionsInternal = sourceInclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.SourceInclusions"/></em></p>
        ///   <p>Comma separated list of source files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddSourceInclusions<T>(this T toolSettings, params string[] sourceInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInclusionsInternal.AddRange(sourceInclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.SourceInclusions"/></em></p>
        ///   <p>Comma separated list of source files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddSourceInclusions<T>(this T toolSettings, IEnumerable<string> sourceInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInclusionsInternal.AddRange(sourceInclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.SourceInclusions"/></em></p>
        ///   <p>Comma separated list of source files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearSourceInclusions<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInclusionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.SourceInclusions"/></em></p>
        ///   <p>Comma separated list of source files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveSourceInclusions<T>(this T toolSettings, params string[] sourceInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sourceInclusions);
            toolSettings.SourceInclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.SourceInclusions"/></em></p>
        ///   <p>Comma separated list of source files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveSourceInclusions<T>(this T toolSettings, IEnumerable<string> sourceInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sourceInclusions);
            toolSettings.SourceInclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TestFileExclusions
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.TestFileExclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of test files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetTestFileExclusions<T>(this T toolSettings, params string[] testFileExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestFileExclusionsInternal = testFileExclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.TestFileExclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of test files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetTestFileExclusions<T>(this T toolSettings, IEnumerable<string> testFileExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestFileExclusionsInternal = testFileExclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.TestFileExclusions"/></em></p>
        ///   <p>Comma separated list of test files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddTestFileExclusions<T>(this T toolSettings, params string[] testFileExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestFileExclusionsInternal.AddRange(testFileExclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.TestFileExclusions"/></em></p>
        ///   <p>Comma separated list of test files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddTestFileExclusions<T>(this T toolSettings, IEnumerable<string> testFileExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestFileExclusionsInternal.AddRange(testFileExclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.TestFileExclusions"/></em></p>
        ///   <p>Comma separated list of test files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearTestFileExclusions<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestFileExclusionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.TestFileExclusions"/></em></p>
        ///   <p>Comma separated list of test files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveTestFileExclusions<T>(this T toolSettings, params string[] testFileExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(testFileExclusions);
            toolSettings.TestFileExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.TestFileExclusions"/></em></p>
        ///   <p>Comma separated list of test files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveTestFileExclusions<T>(this T toolSettings, IEnumerable<string> testFileExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(testFileExclusions);
            toolSettings.TestFileExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TestFileInclusions
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.TestFileInclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of test files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetTestFileInclusions<T>(this T toolSettings, params string[] testFileInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestFileInclusionsInternal = testFileInclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.TestFileInclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of test files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetTestFileInclusions<T>(this T toolSettings, IEnumerable<string> testFileInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestFileInclusionsInternal = testFileInclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.TestFileInclusions"/></em></p>
        ///   <p>Comma separated list of test files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddTestFileInclusions<T>(this T toolSettings, params string[] testFileInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestFileInclusionsInternal.AddRange(testFileInclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.TestFileInclusions"/></em></p>
        ///   <p>Comma separated list of test files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddTestFileInclusions<T>(this T toolSettings, IEnumerable<string> testFileInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestFileInclusionsInternal.AddRange(testFileInclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.TestFileInclusions"/></em></p>
        ///   <p>Comma separated list of test files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearTestFileInclusions<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestFileInclusionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.TestFileInclusions"/></em></p>
        ///   <p>Comma separated list of test files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveTestFileInclusions<T>(this T toolSettings, params string[] testFileInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(testFileInclusions);
            toolSettings.TestFileInclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.TestFileInclusions"/></em></p>
        ///   <p>Comma separated list of test files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveTestFileInclusions<T>(this T toolSettings, IEnumerable<string> testFileInclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(testFileInclusions);
            toolSettings.TestFileInclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region CoverageExclusions
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.CoverageExclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetCoverageExclusions<T>(this T toolSettings, params string[] coverageExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageExclusionsInternal = coverageExclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.CoverageExclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetCoverageExclusions<T>(this T toolSettings, IEnumerable<string> coverageExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageExclusionsInternal = coverageExclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.CoverageExclusions"/></em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddCoverageExclusions<T>(this T toolSettings, params string[] coverageExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageExclusionsInternal.AddRange(coverageExclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.CoverageExclusions"/></em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddCoverageExclusions<T>(this T toolSettings, IEnumerable<string> coverageExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageExclusionsInternal.AddRange(coverageExclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.CoverageExclusions"/></em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearCoverageExclusions<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageExclusionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.CoverageExclusions"/></em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveCoverageExclusions<T>(this T toolSettings, params string[] coverageExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coverageExclusions);
            toolSettings.CoverageExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.CoverageExclusions"/></em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveCoverageExclusions<T>(this T toolSettings, IEnumerable<string> coverageExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coverageExclusions);
            toolSettings.CoverageExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenericCoveragePaths
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/> to a new list</em></p>
        ///   <p>Comma separated list of coverage reports in the <a href="https://docs.sonarqube.org/latest/analysis/generic-test/">Generic Test Data</a> format. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetGenericCoveragePaths<T>(this T toolSettings, params string[] genericCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenericCoveragePathsInternal = genericCoveragePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/> to a new list</em></p>
        ///   <p>Comma separated list of coverage reports in the <a href="https://docs.sonarqube.org/latest/analysis/generic-test/">Generic Test Data</a> format. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetGenericCoveragePaths<T>(this T toolSettings, IEnumerable<string> genericCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenericCoveragePathsInternal = genericCoveragePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></em></p>
        ///   <p>Comma separated list of coverage reports in the <a href="https://docs.sonarqube.org/latest/analysis/generic-test/">Generic Test Data</a> format. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddGenericCoveragePaths<T>(this T toolSettings, params string[] genericCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenericCoveragePathsInternal.AddRange(genericCoveragePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></em></p>
        ///   <p>Comma separated list of coverage reports in the <a href="https://docs.sonarqube.org/latest/analysis/generic-test/">Generic Test Data</a> format. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddGenericCoveragePaths<T>(this T toolSettings, IEnumerable<string> genericCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenericCoveragePathsInternal.AddRange(genericCoveragePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></em></p>
        ///   <p>Comma separated list of coverage reports in the <a href="https://docs.sonarqube.org/latest/analysis/generic-test/">Generic Test Data</a> format. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearGenericCoveragePaths<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenericCoveragePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></em></p>
        ///   <p>Comma separated list of coverage reports in the <a href="https://docs.sonarqube.org/latest/analysis/generic-test/">Generic Test Data</a> format. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveGenericCoveragePaths<T>(this T toolSettings, params string[] genericCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(genericCoveragePaths);
            toolSettings.GenericCoveragePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></em></p>
        ///   <p>Comma separated list of coverage reports in the <a href="https://docs.sonarqube.org/latest/analysis/generic-test/">Generic Test Data</a> format. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveGenericCoveragePaths<T>(this T toolSettings, IEnumerable<string> genericCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(genericCoveragePaths);
            toolSettings.GenericCoveragePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region VisualStudioCoveragePaths
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/> to a new list</em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetVisualStudioCoveragePaths<T>(this T toolSettings, params string[] visualStudioCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VisualStudioCoveragePathsInternal = visualStudioCoveragePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/> to a new list</em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetVisualStudioCoveragePaths<T>(this T toolSettings, IEnumerable<string> visualStudioCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VisualStudioCoveragePathsInternal = visualStudioCoveragePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddVisualStudioCoveragePaths<T>(this T toolSettings, params string[] visualStudioCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VisualStudioCoveragePathsInternal.AddRange(visualStudioCoveragePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddVisualStudioCoveragePaths<T>(this T toolSettings, IEnumerable<string> visualStudioCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VisualStudioCoveragePathsInternal.AddRange(visualStudioCoveragePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearVisualStudioCoveragePaths<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VisualStudioCoveragePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveVisualStudioCoveragePaths<T>(this T toolSettings, params string[] visualStudioCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(visualStudioCoveragePaths);
            toolSettings.VisualStudioCoveragePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveVisualStudioCoveragePaths<T>(this T toolSettings, IEnumerable<string> visualStudioCoveragePaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(visualStudioCoveragePaths);
            toolSettings.VisualStudioCoveragePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DotCoverPaths
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.DotCoverPaths"/> to a new list</em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetDotCoverPaths<T>(this T toolSettings, params string[] dotCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotCoverPathsInternal = dotCoverPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.DotCoverPaths"/> to a new list</em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetDotCoverPaths<T>(this T toolSettings, IEnumerable<string> dotCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotCoverPathsInternal = dotCoverPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.DotCoverPaths"/></em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddDotCoverPaths<T>(this T toolSettings, params string[] dotCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotCoverPathsInternal.AddRange(dotCoverPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.DotCoverPaths"/></em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddDotCoverPaths<T>(this T toolSettings, IEnumerable<string> dotCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotCoverPathsInternal.AddRange(dotCoverPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.DotCoverPaths"/></em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearDotCoverPaths<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotCoverPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.DotCoverPaths"/></em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveDotCoverPaths<T>(this T toolSettings, params string[] dotCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(dotCoverPaths);
            toolSettings.DotCoverPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.DotCoverPaths"/></em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveDotCoverPaths<T>(this T toolSettings, IEnumerable<string> dotCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(dotCoverPaths);
            toolSettings.DotCoverPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region OpenCoverPaths
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.OpenCoverPaths"/> to a new list</em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetOpenCoverPaths<T>(this T toolSettings, params string[] openCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCoverPathsInternal = openCoverPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.OpenCoverPaths"/> to a new list</em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T SetOpenCoverPaths<T>(this T toolSettings, IEnumerable<string> openCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCoverPathsInternal = openCoverPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddOpenCoverPaths<T>(this T toolSettings, params string[] openCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCoverPathsInternal.AddRange(openCoverPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T AddOpenCoverPaths<T>(this T toolSettings, IEnumerable<string> openCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCoverPathsInternal.AddRange(openCoverPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearOpenCoverPaths<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCoverPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveOpenCoverPaths<T>(this T toolSettings, params string[] openCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(openCoverPaths);
            toolSettings.OpenCoverPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveOpenCoverPaths<T>(this T toolSettings, IEnumerable<string> openCoverPaths) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(openCoverPaths);
            toolSettings.OpenCoverPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WebServiceTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.WebServiceTimeout"/></em></p>
        ///   <p>Maximum time to wait for the response of a Web Service call (in seconds). Modifying this value from the default is useful only when you're experiencing timeouts during analysis while waiting for the server to respond to Web Service calls.</p>
        /// </summary>
        [Pure]
        public static T SetWebServiceTimeout<T>(this T toolSettings, int? webServiceTimeout) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WebServiceTimeout = webServiceTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.WebServiceTimeout"/></em></p>
        ///   <p>Maximum time to wait for the response of a Web Service call (in seconds). Modifying this value from the default is useful only when you're experiencing timeouts during analysis while waiting for the server to respond to Web Service calls.</p>
        /// </summary>
        [Pure]
        public static T ResetWebServiceTimeout<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WebServiceTimeout = null;
            return toolSettings;
        }
        #endregion
        #region Homepage
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Homepage"/></em></p>
        ///   <p>Project home page.</p>
        /// </summary>
        [Pure]
        public static T SetHomepage<T>(this T toolSettings, string homepage) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Homepage = homepage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Homepage"/></em></p>
        ///   <p>Project home page.</p>
        /// </summary>
        [Pure]
        public static T ResetHomepage<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Homepage = null;
            return toolSettings;
        }
        #endregion
        #region ContinuousIntegrationUrl
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/></em></p>
        ///   <p>Link to Continuous integration</p>
        /// </summary>
        [Pure]
        public static T SetContinuousIntegrationUrl<T>(this T toolSettings, string continuousIntegrationUrl) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContinuousIntegrationUrl = continuousIntegrationUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/></em></p>
        ///   <p>Link to Continuous integration</p>
        /// </summary>
        [Pure]
        public static T ResetContinuousIntegrationUrl<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContinuousIntegrationUrl = null;
            return toolSettings;
        }
        #endregion
        #region IssueTrackerUrl
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.IssueTrackerUrl"/></em></p>
        ///   <p>Link to Issue tracker.</p>
        /// </summary>
        [Pure]
        public static T SetIssueTrackerUrl<T>(this T toolSettings, string issueTrackerUrl) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IssueTrackerUrl = issueTrackerUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.IssueTrackerUrl"/></em></p>
        ///   <p>Link to Issue tracker.</p>
        /// </summary>
        [Pure]
        public static T ResetIssueTrackerUrl<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IssueTrackerUrl = null;
            return toolSettings;
        }
        #endregion
        #region SCMUrl
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.SCMUrl"/></em></p>
        ///   <p>Link to project source repository</p>
        /// </summary>
        [Pure]
        public static T SetSCMUrl<T>(this T toolSettings, string scmurl) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SCMUrl = scmurl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.SCMUrl"/></em></p>
        ///   <p>Link to project source repository</p>
        /// </summary>
        [Pure]
        public static T ResetSCMUrl<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SCMUrl = null;
            return toolSettings;
        }
        #endregion
        #region SourceEncoding
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.SourceEncoding"/></em></p>
        ///   <p>Encoding of the source files. Ex: <c>UTF-8</c> , <c>MacRoman</c> , <c>Shift_JIS</c>. This property can be replaced by the standard property <c>project.build.sourceEncoding</c> in Maven projects. The list of available encodings depends on your JVM.</p>
        /// </summary>
        [Pure]
        public static T SetSourceEncoding<T>(this T toolSettings, string sourceEncoding) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceEncoding = sourceEncoding;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.SourceEncoding"/></em></p>
        ///   <p>Encoding of the source files. Ex: <c>UTF-8</c> , <c>MacRoman</c> , <c>Shift_JIS</c>. This property can be replaced by the standard property <c>project.build.sourceEncoding</c> in Maven projects. The list of available encodings depends on your JVM.</p>
        /// </summary>
        [Pure]
        public static T ResetSourceEncoding<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceEncoding = null;
            return toolSettings;
        }
        #endregion
        #region DuplicationExclusions
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.DuplicationExclusions"/> to a new list</em></p>
        ///   <p>Comma-delimited list of file path patterns to be excluded from duplication detection.</p>
        /// </summary>
        [Pure]
        public static T SetDuplicationExclusions<T>(this T toolSettings, params string[] duplicationExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DuplicationExclusionsInternal = duplicationExclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.DuplicationExclusions"/> to a new list</em></p>
        ///   <p>Comma-delimited list of file path patterns to be excluded from duplication detection.</p>
        /// </summary>
        [Pure]
        public static T SetDuplicationExclusions<T>(this T toolSettings, IEnumerable<string> duplicationExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DuplicationExclusionsInternal = duplicationExclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></em></p>
        ///   <p>Comma-delimited list of file path patterns to be excluded from duplication detection.</p>
        /// </summary>
        [Pure]
        public static T AddDuplicationExclusions<T>(this T toolSettings, params string[] duplicationExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DuplicationExclusionsInternal.AddRange(duplicationExclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></em></p>
        ///   <p>Comma-delimited list of file path patterns to be excluded from duplication detection.</p>
        /// </summary>
        [Pure]
        public static T AddDuplicationExclusions<T>(this T toolSettings, IEnumerable<string> duplicationExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DuplicationExclusionsInternal.AddRange(duplicationExclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></em></p>
        ///   <p>Comma-delimited list of file path patterns to be excluded from duplication detection.</p>
        /// </summary>
        [Pure]
        public static T ClearDuplicationExclusions<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DuplicationExclusionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></em></p>
        ///   <p>Comma-delimited list of file path patterns to be excluded from duplication detection.</p>
        /// </summary>
        [Pure]
        public static T RemoveDuplicationExclusions<T>(this T toolSettings, params string[] duplicationExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(duplicationExclusions);
            toolSettings.DuplicationExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></em></p>
        ///   <p>Comma-delimited list of file path patterns to be excluded from duplication detection.</p>
        /// </summary>
        [Pure]
        public static T RemoveDuplicationExclusions<T>(this T toolSettings, IEnumerable<string> duplicationExclusions) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(duplicationExclusions);
            toolSettings.DuplicationExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region BranchName
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.BranchName"/></em></p>
        ///   <p>Name of the branch (visible in the UI)</p>
        /// </summary>
        [Pure]
        public static T SetBranchName<T>(this T toolSettings, string branchName) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BranchName = branchName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.BranchName"/></em></p>
        ///   <p>Name of the branch (visible in the UI)</p>
        /// </summary>
        [Pure]
        public static T ResetBranchName<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BranchName = null;
            return toolSettings;
        }
        #endregion
        #region PullRequestKey
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.PullRequestKey"/></em></p>
        ///   <p>Unique identifier of your Pull Request. Must correspond to the key of the Pull Request in your ALM. e.g.: <c>sonar.pullrequest.key=5</c></p>
        /// </summary>
        [Pure]
        public static T SetPullRequestKey<T>(this T toolSettings, string pullRequestKey) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequestKey = pullRequestKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.PullRequestKey"/></em></p>
        ///   <p>Unique identifier of your Pull Request. Must correspond to the key of the Pull Request in your ALM. e.g.: <c>sonar.pullrequest.key=5</c></p>
        /// </summary>
        [Pure]
        public static T ResetPullRequestKey<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequestKey = null;
            return toolSettings;
        }
        #endregion
        #region PullRequestBranch
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.PullRequestBranch"/></em></p>
        ///   <p>The name of the branch that contains the changes to be merged. e.g.: <c>sonar.pullrequest.branch=feature/my-new-feature</c></p>
        /// </summary>
        [Pure]
        public static T SetPullRequestBranch<T>(this T toolSettings, string pullRequestBranch) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequestBranch = pullRequestBranch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.PullRequestBranch"/></em></p>
        ///   <p>The name of the branch that contains the changes to be merged. e.g.: <c>sonar.pullrequest.branch=feature/my-new-feature</c></p>
        /// </summary>
        [Pure]
        public static T ResetPullRequestBranch<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequestBranch = null;
            return toolSettings;
        }
        #endregion
        #region PullRequestBase
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.PullRequestBase"/></em></p>
        ///   <p>The branch into which the Pull Request will be merged. Default: <c>master</c>. e.g.: <c>sonar.pullrequest.base=master</c></p>
        /// </summary>
        [Pure]
        public static T SetPullRequestBase<T>(this T toolSettings, string pullRequestBase) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequestBase = pullRequestBase;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.PullRequestBase"/></em></p>
        ///   <p>The branch into which the Pull Request will be merged. Default: <c>master</c>. e.g.: <c>sonar.pullrequest.base=master</c></p>
        /// </summary>
        [Pure]
        public static T ResetPullRequestBase<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequestBase = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : SonarScannerBeginSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SonarScannerEndSettingsExtensions
    /// <summary>
    ///   Used within <see cref="SonarScannerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SonarScannerEndSettingsExtensions
    {
        #region Login
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerEndSettings.Login"/></em></p>
        ///   <p>Specifies the username or access token to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static T SetLogin<T>(this T toolSettings, string login) where T : SonarScannerEndSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Login = login;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerEndSettings.Login"/></em></p>
        ///   <p>Specifies the username or access token to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static T ResetLogin<T>(this T toolSettings) where T : SonarScannerEndSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Login = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerEndSettings.Password"/></em></p>
        ///   <p>Specifies the password for the SonarQube username in the <c>sonar.login</c> argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : SonarScannerEndSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerEndSettings.Password"/></em></p>
        ///   <p>Specifies the password for the SonarQube username in the <c>sonar.login</c> argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : SonarScannerEndSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerEndSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : SonarScannerEndSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerEndSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : SonarScannerEndSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
