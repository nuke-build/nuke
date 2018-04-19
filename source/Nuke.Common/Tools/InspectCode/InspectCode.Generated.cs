// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, LOCAL VERSION.
// Generated from https://github.com/nuke-build/tools/blob/master/metadata/InspectCode.json.

using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.InspectCode
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class InspectCodeTasks
    {
        /// <summary><p>Path to the InspectCode executable.</p></summary>
        public static string InspectCodePath => ToolPathResolver.GetPackageExecutable("JetBrains.ReSharper.CommandLineTools", GetPackageExecutable());
        static partial void PreProcess(InspectCodeSettings toolSettings);
        static partial void PostProcess(InspectCodeSettings toolSettings);
        /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html/">official website</a>.</p></summary>
        public static void InspectCode(Configure<InspectCodeSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new InspectCodeSettings());
            PreProcess(toolSettings);
            var process = StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html/">official website</a>.</p></summary>
        public static void InspectCode(string targetPath, Configure<InspectCodeSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            InspectCode(x => configurator(x).SetTargetPath(targetPath));
        }
        /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html/">official website</a>.</p></summary>
        public static void InspectCode(string targetPath, string output, Configure<InspectCodeSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            InspectCode(targetPath, x => configurator(x).SetOutput(output));
        }
    }
    #region InspectCodeSettings
    /// <summary><p>Used within <see cref="InspectCodeTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class InspectCodeSettings : ToolSettings
    {
        /// <summary><p>Path to the InspectCode executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? InspectCodeTasks.InspectCodePath;
        /// <summary><p>Target path.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Disables solution-wide analysis.</p></summary>
        public virtual bool? NoSwea { get; internal set; }
        /// <summary><p>Specifies an additional .DotSettings file used for inspection settings.</p></summary>
        public virtual string Profile { get; internal set; }
        /// <summary><p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p></summary>
        public virtual string Project { get; internal set; }
        /// <summary><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        public virtual IReadOnlyList<InspectCodeSettingsLayers> DisableSettingsLayers => DisableSettingsLayersInternal.AsReadOnly();
        internal List<InspectCodeSettingsLayers> DisableSettingsLayersInternal { get; set; } = new List<InspectCodeSettingsLayers>();
        /// <summary><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        public virtual bool? NoBuiltinSettings { get; internal set; }
        /// <summary><p>Lets you specify a custom location for the data that InspectCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p></summary>
        public virtual string CachesHome { get; internal set; }
        /// <summary><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        public virtual IReadOnlyList<string> Extensions => ExtensionsInternal.AsReadOnly();
        internal List<string> ExtensionsInternal { get; set; } = new List<string>();
        /// <summary><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        public virtual bool? DumpIssuesTypes { get; internal set; }
        /// <summary><p>Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.</p></summary>
        public virtual InspectCodeMSBuildToolset Toolset { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), "File.Exists(TargetPath)");
            ControlFlow.Assert(Output != null, "Output != null");
        }
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
    /// <summary><p>Used within <see cref="InspectCodeTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class InspectCodeSettingsExtensions
    {
        #region TargetPath
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.TargetPath"/>.</em></p><p>Target path.</p></summary>
        [Pure]
        public static InspectCodeSettings SetTargetPath(this InspectCodeSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="InspectCodeSettings.TargetPath"/>.</em></p><p>Target path.</p></summary>
        [Pure]
        public static InspectCodeSettings ResetTargetPath(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.Output"/>.</em></p><p>Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.</p></summary>
        [Pure]
        public static InspectCodeSettings SetOutput(this InspectCodeSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="InspectCodeSettings.Output"/>.</em></p><p>Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.</p></summary>
        [Pure]
        public static InspectCodeSettings ResetOutput(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region NoSwea
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.NoSwea"/>.</em></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings SetNoSwea(this InspectCodeSettings toolSettings, bool? noSwea)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = noSwea;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="InspectCodeSettings.NoSwea"/>.</em></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings ResetNoSwea(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="InspectCodeSettings.NoSwea"/>.</em></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings EnableNoSwea(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="InspectCodeSettings.NoSwea"/>.</em></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings DisableNoSwea(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="InspectCodeSettings.NoSwea"/>.</em></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings ToggleNoSwea(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = !toolSettings.NoSwea;
            return toolSettings;
        }
        #endregion
        #region Profile
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.Profile"/>.</em></p><p>Specifies an additional .DotSettings file used for inspection settings.</p></summary>
        [Pure]
        public static InspectCodeSettings SetProfile(this InspectCodeSettings toolSettings, string profile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = profile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="InspectCodeSettings.Profile"/>.</em></p><p>Specifies an additional .DotSettings file used for inspection settings.</p></summary>
        [Pure]
        public static InspectCodeSettings ResetProfile(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.Project"/>.</em></p><p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p></summary>
        [Pure]
        public static InspectCodeSettings SetProject(this InspectCodeSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="InspectCodeSettings.Project"/>.</em></p><p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p></summary>
        [Pure]
        public static InspectCodeSettings ResetProject(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region DisableSettingsLayers
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.DisableSettingsLayers"/> to a new list.</em></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings SetDisableSettingsLayers(this InspectCodeSettings toolSettings, params InspectCodeSettingsLayers[] disableSettingsLayers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.DisableSettingsLayers"/> to a new list.</em></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings SetDisableSettingsLayers(this InspectCodeSettings toolSettings, IEnumerable<InspectCodeSettingsLayers> disableSettingsLayers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</em></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings AddDisableSettingsLayers(this InspectCodeSettings toolSettings, params InspectCodeSettingsLayers[] disableSettingsLayers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</em></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings AddDisableSettingsLayers(this InspectCodeSettings toolSettings, IEnumerable<InspectCodeSettingsLayers> disableSettingsLayers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</em></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings ClearDisableSettingsLayers(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</em></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveDisableSettingsLayers(this InspectCodeSettings toolSettings, params InspectCodeSettingsLayers[] disableSettingsLayers)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<InspectCodeSettingsLayers>(disableSettingsLayers);
            toolSettings.DisableSettingsLayersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</em></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveDisableSettingsLayers(this InspectCodeSettings toolSettings, IEnumerable<InspectCodeSettingsLayers> disableSettingsLayers)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<InspectCodeSettingsLayers>(disableSettingsLayers);
            toolSettings.DisableSettingsLayersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoBuiltinSettings
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</em></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings SetNoBuiltinSettings(this InspectCodeSettings toolSettings, bool? noBuiltinSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = noBuiltinSettings;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</em></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings ResetNoBuiltinSettings(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</em></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings EnableNoBuiltinSettings(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</em></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings DisableNoBuiltinSettings(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</em></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings ToggleNoBuiltinSettings(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = !toolSettings.NoBuiltinSettings;
            return toolSettings;
        }
        #endregion
        #region CachesHome
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.CachesHome"/>.</em></p><p>Lets you specify a custom location for the data that InspectCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p></summary>
        [Pure]
        public static InspectCodeSettings SetCachesHome(this InspectCodeSettings toolSettings, string cachesHome)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = cachesHome;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="InspectCodeSettings.CachesHome"/>.</em></p><p>Lets you specify a custom location for the data that InspectCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p></summary>
        [Pure]
        public static InspectCodeSettings ResetCachesHome(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = null;
            return toolSettings;
        }
        #endregion
        #region Extensions
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.Extensions"/> to a new list.</em></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings SetExtensions(this InspectCodeSettings toolSettings, params string[] extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal = extensions.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.Extensions"/> to a new list.</em></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings SetExtensions(this InspectCodeSettings toolSettings, IEnumerable<string> extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal = extensions.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="InspectCodeSettings.Extensions"/>.</em></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings AddExtensions(this InspectCodeSettings toolSettings, params string[] extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal.AddRange(extensions);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="InspectCodeSettings.Extensions"/>.</em></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings AddExtensions(this InspectCodeSettings toolSettings, IEnumerable<string> extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal.AddRange(extensions);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="InspectCodeSettings.Extensions"/>.</em></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings ClearExtensions(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="InspectCodeSettings.Extensions"/>.</em></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveExtensions(this InspectCodeSettings toolSettings, params string[] extensions)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extensions);
            toolSettings.ExtensionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="InspectCodeSettings.Extensions"/>.</em></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveExtensions(this InspectCodeSettings toolSettings, IEnumerable<string> extensions)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extensions);
            toolSettings.ExtensionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.Properties"/> to a new dictionary.</em></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings SetProperties(this InspectCodeSettings toolSettings, IDictionary<string, string> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="InspectCodeSettings.Properties"/>.</em></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings ClearProperties(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="InspectCodeSettings.Properties"/>.</em></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings AddProperty(this InspectCodeSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="InspectCodeSettings.Properties"/>.</em></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveProperty(this InspectCodeSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="InspectCodeSettings.Properties"/>.</em></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings SetProperty(this InspectCodeSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
        #region DumpIssuesTypes
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</em></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings SetDumpIssuesTypes(this InspectCodeSettings toolSettings, bool? dumpIssuesTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = dumpIssuesTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</em></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings ResetDumpIssuesTypes(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</em></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings EnableDumpIssuesTypes(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</em></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings DisableDumpIssuesTypes(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</em></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings ToggleDumpIssuesTypes(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = !toolSettings.DumpIssuesTypes;
            return toolSettings;
        }
        #endregion
        #region Toolset
        /// <summary><p><em>Sets <see cref="InspectCodeSettings.Toolset"/>.</em></p><p>Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings SetToolset(this InspectCodeSettings toolSettings, InspectCodeMSBuildToolset toolset)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = toolset;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="InspectCodeSettings.Toolset"/>.</em></p><p>Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings ResetToolset(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region InspectCodeSettingsLayers
    /// <summary><p>Used within <see cref="InspectCodeTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class InspectCodeSettingsLayers : Enumeration
    {
        public static InspectCodeSettingsLayers GlobalAll = new InspectCodeSettingsLayers { Value = "GlobalAll" };
        public static InspectCodeSettingsLayers GlobalPerProduct = new InspectCodeSettingsLayers { Value = "GlobalPerProduct" };
        public static InspectCodeSettingsLayers SolutionShared = new InspectCodeSettingsLayers { Value = "SolutionShared" };
        public static InspectCodeSettingsLayers SolutionPersonal = new InspectCodeSettingsLayers { Value = "SolutionPersonal" };
    }
    #endregion
    #region InspectCodeMSBuildToolset
    /// <summary><p>Used within <see cref="InspectCodeTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class InspectCodeMSBuildToolset : Enumeration
    {
        public static InspectCodeMSBuildToolset _12_0 = new InspectCodeMSBuildToolset { Value = "12.0" };
        public static InspectCodeMSBuildToolset _14_0 = new InspectCodeMSBuildToolset { Value = "14.0" };
        public static InspectCodeMSBuildToolset _15_0 = new InspectCodeMSBuildToolset { Value = "15.0" };
    }
    #endregion
}
