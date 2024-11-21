// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/CorFlags/CorFlags.json

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

namespace Nuke.Common.Tools.CorFlags;

/// <summary><p>The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathToolRequirement(PathExecutable)]
[PathTool(Executable = PathExecutable)]
public partial class CorFlagsTasks : ToolTasks, IRequirePathTool
{
    public static string CorFlagsPath => new CorFlagsTasks().GetToolPath();
    public const string PathExecutable = "CorFlags.exe";
    /// <summary><p>The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> CorFlags(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new CorFlagsTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assembly&gt;</c> via <see cref="CorFlagsSettings.Assembly"/></li><li><c>-32BIT</c> via <see cref="CorFlagsSettings.Require32Bit"/></li><li><c>-32BITPREF</c> via <see cref="CorFlagsSettings.Prefer32Bit"/></li><li><c>-Force</c> via <see cref="CorFlagsSettings.Force"/></li><li><c>-ILONLY</c> via <see cref="CorFlagsSettings.ILOnly"/></li><li><c>-nologo</c> via <see cref="CorFlagsSettings.NoLogo"/></li><li><c>-RevertCLRHeader</c> via <see cref="CorFlagsSettings.RevertCLRHeader"/></li><li><c>-UpgradeCLRHeader</c> via <see cref="CorFlagsSettings.UpgradeCLRHeader"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> CorFlags(CorFlagsSettings options = null) => new CorFlagsTasks().Run(options);
    /// <summary><p>The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assembly&gt;</c> via <see cref="CorFlagsSettings.Assembly"/></li><li><c>-32BIT</c> via <see cref="CorFlagsSettings.Require32Bit"/></li><li><c>-32BITPREF</c> via <see cref="CorFlagsSettings.Prefer32Bit"/></li><li><c>-Force</c> via <see cref="CorFlagsSettings.Force"/></li><li><c>-ILONLY</c> via <see cref="CorFlagsSettings.ILOnly"/></li><li><c>-nologo</c> via <see cref="CorFlagsSettings.NoLogo"/></li><li><c>-RevertCLRHeader</c> via <see cref="CorFlagsSettings.RevertCLRHeader"/></li><li><c>-UpgradeCLRHeader</c> via <see cref="CorFlagsSettings.UpgradeCLRHeader"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> CorFlags(Configure<CorFlagsSettings> configurator) => new CorFlagsTasks().Run(configurator.Invoke(new CorFlagsSettings()));
    /// <summary><p>The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assembly&gt;</c> via <see cref="CorFlagsSettings.Assembly"/></li><li><c>-32BIT</c> via <see cref="CorFlagsSettings.Require32Bit"/></li><li><c>-32BITPREF</c> via <see cref="CorFlagsSettings.Prefer32Bit"/></li><li><c>-Force</c> via <see cref="CorFlagsSettings.Force"/></li><li><c>-ILONLY</c> via <see cref="CorFlagsSettings.ILOnly"/></li><li><c>-nologo</c> via <see cref="CorFlagsSettings.NoLogo"/></li><li><c>-RevertCLRHeader</c> via <see cref="CorFlagsSettings.RevertCLRHeader"/></li><li><c>-UpgradeCLRHeader</c> via <see cref="CorFlagsSettings.UpgradeCLRHeader"/></li></ul></remarks>
    public static IEnumerable<(CorFlagsSettings Settings, IReadOnlyCollection<Output> Output)> CorFlags(CombinatorialConfigure<CorFlagsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(CorFlags, degreeOfParallelism, completeOnFailure);
}
#region CorFlagsSettings
/// <summary>Used within <see cref="CorFlagsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<CorFlagsSettings>))]
[Command(Type = typeof(CorFlagsTasks), Command = nameof(CorFlagsTasks.CorFlags))]
public partial class CorFlagsSettings : ToolOptions
{
    /// <summary>Suppresses the Microsoft startup banner display.</summary>
    [Argument(Format = "-nologo")] public bool? NoLogo => Get<bool?>(() => NoLogo);
    /// <summary>Upgrades the CLR header version to 2.5. <em>Note</em>: Assemblies must have a CLR header version of 2.5 or greater to run natively.</summary>
    [Argument(Format = "-UpgradeCLRHeader")] public bool? UpgradeCLRHeader => Get<bool?>(() => UpgradeCLRHeader);
    /// <summary>Reverts the CLR header version to 2.0.</summary>
    [Argument(Format = "-RevertCLRHeader")] public bool? RevertCLRHeader => Get<bool?>(() => RevertCLRHeader);
    /// <summary>Forces an update even if the assembly is strong-named. <em>Important</em>: If you update a strong-named assembly, you must sign it again before executing its code.</summary>
    [Argument(Format = "-Force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>The name of the assembly for which to configure the CorFlags.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Assembly => Get<string>(() => Assembly);
    /// <summary>Sets/clears the ILONLY flag.</summary>
    [Argument(Format = "-ILONLY{value}", FormatterMethod = nameof(FormatBoolean))] public bool? ILOnly => Get<bool?>(() => ILOnly);
    /// <summary>Sets/clears the 32BITREQUIRED flag.</summary>
    [Argument(Format = "-32BIT{value}", FormatterMethod = nameof(FormatBoolean))] public bool? Require32Bit => Get<bool?>(() => Require32Bit);
    /// <summary>Sets/clears the 32BITPREFERRED flag.</summary>
    [Argument(Format = "-32BITPREF{value}", FormatterMethod = nameof(FormatBoolean))] public bool? Prefer32Bit => Get<bool?>(() => Prefer32Bit);
}
#endregion
#region CorFlagsSettingsExtensions
/// <summary>Used within <see cref="CorFlagsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class CorFlagsSettingsExtensions
{
    #region NoLogo
    /// <inheritdoc cref="CorFlagsSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.NoLogo))]
    public static T SetNoLogo<T>(this T o, bool? v) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.NoLogo, v));
    /// <inheritdoc cref="CorFlagsSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.NoLogo))]
    public static T ResetNoLogo<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Remove(() => o.NoLogo));
    /// <inheritdoc cref="CorFlagsSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.NoLogo))]
    public static T EnableNoLogo<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.NoLogo, true));
    /// <inheritdoc cref="CorFlagsSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.NoLogo))]
    public static T DisableNoLogo<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.NoLogo, false));
    /// <inheritdoc cref="CorFlagsSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.NoLogo))]
    public static T ToggleNoLogo<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.NoLogo, !o.NoLogo));
    #endregion
    #region UpgradeCLRHeader
    /// <inheritdoc cref="CorFlagsSettings.UpgradeCLRHeader"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.UpgradeCLRHeader))]
    public static T SetUpgradeCLRHeader<T>(this T o, bool? v) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.UpgradeCLRHeader, v));
    /// <inheritdoc cref="CorFlagsSettings.UpgradeCLRHeader"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.UpgradeCLRHeader))]
    public static T ResetUpgradeCLRHeader<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Remove(() => o.UpgradeCLRHeader));
    /// <inheritdoc cref="CorFlagsSettings.UpgradeCLRHeader"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.UpgradeCLRHeader))]
    public static T EnableUpgradeCLRHeader<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.UpgradeCLRHeader, true));
    /// <inheritdoc cref="CorFlagsSettings.UpgradeCLRHeader"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.UpgradeCLRHeader))]
    public static T DisableUpgradeCLRHeader<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.UpgradeCLRHeader, false));
    /// <inheritdoc cref="CorFlagsSettings.UpgradeCLRHeader"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.UpgradeCLRHeader))]
    public static T ToggleUpgradeCLRHeader<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.UpgradeCLRHeader, !o.UpgradeCLRHeader));
    #endregion
    #region RevertCLRHeader
    /// <inheritdoc cref="CorFlagsSettings.RevertCLRHeader"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.RevertCLRHeader))]
    public static T SetRevertCLRHeader<T>(this T o, bool? v) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.RevertCLRHeader, v));
    /// <inheritdoc cref="CorFlagsSettings.RevertCLRHeader"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.RevertCLRHeader))]
    public static T ResetRevertCLRHeader<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Remove(() => o.RevertCLRHeader));
    /// <inheritdoc cref="CorFlagsSettings.RevertCLRHeader"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.RevertCLRHeader))]
    public static T EnableRevertCLRHeader<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.RevertCLRHeader, true));
    /// <inheritdoc cref="CorFlagsSettings.RevertCLRHeader"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.RevertCLRHeader))]
    public static T DisableRevertCLRHeader<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.RevertCLRHeader, false));
    /// <inheritdoc cref="CorFlagsSettings.RevertCLRHeader"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.RevertCLRHeader))]
    public static T ToggleRevertCLRHeader<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.RevertCLRHeader, !o.RevertCLRHeader));
    #endregion
    #region Force
    /// <inheritdoc cref="CorFlagsSettings.Force"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="CorFlagsSettings.Force"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Force))]
    public static T ResetForce<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="CorFlagsSettings.Force"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Force))]
    public static T EnableForce<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="CorFlagsSettings.Force"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Force))]
    public static T DisableForce<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="CorFlagsSettings.Force"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region Assembly
    /// <inheritdoc cref="CorFlagsSettings.Assembly"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Assembly))]
    public static T SetAssembly<T>(this T o, string v) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Assembly, v));
    /// <inheritdoc cref="CorFlagsSettings.Assembly"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Assembly))]
    public static T ResetAssembly<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Remove(() => o.Assembly));
    #endregion
    #region ILOnly
    /// <inheritdoc cref="CorFlagsSettings.ILOnly"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.ILOnly))]
    public static T SetILOnly<T>(this T o, bool? v) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.ILOnly, v));
    /// <inheritdoc cref="CorFlagsSettings.ILOnly"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.ILOnly))]
    public static T ResetILOnly<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Remove(() => o.ILOnly));
    /// <inheritdoc cref="CorFlagsSettings.ILOnly"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.ILOnly))]
    public static T EnableILOnly<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.ILOnly, true));
    /// <inheritdoc cref="CorFlagsSettings.ILOnly"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.ILOnly))]
    public static T DisableILOnly<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.ILOnly, false));
    /// <inheritdoc cref="CorFlagsSettings.ILOnly"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.ILOnly))]
    public static T ToggleILOnly<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.ILOnly, !o.ILOnly));
    #endregion
    #region Require32Bit
    /// <inheritdoc cref="CorFlagsSettings.Require32Bit"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Require32Bit))]
    public static T SetRequire32Bit<T>(this T o, bool? v) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Require32Bit, v));
    /// <inheritdoc cref="CorFlagsSettings.Require32Bit"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Require32Bit))]
    public static T ResetRequire32Bit<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Remove(() => o.Require32Bit));
    /// <inheritdoc cref="CorFlagsSettings.Require32Bit"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Require32Bit))]
    public static T EnableRequire32Bit<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Require32Bit, true));
    /// <inheritdoc cref="CorFlagsSettings.Require32Bit"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Require32Bit))]
    public static T DisableRequire32Bit<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Require32Bit, false));
    /// <inheritdoc cref="CorFlagsSettings.Require32Bit"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Require32Bit))]
    public static T ToggleRequire32Bit<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Require32Bit, !o.Require32Bit));
    #endregion
    #region Prefer32Bit
    /// <inheritdoc cref="CorFlagsSettings.Prefer32Bit"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Prefer32Bit))]
    public static T SetPrefer32Bit<T>(this T o, bool? v) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Prefer32Bit, v));
    /// <inheritdoc cref="CorFlagsSettings.Prefer32Bit"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Prefer32Bit))]
    public static T ResetPrefer32Bit<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Remove(() => o.Prefer32Bit));
    /// <inheritdoc cref="CorFlagsSettings.Prefer32Bit"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Prefer32Bit))]
    public static T EnablePrefer32Bit<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Prefer32Bit, true));
    /// <inheritdoc cref="CorFlagsSettings.Prefer32Bit"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Prefer32Bit))]
    public static T DisablePrefer32Bit<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Prefer32Bit, false));
    /// <inheritdoc cref="CorFlagsSettings.Prefer32Bit"/>
    [Pure] [Builder(Type = typeof(CorFlagsSettings), Property = nameof(CorFlagsSettings.Prefer32Bit))]
    public static T TogglePrefer32Bit<T>(this T o) where T : CorFlagsSettings => o.Modify(b => b.Set(() => o.Prefer32Bit, !o.Prefer32Bit));
    #endregion
}
#endregion
