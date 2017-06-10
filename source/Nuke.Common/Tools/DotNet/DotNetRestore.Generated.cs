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

[assembly: IconClass(typeof(Nuke.Common.Tools.DotNet.DotNetTasks), "magic-wand")]
namespace Nuke.Common.Tools.DotNet
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetTasks
    {
        static partial void PreProcess (DotNetRestoreSettings dotNetRestoreSettings);
        static partial void PostProcess (DotNetRestoreSettings dotNetRestoreSettings);
        /// <summary>
        /// <p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <i>NuGet.config</i> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <i>NuGet.config</i> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <i>/home/user1</i> on Linux or <i>C:\Users\user1</i> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <i>Nuget.Config</i> file, if present. For example, setting the <c>globalPackagesFolder</c> in <i>NuGet.Config</i> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore">official website</a>.</p>
        /// </summary>
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
        /// <summary>
        /// <p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <i>NuGet.config</i> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <i>NuGet.config</i> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <i>/home/user1</i> on Linux or <i>C:\Users\user1</i> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <i>Nuget.Config</i> file, if present. For example, setting the <c>globalPackagesFolder</c> in <i>NuGet.Config</i> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore">official website</a>.</p>
        /// </summary>
        public static void DotNetRestore (string projectFile, Configure<DotNetRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotNetRestore(x => configurator(x).SetProjectFile(projectFile));
        }
    }
    /// <summary>
    /// <p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <i>NuGet.config</i> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <i>NuGet.config</i> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <i>/home/user1</i> on Linux or <i>C:\Users\user1</i> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <i>Nuget.Config</i> file, if present. For example, setting the <c>globalPackagesFolder</c> in <i>NuGet.Config</i> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore">official website</a>.</p>
    /// </summary>
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
              .Add($"restore")
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
    public static partial class DotNetRestoreSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.ProjectFile"/>.</i></p>
        /// <p>Optional path to the project file to restore.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetProjectFile(this DotNetRestoreSettings dotNetRestoreSettings, string projectFile)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.ProjectFile = projectFile;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.Source"/>.</i></p>
        /// <p>Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <i>NuGet.config</i> file(s). Multiple sources can be provided by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetSource(this DotNetRestoreSettings dotNetRestoreSettings, string source)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.Source = source;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.Runtimes"/> to a new list.</i></p>
        /// <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetRuntimes(this DotNetRestoreSettings dotNetRestoreSettings, params string[] runtimes)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal = runtimes.ToList();
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.Runtimes"/> to a new list.</i></p>
        /// <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetRuntimes(this DotNetRestoreSettings dotNetRestoreSettings, IEnumerable<string> runtimes)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal = runtimes.ToList();
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new runtimes to the existing <see cref="DotNetRestoreSettings.Runtimes"/>.</i></p>
        /// <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings AddRuntimes(this DotNetRestoreSettings dotNetRestoreSettings, params string[] runtimes)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal.AddRange(runtimes);
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new runtimes to the existing <see cref="DotNetRestoreSettings.Runtimes"/>.</i></p>
        /// <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings AddRuntimes(this DotNetRestoreSettings dotNetRestoreSettings, IEnumerable<string> runtimes)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal.AddRange(runtimes);
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="DotNetRestoreSettings.Runtimes"/>.</i></p>
        /// <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings ClearRuntimes(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal.Clear();
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single runtime to <see cref="DotNetRestoreSettings.Runtimes"/>.</i></p>
        /// <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings AddRuntime(this DotNetRestoreSettings dotNetRestoreSettings, string runtime)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal.Add(runtime);
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single runtime from <see cref="DotNetRestoreSettings.Runtimes"/>.</i></p>
        /// <p>Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings RemoveRuntime(this DotNetRestoreSettings dotNetRestoreSettings, string runtime)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.RuntimesInternal.Remove(runtime);
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.PackageDirectory"/>.</i></p>
        /// <p>Specifies the directory for restored packages.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetPackageDirectory(this DotNetRestoreSettings dotNetRestoreSettings, string packageDirectory)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.PackageDirectory = packageDirectory;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.DisableParallel"/>.</i></p>
        /// <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetDisableParallel(this DotNetRestoreSettings dotNetRestoreSettings, bool disableParallel)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.DisableParallel = disableParallel;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetRestoreSettings.DisableParallel"/>.</i></p>
        /// <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings EnableDisableParallel(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.DisableParallel = true;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetRestoreSettings.DisableParallel"/>.</i></p>
        /// <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings DisableDisableParallel(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.DisableParallel = false;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetRestoreSettings.DisableParallel"/>.</i></p>
        /// <p>Disables restoring multiple projects in parallel.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings ToggleDisableParallel(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.DisableParallel = !dotNetRestoreSettings.DisableParallel;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.NoCache"/>.</i></p>
        /// <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetNoCache(this DotNetRestoreSettings dotNetRestoreSettings, bool noCache)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoCache = noCache;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetRestoreSettings.NoCache"/>.</i></p>
        /// <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings EnableNoCache(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoCache = true;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetRestoreSettings.NoCache"/>.</i></p>
        /// <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings DisableNoCache(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoCache = false;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetRestoreSettings.NoCache"/>.</i></p>
        /// <p>Specifies to not cache packages and HTTP requests.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings ToggleNoCache(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoCache = !dotNetRestoreSettings.NoCache;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.ConfigFile"/>.</i></p>
        /// <p>The NuGet configuration file (<i>NuGet.config</i>) to use for the restore operation.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetConfigFile(this DotNetRestoreSettings dotNetRestoreSettings, string configFile)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.ConfigFile = configFile;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</i></p>
        /// <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetIgnoreFailedSources(this DotNetRestoreSettings dotNetRestoreSettings, bool ignoreFailedSources)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.IgnoreFailedSources = ignoreFailedSources;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</i></p>
        /// <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings EnableIgnoreFailedSources(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.IgnoreFailedSources = true;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</i></p>
        /// <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings DisableIgnoreFailedSources(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.IgnoreFailedSources = false;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetRestoreSettings.IgnoreFailedSources"/>.</i></p>
        /// <p>Only warn about failed sources if there are packages meeting the version requirement.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings ToggleIgnoreFailedSources(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.IgnoreFailedSources = !dotNetRestoreSettings.IgnoreFailedSources;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.NoDependencies"/>.</i></p>
        /// <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetNoDependencies(this DotNetRestoreSettings dotNetRestoreSettings, bool noDependencies)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoDependencies = noDependencies;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DotNetRestoreSettings.NoDependencies"/>.</i></p>
        /// <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings EnableNoDependencies(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoDependencies = true;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DotNetRestoreSettings.NoDependencies"/>.</i></p>
        /// <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings DisableNoDependencies(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoDependencies = false;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DotNetRestoreSettings.NoDependencies"/>.</i></p>
        /// <p>When restoring a project with project-to-project (P2P) references, restore the root project and not the references.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings ToggleNoDependencies(this DotNetRestoreSettings dotNetRestoreSettings)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.NoDependencies = !dotNetRestoreSettings.NoDependencies;
            return dotNetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRestoreSettings.Verbosity"/>.</i></p>
        /// <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetRestoreSettings SetVerbosity(this DotNetRestoreSettings dotNetRestoreSettings, DotNetVerbosity? verbosity)
        {
            dotNetRestoreSettings = dotNetRestoreSettings.NewInstance();
            dotNetRestoreSettings.Verbosity = verbosity;
            return dotNetRestoreSettings;
        }
    }
    /// <summary>
    /// <p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <i>NuGet.config</i> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <i>NuGet.config</i> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <i>/home/user1</i> on Linux or <i>C:\Users\user1</i> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <i>Nuget.Config</i> file, if present. For example, setting the <c>globalPackagesFolder</c> in <i>NuGet.Config</i> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href="https://docs.microsoft.com/nuget/schema/nuget-config-file">NuGet.Config reference</a>.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore">official website</a>.</p>
    /// </summary>
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
