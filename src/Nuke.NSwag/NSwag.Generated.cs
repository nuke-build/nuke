// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, Version: 0.1.458 [CommitSha: 88f1c32b].

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

namespace Nuke.NSwag
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagTasks
    {
        static partial void PreProcess (NSwagAspNetCore2SwaggerSettings toolSettings);
        static partial void PostProcess (NSwagAspNetCore2SwaggerSettings toolSettings);
        /// <summary><p>Generates a Swagger specification ASP.NET Core Mvc application using ApiExplorer (experimental).</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagAspNetCore2Swagger (Configure<NSwagAspNetCore2SwaggerSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagAspNetCore2SwaggerSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagVersionSettings toolSettings);
        static partial void PostProcess (NSwagVersionSettings toolSettings);
        /// <summary><p>Prints the toolchain version.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagVersion (Configure<NSwagVersionSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagVersionSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagListTypesSettings toolSettings);
        static partial void PostProcess (NSwagListTypesSettings toolSettings);
        /// <summary><p>List all types for the given assembly and settings.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagListTypes (Configure<NSwagListTypesSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagListTypesSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagListControllersSettings toolSettings);
        static partial void PostProcess (NSwagListControllersSettings toolSettings);
        /// <summary><p>List all controllers classes for the given assembly and settings.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagListControllers (Configure<NSwagListControllersSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagListControllersSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagTypes2SwaggerSettings toolSettings);
        static partial void PostProcess (NSwagTypes2SwaggerSettings toolSettings);
        /// <summary><p>The project combines the functionality of Swashbuckle (Swagger generation) and AutoRest (client generation) in one toolchain. This way a lot of incompatibilites can be avoided and features which are not well described by the Swagger specification or JSON Schema are better supported (e.g. <a href="https://github.com/NJsonSchema/NJsonSchema/wiki/Inheritance">inheritance</a>, <a href="https://github.com/NJsonSchema/NJsonSchema/wiki/Enums">enum</a> and reference handling). The NSwag project heavily uses <a href="http://njsonschema.org/">NJsonSchema for .NET</a> for JSON Schema handling and C#/TypeScript class/interface generation.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagTypes2Swagger (Configure<NSwagTypes2SwaggerSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagTypes2SwaggerSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagWebApi2SwaggerSettings toolSettings);
        static partial void PostProcess (NSwagWebApi2SwaggerSettings toolSettings);
        /// <summary><p>Generates a Swagger specification for a controller or controlles contained in a .NET Web API assembly.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagWebApi2Swagger (Configure<NSwagWebApi2SwaggerSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagWebApi2SwaggerSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagNewSettings toolSettings);
        static partial void PostProcess (NSwagNewSettings toolSettings);
        /// <summary><p>Creates a new nswag.json file in the current directory.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagNew (Configure<NSwagNewSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagNewSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagRunSettings toolSettings);
        static partial void PostProcess (NSwagRunSettings toolSettings);
        /// <summary><p>Executes an .nswag file. If 'input' is not specified then all *.nswag files and the nswag.json file is executed.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagRun (Configure<NSwagRunSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagRunSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagJsonSchema2CsClientSettings toolSettings);
        static partial void PostProcess (NSwagJsonSchema2CsClientSettings toolSettings);
        /// <summary><p>Generates CSharp classes from a JSON Schema.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagJsonSchema2CsClient (Configure<NSwagJsonSchema2CsClientSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagJsonSchema2CsClientSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagJsonSchema2TsClientSettings toolSettings);
        static partial void PostProcess (NSwagJsonSchema2TsClientSettings toolSettings);
        /// <summary><p>Generates TypeScript interfaces from a JSON Schema.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagJsonSchema2TsClient (Configure<NSwagJsonSchema2TsClientSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagJsonSchema2TsClientSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagSwagger2CsClientSettings toolSettings);
        static partial void PostProcess (NSwagSwagger2CsClientSettings toolSettings);
        /// <summary><p>Generates CSharp client code from a Swagger specification.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagSwagger2CsClient (Configure<NSwagSwagger2CsClientSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagSwagger2CsClientSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagSwagger2CscontrollerSettings toolSettings);
        static partial void PostProcess (NSwagSwagger2CscontrollerSettings toolSettings);
        /// <summary><p>Generates CSharp Web API controller code from a Swagger specification.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagSwagger2Cscontroller (Configure<NSwagSwagger2CscontrollerSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagSwagger2CscontrollerSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NSwagSwagger2TsClientSettings toolSettings);
        static partial void PostProcess (NSwagSwagger2TsClientSettings toolSettings);
        /// <summary><p>Generates TypeScript client code from a Swagger specification.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagSwagger2TsClient (Configure<NSwagSwagger2TsClientSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagSwagger2TsClientSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
    }
    #region NSwagAspNetCore2SwaggerSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagAspNetCore2SwaggerSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        /// <summary><p>The project to use.</p></summary>
        public virtual string Project { get; internal set; }
        /// <summary><p>The MSBuild project extensions path. Defaults to "obj".</p></summary>
        public virtual string MSBuildProjectExtensionsPath { get; internal set; }
        /// <summary><p>The configuration to use.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>The runtime to use.</p></summary>
        public virtual string Runtime { get; internal set; }
        /// <summary><p>The target framework to use.</p></summary>
        public virtual string TargetFramework { get; internal set; }
        /// <summary><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary><p>Print verbose output.</p></summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary><p>The output file.</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        public virtual PropertyNameHandling DefaultPropertyNameHandling { get; internal set; }
        /// <summary><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        public virtual ReferenceTypeNullHandling DefaultReferenceTypeNullHandling { get; internal set; }
        /// <summary><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        public virtual EnumHandling DefaultEnumHandling { get; internal set; }
        /// <summary><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        public virtual bool? FlattenInheritanceHierarchy { get; internal set; }
        /// <summary><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        public virtual bool? GenerateKnownTypes { get; internal set; }
        /// <summary><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        public virtual bool? GenerateXmlObjects { get; internal set; }
        /// <summary><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        public virtual bool? GenerateAbstractProperties { get; internal set; }
        /// <summary><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>The basePath of the Swagger specification (optional).</p></summary>
        public virtual string ServiceBasePath { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<String> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<String> ServiceSchemesInternal { get; set; } = new List<String>();
        /// <summary><p>Specify the title of the Swagger specification.</p></summary>
        public virtual string InfoTitle { get; internal set; }
        /// <summary><p>Specify the description of the Swagger specification.</p></summary>
        public virtual string InfoDescription { get; internal set; }
        /// <summary><p>Specify the version of the Swagger specification (default: 1.0.0).</p></summary>
        public virtual string InfoVersion { get; internal set; }
        /// <summary><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        public virtual string DocumentTemplate { get; internal set; }
        /// <summary><p>Gets the document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual IReadOnlyList<String> DocumentProcessorTypes => DocumentProcessorTypesInternal.AsReadOnly();
        internal List<String> DocumentProcessorTypesInternal { get; set; } = new List<String>();
        /// <summary><p>Gets the operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual IReadOnlyList<String> OperationProcessors => OperationProcessorsInternal.AsReadOnly();
        internal List<String> OperationProcessorsInternal { get; set; } = new List<String>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/project:\"{value}\"", Project)
              .Add("/mSBuildProjectExtensionsPath:\"{value}\"", MSBuildProjectExtensionsPath)
              .Add("/configuration:\"{value}\"", Configuration)
              .Add("/runtime:\"{value}\"", Runtime)
              .Add("/targetFramework:\"{value}\"", TargetFramework)
              .Add("/noBuild:\"{value}\"", NoBuild)
              .Add("/verbose:\"{value}\"", Verbose)
              .Add("/output:\"{value}\"", Output)
              .Add("/defaultPropertyNameHandling:\"{value}\"", DefaultPropertyNameHandling)
              .Add("/defaultReferenceTypeNullHandling:\"{value}\"", DefaultReferenceTypeNullHandling)
              .Add("/defaultEnumHandling:\"{value}\"", DefaultEnumHandling)
              .Add("/flattenInheritanceHierarchy:\"{value}\"", FlattenInheritanceHierarchy)
              .Add("/generateKnownTypes:\"{value}\"", GenerateKnownTypes)
              .Add("/generateXmlObjects:\"{value}\"", GenerateXmlObjects)
              .Add("/generateAbstractProperties:\"{value}\"", GenerateAbstractProperties)
              .Add("/serviceHost:\"{value}\"", ServiceHost)
              .Add("/serviceBasePath:\"{value}\"", ServiceBasePath)
              .Add("/serviceSchemes:\"{value}\"", ServiceSchemes, separator: ',')
              .Add("/infoTitle:\"{value}\"", InfoTitle)
              .Add("/infoDescription:\"{value}\"", InfoDescription)
              .Add("/infoVersion:\"{value}\"", InfoVersion)
              .Add("/documentTemplate:\"{value}\"", DocumentTemplate)
              .Add("/documentProcessorTypes:\"{value}\"", DocumentProcessorTypes, separator: ',')
              .Add("/operationProcessors:\"{value}\"", OperationProcessors, separator: ',');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagVersionSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagVersionSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
    }
    #endregion
    #region NSwagListTypesSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagListTypesSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        /// <summary><p>The nswag.json configuration file path.</p></summary>
        public virtual string File { get; internal set; }
        public virtual string Variables { get; internal set; }
        /// <summary><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        public virtual IReadOnlyList<String> Assembly => AssemblyInternal.AsReadOnly();
        internal List<String> AssemblyInternal { get; set; } = new List<String>();
        /// <summary><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        public virtual string AssemblyConfig { get; internal set; }
        /// <summary><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        public virtual IReadOnlyList<String> ReferencePaths => ReferencePathsInternal.AsReadOnly();
        internal List<String> ReferencePathsInternal { get; set; } = new List<String>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/file:\"{value}\"", File)
              .Add("/variables:\"{value}\"", Variables)
              .Add("/assembly:\"{value}\"", Assembly, separator: ',')
              .Add("/assemblyConfig:\"{value}\"", AssemblyConfig)
              .Add("/referencePaths:\"{value}\"", ReferencePaths, separator: ',');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagListControllersSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagListControllersSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        /// <summary><p>The nswag.json configuration file path.</p></summary>
        public virtual string File { get; internal set; }
        public virtual string Variables { get; internal set; }
        /// <summary><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        public virtual IReadOnlyList<String> Assembly => AssemblyInternal.AsReadOnly();
        internal List<String> AssemblyInternal { get; set; } = new List<String>();
        /// <summary><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        public virtual string AssemblyConfig { get; internal set; }
        /// <summary><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        public virtual IReadOnlyList<String> ReferencePaths => ReferencePathsInternal.AsReadOnly();
        internal List<String> ReferencePathsInternal { get; set; } = new List<String>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/file:\"{value}\"", File)
              .Add("/variables:\"{value}\"", Variables)
              .Add("/assembly:\"{value}\"", Assembly, separator: ',')
              .Add("/assemblyConfig:\"{value}\"", AssemblyConfig)
              .Add("/referencePaths:\"{value}\"", ReferencePaths, separator: ',');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagTypes2SwaggerSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagTypes2SwaggerSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        /// <summary><p>The class names.</p></summary>
        public virtual IReadOnlyList<String> ClassNames => ClassNamesInternal.AsReadOnly();
        internal List<String> ClassNamesInternal { get; set; } = new List<String>();
        /// <summary><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        public virtual PropertyNameHandling DefaultPropertyNameHandling { get; internal set; }
        /// <summary><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        public virtual ReferenceTypeNullHandling DefaultReferenceTypeNullHandling { get; internal set; }
        /// <summary><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        public virtual EnumHandling DefaultEnumHandling { get; internal set; }
        /// <summary><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        public virtual bool? FlattenInheritanceHierarchy { get; internal set; }
        /// <summary><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        public virtual bool? IgnoreObsoleteProperties { get; internal set; }
        /// <summary><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        public virtual bool? AllowReferencesWithProperties { get; internal set; }
        /// <summary><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        public virtual bool? GenerateKnownTypes { get; internal set; }
        /// <summary><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        public virtual bool? GenerateXmlObjects { get; internal set; }
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        public virtual IReadOnlyList<String> Assembly => AssemblyInternal.AsReadOnly();
        internal List<String> AssemblyInternal { get; set; } = new List<String>();
        /// <summary><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        public virtual string AssemblyConfig { get; internal set; }
        /// <summary><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        public virtual IReadOnlyList<String> ReferencePaths => ReferencePathsInternal.AsReadOnly();
        internal List<String> ReferencePathsInternal { get; set; } = new List<String>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/classNames:\"{value}\"", ClassNames, separator: ',')
              .Add("/defaultPropertyNameHandling:\"{value}\"", DefaultPropertyNameHandling)
              .Add("/defaultReferenceTypeNullHandling:\"{value}\"", DefaultReferenceTypeNullHandling)
              .Add("/defaultEnumHandling:\"{value}\"", DefaultEnumHandling)
              .Add("/flattenInheritanceHierarchy:\"{value}\"", FlattenInheritanceHierarchy)
              .Add("/ignoreObsoleteProperties:\"{value}\"", IgnoreObsoleteProperties)
              .Add("/allowReferencesWithProperties:\"{value}\"", AllowReferencesWithProperties)
              .Add("/generateKnownTypes:\"{value}\"", GenerateKnownTypes)
              .Add("/generateXmlObjects:\"{value}\"", GenerateXmlObjects)
              .Add("/output:\"{value}\"", Output)
              .Add("/assembly:\"{value}\"", Assembly, separator: ',')
              .Add("/assemblyConfig:\"{value}\"", AssemblyConfig)
              .Add("/referencePaths:\"{value}\"", ReferencePaths, separator: ',');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagWebApi2SwaggerSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagWebApi2SwaggerSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        /// <summary><p>The Web API controller full class name or empty to load all controllers from the assembly.</p></summary>
        public virtual string Controller { get; internal set; }
        /// <summary><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        public virtual IReadOnlyList<String> Controllers => ControllersInternal.AsReadOnly();
        internal List<String> ControllersInternal { get; set; } = new List<String>();
        /// <summary><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        public virtual bool? AspNetCore { get; internal set; }
        /// <summary><p>The Web API default URL template (default for Web API: 'api/{controller}/{id}'; for MVC projects: '{controller}/{action}/{id?}').</p></summary>
        public virtual string DefaultUrlTemplate { get; internal set; }
        /// <summary><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        public virtual PropertyNameHandling DefaultPropertyNameHandling { get; internal set; }
        /// <summary><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        public virtual ReferenceTypeNullHandling DefaultReferenceTypeNullHandling { get; internal set; }
        /// <summary><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        public virtual EnumHandling DefaultEnumHandling { get; internal set; }
        /// <summary><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        public virtual bool? FlattenInheritanceHierarchy { get; internal set; }
        /// <summary><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        public virtual bool? GenerateKnownTypes { get; internal set; }
        /// <summary><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        public virtual bool? GenerateXmlObjects { get; internal set; }
        /// <summary><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        public virtual bool? GenerateAbstractProperties { get; internal set; }
        /// <summary><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        public virtual bool? AddMissingPathParameters { get; internal set; }
        /// <summary><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        public virtual bool? IgnoreObsoleteProperties { get; internal set; }
        /// <summary><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        public virtual bool? AllowReferencesWithProperties { get; internal set; }
        /// <summary><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        public virtual IReadOnlyList<String> ExcludedTypeNames => ExcludedTypeNamesInternal.AsReadOnly();
        internal List<String> ExcludedTypeNamesInternal { get; set; } = new List<String>();
        /// <summary><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>The basePath of the Swagger specification (optional).</p></summary>
        public virtual string ServiceBasePath { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<String> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<String> ServiceSchemesInternal { get; set; } = new List<String>();
        /// <summary><p>Specify the title of the Swagger specification.</p></summary>
        public virtual string InfoTitle { get; internal set; }
        /// <summary><p>Specify the description of the Swagger specification.</p></summary>
        public virtual string InfoDescription { get; internal set; }
        /// <summary><p>Specify the version of the Swagger specification (default: 1.0.0).</p></summary>
        public virtual string InfoVersion { get; internal set; }
        /// <summary><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        public virtual string DocumentTemplate { get; internal set; }
        /// <summary><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual IReadOnlyList<String> DocumentProcessors => DocumentProcessorsInternal.AsReadOnly();
        internal List<String> DocumentProcessorsInternal { get; set; } = new List<String>();
        /// <summary><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual IReadOnlyList<String> OperationProcessors => OperationProcessorsInternal.AsReadOnly();
        internal List<String> OperationProcessorsInternal { get; set; } = new List<String>();
        /// <summary><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string TypeNameGenerator { get; internal set; }
        /// <summary><p>The custom ISchemaNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string SchemaNameGenerator { get; internal set; }
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        public virtual IReadOnlyList<String> Assembly => AssemblyInternal.AsReadOnly();
        internal List<String> AssemblyInternal { get; set; } = new List<String>();
        /// <summary><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        public virtual string AssemblyConfig { get; internal set; }
        /// <summary><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        public virtual IReadOnlyList<String> ReferencePaths => ReferencePathsInternal.AsReadOnly();
        internal List<String> ReferencePathsInternal { get; set; } = new List<String>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/controller:\"{value}\"", Controller)
              .Add("/controllers:\"{value}\"", Controllers, separator: ',')
              .Add("/aspNetCore:\"{value}\"", AspNetCore)
              .Add("/defaultUrlTemplate:\"{value}\"", DefaultUrlTemplate)
              .Add("/defaultPropertyNameHandling:\"{value}\"", DefaultPropertyNameHandling)
              .Add("/defaultReferenceTypeNullHandling:\"{value}\"", DefaultReferenceTypeNullHandling)
              .Add("/defaultEnumHandling:\"{value}\"", DefaultEnumHandling)
              .Add("/flattenInheritanceHierarchy:\"{value}\"", FlattenInheritanceHierarchy)
              .Add("/generateKnownTypes:\"{value}\"", GenerateKnownTypes)
              .Add("/generateXmlObjects:\"{value}\"", GenerateXmlObjects)
              .Add("/generateAbstractProperties:\"{value}\"", GenerateAbstractProperties)
              .Add("/addMissingPathParameters:\"{value}\"", AddMissingPathParameters)
              .Add("/ignoreObsoleteProperties:\"{value}\"", IgnoreObsoleteProperties)
              .Add("/allowReferencesWithProperties:\"{value}\"", AllowReferencesWithProperties)
              .Add("/excludedTypeNames:\"{value}\"", ExcludedTypeNames, separator: ',')
              .Add("/serviceHost:\"{value}\"", ServiceHost)
              .Add("/serviceBasePath:\"{value}\"", ServiceBasePath)
              .Add("/serviceSchemes:\"{value}\"", ServiceSchemes, separator: ',')
              .Add("/infoTitle:\"{value}\"", InfoTitle)
              .Add("/infoDescription:\"{value}\"", InfoDescription)
              .Add("/infoVersion:\"{value}\"", InfoVersion)
              .Add("/documentTemplate:\"{value}\"", DocumentTemplate)
              .Add("/documentProcessors:\"{value}\"", DocumentProcessors, separator: ',')
              .Add("/operationProcessors:\"{value}\"", OperationProcessors, separator: ',')
              .Add("/typeNameGenerator:\"{value}\"", TypeNameGenerator)
              .Add("/schemaNameGenerator:\"{value}\"", SchemaNameGenerator)
              .Add("/output:\"{value}\"", Output)
              .Add("/assembly:\"{value}\"", Assembly, separator: ',')
              .Add("/assemblyConfig:\"{value}\"", AssemblyConfig)
              .Add("/referencePaths:\"{value}\"", ReferencePaths, separator: ',');
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagNewSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagNewSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
    }
    #endregion
    #region NSwagRunSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagRunSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        public virtual string Input { get; internal set; }
        public virtual string Variables { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", Input)
              .Add("/variables:\"{value}\"", Variables);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagJsonSchema2CsClientSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagJsonSchema2CsClientSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        /// <summary><p>The class name of the root schema.</p></summary>
        public virtual string Name { get; internal set; }
        /// <summary><p>The namespace of the generated classes.</p></summary>
        public virtual string TargetNamespace { get; internal set; }
        /// <summary><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        public virtual bool? RequiredPropertiesMustBeDefined { get; internal set; }
        /// <summary><p>The date time .NET type (default: 'DateTime').</p></summary>
        public virtual string DateTimeType { get; internal set; }
        /// <summary><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        public virtual string ArrayType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        public virtual string DictionaryType { get; internal set; }
        /// <summary><p>A file path or URL to the data or the JSON data itself.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<String> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<String> ServiceSchemesInternal { get; set; } = new List<String>();
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/name:\"{value}\"", Name)
              .Add("/namespace:\"{value}\"", TargetNamespace)
              .Add("/requiredPropertiesMustBeDefined:\"{value}\"", RequiredPropertiesMustBeDefined)
              .Add("/dateTimeType:\"{value}\"", DateTimeType)
              .Add("/arrayType:\"{value}\"", ArrayType)
              .Add("/dictionaryType:\"{value}\"", DictionaryType)
              .Add("/input:\"{value}\"", Input)
              .Add("/serviceHost:\"{value}\"", ServiceHost)
              .Add("/serviceSchemes:\"{value}\"", ServiceSchemes, separator: ',')
              .Add("/output:\"{value}\"", Output);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagJsonSchema2TsClientSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagJsonSchema2TsClientSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        /// <summary><p>The type name of the root schema.</p></summary>
        public virtual string Name { get; internal set; }
        /// <summary><p>A file path or URL to the data or the JSON data itself.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<String> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<String> ServiceSchemesInternal { get; set; } = new List<String>();
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/name:\"{value}\"", Name)
              .Add("/input:\"{value}\"", Input)
              .Add("/serviceHost:\"{value}\"", ServiceHost)
              .Add("/serviceSchemes:\"{value}\"", ServiceSchemes, separator: ',')
              .Add("/output:\"{value}\"", Output);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagSwagger2CsClientSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagSwagger2CsClientSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        /// <summary><p>The client base class (empty for no base class).</p></summary>
        public virtual string ClientBaseClass { get; internal set; }
        /// <summary><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        public virtual string ConfigurationClass { get; internal set; }
        /// <summary><p>Specifies whether generate client classes.</p></summary>
        public virtual bool? GenerateClientClasses { get; internal set; }
        /// <summary><p>Specifies whether generate interfaces for the client classes.</p></summary>
        public virtual bool? GenerateClientInterfaces { get; internal set; }
        /// <summary><p>Specifies whether to generate DTO classes.</p></summary>
        public virtual bool? GenerateDtoTypes { get; internal set; }
        /// <summary><p>Specifies whether an HttpClient instance is injected.</p></summary>
        public virtual bool? InjectHttpClient { get; internal set; }
        /// <summary><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        public virtual bool? DisposeHttpClient { get; internal set; }
        /// <summary><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        public virtual IReadOnlyList<String> ProtectedMethods => ProtectedMethodsInternal.AsReadOnly();
        internal List<String> ProtectedMethodsInternal { get; set; } = new List<String>();
        /// <summary><p>Specifies whether to generate exception classes (default: true).</p></summary>
        public virtual bool? GenerateExceptionClasses { get; internal set; }
        /// <summary><p>The exception class (default 'SwaggerException', may use '{controller}' placeholder).</p></summary>
        public virtual string ExceptionClass { get; internal set; }
        /// <summary><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        public virtual bool? WrapDtoExceptions { get; internal set; }
        /// <summary><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        public virtual bool? UseHttpClientCreationMethod { get; internal set; }
        /// <summary><p>Specifies the HttpClient type. By default the 'System.Net.Http.HttpClient' is used.</p></summary>
        public virtual string HttpClientType { get; internal set; }
        /// <summary><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        public virtual bool? UseHttpRequestMessageCreationMethod { get; internal set; }
        /// <summary><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        public virtual bool? UseBaseUrl { get; internal set; }
        /// <summary><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        public virtual bool? GenerateBaseUrlProperty { get; internal set; }
        /// <summary><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        public virtual bool? GenerateSyncMethods { get; internal set; }
        /// <summary><p>The client class access modifier (default: public).</p></summary>
        public virtual string ClientClassAccessModifier { get; internal set; }
        /// <summary><p>The DTO class/enum access modifier (default: public).</p></summary>
        public virtual string TypeAccessModifier { get; internal set; }
        /// <summary><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        public virtual bool? GenerateContractsOutput { get; internal set; }
        /// <summary><p>The contracts .NET namespace.</p></summary>
        public virtual string ContractsTargetNamespace { get; internal set; }
        /// <summary><p>The contracts output file path (optional, if no path is set then a single file with the implementation and contracts is generated).</p></summary>
        public virtual string ContractsOutput { get; internal set; }
        /// <summary><p>Specifies the format for DateTime type method parameters (default: s).</p></summary>
        public virtual string ParameterDateTimeFormat { get; internal set; }
        /// <summary><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        public virtual bool? GenerateUpdateJsonSerializerSettingsMethod { get; internal set; }
        /// <summary><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        public virtual bool? SerializeTypeInformation { get; internal set; }
        /// <summary><p>The null value used for query parameters which are null (default: '').</p></summary>
        public virtual string QueryNullValue { get; internal set; }
        /// <summary><p>The class name of the generated client.</p></summary>
        public virtual string ClassName { get; internal set; }
        /// <summary><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        public virtual OperationGenerationMode OperationGenerationMode { get; internal set; }
        /// <summary><p>The additional namespace usages.</p></summary>
        public virtual IReadOnlyList<String> AdditionalTargetNamespaceUsages => AdditionalTargetNamespaceUsagesInternal.AsReadOnly();
        internal List<String> AdditionalTargetNamespaceUsagesInternal { get; set; } = new List<String>();
        /// <summary><p>The additional contract namespace usages.</p></summary>
        public virtual IReadOnlyList<String> AdditionalContractTargetNamespaceUsages => AdditionalContractTargetNamespaceUsagesInternal.AsReadOnly();
        internal List<String> AdditionalContractTargetNamespaceUsagesInternal { get; set; } = new List<String>();
        /// <summary><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        public virtual bool? GenerateOptionalParameters { get; internal set; }
        /// <summary><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        public virtual string ParameterArrayType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        public virtual string ParameterDictionaryType { get; internal set; }
        /// <summary><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        public virtual string ResponseArrayType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        public virtual string ResponseDictionaryType { get; internal set; }
        /// <summary><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        public virtual bool? WrapResponses { get; internal set; }
        /// <summary><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        public virtual IReadOnlyList<String> WrapResponseMethods => WrapResponseMethodsInternal.AsReadOnly();
        internal List<String> WrapResponseMethodsInternal { get; set; } = new List<String>();
        /// <summary><p>Specifies whether to generate response classes (default: true).</p></summary>
        public virtual bool? GenerateResponseClasses { get; internal set; }
        /// <summary><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        public virtual string ResponseClass { get; internal set; }
        /// <summary><p>The namespace of the generated classes.</p></summary>
        public virtual string TargetNamespace { get; internal set; }
        /// <summary><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        public virtual bool? RequiredPropertiesMustBeDefined { get; internal set; }
        /// <summary><p>The date .NET type (default: 'DateTime').</p></summary>
        public virtual string DateType { get; internal set; }
        /// <summary><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        public virtual IReadOnlyList<String> JsonConverters => JsonConvertersInternal.AsReadOnly();
        internal List<String> JsonConvertersInternal { get; set; } = new List<String>();
        /// <summary><p>The date time .NET type (default: 'DateTime').</p></summary>
        public virtual string DateTimeType { get; internal set; }
        /// <summary><p>The time .NET type (default: 'TimeSpan').</p></summary>
        public virtual string TimeType { get; internal set; }
        /// <summary><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        public virtual string TimeSpanType { get; internal set; }
        /// <summary><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        public virtual string ArrayType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        public virtual string DictionaryType { get; internal set; }
        /// <summary><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        public virtual string ArrayBaseType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        public virtual string DictionaryBaseType { get; internal set; }
        /// <summary><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        public virtual CSharpClassStyle ClassStyle { get; internal set; }
        /// <summary><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        public virtual bool? GenerateDefaultValues { get; internal set; }
        /// <summary><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        public virtual bool? GenerateDataAnnotations { get; internal set; }
        /// <summary><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        public virtual IReadOnlyList<String> ExcludedTypeNames => ExcludedTypeNamesInternal.AsReadOnly();
        internal List<String> ExcludedTypeNamesInternal { get; set; } = new List<String>();
        /// <summary><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        public virtual bool? HandleReferences { get; internal set; }
        /// <summary><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        public virtual bool? GenerateImmutableArrayProperties { get; internal set; }
        /// <summary><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        public virtual bool? GenerateImmutableDictionaryProperties { get; internal set; }
        /// <summary><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        public virtual string JsonSerializerSettingsTransformationMethod { get; internal set; }
        /// <summary><p>The Liquid template directory (experimental).</p></summary>
        public virtual string TemplateDirectory { get; internal set; }
        /// <summary><p>A file path or URL to the data or the JSON data itself.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<String> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<String> ServiceSchemesInternal { get; set; } = new List<String>();
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/clientBaseClass:\"{value}\"", ClientBaseClass)
              .Add("/configurationClass:\"{value}\"", ConfigurationClass)
              .Add("/generateClientClasses:\"{value}\"", GenerateClientClasses)
              .Add("/generateClientInterfaces:\"{value}\"", GenerateClientInterfaces)
              .Add("/generateDtoTypes:\"{value}\"", GenerateDtoTypes)
              .Add("/injectHttpClient:\"{value}\"", InjectHttpClient)
              .Add("/disposeHttpClient:\"{value}\"", DisposeHttpClient)
              .Add("/protectedMethods:\"{value}\"", ProtectedMethods, separator: ',')
              .Add("/generateExceptionClasses:\"{value}\"", GenerateExceptionClasses)
              .Add("/exceptionClass:\"{value}\"", ExceptionClass)
              .Add("/wrapDtoExceptions:\"{value}\"", WrapDtoExceptions)
              .Add("/useHttpClientCreationMethod:\"{value}\"", UseHttpClientCreationMethod)
              .Add("/httpClientType:\"{value}\"", HttpClientType)
              .Add("/useHttpRequestMessageCreationMethod:\"{value}\"", UseHttpRequestMessageCreationMethod)
              .Add("/useBaseUrl:\"{value}\"", UseBaseUrl)
              .Add("/generateBaseUrlProperty:\"{value}\"", GenerateBaseUrlProperty)
              .Add("/generateSyncMethods:\"{value}\"", GenerateSyncMethods)
              .Add("/clientClassAccessModifier:\"{value}\"", ClientClassAccessModifier)
              .Add("/typeAccessModifier:\"{value}\"", TypeAccessModifier)
              .Add("/generateContractsOutput:\"{value}\"", GenerateContractsOutput)
              .Add("/contractsNamespace:\"{value}\"", ContractsTargetNamespace)
              .Add("/contractsOutput:\"{value}\"", ContractsOutput)
              .Add("/parameterDateTimeFormat:\"{value}\"", ParameterDateTimeFormat)
              .Add("/generateUpdateJsonSerializerSettingsMethod:\"{value}\"", GenerateUpdateJsonSerializerSettingsMethod)
              .Add("/serializeTypeInformation:\"{value}\"", SerializeTypeInformation)
              .Add("/queryNullValue:\"{value}\"", QueryNullValue)
              .Add("/className:\"{value}\"", ClassName)
              .Add("/operationGenerationMode:\"{value}\"", OperationGenerationMode)
              .Add("/additionalNamespaceUsages:\"{value}\"", AdditionalTargetNamespaceUsages, separator: ',')
              .Add("/additionalContractNamespaceUsages:\"{value}\"", AdditionalContractTargetNamespaceUsages, separator: ',')
              .Add("/generateOptionalParameters:\"{value}\"", GenerateOptionalParameters)
              .Add("/parameterArrayType:\"{value}\"", ParameterArrayType)
              .Add("/parameterDictionaryType:\"{value}\"", ParameterDictionaryType)
              .Add("/responseArrayType:\"{value}\"", ResponseArrayType)
              .Add("/responseDictionaryType:\"{value}\"", ResponseDictionaryType)
              .Add("/wrapResponses:\"{value}\"", WrapResponses)
              .Add("/wrapResponseMethods:\"{value}\"", WrapResponseMethods, separator: ',')
              .Add("/generateResponseClasses:\"{value}\"", GenerateResponseClasses)
              .Add("/responseClass:\"{value}\"", ResponseClass)
              .Add("/namespace:\"{value}\"", TargetNamespace)
              .Add("/requiredPropertiesMustBeDefined:\"{value}\"", RequiredPropertiesMustBeDefined)
              .Add("/dateType:\"{value}\"", DateType)
              .Add("/jsonConverters:\"{value}\"", JsonConverters, separator: ',')
              .Add("/dateTimeType:\"{value}\"", DateTimeType)
              .Add("/timeType:\"{value}\"", TimeType)
              .Add("/timeSpanType:\"{value}\"", TimeSpanType)
              .Add("/arrayType:\"{value}\"", ArrayType)
              .Add("/dictionaryType:\"{value}\"", DictionaryType)
              .Add("/arrayBaseType:\"{value}\"", ArrayBaseType)
              .Add("/dictionaryBaseType:\"{value}\"", DictionaryBaseType)
              .Add("/classStyle:\"{value}\"", ClassStyle)
              .Add("/generateDefaultValues:\"{value}\"", GenerateDefaultValues)
              .Add("/generateDataAnnotations:\"{value}\"", GenerateDataAnnotations)
              .Add("/excludedTypeNames:\"{value}\"", ExcludedTypeNames, separator: ',')
              .Add("/handleReferences:\"{value}\"", HandleReferences)
              .Add("/generateImmutableArrayProperties:\"{value}\"", GenerateImmutableArrayProperties)
              .Add("/generateImmutableDictionaryProperties:\"{value}\"", GenerateImmutableDictionaryProperties)
              .Add("/jsonSerializerSettingsTransformationMethod:\"{value}\"", JsonSerializerSettingsTransformationMethod)
              .Add("/templateDirectory:\"{value}\"", TemplateDirectory)
              .Add("/input:\"{value}\"", Input)
              .Add("/serviceHost:\"{value}\"", ServiceHost)
              .Add("/serviceSchemes:\"{value}\"", ServiceSchemes, separator: ',')
              .Add("/output:\"{value}\"", Output);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagSwagger2CscontrollerSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagSwagger2CscontrollerSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        /// <summary><p>The controller base class (empty for 'ApiController').</p></summary>
        public virtual string ControllerBaseClass { get; internal set; }
        /// <summary><p>The controller generation style (partial, abstract; default: partial).</p></summary>
        public virtual CSharpControllerStyle ControllerStyle { get; internal set; }
        /// <summary><p>Add a cancellation token parameter (default: false).</p></summary>
        public virtual bool? UseCancellationToken { get; internal set; }
        /// <summary><p>The ASP.NET (Core) framework namespace (default: 'System.Web.Http').</p></summary>
        public virtual string AspNetTargetNamespace { get; internal set; }
        /// <summary><p>The class name of the generated client.</p></summary>
        public virtual string ClassName { get; internal set; }
        /// <summary><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        public virtual OperationGenerationMode OperationGenerationMode { get; internal set; }
        /// <summary><p>The additional namespace usages.</p></summary>
        public virtual IReadOnlyList<String> AdditionalTargetNamespaceUsages => AdditionalTargetNamespaceUsagesInternal.AsReadOnly();
        internal List<String> AdditionalTargetNamespaceUsagesInternal { get; set; } = new List<String>();
        /// <summary><p>The additional contract namespace usages.</p></summary>
        public virtual IReadOnlyList<String> AdditionalContractTargetNamespaceUsages => AdditionalContractTargetNamespaceUsagesInternal.AsReadOnly();
        internal List<String> AdditionalContractTargetNamespaceUsagesInternal { get; set; } = new List<String>();
        /// <summary><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        public virtual bool? GenerateOptionalParameters { get; internal set; }
        /// <summary><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        public virtual string ParameterArrayType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        public virtual string ParameterDictionaryType { get; internal set; }
        /// <summary><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        public virtual string ResponseArrayType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        public virtual string ResponseDictionaryType { get; internal set; }
        /// <summary><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        public virtual bool? WrapResponses { get; internal set; }
        /// <summary><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        public virtual IReadOnlyList<String> WrapResponseMethods => WrapResponseMethodsInternal.AsReadOnly();
        internal List<String> WrapResponseMethodsInternal { get; set; } = new List<String>();
        /// <summary><p>Specifies whether to generate response classes (default: true).</p></summary>
        public virtual bool? GenerateResponseClasses { get; internal set; }
        /// <summary><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        public virtual string ResponseClass { get; internal set; }
        /// <summary><p>The namespace of the generated classes.</p></summary>
        public virtual string TargetNamespace { get; internal set; }
        /// <summary><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        public virtual bool? RequiredPropertiesMustBeDefined { get; internal set; }
        /// <summary><p>The date .NET type (default: 'DateTime').</p></summary>
        public virtual string DateType { get; internal set; }
        /// <summary><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        public virtual IReadOnlyList<String> JsonConverters => JsonConvertersInternal.AsReadOnly();
        internal List<String> JsonConvertersInternal { get; set; } = new List<String>();
        /// <summary><p>The date time .NET type (default: 'DateTime').</p></summary>
        public virtual string DateTimeType { get; internal set; }
        /// <summary><p>The time .NET type (default: 'TimeSpan').</p></summary>
        public virtual string TimeType { get; internal set; }
        /// <summary><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        public virtual string TimeSpanType { get; internal set; }
        /// <summary><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        public virtual string ArrayType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        public virtual string DictionaryType { get; internal set; }
        /// <summary><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        public virtual string ArrayBaseType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        public virtual string DictionaryBaseType { get; internal set; }
        /// <summary><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        public virtual CSharpClassStyle ClassStyle { get; internal set; }
        /// <summary><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        public virtual bool? GenerateDefaultValues { get; internal set; }
        /// <summary><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        public virtual bool? GenerateDataAnnotations { get; internal set; }
        /// <summary><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        public virtual IReadOnlyList<String> ExcludedTypeNames => ExcludedTypeNamesInternal.AsReadOnly();
        internal List<String> ExcludedTypeNamesInternal { get; set; } = new List<String>();
        /// <summary><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        public virtual bool? HandleReferences { get; internal set; }
        /// <summary><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        public virtual bool? GenerateImmutableArrayProperties { get; internal set; }
        /// <summary><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        public virtual bool? GenerateImmutableDictionaryProperties { get; internal set; }
        /// <summary><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        public virtual string JsonSerializerSettingsTransformationMethod { get; internal set; }
        /// <summary><p>The Liquid template directory (experimental).</p></summary>
        public virtual string TemplateDirectory { get; internal set; }
        /// <summary><p>A file path or URL to the data or the JSON data itself.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<String> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<String> ServiceSchemesInternal { get; set; } = new List<String>();
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/controllerBaseClass:\"{value}\"", ControllerBaseClass)
              .Add("/controllerStyle:\"{value}\"", ControllerStyle)
              .Add("/useCancellationToken:\"{value}\"", UseCancellationToken)
              .Add("/aspNetNamespace:\"{value}\"", AspNetTargetNamespace)
              .Add("/className:\"{value}\"", ClassName)
              .Add("/operationGenerationMode:\"{value}\"", OperationGenerationMode)
              .Add("/additionalNamespaceUsages:\"{value}\"", AdditionalTargetNamespaceUsages, separator: ',')
              .Add("/additionalContractNamespaceUsages:\"{value}\"", AdditionalContractTargetNamespaceUsages, separator: ',')
              .Add("/generateOptionalParameters:\"{value}\"", GenerateOptionalParameters)
              .Add("/parameterArrayType:\"{value}\"", ParameterArrayType)
              .Add("/parameterDictionaryType:\"{value}\"", ParameterDictionaryType)
              .Add("/responseArrayType:\"{value}\"", ResponseArrayType)
              .Add("/responseDictionaryType:\"{value}\"", ResponseDictionaryType)
              .Add("/wrapResponses:\"{value}\"", WrapResponses)
              .Add("/wrapResponseMethods:\"{value}\"", WrapResponseMethods, separator: ',')
              .Add("/generateResponseClasses:\"{value}\"", GenerateResponseClasses)
              .Add("/responseClass:\"{value}\"", ResponseClass)
              .Add("/namespace:\"{value}\"", TargetNamespace)
              .Add("/requiredPropertiesMustBeDefined:\"{value}\"", RequiredPropertiesMustBeDefined)
              .Add("/dateType:\"{value}\"", DateType)
              .Add("/jsonConverters:\"{value}\"", JsonConverters, separator: ',')
              .Add("/dateTimeType:\"{value}\"", DateTimeType)
              .Add("/timeType:\"{value}\"", TimeType)
              .Add("/timeSpanType:\"{value}\"", TimeSpanType)
              .Add("/arrayType:\"{value}\"", ArrayType)
              .Add("/dictionaryType:\"{value}\"", DictionaryType)
              .Add("/arrayBaseType:\"{value}\"", ArrayBaseType)
              .Add("/dictionaryBaseType:\"{value}\"", DictionaryBaseType)
              .Add("/classStyle:\"{value}\"", ClassStyle)
              .Add("/generateDefaultValues:\"{value}\"", GenerateDefaultValues)
              .Add("/generateDataAnnotations:\"{value}\"", GenerateDataAnnotations)
              .Add("/excludedTypeNames:\"{value}\"", ExcludedTypeNames, separator: ',')
              .Add("/handleReferences:\"{value}\"", HandleReferences)
              .Add("/generateImmutableArrayProperties:\"{value}\"", GenerateImmutableArrayProperties)
              .Add("/generateImmutableDictionaryProperties:\"{value}\"", GenerateImmutableDictionaryProperties)
              .Add("/jsonSerializerSettingsTransformationMethod:\"{value}\"", JsonSerializerSettingsTransformationMethod)
              .Add("/templateDirectory:\"{value}\"", TemplateDirectory)
              .Add("/input:\"{value}\"", Input)
              .Add("/serviceHost:\"{value}\"", ServiceHost)
              .Add("/serviceSchemes:\"{value}\"", ServiceSchemes, separator: ',')
              .Add("/output:\"{value}\"", Output);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagSwagger2TsClientSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagSwagger2TsClientSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? $"{GetToolPath()}";
        /// <summary><p>The class name of the generated client.</p></summary>
        public virtual string ClassName { get; internal set; }
        /// <summary><p>The TypeScript module name (default: '', no module).</p></summary>
        public virtual string ModuleName { get; internal set; }
        /// <summary><p>The TypeScript namespace (default: '', no namespace).</p></summary>
        public virtual string TargetNamespace { get; internal set; }
        /// <summary><p>The target TypeScript version (default: 1.8).</p></summary>
        public virtual string TypeScriptVersion { get; internal set; }
        /// <summary><p>The type of the asynchronism handling ('JQueryCallbacks', 'JQueryPromises', 'AngularJS', 'Angular', 'Fetch', 'Aurelia').</p></summary>
        public virtual TypeScriptTemplate Template { get; internal set; }
        /// <summary><p>The promise type ('Promise' or 'QPromise').</p></summary>
        public virtual PromiseType PromiseType { get; internal set; }
        /// <summary><p>The Angular HTTP service class (default 'Http', 'HttpClient').</p></summary>
        public virtual HttpClass HttpClass { get; internal set; }
        /// <summary><p>The Angular injection token type (default 'OpaqueToken', 'InjectionToken').</p></summary>
        public virtual InjectionTokenType InjectionTokenType { get; internal set; }
        /// <summary><p>The date time type ('Date', 'MomentJS', 'OffsetMomentJS', 'string').</p></summary>
        public virtual TypeScriptDateTimeType DateTimeType { get; internal set; }
        /// <summary><p>The null value used in object initializers (default 'Undefined', 'Null').</p></summary>
        public virtual TypeScriptNullValue NullValue { get; internal set; }
        /// <summary><p>Specifies whether generate client classes.</p></summary>
        public virtual bool? GenerateClientClasses { get; internal set; }
        /// <summary><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        public virtual bool? GenerateClientInterfaces { get; internal set; }
        /// <summary><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        public virtual bool? GenerateOptionalParameters { get; internal set; }
        /// <summary><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        public virtual bool? WrapDtoExceptions { get; internal set; }
        /// <summary><p>The base class of the generated client classes (optional, must be imported or implemented in the extension code).</p></summary>
        public virtual string ClientBaseClass { get; internal set; }
        /// <summary><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        public virtual bool? WrapResponses { get; internal set; }
        /// <summary><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        public virtual IReadOnlyList<String> WrapResponseMethods => WrapResponseMethodsInternal.AsReadOnly();
        internal List<String> WrapResponseMethodsInternal { get; set; } = new List<String>();
        /// <summary><p>Specifies whether to generate response classes (default: true).</p></summary>
        public virtual bool? GenerateResponseClasses { get; internal set; }
        /// <summary><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        public virtual string ResponseClass { get; internal set; }
        /// <summary><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        public virtual IReadOnlyList<String> ProtectedMethods => ProtectedMethodsInternal.AsReadOnly();
        internal List<String> ProtectedMethodsInternal { get; set; } = new List<String>();
        /// <summary><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        public virtual string ConfigurationClass { get; internal set; }
        /// <summary><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        public virtual bool? UseTransformOptionsMethod { get; internal set; }
        /// <summary><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        public virtual bool? UseTransformResultMethod { get; internal set; }
        /// <summary><p>Specifies whether to generate DTO classes.</p></summary>
        public virtual bool? GenerateDtoTypes { get; internal set; }
        /// <summary><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        public virtual OperationGenerationMode OperationGenerationMode { get; internal set; }
        /// <summary><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        public virtual bool? MarkOptionalProperties { get; internal set; }
        /// <summary><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        public virtual bool? GenerateCloneMethod { get; internal set; }
        /// <summary><p>The type style (default: Class).</p></summary>
        public virtual TypeScriptTypeStyle TypeStyle { get; internal set; }
        /// <summary><p>The type names which always generate plain TypeScript classes.</p></summary>
        public virtual IReadOnlyList<String> ClassTypes => ClassTypesInternal.AsReadOnly();
        internal List<String> ClassTypesInternal { get; set; } = new List<String>();
        /// <summary><p>The list of extended classes.</p></summary>
        public virtual IReadOnlyList<String> ExtendedClasses => ExtendedClassesInternal.AsReadOnly();
        internal List<String> ExtendedClassesInternal { get; set; } = new List<String>();
        /// <summary><p>The extension code (string or file path).</p></summary>
        public virtual string ExtensionCode { get; internal set; }
        /// <summary><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        public virtual bool? GenerateDefaultValues { get; internal set; }
        /// <summary><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        public virtual IReadOnlyList<String> ExcludedTypeNames => ExcludedTypeNamesInternal.AsReadOnly();
        internal List<String> ExcludedTypeNamesInternal { get; set; } = new List<String>();
        /// <summary><p>Handle JSON references (default: false).</p></summary>
        public virtual bool? HandleReferences { get; internal set; }
        /// <summary><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        public virtual bool? GenerateConstructorInterface { get; internal set; }
        /// <summary><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        public virtual bool? ConvertConstructorInterfaceData { get; internal set; }
        /// <summary><p>Specifies whether required types should be imported (default: true).</p></summary>
        public virtual bool? ImportRequiredTypes { get; internal set; }
        /// <summary><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        public virtual bool? UseGetBaseUrlMethod { get; internal set; }
        /// <summary><p>The token name for injecting the API base URL string (used in the Angular template, default: 'API_BASE_URL').</p></summary>
        public virtual string BaseUrlTokenName { get; internal set; }
        /// <summary><p>The null value used for query parameters which are null (default: '').</p></summary>
        public virtual string QueryNullValue { get; internal set; }
        /// <summary><p>The Liquid template directory (experimental).</p></summary>
        public virtual string TemplateDirectory { get; internal set; }
        /// <summary><p>A file path or URL to the data or the JSON data itself.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<String> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<String> ServiceSchemesInternal { get; set; } = new List<String>();
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/className:\"{value}\"", ClassName)
              .Add("/moduleName:\"{value}\"", ModuleName)
              .Add("/namespace:\"{value}\"", TargetNamespace)
              .Add("/typeScriptVersion:\"{value}\"", TypeScriptVersion)
              .Add("/template:\"{value}\"", Template)
              .Add("/promiseType:\"{value}\"", PromiseType)
              .Add("/httpClass:\"{value}\"", HttpClass)
              .Add("/injectionTokenType:\"{value}\"", InjectionTokenType)
              .Add("/dateTimeType:\"{value}\"", DateTimeType)
              .Add("/nullValue:\"{value}\"", NullValue)
              .Add("/generateClientClasses:\"{value}\"", GenerateClientClasses)
              .Add("/generateClientInterfaces:\"{value}\"", GenerateClientInterfaces)
              .Add("/generateOptionalParameters:\"{value}\"", GenerateOptionalParameters)
              .Add("/wrapDtoExceptions:\"{value}\"", WrapDtoExceptions)
              .Add("/clientBaseClass:\"{value}\"", ClientBaseClass)
              .Add("/wrapResponses:\"{value}\"", WrapResponses)
              .Add("/wrapResponseMethods:\"{value}\"", WrapResponseMethods, separator: ',')
              .Add("/generateResponseClasses:\"{value}\"", GenerateResponseClasses)
              .Add("/responseClass:\"{value}\"", ResponseClass)
              .Add("/protectedMethods:\"{value}\"", ProtectedMethods, separator: ',')
              .Add("/configurationClass:\"{value}\"", ConfigurationClass)
              .Add("/useTransformOptionsMethod:\"{value}\"", UseTransformOptionsMethod)
              .Add("/useTransformResultMethod:\"{value}\"", UseTransformResultMethod)
              .Add("/generateDtoTypes:\"{value}\"", GenerateDtoTypes)
              .Add("/operationGenerationMode:\"{value}\"", OperationGenerationMode)
              .Add("/markOptionalProperties:\"{value}\"", MarkOptionalProperties)
              .Add("/generateCloneMethod:\"{value}\"", GenerateCloneMethod)
              .Add("/typeStyle:\"{value}\"", TypeStyle)
              .Add("/classTypes:\"{value}\"", ClassTypes, separator: ',')
              .Add("/extendedClasses:\"{value}\"", ExtendedClasses, separator: ',')
              .Add("/extensionCode:\"{value}\"", ExtensionCode)
              .Add("/generateDefaultValues:\"{value}\"", GenerateDefaultValues)
              .Add("/excludedTypeNames:\"{value}\"", ExcludedTypeNames, separator: ',')
              .Add("/handleReferences:\"{value}\"", HandleReferences)
              .Add("/generateConstructorInterface:\"{value}\"", GenerateConstructorInterface)
              .Add("/convertConstructorInterfaceData:\"{value}\"", ConvertConstructorInterfaceData)
              .Add("/importRequiredTypes:\"{value}\"", ImportRequiredTypes)
              .Add("/useGetBaseUrlMethod:\"{value}\"", UseGetBaseUrlMethod)
              .Add("/baseUrlTokenName:\"{value}\"", BaseUrlTokenName)
              .Add("/queryNullValue:\"{value}\"", QueryNullValue)
              .Add("/templateDirectory:\"{value}\"", TemplateDirectory)
              .Add("/input:\"{value}\"", Input)
              .Add("/serviceHost:\"{value}\"", ServiceHost)
              .Add("/serviceSchemes:\"{value}\"", ServiceSchemes, separator: ',')
              .Add("/output:\"{value}\"", Output);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagAspNetCore2SwaggerSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagAspNetCore2SwaggerSettingsExtensions
    {
        #region Project
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.Project"/>.</em></p><p>The project to use.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetProject(this NSwagAspNetCore2SwaggerSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.Project"/>.</em></p><p>The project to use.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetProject(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildProjectExtensionsPath
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.MSBuildProjectExtensionsPath"/>.</em></p><p>The MSBuild project extensions path. Defaults to "obj".</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetMSBuildProjectExtensionsPath(this NSwagAspNetCore2SwaggerSettings toolSettings, string msbuildProjectExtensionsPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProjectExtensionsPath = msbuildProjectExtensionsPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.MSBuildProjectExtensionsPath"/>.</em></p><p>The MSBuild project extensions path. Defaults to "obj".</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetMSBuildProjectExtensionsPath(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProjectExtensionsPath = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.Configuration"/>.</em></p><p>The configuration to use.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetConfiguration(this NSwagAspNetCore2SwaggerSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.Configuration"/>.</em></p><p>The configuration to use.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetConfiguration(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.Runtime"/>.</em></p><p>The runtime to use.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetRuntime(this NSwagAspNetCore2SwaggerSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.Runtime"/>.</em></p><p>The runtime to use.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetRuntime(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region TargetFramework
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.TargetFramework"/>.</em></p><p>The target framework to use.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetTargetFramework(this NSwagAspNetCore2SwaggerSettings toolSettings, string targetFramework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetFramework = targetFramework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.TargetFramework"/>.</em></p><p>The target framework to use.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetTargetFramework(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetFramework = null;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.NoBuild"/>.</em></p><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetNoBuild(this NSwagAspNetCore2SwaggerSettings toolSettings, bool? noBuild)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.NoBuild"/>.</em></p><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetNoBuild(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCore2SwaggerSettings.NoBuild"/>.</em></p><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings EnableNoBuild(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCore2SwaggerSettings.NoBuild"/>.</em></p><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings DisableNoBuild(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCore2SwaggerSettings.NoBuild"/>.</em></p><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ToggleNoBuild(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.Verbose"/>.</em></p><p>Print verbose output.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetVerbose(this NSwagAspNetCore2SwaggerSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.Verbose"/>.</em></p><p>Print verbose output.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetVerbose(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCore2SwaggerSettings.Verbose"/>.</em></p><p>Print verbose output.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings EnableVerbose(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCore2SwaggerSettings.Verbose"/>.</em></p><p>Print verbose output.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings DisableVerbose(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCore2SwaggerSettings.Verbose"/>.</em></p><p>Print verbose output.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ToggleVerbose(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.Output"/>.</em></p><p>The output file.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetOutput(this NSwagAspNetCore2SwaggerSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.Output"/>.</em></p><p>The output file.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetOutput(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region DefaultPropertyNameHandling
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetDefaultPropertyNameHandling(this NSwagAspNetCore2SwaggerSettings toolSettings, PropertyNameHandling defaultPropertyNameHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = defaultPropertyNameHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetDefaultPropertyNameHandling(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultReferenceTypeNullHandling
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetDefaultReferenceTypeNullHandling(this NSwagAspNetCore2SwaggerSettings toolSettings, ReferenceTypeNullHandling defaultReferenceTypeNullHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = defaultReferenceTypeNullHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetDefaultReferenceTypeNullHandling(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultEnumHandling
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetDefaultEnumHandling(this NSwagAspNetCore2SwaggerSettings toolSettings, EnumHandling defaultEnumHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = defaultEnumHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetDefaultEnumHandling(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = null;
            return toolSettings;
        }
        #endregion
        #region FlattenInheritanceHierarchy
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetFlattenInheritanceHierarchy(this NSwagAspNetCore2SwaggerSettings toolSettings, bool? flattenInheritanceHierarchy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = flattenInheritanceHierarchy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetFlattenInheritanceHierarchy(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCore2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings EnableFlattenInheritanceHierarchy(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCore2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings DisableFlattenInheritanceHierarchy(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCore2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ToggleFlattenInheritanceHierarchy(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = !toolSettings.FlattenInheritanceHierarchy;
            return toolSettings;
        }
        #endregion
        #region GenerateKnownTypes
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetGenerateKnownTypes(this NSwagAspNetCore2SwaggerSettings toolSettings, bool? generateKnownTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = generateKnownTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetGenerateKnownTypes(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCore2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings EnableGenerateKnownTypes(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCore2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings DisableGenerateKnownTypes(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCore2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ToggleGenerateKnownTypes(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = !toolSettings.GenerateKnownTypes;
            return toolSettings;
        }
        #endregion
        #region GenerateXmlObjects
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetGenerateXmlObjects(this NSwagAspNetCore2SwaggerSettings toolSettings, bool? generateXmlObjects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = generateXmlObjects;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetGenerateXmlObjects(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCore2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings EnableGenerateXmlObjects(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCore2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings DisableGenerateXmlObjects(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCore2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ToggleGenerateXmlObjects(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = !toolSettings.GenerateXmlObjects;
            return toolSettings;
        }
        #endregion
        #region GenerateAbstractProperties
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetGenerateAbstractProperties(this NSwagAspNetCore2SwaggerSettings toolSettings, bool? generateAbstractProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = generateAbstractProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetGenerateAbstractProperties(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCore2SwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings EnableGenerateAbstractProperties(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCore2SwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings DisableGenerateAbstractProperties(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCore2SwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ToggleGenerateAbstractProperties(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = !toolSettings.GenerateAbstractProperties;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetServiceHost(this NSwagAspNetCore2SwaggerSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetServiceHost(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceBasePath
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.ServiceBasePath"/>.</em></p><p>The basePath of the Swagger specification (optional).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetServiceBasePath(this NSwagAspNetCore2SwaggerSettings toolSettings, string serviceBasePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceBasePath = serviceBasePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.ServiceBasePath"/>.</em></p><p>The basePath of the Swagger specification (optional).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetServiceBasePath(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceBasePath = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetServiceSchemes(this NSwagAspNetCore2SwaggerSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetServiceSchemes(this NSwagAspNetCore2SwaggerSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCore2SwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings AddServiceSchemes(this NSwagAspNetCore2SwaggerSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCore2SwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings AddServiceSchemes(this NSwagAspNetCore2SwaggerSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagAspNetCore2SwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ClearServiceSchemes(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCore2SwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings RemoveServiceSchemes(this NSwagAspNetCore2SwaggerSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCore2SwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings RemoveServiceSchemes(this NSwagAspNetCore2SwaggerSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region InfoTitle
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.InfoTitle"/>.</em></p><p>Specify the title of the Swagger specification.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetInfoTitle(this NSwagAspNetCore2SwaggerSettings toolSettings, string infoTitle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoTitle = infoTitle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.InfoTitle"/>.</em></p><p>Specify the title of the Swagger specification.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetInfoTitle(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoTitle = null;
            return toolSettings;
        }
        #endregion
        #region InfoDescription
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.InfoDescription"/>.</em></p><p>Specify the description of the Swagger specification.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetInfoDescription(this NSwagAspNetCore2SwaggerSettings toolSettings, string infoDescription)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoDescription = infoDescription;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.InfoDescription"/>.</em></p><p>Specify the description of the Swagger specification.</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetInfoDescription(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoDescription = null;
            return toolSettings;
        }
        #endregion
        #region InfoVersion
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.InfoVersion"/>.</em></p><p>Specify the version of the Swagger specification (default: 1.0.0).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetInfoVersion(this NSwagAspNetCore2SwaggerSettings toolSettings, string infoVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoVersion = infoVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.InfoVersion"/>.</em></p><p>Specify the version of the Swagger specification (default: 1.0.0).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetInfoVersion(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoVersion = null;
            return toolSettings;
        }
        #endregion
        #region DocumentTemplate
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.DocumentTemplate"/>.</em></p><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetDocumentTemplate(this NSwagAspNetCore2SwaggerSettings toolSettings, string documentTemplate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentTemplate = documentTemplate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCore2SwaggerSettings.DocumentTemplate"/>.</em></p><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ResetDocumentTemplate(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentTemplate = null;
            return toolSettings;
        }
        #endregion
        #region DocumentProcessorTypes
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.DocumentProcessorTypes"/> to a new list.</em></p><p>Gets the document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetDocumentProcessorTypes(this NSwagAspNetCore2SwaggerSettings toolSettings, params String[] documentProcessorTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorTypesInternal = documentProcessorTypes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.DocumentProcessorTypes"/> to a new list.</em></p><p>Gets the document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetDocumentProcessorTypes(this NSwagAspNetCore2SwaggerSettings toolSettings, IEnumerable<String> documentProcessorTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorTypesInternal = documentProcessorTypes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCore2SwaggerSettings.DocumentProcessorTypes"/>.</em></p><p>Gets the document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings AddDocumentProcessorTypes(this NSwagAspNetCore2SwaggerSettings toolSettings, params String[] documentProcessorTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorTypesInternal.AddRange(documentProcessorTypes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCore2SwaggerSettings.DocumentProcessorTypes"/>.</em></p><p>Gets the document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings AddDocumentProcessorTypes(this NSwagAspNetCore2SwaggerSettings toolSettings, IEnumerable<String> documentProcessorTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorTypesInternal.AddRange(documentProcessorTypes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagAspNetCore2SwaggerSettings.DocumentProcessorTypes"/>.</em></p><p>Gets the document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ClearDocumentProcessorTypes(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorTypesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCore2SwaggerSettings.DocumentProcessorTypes"/>.</em></p><p>Gets the document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings RemoveDocumentProcessorTypes(this NSwagAspNetCore2SwaggerSettings toolSettings, params String[] documentProcessorTypes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(documentProcessorTypes);
            toolSettings.DocumentProcessorTypesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCore2SwaggerSettings.DocumentProcessorTypes"/>.</em></p><p>Gets the document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings RemoveDocumentProcessorTypes(this NSwagAspNetCore2SwaggerSettings toolSettings, IEnumerable<String> documentProcessorTypes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(documentProcessorTypes);
            toolSettings.DocumentProcessorTypesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region OperationProcessors
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.OperationProcessors"/> to a new list.</em></p><p>Gets the operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetOperationProcessors(this NSwagAspNetCore2SwaggerSettings toolSettings, params String[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal = operationProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagAspNetCore2SwaggerSettings.OperationProcessors"/> to a new list.</em></p><p>Gets the operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings SetOperationProcessors(this NSwagAspNetCore2SwaggerSettings toolSettings, IEnumerable<String> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal = operationProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCore2SwaggerSettings.OperationProcessors"/>.</em></p><p>Gets the operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings AddOperationProcessors(this NSwagAspNetCore2SwaggerSettings toolSettings, params String[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.AddRange(operationProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCore2SwaggerSettings.OperationProcessors"/>.</em></p><p>Gets the operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings AddOperationProcessors(this NSwagAspNetCore2SwaggerSettings toolSettings, IEnumerable<String> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.AddRange(operationProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagAspNetCore2SwaggerSettings.OperationProcessors"/>.</em></p><p>Gets the operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings ClearOperationProcessors(this NSwagAspNetCore2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCore2SwaggerSettings.OperationProcessors"/>.</em></p><p>Gets the operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings RemoveOperationProcessors(this NSwagAspNetCore2SwaggerSettings toolSettings, params String[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(operationProcessors);
            toolSettings.OperationProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCore2SwaggerSettings.OperationProcessors"/>.</em></p><p>Gets the operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCore2SwaggerSettings RemoveOperationProcessors(this NSwagAspNetCore2SwaggerSettings toolSettings, IEnumerable<String> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(operationProcessors);
            toolSettings.OperationProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagVersionSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagVersionSettingsExtensions
    {
    }
    #endregion
    #region NSwagListTypesSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagListTypesSettingsExtensions
    {
        #region File
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.File"/>.</em></p><p>The nswag.json configuration file path.</p></summary>
        [Pure]
        public static NSwagListTypesSettings SetFile(this NSwagListTypesSettings toolSettings, string file)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagListTypesSettings.File"/>.</em></p><p>The nswag.json configuration file path.</p></summary>
        [Pure]
        public static NSwagListTypesSettings ResetFile(this NSwagListTypesSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListTypesSettings SetVariables(this NSwagListTypesSettings toolSettings, string variables)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variables = variables;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagListTypesSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListTypesSettings ResetVariables(this NSwagListTypesSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variables = null;
            return toolSettings;
        }
        #endregion
        #region Assembly
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings SetAssembly(this NSwagListTypesSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings SetAssembly(this NSwagListTypesSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListTypesSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings AddAssembly(this NSwagListTypesSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListTypesSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings AddAssembly(this NSwagListTypesSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagListTypesSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings ClearAssembly(this NSwagListTypesSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListTypesSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings RemoveAssembly(this NSwagListTypesSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListTypesSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings RemoveAssembly(this NSwagListTypesSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AssemblyConfig
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagListTypesSettings SetAssemblyConfig(this NSwagListTypesSettings toolSettings, string assemblyConfig)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = assemblyConfig;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagListTypesSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagListTypesSettings ResetAssemblyConfig(this NSwagListTypesSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = null;
            return toolSettings;
        }
        #endregion
        #region ReferencePaths
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings SetReferencePaths(this NSwagListTypesSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings SetReferencePaths(this NSwagListTypesSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListTypesSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings AddReferencePaths(this NSwagListTypesSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListTypesSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings AddReferencePaths(this NSwagListTypesSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagListTypesSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings ClearReferencePaths(this NSwagListTypesSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListTypesSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings RemoveReferencePaths(this NSwagListTypesSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListTypesSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings RemoveReferencePaths(this NSwagListTypesSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagListControllersSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagListControllersSettingsExtensions
    {
        #region File
        /// <summary><p><em>Sets <see cref="NSwagListControllersSettings.File"/>.</em></p><p>The nswag.json configuration file path.</p></summary>
        [Pure]
        public static NSwagListControllersSettings SetFile(this NSwagListControllersSettings toolSettings, string file)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagListControllersSettings.File"/>.</em></p><p>The nswag.json configuration file path.</p></summary>
        [Pure]
        public static NSwagListControllersSettings ResetFile(this NSwagListControllersSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary><p><em>Sets <see cref="NSwagListControllersSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListControllersSettings SetVariables(this NSwagListControllersSettings toolSettings, string variables)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variables = variables;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagListControllersSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListControllersSettings ResetVariables(this NSwagListControllersSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variables = null;
            return toolSettings;
        }
        #endregion
        #region Assembly
        /// <summary><p><em>Sets <see cref="NSwagListControllersSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings SetAssembly(this NSwagListControllersSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagListControllersSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings SetAssembly(this NSwagListControllersSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListControllersSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings AddAssembly(this NSwagListControllersSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListControllersSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings AddAssembly(this NSwagListControllersSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagListControllersSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings ClearAssembly(this NSwagListControllersSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListControllersSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings RemoveAssembly(this NSwagListControllersSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListControllersSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings RemoveAssembly(this NSwagListControllersSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AssemblyConfig
        /// <summary><p><em>Sets <see cref="NSwagListControllersSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagListControllersSettings SetAssemblyConfig(this NSwagListControllersSettings toolSettings, string assemblyConfig)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = assemblyConfig;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagListControllersSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagListControllersSettings ResetAssemblyConfig(this NSwagListControllersSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = null;
            return toolSettings;
        }
        #endregion
        #region ReferencePaths
        /// <summary><p><em>Sets <see cref="NSwagListControllersSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings SetReferencePaths(this NSwagListControllersSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagListControllersSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings SetReferencePaths(this NSwagListControllersSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListControllersSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings AddReferencePaths(this NSwagListControllersSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListControllersSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings AddReferencePaths(this NSwagListControllersSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagListControllersSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings ClearReferencePaths(this NSwagListControllersSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListControllersSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings RemoveReferencePaths(this NSwagListControllersSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListControllersSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListControllersSettings RemoveReferencePaths(this NSwagListControllersSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagTypes2SwaggerSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagTypes2SwaggerSettingsExtensions
    {
        #region ClassNames
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.ClassNames"/> to a new list.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetClassNames(this NSwagTypes2SwaggerSettings toolSettings, params String[] classNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassNamesInternal = classNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.ClassNames"/> to a new list.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetClassNames(this NSwagTypes2SwaggerSettings toolSettings, IEnumerable<String> classNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassNamesInternal = classNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypes2SwaggerSettings.ClassNames"/>.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings AddClassNames(this NSwagTypes2SwaggerSettings toolSettings, params String[] classNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassNamesInternal.AddRange(classNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypes2SwaggerSettings.ClassNames"/>.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings AddClassNames(this NSwagTypes2SwaggerSettings toolSettings, IEnumerable<String> classNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassNamesInternal.AddRange(classNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagTypes2SwaggerSettings.ClassNames"/>.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ClearClassNames(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypes2SwaggerSettings.ClassNames"/>.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings RemoveClassNames(this NSwagTypes2SwaggerSettings toolSettings, params String[] classNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(classNames);
            toolSettings.ClassNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypes2SwaggerSettings.ClassNames"/>.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings RemoveClassNames(this NSwagTypes2SwaggerSettings toolSettings, IEnumerable<String> classNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(classNames);
            toolSettings.ClassNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DefaultPropertyNameHandling
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetDefaultPropertyNameHandling(this NSwagTypes2SwaggerSettings toolSettings, PropertyNameHandling defaultPropertyNameHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = defaultPropertyNameHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypes2SwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ResetDefaultPropertyNameHandling(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultReferenceTypeNullHandling
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetDefaultReferenceTypeNullHandling(this NSwagTypes2SwaggerSettings toolSettings, ReferenceTypeNullHandling defaultReferenceTypeNullHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = defaultReferenceTypeNullHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypes2SwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ResetDefaultReferenceTypeNullHandling(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultEnumHandling
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetDefaultEnumHandling(this NSwagTypes2SwaggerSettings toolSettings, EnumHandling defaultEnumHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = defaultEnumHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypes2SwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ResetDefaultEnumHandling(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = null;
            return toolSettings;
        }
        #endregion
        #region FlattenInheritanceHierarchy
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetFlattenInheritanceHierarchy(this NSwagTypes2SwaggerSettings toolSettings, bool? flattenInheritanceHierarchy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = flattenInheritanceHierarchy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypes2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ResetFlattenInheritanceHierarchy(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagTypes2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings EnableFlattenInheritanceHierarchy(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagTypes2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings DisableFlattenInheritanceHierarchy(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagTypes2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ToggleFlattenInheritanceHierarchy(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = !toolSettings.FlattenInheritanceHierarchy;
            return toolSettings;
        }
        #endregion
        #region IgnoreObsoleteProperties
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetIgnoreObsoleteProperties(this NSwagTypes2SwaggerSettings toolSettings, bool? ignoreObsoleteProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = ignoreObsoleteProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypes2SwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ResetIgnoreObsoleteProperties(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagTypes2SwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings EnableIgnoreObsoleteProperties(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagTypes2SwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings DisableIgnoreObsoleteProperties(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagTypes2SwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ToggleIgnoreObsoleteProperties(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = !toolSettings.IgnoreObsoleteProperties;
            return toolSettings;
        }
        #endregion
        #region AllowReferencesWithProperties
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetAllowReferencesWithProperties(this NSwagTypes2SwaggerSettings toolSettings, bool? allowReferencesWithProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = allowReferencesWithProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypes2SwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ResetAllowReferencesWithProperties(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagTypes2SwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings EnableAllowReferencesWithProperties(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagTypes2SwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings DisableAllowReferencesWithProperties(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagTypes2SwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ToggleAllowReferencesWithProperties(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = !toolSettings.AllowReferencesWithProperties;
            return toolSettings;
        }
        #endregion
        #region GenerateKnownTypes
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetGenerateKnownTypes(this NSwagTypes2SwaggerSettings toolSettings, bool? generateKnownTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = generateKnownTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypes2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ResetGenerateKnownTypes(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagTypes2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings EnableGenerateKnownTypes(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagTypes2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings DisableGenerateKnownTypes(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagTypes2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ToggleGenerateKnownTypes(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = !toolSettings.GenerateKnownTypes;
            return toolSettings;
        }
        #endregion
        #region GenerateXmlObjects
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetGenerateXmlObjects(this NSwagTypes2SwaggerSettings toolSettings, bool? generateXmlObjects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = generateXmlObjects;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypes2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ResetGenerateXmlObjects(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagTypes2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings EnableGenerateXmlObjects(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagTypes2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings DisableGenerateXmlObjects(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagTypes2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ToggleGenerateXmlObjects(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = !toolSettings.GenerateXmlObjects;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetOutput(this NSwagTypes2SwaggerSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypes2SwaggerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ResetOutput(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Assembly
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetAssembly(this NSwagTypes2SwaggerSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetAssembly(this NSwagTypes2SwaggerSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypes2SwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings AddAssembly(this NSwagTypes2SwaggerSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypes2SwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings AddAssembly(this NSwagTypes2SwaggerSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagTypes2SwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ClearAssembly(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypes2SwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings RemoveAssembly(this NSwagTypes2SwaggerSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypes2SwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings RemoveAssembly(this NSwagTypes2SwaggerSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AssemblyConfig
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetAssemblyConfig(this NSwagTypes2SwaggerSettings toolSettings, string assemblyConfig)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = assemblyConfig;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypes2SwaggerSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ResetAssemblyConfig(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = null;
            return toolSettings;
        }
        #endregion
        #region ReferencePaths
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetReferencePaths(this NSwagTypes2SwaggerSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagTypes2SwaggerSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings SetReferencePaths(this NSwagTypes2SwaggerSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypes2SwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings AddReferencePaths(this NSwagTypes2SwaggerSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypes2SwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings AddReferencePaths(this NSwagTypes2SwaggerSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagTypes2SwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings ClearReferencePaths(this NSwagTypes2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypes2SwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings RemoveReferencePaths(this NSwagTypes2SwaggerSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypes2SwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypes2SwaggerSettings RemoveReferencePaths(this NSwagTypes2SwaggerSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagWebApi2SwaggerSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagWebApi2SwaggerSettingsExtensions
    {
        #region Controller
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.Controller"/>.</em></p><p>The Web API controller full class name or empty to load all controllers from the assembly.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetController(this NSwagWebApi2SwaggerSettings toolSettings, string controller)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Controller = controller;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.Controller"/>.</em></p><p>The Web API controller full class name or empty to load all controllers from the assembly.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetController(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Controller = null;
            return toolSettings;
        }
        #endregion
        #region Controllers
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.Controllers"/> to a new list.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetControllers(this NSwagWebApi2SwaggerSettings toolSettings, params String[] controllers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllersInternal = controllers.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.Controllers"/> to a new list.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetControllers(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> controllers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllersInternal = controllers.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.Controllers"/>.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddControllers(this NSwagWebApi2SwaggerSettings toolSettings, params String[] controllers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllersInternal.AddRange(controllers);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.Controllers"/>.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddControllers(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> controllers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllersInternal.AddRange(controllers);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApi2SwaggerSettings.Controllers"/>.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ClearControllers(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.Controllers"/>.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveControllers(this NSwagWebApi2SwaggerSettings toolSettings, params String[] controllers)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(controllers);
            toolSettings.ControllersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.Controllers"/>.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveControllers(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> controllers)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(controllers);
            toolSettings.ControllersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AspNetCore
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.AspNetCore"/>.</em></p><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetAspNetCore(this NSwagWebApi2SwaggerSettings toolSettings, bool? aspNetCore)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetCore = aspNetCore;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.AspNetCore"/>.</em></p><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetAspNetCore(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetCore = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApi2SwaggerSettings.AspNetCore"/>.</em></p><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings EnableAspNetCore(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetCore = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApi2SwaggerSettings.AspNetCore"/>.</em></p><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings DisableAspNetCore(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetCore = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApi2SwaggerSettings.AspNetCore"/>.</em></p><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ToggleAspNetCore(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetCore = !toolSettings.AspNetCore;
            return toolSettings;
        }
        #endregion
        #region DefaultUrlTemplate
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.DefaultUrlTemplate"/>.</em></p><p>The Web API default URL template (default for Web API: 'api/{controller}/{id}'; for MVC projects: '{controller}/{action}/{id?}').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetDefaultUrlTemplate(this NSwagWebApi2SwaggerSettings toolSettings, string defaultUrlTemplate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultUrlTemplate = defaultUrlTemplate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.DefaultUrlTemplate"/>.</em></p><p>The Web API default URL template (default for Web API: 'api/{controller}/{id}'; for MVC projects: '{controller}/{action}/{id?}').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetDefaultUrlTemplate(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultUrlTemplate = null;
            return toolSettings;
        }
        #endregion
        #region DefaultPropertyNameHandling
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetDefaultPropertyNameHandling(this NSwagWebApi2SwaggerSettings toolSettings, PropertyNameHandling defaultPropertyNameHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = defaultPropertyNameHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetDefaultPropertyNameHandling(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultReferenceTypeNullHandling
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetDefaultReferenceTypeNullHandling(this NSwagWebApi2SwaggerSettings toolSettings, ReferenceTypeNullHandling defaultReferenceTypeNullHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = defaultReferenceTypeNullHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetDefaultReferenceTypeNullHandling(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultEnumHandling
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetDefaultEnumHandling(this NSwagWebApi2SwaggerSettings toolSettings, EnumHandling defaultEnumHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = defaultEnumHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetDefaultEnumHandling(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = null;
            return toolSettings;
        }
        #endregion
        #region FlattenInheritanceHierarchy
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetFlattenInheritanceHierarchy(this NSwagWebApi2SwaggerSettings toolSettings, bool? flattenInheritanceHierarchy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = flattenInheritanceHierarchy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetFlattenInheritanceHierarchy(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApi2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings EnableFlattenInheritanceHierarchy(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApi2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings DisableFlattenInheritanceHierarchy(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApi2SwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ToggleFlattenInheritanceHierarchy(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = !toolSettings.FlattenInheritanceHierarchy;
            return toolSettings;
        }
        #endregion
        #region GenerateKnownTypes
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetGenerateKnownTypes(this NSwagWebApi2SwaggerSettings toolSettings, bool? generateKnownTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = generateKnownTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetGenerateKnownTypes(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApi2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings EnableGenerateKnownTypes(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApi2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings DisableGenerateKnownTypes(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApi2SwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ToggleGenerateKnownTypes(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = !toolSettings.GenerateKnownTypes;
            return toolSettings;
        }
        #endregion
        #region GenerateXmlObjects
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetGenerateXmlObjects(this NSwagWebApi2SwaggerSettings toolSettings, bool? generateXmlObjects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = generateXmlObjects;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetGenerateXmlObjects(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApi2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings EnableGenerateXmlObjects(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApi2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings DisableGenerateXmlObjects(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApi2SwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ToggleGenerateXmlObjects(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = !toolSettings.GenerateXmlObjects;
            return toolSettings;
        }
        #endregion
        #region GenerateAbstractProperties
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetGenerateAbstractProperties(this NSwagWebApi2SwaggerSettings toolSettings, bool? generateAbstractProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = generateAbstractProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetGenerateAbstractProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApi2SwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings EnableGenerateAbstractProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApi2SwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings DisableGenerateAbstractProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApi2SwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ToggleGenerateAbstractProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = !toolSettings.GenerateAbstractProperties;
            return toolSettings;
        }
        #endregion
        #region AddMissingPathParameters
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.AddMissingPathParameters"/>.</em></p><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetAddMissingPathParameters(this NSwagWebApi2SwaggerSettings toolSettings, bool? addMissingPathParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddMissingPathParameters = addMissingPathParameters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.AddMissingPathParameters"/>.</em></p><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetAddMissingPathParameters(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddMissingPathParameters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApi2SwaggerSettings.AddMissingPathParameters"/>.</em></p><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings EnableAddMissingPathParameters(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddMissingPathParameters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApi2SwaggerSettings.AddMissingPathParameters"/>.</em></p><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings DisableAddMissingPathParameters(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddMissingPathParameters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApi2SwaggerSettings.AddMissingPathParameters"/>.</em></p><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ToggleAddMissingPathParameters(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddMissingPathParameters = !toolSettings.AddMissingPathParameters;
            return toolSettings;
        }
        #endregion
        #region IgnoreObsoleteProperties
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetIgnoreObsoleteProperties(this NSwagWebApi2SwaggerSettings toolSettings, bool? ignoreObsoleteProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = ignoreObsoleteProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetIgnoreObsoleteProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApi2SwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings EnableIgnoreObsoleteProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApi2SwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings DisableIgnoreObsoleteProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApi2SwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ToggleIgnoreObsoleteProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = !toolSettings.IgnoreObsoleteProperties;
            return toolSettings;
        }
        #endregion
        #region AllowReferencesWithProperties
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetAllowReferencesWithProperties(this NSwagWebApi2SwaggerSettings toolSettings, bool? allowReferencesWithProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = allowReferencesWithProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetAllowReferencesWithProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApi2SwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings EnableAllowReferencesWithProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApi2SwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings DisableAllowReferencesWithProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApi2SwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ToggleAllowReferencesWithProperties(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = !toolSettings.AllowReferencesWithProperties;
            return toolSettings;
        }
        #endregion
        #region ExcludedTypeNames
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetExcludedTypeNames(this NSwagWebApi2SwaggerSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetExcludedTypeNames(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddExcludedTypeNames(this NSwagWebApi2SwaggerSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddExcludedTypeNames(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApi2SwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ClearExcludedTypeNames(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveExcludedTypeNames(this NSwagWebApi2SwaggerSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveExcludedTypeNames(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetServiceHost(this NSwagWebApi2SwaggerSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetServiceHost(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceBasePath
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.ServiceBasePath"/>.</em></p><p>The basePath of the Swagger specification (optional).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetServiceBasePath(this NSwagWebApi2SwaggerSettings toolSettings, string serviceBasePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceBasePath = serviceBasePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.ServiceBasePath"/>.</em></p><p>The basePath of the Swagger specification (optional).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetServiceBasePath(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceBasePath = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetServiceSchemes(this NSwagWebApi2SwaggerSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetServiceSchemes(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddServiceSchemes(this NSwagWebApi2SwaggerSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddServiceSchemes(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApi2SwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ClearServiceSchemes(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveServiceSchemes(this NSwagWebApi2SwaggerSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveServiceSchemes(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region InfoTitle
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.InfoTitle"/>.</em></p><p>Specify the title of the Swagger specification.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetInfoTitle(this NSwagWebApi2SwaggerSettings toolSettings, string infoTitle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoTitle = infoTitle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.InfoTitle"/>.</em></p><p>Specify the title of the Swagger specification.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetInfoTitle(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoTitle = null;
            return toolSettings;
        }
        #endregion
        #region InfoDescription
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.InfoDescription"/>.</em></p><p>Specify the description of the Swagger specification.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetInfoDescription(this NSwagWebApi2SwaggerSettings toolSettings, string infoDescription)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoDescription = infoDescription;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.InfoDescription"/>.</em></p><p>Specify the description of the Swagger specification.</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetInfoDescription(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoDescription = null;
            return toolSettings;
        }
        #endregion
        #region InfoVersion
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.InfoVersion"/>.</em></p><p>Specify the version of the Swagger specification (default: 1.0.0).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetInfoVersion(this NSwagWebApi2SwaggerSettings toolSettings, string infoVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoVersion = infoVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.InfoVersion"/>.</em></p><p>Specify the version of the Swagger specification (default: 1.0.0).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetInfoVersion(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoVersion = null;
            return toolSettings;
        }
        #endregion
        #region DocumentTemplate
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.DocumentTemplate"/>.</em></p><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetDocumentTemplate(this NSwagWebApi2SwaggerSettings toolSettings, string documentTemplate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentTemplate = documentTemplate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.DocumentTemplate"/>.</em></p><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetDocumentTemplate(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentTemplate = null;
            return toolSettings;
        }
        #endregion
        #region DocumentProcessors
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.DocumentProcessors"/> to a new list.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetDocumentProcessors(this NSwagWebApi2SwaggerSettings toolSettings, params String[] documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal = documentProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.DocumentProcessors"/> to a new list.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetDocumentProcessors(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal = documentProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddDocumentProcessors(this NSwagWebApi2SwaggerSettings toolSettings, params String[] documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal.AddRange(documentProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddDocumentProcessors(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal.AddRange(documentProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApi2SwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ClearDocumentProcessors(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveDocumentProcessors(this NSwagWebApi2SwaggerSettings toolSettings, params String[] documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(documentProcessors);
            toolSettings.DocumentProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveDocumentProcessors(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(documentProcessors);
            toolSettings.DocumentProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region OperationProcessors
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.OperationProcessors"/> to a new list.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetOperationProcessors(this NSwagWebApi2SwaggerSettings toolSettings, params String[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal = operationProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.OperationProcessors"/> to a new list.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetOperationProcessors(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal = operationProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddOperationProcessors(this NSwagWebApi2SwaggerSettings toolSettings, params String[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.AddRange(operationProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddOperationProcessors(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.AddRange(operationProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApi2SwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ClearOperationProcessors(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveOperationProcessors(this NSwagWebApi2SwaggerSettings toolSettings, params String[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(operationProcessors);
            toolSettings.OperationProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveOperationProcessors(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(operationProcessors);
            toolSettings.OperationProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TypeNameGenerator
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetTypeNameGenerator(this NSwagWebApi2SwaggerSettings toolSettings, string typeNameGenerator)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = typeNameGenerator;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetTypeNameGenerator(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = null;
            return toolSettings;
        }
        #endregion
        #region SchemaNameGenerator
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.SchemaNameGenerator"/>.</em></p><p>The custom ISchemaNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetSchemaNameGenerator(this NSwagWebApi2SwaggerSettings toolSettings, string schemaNameGenerator)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SchemaNameGenerator = schemaNameGenerator;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.SchemaNameGenerator"/>.</em></p><p>The custom ISchemaNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetSchemaNameGenerator(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SchemaNameGenerator = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetOutput(this NSwagWebApi2SwaggerSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetOutput(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Assembly
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetAssembly(this NSwagWebApi2SwaggerSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetAssembly(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddAssembly(this NSwagWebApi2SwaggerSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddAssembly(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApi2SwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ClearAssembly(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveAssembly(this NSwagWebApi2SwaggerSettings toolSettings, params String[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveAssembly(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AssemblyConfig
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetAssemblyConfig(this NSwagWebApi2SwaggerSettings toolSettings, string assemblyConfig)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = assemblyConfig;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApi2SwaggerSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ResetAssemblyConfig(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = null;
            return toolSettings;
        }
        #endregion
        #region ReferencePaths
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetReferencePaths(this NSwagWebApi2SwaggerSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApi2SwaggerSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings SetReferencePaths(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddReferencePaths(this NSwagWebApi2SwaggerSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApi2SwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings AddReferencePaths(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApi2SwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings ClearReferencePaths(this NSwagWebApi2SwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveReferencePaths(this NSwagWebApi2SwaggerSettings toolSettings, params String[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApi2SwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApi2SwaggerSettings RemoveReferencePaths(this NSwagWebApi2SwaggerSettings toolSettings, IEnumerable<String> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagNewSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagNewSettingsExtensions
    {
    }
    #endregion
    #region NSwagRunSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagRunSettingsExtensions
    {
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagRunSettings.Input"/>.</em></p></summary>
        [Pure]
        public static NSwagRunSettings SetInput(this NSwagRunSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagRunSettings.Input"/>.</em></p></summary>
        [Pure]
        public static NSwagRunSettings ResetInput(this NSwagRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary><p><em>Sets <see cref="NSwagRunSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagRunSettings SetVariables(this NSwagRunSettings toolSettings, string variables)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variables = variables;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagRunSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagRunSettings ResetVariables(this NSwagRunSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variables = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagJsonSchema2CsClientSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagJsonSchema2CsClientSettingsExtensions
    {
        #region Name
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.Name"/>.</em></p><p>The class name of the root schema.</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetName(this NSwagJsonSchema2CsClientSettings toolSettings, string name)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2CsClientSettings.Name"/>.</em></p><p>The class name of the root schema.</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ResetName(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region TargetNamespace
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.TargetNamespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetTargetNamespace(this NSwagJsonSchema2CsClientSettings toolSettings, string targetNamespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetNamespace = targetNamespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2CsClientSettings.TargetNamespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ResetTargetNamespace(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetNamespace = null;
            return toolSettings;
        }
        #endregion
        #region RequiredPropertiesMustBeDefined
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetRequiredPropertiesMustBeDefined(this NSwagJsonSchema2CsClientSettings toolSettings, bool? requiredPropertiesMustBeDefined)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = requiredPropertiesMustBeDefined;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2CsClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ResetRequiredPropertiesMustBeDefined(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagJsonSchema2CsClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings EnableRequiredPropertiesMustBeDefined(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagJsonSchema2CsClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings DisableRequiredPropertiesMustBeDefined(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagJsonSchema2CsClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ToggleRequiredPropertiesMustBeDefined(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = !toolSettings.RequiredPropertiesMustBeDefined;
            return toolSettings;
        }
        #endregion
        #region DateTimeType
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetDateTimeType(this NSwagJsonSchema2CsClientSettings toolSettings, string dateTimeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = dateTimeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2CsClientSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ResetDateTimeType(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = null;
            return toolSettings;
        }
        #endregion
        #region ArrayType
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetArrayType(this NSwagJsonSchema2CsClientSettings toolSettings, string arrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = arrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2CsClientSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ResetArrayType(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = null;
            return toolSettings;
        }
        #endregion
        #region DictionaryType
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetDictionaryType(this NSwagJsonSchema2CsClientSettings toolSettings, string dictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = dictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2CsClientSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ResetDictionaryType(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetInput(this NSwagJsonSchema2CsClientSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2CsClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ResetInput(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetServiceHost(this NSwagJsonSchema2CsClientSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2CsClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ResetServiceHost(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetServiceSchemes(this NSwagJsonSchema2CsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetServiceSchemes(this NSwagJsonSchema2CsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagJsonSchema2CsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings AddServiceSchemes(this NSwagJsonSchema2CsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagJsonSchema2CsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings AddServiceSchemes(this NSwagJsonSchema2CsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagJsonSchema2CsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ClearServiceSchemes(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagJsonSchema2CsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings RemoveServiceSchemes(this NSwagJsonSchema2CsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagJsonSchema2CsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings RemoveServiceSchemes(this NSwagJsonSchema2CsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2CsClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings SetOutput(this NSwagJsonSchema2CsClientSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2CsClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagJsonSchema2CsClientSettings ResetOutput(this NSwagJsonSchema2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagJsonSchema2TsClientSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagJsonSchema2TsClientSettingsExtensions
    {
        #region Name
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2TsClientSettings.Name"/>.</em></p><p>The type name of the root schema.</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings SetName(this NSwagJsonSchema2TsClientSettings toolSettings, string name)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2TsClientSettings.Name"/>.</em></p><p>The type name of the root schema.</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings ResetName(this NSwagJsonSchema2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2TsClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings SetInput(this NSwagJsonSchema2TsClientSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2TsClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings ResetInput(this NSwagJsonSchema2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2TsClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings SetServiceHost(this NSwagJsonSchema2TsClientSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2TsClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings ResetServiceHost(this NSwagJsonSchema2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2TsClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings SetServiceSchemes(this NSwagJsonSchema2TsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2TsClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings SetServiceSchemes(this NSwagJsonSchema2TsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagJsonSchema2TsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings AddServiceSchemes(this NSwagJsonSchema2TsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagJsonSchema2TsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings AddServiceSchemes(this NSwagJsonSchema2TsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagJsonSchema2TsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings ClearServiceSchemes(this NSwagJsonSchema2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagJsonSchema2TsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings RemoveServiceSchemes(this NSwagJsonSchema2TsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagJsonSchema2TsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings RemoveServiceSchemes(this NSwagJsonSchema2TsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagJsonSchema2TsClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings SetOutput(this NSwagJsonSchema2TsClientSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchema2TsClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagJsonSchema2TsClientSettings ResetOutput(this NSwagJsonSchema2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagSwagger2CsClientSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagSwagger2CsClientSettingsExtensions
    {
        #region ClientBaseClass
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ClientBaseClass"/>.</em></p><p>The client base class (empty for no base class).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetClientBaseClass(this NSwagSwagger2CsClientSettings toolSettings, string clientBaseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientBaseClass = clientBaseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ClientBaseClass"/>.</em></p><p>The client base class (empty for no base class).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetClientBaseClass(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientBaseClass = null;
            return toolSettings;
        }
        #endregion
        #region ConfigurationClass
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ConfigurationClass"/>.</em></p><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetConfigurationClass(this NSwagSwagger2CsClientSettings toolSettings, string configurationClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationClass = configurationClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ConfigurationClass"/>.</em></p><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetConfigurationClass(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationClass = null;
            return toolSettings;
        }
        #endregion
        #region GenerateClientClasses
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateClientClasses(this NSwagSwagger2CsClientSettings toolSettings, bool? generateClientClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = generateClientClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateClientClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateClientClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateClientClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateClientClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = !toolSettings.GenerateClientClasses;
            return toolSettings;
        }
        #endregion
        #region GenerateClientInterfaces
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateClientInterfaces(this NSwagSwagger2CsClientSettings toolSettings, bool? generateClientInterfaces)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = generateClientInterfaces;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateClientInterfaces(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateClientInterfaces(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateClientInterfaces(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateClientInterfaces(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = !toolSettings.GenerateClientInterfaces;
            return toolSettings;
        }
        #endregion
        #region GenerateDtoTypes
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateDtoTypes(this NSwagSwagger2CsClientSettings toolSettings, bool? generateDtoTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = generateDtoTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateDtoTypes(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateDtoTypes(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateDtoTypes(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateDtoTypes(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = !toolSettings.GenerateDtoTypes;
            return toolSettings;
        }
        #endregion
        #region InjectHttpClient
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.InjectHttpClient"/>.</em></p><p>Specifies whether an HttpClient instance is injected.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetInjectHttpClient(this NSwagSwagger2CsClientSettings toolSettings, bool? injectHttpClient)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectHttpClient = injectHttpClient;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.InjectHttpClient"/>.</em></p><p>Specifies whether an HttpClient instance is injected.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetInjectHttpClient(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectHttpClient = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.InjectHttpClient"/>.</em></p><p>Specifies whether an HttpClient instance is injected.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableInjectHttpClient(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectHttpClient = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.InjectHttpClient"/>.</em></p><p>Specifies whether an HttpClient instance is injected.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableInjectHttpClient(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectHttpClient = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.InjectHttpClient"/>.</em></p><p>Specifies whether an HttpClient instance is injected.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleInjectHttpClient(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectHttpClient = !toolSettings.InjectHttpClient;
            return toolSettings;
        }
        #endregion
        #region DisposeHttpClient
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.DisposeHttpClient"/>.</em></p><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetDisposeHttpClient(this NSwagSwagger2CsClientSettings toolSettings, bool? disposeHttpClient)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeHttpClient = disposeHttpClient;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.DisposeHttpClient"/>.</em></p><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetDisposeHttpClient(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeHttpClient = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.DisposeHttpClient"/>.</em></p><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableDisposeHttpClient(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeHttpClient = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.DisposeHttpClient"/>.</em></p><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableDisposeHttpClient(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeHttpClient = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.DisposeHttpClient"/>.</em></p><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleDisposeHttpClient(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeHttpClient = !toolSettings.DisposeHttpClient;
            return toolSettings;
        }
        #endregion
        #region ProtectedMethods
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ProtectedMethods"/> to a new list.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetProtectedMethods(this NSwagSwagger2CsClientSettings toolSettings, params String[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal = protectedMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ProtectedMethods"/> to a new list.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetProtectedMethods(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal = protectedMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddProtectedMethods(this NSwagSwagger2CsClientSettings toolSettings, params String[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.AddRange(protectedMethods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddProtectedMethods(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.AddRange(protectedMethods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CsClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ClearProtectedMethods(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveProtectedMethods(this NSwagSwagger2CsClientSettings toolSettings, params String[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(protectedMethods);
            toolSettings.ProtectedMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveProtectedMethods(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(protectedMethods);
            toolSettings.ProtectedMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenerateExceptionClasses
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateExceptionClasses"/>.</em></p><p>Specifies whether to generate exception classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateExceptionClasses(this NSwagSwagger2CsClientSettings toolSettings, bool? generateExceptionClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateExceptionClasses = generateExceptionClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateExceptionClasses"/>.</em></p><p>Specifies whether to generate exception classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateExceptionClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateExceptionClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateExceptionClasses"/>.</em></p><p>Specifies whether to generate exception classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateExceptionClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateExceptionClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateExceptionClasses"/>.</em></p><p>Specifies whether to generate exception classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateExceptionClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateExceptionClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateExceptionClasses"/>.</em></p><p>Specifies whether to generate exception classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateExceptionClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateExceptionClasses = !toolSettings.GenerateExceptionClasses;
            return toolSettings;
        }
        #endregion
        #region ExceptionClass
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ExceptionClass"/>.</em></p><p>The exception class (default 'SwaggerException', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetExceptionClass(this NSwagSwagger2CsClientSettings toolSettings, string exceptionClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExceptionClass = exceptionClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ExceptionClass"/>.</em></p><p>The exception class (default 'SwaggerException', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetExceptionClass(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExceptionClass = null;
            return toolSettings;
        }
        #endregion
        #region WrapDtoExceptions
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetWrapDtoExceptions(this NSwagSwagger2CsClientSettings toolSettings, bool? wrapDtoExceptions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = wrapDtoExceptions;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetWrapDtoExceptions(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableWrapDtoExceptions(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableWrapDtoExceptions(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleWrapDtoExceptions(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = !toolSettings.WrapDtoExceptions;
            return toolSettings;
        }
        #endregion
        #region UseHttpClientCreationMethod
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.UseHttpClientCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetUseHttpClientCreationMethod(this NSwagSwagger2CsClientSettings toolSettings, bool? useHttpClientCreationMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpClientCreationMethod = useHttpClientCreationMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.UseHttpClientCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetUseHttpClientCreationMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpClientCreationMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.UseHttpClientCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableUseHttpClientCreationMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpClientCreationMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.UseHttpClientCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableUseHttpClientCreationMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpClientCreationMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.UseHttpClientCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleUseHttpClientCreationMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpClientCreationMethod = !toolSettings.UseHttpClientCreationMethod;
            return toolSettings;
        }
        #endregion
        #region HttpClientType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.HttpClientType"/>.</em></p><p>Specifies the HttpClient type. By default the 'System.Net.Http.HttpClient' is used.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetHttpClientType(this NSwagSwagger2CsClientSettings toolSettings, string httpClientType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpClientType = httpClientType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.HttpClientType"/>.</em></p><p>Specifies the HttpClient type. By default the 'System.Net.Http.HttpClient' is used.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetHttpClientType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpClientType = null;
            return toolSettings;
        }
        #endregion
        #region UseHttpRequestMessageCreationMethod
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.UseHttpRequestMessageCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetUseHttpRequestMessageCreationMethod(this NSwagSwagger2CsClientSettings toolSettings, bool? useHttpRequestMessageCreationMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpRequestMessageCreationMethod = useHttpRequestMessageCreationMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.UseHttpRequestMessageCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetUseHttpRequestMessageCreationMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpRequestMessageCreationMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.UseHttpRequestMessageCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableUseHttpRequestMessageCreationMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpRequestMessageCreationMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.UseHttpRequestMessageCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableUseHttpRequestMessageCreationMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpRequestMessageCreationMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.UseHttpRequestMessageCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleUseHttpRequestMessageCreationMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpRequestMessageCreationMethod = !toolSettings.UseHttpRequestMessageCreationMethod;
            return toolSettings;
        }
        #endregion
        #region UseBaseUrl
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.UseBaseUrl"/>.</em></p><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetUseBaseUrl(this NSwagSwagger2CsClientSettings toolSettings, bool? useBaseUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseBaseUrl = useBaseUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.UseBaseUrl"/>.</em></p><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetUseBaseUrl(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseBaseUrl = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.UseBaseUrl"/>.</em></p><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableUseBaseUrl(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseBaseUrl = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.UseBaseUrl"/>.</em></p><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableUseBaseUrl(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseBaseUrl = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.UseBaseUrl"/>.</em></p><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleUseBaseUrl(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseBaseUrl = !toolSettings.UseBaseUrl;
            return toolSettings;
        }
        #endregion
        #region GenerateBaseUrlProperty
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateBaseUrlProperty"/>.</em></p><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateBaseUrlProperty(this NSwagSwagger2CsClientSettings toolSettings, bool? generateBaseUrlProperty)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateBaseUrlProperty = generateBaseUrlProperty;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateBaseUrlProperty"/>.</em></p><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateBaseUrlProperty(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateBaseUrlProperty = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateBaseUrlProperty"/>.</em></p><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateBaseUrlProperty(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateBaseUrlProperty = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateBaseUrlProperty"/>.</em></p><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateBaseUrlProperty(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateBaseUrlProperty = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateBaseUrlProperty"/>.</em></p><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateBaseUrlProperty(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateBaseUrlProperty = !toolSettings.GenerateBaseUrlProperty;
            return toolSettings;
        }
        #endregion
        #region GenerateSyncMethods
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateSyncMethods"/>.</em></p><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateSyncMethods(this NSwagSwagger2CsClientSettings toolSettings, bool? generateSyncMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSyncMethods = generateSyncMethods;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateSyncMethods"/>.</em></p><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateSyncMethods(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSyncMethods = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateSyncMethods"/>.</em></p><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateSyncMethods(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSyncMethods = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateSyncMethods"/>.</em></p><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateSyncMethods(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSyncMethods = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateSyncMethods"/>.</em></p><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateSyncMethods(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSyncMethods = !toolSettings.GenerateSyncMethods;
            return toolSettings;
        }
        #endregion
        #region ClientClassAccessModifier
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ClientClassAccessModifier"/>.</em></p><p>The client class access modifier (default: public).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetClientClassAccessModifier(this NSwagSwagger2CsClientSettings toolSettings, string clientClassAccessModifier)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientClassAccessModifier = clientClassAccessModifier;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ClientClassAccessModifier"/>.</em></p><p>The client class access modifier (default: public).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetClientClassAccessModifier(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientClassAccessModifier = null;
            return toolSettings;
        }
        #endregion
        #region TypeAccessModifier
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.TypeAccessModifier"/>.</em></p><p>The DTO class/enum access modifier (default: public).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetTypeAccessModifier(this NSwagSwagger2CsClientSettings toolSettings, string typeAccessModifier)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeAccessModifier = typeAccessModifier;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.TypeAccessModifier"/>.</em></p><p>The DTO class/enum access modifier (default: public).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetTypeAccessModifier(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeAccessModifier = null;
            return toolSettings;
        }
        #endregion
        #region GenerateContractsOutput
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateContractsOutput"/>.</em></p><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateContractsOutput(this NSwagSwagger2CsClientSettings toolSettings, bool? generateContractsOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateContractsOutput = generateContractsOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateContractsOutput"/>.</em></p><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateContractsOutput(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateContractsOutput = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateContractsOutput"/>.</em></p><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateContractsOutput(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateContractsOutput = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateContractsOutput"/>.</em></p><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateContractsOutput(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateContractsOutput = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateContractsOutput"/>.</em></p><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateContractsOutput(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateContractsOutput = !toolSettings.GenerateContractsOutput;
            return toolSettings;
        }
        #endregion
        #region ContractsTargetNamespace
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ContractsTargetNamespace"/>.</em></p><p>The contracts .NET namespace.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetContractsTargetNamespace(this NSwagSwagger2CsClientSettings toolSettings, string contractsTargetNamespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractsTargetNamespace = contractsTargetNamespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ContractsTargetNamespace"/>.</em></p><p>The contracts .NET namespace.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetContractsTargetNamespace(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractsTargetNamespace = null;
            return toolSettings;
        }
        #endregion
        #region ContractsOutput
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ContractsOutput"/>.</em></p><p>The contracts output file path (optional, if no path is set then a single file with the implementation and contracts is generated).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetContractsOutput(this NSwagSwagger2CsClientSettings toolSettings, string contractsOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractsOutput = contractsOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ContractsOutput"/>.</em></p><p>The contracts output file path (optional, if no path is set then a single file with the implementation and contracts is generated).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetContractsOutput(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractsOutput = null;
            return toolSettings;
        }
        #endregion
        #region ParameterDateTimeFormat
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ParameterDateTimeFormat"/>.</em></p><p>Specifies the format for DateTime type method parameters (default: s).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetParameterDateTimeFormat(this NSwagSwagger2CsClientSettings toolSettings, string parameterDateTimeFormat)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDateTimeFormat = parameterDateTimeFormat;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ParameterDateTimeFormat"/>.</em></p><p>Specifies the format for DateTime type method parameters (default: s).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetParameterDateTimeFormat(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDateTimeFormat = null;
            return toolSettings;
        }
        #endregion
        #region GenerateUpdateJsonSerializerSettingsMethod
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateUpdateJsonSerializerSettingsMethod"/>.</em></p><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateUpdateJsonSerializerSettingsMethod(this NSwagSwagger2CsClientSettings toolSettings, bool? generateUpdateJsonSerializerSettingsMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateUpdateJsonSerializerSettingsMethod = generateUpdateJsonSerializerSettingsMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateUpdateJsonSerializerSettingsMethod"/>.</em></p><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateUpdateJsonSerializerSettingsMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateUpdateJsonSerializerSettingsMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateUpdateJsonSerializerSettingsMethod"/>.</em></p><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateUpdateJsonSerializerSettingsMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateUpdateJsonSerializerSettingsMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateUpdateJsonSerializerSettingsMethod"/>.</em></p><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateUpdateJsonSerializerSettingsMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateUpdateJsonSerializerSettingsMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateUpdateJsonSerializerSettingsMethod"/>.</em></p><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateUpdateJsonSerializerSettingsMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateUpdateJsonSerializerSettingsMethod = !toolSettings.GenerateUpdateJsonSerializerSettingsMethod;
            return toolSettings;
        }
        #endregion
        #region SerializeTypeInformation
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.SerializeTypeInformation"/>.</em></p><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetSerializeTypeInformation(this NSwagSwagger2CsClientSettings toolSettings, bool? serializeTypeInformation)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SerializeTypeInformation = serializeTypeInformation;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.SerializeTypeInformation"/>.</em></p><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetSerializeTypeInformation(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SerializeTypeInformation = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.SerializeTypeInformation"/>.</em></p><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableSerializeTypeInformation(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SerializeTypeInformation = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.SerializeTypeInformation"/>.</em></p><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableSerializeTypeInformation(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SerializeTypeInformation = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.SerializeTypeInformation"/>.</em></p><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleSerializeTypeInformation(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SerializeTypeInformation = !toolSettings.SerializeTypeInformation;
            return toolSettings;
        }
        #endregion
        #region QueryNullValue
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.QueryNullValue"/>.</em></p><p>The null value used for query parameters which are null (default: '').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetQueryNullValue(this NSwagSwagger2CsClientSettings toolSettings, string queryNullValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QueryNullValue = queryNullValue;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.QueryNullValue"/>.</em></p><p>The null value used for query parameters which are null (default: '').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetQueryNullValue(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QueryNullValue = null;
            return toolSettings;
        }
        #endregion
        #region ClassName
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetClassName(this NSwagSwagger2CsClientSettings toolSettings, string className)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = className;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetClassName(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = null;
            return toolSettings;
        }
        #endregion
        #region OperationGenerationMode
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetOperationGenerationMode(this NSwagSwagger2CsClientSettings toolSettings, OperationGenerationMode operationGenerationMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = operationGenerationMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetOperationGenerationMode(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = null;
            return toolSettings;
        }
        #endregion
        #region AdditionalTargetNamespaceUsages
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.AdditionalTargetNamespaceUsages"/> to a new list.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetAdditionalTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, params String[] additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalTargetNamespaceUsagesInternal = additionalTargetNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.AdditionalTargetNamespaceUsages"/> to a new list.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetAdditionalTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalTargetNamespaceUsagesInternal = additionalTargetNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.AdditionalTargetNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddAdditionalTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, params String[] additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalTargetNamespaceUsagesInternal.AddRange(additionalTargetNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.AdditionalTargetNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddAdditionalTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalTargetNamespaceUsagesInternal.AddRange(additionalTargetNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CsClientSettings.AdditionalTargetNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ClearAdditionalTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalTargetNamespaceUsagesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.AdditionalTargetNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveAdditionalTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, params String[] additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(additionalTargetNamespaceUsages);
            toolSettings.AdditionalTargetNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.AdditionalTargetNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveAdditionalTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(additionalTargetNamespaceUsages);
            toolSettings.AdditionalTargetNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AdditionalContractTargetNamespaceUsages
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.AdditionalContractTargetNamespaceUsages"/> to a new list.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, params String[] additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal = additionalContractTargetNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.AdditionalContractTargetNamespaceUsages"/> to a new list.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal = additionalContractTargetNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.AdditionalContractTargetNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, params String[] additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal.AddRange(additionalContractTargetNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.AdditionalContractTargetNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal.AddRange(additionalContractTargetNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CsClientSettings.AdditionalContractTargetNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ClearAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.AdditionalContractTargetNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, params String[] additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(additionalContractTargetNamespaceUsages);
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.AdditionalContractTargetNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(additionalContractTargetNamespaceUsages);
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenerateOptionalParameters
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateOptionalParameters(this NSwagSwagger2CsClientSettings toolSettings, bool? generateOptionalParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = generateOptionalParameters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateOptionalParameters(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateOptionalParameters(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateOptionalParameters(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateOptionalParameters(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = !toolSettings.GenerateOptionalParameters;
            return toolSettings;
        }
        #endregion
        #region ParameterArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ParameterArrayType"/>.</em></p><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetParameterArrayType(this NSwagSwagger2CsClientSettings toolSettings, string parameterArrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterArrayType = parameterArrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ParameterArrayType"/>.</em></p><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetParameterArrayType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterArrayType = null;
            return toolSettings;
        }
        #endregion
        #region ParameterDictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ParameterDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetParameterDictionaryType(this NSwagSwagger2CsClientSettings toolSettings, string parameterDictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDictionaryType = parameterDictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ParameterDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetParameterDictionaryType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region ResponseArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ResponseArrayType"/>.</em></p><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetResponseArrayType(this NSwagSwagger2CsClientSettings toolSettings, string responseArrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseArrayType = responseArrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ResponseArrayType"/>.</em></p><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetResponseArrayType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseArrayType = null;
            return toolSettings;
        }
        #endregion
        #region ResponseDictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ResponseDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetResponseDictionaryType(this NSwagSwagger2CsClientSettings toolSettings, string responseDictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseDictionaryType = responseDictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ResponseDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetResponseDictionaryType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseDictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region WrapResponses
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetWrapResponses(this NSwagSwagger2CsClientSettings toolSettings, bool? wrapResponses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = wrapResponses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetWrapResponses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableWrapResponses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableWrapResponses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleWrapResponses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = !toolSettings.WrapResponses;
            return toolSettings;
        }
        #endregion
        #region WrapResponseMethods
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetWrapResponseMethods(this NSwagSwagger2CsClientSettings toolSettings, params String[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetWrapResponseMethods(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddWrapResponseMethods(this NSwagSwagger2CsClientSettings toolSettings, params String[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddWrapResponseMethods(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CsClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ClearWrapResponseMethods(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveWrapResponseMethods(this NSwagSwagger2CsClientSettings toolSettings, params String[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveWrapResponseMethods(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenerateResponseClasses
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateResponseClasses(this NSwagSwagger2CsClientSettings toolSettings, bool? generateResponseClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = generateResponseClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateResponseClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateResponseClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateResponseClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateResponseClasses(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = !toolSettings.GenerateResponseClasses;
            return toolSettings;
        }
        #endregion
        #region ResponseClass
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetResponseClass(this NSwagSwagger2CsClientSettings toolSettings, string responseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = responseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetResponseClass(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = null;
            return toolSettings;
        }
        #endregion
        #region TargetNamespace
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.TargetNamespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetTargetNamespace(this NSwagSwagger2CsClientSettings toolSettings, string targetNamespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetNamespace = targetNamespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.TargetNamespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetTargetNamespace(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetNamespace = null;
            return toolSettings;
        }
        #endregion
        #region RequiredPropertiesMustBeDefined
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetRequiredPropertiesMustBeDefined(this NSwagSwagger2CsClientSettings toolSettings, bool? requiredPropertiesMustBeDefined)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = requiredPropertiesMustBeDefined;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetRequiredPropertiesMustBeDefined(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableRequiredPropertiesMustBeDefined(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableRequiredPropertiesMustBeDefined(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleRequiredPropertiesMustBeDefined(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = !toolSettings.RequiredPropertiesMustBeDefined;
            return toolSettings;
        }
        #endregion
        #region DateType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.DateType"/>.</em></p><p>The date .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetDateType(this NSwagSwagger2CsClientSettings toolSettings, string dateType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateType = dateType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.DateType"/>.</em></p><p>The date .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetDateType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateType = null;
            return toolSettings;
        }
        #endregion
        #region JsonConverters
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.JsonConverters"/> to a new list.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetJsonConverters(this NSwagSwagger2CsClientSettings toolSettings, params String[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal = jsonConverters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.JsonConverters"/> to a new list.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetJsonConverters(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal = jsonConverters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddJsonConverters(this NSwagSwagger2CsClientSettings toolSettings, params String[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.AddRange(jsonConverters);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddJsonConverters(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.AddRange(jsonConverters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CsClientSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ClearJsonConverters(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveJsonConverters(this NSwagSwagger2CsClientSettings toolSettings, params String[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(jsonConverters);
            toolSettings.JsonConvertersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveJsonConverters(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(jsonConverters);
            toolSettings.JsonConvertersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DateTimeType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetDateTimeType(this NSwagSwagger2CsClientSettings toolSettings, string dateTimeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = dateTimeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetDateTimeType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = null;
            return toolSettings;
        }
        #endregion
        #region TimeType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.TimeType"/>.</em></p><p>The time .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetTimeType(this NSwagSwagger2CsClientSettings toolSettings, string timeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeType = timeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.TimeType"/>.</em></p><p>The time .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetTimeType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeType = null;
            return toolSettings;
        }
        #endregion
        #region TimeSpanType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.TimeSpanType"/>.</em></p><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetTimeSpanType(this NSwagSwagger2CsClientSettings toolSettings, string timeSpanType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeSpanType = timeSpanType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.TimeSpanType"/>.</em></p><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetTimeSpanType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeSpanType = null;
            return toolSettings;
        }
        #endregion
        #region ArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetArrayType(this NSwagSwagger2CsClientSettings toolSettings, string arrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = arrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetArrayType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = null;
            return toolSettings;
        }
        #endregion
        #region DictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetDictionaryType(this NSwagSwagger2CsClientSettings toolSettings, string dictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = dictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetDictionaryType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region ArrayBaseType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ArrayBaseType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetArrayBaseType(this NSwagSwagger2CsClientSettings toolSettings, string arrayBaseType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayBaseType = arrayBaseType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ArrayBaseType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetArrayBaseType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayBaseType = null;
            return toolSettings;
        }
        #endregion
        #region DictionaryBaseType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.DictionaryBaseType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetDictionaryBaseType(this NSwagSwagger2CsClientSettings toolSettings, string dictionaryBaseType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryBaseType = dictionaryBaseType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.DictionaryBaseType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetDictionaryBaseType(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryBaseType = null;
            return toolSettings;
        }
        #endregion
        #region ClassStyle
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ClassStyle"/>.</em></p><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetClassStyle(this NSwagSwagger2CsClientSettings toolSettings, CSharpClassStyle classStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassStyle = classStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ClassStyle"/>.</em></p><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetClassStyle(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassStyle = null;
            return toolSettings;
        }
        #endregion
        #region GenerateDefaultValues
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateDefaultValues(this NSwagSwagger2CsClientSettings toolSettings, bool? generateDefaultValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = generateDefaultValues;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateDefaultValues(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateDefaultValues(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateDefaultValues(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateDefaultValues(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = !toolSettings.GenerateDefaultValues;
            return toolSettings;
        }
        #endregion
        #region GenerateDataAnnotations
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateDataAnnotations(this NSwagSwagger2CsClientSettings toolSettings, bool? generateDataAnnotations)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = generateDataAnnotations;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateDataAnnotations(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateDataAnnotations(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateDataAnnotations(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateDataAnnotations(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = !toolSettings.GenerateDataAnnotations;
            return toolSettings;
        }
        #endregion
        #region ExcludedTypeNames
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetExcludedTypeNames(this NSwagSwagger2CsClientSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetExcludedTypeNames(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddExcludedTypeNames(this NSwagSwagger2CsClientSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddExcludedTypeNames(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CsClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ClearExcludedTypeNames(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveExcludedTypeNames(this NSwagSwagger2CsClientSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveExcludedTypeNames(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region HandleReferences
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetHandleReferences(this NSwagSwagger2CsClientSettings toolSettings, bool? handleReferences)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = handleReferences;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetHandleReferences(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableHandleReferences(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableHandleReferences(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleHandleReferences(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = !toolSettings.HandleReferences;
            return toolSettings;
        }
        #endregion
        #region GenerateImmutableArrayProperties
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateImmutableArrayProperties(this NSwagSwagger2CsClientSettings toolSettings, bool? generateImmutableArrayProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = generateImmutableArrayProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateImmutableArrayProperties(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateImmutableArrayProperties(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateImmutableArrayProperties(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateImmutableArrayProperties(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = !toolSettings.GenerateImmutableArrayProperties;
            return toolSettings;
        }
        #endregion
        #region GenerateImmutableDictionaryProperties
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetGenerateImmutableDictionaryProperties(this NSwagSwagger2CsClientSettings toolSettings, bool? generateImmutableDictionaryProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = generateImmutableDictionaryProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetGenerateImmutableDictionaryProperties(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CsClientSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings EnableGenerateImmutableDictionaryProperties(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CsClientSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings DisableGenerateImmutableDictionaryProperties(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CsClientSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ToggleGenerateImmutableDictionaryProperties(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = !toolSettings.GenerateImmutableDictionaryProperties;
            return toolSettings;
        }
        #endregion
        #region JsonSerializerSettingsTransformationMethod
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.JsonSerializerSettingsTransformationMethod"/>.</em></p><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetJsonSerializerSettingsTransformationMethod(this NSwagSwagger2CsClientSettings toolSettings, string jsonSerializerSettingsTransformationMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonSerializerSettingsTransformationMethod = jsonSerializerSettingsTransformationMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.JsonSerializerSettingsTransformationMethod"/>.</em></p><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetJsonSerializerSettingsTransformationMethod(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonSerializerSettingsTransformationMethod = null;
            return toolSettings;
        }
        #endregion
        #region TemplateDirectory
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetTemplateDirectory(this NSwagSwagger2CsClientSettings toolSettings, string templateDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = templateDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetTemplateDirectory(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetInput(this NSwagSwagger2CsClientSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetInput(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetServiceHost(this NSwagSwagger2CsClientSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetServiceHost(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetServiceSchemes(this NSwagSwagger2CsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetServiceSchemes(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddServiceSchemes(this NSwagSwagger2CsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings AddServiceSchemes(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ClearServiceSchemes(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveServiceSchemes(this NSwagSwagger2CsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings RemoveServiceSchemes(this NSwagSwagger2CsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CsClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings SetOutput(this NSwagSwagger2CsClientSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CsClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwagger2CsClientSettings ResetOutput(this NSwagSwagger2CsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagSwagger2CscontrollerSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagSwagger2CscontrollerSettingsExtensions
    {
        #region ControllerBaseClass
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ControllerBaseClass"/>.</em></p><p>The controller base class (empty for 'ApiController').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetControllerBaseClass(this NSwagSwagger2CscontrollerSettings toolSettings, string controllerBaseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllerBaseClass = controllerBaseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ControllerBaseClass"/>.</em></p><p>The controller base class (empty for 'ApiController').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetControllerBaseClass(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllerBaseClass = null;
            return toolSettings;
        }
        #endregion
        #region ControllerStyle
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ControllerStyle"/>.</em></p><p>The controller generation style (partial, abstract; default: partial).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetControllerStyle(this NSwagSwagger2CscontrollerSettings toolSettings, CSharpControllerStyle controllerStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllerStyle = controllerStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ControllerStyle"/>.</em></p><p>The controller generation style (partial, abstract; default: partial).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetControllerStyle(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllerStyle = null;
            return toolSettings;
        }
        #endregion
        #region UseCancellationToken
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.UseCancellationToken"/>.</em></p><p>Add a cancellation token parameter (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetUseCancellationToken(this NSwagSwagger2CscontrollerSettings toolSettings, bool? useCancellationToken)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseCancellationToken = useCancellationToken;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.UseCancellationToken"/>.</em></p><p>Add a cancellation token parameter (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetUseCancellationToken(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseCancellationToken = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CscontrollerSettings.UseCancellationToken"/>.</em></p><p>Add a cancellation token parameter (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings EnableUseCancellationToken(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseCancellationToken = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CscontrollerSettings.UseCancellationToken"/>.</em></p><p>Add a cancellation token parameter (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings DisableUseCancellationToken(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseCancellationToken = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CscontrollerSettings.UseCancellationToken"/>.</em></p><p>Add a cancellation token parameter (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ToggleUseCancellationToken(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseCancellationToken = !toolSettings.UseCancellationToken;
            return toolSettings;
        }
        #endregion
        #region AspNetTargetNamespace
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.AspNetTargetNamespace"/>.</em></p><p>The ASP.NET (Core) framework namespace (default: 'System.Web.Http').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetAspNetTargetNamespace(this NSwagSwagger2CscontrollerSettings toolSettings, string aspNetTargetNamespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetTargetNamespace = aspNetTargetNamespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.AspNetTargetNamespace"/>.</em></p><p>The ASP.NET (Core) framework namespace (default: 'System.Web.Http').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetAspNetTargetNamespace(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetTargetNamespace = null;
            return toolSettings;
        }
        #endregion
        #region ClassName
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetClassName(this NSwagSwagger2CscontrollerSettings toolSettings, string className)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = className;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetClassName(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = null;
            return toolSettings;
        }
        #endregion
        #region OperationGenerationMode
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetOperationGenerationMode(this NSwagSwagger2CscontrollerSettings toolSettings, OperationGenerationMode operationGenerationMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = operationGenerationMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetOperationGenerationMode(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = null;
            return toolSettings;
        }
        #endregion
        #region AdditionalTargetNamespaceUsages
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.AdditionalTargetNamespaceUsages"/> to a new list.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetAdditionalTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalTargetNamespaceUsagesInternal = additionalTargetNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.AdditionalTargetNamespaceUsages"/> to a new list.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetAdditionalTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalTargetNamespaceUsagesInternal = additionalTargetNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.AdditionalTargetNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddAdditionalTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalTargetNamespaceUsagesInternal.AddRange(additionalTargetNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.AdditionalTargetNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddAdditionalTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalTargetNamespaceUsagesInternal.AddRange(additionalTargetNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CscontrollerSettings.AdditionalTargetNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ClearAdditionalTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalTargetNamespaceUsagesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.AdditionalTargetNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveAdditionalTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(additionalTargetNamespaceUsages);
            toolSettings.AdditionalTargetNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.AdditionalTargetNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveAdditionalTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> additionalTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(additionalTargetNamespaceUsages);
            toolSettings.AdditionalTargetNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AdditionalContractTargetNamespaceUsages
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.AdditionalContractTargetNamespaceUsages"/> to a new list.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal = additionalContractTargetNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.AdditionalContractTargetNamespaceUsages"/> to a new list.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal = additionalContractTargetNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.AdditionalContractTargetNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal.AddRange(additionalContractTargetNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.AdditionalContractTargetNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal.AddRange(additionalContractTargetNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CscontrollerSettings.AdditionalContractTargetNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ClearAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.AdditionalContractTargetNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(additionalContractTargetNamespaceUsages);
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.AdditionalContractTargetNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveAdditionalContractTargetNamespaceUsages(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> additionalContractTargetNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(additionalContractTargetNamespaceUsages);
            toolSettings.AdditionalContractTargetNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenerateOptionalParameters
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetGenerateOptionalParameters(this NSwagSwagger2CscontrollerSettings toolSettings, bool? generateOptionalParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = generateOptionalParameters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetGenerateOptionalParameters(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CscontrollerSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings EnableGenerateOptionalParameters(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CscontrollerSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings DisableGenerateOptionalParameters(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CscontrollerSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ToggleGenerateOptionalParameters(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = !toolSettings.GenerateOptionalParameters;
            return toolSettings;
        }
        #endregion
        #region ParameterArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ParameterArrayType"/>.</em></p><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetParameterArrayType(this NSwagSwagger2CscontrollerSettings toolSettings, string parameterArrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterArrayType = parameterArrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ParameterArrayType"/>.</em></p><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetParameterArrayType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterArrayType = null;
            return toolSettings;
        }
        #endregion
        #region ParameterDictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ParameterDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetParameterDictionaryType(this NSwagSwagger2CscontrollerSettings toolSettings, string parameterDictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDictionaryType = parameterDictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ParameterDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetParameterDictionaryType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region ResponseArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ResponseArrayType"/>.</em></p><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetResponseArrayType(this NSwagSwagger2CscontrollerSettings toolSettings, string responseArrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseArrayType = responseArrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ResponseArrayType"/>.</em></p><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetResponseArrayType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseArrayType = null;
            return toolSettings;
        }
        #endregion
        #region ResponseDictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ResponseDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetResponseDictionaryType(this NSwagSwagger2CscontrollerSettings toolSettings, string responseDictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseDictionaryType = responseDictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ResponseDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetResponseDictionaryType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseDictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region WrapResponses
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetWrapResponses(this NSwagSwagger2CscontrollerSettings toolSettings, bool? wrapResponses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = wrapResponses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetWrapResponses(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CscontrollerSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings EnableWrapResponses(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CscontrollerSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings DisableWrapResponses(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CscontrollerSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ToggleWrapResponses(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = !toolSettings.WrapResponses;
            return toolSettings;
        }
        #endregion
        #region WrapResponseMethods
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetWrapResponseMethods(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetWrapResponseMethods(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddWrapResponseMethods(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddWrapResponseMethods(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CscontrollerSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ClearWrapResponseMethods(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveWrapResponseMethods(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveWrapResponseMethods(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenerateResponseClasses
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetGenerateResponseClasses(this NSwagSwagger2CscontrollerSettings toolSettings, bool? generateResponseClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = generateResponseClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetGenerateResponseClasses(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CscontrollerSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings EnableGenerateResponseClasses(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CscontrollerSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings DisableGenerateResponseClasses(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CscontrollerSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ToggleGenerateResponseClasses(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = !toolSettings.GenerateResponseClasses;
            return toolSettings;
        }
        #endregion
        #region ResponseClass
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetResponseClass(this NSwagSwagger2CscontrollerSettings toolSettings, string responseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = responseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetResponseClass(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = null;
            return toolSettings;
        }
        #endregion
        #region TargetNamespace
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.TargetNamespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetTargetNamespace(this NSwagSwagger2CscontrollerSettings toolSettings, string targetNamespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetNamespace = targetNamespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.TargetNamespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetTargetNamespace(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetNamespace = null;
            return toolSettings;
        }
        #endregion
        #region RequiredPropertiesMustBeDefined
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetRequiredPropertiesMustBeDefined(this NSwagSwagger2CscontrollerSettings toolSettings, bool? requiredPropertiesMustBeDefined)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = requiredPropertiesMustBeDefined;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetRequiredPropertiesMustBeDefined(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CscontrollerSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings EnableRequiredPropertiesMustBeDefined(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CscontrollerSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings DisableRequiredPropertiesMustBeDefined(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CscontrollerSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ToggleRequiredPropertiesMustBeDefined(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = !toolSettings.RequiredPropertiesMustBeDefined;
            return toolSettings;
        }
        #endregion
        #region DateType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.DateType"/>.</em></p><p>The date .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetDateType(this NSwagSwagger2CscontrollerSettings toolSettings, string dateType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateType = dateType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.DateType"/>.</em></p><p>The date .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetDateType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateType = null;
            return toolSettings;
        }
        #endregion
        #region JsonConverters
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.JsonConverters"/> to a new list.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetJsonConverters(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal = jsonConverters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.JsonConverters"/> to a new list.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetJsonConverters(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal = jsonConverters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddJsonConverters(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.AddRange(jsonConverters);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddJsonConverters(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.AddRange(jsonConverters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CscontrollerSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ClearJsonConverters(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveJsonConverters(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(jsonConverters);
            toolSettings.JsonConvertersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveJsonConverters(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(jsonConverters);
            toolSettings.JsonConvertersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DateTimeType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetDateTimeType(this NSwagSwagger2CscontrollerSettings toolSettings, string dateTimeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = dateTimeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetDateTimeType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = null;
            return toolSettings;
        }
        #endregion
        #region TimeType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.TimeType"/>.</em></p><p>The time .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetTimeType(this NSwagSwagger2CscontrollerSettings toolSettings, string timeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeType = timeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.TimeType"/>.</em></p><p>The time .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetTimeType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeType = null;
            return toolSettings;
        }
        #endregion
        #region TimeSpanType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.TimeSpanType"/>.</em></p><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetTimeSpanType(this NSwagSwagger2CscontrollerSettings toolSettings, string timeSpanType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeSpanType = timeSpanType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.TimeSpanType"/>.</em></p><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetTimeSpanType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeSpanType = null;
            return toolSettings;
        }
        #endregion
        #region ArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetArrayType(this NSwagSwagger2CscontrollerSettings toolSettings, string arrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = arrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetArrayType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = null;
            return toolSettings;
        }
        #endregion
        #region DictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetDictionaryType(this NSwagSwagger2CscontrollerSettings toolSettings, string dictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = dictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetDictionaryType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region ArrayBaseType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ArrayBaseType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetArrayBaseType(this NSwagSwagger2CscontrollerSettings toolSettings, string arrayBaseType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayBaseType = arrayBaseType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ArrayBaseType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetArrayBaseType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayBaseType = null;
            return toolSettings;
        }
        #endregion
        #region DictionaryBaseType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.DictionaryBaseType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetDictionaryBaseType(this NSwagSwagger2CscontrollerSettings toolSettings, string dictionaryBaseType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryBaseType = dictionaryBaseType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.DictionaryBaseType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetDictionaryBaseType(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryBaseType = null;
            return toolSettings;
        }
        #endregion
        #region ClassStyle
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ClassStyle"/>.</em></p><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetClassStyle(this NSwagSwagger2CscontrollerSettings toolSettings, CSharpClassStyle classStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassStyle = classStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ClassStyle"/>.</em></p><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetClassStyle(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassStyle = null;
            return toolSettings;
        }
        #endregion
        #region GenerateDefaultValues
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetGenerateDefaultValues(this NSwagSwagger2CscontrollerSettings toolSettings, bool? generateDefaultValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = generateDefaultValues;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetGenerateDefaultValues(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CscontrollerSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings EnableGenerateDefaultValues(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CscontrollerSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings DisableGenerateDefaultValues(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CscontrollerSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ToggleGenerateDefaultValues(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = !toolSettings.GenerateDefaultValues;
            return toolSettings;
        }
        #endregion
        #region GenerateDataAnnotations
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetGenerateDataAnnotations(this NSwagSwagger2CscontrollerSettings toolSettings, bool? generateDataAnnotations)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = generateDataAnnotations;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetGenerateDataAnnotations(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CscontrollerSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings EnableGenerateDataAnnotations(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CscontrollerSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings DisableGenerateDataAnnotations(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CscontrollerSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ToggleGenerateDataAnnotations(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = !toolSettings.GenerateDataAnnotations;
            return toolSettings;
        }
        #endregion
        #region ExcludedTypeNames
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetExcludedTypeNames(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetExcludedTypeNames(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddExcludedTypeNames(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddExcludedTypeNames(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CscontrollerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ClearExcludedTypeNames(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveExcludedTypeNames(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveExcludedTypeNames(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region HandleReferences
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetHandleReferences(this NSwagSwagger2CscontrollerSettings toolSettings, bool? handleReferences)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = handleReferences;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetHandleReferences(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CscontrollerSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings EnableHandleReferences(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CscontrollerSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings DisableHandleReferences(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CscontrollerSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ToggleHandleReferences(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = !toolSettings.HandleReferences;
            return toolSettings;
        }
        #endregion
        #region GenerateImmutableArrayProperties
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetGenerateImmutableArrayProperties(this NSwagSwagger2CscontrollerSettings toolSettings, bool? generateImmutableArrayProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = generateImmutableArrayProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetGenerateImmutableArrayProperties(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CscontrollerSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings EnableGenerateImmutableArrayProperties(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CscontrollerSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings DisableGenerateImmutableArrayProperties(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CscontrollerSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ToggleGenerateImmutableArrayProperties(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = !toolSettings.GenerateImmutableArrayProperties;
            return toolSettings;
        }
        #endregion
        #region GenerateImmutableDictionaryProperties
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetGenerateImmutableDictionaryProperties(this NSwagSwagger2CscontrollerSettings toolSettings, bool? generateImmutableDictionaryProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = generateImmutableDictionaryProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetGenerateImmutableDictionaryProperties(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2CscontrollerSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings EnableGenerateImmutableDictionaryProperties(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2CscontrollerSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings DisableGenerateImmutableDictionaryProperties(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2CscontrollerSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ToggleGenerateImmutableDictionaryProperties(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = !toolSettings.GenerateImmutableDictionaryProperties;
            return toolSettings;
        }
        #endregion
        #region JsonSerializerSettingsTransformationMethod
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.JsonSerializerSettingsTransformationMethod"/>.</em></p><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetJsonSerializerSettingsTransformationMethod(this NSwagSwagger2CscontrollerSettings toolSettings, string jsonSerializerSettingsTransformationMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonSerializerSettingsTransformationMethod = jsonSerializerSettingsTransformationMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.JsonSerializerSettingsTransformationMethod"/>.</em></p><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetJsonSerializerSettingsTransformationMethod(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonSerializerSettingsTransformationMethod = null;
            return toolSettings;
        }
        #endregion
        #region TemplateDirectory
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetTemplateDirectory(this NSwagSwagger2CscontrollerSettings toolSettings, string templateDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = templateDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetTemplateDirectory(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetInput(this NSwagSwagger2CscontrollerSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetInput(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetServiceHost(this NSwagSwagger2CscontrollerSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetServiceHost(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetServiceSchemes(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetServiceSchemes(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddServiceSchemes(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2CscontrollerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings AddServiceSchemes(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2CscontrollerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ClearServiceSchemes(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveServiceSchemes(this NSwagSwagger2CscontrollerSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2CscontrollerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings RemoveServiceSchemes(this NSwagSwagger2CscontrollerSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagSwagger2CscontrollerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings SetOutput(this NSwagSwagger2CscontrollerSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2CscontrollerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwagger2CscontrollerSettings ResetOutput(this NSwagSwagger2CscontrollerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagSwagger2TsClientSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagSwagger2TsClientSettingsExtensions
    {
        #region ClassName
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetClassName(this NSwagSwagger2TsClientSettings toolSettings, string className)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = className;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetClassName(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = null;
            return toolSettings;
        }
        #endregion
        #region ModuleName
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ModuleName"/>.</em></p><p>The TypeScript module name (default: '', no module).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetModuleName(this NSwagSwagger2TsClientSettings toolSettings, string moduleName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ModuleName = moduleName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.ModuleName"/>.</em></p><p>The TypeScript module name (default: '', no module).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetModuleName(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ModuleName = null;
            return toolSettings;
        }
        #endregion
        #region TargetNamespace
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.TargetNamespace"/>.</em></p><p>The TypeScript namespace (default: '', no namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetTargetNamespace(this NSwagSwagger2TsClientSettings toolSettings, string targetNamespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetNamespace = targetNamespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.TargetNamespace"/>.</em></p><p>The TypeScript namespace (default: '', no namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetTargetNamespace(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetNamespace = null;
            return toolSettings;
        }
        #endregion
        #region TypeScriptVersion
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.TypeScriptVersion"/>.</em></p><p>The target TypeScript version (default: 1.8).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetTypeScriptVersion(this NSwagSwagger2TsClientSettings toolSettings, string typeScriptVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeScriptVersion = typeScriptVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.TypeScriptVersion"/>.</em></p><p>The target TypeScript version (default: 1.8).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetTypeScriptVersion(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeScriptVersion = null;
            return toolSettings;
        }
        #endregion
        #region Template
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.Template"/>.</em></p><p>The type of the asynchronism handling ('JQueryCallbacks', 'JQueryPromises', 'AngularJS', 'Angular', 'Fetch', 'Aurelia').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetTemplate(this NSwagSwagger2TsClientSettings toolSettings, TypeScriptTemplate template)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Template = template;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.Template"/>.</em></p><p>The type of the asynchronism handling ('JQueryCallbacks', 'JQueryPromises', 'AngularJS', 'Angular', 'Fetch', 'Aurelia').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetTemplate(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Template = null;
            return toolSettings;
        }
        #endregion
        #region PromiseType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.PromiseType"/>.</em></p><p>The promise type ('Promise' or 'QPromise').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetPromiseType(this NSwagSwagger2TsClientSettings toolSettings, PromiseType promiseType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PromiseType = promiseType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.PromiseType"/>.</em></p><p>The promise type ('Promise' or 'QPromise').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetPromiseType(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PromiseType = null;
            return toolSettings;
        }
        #endregion
        #region HttpClass
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.HttpClass"/>.</em></p><p>The Angular HTTP service class (default 'Http', 'HttpClient').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetHttpClass(this NSwagSwagger2TsClientSettings toolSettings, HttpClass httpClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpClass = httpClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.HttpClass"/>.</em></p><p>The Angular HTTP service class (default 'Http', 'HttpClient').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetHttpClass(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpClass = null;
            return toolSettings;
        }
        #endregion
        #region InjectionTokenType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.InjectionTokenType"/>.</em></p><p>The Angular injection token type (default 'OpaqueToken', 'InjectionToken').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetInjectionTokenType(this NSwagSwagger2TsClientSettings toolSettings, InjectionTokenType injectionTokenType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectionTokenType = injectionTokenType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.InjectionTokenType"/>.</em></p><p>The Angular injection token type (default 'OpaqueToken', 'InjectionToken').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetInjectionTokenType(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectionTokenType = null;
            return toolSettings;
        }
        #endregion
        #region DateTimeType
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.DateTimeType"/>.</em></p><p>The date time type ('Date', 'MomentJS', 'OffsetMomentJS', 'string').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetDateTimeType(this NSwagSwagger2TsClientSettings toolSettings, TypeScriptDateTimeType dateTimeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = dateTimeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.DateTimeType"/>.</em></p><p>The date time type ('Date', 'MomentJS', 'OffsetMomentJS', 'string').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetDateTimeType(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = null;
            return toolSettings;
        }
        #endregion
        #region NullValue
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.NullValue"/>.</em></p><p>The null value used in object initializers (default 'Undefined', 'Null').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetNullValue(this NSwagSwagger2TsClientSettings toolSettings, TypeScriptNullValue nullValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NullValue = nullValue;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.NullValue"/>.</em></p><p>The null value used in object initializers (default 'Undefined', 'Null').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetNullValue(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NullValue = null;
            return toolSettings;
        }
        #endregion
        #region GenerateClientClasses
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetGenerateClientClasses(this NSwagSwagger2TsClientSettings toolSettings, bool? generateClientClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = generateClientClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetGenerateClientClasses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableGenerateClientClasses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableGenerateClientClasses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleGenerateClientClasses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = !toolSettings.GenerateClientClasses;
            return toolSettings;
        }
        #endregion
        #region GenerateClientInterfaces
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetGenerateClientInterfaces(this NSwagSwagger2TsClientSettings toolSettings, bool? generateClientInterfaces)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = generateClientInterfaces;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetGenerateClientInterfaces(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableGenerateClientInterfaces(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableGenerateClientInterfaces(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleGenerateClientInterfaces(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = !toolSettings.GenerateClientInterfaces;
            return toolSettings;
        }
        #endregion
        #region GenerateOptionalParameters
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetGenerateOptionalParameters(this NSwagSwagger2TsClientSettings toolSettings, bool? generateOptionalParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = generateOptionalParameters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetGenerateOptionalParameters(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableGenerateOptionalParameters(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableGenerateOptionalParameters(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleGenerateOptionalParameters(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = !toolSettings.GenerateOptionalParameters;
            return toolSettings;
        }
        #endregion
        #region WrapDtoExceptions
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetWrapDtoExceptions(this NSwagSwagger2TsClientSettings toolSettings, bool? wrapDtoExceptions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = wrapDtoExceptions;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetWrapDtoExceptions(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableWrapDtoExceptions(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableWrapDtoExceptions(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleWrapDtoExceptions(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = !toolSettings.WrapDtoExceptions;
            return toolSettings;
        }
        #endregion
        #region ClientBaseClass
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ClientBaseClass"/>.</em></p><p>The base class of the generated client classes (optional, must be imported or implemented in the extension code).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetClientBaseClass(this NSwagSwagger2TsClientSettings toolSettings, string clientBaseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientBaseClass = clientBaseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.ClientBaseClass"/>.</em></p><p>The base class of the generated client classes (optional, must be imported or implemented in the extension code).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetClientBaseClass(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientBaseClass = null;
            return toolSettings;
        }
        #endregion
        #region WrapResponses
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetWrapResponses(this NSwagSwagger2TsClientSettings toolSettings, bool? wrapResponses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = wrapResponses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetWrapResponses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableWrapResponses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableWrapResponses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleWrapResponses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = !toolSettings.WrapResponses;
            return toolSettings;
        }
        #endregion
        #region WrapResponseMethods
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetWrapResponseMethods(this NSwagSwagger2TsClientSettings toolSettings, params String[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetWrapResponseMethods(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddWrapResponseMethods(this NSwagSwagger2TsClientSettings toolSettings, params String[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddWrapResponseMethods(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2TsClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ClearWrapResponseMethods(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveWrapResponseMethods(this NSwagSwagger2TsClientSettings toolSettings, params String[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveWrapResponseMethods(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenerateResponseClasses
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetGenerateResponseClasses(this NSwagSwagger2TsClientSettings toolSettings, bool? generateResponseClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = generateResponseClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetGenerateResponseClasses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableGenerateResponseClasses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableGenerateResponseClasses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleGenerateResponseClasses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = !toolSettings.GenerateResponseClasses;
            return toolSettings;
        }
        #endregion
        #region ResponseClass
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetResponseClass(this NSwagSwagger2TsClientSettings toolSettings, string responseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = responseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetResponseClass(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = null;
            return toolSettings;
        }
        #endregion
        #region ProtectedMethods
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ProtectedMethods"/> to a new list.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetProtectedMethods(this NSwagSwagger2TsClientSettings toolSettings, params String[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal = protectedMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ProtectedMethods"/> to a new list.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetProtectedMethods(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal = protectedMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddProtectedMethods(this NSwagSwagger2TsClientSettings toolSettings, params String[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.AddRange(protectedMethods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddProtectedMethods(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.AddRange(protectedMethods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2TsClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ClearProtectedMethods(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveProtectedMethods(this NSwagSwagger2TsClientSettings toolSettings, params String[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(protectedMethods);
            toolSettings.ProtectedMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveProtectedMethods(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(protectedMethods);
            toolSettings.ProtectedMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ConfigurationClass
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ConfigurationClass"/>.</em></p><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetConfigurationClass(this NSwagSwagger2TsClientSettings toolSettings, string configurationClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationClass = configurationClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.ConfigurationClass"/>.</em></p><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetConfigurationClass(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationClass = null;
            return toolSettings;
        }
        #endregion
        #region UseTransformOptionsMethod
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.UseTransformOptionsMethod"/>.</em></p><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetUseTransformOptionsMethod(this NSwagSwagger2TsClientSettings toolSettings, bool? useTransformOptionsMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformOptionsMethod = useTransformOptionsMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.UseTransformOptionsMethod"/>.</em></p><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetUseTransformOptionsMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformOptionsMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.UseTransformOptionsMethod"/>.</em></p><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableUseTransformOptionsMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformOptionsMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.UseTransformOptionsMethod"/>.</em></p><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableUseTransformOptionsMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformOptionsMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.UseTransformOptionsMethod"/>.</em></p><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleUseTransformOptionsMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformOptionsMethod = !toolSettings.UseTransformOptionsMethod;
            return toolSettings;
        }
        #endregion
        #region UseTransformResultMethod
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.UseTransformResultMethod"/>.</em></p><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetUseTransformResultMethod(this NSwagSwagger2TsClientSettings toolSettings, bool? useTransformResultMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformResultMethod = useTransformResultMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.UseTransformResultMethod"/>.</em></p><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetUseTransformResultMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformResultMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.UseTransformResultMethod"/>.</em></p><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableUseTransformResultMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformResultMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.UseTransformResultMethod"/>.</em></p><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableUseTransformResultMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformResultMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.UseTransformResultMethod"/>.</em></p><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleUseTransformResultMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformResultMethod = !toolSettings.UseTransformResultMethod;
            return toolSettings;
        }
        #endregion
        #region GenerateDtoTypes
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetGenerateDtoTypes(this NSwagSwagger2TsClientSettings toolSettings, bool? generateDtoTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = generateDtoTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetGenerateDtoTypes(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableGenerateDtoTypes(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableGenerateDtoTypes(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleGenerateDtoTypes(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = !toolSettings.GenerateDtoTypes;
            return toolSettings;
        }
        #endregion
        #region OperationGenerationMode
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetOperationGenerationMode(this NSwagSwagger2TsClientSettings toolSettings, OperationGenerationMode operationGenerationMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = operationGenerationMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetOperationGenerationMode(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = null;
            return toolSettings;
        }
        #endregion
        #region MarkOptionalProperties
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.MarkOptionalProperties"/>.</em></p><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetMarkOptionalProperties(this NSwagSwagger2TsClientSettings toolSettings, bool? markOptionalProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkOptionalProperties = markOptionalProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.MarkOptionalProperties"/>.</em></p><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetMarkOptionalProperties(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkOptionalProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.MarkOptionalProperties"/>.</em></p><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableMarkOptionalProperties(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkOptionalProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.MarkOptionalProperties"/>.</em></p><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableMarkOptionalProperties(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkOptionalProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.MarkOptionalProperties"/>.</em></p><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleMarkOptionalProperties(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkOptionalProperties = !toolSettings.MarkOptionalProperties;
            return toolSettings;
        }
        #endregion
        #region GenerateCloneMethod
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.GenerateCloneMethod"/>.</em></p><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetGenerateCloneMethod(this NSwagSwagger2TsClientSettings toolSettings, bool? generateCloneMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateCloneMethod = generateCloneMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.GenerateCloneMethod"/>.</em></p><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetGenerateCloneMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateCloneMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.GenerateCloneMethod"/>.</em></p><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableGenerateCloneMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateCloneMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.GenerateCloneMethod"/>.</em></p><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableGenerateCloneMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateCloneMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.GenerateCloneMethod"/>.</em></p><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleGenerateCloneMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateCloneMethod = !toolSettings.GenerateCloneMethod;
            return toolSettings;
        }
        #endregion
        #region TypeStyle
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.TypeStyle"/>.</em></p><p>The type style (default: Class).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetTypeStyle(this NSwagSwagger2TsClientSettings toolSettings, TypeScriptTypeStyle typeStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeStyle = typeStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.TypeStyle"/>.</em></p><p>The type style (default: Class).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetTypeStyle(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeStyle = null;
            return toolSettings;
        }
        #endregion
        #region ClassTypes
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ClassTypes"/> to a new list.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetClassTypes(this NSwagSwagger2TsClientSettings toolSettings, params String[] classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassTypesInternal = classTypes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ClassTypes"/> to a new list.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetClassTypes(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassTypesInternal = classTypes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.ClassTypes"/>.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddClassTypes(this NSwagSwagger2TsClientSettings toolSettings, params String[] classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassTypesInternal.AddRange(classTypes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.ClassTypes"/>.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddClassTypes(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassTypesInternal.AddRange(classTypes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2TsClientSettings.ClassTypes"/>.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ClearClassTypes(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassTypesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.ClassTypes"/>.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveClassTypes(this NSwagSwagger2TsClientSettings toolSettings, params String[] classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(classTypes);
            toolSettings.ClassTypesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.ClassTypes"/>.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveClassTypes(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(classTypes);
            toolSettings.ClassTypesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExtendedClasses
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ExtendedClasses"/> to a new list.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetExtendedClasses(this NSwagSwagger2TsClientSettings toolSettings, params String[] extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtendedClassesInternal = extendedClasses.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ExtendedClasses"/> to a new list.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetExtendedClasses(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtendedClassesInternal = extendedClasses.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.ExtendedClasses"/>.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddExtendedClasses(this NSwagSwagger2TsClientSettings toolSettings, params String[] extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtendedClassesInternal.AddRange(extendedClasses);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.ExtendedClasses"/>.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddExtendedClasses(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtendedClassesInternal.AddRange(extendedClasses);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2TsClientSettings.ExtendedClasses"/>.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ClearExtendedClasses(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtendedClassesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.ExtendedClasses"/>.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveExtendedClasses(this NSwagSwagger2TsClientSettings toolSettings, params String[] extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(extendedClasses);
            toolSettings.ExtendedClassesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.ExtendedClasses"/>.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveExtendedClasses(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(extendedClasses);
            toolSettings.ExtendedClassesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExtensionCode
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ExtensionCode"/>.</em></p><p>The extension code (string or file path).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetExtensionCode(this NSwagSwagger2TsClientSettings toolSettings, string extensionCode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionCode = extensionCode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.ExtensionCode"/>.</em></p><p>The extension code (string or file path).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetExtensionCode(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionCode = null;
            return toolSettings;
        }
        #endregion
        #region GenerateDefaultValues
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetGenerateDefaultValues(this NSwagSwagger2TsClientSettings toolSettings, bool? generateDefaultValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = generateDefaultValues;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetGenerateDefaultValues(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableGenerateDefaultValues(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableGenerateDefaultValues(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleGenerateDefaultValues(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = !toolSettings.GenerateDefaultValues;
            return toolSettings;
        }
        #endregion
        #region ExcludedTypeNames
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetExcludedTypeNames(this NSwagSwagger2TsClientSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetExcludedTypeNames(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddExcludedTypeNames(this NSwagSwagger2TsClientSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddExcludedTypeNames(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2TsClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ClearExcludedTypeNames(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveExcludedTypeNames(this NSwagSwagger2TsClientSettings toolSettings, params String[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveExcludedTypeNames(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region HandleReferences
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.HandleReferences"/>.</em></p><p>Handle JSON references (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetHandleReferences(this NSwagSwagger2TsClientSettings toolSettings, bool? handleReferences)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = handleReferences;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.HandleReferences"/>.</em></p><p>Handle JSON references (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetHandleReferences(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.HandleReferences"/>.</em></p><p>Handle JSON references (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableHandleReferences(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.HandleReferences"/>.</em></p><p>Handle JSON references (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableHandleReferences(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.HandleReferences"/>.</em></p><p>Handle JSON references (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleHandleReferences(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = !toolSettings.HandleReferences;
            return toolSettings;
        }
        #endregion
        #region GenerateConstructorInterface
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.GenerateConstructorInterface"/>.</em></p><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetGenerateConstructorInterface(this NSwagSwagger2TsClientSettings toolSettings, bool? generateConstructorInterface)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateConstructorInterface = generateConstructorInterface;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.GenerateConstructorInterface"/>.</em></p><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetGenerateConstructorInterface(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateConstructorInterface = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.GenerateConstructorInterface"/>.</em></p><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableGenerateConstructorInterface(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateConstructorInterface = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.GenerateConstructorInterface"/>.</em></p><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableGenerateConstructorInterface(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateConstructorInterface = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.GenerateConstructorInterface"/>.</em></p><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleGenerateConstructorInterface(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateConstructorInterface = !toolSettings.GenerateConstructorInterface;
            return toolSettings;
        }
        #endregion
        #region ConvertConstructorInterfaceData
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ConvertConstructorInterfaceData"/>.</em></p><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetConvertConstructorInterfaceData(this NSwagSwagger2TsClientSettings toolSettings, bool? convertConstructorInterfaceData)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConvertConstructorInterfaceData = convertConstructorInterfaceData;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.ConvertConstructorInterfaceData"/>.</em></p><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetConvertConstructorInterfaceData(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConvertConstructorInterfaceData = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.ConvertConstructorInterfaceData"/>.</em></p><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableConvertConstructorInterfaceData(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConvertConstructorInterfaceData = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.ConvertConstructorInterfaceData"/>.</em></p><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableConvertConstructorInterfaceData(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConvertConstructorInterfaceData = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.ConvertConstructorInterfaceData"/>.</em></p><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleConvertConstructorInterfaceData(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConvertConstructorInterfaceData = !toolSettings.ConvertConstructorInterfaceData;
            return toolSettings;
        }
        #endregion
        #region ImportRequiredTypes
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ImportRequiredTypes"/>.</em></p><p>Specifies whether required types should be imported (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetImportRequiredTypes(this NSwagSwagger2TsClientSettings toolSettings, bool? importRequiredTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportRequiredTypes = importRequiredTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.ImportRequiredTypes"/>.</em></p><p>Specifies whether required types should be imported (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetImportRequiredTypes(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportRequiredTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.ImportRequiredTypes"/>.</em></p><p>Specifies whether required types should be imported (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableImportRequiredTypes(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportRequiredTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.ImportRequiredTypes"/>.</em></p><p>Specifies whether required types should be imported (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableImportRequiredTypes(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportRequiredTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.ImportRequiredTypes"/>.</em></p><p>Specifies whether required types should be imported (default: true).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleImportRequiredTypes(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportRequiredTypes = !toolSettings.ImportRequiredTypes;
            return toolSettings;
        }
        #endregion
        #region UseGetBaseUrlMethod
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.UseGetBaseUrlMethod"/>.</em></p><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetUseGetBaseUrlMethod(this NSwagSwagger2TsClientSettings toolSettings, bool? useGetBaseUrlMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseGetBaseUrlMethod = useGetBaseUrlMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.UseGetBaseUrlMethod"/>.</em></p><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetUseGetBaseUrlMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseGetBaseUrlMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwagger2TsClientSettings.UseGetBaseUrlMethod"/>.</em></p><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings EnableUseGetBaseUrlMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseGetBaseUrlMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwagger2TsClientSettings.UseGetBaseUrlMethod"/>.</em></p><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings DisableUseGetBaseUrlMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseGetBaseUrlMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwagger2TsClientSettings.UseGetBaseUrlMethod"/>.</em></p><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ToggleUseGetBaseUrlMethod(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseGetBaseUrlMethod = !toolSettings.UseGetBaseUrlMethod;
            return toolSettings;
        }
        #endregion
        #region BaseUrlTokenName
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.BaseUrlTokenName"/>.</em></p><p>The token name for injecting the API base URL string (used in the Angular template, default: 'API_BASE_URL').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetBaseUrlTokenName(this NSwagSwagger2TsClientSettings toolSettings, string baseUrlTokenName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseUrlTokenName = baseUrlTokenName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.BaseUrlTokenName"/>.</em></p><p>The token name for injecting the API base URL string (used in the Angular template, default: 'API_BASE_URL').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetBaseUrlTokenName(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseUrlTokenName = null;
            return toolSettings;
        }
        #endregion
        #region QueryNullValue
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.QueryNullValue"/>.</em></p><p>The null value used for query parameters which are null (default: '').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetQueryNullValue(this NSwagSwagger2TsClientSettings toolSettings, string queryNullValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QueryNullValue = queryNullValue;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.QueryNullValue"/>.</em></p><p>The null value used for query parameters which are null (default: '').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetQueryNullValue(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QueryNullValue = null;
            return toolSettings;
        }
        #endregion
        #region TemplateDirectory
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetTemplateDirectory(this NSwagSwagger2TsClientSettings toolSettings, string templateDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = templateDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetTemplateDirectory(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetInput(this NSwagSwagger2TsClientSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetInput(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetServiceHost(this NSwagSwagger2TsClientSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetServiceHost(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetServiceSchemes(this NSwagSwagger2TsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetServiceSchemes(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddServiceSchemes(this NSwagSwagger2TsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwagger2TsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings AddServiceSchemes(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwagger2TsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ClearServiceSchemes(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveServiceSchemes(this NSwagSwagger2TsClientSettings toolSettings, params String[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwagger2TsClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings RemoveServiceSchemes(this NSwagSwagger2TsClientSettings toolSettings, IEnumerable<String> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<String>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagSwagger2TsClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings SetOutput(this NSwagSwagger2TsClientSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwagger2TsClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwagger2TsClientSettings ResetOutput(this NSwagSwagger2TsClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region PropertyNameHandling
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class PropertyNameHandling : Enumeration
    {
        public static PropertyNameHandling Default = new PropertyNameHandling { Value = "Default" };
        public static PropertyNameHandling CamelCase = new PropertyNameHandling { Value = "CamelCase" };
        public static PropertyNameHandling SnakeCase = new PropertyNameHandling { Value = "SnakeCase" };
    }
    #endregion
    #region ReferenceTypeNullHandling
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class ReferenceTypeNullHandling : Enumeration
    {
        public static ReferenceTypeNullHandling Null = new ReferenceTypeNullHandling { Value = "Null" };
        public static ReferenceTypeNullHandling NotNull = new ReferenceTypeNullHandling { Value = "NotNull" };
    }
    #endregion
    #region EnumHandling
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class EnumHandling : Enumeration
    {
        public static EnumHandling Integer = new EnumHandling { Value = "Integer" };
        public static EnumHandling String = new EnumHandling { Value = "String" };
    }
    #endregion
    #region OperationGenerationMode
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class OperationGenerationMode : Enumeration
    {
        public static OperationGenerationMode MultipleClientsFromOperationId = new OperationGenerationMode { Value = "MultipleClientsFromOperationId" };
        public static OperationGenerationMode MultipleClientsFromPathSegments = new OperationGenerationMode { Value = "MultipleClientsFromPathSegments" };
        public static OperationGenerationMode SingleClientFromOperationId = new OperationGenerationMode { Value = "SingleClientFromOperationId" };
        public static OperationGenerationMode SingleClientFromPathSegments = new OperationGenerationMode { Value = "SingleClientFromPathSegments" };
    }
    #endregion
    #region CSharpClassStyle
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class CSharpClassStyle : Enumeration
    {
        public static CSharpClassStyle Poco = new CSharpClassStyle { Value = "Poco" };
        public static CSharpClassStyle Inpc = new CSharpClassStyle { Value = "Inpc" };
    }
    #endregion
    #region CSharpControllerStyle
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class CSharpControllerStyle : Enumeration
    {
        public static CSharpControllerStyle Partial = new CSharpControllerStyle { Value = "Partial" };
        public static CSharpControllerStyle Abstract = new CSharpControllerStyle { Value = "Abstract" };
    }
    #endregion
    #region TypeScriptTemplate
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class TypeScriptTemplate : Enumeration
    {
        public static TypeScriptTemplate JQueryCallbacks = new TypeScriptTemplate { Value = "JQueryCallbacks" };
        public static TypeScriptTemplate JQueryPromises = new TypeScriptTemplate { Value = "JQueryPromises" };
        public static TypeScriptTemplate AngularJS = new TypeScriptTemplate { Value = "AngularJS" };
        public static TypeScriptTemplate Angular = new TypeScriptTemplate { Value = "Angular" };
        public static TypeScriptTemplate Fetch = new TypeScriptTemplate { Value = "Fetch" };
        public static TypeScriptTemplate Aurelia = new TypeScriptTemplate { Value = "Aurelia" };
    }
    #endregion
    #region PromiseType
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class PromiseType : Enumeration
    {
        public static PromiseType Promise = new PromiseType { Value = "Promise" };
        public static PromiseType QPromise = new PromiseType { Value = "QPromise" };
    }
    #endregion
    #region HttpClass
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class HttpClass : Enumeration
    {
        public static HttpClass Http = new HttpClass { Value = "Http" };
        public static HttpClass HttpClient = new HttpClass { Value = "HttpClient" };
    }
    #endregion
    #region InjectionTokenType
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class InjectionTokenType : Enumeration
    {
        public static InjectionTokenType OpaqueToken = new InjectionTokenType { Value = "OpaqueToken" };
        public static InjectionTokenType InjectionToken = new InjectionTokenType { Value = "InjectionToken" };
    }
    #endregion
    #region TypeScriptDateTimeType
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class TypeScriptDateTimeType : Enumeration
    {
        public static TypeScriptDateTimeType Date = new TypeScriptDateTimeType { Value = "Date" };
        public static TypeScriptDateTimeType MomentJS = new TypeScriptDateTimeType { Value = "MomentJS" };
        public static TypeScriptDateTimeType String = new TypeScriptDateTimeType { Value = "String" };
        public static TypeScriptDateTimeType OffsetMomentJS = new TypeScriptDateTimeType { Value = "OffsetMomentJS" };
    }
    #endregion
    #region TypeScriptNullValue
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class TypeScriptNullValue : Enumeration
    {
        public static TypeScriptNullValue Null = new TypeScriptNullValue { Value = "Null" };
        public static TypeScriptNullValue Undefined = new TypeScriptNullValue { Value = "Undefined" };
    }
    #endregion
    #region TypeScriptTypeStyle
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class TypeScriptTypeStyle : Enumeration
    {
        public static TypeScriptTypeStyle Interface = new TypeScriptTypeStyle { Value = "Interface" };
        public static TypeScriptTypeStyle Class = new TypeScriptTypeStyle { Value = "Class" };
        public static TypeScriptTypeStyle KnockoutClass = new TypeScriptTypeStyle { Value = "KnockoutClass" };
    }
    #endregion
}
