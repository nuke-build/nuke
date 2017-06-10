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
    public static partial class DotNetTasks
    {
        static partial void PreProcess (DotNetBuildSettings dotNetBuildSettings);
        static partial void PostProcess (DotNetBuildSettings dotNetBuildSettings);
        /// <summary>
        /// <p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <i>.dll</i> extension and symbol files used for debugging with a <i>.pdb</i> extension. A dependencies JSON file (<i>.deps.json</i>) is produced that lists the dependencies of the application. A <i>.runtimeconfig.json</i> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <i>project.assets.json</i> file, which lists the dependencies of your application. The file is created when you execute <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> before building the project. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build">official website</a>.</p>
        /// </summary>
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
        /// <summary>
        /// <p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <i>.dll</i> extension and symbol files used for debugging with a <i>.pdb</i> extension. A dependencies JSON file (<i>.deps.json</i>) is produced that lists the dependencies of the application. A <i>.runtimeconfig.json</i> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <i>project.assets.json</i> file, which lists the dependencies of your application. The file is created when you execute <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> before building the project. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build">official website</a>.</p>
        /// </summary>
        public static void DotNetBuild (string projectFile, Configure<DotNetBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotNetBuild(x => configurator(x).SetProjectFile(projectFile));
        }
    }
    /// <summary>
    /// <p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <i>.dll</i> extension and symbol files used for debugging with a <i>.pdb</i> extension. A dependencies JSON file (<i>.deps.json</i>) is produced that lists the dependencies of the application. A <i>.runtimeconfig.json</i> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">.NET Core Application Deployment</a>.</p><p>Building requires the <i>project.assets.json</i> file, which lists the dependencies of your application. The file is created when you execute <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore"><c>dotnet restore</c></a> before building the project. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href="https://docs.microsoft.com/visualstudio/msbuild/incremental-builds">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href="https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build">official website</a>.</p>
    /// </summary>
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
              .Add($"build")
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
    public static partial class DotNetBuildSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetBuildSettings.ProjectFile"/>.</i></p>
        /// <p>The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings SetProjectFile(this DotNetBuildSettings dotNetBuildSettings, string projectFile)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.ProjectFile = projectFile;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetBuildSettings.OutputDirectory"/>.</i></p>
        /// <p>Directory in which to place the built binaries. You also need to define <c>--framework</c> when you specify this option.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings SetOutputDirectory(this DotNetBuildSettings dotNetBuildSettings, string outputDirectory)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.OutputDirectory = outputDirectory;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetBuildSettings.Framework"/>.</i></p>
        /// <p>Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings SetFramework(this DotNetBuildSettings dotNetBuildSettings, string framework)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.Framework = framework;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetBuildSettings.Configuration"/>.</i></p>
        /// <p>Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings SetConfiguration(this DotNetBuildSettings dotNetBuildSettings, string configuration)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.Configuration = configuration;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetBuildSettings.Runtime"/>.</i></p>
        /// <p>Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings SetRuntime(this DotNetBuildSettings dotNetBuildSettings, string runtime)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.Runtime = runtime;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetBuildSettings.VersionSuffix"/>.</i></p>
        /// <p>Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings SetVersionSuffix(this DotNetBuildSettings dotNetBuildSettings, string versionSuffix)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.VersionSuffix = versionSuffix;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetBuildSettings.NoIncremental"/>.</i></p>
        /// <p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings SetNoIncremental(this DotNetBuildSettings dotNetBuildSettings, bool noIncremental)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoIncremental = noIncremental;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetBuildSettings.NoIncremental"/>.</i></p>
        /// <p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings EnableNoIncremental(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoIncremental = true;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetBuildSettings.NoIncremental"/>.</i></p>
        /// <p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings DisableNoIncremental(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoIncremental = false;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetBuildSettings.NoIncremental"/>.</i></p>
        /// <p>Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings ToggleNoIncremental(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoIncremental = !dotNetBuildSettings.NoIncremental;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetBuildSettings.NoDependencies"/>.</i></p>
        /// <p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings SetNoDependencies(this DotNetBuildSettings dotNetBuildSettings, bool noDependencies)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoDependencies = noDependencies;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetBuildSettings.NoDependencies"/>.</i></p>
        /// <p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings EnableNoDependencies(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoDependencies = true;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetBuildSettings.NoDependencies"/>.</i></p>
        /// <p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings DisableNoDependencies(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoDependencies = false;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetBuildSettings.NoDependencies"/>.</i></p>
        /// <p>Ignores project-to-project (P2P) references and only builds the root project specified to build.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings ToggleNoDependencies(this DotNetBuildSettings dotNetBuildSettings)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.NoDependencies = !dotNetBuildSettings.NoDependencies;
            return dotNetBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetBuildSettings.Verbosity"/>.</i></p>
        /// <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetBuildSettings SetVerbosity(this DotNetBuildSettings dotNetBuildSettings, DotNetVerbosity? verbosity)
        {
            dotNetBuildSettings = dotNetBuildSettings.NewInstance();
            dotNetBuildSettings.Verbosity = verbosity;
            return dotNetBuildSettings;
        }
    }
}
