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

/// <summary>
///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathToolRequirement(PwshPathExecutable)]
public partial class PwshTasks
    : IRequirePathTool
{
    public const string PwshPathExecutable = "pwsh";
    /// <summary>
    ///   Path to the Pwsh executable.
    /// </summary>
    public static string PwshPath =>
        ToolPathResolver.TryGetEnvironmentExecutable("PWSH_EXE") ??
        ToolPathResolver.GetPathExecutable("pwsh");
    public static Action<OutputType, string> PwshLogger { get; set; } = ProcessTasks.DefaultLogger;
    /// <summary>
    ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
    /// </summary>
    public static IReadOnlyCollection<Output> Pwsh(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
    {
        using var process = ProcessTasks.StartProcess(PwshPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? PwshLogger);
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
    ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PwshSettings.FileArguments"/></li>
    ///     <li><c>-Command</c> via <see cref="PwshSettings.Command"/></li>
    ///     <li><c>-ConfigurationFile</c> via <see cref="PwshSettings.ConfigurationFile"/></li>
    ///     <li><c>-ConfigurationName</c> via <see cref="PwshSettings.ConfigurationName"/></li>
    ///     <li><c>-CustomPipeName</c> via <see cref="PwshSettings.CustomPipeName"/></li>
    ///     <li><c>-EncodedCommand</c> via <see cref="PwshSettings.EncodedCommand"/></li>
    ///     <li><c>-ExecutionPolicy</c> via <see cref="PwshSettings.ExecutionPolicy"/></li>
    ///     <li><c>-File</c> via <see cref="PwshSettings.File"/></li>
    ///     <li><c>-InputFormat</c> via <see cref="PwshSettings.InputFormat"/></li>
    ///     <li><c>-Interactive</c> via <see cref="PwshSettings.Interactive"/></li>
    ///     <li><c>-Login</c> via <see cref="PwshSettings.Login"/></li>
    ///     <li><c>-Mta</c> via <see cref="PwshSettings.MultiThreadedApartment"/></li>
    ///     <li><c>-NoExit</c> via <see cref="PwshSettings.NoExit"/></li>
    ///     <li><c>-NoLogo</c> via <see cref="PwshSettings.NoLogo"/></li>
    ///     <li><c>-NonInteractive</c> via <see cref="PwshSettings.NonInteractive"/></li>
    ///     <li><c>-NoProfile</c> via <see cref="PwshSettings.NoProfile"/></li>
    ///     <li><c>-NoProfileLoadTime</c> via <see cref="PwshSettings.NoProfileLoadTime"/></li>
    ///     <li><c>-OutputFormat</c> via <see cref="PwshSettings.OutputFormat"/></li>
    ///     <li><c>-SettingsFile</c> via <see cref="PwshSettings.SettingsFile"/></li>
    ///     <li><c>-SSHServerMode</c> via <see cref="PwshSettings.SSHServerMode"/></li>
    ///     <li><c>-Sta</c> via <see cref="PwshSettings.SingleThreadedApartment"/></li>
    ///     <li><c>-Version</c> via <see cref="PwshSettings.Version"/></li>
    ///     <li><c>-WindowStyle</c> via <see cref="PwshSettings.WindowStyle"/></li>
    ///     <li><c>-WorkingDirectory</c> via <see cref="PwshSettings.WorkingDirectory"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> Pwsh(PwshSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new PwshSettings();
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
    ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PwshSettings.FileArguments"/></li>
    ///     <li><c>-Command</c> via <see cref="PwshSettings.Command"/></li>
    ///     <li><c>-ConfigurationFile</c> via <see cref="PwshSettings.ConfigurationFile"/></li>
    ///     <li><c>-ConfigurationName</c> via <see cref="PwshSettings.ConfigurationName"/></li>
    ///     <li><c>-CustomPipeName</c> via <see cref="PwshSettings.CustomPipeName"/></li>
    ///     <li><c>-EncodedCommand</c> via <see cref="PwshSettings.EncodedCommand"/></li>
    ///     <li><c>-ExecutionPolicy</c> via <see cref="PwshSettings.ExecutionPolicy"/></li>
    ///     <li><c>-File</c> via <see cref="PwshSettings.File"/></li>
    ///     <li><c>-InputFormat</c> via <see cref="PwshSettings.InputFormat"/></li>
    ///     <li><c>-Interactive</c> via <see cref="PwshSettings.Interactive"/></li>
    ///     <li><c>-Login</c> via <see cref="PwshSettings.Login"/></li>
    ///     <li><c>-Mta</c> via <see cref="PwshSettings.MultiThreadedApartment"/></li>
    ///     <li><c>-NoExit</c> via <see cref="PwshSettings.NoExit"/></li>
    ///     <li><c>-NoLogo</c> via <see cref="PwshSettings.NoLogo"/></li>
    ///     <li><c>-NonInteractive</c> via <see cref="PwshSettings.NonInteractive"/></li>
    ///     <li><c>-NoProfile</c> via <see cref="PwshSettings.NoProfile"/></li>
    ///     <li><c>-NoProfileLoadTime</c> via <see cref="PwshSettings.NoProfileLoadTime"/></li>
    ///     <li><c>-OutputFormat</c> via <see cref="PwshSettings.OutputFormat"/></li>
    ///     <li><c>-SettingsFile</c> via <see cref="PwshSettings.SettingsFile"/></li>
    ///     <li><c>-SSHServerMode</c> via <see cref="PwshSettings.SSHServerMode"/></li>
    ///     <li><c>-Sta</c> via <see cref="PwshSettings.SingleThreadedApartment"/></li>
    ///     <li><c>-Version</c> via <see cref="PwshSettings.Version"/></li>
    ///     <li><c>-WindowStyle</c> via <see cref="PwshSettings.WindowStyle"/></li>
    ///     <li><c>-WorkingDirectory</c> via <see cref="PwshSettings.WorkingDirectory"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> Pwsh(Configure<PwshSettings> configurator)
    {
        return Pwsh(configurator(new PwshSettings()));
    }
    /// <summary>
    ///   <p>PowerShell is a cross-platform task automation solution made up of a command-line shell, a scripting language, and a configuration management framework. PowerShell runs on Windows, Linux, and macOS.</p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/powershell/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;fileArguments&gt;</c> via <see cref="PwshSettings.FileArguments"/></li>
    ///     <li><c>-Command</c> via <see cref="PwshSettings.Command"/></li>
    ///     <li><c>-ConfigurationFile</c> via <see cref="PwshSettings.ConfigurationFile"/></li>
    ///     <li><c>-ConfigurationName</c> via <see cref="PwshSettings.ConfigurationName"/></li>
    ///     <li><c>-CustomPipeName</c> via <see cref="PwshSettings.CustomPipeName"/></li>
    ///     <li><c>-EncodedCommand</c> via <see cref="PwshSettings.EncodedCommand"/></li>
    ///     <li><c>-ExecutionPolicy</c> via <see cref="PwshSettings.ExecutionPolicy"/></li>
    ///     <li><c>-File</c> via <see cref="PwshSettings.File"/></li>
    ///     <li><c>-InputFormat</c> via <see cref="PwshSettings.InputFormat"/></li>
    ///     <li><c>-Interactive</c> via <see cref="PwshSettings.Interactive"/></li>
    ///     <li><c>-Login</c> via <see cref="PwshSettings.Login"/></li>
    ///     <li><c>-Mta</c> via <see cref="PwshSettings.MultiThreadedApartment"/></li>
    ///     <li><c>-NoExit</c> via <see cref="PwshSettings.NoExit"/></li>
    ///     <li><c>-NoLogo</c> via <see cref="PwshSettings.NoLogo"/></li>
    ///     <li><c>-NonInteractive</c> via <see cref="PwshSettings.NonInteractive"/></li>
    ///     <li><c>-NoProfile</c> via <see cref="PwshSettings.NoProfile"/></li>
    ///     <li><c>-NoProfileLoadTime</c> via <see cref="PwshSettings.NoProfileLoadTime"/></li>
    ///     <li><c>-OutputFormat</c> via <see cref="PwshSettings.OutputFormat"/></li>
    ///     <li><c>-SettingsFile</c> via <see cref="PwshSettings.SettingsFile"/></li>
    ///     <li><c>-SSHServerMode</c> via <see cref="PwshSettings.SSHServerMode"/></li>
    ///     <li><c>-Sta</c> via <see cref="PwshSettings.SingleThreadedApartment"/></li>
    ///     <li><c>-Version</c> via <see cref="PwshSettings.Version"/></li>
    ///     <li><c>-WindowStyle</c> via <see cref="PwshSettings.WindowStyle"/></li>
    ///     <li><c>-WorkingDirectory</c> via <see cref="PwshSettings.WorkingDirectory"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(PwshSettings Settings, IReadOnlyCollection<Output> Output)> Pwsh(CombinatorialConfigure<PwshSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(Pwsh, PwshLogger, degreeOfParallelism, completeOnFailure);
    }
}
#region PwshSettings
/// <summary>
///   Used within <see cref="PwshTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class PwshSettings : ToolSettings
{
    /// <summary>
    ///   Path to the Pwsh executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? PwshTasks.PwshPath;
    public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? PwshTasks.PwshLogger;
    /// <summary>
    ///   Displays the version of PowerShell. Additional parameters are ignored.
    /// </summary>
    public virtual bool? Version { get; internal set; }
    /// <summary>
    ///   Hides the copyright banner at startup.
    /// </summary>
    public virtual bool? NoLogo { get; internal set; }
    /// <summary>
    ///   Does not exit after running startup commands.
    /// </summary>
    public virtual bool? NoExit { get; internal set; }
    /// <summary>
    ///   Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.
    /// </summary>
    public virtual bool? SingleThreadedApartment { get; internal set; }
    /// <summary>
    ///   Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.
    /// </summary>
    public virtual bool? MultiThreadedApartment { get; internal set; }
    /// <summary>
    ///   Does not load the PowerShell profile.
    /// </summary>
    public virtual bool? NoProfile { get; internal set; }
    /// <summary>
    ///   Hides the PowerShell profile load time text shown at startup when the load time exceeds 500 milliseconds.
    /// </summary>
    public virtual bool? NoProfileLoadTime { get; internal set; }
    /// <summary>
    ///   This switch is used to create sessions that shouldn't require user input. This is useful for scripts that run in scheduled tasks or CI/CD pipelines. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement terminating errors rather than hanging.
    /// </summary>
    public virtual bool? NonInteractive { get; internal set; }
    /// <summary>
    ///   Present an interactive prompt to the user. Inverse for <c>NonInteractive</c> parameter.
    /// </summary>
    public virtual bool? Interactive { get; internal set; }
    /// <summary>
    ///   Describes the format of data sent to PowerShell. Valid values are <c>Text</c> (text strings) or <c>XML</c> (serialized CLIXML format).
    /// </summary>
    public virtual PwshInOutFormat InputFormat { get; internal set; }
    /// <summary>
    ///   Determines how output from PowerShell is formatted. Valid values are <c>Text</c>  (text strings) or <c>XML</c>  (serialized CLIXML format).
    /// </summary>
    public virtual PwshInOutFormat OutputFormat { get; internal set; }
    /// <summary>
    ///   Sets the window style for the session. Valid values are <c>Normal</c>, <c>Minimized</c>, <c>Maximized</c> and <c>Hidden</c>.
    /// </summary>
    public virtual PwshWindowStyle WindowStyle { get; internal set; }
    /// <summary>
    ///   Accepts a base-64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex quotation marks or curly braces. The string must be formatted using UTF-16LE character encoding.
    /// </summary>
    public virtual string EncodedCommand { get; internal set; }
    /// <summary>
    ///   Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.
    /// </summary>
    public virtual string ConfigurationName { get; internal set; }
    /// <summary>
    ///   Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. This parameter only applies to Windows computers. The <c>$env:PSExecutionPolicyPreference</c> environment variable does not exist on non-Windows platforms.
    /// </summary>
    public virtual PwshExecutionPolicy ExecutionPolicy { get; internal set; }
    /// <summary>
    ///   If the value of File is <c>-</c>, the command text is read from standard input. Running <c>pwsh -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the File parameter at all.<para/>This is the default parameter if no parameters are present but values are present in the command line. The specified script runs in the local scope ("dot-sourced"), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. File must be the last parameter in the command, because all characters typed after the File parameter name are interpreted as the script file path followed by the script parameters.
    /// </summary>
    public virtual string File { get; internal set; }
    /// <summary>
    ///   Arguments passed in when using the <c>-File</c> option.
    /// </summary>
    public virtual IReadOnlyList<string> FileArguments => FileArgumentsInternal.AsReadOnly();
    internal List<string> FileArgumentsInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of Command can be <c>-</c>, a script block, or a string. If the value of Command is <c>-</c>, the command text is read from standard input.<para/>The Command parameter only accepts a script block for execution when it can recognize the value passed to Command as a ScriptBlock type. This is only possible when running pwsh from another PowerShell host. The ScriptBlock type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to pwsh.
    /// </summary>
    public virtual string Command { get; internal set; }
    /// <summary>
    ///   Overrides the system-wide <c>powershell.config.json</c> settings file for the session. By default, system-wide settings are read from the powershell.config.json in the $PSHOME directory. Note that these settings are not used by the endpoint specified by the <c>-ConfigurationName</c> argument.
    /// </summary>
    public virtual string SettingsFile { get; internal set; }
    /// <summary>
    ///   Specifies the name to use for an additional IPC server (named pipe) used for debugging and other cross-process communication. This offers a predictable mechanism for connecting to other PowerShell instances. Typically used with the CustomPipeName parameter on Enter-PSHostProcess. This parameter was introduced in PowerShell 6.2.
    /// </summary>
    public virtual string CustomPipeName { get; internal set; }
    /// <summary>
    ///   Used in sshd_config for running PowerShell as an SSH subsystem. It is not intended or supported for any other use.
    /// </summary>
    public virtual bool? SSHServerMode { get; internal set; }
    /// <summary>
    ///   Sets the initial working directory by executing at startup. Any valid PowerShell file path is supported. To start PowerShell in your home directory, use: <c>pwsh -WorkingDirectory ~</c>
    /// </summary>
    public virtual string WorkingDirectory { get; internal set; }
    /// <summary>
    ///   Specifies a session configuration (.pssc) file path. The configuration contained in the configuration file will be applied to the PowerShell session.
    /// </summary>
    public virtual string ConfigurationFile { get; internal set; }
    /// <summary>
    ///   On Linux and macOS, starts PowerShell as a login shell, using /bin/sh to execute login profiles such as /etc/profile and ~/.profile. On Windows, this switch does nothing. IMPORTANT This parameter must come first to start PowerShell as a login shell. Passing this parameter in another position will be ignored.
    /// </summary>
    public virtual bool? Login { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("-Version", Version)
          .Add("-NoLogo", NoLogo)
          .Add("-NoExit", NoExit)
          .Add("-Sta", SingleThreadedApartment)
          .Add("-Mta", MultiThreadedApartment)
          .Add("-NoProfile", NoProfile)
          .Add("-NoProfileLoadTime", NoProfileLoadTime)
          .Add("-NonInteractive", NonInteractive)
          .Add("-Interactive", Interactive)
          .Add("-InputFormat {value}", InputFormat)
          .Add("-OutputFormat {value}", OutputFormat)
          .Add("-WindowStyle {value}", WindowStyle)
          .Add("-EncodedCommand {value}", EncodedCommand)
          .Add("-ConfigurationName {value}", ConfigurationName)
          .Add("-ExecutionPolicy {value}", ExecutionPolicy)
          .Add("-File  {value}", File)
          .Add("{value}", FileArguments)
          .Add("-Command {value}", Command)
          .Add("-SettingsFile {value}", SettingsFile)
          .Add("-CustomPipeName {value}", CustomPipeName)
          .Add("-SSHServerMode", SSHServerMode)
          .Add("-WorkingDirectory {value}", WorkingDirectory)
          .Add("-ConfigurationFile {value}", ConfigurationFile)
          .Add("-Login", Login);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region PwshSettingsExtensions
/// <summary>
///   Used within <see cref="PwshTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PwshSettingsExtensions
{
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.Version"/></em></p>
    ///   <p>Displays the version of PowerShell. Additional parameters are ignored.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, bool? version) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.Version"/></em></p>
    ///   <p>Displays the version of PowerShell. Additional parameters are ignored.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.Version"/></em></p>
    ///   <p>Displays the version of PowerShell. Additional parameters are ignored.</p>
    /// </summary>
    [Pure]
    public static T EnableVersion<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.Version"/></em></p>
    ///   <p>Displays the version of PowerShell. Additional parameters are ignored.</p>
    /// </summary>
    [Pure]
    public static T DisableVersion<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.Version"/></em></p>
    ///   <p>Displays the version of PowerShell. Additional parameters are ignored.</p>
    /// </summary>
    [Pure]
    public static T ToggleVersion<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = !toolSettings.Version;
        return toolSettings;
    }
    #endregion
    #region NoLogo
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.NoLogo"/></em></p>
    ///   <p>Hides the copyright banner at startup.</p>
    /// </summary>
    [Pure]
    public static T SetNoLogo<T>(this T toolSettings, bool? noLogo) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoLogo = noLogo;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.NoLogo"/></em></p>
    ///   <p>Hides the copyright banner at startup.</p>
    /// </summary>
    [Pure]
    public static T ResetNoLogo<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoLogo = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.NoLogo"/></em></p>
    ///   <p>Hides the copyright banner at startup.</p>
    /// </summary>
    [Pure]
    public static T EnableNoLogo<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoLogo = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.NoLogo"/></em></p>
    ///   <p>Hides the copyright banner at startup.</p>
    /// </summary>
    [Pure]
    public static T DisableNoLogo<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoLogo = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.NoLogo"/></em></p>
    ///   <p>Hides the copyright banner at startup.</p>
    /// </summary>
    [Pure]
    public static T ToggleNoLogo<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoLogo = !toolSettings.NoLogo;
        return toolSettings;
    }
    #endregion
    #region NoExit
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.NoExit"/></em></p>
    ///   <p>Does not exit after running startup commands.</p>
    /// </summary>
    [Pure]
    public static T SetNoExit<T>(this T toolSettings, bool? noExit) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoExit = noExit;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.NoExit"/></em></p>
    ///   <p>Does not exit after running startup commands.</p>
    /// </summary>
    [Pure]
    public static T ResetNoExit<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoExit = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.NoExit"/></em></p>
    ///   <p>Does not exit after running startup commands.</p>
    /// </summary>
    [Pure]
    public static T EnableNoExit<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoExit = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.NoExit"/></em></p>
    ///   <p>Does not exit after running startup commands.</p>
    /// </summary>
    [Pure]
    public static T DisableNoExit<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoExit = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.NoExit"/></em></p>
    ///   <p>Does not exit after running startup commands.</p>
    /// </summary>
    [Pure]
    public static T ToggleNoExit<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoExit = !toolSettings.NoExit;
        return toolSettings;
    }
    #endregion
    #region SingleThreadedApartment
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.SingleThreadedApartment"/></em></p>
    ///   <p>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</p>
    /// </summary>
    [Pure]
    public static T SetSingleThreadedApartment<T>(this T toolSettings, bool? singleThreadedApartment) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SingleThreadedApartment = singleThreadedApartment;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.SingleThreadedApartment"/></em></p>
    ///   <p>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</p>
    /// </summary>
    [Pure]
    public static T ResetSingleThreadedApartment<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SingleThreadedApartment = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.SingleThreadedApartment"/></em></p>
    ///   <p>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</p>
    /// </summary>
    [Pure]
    public static T EnableSingleThreadedApartment<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SingleThreadedApartment = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.SingleThreadedApartment"/></em></p>
    ///   <p>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</p>
    /// </summary>
    [Pure]
    public static T DisableSingleThreadedApartment<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SingleThreadedApartment = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.SingleThreadedApartment"/></em></p>
    ///   <p>Start PowerShell using a single-threaded apartment. This is the default. This switch is only available on the Windows platform.</p>
    /// </summary>
    [Pure]
    public static T ToggleSingleThreadedApartment<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SingleThreadedApartment = !toolSettings.SingleThreadedApartment;
        return toolSettings;
    }
    #endregion
    #region MultiThreadedApartment
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.MultiThreadedApartment"/></em></p>
    ///   <p>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</p>
    /// </summary>
    [Pure]
    public static T SetMultiThreadedApartment<T>(this T toolSettings, bool? multiThreadedApartment) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MultiThreadedApartment = multiThreadedApartment;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.MultiThreadedApartment"/></em></p>
    ///   <p>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</p>
    /// </summary>
    [Pure]
    public static T ResetMultiThreadedApartment<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MultiThreadedApartment = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.MultiThreadedApartment"/></em></p>
    ///   <p>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</p>
    /// </summary>
    [Pure]
    public static T EnableMultiThreadedApartment<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MultiThreadedApartment = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.MultiThreadedApartment"/></em></p>
    ///   <p>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</p>
    /// </summary>
    [Pure]
    public static T DisableMultiThreadedApartment<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MultiThreadedApartment = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.MultiThreadedApartment"/></em></p>
    ///   <p>Start PowerShell using a multi-threaded apartment. This switch is only available on Windows.</p>
    /// </summary>
    [Pure]
    public static T ToggleMultiThreadedApartment<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MultiThreadedApartment = !toolSettings.MultiThreadedApartment;
        return toolSettings;
    }
    #endregion
    #region NoProfile
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.NoProfile"/></em></p>
    ///   <p>Does not load the PowerShell profile.</p>
    /// </summary>
    [Pure]
    public static T SetNoProfile<T>(this T toolSettings, bool? noProfile) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoProfile = noProfile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.NoProfile"/></em></p>
    ///   <p>Does not load the PowerShell profile.</p>
    /// </summary>
    [Pure]
    public static T ResetNoProfile<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoProfile = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.NoProfile"/></em></p>
    ///   <p>Does not load the PowerShell profile.</p>
    /// </summary>
    [Pure]
    public static T EnableNoProfile<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoProfile = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.NoProfile"/></em></p>
    ///   <p>Does not load the PowerShell profile.</p>
    /// </summary>
    [Pure]
    public static T DisableNoProfile<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoProfile = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.NoProfile"/></em></p>
    ///   <p>Does not load the PowerShell profile.</p>
    /// </summary>
    [Pure]
    public static T ToggleNoProfile<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoProfile = !toolSettings.NoProfile;
        return toolSettings;
    }
    #endregion
    #region NoProfileLoadTime
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.NoProfileLoadTime"/></em></p>
    ///   <p>Hides the PowerShell profile load time text shown at startup when the load time exceeds 500 milliseconds.</p>
    /// </summary>
    [Pure]
    public static T SetNoProfileLoadTime<T>(this T toolSettings, bool? noProfileLoadTime) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoProfileLoadTime = noProfileLoadTime;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.NoProfileLoadTime"/></em></p>
    ///   <p>Hides the PowerShell profile load time text shown at startup when the load time exceeds 500 milliseconds.</p>
    /// </summary>
    [Pure]
    public static T ResetNoProfileLoadTime<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoProfileLoadTime = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.NoProfileLoadTime"/></em></p>
    ///   <p>Hides the PowerShell profile load time text shown at startup when the load time exceeds 500 milliseconds.</p>
    /// </summary>
    [Pure]
    public static T EnableNoProfileLoadTime<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoProfileLoadTime = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.NoProfileLoadTime"/></em></p>
    ///   <p>Hides the PowerShell profile load time text shown at startup when the load time exceeds 500 milliseconds.</p>
    /// </summary>
    [Pure]
    public static T DisableNoProfileLoadTime<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoProfileLoadTime = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.NoProfileLoadTime"/></em></p>
    ///   <p>Hides the PowerShell profile load time text shown at startup when the load time exceeds 500 milliseconds.</p>
    /// </summary>
    [Pure]
    public static T ToggleNoProfileLoadTime<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoProfileLoadTime = !toolSettings.NoProfileLoadTime;
        return toolSettings;
    }
    #endregion
    #region NonInteractive
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.NonInteractive"/></em></p>
    ///   <p>This switch is used to create sessions that shouldn't require user input. This is useful for scripts that run in scheduled tasks or CI/CD pipelines. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement terminating errors rather than hanging.</p>
    /// </summary>
    [Pure]
    public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NonInteractive = nonInteractive;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.NonInteractive"/></em></p>
    ///   <p>This switch is used to create sessions that shouldn't require user input. This is useful for scripts that run in scheduled tasks or CI/CD pipelines. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement terminating errors rather than hanging.</p>
    /// </summary>
    [Pure]
    public static T ResetNonInteractive<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NonInteractive = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.NonInteractive"/></em></p>
    ///   <p>This switch is used to create sessions that shouldn't require user input. This is useful for scripts that run in scheduled tasks or CI/CD pipelines. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement terminating errors rather than hanging.</p>
    /// </summary>
    [Pure]
    public static T EnableNonInteractive<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NonInteractive = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.NonInteractive"/></em></p>
    ///   <p>This switch is used to create sessions that shouldn't require user input. This is useful for scripts that run in scheduled tasks or CI/CD pipelines. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement terminating errors rather than hanging.</p>
    /// </summary>
    [Pure]
    public static T DisableNonInteractive<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NonInteractive = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.NonInteractive"/></em></p>
    ///   <p>This switch is used to create sessions that shouldn't require user input. This is useful for scripts that run in scheduled tasks or CI/CD pipelines. Any attempts to use interactive features, like <c>Read-Host</c> or confirmation prompts, result in statement terminating errors rather than hanging.</p>
    /// </summary>
    [Pure]
    public static T ToggleNonInteractive<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NonInteractive = !toolSettings.NonInteractive;
        return toolSettings;
    }
    #endregion
    #region Interactive
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.Interactive"/></em></p>
    ///   <p>Present an interactive prompt to the user. Inverse for <c>NonInteractive</c> parameter.</p>
    /// </summary>
    [Pure]
    public static T SetInteractive<T>(this T toolSettings, bool? interactive) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Interactive = interactive;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.Interactive"/></em></p>
    ///   <p>Present an interactive prompt to the user. Inverse for <c>NonInteractive</c> parameter.</p>
    /// </summary>
    [Pure]
    public static T ResetInteractive<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Interactive = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.Interactive"/></em></p>
    ///   <p>Present an interactive prompt to the user. Inverse for <c>NonInteractive</c> parameter.</p>
    /// </summary>
    [Pure]
    public static T EnableInteractive<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Interactive = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.Interactive"/></em></p>
    ///   <p>Present an interactive prompt to the user. Inverse for <c>NonInteractive</c> parameter.</p>
    /// </summary>
    [Pure]
    public static T DisableInteractive<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Interactive = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.Interactive"/></em></p>
    ///   <p>Present an interactive prompt to the user. Inverse for <c>NonInteractive</c> parameter.</p>
    /// </summary>
    [Pure]
    public static T ToggleInteractive<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Interactive = !toolSettings.Interactive;
        return toolSettings;
    }
    #endregion
    #region InputFormat
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.InputFormat"/></em></p>
    ///   <p>Describes the format of data sent to PowerShell. Valid values are <c>Text</c> (text strings) or <c>XML</c> (serialized CLIXML format).</p>
    /// </summary>
    [Pure]
    public static T SetInputFormat<T>(this T toolSettings, PwshInOutFormat inputFormat) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.InputFormat = inputFormat;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.InputFormat"/></em></p>
    ///   <p>Describes the format of data sent to PowerShell. Valid values are <c>Text</c> (text strings) or <c>XML</c> (serialized CLIXML format).</p>
    /// </summary>
    [Pure]
    public static T ResetInputFormat<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.InputFormat = null;
        return toolSettings;
    }
    #endregion
    #region OutputFormat
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.OutputFormat"/></em></p>
    ///   <p>Determines how output from PowerShell is formatted. Valid values are <c>Text</c>  (text strings) or <c>XML</c>  (serialized CLIXML format).</p>
    /// </summary>
    [Pure]
    public static T SetOutputFormat<T>(this T toolSettings, PwshInOutFormat outputFormat) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OutputFormat = outputFormat;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.OutputFormat"/></em></p>
    ///   <p>Determines how output from PowerShell is formatted. Valid values are <c>Text</c>  (text strings) or <c>XML</c>  (serialized CLIXML format).</p>
    /// </summary>
    [Pure]
    public static T ResetOutputFormat<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OutputFormat = null;
        return toolSettings;
    }
    #endregion
    #region WindowStyle
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.WindowStyle"/></em></p>
    ///   <p>Sets the window style for the session. Valid values are <c>Normal</c>, <c>Minimized</c>, <c>Maximized</c> and <c>Hidden</c>.</p>
    /// </summary>
    [Pure]
    public static T SetWindowStyle<T>(this T toolSettings, PwshWindowStyle windowStyle) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WindowStyle = windowStyle;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.WindowStyle"/></em></p>
    ///   <p>Sets the window style for the session. Valid values are <c>Normal</c>, <c>Minimized</c>, <c>Maximized</c> and <c>Hidden</c>.</p>
    /// </summary>
    [Pure]
    public static T ResetWindowStyle<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WindowStyle = null;
        return toolSettings;
    }
    #endregion
    #region EncodedCommand
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.EncodedCommand"/></em></p>
    ///   <p>Accepts a base-64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex quotation marks or curly braces. The string must be formatted using UTF-16LE character encoding.</p>
    /// </summary>
    [Pure]
    public static T SetEncodedCommand<T>(this T toolSettings, string encodedCommand) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.EncodedCommand = encodedCommand;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.EncodedCommand"/></em></p>
    ///   <p>Accepts a base-64-encoded string version of a command. Use this parameter to submit commands to PowerShell that require complex quotation marks or curly braces. The string must be formatted using UTF-16LE character encoding.</p>
    /// </summary>
    [Pure]
    public static T ResetEncodedCommand<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.EncodedCommand = null;
        return toolSettings;
    }
    #endregion
    #region ConfigurationName
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.ConfigurationName"/></em></p>
    ///   <p>Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.</p>
    /// </summary>
    [Pure]
    public static T SetConfigurationName<T>(this T toolSettings, string configurationName) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigurationName = configurationName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.ConfigurationName"/></em></p>
    ///   <p>Specifies a configuration endpoint in which PowerShell is run. This can be any endpoint registered on the local machine including the default PowerShell remoting endpoints or a custom endpoint having specific user role capabilities.</p>
    /// </summary>
    [Pure]
    public static T ResetConfigurationName<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigurationName = null;
        return toolSettings;
    }
    #endregion
    #region ExecutionPolicy
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.ExecutionPolicy"/></em></p>
    ///   <p>Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. This parameter only applies to Windows computers. The <c>$env:PSExecutionPolicyPreference</c> environment variable does not exist on non-Windows platforms.</p>
    /// </summary>
    [Pure]
    public static T SetExecutionPolicy<T>(this T toolSettings, PwshExecutionPolicy executionPolicy) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExecutionPolicy = executionPolicy;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.ExecutionPolicy"/></em></p>
    ///   <p>Sets the default execution policy for the current session and saves it in the <c>$env:PSExecutionPolicyPreference</c> environment variable. This parameter does not change the PowerShell execution policy that is set in the registry. This parameter only applies to Windows computers. The <c>$env:PSExecutionPolicyPreference</c> environment variable does not exist on non-Windows platforms.</p>
    /// </summary>
    [Pure]
    public static T ResetExecutionPolicy<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExecutionPolicy = null;
        return toolSettings;
    }
    #endregion
    #region File
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.File"/></em></p>
    ///   <p>If the value of File is <c>-</c>, the command text is read from standard input. Running <c>pwsh -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the File parameter at all.<para/>This is the default parameter if no parameters are present but values are present in the command line. The specified script runs in the local scope ("dot-sourced"), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. File must be the last parameter in the command, because all characters typed after the File parameter name are interpreted as the script file path followed by the script parameters.</p>
    /// </summary>
    [Pure]
    public static T SetFile<T>(this T toolSettings, string file) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.File = file;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.File"/></em></p>
    ///   <p>If the value of File is <c>-</c>, the command text is read from standard input. Running <c>pwsh -File -</c> without redirected standard input starts a regular session. This is the same as not specifying the File parameter at all.<para/>This is the default parameter if no parameters are present but values are present in the command line. The specified script runs in the local scope ("dot-sourced"), so that the functions and variables that the script creates are available in the current session. Enter the script file path and any parameters. File must be the last parameter in the command, because all characters typed after the File parameter name are interpreted as the script file path followed by the script parameters.</p>
    /// </summary>
    [Pure]
    public static T ResetFile<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.File = null;
        return toolSettings;
    }
    #endregion
    #region FileArguments
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.FileArguments"/> to a new list</em></p>
    ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
    /// </summary>
    [Pure]
    public static T SetFileArguments<T>(this T toolSettings, params string[] fileArguments) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileArgumentsInternal = fileArguments.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.FileArguments"/> to a new list</em></p>
    ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
    /// </summary>
    [Pure]
    public static T SetFileArguments<T>(this T toolSettings, IEnumerable<string> fileArguments) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileArgumentsInternal = fileArguments.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="PwshSettings.FileArguments"/></em></p>
    ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
    /// </summary>
    [Pure]
    public static T AddFileArguments<T>(this T toolSettings, params string[] fileArguments) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileArgumentsInternal.AddRange(fileArguments);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="PwshSettings.FileArguments"/></em></p>
    ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
    /// </summary>
    [Pure]
    public static T AddFileArguments<T>(this T toolSettings, IEnumerable<string> fileArguments) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileArgumentsInternal.AddRange(fileArguments);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="PwshSettings.FileArguments"/></em></p>
    ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
    /// </summary>
    [Pure]
    public static T ClearFileArguments<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileArgumentsInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="PwshSettings.FileArguments"/></em></p>
    ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
    /// </summary>
    [Pure]
    public static T RemoveFileArguments<T>(this T toolSettings, params string[] fileArguments) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(fileArguments);
        toolSettings.FileArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="PwshSettings.FileArguments"/></em></p>
    ///   <p>Arguments passed in when using the <c>-File</c> option.</p>
    /// </summary>
    [Pure]
    public static T RemoveFileArguments<T>(this T toolSettings, IEnumerable<string> fileArguments) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(fileArguments);
        toolSettings.FileArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Command
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.Command"/></em></p>
    ///   <p>Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of Command can be <c>-</c>, a script block, or a string. If the value of Command is <c>-</c>, the command text is read from standard input.<para/>The Command parameter only accepts a script block for execution when it can recognize the value passed to Command as a ScriptBlock type. This is only possible when running pwsh from another PowerShell host. The ScriptBlock type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to pwsh.</p>
    /// </summary>
    [Pure]
    public static T SetCommand<T>(this T toolSettings, string command) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Command = command;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.Command"/></em></p>
    ///   <p>Executes the specified commands (and any parameters) as though they were typed at the PowerShell command prompt, and then exits, unless the <c>NoExit</c> parameter is specified.<para/>The value of Command can be <c>-</c>, a script block, or a string. If the value of Command is <c>-</c>, the command text is read from standard input.<para/>The Command parameter only accepts a script block for execution when it can recognize the value passed to Command as a ScriptBlock type. This is only possible when running pwsh from another PowerShell host. The ScriptBlock type may be contained in an existing variable, returned from an expression, or parsed by the PowerShell host as a literal script block enclosed in curly braces (<c>{}</c>), before being passed to pwsh.</p>
    /// </summary>
    [Pure]
    public static T ResetCommand<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Command = null;
        return toolSettings;
    }
    #endregion
    #region SettingsFile
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.SettingsFile"/></em></p>
    ///   <p>Overrides the system-wide <c>powershell.config.json</c> settings file for the session. By default, system-wide settings are read from the powershell.config.json in the $PSHOME directory. Note that these settings are not used by the endpoint specified by the <c>-ConfigurationName</c> argument.</p>
    /// </summary>
    [Pure]
    public static T SetSettingsFile<T>(this T toolSettings, string settingsFile) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SettingsFile = settingsFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.SettingsFile"/></em></p>
    ///   <p>Overrides the system-wide <c>powershell.config.json</c> settings file for the session. By default, system-wide settings are read from the powershell.config.json in the $PSHOME directory. Note that these settings are not used by the endpoint specified by the <c>-ConfigurationName</c> argument.</p>
    /// </summary>
    [Pure]
    public static T ResetSettingsFile<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SettingsFile = null;
        return toolSettings;
    }
    #endregion
    #region CustomPipeName
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.CustomPipeName"/></em></p>
    ///   <p>Specifies the name to use for an additional IPC server (named pipe) used for debugging and other cross-process communication. This offers a predictable mechanism for connecting to other PowerShell instances. Typically used with the CustomPipeName parameter on Enter-PSHostProcess. This parameter was introduced in PowerShell 6.2.</p>
    /// </summary>
    [Pure]
    public static T SetCustomPipeName<T>(this T toolSettings, string customPipeName) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CustomPipeName = customPipeName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.CustomPipeName"/></em></p>
    ///   <p>Specifies the name to use for an additional IPC server (named pipe) used for debugging and other cross-process communication. This offers a predictable mechanism for connecting to other PowerShell instances. Typically used with the CustomPipeName parameter on Enter-PSHostProcess. This parameter was introduced in PowerShell 6.2.</p>
    /// </summary>
    [Pure]
    public static T ResetCustomPipeName<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CustomPipeName = null;
        return toolSettings;
    }
    #endregion
    #region SSHServerMode
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.SSHServerMode"/></em></p>
    ///   <p>Used in sshd_config for running PowerShell as an SSH subsystem. It is not intended or supported for any other use.</p>
    /// </summary>
    [Pure]
    public static T SetSSHServerMode<T>(this T toolSettings, bool? sshserverMode) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SSHServerMode = sshserverMode;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.SSHServerMode"/></em></p>
    ///   <p>Used in sshd_config for running PowerShell as an SSH subsystem. It is not intended or supported for any other use.</p>
    /// </summary>
    [Pure]
    public static T ResetSSHServerMode<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SSHServerMode = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.SSHServerMode"/></em></p>
    ///   <p>Used in sshd_config for running PowerShell as an SSH subsystem. It is not intended or supported for any other use.</p>
    /// </summary>
    [Pure]
    public static T EnableSSHServerMode<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SSHServerMode = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.SSHServerMode"/></em></p>
    ///   <p>Used in sshd_config for running PowerShell as an SSH subsystem. It is not intended or supported for any other use.</p>
    /// </summary>
    [Pure]
    public static T DisableSSHServerMode<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SSHServerMode = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.SSHServerMode"/></em></p>
    ///   <p>Used in sshd_config for running PowerShell as an SSH subsystem. It is not intended or supported for any other use.</p>
    /// </summary>
    [Pure]
    public static T ToggleSSHServerMode<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SSHServerMode = !toolSettings.SSHServerMode;
        return toolSettings;
    }
    #endregion
    #region WorkingDirectory
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.WorkingDirectory"/></em></p>
    ///   <p>Sets the initial working directory by executing at startup. Any valid PowerShell file path is supported. To start PowerShell in your home directory, use: <c>pwsh -WorkingDirectory ~</c></p>
    /// </summary>
    [Pure]
    public static T SetWorkingDirectory<T>(this T toolSettings, string workingDirectory) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WorkingDirectory = workingDirectory;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.WorkingDirectory"/></em></p>
    ///   <p>Sets the initial working directory by executing at startup. Any valid PowerShell file path is supported. To start PowerShell in your home directory, use: <c>pwsh -WorkingDirectory ~</c></p>
    /// </summary>
    [Pure]
    public static T ResetWorkingDirectory<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WorkingDirectory = null;
        return toolSettings;
    }
    #endregion
    #region ConfigurationFile
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.ConfigurationFile"/></em></p>
    ///   <p>Specifies a session configuration (.pssc) file path. The configuration contained in the configuration file will be applied to the PowerShell session.</p>
    /// </summary>
    [Pure]
    public static T SetConfigurationFile<T>(this T toolSettings, string configurationFile) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigurationFile = configurationFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.ConfigurationFile"/></em></p>
    ///   <p>Specifies a session configuration (.pssc) file path. The configuration contained in the configuration file will be applied to the PowerShell session.</p>
    /// </summary>
    [Pure]
    public static T ResetConfigurationFile<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigurationFile = null;
        return toolSettings;
    }
    #endregion
    #region Login
    /// <summary>
    ///   <p><em>Sets <see cref="PwshSettings.Login"/></em></p>
    ///   <p>On Linux and macOS, starts PowerShell as a login shell, using /bin/sh to execute login profiles such as /etc/profile and ~/.profile. On Windows, this switch does nothing. IMPORTANT This parameter must come first to start PowerShell as a login shell. Passing this parameter in another position will be ignored.</p>
    /// </summary>
    [Pure]
    public static T SetLogin<T>(this T toolSettings, bool? login) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Login = login;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="PwshSettings.Login"/></em></p>
    ///   <p>On Linux and macOS, starts PowerShell as a login shell, using /bin/sh to execute login profiles such as /etc/profile and ~/.profile. On Windows, this switch does nothing. IMPORTANT This parameter must come first to start PowerShell as a login shell. Passing this parameter in another position will be ignored.</p>
    /// </summary>
    [Pure]
    public static T ResetLogin<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Login = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="PwshSettings.Login"/></em></p>
    ///   <p>On Linux and macOS, starts PowerShell as a login shell, using /bin/sh to execute login profiles such as /etc/profile and ~/.profile. On Windows, this switch does nothing. IMPORTANT This parameter must come first to start PowerShell as a login shell. Passing this parameter in another position will be ignored.</p>
    /// </summary>
    [Pure]
    public static T EnableLogin<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Login = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="PwshSettings.Login"/></em></p>
    ///   <p>On Linux and macOS, starts PowerShell as a login shell, using /bin/sh to execute login profiles such as /etc/profile and ~/.profile. On Windows, this switch does nothing. IMPORTANT This parameter must come first to start PowerShell as a login shell. Passing this parameter in another position will be ignored.</p>
    /// </summary>
    [Pure]
    public static T DisableLogin<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Login = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="PwshSettings.Login"/></em></p>
    ///   <p>On Linux and macOS, starts PowerShell as a login shell, using /bin/sh to execute login profiles such as /etc/profile and ~/.profile. On Windows, this switch does nothing. IMPORTANT This parameter must come first to start PowerShell as a login shell. Passing this parameter in another position will be ignored.</p>
    /// </summary>
    [Pure]
    public static T ToggleLogin<T>(this T toolSettings) where T : PwshSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Login = !toolSettings.Login;
        return toolSettings;
    }
    #endregion
}
#endregion
#region PwshExecutionPolicy
/// <summary>
///   Used within <see cref="PwshTasks"/>.
/// </summary>
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
/// <summary>
///   Used within <see cref="PwshTasks"/>.
/// </summary>
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
/// <summary>
///   Used within <see cref="PwshTasks"/>.
/// </summary>
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
