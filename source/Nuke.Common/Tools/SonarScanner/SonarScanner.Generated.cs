// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/SonarScanner/SonarScanner.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
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

namespace Nuke.Common.Tools.SonarScanner;

/// <summary><p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p><p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class SonarScannerTasks : ToolTasks, IRequireNuGetPackage
{
    public static string SonarScannerPath => new SonarScannerTasks().GetToolPath();
    public const string PackageId = "dotnet-sonarscanner";
    public const string PackageExecutable = "SonarScanner.MSBuild.dll|SonarScanner.MSBuild.exe";
    /// <summary><p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p><p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> SonarScanner(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new SonarScannerTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p><p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/d</c> via <see cref="SonarScannerBeginSettings.AdditionalParameters"/></li><li><c>/d:sonar.analysis.</c> via <see cref="SonarScannerBeginSettings.AdditionalAnalysisParameters"/></li><li><c>/d:sonar.branch.name</c> via <see cref="SonarScannerBeginSettings.BranchName"/></li><li><c>/d:sonar.clientcert.password</c> via <see cref="SonarScannerBeginSettings.ClientCertificatePassword"/></li><li><c>/d:sonar.clientcert.path</c> via <see cref="SonarScannerBeginSettings.ClientCertificatePath"/></li><li><c>/d:sonar.coverage.exclusions</c> via <see cref="SonarScannerBeginSettings.CoverageExclusions"/></li><li><c>/d:sonar.coverageReportPaths</c> via <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></li><li><c>/d:sonar.cpd.exclusions</c> via <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></li><li><c>/d:sonar.cs.dotcover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.DotCoverPaths"/></li><li><c>/d:sonar.cs.nunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.NUnitTestReports"/></li><li><c>/d:sonar.cs.opencover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></li><li><c>/d:sonar.cs.vscoveragexml.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></li><li><c>/d:sonar.cs.vstest.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VSTestReports"/></li><li><c>/d:sonar.cs.xunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.XUnitTestReports"/></li><li><c>/d:sonar.dotnet.excludeTestProjects</c> via <see cref="SonarScannerBeginSettings.ExcludeTestProjects"/></li><li><c>/d:sonar.exclusions</c> via <see cref="SonarScannerBeginSettings.SourceExclusions"/></li><li><c>/d:sonar.host.url</c> via <see cref="SonarScannerBeginSettings.Server"/></li><li><c>/d:sonar.inclusions</c> via <see cref="SonarScannerBeginSettings.SourceInclusions"/></li><li><c>/d:sonar.links.ci</c> via <see cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/></li><li><c>/d:sonar.links.homepage</c> via <see cref="SonarScannerBeginSettings.Homepage"/></li><li><c>/d:sonar.links.issue</c> via <see cref="SonarScannerBeginSettings.IssueTrackerUrl"/></li><li><c>/d:sonar.links.scm</c> via <see cref="SonarScannerBeginSettings.SCMUrl"/></li><li><c>/d:sonar.login</c> via <see cref="SonarScannerBeginSettings.Login"/></li><li><c>/d:sonar.password</c> via <see cref="SonarScannerBeginSettings.Password"/></li><li><c>/d:sonar.projectDescription</c> via <see cref="SonarScannerBeginSettings.Description"/></li><li><c>/d:sonar.pullrequest.base</c> via <see cref="SonarScannerBeginSettings.PullRequestBase"/></li><li><c>/d:sonar.pullrequest.branch</c> via <see cref="SonarScannerBeginSettings.PullRequestBranch"/></li><li><c>/d:sonar.pullrequest.key</c> via <see cref="SonarScannerBeginSettings.PullRequestKey"/></li><li><c>/d:sonar.qualitygate.timeout</c> via <see cref="SonarScannerBeginSettings.QualityGateTimeout"/></li><li><c>/d:sonar.qualitygate.wait</c> via <see cref="SonarScannerBeginSettings.QualityGateWait"/></li><li><c>/d:sonar.scm.exclusions.disabled</c> via <see cref="SonarScannerBeginSettings.ScmExclusionsDisabled"/></li><li><c>/d:sonar.scm.forceReloadAll</c> via <see cref="SonarScannerBeginSettings.ScmForceReloadAll"/></li><li><c>/d:sonar.scm.provider</c> via <see cref="SonarScannerBeginSettings.ScmProvider"/></li><li><c>/d:sonar.scm.revision</c> via <see cref="SonarScannerBeginSettings.ScmRevision"/></li><li><c>/d:sonar.sourceEncoding</c> via <see cref="SonarScannerBeginSettings.SourceEncoding"/></li><li><c>/d:sonar.test.exclusions</c> via <see cref="SonarScannerBeginSettings.TestFileExclusions"/></li><li><c>/d:sonar.test.inclusions</c> via <see cref="SonarScannerBeginSettings.TestFileInclusions"/></li><li><c>/d:sonar.token</c> via <see cref="SonarScannerBeginSettings.Token"/></li><li><c>/d:sonar.verbose</c> via <see cref="SonarScannerBeginSettings.Verbose"/></li><li><c>/d:sonar.ws.timeout</c> via <see cref="SonarScannerBeginSettings.WebServiceTimeout"/></li><li><c>/k</c> via <see cref="SonarScannerBeginSettings.ProjectKey"/></li><li><c>/n</c> via <see cref="SonarScannerBeginSettings.Name"/></li><li><c>/o</c> via <see cref="SonarScannerBeginSettings.Organization"/></li><li><c>/v</c> via <see cref="SonarScannerBeginSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SonarScannerBegin(SonarScannerBeginSettings options = null) => new SonarScannerTasks().Run(options);
    /// <summary><p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p><p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/d</c> via <see cref="SonarScannerBeginSettings.AdditionalParameters"/></li><li><c>/d:sonar.analysis.</c> via <see cref="SonarScannerBeginSettings.AdditionalAnalysisParameters"/></li><li><c>/d:sonar.branch.name</c> via <see cref="SonarScannerBeginSettings.BranchName"/></li><li><c>/d:sonar.clientcert.password</c> via <see cref="SonarScannerBeginSettings.ClientCertificatePassword"/></li><li><c>/d:sonar.clientcert.path</c> via <see cref="SonarScannerBeginSettings.ClientCertificatePath"/></li><li><c>/d:sonar.coverage.exclusions</c> via <see cref="SonarScannerBeginSettings.CoverageExclusions"/></li><li><c>/d:sonar.coverageReportPaths</c> via <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></li><li><c>/d:sonar.cpd.exclusions</c> via <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></li><li><c>/d:sonar.cs.dotcover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.DotCoverPaths"/></li><li><c>/d:sonar.cs.nunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.NUnitTestReports"/></li><li><c>/d:sonar.cs.opencover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></li><li><c>/d:sonar.cs.vscoveragexml.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></li><li><c>/d:sonar.cs.vstest.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VSTestReports"/></li><li><c>/d:sonar.cs.xunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.XUnitTestReports"/></li><li><c>/d:sonar.dotnet.excludeTestProjects</c> via <see cref="SonarScannerBeginSettings.ExcludeTestProjects"/></li><li><c>/d:sonar.exclusions</c> via <see cref="SonarScannerBeginSettings.SourceExclusions"/></li><li><c>/d:sonar.host.url</c> via <see cref="SonarScannerBeginSettings.Server"/></li><li><c>/d:sonar.inclusions</c> via <see cref="SonarScannerBeginSettings.SourceInclusions"/></li><li><c>/d:sonar.links.ci</c> via <see cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/></li><li><c>/d:sonar.links.homepage</c> via <see cref="SonarScannerBeginSettings.Homepage"/></li><li><c>/d:sonar.links.issue</c> via <see cref="SonarScannerBeginSettings.IssueTrackerUrl"/></li><li><c>/d:sonar.links.scm</c> via <see cref="SonarScannerBeginSettings.SCMUrl"/></li><li><c>/d:sonar.login</c> via <see cref="SonarScannerBeginSettings.Login"/></li><li><c>/d:sonar.password</c> via <see cref="SonarScannerBeginSettings.Password"/></li><li><c>/d:sonar.projectDescription</c> via <see cref="SonarScannerBeginSettings.Description"/></li><li><c>/d:sonar.pullrequest.base</c> via <see cref="SonarScannerBeginSettings.PullRequestBase"/></li><li><c>/d:sonar.pullrequest.branch</c> via <see cref="SonarScannerBeginSettings.PullRequestBranch"/></li><li><c>/d:sonar.pullrequest.key</c> via <see cref="SonarScannerBeginSettings.PullRequestKey"/></li><li><c>/d:sonar.qualitygate.timeout</c> via <see cref="SonarScannerBeginSettings.QualityGateTimeout"/></li><li><c>/d:sonar.qualitygate.wait</c> via <see cref="SonarScannerBeginSettings.QualityGateWait"/></li><li><c>/d:sonar.scm.exclusions.disabled</c> via <see cref="SonarScannerBeginSettings.ScmExclusionsDisabled"/></li><li><c>/d:sonar.scm.forceReloadAll</c> via <see cref="SonarScannerBeginSettings.ScmForceReloadAll"/></li><li><c>/d:sonar.scm.provider</c> via <see cref="SonarScannerBeginSettings.ScmProvider"/></li><li><c>/d:sonar.scm.revision</c> via <see cref="SonarScannerBeginSettings.ScmRevision"/></li><li><c>/d:sonar.sourceEncoding</c> via <see cref="SonarScannerBeginSettings.SourceEncoding"/></li><li><c>/d:sonar.test.exclusions</c> via <see cref="SonarScannerBeginSettings.TestFileExclusions"/></li><li><c>/d:sonar.test.inclusions</c> via <see cref="SonarScannerBeginSettings.TestFileInclusions"/></li><li><c>/d:sonar.token</c> via <see cref="SonarScannerBeginSettings.Token"/></li><li><c>/d:sonar.verbose</c> via <see cref="SonarScannerBeginSettings.Verbose"/></li><li><c>/d:sonar.ws.timeout</c> via <see cref="SonarScannerBeginSettings.WebServiceTimeout"/></li><li><c>/k</c> via <see cref="SonarScannerBeginSettings.ProjectKey"/></li><li><c>/n</c> via <see cref="SonarScannerBeginSettings.Name"/></li><li><c>/o</c> via <see cref="SonarScannerBeginSettings.Organization"/></li><li><c>/v</c> via <see cref="SonarScannerBeginSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SonarScannerBegin(Configure<SonarScannerBeginSettings> configurator) => new SonarScannerTasks().Run(configurator.Invoke(new SonarScannerBeginSettings()));
    /// <summary><p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p><p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/d</c> via <see cref="SonarScannerBeginSettings.AdditionalParameters"/></li><li><c>/d:sonar.analysis.</c> via <see cref="SonarScannerBeginSettings.AdditionalAnalysisParameters"/></li><li><c>/d:sonar.branch.name</c> via <see cref="SonarScannerBeginSettings.BranchName"/></li><li><c>/d:sonar.clientcert.password</c> via <see cref="SonarScannerBeginSettings.ClientCertificatePassword"/></li><li><c>/d:sonar.clientcert.path</c> via <see cref="SonarScannerBeginSettings.ClientCertificatePath"/></li><li><c>/d:sonar.coverage.exclusions</c> via <see cref="SonarScannerBeginSettings.CoverageExclusions"/></li><li><c>/d:sonar.coverageReportPaths</c> via <see cref="SonarScannerBeginSettings.GenericCoveragePaths"/></li><li><c>/d:sonar.cpd.exclusions</c> via <see cref="SonarScannerBeginSettings.DuplicationExclusions"/></li><li><c>/d:sonar.cs.dotcover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.DotCoverPaths"/></li><li><c>/d:sonar.cs.nunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.NUnitTestReports"/></li><li><c>/d:sonar.cs.opencover.reportsPaths</c> via <see cref="SonarScannerBeginSettings.OpenCoverPaths"/></li><li><c>/d:sonar.cs.vscoveragexml.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/></li><li><c>/d:sonar.cs.vstest.reportsPaths</c> via <see cref="SonarScannerBeginSettings.VSTestReports"/></li><li><c>/d:sonar.cs.xunit.reportsPaths</c> via <see cref="SonarScannerBeginSettings.XUnitTestReports"/></li><li><c>/d:sonar.dotnet.excludeTestProjects</c> via <see cref="SonarScannerBeginSettings.ExcludeTestProjects"/></li><li><c>/d:sonar.exclusions</c> via <see cref="SonarScannerBeginSettings.SourceExclusions"/></li><li><c>/d:sonar.host.url</c> via <see cref="SonarScannerBeginSettings.Server"/></li><li><c>/d:sonar.inclusions</c> via <see cref="SonarScannerBeginSettings.SourceInclusions"/></li><li><c>/d:sonar.links.ci</c> via <see cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/></li><li><c>/d:sonar.links.homepage</c> via <see cref="SonarScannerBeginSettings.Homepage"/></li><li><c>/d:sonar.links.issue</c> via <see cref="SonarScannerBeginSettings.IssueTrackerUrl"/></li><li><c>/d:sonar.links.scm</c> via <see cref="SonarScannerBeginSettings.SCMUrl"/></li><li><c>/d:sonar.login</c> via <see cref="SonarScannerBeginSettings.Login"/></li><li><c>/d:sonar.password</c> via <see cref="SonarScannerBeginSettings.Password"/></li><li><c>/d:sonar.projectDescription</c> via <see cref="SonarScannerBeginSettings.Description"/></li><li><c>/d:sonar.pullrequest.base</c> via <see cref="SonarScannerBeginSettings.PullRequestBase"/></li><li><c>/d:sonar.pullrequest.branch</c> via <see cref="SonarScannerBeginSettings.PullRequestBranch"/></li><li><c>/d:sonar.pullrequest.key</c> via <see cref="SonarScannerBeginSettings.PullRequestKey"/></li><li><c>/d:sonar.qualitygate.timeout</c> via <see cref="SonarScannerBeginSettings.QualityGateTimeout"/></li><li><c>/d:sonar.qualitygate.wait</c> via <see cref="SonarScannerBeginSettings.QualityGateWait"/></li><li><c>/d:sonar.scm.exclusions.disabled</c> via <see cref="SonarScannerBeginSettings.ScmExclusionsDisabled"/></li><li><c>/d:sonar.scm.forceReloadAll</c> via <see cref="SonarScannerBeginSettings.ScmForceReloadAll"/></li><li><c>/d:sonar.scm.provider</c> via <see cref="SonarScannerBeginSettings.ScmProvider"/></li><li><c>/d:sonar.scm.revision</c> via <see cref="SonarScannerBeginSettings.ScmRevision"/></li><li><c>/d:sonar.sourceEncoding</c> via <see cref="SonarScannerBeginSettings.SourceEncoding"/></li><li><c>/d:sonar.test.exclusions</c> via <see cref="SonarScannerBeginSettings.TestFileExclusions"/></li><li><c>/d:sonar.test.inclusions</c> via <see cref="SonarScannerBeginSettings.TestFileInclusions"/></li><li><c>/d:sonar.token</c> via <see cref="SonarScannerBeginSettings.Token"/></li><li><c>/d:sonar.verbose</c> via <see cref="SonarScannerBeginSettings.Verbose"/></li><li><c>/d:sonar.ws.timeout</c> via <see cref="SonarScannerBeginSettings.WebServiceTimeout"/></li><li><c>/k</c> via <see cref="SonarScannerBeginSettings.ProjectKey"/></li><li><c>/n</c> via <see cref="SonarScannerBeginSettings.Name"/></li><li><c>/o</c> via <see cref="SonarScannerBeginSettings.Organization"/></li><li><c>/v</c> via <see cref="SonarScannerBeginSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(SonarScannerBeginSettings Settings, IReadOnlyCollection<Output> Output)> SonarScannerBegin(CombinatorialConfigure<SonarScannerBeginSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SonarScannerBegin, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p><p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/d:sonar.clientcert.password</c> via <see cref="SonarScannerEndSettings.ClientCertificatePassword"/></li><li><c>/d:sonar.login</c> via <see cref="SonarScannerEndSettings.Login"/></li><li><c>/d:sonar.password</c> via <see cref="SonarScannerEndSettings.Password"/></li><li><c>/d:sonar.token</c> via <see cref="SonarScannerEndSettings.Token"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SonarScannerEnd(SonarScannerEndSettings options = null) => new SonarScannerTasks().Run(options);
    /// <summary><p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p><p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/d:sonar.clientcert.password</c> via <see cref="SonarScannerEndSettings.ClientCertificatePassword"/></li><li><c>/d:sonar.login</c> via <see cref="SonarScannerEndSettings.Login"/></li><li><c>/d:sonar.password</c> via <see cref="SonarScannerEndSettings.Password"/></li><li><c>/d:sonar.token</c> via <see cref="SonarScannerEndSettings.Token"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SonarScannerEnd(Configure<SonarScannerEndSettings> configurator) => new SonarScannerTasks().Run(configurator.Invoke(new SonarScannerEndSettings()));
    /// <summary><p>The SonarScanner for MSBuild is the recommended way to launch a SonarQube or SonarCloud analysis for projects/solutions using MSBuild or dotnet command as build tool.</p><p>For more details, visit the <a href="https://www.sonarqube.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/d:sonar.clientcert.password</c> via <see cref="SonarScannerEndSettings.ClientCertificatePassword"/></li><li><c>/d:sonar.login</c> via <see cref="SonarScannerEndSettings.Login"/></li><li><c>/d:sonar.password</c> via <see cref="SonarScannerEndSettings.Password"/></li><li><c>/d:sonar.token</c> via <see cref="SonarScannerEndSettings.Token"/></li></ul></remarks>
    public static IEnumerable<(SonarScannerEndSettings Settings, IReadOnlyCollection<Output> Output)> SonarScannerEnd(CombinatorialConfigure<SonarScannerEndSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SonarScannerEnd, degreeOfParallelism, completeOnFailure);
}
#region SonarScannerBeginSettings
/// <summary>Used within <see cref="SonarScannerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SonarScannerBeginSettings>))]
[Command(Type = typeof(SonarScannerTasks), Command = nameof(SonarScannerTasks.SonarScannerBegin), Arguments = "begin")]
public partial class SonarScannerBeginSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>Specifies the key of the analyzed project in SonarQube.</summary>
    [Argument(Format = "/k:{value}", Secret = false)] public string ProjectKey => Get<string>(() => ProjectKey);
    /// <summary>Specifies the name of the analyzed project in SonarQube. Adding this argument will overwrite the project name in SonarQube if it already exists.</summary>
    [Argument(Format = "/n:{value}")] public string Name => Get<string>(() => Name);
    /// <summary>Specifies the version of your project.</summary>
    [Argument(Format = "/v:{value}")] public string Version => Get<string>(() => Version);
    /// <summary>Specifies the Organization of your project.</summary>
    [Argument(Format = "/o:{value}")] public string Organization => Get<string>(() => Organization);
    /// <summary>The project description.</summary>
    [Argument(Format = "/d:sonar.projectDescription={value}")] public string Description => Get<string>(() => Description);
    /// <summary>The server URL. Default is <c>http://localhost:9000</c></summary>
    [Argument(Format = "/d:sonar.host.url={value}")] public string Server => Get<string>(() => Server);
    /// <summary>Specifies the username or access token to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added on the end step.</summary>
    [Argument(Format = "/d:sonar.login={value}", Secret = true)] public string Login => Get<string>(() => Login);
    /// <summary>Specifies the password for the SonarQube username in the <c>sonar.login</c> argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.</summary>
    [Argument(Format = "/d:sonar.password={value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Specifies the authentication token used to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added to the end step.</summary>
    [Argument(Format = "/d:sonar.token={value}", Secret = true)] public string Token => Get<string>(() => Token);
    /// <summary>Sets the logging verbosity to detailed. Add this argument before sending logs for troubleshooting.</summary>
    [Argument(Format = "/d:sonar.verbose={value}")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Comma separated list of VSTest report files to include.</summary>
    [Argument(Format = "/d:sonar.cs.vstest.reportsPaths={value}", Separator = ",")] public IReadOnlyList<string> VSTestReports => Get<List<string>>(() => VSTestReports);
    /// <summary>Comma separated list of NUnit report files to include.</summary>
    [Argument(Format = "/d:sonar.cs.nunit.reportsPaths={value}", Separator = ",")] public IReadOnlyList<string> NUnitTestReports => Get<List<string>>(() => NUnitTestReports);
    /// <summary>Comma separated list of xUnit report files to include.</summary>
    [Argument(Format = "/d:sonar.cs.xunit.reportsPaths={value}", Separator = ",")] public IReadOnlyList<string> XUnitTestReports => Get<List<string>>(() => XUnitTestReports);
    /// <summary>Comma separated list of source files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</summary>
    [Argument(Format = "/d:sonar.exclusions={value}", Separator = ",")] public IReadOnlyList<string> SourceExclusions => Get<List<string>>(() => SourceExclusions);
    /// <summary>Comma separated list of source files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</summary>
    [Argument(Format = "/d:sonar.inclusions={value}", Separator = ",")] public IReadOnlyList<string> SourceInclusions => Get<List<string>>(() => SourceInclusions);
    /// <summary>Comma separated list of test files to exclude from analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</summary>
    [Argument(Format = "/d:sonar.test.exclusions={value}", Separator = ",")] public IReadOnlyList<string> TestFileExclusions => Get<List<string>>(() => TestFileExclusions);
    /// <summary>Comma separated list of test files to include in analysis scope. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</summary>
    [Argument(Format = "/d:sonar.test.inclusions={value}", Separator = ",")] public IReadOnlyList<string> TestFileInclusions => Get<List<string>>(() => TestFileInclusions);
    /// <summary>Comma separated list of files to exclude from coverage calculations. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</summary>
    [Argument(Format = "/d:sonar.coverage.exclusions={value}", Separator = ",")] public IReadOnlyList<string> CoverageExclusions => Get<List<string>>(() => CoverageExclusions);
    /// <summary>Comma separated list of coverage reports in the <a href="https://docs.sonarqube.org/latest/analysis/generic-test/">Generic Test Data</a> format. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</summary>
    [Argument(Format = "/d:sonar.coverageReportPaths={value}", Separator = ",")] public IReadOnlyList<string> GenericCoveragePaths => Get<List<string>>(() => GenericCoveragePaths);
    /// <summary>Comma separated list of Visual Studio Code Coverage reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</summary>
    [Argument(Format = "/d:sonar.cs.vscoveragexml.reportsPaths={value}", Separator = ",")] public IReadOnlyList<string> VisualStudioCoveragePaths => Get<List<string>>(() => VisualStudioCoveragePaths);
    /// <summary>Comma separated list of dotCover HTML-reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</summary>
    [Argument(Format = "/d:sonar.cs.dotcover.reportsPaths={value}", Separator = ",")] public IReadOnlyList<string> DotCoverPaths => Get<List<string>>(() => DotCoverPaths);
    /// <summary>Comma separated list of OpenCover reports to include. Supports wildcards (<c>*</c>, <c>**</c>, <c>?</c>).</summary>
    [Argument(Format = "/d:sonar.cs.opencover.reportsPaths={value}", Separator = ",")] public IReadOnlyList<string> OpenCoverPaths => Get<List<string>>(() => OpenCoverPaths);
    /// <summary>Maximum time to wait for the response of a Web Service call (in seconds). Modifying this value from the default is useful only when you're experiencing timeouts during analysis while waiting for the server to respond to Web Service calls.</summary>
    [Argument(Format = "/d:sonar.ws.timeout={value}")] public int? WebServiceTimeout => Get<int?>(() => WebServiceTimeout);
    /// <summary>Project home page.</summary>
    [Argument(Format = "/d:sonar.links.homepage={value}")] public string Homepage => Get<string>(() => Homepage);
    /// <summary>Link to Continuous integration</summary>
    [Argument(Format = "/d:sonar.links.ci={value}")] public string ContinuousIntegrationUrl => Get<string>(() => ContinuousIntegrationUrl);
    /// <summary>Link to Issue tracker.</summary>
    [Argument(Format = "/d:sonar.links.issue={value}")] public string IssueTrackerUrl => Get<string>(() => IssueTrackerUrl);
    /// <summary>Link to project source repository</summary>
    [Argument(Format = "/d:sonar.links.scm={value}")] public string SCMUrl => Get<string>(() => SCMUrl);
    /// <summary>Encoding of the source files. Ex: <c>UTF-8</c> , <c>MacRoman</c> , <c>Shift_JIS</c>. This property can be replaced by the standard property <c>project.build.sourceEncoding</c> in Maven projects. The list of available encodings depends on your JVM.</summary>
    [Argument(Format = "/d:sonar.sourceEncoding={value}")] public string SourceEncoding => Get<string>(() => SourceEncoding);
    /// <summary>Comma-delimited list of file path patterns to be excluded from duplication detection.</summary>
    [Argument(Format = "/d:sonar.cpd.exclusions={value}", Separator = ",")] public IReadOnlyList<string> DuplicationExclusions => Get<List<string>>(() => DuplicationExclusions);
    /// <summary>Name of the branch (visible in the UI)</summary>
    [Argument(Format = "/d:sonar.branch.name={value}")] public string BranchName => Get<string>(() => BranchName);
    /// <summary>Unique identifier of your Pull Request. Must correspond to the key of the Pull Request in your ALM. e.g.: <c>sonar.pullrequest.key=5</c></summary>
    [Argument(Format = "/d:sonar.pullrequest.key={value}")] public string PullRequestKey => Get<string>(() => PullRequestKey);
    /// <summary>The name of the branch that contains the changes to be merged. e.g.: <c>sonar.pullrequest.branch=feature/my-new-feature</c></summary>
    [Argument(Format = "/d:sonar.pullrequest.branch={value}")] public string PullRequestBranch => Get<string>(() => PullRequestBranch);
    /// <summary>The branch into which the Pull Request will be merged. Default: <c>master</c>. e.g.: <c>sonar.pullrequest.base=master</c></summary>
    [Argument(Format = "/d:sonar.pullrequest.base={value}")] public string PullRequestBase => Get<string>(() => PullRequestBase);
    /// <summary>Excludes Test Projects from analysis. Add this argument to improve build performance when issues should not be detected in Test Projects.</summary>
    [Argument(Format = "/d:sonar.dotnet.excludeTestProjects={value}")] public bool? ExcludeTestProjects => Get<bool?>(() => ExcludeTestProjects);
    /// <summary>This property can be used to explicitly tell SonarQube which SCM you're using on the project (in case auto-detection doesn't work). The value of this property is always lowercase and depends on the SCM (ex. "git" if you're using Git).</summary>
    [Argument(Format = "/d:sonar.scm.provider={value}")] public string ScmProvider => Get<string>(() => ScmProvider);
    /// <summary>By default, blame information is only retrieved for changed files. Set this property to true to load blame information for all files. This can be useful is you feel that some SCM data is outdated but SonarQube does not get the latest information from the SCM engine.</summary>
    [Argument(Format = "/d:sonar.scm.forceReloadAll={value}")] public bool? ScmForceReloadAll => Get<bool?>(() => ScmForceReloadAll);
    /// <summary>For supported engines, files ignored by the SCM, i.e. files listed in .gitignore, will automatically be ignored by analysis too. Set this property to true to disable that feature. SCM exclusions are always disabled if sonar.scm.disabled is set to true.</summary>
    [Argument(Format = "/d:sonar.scm.exclusions.disabled={value}")] public bool? ScmExclusionsDisabled => Get<bool?>(() => ScmExclusionsDisabled);
    /// <summary>Overrides the revision, for instance the Git sha1, displayed in analysis results. By default value is provided by the CI environment or guessed by the checked-out sources.</summary>
    [Argument(Format = "/d:sonar.scm.revision={value}")] public string ScmRevision => Get<string>(() => ScmRevision);
    /// <summary>Forces the analysis step to poll the SonarQube instance and wait for the Quality Gate status. If there are no other options, you can use this to fail a pipeline build when the Quality Gate is failing.</summary>
    [Argument(Format = "/d:sonar.qualitygate.wait={value}")] public bool? QualityGateWait => Get<bool?>(() => QualityGateWait);
    /// <summary>Sets the number of seconds that the scanner should wait for a report to be processed. Default: <c>300</c>. e.g.: <c>sonar.qualitygate.timeout=300</c></summary>
    [Argument(Format = "/d:sonar.qualitygate.timeout={value}")] public int? QualityGateTimeout => Get<int?>(() => QualityGateTimeout);
    /// <summary>This property stub allows you to insert custom key/value pairs into the analysis context, which will also be passed forward to webhooks.</summary>
    [Argument(Format = "/d:sonar.analysis.{key}={value}")] public IReadOnlyDictionary<string, string> AdditionalAnalysisParameters => Get<Dictionary<string, string>>(() => AdditionalAnalysisParameters);
    /// <summary>Specifies an additional SonarQube analysis parameter, you can add this argument multiple times.</summary>
    [Argument(Format = "/d:{key}={value}")] public IReadOnlyDictionary<string, string> AdditionalParameters => Get<Dictionary<string, string>>(() => AdditionalParameters);
    /// <summary>Specifies the path to a client certificate used to access SonarQube. The certificate must be password protected.</summary>
    [Argument(Format = "/d:sonar.clientcert.path={value}")] public string ClientCertificatePath => Get<string>(() => ClientCertificatePath);
    /// <summary>Specifies the password for the client certificate used to access SonarQube. Required if a client certificate is used.</summary>
    [Argument(Format = "/d:sonar.clientcert.password={value}")] public string ClientCertificatePassword => Get<string>(() => ClientCertificatePassword);
}
#endregion
#region SonarScannerEndSettings
/// <summary>Used within <see cref="SonarScannerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SonarScannerEndSettings>))]
[Command(Type = typeof(SonarScannerTasks), Command = nameof(SonarScannerTasks.SonarScannerEnd), Arguments = "end")]
public partial class SonarScannerEndSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>Specifies the username or access token to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added on the end step.</summary>
    [Argument(Format = "/d:sonar.login={value}", Secret = true)] public string Login => Get<string>(() => Login);
    /// <summary>Specifies the password for the SonarQube username in the <c>sonar.login</c> argument. This argument is not needed if you use authentication token. If this argument is added to the begin step, it must also be added on the end step.</summary>
    [Argument(Format = "/d:sonar.password={value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Specifies the authentication token used to authenticate with to SonarQube. If this argument is added to the begin step, it must also be added to the end step.</summary>
    [Argument(Format = "/d:sonar.token={value}", Secret = true)] public string Token => Get<string>(() => Token);
    /// <summary>Specifies the password for the client certificate used to access SonarQube. Required if a client certificate is used.</summary>
    [Argument(Format = "/d:sonar.clientcert.password={value}")] public string ClientCertificatePassword => Get<string>(() => ClientCertificatePassword);
}
#endregion
#region SonarScannerBeginSettingsExtensions
/// <summary>Used within <see cref="SonarScannerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SonarScannerBeginSettingsExtensions
{
    #region ProjectKey
    /// <inheritdoc cref="SonarScannerBeginSettings.ProjectKey"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ProjectKey))]
    public static T SetProjectKey<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ProjectKey, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.ProjectKey"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ProjectKey))]
    public static T ResetProjectKey<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.ProjectKey));
    #endregion
    #region Name
    /// <inheritdoc cref="SonarScannerBeginSettings.Name"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.Name"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Name))]
    public static T ResetName<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Version
    /// <inheritdoc cref="SonarScannerBeginSettings.Version"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.Version"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Organization
    /// <inheritdoc cref="SonarScannerBeginSettings.Organization"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Organization))]
    public static T SetOrganization<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Organization, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.Organization"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Organization))]
    public static T ResetOrganization<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.Organization));
    #endregion
    #region Description
    /// <inheritdoc cref="SonarScannerBeginSettings.Description"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Description))]
    public static T SetDescription<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.Description"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Description))]
    public static T ResetDescription<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region Server
    /// <inheritdoc cref="SonarScannerBeginSettings.Server"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Server))]
    public static T SetServer<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Server, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.Server"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Server))]
    public static T ResetServer<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.Server));
    #endregion
    #region Login
    /// <inheritdoc cref="SonarScannerBeginSettings.Login"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Login))]
    public static T SetLogin<T>(this T o, [Secret] string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Login, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.Login"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Login))]
    public static T ResetLogin<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.Login));
    #endregion
    #region Password
    /// <inheritdoc cref="SonarScannerBeginSettings.Password"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.Password"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Token
    /// <inheritdoc cref="SonarScannerBeginSettings.Token"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Token))]
    public static T SetToken<T>(this T o, [Secret] string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Token, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.Token"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Token))]
    public static T ResetToken<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.Token));
    #endregion
    #region Verbose
    /// <inheritdoc cref="SonarScannerBeginSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="SonarScannerBeginSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="SonarScannerBeginSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="SonarScannerBeginSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region VSTestReports
    /// <inheritdoc cref="SonarScannerBeginSettings.VSTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VSTestReports))]
    public static T SetVSTestReports<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.VSTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VSTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VSTestReports))]
    public static T SetVSTestReports<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.VSTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VSTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VSTestReports))]
    public static T AddVSTestReports<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.VSTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VSTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VSTestReports))]
    public static T AddVSTestReports<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.VSTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VSTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VSTestReports))]
    public static T RemoveVSTestReports<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.VSTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VSTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VSTestReports))]
    public static T RemoveVSTestReports<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.VSTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VSTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VSTestReports))]
    public static T ClearVSTestReports<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.VSTestReports));
    #endregion
    #region NUnitTestReports
    /// <inheritdoc cref="SonarScannerBeginSettings.NUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.NUnitTestReports))]
    public static T SetNUnitTestReports<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.NUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.NUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.NUnitTestReports))]
    public static T SetNUnitTestReports<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.NUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.NUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.NUnitTestReports))]
    public static T AddNUnitTestReports<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.NUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.NUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.NUnitTestReports))]
    public static T AddNUnitTestReports<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.NUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.NUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.NUnitTestReports))]
    public static T RemoveNUnitTestReports<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.NUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.NUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.NUnitTestReports))]
    public static T RemoveNUnitTestReports<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.NUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.NUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.NUnitTestReports))]
    public static T ClearNUnitTestReports<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.NUnitTestReports));
    #endregion
    #region XUnitTestReports
    /// <inheritdoc cref="SonarScannerBeginSettings.XUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.XUnitTestReports))]
    public static T SetXUnitTestReports<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.XUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.XUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.XUnitTestReports))]
    public static T SetXUnitTestReports<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.XUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.XUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.XUnitTestReports))]
    public static T AddXUnitTestReports<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.XUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.XUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.XUnitTestReports))]
    public static T AddXUnitTestReports<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.XUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.XUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.XUnitTestReports))]
    public static T RemoveXUnitTestReports<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.XUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.XUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.XUnitTestReports))]
    public static T RemoveXUnitTestReports<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.XUnitTestReports, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.XUnitTestReports"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.XUnitTestReports))]
    public static T ClearXUnitTestReports<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.XUnitTestReports));
    #endregion
    #region SourceExclusions
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceExclusions))]
    public static T SetSourceExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.SourceExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceExclusions))]
    public static T SetSourceExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.SourceExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceExclusions))]
    public static T AddSourceExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.SourceExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceExclusions))]
    public static T AddSourceExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.SourceExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceExclusions))]
    public static T RemoveSourceExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.SourceExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceExclusions))]
    public static T RemoveSourceExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.SourceExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceExclusions))]
    public static T ClearSourceExclusions<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.SourceExclusions));
    #endregion
    #region SourceInclusions
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceInclusions))]
    public static T SetSourceInclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.SourceInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceInclusions))]
    public static T SetSourceInclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.SourceInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceInclusions))]
    public static T AddSourceInclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.SourceInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceInclusions))]
    public static T AddSourceInclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.SourceInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceInclusions))]
    public static T RemoveSourceInclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.SourceInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceInclusions))]
    public static T RemoveSourceInclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.SourceInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceInclusions))]
    public static T ClearSourceInclusions<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.SourceInclusions));
    #endregion
    #region TestFileExclusions
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileExclusions))]
    public static T SetTestFileExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.TestFileExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileExclusions))]
    public static T SetTestFileExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.TestFileExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileExclusions))]
    public static T AddTestFileExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.TestFileExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileExclusions))]
    public static T AddTestFileExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.TestFileExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileExclusions))]
    public static T RemoveTestFileExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.TestFileExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileExclusions))]
    public static T RemoveTestFileExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.TestFileExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileExclusions))]
    public static T ClearTestFileExclusions<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.TestFileExclusions));
    #endregion
    #region TestFileInclusions
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileInclusions))]
    public static T SetTestFileInclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.TestFileInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileInclusions))]
    public static T SetTestFileInclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.TestFileInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileInclusions))]
    public static T AddTestFileInclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.TestFileInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileInclusions))]
    public static T AddTestFileInclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.TestFileInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileInclusions))]
    public static T RemoveTestFileInclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.TestFileInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileInclusions))]
    public static T RemoveTestFileInclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.TestFileInclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.TestFileInclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.TestFileInclusions))]
    public static T ClearTestFileInclusions<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.TestFileInclusions));
    #endregion
    #region CoverageExclusions
    /// <inheritdoc cref="SonarScannerBeginSettings.CoverageExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.CoverageExclusions))]
    public static T SetCoverageExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.CoverageExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.CoverageExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.CoverageExclusions))]
    public static T SetCoverageExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.CoverageExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.CoverageExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.CoverageExclusions))]
    public static T AddCoverageExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.CoverageExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.CoverageExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.CoverageExclusions))]
    public static T AddCoverageExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.CoverageExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.CoverageExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.CoverageExclusions))]
    public static T RemoveCoverageExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.CoverageExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.CoverageExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.CoverageExclusions))]
    public static T RemoveCoverageExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.CoverageExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.CoverageExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.CoverageExclusions))]
    public static T ClearCoverageExclusions<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.CoverageExclusions));
    #endregion
    #region GenericCoveragePaths
    /// <inheritdoc cref="SonarScannerBeginSettings.GenericCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.GenericCoveragePaths))]
    public static T SetGenericCoveragePaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.GenericCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.GenericCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.GenericCoveragePaths))]
    public static T SetGenericCoveragePaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.GenericCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.GenericCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.GenericCoveragePaths))]
    public static T AddGenericCoveragePaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.GenericCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.GenericCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.GenericCoveragePaths))]
    public static T AddGenericCoveragePaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.GenericCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.GenericCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.GenericCoveragePaths))]
    public static T RemoveGenericCoveragePaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.GenericCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.GenericCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.GenericCoveragePaths))]
    public static T RemoveGenericCoveragePaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.GenericCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.GenericCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.GenericCoveragePaths))]
    public static T ClearGenericCoveragePaths<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.GenericCoveragePaths));
    #endregion
    #region VisualStudioCoveragePaths
    /// <inheritdoc cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VisualStudioCoveragePaths))]
    public static T SetVisualStudioCoveragePaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.VisualStudioCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VisualStudioCoveragePaths))]
    public static T SetVisualStudioCoveragePaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.VisualStudioCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VisualStudioCoveragePaths))]
    public static T AddVisualStudioCoveragePaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.VisualStudioCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VisualStudioCoveragePaths))]
    public static T AddVisualStudioCoveragePaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.VisualStudioCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VisualStudioCoveragePaths))]
    public static T RemoveVisualStudioCoveragePaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.VisualStudioCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VisualStudioCoveragePaths))]
    public static T RemoveVisualStudioCoveragePaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.VisualStudioCoveragePaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.VisualStudioCoveragePaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.VisualStudioCoveragePaths))]
    public static T ClearVisualStudioCoveragePaths<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.VisualStudioCoveragePaths));
    #endregion
    #region DotCoverPaths
    /// <inheritdoc cref="SonarScannerBeginSettings.DotCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DotCoverPaths))]
    public static T SetDotCoverPaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.DotCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DotCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DotCoverPaths))]
    public static T SetDotCoverPaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.DotCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DotCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DotCoverPaths))]
    public static T AddDotCoverPaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.DotCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DotCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DotCoverPaths))]
    public static T AddDotCoverPaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.DotCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DotCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DotCoverPaths))]
    public static T RemoveDotCoverPaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.DotCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DotCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DotCoverPaths))]
    public static T RemoveDotCoverPaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.DotCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DotCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DotCoverPaths))]
    public static T ClearDotCoverPaths<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.DotCoverPaths));
    #endregion
    #region OpenCoverPaths
    /// <inheritdoc cref="SonarScannerBeginSettings.OpenCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.OpenCoverPaths))]
    public static T SetOpenCoverPaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.OpenCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.OpenCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.OpenCoverPaths))]
    public static T SetOpenCoverPaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.OpenCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.OpenCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.OpenCoverPaths))]
    public static T AddOpenCoverPaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.OpenCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.OpenCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.OpenCoverPaths))]
    public static T AddOpenCoverPaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.OpenCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.OpenCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.OpenCoverPaths))]
    public static T RemoveOpenCoverPaths<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.OpenCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.OpenCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.OpenCoverPaths))]
    public static T RemoveOpenCoverPaths<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.OpenCoverPaths, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.OpenCoverPaths"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.OpenCoverPaths))]
    public static T ClearOpenCoverPaths<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.OpenCoverPaths));
    #endregion
    #region WebServiceTimeout
    /// <inheritdoc cref="SonarScannerBeginSettings.WebServiceTimeout"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.WebServiceTimeout))]
    public static T SetWebServiceTimeout<T>(this T o, int? v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.WebServiceTimeout, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.WebServiceTimeout"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.WebServiceTimeout))]
    public static T ResetWebServiceTimeout<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.WebServiceTimeout));
    #endregion
    #region Homepage
    /// <inheritdoc cref="SonarScannerBeginSettings.Homepage"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Homepage))]
    public static T SetHomepage<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.Homepage, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.Homepage"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.Homepage))]
    public static T ResetHomepage<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.Homepage));
    #endregion
    #region ContinuousIntegrationUrl
    /// <inheritdoc cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ContinuousIntegrationUrl))]
    public static T SetContinuousIntegrationUrl<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ContinuousIntegrationUrl, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.ContinuousIntegrationUrl"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ContinuousIntegrationUrl))]
    public static T ResetContinuousIntegrationUrl<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.ContinuousIntegrationUrl));
    #endregion
    #region IssueTrackerUrl
    /// <inheritdoc cref="SonarScannerBeginSettings.IssueTrackerUrl"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.IssueTrackerUrl))]
    public static T SetIssueTrackerUrl<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.IssueTrackerUrl, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.IssueTrackerUrl"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.IssueTrackerUrl))]
    public static T ResetIssueTrackerUrl<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.IssueTrackerUrl));
    #endregion
    #region SCMUrl
    /// <inheritdoc cref="SonarScannerBeginSettings.SCMUrl"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SCMUrl))]
    public static T SetSCMUrl<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.SCMUrl, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SCMUrl"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SCMUrl))]
    public static T ResetSCMUrl<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.SCMUrl));
    #endregion
    #region SourceEncoding
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceEncoding"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceEncoding))]
    public static T SetSourceEncoding<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.SourceEncoding, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.SourceEncoding"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.SourceEncoding))]
    public static T ResetSourceEncoding<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.SourceEncoding));
    #endregion
    #region DuplicationExclusions
    /// <inheritdoc cref="SonarScannerBeginSettings.DuplicationExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DuplicationExclusions))]
    public static T SetDuplicationExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.DuplicationExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DuplicationExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DuplicationExclusions))]
    public static T SetDuplicationExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.DuplicationExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DuplicationExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DuplicationExclusions))]
    public static T AddDuplicationExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.DuplicationExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DuplicationExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DuplicationExclusions))]
    public static T AddDuplicationExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddCollection(() => o.DuplicationExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DuplicationExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DuplicationExclusions))]
    public static T RemoveDuplicationExclusions<T>(this T o, params string[] v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.DuplicationExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DuplicationExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DuplicationExclusions))]
    public static T RemoveDuplicationExclusions<T>(this T o, IEnumerable<string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveCollection(() => o.DuplicationExclusions, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.DuplicationExclusions"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.DuplicationExclusions))]
    public static T ClearDuplicationExclusions<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearCollection(() => o.DuplicationExclusions));
    #endregion
    #region BranchName
    /// <inheritdoc cref="SonarScannerBeginSettings.BranchName"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.BranchName))]
    public static T SetBranchName<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.BranchName, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.BranchName"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.BranchName))]
    public static T ResetBranchName<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.BranchName));
    #endregion
    #region PullRequestKey
    /// <inheritdoc cref="SonarScannerBeginSettings.PullRequestKey"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.PullRequestKey))]
    public static T SetPullRequestKey<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.PullRequestKey, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.PullRequestKey"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.PullRequestKey))]
    public static T ResetPullRequestKey<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.PullRequestKey));
    #endregion
    #region PullRequestBranch
    /// <inheritdoc cref="SonarScannerBeginSettings.PullRequestBranch"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.PullRequestBranch))]
    public static T SetPullRequestBranch<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.PullRequestBranch, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.PullRequestBranch"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.PullRequestBranch))]
    public static T ResetPullRequestBranch<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.PullRequestBranch));
    #endregion
    #region PullRequestBase
    /// <inheritdoc cref="SonarScannerBeginSettings.PullRequestBase"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.PullRequestBase))]
    public static T SetPullRequestBase<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.PullRequestBase, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.PullRequestBase"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.PullRequestBase))]
    public static T ResetPullRequestBase<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.PullRequestBase));
    #endregion
    #region ExcludeTestProjects
    /// <inheritdoc cref="SonarScannerBeginSettings.ExcludeTestProjects"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ExcludeTestProjects))]
    public static T SetExcludeTestProjects<T>(this T o, bool? v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ExcludeTestProjects, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.ExcludeTestProjects"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ExcludeTestProjects))]
    public static T ResetExcludeTestProjects<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.ExcludeTestProjects));
    /// <inheritdoc cref="SonarScannerBeginSettings.ExcludeTestProjects"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ExcludeTestProjects))]
    public static T EnableExcludeTestProjects<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ExcludeTestProjects, true));
    /// <inheritdoc cref="SonarScannerBeginSettings.ExcludeTestProjects"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ExcludeTestProjects))]
    public static T DisableExcludeTestProjects<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ExcludeTestProjects, false));
    /// <inheritdoc cref="SonarScannerBeginSettings.ExcludeTestProjects"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ExcludeTestProjects))]
    public static T ToggleExcludeTestProjects<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ExcludeTestProjects, !o.ExcludeTestProjects));
    #endregion
    #region ScmProvider
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmProvider"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmProvider))]
    public static T SetScmProvider<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ScmProvider, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmProvider"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmProvider))]
    public static T ResetScmProvider<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.ScmProvider));
    #endregion
    #region ScmForceReloadAll
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmForceReloadAll"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmForceReloadAll))]
    public static T SetScmForceReloadAll<T>(this T o, bool? v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ScmForceReloadAll, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmForceReloadAll"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmForceReloadAll))]
    public static T ResetScmForceReloadAll<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.ScmForceReloadAll));
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmForceReloadAll"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmForceReloadAll))]
    public static T EnableScmForceReloadAll<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ScmForceReloadAll, true));
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmForceReloadAll"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmForceReloadAll))]
    public static T DisableScmForceReloadAll<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ScmForceReloadAll, false));
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmForceReloadAll"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmForceReloadAll))]
    public static T ToggleScmForceReloadAll<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ScmForceReloadAll, !o.ScmForceReloadAll));
    #endregion
    #region ScmExclusionsDisabled
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmExclusionsDisabled"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmExclusionsDisabled))]
    public static T SetScmExclusionsDisabled<T>(this T o, bool? v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ScmExclusionsDisabled, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmExclusionsDisabled"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmExclusionsDisabled))]
    public static T ResetScmExclusionsDisabled<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.ScmExclusionsDisabled));
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmExclusionsDisabled"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmExclusionsDisabled))]
    public static T EnableScmExclusionsDisabled<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ScmExclusionsDisabled, true));
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmExclusionsDisabled"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmExclusionsDisabled))]
    public static T DisableScmExclusionsDisabled<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ScmExclusionsDisabled, false));
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmExclusionsDisabled"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmExclusionsDisabled))]
    public static T ToggleScmExclusionsDisabled<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ScmExclusionsDisabled, !o.ScmExclusionsDisabled));
    #endregion
    #region ScmRevision
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmRevision"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmRevision))]
    public static T SetScmRevision<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ScmRevision, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.ScmRevision"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ScmRevision))]
    public static T ResetScmRevision<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.ScmRevision));
    #endregion
    #region QualityGateWait
    /// <inheritdoc cref="SonarScannerBeginSettings.QualityGateWait"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.QualityGateWait))]
    public static T SetQualityGateWait<T>(this T o, bool? v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.QualityGateWait, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.QualityGateWait"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.QualityGateWait))]
    public static T ResetQualityGateWait<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.QualityGateWait));
    /// <inheritdoc cref="SonarScannerBeginSettings.QualityGateWait"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.QualityGateWait))]
    public static T EnableQualityGateWait<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.QualityGateWait, true));
    /// <inheritdoc cref="SonarScannerBeginSettings.QualityGateWait"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.QualityGateWait))]
    public static T DisableQualityGateWait<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.QualityGateWait, false));
    /// <inheritdoc cref="SonarScannerBeginSettings.QualityGateWait"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.QualityGateWait))]
    public static T ToggleQualityGateWait<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.QualityGateWait, !o.QualityGateWait));
    #endregion
    #region QualityGateTimeout
    /// <inheritdoc cref="SonarScannerBeginSettings.QualityGateTimeout"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.QualityGateTimeout))]
    public static T SetQualityGateTimeout<T>(this T o, int? v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.QualityGateTimeout, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.QualityGateTimeout"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.QualityGateTimeout))]
    public static T ResetQualityGateTimeout<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.QualityGateTimeout));
    #endregion
    #region AdditionalAnalysisParameters
    /// <inheritdoc cref="SonarScannerBeginSettings.AdditionalAnalysisParameters"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.AdditionalAnalysisParameters))]
    public static T SetAdditionalAnalysisParameters<T>(this T o, IDictionary<string, string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.AdditionalAnalysisParameters, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="SonarScannerBeginSettings.AdditionalAnalysisParameters"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.AdditionalAnalysisParameters))]
    public static T SetAdditionalAnalysisParameter<T>(this T o, string k, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.SetDictionary(() => o.AdditionalAnalysisParameters, k, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.AdditionalAnalysisParameters"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.AdditionalAnalysisParameters))]
    public static T AddAdditionalAnalysisParameter<T>(this T o, string k, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddDictionary(() => o.AdditionalAnalysisParameters, k, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.AdditionalAnalysisParameters"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.AdditionalAnalysisParameters))]
    public static T RemoveAdditionalAnalysisParameter<T>(this T o, string k) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveDictionary(() => o.AdditionalAnalysisParameters, k));
    /// <inheritdoc cref="SonarScannerBeginSettings.AdditionalAnalysisParameters"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.AdditionalAnalysisParameters))]
    public static T ClearAdditionalAnalysisParameters<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearDictionary(() => o.AdditionalAnalysisParameters));
    #endregion
    #region AdditionalParameters
    /// <inheritdoc cref="SonarScannerBeginSettings.AdditionalParameters"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.AdditionalParameters))]
    public static T SetAdditionalParameters<T>(this T o, IDictionary<string, string> v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.AdditionalParameters, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="SonarScannerBeginSettings.AdditionalParameters"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.AdditionalParameters))]
    public static T SetAdditionalParameter<T>(this T o, string k, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.SetDictionary(() => o.AdditionalParameters, k, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.AdditionalParameters"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.AdditionalParameters))]
    public static T AddAdditionalParameter<T>(this T o, string k, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.AddDictionary(() => o.AdditionalParameters, k, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.AdditionalParameters"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.AdditionalParameters))]
    public static T RemoveAdditionalParameter<T>(this T o, string k) where T : SonarScannerBeginSettings => o.Modify(b => b.RemoveDictionary(() => o.AdditionalParameters, k));
    /// <inheritdoc cref="SonarScannerBeginSettings.AdditionalParameters"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.AdditionalParameters))]
    public static T ClearAdditionalParameters<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.ClearDictionary(() => o.AdditionalParameters));
    #endregion
    #region ClientCertificatePath
    /// <inheritdoc cref="SonarScannerBeginSettings.ClientCertificatePath"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ClientCertificatePath))]
    public static T SetClientCertificatePath<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ClientCertificatePath, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.ClientCertificatePath"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ClientCertificatePath))]
    public static T ResetClientCertificatePath<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.ClientCertificatePath));
    #endregion
    #region ClientCertificatePassword
    /// <inheritdoc cref="SonarScannerBeginSettings.ClientCertificatePassword"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ClientCertificatePassword))]
    public static T SetClientCertificatePassword<T>(this T o, string v) where T : SonarScannerBeginSettings => o.Modify(b => b.Set(() => o.ClientCertificatePassword, v));
    /// <inheritdoc cref="SonarScannerBeginSettings.ClientCertificatePassword"/>
    [Pure] [Builder(Type = typeof(SonarScannerBeginSettings), Property = nameof(SonarScannerBeginSettings.ClientCertificatePassword))]
    public static T ResetClientCertificatePassword<T>(this T o) where T : SonarScannerBeginSettings => o.Modify(b => b.Remove(() => o.ClientCertificatePassword));
    #endregion
}
#endregion
#region SonarScannerEndSettingsExtensions
/// <summary>Used within <see cref="SonarScannerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SonarScannerEndSettingsExtensions
{
    #region Login
    /// <inheritdoc cref="SonarScannerEndSettings.Login"/>
    [Pure] [Builder(Type = typeof(SonarScannerEndSettings), Property = nameof(SonarScannerEndSettings.Login))]
    public static T SetLogin<T>(this T o, [Secret] string v) where T : SonarScannerEndSettings => o.Modify(b => b.Set(() => o.Login, v));
    /// <inheritdoc cref="SonarScannerEndSettings.Login"/>
    [Pure] [Builder(Type = typeof(SonarScannerEndSettings), Property = nameof(SonarScannerEndSettings.Login))]
    public static T ResetLogin<T>(this T o) where T : SonarScannerEndSettings => o.Modify(b => b.Remove(() => o.Login));
    #endregion
    #region Password
    /// <inheritdoc cref="SonarScannerEndSettings.Password"/>
    [Pure] [Builder(Type = typeof(SonarScannerEndSettings), Property = nameof(SonarScannerEndSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : SonarScannerEndSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="SonarScannerEndSettings.Password"/>
    [Pure] [Builder(Type = typeof(SonarScannerEndSettings), Property = nameof(SonarScannerEndSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : SonarScannerEndSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Token
    /// <inheritdoc cref="SonarScannerEndSettings.Token"/>
    [Pure] [Builder(Type = typeof(SonarScannerEndSettings), Property = nameof(SonarScannerEndSettings.Token))]
    public static T SetToken<T>(this T o, [Secret] string v) where T : SonarScannerEndSettings => o.Modify(b => b.Set(() => o.Token, v));
    /// <inheritdoc cref="SonarScannerEndSettings.Token"/>
    [Pure] [Builder(Type = typeof(SonarScannerEndSettings), Property = nameof(SonarScannerEndSettings.Token))]
    public static T ResetToken<T>(this T o) where T : SonarScannerEndSettings => o.Modify(b => b.Remove(() => o.Token));
    #endregion
    #region ClientCertificatePassword
    /// <inheritdoc cref="SonarScannerEndSettings.ClientCertificatePassword"/>
    [Pure] [Builder(Type = typeof(SonarScannerEndSettings), Property = nameof(SonarScannerEndSettings.ClientCertificatePassword))]
    public static T SetClientCertificatePassword<T>(this T o, string v) where T : SonarScannerEndSettings => o.Modify(b => b.Set(() => o.ClientCertificatePassword, v));
    /// <inheritdoc cref="SonarScannerEndSettings.ClientCertificatePassword"/>
    [Pure] [Builder(Type = typeof(SonarScannerEndSettings), Property = nameof(SonarScannerEndSettings.ClientCertificatePassword))]
    public static T ResetClientCertificatePassword<T>(this T o) where T : SonarScannerEndSettings => o.Modify(b => b.Remove(() => o.ClientCertificatePassword));
    #endregion
}
#endregion
