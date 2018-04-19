// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, LOCAL VERSION.
// Generated from https://github.com/nuke-build/tools/blob/master/metadata/Npm.json.

using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Npm
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NpmTasks
    {
        /// <summary><p>Path to the Npm executable.</p></summary>
        public static string NpmPath => ToolPathResolver.GetPathExecutable("npm");
        static partial void PreProcess(NpmInstallSettings toolSettings);
        static partial void PostProcess(NpmInstallSettings toolSettings);
        /// <summary><p>Installs a package, and any packages that it depends on. If the package has a package-lock or shrinkwrap file, the installation of dependencies will be driven by that, with an <b>npm-shrinkwrap.json</b> taking precedence if both files exist. See <a href="https://docs.npmjs.com/files/package-lock.json">package-lock.json</a> and <a href="https://docs.npmjs.com/cli/shrinkwrap">npm-shrinkwrap</a>.<para/>A package is: <ul><li>a) A folder containing a program described by a <a href="https://docs.npmjs.com/files/package.json">package.json file</a></li><li>b) A gzipped tarball containing (b)</li><li>c) A url that resolves to (b)</li><li>d) a <c>&lt;name&gt;@&lt;version&gt;</c> that is published on the registry (see <a href="https://docs.npmjs.com/misc/registry">npm-registry</a>) with (c)</li><li>e) a <c>&lt;name&gt;@&lt;tag&gt;</c> (see <a href="https://docs.npmjs.com/cli/dist-tag">npm-dist-tag</a>) that points to (d)</li><li>f) a <c>&lt;name&gt;</c> that has a "latest" tag satisfying (e)</li><li>g) a <c>&lt;git remote url&gt;</c> that resolves to (a)</li></ul></p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
        public static void NpmInstall(Configure<NpmInstallSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NpmInstallSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NpmRunSettings toolSettings);
        static partial void PostProcess(NpmRunSettings toolSettings);
        /// <summary><p>Runs an arbitrary command from a package's <c>"scripts"</c> object. If no <c>"command"</c> is provided, it will list the available scripts. <c>run[-script]</c> is used by the test, start, restart, and stop commands, but can be called directly, as well. When the scripts in the package are printed out, they're separated into lifecycle (test, start, restart) and directly-run scripts."</p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
        public static void NpmRun(Configure<NpmRunSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NpmRunSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
    }
    #region NpmInstallSettings
    /// <summary><p>Used within <see cref="NpmTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NpmInstallSettings : ToolSettings
    {
        /// <summary><p>Path to the Npm executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? NpmTasks.NpmPath;
        /// <summary><p>List of packages to be installed.</p></summary>
        public virtual IReadOnlyList<string> Packages => PackagesInternal.AsReadOnly();
        internal List<string> PackagesInternal { get; set; } = new List<string>();
        /// <summary><p>Causes npm to not install modules listed in devDependencies.</p></summary>
        public virtual bool? Production { get; internal set; }
        /// <summary><p>Forces npm to fetch remote resources even if a local copy exists on disk.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p></summary>
        public virtual bool? Global { get; internal set; }
        /// <summary><p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        public virtual bool? GlobalStyle { get; internal set; }
        /// <summary><p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p></summary>
        public virtual bool? IgnoreScripts { get; internal set; }
        /// <summary><p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        public virtual bool? LegacyBundling { get; internal set; }
        /// <summary><p>Cause npm to link global installs into the local space in some cases.</p></summary>
        public virtual bool? Link { get; internal set; }
        /// <summary><p>Prevents npm from creating symlinks for any binaries the package might contain.</p></summary>
        public virtual bool? NoBinLinks { get; internal set; }
        /// <summary><p>Prevents optional dependencies from being installed.</p></summary>
        public virtual bool? NoOptional { get; internal set; }
        /// <summary><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        public virtual bool? NoShrinkWrap { get; internal set; }
        /// <summary><p>Allows npm to find the node source code so that npm can compile native modules.</p></summary>
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
    #region NpmRunSettings
    /// <summary><p>Used within <see cref="NpmTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NpmRunSettings : ToolSettings
    {
        /// <summary><p>Path to the Npm executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? NpmTasks.NpmPath;
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
    #region NpmInstallSettingsExtensions
    /// <summary><p>Used within <see cref="NpmTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NpmInstallSettingsExtensions
    {
        #region Packages
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.Packages"/> to a new list.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static NpmInstallSettings SetPackages(this NpmInstallSettings toolSettings, params string[] packages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal = packages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.Packages"/> to a new list.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static NpmInstallSettings SetPackages(this NpmInstallSettings toolSettings, IEnumerable<string> packages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal = packages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NpmInstallSettings.Packages"/>.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static NpmInstallSettings AddPackages(this NpmInstallSettings toolSettings, params string[] packages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal.AddRange(packages);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NpmInstallSettings.Packages"/>.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static NpmInstallSettings AddPackages(this NpmInstallSettings toolSettings, IEnumerable<string> packages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal.AddRange(packages);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NpmInstallSettings.Packages"/>.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static NpmInstallSettings ClearPackages(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NpmInstallSettings.Packages"/>.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static NpmInstallSettings RemovePackages(this NpmInstallSettings toolSettings, params string[] packages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(packages);
            toolSettings.PackagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NpmInstallSettings.Packages"/>.</em></p><p>List of packages to be installed.</p></summary>
        [Pure]
        public static NpmInstallSettings RemovePackages(this NpmInstallSettings toolSettings, IEnumerable<string> packages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(packages);
            toolSettings.PackagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Production
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.Production"/>.</em></p><p>Causes npm to not install modules listed in devDependencies.</p></summary>
        [Pure]
        public static NpmInstallSettings SetProduction(this NpmInstallSettings toolSettings, bool? production)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = production;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.Production"/>.</em></p><p>Causes npm to not install modules listed in devDependencies.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetProduction(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NpmInstallSettings.Production"/>.</em></p><p>Causes npm to not install modules listed in devDependencies.</p></summary>
        [Pure]
        public static NpmInstallSettings EnableProduction(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NpmInstallSettings.Production"/>.</em></p><p>Causes npm to not install modules listed in devDependencies.</p></summary>
        [Pure]
        public static NpmInstallSettings DisableProduction(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NpmInstallSettings.Production"/>.</em></p><p>Causes npm to not install modules listed in devDependencies.</p></summary>
        [Pure]
        public static NpmInstallSettings ToggleProduction(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = !toolSettings.Production;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.Force"/>.</em></p><p>Forces npm to fetch remote resources even if a local copy exists on disk.</p></summary>
        [Pure]
        public static NpmInstallSettings SetForce(this NpmInstallSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.Force"/>.</em></p><p>Forces npm to fetch remote resources even if a local copy exists on disk.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetForce(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NpmInstallSettings.Force"/>.</em></p><p>Forces npm to fetch remote resources even if a local copy exists on disk.</p></summary>
        [Pure]
        public static NpmInstallSettings EnableForce(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NpmInstallSettings.Force"/>.</em></p><p>Forces npm to fetch remote resources even if a local copy exists on disk.</p></summary>
        [Pure]
        public static NpmInstallSettings DisableForce(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NpmInstallSettings.Force"/>.</em></p><p>Forces npm to fetch remote resources even if a local copy exists on disk.</p></summary>
        [Pure]
        public static NpmInstallSettings ToggleForce(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Global
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.Global"/>.</em></p><p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p></summary>
        [Pure]
        public static NpmInstallSettings SetGlobal(this NpmInstallSettings toolSettings, bool? global)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = global;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.Global"/>.</em></p><p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetGlobal(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NpmInstallSettings.Global"/>.</em></p><p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p></summary>
        [Pure]
        public static NpmInstallSettings EnableGlobal(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NpmInstallSettings.Global"/>.</em></p><p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p></summary>
        [Pure]
        public static NpmInstallSettings DisableGlobal(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NpmInstallSettings.Global"/>.</em></p><p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p></summary>
        [Pure]
        public static NpmInstallSettings ToggleGlobal(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = !toolSettings.Global;
            return toolSettings;
        }
        #endregion
        #region GlobalStyle
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.GlobalStyle"/>.</em></p><p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        [Pure]
        public static NpmInstallSettings SetGlobalStyle(this NpmInstallSettings toolSettings, bool? globalStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = globalStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.GlobalStyle"/>.</em></p><p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetGlobalStyle(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NpmInstallSettings.GlobalStyle"/>.</em></p><p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        [Pure]
        public static NpmInstallSettings EnableGlobalStyle(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NpmInstallSettings.GlobalStyle"/>.</em></p><p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        [Pure]
        public static NpmInstallSettings DisableGlobalStyle(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NpmInstallSettings.GlobalStyle"/>.</em></p><p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p></summary>
        [Pure]
        public static NpmInstallSettings ToggleGlobalStyle(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = !toolSettings.GlobalStyle;
            return toolSettings;
        }
        #endregion
        #region IgnoreScripts
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.IgnoreScripts"/>.</em></p><p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p></summary>
        [Pure]
        public static NpmInstallSettings SetIgnoreScripts(this NpmInstallSettings toolSettings, bool? ignoreScripts)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = ignoreScripts;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.IgnoreScripts"/>.</em></p><p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetIgnoreScripts(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NpmInstallSettings.IgnoreScripts"/>.</em></p><p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p></summary>
        [Pure]
        public static NpmInstallSettings EnableIgnoreScripts(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NpmInstallSettings.IgnoreScripts"/>.</em></p><p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p></summary>
        [Pure]
        public static NpmInstallSettings DisableIgnoreScripts(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NpmInstallSettings.IgnoreScripts"/>.</em></p><p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p></summary>
        [Pure]
        public static NpmInstallSettings ToggleIgnoreScripts(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = !toolSettings.IgnoreScripts;
            return toolSettings;
        }
        #endregion
        #region LegacyBundling
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.LegacyBundling"/>.</em></p><p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        [Pure]
        public static NpmInstallSettings SetLegacyBundling(this NpmInstallSettings toolSettings, bool? legacyBundling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = legacyBundling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.LegacyBundling"/>.</em></p><p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetLegacyBundling(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NpmInstallSettings.LegacyBundling"/>.</em></p><p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        [Pure]
        public static NpmInstallSettings EnableLegacyBundling(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NpmInstallSettings.LegacyBundling"/>.</em></p><p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        [Pure]
        public static NpmInstallSettings DisableLegacyBundling(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NpmInstallSettings.LegacyBundling"/>.</em></p><p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p></summary>
        [Pure]
        public static NpmInstallSettings ToggleLegacyBundling(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = !toolSettings.LegacyBundling;
            return toolSettings;
        }
        #endregion
        #region Link
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.Link"/>.</em></p><p>Cause npm to link global installs into the local space in some cases.</p></summary>
        [Pure]
        public static NpmInstallSettings SetLink(this NpmInstallSettings toolSettings, bool? link)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = link;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.Link"/>.</em></p><p>Cause npm to link global installs into the local space in some cases.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetLink(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NpmInstallSettings.Link"/>.</em></p><p>Cause npm to link global installs into the local space in some cases.</p></summary>
        [Pure]
        public static NpmInstallSettings EnableLink(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NpmInstallSettings.Link"/>.</em></p><p>Cause npm to link global installs into the local space in some cases.</p></summary>
        [Pure]
        public static NpmInstallSettings DisableLink(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NpmInstallSettings.Link"/>.</em></p><p>Cause npm to link global installs into the local space in some cases.</p></summary>
        [Pure]
        public static NpmInstallSettings ToggleLink(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = !toolSettings.Link;
            return toolSettings;
        }
        #endregion
        #region NoBinLinks
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.NoBinLinks"/>.</em></p><p>Prevents npm from creating symlinks for any binaries the package might contain.</p></summary>
        [Pure]
        public static NpmInstallSettings SetNoBinLinks(this NpmInstallSettings toolSettings, bool? noBinLinks)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = noBinLinks;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.NoBinLinks"/>.</em></p><p>Prevents npm from creating symlinks for any binaries the package might contain.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetNoBinLinks(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NpmInstallSettings.NoBinLinks"/>.</em></p><p>Prevents npm from creating symlinks for any binaries the package might contain.</p></summary>
        [Pure]
        public static NpmInstallSettings EnableNoBinLinks(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NpmInstallSettings.NoBinLinks"/>.</em></p><p>Prevents npm from creating symlinks for any binaries the package might contain.</p></summary>
        [Pure]
        public static NpmInstallSettings DisableNoBinLinks(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NpmInstallSettings.NoBinLinks"/>.</em></p><p>Prevents npm from creating symlinks for any binaries the package might contain.</p></summary>
        [Pure]
        public static NpmInstallSettings ToggleNoBinLinks(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = !toolSettings.NoBinLinks;
            return toolSettings;
        }
        #endregion
        #region NoOptional
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.NoOptional"/>.</em></p><p>Prevents optional dependencies from being installed.</p></summary>
        [Pure]
        public static NpmInstallSettings SetNoOptional(this NpmInstallSettings toolSettings, bool? noOptional)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = noOptional;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.NoOptional"/>.</em></p><p>Prevents optional dependencies from being installed.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetNoOptional(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NpmInstallSettings.NoOptional"/>.</em></p><p>Prevents optional dependencies from being installed.</p></summary>
        [Pure]
        public static NpmInstallSettings EnableNoOptional(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NpmInstallSettings.NoOptional"/>.</em></p><p>Prevents optional dependencies from being installed.</p></summary>
        [Pure]
        public static NpmInstallSettings DisableNoOptional(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NpmInstallSettings.NoOptional"/>.</em></p><p>Prevents optional dependencies from being installed.</p></summary>
        [Pure]
        public static NpmInstallSettings ToggleNoOptional(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = !toolSettings.NoOptional;
            return toolSettings;
        }
        #endregion
        #region NoShrinkWrap
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.NoShrinkWrap"/>.</em></p><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        [Pure]
        public static NpmInstallSettings SetNoShrinkWrap(this NpmInstallSettings toolSettings, bool? noShrinkWrap)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = noShrinkWrap;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.NoShrinkWrap"/>.</em></p><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetNoShrinkWrap(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NpmInstallSettings.NoShrinkWrap"/>.</em></p><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        [Pure]
        public static NpmInstallSettings EnableNoShrinkWrap(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NpmInstallSettings.NoShrinkWrap"/>.</em></p><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        [Pure]
        public static NpmInstallSettings DisableNoShrinkWrap(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NpmInstallSettings.NoShrinkWrap"/>.</em></p><p>Ignores an available shrinkwrap file and use the package.json instead.</p></summary>
        [Pure]
        public static NpmInstallSettings ToggleNoShrinkWrap(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = !toolSettings.NoShrinkWrap;
            return toolSettings;
        }
        #endregion
        #region NodeDir
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.NodeDir"/>.</em></p><p>Allows npm to find the node source code so that npm can compile native modules.</p></summary>
        [Pure]
        public static NpmInstallSettings SetNodeDir(this NpmInstallSettings toolSettings, string nodeDir)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeDir = nodeDir;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.NodeDir"/>.</em></p><p>Allows npm to find the node source code so that npm can compile native modules.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetNodeDir(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeDir = null;
            return toolSettings;
        }
        #endregion
        #region Only
        /// <summary><p><em>Sets <see cref="NpmInstallSettings.Only"/>.</em></p><p>Causes either only <c>devDependencies</c> or only non-<c>devDependencies</c> to be installed regardless of the <c>NODE_ENV</c>.</p></summary>
        [Pure]
        public static NpmInstallSettings SetOnly(this NpmInstallSettings toolSettings, NpmOnlyMode only)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Only = only;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmInstallSettings.Only"/>.</em></p><p>Causes either only <c>devDependencies</c> or only non-<c>devDependencies</c> to be installed regardless of the <c>NODE_ENV</c>.</p></summary>
        [Pure]
        public static NpmInstallSettings ResetOnly(this NpmInstallSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Only = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NpmRunSettingsExtensions
    /// <summary><p>Used within <see cref="NpmTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NpmRunSettingsExtensions
    {
        #region Command
        /// <summary><p><em>Sets <see cref="NpmRunSettings.Command"/>.</em></p><p>The command to be executed.</p></summary>
        [Pure]
        public static NpmRunSettings SetCommand(this NpmRunSettings toolSettings, string command)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NpmRunSettings.Command"/>.</em></p><p>The command to be executed.</p></summary>
        [Pure]
        public static NpmRunSettings ResetCommand(this NpmRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = null;
            return toolSettings;
        }
        #endregion
        #region Arguments
        /// <summary><p><em>Sets <see cref="NpmRunSettings.Arguments"/> to a new list.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static NpmRunSettings SetArguments(this NpmRunSettings toolSettings, params string[] arguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal = arguments.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NpmRunSettings.Arguments"/> to a new list.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static NpmRunSettings SetArguments(this NpmRunSettings toolSettings, IEnumerable<string> arguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal = arguments.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NpmRunSettings.Arguments"/>.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static NpmRunSettings AddArguments(this NpmRunSettings toolSettings, params string[] arguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.AddRange(arguments);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NpmRunSettings.Arguments"/>.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static NpmRunSettings AddArguments(this NpmRunSettings toolSettings, IEnumerable<string> arguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.AddRange(arguments);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NpmRunSettings.Arguments"/>.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static NpmRunSettings ClearArguments(this NpmRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NpmRunSettings.Arguments"/>.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static NpmRunSettings RemoveArguments(this NpmRunSettings toolSettings, params string[] arguments)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(arguments);
            toolSettings.ArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NpmRunSettings.Arguments"/>.</em></p><p>Arguments passed to the script.</p></summary>
        [Pure]
        public static NpmRunSettings RemoveArguments(this NpmRunSettings toolSettings, IEnumerable<string> arguments)
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
    /// <summary><p>Used within <see cref="NpmTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class NpmOnlyMode : Enumeration
    {
        public static NpmOnlyMode production = new NpmOnlyMode { Value = "production" };
        public static NpmOnlyMode development = new NpmOnlyMode { Value = "development" };
    }
    #endregion
}
