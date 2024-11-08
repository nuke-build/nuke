// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/DotnetPackaging/DotnetPackaging.json

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

namespace Nuke.Common.Tools.DotnetPackaging;

/// <summary><p>DotnetPackaging is able to package your application into various formats, including Deb and AppImage.</p><p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class DotnetPackagingTasks : ToolTasks, IRequireNuGetPackage
{
    public static string DotnetPackagingPath => new DotnetPackagingTasks().GetToolPath();
    public const string PackageId = "DotnetPackaging.Console";
    public const string PackageExecutable = "DotnetPackaging.Console.dll";
    /// <summary><p>DotnetPackaging is able to package your application into various formats, including Deb and AppImage.</p><p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> DotnetPackaging(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new DotnetPackagingTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Creates a Debian package from the specified directory.</p><p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--directory</c> via <see cref="DotnetPackagingDebSettings.Directory"/></li><li><c>--metadata</c> via <see cref="DotnetPackagingDebSettings.Metadata"/></li><li><c>--output</c> via <see cref="DotnetPackagingDebSettings.Output"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotnetPackagingDeb(DotnetPackagingDebSettings options = null) => new DotnetPackagingTasks().Run(options);
    /// <summary><p>Creates a Debian package from the specified directory.</p><p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--directory</c> via <see cref="DotnetPackagingDebSettings.Directory"/></li><li><c>--metadata</c> via <see cref="DotnetPackagingDebSettings.Metadata"/></li><li><c>--output</c> via <see cref="DotnetPackagingDebSettings.Output"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotnetPackagingDeb(Configure<DotnetPackagingDebSettings> configurator) => new DotnetPackagingTasks().Run(configurator.Invoke(new DotnetPackagingDebSettings()));
    /// <summary><p>Creates a Debian package from the specified directory.</p><p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--directory</c> via <see cref="DotnetPackagingDebSettings.Directory"/></li><li><c>--metadata</c> via <see cref="DotnetPackagingDebSettings.Metadata"/></li><li><c>--output</c> via <see cref="DotnetPackagingDebSettings.Output"/></li></ul></remarks>
    public static IEnumerable<(DotnetPackagingDebSettings Settings, IReadOnlyCollection<Output> Output)> DotnetPackagingDeb(CombinatorialConfigure<DotnetPackagingDebSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DotnetPackagingDeb, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Creates an AppImage package.</p><p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--additional-categories</c> via <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></li><li><c>--appId</c> via <see cref="DotnetPackagingAppImageSettings.AppId"/></li><li><c>--application-name</c> via <see cref="DotnetPackagingAppImageSettings.ApplicationName"/></li><li><c>--directory</c> via <see cref="DotnetPackagingAppImageSettings.Directory"/></li><li><c>--homepage</c> via <see cref="DotnetPackagingAppImageSettings.Homepage"/></li><li><c>--icon</c> via <see cref="DotnetPackagingAppImageSettings.Icon"/></li><li><c>--license</c> via <see cref="DotnetPackagingAppImageSettings.License"/></li><li><c>--main-category</c> via <see cref="DotnetPackagingAppImageSettings.MainCategory"/></li><li><c>--output</c> via <see cref="DotnetPackagingAppImageSettings.Output"/></li><li><c>--screenshot-urls</c> via <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></li><li><c>--summary</c> via <see cref="DotnetPackagingAppImageSettings.Summary"/></li><li><c>--version</c> via <see cref="DotnetPackagingAppImageSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotnetPackagingAppImage(DotnetPackagingAppImageSettings options = null) => new DotnetPackagingTasks().Run(options);
    /// <summary><p>Creates an AppImage package.</p><p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--additional-categories</c> via <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></li><li><c>--appId</c> via <see cref="DotnetPackagingAppImageSettings.AppId"/></li><li><c>--application-name</c> via <see cref="DotnetPackagingAppImageSettings.ApplicationName"/></li><li><c>--directory</c> via <see cref="DotnetPackagingAppImageSettings.Directory"/></li><li><c>--homepage</c> via <see cref="DotnetPackagingAppImageSettings.Homepage"/></li><li><c>--icon</c> via <see cref="DotnetPackagingAppImageSettings.Icon"/></li><li><c>--license</c> via <see cref="DotnetPackagingAppImageSettings.License"/></li><li><c>--main-category</c> via <see cref="DotnetPackagingAppImageSettings.MainCategory"/></li><li><c>--output</c> via <see cref="DotnetPackagingAppImageSettings.Output"/></li><li><c>--screenshot-urls</c> via <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></li><li><c>--summary</c> via <see cref="DotnetPackagingAppImageSettings.Summary"/></li><li><c>--version</c> via <see cref="DotnetPackagingAppImageSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DotnetPackagingAppImage(Configure<DotnetPackagingAppImageSettings> configurator) => new DotnetPackagingTasks().Run(configurator.Invoke(new DotnetPackagingAppImageSettings()));
    /// <summary><p>Creates an AppImage package.</p><p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--additional-categories</c> via <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></li><li><c>--appId</c> via <see cref="DotnetPackagingAppImageSettings.AppId"/></li><li><c>--application-name</c> via <see cref="DotnetPackagingAppImageSettings.ApplicationName"/></li><li><c>--directory</c> via <see cref="DotnetPackagingAppImageSettings.Directory"/></li><li><c>--homepage</c> via <see cref="DotnetPackagingAppImageSettings.Homepage"/></li><li><c>--icon</c> via <see cref="DotnetPackagingAppImageSettings.Icon"/></li><li><c>--license</c> via <see cref="DotnetPackagingAppImageSettings.License"/></li><li><c>--main-category</c> via <see cref="DotnetPackagingAppImageSettings.MainCategory"/></li><li><c>--output</c> via <see cref="DotnetPackagingAppImageSettings.Output"/></li><li><c>--screenshot-urls</c> via <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></li><li><c>--summary</c> via <see cref="DotnetPackagingAppImageSettings.Summary"/></li><li><c>--version</c> via <see cref="DotnetPackagingAppImageSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(DotnetPackagingAppImageSettings Settings, IReadOnlyCollection<Output> Output)> DotnetPackagingAppImage(CombinatorialConfigure<DotnetPackagingAppImageSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DotnetPackagingAppImage, degreeOfParallelism, completeOnFailure);
}
#region DotnetPackagingDebSettings
/// <summary>Used within <see cref="DotnetPackagingTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotnetPackagingDebSettings>))]
[Command(Type = typeof(DotnetPackagingTasks), Command = nameof(DotnetPackagingTasks.DotnetPackagingDeb), Arguments = "deb")]
public partial class DotnetPackagingDebSettings : ToolOptions
{
    /// <summary>The input directory from which to create the package.</summary>
    [Argument(Format = "--directory={value}")] public string Directory => Get<string>(() => Directory);
    /// <summary>The metadata file to include in the package.</summary>
    [Argument(Format = "--metadata={value}")] public string Metadata => Get<string>(() => Metadata);
    /// <summary>The output DEB file to create.</summary>
    [Argument(Format = "--output={value}")] public string Output => Get<string>(() => Output);
}
#endregion
#region DotnetPackagingAppImageSettings
/// <summary>Used within <see cref="DotnetPackagingTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotnetPackagingAppImageSettings>))]
[Command(Type = typeof(DotnetPackagingTasks), Command = nameof(DotnetPackagingTasks.DotnetPackagingAppImage), Arguments = "appimage")]
public partial class DotnetPackagingAppImageSettings : ToolOptions
{
    /// <summary>The input directory from which to create the AppImage.</summary>
    [Argument(Format = "--directory={value}")] public string Directory => Get<string>(() => Directory);
    /// <summary>The output AppImage file to create.</summary>
    [Argument(Format = "--output={value}")] public string Output => Get<string>(() => Output);
    /// <summary>The name of the application for the AppImage.</summary>
    [Argument(Format = "--application-name={value}")] public string ApplicationName => Get<string>(() => ApplicationName);
    /// <summary>Main category of the application.</summary>
    [Argument(Format = "--main-category {value}")] public DotnetPackagingMainCategory MainCategory => Get<DotnetPackagingMainCategory>(() => MainCategory);
    /// <summary>Additional categories for the application.</summary>
    [Argument(Format = "--additional-categories {value}")] public IReadOnlyList<DotnetPackagingAdditionalCategory> AdditionalCategories => Get<List<DotnetPackagingAdditionalCategory>>(() => AdditionalCategories);
    /// <summary>The icon path for the application. When not provided, the tool looks up for an image called <c>AppImage.png</c>.</summary>
    [Argument(Format = "--icon {value}")] public string Icon => Get<string>(() => Icon);
    /// <summary>Home page of the application.</summary>
    [Argument(Format = "--homepage {value}")] public string Homepage => Get<string>(() => Homepage);
    /// <summary>License of the application.</summary>
    [Argument(Format = "--license {value}")] public string License => Get<string>(() => License);
    /// <summary>Version of the application.</summary>
    [Argument(Format = "--version {value}")] public string Version => Get<string>(() => Version);
    /// <summary>URLs of screenshots of the application.</summary>
    [Argument(Format = "--screenshot-urls {value}")] public IReadOnlyList<string> ScreenshotUrls => Get<List<string>>(() => ScreenshotUrls);
    /// <summary>Short description of the application.</summary>
    [Argument(Format = "--summary {value}")] public string Summary => Get<string>(() => Summary);
    /// <summary>Application ID, usually a reverse DNS name like <c>com.SomeCompany.SomeApplication</c>.</summary>
    [Argument(Format = "--appId {value}")] public string AppId => Get<string>(() => AppId);
}
#endregion
#region DotnetPackagingDebSettingsExtensions
/// <summary>Used within <see cref="DotnetPackagingTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotnetPackagingDebSettingsExtensions
{
    #region Directory
    /// <inheritdoc cref="DotnetPackagingDebSettings.Directory"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingDebSettings), Property = nameof(DotnetPackagingDebSettings.Directory))]
    public static T SetDirectory<T>(this T o, string v) where T : DotnetPackagingDebSettings => o.Modify(b => b.Set(() => o.Directory, v));
    /// <inheritdoc cref="DotnetPackagingDebSettings.Directory"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingDebSettings), Property = nameof(DotnetPackagingDebSettings.Directory))]
    public static T ResetDirectory<T>(this T o) where T : DotnetPackagingDebSettings => o.Modify(b => b.Remove(() => o.Directory));
    #endregion
    #region Metadata
    /// <inheritdoc cref="DotnetPackagingDebSettings.Metadata"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingDebSettings), Property = nameof(DotnetPackagingDebSettings.Metadata))]
    public static T SetMetadata<T>(this T o, string v) where T : DotnetPackagingDebSettings => o.Modify(b => b.Set(() => o.Metadata, v));
    /// <inheritdoc cref="DotnetPackagingDebSettings.Metadata"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingDebSettings), Property = nameof(DotnetPackagingDebSettings.Metadata))]
    public static T ResetMetadata<T>(this T o) where T : DotnetPackagingDebSettings => o.Modify(b => b.Remove(() => o.Metadata));
    #endregion
    #region Output
    /// <inheritdoc cref="DotnetPackagingDebSettings.Output"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingDebSettings), Property = nameof(DotnetPackagingDebSettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : DotnetPackagingDebSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="DotnetPackagingDebSettings.Output"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingDebSettings), Property = nameof(DotnetPackagingDebSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : DotnetPackagingDebSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
}
#endregion
#region DotnetPackagingAppImageSettingsExtensions
/// <summary>Used within <see cref="DotnetPackagingTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotnetPackagingAppImageSettingsExtensions
{
    #region Directory
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Directory"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Directory))]
    public static T SetDirectory<T>(this T o, string v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.Directory, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Directory"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Directory))]
    public static T ResetDirectory<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Remove(() => o.Directory));
    #endregion
    #region Output
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Output"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Output"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region ApplicationName
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.ApplicationName"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.ApplicationName))]
    public static T SetApplicationName<T>(this T o, string v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.ApplicationName, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.ApplicationName"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.ApplicationName))]
    public static T ResetApplicationName<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Remove(() => o.ApplicationName));
    #endregion
    #region MainCategory
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.MainCategory"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.MainCategory))]
    public static T SetMainCategory<T>(this T o, DotnetPackagingMainCategory v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.MainCategory, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.MainCategory"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.MainCategory))]
    public static T ResetMainCategory<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Remove(() => o.MainCategory));
    #endregion
    #region AdditionalCategories
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.AdditionalCategories"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.AdditionalCategories))]
    public static T SetAdditionalCategories<T>(this T o, params DotnetPackagingAdditionalCategory[] v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.AdditionalCategories, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.AdditionalCategories"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.AdditionalCategories))]
    public static T SetAdditionalCategories<T>(this T o, IEnumerable<DotnetPackagingAdditionalCategory> v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.AdditionalCategories, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.AdditionalCategories"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.AdditionalCategories))]
    public static T AddAdditionalCategories<T>(this T o, params DotnetPackagingAdditionalCategory[] v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.AddCollection(() => o.AdditionalCategories, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.AdditionalCategories"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.AdditionalCategories))]
    public static T AddAdditionalCategories<T>(this T o, IEnumerable<DotnetPackagingAdditionalCategory> v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.AddCollection(() => o.AdditionalCategories, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.AdditionalCategories"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.AdditionalCategories))]
    public static T RemoveAdditionalCategories<T>(this T o, params DotnetPackagingAdditionalCategory[] v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.RemoveCollection(() => o.AdditionalCategories, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.AdditionalCategories"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.AdditionalCategories))]
    public static T RemoveAdditionalCategories<T>(this T o, IEnumerable<DotnetPackagingAdditionalCategory> v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.RemoveCollection(() => o.AdditionalCategories, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.AdditionalCategories"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.AdditionalCategories))]
    public static T ClearAdditionalCategories<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.ClearCollection(() => o.AdditionalCategories));
    #endregion
    #region Icon
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Icon"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Icon))]
    public static T SetIcon<T>(this T o, string v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.Icon, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Icon"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Icon))]
    public static T ResetIcon<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Remove(() => o.Icon));
    #endregion
    #region Homepage
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Homepage"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Homepage))]
    public static T SetHomepage<T>(this T o, string v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.Homepage, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Homepage"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Homepage))]
    public static T ResetHomepage<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Remove(() => o.Homepage));
    #endregion
    #region License
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.License"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.License))]
    public static T SetLicense<T>(this T o, string v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.License, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.License"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.License))]
    public static T ResetLicense<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Remove(() => o.License));
    #endregion
    #region Version
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Version"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Version"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region ScreenshotUrls
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.ScreenshotUrls))]
    public static T SetScreenshotUrls<T>(this T o, params string[] v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.ScreenshotUrls, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.ScreenshotUrls))]
    public static T SetScreenshotUrls<T>(this T o, IEnumerable<string> v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.ScreenshotUrls, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.ScreenshotUrls))]
    public static T AddScreenshotUrls<T>(this T o, params string[] v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.AddCollection(() => o.ScreenshotUrls, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.ScreenshotUrls))]
    public static T AddScreenshotUrls<T>(this T o, IEnumerable<string> v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.AddCollection(() => o.ScreenshotUrls, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.ScreenshotUrls))]
    public static T RemoveScreenshotUrls<T>(this T o, params string[] v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.RemoveCollection(() => o.ScreenshotUrls, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.ScreenshotUrls))]
    public static T RemoveScreenshotUrls<T>(this T o, IEnumerable<string> v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.RemoveCollection(() => o.ScreenshotUrls, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.ScreenshotUrls))]
    public static T ClearScreenshotUrls<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.ClearCollection(() => o.ScreenshotUrls));
    #endregion
    #region Summary
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Summary"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Summary))]
    public static T SetSummary<T>(this T o, string v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.Summary, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.Summary"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.Summary))]
    public static T ResetSummary<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Remove(() => o.Summary));
    #endregion
    #region AppId
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.AppId"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.AppId))]
    public static T SetAppId<T>(this T o, string v) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Set(() => o.AppId, v));
    /// <inheritdoc cref="DotnetPackagingAppImageSettings.AppId"/>
    [Pure] [Builder(Type = typeof(DotnetPackagingAppImageSettings), Property = nameof(DotnetPackagingAppImageSettings.AppId))]
    public static T ResetAppId<T>(this T o) where T : DotnetPackagingAppImageSettings => o.Modify(b => b.Remove(() => o.AppId));
    #endregion
}
#endregion
#region DotnetPackagingMainCategory
/// <summary>Used within <see cref="DotnetPackagingTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotnetPackagingMainCategory>))]
public partial class DotnetPackagingMainCategory : Enumeration
{
    public static DotnetPackagingMainCategory AudioVideo = (DotnetPackagingMainCategory) "AudioVideo";
    public static DotnetPackagingMainCategory Audio = (DotnetPackagingMainCategory) "Audio";
    public static DotnetPackagingMainCategory Video = (DotnetPackagingMainCategory) "Video";
    public static DotnetPackagingMainCategory Development = (DotnetPackagingMainCategory) "Development";
    public static DotnetPackagingMainCategory Education = (DotnetPackagingMainCategory) "Education";
    public static DotnetPackagingMainCategory Game = (DotnetPackagingMainCategory) "Game";
    public static DotnetPackagingMainCategory Graphics = (DotnetPackagingMainCategory) "Graphics";
    public static DotnetPackagingMainCategory Network = (DotnetPackagingMainCategory) "Network";
    public static DotnetPackagingMainCategory Office = (DotnetPackagingMainCategory) "Office";
    public static DotnetPackagingMainCategory Settings = (DotnetPackagingMainCategory) "Settings";
    public static DotnetPackagingMainCategory Utility = (DotnetPackagingMainCategory) "Utility";
    public static implicit operator DotnetPackagingMainCategory(string value)
    {
        return new DotnetPackagingMainCategory { Value = value };
    }
}
#endregion
#region DotnetPackagingAdditionalCategory
/// <summary>Used within <see cref="DotnetPackagingTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DotnetPackagingAdditionalCategory>))]
public partial class DotnetPackagingAdditionalCategory : Enumeration
{
    public static DotnetPackagingAdditionalCategory Building = (DotnetPackagingAdditionalCategory) "Building";
    public static DotnetPackagingAdditionalCategory Debugger = (DotnetPackagingAdditionalCategory) "Debugger";
    public static DotnetPackagingAdditionalCategory IDE = (DotnetPackagingAdditionalCategory) "IDE";
    public static DotnetPackagingAdditionalCategory GUIDesigner = (DotnetPackagingAdditionalCategory) "GUIDesigner";
    public static DotnetPackagingAdditionalCategory Profiling = (DotnetPackagingAdditionalCategory) "Profiling";
    public static DotnetPackagingAdditionalCategory RevisionControl = (DotnetPackagingAdditionalCategory) "RevisionControl";
    public static DotnetPackagingAdditionalCategory Translation = (DotnetPackagingAdditionalCategory) "Translation";
    public static DotnetPackagingAdditionalCategory Calendar = (DotnetPackagingAdditionalCategory) "Calendar";
    public static DotnetPackagingAdditionalCategory ContactManagement = (DotnetPackagingAdditionalCategory) "ContactManagement";
    public static DotnetPackagingAdditionalCategory Database = (DotnetPackagingAdditionalCategory) "Database";
    public static DotnetPackagingAdditionalCategory Dictionary = (DotnetPackagingAdditionalCategory) "Dictionary";
    public static DotnetPackagingAdditionalCategory Chart = (DotnetPackagingAdditionalCategory) "Chart";
    public static DotnetPackagingAdditionalCategory Email = (DotnetPackagingAdditionalCategory) "Email";
    public static DotnetPackagingAdditionalCategory Finance = (DotnetPackagingAdditionalCategory) "Finance";
    public static DotnetPackagingAdditionalCategory FlowChart = (DotnetPackagingAdditionalCategory) "FlowChart";
    public static DotnetPackagingAdditionalCategory PDA = (DotnetPackagingAdditionalCategory) "PDA";
    public static DotnetPackagingAdditionalCategory ProjectManagement = (DotnetPackagingAdditionalCategory) "ProjectManagement";
    public static DotnetPackagingAdditionalCategory Presentation = (DotnetPackagingAdditionalCategory) "Presentation";
    public static DotnetPackagingAdditionalCategory Spreadsheet = (DotnetPackagingAdditionalCategory) "Spreadsheet";
    public static DotnetPackagingAdditionalCategory WordProcessor = (DotnetPackagingAdditionalCategory) "WordProcessor";
    public static DotnetPackagingAdditionalCategory TwoDGraphics = (DotnetPackagingAdditionalCategory) "TwoDGraphics";
    public static DotnetPackagingAdditionalCategory VectorGraphics = (DotnetPackagingAdditionalCategory) "VectorGraphics";
    public static DotnetPackagingAdditionalCategory RasterGraphics = (DotnetPackagingAdditionalCategory) "RasterGraphics";
    public static DotnetPackagingAdditionalCategory ThreeDGraphics = (DotnetPackagingAdditionalCategory) "ThreeDGraphics";
    public static DotnetPackagingAdditionalCategory Scanning = (DotnetPackagingAdditionalCategory) "Scanning";
    public static DotnetPackagingAdditionalCategory OCR = (DotnetPackagingAdditionalCategory) "OCR";
    public static DotnetPackagingAdditionalCategory Photography = (DotnetPackagingAdditionalCategory) "Photography";
    public static DotnetPackagingAdditionalCategory Publishing = (DotnetPackagingAdditionalCategory) "Publishing";
    public static DotnetPackagingAdditionalCategory Viewer = (DotnetPackagingAdditionalCategory) "Viewer";
    public static DotnetPackagingAdditionalCategory TextTools = (DotnetPackagingAdditionalCategory) "TextTools";
    public static DotnetPackagingAdditionalCategory DesktopSettings = (DotnetPackagingAdditionalCategory) "DesktopSettings";
    public static DotnetPackagingAdditionalCategory HardwareSettings = (DotnetPackagingAdditionalCategory) "HardwareSettings";
    public static DotnetPackagingAdditionalCategory Printing = (DotnetPackagingAdditionalCategory) "Printing";
    public static DotnetPackagingAdditionalCategory PackageManager = (DotnetPackagingAdditionalCategory) "PackageManager";
    public static DotnetPackagingAdditionalCategory Dialup = (DotnetPackagingAdditionalCategory) "Dialup";
    public static DotnetPackagingAdditionalCategory InstantMessaging = (DotnetPackagingAdditionalCategory) "InstantMessaging";
    public static DotnetPackagingAdditionalCategory Chat = (DotnetPackagingAdditionalCategory) "Chat";
    public static DotnetPackagingAdditionalCategory IRCClient = (DotnetPackagingAdditionalCategory) "IRCClient";
    public static DotnetPackagingAdditionalCategory FileTransfer = (DotnetPackagingAdditionalCategory) "FileTransfer";
    public static DotnetPackagingAdditionalCategory HamRadio = (DotnetPackagingAdditionalCategory) "HamRadio";
    public static DotnetPackagingAdditionalCategory News = (DotnetPackagingAdditionalCategory) "News";
    public static DotnetPackagingAdditionalCategory P2P = (DotnetPackagingAdditionalCategory) "P2P";
    public static DotnetPackagingAdditionalCategory RemoteAccess = (DotnetPackagingAdditionalCategory) "RemoteAccess";
    public static DotnetPackagingAdditionalCategory Telephony = (DotnetPackagingAdditionalCategory) "Telephony";
    public static DotnetPackagingAdditionalCategory TelephonyTools = (DotnetPackagingAdditionalCategory) "TelephonyTools";
    public static DotnetPackagingAdditionalCategory VideoConference = (DotnetPackagingAdditionalCategory) "VideoConference";
    public static DotnetPackagingAdditionalCategory WebBrowser = (DotnetPackagingAdditionalCategory) "WebBrowser";
    public static DotnetPackagingAdditionalCategory WebDevelopment = (DotnetPackagingAdditionalCategory) "WebDevelopment";
    public static DotnetPackagingAdditionalCategory Midi = (DotnetPackagingAdditionalCategory) "Midi";
    public static DotnetPackagingAdditionalCategory Mixer = (DotnetPackagingAdditionalCategory) "Mixer";
    public static DotnetPackagingAdditionalCategory Sequencer = (DotnetPackagingAdditionalCategory) "Sequencer";
    public static DotnetPackagingAdditionalCategory Tuner = (DotnetPackagingAdditionalCategory) "Tuner";
    public static DotnetPackagingAdditionalCategory TV = (DotnetPackagingAdditionalCategory) "TV";
    public static DotnetPackagingAdditionalCategory AudioVideoEditing = (DotnetPackagingAdditionalCategory) "AudioVideoEditing";
    public static DotnetPackagingAdditionalCategory Player = (DotnetPackagingAdditionalCategory) "Player";
    public static DotnetPackagingAdditionalCategory Recorder = (DotnetPackagingAdditionalCategory) "Recorder";
    public static DotnetPackagingAdditionalCategory DiscBurning = (DotnetPackagingAdditionalCategory) "DiscBurning";
    public static DotnetPackagingAdditionalCategory ActionGame = (DotnetPackagingAdditionalCategory) "ActionGame";
    public static DotnetPackagingAdditionalCategory AdventureGame = (DotnetPackagingAdditionalCategory) "AdventureGame";
    public static DotnetPackagingAdditionalCategory ArcadeGame = (DotnetPackagingAdditionalCategory) "ArcadeGame";
    public static DotnetPackagingAdditionalCategory BoardGame = (DotnetPackagingAdditionalCategory) "BoardGame";
    public static DotnetPackagingAdditionalCategory BlocksGame = (DotnetPackagingAdditionalCategory) "BlocksGame";
    public static DotnetPackagingAdditionalCategory CardGame = (DotnetPackagingAdditionalCategory) "CardGame";
    public static DotnetPackagingAdditionalCategory KidsGame = (DotnetPackagingAdditionalCategory) "KidsGame";
    public static DotnetPackagingAdditionalCategory LogicGame = (DotnetPackagingAdditionalCategory) "LogicGame";
    public static DotnetPackagingAdditionalCategory RolePlaying = (DotnetPackagingAdditionalCategory) "RolePlaying";
    public static DotnetPackagingAdditionalCategory Simulation = (DotnetPackagingAdditionalCategory) "Simulation";
    public static DotnetPackagingAdditionalCategory SportsGame = (DotnetPackagingAdditionalCategory) "SportsGame";
    public static DotnetPackagingAdditionalCategory StrategyGame = (DotnetPackagingAdditionalCategory) "StrategyGame";
    public static DotnetPackagingAdditionalCategory Art = (DotnetPackagingAdditionalCategory) "Art";
    public static DotnetPackagingAdditionalCategory Construction = (DotnetPackagingAdditionalCategory) "Construction";
    public static DotnetPackagingAdditionalCategory Music = (DotnetPackagingAdditionalCategory) "Music";
    public static DotnetPackagingAdditionalCategory Languages = (DotnetPackagingAdditionalCategory) "Languages";
    public static DotnetPackagingAdditionalCategory Science = (DotnetPackagingAdditionalCategory) "Science";
    public static DotnetPackagingAdditionalCategory ArtificialIntelligence = (DotnetPackagingAdditionalCategory) "ArtificialIntelligence";
    public static DotnetPackagingAdditionalCategory Astronomy = (DotnetPackagingAdditionalCategory) "Astronomy";
    public static DotnetPackagingAdditionalCategory Biology = (DotnetPackagingAdditionalCategory) "Biology";
    public static DotnetPackagingAdditionalCategory Chemistry = (DotnetPackagingAdditionalCategory) "Chemistry";
    public static DotnetPackagingAdditionalCategory ComputerScience = (DotnetPackagingAdditionalCategory) "ComputerScience";
    public static DotnetPackagingAdditionalCategory DataVisualization = (DotnetPackagingAdditionalCategory) "DataVisualization";
    public static DotnetPackagingAdditionalCategory Economy = (DotnetPackagingAdditionalCategory) "Economy";
    public static DotnetPackagingAdditionalCategory Electricity = (DotnetPackagingAdditionalCategory) "Electricity";
    public static DotnetPackagingAdditionalCategory Geography = (DotnetPackagingAdditionalCategory) "Geography";
    public static DotnetPackagingAdditionalCategory Geology = (DotnetPackagingAdditionalCategory) "Geology";
    public static DotnetPackagingAdditionalCategory Geoscience = (DotnetPackagingAdditionalCategory) "Geoscience";
    public static DotnetPackagingAdditionalCategory History = (DotnetPackagingAdditionalCategory) "History";
    public static DotnetPackagingAdditionalCategory ImageProcessing = (DotnetPackagingAdditionalCategory) "ImageProcessing";
    public static DotnetPackagingAdditionalCategory Literature = (DotnetPackagingAdditionalCategory) "Literature";
    public static DotnetPackagingAdditionalCategory Math = (DotnetPackagingAdditionalCategory) "Math";
    public static DotnetPackagingAdditionalCategory NumericalAnalysis = (DotnetPackagingAdditionalCategory) "NumericalAnalysis";
    public static DotnetPackagingAdditionalCategory MedicalSoftware = (DotnetPackagingAdditionalCategory) "MedicalSoftware";
    public static DotnetPackagingAdditionalCategory Physics = (DotnetPackagingAdditionalCategory) "Physics";
    public static DotnetPackagingAdditionalCategory Robotics = (DotnetPackagingAdditionalCategory) "Robotics";
    public static DotnetPackagingAdditionalCategory Sports = (DotnetPackagingAdditionalCategory) "Sports";
    public static DotnetPackagingAdditionalCategory ParallelComputing = (DotnetPackagingAdditionalCategory) "ParallelComputing";
    public static DotnetPackagingAdditionalCategory Amusement = (DotnetPackagingAdditionalCategory) "Amusement";
    public static DotnetPackagingAdditionalCategory Archiving = (DotnetPackagingAdditionalCategory) "Archiving";
    public static DotnetPackagingAdditionalCategory Compression = (DotnetPackagingAdditionalCategory) "Compression";
    public static DotnetPackagingAdditionalCategory Electronics = (DotnetPackagingAdditionalCategory) "Electronics";
    public static DotnetPackagingAdditionalCategory Emulator = (DotnetPackagingAdditionalCategory) "Emulator";
    public static DotnetPackagingAdditionalCategory Engineering = (DotnetPackagingAdditionalCategory) "Engineering";
    public static DotnetPackagingAdditionalCategory FileTools = (DotnetPackagingAdditionalCategory) "FileTools";
    public static DotnetPackagingAdditionalCategory FileManager = (DotnetPackagingAdditionalCategory) "FileManager";
    public static DotnetPackagingAdditionalCategory TerminalEmulator = (DotnetPackagingAdditionalCategory) "TerminalEmulator";
    public static DotnetPackagingAdditionalCategory Filesystem = (DotnetPackagingAdditionalCategory) "Filesystem";
    public static DotnetPackagingAdditionalCategory Monitor = (DotnetPackagingAdditionalCategory) "Monitor";
    public static DotnetPackagingAdditionalCategory Security = (DotnetPackagingAdditionalCategory) "Security";
    public static DotnetPackagingAdditionalCategory Accessibility = (DotnetPackagingAdditionalCategory) "Accessibility";
    public static DotnetPackagingAdditionalCategory Calculator = (DotnetPackagingAdditionalCategory) "Calculator";
    public static DotnetPackagingAdditionalCategory Clock = (DotnetPackagingAdditionalCategory) "Clock";
    public static DotnetPackagingAdditionalCategory TextEditor = (DotnetPackagingAdditionalCategory) "TextEditor";
    public static DotnetPackagingAdditionalCategory Documentation = (DotnetPackagingAdditionalCategory) "Documentation";
    public static DotnetPackagingAdditionalCategory Core = (DotnetPackagingAdditionalCategory) "Core";
    public static DotnetPackagingAdditionalCategory KDE = (DotnetPackagingAdditionalCategory) "KDE";
    public static DotnetPackagingAdditionalCategory GNOME = (DotnetPackagingAdditionalCategory) "GNOME";
    public static DotnetPackagingAdditionalCategory GTK = (DotnetPackagingAdditionalCategory) "GTK";
    public static DotnetPackagingAdditionalCategory Qt = (DotnetPackagingAdditionalCategory) "Qt";
    public static DotnetPackagingAdditionalCategory Motif = (DotnetPackagingAdditionalCategory) "Motif";
    public static DotnetPackagingAdditionalCategory Java = (DotnetPackagingAdditionalCategory) "Java";
    public static DotnetPackagingAdditionalCategory ConsoleOnly = (DotnetPackagingAdditionalCategory) "ConsoleOnly";
    public static implicit operator DotnetPackagingAdditionalCategory(string value)
    {
        return new DotnetPackagingAdditionalCategory { Value = value };
    }
}
#endregion
