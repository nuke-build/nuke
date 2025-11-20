// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Pwsh/Pwsh.json

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

namespace Nuke.Common.Tools.Pwsh;

/// <summary><p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathTool(Executable = PathExecutable)]
public partial class PwshTasks : ToolTasks, IRequirePathTool
{
    public static string PwshPath { get => new PwshTasks().GetToolPathInternal(); set => new PwshTasks().SetToolPath(value); }
    public const string PathExecutable = "pwsh";
    /// <summary><p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Pwsh(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new PwshTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="https://www.nuke.build/docs/common/cli-tools/#fluent-api">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;fileArguments&gt;</c> via <see cref="PwshSettings.FileArguments"/></li><li><c>-Command</c> via <see cref="PwshSettings.Command"/></li><li><c>-ConfigurationFile</c> via <see cref="PwshSettings.ConfigurationFile"/></li><li><c>-ConfigurationName</c> via <see cref="PwshSettings.ConfigurationName"/></li><li><c>-CustomPipeName</c> via <see cref="PwshSettings.CustomPipeName"/></li><li><c>-EncodedCommand</c> via <see cref="PwshSettings.EncodedCommand"/></li><li><c>-ExecutionPolicy</c> via <see cref="PwshSettings.ExecutionPolicy"/></li><li><c>-File</c> via <see cref="PwshSettings.File"/></li><li><c>-InputFormat</c> via <see cref="PwshSettings.InputFormat"/></li><li><c>-Interactive</c> via <see cref="PwshSettings.Interactive"/></li><li><c>-Login</c> via <see cref="PwshSettings.Login"/></li><li><c>-Mta</c> via <see cref="PwshSettings.MultiThreadedApartment"/></li><li><c>-NoExit</c> via <see cref="PwshSettings.NoExit"/></li><li><c>-NoLogo</c> via <see cref="PwshSettings.NoLogo"/></li><li><c>-NonInteractive</c> via <see cref="PwshSettings.NonInteractive"/></li><li><c>-NoProfile</c> via <see cref="PwshSettings.NoProfile"/></li><li><c>-NoProfileLoadTime</c> via <see cref="PwshSettings.NoProfileLoadTime"/></li><li><c>-OutputFormat</c> via <see cref="PwshSettings.OutputFormat"/></li><li><c>-SettingsFile</c> via <see cref="PwshSettings.SettingsFile"/></li><li><c>-SSHServerMode</c> via <see cref="PwshSettings.SSHServerMode"/></li><li><c>-Sta</c> via <see cref="PwshSettings.SingleThreadedApartment"/></li><li><c>-Version</c> via <see cref="PwshSettings.Version"/></li><li><c>-WindowStyle</c> via <see cref="PwshSettings.WindowStyle"/></li><li><c>-WorkingDirectory</c> via <see cref="PwshSettings.WorkingDirectory"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Pwsh(PwshSettings options = null) => new PwshTasks().Run<PwshSettings>(options);
    /// <inheritdoc cref="PwshTasks.Pwsh(Nuke.Common.Tools.Pwsh.PwshSettings)"/>
    public static IReadOnlyCollection<Output> Pwsh(Configure<PwshSettings> configurator) => new PwshTasks().Run<PwshSettings>(configurator.Invoke(new PwshSettings()));
    /// <inheritdoc cref="PwshTasks.Pwsh(Nuke.Common.Tools.Pwsh.PwshSettings)"/>
    public static IEnumerable<(PwshSettings Settings, IReadOnlyCollection<Output> Output)> Pwsh(CombinatorialConfigure<PwshSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(Pwsh, degreeOfParallelism, completeOnFailure);
}
#region PwshSettings
/// <inheritdoc cref="PwshTasks.Pwsh(Nuke.Common.Tools.Pwsh.PwshSettings)"/>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Command(Type = typeof(PwshTasks), Command = nameof(PwshTasks.Pwsh))]
public partial class PwshSettings : ToolOptions
{
    /// <summary>Displays the version of PowerShell. Additional parameters are ignored.</summary>
    [Argument(Format = "-Version")] public bool? Version => Get<bool?>(() => Version);
    /// <summary>Hides the copyright banner at startup.</summary>
    [Argument(Format = "-NoLogo")] public bool? NoLogo => Get<bool?>(() => NoLogo);
    /// <summary>Does not exit after running startup commands.</summary>
    [Argument(Format = "-NoExit")] public bool? NoExit => Get<bool?>(() => NoExit);
    /// <summary>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</summary>
    [Argument(Format = "-Sta")] public bool? SingleThreadedApartment => Get<bool?>(() => SingleThreadedApartment);
    /// <summary>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</summary>
    [Argument(Format = "-Mta")] public bool? MultiThreadedApartment => Get<bool?>(() => MultiThreadedApartment);
    /// <summary>Does not load the PowerShell profile.</summary>
    [Argument(Format = "-NoProfile")] public bool? NoProfile => Get<bool?>(() => NoProfile);
    /// <summary>Hides the PowerShell profile load time text shown at startup when the load time exceeds 500 milliseconds.</summary>
    [Argument(Format = "-NoProfileLoadTime")] public bool? NoProfileLoadTime => Get<bool?>(() => NoProfileLoadTime);
    /// <summary>This switch is used to create sessions that shouldn't require user input. This is useful for scripts that run in scheduled tasks or CI/CD pipelines. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement terminating errors rather than hanging.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Present an interactive prompt to the user. Inverse for <c>NonInteractive</c> parameter.</summary>
    [Argument(Format = "-Interactive")] public bool? Interactive => Get<bool?>(() => Interactive);
    /// <summary>Describes the format of data sent to PowerShell. Valid values are <c>Text</c> (text strings) or <c>XML</c> (serialized CLIXML format).</summary>
    [Argument(Format = "-InputFormat {value}")] public PwshInOutFormat InputFormat => Get<PwshInOutFormat>(() => InputFormat);
    /// <summary>Determines how output from PowerShell is formatted. Valid values are <c>Text</c>  (text strings) or <c>XML</c>  (serialized CLIXML format).</summary>
    [Argument(Format = "-OutputFormat {value}")] public PwshInOutFormat OutputFormat => Get<PwshInOutFormat>(() => OutputFormat);
    /// <summary>Sets the window style for the session. Valid values are <c>Normal</c>, <c>Minimized</c>, <c>Maximized</c> and <c>Hidden</c>.</summary>
    [Argument(Format = "-WindowStyle {value}")] public PwshWindowStyle WindowStyle => Get<PwshWindowStyle>(() => WindowStyle);
    /// <summary>Accepts a base-64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex quotation marks or curly braces. The string must be formatted using UTF-16LE character encoding.</summary>
    [Argument(Format = "-EncodedCommand {value}")] public string EncodedCommand => Get<string>(() => EncodedCommand);
    /// <summary>Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.</summary>
    [Argument(Format = "-ConfigurationName {value}")] public string ConfigurationName => Get<string>(() => ConfigurationName);
    /// <summary>Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. This parameter only applies to Windows computers. The <c>$env:PSExecutionPolicyPreference</c> environment variable does not exist on non-Windows platforms.</summary>
    [Argument(Format = "-ExecutionPolicy {value}")] public PwshExecutionPolicy ExecutionPolicy => Get<PwshExecutionPolicy>(() => ExecutionPolicy);
    /// <summary>If the value of File is <c>-</c>, the command text is read from standard input. Running <c>pwsh -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the File parameter at all.<para/>This is the default parameter if no parameters are present but values are present in the command line. The specified script runs in the local scope ("dot-sourced"), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. File must be the last parameter in the command, because all characters typed after the File parameter name are interpreted as the script file path followed by the script parameters.</summary>
    [Argument(Format = "-File  {value}")] public string File => Get<string>(() => File);
    /// <summary>Arguments passed in when using the <c>-File</c> option.</summary>
    [Argument(Format = "{value}")] public IReadOnlyList<string> FileArguments => Get<List<string>>(() => FileArguments);
    /// <summary>Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of Command can be <c>-</c>, a script block, or a string. If the value of Command is <c>-</c>, the command text is read from standard input.<para/>The Command parameter only accepts a script block for execution when it can recognize the value passed to Command as a ScriptBlock type. This is only possible when running pwsh from another PowerShell host. The ScriptBlock type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to pwsh.</summary>
    [Argument(Format = "-Command {value}")] public string Command => Get<string>(() => Command);
    /// <summary>Overrides the system-wide <c>powershell.config.json</c> settings file for the session. By default, system-wide settings are read from the powershell.config.json in the $PSHOME directory. Note that these settings are not used by the endpoint specified by the <c>-ConfigurationName</c> argument.</summary>
    [Argument(Format = "-SettingsFile {value}")] public string SettingsFile => Get<string>(() => SettingsFile);
    /// <summary>Specifies the name to use for an additional IPC server (named pipe) used for debugging and other cross-process communication. This offers a predictable mechanism for connecting to other PowerShell instances. Typically used with the CustomPipeName parameter on Enter-PSHostProcess. This parameter was introduced in PowerShell 6.2.</summary>
    [Argument(Format = "-CustomPipeName {value}")] public string CustomPipeName => Get<string>(() => CustomPipeName);
    /// <summary>Used in sshd_config for running PowerShell as an SSH subsystem. It is not intended or supported for any other use.</summary>
    [Argument(Format = "-SSHServerMode")] public bool? SSHServerMode => Get<bool?>(() => SSHServerMode);
    /// <summary>Sets the initial working directory by executing at startup. Any valid PowerShell file path is supported. To start PowerShell in your home directory, use: <c>pwsh -WorkingDirectory ~</c></summary>
    [Argument(Format = "-WorkingDirectory {value}")] public string WorkingDirectory => Get<string>(() => WorkingDirectory);
    /// <summary>Specifies a session configuration (.pssc) file path. The configuration contained in the configuration file will be applied to the PowerShell session.</summary>
    [Argument(Format = "-ConfigurationFile {value}")] public string ConfigurationFile => Get<string>(() => ConfigurationFile);
    /// <summary>On Linux and macOS, starts PowerShell as a login shell, using /bin/sh to execute login profiles such as /etc/profile and ~/.profile. On Windows, this switch does nothing. IMPORTANT This parameter must come first to start PowerShell as a login shell. Passing this parameter in another position will be ignored.</summary>
    [Argument(Format = "-Login")] public bool? Login => Get<bool?>(() => Login);
}
#endregion
#region PwshSettingsExtensions
/// <inheritdoc cref="PwshTasks.Pwsh(Nuke.Common.Tools.Pwsh.PwshSettings)"/>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PwshSettingsExtensions
{
    #region Version
    /// <inheritdoc cref="PwshSettings.Version"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Version))]
    public static T SetVersion<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="PwshSettings.Version"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.Version));
    /// <inheritdoc cref="PwshSettings.Version"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Version))]
    public static T EnableVersion<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.Version, true));
    /// <inheritdoc cref="PwshSettings.Version"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Version))]
    public static T DisableVersion<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.Version, false));
    /// <inheritdoc cref="PwshSettings.Version"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Version))]
    public static T ToggleVersion<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.Version, !o.Version));
    #endregion
    #region NoLogo
    /// <inheritdoc cref="PwshSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoLogo))]
    public static T SetNoLogo<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoLogo, v));
    /// <inheritdoc cref="PwshSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoLogo))]
    public static T ResetNoLogo<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.NoLogo));
    /// <inheritdoc cref="PwshSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoLogo))]
    public static T EnableNoLogo<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoLogo, true));
    /// <inheritdoc cref="PwshSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoLogo))]
    public static T DisableNoLogo<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoLogo, false));
    /// <inheritdoc cref="PwshSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoLogo))]
    public static T ToggleNoLogo<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoLogo, !o.NoLogo));
    #endregion
    #region NoExit
    /// <inheritdoc cref="PwshSettings.NoExit"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoExit))]
    public static T SetNoExit<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoExit, v));
    /// <inheritdoc cref="PwshSettings.NoExit"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoExit))]
    public static T ResetNoExit<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.NoExit));
    /// <inheritdoc cref="PwshSettings.NoExit"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoExit))]
    public static T EnableNoExit<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoExit, true));
    /// <inheritdoc cref="PwshSettings.NoExit"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoExit))]
    public static T DisableNoExit<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoExit, false));
    /// <inheritdoc cref="PwshSettings.NoExit"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoExit))]
    public static T ToggleNoExit<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoExit, !o.NoExit));
    #endregion
    #region SingleThreadedApartment
    /// <inheritdoc cref="PwshSettings.SingleThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SingleThreadedApartment))]
    public static T SetSingleThreadedApartment<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.SingleThreadedApartment, v));
    /// <inheritdoc cref="PwshSettings.SingleThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SingleThreadedApartment))]
    public static T ResetSingleThreadedApartment<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.SingleThreadedApartment));
    /// <inheritdoc cref="PwshSettings.SingleThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SingleThreadedApartment))]
    public static T EnableSingleThreadedApartment<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.SingleThreadedApartment, true));
    /// <inheritdoc cref="PwshSettings.SingleThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SingleThreadedApartment))]
    public static T DisableSingleThreadedApartment<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.SingleThreadedApartment, false));
    /// <inheritdoc cref="PwshSettings.SingleThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SingleThreadedApartment))]
    public static T ToggleSingleThreadedApartment<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.SingleThreadedApartment, !o.SingleThreadedApartment));
    #endregion
    #region MultiThreadedApartment
    /// <inheritdoc cref="PwshSettings.MultiThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.MultiThreadedApartment))]
    public static T SetMultiThreadedApartment<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.MultiThreadedApartment, v));
    /// <inheritdoc cref="PwshSettings.MultiThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.MultiThreadedApartment))]
    public static T ResetMultiThreadedApartment<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.MultiThreadedApartment));
    /// <inheritdoc cref="PwshSettings.MultiThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.MultiThreadedApartment))]
    public static T EnableMultiThreadedApartment<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.MultiThreadedApartment, true));
    /// <inheritdoc cref="PwshSettings.MultiThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.MultiThreadedApartment))]
    public static T DisableMultiThreadedApartment<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.MultiThreadedApartment, false));
    /// <inheritdoc cref="PwshSettings.MultiThreadedApartment"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.MultiThreadedApartment))]
    public static T ToggleMultiThreadedApartment<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.MultiThreadedApartment, !o.MultiThreadedApartment));
    #endregion
    #region NoProfile
    /// <inheritdoc cref="PwshSettings.NoProfile"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoProfile))]
    public static T SetNoProfile<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoProfile, v));
    /// <inheritdoc cref="PwshSettings.NoProfile"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoProfile))]
    public static T ResetNoProfile<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.NoProfile));
    /// <inheritdoc cref="PwshSettings.NoProfile"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoProfile))]
    public static T EnableNoProfile<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoProfile, true));
    /// <inheritdoc cref="PwshSettings.NoProfile"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoProfile))]
    public static T DisableNoProfile<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoProfile, false));
    /// <inheritdoc cref="PwshSettings.NoProfile"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoProfile))]
    public static T ToggleNoProfile<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoProfile, !o.NoProfile));
    #endregion
    #region NoProfileLoadTime
    /// <inheritdoc cref="PwshSettings.NoProfileLoadTime"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoProfileLoadTime))]
    public static T SetNoProfileLoadTime<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoProfileLoadTime, v));
    /// <inheritdoc cref="PwshSettings.NoProfileLoadTime"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoProfileLoadTime))]
    public static T ResetNoProfileLoadTime<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.NoProfileLoadTime));
    /// <inheritdoc cref="PwshSettings.NoProfileLoadTime"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoProfileLoadTime))]
    public static T EnableNoProfileLoadTime<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoProfileLoadTime, true));
    /// <inheritdoc cref="PwshSettings.NoProfileLoadTime"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoProfileLoadTime))]
    public static T DisableNoProfileLoadTime<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoProfileLoadTime, false));
    /// <inheritdoc cref="PwshSettings.NoProfileLoadTime"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NoProfileLoadTime))]
    public static T ToggleNoProfileLoadTime<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NoProfileLoadTime, !o.NoProfileLoadTime));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PwshSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PwshSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PwshSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PwshSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PwshSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Interactive
    /// <inheritdoc cref="PwshSettings.Interactive"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Interactive))]
    public static T SetInteractive<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.Interactive, v));
    /// <inheritdoc cref="PwshSettings.Interactive"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Interactive))]
    public static T ResetInteractive<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.Interactive));
    /// <inheritdoc cref="PwshSettings.Interactive"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Interactive))]
    public static T EnableInteractive<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.Interactive, true));
    /// <inheritdoc cref="PwshSettings.Interactive"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Interactive))]
    public static T DisableInteractive<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.Interactive, false));
    /// <inheritdoc cref="PwshSettings.Interactive"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Interactive))]
    public static T ToggleInteractive<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.Interactive, !o.Interactive));
    #endregion
    #region InputFormat
    /// <inheritdoc cref="PwshSettings.InputFormat"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.InputFormat))]
    public static T SetInputFormat<T>(this T o, PwshInOutFormat v) where T : PwshSettings => o.Modify(b => b.Set(() => o.InputFormat, v));
    /// <inheritdoc cref="PwshSettings.InputFormat"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.InputFormat))]
    public static T ResetInputFormat<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.InputFormat));
    #endregion
    #region OutputFormat
    /// <inheritdoc cref="PwshSettings.OutputFormat"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.OutputFormat))]
    public static T SetOutputFormat<T>(this T o, PwshInOutFormat v) where T : PwshSettings => o.Modify(b => b.Set(() => o.OutputFormat, v));
    /// <inheritdoc cref="PwshSettings.OutputFormat"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.OutputFormat))]
    public static T ResetOutputFormat<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.OutputFormat));
    #endregion
    #region WindowStyle
    /// <inheritdoc cref="PwshSettings.WindowStyle"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.WindowStyle))]
    public static T SetWindowStyle<T>(this T o, PwshWindowStyle v) where T : PwshSettings => o.Modify(b => b.Set(() => o.WindowStyle, v));
    /// <inheritdoc cref="PwshSettings.WindowStyle"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.WindowStyle))]
    public static T ResetWindowStyle<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.WindowStyle));
    #endregion
    #region EncodedCommand
    /// <inheritdoc cref="PwshSettings.EncodedCommand"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.EncodedCommand))]
    public static T SetEncodedCommand<T>(this T o, string v) where T : PwshSettings => o.Modify(b => b.Set(() => o.EncodedCommand, v));
    /// <inheritdoc cref="PwshSettings.EncodedCommand"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.EncodedCommand))]
    public static T ResetEncodedCommand<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.EncodedCommand));
    #endregion
    #region ConfigurationName
    /// <inheritdoc cref="PwshSettings.ConfigurationName"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.ConfigurationName))]
    public static T SetConfigurationName<T>(this T o, string v) where T : PwshSettings => o.Modify(b => b.Set(() => o.ConfigurationName, v));
    /// <inheritdoc cref="PwshSettings.ConfigurationName"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.ConfigurationName))]
    public static T ResetConfigurationName<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.ConfigurationName));
    #endregion
    #region ExecutionPolicy
    /// <inheritdoc cref="PwshSettings.ExecutionPolicy"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.ExecutionPolicy))]
    public static T SetExecutionPolicy<T>(this T o, PwshExecutionPolicy v) where T : PwshSettings => o.Modify(b => b.Set(() => o.ExecutionPolicy, v));
    /// <inheritdoc cref="PwshSettings.ExecutionPolicy"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.ExecutionPolicy))]
    public static T ResetExecutionPolicy<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.ExecutionPolicy));
    #endregion
    #region File
    /// <inheritdoc cref="PwshSettings.File"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.File))]
    public static T SetFile<T>(this T o, string v) where T : PwshSettings => o.Modify(b => b.Set(() => o.File, v));
    /// <inheritdoc cref="PwshSettings.File"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.File))]
    public static T ResetFile<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.File));
    #endregion
    #region FileArguments
    /// <inheritdoc cref="PwshSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.FileArguments))]
    public static T SetFileArguments<T>(this T o, params string[] v) where T : PwshSettings => o.Modify(b => b.Set(() => o.FileArguments, v));
    /// <inheritdoc cref="PwshSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.FileArguments))]
    public static T SetFileArguments<T>(this T o, IEnumerable<string> v) where T : PwshSettings => o.Modify(b => b.Set(() => o.FileArguments, v));
    /// <inheritdoc cref="PwshSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.FileArguments))]
    public static T AddFileArguments<T>(this T o, params string[] v) where T : PwshSettings => o.Modify(b => b.AddCollection(() => o.FileArguments, v));
    /// <inheritdoc cref="PwshSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.FileArguments))]
    public static T AddFileArguments<T>(this T o, IEnumerable<string> v) where T : PwshSettings => o.Modify(b => b.AddCollection(() => o.FileArguments, v));
    /// <inheritdoc cref="PwshSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.FileArguments))]
    public static T RemoveFileArguments<T>(this T o, params string[] v) where T : PwshSettings => o.Modify(b => b.RemoveCollection(() => o.FileArguments, v));
    /// <inheritdoc cref="PwshSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.FileArguments))]
    public static T RemoveFileArguments<T>(this T o, IEnumerable<string> v) where T : PwshSettings => o.Modify(b => b.RemoveCollection(() => o.FileArguments, v));
    /// <inheritdoc cref="PwshSettings.FileArguments"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.FileArguments))]
    public static T ClearFileArguments<T>(this T o) where T : PwshSettings => o.Modify(b => b.ClearCollection(() => o.FileArguments));
    #endregion
    #region Command
    /// <inheritdoc cref="PwshSettings.Command"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Command))]
    public static T SetCommand<T>(this T o, string v) where T : PwshSettings => o.Modify(b => b.Set(() => o.Command, v));
    /// <inheritdoc cref="PwshSettings.Command"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Command))]
    public static T ResetCommand<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.Command));
    #endregion
    #region SettingsFile
    /// <inheritdoc cref="PwshSettings.SettingsFile"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SettingsFile))]
    public static T SetSettingsFile<T>(this T o, string v) where T : PwshSettings => o.Modify(b => b.Set(() => o.SettingsFile, v));
    /// <inheritdoc cref="PwshSettings.SettingsFile"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SettingsFile))]
    public static T ResetSettingsFile<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.SettingsFile));
    #endregion
    #region CustomPipeName
    /// <inheritdoc cref="PwshSettings.CustomPipeName"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.CustomPipeName))]
    public static T SetCustomPipeName<T>(this T o, string v) where T : PwshSettings => o.Modify(b => b.Set(() => o.CustomPipeName, v));
    /// <inheritdoc cref="PwshSettings.CustomPipeName"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.CustomPipeName))]
    public static T ResetCustomPipeName<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.CustomPipeName));
    #endregion
    #region SSHServerMode
    /// <inheritdoc cref="PwshSettings.SSHServerMode"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SSHServerMode))]
    public static T SetSSHServerMode<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.SSHServerMode, v));
    /// <inheritdoc cref="PwshSettings.SSHServerMode"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SSHServerMode))]
    public static T ResetSSHServerMode<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.SSHServerMode));
    /// <inheritdoc cref="PwshSettings.SSHServerMode"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SSHServerMode))]
    public static T EnableSSHServerMode<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.SSHServerMode, true));
    /// <inheritdoc cref="PwshSettings.SSHServerMode"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SSHServerMode))]
    public static T DisableSSHServerMode<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.SSHServerMode, false));
    /// <inheritdoc cref="PwshSettings.SSHServerMode"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.SSHServerMode))]
    public static T ToggleSSHServerMode<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.SSHServerMode, !o.SSHServerMode));
    #endregion
    #region WorkingDirectory
    /// <inheritdoc cref="PwshSettings.WorkingDirectory"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.WorkingDirectory))]
    public static T SetWorkingDirectory<T>(this T o, string v) where T : PwshSettings => o.Modify(b => b.Set(() => o.WorkingDirectory, v));
    /// <inheritdoc cref="PwshSettings.WorkingDirectory"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.WorkingDirectory))]
    public static T ResetWorkingDirectory<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.WorkingDirectory));
    #endregion
    #region ConfigurationFile
    /// <inheritdoc cref="PwshSettings.ConfigurationFile"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.ConfigurationFile))]
    public static T SetConfigurationFile<T>(this T o, string v) where T : PwshSettings => o.Modify(b => b.Set(() => o.ConfigurationFile, v));
    /// <inheritdoc cref="PwshSettings.ConfigurationFile"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.ConfigurationFile))]
    public static T ResetConfigurationFile<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.ConfigurationFile));
    #endregion
    #region Login
    /// <inheritdoc cref="PwshSettings.Login"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Login))]
    public static T SetLogin<T>(this T o, bool? v) where T : PwshSettings => o.Modify(b => b.Set(() => o.Login, v));
    /// <inheritdoc cref="PwshSettings.Login"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Login))]
    public static T ResetLogin<T>(this T o) where T : PwshSettings => o.Modify(b => b.Remove(() => o.Login));
    /// <inheritdoc cref="PwshSettings.Login"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Login))]
    public static T EnableLogin<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.Login, true));
    /// <inheritdoc cref="PwshSettings.Login"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Login))]
    public static T DisableLogin<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.Login, false));
    /// <inheritdoc cref="PwshSettings.Login"/>
    [Pure] [Builder(Type = typeof(PwshSettings), Property = nameof(PwshSettings.Login))]
    public static T ToggleLogin<T>(this T o) where T : PwshSettings => o.Modify(b => b.Set(() => o.Login, !o.Login));
    #endregion
}
#endregion
#region PwshExecutionPolicy
/// <summary>Used within <see cref="PwshTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PwshExecutionPolicy>))]
public partial class PwshExecutionPolicy : Enumeration
{
    public static PwshExecutionPolicy AllSigned = (PwshExecutionPolicy) "AllSigned";
    public static PwshExecutionPolicy Bypass = (PwshExecutionPolicy) "Bypass";
    public static PwshExecutionPolicy Default = (PwshExecutionPolicy) "Default";
    public static PwshExecutionPolicy RemoteSigned = (PwshExecutionPolicy) "RemoteSigned";
    public static PwshExecutionPolicy Restricted = (PwshExecutionPolicy) "Restricted";
    public static PwshExecutionPolicy Undefined = (PwshExecutionPolicy) "Undefined";
    public static PwshExecutionPolicy Unrestricted = (PwshExecutionPolicy) "Unrestricted";
    public static implicit operator PwshExecutionPolicy(string value)
    {
        return new PwshExecutionPolicy { Value = value };
    }
}
#endregion
#region PwshInOutFormat
/// <summary>Used within <see cref="PwshTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PwshInOutFormat>))]
public partial class PwshInOutFormat : Enumeration
{
    public static PwshInOutFormat Text = (PwshInOutFormat) "Text";
    public static PwshInOutFormat Xml = (PwshInOutFormat) "Xml";
    public static implicit operator PwshInOutFormat(string value)
    {
        return new PwshInOutFormat { Value = value };
    }
}
#endregion
#region PwshWindowStyle
/// <summary>Used within <see cref="PwshTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PwshWindowStyle>))]
public partial class PwshWindowStyle : Enumeration
{
    public static PwshWindowStyle Normal = (PwshWindowStyle) "Normal";
    public static PwshWindowStyle Minimized = (PwshWindowStyle) "Minimized";
    public static PwshWindowStyle Maximized = (PwshWindowStyle) "Maximized";
    public static PwshWindowStyle Hidden = (PwshWindowStyle) "Hidden";
    public static implicit operator PwshWindowStyle(string value)
    {
        return new PwshWindowStyle { Value = value };
    }
}
#endregion
