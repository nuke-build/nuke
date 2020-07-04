// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/InspectCode.json

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

namespace Nuke.Common.Tools.InspectCode
{
    /// <summary>
    ///   <p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p>
    ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class InspectCodeTasks
    {
        /// <summary>
        ///   Path to the InspectCode executable.
        /// </summary>
        public static string InspectCodePath =>
            ToolPathResolver.TryGetEnvironmentExecutable("INSPECTCODE_EXE") ??
            ToolPathResolver.GetPackageExecutable("JetBrains.ReSharper.CommandLineTools", GetPackageExecutable());
        public static Action<OutputType, string> InspectCodeLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> InspectCode(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(InspectCodePath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, InspectCodeLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="InspectCodeSettings.TargetPath"/></li>
        ///     <li><c>--caches-home</c> via <see cref="InspectCodeSettings.CachesHome"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="InspectCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dumpIssuesTypes</c> via <see cref="InspectCodeSettings.DumpIssuesTypes"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="InspectCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--no-swea</c> via <see cref="InspectCodeSettings.NoSwea"/></li>
        ///     <li><c>--output</c> via <see cref="InspectCodeSettings.Output"/></li>
        ///     <li><c>--profile</c> via <see cref="InspectCodeSettings.Profile"/></li>
        ///     <li><c>--project</c> via <see cref="InspectCodeSettings.Project"/></li>
        ///     <li><c>--properties</c> via <see cref="InspectCodeSettings.Properties"/></li>
        ///     <li><c>--toolset</c> via <see cref="InspectCodeSettings.Toolset"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> InspectCode(InspectCodeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new InspectCodeSettings();
            PreProcess(ref toolSettings);
            var process = StartProcess(toolSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
            return process.Output;
        }
        /// <summary>
        ///   <p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="InspectCodeSettings.TargetPath"/></li>
        ///     <li><c>--caches-home</c> via <see cref="InspectCodeSettings.CachesHome"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="InspectCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dumpIssuesTypes</c> via <see cref="InspectCodeSettings.DumpIssuesTypes"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="InspectCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--no-swea</c> via <see cref="InspectCodeSettings.NoSwea"/></li>
        ///     <li><c>--output</c> via <see cref="InspectCodeSettings.Output"/></li>
        ///     <li><c>--profile</c> via <see cref="InspectCodeSettings.Profile"/></li>
        ///     <li><c>--project</c> via <see cref="InspectCodeSettings.Project"/></li>
        ///     <li><c>--properties</c> via <see cref="InspectCodeSettings.Properties"/></li>
        ///     <li><c>--toolset</c> via <see cref="InspectCodeSettings.Toolset"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> InspectCode(Configure<InspectCodeSettings> configurator)
        {
            return InspectCode(configurator(new InspectCodeSettings()));
        }
        /// <summary>
        ///   <p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="InspectCodeSettings.TargetPath"/></li>
        ///     <li><c>--caches-home</c> via <see cref="InspectCodeSettings.CachesHome"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="InspectCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dumpIssuesTypes</c> via <see cref="InspectCodeSettings.DumpIssuesTypes"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="InspectCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--no-swea</c> via <see cref="InspectCodeSettings.NoSwea"/></li>
        ///     <li><c>--output</c> via <see cref="InspectCodeSettings.Output"/></li>
        ///     <li><c>--profile</c> via <see cref="InspectCodeSettings.Profile"/></li>
        ///     <li><c>--project</c> via <see cref="InspectCodeSettings.Project"/></li>
        ///     <li><c>--properties</c> via <see cref="InspectCodeSettings.Properties"/></li>
        ///     <li><c>--toolset</c> via <see cref="InspectCodeSettings.Toolset"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(InspectCodeSettings Settings, IReadOnlyCollection<Output> Output)> InspectCode(CombinatorialConfigure<InspectCodeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(InspectCode, InspectCodeLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region InspectCodeSettings
    /// <summary>
    ///   Used within <see cref="InspectCodeTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class InspectCodeSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the InspectCode executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? InspectCodeTasks.InspectCodePath;
        public override Action<OutputType, string> CustomLogger => InspectCodeTasks.InspectCodeLogger;
        /// <summary>
        ///   Target path.
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   Disables solution-wide analysis.
        /// </summary>
        public virtual bool? NoSwea { get; internal set; }
        /// <summary>
        ///   Specifies an additional .DotSettings file used for inspection settings.
        /// </summary>
        public virtual string Profile { get; internal set; }
        /// <summary>
        ///   Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c>
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.
        /// </summary>
        public virtual IReadOnlyList<InspectCodeSettingsLayers> DisableSettingsLayers => DisableSettingsLayersInternal.AsReadOnly();
        internal List<InspectCodeSettingsLayers> DisableSettingsLayersInternal { get; set; } = new List<InspectCodeSettingsLayers>();
        /// <summary>
        ///   Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c>
        /// </summary>
        public virtual bool? NoBuiltinSettings { get; internal set; }
        /// <summary>
        ///   Lets you specify a custom location for the data that InspectCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.
        /// </summary>
        public virtual string CachesHome { get; internal set; }
        /// <summary>
        ///   Allows adding ReSharper plugins that will get included during code analysis. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>InspectCodePluginLatest</c> or <c>null</c> will download the latest version.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Plugins => PluginsInternal.AsReadOnly();
        internal Dictionary<string, string> PluginsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.
        /// </summary>
        public virtual bool? DumpIssuesTypes { get; internal set; }
        /// <summary>
        ///   Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.
        /// </summary>
        public virtual InspectCodeMSBuildToolset Toolset { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", TargetPath)
              .Add("--output={value}", Output)
              .Add("--no-swea", NoSwea)
              .Add("--profile={value}", Profile)
              .Add("--project={value}", Project)
              .Add("--disable-settings-layers={value}", DisableSettingsLayers, separator: ';')
              .Add("--no-buildin-settings", NoBuiltinSettings)
              .Add("--caches-home={value}", CachesHome)
              .Add("--properties={value}", Properties, "{key}={value}")
              .Add("--dumpIssuesTypes", DumpIssuesTypes)
              .Add("--toolset={value}", Toolset);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region InspectCodeSettingsExtensions
    /// <summary>
    ///   Used within <see cref="InspectCodeTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class InspectCodeSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.TargetPath"/></em></p>
        ///   <p>Target path.</p>
        /// </summary>
        [Pure]
        public static T SetTargetPath<T>(this T toolSettings, string targetPath) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InspectCodeSettings.TargetPath"/></em></p>
        ///   <p>Target path.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPath<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.Output"/></em></p>
        ///   <p>Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InspectCodeSettings.Output"/></em></p>
        ///   <p>Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region NoSwea
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.NoSwea"/></em></p>
        ///   <p>Disables solution-wide analysis.</p>
        /// </summary>
        [Pure]
        public static T SetNoSwea<T>(this T toolSettings, bool? noSwea) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = noSwea;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InspectCodeSettings.NoSwea"/></em></p>
        ///   <p>Disables solution-wide analysis.</p>
        /// </summary>
        [Pure]
        public static T ResetNoSwea<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="InspectCodeSettings.NoSwea"/></em></p>
        ///   <p>Disables solution-wide analysis.</p>
        /// </summary>
        [Pure]
        public static T EnableNoSwea<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="InspectCodeSettings.NoSwea"/></em></p>
        ///   <p>Disables solution-wide analysis.</p>
        /// </summary>
        [Pure]
        public static T DisableNoSwea<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="InspectCodeSettings.NoSwea"/></em></p>
        ///   <p>Disables solution-wide analysis.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoSwea<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = !toolSettings.NoSwea;
            return toolSettings;
        }
        #endregion
        #region Profile
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.Profile"/></em></p>
        ///   <p>Specifies an additional .DotSettings file used for inspection settings.</p>
        /// </summary>
        [Pure]
        public static T SetProfile<T>(this T toolSettings, string profile) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = profile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InspectCodeSettings.Profile"/></em></p>
        ///   <p>Specifies an additional .DotSettings file used for inspection settings.</p>
        /// </summary>
        [Pure]
        public static T ResetProfile<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.Project"/></em></p>
        ///   <p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InspectCodeSettings.Project"/></em></p>
        ///   <p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region DisableSettingsLayers
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.DisableSettingsLayers"/> to a new list</em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDisableSettingsLayers<T>(this T toolSettings, params InspectCodeSettingsLayers[] disableSettingsLayers) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.DisableSettingsLayers"/> to a new list</em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDisableSettingsLayers<T>(this T toolSettings, IEnumerable<InspectCodeSettingsLayers> disableSettingsLayers) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="InspectCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T AddDisableSettingsLayers<T>(this T toolSettings, params InspectCodeSettingsLayers[] disableSettingsLayers) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="InspectCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T AddDisableSettingsLayers<T>(this T toolSettings, IEnumerable<InspectCodeSettingsLayers> disableSettingsLayers) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="InspectCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearDisableSettingsLayers<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="InspectCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveDisableSettingsLayers<T>(this T toolSettings, params InspectCodeSettingsLayers[] disableSettingsLayers) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<InspectCodeSettingsLayers>(disableSettingsLayers);
            toolSettings.DisableSettingsLayersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="InspectCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveDisableSettingsLayers<T>(this T toolSettings, IEnumerable<InspectCodeSettingsLayers> disableSettingsLayers) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<InspectCodeSettingsLayers>(disableSettingsLayers);
            toolSettings.DisableSettingsLayersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoBuiltinSettings
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T SetNoBuiltinSettings<T>(this T toolSettings, bool? noBuiltinSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = noBuiltinSettings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InspectCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T ResetNoBuiltinSettings<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="InspectCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T EnableNoBuiltinSettings<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="InspectCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T DisableNoBuiltinSettings<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="InspectCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T ToggleNoBuiltinSettings<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = !toolSettings.NoBuiltinSettings;
            return toolSettings;
        }
        #endregion
        #region CachesHome
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the data that InspectCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static T SetCachesHome<T>(this T toolSettings, string cachesHome) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = cachesHome;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InspectCodeSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the data that InspectCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static T ResetCachesHome<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = null;
            return toolSettings;
        }
        #endregion
        #region Plugins
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.Plugins"/> to a new dictionary</em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during code analysis. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>InspectCodePluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T SetPlugins<T>(this T toolSettings, IDictionary<string, string> plugins) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal = plugins.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="InspectCodeSettings.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during code analysis. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>InspectCodePluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T ClearPlugins<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="InspectCodeSettings.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during code analysis. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>InspectCodePluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T AddPlugin<T>(this T toolSettings, string pluginKey, string pluginValue) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Add(pluginKey, pluginValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="InspectCodeSettings.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during code analysis. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>InspectCodePluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T RemovePlugin<T>(this T toolSettings, string pluginKey) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Remove(pluginKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="InspectCodeSettings.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during code analysis. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>InspectCodePluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T SetPlugin<T>(this T toolSettings, string pluginKey, string pluginValue) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal[pluginKey] = pluginValue;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, string> properties) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="InspectCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="InspectCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="InspectCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="InspectCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
        #region DumpIssuesTypes
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.DumpIssuesTypes"/></em></p>
        ///   <p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p>
        /// </summary>
        [Pure]
        public static T SetDumpIssuesTypes<T>(this T toolSettings, bool? dumpIssuesTypes) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = dumpIssuesTypes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InspectCodeSettings.DumpIssuesTypes"/></em></p>
        ///   <p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p>
        /// </summary>
        [Pure]
        public static T ResetDumpIssuesTypes<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="InspectCodeSettings.DumpIssuesTypes"/></em></p>
        ///   <p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p>
        /// </summary>
        [Pure]
        public static T EnableDumpIssuesTypes<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="InspectCodeSettings.DumpIssuesTypes"/></em></p>
        ///   <p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p>
        /// </summary>
        [Pure]
        public static T DisableDumpIssuesTypes<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="InspectCodeSettings.DumpIssuesTypes"/></em></p>
        ///   <p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p>
        /// </summary>
        [Pure]
        public static T ToggleDumpIssuesTypes<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = !toolSettings.DumpIssuesTypes;
            return toolSettings;
        }
        #endregion
        #region Toolset
        /// <summary>
        ///   <p><em>Sets <see cref="InspectCodeSettings.Toolset"/></em></p>
        ///   <p>Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.</p>
        /// </summary>
        [Pure]
        public static T SetToolset<T>(this T toolSettings, InspectCodeMSBuildToolset toolset) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = toolset;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InspectCodeSettings.Toolset"/></em></p>
        ///   <p>Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetToolset<T>(this T toolSettings) where T : InspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region InspectCodeSettingsLayers
    /// <summary>
    ///   Used within <see cref="InspectCodeTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<InspectCodeSettingsLayers>))]
    public partial class InspectCodeSettingsLayers : Enumeration
    {
        public static InspectCodeSettingsLayers GlobalAll = (InspectCodeSettingsLayers) "GlobalAll";
        public static InspectCodeSettingsLayers GlobalPerProduct = (InspectCodeSettingsLayers) "GlobalPerProduct";
        public static InspectCodeSettingsLayers SolutionShared = (InspectCodeSettingsLayers) "SolutionShared";
        public static InspectCodeSettingsLayers SolutionPersonal = (InspectCodeSettingsLayers) "SolutionPersonal";
        public static explicit operator InspectCodeSettingsLayers(string value)
        {
            return new InspectCodeSettingsLayers { Value = value };
        }
    }
    #endregion
    #region InspectCodeMSBuildToolset
    /// <summary>
    ///   Used within <see cref="InspectCodeTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<InspectCodeMSBuildToolset>))]
    public partial class InspectCodeMSBuildToolset : Enumeration
    {
        public static InspectCodeMSBuildToolset _12_0 = (InspectCodeMSBuildToolset) "12.0";
        public static InspectCodeMSBuildToolset _14_0 = (InspectCodeMSBuildToolset) "14.0";
        public static InspectCodeMSBuildToolset _15_0 = (InspectCodeMSBuildToolset) "15.0";
        public static explicit operator InspectCodeMSBuildToolset(string value)
        {
            return new InspectCodeMSBuildToolset { Value = value };
        }
    }
    #endregion
}
