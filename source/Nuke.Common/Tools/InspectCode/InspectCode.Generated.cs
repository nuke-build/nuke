// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Auto-generated with Nuke.ToolGenerator.

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
        static partial void PreProcess (InspectCodeSettings toolSettings);
        static partial void PostProcess (InspectCodeSettings toolSettings);
        /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html/">official website</a>.</p></summary>
        public static void InspectCode (Configure<InspectCodeSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new InspectCodeSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
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
        /// <summary><p>Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.</p></summary>
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
        /// <summary><p>Lets you specify a custom location for the data that InspectCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p></summary>
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
        public virtual InspectCodeMSBuildToolset? Toolset { get; internal set; }
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
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.TargetPath"/>.</i></p><p>Target path.</p></summary>
        [Pure]
        public static InspectCodeSettings SetTargetPath(this InspectCodeSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.Output"/>.</i></p><p>Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.</p></summary>
        [Pure]
        public static InspectCodeSettings SetOutput(this InspectCodeSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.NoSwea"/>.</i></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings SetNoSwea(this InspectCodeSettings toolSettings, bool noSwea)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = noSwea;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="InspectCodeSettings.NoSwea"/>.</i></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings EnableNoSwea(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="InspectCodeSettings.NoSwea"/>.</i></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings DisableNoSwea(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="InspectCodeSettings.NoSwea"/>.</i></p><p>Disables solution-wide analysis.</p></summary>
        [Pure]
        public static InspectCodeSettings ToggleNoSwea(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = !toolSettings.NoSwea;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.Profile"/>.</i></p><p>Specifies an additional .DotSettings file used for inspection settings.</p></summary>
        [Pure]
        public static InspectCodeSettings SetProfile(this InspectCodeSettings toolSettings, string profile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = profile;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.Project"/>.</i></p><p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p></summary>
        [Pure]
        public static InspectCodeSettings SetProject(this InspectCodeSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.DisableSettingsLayers"/> to a new list.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings SetDisableSettingsLayers(this InspectCodeSettings toolSettings, params InspectCodeSettingsLayers[] disableSettingsLayers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.DisableSettingsLayers"/> to a new list.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings SetDisableSettingsLayers(this InspectCodeSettings toolSettings, IEnumerable<InspectCodeSettingsLayers> disableSettingsLayers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Adds a disableSettingsLayers to the existing <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings AddDisableSettingsLayers(this InspectCodeSettings toolSettings, params InspectCodeSettingsLayers[] disableSettingsLayers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary><p><i>Adds a disableSettingsLayers to the existing <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings AddDisableSettingsLayers(this InspectCodeSettings toolSettings, IEnumerable<InspectCodeSettingsLayers> disableSettingsLayers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings ClearDisableSettingsLayers(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a single disableSettingsLayer to <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings AddDisableSettingsLayer(this InspectCodeSettings toolSettings, InspectCodeSettingsLayers disableSettingsLayer)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.Add(disableSettingsLayer);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single disableSettingsLayer from <see cref="InspectCodeSettings.DisableSettingsLayers"/>.</i></p><p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveDisableSettingsLayer(this InspectCodeSettings toolSettings, InspectCodeSettingsLayers disableSettingsLayer)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = toolSettings.Nuke.ToolGenerator.Model.Property.Where(x => x == disableSettingsLayer).ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</i></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings SetNoBuiltinSettings(this InspectCodeSettings toolSettings, bool noBuiltinSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = noBuiltinSettings;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</i></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings EnableNoBuiltinSettings(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</i></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings DisableNoBuiltinSettings(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="InspectCodeSettings.NoBuiltinSettings"/>.</i></p><p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p></summary>
        [Pure]
        public static InspectCodeSettings ToggleNoBuiltinSettings(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = !toolSettings.NoBuiltinSettings;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.CachesHome"/>.</i></p><p>Lets you specify a custom location for the data that InspectCode caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p></summary>
        [Pure]
        public static InspectCodeSettings SetCachesHome(this InspectCodeSettings toolSettings, string cachesHome)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = cachesHome;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.Extensions"/> to a new list.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings SetExtensions(this InspectCodeSettings toolSettings, params string[] extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal = extensions.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.Extensions"/> to a new list.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings SetExtensions(this InspectCodeSettings toolSettings, IEnumerable<string> extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal = extensions.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Adds a extensions to the existing <see cref="InspectCodeSettings.Extensions"/>.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings AddExtensions(this InspectCodeSettings toolSettings, params string[] extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal.AddRange(extensions);
            return toolSettings;
        }
        /// <summary><p><i>Adds a extensions to the existing <see cref="InspectCodeSettings.Extensions"/>.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings AddExtensions(this InspectCodeSettings toolSettings, IEnumerable<string> extensions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal.AddRange(extensions);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="InspectCodeSettings.Extensions"/>.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings ClearExtensions(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a single extension to <see cref="InspectCodeSettings.Extensions"/>.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings AddExtension(this InspectCodeSettings toolSettings, string extension, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (extension != null || evenIfNull) toolSettings.ExtensionsInternal.Add(extension);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single extension from <see cref="InspectCodeSettings.Extensions"/>.</i></p><p>Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href="http://resharper-plugins.jetbrains.com/">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveExtension(this InspectCodeSettings toolSettings, string extension)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionsInternal = toolSettings.Nuke.ToolGenerator.Model.Property.Where(x => x == extension).ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.Properties"/> to a new dictionary.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings SetProperties(this InspectCodeSettings toolSettings, IDictionary<string, string> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="InspectCodeSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings ClearProperties(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a property to the existing <see cref="InspectCodeSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings AddProperty(this InspectCodeSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single property from <see cref="InspectCodeSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings RemoveProperty(this InspectCodeSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><i>Sets a property in <see cref="InspectCodeSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static InspectCodeSettings SetProperty(this InspectCodeSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</i></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings SetDumpIssuesTypes(this InspectCodeSettings toolSettings, bool dumpIssuesTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = dumpIssuesTypes;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</i></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings EnableDumpIssuesTypes(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</i></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings DisableDumpIssuesTypes(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="InspectCodeSettings.DumpIssuesTypes"/>.</i></p><p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p></summary>
        [Pure]
        public static InspectCodeSettings ToggleDumpIssuesTypes(this InspectCodeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = !toolSettings.DumpIssuesTypes;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="InspectCodeSettings.Toolset"/>.</i></p><p>Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>.</p></summary>
        [Pure]
        public static InspectCodeSettings SetToolset(this InspectCodeSettings toolSettings, InspectCodeMSBuildToolset? toolset)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = toolset;
            return toolSettings;
        }
    }
    /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p></summary>
    [PublicAPI]
    public enum InspectCodeSettingsLayers
    {
        GlobalAll,
        GlobalPerProduct,
        SolutionShared,
        SolutionPersonal,
    }
    /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p></summary>
    [PublicAPI]
    public enum InspectCodeMSBuildToolset
    {
        [FriendlyString("12.0")]
        _12_0,
        [FriendlyString("14.0")]
        _14_0,
        [FriendlyString("15.0")]
        _15_0,
    }
}
