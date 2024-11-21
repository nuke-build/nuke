// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/ILRepack/ILRepack.json

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

namespace Nuke.Common.Tools.ILRepack;

/// <summary><p>ILRepack is meant at replacing <a href="https://github.com/dotnet/ILMerge">ILMerge</a> / <a href="https://evain.net/blog/articles/2006/11/06/an-introduction-to-mono-merge">Mono.Merge</a>.<para/>The former being closed-source (<a href="https://github.com/Microsoft/ILMerge">now open-sourced</a>), impossible to customize, slow, resource consuming and many more. The later being deprecated, unsupported, and based on an old version of Mono.Cecil.<para/>Here we're using latest (slightly modified) Cecil sources (0.9), you can find the fork <a href="https://github.com/gluck/cecil">here</a>. Mono.Posix is also required (build only, it gets merged afterwards) for executable bit set on target file.</p><p>For more details, visit the <a href="https://github.com/gluck/il-repack#readme">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class ILRepackTasks : ToolTasks, IRequireNuGetPackage
{
    public static string ILRepackPath => new ILRepackTasks().GetToolPath();
    public const string PackageId = "ILRepack";
    public const string PackageExecutable = "ILRepack.exe";
    /// <summary><p>ILRepack is meant at replacing <a href="https://github.com/dotnet/ILMerge">ILMerge</a> / <a href="https://evain.net/blog/articles/2006/11/06/an-introduction-to-mono-merge">Mono.Merge</a>.<para/>The former being closed-source (<a href="https://github.com/Microsoft/ILMerge">now open-sourced</a>), impossible to customize, slow, resource consuming and many more. The later being deprecated, unsupported, and based on an old version of Mono.Cecil.<para/>Here we're using latest (slightly modified) Cecil sources (0.9), you can find the fork <a href="https://github.com/gluck/cecil">here</a>. Mono.Posix is also required (build only, it gets merged afterwards) for executable bit set on target file.</p><p>For more details, visit the <a href="https://github.com/gluck/il-repack#readme">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> ILRepack(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new ILRepackTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>ILRepack is meant at replacing <a href="https://github.com/dotnet/ILMerge">ILMerge</a> / <a href="https://evain.net/blog/articles/2006/11/06/an-introduction-to-mono-merge">Mono.Merge</a>.<para/>The former being closed-source (<a href="https://github.com/Microsoft/ILMerge">now open-sourced</a>), impossible to customize, slow, resource consuming and many more. The later being deprecated, unsupported, and based on an old version of Mono.Cecil.<para/>Here we're using latest (slightly modified) Cecil sources (0.9), you can find the fork <a href="https://github.com/gluck/cecil">here</a>. Mono.Posix is also required (build only, it gets merged afterwards) for executable bit set on target file.</p><p>For more details, visit the <a href="https://github.com/gluck/il-repack#readme">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assemblies&gt;</c> via <see cref="ILRepackSettings.Assemblies"/></li><li><c>--allowdup</c> via <see cref="ILRepackSettings.AllowDuplicate"/></li><li><c>--allowduplicateresources</c> via <see cref="ILRepackSettings.AllowDuplicateResources"/></li><li><c>--allowMultiple</c> via <see cref="ILRepackSettings.AllowMultiple"/></li><li><c>--attr</c> via <see cref="ILRepackSettings.Attr"/></li><li><c>--copyattrs</c> via <see cref="ILRepackSettings.CopyAttributes"/></li><li><c>--delaysign</c> via <see cref="ILRepackSettings.DelaySign"/></li><li><c>--internalize</c> via <see cref="ILRepackSettings.Internalize"/></li><li><c>--internalize</c> via <see cref="ILRepackSettings.InternalizeExcludeFile"/></li><li><c>--keycontainer</c> via <see cref="ILRepackSettings.KeyContainer"/></li><li><c>--keyfile</c> via <see cref="ILRepackSettings.KeyFile"/></li><li><c>--lib</c> via <see cref="ILRepackSettings.Lib"/></li><li><c>--log</c> via <see cref="ILRepackSettings.LogFile"/></li><li><c>--ndebug</c> via <see cref="ILRepackSettings.NoDebug"/></li><li><c>--out</c> via <see cref="ILRepackSettings.Output"/></li><li><c>--parallel</c> via <see cref="ILRepackSettings.Parallel"/></li><li><c>--pause</c> via <see cref="ILRepackSettings.Pause"/></li><li><c>--renameInternalized</c> via <see cref="ILRepackSettings.RenameInternalized"/></li><li><c>--repackdrop:AttributeClass</c> via <see cref="ILRepackSettings.RepackDrop"/></li><li><c>--target</c> via <see cref="ILRepackSettings.Target"/></li><li><c>--targetplatform</c> via <see cref="ILRepackSettings.TargetPlatform"/></li><li><c>--union</c> via <see cref="ILRepackSettings.Union"/></li><li><c>--ver</c> via <see cref="ILRepackSettings.Version"/></li><li><c>--verbose</c> via <see cref="ILRepackSettings.Verbose"/></li><li><c>--wildcards</c> via <see cref="ILRepackSettings.Wildcards"/></li><li><c>--xmldocs</c> via <see cref="ILRepackSettings.Xmldocs"/></li><li><c>--zeropekind</c> via <see cref="ILRepackSettings.ZeroPekind"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ILRepack(ILRepackSettings options = null) => new ILRepackTasks().Run(options);
    /// <summary><p>ILRepack is meant at replacing <a href="https://github.com/dotnet/ILMerge">ILMerge</a> / <a href="https://evain.net/blog/articles/2006/11/06/an-introduction-to-mono-merge">Mono.Merge</a>.<para/>The former being closed-source (<a href="https://github.com/Microsoft/ILMerge">now open-sourced</a>), impossible to customize, slow, resource consuming and many more. The later being deprecated, unsupported, and based on an old version of Mono.Cecil.<para/>Here we're using latest (slightly modified) Cecil sources (0.9), you can find the fork <a href="https://github.com/gluck/cecil">here</a>. Mono.Posix is also required (build only, it gets merged afterwards) for executable bit set on target file.</p><p>For more details, visit the <a href="https://github.com/gluck/il-repack#readme">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assemblies&gt;</c> via <see cref="ILRepackSettings.Assemblies"/></li><li><c>--allowdup</c> via <see cref="ILRepackSettings.AllowDuplicate"/></li><li><c>--allowduplicateresources</c> via <see cref="ILRepackSettings.AllowDuplicateResources"/></li><li><c>--allowMultiple</c> via <see cref="ILRepackSettings.AllowMultiple"/></li><li><c>--attr</c> via <see cref="ILRepackSettings.Attr"/></li><li><c>--copyattrs</c> via <see cref="ILRepackSettings.CopyAttributes"/></li><li><c>--delaysign</c> via <see cref="ILRepackSettings.DelaySign"/></li><li><c>--internalize</c> via <see cref="ILRepackSettings.Internalize"/></li><li><c>--internalize</c> via <see cref="ILRepackSettings.InternalizeExcludeFile"/></li><li><c>--keycontainer</c> via <see cref="ILRepackSettings.KeyContainer"/></li><li><c>--keyfile</c> via <see cref="ILRepackSettings.KeyFile"/></li><li><c>--lib</c> via <see cref="ILRepackSettings.Lib"/></li><li><c>--log</c> via <see cref="ILRepackSettings.LogFile"/></li><li><c>--ndebug</c> via <see cref="ILRepackSettings.NoDebug"/></li><li><c>--out</c> via <see cref="ILRepackSettings.Output"/></li><li><c>--parallel</c> via <see cref="ILRepackSettings.Parallel"/></li><li><c>--pause</c> via <see cref="ILRepackSettings.Pause"/></li><li><c>--renameInternalized</c> via <see cref="ILRepackSettings.RenameInternalized"/></li><li><c>--repackdrop:AttributeClass</c> via <see cref="ILRepackSettings.RepackDrop"/></li><li><c>--target</c> via <see cref="ILRepackSettings.Target"/></li><li><c>--targetplatform</c> via <see cref="ILRepackSettings.TargetPlatform"/></li><li><c>--union</c> via <see cref="ILRepackSettings.Union"/></li><li><c>--ver</c> via <see cref="ILRepackSettings.Version"/></li><li><c>--verbose</c> via <see cref="ILRepackSettings.Verbose"/></li><li><c>--wildcards</c> via <see cref="ILRepackSettings.Wildcards"/></li><li><c>--xmldocs</c> via <see cref="ILRepackSettings.Xmldocs"/></li><li><c>--zeropekind</c> via <see cref="ILRepackSettings.ZeroPekind"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ILRepack(Configure<ILRepackSettings> configurator) => new ILRepackTasks().Run(configurator.Invoke(new ILRepackSettings()));
    /// <summary><p>ILRepack is meant at replacing <a href="https://github.com/dotnet/ILMerge">ILMerge</a> / <a href="https://evain.net/blog/articles/2006/11/06/an-introduction-to-mono-merge">Mono.Merge</a>.<para/>The former being closed-source (<a href="https://github.com/Microsoft/ILMerge">now open-sourced</a>), impossible to customize, slow, resource consuming and many more. The later being deprecated, unsupported, and based on an old version of Mono.Cecil.<para/>Here we're using latest (slightly modified) Cecil sources (0.9), you can find the fork <a href="https://github.com/gluck/cecil">here</a>. Mono.Posix is also required (build only, it gets merged afterwards) for executable bit set on target file.</p><p>For more details, visit the <a href="https://github.com/gluck/il-repack#readme">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assemblies&gt;</c> via <see cref="ILRepackSettings.Assemblies"/></li><li><c>--allowdup</c> via <see cref="ILRepackSettings.AllowDuplicate"/></li><li><c>--allowduplicateresources</c> via <see cref="ILRepackSettings.AllowDuplicateResources"/></li><li><c>--allowMultiple</c> via <see cref="ILRepackSettings.AllowMultiple"/></li><li><c>--attr</c> via <see cref="ILRepackSettings.Attr"/></li><li><c>--copyattrs</c> via <see cref="ILRepackSettings.CopyAttributes"/></li><li><c>--delaysign</c> via <see cref="ILRepackSettings.DelaySign"/></li><li><c>--internalize</c> via <see cref="ILRepackSettings.Internalize"/></li><li><c>--internalize</c> via <see cref="ILRepackSettings.InternalizeExcludeFile"/></li><li><c>--keycontainer</c> via <see cref="ILRepackSettings.KeyContainer"/></li><li><c>--keyfile</c> via <see cref="ILRepackSettings.KeyFile"/></li><li><c>--lib</c> via <see cref="ILRepackSettings.Lib"/></li><li><c>--log</c> via <see cref="ILRepackSettings.LogFile"/></li><li><c>--ndebug</c> via <see cref="ILRepackSettings.NoDebug"/></li><li><c>--out</c> via <see cref="ILRepackSettings.Output"/></li><li><c>--parallel</c> via <see cref="ILRepackSettings.Parallel"/></li><li><c>--pause</c> via <see cref="ILRepackSettings.Pause"/></li><li><c>--renameInternalized</c> via <see cref="ILRepackSettings.RenameInternalized"/></li><li><c>--repackdrop:AttributeClass</c> via <see cref="ILRepackSettings.RepackDrop"/></li><li><c>--target</c> via <see cref="ILRepackSettings.Target"/></li><li><c>--targetplatform</c> via <see cref="ILRepackSettings.TargetPlatform"/></li><li><c>--union</c> via <see cref="ILRepackSettings.Union"/></li><li><c>--ver</c> via <see cref="ILRepackSettings.Version"/></li><li><c>--verbose</c> via <see cref="ILRepackSettings.Verbose"/></li><li><c>--wildcards</c> via <see cref="ILRepackSettings.Wildcards"/></li><li><c>--xmldocs</c> via <see cref="ILRepackSettings.Xmldocs"/></li><li><c>--zeropekind</c> via <see cref="ILRepackSettings.ZeroPekind"/></li></ul></remarks>
    public static IEnumerable<(ILRepackSettings Settings, IReadOnlyCollection<Output> Output)> ILRepack(CombinatorialConfigure<ILRepackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ILRepack, degreeOfParallelism, completeOnFailure);
}
#region ILRepackSettings
/// <summary>Used within <see cref="ILRepackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ILRepackSettings>))]
[Command(Type = typeof(ILRepackTasks), Command = nameof(ILRepackTasks.ILRepack))]
public partial class ILRepackSettings : ToolOptions
{
    /// <summary>Specifies a keyfile to sign the output assembly.</summary>
    [Argument(Format = "--keyfile:{value}")] public string KeyFile => Get<string>(() => KeyFile);
    /// <summary>Specifies a key container to sign the output assembly (takes precedence over <c>--keyfile</c>).</summary>
    [Argument(Format = "--keycontainer:{value}")] public string KeyContainer => Get<string>(() => KeyContainer);
    /// <summary>Enable logging (to a file, if given) (default is disabled).</summary>
    [Argument(Format = "--log:{value}")] public string LogFile => Get<string>(() => LogFile);
    /// <summary>Target assembly version.</summary>
    [Argument(Format = "--ver:{value}")] public string Version => Get<string>(() => Version);
    /// <summary>Merges types with identical names into one.</summary>
    [Argument(Format = "--union")] public bool? Union => Get<bool?>(() => Union);
    /// <summary>Disables symbol file generation.</summary>
    [Argument(Format = "--ndebug")] public bool? NoDebug => Get<bool?>(() => NoDebug);
    /// <summary>Copy assembly attributes (by default only the primary assembly attributes are copied).</summary>
    [Argument(Format = "--copyattrs")] public bool? CopyAttributes => Get<bool?>(() => CopyAttributes);
    /// <summary>Take assembly attributes from the given assembly file.</summary>
    [Argument(Format = "--attr:{value}")] public string Attr => Get<string>(() => Attr);
    /// <summary>When <c>--copyattrs</c> is specified, allows multiple attributes (if type allows).</summary>
    [Argument(Format = "--allowMultiple")] public bool? AllowMultiple => Get<bool?>(() => AllowMultiple);
    /// <summary>Specify target assembly kind (<c>library</c>, <c>exe</c>, <c>winexe</c> supported, default is same as first assembly).</summary>
    [Argument(Format = "--target:{value}")] public ILRepackTarget Target => Get<ILRepackTarget>(() => Target);
    /// <summary>Specify target platform (v1, v1.1, v2, v4 supported).</summary>
    [Argument(Format = "--targetplatform:{value}")] public string TargetPlatform => Get<string>(() => TargetPlatform);
    /// <summary>Merges XML documentation as well.</summary>
    [Argument(Format = "--xmldocs")] public bool? Xmldocs => Get<bool?>(() => Xmldocs);
    /// <summary>Adds the path to the search directories for referenced assemblies (can be specified multiple times).</summary>
    [Argument(Format = "--lib:{value}")] public string Lib => Get<string>(() => Lib);
    /// <summary>Sets all types but the ones from the first assembly <c>internal</c>.</summary>
    [Argument(Format = "--internalize")] public bool? Internalize => Get<bool?>(() => Internalize);
    /// <summary>Exclude file contains one regex per line to compare against fullname of types NOT to internalize.</summary>
    [Argument(Format = "--internalize:{value}")] public string InternalizeExcludeFile => Get<string>(() => InternalizeExcludeFile);
    /// <summary>Rename all internalized types.</summary>
    [Argument(Format = "--renameInternalized")] public bool? RenameInternalized => Get<bool?>(() => RenameInternalized);
    /// <summary>Sets the key, but don't sign the assembly.</summary>
    [Argument(Format = "--delaysign")] public bool? DelaySign => Get<bool?>(() => DelaySign);
    /// <summary>Allows the specified type for being duplicated in input assemblies.</summary>
    [Argument(Format = "--allowdup:{value}")] public IReadOnlyList<string> AllowDuplicate => Get<List<string>>(() => AllowDuplicate);
    /// <summary>Allows to duplicate resources in output assembly (by default they're ignored).</summary>
    [Argument(Format = "--allowduplicateresources")] public bool? AllowDuplicateResources => Get<bool?>(() => AllowDuplicateResources);
    /// <summary>Allows assemblies with Zero <c>PeKind</c> (but obviously only IL will get merged).</summary>
    [Argument(Format = "--zeropekind")] public bool? ZeroPekind => Get<bool?>(() => ZeroPekind);
    /// <summary>Allows (and resolves) file wildcards (e.g. <c>*.dll</c>) in input assemblies.</summary>
    [Argument(Format = "--wildcards")] public bool? Wildcards => Get<bool?>(() => Wildcards);
    /// <summary>Use as many CPUs as possible to merge the assemblies.</summary>
    [Argument(Format = "--parallel")] public bool? Parallel => Get<bool?>(() => Parallel);
    /// <summary>Pause execution once completed (good for debugging).</summary>
    [Argument(Format = "--pause")] public bool? Pause => Get<bool?>(() => Pause);
    /// <summary>Allows dropping specific members during merging (<a href="https://github.com/gluck/il-repack/issues/215">#215</a>).</summary>
    [Argument(Format = "--repackdrop:AttributeClass")] public bool? RepackDrop => Get<bool?>(() => RepackDrop);
    /// <summary>Shows more logs.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Target assembly path, <c>symbol/config/doc</c> files will be written here as well.</summary>
    [Argument(Format = "--out:{value}")] public string Output => Get<string>(() => Output);
    /// <summary>Primary and other assemblies to be merged.</summary>
    [Argument(Format = "{value}", Position = -1)] public IReadOnlyList<string> Assemblies => Get<List<string>>(() => Assemblies);
}
#endregion
#region ILRepackSettingsExtensions
/// <summary>Used within <see cref="ILRepackTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ILRepackSettingsExtensions
{
    #region KeyFile
    /// <inheritdoc cref="ILRepackSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.KeyFile))]
    public static T SetKeyFile<T>(this T o, string v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.KeyFile, v));
    /// <inheritdoc cref="ILRepackSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.KeyFile))]
    public static T ResetKeyFile<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.KeyFile));
    #endregion
    #region KeyContainer
    /// <inheritdoc cref="ILRepackSettings.KeyContainer"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.KeyContainer))]
    public static T SetKeyContainer<T>(this T o, string v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.KeyContainer, v));
    /// <inheritdoc cref="ILRepackSettings.KeyContainer"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.KeyContainer))]
    public static T ResetKeyContainer<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.KeyContainer));
    #endregion
    #region LogFile
    /// <inheritdoc cref="ILRepackSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="ILRepackSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
    #region Version
    /// <inheritdoc cref="ILRepackSettings.Version"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="ILRepackSettings.Version"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Union
    /// <inheritdoc cref="ILRepackSettings.Union"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Union))]
    public static T SetUnion<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Union, v));
    /// <inheritdoc cref="ILRepackSettings.Union"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Union))]
    public static T ResetUnion<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Union));
    /// <inheritdoc cref="ILRepackSettings.Union"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Union))]
    public static T EnableUnion<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Union, true));
    /// <inheritdoc cref="ILRepackSettings.Union"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Union))]
    public static T DisableUnion<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Union, false));
    /// <inheritdoc cref="ILRepackSettings.Union"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Union))]
    public static T ToggleUnion<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Union, !o.Union));
    #endregion
    #region NoDebug
    /// <inheritdoc cref="ILRepackSettings.NoDebug"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.NoDebug))]
    public static T SetNoDebug<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.NoDebug, v));
    /// <inheritdoc cref="ILRepackSettings.NoDebug"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.NoDebug))]
    public static T ResetNoDebug<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.NoDebug));
    /// <inheritdoc cref="ILRepackSettings.NoDebug"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.NoDebug))]
    public static T EnableNoDebug<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.NoDebug, true));
    /// <inheritdoc cref="ILRepackSettings.NoDebug"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.NoDebug))]
    public static T DisableNoDebug<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.NoDebug, false));
    /// <inheritdoc cref="ILRepackSettings.NoDebug"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.NoDebug))]
    public static T ToggleNoDebug<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.NoDebug, !o.NoDebug));
    #endregion
    #region CopyAttributes
    /// <inheritdoc cref="ILRepackSettings.CopyAttributes"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.CopyAttributes))]
    public static T SetCopyAttributes<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.CopyAttributes, v));
    /// <inheritdoc cref="ILRepackSettings.CopyAttributes"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.CopyAttributes))]
    public static T ResetCopyAttributes<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.CopyAttributes));
    /// <inheritdoc cref="ILRepackSettings.CopyAttributes"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.CopyAttributes))]
    public static T EnableCopyAttributes<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.CopyAttributes, true));
    /// <inheritdoc cref="ILRepackSettings.CopyAttributes"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.CopyAttributes))]
    public static T DisableCopyAttributes<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.CopyAttributes, false));
    /// <inheritdoc cref="ILRepackSettings.CopyAttributes"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.CopyAttributes))]
    public static T ToggleCopyAttributes<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.CopyAttributes, !o.CopyAttributes));
    #endregion
    #region Attr
    /// <inheritdoc cref="ILRepackSettings.Attr"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Attr))]
    public static T SetAttr<T>(this T o, string v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Attr, v));
    /// <inheritdoc cref="ILRepackSettings.Attr"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Attr))]
    public static T ResetAttr<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Attr));
    #endregion
    #region AllowMultiple
    /// <inheritdoc cref="ILRepackSettings.AllowMultiple"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowMultiple))]
    public static T SetAllowMultiple<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.AllowMultiple, v));
    /// <inheritdoc cref="ILRepackSettings.AllowMultiple"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowMultiple))]
    public static T ResetAllowMultiple<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.AllowMultiple));
    /// <inheritdoc cref="ILRepackSettings.AllowMultiple"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowMultiple))]
    public static T EnableAllowMultiple<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.AllowMultiple, true));
    /// <inheritdoc cref="ILRepackSettings.AllowMultiple"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowMultiple))]
    public static T DisableAllowMultiple<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.AllowMultiple, false));
    /// <inheritdoc cref="ILRepackSettings.AllowMultiple"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowMultiple))]
    public static T ToggleAllowMultiple<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.AllowMultiple, !o.AllowMultiple));
    #endregion
    #region Target
    /// <inheritdoc cref="ILRepackSettings.Target"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Target))]
    public static T SetTarget<T>(this T o, ILRepackTarget v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Target, v));
    /// <inheritdoc cref="ILRepackSettings.Target"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Target))]
    public static T ResetTarget<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Target));
    #endregion
    #region TargetPlatform
    /// <inheritdoc cref="ILRepackSettings.TargetPlatform"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.TargetPlatform))]
    public static T SetTargetPlatform<T>(this T o, string v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.TargetPlatform, v));
    /// <inheritdoc cref="ILRepackSettings.TargetPlatform"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.TargetPlatform))]
    public static T ResetTargetPlatform<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.TargetPlatform));
    #endregion
    #region Xmldocs
    /// <inheritdoc cref="ILRepackSettings.Xmldocs"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Xmldocs))]
    public static T SetXmldocs<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Xmldocs, v));
    /// <inheritdoc cref="ILRepackSettings.Xmldocs"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Xmldocs))]
    public static T ResetXmldocs<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Xmldocs));
    /// <inheritdoc cref="ILRepackSettings.Xmldocs"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Xmldocs))]
    public static T EnableXmldocs<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Xmldocs, true));
    /// <inheritdoc cref="ILRepackSettings.Xmldocs"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Xmldocs))]
    public static T DisableXmldocs<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Xmldocs, false));
    /// <inheritdoc cref="ILRepackSettings.Xmldocs"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Xmldocs))]
    public static T ToggleXmldocs<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Xmldocs, !o.Xmldocs));
    #endregion
    #region Lib
    /// <inheritdoc cref="ILRepackSettings.Lib"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Lib))]
    public static T SetLib<T>(this T o, string v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Lib, v));
    /// <inheritdoc cref="ILRepackSettings.Lib"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Lib))]
    public static T ResetLib<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Lib));
    #endregion
    #region Internalize
    /// <inheritdoc cref="ILRepackSettings.Internalize"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Internalize))]
    public static T SetInternalize<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Internalize, v));
    /// <inheritdoc cref="ILRepackSettings.Internalize"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Internalize))]
    public static T ResetInternalize<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Internalize));
    /// <inheritdoc cref="ILRepackSettings.Internalize"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Internalize))]
    public static T EnableInternalize<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Internalize, true));
    /// <inheritdoc cref="ILRepackSettings.Internalize"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Internalize))]
    public static T DisableInternalize<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Internalize, false));
    /// <inheritdoc cref="ILRepackSettings.Internalize"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Internalize))]
    public static T ToggleInternalize<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Internalize, !o.Internalize));
    #endregion
    #region InternalizeExcludeFile
    /// <inheritdoc cref="ILRepackSettings.InternalizeExcludeFile"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.InternalizeExcludeFile))]
    public static T SetInternalizeExcludeFile<T>(this T o, string v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.InternalizeExcludeFile, v));
    /// <inheritdoc cref="ILRepackSettings.InternalizeExcludeFile"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.InternalizeExcludeFile))]
    public static T ResetInternalizeExcludeFile<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.InternalizeExcludeFile));
    #endregion
    #region RenameInternalized
    /// <inheritdoc cref="ILRepackSettings.RenameInternalized"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.RenameInternalized))]
    public static T SetRenameInternalized<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.RenameInternalized, v));
    /// <inheritdoc cref="ILRepackSettings.RenameInternalized"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.RenameInternalized))]
    public static T ResetRenameInternalized<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.RenameInternalized));
    /// <inheritdoc cref="ILRepackSettings.RenameInternalized"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.RenameInternalized))]
    public static T EnableRenameInternalized<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.RenameInternalized, true));
    /// <inheritdoc cref="ILRepackSettings.RenameInternalized"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.RenameInternalized))]
    public static T DisableRenameInternalized<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.RenameInternalized, false));
    /// <inheritdoc cref="ILRepackSettings.RenameInternalized"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.RenameInternalized))]
    public static T ToggleRenameInternalized<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.RenameInternalized, !o.RenameInternalized));
    #endregion
    #region DelaySign
    /// <inheritdoc cref="ILRepackSettings.DelaySign"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.DelaySign))]
    public static T SetDelaySign<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.DelaySign, v));
    /// <inheritdoc cref="ILRepackSettings.DelaySign"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.DelaySign))]
    public static T ResetDelaySign<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.DelaySign));
    /// <inheritdoc cref="ILRepackSettings.DelaySign"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.DelaySign))]
    public static T EnableDelaySign<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.DelaySign, true));
    /// <inheritdoc cref="ILRepackSettings.DelaySign"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.DelaySign))]
    public static T DisableDelaySign<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.DelaySign, false));
    /// <inheritdoc cref="ILRepackSettings.DelaySign"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.DelaySign))]
    public static T ToggleDelaySign<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.DelaySign, !o.DelaySign));
    #endregion
    #region AllowDuplicate
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicate"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicate))]
    public static T SetAllowDuplicate<T>(this T o, params string[] v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.AllowDuplicate, v));
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicate"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicate))]
    public static T SetAllowDuplicate<T>(this T o, IEnumerable<string> v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.AllowDuplicate, v));
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicate"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicate))]
    public static T AddAllowDuplicate<T>(this T o, params string[] v) where T : ILRepackSettings => o.Modify(b => b.AddCollection(() => o.AllowDuplicate, v));
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicate"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicate))]
    public static T AddAllowDuplicate<T>(this T o, IEnumerable<string> v) where T : ILRepackSettings => o.Modify(b => b.AddCollection(() => o.AllowDuplicate, v));
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicate"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicate))]
    public static T RemoveAllowDuplicate<T>(this T o, params string[] v) where T : ILRepackSettings => o.Modify(b => b.RemoveCollection(() => o.AllowDuplicate, v));
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicate"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicate))]
    public static T RemoveAllowDuplicate<T>(this T o, IEnumerable<string> v) where T : ILRepackSettings => o.Modify(b => b.RemoveCollection(() => o.AllowDuplicate, v));
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicate"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicate))]
    public static T ClearAllowDuplicate<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.ClearCollection(() => o.AllowDuplicate));
    #endregion
    #region AllowDuplicateResources
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicateResources"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicateResources))]
    public static T SetAllowDuplicateResources<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.AllowDuplicateResources, v));
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicateResources"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicateResources))]
    public static T ResetAllowDuplicateResources<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.AllowDuplicateResources));
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicateResources"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicateResources))]
    public static T EnableAllowDuplicateResources<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.AllowDuplicateResources, true));
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicateResources"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicateResources))]
    public static T DisableAllowDuplicateResources<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.AllowDuplicateResources, false));
    /// <inheritdoc cref="ILRepackSettings.AllowDuplicateResources"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.AllowDuplicateResources))]
    public static T ToggleAllowDuplicateResources<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.AllowDuplicateResources, !o.AllowDuplicateResources));
    #endregion
    #region ZeroPekind
    /// <inheritdoc cref="ILRepackSettings.ZeroPekind"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.ZeroPekind))]
    public static T SetZeroPekind<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.ZeroPekind, v));
    /// <inheritdoc cref="ILRepackSettings.ZeroPekind"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.ZeroPekind))]
    public static T ResetZeroPekind<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.ZeroPekind));
    /// <inheritdoc cref="ILRepackSettings.ZeroPekind"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.ZeroPekind))]
    public static T EnableZeroPekind<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.ZeroPekind, true));
    /// <inheritdoc cref="ILRepackSettings.ZeroPekind"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.ZeroPekind))]
    public static T DisableZeroPekind<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.ZeroPekind, false));
    /// <inheritdoc cref="ILRepackSettings.ZeroPekind"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.ZeroPekind))]
    public static T ToggleZeroPekind<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.ZeroPekind, !o.ZeroPekind));
    #endregion
    #region Wildcards
    /// <inheritdoc cref="ILRepackSettings.Wildcards"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Wildcards))]
    public static T SetWildcards<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Wildcards, v));
    /// <inheritdoc cref="ILRepackSettings.Wildcards"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Wildcards))]
    public static T ResetWildcards<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Wildcards));
    /// <inheritdoc cref="ILRepackSettings.Wildcards"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Wildcards))]
    public static T EnableWildcards<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Wildcards, true));
    /// <inheritdoc cref="ILRepackSettings.Wildcards"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Wildcards))]
    public static T DisableWildcards<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Wildcards, false));
    /// <inheritdoc cref="ILRepackSettings.Wildcards"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Wildcards))]
    public static T ToggleWildcards<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Wildcards, !o.Wildcards));
    #endregion
    #region Parallel
    /// <inheritdoc cref="ILRepackSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Parallel))]
    public static T SetParallel<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Parallel, v));
    /// <inheritdoc cref="ILRepackSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Parallel))]
    public static T ResetParallel<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Parallel));
    /// <inheritdoc cref="ILRepackSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Parallel))]
    public static T EnableParallel<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Parallel, true));
    /// <inheritdoc cref="ILRepackSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Parallel))]
    public static T DisableParallel<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Parallel, false));
    /// <inheritdoc cref="ILRepackSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Parallel))]
    public static T ToggleParallel<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Parallel, !o.Parallel));
    #endregion
    #region Pause
    /// <inheritdoc cref="ILRepackSettings.Pause"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Pause))]
    public static T SetPause<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Pause, v));
    /// <inheritdoc cref="ILRepackSettings.Pause"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Pause))]
    public static T ResetPause<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Pause));
    /// <inheritdoc cref="ILRepackSettings.Pause"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Pause))]
    public static T EnablePause<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Pause, true));
    /// <inheritdoc cref="ILRepackSettings.Pause"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Pause))]
    public static T DisablePause<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Pause, false));
    /// <inheritdoc cref="ILRepackSettings.Pause"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Pause))]
    public static T TogglePause<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Pause, !o.Pause));
    #endregion
    #region RepackDrop
    /// <inheritdoc cref="ILRepackSettings.RepackDrop"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.RepackDrop))]
    public static T SetRepackDrop<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.RepackDrop, v));
    /// <inheritdoc cref="ILRepackSettings.RepackDrop"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.RepackDrop))]
    public static T ResetRepackDrop<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.RepackDrop));
    /// <inheritdoc cref="ILRepackSettings.RepackDrop"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.RepackDrop))]
    public static T EnableRepackDrop<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.RepackDrop, true));
    /// <inheritdoc cref="ILRepackSettings.RepackDrop"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.RepackDrop))]
    public static T DisableRepackDrop<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.RepackDrop, false));
    /// <inheritdoc cref="ILRepackSettings.RepackDrop"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.RepackDrop))]
    public static T ToggleRepackDrop<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.RepackDrop, !o.RepackDrop));
    #endregion
    #region Verbose
    /// <inheritdoc cref="ILRepackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="ILRepackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="ILRepackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="ILRepackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="ILRepackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Output
    /// <inheritdoc cref="ILRepackSettings.Output"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="ILRepackSettings.Output"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region Assemblies
    /// <inheritdoc cref="ILRepackSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Assemblies))]
    public static T SetAssemblies<T>(this T o, params string[] v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Assemblies, v));
    /// <inheritdoc cref="ILRepackSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Assemblies))]
    public static T SetAssemblies<T>(this T o, IEnumerable<string> v) where T : ILRepackSettings => o.Modify(b => b.Set(() => o.Assemblies, v));
    /// <inheritdoc cref="ILRepackSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Assemblies))]
    public static T AddAssemblies<T>(this T o, params string[] v) where T : ILRepackSettings => o.Modify(b => b.AddCollection(() => o.Assemblies, v));
    /// <inheritdoc cref="ILRepackSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Assemblies))]
    public static T AddAssemblies<T>(this T o, IEnumerable<string> v) where T : ILRepackSettings => o.Modify(b => b.AddCollection(() => o.Assemblies, v));
    /// <inheritdoc cref="ILRepackSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Assemblies))]
    public static T RemoveAssemblies<T>(this T o, params string[] v) where T : ILRepackSettings => o.Modify(b => b.RemoveCollection(() => o.Assemblies, v));
    /// <inheritdoc cref="ILRepackSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Assemblies))]
    public static T RemoveAssemblies<T>(this T o, IEnumerable<string> v) where T : ILRepackSettings => o.Modify(b => b.RemoveCollection(() => o.Assemblies, v));
    /// <inheritdoc cref="ILRepackSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(ILRepackSettings), Property = nameof(ILRepackSettings.Assemblies))]
    public static T ClearAssemblies<T>(this T o) where T : ILRepackSettings => o.Modify(b => b.ClearCollection(() => o.Assemblies));
    #endregion
}
#endregion
#region ILRepackTarget
/// <summary>Used within <see cref="ILRepackTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ILRepackTarget>))]
public partial class ILRepackTarget : Enumeration
{
    public static ILRepackTarget library = (ILRepackTarget) "library";
    public static ILRepackTarget exe = (ILRepackTarget) "exe";
    public static ILRepackTarget winexe = (ILRepackTarget) "winexe";
    public static implicit operator ILRepackTarget(string value)
    {
        return new ILRepackTarget { Value = value };
    }
}
#endregion
