// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/SpecFlow/SpecFlow.json

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

namespace Nuke.Common.Tools.SpecFlow;

/// <summary><p>Use SpecFlow to define, manage and automatically execute human-readable acceptance tests in .NET projects. Writing easily understandable tests is a cornerstone of the BDD paradigm and also helps build up a living documentation of your system.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class SpecFlowTasks : ToolTasks, IRequireNuGetPackage
{
    public static string SpecFlowPath => new SpecFlowTasks().GetToolPath();
    public const string PackageId = "SpecFlow";
    public const string PackageExecutable = "specflow.exe";
    /// <summary><p>Use SpecFlow to define, manage and automatically execute human-readable acceptance tests in .NET projects. Writing easily understandable tests is a cornerstone of the BDD paradigm and also helps build up a living documentation of your system.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> SpecFlow(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new SpecFlowTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>This report provides a formatted HTML report of a test execution. The report contains a summary about the executed tests and the result and also a detailed report for the individual scenario executions.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--FeatureLanguage</c> via <see cref="SpecFlowNUnitExecutionReportSettings.FeatureLanguage"/></li><li><c>--OutputFile</c> via <see cref="SpecFlowNUnitExecutionReportSettings.OutputFile"/></li><li><c>--ProjectFile</c> via <see cref="SpecFlowNUnitExecutionReportSettings.ProjectFile"/></li><li><c>--ProjectName</c> via <see cref="SpecFlowNUnitExecutionReportSettings.ProjectName"/></li><li><c>--testOutput</c> via <see cref="SpecFlowNUnitExecutionReportSettings.TestOutput"/></li><li><c>--xmlTestResult</c> via <see cref="SpecFlowNUnitExecutionReportSettings.XmlTestResult"/></li><li><c>--XsltFile</c> via <see cref="SpecFlowNUnitExecutionReportSettings.XsltFile"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowNUnitExecutionReport(SpecFlowNUnitExecutionReportSettings options = null) => new SpecFlowTasks().Run(options);
    /// <summary><p>This report provides a formatted HTML report of a test execution. The report contains a summary about the executed tests and the result and also a detailed report for the individual scenario executions.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--FeatureLanguage</c> via <see cref="SpecFlowNUnitExecutionReportSettings.FeatureLanguage"/></li><li><c>--OutputFile</c> via <see cref="SpecFlowNUnitExecutionReportSettings.OutputFile"/></li><li><c>--ProjectFile</c> via <see cref="SpecFlowNUnitExecutionReportSettings.ProjectFile"/></li><li><c>--ProjectName</c> via <see cref="SpecFlowNUnitExecutionReportSettings.ProjectName"/></li><li><c>--testOutput</c> via <see cref="SpecFlowNUnitExecutionReportSettings.TestOutput"/></li><li><c>--xmlTestResult</c> via <see cref="SpecFlowNUnitExecutionReportSettings.XmlTestResult"/></li><li><c>--XsltFile</c> via <see cref="SpecFlowNUnitExecutionReportSettings.XsltFile"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowNUnitExecutionReport(Configure<SpecFlowNUnitExecutionReportSettings> configurator) => new SpecFlowTasks().Run(configurator.Invoke(new SpecFlowNUnitExecutionReportSettings()));
    /// <summary><p>This report provides a formatted HTML report of a test execution. The report contains a summary about the executed tests and the result and also a detailed report for the individual scenario executions.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--FeatureLanguage</c> via <see cref="SpecFlowNUnitExecutionReportSettings.FeatureLanguage"/></li><li><c>--OutputFile</c> via <see cref="SpecFlowNUnitExecutionReportSettings.OutputFile"/></li><li><c>--ProjectFile</c> via <see cref="SpecFlowNUnitExecutionReportSettings.ProjectFile"/></li><li><c>--ProjectName</c> via <see cref="SpecFlowNUnitExecutionReportSettings.ProjectName"/></li><li><c>--testOutput</c> via <see cref="SpecFlowNUnitExecutionReportSettings.TestOutput"/></li><li><c>--xmlTestResult</c> via <see cref="SpecFlowNUnitExecutionReportSettings.XmlTestResult"/></li><li><c>--XsltFile</c> via <see cref="SpecFlowNUnitExecutionReportSettings.XsltFile"/></li></ul></remarks>
    public static IEnumerable<(SpecFlowNUnitExecutionReportSettings Settings, IReadOnlyCollection<Output> Output)> SpecFlowNUnitExecutionReport(CombinatorialConfigure<SpecFlowNUnitExecutionReportSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SpecFlowNUnitExecutionReport, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This report provides a formatted HTML report of a test execution. The report contains a summary about the executed tests and the result and also a detailed report for the individual scenario executions.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;projectFile&gt;</c> via <see cref="SpecFlowMSTestExecutionReportSettings.ProjectFile"/></li><li><c>/out</c> via <see cref="SpecFlowMSTestExecutionReportSettings.OutputFile"/></li><li><c>/testResult</c> via <see cref="SpecFlowMSTestExecutionReportSettings.TestResult"/></li><li><c>/xsltFile</c> via <see cref="SpecFlowMSTestExecutionReportSettings.XsltFile"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowMSTestExecutionReport(SpecFlowMSTestExecutionReportSettings options = null) => new SpecFlowTasks().Run(options);
    /// <summary><p>This report provides a formatted HTML report of a test execution. The report contains a summary about the executed tests and the result and also a detailed report for the individual scenario executions.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;projectFile&gt;</c> via <see cref="SpecFlowMSTestExecutionReportSettings.ProjectFile"/></li><li><c>/out</c> via <see cref="SpecFlowMSTestExecutionReportSettings.OutputFile"/></li><li><c>/testResult</c> via <see cref="SpecFlowMSTestExecutionReportSettings.TestResult"/></li><li><c>/xsltFile</c> via <see cref="SpecFlowMSTestExecutionReportSettings.XsltFile"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowMSTestExecutionReport(Configure<SpecFlowMSTestExecutionReportSettings> configurator) => new SpecFlowTasks().Run(configurator.Invoke(new SpecFlowMSTestExecutionReportSettings()));
    /// <summary><p>This report provides a formatted HTML report of a test execution. The report contains a summary about the executed tests and the result and also a detailed report for the individual scenario executions.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;projectFile&gt;</c> via <see cref="SpecFlowMSTestExecutionReportSettings.ProjectFile"/></li><li><c>/out</c> via <see cref="SpecFlowMSTestExecutionReportSettings.OutputFile"/></li><li><c>/testResult</c> via <see cref="SpecFlowMSTestExecutionReportSettings.TestResult"/></li><li><c>/xsltFile</c> via <see cref="SpecFlowMSTestExecutionReportSettings.XsltFile"/></li></ul></remarks>
    public static IEnumerable<(SpecFlowMSTestExecutionReportSettings Settings, IReadOnlyCollection<Output> Output)> SpecFlowMSTestExecutionReport(CombinatorialConfigure<SpecFlowMSTestExecutionReportSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SpecFlowMSTestExecutionReport, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This report shows the usage and binding status of the steps for the entire project. You can use this report to find both unused code in the automation layer and scenario steps that have no definition yet.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;projectFile&gt;</c> via <see cref="SpecFlowStepDefinitionReportSettings.ProjectFile"/></li><li><c>/out</c> via <see cref="SpecFlowStepDefinitionReportSettings.OutputFile"/></li><li><c>/testResult</c> via <see cref="SpecFlowStepDefinitionReportSettings.BinFolder"/></li><li><c>/xsltFile</c> via <see cref="SpecFlowStepDefinitionReportSettings.XsltFile"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowStepDefinitionReport(SpecFlowStepDefinitionReportSettings options = null) => new SpecFlowTasks().Run(options);
    /// <summary><p>This report shows the usage and binding status of the steps for the entire project. You can use this report to find both unused code in the automation layer and scenario steps that have no definition yet.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;projectFile&gt;</c> via <see cref="SpecFlowStepDefinitionReportSettings.ProjectFile"/></li><li><c>/out</c> via <see cref="SpecFlowStepDefinitionReportSettings.OutputFile"/></li><li><c>/testResult</c> via <see cref="SpecFlowStepDefinitionReportSettings.BinFolder"/></li><li><c>/xsltFile</c> via <see cref="SpecFlowStepDefinitionReportSettings.XsltFile"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowStepDefinitionReport(Configure<SpecFlowStepDefinitionReportSettings> configurator) => new SpecFlowTasks().Run(configurator.Invoke(new SpecFlowStepDefinitionReportSettings()));
    /// <summary><p>This report shows the usage and binding status of the steps for the entire project. You can use this report to find both unused code in the automation layer and scenario steps that have no definition yet.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;projectFile&gt;</c> via <see cref="SpecFlowStepDefinitionReportSettings.ProjectFile"/></li><li><c>/out</c> via <see cref="SpecFlowStepDefinitionReportSettings.OutputFile"/></li><li><c>/testResult</c> via <see cref="SpecFlowStepDefinitionReportSettings.BinFolder"/></li><li><c>/xsltFile</c> via <see cref="SpecFlowStepDefinitionReportSettings.XsltFile"/></li></ul></remarks>
    public static IEnumerable<(SpecFlowStepDefinitionReportSettings Settings, IReadOnlyCollection<Output> Output)> SpecFlowStepDefinitionReport(CombinatorialConfigure<SpecFlowStepDefinitionReportSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SpecFlowStepDefinitionReport, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Use <c>SpecRun.exe run</c> to execute your tests.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/basefolder</c> via <see cref="SpecFlowRunSettings.BaseFolder"/></li><li><c>/debug</c> via <see cref="SpecFlowRunSettings.Debug"/></li><li><c>/filter</c> via <see cref="SpecFlowRunSettings.Filter"/></li><li><c>/log</c> via <see cref="SpecFlowRunSettings.LogFile"/></li><li><c>/outputfolder</c> via <see cref="SpecFlowRunSettings.OutputFolder"/></li><li><c>/report</c> via <see cref="SpecFlowRunSettings.ReportFile"/></li><li><c>/toolIntegration</c> via <see cref="SpecFlowRunSettings.ToolIntegration"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowRun(SpecFlowRunSettings options = null) => new SpecFlowTasks().Run(options);
    /// <summary><p>Use <c>SpecRun.exe run</c> to execute your tests.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/basefolder</c> via <see cref="SpecFlowRunSettings.BaseFolder"/></li><li><c>/debug</c> via <see cref="SpecFlowRunSettings.Debug"/></li><li><c>/filter</c> via <see cref="SpecFlowRunSettings.Filter"/></li><li><c>/log</c> via <see cref="SpecFlowRunSettings.LogFile"/></li><li><c>/outputfolder</c> via <see cref="SpecFlowRunSettings.OutputFolder"/></li><li><c>/report</c> via <see cref="SpecFlowRunSettings.ReportFile"/></li><li><c>/toolIntegration</c> via <see cref="SpecFlowRunSettings.ToolIntegration"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowRun(Configure<SpecFlowRunSettings> configurator) => new SpecFlowTasks().Run(configurator.Invoke(new SpecFlowRunSettings()));
    /// <summary><p>Use <c>SpecRun.exe run</c> to execute your tests.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>/basefolder</c> via <see cref="SpecFlowRunSettings.BaseFolder"/></li><li><c>/debug</c> via <see cref="SpecFlowRunSettings.Debug"/></li><li><c>/filter</c> via <see cref="SpecFlowRunSettings.Filter"/></li><li><c>/log</c> via <see cref="SpecFlowRunSettings.LogFile"/></li><li><c>/outputfolder</c> via <see cref="SpecFlowRunSettings.OutputFolder"/></li><li><c>/report</c> via <see cref="SpecFlowRunSettings.ReportFile"/></li><li><c>/toolIntegration</c> via <see cref="SpecFlowRunSettings.ToolIntegration"/></li></ul></remarks>
    public static IEnumerable<(SpecFlowRunSettings Settings, IReadOnlyCollection<Output> Output)> SpecFlowRun(CombinatorialConfigure<SpecFlowRunSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SpecFlowRun, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Use <c>SpecRun.exe buildserverrun</c> to execute your tests in build server mode.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;target&gt;</c> via <see cref="SpecFlowBuildServerRunSettings.Target"/></li><li><c>/basefolder</c> via <see cref="SpecFlowBuildServerRunSettings.BaseFolder"/></li><li><c>/buildserver</c> via <see cref="SpecFlowBuildServerRunSettings.BuildServerName"/></li><li><c>/filter</c> via <see cref="SpecFlowBuildServerRunSettings.Filter"/></li><li><c>/log</c> via <see cref="SpecFlowBuildServerRunSettings.LogFile"/></li><li><c>/outputfolder</c> via <see cref="SpecFlowBuildServerRunSettings.OutputFolder"/></li><li><c>/report</c> via <see cref="SpecFlowBuildServerRunSettings.ReportFile"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowBuildServerRun(SpecFlowBuildServerRunSettings options = null) => new SpecFlowTasks().Run(options);
    /// <summary><p>Use <c>SpecRun.exe buildserverrun</c> to execute your tests in build server mode.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;target&gt;</c> via <see cref="SpecFlowBuildServerRunSettings.Target"/></li><li><c>/basefolder</c> via <see cref="SpecFlowBuildServerRunSettings.BaseFolder"/></li><li><c>/buildserver</c> via <see cref="SpecFlowBuildServerRunSettings.BuildServerName"/></li><li><c>/filter</c> via <see cref="SpecFlowBuildServerRunSettings.Filter"/></li><li><c>/log</c> via <see cref="SpecFlowBuildServerRunSettings.LogFile"/></li><li><c>/outputfolder</c> via <see cref="SpecFlowBuildServerRunSettings.OutputFolder"/></li><li><c>/report</c> via <see cref="SpecFlowBuildServerRunSettings.ReportFile"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowBuildServerRun(Configure<SpecFlowBuildServerRunSettings> configurator) => new SpecFlowTasks().Run(configurator.Invoke(new SpecFlowBuildServerRunSettings()));
    /// <summary><p>Use <c>SpecRun.exe buildserverrun</c> to execute your tests in build server mode.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;target&gt;</c> via <see cref="SpecFlowBuildServerRunSettings.Target"/></li><li><c>/basefolder</c> via <see cref="SpecFlowBuildServerRunSettings.BaseFolder"/></li><li><c>/buildserver</c> via <see cref="SpecFlowBuildServerRunSettings.BuildServerName"/></li><li><c>/filter</c> via <see cref="SpecFlowBuildServerRunSettings.Filter"/></li><li><c>/log</c> via <see cref="SpecFlowBuildServerRunSettings.LogFile"/></li><li><c>/outputfolder</c> via <see cref="SpecFlowBuildServerRunSettings.OutputFolder"/></li><li><c>/report</c> via <see cref="SpecFlowBuildServerRunSettings.ReportFile"/></li></ul></remarks>
    public static IEnumerable<(SpecFlowBuildServerRunSettings Settings, IReadOnlyCollection<Output> Output)> SpecFlowBuildServerRun(CombinatorialConfigure<SpecFlowBuildServerRunSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SpecFlowBuildServerRun, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Use <c>SpecRun.exe register</c> to register your SpecFlow+ license. You only need to register your license once per user per machine. The license is valid for all SpecFlow+ components.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;issuedTo&gt;</c> via <see cref="SpecFlowRegisterSettings.IssuedTo"/></li><li><c>&lt;licenseKey&gt;</c> via <see cref="SpecFlowRegisterSettings.LicenseKey"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowRegister(SpecFlowRegisterSettings options = null) => new SpecFlowTasks().Run(options);
    /// <summary><p>Use <c>SpecRun.exe register</c> to register your SpecFlow+ license. You only need to register your license once per user per machine. The license is valid for all SpecFlow+ components.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;issuedTo&gt;</c> via <see cref="SpecFlowRegisterSettings.IssuedTo"/></li><li><c>&lt;licenseKey&gt;</c> via <see cref="SpecFlowRegisterSettings.LicenseKey"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SpecFlowRegister(Configure<SpecFlowRegisterSettings> configurator) => new SpecFlowTasks().Run(configurator.Invoke(new SpecFlowRegisterSettings()));
    /// <summary><p>Use <c>SpecRun.exe register</c> to register your SpecFlow+ license. You only need to register your license once per user per machine. The license is valid for all SpecFlow+ components.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;issuedTo&gt;</c> via <see cref="SpecFlowRegisterSettings.IssuedTo"/></li><li><c>&lt;licenseKey&gt;</c> via <see cref="SpecFlowRegisterSettings.LicenseKey"/></li></ul></remarks>
    public static IEnumerable<(SpecFlowRegisterSettings Settings, IReadOnlyCollection<Output> Output)> SpecFlowRegister(CombinatorialConfigure<SpecFlowRegisterSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SpecFlowRegister, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Use <c>SpecRun.exe unregister</c> to unregister your SpecFlow+ license.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p></remarks>
    public static IReadOnlyCollection<Output> SpecFlowUnregister(SpecFlowUnregisterSettings options = null) => new SpecFlowTasks().Run(options);
    /// <summary><p>Use <c>SpecRun.exe unregister</c> to unregister your SpecFlow+ license.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p></remarks>
    public static IReadOnlyCollection<Output> SpecFlowUnregister(Configure<SpecFlowUnregisterSettings> configurator) => new SpecFlowTasks().Run(configurator.Invoke(new SpecFlowUnregisterSettings()));
    /// <summary><p>Use <c>SpecRun.exe unregister</c> to unregister your SpecFlow+ license.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p></remarks>
    public static IEnumerable<(SpecFlowUnregisterSettings Settings, IReadOnlyCollection<Output> Output)> SpecFlowUnregister(CombinatorialConfigure<SpecFlowUnregisterSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SpecFlowUnregister, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Use <c>SpecRun.exe about</c> to display information such as your version number, build date and license information (licensee, upgrade until date/expiry date).</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p></remarks>
    public static IReadOnlyCollection<Output> SpecFlowAbout(SpecFlowAboutSettings options = null) => new SpecFlowTasks().Run(options);
    /// <summary><p>Use <c>SpecRun.exe about</c> to display information such as your version number, build date and license information (licensee, upgrade until date/expiry date).</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p></remarks>
    public static IReadOnlyCollection<Output> SpecFlowAbout(Configure<SpecFlowAboutSettings> configurator) => new SpecFlowTasks().Run(configurator.Invoke(new SpecFlowAboutSettings()));
    /// <summary><p>Use <c>SpecRun.exe about</c> to display information such as your version number, build date and license information (licensee, upgrade until date/expiry date).</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p></remarks>
    public static IEnumerable<(SpecFlowAboutSettings Settings, IReadOnlyCollection<Output> Output)> SpecFlowAbout(CombinatorialConfigure<SpecFlowAboutSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SpecFlowAbout, degreeOfParallelism, completeOnFailure);
}
#region SpecFlowNUnitExecutionReportSettings
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SpecFlowNUnitExecutionReportSettings>))]
[Command(Type = typeof(SpecFlowTasks), Command = nameof(SpecFlowTasks.SpecFlowNUnitExecutionReport), Arguments = "nunitexecutionreport")]
public partial class SpecFlowNUnitExecutionReportSettings : ToolOptions
{
    /// <summary>A path of the project file containing the *.feature files. Required.</summary>
    [Argument(Format = "--ProjectFile {value}")] public string ProjectFile => Get<string>(() => ProjectFile);
    /// <summary>The XML test result file generated by nunit-console. Optional. Default: TestResult.xml.</summary>
    [Argument(Format = "--xmlTestResult {value}")] public string XmlTestResult => Get<string>(() => XmlTestResult);
    /// <summary>The labeled test output file generated by nunit-console. Optional. Default: TestResult.txt.</summary>
    [Argument(Format = "--testOutput {value}")] public string TestOutput => Get<string>(() => TestOutput);
    /// <summary>Generated Output File. Optional. Default: TestResult.html.</summary>
    [Argument(Format = "--OutputFile {value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</summary>
    [Argument(Format = "--XsltFile {value}")] public string XsltFile => Get<string>(() => XsltFile);
    /// <summary>Project name which can be passed explicitly instead of implicitly getting it from --ProjectFile. Optional. Default: not specified.</summary>
    [Argument(Format = "--ProjectName {value}")] public string ProjectName => Get<string>(() => ProjectName);
    /// <summary>The feature language to use. Optional. Default: en-US.</summary>
    [Argument(Format = "--FeatureLanguage {value}")] public string FeatureLanguage => Get<string>(() => FeatureLanguage);
}
#endregion
#region SpecFlowMSTestExecutionReportSettings
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SpecFlowMSTestExecutionReportSettings>))]
[Command(Type = typeof(SpecFlowTasks), Command = nameof(SpecFlowTasks.SpecFlowMSTestExecutionReport), Arguments = "mstestexecutionreport")]
public partial class SpecFlowMSTestExecutionReportSettings : ToolOptions
{
    /// <summary>A path of the project file containing the *.feature files. Required.</summary>
    [Argument(Format = "{value}", Position = 1)] public string ProjectFile => Get<string>(() => ProjectFile);
    /// <summary>The TRX test result file generated by MsTest. Optional. Default: TestResult.trx</summary>
    [Argument(Format = "/testResult {value}")] public string TestResult => Get<string>(() => TestResult);
    /// <summary>Generated Output File. Optional. Default: TestResult.html</summary>
    [Argument(Format = "/out {value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</summary>
    [Argument(Format = "/xsltFile {value}")] public string XsltFile => Get<string>(() => XsltFile);
}
#endregion
#region SpecFlowStepDefinitionReportSettings
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SpecFlowStepDefinitionReportSettings>))]
[Command(Type = typeof(SpecFlowTasks), Command = nameof(SpecFlowTasks.SpecFlowStepDefinitionReport), Arguments = "stepdefinitionreport")]
public partial class SpecFlowStepDefinitionReportSettings : ToolOptions
{
    /// <summary>A path of the project file containing the *.feature files. Required.</summary>
    [Argument(Format = "{value}", Position = 1)] public string ProjectFile => Get<string>(() => ProjectFile);
    /// <summary>A path for the compiled SpecFlow project. Optional. Default: bin/debug</summary>
    [Argument(Format = "/testResult {value}")] public string BinFolder => Get<string>(() => BinFolder);
    /// <summary>Generated Output File. Optional. Default: TestResult.html</summary>
    [Argument(Format = "/out {value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</summary>
    [Argument(Format = "/xsltFile {value}")] public string XsltFile => Get<string>(() => XsltFile);
}
#endregion
#region SpecFlowRunSettings
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SpecFlowRunSettings>))]
[Command(Type = typeof(SpecFlowTasks), Command = nameof(SpecFlowTasks.SpecFlowRun), Arguments = "run")]
public partial class SpecFlowRunSettings : ToolOptions
{
    /// <summary>Supported values: <c>None, VS2010, VS2012, VS2013, TeamCity, TFS</c>.</summary>
    [Argument(Format = "/toolIntegration:{value}")] public SpecFlowToolIntegration ToolIntegration => Get<SpecFlowToolIntegration>(() => ToolIntegration);
    /// <summary>Default: false.</summary>
    [Argument(Format = "/debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Specifies the base folder for executing tests. All paths are relative to this path.<para>If you have specified an <b>assembly</b> as your <c>target</c> you need to define the base folder as the path to the directory containing your assembly.</para><para>If you have specified a <b>test profile</b> (.srprofile) as your target, this overrides the <c>baseFolder</c> entry in your <c>.srprofile</c> file.</para></summary>
    [Argument(Format = "/basefolder:{value}")] public string BaseFolder => Get<string>(() => BaseFolder);
    /// <summary>Specifies the output folder for your logs and report file. All paths are relative to this path. If you have specified a test profile (.srprofile) as your target, this value overrides the <c>outputFolder</c> entry in your <c>.srprofile</c> file.<para>If no output folder is defined in your test profile, or your <c>target</c> is an assembly,  the output folder defaults to the base folder if not specified from the command line.</para></summary>
    [Argument(Format = "/outputfolder:{value}")] public string OutputFolder => Get<string>(() => OutputFolder);
    /// <summary>Specifies the target log file. This path is relative to your output folder.</summary>
    [Argument(Format = "/log:{value}")] public string LogFile => Get<string>(() => LogFile);
    /// <summary>Specifies the target report file. This path is relative to your output folder.<para><b>Note:</b>This option only affects the name of the report file defined in the <li>&lt;Settings&gt;</li> section of your profile. It does not affect the reports defined in the <li>&lt;Report&gt;</li>; section; to change the name of the report file for these reports, use the <c>outputName</c> attribute instead.</para></summary>
    [Argument(Format = "/report:{value}")] public string ReportFile => Get<string>(() => ReportFile);
    /// <summary>Applies a filter to your tests and only executes those that match your expression. This overrides the <c>filter</c> entry in your <c>.srprofile</c> file. An overview of the syntax can be found <a href="https://specflow.org/plus/documentation/Filter/">here</a>.</summary>
    [Argument(Format = "/filter:{value}")] public string Filter => Get<string>(() => Filter);
}
#endregion
#region SpecFlowBuildServerRunSettings
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SpecFlowBuildServerRunSettings>))]
[Command(Type = typeof(SpecFlowTasks), Command = nameof(SpecFlowTasks.SpecFlowBuildServerRun), Arguments = "buildserverrun")]
public partial class SpecFlowBuildServerRunSettings : ToolOptions
{
    /// <summary>The assembly or test profile (<c>.srprofile</c> file) to be tested.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Target => Get<string>(() => Target);
    /// <summary>The build servers' product name (TFS, TeamCity) for specialised trace output.</summary>
    [Argument(Format = "/buildserver:{value}")] public string BuildServerName => Get<string>(() => BuildServerName);
    /// <summary>Specifies the base folder for executing tests. All paths are relative to this path.<para>If you have specified an <b>assembly</b> as your <c>target</c> you need to define the base folder as the path to the directory containing your assembly.</para><para>If you have specified a <b>test profile</b> (.srprofile) as your target, this overrides the <c>baseFolder</c> entry in your <c>.srprofile</c> file.</para></summary>
    [Argument(Format = "/basefolder:{value}")] public string BaseFolder => Get<string>(() => BaseFolder);
    /// <summary>Specifies the output folder for your logs and report file. All paths are relative to this path. If you have specified a test profile (.srprofile) as your target, this value overrides the <c>outputFolder</c> entry in your <c>.srprofile</c> file.<para>If no output folder is defined in your test profile, or your <c>target</c> is an assembly,  the output folder defaults to the base folder if not specified from the command line.</para></summary>
    [Argument(Format = "/outputfolder:{value}")] public string OutputFolder => Get<string>(() => OutputFolder);
    /// <summary>Specifies the target log file. This path is relative to your output folder.</summary>
    [Argument(Format = "/log:{value}")] public string LogFile => Get<string>(() => LogFile);
    /// <summary>Specifies the target report file. This path is relative to your output folder.<para><b>Note:</b>This option only affects the name of the report file defined in the <li>&lt;Settings&gt;</li> section of your profile. It does not affect the reports defined in the <li>&lt;Report&gt;</li>; section; to change the name of the report file for these reports, use the <c>outputName</c> attribute instead.</para></summary>
    [Argument(Format = "/report:{value}")] public string ReportFile => Get<string>(() => ReportFile);
    /// <summary>Applies a filter to your tests and only executes those that match your expression. This overrides the <c>filter</c> entry in your <c>.srprofile</c> file. An overview of the syntax can be found <a href="https://specflow.org/plus/documentation/Filter/">here</a>.</summary>
    [Argument(Format = "/filter:{value}")] public string Filter => Get<string>(() => Filter);
}
#endregion
#region SpecFlowRegisterSettings
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SpecFlowRegisterSettings>))]
[Command(Type = typeof(SpecFlowTasks), Command = nameof(SpecFlowTasks.SpecFlowRegister), Arguments = "register")]
public partial class SpecFlowRegisterSettings : ToolOptions
{
    /// <summary>The license key you received when you purchased SpecFlow+.</summary>
    [Argument(Format = "{value}", Position = 1, Secret = true)] public string LicenseKey => Get<string>(() => LicenseKey);
    /// <summary>The name of the licensee. If you purchased your SpecFlow+ license online via SWREG, this is the email address you used to purchase the license. If you purchased SpecFlow+ directly from TechTalk, this is the value in the email you received containing your license information.</summary>
    [Argument(Format = "{value}", Position = 2)] public string IssuedTo => Get<string>(() => IssuedTo);
}
#endregion
#region SpecFlowUnregisterSettings
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SpecFlowUnregisterSettings>))]
[Command(Type = typeof(SpecFlowTasks), Command = nameof(SpecFlowTasks.SpecFlowUnregister), Arguments = "register")]
public partial class SpecFlowUnregisterSettings : ToolOptions
{
}
#endregion
#region SpecFlowAboutSettings
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SpecFlowAboutSettings>))]
[Command(Type = typeof(SpecFlowTasks), Command = nameof(SpecFlowTasks.SpecFlowAbout), Arguments = "register")]
public partial class SpecFlowAboutSettings : ToolOptions
{
}
#endregion
#region SpecFlowNUnitExecutionReportSettingsExtensions
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SpecFlowNUnitExecutionReportSettingsExtensions
{
    #region ProjectFile
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.ProjectFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.ProjectFile))]
    public static T SetProjectFile<T>(this T o, string v) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Set(() => o.ProjectFile, v));
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.ProjectFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.ProjectFile))]
    public static T ResetProjectFile<T>(this T o) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Remove(() => o.ProjectFile));
    #endregion
    #region XmlTestResult
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.XmlTestResult"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.XmlTestResult))]
    public static T SetXmlTestResult<T>(this T o, string v) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Set(() => o.XmlTestResult, v));
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.XmlTestResult"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.XmlTestResult))]
    public static T ResetXmlTestResult<T>(this T o) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Remove(() => o.XmlTestResult));
    #endregion
    #region TestOutput
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.TestOutput"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.TestOutput))]
    public static T SetTestOutput<T>(this T o, string v) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Set(() => o.TestOutput, v));
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.TestOutput"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.TestOutput))]
    public static T ResetTestOutput<T>(this T o) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Remove(() => o.TestOutput));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region XsltFile
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.XsltFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.XsltFile))]
    public static T SetXsltFile<T>(this T o, string v) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Set(() => o.XsltFile, v));
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.XsltFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.XsltFile))]
    public static T ResetXsltFile<T>(this T o) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Remove(() => o.XsltFile));
    #endregion
    #region ProjectName
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.ProjectName"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.ProjectName))]
    public static T SetProjectName<T>(this T o, string v) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Set(() => o.ProjectName, v));
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.ProjectName"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.ProjectName))]
    public static T ResetProjectName<T>(this T o) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Remove(() => o.ProjectName));
    #endregion
    #region FeatureLanguage
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.FeatureLanguage"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.FeatureLanguage))]
    public static T SetFeatureLanguage<T>(this T o, string v) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Set(() => o.FeatureLanguage, v));
    /// <inheritdoc cref="SpecFlowNUnitExecutionReportSettings.FeatureLanguage"/>
    [Pure] [Builder(Type = typeof(SpecFlowNUnitExecutionReportSettings), Property = nameof(SpecFlowNUnitExecutionReportSettings.FeatureLanguage))]
    public static T ResetFeatureLanguage<T>(this T o) where T : SpecFlowNUnitExecutionReportSettings => o.Modify(b => b.Remove(() => o.FeatureLanguage));
    #endregion
}
#endregion
#region SpecFlowMSTestExecutionReportSettingsExtensions
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SpecFlowMSTestExecutionReportSettingsExtensions
{
    #region ProjectFile
    /// <inheritdoc cref="SpecFlowMSTestExecutionReportSettings.ProjectFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowMSTestExecutionReportSettings), Property = nameof(SpecFlowMSTestExecutionReportSettings.ProjectFile))]
    public static T SetProjectFile<T>(this T o, string v) where T : SpecFlowMSTestExecutionReportSettings => o.Modify(b => b.Set(() => o.ProjectFile, v));
    /// <inheritdoc cref="SpecFlowMSTestExecutionReportSettings.ProjectFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowMSTestExecutionReportSettings), Property = nameof(SpecFlowMSTestExecutionReportSettings.ProjectFile))]
    public static T ResetProjectFile<T>(this T o) where T : SpecFlowMSTestExecutionReportSettings => o.Modify(b => b.Remove(() => o.ProjectFile));
    #endregion
    #region TestResult
    /// <inheritdoc cref="SpecFlowMSTestExecutionReportSettings.TestResult"/>
    [Pure] [Builder(Type = typeof(SpecFlowMSTestExecutionReportSettings), Property = nameof(SpecFlowMSTestExecutionReportSettings.TestResult))]
    public static T SetTestResult<T>(this T o, string v) where T : SpecFlowMSTestExecutionReportSettings => o.Modify(b => b.Set(() => o.TestResult, v));
    /// <inheritdoc cref="SpecFlowMSTestExecutionReportSettings.TestResult"/>
    [Pure] [Builder(Type = typeof(SpecFlowMSTestExecutionReportSettings), Property = nameof(SpecFlowMSTestExecutionReportSettings.TestResult))]
    public static T ResetTestResult<T>(this T o) where T : SpecFlowMSTestExecutionReportSettings => o.Modify(b => b.Remove(() => o.TestResult));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="SpecFlowMSTestExecutionReportSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowMSTestExecutionReportSettings), Property = nameof(SpecFlowMSTestExecutionReportSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : SpecFlowMSTestExecutionReportSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="SpecFlowMSTestExecutionReportSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowMSTestExecutionReportSettings), Property = nameof(SpecFlowMSTestExecutionReportSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : SpecFlowMSTestExecutionReportSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region XsltFile
    /// <inheritdoc cref="SpecFlowMSTestExecutionReportSettings.XsltFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowMSTestExecutionReportSettings), Property = nameof(SpecFlowMSTestExecutionReportSettings.XsltFile))]
    public static T SetXsltFile<T>(this T o, string v) where T : SpecFlowMSTestExecutionReportSettings => o.Modify(b => b.Set(() => o.XsltFile, v));
    /// <inheritdoc cref="SpecFlowMSTestExecutionReportSettings.XsltFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowMSTestExecutionReportSettings), Property = nameof(SpecFlowMSTestExecutionReportSettings.XsltFile))]
    public static T ResetXsltFile<T>(this T o) where T : SpecFlowMSTestExecutionReportSettings => o.Modify(b => b.Remove(() => o.XsltFile));
    #endregion
}
#endregion
#region SpecFlowStepDefinitionReportSettingsExtensions
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SpecFlowStepDefinitionReportSettingsExtensions
{
    #region ProjectFile
    /// <inheritdoc cref="SpecFlowStepDefinitionReportSettings.ProjectFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowStepDefinitionReportSettings), Property = nameof(SpecFlowStepDefinitionReportSettings.ProjectFile))]
    public static T SetProjectFile<T>(this T o, string v) where T : SpecFlowStepDefinitionReportSettings => o.Modify(b => b.Set(() => o.ProjectFile, v));
    /// <inheritdoc cref="SpecFlowStepDefinitionReportSettings.ProjectFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowStepDefinitionReportSettings), Property = nameof(SpecFlowStepDefinitionReportSettings.ProjectFile))]
    public static T ResetProjectFile<T>(this T o) where T : SpecFlowStepDefinitionReportSettings => o.Modify(b => b.Remove(() => o.ProjectFile));
    #endregion
    #region BinFolder
    /// <inheritdoc cref="SpecFlowStepDefinitionReportSettings.BinFolder"/>
    [Pure] [Builder(Type = typeof(SpecFlowStepDefinitionReportSettings), Property = nameof(SpecFlowStepDefinitionReportSettings.BinFolder))]
    public static T SetBinFolder<T>(this T o, string v) where T : SpecFlowStepDefinitionReportSettings => o.Modify(b => b.Set(() => o.BinFolder, v));
    /// <inheritdoc cref="SpecFlowStepDefinitionReportSettings.BinFolder"/>
    [Pure] [Builder(Type = typeof(SpecFlowStepDefinitionReportSettings), Property = nameof(SpecFlowStepDefinitionReportSettings.BinFolder))]
    public static T ResetBinFolder<T>(this T o) where T : SpecFlowStepDefinitionReportSettings => o.Modify(b => b.Remove(() => o.BinFolder));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="SpecFlowStepDefinitionReportSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowStepDefinitionReportSettings), Property = nameof(SpecFlowStepDefinitionReportSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : SpecFlowStepDefinitionReportSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="SpecFlowStepDefinitionReportSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowStepDefinitionReportSettings), Property = nameof(SpecFlowStepDefinitionReportSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : SpecFlowStepDefinitionReportSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region XsltFile
    /// <inheritdoc cref="SpecFlowStepDefinitionReportSettings.XsltFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowStepDefinitionReportSettings), Property = nameof(SpecFlowStepDefinitionReportSettings.XsltFile))]
    public static T SetXsltFile<T>(this T o, string v) where T : SpecFlowStepDefinitionReportSettings => o.Modify(b => b.Set(() => o.XsltFile, v));
    /// <inheritdoc cref="SpecFlowStepDefinitionReportSettings.XsltFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowStepDefinitionReportSettings), Property = nameof(SpecFlowStepDefinitionReportSettings.XsltFile))]
    public static T ResetXsltFile<T>(this T o) where T : SpecFlowStepDefinitionReportSettings => o.Modify(b => b.Remove(() => o.XsltFile));
    #endregion
}
#endregion
#region SpecFlowRunSettingsExtensions
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SpecFlowRunSettingsExtensions
{
    #region ToolIntegration
    /// <inheritdoc cref="SpecFlowRunSettings.ToolIntegration"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.ToolIntegration))]
    public static T SetToolIntegration<T>(this T o, SpecFlowToolIntegration v) where T : SpecFlowRunSettings => o.Modify(b => b.Set(() => o.ToolIntegration, v));
    /// <inheritdoc cref="SpecFlowRunSettings.ToolIntegration"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.ToolIntegration))]
    public static T ResetToolIntegration<T>(this T o) where T : SpecFlowRunSettings => o.Modify(b => b.Remove(() => o.ToolIntegration));
    #endregion
    #region Debug
    /// <inheritdoc cref="SpecFlowRunSettings.Debug"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : SpecFlowRunSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="SpecFlowRunSettings.Debug"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : SpecFlowRunSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="SpecFlowRunSettings.Debug"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : SpecFlowRunSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="SpecFlowRunSettings.Debug"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : SpecFlowRunSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="SpecFlowRunSettings.Debug"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : SpecFlowRunSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region BaseFolder
    /// <inheritdoc cref="SpecFlowRunSettings.BaseFolder"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.BaseFolder))]
    public static T SetBaseFolder<T>(this T o, string v) where T : SpecFlowRunSettings => o.Modify(b => b.Set(() => o.BaseFolder, v));
    /// <inheritdoc cref="SpecFlowRunSettings.BaseFolder"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.BaseFolder))]
    public static T ResetBaseFolder<T>(this T o) where T : SpecFlowRunSettings => o.Modify(b => b.Remove(() => o.BaseFolder));
    #endregion
    #region OutputFolder
    /// <inheritdoc cref="SpecFlowRunSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.OutputFolder))]
    public static T SetOutputFolder<T>(this T o, string v) where T : SpecFlowRunSettings => o.Modify(b => b.Set(() => o.OutputFolder, v));
    /// <inheritdoc cref="SpecFlowRunSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.OutputFolder))]
    public static T ResetOutputFolder<T>(this T o) where T : SpecFlowRunSettings => o.Modify(b => b.Remove(() => o.OutputFolder));
    #endregion
    #region LogFile
    /// <inheritdoc cref="SpecFlowRunSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : SpecFlowRunSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="SpecFlowRunSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : SpecFlowRunSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
    #region ReportFile
    /// <inheritdoc cref="SpecFlowRunSettings.ReportFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.ReportFile))]
    public static T SetReportFile<T>(this T o, string v) where T : SpecFlowRunSettings => o.Modify(b => b.Set(() => o.ReportFile, v));
    /// <inheritdoc cref="SpecFlowRunSettings.ReportFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.ReportFile))]
    public static T ResetReportFile<T>(this T o) where T : SpecFlowRunSettings => o.Modify(b => b.Remove(() => o.ReportFile));
    #endregion
    #region Filter
    /// <inheritdoc cref="SpecFlowRunSettings.Filter"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.Filter))]
    public static T SetFilter<T>(this T o, string v) where T : SpecFlowRunSettings => o.Modify(b => b.Set(() => o.Filter, v));
    /// <inheritdoc cref="SpecFlowRunSettings.Filter"/>
    [Pure] [Builder(Type = typeof(SpecFlowRunSettings), Property = nameof(SpecFlowRunSettings.Filter))]
    public static T ResetFilter<T>(this T o) where T : SpecFlowRunSettings => o.Modify(b => b.Remove(() => o.Filter));
    #endregion
}
#endregion
#region SpecFlowBuildServerRunSettingsExtensions
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SpecFlowBuildServerRunSettingsExtensions
{
    #region Target
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.Target"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.Target))]
    public static T SetTarget<T>(this T o, string v) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Set(() => o.Target, v));
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.Target"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.Target))]
    public static T ResetTarget<T>(this T o) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Remove(() => o.Target));
    #endregion
    #region BuildServerName
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.BuildServerName"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.BuildServerName))]
    public static T SetBuildServerName<T>(this T o, string v) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Set(() => o.BuildServerName, v));
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.BuildServerName"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.BuildServerName))]
    public static T ResetBuildServerName<T>(this T o) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Remove(() => o.BuildServerName));
    #endregion
    #region BaseFolder
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.BaseFolder"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.BaseFolder))]
    public static T SetBaseFolder<T>(this T o, string v) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Set(() => o.BaseFolder, v));
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.BaseFolder"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.BaseFolder))]
    public static T ResetBaseFolder<T>(this T o) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Remove(() => o.BaseFolder));
    #endregion
    #region OutputFolder
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.OutputFolder))]
    public static T SetOutputFolder<T>(this T o, string v) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Set(() => o.OutputFolder, v));
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.OutputFolder))]
    public static T ResetOutputFolder<T>(this T o) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Remove(() => o.OutputFolder));
    #endregion
    #region LogFile
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
    #region ReportFile
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.ReportFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.ReportFile))]
    public static T SetReportFile<T>(this T o, string v) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Set(() => o.ReportFile, v));
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.ReportFile"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.ReportFile))]
    public static T ResetReportFile<T>(this T o) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Remove(() => o.ReportFile));
    #endregion
    #region Filter
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.Filter"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.Filter))]
    public static T SetFilter<T>(this T o, string v) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Set(() => o.Filter, v));
    /// <inheritdoc cref="SpecFlowBuildServerRunSettings.Filter"/>
    [Pure] [Builder(Type = typeof(SpecFlowBuildServerRunSettings), Property = nameof(SpecFlowBuildServerRunSettings.Filter))]
    public static T ResetFilter<T>(this T o) where T : SpecFlowBuildServerRunSettings => o.Modify(b => b.Remove(() => o.Filter));
    #endregion
}
#endregion
#region SpecFlowRegisterSettingsExtensions
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SpecFlowRegisterSettingsExtensions
{
    #region LicenseKey
    /// <inheritdoc cref="SpecFlowRegisterSettings.LicenseKey"/>
    [Pure] [Builder(Type = typeof(SpecFlowRegisterSettings), Property = nameof(SpecFlowRegisterSettings.LicenseKey))]
    public static T SetLicenseKey<T>(this T o, [Secret] string v) where T : SpecFlowRegisterSettings => o.Modify(b => b.Set(() => o.LicenseKey, v));
    /// <inheritdoc cref="SpecFlowRegisterSettings.LicenseKey"/>
    [Pure] [Builder(Type = typeof(SpecFlowRegisterSettings), Property = nameof(SpecFlowRegisterSettings.LicenseKey))]
    public static T ResetLicenseKey<T>(this T o) where T : SpecFlowRegisterSettings => o.Modify(b => b.Remove(() => o.LicenseKey));
    #endregion
    #region IssuedTo
    /// <inheritdoc cref="SpecFlowRegisterSettings.IssuedTo"/>
    [Pure] [Builder(Type = typeof(SpecFlowRegisterSettings), Property = nameof(SpecFlowRegisterSettings.IssuedTo))]
    public static T SetIssuedTo<T>(this T o, string v) where T : SpecFlowRegisterSettings => o.Modify(b => b.Set(() => o.IssuedTo, v));
    /// <inheritdoc cref="SpecFlowRegisterSettings.IssuedTo"/>
    [Pure] [Builder(Type = typeof(SpecFlowRegisterSettings), Property = nameof(SpecFlowRegisterSettings.IssuedTo))]
    public static T ResetIssuedTo<T>(this T o) where T : SpecFlowRegisterSettings => o.Modify(b => b.Remove(() => o.IssuedTo));
    #endregion
}
#endregion
#region SpecFlowUnregisterSettingsExtensions
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SpecFlowUnregisterSettingsExtensions
{
}
#endregion
#region SpecFlowAboutSettingsExtensions
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SpecFlowAboutSettingsExtensions
{
}
#endregion
#region SpecFlowToolIntegration
/// <summary>Used within <see cref="SpecFlowTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SpecFlowToolIntegration>))]
public partial class SpecFlowToolIntegration : Enumeration
{
    public static SpecFlowToolIntegration None = (SpecFlowToolIntegration) "None";
    public static SpecFlowToolIntegration VS2010 = (SpecFlowToolIntegration) "VS2010";
    public static SpecFlowToolIntegration VS2012 = (SpecFlowToolIntegration) "VS2012";
    public static SpecFlowToolIntegration VS2013 = (SpecFlowToolIntegration) "VS2013";
    public static SpecFlowToolIntegration TFS = (SpecFlowToolIntegration) "TFS";
    public static implicit operator SpecFlowToolIntegration(string value)
    {
        return new SpecFlowToolIntegration { Value = value };
    }
}
#endregion
