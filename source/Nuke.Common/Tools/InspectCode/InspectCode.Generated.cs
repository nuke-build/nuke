using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

[assembly: IconClass(typeof(Nuke.Common.Tools.InspectCode.InspectCodeTasks), "code")]

namespace Nuke.Common.Tools.InspectCode
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class InspectCodeTasks
    {
        static partial void PreProcess (InspectCodeSettings inspectCodeSettings);
        static partial void PostProcess (InspectCodeSettings inspectCodeSettings);
        /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html/">official website</a>.</p></summary>
        public static void InspectCode (Configure<InspectCodeSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var inspectCodeSettings = new InspectCodeSettings();
            inspectCodeSettings = configurator(inspectCodeSettings);
            PreProcess(inspectCodeSettings);
            var process = ProcessTasks.StartProcess(inspectCodeSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(inspectCodeSettings);
        }
        /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html/">official website</a>.</p></summary>
        public static void InspectCode (string targetPath, Configure<InspectCodeSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            InspectCode(x => configurator(x).SetTargetPath(targetPath));
        }
        /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html/">official website</a>.</p></summary>
        public static void InspectCode (string targetPath, string output, Configure<InspectCodeSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            InspectCode(targetPath, x => configurator(x).SetOutput(output));
        }
    }
    /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class InspectCodeSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"JetBrains.ReSharper.CommandLineTools", packageExecutable: $"{GetPackageExecutable()}");
        /// <summary><p>Target path.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>Lets you set the output file. By default, the output file is saved in the <i>%TEMP%</i> directory.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Disables solution-wide analysis.</p></summary>
        public virtual bool NoSwea { get; internal set; }
        /// <summary><p>Specifies an additional .DotSettings file used for inspection settings.</p></summary>
        public virtual string Profile { get; internal set; }
        /// <summary><p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p></summary>
        public virtual string Project { get; internal set; }
        /// <summary><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        public virtual IReadOnlyList<InspectCodeSettingsLayers> DisableSettingsLayers => DisableSettingsLayersInternal.AsReadOnly();
        internal List<InspectCodeSettingsLayers> DisableSettingsLayersInternal { get; set; } = new List<InspectCodeSettingsLayers>();
        /// <summary><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        public virtual bool NoBuiltinSettings { get; internal set; }
        /// <summary><p>Lets you specify a custom location for the data that InspectCode caches. By default, the <i>%LOCALAPPDATA%</i> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p></summary>
        public virtual string CachesHome { get; internal set; }
        /// <summary><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        public virtual IReadOnlyList<string> Extensions => ExtensionsInternal.AsReadOnly();
        internal List<string> ExtensionsInternal { get; set; } = new List<string>();
        /// <summary><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        public virtual bool DumpIssuesTypes { get; internal set; }
        /// <summary><p>Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.</p></summary>
        public virtual string Toolset { get; internal set; }
        /// <inheritdoc />
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), $"File.Exists(TargetPath)");
            ControlFlow.Assert(Output != null, $"Output != null");
        }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("{value}", TargetPath)
              .Add("--output={value}", Output)
              .Add("--no-swea", NoSwea)
              .Add("--profile={value}", Profile)
              .Add("--project={value}", Project)
              .Add("--disable-settings-layers={value}", DisableSettingsLayers, mainSeparator: $";")
              .Add("--no-buildin-settings", NoBuiltinSettings)
              .Add("--caches-home={value}", CachesHome)
              .Add("--properties={value}", Properties, mainSeparator: $";", keyValueSeparator: $"=")
              .Add("--dumpIssuesTypes", DumpIssuesTypes)
              .Add("--toolset={value}", Toolset);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class InspectCodeSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.TargetPath"/>.</i></p><p>Target path.</p></summary>
        [Pure]
        public static InspectCodeSettings SetTargetPath(this InspectCodeSettings inspectCodeSettings, string targetPath)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.TargetPath = targetPath;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.Output"/>.</i></p><p>Lets you set the output file. By default, the output file is saved in the <i>%TEMP%</i> directory.</p></summary>
        [Pure]
        public static InspectCodeSettings SetOutput(this InspectCodeSettings inspectCodeSettings, string output)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.Output = output;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.NoSwea"/>.</i></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings SetNoSwea(this InspectCodeSettings inspectCodeSettings, bool noSwea)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.NoSwea = noSwea;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="InspectCodeSettings.NoSwea"/>.</i></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings EnableNoSwea(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.NoSwea = true;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="InspectCodeSettings.NoSwea"/>.</i></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings DisableNoSwea(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.NoSwea = false;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="InspectCodeSettings.NoSwea"/>.</i></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings ToggleNoSwea(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.NoSwea = !inspectCodeSettings.NoSwea;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.Profile"/>.</i></p><p>Specifies an additional .DotSettings file used for inspection settings.</p></summary>
        [Pure]
        public static InspectCodeSettings SetProfile(this InspectCodeSettings inspectCodeSettings, string profile)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.Profile = profile;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.Project"/>.</i></p><p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p></summary>
        [Pure]
        public static InspectCodeSettings SetProject(this InspectCodeSettings inspectCodeSettings, string project)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.Project = project;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.DisableSettingsLayers"/> to a new list.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings SetDisableSettingsLayers(this InspectCodeSettings inspectCodeSettings, params InspectCodeSettingsLayers[] disableSettingsLayers)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.DisableSettingsLayers"/> to a new list.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings SetDisableSettingsLayers(this InspectCodeSettings inspectCodeSettings, IEnumerable<InspectCodeSettingsLayers> disableSettingsLayers)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for adding new disableSettingsLayers to the existing <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings AddDisableSettingsLayers(this InspectCodeSettings inspectCodeSettings, params InspectCodeSettingsLayers[] disableSettingsLayers)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for adding new disableSettingsLayers to the existing <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings AddDisableSettingsLayers(this InspectCodeSettings inspectCodeSettings, IEnumerable<InspectCodeSettingsLayers> disableSettingsLayers)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings ClearDisableSettingsLayers(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DisableSettingsLayersInternal.Clear();
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for adding a single disableSettingsLayer to <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings AddDisableSettingsLayer(this InspectCodeSettings inspectCodeSettings, InspectCodeSettingsLayers disableSettingsLayer)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DisableSettingsLayersInternal.Add(disableSettingsLayer);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for removing a single disableSettingsLayer from <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveDisableSettingsLayer(this InspectCodeSettings inspectCodeSettings, InspectCodeSettingsLayers disableSettingsLayer)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DisableSettingsLayersInternal.Remove(disableSettingsLayer);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</i></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings SetNoBuiltinSettings(this InspectCodeSettings inspectCodeSettings, bool noBuiltinSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.NoBuiltinSettings = noBuiltinSettings;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</i></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings EnableNoBuiltinSettings(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.NoBuiltinSettings = true;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</i></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings DisableNoBuiltinSettings(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.NoBuiltinSettings = false;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</i></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings ToggleNoBuiltinSettings(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.NoBuiltinSettings = !inspectCodeSettings.NoBuiltinSettings;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.CachesHome"/>.</i></p><p>Lets you specify a custom location for the data that InspectCode caches. By default, the <i>%LOCALAPPDATA%</i> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p></summary>
        [Pure]
        public static InspectCodeSettings SetCachesHome(this InspectCodeSettings inspectCodeSettings, string cachesHome)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.CachesHome = cachesHome;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.Extensions"/> to a new list.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings SetExtensions(this InspectCodeSettings inspectCodeSettings, params string[] extensions)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.ExtensionsInternal = extensions.ToList();
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.Extensions"/> to a new list.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings SetExtensions(this InspectCodeSettings inspectCodeSettings, IEnumerable<string> extensions)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.ExtensionsInternal = extensions.ToList();
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for adding new extensions to the existing <see cref="InspectCodeSettings.Extensions"/>.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings AddExtensions(this InspectCodeSettings inspectCodeSettings, params string[] extensions)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.ExtensionsInternal.AddRange(extensions);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for adding new extensions to the existing <see cref="InspectCodeSettings.Extensions"/>.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings AddExtensions(this InspectCodeSettings inspectCodeSettings, IEnumerable<string> extensions)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.ExtensionsInternal.AddRange(extensions);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="InspectCodeSettings.Extensions"/>.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings ClearExtensions(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.ExtensionsInternal.Clear();
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for adding a single extension to <see cref="InspectCodeSettings.Extensions"/>.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings AddExtension(this InspectCodeSettings inspectCodeSettings, string extension)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.ExtensionsInternal.Add(extension);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for removing a single extension from <see cref="InspectCodeSettings.Extensions"/>.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveExtension(this InspectCodeSettings inspectCodeSettings, string extension)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.ExtensionsInternal.Remove(extension);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.Properties"/> to a new dictionary.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings SetProperties(this InspectCodeSettings inspectCodeSettings, IDictionary<string, string> properties)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="InspectCodeSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings ClearProperties(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.PropertiesInternal.Clear();
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for adding a property to <see cref="InspectCodeSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings AddProperty(this InspectCodeSettings inspectCodeSettings, string propertyKey, string propertyValue)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for removing a property from <see cref="InspectCodeSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveProperty(this InspectCodeSettings inspectCodeSettings, string propertyKey)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.PropertiesInternal.Remove(propertyKey);
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting a property in <see cref="InspectCodeSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings SetProperty(this InspectCodeSettings inspectCodeSettings, string propertyKey, string propertyValue)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.PropertiesInternal[propertyKey] = propertyValue;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</i></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings SetDumpIssuesTypes(this InspectCodeSettings inspectCodeSettings, bool dumpIssuesTypes)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DumpIssuesTypes = dumpIssuesTypes;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</i></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings EnableDumpIssuesTypes(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DumpIssuesTypes = true;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</i></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings DisableDumpIssuesTypes(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DumpIssuesTypes = false;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</i></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings ToggleDumpIssuesTypes(this InspectCodeSettings inspectCodeSettings)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.DumpIssuesTypes = !inspectCodeSettings.DumpIssuesTypes;
            return inspectCodeSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="InspectCodeSettings.Toolset"/>.</i></p><p>Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings SetToolset(this InspectCodeSettings inspectCodeSettings, string toolset)
        {
            inspectCodeSettings = inspectCodeSettings.NewInstance();
            inspectCodeSettings.Toolset = toolset;
            return inspectCodeSettings;
        }
    }
    /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p></summary>
    [PublicAPI]
    public enum InspectCodeSettingsLayers
    {
        GlobalAll,
        GlobalPerProduct,
        SolutionShared,
        SolutionPersonal
    }
}
