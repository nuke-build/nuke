// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/CleanupCode.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
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

namespace Nuke.Common.Tools.CleanupCode
{
    /// <summary>
    ///   <p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p>
    ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/CleanupCode.html">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CleanupCodeTasks
    {
        /// <summary>
        ///   Path to the CleanupCode executable.
        /// </summary>
        public static string CleanupCodePath =>
            ToolPathResolver.TryGetEnvironmentExecutable("CLEANUPCODE_EXE") ??
            ToolPathResolver.GetPackageExecutable("JetBrains.ReSharper.CommandLineTools", GetPackageExecutable());
        public static Action<OutputType, string> CleanupCodeLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/CleanupCode.html">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> CleanupCode(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, bool? logTimestamp = null, string logFile = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(CleanupCodePath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logTimestamp, logFile, CleanupCodeLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/CleanupCode.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="CleanupCodeSettings.TargetPath"/></li>
        ///     <li><c>--caches-home</c> via <see cref="CleanupCodeSettings.CachesHome"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="CleanupCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dotnetcore</c> via <see cref="CleanupCodeSettings.DotNetCore"/></li>
        ///     <li><c>--dotnetcoresdk</c> via <see cref="CleanupCodeSettings.DotNetCoreSdk"/></li>
        ///     <li><c>--exclude</c> via <see cref="CleanupCodeSettings.Exclude"/></li>
        ///     <li><c>--include</c> via <see cref="CleanupCodeSettings.Include"/></li>
        ///     <li><c>--mono</c> via <see cref="CleanupCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="CleanupCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--profile</c> via <see cref="CleanupCodeSettings.Profile"/></li>
        ///     <li><c>--properties</c> via <see cref="CleanupCodeSettings.Properties"/></li>
        ///     <li><c>--targets-for-items</c> via <see cref="CleanupCodeSettings.ItemTargets"/></li>
        ///     <li><c>--targets-for-references</c> via <see cref="CleanupCodeSettings.ReferenceTargets"/></li>
        ///     <li><c>--toolset</c> via <see cref="CleanupCodeSettings.Toolset"/></li>
        ///     <li><c>--toolset-path</c> via <see cref="CleanupCodeSettings.ToolsetPath"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CleanupCode(CleanupCodeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CleanupCodeSettings();
            PreProcess(ref toolSettings);
            using var process = StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/CleanupCode.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="CleanupCodeSettings.TargetPath"/></li>
        ///     <li><c>--caches-home</c> via <see cref="CleanupCodeSettings.CachesHome"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="CleanupCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dotnetcore</c> via <see cref="CleanupCodeSettings.DotNetCore"/></li>
        ///     <li><c>--dotnetcoresdk</c> via <see cref="CleanupCodeSettings.DotNetCoreSdk"/></li>
        ///     <li><c>--exclude</c> via <see cref="CleanupCodeSettings.Exclude"/></li>
        ///     <li><c>--include</c> via <see cref="CleanupCodeSettings.Include"/></li>
        ///     <li><c>--mono</c> via <see cref="CleanupCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="CleanupCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--profile</c> via <see cref="CleanupCodeSettings.Profile"/></li>
        ///     <li><c>--properties</c> via <see cref="CleanupCodeSettings.Properties"/></li>
        ///     <li><c>--targets-for-items</c> via <see cref="CleanupCodeSettings.ItemTargets"/></li>
        ///     <li><c>--targets-for-references</c> via <see cref="CleanupCodeSettings.ReferenceTargets"/></li>
        ///     <li><c>--toolset</c> via <see cref="CleanupCodeSettings.Toolset"/></li>
        ///     <li><c>--toolset-path</c> via <see cref="CleanupCodeSettings.ToolsetPath"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CleanupCode(Configure<CleanupCodeSettings> configurator)
        {
            return CleanupCode(configurator(new CleanupCodeSettings()));
        }
        /// <summary>
        ///   <p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/CleanupCode.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="CleanupCodeSettings.TargetPath"/></li>
        ///     <li><c>--caches-home</c> via <see cref="CleanupCodeSettings.CachesHome"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="CleanupCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dotnetcore</c> via <see cref="CleanupCodeSettings.DotNetCore"/></li>
        ///     <li><c>--dotnetcoresdk</c> via <see cref="CleanupCodeSettings.DotNetCoreSdk"/></li>
        ///     <li><c>--exclude</c> via <see cref="CleanupCodeSettings.Exclude"/></li>
        ///     <li><c>--include</c> via <see cref="CleanupCodeSettings.Include"/></li>
        ///     <li><c>--mono</c> via <see cref="CleanupCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="CleanupCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--profile</c> via <see cref="CleanupCodeSettings.Profile"/></li>
        ///     <li><c>--properties</c> via <see cref="CleanupCodeSettings.Properties"/></li>
        ///     <li><c>--targets-for-items</c> via <see cref="CleanupCodeSettings.ItemTargets"/></li>
        ///     <li><c>--targets-for-references</c> via <see cref="CleanupCodeSettings.ReferenceTargets"/></li>
        ///     <li><c>--toolset</c> via <see cref="CleanupCodeSettings.Toolset"/></li>
        ///     <li><c>--toolset-path</c> via <see cref="CleanupCodeSettings.ToolsetPath"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CleanupCodeSettings Settings, IReadOnlyCollection<Output> Output)> CleanupCode(CombinatorialConfigure<CleanupCodeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CleanupCode, CleanupCodeLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region CleanupCodeSettings
    /// <summary>
    ///   Used within <see cref="CleanupCodeTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CleanupCodeSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CleanupCode executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CleanupCodeTasks.CleanupCodePath;
        public override Action<OutputType, string> CustomLogger => CleanupCodeTasks.CleanupCodeLogger;
        /// <summary>
        ///   Target path.
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   A code cleanup profile that lists cleanup tasks to execute.<p/>By default, CleanupCode will apply code cleanup tasks specified in the <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#profiles">Built-in: Full Cleanup profile</a>, that is all <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#tasks">available cleanup tasks</a> tasks except <a href="https://www.jetbrains.com/help/resharper/File_Header_Style.html">updating file header</a>. 
        /// </summary>
        public virtual string Profile { get; internal set; }
        /// <summary>
        ///   Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.
        /// </summary>
        public virtual IReadOnlyList<string> Include => IncludeInternal.AsReadOnly();
        internal List<string> IncludeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.
        /// </summary>
        public virtual IReadOnlyList<string> Exclude => ExcludeInternal.AsReadOnly();
        internal List<string> ExcludeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.
        /// </summary>
        public virtual CleanupCodeMSBuildToolset Toolset { get; internal set; }
        /// <summary>
        ///   Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c>
        /// </summary>
        public virtual string ToolsetPath { get; internal set; }
        /// <summary>
        ///   By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.
        /// </summary>
        public virtual string DotNetCore { get; internal set; }
        /// <summary>
        ///   Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.
        /// </summary>
        public virtual string DotNetCoreSdk { get; internal set; }
        /// <summary>
        ///   Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c>
        /// </summary>
        public virtual string MonoPath { get; internal set; }
        /// <summary>
        ///   Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.
        /// </summary>
        public virtual IReadOnlyList<string> ReferenceTargets => ReferenceTargetsInternal.AsReadOnly();
        internal List<string> ReferenceTargetsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.
        /// </summary>
        public virtual IReadOnlyList<string> ItemTargets => ItemTargetsInternal.AsReadOnly();
        internal List<string> ItemTargetsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Lets you specify a custom location for the data that CleanupCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.
        /// </summary>
        public virtual string CachesHome { get; internal set; }
        /// <summary>
        ///   Allows adding ReSharper plugins that will get included during code cleanup. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>CleanupCodePluginLatest</c> or <c>null</c> will download the latest version.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Plugins => PluginsInternal.AsReadOnly();
        internal Dictionary<string, string> PluginsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.
        /// </summary>
        public virtual IReadOnlyList<CleanupCodeSettingsLayers> DisableSettingsLayers => DisableSettingsLayersInternal.AsReadOnly();
        internal List<CleanupCodeSettingsLayers> DisableSettingsLayersInternal { get; set; } = new List<CleanupCodeSettingsLayers>();
        /// <summary>
        ///   Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c>
        /// </summary>
        public virtual bool? NoBuiltinSettings { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", TargetPath)
              .Add("--profile={value}", Profile)
              .Add("--include={value}", Include, separator: ';')
              .Add("--exclude={value}", Exclude, separator: ';')
              .Add("--properties={value}", Properties, "{key}={value}")
              .Add("--toolset={value}", Toolset)
              .Add("--toolset-path={value}", ToolsetPath)
              .Add("--dotnetcore={value}", DotNetCore)
              .Add("--dotnetcoresdk={value}", DotNetCoreSdk)
              .Add("--mono={value}", MonoPath)
              .Add("--targets-for-references={value}", ReferenceTargets, separator: ';')
              .Add("--targets-for-items={value}", ItemTargets, separator: ';')
              .Add("--caches-home={value}", CachesHome)
              .Add("--disable-settings-layers={value}", DisableSettingsLayers, separator: ';')
              .Add("--no-buildin-settings", NoBuiltinSettings);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CleanupCodeSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CleanupCodeTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CleanupCodeSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.TargetPath"/></em></p>
        ///   <p>Target path.</p>
        /// </summary>
        [Pure]
        public static T SetTargetPath<T>(this T toolSettings, string targetPath) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.TargetPath"/></em></p>
        ///   <p>Target path.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPath<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region Profile
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Profile"/></em></p>
        ///   <p>A code cleanup profile that lists cleanup tasks to execute.<p/>By default, CleanupCode will apply code cleanup tasks specified in the <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#profiles">Built-in: Full Cleanup profile</a>, that is all <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#tasks">available cleanup tasks</a> tasks except <a href="https://www.jetbrains.com/help/resharper/File_Header_Style.html">updating file header</a>. </p>
        /// </summary>
        [Pure]
        public static T SetProfile<T>(this T toolSettings, string profile) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = profile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.Profile"/></em></p>
        ///   <p>A code cleanup profile that lists cleanup tasks to execute.<p/>By default, CleanupCode will apply code cleanup tasks specified in the <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#profiles">Built-in: Full Cleanup profile</a>, that is all <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#tasks">available cleanup tasks</a> tasks except <a href="https://www.jetbrains.com/help/resharper/File_Header_Style.html">updating file header</a>. </p>
        /// </summary>
        [Pure]
        public static T ResetProfile<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = null;
            return toolSettings;
        }
        #endregion
        #region Include
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Include"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetInclude<T>(this T toolSettings, params string[] include) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Include"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetInclude<T>(this T toolSettings, IEnumerable<string> include) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddInclude<T>(this T toolSettings, params string[] include) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddInclude<T>(this T toolSettings, IEnumerable<string> include) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T ClearInclude<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveInclude<T>(this T toolSettings, params string[] include) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveInclude<T>(this T toolSettings, IEnumerable<string> include) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Exclude
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Exclude"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetExclude<T>(this T toolSettings, params string[] exclude) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Exclude"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddExclude<T>(this T toolSettings, params string[] exclude) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T ClearExclude<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveExclude<T>(this T toolSettings, params string[] exclude) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, string> properties) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.Properties"/></em></p>
        ///   <p>lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="CleanupCodeSettings.Properties"/></em></p>
        ///   <p>lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="CleanupCodeSettings.Properties"/></em></p>
        ///   <p>lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="CleanupCodeSettings.Properties"/></em></p>
        ///   <p>lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
        #region Toolset
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Toolset"/></em></p>
        ///   <p>Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.</p>
        /// </summary>
        [Pure]
        public static T SetToolset<T>(this T toolSettings, CleanupCodeMSBuildToolset toolset) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = toolset;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.Toolset"/></em></p>
        ///   <p>Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.</p>
        /// </summary>
        [Pure]
        public static T ResetToolset<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = null;
            return toolSettings;
        }
        #endregion
        #region ToolsetPath
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.ToolsetPath"/></em></p>
        ///   <p>Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c></p>
        /// </summary>
        [Pure]
        public static T SetToolsetPath<T>(this T toolSettings, string toolsetPath) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolsetPath = toolsetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.ToolsetPath"/></em></p>
        ///   <p>Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c></p>
        /// </summary>
        [Pure]
        public static T ResetToolsetPath<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolsetPath = null;
            return toolSettings;
        }
        #endregion
        #region DotNetCore
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.DotNetCore"/></em></p>
        ///   <p>By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDotNetCore<T>(this T toolSettings, string dotNetCore) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCore = dotNetCore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.DotNetCore"/></em></p>
        ///   <p>By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDotNetCore<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCore = null;
            return toolSettings;
        }
        #endregion
        #region DotNetCoreSdk
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.DotNetCoreSdk"/></em></p>
        ///   <p>Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.</p>
        /// </summary>
        [Pure]
        public static T SetDotNetCoreSdk<T>(this T toolSettings, string dotNetCoreSdk) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCoreSdk = dotNetCoreSdk;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.DotNetCoreSdk"/></em></p>
        ///   <p>Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.</p>
        /// </summary>
        [Pure]
        public static T ResetDotNetCoreSdk<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCoreSdk = null;
            return toolSettings;
        }
        #endregion
        #region MonoPath
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.MonoPath"/></em></p>
        ///   <p>Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c></p>
        /// </summary>
        [Pure]
        public static T SetMonoPath<T>(this T toolSettings, string monoPath) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MonoPath = monoPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.MonoPath"/></em></p>
        ///   <p>Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c></p>
        /// </summary>
        [Pure]
        public static T ResetMonoPath<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MonoPath = null;
            return toolSettings;
        }
        #endregion
        #region ReferenceTargets
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.ReferenceTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetReferenceTargets<T>(this T toolSettings, params string[] referenceTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal = referenceTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.ReferenceTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetReferenceTargets<T>(this T toolSettings, IEnumerable<string> referenceTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal = referenceTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddReferenceTargets<T>(this T toolSettings, params string[] referenceTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal.AddRange(referenceTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddReferenceTargets<T>(this T toolSettings, IEnumerable<string> referenceTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal.AddRange(referenceTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearReferenceTargets<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveReferenceTargets<T>(this T toolSettings, params string[] referenceTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referenceTargets);
            toolSettings.ReferenceTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveReferenceTargets<T>(this T toolSettings, IEnumerable<string> referenceTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referenceTargets);
            toolSettings.ReferenceTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ItemTargets
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.ItemTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetItemTargets<T>(this T toolSettings, params string[] itemTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal = itemTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.ItemTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetItemTargets<T>(this T toolSettings, IEnumerable<string> itemTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal = itemTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddItemTargets<T>(this T toolSettings, params string[] itemTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal.AddRange(itemTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddItemTargets<T>(this T toolSettings, IEnumerable<string> itemTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal.AddRange(itemTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearItemTargets<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveItemTargets<T>(this T toolSettings, params string[] itemTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(itemTargets);
            toolSettings.ItemTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveItemTargets<T>(this T toolSettings, IEnumerable<string> itemTargets) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(itemTargets);
            toolSettings.ItemTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region CachesHome
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the data that CleanupCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static T SetCachesHome<T>(this T toolSettings, string cachesHome) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = cachesHome;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the data that CleanupCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static T ResetCachesHome<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = null;
            return toolSettings;
        }
        #endregion
        #region Plugins
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Plugins"/> to a new dictionary</em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during code cleanup. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>CleanupCodePluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T SetPlugins<T>(this T toolSettings, IDictionary<string, string> plugins) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal = plugins.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during code cleanup. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>CleanupCodePluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T ClearPlugins<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="CleanupCodeSettings.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during code cleanup. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>CleanupCodePluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T AddPlugin<T>(this T toolSettings, string pluginKey, string pluginValue) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Add(pluginKey, pluginValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="CleanupCodeSettings.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during code cleanup. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>CleanupCodePluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T RemovePlugin<T>(this T toolSettings, string pluginKey) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Remove(pluginKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="CleanupCodeSettings.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during code cleanup. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>CleanupCodePluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T SetPlugin<T>(this T toolSettings, string pluginKey, string pluginValue) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal[pluginKey] = pluginValue;
            return toolSettings;
        }
        #endregion
        #region DisableSettingsLayers
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.DisableSettingsLayers"/> to a new list</em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDisableSettingsLayers<T>(this T toolSettings, params CleanupCodeSettingsLayers[] disableSettingsLayers) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.DisableSettingsLayers"/> to a new list</em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDisableSettingsLayers<T>(this T toolSettings, IEnumerable<CleanupCodeSettingsLayers> disableSettingsLayers) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T AddDisableSettingsLayers<T>(this T toolSettings, params CleanupCodeSettingsLayers[] disableSettingsLayers) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T AddDisableSettingsLayers<T>(this T toolSettings, IEnumerable<CleanupCodeSettingsLayers> disableSettingsLayers) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearDisableSettingsLayers<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveDisableSettingsLayers<T>(this T toolSettings, params CleanupCodeSettingsLayers[] disableSettingsLayers) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<CleanupCodeSettingsLayers>(disableSettingsLayers);
            toolSettings.DisableSettingsLayersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveDisableSettingsLayers<T>(this T toolSettings, IEnumerable<CleanupCodeSettingsLayers> disableSettingsLayers) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<CleanupCodeSettingsLayers>(disableSettingsLayers);
            toolSettings.DisableSettingsLayersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoBuiltinSettings
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T SetNoBuiltinSettings<T>(this T toolSettings, bool? noBuiltinSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = noBuiltinSettings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T ResetNoBuiltinSettings<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CleanupCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T EnableNoBuiltinSettings<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CleanupCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T DisableNoBuiltinSettings<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CleanupCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T ToggleNoBuiltinSettings<T>(this T toolSettings) where T : CleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = !toolSettings.NoBuiltinSettings;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CleanupCodeSettingsLayers
    /// <summary>
    ///   Used within <see cref="CleanupCodeTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<CleanupCodeSettingsLayers>))]
    public partial class CleanupCodeSettingsLayers : Enumeration
    {
        public static CleanupCodeSettingsLayers GlobalAll = (CleanupCodeSettingsLayers) "GlobalAll";
        public static CleanupCodeSettingsLayers GlobalPerProduct = (CleanupCodeSettingsLayers) "GlobalPerProduct";
        public static CleanupCodeSettingsLayers SolutionShared = (CleanupCodeSettingsLayers) "SolutionShared";
        public static CleanupCodeSettingsLayers SolutionPersonal = (CleanupCodeSettingsLayers) "SolutionPersonal";
        public static explicit operator CleanupCodeSettingsLayers(string value)
        {
            return new CleanupCodeSettingsLayers { Value = value };
        }
    }
    #endregion
    #region CleanupCodeMSBuildToolset
    /// <summary>
    ///   Used within <see cref="CleanupCodeTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<CleanupCodeMSBuildToolset>))]
    public partial class CleanupCodeMSBuildToolset : Enumeration
    {
        public static CleanupCodeMSBuildToolset _12_0 = (CleanupCodeMSBuildToolset) "12.0";
        public static CleanupCodeMSBuildToolset _14_0 = (CleanupCodeMSBuildToolset) "14.0";
        public static CleanupCodeMSBuildToolset _15_0 = (CleanupCodeMSBuildToolset) "15.0";
        public static CleanupCodeMSBuildToolset _16_0 = (CleanupCodeMSBuildToolset) "16.0";
        public static explicit operator CleanupCodeMSBuildToolset(string value)
        {
            return new CleanupCodeMSBuildToolset { Value = value };
        }
    }
    #endregion
}
