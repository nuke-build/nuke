// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/DotNet.json

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

namespace Nuke.Common.Tools.DotNet
{
    /// <summary>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetTasks
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public static string DotNetPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("DOTNET_EXE") ??
            ToolPathResolver.GetPathExecutable("dotnet");
        public static Action<OutputType, string> DotNetLogger { get; set; } = CustomLogger;
        /// <summary>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotNet(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, string logFile = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(DotNetPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logFile, DotNetLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projectFile&gt;</c> via <see cref="DotNetTestSettings.ProjectFile"/></li>
        ///     <li><c>--blame</c> via <see cref="DotNetTestSettings.BlameMode"/></li>
        ///     <li><c>--collect</c> via <see cref="DotNetTestSettings.DataCollector"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetTestSettings.Configuration"/></li>
        ///     <li><c>--diag</c> via <see cref="DotNetTestSettings.DiagnosticsFile"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetTestSettings.DisableParallel"/></li>
        ///     <li><c>--filter</c> via <see cref="DotNetTestSettings.Filter"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetTestSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetTestSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetTestSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetTestSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--list-tests</c> via <see cref="DotNetTestSettings.ListTests"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetTestSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetTestSettings.LockedMode"/></li>
        ///     <li><c>--logger</c> via <see cref="DotNetTestSettings.Logger"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetTestSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetTestSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetTestSettings.NoDependencies"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetTestSettings.NoRestore"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetTestSettings.Output"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetTestSettings.PackageDirectory"/></li>
        ///     <li><c>--results-directory</c> via <see cref="DotNetTestSettings.ResultsDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetTestSettings.Runtime"/></li>
        ///     <li><c>--settings</c> via <see cref="DotNetTestSettings.SettingsFile"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetTestSettings.Sources"/></li>
        ///     <li><c>--test-adapter-path</c> via <see cref="DotNetTestSettings.TestAdapterPath"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetTestSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetTestSettings.Verbosity"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetTestSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetTest(DotNetTestSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetTestSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projectFile&gt;</c> via <see cref="DotNetTestSettings.ProjectFile"/></li>
        ///     <li><c>--blame</c> via <see cref="DotNetTestSettings.BlameMode"/></li>
        ///     <li><c>--collect</c> via <see cref="DotNetTestSettings.DataCollector"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetTestSettings.Configuration"/></li>
        ///     <li><c>--diag</c> via <see cref="DotNetTestSettings.DiagnosticsFile"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetTestSettings.DisableParallel"/></li>
        ///     <li><c>--filter</c> via <see cref="DotNetTestSettings.Filter"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetTestSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetTestSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetTestSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetTestSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--list-tests</c> via <see cref="DotNetTestSettings.ListTests"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetTestSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetTestSettings.LockedMode"/></li>
        ///     <li><c>--logger</c> via <see cref="DotNetTestSettings.Logger"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetTestSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetTestSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetTestSettings.NoDependencies"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetTestSettings.NoRestore"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetTestSettings.Output"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetTestSettings.PackageDirectory"/></li>
        ///     <li><c>--results-directory</c> via <see cref="DotNetTestSettings.ResultsDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetTestSettings.Runtime"/></li>
        ///     <li><c>--settings</c> via <see cref="DotNetTestSettings.SettingsFile"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetTestSettings.Sources"/></li>
        ///     <li><c>--test-adapter-path</c> via <see cref="DotNetTestSettings.TestAdapterPath"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetTestSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetTestSettings.Verbosity"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetTestSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetTest(Configure<DotNetTestSettings> configurator)
        {
            return DotNetTest(configurator(new DotNetTestSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projectFile&gt;</c> via <see cref="DotNetTestSettings.ProjectFile"/></li>
        ///     <li><c>--blame</c> via <see cref="DotNetTestSettings.BlameMode"/></li>
        ///     <li><c>--collect</c> via <see cref="DotNetTestSettings.DataCollector"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetTestSettings.Configuration"/></li>
        ///     <li><c>--diag</c> via <see cref="DotNetTestSettings.DiagnosticsFile"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetTestSettings.DisableParallel"/></li>
        ///     <li><c>--filter</c> via <see cref="DotNetTestSettings.Filter"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetTestSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetTestSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetTestSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetTestSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--list-tests</c> via <see cref="DotNetTestSettings.ListTests"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetTestSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetTestSettings.LockedMode"/></li>
        ///     <li><c>--logger</c> via <see cref="DotNetTestSettings.Logger"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetTestSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetTestSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetTestSettings.NoDependencies"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetTestSettings.NoRestore"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetTestSettings.Output"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetTestSettings.PackageDirectory"/></li>
        ///     <li><c>--results-directory</c> via <see cref="DotNetTestSettings.ResultsDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetTestSettings.Runtime"/></li>
        ///     <li><c>--settings</c> via <see cref="DotNetTestSettings.SettingsFile"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetTestSettings.Sources"/></li>
        ///     <li><c>--test-adapter-path</c> via <see cref="DotNetTestSettings.TestAdapterPath"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetTestSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetTestSettings.Verbosity"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetTestSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetTestSettings Settings, IReadOnlyCollection<Output> Output)> DotNetTest(CombinatorialConfigure<DotNetTestSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetTest, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet run</c> command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build"><c>dotnet build</c></a> command to build the code. Any requirements for the build, such as that the project must be restored first, apply to <c>dotnet run</c> as well.</p><p>Output files are written into the default location, which is <c>bin/&lt;configuration&gt;/&lt;target&gt;</c>. For example if you have a <c>netcoreapp1.0</c> application and you run <c>dotnet run</c>, the output is placed in <c>bin/Debug/netcoreapp1.0</c>. Files are overwritten as needed. Temporary files are placed in the <c>obj</c> directory.</p><p>If the project specifies multiple frameworks, executing <c>dotnet run</c> results in an error unless the <c>-f|--framework &lt;FRAMEWORK&gt;</c> option is used to specify the framework.</p><p>The <c>dotnet run</c> command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet">dotnet</a> without a command. For example, to run <c>myapp.dll</c>, use: <c>dotnet myapp.dll</c></p><p>For more information on the <c>dotnet</c> driver, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/index">.NET Core Command Line Tools (CLI)</a> topic.</p><p>In order to run the application, the <c>dotnet run</c> command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use <c>dotnet run</c> to run applications in production. Instead, <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">create a deployment</a> using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command and deploy the published output.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="DotNetRunSettings.ApplicationArguments"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetRunSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetRunSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetRunSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetRunSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetRunSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetRunSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--launch-profile</c> via <see cref="DotNetRunSettings.LaunchProfile"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetRunSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetRunSettings.LockedMode"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetRunSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetRunSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetRunSettings.NoDependencies"/></li>
        ///     <li><c>--no-launch-profile</c> via <see cref="DotNetRunSettings.NoLaunchProfile"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetRunSettings.NoRestore"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetRunSettings.PackageDirectory"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetRunSettings.ProjectFile"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetRunSettings.Runtime"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetRunSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetRunSettings.UseLockFile"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetRunSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetRun(DotNetRunSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetRunSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet run</c> command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build"><c>dotnet build</c></a> command to build the code. Any requirements for the build, such as that the project must be restored first, apply to <c>dotnet run</c> as well.</p><p>Output files are written into the default location, which is <c>bin/&lt;configuration&gt;/&lt;target&gt;</c>. For example if you have a <c>netcoreapp1.0</c> application and you run <c>dotnet run</c>, the output is placed in <c>bin/Debug/netcoreapp1.0</c>. Files are overwritten as needed. Temporary files are placed in the <c>obj</c> directory.</p><p>If the project specifies multiple frameworks, executing <c>dotnet run</c> results in an error unless the <c>-f|--framework &lt;FRAMEWORK&gt;</c> option is used to specify the framework.</p><p>The <c>dotnet run</c> command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet">dotnet</a> without a command. For example, to run <c>myapp.dll</c>, use: <c>dotnet myapp.dll</c></p><p>For more information on the <c>dotnet</c> driver, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/index">.NET Core Command Line Tools (CLI)</a> topic.</p><p>In order to run the application, the <c>dotnet run</c> command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use <c>dotnet run</c> to run applications in production. Instead, <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">create a deployment</a> using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command and deploy the published output.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="DotNetRunSettings.ApplicationArguments"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetRunSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetRunSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetRunSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetRunSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetRunSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetRunSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--launch-profile</c> via <see cref="DotNetRunSettings.LaunchProfile"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetRunSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetRunSettings.LockedMode"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetRunSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetRunSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetRunSettings.NoDependencies"/></li>
        ///     <li><c>--no-launch-profile</c> via <see cref="DotNetRunSettings.NoLaunchProfile"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetRunSettings.NoRestore"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetRunSettings.PackageDirectory"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetRunSettings.ProjectFile"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetRunSettings.Runtime"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetRunSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetRunSettings.UseLockFile"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetRunSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetRun(Configure<DotNetRunSettings> configurator)
        {
            return DotNetRun(configurator(new DotNetRunSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet run</c> command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build"><c>dotnet build</c></a> command to build the code. Any requirements for the build, such as that the project must be restored first, apply to <c>dotnet run</c> as well.</p><p>Output files are written into the default location, which is <c>bin/&lt;configuration&gt;/&lt;target&gt;</c>. For example if you have a <c>netcoreapp1.0</c> application and you run <c>dotnet run</c>, the output is placed in <c>bin/Debug/netcoreapp1.0</c>. Files are overwritten as needed. Temporary files are placed in the <c>obj</c> directory.</p><p>If the project specifies multiple frameworks, executing <c>dotnet run</c> results in an error unless the <c>-f|--framework &lt;FRAMEWORK&gt;</c> option is used to specify the framework.</p><p>The <c>dotnet run</c> command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet">dotnet</a> without a command. For example, to run <c>myapp.dll</c>, use: <c>dotnet myapp.dll</c></p><p>For more information on the <c>dotnet</c> driver, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/index">.NET Core Command Line Tools (CLI)</a> topic.</p><p>In order to run the application, the <c>dotnet run</c> command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use <c>dotnet run</c> to run applications in production. Instead, <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">create a deployment</a> using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command and deploy the published output.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="DotNetRunSettings.ApplicationArguments"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetRunSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetRunSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetRunSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetRunSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetRunSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetRunSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--launch-profile</c> via <see cref="DotNetRunSettings.LaunchProfile"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetRunSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetRunSettings.LockedMode"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetRunSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetRunSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetRunSettings.NoDependencies"/></li>
        ///     <li><c>--no-launch-profile</c> via <see cref="DotNetRunSettings.NoLaunchProfile"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetRunSettings.NoRestore"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetRunSettings.PackageDirectory"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetRunSettings.ProjectFile"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetRunSettings.Runtime"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetRunSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetRunSettings.UseLockFile"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetRunSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetRunSettings Settings, IReadOnlyCollection<Output> Output)> DotNetRun(CombinatorialConfigure<DotNetRunSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetRun, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>Starting with .NET Core 2.0, you don't have to run <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> because it's run implicitly by all commands, such as <c>dotnet build</c> and <c>dotnet run</c>, that require a restore to occur. It's still a valid command in certain scenarios where doing an explicit restore makes sense, such as <a href="https://docs.microsoft.com/en-us/vsts/build-release/apps/aspnet/build-aspnet-core">continuous integration builds in Visual Studio Team Services</a> or in build systems that need to explicitly control the time at which the restore occurs.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <em>NuGet.config</em> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <em>NuGet.config</em> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <em>/home/user1</em> on Linux or <em>C:\Users\user1</em> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <em>Nuget.Config</em> file, if present. For example, setting the <c>globalPackagesFolder</c> in <em>NuGet.Config</em> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projectFile&gt;</c> via <see cref="DotNetRestoreSettings.ProjectFile"/></li>
        ///     <li><c>--configfile</c> via <see cref="DotNetRestoreSettings.ConfigFile"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetRestoreSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetRestoreSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetRestoreSettings.ForceEvaluate"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetRestoreSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetRestoreSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetRestoreSettings.LockedMode"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetRestoreSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetRestoreSettings.NoDependencies"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetRestoreSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetRestoreSettings.Runtime"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetRestoreSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetRestoreSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetRestoreSettings.Verbosity"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetRestoreSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetRestore(DotNetRestoreSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetRestoreSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>Starting with .NET Core 2.0, you don't have to run <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> because it's run implicitly by all commands, such as <c>dotnet build</c> and <c>dotnet run</c>, that require a restore to occur. It's still a valid command in certain scenarios where doing an explicit restore makes sense, such as <a href="https://docs.microsoft.com/en-us/vsts/build-release/apps/aspnet/build-aspnet-core">continuous integration builds in Visual Studio Team Services</a> or in build systems that need to explicitly control the time at which the restore occurs.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <em>NuGet.config</em> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <em>NuGet.config</em> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <em>/home/user1</em> on Linux or <em>C:\Users\user1</em> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <em>Nuget.Config</em> file, if present. For example, setting the <c>globalPackagesFolder</c> in <em>NuGet.Config</em> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projectFile&gt;</c> via <see cref="DotNetRestoreSettings.ProjectFile"/></li>
        ///     <li><c>--configfile</c> via <see cref="DotNetRestoreSettings.ConfigFile"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetRestoreSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetRestoreSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetRestoreSettings.ForceEvaluate"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetRestoreSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetRestoreSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetRestoreSettings.LockedMode"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetRestoreSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetRestoreSettings.NoDependencies"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetRestoreSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetRestoreSettings.Runtime"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetRestoreSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetRestoreSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetRestoreSettings.Verbosity"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetRestoreSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetRestore(Configure<DotNetRestoreSettings> configurator)
        {
            return DotNetRestore(configurator(new DotNetRestoreSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>Starting with .NET Core 2.0, you don't have to run <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> because it's run implicitly by all commands, such as <c>dotnet build</c> and <c>dotnet run</c>, that require a restore to occur. It's still a valid command in certain scenarios where doing an explicit restore makes sense, such as <a href="https://docs.microsoft.com/en-us/vsts/build-release/apps/aspnet/build-aspnet-core">continuous integration builds in Visual Studio Team Services</a> or in build systems that need to explicitly control the time at which the restore occurs.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <em>NuGet.config</em> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <em>NuGet.config</em> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <em>/home/user1</em> on Linux or <em>C:\Users\user1</em> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <em>Nuget.Config</em> file, if present. For example, setting the <c>globalPackagesFolder</c> in <em>NuGet.Config</em> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projectFile&gt;</c> via <see cref="DotNetRestoreSettings.ProjectFile"/></li>
        ///     <li><c>--configfile</c> via <see cref="DotNetRestoreSettings.ConfigFile"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetRestoreSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetRestoreSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetRestoreSettings.ForceEvaluate"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetRestoreSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetRestoreSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetRestoreSettings.LockedMode"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetRestoreSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetRestoreSettings.NoDependencies"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetRestoreSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetRestoreSettings.Runtime"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetRestoreSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetRestoreSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetRestoreSettings.Verbosity"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetRestoreSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetRestoreSettings Settings, IReadOnlyCollection<Output> Output)> DotNetRestore(CombinatorialConfigure<DotNetRestoreSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetRestore, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <em>.nuspec</em> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;project&gt;</c> via <see cref="DotNetPackSettings.Project"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetPackSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetPackSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetPackSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetPackSettings.ForceEvaluate"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetPackSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--include-source</c> via <see cref="DotNetPackSettings.IncludeSource"/></li>
        ///     <li><c>--include-symbols</c> via <see cref="DotNetPackSettings.IncludeSymbols"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetPackSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetPackSettings.LockedMode"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetPackSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetPackSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetPackSettings.NoDependencies"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetPackSettings.NoRestore"/></li>
        ///     <li><c>--nologo</c> via <see cref="DotNetPackSettings.NoLogo"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetPackSettings.OutputDirectory"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetPackSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetPackSettings.Runtime"/></li>
        ///     <li><c>--serviceable</c> via <see cref="DotNetPackSettings.Serviceable"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetPackSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetPackSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetPackSettings.Verbostiy"/></li>
        ///     <li><c>--version-suffix</c> via <see cref="DotNetPackSettings.VersionSuffix"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetPackSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetPack(DotNetPackSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetPackSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <em>.nuspec</em> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;project&gt;</c> via <see cref="DotNetPackSettings.Project"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetPackSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetPackSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetPackSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetPackSettings.ForceEvaluate"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetPackSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--include-source</c> via <see cref="DotNetPackSettings.IncludeSource"/></li>
        ///     <li><c>--include-symbols</c> via <see cref="DotNetPackSettings.IncludeSymbols"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetPackSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetPackSettings.LockedMode"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetPackSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetPackSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetPackSettings.NoDependencies"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetPackSettings.NoRestore"/></li>
        ///     <li><c>--nologo</c> via <see cref="DotNetPackSettings.NoLogo"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetPackSettings.OutputDirectory"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetPackSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetPackSettings.Runtime"/></li>
        ///     <li><c>--serviceable</c> via <see cref="DotNetPackSettings.Serviceable"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetPackSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetPackSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetPackSettings.Verbostiy"/></li>
        ///     <li><c>--version-suffix</c> via <see cref="DotNetPackSettings.VersionSuffix"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetPackSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetPack(Configure<DotNetPackSettings> configurator)
        {
            return DotNetPack(configurator(new DotNetPackSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <em>.nuspec</em> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;project&gt;</c> via <see cref="DotNetPackSettings.Project"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetPackSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetPackSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetPackSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetPackSettings.ForceEvaluate"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetPackSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--include-source</c> via <see cref="DotNetPackSettings.IncludeSource"/></li>
        ///     <li><c>--include-symbols</c> via <see cref="DotNetPackSettings.IncludeSymbols"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetPackSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetPackSettings.LockedMode"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetPackSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetPackSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetPackSettings.NoDependencies"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetPackSettings.NoRestore"/></li>
        ///     <li><c>--nologo</c> via <see cref="DotNetPackSettings.NoLogo"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetPackSettings.OutputDirectory"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetPackSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetPackSettings.Runtime"/></li>
        ///     <li><c>--serviceable</c> via <see cref="DotNetPackSettings.Serviceable"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetPackSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetPackSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetPackSettings.Verbostiy"/></li>
        ///     <li><c>--version-suffix</c> via <see cref="DotNetPackSettings.VersionSuffix"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetPackSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetPackSettings Settings, IReadOnlyCollection<Output> Output)> DotNetPack(CombinatorialConfigure<DotNetPackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetPack, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <em>.dll</em> extension and symbol files used for debugging with a <em>.pdb</em> extension. A dependencies JSON file (<em>*.deps.json</em>) is produced that lists the dependencies of the application. A <em>.runtimeconfig.json</em> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <em>project.assets.json</em> file, which lists the dependencies of your application. The file is created <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> is executed. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors. With .NET Core 1.x SDK, you needed to explicitily run the <c>dotnet restore</c> before running <c>dotnet build</c>. Starting with .NET Core 2.0 SDK, <c>dotnet restore</c> runs implicitily when you run <c>dotnet build</c>. If you want to disable implicit restore when running the build command, you can pass the <c>--no-restore</c> option.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projectFile&gt;</c> via <see cref="DotNetBuildSettings.ProjectFile"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetBuildSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetBuildSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetBuildSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetBuildSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetBuildSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetBuildSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetBuildSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetBuildSettings.LockedMode"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetBuildSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetBuildSettings.NoDependencies"/></li>
        ///     <li><c>--no-incremental</c> via <see cref="DotNetBuildSettings.NoIncremental"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetBuildSettings.NoRestore"/></li>
        ///     <li><c>--nologo</c> via <see cref="DotNetBuildSettings.NoLogo"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetBuildSettings.OutputDirectory"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetBuildSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetBuildSettings.Runtime"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetBuildSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetBuildSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetBuildSettings.Verbosity"/></li>
        ///     <li><c>--version-suffix</c> via <see cref="DotNetBuildSettings.VersionSuffix"/></li>
        ///     <li><c>/logger</c> via <see cref="DotNetBuildSettings.Loggers"/></li>
        ///     <li><c>/noconsolelogger</c> via <see cref="DotNetBuildSettings.NoConsoleLogger"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetBuildSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetBuild(DotNetBuildSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetBuildSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <em>.dll</em> extension and symbol files used for debugging with a <em>.pdb</em> extension. A dependencies JSON file (<em>*.deps.json</em>) is produced that lists the dependencies of the application. A <em>.runtimeconfig.json</em> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <em>project.assets.json</em> file, which lists the dependencies of your application. The file is created <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> is executed. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors. With .NET Core 1.x SDK, you needed to explicitily run the <c>dotnet restore</c> before running <c>dotnet build</c>. Starting with .NET Core 2.0 SDK, <c>dotnet restore</c> runs implicitily when you run <c>dotnet build</c>. If you want to disable implicit restore when running the build command, you can pass the <c>--no-restore</c> option.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projectFile&gt;</c> via <see cref="DotNetBuildSettings.ProjectFile"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetBuildSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetBuildSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetBuildSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetBuildSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetBuildSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetBuildSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetBuildSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetBuildSettings.LockedMode"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetBuildSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetBuildSettings.NoDependencies"/></li>
        ///     <li><c>--no-incremental</c> via <see cref="DotNetBuildSettings.NoIncremental"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetBuildSettings.NoRestore"/></li>
        ///     <li><c>--nologo</c> via <see cref="DotNetBuildSettings.NoLogo"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetBuildSettings.OutputDirectory"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetBuildSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetBuildSettings.Runtime"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetBuildSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetBuildSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetBuildSettings.Verbosity"/></li>
        ///     <li><c>--version-suffix</c> via <see cref="DotNetBuildSettings.VersionSuffix"/></li>
        ///     <li><c>/logger</c> via <see cref="DotNetBuildSettings.Loggers"/></li>
        ///     <li><c>/noconsolelogger</c> via <see cref="DotNetBuildSettings.NoConsoleLogger"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetBuildSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetBuild(Configure<DotNetBuildSettings> configurator)
        {
            return DotNetBuild(configurator(new DotNetBuildSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <em>.dll</em> extension and symbol files used for debugging with a <em>.pdb</em> extension. A dependencies JSON file (<em>*.deps.json</em>) is produced that lists the dependencies of the application. A <em>.runtimeconfig.json</em> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <em>project.assets.json</em> file, which lists the dependencies of your application. The file is created <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> is executed. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors. With .NET Core 1.x SDK, you needed to explicitily run the <c>dotnet restore</c> before running <c>dotnet build</c>. Starting with .NET Core 2.0 SDK, <c>dotnet restore</c> runs implicitily when you run <c>dotnet build</c>. If you want to disable implicit restore when running the build command, you can pass the <c>--no-restore</c> option.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projectFile&gt;</c> via <see cref="DotNetBuildSettings.ProjectFile"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetBuildSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetBuildSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetBuildSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetBuildSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetBuildSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetBuildSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetBuildSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetBuildSettings.LockedMode"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetBuildSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetBuildSettings.NoDependencies"/></li>
        ///     <li><c>--no-incremental</c> via <see cref="DotNetBuildSettings.NoIncremental"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetBuildSettings.NoRestore"/></li>
        ///     <li><c>--nologo</c> via <see cref="DotNetBuildSettings.NoLogo"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetBuildSettings.OutputDirectory"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetBuildSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetBuildSettings.Runtime"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetBuildSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetBuildSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetBuildSettings.Verbosity"/></li>
        ///     <li><c>--version-suffix</c> via <see cref="DotNetBuildSettings.VersionSuffix"/></li>
        ///     <li><c>/logger</c> via <see cref="DotNetBuildSettings.Loggers"/></li>
        ///     <li><c>/noconsolelogger</c> via <see cref="DotNetBuildSettings.NoConsoleLogger"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetBuildSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetBuildSettings Settings, IReadOnlyCollection<Output> Output)> DotNetBuild(CombinatorialConfigure<DotNetBuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetBuild, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet clean</c> command cleans the output of the previous build. It's implemented as an <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-targets">MSBuild target</a>, so the project is evaluated when the command is run. Only the outputs created during the build are cleaned. Both intermediate <em>(obj)</em> and final output <em>(bin)</em> folders are cleaned.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;project&gt;</c> via <see cref="DotNetCleanSettings.Project"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetCleanSettings.Configuration"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetCleanSettings.Framework"/></li>
        ///     <li><c>--nologo</c> via <see cref="DotNetCleanSettings.NoLogo"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetCleanSettings.Output"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetCleanSettings.Runtime"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetCleanSettings.Verbosity"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetCleanSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetClean(DotNetCleanSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetCleanSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet clean</c> command cleans the output of the previous build. It's implemented as an <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-targets">MSBuild target</a>, so the project is evaluated when the command is run. Only the outputs created during the build are cleaned. Both intermediate <em>(obj)</em> and final output <em>(bin)</em> folders are cleaned.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;project&gt;</c> via <see cref="DotNetCleanSettings.Project"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetCleanSettings.Configuration"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetCleanSettings.Framework"/></li>
        ///     <li><c>--nologo</c> via <see cref="DotNetCleanSettings.NoLogo"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetCleanSettings.Output"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetCleanSettings.Runtime"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetCleanSettings.Verbosity"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetCleanSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetClean(Configure<DotNetCleanSettings> configurator)
        {
            return DotNetClean(configurator(new DotNetCleanSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet clean</c> command cleans the output of the previous build. It's implemented as an <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-targets">MSBuild target</a>, so the project is evaluated when the command is run. Only the outputs created during the build are cleaned. Both intermediate <em>(obj)</em> and final output <em>(bin)</em> folders are cleaned.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;project&gt;</c> via <see cref="DotNetCleanSettings.Project"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetCleanSettings.Configuration"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetCleanSettings.Framework"/></li>
        ///     <li><c>--nologo</c> via <see cref="DotNetCleanSettings.NoLogo"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetCleanSettings.Output"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetCleanSettings.Runtime"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetCleanSettings.Verbosity"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetCleanSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetCleanSettings Settings, IReadOnlyCollection<Output> Output)> DotNetClean(CombinatorialConfigure<DotNetCleanSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetClean, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p><c>dotnet publish</c> compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output will contain the following:<para/><ul><li>Intermediate Language (IL) code in an assembly with a <em>dll</em> extension.</li><li><em>.deps.json</em> file that contains all of the dependencies of the project.</li><li><em>.runtime.config.json</em> file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).</li><li>The application's dependencies. These are copied from the NuGet cache into the output folder.</li></ul><para/>The <c>dotnet publish</c> command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution and is the only officially supported way to prepare the application for deployment. Depending on the type of deployment that the project specifies, the hosting system may or may not have the .NET Core shared runtime installed on it. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>. For the directory structure of a published application, see <a href="https://docs.microsoft.com/en-us/aspnet/core/hosting/directory-structure">Directory structure</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;project&gt;</c> via <see cref="DotNetPublishSettings.Project"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetPublishSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetPublishSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetPublishSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetPublishSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetPublishSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetPublishSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetPublishSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetPublishSettings.LockedMode"/></li>
        ///     <li><c>--manifest</c> via <see cref="DotNetPublishSettings.Manifest"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetPublishSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetPublishSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetPublishSettings.NoDependencies"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetPublishSettings.NoRestore"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetPublishSettings.Output"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetPublishSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetPublishSettings.Runtime"/></li>
        ///     <li><c>--self-contained</c> via <see cref="DotNetPublishSettings.SelfContained"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetPublishSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetPublishSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetPublishSettings.Verbosity"/></li>
        ///     <li><c>--version-suffix</c> via <see cref="DotNetPublishSettings.VersionSuffix"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetPublishSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetPublish(DotNetPublishSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetPublishSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p><c>dotnet publish</c> compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output will contain the following:<para/><ul><li>Intermediate Language (IL) code in an assembly with a <em>dll</em> extension.</li><li><em>.deps.json</em> file that contains all of the dependencies of the project.</li><li><em>.runtime.config.json</em> file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).</li><li>The application's dependencies. These are copied from the NuGet cache into the output folder.</li></ul><para/>The <c>dotnet publish</c> command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution and is the only officially supported way to prepare the application for deployment. Depending on the type of deployment that the project specifies, the hosting system may or may not have the .NET Core shared runtime installed on it. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>. For the directory structure of a published application, see <a href="https://docs.microsoft.com/en-us/aspnet/core/hosting/directory-structure">Directory structure</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;project&gt;</c> via <see cref="DotNetPublishSettings.Project"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetPublishSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetPublishSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetPublishSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetPublishSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetPublishSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetPublishSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetPublishSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetPublishSettings.LockedMode"/></li>
        ///     <li><c>--manifest</c> via <see cref="DotNetPublishSettings.Manifest"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetPublishSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetPublishSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetPublishSettings.NoDependencies"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetPublishSettings.NoRestore"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetPublishSettings.Output"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetPublishSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetPublishSettings.Runtime"/></li>
        ///     <li><c>--self-contained</c> via <see cref="DotNetPublishSettings.SelfContained"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetPublishSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetPublishSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetPublishSettings.Verbosity"/></li>
        ///     <li><c>--version-suffix</c> via <see cref="DotNetPublishSettings.VersionSuffix"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetPublishSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetPublish(Configure<DotNetPublishSettings> configurator)
        {
            return DotNetPublish(configurator(new DotNetPublishSettings()));
        }
        /// <summary>
        ///   <p><c>dotnet publish</c> compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output will contain the following:<para/><ul><li>Intermediate Language (IL) code in an assembly with a <em>dll</em> extension.</li><li><em>.deps.json</em> file that contains all of the dependencies of the project.</li><li><em>.runtime.config.json</em> file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).</li><li>The application's dependencies. These are copied from the NuGet cache into the output folder.</li></ul><para/>The <c>dotnet publish</c> command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution and is the only officially supported way to prepare the application for deployment. Depending on the type of deployment that the project specifies, the hosting system may or may not have the .NET Core shared runtime installed on it. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>. For the directory structure of a published application, see <a href="https://docs.microsoft.com/en-us/aspnet/core/hosting/directory-structure">Directory structure</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;project&gt;</c> via <see cref="DotNetPublishSettings.Project"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetPublishSettings.Configuration"/></li>
        ///     <li><c>--disable-parallel</c> via <see cref="DotNetPublishSettings.DisableParallel"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetPublishSettings.Force"/></li>
        ///     <li><c>--force-evaluate</c> via <see cref="DotNetPublishSettings.ForceEvaluate"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetPublishSettings.Framework"/></li>
        ///     <li><c>--ignore-failed-sources</c> via <see cref="DotNetPublishSettings.IgnoreFailedSources"/></li>
        ///     <li><c>--lock-file-path</c> via <see cref="DotNetPublishSettings.LockFilePath"/></li>
        ///     <li><c>--locked-mode</c> via <see cref="DotNetPublishSettings.LockedMode"/></li>
        ///     <li><c>--manifest</c> via <see cref="DotNetPublishSettings.Manifest"/></li>
        ///     <li><c>--no-build</c> via <see cref="DotNetPublishSettings.NoBuild"/></li>
        ///     <li><c>--no-cache</c> via <see cref="DotNetPublishSettings.NoCache"/></li>
        ///     <li><c>--no-dependencies</c> via <see cref="DotNetPublishSettings.NoDependencies"/></li>
        ///     <li><c>--no-restore</c> via <see cref="DotNetPublishSettings.NoRestore"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetPublishSettings.Output"/></li>
        ///     <li><c>--packages</c> via <see cref="DotNetPublishSettings.PackageDirectory"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetPublishSettings.Runtime"/></li>
        ///     <li><c>--self-contained</c> via <see cref="DotNetPublishSettings.SelfContained"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetPublishSettings.Sources"/></li>
        ///     <li><c>--use-lock-file</c> via <see cref="DotNetPublishSettings.UseLockFile"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetPublishSettings.Verbosity"/></li>
        ///     <li><c>--version-suffix</c> via <see cref="DotNetPublishSettings.VersionSuffix"/></li>
        ///     <li><c>/property</c> via <see cref="DotNetPublishSettings.Properties"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetPublishSettings Settings, IReadOnlyCollection<Output> Output)> DotNetPublish(CombinatorialConfigure<DotNetPublishSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetPublish, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Pushes a package to the server and publishes it.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="DotNetNuGetPushSettings.TargetPath"/></li>
        ///     <li><c>--api-key</c> via <see cref="DotNetNuGetPushSettings.ApiKey"/></li>
        ///     <li><c>--disable-buffering</c> via <see cref="DotNetNuGetPushSettings.DisableBuffering"/></li>
        ///     <li><c>--force-english-output</c> via <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/></li>
        ///     <li><c>--no-service-endpoint</c> via <see cref="DotNetNuGetPushSettings.NoServiceEndpoint"/></li>
        ///     <li><c>--no-symbols</c> via <see cref="DotNetNuGetPushSettings.NoSymbols"/></li>
        ///     <li><c>--skip-duplicate</c> via <see cref="DotNetNuGetPushSettings.SkipDuplicate"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetNuGetPushSettings.Source"/></li>
        ///     <li><c>--symbol-api-key</c> via <see cref="DotNetNuGetPushSettings.SymbolApiKey"/></li>
        ///     <li><c>--symbol-source</c> via <see cref="DotNetNuGetPushSettings.SymbolSource"/></li>
        ///     <li><c>--timeout</c> via <see cref="DotNetNuGetPushSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetNuGetPush(DotNetNuGetPushSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetNuGetPushSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Pushes a package to the server and publishes it.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="DotNetNuGetPushSettings.TargetPath"/></li>
        ///     <li><c>--api-key</c> via <see cref="DotNetNuGetPushSettings.ApiKey"/></li>
        ///     <li><c>--disable-buffering</c> via <see cref="DotNetNuGetPushSettings.DisableBuffering"/></li>
        ///     <li><c>--force-english-output</c> via <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/></li>
        ///     <li><c>--no-service-endpoint</c> via <see cref="DotNetNuGetPushSettings.NoServiceEndpoint"/></li>
        ///     <li><c>--no-symbols</c> via <see cref="DotNetNuGetPushSettings.NoSymbols"/></li>
        ///     <li><c>--skip-duplicate</c> via <see cref="DotNetNuGetPushSettings.SkipDuplicate"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetNuGetPushSettings.Source"/></li>
        ///     <li><c>--symbol-api-key</c> via <see cref="DotNetNuGetPushSettings.SymbolApiKey"/></li>
        ///     <li><c>--symbol-source</c> via <see cref="DotNetNuGetPushSettings.SymbolSource"/></li>
        ///     <li><c>--timeout</c> via <see cref="DotNetNuGetPushSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetNuGetPush(Configure<DotNetNuGetPushSettings> configurator)
        {
            return DotNetNuGetPush(configurator(new DotNetNuGetPushSettings()));
        }
        /// <summary>
        ///   <p>Pushes a package to the server and publishes it.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="DotNetNuGetPushSettings.TargetPath"/></li>
        ///     <li><c>--api-key</c> via <see cref="DotNetNuGetPushSettings.ApiKey"/></li>
        ///     <li><c>--disable-buffering</c> via <see cref="DotNetNuGetPushSettings.DisableBuffering"/></li>
        ///     <li><c>--force-english-output</c> via <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/></li>
        ///     <li><c>--no-service-endpoint</c> via <see cref="DotNetNuGetPushSettings.NoServiceEndpoint"/></li>
        ///     <li><c>--no-symbols</c> via <see cref="DotNetNuGetPushSettings.NoSymbols"/></li>
        ///     <li><c>--skip-duplicate</c> via <see cref="DotNetNuGetPushSettings.SkipDuplicate"/></li>
        ///     <li><c>--source</c> via <see cref="DotNetNuGetPushSettings.Source"/></li>
        ///     <li><c>--symbol-api-key</c> via <see cref="DotNetNuGetPushSettings.SymbolApiKey"/></li>
        ///     <li><c>--symbol-source</c> via <see cref="DotNetNuGetPushSettings.SymbolSource"/></li>
        ///     <li><c>--timeout</c> via <see cref="DotNetNuGetPushSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetNuGetPushSettings Settings, IReadOnlyCollection<Output> Output)> DotNetNuGetPush(CombinatorialConfigure<DotNetNuGetPushSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetNuGetPush, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet tool install</c> command provides a way for you to install .NET Core Global Tools on your machine. To use the command, you either have to specify that you want a user-wide installation using the <c>--global</c> option or you specify a path to install it using the <c>--tool-path</c> option.<para/>Global Tools are installed in the following directories by default when you specify the <c>-g</c> (or <c>--global</c>) option:<ul><li>Linux/macOS: <c>$HOME/.dotnet/tools</c></li><li>Windows: <c>%USERPROFILE%\.dotnet\tools</c></li></ul></p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageName&gt;</c> via <see cref="DotNetToolInstallSettings.PackageName"/></li>
        ///     <li><c>--add-source</c> via <see cref="DotNetToolInstallSettings.Sources"/></li>
        ///     <li><c>--configfile</c> via <see cref="DotNetToolInstallSettings.ConfigFile"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetToolInstallSettings.Framework"/></li>
        ///     <li><c>--global</c> via <see cref="DotNetToolInstallSettings.Global"/></li>
        ///     <li><c>--tool-path</c> via <see cref="DotNetToolInstallSettings.ToolInstallationPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetToolInstallSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetToolInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetToolInstall(DotNetToolInstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetToolInstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet tool install</c> command provides a way for you to install .NET Core Global Tools on your machine. To use the command, you either have to specify that you want a user-wide installation using the <c>--global</c> option or you specify a path to install it using the <c>--tool-path</c> option.<para/>Global Tools are installed in the following directories by default when you specify the <c>-g</c> (or <c>--global</c>) option:<ul><li>Linux/macOS: <c>$HOME/.dotnet/tools</c></li><li>Windows: <c>%USERPROFILE%\.dotnet\tools</c></li></ul></p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageName&gt;</c> via <see cref="DotNetToolInstallSettings.PackageName"/></li>
        ///     <li><c>--add-source</c> via <see cref="DotNetToolInstallSettings.Sources"/></li>
        ///     <li><c>--configfile</c> via <see cref="DotNetToolInstallSettings.ConfigFile"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetToolInstallSettings.Framework"/></li>
        ///     <li><c>--global</c> via <see cref="DotNetToolInstallSettings.Global"/></li>
        ///     <li><c>--tool-path</c> via <see cref="DotNetToolInstallSettings.ToolInstallationPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetToolInstallSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetToolInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetToolInstall(Configure<DotNetToolInstallSettings> configurator)
        {
            return DotNetToolInstall(configurator(new DotNetToolInstallSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet tool install</c> command provides a way for you to install .NET Core Global Tools on your machine. To use the command, you either have to specify that you want a user-wide installation using the <c>--global</c> option or you specify a path to install it using the <c>--tool-path</c> option.<para/>Global Tools are installed in the following directories by default when you specify the <c>-g</c> (or <c>--global</c>) option:<ul><li>Linux/macOS: <c>$HOME/.dotnet/tools</c></li><li>Windows: <c>%USERPROFILE%\.dotnet\tools</c></li></ul></p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageName&gt;</c> via <see cref="DotNetToolInstallSettings.PackageName"/></li>
        ///     <li><c>--add-source</c> via <see cref="DotNetToolInstallSettings.Sources"/></li>
        ///     <li><c>--configfile</c> via <see cref="DotNetToolInstallSettings.ConfigFile"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetToolInstallSettings.Framework"/></li>
        ///     <li><c>--global</c> via <see cref="DotNetToolInstallSettings.Global"/></li>
        ///     <li><c>--tool-path</c> via <see cref="DotNetToolInstallSettings.ToolInstallationPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetToolInstallSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetToolInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetToolInstallSettings Settings, IReadOnlyCollection<Output> Output)> DotNetToolInstall(CombinatorialConfigure<DotNetToolInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetToolInstall, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet tool uninstall</c> command provides a way for you to uninstall .NET Core Global Tools from your machine. To use the command, you either have to specify that you want to remove a user-wide tool using the <c>--global</c> option or specify a path to where the tool is installed using the <c>--tool-path</c> option.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageName&gt;</c> via <see cref="DotNetToolUninstallSettings.PackageName"/></li>
        ///     <li><c>--global</c> via <see cref="DotNetToolUninstallSettings.Global"/></li>
        ///     <li><c>--tool-path</c> via <see cref="DotNetToolUninstallSettings.ToolInstallationPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetToolUninstallSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetToolUninstall(DotNetToolUninstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetToolUninstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet tool uninstall</c> command provides a way for you to uninstall .NET Core Global Tools from your machine. To use the command, you either have to specify that you want to remove a user-wide tool using the <c>--global</c> option or specify a path to where the tool is installed using the <c>--tool-path</c> option.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageName&gt;</c> via <see cref="DotNetToolUninstallSettings.PackageName"/></li>
        ///     <li><c>--global</c> via <see cref="DotNetToolUninstallSettings.Global"/></li>
        ///     <li><c>--tool-path</c> via <see cref="DotNetToolUninstallSettings.ToolInstallationPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetToolUninstallSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetToolUninstall(Configure<DotNetToolUninstallSettings> configurator)
        {
            return DotNetToolUninstall(configurator(new DotNetToolUninstallSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet tool uninstall</c> command provides a way for you to uninstall .NET Core Global Tools from your machine. To use the command, you either have to specify that you want to remove a user-wide tool using the <c>--global</c> option or specify a path to where the tool is installed using the <c>--tool-path</c> option.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageName&gt;</c> via <see cref="DotNetToolUninstallSettings.PackageName"/></li>
        ///     <li><c>--global</c> via <see cref="DotNetToolUninstallSettings.Global"/></li>
        ///     <li><c>--tool-path</c> via <see cref="DotNetToolUninstallSettings.ToolInstallationPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetToolUninstallSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetToolUninstallSettings Settings, IReadOnlyCollection<Output> Output)> DotNetToolUninstall(CombinatorialConfigure<DotNetToolUninstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetToolUninstall, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet tool update</c> command provides a way for you to update .NET Core Global Tools on your machine to the latest stable version of the package. The command uninstalls and re-installs a tool, effectively updating it. To use the command, you either have to specify that you want to update a tool from a user-wide installation using the <c>--global</c> option or specify a path to where the tool is installed using the <c>--tool-path</c> option.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageName&gt;</c> via <see cref="DotNetToolUpdateSettings.PackageName"/></li>
        ///     <li><c>--add-source</c> via <see cref="DotNetToolUpdateSettings.Sources"/></li>
        ///     <li><c>--configfile</c> via <see cref="DotNetToolUpdateSettings.ConfigFile"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetToolUpdateSettings.Framework"/></li>
        ///     <li><c>--global</c> via <see cref="DotNetToolUpdateSettings.Global"/></li>
        ///     <li><c>--tool-path</c> via <see cref="DotNetToolUpdateSettings.ToolInstallationPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetToolUpdateSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetToolUpdate(DotNetToolUpdateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetToolUpdateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet tool update</c> command provides a way for you to update .NET Core Global Tools on your machine to the latest stable version of the package. The command uninstalls and re-installs a tool, effectively updating it. To use the command, you either have to specify that you want to update a tool from a user-wide installation using the <c>--global</c> option or specify a path to where the tool is installed using the <c>--tool-path</c> option.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageName&gt;</c> via <see cref="DotNetToolUpdateSettings.PackageName"/></li>
        ///     <li><c>--add-source</c> via <see cref="DotNetToolUpdateSettings.Sources"/></li>
        ///     <li><c>--configfile</c> via <see cref="DotNetToolUpdateSettings.ConfigFile"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetToolUpdateSettings.Framework"/></li>
        ///     <li><c>--global</c> via <see cref="DotNetToolUpdateSettings.Global"/></li>
        ///     <li><c>--tool-path</c> via <see cref="DotNetToolUpdateSettings.ToolInstallationPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetToolUpdateSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetToolUpdate(Configure<DotNetToolUpdateSettings> configurator)
        {
            return DotNetToolUpdate(configurator(new DotNetToolUpdateSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet tool update</c> command provides a way for you to update .NET Core Global Tools on your machine to the latest stable version of the package. The command uninstalls and re-installs a tool, effectively updating it. To use the command, you either have to specify that you want to update a tool from a user-wide installation using the <c>--global</c> option or specify a path to where the tool is installed using the <c>--tool-path</c> option.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageName&gt;</c> via <see cref="DotNetToolUpdateSettings.PackageName"/></li>
        ///     <li><c>--add-source</c> via <see cref="DotNetToolUpdateSettings.Sources"/></li>
        ///     <li><c>--configfile</c> via <see cref="DotNetToolUpdateSettings.ConfigFile"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetToolUpdateSettings.Framework"/></li>
        ///     <li><c>--global</c> via <see cref="DotNetToolUpdateSettings.Global"/></li>
        ///     <li><c>--tool-path</c> via <see cref="DotNetToolUpdateSettings.ToolInstallationPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetToolUpdateSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetToolUpdateSettings Settings, IReadOnlyCollection<Output> Output)> DotNetToolUpdate(CombinatorialConfigure<DotNetToolUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetToolUpdate, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region DotNetTestSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetTestSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   Specifies a path to the test project. If omitted, it defaults to current directory.
        /// </summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary>
        ///   Use the custom test adapters from the specified path in the test run.
        /// </summary>
        public virtual string TestAdapterPath { get; internal set; }
        /// <summary>
        ///   Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting.
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   Enables data collector for the test run. For more information, see <a href="https://aka.ms/vstest-collect">Monitor and analyze test run</a>.
        /// </summary>
        public virtual string DataCollector { get; internal set; }
        /// <summary>
        ///   Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.
        /// </summary>
        public virtual string DiagnosticsFile { get; internal set; }
        /// <summary>
        ///   Looks for test binaries for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   Filters out tests in the current project using the given expression. For more information, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests">Running selective unit tests</a>.
        /// </summary>
        public virtual string Filter { get; internal set; }
        /// <summary>
        ///   Specifies a logger for test results.
        /// </summary>
        public virtual string Logger { get; internal set; }
        /// <summary>
        ///   Does not build the test project prior to running it.
        /// </summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary>
        ///   Doesn't perform an implicit restore when running the command.
        /// </summary>
        public virtual bool? NoRestore { get; internal set; }
        /// <summary>
        ///   Directory in which to find the binaries to run.
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   The directory where the test results are going to be placed. The specified directory will be created if it doesn't exist.
        /// </summary>
        public virtual string ResultsDirectory { get; internal set; }
        /// <summary>
        ///   Settings to use when running tests.
        /// </summary>
        public virtual string SettingsFile { get; internal set; }
        /// <summary>
        ///   List all of the discovered tests in the current project.
        /// </summary>
        public virtual bool? ListTests { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Runs the tests in blame mode. This option is helpful in isolating the problematic tests causing test host to crash. It creates an output file in the current directory as <em>Sequence.xml</em> that captures the order of tests execution before the crash.
        /// </summary>
        public virtual bool? BlameMode { get; internal set; }
        /// <summary>
        ///   Disables restoring multiple projects in parallel.
        /// </summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary>
        ///   Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Only warn about failed sources if there are packages meeting the version requirement.
        /// </summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary>
        ///   Specifies to not cache packages and HTTP requests.
        /// </summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary>
        ///   When restoring a project with project-to-project (P2P) references, restore the root project and not the references.
        /// </summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary>
        ///   Specifies the directory for restored packages.
        /// </summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary>
        ///   Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.
        /// </summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Enables project lock file to be generated and used with restore.
        /// </summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary>
        ///   Don't allow updating project lock file.
        /// </summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary>
        ///   Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.
        /// </summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary>
        ///   Forces restore to reevaluate all dependencies even if a lock file already exists.
        /// </summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary>
        ///   Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("test")
              .Add("{value}", ProjectFile)
              .Add("--test-adapter-path {value}", TestAdapterPath)
              .Add("--configuration {value}", Configuration)
              .Add("--collect {value}", DataCollector)
              .Add("--diag {value}", DiagnosticsFile)
              .Add("--framework {value}", Framework)
              .Add("--filter {value}", Filter)
              .Add("--logger {value}", Logger)
              .Add("--no-build", NoBuild)
              .Add("--no-restore", NoRestore)
              .Add("--output {value}", Output)
              .Add("--results-directory {value}", ResultsDirectory)
              .Add("--settings {value}", SettingsFile)
              .Add("--list-tests", ListTests)
              .Add("--verbosity {value}", Verbosity)
              .Add("/property:{value}", Properties, "{key}={value}", disallowed: ';')
              .Add("--blame", BlameMode)
              .Add("--disable-parallel", DisableParallel)
              .Add("--force", Force)
              .Add("--ignore-failed-sources", IgnoreFailedSources)
              .Add("--no-cache", NoCache)
              .Add("--no-dependencies", NoDependencies)
              .Add("--packages {value}", PackageDirectory)
              .Add("--source {value}", Sources)
              .Add("--use-lock-file", UseLockFile)
              .Add("--locked-mode", LockedMode)
              .Add("--lock-file-path {value}", LockFilePath)
              .Add("--force-evaluate", ForceEvaluate)
              .Add("--runtime {value}", Runtime);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetRunSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetRunSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   Configuration to use for building the project. The default value is Debug.
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   Builds and runs the app using the specified framework. The framework must be specified in the project file.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the <em>launchSettings.json</em> file and are typically called <c>Development</c>, <c>Staging</c> and <c>Production</c>. For more information, see <a href="https://docs.microsoft.com/en-us/aspnetcore/fundamentals/environments">Working with multiple environments</a>.
        /// </summary>
        public virtual string LaunchProfile { get; internal set; }
        /// <summary>
        ///   Doesn't build the project before running.
        /// </summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary>
        ///   Doesn't attempt to use <em>launchSettings.json</em> to configure the application.
        /// </summary>
        public virtual bool? NoLaunchProfile { get; internal set; }
        /// <summary>
        ///   Doesn't perform an implicit restore when running the command.
        /// </summary>
        public virtual bool? NoRestore { get; internal set; }
        /// <summary>
        ///   Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.
        /// </summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary>
        ///   Arguments passed to the application being run.
        /// </summary>
        public virtual string ApplicationArguments { get; internal set; }
        /// <summary>
        ///   Disables restoring multiple projects in parallel.
        /// </summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary>
        ///   Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Only warn about failed sources if there are packages meeting the version requirement.
        /// </summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary>
        ///   Specifies to not cache packages and HTTP requests.
        /// </summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary>
        ///   When restoring a project with project-to-project (P2P) references, restore the root project and not the references.
        /// </summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary>
        ///   Specifies the directory for restored packages.
        /// </summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary>
        ///   Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.
        /// </summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Enables project lock file to be generated and used with restore.
        /// </summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary>
        ///   Don't allow updating project lock file.
        /// </summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary>
        ///   Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.
        /// </summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary>
        ///   Forces restore to reevaluate all dependencies even if a lock file already exists.
        /// </summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary>
        ///   Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("run")
              .Add("--configuration {value}", Configuration)
              .Add("--framework {value}", Framework)
              .Add("--launch-profile {value}", LaunchProfile)
              .Add("--no-build", NoBuild)
              .Add("--no-launch-profile", NoLaunchProfile)
              .Add("--no-restore", NoRestore)
              .Add("--project {value}", ProjectFile)
              .Add("-- {value}", GetApplicationArguments(), customValue: true)
              .Add("--disable-parallel", DisableParallel)
              .Add("--force", Force)
              .Add("--ignore-failed-sources", IgnoreFailedSources)
              .Add("--no-cache", NoCache)
              .Add("--no-dependencies", NoDependencies)
              .Add("--packages {value}", PackageDirectory)
              .Add("--source {value}", Sources)
              .Add("--use-lock-file", UseLockFile)
              .Add("--locked-mode", LockedMode)
              .Add("--lock-file-path {value}", LockFilePath)
              .Add("--force-evaluate", ForceEvaluate)
              .Add("--runtime {value}", Runtime)
              .Add("/property:{value}", Properties, "{key}={value}", disallowed: ';');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetRestoreSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetRestoreSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   Optional path to the project file to restore.
        /// </summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary>
        ///   The NuGet configuration file (<em>NuGet.config</em>) to use for the restore operation.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Disables restoring multiple projects in parallel.
        /// </summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary>
        ///   Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Only warn about failed sources if there are packages meeting the version requirement.
        /// </summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary>
        ///   Specifies to not cache packages and HTTP requests.
        /// </summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary>
        ///   When restoring a project with project-to-project (P2P) references, restore the root project and not the references.
        /// </summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary>
        ///   Specifies the directory for restored packages.
        /// </summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary>
        ///   Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.
        /// </summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Enables project lock file to be generated and used with restore.
        /// </summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary>
        ///   Don't allow updating project lock file.
        /// </summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary>
        ///   Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.
        /// </summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary>
        ///   Forces restore to reevaluate all dependencies even if a lock file already exists.
        /// </summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary>
        ///   Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("restore")
              .Add("{value}", ProjectFile)
              .Add("--configfile {value}", ConfigFile)
              .Add("--verbosity {value}", Verbosity)
              .Add("--disable-parallel", DisableParallel)
              .Add("--force", Force)
              .Add("--ignore-failed-sources", IgnoreFailedSources)
              .Add("--no-cache", NoCache)
              .Add("--no-dependencies", NoDependencies)
              .Add("--packages {value}", PackageDirectory)
              .Add("--source {value}", Sources)
              .Add("--use-lock-file", UseLockFile)
              .Add("--locked-mode", LockedMode)
              .Add("--lock-file-path {value}", LockFilePath)
              .Add("--force-evaluate", ForceEvaluate)
              .Add("--runtime {value}", Runtime)
              .Add("/property:{value}", Properties, "{key}={value}", disallowed: ';');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetPackSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetPackSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   The project to pack. It's either a path to a csproj file or to a directory. If omitted, it defaults to the current directory.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>.
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.
        /// </summary>
        public virtual bool? IncludeSource { get; internal set; }
        /// <summary>
        ///   Generates the symbols <c>nupkg</c>.
        /// </summary>
        public virtual bool? IncludeSymbols { get; internal set; }
        /// <summary>
        ///   Don't build the project before packing.
        /// </summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary>
        ///   Doesn't perform an implicit restore when running the command.
        /// </summary>
        public virtual bool? NoRestore { get; internal set; }
        /// <summary>
        ///   Places the built packages in the directory specified.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.
        /// </summary>
        public virtual bool? Serviceable { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbostiy { get; internal set; }
        /// <summary>
        ///   Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project.
        /// </summary>
        public virtual string VersionSuffix { get; internal set; }
        /// <summary>
        ///   Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   Disables restoring multiple projects in parallel.
        /// </summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary>
        ///   Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Only warn about failed sources if there are packages meeting the version requirement.
        /// </summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary>
        ///   Specifies to not cache packages and HTTP requests.
        /// </summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary>
        ///   When restoring a project with project-to-project (P2P) references, restore the root project and not the references.
        /// </summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary>
        ///   Specifies the directory for restored packages.
        /// </summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary>
        ///   Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.
        /// </summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Enables project lock file to be generated and used with restore.
        /// </summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary>
        ///   Don't allow updating project lock file.
        /// </summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary>
        ///   Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.
        /// </summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary>
        ///   Forces restore to reevaluate all dependencies even if a lock file already exists.
        /// </summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary>
        ///   Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("pack")
              .Add("{value}", Project)
              .Add("--configuration {value}", Configuration)
              .Add("--include-source", IncludeSource)
              .Add("--include-symbols", IncludeSymbols)
              .Add("--no-build", NoBuild)
              .Add("--no-restore", NoRestore)
              .Add("--output {value}", OutputDirectory)
              .Add("--serviceable", Serviceable)
              .Add("--verbosity {value}", Verbostiy)
              .Add("--version-suffix {value}", VersionSuffix)
              .Add("--nologo", NoLogo)
              .Add("--disable-parallel", DisableParallel)
              .Add("--force", Force)
              .Add("--ignore-failed-sources", IgnoreFailedSources)
              .Add("--no-cache", NoCache)
              .Add("--no-dependencies", NoDependencies)
              .Add("--packages {value}", PackageDirectory)
              .Add("--source {value}", Sources)
              .Add("--use-lock-file", UseLockFile)
              .Add("--locked-mode", LockedMode)
              .Add("--lock-file-path {value}", LockFilePath)
              .Add("--force-evaluate", ForceEvaluate)
              .Add("--runtime {value}", Runtime)
              .Add("/property:{value}", Properties, "{key}={value}", disallowed: ';');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetBuildSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetBuildSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.
        /// </summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary>
        ///   Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.
        /// </summary>
        public virtual bool? NoIncremental { get; internal set; }
        /// <summary>
        ///   Doesn't perform an implicit restore during build.
        /// </summary>
        public virtual bool? NoRestore { get; internal set; }
        /// <summary>
        ///   Directory in which to place the built binaries. You also need to define <c>--framework</c> when you specify this option.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.
        /// </summary>
        public virtual string VersionSuffix { get; internal set; }
        /// <summary>
        ///   Specifies the loggers to use to log events from MSBuild.
        /// </summary>
        public virtual IReadOnlyList<string> Loggers => LoggersInternal.AsReadOnly();
        internal List<string> LoggersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Disable the default console logger, and don't log events to the console.
        /// </summary>
        public virtual bool? NoConsoleLogger { get; internal set; }
        /// <summary>
        ///   Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   Disables restoring multiple projects in parallel.
        /// </summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary>
        ///   Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Only warn about failed sources if there are packages meeting the version requirement.
        /// </summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary>
        ///   Specifies to not cache packages and HTTP requests.
        /// </summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary>
        ///   When restoring a project with project-to-project (P2P) references, restore the root project and not the references.
        /// </summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary>
        ///   Specifies the directory for restored packages.
        /// </summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary>
        ///   Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.
        /// </summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Enables project lock file to be generated and used with restore.
        /// </summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary>
        ///   Don't allow updating project lock file.
        /// </summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary>
        ///   Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.
        /// </summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary>
        ///   Forces restore to reevaluate all dependencies even if a lock file already exists.
        /// </summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("build")
              .Add("{value}", ProjectFile)
              .Add("--configuration {value}", Configuration)
              .Add("--framework {value}", Framework)
              .Add("--no-incremental", NoIncremental)
              .Add("--no-restore", NoRestore)
              .Add("--output {value}", OutputDirectory)
              .Add("--runtime {value}", Runtime)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version-suffix {value}", VersionSuffix)
              .Add("/logger:{value}", Loggers)
              .Add("/noconsolelogger", NoConsoleLogger)
              .Add("--nologo", NoLogo)
              .Add("--disable-parallel", DisableParallel)
              .Add("--force", Force)
              .Add("--ignore-failed-sources", IgnoreFailedSources)
              .Add("--no-cache", NoCache)
              .Add("--no-dependencies", NoDependencies)
              .Add("--packages {value}", PackageDirectory)
              .Add("--source {value}", Sources)
              .Add("--use-lock-file", UseLockFile)
              .Add("--locked-mode", LockedMode)
              .Add("--lock-file-path {value}", LockFilePath)
              .Add("--force-evaluate", ForceEvaluate)
              .Add("/property:{value}", Properties, "{key}={value}", disallowed: ';');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetCleanSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetCleanSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   The MSBuild project to clean. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in <em>proj</em> and uses that file.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Defines the build configuration. The default value is <c>Debug</c>. This option is only required when cleaning if you specified it during build time.
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a> that was specified at build time. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>. If you specified the framework at build time, you must specify the framework when cleaning.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   Directory in which the build outputs are placed. Specify the <c>--framework</c> switch with the output directory switch if you specified the framework when the project was built.
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   Cleans the output folder of the specified runtime. This is used when a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment</a> was created.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed levels are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("clean")
              .Add("{value}", Project)
              .Add("--configuration {value}", Configuration)
              .Add("--framework {value}", Framework)
              .Add("--output {value}", Output)
              .Add("--runtime {value}", Runtime)
              .Add("--verbosity {value}", Verbosity)
              .Add("--nologo", NoLogo)
              .Add("/property:{value}", Properties, "{key}={value}", disallowed: ';');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetPublishSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetPublishSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   The project to publish, which defaults to the current directory if not specified.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Defines the build configuration. The default value is <c>Debug</c>.
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   Publishes the application for the specified <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. You must specify the target framework in the project file.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   Specifies one or several <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/runtime-store">target manifests</a> to use to trim the set of packages published with the app. The manifest file is part of the output of the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-store"><c>dotnet store</c></a> command. To specify multiple manifests, add a <c>--manifest</c> option for each manifest. This option is available starting with .NET Core 2.0 SDK.
        /// </summary>
        public virtual string Manifest { get; internal set; }
        /// <summary>
        ///   Doesn't perform an implicit restore when running the command.
        /// </summary>
        public virtual bool? NoRestore { get; internal set; }
        /// <summary>
        ///   Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.
        /// </summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary>
        ///   Specifies the path for the output directory. If not specified, it defaults to <em>./bin/[configuration]/[framework]/</em> for a framework-dependent deployment or <em>./bin/[configuration]/[framework]/[runtime]</em> for a self-contained deployment.<para/>If a relative path is provided, the output directory generated is relative to the project file location, not to the current working directory.
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.
        /// </summary>
        public virtual bool? SelfContained { get; internal set; }
        /// <summary>
        ///   Publishes the application for a given runtime. This is used when creating a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment (SCD)</a>. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Default is to publish a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#framework-dependent-deployments-fdd">framework-dependent deployment (FDD)</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.
        /// </summary>
        public virtual string VersionSuffix { get; internal set; }
        /// <summary>
        ///   Disables restoring multiple projects in parallel.
        /// </summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary>
        ///   Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Only warn about failed sources if there are packages meeting the version requirement.
        /// </summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary>
        ///   Specifies to not cache packages and HTTP requests.
        /// </summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary>
        ///   When restoring a project with project-to-project (P2P) references, restore the root project and not the references.
        /// </summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary>
        ///   Specifies the directory for restored packages.
        /// </summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary>
        ///   Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.
        /// </summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Enables project lock file to be generated and used with restore.
        /// </summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary>
        ///   Don't allow updating project lock file.
        /// </summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary>
        ///   Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.
        /// </summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary>
        ///   Forces restore to reevaluate all dependencies even if a lock file already exists.
        /// </summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("publish")
              .Add("{value}", Project)
              .Add("--configuration {value}", Configuration)
              .Add("--framework {value}", Framework)
              .Add("--manifest {value}", Manifest)
              .Add("--no-restore", NoRestore)
              .Add("--no-build", NoBuild)
              .Add("--output {value}", Output)
              .Add("--self-contained {value}", SelfContained)
              .Add("--runtime {value}", Runtime)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version-suffix {value}", VersionSuffix)
              .Add("--disable-parallel", DisableParallel)
              .Add("--force", Force)
              .Add("--ignore-failed-sources", IgnoreFailedSources)
              .Add("--no-cache", NoCache)
              .Add("--no-dependencies", NoDependencies)
              .Add("--packages {value}", PackageDirectory)
              .Add("--source {value}", Sources)
              .Add("--use-lock-file", UseLockFile)
              .Add("--locked-mode", LockedMode)
              .Add("--lock-file-path {value}", LockFilePath)
              .Add("--force-evaluate", ForceEvaluate)
              .Add("/property:{value}", Properties, "{key}={value}", disallowed: ';');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetNuGetPushSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetNuGetPushSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   Path of the package to push.
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   Specifies the server URL. This option is required unless <c>DefaultPushSource</c> config value is set in the NuGet config file.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   Specifies the symbol server URL.
        /// </summary>
        public virtual string SymbolSource { get; internal set; }
        /// <summary>
        ///   Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.
        /// </summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary>
        ///   The API key for the server.
        /// </summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary>
        ///   The API key for the symbol server.
        /// </summary>
        public virtual string SymbolApiKey { get; internal set; }
        /// <summary>
        ///   Disables buffering when pushing to an HTTP(S) server to decrease memory usage.
        /// </summary>
        public virtual bool? DisableBuffering { get; internal set; }
        /// <summary>
        ///   Doesn't push symbols (even if present).
        /// </summary>
        public virtual bool? NoSymbols { get; internal set; }
        /// <summary>
        ///   Forces all logged output in English.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   When pushing multiple packages to an HTTP(S) server, treats any 409 Conflict response as a warning so that the push can continue. Available since .NET Core 3.1 SDK.
        /// </summary>
        public virtual bool? SkipDuplicate { get; internal set; }
        /// <summary>
        ///   Doesn't append <c>api/v2/package</c> to the source URL. Option available since .NET Core 2.1 SDK.
        /// </summary>
        public virtual bool? NoServiceEndpoint { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("nuget push")
              .Add("{value}", TargetPath)
              .Add("--source {value}", Source)
              .Add("--symbol-source {value}", SymbolSource)
              .Add("--timeout {value}", Timeout)
              .Add("--api-key {value}", ApiKey, secret: true)
              .Add("--symbol-api-key {value}", SymbolApiKey, secret: true)
              .Add("--disable-buffering", DisableBuffering)
              .Add("--no-symbols", NoSymbols)
              .Add("--force-english-output", ForceEnglishOutput)
              .Add("--skip-duplicate", SkipDuplicate)
              .Add("--no-service-endpoint", NoServiceEndpoint);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetToolInstallSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetToolInstallSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   The Name/ID of the NuGet package that contains the .NET Core Global Tool to install.
        /// </summary>
        public virtual string PackageName { get; internal set; }
        /// <summary>
        ///   Adds an additional NuGet package source to use during installation.
        /// </summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specifies the NuGet configuration (<em>nuget.config</em>) file to use.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Specifies the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a> to install the tool for. By default, the .NET Core SDK tries to choose the most appropriate target framework.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.
        /// </summary>
        public virtual bool? Global { get; internal set; }
        /// <summary>
        ///   Specifies the location where to install the Global Tool. The path can be absolute or relative. If the path doesn't exist, the command tries to create it. Can't be combined with the <c>--global</c> option. If you don't specify this option, you must specify the <c>--global</c> option.
        /// </summary>
        public virtual string ToolInstallationPath { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   The version of the tool to install. By default, the latest stable package version is installed. Use this option to install preview or older versions of the tool.
        /// </summary>
        public virtual string Version { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("tool install")
              .Add("{value}", PackageName)
              .Add("--add-source {value}", Sources)
              .Add("--configfile {value}", ConfigFile)
              .Add("--framework {value}", Framework)
              .Add("--global", Global)
              .Add("--tool-path {value}", ToolInstallationPath)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version {value}", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetToolUninstallSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetToolUninstallSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   The Name/ID of the NuGet package that contains the .NET Core Global Tool to uninstall. You can find the package name using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-list">dotnet tool list</a> command.
        /// </summary>
        public virtual string PackageName { get; internal set; }
        /// <summary>
        ///   Specifies that the tool to be removed is from a user-wide installation. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.
        /// </summary>
        public virtual bool? Global { get; internal set; }
        /// <summary>
        ///   Specifies the location where to uninstall the Global Tool. The path can be absolute or relative. Can't be combined with the <c>--global</c> option. If you don't specify this option, you must specify the <c>--global</c> option.
        /// </summary>
        public virtual string ToolInstallationPath { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("tool uninstall")
              .Add("{value}", PackageName)
              .Add("--global", Global)
              .Add("--tool-path {value}", ToolInstallationPath)
              .Add("--verbosity {value}", Verbosity);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetToolUpdateSettings
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetToolUpdateSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNet executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        public override Action<OutputType, string> CustomLogger => DotNetTasks.DotNetLogger;
        /// <summary>
        ///   The Name/ID of the NuGet package that contains the .NET Core Global Tool to install.
        /// </summary>
        public virtual string PackageName { get; internal set; }
        /// <summary>
        ///   Adds an additional NuGet package source to use during installation.
        /// </summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specifies the NuGet configuration (<em>nuget.config</em>) file to use.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Specifies the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a> to update the tool for.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.
        /// </summary>
        public virtual bool? Global { get; internal set; }
        /// <summary>
        ///   Specifies the location where the Global Tool is installed. The path can be absolute or relative. Can't be combined with the <c>--global</c> option. If you don't specify this option, you must specify the <c>--global</c> option.
        /// </summary>
        public virtual string ToolInstallationPath { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("tool update")
              .Add("{value}", PackageName)
              .Add("--add-source {value}", Sources)
              .Add("--configfile {value}", ConfigFile)
              .Add("--framework {value}", Framework)
              .Add("--global", Global)
              .Add("--tool-path {value}", ToolInstallationPath)
              .Add("--verbosity {value}", Verbosity);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetTestSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetTestSettingsExtensions
    {
        #region ProjectFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.ProjectFile"/></em></p>
        ///   <p>Specifies a path to the test project. If omitted, it defaults to current directory.</p>
        /// </summary>
        [Pure]
        public static T SetProjectFile<T>(this T toolSettings, string projectFile) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.ProjectFile"/></em></p>
        ///   <p>Specifies a path to the test project. If omitted, it defaults to current directory.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectFile<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region TestAdapterPath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.TestAdapterPath"/></em></p>
        ///   <p>Use the custom test adapters from the specified path in the test run.</p>
        /// </summary>
        [Pure]
        public static T SetTestAdapterPath<T>(this T toolSettings, string testAdapterPath) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestAdapterPath = testAdapterPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.TestAdapterPath"/></em></p>
        ///   <p>Use the custom test adapters from the specified path in the test run.</p>
        /// </summary>
        [Pure]
        public static T ResetTestAdapterPath<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestAdapterPath = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Configuration"/></em></p>
        ///   <p>Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting.</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.Configuration"/></em></p>
        ///   <p>Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting.</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region DataCollector
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.DataCollector"/></em></p>
        ///   <p>Enables data collector for the test run. For more information, see <a href="https://aka.ms/vstest-collect">Monitor and analyze test run</a>.</p>
        /// </summary>
        [Pure]
        public static T SetDataCollector<T>(this T toolSettings, string dataCollector) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataCollector = dataCollector;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.DataCollector"/></em></p>
        ///   <p>Enables data collector for the test run. For more information, see <a href="https://aka.ms/vstest-collect">Monitor and analyze test run</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetDataCollector<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataCollector = null;
            return toolSettings;
        }
        #endregion
        #region DiagnosticsFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.DiagnosticsFile"/></em></p>
        ///   <p>Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.</p>
        /// </summary>
        [Pure]
        public static T SetDiagnosticsFile<T>(this T toolSettings, string diagnosticsFile) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiagnosticsFile = diagnosticsFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.DiagnosticsFile"/></em></p>
        ///   <p>Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.</p>
        /// </summary>
        [Pure]
        public static T ResetDiagnosticsFile<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiagnosticsFile = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Framework"/></em></p>
        ///   <p>Looks for test binaries for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>.</p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.Framework"/></em></p>
        ///   <p>Looks for test binaries for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Filter
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Filter"/></em></p>
        ///   <p>Filters out tests in the current project using the given expression. For more information, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests">Running selective unit tests</a>.</p>
        /// </summary>
        [Pure]
        public static T SetFilter<T>(this T toolSettings, string filter) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.Filter"/></em></p>
        ///   <p>Filters out tests in the current project using the given expression. For more information, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests">Running selective unit tests</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetFilter<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
            return toolSettings;
        }
        #endregion
        #region Logger
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Logger"/></em></p>
        ///   <p>Specifies a logger for test results.</p>
        /// </summary>
        [Pure]
        public static T SetLogger<T>(this T toolSettings, string logger) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logger = logger;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.Logger"/></em></p>
        ///   <p>Specifies a logger for test results.</p>
        /// </summary>
        [Pure]
        public static T ResetLogger<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logger = null;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.NoBuild"/></em></p>
        ///   <p>Does not build the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static T SetNoBuild<T>(this T toolSettings, bool? noBuild) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.NoBuild"/></em></p>
        ///   <p>Does not build the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static T ResetNoBuild<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.NoBuild"/></em></p>
        ///   <p>Does not build the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static T EnableNoBuild<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.NoBuild"/></em></p>
        ///   <p>Does not build the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static T DisableNoBuild<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.NoBuild"/></em></p>
        ///   <p>Does not build the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoBuild<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region NoRestore
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T SetNoRestore<T>(this T toolSettings, bool? noRestore) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = noRestore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T ResetNoRestore<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T EnableNoRestore<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T DisableNoRestore<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoRestore<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = !toolSettings.NoRestore;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Output"/></em></p>
        ///   <p>Directory in which to find the binaries to run.</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.Output"/></em></p>
        ///   <p>Directory in which to find the binaries to run.</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region ResultsDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.ResultsDirectory"/></em></p>
        ///   <p>The directory where the test results are going to be placed. The specified directory will be created if it doesn't exist.</p>
        /// </summary>
        [Pure]
        public static T SetResultsDirectory<T>(this T toolSettings, string resultsDirectory) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsDirectory = resultsDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.ResultsDirectory"/></em></p>
        ///   <p>The directory where the test results are going to be placed. The specified directory will be created if it doesn't exist.</p>
        /// </summary>
        [Pure]
        public static T ResetResultsDirectory<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsDirectory = null;
            return toolSettings;
        }
        #endregion
        #region SettingsFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.SettingsFile"/></em></p>
        ///   <p>Settings to use when running tests.</p>
        /// </summary>
        [Pure]
        public static T SetSettingsFile<T>(this T toolSettings, string settingsFile) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SettingsFile = settingsFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.SettingsFile"/></em></p>
        ///   <p>Settings to use when running tests.</p>
        /// </summary>
        [Pure]
        public static T ResetSettingsFile<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SettingsFile = null;
            return toolSettings;
        }
        #endregion
        #region ListTests
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.ListTests"/></em></p>
        ///   <p>List all of the discovered tests in the current project.</p>
        /// </summary>
        [Pure]
        public static T SetListTests<T>(this T toolSettings, bool? listTests) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListTests = listTests;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.ListTests"/></em></p>
        ///   <p>List all of the discovered tests in the current project.</p>
        /// </summary>
        [Pure]
        public static T ResetListTests<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListTests = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.ListTests"/></em></p>
        ///   <p>List all of the discovered tests in the current project.</p>
        /// </summary>
        [Pure]
        public static T EnableListTests<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListTests = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.ListTests"/></em></p>
        ///   <p>List all of the discovered tests in the current project.</p>
        /// </summary>
        [Pure]
        public static T DisableListTests<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListTests = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.ListTests"/></em></p>
        ///   <p>List all of the discovered tests in the current project.</p>
        /// </summary>
        [Pure]
        public static T ToggleListTests<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListTests = !toolSettings.ListTests;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, DotNetVerbosity verbosity) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="DotNetTestSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
        #region BlameMode
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.BlameMode"/></em></p>
        ///   <p>Runs the tests in blame mode. This option is helpful in isolating the problematic tests causing test host to crash. It creates an output file in the current directory as <em>Sequence.xml</em> that captures the order of tests execution before the crash.</p>
        /// </summary>
        [Pure]
        public static T SetBlameMode<T>(this T toolSettings, bool? blameMode) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BlameMode = blameMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.BlameMode"/></em></p>
        ///   <p>Runs the tests in blame mode. This option is helpful in isolating the problematic tests causing test host to crash. It creates an output file in the current directory as <em>Sequence.xml</em> that captures the order of tests execution before the crash.</p>
        /// </summary>
        [Pure]
        public static T ResetBlameMode<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BlameMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.BlameMode"/></em></p>
        ///   <p>Runs the tests in blame mode. This option is helpful in isolating the problematic tests causing test host to crash. It creates an output file in the current directory as <em>Sequence.xml</em> that captures the order of tests execution before the crash.</p>
        /// </summary>
        [Pure]
        public static T EnableBlameMode<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BlameMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.BlameMode"/></em></p>
        ///   <p>Runs the tests in blame mode. This option is helpful in isolating the problematic tests causing test host to crash. It creates an output file in the current directory as <em>Sequence.xml</em> that captures the order of tests execution before the crash.</p>
        /// </summary>
        [Pure]
        public static T DisableBlameMode<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BlameMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.BlameMode"/></em></p>
        ///   <p>Runs the tests in blame mode. This option is helpful in isolating the problematic tests causing test host to crash. It creates an output file in the current directory as <em>Sequence.xml</em> that captures the order of tests execution before the crash.</p>
        /// </summary>
        [Pure]
        public static T ToggleBlameMode<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BlameMode = !toolSettings.BlameMode;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T SetDisableParallel<T>(this T toolSettings, bool? disableParallel) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableParallel<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableParallel<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableParallel<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableParallel<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreFailedSources<T>(this T toolSettings, bool? ignoreFailedSources) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreFailedSources<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreFailedSources<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T SetNoCache<T>(this T toolSettings, bool? noCache) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ResetNoCache<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T EnableNoCache<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T DisableNoCache<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoCache<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T SetNoDependencies<T>(this T toolSettings, bool? noDependencies) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ResetNoDependencies<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T EnableNoDependencies<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T DisableNoDependencies<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoDependencies<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T SetPackageDirectory<T>(this T toolSettings, string packageDirectory) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageDirectory<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, params string[] sources) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetTestSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, params string[] sources) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetTestSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetTestSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ClearSources<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetTestSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, params string[] sources) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetTestSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T SetUseLockFile<T>(this T toolSettings, bool? useLockFile) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ResetUseLockFile<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T EnableUseLockFile<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T DisableUseLockFile<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseLockFile<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T SetLockedMode<T>(this T toolSettings, bool? lockedMode) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ResetLockedMode<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T EnableLockedMode<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T DisableLockedMode<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ToggleLockedMode<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T SetLockFilePath<T>(this T toolSettings, string lockFilePath) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T ResetLockFilePath<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T SetForceEvaluate<T>(this T toolSettings, bool? forceEvaluate) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEvaluate<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetTestSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEvaluate<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetTestSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEvaluate<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetTestSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEvaluate<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetTestSettings.Runtime"/></em></p>
        ///   <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetRuntime<T>(this T toolSettings, string runtime) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetTestSettings.Runtime"/></em></p>
        ///   <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ResetRuntime<T>(this T toolSettings) where T : DotNetTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetRunSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetRunSettingsExtensions
    {
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.Configuration"/></em></p>
        ///   <p>Configuration to use for building the project. The default value is Debug.</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.Configuration"/></em></p>
        ///   <p>Configuration to use for building the project. The default value is Debug.</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.Framework"/></em></p>
        ///   <p>Builds and runs the app using the specified framework. The framework must be specified in the project file.</p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.Framework"/></em></p>
        ///   <p>Builds and runs the app using the specified framework. The framework must be specified in the project file.</p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region LaunchProfile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.LaunchProfile"/></em></p>
        ///   <p>The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the <em>launchSettings.json</em> file and are typically called <c>Development</c>, <c>Staging</c> and <c>Production</c>. For more information, see <a href="https://docs.microsoft.com/en-us/aspnetcore/fundamentals/environments">Working with multiple environments</a>.</p>
        /// </summary>
        [Pure]
        public static T SetLaunchProfile<T>(this T toolSettings, string launchProfile) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LaunchProfile = launchProfile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.LaunchProfile"/></em></p>
        ///   <p>The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the <em>launchSettings.json</em> file and are typically called <c>Development</c>, <c>Staging</c> and <c>Production</c>. For more information, see <a href="https://docs.microsoft.com/en-us/aspnetcore/fundamentals/environments">Working with multiple environments</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetLaunchProfile<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LaunchProfile = null;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before running.</p>
        /// </summary>
        [Pure]
        public static T SetNoBuild<T>(this T toolSettings, bool? noBuild) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before running.</p>
        /// </summary>
        [Pure]
        public static T ResetNoBuild<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before running.</p>
        /// </summary>
        [Pure]
        public static T EnableNoBuild<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before running.</p>
        /// </summary>
        [Pure]
        public static T DisableNoBuild<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before running.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoBuild<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region NoLaunchProfile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.NoLaunchProfile"/></em></p>
        ///   <p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p>
        /// </summary>
        [Pure]
        public static T SetNoLaunchProfile<T>(this T toolSettings, bool? noLaunchProfile) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLaunchProfile = noLaunchProfile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.NoLaunchProfile"/></em></p>
        ///   <p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p>
        /// </summary>
        [Pure]
        public static T ResetNoLaunchProfile<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLaunchProfile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.NoLaunchProfile"/></em></p>
        ///   <p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p>
        /// </summary>
        [Pure]
        public static T EnableNoLaunchProfile<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLaunchProfile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.NoLaunchProfile"/></em></p>
        ///   <p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p>
        /// </summary>
        [Pure]
        public static T DisableNoLaunchProfile<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLaunchProfile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.NoLaunchProfile"/></em></p>
        ///   <p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoLaunchProfile<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLaunchProfile = !toolSettings.NoLaunchProfile;
            return toolSettings;
        }
        #endregion
        #region NoRestore
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T SetNoRestore<T>(this T toolSettings, bool? noRestore) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = noRestore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T ResetNoRestore<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T EnableNoRestore<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T DisableNoRestore<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoRestore<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = !toolSettings.NoRestore;
            return toolSettings;
        }
        #endregion
        #region ProjectFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.ProjectFile"/></em></p>
        ///   <p>Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.</p>
        /// </summary>
        [Pure]
        public static T SetProjectFile<T>(this T toolSettings, string projectFile) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.ProjectFile"/></em></p>
        ///   <p>Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectFile<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region ApplicationArguments
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.ApplicationArguments"/></em></p>
        ///   <p>Arguments passed to the application being run.</p>
        /// </summary>
        [Pure]
        public static T SetApplicationArguments<T>(this T toolSettings, string applicationArguments) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApplicationArguments = applicationArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.ApplicationArguments"/></em></p>
        ///   <p>Arguments passed to the application being run.</p>
        /// </summary>
        [Pure]
        public static T ResetApplicationArguments<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApplicationArguments = null;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T SetDisableParallel<T>(this T toolSettings, bool? disableParallel) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableParallel<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableParallel<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableParallel<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableParallel<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreFailedSources<T>(this T toolSettings, bool? ignoreFailedSources) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreFailedSources<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreFailedSources<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T SetNoCache<T>(this T toolSettings, bool? noCache) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ResetNoCache<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T EnableNoCache<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T DisableNoCache<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoCache<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T SetNoDependencies<T>(this T toolSettings, bool? noDependencies) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ResetNoDependencies<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T EnableNoDependencies<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T DisableNoDependencies<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoDependencies<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T SetPackageDirectory<T>(this T toolSettings, string packageDirectory) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageDirectory<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, params string[] sources) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetRunSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, params string[] sources) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetRunSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetRunSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ClearSources<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetRunSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, params string[] sources) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetRunSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T SetUseLockFile<T>(this T toolSettings, bool? useLockFile) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ResetUseLockFile<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T EnableUseLockFile<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T DisableUseLockFile<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseLockFile<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T SetLockedMode<T>(this T toolSettings, bool? lockedMode) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ResetLockedMode<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T EnableLockedMode<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T DisableLockedMode<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ToggleLockedMode<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T SetLockFilePath<T>(this T toolSettings, string lockFilePath) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T ResetLockFilePath<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T SetForceEvaluate<T>(this T toolSettings, bool? forceEvaluate) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEvaluate<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRunSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEvaluate<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRunSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEvaluate<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRunSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEvaluate<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.Runtime"/></em></p>
        ///   <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetRuntime<T>(this T toolSettings, string runtime) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRunSettings.Runtime"/></em></p>
        ///   <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ResetRuntime<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRunSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary>
        ///   <p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRunCodeAnalysis<T>(this T toolSettings, bool? runCodeAnalysis) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRunCodeAnalysis<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleRunCodeAnalysis<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearNoWarns<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearWarningsAsErrors<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary>
        ///   <p><em>Sets <c>WarningLevel</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningLevel<T>(this T toolSettings, int? warningLevel) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>WarningLevel</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetWarningLevel<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTreatWarningsAsErrors<T>(this T toolSettings, bool? treatWarningsAsErrors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary>
        ///   <p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAssemblyVersion<T>(this T toolSettings, string assemblyVersion) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetAssemblyVersion<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary>
        ///   <p><em>Sets <c>FileVersion</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetFileVersion<T>(this T toolSettings, string fileVersion) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>FileVersion</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetFileVersion<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary>
        ///   <p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetInformationalVersion<T>(this T toolSettings, string informationalVersion) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetInformationalVersion<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #region PackageId
        /// <summary>
        ///   <p><em>Sets <c>PackageId</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageId<T>(this T toolSettings, string packageId) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageId"] = packageId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageId</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageId<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageId");
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <c>Version</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Version"] = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Version</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Version");
            return toolSettings;
        }
        #endregion
        #region VersionPrefix
        /// <summary>
        ///   <p><em>Sets <c>VersionPrefix</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersionPrefix<T>(this T toolSettings, string versionPrefix) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["VersionPrefix"] = versionPrefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>VersionPrefix</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersionPrefix<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("VersionPrefix");
            return toolSettings;
        }
        #endregion
        #region Authors
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in existing <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>Authors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearAuthors<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Authors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        #endregion
        #region Title
        /// <summary>
        ///   <p><em>Sets <c>Title</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTitle<T>(this T toolSettings, string title) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Title"] = title;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Title</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTitle<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Title");
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <c>Description</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Description"] = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Description</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Description");
            return toolSettings;
        }
        #endregion
        #region Copyright
        /// <summary>
        ///   <p><em>Sets <c>Copyright</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetCopyright<T>(this T toolSettings, string copyright) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Copyright"] = copyright;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Copyright</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetCopyright<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Copyright");
            return toolSettings;
        }
        #endregion
        #region PackageRequireLicenseAcceptance
        /// <summary>
        ///   <p><em>Sets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageRequireLicenseAcceptance<T>(this T toolSettings, bool? packageRequireLicenseAcceptance) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = packageRequireLicenseAcceptance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T TogglePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        #endregion
        #region PackageLicenseUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageLicenseUrl</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageLicenseUrl<T>(this T toolSettings, string packageLicenseUrl) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageLicenseUrl"] = packageLicenseUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageLicenseUrl</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageLicenseUrl<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageLicenseUrl");
            return toolSettings;
        }
        #endregion
        #region PackageProjectUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageProjectUrl</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageProjectUrl<T>(this T toolSettings, string packageProjectUrl) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageProjectUrl"] = packageProjectUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageProjectUrl</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageProjectUrl<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageProjectUrl");
            return toolSettings;
        }
        #endregion
        #region PackageIconUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageIconUrl</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageIconUrl<T>(this T toolSettings, string packageIconUrl) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageIconUrl"] = packageIconUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageIconUrl</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageIconUrl<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageIconUrl");
            return toolSettings;
        }
        #endregion
        #region PackageTags
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in existing <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>PackageTags</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearPackageTags<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageTags");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        #endregion
        #region PackageReleaseNotes
        /// <summary>
        ///   <p><em>Sets <c>PackageReleaseNotes</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageReleaseNotes<T>(this T toolSettings, string packageReleaseNotes) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageReleaseNotes"] = packageReleaseNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageReleaseNotes</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageReleaseNotes<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageReleaseNotes");
            return toolSettings;
        }
        #endregion
        #region RepositoryUrl
        /// <summary>
        ///   <p><em>Sets <c>RepositoryUrl</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryUrl<T>(this T toolSettings, string repositoryUrl) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryUrl"] = repositoryUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryUrl</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryUrl<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryUrl");
            return toolSettings;
        }
        #endregion
        #region RepositoryType
        /// <summary>
        ///   <p><em>Sets <c>RepositoryType</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryType<T>(this T toolSettings, string repositoryType) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryType"] = repositoryType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryType</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryType<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryType");
            return toolSettings;
        }
        #endregion
        #region SymbolPackageFormat
        /// <summary>
        ///   <p><em>Sets <c>SymbolPackageFormat</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolPackageFormat<T>(this T toolSettings, DotNetSymbolPackageFormat symbolPackageFormat) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["SymbolPackageFormat"] = symbolPackageFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>SymbolPackageFormat</c> in <see cref="DotNetRunSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolPackageFormat<T>(this T toolSettings) where T : DotNetRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("SymbolPackageFormat");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetRestoreSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetRestoreSettingsExtensions
    {
        #region ProjectFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.ProjectFile"/></em></p>
        ///   <p>Optional path to the project file to restore.</p>
        /// </summary>
        [Pure]
        public static T SetProjectFile<T>(this T toolSettings, string projectFile) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.ProjectFile"/></em></p>
        ///   <p>Optional path to the project file to restore.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectFile<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file (<em>NuGet.config</em>) to use for the restore operation.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file (<em>NuGet.config</em>) to use for the restore operation.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, DotNetVerbosity verbosity) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T SetDisableParallel<T>(this T toolSettings, bool? disableParallel) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableParallel<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRestoreSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableParallel<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRestoreSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableParallel<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRestoreSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableParallel<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRestoreSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRestoreSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRestoreSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreFailedSources<T>(this T toolSettings, bool? ignoreFailedSources) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreFailedSources<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRestoreSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRestoreSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRestoreSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreFailedSources<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T SetNoCache<T>(this T toolSettings, bool? noCache) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ResetNoCache<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRestoreSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T EnableNoCache<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRestoreSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T DisableNoCache<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRestoreSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoCache<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T SetNoDependencies<T>(this T toolSettings, bool? noDependencies) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ResetNoDependencies<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRestoreSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T EnableNoDependencies<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRestoreSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T DisableNoDependencies<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRestoreSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoDependencies<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T SetPackageDirectory<T>(this T toolSettings, string packageDirectory) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageDirectory<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, params string[] sources) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetRestoreSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, params string[] sources) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetRestoreSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetRestoreSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ClearSources<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetRestoreSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, params string[] sources) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetRestoreSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T SetUseLockFile<T>(this T toolSettings, bool? useLockFile) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ResetUseLockFile<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRestoreSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T EnableUseLockFile<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRestoreSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T DisableUseLockFile<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRestoreSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseLockFile<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T SetLockedMode<T>(this T toolSettings, bool? lockedMode) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ResetLockedMode<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRestoreSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T EnableLockedMode<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRestoreSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T DisableLockedMode<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRestoreSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ToggleLockedMode<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T SetLockFilePath<T>(this T toolSettings, string lockFilePath) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T ResetLockFilePath<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T SetForceEvaluate<T>(this T toolSettings, bool? forceEvaluate) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEvaluate<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetRestoreSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEvaluate<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetRestoreSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEvaluate<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetRestoreSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEvaluate<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.Runtime"/></em></p>
        ///   <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetRuntime<T>(this T toolSettings, string runtime) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetRestoreSettings.Runtime"/></em></p>
        ///   <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ResetRuntime<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetRestoreSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary>
        ///   <p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRunCodeAnalysis<T>(this T toolSettings, bool? runCodeAnalysis) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRunCodeAnalysis<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleRunCodeAnalysis<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetRestoreSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetRestoreSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>NoWarn</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearNoWarns<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearWarningsAsErrors<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary>
        ///   <p><em>Sets <c>WarningLevel</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningLevel<T>(this T toolSettings, int? warningLevel) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>WarningLevel</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetWarningLevel<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTreatWarningsAsErrors<T>(this T toolSettings, bool? treatWarningsAsErrors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary>
        ///   <p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAssemblyVersion<T>(this T toolSettings, string assemblyVersion) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetAssemblyVersion<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary>
        ///   <p><em>Sets <c>FileVersion</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetFileVersion<T>(this T toolSettings, string fileVersion) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>FileVersion</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetFileVersion<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary>
        ///   <p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetInformationalVersion<T>(this T toolSettings, string informationalVersion) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetInformationalVersion<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #region PackageId
        /// <summary>
        ///   <p><em>Sets <c>PackageId</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageId<T>(this T toolSettings, string packageId) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageId"] = packageId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageId</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageId<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageId");
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <c>Version</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Version"] = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Version</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Version");
            return toolSettings;
        }
        #endregion
        #region VersionPrefix
        /// <summary>
        ///   <p><em>Sets <c>VersionPrefix</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersionPrefix<T>(this T toolSettings, string versionPrefix) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["VersionPrefix"] = versionPrefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>VersionPrefix</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersionPrefix<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("VersionPrefix");
            return toolSettings;
        }
        #endregion
        #region Authors
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetRestoreSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetRestoreSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in existing <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>Authors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearAuthors<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Authors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        #endregion
        #region Title
        /// <summary>
        ///   <p><em>Sets <c>Title</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTitle<T>(this T toolSettings, string title) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Title"] = title;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Title</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTitle<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Title");
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <c>Description</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Description"] = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Description</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Description");
            return toolSettings;
        }
        #endregion
        #region Copyright
        /// <summary>
        ///   <p><em>Sets <c>Copyright</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetCopyright<T>(this T toolSettings, string copyright) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Copyright"] = copyright;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Copyright</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetCopyright<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Copyright");
            return toolSettings;
        }
        #endregion
        #region PackageRequireLicenseAcceptance
        /// <summary>
        ///   <p><em>Sets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageRequireLicenseAcceptance<T>(this T toolSettings, bool? packageRequireLicenseAcceptance) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = packageRequireLicenseAcceptance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T TogglePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        #endregion
        #region PackageLicenseUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageLicenseUrl</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageLicenseUrl<T>(this T toolSettings, string packageLicenseUrl) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageLicenseUrl"] = packageLicenseUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageLicenseUrl</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageLicenseUrl<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageLicenseUrl");
            return toolSettings;
        }
        #endregion
        #region PackageProjectUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageProjectUrl</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageProjectUrl<T>(this T toolSettings, string packageProjectUrl) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageProjectUrl"] = packageProjectUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageProjectUrl</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageProjectUrl<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageProjectUrl");
            return toolSettings;
        }
        #endregion
        #region PackageIconUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageIconUrl</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageIconUrl<T>(this T toolSettings, string packageIconUrl) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageIconUrl"] = packageIconUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageIconUrl</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageIconUrl<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageIconUrl");
            return toolSettings;
        }
        #endregion
        #region PackageTags
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetRestoreSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetRestoreSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in existing <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>PackageTags</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearPackageTags<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageTags");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        #endregion
        #region PackageReleaseNotes
        /// <summary>
        ///   <p><em>Sets <c>PackageReleaseNotes</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageReleaseNotes<T>(this T toolSettings, string packageReleaseNotes) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageReleaseNotes"] = packageReleaseNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageReleaseNotes</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageReleaseNotes<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageReleaseNotes");
            return toolSettings;
        }
        #endregion
        #region RepositoryUrl
        /// <summary>
        ///   <p><em>Sets <c>RepositoryUrl</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryUrl<T>(this T toolSettings, string repositoryUrl) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryUrl"] = repositoryUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryUrl</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryUrl<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryUrl");
            return toolSettings;
        }
        #endregion
        #region RepositoryType
        /// <summary>
        ///   <p><em>Sets <c>RepositoryType</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryType<T>(this T toolSettings, string repositoryType) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryType"] = repositoryType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryType</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryType<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryType");
            return toolSettings;
        }
        #endregion
        #region SymbolPackageFormat
        /// <summary>
        ///   <p><em>Sets <c>SymbolPackageFormat</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolPackageFormat<T>(this T toolSettings, DotNetSymbolPackageFormat symbolPackageFormat) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["SymbolPackageFormat"] = symbolPackageFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>SymbolPackageFormat</c> in <see cref="DotNetRestoreSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolPackageFormat<T>(this T toolSettings) where T : DotNetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("SymbolPackageFormat");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetPackSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetPackSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.Project"/></em></p>
        ///   <p>The project to pack. It's either a path to a csproj file or to a directory. If omitted, it defaults to the current directory.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.Project"/></em></p>
        ///   <p>The project to pack. It's either a path to a csproj file or to a directory. If omitted, it defaults to the current directory.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.Configuration"/></em></p>
        ///   <p>Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>.</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.Configuration"/></em></p>
        ///   <p>Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region IncludeSource
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.IncludeSource"/></em></p>
        ///   <p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T SetIncludeSource<T>(this T toolSettings, bool? includeSource) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSource = includeSource;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.IncludeSource"/></em></p>
        ///   <p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetIncludeSource<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSource = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.IncludeSource"/></em></p>
        ///   <p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableIncludeSource<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSource = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.IncludeSource"/></em></p>
        ///   <p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableIncludeSource<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSource = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.IncludeSource"/></em></p>
        ///   <p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleIncludeSource<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSource = !toolSettings.IncludeSource;
            return toolSettings;
        }
        #endregion
        #region IncludeSymbols
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.IncludeSymbols"/></em></p>
        ///   <p>Generates the symbols <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T SetIncludeSymbols<T>(this T toolSettings, bool? includeSymbols) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSymbols = includeSymbols;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.IncludeSymbols"/></em></p>
        ///   <p>Generates the symbols <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetIncludeSymbols<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSymbols = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.IncludeSymbols"/></em></p>
        ///   <p>Generates the symbols <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableIncludeSymbols<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSymbols = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.IncludeSymbols"/></em></p>
        ///   <p>Generates the symbols <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableIncludeSymbols<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSymbols = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.IncludeSymbols"/></em></p>
        ///   <p>Generates the symbols <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleIncludeSymbols<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSymbols = !toolSettings.IncludeSymbols;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.NoBuild"/></em></p>
        ///   <p>Don't build the project before packing.</p>
        /// </summary>
        [Pure]
        public static T SetNoBuild<T>(this T toolSettings, bool? noBuild) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.NoBuild"/></em></p>
        ///   <p>Don't build the project before packing.</p>
        /// </summary>
        [Pure]
        public static T ResetNoBuild<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.NoBuild"/></em></p>
        ///   <p>Don't build the project before packing.</p>
        /// </summary>
        [Pure]
        public static T EnableNoBuild<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.NoBuild"/></em></p>
        ///   <p>Don't build the project before packing.</p>
        /// </summary>
        [Pure]
        public static T DisableNoBuild<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.NoBuild"/></em></p>
        ///   <p>Don't build the project before packing.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoBuild<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region NoRestore
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T SetNoRestore<T>(this T toolSettings, bool? noRestore) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = noRestore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T ResetNoRestore<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T EnableNoRestore<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T DisableNoRestore<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoRestore<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = !toolSettings.NoRestore;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.OutputDirectory"/></em></p>
        ///   <p>Places the built packages in the directory specified.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDirectory<T>(this T toolSettings, string outputDirectory) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.OutputDirectory"/></em></p>
        ///   <p>Places the built packages in the directory specified.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDirectory<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Serviceable
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.Serviceable"/></em></p>
        ///   <p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p>
        /// </summary>
        [Pure]
        public static T SetServiceable<T>(this T toolSettings, bool? serviceable) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serviceable = serviceable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.Serviceable"/></em></p>
        ///   <p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetServiceable<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serviceable = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.Serviceable"/></em></p>
        ///   <p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableServiceable<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serviceable = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.Serviceable"/></em></p>
        ///   <p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableServiceable<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serviceable = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.Serviceable"/></em></p>
        ///   <p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleServiceable<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serviceable = !toolSettings.Serviceable;
            return toolSettings;
        }
        #endregion
        #region Verbostiy
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.Verbostiy"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbostiy<T>(this T toolSettings, DotNetVerbosity verbostiy) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbostiy = verbostiy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.Verbostiy"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbostiy<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbostiy = null;
            return toolSettings;
        }
        #endregion
        #region VersionSuffix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.VersionSuffix"/></em></p>
        ///   <p>Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project.</p>
        /// </summary>
        [Pure]
        public static T SetVersionSuffix<T>(this T toolSettings, string versionSuffix) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = versionSuffix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.VersionSuffix"/></em></p>
        ///   <p>Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project.</p>
        /// </summary>
        [Pure]
        public static T ResetVersionSuffix<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = null;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T SetNoLogo<T>(this T toolSettings, bool? noLogo) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T ResetNoLogo<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T EnableNoLogo<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T DisableNoLogo<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoLogo<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T SetDisableParallel<T>(this T toolSettings, bool? disableParallel) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableParallel<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableParallel<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableParallel<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableParallel<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreFailedSources<T>(this T toolSettings, bool? ignoreFailedSources) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreFailedSources<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreFailedSources<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T SetNoCache<T>(this T toolSettings, bool? noCache) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ResetNoCache<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T EnableNoCache<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T DisableNoCache<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoCache<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T SetNoDependencies<T>(this T toolSettings, bool? noDependencies) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ResetNoDependencies<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T EnableNoDependencies<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T DisableNoDependencies<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoDependencies<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T SetPackageDirectory<T>(this T toolSettings, string packageDirectory) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageDirectory<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, params string[] sources) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetPackSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, params string[] sources) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetPackSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetPackSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ClearSources<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetPackSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, params string[] sources) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetPackSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T SetUseLockFile<T>(this T toolSettings, bool? useLockFile) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ResetUseLockFile<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T EnableUseLockFile<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T DisableUseLockFile<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseLockFile<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T SetLockedMode<T>(this T toolSettings, bool? lockedMode) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ResetLockedMode<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T EnableLockedMode<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T DisableLockedMode<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ToggleLockedMode<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T SetLockFilePath<T>(this T toolSettings, string lockFilePath) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T ResetLockFilePath<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T SetForceEvaluate<T>(this T toolSettings, bool? forceEvaluate) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEvaluate<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPackSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEvaluate<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPackSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEvaluate<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPackSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEvaluate<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.Runtime"/></em></p>
        ///   <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetRuntime<T>(this T toolSettings, string runtime) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPackSettings.Runtime"/></em></p>
        ///   <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ResetRuntime<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPackSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary>
        ///   <p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRunCodeAnalysis<T>(this T toolSettings, bool? runCodeAnalysis) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRunCodeAnalysis<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleRunCodeAnalysis<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearNoWarns<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearWarningsAsErrors<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary>
        ///   <p><em>Sets <c>WarningLevel</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningLevel<T>(this T toolSettings, int? warningLevel) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>WarningLevel</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetWarningLevel<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTreatWarningsAsErrors<T>(this T toolSettings, bool? treatWarningsAsErrors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary>
        ///   <p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAssemblyVersion<T>(this T toolSettings, string assemblyVersion) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetAssemblyVersion<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary>
        ///   <p><em>Sets <c>FileVersion</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetFileVersion<T>(this T toolSettings, string fileVersion) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>FileVersion</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetFileVersion<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary>
        ///   <p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetInformationalVersion<T>(this T toolSettings, string informationalVersion) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetInformationalVersion<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #region PackageId
        /// <summary>
        ///   <p><em>Sets <c>PackageId</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageId<T>(this T toolSettings, string packageId) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageId"] = packageId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageId</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageId<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageId");
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <c>Version</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Version"] = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Version</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Version");
            return toolSettings;
        }
        #endregion
        #region VersionPrefix
        /// <summary>
        ///   <p><em>Sets <c>VersionPrefix</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersionPrefix<T>(this T toolSettings, string versionPrefix) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["VersionPrefix"] = versionPrefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>VersionPrefix</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersionPrefix<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("VersionPrefix");
            return toolSettings;
        }
        #endregion
        #region Authors
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in existing <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearAuthors<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Authors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        #endregion
        #region Title
        /// <summary>
        ///   <p><em>Sets <c>Title</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTitle<T>(this T toolSettings, string title) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Title"] = title;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Title</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTitle<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Title");
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <c>Description</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Description"] = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Description</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Description");
            return toolSettings;
        }
        #endregion
        #region Copyright
        /// <summary>
        ///   <p><em>Sets <c>Copyright</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetCopyright<T>(this T toolSettings, string copyright) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Copyright"] = copyright;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Copyright</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetCopyright<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Copyright");
            return toolSettings;
        }
        #endregion
        #region PackageRequireLicenseAcceptance
        /// <summary>
        ///   <p><em>Sets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageRequireLicenseAcceptance<T>(this T toolSettings, bool? packageRequireLicenseAcceptance) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = packageRequireLicenseAcceptance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T TogglePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        #endregion
        #region PackageLicenseUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageLicenseUrl</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageLicenseUrl<T>(this T toolSettings, string packageLicenseUrl) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageLicenseUrl"] = packageLicenseUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageLicenseUrl</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageLicenseUrl<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageLicenseUrl");
            return toolSettings;
        }
        #endregion
        #region PackageProjectUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageProjectUrl</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageProjectUrl<T>(this T toolSettings, string packageProjectUrl) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageProjectUrl"] = packageProjectUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageProjectUrl</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageProjectUrl<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageProjectUrl");
            return toolSettings;
        }
        #endregion
        #region PackageIconUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageIconUrl</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageIconUrl<T>(this T toolSettings, string packageIconUrl) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageIconUrl"] = packageIconUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageIconUrl</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageIconUrl<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageIconUrl");
            return toolSettings;
        }
        #endregion
        #region PackageTags
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in existing <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearPackageTags<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageTags");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        #endregion
        #region PackageReleaseNotes
        /// <summary>
        ///   <p><em>Sets <c>PackageReleaseNotes</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageReleaseNotes<T>(this T toolSettings, string packageReleaseNotes) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageReleaseNotes"] = packageReleaseNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageReleaseNotes</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageReleaseNotes<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageReleaseNotes");
            return toolSettings;
        }
        #endregion
        #region RepositoryUrl
        /// <summary>
        ///   <p><em>Sets <c>RepositoryUrl</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryUrl<T>(this T toolSettings, string repositoryUrl) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryUrl"] = repositoryUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryUrl</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryUrl<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryUrl");
            return toolSettings;
        }
        #endregion
        #region RepositoryType
        /// <summary>
        ///   <p><em>Sets <c>RepositoryType</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryType<T>(this T toolSettings, string repositoryType) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryType"] = repositoryType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryType</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryType<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryType");
            return toolSettings;
        }
        #endregion
        #region SymbolPackageFormat
        /// <summary>
        ///   <p><em>Sets <c>SymbolPackageFormat</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolPackageFormat<T>(this T toolSettings, DotNetSymbolPackageFormat symbolPackageFormat) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["SymbolPackageFormat"] = symbolPackageFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>SymbolPackageFormat</c> in <see cref="DotNetPackSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolPackageFormat<T>(this T toolSettings) where T : DotNetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("SymbolPackageFormat");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetBuildSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetBuildSettingsExtensions
    {
        #region ProjectFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.ProjectFile"/></em></p>
        ///   <p>The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p>
        /// </summary>
        [Pure]
        public static T SetProjectFile<T>(this T toolSettings, string projectFile) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.ProjectFile"/></em></p>
        ///   <p>The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectFile<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.Configuration"/></em></p>
        ///   <p>Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.Configuration"/></em></p>
        ///   <p>Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.Framework"/></em></p>
        ///   <p>Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.</p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.Framework"/></em></p>
        ///   <p>Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region NoIncremental
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.NoIncremental"/></em></p>
        ///   <p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p>
        /// </summary>
        [Pure]
        public static T SetNoIncremental<T>(this T toolSettings, bool? noIncremental) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoIncremental = noIncremental;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.NoIncremental"/></em></p>
        ///   <p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p>
        /// </summary>
        [Pure]
        public static T ResetNoIncremental<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoIncremental = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.NoIncremental"/></em></p>
        ///   <p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p>
        /// </summary>
        [Pure]
        public static T EnableNoIncremental<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoIncremental = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.NoIncremental"/></em></p>
        ///   <p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p>
        /// </summary>
        [Pure]
        public static T DisableNoIncremental<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoIncremental = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.NoIncremental"/></em></p>
        ///   <p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoIncremental<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoIncremental = !toolSettings.NoIncremental;
            return toolSettings;
        }
        #endregion
        #region NoRestore
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore during build.</p>
        /// </summary>
        [Pure]
        public static T SetNoRestore<T>(this T toolSettings, bool? noRestore) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = noRestore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore during build.</p>
        /// </summary>
        [Pure]
        public static T ResetNoRestore<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore during build.</p>
        /// </summary>
        [Pure]
        public static T EnableNoRestore<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore during build.</p>
        /// </summary>
        [Pure]
        public static T DisableNoRestore<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore during build.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoRestore<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = !toolSettings.NoRestore;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.OutputDirectory"/></em></p>
        ///   <p>Directory in which to place the built binaries. You also need to define <c>--framework</c> when you specify this option.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDirectory<T>(this T toolSettings, string outputDirectory) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.OutputDirectory"/></em></p>
        ///   <p>Directory in which to place the built binaries. You also need to define <c>--framework</c> when you specify this option.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDirectory<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.Runtime"/></em></p>
        ///   <p>Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static T SetRuntime<T>(this T toolSettings, string runtime) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.Runtime"/></em></p>
        ///   <p>Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetRuntime<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, DotNetVerbosity verbosity) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region VersionSuffix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.VersionSuffix"/></em></p>
        ///   <p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p>
        /// </summary>
        [Pure]
        public static T SetVersionSuffix<T>(this T toolSettings, string versionSuffix) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = versionSuffix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.VersionSuffix"/></em></p>
        ///   <p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p>
        /// </summary>
        [Pure]
        public static T ResetVersionSuffix<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = null;
            return toolSettings;
        }
        #endregion
        #region Loggers
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.Loggers"/> to a new list</em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static T SetLoggers<T>(this T toolSettings, params string[] loggers) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal = loggers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.Loggers"/> to a new list</em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static T SetLoggers<T>(this T toolSettings, IEnumerable<string> loggers) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal = loggers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetBuildSettings.Loggers"/></em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static T AddLoggers<T>(this T toolSettings, params string[] loggers) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal.AddRange(loggers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetBuildSettings.Loggers"/></em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static T AddLoggers<T>(this T toolSettings, IEnumerable<string> loggers) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal.AddRange(loggers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetBuildSettings.Loggers"/></em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static T ClearLoggers<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoggersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetBuildSettings.Loggers"/></em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static T RemoveLoggers<T>(this T toolSettings, params string[] loggers) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(loggers);
            toolSettings.LoggersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetBuildSettings.Loggers"/></em></p>
        ///   <p>Specifies the loggers to use to log events from MSBuild.</p>
        /// </summary>
        [Pure]
        public static T RemoveLoggers<T>(this T toolSettings, IEnumerable<string> loggers) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(loggers);
            toolSettings.LoggersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoConsoleLogger
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.NoConsoleLogger"/></em></p>
        ///   <p>Disable the default console logger, and don't log events to the console.</p>
        /// </summary>
        [Pure]
        public static T SetNoConsoleLogger<T>(this T toolSettings, bool? noConsoleLogger) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = noConsoleLogger;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.NoConsoleLogger"/></em></p>
        ///   <p>Disable the default console logger, and don't log events to the console.</p>
        /// </summary>
        [Pure]
        public static T ResetNoConsoleLogger<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.NoConsoleLogger"/></em></p>
        ///   <p>Disable the default console logger, and don't log events to the console.</p>
        /// </summary>
        [Pure]
        public static T EnableNoConsoleLogger<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.NoConsoleLogger"/></em></p>
        ///   <p>Disable the default console logger, and don't log events to the console.</p>
        /// </summary>
        [Pure]
        public static T DisableNoConsoleLogger<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.NoConsoleLogger"/></em></p>
        ///   <p>Disable the default console logger, and don't log events to the console.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoConsoleLogger<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConsoleLogger = !toolSettings.NoConsoleLogger;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T SetNoLogo<T>(this T toolSettings, bool? noLogo) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T ResetNoLogo<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T EnableNoLogo<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T DisableNoLogo<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoLogo<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T SetDisableParallel<T>(this T toolSettings, bool? disableParallel) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableParallel<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableParallel<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableParallel<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableParallel<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreFailedSources<T>(this T toolSettings, bool? ignoreFailedSources) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreFailedSources<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreFailedSources<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T SetNoCache<T>(this T toolSettings, bool? noCache) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ResetNoCache<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T EnableNoCache<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T DisableNoCache<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoCache<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T SetNoDependencies<T>(this T toolSettings, bool? noDependencies) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ResetNoDependencies<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T EnableNoDependencies<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T DisableNoDependencies<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoDependencies<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T SetPackageDirectory<T>(this T toolSettings, string packageDirectory) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageDirectory<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, params string[] sources) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetBuildSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, params string[] sources) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetBuildSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetBuildSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ClearSources<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetBuildSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, params string[] sources) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetBuildSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T SetUseLockFile<T>(this T toolSettings, bool? useLockFile) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ResetUseLockFile<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T EnableUseLockFile<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T DisableUseLockFile<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseLockFile<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T SetLockedMode<T>(this T toolSettings, bool? lockedMode) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ResetLockedMode<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T EnableLockedMode<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T DisableLockedMode<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ToggleLockedMode<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T SetLockFilePath<T>(this T toolSettings, string lockFilePath) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T ResetLockFilePath<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T SetForceEvaluate<T>(this T toolSettings, bool? forceEvaluate) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetBuildSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEvaluate<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetBuildSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEvaluate<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetBuildSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEvaluate<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetBuildSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEvaluate<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetBuildSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary>
        ///   <p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRunCodeAnalysis<T>(this T toolSettings, bool? runCodeAnalysis) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRunCodeAnalysis<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleRunCodeAnalysis<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearNoWarns<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearWarningsAsErrors<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary>
        ///   <p><em>Sets <c>WarningLevel</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningLevel<T>(this T toolSettings, int? warningLevel) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>WarningLevel</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetWarningLevel<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTreatWarningsAsErrors<T>(this T toolSettings, bool? treatWarningsAsErrors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary>
        ///   <p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAssemblyVersion<T>(this T toolSettings, string assemblyVersion) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetAssemblyVersion<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary>
        ///   <p><em>Sets <c>FileVersion</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetFileVersion<T>(this T toolSettings, string fileVersion) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>FileVersion</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetFileVersion<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary>
        ///   <p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetInformationalVersion<T>(this T toolSettings, string informationalVersion) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetInformationalVersion<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #region PackageId
        /// <summary>
        ///   <p><em>Sets <c>PackageId</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageId<T>(this T toolSettings, string packageId) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageId"] = packageId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageId</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageId<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageId");
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <c>Version</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Version"] = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Version</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Version");
            return toolSettings;
        }
        #endregion
        #region VersionPrefix
        /// <summary>
        ///   <p><em>Sets <c>VersionPrefix</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersionPrefix<T>(this T toolSettings, string versionPrefix) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["VersionPrefix"] = versionPrefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>VersionPrefix</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersionPrefix<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("VersionPrefix");
            return toolSettings;
        }
        #endregion
        #region Authors
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in existing <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>Authors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearAuthors<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Authors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        #endregion
        #region Title
        /// <summary>
        ///   <p><em>Sets <c>Title</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTitle<T>(this T toolSettings, string title) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Title"] = title;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Title</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTitle<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Title");
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <c>Description</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Description"] = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Description</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Description");
            return toolSettings;
        }
        #endregion
        #region Copyright
        /// <summary>
        ///   <p><em>Sets <c>Copyright</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetCopyright<T>(this T toolSettings, string copyright) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Copyright"] = copyright;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Copyright</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetCopyright<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Copyright");
            return toolSettings;
        }
        #endregion
        #region PackageRequireLicenseAcceptance
        /// <summary>
        ///   <p><em>Sets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageRequireLicenseAcceptance<T>(this T toolSettings, bool? packageRequireLicenseAcceptance) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = packageRequireLicenseAcceptance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T TogglePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        #endregion
        #region PackageLicenseUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageLicenseUrl</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageLicenseUrl<T>(this T toolSettings, string packageLicenseUrl) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageLicenseUrl"] = packageLicenseUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageLicenseUrl</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageLicenseUrl<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageLicenseUrl");
            return toolSettings;
        }
        #endregion
        #region PackageProjectUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageProjectUrl</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageProjectUrl<T>(this T toolSettings, string packageProjectUrl) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageProjectUrl"] = packageProjectUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageProjectUrl</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageProjectUrl<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageProjectUrl");
            return toolSettings;
        }
        #endregion
        #region PackageIconUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageIconUrl</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageIconUrl<T>(this T toolSettings, string packageIconUrl) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageIconUrl"] = packageIconUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageIconUrl</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageIconUrl<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageIconUrl");
            return toolSettings;
        }
        #endregion
        #region PackageTags
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in existing <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>PackageTags</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearPackageTags<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageTags");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        #endregion
        #region PackageReleaseNotes
        /// <summary>
        ///   <p><em>Sets <c>PackageReleaseNotes</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageReleaseNotes<T>(this T toolSettings, string packageReleaseNotes) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageReleaseNotes"] = packageReleaseNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageReleaseNotes</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageReleaseNotes<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageReleaseNotes");
            return toolSettings;
        }
        #endregion
        #region RepositoryUrl
        /// <summary>
        ///   <p><em>Sets <c>RepositoryUrl</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryUrl<T>(this T toolSettings, string repositoryUrl) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryUrl"] = repositoryUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryUrl</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryUrl<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryUrl");
            return toolSettings;
        }
        #endregion
        #region RepositoryType
        /// <summary>
        ///   <p><em>Sets <c>RepositoryType</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryType<T>(this T toolSettings, string repositoryType) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryType"] = repositoryType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryType</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryType<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryType");
            return toolSettings;
        }
        #endregion
        #region SymbolPackageFormat
        /// <summary>
        ///   <p><em>Sets <c>SymbolPackageFormat</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolPackageFormat<T>(this T toolSettings, DotNetSymbolPackageFormat symbolPackageFormat) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["SymbolPackageFormat"] = symbolPackageFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>SymbolPackageFormat</c> in <see cref="DotNetBuildSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolPackageFormat<T>(this T toolSettings) where T : DotNetBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("SymbolPackageFormat");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetCleanSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetCleanSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetCleanSettings.Project"/></em></p>
        ///   <p>The MSBuild project to clean. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in <em>proj</em> and uses that file.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetCleanSettings.Project"/></em></p>
        ///   <p>The MSBuild project to clean. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in <em>proj</em> and uses that file.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetCleanSettings.Configuration"/></em></p>
        ///   <p>Defines the build configuration. The default value is <c>Debug</c>. This option is only required when cleaning if you specified it during build time.</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetCleanSettings.Configuration"/></em></p>
        ///   <p>Defines the build configuration. The default value is <c>Debug</c>. This option is only required when cleaning if you specified it during build time.</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetCleanSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a> that was specified at build time. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>. If you specified the framework at build time, you must specify the framework when cleaning.</p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetCleanSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a> that was specified at build time. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>. If you specified the framework at build time, you must specify the framework when cleaning.</p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetCleanSettings.Output"/></em></p>
        ///   <p>Directory in which the build outputs are placed. Specify the <c>--framework</c> switch with the output directory switch if you specified the framework when the project was built.</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetCleanSettings.Output"/></em></p>
        ///   <p>Directory in which the build outputs are placed. Specify the <c>--framework</c> switch with the output directory switch if you specified the framework when the project was built.</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetCleanSettings.Runtime"/></em></p>
        ///   <p>Cleans the output folder of the specified runtime. This is used when a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment</a> was created.</p>
        /// </summary>
        [Pure]
        public static T SetRuntime<T>(this T toolSettings, string runtime) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetCleanSettings.Runtime"/></em></p>
        ///   <p>Cleans the output folder of the specified runtime. This is used when a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment</a> was created.</p>
        /// </summary>
        [Pure]
        public static T ResetRuntime<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetCleanSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed levels are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, DotNetVerbosity verbosity) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetCleanSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed levels are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetCleanSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T SetNoLogo<T>(this T toolSettings, bool? noLogo) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetCleanSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T ResetNoLogo<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetCleanSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T EnableNoLogo<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetCleanSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T DisableNoLogo<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetCleanSettings.NoLogo"/></em></p>
        ///   <p>Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoLogo<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetCleanSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary>
        ///   <p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRunCodeAnalysis<T>(this T toolSettings, bool? runCodeAnalysis) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRunCodeAnalysis<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleRunCodeAnalysis<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetCleanSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetCleanSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>NoWarn</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearNoWarns<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearWarningsAsErrors<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary>
        ///   <p><em>Sets <c>WarningLevel</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningLevel<T>(this T toolSettings, int? warningLevel) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>WarningLevel</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetWarningLevel<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTreatWarningsAsErrors<T>(this T toolSettings, bool? treatWarningsAsErrors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary>
        ///   <p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAssemblyVersion<T>(this T toolSettings, string assemblyVersion) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetAssemblyVersion<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary>
        ///   <p><em>Sets <c>FileVersion</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetFileVersion<T>(this T toolSettings, string fileVersion) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>FileVersion</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetFileVersion<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary>
        ///   <p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetInformationalVersion<T>(this T toolSettings, string informationalVersion) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetInformationalVersion<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #region PackageId
        /// <summary>
        ///   <p><em>Sets <c>PackageId</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageId<T>(this T toolSettings, string packageId) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageId"] = packageId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageId</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageId<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageId");
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <c>Version</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Version"] = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Version</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Version");
            return toolSettings;
        }
        #endregion
        #region VersionPrefix
        /// <summary>
        ///   <p><em>Sets <c>VersionPrefix</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersionPrefix<T>(this T toolSettings, string versionPrefix) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["VersionPrefix"] = versionPrefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>VersionPrefix</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersionPrefix<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("VersionPrefix");
            return toolSettings;
        }
        #endregion
        #region Authors
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetCleanSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetCleanSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in existing <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>Authors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearAuthors<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Authors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        #endregion
        #region Title
        /// <summary>
        ///   <p><em>Sets <c>Title</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTitle<T>(this T toolSettings, string title) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Title"] = title;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Title</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTitle<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Title");
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <c>Description</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Description"] = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Description</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Description");
            return toolSettings;
        }
        #endregion
        #region Copyright
        /// <summary>
        ///   <p><em>Sets <c>Copyright</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetCopyright<T>(this T toolSettings, string copyright) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Copyright"] = copyright;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Copyright</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetCopyright<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Copyright");
            return toolSettings;
        }
        #endregion
        #region PackageRequireLicenseAcceptance
        /// <summary>
        ///   <p><em>Sets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageRequireLicenseAcceptance<T>(this T toolSettings, bool? packageRequireLicenseAcceptance) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = packageRequireLicenseAcceptance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T TogglePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        #endregion
        #region PackageLicenseUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageLicenseUrl</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageLicenseUrl<T>(this T toolSettings, string packageLicenseUrl) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageLicenseUrl"] = packageLicenseUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageLicenseUrl</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageLicenseUrl<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageLicenseUrl");
            return toolSettings;
        }
        #endregion
        #region PackageProjectUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageProjectUrl</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageProjectUrl<T>(this T toolSettings, string packageProjectUrl) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageProjectUrl"] = packageProjectUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageProjectUrl</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageProjectUrl<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageProjectUrl");
            return toolSettings;
        }
        #endregion
        #region PackageIconUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageIconUrl</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageIconUrl<T>(this T toolSettings, string packageIconUrl) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageIconUrl"] = packageIconUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageIconUrl</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageIconUrl<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageIconUrl");
            return toolSettings;
        }
        #endregion
        #region PackageTags
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetCleanSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetCleanSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in existing <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>PackageTags</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearPackageTags<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageTags");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        #endregion
        #region PackageReleaseNotes
        /// <summary>
        ///   <p><em>Sets <c>PackageReleaseNotes</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageReleaseNotes<T>(this T toolSettings, string packageReleaseNotes) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageReleaseNotes"] = packageReleaseNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageReleaseNotes</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageReleaseNotes<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageReleaseNotes");
            return toolSettings;
        }
        #endregion
        #region RepositoryUrl
        /// <summary>
        ///   <p><em>Sets <c>RepositoryUrl</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryUrl<T>(this T toolSettings, string repositoryUrl) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryUrl"] = repositoryUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryUrl</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryUrl<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryUrl");
            return toolSettings;
        }
        #endregion
        #region RepositoryType
        /// <summary>
        ///   <p><em>Sets <c>RepositoryType</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryType<T>(this T toolSettings, string repositoryType) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryType"] = repositoryType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryType</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryType<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryType");
            return toolSettings;
        }
        #endregion
        #region SymbolPackageFormat
        /// <summary>
        ///   <p><em>Sets <c>SymbolPackageFormat</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolPackageFormat<T>(this T toolSettings, DotNetSymbolPackageFormat symbolPackageFormat) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["SymbolPackageFormat"] = symbolPackageFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>SymbolPackageFormat</c> in <see cref="DotNetCleanSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolPackageFormat<T>(this T toolSettings) where T : DotNetCleanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("SymbolPackageFormat");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetPublishSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetPublishSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Project"/></em></p>
        ///   <p>The project to publish, which defaults to the current directory if not specified.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.Project"/></em></p>
        ///   <p>The project to publish, which defaults to the current directory if not specified.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Configuration"/></em></p>
        ///   <p>Defines the build configuration. The default value is <c>Debug</c>.</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.Configuration"/></em></p>
        ///   <p>Defines the build configuration. The default value is <c>Debug</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Framework"/></em></p>
        ///   <p>Publishes the application for the specified <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. You must specify the target framework in the project file.</p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.Framework"/></em></p>
        ///   <p>Publishes the application for the specified <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. You must specify the target framework in the project file.</p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Manifest
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Manifest"/></em></p>
        ///   <p>Specifies one or several <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/runtime-store">target manifests</a> to use to trim the set of packages published with the app. The manifest file is part of the output of the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-store"><c>dotnet store</c></a> command. To specify multiple manifests, add a <c>--manifest</c> option for each manifest. This option is available starting with .NET Core 2.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T SetManifest<T>(this T toolSettings, string manifest) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manifest = manifest;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.Manifest"/></em></p>
        ///   <p>Specifies one or several <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/runtime-store">target manifests</a> to use to trim the set of packages published with the app. The manifest file is part of the output of the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-store"><c>dotnet store</c></a> command. To specify multiple manifests, add a <c>--manifest</c> option for each manifest. This option is available starting with .NET Core 2.0 SDK.</p>
        /// </summary>
        [Pure]
        public static T ResetManifest<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manifest = null;
            return toolSettings;
        }
        #endregion
        #region NoRestore
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T SetNoRestore<T>(this T toolSettings, bool? noRestore) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = noRestore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T ResetNoRestore<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T EnableNoRestore<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T DisableNoRestore<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.NoRestore"/></em></p>
        ///   <p>Doesn't perform an implicit restore when running the command.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoRestore<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = !toolSettings.NoRestore;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p>
        /// </summary>
        [Pure]
        public static T SetNoBuild<T>(this T toolSettings, bool? noBuild) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p>
        /// </summary>
        [Pure]
        public static T ResetNoBuild<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p>
        /// </summary>
        [Pure]
        public static T EnableNoBuild<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p>
        /// </summary>
        [Pure]
        public static T DisableNoBuild<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoBuild<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Output"/></em></p>
        ///   <p>Specifies the path for the output directory. If not specified, it defaults to <em>./bin/[configuration]/[framework]/</em> for a framework-dependent deployment or <em>./bin/[configuration]/[framework]/[runtime]</em> for a self-contained deployment.<para/>If a relative path is provided, the output directory generated is relative to the project file location, not to the current working directory.</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.Output"/></em></p>
        ///   <p>Specifies the path for the output directory. If not specified, it defaults to <em>./bin/[configuration]/[framework]/</em> for a framework-dependent deployment or <em>./bin/[configuration]/[framework]/[runtime]</em> for a self-contained deployment.<para/>If a relative path is provided, the output directory generated is relative to the project file location, not to the current working directory.</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region SelfContained
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.SelfContained"/></em></p>
        ///   <p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p>
        /// </summary>
        [Pure]
        public static T SetSelfContained<T>(this T toolSettings, bool? selfContained) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = selfContained;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.SelfContained"/></em></p>
        ///   <p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetSelfContained<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.SelfContained"/></em></p>
        ///   <p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableSelfContained<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.SelfContained"/></em></p>
        ///   <p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableSelfContained<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.SelfContained"/></em></p>
        ///   <p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleSelfContained<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = !toolSettings.SelfContained;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Runtime"/></em></p>
        ///   <p>Publishes the application for a given runtime. This is used when creating a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment (SCD)</a>. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Default is to publish a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#framework-dependent-deployments-fdd">framework-dependent deployment (FDD)</a>.</p>
        /// </summary>
        [Pure]
        public static T SetRuntime<T>(this T toolSettings, string runtime) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.Runtime"/></em></p>
        ///   <p>Publishes the application for a given runtime. This is used when creating a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment (SCD)</a>. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Default is to publish a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#framework-dependent-deployments-fdd">framework-dependent deployment (FDD)</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetRuntime<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, DotNetVerbosity verbosity) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region VersionSuffix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.VersionSuffix"/></em></p>
        ///   <p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p>
        /// </summary>
        [Pure]
        public static T SetVersionSuffix<T>(this T toolSettings, string versionSuffix) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = versionSuffix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.VersionSuffix"/></em></p>
        ///   <p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p>
        /// </summary>
        [Pure]
        public static T ResetVersionSuffix<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = null;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T SetDisableParallel<T>(this T toolSettings, bool? disableParallel) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableParallel<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableParallel<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableParallel<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.DisableParallel"/></em></p>
        ///   <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableParallel<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.Force"/></em></p>
        ///   <p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreFailedSources<T>(this T toolSettings, bool? ignoreFailedSources) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreFailedSources<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreFailedSources<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.IgnoreFailedSources"/></em></p>
        ///   <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreFailedSources<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T SetNoCache<T>(this T toolSettings, bool? noCache) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ResetNoCache<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T EnableNoCache<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T DisableNoCache<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.NoCache"/></em></p>
        ///   <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoCache<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T SetNoDependencies<T>(this T toolSettings, bool? noDependencies) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ResetNoDependencies<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T EnableNoDependencies<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T DisableNoDependencies<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.NoDependencies"/></em></p>
        ///   <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoDependencies<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T SetPackageDirectory<T>(this T toolSettings, string packageDirectory) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.PackageDirectory"/></em></p>
        ///   <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageDirectory<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, params string[] sources) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Sources"/> to a new list</em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetPublishSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, params string[] sources) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetPublishSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetPublishSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T ClearSources<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetPublishSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, params string[] sources) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetPublishSettings.Sources"/></em></p>
        ///   <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T SetUseLockFile<T>(this T toolSettings, bool? useLockFile) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ResetUseLockFile<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T EnableUseLockFile<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T DisableUseLockFile<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.UseLockFile"/></em></p>
        ///   <p>Enables project lock file to be generated and used with restore.</p>
        /// </summary>
        [Pure]
        public static T ToggleUseLockFile<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T SetLockedMode<T>(this T toolSettings, bool? lockedMode) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ResetLockedMode<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T EnableLockedMode<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T DisableLockedMode<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.LockedMode"/></em></p>
        ///   <p>Don't allow updating project lock file.</p>
        /// </summary>
        [Pure]
        public static T ToggleLockedMode<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T SetLockFilePath<T>(this T toolSettings, string lockFilePath) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.LockFilePath"/></em></p>
        ///   <p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p>
        /// </summary>
        [Pure]
        public static T ResetLockFilePath<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T SetForceEvaluate<T>(this T toolSettings, bool? forceEvaluate) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetPublishSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEvaluate<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetPublishSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEvaluate<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetPublishSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEvaluate<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetPublishSettings.ForceEvaluate"/></em></p>
        ///   <p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEvaluate<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetPublishSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary>
        ///   <p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRunCodeAnalysis<T>(this T toolSettings, bool? runCodeAnalysis) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRunCodeAnalysis<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableRunCodeAnalysis<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleRunCodeAnalysis<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearNoWarns<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, params int[] noWarn) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearWarningsAsErrors<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary>
        ///   <p><em>Sets <c>WarningLevel</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningLevel<T>(this T toolSettings, int? warningLevel) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>WarningLevel</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetWarningLevel<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTreatWarningsAsErrors<T>(this T toolSettings, bool? treatWarningsAsErrors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleTreatWarningsAsErrors<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary>
        ///   <p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAssemblyVersion<T>(this T toolSettings, string assemblyVersion) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetAssemblyVersion<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary>
        ///   <p><em>Sets <c>FileVersion</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetFileVersion<T>(this T toolSettings, string fileVersion) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>FileVersion</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetFileVersion<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary>
        ///   <p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetInformationalVersion<T>(this T toolSettings, string informationalVersion) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetInformationalVersion<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #region PackageId
        /// <summary>
        ///   <p><em>Sets <c>PackageId</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageId<T>(this T toolSettings, string packageId) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageId"] = packageId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageId</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageId<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageId");
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <c>Version</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Version"] = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Version</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Version");
            return toolSettings;
        }
        #endregion
        #region VersionPrefix
        /// <summary>
        ///   <p><em>Sets <c>VersionPrefix</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersionPrefix<T>(this T toolSettings, string versionPrefix) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["VersionPrefix"] = versionPrefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>VersionPrefix</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersionPrefix<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("VersionPrefix");
            return toolSettings;
        }
        #endregion
        #region Authors
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in existing <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>Authors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearAuthors<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Authors");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, params string[] authors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        #endregion
        #region Title
        /// <summary>
        ///   <p><em>Sets <c>Title</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTitle<T>(this T toolSettings, string title) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Title"] = title;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Title</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTitle<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Title");
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <c>Description</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Description"] = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Description</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Description");
            return toolSettings;
        }
        #endregion
        #region Copyright
        /// <summary>
        ///   <p><em>Sets <c>Copyright</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetCopyright<T>(this T toolSettings, string copyright) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Copyright"] = copyright;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Copyright</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetCopyright<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Copyright");
            return toolSettings;
        }
        #endregion
        #region PackageRequireLicenseAcceptance
        /// <summary>
        ///   <p><em>Sets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageRequireLicenseAcceptance<T>(this T toolSettings, bool? packageRequireLicenseAcceptance) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = packageRequireLicenseAcceptance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T TogglePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        #endregion
        #region PackageLicenseUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageLicenseUrl</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageLicenseUrl<T>(this T toolSettings, string packageLicenseUrl) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageLicenseUrl"] = packageLicenseUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageLicenseUrl</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageLicenseUrl<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageLicenseUrl");
            return toolSettings;
        }
        #endregion
        #region PackageProjectUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageProjectUrl</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageProjectUrl<T>(this T toolSettings, string packageProjectUrl) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageProjectUrl"] = packageProjectUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageProjectUrl</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageProjectUrl<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageProjectUrl");
            return toolSettings;
        }
        #endregion
        #region PackageIconUrl
        /// <summary>
        ///   <p><em>Sets <c>PackageIconUrl</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageIconUrl<T>(this T toolSettings, string packageIconUrl) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageIconUrl"] = packageIconUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageIconUrl</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageIconUrl<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageIconUrl");
            return toolSettings;
        }
        #endregion
        #region PackageTags
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in existing <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <c>PackageTags</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearPackageTags<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageTags");
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, params string[] packageTags) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        #endregion
        #region PackageReleaseNotes
        /// <summary>
        ///   <p><em>Sets <c>PackageReleaseNotes</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageReleaseNotes<T>(this T toolSettings, string packageReleaseNotes) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageReleaseNotes"] = packageReleaseNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>PackageReleaseNotes</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageReleaseNotes<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageReleaseNotes");
            return toolSettings;
        }
        #endregion
        #region RepositoryUrl
        /// <summary>
        ///   <p><em>Sets <c>RepositoryUrl</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryUrl<T>(this T toolSettings, string repositoryUrl) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryUrl"] = repositoryUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryUrl</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryUrl<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryUrl");
            return toolSettings;
        }
        #endregion
        #region RepositoryType
        /// <summary>
        ///   <p><em>Sets <c>RepositoryType</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryType<T>(this T toolSettings, string repositoryType) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryType"] = repositoryType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>RepositoryType</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryType<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryType");
            return toolSettings;
        }
        #endregion
        #region SymbolPackageFormat
        /// <summary>
        ///   <p><em>Sets <c>SymbolPackageFormat</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolPackageFormat<T>(this T toolSettings, DotNetSymbolPackageFormat symbolPackageFormat) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["SymbolPackageFormat"] = symbolPackageFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>SymbolPackageFormat</c> in <see cref="DotNetPublishSettings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolPackageFormat<T>(this T toolSettings) where T : DotNetPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("SymbolPackageFormat");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetNuGetPushSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetNuGetPushSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.TargetPath"/></em></p>
        ///   <p>Path of the package to push.</p>
        /// </summary>
        [Pure]
        public static T SetTargetPath<T>(this T toolSettings, string targetPath) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.TargetPath"/></em></p>
        ///   <p>Path of the package to push.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPath<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.Source"/></em></p>
        ///   <p>Specifies the server URL. This option is required unless <c>DefaultPushSource</c> config value is set in the NuGet config file.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.Source"/></em></p>
        ///   <p>Specifies the server URL. This option is required unless <c>DefaultPushSource</c> config value is set in the NuGet config file.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region SymbolSource
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.SymbolSource"/></em></p>
        ///   <p>Specifies the symbol server URL.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolSource<T>(this T toolSettings, string symbolSource) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSource = symbolSource;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.SymbolSource"/></em></p>
        ///   <p>Specifies the symbol server URL.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolSource<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSource = null;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.Timeout"/></em></p>
        ///   <p>Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, int? timeout) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.Timeout"/></em></p>
        ///   <p>Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.ApiKey"/></em></p>
        ///   <p>The API key for the server.</p>
        /// </summary>
        [Pure]
        public static T SetApiKey<T>(this T toolSettings, string apiKey) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.ApiKey"/></em></p>
        ///   <p>The API key for the server.</p>
        /// </summary>
        [Pure]
        public static T ResetApiKey<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region SymbolApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.SymbolApiKey"/></em></p>
        ///   <p>The API key for the symbol server.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolApiKey<T>(this T toolSettings, string symbolApiKey) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolApiKey = symbolApiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.SymbolApiKey"/></em></p>
        ///   <p>The API key for the symbol server.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolApiKey<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolApiKey = null;
            return toolSettings;
        }
        #endregion
        #region DisableBuffering
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.DisableBuffering"/></em></p>
        ///   <p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p>
        /// </summary>
        [Pure]
        public static T SetDisableBuffering<T>(this T toolSettings, bool? disableBuffering) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = disableBuffering;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.DisableBuffering"/></em></p>
        ///   <p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableBuffering<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetNuGetPushSettings.DisableBuffering"/></em></p>
        ///   <p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableBuffering<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetNuGetPushSettings.DisableBuffering"/></em></p>
        ///   <p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableBuffering<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetNuGetPushSettings.DisableBuffering"/></em></p>
        ///   <p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableBuffering<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = !toolSettings.DisableBuffering;
            return toolSettings;
        }
        #endregion
        #region NoSymbols
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.NoSymbols"/></em></p>
        ///   <p>Doesn't push symbols (even if present).</p>
        /// </summary>
        [Pure]
        public static T SetNoSymbols<T>(this T toolSettings, bool? noSymbols) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = noSymbols;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.NoSymbols"/></em></p>
        ///   <p>Doesn't push symbols (even if present).</p>
        /// </summary>
        [Pure]
        public static T ResetNoSymbols<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetNuGetPushSettings.NoSymbols"/></em></p>
        ///   <p>Doesn't push symbols (even if present).</p>
        /// </summary>
        [Pure]
        public static T EnableNoSymbols<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetNuGetPushSettings.NoSymbols"/></em></p>
        ///   <p>Doesn't push symbols (even if present).</p>
        /// </summary>
        [Pure]
        public static T DisableNoSymbols<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetNuGetPushSettings.NoSymbols"/></em></p>
        ///   <p>Doesn't push symbols (even if present).</p>
        /// </summary>
        [Pure]
        public static T ToggleNoSymbols<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = !toolSettings.NoSymbols;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/></em></p>
        ///   <p>Forces all logged output in English.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/></em></p>
        ///   <p>Forces all logged output in English.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/></em></p>
        ///   <p>Forces all logged output in English.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/></em></p>
        ///   <p>Forces all logged output in English.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/></em></p>
        ///   <p>Forces all logged output in English.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region SkipDuplicate
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.SkipDuplicate"/></em></p>
        ///   <p>When pushing multiple packages to an HTTP(S) server, treats any 409 Conflict response as a warning so that the push can continue. Available since .NET Core 3.1 SDK.</p>
        /// </summary>
        [Pure]
        public static T SetSkipDuplicate<T>(this T toolSettings, bool? skipDuplicate) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipDuplicate = skipDuplicate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.SkipDuplicate"/></em></p>
        ///   <p>When pushing multiple packages to an HTTP(S) server, treats any 409 Conflict response as a warning so that the push can continue. Available since .NET Core 3.1 SDK.</p>
        /// </summary>
        [Pure]
        public static T ResetSkipDuplicate<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipDuplicate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetNuGetPushSettings.SkipDuplicate"/></em></p>
        ///   <p>When pushing multiple packages to an HTTP(S) server, treats any 409 Conflict response as a warning so that the push can continue. Available since .NET Core 3.1 SDK.</p>
        /// </summary>
        [Pure]
        public static T EnableSkipDuplicate<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipDuplicate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetNuGetPushSettings.SkipDuplicate"/></em></p>
        ///   <p>When pushing multiple packages to an HTTP(S) server, treats any 409 Conflict response as a warning so that the push can continue. Available since .NET Core 3.1 SDK.</p>
        /// </summary>
        [Pure]
        public static T DisableSkipDuplicate<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipDuplicate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetNuGetPushSettings.SkipDuplicate"/></em></p>
        ///   <p>When pushing multiple packages to an HTTP(S) server, treats any 409 Conflict response as a warning so that the push can continue. Available since .NET Core 3.1 SDK.</p>
        /// </summary>
        [Pure]
        public static T ToggleSkipDuplicate<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipDuplicate = !toolSettings.SkipDuplicate;
            return toolSettings;
        }
        #endregion
        #region NoServiceEndpoint
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetNuGetPushSettings.NoServiceEndpoint"/></em></p>
        ///   <p>Doesn't append <c>api/v2/package</c> to the source URL. Option available since .NET Core 2.1 SDK.</p>
        /// </summary>
        [Pure]
        public static T SetNoServiceEndpoint<T>(this T toolSettings, bool? noServiceEndpoint) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoServiceEndpoint = noServiceEndpoint;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetNuGetPushSettings.NoServiceEndpoint"/></em></p>
        ///   <p>Doesn't append <c>api/v2/package</c> to the source URL. Option available since .NET Core 2.1 SDK.</p>
        /// </summary>
        [Pure]
        public static T ResetNoServiceEndpoint<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoServiceEndpoint = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetNuGetPushSettings.NoServiceEndpoint"/></em></p>
        ///   <p>Doesn't append <c>api/v2/package</c> to the source URL. Option available since .NET Core 2.1 SDK.</p>
        /// </summary>
        [Pure]
        public static T EnableNoServiceEndpoint<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoServiceEndpoint = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetNuGetPushSettings.NoServiceEndpoint"/></em></p>
        ///   <p>Doesn't append <c>api/v2/package</c> to the source URL. Option available since .NET Core 2.1 SDK.</p>
        /// </summary>
        [Pure]
        public static T DisableNoServiceEndpoint<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoServiceEndpoint = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetNuGetPushSettings.NoServiceEndpoint"/></em></p>
        ///   <p>Doesn't append <c>api/v2/package</c> to the source URL. Option available since .NET Core 2.1 SDK.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoServiceEndpoint<T>(this T toolSettings) where T : DotNetNuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoServiceEndpoint = !toolSettings.NoServiceEndpoint;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetToolInstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetToolInstallSettingsExtensions
    {
        #region PackageName
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolInstallSettings.PackageName"/></em></p>
        ///   <p>The Name/ID of the NuGet package that contains the .NET Core Global Tool to install.</p>
        /// </summary>
        [Pure]
        public static T SetPackageName<T>(this T toolSettings, string packageName) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageName = packageName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolInstallSettings.PackageName"/></em></p>
        ///   <p>The Name/ID of the NuGet package that contains the .NET Core Global Tool to install.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageName<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageName = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolInstallSettings.Sources"/> to a new list</em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, params string[] sources) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolInstallSettings.Sources"/> to a new list</em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetToolInstallSettings.Sources"/></em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, params string[] sources) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetToolInstallSettings.Sources"/></em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetToolInstallSettings.Sources"/></em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T ClearSources<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetToolInstallSettings.Sources"/></em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, params string[] sources) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetToolInstallSettings.Sources"/></em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolInstallSettings.ConfigFile"/></em></p>
        ///   <p>Specifies the NuGet configuration (<em>nuget.config</em>) file to use.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolInstallSettings.ConfigFile"/></em></p>
        ///   <p>Specifies the NuGet configuration (<em>nuget.config</em>) file to use.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolInstallSettings.Framework"/></em></p>
        ///   <p>Specifies the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a> to install the tool for. By default, the .NET Core SDK tries to choose the most appropriate target framework.</p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolInstallSettings.Framework"/></em></p>
        ///   <p>Specifies the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a> to install the tool for. By default, the .NET Core SDK tries to choose the most appropriate target framework.</p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Global
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolInstallSettings.Global"/></em></p>
        ///   <p>Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetGlobal<T>(this T toolSettings, bool? global) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = global;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolInstallSettings.Global"/></em></p>
        ///   <p>Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T ResetGlobal<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetToolInstallSettings.Global"/></em></p>
        ///   <p>Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T EnableGlobal<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetToolInstallSettings.Global"/></em></p>
        ///   <p>Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T DisableGlobal<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetToolInstallSettings.Global"/></em></p>
        ///   <p>Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T ToggleGlobal<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = !toolSettings.Global;
            return toolSettings;
        }
        #endregion
        #region ToolInstallationPath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolInstallSettings.ToolInstallationPath"/></em></p>
        ///   <p>Specifies the location where to install the Global Tool. The path can be absolute or relative. If the path doesn't exist, the command tries to create it. Can't be combined with the <c>--global</c> option. If you don't specify this option, you must specify the <c>--global</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetToolInstallationPath<T>(this T toolSettings, string toolInstallationPath) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolInstallationPath = toolInstallationPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolInstallSettings.ToolInstallationPath"/></em></p>
        ///   <p>Specifies the location where to install the Global Tool. The path can be absolute or relative. If the path doesn't exist, the command tries to create it. Can't be combined with the <c>--global</c> option. If you don't specify this option, you must specify the <c>--global</c> option.</p>
        /// </summary>
        [Pure]
        public static T ResetToolInstallationPath<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolInstallationPath = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolInstallSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, DotNetVerbosity verbosity) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolInstallSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolInstallSettings.Version"/></em></p>
        ///   <p>The version of the tool to install. By default, the latest stable package version is installed. Use this option to install preview or older versions of the tool.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolInstallSettings.Version"/></em></p>
        ///   <p>The version of the tool to install. By default, the latest stable package version is installed. Use this option to install preview or older versions of the tool.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : DotNetToolInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetToolUninstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetToolUninstallSettingsExtensions
    {
        #region PackageName
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUninstallSettings.PackageName"/></em></p>
        ///   <p>The Name/ID of the NuGet package that contains the .NET Core Global Tool to uninstall. You can find the package name using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-list">dotnet tool list</a> command.</p>
        /// </summary>
        [Pure]
        public static T SetPackageName<T>(this T toolSettings, string packageName) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageName = packageName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolUninstallSettings.PackageName"/></em></p>
        ///   <p>The Name/ID of the NuGet package that contains the .NET Core Global Tool to uninstall. You can find the package name using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-tool-list">dotnet tool list</a> command.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageName<T>(this T toolSettings) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageName = null;
            return toolSettings;
        }
        #endregion
        #region Global
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUninstallSettings.Global"/></em></p>
        ///   <p>Specifies that the tool to be removed is from a user-wide installation. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetGlobal<T>(this T toolSettings, bool? global) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = global;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolUninstallSettings.Global"/></em></p>
        ///   <p>Specifies that the tool to be removed is from a user-wide installation. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T ResetGlobal<T>(this T toolSettings) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetToolUninstallSettings.Global"/></em></p>
        ///   <p>Specifies that the tool to be removed is from a user-wide installation. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T EnableGlobal<T>(this T toolSettings) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetToolUninstallSettings.Global"/></em></p>
        ///   <p>Specifies that the tool to be removed is from a user-wide installation. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T DisableGlobal<T>(this T toolSettings) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetToolUninstallSettings.Global"/></em></p>
        ///   <p>Specifies that the tool to be removed is from a user-wide installation. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T ToggleGlobal<T>(this T toolSettings) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = !toolSettings.Global;
            return toolSettings;
        }
        #endregion
        #region ToolInstallationPath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUninstallSettings.ToolInstallationPath"/></em></p>
        ///   <p>Specifies the location where to uninstall the Global Tool. The path can be absolute or relative. Can't be combined with the <c>--global</c> option. If you don't specify this option, you must specify the <c>--global</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetToolInstallationPath<T>(this T toolSettings, string toolInstallationPath) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolInstallationPath = toolInstallationPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolUninstallSettings.ToolInstallationPath"/></em></p>
        ///   <p>Specifies the location where to uninstall the Global Tool. The path can be absolute or relative. Can't be combined with the <c>--global</c> option. If you don't specify this option, you must specify the <c>--global</c> option.</p>
        /// </summary>
        [Pure]
        public static T ResetToolInstallationPath<T>(this T toolSettings) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolInstallationPath = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUninstallSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, DotNetVerbosity verbosity) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolUninstallSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : DotNetToolUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetToolUpdateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetToolUpdateSettingsExtensions
    {
        #region PackageName
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUpdateSettings.PackageName"/></em></p>
        ///   <p>The Name/ID of the NuGet package that contains the .NET Core Global Tool to install.</p>
        /// </summary>
        [Pure]
        public static T SetPackageName<T>(this T toolSettings, string packageName) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageName = packageName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolUpdateSettings.PackageName"/></em></p>
        ///   <p>The Name/ID of the NuGet package that contains the .NET Core Global Tool to install.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageName<T>(this T toolSettings) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageName = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUpdateSettings.Sources"/> to a new list</em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, params string[] sources) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUpdateSettings.Sources"/> to a new list</em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetToolUpdateSettings.Sources"/></em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, params string[] sources) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DotNetToolUpdateSettings.Sources"/></em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DotNetToolUpdateSettings.Sources"/></em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T ClearSources<T>(this T toolSettings) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetToolUpdateSettings.Sources"/></em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, params string[] sources) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DotNetToolUpdateSettings.Sources"/></em></p>
        ///   <p>Adds an additional NuGet package source to use during installation.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, IEnumerable<string> sources) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUpdateSettings.ConfigFile"/></em></p>
        ///   <p>Specifies the NuGet configuration (<em>nuget.config</em>) file to use.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolUpdateSettings.ConfigFile"/></em></p>
        ///   <p>Specifies the NuGet configuration (<em>nuget.config</em>) file to use.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUpdateSettings.Framework"/></em></p>
        ///   <p>Specifies the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a> to update the tool for.</p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolUpdateSettings.Framework"/></em></p>
        ///   <p>Specifies the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a> to update the tool for.</p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Global
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUpdateSettings.Global"/></em></p>
        ///   <p>Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetGlobal<T>(this T toolSettings, bool? global) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = global;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolUpdateSettings.Global"/></em></p>
        ///   <p>Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T ResetGlobal<T>(this T toolSettings) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetToolUpdateSettings.Global"/></em></p>
        ///   <p>Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T EnableGlobal<T>(this T toolSettings) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetToolUpdateSettings.Global"/></em></p>
        ///   <p>Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T DisableGlobal<T>(this T toolSettings) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetToolUpdateSettings.Global"/></em></p>
        ///   <p>Specifies that the installation is user wide. Can't be combined with the <c>--tool-path</c> option. If you don't specify this option, you must specify the <c>--tool-path</c> option.</p>
        /// </summary>
        [Pure]
        public static T ToggleGlobal<T>(this T toolSettings) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = !toolSettings.Global;
            return toolSettings;
        }
        #endregion
        #region ToolInstallationPath
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUpdateSettings.ToolInstallationPath"/></em></p>
        ///   <p>Specifies the location where the Global Tool is installed. The path can be absolute or relative. Can't be combined with the <c>--global</c> option. If you don't specify this option, you must specify the <c>--global</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetToolInstallationPath<T>(this T toolSettings, string toolInstallationPath) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolInstallationPath = toolInstallationPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolUpdateSettings.ToolInstallationPath"/></em></p>
        ///   <p>Specifies the location where the Global Tool is installed. The path can be absolute or relative. Can't be combined with the <c>--global</c> option. If you don't specify this option, you must specify the <c>--global</c> option.</p>
        /// </summary>
        [Pure]
        public static T ResetToolInstallationPath<T>(this T toolSettings) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolInstallationPath = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetToolUpdateSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, DotNetVerbosity verbosity) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetToolUpdateSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : DotNetToolUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetVerbosity
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<DotNetVerbosity>))]
    public partial class DotNetVerbosity : Enumeration
    {
        public static DotNetVerbosity Quiet = (DotNetVerbosity) "Quiet";
        public static DotNetVerbosity Minimal = (DotNetVerbosity) "Minimal";
        public static DotNetVerbosity Normal = (DotNetVerbosity) "Normal";
        public static DotNetVerbosity Detailed = (DotNetVerbosity) "Detailed";
        public static DotNetVerbosity Diagnostic = (DotNetVerbosity) "Diagnostic";
        public static explicit operator DotNetVerbosity(string value)
        {
            return new DotNetVerbosity { Value = value };
        }
    }
    #endregion
    #region DotNetSymbolPackageFormat
    /// <summary>
    ///   Used within <see cref="DotNetTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<DotNetSymbolPackageFormat>))]
    public partial class DotNetSymbolPackageFormat : Enumeration
    {
        public static DotNetSymbolPackageFormat symbols_nupkg = (DotNetSymbolPackageFormat) "symbols.nupkg";
        public static DotNetSymbolPackageFormat snupkg = (DotNetSymbolPackageFormat) "snupkg";
        public static explicit operator DotNetSymbolPackageFormat(string value)
        {
            return new DotNetSymbolPackageFormat { Value = value };
        }
    }
    #endregion
}
