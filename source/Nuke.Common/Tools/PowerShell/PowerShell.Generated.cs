// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/PowerShell.json

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

namespace Nuke.Common.Tools.PowerShell
{
    /// <summary>
    ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PowerShellTasks
    {
        /// <summary>
        ///   Path to the PowerShell executable.
        /// </summary>
        public static string PowerShellPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("POWERSHELL_EXE") ??
            ToolPathResolver.GetPathExecutable("powershell");
        public static Action<OutputType, string> PowerShellLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> PowerShell(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, bool? logTimestamp = null, string logFile = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(PowerShellPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logTimestamp, logFile, PowerShellLogger, outputFilter);
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
        ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PowerShellSettings.FileArguments"/></li>
        ///     <li><c>-</c> via <see cref="PowerShellSettings.FileKeyValueArguments"/></li>
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
        ///     <li><c>-PSConsoleFile</c> via <see cref="PowerShellSettings.PowerShellConsoleFile"/></li>
        ///     <li><c>-Sta</c> via <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></li>
        ///     <li><c>-Version</c> via <see cref="PowerShellSettings.PowerShellVersion"/></li>
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
        ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PowerShellSettings.FileArguments"/></li>
        ///     <li><c>-</c> via <see cref="PowerShellSettings.FileKeyValueArguments"/></li>
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
        ///     <li><c>-PSConsoleFile</c> via <see cref="PowerShellSettings.PowerShellConsoleFile"/></li>
        ///     <li><c>-Sta</c> via <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></li>
        ///     <li><c>-Version</c> via <see cref="PowerShellSettings.PowerShellVersion"/></li>
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
        ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PowerShellSettings.FileArguments"/></li>
        ///     <li><c>-</c> via <see cref="PowerShellSettings.FileKeyValueArguments"/></li>
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
        ///     <li><c>-PSConsoleFile</c> via <see cref="PowerShellSettings.PowerShellConsoleFile"/></li>
        ///     <li><c>-Sta</c> via <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></li>
        ///     <li><c>-Version</c> via <see cref="PowerShellSettings.PowerShellVersion"/></li>
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
        public override string ProcessToolPath => base.ProcessToolPath ?? PowerShellTasks.PowerShellPath;
        public override Action<OutputType, string> ProcessCustomLogger => PowerShellTasks.PowerShellLogger;
        /// <summary>
        ///   Loads the specified PowerShell console file. Enter the path and name of the console file. To create a console file, use the Export-Console cmdlet in PowerShell.
        /// </summary>
        public virtual string PowerShellConsoleFile { get; internal set; }
        /// <summary>
        ///   Starts the specified version of PowerShell. Valid values are 2.0 and 3.0. The version that you specify must be installed on the system. If Windows PowerShell 3.0 is installed on the computer, "3.0" is the default version.
        /// </summary>
        public virtual string PowerShellVersion { get; internal set; }
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
        ///   Describes the format of data sent to PowerShell. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).
        /// </summary>
        public virtual string InputFormat { get; internal set; }
        /// <summary>
        ///   Determines how output from PowerShell is formatted. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).
        /// </summary>
        public virtual string OutputFormat { get; internal set; }
        /// <summary>
        ///   Sets the window style for the session. Valid values are Normal, Minimized, Maximized and Hidden.
        /// </summary>
        public virtual string WindowStyle { get; internal set; }
        /// <summary>
        ///   Accepts a base-64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex quotation marks or curly braces. The string must be formatted using UTF-16LE character encoding.
        /// </summary>
        public virtual string EncodedCommand { get; internal set; }
        /// <summary>
        ///   Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.
        /// </summary>
        public virtual string ConfigurationName { get; internal set; }
        /// <summary>
        ///   Sets the default execution policy for the current session and saves it in the $env:PSExecutionPolicyPreference environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. For information about PowerShell execution policies, including a list of valid values, see about_Execution_Policies(https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-5.1).
        /// </summary>
        public virtual string ExecutionPolicy { get; internal set; }
        /// <summary>
        ///   If the value of File is "-", the command text is read from standard input. Running powershell -File - without redirected standard input starts a regular session. This is the same as not specifying the File parameter at all. 
///If the value of File is a file path, the script runs in the local scope ("dot-sourced"), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. File must be the last parameter in the command. All values typed after the File parameter are interpreted as the script file path and parameters passed to that script. Parameters passed to the script are passed as literal strings, after interpretation by the current shell. For example, if you are in cmd.exe and want to pass an environment variable value, you would use the cmd.exe syntax: powershell.exe -File .\test.ps1 -TestParam %windir%. 
/// In contrast, running powershell.exe -File .\test.ps1 -TestParam $env:windir in cmd.exe results in the script receiving the literal string $env:windir because it has no special meaning to the current cmd.exe shell. The $env:windir style of environment variable reference can be used inside a Command parameter, since there it will be interpreted as PowerShell code. 
///Similarly, if you want to execute the same command from a Batch script, you would use %~dp0 instead of .\ or $PSScriptRoot to represent the current execution directory: powershell.exe -File %~dp0test.ps1 -TestParam %windir%. If you instead used .\test.ps1, PowerShell would throw an error because it cannot find the literal path .\test.ps1 
///When the value of File is a file path, File must be the last parameter in the command because any characters typed after the File parameter name are interpreted as the script file path followed by the script parameters. 
///You can include the script parameters and values in the value of the File parameter. For example: -File .\Get-Script.ps1 -Domain Central 
///Typically, the switch parameters of a script are either included or omitted. For example, the following command uses the All parameter of the Get-Script.ps1 script file: -File .\Get-Script.ps1 -All 
///In rare cases, you might need to provide a Boolean value for a parameter. It is not possible to pass an explicit boolean value for a switch parameter when running a script in this way. This limitation was removed in PowerShell 6 (pwsh.exe).
        /// </summary>
        public virtual string File { get; internal set; }
        /// <summary>
        ///   Arguments passed in when using the -File option
        /// </summary>
        public virtual IReadOnlyList<string> FileArguments => FileArgumentsInternal.AsReadOnly();
        internal List<string> FileArgumentsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Arguments passed in when using the -File option
        /// </summary>
        public virtual IReadOnlyList<string> FileArguments => FileArgumentsInternal.AsReadOnly();
        internal List<string> FileArgumentsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Pass in arguments by parameter name Ex. -Name "Test"</c>
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> FileKeyValueArguments => FileKeyValueArgumentsInternal.AsReadOnly();
        internal Dictionary<string, string> FileKeyValueArgumentsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the NoExit parameter is specified. 
///The value of Command can be -, a script block, or a string. If the value of Command is -, the command text is read from standard input. 
///The Command parameter only accepts a script block for execution when it can recognize the value passed to Command as a ScriptBlock type. This is only possible when running powershell.exe from another PowerShell host. The ScriptBlock type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces ({}), before being passed to powershell.exe.
        /// </summary>
        public virtual string Command { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("-PSConsoleFile {value}", PowerShellConsoleFile)
              .Add("-Version {value}", PowerShellVersion)
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
              .Add("{value}", FileArguments)
              .Add("-{value}", FileKeyValueArguments, "{key} {value}")
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
        #region PowerShellConsoleFile
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.PowerShellConsoleFile"/></em></p>
        ///   <p>Loads the specified PowerShell console file. Enter the path and name of the console file. To create a console file, use the Export-Console cmdlet in PowerShell.</p>
        /// </summary>
        [Pure]
        public static T SetPowerShellConsoleFile<T>(this T toolSettings, string powerShellConsoleFile) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PowerShellConsoleFile = powerShellConsoleFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.PowerShellConsoleFile"/></em></p>
        ///   <p>Loads the specified PowerShell console file. Enter the path and name of the console file. To create a console file, use the Export-Console cmdlet in PowerShell.</p>
        /// </summary>
        [Pure]
        public static T ResetPowerShellConsoleFile<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PowerShellConsoleFile = null;
            return toolSettings;
        }
        #endregion
        #region PowerShellVersion
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.PowerShellVersion"/></em></p>
        ///   <p>Starts the specified version of PowerShell. Valid values are 2.0 and 3.0. The version that you specify must be installed on the system. If Windows PowerShell 3.0 is installed on the computer, "3.0" is the default version.</p>
        /// </summary>
        [Pure]
        public static T SetPowerShellVersion<T>(this T toolSettings, string powerShellVersion) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PowerShellVersion = powerShellVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.PowerShellVersion"/></em></p>
        ///   <p>Starts the specified version of PowerShell. Valid values are 2.0 and 3.0. The version that you specify must be installed on the system. If Windows PowerShell 3.0 is installed on the computer, "3.0" is the default version.</p>
        /// </summary>
        [Pure]
        public static T ResetPowerShellVersion<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PowerShellVersion = null;
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
        ///   <p>Describes the format of data sent to PowerShell. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).</p>
        /// </summary>
        [Pure]
        public static T SetInputFormat<T>(this T toolSettings, string inputFormat) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFormat = inputFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.InputFormat"/></em></p>
        ///   <p>Describes the format of data sent to PowerShell. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).</p>
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
        ///   <p>Determines how output from PowerShell is formatted. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).</p>
        /// </summary>
        [Pure]
        public static T SetOutputFormat<T>(this T toolSettings, string outputFormat) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormat = outputFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.OutputFormat"/></em></p>
        ///   <p>Determines how output from PowerShell is formatted. Valid values are "Text" (text strings) or "XML" (serialized CLIXML format).</p>
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
        ///   <p>Sets the window style for the session. Valid values are Normal, Minimized, Maximized and Hidden.</p>
        /// </summary>
        [Pure]
        public static T SetWindowStyle<T>(this T toolSettings, string windowStyle) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WindowStyle = windowStyle;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PowerShellSettings.WindowStyle"/></em></p>
        ///   <p>Sets the window style for the session. Valid values are Normal, Minimized, Maximized and Hidden.</p>
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
        ///   <p>Sets the default execution policy for the current session and saves it in the $env:PSExecutionPolicyPreference environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. For information about PowerShell execution policies, including a list of valid values, see about_Execution_Policies(https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-5.1).</p>
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
        ///   <p>Sets the default execution policy for the current session and saves it in the $env:PSExecutionPolicyPreference environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. For information about PowerShell execution policies, including a list of valid values, see about_Execution_Policies(https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-5.1).</p>
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
        ///   <p>If the value of File is "-", the command text is read from standard input. Running powershell -File - without redirected standard input starts a regular session. This is the same as not specifying the File parameter at all. 
///If the value of File is a file path, the script runs in the local scope ("dot-sourced"), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. File must be the last parameter in the command. All values typed after the File parameter are interpreted as the script file path and parameters passed to that script. Parameters passed to the script are passed as literal strings, after interpretation by the current shell. For example, if you are in cmd.exe and want to pass an environment variable value, you would use the cmd.exe syntax: powershell.exe -File .\test.ps1 -TestParam %windir%. 
/// In contrast, running powershell.exe -File .\test.ps1 -TestParam $env:windir in cmd.exe results in the script receiving the literal string $env:windir because it has no special meaning to the current cmd.exe shell. The $env:windir style of environment variable reference can be used inside a Command parameter, since there it will be interpreted as PowerShell code. 
///Similarly, if you want to execute the same command from a Batch script, you would use %~dp0 instead of .\ or $PSScriptRoot to represent the current execution directory: powershell.exe -File %~dp0test.ps1 -TestParam %windir%. If you instead used .\test.ps1, PowerShell would throw an error because it cannot find the literal path .\test.ps1 
///When the value of File is a file path, File must be the last parameter in the command because any characters typed after the File parameter name are interpreted as the script file path followed by the script parameters. 
///You can include the script parameters and values in the value of the File parameter. For example: -File .\Get-Script.ps1 -Domain Central 
///Typically, the switch parameters of a script are either included or omitted. For example, the following command uses the All parameter of the Get-Script.ps1 script file: -File .\Get-Script.ps1 -All 
///In rare cases, you might need to provide a Boolean value for a parameter. It is not possible to pass an explicit boolean value for a switch parameter when running a script in this way. This limitation was removed in PowerShell 6 (pwsh.exe).</p>
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
        ///   <p>If the value of File is "-", the command text is read from standard input. Running powershell -File - without redirected standard input starts a regular session. This is the same as not specifying the File parameter at all. 
///If the value of File is a file path, the script runs in the local scope ("dot-sourced"), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. File must be the last parameter in the command. All values typed after the File parameter are interpreted as the script file path and parameters passed to that script. Parameters passed to the script are passed as literal strings, after interpretation by the current shell. For example, if you are in cmd.exe and want to pass an environment variable value, you would use the cmd.exe syntax: powershell.exe -File .\test.ps1 -TestParam %windir%. 
/// In contrast, running powershell.exe -File .\test.ps1 -TestParam $env:windir in cmd.exe results in the script receiving the literal string $env:windir because it has no special meaning to the current cmd.exe shell. The $env:windir style of environment variable reference can be used inside a Command parameter, since there it will be interpreted as PowerShell code. 
///Similarly, if you want to execute the same command from a Batch script, you would use %~dp0 instead of .\ or $PSScriptRoot to represent the current execution directory: powershell.exe -File %~dp0test.ps1 -TestParam %windir%. If you instead used .\test.ps1, PowerShell would throw an error because it cannot find the literal path .\test.ps1 
///When the value of File is a file path, File must be the last parameter in the command because any characters typed after the File parameter name are interpreted as the script file path followed by the script parameters. 
///You can include the script parameters and values in the value of the File parameter. For example: -File .\Get-Script.ps1 -Domain Central 
///Typically, the switch parameters of a script are either included or omitted. For example, the following command uses the All parameter of the Get-Script.ps1 script file: -File .\Get-Script.ps1 -All 
///In rare cases, you might need to provide a Boolean value for a parameter. It is not possible to pass an explicit boolean value for a switch parameter when running a script in this way. This limitation was removed in PowerShell 6 (pwsh.exe).</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        #region FileArguments
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.FileArguments"/> to a new list</em></p>
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        ///   <p>Arguments passed in when using the -File option</p>
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
        #region FileKeyValueArguments
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.FileKeyValueArguments"/> to a new dictionary</em></p>
        ///   <p>Pass in arguments by parameter name Ex. -Name "Test"</c></p>
        /// </summary>
        [Pure]
        public static T SetFileKeyValueArguments<T>(this T toolSettings, IDictionary<string, string> fileKeyValueArguments) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueArgumentsInternal = fileKeyValueArguments.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="PowerShellSettings.FileKeyValueArguments"/></em></p>
        ///   <p>Pass in arguments by parameter name Ex. -Name "Test"</c></p>
        /// </summary>
        [Pure]
        public static T ClearFileKeyValueArguments<T>(this T toolSettings) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueArgumentsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="PowerShellSettings.FileKeyValueArguments"/></em></p>
        ///   <p>Pass in arguments by parameter name Ex. -Name "Test"</c></p>
        /// </summary>
        [Pure]
        public static T AddFileKeyValueArgument<T>(this T toolSettings, string fileKeyValueArgumentKey, string fileKeyValueArgumentValue) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueArgumentsInternal.Add(fileKeyValueArgumentKey, fileKeyValueArgumentValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="PowerShellSettings.FileKeyValueArguments"/></em></p>
        ///   <p>Pass in arguments by parameter name Ex. -Name "Test"</c></p>
        /// </summary>
        [Pure]
        public static T RemoveFileKeyValueArgument<T>(this T toolSettings, string fileKeyValueArgumentKey) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueArgumentsInternal.Remove(fileKeyValueArgumentKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="PowerShellSettings.FileKeyValueArguments"/></em></p>
        ///   <p>Pass in arguments by parameter name Ex. -Name "Test"</c></p>
        /// </summary>
        [Pure]
        public static T SetFileKeyValueArgument<T>(this T toolSettings, string fileKeyValueArgumentKey, string fileKeyValueArgumentValue) where T : PowerShellSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileKeyValueArgumentsInternal[fileKeyValueArgumentKey] = fileKeyValueArgumentValue;
            return toolSettings;
        }
        #endregion
        #region Command
        /// <summary>
        ///   <p><em>Sets <see cref="PowerShellSettings.Command"/></em></p>
        ///   <p>Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the NoExit parameter is specified. 
///The value of Command can be -, a script block, or a string. If the value of Command is -, the command text is read from standard input. 
///The Command parameter only accepts a script block for execution when it can recognize the value passed to Command as a ScriptBlock type. This is only possible when running powershell.exe from another PowerShell host. The ScriptBlock type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces ({}), before being passed to powershell.exe.</p>
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
        ///   <p>Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the NoExit parameter is specified. 
///The value of Command can be -, a script block, or a string. If the value of Command is -, the command text is read from standard input. 
///The Command parameter only accepts a script block for execution when it can recognize the value passed to Command as a ScriptBlock type. This is only possible when running powershell.exe from another PowerShell host. The ScriptBlock type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces ({}), before being passed to powershell.exe.</p>
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
}
