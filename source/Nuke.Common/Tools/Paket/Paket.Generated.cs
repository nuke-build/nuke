// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, Version: Local.
// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/Paket.json.

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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Paket
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketTasks
    {
        /// <summary><p>Path to the Paket executable.</p></summary>
        public static string PaketPath => ToolPathResolver.GetPackageExecutable("Paket", "paket.exe");
        /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p></summary>
        public static IReadOnlyCollection<Output> Paket(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(PaketPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, null, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> PaketUpdate(Configure<PaketUpdateSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new PaketUpdateSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> PaketRestore(Configure<PaketRestoreSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new PaketRestoreSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> PaketPush(Configure<PaketPushSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new PaketPushSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> PaketPack(Configure<PaketPackSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new PaketPackSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
    }
    #region PaketUpdateSettings
    /// <summary><p>Used within <see cref="PaketTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketUpdateSettings : ToolSettings
    {
        /// <summary><p>Path to the Paket executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? PaketTasks.PaketPath;
        /// <summary><p>NuGet package ID.</p></summary>
        public virtual string PackageId { get; internal set; }
        /// <summary><p>Dependency version constraint.</p></summary>
        public virtual string PackageVersion { get; internal set; }
        /// <summary><p>Dependency group to update. Default is <em>all groups</em>.</p></summary>
        public virtual string DependencyGroup { get; internal set; }
        /// <summary><p>Creates binding redirect files if needed.</p></summary>
        public virtual bool? CreateNewBindingFiles { get; internal set; }
        /// <summary><p>Force download and reinstallation of all dependencies.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Create binding redirects.</p></summary>
        public virtual bool? Redirects { get; internal set; }
        /// <summary><p>Remove binding redirects that were not created by Paket.</p></summary>
        public virtual bool? CleanRedirects { get; internal set; }
        /// <summary><p>Do not modify projects.</p></summary>
        public virtual bool? NoInstall { get; internal set; }
        /// <summary><p>Only allow updates that preserve the major version.</p></summary>
        public virtual bool? KeepMajor { get; internal set; }
        /// <summary><p>Only allow updates that preserve the minor version.</p></summary>
        public virtual bool? KeepMinor { get; internal set; }
        /// <summary><p>Only allow updates that preserve the patch version.</p></summary>
        public virtual bool? KeepPatch { get; internal set; }
        /// <summary><p>Treat the NuGet package ID as a regex to filter packages.</p></summary>
        public virtual bool? Filter { get; internal set; }
        /// <summary><p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p></summary>
        public virtual bool? TouchAffectedReferences { get; internal set; }
        /// <summary><p>Suppress console output.</p></summary>
        public virtual bool? Silent { get; internal set; }
        /// <summary><p>Print detailed information to the console.</p></summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary><p>Print output to a file.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        public virtual bool? FromBootstrapper { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("update")
              .Add("{value}", PackageId)
              .Add("--version {value}", PackageVersion)
              .Add("--group {value}", DependencyGroup)
              .Add("--create-new-binding-files", CreateNewBindingFiles)
              .Add("--force", Force)
              .Add("--redirects", Redirects)
              .Add("--clean-redirects", CleanRedirects)
              .Add("--no-install", NoInstall)
              .Add("--keep-major", KeepMajor)
              .Add("--keep-minor", KeepMinor)
              .Add("--keep-patch", KeepPatch)
              .Add("--filter", Filter)
              .Add("--touch-affected-refs", TouchAffectedReferences)
              .Add("--silent", Silent)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--from-bootstrapper", FromBootstrapper);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region PaketRestoreSettings
    /// <summary><p>Used within <see cref="PaketTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketRestoreSettings : ToolSettings
    {
        /// <summary><p>Path to the Paket executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? PaketTasks.PaketPath;
        /// <summary><p>Force download and reinstallation of all dependencies.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Only restore packages that are referenced by paket.references files.</p></summary>
        public virtual bool? OnlyReferenced { get; internal set; }
        /// <summary><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        public virtual bool? TouchAffectedRefs { get; internal set; }
        /// <summary><p>Do not check if paket.dependencies and paket.lock are in sync.</p></summary>
        public virtual bool? IgnoreChecks { get; internal set; }
        /// <summary><p>Abort if any checks fail.</p></summary>
        public virtual bool? FailOnChecks { get; internal set; }
        /// <summary><p>Restore dependencies of a single group.</p></summary>
        public virtual string DependencyGroup { get; internal set; }
        /// <summary><p>Restore dependencies of a single project.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary><p>Restore packages from a paket.references file.</p></summary>
        public virtual IReadOnlyList<string> ReferencesFiles => ReferencesFilesInternal.AsReadOnly();
        internal List<string> ReferencesFilesInternal { get; set; } = new List<string>();
        /// <summary><p>Restore only for the specified target framework.</p></summary>
        public virtual string TargetFramework { get; internal set; }
        /// <summary><p>Suppress console output.</p></summary>
        public virtual bool? Silent { get; internal set; }
        /// <summary><p>Print detailed information to the console.</p></summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary><p>Print output to a file.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        public virtual bool? FromBootstrapper { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("restore")
              .Add("--force", Force)
              .Add("--only-referenced", OnlyReferenced)
              .Add("--touch-affected-refs", TouchAffectedRefs)
              .Add("--ignore-checks", IgnoreChecks)
              .Add("--fail-on-checks", FailOnChecks)
              .Add("--group {value}", DependencyGroup)
              .Add("--project {value}", ProjectFile)
              .Add("--references-files {value}", ReferencesFiles)
              .Add("--target-framework {value}", TargetFramework)
              .Add("--silent", Silent)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--from-bootstrapper", FromBootstrapper);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region PaketPushSettings
    /// <summary><p>Used within <see cref="PaketTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketPushSettings : ToolSettings
    {
        /// <summary><p>Path to the Paket executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? PaketTasks.PaketPath;
        /// <summary><p>Path to the package.</p></summary>
        public virtual string File { get; internal set; }
        /// <summary><p>URL of the NuGet feed.</p></summary>
        public virtual string Url { get; internal set; }
        /// <summary><p>API key for the URL. Default is the <c>NUGET_KEY</c> environment variable.</p></summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary><p>API endpoint to push to. Default is <em>/api/v2/package</em>.</p></summary>
        public virtual string Endpoint { get; internal set; }
        /// <summary><p>Suppress console output.</p></summary>
        public virtual bool? Silent { get; internal set; }
        /// <summary><p>Print detailed information to the console.</p></summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary><p>Print output to a file.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        public virtual bool? FromBootstrapper { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("push")
              .Add("file {value}", File)
              .Add("--url {value}", Url)
              .Add("--api-key {value}", ApiKey, secret: true)
              .Add("--endpoint {value}", Endpoint)
              .Add("--silent", Silent)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--from-bootstrapper", FromBootstrapper);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region PaketPackSettings
    /// <summary><p>Used within <see cref="PaketTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketPackSettings : ToolSettings
    {
        /// <summary><p>Path to the Paket executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? PaketTasks.PaketPath;
        /// <summary><p>Output directory for .nupkg files.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Build configuration that should be packaged. Default is <em>Release</em>.</p></summary>
        public virtual string BuildConfiguration { get; internal set; }
        /// <summary><p>Build platform that should be packaged. Default is <em>check all known platform targets</em>.</p></summary>
        public virtual string BuildPlatform { get; internal set; }
        /// <summary><p>Version of the package.</p></summary>
        public virtual string PackageVersion { get; internal set; }
        /// <summary><p>Pack a single paket.template file.</p></summary>
        public virtual string TemplateFile { get; internal set; }
        /// <summary><p>Exclude paket.template file by package ID.</p></summary>
        public virtual IReadOnlyList<string> Exclude => ExcludeInternal.AsReadOnly();
        internal List<string> ExcludeInternal { get; set; } = new List<string>();
        /// <summary><p>Package IDs with version numbers.</p></summary>
        public virtual IReadOnlyDictionary<string, string> SpecificVersions => SpecificVersionsInternal.AsReadOnly();
        internal Dictionary<string, string> SpecificVersionsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Specify release notes for the package.</p></summary>
        public virtual string ReleaseNotes { get; internal set; }
        /// <summary><p>Use version requirements from paket.lock instead of paket.dependencies.</p></summary>
        public virtual bool? LockDependencies { get; internal set; }
        /// <summary><p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p></summary>
        public virtual bool? MinimumFromLockFile { get; internal set; }
        /// <summary><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p></summary>
        public virtual bool? PinProjectReferences { get; internal set; }
        /// <summary><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        public virtual bool? Symbols { get; internal set; }
        /// <summary><p>Include symbol/source from referenced projects.</p></summary>
        public virtual bool? IncludeReferencedProjects { get; internal set; }
        /// <summary><p>Url to the projects home page.</p></summary>
        public virtual string ProjectUrl { get; internal set; }
        /// <summary><p>Suppress console output.</p></summary>
        public virtual bool? Silent { get; internal set; }
        /// <summary><p>Print detailed information to the console.</p></summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary><p>Print output to a file.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        public virtual bool? FromBootstrapper { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("pack")
              .Add("{value}", OutputDirectory)
              .Add("--build-config {value}", BuildConfiguration)
              .Add("--build-platform {value}", BuildPlatform)
              .Add("--version {value}", PackageVersion)
              .Add("--template {value}", TemplateFile)
              .Add("--exclude {value}", Exclude)
              .Add("--specific-version {value}", SpecificVersions, "{key} {value}")
              .Add("--release-notes {value}", ReleaseNotes)
              .Add("--lock-dependencies", LockDependencies)
              .Add("--minimum-from-lock-file", MinimumFromLockFile)
              .Add("--pin-project-references", PinProjectReferences)
              .Add("--symbols", Symbols)
              .Add("--include-referenced-projects", IncludeReferencedProjects)
              .Add("--project-url {value}", ProjectUrl)
              .Add("--silent", Silent)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--from-bootstrapper", FromBootstrapper);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region PaketUpdateSettingsExtensions
    /// <summary><p>Used within <see cref="PaketTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketUpdateSettingsExtensions
    {
        #region PackageId
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.PackageId"/>.</em></p><p>NuGet package ID.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetPackageId(this PaketUpdateSettings toolSettings, string packageId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageId = packageId;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.PackageId"/>.</em></p><p>NuGet package ID.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetPackageId(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageId = null;
            return toolSettings;
        }
        #endregion
        #region PackageVersion
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.PackageVersion"/>.</em></p><p>Dependency version constraint.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetPackageVersion(this PaketUpdateSettings toolSettings, string packageVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersion = packageVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.PackageVersion"/>.</em></p><p>Dependency version constraint.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetPackageVersion(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersion = null;
            return toolSettings;
        }
        #endregion
        #region DependencyGroup
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.DependencyGroup"/>.</em></p><p>Dependency group to update. Default is <em>all groups</em>.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetDependencyGroup(this PaketUpdateSettings toolSettings, string dependencyGroup)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyGroup = dependencyGroup;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.DependencyGroup"/>.</em></p><p>Dependency group to update. Default is <em>all groups</em>.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetDependencyGroup(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyGroup = null;
            return toolSettings;
        }
        #endregion
        #region CreateNewBindingFiles
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.CreateNewBindingFiles"/>.</em></p><p>Creates binding redirect files if needed.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetCreateNewBindingFiles(this PaketUpdateSettings toolSettings, bool? createNewBindingFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNewBindingFiles = createNewBindingFiles;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.CreateNewBindingFiles"/>.</em></p><p>Creates binding redirect files if needed.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetCreateNewBindingFiles(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNewBindingFiles = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.CreateNewBindingFiles"/>.</em></p><p>Creates binding redirect files if needed.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableCreateNewBindingFiles(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNewBindingFiles = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.CreateNewBindingFiles"/>.</em></p><p>Creates binding redirect files if needed.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableCreateNewBindingFiles(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNewBindingFiles = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.CreateNewBindingFiles"/>.</em></p><p>Creates binding redirect files if needed.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleCreateNewBindingFiles(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNewBindingFiles = !toolSettings.CreateNewBindingFiles;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.Force"/>.</em></p><p>Force download and reinstallation of all dependencies.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetForce(this PaketUpdateSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.Force"/>.</em></p><p>Force download and reinstallation of all dependencies.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetForce(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.Force"/>.</em></p><p>Force download and reinstallation of all dependencies.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableForce(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.Force"/>.</em></p><p>Force download and reinstallation of all dependencies.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableForce(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.Force"/>.</em></p><p>Force download and reinstallation of all dependencies.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleForce(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Redirects
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.Redirects"/>.</em></p><p>Create binding redirects.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetRedirects(this PaketUpdateSettings toolSettings, bool? redirects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Redirects = redirects;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.Redirects"/>.</em></p><p>Create binding redirects.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetRedirects(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Redirects = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.Redirects"/>.</em></p><p>Create binding redirects.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableRedirects(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Redirects = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.Redirects"/>.</em></p><p>Create binding redirects.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableRedirects(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Redirects = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.Redirects"/>.</em></p><p>Create binding redirects.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleRedirects(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Redirects = !toolSettings.Redirects;
            return toolSettings;
        }
        #endregion
        #region CleanRedirects
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.CleanRedirects"/>.</em></p><p>Remove binding redirects that were not created by Paket.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetCleanRedirects(this PaketUpdateSettings toolSettings, bool? cleanRedirects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanRedirects = cleanRedirects;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.CleanRedirects"/>.</em></p><p>Remove binding redirects that were not created by Paket.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetCleanRedirects(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanRedirects = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.CleanRedirects"/>.</em></p><p>Remove binding redirects that were not created by Paket.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableCleanRedirects(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanRedirects = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.CleanRedirects"/>.</em></p><p>Remove binding redirects that were not created by Paket.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableCleanRedirects(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanRedirects = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.CleanRedirects"/>.</em></p><p>Remove binding redirects that were not created by Paket.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleCleanRedirects(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanRedirects = !toolSettings.CleanRedirects;
            return toolSettings;
        }
        #endregion
        #region NoInstall
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.NoInstall"/>.</em></p><p>Do not modify projects.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetNoInstall(this PaketUpdateSettings toolSettings, bool? noInstall)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInstall = noInstall;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.NoInstall"/>.</em></p><p>Do not modify projects.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetNoInstall(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInstall = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.NoInstall"/>.</em></p><p>Do not modify projects.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableNoInstall(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInstall = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.NoInstall"/>.</em></p><p>Do not modify projects.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableNoInstall(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInstall = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.NoInstall"/>.</em></p><p>Do not modify projects.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleNoInstall(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInstall = !toolSettings.NoInstall;
            return toolSettings;
        }
        #endregion
        #region KeepMajor
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.KeepMajor"/>.</em></p><p>Only allow updates that preserve the major version.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetKeepMajor(this PaketUpdateSettings toolSettings, bool? keepMajor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMajor = keepMajor;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.KeepMajor"/>.</em></p><p>Only allow updates that preserve the major version.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetKeepMajor(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMajor = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.KeepMajor"/>.</em></p><p>Only allow updates that preserve the major version.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableKeepMajor(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMajor = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.KeepMajor"/>.</em></p><p>Only allow updates that preserve the major version.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableKeepMajor(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMajor = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.KeepMajor"/>.</em></p><p>Only allow updates that preserve the major version.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleKeepMajor(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMajor = !toolSettings.KeepMajor;
            return toolSettings;
        }
        #endregion
        #region KeepMinor
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.KeepMinor"/>.</em></p><p>Only allow updates that preserve the minor version.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetKeepMinor(this PaketUpdateSettings toolSettings, bool? keepMinor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMinor = keepMinor;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.KeepMinor"/>.</em></p><p>Only allow updates that preserve the minor version.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetKeepMinor(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMinor = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.KeepMinor"/>.</em></p><p>Only allow updates that preserve the minor version.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableKeepMinor(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMinor = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.KeepMinor"/>.</em></p><p>Only allow updates that preserve the minor version.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableKeepMinor(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMinor = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.KeepMinor"/>.</em></p><p>Only allow updates that preserve the minor version.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleKeepMinor(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMinor = !toolSettings.KeepMinor;
            return toolSettings;
        }
        #endregion
        #region KeepPatch
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.KeepPatch"/>.</em></p><p>Only allow updates that preserve the patch version.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetKeepPatch(this PaketUpdateSettings toolSettings, bool? keepPatch)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepPatch = keepPatch;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.KeepPatch"/>.</em></p><p>Only allow updates that preserve the patch version.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetKeepPatch(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepPatch = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.KeepPatch"/>.</em></p><p>Only allow updates that preserve the patch version.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableKeepPatch(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepPatch = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.KeepPatch"/>.</em></p><p>Only allow updates that preserve the patch version.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableKeepPatch(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepPatch = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.KeepPatch"/>.</em></p><p>Only allow updates that preserve the patch version.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleKeepPatch(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepPatch = !toolSettings.KeepPatch;
            return toolSettings;
        }
        #endregion
        #region Filter
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.Filter"/>.</em></p><p>Treat the NuGet package ID as a regex to filter packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetFilter(this PaketUpdateSettings toolSettings, bool? filter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.Filter"/>.</em></p><p>Treat the NuGet package ID as a regex to filter packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetFilter(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.Filter"/>.</em></p><p>Treat the NuGet package ID as a regex to filter packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableFilter(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.Filter"/>.</em></p><p>Treat the NuGet package ID as a regex to filter packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableFilter(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.Filter"/>.</em></p><p>Treat the NuGet package ID as a regex to filter packages.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleFilter(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = !toolSettings.Filter;
            return toolSettings;
        }
        #endregion
        #region TouchAffectedReferences
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.TouchAffectedReferences"/>.</em></p><p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetTouchAffectedReferences(this PaketUpdateSettings toolSettings, bool? touchAffectedReferences)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedReferences = touchAffectedReferences;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.TouchAffectedReferences"/>.</em></p><p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetTouchAffectedReferences(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedReferences = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.TouchAffectedReferences"/>.</em></p><p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableTouchAffectedReferences(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedReferences = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.TouchAffectedReferences"/>.</em></p><p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableTouchAffectedReferences(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedReferences = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.TouchAffectedReferences"/>.</em></p><p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleTouchAffectedReferences(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedReferences = !toolSettings.TouchAffectedReferences;
            return toolSettings;
        }
        #endregion
        #region Silent
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetSilent(this PaketUpdateSettings toolSettings, bool? silent)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = silent;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetSilent(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableSilent(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableSilent(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleSilent(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = !toolSettings.Silent;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetVerbose(this PaketUpdateSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetVerbose(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableVerbose(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableVerbose(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleVerbose(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.LogFile"/>.</em></p><p>Print output to a file.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetLogFile(this PaketUpdateSettings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.LogFile"/>.</em></p><p>Print output to a file.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetLogFile(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region FromBootstrapper
        /// <summary><p><em>Sets <see cref="PaketUpdateSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketUpdateSettings SetFromBootstrapper(this PaketUpdateSettings toolSettings, bool? fromBootstrapper)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = fromBootstrapper;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketUpdateSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketUpdateSettings ResetFromBootstrapper(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketUpdateSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketUpdateSettings EnableFromBootstrapper(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketUpdateSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketUpdateSettings DisableFromBootstrapper(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketUpdateSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketUpdateSettings ToggleFromBootstrapper(this PaketUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = !toolSettings.FromBootstrapper;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region PaketRestoreSettingsExtensions
    /// <summary><p>Used within <see cref="PaketTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketRestoreSettingsExtensions
    {
        #region Force
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.Force"/>.</em></p><p>Force download and reinstallation of all dependencies.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetForce(this PaketRestoreSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.Force"/>.</em></p><p>Force download and reinstallation of all dependencies.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetForce(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketRestoreSettings.Force"/>.</em></p><p>Force download and reinstallation of all dependencies.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableForce(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketRestoreSettings.Force"/>.</em></p><p>Force download and reinstallation of all dependencies.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableForce(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketRestoreSettings.Force"/>.</em></p><p>Force download and reinstallation of all dependencies.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleForce(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region OnlyReferenced
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.OnlyReferenced"/>.</em></p><p>Only restore packages that are referenced by paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetOnlyReferenced(this PaketRestoreSettings toolSettings, bool? onlyReferenced)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyReferenced = onlyReferenced;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.OnlyReferenced"/>.</em></p><p>Only restore packages that are referenced by paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetOnlyReferenced(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyReferenced = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketRestoreSettings.OnlyReferenced"/>.</em></p><p>Only restore packages that are referenced by paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableOnlyReferenced(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyReferenced = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketRestoreSettings.OnlyReferenced"/>.</em></p><p>Only restore packages that are referenced by paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableOnlyReferenced(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyReferenced = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketRestoreSettings.OnlyReferenced"/>.</em></p><p>Only restore packages that are referenced by paket.references files.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleOnlyReferenced(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyReferenced = !toolSettings.OnlyReferenced;
            return toolSettings;
        }
        #endregion
        #region TouchAffectedRefs
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.TouchAffectedRefs"/>.</em></p><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetTouchAffectedRefs(this PaketRestoreSettings toolSettings, bool? touchAffectedRefs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedRefs = touchAffectedRefs;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.TouchAffectedRefs"/>.</em></p><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetTouchAffectedRefs(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedRefs = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketRestoreSettings.TouchAffectedRefs"/>.</em></p><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableTouchAffectedRefs(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedRefs = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketRestoreSettings.TouchAffectedRefs"/>.</em></p><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableTouchAffectedRefs(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedRefs = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketRestoreSettings.TouchAffectedRefs"/>.</em></p><p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleTouchAffectedRefs(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedRefs = !toolSettings.TouchAffectedRefs;
            return toolSettings;
        }
        #endregion
        #region IgnoreChecks
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.IgnoreChecks"/>.</em></p><p>Do not check if paket.dependencies and paket.lock are in sync.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetIgnoreChecks(this PaketRestoreSettings toolSettings, bool? ignoreChecks)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChecks = ignoreChecks;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.IgnoreChecks"/>.</em></p><p>Do not check if paket.dependencies and paket.lock are in sync.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetIgnoreChecks(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChecks = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketRestoreSettings.IgnoreChecks"/>.</em></p><p>Do not check if paket.dependencies and paket.lock are in sync.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableIgnoreChecks(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChecks = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketRestoreSettings.IgnoreChecks"/>.</em></p><p>Do not check if paket.dependencies and paket.lock are in sync.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableIgnoreChecks(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChecks = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketRestoreSettings.IgnoreChecks"/>.</em></p><p>Do not check if paket.dependencies and paket.lock are in sync.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleIgnoreChecks(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChecks = !toolSettings.IgnoreChecks;
            return toolSettings;
        }
        #endregion
        #region FailOnChecks
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.FailOnChecks"/>.</em></p><p>Abort if any checks fail.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetFailOnChecks(this PaketRestoreSettings toolSettings, bool? failOnChecks)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnChecks = failOnChecks;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.FailOnChecks"/>.</em></p><p>Abort if any checks fail.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetFailOnChecks(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnChecks = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketRestoreSettings.FailOnChecks"/>.</em></p><p>Abort if any checks fail.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableFailOnChecks(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnChecks = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketRestoreSettings.FailOnChecks"/>.</em></p><p>Abort if any checks fail.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableFailOnChecks(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnChecks = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketRestoreSettings.FailOnChecks"/>.</em></p><p>Abort if any checks fail.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleFailOnChecks(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnChecks = !toolSettings.FailOnChecks;
            return toolSettings;
        }
        #endregion
        #region DependencyGroup
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.DependencyGroup"/>.</em></p><p>Restore dependencies of a single group.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetDependencyGroup(this PaketRestoreSettings toolSettings, string dependencyGroup)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyGroup = dependencyGroup;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.DependencyGroup"/>.</em></p><p>Restore dependencies of a single group.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetDependencyGroup(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyGroup = null;
            return toolSettings;
        }
        #endregion
        #region ProjectFile
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.ProjectFile"/>.</em></p><p>Restore dependencies of a single project.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetProjectFile(this PaketRestoreSettings toolSettings, string projectFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.ProjectFile"/>.</em></p><p>Restore dependencies of a single project.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetProjectFile(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region ReferencesFiles
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.ReferencesFiles"/> to a new list.</em></p><p>Restore packages from a paket.references file.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetReferencesFiles(this PaketRestoreSettings toolSettings, params string[] referencesFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencesFilesInternal = referencesFiles.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.ReferencesFiles"/> to a new list.</em></p><p>Restore packages from a paket.references file.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetReferencesFiles(this PaketRestoreSettings toolSettings, IEnumerable<string> referencesFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencesFilesInternal = referencesFiles.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="PaketRestoreSettings.ReferencesFiles"/>.</em></p><p>Restore packages from a paket.references file.</p></summary>
        [Pure]
        public static PaketRestoreSettings AddReferencesFiles(this PaketRestoreSettings toolSettings, params string[] referencesFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencesFilesInternal.AddRange(referencesFiles);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="PaketRestoreSettings.ReferencesFiles"/>.</em></p><p>Restore packages from a paket.references file.</p></summary>
        [Pure]
        public static PaketRestoreSettings AddReferencesFiles(this PaketRestoreSettings toolSettings, IEnumerable<string> referencesFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencesFilesInternal.AddRange(referencesFiles);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="PaketRestoreSettings.ReferencesFiles"/>.</em></p><p>Restore packages from a paket.references file.</p></summary>
        [Pure]
        public static PaketRestoreSettings ClearReferencesFiles(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencesFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="PaketRestoreSettings.ReferencesFiles"/>.</em></p><p>Restore packages from a paket.references file.</p></summary>
        [Pure]
        public static PaketRestoreSettings RemoveReferencesFiles(this PaketRestoreSettings toolSettings, params string[] referencesFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencesFiles);
            toolSettings.ReferencesFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="PaketRestoreSettings.ReferencesFiles"/>.</em></p><p>Restore packages from a paket.references file.</p></summary>
        [Pure]
        public static PaketRestoreSettings RemoveReferencesFiles(this PaketRestoreSettings toolSettings, IEnumerable<string> referencesFiles)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencesFiles);
            toolSettings.ReferencesFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TargetFramework
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.TargetFramework"/>.</em></p><p>Restore only for the specified target framework.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetTargetFramework(this PaketRestoreSettings toolSettings, string targetFramework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetFramework = targetFramework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.TargetFramework"/>.</em></p><p>Restore only for the specified target framework.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetTargetFramework(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetFramework = null;
            return toolSettings;
        }
        #endregion
        #region Silent
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetSilent(this PaketRestoreSettings toolSettings, bool? silent)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = silent;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetSilent(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketRestoreSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableSilent(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketRestoreSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableSilent(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketRestoreSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleSilent(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = !toolSettings.Silent;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetVerbose(this PaketRestoreSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetVerbose(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketRestoreSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableVerbose(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketRestoreSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableVerbose(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketRestoreSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleVerbose(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.LogFile"/>.</em></p><p>Print output to a file.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetLogFile(this PaketRestoreSettings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.LogFile"/>.</em></p><p>Print output to a file.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetLogFile(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region FromBootstrapper
        /// <summary><p><em>Sets <see cref="PaketRestoreSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketRestoreSettings SetFromBootstrapper(this PaketRestoreSettings toolSettings, bool? fromBootstrapper)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = fromBootstrapper;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketRestoreSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketRestoreSettings ResetFromBootstrapper(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketRestoreSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketRestoreSettings EnableFromBootstrapper(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketRestoreSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketRestoreSettings DisableFromBootstrapper(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketRestoreSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketRestoreSettings ToggleFromBootstrapper(this PaketRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = !toolSettings.FromBootstrapper;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region PaketPushSettingsExtensions
    /// <summary><p>Used within <see cref="PaketTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketPushSettingsExtensions
    {
        #region File
        /// <summary><p><em>Sets <see cref="PaketPushSettings.File"/>.</em></p><p>Path to the package.</p></summary>
        [Pure]
        public static PaketPushSettings SetFile(this PaketPushSettings toolSettings, string file)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPushSettings.File"/>.</em></p><p>Path to the package.</p></summary>
        [Pure]
        public static PaketPushSettings ResetFile(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary><p><em>Sets <see cref="PaketPushSettings.Url"/>.</em></p><p>URL of the NuGet feed.</p></summary>
        [Pure]
        public static PaketPushSettings SetUrl(this PaketPushSettings toolSettings, string url)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPushSettings.Url"/>.</em></p><p>URL of the NuGet feed.</p></summary>
        [Pure]
        public static PaketPushSettings ResetUrl(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary><p><em>Sets <see cref="PaketPushSettings.ApiKey"/>.</em></p><p>API key for the URL. Default is the <c>NUGET_KEY</c> environment variable.</p></summary>
        [Pure]
        public static PaketPushSettings SetApiKey(this PaketPushSettings toolSettings, string apiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPushSettings.ApiKey"/>.</em></p><p>API key for the URL. Default is the <c>NUGET_KEY</c> environment variable.</p></summary>
        [Pure]
        public static PaketPushSettings ResetApiKey(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Endpoint
        /// <summary><p><em>Sets <see cref="PaketPushSettings.Endpoint"/>.</em></p><p>API endpoint to push to. Default is <em>/api/v2/package</em>.</p></summary>
        [Pure]
        public static PaketPushSettings SetEndpoint(this PaketPushSettings toolSettings, string endpoint)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Endpoint = endpoint;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPushSettings.Endpoint"/>.</em></p><p>API endpoint to push to. Default is <em>/api/v2/package</em>.</p></summary>
        [Pure]
        public static PaketPushSettings ResetEndpoint(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Endpoint = null;
            return toolSettings;
        }
        #endregion
        #region Silent
        /// <summary><p><em>Sets <see cref="PaketPushSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketPushSettings SetSilent(this PaketPushSettings toolSettings, bool? silent)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = silent;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPushSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketPushSettings ResetSilent(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPushSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketPushSettings EnableSilent(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPushSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketPushSettings DisableSilent(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPushSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketPushSettings ToggleSilent(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = !toolSettings.Silent;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary><p><em>Sets <see cref="PaketPushSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketPushSettings SetVerbose(this PaketPushSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPushSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketPushSettings ResetVerbose(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPushSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketPushSettings EnableVerbose(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPushSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketPushSettings DisableVerbose(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPushSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketPushSettings ToggleVerbose(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary><p><em>Sets <see cref="PaketPushSettings.LogFile"/>.</em></p><p>Print output to a file.</p></summary>
        [Pure]
        public static PaketPushSettings SetLogFile(this PaketPushSettings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPushSettings.LogFile"/>.</em></p><p>Print output to a file.</p></summary>
        [Pure]
        public static PaketPushSettings ResetLogFile(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region FromBootstrapper
        /// <summary><p><em>Sets <see cref="PaketPushSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPushSettings SetFromBootstrapper(this PaketPushSettings toolSettings, bool? fromBootstrapper)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = fromBootstrapper;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPushSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPushSettings ResetFromBootstrapper(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPushSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPushSettings EnableFromBootstrapper(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPushSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPushSettings DisableFromBootstrapper(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPushSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPushSettings ToggleFromBootstrapper(this PaketPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = !toolSettings.FromBootstrapper;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region PaketPackSettingsExtensions
    /// <summary><p>Used within <see cref="PaketTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketPackSettingsExtensions
    {
        #region OutputDirectory
        /// <summary><p><em>Sets <see cref="PaketPackSettings.OutputDirectory"/>.</em></p><p>Output directory for .nupkg files.</p></summary>
        [Pure]
        public static PaketPackSettings SetOutputDirectory(this PaketPackSettings toolSettings, string outputDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.OutputDirectory"/>.</em></p><p>Output directory for .nupkg files.</p></summary>
        [Pure]
        public static PaketPackSettings ResetOutputDirectory(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region BuildConfiguration
        /// <summary><p><em>Sets <see cref="PaketPackSettings.BuildConfiguration"/>.</em></p><p>Build configuration that should be packaged. Default is <em>Release</em>.</p></summary>
        [Pure]
        public static PaketPackSettings SetBuildConfiguration(this PaketPackSettings toolSettings, string buildConfiguration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildConfiguration = buildConfiguration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.BuildConfiguration"/>.</em></p><p>Build configuration that should be packaged. Default is <em>Release</em>.</p></summary>
        [Pure]
        public static PaketPackSettings ResetBuildConfiguration(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildConfiguration = null;
            return toolSettings;
        }
        #endregion
        #region BuildPlatform
        /// <summary><p><em>Sets <see cref="PaketPackSettings.BuildPlatform"/>.</em></p><p>Build platform that should be packaged. Default is <em>check all known platform targets</em>.</p></summary>
        [Pure]
        public static PaketPackSettings SetBuildPlatform(this PaketPackSettings toolSettings, string buildPlatform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildPlatform = buildPlatform;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.BuildPlatform"/>.</em></p><p>Build platform that should be packaged. Default is <em>check all known platform targets</em>.</p></summary>
        [Pure]
        public static PaketPackSettings ResetBuildPlatform(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildPlatform = null;
            return toolSettings;
        }
        #endregion
        #region PackageVersion
        /// <summary><p><em>Sets <see cref="PaketPackSettings.PackageVersion"/>.</em></p><p>Version of the package.</p></summary>
        [Pure]
        public static PaketPackSettings SetPackageVersion(this PaketPackSettings toolSettings, string packageVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersion = packageVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.PackageVersion"/>.</em></p><p>Version of the package.</p></summary>
        [Pure]
        public static PaketPackSettings ResetPackageVersion(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersion = null;
            return toolSettings;
        }
        #endregion
        #region TemplateFile
        /// <summary><p><em>Sets <see cref="PaketPackSettings.TemplateFile"/>.</em></p><p>Pack a single paket.template file.</p></summary>
        [Pure]
        public static PaketPackSettings SetTemplateFile(this PaketPackSettings toolSettings, string templateFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateFile = templateFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.TemplateFile"/>.</em></p><p>Pack a single paket.template file.</p></summary>
        [Pure]
        public static PaketPackSettings ResetTemplateFile(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateFile = null;
            return toolSettings;
        }
        #endregion
        #region Exclude
        /// <summary><p><em>Sets <see cref="PaketPackSettings.Exclude"/> to a new list.</em></p><p>Exclude paket.template file by package ID.</p></summary>
        [Pure]
        public static PaketPackSettings SetExclude(this PaketPackSettings toolSettings, params string[] exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="PaketPackSettings.Exclude"/> to a new list.</em></p><p>Exclude paket.template file by package ID.</p></summary>
        [Pure]
        public static PaketPackSettings SetExclude(this PaketPackSettings toolSettings, IEnumerable<string> exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="PaketPackSettings.Exclude"/>.</em></p><p>Exclude paket.template file by package ID.</p></summary>
        [Pure]
        public static PaketPackSettings AddExclude(this PaketPackSettings toolSettings, params string[] exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="PaketPackSettings.Exclude"/>.</em></p><p>Exclude paket.template file by package ID.</p></summary>
        [Pure]
        public static PaketPackSettings AddExclude(this PaketPackSettings toolSettings, IEnumerable<string> exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="PaketPackSettings.Exclude"/>.</em></p><p>Exclude paket.template file by package ID.</p></summary>
        [Pure]
        public static PaketPackSettings ClearExclude(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="PaketPackSettings.Exclude"/>.</em></p><p>Exclude paket.template file by package ID.</p></summary>
        [Pure]
        public static PaketPackSettings RemoveExclude(this PaketPackSettings toolSettings, params string[] exclude)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="PaketPackSettings.Exclude"/>.</em></p><p>Exclude paket.template file by package ID.</p></summary>
        [Pure]
        public static PaketPackSettings RemoveExclude(this PaketPackSettings toolSettings, IEnumerable<string> exclude)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SpecificVersions
        /// <summary><p><em>Sets <see cref="PaketPackSettings.SpecificVersions"/> to a new dictionary.</em></p><p>Package IDs with version numbers.</p></summary>
        [Pure]
        public static PaketPackSettings SetSpecificVersions(this PaketPackSettings toolSettings, IDictionary<string, string> specificVersions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificVersionsInternal = specificVersions.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="PaketPackSettings.SpecificVersions"/>.</em></p><p>Package IDs with version numbers.</p></summary>
        [Pure]
        public static PaketPackSettings ClearSpecificVersions(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificVersionsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="PaketPackSettings.SpecificVersions"/>.</em></p><p>Package IDs with version numbers.</p></summary>
        [Pure]
        public static PaketPackSettings AddSpecificVersion(this PaketPackSettings toolSettings, string specificVersionKey, string specificVersionValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificVersionsInternal.Add(specificVersionKey, specificVersionValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="PaketPackSettings.SpecificVersions"/>.</em></p><p>Package IDs with version numbers.</p></summary>
        [Pure]
        public static PaketPackSettings RemoveSpecificVersion(this PaketPackSettings toolSettings, string specificVersionKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificVersionsInternal.Remove(specificVersionKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="PaketPackSettings.SpecificVersions"/>.</em></p><p>Package IDs with version numbers.</p></summary>
        [Pure]
        public static PaketPackSettings SetSpecificVersion(this PaketPackSettings toolSettings, string specificVersionKey, string specificVersionValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificVersionsInternal[specificVersionKey] = specificVersionValue;
            return toolSettings;
        }
        #endregion
        #region ReleaseNotes
        /// <summary><p><em>Sets <see cref="PaketPackSettings.ReleaseNotes"/>.</em></p><p>Specify release notes for the package.</p></summary>
        [Pure]
        public static PaketPackSettings SetReleaseNotes(this PaketPackSettings toolSettings, string releaseNotes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = releaseNotes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.ReleaseNotes"/>.</em></p><p>Specify release notes for the package.</p></summary>
        [Pure]
        public static PaketPackSettings ResetReleaseNotes(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = null;
            return toolSettings;
        }
        #endregion
        #region LockDependencies
        /// <summary><p><em>Sets <see cref="PaketPackSettings.LockDependencies"/>.</em></p><p>Use version requirements from paket.lock instead of paket.dependencies.</p></summary>
        [Pure]
        public static PaketPackSettings SetLockDependencies(this PaketPackSettings toolSettings, bool? lockDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockDependencies = lockDependencies;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.LockDependencies"/>.</em></p><p>Use version requirements from paket.lock instead of paket.dependencies.</p></summary>
        [Pure]
        public static PaketPackSettings ResetLockDependencies(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockDependencies = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPackSettings.LockDependencies"/>.</em></p><p>Use version requirements from paket.lock instead of paket.dependencies.</p></summary>
        [Pure]
        public static PaketPackSettings EnableLockDependencies(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockDependencies = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPackSettings.LockDependencies"/>.</em></p><p>Use version requirements from paket.lock instead of paket.dependencies.</p></summary>
        [Pure]
        public static PaketPackSettings DisableLockDependencies(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockDependencies = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPackSettings.LockDependencies"/>.</em></p><p>Use version requirements from paket.lock instead of paket.dependencies.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleLockDependencies(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockDependencies = !toolSettings.LockDependencies;
            return toolSettings;
        }
        #endregion
        #region MinimumFromLockFile
        /// <summary><p><em>Sets <see cref="PaketPackSettings.MinimumFromLockFile"/>.</em></p><p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p></summary>
        [Pure]
        public static PaketPackSettings SetMinimumFromLockFile(this PaketPackSettings toolSettings, bool? minimumFromLockFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumFromLockFile = minimumFromLockFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.MinimumFromLockFile"/>.</em></p><p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p></summary>
        [Pure]
        public static PaketPackSettings ResetMinimumFromLockFile(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumFromLockFile = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPackSettings.MinimumFromLockFile"/>.</em></p><p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p></summary>
        [Pure]
        public static PaketPackSettings EnableMinimumFromLockFile(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumFromLockFile = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPackSettings.MinimumFromLockFile"/>.</em></p><p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p></summary>
        [Pure]
        public static PaketPackSettings DisableMinimumFromLockFile(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumFromLockFile = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPackSettings.MinimumFromLockFile"/>.</em></p><p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleMinimumFromLockFile(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumFromLockFile = !toolSettings.MinimumFromLockFile;
            return toolSettings;
        }
        #endregion
        #region PinProjectReferences
        /// <summary><p><em>Sets <see cref="PaketPackSettings.PinProjectReferences"/>.</em></p><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p></summary>
        [Pure]
        public static PaketPackSettings SetPinProjectReferences(this PaketPackSettings toolSettings, bool? pinProjectReferences)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PinProjectReferences = pinProjectReferences;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.PinProjectReferences"/>.</em></p><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p></summary>
        [Pure]
        public static PaketPackSettings ResetPinProjectReferences(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PinProjectReferences = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPackSettings.PinProjectReferences"/>.</em></p><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p></summary>
        [Pure]
        public static PaketPackSettings EnablePinProjectReferences(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PinProjectReferences = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPackSettings.PinProjectReferences"/>.</em></p><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p></summary>
        [Pure]
        public static PaketPackSettings DisablePinProjectReferences(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PinProjectReferences = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPackSettings.PinProjectReferences"/>.</em></p><p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p></summary>
        [Pure]
        public static PaketPackSettings TogglePinProjectReferences(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PinProjectReferences = !toolSettings.PinProjectReferences;
            return toolSettings;
        }
        #endregion
        #region Symbols
        /// <summary><p><em>Sets <see cref="PaketPackSettings.Symbols"/>.</em></p><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        [Pure]
        public static PaketPackSettings SetSymbols(this PaketPackSettings toolSettings, bool? symbols)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = symbols;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.Symbols"/>.</em></p><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        [Pure]
        public static PaketPackSettings ResetSymbols(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPackSettings.Symbols"/>.</em></p><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        [Pure]
        public static PaketPackSettings EnableSymbols(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPackSettings.Symbols"/>.</em></p><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        [Pure]
        public static PaketPackSettings DisableSymbols(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPackSettings.Symbols"/>.</em></p><p>Build symbol/source packages in addition to library/content packages.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleSymbols(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = !toolSettings.Symbols;
            return toolSettings;
        }
        #endregion
        #region IncludeReferencedProjects
        /// <summary><p><em>Sets <see cref="PaketPackSettings.IncludeReferencedProjects"/>.</em></p><p>Include symbol/source from referenced projects.</p></summary>
        [Pure]
        public static PaketPackSettings SetIncludeReferencedProjects(this PaketPackSettings toolSettings, bool? includeReferencedProjects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = includeReferencedProjects;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.IncludeReferencedProjects"/>.</em></p><p>Include symbol/source from referenced projects.</p></summary>
        [Pure]
        public static PaketPackSettings ResetIncludeReferencedProjects(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPackSettings.IncludeReferencedProjects"/>.</em></p><p>Include symbol/source from referenced projects.</p></summary>
        [Pure]
        public static PaketPackSettings EnableIncludeReferencedProjects(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPackSettings.IncludeReferencedProjects"/>.</em></p><p>Include symbol/source from referenced projects.</p></summary>
        [Pure]
        public static PaketPackSettings DisableIncludeReferencedProjects(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPackSettings.IncludeReferencedProjects"/>.</em></p><p>Include symbol/source from referenced projects.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleIncludeReferencedProjects(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = !toolSettings.IncludeReferencedProjects;
            return toolSettings;
        }
        #endregion
        #region ProjectUrl
        /// <summary><p><em>Sets <see cref="PaketPackSettings.ProjectUrl"/>.</em></p><p>Url to the projects home page.</p></summary>
        [Pure]
        public static PaketPackSettings SetProjectUrl(this PaketPackSettings toolSettings, string projectUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectUrl = projectUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.ProjectUrl"/>.</em></p><p>Url to the projects home page.</p></summary>
        [Pure]
        public static PaketPackSettings ResetProjectUrl(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectUrl = null;
            return toolSettings;
        }
        #endregion
        #region Silent
        /// <summary><p><em>Sets <see cref="PaketPackSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketPackSettings SetSilent(this PaketPackSettings toolSettings, bool? silent)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = silent;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketPackSettings ResetSilent(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPackSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketPackSettings EnableSilent(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPackSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketPackSettings DisableSilent(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPackSettings.Silent"/>.</em></p><p>Suppress console output.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleSilent(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = !toolSettings.Silent;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary><p><em>Sets <see cref="PaketPackSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketPackSettings SetVerbose(this PaketPackSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketPackSettings ResetVerbose(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPackSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketPackSettings EnableVerbose(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPackSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketPackSettings DisableVerbose(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPackSettings.Verbose"/>.</em></p><p>Print detailed information to the console.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleVerbose(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary><p><em>Sets <see cref="PaketPackSettings.LogFile"/>.</em></p><p>Print output to a file.</p></summary>
        [Pure]
        public static PaketPackSettings SetLogFile(this PaketPackSettings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.LogFile"/>.</em></p><p>Print output to a file.</p></summary>
        [Pure]
        public static PaketPackSettings ResetLogFile(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region FromBootstrapper
        /// <summary><p><em>Sets <see cref="PaketPackSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPackSettings SetFromBootstrapper(this PaketPackSettings toolSettings, bool? fromBootstrapper)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = fromBootstrapper;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PaketPackSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPackSettings ResetFromBootstrapper(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PaketPackSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPackSettings EnableFromBootstrapper(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PaketPackSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPackSettings DisableFromBootstrapper(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PaketPackSettings.FromBootstrapper"/>.</em></p><p>Call coming from the <c>--run</c> feature of the bootstrapper.</p></summary>
        [Pure]
        public static PaketPackSettings ToggleFromBootstrapper(this PaketPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = !toolSettings.FromBootstrapper;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
