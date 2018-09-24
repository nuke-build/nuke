// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/Pnpm.json
// Generated with Nuke.CodeGeneration, Version: Local

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

namespace Nuke.Common.Tools.Pnpm
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PnpmTasks
    {
        /// <summary><p>Path to the Pnpm executable.</p></summary>
        public static string PnpmPath => ToolPathResolver.GetPathExecutable("pnpm");
        /// <summary><p>pnpm is the package manager for the Node JavaScript platform. It puts modules in place so that node can find them, and manages dependency conflicts intelligently.<para/>It is extremely configurable to support a wide variety of use cases. Most commonly, it is used to publish, discover, install, and develop node programs.</p></summary>
        public static IReadOnlyCollection<Output> Pnpm(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(PnpmPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, null, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Installs a package, and any packages that it depends on. If the package has a package-lock or shrinkwrap file, the installation of dependencies will be driven by that, with an <b>pnpm-shrinkwrap.json</b> taking precedence if both files exist. See <a href="https://docs.npmjs.com/files/package-lock.json">package-lock.json</a> and <a href="https://docs.npmjs.com/cli/shrinkwrap">pnpm-shrinkwrap</a>.<para/>A package is: <ul><li>a) A folder containing a program described by a <a href="https://docs.npmjs.com/files/package.json">package.json file</a></li><li>b) A gzipped tarball containing (b)</li><li>c) A url that resolves to (b)</li><li>d) a <c>&lt;name&gt;@&lt;version&gt;</c> that is published on the registry (see <a href="https://docs.npmjs.com/misc/registry">pnpm-registry</a>) with (c)</li><li>e) a <c>&lt;name&gt;@&lt;tag&gt;</c> (see <a href="https://docs.npmjs.com/cli/dist-tag">pnpm-dist-tag</a>) that points to (d)</li><li>f) a <c>&lt;name&gt;</c> that has a "latest" tag satisfying (e)</li><li>g) a <c>&lt;git remote url&gt;</c> that resolves to (a)</li></ul></p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> PnpmInstall(Configure<PnpmInstallSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new PnpmInstallSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Runs an arbitrary command from a package's <c>"scripts"</c> object. If no <c>"command"</c> is provided, it will list the available scripts. <c>run[-script]</c> is used by the test, start, restart, and stop commands, but can be called directly, as well. When the scripts in the package are printed out, they're separated into lifecycle (test, start, restart) and directly-run scripts."</p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> PnpmRun(Configure<PnpmRunSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new PnpmRunSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
    }
    #region PnpmInstallSettings
    /// <summary><p>Used within <see cref="PnpmTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PnpmInstallSettings : ToolSettings
    {
        /// <summary><p>Path to the Pnpm executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? PnpmTasks.PnpmPath;
        /// <summary><p>List of packages to be installed.</p></summary>
        public virtual IReadOnlyList<string> Packages => PackagesInternal.AsReadOnly();
        internal List<string> PackagesInternal { get; set; } = new List<string>();
        /// <summary><p>Causes pnpm to not install modules listed in devDependencies.</p></summary>
        public virtual bool? Production { get; internal set; }
        /// <summary><p>Forces pnpm to fetch remote resources even if a local copy exists on disk.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Causes pnpm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">pnpm-folders</a>.</p></summary>
        public virtual bool? Global { get; internal set; }
        /// <summary><p>Causes pnpm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        public virtual bool? GlobalStyle { get; internal set; }
        /// <summary><p>Causes pnpm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">pnpm-scripts</a>.</p></summary>
        public virtual bool? IgnoreScripts { get; internal set; }
        /// <summary><p>Causes pnpm to install the package such that versions of pnpm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        public virtual bool? LegacyBundling { get; internal set; }
        /// <summary><p>Cause pnpm to link global installs into the local space in some cases.</p></summary>
        public virtual bool? Link { get; internal set; }
        /// <summary><p>Prevents pnpm from creating symlinks for any binaries the package might contain.</p></summary>
        public virtual bool? NoBinLinks { get; internal set; }
        /// <summary><p>Prevents optional dependencies from being installed.</p></summary>
        public virtual bool? NoOptional { get; internal set; }
        /// <summary><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        public virtual bool? NoShrinkWrap { get; internal set; }
        /// <summary><p>Allows pnpm to find the node source code so that pnpm can compile native modules.</p></summary>
        public virtual string NodeDir { get; internal set; }
        /// <summary><p>Causes either only <c>devDependencies</c> or only non-<c>devDependencies</c> to be installed regardless of the <c>NODE_ENV</c>.</p></summary>
        public virtual NpmOnlyMode Only { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("install")
              .Add("{value}", Packages)
              .Add("--production", Production)
              .Add("--force", Force)
              .Add("--global", Global)
              .Add("--global-style", GlobalStyle)
              .Add("--ignore-scripts", IgnoreScripts)
              .Add("--legacy-bundling", LegacyBundling)
              .Add("--link", Link)
              .Add("--no-bin-links", NoBinLinks)
              .Add("--no-optional", NoOptional)
              .Add("--no-shrinkwrap", NoShrinkWrap)
              .Add("--nodedir={value}", NodeDir)
              .Add("--only={value}", Only);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region PnpmRunSettings
    /// <summary><p>Used within <see cref="PnpmTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PnpmRunSettings : ToolSettings
    {
        /// <summary><p>Path to the Pnpm executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? PnpmTasks.PnpmPath;
        /// <summary><p>The command to be executed.</p></summary>
        public virtual string Command { get; internal set; }
        /// <summary><p>Arguments passed to the script.</p></summary>
        public virtual IReadOnlyList<string> Arguments => ArgumentsInternal.AsReadOnly();
        internal List<string> ArgumentsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("run")
              .Add("{value}", Command)
              .Add("-- {value}", Arguments, separator: ' ');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region PnpmInstallSettingsExtensions
    /// <summary><p>Used within <see cref="PnpmTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PnpmInstallSettingsExtensions
    {
        #region Packages
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.Packages"/> to a new list.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetPackages(this PnpmInstallSettings toolSettings, params string[] packages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal = packages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.Packages"/> to a new list.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetPackages(this PnpmInstallSettings toolSettings, IEnumerable<string> packages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal = packages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="PnpmInstallSettings.Packages"/>.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings AddPackages(this PnpmInstallSettings toolSettings, params string[] packages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal.AddRange(packages);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="PnpmInstallSettings.Packages"/>.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings AddPackages(this PnpmInstallSettings toolSettings, IEnumerable<string> packages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal.AddRange(packages);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="PnpmInstallSettings.Packages"/>.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings ClearPackages(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="PnpmInstallSettings.Packages"/>.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings RemovePackages(this PnpmInstallSettings toolSettings, params string[] packages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(packages);
            toolSettings.PackagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="PnpmInstallSettings.Packages"/>.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings RemovePackages(this PnpmInstallSettings toolSettings, IEnumerable<string> packages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(packages);
            toolSettings.PackagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Production
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.Production"/>.</em></p><p>Causes pnpm to not install modules listed in devDependencies.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetProduction(this PnpmInstallSettings toolSettings, bool? production)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = production;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.Production"/>.</em></p><p>Causes pnpm to not install modules listed in devDependencies.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetProduction(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PnpmInstallSettings.Production"/>.</em></p><p>Causes pnpm to not install modules listed in devDependencies.</p></summary>
        [Pure]
        public static PnpmInstallSettings EnableProduction(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PnpmInstallSettings.Production"/>.</em></p><p>Causes pnpm to not install modules listed in devDependencies.</p></summary>
        [Pure]
        public static PnpmInstallSettings DisableProduction(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PnpmInstallSettings.Production"/>.</em></p><p>Causes pnpm to not install modules listed in devDependencies.</p></summary>
        [Pure]
        public static PnpmInstallSettings ToggleProduction(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = !toolSettings.Production;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.Force"/>.</em></p><p>Forces pnpm to fetch remote resources even if a local copy exists on disk.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetForce(this PnpmInstallSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.Force"/>.</em></p><p>Forces pnpm to fetch remote resources even if a local copy exists on disk.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetForce(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PnpmInstallSettings.Force"/>.</em></p><p>Forces pnpm to fetch remote resources even if a local copy exists on disk.</p></summary>
        [Pure]
        public static PnpmInstallSettings EnableForce(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PnpmInstallSettings.Force"/>.</em></p><p>Forces pnpm to fetch remote resources even if a local copy exists on disk.</p></summary>
        [Pure]
        public static PnpmInstallSettings DisableForce(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PnpmInstallSettings.Force"/>.</em></p><p>Forces pnpm to fetch remote resources even if a local copy exists on disk.</p></summary>
        [Pure]
        public static PnpmInstallSettings ToggleForce(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Global
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.Global"/>.</em></p><p>Causes pnpm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">pnpm-folders</a>.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetGlobal(this PnpmInstallSettings toolSettings, bool? global)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = global;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.Global"/>.</em></p><p>Causes pnpm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">pnpm-folders</a>.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetGlobal(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PnpmInstallSettings.Global"/>.</em></p><p>Causes pnpm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">pnpm-folders</a>.</p></summary>
        [Pure]
        public static PnpmInstallSettings EnableGlobal(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PnpmInstallSettings.Global"/>.</em></p><p>Causes pnpm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">pnpm-folders</a>.</p></summary>
        [Pure]
        public static PnpmInstallSettings DisableGlobal(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PnpmInstallSettings.Global"/>.</em></p><p>Causes pnpm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">pnpm-folders</a>.</p></summary>
        [Pure]
        public static PnpmInstallSettings ToggleGlobal(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = !toolSettings.Global;
            return toolSettings;
        }
        #endregion
        #region GlobalStyle
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.GlobalStyle"/>.</em></p><p>Causes pnpm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetGlobalStyle(this PnpmInstallSettings toolSettings, bool? globalStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = globalStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.GlobalStyle"/>.</em></p><p>Causes pnpm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetGlobalStyle(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PnpmInstallSettings.GlobalStyle"/>.</em></p><p>Causes pnpm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        [Pure]
        public static PnpmInstallSettings EnableGlobalStyle(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PnpmInstallSettings.GlobalStyle"/>.</em></p><p>Causes pnpm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        [Pure]
        public static PnpmInstallSettings DisableGlobalStyle(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PnpmInstallSettings.GlobalStyle"/>.</em></p><p>Causes pnpm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        [Pure]
        public static PnpmInstallSettings ToggleGlobalStyle(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = !toolSettings.GlobalStyle;
            return toolSettings;
        }
        #endregion
        #region IgnoreScripts
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.IgnoreScripts"/>.</em></p><p>Causes pnpm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">pnpm-scripts</a>.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetIgnoreScripts(this PnpmInstallSettings toolSettings, bool? ignoreScripts)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = ignoreScripts;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.IgnoreScripts"/>.</em></p><p>Causes pnpm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">pnpm-scripts</a>.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetIgnoreScripts(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PnpmInstallSettings.IgnoreScripts"/>.</em></p><p>Causes pnpm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">pnpm-scripts</a>.</p></summary>
        [Pure]
        public static PnpmInstallSettings EnableIgnoreScripts(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PnpmInstallSettings.IgnoreScripts"/>.</em></p><p>Causes pnpm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">pnpm-scripts</a>.</p></summary>
        [Pure]
        public static PnpmInstallSettings DisableIgnoreScripts(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PnpmInstallSettings.IgnoreScripts"/>.</em></p><p>Causes pnpm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">pnpm-scripts</a>.</p></summary>
        [Pure]
        public static PnpmInstallSettings ToggleIgnoreScripts(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = !toolSettings.IgnoreScripts;
            return toolSettings;
        }
        #endregion
        #region LegacyBundling
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.LegacyBundling"/>.</em></p><p>Causes pnpm to install the package such that versions of pnpm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetLegacyBundling(this PnpmInstallSettings toolSettings, bool? legacyBundling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = legacyBundling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.LegacyBundling"/>.</em></p><p>Causes pnpm to install the package such that versions of pnpm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetLegacyBundling(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PnpmInstallSettings.LegacyBundling"/>.</em></p><p>Causes pnpm to install the package such that versions of pnpm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        [Pure]
        public static PnpmInstallSettings EnableLegacyBundling(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PnpmInstallSettings.LegacyBundling"/>.</em></p><p>Causes pnpm to install the package such that versions of pnpm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        [Pure]
        public static PnpmInstallSettings DisableLegacyBundling(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PnpmInstallSettings.LegacyBundling"/>.</em></p><p>Causes pnpm to install the package such that versions of pnpm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        [Pure]
        public static PnpmInstallSettings ToggleLegacyBundling(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = !toolSettings.LegacyBundling;
            return toolSettings;
        }
        #endregion
        #region Link
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.Link"/>.</em></p><p>Cause pnpm to link global installs into the local space in some cases.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetLink(this PnpmInstallSettings toolSettings, bool? link)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = link;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.Link"/>.</em></p><p>Cause pnpm to link global installs into the local space in some cases.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetLink(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PnpmInstallSettings.Link"/>.</em></p><p>Cause pnpm to link global installs into the local space in some cases.</p></summary>
        [Pure]
        public static PnpmInstallSettings EnableLink(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PnpmInstallSettings.Link"/>.</em></p><p>Cause pnpm to link global installs into the local space in some cases.</p></summary>
        [Pure]
        public static PnpmInstallSettings DisableLink(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PnpmInstallSettings.Link"/>.</em></p><p>Cause pnpm to link global installs into the local space in some cases.</p></summary>
        [Pure]
        public static PnpmInstallSettings ToggleLink(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = !toolSettings.Link;
            return toolSettings;
        }
        #endregion
        #region NoBinLinks
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.NoBinLinks"/>.</em></p><p>Prevents pnpm from creating symlinks for any binaries the package might contain.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetNoBinLinks(this PnpmInstallSettings toolSettings, bool? noBinLinks)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = noBinLinks;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.NoBinLinks"/>.</em></p><p>Prevents pnpm from creating symlinks for any binaries the package might contain.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetNoBinLinks(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PnpmInstallSettings.NoBinLinks"/>.</em></p><p>Prevents pnpm from creating symlinks for any binaries the package might contain.</p></summary>
        [Pure]
        public static PnpmInstallSettings EnableNoBinLinks(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PnpmInstallSettings.NoBinLinks"/>.</em></p><p>Prevents pnpm from creating symlinks for any binaries the package might contain.</p></summary>
        [Pure]
        public static PnpmInstallSettings DisableNoBinLinks(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PnpmInstallSettings.NoBinLinks"/>.</em></p><p>Prevents pnpm from creating symlinks for any binaries the package might contain.</p></summary>
        [Pure]
        public static PnpmInstallSettings ToggleNoBinLinks(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = !toolSettings.NoBinLinks;
            return toolSettings;
        }
        #endregion
        #region NoOptional
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.NoOptional"/>.</em></p><p>Prevents optional dependencies from being installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetNoOptional(this PnpmInstallSettings toolSettings, bool? noOptional)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = noOptional;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.NoOptional"/>.</em></p><p>Prevents optional dependencies from being installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetNoOptional(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PnpmInstallSettings.NoOptional"/>.</em></p><p>Prevents optional dependencies from being installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings EnableNoOptional(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PnpmInstallSettings.NoOptional"/>.</em></p><p>Prevents optional dependencies from being installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings DisableNoOptional(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PnpmInstallSettings.NoOptional"/>.</em></p><p>Prevents optional dependencies from being installed.</p></summary>
        [Pure]
        public static PnpmInstallSettings ToggleNoOptional(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = !toolSettings.NoOptional;
            return toolSettings;
        }
        #endregion
        #region NoShrinkWrap
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.NoShrinkWrap"/>.</em></p><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetNoShrinkWrap(this PnpmInstallSettings toolSettings, bool? noShrinkWrap)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = noShrinkWrap;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.NoShrinkWrap"/>.</em></p><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetNoShrinkWrap(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="PnpmInstallSettings.NoShrinkWrap"/>.</em></p><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        [Pure]
        public static PnpmInstallSettings EnableNoShrinkWrap(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="PnpmInstallSettings.NoShrinkWrap"/>.</em></p><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        [Pure]
        public static PnpmInstallSettings DisableNoShrinkWrap(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="PnpmInstallSettings.NoShrinkWrap"/>.</em></p><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        [Pure]
        public static PnpmInstallSettings ToggleNoShrinkWrap(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = !toolSettings.NoShrinkWrap;
            return toolSettings;
        }
        #endregion
        #region NodeDir
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.NodeDir"/>.</em></p><p>Allows pnpm to find the node source code so that pnpm can compile native modules.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetNodeDir(this PnpmInstallSettings toolSettings, string nodeDir)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeDir = nodeDir;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.NodeDir"/>.</em></p><p>Allows pnpm to find the node source code so that pnpm can compile native modules.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetNodeDir(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeDir = null;
            return toolSettings;
        }
        #endregion
        #region Only
        /// <summary><p><em>Sets <see cref="PnpmInstallSettings.Only"/>.</em></p><p>Causes either only <c>devDependencies</c> or only non-<c>devDependencies</c> to be installed regardless of the <c>NODE_ENV</c>.</p></summary>
        [Pure]
        public static PnpmInstallSettings SetOnly(this PnpmInstallSettings toolSettings, NpmOnlyMode only)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Only = only;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmInstallSettings.Only"/>.</em></p><p>Causes either only <c>devDependencies</c> or only non-<c>devDependencies</c> to be installed regardless of the <c>NODE_ENV</c>.</p></summary>
        [Pure]
        public static PnpmInstallSettings ResetOnly(this PnpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Only = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region PnpmRunSettingsExtensions
    /// <summary><p>Used within <see cref="PnpmTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PnpmRunSettingsExtensions
    {
        #region Command
        /// <summary><p><em>Sets <see cref="PnpmRunSettings.Command"/>.</em></p><p>The command to be executed.</p></summary>
        [Pure]
        public static PnpmRunSettings SetCommand(this PnpmRunSettings toolSettings, string command)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="PnpmRunSettings.Command"/>.</em></p><p>The command to be executed.</p></summary>
        [Pure]
        public static PnpmRunSettings ResetCommand(this PnpmRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = null;
            return toolSettings;
        }
        #endregion
        #region Arguments
        /// <summary><p><em>Sets <see cref="PnpmRunSettings.Arguments"/> to a new list.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static PnpmRunSettings SetArguments(this PnpmRunSettings toolSettings, params string[] arguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal = arguments.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="PnpmRunSettings.Arguments"/> to a new list.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static PnpmRunSettings SetArguments(this PnpmRunSettings toolSettings, IEnumerable<string> arguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal = arguments.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="PnpmRunSettings.Arguments"/>.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static PnpmRunSettings AddArguments(this PnpmRunSettings toolSettings, params string[] arguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.AddRange(arguments);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="PnpmRunSettings.Arguments"/>.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static PnpmRunSettings AddArguments(this PnpmRunSettings toolSettings, IEnumerable<string> arguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.AddRange(arguments);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="PnpmRunSettings.Arguments"/>.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static PnpmRunSettings ClearArguments(this PnpmRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="PnpmRunSettings.Arguments"/>.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static PnpmRunSettings RemoveArguments(this PnpmRunSettings toolSettings, params string[] arguments)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(arguments);
            toolSettings.ArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="PnpmRunSettings.Arguments"/>.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static PnpmRunSettings RemoveArguments(this PnpmRunSettings toolSettings, IEnumerable<string> arguments)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(arguments);
            toolSettings.ArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NpmOnlyMode
    /// <summary><p>Used within <see cref="PnpmTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public partial class NpmOnlyMode : Enumeration
    {
        public static NpmOnlyMode production = new NpmOnlyMode { Value = "production" };
        public static NpmOnlyMode development = new NpmOnlyMode { Value = "development" };
    }
    #endregion
}
