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

namespace Nuke.Common.Tools.MauiCheck;

/// <summary><p>A dotnet tool for helping set up your .NET MAUI environment.</p><p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class MauiCheckTasks : ToolTasks, IRequireNuGetPackage
{
    public static string MauiCheckPath => new MauiCheckTasks().GetToolPath();
    public const string PackageId = "Redth.Net.Maui.Check";
    public const string PackageExecutable = "MauiCheck.dll";
    /// <summary><p>A dotnet tool for helping set up your .NET MAUI environment.</p><p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> MauiCheck(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new MauiCheckTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>A dotnet tool for helping set up your .NET MAUI environment.</p><p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--ci</c> via <see cref="MauiCheckSettings.Ci"/></li><li><c>--fix</c> via <see cref="MauiCheckSettings.Fix"/></li><li><c>--manifest</c> via <see cref="MauiCheckSettings.Manifest"/></li><li><c>--non-interactive</c> via <see cref="MauiCheckSettings.NonInteractive"/></li><li><c>--preview</c> via <see cref="MauiCheckSettings.Preview"/></li><li><c>--skip</c> via <see cref="MauiCheckSettings.Skip"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> MauiCheck(MauiCheckSettings options = null) => new MauiCheckTasks().Run(options);
    /// <summary><p>A dotnet tool for helping set up your .NET MAUI environment.</p><p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--ci</c> via <see cref="MauiCheckSettings.Ci"/></li><li><c>--fix</c> via <see cref="MauiCheckSettings.Fix"/></li><li><c>--manifest</c> via <see cref="MauiCheckSettings.Manifest"/></li><li><c>--non-interactive</c> via <see cref="MauiCheckSettings.NonInteractive"/></li><li><c>--preview</c> via <see cref="MauiCheckSettings.Preview"/></li><li><c>--skip</c> via <see cref="MauiCheckSettings.Skip"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> MauiCheck(Configure<MauiCheckSettings> configurator) => new MauiCheckTasks().Run(configurator.Invoke(new MauiCheckSettings()));
    /// <summary><p>A dotnet tool for helping set up your .NET MAUI environment.</p><p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--ci</c> via <see cref="MauiCheckSettings.Ci"/></li><li><c>--fix</c> via <see cref="MauiCheckSettings.Fix"/></li><li><c>--manifest</c> via <see cref="MauiCheckSettings.Manifest"/></li><li><c>--non-interactive</c> via <see cref="MauiCheckSettings.NonInteractive"/></li><li><c>--preview</c> via <see cref="MauiCheckSettings.Preview"/></li><li><c>--skip</c> via <see cref="MauiCheckSettings.Skip"/></li></ul></remarks>
    public static IEnumerable<(MauiCheckSettings Settings, IReadOnlyCollection<Output> Output)> MauiCheck(CombinatorialConfigure<MauiCheckSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(MauiCheck, degreeOfParallelism, completeOnFailure);
    /// <summary><p>A dotnet tool for helping set up your .NET MAUI environment.</p><p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--dotnet-pre</c> via <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></li><li><c>--dotnet-rollForward</c> via <see cref="MauiCheckConfigSettings.DotNetRollForward"/></li><li><c>--dotnet-version</c> via <see cref="MauiCheckConfigSettings.DotNetVersion"/></li><li><c>--nuget-sources</c> via <see cref="MauiCheckConfigSettings.NuGetSources"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> MauiCheckConfig(MauiCheckConfigSettings options = null) => new MauiCheckTasks().Run(options);
    /// <summary><p>A dotnet tool for helping set up your .NET MAUI environment.</p><p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--dotnet-pre</c> via <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></li><li><c>--dotnet-rollForward</c> via <see cref="MauiCheckConfigSettings.DotNetRollForward"/></li><li><c>--dotnet-version</c> via <see cref="MauiCheckConfigSettings.DotNetVersion"/></li><li><c>--nuget-sources</c> via <see cref="MauiCheckConfigSettings.NuGetSources"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> MauiCheckConfig(Configure<MauiCheckConfigSettings> configurator) => new MauiCheckTasks().Run(configurator.Invoke(new MauiCheckConfigSettings()));
    /// <summary><p>A dotnet tool for helping set up your .NET MAUI environment.</p><p>For more details, visit the <a href="https://github.com/Redth/dotnet-maui-check">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--dotnet-pre</c> via <see cref="MauiCheckConfigSettings.DotNetPrerelease"/></li><li><c>--dotnet-rollForward</c> via <see cref="MauiCheckConfigSettings.DotNetRollForward"/></li><li><c>--dotnet-version</c> via <see cref="MauiCheckConfigSettings.DotNetVersion"/></li><li><c>--nuget-sources</c> via <see cref="MauiCheckConfigSettings.NuGetSources"/></li></ul></remarks>
    public static IEnumerable<(MauiCheckConfigSettings Settings, IReadOnlyCollection<Output> Output)> MauiCheckConfig(CombinatorialConfigure<MauiCheckConfigSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(MauiCheckConfig, degreeOfParallelism, completeOnFailure);
}
#region MauiCheckSettings
/// <summary>Used within <see cref="MauiCheckTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MauiCheckSettings>))]
[Command(Type = typeof(MauiCheckTasks), Command = nameof(MauiCheckTasks.MauiCheck))]
public partial class MauiCheckSettings : ToolOptions
{
    /// <summary>Manifest files are currently used by the doctor to fetch the latest versions and requirements. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest">https://aka.ms/dotnet-maui-check-manifest</a>. Use this option to specify an alternative file path or URL to use.</summary>
    [Argument(Format = "--manifest {value}")] public string Manifest => Get<string>(() => Manifest);
    /// <summary>You can try using the <c>--fix</c> argument to automatically enable solutions to run without being prompted.</summary>
    [Argument(Format = "--fix")] public bool? Fix => Get<bool?>(() => Fix);
    /// <summary>If you're running on CI you may want to run without any required input with the <c>--non-interactive</c> argument. You can combine this with <c>--fix</c> to automatically fix without prompting.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>This uses a more frequently updated manifest with newer versions of things more often. The manifest is hosted by default at: <a href="https://aka.ms/dotnet-maui-check-manifest-dev">https://aka.ms/dotnet-maui-check-manifest-dev</a></summary>
    [Argument(Format = "--preview")] public bool? Preview => Get<bool?>(() => Preview);
    /// <summary>Uses the <c>dotnet-install</c> powershell / bash scripts for installing the dotnet SDK version from the manifest instead of the global installer.</summary>
    [Argument(Format = "--ci")] public bool? Ci => Get<bool?>(() => Ci);
    /// <summary>Skips a checkup by name or id as listed in maui-check list. NOTE: If there are any other checkups which depend on a skipped checkup, they will be skipped too.</summary>
    [Argument(Format = "--skip {value}")] public IReadOnlyList<MauiCheckCheckup> Skip => Get<List<MauiCheckCheckup>>(() => Skip);
}
#endregion
#region MauiCheckConfigSettings
/// <summary>Used within <see cref="MauiCheckTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MauiCheckConfigSettings>))]
[Command(Type = typeof(MauiCheckTasks), Command = nameof(MauiCheckTasks.MauiCheckConfig), Arguments = "config")]
public partial class MauiCheckConfigSettings : ToolOptions
{
    /// <summary>Use the SDK version in the manifest in <em>global.json</em>.</summary>
    [Argument(Format = "--dotnet-version")] public bool? DotNetVersion => Get<bool?>(() => DotNetVersion);
    /// <summary>Change the <c>allowPrerelease</c> value in the <em>global.json</em>.</summary>
    [Argument(Format = "--dotnet-pre {value}")] public bool? DotNetPrerelease => Get<bool?>(() => DotNetPrerelease);
    /// <summary>Change the <c>rollForward</c> value in <em>global.json</em> to one of the allowed values specified.</summary>
    [Argument(Format = "--dotnet-rollForward {value}")] public MauiCheckDotNetRollForward DotNetRollForward => Get<MauiCheckDotNetRollForward>(() => DotNetRollForward);
    /// <summary>Adds the nuget sources specified in the manifest to the <em>NuGet.config</em> and creates the file if needed.</summary>
    [Argument(Format = "--nuget-sources")] public bool? NuGetSources => Get<bool?>(() => NuGetSources);
}
#endregion
#region MauiCheckSettingsExtensions
/// <summary>Used within <see cref="MauiCheckTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class MauiCheckSettingsExtensions
{
    #region Manifest
    /// <inheritdoc cref="MauiCheckSettings.Manifest"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Manifest))]
    public static T SetManifest<T>(this T o, string v) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Manifest, v));
    /// <inheritdoc cref="MauiCheckSettings.Manifest"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Manifest))]
    public static T ResetManifest<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Remove(() => o.Manifest));
    #endregion
    #region Fix
    /// <inheritdoc cref="MauiCheckSettings.Fix"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Fix))]
    public static T SetFix<T>(this T o, bool? v) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Fix, v));
    /// <inheritdoc cref="MauiCheckSettings.Fix"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Fix))]
    public static T ResetFix<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Remove(() => o.Fix));
    /// <inheritdoc cref="MauiCheckSettings.Fix"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Fix))]
    public static T EnableFix<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Fix, true));
    /// <inheritdoc cref="MauiCheckSettings.Fix"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Fix))]
    public static T DisableFix<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Fix, false));
    /// <inheritdoc cref="MauiCheckSettings.Fix"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Fix))]
    public static T ToggleFix<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Fix, !o.Fix));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="MauiCheckSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="MauiCheckSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="MauiCheckSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="MauiCheckSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="MauiCheckSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Preview
    /// <inheritdoc cref="MauiCheckSettings.Preview"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Preview))]
    public static T SetPreview<T>(this T o, bool? v) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Preview, v));
    /// <inheritdoc cref="MauiCheckSettings.Preview"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Preview))]
    public static T ResetPreview<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Remove(() => o.Preview));
    /// <inheritdoc cref="MauiCheckSettings.Preview"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Preview))]
    public static T EnablePreview<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Preview, true));
    /// <inheritdoc cref="MauiCheckSettings.Preview"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Preview))]
    public static T DisablePreview<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Preview, false));
    /// <inheritdoc cref="MauiCheckSettings.Preview"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Preview))]
    public static T TogglePreview<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Preview, !o.Preview));
    #endregion
    #region Ci
    /// <inheritdoc cref="MauiCheckSettings.Ci"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Ci))]
    public static T SetCi<T>(this T o, bool? v) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Ci, v));
    /// <inheritdoc cref="MauiCheckSettings.Ci"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Ci))]
    public static T ResetCi<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Remove(() => o.Ci));
    /// <inheritdoc cref="MauiCheckSettings.Ci"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Ci))]
    public static T EnableCi<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Ci, true));
    /// <inheritdoc cref="MauiCheckSettings.Ci"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Ci))]
    public static T DisableCi<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Ci, false));
    /// <inheritdoc cref="MauiCheckSettings.Ci"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Ci))]
    public static T ToggleCi<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Ci, !o.Ci));
    #endregion
    #region Skip
    /// <inheritdoc cref="MauiCheckSettings.Skip"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Skip))]
    public static T SetSkip<T>(this T o, params MauiCheckCheckup[] v) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Skip, v));
    /// <inheritdoc cref="MauiCheckSettings.Skip"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Skip))]
    public static T SetSkip<T>(this T o, IEnumerable<MauiCheckCheckup> v) where T : MauiCheckSettings => o.Modify(b => b.Set(() => o.Skip, v));
    /// <inheritdoc cref="MauiCheckSettings.Skip"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Skip))]
    public static T AddSkip<T>(this T o, params MauiCheckCheckup[] v) where T : MauiCheckSettings => o.Modify(b => b.AddCollection(() => o.Skip, v));
    /// <inheritdoc cref="MauiCheckSettings.Skip"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Skip))]
    public static T AddSkip<T>(this T o, IEnumerable<MauiCheckCheckup> v) where T : MauiCheckSettings => o.Modify(b => b.AddCollection(() => o.Skip, v));
    /// <inheritdoc cref="MauiCheckSettings.Skip"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Skip))]
    public static T RemoveSkip<T>(this T o, params MauiCheckCheckup[] v) where T : MauiCheckSettings => o.Modify(b => b.RemoveCollection(() => o.Skip, v));
    /// <inheritdoc cref="MauiCheckSettings.Skip"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Skip))]
    public static T RemoveSkip<T>(this T o, IEnumerable<MauiCheckCheckup> v) where T : MauiCheckSettings => o.Modify(b => b.RemoveCollection(() => o.Skip, v));
    /// <inheritdoc cref="MauiCheckSettings.Skip"/>
    [Pure] [Builder(Type = typeof(MauiCheckSettings), Property = nameof(MauiCheckSettings.Skip))]
    public static T ClearSkip<T>(this T o) where T : MauiCheckSettings => o.Modify(b => b.ClearCollection(() => o.Skip));
    #endregion
}
#endregion
#region MauiCheckConfigSettingsExtensions
/// <summary>Used within <see cref="MauiCheckTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class MauiCheckConfigSettingsExtensions
{
    #region DotNetVersion
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetVersion"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetVersion))]
    public static T SetDotNetVersion<T>(this T o, bool? v) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.DotNetVersion, v));
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetVersion"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetVersion))]
    public static T ResetDotNetVersion<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Remove(() => o.DotNetVersion));
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetVersion"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetVersion))]
    public static T EnableDotNetVersion<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.DotNetVersion, true));
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetVersion"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetVersion))]
    public static T DisableDotNetVersion<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.DotNetVersion, false));
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetVersion"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetVersion))]
    public static T ToggleDotNetVersion<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.DotNetVersion, !o.DotNetVersion));
    #endregion
    #region DotNetPrerelease
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetPrerelease"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetPrerelease))]
    public static T SetDotNetPrerelease<T>(this T o, bool? v) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.DotNetPrerelease, v));
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetPrerelease"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetPrerelease))]
    public static T ResetDotNetPrerelease<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Remove(() => o.DotNetPrerelease));
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetPrerelease"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetPrerelease))]
    public static T EnableDotNetPrerelease<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.DotNetPrerelease, true));
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetPrerelease"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetPrerelease))]
    public static T DisableDotNetPrerelease<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.DotNetPrerelease, false));
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetPrerelease"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetPrerelease))]
    public static T ToggleDotNetPrerelease<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.DotNetPrerelease, !o.DotNetPrerelease));
    #endregion
    #region DotNetRollForward
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetRollForward"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetRollForward))]
    public static T SetDotNetRollForward<T>(this T o, MauiCheckDotNetRollForward v) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.DotNetRollForward, v));
    /// <inheritdoc cref="MauiCheckConfigSettings.DotNetRollForward"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.DotNetRollForward))]
    public static T ResetDotNetRollForward<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Remove(() => o.DotNetRollForward));
    #endregion
    #region NuGetSources
    /// <inheritdoc cref="MauiCheckConfigSettings.NuGetSources"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.NuGetSources))]
    public static T SetNuGetSources<T>(this T o, bool? v) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.NuGetSources, v));
    /// <inheritdoc cref="MauiCheckConfigSettings.NuGetSources"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.NuGetSources))]
    public static T ResetNuGetSources<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Remove(() => o.NuGetSources));
    /// <inheritdoc cref="MauiCheckConfigSettings.NuGetSources"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.NuGetSources))]
    public static T EnableNuGetSources<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.NuGetSources, true));
    /// <inheritdoc cref="MauiCheckConfigSettings.NuGetSources"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.NuGetSources))]
    public static T DisableNuGetSources<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.NuGetSources, false));
    /// <inheritdoc cref="MauiCheckConfigSettings.NuGetSources"/>
    [Pure] [Builder(Type = typeof(MauiCheckConfigSettings), Property = nameof(MauiCheckConfigSettings.NuGetSources))]
    public static T ToggleNuGetSources<T>(this T o) where T : MauiCheckConfigSettings => o.Modify(b => b.Set(() => o.NuGetSources, !o.NuGetSources));
    #endregion
}
#endregion
#region MauiCheckDotNetRollForward
/// <summary>Used within <see cref="MauiCheckTasks"/>.</summary>
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
/// <summary>Used within <see cref="MauiCheckTasks"/>.</summary>
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
