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

namespace Nuke.Common.Tools.Boots
{
    /// <summary>
    ///   <p>boots is a .NET global tool for <c>bootstrapping</c> <c>vsix</c> and <c>pkg</c> files.</p>
    ///   <p>For more details, visit the <a href="https://github.com/jonathanpeppers/boots">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(BootsPackageId)]
    public partial class BootsTasks
        : IRequireNuGetPackage
    {
        public const string BootsPackageId = "Boots";
        /// <summary>
        ///   Path to the Boots executable.
        /// </summary>
        public static string BootsPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("BOOTS_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("Boots", "Boots.exe");
        public static Action<OutputType, string> BootsLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>boots is a .NET global tool for <c>bootstrapping</c> <c>vsix</c> and <c>pkg</c> files.</p>
        ///   <p>For more details, visit the <a href="https://github.com/jonathanpeppers/boots">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Boots(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(BootsPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? BootsLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>boots is a .NET global tool for <c>bootstrapping</c> <c>vsix</c> and <c>pkg</c> files.</p>
        ///   <p>For more details, visit the <a href="https://github.com/jonathanpeppers/boots">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--file-type</c> via <see cref="BootsSettings.FileType"/></li>
        ///     <li><c>--preview</c> via <see cref="BootsSettings.Preview"/></li>
        ///     <li><c>--read-write-timeout</c> via <see cref="BootsSettings.ReadWriteTimeout"/></li>
        ///     <li><c>--retries</c> via <see cref="BootsSettings.Retries"/></li>
        ///     <li><c>--stable</c> via <see cref="BootsSettings.Stable"/></li>
        ///     <li><c>--timeout</c> via <see cref="BootsSettings.Timeout"/></li>
        ///     <li><c>--url</c> via <see cref="BootsSettings.Url"/></li>
        ///     <li><c>--version</c> via <see cref="BootsSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Boots(BootsSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new BootsSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>boots is a .NET global tool for <c>bootstrapping</c> <c>vsix</c> and <c>pkg</c> files.</p>
        ///   <p>For more details, visit the <a href="https://github.com/jonathanpeppers/boots">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--file-type</c> via <see cref="BootsSettings.FileType"/></li>
        ///     <li><c>--preview</c> via <see cref="BootsSettings.Preview"/></li>
        ///     <li><c>--read-write-timeout</c> via <see cref="BootsSettings.ReadWriteTimeout"/></li>
        ///     <li><c>--retries</c> via <see cref="BootsSettings.Retries"/></li>
        ///     <li><c>--stable</c> via <see cref="BootsSettings.Stable"/></li>
        ///     <li><c>--timeout</c> via <see cref="BootsSettings.Timeout"/></li>
        ///     <li><c>--url</c> via <see cref="BootsSettings.Url"/></li>
        ///     <li><c>--version</c> via <see cref="BootsSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Boots(Configure<BootsSettings> configurator)
        {
            return Boots(configurator(new BootsSettings()));
        }
        /// <summary>
        ///   <p>boots is a .NET global tool for <c>bootstrapping</c> <c>vsix</c> and <c>pkg</c> files.</p>
        ///   <p>For more details, visit the <a href="https://github.com/jonathanpeppers/boots">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--file-type</c> via <see cref="BootsSettings.FileType"/></li>
        ///     <li><c>--preview</c> via <see cref="BootsSettings.Preview"/></li>
        ///     <li><c>--read-write-timeout</c> via <see cref="BootsSettings.ReadWriteTimeout"/></li>
        ///     <li><c>--retries</c> via <see cref="BootsSettings.Retries"/></li>
        ///     <li><c>--stable</c> via <see cref="BootsSettings.Stable"/></li>
        ///     <li><c>--timeout</c> via <see cref="BootsSettings.Timeout"/></li>
        ///     <li><c>--url</c> via <see cref="BootsSettings.Url"/></li>
        ///     <li><c>--version</c> via <see cref="BootsSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(BootsSettings Settings, IReadOnlyCollection<Output> Output)> Boots(CombinatorialConfigure<BootsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(Boots, BootsLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region BootsSettings
    /// <summary>
    ///   Used within <see cref="BootsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class BootsSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Boots executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? BootsTasks.BootsPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? BootsTasks.BootsLogger;
        /// <summary>
        ///   Install the latest <em>stable</em> version of a product from VS manifests. Options include: <c>Xamarin.Android</c>, <c>Xamarin.iOS</c>, <c>Xamarin.Mac</c>, and <c>Mono</c>
        /// </summary>
        public virtual BootsProductType Stable { get; internal set; }
        /// <summary>
        ///   Install the latest <em>preview</em> version of a product from VS manifests. Options include: <c>Xamarin.Android</c>, <c>Xamarin.iOS</c>, <c>Xamarin.Mac</c>, and <c>Mono</c>
        /// </summary>
        public virtual BootsProductType Preview { get; internal set; }
        /// <summary>
        ///   A Url to a <c>pkg</c> or <c>vsix</c> file to install
        /// </summary>
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   Specifies the type of file to be installed such as <c>vsix</c>, <c>pkg</c>, or <c>msi</c>. Defaults to <c>vsix</c> on Windows and <c>pkg</c> on macOS
        /// </summary>
        public virtual BootsFileType FileType { get; internal set; }
        /// <summary>
        ///   Specifies a timeout for <c>HttpClient</c>. If omitted, uses the .NET default of 100 seconds
        /// </summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary>
        ///   Specifies a timeout for reading/writing from a <c>HttpClient</c> stream. If omitted, uses a default of 300 seconds
        /// </summary>
        public virtual int? ReadWriteTimeout { get; internal set; }
        /// <summary>
        ///   Specifies a number of retries for <c>HttpClient</c> failures. If omitted, uses a default of 3 retries
        /// </summary>
        public virtual int? Retries { get; internal set; }
        /// <summary>
        ///   Show version information
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("--stable {value}", Stable)
              .Add("--preview {value}", Preview)
              .Add("--url {value}", Url)
              .Add("--file-type {value}", FileType)
              .Add("--timeout {value}", Timeout)
              .Add("--read-write-timeout {value}", ReadWriteTimeout)
              .Add("--retries {value}", Retries)
              .Add("--version", Version);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region BootsSettingsExtensions
    /// <summary>
    ///   Used within <see cref="BootsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class BootsSettingsExtensions
    {
        #region Stable
        /// <summary>
        ///   <p><em>Sets <see cref="BootsSettings.Stable"/></em></p>
        ///   <p>Install the latest <em>stable</em> version of a product from VS manifests. Options include: <c>Xamarin.Android</c>, <c>Xamarin.iOS</c>, <c>Xamarin.Mac</c>, and <c>Mono</c></p>
        /// </summary>
        [Pure]
        public static T SetStable<T>(this T toolSettings, BootsProductType stable) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Stable = stable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BootsSettings.Stable"/></em></p>
        ///   <p>Install the latest <em>stable</em> version of a product from VS manifests. Options include: <c>Xamarin.Android</c>, <c>Xamarin.iOS</c>, <c>Xamarin.Mac</c>, and <c>Mono</c></p>
        /// </summary>
        [Pure]
        public static T ResetStable<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Stable = null;
            return toolSettings;
        }
        #endregion
        #region Preview
        /// <summary>
        ///   <p><em>Sets <see cref="BootsSettings.Preview"/></em></p>
        ///   <p>Install the latest <em>preview</em> version of a product from VS manifests. Options include: <c>Xamarin.Android</c>, <c>Xamarin.iOS</c>, <c>Xamarin.Mac</c>, and <c>Mono</c></p>
        /// </summary>
        [Pure]
        public static T SetPreview<T>(this T toolSettings, BootsProductType preview) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preview = preview;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BootsSettings.Preview"/></em></p>
        ///   <p>Install the latest <em>preview</em> version of a product from VS manifests. Options include: <c>Xamarin.Android</c>, <c>Xamarin.iOS</c>, <c>Xamarin.Mac</c>, and <c>Mono</c></p>
        /// </summary>
        [Pure]
        public static T ResetPreview<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Preview = null;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="BootsSettings.Url"/></em></p>
        ///   <p>A Url to a <c>pkg</c> or <c>vsix</c> file to install</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BootsSettings.Url"/></em></p>
        ///   <p>A Url to a <c>pkg</c> or <c>vsix</c> file to install</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region FileType
        /// <summary>
        ///   <p><em>Sets <see cref="BootsSettings.FileType"/></em></p>
        ///   <p>Specifies the type of file to be installed such as <c>vsix</c>, <c>pkg</c>, or <c>msi</c>. Defaults to <c>vsix</c> on Windows and <c>pkg</c> on macOS</p>
        /// </summary>
        [Pure]
        public static T SetFileType<T>(this T toolSettings, BootsFileType fileType) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileType = fileType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BootsSettings.FileType"/></em></p>
        ///   <p>Specifies the type of file to be installed such as <c>vsix</c>, <c>pkg</c>, or <c>msi</c>. Defaults to <c>vsix</c> on Windows and <c>pkg</c> on macOS</p>
        /// </summary>
        [Pure]
        public static T ResetFileType<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileType = null;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="BootsSettings.Timeout"/></em></p>
        ///   <p>Specifies a timeout for <c>HttpClient</c>. If omitted, uses the .NET default of 100 seconds</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, int? timeout) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BootsSettings.Timeout"/></em></p>
        ///   <p>Specifies a timeout for <c>HttpClient</c>. If omitted, uses the .NET default of 100 seconds</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region ReadWriteTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="BootsSettings.ReadWriteTimeout"/></em></p>
        ///   <p>Specifies a timeout for reading/writing from a <c>HttpClient</c> stream. If omitted, uses a default of 300 seconds</p>
        /// </summary>
        [Pure]
        public static T SetReadWriteTimeout<T>(this T toolSettings, int? readWriteTimeout) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReadWriteTimeout = readWriteTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BootsSettings.ReadWriteTimeout"/></em></p>
        ///   <p>Specifies a timeout for reading/writing from a <c>HttpClient</c> stream. If omitted, uses a default of 300 seconds</p>
        /// </summary>
        [Pure]
        public static T ResetReadWriteTimeout<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReadWriteTimeout = null;
            return toolSettings;
        }
        #endregion
        #region Retries
        /// <summary>
        ///   <p><em>Sets <see cref="BootsSettings.Retries"/></em></p>
        ///   <p>Specifies a number of retries for <c>HttpClient</c> failures. If omitted, uses a default of 3 retries</p>
        /// </summary>
        [Pure]
        public static T SetRetries<T>(this T toolSettings, int? retries) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Retries = retries;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BootsSettings.Retries"/></em></p>
        ///   <p>Specifies a number of retries for <c>HttpClient</c> failures. If omitted, uses a default of 3 retries</p>
        /// </summary>
        [Pure]
        public static T ResetRetries<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Retries = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="BootsSettings.Version"/></em></p>
        ///   <p>Show version information</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="BootsSettings.Version"/></em></p>
        ///   <p>Show version information</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="BootsSettings.Version"/></em></p>
        ///   <p>Show version information</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="BootsSettings.Version"/></em></p>
        ///   <p>Show version information</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="BootsSettings.Version"/></em></p>
        ///   <p>Show version information</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : BootsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region BootsProductType
    /// <summary>
    ///   Used within <see cref="BootsTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="BootsTasks"/>.
    /// </summary>
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
}
