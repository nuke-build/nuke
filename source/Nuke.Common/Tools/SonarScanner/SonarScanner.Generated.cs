// Generated from https://github.com/nuke-build/common/blob/master/build/specifications/SonarScanner.json
// Generated with Nuke.CodeGeneration version LOCAL (OSX,.NETStandard,Version=v2.0)

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
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SonarScannerTasks
    {
        /// <summary>
        ///   Path to the SonarScanner executable.
        /// </summary>
        public static string SonarScannerPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("SONARSCANNER_EXE") ??
            ToolPathResolver.GetPackageExecutable("MSBuild.SonarQube.Runner.Tool", "SonarScanner.MSBuild.exe");
        public static Action<OutputType, string> SonarScannerLogger { get; set; } = ProcessManager.DefaultLogger;
        /// <summary>
        ///   The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.
        /// </summary>
        public static IReadOnlyCollection<Output> SonarScanner(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(SonarScannerPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, SonarScannerLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p>
        ///   <p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> SonarScannerBegin(SonarScannerBeginSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new SonarScannerBeginSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
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
        ///     <li><c>/d:sonar.coverage.exclusions</c> via <see cref="SonarScannerBeginSettings.CoverageExclusions"/></li>
        ///     <li><c>/d:sonar.cpd.exclusions</c> via <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></li>
        ///     <li><c>/d:sonar.cs.dotcover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.DotCoverPaths"/></li>
        ///     <li><c>/d:sonar.cs.nunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.NUnitTestReports"/></li>
        ///     <li><c>/d:sonar.cs.opencover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></li>
        ///     <li><c>/d:sonar.cs.vscoveragexml.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></li>
        ///     <li><c>/d:sonar.cs.vstest.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VSTestReports"/></li>
        ///     <li><c>/d:sonar.cs.xunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.XUnitTestReports"/></li>
        ///     <li><c>/d:sonar.host.url</c> via <see cref="SonarScannerBeginSettings.Server"/></li>
        ///     <li><c>/d:sonar.links.ci</c> via <see cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/></li>
        ///     <li><c>/d:sonar.links.homepage</c> via <see cref="SonarScannerBeginSettings.Homepage"/></li>
        ///     <li><c>/d:sonar.links.issue</c> via <see cref="SonarScannerBeginSettings.IssueTrackerUrl"/></li>
        ///     <li><c>/d:sonar.links.scm</c> via <see cref="SonarScannerBeginSettings.SCMUrl"/></li>
        ///     <li><c>/d:sonar.login</c> via <see cref="SonarScannerBeginSettings.Login"/></li>
        ///     <li><c>/d:sonar.password</c> via <see cref="SonarScannerBeginSettings.Password"/></li>
        ///     <li><c>/d:sonar.projectDescription</c> via <see cref="SonarScannerBeginSettings.Description"/></li>
        ///     <li><c>/d:sonar.sourceEncoding</c> via <see cref="SonarScannerBeginSettings.SourceEncoding"/></li>
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
        ///     <li><c>/d:sonar.coverage.exclusions</c> via <see cref="SonarScannerBeginSettings.CoverageExclusions"/></li>
        ///     <li><c>/d:sonar.cpd.exclusions</c> via <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></li>
        ///     <li><c>/d:sonar.cs.dotcover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.DotCoverPaths"/></li>
        ///     <li><c>/d:sonar.cs.nunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.NUnitTestReports"/></li>
        ///     <li><c>/d:sonar.cs.opencover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></li>
        ///     <li><c>/d:sonar.cs.vscoveragexml.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></li>
        ///     <li><c>/d:sonar.cs.vstest.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VSTestReports"/></li>
        ///     <li><c>/d:sonar.cs.xunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.XUnitTestReports"/></li>
        ///     <li><c>/d:sonar.host.url</c> via <see cref="SonarScannerBeginSettings.Server"/></li>
        ///     <li><c>/d:sonar.links.ci</c> via <see cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/></li>
        ///     <li><c>/d:sonar.links.homepage</c> via <see cref="SonarScannerBeginSettings.Homepage"/></li>
        ///     <li><c>/d:sonar.links.issue</c> via <see cref="SonarScannerBeginSettings.IssueTrackerUrl"/></li>
        ///     <li><c>/d:sonar.links.scm</c> via <see cref="SonarScannerBeginSettings.SCMUrl"/></li>
        ///     <li><c>/d:sonar.login</c> via <see cref="SonarScannerBeginSettings.Login"/></li>
        ///     <li><c>/d:sonar.password</c> via <see cref="SonarScannerBeginSettings.Password"/></li>
        ///     <li><c>/d:sonar.projectDescription</c> via <see cref="SonarScannerBeginSettings.Description"/></li>
        ///     <li><c>/d:sonar.sourceEncoding</c> via <see cref="SonarScannerBeginSettings.SourceEncoding"/></li>
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
        public static IReadOnlyCollection<Output> SonarScannerEnd(SonarScannerEndSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new SonarScannerEndSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
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
        public override string ToolPath => base.ToolPath ?? SonarScannerTasks.SonarScannerPath;
        public override Action<OutputType, string> CustomLogger => SonarScannerTasks.SonarScannerLogger;
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
        ///   The server URL. Default is http://localhost:9000
        /// </summary>
        public virtual string Server { get; internal set; }
        /// <summary>
        ///   Specifies the username or access token to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added on the end step.
        /// </summary>
        public virtual string Login { get; internal set; }
        /// <summary>
        ///   Specifies the password for the SonarQube username in the `sonar.login` argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.
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
        ///   Comma separated list of files to exclude from coverage calculations. Supports wildcards (*, **, ?).
        /// </summary>
        public virtual IReadOnlyList<string> CoverageExclusions => CoverageExclusionsInternal.AsReadOnly();
        internal List<string> CoverageExclusionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (*, **, ?).
        /// </summary>
        public virtual IReadOnlyList<string> VisualStudioCoveragePaths => VisualStudioCoveragePathsInternal.AsReadOnly();
        internal List<string> VisualStudioCoveragePathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of dotCover HTML-reports to include. Supports wildcards (*, **, ?).
        /// </summary>
        public virtual IReadOnlyList<string> DotCoverPaths => DotCoverPathsInternal.AsReadOnly();
        internal List<string> DotCoverPathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Comma separated list of OpenCover reports to include. Supports wildcards (*, **, ?).
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
        ///   Encoding of the source files. Ex: UTF-8 , MacRoman , Shift_JIS . This property can be replaced by the standard property project.build.sourceEncoding in Maven projects. The list of available encodings depends on your JVM.
        /// </summary>
        public virtual string SourceEncoding { get; internal set; }
        /// <summary>
        ///   Comma-delimited list of file path patterns to be excluded from duplication detection.
        /// </summary>
        public virtual IReadOnlyList<string> DuplicationExclusions => DuplicationExclusionsInternal.AsReadOnly();
        internal List<string> DuplicationExclusionsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
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
              .Add("/d:sonar.coverage.exclusions={value}", CoverageExclusions, separator: ',')
              .Add("/d:sonar.cs.vscoveragexml.reportsPaths={value}", VisualStudioCoveragePaths, separator: ',')
              .Add("/d:sonar.cs.dotcover.reportsPaths={value}", DotCoverPaths, separator: ',')
              .Add("/d:sonar.cs.opencover.reportsPaths={value}", OpenCoverPaths, separator: ',')
              .Add("/d:sonar.ws.timeout={value}", WebServiceTimeout)
              .Add("/d:sonar.links.homepage={value}", Homepage)
              .Add("/d:sonar.links.ci={value}", ContinuousIntegrationUrl)
              .Add("/d:sonar.links.issue={value}", IssueTrackerUrl)
              .Add("/d:sonar.links.scm={value}", SCMUrl)
              .Add("/d:sonar.sourceEncoding={value}", SourceEncoding)
              .Add("/d:sonar.cpd.exclusions={value}", DuplicationExclusions, separator: ',');
            return base.ConfigureArguments(arguments);
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
        public override string ToolPath => base.ToolPath ?? SonarScannerTasks.SonarScannerPath;
        public override Action<OutputType, string> CustomLogger => SonarScannerTasks.SonarScannerLogger;
        /// <summary>
        ///   Specifies the username or access token to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added on the end step.
        /// </summary>
        public virtual string Login { get; internal set; }
        /// <summary>
        ///   Specifies the password for the SonarQube username in the `sonar.login` argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.
        /// </summary>
        public virtual string Password { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("end")
              .Add("/d:sonar.login={value}", Login)
              .Add("/d:sonar.password={value}", Password, secret: true);
            return base.ConfigureArguments(arguments);
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
        public static SonarScannerBeginSettings SetProjectKey(this SonarScannerBeginSettings toolSettings, string projectKey)
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
        public static SonarScannerBeginSettings ResetProjectKey(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetName(this SonarScannerBeginSettings toolSettings, string name)
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
        public static SonarScannerBeginSettings ResetName(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetVersion(this SonarScannerBeginSettings toolSettings, string version)
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
        public static SonarScannerBeginSettings ResetVersion(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetDescription(this SonarScannerBeginSettings toolSettings, string description)
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
        public static SonarScannerBeginSettings ResetDescription(this SonarScannerBeginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region Server
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Server"/></em></p>
        ///   <p>The server URL. Default is http://localhost:9000</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetServer(this SonarScannerBeginSettings toolSettings, string server)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = server;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Server"/></em></p>
        ///   <p>The server URL. Default is http://localhost:9000</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings ResetServer(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetLogin(this SonarScannerBeginSettings toolSettings, string login)
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
        public static SonarScannerBeginSettings ResetLogin(this SonarScannerBeginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Login = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.Password"/></em></p>
        ///   <p>Specifies the password for the SonarQube username in the `sonar.login` argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetPassword(this SonarScannerBeginSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.Password"/></em></p>
        ///   <p>Specifies the password for the SonarQube username in the `sonar.login` argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings ResetPassword(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetVerbose(this SonarScannerBeginSettings toolSettings, bool? verbose)
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
        public static SonarScannerBeginSettings ResetVerbose(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings EnableVerbose(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings DisableVerbose(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings ToggleVerbose(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetVSTestReports(this SonarScannerBeginSettings toolSettings, params string[] vstestReports)
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
        public static SonarScannerBeginSettings SetVSTestReports(this SonarScannerBeginSettings toolSettings, IEnumerable<string> vstestReports)
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
        public static SonarScannerBeginSettings AddVSTestReports(this SonarScannerBeginSettings toolSettings, params string[] vstestReports)
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
        public static SonarScannerBeginSettings AddVSTestReports(this SonarScannerBeginSettings toolSettings, IEnumerable<string> vstestReports)
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
        public static SonarScannerBeginSettings ClearVSTestReports(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings RemoveVSTestReports(this SonarScannerBeginSettings toolSettings, params string[] vstestReports)
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
        public static SonarScannerBeginSettings RemoveVSTestReports(this SonarScannerBeginSettings toolSettings, IEnumerable<string> vstestReports)
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
        public static SonarScannerBeginSettings SetNUnitTestReports(this SonarScannerBeginSettings toolSettings, params string[] nunitTestReports)
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
        public static SonarScannerBeginSettings SetNUnitTestReports(this SonarScannerBeginSettings toolSettings, IEnumerable<string> nunitTestReports)
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
        public static SonarScannerBeginSettings AddNUnitTestReports(this SonarScannerBeginSettings toolSettings, params string[] nunitTestReports)
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
        public static SonarScannerBeginSettings AddNUnitTestReports(this SonarScannerBeginSettings toolSettings, IEnumerable<string> nunitTestReports)
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
        public static SonarScannerBeginSettings ClearNUnitTestReports(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings RemoveNUnitTestReports(this SonarScannerBeginSettings toolSettings, params string[] nunitTestReports)
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
        public static SonarScannerBeginSettings RemoveNUnitTestReports(this SonarScannerBeginSettings toolSettings, IEnumerable<string> nunitTestReports)
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
        public static SonarScannerBeginSettings SetXUnitTestReports(this SonarScannerBeginSettings toolSettings, params string[] xunitTestReports)
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
        public static SonarScannerBeginSettings SetXUnitTestReports(this SonarScannerBeginSettings toolSettings, IEnumerable<string> xunitTestReports)
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
        public static SonarScannerBeginSettings AddXUnitTestReports(this SonarScannerBeginSettings toolSettings, params string[] xunitTestReports)
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
        public static SonarScannerBeginSettings AddXUnitTestReports(this SonarScannerBeginSettings toolSettings, IEnumerable<string> xunitTestReports)
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
        public static SonarScannerBeginSettings ClearXUnitTestReports(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings RemoveXUnitTestReports(this SonarScannerBeginSettings toolSettings, params string[] xunitTestReports)
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
        public static SonarScannerBeginSettings RemoveXUnitTestReports(this SonarScannerBeginSettings toolSettings, IEnumerable<string> xunitTestReports)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(xunitTestReports);
            toolSettings.XUnitTestReportsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region CoverageExclusions
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.CoverageExclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetCoverageExclusions(this SonarScannerBeginSettings toolSettings, params string[] coverageExclusions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageExclusionsInternal = coverageExclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.CoverageExclusions"/> to a new list</em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetCoverageExclusions(this SonarScannerBeginSettings toolSettings, IEnumerable<string> coverageExclusions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageExclusionsInternal = coverageExclusions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.CoverageExclusions"/></em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings AddCoverageExclusions(this SonarScannerBeginSettings toolSettings, params string[] coverageExclusions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageExclusionsInternal.AddRange(coverageExclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.CoverageExclusions"/></em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings AddCoverageExclusions(this SonarScannerBeginSettings toolSettings, IEnumerable<string> coverageExclusions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageExclusionsInternal.AddRange(coverageExclusions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.CoverageExclusions"/></em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings ClearCoverageExclusions(this SonarScannerBeginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CoverageExclusionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.CoverageExclusions"/></em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings RemoveCoverageExclusions(this SonarScannerBeginSettings toolSettings, params string[] coverageExclusions)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coverageExclusions);
            toolSettings.CoverageExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.CoverageExclusions"/></em></p>
        ///   <p>Comma separated list of files to exclude from coverage calculations. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings RemoveCoverageExclusions(this SonarScannerBeginSettings toolSettings, IEnumerable<string> coverageExclusions)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(coverageExclusions);
            toolSettings.CoverageExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region VisualStudioCoveragePaths
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/> to a new list</em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetVisualStudioCoveragePaths(this SonarScannerBeginSettings toolSettings, params string[] visualStudioCoveragePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VisualStudioCoveragePathsInternal = visualStudioCoveragePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/> to a new list</em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetVisualStudioCoveragePaths(this SonarScannerBeginSettings toolSettings, IEnumerable<string> visualStudioCoveragePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VisualStudioCoveragePathsInternal = visualStudioCoveragePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings AddVisualStudioCoveragePaths(this SonarScannerBeginSettings toolSettings, params string[] visualStudioCoveragePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VisualStudioCoveragePathsInternal.AddRange(visualStudioCoveragePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings AddVisualStudioCoveragePaths(this SonarScannerBeginSettings toolSettings, IEnumerable<string> visualStudioCoveragePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VisualStudioCoveragePathsInternal.AddRange(visualStudioCoveragePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings ClearVisualStudioCoveragePaths(this SonarScannerBeginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VisualStudioCoveragePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings RemoveVisualStudioCoveragePaths(this SonarScannerBeginSettings toolSettings, params string[] visualStudioCoveragePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(visualStudioCoveragePaths);
            toolSettings.VisualStudioCoveragePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></em></p>
        ///   <p>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings RemoveVisualStudioCoveragePaths(this SonarScannerBeginSettings toolSettings, IEnumerable<string> visualStudioCoveragePaths)
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
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetDotCoverPaths(this SonarScannerBeginSettings toolSettings, params string[] dotCoverPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotCoverPathsInternal = dotCoverPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.DotCoverPaths"/> to a new list</em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetDotCoverPaths(this SonarScannerBeginSettings toolSettings, IEnumerable<string> dotCoverPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotCoverPathsInternal = dotCoverPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.DotCoverPaths"/></em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings AddDotCoverPaths(this SonarScannerBeginSettings toolSettings, params string[] dotCoverPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotCoverPathsInternal.AddRange(dotCoverPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.DotCoverPaths"/></em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings AddDotCoverPaths(this SonarScannerBeginSettings toolSettings, IEnumerable<string> dotCoverPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotCoverPathsInternal.AddRange(dotCoverPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.DotCoverPaths"/></em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings ClearDotCoverPaths(this SonarScannerBeginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotCoverPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.DotCoverPaths"/></em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings RemoveDotCoverPaths(this SonarScannerBeginSettings toolSettings, params string[] dotCoverPaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(dotCoverPaths);
            toolSettings.DotCoverPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.DotCoverPaths"/></em></p>
        ///   <p>Comma separated list of dotCover HTML-reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings RemoveDotCoverPaths(this SonarScannerBeginSettings toolSettings, IEnumerable<string> dotCoverPaths)
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
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetOpenCoverPaths(this SonarScannerBeginSettings toolSettings, params string[] openCoverPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCoverPathsInternal = openCoverPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.OpenCoverPaths"/> to a new list</em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetOpenCoverPaths(this SonarScannerBeginSettings toolSettings, IEnumerable<string> openCoverPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCoverPathsInternal = openCoverPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings AddOpenCoverPaths(this SonarScannerBeginSettings toolSettings, params string[] openCoverPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCoverPathsInternal.AddRange(openCoverPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings AddOpenCoverPaths(this SonarScannerBeginSettings toolSettings, IEnumerable<string> openCoverPaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCoverPathsInternal.AddRange(openCoverPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings ClearOpenCoverPaths(this SonarScannerBeginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OpenCoverPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings RemoveOpenCoverPaths(this SonarScannerBeginSettings toolSettings, params string[] openCoverPaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(openCoverPaths);
            toolSettings.OpenCoverPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></em></p>
        ///   <p>Comma separated list of OpenCover reports to include. Supports wildcards (*, **, ?).</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings RemoveOpenCoverPaths(this SonarScannerBeginSettings toolSettings, IEnumerable<string> openCoverPaths)
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
        public static SonarScannerBeginSettings SetWebServiceTimeout(this SonarScannerBeginSettings toolSettings, int? webServiceTimeout)
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
        public static SonarScannerBeginSettings ResetWebServiceTimeout(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetHomepage(this SonarScannerBeginSettings toolSettings, string homepage)
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
        public static SonarScannerBeginSettings ResetHomepage(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetContinuousIntegrationUrl(this SonarScannerBeginSettings toolSettings, string continuousIntegrationUrl)
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
        public static SonarScannerBeginSettings ResetContinuousIntegrationUrl(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetIssueTrackerUrl(this SonarScannerBeginSettings toolSettings, string issueTrackerUrl)
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
        public static SonarScannerBeginSettings ResetIssueTrackerUrl(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetSCMUrl(this SonarScannerBeginSettings toolSettings, string scmurl)
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
        public static SonarScannerBeginSettings ResetSCMUrl(this SonarScannerBeginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SCMUrl = null;
            return toolSettings;
        }
        #endregion
        #region SourceEncoding
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerBeginSettings.SourceEncoding"/></em></p>
        ///   <p>Encoding of the source files. Ex: UTF-8 , MacRoman , Shift_JIS . This property can be replaced by the standard property project.build.sourceEncoding in Maven projects. The list of available encodings depends on your JVM.</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings SetSourceEncoding(this SonarScannerBeginSettings toolSettings, string sourceEncoding)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceEncoding = sourceEncoding;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerBeginSettings.SourceEncoding"/></em></p>
        ///   <p>Encoding of the source files. Ex: UTF-8 , MacRoman , Shift_JIS . This property can be replaced by the standard property project.build.sourceEncoding in Maven projects. The list of available encodings depends on your JVM.</p>
        /// </summary>
        [Pure]
        public static SonarScannerBeginSettings ResetSourceEncoding(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings SetDuplicationExclusions(this SonarScannerBeginSettings toolSettings, params string[] duplicationExclusions)
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
        public static SonarScannerBeginSettings SetDuplicationExclusions(this SonarScannerBeginSettings toolSettings, IEnumerable<string> duplicationExclusions)
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
        public static SonarScannerBeginSettings AddDuplicationExclusions(this SonarScannerBeginSettings toolSettings, params string[] duplicationExclusions)
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
        public static SonarScannerBeginSettings AddDuplicationExclusions(this SonarScannerBeginSettings toolSettings, IEnumerable<string> duplicationExclusions)
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
        public static SonarScannerBeginSettings ClearDuplicationExclusions(this SonarScannerBeginSettings toolSettings)
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
        public static SonarScannerBeginSettings RemoveDuplicationExclusions(this SonarScannerBeginSettings toolSettings, params string[] duplicationExclusions)
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
        public static SonarScannerBeginSettings RemoveDuplicationExclusions(this SonarScannerBeginSettings toolSettings, IEnumerable<string> duplicationExclusions)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(duplicationExclusions);
            toolSettings.DuplicationExclusionsInternal.RemoveAll(x => hashSet.Contains(x));
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
        public static SonarScannerEndSettings SetLogin(this SonarScannerEndSettings toolSettings, string login)
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
        public static SonarScannerEndSettings ResetLogin(this SonarScannerEndSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Login = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="SonarScannerEndSettings.Password"/></em></p>
        ///   <p>Specifies the password for the SonarQube username in the `sonar.login` argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static SonarScannerEndSettings SetPassword(this SonarScannerEndSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SonarScannerEndSettings.Password"/></em></p>
        ///   <p>Specifies the password for the SonarQube username in the `sonar.login` argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.</p>
        /// </summary>
        [Pure]
        public static SonarScannerEndSettings ResetPassword(this SonarScannerEndSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
