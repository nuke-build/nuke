// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/PowerShell/PowerShell.json

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

namespace Nuke.Common.Tools.PowerShell
{
    /// <summary>
    ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public partial class PowerShellTasks
    {
        /// <summary>
        ///   Path to the PowerShell executable.
        /// </summary>
        public static string PowerShellPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("POWERSHELL_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> PowerShellLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> PowerShell(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(PowerShellPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? PowerShellLogger);
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
        ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PowerShellSettings.FileArguments"/></li>
        ///     <li><c>-</c> via <see cref="PowerShellSettings.FileKeyValueParameters"/></li>
        ///     <li><c>-Command</c> via <see cref="PowerShellSettings.Command"/></li>
        ///     <li><c>-ConfigurationName</c> via <see cref="PowerShellSettings.ConfigurationName"/></li>
        ///     <li><c>-EncodedCommand</c> via <see cref="PowerShellSettings.EncodedCommand"/></li>
        ///     <li><c>-ExecutionPolicy</c> via <see cref="PowerShellSettings.ExecutionPolicy"/></li>
        ///     <li><c>-File</c> via <see cref="PowerShellSettings.File"/></li>
        ///     <li><c>-InputFormat</c> via <see cref="PowerShellSettings.InputFormat"/></li>
        ///     <li><c>-Mta</c> via <see cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/></li>
        ///     <li><c>-NoExit</c> via <see cref="PowerShellSettings.NoExit"/></li>
        ///     <li><c>-NoLogo</c> via <see cref="PowerShellSettings.NoLogo"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="PowerShellSettings.NonInteractive"/></li>
        ///     <li><c>-NoProfile</c> via <see cref="PowerShellSettings.NoProfile"/></li>
        ///     <li><c>-OutputFormat</c> via <see cref="PowerShellSettings.OutputFormat"/></li>
        ///     <li><c>-PSConsoleFile</c> via <see cref="PowerShellSettings.ConsoleFile"/></li>
        ///     <li><c>-Sta</c> via <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></li>
        ///     <li><c>-Version</c> via <see cref="PowerShellSettings.Version"/></li>
        ///     <li><c>-WindowStyle</c> via <see cref="PowerShellSettings.WindowStyle"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PowerShell(PowerShellSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new PowerShellSettings();
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
        ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PowerShellSettings.FileArguments"/></li>
        ///     <li><c>-</c> via <see cref="PowerShellSettings.FileKeyValueParameters"/></li>
        ///     <li><c>-Command</c> via <see cref="PowerShellSettings.Command"/></li>
        ///     <li><c>-ConfigurationName</c> via <see cref="PowerShellSettings.ConfigurationName"/></li>
        ///     <li><c>-EncodedCommand</c> via <see cref="PowerShellSettings.EncodedCommand"/></li>
        ///     <li><c>-ExecutionPolicy</c> via <see cref="PowerShellSettings.ExecutionPolicy"/></li>
        ///     <li><c>-File</c> via <see cref="PowerShellSettings.File"/></li>
        ///     <li><c>-InputFormat</c> via <see cref="PowerShellSettings.InputFormat"/></li>
        ///     <li><c>-Mta</c> via <see cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/></li>
        ///     <li><c>-NoExit</c> via <see cref="PowerShellSettings.NoExit"/></li>
        ///     <li><c>-NoLogo</c> via <see cref="PowerShellSettings.NoLogo"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="PowerShellSettings.NonInteractive"/></li>
        ///     <li><c>-NoProfile</c> via <see cref="PowerShellSettings.NoProfile"/></li>
        ///     <li><c>-OutputFormat</c> via <see cref="PowerShellSettings.OutputFormat"/></li>
        ///     <li><c>-PSConsoleFile</c> via <see cref="PowerShellSettings.ConsoleFile"/></li>
        ///     <li><c>-Sta</c> via <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></li>
        ///     <li><c>-Version</c> via <see cref="PowerShellSettings.Version"/></li>
        ///     <li><c>-WindowStyle</c> via <see cref="PowerShellSettings.WindowStyle"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PowerShell(Configure<PowerShellSettings> configurator)
        {
            return PowerShell(configurator(new PowerShellSettings()));
        }
        /// <summary>
        ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PowerShellSettings.FileArguments"/></li>
        ///     <li><c>-</c> via <see cref="PowerShellSettings.FileKeyValueParameters"/></li>
        ///     <li><c>-Command</c> via <see cref="PowerShellSettings.Command"/></li>
        ///     <li><c>-ConfigurationName</c> via <see cref="PowerShellSettings.ConfigurationName"/></li>
        ///     <li><c>-EncodedCommand</c> via <see cref="PowerShellSettings.EncodedCommand"/></li>
        ///     <li><c>-ExecutionPolicy</c> via <see cref="PowerShellSettings.ExecutionPolicy"/></li>
        ///     <li><c>-File</c> via <see cref="PowerShellSettings.File"/></li>
        ///     <li><c>-InputFormat</c> via <see cref="PowerShellSettings.InputFormat"/></li>
        ///     <li><c>-Mta</c> via <see cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/></li>
        ///     <li><c>-NoExit</c> via <see cref="PowerShellSettings.NoExit"/></li>
        ///     <li><c>-NoLogo</c> via <see cref="PowerShellSettings.NoLogo"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="PowerShellSettings.NonInteractive"/></li>
        ///     <li><c>-NoProfile</c> via <see cref="PowerShellSettings.NoProfile"/></li>
        ///     <li><c>-OutputFormat</c> via <see cref="PowerShellSettings.OutputFormat"/></li>
        ///     <li><c>-PSConsoleFile</c> via <see cref="PowerShellSettings.ConsoleFile"/></li>
        ///     <li><c>-Sta</c> via <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></li>
        ///     <li><c>-Version</c> via <see cref="PowerShellSettings.Version"/></li>
        ///     <li><c>-WindowStyle</c> via <see cref="PowerShellSettings.WindowStyle"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(PowerShellSettings Settings, IReadOnlyCollection<Output> Output)> PowerShell(CombinatorialConfigure<PowerShellSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(PowerShell, PowerShellLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region PowerShellSettings
    /// <summary>
    ///   Used within <see cref="PowerShellTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PowerShellSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the PowerShell executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? PowerShellTasks.PowerShellLogger;
        /// <summary>
        ///   Loads the specified PowerShell console file. Enter the path and name of the console file. To create a console file, use the Export-Console cmdlet in PowerShell.
        /// </summary>
        public virtual string ConsoleFile { get; internal set; }
        /// <summary>
        ///   Starts the specified version of PowerShell. Valid values are 2.0 and 3.0. The version that you specify must be installed on the system. If Windows PowerShell 3.0 is installed on the computer, <c>3.0</c> is the default version. Otherwise, <c>2.0</c> is the default version. For more information, see <a href="https://docs.microsoft.com/en-us/powershell/scripting/install/installing-windows-powershell">Installing PowerShell</a>.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   Hides the copyright banner at startup.
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   Does not exit after running startup commands.
        /// </summary>
        public virtual bool? NoExit { get; internal set; }
        /// <summary>
        ///   Starts PowerShell using a single-threaded apartment. In Windows PowerShell 2.0, multi-threaded apartment (MTA) is the default. In Windows PowerShell 3.0, single-threaded apartment (STA) is the default.
        /// </summary>
        public virtual bool? StartUsingASingleThreadedApartment { get; internal set; }
        /// <summary>
        ///   Starts PowerShell using a multi-threaded apartment. This parameter is introduced in PowerShell 3.0. In PowerShell 2.0, multi-threaded apartment (MTA) is the default. In PowerShell 3.0, single-threaded apartment (STA) is the default.
        /// </summary>
        public virtual bool? StartUsingAMultiThreadedApartment { get; internal set; }
        /// <summary>
        ///   Does not load the PowerShell profile.
        /// </summary>
        public virtual bool? NoProfile { get; internal set; }
        /// <summary>
        ///   Does not present an interactive prompt to the user.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Describes the format of data sent to PowerShell. Valid values are <c>Text</c> (text strings) or <c>XML</c> (serialized CLIXML format).
        /// </summary>
        public virtual PowerShellFormat InputFormat { get; internal set; }
        /// <summary>
        ///   Determines how output from PowerShell is formatted. Valid values are <c>Text</c>  (text strings) or <c>XML</c>  (serialized CLIXML format).
        /// </summary>
        public virtual PowerShellFormat OutputFormat { get; internal set; }
        /// <summary>
        ///   Sets the window style for the session. Valid values are <c>Normal</c>, <c>Minimized</c>, <c>Maximized</c> and <c>Hidden</c>.
        /// </summary>
        public virtual PowerShellWindowStyle WindowStyle { get; internal set; }
        /// <summary>
        ///   Accepts a base-64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex quotation marks or curly braces. The string must be formatted using UTF-16LE character encoding.
        /// </summary>
        public virtual string EncodedCommand { get; internal set; }
        /// <summary>
        ///   Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.
        /// </summary>
        public virtual string ConfigurationName { get; internal set; }
        /// <summary>
        ///   Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. For information about PowerShell execution policies, including a list of valid values, see <a href="https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies">about_Execution_Policies</a>.
        /// </summary>
        public virtual string ExecutionPolicy { get; internal set; }
        /// <summary>
        ///   If the value of File is <c>-</c>, the command text is read from standard input. Running <c>powershell -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the <c>File</c> parameter at all.<para/>If the value of File is a file path, the script runs in the local scope (<c>dot-sourced</c>), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. <c>File</c> must be the last parameter in the command. All values typed after the <c>File</c> parameter are interpreted as the script file path and parameters passed to that script. Parameters passed to the script are passed as literal strings, after interpretation by the current shell. For example, if you are in cmd.exe and want to pass an environment variable value, you would use the cmd.exe syntax: <c>powershell.exe -File .\test.ps1 -TestParam %windir%</c>.<para/>In contrast, running <c>powershell.exe -File .\test.ps1 -TestParam $env:windir</c> in cmd.exe results in the script receiving the literal string <c>$env:windir</c> because it has no special meaning to the current cmd.exe shell. The <c>$env:windir</c> style of environment variable reference can be used inside a Command parameter, since there it will be interpreted as PowerShell code.<para/>Similarly, if you want to execute the same command from a Batch script, you would use <c>%~dp0</c> instead of <c>.\</c> or <c>$PSScriptRoot</c> to represent the current execution directory: <c>powershell.exe -File %~dp0test.ps1 -TestParam %windir%</c>. If you instead used <c>.\test.ps1</c>, PowerShell would throw an error because it cannot find the literal path <c>.\test.ps1</c>.<para/>When the value of <c>File</c> is a file path, <c>File</c> must be the last parameter in the command because any characters typed after the <c>File</c> parameter name are interpreted as the script file path followed by the script parameters.<para/>You can include the script parameters and values in the value of the <c>File</c> parameter. For example: <c>-File .\Get-Script.ps1 -Domain Central</c>.<para/>Typically, the switch parameters of a script are either included or omitted. For example, the following command uses the <c>All</c> parameter of the <c>Get-Script.ps1</c> script file: <c>-File .\Get-Script.ps1 -All</c>.<para/>In rare cases, you might need to provide a Boolean value for a parameter. It is not possible to pass an explicit boolean value for a switch parameter when running a script in this way. This limitation was removed in PowerShell 6 (<c>pwsh.exe</c>).
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
        ///   Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of Command can be <c>-</c>, a script block, or a string. If the value of <c>Command</c> is <c>-</c>, the command text is read from standard input.<para/>The <c>Command</c> parameter only accepts a script block for execution when it can recognize the value passed to <c>Command</c> as a <c>ScriptBlock</c> type. This is only possible when running <c>powershell.exe</c> from another PowerShell host. The <c>ScriptBlock</c> type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to <c>powershell.exe</c>.
        /// </summary>
        public virtual string Command { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("-PSConsoleFile {value}", ConsoleFile)
              .Add("-Version {value}", Version)
              .Add("-NoLogo", NoLogo)
              .Add("-NoExit", NoExit)
              .Add("-Sta", StartUsingASingleThreadedApartment)
              .Add("-Mta", StartUsingAMultiThreadedApartment)
              .Add("-NoProfile", NoProfile)
              .Add("-NonInteractive", NonInteractive)
              .Add("-InputFormat {value}", InputFormat)
              .Add("-OutputFormat {value}", OutputFormat)
              .Add("-WindowStyle {value}", WindowStyle)
              .Add("-EncodedCommand {value}", EncodedCommand)
              .Add("-ConfigurationName {value}", ConfigurationName)
              .Add("-ExecutionPolicy {value}", ExecutionPolicy)
              .Add("-File  {value}", File)
              .Add("{value}", FileArguments)
              .Add("-{value}", FileKeyValueParameters, "{key} {value}")
              .Add("-Command {value}", Command);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region PowerShellSettingsExtensions
    /// <summary>
    ///   Used within <see cref="PowerShellTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PowerShellSettingsExtensions
    {
        #region ConsoleFile
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.ConsoleFile"/></em></p>
        ///   <p>Loads the specified PowerShell console file. Enter the path and name of the console file. To create a console file, use the Export-Console cmdlet in PowerShell.</p>
        /// </summary>
        [Pure]
        public static T SetConsoleFile<T>(this T toolSettings, string consoleFile) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConsoleFile = consoleFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.ConsoleFile"/></em></p>
        ///   <p>Loads the specified PowerShell console file. Enter the path and name of the console file. To create a console file, use the Export-Console cmdlet in PowerShell.</p>
        /// </summary>
        [Pure]
        public static T ResetConsoleFile<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConsoleFile = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.Version"/></em></p>
        ///   <p>Starts the specified version of PowerShell. Valid values are 2.0 and 3.0. The version that you specify must be installed on the system. If Windows PowerShell 3.0 is installed on the computer, <c>3.0</c> is the default version. Otherwise, <c>2.0</c> is the default version. For more information, see <a href="https://docs.microsoft.com/en-us/powershell/scripting/install/installing-windows-powershell">Installing PowerShell</a>.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.Version"/></em></p>
        ///   <p>Starts the specified version of PowerShell. Valid values are 2.0 and 3.0. The version that you specify must be installed on the system. If Windows PowerShell 3.0 is installed on the computer, <c>3.0</c> is the default version. Otherwise, <c>2.0</c> is the default version. For more information, see <a href="https://docs.microsoft.com/en-us/powershell/scripting/install/installing-windows-powershell">Installing PowerShell</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.NoLogo"/></em></p>
        ///   <p>Hides the copyright banner at startup.</p>
        /// </summary>
        [Pure]
        public static T SetNoLogo<T>(this T toolSettings, bool? noLogo) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.NoLogo"/></em></p>
        ///   <p>Hides the copyright banner at startup.</p>
        /// </summary>
        [Pure]
        public static T ResetNoLogo<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellSettings.NoLogo"/></em></p>
        ///   <p>Hides the copyright banner at startup.</p>
        /// </summary>
        [Pure]
        public static T EnableNoLogo<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellSettings.NoLogo"/></em></p>
        ///   <p>Hides the copyright banner at startup.</p>
        /// </summary>
        [Pure]
        public static T DisableNoLogo<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellSettings.NoLogo"/></em></p>
        ///   <p>Hides the copyright banner at startup.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoLogo<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region NoExit
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.NoExit"/></em></p>
        ///   <p>Does not exit after running startup commands.</p>
        /// </summary>
        [Pure]
        public static T SetNoExit<T>(this T toolSettings, bool? noExit) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoExit = noExit;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.NoExit"/></em></p>
        ///   <p>Does not exit after running startup commands.</p>
        /// </summary>
        [Pure]
        public static T ResetNoExit<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoExit = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellSettings.NoExit"/></em></p>
        ///   <p>Does not exit after running startup commands.</p>
        /// </summary>
        [Pure]
        public static T EnableNoExit<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoExit = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellSettings.NoExit"/></em></p>
        ///   <p>Does not exit after running startup commands.</p>
        /// </summary>
        [Pure]
        public static T DisableNoExit<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoExit = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellSettings.NoExit"/></em></p>
        ///   <p>Does not exit after running startup commands.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoExit<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoExit = !toolSettings.NoExit;
            return toolSettings;
        }
        #endregion
        #region StartUsingASingleThreadedApartment
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></em></p>
        ///   <p>Starts PowerShell using a single-threaded apartment. In Windows PowerShell 2.0, multi-threaded apartment (MTA) is the default. In Windows PowerShell 3.0, single-threaded apartment (STA) is the default.</p>
        /// </summary>
        [Pure]
        public static T SetStartUsingASingleThreadedApartment<T>(this T toolSettings, bool? startUsingASingleThreadedApartment) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingASingleThreadedApartment = startUsingASingleThreadedApartment;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></em></p>
        ///   <p>Starts PowerShell using a single-threaded apartment. In Windows PowerShell 2.0, multi-threaded apartment (MTA) is the default. In Windows PowerShell 3.0, single-threaded apartment (STA) is the default.</p>
        /// </summary>
        [Pure]
        public static T ResetStartUsingASingleThreadedApartment<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingASingleThreadedApartment = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></em></p>
        ///   <p>Starts PowerShell using a single-threaded apartment. In Windows PowerShell 2.0, multi-threaded apartment (MTA) is the default. In Windows PowerShell 3.0, single-threaded apartment (STA) is the default.</p>
        /// </summary>
        [Pure]
        public static T EnableStartUsingASingleThreadedApartment<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingASingleThreadedApartment = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></em></p>
        ///   <p>Starts PowerShell using a single-threaded apartment. In Windows PowerShell 2.0, multi-threaded apartment (MTA) is the default. In Windows PowerShell 3.0, single-threaded apartment (STA) is the default.</p>
        /// </summary>
        [Pure]
        public static T DisableStartUsingASingleThreadedApartment<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingASingleThreadedApartment = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></em></p>
        ///   <p>Starts PowerShell using a single-threaded apartment. In Windows PowerShell 2.0, multi-threaded apartment (MTA) is the default. In Windows PowerShell 3.0, single-threaded apartment (STA) is the default.</p>
        /// </summary>
        [Pure]
        public static T ToggleStartUsingASingleThreadedApartment<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingASingleThreadedApartment = !toolSettings.StartUsingASingleThreadedApartment;
            return toolSettings;
        }
        #endregion
        #region StartUsingAMultiThreadedApartment
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/></em></p>
        ///   <p>Starts PowerShell using a multi-threaded apartment. This parameter is introduced in PowerShell 3.0. In PowerShell 2.0, multi-threaded apartment (MTA) is the default. In PowerShell 3.0, single-threaded apartment (STA) is the default.</p>
        /// </summary>
        [Pure]
        public static T SetStartUsingAMultiThreadedApartment<T>(this T toolSettings, bool? startUsingAMultiThreadedApartment) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingAMultiThreadedApartment = startUsingAMultiThreadedApartment;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/></em></p>
        ///   <p>Starts PowerShell using a multi-threaded apartment. This parameter is introduced in PowerShell 3.0. In PowerShell 2.0, multi-threaded apartment (MTA) is the default. In PowerShell 3.0, single-threaded apartment (STA) is the default.</p>
        /// </summary>
        [Pure]
        public static T ResetStartUsingAMultiThreadedApartment<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingAMultiThreadedApartment = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/></em></p>
        ///   <p>Starts PowerShell using a multi-threaded apartment. This parameter is introduced in PowerShell 3.0. In PowerShell 2.0, multi-threaded apartment (MTA) is the default. In PowerShell 3.0, single-threaded apartment (STA) is the default.</p>
        /// </summary>
        [Pure]
        public static T EnableStartUsingAMultiThreadedApartment<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingAMultiThreadedApartment = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/></em></p>
        ///   <p>Starts PowerShell using a multi-threaded apartment. This parameter is introduced in PowerShell 3.0. In PowerShell 2.0, multi-threaded apartment (MTA) is the default. In PowerShell 3.0, single-threaded apartment (STA) is the default.</p>
        /// </summary>
        [Pure]
        public static T DisableStartUsingAMultiThreadedApartment<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingAMultiThreadedApartment = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/></em></p>
        ///   <p>Starts PowerShell using a multi-threaded apartment. This parameter is introduced in PowerShell 3.0. In PowerShell 2.0, multi-threaded apartment (MTA) is the default. In PowerShell 3.0, single-threaded apartment (STA) is the default.</p>
        /// </summary>
        [Pure]
        public static T ToggleStartUsingAMultiThreadedApartment<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartUsingAMultiThreadedApartment = !toolSettings.StartUsingAMultiThreadedApartment;
            return toolSettings;
        }
        #endregion
        #region NoProfile
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.NoProfile"/></em></p>
        ///   <p>Does not load the PowerShell profile.</p>
        /// </summary>
        [Pure]
        public static T SetNoProfile<T>(this T toolSettings, bool? noProfile) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoProfile = noProfile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.NoProfile"/></em></p>
        ///   <p>Does not load the PowerShell profile.</p>
        /// </summary>
        [Pure]
        public static T ResetNoProfile<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoProfile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellSettings.NoProfile"/></em></p>
        ///   <p>Does not load the PowerShell profile.</p>
        /// </summary>
        [Pure]
        public static T EnableNoProfile<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoProfile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellSettings.NoProfile"/></em></p>
        ///   <p>Does not load the PowerShell profile.</p>
        /// </summary>
        [Pure]
        public static T DisableNoProfile<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoProfile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellSettings.NoProfile"/></em></p>
        ///   <p>Does not load the PowerShell profile.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoProfile<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoProfile = !toolSettings.NoProfile;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.NonInteractive"/></em></p>
        ///   <p>Does not present an interactive prompt to the user.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.NonInteractive"/></em></p>
        ///   <p>Does not present an interactive prompt to the user.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PowerShellSettings.NonInteractive"/></em></p>
        ///   <p>Does not present an interactive prompt to the user.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PowerShellSettings.NonInteractive"/></em></p>
        ///   <p>Does not present an interactive prompt to the user.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PowerShellSettings.NonInteractive"/></em></p>
        ///   <p>Does not present an interactive prompt to the user.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region InputFormat
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.InputFormat"/></em></p>
        ///   <p>Describes the format of data sent to PowerShell. Valid values are <c>Text</c> (text strings) or <c>XML</c> (serialized CLIXML format).</p>
        /// </summary>
        [Pure]
        public static T SetInputFormat<T>(this T toolSettings, PowerShellFormat inputFormat) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFormat = inputFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.InputFormat"/></em></p>
        ///   <p>Describes the format of data sent to PowerShell. Valid values are <c>Text</c> (text strings) or <c>XML</c> (serialized CLIXML format).</p>
        /// </summary>
        [Pure]
        public static T ResetInputFormat<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFormat = null;
            return toolSettings;
        }
        #endregion
        #region OutputFormat
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.OutputFormat"/></em></p>
        ///   <p>Determines how output from PowerShell is formatted. Valid values are <c>Text</c>  (text strings) or <c>XML</c>  (serialized CLIXML format).</p>
        /// </summary>
        [Pure]
        public static T SetOutputFormat<T>(this T toolSettings, PowerShellFormat outputFormat) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormat = outputFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.OutputFormat"/></em></p>
        ///   <p>Determines how output from PowerShell is formatted. Valid values are <c>Text</c>  (text strings) or <c>XML</c>  (serialized CLIXML format).</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFormat<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormat = null;
            return toolSettings;
        }
        #endregion
        #region WindowStyle
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.WindowStyle"/></em></p>
        ///   <p>Sets the window style for the session. Valid values are <c>Normal</c>, <c>Minimized</c>, <c>Maximized</c> and <c>Hidden</c>.</p>
        /// </summary>
        [Pure]
        public static T SetWindowStyle<T>(this T toolSettings, PowerShellWindowStyle windowStyle) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowStyle = windowStyle;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.WindowStyle"/></em></p>
        ///   <p>Sets the window style for the session. Valid values are <c>Normal</c>, <c>Minimized</c>, <c>Maximized</c> and <c>Hidden</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetWindowStyle<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowStyle = null;
            return toolSettings;
        }
        #endregion
        #region EncodedCommand
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.EncodedCommand"/></em></p>
        ///   <p>Accepts a base-64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex quotation marks or curly braces. The string must be formatted using UTF-16LE character encoding.</p>
        /// </summary>
        [Pure]
        public static T SetEncodedCommand<T>(this T toolSettings, string encodedCommand) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EncodedCommand = encodedCommand;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.EncodedCommand"/></em></p>
        ///   <p>Accepts a base-64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex quotation marks or curly braces. The string must be formatted using UTF-16LE character encoding.</p>
        /// </summary>
        [Pure]
        public static T ResetEncodedCommand<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EncodedCommand = null;
            return toolSettings;
        }
        #endregion
        #region ConfigurationName
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.ConfigurationName"/></em></p>
        ///   <p>Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.</p>
        /// </summary>
        [Pure]
        public static T SetConfigurationName<T>(this T toolSettings, string configurationName) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationName = configurationName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.ConfigurationName"/></em></p>
        ///   <p>Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigurationName<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationName = null;
            return toolSettings;
        }
        #endregion
        #region ExecutionPolicy
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.ExecutionPolicy"/></em></p>
        ///   <p>Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. For information about PowerShell execution policies, including a list of valid values, see <a href="https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies">about_Execution_Policies</a>.</p>
        /// </summary>
        [Pure]
        public static T SetExecutionPolicy<T>(this T toolSettings, string executionPolicy) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExecutionPolicy = executionPolicy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.ExecutionPolicy"/></em></p>
        ///   <p>Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. For information about PowerShell execution policies, including a list of valid values, see <a href="https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies">about_Execution_Policies</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetExecutionPolicy<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExecutionPolicy = null;
            return toolSettings;
        }
        #endregion
        #region File
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.File"/></em></p>
        ///   <p>If the value of File is <c>-</c>, the command text is read from standard input. Running <c>powershell -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the <c>File</c> parameter at all.<para/>If the value of File is a file path, the script runs in the local scope (<c>dot-sourced</c>), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. <c>File</c> must be the last parameter in the command. All values typed after the <c>File</c> parameter are interpreted as the script file path and parameters passed to that script. Parameters passed to the script are passed as literal strings, after interpretation by the current shell. For example, if you are in cmd.exe and want to pass an environment variable value, you would use the cmd.exe syntax: <c>powershell.exe -File .\test.ps1 -TestParam %windir%</c>.<para/>In contrast, running <c>powershell.exe -File .\test.ps1 -TestParam $env:windir</c> in cmd.exe results in the script receiving the literal string <c>$env:windir</c> because it has no special meaning to the current cmd.exe shell. The <c>$env:windir</c> style of environment variable reference can be used inside a Command parameter, since there it will be interpreted as PowerShell code.<para/>Similarly, if you want to execute the same command from a Batch script, you would use <c>%~dp0</c> instead of <c>.\</c> or <c>$PSScriptRoot</c> to represent the current execution directory: <c>powershell.exe -File %~dp0test.ps1 -TestParam %windir%</c>. If you instead used <c>.\test.ps1</c>, PowerShell would throw an error because it cannot find the literal path <c>.\test.ps1</c>.<para/>When the value of <c>File</c> is a file path, <c>File</c> must be the last parameter in the command because any characters typed after the <c>File</c> parameter name are interpreted as the script file path followed by the script parameters.<para/>You can include the script parameters and values in the value of the <c>File</c> parameter. For example: <c>-File .\Get-Script.ps1 -Domain Central</c>.<para/>Typically, the switch parameters of a script are either included or omitted. For example, the following command uses the <c>All</c> parameter of the <c>Get-Script.ps1</c> script file: <c>-File .\Get-Script.ps1 -All</c>.<para/>In rare cases, you might need to provide a Boolean value for a parameter. It is not possible to pass an explicit boolean value for a switch parameter when running a script in this way. This limitation was removed in PowerShell 6 (<c>pwsh.exe</c>).</p>
        /// </summary>
        [Pure]
        public static T SetFile<T>(this T toolSettings, string file) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.File"/></em></p>
        ///   <p>If the value of File is <c>-</c>, the command text is read from standard input. Running <c>powershell -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the <c>File</c> parameter at all.<para/>If the value of File is a file path, the script runs in the local scope (<c>dot-sourced</c>), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. <c>File</c> must be the last parameter in the command. All values typed after the <c>File</c> parameter are interpreted as the script file path and parameters passed to that script. Parameters passed to the script are passed as literal strings, after interpretation by the current shell. For example, if you are in cmd.exe and want to pass an environment variable value, you would use the cmd.exe syntax: <c>powershell.exe -File .\test.ps1 -TestParam %windir%</c>.<para/>In contrast, running <c>powershell.exe -File .\test.ps1 -TestParam $env:windir</c> in cmd.exe results in the script receiving the literal string <c>$env:windir</c> because it has no special meaning to the current cmd.exe shell. The <c>$env:windir</c> style of environment variable reference can be used inside a Command parameter, since there it will be interpreted as PowerShell code.<para/>Similarly, if you want to execute the same command from a Batch script, you would use <c>%~dp0</c> instead of <c>.\</c> or <c>$PSScriptRoot</c> to represent the current execution directory: <c>powershell.exe -File %~dp0test.ps1 -TestParam %windir%</c>. If you instead used <c>.\test.ps1</c>, PowerShell would throw an error because it cannot find the literal path <c>.\test.ps1</c>.<para/>When the value of <c>File</c> is a file path, <c>File</c> must be the last parameter in the command because any characters typed after the <c>File</c> parameter name are interpreted as the script file path followed by the script parameters.<para/>You can include the script parameters and values in the value of the <c>File</c> parameter. For example: <c>-File .\Get-Script.ps1 -Domain Central</c>.<para/>Typically, the switch parameters of a script are either included or omitted. For example, the following command uses the <c>All</c> parameter of the <c>Get-Script.ps1</c> script file: <c>-File .\Get-Script.ps1 -All</c>.<para/>In rare cases, you might need to provide a Boolean value for a parameter. It is not possible to pass an explicit boolean value for a switch parameter when running a script in this way. This limitation was removed in PowerShell 6 (<c>pwsh.exe</c>).</p>
        /// </summary>
        [Pure]
        public static T ResetFile<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region FileArguments
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.FileArguments"/> to a new list</em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetFileArguments<T>(this T toolSettings, params string[] fileArguments) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileArgumentsInternal = fileArguments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.FileArguments"/> to a new list</em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetFileArguments<T>(this T toolSettings, IEnumerable<string> fileArguments) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileArgumentsInternal = fileArguments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="PowerShellSettings.FileArguments"/></em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T AddFileArguments<T>(this T toolSettings, params string[] fileArguments) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileArgumentsInternal.AddRange(fileArguments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="PowerShellSettings.FileArguments"/></em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T AddFileArguments<T>(this T toolSettings, IEnumerable<string> fileArguments) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileArgumentsInternal.AddRange(fileArguments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="PowerShellSettings.FileArguments"/></em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T ClearFileArguments<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileArgumentsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="PowerShellSettings.FileArguments"/></em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T RemoveFileArguments<T>(this T toolSettings, params string[] fileArguments) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fileArguments);
            toolSettings.FileArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="PowerShellSettings.FileArguments"/></em></p>
        ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T RemoveFileArguments<T>(this T toolSettings, IEnumerable<string> fileArguments) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fileArguments);
            toolSettings.FileArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region FileKeyValueParameters
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.FileKeyValueParameters"/> to a new dictionary</em></p>
        ///   <p>Key-value pairs passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetFileKeyValueParameters<T>(this T toolSettings, IDictionary<string, string> fileKeyValueParameters) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueParametersInternal = fileKeyValueParameters.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="PowerShellSettings.FileKeyValueParameters"/></em></p>
        ///   <p>Key-value pairs passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T ClearFileKeyValueParameters<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueParametersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="PowerShellSettings.FileKeyValueParameters"/></em></p>
        ///   <p>Key-value pairs passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T AddFileKeyValueParameter<T>(this T toolSettings, string fileKeyValueParameterKey, string fileKeyValueParameterValue) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueParametersInternal.Add(fileKeyValueParameterKey, fileKeyValueParameterValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="PowerShellSettings.FileKeyValueParameters"/></em></p>
        ///   <p>Key-value pairs passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T RemoveFileKeyValueParameter<T>(this T toolSettings, string fileKeyValueParameterKey) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueParametersInternal.Remove(fileKeyValueParameterKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="PowerShellSettings.FileKeyValueParameters"/></em></p>
        ///   <p>Key-value pairs passed in when using the <c>-File</c> option.</p>
        /// </summary>
        [Pure]
        public static T SetFileKeyValueParameter<T>(this T toolSettings, string fileKeyValueParameterKey, string fileKeyValueParameterValue) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueParametersInternal[fileKeyValueParameterKey] = fileKeyValueParameterValue;
            return toolSettings;
        }
        #endregion
        #region Command
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.Command"/></em></p>
        ///   <p>Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of Command can be <c>-</c>, a script block, or a string. If the value of <c>Command</c> is <c>-</c>, the command text is read from standard input.<para/>The <c>Command</c> parameter only accepts a script block for execution when it can recognize the value passed to <c>Command</c> as a <c>ScriptBlock</c> type. This is only possible when running <c>powershell.exe</c> from another PowerShell host. The <c>ScriptBlock</c> type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to <c>powershell.exe</c>.</p>
        /// </summary>
        [Pure]
        public static T SetCommand<T>(this T toolSettings, string command) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.Command"/></em></p>
        ///   <p>Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of Command can be <c>-</c>, a script block, or a string. If the value of <c>Command</c> is <c>-</c>, the command text is read from standard input.<para/>The <c>Command</c> parameter only accepts a script block for execution when it can recognize the value passed to <c>Command</c> as a <c>ScriptBlock</c> type. This is only possible when running <c>powershell.exe</c> from another PowerShell host. The <c>ScriptBlock</c> type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to <c>powershell.exe</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetCommand<T>(this T toolSettings) where T : PowerShellSettings
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
    ///   Used within <see cref="PowerShellTasks"/>.
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
    ///   Used within <see cref="PowerShellTasks"/>.
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
}
