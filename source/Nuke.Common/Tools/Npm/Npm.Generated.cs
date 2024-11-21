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

namespace Nuke.Common.Tools.Npm;

/// <summary><p>npm is the package manager for the Node JavaScript platform. It puts modules in place so that node can find them, and manages dependency conflicts intelligently.<para/>It is extremely configurable to support a wide variety of use cases. Most commonly, it is used to publish, discover, install, and develop node programs.</p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathToolRequirement(PathExecutable)]
[PathTool(Executable = PathExecutable)]
public partial class NpmTasks : ToolTasks, IRequirePathTool
{
    public static string NpmPath => new NpmTasks().GetToolPath();
    public const string PathExecutable = "npm";
    /// <summary><p>npm is the package manager for the Node JavaScript platform. It puts modules in place so that node can find them, and manages dependency conflicts intelligently.<para/>It is extremely configurable to support a wide variety of use cases. Most commonly, it is used to publish, discover, install, and develop node programs.</p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Npm(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new NpmTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Install a project with a clean slate. This command is similar to <a href="https://docs.npmjs.com/cli/install.html">npm install</a>, except it's meant to be used in automated environments such as test platforms, continuous integration, and deployment or any situation where you want to make sure you're doing a clean install of your dependencies. It can be significantly faster than a regular npm install by skipping certain user-oriented features. It is also more strict than a regular install, which can help catch errors or inconsistencies caused by the incrementally-installed local environments of most npm users.<p>In short, the main differences between using <b>npm install</b> and <b>npm ci</b> are:</p><ul><li>The project <b>must</b> have an existing <b>package-lock.json</b> or <b>npm-shrinkwrap.json</b>.</li><li>If dependencies in the package lock do not match those in <b>package.json</b>, <b>npm ci</b> will exit with an error, instead of updating the package lock.</li><li><b>npm ci</b> can only install entire projects at a time: individual dependencies cannot be added with this command.</li><li>If a <b>node_modules</b> is already present, it will be automatically removed before <b>npm ci</b> begins its install.</li><li>It will never write to <b>package.json</b> or any of the package-locks: installs are essentially frozen.</li></ul></p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p></remarks>
    public static IReadOnlyCollection<Output> NpmCi(NpmCiSettings options = null) => new NpmTasks().Run(options);
    /// <summary><p>Install a project with a clean slate. This command is similar to <a href="https://docs.npmjs.com/cli/install.html">npm install</a>, except it's meant to be used in automated environments such as test platforms, continuous integration, and deployment or any situation where you want to make sure you're doing a clean install of your dependencies. It can be significantly faster than a regular npm install by skipping certain user-oriented features. It is also more strict than a regular install, which can help catch errors or inconsistencies caused by the incrementally-installed local environments of most npm users.<p>In short, the main differences between using <b>npm install</b> and <b>npm ci</b> are:</p><ul><li>The project <b>must</b> have an existing <b>package-lock.json</b> or <b>npm-shrinkwrap.json</b>.</li><li>If dependencies in the package lock do not match those in <b>package.json</b>, <b>npm ci</b> will exit with an error, instead of updating the package lock.</li><li><b>npm ci</b> can only install entire projects at a time: individual dependencies cannot be added with this command.</li><li>If a <b>node_modules</b> is already present, it will be automatically removed before <b>npm ci</b> begins its install.</li><li>It will never write to <b>package.json</b> or any of the package-locks: installs are essentially frozen.</li></ul></p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p></remarks>
    public static IReadOnlyCollection<Output> NpmCi(Configure<NpmCiSettings> configurator) => new NpmTasks().Run(configurator.Invoke(new NpmCiSettings()));
    /// <summary><p>Install a project with a clean slate. This command is similar to <a href="https://docs.npmjs.com/cli/install.html">npm install</a>, except it's meant to be used in automated environments such as test platforms, continuous integration, and deployment or any situation where you want to make sure you're doing a clean install of your dependencies. It can be significantly faster than a regular npm install by skipping certain user-oriented features. It is also more strict than a regular install, which can help catch errors or inconsistencies caused by the incrementally-installed local environments of most npm users.<p>In short, the main differences between using <b>npm install</b> and <b>npm ci</b> are:</p><ul><li>The project <b>must</b> have an existing <b>package-lock.json</b> or <b>npm-shrinkwrap.json</b>.</li><li>If dependencies in the package lock do not match those in <b>package.json</b>, <b>npm ci</b> will exit with an error, instead of updating the package lock.</li><li><b>npm ci</b> can only install entire projects at a time: individual dependencies cannot be added with this command.</li><li>If a <b>node_modules</b> is already present, it will be automatically removed before <b>npm ci</b> begins its install.</li><li>It will never write to <b>package.json</b> or any of the package-locks: installs are essentially frozen.</li></ul></p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p></remarks>
    public static IEnumerable<(NpmCiSettings Settings, IReadOnlyCollection<Output> Output)> NpmCi(CombinatorialConfigure<NpmCiSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NpmCi, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Installs a package, and any packages that it depends on. If the package has a package-lock or shrinkwrap file, the installation of dependencies will be driven by that, with an <b>npm-shrinkwrap.json</b> taking precedence if both files exist. See <a href="https://docs.npmjs.com/files/package-lock.json">package-lock.json</a> and <a href="https://docs.npmjs.com/cli/shrinkwrap">npm-shrinkwrap</a>.<para/>A package is: <ul><li>a) A folder containing a program described by a <a href="https://docs.npmjs.com/files/package.json">package.json file</a></li><li>b) A gzipped tarball containing (b)</li><li>c) A url that resolves to (b)</li><li>d) a <c>&lt;name&gt;@&lt;version&gt;</c> that is published on the registry (see <a href="https://docs.npmjs.com/misc/registry">npm-registry</a>) with (c)</li><li>e) a <c>&lt;name&gt;@&lt;tag&gt;</c> (see <a href="https://docs.npmjs.com/cli/dist-tag">npm-dist-tag</a>) that points to (d)</li><li>f) a <c>&lt;name&gt;</c> that has a "latest" tag satisfying (e)</li><li>g) a <c>&lt;git remote url&gt;</c> that resolves to (a)</li></ul></p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;packages&gt;</c> via <see cref="NpmInstallSettings.Packages"/></li><li><c>--force</c> via <see cref="NpmInstallSettings.Force"/></li><li><c>--global</c> via <see cref="NpmInstallSettings.Global"/></li><li><c>--global-style</c> via <see cref="NpmInstallSettings.GlobalStyle"/></li><li><c>--ignore-scripts</c> via <see cref="NpmInstallSettings.IgnoreScripts"/></li><li><c>--legacy-bundling</c> via <see cref="NpmInstallSettings.LegacyBundling"/></li><li><c>--link</c> via <see cref="NpmInstallSettings.Link"/></li><li><c>--no-bin-links</c> via <see cref="NpmInstallSettings.NoBinLinks"/></li><li><c>--no-optional</c> via <see cref="NpmInstallSettings.NoOptional"/></li><li><c>--no-shrinkwrap</c> via <see cref="NpmInstallSettings.NoShrinkWrap"/></li><li><c>--nodedir</c> via <see cref="NpmInstallSettings.NodeDir"/></li><li><c>--only</c> via <see cref="NpmInstallSettings.Only"/></li><li><c>--production</c> via <see cref="NpmInstallSettings.Production"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NpmInstall(NpmInstallSettings options = null) => new NpmTasks().Run(options);
    /// <summary><p>Installs a package, and any packages that it depends on. If the package has a package-lock or shrinkwrap file, the installation of dependencies will be driven by that, with an <b>npm-shrinkwrap.json</b> taking precedence if both files exist. See <a href="https://docs.npmjs.com/files/package-lock.json">package-lock.json</a> and <a href="https://docs.npmjs.com/cli/shrinkwrap">npm-shrinkwrap</a>.<para/>A package is: <ul><li>a) A folder containing a program described by a <a href="https://docs.npmjs.com/files/package.json">package.json file</a></li><li>b) A gzipped tarball containing (b)</li><li>c) A url that resolves to (b)</li><li>d) a <c>&lt;name&gt;@&lt;version&gt;</c> that is published on the registry (see <a href="https://docs.npmjs.com/misc/registry">npm-registry</a>) with (c)</li><li>e) a <c>&lt;name&gt;@&lt;tag&gt;</c> (see <a href="https://docs.npmjs.com/cli/dist-tag">npm-dist-tag</a>) that points to (d)</li><li>f) a <c>&lt;name&gt;</c> that has a "latest" tag satisfying (e)</li><li>g) a <c>&lt;git remote url&gt;</c> that resolves to (a)</li></ul></p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;packages&gt;</c> via <see cref="NpmInstallSettings.Packages"/></li><li><c>--force</c> via <see cref="NpmInstallSettings.Force"/></li><li><c>--global</c> via <see cref="NpmInstallSettings.Global"/></li><li><c>--global-style</c> via <see cref="NpmInstallSettings.GlobalStyle"/></li><li><c>--ignore-scripts</c> via <see cref="NpmInstallSettings.IgnoreScripts"/></li><li><c>--legacy-bundling</c> via <see cref="NpmInstallSettings.LegacyBundling"/></li><li><c>--link</c> via <see cref="NpmInstallSettings.Link"/></li><li><c>--no-bin-links</c> via <see cref="NpmInstallSettings.NoBinLinks"/></li><li><c>--no-optional</c> via <see cref="NpmInstallSettings.NoOptional"/></li><li><c>--no-shrinkwrap</c> via <see cref="NpmInstallSettings.NoShrinkWrap"/></li><li><c>--nodedir</c> via <see cref="NpmInstallSettings.NodeDir"/></li><li><c>--only</c> via <see cref="NpmInstallSettings.Only"/></li><li><c>--production</c> via <see cref="NpmInstallSettings.Production"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NpmInstall(Configure<NpmInstallSettings> configurator) => new NpmTasks().Run(configurator.Invoke(new NpmInstallSettings()));
    /// <summary><p>Installs a package, and any packages that it depends on. If the package has a package-lock or shrinkwrap file, the installation of dependencies will be driven by that, with an <b>npm-shrinkwrap.json</b> taking precedence if both files exist. See <a href="https://docs.npmjs.com/files/package-lock.json">package-lock.json</a> and <a href="https://docs.npmjs.com/cli/shrinkwrap">npm-shrinkwrap</a>.<para/>A package is: <ul><li>a) A folder containing a program described by a <a href="https://docs.npmjs.com/files/package.json">package.json file</a></li><li>b) A gzipped tarball containing (b)</li><li>c) A url that resolves to (b)</li><li>d) a <c>&lt;name&gt;@&lt;version&gt;</c> that is published on the registry (see <a href="https://docs.npmjs.com/misc/registry">npm-registry</a>) with (c)</li><li>e) a <c>&lt;name&gt;@&lt;tag&gt;</c> (see <a href="https://docs.npmjs.com/cli/dist-tag">npm-dist-tag</a>) that points to (d)</li><li>f) a <c>&lt;name&gt;</c> that has a "latest" tag satisfying (e)</li><li>g) a <c>&lt;git remote url&gt;</c> that resolves to (a)</li></ul></p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;packages&gt;</c> via <see cref="NpmInstallSettings.Packages"/></li><li><c>--force</c> via <see cref="NpmInstallSettings.Force"/></li><li><c>--global</c> via <see cref="NpmInstallSettings.Global"/></li><li><c>--global-style</c> via <see cref="NpmInstallSettings.GlobalStyle"/></li><li><c>--ignore-scripts</c> via <see cref="NpmInstallSettings.IgnoreScripts"/></li><li><c>--legacy-bundling</c> via <see cref="NpmInstallSettings.LegacyBundling"/></li><li><c>--link</c> via <see cref="NpmInstallSettings.Link"/></li><li><c>--no-bin-links</c> via <see cref="NpmInstallSettings.NoBinLinks"/></li><li><c>--no-optional</c> via <see cref="NpmInstallSettings.NoOptional"/></li><li><c>--no-shrinkwrap</c> via <see cref="NpmInstallSettings.NoShrinkWrap"/></li><li><c>--nodedir</c> via <see cref="NpmInstallSettings.NodeDir"/></li><li><c>--only</c> via <see cref="NpmInstallSettings.Only"/></li><li><c>--production</c> via <see cref="NpmInstallSettings.Production"/></li></ul></remarks>
    public static IEnumerable<(NpmInstallSettings Settings, IReadOnlyCollection<Output> Output)> NpmInstall(CombinatorialConfigure<NpmInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NpmInstall, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Runs an arbitrary command from a package's <c>"scripts"</c> object. If no <c>"command"</c> is provided, it will list the available scripts. <c>run[-script]</c> is used by the test, start, restart, and stop commands, but can be called directly, as well. When the scripts in the package are printed out, they're separated into lifecycle (test, start, restart) and directly-run scripts."</p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;command&gt;</c> via <see cref="NpmRunSettings.Command"/></li><li><c>--</c> via <see cref="NpmRunSettings.Arguments"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NpmRun(NpmRunSettings options = null) => new NpmTasks().Run(options);
    /// <summary><p>Runs an arbitrary command from a package's <c>"scripts"</c> object. If no <c>"command"</c> is provided, it will list the available scripts. <c>run[-script]</c> is used by the test, start, restart, and stop commands, but can be called directly, as well. When the scripts in the package are printed out, they're separated into lifecycle (test, start, restart) and directly-run scripts."</p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;command&gt;</c> via <see cref="NpmRunSettings.Command"/></li><li><c>--</c> via <see cref="NpmRunSettings.Arguments"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NpmRun(Configure<NpmRunSettings> configurator) => new NpmTasks().Run(configurator.Invoke(new NpmRunSettings()));
    /// <summary><p>Runs an arbitrary command from a package's <c>"scripts"</c> object. If no <c>"command"</c> is provided, it will list the available scripts. <c>run[-script]</c> is used by the test, start, restart, and stop commands, but can be called directly, as well. When the scripts in the package are printed out, they're separated into lifecycle (test, start, restart) and directly-run scripts."</p><p>For more details, visit the <a href="https://www.npmjs.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;command&gt;</c> via <see cref="NpmRunSettings.Command"/></li><li><c>--</c> via <see cref="NpmRunSettings.Arguments"/></li></ul></remarks>
    public static IEnumerable<(NpmRunSettings Settings, IReadOnlyCollection<Output> Output)> NpmRun(CombinatorialConfigure<NpmRunSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NpmRun, degreeOfParallelism, completeOnFailure);
}
#region NpmCiSettings
/// <summary>Used within <see cref="NpmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NpmCiSettings>))]
[Command(Type = typeof(NpmTasks), Command = nameof(NpmTasks.NpmCi), Arguments = "ci")]
public partial class NpmCiSettings : ToolOptions
{
}
#endregion
#region NpmInstallSettings
/// <summary>Used within <see cref="NpmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NpmInstallSettings>))]
[Command(Type = typeof(NpmTasks), Command = nameof(NpmTasks.NpmInstall), Arguments = "install")]
public partial class NpmInstallSettings : ToolOptions
{
    /// <summary>List of packages to be installed.</summary>
    [Argument(Format = "{value}", Position = 1)] public IReadOnlyList<string> Packages => Get<List<string>>(() => Packages);
    /// <summary>Causes npm to not install modules listed in devDependencies.</summary>
    [Argument(Format = "--production")] public bool? Production => Get<bool?>(() => Production);
    /// <summary>Forces npm to fetch remote resources even if a local copy exists on disk.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Causes npm to install the package globally rather than locally. See <a href="https://docs.npmjs.com/files/folders">npm-folders</a>.</summary>
    [Argument(Format = "--global")] public bool? Global => Get<bool?>(() => Global);
    /// <summary>Causes npm to install the package into your local <c>node_modules</c> folder with the same layout it uses with the global <c>node_modules</c> folder. Only your direct dependencies will show in <c>node_modules</c> and everything they depend on will be flattened in their <c>node_modules</c> folders. This obviously will eliminate some deduping.</summary>
    [Argument(Format = "--global-style")] public bool? GlobalStyle => Get<bool?>(() => GlobalStyle);
    /// <summary>Causes npm to not execute any scripts defined in the package.json. See <a href="https://docs.npmjs.com/misc/scripts">npm-scripts</a>.</summary>
    [Argument(Format = "--ignore-scripts")] public bool? IgnoreScripts => Get<bool?>(() => IgnoreScripts);
    /// <summary>Causes npm to install the package such that versions of npm prior to 1.4, such as the one included with node 0.8, can install the package. This eliminates all automatic deduping.</summary>
    [Argument(Format = "--legacy-bundling")] public bool? LegacyBundling => Get<bool?>(() => LegacyBundling);
    /// <summary>Cause npm to link global installs into the local space in some cases.</summary>
    [Argument(Format = "--link")] public bool? Link => Get<bool?>(() => Link);
    /// <summary>Prevents npm from creating symlinks for any binaries the package might contain.</summary>
    [Argument(Format = "--no-bin-links")] public bool? NoBinLinks => Get<bool?>(() => NoBinLinks);
    /// <summary>Prevents optional dependencies from being installed.</summary>
    [Argument(Format = "--no-optional")] public bool? NoOptional => Get<bool?>(() => NoOptional);
    /// <summary>Ignores an available shrinkwrap file and use the package.json instead.</summary>
    [Argument(Format = "--no-shrinkwrap")] public bool? NoShrinkWrap => Get<bool?>(() => NoShrinkWrap);
    /// <summary>Allows npm to find the node source code so that npm can compile native modules.</summary>
    [Argument(Format = "--nodedir={value}")] public string NodeDir => Get<string>(() => NodeDir);
    /// <summary>Causes either only <c>devDependencies</c> or only non-<c>devDependencies</c> to be installed regardless of the <c>NODE_ENV</c>.</summary>
    [Argument(Format = "--only={value}")] public NpmOnlyMode Only => Get<NpmOnlyMode>(() => Only);
}
#endregion
#region NpmRunSettings
/// <summary>Used within <see cref="NpmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NpmRunSettings>))]
[Command(Type = typeof(NpmTasks), Command = nameof(NpmTasks.NpmRun), Arguments = "run")]
public partial class NpmRunSettings : ToolOptions
{
    /// <summary>The command to be executed.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Command => Get<string>(() => Command);
    /// <summary>Arguments passed to the script.</summary>
    [Argument(Format = "-- {value}", Position = -1, Separator = " ")] public IReadOnlyList<string> Arguments => Get<List<string>>(() => Arguments);
}
#endregion
#region NpmCiSettingsExtensions
/// <summary>Used within <see cref="NpmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NpmCiSettingsExtensions
{
}
#endregion
#region NpmInstallSettingsExtensions
/// <summary>Used within <see cref="NpmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NpmInstallSettingsExtensions
{
    #region Packages
    /// <inheritdoc cref="NpmInstallSettings.Packages"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Packages))]
    public static T SetPackages<T>(this T o, params string[] v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Packages, v));
    /// <inheritdoc cref="NpmInstallSettings.Packages"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Packages))]
    public static T SetPackages<T>(this T o, IEnumerable<string> v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Packages, v));
    /// <inheritdoc cref="NpmInstallSettings.Packages"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Packages))]
    public static T AddPackages<T>(this T o, params string[] v) where T : NpmInstallSettings => o.Modify(b => b.AddCollection(() => o.Packages, v));
    /// <inheritdoc cref="NpmInstallSettings.Packages"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Packages))]
    public static T AddPackages<T>(this T o, IEnumerable<string> v) where T : NpmInstallSettings => o.Modify(b => b.AddCollection(() => o.Packages, v));
    /// <inheritdoc cref="NpmInstallSettings.Packages"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Packages))]
    public static T RemovePackages<T>(this T o, params string[] v) where T : NpmInstallSettings => o.Modify(b => b.RemoveCollection(() => o.Packages, v));
    /// <inheritdoc cref="NpmInstallSettings.Packages"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Packages))]
    public static T RemovePackages<T>(this T o, IEnumerable<string> v) where T : NpmInstallSettings => o.Modify(b => b.RemoveCollection(() => o.Packages, v));
    /// <inheritdoc cref="NpmInstallSettings.Packages"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Packages))]
    public static T ClearPackages<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.ClearCollection(() => o.Packages));
    #endregion
    #region Production
    /// <inheritdoc cref="NpmInstallSettings.Production"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Production))]
    public static T SetProduction<T>(this T o, bool? v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Production, v));
    /// <inheritdoc cref="NpmInstallSettings.Production"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Production))]
    public static T ResetProduction<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.Production));
    /// <inheritdoc cref="NpmInstallSettings.Production"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Production))]
    public static T EnableProduction<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Production, true));
    /// <inheritdoc cref="NpmInstallSettings.Production"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Production))]
    public static T DisableProduction<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Production, false));
    /// <inheritdoc cref="NpmInstallSettings.Production"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Production))]
    public static T ToggleProduction<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Production, !o.Production));
    #endregion
    #region Force
    /// <inheritdoc cref="NpmInstallSettings.Force"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="NpmInstallSettings.Force"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Force))]
    public static T ResetForce<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="NpmInstallSettings.Force"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Force))]
    public static T EnableForce<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="NpmInstallSettings.Force"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Force))]
    public static T DisableForce<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="NpmInstallSettings.Force"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region Global
    /// <inheritdoc cref="NpmInstallSettings.Global"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Global))]
    public static T SetGlobal<T>(this T o, bool? v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Global, v));
    /// <inheritdoc cref="NpmInstallSettings.Global"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Global))]
    public static T ResetGlobal<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.Global));
    /// <inheritdoc cref="NpmInstallSettings.Global"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Global))]
    public static T EnableGlobal<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Global, true));
    /// <inheritdoc cref="NpmInstallSettings.Global"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Global))]
    public static T DisableGlobal<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Global, false));
    /// <inheritdoc cref="NpmInstallSettings.Global"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Global))]
    public static T ToggleGlobal<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Global, !o.Global));
    #endregion
    #region GlobalStyle
    /// <inheritdoc cref="NpmInstallSettings.GlobalStyle"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.GlobalStyle))]
    public static T SetGlobalStyle<T>(this T o, bool? v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.GlobalStyle, v));
    /// <inheritdoc cref="NpmInstallSettings.GlobalStyle"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.GlobalStyle))]
    public static T ResetGlobalStyle<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.GlobalStyle));
    /// <inheritdoc cref="NpmInstallSettings.GlobalStyle"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.GlobalStyle))]
    public static T EnableGlobalStyle<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.GlobalStyle, true));
    /// <inheritdoc cref="NpmInstallSettings.GlobalStyle"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.GlobalStyle))]
    public static T DisableGlobalStyle<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.GlobalStyle, false));
    /// <inheritdoc cref="NpmInstallSettings.GlobalStyle"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.GlobalStyle))]
    public static T ToggleGlobalStyle<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.GlobalStyle, !o.GlobalStyle));
    #endregion
    #region IgnoreScripts
    /// <inheritdoc cref="NpmInstallSettings.IgnoreScripts"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.IgnoreScripts))]
    public static T SetIgnoreScripts<T>(this T o, bool? v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.IgnoreScripts, v));
    /// <inheritdoc cref="NpmInstallSettings.IgnoreScripts"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.IgnoreScripts))]
    public static T ResetIgnoreScripts<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.IgnoreScripts));
    /// <inheritdoc cref="NpmInstallSettings.IgnoreScripts"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.IgnoreScripts))]
    public static T EnableIgnoreScripts<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.IgnoreScripts, true));
    /// <inheritdoc cref="NpmInstallSettings.IgnoreScripts"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.IgnoreScripts))]
    public static T DisableIgnoreScripts<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.IgnoreScripts, false));
    /// <inheritdoc cref="NpmInstallSettings.IgnoreScripts"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.IgnoreScripts))]
    public static T ToggleIgnoreScripts<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.IgnoreScripts, !o.IgnoreScripts));
    #endregion
    #region LegacyBundling
    /// <inheritdoc cref="NpmInstallSettings.LegacyBundling"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.LegacyBundling))]
    public static T SetLegacyBundling<T>(this T o, bool? v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.LegacyBundling, v));
    /// <inheritdoc cref="NpmInstallSettings.LegacyBundling"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.LegacyBundling))]
    public static T ResetLegacyBundling<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.LegacyBundling));
    /// <inheritdoc cref="NpmInstallSettings.LegacyBundling"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.LegacyBundling))]
    public static T EnableLegacyBundling<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.LegacyBundling, true));
    /// <inheritdoc cref="NpmInstallSettings.LegacyBundling"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.LegacyBundling))]
    public static T DisableLegacyBundling<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.LegacyBundling, false));
    /// <inheritdoc cref="NpmInstallSettings.LegacyBundling"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.LegacyBundling))]
    public static T ToggleLegacyBundling<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.LegacyBundling, !o.LegacyBundling));
    #endregion
    #region Link
    /// <inheritdoc cref="NpmInstallSettings.Link"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Link))]
    public static T SetLink<T>(this T o, bool? v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Link, v));
    /// <inheritdoc cref="NpmInstallSettings.Link"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Link))]
    public static T ResetLink<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.Link));
    /// <inheritdoc cref="NpmInstallSettings.Link"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Link))]
    public static T EnableLink<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Link, true));
    /// <inheritdoc cref="NpmInstallSettings.Link"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Link))]
    public static T DisableLink<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Link, false));
    /// <inheritdoc cref="NpmInstallSettings.Link"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Link))]
    public static T ToggleLink<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Link, !o.Link));
    #endregion
    #region NoBinLinks
    /// <inheritdoc cref="NpmInstallSettings.NoBinLinks"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoBinLinks))]
    public static T SetNoBinLinks<T>(this T o, bool? v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoBinLinks, v));
    /// <inheritdoc cref="NpmInstallSettings.NoBinLinks"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoBinLinks))]
    public static T ResetNoBinLinks<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.NoBinLinks));
    /// <inheritdoc cref="NpmInstallSettings.NoBinLinks"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoBinLinks))]
    public static T EnableNoBinLinks<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoBinLinks, true));
    /// <inheritdoc cref="NpmInstallSettings.NoBinLinks"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoBinLinks))]
    public static T DisableNoBinLinks<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoBinLinks, false));
    /// <inheritdoc cref="NpmInstallSettings.NoBinLinks"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoBinLinks))]
    public static T ToggleNoBinLinks<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoBinLinks, !o.NoBinLinks));
    #endregion
    #region NoOptional
    /// <inheritdoc cref="NpmInstallSettings.NoOptional"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoOptional))]
    public static T SetNoOptional<T>(this T o, bool? v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoOptional, v));
    /// <inheritdoc cref="NpmInstallSettings.NoOptional"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoOptional))]
    public static T ResetNoOptional<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.NoOptional));
    /// <inheritdoc cref="NpmInstallSettings.NoOptional"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoOptional))]
    public static T EnableNoOptional<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoOptional, true));
    /// <inheritdoc cref="NpmInstallSettings.NoOptional"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoOptional))]
    public static T DisableNoOptional<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoOptional, false));
    /// <inheritdoc cref="NpmInstallSettings.NoOptional"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoOptional))]
    public static T ToggleNoOptional<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoOptional, !o.NoOptional));
    #endregion
    #region NoShrinkWrap
    /// <inheritdoc cref="NpmInstallSettings.NoShrinkWrap"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoShrinkWrap))]
    public static T SetNoShrinkWrap<T>(this T o, bool? v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoShrinkWrap, v));
    /// <inheritdoc cref="NpmInstallSettings.NoShrinkWrap"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoShrinkWrap))]
    public static T ResetNoShrinkWrap<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.NoShrinkWrap));
    /// <inheritdoc cref="NpmInstallSettings.NoShrinkWrap"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoShrinkWrap))]
    public static T EnableNoShrinkWrap<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoShrinkWrap, true));
    /// <inheritdoc cref="NpmInstallSettings.NoShrinkWrap"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoShrinkWrap))]
    public static T DisableNoShrinkWrap<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoShrinkWrap, false));
    /// <inheritdoc cref="NpmInstallSettings.NoShrinkWrap"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NoShrinkWrap))]
    public static T ToggleNoShrinkWrap<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NoShrinkWrap, !o.NoShrinkWrap));
    #endregion
    #region NodeDir
    /// <inheritdoc cref="NpmInstallSettings.NodeDir"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NodeDir))]
    public static T SetNodeDir<T>(this T o, string v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.NodeDir, v));
    /// <inheritdoc cref="NpmInstallSettings.NodeDir"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.NodeDir))]
    public static T ResetNodeDir<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.NodeDir));
    #endregion
    #region Only
    /// <inheritdoc cref="NpmInstallSettings.Only"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Only))]
    public static T SetOnly<T>(this T o, NpmOnlyMode v) where T : NpmInstallSettings => o.Modify(b => b.Set(() => o.Only, v));
    /// <inheritdoc cref="NpmInstallSettings.Only"/>
    [Pure] [Builder(Type = typeof(NpmInstallSettings), Property = nameof(NpmInstallSettings.Only))]
    public static T ResetOnly<T>(this T o) where T : NpmInstallSettings => o.Modify(b => b.Remove(() => o.Only));
    #endregion
}
#endregion
#region NpmRunSettingsExtensions
/// <summary>Used within <see cref="NpmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NpmRunSettingsExtensions
{
    #region Command
    /// <inheritdoc cref="NpmRunSettings.Command"/>
    [Pure] [Builder(Type = typeof(NpmRunSettings), Property = nameof(NpmRunSettings.Command))]
    public static T SetCommand<T>(this T o, string v) where T : NpmRunSettings => o.Modify(b => b.Set(() => o.Command, v));
    /// <inheritdoc cref="NpmRunSettings.Command"/>
    [Pure] [Builder(Type = typeof(NpmRunSettings), Property = nameof(NpmRunSettings.Command))]
    public static T ResetCommand<T>(this T o) where T : NpmRunSettings => o.Modify(b => b.Remove(() => o.Command));
    #endregion
    #region Arguments
    /// <inheritdoc cref="NpmRunSettings.Arguments"/>
    [Pure] [Builder(Type = typeof(NpmRunSettings), Property = nameof(NpmRunSettings.Arguments))]
    public static T SetArguments<T>(this T o, params string[] v) where T : NpmRunSettings => o.Modify(b => b.Set(() => o.Arguments, v));
    /// <inheritdoc cref="NpmRunSettings.Arguments"/>
    [Pure] [Builder(Type = typeof(NpmRunSettings), Property = nameof(NpmRunSettings.Arguments))]
    public static T SetArguments<T>(this T o, IEnumerable<string> v) where T : NpmRunSettings => o.Modify(b => b.Set(() => o.Arguments, v));
    /// <inheritdoc cref="NpmRunSettings.Arguments"/>
    [Pure] [Builder(Type = typeof(NpmRunSettings), Property = nameof(NpmRunSettings.Arguments))]
    public static T AddArguments<T>(this T o, params string[] v) where T : NpmRunSettings => o.Modify(b => b.AddCollection(() => o.Arguments, v));
    /// <inheritdoc cref="NpmRunSettings.Arguments"/>
    [Pure] [Builder(Type = typeof(NpmRunSettings), Property = nameof(NpmRunSettings.Arguments))]
    public static T AddArguments<T>(this T o, IEnumerable<string> v) where T : NpmRunSettings => o.Modify(b => b.AddCollection(() => o.Arguments, v));
    /// <inheritdoc cref="NpmRunSettings.Arguments"/>
    [Pure] [Builder(Type = typeof(NpmRunSettings), Property = nameof(NpmRunSettings.Arguments))]
    public static T RemoveArguments<T>(this T o, params string[] v) where T : NpmRunSettings => o.Modify(b => b.RemoveCollection(() => o.Arguments, v));
    /// <inheritdoc cref="NpmRunSettings.Arguments"/>
    [Pure] [Builder(Type = typeof(NpmRunSettings), Property = nameof(NpmRunSettings.Arguments))]
    public static T RemoveArguments<T>(this T o, IEnumerable<string> v) where T : NpmRunSettings => o.Modify(b => b.RemoveCollection(() => o.Arguments, v));
    /// <inheritdoc cref="NpmRunSettings.Arguments"/>
    [Pure] [Builder(Type = typeof(NpmRunSettings), Property = nameof(NpmRunSettings.Arguments))]
    public static T ClearArguments<T>(this T o) where T : NpmRunSettings => o.Modify(b => b.ClearCollection(() => o.Arguments));
    #endregion
}
#endregion
#region NpmOnlyMode
/// <summary>Used within <see cref="NpmTasks"/>.</summary>
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
