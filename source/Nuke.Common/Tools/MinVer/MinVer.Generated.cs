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

namespace Nuke.Common.Tools.MinVer
{
    /// <summary>
    ///   <p>Minimalistic versioning using Git tags.</p>
    ///   <p>For more details, visit the <a href="https://github.com/adamralph/minver">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(MinVerPackageId)]
    public partial class MinVerTasks
        : IRequireNuGetPackage
    {
        public const string MinVerPackageId = "minver-cli";
        /// <summary>
        ///   Path to the MinVer executable.
        /// </summary>
        public static string MinVerPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("MINVER_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> MinVerLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Minimalistic versioning using Git tags.</p>
        ///   <p>For more details, visit the <a href="https://github.com/adamralph/minver">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> MinVer(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(MinVerPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? MinVerLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Minimalistic versioning using Git tags.</p>
        ///   <p>For more details, visit the <a href="https://github.com/adamralph/minver">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--auto-increment</c> via <see cref="MinVerSettings.AutoIncrement"/></li>
        ///     <li><c>--build-metadata</c> via <see cref="MinVerSettings.BuildMetadata"/></li>
        ///     <li><c>--default-pre-release-phase</c> via <see cref="MinVerSettings.DefaultPreReleasePhase"/></li>
        ///     <li><c>--minimum-major-minor</c> via <see cref="MinVerSettings.MinimumMajorMinor"/></li>
        ///     <li><c>--tag-prefix</c> via <see cref="MinVerSettings.TagPrefix"/></li>
        ///     <li><c>--verbosity</c> via <see cref="MinVerSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static (MinVer Result, IReadOnlyCollection<Output> Output) MinVer(MinVerSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new MinVerSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return (GetResult(process, toolSettings), process.Output);
        }
        /// <summary>
        ///   <p>Minimalistic versioning using Git tags.</p>
        ///   <p>For more details, visit the <a href="https://github.com/adamralph/minver">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--auto-increment</c> via <see cref="MinVerSettings.AutoIncrement"/></li>
        ///     <li><c>--build-metadata</c> via <see cref="MinVerSettings.BuildMetadata"/></li>
        ///     <li><c>--default-pre-release-phase</c> via <see cref="MinVerSettings.DefaultPreReleasePhase"/></li>
        ///     <li><c>--minimum-major-minor</c> via <see cref="MinVerSettings.MinimumMajorMinor"/></li>
        ///     <li><c>--tag-prefix</c> via <see cref="MinVerSettings.TagPrefix"/></li>
        ///     <li><c>--verbosity</c> via <see cref="MinVerSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static (MinVer Result, IReadOnlyCollection<Output> Output) MinVer(Configure<MinVerSettings> configurator)
        {
            return MinVer(configurator(new MinVerSettings()));
        }
        /// <summary>
        ///   <p>Minimalistic versioning using Git tags.</p>
        ///   <p>For more details, visit the <a href="https://github.com/adamralph/minver">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--auto-increment</c> via <see cref="MinVerSettings.AutoIncrement"/></li>
        ///     <li><c>--build-metadata</c> via <see cref="MinVerSettings.BuildMetadata"/></li>
        ///     <li><c>--default-pre-release-phase</c> via <see cref="MinVerSettings.DefaultPreReleasePhase"/></li>
        ///     <li><c>--minimum-major-minor</c> via <see cref="MinVerSettings.MinimumMajorMinor"/></li>
        ///     <li><c>--tag-prefix</c> via <see cref="MinVerSettings.TagPrefix"/></li>
        ///     <li><c>--verbosity</c> via <see cref="MinVerSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(MinVerSettings Settings, MinVer Result, IReadOnlyCollection<Output> Output)> MinVer(CombinatorialConfigure<MinVerSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(MinVer, MinVerLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region MinVerSettings
    /// <summary>
    ///   Used within <see cref="MinVerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class MinVerSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the MinVer executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? MinVerTasks.MinVerLogger;
        public virtual MinVerVersionPart AutoIncrement { get; internal set; }
        public virtual string BuildMetadata { get; internal set; }
        public virtual string DefaultPreReleasePhase { get; internal set; }
        public virtual string MinimumMajorMinor { get; internal set; }
        public virtual string TagPrefix { get; internal set; }
        public virtual MinVerVerbosity Verbosity { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("--auto-increment {value}", AutoIncrement)
              .Add("--build-metadata {value}", BuildMetadata)
              .Add("--default-pre-release-phase {value}", DefaultPreReleasePhase)
              .Add("--minimum-major-minor {value}", MinimumMajorMinor)
              .Add("--tag-prefix {value}", TagPrefix)
              .Add("--verbosity {value}", Verbosity);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region MinVer
    /// <summary>
    ///   Used within <see cref="MinVerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class MinVer : ISettingsEntity
    {
        public virtual string MinVerVersion { get; internal set; }
        public virtual string MinVerMajor { get; internal set; }
        public virtual string MinVerMinor { get; internal set; }
        public virtual string MinVerPatch { get; internal set; }
        public virtual string MinVerPreRelease { get; internal set; }
        public virtual string MinVerBuildMetadata { get; internal set; }
        public virtual string AssemblyVersion { get; internal set; }
        public virtual string FileVersion { get; internal set; }
        public virtual string PackageVersion { get; internal set; }
        public virtual string Version { get; internal set; }
    }
    #endregion
    #region MinVerSettingsExtensions
    /// <summary>
    ///   Used within <see cref="MinVerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MinVerSettingsExtensions
    {
        #region AutoIncrement
        /// <summary>
        ///   <p><em>Sets <see cref="MinVerSettings.AutoIncrement"/></em></p>
        /// </summary>
        [Pure]
        public static T SetAutoIncrement<T>(this T toolSettings, MinVerVersionPart autoIncrement) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoIncrement = autoIncrement;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MinVerSettings.AutoIncrement"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetAutoIncrement<T>(this T toolSettings) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoIncrement = null;
            return toolSettings;
        }
        #endregion
        #region BuildMetadata
        /// <summary>
        ///   <p><em>Sets <see cref="MinVerSettings.BuildMetadata"/></em></p>
        /// </summary>
        [Pure]
        public static T SetBuildMetadata<T>(this T toolSettings, string buildMetadata) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildMetadata = buildMetadata;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MinVerSettings.BuildMetadata"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetBuildMetadata<T>(this T toolSettings) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildMetadata = null;
            return toolSettings;
        }
        #endregion
        #region DefaultPreReleasePhase
        /// <summary>
        ///   <p><em>Sets <see cref="MinVerSettings.DefaultPreReleasePhase"/></em></p>
        /// </summary>
        [Pure]
        public static T SetDefaultPreReleasePhase<T>(this T toolSettings, string defaultPreReleasePhase) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPreReleasePhase = defaultPreReleasePhase;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MinVerSettings.DefaultPreReleasePhase"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetDefaultPreReleasePhase<T>(this T toolSettings) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPreReleasePhase = null;
            return toolSettings;
        }
        #endregion
        #region MinimumMajorMinor
        /// <summary>
        ///   <p><em>Sets <see cref="MinVerSettings.MinimumMajorMinor"/></em></p>
        /// </summary>
        [Pure]
        public static T SetMinimumMajorMinor<T>(this T toolSettings, string minimumMajorMinor) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumMajorMinor = minimumMajorMinor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MinVerSettings.MinimumMajorMinor"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetMinimumMajorMinor<T>(this T toolSettings) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumMajorMinor = null;
            return toolSettings;
        }
        #endregion
        #region TagPrefix
        /// <summary>
        ///   <p><em>Sets <see cref="MinVerSettings.TagPrefix"/></em></p>
        /// </summary>
        [Pure]
        public static T SetTagPrefix<T>(this T toolSettings, string tagPrefix) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagPrefix = tagPrefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MinVerSettings.TagPrefix"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetTagPrefix<T>(this T toolSettings) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagPrefix = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="MinVerSettings.Verbosity"/></em></p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, MinVerVerbosity verbosity) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MinVerSettings.Verbosity"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="MinVerSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MinVerSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : MinVerSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region MinVerVerbosity
    /// <summary>
    ///   Used within <see cref="MinVerTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="MinVerTasks"/>.
    /// </summary>
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
}
