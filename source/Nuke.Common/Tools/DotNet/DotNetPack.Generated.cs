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
        static partial void PreProcess (DotNetPackSettings dotNetPackSettings);
        static partial void PostProcess (DotNetPackSettings dotNetPackSettings);
        /// <summary>
        /// <p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <i>.nuspec</i> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-pack">official website</a>.</p>
        /// </summary>
        public static void DotNetPack (Configure<DotNetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dotNetPackSettings = new DotNetPackSettings();
            dotNetPackSettings = configurator(dotNetPackSettings);
            PreProcess(dotNetPackSettings);
            var process = ProcessManager.Instance.StartProcess(dotNetPackSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dotNetPackSettings);
        }
        /// <summary>
        /// <p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <i>.nuspec</i> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-pack">official website</a>.</p>
        /// </summary>
        public static void DotNetPack (string project, Configure<DotNetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotNetPack(x => configurator(x).SetProject(project));
        }
    }
    /// <summary>
    /// <p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <i>.nuspec</i> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties">NuGet metadata properties</a> and the <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference">MSBuild Command-Line Reference</a>.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-pack">official website</a>.</p>
    /// </summary>
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
        public virtual DotNetVerbosity Verbostiy { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add($"pack")
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
    public static partial class DotNetPackSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetPackSettings.Project"/>.</i></p>
        /// <p>The project to pack. It's either a path to a csproj file or to a directory. If omitted, it defaults to the current directory.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings SetProject(this DotNetPackSettings dotNetPackSettings, string project)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Project = project;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetPackSettings.OutputDirectory"/>.</i></p>
        /// <p>Places the built packages in the directory specified.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings SetOutputDirectory(this DotNetPackSettings dotNetPackSettings, string outputDirectory)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.OutputDirectory = outputDirectory;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetPackSettings.NoBuild"/>.</i></p>
        /// <p>Don't build the project before packing.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings SetNoBuild(this DotNetPackSettings dotNetPackSettings, bool noBuild)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.NoBuild = noBuild;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetPackSettings.NoBuild"/>.</i></p>
        /// <p>Don't build the project before packing.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings EnableNoBuild(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.NoBuild = true;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetPackSettings.NoBuild"/>.</i></p>
        /// <p>Don't build the project before packing.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings DisableNoBuild(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.NoBuild = false;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetPackSettings.NoBuild"/>.</i></p>
        /// <p>Don't build the project before packing.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings ToggleNoBuild(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.NoBuild = !dotNetPackSettings.NoBuild;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetPackSettings.IncludeSymbols"/>.</i></p>
        /// <p>Generates the symbols <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings SetIncludeSymbols(this DotNetPackSettings dotNetPackSettings, bool includeSymbols)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSymbols = includeSymbols;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetPackSettings.IncludeSymbols"/>.</i></p>
        /// <p>Generates the symbols <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings EnableIncludeSymbols(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSymbols = true;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetPackSettings.IncludeSymbols"/>.</i></p>
        /// <p>Generates the symbols <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings DisableIncludeSymbols(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSymbols = false;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetPackSettings.IncludeSymbols"/>.</i></p>
        /// <p>Generates the symbols <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings ToggleIncludeSymbols(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSymbols = !dotNetPackSettings.IncludeSymbols;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetPackSettings.IncludeSource"/>.</i></p>
        /// <p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings SetIncludeSource(this DotNetPackSettings dotNetPackSettings, bool includeSource)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSource = includeSource;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetPackSettings.IncludeSource"/>.</i></p>
        /// <p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings EnableIncludeSource(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSource = true;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetPackSettings.IncludeSource"/>.</i></p>
        /// <p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings DisableIncludeSource(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSource = false;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetPackSettings.IncludeSource"/>.</i></p>
        /// <p>Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings ToggleIncludeSource(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.IncludeSource = !dotNetPackSettings.IncludeSource;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetPackSettings.Configuration"/>.</i></p>
        /// <p>Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings SetConfiguration(this DotNetPackSettings dotNetPackSettings, string configuration)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Configuration = configuration;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetPackSettings.VersionSuffix"/>.</i></p>
        /// <p>Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings SetVersionSuffix(this DotNetPackSettings dotNetPackSettings, string versionSuffix)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.VersionSuffix = versionSuffix;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetPackSettings.Serviceable"/>.</i></p>
        /// <p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings SetServiceable(this DotNetPackSettings dotNetPackSettings, bool serviceable)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Serviceable = serviceable;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetPackSettings.Serviceable"/>.</i></p>
        /// <p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings EnableServiceable(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Serviceable = true;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetPackSettings.Serviceable"/>.</i></p>
        /// <p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings DisableServiceable(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Serviceable = false;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetPackSettings.Serviceable"/>.</i></p>
        /// <p>Sets the serviceable flag in the package. For more information, see <a href="https://aka.ms/nupkgservicing">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings ToggleServiceable(this DotNetPackSettings dotNetPackSettings)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Serviceable = !dotNetPackSettings.Serviceable;
            return dotNetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetPackSettings.Verbostiy"/>.</i></p>
        /// <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetPackSettings SetVerbostiy(this DotNetPackSettings dotNetPackSettings, DotNetVerbosity verbostiy)
        {
            dotNetPackSettings = dotNetPackSettings.NewInstance();
            dotNetPackSettings.Verbostiy = verbostiy;
            return dotNetPackSettings;
        }
    }
}
