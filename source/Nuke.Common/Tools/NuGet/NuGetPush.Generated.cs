using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.NuGet
{
    public static partial class NuGetTasks
    {
        static partial void PreProcess (NuGetPushSettings nuGetPushSettings);
        static partial void PostProcess (NuGetPushSettings nuGetPushSettings);
        /// <summary>
        /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        public static void NuGetPush (Configure<NuGetPushSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var nuGetPushSettings = new NuGetPushSettings();
            nuGetPushSettings = configurator(nuGetPushSettings);
            PreProcess(nuGetPushSettings);
            var process = ProcessTasks.StartProcess(nuGetPushSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(nuGetPushSettings);
        }
    }
    /// <summary>
    /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetPushSettings : NuGetSettings
    {
        /// <summary><p>Path of the package to push.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>The API key for the target repository. If not present, the one specified in <i>%AppData%\NuGet\NuGet.Config</i> is used.</p></summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary><p>Specifies the server URL. With NuGet 2.5+, NuGet will identify a UNC or local folder source and simply copy the file there instead of pushing it using HTTP. Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <i>NuGet.Config</i> file specifies a <i>DefaultPushSource</i> value.</p></summary>
        public virtual string Source { get; internal set; }
        /// <summary><p><i>(3.5+)</i> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p></summary>
        public virtual string SymbolSource { get; internal set; }
        /// <summary><p><i>(3.5+)</i> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p></summary>
        public virtual string SymbolApiKey { get; internal set; }
        /// <summary><p><i>(3.5+)</i> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        public virtual bool NoSymbols { get; internal set; }
        /// <summary><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        public virtual bool DisableBuffering { get; internal set; }
        /// <summary><p><i>(2.5+)</i> The NuGet configuration file to apply. If not specified, <i>%AppData%\NuGet\NuGet.Config</i> is used.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p><i>(2.5+)</i> Specifies the amount of details displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p></summary>
        public virtual NuGetVerbosity? Verbosity { get; internal set; }
        /// <summary><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        public virtual bool ForceEnglishOutput { get; internal set; }
        /// <summary><p>Suppresses prompts for user input or confirmations.</p></summary>
        public virtual bool NonInteractive { get; internal set; }
        /// <summary><p>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</p></summary>
        public virtual int? Timeout { get; internal set; }
        /// <inheritdoc />
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), $"File.Exists(TargetPath)");
            ControlFlow.Assert(File.Exists(ConfigFile) || ConfigFile == null, $"File.Exists(ConfigFile) || ConfigFile == null");
        }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("push")
              .Add("{value}", TargetPath)
              .Add("-ApiKey {value}", ApiKey, secret: true)
              .Add("-Source {value}", Source)
              .Add("-SymbolSource {value}", SymbolSource)
              .Add("-SymbolApiKey {value}", SymbolApiKey, secret: true)
              .Add("-NoSymbols", NoSymbols)
              .Add("-DisableBuffering", DisableBuffering)
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-NonInteractive", NonInteractive)
              .Add("-Timeout {value}", Timeout);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetPushSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.TargetPath"/>.</i></p>
        /// <p>Path of the package to push.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetTargetPath(this NuGetPushSettings nuGetPushSettings, string targetPath)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.TargetPath = targetPath;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.ApiKey"/>.</i></p>
        /// <p>The API key for the target repository. If not present, the one specified in <i>%AppData%\NuGet\NuGet.Config</i> is used.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetApiKey(this NuGetPushSettings nuGetPushSettings, string apiKey)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ApiKey = apiKey;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.Source"/>.</i></p>
        /// <p>Specifies the server URL. With NuGet 2.5+, NuGet will identify a UNC or local folder source and simply copy the file there instead of pushing it using HTTP. Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <i>NuGet.Config</i> file specifies a <i>DefaultPushSource</i> value.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetSource(this NuGetPushSettings nuGetPushSettings, string source)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.Source = source;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.SymbolSource"/>.</i></p>
        /// <p><i>(3.5+)</i> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetSymbolSource(this NuGetPushSettings nuGetPushSettings, string symbolSource)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.SymbolSource = symbolSource;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.SymbolApiKey"/>.</i></p>
        /// <p><i>(3.5+)</i> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetSymbolApiKey(this NuGetPushSettings nuGetPushSettings, string symbolApiKey)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.SymbolApiKey = symbolApiKey;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.NoSymbols"/>.</i></p>
        /// <p><i>(3.5+)</i> If a symbols package exists, it will not be pushed to a symbol server.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetNoSymbols(this NuGetPushSettings nuGetPushSettings, bool noSymbols)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NoSymbols = noSymbols;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPushSettings.NoSymbols"/>.</i></p>
        /// <p><i>(3.5+)</i> If a symbols package exists, it will not be pushed to a symbol server.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings EnableNoSymbols(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NoSymbols = true;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPushSettings.NoSymbols"/>.</i></p>
        /// <p><i>(3.5+)</i> If a symbols package exists, it will not be pushed to a symbol server.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings DisableNoSymbols(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NoSymbols = false;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPushSettings.NoSymbols"/>.</i></p>
        /// <p><i>(3.5+)</i> If a symbols package exists, it will not be pushed to a symbol server.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings ToggleNoSymbols(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NoSymbols = !nuGetPushSettings.NoSymbols;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p>
        /// <p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetDisableBuffering(this NuGetPushSettings nuGetPushSettings, bool disableBuffering)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.DisableBuffering = disableBuffering;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p>
        /// <p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings EnableDisableBuffering(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.DisableBuffering = true;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p>
        /// <p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings DisableDisableBuffering(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.DisableBuffering = false;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p>
        /// <p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings ToggleDisableBuffering(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.DisableBuffering = !nuGetPushSettings.DisableBuffering;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.ConfigFile"/>.</i></p>
        /// <p><i>(2.5+)</i> The NuGet configuration file to apply. If not specified, <i>%AppData%\NuGet\NuGet.Config</i> is used.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetConfigFile(this NuGetPushSettings nuGetPushSettings, string configFile)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ConfigFile = configFile;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.Verbosity"/>.</i></p>
        /// <p><i>(2.5+)</i> Specifies the amount of details displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetVerbosity(this NuGetPushSettings nuGetPushSettings, NuGetVerbosity? verbosity)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.Verbosity = verbosity;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetForceEnglishOutput(this NuGetPushSettings nuGetPushSettings, bool forceEnglishOutput)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ForceEnglishOutput = forceEnglishOutput;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings EnableForceEnglishOutput(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ForceEnglishOutput = true;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings DisableForceEnglishOutput(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ForceEnglishOutput = false;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings ToggleForceEnglishOutput(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ForceEnglishOutput = !nuGetPushSettings.ForceEnglishOutput;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.NonInteractive"/>.</i></p>
        /// <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetNonInteractive(this NuGetPushSettings nuGetPushSettings, bool nonInteractive)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NonInteractive = nonInteractive;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPushSettings.NonInteractive"/>.</i></p>
        /// <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings EnableNonInteractive(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NonInteractive = true;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPushSettings.NonInteractive"/>.</i></p>
        /// <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings DisableNonInteractive(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NonInteractive = false;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPushSettings.NonInteractive"/>.</i></p>
        /// <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings ToggleNonInteractive(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NonInteractive = !nuGetPushSettings.NonInteractive;
            return nuGetPushSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPushSettings.Timeout"/>.</i></p>
        /// <p>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</p>
        /// </summary>
        [Pure]
        public static NuGetPushSettings SetTimeout(this NuGetPushSettings nuGetPushSettings, int? timeout)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.Timeout = timeout;
            return nuGetPushSettings;
        }
    }
}
