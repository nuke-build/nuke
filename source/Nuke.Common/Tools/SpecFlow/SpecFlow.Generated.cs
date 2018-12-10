// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/SpecFlow.json
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

namespace Nuke.Common.Tools.SpecFlow
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SpecFlowTasks
    {
        /// <summary><p>Path to the SpecFlow executable.</p></summary>
        public static string SpecFlowPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("SPECFLOW_EXE") ??
            ToolPathResolver.GetPackageExecutable("SpecFlow", "specflow.exe");
        /// <summary><p>Use SpecFlow to define, manage and automatically execute human-readable acceptance tests in .NET projects. Writing easily understandable tests is a cornerstone of the BDD paradigm and also helps build up a living documentation of your system.</p></summary>
        public static IReadOnlyCollection<Output> SpecFlow(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(SpecFlowPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, null, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>This report provides a formatted HTML report of a test execution. The report contains a summary about the executed tests and the result and also a detailed report for the individual scenario executions.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> SpecFlowNUnitExecutionReport(Configure<SpecFlowNUnitExecutionReportSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new SpecFlowNUnitExecutionReportSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>This report provides a formatted HTML report of a test execution. The report contains a summary about the executed tests and the result and also a detailed report for the individual scenario executions.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> SpecFlowMSTestExecutionReport(Configure<SpecFlowMSTestExecutionReportSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new SpecFlowMSTestExecutionReportSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>This report shows the usage and binding status of the steps for the entire project. You can use this report to find both unused code in the automation layer and scenario steps that have no definition yet.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> SpecFlowStepDefinitionReport(Configure<SpecFlowStepDefinitionReportSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new SpecFlowStepDefinitionReportSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Use <c>SpecRun.exe run</c> to execute your tests.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> SpecFlowRun(Configure<SpecFlowRunSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new SpecFlowRunSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Use <c>SpecRun.exe buildserverrun</c> to execute your tests in build server mode.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> SpecFlowBuildServerRun(Configure<SpecFlowBuildServerRunSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new SpecFlowBuildServerRunSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Use <c>SpecRun.exe register</c> to register your SpecFlow+ license. You only need to register your license once per user per machine. The license is valid for all SpecFlow+ components.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> SpecFlowRegister(Configure<SpecFlowRegisterSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new SpecFlowRegisterSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Use <c>SpecRun.exe unregister</c> to unregister your SpecFlow+ license.</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> SpecFlowUnregister(Configure<SpecFlowUnregisterSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new SpecFlowUnregisterSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Use <c>SpecRun.exe about</c> to display information such as your version number, build date and license information (licensee, upgrade until date/expiry date).</p><p>For more details, visit the <a href="https://specflow.org/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> SpecFlowAbout(Configure<SpecFlowAboutSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new SpecFlowAboutSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
    }
    #region SpecFlowNUnitExecutionReportSettings
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SpecFlowNUnitExecutionReportSettings : ToolSettings
    {
        /// <summary><p>Path to the SpecFlow executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SpecFlowTasks.SpecFlowPath;
        /// <summary><p>A path of the project file containing the *.feature files. Required.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>The XML test result file generated by nunit-console. Optional. Default: TestResult.xml.</p></summary>
        public virtual string XmlTestResult { get; internal set; }
        /// <summary><p>The labeled test output file generated by nunit-console. Optional. Default: TestResult.txt.</p></summary>
        public virtual string TestOutput { get; internal set; }
        /// <summary><p>Generated Output File. Optional. Default: TestResult.html.</p></summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary><p>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</p></summary>
        public virtual string XsltFile { get; internal set; }
        /// <summary><p>Project name which can be passed explicitly instead of implicitly getting it from --ProjectFile. Optional. Default: not specified.</p></summary>
        public virtual string ProjectName { get; internal set; }
        /// <summary><p>The feature language to use. Optional. Default: en-US.</p></summary>
        public virtual string FeatureLanguage { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(ProjectFile), $"File.Exists(ProjectFile) [ProjectFile = {ProjectFile}]");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("nunitexecutionreport")
              .Add("--ProjectFile {value}", ProjectFile)
              .Add("--xmlTestResult {value}", XmlTestResult)
              .Add("--testOutput {value}", TestOutput)
              .Add("--OutputFile {value}", OutputFile)
              .Add("--XsltFile {value}", XsltFile)
              .Add("--ProjectName {value}", ProjectName)
              .Add("--FeatureLanguage {value}", FeatureLanguage);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SpecFlowMSTestExecutionReportSettings
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SpecFlowMSTestExecutionReportSettings : ToolSettings
    {
        /// <summary><p>Path to the SpecFlow executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SpecFlowTasks.SpecFlowPath;
        /// <summary><p>A path of the project file containing the *.feature files. Required.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>The TRX test result file generated by MsTest. Optional. Default: TestResult.trx</p></summary>
        public virtual string TestResult { get; internal set; }
        /// <summary><p>Generated Output File. Optional. Default: TestResult.html</p></summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary><p>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</p></summary>
        public virtual string XsltFile { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(ProjectFile), $"File.Exists(ProjectFile) [ProjectFile = {ProjectFile}]");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("mstestexecutionreport")
              .Add("{value}", ProjectFile)
              .Add("/testResult {value}", TestResult)
              .Add("/out {value}", OutputFile)
              .Add("/xsltFile {value}", XsltFile);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SpecFlowStepDefinitionReportSettings
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SpecFlowStepDefinitionReportSettings : ToolSettings
    {
        /// <summary><p>Path to the SpecFlow executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SpecFlowTasks.SpecFlowPath;
        /// <summary><p>A path of the project file containing the *.feature files. Required.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>A path for the compiled SpecFlow project. Optional. Default: bin/debug</p></summary>
        public virtual string BinFolder { get; internal set; }
        /// <summary><p>Generated Output File. Optional. Default: TestResult.html</p></summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary><p>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</p></summary>
        public virtual string XsltFile { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(ProjectFile), $"File.Exists(ProjectFile) [ProjectFile = {ProjectFile}]");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("stepdefinitionreport")
              .Add("{value}", ProjectFile)
              .Add("/testResult {value}", BinFolder)
              .Add("/out {value}", OutputFile)
              .Add("/xsltFile {value}", XsltFile);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SpecFlowRunSettings
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SpecFlowRunSettings : ToolSettings
    {
        /// <summary><p>Path to the SpecFlow executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SpecFlowTasks.SpecFlowPath;
        /// <summary><p>Supported values: <c>None, VS2010, VS2012, VS2013, TeamCity, TFS</c>.</p></summary>
        public virtual SpecFlowToolIntegration ToolIntegration { get; internal set; }
        /// <summary><p>Default: false.</p></summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary><p>Specifies the base folder for executing tests. All paths are relative to this path.<para>If you have specified an <b>assembly</b> as your <c>target</c> you need to define the base folder as the path to the directory containing your assembly.</para><para>If you have specified a <b>test profile</b> (.srprofile) as your target, this overrides the <c>baseFolder</c> entry in your <c>.srprofile</c> file.</para></p></summary>
        public virtual string BaseFolder { get; internal set; }
        /// <summary><p>Specifies the output folder for your logs and report file. All paths are relative to this path. If you have specified a test profile (.srprofile) as your target, this value overrides the <c>outputFolder</c> entry in your <c>.srprofile</c> file.<para>If no output folder is defined in your test profile, or your <c>target</c> is an assembly,  the output folder defaults to the base folder if not specified from the command line.</para></p></summary>
        public virtual string OutputFolder { get; internal set; }
        /// <summary><p>Specifies the target log file. This path is relative to your output folder.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Specifies the target report file. This path is relative to your output folder.<para><b>Note:</b>This option only affects the name of the report file defined in the <li>&lt;Settings&gt;</li> section of your profile. It does not affect the reports defined in the <li>&lt;Report&gt;</li>; section; to change the name of the report file for these reports, use the <c>outputName</c> attribute instead.</para></p></summary>
        public virtual string ReportFile { get; internal set; }
        /// <summary><p>Applies a filter to your tests and only executes those that match your expression. This overrides the <c>filter</c> entry in your <c>.srprofile</c> file. An overview of the syntax can be found <a href="https://specflow.org/plus/documentation/Filter/">here</a>.</p></summary>
        public virtual string Filter { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("run")
              .Add("/toolIntegration:{value}", ToolIntegration)
              .Add("/debug", Debug)
              .Add("/basefolder:{value}", BaseFolder)
              .Add("/outputfolder:{value}", OutputFolder)
              .Add("/log:{value}", LogFile)
              .Add("/report:{value}", ReportFile)
              .Add("/filter:{value}", Filter);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SpecFlowBuildServerRunSettings
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SpecFlowBuildServerRunSettings : ToolSettings
    {
        /// <summary><p>Path to the SpecFlow executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SpecFlowTasks.SpecFlowPath;
        /// <summary><p>The assembly or test profile (<c>.srprofile</c> file) to be tested.</p></summary>
        public virtual string Target { get; internal set; }
        /// <summary><p>The build servers' product name (TFS, TeamCity) for specialised trace output.</p></summary>
        public virtual string BuildServerName { get; internal set; }
        /// <summary><p>Specifies the base folder for executing tests. All paths are relative to this path.<para>If you have specified an <b>assembly</b> as your <c>target</c> you need to define the base folder as the path to the directory containing your assembly.</para><para>If you have specified a <b>test profile</b> (.srprofile) as your target, this overrides the <c>baseFolder</c> entry in your <c>.srprofile</c> file.</para></p></summary>
        public virtual string BaseFolder { get; internal set; }
        /// <summary><p>Specifies the output folder for your logs and report file. All paths are relative to this path. If you have specified a test profile (.srprofile) as your target, this value overrides the <c>outputFolder</c> entry in your <c>.srprofile</c> file.<para>If no output folder is defined in your test profile, or your <c>target</c> is an assembly,  the output folder defaults to the base folder if not specified from the command line.</para></p></summary>
        public virtual string OutputFolder { get; internal set; }
        /// <summary><p>Specifies the target log file. This path is relative to your output folder.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Specifies the target report file. This path is relative to your output folder.<para><b>Note:</b>This option only affects the name of the report file defined in the <li>&lt;Settings&gt;</li> section of your profile. It does not affect the reports defined in the <li>&lt;Report&gt;</li>; section; to change the name of the report file for these reports, use the <c>outputName</c> attribute instead.</para></p></summary>
        public virtual string ReportFile { get; internal set; }
        /// <summary><p>Applies a filter to your tests and only executes those that match your expression. This overrides the <c>filter</c> entry in your <c>.srprofile</c> file. An overview of the syntax can be found <a href="https://specflow.org/plus/documentation/Filter/">here</a>.</p></summary>
        public virtual string Filter { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(Target != null, $"Target != null [Target = {Target}]");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("buildserverrun")
              .Add("{value}", Target)
              .Add("/buildserver:{value}", BuildServerName)
              .Add("/basefolder:{value}", BaseFolder)
              .Add("/outputfolder:{value}", OutputFolder)
              .Add("/log:{value}", LogFile)
              .Add("/report:{value}", ReportFile)
              .Add("/filter:{value}", Filter);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SpecFlowRegisterSettings
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SpecFlowRegisterSettings : ToolSettings
    {
        /// <summary><p>Path to the SpecFlow executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SpecFlowTasks.SpecFlowPath;
        /// <summary><p>The license key you received when you purchased SpecFlow+.</p></summary>
        public virtual string LicenseKey { get; internal set; }
        /// <summary><p>The name of the licensee. If you purchased your SpecFlow+ license online via SWREG, this is the email address you used to purchase the license. If you purchased SpecFlow+ directly from TechTalk, this is the value in the email you received containing your license information.</p></summary>
        public virtual string IssuedTo { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(LicenseKey != null, $"LicenseKey != null [LicenseKey = {LicenseKey}]");
            ControlFlow.Assert(IssuedTo != null, $"IssuedTo != null [IssuedTo = {IssuedTo}]");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("register")
              .Add("{value}", LicenseKey, secret: true)
              .Add("{value}", IssuedTo);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SpecFlowUnregisterSettings
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SpecFlowUnregisterSettings : ToolSettings
    {
        /// <summary><p>Path to the SpecFlow executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SpecFlowTasks.SpecFlowPath;
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("register");
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SpecFlowAboutSettings
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SpecFlowAboutSettings : ToolSettings
    {
        /// <summary><p>Path to the SpecFlow executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SpecFlowTasks.SpecFlowPath;
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("register");
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SpecFlowNUnitExecutionReportSettingsExtensions
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SpecFlowNUnitExecutionReportSettingsExtensions
    {
        #region ProjectFile
        /// <summary><p><em>Sets <see cref="SpecFlowNUnitExecutionReportSettings.ProjectFile"/>.</em></p><p>A path of the project file containing the *.feature files. Required.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings SetProjectFile(this SpecFlowNUnitExecutionReportSettings toolSettings, string projectFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowNUnitExecutionReportSettings.ProjectFile"/>.</em></p><p>A path of the project file containing the *.feature files. Required.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings ResetProjectFile(this SpecFlowNUnitExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region XmlTestResult
        /// <summary><p><em>Sets <see cref="SpecFlowNUnitExecutionReportSettings.XmlTestResult"/>.</em></p><p>The XML test result file generated by nunit-console. Optional. Default: TestResult.xml.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings SetXmlTestResult(this SpecFlowNUnitExecutionReportSettings toolSettings, string xmlTestResult)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlTestResult = xmlTestResult;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowNUnitExecutionReportSettings.XmlTestResult"/>.</em></p><p>The XML test result file generated by nunit-console. Optional. Default: TestResult.xml.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings ResetXmlTestResult(this SpecFlowNUnitExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlTestResult = null;
            return toolSettings;
        }
        #endregion
        #region TestOutput
        /// <summary><p><em>Sets <see cref="SpecFlowNUnitExecutionReportSettings.TestOutput"/>.</em></p><p>The labeled test output file generated by nunit-console. Optional. Default: TestResult.txt.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings SetTestOutput(this SpecFlowNUnitExecutionReportSettings toolSettings, string testOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestOutput = testOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowNUnitExecutionReportSettings.TestOutput"/>.</em></p><p>The labeled test output file generated by nunit-console. Optional. Default: TestResult.txt.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings ResetTestOutput(this SpecFlowNUnitExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestOutput = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary><p><em>Sets <see cref="SpecFlowNUnitExecutionReportSettings.OutputFile"/>.</em></p><p>Generated Output File. Optional. Default: TestResult.html.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings SetOutputFile(this SpecFlowNUnitExecutionReportSettings toolSettings, string outputFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowNUnitExecutionReportSettings.OutputFile"/>.</em></p><p>Generated Output File. Optional. Default: TestResult.html.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings ResetOutputFile(this SpecFlowNUnitExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region XsltFile
        /// <summary><p><em>Sets <see cref="SpecFlowNUnitExecutionReportSettings.XsltFile"/>.</em></p><p>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings SetXsltFile(this SpecFlowNUnitExecutionReportSettings toolSettings, string xsltFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XsltFile = xsltFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowNUnitExecutionReportSettings.XsltFile"/>.</em></p><p>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings ResetXsltFile(this SpecFlowNUnitExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XsltFile = null;
            return toolSettings;
        }
        #endregion
        #region ProjectName
        /// <summary><p><em>Sets <see cref="SpecFlowNUnitExecutionReportSettings.ProjectName"/>.</em></p><p>Project name which can be passed explicitly instead of implicitly getting it from --ProjectFile. Optional. Default: not specified.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings SetProjectName(this SpecFlowNUnitExecutionReportSettings toolSettings, string projectName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectName = projectName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowNUnitExecutionReportSettings.ProjectName"/>.</em></p><p>Project name which can be passed explicitly instead of implicitly getting it from --ProjectFile. Optional. Default: not specified.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings ResetProjectName(this SpecFlowNUnitExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectName = null;
            return toolSettings;
        }
        #endregion
        #region FeatureLanguage
        /// <summary><p><em>Sets <see cref="SpecFlowNUnitExecutionReportSettings.FeatureLanguage"/>.</em></p><p>The feature language to use. Optional. Default: en-US.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings SetFeatureLanguage(this SpecFlowNUnitExecutionReportSettings toolSettings, string featureLanguage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FeatureLanguage = featureLanguage;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowNUnitExecutionReportSettings.FeatureLanguage"/>.</em></p><p>The feature language to use. Optional. Default: en-US.</p></summary>
        [Pure]
        public static SpecFlowNUnitExecutionReportSettings ResetFeatureLanguage(this SpecFlowNUnitExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FeatureLanguage = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SpecFlowMSTestExecutionReportSettingsExtensions
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SpecFlowMSTestExecutionReportSettingsExtensions
    {
        #region ProjectFile
        /// <summary><p><em>Sets <see cref="SpecFlowMSTestExecutionReportSettings.ProjectFile"/>.</em></p><p>A path of the project file containing the *.feature files. Required.</p></summary>
        [Pure]
        public static SpecFlowMSTestExecutionReportSettings SetProjectFile(this SpecFlowMSTestExecutionReportSettings toolSettings, string projectFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowMSTestExecutionReportSettings.ProjectFile"/>.</em></p><p>A path of the project file containing the *.feature files. Required.</p></summary>
        [Pure]
        public static SpecFlowMSTestExecutionReportSettings ResetProjectFile(this SpecFlowMSTestExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region TestResult
        /// <summary><p><em>Sets <see cref="SpecFlowMSTestExecutionReportSettings.TestResult"/>.</em></p><p>The TRX test result file generated by MsTest. Optional. Default: TestResult.trx</p></summary>
        [Pure]
        public static SpecFlowMSTestExecutionReportSettings SetTestResult(this SpecFlowMSTestExecutionReportSettings toolSettings, string testResult)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestResult = testResult;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowMSTestExecutionReportSettings.TestResult"/>.</em></p><p>The TRX test result file generated by MsTest. Optional. Default: TestResult.trx</p></summary>
        [Pure]
        public static SpecFlowMSTestExecutionReportSettings ResetTestResult(this SpecFlowMSTestExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestResult = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary><p><em>Sets <see cref="SpecFlowMSTestExecutionReportSettings.OutputFile"/>.</em></p><p>Generated Output File. Optional. Default: TestResult.html</p></summary>
        [Pure]
        public static SpecFlowMSTestExecutionReportSettings SetOutputFile(this SpecFlowMSTestExecutionReportSettings toolSettings, string outputFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowMSTestExecutionReportSettings.OutputFile"/>.</em></p><p>Generated Output File. Optional. Default: TestResult.html</p></summary>
        [Pure]
        public static SpecFlowMSTestExecutionReportSettings ResetOutputFile(this SpecFlowMSTestExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region XsltFile
        /// <summary><p><em>Sets <see cref="SpecFlowMSTestExecutionReportSettings.XsltFile"/>.</em></p><p>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</p></summary>
        [Pure]
        public static SpecFlowMSTestExecutionReportSettings SetXsltFile(this SpecFlowMSTestExecutionReportSettings toolSettings, string xsltFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XsltFile = xsltFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowMSTestExecutionReportSettings.XsltFile"/>.</em></p><p>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</p></summary>
        [Pure]
        public static SpecFlowMSTestExecutionReportSettings ResetXsltFile(this SpecFlowMSTestExecutionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XsltFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SpecFlowStepDefinitionReportSettingsExtensions
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SpecFlowStepDefinitionReportSettingsExtensions
    {
        #region ProjectFile
        /// <summary><p><em>Sets <see cref="SpecFlowStepDefinitionReportSettings.ProjectFile"/>.</em></p><p>A path of the project file containing the *.feature files. Required.</p></summary>
        [Pure]
        public static SpecFlowStepDefinitionReportSettings SetProjectFile(this SpecFlowStepDefinitionReportSettings toolSettings, string projectFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowStepDefinitionReportSettings.ProjectFile"/>.</em></p><p>A path of the project file containing the *.feature files. Required.</p></summary>
        [Pure]
        public static SpecFlowStepDefinitionReportSettings ResetProjectFile(this SpecFlowStepDefinitionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region BinFolder
        /// <summary><p><em>Sets <see cref="SpecFlowStepDefinitionReportSettings.BinFolder"/>.</em></p><p>A path for the compiled SpecFlow project. Optional. Default: bin/debug</p></summary>
        [Pure]
        public static SpecFlowStepDefinitionReportSettings SetBinFolder(this SpecFlowStepDefinitionReportSettings toolSettings, string binFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BinFolder = binFolder;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowStepDefinitionReportSettings.BinFolder"/>.</em></p><p>A path for the compiled SpecFlow project. Optional. Default: bin/debug</p></summary>
        [Pure]
        public static SpecFlowStepDefinitionReportSettings ResetBinFolder(this SpecFlowStepDefinitionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BinFolder = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary><p><em>Sets <see cref="SpecFlowStepDefinitionReportSettings.OutputFile"/>.</em></p><p>Generated Output File. Optional. Default: TestResult.html</p></summary>
        [Pure]
        public static SpecFlowStepDefinitionReportSettings SetOutputFile(this SpecFlowStepDefinitionReportSettings toolSettings, string outputFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowStepDefinitionReportSettings.OutputFile"/>.</em></p><p>Generated Output File. Optional. Default: TestResult.html</p></summary>
        [Pure]
        public static SpecFlowStepDefinitionReportSettings ResetOutputFile(this SpecFlowStepDefinitionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region XsltFile
        /// <summary><p><em>Sets <see cref="SpecFlowStepDefinitionReportSettings.XsltFile"/>.</em></p><p>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</p></summary>
        [Pure]
        public static SpecFlowStepDefinitionReportSettings SetXsltFile(this SpecFlowStepDefinitionReportSettings toolSettings, string xsltFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XsltFile = xsltFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowStepDefinitionReportSettings.XsltFile"/>.</em></p><p>Custom XSLT file to use, defaults to built-in stylesheet if not provided. Optional. Default: not specified.</p></summary>
        [Pure]
        public static SpecFlowStepDefinitionReportSettings ResetXsltFile(this SpecFlowStepDefinitionReportSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XsltFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SpecFlowRunSettingsExtensions
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SpecFlowRunSettingsExtensions
    {
        #region ToolIntegration
        /// <summary><p><em>Sets <see cref="SpecFlowRunSettings.ToolIntegration"/>.</em></p><p>Supported values: <c>None, VS2010, VS2012, VS2013, TeamCity, TFS</c>.</p></summary>
        [Pure]
        public static SpecFlowRunSettings SetToolIntegration(this SpecFlowRunSettings toolSettings, SpecFlowToolIntegration toolIntegration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolIntegration = toolIntegration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowRunSettings.ToolIntegration"/>.</em></p><p>Supported values: <c>None, VS2010, VS2012, VS2013, TeamCity, TFS</c>.</p></summary>
        [Pure]
        public static SpecFlowRunSettings ResetToolIntegration(this SpecFlowRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolIntegration = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary><p><em>Sets <see cref="SpecFlowRunSettings.Debug"/>.</em></p><p>Default: false.</p></summary>
        [Pure]
        public static SpecFlowRunSettings SetDebug(this SpecFlowRunSettings toolSettings, bool? debug)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowRunSettings.Debug"/>.</em></p><p>Default: false.</p></summary>
        [Pure]
        public static SpecFlowRunSettings ResetDebug(this SpecFlowRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SpecFlowRunSettings.Debug"/>.</em></p><p>Default: false.</p></summary>
        [Pure]
        public static SpecFlowRunSettings EnableDebug(this SpecFlowRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SpecFlowRunSettings.Debug"/>.</em></p><p>Default: false.</p></summary>
        [Pure]
        public static SpecFlowRunSettings DisableDebug(this SpecFlowRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SpecFlowRunSettings.Debug"/>.</em></p><p>Default: false.</p></summary>
        [Pure]
        public static SpecFlowRunSettings ToggleDebug(this SpecFlowRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region BaseFolder
        /// <summary><p><em>Sets <see cref="SpecFlowRunSettings.BaseFolder"/>.</em></p><p>Specifies the base folder for executing tests. All paths are relative to this path.<para>If you have specified an <b>assembly</b> as your <c>target</c> you need to define the base folder as the path to the directory containing your assembly.</para><para>If you have specified a <b>test profile</b> (.srprofile) as your target, this overrides the <c>baseFolder</c> entry in your <c>.srprofile</c> file.</para></p></summary>
        [Pure]
        public static SpecFlowRunSettings SetBaseFolder(this SpecFlowRunSettings toolSettings, string baseFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseFolder = baseFolder;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowRunSettings.BaseFolder"/>.</em></p><p>Specifies the base folder for executing tests. All paths are relative to this path.<para>If you have specified an <b>assembly</b> as your <c>target</c> you need to define the base folder as the path to the directory containing your assembly.</para><para>If you have specified a <b>test profile</b> (.srprofile) as your target, this overrides the <c>baseFolder</c> entry in your <c>.srprofile</c> file.</para></p></summary>
        [Pure]
        public static SpecFlowRunSettings ResetBaseFolder(this SpecFlowRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseFolder = null;
            return toolSettings;
        }
        #endregion
        #region OutputFolder
        /// <summary><p><em>Sets <see cref="SpecFlowRunSettings.OutputFolder"/>.</em></p><p>Specifies the output folder for your logs and report file. All paths are relative to this path. If you have specified a test profile (.srprofile) as your target, this value overrides the <c>outputFolder</c> entry in your <c>.srprofile</c> file.<para>If no output folder is defined in your test profile, or your <c>target</c> is an assembly,  the output folder defaults to the base folder if not specified from the command line.</para></p></summary>
        [Pure]
        public static SpecFlowRunSettings SetOutputFolder(this SpecFlowRunSettings toolSettings, string outputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = outputFolder;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowRunSettings.OutputFolder"/>.</em></p><p>Specifies the output folder for your logs and report file. All paths are relative to this path. If you have specified a test profile (.srprofile) as your target, this value overrides the <c>outputFolder</c> entry in your <c>.srprofile</c> file.<para>If no output folder is defined in your test profile, or your <c>target</c> is an assembly,  the output folder defaults to the base folder if not specified from the command line.</para></p></summary>
        [Pure]
        public static SpecFlowRunSettings ResetOutputFolder(this SpecFlowRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary><p><em>Sets <see cref="SpecFlowRunSettings.LogFile"/>.</em></p><p>Specifies the target log file. This path is relative to your output folder.</p></summary>
        [Pure]
        public static SpecFlowRunSettings SetLogFile(this SpecFlowRunSettings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowRunSettings.LogFile"/>.</em></p><p>Specifies the target log file. This path is relative to your output folder.</p></summary>
        [Pure]
        public static SpecFlowRunSettings ResetLogFile(this SpecFlowRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region ReportFile
        /// <summary><p><em>Sets <see cref="SpecFlowRunSettings.ReportFile"/>.</em></p><p>Specifies the target report file. This path is relative to your output folder.<para><b>Note:</b>This option only affects the name of the report file defined in the <li>&lt;Settings&gt;</li> section of your profile. It does not affect the reports defined in the <li>&lt;Report&gt;</li>; section; to change the name of the report file for these reports, use the <c>outputName</c> attribute instead.</para></p></summary>
        [Pure]
        public static SpecFlowRunSettings SetReportFile(this SpecFlowRunSettings toolSettings, string reportFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportFile = reportFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowRunSettings.ReportFile"/>.</em></p><p>Specifies the target report file. This path is relative to your output folder.<para><b>Note:</b>This option only affects the name of the report file defined in the <li>&lt;Settings&gt;</li> section of your profile. It does not affect the reports defined in the <li>&lt;Report&gt;</li>; section; to change the name of the report file for these reports, use the <c>outputName</c> attribute instead.</para></p></summary>
        [Pure]
        public static SpecFlowRunSettings ResetReportFile(this SpecFlowRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportFile = null;
            return toolSettings;
        }
        #endregion
        #region Filter
        /// <summary><p><em>Sets <see cref="SpecFlowRunSettings.Filter"/>.</em></p><p>Applies a filter to your tests and only executes those that match your expression. This overrides the <c>filter</c> entry in your <c>.srprofile</c> file. An overview of the syntax can be found <a href="https://specflow.org/plus/documentation/Filter/">here</a>.</p></summary>
        [Pure]
        public static SpecFlowRunSettings SetFilter(this SpecFlowRunSettings toolSettings, string filter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowRunSettings.Filter"/>.</em></p><p>Applies a filter to your tests and only executes those that match your expression. This overrides the <c>filter</c> entry in your <c>.srprofile</c> file. An overview of the syntax can be found <a href="https://specflow.org/plus/documentation/Filter/">here</a>.</p></summary>
        [Pure]
        public static SpecFlowRunSettings ResetFilter(this SpecFlowRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SpecFlowBuildServerRunSettingsExtensions
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SpecFlowBuildServerRunSettingsExtensions
    {
        #region Target
        /// <summary><p><em>Sets <see cref="SpecFlowBuildServerRunSettings.Target"/>.</em></p><p>The assembly or test profile (<c>.srprofile</c> file) to be tested.</p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings SetTarget(this SpecFlowBuildServerRunSettings toolSettings, string target)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Target = target;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowBuildServerRunSettings.Target"/>.</em></p><p>The assembly or test profile (<c>.srprofile</c> file) to be tested.</p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings ResetTarget(this SpecFlowBuildServerRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Target = null;
            return toolSettings;
        }
        #endregion
        #region BuildServerName
        /// <summary><p><em>Sets <see cref="SpecFlowBuildServerRunSettings.BuildServerName"/>.</em></p><p>The build servers' product name (TFS, TeamCity) for specialised trace output.</p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings SetBuildServerName(this SpecFlowBuildServerRunSettings toolSettings, string buildServerName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildServerName = buildServerName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowBuildServerRunSettings.BuildServerName"/>.</em></p><p>The build servers' product name (TFS, TeamCity) for specialised trace output.</p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings ResetBuildServerName(this SpecFlowBuildServerRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildServerName = null;
            return toolSettings;
        }
        #endregion
        #region BaseFolder
        /// <summary><p><em>Sets <see cref="SpecFlowBuildServerRunSettings.BaseFolder"/>.</em></p><p>Specifies the base folder for executing tests. All paths are relative to this path.<para>If you have specified an <b>assembly</b> as your <c>target</c> you need to define the base folder as the path to the directory containing your assembly.</para><para>If you have specified a <b>test profile</b> (.srprofile) as your target, this overrides the <c>baseFolder</c> entry in your <c>.srprofile</c> file.</para></p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings SetBaseFolder(this SpecFlowBuildServerRunSettings toolSettings, string baseFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseFolder = baseFolder;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowBuildServerRunSettings.BaseFolder"/>.</em></p><p>Specifies the base folder for executing tests. All paths are relative to this path.<para>If you have specified an <b>assembly</b> as your <c>target</c> you need to define the base folder as the path to the directory containing your assembly.</para><para>If you have specified a <b>test profile</b> (.srprofile) as your target, this overrides the <c>baseFolder</c> entry in your <c>.srprofile</c> file.</para></p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings ResetBaseFolder(this SpecFlowBuildServerRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseFolder = null;
            return toolSettings;
        }
        #endregion
        #region OutputFolder
        /// <summary><p><em>Sets <see cref="SpecFlowBuildServerRunSettings.OutputFolder"/>.</em></p><p>Specifies the output folder for your logs and report file. All paths are relative to this path. If you have specified a test profile (.srprofile) as your target, this value overrides the <c>outputFolder</c> entry in your <c>.srprofile</c> file.<para>If no output folder is defined in your test profile, or your <c>target</c> is an assembly,  the output folder defaults to the base folder if not specified from the command line.</para></p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings SetOutputFolder(this SpecFlowBuildServerRunSettings toolSettings, string outputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = outputFolder;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowBuildServerRunSettings.OutputFolder"/>.</em></p><p>Specifies the output folder for your logs and report file. All paths are relative to this path. If you have specified a test profile (.srprofile) as your target, this value overrides the <c>outputFolder</c> entry in your <c>.srprofile</c> file.<para>If no output folder is defined in your test profile, or your <c>target</c> is an assembly,  the output folder defaults to the base folder if not specified from the command line.</para></p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings ResetOutputFolder(this SpecFlowBuildServerRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary><p><em>Sets <see cref="SpecFlowBuildServerRunSettings.LogFile"/>.</em></p><p>Specifies the target log file. This path is relative to your output folder.</p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings SetLogFile(this SpecFlowBuildServerRunSettings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowBuildServerRunSettings.LogFile"/>.</em></p><p>Specifies the target log file. This path is relative to your output folder.</p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings ResetLogFile(this SpecFlowBuildServerRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region ReportFile
        /// <summary><p><em>Sets <see cref="SpecFlowBuildServerRunSettings.ReportFile"/>.</em></p><p>Specifies the target report file. This path is relative to your output folder.<para><b>Note:</b>This option only affects the name of the report file defined in the <li>&lt;Settings&gt;</li> section of your profile. It does not affect the reports defined in the <li>&lt;Report&gt;</li>; section; to change the name of the report file for these reports, use the <c>outputName</c> attribute instead.</para></p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings SetReportFile(this SpecFlowBuildServerRunSettings toolSettings, string reportFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportFile = reportFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowBuildServerRunSettings.ReportFile"/>.</em></p><p>Specifies the target report file. This path is relative to your output folder.<para><b>Note:</b>This option only affects the name of the report file defined in the <li>&lt;Settings&gt;</li> section of your profile. It does not affect the reports defined in the <li>&lt;Report&gt;</li>; section; to change the name of the report file for these reports, use the <c>outputName</c> attribute instead.</para></p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings ResetReportFile(this SpecFlowBuildServerRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReportFile = null;
            return toolSettings;
        }
        #endregion
        #region Filter
        /// <summary><p><em>Sets <see cref="SpecFlowBuildServerRunSettings.Filter"/>.</em></p><p>Applies a filter to your tests and only executes those that match your expression. This overrides the <c>filter</c> entry in your <c>.srprofile</c> file. An overview of the syntax can be found <a href="https://specflow.org/plus/documentation/Filter/">here</a>.</p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings SetFilter(this SpecFlowBuildServerRunSettings toolSettings, string filter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowBuildServerRunSettings.Filter"/>.</em></p><p>Applies a filter to your tests and only executes those that match your expression. This overrides the <c>filter</c> entry in your <c>.srprofile</c> file. An overview of the syntax can be found <a href="https://specflow.org/plus/documentation/Filter/">here</a>.</p></summary>
        [Pure]
        public static SpecFlowBuildServerRunSettings ResetFilter(this SpecFlowBuildServerRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SpecFlowRegisterSettingsExtensions
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SpecFlowRegisterSettingsExtensions
    {
        #region LicenseKey
        /// <summary><p><em>Sets <see cref="SpecFlowRegisterSettings.LicenseKey"/>.</em></p><p>The license key you received when you purchased SpecFlow+.</p></summary>
        [Pure]
        public static SpecFlowRegisterSettings SetLicenseKey(this SpecFlowRegisterSettings toolSettings, string licenseKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LicenseKey = licenseKey;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowRegisterSettings.LicenseKey"/>.</em></p><p>The license key you received when you purchased SpecFlow+.</p></summary>
        [Pure]
        public static SpecFlowRegisterSettings ResetLicenseKey(this SpecFlowRegisterSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LicenseKey = null;
            return toolSettings;
        }
        #endregion
        #region IssuedTo
        /// <summary><p><em>Sets <see cref="SpecFlowRegisterSettings.IssuedTo"/>.</em></p><p>The name of the licensee. If you purchased your SpecFlow+ license online via SWREG, this is the email address you used to purchase the license. If you purchased SpecFlow+ directly from TechTalk, this is the value in the email you received containing your license information.</p></summary>
        [Pure]
        public static SpecFlowRegisterSettings SetIssuedTo(this SpecFlowRegisterSettings toolSettings, string issuedTo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IssuedTo = issuedTo;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SpecFlowRegisterSettings.IssuedTo"/>.</em></p><p>The name of the licensee. If you purchased your SpecFlow+ license online via SWREG, this is the email address you used to purchase the license. If you purchased SpecFlow+ directly from TechTalk, this is the value in the email you received containing your license information.</p></summary>
        [Pure]
        public static SpecFlowRegisterSettings ResetIssuedTo(this SpecFlowRegisterSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IssuedTo = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SpecFlowUnregisterSettingsExtensions
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SpecFlowUnregisterSettingsExtensions
    {
    }
    #endregion
    #region SpecFlowAboutSettingsExtensions
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SpecFlowAboutSettingsExtensions
    {
    }
    #endregion
    #region SpecFlowToolIntegration
    /// <summary><p>Used within <see cref="SpecFlowTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<SpecFlowToolIntegration>))]
    public partial class SpecFlowToolIntegration : Enumeration
    {
        public static SpecFlowToolIntegration None = new SpecFlowToolIntegration { Value = "None" };
        public static SpecFlowToolIntegration VS2010 = new SpecFlowToolIntegration { Value = "VS2010" };
        public static SpecFlowToolIntegration VS2012 = new SpecFlowToolIntegration { Value = "VS2012" };
        public static SpecFlowToolIntegration VS2013 = new SpecFlowToolIntegration { Value = "VS2013" };
        public static SpecFlowToolIntegration TFS = new SpecFlowToolIntegration { Value = "TFS" };
    }
    #endregion
}
