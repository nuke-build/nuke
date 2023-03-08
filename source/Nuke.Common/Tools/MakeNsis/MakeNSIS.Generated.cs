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

namespace Nuke.Common.Tools.MakeNSIS
{
    /// <summary>
    ///   <p>NSIS creates installers that are capable of installing, uninstalling, setting system settings, extracting files, etc. Because it's based on script files you can fully control every part of your installer.</p>
    ///   <p>For more details, visit the <a href="https://nsis.sourceforge.io/Docs/Contents.html">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [PathToolRequirement(MakeNSISPathExecutable)]
    public partial class MakeNSISTasks
        : IRequirePathTool
    {
        public const string MakeNSISPathExecutable = "makensis";
        /// <summary>
        ///   Path to the MakeNSIS executable.
        /// </summary>
        public static string MakeNSISPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("MAKENSIS_EXE") ??
            ToolPathResolver.GetPathExecutable("makensis");
        public static Action<OutputType, string> MakeNSISLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>NSIS creates installers that are capable of installing, uninstalling, setting system settings, extracting files, etc. Because it's based on script files you can fully control every part of your installer.</p>
        ///   <p>For more details, visit the <a href="https://nsis.sourceforge.io/Docs/Contents.html">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> MakeNSIS(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(MakeNSISPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? MakeNSISLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>NSIS creates installers that are capable of installing, uninstalling, setting system settings, extracting files, etc. Because it's based on script files you can fully control every part of your installer.</p>
        ///   <p>For more details, visit the <a href="https://nsis.sourceforge.io/Docs/Contents.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;scriptFile&gt;</c> via <see cref="MakeNSISSettings.ScriptFile"/></li>
        ///     <li><c>/D</c> via <see cref="MakeNSISSettings.DefinedSymbols"/></li>
        ///     <li><c>/INPUTCHARSET</c> via <see cref="MakeNSISSettings.InputCharset"/></li>
        ///     <li><c>/NOCD</c> via <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></li>
        ///     <li><c>/NOCONFIG</c> via <see cref="MakeNSISSettings.NoConfig"/></li>
        ///     <li><c>/O</c> via <see cref="MakeNSISSettings.LogOutputFile"/></li>
        ///     <li><c>/OUTPUTCHARSET</c> via <see cref="MakeNSISSettings.OutputCharset"/></li>
        ///     <li><c>/P</c> via <see cref="MakeNSISSettings.CompilerPriority"/></li>
        ///     <li><c>/PPO</c> via <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></li>
        ///     <li><c>/SAFEPPO</c> via <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></li>
        ///     <li><c>/V</c> via <see cref="MakeNSISSettings.Verbosity"/></li>
        ///     <li><c>/WX</c> via <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></li>
        ///     <li><c>/X</c> via <see cref="MakeNSISSettings.PreExecutionCodes"/></li>
        ///     <li><c>/X</c> via <see cref="MakeNSISSettings.PostExecutionCodes"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> MakeNSIS(MakeNSISSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new MakeNSISSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>NSIS creates installers that are capable of installing, uninstalling, setting system settings, extracting files, etc. Because it's based on script files you can fully control every part of your installer.</p>
        ///   <p>For more details, visit the <a href="https://nsis.sourceforge.io/Docs/Contents.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;scriptFile&gt;</c> via <see cref="MakeNSISSettings.ScriptFile"/></li>
        ///     <li><c>/D</c> via <see cref="MakeNSISSettings.DefinedSymbols"/></li>
        ///     <li><c>/INPUTCHARSET</c> via <see cref="MakeNSISSettings.InputCharset"/></li>
        ///     <li><c>/NOCD</c> via <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></li>
        ///     <li><c>/NOCONFIG</c> via <see cref="MakeNSISSettings.NoConfig"/></li>
        ///     <li><c>/O</c> via <see cref="MakeNSISSettings.LogOutputFile"/></li>
        ///     <li><c>/OUTPUTCHARSET</c> via <see cref="MakeNSISSettings.OutputCharset"/></li>
        ///     <li><c>/P</c> via <see cref="MakeNSISSettings.CompilerPriority"/></li>
        ///     <li><c>/PPO</c> via <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></li>
        ///     <li><c>/SAFEPPO</c> via <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></li>
        ///     <li><c>/V</c> via <see cref="MakeNSISSettings.Verbosity"/></li>
        ///     <li><c>/WX</c> via <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></li>
        ///     <li><c>/X</c> via <see cref="MakeNSISSettings.PreExecutionCodes"/></li>
        ///     <li><c>/X</c> via <see cref="MakeNSISSettings.PostExecutionCodes"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> MakeNSIS(Configure<MakeNSISSettings> configurator)
        {
            return MakeNSIS(configurator(new MakeNSISSettings()));
        }
        /// <summary>
        ///   <p>NSIS creates installers that are capable of installing, uninstalling, setting system settings, extracting files, etc. Because it's based on script files you can fully control every part of your installer.</p>
        ///   <p>For more details, visit the <a href="https://nsis.sourceforge.io/Docs/Contents.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;scriptFile&gt;</c> via <see cref="MakeNSISSettings.ScriptFile"/></li>
        ///     <li><c>/D</c> via <see cref="MakeNSISSettings.DefinedSymbols"/></li>
        ///     <li><c>/INPUTCHARSET</c> via <see cref="MakeNSISSettings.InputCharset"/></li>
        ///     <li><c>/NOCD</c> via <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></li>
        ///     <li><c>/NOCONFIG</c> via <see cref="MakeNSISSettings.NoConfig"/></li>
        ///     <li><c>/O</c> via <see cref="MakeNSISSettings.LogOutputFile"/></li>
        ///     <li><c>/OUTPUTCHARSET</c> via <see cref="MakeNSISSettings.OutputCharset"/></li>
        ///     <li><c>/P</c> via <see cref="MakeNSISSettings.CompilerPriority"/></li>
        ///     <li><c>/PPO</c> via <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></li>
        ///     <li><c>/SAFEPPO</c> via <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></li>
        ///     <li><c>/V</c> via <see cref="MakeNSISSettings.Verbosity"/></li>
        ///     <li><c>/WX</c> via <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></li>
        ///     <li><c>/X</c> via <see cref="MakeNSISSettings.PreExecutionCodes"/></li>
        ///     <li><c>/X</c> via <see cref="MakeNSISSettings.PostExecutionCodes"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(MakeNSISSettings Settings, IReadOnlyCollection<Output> Output)> MakeNSIS(CombinatorialConfigure<MakeNSISSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(MakeNSIS, MakeNSISLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region MakeNSISSettings
    /// <summary>
    ///   Used within <see cref="MakeNSISTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class MakeNSISSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the MakeNSIS executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? MakeNSISTasks.MakeNSISPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? MakeNSISTasks.MakeNSISLogger;
        /// <summary>
        ///   0=no output, 1=errors only, 2=warnings and errors, 3=info, warnings, and errors, 4=all output.
        /// </summary>
        public virtual int? Verbosity { get; internal set; }
        /// <summary>
        ///   set the priority of the compiler process accordingly. 0=idle, 1=below normal, 2=normal (default), 3=above normal, 4=high, 5=realtime.
        /// </summary>
        public virtual int? CompilerPriority { get; internal set; }
        /// <summary>
        ///   Tells the compiler to print its log to that file (instead of the screen).
        /// </summary>
        public virtual string LogOutputFile { get; internal set; }
        /// <summary>
        ///   disables inclusion of nsisconf.nsh. Without this parameter, installer defaults are set from nsisconf.nsh.
        /// </summary>
        public virtual bool? NoConfig { get; internal set; }
        /// <summary>
        ///   disables the current directory change to that of the .nsi file.
        /// </summary>
        public virtual bool? NoCurrentDirectoryChange { get; internal set; }
        /// <summary>
        ///   Allows you to specify a specific codepage for files without a BOM. (<c>ACP</c>|<c>OEM</c>|<c>CP#</c>|<c>UTF8</c>|<c>UTF16</c>&lt;LE|BE&gt;).
        /// </summary>
        public virtual string InputCharset { get; internal set; }
        /// <summary>
        ///   Allows you to specify the codepage used by stdout when the output is redirected. (<c>ACP</c>|<c>OEM</c>|<c>CP#</c>|<c>UTF8[SIG]</c>|<c>UTF16&lt;LE|BE&gt;[BOM]</c>)
        /// </summary>
        public virtual string OutputCharset { get; internal set; }
        /// <summary>
        ///   Will only run the preprocessor and print the result to stdout.
        /// </summary>
        public virtual bool? OnlyRunPreprocessor { get; internal set; }
        /// <summary>
        ///   Will only run the preprocessor and print the result to stdout. The safe version will not execute instructions like <c>!appendfile</c> or <c>!system</c>. <c>!packhdr</c> and !finalize are never executed.
        /// </summary>
        public virtual bool? OnlyRunSaveVersionPreprocessor { get; internal set; }
        /// <summary>
        ///   Treats warnings as errors.
        /// </summary>
        public virtual bool? TreatWarningsAsErrors { get; internal set; }
        /// <summary>
        ///   One or more times will add to symbols to the globally defined list (See <c>!define</c>).
        /// </summary>
        public virtual IReadOnlyList<string> DefinedSymbols => DefinedSymbolsInternal.AsReadOnly();
        internal List<string> DefinedSymbolsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   One or more times will execute the code you specify following it.
        /// </summary>
        public virtual IReadOnlyList<string> PreExecutionCodes => PreExecutionCodesInternal.AsReadOnly();
        internal List<string> PreExecutionCodesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   The <c>.nsi</c> script file to compile.
        /// </summary>
        public virtual string ScriptFile { get; internal set; }
        /// <summary>
        ///   One or more times will execute the code you specify following it.
        /// </summary>
        public virtual IReadOnlyList<string> PostExecutionCodes => PostExecutionCodesInternal.AsReadOnly();
        internal List<string> PostExecutionCodesInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("/V{value}", Verbosity)
              .Add("/P{value}", CompilerPriority)
              .Add("/O{value}", LogOutputFile)
              .Add("/NOCONFIG", NoConfig)
              .Add("/NOCD", NoCurrentDirectoryChange)
              .Add("/INPUTCHARSET{value}", InputCharset)
              .Add("/OUTPUTCHARSET{value}", OutputCharset)
              .Add("/PPO", OnlyRunPreprocessor)
              .Add("/SAFEPPO", OnlyRunSaveVersionPreprocessor)
              .Add("/WX", TreatWarningsAsErrors)
              .Add("/D{value}", DefinedSymbols)
              .Add("/X{value}", PreExecutionCodes)
              .Add("{value}", ScriptFile)
              .Add("/X{value}", PostExecutionCodes);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region MakeNSISSettingsExtensions
    /// <summary>
    ///   Used within <see cref="MakeNSISTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MakeNSISSettingsExtensions
    {
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.Verbosity"/></em></p>
        ///   <p>0=no output, 1=errors only, 2=warnings and errors, 3=info, warnings, and errors, 4=all output.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, int? verbosity) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.Verbosity"/></em></p>
        ///   <p>0=no output, 1=errors only, 2=warnings and errors, 3=info, warnings, and errors, 4=all output.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region CompilerPriority
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.CompilerPriority"/></em></p>
        ///   <p>set the priority of the compiler process accordingly. 0=idle, 1=below normal, 2=normal (default), 3=above normal, 4=high, 5=realtime.</p>
        /// </summary>
        [Pure]
        public static T SetCompilerPriority<T>(this T toolSettings, int? compilerPriority) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompilerPriority = compilerPriority;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.CompilerPriority"/></em></p>
        ///   <p>set the priority of the compiler process accordingly. 0=idle, 1=below normal, 2=normal (default), 3=above normal, 4=high, 5=realtime.</p>
        /// </summary>
        [Pure]
        public static T ResetCompilerPriority<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompilerPriority = null;
            return toolSettings;
        }
        #endregion
        #region LogOutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.LogOutputFile"/></em></p>
        ///   <p>Tells the compiler to print its log to that file (instead of the screen).</p>
        /// </summary>
        [Pure]
        public static T SetLogOutputFile<T>(this T toolSettings, string logOutputFile) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogOutputFile = logOutputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.LogOutputFile"/></em></p>
        ///   <p>Tells the compiler to print its log to that file (instead of the screen).</p>
        /// </summary>
        [Pure]
        public static T ResetLogOutputFile<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogOutputFile = null;
            return toolSettings;
        }
        #endregion
        #region NoConfig
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.NoConfig"/></em></p>
        ///   <p>disables inclusion of nsisconf.nsh. Without this parameter, installer defaults are set from nsisconf.nsh.</p>
        /// </summary>
        [Pure]
        public static T SetNoConfig<T>(this T toolSettings, bool? noConfig) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConfig = noConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.NoConfig"/></em></p>
        ///   <p>disables inclusion of nsisconf.nsh. Without this parameter, installer defaults are set from nsisconf.nsh.</p>
        /// </summary>
        [Pure]
        public static T ResetNoConfig<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConfig = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MakeNSISSettings.NoConfig"/></em></p>
        ///   <p>disables inclusion of nsisconf.nsh. Without this parameter, installer defaults are set from nsisconf.nsh.</p>
        /// </summary>
        [Pure]
        public static T EnableNoConfig<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConfig = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MakeNSISSettings.NoConfig"/></em></p>
        ///   <p>disables inclusion of nsisconf.nsh. Without this parameter, installer defaults are set from nsisconf.nsh.</p>
        /// </summary>
        [Pure]
        public static T DisableNoConfig<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConfig = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MakeNSISSettings.NoConfig"/></em></p>
        ///   <p>disables inclusion of nsisconf.nsh. Without this parameter, installer defaults are set from nsisconf.nsh.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoConfig<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConfig = !toolSettings.NoConfig;
            return toolSettings;
        }
        #endregion
        #region NoCurrentDirectoryChange
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></em></p>
        ///   <p>disables the current directory change to that of the .nsi file.</p>
        /// </summary>
        [Pure]
        public static T SetNoCurrentDirectoryChange<T>(this T toolSettings, bool? noCurrentDirectoryChange) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCurrentDirectoryChange = noCurrentDirectoryChange;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></em></p>
        ///   <p>disables the current directory change to that of the .nsi file.</p>
        /// </summary>
        [Pure]
        public static T ResetNoCurrentDirectoryChange<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCurrentDirectoryChange = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></em></p>
        ///   <p>disables the current directory change to that of the .nsi file.</p>
        /// </summary>
        [Pure]
        public static T EnableNoCurrentDirectoryChange<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCurrentDirectoryChange = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></em></p>
        ///   <p>disables the current directory change to that of the .nsi file.</p>
        /// </summary>
        [Pure]
        public static T DisableNoCurrentDirectoryChange<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCurrentDirectoryChange = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MakeNSISSettings.NoCurrentDirectoryChange"/></em></p>
        ///   <p>disables the current directory change to that of the .nsi file.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoCurrentDirectoryChange<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCurrentDirectoryChange = !toolSettings.NoCurrentDirectoryChange;
            return toolSettings;
        }
        #endregion
        #region InputCharset
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.InputCharset"/></em></p>
        ///   <p>Allows you to specify a specific codepage for files without a BOM. (<c>ACP</c>|<c>OEM</c>|<c>CP#</c>|<c>UTF8</c>|<c>UTF16</c>&lt;LE|BE&gt;).</p>
        /// </summary>
        [Pure]
        public static T SetInputCharset<T>(this T toolSettings, string inputCharset) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputCharset = inputCharset;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.InputCharset"/></em></p>
        ///   <p>Allows you to specify a specific codepage for files without a BOM. (<c>ACP</c>|<c>OEM</c>|<c>CP#</c>|<c>UTF8</c>|<c>UTF16</c>&lt;LE|BE&gt;).</p>
        /// </summary>
        [Pure]
        public static T ResetInputCharset<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputCharset = null;
            return toolSettings;
        }
        #endregion
        #region OutputCharset
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.OutputCharset"/></em></p>
        ///   <p>Allows you to specify the codepage used by stdout when the output is redirected. (<c>ACP</c>|<c>OEM</c>|<c>CP#</c>|<c>UTF8[SIG]</c>|<c>UTF16&lt;LE|BE&gt;[BOM]</c>)</p>
        /// </summary>
        [Pure]
        public static T SetOutputCharset<T>(this T toolSettings, string outputCharset) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputCharset = outputCharset;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.OutputCharset"/></em></p>
        ///   <p>Allows you to specify the codepage used by stdout when the output is redirected. (<c>ACP</c>|<c>OEM</c>|<c>CP#</c>|<c>UTF8[SIG]</c>|<c>UTF16&lt;LE|BE&gt;[BOM]</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetOutputCharset<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputCharset = null;
            return toolSettings;
        }
        #endregion
        #region OnlyRunPreprocessor
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></em></p>
        ///   <p>Will only run the preprocessor and print the result to stdout.</p>
        /// </summary>
        [Pure]
        public static T SetOnlyRunPreprocessor<T>(this T toolSettings, bool? onlyRunPreprocessor) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyRunPreprocessor = onlyRunPreprocessor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></em></p>
        ///   <p>Will only run the preprocessor and print the result to stdout.</p>
        /// </summary>
        [Pure]
        public static T ResetOnlyRunPreprocessor<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyRunPreprocessor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></em></p>
        ///   <p>Will only run the preprocessor and print the result to stdout.</p>
        /// </summary>
        [Pure]
        public static T EnableOnlyRunPreprocessor<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyRunPreprocessor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></em></p>
        ///   <p>Will only run the preprocessor and print the result to stdout.</p>
        /// </summary>
        [Pure]
        public static T DisableOnlyRunPreprocessor<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyRunPreprocessor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MakeNSISSettings.OnlyRunPreprocessor"/></em></p>
        ///   <p>Will only run the preprocessor and print the result to stdout.</p>
        /// </summary>
        [Pure]
        public static T ToggleOnlyRunPreprocessor<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyRunPreprocessor = !toolSettings.OnlyRunPreprocessor;
            return toolSettings;
        }
        #endregion
        #region OnlyRunSaveVersionPreprocessor
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></em></p>
        ///   <p>Will only run the preprocessor and print the result to stdout. The safe version will not execute instructions like <c>!appendfile</c> or <c>!system</c>. <c>!packhdr</c> and !finalize are never executed.</p>
        /// </summary>
        [Pure]
        public static T SetOnlyRunSaveVersionPreprocessor<T>(this T toolSettings, bool? onlyRunSaveVersionPreprocessor) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyRunSaveVersionPreprocessor = onlyRunSaveVersionPreprocessor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></em></p>
        ///   <p>Will only run the preprocessor and print the result to stdout. The safe version will not execute instructions like <c>!appendfile</c> or <c>!system</c>. <c>!packhdr</c> and !finalize are never executed.</p>
        /// </summary>
        [Pure]
        public static T ResetOnlyRunSaveVersionPreprocessor<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyRunSaveVersionPreprocessor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></em></p>
        ///   <p>Will only run the preprocessor and print the result to stdout. The safe version will not execute instructions like <c>!appendfile</c> or <c>!system</c>. <c>!packhdr</c> and !finalize are never executed.</p>
        /// </summary>
        [Pure]
        public static T EnableOnlyRunSaveVersionPreprocessor<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyRunSaveVersionPreprocessor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></em></p>
        ///   <p>Will only run the preprocessor and print the result to stdout. The safe version will not execute instructions like <c>!appendfile</c> or <c>!system</c>. <c>!packhdr</c> and !finalize are never executed.</p>
        /// </summary>
        [Pure]
        public static T DisableOnlyRunSaveVersionPreprocessor<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyRunSaveVersionPreprocessor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MakeNSISSettings.OnlyRunSaveVersionPreprocessor"/></em></p>
        ///   <p>Will only run the preprocessor and print the result to stdout. The safe version will not execute instructions like <c>!appendfile</c> or <c>!system</c>. <c>!packhdr</c> and !finalize are never executed.</p>
        /// </summary>
        [Pure]
        public static T ToggleOnlyRunSaveVersionPreprocessor<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyRunSaveVersionPreprocessor = !toolSettings.OnlyRunSaveVersionPreprocessor;
            return toolSettings;
        }
        #endregion
        #region TreatWarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></em></p>
        ///   <p>Treats warnings as errors.</p>
        /// </summary>
        [Pure]
        public static T SetTreatWarningsAsErrors<T>(this T toolSettings, bool? treatWarningsAsErrors) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TreatWarningsAsErrors = treatWarningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></em></p>
        ///   <p>Treats warnings as errors.</p>
        /// </summary>
        [Pure]
        public static T ResetTreatWarningsAsErrors<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TreatWarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></em></p>
        ///   <p>Treats warnings as errors.</p>
        /// </summary>
        [Pure]
        public static T EnableTreatWarningsAsErrors<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TreatWarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></em></p>
        ///   <p>Treats warnings as errors.</p>
        /// </summary>
        [Pure]
        public static T DisableTreatWarningsAsErrors<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TreatWarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MakeNSISSettings.TreatWarningsAsErrors"/></em></p>
        ///   <p>Treats warnings as errors.</p>
        /// </summary>
        [Pure]
        public static T ToggleTreatWarningsAsErrors<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TreatWarningsAsErrors = !toolSettings.TreatWarningsAsErrors;
            return toolSettings;
        }
        #endregion
        #region DefinedSymbols
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.DefinedSymbols"/> to a new list</em></p>
        ///   <p>One or more times will add to symbols to the globally defined list (See <c>!define</c>).</p>
        /// </summary>
        [Pure]
        public static T SetDefinedSymbols<T>(this T toolSettings, params string[] definedSymbols) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefinedSymbolsInternal = definedSymbols.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.DefinedSymbols"/> to a new list</em></p>
        ///   <p>One or more times will add to symbols to the globally defined list (See <c>!define</c>).</p>
        /// </summary>
        [Pure]
        public static T SetDefinedSymbols<T>(this T toolSettings, IEnumerable<string> definedSymbols) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefinedSymbolsInternal = definedSymbols.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MakeNSISSettings.DefinedSymbols"/></em></p>
        ///   <p>One or more times will add to symbols to the globally defined list (See <c>!define</c>).</p>
        /// </summary>
        [Pure]
        public static T AddDefinedSymbols<T>(this T toolSettings, params string[] definedSymbols) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefinedSymbolsInternal.AddRange(definedSymbols);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MakeNSISSettings.DefinedSymbols"/></em></p>
        ///   <p>One or more times will add to symbols to the globally defined list (See <c>!define</c>).</p>
        /// </summary>
        [Pure]
        public static T AddDefinedSymbols<T>(this T toolSettings, IEnumerable<string> definedSymbols) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefinedSymbolsInternal.AddRange(definedSymbols);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MakeNSISSettings.DefinedSymbols"/></em></p>
        ///   <p>One or more times will add to symbols to the globally defined list (See <c>!define</c>).</p>
        /// </summary>
        [Pure]
        public static T ClearDefinedSymbols<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefinedSymbolsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MakeNSISSettings.DefinedSymbols"/></em></p>
        ///   <p>One or more times will add to symbols to the globally defined list (See <c>!define</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveDefinedSymbols<T>(this T toolSettings, params string[] definedSymbols) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(definedSymbols);
            toolSettings.DefinedSymbolsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MakeNSISSettings.DefinedSymbols"/></em></p>
        ///   <p>One or more times will add to symbols to the globally defined list (See <c>!define</c>).</p>
        /// </summary>
        [Pure]
        public static T RemoveDefinedSymbols<T>(this T toolSettings, IEnumerable<string> definedSymbols) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(definedSymbols);
            toolSettings.DefinedSymbolsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region PreExecutionCodes
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.PreExecutionCodes"/> to a new list</em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T SetPreExecutionCodes<T>(this T toolSettings, params string[] preExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreExecutionCodesInternal = preExecutionCodes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.PreExecutionCodes"/> to a new list</em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T SetPreExecutionCodes<T>(this T toolSettings, IEnumerable<string> preExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreExecutionCodesInternal = preExecutionCodes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MakeNSISSettings.PreExecutionCodes"/></em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T AddPreExecutionCodes<T>(this T toolSettings, params string[] preExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreExecutionCodesInternal.AddRange(preExecutionCodes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MakeNSISSettings.PreExecutionCodes"/></em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T AddPreExecutionCodes<T>(this T toolSettings, IEnumerable<string> preExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreExecutionCodesInternal.AddRange(preExecutionCodes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MakeNSISSettings.PreExecutionCodes"/></em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T ClearPreExecutionCodes<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreExecutionCodesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MakeNSISSettings.PreExecutionCodes"/></em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T RemovePreExecutionCodes<T>(this T toolSettings, params string[] preExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(preExecutionCodes);
            toolSettings.PreExecutionCodesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MakeNSISSettings.PreExecutionCodes"/></em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T RemovePreExecutionCodes<T>(this T toolSettings, IEnumerable<string> preExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(preExecutionCodes);
            toolSettings.PreExecutionCodesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ScriptFile
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.ScriptFile"/></em></p>
        ///   <p>The <c>.nsi</c> script file to compile.</p>
        /// </summary>
        [Pure]
        public static T SetScriptFile<T>(this T toolSettings, string scriptFile) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScriptFile = scriptFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MakeNSISSettings.ScriptFile"/></em></p>
        ///   <p>The <c>.nsi</c> script file to compile.</p>
        /// </summary>
        [Pure]
        public static T ResetScriptFile<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScriptFile = null;
            return toolSettings;
        }
        #endregion
        #region PostExecutionCodes
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.PostExecutionCodes"/> to a new list</em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T SetPostExecutionCodes<T>(this T toolSettings, params string[] postExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostExecutionCodesInternal = postExecutionCodes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MakeNSISSettings.PostExecutionCodes"/> to a new list</em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T SetPostExecutionCodes<T>(this T toolSettings, IEnumerable<string> postExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostExecutionCodesInternal = postExecutionCodes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MakeNSISSettings.PostExecutionCodes"/></em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T AddPostExecutionCodes<T>(this T toolSettings, params string[] postExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostExecutionCodesInternal.AddRange(postExecutionCodes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MakeNSISSettings.PostExecutionCodes"/></em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T AddPostExecutionCodes<T>(this T toolSettings, IEnumerable<string> postExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostExecutionCodesInternal.AddRange(postExecutionCodes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MakeNSISSettings.PostExecutionCodes"/></em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T ClearPostExecutionCodes<T>(this T toolSettings) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostExecutionCodesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MakeNSISSettings.PostExecutionCodes"/></em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T RemovePostExecutionCodes<T>(this T toolSettings, params string[] postExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(postExecutionCodes);
            toolSettings.PostExecutionCodesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MakeNSISSettings.PostExecutionCodes"/></em></p>
        ///   <p>One or more times will execute the code you specify following it.</p>
        /// </summary>
        [Pure]
        public static T RemovePostExecutionCodes<T>(this T toolSettings, IEnumerable<string> postExecutionCodes) where T : MakeNSISSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(postExecutionCodes);
            toolSettings.PostExecutionCodesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
