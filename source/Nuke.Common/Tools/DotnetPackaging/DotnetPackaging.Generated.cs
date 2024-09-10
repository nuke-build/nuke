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

/// <summary>
///   <p>DotnetPackaging is able to package your application into various formats, including Deb and AppImage.</p>
///   <p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p>
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(DotnetPackagingPackageId)]
public partial class DotnetPackagingTasks
    : IRequireNuGetPackage
{
    public const string DotnetPackagingPackageId = "DotnetPackaging.Console";
    /// <summary>
    ///   Path to the DotnetPackaging executable.
    /// </summary>
    public static string DotnetPackagingPath =>
        ToolPathResolver.TryGetEnvironmentExecutable("DOTNETPACKAGING_EXE") ??
        NuGetToolPathResolver.GetPackageExecutable("DotnetPackaging.Console", "DotnetPackaging.Console.dll");
    public static Action<OutputType, string> DotnetPackagingLogger { get; set; } = ProcessTasks.DefaultLogger;
    public static Action<ToolSettings, IProcess> DotnetPackagingExitHandler { get; set; } = ProcessTasks.DefaultExitHandler;
    /// <summary>
    ///   <p>DotnetPackaging is able to package your application into various formats, including Deb and AppImage.</p>
    ///   <p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p>
    /// </summary>
    public static IReadOnlyCollection<Output> DotnetPackaging(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Action<IProcess> exitHandler = null)
    {
        using var process = ProcessTasks.StartProcess(DotnetPackagingPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger ?? DotnetPackagingLogger);
        (exitHandler ?? (p => DotnetPackagingExitHandler.Invoke(null, p))).Invoke(process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Creates a Debian package from the specified directory.</p>
    ///   <p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--directory</c> via <see cref="DotnetPackagingDebSettings.Directory"/></li>
    ///     <li><c>--metadata</c> via <see cref="DotnetPackagingDebSettings.Metadata"/></li>
    ///     <li><c>--output</c> via <see cref="DotnetPackagingDebSettings.Output"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> DotnetPackagingDeb(DotnetPackagingDebSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new DotnetPackagingDebSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Creates a Debian package from the specified directory.</p>
    ///   <p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--directory</c> via <see cref="DotnetPackagingDebSettings.Directory"/></li>
    ///     <li><c>--metadata</c> via <see cref="DotnetPackagingDebSettings.Metadata"/></li>
    ///     <li><c>--output</c> via <see cref="DotnetPackagingDebSettings.Output"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> DotnetPackagingDeb(Configure<DotnetPackagingDebSettings> configurator)
    {
        return DotnetPackagingDeb(configurator(new DotnetPackagingDebSettings()));
    }
    /// <summary>
    ///   <p>Creates a Debian package from the specified directory.</p>
    ///   <p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--directory</c> via <see cref="DotnetPackagingDebSettings.Directory"/></li>
    ///     <li><c>--metadata</c> via <see cref="DotnetPackagingDebSettings.Metadata"/></li>
    ///     <li><c>--output</c> via <see cref="DotnetPackagingDebSettings.Output"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(DotnetPackagingDebSettings Settings, IReadOnlyCollection<Output> Output)> DotnetPackagingDeb(CombinatorialConfigure<DotnetPackagingDebSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(DotnetPackagingDeb, DotnetPackagingLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Creates an AppImage package.</p>
    ///   <p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--additional-categories</c> via <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></li>
    ///     <li><c>--appId</c> via <see cref="DotnetPackagingAppImageSettings.AppId"/></li>
    ///     <li><c>--application-name</c> via <see cref="DotnetPackagingAppImageSettings.ApplicationName"/></li>
    ///     <li><c>--directory</c> via <see cref="DotnetPackagingAppImageSettings.Directory"/></li>
    ///     <li><c>--homepage</c> via <see cref="DotnetPackagingAppImageSettings.Homepage"/></li>
    ///     <li><c>--icon</c> via <see cref="DotnetPackagingAppImageSettings.Icon"/></li>
    ///     <li><c>--license</c> via <see cref="DotnetPackagingAppImageSettings.License"/></li>
    ///     <li><c>--main-category</c> via <see cref="DotnetPackagingAppImageSettings.MainCategory"/></li>
    ///     <li><c>--output</c> via <see cref="DotnetPackagingAppImageSettings.Output"/></li>
    ///     <li><c>--screenshot-urls</c> via <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></li>
    ///     <li><c>--summary</c> via <see cref="DotnetPackagingAppImageSettings.Summary"/></li>
    ///     <li><c>--version</c> via <see cref="DotnetPackagingAppImageSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> DotnetPackagingAppImage(DotnetPackagingAppImageSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new DotnetPackagingAppImageSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Creates an AppImage package.</p>
    ///   <p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--additional-categories</c> via <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></li>
    ///     <li><c>--appId</c> via <see cref="DotnetPackagingAppImageSettings.AppId"/></li>
    ///     <li><c>--application-name</c> via <see cref="DotnetPackagingAppImageSettings.ApplicationName"/></li>
    ///     <li><c>--directory</c> via <see cref="DotnetPackagingAppImageSettings.Directory"/></li>
    ///     <li><c>--homepage</c> via <see cref="DotnetPackagingAppImageSettings.Homepage"/></li>
    ///     <li><c>--icon</c> via <see cref="DotnetPackagingAppImageSettings.Icon"/></li>
    ///     <li><c>--license</c> via <see cref="DotnetPackagingAppImageSettings.License"/></li>
    ///     <li><c>--main-category</c> via <see cref="DotnetPackagingAppImageSettings.MainCategory"/></li>
    ///     <li><c>--output</c> via <see cref="DotnetPackagingAppImageSettings.Output"/></li>
    ///     <li><c>--screenshot-urls</c> via <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></li>
    ///     <li><c>--summary</c> via <see cref="DotnetPackagingAppImageSettings.Summary"/></li>
    ///     <li><c>--version</c> via <see cref="DotnetPackagingAppImageSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> DotnetPackagingAppImage(Configure<DotnetPackagingAppImageSettings> configurator)
    {
        return DotnetPackagingAppImage(configurator(new DotnetPackagingAppImageSettings()));
    }
    /// <summary>
    ///   <p>Creates an AppImage package.</p>
    ///   <p>For more details, visit the <a href="https://github.com/superjmn/dotnetpackaging">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--additional-categories</c> via <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></li>
    ///     <li><c>--appId</c> via <see cref="DotnetPackagingAppImageSettings.AppId"/></li>
    ///     <li><c>--application-name</c> via <see cref="DotnetPackagingAppImageSettings.ApplicationName"/></li>
    ///     <li><c>--directory</c> via <see cref="DotnetPackagingAppImageSettings.Directory"/></li>
    ///     <li><c>--homepage</c> via <see cref="DotnetPackagingAppImageSettings.Homepage"/></li>
    ///     <li><c>--icon</c> via <see cref="DotnetPackagingAppImageSettings.Icon"/></li>
    ///     <li><c>--license</c> via <see cref="DotnetPackagingAppImageSettings.License"/></li>
    ///     <li><c>--main-category</c> via <see cref="DotnetPackagingAppImageSettings.MainCategory"/></li>
    ///     <li><c>--output</c> via <see cref="DotnetPackagingAppImageSettings.Output"/></li>
    ///     <li><c>--screenshot-urls</c> via <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></li>
    ///     <li><c>--summary</c> via <see cref="DotnetPackagingAppImageSettings.Summary"/></li>
    ///     <li><c>--version</c> via <see cref="DotnetPackagingAppImageSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(DotnetPackagingAppImageSettings Settings, IReadOnlyCollection<Output> Output)> DotnetPackagingAppImage(CombinatorialConfigure<DotnetPackagingAppImageSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(DotnetPackagingAppImage, DotnetPackagingLogger, degreeOfParallelism, completeOnFailure);
    }
}
#region DotnetPackagingDebSettings
/// <summary>
///   Used within <see cref="DotnetPackagingTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class DotnetPackagingDebSettings : ToolSettings
{
    /// <summary>
    ///   Path to the DotnetPackaging executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? DotnetPackagingTasks.DotnetPackagingPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? DotnetPackagingTasks.DotnetPackagingLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? DotnetPackagingTasks.DotnetPackagingExitHandler;
    /// <summary>
    ///   The input directory from which to create the package.
    /// </summary>
    public virtual string Directory { get; internal set; }
    /// <summary>
    ///   The metadata file to include in the package.
    /// </summary>
    public virtual string Metadata { get; internal set; }
    /// <summary>
    ///   The output DEB file to create.
    /// </summary>
    public virtual string Output { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("deb")
          .Add("--directory={value}", Directory)
          .Add("--metadata={value}", Metadata)
          .Add("--output={value}", Output);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region DotnetPackagingAppImageSettings
/// <summary>
///   Used within <see cref="DotnetPackagingTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class DotnetPackagingAppImageSettings : ToolSettings
{
    /// <summary>
    ///   Path to the DotnetPackaging executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? DotnetPackagingTasks.DotnetPackagingPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? DotnetPackagingTasks.DotnetPackagingLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? DotnetPackagingTasks.DotnetPackagingExitHandler;
    /// <summary>
    ///   The input directory from which to create the AppImage.
    /// </summary>
    public virtual string Directory { get; internal set; }
    /// <summary>
    ///   The output AppImage file to create.
    /// </summary>
    public virtual string Output { get; internal set; }
    /// <summary>
    ///   The name of the application for the AppImage.
    /// </summary>
    public virtual string ApplicationName { get; internal set; }
    /// <summary>
    ///   Main category of the application.
    /// </summary>
    public virtual DotnetPackagingMainCategory MainCategory { get; internal set; }
    /// <summary>
    ///   Additional categories for the application.
    /// </summary>
    public virtual IReadOnlyList<DotnetPackagingAdditionalCategory> AdditionalCategories => AdditionalCategoriesInternal.AsReadOnly();
    internal List<DotnetPackagingAdditionalCategory> AdditionalCategoriesInternal { get; set; } = new List<DotnetPackagingAdditionalCategory>();
    /// <summary>
    ///   The icon path for the application. When not provided, the tool looks up for an image called <c>AppImage.png</c>.
    /// </summary>
    public virtual string Icon { get; internal set; }
    /// <summary>
    ///   Home page of the application.
    /// </summary>
    public virtual string Homepage { get; internal set; }
    /// <summary>
    ///   License of the application.
    /// </summary>
    public virtual string License { get; internal set; }
    /// <summary>
    ///   Version of the application.
    /// </summary>
    public virtual string Version { get; internal set; }
    /// <summary>
    ///   URLs of screenshots of the application.
    /// </summary>
    public virtual IReadOnlyList<string> ScreenshotUrls => ScreenshotUrlsInternal.AsReadOnly();
    internal List<string> ScreenshotUrlsInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Short description of the application.
    /// </summary>
    public virtual string Summary { get; internal set; }
    /// <summary>
    ///   Application ID, usually a reverse DNS name like <c>com.SomeCompany.SomeApplication</c>.
    /// </summary>
    public virtual string AppId { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("appimage")
          .Add("--directory={value}", Directory)
          .Add("--output={value}", Output)
          .Add("--application-name={value}", ApplicationName)
          .Add("--main-category {value}", MainCategory)
          .Add("--additional-categories {value}", AdditionalCategories)
          .Add("--icon {value}", Icon)
          .Add("--homepage {value}", Homepage)
          .Add("--license {value}", License)
          .Add("--version {value}", Version)
          .Add("--screenshot-urls {value}", ScreenshotUrls)
          .Add("--summary {value}", Summary)
          .Add("--appId {value}", AppId);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region DotnetPackagingDebSettingsExtensions
/// <summary>
///   Used within <see cref="DotnetPackagingTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotnetPackagingDebSettingsExtensions
{
    #region Directory
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingDebSettings.Directory"/></em></p>
    ///   <p>The input directory from which to create the package.</p>
    /// </summary>
    [Pure]
    public static T SetDirectory<T>(this T toolSettings, string directory) where T : DotnetPackagingDebSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Directory = directory;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingDebSettings.Directory"/></em></p>
    ///   <p>The input directory from which to create the package.</p>
    /// </summary>
    [Pure]
    public static T ResetDirectory<T>(this T toolSettings) where T : DotnetPackagingDebSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Directory = null;
        return toolSettings;
    }
    #endregion
    #region Metadata
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingDebSettings.Metadata"/></em></p>
    ///   <p>The metadata file to include in the package.</p>
    /// </summary>
    [Pure]
    public static T SetMetadata<T>(this T toolSettings, string metadata) where T : DotnetPackagingDebSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Metadata = metadata;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingDebSettings.Metadata"/></em></p>
    ///   <p>The metadata file to include in the package.</p>
    /// </summary>
    [Pure]
    public static T ResetMetadata<T>(this T toolSettings) where T : DotnetPackagingDebSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Metadata = null;
        return toolSettings;
    }
    #endregion
    #region Output
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingDebSettings.Output"/></em></p>
    ///   <p>The output DEB file to create.</p>
    /// </summary>
    [Pure]
    public static T SetOutput<T>(this T toolSettings, string output) where T : DotnetPackagingDebSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = output;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingDebSettings.Output"/></em></p>
    ///   <p>The output DEB file to create.</p>
    /// </summary>
    [Pure]
    public static T ResetOutput<T>(this T toolSettings) where T : DotnetPackagingDebSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region DotnetPackagingAppImageSettingsExtensions
/// <summary>
///   Used within <see cref="DotnetPackagingTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DotnetPackagingAppImageSettingsExtensions
{
    #region Directory
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.Directory"/></em></p>
    ///   <p>The input directory from which to create the AppImage.</p>
    /// </summary>
    [Pure]
    public static T SetDirectory<T>(this T toolSettings, string directory) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Directory = directory;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingAppImageSettings.Directory"/></em></p>
    ///   <p>The input directory from which to create the AppImage.</p>
    /// </summary>
    [Pure]
    public static T ResetDirectory<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Directory = null;
        return toolSettings;
    }
    #endregion
    #region Output
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.Output"/></em></p>
    ///   <p>The output AppImage file to create.</p>
    /// </summary>
    [Pure]
    public static T SetOutput<T>(this T toolSettings, string output) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = output;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingAppImageSettings.Output"/></em></p>
    ///   <p>The output AppImage file to create.</p>
    /// </summary>
    [Pure]
    public static T ResetOutput<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = null;
        return toolSettings;
    }
    #endregion
    #region ApplicationName
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.ApplicationName"/></em></p>
    ///   <p>The name of the application for the AppImage.</p>
    /// </summary>
    [Pure]
    public static T SetApplicationName<T>(this T toolSettings, string applicationName) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ApplicationName = applicationName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingAppImageSettings.ApplicationName"/></em></p>
    ///   <p>The name of the application for the AppImage.</p>
    /// </summary>
    [Pure]
    public static T ResetApplicationName<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ApplicationName = null;
        return toolSettings;
    }
    #endregion
    #region MainCategory
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.MainCategory"/></em></p>
    ///   <p>Main category of the application.</p>
    /// </summary>
    [Pure]
    public static T SetMainCategory<T>(this T toolSettings, DotnetPackagingMainCategory mainCategory) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MainCategory = mainCategory;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingAppImageSettings.MainCategory"/></em></p>
    ///   <p>Main category of the application.</p>
    /// </summary>
    [Pure]
    public static T ResetMainCategory<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MainCategory = null;
        return toolSettings;
    }
    #endregion
    #region AdditionalCategories
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/> to a new list</em></p>
    ///   <p>Additional categories for the application.</p>
    /// </summary>
    [Pure]
    public static T SetAdditionalCategories<T>(this T toolSettings, params DotnetPackagingAdditionalCategory[] additionalCategories) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AdditionalCategoriesInternal = additionalCategories.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/> to a new list</em></p>
    ///   <p>Additional categories for the application.</p>
    /// </summary>
    [Pure]
    public static T SetAdditionalCategories<T>(this T toolSettings, IEnumerable<DotnetPackagingAdditionalCategory> additionalCategories) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AdditionalCategoriesInternal = additionalCategories.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></em></p>
    ///   <p>Additional categories for the application.</p>
    /// </summary>
    [Pure]
    public static T AddAdditionalCategories<T>(this T toolSettings, params DotnetPackagingAdditionalCategory[] additionalCategories) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AdditionalCategoriesInternal.AddRange(additionalCategories);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></em></p>
    ///   <p>Additional categories for the application.</p>
    /// </summary>
    [Pure]
    public static T AddAdditionalCategories<T>(this T toolSettings, IEnumerable<DotnetPackagingAdditionalCategory> additionalCategories) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AdditionalCategoriesInternal.AddRange(additionalCategories);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></em></p>
    ///   <p>Additional categories for the application.</p>
    /// </summary>
    [Pure]
    public static T ClearAdditionalCategories<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AdditionalCategoriesInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></em></p>
    ///   <p>Additional categories for the application.</p>
    /// </summary>
    [Pure]
    public static T RemoveAdditionalCategories<T>(this T toolSettings, params DotnetPackagingAdditionalCategory[] additionalCategories) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<DotnetPackagingAdditionalCategory>(additionalCategories);
        toolSettings.AdditionalCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="DotnetPackagingAppImageSettings.AdditionalCategories"/></em></p>
    ///   <p>Additional categories for the application.</p>
    /// </summary>
    [Pure]
    public static T RemoveAdditionalCategories<T>(this T toolSettings, IEnumerable<DotnetPackagingAdditionalCategory> additionalCategories) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<DotnetPackagingAdditionalCategory>(additionalCategories);
        toolSettings.AdditionalCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Icon
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.Icon"/></em></p>
    ///   <p>The icon path for the application. When not provided, the tool looks up for an image called <c>AppImage.png</c>.</p>
    /// </summary>
    [Pure]
    public static T SetIcon<T>(this T toolSettings, string icon) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Icon = icon;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingAppImageSettings.Icon"/></em></p>
    ///   <p>The icon path for the application. When not provided, the tool looks up for an image called <c>AppImage.png</c>.</p>
    /// </summary>
    [Pure]
    public static T ResetIcon<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Icon = null;
        return toolSettings;
    }
    #endregion
    #region Homepage
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.Homepage"/></em></p>
    ///   <p>Home page of the application.</p>
    /// </summary>
    [Pure]
    public static T SetHomepage<T>(this T toolSettings, string homepage) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Homepage = homepage;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingAppImageSettings.Homepage"/></em></p>
    ///   <p>Home page of the application.</p>
    /// </summary>
    [Pure]
    public static T ResetHomepage<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Homepage = null;
        return toolSettings;
    }
    #endregion
    #region License
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.License"/></em></p>
    ///   <p>License of the application.</p>
    /// </summary>
    [Pure]
    public static T SetLicense<T>(this T toolSettings, string license) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.License = license;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingAppImageSettings.License"/></em></p>
    ///   <p>License of the application.</p>
    /// </summary>
    [Pure]
    public static T ResetLicense<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.License = null;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.Version"/></em></p>
    ///   <p>Version of the application.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingAppImageSettings.Version"/></em></p>
    ///   <p>Version of the application.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region ScreenshotUrls
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/> to a new list</em></p>
    ///   <p>URLs of screenshots of the application.</p>
    /// </summary>
    [Pure]
    public static T SetScreenshotUrls<T>(this T toolSettings, params string[] screenshotUrls) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ScreenshotUrlsInternal = screenshotUrls.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/> to a new list</em></p>
    ///   <p>URLs of screenshots of the application.</p>
    /// </summary>
    [Pure]
    public static T SetScreenshotUrls<T>(this T toolSettings, IEnumerable<string> screenshotUrls) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ScreenshotUrlsInternal = screenshotUrls.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></em></p>
    ///   <p>URLs of screenshots of the application.</p>
    /// </summary>
    [Pure]
    public static T AddScreenshotUrls<T>(this T toolSettings, params string[] screenshotUrls) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ScreenshotUrlsInternal.AddRange(screenshotUrls);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></em></p>
    ///   <p>URLs of screenshots of the application.</p>
    /// </summary>
    [Pure]
    public static T AddScreenshotUrls<T>(this T toolSettings, IEnumerable<string> screenshotUrls) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ScreenshotUrlsInternal.AddRange(screenshotUrls);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></em></p>
    ///   <p>URLs of screenshots of the application.</p>
    /// </summary>
    [Pure]
    public static T ClearScreenshotUrls<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ScreenshotUrlsInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></em></p>
    ///   <p>URLs of screenshots of the application.</p>
    /// </summary>
    [Pure]
    public static T RemoveScreenshotUrls<T>(this T toolSettings, params string[] screenshotUrls) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(screenshotUrls);
        toolSettings.ScreenshotUrlsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="DotnetPackagingAppImageSettings.ScreenshotUrls"/></em></p>
    ///   <p>URLs of screenshots of the application.</p>
    /// </summary>
    [Pure]
    public static T RemoveScreenshotUrls<T>(this T toolSettings, IEnumerable<string> screenshotUrls) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(screenshotUrls);
        toolSettings.ScreenshotUrlsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Summary
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.Summary"/></em></p>
    ///   <p>Short description of the application.</p>
    /// </summary>
    [Pure]
    public static T SetSummary<T>(this T toolSettings, string summary) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Summary = summary;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingAppImageSettings.Summary"/></em></p>
    ///   <p>Short description of the application.</p>
    /// </summary>
    [Pure]
    public static T ResetSummary<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Summary = null;
        return toolSettings;
    }
    #endregion
    #region AppId
    /// <summary>
    ///   <p><em>Sets <see cref="DotnetPackagingAppImageSettings.AppId"/></em></p>
    ///   <p>Application ID, usually a reverse DNS name like <c>com.SomeCompany.SomeApplication</c>.</p>
    /// </summary>
    [Pure]
    public static T SetAppId<T>(this T toolSettings, string appId) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AppId = appId;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="DotnetPackagingAppImageSettings.AppId"/></em></p>
    ///   <p>Application ID, usually a reverse DNS name like <c>com.SomeCompany.SomeApplication</c>.</p>
    /// </summary>
    [Pure]
    public static T ResetAppId<T>(this T toolSettings) where T : DotnetPackagingAppImageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AppId = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region DotnetPackagingMainCategory
/// <summary>
///   Used within <see cref="DotnetPackagingTasks"/>.
/// </summary>
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
/// <summary>
///   Used within <see cref="DotnetPackagingTasks"/>.
/// </summary>
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
