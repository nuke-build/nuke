// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated from https://github.com/nuke-build/tools/blob/master/DotNet.json with Nuke.ToolGenerator.

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

namespace Nuke.Common.Tools.DotNet
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetTasks
    {
        static partial void PreProcess (DotNetTestSettings toolSettings);
        static partial void PostProcess (DotNetTestSettings toolSettings);
        /// <summary><p>The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetTest (Configure<DotNetTestSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetTestSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (DotNetRunSettings toolSettings);
        static partial void PostProcess (DotNetRunSettings toolSettings);
        /// <summary><p>The <c>dotnet run</c> command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build"><c>dotnet build</c></a> command to build the code. Any requirements for the build, such as that the project must be restored first, apply to <c>dotnet run</c> as well.</p><p>Output files are written into the default location, which is <c>bin/&lt;configuration&gt;/&lt;target&gt;</c>. For example if you have a <c>netcoreapp1.0</c> application and you run <c>dotnet run</c>, the output is placed in <c>bin/Debug/netcoreapp1.0</c>. Files are overwritten as needed. Temporary files are placed in the <c>obj</c> directory.</p><p>If the project specifies multiple frameworks, executing <c>dotnet run</c> results in an error unless the <c>-f|--framework &lt;FRAMEWORK&gt;</c> option is used to specify the framework.</p><p>The <c>dotnet run</c> command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet">dotnet</a> without a command. For example, to run <c>myapp.dll</c>, use: <c>dotnet myapp.dll</c></p><p>For more information on the <c>dotnet</c> driver, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/index">.NET Core Command Line Tools (CLI)</a> topic.</p><p>In order to run the application, the <c>dotnet run</c> command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use <c>dotnet run</c> to run applications in production. Instead, <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">create a deployment</a> using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command and deploy the published output.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetRun (Configure<DotNetRunSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetRunSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (DotNetRestoreSettings toolSettings);
        static partial void PostProcess (DotNetRestoreSettings toolSettings);
        /// <summary><p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <em>NuGet.config</em> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <em>NuGet.config</em> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <em>/home/user1</em> on Linux or <em>C:\Users\user1</em> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <em>Nuget.Config</em> file, if present. For example, setting the <c>globalPackagesFolder</c> in <em>NuGet.Config</em> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetRestore (Configure<DotNetRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetRestoreSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <em>NuGet.config</em> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <em>NuGet.config</em> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <em>/home/user1</em> on Linux or <em>C:\Users\user1</em> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <em>Nuget.Config</em> file, if present. For example, setting the <c>globalPackagesFolder</c> in <em>NuGet.Config</em> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetRestore (string projectFile, Configure<DotNetRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotNetRestore(x => configurator(x).SetProjectFile(projectFile));
        }
        static partial void PreProcess (DotNetPackSettings toolSettings);
        static partial void PostProcess (DotNetPackSettings toolSettings);
        /// <summary><p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <em>.nuspec</em> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetPack (Configure<DotNetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetPackSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <em>.nuspec</em> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetPack (string project, Configure<DotNetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotNetPack(x => configurator(x).SetProject(project));
        }
        static partial void PreProcess (DotNetBuildSettings toolSettings);
        static partial void PostProcess (DotNetBuildSettings toolSettings);
        /// <summary><p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <em>.dll</em> extension and symbol files used for debugging with a <em>.pdb</em> extension. A dependencies JSON file (<em>.deps.json</em>) is produced that lists the dependencies of the application. A <em>.runtimeconfig.json</em> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <em>project.assets.json</em> file, which lists the dependencies of your application. The file is created when you execute <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> before building the project. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetBuild (Configure<DotNetBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new DotNetBuildSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <em>.dll</em> extension and symbol files used for debugging with a <em>.pdb</em> extension. A dependencies JSON file (<em>.deps.json</em>) is produced that lists the dependencies of the application. A <em>.runtimeconfig.json</em> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <em>project.assets.json</em> file, which lists the dependencies of your application. The file is created when you execute <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> before building the project. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p></summary>
        public static void DotNetBuild (string projectFile, Configure<DotNetBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotNetBuild(x => configurator(x).SetProjectFile(projectFile));
        }
    }
    #region DotNetTestSettings
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
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
        public virtual bool? ListTests { get; internal set; }
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
        public virtual bool? NoBuild { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
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
    #endregion
    #region DotNetRunSettings
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
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
    #endregion
    #region DotNetRestoreSettings
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetRestoreSettings : DotNetSettings
    {
        /// <summary><p>Optional path to the project file to restore.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        public virtual string Source { get; internal set; }
        /// <summary><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        public virtual IReadOnlyList<string> Runtimes => RuntimesInternal.AsReadOnly();
        internal List<string> RuntimesInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies the directory for restored packages.</p></summary>
        public virtual string PackageDirectory { get; internal set; }
        /// <summary><p>Disables restoring multiple projects in parallel.</p></summary>
        public virtual bool? DisableParallel { get; internal set; }
        /// <summary><p>Specifies to not cache packages and HTTP requests.</p></summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary><p>The NuGet configuration file (<em>NuGet.config</em>) to use for the restore operation.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p>Only warn about failed sources if there are packages meeting the version requirement.</p></summary>
        public virtual bool? IgnoreFailedSources { get; internal set; }
        /// <summary><p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p></summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
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
    #endregion
    #region DotNetPackSettings
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
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
        public virtual bool? NoBuild { get; internal set; }
        /// <summary><p>Generates the symbols <c>nupkg</c>.</p></summary>
        public virtual bool? IncludeSymbols { get; internal set; }
        /// <summary><p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p></summary>
        public virtual bool? IncludeSource { get; internal set; }
        /// <summary><p>Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project.</p></summary>
        public virtual string VersionSuffix { get; internal set; }
        /// <summary><p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p></summary>
        public virtual bool? Serviceable { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity Verbostiy { get; internal set; }
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
    #endregion
    #region DotNetBuildSettings
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
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
        public virtual bool? NoIncremental { get; internal set; }
        /// <summary><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        public virtual bool? NoDependencies { get; internal set; }
        /// <summary><p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p></summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
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
        #region Source
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.Source"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetSource(this DotNetRestoreSettings toolSettings, string source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetRestoreSettings.Source"/>.</em></p><p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <em>NuGet.config</em> file(s). Multiple sources can be provided by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ResetSource(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region Runtimes
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.Runtimes"/> to a new list.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetRuntimes(this DotNetRestoreSettings toolSettings, params string[] runtimes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RuntimesInternal = runtimes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DotNetRestoreSettings.Runtimes"/> to a new list.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings SetRuntimes(this DotNetRestoreSettings toolSettings, IEnumerable<string> runtimes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RuntimesInternal = runtimes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetRestoreSettings.Runtimes"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings AddRuntimes(this DotNetRestoreSettings toolSettings, params string[] runtimes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RuntimesInternal.AddRange(runtimes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DotNetRestoreSettings.Runtimes"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings AddRuntimes(this DotNetRestoreSettings toolSettings, IEnumerable<string> runtimes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RuntimesInternal.AddRange(runtimes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DotNetRestoreSettings.Runtimes"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings ClearRuntimes(this DotNetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RuntimesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetRestoreSettings.Runtimes"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings RemoveRuntimes(this DotNetRestoreSettings toolSettings, params string[] runtimes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(runtimes);
            toolSettings.RuntimesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DotNetRestoreSettings.Runtimes"/>.</em></p><p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <em>.csproj</em> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p></summary>
        [Pure]
        public static DotNetRestoreSettings RemoveRuntimes(this DotNetRestoreSettings toolSettings, IEnumerable<string> runtimes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(runtimes);
            toolSettings.RuntimesInternal.RemoveAll(x => hashSet.Contains(x));
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
        #region NoDependencies
        /// <summary><p><em>Sets <see cref="DotNetBuildSettings.NoDependencies"/>.</em></p><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        [Pure]
        public static DotNetBuildSettings SetNoDependencies(this DotNetBuildSettings toolSettings, bool? noDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = noDependencies;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DotNetBuildSettings.NoDependencies"/>.</em></p><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        [Pure]
        public static DotNetBuildSettings ResetNoDependencies(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DotNetBuildSettings.NoDependencies"/>.</em></p><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        [Pure]
        public static DotNetBuildSettings EnableNoDependencies(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DotNetBuildSettings.NoDependencies"/>.</em></p><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        [Pure]
        public static DotNetBuildSettings DisableNoDependencies(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DotNetBuildSettings.NoDependencies"/>.</em></p><p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p></summary>
        [Pure]
        public static DotNetBuildSettings ToggleNoDependencies(this DotNetBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDependencies = !toolSettings.NoDependencies;
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
    }
    #endregion
    #region DotNetVerbosity
    /// <summary><p>Used within <see cref="DotNetTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
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
