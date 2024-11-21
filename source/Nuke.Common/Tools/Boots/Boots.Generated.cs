// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Boots/Boots.json

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

namespace Nuke.Common.Tools.Boots;

/// <summary><p>boots is a .NET global tool for <c>bootstrapping</c> <c>vsix</c> and <c>pkg</c> files.</p><p>For more details, visit the <a href="https://github.com/jonathanpeppers/boots">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class BootsTasks : ToolTasks, IRequireNuGetPackage
{
    public static string BootsPath => new BootsTasks().GetToolPath();
    public const string PackageId = "Boots";
    public const string PackageExecutable = "Boots.exe";
    /// <summary><p>boots is a .NET global tool for <c>bootstrapping</c> <c>vsix</c> and <c>pkg</c> files.</p><p>For more details, visit the <a href="https://github.com/jonathanpeppers/boots">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Boots(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new BootsTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>boots is a .NET global tool for <c>bootstrapping</c> <c>vsix</c> and <c>pkg</c> files.</p><p>For more details, visit the <a href="https://github.com/jonathanpeppers/boots">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--file-type</c> via <see cref="BootsSettings.FileType"/></li><li><c>--preview</c> via <see cref="BootsSettings.Preview"/></li><li><c>--read-write-timeout</c> via <see cref="BootsSettings.ReadWriteTimeout"/></li><li><c>--retries</c> via <see cref="BootsSettings.Retries"/></li><li><c>--stable</c> via <see cref="BootsSettings.Stable"/></li><li><c>--timeout</c> via <see cref="BootsSettings.Timeout"/></li><li><c>--url</c> via <see cref="BootsSettings.Url"/></li><li><c>--version</c> via <see cref="BootsSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Boots(BootsSettings options = null) => new BootsTasks().Run(options);
    /// <summary><p>boots is a .NET global tool for <c>bootstrapping</c> <c>vsix</c> and <c>pkg</c> files.</p><p>For more details, visit the <a href="https://github.com/jonathanpeppers/boots">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--file-type</c> via <see cref="BootsSettings.FileType"/></li><li><c>--preview</c> via <see cref="BootsSettings.Preview"/></li><li><c>--read-write-timeout</c> via <see cref="BootsSettings.ReadWriteTimeout"/></li><li><c>--retries</c> via <see cref="BootsSettings.Retries"/></li><li><c>--stable</c> via <see cref="BootsSettings.Stable"/></li><li><c>--timeout</c> via <see cref="BootsSettings.Timeout"/></li><li><c>--url</c> via <see cref="BootsSettings.Url"/></li><li><c>--version</c> via <see cref="BootsSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Boots(Configure<BootsSettings> configurator) => new BootsTasks().Run(configurator.Invoke(new BootsSettings()));
    /// <summary><p>boots is a .NET global tool for <c>bootstrapping</c> <c>vsix</c> and <c>pkg</c> files.</p><p>For more details, visit the <a href="https://github.com/jonathanpeppers/boots">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--file-type</c> via <see cref="BootsSettings.FileType"/></li><li><c>--preview</c> via <see cref="BootsSettings.Preview"/></li><li><c>--read-write-timeout</c> via <see cref="BootsSettings.ReadWriteTimeout"/></li><li><c>--retries</c> via <see cref="BootsSettings.Retries"/></li><li><c>--stable</c> via <see cref="BootsSettings.Stable"/></li><li><c>--timeout</c> via <see cref="BootsSettings.Timeout"/></li><li><c>--url</c> via <see cref="BootsSettings.Url"/></li><li><c>--version</c> via <see cref="BootsSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(BootsSettings Settings, IReadOnlyCollection<Output> Output)> Boots(CombinatorialConfigure<BootsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(Boots, degreeOfParallelism, completeOnFailure);
}
#region BootsSettings
/// <summary>Used within <see cref="BootsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<BootsSettings>))]
[Command(Type = typeof(BootsTasks), Command = nameof(BootsTasks.Boots))]
public partial class BootsSettings : ToolOptions
{
    /// <summary>Install the latest <em>stable</em> version of a product from VS manifests. Options include: <c>Xamarin.Android</c>, <c>Xamarin.iOS</c>, <c>Xamarin.Mac</c>, and <c>Mono</c></summary>
    [Argument(Format = "--stable {value}")] public BootsProductType Stable => Get<BootsProductType>(() => Stable);
    /// <summary>Install the latest <em>preview</em> version of a product from VS manifests. Options include: <c>Xamarin.Android</c>, <c>Xamarin.iOS</c>, <c>Xamarin.Mac</c>, and <c>Mono</c></summary>
    [Argument(Format = "--preview {value}")] public BootsProductType Preview => Get<BootsProductType>(() => Preview);
    /// <summary>A Url to a <c>pkg</c> or <c>vsix</c> file to install</summary>
    [Argument(Format = "--url {value}")] public string Url => Get<string>(() => Url);
    /// <summary>Specifies the type of file to be installed such as <c>vsix</c>, <c>pkg</c>, or <c>msi</c>. Defaults to <c>vsix</c> on Windows and <c>pkg</c> on macOS</summary>
    [Argument(Format = "--file-type {value}")] public BootsFileType FileType => Get<BootsFileType>(() => FileType);
    /// <summary>Specifies a timeout for <c>HttpClient</c>. If omitted, uses the .NET default of 100 seconds</summary>
    [Argument(Format = "--timeout {value}")] public int? Timeout => Get<int?>(() => Timeout);
    /// <summary>Specifies a timeout for reading/writing from a <c>HttpClient</c> stream. If omitted, uses a default of 300 seconds</summary>
    [Argument(Format = "--read-write-timeout {value}")] public int? ReadWriteTimeout => Get<int?>(() => ReadWriteTimeout);
    /// <summary>Specifies a number of retries for <c>HttpClient</c> failures. If omitted, uses a default of 3 retries</summary>
    [Argument(Format = "--retries {value}")] public int? Retries => Get<int?>(() => Retries);
    /// <summary>Show version information</summary>
    [Argument(Format = "--version")] public bool? Version => Get<bool?>(() => Version);
}
#endregion
#region BootsSettingsExtensions
/// <summary>Used within <see cref="BootsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class BootsSettingsExtensions
{
    #region Stable
    /// <inheritdoc cref="BootsSettings.Stable"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Stable))]
    public static T SetStable<T>(this T o, BootsProductType v) where T : BootsSettings => o.Modify(b => b.Set(() => o.Stable, v));
    /// <inheritdoc cref="BootsSettings.Stable"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Stable))]
    public static T ResetStable<T>(this T o) where T : BootsSettings => o.Modify(b => b.Remove(() => o.Stable));
    #endregion
    #region Preview
    /// <inheritdoc cref="BootsSettings.Preview"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Preview))]
    public static T SetPreview<T>(this T o, BootsProductType v) where T : BootsSettings => o.Modify(b => b.Set(() => o.Preview, v));
    /// <inheritdoc cref="BootsSettings.Preview"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Preview))]
    public static T ResetPreview<T>(this T o) where T : BootsSettings => o.Modify(b => b.Remove(() => o.Preview));
    #endregion
    #region Url
    /// <inheritdoc cref="BootsSettings.Url"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Url))]
    public static T SetUrl<T>(this T o, string v) where T : BootsSettings => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="BootsSettings.Url"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Url))]
    public static T ResetUrl<T>(this T o) where T : BootsSettings => o.Modify(b => b.Remove(() => o.Url));
    #endregion
    #region FileType
    /// <inheritdoc cref="BootsSettings.FileType"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.FileType))]
    public static T SetFileType<T>(this T o, BootsFileType v) where T : BootsSettings => o.Modify(b => b.Set(() => o.FileType, v));
    /// <inheritdoc cref="BootsSettings.FileType"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.FileType))]
    public static T ResetFileType<T>(this T o) where T : BootsSettings => o.Modify(b => b.Remove(() => o.FileType));
    #endregion
    #region Timeout
    /// <inheritdoc cref="BootsSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Timeout))]
    public static T SetTimeout<T>(this T o, int? v) where T : BootsSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="BootsSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : BootsSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region ReadWriteTimeout
    /// <inheritdoc cref="BootsSettings.ReadWriteTimeout"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.ReadWriteTimeout))]
    public static T SetReadWriteTimeout<T>(this T o, int? v) where T : BootsSettings => o.Modify(b => b.Set(() => o.ReadWriteTimeout, v));
    /// <inheritdoc cref="BootsSettings.ReadWriteTimeout"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.ReadWriteTimeout))]
    public static T ResetReadWriteTimeout<T>(this T o) where T : BootsSettings => o.Modify(b => b.Remove(() => o.ReadWriteTimeout));
    #endregion
    #region Retries
    /// <inheritdoc cref="BootsSettings.Retries"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Retries))]
    public static T SetRetries<T>(this T o, int? v) where T : BootsSettings => o.Modify(b => b.Set(() => o.Retries, v));
    /// <inheritdoc cref="BootsSettings.Retries"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Retries))]
    public static T ResetRetries<T>(this T o) where T : BootsSettings => o.Modify(b => b.Remove(() => o.Retries));
    #endregion
    #region Version
    /// <inheritdoc cref="BootsSettings.Version"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Version))]
    public static T SetVersion<T>(this T o, bool? v) where T : BootsSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="BootsSettings.Version"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : BootsSettings => o.Modify(b => b.Remove(() => o.Version));
    /// <inheritdoc cref="BootsSettings.Version"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Version))]
    public static T EnableVersion<T>(this T o) where T : BootsSettings => o.Modify(b => b.Set(() => o.Version, true));
    /// <inheritdoc cref="BootsSettings.Version"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Version))]
    public static T DisableVersion<T>(this T o) where T : BootsSettings => o.Modify(b => b.Set(() => o.Version, false));
    /// <inheritdoc cref="BootsSettings.Version"/>
    [Pure] [Builder(Type = typeof(BootsSettings), Property = nameof(BootsSettings.Version))]
    public static T ToggleVersion<T>(this T o) where T : BootsSettings => o.Modify(b => b.Set(() => o.Version, !o.Version));
    #endregion
}
#endregion
#region BootsProductType
/// <summary>Used within <see cref="BootsTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<BootsProductType>))]
public partial class BootsProductType : Enumeration
{
    public static BootsProductType Mono = (BootsProductType) "Mono";
    public static BootsProductType Xamarin_Android = (BootsProductType) "Xamarin.Android";
    public static BootsProductType Xamarin_iOS = (BootsProductType) "Xamarin.iOS";
    public static BootsProductType Xamarin_Mac = (BootsProductType) "Xamarin.Mac";
    public static implicit operator BootsProductType(string value)
    {
        return new BootsProductType { Value = value };
    }
}
#endregion
#region BootsFileType
/// <summary>Used within <see cref="BootsTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<BootsFileType>))]
public partial class BootsFileType : Enumeration
{
    public static BootsFileType vsix = (BootsFileType) "vsix";
    public static BootsFileType pkg = (BootsFileType) "pkg";
    public static BootsFileType msi = (BootsFileType) "msi";
    public static implicit operator BootsFileType(string value)
    {
        return new BootsFileType { Value = value };
    }
}
#endregion
