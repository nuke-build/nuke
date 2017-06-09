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

[assembly: IconClass(typeof(Nuke.Common.Tools.NuGet.NuGetTasks), "box")]
namespace Nuke.Common.Tools.NuGet
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetTasks
    {
        static partial void PreProcess (NuGetPackSettings nuGetPackSettings);
        static partial void PostProcess (NuGetPackSettings nuGetPackSettings);
        /// <summary>
        /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        public static void NuGetPack (Configure<NuGetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var nuGetPackSettings = new NuGetPackSettings();
            nuGetPackSettings = configurator(nuGetPackSettings);
            PreProcess(nuGetPackSettings);
            var process = ProcessManager.Instance.StartProcess(nuGetPackSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(nuGetPackSettings);
        }
        /// <summary>
        /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        public static void NuGetPack (string targetPath, Configure<NuGetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            NuGetPack(x => configurator(x).SetTargetPath(targetPath));
        }
        /// <summary>
        /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        public static void NuGetPack (string targetPath, string version, Configure<NuGetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            NuGetPack(targetPath, x => configurator(x).SetVersion(version));
        }
    }
    /// <summary>
    /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetPackSettings : NuGetSettings
    {
        /// <summary><p>The <c>.nuspec</c> or <c>.csproj</c> file.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>Sets the base path of the files defined in the <c>.nuspec</c> file.</p></summary>
        public virtual string BasePath { get; internal set; }
        /// <summary><p>Specifies that the project should be built before building the package.</p></summary>
        public virtual bool Build { get; internal set; }
        /// <summary><p>Specifies one or more wildcard patterns to exclude when creating a package.</p></summary>
        public virtual string Exclude { get; internal set; }
        /// <summary><p>Prevent inclusion of empty directories when building the package.</p></summary>
        public virtual bool ExcludeEmptyDirectories { get; internal set; }
        /// <summary><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        public virtual bool IncludeReferencedProjects { get; internal set; }
        /// <summary><p>Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        public virtual bool MinClientVersion { get; internal set; }
        /// <summary><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        public virtual bool ForceEnglishOutput { get; internal set; }
        /// <summary><p><i>(4.0+)</i> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        public virtual string MSBuildPath { get; internal set; }
        /// <summary><p><i>(3.2+)</i> Specifies the version of MSBuild to be used with this command. Supported values are <i>4</i>, <i>12</i>, <i>14</i>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        public virtual Nuke.Common.Tools.MSBuild.MSBuildVersion? MSBuildVersion { get; internal set; }
        /// <summary><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>.</p></summary>
        public virtual bool NoDefaultExcludes { get; internal set; }
        /// <summary><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        public virtual bool NoPackageAnalysis { get; internal set; }
        /// <summary><p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p><i>(3.4.4+)</i> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p></summary>
        public virtual string Suffix { get; internal set; }
        /// <summary><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        public virtual bool Symbols { get; internal set; }
        /// <summary><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        public virtual bool Tool { get; internal set; }
        /// <summary><p><i>(2.5+)</i> Specifies the amount of details displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p></summary>
        public virtual NuGetVerbosity? Verbosity { get; internal set; }
        /// <summary><p>Overrides the version number from the <c>.nuspec</c> file.</p></summary>
        public virtual string Version { get; internal set; }
        public virtual string Configuration { get; internal set; }
        /// <inheritdoc />
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), $"File.Exists(TargetPath)");
            ControlFlow.Assert(Directory.Exists(BasePath), $"Directory.Exists(BasePath)");
        }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add($"pack")
              .Add("{value}", TargetPath)
              .Add("-BasePath {value}", BasePath)
              .Add("-Build", Build)
              .Add("-Exclude {value}", Exclude)
              .Add("-ExcludeEmptyDirectories", ExcludeEmptyDirectories)
              .Add("-IncludeReferencedProjects", IncludeReferencedProjects)
              .Add("-MinClientVersion", MinClientVersion)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-MSBuildPath {value}", MSBuildPath)
              .Add("-MSBuildVersion {value}", GetMSBuildVersion())
              .Add("-NoDefaultExcludes", NoDefaultExcludes)
              .Add("-NoPackageAnalysis", NoPackageAnalysis)
              .Add("-OutputDirectory {value}", OutputDirectory)
              .Add("-Properties {value}", GetProperties())
              .Add("-Suffix {value}", Suffix)
              .Add("-Symbols", Symbols)
              .Add("-Tool", Tool)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-Version {value}", Version);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetPackSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.TargetPath"/>.</i></p>
        /// <p>The <c>.nuspec</c> or <c>.csproj</c> file.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetTargetPath(this NuGetPackSettings nuGetPackSettings, string targetPath)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.TargetPath = targetPath;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.BasePath"/>.</i></p>
        /// <p>Sets the base path of the files defined in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetBasePath(this NuGetPackSettings nuGetPackSettings, string basePath)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.BasePath = basePath;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.Build"/>.</i></p>
        /// <p>Specifies that the project should be built before building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetBuild(this NuGetPackSettings nuGetPackSettings, bool build)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Build = build;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackSettings.Build"/>.</i></p>
        /// <p>Specifies that the project should be built before building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings EnableBuild(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Build = true;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackSettings.Build"/>.</i></p>
        /// <p>Specifies that the project should be built before building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings DisableBuild(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Build = false;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackSettings.Build"/>.</i></p>
        /// <p>Specifies that the project should be built before building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings ToggleBuild(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Build = !nuGetPackSettings.Build;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.Exclude"/>.</i></p>
        /// <p>Specifies one or more wildcard patterns to exclude when creating a package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetExclude(this NuGetPackSettings nuGetPackSettings, string exclude)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Exclude = exclude;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p>
        /// <p>Prevent inclusion of empty directories when building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetExcludeEmptyDirectories(this NuGetPackSettings nuGetPackSettings, bool excludeEmptyDirectories)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ExcludeEmptyDirectories = excludeEmptyDirectories;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p>
        /// <p>Prevent inclusion of empty directories when building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings EnableExcludeEmptyDirectories(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ExcludeEmptyDirectories = true;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p>
        /// <p>Prevent inclusion of empty directories when building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings DisableExcludeEmptyDirectories(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ExcludeEmptyDirectories = false;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p>
        /// <p>Prevent inclusion of empty directories when building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings ToggleExcludeEmptyDirectories(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ExcludeEmptyDirectories = !nuGetPackSettings.ExcludeEmptyDirectories;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p>
        /// <p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetIncludeReferencedProjects(this NuGetPackSettings nuGetPackSettings, bool includeReferencedProjects)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.IncludeReferencedProjects = includeReferencedProjects;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p>
        /// <p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings EnableIncludeReferencedProjects(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.IncludeReferencedProjects = true;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p>
        /// <p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings DisableIncludeReferencedProjects(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.IncludeReferencedProjects = false;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p>
        /// <p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings ToggleIncludeReferencedProjects(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.IncludeReferencedProjects = !nuGetPackSettings.IncludeReferencedProjects;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p>
        /// <p>Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetMinClientVersion(this NuGetPackSettings nuGetPackSettings, bool minClientVersion)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MinClientVersion = minClientVersion;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p>
        /// <p>Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings EnableMinClientVersion(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MinClientVersion = true;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p>
        /// <p>Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings DisableMinClientVersion(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MinClientVersion = false;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p>
        /// <p>Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings ToggleMinClientVersion(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MinClientVersion = !nuGetPackSettings.MinClientVersion;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetForceEnglishOutput(this NuGetPackSettings nuGetPackSettings, bool forceEnglishOutput)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ForceEnglishOutput = forceEnglishOutput;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings EnableForceEnglishOutput(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ForceEnglishOutput = true;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings DisableForceEnglishOutput(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ForceEnglishOutput = false;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings ToggleForceEnglishOutput(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ForceEnglishOutput = !nuGetPackSettings.ForceEnglishOutput;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.MSBuildPath"/>.</i></p>
        /// <p><i>(4.0+)</i> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetMSBuildPath(this NuGetPackSettings nuGetPackSettings, string msbuildPath)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MSBuildPath = msbuildPath;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.MSBuildVersion"/>.</i></p>
        /// <p><i>(3.2+)</i> Specifies the version of MSBuild to be used with this command. Supported values are <i>4</i>, <i>12</i>, <i>14</i>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetMSBuildVersion(this NuGetPackSettings nuGetPackSettings, Nuke.Common.Tools.MSBuild.MSBuildVersion? msbuildVersion)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MSBuildVersion = msbuildVersion;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p>
        /// <p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetNoDefaultExcludes(this NuGetPackSettings nuGetPackSettings, bool noDefaultExcludes)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoDefaultExcludes = noDefaultExcludes;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p>
        /// <p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings EnableNoDefaultExcludes(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoDefaultExcludes = true;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p>
        /// <p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings DisableNoDefaultExcludes(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoDefaultExcludes = false;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p>
        /// <p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings ToggleNoDefaultExcludes(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoDefaultExcludes = !nuGetPackSettings.NoDefaultExcludes;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p>
        /// <p>Specifies that pack should not run package analysis after building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetNoPackageAnalysis(this NuGetPackSettings nuGetPackSettings, bool noPackageAnalysis)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoPackageAnalysis = noPackageAnalysis;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p>
        /// <p>Specifies that pack should not run package analysis after building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings EnableNoPackageAnalysis(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoPackageAnalysis = true;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p>
        /// <p>Specifies that pack should not run package analysis after building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings DisableNoPackageAnalysis(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoPackageAnalysis = false;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p>
        /// <p>Specifies that pack should not run package analysis after building the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings ToggleNoPackageAnalysis(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoPackageAnalysis = !nuGetPackSettings.NoPackageAnalysis;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.OutputDirectory"/>.</i></p>
        /// <p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetOutputDirectory(this NuGetPackSettings nuGetPackSettings, string outputDirectory)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.OutputDirectory = outputDirectory;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.Properties"/> to a new dictionary.</i></p>
        /// <p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetProperties(this NuGetPackSettings nuGetPackSettings, IDictionary<string, string> properties)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="NuGetPackSettings.Properties"/>.</i></p>
        /// <p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings ClearProperties(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.PropertiesInternal.Clear();
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a property to <see cref="NuGetPackSettings.Properties"/>.</i></p>
        /// <p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings AddProperty(this NuGetPackSettings nuGetPackSettings, string propertyKey, string propertyValue)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a property from <see cref="NuGetPackSettings.Properties"/>.</i></p>
        /// <p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings RemoveProperty(this NuGetPackSettings nuGetPackSettings, string propertyKey)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.PropertiesInternal.Remove(propertyKey);
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting a property in <see cref="NuGetPackSettings.Properties"/>.</i></p>
        /// <p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetProperty(this NuGetPackSettings nuGetPackSettings, string propertyKey, string propertyValue)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.PropertiesInternal[propertyKey] = propertyValue;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.Suffix"/>.</i></p>
        /// <p><i>(3.4.4+)</i> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetSuffix(this NuGetPackSettings nuGetPackSettings, string suffix)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Suffix = suffix;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.Symbols"/>.</i></p>
        /// <p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetSymbols(this NuGetPackSettings nuGetPackSettings, bool symbols)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Symbols = symbols;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackSettings.Symbols"/>.</i></p>
        /// <p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings EnableSymbols(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Symbols = true;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackSettings.Symbols"/>.</i></p>
        /// <p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings DisableSymbols(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Symbols = false;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackSettings.Symbols"/>.</i></p>
        /// <p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings ToggleSymbols(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Symbols = !nuGetPackSettings.Symbols;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.Tool"/>.</i></p>
        /// <p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetTool(this NuGetPackSettings nuGetPackSettings, bool tool)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Tool = tool;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackSettings.Tool"/>.</i></p>
        /// <p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings EnableTool(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Tool = true;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackSettings.Tool"/>.</i></p>
        /// <p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings DisableTool(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Tool = false;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackSettings.Tool"/>.</i></p>
        /// <p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings ToggleTool(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Tool = !nuGetPackSettings.Tool;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.Verbosity"/>.</i></p>
        /// <p><i>(2.5+)</i> Specifies the amount of details displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetVerbosity(this NuGetPackSettings nuGetPackSettings, NuGetVerbosity? verbosity)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Verbosity = verbosity;
            return nuGetPackSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackSettings.Version"/>.</i></p>
        /// <p>Overrides the version number from the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static NuGetPackSettings SetVersion(this NuGetPackSettings nuGetPackSettings, string version)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Version = version;
            return nuGetPackSettings;
        }
        [Pure]
        public static NuGetPackSettings SetConfiguration(this NuGetPackSettings nuGetPackSettings, string configuration)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Configuration = configuration;
            return nuGetPackSettings;
        }
    }
    /// <summary>
    /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    public enum NuGetVerbosity
    {
        Normal,
        Quiet,
        Detailed
    }
}
