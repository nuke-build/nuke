// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/MakeNsis/MakeNSIS.json

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

namespace Nuke.Common.Tools.MakeNSIS;

/// <summary><p>NSIS creates installers that are capable of installing, uninstalling, setting system settings, extracting files, etc. Because it's based on script files you can fully control every part of your installer.</p><p>For more details, visit the <a href="https://nsis.sourceforge.io/Docs/Contents.html">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathToolRequirement(PathExecutable)]
[PathTool(Executable = PathExecutable)]
public partial class MakeNSISTasks : ToolTasks, IRequirePathTool
{
    public static string MakeNSISPath => new MakeNSISTasks().GetToolPath();
    public const string PathExecutable = "makensis";
    /// <summary><p>NSIS creates installers that are capable of installing, uninstalling, setting system settings, extracting files, etc. Because it's based on script files you can fully control every part of your installer.</p><p>For more details, visit the <a href="https://nsis.sourceforge.io/Docs/Contents.html">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> MakeNSIS(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new MakeNSISTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>NSIS creates installers that are capable of installing, uninstalling, setting system settings, extracting files, etc. Because it's based on script files you can fully control every part of your installer.</p><p>For more details, visit the <a href="https://nsis.sourceforge.io/Docs/Contents.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;scriptFile&gt;</c> via <see cref="MakeNSISSettings.ScriptFile"/></li><li><c>/D</c> via <see cref="MakeNSISSettings.DefinedSymbols"/></li><li><c>/INPUTCHARSET</c> via <see cref="MakeNSISSettings.InputCharset"/></li><li><c>/NOCD</c> via <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></li><li><c>/NOCONFIG</c> via <see cref="MakeNSISSettings.NoConfig"/></li><li><c>/O</c> via <see cref="MakeNSISSettings.LogOutputFile"/></li><li><c>/OUTPUTCHARSET</c> via <see cref="MakeNSISSettings.OutputCharset"/></li><li><c>/P</c> via <see cref="MakeNSISSettings.CompilerPriority"/></li><li><c>/PPO</c> via <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></li><li><c>/SAFEPPO</c> via <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></li><li><c>/V</c> via <see cref="MakeNSISSettings.Verbosity"/></li><li><c>/WX</c> via <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></li><li><c>/X</c> via <see cref="MakeNSISSettings.PreExecutionCodes"/></li><li><c>/X</c> via <see cref="MakeNSISSettings.PostExecutionCodes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> MakeNSIS(MakeNSISSettings options = null) => new MakeNSISTasks().Run(options);
    /// <summary><p>NSIS creates installers that are capable of installing, uninstalling, setting system settings, extracting files, etc. Because it's based on script files you can fully control every part of your installer.</p><p>For more details, visit the <a href="https://nsis.sourceforge.io/Docs/Contents.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;scriptFile&gt;</c> via <see cref="MakeNSISSettings.ScriptFile"/></li><li><c>/D</c> via <see cref="MakeNSISSettings.DefinedSymbols"/></li><li><c>/INPUTCHARSET</c> via <see cref="MakeNSISSettings.InputCharset"/></li><li><c>/NOCD</c> via <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></li><li><c>/NOCONFIG</c> via <see cref="MakeNSISSettings.NoConfig"/></li><li><c>/O</c> via <see cref="MakeNSISSettings.LogOutputFile"/></li><li><c>/OUTPUTCHARSET</c> via <see cref="MakeNSISSettings.OutputCharset"/></li><li><c>/P</c> via <see cref="MakeNSISSettings.CompilerPriority"/></li><li><c>/PPO</c> via <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></li><li><c>/SAFEPPO</c> via <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></li><li><c>/V</c> via <see cref="MakeNSISSettings.Verbosity"/></li><li><c>/WX</c> via <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></li><li><c>/X</c> via <see cref="MakeNSISSettings.PreExecutionCodes"/></li><li><c>/X</c> via <see cref="MakeNSISSettings.PostExecutionCodes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> MakeNSIS(Configure<MakeNSISSettings> configurator) => new MakeNSISTasks().Run(configurator.Invoke(new MakeNSISSettings()));
    /// <summary><p>NSIS creates installers that are capable of installing, uninstalling, setting system settings, extracting files, etc. Because it's based on script files you can fully control every part of your installer.</p><p>For more details, visit the <a href="https://nsis.sourceforge.io/Docs/Contents.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;scriptFile&gt;</c> via <see cref="MakeNSISSettings.ScriptFile"/></li><li><c>/D</c> via <see cref="MakeNSISSettings.DefinedSymbols"/></li><li><c>/INPUTCHARSET</c> via <see cref="MakeNSISSettings.InputCharset"/></li><li><c>/NOCD</c> via <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></li><li><c>/NOCONFIG</c> via <see cref="MakeNSISSettings.NoConfig"/></li><li><c>/O</c> via <see cref="MakeNSISSettings.LogOutputFile"/></li><li><c>/OUTPUTCHARSET</c> via <see cref="MakeNSISSettings.OutputCharset"/></li><li><c>/P</c> via <see cref="MakeNSISSettings.CompilerPriority"/></li><li><c>/PPO</c> via <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></li><li><c>/SAFEPPO</c> via <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></li><li><c>/V</c> via <see cref="MakeNSISSettings.Verbosity"/></li><li><c>/WX</c> via <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></li><li><c>/X</c> via <see cref="MakeNSISSettings.PreExecutionCodes"/></li><li><c>/X</c> via <see cref="MakeNSISSettings.PostExecutionCodes"/></li></ul></remarks>
    public static IEnumerable<(MakeNSISSettings Settings, IReadOnlyCollection<Output> Output)> MakeNSIS(CombinatorialConfigure<MakeNSISSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(MakeNSIS, degreeOfParallelism, completeOnFailure);
}
#region MakeNSISSettings
/// <summary>Used within <see cref="MakeNSISTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MakeNSISSettings>))]
[Command(Type = typeof(MakeNSISTasks), Command = nameof(MakeNSISTasks.MakeNSIS))]
public partial class MakeNSISSettings : ToolOptions
{
    /// <summary>0=no output, 1=errors only, 2=warnings and errors, 3=info, warnings, and errors, 4=all output.</summary>
    [Argument(Format = "/V{value}")] public int? Verbosity => Get<int?>(() => Verbosity);
    /// <summary>set the priority of the compiler process accordingly. 0=idle, 1=below normal, 2=normal (default), 3=above normal, 4=high, 5=realtime.</summary>
    [Argument(Format = "/P{value}")] public int? CompilerPriority => Get<int?>(() => CompilerPriority);
    /// <summary>Tells the compiler to print its log to that file (instead of the screen).</summary>
    [Argument(Format = "/O{value}")] public string LogOutputFile => Get<string>(() => LogOutputFile);
    /// <summary>disables inclusion of nsisconf.nsh. Without this parameter, installer defaults are set from nsisconf.nsh.</summary>
    [Argument(Format = "/NOCONFIG")] public bool? NoConfig => Get<bool?>(() => NoConfig);
    /// <summary>disables the current directory change to that of the .nsi file.</summary>
    [Argument(Format = "/NOCD")] public bool? NoCurrentDirectoryChange => Get<bool?>(() => NoCurrentDirectoryChange);
    /// <summary>Allows you to specify a specific codepage for files without a BOM. (<c>ACP</c>|<c>OEM</c>|<c>CP#</c>|<c>UTF8</c>|<c>UTF16</c>&lt;LE|BE&gt;).</summary>
    [Argument(Format = "/INPUTCHARSET{value}")] public string InputCharset => Get<string>(() => InputCharset);
    /// <summary>Allows you to specify the codepage used by stdout when the output is redirected. (<c>ACP</c>|<c>OEM</c>|<c>CP#</c>|<c>UTF8[SIG]</c>|<c>UTF16&lt;LE|BE&gt;[BOM]</c>)</summary>
    [Argument(Format = "/OUTPUTCHARSET{value}")] public string OutputCharset => Get<string>(() => OutputCharset);
    /// <summary>Will only run the preprocessor and print the result to stdout.</summary>
    [Argument(Format = "/PPO")] public bool? OnlyRunPreprocessor => Get<bool?>(() => OnlyRunPreprocessor);
    /// <summary>Will only run the preprocessor and print the result to stdout. The safe version will not execute instructions like <c>!appendfile</c> or <c>!system</c>. <c>!packhdr</c> and !finalize are never executed.</summary>
    [Argument(Format = "/SAFEPPO")] public bool? OnlyRunSaveVersionPreprocessor => Get<bool?>(() => OnlyRunSaveVersionPreprocessor);
    /// <summary>Treats warnings as errors.</summary>
    [Argument(Format = "/WX")] public bool? TreatWarningsAsErrors => Get<bool?>(() => TreatWarningsAsErrors);
    /// <summary>One or more times will add to symbols to the globally defined list (See <c>!define</c>).</summary>
    [Argument(Format = "/D{value}")] public IReadOnlyList<string> DefinedSymbols => Get<List<string>>(() => DefinedSymbols);
    /// <summary>One or more times will execute the code you specify following it.</summary>
    [Argument(Format = "/X{value}")] public IReadOnlyList<string> PreExecutionCodes => Get<List<string>>(() => PreExecutionCodes);
    /// <summary>The <c>.nsi</c> script file to compile.</summary>
    [Argument(Format = "{value}")] public string ScriptFile => Get<string>(() => ScriptFile);
    /// <summary>One or more times will execute the code you specify following it.</summary>
    [Argument(Format = "/X{value}")] public IReadOnlyList<string> PostExecutionCodes => Get<List<string>>(() => PostExecutionCodes);
}
#endregion
#region MakeNSISSettingsExtensions
/// <summary>Used within <see cref="MakeNSISTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class MakeNSISSettingsExtensions
{
    #region Verbosity
    /// <inheritdoc cref="MakeNSISSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, int? v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="MakeNSISSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region CompilerPriority
    /// <inheritdoc cref="MakeNSISSettings.CompilerPriority"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.CompilerPriority))]
    public static T SetCompilerPriority<T>(this T o, int? v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.CompilerPriority, v));
    /// <inheritdoc cref="MakeNSISSettings.CompilerPriority"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.CompilerPriority))]
    public static T ResetCompilerPriority<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.CompilerPriority));
    #endregion
    #region LogOutputFile
    /// <inheritdoc cref="MakeNSISSettings.LogOutputFile"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.LogOutputFile))]
    public static T SetLogOutputFile<T>(this T o, string v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.LogOutputFile, v));
    /// <inheritdoc cref="MakeNSISSettings.LogOutputFile"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.LogOutputFile))]
    public static T ResetLogOutputFile<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.LogOutputFile));
    #endregion
    #region NoConfig
    /// <inheritdoc cref="MakeNSISSettings.NoConfig"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.NoConfig))]
    public static T SetNoConfig<T>(this T o, bool? v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.NoConfig, v));
    /// <inheritdoc cref="MakeNSISSettings.NoConfig"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.NoConfig))]
    public static T ResetNoConfig<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.NoConfig));
    /// <inheritdoc cref="MakeNSISSettings.NoConfig"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.NoConfig))]
    public static T EnableNoConfig<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.NoConfig, true));
    /// <inheritdoc cref="MakeNSISSettings.NoConfig"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.NoConfig))]
    public static T DisableNoConfig<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.NoConfig, false));
    /// <inheritdoc cref="MakeNSISSettings.NoConfig"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.NoConfig))]
    public static T ToggleNoConfig<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.NoConfig, !o.NoConfig));
    #endregion
    #region NoCurrentDirectoryChange
    /// <inheritdoc cref="MakeNSISSettings.NoCurrentDirectoryChange"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.NoCurrentDirectoryChange))]
    public static T SetNoCurrentDirectoryChange<T>(this T o, bool? v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.NoCurrentDirectoryChange, v));
    /// <inheritdoc cref="MakeNSISSettings.NoCurrentDirectoryChange"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.NoCurrentDirectoryChange))]
    public static T ResetNoCurrentDirectoryChange<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.NoCurrentDirectoryChange));
    /// <inheritdoc cref="MakeNSISSettings.NoCurrentDirectoryChange"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.NoCurrentDirectoryChange))]
    public static T EnableNoCurrentDirectoryChange<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.NoCurrentDirectoryChange, true));
    /// <inheritdoc cref="MakeNSISSettings.NoCurrentDirectoryChange"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.NoCurrentDirectoryChange))]
    public static T DisableNoCurrentDirectoryChange<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.NoCurrentDirectoryChange, false));
    /// <inheritdoc cref="MakeNSISSettings.NoCurrentDirectoryChange"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.NoCurrentDirectoryChange))]
    public static T ToggleNoCurrentDirectoryChange<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.NoCurrentDirectoryChange, !o.NoCurrentDirectoryChange));
    #endregion
    #region InputCharset
    /// <inheritdoc cref="MakeNSISSettings.InputCharset"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.InputCharset))]
    public static T SetInputCharset<T>(this T o, string v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.InputCharset, v));
    /// <inheritdoc cref="MakeNSISSettings.InputCharset"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.InputCharset))]
    public static T ResetInputCharset<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.InputCharset));
    #endregion
    #region OutputCharset
    /// <inheritdoc cref="MakeNSISSettings.OutputCharset"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OutputCharset))]
    public static T SetOutputCharset<T>(this T o, string v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.OutputCharset, v));
    /// <inheritdoc cref="MakeNSISSettings.OutputCharset"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OutputCharset))]
    public static T ResetOutputCharset<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.OutputCharset));
    #endregion
    #region OnlyRunPreprocessor
    /// <inheritdoc cref="MakeNSISSettings.OnlyRunPreprocessor"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OnlyRunPreprocessor))]
    public static T SetOnlyRunPreprocessor<T>(this T o, bool? v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.OnlyRunPreprocessor, v));
    /// <inheritdoc cref="MakeNSISSettings.OnlyRunPreprocessor"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OnlyRunPreprocessor))]
    public static T ResetOnlyRunPreprocessor<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.OnlyRunPreprocessor));
    /// <inheritdoc cref="MakeNSISSettings.OnlyRunPreprocessor"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OnlyRunPreprocessor))]
    public static T EnableOnlyRunPreprocessor<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.OnlyRunPreprocessor, true));
    /// <inheritdoc cref="MakeNSISSettings.OnlyRunPreprocessor"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OnlyRunPreprocessor))]
    public static T DisableOnlyRunPreprocessor<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.OnlyRunPreprocessor, false));
    /// <inheritdoc cref="MakeNSISSettings.OnlyRunPreprocessor"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OnlyRunPreprocessor))]
    public static T ToggleOnlyRunPreprocessor<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.OnlyRunPreprocessor, !o.OnlyRunPreprocessor));
    #endregion
    #region OnlyRunSaveVersionPreprocessor
    /// <inheritdoc cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OnlyRunSaveVersionPreprocessor))]
    public static T SetOnlyRunSaveVersionPreprocessor<T>(this T o, bool? v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.OnlyRunSaveVersionPreprocessor, v));
    /// <inheritdoc cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OnlyRunSaveVersionPreprocessor))]
    public static T ResetOnlyRunSaveVersionPreprocessor<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.OnlyRunSaveVersionPreprocessor));
    /// <inheritdoc cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OnlyRunSaveVersionPreprocessor))]
    public static T EnableOnlyRunSaveVersionPreprocessor<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.OnlyRunSaveVersionPreprocessor, true));
    /// <inheritdoc cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OnlyRunSaveVersionPreprocessor))]
    public static T DisableOnlyRunSaveVersionPreprocessor<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.OnlyRunSaveVersionPreprocessor, false));
    /// <inheritdoc cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.OnlyRunSaveVersionPreprocessor))]
    public static T ToggleOnlyRunSaveVersionPreprocessor<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.OnlyRunSaveVersionPreprocessor, !o.OnlyRunSaveVersionPreprocessor));
    #endregion
    #region TreatWarningsAsErrors
    /// <inheritdoc cref="MakeNSISSettings.TreatWarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.TreatWarningsAsErrors))]
    public static T SetTreatWarningsAsErrors<T>(this T o, bool? v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.TreatWarningsAsErrors, v));
    /// <inheritdoc cref="MakeNSISSettings.TreatWarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.TreatWarningsAsErrors))]
    public static T ResetTreatWarningsAsErrors<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.TreatWarningsAsErrors));
    /// <inheritdoc cref="MakeNSISSettings.TreatWarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.TreatWarningsAsErrors))]
    public static T EnableTreatWarningsAsErrors<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.TreatWarningsAsErrors, true));
    /// <inheritdoc cref="MakeNSISSettings.TreatWarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.TreatWarningsAsErrors))]
    public static T DisableTreatWarningsAsErrors<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.TreatWarningsAsErrors, false));
    /// <inheritdoc cref="MakeNSISSettings.TreatWarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.TreatWarningsAsErrors))]
    public static T ToggleTreatWarningsAsErrors<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.TreatWarningsAsErrors, !o.TreatWarningsAsErrors));
    #endregion
    #region DefinedSymbols
    /// <inheritdoc cref="MakeNSISSettings.DefinedSymbols"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.DefinedSymbols))]
    public static T SetDefinedSymbols<T>(this T o, params string[] v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.DefinedSymbols, v));
    /// <inheritdoc cref="MakeNSISSettings.DefinedSymbols"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.DefinedSymbols))]
    public static T SetDefinedSymbols<T>(this T o, IEnumerable<string> v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.DefinedSymbols, v));
    /// <inheritdoc cref="MakeNSISSettings.DefinedSymbols"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.DefinedSymbols))]
    public static T AddDefinedSymbols<T>(this T o, params string[] v) where T : MakeNSISSettings => o.Modify(b => b.AddCollection(() => o.DefinedSymbols, v));
    /// <inheritdoc cref="MakeNSISSettings.DefinedSymbols"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.DefinedSymbols))]
    public static T AddDefinedSymbols<T>(this T o, IEnumerable<string> v) where T : MakeNSISSettings => o.Modify(b => b.AddCollection(() => o.DefinedSymbols, v));
    /// <inheritdoc cref="MakeNSISSettings.DefinedSymbols"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.DefinedSymbols))]
    public static T RemoveDefinedSymbols<T>(this T o, params string[] v) where T : MakeNSISSettings => o.Modify(b => b.RemoveCollection(() => o.DefinedSymbols, v));
    /// <inheritdoc cref="MakeNSISSettings.DefinedSymbols"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.DefinedSymbols))]
    public static T RemoveDefinedSymbols<T>(this T o, IEnumerable<string> v) where T : MakeNSISSettings => o.Modify(b => b.RemoveCollection(() => o.DefinedSymbols, v));
    /// <inheritdoc cref="MakeNSISSettings.DefinedSymbols"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.DefinedSymbols))]
    public static T ClearDefinedSymbols<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.ClearCollection(() => o.DefinedSymbols));
    #endregion
    #region PreExecutionCodes
    /// <inheritdoc cref="MakeNSISSettings.PreExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PreExecutionCodes))]
    public static T SetPreExecutionCodes<T>(this T o, params string[] v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.PreExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PreExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PreExecutionCodes))]
    public static T SetPreExecutionCodes<T>(this T o, IEnumerable<string> v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.PreExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PreExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PreExecutionCodes))]
    public static T AddPreExecutionCodes<T>(this T o, params string[] v) where T : MakeNSISSettings => o.Modify(b => b.AddCollection(() => o.PreExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PreExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PreExecutionCodes))]
    public static T AddPreExecutionCodes<T>(this T o, IEnumerable<string> v) where T : MakeNSISSettings => o.Modify(b => b.AddCollection(() => o.PreExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PreExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PreExecutionCodes))]
    public static T RemovePreExecutionCodes<T>(this T o, params string[] v) where T : MakeNSISSettings => o.Modify(b => b.RemoveCollection(() => o.PreExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PreExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PreExecutionCodes))]
    public static T RemovePreExecutionCodes<T>(this T o, IEnumerable<string> v) where T : MakeNSISSettings => o.Modify(b => b.RemoveCollection(() => o.PreExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PreExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PreExecutionCodes))]
    public static T ClearPreExecutionCodes<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.ClearCollection(() => o.PreExecutionCodes));
    #endregion
    #region ScriptFile
    /// <inheritdoc cref="MakeNSISSettings.ScriptFile"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.ScriptFile))]
    public static T SetScriptFile<T>(this T o, string v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.ScriptFile, v));
    /// <inheritdoc cref="MakeNSISSettings.ScriptFile"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.ScriptFile))]
    public static T ResetScriptFile<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.Remove(() => o.ScriptFile));
    #endregion
    #region PostExecutionCodes
    /// <inheritdoc cref="MakeNSISSettings.PostExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PostExecutionCodes))]
    public static T SetPostExecutionCodes<T>(this T o, params string[] v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.PostExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PostExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PostExecutionCodes))]
    public static T SetPostExecutionCodes<T>(this T o, IEnumerable<string> v) where T : MakeNSISSettings => o.Modify(b => b.Set(() => o.PostExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PostExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PostExecutionCodes))]
    public static T AddPostExecutionCodes<T>(this T o, params string[] v) where T : MakeNSISSettings => o.Modify(b => b.AddCollection(() => o.PostExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PostExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PostExecutionCodes))]
    public static T AddPostExecutionCodes<T>(this T o, IEnumerable<string> v) where T : MakeNSISSettings => o.Modify(b => b.AddCollection(() => o.PostExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PostExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PostExecutionCodes))]
    public static T RemovePostExecutionCodes<T>(this T o, params string[] v) where T : MakeNSISSettings => o.Modify(b => b.RemoveCollection(() => o.PostExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PostExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PostExecutionCodes))]
    public static T RemovePostExecutionCodes<T>(this T o, IEnumerable<string> v) where T : MakeNSISSettings => o.Modify(b => b.RemoveCollection(() => o.PostExecutionCodes, v));
    /// <inheritdoc cref="MakeNSISSettings.PostExecutionCodes"/>
    [Pure] [Builder(Type = typeof(MakeNSISSettings), Property = nameof(MakeNSISSettings.PostExecutionCodes))]
    public static T ClearPostExecutionCodes<T>(this T o) where T : MakeNSISSettings => o.Modify(b => b.ClearCollection(() => o.PostExecutionCodes));
    #endregion
}
#endregion
