// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/DotNet.json
// Generated with Nuke.CodeGeneration version LOCAL (OSX, .NETStandard,Version=v2.0)

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
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetTasks
    {
        /// <summary><p>Path to the DotNet executable.</p></summary>
        public static string DotNetPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("DOTNET_EXE") ??
            ToolPathResolver.GetPathExecutable("dotnet");
        public static IReadOnlyCollection<Output> DotNet(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(DotNetPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, ParseLogLevel, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetTest(Configure<DotNetTestSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetTestSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>The <c>dotnet run</c> command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build"><c>dotnet build</c></a> command to build the code. Any requirements for the build, such as that the project must be restored first, apply to <c>dotnet run</c> as well.</p><p>Output files are written into the default location, which is <c>bin/&lt;configuration&gt;/&lt;target&gt;</c>. For example if you have a <c>netcoreapp1.0</c> application and you run <c>dotnet run</c>, the output is placed in <c>bin/Debug/netcoreapp1.0</c>. Files are overwritten as needed. Temporary files are placed in the <c>obj</c> directory.</p><p>If the project specifies multiple frameworks, executing <c>dotnet run</c> results in an error unless the <c>-f|--framework &lt;FRAMEWORK&gt;</c> option is used to specify the framework.</p><p>The <c>dotnet run</c> command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet">dotnet</a> without a command. For example, to run <c>myapp.dll</c>, use: <c>dotnet myapp.dll</c></p><p>For more information on the <c>dotnet</c> driver, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/index">.NET Core Command Line Tools (CLI)</a> topic.</p><p>In order to run the application, the <c>dotnet run</c> command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use <c>dotnet run</c> to run applications in production. Instead, <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">create a deployment</a> using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command and deploy the published output.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetRun(Configure<DotNetRunSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetRunSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>Starting with .NET Core 2.0, you don't have to run <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> because it's run implicitly by all commands, such as <c>dotnet build</c> and <c>dotnet run</c>, that require a restore to occur. It's still a valid command in certain scenarios where doing an explicit restore makes sense, such as <a href="https://docs.microsoft.com/en-us/vsts/build-release/apps/aspnet/build-aspnet-core">continuous integration builds in Visual Studio Team Services</a> or in build systems that need to explicitly control the time at which the restore occurs.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <em>NuGet.config</em> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <em>NuGet.config</em> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <em>/home/user1</em> on Linux or <em>C:\Users\user1</em> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <em>Nuget.Config</em> file, if present. For example, setting the <c>globalPackagesFolder</c> in <em>NuGet.Config</em> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetRestore(Configure<DotNetRestoreSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetRestoreSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>Starting with .NET Core 2.0, you don't have to run <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> because it's run implicitly by all commands, such as <c>dotnet build</c> and <c>dotnet run</c>, that require a restore to occur. It's still a valid command in certain scenarios where doing an explicit restore makes sense, such as <a href="https://docs.microsoft.com/en-us/vsts/build-release/apps/aspnet/build-aspnet-core">continuous integration builds in Visual Studio Team Services</a> or in build systems that need to explicitly control the time at which the restore occurs.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <em>NuGet.config</em> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <em>NuGet.config</em> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <em>/home/user1</em> on Linux or <em>C:\Users\user1</em> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <em>Nuget.Config</em> file, if present. For example, setting the <c>globalPackagesFolder</c> in <em>NuGet.Config</em> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetRestore(string projectFile, Configure<DotNetRestoreSettings> configurator = null)
        {
            configurator = configurator ?? (x => x);
            return DotNetRestore(x => configurator(x).SetProjectFile(projectFile));
        }
        /// <summary><p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <em>.nuspec</em> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetPack(Configure<DotNetPackSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetPackSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <em>.nuspec</em> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetPack(string project, Configure<DotNetPackSettings> configurator = null)
        {
            configurator = configurator ?? (x => x);
            return DotNetPack(x => configurator(x).SetProject(project));
        }
        /// <summary><p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <em>.dll</em> extension and symbol files used for debugging with a <em>.pdb</em> extension. A dependencies JSON file (<em>*.deps.json</em>) is produced that lists the dependencies of the application. A <em>.runtimeconfig.json</em> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <em>project.assets.json</em> file, which lists the dependencies of your application. The file is created <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> is executed. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors. With .NET Core 1.x SDK, you needed to explicitily run the <c>dotnet restore</c> before running <c>dotnet build</c>. Starting with .NET Core 2.0 SDK, <c>dotnet restore</c> runs implicitily when you run <c>dotnet build</c>. If you want to disable implicit restore when running the build command, you can pass the <c>--no-restore</c> option.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetBuild(Configure<DotNetBuildSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetBuildSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <em>.dll</em> extension and symbol files used for debugging with a <em>.pdb</em> extension. A dependencies JSON file (<em>*.deps.json</em>) is produced that lists the dependencies of the application. A <em>.runtimeconfig.json</em> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <em>project.assets.json</em> file, which lists the dependencies of your application. The file is created <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> is executed. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors. With .NET Core 1.x SDK, you needed to explicitily run the <c>dotnet restore</c> before running <c>dotnet build</c>. Starting with .NET Core 2.0 SDK, <c>dotnet restore</c> runs implicitily when you run <c>dotnet build</c>. If you want to disable implicit restore when running the build command, you can pass the <c>--no-restore</c> option.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetBuild(string projectFile, Configure<DotNetBuildSettings> configurator = null)
        {
            configurator = configurator ?? (x => x);
            return DotNetBuild(x => configurator(x).SetProjectFile(projectFile));
        }
        /// <summary><p>The <c>dotnet clean</c> command cleans the output of the previous build. It's implemented as an <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-targets">MSBuild target</a>, so the project is evaluated when the command is run. Only the outputs created during the build are cleaned. Both intermediate <em>(obj)</em> and final output <em>(bin)</em> folders are cleaned.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetClean(Configure<DotNetCleanSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetCleanSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>The <c>dotnet clean</c> command cleans the output of the previous build. It's implemented as an <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-targets">MSBuild target</a>, so the project is evaluated when the command is run. Only the outputs created during the build are cleaned. Both intermediate <em>(obj)</em> and final output <em>(bin)</em> folders are cleaned.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetClean(string project, Configure<DotNetCleanSettings> configurator = null)
        {
            configurator = configurator ?? (x => x);
            return DotNetClean(x => configurator(x).SetProject(project));
        }
        /// <summary><p><c>dotnet publish</c> compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output will contain the following:<para/><ul><li>Intermediate Language (IL) code in an assembly with a <em>dll</em> extension.</li><li><em>.deps.json</em> file that contains all of the dependencies of the project.</li><li><em>.runtime.config.json</em> file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).</li><li>The application's dependencies. These are copied from the NuGet cache into the output folder.</li></ul><para/>The <c>dotnet publish</c> command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution and is the only officially supported way to prepare the application for deployment. Depending on the type of deployment that the project specifies, the hosting system may or may not have the .NET Core shared runtime installed on it. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>. For the directory structure of a published application, see <a href="https://docs.microsoft.com/en-us/aspnet/core/hosting/directory-structure">Directory structure</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetPublish(Configure<DotNetPublishSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetPublishSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Pushes a package to the server and publishes it.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> DotNetNuGetPush(Configure<DotNetNuGetPushSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetNuGetPushSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
    }
    #region DotNetTestSettings
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetTestSettings : ToolSettings
    {
        /// <summary><p>Path to the DotNet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        protected internal override Func<string, LogLevel> LogLevelParser => DotNetTasks.ParseLogLevel;
        /// <summary><p>Specifies a path to the test project. If omitted, it defaults to current directory.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>Use the custom test adapters from the specified path in the test run.</p></summary>
        public virtual string TestAdapterPath { get; internal set; }
        /// <summary><p>Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Enables data collector for the test run. For more information, see <a href="https://aka.ms/vstest-collect">Monitor and analyze test run</a>.</p></summary>
        public virtual string DataCollector { get; internal set; }
        /// <summary><p>Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.</p></summary>
        public virtual string DiagnosticsFile { get; internal set; }
        /// <summary><p>Looks for test binaries for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>.</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Filters out tests in the current project using the given expression. For more information, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests">Running selective unit tests</a>.</p></summary>
        public virtual string Filter { get; internal set; }
        /// <summary><p>Specifies a logger for test results.</p></summary>
        public virtual string Logger { get; internal set; }
        /// <summary><p>Does not build the test project prior to running it.</p></summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary><p>Doesn't perform an implicit restore when running the command.</p></summary>
        public virtual bool? NoRestore { get; internal set; }
        /// <summary><p>Directory in which to find the binaries to run.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>The directory where the test results are going to be placed. The specified directory will be created if it doesn't exist.</p></summary>
        public virtual string ResultsDirectory { get; internal set; }
        /// <summary><p>Settings to use when running tests.</p></summary>
        public virtual string SettingsFile { get; internal set; }
        /// <summary><p>List all of the discovered tests in the current project.</p></summary>
        public virtual bool? ListTests { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary><p>Disables restoring multiple projects in parallel.</p></summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary><p>Specifies to not cache packages and HTTP requests.</p></summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary><p>Specifies the directory for restored packages.</p></summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary><p>Enables project lock file to be generated and used with restore.</p></summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary><p>Don't allow updating project lock file.</p></summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        public virtual string Runtime { get; internal set; }
        /// <summary><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
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
    #region DotNetRunSettings
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetRunSettings : ToolSettings
    {
        /// <summary><p>Path to the DotNet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        protected internal override Func<string, LogLevel> LogLevelParser => DotNetTasks.ParseLogLevel;
        /// <summary><p>Configuration to use for building the project. The default value is Debug.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Builds and runs the app using the specified framework. The framework must be specified in the project file.</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the <em>launchSettings.json</em> file and are typically called <c>Development</c>, <c>Staging</c> and <c>Production</c>. For more information, see <a href="https://docs.microsoft.com/en-us/aspnetcore/fundamentals/environments">Working with multiple environments</a>.</p></summary>
        public virtual string LaunchProfile { get; internal set; }
        /// <summary><p>Doesn't build the project before running.</p></summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary><p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p></summary>
        public virtual bool? NoLaunchProfile { get; internal set; }
        /// <summary><p>Doesn't perform an implicit restore when running the command.</p></summary>
        public virtual bool? NoRestore { get; internal set; }
        /// <summary><p>Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>Arguments passed to the application being run.</p></summary>
        public virtual string ApplicationArguments { get; internal set; }
        /// <summary><p>Disables restoring multiple projects in parallel.</p></summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary><p>Specifies to not cache packages and HTTP requests.</p></summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary><p>Specifies the directory for restored packages.</p></summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary><p>Enables project lock file to be generated and used with restore.</p></summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary><p>Don't allow updating project lock file.</p></summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        public virtual string Runtime { get; internal set; }
        /// <summary><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
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
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetRestoreSettings : ToolSettings
    {
        /// <summary><p>Path to the DotNet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        protected internal override Func<string, LogLevel> LogLevelParser => DotNetTasks.ParseLogLevel;
        /// <summary><p>Optional path to the project file to restore.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>The NuGet configuration file (<em>NuGet.config</em>) to use for the restore operation.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary><p>Disables restoring multiple projects in parallel.</p></summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary><p>Specifies to not cache packages and HTTP requests.</p></summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary><p>Specifies the directory for restored packages.</p></summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary><p>Enables project lock file to be generated and used with restore.</p></summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary><p>Don't allow updating project lock file.</p></summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        public virtual string Runtime { get; internal set; }
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
              .Add("--runtime {value}", Runtime);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetPackSettings
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetPackSettings : ToolSettings
    {
        /// <summary><p>Path to the DotNet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        protected internal override Func<string, LogLevel> LogLevelParser => DotNetTasks.ParseLogLevel;
        /// <summary><p>The project to pack. It's either a path to a csproj file or to a directory. If omitted, it defaults to the current directory.</p></summary>
        public virtual string Project { get; internal set; }
        /// <summary><p>Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        public virtual bool? IncludeSource { get; internal set; }
        /// <summary><p>Generates the symbols <c>nupkg</c>.</p></summary>
        public virtual bool? IncludeSymbols { get; internal set; }
        /// <summary><p>Don't build the project before packing.</p></summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary><p>Doesn't perform an implicit restore when running the command.</p></summary>
        public virtual bool? NoRestore { get; internal set; }
        /// <summary><p>Places the built packages in the directory specified.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        public virtual bool? Serviceable { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity Verbostiy { get; internal set; }
        /// <summary><p>Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project.</p></summary>
        public virtual string VersionSuffix { get; internal set; }
        /// <summary><p>Disables restoring multiple projects in parallel.</p></summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary><p>Specifies to not cache packages and HTTP requests.</p></summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary><p>Specifies the directory for restored packages.</p></summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary><p>Enables project lock file to be generated and used with restore.</p></summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary><p>Don't allow updating project lock file.</p></summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        public virtual string Runtime { get; internal set; }
        /// <summary><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
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
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetBuildSettings : ToolSettings
    {
        /// <summary><p>Path to the DotNet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        protected internal override Func<string, LogLevel> LogLevelParser => DotNetTasks.ParseLogLevel;
        /// <summary><p>The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        public virtual bool? NoIncremental { get; internal set; }
        /// <summary><p>Doesn't perform an implicit restore during build.</p></summary>
        public virtual bool? NoRestore { get; internal set; }
        /// <summary><p>Directory in which to place the built binaries. You also need to define <c>--framework</c> when you specify this option.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p></summary>
        public virtual string Runtime { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary><p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p></summary>
        public virtual string VersionSuffix { get; internal set; }
        /// <summary><p>Disables restoring multiple projects in parallel.</p></summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary><p>Specifies to not cache packages and HTTP requests.</p></summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary><p>Specifies the directory for restored packages.</p></summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary><p>Enables project lock file to be generated and used with restore.</p></summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary><p>Don't allow updating project lock file.</p></summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
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
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetCleanSettings : ToolSettings
    {
        /// <summary><p>Path to the DotNet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        protected internal override Func<string, LogLevel> LogLevelParser => DotNetTasks.ParseLogLevel;
        /// <summary><p>The MSBuild project to clean. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in <em>proj</em> and uses that file.</p></summary>
        public virtual string Project { get; internal set; }
        /// <summary><p>Defines the build configuration. The default value is <c>Debug</c>. This option is only required when cleaning if you specified it during build time.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a> that was specified at build time. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>. If you specified the framework at build time, you must specify the framework when cleaning.</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Directory in which the build outputs are placed. Specify the <c>--framework</c> switch with the output directory switch if you specified the framework when the project was built.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Cleans the output folder of the specified runtime. This is used when a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment</a> was created.</p></summary>
        public virtual string Runtime { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed levels are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].</p></summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("clean")
              .Add("{value}", Project)
              .Add("--configuration {value}", Configuration)
              .Add("--framework {value}", Framework)
              .Add("--output {value}", Output)
              .Add("--runtime {value}", Runtime)
              .Add("--verbosity {value}", Verbosity);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetPublishSettings
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetPublishSettings : ToolSettings
    {
        /// <summary><p>Path to the DotNet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        protected internal override Func<string, LogLevel> LogLevelParser => DotNetTasks.ParseLogLevel;
        /// <summary><p>The project to publish, which defaults to the current directory if not specified.</p></summary>
        public virtual string Project { get; internal set; }
        /// <summary><p>Defines the build configuration. The default value is <c>Debug</c>.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Publishes the application for the specified <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. You must specify the target framework in the project file.</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Specifies one or several <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/runtime-store">target manifests</a> to use to trim the set of packages published with the app. The manifest file is part of the output of the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-store"><c>dotnet store</c></a> command. To specify multiple manifests, add a <c>--manifest</c> option for each manifest. This option is available starting with .NET Core 2.0 SDK.</p></summary>
        public virtual string Manifest { get; internal set; }
        /// <summary><p>Doesn't perform an implicit restore when running the command.</p></summary>
        public virtual bool? NoRestore { get; internal set; }
        /// <summary><p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p></summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary><p>Specifies the path for the output directory. If not specified, it defaults to <em>./bin/[configuration]/[framework]/</em> for a framework-dependent deployment or <em>./bin/[configuration]/[framework]/[runtime]</em> for a self-contained deployment.<para/>If a relative path is provided, the output directory generated is relative to the project file location, not to the current working directory.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p></summary>
        public virtual bool? SelfContained { get; internal set; }
        /// <summary><p>Publishes the application for a given runtime. This is used when creating a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment (SCD)</a>. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Default is to publish a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#framework-dependent-deployments-fdd">framework-dependent deployment (FDD)</a>.</p></summary>
        public virtual string Runtime { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary><p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p></summary>
        public virtual string VersionSuffix { get; internal set; }
        /// <summary><p>Disables restoring multiple projects in parallel.</p></summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary><p>Specifies to not cache packages and HTTP requests.</p></summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary><p>Specifies the directory for restored packages.</p></summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        /// <summary><p>Enables project lock file to be generated and used with restore.</p></summary>
        public virtual bool? UseLockFile { get; internal set; }
        /// <summary><p>Don't allow updating project lock file.</p></summary>
        public virtual bool? LockedMode { get; internal set; }
        /// <summary><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        public virtual string LockFilePath { get; internal set; }
        /// <summary><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        public virtual bool? ForceEvaluate { get; internal set; }
        /// <summary><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
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
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetNuGetPushSettings : ToolSettings
    {
        /// <summary><p>Path to the DotNet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? DotNetTasks.DotNetPath;
        protected internal override Func<string, LogLevel> LogLevelParser => DotNetTasks.ParseLogLevel;
        /// <summary><p>Path of the package to push.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>Specifies the server URL. This option is required unless <c>DefaultPushSource</c> config value is set in the NuGet config file.</p></summary>
        public virtual string Source { get; internal set; }
        /// <summary><p>Specifies the symbol server URL.</p></summary>
        public virtual string SymbolSource { get; internal set; }
        /// <summary><p>Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.</p></summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary><p>The API key for the server.</p></summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary><p>The API key for the symbol server.</p></summary>
        public virtual string SymbolApiKey { get; internal set; }
        /// <summary><p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p></summary>
        public virtual bool? DisableBuffering { get; internal set; }
        /// <summary><p>Doesn't push symbols (even if present).</p></summary>
        public virtual bool? NoSymbols { get; internal set; }
        /// <summary><p>Forces all logged output in English.</p></summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), $"File.Exists(TargetPath) [TargetPath = {TargetPath}]");
        }
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
              .Add("--force-english-output", ForceEnglishOutput);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetTestSettingsExtensions
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetTestSettingsExtensions
    {
        #region ProjectFile
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.ProjectFile"/>.</em></p><p>Specifies a path to the test project. If omitted, it defaults to current directory.</p></summary>
        [Pure]
        public static DotNetTestSettings SetProjectFile(this DotNetTestSettings toolSettings, string projectFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.ProjectFile"/>.</em></p><p>Specifies a path to the test project. If omitted, it defaults to current directory.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetProjectFile(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region TestAdapterPath
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.TestAdapterPath"/>.</em></p><p>Use the custom test adapters from the specified path in the test run.</p></summary>
        [Pure]
        public static DotNetTestSettings SetTestAdapterPath(this DotNetTestSettings toolSettings, string testAdapterPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestAdapterPath = testAdapterPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.TestAdapterPath"/>.</em></p><p>Use the custom test adapters from the specified path in the test run.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetTestAdapterPath(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TestAdapterPath = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Configuration"/>.</em></p><p>Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting.</p></summary>
        [Pure]
        public static DotNetTestSettings SetConfiguration(this DotNetTestSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.Configuration"/>.</em></p><p>Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetConfiguration(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region DataCollector
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.DataCollector"/>.</em></p><p>Enables data collector for the test run. For more information, see <a href="https://aka.ms/vstest-collect">Monitor and analyze test run</a>.</p></summary>
        [Pure]
        public static DotNetTestSettings SetDataCollector(this DotNetTestSettings toolSettings, string dataCollector)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataCollector = dataCollector;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.DataCollector"/>.</em></p><p>Enables data collector for the test run. For more information, see <a href="https://aka.ms/vstest-collect">Monitor and analyze test run</a>.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetDataCollector(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataCollector = null;
            return toolSettings;
        }
        #endregion
        #region DiagnosticsFile
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.DiagnosticsFile"/>.</em></p><p>Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.</p></summary>
        [Pure]
        public static DotNetTestSettings SetDiagnosticsFile(this DotNetTestSettings toolSettings, string diagnosticsFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiagnosticsFile = diagnosticsFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.DiagnosticsFile"/>.</em></p><p>Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetDiagnosticsFile(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiagnosticsFile = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Framework"/>.</em></p><p>Looks for test binaries for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>.</p></summary>
        [Pure]
        public static DotNetTestSettings SetFramework(this DotNetTestSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.Framework"/>.</em></p><p>Looks for test binaries for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetFramework(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Filter
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Filter"/>.</em></p><p>Filters out tests in the current project using the given expression. For more information, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests">Running selective unit tests</a>.</p></summary>
        [Pure]
        public static DotNetTestSettings SetFilter(this DotNetTestSettings toolSettings, string filter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.Filter"/>.</em></p><p>Filters out tests in the current project using the given expression. For more information, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests">Running selective unit tests</a>.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetFilter(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
            return toolSettings;
        }
        #endregion
        #region Logger
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Logger"/>.</em></p><p>Specifies a logger for test results.</p></summary>
        [Pure]
        public static DotNetTestSettings SetLogger(this DotNetTestSettings toolSettings, string logger)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logger = logger;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.Logger"/>.</em></p><p>Specifies a logger for test results.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetLogger(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logger = null;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.NoBuild"/>.</em></p><p>Does not build the test project prior to running it.</p></summary>
        [Pure]
        public static DotNetTestSettings SetNoBuild(this DotNetTestSettings toolSettings, bool? noBuild)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.NoBuild"/>.</em></p><p>Does not build the test project prior to running it.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetNoBuild(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.NoBuild"/>.</em></p><p>Does not build the test project prior to running it.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableNoBuild(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.NoBuild"/>.</em></p><p>Does not build the test project prior to running it.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableNoBuild(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.NoBuild"/>.</em></p><p>Does not build the test project prior to running it.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleNoBuild(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region NoRestore
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetTestSettings SetNoRestore(this DotNetTestSettings toolSettings, bool? noRestore)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = noRestore;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetNoRestore(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableNoRestore(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableNoRestore(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleNoRestore(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = !toolSettings.NoRestore;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Output"/>.</em></p><p>Directory in which to find the binaries to run.</p></summary>
        [Pure]
        public static DotNetTestSettings SetOutput(this DotNetTestSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.Output"/>.</em></p><p>Directory in which to find the binaries to run.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetOutput(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region ResultsDirectory
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.ResultsDirectory"/>.</em></p><p>The directory where the test results are going to be placed. The specified directory will be created if it doesn't exist.</p></summary>
        [Pure]
        public static DotNetTestSettings SetResultsDirectory(this DotNetTestSettings toolSettings, string resultsDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsDirectory = resultsDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.ResultsDirectory"/>.</em></p><p>The directory where the test results are going to be placed. The specified directory will be created if it doesn't exist.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetResultsDirectory(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResultsDirectory = null;
            return toolSettings;
        }
        #endregion
        #region SettingsFile
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.SettingsFile"/>.</em></p><p>Settings to use when running tests.</p></summary>
        [Pure]
        public static DotNetTestSettings SetSettingsFile(this DotNetTestSettings toolSettings, string settingsFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SettingsFile = settingsFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.SettingsFile"/>.</em></p><p>Settings to use when running tests.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetSettingsFile(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SettingsFile = null;
            return toolSettings;
        }
        #endregion
        #region ListTests
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.ListTests"/>.</em></p><p>List all of the discovered tests in the current project.</p></summary>
        [Pure]
        public static DotNetTestSettings SetListTests(this DotNetTestSettings toolSettings, bool? listTests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListTests = listTests;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.ListTests"/>.</em></p><p>List all of the discovered tests in the current project.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetListTests(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListTests = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.ListTests"/>.</em></p><p>List all of the discovered tests in the current project.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableListTests(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListTests = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.ListTests"/>.</em></p><p>List all of the discovered tests in the current project.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableListTests(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListTests = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.ListTests"/>.</em></p><p>List all of the discovered tests in the current project.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleListTests(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ListTests = !toolSettings.ListTests;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Verbosity"/>.</em></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetTestSettings SetVerbosity(this DotNetTestSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.Verbosity"/>.</em></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetVerbosity(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetTestSettings SetDisableParallel(this DotNetTestSettings toolSettings, bool? disableParallel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetDisableParallel(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableDisableParallel(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableDisableParallel(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleDisableParallel(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetTestSettings SetForce(this DotNetTestSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetForce(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableForce(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableForce(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleForce(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetTestSettings SetIgnoreFailedSources(this DotNetTestSettings toolSettings, bool? ignoreFailedSources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetIgnoreFailedSources(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableIgnoreFailedSources(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableIgnoreFailedSources(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleIgnoreFailedSources(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetTestSettings SetNoCache(this DotNetTestSettings toolSettings, bool? noCache)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetNoCache(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableNoCache(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableNoCache(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleNoCache(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetTestSettings SetNoDependencies(this DotNetTestSettings toolSettings, bool? noDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetNoDependencies(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableNoDependencies(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableNoDependencies(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleNoDependencies(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetTestSettings SetPackageDirectory(this DotNetTestSettings toolSettings, string packageDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetPackageDirectory(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetTestSettings SetSources(this DotNetTestSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetTestSettings SetSources(this DotNetTestSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetTestSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetTestSettings AddSources(this DotNetTestSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetTestSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetTestSettings AddSources(this DotNetTestSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetTestSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetTestSettings ClearSources(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetTestSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetTestSettings RemoveSources(this DotNetTestSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetTestSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetTestSettings RemoveSources(this DotNetTestSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetTestSettings SetUseLockFile(this DotNetTestSettings toolSettings, bool? useLockFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetUseLockFile(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableUseLockFile(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableUseLockFile(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleUseLockFile(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetTestSettings SetLockedMode(this DotNetTestSettings toolSettings, bool? lockedMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetLockedMode(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableLockedMode(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableLockedMode(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleLockedMode(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetTestSettings SetLockFilePath(this DotNetTestSettings toolSettings, string lockFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetLockFilePath(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetTestSettings SetForceEvaluate(this DotNetTestSettings toolSettings, bool? forceEvaluate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetForceEvaluate(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetTestSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableForceEvaluate(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetTestSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableForceEvaluate(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetTestSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleForceEvaluate(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Runtime"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetTestSettings SetRuntime(this DotNetTestSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetTestSettings.Runtime"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetTestSettings ResetRuntime(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary><p><em>Sets <see cref="DotNetTestSettings.Properties"/> to a new dictionary.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetProperties(this DotNetTestSettings toolSettings, IDictionary<string, object> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ClearProperties(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings AddProperty(this DotNetTestSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings RemoveProperty(this DotNetTestSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetProperty(this DotNetTestSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary><p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetRunCodeAnalysis(this DotNetTestSettings toolSettings, bool? runCodeAnalysis)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ResetRunCodeAnalysis(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings EnableRunCodeAnalysis(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings DisableRunCodeAnalysis(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ToggleRunCodeAnalysis(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary><p><em>Sets <c>NoWarn</c> in <see cref="DotNetTestSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetNoWarns(this DotNetTestSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>NoWarn</c> in <see cref="DotNetTestSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetNoWarns(this DotNetTestSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings AddNoWarns(this DotNetTestSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings AddNoWarns(this DotNetTestSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>NoWarn</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ClearNoWarns(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings RemoveNoWarns(this DotNetTestSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings RemoveNoWarns(this DotNetTestSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary><p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetWarningsAsErrors(this DotNetTestSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetWarningsAsErrors(this DotNetTestSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings AddWarningsAsErrors(this DotNetTestSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings AddWarningsAsErrors(this DotNetTestSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ClearWarningsAsErrors(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings RemoveWarningsAsErrors(this DotNetTestSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings RemoveWarningsAsErrors(this DotNetTestSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary><p><em>Sets <c>WarningLevel</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetWarningLevel(this DotNetTestSettings toolSettings, int? warningLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>WarningLevel</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ResetWarningLevel(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary><p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetTreatWarningsAsErrors(this DotNetTestSettings toolSettings, bool? treatWarningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ResetTreatWarningsAsErrors(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings EnableTreatWarningsAsErrors(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings DisableTreatWarningsAsErrors(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ToggleTreatWarningsAsErrors(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary><p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetAssemblyVersion(this DotNetTestSettings toolSettings, string assemblyVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ResetAssemblyVersion(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary><p><em>Sets <c>FileVersion</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetFileVersion(this DotNetTestSettings toolSettings, string fileVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>FileVersion</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ResetFileVersion(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary><p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings SetInformationalVersion(this DotNetTestSettings toolSettings, string informationalVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetTestSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetTestSettings ResetInformationalVersion(this DotNetTestSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetRunSettingsExtensions
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetRunSettingsExtensions
    {
        #region Configuration
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.Configuration"/>.</em></p><p>Configuration to use for building the project. The default value is Debug.</p></summary>
        [Pure]
        public static DotNetRunSettings SetConfiguration(this DotNetRunSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.Configuration"/>.</em></p><p>Configuration to use for building the project. The default value is Debug.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetConfiguration(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.Framework"/>.</em></p><p>Builds and runs the app using the specified framework. The framework must be specified in the project file.</p></summary>
        [Pure]
        public static DotNetRunSettings SetFramework(this DotNetRunSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.Framework"/>.</em></p><p>Builds and runs the app using the specified framework. The framework must be specified in the project file.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetFramework(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region LaunchProfile
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.LaunchProfile"/>.</em></p><p>The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the <em>launchSettings.json</em> file and are typically called <c>Development</c>, <c>Staging</c> and <c>Production</c>. For more information, see <a href="https://docs.microsoft.com/en-us/aspnetcore/fundamentals/environments">Working with multiple environments</a>.</p></summary>
        [Pure]
        public static DotNetRunSettings SetLaunchProfile(this DotNetRunSettings toolSettings, string launchProfile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LaunchProfile = launchProfile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.LaunchProfile"/>.</em></p><p>The name of the launch profile (if any) to use when launching the application. Launch profiles are defined in the <em>launchSettings.json</em> file and are typically called <c>Development</c>, <c>Staging</c> and <c>Production</c>. For more information, see <a href="https://docs.microsoft.com/en-us/aspnetcore/fundamentals/environments">Working with multiple environments</a>.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetLaunchProfile(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LaunchProfile = null;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.NoBuild"/>.</em></p><p>Doesn't build the project before running.</p></summary>
        [Pure]
        public static DotNetRunSettings SetNoBuild(this DotNetRunSettings toolSettings, bool? noBuild)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.NoBuild"/>.</em></p><p>Doesn't build the project before running.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetNoBuild(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.NoBuild"/>.</em></p><p>Doesn't build the project before running.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableNoBuild(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.NoBuild"/>.</em></p><p>Doesn't build the project before running.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableNoBuild(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.NoBuild"/>.</em></p><p>Doesn't build the project before running.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleNoBuild(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region NoLaunchProfile
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.NoLaunchProfile"/>.</em></p><p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p></summary>
        [Pure]
        public static DotNetRunSettings SetNoLaunchProfile(this DotNetRunSettings toolSettings, bool? noLaunchProfile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLaunchProfile = noLaunchProfile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.NoLaunchProfile"/>.</em></p><p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetNoLaunchProfile(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLaunchProfile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.NoLaunchProfile"/>.</em></p><p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableNoLaunchProfile(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLaunchProfile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.NoLaunchProfile"/>.</em></p><p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableNoLaunchProfile(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLaunchProfile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.NoLaunchProfile"/>.</em></p><p>Doesn't attempt to use <em>launchSettings.json</em> to configure the application.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleNoLaunchProfile(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLaunchProfile = !toolSettings.NoLaunchProfile;
            return toolSettings;
        }
        #endregion
        #region NoRestore
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetRunSettings SetNoRestore(this DotNetRunSettings toolSettings, bool? noRestore)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = noRestore;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetNoRestore(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableNoRestore(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableNoRestore(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleNoRestore(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = !toolSettings.NoRestore;
            return toolSettings;
        }
        #endregion
        #region ProjectFile
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.ProjectFile"/>.</em></p><p>Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.</p></summary>
        [Pure]
        public static DotNetRunSettings SetProjectFile(this DotNetRunSettings toolSettings, string projectFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.ProjectFile"/>.</em></p><p>Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetProjectFile(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region ApplicationArguments
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.ApplicationArguments"/>.</em></p><p>Arguments passed to the application being run.</p></summary>
        [Pure]
        public static DotNetRunSettings SetApplicationArguments(this DotNetRunSettings toolSettings, string applicationArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApplicationArguments = applicationArguments;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.ApplicationArguments"/>.</em></p><p>Arguments passed to the application being run.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetApplicationArguments(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApplicationArguments = null;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRunSettings SetDisableParallel(this DotNetRunSettings toolSettings, bool? disableParallel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetDisableParallel(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableDisableParallel(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableDisableParallel(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleDisableParallel(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetRunSettings SetForce(this DotNetRunSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetForce(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableForce(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableForce(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleForce(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRunSettings SetIgnoreFailedSources(this DotNetRunSettings toolSettings, bool? ignoreFailedSources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetIgnoreFailedSources(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableIgnoreFailedSources(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableIgnoreFailedSources(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleIgnoreFailedSources(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRunSettings SetNoCache(this DotNetRunSettings toolSettings, bool? noCache)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetNoCache(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableNoCache(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableNoCache(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleNoCache(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRunSettings SetNoDependencies(this DotNetRunSettings toolSettings, bool? noDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetNoDependencies(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableNoDependencies(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableNoDependencies(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleNoDependencies(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetRunSettings SetPackageDirectory(this DotNetRunSettings toolSettings, string packageDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetPackageDirectory(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRunSettings SetSources(this DotNetRunSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRunSettings SetSources(this DotNetRunSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetRunSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRunSettings AddSources(this DotNetRunSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetRunSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRunSettings AddSources(this DotNetRunSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetRunSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRunSettings ClearSources(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetRunSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRunSettings RemoveSources(this DotNetRunSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetRunSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRunSettings RemoveSources(this DotNetRunSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetRunSettings SetUseLockFile(this DotNetRunSettings toolSettings, bool? useLockFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetUseLockFile(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableUseLockFile(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableUseLockFile(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleUseLockFile(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetRunSettings SetLockedMode(this DotNetRunSettings toolSettings, bool? lockedMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetLockedMode(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableLockedMode(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableLockedMode(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleLockedMode(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetRunSettings SetLockFilePath(this DotNetRunSettings toolSettings, string lockFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetLockFilePath(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetRunSettings SetForceEvaluate(this DotNetRunSettings toolSettings, bool? forceEvaluate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetForceEvaluate(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRunSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetRunSettings EnableForceEvaluate(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRunSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetRunSettings DisableForceEvaluate(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRunSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetRunSettings ToggleForceEvaluate(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.Runtime"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRunSettings SetRuntime(this DotNetRunSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRunSettings.Runtime"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRunSettings ResetRuntime(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary><p><em>Sets <see cref="DotNetRunSettings.Properties"/> to a new dictionary.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetProperties(this DotNetRunSettings toolSettings, IDictionary<string, object> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ClearProperties(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings AddProperty(this DotNetRunSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings RemoveProperty(this DotNetRunSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetProperty(this DotNetRunSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary><p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetRunCodeAnalysis(this DotNetRunSettings toolSettings, bool? runCodeAnalysis)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ResetRunCodeAnalysis(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings EnableRunCodeAnalysis(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings DisableRunCodeAnalysis(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ToggleRunCodeAnalysis(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary><p><em>Sets <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetNoWarns(this DotNetRunSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetNoWarns(this DotNetRunSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings AddNoWarns(this DotNetRunSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings AddNoWarns(this DotNetRunSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ClearNoWarns(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings RemoveNoWarns(this DotNetRunSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings RemoveNoWarns(this DotNetRunSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary><p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetWarningsAsErrors(this DotNetRunSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetWarningsAsErrors(this DotNetRunSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings AddWarningsAsErrors(this DotNetRunSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings AddWarningsAsErrors(this DotNetRunSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ClearWarningsAsErrors(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings RemoveWarningsAsErrors(this DotNetRunSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings RemoveWarningsAsErrors(this DotNetRunSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary><p><em>Sets <c>WarningLevel</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetWarningLevel(this DotNetRunSettings toolSettings, int? warningLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>WarningLevel</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ResetWarningLevel(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary><p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetTreatWarningsAsErrors(this DotNetRunSettings toolSettings, bool? treatWarningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ResetTreatWarningsAsErrors(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings EnableTreatWarningsAsErrors(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings DisableTreatWarningsAsErrors(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ToggleTreatWarningsAsErrors(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary><p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetAssemblyVersion(this DotNetRunSettings toolSettings, string assemblyVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ResetAssemblyVersion(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary><p><em>Sets <c>FileVersion</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetFileVersion(this DotNetRunSettings toolSettings, string fileVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>FileVersion</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ResetFileVersion(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary><p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings SetInformationalVersion(this DotNetRunSettings toolSettings, string informationalVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetRunSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetRunSettings ResetInformationalVersion(this DotNetRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetRestoreSettingsExtensions
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetRestoreSettingsExtensions
    {
        #region ProjectFile
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.ProjectFile"/>.</em></p><p>Optional path to the project file to restore.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetProjectFile(this DotNetRestoreSettings toolSettings, string projectFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.ProjectFile"/>.</em></p><p>Optional path to the project file to restore.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetProjectFile(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.ConfigFile"/>.</em></p><p>The NuGet configuration file (<em>NuGet.config</em>) to use for the restore operation.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetConfigFile(this DotNetRestoreSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.ConfigFile"/>.</em></p><p>The NuGet configuration file (<em>NuGet.config</em>) to use for the restore operation.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetConfigFile(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.Verbosity"/>.</em></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetVerbosity(this DotNetRestoreSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.Verbosity"/>.</em></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetVerbosity(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetDisableParallel(this DotNetRestoreSettings toolSettings, bool? disableParallel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetDisableParallel(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRestoreSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableDisableParallel(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRestoreSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableDisableParallel(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRestoreSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleDisableParallel(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetForce(this DotNetRestoreSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetForce(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRestoreSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableForce(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRestoreSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableForce(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRestoreSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleForce(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetIgnoreFailedSources(this DotNetRestoreSettings toolSettings, bool? ignoreFailedSources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetIgnoreFailedSources(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableIgnoreFailedSources(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableIgnoreFailedSources(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleIgnoreFailedSources(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetNoCache(this DotNetRestoreSettings toolSettings, bool? noCache)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetNoCache(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRestoreSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableNoCache(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRestoreSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableNoCache(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRestoreSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleNoCache(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetNoDependencies(this DotNetRestoreSettings toolSettings, bool? noDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetNoDependencies(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRestoreSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableNoDependencies(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRestoreSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableNoDependencies(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRestoreSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleNoDependencies(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetPackageDirectory(this DotNetRestoreSettings toolSettings, string packageDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetPackageDirectory(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetSources(this DotNetRestoreSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetSources(this DotNetRestoreSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetRestoreSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings AddSources(this DotNetRestoreSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetRestoreSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings AddSources(this DotNetRestoreSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetRestoreSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ClearSources(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetRestoreSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings RemoveSources(this DotNetRestoreSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetRestoreSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings RemoveSources(this DotNetRestoreSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetUseLockFile(this DotNetRestoreSettings toolSettings, bool? useLockFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetUseLockFile(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRestoreSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableUseLockFile(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRestoreSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableUseLockFile(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRestoreSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleUseLockFile(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetLockedMode(this DotNetRestoreSettings toolSettings, bool? lockedMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetLockedMode(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRestoreSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableLockedMode(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRestoreSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableLockedMode(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRestoreSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleLockedMode(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetLockFilePath(this DotNetRestoreSettings toolSettings, string lockFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetLockFilePath(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetForceEvaluate(this DotNetRestoreSettings toolSettings, bool? forceEvaluate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetForceEvaluate(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetRestoreSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableForceEvaluate(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetRestoreSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableForceEvaluate(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetRestoreSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleForceEvaluate(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.Runtime"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetRuntime(this DotNetRestoreSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.Runtime"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetRuntime(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetPackSettingsExtensions
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetPackSettingsExtensions
    {
        #region Project
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.Project"/>.</em></p><p>The project to pack. It's either a path to a csproj file or to a directory. If omitted, it defaults to the current directory.</p></summary>
        [Pure]
        public static DotNetPackSettings SetProject(this DotNetPackSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.Project"/>.</em></p><p>The project to pack. It's either a path to a csproj file or to a directory. If omitted, it defaults to the current directory.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetProject(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.Configuration"/>.</em></p><p>Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings SetConfiguration(this DotNetPackSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.Configuration"/>.</em></p><p>Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetConfiguration(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region IncludeSource
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.IncludeSource"/>.</em></p><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings SetIncludeSource(this DotNetPackSettings toolSettings, bool? includeSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSource = includeSource;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.IncludeSource"/>.</em></p><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetIncludeSource(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSource = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.IncludeSource"/>.</em></p><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableIncludeSource(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSource = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.IncludeSource"/>.</em></p><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableIncludeSource(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSource = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.IncludeSource"/>.</em></p><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleIncludeSource(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSource = !toolSettings.IncludeSource;
            return toolSettings;
        }
        #endregion
        #region IncludeSymbols
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.IncludeSymbols"/>.</em></p><p>Generates the symbols <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings SetIncludeSymbols(this DotNetPackSettings toolSettings, bool? includeSymbols)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSymbols = includeSymbols;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.IncludeSymbols"/>.</em></p><p>Generates the symbols <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetIncludeSymbols(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSymbols = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.IncludeSymbols"/>.</em></p><p>Generates the symbols <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableIncludeSymbols(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSymbols = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.IncludeSymbols"/>.</em></p><p>Generates the symbols <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableIncludeSymbols(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSymbols = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.IncludeSymbols"/>.</em></p><p>Generates the symbols <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleIncludeSymbols(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeSymbols = !toolSettings.IncludeSymbols;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.NoBuild"/>.</em></p><p>Don't build the project before packing.</p></summary>
        [Pure]
        public static DotNetPackSettings SetNoBuild(this DotNetPackSettings toolSettings, bool? noBuild)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.NoBuild"/>.</em></p><p>Don't build the project before packing.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetNoBuild(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.NoBuild"/>.</em></p><p>Don't build the project before packing.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableNoBuild(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.NoBuild"/>.</em></p><p>Don't build the project before packing.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableNoBuild(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.NoBuild"/>.</em></p><p>Don't build the project before packing.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleNoBuild(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region NoRestore
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetPackSettings SetNoRestore(this DotNetPackSettings toolSettings, bool? noRestore)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = noRestore;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetNoRestore(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableNoRestore(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableNoRestore(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleNoRestore(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = !toolSettings.NoRestore;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.OutputDirectory"/>.</em></p><p>Places the built packages in the directory specified.</p></summary>
        [Pure]
        public static DotNetPackSettings SetOutputDirectory(this DotNetPackSettings toolSettings, string outputDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.OutputDirectory"/>.</em></p><p>Places the built packages in the directory specified.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetOutputDirectory(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Serviceable
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.Serviceable"/>.</em></p><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        [Pure]
        public static DotNetPackSettings SetServiceable(this DotNetPackSettings toolSettings, bool? serviceable)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serviceable = serviceable;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.Serviceable"/>.</em></p><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetServiceable(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serviceable = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.Serviceable"/>.</em></p><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableServiceable(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serviceable = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.Serviceable"/>.</em></p><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableServiceable(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serviceable = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.Serviceable"/>.</em></p><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleServiceable(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serviceable = !toolSettings.Serviceable;
            return toolSettings;
        }
        #endregion
        #region Verbostiy
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.Verbostiy"/>.</em></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings SetVerbostiy(this DotNetPackSettings toolSettings, DotNetVerbosity verbostiy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbostiy = verbostiy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.Verbostiy"/>.</em></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetVerbostiy(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbostiy = null;
            return toolSettings;
        }
        #endregion
        #region VersionSuffix
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.VersionSuffix"/>.</em></p><p>Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project.</p></summary>
        [Pure]
        public static DotNetPackSettings SetVersionSuffix(this DotNetPackSettings toolSettings, string versionSuffix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = versionSuffix;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.VersionSuffix"/>.</em></p><p>Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetVersionSuffix(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = null;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetPackSettings SetDisableParallel(this DotNetPackSettings toolSettings, bool? disableParallel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetDisableParallel(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableDisableParallel(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableDisableParallel(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleDisableParallel(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetPackSettings SetForce(this DotNetPackSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetForce(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableForce(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableForce(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleForce(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetPackSettings SetIgnoreFailedSources(this DotNetPackSettings toolSettings, bool? ignoreFailedSources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetIgnoreFailedSources(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableIgnoreFailedSources(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableIgnoreFailedSources(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleIgnoreFailedSources(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetPackSettings SetNoCache(this DotNetPackSettings toolSettings, bool? noCache)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetNoCache(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableNoCache(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableNoCache(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleNoCache(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetPackSettings SetNoDependencies(this DotNetPackSettings toolSettings, bool? noDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetNoDependencies(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableNoDependencies(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableNoDependencies(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleNoDependencies(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetPackSettings SetPackageDirectory(this DotNetPackSettings toolSettings, string packageDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetPackageDirectory(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPackSettings SetSources(this DotNetPackSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPackSettings SetSources(this DotNetPackSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetPackSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPackSettings AddSources(this DotNetPackSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetPackSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPackSettings AddSources(this DotNetPackSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetPackSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPackSettings ClearSources(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetPackSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPackSettings RemoveSources(this DotNetPackSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetPackSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPackSettings RemoveSources(this DotNetPackSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetPackSettings SetUseLockFile(this DotNetPackSettings toolSettings, bool? useLockFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetUseLockFile(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableUseLockFile(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableUseLockFile(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleUseLockFile(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetPackSettings SetLockedMode(this DotNetPackSettings toolSettings, bool? lockedMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetLockedMode(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableLockedMode(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableLockedMode(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleLockedMode(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetPackSettings SetLockFilePath(this DotNetPackSettings toolSettings, string lockFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetLockFilePath(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetPackSettings SetForceEvaluate(this DotNetPackSettings toolSettings, bool? forceEvaluate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetForceEvaluate(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPackSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableForceEvaluate(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPackSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableForceEvaluate(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPackSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleForceEvaluate(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.Runtime"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPackSettings SetRuntime(this DotNetPackSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPackSettings.Runtime"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPackSettings ResetRuntime(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary><p><em>Sets <see cref="DotNetPackSettings.Properties"/> to a new dictionary.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetProperties(this DotNetPackSettings toolSettings, IDictionary<string, object> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ClearProperties(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings AddProperty(this DotNetPackSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings RemoveProperty(this DotNetPackSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetProperty(this DotNetPackSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary><p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetRunCodeAnalysis(this DotNetPackSettings toolSettings, bool? runCodeAnalysis)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetRunCodeAnalysis(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings EnableRunCodeAnalysis(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings DisableRunCodeAnalysis(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ToggleRunCodeAnalysis(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary><p><em>Sets <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetNoWarns(this DotNetPackSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetNoWarns(this DotNetPackSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings AddNoWarns(this DotNetPackSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings AddNoWarns(this DotNetPackSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ClearNoWarns(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings RemoveNoWarns(this DotNetPackSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings RemoveNoWarns(this DotNetPackSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary><p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetWarningsAsErrors(this DotNetPackSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetWarningsAsErrors(this DotNetPackSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings AddWarningsAsErrors(this DotNetPackSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings AddWarningsAsErrors(this DotNetPackSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ClearWarningsAsErrors(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings RemoveWarningsAsErrors(this DotNetPackSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings RemoveWarningsAsErrors(this DotNetPackSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary><p><em>Sets <c>WarningLevel</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetWarningLevel(this DotNetPackSettings toolSettings, int? warningLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>WarningLevel</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetWarningLevel(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary><p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetTreatWarningsAsErrors(this DotNetPackSettings toolSettings, bool? treatWarningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetTreatWarningsAsErrors(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings EnableTreatWarningsAsErrors(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings DisableTreatWarningsAsErrors(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ToggleTreatWarningsAsErrors(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary><p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetAssemblyVersion(this DotNetPackSettings toolSettings, string assemblyVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetAssemblyVersion(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary><p><em>Sets <c>FileVersion</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetFileVersion(this DotNetPackSettings toolSettings, string fileVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>FileVersion</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetFileVersion(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary><p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetInformationalVersion(this DotNetPackSettings toolSettings, string informationalVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetInformationalVersion(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #region PackageId
        /// <summary><p><em>Sets <c>PackageId</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetPackageId(this DotNetPackSettings toolSettings, string packageId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageId"] = packageId;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>PackageId</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetPackageId(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageId");
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary><p><em>Sets <c>Version</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetVersion(this DotNetPackSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Version"] = version;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>Version</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetVersion(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Version");
            return toolSettings;
        }
        #endregion
        #region VersionPrefix
        /// <summary><p><em>Sets <c>VersionPrefix</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetVersionPrefix(this DotNetPackSettings toolSettings, string versionPrefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["VersionPrefix"] = versionPrefix;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>VersionPrefix</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetVersionPrefix(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("VersionPrefix");
            return toolSettings;
        }
        #endregion
        #region Authors
        /// <summary><p><em>Sets <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetAuthors(this DotNetPackSettings toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetAuthors(this DotNetPackSettings toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings AddAuthors(this DotNetPackSettings toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>Authors</c> in existing <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings AddAuthors(this DotNetPackSettings toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ClearAuthors(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Authors");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings RemoveAuthors(this DotNetPackSettings toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>Authors</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings RemoveAuthors(this DotNetPackSettings toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }
        #endregion
        #region Title
        /// <summary><p><em>Sets <c>Title</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetTitle(this DotNetPackSettings toolSettings, string title)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Title"] = title;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>Title</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetTitle(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Title");
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary><p><em>Sets <c>Description</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetDescription(this DotNetPackSettings toolSettings, string description)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Description"] = description;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>Description</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetDescription(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Description");
            return toolSettings;
        }
        #endregion
        #region Copyright
        /// <summary><p><em>Sets <c>Copyright</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetCopyright(this DotNetPackSettings toolSettings, string copyright)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Copyright"] = copyright;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>Copyright</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetCopyright(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Copyright");
            return toolSettings;
        }
        #endregion
        #region PackageRequireLicenseAcceptance
        /// <summary><p><em>Sets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetPackageRequireLicenseAcceptance(this DotNetPackSettings toolSettings, bool? packageRequireLicenseAcceptance)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = packageRequireLicenseAcceptance;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetPackageRequireLicenseAcceptance(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings EnablePackageRequireLicenseAcceptance(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings DisablePackageRequireLicenseAcceptance(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>PackageRequireLicenseAcceptance</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings TogglePackageRequireLicenseAcceptance(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PackageRequireLicenseAcceptance");
            return toolSettings;
        }
        #endregion
        #region PackageLicenseUrl
        /// <summary><p><em>Sets <c>PackageLicenseUrl</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetPackageLicenseUrl(this DotNetPackSettings toolSettings, string packageLicenseUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageLicenseUrl"] = packageLicenseUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>PackageLicenseUrl</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetPackageLicenseUrl(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageLicenseUrl");
            return toolSettings;
        }
        #endregion
        #region PackageProjectUrl
        /// <summary><p><em>Sets <c>PackageProjectUrl</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetPackageProjectUrl(this DotNetPackSettings toolSettings, string packageProjectUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageProjectUrl"] = packageProjectUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>PackageProjectUrl</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetPackageProjectUrl(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageProjectUrl");
            return toolSettings;
        }
        #endregion
        #region PackageIconUrl
        /// <summary><p><em>Sets <c>PackageIconUrl</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetPackageIconUrl(this DotNetPackSettings toolSettings, string packageIconUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageIconUrl"] = packageIconUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>PackageIconUrl</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetPackageIconUrl(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageIconUrl");
            return toolSettings;
        }
        #endregion
        #region PackageTags
        /// <summary><p><em>Sets <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetPackageTags(this DotNetPackSettings toolSettings, params string[] packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetPackageTags(this DotNetPackSettings toolSettings, IEnumerable<string> packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings AddPackageTags(this DotNetPackSettings toolSettings, params string[] packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>PackageTags</c> in existing <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings AddPackageTags(this DotNetPackSettings toolSettings, IEnumerable<string> packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ClearPackageTags(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageTags");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings RemovePackageTags(this DotNetPackSettings toolSettings, params string[] packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>PackageTags</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings RemovePackageTags(this DotNetPackSettings toolSettings, IEnumerable<string> packageTags)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }
        #endregion
        #region PackageReleaseNotes
        /// <summary><p><em>Sets <c>PackageReleaseNotes</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetPackageReleaseNotes(this DotNetPackSettings toolSettings, string packageReleaseNotes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageReleaseNotes"] = packageReleaseNotes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>PackageReleaseNotes</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetPackageReleaseNotes(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageReleaseNotes");
            return toolSettings;
        }
        #endregion
        #region RepositoryUrl
        /// <summary><p><em>Sets <c>RepositoryUrl</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetRepositoryUrl(this DotNetPackSettings toolSettings, string repositoryUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryUrl"] = repositoryUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>RepositoryUrl</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetRepositoryUrl(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryUrl");
            return toolSettings;
        }
        #endregion
        #region RepositoryType
        /// <summary><p><em>Sets <c>RepositoryType</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings SetRepositoryType(this DotNetPackSettings toolSettings, string repositoryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryType"] = repositoryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>RepositoryType</c> in <see cref="DotNetPackSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPackSettings ResetRepositoryType(this DotNetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryType");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetBuildSettingsExtensions
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetBuildSettingsExtensions
    {
        #region ProjectFile
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.ProjectFile"/>.</em></p><p>The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetProjectFile(this DotNetBuildSettings toolSettings, string projectFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.ProjectFile"/>.</em></p><p>The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetProjectFile(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.Configuration"/>.</em></p><p>Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetConfiguration(this DotNetBuildSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.Configuration"/>.</em></p><p>Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetConfiguration(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.Framework"/>.</em></p><p>Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetFramework(this DotNetBuildSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.Framework"/>.</em></p><p>Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetFramework(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region NoIncremental
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.NoIncremental"/>.</em></p><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetNoIncremental(this DotNetBuildSettings toolSettings, bool? noIncremental)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoIncremental = noIncremental;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.NoIncremental"/>.</em></p><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetNoIncremental(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoIncremental = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.NoIncremental"/>.</em></p><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableNoIncremental(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoIncremental = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.NoIncremental"/>.</em></p><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableNoIncremental(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoIncremental = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.NoIncremental"/>.</em></p><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleNoIncremental(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoIncremental = !toolSettings.NoIncremental;
            return toolSettings;
        }
        #endregion
        #region NoRestore
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore during build.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetNoRestore(this DotNetBuildSettings toolSettings, bool? noRestore)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = noRestore;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore during build.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetNoRestore(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore during build.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableNoRestore(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore during build.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableNoRestore(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore during build.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleNoRestore(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = !toolSettings.NoRestore;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.OutputDirectory"/>.</em></p><p>Directory in which to place the built binaries. You also need to define <c>--framework</c> when you specify this option.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetOutputDirectory(this DotNetBuildSettings toolSettings, string outputDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.OutputDirectory"/>.</em></p><p>Directory in which to place the built binaries. You also need to define <c>--framework</c> when you specify this option.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetOutputDirectory(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.Runtime"/>.</em></p><p>Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetRuntime(this DotNetBuildSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.Runtime"/>.</em></p><p>Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetRuntime(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.Verbosity"/>.</em></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetVerbosity(this DotNetBuildSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.Verbosity"/>.</em></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetVerbosity(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region VersionSuffix
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.VersionSuffix"/>.</em></p><p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetVersionSuffix(this DotNetBuildSettings toolSettings, string versionSuffix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = versionSuffix;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.VersionSuffix"/>.</em></p><p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetVersionSuffix(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = null;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetDisableParallel(this DotNetBuildSettings toolSettings, bool? disableParallel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetDisableParallel(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableDisableParallel(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableDisableParallel(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleDisableParallel(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetForce(this DotNetBuildSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetForce(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableForce(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableForce(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleForce(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetIgnoreFailedSources(this DotNetBuildSettings toolSettings, bool? ignoreFailedSources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetIgnoreFailedSources(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableIgnoreFailedSources(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableIgnoreFailedSources(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleIgnoreFailedSources(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetNoCache(this DotNetBuildSettings toolSettings, bool? noCache)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetNoCache(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableNoCache(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableNoCache(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleNoCache(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetNoDependencies(this DotNetBuildSettings toolSettings, bool? noDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetNoDependencies(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableNoDependencies(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableNoDependencies(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleNoDependencies(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetPackageDirectory(this DotNetBuildSettings toolSettings, string packageDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetPackageDirectory(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetSources(this DotNetBuildSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetSources(this DotNetBuildSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetBuildSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetBuildSettings AddSources(this DotNetBuildSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetBuildSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetBuildSettings AddSources(this DotNetBuildSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetBuildSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetBuildSettings ClearSources(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetBuildSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetBuildSettings RemoveSources(this DotNetBuildSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetBuildSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetBuildSettings RemoveSources(this DotNetBuildSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetUseLockFile(this DotNetBuildSettings toolSettings, bool? useLockFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetUseLockFile(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableUseLockFile(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableUseLockFile(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleUseLockFile(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetLockedMode(this DotNetBuildSettings toolSettings, bool? lockedMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetLockedMode(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableLockedMode(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableLockedMode(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleLockedMode(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetLockFilePath(this DotNetBuildSettings toolSettings, string lockFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetLockFilePath(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetForceEvaluate(this DotNetBuildSettings toolSettings, bool? forceEvaluate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetForceEvaluate(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableForceEvaluate(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableForceEvaluate(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleForceEvaluate(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.Properties"/> to a new dictionary.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetProperties(this DotNetBuildSettings toolSettings, IDictionary<string, object> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ClearProperties(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings AddProperty(this DotNetBuildSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings RemoveProperty(this DotNetBuildSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetProperty(this DotNetBuildSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary><p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetRunCodeAnalysis(this DotNetBuildSettings toolSettings, bool? runCodeAnalysis)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ResetRunCodeAnalysis(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings EnableRunCodeAnalysis(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings DisableRunCodeAnalysis(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleRunCodeAnalysis(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary><p><em>Sets <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetNoWarns(this DotNetBuildSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetNoWarns(this DotNetBuildSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings AddNoWarns(this DotNetBuildSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings AddNoWarns(this DotNetBuildSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ClearNoWarns(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings RemoveNoWarns(this DotNetBuildSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings RemoveNoWarns(this DotNetBuildSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary><p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetWarningsAsErrors(this DotNetBuildSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetWarningsAsErrors(this DotNetBuildSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings AddWarningsAsErrors(this DotNetBuildSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings AddWarningsAsErrors(this DotNetBuildSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ClearWarningsAsErrors(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings RemoveWarningsAsErrors(this DotNetBuildSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings RemoveWarningsAsErrors(this DotNetBuildSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary><p><em>Sets <c>WarningLevel</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetWarningLevel(this DotNetBuildSettings toolSettings, int? warningLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>WarningLevel</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ResetWarningLevel(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary><p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetTreatWarningsAsErrors(this DotNetBuildSettings toolSettings, bool? treatWarningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ResetTreatWarningsAsErrors(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings EnableTreatWarningsAsErrors(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings DisableTreatWarningsAsErrors(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleTreatWarningsAsErrors(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary><p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetAssemblyVersion(this DotNetBuildSettings toolSettings, string assemblyVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ResetAssemblyVersion(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary><p><em>Sets <c>FileVersion</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetFileVersion(this DotNetBuildSettings toolSettings, string fileVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>FileVersion</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ResetFileVersion(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary><p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings SetInformationalVersion(this DotNetBuildSettings toolSettings, string informationalVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetBuildSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetBuildSettings ResetInformationalVersion(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetCleanSettingsExtensions
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetCleanSettingsExtensions
    {
        #region Project
        /// <summary><p><em>Sets <see cref="DotNetCleanSettings.Project"/>.</em></p><p>The MSBuild project to clean. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in <em>proj</em> and uses that file.</p></summary>
        [Pure]
        public static DotNetCleanSettings SetProject(this DotNetCleanSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetCleanSettings.Project"/>.</em></p><p>The MSBuild project to clean. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in <em>proj</em> and uses that file.</p></summary>
        [Pure]
        public static DotNetCleanSettings ResetProject(this DotNetCleanSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary><p><em>Sets <see cref="DotNetCleanSettings.Configuration"/>.</em></p><p>Defines the build configuration. The default value is <c>Debug</c>. This option is only required when cleaning if you specified it during build time.</p></summary>
        [Pure]
        public static DotNetCleanSettings SetConfiguration(this DotNetCleanSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetCleanSettings.Configuration"/>.</em></p><p>Defines the build configuration. The default value is <c>Debug</c>. This option is only required when cleaning if you specified it during build time.</p></summary>
        [Pure]
        public static DotNetCleanSettings ResetConfiguration(this DotNetCleanSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary><p><em>Sets <see cref="DotNetCleanSettings.Framework"/>.</em></p><p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a> that was specified at build time. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>. If you specified the framework at build time, you must specify the framework when cleaning.</p></summary>
        [Pure]
        public static DotNetCleanSettings SetFramework(this DotNetCleanSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetCleanSettings.Framework"/>.</em></p><p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a> that was specified at build time. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>. If you specified the framework at build time, you must specify the framework when cleaning.</p></summary>
        [Pure]
        public static DotNetCleanSettings ResetFramework(this DotNetCleanSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="DotNetCleanSettings.Output"/>.</em></p><p>Directory in which the build outputs are placed. Specify the <c>--framework</c> switch with the output directory switch if you specified the framework when the project was built.</p></summary>
        [Pure]
        public static DotNetCleanSettings SetOutput(this DotNetCleanSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetCleanSettings.Output"/>.</em></p><p>Directory in which the build outputs are placed. Specify the <c>--framework</c> switch with the output directory switch if you specified the framework when the project was built.</p></summary>
        [Pure]
        public static DotNetCleanSettings ResetOutput(this DotNetCleanSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary><p><em>Sets <see cref="DotNetCleanSettings.Runtime"/>.</em></p><p>Cleans the output folder of the specified runtime. This is used when a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment</a> was created.</p></summary>
        [Pure]
        public static DotNetCleanSettings SetRuntime(this DotNetCleanSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetCleanSettings.Runtime"/>.</em></p><p>Cleans the output folder of the specified runtime. This is used when a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment</a> was created.</p></summary>
        [Pure]
        public static DotNetCleanSettings ResetRuntime(this DotNetCleanSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary><p><em>Sets <see cref="DotNetCleanSettings.Verbosity"/>.</em></p><p>Sets the verbosity level of the command. Allowed levels are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].</p></summary>
        [Pure]
        public static DotNetCleanSettings SetVerbosity(this DotNetCleanSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetCleanSettings.Verbosity"/>.</em></p><p>Sets the verbosity level of the command. Allowed levels are q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].</p></summary>
        [Pure]
        public static DotNetCleanSettings ResetVerbosity(this DotNetCleanSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetPublishSettingsExtensions
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetPublishSettingsExtensions
    {
        #region Project
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Project"/>.</em></p><p>The project to publish, which defaults to the current directory if not specified.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetProject(this DotNetPublishSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.Project"/>.</em></p><p>The project to publish, which defaults to the current directory if not specified.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetProject(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Configuration"/>.</em></p><p>Defines the build configuration. The default value is <c>Debug</c>.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetConfiguration(this DotNetPublishSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.Configuration"/>.</em></p><p>Defines the build configuration. The default value is <c>Debug</c>.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetConfiguration(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Framework"/>.</em></p><p>Publishes the application for the specified <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. You must specify the target framework in the project file.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetFramework(this DotNetPublishSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.Framework"/>.</em></p><p>Publishes the application for the specified <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. You must specify the target framework in the project file.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetFramework(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Manifest
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Manifest"/>.</em></p><p>Specifies one or several <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/runtime-store">target manifests</a> to use to trim the set of packages published with the app. The manifest file is part of the output of the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-store"><c>dotnet store</c></a> command. To specify multiple manifests, add a <c>--manifest</c> option for each manifest. This option is available starting with .NET Core 2.0 SDK.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetManifest(this DotNetPublishSettings toolSettings, string manifest)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manifest = manifest;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.Manifest"/>.</em></p><p>Specifies one or several <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/runtime-store">target manifests</a> to use to trim the set of packages published with the app. The manifest file is part of the output of the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-store"><c>dotnet store</c></a> command. To specify multiple manifests, add a <c>--manifest</c> option for each manifest. This option is available starting with .NET Core 2.0 SDK.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetManifest(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manifest = null;
            return toolSettings;
        }
        #endregion
        #region NoRestore
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetNoRestore(this DotNetPublishSettings toolSettings, bool? noRestore)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = noRestore;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetNoRestore(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableNoRestore(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableNoRestore(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.NoRestore"/>.</em></p><p>Doesn't perform an implicit restore when running the command.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleNoRestore(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRestore = !toolSettings.NoRestore;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.NoBuild"/>.</em></p><p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetNoBuild(this DotNetPublishSettings toolSettings, bool? noBuild)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.NoBuild"/>.</em></p><p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetNoBuild(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.NoBuild"/>.</em></p><p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableNoBuild(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.NoBuild"/>.</em></p><p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableNoBuild(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.NoBuild"/>.</em></p><p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleNoBuild(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Output"/>.</em></p><p>Specifies the path for the output directory. If not specified, it defaults to <em>./bin/[configuration]/[framework]/</em> for a framework-dependent deployment or <em>./bin/[configuration]/[framework]/[runtime]</em> for a self-contained deployment.<para/>If a relative path is provided, the output directory generated is relative to the project file location, not to the current working directory.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetOutput(this DotNetPublishSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.Output"/>.</em></p><p>Specifies the path for the output directory. If not specified, it defaults to <em>./bin/[configuration]/[framework]/</em> for a framework-dependent deployment or <em>./bin/[configuration]/[framework]/[runtime]</em> for a self-contained deployment.<para/>If a relative path is provided, the output directory generated is relative to the project file location, not to the current working directory.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetOutput(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region SelfContained
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.SelfContained"/>.</em></p><p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetSelfContained(this DotNetPublishSettings toolSettings, bool? selfContained)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = selfContained;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.SelfContained"/>.</em></p><p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetSelfContained(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.SelfContained"/>.</em></p><p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableSelfContained(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.SelfContained"/>.</em></p><p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableSelfContained(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.SelfContained"/>.</em></p><p>Publishes the .NET Core runtime with your application so the runtime doesn't need to be installed on the target machine. If a runtime identifier is specified, its default value is <c>true</c>. For more information about the different deployment types, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core application deployment</a>.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleSelfContained(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = !toolSettings.SelfContained;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Runtime"/>.</em></p><p>Publishes the application for a given runtime. This is used when creating a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment (SCD)</a>. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Default is to publish a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#framework-dependent-deployments-fdd">framework-dependent deployment (FDD)</a>.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetRuntime(this DotNetPublishSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.Runtime"/>.</em></p><p>Publishes the application for a given runtime. This is used when creating a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#self-contained-deployments-scd">self-contained deployment (SCD)</a>. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Default is to publish a <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index#framework-dependent-deployments-fdd">framework-dependent deployment (FDD)</a>.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetRuntime(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Verbosity"/>.</em></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetVerbosity(this DotNetPublishSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.Verbosity"/>.</em></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetVerbosity(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region VersionSuffix
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.VersionSuffix"/>.</em></p><p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetVersionSuffix(this DotNetPublishSettings toolSettings, string versionSuffix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = versionSuffix;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.VersionSuffix"/>.</em></p><p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetVersionSuffix(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionSuffix = null;
            return toolSettings;
        }
        #endregion
        #region DisableParallel
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetDisableParallel(this DotNetPublishSettings toolSettings, bool? disableParallel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = disableParallel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetDisableParallel(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableDisableParallel(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableDisableParallel(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.DisableParallel"/>.</em></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleDisableParallel(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallel = !toolSettings.DisableParallel;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetForce(this DotNetPublishSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetForce(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableForce(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableForce(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.Force"/>.</em></p><p>Forces all dependencies to be resolved even if the last restore was successful. This is equivalent to deleting the <em>project.assets.json</em> file.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleForce(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region IgnoreFailedSources
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetIgnoreFailedSources(this DotNetPublishSettings toolSettings, bool? ignoreFailedSources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = ignoreFailedSources;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetIgnoreFailedSources(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableIgnoreFailedSources(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableIgnoreFailedSources(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.IgnoreFailedSources"/>.</em></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleIgnoreFailedSources(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreFailedSources = !toolSettings.IgnoreFailedSources;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetNoCache(this DotNetPublishSettings toolSettings, bool? noCache)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetNoCache(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableNoCache(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableNoCache(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.NoCache"/>.</em></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleNoCache(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NoDependencies
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetNoDependencies(this DotNetPublishSettings toolSettings, bool? noDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetNoDependencies(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableNoDependencies(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableNoDependencies(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.NoDependencies"/>.</em></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleNoDependencies(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
            return toolSettings;
        }
        #endregion
        #region PackageDirectory
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetPackageDirectory(this DotNetPublishSettings toolSettings, string packageDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = packageDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.PackageDirectory"/>.</em></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetPackageDirectory(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetSources(this DotNetPublishSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Sources"/> to a new list.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetSources(this DotNetPublishSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetPublishSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPublishSettings AddSources(this DotNetPublishSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetPublishSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPublishSettings AddSources(this DotNetPublishSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetPublishSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPublishSettings ClearSources(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetPublishSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPublishSettings RemoveSources(this DotNetPublishSettings toolSettings, params string[] sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetPublishSettings.Sources"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetPublishSettings RemoveSources(this DotNetPublishSettings toolSettings, IEnumerable<string> sources)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region UseLockFile
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetUseLockFile(this DotNetPublishSettings toolSettings, bool? useLockFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = useLockFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetUseLockFile(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableUseLockFile(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableUseLockFile(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.UseLockFile"/>.</em></p><p>Enables project lock file to be generated and used with restore.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleUseLockFile(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseLockFile = !toolSettings.UseLockFile;
            return toolSettings;
        }
        #endregion
        #region LockedMode
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetLockedMode(this DotNetPublishSettings toolSettings, bool? lockedMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = lockedMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetLockedMode(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableLockedMode(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableLockedMode(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.LockedMode"/>.</em></p><p>Don't allow updating project lock file.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleLockedMode(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockedMode = !toolSettings.LockedMode;
            return toolSettings;
        }
        #endregion
        #region LockFilePath
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetLockFilePath(this DotNetPublishSettings toolSettings, string lockFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = lockFilePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.LockFilePath"/>.</em></p><p>Output location where project lock file is written. By default, this is 'PROJECT_ROOT\packages.lock.json'.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetLockFilePath(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ForceEvaluate
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetPublishSettings SetForceEvaluate(this DotNetPublishSettings toolSettings, bool? forceEvaluate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = forceEvaluate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetPublishSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetPublishSettings ResetForceEvaluate(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetPublishSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetPublishSettings EnableForceEvaluate(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetPublishSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetPublishSettings DisableForceEvaluate(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetPublishSettings.ForceEvaluate"/>.</em></p><p>Forces restore to reevaluate all dependencies even if a lock file already exists.</p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleForceEvaluate(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEvaluate = !toolSettings.ForceEvaluate;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary><p><em>Sets <see cref="DotNetPublishSettings.Properties"/> to a new dictionary.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetProperties(this DotNetPublishSettings toolSettings, IDictionary<string, object> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ClearProperties(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings AddProperty(this DotNetPublishSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings RemoveProperty(this DotNetPublishSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetProperty(this DotNetPublishSettings toolSettings, string propertyKey, object propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region RunCodeAnalysis
        /// <summary><p><em>Sets <c>RunCodeAnalysis</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetRunCodeAnalysis(this DotNetPublishSettings toolSettings, bool? runCodeAnalysis)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>RunCodeAnalysis</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ResetRunCodeAnalysis(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>RunCodeAnalysis</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings EnableRunCodeAnalysis(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>RunCodeAnalysis</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings DisableRunCodeAnalysis(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleRunCodeAnalysis(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }
        #endregion
        #region NoWarn
        /// <summary><p><em>Sets <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetNoWarns(this DotNetPublishSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetNoWarns(this DotNetPublishSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings AddNoWarns(this DotNetPublishSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>NoWarn</c> in existing <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings AddNoWarns(this DotNetPublishSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ClearNoWarns(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings RemoveNoWarns(this DotNetPublishSettings toolSettings, params int[] noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>NoWarn</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings RemoveNoWarns(this DotNetPublishSettings toolSettings, IEnumerable<int> noWarn)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary><p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetWarningsAsErrors(this DotNetPublishSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Sets <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/> to a new collection.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetWarningsAsErrors(this DotNetPublishSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings AddWarningsAsErrors(this DotNetPublishSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings AddWarningsAsErrors(this DotNetPublishSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Clears <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ClearWarningsAsErrors(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings RemoveWarningsAsErrors(this DotNetPublishSettings toolSettings, params int[] warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings RemoveWarningsAsErrors(this DotNetPublishSettings toolSettings, IEnumerable<int> warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }
        #endregion
        #region WarningLevel
        /// <summary><p><em>Sets <c>WarningLevel</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetWarningLevel(this DotNetPublishSettings toolSettings, int? warningLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>WarningLevel</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ResetWarningLevel(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary><p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetTreatWarningsAsErrors(this DotNetPublishSettings toolSettings, bool? treatWarningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ResetTreatWarningsAsErrors(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }
        /// <summary><p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings EnableTreatWarningsAsErrors(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings DisableTreatWarningsAsErrors(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ToggleTreatWarningsAsErrors(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }
        #endregion
        #region AssemblyVersion
        /// <summary><p><em>Sets <c>AssemblyVersion</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetAssemblyVersion(this DotNetPublishSettings toolSettings, string assemblyVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>AssemblyVersion</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ResetAssemblyVersion(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }
        #endregion
        #region FileVersion
        /// <summary><p><em>Sets <c>FileVersion</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetFileVersion(this DotNetPublishSettings toolSettings, string fileVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>FileVersion</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ResetFileVersion(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }
        #endregion
        #region InformationalVersion
        /// <summary><p><em>Sets <c>InformationalVersion</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings SetInformationalVersion(this DotNetPublishSettings toolSettings, string informationalVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <c>InformationalVersion</c> in <see cref="DotNetPublishSettings.Properties"/>.</em></p><p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p></summary>
        [Pure]
        public static DotNetPublishSettings ResetInformationalVersion(this DotNetPublishSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }
        #endregion
        #endregion
    }
    #endregion
    #region DotNetNuGetPushSettingsExtensions
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetNuGetPushSettingsExtensions
    {
        #region TargetPath
        /// <summary><p><em>Sets <see cref="DotNetNuGetPushSettings.TargetPath"/>.</em></p><p>Path of the package to push.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings SetTargetPath(this DotNetNuGetPushSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetNuGetPushSettings.TargetPath"/>.</em></p><p>Path of the package to push.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ResetTargetPath(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary><p><em>Sets <see cref="DotNetNuGetPushSettings.Source"/>.</em></p><p>Specifies the server URL. This option is required unless <c>DefaultPushSource</c> config value is set in the NuGet config file.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings SetSource(this DotNetNuGetPushSettings toolSettings, string source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetNuGetPushSettings.Source"/>.</em></p><p>Specifies the server URL. This option is required unless <c>DefaultPushSource</c> config value is set in the NuGet config file.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ResetSource(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region SymbolSource
        /// <summary><p><em>Sets <see cref="DotNetNuGetPushSettings.SymbolSource"/>.</em></p><p>Specifies the symbol server URL.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings SetSymbolSource(this DotNetNuGetPushSettings toolSettings, string symbolSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSource = symbolSource;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetNuGetPushSettings.SymbolSource"/>.</em></p><p>Specifies the symbol server URL.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ResetSymbolSource(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSource = null;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary><p><em>Sets <see cref="DotNetNuGetPushSettings.Timeout"/>.</em></p><p>Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings SetTimeout(this DotNetNuGetPushSettings toolSettings, int? timeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetNuGetPushSettings.Timeout"/>.</em></p><p>Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ResetTimeout(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary><p><em>Sets <see cref="DotNetNuGetPushSettings.ApiKey"/>.</em></p><p>The API key for the server.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings SetApiKey(this DotNetNuGetPushSettings toolSettings, string apiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetNuGetPushSettings.ApiKey"/>.</em></p><p>The API key for the server.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ResetApiKey(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region SymbolApiKey
        /// <summary><p><em>Sets <see cref="DotNetNuGetPushSettings.SymbolApiKey"/>.</em></p><p>The API key for the symbol server.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings SetSymbolApiKey(this DotNetNuGetPushSettings toolSettings, string symbolApiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolApiKey = symbolApiKey;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetNuGetPushSettings.SymbolApiKey"/>.</em></p><p>The API key for the symbol server.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ResetSymbolApiKey(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolApiKey = null;
            return toolSettings;
        }
        #endregion
        #region DisableBuffering
        /// <summary><p><em>Sets <see cref="DotNetNuGetPushSettings.DisableBuffering"/>.</em></p><p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings SetDisableBuffering(this DotNetNuGetPushSettings toolSettings, bool? disableBuffering)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = disableBuffering;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetNuGetPushSettings.DisableBuffering"/>.</em></p><p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ResetDisableBuffering(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetNuGetPushSettings.DisableBuffering"/>.</em></p><p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings EnableDisableBuffering(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetNuGetPushSettings.DisableBuffering"/>.</em></p><p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings DisableDisableBuffering(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetNuGetPushSettings.DisableBuffering"/>.</em></p><p>Disables buffering when pushing to an HTTP(S) server to decrease memory usage.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ToggleDisableBuffering(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = !toolSettings.DisableBuffering;
            return toolSettings;
        }
        #endregion
        #region NoSymbols
        /// <summary><p><em>Sets <see cref="DotNetNuGetPushSettings.NoSymbols"/>.</em></p><p>Doesn't push symbols (even if present).</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings SetNoSymbols(this DotNetNuGetPushSettings toolSettings, bool? noSymbols)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = noSymbols;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetNuGetPushSettings.NoSymbols"/>.</em></p><p>Doesn't push symbols (even if present).</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ResetNoSymbols(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetNuGetPushSettings.NoSymbols"/>.</em></p><p>Doesn't push symbols (even if present).</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings EnableNoSymbols(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetNuGetPushSettings.NoSymbols"/>.</em></p><p>Doesn't push symbols (even if present).</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings DisableNoSymbols(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetNuGetPushSettings.NoSymbols"/>.</em></p><p>Doesn't push symbols (even if present).</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ToggleNoSymbols(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = !toolSettings.NoSymbols;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary><p><em>Sets <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/>.</em></p><p>Forces all logged output in English.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings SetForceEnglishOutput(this DotNetNuGetPushSettings toolSettings, bool? forceEnglishOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/>.</em></p><p>Forces all logged output in English.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ResetForceEnglishOutput(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/>.</em></p><p>Forces all logged output in English.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings EnableForceEnglishOutput(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/>.</em></p><p>Forces all logged output in English.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings DisableForceEnglishOutput(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetNuGetPushSettings.ForceEnglishOutput"/>.</em></p><p>Forces all logged output in English.</p></summary>
        [Pure]
        public static DotNetNuGetPushSettings ToggleForceEnglishOutput(this DotNetNuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetVerbosity
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<DotNetVerbosity>))]
    public partial class DotNetVerbosity : Enumeration
    {
        public static DotNetVerbosity Quiet = new DotNetVerbosity { Value = "Quiet" };
        public static DotNetVerbosity Minimal = new DotNetVerbosity { Value = "Minimal" };
        public static DotNetVerbosity Normal = new DotNetVerbosity { Value = "Normal" };
        public static DotNetVerbosity Detailed = new DotNetVerbosity { Value = "Detailed" };
        public static DotNetVerbosity Diagnostic = new DotNetVerbosity { Value = "Diagnostic" };
    }
    #endregion
}
