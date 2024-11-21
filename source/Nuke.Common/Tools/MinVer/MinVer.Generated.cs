// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/MinVer/MinVer.json

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

namespace Nuke.Common.Tools.MinVer;

/// <summary><p>Minimalistic versioning using Git tags.</p><p>For more details, visit the <a href="https://github.com/adamralph/minver">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class MinVerTasks : ToolTasks, IRequireNuGetPackage
{
    public static string MinVerPath => new MinVerTasks().GetToolPath();
    public const string PackageId = "minver-cli";
    public const string PackageExecutable = "minver-cli.dll";
    /// <summary><p>Minimalistic versioning using Git tags.</p><p>For more details, visit the <a href="https://github.com/adamralph/minver">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> MinVer(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new MinVerTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Minimalistic versioning using Git tags.</p><p>For more details, visit the <a href="https://github.com/adamralph/minver">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--auto-increment</c> via <see cref="MinVerSettings.AutoIncrement"/></li><li><c>--build-metadata</c> via <see cref="MinVerSettings.BuildMetadata"/></li><li><c>--default-pre-release-identifiers</c> via <see cref="MinVerSettings.DefaultPreReleaseIdentifiers"/></li><li><c>--minimum-major-minor</c> via <see cref="MinVerSettings.MinimumMajorMinor"/></li><li><c>--tag-prefix</c> via <see cref="MinVerSettings.TagPrefix"/></li><li><c>--verbosity</c> via <see cref="MinVerSettings.Verbosity"/></li></ul></remarks>
    public static (MinVer Result, IReadOnlyCollection<Output> Output) MinVer(MinVerSettings options = null) => new MinVerTasks().Run<MinVer>(options);
    /// <summary><p>Minimalistic versioning using Git tags.</p><p>For more details, visit the <a href="https://github.com/adamralph/minver">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--auto-increment</c> via <see cref="MinVerSettings.AutoIncrement"/></li><li><c>--build-metadata</c> via <see cref="MinVerSettings.BuildMetadata"/></li><li><c>--default-pre-release-identifiers</c> via <see cref="MinVerSettings.DefaultPreReleaseIdentifiers"/></li><li><c>--minimum-major-minor</c> via <see cref="MinVerSettings.MinimumMajorMinor"/></li><li><c>--tag-prefix</c> via <see cref="MinVerSettings.TagPrefix"/></li><li><c>--verbosity</c> via <see cref="MinVerSettings.Verbosity"/></li></ul></remarks>
    public static (MinVer Result, IReadOnlyCollection<Output> Output) MinVer(Configure<MinVerSettings> configurator) => new MinVerTasks().Run<MinVer>(configurator.Invoke(new MinVerSettings()));
    /// <summary><p>Minimalistic versioning using Git tags.</p><p>For more details, visit the <a href="https://github.com/adamralph/minver">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--auto-increment</c> via <see cref="MinVerSettings.AutoIncrement"/></li><li><c>--build-metadata</c> via <see cref="MinVerSettings.BuildMetadata"/></li><li><c>--default-pre-release-identifiers</c> via <see cref="MinVerSettings.DefaultPreReleaseIdentifiers"/></li><li><c>--minimum-major-minor</c> via <see cref="MinVerSettings.MinimumMajorMinor"/></li><li><c>--tag-prefix</c> via <see cref="MinVerSettings.TagPrefix"/></li><li><c>--verbosity</c> via <see cref="MinVerSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(MinVerSettings Settings, MinVer Result, IReadOnlyCollection<Output> Output)> MinVer(CombinatorialConfigure<MinVerSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(MinVer, degreeOfParallelism, completeOnFailure);
}
#region MinVerSettings
/// <summary>Used within <see cref="MinVerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MinVerSettings>))]
[Command(Type = typeof(MinVerTasks), Command = nameof(MinVerTasks.MinVer))]
public partial class MinVerSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary></summary>
    [Argument(Format = "--auto-increment {value}")] public MinVerVersionPart AutoIncrement => Get<MinVerVersionPart>(() => AutoIncrement);
    /// <summary></summary>
    [Argument(Format = "--build-metadata {value}")] public string BuildMetadata => Get<string>(() => BuildMetadata);
    /// <summary></summary>
    [Argument(Format = "--default-pre-release-identifiers {value}")] public string DefaultPreReleaseIdentifiers => Get<string>(() => DefaultPreReleaseIdentifiers);
    /// <summary></summary>
    [Argument(Format = "--minimum-major-minor {value}")] public string MinimumMajorMinor => Get<string>(() => MinimumMajorMinor);
    /// <summary></summary>
    [Argument(Format = "--tag-prefix {value}")] public string TagPrefix => Get<string>(() => TagPrefix);
    /// <summary></summary>
    [Argument(Format = "--verbosity {value}")] public MinVerVerbosity Verbosity => Get<MinVerVerbosity>(() => Verbosity);
}
#endregion
#region MinVerSettingsExtensions
/// <summary>Used within <see cref="MinVerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class MinVerSettingsExtensions
{
    #region AutoIncrement
    /// <inheritdoc cref="MinVerSettings.AutoIncrement"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.AutoIncrement))]
    public static T SetAutoIncrement<T>(this T o, MinVerVersionPart v) where T : MinVerSettings => o.Modify(b => b.Set(() => o.AutoIncrement, v));
    /// <inheritdoc cref="MinVerSettings.AutoIncrement"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.AutoIncrement))]
    public static T ResetAutoIncrement<T>(this T o) where T : MinVerSettings => o.Modify(b => b.Remove(() => o.AutoIncrement));
    #endregion
    #region BuildMetadata
    /// <inheritdoc cref="MinVerSettings.BuildMetadata"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.BuildMetadata))]
    public static T SetBuildMetadata<T>(this T o, string v) where T : MinVerSettings => o.Modify(b => b.Set(() => o.BuildMetadata, v));
    /// <inheritdoc cref="MinVerSettings.BuildMetadata"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.BuildMetadata))]
    public static T ResetBuildMetadata<T>(this T o) where T : MinVerSettings => o.Modify(b => b.Remove(() => o.BuildMetadata));
    #endregion
    #region DefaultPreReleaseIdentifiers
    /// <inheritdoc cref="MinVerSettings.DefaultPreReleaseIdentifiers"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.DefaultPreReleaseIdentifiers))]
    public static T SetDefaultPreReleaseIdentifiers<T>(this T o, string v) where T : MinVerSettings => o.Modify(b => b.Set(() => o.DefaultPreReleaseIdentifiers, v));
    /// <inheritdoc cref="MinVerSettings.DefaultPreReleaseIdentifiers"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.DefaultPreReleaseIdentifiers))]
    public static T ResetDefaultPreReleaseIdentifiers<T>(this T o) where T : MinVerSettings => o.Modify(b => b.Remove(() => o.DefaultPreReleaseIdentifiers));
    #endregion
    #region MinimumMajorMinor
    /// <inheritdoc cref="MinVerSettings.MinimumMajorMinor"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.MinimumMajorMinor))]
    public static T SetMinimumMajorMinor<T>(this T o, string v) where T : MinVerSettings => o.Modify(b => b.Set(() => o.MinimumMajorMinor, v));
    /// <inheritdoc cref="MinVerSettings.MinimumMajorMinor"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.MinimumMajorMinor))]
    public static T ResetMinimumMajorMinor<T>(this T o) where T : MinVerSettings => o.Modify(b => b.Remove(() => o.MinimumMajorMinor));
    #endregion
    #region TagPrefix
    /// <inheritdoc cref="MinVerSettings.TagPrefix"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.TagPrefix))]
    public static T SetTagPrefix<T>(this T o, string v) where T : MinVerSettings => o.Modify(b => b.Set(() => o.TagPrefix, v));
    /// <inheritdoc cref="MinVerSettings.TagPrefix"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.TagPrefix))]
    public static T ResetTagPrefix<T>(this T o) where T : MinVerSettings => o.Modify(b => b.Remove(() => o.TagPrefix));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="MinVerSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, MinVerVerbosity v) where T : MinVerSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="MinVerSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(MinVerSettings), Property = nameof(MinVerSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : MinVerSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
}
#endregion
#region MinVerVerbosity
/// <summary>Used within <see cref="MinVerTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MinVerVerbosity>))]
public partial class MinVerVerbosity : Enumeration
{
    public static MinVerVerbosity Error = (MinVerVerbosity) "Error";
    public static MinVerVerbosity Warn = (MinVerVerbosity) "Warn";
    public static MinVerVerbosity Info = (MinVerVerbosity) "Info";
    public static MinVerVerbosity Debug = (MinVerVerbosity) "Debug";
    public static MinVerVerbosity Trace = (MinVerVerbosity) "Trace";
    public static implicit operator MinVerVerbosity(string value)
    {
        return new MinVerVerbosity { Value = value };
    }
}
#endregion
#region MinVerVersionPart
/// <summary>Used within <see cref="MinVerTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MinVerVersionPart>))]
public partial class MinVerVersionPart : Enumeration
{
    public static MinVerVersionPart Major = (MinVerVersionPart) "Major";
    public static MinVerVersionPart Minor = (MinVerVersionPart) "Minor";
    public static MinVerVersionPart Patch = (MinVerVersionPart) "Patch";
    public static implicit operator MinVerVersionPart(string value)
    {
        return new MinVerVersionPart { Value = value };
    }
}
#endregion
