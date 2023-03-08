// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Npm/Npm.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Npm
{
    /// <summary>
    ///   <p>npm is the package manager for the Node JavaScript platform. It puts modules in place so that node can find them, and manages dependency conflicts intelligently.<para/>It is extremely configurable to support a wide variety of use cases. Most commonly, it is used to publish, discover, install, and develop node programs.</p>
    ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [PathToolRequirement(NpmPathExecutable)]
    public partial class NpmTasks
        : IRequirePathTool
    {
        public const string NpmPathExecutable = "npm";
        /// <summary>
        ///   Path to the Npm executable.
        /// </summary>
        public static string NpmPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("NPM_EXE") ??
            ToolPathResolver.GetPathExecutable("npm");
        public static Action<OutputType, string> NpmLogger { get; set; } = CustomLogger;
        /// <summary>
        ///   <p>npm is the package manager for the Node JavaScript platform. It puts modules in place so that node can find them, and manages dependency conflicts intelligently.<para/>It is extremely configurable to support a wide variety of use cases. Most commonly, it is used to publish, discover, install, and develop node programs.</p>
        ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Npm(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(NpmPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? NpmLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Install a project with a clean slate. This command is similar to <a href="https://docs.npmjs.com/cli/install.html">npm install</a>, except it's meant to be used in automated environments such as test platforms, continuous integration, and deployment or any situation where you want to make sure you're doing a clean install of your dependencies. It can be significantly faster than a regular npm install by skipping certain user-oriented features. It is also more strict than a regular install, which can help catch errors or inconsistencies caused by the incrementally-installed local environments of most npm users.<p>In short, the main differences between using <b>npm install</b> and <b>npm ci</b> are:</p><ul><li>The project <b>must</b> have an existing <b>package-lock.json</b> or <b>npm-shrinkwrap.json</b>.</li><li>If dependencies in the package lock do not match those in <b>package.json</b>, <b>npm ci</b> will exit with an error, instead of updating the package lock.</li><li><b>npm ci</b> can only install entire projects at a time: individual dependencies cannot be added with this command.</li><li>If a <b>node_modules</b> is already present, it will be automatically removed before <b>npm ci</b> begins its install.</li><li>It will never write to <b>package.json</b> or any of the package-locks: installs are essentially frozen.</li></ul></p>
        ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        /// </remarks>
        public static IReadOnlyCollection<Output> NpmCi(NpmCiSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NpmCiSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Install a project with a clean slate. This command is similar to <a href="https://docs.npmjs.com/cli/install.html">npm install</a>, except it's meant to be used in automated environments such as test platforms, continuous integration, and deployment or any situation where you want to make sure you're doing a clean install of your dependencies. It can be significantly faster than a regular npm install by skipping certain user-oriented features. It is also more strict than a regular install, which can help catch errors or inconsistencies caused by the incrementally-installed local environments of most npm users.<p>In short, the main differences between using <b>npm install</b> and <b>npm ci</b> are:</p><ul><li>The project <b>must</b> have an existing <b>package-lock.json</b> or <b>npm-shrinkwrap.json</b>.</li><li>If dependencies in the package lock do not match those in <b>package.json</b>, <b>npm ci</b> will exit with an error, instead of updating the package lock.</li><li><b>npm ci</b> can only install entire projects at a time: individual dependencies cannot be added with this command.</li><li>If a <b>node_modules</b> is already present, it will be automatically removed before <b>npm ci</b> begins its install.</li><li>It will never write to <b>package.json</b> or any of the package-locks: installs are essentially frozen.</li></ul></p>
        ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        /// </remarks>
        public static IReadOnlyCollection<Output> NpmCi(Configure<NpmCiSettings> configurator)
        {
            return NpmCi(configurator(new NpmCiSettings()));
        }
        /// <summary>
        ///   <p>Install a project with a clean slate. This command is similar to <a href="https://docs.npmjs.com/cli/install.html">npm install</a>, except it's meant to be used in automated environments such as test platforms, continuous integration, and deployment or any situation where you want to make sure you're doing a clean install of your dependencies. It can be significantly faster than a regular npm install by skipping certain user-oriented features. It is also more strict than a regular install, which can help catch errors or inconsistencies caused by the incrementally-installed local environments of most npm users.<p>In short, the main differences between using <b>npm install</b> and <b>npm ci</b> are:</p><ul><li>The project <b>must</b> have an existing <b>package-lock.json</b> or <b>npm-shrinkwrap.json</b>.</li><li>If dependencies in the package lock do not match those in <b>package.json</b>, <b>npm ci</b> will exit with an error, instead of updating the package lock.</li><li><b>npm ci</b> can only install entire projects at a time: individual dependencies cannot be added with this command.</li><li>If a <b>node_modules</b> is already present, it will be automatically removed before <b>npm ci</b> begins its install.</li><li>It will never write to <b>package.json</b> or any of the package-locks: installs are essentially frozen.</li></ul></p>
        ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        /// </remarks>
        public static IEnumerable<(NpmCiSettings Settings, IReadOnlyCollection<Output> Output)> NpmCi(CombinatorialConfigure<NpmCiSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NpmCi, NpmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Installs a package, and any packages that it depends on. If the package has a package-lock or shrinkwrap file, the installation of dependencies will be driven by that, with an <b>npm-shrinkwrap.json</b> taking precedence if both files exist. See <a href="https://docs.npmjs.com/files/package-lock.json">package-lock.json</a> and <a href="https://docs.npmjs.com/cli/shrinkwrap">npm-shrinkwrap</a>.<para/>A package is: <ul><li>a) A folder containing a program described by a <a href="https://docs.npmjs.com/files/package.json">package.json file</a></li><li>b) A gzipped tarball containing (b)</li><li>c) A url that resolves to (b)</li><li>d) a <c>&lt;name&gt;@&lt;version&gt;</c> that is published on the registry (see <a href="https://docs.npmjs.com/misc/registry">npm-registry</a>) with (c)</li><li>e) a <c>&lt;name&gt;@&lt;tag&gt;</c> (see <a href="https://docs.npmjs.com/cli/dist-tag">npm-dist-tag</a>) that points to (d)</li><li>f) a <c>&lt;name&gt;</c> that has a "latest" tag satisfying (e)</li><li>g) a <c>&lt;git remote url&gt;</c> that resolves to (a)</li></ul></p>
        ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packages&gt;</c> via <see cref="NpmInstallSettings.Packages"/></li>
        ///     <li><c>--force</c> via <see cref="NpmInstallSettings.Force"/></li>
        ///     <li><c>--global</c> via <see cref="NpmInstallSettings.Global"/></li>
        ///     <li><c>--global-style</c> via <see cref="NpmInstallSettings.GlobalStyle"/></li>
        ///     <li><c>--ignore-scripts</c> via <see cref="NpmInstallSettings.IgnoreScripts"/></li>
        ///     <li><c>--legacy-bundling</c> via <see cref="NpmInstallSettings.LegacyBundling"/></li>
        ///     <li><c>--link</c> via <see cref="NpmInstallSettings.Link"/></li>
        ///     <li><c>--no-bin-links</c> via <see cref="NpmInstallSettings.NoBinLinks"/></li>
        ///     <li><c>--no-optional</c> via <see cref="NpmInstallSettings.NoOptional"/></li>
        ///     <li><c>--no-shrinkwrap</c> via <see cref="NpmInstallSettings.NoShrinkWrap"/></li>
        ///     <li><c>--nodedir</c> via <see cref="NpmInstallSettings.NodeDir"/></li>
        ///     <li><c>--only</c> via <see cref="NpmInstallSettings.Only"/></li>
        ///     <li><c>--production</c> via <see cref="NpmInstallSettings.Production"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NpmInstall(NpmInstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NpmInstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Installs a package, and any packages that it depends on. If the package has a package-lock or shrinkwrap file, the installation of dependencies will be driven by that, with an <b>npm-shrinkwrap.json</b> taking precedence if both files exist. See <a href="https://docs.npmjs.com/files/package-lock.json">package-lock.json</a> and <a href="https://docs.npmjs.com/cli/shrinkwrap">npm-shrinkwrap</a>.<para/>A package is: <ul><li>a) A folder containing a program described by a <a href="https://docs.npmjs.com/files/package.json">package.json file</a></li><li>b) A gzipped tarball containing (b)</li><li>c) A url that resolves to (b)</li><li>d) a <c>&lt;name&gt;@&lt;version&gt;</c> that is published on the registry (see <a href="https://docs.npmjs.com/misc/registry">npm-registry</a>) with (c)</li><li>e) a <c>&lt;name&gt;@&lt;tag&gt;</c> (see <a href="https://docs.npmjs.com/cli/dist-tag">npm-dist-tag</a>) that points to (d)</li><li>f) a <c>&lt;name&gt;</c> that has a "latest" tag satisfying (e)</li><li>g) a <c>&lt;git remote url&gt;</c> that resolves to (a)</li></ul></p>
        ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packages&gt;</c> via <see cref="NpmInstallSettings.Packages"/></li>
        ///     <li><c>--force</c> via <see cref="NpmInstallSettings.Force"/></li>
        ///     <li><c>--global</c> via <see cref="NpmInstallSettings.Global"/></li>
        ///     <li><c>--global-style</c> via <see cref="NpmInstallSettings.GlobalStyle"/></li>
        ///     <li><c>--ignore-scripts</c> via <see cref="NpmInstallSettings.IgnoreScripts"/></li>
        ///     <li><c>--legacy-bundling</c> via <see cref="NpmInstallSettings.LegacyBundling"/></li>
        ///     <li><c>--link</c> via <see cref="NpmInstallSettings.Link"/></li>
        ///     <li><c>--no-bin-links</c> via <see cref="NpmInstallSettings.NoBinLinks"/></li>
        ///     <li><c>--no-optional</c> via <see cref="NpmInstallSettings.NoOptional"/></li>
        ///     <li><c>--no-shrinkwrap</c> via <see cref="NpmInstallSettings.NoShrinkWrap"/></li>
        ///     <li><c>--nodedir</c> via <see cref="NpmInstallSettings.NodeDir"/></li>
        ///     <li><c>--only</c> via <see cref="NpmInstallSettings.Only"/></li>
        ///     <li><c>--production</c> via <see cref="NpmInstallSettings.Production"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NpmInstall(Configure<NpmInstallSettings> configurator)
        {
            return NpmInstall(configurator(new NpmInstallSettings()));
        }
        /// <summary>
        ///   <p>Installs a package, and any packages that it depends on. If the package has a package-lock or shrinkwrap file, the installation of dependencies will be driven by that, with an <b>npm-shrinkwrap.json</b> taking precedence if both files exist. See <a href="https://docs.npmjs.com/files/package-lock.json">package-lock.json</a> and <a href="https://docs.npmjs.com/cli/shrinkwrap">npm-shrinkwrap</a>.<para/>A package is: <ul><li>a) A folder containing a program described by a <a href="https://docs.npmjs.com/files/package.json">package.json file</a></li><li>b) A gzipped tarball containing (b)</li><li>c) A url that resolves to (b)</li><li>d) a <c>&lt;name&gt;@&lt;version&gt;</c> that is published on the registry (see <a href="https://docs.npmjs.com/misc/registry">npm-registry</a>) with (c)</li><li>e) a <c>&lt;name&gt;@&lt;tag&gt;</c> (see <a href="https://docs.npmjs.com/cli/dist-tag">npm-dist-tag</a>) that points to (d)</li><li>f) a <c>&lt;name&gt;</c> that has a "latest" tag satisfying (e)</li><li>g) a <c>&lt;git remote url&gt;</c> that resolves to (a)</li></ul></p>
        ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packages&gt;</c> via <see cref="NpmInstallSettings.Packages"/></li>
        ///     <li><c>--force</c> via <see cref="NpmInstallSettings.Force"/></li>
        ///     <li><c>--global</c> via <see cref="NpmInstallSettings.Global"/></li>
        ///     <li><c>--global-style</c> via <see cref="NpmInstallSettings.GlobalStyle"/></li>
        ///     <li><c>--ignore-scripts</c> via <see cref="NpmInstallSettings.IgnoreScripts"/></li>
        ///     <li><c>--legacy-bundling</c> via <see cref="NpmInstallSettings.LegacyBundling"/></li>
        ///     <li><c>--link</c> via <see cref="NpmInstallSettings.Link"/></li>
        ///     <li><c>--no-bin-links</c> via <see cref="NpmInstallSettings.NoBinLinks"/></li>
        ///     <li><c>--no-optional</c> via <see cref="NpmInstallSettings.NoOptional"/></li>
        ///     <li><c>--no-shrinkwrap</c> via <see cref="NpmInstallSettings.NoShrinkWrap"/></li>
        ///     <li><c>--nodedir</c> via <see cref="NpmInstallSettings.NodeDir"/></li>
        ///     <li><c>--only</c> via <see cref="NpmInstallSettings.Only"/></li>
        ///     <li><c>--production</c> via <see cref="NpmInstallSettings.Production"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NpmInstallSettings Settings, IReadOnlyCollection<Output> Output)> NpmInstall(CombinatorialConfigure<NpmInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NpmInstall, NpmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Runs an arbitrary command from a package's <c>"scripts"</c> object. If no <c>"command"</c> is provided, it will list the available scripts. <c>run[-script]</c> is used by the test, start, restart, and stop commands, but can be called directly, as well. When the scripts in the package are printed out, they're separated into lifecycle (test, start, restart) and directly-run scripts."</p>
        ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;command&gt;</c> via <see cref="NpmRunSettings.Command"/></li>
        ///     <li><c>--</c> via <see cref="NpmRunSettings.Arguments"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NpmRun(NpmRunSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NpmRunSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Runs an arbitrary command from a package's <c>"scripts"</c> object. If no <c>"command"</c> is provided, it will list the available scripts. <c>run[-script]</c> is used by the test, start, restart, and stop commands, but can be called directly, as well. When the scripts in the package are printed out, they're separated into lifecycle (test, start, restart) and directly-run scripts."</p>
        ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;command&gt;</c> via <see cref="NpmRunSettings.Command"/></li>
        ///     <li><c>--</c> via <see cref="NpmRunSettings.Arguments"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NpmRun(Configure<NpmRunSettings> configurator)
        {
            return NpmRun(configurator(new NpmRunSettings()));
        }
        /// <summary>
        ///   <p>Runs an arbitrary command from a package's <c>"scripts"</c> object. If no <c>"command"</c> is provided, it will list the available scripts. <c>run[-script]</c> is used by the test, start, restart, and stop commands, but can be called directly, as well. When the scripts in the package are printed out, they're separated into lifecycle (test, start, restart) and directly-run scripts."</p>
        ///   <p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;command&gt;</c> via <see cref="NpmRunSettings.Command"/></li>
        ///     <li><c>--</c> via <see cref="NpmRunSettings.Arguments"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NpmRunSettings Settings, IReadOnlyCollection<Output> Output)> NpmRun(CombinatorialConfigure<NpmRunSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NpmRun, NpmLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region NpmCiSettings
    /// <summary>
    ///   Used within <see cref="NpmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NpmCiSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Npm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NpmTasks.NpmPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NpmTasks.NpmLogger;
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("ci");
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NpmInstallSettings
    /// <summary>
    ///   Used within <see cref="NpmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NpmInstallSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Npm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NpmTasks.NpmPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NpmTasks.NpmLogger;
        /// <summary>
        ///   List of packages to be installed.
        /// </summary>
        public virtual IReadOnlyList<string> Packages => PackagesInternal.AsReadOnly();
        internal List<string> PackagesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Causes npm to not install modules listed in devDependencies.
        /// </summary>
        public virtual bool? Production { get; internal set; }
        /// <summary>
        ///   Forces npm to fetch remote resources even if a local copy exists on disk.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.
        /// </summary>
        public virtual bool? Global { get; internal set; }
        /// <summary>
        ///   Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.
        /// </summary>
        public virtual bool? GlobalStyle { get; internal set; }
        /// <summary>
        ///   Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.
        /// </summary>
        public virtual bool? IgnoreScripts { get; internal set; }
        /// <summary>
        ///   Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.
        /// </summary>
        public virtual bool? LegacyBundling { get; internal set; }
        /// <summary>
        ///   Cause npm to link global installs into the local space in some cases.
        /// </summary>
        public virtual bool? Link { get; internal set; }
        /// <summary>
        ///   Prevents npm from creating symlinks for any binaries the package might contain.
        /// </summary>
        public virtual bool? NoBinLinks { get; internal set; }
        /// <summary>
        ///   Prevents optional dependencies from being installed.
        /// </summary>
        public virtual bool? NoOptional { get; internal set; }
        /// <summary>
        ///   Ignores an available shrinkwrap file and use the package.json instead.
        /// </summary>
        public virtual bool? NoShrinkWrap { get; internal set; }
        /// <summary>
        ///   Allows npm to find the node source code so that npm can compile native modules.
        /// </summary>
        public virtual string NodeDir { get; internal set; }
        /// <summary>
        ///   Causes either only <c>devDependencies</c> or only non-<c>devDependencies</c> to be installed regardless of the <c>NODE_ENV</c>.
        /// </summary>
        public virtual NpmOnlyMode Only { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
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
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NpmRunSettings
    /// <summary>
    ///   Used within <see cref="NpmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NpmRunSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Npm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NpmTasks.NpmPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NpmTasks.NpmLogger;
        /// <summary>
        ///   The command to be executed.
        /// </summary>
        public virtual string Command { get; internal set; }
        /// <summary>
        ///   Arguments passed to the script.
        /// </summary>
        public virtual IReadOnlyList<string> Arguments => ArgumentsInternal.AsReadOnly();
        internal List<string> ArgumentsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("run")
              .Add("{value}", Command)
              .Add("-- {value}", Arguments, separator: ' ');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NpmCiSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NpmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NpmCiSettingsExtensions
    {
    }
    #endregion
    #region NpmInstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NpmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NpmInstallSettingsExtensions
    {
        #region Packages
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.Packages"/> to a new list</em></p>
        ///   <p>List of packages to be installed.</p>
        /// </summary>
        [Pure]
        public static T SetPackages<T>(this T toolSettings, params string[] packages) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal = packages.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.Packages"/> to a new list</em></p>
        ///   <p>List of packages to be installed.</p>
        /// </summary>
        [Pure]
        public static T SetPackages<T>(this T toolSettings, IEnumerable<string> packages) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal = packages.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NpmInstallSettings.Packages"/></em></p>
        ///   <p>List of packages to be installed.</p>
        /// </summary>
        [Pure]
        public static T AddPackages<T>(this T toolSettings, params string[] packages) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal.AddRange(packages);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NpmInstallSettings.Packages"/></em></p>
        ///   <p>List of packages to be installed.</p>
        /// </summary>
        [Pure]
        public static T AddPackages<T>(this T toolSettings, IEnumerable<string> packages) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal.AddRange(packages);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NpmInstallSettings.Packages"/></em></p>
        ///   <p>List of packages to be installed.</p>
        /// </summary>
        [Pure]
        public static T ClearPackages<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NpmInstallSettings.Packages"/></em></p>
        ///   <p>List of packages to be installed.</p>
        /// </summary>
        [Pure]
        public static T RemovePackages<T>(this T toolSettings, params string[] packages) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(packages);
            toolSettings.PackagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NpmInstallSettings.Packages"/></em></p>
        ///   <p>List of packages to be installed.</p>
        /// </summary>
        [Pure]
        public static T RemovePackages<T>(this T toolSettings, IEnumerable<string> packages) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(packages);
            toolSettings.PackagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Production
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.Production"/></em></p>
        ///   <p>Causes npm to not install modules listed in devDependencies.</p>
        /// </summary>
        [Pure]
        public static T SetProduction<T>(this T toolSettings, bool? production) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = production;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.Production"/></em></p>
        ///   <p>Causes npm to not install modules listed in devDependencies.</p>
        /// </summary>
        [Pure]
        public static T ResetProduction<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NpmInstallSettings.Production"/></em></p>
        ///   <p>Causes npm to not install modules listed in devDependencies.</p>
        /// </summary>
        [Pure]
        public static T EnableProduction<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NpmInstallSettings.Production"/></em></p>
        ///   <p>Causes npm to not install modules listed in devDependencies.</p>
        /// </summary>
        [Pure]
        public static T DisableProduction<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NpmInstallSettings.Production"/></em></p>
        ///   <p>Causes npm to not install modules listed in devDependencies.</p>
        /// </summary>
        [Pure]
        public static T ToggleProduction<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = !toolSettings.Production;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.Force"/></em></p>
        ///   <p>Forces npm to fetch remote resources even if a local copy exists on disk.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.Force"/></em></p>
        ///   <p>Forces npm to fetch remote resources even if a local copy exists on disk.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NpmInstallSettings.Force"/></em></p>
        ///   <p>Forces npm to fetch remote resources even if a local copy exists on disk.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NpmInstallSettings.Force"/></em></p>
        ///   <p>Forces npm to fetch remote resources even if a local copy exists on disk.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NpmInstallSettings.Force"/></em></p>
        ///   <p>Forces npm to fetch remote resources even if a local copy exists on disk.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Global
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.Global"/></em></p>
        ///   <p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p>
        /// </summary>
        [Pure]
        public static T SetGlobal<T>(this T toolSettings, bool? global) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = global;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.Global"/></em></p>
        ///   <p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetGlobal<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NpmInstallSettings.Global"/></em></p>
        ///   <p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableGlobal<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NpmInstallSettings.Global"/></em></p>
        ///   <p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableGlobal<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NpmInstallSettings.Global"/></em></p>
        ///   <p>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleGlobal<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Global = !toolSettings.Global;
            return toolSettings;
        }
        #endregion
        #region GlobalStyle
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.GlobalStyle"/></em></p>
        ///   <p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p>
        /// </summary>
        [Pure]
        public static T SetGlobalStyle<T>(this T toolSettings, bool? globalStyle) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = globalStyle;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.GlobalStyle"/></em></p>
        ///   <p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p>
        /// </summary>
        [Pure]
        public static T ResetGlobalStyle<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NpmInstallSettings.GlobalStyle"/></em></p>
        ///   <p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p>
        /// </summary>
        [Pure]
        public static T EnableGlobalStyle<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NpmInstallSettings.GlobalStyle"/></em></p>
        ///   <p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p>
        /// </summary>
        [Pure]
        public static T DisableGlobalStyle<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NpmInstallSettings.GlobalStyle"/></em></p>
        ///   <p>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</p>
        /// </summary>
        [Pure]
        public static T ToggleGlobalStyle<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalStyle = !toolSettings.GlobalStyle;
            return toolSettings;
        }
        #endregion
        #region IgnoreScripts
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.IgnoreScripts"/></em></p>
        ///   <p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreScripts<T>(this T toolSettings, bool? ignoreScripts) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = ignoreScripts;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.IgnoreScripts"/></em></p>
        ///   <p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreScripts<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NpmInstallSettings.IgnoreScripts"/></em></p>
        ///   <p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreScripts<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NpmInstallSettings.IgnoreScripts"/></em></p>
        ///   <p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreScripts<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NpmInstallSettings.IgnoreScripts"/></em></p>
        ///   <p>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreScripts<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreScripts = !toolSettings.IgnoreScripts;
            return toolSettings;
        }
        #endregion
        #region LegacyBundling
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.LegacyBundling"/></em></p>
        ///   <p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p>
        /// </summary>
        [Pure]
        public static T SetLegacyBundling<T>(this T toolSettings, bool? legacyBundling) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = legacyBundling;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.LegacyBundling"/></em></p>
        ///   <p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p>
        /// </summary>
        [Pure]
        public static T ResetLegacyBundling<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NpmInstallSettings.LegacyBundling"/></em></p>
        ///   <p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p>
        /// </summary>
        [Pure]
        public static T EnableLegacyBundling<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NpmInstallSettings.LegacyBundling"/></em></p>
        ///   <p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p>
        /// </summary>
        [Pure]
        public static T DisableLegacyBundling<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NpmInstallSettings.LegacyBundling"/></em></p>
        ///   <p>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</p>
        /// </summary>
        [Pure]
        public static T ToggleLegacyBundling<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LegacyBundling = !toolSettings.LegacyBundling;
            return toolSettings;
        }
        #endregion
        #region Link
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.Link"/></em></p>
        ///   <p>Cause npm to link global installs into the local space in some cases.</p>
        /// </summary>
        [Pure]
        public static T SetLink<T>(this T toolSettings, bool? link) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = link;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.Link"/></em></p>
        ///   <p>Cause npm to link global installs into the local space in some cases.</p>
        /// </summary>
        [Pure]
        public static T ResetLink<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NpmInstallSettings.Link"/></em></p>
        ///   <p>Cause npm to link global installs into the local space in some cases.</p>
        /// </summary>
        [Pure]
        public static T EnableLink<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NpmInstallSettings.Link"/></em></p>
        ///   <p>Cause npm to link global installs into the local space in some cases.</p>
        /// </summary>
        [Pure]
        public static T DisableLink<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NpmInstallSettings.Link"/></em></p>
        ///   <p>Cause npm to link global installs into the local space in some cases.</p>
        /// </summary>
        [Pure]
        public static T ToggleLink<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Link = !toolSettings.Link;
            return toolSettings;
        }
        #endregion
        #region NoBinLinks
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.NoBinLinks"/></em></p>
        ///   <p>Prevents npm from creating symlinks for any binaries the package might contain.</p>
        /// </summary>
        [Pure]
        public static T SetNoBinLinks<T>(this T toolSettings, bool? noBinLinks) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = noBinLinks;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.NoBinLinks"/></em></p>
        ///   <p>Prevents npm from creating symlinks for any binaries the package might contain.</p>
        /// </summary>
        [Pure]
        public static T ResetNoBinLinks<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NpmInstallSettings.NoBinLinks"/></em></p>
        ///   <p>Prevents npm from creating symlinks for any binaries the package might contain.</p>
        /// </summary>
        [Pure]
        public static T EnableNoBinLinks<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NpmInstallSettings.NoBinLinks"/></em></p>
        ///   <p>Prevents npm from creating symlinks for any binaries the package might contain.</p>
        /// </summary>
        [Pure]
        public static T DisableNoBinLinks<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NpmInstallSettings.NoBinLinks"/></em></p>
        ///   <p>Prevents npm from creating symlinks for any binaries the package might contain.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoBinLinks<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBinLinks = !toolSettings.NoBinLinks;
            return toolSettings;
        }
        #endregion
        #region NoOptional
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.NoOptional"/></em></p>
        ///   <p>Prevents optional dependencies from being installed.</p>
        /// </summary>
        [Pure]
        public static T SetNoOptional<T>(this T toolSettings, bool? noOptional) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = noOptional;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.NoOptional"/></em></p>
        ///   <p>Prevents optional dependencies from being installed.</p>
        /// </summary>
        [Pure]
        public static T ResetNoOptional<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NpmInstallSettings.NoOptional"/></em></p>
        ///   <p>Prevents optional dependencies from being installed.</p>
        /// </summary>
        [Pure]
        public static T EnableNoOptional<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NpmInstallSettings.NoOptional"/></em></p>
        ///   <p>Prevents optional dependencies from being installed.</p>
        /// </summary>
        [Pure]
        public static T DisableNoOptional<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NpmInstallSettings.NoOptional"/></em></p>
        ///   <p>Prevents optional dependencies from being installed.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoOptional<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOptional = !toolSettings.NoOptional;
            return toolSettings;
        }
        #endregion
        #region NoShrinkWrap
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.NoShrinkWrap"/></em></p>
        ///   <p>Ignores an available shrinkwrap file and use the package.json instead.</p>
        /// </summary>
        [Pure]
        public static T SetNoShrinkWrap<T>(this T toolSettings, bool? noShrinkWrap) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = noShrinkWrap;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.NoShrinkWrap"/></em></p>
        ///   <p>Ignores an available shrinkwrap file and use the package.json instead.</p>
        /// </summary>
        [Pure]
        public static T ResetNoShrinkWrap<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NpmInstallSettings.NoShrinkWrap"/></em></p>
        ///   <p>Ignores an available shrinkwrap file and use the package.json instead.</p>
        /// </summary>
        [Pure]
        public static T EnableNoShrinkWrap<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NpmInstallSettings.NoShrinkWrap"/></em></p>
        ///   <p>Ignores an available shrinkwrap file and use the package.json instead.</p>
        /// </summary>
        [Pure]
        public static T DisableNoShrinkWrap<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NpmInstallSettings.NoShrinkWrap"/></em></p>
        ///   <p>Ignores an available shrinkwrap file and use the package.json instead.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoShrinkWrap<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoShrinkWrap = !toolSettings.NoShrinkWrap;
            return toolSettings;
        }
        #endregion
        #region NodeDir
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.NodeDir"/></em></p>
        ///   <p>Allows npm to find the node source code so that npm can compile native modules.</p>
        /// </summary>
        [Pure]
        public static T SetNodeDir<T>(this T toolSettings, string nodeDir) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeDir = nodeDir;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.NodeDir"/></em></p>
        ///   <p>Allows npm to find the node source code so that npm can compile native modules.</p>
        /// </summary>
        [Pure]
        public static T ResetNodeDir<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NodeDir = null;
            return toolSettings;
        }
        #endregion
        #region Only
        /// <summary>
        ///   <p><em>Sets <see cref="NpmInstallSettings.Only"/></em></p>
        ///   <p>Causes either only <c>devDependencies</c> or only non-<c>devDependencies</c> to be installed regardless of the <c>NODE_ENV</c>.</p>
        /// </summary>
        [Pure]
        public static T SetOnly<T>(this T toolSettings, NpmOnlyMode only) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Only = only;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmInstallSettings.Only"/></em></p>
        ///   <p>Causes either only <c>devDependencies</c> or only non-<c>devDependencies</c> to be installed regardless of the <c>NODE_ENV</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetOnly<T>(this T toolSettings) where T : NpmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Only = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NpmRunSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NpmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NpmRunSettingsExtensions
    {
        #region Command
        /// <summary>
        ///   <p><em>Sets <see cref="NpmRunSettings.Command"/></em></p>
        ///   <p>The command to be executed.</p>
        /// </summary>
        [Pure]
        public static T SetCommand<T>(this T toolSettings, string command) where T : NpmRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NpmRunSettings.Command"/></em></p>
        ///   <p>The command to be executed.</p>
        /// </summary>
        [Pure]
        public static T ResetCommand<T>(this T toolSettings) where T : NpmRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = null;
            return toolSettings;
        }
        #endregion
        #region Arguments
        /// <summary>
        ///   <p><em>Sets <see cref="NpmRunSettings.Arguments"/> to a new list</em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T SetArguments<T>(this T toolSettings, params string[] arguments) where T : NpmRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal = arguments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NpmRunSettings.Arguments"/> to a new list</em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T SetArguments<T>(this T toolSettings, IEnumerable<string> arguments) where T : NpmRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal = arguments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NpmRunSettings.Arguments"/></em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T AddArguments<T>(this T toolSettings, params string[] arguments) where T : NpmRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.AddRange(arguments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NpmRunSettings.Arguments"/></em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T AddArguments<T>(this T toolSettings, IEnumerable<string> arguments) where T : NpmRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.AddRange(arguments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NpmRunSettings.Arguments"/></em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T ClearArguments<T>(this T toolSettings) where T : NpmRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NpmRunSettings.Arguments"/></em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T RemoveArguments<T>(this T toolSettings, params string[] arguments) where T : NpmRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(arguments);
            toolSettings.ArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NpmRunSettings.Arguments"/></em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T RemoveArguments<T>(this T toolSettings, IEnumerable<string> arguments) where T : NpmRunSettings
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
    /// <summary>
    ///   Used within <see cref="NpmTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<NpmOnlyMode>))]
    public partial class NpmOnlyMode : Enumeration
    {
        public static NpmOnlyMode production = (NpmOnlyMode) "production";
        public static NpmOnlyMode development = (NpmOnlyMode) "development";
        public static implicit operator NpmOnlyMode(string value)
        {
            return new NpmOnlyMode { Value = value };
        }
    }
    #endregion
}
