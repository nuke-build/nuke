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
        public static IReadOnlyCollection<Output> CleanupCode(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(CleanupCodePath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, CleanupCodeLogger, outputFilter);
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
        ///     <li><c>--dotnetcore</c> via <see cref="CleanupCodeSettings.DotNetPath"/></li>
        ///     <li><c>--exclude</c> via <see cref="CleanupCodeSettings.Exclude"/></li>
        ///     <li><c>--include</c> via <see cref="CleanupCodeSettings.Include"/></li>
        ///     <li><c>--mono</c> via <see cref="CleanupCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="CleanupCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--profile</c> via <see cref="CleanupCodeSettings.Profile"/></li>
        ///     <li><c>--project</c> via <see cref="CleanupCodeSettings.Project"/></li>
        ///     <li><c>--properties</c> via <see cref="CleanupCodeSettings.Properties"/></li>
        ///     <li><c>--toolset</c> via <see cref="CleanupCodeSettings.Toolset"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CleanupCode(CleanupCodeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CleanupCodeSettings();
            PreProcess(ref toolSettings);
            var process = StartProcess(toolSettings);
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
        ///     <li><c>--dotnetcore</c> via <see cref="CleanupCodeSettings.DotNetPath"/></li>
        ///     <li><c>--exclude</c> via <see cref="CleanupCodeSettings.Exclude"/></li>
        ///     <li><c>--include</c> via <see cref="CleanupCodeSettings.Include"/></li>
        ///     <li><c>--mono</c> via <see cref="CleanupCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="CleanupCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--profile</c> via <see cref="CleanupCodeSettings.Profile"/></li>
        ///     <li><c>--project</c> via <see cref="CleanupCodeSettings.Project"/></li>
        ///     <li><c>--properties</c> via <see cref="CleanupCodeSettings.Properties"/></li>
        ///     <li><c>--toolset</c> via <see cref="CleanupCodeSettings.Toolset"/></li>
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
        ///     <li><c>--dotnetcore</c> via <see cref="CleanupCodeSettings.DotNetPath"/></li>
        ///     <li><c>--exclude</c> via <see cref="CleanupCodeSettings.Exclude"/></li>
        ///     <li><c>--include</c> via <see cref="CleanupCodeSettings.Include"/></li>
        ///     <li><c>--mono</c> via <see cref="CleanupCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="CleanupCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--profile</c> via <see cref="CleanupCodeSettings.Profile"/></li>
        ///     <li><c>--project</c> via <see cref="CleanupCodeSettings.Project"/></li>
        ///     <li><c>--properties</c> via <see cref="CleanupCodeSettings.Properties"/></li>
        ///     <li><c>--toolset</c> via <see cref="CleanupCodeSettings.Toolset"/></li>
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
        ///   Specifies an additional .DotSettings file used for inspection settings.
        /// </summary>
        public virtual string Profile { get; internal set; }
        /// <summary>
        ///   Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c>
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   relative path(s) that define the files to include during the cleanup.
        /// </summary>
        public virtual IReadOnlyList<string> Include => IncludeInternal.AsReadOnly();
        internal List<string> IncludeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   relative path(s) that define the files to exclude during the cleanup.
        /// </summary>
        public virtual IReadOnlyList<string> Exclude => ExcludeInternal.AsReadOnly();
        internal List<string> ExcludeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.
        /// </summary>
        public virtual IReadOnlyList<CleanupCodeSettingsLayers> DisableSettingsLayers => DisableSettingsLayersInternal.AsReadOnly();
        internal List<CleanupCodeSettingsLayers> DisableSettingsLayersInternal { get; set; } = new List<CleanupCodeSettingsLayers>();
        /// <summary>
        ///   Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c>
        /// </summary>
        public virtual bool? NoBuiltinSettings { get; internal set; }
        /// <summary>
        ///   Lets you specify a custom location for the data that CleanupCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.
        /// </summary>
        public virtual string CachesHome { get; internal set; }
        /// <summary>
        ///   Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.
        /// </summary>
        public virtual IReadOnlyList<string> Extensions => ExtensionsInternal.AsReadOnly();
        internal List<string> ExtensionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.
        /// </summary>
        public virtual CleanupCodeMSBuildToolset Toolset { get; internal set; }
        /// <summary>
        ///   Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c>
        /// </summary>
        public virtual string MonoPath { get; internal set; }
        /// <summary>
        ///   .NET Core path. Empty to ignore .NET Core. Not specified for autodetect. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet.</c>
        /// </summary>
        public virtual string DotNetPath { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", TargetPath)
              .Add("--profile={value}", Profile)
              .Add("--project={value}", Project)
              .Add("--include={value}", Include, separator: ';')
              .Add("--exclude={value}", Exclude, separator: ';')
              .Add("--disable-settings-layers={value}", DisableSettingsLayers, separator: ';')
              .Add("--no-buildin-settings", NoBuiltinSettings)
              .Add("--caches-home={value}", CachesHome)
              .Add("--properties={value}", Properties, "{key}={value}")
              .Add("--toolset={value}", Toolset)
              .Add("--mono={value}", MonoPath)
              .Add("--dotnetcore={value}", DotNetPath);
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
        public static CleanupCodeSettings SetTargetPath(this CleanupCodeSettings toolSettings, string targetPath)
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
        public static CleanupCodeSettings ResetTargetPath(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region Profile
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Profile"/></em></p>
        ///   <p>Specifies an additional .DotSettings file used for inspection settings.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetProfile(this CleanupCodeSettings toolSettings, string profile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = profile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.Profile"/></em></p>
        ///   <p>Specifies an additional .DotSettings file used for inspection settings.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings ResetProfile(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Project"/></em></p>
        ///   <p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetProject(this CleanupCodeSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.Project"/></em></p>
        ///   <p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings ResetProject(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Include
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Include"/> to a new list</em></p>
        ///   <p>relative path(s) that define the files to include during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetInclude(this CleanupCodeSettings toolSettings, params string[] include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Include"/> to a new list</em></p>
        ///   <p>relative path(s) that define the files to include during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetInclude(this CleanupCodeSettings toolSettings, IEnumerable<string> include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.Include"/></em></p>
        ///   <p>relative path(s) that define the files to include during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings AddInclude(this CleanupCodeSettings toolSettings, params string[] include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.Include"/></em></p>
        ///   <p>relative path(s) that define the files to include during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings AddInclude(this CleanupCodeSettings toolSettings, IEnumerable<string> include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.Include"/></em></p>
        ///   <p>relative path(s) that define the files to include during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings ClearInclude(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.Include"/></em></p>
        ///   <p>relative path(s) that define the files to include during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings RemoveInclude(this CleanupCodeSettings toolSettings, params string[] include)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.Include"/></em></p>
        ///   <p>relative path(s) that define the files to include during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings RemoveInclude(this CleanupCodeSettings toolSettings, IEnumerable<string> include)
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
        ///   <p>relative path(s) that define the files to exclude during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetExclude(this CleanupCodeSettings toolSettings, params string[] exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Exclude"/> to a new list</em></p>
        ///   <p>relative path(s) that define the files to exclude during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetExclude(this CleanupCodeSettings toolSettings, IEnumerable<string> exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.Exclude"/></em></p>
        ///   <p>relative path(s) that define the files to exclude during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings AddExclude(this CleanupCodeSettings toolSettings, params string[] exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.Exclude"/></em></p>
        ///   <p>relative path(s) that define the files to exclude during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings AddExclude(this CleanupCodeSettings toolSettings, IEnumerable<string> exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.Exclude"/></em></p>
        ///   <p>relative path(s) that define the files to exclude during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings ClearExclude(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.Exclude"/></em></p>
        ///   <p>relative path(s) that define the files to exclude during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings RemoveExclude(this CleanupCodeSettings toolSettings, params string[] exclude)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.Exclude"/></em></p>
        ///   <p>relative path(s) that define the files to exclude during the cleanup.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings RemoveExclude(this CleanupCodeSettings toolSettings, IEnumerable<string> exclude)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DisableSettingsLayers
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.DisableSettingsLayers"/> to a new list</em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetDisableSettingsLayers(this CleanupCodeSettings toolSettings, params CleanupCodeSettingsLayers[] disableSettingsLayers)
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
        public static CleanupCodeSettings SetDisableSettingsLayers(this CleanupCodeSettings toolSettings, IEnumerable<CleanupCodeSettingsLayers> disableSettingsLayers)
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
        public static CleanupCodeSettings AddDisableSettingsLayers(this CleanupCodeSettings toolSettings, params CleanupCodeSettingsLayers[] disableSettingsLayers)
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
        public static CleanupCodeSettings AddDisableSettingsLayers(this CleanupCodeSettings toolSettings, IEnumerable<CleanupCodeSettingsLayers> disableSettingsLayers)
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
        public static CleanupCodeSettings ClearDisableSettingsLayers(this CleanupCodeSettings toolSettings)
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
        public static CleanupCodeSettings RemoveDisableSettingsLayers(this CleanupCodeSettings toolSettings, params CleanupCodeSettingsLayers[] disableSettingsLayers)
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
        public static CleanupCodeSettings RemoveDisableSettingsLayers(this CleanupCodeSettings toolSettings, IEnumerable<CleanupCodeSettingsLayers> disableSettingsLayers)
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
        public static CleanupCodeSettings SetNoBuiltinSettings(this CleanupCodeSettings toolSettings, bool? noBuiltinSettings)
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
        public static CleanupCodeSettings ResetNoBuiltinSettings(this CleanupCodeSettings toolSettings)
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
        public static CleanupCodeSettings EnableNoBuiltinSettings(this CleanupCodeSettings toolSettings)
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
        public static CleanupCodeSettings DisableNoBuiltinSettings(this CleanupCodeSettings toolSettings)
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
        public static CleanupCodeSettings ToggleNoBuiltinSettings(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = !toolSettings.NoBuiltinSettings;
            return toolSettings;
        }
        #endregion
        #region CachesHome
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the data that CleanupCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetCachesHome(this CleanupCodeSettings toolSettings, string cachesHome)
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
        public static CleanupCodeSettings ResetCachesHome(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = null;
            return toolSettings;
        }
        #endregion
        #region Extensions
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Extensions"/> to a new list</em></p>
        ///   <p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetExtensions(this CleanupCodeSettings toolSettings, params string[] extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal = extensions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Extensions"/> to a new list</em></p>
        ///   <p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetExtensions(this CleanupCodeSettings toolSettings, IEnumerable<string> extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal = extensions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.Extensions"/></em></p>
        ///   <p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings AddExtensions(this CleanupCodeSettings toolSettings, params string[] extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal.AddRange(extensions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CleanupCodeSettings.Extensions"/></em></p>
        ///   <p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings AddExtensions(this CleanupCodeSettings toolSettings, IEnumerable<string> extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal.AddRange(extensions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.Extensions"/></em></p>
        ///   <p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings ClearExtensions(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.Extensions"/></em></p>
        ///   <p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings RemoveExtensions(this CleanupCodeSettings toolSettings, params string[] extensions)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extensions);
            toolSettings.ExtensionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CleanupCodeSettings.Extensions"/></em></p>
        ///   <p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings RemoveExtensions(this CleanupCodeSettings toolSettings, IEnumerable<string> extensions)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extensions);
            toolSettings.ExtensionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetProperties(this CleanupCodeSettings toolSettings, IDictionary<string, string> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CleanupCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings ClearProperties(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="CleanupCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings AddProperty(this CleanupCodeSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="CleanupCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings RemoveProperty(this CleanupCodeSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="CleanupCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetProperty(this CleanupCodeSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
        #region Toolset
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.Toolset"/></em></p>
        ///   <p>Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetToolset(this CleanupCodeSettings toolSettings, CleanupCodeMSBuildToolset toolset)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = toolset;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.Toolset"/></em></p>
        ///   <p>Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.</p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings ResetToolset(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = null;
            return toolSettings;
        }
        #endregion
        #region MonoPath
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.MonoPath"/></em></p>
        ///   <p>Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c></p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetMonoPath(this CleanupCodeSettings toolSettings, string monoPath)
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
        public static CleanupCodeSettings ResetMonoPath(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MonoPath = null;
            return toolSettings;
        }
        #endregion
        #region DotNetPath
        /// <summary>
        ///   <p><em>Sets <see cref="CleanupCodeSettings.DotNetPath"/></em></p>
        ///   <p>.NET Core path. Empty to ignore .NET Core. Not specified for autodetect. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet.</c></p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings SetDotNetPath(this CleanupCodeSettings toolSettings, string dotNetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetPath = dotNetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CleanupCodeSettings.DotNetPath"/></em></p>
        ///   <p>.NET Core path. Empty to ignore .NET Core. Not specified for autodetect. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet.</c></p>
        /// </summary>
        [Pure]
        public static CleanupCodeSettings ResetDotNetPath(this CleanupCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetPath = null;
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
        public static explicit operator CleanupCodeMSBuildToolset(string value)
        {
            return new CleanupCodeMSBuildToolset { Value = value };
        }
    }
    #endregion
}
