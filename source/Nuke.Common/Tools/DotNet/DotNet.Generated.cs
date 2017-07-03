using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

[assembly: IconClass(typeof(Nuke.Common.Tools.DotNet.DotNetTasks), "fire")]

namespace Nuke.Common.Tools.DotNet
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetTasks
    {
        static partial void PreProcess (DotNetTestSettings dotNetTestSettings);
        static partial void PostProcess (DotNetTestSettings dotNetTestSettings);
        /// <summary><p>The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetTest (Configure<DotNetTestSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dotNetTestSettings = new DotNetTestSettings();
            dotNetTestSettings = configurator(dotNetTestSettings);
            PreProcess(dotNetTestSettings);
            var process = ProcessTasks.StartProcess(dotNetTestSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dotNetTestSettings);
        }
        static partial void PreProcess (DotNetRunSettings dotNetRunSettings);
        static partial void PostProcess (DotNetRunSettings dotNetRunSettings);
        /// <summary><p>The <c>dotnet run</c> command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build"><c>dotnet build</c></a> command to build the code. Any requirements for the build, such as that the project must be restored first, apply to <c>dotnet run</c> as well.</p><p>Output files are written into the default location, which is <c>bin/&lt;configuration&gt;/&lt;target&gt;</c>. For example if you have a <c>netcoreapp1.0</c> application and you run <c>dotnet run</c>, the output is placed in <c>bin/Debug/netcoreapp1.0</c>. Files are overwritten as needed. Temporary files are placed in the <c>obj</c> directory.</p><p>If the project specifies multiple frameworks, executing <c>dotnet run</c> results in an error unless the <c>-f|--framework &lt;FRAMEWORK&gt;</c> option is used to specify the framework.</p><p>The <c>dotnet run</c> command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet">dotnet</a> without a command. For example, to run <c>myapp.dll</c>, use: <c>dotnet myapp.dll</c></p><p>For more information on the <c>dotnet</c> driver, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/index">.NET Core Command Line Tools (CLI)</a> topic.</p><p>In order to run the application, the <c>dotnet run</c> command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use <c>dotnet run</c> to run applications in production. Instead, <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">create a deployment</a> using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command and deploy the published output.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetRun (Configure<DotNetRunSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dotNetRunSettings = new DotNetRunSettings();
            dotNetRunSettings = configurator(dotNetRunSettings);
            PreProcess(dotNetRunSettings);
            var process = ProcessTasks.StartProcess(dotNetRunSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dotNetRunSettings);
        }
        static partial void PreProcess (DotNetRestoreSettings dotNetRestoreSettings);
        static partial void PostProcess (DotNetRestoreSettings dotNetRestoreSettings);
        /// <summary><p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <i>NuGet.config</i> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <i>NuGet.config</i> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <i>/home/user1</i> on Linux or <i>C:\Users\user1</i> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <i>Nuget.Config</i> file, if present. For example, setting the <c>globalPackagesFolder</c> in <i>NuGet.Config</i> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetRestore (Configure<DotNetRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dotNetRestoreSettings = new DotNetRestoreSettings();
            dotNetRestoreSettings = configurator(dotNetRestoreSettings);
            PreProcess(dotNetRestoreSettings);
            var process = ProcessTasks.StartProcess(dotNetRestoreSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dotNetRestoreSettings);
        }
        /// <summary><p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <i>NuGet.config</i> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <i>NuGet.config</i> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <i>/home/user1</i> on Linux or <i>C:\Users\user1</i> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <i>Nuget.Config</i> file, if present. For example, setting the <c>globalPackagesFolder</c> in <i>NuGet.Config</i> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetRestore (string projectFile, Configure<DotNetRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotNetRestore(x => configurator(x).SetProjectFile(projectFile));
        }
        static partial void PreProcess (DotNetPackSettings dotNetPackSettings);
        static partial void PostProcess (DotNetPackSettings dotNetPackSettings);
        /// <summary><p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <i>.nuspec</i> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetPack (Configure<DotNetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dotNetPackSettings = new DotNetPackSettings();
            dotNetPackSettings = configurator(dotNetPackSettings);
            PreProcess(dotNetPackSettings);
            var process = ProcessTasks.StartProcess(dotNetPackSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dotNetPackSettings);
        }
        /// <summary><p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <i>.nuspec</i> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetPack (string project, Configure<DotNetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotNetPack(x => configurator(x).SetProject(project));
        }
        static partial void PreProcess (DotNetBuildSettings dotNetBuildSettings);
        static partial void PostProcess (DotNetBuildSettings dotNetBuildSettings);
        /// <summary><p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <i>.dll</i> extension and symbol files used for debugging with a <i>.pdb</i> extension. A dependencies JSON file (<i>.deps.json</i>) is produced that lists the dependencies of the application. A <i>.runtimeconfig.json</i> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <i>project.assets.json</i> file, which lists the dependencies of your application. The file is created when you execute <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> before building the project. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetBuild (Configure<DotNetBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dotNetBuildSettings = new DotNetBuildSettings();
            dotNetBuildSettings = configurator(dotNetBuildSettings);
            PreProcess(dotNetBuildSettings);
            var process = ProcessTasks.StartProcess(dotNetBuildSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dotNetBuildSettings);
        }
        /// <summary><p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <i>.dll</i> extension and symbol files used for debugging with a <i>.pdb</i> extension. A dependencies JSON file (<i>.deps.json</i>) is produced that lists the dependencies of the application. A <i>.runtimeconfig.json</i> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <i>project.assets.json</i> file, which lists the dependencies of your application. The file is created when you execute <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> before building the project. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetBuild (string projectFile, Configure<DotNetBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotNetBuild(x => configurator(x).SetProjectFile(projectFile));
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetTestSettings : DotNetSettings
    {
        /// <summary><p>Specifies a path to the test project. If omitted, it defaults to current directory.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>Settings to use when running tests.</p></summary>
        public virtual string SettingsFile { get; internal set; }
        /// <summary><p>List all of the discovered tests in the current project.</p></summary>
        public virtual bool ListTests { get; internal set; }
        /// <summary><p>Filters out tests in the current project using the given expression. For more information, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests">Running selective unit tests</a>.</p></summary>
        public virtual string Filter { get; internal set; }
        /// <summary><p>Use the custom test adapters from the specified path in the test run.</p></summary>
        public virtual string TestAdapterPath { get; internal set; }
        /// <summary><p>Specifies a logger for test results.</p></summary>
        public virtual string Logger { get; internal set; }
        /// <summary><p>Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Looks for test binaries for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>.</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Directory in which to find the binaries to run.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.</p></summary>
        public virtual string DiagnosticsFile { get; internal set; }
        /// <summary><p>Does not build the test project prior to running it.</p></summary>
        public virtual bool NoBuild { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity? Verbosity { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("test")
              .Add("{value}", ProjectFile)
              .Add("--settings {value}", SettingsFile)
              .Add("--list-tests", ListTests)
              .Add("--filter {value}", Filter)
              .Add("--test-adapter-path {value}", TestAdapterPath)
              .Add("--logger {value}", Logger)
              .Add("--configuration {value}", Configuration)
              .Add("--framework {value}", Framework)
              .Add("--output {value}", Output)
              .Add("--diag {value}", DiagnosticsFile)
              .Add("--no-build", NoBuild)
              .Add("--verbosity {value}", Verbosity);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetRunSettings : DotNetSettings
    {
        /// <summary><p>Configuration to use for building the project. The default value is Debug.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Builds and runs the app using the specified framework. The framework must be specified in the project file.</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("run")
              .Add("--configuration {value}", Configuration)
              .Add("--framework {value}", Framework)
              .Add("--project {value}", ProjectFile);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetRestoreSettings : DotNetSettings
    {
        /// <summary><p>Optional path to the project file to restore.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <i>NuGet.config</i> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        public virtual string Source { get; internal set; }
        /// <summary><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        public virtual IReadOnlyList<string> Runtimes => RuntimesInternal.AsReadOnly();
        internal List<string> RuntimesInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies the directory for restored packages.</p></summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary><p>Disables restoring multiple projects in parallel.</p></summary>
        public virtual bool DisableParallel { get; internal set; }
        /// <summary><p>Specifies to not cache packages and HTTP requests.</p></summary>
        public virtual bool NoCache { get; internal set; }
        /// <summary><p>The NuGet configuration file (<i>NuGet.config</i>) to use for the restore operation.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        public virtual bool IgnoreFailedSources { get; internal set; }
        /// <summary><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        public virtual bool NoDependencies { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity? Verbosity { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("restore")
              .Add("{value}", ProjectFile)
              .Add("--source {value}", Source)
              .Add("--runtime {value}", Runtimes)
              .Add("--packages {value}", PackageDirectory)
              .Add("--disable-parallel", DisableParallel)
              .Add("--no-cache", NoCache)
              .Add("--configfile {value}", ConfigFile)
              .Add("--ignore-failed-sources", IgnoreFailedSources)
              .Add("--no-dependencies", NoDependencies)
              .Add("--verbosity {value}", Verbosity);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetPackSettings : DotNetSettings
    {
        /// <summary><p>The project to pack. It's either a path to a csproj file or to a directory. If omitted, it defaults to the current directory.</p></summary>
        public virtual string Project { get; internal set; }
        /// <summary><p>Places the built packages in the directory specified.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Don't build the project before packing.</p></summary>
        public virtual bool NoBuild { get; internal set; }
        /// <summary><p>Generates the symbols <c>nupkg</c>.</p></summary>
        public virtual bool IncludeSymbols { get; internal set; }
        /// <summary><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        public virtual bool IncludeSource { get; internal set; }
        /// <summary><p>Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project.</p></summary>
        public virtual string VersionSuffix { get; internal set; }
        /// <summary><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        public virtual bool Serviceable { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity? Verbostiy { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("pack")
              .Add("{value}", Project)
              .Add("--output {value}", OutputDirectory)
              .Add("--no-build", NoBuild)
              .Add("--include-symbols", IncludeSymbols)
              .Add("--include-source", IncludeSource)
              .Add("--configuration {value}", Configuration)
              .Add("--version-suffix {value}", VersionSuffix)
              .Add("--serviceable", Serviceable)
              .Add("--verbosity {value}", Verbostiy);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetBuildSettings : DotNetSettings
    {
        /// <summary><p>The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>Directory in which to place the built binaries. You also need to define <c>--framework</c> when you specify this option.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p></summary>
        public virtual string Runtime { get; internal set; }
        /// <summary><p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p></summary>
        public virtual string VersionSuffix { get; internal set; }
        /// <summary><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        public virtual bool NoIncremental { get; internal set; }
        /// <summary><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        public virtual bool NoDependencies { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity? Verbosity { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("build")
              .Add("{value}", ProjectFile)
              .Add("--output {value}", OutputDirectory)
              .Add("--framework {value}", Framework)
              .Add("--configuration {value}", Configuration)
              .Add("--runtime {value}", Runtime)
              .Add("--version-suffix {value}", VersionSuffix)
              .Add("--no-incremental", NoIncremental)
              .Add("--no-dependencies", NoDependencies)
              .Add("--verbosity {value}", Verbosity);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetTestSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.ProjectFile"/>.</i></p><p>Specifies a path to the test project. If omitted, it defaults to current directory.</p></summary>
        [Pure]
        public static DotNetTestSettings SetProjectFile(this DotNetTestSettings dotNetTestSettings, string projectFile)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.ProjectFile = projectFile;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.SettingsFile"/>.</i></p><p>Settings to use when running tests.</p></summary>
        [Pure]
        public static DotNetTestSettings SetSettingsFile(this DotNetTestSettings dotNetTestSettings, string settingsFile)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.SettingsFile = settingsFile;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.ListTests"/>.</i></p><p>List all of the discovered tests in the current project.</p></summary>
        [Pure]
        public static DotNetTestSettings SetListTests(this DotNetTestSettings dotNetTestSettings, bool listTests)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.ListTests = listTests;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetTestSettings.ListTests"/>.</i></p><p>List all of the discovered tests in the current project.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableListTests(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.ListTests = true;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetTestSettings.ListTests"/>.</i></p><p>List all of the discovered tests in the current project.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableListTests(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.ListTests = false;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetTestSettings.ListTests"/>.</i></p><p>List all of the discovered tests in the current project.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleListTests(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.ListTests = !dotNetTestSettings.ListTests;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.Filter"/>.</i></p><p>Filters out tests in the current project using the given expression. For more information, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests">Running selective unit tests</a>.</p></summary>
        [Pure]
        public static DotNetTestSettings SetFilter(this DotNetTestSettings dotNetTestSettings, string filter)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Filter = filter;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.TestAdapterPath"/>.</i></p><p>Use the custom test adapters from the specified path in the test run.</p></summary>
        [Pure]
        public static DotNetTestSettings SetTestAdapterPath(this DotNetTestSettings dotNetTestSettings, string testAdapterPath)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.TestAdapterPath = testAdapterPath;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.Logger"/>.</i></p><p>Specifies a logger for test results.</p></summary>
        [Pure]
        public static DotNetTestSettings SetLogger(this DotNetTestSettings dotNetTestSettings, string logger)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Logger = logger;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.Configuration"/>.</i></p><p>Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting.</p></summary>
        [Pure]
        public static DotNetTestSettings SetConfiguration(this DotNetTestSettings dotNetTestSettings, string configuration)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Configuration = configuration;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.Framework"/>.</i></p><p>Looks for test binaries for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>.</p></summary>
        [Pure]
        public static DotNetTestSettings SetFramework(this DotNetTestSettings dotNetTestSettings, string framework)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Framework = framework;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.Output"/>.</i></p><p>Directory in which to find the binaries to run.</p></summary>
        [Pure]
        public static DotNetTestSettings SetOutput(this DotNetTestSettings dotNetTestSettings, string output)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Output = output;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.DiagnosticsFile"/>.</i></p><p>Enables diagnostic mode for the test platform and write diagnostic messages to the specified file.</p></summary>
        [Pure]
        public static DotNetTestSettings SetDiagnosticsFile(this DotNetTestSettings dotNetTestSettings, string diagnosticsFile)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.DiagnosticsFile = diagnosticsFile;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.NoBuild"/>.</i></p><p>Does not build the test project prior to running it.</p></summary>
        [Pure]
        public static DotNetTestSettings SetNoBuild(this DotNetTestSettings dotNetTestSettings, bool noBuild)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.NoBuild = noBuild;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetTestSettings.NoBuild"/>.</i></p><p>Does not build the test project prior to running it.</p></summary>
        [Pure]
        public static DotNetTestSettings EnableNoBuild(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.NoBuild = true;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetTestSettings.NoBuild"/>.</i></p><p>Does not build the test project prior to running it.</p></summary>
        [Pure]
        public static DotNetTestSettings DisableNoBuild(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.NoBuild = false;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetTestSettings.NoBuild"/>.</i></p><p>Does not build the test project prior to running it.</p></summary>
        [Pure]
        public static DotNetTestSettings ToggleNoBuild(this DotNetTestSettings dotNetTestSettings)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.NoBuild = !dotNetTestSettings.NoBuild;
            return dotNetTestSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetTestSettings.Verbosity"/>.</i></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetTestSettings SetVerbosity(this DotNetTestSettings dotNetTestSettings, DotNetVerbosity? verbosity)
        {
            dotNetTestSettings = dotNetTestSettings.NewInstance();
            dotNetTestSettings.Verbosity = verbosity;
            return dotNetTestSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetRunSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="DotNetRunSettings.Configuration"/>.</i></p><p>Configuration to use for building the project. The default value is Debug.</p></summary>
        [Pure]
        public static DotNetRunSettings SetConfiguration(this DotNetRunSettings dotNetRunSettings, string configuration)
        {
            dotNetRunSettings = dotNetRunSettings.NewInstance();
            dotNetRunSettings.Configuration = configuration;
            return dotNetRunSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRunSettings.Framework"/>.</i></p><p>Builds and runs the app using the specified framework. The framework must be specified in the project file.</p></summary>
        [Pure]
        public static DotNetRunSettings SetFramework(this DotNetRunSettings dotNetRunSettings, string framework)
        {
            dotNetRunSettings = dotNetRunSettings.NewInstance();
            dotNetRunSettings.Framework = framework;
            return dotNetRunSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRunSettings.ProjectFile"/>.</i></p><p>Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.</p></summary>
        [Pure]
        public static DotNetRunSettings SetProjectFile(this DotNetRunSettings dotNetRunSettings, string projectFile)
        {
            dotNetRunSettings = dotNetRunSettings.NewInstance();
            dotNetRunSettings.ProjectFile = projectFile;
            return dotNetRunSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetRestoreSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.ProjectFile"/>.</i></p><p>Optional path to the project file to restore.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetProjectFile(this DotNetRestoreSettings dotNetRestoreSettings, string projectFile)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.ProjectFile = projectFile;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.Source"/>.</i></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <i>NuGet.config</i> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetSource(this DotNetRestoreSettings dotNetRestoreSettings, string source)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.Source = source;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.Runtimes"/> to a new list.</i></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetRuntimes(this DotNetRestoreSettings dotNetRestoreSettings, params string[] runtimes)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal = runtimes.ToList();
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.Runtimes"/> to a new list.</i></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetRuntimes(this DotNetRestoreSettings dotNetRestoreSettings, IEnumerable<string> runtimes)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal = runtimes.ToList();
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding new runtimes to the existing <see cref="DotNetRestoreSettings.Runtimes"/>.</i></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings AddRuntimes(this DotNetRestoreSettings dotNetRestoreSettings, params string[] runtimes)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal.AddRange(runtimes);
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding new runtimes to the existing <see cref="DotNetRestoreSettings.Runtimes"/>.</i></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings AddRuntimes(this DotNetRestoreSettings dotNetRestoreSettings, IEnumerable<string> runtimes)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal.AddRange(runtimes);
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DotNetRestoreSettings.Runtimes"/>.</i></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ClearRuntimes(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal.Clear();
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding a single runtime to <see cref="DotNetRestoreSettings.Runtimes"/>.</i></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings AddRuntime(this DotNetRestoreSettings dotNetRestoreSettings, string runtime)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal.Add(runtime);
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for removing a single runtime from <see cref="DotNetRestoreSettings.Runtimes"/>.</i></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings RemoveRuntime(this DotNetRestoreSettings dotNetRestoreSettings, string runtime)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal.Remove(runtime);
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.PackageDirectory"/>.</i></p><p>Specifies the directory for restored packages.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetPackageDirectory(this DotNetRestoreSettings dotNetRestoreSettings, string packageDirectory)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.PackageDirectory = packageDirectory;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.DisableParallel"/>.</i></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetDisableParallel(this DotNetRestoreSettings dotNetRestoreSettings, bool disableParallel)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.DisableParallel = disableParallel;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetRestoreSettings.DisableParallel"/>.</i></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableDisableParallel(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.DisableParallel = true;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetRestoreSettings.DisableParallel"/>.</i></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableDisableParallel(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.DisableParallel = false;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetRestoreSettings.DisableParallel"/>.</i></p><p>Disables restoring multiple projects in parallel.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleDisableParallel(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.DisableParallel = !dotNetRestoreSettings.DisableParallel;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.NoCache"/>.</i></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetNoCache(this DotNetRestoreSettings dotNetRestoreSettings, bool noCache)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoCache = noCache;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetRestoreSettings.NoCache"/>.</i></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableNoCache(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoCache = true;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetRestoreSettings.NoCache"/>.</i></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableNoCache(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoCache = false;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetRestoreSettings.NoCache"/>.</i></p><p>Specifies to not cache packages and HTTP requests.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleNoCache(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoCache = !dotNetRestoreSettings.NoCache;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.ConfigFile"/>.</i></p><p>The NuGet configuration file (<i>NuGet.config</i>) to use for the restore operation.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetConfigFile(this DotNetRestoreSettings dotNetRestoreSettings, string configFile)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.ConfigFile = configFile;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</i></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetIgnoreFailedSources(this DotNetRestoreSettings dotNetRestoreSettings, bool ignoreFailedSources)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.IgnoreFailedSources = ignoreFailedSources;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</i></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableIgnoreFailedSources(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.IgnoreFailedSources = true;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</i></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableIgnoreFailedSources(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.IgnoreFailedSources = false;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</i></p><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleIgnoreFailedSources(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.IgnoreFailedSources = !dotNetRestoreSettings.IgnoreFailedSources;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.NoDependencies"/>.</i></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetNoDependencies(this DotNetRestoreSettings dotNetRestoreSettings, bool noDependencies)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoDependencies = noDependencies;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetRestoreSettings.NoDependencies"/>.</i></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRestoreSettings EnableNoDependencies(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoDependencies = true;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetRestoreSettings.NoDependencies"/>.</i></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRestoreSettings DisableNoDependencies(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoDependencies = false;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetRestoreSettings.NoDependencies"/>.</i></p><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ToggleNoDependencies(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoDependencies = !dotNetRestoreSettings.NoDependencies;
            return dotNetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetRestoreSettings.Verbosity"/>.</i></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetVerbosity(this DotNetRestoreSettings dotNetRestoreSettings, DotNetVerbosity? verbosity)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.Verbosity = verbosity;
            return dotNetRestoreSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetPackSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="DotNetPackSettings.Project"/>.</i></p><p>The project to pack. It's either a path to a csproj file or to a directory. If omitted, it defaults to the current directory.</p></summary>
        [Pure]
        public static DotNetPackSettings SetProject(this DotNetPackSettings dotNetPackSettings, string project)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Project = project;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetPackSettings.OutputDirectory"/>.</i></p><p>Places the built packages in the directory specified.</p></summary>
        [Pure]
        public static DotNetPackSettings SetOutputDirectory(this DotNetPackSettings dotNetPackSettings, string outputDirectory)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.OutputDirectory = outputDirectory;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetPackSettings.NoBuild"/>.</i></p><p>Don't build the project before packing.</p></summary>
        [Pure]
        public static DotNetPackSettings SetNoBuild(this DotNetPackSettings dotNetPackSettings, bool noBuild)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.NoBuild = noBuild;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetPackSettings.NoBuild"/>.</i></p><p>Don't build the project before packing.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableNoBuild(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.NoBuild = true;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetPackSettings.NoBuild"/>.</i></p><p>Don't build the project before packing.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableNoBuild(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.NoBuild = false;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetPackSettings.NoBuild"/>.</i></p><p>Don't build the project before packing.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleNoBuild(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.NoBuild = !dotNetPackSettings.NoBuild;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetPackSettings.IncludeSymbols"/>.</i></p><p>Generates the symbols <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings SetIncludeSymbols(this DotNetPackSettings dotNetPackSettings, bool includeSymbols)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSymbols = includeSymbols;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetPackSettings.IncludeSymbols"/>.</i></p><p>Generates the symbols <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableIncludeSymbols(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSymbols = true;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetPackSettings.IncludeSymbols"/>.</i></p><p>Generates the symbols <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableIncludeSymbols(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSymbols = false;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetPackSettings.IncludeSymbols"/>.</i></p><p>Generates the symbols <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleIncludeSymbols(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSymbols = !dotNetPackSettings.IncludeSymbols;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetPackSettings.IncludeSource"/>.</i></p><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings SetIncludeSource(this DotNetPackSettings dotNetPackSettings, bool includeSource)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSource = includeSource;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetPackSettings.IncludeSource"/>.</i></p><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableIncludeSource(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSource = true;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetPackSettings.IncludeSource"/>.</i></p><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableIncludeSource(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSource = false;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetPackSettings.IncludeSource"/>.</i></p><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleIncludeSource(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSource = !dotNetPackSettings.IncludeSource;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetPackSettings.Configuration"/>.</i></p><p>Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings SetConfiguration(this DotNetPackSettings dotNetPackSettings, string configuration)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Configuration = configuration;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetPackSettings.VersionSuffix"/>.</i></p><p>Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project.</p></summary>
        [Pure]
        public static DotNetPackSettings SetVersionSuffix(this DotNetPackSettings dotNetPackSettings, string versionSuffix)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.VersionSuffix = versionSuffix;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetPackSettings.Serviceable"/>.</i></p><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        [Pure]
        public static DotNetPackSettings SetServiceable(this DotNetPackSettings dotNetPackSettings, bool serviceable)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Serviceable = serviceable;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetPackSettings.Serviceable"/>.</i></p><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        [Pure]
        public static DotNetPackSettings EnableServiceable(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Serviceable = true;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetPackSettings.Serviceable"/>.</i></p><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        [Pure]
        public static DotNetPackSettings DisableServiceable(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Serviceable = false;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetPackSettings.Serviceable"/>.</i></p><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        [Pure]
        public static DotNetPackSettings ToggleServiceable(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Serviceable = !dotNetPackSettings.Serviceable;
            return dotNetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetPackSettings.Verbostiy"/>.</i></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetPackSettings SetVerbostiy(this DotNetPackSettings dotNetPackSettings, DotNetVerbosity? verbostiy)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Verbostiy = verbostiy;
            return dotNetPackSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetBuildSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="DotNetBuildSettings.ProjectFile"/>.</i></p><p>The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetProjectFile(this DotNetBuildSettings dotNetBuildSettings, string projectFile)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.ProjectFile = projectFile;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetBuildSettings.OutputDirectory"/>.</i></p><p>Directory in which to place the built binaries. You also need to define <c>--framework</c> when you specify this option.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetOutputDirectory(this DotNetBuildSettings dotNetBuildSettings, string outputDirectory)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.OutputDirectory = outputDirectory;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetBuildSettings.Framework"/>.</i></p><p>Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetFramework(this DotNetBuildSettings dotNetBuildSettings, string framework)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.Framework = framework;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetBuildSettings.Configuration"/>.</i></p><p>Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetConfiguration(this DotNetBuildSettings dotNetBuildSettings, string configuration)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.Configuration = configuration;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetBuildSettings.Runtime"/>.</i></p><p>Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetRuntime(this DotNetBuildSettings dotNetBuildSettings, string runtime)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.Runtime = runtime;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetBuildSettings.VersionSuffix"/>.</i></p><p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetVersionSuffix(this DotNetBuildSettings dotNetBuildSettings, string versionSuffix)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.VersionSuffix = versionSuffix;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetBuildSettings.NoIncremental"/>.</i></p><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetNoIncremental(this DotNetBuildSettings dotNetBuildSettings, bool noIncremental)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoIncremental = noIncremental;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetBuildSettings.NoIncremental"/>.</i></p><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableNoIncremental(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoIncremental = true;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetBuildSettings.NoIncremental"/>.</i></p><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableNoIncremental(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoIncremental = false;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetBuildSettings.NoIncremental"/>.</i></p><p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleNoIncremental(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoIncremental = !dotNetBuildSettings.NoIncremental;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetBuildSettings.NoDependencies"/>.</i></p><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetNoDependencies(this DotNetBuildSettings dotNetBuildSettings, bool noDependencies)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoDependencies = noDependencies;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DotNetBuildSettings.NoDependencies"/>.</i></p><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableNoDependencies(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoDependencies = true;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DotNetBuildSettings.NoDependencies"/>.</i></p><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableNoDependencies(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoDependencies = false;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DotNetBuildSettings.NoDependencies"/>.</i></p><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleNoDependencies(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoDependencies = !dotNetBuildSettings.NoDependencies;
            return dotNetBuildSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DotNetBuildSettings.Verbosity"/>.</i></p><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetVerbosity(this DotNetBuildSettings dotNetBuildSettings, DotNetVerbosity? verbosity)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.Verbosity = verbosity;
            return dotNetBuildSettings;
        }
    }
    [PublicAPI]
    public enum DotNetVerbosity
    {
        Quiet,
        Minimal,
        Normal,
        Detailed,
        Diagnostic
    }
}
