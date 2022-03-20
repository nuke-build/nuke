// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/PowerShellCore/PowerShellCore.json

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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.PowerShellCore
{
    /// <summary>
    ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PowerShellCoreTasks
    {
        /// <summary>
        ///   Path to the PowerShellCore executable.
        /// </summary>
        public static string PowerShellCorePath =>
            ToolPathResolver.TryGetEnvironmentExecutable("POWERSHELLCORE_EXE") ??
            ToolPathResolver.GetPathExecutable("pwsh");
        public static Action<OutputType, string> PowerShellCoreLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> PowerShellCore(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(PowerShellCorePath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, PowerShellCoreLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PowerShellCoreSettings.FileArguments"/></li>
        ///     <li><c>-</c> via <see cref="PowerShellCoreSettings.FileKeyValueParameters"/></li>
        ///     <li><c>-Command</c> via <see cref="PowerShellCoreSettings.Command"/></li>
        ///     <li><c>-ConfigurationName</c> via <see cref="PowerShellCoreSettings.ConfigurationName"/></li>
        ///     <li><c>-CustomPipeName</c> via <see cref="PowerShellCoreSettings.CustomPipeName"/></li>
        ///     <li><c>-EncodedCommand</c> via <see cref="PowerShellCoreSettings.EncodedCommand"/></li>
        ///     <li><c>-ExecutionPolicy</c> via <see cref="PowerShellCoreSettings.ExecutionPolicy"/></li>
        ///     <li><c>-File</c> via <see cref="PowerShellCoreSettings.File"/></li>
        ///     <li><c>-InputFormat</c> via <see cref="PowerShellCoreSettings.InputFormat"/></li>
        ///     <li><c>-MTA</c> via <see cref="PowerShellCoreSettings.StartUsingAMultiThreadedApartment"/></li>
        ///     <li><c>-NoExit</c> via <see cref="PowerShellCoreSettings.NoExit"/></li>
        ///     <li><c>-NoLogo</c> via <see cref="PowerShellCoreSettings.NoLogo"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="PowerShellCoreSettings.NonInteractive"/></li>
        ///     <li><c>-NoProfile</c> via <see cref="PowerShellCoreSettings.NoProfile"/></li>
        ///     <li><c>-OutputFormat</c> via <see cref="PowerShellCoreSettings.OutputFormat"/></li>
        ///     <li><c>-SettingsFile</c> via <see cref="PowerShellCoreSettings.SettingsFile"/></li>
        ///     <li><c>-STA</c> via <see cref="PowerShellCoreSettings.StartUsingASingleThreadedApartment"/></li>
        ///     <li><c>-Version</c> via <see cref="PowerShellCoreSettings.Version"/></li>
        ///     <li><c>-WindowStyle</c> via <see cref="PowerShellCoreSettings.WindowStyle"/></li>
        ///     <li><c>-WorkingDirectory</c> via <see cref="PowerShellCoreSettings.WorkingDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PowerShellCore(PowerShellCoreSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new PowerShellCoreSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PowerShellCoreSettings.FileArguments"/></li>
        ///     <li><c>-</c> via <see cref="PowerShellCoreSettings.FileKeyValueParameters"/></li>
        ///     <li><c>-Command</c> via <see cref="PowerShellCoreSettings.Command"/></li>
        ///     <li><c>-ConfigurationName</c> via <see cref="PowerShellCoreSettings.ConfigurationName"/></li>
        ///     <li><c>-CustomPipeName</c> via <see cref="PowerShellCoreSettings.CustomPipeName"/></li>
        ///     <li><c>-EncodedCommand</c> via <see cref="PowerShellCoreSettings.EncodedCommand"/></li>
        ///     <li><c>-ExecutionPolicy</c> via <see cref="PowerShellCoreSettings.ExecutionPolicy"/></li>
        ///     <li><c>-File</c> via <see cref="PowerShellCoreSettings.File"/></li>
        ///     <li><c>-InputFormat</c> via <see cref="PowerShellCoreSettings.InputFormat"/></li>
        ///     <li><c>-MTA</c> via <see cref="PowerShellCoreSettings.StartUsingAMultiThreadedApartment"/></li>
        ///     <li><c>-NoExit</c> via <see cref="PowerShellCoreSettings.NoExit"/></li>
        ///     <li><c>-NoLogo</c> via <see cref="PowerShellCoreSettings.NoLogo"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="PowerShellCoreSettings.NonInteractive"/></li>
        ///     <li><c>-NoProfile</c> via <see cref="PowerShellCoreSettings.NoProfile"/></li>
        ///     <li><c>-OutputFormat</c> via <see cref="PowerShellCoreSettings.OutputFormat"/></li>
        ///     <li><c>-SettingsFile</c> via <see cref="PowerShellCoreSettings.SettingsFile"/></li>
        ///     <li><c>-STA</c> via <see cref="PowerShellCoreSettings.StartUsingASingleThreadedApartment"/></li>
        ///     <li><c>-Version</c> via <see cref="PowerShellCoreSettings.Version"/></li>
        ///     <li><c>-WindowStyle</c> via <see cref="PowerShellCoreSettings.WindowStyle"/></li>
        ///     <li><c>-WorkingDirectory</c> via <see cref="PowerShellCoreSettings.WorkingDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PowerShellCore(Configure<PowerShellCoreSettings> configurator)
        {
            return PowerShellCore(configurator(new PowerShellCoreSettings()));
        }
        /// <summary>
        ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PowerShellCoreSettings.FileArguments"/></li>
        ///     <li><c>-</c> via <see cref="PowerShellCoreSettings.FileKeyValueParameters"/></li>
        ///     <li><c>-Command</c> via <see cref="PowerShellCoreSettings.Command"/></li>
        ///     <li><c>-ConfigurationName</c> via <see cref="PowerShellCoreSettings.ConfigurationName"/></li>
        ///     <li><c>-CustomPipeName</c> via <see cref="PowerShellCoreSettings.CustomPipeName"/></li>
        ///     <li><c>-EncodedCommand</c> via <see cref="PowerShellCoreSettings.EncodedCommand"/></li>
        ///     <li><c>-ExecutionPolicy</c> via <see cref="PowerShellCoreSettings.ExecutionPolicy"/></li>
        ///     <li><c>-File</c> via <see cref="PowerShellCoreSettings.File"/></li>
        ///     <li><c>-InputFormat</c> via <see cref="PowerShellCoreSettings.InputFormat"/></li>
        ///     <li><c>-MTA</c> via <see cref="PowerShellCoreSettings.StartUsingAMultiThreadedApartment"/></li>
        ///     <li><c>-NoExit</c> via <see cref="PowerShellCoreSettings.NoExit"/></li>
        ///     <li><c>-NoLogo</c> via <see cref="PowerShellCoreSettings.NoLogo"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="PowerShellCoreSettings.NonInteractive"/></li>
        ///     <li><c>-NoProfile</c> via <see cref="PowerShellCoreSettings.NoProfile"/></li>
        ///     <li><c>-OutputFormat</c> via <see cref="PowerShellCoreSettings.OutputFormat"/></li>
        ///     <li><c>-SettingsFile</c> via <see cref="PowerShellCoreSettings.SettingsFile"/></li>
        ///     <li><c>-STA</c> via <see cref="PowerShellCoreSettings.StartUsingASingleThreadedApartment"/></li>
        ///     <li><c>-Version</c> via <see cref="PowerShellCoreSettings.Version"/></li>
        ///     <li><c>-WindowStyle</c> via <see cref="PowerShellCoreSettings.WindowStyle"/></li>
        ///     <li><c>-WorkingDirectory</c> via <see cref="PowerShellCoreSettings.WorkingDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(PowerShellCoreSettings Settings, IReadOnlyCollection<Output> Output)> PowerShellCore(CombinatorialConfigure<PowerShellCoreSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(PowerShellCore, PowerShellCoreLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region PowerShellCoreSettings
    /// <summary>
    ///   Used within <see cref="PowerShellCoreTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PowerShellCoreSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the PowerShellCore executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? PowerShellCoreTasks.PowerShellCorePath;
        public override Action<OutputType, string> ProcessCustomLogger => PowerShellCoreTasks.PowerShellCoreLogger;
        /// <summary>
        ///   Displays the version of PowerShell. Additional parameters are ignored.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        /// <summary>
        ///   Hides the copyright banner at startup of interactive sessions.
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   Does not exit after running startup commands.
        /// </summary>
        public virtual bool? NoExit { get; internal set; }
        /// <summary>
        ///   Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.
        /// </summary>
        public virtual bool? StartUsingASingleThreadedApartment { get; internal set; }
        /// <summary>
        ///   Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.
        /// </summary>
        public virtual bool? StartUsingAMultiThreadedApartment { get; internal set; }
        /// <summary>
        ///   Does not load the PowerShell profiles.
        /// </summary>
        public virtual bool? NoProfile { get; internal set; }
        /// <summary>
        ///   Does not present an interactive prompt to the user. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement-terminating errors.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Describes the format of data sent to PowerShell. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).
        /// </summary>
        public virtual PowerShellFormat InputFormat { get; internal set; }
        /// <summary>
        ///   Determines how output from PowerShell is formatted. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).<para/>Example: <c>pwsh -o XML -c Get-Date</c><para/>When called withing a PowerShell session, you get deserialized objects as output rather plain strings. When called from other shells, the output is string data formatted as CLIXML text.
        /// </summary>
        public virtual PowerShellFormat OutputFormat { get; internal set; }
        /// <summary>
        ///   Sets the window style for the session. Valid values are Normal, Minimized, Maximized and Hidden.
        /// </summary>
        public virtual PowerShellWindowStyle WindowStyle { get; internal set; }
        /// <summary>
        ///   Accepts a Base64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex, nested quoting. The Base64 representation must be a UTF-16LE encoded string.
        /// </summary>
        public virtual string EncodedCommand { get; internal set; }
        /// <summary>
        ///   Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.
        /// </summary>
        public virtual string ConfigurationName { get; internal set; }
        /// <summary>
        ///   Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the persistently configured execution policies.<para/>This parameter only applies to Windows computers. The <c>$env:PSExecutionPolicyPreference</c> environment variable does not exist on non-Windows platforms.
        /// </summary>
        public virtual ExecutionPolicy ExecutionPolicy { get; internal set; }
        /// <summary>
        ///   Specifies the name to use for an additional IPC server (named pipe) used for debugging and other cross-process communication. This offers a predictable mechanism for connecting to other PowerShell instances. Typically used with the <em>CustomPipeName</em> parameter on <c>Enter-PSHostProcess</c>.
        /// </summary>
        public virtual string CustomPipeName { get; internal set; }
        /// <summary>
        ///   Overrides the system-wide <c>powershell.config.json</c> settings file for the session. By default, system-wide settings are read from the <c>powershell.config.json</c> in the <c>$PSHOME</c> directory.<para/>Note that these settings are not used by the endpoint specified by the <c>-ConfigurationName</c> argument.
        /// </summary>
        public virtual string SettingsFile { get; internal set; }
        /// <summary>
        ///   Sets the initial working directory by executing at startup. Any valid PowerShell file path is supported.
        /// </summary>
        public virtual string WorkingDirectory { get; internal set; }
        /// <summary>
        ///   If the value of <c>File</c> is <c>-</c>, the command text is read from standard input. Running <c>pwsh -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the <c>File</c> parameter at all.<para/>This is the default parameter if no parameters are present but values are present in the command line. The specified script runs in the local scope ("dot-sourced"), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. File must be the last parameter in the command, because all characters typed after the File parameter name are interpreted as the script file path followed by the script parameters.<para/>Typically, the switch parameters of a script are either included or omitted. For example, the following command uses the All parameter of the Get-Script.ps1 script file: <c>-File .\Get-Script.ps1 -All</c><para/>In rare cases, you might need to provide a <em>Boolean</em> value for a switch parameter. To provide a <em>Boolean</em> value for a switch parameter in the value of the <em>File</em> parameter, Use the parameter normally followed immediately by a colon and the boolean value, such as the following: <c>-File .\Get-Script.ps1 -All:$False</c>.<para/>As of PowerShell 7.2, the File parameter only accepts .ps1 files on Windows. If another file type is provided an error is thrown. This behavior is Windows specific. On other platforms, PowerShell attempts to run other file types.
        /// </summary>
        public virtual string File { get; internal set; }
        /// <summary>
        ///   Arguments passed in when using the <c>-File</c> option.
        /// </summary>
        public virtual IReadOnlyList<string> FileArguments => FileArgumentsInternal.AsReadOnly();
        internal List<string> FileArgumentsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Key-value pairs passed in when using the <c>-File</c> option.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> FileKeyValueParameters => FileKeyValueParametersInternal.AsReadOnly();
        internal Dictionary<string, string> FileKeyValueParametersInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of <em>Command</em> can be <c>-</c>, a script block, or a string. If the value of <em>Command</em> is <c>-</c>, the command text is read from standard input.<para/>The <em>Command</em> parameter only accepts a script block for execution when it can recognize the value passed to <em>Command</em> as a <em>ScriptBlock</em> type. This is only possible when running <c>pwsh</c> from another PowerShell host. The <em>ScriptBlock</em> type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to <c>pwsh</c>.
        /// </summary>
        public virtual string Command { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("-Version", Version)
              .Add("-NoLogo", NoLogo)
              .Add("-NoExit", NoExit)
              .Add("-STA", StartUsingASingleThreadedApartment)
              .Add("-MTA", StartUsingAMultiThreadedApartment)
              .Add("-NoProfile", NoProfile)
              .Add("-NonInteractive", NonInteractive)
              .Add("-InputFormat {value}", InputFormat)
              .Add("-OutputFormat {value}", OutputFormat)
              .Add("-WindowStyle {value}", WindowStyle)
              .Add("-EncodedCommand {value}", EncodedCommand)
              .Add("-ConfigurationName {value}", ConfigurationName)
              .Add("-ExecutionPolicy {value}", ExecutionPolicy)
              .Add("-CustomPipeName {value}", CustomPipeName)
              .Add("-SettingsFile {value}", SettingsFile)
              .Add("-WorkingDirectory {value}", WorkingDirectory)
              .Add("-File  {value}", File)
              .Add("{value}", FileArguments)
              .Add("-{value}", FileKeyValueParameters, "{key} {value}")
              .Add("-Command {value}", Command);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region PowerShellCoreSettingsExtensions
    /// <summary>
    ///   Used within <see cref="PowerShellCoreTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PowerShellCoreSettingsExtensions
    {
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.Version"/></em></p>
        ///   <p>Displays the version of PowerShell. Additional parameters are ignored.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.Version"/></em></p>
        ///   <p>Displays the version of PowerShell. Additional parameters are ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellCoreSettings.Version"/></em></p>
        ///   <p>Displays the version of PowerShell. Additional parameters are ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellCoreSettings.Version"/></em></p>
        ///   <p>Displays the version of PowerShell. Additional parameters are ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellCoreSettings.Version"/></em></p>
        ///   <p>Displays the version of PowerShell. Additional parameters are ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.NoLogo"/></em></p>
        ///   <p>Hides the copyright banner at startup of interactive sessions.</p>
        /// </summary>
        [Pure]
        public static T SetNoLogo<T>(this T toolSettings, bool? noLogo) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.NoLogo"/></em></p>
        ///   <p>Hides the copyright banner at startup of interactive sessions.</p>
        /// </summary>
        [Pure]
        public static T ResetNoLogo<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellCoreSettings.NoLogo"/></em></p>
        ///   <p>Hides the copyright banner at startup of interactive sessions.</p>
        /// </summary>
        [Pure]
        public static T EnableNoLogo<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellCoreSettings.NoLogo"/></em></p>
        ///   <p>Hides the copyright banner at startup of interactive sessions.</p>
        /// </summary>
        [Pure]
        public static T DisableNoLogo<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellCoreSettings.NoLogo"/></em></p>
        ///   <p>Hides the copyright banner at startup of interactive sessions.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoLogo<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region NoExit
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.NoExit"/></em></p>
        ///   <p>Does not exit after running startup commands.</p>
        /// </summary>
        [Pure]
        public static T SetNoExit<T>(this T toolSettings, bool? noExit) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoExit = noExit;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.NoExit"/></em></p>
        ///   <p>Does not exit after running startup commands.</p>
        /// </summary>
        [Pure]
        public static T ResetNoExit<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoExit = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellCoreSettings.NoExit"/></em></p>
        ///   <p>Does not exit after running startup commands.</p>
        /// </summary>
        [Pure]
        public static T EnableNoExit<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoExit = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellCoreSettings.NoExit"/></em></p>
        ///   <p>Does not exit after running startup commands.</p>
        /// </summary>
        [Pure]
        public static T DisableNoExit<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoExit = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellCoreSettings.NoExit"/></em></p>
        ///   <p>Does not exit after running startup commands.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoExit<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoExit = !toolSettings.NoExit;
            return toolSettings;
        }
        #endregion
        #region StartUsingASingleThreadedApartment
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.StartUsingASingleThreadedApartment"/></em></p>
        ///   <p>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</p>
        /// </summary>
        [Pure]
        public static T SetStartUsingASingleThreadedApartment<T>(this T toolSettings, bool? startUsingASingleThreadedApartment) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingASingleThreadedApartment = startUsingASingleThreadedApartment;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.StartUsingASingleThreadedApartment"/></em></p>
        ///   <p>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</p>
        /// </summary>
        [Pure]
        public static T ResetStartUsingASingleThreadedApartment<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingASingleThreadedApartment = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellCoreSettings.StartUsingASingleThreadedApartment"/></em></p>
        ///   <p>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</p>
        /// </summary>
        [Pure]
        public static T EnableStartUsingASingleThreadedApartment<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingASingleThreadedApartment = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellCoreSettings.StartUsingASingleThreadedApartment"/></em></p>
        ///   <p>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</p>
        /// </summary>
        [Pure]
        public static T DisableStartUsingASingleThreadedApartment<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingASingleThreadedApartment = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellCoreSettings.StartUsingASingleThreadedApartment"/></em></p>
        ///   <p>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</p>
        /// </summary>
        [Pure]
        public static T ToggleStartUsingASingleThreadedApartment<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingASingleThreadedApartment = !toolSettings.StartUsingASingleThreadedApartment;
            return toolSettings;
        }
        #endregion
        #region StartUsingAMultiThreadedApartment
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.StartUsingAMultiThreadedApartment"/></em></p>
        ///   <p>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</p>
        /// </summary>
        [Pure]
        public static T SetStartUsingAMultiThreadedApartment<T>(this T toolSettings, bool? startUsingAMultiThreadedApartment) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingAMultiThreadedApartment = startUsingAMultiThreadedApartment;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.StartUsingAMultiThreadedApartment"/></em></p>
        ///   <p>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</p>
        /// </summary>
        [Pure]
        public static T ResetStartUsingAMultiThreadedApartment<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingAMultiThreadedApartment = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellCoreSettings.StartUsingAMultiThreadedApartment"/></em></p>
        ///   <p>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</p>
        /// </summary>
        [Pure]
        public static T EnableStartUsingAMultiThreadedApartment<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingAMultiThreadedApartment = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellCoreSettings.StartUsingAMultiThreadedApartment"/></em></p>
        ///   <p>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</p>
        /// </summary>
        [Pure]
        public static T DisableStartUsingAMultiThreadedApartment<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingAMultiThreadedApartment = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellCoreSettings.StartUsingAMultiThreadedApartment"/></em></p>
        ///   <p>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</p>
        /// </summary>
        [Pure]
        public static T ToggleStartUsingAMultiThreadedApartment<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingAMultiThreadedApartment = !toolSettings.StartUsingAMultiThreadedApartment;
            return toolSettings;
        }
        #endregion
        #region NoProfile
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.NoProfile"/></em></p>
        ///   <p>Does not load the PowerShell profiles.</p>
        /// </summary>
        [Pure]
        public static T SetNoProfile<T>(this T toolSettings, bool? noProfile) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoProfile = noProfile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.NoProfile"/></em></p>
        ///   <p>Does not load the PowerShell profiles.</p>
        /// </summary>
        [Pure]
        public static T ResetNoProfile<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoProfile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellCoreSettings.NoProfile"/></em></p>
        ///   <p>Does not load the PowerShell profiles.</p>
        /// </summary>
        [Pure]
        public static T EnableNoProfile<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoProfile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellCoreSettings.NoProfile"/></em></p>
        ///   <p>Does not load the PowerShell profiles.</p>
        /// </summary>
        [Pure]
        public static T DisableNoProfile<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoProfile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellCoreSettings.NoProfile"/></em></p>
        ///   <p>Does not load the PowerShell profiles.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoProfile<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoProfile = !toolSettings.NoProfile;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.NonInteractive"/></em></p>
        ///   <p>Does not present an interactive prompt to the user. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement-terminating errors.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.NonInteractive"/></em></p>
        ///   <p>Does not present an interactive prompt to the user. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement-terminating errors.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellCoreSettings.NonInteractive"/></em></p>
        ///   <p>Does not present an interactive prompt to the user. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement-terminating errors.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellCoreSettings.NonInteractive"/></em></p>
        ///   <p>Does not present an interactive prompt to the user. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement-terminating errors.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellCoreSettings.NonInteractive"/></em></p>
        ///   <p>Does not present an interactive prompt to the user. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement-terminating errors.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region InputFormat
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.InputFormat"/></em></p>
        ///   <p>Describes the format of data sent to PowerShell. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).</p>
        /// </summary>
        [Pure]
        public static T SetInputFormat<T>(this T toolSettings, PowerShellFormat inputFormat) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFormat = inputFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.InputFormat"/></em></p>
        ///   <p>Describes the format of data sent to PowerShell. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).</p>
        /// </summary>
        [Pure]
        public static T ResetInputFormat<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFormat = null;
            return toolSettings;
        }
        #endregion
        #region OutputFormat
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.OutputFormat"/></em></p>
        ///   <p>Determines how output from PowerShell is formatted. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).<para/>Example: <c>pwsh -o XML -c Get-Date</c><para/>When called withing a PowerShell session, you get deserialized objects as output rather plain strings. When called from other shells, the output is string data formatted as CLIXML text.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFormat<T>(this T toolSettings, PowerShellFormat outputFormat) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormat = outputFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.OutputFormat"/></em></p>
        ///   <p>Determines how output from PowerShell is formatted. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).<para/>Example: <c>pwsh -o XML -c Get-Date</c><para/>When called withing a PowerShell session, you get deserialized objects as output rather plain strings. When called from other shells, the output is string data formatted as CLIXML text.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFormat<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormat = null;
            return toolSettings;
        }
        #endregion
        #region WindowStyle
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.WindowStyle"/></em></p>
        ///   <p>Sets the window style for the session. Valid values are Normal, Minimized, Maximized and Hidden.</p>
        /// </summary>
        [Pure]
        public static T SetWindowStyle<T>(this T toolSettings, PowerShellWindowStyle windowStyle) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowStyle = windowStyle;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.WindowStyle"/></em></p>
        ///   <p>Sets the window style for the session. Valid values are Normal, Minimized, Maximized and Hidden.</p>
        /// </summary>
        [Pure]
        public static T ResetWindowStyle<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowStyle = null;
            return toolSettings;
        }
        #endregion
        #region EncodedCommand
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.EncodedCommand"/></em></p>
        ///   <p>Accepts a Base64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex, nested quoting. The Base64 representation must be a UTF-16LE encoded string.</p>
        /// </summary>
        [Pure]
        public static T SetEncodedCommand<T>(this T toolSettings, string encodedCommand) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EncodedCommand = encodedCommand;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.EncodedCommand"/></em></p>
        ///   <p>Accepts a Base64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex, nested quoting. The Base64 representation must be a UTF-16LE encoded string.</p>
        /// </summary>
        [Pure]
        public static T ResetEncodedCommand<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EncodedCommand = null;
            return toolSettings;
        }
        #endregion
        #region ConfigurationName
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.ConfigurationName"/></em></p>
        ///   <p>Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.</p>
        /// </summary>
        [Pure]
        public static T SetConfigurationName<T>(this T toolSettings, string configurationName) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationName = configurationName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.ConfigurationName"/></em></p>
        ///   <p>Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigurationName<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationName = null;
            return toolSettings;
        }
        #endregion
        #region ExecutionPolicy
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.ExecutionPolicy"/></em></p>
        ///   <p>Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the persistently configured execution policies.<para/>This parameter only applies to Windows computers. The <c>$env:PSExecutionPolicyPreference</c> environment variable does not exist on non-Windows platforms.</p>
        /// </summary>
        [Pure]
        public static T SetExecutionPolicy<T>(this T toolSettings, ExecutionPolicy executionPolicy) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExecutionPolicy = executionPolicy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.ExecutionPolicy"/></em></p>
        ///   <p>Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the persistently configured execution policies.<para/>This parameter only applies to Windows computers. The <c>$env:PSExecutionPolicyPreference</c> environment variable does not exist on non-Windows platforms.</p>
        /// </summary>
        [Pure]
        public static T ResetExecutionPolicy<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExecutionPolicy = null;
            return toolSettings;
        }
        #endregion
        #region CustomPipeName
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.CustomPipeName"/></em></p>
        ///   <p>Specifies the name to use for an additional IPC server (named pipe) used for debugging and other cross-process communication. This offers a predictable mechanism for connecting to other PowerShell instances. Typically used with the <em>CustomPipeName</em> parameter on <c>Enter-PSHostProcess</c>.</p>
        /// </summary>
        [Pure]
        public static T SetCustomPipeName<T>(this T toolSettings, string customPipeName) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CustomPipeName = customPipeName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.CustomPipeName"/></em></p>
        ///   <p>Specifies the name to use for an additional IPC server (named pipe) used for debugging and other cross-process communication. This offers a predictable mechanism for connecting to other PowerShell instances. Typically used with the <em>CustomPipeName</em> parameter on <c>Enter-PSHostProcess</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetCustomPipeName<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CustomPipeName = null;
            return toolSettings;
        }
        #endregion
        #region SettingsFile
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.SettingsFile"/></em></p>
        ///   <p>Overrides the system-wide <c>powershell.config.json</c> settings file for the session. By default, system-wide settings are read from the <c>powershell.config.json</c> in the <c>$PSHOME</c> directory.<para/>Note that these settings are not used by the endpoint specified by the <c>-ConfigurationName</c> argument.</p>
        /// </summary>
        [Pure]
        public static T SetSettingsFile<T>(this T toolSettings, string settingsFile) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SettingsFile = settingsFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.SettingsFile"/></em></p>
        ///   <p>Overrides the system-wide <c>powershell.config.json</c> settings file for the session. By default, system-wide settings are read from the <c>powershell.config.json</c> in the <c>$PSHOME</c> directory.<para/>Note that these settings are not used by the endpoint specified by the <c>-ConfigurationName</c> argument.</p>
        /// </summary>
        [Pure]
        public static T ResetSettingsFile<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SettingsFile = null;
            return toolSettings;
        }
        #endregion
        #region WorkingDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.WorkingDirectory"/></em></p>
        ///   <p>Sets the initial working directory by executing at startup. Any valid PowerShell file path is supported.</p>
        /// </summary>
        [Pure]
        public static T SetWorkingDirectory<T>(this T toolSettings, string workingDirectory) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WorkingDirectory = workingDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.WorkingDirectory"/></em></p>
        ///   <p>Sets the initial working directory by executing at startup. Any valid PowerShell file path is supported.</p>
        /// </summary>
        [Pure]
        public static T ResetWorkingDirectory<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WorkingDirectory = null;
            return toolSettings;
        }
        #endregion
        #region File
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.File"/></em></p>
        ///   <p>If the value of <c>File</c> is <c>-</c>, the command text is read from standard input. Running <c>pwsh -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the <c>File</c> parameter at all.<para/>This is the default parameter if no parameters are present but values are present in the command line. The specified script runs in the local scope ("dot-sourced"), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. File must be the last parameter in the command, because all characters typed after the File parameter name are interpreted as the script file path followed by the script parameters.<para/>Typically, the switch parameters of a script are either included or omitted. For example, the following command uses the All parameter of the Get-Script.ps1 script file: <c>-File .\Get-Script.ps1 -All</c><para/>In rare cases, you might need to provide a <em>Boolean</em> value for a switch parameter. To provide a <em>Boolean</em> value for a switch parameter in the value of the <em>File</em> parameter, Use the parameter normally followed immediately by a colon and the boolean value, such as the following: <c>-File .\Get-Script.ps1 -All:$False</c>.<para/>As of PowerShell 7.2, the File parameter only accepts .ps1 files on Windows. If another file type is provided an error is thrown. This behavior is Windows specific. On other platforms, PowerShell attempts to run other file types.</p>
        /// </summary>
        [Pure]
        public static T SetFile<T>(this T toolSettings, string file) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.File"/></em></p>
        ///   <p>If the value of <c>File</c> is <c>-</c>, the command text is read from standard input. Running <c>pwsh -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the <c>File</c> parameter at all.<para/>This is the default parameter if no parameters are present but values are present in the command line. The specified script runs in the local scope ("dot-sourced"), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. File must be the last parameter in the command, because all characters typed after the File parameter name are interpreted as the script file path followed by the script parameters.<para/>Typically, the switch parameters of a script are either included or omitted. For example, the following command uses the All parameter of the Get-Script.ps1 script file: <c>-File .\Get-Script.ps1 -All</c><para/>In rare cases, you might need to provide a <em>Boolean</em> value for a switch parameter. To provide a <em>Boolean</em> value for a switch parameter in the value of the <em>File</em> parameter, Use the parameter normally followed immediately by a colon and the boolean value, such as the following: <c>-File .\Get-Script.ps1 -All:$False</c>.<para/>As of PowerShell 7.2, the File parameter only accepts .ps1 files on Windows. If another file type is provided an error is thrown. This behavior is Windows specific. On other platforms, PowerShell attempts to run other file types.</p>
        /// </summary>
        [Pure]
        public static T ResetFile<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region FileArguments
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.FileArguments"/> to a new list</em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetFileArguments<T>(this T toolSettings, params string[] fileArguments) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileArgumentsInternal = fileArguments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.FileArguments"/> to a new list</em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetFileArguments<T>(this T toolSettings, IEnumerable<string> fileArguments) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileArgumentsInternal = fileArguments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="PowerShellCoreSettings.FileArguments"/></em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T AddFileArguments<T>(this T toolSettings, params string[] fileArguments) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileArgumentsInternal.AddRange(fileArguments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="PowerShellCoreSettings.FileArguments"/></em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T AddFileArguments<T>(this T toolSettings, IEnumerable<string> fileArguments) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileArgumentsInternal.AddRange(fileArguments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="PowerShellCoreSettings.FileArguments"/></em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T ClearFileArguments<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileArgumentsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="PowerShellCoreSettings.FileArguments"/></em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T RemoveFileArguments<T>(this T toolSettings, params string[] fileArguments) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fileArguments);
            toolSettings.FileArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="PowerShellCoreSettings.FileArguments"/></em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T RemoveFileArguments<T>(this T toolSettings, IEnumerable<string> fileArguments) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fileArguments);
            toolSettings.FileArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region FileKeyValueParameters
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.FileKeyValueParameters"/> to a new dictionary</em></p>
        ///   <p>Key-value pairs passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetFileKeyValueParameters<T>(this T toolSettings, IDictionary<string, string> fileKeyValueParameters) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueParametersInternal = fileKeyValueParameters.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="PowerShellCoreSettings.FileKeyValueParameters"/></em></p>
        ///   <p>Key-value pairs passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T ClearFileKeyValueParameters<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueParametersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="PowerShellCoreSettings.FileKeyValueParameters"/></em></p>
        ///   <p>Key-value pairs passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T AddFileKeyValueParameter<T>(this T toolSettings, string fileKeyValueParameterKey, string fileKeyValueParameterValue) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueParametersInternal.Add(fileKeyValueParameterKey, fileKeyValueParameterValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="PowerShellCoreSettings.FileKeyValueParameters"/></em></p>
        ///   <p>Key-value pairs passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T RemoveFileKeyValueParameter<T>(this T toolSettings, string fileKeyValueParameterKey) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueParametersInternal.Remove(fileKeyValueParameterKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="PowerShellCoreSettings.FileKeyValueParameters"/></em></p>
        ///   <p>Key-value pairs passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetFileKeyValueParameter<T>(this T toolSettings, string fileKeyValueParameterKey, string fileKeyValueParameterValue) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueParametersInternal[fileKeyValueParameterKey] = fileKeyValueParameterValue;
            return toolSettings;
        }
        #endregion
        #region Command
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellCoreSettings.Command"/></em></p>
        ///   <p>Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of <em>Command</em> can be <c>-</c>, a script block, or a string. If the value of <em>Command</em> is <c>-</c>, the command text is read from standard input.<para/>The <em>Command</em> parameter only accepts a script block for execution when it can recognize the value passed to <em>Command</em> as a <em>ScriptBlock</em> type. This is only possible when running <c>pwsh</c> from another PowerShell host. The <em>ScriptBlock</em> type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to <c>pwsh</c>.</p>
        /// </summary>
        [Pure]
        public static T SetCommand<T>(this T toolSettings, string command) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellCoreSettings.Command"/></em></p>
        ///   <p>Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of <em>Command</em> can be <c>-</c>, a script block, or a string. If the value of <em>Command</em> is <c>-</c>, the command text is read from standard input.<para/>The <em>Command</em> parameter only accepts a script block for execution when it can recognize the value passed to <em>Command</em> as a <em>ScriptBlock</em> type. This is only possible when running <c>pwsh</c> from another PowerShell host. The <em>ScriptBlock</em> type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to <c>pwsh</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetCommand<T>(this T toolSettings) where T : PowerShellCoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region PowerShellFormat
    /// <summary>
    ///   Used within <see cref="PowerShellCoreTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<PowerShellFormat>))]
    public partial class PowerShellFormat : Enumeration
    {
        public static PowerShellFormat Text = (PowerShellFormat) "Text";
        public static PowerShellFormat Xml = (PowerShellFormat) "Xml";
        public static implicit operator PowerShellFormat(string value)
        {
            return new PowerShellFormat { Value = value };
        }
    }
    #endregion
    #region PowerShellWindowStyle
    /// <summary>
    ///   Used within <see cref="PowerShellCoreTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<PowerShellWindowStyle>))]
    public partial class PowerShellWindowStyle : Enumeration
    {
        public static PowerShellWindowStyle Normal = (PowerShellWindowStyle) "Normal";
        public static PowerShellWindowStyle Minimized = (PowerShellWindowStyle) "Minimized";
        public static PowerShellWindowStyle Maximized = (PowerShellWindowStyle) "Maximized";
        public static PowerShellWindowStyle Hidden = (PowerShellWindowStyle) "Hidden";
        public static implicit operator PowerShellWindowStyle(string value)
        {
            return new PowerShellWindowStyle { Value = value };
        }
    }
    #endregion
    #region ExecutionPolicy
    /// <summary>
    ///   Used within <see cref="PowerShellCoreTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<ExecutionPolicy>))]
    public partial class ExecutionPolicy : Enumeration
    {
        public static ExecutionPolicy AllSigned = (ExecutionPolicy) "AllSigned";
        public static ExecutionPolicy Bypass = (ExecutionPolicy) "Bypass";
        public static ExecutionPolicy Default = (ExecutionPolicy) "Default";
        public static ExecutionPolicy RemoteSigned = (ExecutionPolicy) "RemoteSigned";
        public static ExecutionPolicy Restricted = (ExecutionPolicy) "Restricted";
        public static ExecutionPolicy Undefined = (ExecutionPolicy) "Undefined";
        public static ExecutionPolicy Unrestricted = (ExecutionPolicy) "Unrestricted";
        public static implicit operator ExecutionPolicy(string value)
        {
            return new ExecutionPolicy { Value = value };
        }
    }
    #endregion
}
