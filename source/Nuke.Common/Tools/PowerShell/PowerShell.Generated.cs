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

namespace Nuke.Common.Tools.PowerShell;

/// <summary><p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public partial class PowerShellTasks : ToolTasks
{
    public static string PowerShellPath { get => new PowerShellTasks().GetToolPathInternal(); set => new PowerShellTasks().SetToolPath(value); }
    /// <summary><p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> PowerShell(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new PowerShellTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="https://www.nuke.build/docs/common/cli-tools/#fluent-api">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;fileArguments&gt;</c> via <see cref="PowerShellSettings.FileArguments"/></li><li><c>-</c> via <see cref="PowerShellSettings.FileKeyValueParameters"/></li><li><c>-Command</c> via <see cref="PowerShellSettings.Command"/></li><li><c>-ConfigurationName</c> via <see cref="PowerShellSettings.ConfigurationName"/></li><li><c>-EncodedCommand</c> via <see cref="PowerShellSettings.EncodedCommand"/></li><li><c>-ExecutionPolicy</c> via <see cref="PowerShellSettings.ExecutionPolicy"/></li><li><c>-File</c> via <see cref="PowerShellSettings.File"/></li><li><c>-InputFormat</c> via <see cref="PowerShellSettings.InputFormat"/></li><li><c>-Mta</c> via <see cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/></li><li><c>-NoExit</c> via <see cref="PowerShellSettings.NoExit"/></li><li><c>-NoLogo</c> via <see cref="PowerShellSettings.NoLogo"/></li><li><c>-NonInteractive</c> via <see cref="PowerShellSettings.NonInteractive"/></li><li><c>-NoProfile</c> via <see cref="PowerShellSettings.NoProfile"/></li><li><c>-OutputFormat</c> via <see cref="PowerShellSettings.OutputFormat"/></li><li><c>-PSConsoleFile</c> via <see cref="PowerShellSettings.ConsoleFile"/></li><li><c>-Sta</c> via <see cref="PowerShellSettings.StartUsingASingleThreadedApartment"/></li><li><c>-Version</c> via <see cref="PowerShellSettings.Version"/></li><li><c>-WindowStyle</c> via <see cref="PowerShellSettings.WindowStyle"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PowerShell(PowerShellSettings options = null) => new PowerShellTasks().Run<PowerShellSettings>(options);
    /// <inheritdoc cref="PowerShellTasks.PowerShell(Nuke.Common.Tools.PowerShell.PowerShellSettings)"/>
    public static IReadOnlyCollection<Output> PowerShell(Configure<PowerShellSettings> configurator) => new PowerShellTasks().Run<PowerShellSettings>(configurator.Invoke(new PowerShellSettings()));
    /// <inheritdoc cref="PowerShellTasks.PowerShell(Nuke.Common.Tools.PowerShell.PowerShellSettings)"/>
    public static IEnumerable<(PowerShellSettings Settings, IReadOnlyCollection<Output> Output)> PowerShell(CombinatorialConfigure<PowerShellSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PowerShell, degreeOfParallelism, completeOnFailure);
}
#region PowerShellSettings
/// <inheritdoc cref="PowerShellTasks.PowerShell(Nuke.Common.Tools.PowerShell.PowerShellSettings)"/>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Command(Type = typeof(PowerShellTasks), Command = nameof(PowerShellTasks.PowerShell))]
public partial class PowerShellSettings : ToolOptions
{
    /// <summary>Loads the specified PowerShell console file. Enter the path and name of the console file. To create a console file, use the Export-Console cmdlet in PowerShell.</summary>
    [Argument(Format = "-PSConsoleFile {value}")] public string ConsoleFile => Get<string>(() => ConsoleFile);
    /// <summary>Starts the specified version of PowerShell. Valid values are 2.0 and 3.0. The version that you specify must be installed on the system. If Windows PowerShell 3.0 is installed on the computer, <c>3.0</c> is the default version. Otherwise, <c>2.0</c> is the default version. For more information, see <a href="https://docs.microsoft.com/en-us/powershell/scripting/install/installing-windows-powershell">Installing PowerShell</a>.</summary>
    [Argument(Format = "-Version {value}")] public string Version => Get<string>(() => Version);
    /// <summary>Hides the copyright banner at startup.</summary>
    [Argument(Format = "-NoLogo")] public bool? NoLogo => Get<bool?>(() => NoLogo);
    /// <summary>Does not exit after running startup commands.</summary>
    [Argument(Format = "-NoExit")] public bool? NoExit => Get<bool?>(() => NoExit);
    /// <summary>Starts PowerShell using a single-threaded apartment. In Windows PowerShell 2.0, multi-threaded apartment (MTA) is the default. In Windows PowerShell 3.0, single-threaded apartment (STA) is the default.</summary>
    [Argument(Format = "-Sta")] public bool? StartUsingASingleThreadedApartment => Get<bool?>(() => StartUsingASingleThreadedApartment);
    /// <summary>Starts PowerShell using a multi-threaded apartment. This parameter is introduced in PowerShell 3.0. In PowerShell 2.0, multi-threaded apartment (MTA) is the default. In PowerShell 3.0, single-threaded apartment (STA) is the default.</summary>
    [Argument(Format = "-Mta")] public bool? StartUsingAMultiThreadedApartment => Get<bool?>(() => StartUsingAMultiThreadedApartment);
    /// <summary>Does not load the PowerShell profile.</summary>
    [Argument(Format = "-NoProfile")] public bool? NoProfile => Get<bool?>(() => NoProfile);
    /// <summary>Does not present an interactive prompt to the user.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Describes the format of data sent to PowerShell. Valid values are <c>Text</c> (text strings) or <c>XML</c> (serialized CLIXML format).</summary>
    [Argument(Format = "-InputFormat {value}")] public PowerShellFormat InputFormat => Get<PowerShellFormat>(() => InputFormat);
    /// <summary>Determines how output from PowerShell is formatted. Valid values are <c>Text</c>  (text strings) or <c>XML</c>  (serialized CLIXML format).</summary>
    [Argument(Format = "-OutputFormat {value}")] public PowerShellFormat OutputFormat => Get<PowerShellFormat>(() => OutputFormat);
    /// <summary>Sets the window style for the session. Valid values are <c>Normal</c>, <c>Minimized</c>, <c>Maximized</c> and <c>Hidden</c>.</summary>
    [Argument(Format = "-WindowStyle {value}")] public PowerShellWindowStyle WindowStyle => Get<PowerShellWindowStyle>(() => WindowStyle);
    /// <summary>Accepts a base-64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex quotation marks or curly braces. The string must be formatted using UTF-16LE character encoding.</summary>
    [Argument(Format = "-EncodedCommand {value}")] public string EncodedCommand => Get<string>(() => EncodedCommand);
    /// <summary>Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.</summary>
    [Argument(Format = "-ConfigurationName {value}")] public string ConfigurationName => Get<string>(() => ConfigurationName);
    /// <summary>Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. For information about PowerShell execution policies, including a list of valid values, see <a href="https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies">about_Execution_Policies</a>.</summary>
    [Argument(Format = "-ExecutionPolicy {value}")] public string ExecutionPolicy => Get<string>(() => ExecutionPolicy);
    /// <summary>If the value of File is <c>-</c>, the command text is read from standard input. Running <c>powershell -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the <c>File</c> parameter at all.<para/>If the value of File is a file path, the script runs in the local scope (<c>dot-sourced</c>), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. <c>File</c> must be the last parameter in the command. All values typed after the <c>File</c> parameter are interpreted as the script file path and parameters passed to that script. Parameters passed to the script are passed as literal strings, after interpretation by the current shell. For example, if you are in cmd.exe and want to pass an environment variable value, you would use the cmd.exe syntax: <c>powershell.exe -File .\test.ps1 -TestParam %windir%</c>.<para/>In contrast, running <c>powershell.exe -File .\test.ps1 -TestParam $env:windir</c> in cmd.exe results in the script receiving the literal string <c>$env:windir</c> because it has no special meaning to the current cmd.exe shell. The <c>$env:windir</c> style of environment variable reference can be used inside a Command parameter, since there it will be interpreted as PowerShell code.<para/>Similarly, if you want to execute the same command from a Batch script, you would use <c>%~dp0</c> instead of <c>.\</c> or <c>$PSScriptRoot</c> to represent the current execution directory: <c>powershell.exe -File %~dp0test.ps1 -TestParam %windir%</c>. If you instead used <c>.\test.ps1</c>, PowerShell would throw an error because it cannot find the literal path <c>.\test.ps1</c>.<para/>When the value of <c>File</c> is a file path, <c>File</c> must be the last parameter in the command because any characters typed after the <c>File</c> parameter name are interpreted as the script file path followed by the script parameters.<para/>You can include the script parameters and values in the value of the <c>File</c> parameter. For example: <c>-File .\Get-Script.ps1 -Domain Central</c>.<para/>Typically, the switch parameters of a script are either included or omitted. For example, the following command uses the <c>All</c> parameter of the <c>Get-Script.ps1</c> script file: <c>-File .\Get-Script.ps1 -All</c>.<para/>In rare cases, you might need to provide a Boolean value for a parameter. It is not possible to pass an explicit boolean value for a switch parameter when running a script in this way. This limitation was removed in PowerShell 6 (<c>pwsh.exe</c>).</summary>
    [Argument(Format = "-File  {value}")] public string File => Get<string>(() => File);
    /// <summary>Arguments passed in when using the <c>-File</c> option.</summary>
    [Argument(Format = "{value}")] public IReadOnlyList<string> FileArguments => Get<List<string>>(() => FileArguments);
    /// <summary>Key-value pairs passed in when using the <c>-File</c> option.</summary>
    [Argument(Format = "-{key} {value}", Secret = false)] public IReadOnlyDictionary<string, string> FileKeyValueParameters => Get<Dictionary<string, string>>(() => FileKeyValueParameters);
    /// <summary>Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of Command can be <c>-</c>, a script block, or a string. If the value of <c>Command</c> is <c>-</c>, the command text is read from standard input.<para/>The <c>Command</c> parameter only accepts a script block for execution when it can recognize the value passed to <c>Command</c> as a <c>ScriptBlock</c> type. This is only possible when running <c>powershell.exe</c> from another PowerShell host. The <c>ScriptBlock</c> type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to <c>powershell.exe</c>.</summary>
    [Argument(Format = "-Command {value}")] public string Command => Get<string>(() => Command);
}
#endregion
#region PowerShellSettingsExtensions
/// <inheritdoc cref="PowerShellTasks.PowerShell(Nuke.Common.Tools.PowerShell.PowerShellSettings)"/>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PowerShellSettingsExtensions
{
    #region ConsoleFile
    /// <inheritdoc cref="PowerShellSettings.ConsoleFile"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.ConsoleFile))]
    public static T SetConsoleFile<T>(this T o, string v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.ConsoleFile, v));
    /// <inheritdoc cref="PowerShellSettings.ConsoleFile"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.ConsoleFile))]
    public static T ResetConsoleFile<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.ConsoleFile));
    #endregion
    #region Version
    /// <inheritdoc cref="PowerShellSettings.Version"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="PowerShellSettings.Version"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region NoLogo
    /// <inheritdoc cref="PowerShellSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoLogo))]
    public static T SetNoLogo<T>(this T o, bool? v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoLogo, v));
    /// <inheritdoc cref="PowerShellSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoLogo))]
    public static T ResetNoLogo<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.NoLogo));
    /// <inheritdoc cref="PowerShellSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoLogo))]
    public static T EnableNoLogo<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoLogo, true));
    /// <inheritdoc cref="PowerShellSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoLogo))]
    public static T DisableNoLogo<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoLogo, false));
    /// <inheritdoc cref="PowerShellSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoLogo))]
    public static T ToggleNoLogo<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoLogo, !o.NoLogo));
    #endregion
    #region NoExit
    /// <inheritdoc cref="PowerShellSettings.NoExit"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoExit))]
    public static T SetNoExit<T>(this T o, bool? v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoExit, v));
    /// <inheritdoc cref="PowerShellSettings.NoExit"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoExit))]
    public static T ResetNoExit<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.NoExit));
    /// <inheritdoc cref="PowerShellSettings.NoExit"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoExit))]
    public static T EnableNoExit<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoExit, true));
    /// <inheritdoc cref="PowerShellSettings.NoExit"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoExit))]
    public static T DisableNoExit<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoExit, false));
    /// <inheritdoc cref="PowerShellSettings.NoExit"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoExit))]
    public static T ToggleNoExit<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoExit, !o.NoExit));
    #endregion
    #region StartUsingASingleThreadedApartment
    /// <inheritdoc cref="PowerShellSettings.StartUsingASingleThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.StartUsingASingleThreadedApartment))]
    public static T SetStartUsingASingleThreadedApartment<T>(this T o, bool? v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.StartUsingASingleThreadedApartment, v));
    /// <inheritdoc cref="PowerShellSettings.StartUsingASingleThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.StartUsingASingleThreadedApartment))]
    public static T ResetStartUsingASingleThreadedApartment<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.StartUsingASingleThreadedApartment));
    /// <inheritdoc cref="PowerShellSettings.StartUsingASingleThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.StartUsingASingleThreadedApartment))]
    public static T EnableStartUsingASingleThreadedApartment<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.StartUsingASingleThreadedApartment, true));
    /// <inheritdoc cref="PowerShellSettings.StartUsingASingleThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.StartUsingASingleThreadedApartment))]
    public static T DisableStartUsingASingleThreadedApartment<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.StartUsingASingleThreadedApartment, false));
    /// <inheritdoc cref="PowerShellSettings.StartUsingASingleThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.StartUsingASingleThreadedApartment))]
    public static T ToggleStartUsingASingleThreadedApartment<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.StartUsingASingleThreadedApartment, !o.StartUsingASingleThreadedApartment));
    #endregion
    #region StartUsingAMultiThreadedApartment
    /// <inheritdoc cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.StartUsingAMultiThreadedApartment))]
    public static T SetStartUsingAMultiThreadedApartment<T>(this T o, bool? v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.StartUsingAMultiThreadedApartment, v));
    /// <inheritdoc cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.StartUsingAMultiThreadedApartment))]
    public static T ResetStartUsingAMultiThreadedApartment<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.StartUsingAMultiThreadedApartment));
    /// <inheritdoc cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.StartUsingAMultiThreadedApartment))]
    public static T EnableStartUsingAMultiThreadedApartment<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.StartUsingAMultiThreadedApartment, true));
    /// <inheritdoc cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.StartUsingAMultiThreadedApartment))]
    public static T DisableStartUsingAMultiThreadedApartment<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.StartUsingAMultiThreadedApartment, false));
    /// <inheritdoc cref="PowerShellSettings.StartUsingAMultiThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.StartUsingAMultiThreadedApartment))]
    public static T ToggleStartUsingAMultiThreadedApartment<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.StartUsingAMultiThreadedApartment, !o.StartUsingAMultiThreadedApartment));
    #endregion
    #region NoProfile
    /// <inheritdoc cref="PowerShellSettings.NoProfile"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoProfile))]
    public static T SetNoProfile<T>(this T o, bool? v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoProfile, v));
    /// <inheritdoc cref="PowerShellSettings.NoProfile"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoProfile))]
    public static T ResetNoProfile<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.NoProfile));
    /// <inheritdoc cref="PowerShellSettings.NoProfile"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoProfile))]
    public static T EnableNoProfile<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoProfile, true));
    /// <inheritdoc cref="PowerShellSettings.NoProfile"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoProfile))]
    public static T DisableNoProfile<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoProfile, false));
    /// <inheritdoc cref="PowerShellSettings.NoProfile"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NoProfile))]
    public static T ToggleNoProfile<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NoProfile, !o.NoProfile));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PowerShellSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PowerShellSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PowerShellSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PowerShellSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PowerShellSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region InputFormat
    /// <inheritdoc cref="PowerShellSettings.InputFormat"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.InputFormat))]
    public static T SetInputFormat<T>(this T o, PowerShellFormat v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.InputFormat, v));
    /// <inheritdoc cref="PowerShellSettings.InputFormat"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.InputFormat))]
    public static T ResetInputFormat<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.InputFormat));
    #endregion
    #region OutputFormat
    /// <inheritdoc cref="PowerShellSettings.OutputFormat"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.OutputFormat))]
    public static T SetOutputFormat<T>(this T o, PowerShellFormat v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.OutputFormat, v));
    /// <inheritdoc cref="PowerShellSettings.OutputFormat"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.OutputFormat))]
    public static T ResetOutputFormat<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.OutputFormat));
    #endregion
    #region WindowStyle
    /// <inheritdoc cref="PowerShellSettings.WindowStyle"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.WindowStyle))]
    public static T SetWindowStyle<T>(this T o, PowerShellWindowStyle v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.WindowStyle, v));
    /// <inheritdoc cref="PowerShellSettings.WindowStyle"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.WindowStyle))]
    public static T ResetWindowStyle<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.WindowStyle));
    #endregion
    #region EncodedCommand
    /// <inheritdoc cref="PowerShellSettings.EncodedCommand"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.EncodedCommand))]
    public static T SetEncodedCommand<T>(this T o, string v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.EncodedCommand, v));
    /// <inheritdoc cref="PowerShellSettings.EncodedCommand"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.EncodedCommand))]
    public static T ResetEncodedCommand<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.EncodedCommand));
    #endregion
    #region ConfigurationName
    /// <inheritdoc cref="PowerShellSettings.ConfigurationName"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.ConfigurationName))]
    public static T SetConfigurationName<T>(this T o, string v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.ConfigurationName, v));
    /// <inheritdoc cref="PowerShellSettings.ConfigurationName"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.ConfigurationName))]
    public static T ResetConfigurationName<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.ConfigurationName));
    #endregion
    #region ExecutionPolicy
    /// <inheritdoc cref="PowerShellSettings.ExecutionPolicy"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.ExecutionPolicy))]
    public static T SetExecutionPolicy<T>(this T o, string v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.ExecutionPolicy, v));
    /// <inheritdoc cref="PowerShellSettings.ExecutionPolicy"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.ExecutionPolicy))]
    public static T ResetExecutionPolicy<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.ExecutionPolicy));
    #endregion
    #region File
    /// <inheritdoc cref="PowerShellSettings.File"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.File))]
    public static T SetFile<T>(this T o, string v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.File, v));
    /// <inheritdoc cref="PowerShellSettings.File"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.File))]
    public static T ResetFile<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.File));
    #endregion
    #region FileArguments
    /// <inheritdoc cref="PowerShellSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileArguments))]
    public static T SetFileArguments<T>(this T o, params string[] v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.FileArguments, v));
    /// <inheritdoc cref="PowerShellSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileArguments))]
    public static T SetFileArguments<T>(this T o, IEnumerable<string> v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.FileArguments, v));
    /// <inheritdoc cref="PowerShellSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileArguments))]
    public static T AddFileArguments<T>(this T o, params string[] v) where T : PowerShellSettings => o.Modify(b => b.AddCollection(() => o.FileArguments, v));
    /// <inheritdoc cref="PowerShellSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileArguments))]
    public static T AddFileArguments<T>(this T o, IEnumerable<string> v) where T : PowerShellSettings => o.Modify(b => b.AddCollection(() => o.FileArguments, v));
    /// <inheritdoc cref="PowerShellSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileArguments))]
    public static T RemoveFileArguments<T>(this T o, params string[] v) where T : PowerShellSettings => o.Modify(b => b.RemoveCollection(() => o.FileArguments, v));
    /// <inheritdoc cref="PowerShellSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileArguments))]
    public static T RemoveFileArguments<T>(this T o, IEnumerable<string> v) where T : PowerShellSettings => o.Modify(b => b.RemoveCollection(() => o.FileArguments, v));
    /// <inheritdoc cref="PowerShellSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileArguments))]
    public static T ClearFileArguments<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.ClearCollection(() => o.FileArguments));
    #endregion
    #region FileKeyValueParameters
    /// <inheritdoc cref="PowerShellSettings.FileKeyValueParameters"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileKeyValueParameters))]
    public static T SetFileKeyValueParameters<T>(this T o, IDictionary<string, string> v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.FileKeyValueParameters, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="PowerShellSettings.FileKeyValueParameters"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileKeyValueParameters))]
    public static T SetFileKeyValueParameter<T>(this T o, string k, string v) where T : PowerShellSettings => o.Modify(b => b.SetDictionary(() => o.FileKeyValueParameters, k, v));
    /// <inheritdoc cref="PowerShellSettings.FileKeyValueParameters"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileKeyValueParameters))]
    public static T AddFileKeyValueParameter<T>(this T o, string k, string v) where T : PowerShellSettings => o.Modify(b => b.AddDictionary(() => o.FileKeyValueParameters, k, v));
    /// <inheritdoc cref="PowerShellSettings.FileKeyValueParameters"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileKeyValueParameters))]
    public static T RemoveFileKeyValueParameter<T>(this T o, string k) where T : PowerShellSettings => o.Modify(b => b.RemoveDictionary(() => o.FileKeyValueParameters, k));
    /// <inheritdoc cref="PowerShellSettings.FileKeyValueParameters"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.FileKeyValueParameters))]
    public static T ClearFileKeyValueParameters<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.ClearDictionary(() => o.FileKeyValueParameters));
    #endregion
    #region Command
    /// <inheritdoc cref="PowerShellSettings.Command"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.Command))]
    public static T SetCommand<T>(this T o, string v) where T : PowerShellSettings => o.Modify(b => b.Set(() => o.Command, v));
    /// <inheritdoc cref="PowerShellSettings.Command"/>
    [Pure] [Builder(Type = typeof(PowerShellSettings), Property = nameof(PowerShellSettings.Command))]
    public static T ResetCommand<T>(this T o) where T : PowerShellSettings => o.Modify(b => b.Remove(() => o.Command));
    #endregion
}
#endregion
#region PowerShellFormat
/// <summary>Used within <see cref="PowerShellTasks"/>.</summary>
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
/// <summary>Used within <see cref="PowerShellTasks"/>.</summary>
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
