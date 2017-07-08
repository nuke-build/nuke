// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Auto-generated with Nuke.ToolGenerator.

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

[assembly: IconClass(typeof(Nuke.Common.Tools.Paket.PaketTasks), "box")]

namespace Nuke.Common.Tools.Paket
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketTasks
    {
        static partial void PreProcess (PaketUpdateSettings paketUpdateSettings);
        static partial void PostProcess (PaketUpdateSettings paketUpdateSettings);
        /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><i>Getting started</i> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
        public static void PaketUpdate (Configure<PaketUpdateSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var paketUpdateSettings = configurator.InvokeSafe(new PaketUpdateSettings());
            PreProcess(paketUpdateSettings);
            var process = ProcessTasks.StartProcess(paketUpdateSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(paketUpdateSettings);
        }
        static partial void PreProcess (PaketRestoreSettings paketRestoreSettings);
        static partial void PostProcess (PaketRestoreSettings paketRestoreSettings);
        /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><i>Getting started</i> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
        public static void PaketRestore (Configure<PaketRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var paketRestoreSettings = configurator.InvokeSafe(new PaketRestoreSettings());
            PreProcess(paketRestoreSettings);
            var process = ProcessTasks.StartProcess(paketRestoreSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(paketRestoreSettings);
        }
        static partial void PreProcess (PaketPushSettings paketPushSettings);
        static partial void PostProcess (PaketPushSettings paketPushSettings);
        /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><i>Getting started</i> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
        public static void PaketPush (Configure<PaketPushSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var paketPushSettings = configurator.InvokeSafe(new PaketPushSettings());
            PreProcess(paketPushSettings);
            var process = ProcessTasks.StartProcess(paketPushSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(paketPushSettings);
        }
        static partial void PreProcess (PaketPackSettings paketPackSettings);
        static partial void PostProcess (PaketPackSettings paketPackSettings);
        /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><i>Getting started</i> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
        public static void PaketPack (Configure<PaketPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var paketPackSettings = configurator.InvokeSafe(new PaketPackSettings());
            PreProcess(paketPackSettings);
            var process = ProcessTasks.StartProcess(paketPackSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(paketPackSettings);
        }
    }
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><i>Getting started</i> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketUpdateSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"Paket", packageExecutable: $"paket.exe");
        /// <summary><p>NuGet package id.</p></summary>
        public virtual string PackageId { get; internal set; }
        /// <summary><p>Allows to specify version of the package.</p></summary>
        public virtual string PackageVersion { get; internal set; }
        /// <summary><p>Allows to specify the dependency group.</p></summary>
        public virtual string DependencyGroup { get; internal set; }
        /// <summary><p>Forces the download and reinstallation of all packages.</p></summary>
        public virtual bool Force { get; internal set; }
        /// <summary><p>Creates binding redirects for the NuGet packages.</p></summary>
        public virtual bool Redirects { get; internal set; }
        /// <summary><p>Creates binding redirect files if needed.</p></summary>
        public virtual bool CreateNewBindingFiles { get; internal set; }
        /// <summary><p>Removes all binding redirects that are not specified by Paket.</p></summary>
        public virtual bool CleanRedirects { get; internal set; }
        /// <summary><p>Skips paket install process (patching of csproj, fsproj, ... files) after the generation of paket.lock file.</p></summary>
        public virtual bool NoInstall { get; internal set; }
        /// <summary><p>Allows only updates that are not changing the major version of the NuGet packages.</p></summary>
        public virtual bool KeepMajor { get; internal set; }
        /// <summary><p>Allows only updates that are not changing the minor version of the NuGet packages.</p></summary>
        public virtual bool KeepMinor { get; internal set; }
        /// <summary><p>Allows only updates that are not changing the patch version of the NuGet packages.</p></summary>
        public virtual bool KeepPatch { get; internal set; }
        /// <summary><p>Treat the nuget parameter as a regex to filter packages rather than an exact match.</p></summary>
        public virtual bool Filter { get; internal set; }
        /// <summary><p>Touches project files referencing packages which are affected, to help incremental build tools detecting the change.</p></summary>
        public virtual bool TouchAffectedRefs { get; internal set; }
        /// <summary><p>Enable verbose console output for the paket process.</p></summary>
        public virtual bool Verbose { get; internal set; }
        /// <summary><p>Specify a log file for the paket process.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Suppress console output for the paket process.</p></summary>
        public virtual bool Silent { get; internal set; }
        /// <summary><p>Display the version.</p></summary>
        public virtual bool ShowVersion { get; internal set; }
        /// <summary><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        public virtual bool FromBootstrapper { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("update")
              .Add("nuget {value}", PackageId)
              .Add("version {value}", PackageVersion)
              .Add("group {value}", DependencyGroup)
              .Add("--force", Force)
              .Add("--redirects", Redirects)
              .Add("--createnewbindingfiles", CreateNewBindingFiles)
              .Add("--clean-redirects", CleanRedirects)
              .Add("--no-install", NoInstall)
              .Add("--keep-major", KeepMajor)
              .Add("--keep-minor", KeepMinor)
              .Add("--keep-patch", KeepPatch)
              .Add("--filter", Filter)
              .Add("--touch-affected-refs", TouchAffectedRefs)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--silent", Silent)
              .Add("--version", ShowVersion)
              .Add("--from-bootstrapper", FromBootstrapper);
        }
    }
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><i>Getting started</i> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketRestoreSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"Paket", packageExecutable: $"paket.exe");
        /// <summary><p>Forces the download of all packages.</p></summary>
        public virtual bool Force { get; internal set; }
        /// <summary><p>Allows to restore packages that are referenced in paket.references files, instead of all packages in paket.dependencies.</p></summary>
        public virtual bool OnlyReferenced { get; internal set; }
        /// <summary><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        public virtual bool TouchAffectedRefs { get; internal set; }
        /// <summary><p>Skips the test if paket.dependencies and paket.lock are in sync.</p></summary>
        public virtual bool IgnoreChecks { get; internal set; }
        /// <summary><p>Causes the restore to fail if any of the checks fail.</p></summary>
        public virtual bool FailOnChecks { get; internal set; }
        /// <summary><p>Allows to restore a single group.</p></summary>
        public virtual string DependencyGroup { get; internal set; }
        /// <summary><p>Allows to restore dependencies for a project.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>Allows to restore all packages from the given paket.references files.</p></summary>
        public virtual IReadOnlyList<string> ReferencesFiles => ReferencesFilesInternal.AsReadOnly();
        internal List<string> ReferencesFilesInternal { get; set; } = new List<string>();
        /// <summary><p>Allows to restore only for a specified target framework.</p></summary>
        public virtual string TargetFramework { get; internal set; }
        /// <summary><p>Enable verbose console output for the paket process.</p></summary>
        public virtual bool Verbose { get; internal set; }
        /// <summary><p>Specify a log file for the paket process.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Suppress console output for the paket process.</p></summary>
        public virtual bool Silent { get; internal set; }
        /// <summary><p>Display the version.</p></summary>
        public virtual bool ShowVersion { get; internal set; }
        /// <summary><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        public virtual bool FromBootstrapper { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("restore")
              .Add("--force", Force)
              .Add("--only-referenced", OnlyReferenced)
              .Add("--touch-affected-refs", TouchAffectedRefs)
              .Add("--ignore-checks", IgnoreChecks)
              .Add("--fail-on-checks", FailOnChecks)
              .Add("group {value}", DependencyGroup)
              .Add("--project {value}", ProjectFile)
              .Add("--references-files {value}", ReferencesFiles)
              .Add("--target-framework {value}", TargetFramework)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--silent", Silent)
              .Add("--version", ShowVersion)
              .Add("--from-bootstrapper", FromBootstrapper);
        }
    }
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><i>Getting started</i> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketPushSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"Paket", packageExecutable: $"paket.exe");
        /// <summary><p>Url of the NuGet feed.</p></summary>
        public virtual string Url { get; internal set; }
        /// <summary><p>Path to the package.</p></summary>
        public virtual string File { get; internal set; }
        /// <summary><p>Optionally specify your API key on the command line. Otherwise uses the value of the `nugetkey` environment variable.</p></summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary><p>Optionally specify a custom api endpoint to push to. Defaults to `/api/v2/package`.</p></summary>
        public virtual string Endpoint { get; internal set; }
        /// <summary><p>Enable verbose console output for the paket process.</p></summary>
        public virtual bool Verbose { get; internal set; }
        /// <summary><p>Specify a log file for the paket process.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Suppress console output for the paket process.</p></summary>
        public virtual bool Silent { get; internal set; }
        /// <summary><p>Display the version.</p></summary>
        public virtual bool ShowVersion { get; internal set; }
        /// <summary><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        public virtual bool FromBootstrapper { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("push")
              .Add("url {value}", Url)
              .Add("file {value}", File)
              .Add("apikey {value}", ApiKey)
              .Add("endpoint {value}", Endpoint)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--silent", Silent)
              .Add("--version", ShowVersion)
              .Add("--from-bootstrapper", FromBootstrapper);
        }
    }
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><i>Getting started</i> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketPackSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"Paket", packageExecutable: $"paket.exe");
        /// <summary><p>Output directory to put .nupkg files.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Optionally specify build configuration that should be packaged (defaults to Release).</p></summary>
        public virtual string BuildConfiguration { get; internal set; }
        /// <summary><p>Optionally specify build platform that should be packaged (if not provided or empty, checks all known platform targets).</p></summary>
        public virtual string BuildPlatform { get; internal set; }
        /// <summary><p>Specify version of the package.</p></summary>
        public virtual string PackageVersion { get; internal set; }
        /// <summary><p>Allows to specify a single template file.</p></summary>
        public virtual string TemplateFile { get; internal set; }
        /// <summary><p>Exclude template file by id.</p></summary>
        public virtual string Exclude { get; internal set; }
        /// <summary><p>Specifies a version number for template with given id.</p></summary>
        public virtual string SpecificVersion { get; internal set; }
        /// <summary><p>Specify relase notes for the package.</p></summary>
        public virtual string ReleaseNotes { get; internal set; }
        /// <summary><p>Get the version requirements from paket.lock instead of paket.dependencies.</p></summary>
        public virtual bool LockDependencies { get; internal set; }
        /// <summary><p>Get the version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. `lock-dependencies` will over-ride this option.</p></summary>
        public virtual bool MinimumFromLockFile { get; internal set; }
        /// <summary><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If `lock-dependencies` is specified, project references will be pinned even if this option is not specified.</p></summary>
        public virtual bool PinProjectReferences { get; internal set; }
        /// <summary><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        public virtual bool Symbols { get; internal set; }
        /// <summary><p>Include symbol/source from referenced projects.</p></summary>
        public virtual bool IncludeReferencedProjects { get; internal set; }
        /// <summary><p>Url to the projects home page.</p></summary>
        public virtual string ProjectUrl { get; internal set; }
        /// <summary><p>Enable verbose console output for the paket process.</p></summary>
        public virtual bool Verbose { get; internal set; }
        /// <summary><p>Specify a log file for the paket process.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Suppress console output for the paket process.</p></summary>
        public virtual bool Silent { get; internal set; }
        /// <summary><p>Display the version.</p></summary>
        public virtual bool ShowVersion { get; internal set; }
        /// <summary><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        public virtual bool FromBootstrapper { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("pack")
              .Add("output {value}", OutputDirectory)
              .Add("buildconfig {value}", BuildConfiguration)
              .Add("buildplatform {value}", BuildPlatform)
              .Add("version {value}", PackageVersion)
              .Add("templatefile {value}", TemplateFile)
              .Add("exclude {value}", Exclude)
              .Add("specific-version {value}", SpecificVersion)
              .Add("releaseNotes {value}", ReleaseNotes)
              .Add("lock-dependencies", LockDependencies)
              .Add("minimum-from-lock-file", MinimumFromLockFile)
              .Add("pin-project-references", PinProjectReferences)
              .Add("symbols", Symbols)
              .Add("include-referenced-projects", IncludeReferencedProjects)
              .Add("project-url {value}", ProjectUrl)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--silent", Silent)
              .Add("--version", ShowVersion)
              .Add("--from-bootstrapper", FromBootstrapper);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketUpdateSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.PackageId"/>.</i></p><p>NuGet package id.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetPackageId(this PaketUpdateSettings paketUpdateSettings, string packageId)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.PackageId = packageId;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.PackageVersion"/>.</i></p><p>Allows to specify version of the package.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetPackageVersion(this PaketUpdateSettings paketUpdateSettings, string packageVersion)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.PackageVersion = packageVersion;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.DependencyGroup"/>.</i></p><p>Allows to specify the dependency group.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetDependencyGroup(this PaketUpdateSettings paketUpdateSettings, string dependencyGroup)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.DependencyGroup = dependencyGroup;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.Force"/>.</i></p><p>Forces the download and reinstallation of all packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetForce(this PaketUpdateSettings paketUpdateSettings, bool force)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Force = force;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.Force"/>.</i></p><p>Forces the download and reinstallation of all packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableForce(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Force = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.Force"/>.</i></p><p>Forces the download and reinstallation of all packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableForce(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Force = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.Force"/>.</i></p><p>Forces the download and reinstallation of all packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleForce(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Force = !paketUpdateSettings.Force;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.Redirects"/>.</i></p><p>Creates binding redirects for the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetRedirects(this PaketUpdateSettings paketUpdateSettings, bool redirects)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Redirects = redirects;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.Redirects"/>.</i></p><p>Creates binding redirects for the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableRedirects(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Redirects = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.Redirects"/>.</i></p><p>Creates binding redirects for the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableRedirects(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Redirects = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.Redirects"/>.</i></p><p>Creates binding redirects for the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleRedirects(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Redirects = !paketUpdateSettings.Redirects;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.CreateNewBindingFiles"/>.</i></p><p>Creates binding redirect files if needed.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetCreateNewBindingFiles(this PaketUpdateSettings paketUpdateSettings, bool createNewBindingFiles)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.CreateNewBindingFiles = createNewBindingFiles;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.CreateNewBindingFiles"/>.</i></p><p>Creates binding redirect files if needed.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableCreateNewBindingFiles(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.CreateNewBindingFiles = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.CreateNewBindingFiles"/>.</i></p><p>Creates binding redirect files if needed.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableCreateNewBindingFiles(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.CreateNewBindingFiles = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.CreateNewBindingFiles"/>.</i></p><p>Creates binding redirect files if needed.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleCreateNewBindingFiles(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.CreateNewBindingFiles = !paketUpdateSettings.CreateNewBindingFiles;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.CleanRedirects"/>.</i></p><p>Removes all binding redirects that are not specified by Paket.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetCleanRedirects(this PaketUpdateSettings paketUpdateSettings, bool cleanRedirects)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.CleanRedirects = cleanRedirects;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.CleanRedirects"/>.</i></p><p>Removes all binding redirects that are not specified by Paket.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableCleanRedirects(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.CleanRedirects = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.CleanRedirects"/>.</i></p><p>Removes all binding redirects that are not specified by Paket.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableCleanRedirects(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.CleanRedirects = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.CleanRedirects"/>.</i></p><p>Removes all binding redirects that are not specified by Paket.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleCleanRedirects(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.CleanRedirects = !paketUpdateSettings.CleanRedirects;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.NoInstall"/>.</i></p><p>Skips paket install process (patching of csproj, fsproj, ... files) after the generation of paket.lock file.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetNoInstall(this PaketUpdateSettings paketUpdateSettings, bool noInstall)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.NoInstall = noInstall;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.NoInstall"/>.</i></p><p>Skips paket install process (patching of csproj, fsproj, ... files) after the generation of paket.lock file.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableNoInstall(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.NoInstall = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.NoInstall"/>.</i></p><p>Skips paket install process (patching of csproj, fsproj, ... files) after the generation of paket.lock file.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableNoInstall(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.NoInstall = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.NoInstall"/>.</i></p><p>Skips paket install process (patching of csproj, fsproj, ... files) after the generation of paket.lock file.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleNoInstall(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.NoInstall = !paketUpdateSettings.NoInstall;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.KeepMajor"/>.</i></p><p>Allows only updates that are not changing the major version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetKeepMajor(this PaketUpdateSettings paketUpdateSettings, bool keepMajor)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepMajor = keepMajor;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.KeepMajor"/>.</i></p><p>Allows only updates that are not changing the major version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableKeepMajor(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepMajor = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.KeepMajor"/>.</i></p><p>Allows only updates that are not changing the major version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableKeepMajor(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepMajor = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.KeepMajor"/>.</i></p><p>Allows only updates that are not changing the major version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleKeepMajor(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepMajor = !paketUpdateSettings.KeepMajor;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.KeepMinor"/>.</i></p><p>Allows only updates that are not changing the minor version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetKeepMinor(this PaketUpdateSettings paketUpdateSettings, bool keepMinor)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepMinor = keepMinor;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.KeepMinor"/>.</i></p><p>Allows only updates that are not changing the minor version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableKeepMinor(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepMinor = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.KeepMinor"/>.</i></p><p>Allows only updates that are not changing the minor version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableKeepMinor(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepMinor = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.KeepMinor"/>.</i></p><p>Allows only updates that are not changing the minor version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleKeepMinor(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepMinor = !paketUpdateSettings.KeepMinor;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.KeepPatch"/>.</i></p><p>Allows only updates that are not changing the patch version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetKeepPatch(this PaketUpdateSettings paketUpdateSettings, bool keepPatch)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepPatch = keepPatch;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.KeepPatch"/>.</i></p><p>Allows only updates that are not changing the patch version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableKeepPatch(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepPatch = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.KeepPatch"/>.</i></p><p>Allows only updates that are not changing the patch version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableKeepPatch(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepPatch = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.KeepPatch"/>.</i></p><p>Allows only updates that are not changing the patch version of the NuGet packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleKeepPatch(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.KeepPatch = !paketUpdateSettings.KeepPatch;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.Filter"/>.</i></p><p>Treat the nuget parameter as a regex to filter packages rather than an exact match.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetFilter(this PaketUpdateSettings paketUpdateSettings, bool filter)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Filter = filter;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.Filter"/>.</i></p><p>Treat the nuget parameter as a regex to filter packages rather than an exact match.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableFilter(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Filter = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.Filter"/>.</i></p><p>Treat the nuget parameter as a regex to filter packages rather than an exact match.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableFilter(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Filter = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.Filter"/>.</i></p><p>Treat the nuget parameter as a regex to filter packages rather than an exact match.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleFilter(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Filter = !paketUpdateSettings.Filter;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.TouchAffectedRefs"/>.</i></p><p>Touches project files referencing packages which are affected, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetTouchAffectedRefs(this PaketUpdateSettings paketUpdateSettings, bool touchAffectedRefs)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.TouchAffectedRefs = touchAffectedRefs;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.TouchAffectedRefs"/>.</i></p><p>Touches project files referencing packages which are affected, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableTouchAffectedRefs(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.TouchAffectedRefs = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.TouchAffectedRefs"/>.</i></p><p>Touches project files referencing packages which are affected, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableTouchAffectedRefs(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.TouchAffectedRefs = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.TouchAffectedRefs"/>.</i></p><p>Touches project files referencing packages which are affected, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleTouchAffectedRefs(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.TouchAffectedRefs = !paketUpdateSettings.TouchAffectedRefs;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetVerbose(this PaketUpdateSettings paketUpdateSettings, bool verbose)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Verbose = verbose;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableVerbose(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Verbose = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableVerbose(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Verbose = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleVerbose(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Verbose = !paketUpdateSettings.Verbose;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.LogFile"/>.</i></p><p>Specify a log file for the paket process.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetLogFile(this PaketUpdateSettings paketUpdateSettings, string logFile)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.LogFile = logFile;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetSilent(this PaketUpdateSettings paketUpdateSettings, bool silent)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Silent = silent;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableSilent(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Silent = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableSilent(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Silent = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleSilent(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.Silent = !paketUpdateSettings.Silent;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetShowVersion(this PaketUpdateSettings paketUpdateSettings, bool showVersion)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.ShowVersion = showVersion;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableShowVersion(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.ShowVersion = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableShowVersion(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.ShowVersion = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleShowVersion(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.ShowVersion = !paketUpdateSettings.ShowVersion;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketUpdateSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetFromBootstrapper(this PaketUpdateSettings paketUpdateSettings, bool fromBootstrapper)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.FromBootstrapper = fromBootstrapper;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketUpdateSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableFromBootstrapper(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.FromBootstrapper = true;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketUpdateSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableFromBootstrapper(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.FromBootstrapper = false;
            return paketUpdateSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketUpdateSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleFromBootstrapper(this PaketUpdateSettings paketUpdateSettings)
        {
            paketUpdateSettings = paketUpdateSettings.NewInstance();
            paketUpdateSettings.FromBootstrapper = !paketUpdateSettings.FromBootstrapper;
            return paketUpdateSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketRestoreSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.Force"/>.</i></p><p>Forces the download of all packages.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetForce(this PaketRestoreSettings paketRestoreSettings, bool force)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Force = force;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketRestoreSettings.Force"/>.</i></p><p>Forces the download of all packages.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableForce(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Force = true;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketRestoreSettings.Force"/>.</i></p><p>Forces the download of all packages.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableForce(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Force = false;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketRestoreSettings.Force"/>.</i></p><p>Forces the download of all packages.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleForce(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Force = !paketRestoreSettings.Force;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.OnlyReferenced"/>.</i></p><p>Allows to restore packages that are referenced in paket.references files, instead of all packages in paket.dependencies.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetOnlyReferenced(this PaketRestoreSettings paketRestoreSettings, bool onlyReferenced)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.OnlyReferenced = onlyReferenced;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketRestoreSettings.OnlyReferenced"/>.</i></p><p>Allows to restore packages that are referenced in paket.references files, instead of all packages in paket.dependencies.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableOnlyReferenced(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.OnlyReferenced = true;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketRestoreSettings.OnlyReferenced"/>.</i></p><p>Allows to restore packages that are referenced in paket.references files, instead of all packages in paket.dependencies.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableOnlyReferenced(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.OnlyReferenced = false;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketRestoreSettings.OnlyReferenced"/>.</i></p><p>Allows to restore packages that are referenced in paket.references files, instead of all packages in paket.dependencies.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleOnlyReferenced(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.OnlyReferenced = !paketRestoreSettings.OnlyReferenced;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.TouchAffectedRefs"/>.</i></p><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetTouchAffectedRefs(this PaketRestoreSettings paketRestoreSettings, bool touchAffectedRefs)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.TouchAffectedRefs = touchAffectedRefs;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketRestoreSettings.TouchAffectedRefs"/>.</i></p><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableTouchAffectedRefs(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.TouchAffectedRefs = true;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketRestoreSettings.TouchAffectedRefs"/>.</i></p><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableTouchAffectedRefs(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.TouchAffectedRefs = false;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketRestoreSettings.TouchAffectedRefs"/>.</i></p><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleTouchAffectedRefs(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.TouchAffectedRefs = !paketRestoreSettings.TouchAffectedRefs;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.IgnoreChecks"/>.</i></p><p>Skips the test if paket.dependencies and paket.lock are in sync.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetIgnoreChecks(this PaketRestoreSettings paketRestoreSettings, bool ignoreChecks)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.IgnoreChecks = ignoreChecks;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketRestoreSettings.IgnoreChecks"/>.</i></p><p>Skips the test if paket.dependencies and paket.lock are in sync.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableIgnoreChecks(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.IgnoreChecks = true;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketRestoreSettings.IgnoreChecks"/>.</i></p><p>Skips the test if paket.dependencies and paket.lock are in sync.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableIgnoreChecks(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.IgnoreChecks = false;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketRestoreSettings.IgnoreChecks"/>.</i></p><p>Skips the test if paket.dependencies and paket.lock are in sync.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleIgnoreChecks(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.IgnoreChecks = !paketRestoreSettings.IgnoreChecks;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.FailOnChecks"/>.</i></p><p>Causes the restore to fail if any of the checks fail.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetFailOnChecks(this PaketRestoreSettings paketRestoreSettings, bool failOnChecks)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.FailOnChecks = failOnChecks;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketRestoreSettings.FailOnChecks"/>.</i></p><p>Causes the restore to fail if any of the checks fail.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableFailOnChecks(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.FailOnChecks = true;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketRestoreSettings.FailOnChecks"/>.</i></p><p>Causes the restore to fail if any of the checks fail.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableFailOnChecks(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.FailOnChecks = false;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketRestoreSettings.FailOnChecks"/>.</i></p><p>Causes the restore to fail if any of the checks fail.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleFailOnChecks(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.FailOnChecks = !paketRestoreSettings.FailOnChecks;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.DependencyGroup"/>.</i></p><p>Allows to restore a single group.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetDependencyGroup(this PaketRestoreSettings paketRestoreSettings, string dependencyGroup)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.DependencyGroup = dependencyGroup;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.ProjectFile"/>.</i></p><p>Allows to restore dependencies for a project.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetProjectFile(this PaketRestoreSettings paketRestoreSettings, string projectFile)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ProjectFile = projectFile;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.ReferencesFiles"/> to a new list.</i></p><p>Allows to restore all packages from the given paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetReferencesFiles(this PaketRestoreSettings paketRestoreSettings, params string[] referencesFiles)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ReferencesFilesInternal = referencesFiles.ToList();
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.ReferencesFiles"/> to a new list.</i></p><p>Allows to restore all packages from the given paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetReferencesFiles(this PaketRestoreSettings paketRestoreSettings, IEnumerable<string> referencesFiles)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ReferencesFilesInternal = referencesFiles.ToList();
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding new referencesFiles to the existing <see cref="PaketRestoreSettings.ReferencesFiles"/>.</i></p><p>Allows to restore all packages from the given paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings AddReferencesFiles(this PaketRestoreSettings paketRestoreSettings, params string[] referencesFiles)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ReferencesFilesInternal.AddRange(referencesFiles);
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding new referencesFiles to the existing <see cref="PaketRestoreSettings.ReferencesFiles"/>.</i></p><p>Allows to restore all packages from the given paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings AddReferencesFiles(this PaketRestoreSettings paketRestoreSettings, IEnumerable<string> referencesFiles)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ReferencesFilesInternal.AddRange(referencesFiles);
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="PaketRestoreSettings.ReferencesFiles"/>.</i></p><p>Allows to restore all packages from the given paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings ClearReferencesFiles(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ReferencesFilesInternal.Clear();
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding a single referencesFile to <see cref="PaketRestoreSettings.ReferencesFiles"/>.</i></p><p>Allows to restore all packages from the given paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings AddReferencesFile(this PaketRestoreSettings paketRestoreSettings, string referencesFile)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ReferencesFilesInternal.Add(referencesFile);
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for removing a single referencesFile from <see cref="PaketRestoreSettings.ReferencesFiles"/>.</i></p><p>Allows to restore all packages from the given paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings RemoveReferencesFile(this PaketRestoreSettings paketRestoreSettings, string referencesFile)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ReferencesFilesInternal.Remove(referencesFile);
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.TargetFramework"/>.</i></p><p>Allows to restore only for a specified target framework.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetTargetFramework(this PaketRestoreSettings paketRestoreSettings, string targetFramework)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.TargetFramework = targetFramework;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetVerbose(this PaketRestoreSettings paketRestoreSettings, bool verbose)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Verbose = verbose;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketRestoreSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableVerbose(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Verbose = true;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketRestoreSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableVerbose(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Verbose = false;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketRestoreSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleVerbose(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Verbose = !paketRestoreSettings.Verbose;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.LogFile"/>.</i></p><p>Specify a log file for the paket process.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetLogFile(this PaketRestoreSettings paketRestoreSettings, string logFile)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.LogFile = logFile;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetSilent(this PaketRestoreSettings paketRestoreSettings, bool silent)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Silent = silent;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketRestoreSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableSilent(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Silent = true;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketRestoreSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableSilent(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Silent = false;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketRestoreSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleSilent(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.Silent = !paketRestoreSettings.Silent;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetShowVersion(this PaketRestoreSettings paketRestoreSettings, bool showVersion)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ShowVersion = showVersion;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketRestoreSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableShowVersion(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ShowVersion = true;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketRestoreSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableShowVersion(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ShowVersion = false;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketRestoreSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleShowVersion(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.ShowVersion = !paketRestoreSettings.ShowVersion;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketRestoreSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetFromBootstrapper(this PaketRestoreSettings paketRestoreSettings, bool fromBootstrapper)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.FromBootstrapper = fromBootstrapper;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketRestoreSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableFromBootstrapper(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.FromBootstrapper = true;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketRestoreSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableFromBootstrapper(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.FromBootstrapper = false;
            return paketRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketRestoreSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleFromBootstrapper(this PaketRestoreSettings paketRestoreSettings)
        {
            paketRestoreSettings = paketRestoreSettings.NewInstance();
            paketRestoreSettings.FromBootstrapper = !paketRestoreSettings.FromBootstrapper;
            return paketRestoreSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketPushSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="PaketPushSettings.Url"/>.</i></p><p>Url of the NuGet feed.</p></summary>
        [Pure]
        public static PaketPushSettings SetUrl(this PaketPushSettings paketPushSettings, string url)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.Url = url;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPushSettings.File"/>.</i></p><p>Path to the package.</p></summary>
        [Pure]
        public static PaketPushSettings SetFile(this PaketPushSettings paketPushSettings, string file)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.File = file;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPushSettings.ApiKey"/>.</i></p><p>Optionally specify your API key on the command line. Otherwise uses the value of the `nugetkey` environment variable.</p></summary>
        [Pure]
        public static PaketPushSettings SetApiKey(this PaketPushSettings paketPushSettings, string apiKey)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.ApiKey = apiKey;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPushSettings.Endpoint"/>.</i></p><p>Optionally specify a custom api endpoint to push to. Defaults to `/api/v2/package`.</p></summary>
        [Pure]
        public static PaketPushSettings SetEndpoint(this PaketPushSettings paketPushSettings, string endpoint)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.Endpoint = endpoint;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPushSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketPushSettings SetVerbose(this PaketPushSettings paketPushSettings, bool verbose)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.Verbose = verbose;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPushSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketPushSettings EnableVerbose(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.Verbose = true;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPushSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketPushSettings DisableVerbose(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.Verbose = false;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPushSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketPushSettings ToggleVerbose(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.Verbose = !paketPushSettings.Verbose;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPushSettings.LogFile"/>.</i></p><p>Specify a log file for the paket process.</p></summary>
        [Pure]
        public static PaketPushSettings SetLogFile(this PaketPushSettings paketPushSettings, string logFile)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.LogFile = logFile;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPushSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketPushSettings SetSilent(this PaketPushSettings paketPushSettings, bool silent)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.Silent = silent;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPushSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketPushSettings EnableSilent(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.Silent = true;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPushSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketPushSettings DisableSilent(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.Silent = false;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPushSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketPushSettings ToggleSilent(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.Silent = !paketPushSettings.Silent;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPushSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketPushSettings SetShowVersion(this PaketPushSettings paketPushSettings, bool showVersion)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.ShowVersion = showVersion;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPushSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketPushSettings EnableShowVersion(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.ShowVersion = true;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPushSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketPushSettings DisableShowVersion(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.ShowVersion = false;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPushSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketPushSettings ToggleShowVersion(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.ShowVersion = !paketPushSettings.ShowVersion;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPushSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPushSettings SetFromBootstrapper(this PaketPushSettings paketPushSettings, bool fromBootstrapper)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.FromBootstrapper = fromBootstrapper;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPushSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPushSettings EnableFromBootstrapper(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.FromBootstrapper = true;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPushSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPushSettings DisableFromBootstrapper(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.FromBootstrapper = false;
            return paketPushSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPushSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPushSettings ToggleFromBootstrapper(this PaketPushSettings paketPushSettings)
        {
            paketPushSettings = paketPushSettings.NewInstance();
            paketPushSettings.FromBootstrapper = !paketPushSettings.FromBootstrapper;
            return paketPushSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketPackSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.OutputDirectory"/>.</i></p><p>Output directory to put .nupkg files.</p></summary>
        [Pure]
        public static PaketPackSettings SetOutputDirectory(this PaketPackSettings paketPackSettings, string outputDirectory)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.OutputDirectory = outputDirectory;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.BuildConfiguration"/>.</i></p><p>Optionally specify build configuration that should be packaged (defaults to Release).</p></summary>
        [Pure]
        public static PaketPackSettings SetBuildConfiguration(this PaketPackSettings paketPackSettings, string buildConfiguration)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.BuildConfiguration = buildConfiguration;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.BuildPlatform"/>.</i></p><p>Optionally specify build platform that should be packaged (if not provided or empty, checks all known platform targets).</p></summary>
        [Pure]
        public static PaketPackSettings SetBuildPlatform(this PaketPackSettings paketPackSettings, string buildPlatform)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.BuildPlatform = buildPlatform;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.PackageVersion"/>.</i></p><p>Specify version of the package.</p></summary>
        [Pure]
        public static PaketPackSettings SetPackageVersion(this PaketPackSettings paketPackSettings, string packageVersion)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.PackageVersion = packageVersion;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.TemplateFile"/>.</i></p><p>Allows to specify a single template file.</p></summary>
        [Pure]
        public static PaketPackSettings SetTemplateFile(this PaketPackSettings paketPackSettings, string templateFile)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.TemplateFile = templateFile;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.Exclude"/>.</i></p><p>Exclude template file by id.</p></summary>
        [Pure]
        public static PaketPackSettings SetExclude(this PaketPackSettings paketPackSettings, string exclude)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Exclude = exclude;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.SpecificVersion"/>.</i></p><p>Specifies a version number for template with given id.</p></summary>
        [Pure]
        public static PaketPackSettings SetSpecificVersion(this PaketPackSettings paketPackSettings, string specificVersion)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.SpecificVersion = specificVersion;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.ReleaseNotes"/>.</i></p><p>Specify relase notes for the package.</p></summary>
        [Pure]
        public static PaketPackSettings SetReleaseNotes(this PaketPackSettings paketPackSettings, string releaseNotes)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.ReleaseNotes = releaseNotes;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.LockDependencies"/>.</i></p><p>Get the version requirements from paket.lock instead of paket.dependencies.</p></summary>
        [Pure]
        public static PaketPackSettings SetLockDependencies(this PaketPackSettings paketPackSettings, bool lockDependencies)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.LockDependencies = lockDependencies;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPackSettings.LockDependencies"/>.</i></p><p>Get the version requirements from paket.lock instead of paket.dependencies.</p></summary>
        [Pure]
        public static PaketPackSettings EnableLockDependencies(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.LockDependencies = true;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPackSettings.LockDependencies"/>.</i></p><p>Get the version requirements from paket.lock instead of paket.dependencies.</p></summary>
        [Pure]
        public static PaketPackSettings DisableLockDependencies(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.LockDependencies = false;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPackSettings.LockDependencies"/>.</i></p><p>Get the version requirements from paket.lock instead of paket.dependencies.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleLockDependencies(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.LockDependencies = !paketPackSettings.LockDependencies;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.MinimumFromLockFile"/>.</i></p><p>Get the version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. `lock-dependencies` will over-ride this option.</p></summary>
        [Pure]
        public static PaketPackSettings SetMinimumFromLockFile(this PaketPackSettings paketPackSettings, bool minimumFromLockFile)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.MinimumFromLockFile = minimumFromLockFile;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPackSettings.MinimumFromLockFile"/>.</i></p><p>Get the version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. `lock-dependencies` will over-ride this option.</p></summary>
        [Pure]
        public static PaketPackSettings EnableMinimumFromLockFile(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.MinimumFromLockFile = true;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPackSettings.MinimumFromLockFile"/>.</i></p><p>Get the version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. `lock-dependencies` will over-ride this option.</p></summary>
        [Pure]
        public static PaketPackSettings DisableMinimumFromLockFile(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.MinimumFromLockFile = false;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPackSettings.MinimumFromLockFile"/>.</i></p><p>Get the version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. `lock-dependencies` will over-ride this option.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleMinimumFromLockFile(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.MinimumFromLockFile = !paketPackSettings.MinimumFromLockFile;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.PinProjectReferences"/>.</i></p><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If `lock-dependencies` is specified, project references will be pinned even if this option is not specified.</p></summary>
        [Pure]
        public static PaketPackSettings SetPinProjectReferences(this PaketPackSettings paketPackSettings, bool pinProjectReferences)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.PinProjectReferences = pinProjectReferences;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPackSettings.PinProjectReferences"/>.</i></p><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If `lock-dependencies` is specified, project references will be pinned even if this option is not specified.</p></summary>
        [Pure]
        public static PaketPackSettings EnablePinProjectReferences(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.PinProjectReferences = true;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPackSettings.PinProjectReferences"/>.</i></p><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If `lock-dependencies` is specified, project references will be pinned even if this option is not specified.</p></summary>
        [Pure]
        public static PaketPackSettings DisablePinProjectReferences(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.PinProjectReferences = false;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPackSettings.PinProjectReferences"/>.</i></p><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If `lock-dependencies` is specified, project references will be pinned even if this option is not specified.</p></summary>
        [Pure]
        public static PaketPackSettings TogglePinProjectReferences(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.PinProjectReferences = !paketPackSettings.PinProjectReferences;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.Symbols"/>.</i></p><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        [Pure]
        public static PaketPackSettings SetSymbols(this PaketPackSettings paketPackSettings, bool symbols)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Symbols = symbols;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPackSettings.Symbols"/>.</i></p><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        [Pure]
        public static PaketPackSettings EnableSymbols(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Symbols = true;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPackSettings.Symbols"/>.</i></p><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        [Pure]
        public static PaketPackSettings DisableSymbols(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Symbols = false;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPackSettings.Symbols"/>.</i></p><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleSymbols(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Symbols = !paketPackSettings.Symbols;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.IncludeReferencedProjects"/>.</i></p><p>Include symbol/source from referenced projects.</p></summary>
        [Pure]
        public static PaketPackSettings SetIncludeReferencedProjects(this PaketPackSettings paketPackSettings, bool includeReferencedProjects)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.IncludeReferencedProjects = includeReferencedProjects;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPackSettings.IncludeReferencedProjects"/>.</i></p><p>Include symbol/source from referenced projects.</p></summary>
        [Pure]
        public static PaketPackSettings EnableIncludeReferencedProjects(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.IncludeReferencedProjects = true;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPackSettings.IncludeReferencedProjects"/>.</i></p><p>Include symbol/source from referenced projects.</p></summary>
        [Pure]
        public static PaketPackSettings DisableIncludeReferencedProjects(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.IncludeReferencedProjects = false;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPackSettings.IncludeReferencedProjects"/>.</i></p><p>Include symbol/source from referenced projects.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleIncludeReferencedProjects(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.IncludeReferencedProjects = !paketPackSettings.IncludeReferencedProjects;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.ProjectUrl"/>.</i></p><p>Url to the projects home page.</p></summary>
        [Pure]
        public static PaketPackSettings SetProjectUrl(this PaketPackSettings paketPackSettings, string projectUrl)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.ProjectUrl = projectUrl;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketPackSettings SetVerbose(this PaketPackSettings paketPackSettings, bool verbose)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Verbose = verbose;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPackSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketPackSettings EnableVerbose(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Verbose = true;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPackSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketPackSettings DisableVerbose(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Verbose = false;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPackSettings.Verbose"/>.</i></p><p>Enable verbose console output for the paket process.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleVerbose(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Verbose = !paketPackSettings.Verbose;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.LogFile"/>.</i></p><p>Specify a log file for the paket process.</p></summary>
        [Pure]
        public static PaketPackSettings SetLogFile(this PaketPackSettings paketPackSettings, string logFile)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.LogFile = logFile;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketPackSettings SetSilent(this PaketPackSettings paketPackSettings, bool silent)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Silent = silent;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPackSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketPackSettings EnableSilent(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Silent = true;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPackSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketPackSettings DisableSilent(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Silent = false;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPackSettings.Silent"/>.</i></p><p>Suppress console output for the paket process.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleSilent(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.Silent = !paketPackSettings.Silent;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketPackSettings SetShowVersion(this PaketPackSettings paketPackSettings, bool showVersion)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.ShowVersion = showVersion;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPackSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketPackSettings EnableShowVersion(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.ShowVersion = true;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPackSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketPackSettings DisableShowVersion(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.ShowVersion = false;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPackSettings.ShowVersion"/>.</i></p><p>Display the version.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleShowVersion(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.ShowVersion = !paketPackSettings.ShowVersion;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="PaketPackSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPackSettings SetFromBootstrapper(this PaketPackSettings paketPackSettings, bool fromBootstrapper)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.FromBootstrapper = fromBootstrapper;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="PaketPackSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPackSettings EnableFromBootstrapper(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.FromBootstrapper = true;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="PaketPackSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPackSettings DisableFromBootstrapper(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.FromBootstrapper = false;
            return paketPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="PaketPackSettings.FromBootstrapper"/>.</i></p><p>Call coming from the '--run' feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleFromBootstrapper(this PaketPackSettings paketPackSettings)
        {
            paketPackSettings = paketPackSettings.NewInstance();
            paketPackSettings.FromBootstrapper = !paketPackSettings.FromBootstrapper;
            return paketPackSettings;
        }
    }
}
