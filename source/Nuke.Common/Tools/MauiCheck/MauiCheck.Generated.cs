// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/MauiCheck/MauiCheck.json

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

namespace Nuke.Common.Tools.MauiCheck
{
    /// <summary>
    ///   <p>A dotnet tool for helping set up your .NET MAUI environment.</p>
    ///   <p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(MauiCheckPackageId)]
    public partial class MauiCheckTasks
        : IRequireNuGetPackage
    {
        public const string MauiCheckPackageId = "Redth.Net.Maui.Check";
        /// <summary>
        ///   Path to the MauiCheck executable.
        /// </summary>
        public static string MauiCheckPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("MAUICHECK_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("Redth.Net.Maui.Check", "MauiCheck.dll");
        public static Action<OutputType, string> MauiCheckLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>A dotnet tool for helping set up your .NET MAUI environment.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> MauiCheck(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(MauiCheckPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? MauiCheckLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>A dotnet tool for helping set up your .NET MAUI environment.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--ci</c> via <see cref="MauiCheckSettings.Ci"/></li>
        ///     <li><c>--fix</c> via <see cref="MauiCheckSettings.Fix"/></li>
        ///     <li><c>--manifest</c> via <see cref="MauiCheckSettings.Manifest"/></li>
        ///     <li><c>--non-interactive</c> via <see cref="MauiCheckSettings.NonInteractive"/></li>
        ///     <li><c>--preview</c> via <see cref="MauiCheckSettings.Preview"/></li>
        ///     <li><c>--skip</c> via <see cref="MauiCheckSettings.Skip"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> MauiCheck(MauiCheckSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new MauiCheckSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>A dotnet tool for helping set up your .NET MAUI environment.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--ci</c> via <see cref="MauiCheckSettings.Ci"/></li>
        ///     <li><c>--fix</c> via <see cref="MauiCheckSettings.Fix"/></li>
        ///     <li><c>--manifest</c> via <see cref="MauiCheckSettings.Manifest"/></li>
        ///     <li><c>--non-interactive</c> via <see cref="MauiCheckSettings.NonInteractive"/></li>
        ///     <li><c>--preview</c> via <see cref="MauiCheckSettings.Preview"/></li>
        ///     <li><c>--skip</c> via <see cref="MauiCheckSettings.Skip"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> MauiCheck(Configure<MauiCheckSettings> configurator)
        {
            return MauiCheck(configurator(new MauiCheckSettings()));
        }
        /// <summary>
        ///   <p>A dotnet tool for helping set up your .NET MAUI environment.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--ci</c> via <see cref="MauiCheckSettings.Ci"/></li>
        ///     <li><c>--fix</c> via <see cref="MauiCheckSettings.Fix"/></li>
        ///     <li><c>--manifest</c> via <see cref="MauiCheckSettings.Manifest"/></li>
        ///     <li><c>--non-interactive</c> via <see cref="MauiCheckSettings.NonInteractive"/></li>
        ///     <li><c>--preview</c> via <see cref="MauiCheckSettings.Preview"/></li>
        ///     <li><c>--skip</c> via <see cref="MauiCheckSettings.Skip"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(MauiCheckSettings Settings, IReadOnlyCollection<Output> Output)> MauiCheck(CombinatorialConfigure<MauiCheckSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(MauiCheck, MauiCheckLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>A dotnet tool for helping set up your .NET MAUI environment.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--dotnet-pre</c> via <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></li>
        ///     <li><c>--dotnet-rollForward</c> via <see cref="MauiCheckConfigSettings.DotNetRollForward"/></li>
        ///     <li><c>--dotnet-version</c> via <see cref="MauiCheckConfigSettings.DotNetVersion"/></li>
        ///     <li><c>--nuget-sources</c> via <see cref="MauiCheckConfigSettings.NuGetSources"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> MauiCheckConfig(MauiCheckConfigSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new MauiCheckConfigSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>A dotnet tool for helping set up your .NET MAUI environment.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--dotnet-pre</c> via <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></li>
        ///     <li><c>--dotnet-rollForward</c> via <see cref="MauiCheckConfigSettings.DotNetRollForward"/></li>
        ///     <li><c>--dotnet-version</c> via <see cref="MauiCheckConfigSettings.DotNetVersion"/></li>
        ///     <li><c>--nuget-sources</c> via <see cref="MauiCheckConfigSettings.NuGetSources"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> MauiCheckConfig(Configure<MauiCheckConfigSettings> configurator)
        {
            return MauiCheckConfig(configurator(new MauiCheckConfigSettings()));
        }
        /// <summary>
        ///   <p>A dotnet tool for helping set up your .NET MAUI environment.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--dotnet-pre</c> via <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></li>
        ///     <li><c>--dotnet-rollForward</c> via <see cref="MauiCheckConfigSettings.DotNetRollForward"/></li>
        ///     <li><c>--dotnet-version</c> via <see cref="MauiCheckConfigSettings.DotNetVersion"/></li>
        ///     <li><c>--nuget-sources</c> via <see cref="MauiCheckConfigSettings.NuGetSources"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(MauiCheckConfigSettings Settings, IReadOnlyCollection<Output> Output)> MauiCheckConfig(CombinatorialConfigure<MauiCheckConfigSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(MauiCheckConfig, MauiCheckLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region MauiCheckSettings
    /// <summary>
    ///   Used within <see cref="MauiCheckTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class MauiCheckSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the MauiCheck executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? MauiCheckTasks.MauiCheckPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? MauiCheckTasks.MauiCheckLogger;
        /// <summary>
        ///   Manifest files are currently used by the doctor to fetch the latest versions and requirements. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest">https://aka.ms/dotnet-maui-check-manifest</a>. Use this option to specify an alternative file path or URL to use.
        /// </summary>
        public virtual string Manifest { get; internal set; }
        /// <summary>
        ///   You can try using the <c>--fix</c> argument to automatically enable solutions to run without being prompted.
        /// </summary>
        public virtual bool? Fix { get; internal set; }
        /// <summary>
        ///   If you're running on CI you may want to run without any required input with the <c>--non-interactive</c> argument. You can combine this with <c>--fix</c> to automatically fix without prompting.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   This uses a more frequently updated manifest with newer versions of things more often. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest-dev">https://aka.ms/dotnet-maui-check-manifest-dev</a>
        /// </summary>
        public virtual bool? Preview { get; internal set; }
        /// <summary>
        ///   Uses the <c>dotnet-install</c> powershell / bash scripts for installing the dotnet SDK version from the manifest instead of the global installer.
        /// </summary>
        public virtual bool? Ci { get; internal set; }
        /// <summary>
        ///   Skips a checkup by name or id as listed in maui-check list. NOTE: If there are any other checkups which depend on a skipped checkup, they will be skipped too.
        /// </summary>
        public virtual IReadOnlyList<MauiCheckCheckup> Skip => SkipInternal.AsReadOnly();
        internal List<MauiCheckCheckup> SkipInternal { get; set; } = new List<MauiCheckCheckup>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("--manifest {value}", Manifest)
              .Add("--fix", Fix)
              .Add("--non-interactive", NonInteractive)
              .Add("--preview", Preview)
              .Add("--ci", Ci)
              .Add("--skip {value}", Skip);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region MauiCheckConfigSettings
    /// <summary>
    ///   Used within <see cref="MauiCheckTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class MauiCheckConfigSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the MauiCheck executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? MauiCheckTasks.MauiCheckPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? MauiCheckTasks.MauiCheckLogger;
        /// <summary>
        ///   Use the SDK version in the manifest in <em>global.json</em>.
        /// </summary>
        public virtual bool? DotNetVersion { get; internal set; }
        /// <summary>
        ///   Change the <c>allowPrerelease</c> value in the <em>global.json</em>.
        /// </summary>
        public virtual bool? DotNetPrerelease { get; internal set; }
        /// <summary>
        ///   Change the <c>rollForward</c> value in <em>global.json</em> to one of the allowed values specified.
        /// </summary>
        public virtual MauiCheckDotNetRollForward DotNetRollForward { get; internal set; }
        /// <summary>
        ///   Adds the nuget sources specified in the manifest to the <em>NuGet.config</em> and creates the file if needed.
        /// </summary>
        public virtual bool? NuGetSources { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("config")
              .Add("--dotnet-version", DotNetVersion)
              .Add("--dotnet-pre {value}", DotNetPrerelease)
              .Add("--dotnet-rollForward {value}", DotNetRollForward)
              .Add("--nuget-sources", NuGetSources);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region MauiCheckSettingsExtensions
    /// <summary>
    ///   Used within <see cref="MauiCheckTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MauiCheckSettingsExtensions
    {
        #region Manifest
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckSettings.Manifest"/></em></p>
        ///   <p>Manifest files are currently used by the doctor to fetch the latest versions and requirements. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest">https://aka.ms/dotnet-maui-check-manifest</a>. Use this option to specify an alternative file path or URL to use.</p>
        /// </summary>
        [Pure]
        public static T SetManifest<T>(this T toolSettings, string manifest) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manifest = manifest;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MauiCheckSettings.Manifest"/></em></p>
        ///   <p>Manifest files are currently used by the doctor to fetch the latest versions and requirements. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest">https://aka.ms/dotnet-maui-check-manifest</a>. Use this option to specify an alternative file path or URL to use.</p>
        /// </summary>
        [Pure]
        public static T ResetManifest<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manifest = null;
            return toolSettings;
        }
        #endregion
        #region Fix
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckSettings.Fix"/></em></p>
        ///   <p>You can try using the <c>--fix</c> argument to automatically enable solutions to run without being prompted.</p>
        /// </summary>
        [Pure]
        public static T SetFix<T>(this T toolSettings, bool? fix) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fix = fix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MauiCheckSettings.Fix"/></em></p>
        ///   <p>You can try using the <c>--fix</c> argument to automatically enable solutions to run without being prompted.</p>
        /// </summary>
        [Pure]
        public static T ResetFix<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MauiCheckSettings.Fix"/></em></p>
        ///   <p>You can try using the <c>--fix</c> argument to automatically enable solutions to run without being prompted.</p>
        /// </summary>
        [Pure]
        public static T EnableFix<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MauiCheckSettings.Fix"/></em></p>
        ///   <p>You can try using the <c>--fix</c> argument to automatically enable solutions to run without being prompted.</p>
        /// </summary>
        [Pure]
        public static T DisableFix<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MauiCheckSettings.Fix"/></em></p>
        ///   <p>You can try using the <c>--fix</c> argument to automatically enable solutions to run without being prompted.</p>
        /// </summary>
        [Pure]
        public static T ToggleFix<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Fix = !toolSettings.Fix;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckSettings.NonInteractive"/></em></p>
        ///   <p>If you're running on CI you may want to run without any required input with the <c>--non-interactive</c> argument. You can combine this with <c>--fix</c> to automatically fix without prompting.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MauiCheckSettings.NonInteractive"/></em></p>
        ///   <p>If you're running on CI you may want to run without any required input with the <c>--non-interactive</c> argument. You can combine this with <c>--fix</c> to automatically fix without prompting.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MauiCheckSettings.NonInteractive"/></em></p>
        ///   <p>If you're running on CI you may want to run without any required input with the <c>--non-interactive</c> argument. You can combine this with <c>--fix</c> to automatically fix without prompting.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MauiCheckSettings.NonInteractive"/></em></p>
        ///   <p>If you're running on CI you may want to run without any required input with the <c>--non-interactive</c> argument. You can combine this with <c>--fix</c> to automatically fix without prompting.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MauiCheckSettings.NonInteractive"/></em></p>
        ///   <p>If you're running on CI you may want to run without any required input with the <c>--non-interactive</c> argument. You can combine this with <c>--fix</c> to automatically fix without prompting.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region Preview
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckSettings.Preview"/></em></p>
        ///   <p>This uses a more frequently updated manifest with newer versions of things more often. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest-dev">https://aka.ms/dotnet-maui-check-manifest-dev</a></p>
        /// </summary>
        [Pure]
        public static T SetPreview<T>(this T toolSettings, bool? preview) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preview = preview;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MauiCheckSettings.Preview"/></em></p>
        ///   <p>This uses a more frequently updated manifest with newer versions of things more often. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest-dev">https://aka.ms/dotnet-maui-check-manifest-dev</a></p>
        /// </summary>
        [Pure]
        public static T ResetPreview<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preview = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MauiCheckSettings.Preview"/></em></p>
        ///   <p>This uses a more frequently updated manifest with newer versions of things more often. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest-dev">https://aka.ms/dotnet-maui-check-manifest-dev</a></p>
        /// </summary>
        [Pure]
        public static T EnablePreview<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preview = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MauiCheckSettings.Preview"/></em></p>
        ///   <p>This uses a more frequently updated manifest with newer versions of things more often. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest-dev">https://aka.ms/dotnet-maui-check-manifest-dev</a></p>
        /// </summary>
        [Pure]
        public static T DisablePreview<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preview = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MauiCheckSettings.Preview"/></em></p>
        ///   <p>This uses a more frequently updated manifest with newer versions of things more often. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest-dev">https://aka.ms/dotnet-maui-check-manifest-dev</a></p>
        /// </summary>
        [Pure]
        public static T TogglePreview<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preview = !toolSettings.Preview;
            return toolSettings;
        }
        #endregion
        #region Ci
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckSettings.Ci"/></em></p>
        ///   <p>Uses the <c>dotnet-install</c> powershell / bash scripts for installing the dotnet SDK version from the manifest instead of the global installer.</p>
        /// </summary>
        [Pure]
        public static T SetCi<T>(this T toolSettings, bool? ci) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Ci = ci;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MauiCheckSettings.Ci"/></em></p>
        ///   <p>Uses the <c>dotnet-install</c> powershell / bash scripts for installing the dotnet SDK version from the manifest instead of the global installer.</p>
        /// </summary>
        [Pure]
        public static T ResetCi<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Ci = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MauiCheckSettings.Ci"/></em></p>
        ///   <p>Uses the <c>dotnet-install</c> powershell / bash scripts for installing the dotnet SDK version from the manifest instead of the global installer.</p>
        /// </summary>
        [Pure]
        public static T EnableCi<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Ci = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MauiCheckSettings.Ci"/></em></p>
        ///   <p>Uses the <c>dotnet-install</c> powershell / bash scripts for installing the dotnet SDK version from the manifest instead of the global installer.</p>
        /// </summary>
        [Pure]
        public static T DisableCi<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Ci = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MauiCheckSettings.Ci"/></em></p>
        ///   <p>Uses the <c>dotnet-install</c> powershell / bash scripts for installing the dotnet SDK version from the manifest instead of the global installer.</p>
        /// </summary>
        [Pure]
        public static T ToggleCi<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Ci = !toolSettings.Ci;
            return toolSettings;
        }
        #endregion
        #region Skip
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckSettings.Skip"/> to a new list</em></p>
        ///   <p>Skips a checkup by name or id as listed in maui-check list. NOTE: If there are any other checkups which depend on a skipped checkup, they will be skipped too.</p>
        /// </summary>
        [Pure]
        public static T SetSkip<T>(this T toolSettings, params MauiCheckCheckup[] skip) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal = skip.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckSettings.Skip"/> to a new list</em></p>
        ///   <p>Skips a checkup by name or id as listed in maui-check list. NOTE: If there are any other checkups which depend on a skipped checkup, they will be skipped too.</p>
        /// </summary>
        [Pure]
        public static T SetSkip<T>(this T toolSettings, IEnumerable<MauiCheckCheckup> skip) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal = skip.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MauiCheckSettings.Skip"/></em></p>
        ///   <p>Skips a checkup by name or id as listed in maui-check list. NOTE: If there are any other checkups which depend on a skipped checkup, they will be skipped too.</p>
        /// </summary>
        [Pure]
        public static T AddSkip<T>(this T toolSettings, params MauiCheckCheckup[] skip) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.AddRange(skip);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MauiCheckSettings.Skip"/></em></p>
        ///   <p>Skips a checkup by name or id as listed in maui-check list. NOTE: If there are any other checkups which depend on a skipped checkup, they will be skipped too.</p>
        /// </summary>
        [Pure]
        public static T AddSkip<T>(this T toolSettings, IEnumerable<MauiCheckCheckup> skip) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.AddRange(skip);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MauiCheckSettings.Skip"/></em></p>
        ///   <p>Skips a checkup by name or id as listed in maui-check list. NOTE: If there are any other checkups which depend on a skipped checkup, they will be skipped too.</p>
        /// </summary>
        [Pure]
        public static T ClearSkip<T>(this T toolSettings) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MauiCheckSettings.Skip"/></em></p>
        ///   <p>Skips a checkup by name or id as listed in maui-check list. NOTE: If there are any other checkups which depend on a skipped checkup, they will be skipped too.</p>
        /// </summary>
        [Pure]
        public static T RemoveSkip<T>(this T toolSettings, params MauiCheckCheckup[] skip) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<MauiCheckCheckup>(skip);
            toolSettings.SkipInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MauiCheckSettings.Skip"/></em></p>
        ///   <p>Skips a checkup by name or id as listed in maui-check list. NOTE: If there are any other checkups which depend on a skipped checkup, they will be skipped too.</p>
        /// </summary>
        [Pure]
        public static T RemoveSkip<T>(this T toolSettings, IEnumerable<MauiCheckCheckup> skip) where T : MauiCheckSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<MauiCheckCheckup>(skip);
            toolSettings.SkipInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region MauiCheckConfigSettingsExtensions
    /// <summary>
    ///   Used within <see cref="MauiCheckTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MauiCheckConfigSettingsExtensions
    {
        #region DotNetVersion
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckConfigSettings.DotNetVersion"/></em></p>
        ///   <p>Use the SDK version in the manifest in <em>global.json</em>.</p>
        /// </summary>
        [Pure]
        public static T SetDotNetVersion<T>(this T toolSettings, bool? dotNetVersion) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetVersion = dotNetVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MauiCheckConfigSettings.DotNetVersion"/></em></p>
        ///   <p>Use the SDK version in the manifest in <em>global.json</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetDotNetVersion<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetVersion = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MauiCheckConfigSettings.DotNetVersion"/></em></p>
        ///   <p>Use the SDK version in the manifest in <em>global.json</em>.</p>
        /// </summary>
        [Pure]
        public static T EnableDotNetVersion<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetVersion = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MauiCheckConfigSettings.DotNetVersion"/></em></p>
        ///   <p>Use the SDK version in the manifest in <em>global.json</em>.</p>
        /// </summary>
        [Pure]
        public static T DisableDotNetVersion<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetVersion = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MauiCheckConfigSettings.DotNetVersion"/></em></p>
        ///   <p>Use the SDK version in the manifest in <em>global.json</em>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDotNetVersion<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetVersion = !toolSettings.DotNetVersion;
            return toolSettings;
        }
        #endregion
        #region DotNetPrerelease
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></em></p>
        ///   <p>Change the <c>allowPrerelease</c> value in the <em>global.json</em>.</p>
        /// </summary>
        [Pure]
        public static T SetDotNetPrerelease<T>(this T toolSettings, bool? dotNetPrerelease) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetPrerelease = dotNetPrerelease;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></em></p>
        ///   <p>Change the <c>allowPrerelease</c> value in the <em>global.json</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetDotNetPrerelease<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetPrerelease = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></em></p>
        ///   <p>Change the <c>allowPrerelease</c> value in the <em>global.json</em>.</p>
        /// </summary>
        [Pure]
        public static T EnableDotNetPrerelease<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetPrerelease = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></em></p>
        ///   <p>Change the <c>allowPrerelease</c> value in the <em>global.json</em>.</p>
        /// </summary>
        [Pure]
        public static T DisableDotNetPrerelease<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetPrerelease = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></em></p>
        ///   <p>Change the <c>allowPrerelease</c> value in the <em>global.json</em>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDotNetPrerelease<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetPrerelease = !toolSettings.DotNetPrerelease;
            return toolSettings;
        }
        #endregion
        #region DotNetRollForward
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckConfigSettings.DotNetRollForward"/></em></p>
        ///   <p>Change the <c>rollForward</c> value in <em>global.json</em> to one of the allowed values specified.</p>
        /// </summary>
        [Pure]
        public static T SetDotNetRollForward<T>(this T toolSettings, MauiCheckDotNetRollForward dotNetRollForward) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetRollForward = dotNetRollForward;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MauiCheckConfigSettings.DotNetRollForward"/></em></p>
        ///   <p>Change the <c>rollForward</c> value in <em>global.json</em> to one of the allowed values specified.</p>
        /// </summary>
        [Pure]
        public static T ResetDotNetRollForward<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetRollForward = null;
            return toolSettings;
        }
        #endregion
        #region NuGetSources
        /// <summary>
        ///   <p><em>Sets <see cref="MauiCheckConfigSettings.NuGetSources"/></em></p>
        ///   <p>Adds the nuget sources specified in the manifest to the <em>NuGet.config</em> and creates the file if needed.</p>
        /// </summary>
        [Pure]
        public static T SetNuGetSources<T>(this T toolSettings, bool? nuGetSources) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NuGetSources = nuGetSources;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MauiCheckConfigSettings.NuGetSources"/></em></p>
        ///   <p>Adds the nuget sources specified in the manifest to the <em>NuGet.config</em> and creates the file if needed.</p>
        /// </summary>
        [Pure]
        public static T ResetNuGetSources<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NuGetSources = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MauiCheckConfigSettings.NuGetSources"/></em></p>
        ///   <p>Adds the nuget sources specified in the manifest to the <em>NuGet.config</em> and creates the file if needed.</p>
        /// </summary>
        [Pure]
        public static T EnableNuGetSources<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NuGetSources = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MauiCheckConfigSettings.NuGetSources"/></em></p>
        ///   <p>Adds the nuget sources specified in the manifest to the <em>NuGet.config</em> and creates the file if needed.</p>
        /// </summary>
        [Pure]
        public static T DisableNuGetSources<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NuGetSources = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MauiCheckConfigSettings.NuGetSources"/></em></p>
        ///   <p>Adds the nuget sources specified in the manifest to the <em>NuGet.config</em> and creates the file if needed.</p>
        /// </summary>
        [Pure]
        public static T ToggleNuGetSources<T>(this T toolSettings) where T : MauiCheckConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NuGetSources = !toolSettings.NuGetSources;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region MauiCheckDotNetRollForward
    /// <summary>
    ///   Used within <see cref="MauiCheckTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<MauiCheckDotNetRollForward>))]
    public partial class MauiCheckDotNetRollForward : Enumeration
    {
        public static MauiCheckDotNetRollForward disable = (MauiCheckDotNetRollForward) "disable";
        public static MauiCheckDotNetRollForward major = (MauiCheckDotNetRollForward) "major";
        public static MauiCheckDotNetRollForward minor = (MauiCheckDotNetRollForward) "minor";
        public static MauiCheckDotNetRollForward feature = (MauiCheckDotNetRollForward) "feature";
        public static MauiCheckDotNetRollForward patch = (MauiCheckDotNetRollForward) "patch";
        public static MauiCheckDotNetRollForward latestMajor = (MauiCheckDotNetRollForward) "latestMajor";
        public static MauiCheckDotNetRollForward latestMinor = (MauiCheckDotNetRollForward) "latestMinor";
        public static MauiCheckDotNetRollForward latestFeature = (MauiCheckDotNetRollForward) "latestFeature";
        public static MauiCheckDotNetRollForward latestPatch = (MauiCheckDotNetRollForward) "latestPatch";
        public static implicit operator MauiCheckDotNetRollForward(string value)
        {
            return new MauiCheckDotNetRollForward { Value = value };
        }
    }
    #endregion
    #region MauiCheckCheckup
    /// <summary>
    ///   Used within <see cref="MauiCheckTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<MauiCheckCheckup>))]
    public partial class MauiCheckCheckup : Enumeration
    {
        public static MauiCheckCheckup OpenJdkCheckup = (MauiCheckCheckup) "OpenJdkCheckup";
        public static MauiCheckCheckup VisualStudioMacCheckup = (MauiCheckCheckup) "VisualStudioMacCheckup";
        public static MauiCheckCheckup AndroidSdkPackagesCheckup = (MauiCheckCheckup) "AndroidSdkPackagesCheckup";
        public static MauiCheckCheckup AndroidEmulatorCheckup = (MauiCheckCheckup) "AndroidEmulatorCheckup";
        public static MauiCheckCheckup XCodeCheckup = (MauiCheckCheckup) "XCodeCheckup";
        public static MauiCheckCheckup DotNetCheckup = (MauiCheckCheckup) "DotNetCheckup";
        public static MauiCheckCheckup DotNetWorkloadDuplicatesCheckup = (MauiCheckCheckup) "DotNetWorkloadDuplicatesCheckup";
        public static MauiCheckCheckup DotNetSentinelCheckup = (MauiCheckCheckup) "DotNetSentinelCheckup";
        public static MauiCheckCheckup DotNetWorkloadsCheckup = (MauiCheckCheckup) "DotNetWorkloadsCheckup";
        public static implicit operator MauiCheckCheckup(string value)
        {
            return new MauiCheckCheckup { Value = value };
        }
    }
    #endregion
}
