// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, Version: 0.5.3 [CommitSha: 0aff3c55].
// Generated from https://github.com/nuke-build/nswag/blob/master/src/Nuke.NSwag/specifications/NSwag.json.

using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
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
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public static string NSwagPath => GetToolPath();
        /// <summary><p>The project combines the functionality of Swashbuckle (Swagger generation) and AutoRest (client generation) in one toolchain. This way a lot of incompatibilites can be avoided and features which are not well described by the Swagger specification or JSON Schema are better supported (e.g. <a href="https://github.com/NJsonSchema/NJsonSchema/wiki/Inheritance">inheritance</a>, <a href="https://github.com/NJsonSchema/NJsonSchema/wiki/Enums">enum</a> and reference handling). The NSwag project heavily uses <a href="http://njsonschema.org/">NJsonSchema for .NET</a> for JSON Schema handling and C#/TypeScript class/interface generation.</p></summary>
        public static IEnumerable<string> NSwag(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool redirectOutput = false, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(NSwagPath, arguments, workingDirectory, environmentVariables, timeout, redirectOutput, outputFilter);
            process.AssertZeroExitCode();
            return process.HasOutput ? process.Output.Select(x => x.Text) : null;
        }
        static partial void PreProcess(NSwagVersionSettings toolSettings);
        static partial void PostProcess(NSwagVersionSettings toolSettings);
        /// <summary><p>Prints the toolchain version.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagVersion(Configure<NSwagVersionSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagVersionSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagListTypesSettings toolSettings);
        static partial void PostProcess(NSwagListTypesSettings toolSettings);
        /// <summary><p>List all types for the given assembly and settings.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagListTypes(Configure<NSwagListTypesSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagListTypesSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagListWebApiControllersSettings toolSettings);
        static partial void PostProcess(NSwagListWebApiControllersSettings toolSettings);
        /// <summary><p>List all controllers classes for the given assembly and settings.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagListWebApiControllers(Configure<NSwagListWebApiControllersSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagListWebApiControllersSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagTypesToSwaggerSettings toolSettings);
        static partial void PostProcess(NSwagTypesToSwaggerSettings toolSettings);
        /// <summary><p>The project combines the functionality of Swashbuckle (Swagger generation) and AutoRest (client generation) in one toolchain. This way a lot of incompatibilites can be avoided and features which are not well described by the Swagger specification or JSON Schema are better supported (e.g. <a href="https://github.com/NJsonSchema/NJsonSchema/wiki/Inheritance">inheritance</a>, <a href="https://github.com/NJsonSchema/NJsonSchema/wiki/Enums">enum</a> and reference handling). The NSwag project heavily uses <a href="http://njsonschema.org/">NJsonSchema for .NET</a> for JSON Schema handling and C#/TypeScript class/interface generation.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagTypesToSwagger(Configure<NSwagTypesToSwaggerSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagTypesToSwaggerSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagWebApiToSwaggerSettings toolSettings);
        static partial void PostProcess(NSwagWebApiToSwaggerSettings toolSettings);
        /// <summary><p>Generates a Swagger specification for a controller or controlles contained in a .NET Web API assembly.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagWebApiToSwagger(Configure<NSwagWebApiToSwaggerSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagWebApiToSwaggerSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagAspNetCoreToSwaggerSettings toolSettings);
        static partial void PostProcess(NSwagAspNetCoreToSwaggerSettings toolSettings);
        /// <summary><p>Generates a Swagger specification ASP.NET Core Mvc application using ApiExplorer (experimental).</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagAspNetCoreToSwagger(Configure<NSwagAspNetCoreToSwaggerSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagAspNetCoreToSwaggerSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagCreateDocumentSettings toolSettings);
        static partial void PostProcess(NSwagCreateDocumentSettings toolSettings);
        /// <summary><p>Creates a new nswag.json file in the current directory.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagCreateDocument(Configure<NSwagCreateDocumentSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagCreateDocumentSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagExecuteDocumentSettings toolSettings);
        static partial void PostProcess(NSwagExecuteDocumentSettings toolSettings);
        /// <summary><p>Executes an .nswag file. If 'input' is not specified then all *.nswag files and the nswag.json file is executed.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagExecuteDocument(Configure<NSwagExecuteDocumentSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagExecuteDocumentSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagJsonSchemaToCSharpSettings toolSettings);
        static partial void PostProcess(NSwagJsonSchemaToCSharpSettings toolSettings);
        /// <summary><p>Generates CSharp classes from a JSON Schema.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagJsonSchemaToCSharp(Configure<NSwagJsonSchemaToCSharpSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagJsonSchemaToCSharpSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagJsonSchemaToTypeScriptSettings toolSettings);
        static partial void PostProcess(NSwagJsonSchemaToTypeScriptSettings toolSettings);
        /// <summary><p>Generates TypeScript interfaces from a JSON Schema.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagJsonSchemaToTypeScript(Configure<NSwagJsonSchemaToTypeScriptSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagJsonSchemaToTypeScriptSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagSwaggerToCSharpClientSettings toolSettings);
        static partial void PostProcess(NSwagSwaggerToCSharpClientSettings toolSettings);
        /// <summary><p>Generates CSharp client code from a Swagger specification.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagSwaggerToCSharpClient(Configure<NSwagSwaggerToCSharpClientSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagSwaggerToCSharpClientSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagSwaggerToCSharpControllerSettings toolSettings);
        static partial void PostProcess(NSwagSwaggerToCSharpControllerSettings toolSettings);
        /// <summary><p>Generates CSharp Web API controller code from a Swagger specification.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagSwaggerToCSharpController(Configure<NSwagSwaggerToCSharpControllerSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagSwaggerToCSharpControllerSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NSwagSwaggerToTypeScriptClientSettings toolSettings);
        static partial void PostProcess(NSwagSwaggerToTypeScriptClientSettings toolSettings);
        /// <summary><p>Generates TypeScript client code from a Swagger specification.</p><p>For more details, visit the <a href="https://github.com/RSuter/NSwag">official website</a>.</p></summary>
        public static void NSwagSwaggerToTypeScriptClient(Configure<NSwagSwaggerToTypeScriptClientSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NSwagSwaggerToTypeScriptClientSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
    }
    #region NSwagVersionSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagVersionSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("version")
              .Add("{value}", GetNSwagRuntime(), customValue: true);
            return base.ConfigureArguments(arguments);
        }
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
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        /// <summary><p>The nswag.json configuration file path.</p></summary>
        public virtual string File { get; internal set; }
        public virtual IReadOnlyDictionary<string, object> Variables => VariablesInternal.AsReadOnly();
        internal Dictionary<string,object> VariablesInternal { get; set; } = new Dictionary<string,object>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        public virtual IReadOnlyList<string> Assembly => AssemblyInternal.AsReadOnly();
        internal List<string> AssemblyInternal { get; set; } = new List<string>();
        /// <summary><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        public virtual string AssemblyConfig { get; internal set; }
        /// <summary><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        public virtual IReadOnlyList<string> ReferencePaths => ReferencePathsInternal.AsReadOnly();
        internal List<string> ReferencePathsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("list-types")
              .Add("/File:{value}", File)
              .Add("/Variables:{value}", Variables, "{key}={value}")
              .Add("{value}", GetNSwagRuntime(), customValue: true)
              .Add("/Assembly:{value}", Assembly)
              .Add("/AssemblyConfig:{value}", AssemblyConfig)
              .Add("/ReferencePaths:{value}", ReferencePaths);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagListWebApiControllersSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagListWebApiControllersSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        /// <summary><p>The nswag.json configuration file path.</p></summary>
        public virtual string File { get; internal set; }
        public virtual IReadOnlyDictionary<string, object> Variables => VariablesInternal.AsReadOnly();
        internal Dictionary<string,object> VariablesInternal { get; set; } = new Dictionary<string,object>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        public virtual IReadOnlyList<string> Assembly => AssemblyInternal.AsReadOnly();
        internal List<string> AssemblyInternal { get; set; } = new List<string>();
        /// <summary><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        public virtual string AssemblyConfig { get; internal set; }
        /// <summary><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        public virtual IReadOnlyList<string> ReferencePaths => ReferencePathsInternal.AsReadOnly();
        internal List<string> ReferencePathsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("list-controllers")
              .Add("/File:{value}", File)
              .Add("/Variables:{value}", Variables, "{key}={value}")
              .Add("{value}", GetNSwagRuntime(), customValue: true)
              .Add("/Assembly:{value}", Assembly)
              .Add("/AssemblyConfig:{value}", AssemblyConfig)
              .Add("/ReferencePaths:{value}", ReferencePaths);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagTypesToSwaggerSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagTypesToSwaggerSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        /// <summary><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        public virtual bool? AllowReferencesWithProperties { get; internal set; }
        /// <summary><p>The class names.</p></summary>
        public virtual IReadOnlyList<string> ClassNames => ClassNamesInternal.AsReadOnly();
        internal List<string> ClassNamesInternal { get; set; } = new List<string>();
        /// <summary><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        public virtual EnumHandling DefaultEnumHandling { get; internal set; }
        /// <summary><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        public virtual PropertyNameHandling DefaultPropertyNameHandling { get; internal set; }
        /// <summary><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        public virtual ReferenceTypeNullHandling DefaultReferenceTypeNullHandling { get; internal set; }
        /// <summary><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        public virtual bool? FlattenInheritanceHierarchy { get; internal set; }
        /// <summary><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        public virtual bool? GenerateKnownTypes { get; internal set; }
        /// <summary><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        public virtual bool? GenerateXmlObjects { get; internal set; }
        /// <summary><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        public virtual bool? IgnoreObsoleteProperties { get; internal set; }
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Specifies the output schema type (Swagger2|OpenApi3, default: Swagger2).</p></summary>
        public virtual SchemaType OutputType { get; internal set; }
        /// <summary><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        public virtual IReadOnlyList<string> Assembly => AssemblyInternal.AsReadOnly();
        internal List<string> AssemblyInternal { get; set; } = new List<string>();
        /// <summary><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        public virtual string AssemblyConfig { get; internal set; }
        /// <summary><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        public virtual IReadOnlyList<string> ReferencePaths => ReferencePathsInternal.AsReadOnly();
        internal List<string> ReferencePathsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("types2swagger")
              .Add("/AllowReferencesWithProperties:{value}", AllowReferencesWithProperties)
              .Add("/ClassNames:{value}", ClassNames)
              .Add("/DefaultEnumHandling:{value}", DefaultEnumHandling)
              .Add("/DefaultPropertyNameHandling:{value}", DefaultPropertyNameHandling)
              .Add("/DefaultReferenceTypeNullHandling:{value}", DefaultReferenceTypeNullHandling)
              .Add("/FlattenInheritanceHierarchy:{value}", FlattenInheritanceHierarchy)
              .Add("/GenerateKnownTypes:{value}", GenerateKnownTypes)
              .Add("/GenerateXmlObjects:{value}", GenerateXmlObjects)
              .Add("/IgnoreObsoleteProperties:{value}", IgnoreObsoleteProperties)
              .Add("{value}", GetNSwagRuntime(), customValue: true)
              .Add("/Output:{value}", Output)
              .Add("/OutputType:{value}", OutputType)
              .Add("/Assembly:{value}", Assembly)
              .Add("/AssemblyConfig:{value}", AssemblyConfig)
              .Add("/ReferencePaths:{value}", ReferencePaths);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagWebApiToSwaggerSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagWebApiToSwaggerSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        /// <summary><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        public virtual bool? AddMissingPathParameters { get; internal set; }
        /// <summary><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        public virtual bool? AspNetCore { get; internal set; }
        /// <summary><p>The Web API controller full class name or empty to load all controllers from the assembly.</p></summary>
        public virtual string Controller { get; internal set; }
        /// <summary><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        public virtual IReadOnlyList<string> Controllers => ControllersInternal.AsReadOnly();
        internal List<string> ControllersInternal { get; set; } = new List<string>();
        /// <summary><p>The Web API default URL template (default for Web API: 'api/{controller}/{id}'; for MVC projects: '{controller}/{action}/{id?}').</p></summary>
        public virtual string DefaultUrlTemplate { get; internal set; }
        /// <summary><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        public virtual bool? AllowReferencesWithProperties { get; internal set; }
        /// <summary><p>The custom IContractResolver implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string ContractResolver { get; internal set; }
        /// <summary><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        public virtual EnumHandling DefaultEnumHandling { get; internal set; }
        /// <summary><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        public virtual PropertyNameHandling DefaultPropertyNameHandling { get; internal set; }
        /// <summary><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        public virtual ReferenceTypeNullHandling DefaultReferenceTypeNullHandling { get; internal set; }
        /// <summary><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual IReadOnlyList<string> DocumentProcessors => DocumentProcessorsInternal.AsReadOnly();
        internal List<string> DocumentProcessorsInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        public virtual string DocumentTemplate { get; internal set; }
        /// <summary><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        public virtual IReadOnlyList<string> ExcludedTypeNames => ExcludedTypeNamesInternal.AsReadOnly();
        internal List<string> ExcludedTypeNamesInternal { get; set; } = new List<string>();
        /// <summary><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        public virtual bool? FlattenInheritanceHierarchy { get; internal set; }
        /// <summary><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        public virtual bool? GenerateAbstractProperties { get; internal set; }
        /// <summary><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        public virtual bool? GenerateKnownTypes { get; internal set; }
        /// <summary><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        public virtual bool? GenerateXmlObjects { get; internal set; }
        /// <summary><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        public virtual bool? IgnoreObsoleteProperties { get; internal set; }
        /// <summary><p>Specify the description of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        public virtual string InfoDescription { get; internal set; }
        /// <summary><p>Specify the title of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        public virtual string InfoTitle { get; internal set; }
        /// <summary><p>Specify the version of the Swagger specification (default: 1.0.0, ignored when DocumentTemplate is set).</p></summary>
        public virtual string InfoVersion { get; internal set; }
        /// <summary><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual IReadOnlyList<string> OperationProcessors => OperationProcessorsInternal.AsReadOnly();
        internal List<string> OperationProcessorsInternal { get; set; } = new List<string>();
        /// <summary><p>The custom ISchemaNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string SchemaNameGenerator { get; internal set; }
        /// <summary><p>The basePath of the Swagger specification (optional).</p></summary>
        public virtual string ServiceBasePath { get; internal set; }
        /// <summary><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<string> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<string> ServiceSchemesInternal { get; set; } = new List<string>();
        /// <summary><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string TypeNameGenerator { get; internal set; }
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Specifies the output schema type (Swagger2|OpenApi3, default: Swagger2).</p></summary>
        public virtual SchemaType OutputType { get; internal set; }
        /// <summary><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        public virtual IReadOnlyList<string> Assembly => AssemblyInternal.AsReadOnly();
        internal List<string> AssemblyInternal { get; set; } = new List<string>();
        /// <summary><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        public virtual string AssemblyConfig { get; internal set; }
        /// <summary><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        public virtual IReadOnlyList<string> ReferencePaths => ReferencePathsInternal.AsReadOnly();
        internal List<string> ReferencePathsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("webapi2swagger")
              .Add("/AddMissingPathParameters:{value}", AddMissingPathParameters)
              .Add("/AspNetCore:{value}", AspNetCore)
              .Add("/Controller:{value}", Controller)
              .Add("/Controllers:{value}", Controllers)
              .Add("/DefaultUrlTemplate:{value}", DefaultUrlTemplate)
              .Add("{value}", GetNSwagRuntime(), customValue: true)
              .Add("/AllowReferencesWithProperties:{value}", AllowReferencesWithProperties)
              .Add("/ContractResolver:{value}", ContractResolver)
              .Add("/DefaultEnumHandling:{value}", DefaultEnumHandling)
              .Add("/DefaultPropertyNameHandling:{value}", DefaultPropertyNameHandling)
              .Add("/DefaultReferenceTypeNullHandling:{value}", DefaultReferenceTypeNullHandling)
              .Add("/DocumentProcessors:{value}", DocumentProcessors)
              .Add("/DocumentTemplate:{value}", DocumentTemplate)
              .Add("/ExcludedTypeNames:{value}", ExcludedTypeNames)
              .Add("/FlattenInheritanceHierarchy:{value}", FlattenInheritanceHierarchy)
              .Add("/GenerateAbstractProperties:{value}", GenerateAbstractProperties)
              .Add("/GenerateKnownTypes:{value}", GenerateKnownTypes)
              .Add("/GenerateXmlObjects:{value}", GenerateXmlObjects)
              .Add("/IgnoreObsoleteProperties:{value}", IgnoreObsoleteProperties)
              .Add("/InfoDescription:{value}", InfoDescription)
              .Add("/InfoTitle:{value}", InfoTitle)
              .Add("/InfoVersion:{value}", InfoVersion)
              .Add("/OperationProcessors:{value}", OperationProcessors)
              .Add("/SchemaNameGenerator:{value}", SchemaNameGenerator)
              .Add("/ServiceBasePath:{value}", ServiceBasePath)
              .Add("/ServiceHost:{value}", ServiceHost)
              .Add("/ServiceSchemes:{value}", ServiceSchemes)
              .Add("/TypeNameGenerator:{value}", TypeNameGenerator)
              .Add("/Output:{value}", Output)
              .Add("/OutputType:{value}", OutputType)
              .Add("/Assembly:{value}", Assembly)
              .Add("/AssemblyConfig:{value}", AssemblyConfig)
              .Add("/ReferencePaths:{value}", ReferencePaths);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagAspNetCoreToSwaggerSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagAspNetCoreToSwaggerSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        /// <summary><p>The configuration to use.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>The MSBuild project extensions path. Defaults to "obj".</p></summary>
        public virtual string MSBuildProjectExtensionsPath { get; internal set; }
        /// <summary><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary><p>The project to use.</p></summary>
        public virtual string Project { get; internal set; }
        /// <summary><p>The runtime to use.</p></summary>
        public virtual string Runtime { get; internal set; }
        /// <summary><p>The target framework to use.</p></summary>
        public virtual string TargetFramework { get; internal set; }
        /// <summary><p>Print verbose output.</p></summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        public virtual bool? AllowReferencesWithProperties { get; internal set; }
        /// <summary><p>The custom IContractResolver implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string ContractResolver { get; internal set; }
        /// <summary><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        public virtual EnumHandling DefaultEnumHandling { get; internal set; }
        /// <summary><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        public virtual PropertyNameHandling DefaultPropertyNameHandling { get; internal set; }
        /// <summary><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        public virtual ReferenceTypeNullHandling DefaultReferenceTypeNullHandling { get; internal set; }
        /// <summary><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual IReadOnlyList<string> DocumentProcessors => DocumentProcessorsInternal.AsReadOnly();
        internal List<string> DocumentProcessorsInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        public virtual string DocumentTemplate { get; internal set; }
        /// <summary><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        public virtual IReadOnlyList<string> ExcludedTypeNames => ExcludedTypeNamesInternal.AsReadOnly();
        internal List<string> ExcludedTypeNamesInternal { get; set; } = new List<string>();
        /// <summary><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        public virtual bool? FlattenInheritanceHierarchy { get; internal set; }
        /// <summary><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        public virtual bool? GenerateAbstractProperties { get; internal set; }
        /// <summary><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        public virtual bool? GenerateKnownTypes { get; internal set; }
        /// <summary><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        public virtual bool? GenerateXmlObjects { get; internal set; }
        /// <summary><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        public virtual bool? IgnoreObsoleteProperties { get; internal set; }
        /// <summary><p>Specify the description of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        public virtual string InfoDescription { get; internal set; }
        /// <summary><p>Specify the title of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        public virtual string InfoTitle { get; internal set; }
        /// <summary><p>Specify the version of the Swagger specification (default: 1.0.0, ignored when DocumentTemplate is set).</p></summary>
        public virtual string InfoVersion { get; internal set; }
        /// <summary><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual IReadOnlyList<string> OperationProcessors => OperationProcessorsInternal.AsReadOnly();
        internal List<string> OperationProcessorsInternal { get; set; } = new List<string>();
        /// <summary><p>The custom ISchemaNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string SchemaNameGenerator { get; internal set; }
        /// <summary><p>The basePath of the Swagger specification (optional).</p></summary>
        public virtual string ServiceBasePath { get; internal set; }
        /// <summary><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<string> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<string> ServiceSchemesInternal { get; set; } = new List<string>();
        /// <summary><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string TypeNameGenerator { get; internal set; }
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        /// <summary><p>Specifies the output schema type (Swagger2|OpenApi3, default: Swagger2).</p></summary>
        public virtual SchemaType OutputType { get; internal set; }
        /// <summary><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        public virtual IReadOnlyList<string> Assembly => AssemblyInternal.AsReadOnly();
        internal List<string> AssemblyInternal { get; set; } = new List<string>();
        /// <summary><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        public virtual string AssemblyConfig { get; internal set; }
        /// <summary><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        public virtual IReadOnlyList<string> ReferencePaths => ReferencePathsInternal.AsReadOnly();
        internal List<string> ReferencePathsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("aspnetcore2swagger")
              .Add("/Configuration:{value}", Configuration)
              .Add("/MSBuildProjectExtensionsPath:{value}", MSBuildProjectExtensionsPath)
              .Add("/NoBuild:{value}", NoBuild)
              .Add("/Project:{value}", Project)
              .Add("/Runtime:{value}", Runtime)
              .Add("/TargetFramework:{value}", TargetFramework)
              .Add("/Verbose:{value}", Verbose)
              .Add("{value}", GetNSwagRuntime(), customValue: true)
              .Add("/AllowReferencesWithProperties:{value}", AllowReferencesWithProperties)
              .Add("/ContractResolver:{value}", ContractResolver)
              .Add("/DefaultEnumHandling:{value}", DefaultEnumHandling)
              .Add("/DefaultPropertyNameHandling:{value}", DefaultPropertyNameHandling)
              .Add("/DefaultReferenceTypeNullHandling:{value}", DefaultReferenceTypeNullHandling)
              .Add("/DocumentProcessors:{value}", DocumentProcessors)
              .Add("/DocumentTemplate:{value}", DocumentTemplate)
              .Add("/ExcludedTypeNames:{value}", ExcludedTypeNames)
              .Add("/FlattenInheritanceHierarchy:{value}", FlattenInheritanceHierarchy)
              .Add("/GenerateAbstractProperties:{value}", GenerateAbstractProperties)
              .Add("/GenerateKnownTypes:{value}", GenerateKnownTypes)
              .Add("/GenerateXmlObjects:{value}", GenerateXmlObjects)
              .Add("/IgnoreObsoleteProperties:{value}", IgnoreObsoleteProperties)
              .Add("/InfoDescription:{value}", InfoDescription)
              .Add("/InfoTitle:{value}", InfoTitle)
              .Add("/InfoVersion:{value}", InfoVersion)
              .Add("/OperationProcessors:{value}", OperationProcessors)
              .Add("/SchemaNameGenerator:{value}", SchemaNameGenerator)
              .Add("/ServiceBasePath:{value}", ServiceBasePath)
              .Add("/ServiceHost:{value}", ServiceHost)
              .Add("/ServiceSchemes:{value}", ServiceSchemes)
              .Add("/TypeNameGenerator:{value}", TypeNameGenerator)
              .Add("/Output:{value}", Output)
              .Add("/OutputType:{value}", OutputType)
              .Add("/Assembly:{value}", Assembly)
              .Add("/AssemblyConfig:{value}", AssemblyConfig)
              .Add("/ReferencePaths:{value}", ReferencePaths);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagCreateDocumentSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagCreateDocumentSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("new")
              .Add("{value}", GetNSwagRuntime(), customValue: true);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagExecuteDocumentSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagExecuteDocumentSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public virtual string Input { get; internal set; }
        public virtual IReadOnlyDictionary<string, object> Variables => VariablesInternal.AsReadOnly();
        internal Dictionary<string,object> VariablesInternal { get; set; } = new Dictionary<string,object>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("run")
              .Add("/Input:{value}", Input)
              .Add("/Variables:{value}", Variables, "{key}={value}")
              .Add("{value}", GetNSwagRuntime(), customValue: true);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagJsonSchemaToCSharpSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagJsonSchemaToCSharpSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        /// <summary><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        public virtual string ArrayType { get; internal set; }
        /// <summary><p>The date time .NET type (default: 'DateTime').</p></summary>
        public virtual string DateTimeType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        public virtual string DictionaryType { get; internal set; }
        /// <summary><p>The class name of the root schema.</p></summary>
        public virtual string Name { get; internal set; }
        /// <summary><p>The namespace of the generated classes.</p></summary>
        public virtual string Namespace { get; internal set; }
        /// <summary><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        public virtual bool? RequiredPropertiesMustBeDefined { get; internal set; }
        /// <summary><p>A file path or URL to the data or the JSON data itself.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<string> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<string> ServiceSchemesInternal { get; set; } = new List<string>();
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("jsonschema2csclient")
              .Add("/ArrayType:{value}", ArrayType)
              .Add("/DateTimeType:{value}", DateTimeType)
              .Add("/DictionaryType:{value}", DictionaryType)
              .Add("/Name:{value}", Name)
              .Add("/Namespace:{value}", Namespace)
              .Add("/RequiredPropertiesMustBeDefined:{value}", RequiredPropertiesMustBeDefined)
              .Add("{value}", GetNSwagRuntime(), customValue: true)
              .Add("/Input:{value}", Input)
              .Add("/ServiceHost:{value}", ServiceHost)
              .Add("/ServiceSchemes:{value}", ServiceSchemes)
              .Add("/Output:{value}", Output);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagJsonSchemaToTypeScriptSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagJsonSchemaToTypeScriptSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        /// <summary><p>The type name of the root schema.</p></summary>
        public virtual string Name { get; internal set; }
        /// <summary><p>A file path or URL to the data or the JSON data itself.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<string> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<string> ServiceSchemesInternal { get; set; } = new List<string>();
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("jsonschema2tsclient")
              .Add("/Name:{value}", Name)
              .Add("{value}", GetNSwagRuntime(), customValue: true)
              .Add("/Input:{value}", Input)
              .Add("/ServiceHost:{value}", ServiceHost)
              .Add("/ServiceSchemes:{value}", ServiceSchemes)
              .Add("/Output:{value}", Output);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagSwaggerToCSharpClientSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagSwaggerToCSharpClientSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        /// <summary><p>The client base class (empty for no base class).</p></summary>
        public virtual string ClientBaseClass { get; internal set; }
        /// <summary><p>The client class access modifier (default: public).</p></summary>
        public virtual string ClientClassAccessModifier { get; internal set; }
        /// <summary><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        public virtual string ConfigurationClass { get; internal set; }
        /// <summary><p>The contracts .NET namespace.</p></summary>
        public virtual string ContractsNamespace { get; internal set; }
        /// <summary><p>The contracts output file path (optional, if no path is set then a single file with the implementation and contracts is generated).</p></summary>
        public virtual string ContractsOutput { get; internal set; }
        /// <summary><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        public virtual bool? DisposeHttpClient { get; internal set; }
        /// <summary><p>The exception class (default 'SwaggerException', may use '{controller}' placeholder).</p></summary>
        public virtual string ExceptionClass { get; internal set; }
        /// <summary><p>Specifies whether to expose the JsonSerializerSettings property (default: false).</p></summary>
        public virtual bool? ExposeJsonSerializerSettings { get; internal set; }
        /// <summary><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        public virtual bool? GenerateBaseUrlProperty { get; internal set; }
        /// <summary><p>Specifies whether generate client classes.</p></summary>
        public virtual bool? GenerateClientClasses { get; internal set; }
        /// <summary><p>Specifies whether generate interfaces for the client classes.</p></summary>
        public virtual bool? GenerateClientInterfaces { get; internal set; }
        /// <summary><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        public virtual bool? GenerateContractsOutput { get; internal set; }
        /// <summary><p>Specifies whether to generate DTO classes.</p></summary>
        public virtual bool? GenerateDtoTypes { get; internal set; }
        /// <summary><p>Specifies whether to generate exception classes (default: true).</p></summary>
        public virtual bool? GenerateExceptionClasses { get; internal set; }
        /// <summary><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        public virtual bool? GenerateSyncMethods { get; internal set; }
        /// <summary><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        public virtual bool? GenerateUpdateJsonSerializerSettingsMethod { get; internal set; }
        /// <summary><p>Specifies the HttpClient type. By default the 'System.Net.Http.HttpClient' is used.</p></summary>
        public virtual string HttpClientType { get; internal set; }
        /// <summary><p>Specifies whether an HttpClient instance is injected.</p></summary>
        public virtual bool? InjectHttpClient { get; internal set; }
        /// <summary><p>Specifies the format for DateTime type method parameters (default: s).</p></summary>
        public virtual string ParameterDateTimeFormat { get; internal set; }
        /// <summary><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        public virtual IReadOnlyList<string> ProtectedMethods => ProtectedMethodsInternal.AsReadOnly();
        internal List<string> ProtectedMethodsInternal { get; set; } = new List<string>();
        /// <summary><p>The null value used for query parameters which are null (default: '').</p></summary>
        public virtual string QueryNullValue { get; internal set; }
        /// <summary><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        public virtual bool? SerializeTypeInformation { get; internal set; }
        /// <summary><p>The DTO class/enum access modifier (default: public).</p></summary>
        public virtual string TypeAccessModifier { get; internal set; }
        /// <summary><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        public virtual bool? UseBaseUrl { get; internal set; }
        /// <summary><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        public virtual bool? UseHttpClientCreationMethod { get; internal set; }
        /// <summary><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        public virtual bool? UseHttpRequestMessageCreationMethod { get; internal set; }
        /// <summary><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        public virtual bool? WrapDtoExceptions { get; internal set; }
        /// <summary><p>The additional contract namespace usages.</p></summary>
        public virtual IReadOnlyList<string> AdditionalContractNamespaceUsages => AdditionalContractNamespaceUsagesInternal.AsReadOnly();
        internal List<string> AdditionalContractNamespaceUsagesInternal { get; set; } = new List<string>();
        /// <summary><p>The additional namespace usages.</p></summary>
        public virtual IReadOnlyList<string> AdditionalNamespaceUsages => AdditionalNamespaceUsagesInternal.AsReadOnly();
        internal List<string> AdditionalNamespaceUsagesInternal { get; set; } = new List<string>();
        /// <summary><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        public virtual string ArrayBaseType { get; internal set; }
        /// <summary><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        public virtual string ArrayType { get; internal set; }
        /// <summary><p>The class name of the generated client.</p></summary>
        public virtual string ClassName { get; internal set; }
        /// <summary><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        public virtual CSharpClassStyle ClassStyle { get; internal set; }
        /// <summary><p>The date time .NET type (default: 'DateTime').</p></summary>
        public virtual string DateTimeType { get; internal set; }
        /// <summary><p>The date .NET type (default: 'DateTime').</p></summary>
        public virtual string DateType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        public virtual string DictionaryBaseType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        public virtual string DictionaryType { get; internal set; }
        /// <summary><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        public virtual IReadOnlyList<string> ExcludedTypeNames => ExcludedTypeNamesInternal.AsReadOnly();
        internal List<string> ExcludedTypeNamesInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        public virtual bool? GenerateDataAnnotations { get; internal set; }
        /// <summary><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        public virtual bool? GenerateDefaultValues { get; internal set; }
        /// <summary><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        public virtual bool? GenerateImmutableArrayProperties { get; internal set; }
        /// <summary><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        public virtual bool? GenerateImmutableDictionaryProperties { get; internal set; }
        /// <summary><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        public virtual bool? GenerateJsonMethods { get; internal set; }
        /// <summary><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        public virtual bool? GenerateOptionalParameters { get; internal set; }
        /// <summary><p>Specifies whether to generate response classes (default: true).</p></summary>
        public virtual bool? GenerateResponseClasses { get; internal set; }
        /// <summary><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        public virtual bool? HandleReferences { get; internal set; }
        /// <summary><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        public virtual IReadOnlyList<string> JsonConverters => JsonConvertersInternal.AsReadOnly();
        internal List<string> JsonConvertersInternal { get; set; } = new List<string>();
        /// <summary><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        public virtual string JsonSerializerSettingsTransformationMethod { get; internal set; }
        /// <summary><p>The namespace of the generated classes.</p></summary>
        public virtual string Namespace { get; internal set; }
        /// <summary><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        public virtual OperationGenerationMode OperationGenerationMode { get; internal set; }
        /// <summary><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        public virtual string ParameterArrayType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        public virtual string ParameterDictionaryType { get; internal set; }
        /// <summary><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        public virtual bool? RequiredPropertiesMustBeDefined { get; internal set; }
        /// <summary><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        public virtual string ResponseArrayType { get; internal set; }
        /// <summary><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        public virtual string ResponseClass { get; internal set; }
        /// <summary><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        public virtual string ResponseDictionaryType { get; internal set; }
        /// <summary><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        public virtual string TimeSpanType { get; internal set; }
        /// <summary><p>The time .NET type (default: 'TimeSpan').</p></summary>
        public virtual string TimeType { get; internal set; }
        /// <summary><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        public virtual IReadOnlyList<string> WrapResponseMethods => WrapResponseMethodsInternal.AsReadOnly();
        internal List<string> WrapResponseMethodsInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        public virtual bool? WrapResponses { get; internal set; }
        /// <summary><p>The custom IEnumNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string EnumNameGeneratorType { get; internal set; }
        /// <summary><p>The custom IPropertyNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string PropertyNameGeneratorType { get; internal set; }
        /// <summary><p>The Liquid template directory (experimental).</p></summary>
        public virtual string TemplateDirectory { get; internal set; }
        /// <summary><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string TypeNameGenerator { get; internal set; }
        /// <summary><p>A file path or URL to the data or the JSON data itself.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<string> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<string> ServiceSchemesInternal { get; set; } = new List<string>();
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("swagger2csclient")
              .Add("/ClientBaseClass:{value}", ClientBaseClass)
              .Add("/ClientClassAccessModifier:{value}", ClientClassAccessModifier)
              .Add("/ConfigurationClass:{value}", ConfigurationClass)
              .Add("/ContractsNamespace:{value}", ContractsNamespace)
              .Add("/ContractsOutput:{value}", ContractsOutput)
              .Add("/DisposeHttpClient:{value}", DisposeHttpClient)
              .Add("/ExceptionClass:{value}", ExceptionClass)
              .Add("/ExposeJsonSerializerSettings:{value}", ExposeJsonSerializerSettings)
              .Add("/GenerateBaseUrlProperty:{value}", GenerateBaseUrlProperty)
              .Add("/GenerateClientClasses:{value}", GenerateClientClasses)
              .Add("/GenerateClientInterfaces:{value}", GenerateClientInterfaces)
              .Add("/GenerateContractsOutput:{value}", GenerateContractsOutput)
              .Add("/GenerateDtoTypes:{value}", GenerateDtoTypes)
              .Add("/GenerateExceptionClasses:{value}", GenerateExceptionClasses)
              .Add("/GenerateSyncMethods:{value}", GenerateSyncMethods)
              .Add("/GenerateUpdateJsonSerializerSettingsMethod:{value}", GenerateUpdateJsonSerializerSettingsMethod)
              .Add("/HttpClientType:{value}", HttpClientType)
              .Add("/InjectHttpClient:{value}", InjectHttpClient)
              .Add("/ParameterDateTimeFormat:{value}", ParameterDateTimeFormat)
              .Add("/ProtectedMethods:{value}", ProtectedMethods)
              .Add("/QueryNullValue:{value}", QueryNullValue)
              .Add("/SerializeTypeInformation:{value}", SerializeTypeInformation)
              .Add("/TypeAccessModifier:{value}", TypeAccessModifier)
              .Add("/UseBaseUrl:{value}", UseBaseUrl)
              .Add("/UseHttpClientCreationMethod:{value}", UseHttpClientCreationMethod)
              .Add("/UseHttpRequestMessageCreationMethod:{value}", UseHttpRequestMessageCreationMethod)
              .Add("/WrapDtoExceptions:{value}", WrapDtoExceptions)
              .Add("{value}", GetNSwagRuntime(), customValue: true)
              .Add("/AdditionalContractNamespaceUsages:{value}", AdditionalContractNamespaceUsages)
              .Add("/AdditionalNamespaceUsages:{value}", AdditionalNamespaceUsages)
              .Add("/ArrayBaseType:{value}", ArrayBaseType)
              .Add("/ArrayType:{value}", ArrayType)
              .Add("/ClassName:{value}", ClassName)
              .Add("/ClassStyle:{value}", ClassStyle)
              .Add("/DateTimeType:{value}", DateTimeType)
              .Add("/DateType:{value}", DateType)
              .Add("/DictionaryBaseType:{value}", DictionaryBaseType)
              .Add("/DictionaryType:{value}", DictionaryType)
              .Add("/ExcludedTypeNames:{value}", ExcludedTypeNames)
              .Add("/GenerateDataAnnotations:{value}", GenerateDataAnnotations)
              .Add("/GenerateDefaultValues:{value}", GenerateDefaultValues)
              .Add("/GenerateImmutableArrayProperties:{value}", GenerateImmutableArrayProperties)
              .Add("/GenerateImmutableDictionaryProperties:{value}", GenerateImmutableDictionaryProperties)
              .Add("/GenerateJsonMethods:{value}", GenerateJsonMethods)
              .Add("/GenerateOptionalParameters:{value}", GenerateOptionalParameters)
              .Add("/GenerateResponseClasses:{value}", GenerateResponseClasses)
              .Add("/HandleReferences:{value}", HandleReferences)
              .Add("/JsonConverters:{value}", JsonConverters)
              .Add("/JsonSerializerSettingsTransformationMethod:{value}", JsonSerializerSettingsTransformationMethod)
              .Add("/Namespace:{value}", Namespace)
              .Add("/OperationGenerationMode:{value}", OperationGenerationMode)
              .Add("/ParameterArrayType:{value}", ParameterArrayType)
              .Add("/ParameterDictionaryType:{value}", ParameterDictionaryType)
              .Add("/RequiredPropertiesMustBeDefined:{value}", RequiredPropertiesMustBeDefined)
              .Add("/ResponseArrayType:{value}", ResponseArrayType)
              .Add("/ResponseClass:{value}", ResponseClass)
              .Add("/ResponseDictionaryType:{value}", ResponseDictionaryType)
              .Add("/TimeSpanType:{value}", TimeSpanType)
              .Add("/TimeType:{value}", TimeType)
              .Add("/WrapResponseMethods:{value}", WrapResponseMethods)
              .Add("/WrapResponses:{value}", WrapResponses)
              .Add("/EnumNameGeneratorType:{value}", EnumNameGeneratorType)
              .Add("/PropertyNameGeneratorType:{value}", PropertyNameGeneratorType)
              .Add("/TemplateDirectory:{value}", TemplateDirectory)
              .Add("/TypeNameGenerator:{value}", TypeNameGenerator)
              .Add("/Input:{value}", Input)
              .Add("/ServiceHost:{value}", ServiceHost)
              .Add("/ServiceSchemes:{value}", ServiceSchemes)
              .Add("/Output:{value}", Output);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagSwaggerToCSharpControllerSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagSwaggerToCSharpControllerSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        /// <summary><p>The ASP.NET (Core) framework namespace (default: 'System.Web.Http').</p></summary>
        public virtual string AspNetNamespace { get; internal set; }
        /// <summary><p>The controller base class (empty for 'ApiController').</p></summary>
        public virtual string ControllerBaseClass { get; internal set; }
        /// <summary><p>The controller generation style (partial, abstract; default: partial).</p></summary>
        public virtual CSharpControllerStyle ControllerStyle { get; internal set; }
        /// <summary><p>Add a cancellation token parameter (default: false).</p></summary>
        public virtual bool? UseCancellationToken { get; internal set; }
        /// <summary><p>The additional contract namespace usages.</p></summary>
        public virtual IReadOnlyList<string> AdditionalContractNamespaceUsages => AdditionalContractNamespaceUsagesInternal.AsReadOnly();
        internal List<string> AdditionalContractNamespaceUsagesInternal { get; set; } = new List<string>();
        /// <summary><p>The additional namespace usages.</p></summary>
        public virtual IReadOnlyList<string> AdditionalNamespaceUsages => AdditionalNamespaceUsagesInternal.AsReadOnly();
        internal List<string> AdditionalNamespaceUsagesInternal { get; set; } = new List<string>();
        /// <summary><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        public virtual string ArrayBaseType { get; internal set; }
        /// <summary><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        public virtual string ArrayType { get; internal set; }
        /// <summary><p>The class name of the generated client.</p></summary>
        public virtual string ClassName { get; internal set; }
        /// <summary><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        public virtual CSharpClassStyle ClassStyle { get; internal set; }
        /// <summary><p>The date time .NET type (default: 'DateTime').</p></summary>
        public virtual string DateTimeType { get; internal set; }
        /// <summary><p>The date .NET type (default: 'DateTime').</p></summary>
        public virtual string DateType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        public virtual string DictionaryBaseType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        public virtual string DictionaryType { get; internal set; }
        /// <summary><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        public virtual IReadOnlyList<string> ExcludedTypeNames => ExcludedTypeNamesInternal.AsReadOnly();
        internal List<string> ExcludedTypeNamesInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        public virtual bool? GenerateDataAnnotations { get; internal set; }
        /// <summary><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        public virtual bool? GenerateDefaultValues { get; internal set; }
        /// <summary><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        public virtual bool? GenerateImmutableArrayProperties { get; internal set; }
        /// <summary><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        public virtual bool? GenerateImmutableDictionaryProperties { get; internal set; }
        /// <summary><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        public virtual bool? GenerateJsonMethods { get; internal set; }
        /// <summary><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        public virtual bool? GenerateOptionalParameters { get; internal set; }
        /// <summary><p>Specifies whether to generate response classes (default: true).</p></summary>
        public virtual bool? GenerateResponseClasses { get; internal set; }
        /// <summary><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        public virtual bool? HandleReferences { get; internal set; }
        /// <summary><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        public virtual IReadOnlyList<string> JsonConverters => JsonConvertersInternal.AsReadOnly();
        internal List<string> JsonConvertersInternal { get; set; } = new List<string>();
        /// <summary><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        public virtual string JsonSerializerSettingsTransformationMethod { get; internal set; }
        /// <summary><p>The namespace of the generated classes.</p></summary>
        public virtual string Namespace { get; internal set; }
        /// <summary><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        public virtual OperationGenerationMode OperationGenerationMode { get; internal set; }
        /// <summary><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        public virtual string ParameterArrayType { get; internal set; }
        /// <summary><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        public virtual string ParameterDictionaryType { get; internal set; }
        /// <summary><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        public virtual bool? RequiredPropertiesMustBeDefined { get; internal set; }
        /// <summary><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        public virtual string ResponseArrayType { get; internal set; }
        /// <summary><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        public virtual string ResponseClass { get; internal set; }
        /// <summary><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        public virtual string ResponseDictionaryType { get; internal set; }
        /// <summary><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        public virtual string TimeSpanType { get; internal set; }
        /// <summary><p>The time .NET type (default: 'TimeSpan').</p></summary>
        public virtual string TimeType { get; internal set; }
        /// <summary><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        public virtual IReadOnlyList<string> WrapResponseMethods => WrapResponseMethodsInternal.AsReadOnly();
        internal List<string> WrapResponseMethodsInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        public virtual bool? WrapResponses { get; internal set; }
        /// <summary><p>The custom IEnumNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string EnumNameGeneratorType { get; internal set; }
        /// <summary><p>The custom IPropertyNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string PropertyNameGeneratorType { get; internal set; }
        /// <summary><p>The Liquid template directory (experimental).</p></summary>
        public virtual string TemplateDirectory { get; internal set; }
        /// <summary><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string TypeNameGenerator { get; internal set; }
        /// <summary><p>A file path or URL to the data or the JSON data itself.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<string> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<string> ServiceSchemesInternal { get; set; } = new List<string>();
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("swagger2cscontroller")
              .Add("/AspNetNamespace:{value}", AspNetNamespace)
              .Add("/ControllerBaseClass:{value}", ControllerBaseClass)
              .Add("/ControllerStyle:{value}", ControllerStyle)
              .Add("/UseCancellationToken:{value}", UseCancellationToken)
              .Add("{value}", GetNSwagRuntime(), customValue: true)
              .Add("/AdditionalContractNamespaceUsages:{value}", AdditionalContractNamespaceUsages)
              .Add("/AdditionalNamespaceUsages:{value}", AdditionalNamespaceUsages)
              .Add("/ArrayBaseType:{value}", ArrayBaseType)
              .Add("/ArrayType:{value}", ArrayType)
              .Add("/ClassName:{value}", ClassName)
              .Add("/ClassStyle:{value}", ClassStyle)
              .Add("/DateTimeType:{value}", DateTimeType)
              .Add("/DateType:{value}", DateType)
              .Add("/DictionaryBaseType:{value}", DictionaryBaseType)
              .Add("/DictionaryType:{value}", DictionaryType)
              .Add("/ExcludedTypeNames:{value}", ExcludedTypeNames)
              .Add("/GenerateDataAnnotations:{value}", GenerateDataAnnotations)
              .Add("/GenerateDefaultValues:{value}", GenerateDefaultValues)
              .Add("/GenerateImmutableArrayProperties:{value}", GenerateImmutableArrayProperties)
              .Add("/GenerateImmutableDictionaryProperties:{value}", GenerateImmutableDictionaryProperties)
              .Add("/GenerateJsonMethods:{value}", GenerateJsonMethods)
              .Add("/GenerateOptionalParameters:{value}", GenerateOptionalParameters)
              .Add("/GenerateResponseClasses:{value}", GenerateResponseClasses)
              .Add("/HandleReferences:{value}", HandleReferences)
              .Add("/JsonConverters:{value}", JsonConverters)
              .Add("/JsonSerializerSettingsTransformationMethod:{value}", JsonSerializerSettingsTransformationMethod)
              .Add("/Namespace:{value}", Namespace)
              .Add("/OperationGenerationMode:{value}", OperationGenerationMode)
              .Add("/ParameterArrayType:{value}", ParameterArrayType)
              .Add("/ParameterDictionaryType:{value}", ParameterDictionaryType)
              .Add("/RequiredPropertiesMustBeDefined:{value}", RequiredPropertiesMustBeDefined)
              .Add("/ResponseArrayType:{value}", ResponseArrayType)
              .Add("/ResponseClass:{value}", ResponseClass)
              .Add("/ResponseDictionaryType:{value}", ResponseDictionaryType)
              .Add("/TimeSpanType:{value}", TimeSpanType)
              .Add("/TimeType:{value}", TimeType)
              .Add("/WrapResponseMethods:{value}", WrapResponseMethods)
              .Add("/WrapResponses:{value}", WrapResponses)
              .Add("/EnumNameGeneratorType:{value}", EnumNameGeneratorType)
              .Add("/PropertyNameGeneratorType:{value}", PropertyNameGeneratorType)
              .Add("/TemplateDirectory:{value}", TemplateDirectory)
              .Add("/TypeNameGenerator:{value}", TypeNameGenerator)
              .Add("/Input:{value}", Input)
              .Add("/ServiceHost:{value}", ServiceHost)
              .Add("/ServiceSchemes:{value}", ServiceSchemes)
              .Add("/Output:{value}", Output);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NSwagSwaggerToTypeScriptClientSettings
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NSwagSwaggerToTypeScriptClientSettings : NSwagSettings
    {
        /// <summary><p>Path to the NSwag executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        /// <summary><p>The token name for injecting the API base URL string (used in the Angular template, default: 'API_BASE_URL').</p></summary>
        public virtual string BaseUrlTokenName { get; internal set; }
        /// <summary><p>The class name of the generated client.</p></summary>
        public virtual string ClassName { get; internal set; }
        /// <summary><p>The type names which always generate plain TypeScript classes.</p></summary>
        public virtual IReadOnlyList<string> ClassTypes => ClassTypesInternal.AsReadOnly();
        internal List<string> ClassTypesInternal { get; set; } = new List<string>();
        /// <summary><p>The base class of the generated client classes (optional, must be imported or implemented in the extension code).</p></summary>
        public virtual string ClientBaseClass { get; internal set; }
        /// <summary><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        public virtual string ConfigurationClass { get; internal set; }
        /// <summary><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        public virtual bool? ConvertConstructorInterfaceData { get; internal set; }
        /// <summary><p>The date time type ('Date', 'MomentJS', 'OffsetMomentJS', 'string').</p></summary>
        public virtual TypeScriptDateTimeType DateTimeType { get; internal set; }
        /// <summary><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        public virtual IReadOnlyList<string> ExcludedTypeNames => ExcludedTypeNamesInternal.AsReadOnly();
        internal List<string> ExcludedTypeNamesInternal { get; set; } = new List<string>();
        /// <summary><p>The list of extended classes.</p></summary>
        public virtual IReadOnlyList<string> ExtendedClasses => ExtendedClassesInternal.AsReadOnly();
        internal List<string> ExtendedClassesInternal { get; set; } = new List<string>();
        /// <summary><p>The extension code (string or file path).</p></summary>
        public virtual string ExtensionCode { get; internal set; }
        /// <summary><p>Specifies whether generate client classes.</p></summary>
        public virtual bool? GenerateClientClasses { get; internal set; }
        /// <summary><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        public virtual bool? GenerateClientInterfaces { get; internal set; }
        /// <summary><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        public virtual bool? GenerateCloneMethod { get; internal set; }
        /// <summary><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        public virtual bool? GenerateConstructorInterface { get; internal set; }
        /// <summary><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        public virtual bool? GenerateDefaultValues { get; internal set; }
        /// <summary><p>Specifies whether to generate DTO classes.</p></summary>
        public virtual bool? GenerateDtoTypes { get; internal set; }
        /// <summary><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        public virtual bool? GenerateOptionalParameters { get; internal set; }
        /// <summary><p>Specifies whether to generate response classes (default: true).</p></summary>
        public virtual bool? GenerateResponseClasses { get; internal set; }
        /// <summary><p>Handle JSON references (default: false).</p></summary>
        public virtual bool? HandleReferences { get; internal set; }
        /// <summary><p>The Angular HTTP service class (default 'Http', 'HttpClient').</p></summary>
        public virtual HttpClass HttpClass { get; internal set; }
        /// <summary><p>Specifies whether required types should be imported (default: true).</p></summary>
        public virtual bool? ImportRequiredTypes { get; internal set; }
        /// <summary><p>The Angular injection token type (default 'OpaqueToken', 'InjectionToken').</p></summary>
        public virtual InjectionTokenType InjectionTokenType { get; internal set; }
        /// <summary><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        public virtual bool? MarkOptionalProperties { get; internal set; }
        /// <summary><p>The TypeScript module name (default: '', no module).</p></summary>
        public virtual string ModuleName { get; internal set; }
        /// <summary><p>The TypeScript namespace (default: '', no namespace).</p></summary>
        public virtual string Namespace { get; internal set; }
        /// <summary><p>The null value used in object initializers (default 'Undefined', 'Null').</p></summary>
        public virtual TypeScriptNullValue NullValue { get; internal set; }
        /// <summary><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        public virtual OperationGenerationMode OperationGenerationMode { get; internal set; }
        /// <summary><p>The promise type ('Promise' or 'QPromise').</p></summary>
        public virtual PromiseType PromiseType { get; internal set; }
        /// <summary><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        public virtual IReadOnlyList<string> ProtectedMethods => ProtectedMethodsInternal.AsReadOnly();
        internal List<string> ProtectedMethodsInternal { get; set; } = new List<string>();
        /// <summary><p>The null value used for query parameters which are null (default: '').</p></summary>
        public virtual string QueryNullValue { get; internal set; }
        /// <summary><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        public virtual string ResponseClass { get; internal set; }
        /// <summary><p>The target RxJs version (default: 5.0).</p></summary>
        public virtual decimal? RxJsVersion { get; internal set; }
        /// <summary><p>The type of the asynchronism handling ('JQueryCallbacks', 'JQueryPromises', 'AngularJS', 'Angular', 'Fetch', 'Aurelia').</p></summary>
        public virtual TypeScriptTemplate Template { get; internal set; }
        /// <summary><p>The target TypeScript version (default: 1.8).</p></summary>
        public virtual decimal? TypeScriptVersion { get; internal set; }
        /// <summary><p>The type style (default: Class).</p></summary>
        public virtual TypeScriptTypeStyle TypeStyle { get; internal set; }
        /// <summary><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        public virtual bool? UseGetBaseUrlMethod { get; internal set; }
        /// <summary><p>Specifies whether to use the Angular 6 Singleton Provider (Angular template only, default: false).</p></summary>
        public virtual bool? UseSingletonProvider { get; internal set; }
        /// <summary><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        public virtual bool? UseTransformOptionsMethod { get; internal set; }
        /// <summary><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        public virtual bool? UseTransformResultMethod { get; internal set; }
        /// <summary><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        public virtual bool? WrapDtoExceptions { get; internal set; }
        /// <summary><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        public virtual IReadOnlyList<string> WrapResponseMethods => WrapResponseMethodsInternal.AsReadOnly();
        internal List<string> WrapResponseMethodsInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        public virtual bool? WrapResponses { get; internal set; }
        /// <summary><p>The custom IEnumNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string EnumNameGeneratorType { get; internal set; }
        /// <summary><p>The custom IPropertyNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string PropertyNameGeneratorType { get; internal set; }
        /// <summary><p>The Liquid template directory (experimental).</p></summary>
        public virtual string TemplateDirectory { get; internal set; }
        /// <summary><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        public virtual string TypeNameGenerator { get; internal set; }
        /// <summary><p>A file path or URL to the data or the JSON data itself.</p></summary>
        public virtual string Input { get; internal set; }
        /// <summary><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        public virtual string ServiceHost { get; internal set; }
        /// <summary><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        public virtual IReadOnlyList<string> ServiceSchemes => ServiceSchemesInternal.AsReadOnly();
        internal List<string> ServiceSchemesInternal { get; set; } = new List<string>();
        /// <summary><p>The output file path (optional).</p></summary>
        public virtual string Output { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("swagger2tsclient")
              .Add("/BaseUrlTokenName:{value}", BaseUrlTokenName)
              .Add("/ClassName:{value}", ClassName)
              .Add("/ClassTypes:{value}", ClassTypes)
              .Add("/ClientBaseClass:{value}", ClientBaseClass)
              .Add("/ConfigurationClass:{value}", ConfigurationClass)
              .Add("/ConvertConstructorInterfaceData:{value}", ConvertConstructorInterfaceData)
              .Add("/DateTimeType:{value}", DateTimeType)
              .Add("/ExcludedTypeNames:{value}", ExcludedTypeNames)
              .Add("/ExtendedClasses:{value}", ExtendedClasses)
              .Add("/ExtensionCode:{value}", ExtensionCode)
              .Add("/GenerateClientClasses:{value}", GenerateClientClasses)
              .Add("/GenerateClientInterfaces:{value}", GenerateClientInterfaces)
              .Add("/GenerateCloneMethod:{value}", GenerateCloneMethod)
              .Add("/GenerateConstructorInterface:{value}", GenerateConstructorInterface)
              .Add("/GenerateDefaultValues:{value}", GenerateDefaultValues)
              .Add("/GenerateDtoTypes:{value}", GenerateDtoTypes)
              .Add("/GenerateOptionalParameters:{value}", GenerateOptionalParameters)
              .Add("/GenerateResponseClasses:{value}", GenerateResponseClasses)
              .Add("/HandleReferences:{value}", HandleReferences)
              .Add("/HttpClass:{value}", HttpClass)
              .Add("/ImportRequiredTypes:{value}", ImportRequiredTypes)
              .Add("/InjectionTokenType:{value}", InjectionTokenType)
              .Add("/MarkOptionalProperties:{value}", MarkOptionalProperties)
              .Add("/ModuleName:{value}", ModuleName)
              .Add("/Namespace:{value}", Namespace)
              .Add("/NullValue:{value}", NullValue)
              .Add("/OperationGenerationMode:{value}", OperationGenerationMode)
              .Add("/PromiseType:{value}", PromiseType)
              .Add("/ProtectedMethods:{value}", ProtectedMethods)
              .Add("/QueryNullValue:{value}", QueryNullValue)
              .Add("/ResponseClass:{value}", ResponseClass)
              .Add("/RxJsVersion:{value}", RxJsVersion)
              .Add("/Template:{value}", Template)
              .Add("/TypeScriptVersion:{value}", TypeScriptVersion)
              .Add("/TypeStyle:{value}", TypeStyle)
              .Add("/UseGetBaseUrlMethod:{value}", UseGetBaseUrlMethod)
              .Add("/UseSingletonProvider:{value}", UseSingletonProvider)
              .Add("/UseTransformOptionsMethod:{value}", UseTransformOptionsMethod)
              .Add("/UseTransformResultMethod:{value}", UseTransformResultMethod)
              .Add("/WrapDtoExceptions:{value}", WrapDtoExceptions)
              .Add("/WrapResponseMethods:{value}", WrapResponseMethods)
              .Add("/WrapResponses:{value}", WrapResponses)
              .Add("{value}", GetNSwagRuntime(), customValue: true)
              .Add("/EnumNameGeneratorType:{value}", EnumNameGeneratorType)
              .Add("/PropertyNameGeneratorType:{value}", PropertyNameGeneratorType)
              .Add("/TemplateDirectory:{value}", TemplateDirectory)
              .Add("/TypeNameGenerator:{value}", TypeNameGenerator)
              .Add("/Input:{value}", Input)
              .Add("/ServiceHost:{value}", ServiceHost)
              .Add("/ServiceSchemes:{value}", ServiceSchemes)
              .Add("/Output:{value}", Output);
            return base.ConfigureArguments(arguments);
        }
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
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.Variables"/> to a new dictionary.</em></p></summary>
        [Pure]
        public static NSwagListTypesSettings SetVariables(this NSwagListTypesSettings toolSettings, IDictionary<string, object> variables)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal = variables.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagListTypesSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListTypesSettings ClearVariables(this NSwagListTypesSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="NSwagListTypesSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListTypesSettings AddVariable(this NSwagListTypesSettings toolSettings, string variableKey, object variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Add(variableKey, variableValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="NSwagListTypesSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListTypesSettings RemoveVariable(this NSwagListTypesSettings toolSettings, string variableKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Remove(variableKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="NSwagListTypesSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListTypesSettings SetVariable(this NSwagListTypesSettings toolSettings, string variableKey, object variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal[variableKey] = variableValue;
            return toolSettings;
        }
        #endregion
        #region Assembly
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings SetAssembly(this NSwagListTypesSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings SetAssembly(this NSwagListTypesSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListTypesSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings AddAssembly(this NSwagListTypesSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListTypesSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings AddAssembly(this NSwagListTypesSettings toolSettings, IEnumerable<string> assembly)
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
        public static NSwagListTypesSettings RemoveAssembly(this NSwagListTypesSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListTypesSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings RemoveAssembly(this NSwagListTypesSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assembly);
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
        public static NSwagListTypesSettings SetReferencePaths(this NSwagListTypesSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagListTypesSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings SetReferencePaths(this NSwagListTypesSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListTypesSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings AddReferencePaths(this NSwagListTypesSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListTypesSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings AddReferencePaths(this NSwagListTypesSettings toolSettings, IEnumerable<string> referencePaths)
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
        public static NSwagListTypesSettings RemoveReferencePaths(this NSwagListTypesSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListTypesSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListTypesSettings RemoveReferencePaths(this NSwagListTypesSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagListWebApiControllersSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagListWebApiControllersSettingsExtensions
    {
        #region File
        /// <summary><p><em>Sets <see cref="NSwagListWebApiControllersSettings.File"/>.</em></p><p>The nswag.json configuration file path.</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings SetFile(this NSwagListWebApiControllersSettings toolSettings, string file)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagListWebApiControllersSettings.File"/>.</em></p><p>The nswag.json configuration file path.</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings ResetFile(this NSwagListWebApiControllersSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary><p><em>Sets <see cref="NSwagListWebApiControllersSettings.Variables"/> to a new dictionary.</em></p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings SetVariables(this NSwagListWebApiControllersSettings toolSettings, IDictionary<string, object> variables)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal = variables.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagListWebApiControllersSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings ClearVariables(this NSwagListWebApiControllersSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="NSwagListWebApiControllersSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings AddVariable(this NSwagListWebApiControllersSettings toolSettings, string variableKey, object variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Add(variableKey, variableValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="NSwagListWebApiControllersSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings RemoveVariable(this NSwagListWebApiControllersSettings toolSettings, string variableKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Remove(variableKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="NSwagListWebApiControllersSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings SetVariable(this NSwagListWebApiControllersSettings toolSettings, string variableKey, object variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal[variableKey] = variableValue;
            return toolSettings;
        }
        #endregion
        #region Assembly
        /// <summary><p><em>Sets <see cref="NSwagListWebApiControllersSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings SetAssembly(this NSwagListWebApiControllersSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagListWebApiControllersSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings SetAssembly(this NSwagListWebApiControllersSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListWebApiControllersSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings AddAssembly(this NSwagListWebApiControllersSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListWebApiControllersSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings AddAssembly(this NSwagListWebApiControllersSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagListWebApiControllersSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings ClearAssembly(this NSwagListWebApiControllersSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListWebApiControllersSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings RemoveAssembly(this NSwagListWebApiControllersSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListWebApiControllersSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings RemoveAssembly(this NSwagListWebApiControllersSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AssemblyConfig
        /// <summary><p><em>Sets <see cref="NSwagListWebApiControllersSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings SetAssemblyConfig(this NSwagListWebApiControllersSettings toolSettings, string assemblyConfig)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = assemblyConfig;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagListWebApiControllersSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings ResetAssemblyConfig(this NSwagListWebApiControllersSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = null;
            return toolSettings;
        }
        #endregion
        #region ReferencePaths
        /// <summary><p><em>Sets <see cref="NSwagListWebApiControllersSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings SetReferencePaths(this NSwagListWebApiControllersSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagListWebApiControllersSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings SetReferencePaths(this NSwagListWebApiControllersSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListWebApiControllersSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings AddReferencePaths(this NSwagListWebApiControllersSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagListWebApiControllersSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings AddReferencePaths(this NSwagListWebApiControllersSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagListWebApiControllersSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings ClearReferencePaths(this NSwagListWebApiControllersSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListWebApiControllersSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings RemoveReferencePaths(this NSwagListWebApiControllersSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagListWebApiControllersSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagListWebApiControllersSettings RemoveReferencePaths(this NSwagListWebApiControllersSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagTypesToSwaggerSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagTypesToSwaggerSettingsExtensions
    {
        #region AllowReferencesWithProperties
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetAllowReferencesWithProperties(this NSwagTypesToSwaggerSettings toolSettings, bool? allowReferencesWithProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = allowReferencesWithProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetAllowReferencesWithProperties(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagTypesToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings EnableAllowReferencesWithProperties(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagTypesToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings DisableAllowReferencesWithProperties(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagTypesToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ToggleAllowReferencesWithProperties(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = !toolSettings.AllowReferencesWithProperties;
            return toolSettings;
        }
        #endregion
        #region ClassNames
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.ClassNames"/> to a new list.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetClassNames(this NSwagTypesToSwaggerSettings toolSettings, params string[] classNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassNamesInternal = classNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.ClassNames"/> to a new list.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetClassNames(this NSwagTypesToSwaggerSettings toolSettings, IEnumerable<string> classNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassNamesInternal = classNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypesToSwaggerSettings.ClassNames"/>.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings AddClassNames(this NSwagTypesToSwaggerSettings toolSettings, params string[] classNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassNamesInternal.AddRange(classNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypesToSwaggerSettings.ClassNames"/>.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings AddClassNames(this NSwagTypesToSwaggerSettings toolSettings, IEnumerable<string> classNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassNamesInternal.AddRange(classNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagTypesToSwaggerSettings.ClassNames"/>.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ClearClassNames(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypesToSwaggerSettings.ClassNames"/>.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings RemoveClassNames(this NSwagTypesToSwaggerSettings toolSettings, params string[] classNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(classNames);
            toolSettings.ClassNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypesToSwaggerSettings.ClassNames"/>.</em></p><p>The class names.</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings RemoveClassNames(this NSwagTypesToSwaggerSettings toolSettings, IEnumerable<string> classNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(classNames);
            toolSettings.ClassNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DefaultEnumHandling
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetDefaultEnumHandling(this NSwagTypesToSwaggerSettings toolSettings, EnumHandling defaultEnumHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = defaultEnumHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetDefaultEnumHandling(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultPropertyNameHandling
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetDefaultPropertyNameHandling(this NSwagTypesToSwaggerSettings toolSettings, PropertyNameHandling defaultPropertyNameHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = defaultPropertyNameHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetDefaultPropertyNameHandling(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultReferenceTypeNullHandling
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetDefaultReferenceTypeNullHandling(this NSwagTypesToSwaggerSettings toolSettings, ReferenceTypeNullHandling defaultReferenceTypeNullHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = defaultReferenceTypeNullHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetDefaultReferenceTypeNullHandling(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = null;
            return toolSettings;
        }
        #endregion
        #region FlattenInheritanceHierarchy
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetFlattenInheritanceHierarchy(this NSwagTypesToSwaggerSettings toolSettings, bool? flattenInheritanceHierarchy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = flattenInheritanceHierarchy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetFlattenInheritanceHierarchy(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagTypesToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings EnableFlattenInheritanceHierarchy(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagTypesToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings DisableFlattenInheritanceHierarchy(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagTypesToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ToggleFlattenInheritanceHierarchy(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = !toolSettings.FlattenInheritanceHierarchy;
            return toolSettings;
        }
        #endregion
        #region GenerateKnownTypes
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetGenerateKnownTypes(this NSwagTypesToSwaggerSettings toolSettings, bool? generateKnownTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = generateKnownTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetGenerateKnownTypes(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagTypesToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings EnableGenerateKnownTypes(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagTypesToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings DisableGenerateKnownTypes(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagTypesToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ToggleGenerateKnownTypes(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = !toolSettings.GenerateKnownTypes;
            return toolSettings;
        }
        #endregion
        #region GenerateXmlObjects
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetGenerateXmlObjects(this NSwagTypesToSwaggerSettings toolSettings, bool? generateXmlObjects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = generateXmlObjects;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetGenerateXmlObjects(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagTypesToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings EnableGenerateXmlObjects(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagTypesToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings DisableGenerateXmlObjects(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagTypesToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ToggleGenerateXmlObjects(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = !toolSettings.GenerateXmlObjects;
            return toolSettings;
        }
        #endregion
        #region IgnoreObsoleteProperties
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetIgnoreObsoleteProperties(this NSwagTypesToSwaggerSettings toolSettings, bool? ignoreObsoleteProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = ignoreObsoleteProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetIgnoreObsoleteProperties(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagTypesToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings EnableIgnoreObsoleteProperties(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagTypesToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings DisableIgnoreObsoleteProperties(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagTypesToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ToggleIgnoreObsoleteProperties(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = !toolSettings.IgnoreObsoleteProperties;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetOutput(this NSwagTypesToSwaggerSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetOutput(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region OutputType
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.OutputType"/>.</em></p><p>Specifies the output schema type (Swagger2|OpenApi3, default: Swagger2).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetOutputType(this NSwagTypesToSwaggerSettings toolSettings, SchemaType outputType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputType = outputType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.OutputType"/>.</em></p><p>Specifies the output schema type (Swagger2|OpenApi3, default: Swagger2).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetOutputType(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputType = null;
            return toolSettings;
        }
        #endregion
        #region Assembly
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetAssembly(this NSwagTypesToSwaggerSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetAssembly(this NSwagTypesToSwaggerSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypesToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings AddAssembly(this NSwagTypesToSwaggerSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypesToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings AddAssembly(this NSwagTypesToSwaggerSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagTypesToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ClearAssembly(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypesToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings RemoveAssembly(this NSwagTypesToSwaggerSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypesToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings RemoveAssembly(this NSwagTypesToSwaggerSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AssemblyConfig
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetAssemblyConfig(this NSwagTypesToSwaggerSettings toolSettings, string assemblyConfig)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = assemblyConfig;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagTypesToSwaggerSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ResetAssemblyConfig(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = null;
            return toolSettings;
        }
        #endregion
        #region ReferencePaths
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetReferencePaths(this NSwagTypesToSwaggerSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagTypesToSwaggerSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings SetReferencePaths(this NSwagTypesToSwaggerSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypesToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings AddReferencePaths(this NSwagTypesToSwaggerSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagTypesToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings AddReferencePaths(this NSwagTypesToSwaggerSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagTypesToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings ClearReferencePaths(this NSwagTypesToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypesToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings RemoveReferencePaths(this NSwagTypesToSwaggerSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagTypesToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagTypesToSwaggerSettings RemoveReferencePaths(this NSwagTypesToSwaggerSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagWebApiToSwaggerSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagWebApiToSwaggerSettingsExtensions
    {
        #region AddMissingPathParameters
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.AddMissingPathParameters"/>.</em></p><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetAddMissingPathParameters(this NSwagWebApiToSwaggerSettings toolSettings, bool? addMissingPathParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddMissingPathParameters = addMissingPathParameters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.AddMissingPathParameters"/>.</em></p><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetAddMissingPathParameters(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddMissingPathParameters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApiToSwaggerSettings.AddMissingPathParameters"/>.</em></p><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings EnableAddMissingPathParameters(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddMissingPathParameters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApiToSwaggerSettings.AddMissingPathParameters"/>.</em></p><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings DisableAddMissingPathParameters(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddMissingPathParameters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApiToSwaggerSettings.AddMissingPathParameters"/>.</em></p><p>Specifies whether to add path parameters which are missing in the action method (default: true).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ToggleAddMissingPathParameters(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddMissingPathParameters = !toolSettings.AddMissingPathParameters;
            return toolSettings;
        }
        #endregion
        #region AspNetCore
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.AspNetCore"/>.</em></p><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetAspNetCore(this NSwagWebApiToSwaggerSettings toolSettings, bool? aspNetCore)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetCore = aspNetCore;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.AspNetCore"/>.</em></p><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetAspNetCore(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetCore = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApiToSwaggerSettings.AspNetCore"/>.</em></p><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings EnableAspNetCore(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetCore = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApiToSwaggerSettings.AspNetCore"/>.</em></p><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings DisableAspNetCore(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetCore = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApiToSwaggerSettings.AspNetCore"/>.</em></p><p>Specifies whether the controllers are hosted by ASP.NET Core.</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ToggleAspNetCore(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetCore = !toolSettings.AspNetCore;
            return toolSettings;
        }
        #endregion
        #region Controller
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.Controller"/>.</em></p><p>The Web API controller full class name or empty to load all controllers from the assembly.</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetController(this NSwagWebApiToSwaggerSettings toolSettings, string controller)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Controller = controller;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.Controller"/>.</em></p><p>The Web API controller full class name or empty to load all controllers from the assembly.</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetController(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Controller = null;
            return toolSettings;
        }
        #endregion
        #region Controllers
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.Controllers"/> to a new list.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetControllers(this NSwagWebApiToSwaggerSettings toolSettings, params string[] controllers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllersInternal = controllers.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.Controllers"/> to a new list.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetControllers(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> controllers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllersInternal = controllers.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.Controllers"/>.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddControllers(this NSwagWebApiToSwaggerSettings toolSettings, params string[] controllers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllersInternal.AddRange(controllers);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.Controllers"/>.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddControllers(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> controllers)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllersInternal.AddRange(controllers);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApiToSwaggerSettings.Controllers"/>.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ClearControllers(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.Controllers"/>.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveControllers(this NSwagWebApiToSwaggerSettings toolSettings, params string[] controllers)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(controllers);
            toolSettings.ControllersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.Controllers"/>.</em></p><p>The Web API controller full class names or empty to load all controllers from the assembly (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveControllers(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> controllers)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(controllers);
            toolSettings.ControllersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DefaultUrlTemplate
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.DefaultUrlTemplate"/>.</em></p><p>The Web API default URL template (default for Web API: 'api/{controller}/{id}'; for MVC projects: '{controller}/{action}/{id?}').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetDefaultUrlTemplate(this NSwagWebApiToSwaggerSettings toolSettings, string defaultUrlTemplate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultUrlTemplate = defaultUrlTemplate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.DefaultUrlTemplate"/>.</em></p><p>The Web API default URL template (default for Web API: 'api/{controller}/{id}'; for MVC projects: '{controller}/{action}/{id?}').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetDefaultUrlTemplate(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultUrlTemplate = null;
            return toolSettings;
        }
        #endregion
        #region AllowReferencesWithProperties
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetAllowReferencesWithProperties(this NSwagWebApiToSwaggerSettings toolSettings, bool? allowReferencesWithProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = allowReferencesWithProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetAllowReferencesWithProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApiToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings EnableAllowReferencesWithProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApiToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings DisableAllowReferencesWithProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApiToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ToggleAllowReferencesWithProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = !toolSettings.AllowReferencesWithProperties;
            return toolSettings;
        }
        #endregion
        #region ContractResolver
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.ContractResolver"/>.</em></p><p>The custom IContractResolver implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetContractResolver(this NSwagWebApiToSwaggerSettings toolSettings, string contractResolver)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractResolver = contractResolver;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.ContractResolver"/>.</em></p><p>The custom IContractResolver implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetContractResolver(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractResolver = null;
            return toolSettings;
        }
        #endregion
        #region DefaultEnumHandling
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetDefaultEnumHandling(this NSwagWebApiToSwaggerSettings toolSettings, EnumHandling defaultEnumHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = defaultEnumHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetDefaultEnumHandling(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultPropertyNameHandling
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetDefaultPropertyNameHandling(this NSwagWebApiToSwaggerSettings toolSettings, PropertyNameHandling defaultPropertyNameHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = defaultPropertyNameHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetDefaultPropertyNameHandling(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultReferenceTypeNullHandling
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetDefaultReferenceTypeNullHandling(this NSwagWebApiToSwaggerSettings toolSettings, ReferenceTypeNullHandling defaultReferenceTypeNullHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = defaultReferenceTypeNullHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetDefaultReferenceTypeNullHandling(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = null;
            return toolSettings;
        }
        #endregion
        #region DocumentProcessors
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.DocumentProcessors"/> to a new list.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetDocumentProcessors(this NSwagWebApiToSwaggerSettings toolSettings, params string[] documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal = documentProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.DocumentProcessors"/> to a new list.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetDocumentProcessors(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal = documentProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddDocumentProcessors(this NSwagWebApiToSwaggerSettings toolSettings, params string[] documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal.AddRange(documentProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddDocumentProcessors(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal.AddRange(documentProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApiToSwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ClearDocumentProcessors(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveDocumentProcessors(this NSwagWebApiToSwaggerSettings toolSettings, params string[] documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(documentProcessors);
            toolSettings.DocumentProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveDocumentProcessors(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(documentProcessors);
            toolSettings.DocumentProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DocumentTemplate
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.DocumentTemplate"/>.</em></p><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetDocumentTemplate(this NSwagWebApiToSwaggerSettings toolSettings, string documentTemplate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentTemplate = documentTemplate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.DocumentTemplate"/>.</em></p><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetDocumentTemplate(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentTemplate = null;
            return toolSettings;
        }
        #endregion
        #region ExcludedTypeNames
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetExcludedTypeNames(this NSwagWebApiToSwaggerSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetExcludedTypeNames(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddExcludedTypeNames(this NSwagWebApiToSwaggerSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddExcludedTypeNames(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApiToSwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ClearExcludedTypeNames(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveExcludedTypeNames(this NSwagWebApiToSwaggerSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveExcludedTypeNames(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region FlattenInheritanceHierarchy
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetFlattenInheritanceHierarchy(this NSwagWebApiToSwaggerSettings toolSettings, bool? flattenInheritanceHierarchy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = flattenInheritanceHierarchy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetFlattenInheritanceHierarchy(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApiToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings EnableFlattenInheritanceHierarchy(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApiToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings DisableFlattenInheritanceHierarchy(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApiToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ToggleFlattenInheritanceHierarchy(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = !toolSettings.FlattenInheritanceHierarchy;
            return toolSettings;
        }
        #endregion
        #region GenerateAbstractProperties
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetGenerateAbstractProperties(this NSwagWebApiToSwaggerSettings toolSettings, bool? generateAbstractProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = generateAbstractProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetGenerateAbstractProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApiToSwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings EnableGenerateAbstractProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApiToSwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings DisableGenerateAbstractProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApiToSwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ToggleGenerateAbstractProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = !toolSettings.GenerateAbstractProperties;
            return toolSettings;
        }
        #endregion
        #region GenerateKnownTypes
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetGenerateKnownTypes(this NSwagWebApiToSwaggerSettings toolSettings, bool? generateKnownTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = generateKnownTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetGenerateKnownTypes(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApiToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings EnableGenerateKnownTypes(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApiToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings DisableGenerateKnownTypes(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApiToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ToggleGenerateKnownTypes(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = !toolSettings.GenerateKnownTypes;
            return toolSettings;
        }
        #endregion
        #region GenerateXmlObjects
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetGenerateXmlObjects(this NSwagWebApiToSwaggerSettings toolSettings, bool? generateXmlObjects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = generateXmlObjects;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetGenerateXmlObjects(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApiToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings EnableGenerateXmlObjects(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApiToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings DisableGenerateXmlObjects(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApiToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ToggleGenerateXmlObjects(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = !toolSettings.GenerateXmlObjects;
            return toolSettings;
        }
        #endregion
        #region IgnoreObsoleteProperties
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetIgnoreObsoleteProperties(this NSwagWebApiToSwaggerSettings toolSettings, bool? ignoreObsoleteProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = ignoreObsoleteProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetIgnoreObsoleteProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagWebApiToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings EnableIgnoreObsoleteProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagWebApiToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings DisableIgnoreObsoleteProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagWebApiToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ToggleIgnoreObsoleteProperties(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = !toolSettings.IgnoreObsoleteProperties;
            return toolSettings;
        }
        #endregion
        #region InfoDescription
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.InfoDescription"/>.</em></p><p>Specify the description of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetInfoDescription(this NSwagWebApiToSwaggerSettings toolSettings, string infoDescription)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoDescription = infoDescription;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.InfoDescription"/>.</em></p><p>Specify the description of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetInfoDescription(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoDescription = null;
            return toolSettings;
        }
        #endregion
        #region InfoTitle
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.InfoTitle"/>.</em></p><p>Specify the title of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetInfoTitle(this NSwagWebApiToSwaggerSettings toolSettings, string infoTitle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoTitle = infoTitle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.InfoTitle"/>.</em></p><p>Specify the title of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetInfoTitle(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoTitle = null;
            return toolSettings;
        }
        #endregion
        #region InfoVersion
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.InfoVersion"/>.</em></p><p>Specify the version of the Swagger specification (default: 1.0.0, ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetInfoVersion(this NSwagWebApiToSwaggerSettings toolSettings, string infoVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoVersion = infoVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.InfoVersion"/>.</em></p><p>Specify the version of the Swagger specification (default: 1.0.0, ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetInfoVersion(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoVersion = null;
            return toolSettings;
        }
        #endregion
        #region OperationProcessors
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.OperationProcessors"/> to a new list.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetOperationProcessors(this NSwagWebApiToSwaggerSettings toolSettings, params string[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal = operationProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.OperationProcessors"/> to a new list.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetOperationProcessors(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal = operationProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddOperationProcessors(this NSwagWebApiToSwaggerSettings toolSettings, params string[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.AddRange(operationProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddOperationProcessors(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.AddRange(operationProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApiToSwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ClearOperationProcessors(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveOperationProcessors(this NSwagWebApiToSwaggerSettings toolSettings, params string[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(operationProcessors);
            toolSettings.OperationProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveOperationProcessors(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(operationProcessors);
            toolSettings.OperationProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SchemaNameGenerator
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.SchemaNameGenerator"/>.</em></p><p>The custom ISchemaNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetSchemaNameGenerator(this NSwagWebApiToSwaggerSettings toolSettings, string schemaNameGenerator)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SchemaNameGenerator = schemaNameGenerator;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.SchemaNameGenerator"/>.</em></p><p>The custom ISchemaNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetSchemaNameGenerator(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SchemaNameGenerator = null;
            return toolSettings;
        }
        #endregion
        #region ServiceBasePath
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.ServiceBasePath"/>.</em></p><p>The basePath of the Swagger specification (optional).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetServiceBasePath(this NSwagWebApiToSwaggerSettings toolSettings, string serviceBasePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceBasePath = serviceBasePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.ServiceBasePath"/>.</em></p><p>The basePath of the Swagger specification (optional).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetServiceBasePath(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceBasePath = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetServiceHost(this NSwagWebApiToSwaggerSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetServiceHost(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetServiceSchemes(this NSwagWebApiToSwaggerSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetServiceSchemes(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddServiceSchemes(this NSwagWebApiToSwaggerSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddServiceSchemes(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApiToSwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ClearServiceSchemes(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveServiceSchemes(this NSwagWebApiToSwaggerSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveServiceSchemes(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TypeNameGenerator
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetTypeNameGenerator(this NSwagWebApiToSwaggerSettings toolSettings, string typeNameGenerator)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = typeNameGenerator;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetTypeNameGenerator(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetOutput(this NSwagWebApiToSwaggerSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetOutput(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region OutputType
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.OutputType"/>.</em></p><p>Specifies the output schema type (Swagger2|OpenApi3, default: Swagger2).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetOutputType(this NSwagWebApiToSwaggerSettings toolSettings, SchemaType outputType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputType = outputType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.OutputType"/>.</em></p><p>Specifies the output schema type (Swagger2|OpenApi3, default: Swagger2).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetOutputType(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputType = null;
            return toolSettings;
        }
        #endregion
        #region Assembly
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetAssembly(this NSwagWebApiToSwaggerSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetAssembly(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddAssembly(this NSwagWebApiToSwaggerSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddAssembly(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApiToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ClearAssembly(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveAssembly(this NSwagWebApiToSwaggerSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveAssembly(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AssemblyConfig
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetAssemblyConfig(this NSwagWebApiToSwaggerSettings toolSettings, string assemblyConfig)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = assemblyConfig;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagWebApiToSwaggerSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ResetAssemblyConfig(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = null;
            return toolSettings;
        }
        #endregion
        #region ReferencePaths
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetReferencePaths(this NSwagWebApiToSwaggerSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagWebApiToSwaggerSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings SetReferencePaths(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddReferencePaths(this NSwagWebApiToSwaggerSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagWebApiToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings AddReferencePaths(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagWebApiToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings ClearReferencePaths(this NSwagWebApiToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveReferencePaths(this NSwagWebApiToSwaggerSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagWebApiToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagWebApiToSwaggerSettings RemoveReferencePaths(this NSwagWebApiToSwaggerSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagAspNetCoreToSwaggerSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagAspNetCoreToSwaggerSettingsExtensions
    {
        #region Configuration
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.Configuration"/>.</em></p><p>The configuration to use.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetConfiguration(this NSwagAspNetCoreToSwaggerSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.Configuration"/>.</em></p><p>The configuration to use.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetConfiguration(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildProjectExtensionsPath
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.MSBuildProjectExtensionsPath"/>.</em></p><p>The MSBuild project extensions path. Defaults to "obj".</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetMSBuildProjectExtensionsPath(this NSwagAspNetCoreToSwaggerSettings toolSettings, string msbuildProjectExtensionsPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProjectExtensionsPath = msbuildProjectExtensionsPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.MSBuildProjectExtensionsPath"/>.</em></p><p>The MSBuild project extensions path. Defaults to "obj".</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetMSBuildProjectExtensionsPath(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProjectExtensionsPath = null;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.NoBuild"/>.</em></p><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetNoBuild(this NSwagAspNetCoreToSwaggerSettings toolSettings, bool? noBuild)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.NoBuild"/>.</em></p><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetNoBuild(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCoreToSwaggerSettings.NoBuild"/>.</em></p><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings EnableNoBuild(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCoreToSwaggerSettings.NoBuild"/>.</em></p><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings DisableNoBuild(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCoreToSwaggerSettings.NoBuild"/>.</em></p><p>Don't build the project. Only use this when the build is up-to-date.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ToggleNoBuild(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.Project"/>.</em></p><p>The project to use.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetProject(this NSwagAspNetCoreToSwaggerSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.Project"/>.</em></p><p>The project to use.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetProject(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.Runtime"/>.</em></p><p>The runtime to use.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetRuntime(this NSwagAspNetCoreToSwaggerSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.Runtime"/>.</em></p><p>The runtime to use.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetRuntime(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region TargetFramework
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.TargetFramework"/>.</em></p><p>The target framework to use.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetTargetFramework(this NSwagAspNetCoreToSwaggerSettings toolSettings, string targetFramework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetFramework = targetFramework;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.TargetFramework"/>.</em></p><p>The target framework to use.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetTargetFramework(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetFramework = null;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.Verbose"/>.</em></p><p>Print verbose output.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetVerbose(this NSwagAspNetCoreToSwaggerSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.Verbose"/>.</em></p><p>Print verbose output.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetVerbose(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCoreToSwaggerSettings.Verbose"/>.</em></p><p>Print verbose output.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings EnableVerbose(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCoreToSwaggerSettings.Verbose"/>.</em></p><p>Print verbose output.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings DisableVerbose(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCoreToSwaggerSettings.Verbose"/>.</em></p><p>Print verbose output.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ToggleVerbose(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region AllowReferencesWithProperties
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetAllowReferencesWithProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings, bool? allowReferencesWithProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = allowReferencesWithProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetAllowReferencesWithProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCoreToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings EnableAllowReferencesWithProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCoreToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings DisableAllowReferencesWithProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCoreToSwaggerSettings.AllowReferencesWithProperties"/>.</em></p><p>Use $ref references even if additional properties are defined on the object (otherwise allOf/oneOf with $ref is used, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ToggleAllowReferencesWithProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowReferencesWithProperties = !toolSettings.AllowReferencesWithProperties;
            return toolSettings;
        }
        #endregion
        #region ContractResolver
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.ContractResolver"/>.</em></p><p>The custom IContractResolver implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetContractResolver(this NSwagAspNetCoreToSwaggerSettings toolSettings, string contractResolver)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractResolver = contractResolver;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.ContractResolver"/>.</em></p><p>The custom IContractResolver implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetContractResolver(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractResolver = null;
            return toolSettings;
        }
        #endregion
        #region DefaultEnumHandling
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetDefaultEnumHandling(this NSwagAspNetCoreToSwaggerSettings toolSettings, EnumHandling defaultEnumHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = defaultEnumHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.DefaultEnumHandling"/>.</em></p><p>The default enum handling ('String' or 'Integer'), default: Integer.</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetDefaultEnumHandling(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultEnumHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultPropertyNameHandling
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetDefaultPropertyNameHandling(this NSwagAspNetCoreToSwaggerSettings toolSettings, PropertyNameHandling defaultPropertyNameHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = defaultPropertyNameHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.DefaultPropertyNameHandling"/>.</em></p><p>The default property name handling ('Default' or 'CamelCase').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetDefaultPropertyNameHandling(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPropertyNameHandling = null;
            return toolSettings;
        }
        #endregion
        #region DefaultReferenceTypeNullHandling
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetDefaultReferenceTypeNullHandling(this NSwagAspNetCoreToSwaggerSettings toolSettings, ReferenceTypeNullHandling defaultReferenceTypeNullHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = defaultReferenceTypeNullHandling;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.DefaultReferenceTypeNullHandling"/>.</em></p><p>The default null handling (if NotNullAttribute and CanBeNullAttribute are missing, default: Null, Null or NotNull).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetDefaultReferenceTypeNullHandling(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultReferenceTypeNullHandling = null;
            return toolSettings;
        }
        #endregion
        #region DocumentProcessors
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.DocumentProcessors"/> to a new list.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetDocumentProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal = documentProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.DocumentProcessors"/> to a new list.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetDocumentProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal = documentProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddDocumentProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal.AddRange(documentProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddDocumentProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal.AddRange(documentProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagAspNetCoreToSwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ClearDocumentProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentProcessorsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveDocumentProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(documentProcessors);
            toolSettings.DocumentProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.DocumentProcessors"/>.</em></p><p>The document processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveDocumentProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> documentProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(documentProcessors);
            toolSettings.DocumentProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DocumentTemplate
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.DocumentTemplate"/>.</em></p><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetDocumentTemplate(this NSwagAspNetCoreToSwaggerSettings toolSettings, string documentTemplate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentTemplate = documentTemplate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.DocumentTemplate"/>.</em></p><p>Specifies the Swagger document template (may be a path or JSON, default: none).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetDocumentTemplate(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DocumentTemplate = null;
            return toolSettings;
        }
        #endregion
        #region ExcludedTypeNames
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetExcludedTypeNames(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetExcludedTypeNames(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddExcludedTypeNames(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddExcludedTypeNames(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagAspNetCoreToSwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ClearExcludedTypeNames(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveExcludedTypeNames(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded type names (same as JsonSchemaIgnoreAttribute).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveExcludedTypeNames(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region FlattenInheritanceHierarchy
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetFlattenInheritanceHierarchy(this NSwagAspNetCoreToSwaggerSettings toolSettings, bool? flattenInheritanceHierarchy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = flattenInheritanceHierarchy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetFlattenInheritanceHierarchy(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCoreToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings EnableFlattenInheritanceHierarchy(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCoreToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings DisableFlattenInheritanceHierarchy(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCoreToSwaggerSettings.FlattenInheritanceHierarchy"/>.</em></p><p>Flatten the inheritance hierarchy instead of using allOf to describe inheritance (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ToggleFlattenInheritanceHierarchy(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FlattenInheritanceHierarchy = !toolSettings.FlattenInheritanceHierarchy;
            return toolSettings;
        }
        #endregion
        #region GenerateAbstractProperties
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetGenerateAbstractProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings, bool? generateAbstractProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = generateAbstractProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetGenerateAbstractProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings EnableGenerateAbstractProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings DisableGenerateAbstractProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateAbstractProperties"/>.</em></p><p>Generate abstract properties (i.e. interface and abstract properties. Properties may defined multiple times in a inheritance hierarchy, default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ToggleGenerateAbstractProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateAbstractProperties = !toolSettings.GenerateAbstractProperties;
            return toolSettings;
        }
        #endregion
        #region GenerateKnownTypes
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetGenerateKnownTypes(this NSwagAspNetCoreToSwaggerSettings toolSettings, bool? generateKnownTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = generateKnownTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetGenerateKnownTypes(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings EnableGenerateKnownTypes(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings DisableGenerateKnownTypes(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateKnownTypes"/>.</em></p><p>Generate schemas for types in KnownTypeAttribute attributes (default: true).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ToggleGenerateKnownTypes(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateKnownTypes = !toolSettings.GenerateKnownTypes;
            return toolSettings;
        }
        #endregion
        #region GenerateXmlObjects
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetGenerateXmlObjects(this NSwagAspNetCoreToSwaggerSettings toolSettings, bool? generateXmlObjects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = generateXmlObjects;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetGenerateXmlObjects(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings EnableGenerateXmlObjects(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings DisableGenerateXmlObjects(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCoreToSwaggerSettings.GenerateXmlObjects"/>.</em></p><p>Generate xmlObject representation for definitions (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ToggleGenerateXmlObjects(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateXmlObjects = !toolSettings.GenerateXmlObjects;
            return toolSettings;
        }
        #endregion
        #region IgnoreObsoleteProperties
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetIgnoreObsoleteProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings, bool? ignoreObsoleteProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = ignoreObsoleteProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetIgnoreObsoleteProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagAspNetCoreToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings EnableIgnoreObsoleteProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagAspNetCoreToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings DisableIgnoreObsoleteProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagAspNetCoreToSwaggerSettings.IgnoreObsoleteProperties"/>.</em></p><p>Ignore properties with the ObsoleteAttribute (default: false).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ToggleIgnoreObsoleteProperties(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreObsoleteProperties = !toolSettings.IgnoreObsoleteProperties;
            return toolSettings;
        }
        #endregion
        #region InfoDescription
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.InfoDescription"/>.</em></p><p>Specify the description of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetInfoDescription(this NSwagAspNetCoreToSwaggerSettings toolSettings, string infoDescription)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoDescription = infoDescription;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.InfoDescription"/>.</em></p><p>Specify the description of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetInfoDescription(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoDescription = null;
            return toolSettings;
        }
        #endregion
        #region InfoTitle
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.InfoTitle"/>.</em></p><p>Specify the title of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetInfoTitle(this NSwagAspNetCoreToSwaggerSettings toolSettings, string infoTitle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoTitle = infoTitle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.InfoTitle"/>.</em></p><p>Specify the title of the Swagger specification (ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetInfoTitle(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoTitle = null;
            return toolSettings;
        }
        #endregion
        #region InfoVersion
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.InfoVersion"/>.</em></p><p>Specify the version of the Swagger specification (default: 1.0.0, ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetInfoVersion(this NSwagAspNetCoreToSwaggerSettings toolSettings, string infoVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoVersion = infoVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.InfoVersion"/>.</em></p><p>Specify the version of the Swagger specification (default: 1.0.0, ignored when DocumentTemplate is set).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetInfoVersion(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InfoVersion = null;
            return toolSettings;
        }
        #endregion
        #region OperationProcessors
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.OperationProcessors"/> to a new list.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetOperationProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal = operationProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.OperationProcessors"/> to a new list.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetOperationProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal = operationProcessors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddOperationProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.AddRange(operationProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddOperationProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.AddRange(operationProcessors);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagAspNetCoreToSwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ClearOperationProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationProcessorsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveOperationProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(operationProcessors);
            toolSettings.OperationProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.OperationProcessors"/>.</em></p><p>The operation processor type names in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveOperationProcessors(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> operationProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(operationProcessors);
            toolSettings.OperationProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SchemaNameGenerator
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.SchemaNameGenerator"/>.</em></p><p>The custom ISchemaNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetSchemaNameGenerator(this NSwagAspNetCoreToSwaggerSettings toolSettings, string schemaNameGenerator)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SchemaNameGenerator = schemaNameGenerator;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.SchemaNameGenerator"/>.</em></p><p>The custom ISchemaNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetSchemaNameGenerator(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SchemaNameGenerator = null;
            return toolSettings;
        }
        #endregion
        #region ServiceBasePath
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceBasePath"/>.</em></p><p>The basePath of the Swagger specification (optional).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetServiceBasePath(this NSwagAspNetCoreToSwaggerSettings toolSettings, string serviceBasePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceBasePath = serviceBasePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceBasePath"/>.</em></p><p>The basePath of the Swagger specification (optional).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetServiceBasePath(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceBasePath = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetServiceHost(this NSwagAspNetCoreToSwaggerSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web service (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetServiceHost(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetServiceSchemes(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetServiceSchemes(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddServiceSchemes(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddServiceSchemes(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ClearServiceSchemes(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveServiceSchemes(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveServiceSchemes(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TypeNameGenerator
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetTypeNameGenerator(this NSwagAspNetCoreToSwaggerSettings toolSettings, string typeNameGenerator)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = typeNameGenerator;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetTypeNameGenerator(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetOutput(this NSwagAspNetCoreToSwaggerSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetOutput(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region OutputType
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.OutputType"/>.</em></p><p>Specifies the output schema type (Swagger2|OpenApi3, default: Swagger2).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetOutputType(this NSwagAspNetCoreToSwaggerSettings toolSettings, SchemaType outputType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputType = outputType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.OutputType"/>.</em></p><p>Specifies the output schema type (Swagger2|OpenApi3, default: Swagger2).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetOutputType(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputType = null;
            return toolSettings;
        }
        #endregion
        #region Assembly
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetAssembly(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.Assembly"/> to a new list.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetAssembly(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal = assembly.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddAssembly(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddAssembly(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.AddRange(assembly);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagAspNetCoreToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ClearAssembly(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveAssembly(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.Assembly"/>.</em></p><p>The path or paths to the .NET assemblies (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveAssembly(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> assembly)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assembly);
            toolSettings.AssemblyInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AssemblyConfig
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetAssemblyConfig(this NSwagAspNetCoreToSwaggerSettings toolSettings, string assemblyConfig)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = assemblyConfig;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagAspNetCoreToSwaggerSettings.AssemblyConfig"/>.</em></p><p>The path to the assembly App.config or Web.config (optional).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ResetAssemblyConfig(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssemblyConfig = null;
            return toolSettings;
        }
        #endregion
        #region ReferencePaths
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetReferencePaths(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagAspNetCoreToSwaggerSettings.ReferencePaths"/> to a new list.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings SetReferencePaths(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal = referencePaths.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddReferencePaths(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagAspNetCoreToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings AddReferencePaths(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.AddRange(referencePaths);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagAspNetCoreToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings ClearReferencePaths(this NSwagAspNetCoreToSwaggerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveReferencePaths(this NSwagAspNetCoreToSwaggerSettings toolSettings, params string[] referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagAspNetCoreToSwaggerSettings.ReferencePaths"/>.</em></p><p>The paths to search for referenced assembly files (comma separated).</p></summary>
        [Pure]
        public static NSwagAspNetCoreToSwaggerSettings RemoveReferencePaths(this NSwagAspNetCoreToSwaggerSettings toolSettings, IEnumerable<string> referencePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencePaths);
            toolSettings.ReferencePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagCreateDocumentSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagCreateDocumentSettingsExtensions
    {
    }
    #endregion
    #region NSwagExecuteDocumentSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagExecuteDocumentSettingsExtensions
    {
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagExecuteDocumentSettings.Input"/>.</em></p></summary>
        [Pure]
        public static NSwagExecuteDocumentSettings SetInput(this NSwagExecuteDocumentSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagExecuteDocumentSettings.Input"/>.</em></p></summary>
        [Pure]
        public static NSwagExecuteDocumentSettings ResetInput(this NSwagExecuteDocumentSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary><p><em>Sets <see cref="NSwagExecuteDocumentSettings.Variables"/> to a new dictionary.</em></p></summary>
        [Pure]
        public static NSwagExecuteDocumentSettings SetVariables(this NSwagExecuteDocumentSettings toolSettings, IDictionary<string, object> variables)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal = variables.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagExecuteDocumentSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagExecuteDocumentSettings ClearVariables(this NSwagExecuteDocumentSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="NSwagExecuteDocumentSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagExecuteDocumentSettings AddVariable(this NSwagExecuteDocumentSettings toolSettings, string variableKey, object variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Add(variableKey, variableValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="NSwagExecuteDocumentSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagExecuteDocumentSettings RemoveVariable(this NSwagExecuteDocumentSettings toolSettings, string variableKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Remove(variableKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="NSwagExecuteDocumentSettings.Variables"/>.</em></p></summary>
        [Pure]
        public static NSwagExecuteDocumentSettings SetVariable(this NSwagExecuteDocumentSettings toolSettings, string variableKey, object variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal[variableKey] = variableValue;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagJsonSchemaToCSharpSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagJsonSchemaToCSharpSettingsExtensions
    {
        #region ArrayType
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetArrayType(this NSwagJsonSchemaToCSharpSettings toolSettings, string arrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = arrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToCSharpSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ResetArrayType(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = null;
            return toolSettings;
        }
        #endregion
        #region DateTimeType
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetDateTimeType(this NSwagJsonSchemaToCSharpSettings toolSettings, string dateTimeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = dateTimeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToCSharpSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ResetDateTimeType(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = null;
            return toolSettings;
        }
        #endregion
        #region DictionaryType
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetDictionaryType(this NSwagJsonSchemaToCSharpSettings toolSettings, string dictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = dictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToCSharpSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ResetDictionaryType(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.Name"/>.</em></p><p>The class name of the root schema.</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetName(this NSwagJsonSchemaToCSharpSettings toolSettings, string name)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToCSharpSettings.Name"/>.</em></p><p>The class name of the root schema.</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ResetName(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Namespace
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.Namespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetNamespace(this NSwagJsonSchemaToCSharpSettings toolSettings, string @namespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Namespace = @namespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToCSharpSettings.Namespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ResetNamespace(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Namespace = null;
            return toolSettings;
        }
        #endregion
        #region RequiredPropertiesMustBeDefined
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetRequiredPropertiesMustBeDefined(this NSwagJsonSchemaToCSharpSettings toolSettings, bool? requiredPropertiesMustBeDefined)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = requiredPropertiesMustBeDefined;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToCSharpSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ResetRequiredPropertiesMustBeDefined(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagJsonSchemaToCSharpSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings EnableRequiredPropertiesMustBeDefined(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagJsonSchemaToCSharpSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings DisableRequiredPropertiesMustBeDefined(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagJsonSchemaToCSharpSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ToggleRequiredPropertiesMustBeDefined(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = !toolSettings.RequiredPropertiesMustBeDefined;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetInput(this NSwagJsonSchemaToCSharpSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToCSharpSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ResetInput(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetServiceHost(this NSwagJsonSchemaToCSharpSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToCSharpSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ResetServiceHost(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetServiceSchemes(this NSwagJsonSchemaToCSharpSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetServiceSchemes(this NSwagJsonSchemaToCSharpSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagJsonSchemaToCSharpSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings AddServiceSchemes(this NSwagJsonSchemaToCSharpSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagJsonSchemaToCSharpSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings AddServiceSchemes(this NSwagJsonSchemaToCSharpSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagJsonSchemaToCSharpSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ClearServiceSchemes(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagJsonSchemaToCSharpSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings RemoveServiceSchemes(this NSwagJsonSchemaToCSharpSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagJsonSchemaToCSharpSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings RemoveServiceSchemes(this NSwagJsonSchemaToCSharpSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToCSharpSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings SetOutput(this NSwagJsonSchemaToCSharpSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToCSharpSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToCSharpSettings ResetOutput(this NSwagJsonSchemaToCSharpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagJsonSchemaToTypeScriptSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagJsonSchemaToTypeScriptSettingsExtensions
    {
        #region Name
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToTypeScriptSettings.Name"/>.</em></p><p>The type name of the root schema.</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings SetName(this NSwagJsonSchemaToTypeScriptSettings toolSettings, string name)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToTypeScriptSettings.Name"/>.</em></p><p>The type name of the root schema.</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings ResetName(this NSwagJsonSchemaToTypeScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToTypeScriptSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings SetInput(this NSwagJsonSchemaToTypeScriptSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToTypeScriptSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings ResetInput(this NSwagJsonSchemaToTypeScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToTypeScriptSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings SetServiceHost(this NSwagJsonSchemaToTypeScriptSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToTypeScriptSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings ResetServiceHost(this NSwagJsonSchemaToTypeScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToTypeScriptSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings SetServiceSchemes(this NSwagJsonSchemaToTypeScriptSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToTypeScriptSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings SetServiceSchemes(this NSwagJsonSchemaToTypeScriptSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagJsonSchemaToTypeScriptSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings AddServiceSchemes(this NSwagJsonSchemaToTypeScriptSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagJsonSchemaToTypeScriptSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings AddServiceSchemes(this NSwagJsonSchemaToTypeScriptSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagJsonSchemaToTypeScriptSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings ClearServiceSchemes(this NSwagJsonSchemaToTypeScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagJsonSchemaToTypeScriptSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings RemoveServiceSchemes(this NSwagJsonSchemaToTypeScriptSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagJsonSchemaToTypeScriptSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings RemoveServiceSchemes(this NSwagJsonSchemaToTypeScriptSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagJsonSchemaToTypeScriptSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings SetOutput(this NSwagJsonSchemaToTypeScriptSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagJsonSchemaToTypeScriptSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagJsonSchemaToTypeScriptSettings ResetOutput(this NSwagJsonSchemaToTypeScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagSwaggerToCSharpClientSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagSwaggerToCSharpClientSettingsExtensions
    {
        #region ClientBaseClass
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ClientBaseClass"/>.</em></p><p>The client base class (empty for no base class).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetClientBaseClass(this NSwagSwaggerToCSharpClientSettings toolSettings, string clientBaseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientBaseClass = clientBaseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ClientBaseClass"/>.</em></p><p>The client base class (empty for no base class).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetClientBaseClass(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientBaseClass = null;
            return toolSettings;
        }
        #endregion
        #region ClientClassAccessModifier
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ClientClassAccessModifier"/>.</em></p><p>The client class access modifier (default: public).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetClientClassAccessModifier(this NSwagSwaggerToCSharpClientSettings toolSettings, string clientClassAccessModifier)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientClassAccessModifier = clientClassAccessModifier;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ClientClassAccessModifier"/>.</em></p><p>The client class access modifier (default: public).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetClientClassAccessModifier(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientClassAccessModifier = null;
            return toolSettings;
        }
        #endregion
        #region ConfigurationClass
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ConfigurationClass"/>.</em></p><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetConfigurationClass(this NSwagSwaggerToCSharpClientSettings toolSettings, string configurationClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationClass = configurationClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ConfigurationClass"/>.</em></p><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetConfigurationClass(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationClass = null;
            return toolSettings;
        }
        #endregion
        #region ContractsNamespace
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ContractsNamespace"/>.</em></p><p>The contracts .NET namespace.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetContractsNamespace(this NSwagSwaggerToCSharpClientSettings toolSettings, string contractsNamespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractsNamespace = contractsNamespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ContractsNamespace"/>.</em></p><p>The contracts .NET namespace.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetContractsNamespace(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractsNamespace = null;
            return toolSettings;
        }
        #endregion
        #region ContractsOutput
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ContractsOutput"/>.</em></p><p>The contracts output file path (optional, if no path is set then a single file with the implementation and contracts is generated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetContractsOutput(this NSwagSwaggerToCSharpClientSettings toolSettings, string contractsOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractsOutput = contractsOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ContractsOutput"/>.</em></p><p>The contracts output file path (optional, if no path is set then a single file with the implementation and contracts is generated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetContractsOutput(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContractsOutput = null;
            return toolSettings;
        }
        #endregion
        #region DisposeHttpClient
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.DisposeHttpClient"/>.</em></p><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetDisposeHttpClient(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? disposeHttpClient)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeHttpClient = disposeHttpClient;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.DisposeHttpClient"/>.</em></p><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetDisposeHttpClient(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeHttpClient = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.DisposeHttpClient"/>.</em></p><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableDisposeHttpClient(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeHttpClient = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.DisposeHttpClient"/>.</em></p><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableDisposeHttpClient(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeHttpClient = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.DisposeHttpClient"/>.</em></p><p>Specifies whether to dispose the HttpClient (injected HttpClient is never disposed).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleDisposeHttpClient(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisposeHttpClient = !toolSettings.DisposeHttpClient;
            return toolSettings;
        }
        #endregion
        #region ExceptionClass
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ExceptionClass"/>.</em></p><p>The exception class (default 'SwaggerException', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetExceptionClass(this NSwagSwaggerToCSharpClientSettings toolSettings, string exceptionClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExceptionClass = exceptionClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ExceptionClass"/>.</em></p><p>The exception class (default 'SwaggerException', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetExceptionClass(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExceptionClass = null;
            return toolSettings;
        }
        #endregion
        #region ExposeJsonSerializerSettings
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ExposeJsonSerializerSettings"/>.</em></p><p>Specifies whether to expose the JsonSerializerSettings property (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetExposeJsonSerializerSettings(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? exposeJsonSerializerSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExposeJsonSerializerSettings = exposeJsonSerializerSettings;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ExposeJsonSerializerSettings"/>.</em></p><p>Specifies whether to expose the JsonSerializerSettings property (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetExposeJsonSerializerSettings(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExposeJsonSerializerSettings = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.ExposeJsonSerializerSettings"/>.</em></p><p>Specifies whether to expose the JsonSerializerSettings property (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableExposeJsonSerializerSettings(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExposeJsonSerializerSettings = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.ExposeJsonSerializerSettings"/>.</em></p><p>Specifies whether to expose the JsonSerializerSettings property (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableExposeJsonSerializerSettings(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExposeJsonSerializerSettings = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.ExposeJsonSerializerSettings"/>.</em></p><p>Specifies whether to expose the JsonSerializerSettings property (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleExposeJsonSerializerSettings(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExposeJsonSerializerSettings = !toolSettings.ExposeJsonSerializerSettings;
            return toolSettings;
        }
        #endregion
        #region GenerateBaseUrlProperty
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateBaseUrlProperty"/>.</em></p><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateBaseUrlProperty(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateBaseUrlProperty)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateBaseUrlProperty = generateBaseUrlProperty;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateBaseUrlProperty"/>.</em></p><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateBaseUrlProperty(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateBaseUrlProperty = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateBaseUrlProperty"/>.</em></p><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateBaseUrlProperty(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateBaseUrlProperty = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateBaseUrlProperty"/>.</em></p><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateBaseUrlProperty(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateBaseUrlProperty = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateBaseUrlProperty"/>.</em></p><p>Specifies whether to generate the BaseUrl property, must be defined on the base class otherwise (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateBaseUrlProperty(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateBaseUrlProperty = !toolSettings.GenerateBaseUrlProperty;
            return toolSettings;
        }
        #endregion
        #region GenerateClientClasses
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateClientClasses(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateClientClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = generateClientClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateClientClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateClientClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateClientClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateClientClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = !toolSettings.GenerateClientClasses;
            return toolSettings;
        }
        #endregion
        #region GenerateClientInterfaces
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateClientInterfaces(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateClientInterfaces)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = generateClientInterfaces;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateClientInterfaces(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateClientInterfaces(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateClientInterfaces(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateClientInterfaces(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = !toolSettings.GenerateClientInterfaces;
            return toolSettings;
        }
        #endregion
        #region GenerateContractsOutput
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateContractsOutput"/>.</em></p><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateContractsOutput(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateContractsOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateContractsOutput = generateContractsOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateContractsOutput"/>.</em></p><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateContractsOutput(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateContractsOutput = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateContractsOutput"/>.</em></p><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateContractsOutput(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateContractsOutput = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateContractsOutput"/>.</em></p><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateContractsOutput(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateContractsOutput = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateContractsOutput"/>.</em></p><p>Specifies whether to generate contracts output (interface and models in a separate file set with the ContractsOutput parameter).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateContractsOutput(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateContractsOutput = !toolSettings.GenerateContractsOutput;
            return toolSettings;
        }
        #endregion
        #region GenerateDtoTypes
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateDtoTypes(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateDtoTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = generateDtoTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateDtoTypes(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateDtoTypes(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateDtoTypes(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateDtoTypes(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = !toolSettings.GenerateDtoTypes;
            return toolSettings;
        }
        #endregion
        #region GenerateExceptionClasses
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateExceptionClasses"/>.</em></p><p>Specifies whether to generate exception classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateExceptionClasses(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateExceptionClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateExceptionClasses = generateExceptionClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateExceptionClasses"/>.</em></p><p>Specifies whether to generate exception classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateExceptionClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateExceptionClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateExceptionClasses"/>.</em></p><p>Specifies whether to generate exception classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateExceptionClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateExceptionClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateExceptionClasses"/>.</em></p><p>Specifies whether to generate exception classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateExceptionClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateExceptionClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateExceptionClasses"/>.</em></p><p>Specifies whether to generate exception classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateExceptionClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateExceptionClasses = !toolSettings.GenerateExceptionClasses;
            return toolSettings;
        }
        #endregion
        #region GenerateSyncMethods
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateSyncMethods"/>.</em></p><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateSyncMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateSyncMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSyncMethods = generateSyncMethods;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateSyncMethods"/>.</em></p><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateSyncMethods(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSyncMethods = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateSyncMethods"/>.</em></p><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateSyncMethods(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSyncMethods = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateSyncMethods"/>.</em></p><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateSyncMethods(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSyncMethods = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateSyncMethods"/>.</em></p><p>Specifies whether to generate synchronous methods (not recommended, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateSyncMethods(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateSyncMethods = !toolSettings.GenerateSyncMethods;
            return toolSettings;
        }
        #endregion
        #region GenerateUpdateJsonSerializerSettingsMethod
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateUpdateJsonSerializerSettingsMethod"/>.</em></p><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateUpdateJsonSerializerSettingsMethod(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateUpdateJsonSerializerSettingsMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateUpdateJsonSerializerSettingsMethod = generateUpdateJsonSerializerSettingsMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateUpdateJsonSerializerSettingsMethod"/>.</em></p><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateUpdateJsonSerializerSettingsMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateUpdateJsonSerializerSettingsMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateUpdateJsonSerializerSettingsMethod"/>.</em></p><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateUpdateJsonSerializerSettingsMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateUpdateJsonSerializerSettingsMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateUpdateJsonSerializerSettingsMethod"/>.</em></p><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateUpdateJsonSerializerSettingsMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateUpdateJsonSerializerSettingsMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateUpdateJsonSerializerSettingsMethod"/>.</em></p><p>Generate the UpdateJsonSerializerSettings method (must be implemented in the base class otherwise, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateUpdateJsonSerializerSettingsMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateUpdateJsonSerializerSettingsMethod = !toolSettings.GenerateUpdateJsonSerializerSettingsMethod;
            return toolSettings;
        }
        #endregion
        #region HttpClientType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.HttpClientType"/>.</em></p><p>Specifies the HttpClient type. By default the 'System.Net.Http.HttpClient' is used.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetHttpClientType(this NSwagSwaggerToCSharpClientSettings toolSettings, string httpClientType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpClientType = httpClientType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.HttpClientType"/>.</em></p><p>Specifies the HttpClient type. By default the 'System.Net.Http.HttpClient' is used.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetHttpClientType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpClientType = null;
            return toolSettings;
        }
        #endregion
        #region InjectHttpClient
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.InjectHttpClient"/>.</em></p><p>Specifies whether an HttpClient instance is injected.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetInjectHttpClient(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? injectHttpClient)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectHttpClient = injectHttpClient;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.InjectHttpClient"/>.</em></p><p>Specifies whether an HttpClient instance is injected.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetInjectHttpClient(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectHttpClient = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.InjectHttpClient"/>.</em></p><p>Specifies whether an HttpClient instance is injected.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableInjectHttpClient(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectHttpClient = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.InjectHttpClient"/>.</em></p><p>Specifies whether an HttpClient instance is injected.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableInjectHttpClient(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectHttpClient = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.InjectHttpClient"/>.</em></p><p>Specifies whether an HttpClient instance is injected.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleInjectHttpClient(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectHttpClient = !toolSettings.InjectHttpClient;
            return toolSettings;
        }
        #endregion
        #region ParameterDateTimeFormat
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ParameterDateTimeFormat"/>.</em></p><p>Specifies the format for DateTime type method parameters (default: s).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetParameterDateTimeFormat(this NSwagSwaggerToCSharpClientSettings toolSettings, string parameterDateTimeFormat)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDateTimeFormat = parameterDateTimeFormat;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ParameterDateTimeFormat"/>.</em></p><p>Specifies the format for DateTime type method parameters (default: s).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetParameterDateTimeFormat(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDateTimeFormat = null;
            return toolSettings;
        }
        #endregion
        #region ProtectedMethods
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ProtectedMethods"/> to a new list.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetProtectedMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal = protectedMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ProtectedMethods"/> to a new list.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetProtectedMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal = protectedMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddProtectedMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.AddRange(protectedMethods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddProtectedMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.AddRange(protectedMethods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ClearProtectedMethods(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveProtectedMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(protectedMethods);
            toolSettings.ProtectedMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveProtectedMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(protectedMethods);
            toolSettings.ProtectedMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region QueryNullValue
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.QueryNullValue"/>.</em></p><p>The null value used for query parameters which are null (default: '').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetQueryNullValue(this NSwagSwaggerToCSharpClientSettings toolSettings, string queryNullValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QueryNullValue = queryNullValue;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.QueryNullValue"/>.</em></p><p>The null value used for query parameters which are null (default: '').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetQueryNullValue(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QueryNullValue = null;
            return toolSettings;
        }
        #endregion
        #region SerializeTypeInformation
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.SerializeTypeInformation"/>.</em></p><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetSerializeTypeInformation(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? serializeTypeInformation)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SerializeTypeInformation = serializeTypeInformation;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.SerializeTypeInformation"/>.</em></p><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetSerializeTypeInformation(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SerializeTypeInformation = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.SerializeTypeInformation"/>.</em></p><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableSerializeTypeInformation(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SerializeTypeInformation = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.SerializeTypeInformation"/>.</em></p><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableSerializeTypeInformation(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SerializeTypeInformation = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.SerializeTypeInformation"/>.</em></p><p>Serialize the type information in a $type property (not recommended, also sets TypeNameHandling = Auto, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleSerializeTypeInformation(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SerializeTypeInformation = !toolSettings.SerializeTypeInformation;
            return toolSettings;
        }
        #endregion
        #region TypeAccessModifier
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.TypeAccessModifier"/>.</em></p><p>The DTO class/enum access modifier (default: public).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetTypeAccessModifier(this NSwagSwaggerToCSharpClientSettings toolSettings, string typeAccessModifier)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeAccessModifier = typeAccessModifier;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.TypeAccessModifier"/>.</em></p><p>The DTO class/enum access modifier (default: public).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetTypeAccessModifier(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeAccessModifier = null;
            return toolSettings;
        }
        #endregion
        #region UseBaseUrl
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.UseBaseUrl"/>.</em></p><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetUseBaseUrl(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? useBaseUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseBaseUrl = useBaseUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.UseBaseUrl"/>.</em></p><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetUseBaseUrl(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseBaseUrl = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.UseBaseUrl"/>.</em></p><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableUseBaseUrl(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseBaseUrl = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.UseBaseUrl"/>.</em></p><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableUseBaseUrl(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseBaseUrl = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.UseBaseUrl"/>.</em></p><p>Specifies whether to use and expose the base URL (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleUseBaseUrl(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseBaseUrl = !toolSettings.UseBaseUrl;
            return toolSettings;
        }
        #endregion
        #region UseHttpClientCreationMethod
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.UseHttpClientCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetUseHttpClientCreationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? useHttpClientCreationMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpClientCreationMethod = useHttpClientCreationMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.UseHttpClientCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetUseHttpClientCreationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpClientCreationMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.UseHttpClientCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableUseHttpClientCreationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpClientCreationMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.UseHttpClientCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableUseHttpClientCreationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpClientCreationMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.UseHttpClientCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpClientAsync on the base class to create a new HttpClient.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleUseHttpClientCreationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpClientCreationMethod = !toolSettings.UseHttpClientCreationMethod;
            return toolSettings;
        }
        #endregion
        #region UseHttpRequestMessageCreationMethod
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.UseHttpRequestMessageCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetUseHttpRequestMessageCreationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? useHttpRequestMessageCreationMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpRequestMessageCreationMethod = useHttpRequestMessageCreationMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.UseHttpRequestMessageCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetUseHttpRequestMessageCreationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpRequestMessageCreationMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.UseHttpRequestMessageCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableUseHttpRequestMessageCreationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpRequestMessageCreationMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.UseHttpRequestMessageCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableUseHttpRequestMessageCreationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpRequestMessageCreationMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.UseHttpRequestMessageCreationMethod"/>.</em></p><p>Specifies whether to call CreateHttpRequestMessageAsync on the base class to create a new HttpRequestMethod.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleUseHttpRequestMessageCreationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseHttpRequestMessageCreationMethod = !toolSettings.UseHttpRequestMessageCreationMethod;
            return toolSettings;
        }
        #endregion
        #region WrapDtoExceptions
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetWrapDtoExceptions(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? wrapDtoExceptions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = wrapDtoExceptions;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetWrapDtoExceptions(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableWrapDtoExceptions(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableWrapDtoExceptions(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleWrapDtoExceptions(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = !toolSettings.WrapDtoExceptions;
            return toolSettings;
        }
        #endregion
        #region AdditionalContractNamespaceUsages
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalContractNamespaceUsages"/> to a new list.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractNamespaceUsagesInternal = additionalContractNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalContractNamespaceUsages"/> to a new list.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractNamespaceUsagesInternal = additionalContractNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalContractNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractNamespaceUsagesInternal.AddRange(additionalContractNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalContractNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractNamespaceUsagesInternal.AddRange(additionalContractNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalContractNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ClearAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractNamespaceUsagesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalContractNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(additionalContractNamespaceUsages);
            toolSettings.AdditionalContractNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalContractNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(additionalContractNamespaceUsages);
            toolSettings.AdditionalContractNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AdditionalNamespaceUsages
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalNamespaceUsages"/> to a new list.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetAdditionalNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalNamespaceUsagesInternal = additionalNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalNamespaceUsages"/> to a new list.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetAdditionalNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalNamespaceUsagesInternal = additionalNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddAdditionalNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalNamespaceUsagesInternal.AddRange(additionalNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddAdditionalNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalNamespaceUsagesInternal.AddRange(additionalNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ClearAdditionalNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalNamespaceUsagesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveAdditionalNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(additionalNamespaceUsages);
            toolSettings.AdditionalNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.AdditionalNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveAdditionalNamespaceUsages(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(additionalNamespaceUsages);
            toolSettings.AdditionalNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ArrayBaseType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ArrayBaseType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetArrayBaseType(this NSwagSwaggerToCSharpClientSettings toolSettings, string arrayBaseType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayBaseType = arrayBaseType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ArrayBaseType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetArrayBaseType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayBaseType = null;
            return toolSettings;
        }
        #endregion
        #region ArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetArrayType(this NSwagSwaggerToCSharpClientSettings toolSettings, string arrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = arrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetArrayType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = null;
            return toolSettings;
        }
        #endregion
        #region ClassName
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetClassName(this NSwagSwaggerToCSharpClientSettings toolSettings, string className)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = className;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetClassName(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = null;
            return toolSettings;
        }
        #endregion
        #region ClassStyle
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ClassStyle"/>.</em></p><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetClassStyle(this NSwagSwaggerToCSharpClientSettings toolSettings, CSharpClassStyle classStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassStyle = classStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ClassStyle"/>.</em></p><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetClassStyle(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassStyle = null;
            return toolSettings;
        }
        #endregion
        #region DateTimeType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetDateTimeType(this NSwagSwaggerToCSharpClientSettings toolSettings, string dateTimeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = dateTimeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetDateTimeType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = null;
            return toolSettings;
        }
        #endregion
        #region DateType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.DateType"/>.</em></p><p>The date .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetDateType(this NSwagSwaggerToCSharpClientSettings toolSettings, string dateType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateType = dateType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.DateType"/>.</em></p><p>The date .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetDateType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateType = null;
            return toolSettings;
        }
        #endregion
        #region DictionaryBaseType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.DictionaryBaseType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetDictionaryBaseType(this NSwagSwaggerToCSharpClientSettings toolSettings, string dictionaryBaseType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryBaseType = dictionaryBaseType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.DictionaryBaseType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetDictionaryBaseType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryBaseType = null;
            return toolSettings;
        }
        #endregion
        #region DictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetDictionaryType(this NSwagSwaggerToCSharpClientSettings toolSettings, string dictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = dictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetDictionaryType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region ExcludedTypeNames
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetExcludedTypeNames(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetExcludedTypeNames(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddExcludedTypeNames(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddExcludedTypeNames(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ClearExcludedTypeNames(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveExcludedTypeNames(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveExcludedTypeNames(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenerateDataAnnotations
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateDataAnnotations(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateDataAnnotations)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = generateDataAnnotations;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateDataAnnotations(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateDataAnnotations(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateDataAnnotations(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateDataAnnotations(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = !toolSettings.GenerateDataAnnotations;
            return toolSettings;
        }
        #endregion
        #region GenerateDefaultValues
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateDefaultValues(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateDefaultValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = generateDefaultValues;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateDefaultValues(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateDefaultValues(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateDefaultValues(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateDefaultValues(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = !toolSettings.GenerateDefaultValues;
            return toolSettings;
        }
        #endregion
        #region GenerateImmutableArrayProperties
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateImmutableArrayProperties(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateImmutableArrayProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = generateImmutableArrayProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateImmutableArrayProperties(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateImmutableArrayProperties(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateImmutableArrayProperties(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateImmutableArrayProperties(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = !toolSettings.GenerateImmutableArrayProperties;
            return toolSettings;
        }
        #endregion
        #region GenerateImmutableDictionaryProperties
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateImmutableDictionaryProperties(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateImmutableDictionaryProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = generateImmutableDictionaryProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateImmutableDictionaryProperties(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateImmutableDictionaryProperties(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateImmutableDictionaryProperties(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateImmutableDictionaryProperties(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = !toolSettings.GenerateImmutableDictionaryProperties;
            return toolSettings;
        }
        #endregion
        #region GenerateJsonMethods
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateJsonMethods"/>.</em></p><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateJsonMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateJsonMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateJsonMethods = generateJsonMethods;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateJsonMethods"/>.</em></p><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateJsonMethods(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateJsonMethods = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateJsonMethods"/>.</em></p><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateJsonMethods(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateJsonMethods = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateJsonMethods"/>.</em></p><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateJsonMethods(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateJsonMethods = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateJsonMethods"/>.</em></p><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateJsonMethods(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateJsonMethods = !toolSettings.GenerateJsonMethods;
            return toolSettings;
        }
        #endregion
        #region GenerateOptionalParameters
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateOptionalParameters(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateOptionalParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = generateOptionalParameters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateOptionalParameters(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateOptionalParameters(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateOptionalParameters(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateOptionalParameters(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = !toolSettings.GenerateOptionalParameters;
            return toolSettings;
        }
        #endregion
        #region GenerateResponseClasses
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetGenerateResponseClasses(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? generateResponseClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = generateResponseClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetGenerateResponseClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableGenerateResponseClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableGenerateResponseClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleGenerateResponseClasses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = !toolSettings.GenerateResponseClasses;
            return toolSettings;
        }
        #endregion
        #region HandleReferences
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetHandleReferences(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? handleReferences)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = handleReferences;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetHandleReferences(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableHandleReferences(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableHandleReferences(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleHandleReferences(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = !toolSettings.HandleReferences;
            return toolSettings;
        }
        #endregion
        #region JsonConverters
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.JsonConverters"/> to a new list.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetJsonConverters(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal = jsonConverters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.JsonConverters"/> to a new list.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetJsonConverters(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal = jsonConverters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddJsonConverters(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.AddRange(jsonConverters);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddJsonConverters(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.AddRange(jsonConverters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpClientSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ClearJsonConverters(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveJsonConverters(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(jsonConverters);
            toolSettings.JsonConvertersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveJsonConverters(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(jsonConverters);
            toolSettings.JsonConvertersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region JsonSerializerSettingsTransformationMethod
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.JsonSerializerSettingsTransformationMethod"/>.</em></p><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetJsonSerializerSettingsTransformationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings, string jsonSerializerSettingsTransformationMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonSerializerSettingsTransformationMethod = jsonSerializerSettingsTransformationMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.JsonSerializerSettingsTransformationMethod"/>.</em></p><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetJsonSerializerSettingsTransformationMethod(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonSerializerSettingsTransformationMethod = null;
            return toolSettings;
        }
        #endregion
        #region Namespace
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.Namespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetNamespace(this NSwagSwaggerToCSharpClientSettings toolSettings, string @namespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Namespace = @namespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.Namespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetNamespace(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Namespace = null;
            return toolSettings;
        }
        #endregion
        #region OperationGenerationMode
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetOperationGenerationMode(this NSwagSwaggerToCSharpClientSettings toolSettings, OperationGenerationMode operationGenerationMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = operationGenerationMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetOperationGenerationMode(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = null;
            return toolSettings;
        }
        #endregion
        #region ParameterArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ParameterArrayType"/>.</em></p><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetParameterArrayType(this NSwagSwaggerToCSharpClientSettings toolSettings, string parameterArrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterArrayType = parameterArrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ParameterArrayType"/>.</em></p><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetParameterArrayType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterArrayType = null;
            return toolSettings;
        }
        #endregion
        #region ParameterDictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ParameterDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetParameterDictionaryType(this NSwagSwaggerToCSharpClientSettings toolSettings, string parameterDictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDictionaryType = parameterDictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ParameterDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetParameterDictionaryType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region RequiredPropertiesMustBeDefined
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetRequiredPropertiesMustBeDefined(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? requiredPropertiesMustBeDefined)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = requiredPropertiesMustBeDefined;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetRequiredPropertiesMustBeDefined(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableRequiredPropertiesMustBeDefined(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableRequiredPropertiesMustBeDefined(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleRequiredPropertiesMustBeDefined(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = !toolSettings.RequiredPropertiesMustBeDefined;
            return toolSettings;
        }
        #endregion
        #region ResponseArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ResponseArrayType"/>.</em></p><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetResponseArrayType(this NSwagSwaggerToCSharpClientSettings toolSettings, string responseArrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseArrayType = responseArrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ResponseArrayType"/>.</em></p><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetResponseArrayType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseArrayType = null;
            return toolSettings;
        }
        #endregion
        #region ResponseClass
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetResponseClass(this NSwagSwaggerToCSharpClientSettings toolSettings, string responseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = responseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetResponseClass(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = null;
            return toolSettings;
        }
        #endregion
        #region ResponseDictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ResponseDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetResponseDictionaryType(this NSwagSwaggerToCSharpClientSettings toolSettings, string responseDictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseDictionaryType = responseDictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ResponseDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetResponseDictionaryType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseDictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region TimeSpanType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.TimeSpanType"/>.</em></p><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetTimeSpanType(this NSwagSwaggerToCSharpClientSettings toolSettings, string timeSpanType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeSpanType = timeSpanType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.TimeSpanType"/>.</em></p><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetTimeSpanType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeSpanType = null;
            return toolSettings;
        }
        #endregion
        #region TimeType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.TimeType"/>.</em></p><p>The time .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetTimeType(this NSwagSwaggerToCSharpClientSettings toolSettings, string timeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeType = timeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.TimeType"/>.</em></p><p>The time .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetTimeType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeType = null;
            return toolSettings;
        }
        #endregion
        #region WrapResponseMethods
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetWrapResponseMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetWrapResponseMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddWrapResponseMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddWrapResponseMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ClearWrapResponseMethods(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveWrapResponseMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveWrapResponseMethods(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WrapResponses
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetWrapResponses(this NSwagSwaggerToCSharpClientSettings toolSettings, bool? wrapResponses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = wrapResponses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetWrapResponses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings EnableWrapResponses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings DisableWrapResponses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ToggleWrapResponses(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = !toolSettings.WrapResponses;
            return toolSettings;
        }
        #endregion
        #region EnumNameGeneratorType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.EnumNameGeneratorType"/>.</em></p><p>The custom IEnumNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetEnumNameGeneratorType(this NSwagSwaggerToCSharpClientSettings toolSettings, string enumNameGeneratorType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnumNameGeneratorType = enumNameGeneratorType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.EnumNameGeneratorType"/>.</em></p><p>The custom IEnumNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetEnumNameGeneratorType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnumNameGeneratorType = null;
            return toolSettings;
        }
        #endregion
        #region PropertyNameGeneratorType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.PropertyNameGeneratorType"/>.</em></p><p>The custom IPropertyNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetPropertyNameGeneratorType(this NSwagSwaggerToCSharpClientSettings toolSettings, string propertyNameGeneratorType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertyNameGeneratorType = propertyNameGeneratorType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.PropertyNameGeneratorType"/>.</em></p><p>The custom IPropertyNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetPropertyNameGeneratorType(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertyNameGeneratorType = null;
            return toolSettings;
        }
        #endregion
        #region TemplateDirectory
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetTemplateDirectory(this NSwagSwaggerToCSharpClientSettings toolSettings, string templateDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = templateDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetTemplateDirectory(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = null;
            return toolSettings;
        }
        #endregion
        #region TypeNameGenerator
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetTypeNameGenerator(this NSwagSwaggerToCSharpClientSettings toolSettings, string typeNameGenerator)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = typeNameGenerator;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetTypeNameGenerator(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = null;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetInput(this NSwagSwaggerToCSharpClientSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetInput(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetServiceHost(this NSwagSwaggerToCSharpClientSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetServiceHost(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetServiceSchemes(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetServiceSchemes(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddServiceSchemes(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings AddServiceSchemes(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ClearServiceSchemes(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveServiceSchemes(this NSwagSwaggerToCSharpClientSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings RemoveServiceSchemes(this NSwagSwaggerToCSharpClientSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings SetOutput(this NSwagSwaggerToCSharpClientSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpClientSettings ResetOutput(this NSwagSwaggerToCSharpClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagSwaggerToCSharpControllerSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagSwaggerToCSharpControllerSettingsExtensions
    {
        #region AspNetNamespace
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.AspNetNamespace"/>.</em></p><p>The ASP.NET (Core) framework namespace (default: 'System.Web.Http').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetAspNetNamespace(this NSwagSwaggerToCSharpControllerSettings toolSettings, string aspNetNamespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetNamespace = aspNetNamespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.AspNetNamespace"/>.</em></p><p>The ASP.NET (Core) framework namespace (default: 'System.Web.Http').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetAspNetNamespace(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AspNetNamespace = null;
            return toolSettings;
        }
        #endregion
        #region ControllerBaseClass
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ControllerBaseClass"/>.</em></p><p>The controller base class (empty for 'ApiController').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetControllerBaseClass(this NSwagSwaggerToCSharpControllerSettings toolSettings, string controllerBaseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllerBaseClass = controllerBaseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ControllerBaseClass"/>.</em></p><p>The controller base class (empty for 'ApiController').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetControllerBaseClass(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllerBaseClass = null;
            return toolSettings;
        }
        #endregion
        #region ControllerStyle
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ControllerStyle"/>.</em></p><p>The controller generation style (partial, abstract; default: partial).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetControllerStyle(this NSwagSwaggerToCSharpControllerSettings toolSettings, CSharpControllerStyle controllerStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllerStyle = controllerStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ControllerStyle"/>.</em></p><p>The controller generation style (partial, abstract; default: partial).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetControllerStyle(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ControllerStyle = null;
            return toolSettings;
        }
        #endregion
        #region UseCancellationToken
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.UseCancellationToken"/>.</em></p><p>Add a cancellation token parameter (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetUseCancellationToken(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? useCancellationToken)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseCancellationToken = useCancellationToken;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.UseCancellationToken"/>.</em></p><p>Add a cancellation token parameter (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetUseCancellationToken(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseCancellationToken = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.UseCancellationToken"/>.</em></p><p>Add a cancellation token parameter (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableUseCancellationToken(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseCancellationToken = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.UseCancellationToken"/>.</em></p><p>Add a cancellation token parameter (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableUseCancellationToken(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseCancellationToken = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.UseCancellationToken"/>.</em></p><p>Add a cancellation token parameter (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleUseCancellationToken(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseCancellationToken = !toolSettings.UseCancellationToken;
            return toolSettings;
        }
        #endregion
        #region AdditionalContractNamespaceUsages
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalContractNamespaceUsages"/> to a new list.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractNamespaceUsagesInternal = additionalContractNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalContractNamespaceUsages"/> to a new list.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractNamespaceUsagesInternal = additionalContractNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalContractNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractNamespaceUsagesInternal.AddRange(additionalContractNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalContractNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractNamespaceUsagesInternal.AddRange(additionalContractNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalContractNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ClearAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalContractNamespaceUsagesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalContractNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(additionalContractNamespaceUsages);
            toolSettings.AdditionalContractNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalContractNamespaceUsages"/>.</em></p><p>The additional contract namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveAdditionalContractNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> additionalContractNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(additionalContractNamespaceUsages);
            toolSettings.AdditionalContractNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AdditionalNamespaceUsages
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalNamespaceUsages"/> to a new list.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetAdditionalNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalNamespaceUsagesInternal = additionalNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalNamespaceUsages"/> to a new list.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetAdditionalNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalNamespaceUsagesInternal = additionalNamespaceUsages.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddAdditionalNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalNamespaceUsagesInternal.AddRange(additionalNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddAdditionalNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalNamespaceUsagesInternal.AddRange(additionalNamespaceUsages);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ClearAdditionalNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AdditionalNamespaceUsagesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveAdditionalNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(additionalNamespaceUsages);
            toolSettings.AdditionalNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.AdditionalNamespaceUsages"/>.</em></p><p>The additional namespace usages.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveAdditionalNamespaceUsages(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> additionalNamespaceUsages)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(additionalNamespaceUsages);
            toolSettings.AdditionalNamespaceUsagesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ArrayBaseType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ArrayBaseType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetArrayBaseType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string arrayBaseType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayBaseType = arrayBaseType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ArrayBaseType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetArrayBaseType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayBaseType = null;
            return toolSettings;
        }
        #endregion
        #region ArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetArrayType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string arrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = arrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ArrayType"/>.</em></p><p>The generic array .NET type (default: 'ObservableCollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetArrayType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArrayType = null;
            return toolSettings;
        }
        #endregion
        #region ClassName
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetClassName(this NSwagSwaggerToCSharpControllerSettings toolSettings, string className)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = className;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetClassName(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = null;
            return toolSettings;
        }
        #endregion
        #region ClassStyle
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ClassStyle"/>.</em></p><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetClassStyle(this NSwagSwaggerToCSharpControllerSettings toolSettings, CSharpClassStyle classStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassStyle = classStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ClassStyle"/>.</em></p><p>The CSharp class style, 'Poco' or 'Inpc' (default: 'Inpc').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetClassStyle(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassStyle = null;
            return toolSettings;
        }
        #endregion
        #region DateTimeType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetDateTimeType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string dateTimeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = dateTimeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.DateTimeType"/>.</em></p><p>The date time .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetDateTimeType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = null;
            return toolSettings;
        }
        #endregion
        #region DateType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.DateType"/>.</em></p><p>The date .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetDateType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string dateType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateType = dateType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.DateType"/>.</em></p><p>The date .NET type (default: 'DateTime').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetDateType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateType = null;
            return toolSettings;
        }
        #endregion
        #region DictionaryBaseType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.DictionaryBaseType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetDictionaryBaseType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string dictionaryBaseType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryBaseType = dictionaryBaseType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.DictionaryBaseType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetDictionaryBaseType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryBaseType = null;
            return toolSettings;
        }
        #endregion
        #region DictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetDictionaryType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string dictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = dictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.DictionaryType"/>.</em></p><p>The generic dictionary .NET type (default: 'Dictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetDictionaryType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region ExcludedTypeNames
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetExcludedTypeNames(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetExcludedTypeNames(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddExcludedTypeNames(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddExcludedTypeNames(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpControllerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ClearExcludedTypeNames(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveExcludedTypeNames(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveExcludedTypeNames(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenerateDataAnnotations
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetGenerateDataAnnotations(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? generateDataAnnotations)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = generateDataAnnotations;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetGenerateDataAnnotations(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableGenerateDataAnnotations(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableGenerateDataAnnotations(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateDataAnnotations"/>.</em></p><p>Specifies whether to generate data annotation attributes on DTO classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleGenerateDataAnnotations(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDataAnnotations = !toolSettings.GenerateDataAnnotations;
            return toolSettings;
        }
        #endregion
        #region GenerateDefaultValues
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetGenerateDefaultValues(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? generateDefaultValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = generateDefaultValues;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetGenerateDefaultValues(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableGenerateDefaultValues(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableGenerateDefaultValues(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (may generate CSharp 6 code, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleGenerateDefaultValues(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = !toolSettings.GenerateDefaultValues;
            return toolSettings;
        }
        #endregion
        #region GenerateImmutableArrayProperties
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetGenerateImmutableArrayProperties(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? generateImmutableArrayProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = generateImmutableArrayProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetGenerateImmutableArrayProperties(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableGenerateImmutableArrayProperties(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableGenerateImmutableArrayProperties(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateImmutableArrayProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable array properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleGenerateImmutableArrayProperties(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableArrayProperties = !toolSettings.GenerateImmutableArrayProperties;
            return toolSettings;
        }
        #endregion
        #region GenerateImmutableDictionaryProperties
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetGenerateImmutableDictionaryProperties(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? generateImmutableDictionaryProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = generateImmutableDictionaryProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetGenerateImmutableDictionaryProperties(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableGenerateImmutableDictionaryProperties(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableGenerateImmutableDictionaryProperties(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateImmutableDictionaryProperties"/>.</em></p><p>Specifies whether to remove the setter for non-nullable dictionary properties (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleGenerateImmutableDictionaryProperties(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateImmutableDictionaryProperties = !toolSettings.GenerateImmutableDictionaryProperties;
            return toolSettings;
        }
        #endregion
        #region GenerateJsonMethods
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateJsonMethods"/>.</em></p><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetGenerateJsonMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? generateJsonMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateJsonMethods = generateJsonMethods;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateJsonMethods"/>.</em></p><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetGenerateJsonMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateJsonMethods = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateJsonMethods"/>.</em></p><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableGenerateJsonMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateJsonMethods = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateJsonMethods"/>.</em></p><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableGenerateJsonMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateJsonMethods = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateJsonMethods"/>.</em></p><p>Specifies whether to render ToJson() and FromJson() methods for DTOs (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleGenerateJsonMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateJsonMethods = !toolSettings.GenerateJsonMethods;
            return toolSettings;
        }
        #endregion
        #region GenerateOptionalParameters
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetGenerateOptionalParameters(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? generateOptionalParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = generateOptionalParameters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetGenerateOptionalParameters(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableGenerateOptionalParameters(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableGenerateOptionalParameters(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleGenerateOptionalParameters(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = !toolSettings.GenerateOptionalParameters;
            return toolSettings;
        }
        #endregion
        #region GenerateResponseClasses
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetGenerateResponseClasses(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? generateResponseClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = generateResponseClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetGenerateResponseClasses(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableGenerateResponseClasses(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableGenerateResponseClasses(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleGenerateResponseClasses(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = !toolSettings.GenerateResponseClasses;
            return toolSettings;
        }
        #endregion
        #region HandleReferences
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetHandleReferences(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? handleReferences)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = handleReferences;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetHandleReferences(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableHandleReferences(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableHandleReferences(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.HandleReferences"/>.</em></p><p>Use preserve references handling (All) in the JSON serializer (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleHandleReferences(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = !toolSettings.HandleReferences;
            return toolSettings;
        }
        #endregion
        #region JsonConverters
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.JsonConverters"/> to a new list.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetJsonConverters(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal = jsonConverters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.JsonConverters"/> to a new list.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetJsonConverters(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal = jsonConverters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddJsonConverters(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.AddRange(jsonConverters);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddJsonConverters(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.AddRange(jsonConverters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpControllerSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ClearJsonConverters(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonConvertersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveJsonConverters(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(jsonConverters);
            toolSettings.JsonConvertersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.JsonConverters"/>.</em></p><p>Specifies the custom Json.NET converter types (optional, comma separated).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveJsonConverters(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> jsonConverters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(jsonConverters);
            toolSettings.JsonConvertersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region JsonSerializerSettingsTransformationMethod
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.JsonSerializerSettingsTransformationMethod"/>.</em></p><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetJsonSerializerSettingsTransformationMethod(this NSwagSwaggerToCSharpControllerSettings toolSettings, string jsonSerializerSettingsTransformationMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonSerializerSettingsTransformationMethod = jsonSerializerSettingsTransformationMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.JsonSerializerSettingsTransformationMethod"/>.</em></p><p>The name of a static method which is called to transform the JsonSerializerSettings used in the generated ToJson()/FromJson() methods (default: none).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetJsonSerializerSettingsTransformationMethod(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.JsonSerializerSettingsTransformationMethod = null;
            return toolSettings;
        }
        #endregion
        #region Namespace
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.Namespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetNamespace(this NSwagSwaggerToCSharpControllerSettings toolSettings, string @namespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Namespace = @namespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.Namespace"/>.</em></p><p>The namespace of the generated classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetNamespace(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Namespace = null;
            return toolSettings;
        }
        #endregion
        #region OperationGenerationMode
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetOperationGenerationMode(this NSwagSwaggerToCSharpControllerSettings toolSettings, OperationGenerationMode operationGenerationMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = operationGenerationMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetOperationGenerationMode(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = null;
            return toolSettings;
        }
        #endregion
        #region ParameterArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ParameterArrayType"/>.</em></p><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetParameterArrayType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string parameterArrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterArrayType = parameterArrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ParameterArrayType"/>.</em></p><p>The generic array .NET type of operation parameters (default: 'IEnumerable').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetParameterArrayType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterArrayType = null;
            return toolSettings;
        }
        #endregion
        #region ParameterDictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ParameterDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetParameterDictionaryType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string parameterDictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDictionaryType = parameterDictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ParameterDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation parameters (default: 'IReadOnlyDictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetParameterDictionaryType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ParameterDictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region RequiredPropertiesMustBeDefined
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetRequiredPropertiesMustBeDefined(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? requiredPropertiesMustBeDefined)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = requiredPropertiesMustBeDefined;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetRequiredPropertiesMustBeDefined(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableRequiredPropertiesMustBeDefined(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableRequiredPropertiesMustBeDefined(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.RequiredPropertiesMustBeDefined"/>.</em></p><p>Specifies whether a required property must be defined in JSON (sets Required.Always when the property is required).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleRequiredPropertiesMustBeDefined(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiredPropertiesMustBeDefined = !toolSettings.RequiredPropertiesMustBeDefined;
            return toolSettings;
        }
        #endregion
        #region ResponseArrayType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ResponseArrayType"/>.</em></p><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetResponseArrayType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string responseArrayType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseArrayType = responseArrayType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ResponseArrayType"/>.</em></p><p>The generic array .NET type of operation responses (default: 'ICollection').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetResponseArrayType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseArrayType = null;
            return toolSettings;
        }
        #endregion
        #region ResponseClass
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetResponseClass(this NSwagSwaggerToCSharpControllerSettings toolSettings, string responseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = responseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetResponseClass(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = null;
            return toolSettings;
        }
        #endregion
        #region ResponseDictionaryType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ResponseDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetResponseDictionaryType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string responseDictionaryType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseDictionaryType = responseDictionaryType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ResponseDictionaryType"/>.</em></p><p>The generic dictionary .NET type of operation responses (default: 'IDictionary').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetResponseDictionaryType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseDictionaryType = null;
            return toolSettings;
        }
        #endregion
        #region TimeSpanType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.TimeSpanType"/>.</em></p><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetTimeSpanType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string timeSpanType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeSpanType = timeSpanType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.TimeSpanType"/>.</em></p><p>The time span .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetTimeSpanType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeSpanType = null;
            return toolSettings;
        }
        #endregion
        #region TimeType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.TimeType"/>.</em></p><p>The time .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetTimeType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string timeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeType = timeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.TimeType"/>.</em></p><p>The time .NET type (default: 'TimeSpan').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetTimeType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeType = null;
            return toolSettings;
        }
        #endregion
        #region WrapResponseMethods
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetWrapResponseMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetWrapResponseMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddWrapResponseMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddWrapResponseMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ClearWrapResponseMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveWrapResponseMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveWrapResponseMethods(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WrapResponses
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetWrapResponses(this NSwagSwaggerToCSharpControllerSettings toolSettings, bool? wrapResponses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = wrapResponses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetWrapResponses(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings EnableWrapResponses(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings DisableWrapResponses(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToCSharpControllerSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ToggleWrapResponses(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = !toolSettings.WrapResponses;
            return toolSettings;
        }
        #endregion
        #region EnumNameGeneratorType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.EnumNameGeneratorType"/>.</em></p><p>The custom IEnumNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetEnumNameGeneratorType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string enumNameGeneratorType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnumNameGeneratorType = enumNameGeneratorType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.EnumNameGeneratorType"/>.</em></p><p>The custom IEnumNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetEnumNameGeneratorType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnumNameGeneratorType = null;
            return toolSettings;
        }
        #endregion
        #region PropertyNameGeneratorType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.PropertyNameGeneratorType"/>.</em></p><p>The custom IPropertyNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetPropertyNameGeneratorType(this NSwagSwaggerToCSharpControllerSettings toolSettings, string propertyNameGeneratorType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertyNameGeneratorType = propertyNameGeneratorType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.PropertyNameGeneratorType"/>.</em></p><p>The custom IPropertyNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetPropertyNameGeneratorType(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertyNameGeneratorType = null;
            return toolSettings;
        }
        #endregion
        #region TemplateDirectory
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetTemplateDirectory(this NSwagSwaggerToCSharpControllerSettings toolSettings, string templateDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = templateDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetTemplateDirectory(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = null;
            return toolSettings;
        }
        #endregion
        #region TypeNameGenerator
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetTypeNameGenerator(this NSwagSwaggerToCSharpControllerSettings toolSettings, string typeNameGenerator)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = typeNameGenerator;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetTypeNameGenerator(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = null;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetInput(this NSwagSwaggerToCSharpControllerSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetInput(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetServiceHost(this NSwagSwaggerToCSharpControllerSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetServiceHost(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetServiceSchemes(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetServiceSchemes(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddServiceSchemes(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToCSharpControllerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings AddServiceSchemes(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToCSharpControllerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ClearServiceSchemes(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveServiceSchemes(this NSwagSwaggerToCSharpControllerSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToCSharpControllerSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings RemoveServiceSchemes(this NSwagSwaggerToCSharpControllerSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToCSharpControllerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings SetOutput(this NSwagSwaggerToCSharpControllerSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToCSharpControllerSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwaggerToCSharpControllerSettings ResetOutput(this NSwagSwaggerToCSharpControllerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NSwagSwaggerToTypeScriptClientSettingsExtensions
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NSwagSwaggerToTypeScriptClientSettingsExtensions
    {
        #region BaseUrlTokenName
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.BaseUrlTokenName"/>.</em></p><p>The token name for injecting the API base URL string (used in the Angular template, default: 'API_BASE_URL').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetBaseUrlTokenName(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string baseUrlTokenName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseUrlTokenName = baseUrlTokenName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.BaseUrlTokenName"/>.</em></p><p>The token name for injecting the API base URL string (used in the Angular template, default: 'API_BASE_URL').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetBaseUrlTokenName(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseUrlTokenName = null;
            return toolSettings;
        }
        #endregion
        #region ClassName
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetClassName(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string className)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = className;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.ClassName"/>.</em></p><p>The class name of the generated client.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetClassName(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassName = null;
            return toolSettings;
        }
        #endregion
        #region ClassTypes
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ClassTypes"/> to a new list.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetClassTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassTypesInternal = classTypes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ClassTypes"/> to a new list.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetClassTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassTypesInternal = classTypes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.ClassTypes"/>.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddClassTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassTypesInternal.AddRange(classTypes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.ClassTypes"/>.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddClassTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassTypesInternal.AddRange(classTypes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToTypeScriptClientSettings.ClassTypes"/>.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ClearClassTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClassTypesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.ClassTypes"/>.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveClassTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(classTypes);
            toolSettings.ClassTypesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.ClassTypes"/>.</em></p><p>The type names which always generate plain TypeScript classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveClassTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> classTypes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(classTypes);
            toolSettings.ClassTypesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ClientBaseClass
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ClientBaseClass"/>.</em></p><p>The base class of the generated client classes (optional, must be imported or implemented in the extension code).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetClientBaseClass(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string clientBaseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientBaseClass = clientBaseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.ClientBaseClass"/>.</em></p><p>The base class of the generated client classes (optional, must be imported or implemented in the extension code).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetClientBaseClass(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientBaseClass = null;
            return toolSettings;
        }
        #endregion
        #region ConfigurationClass
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ConfigurationClass"/>.</em></p><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetConfigurationClass(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string configurationClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationClass = configurationClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.ConfigurationClass"/>.</em></p><p>The configuration class. The setting ClientBaseClass must be set. (empty for no configuration class).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetConfigurationClass(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationClass = null;
            return toolSettings;
        }
        #endregion
        #region ConvertConstructorInterfaceData
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ConvertConstructorInterfaceData"/>.</em></p><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetConvertConstructorInterfaceData(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? convertConstructorInterfaceData)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConvertConstructorInterfaceData = convertConstructorInterfaceData;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.ConvertConstructorInterfaceData"/>.</em></p><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetConvertConstructorInterfaceData(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConvertConstructorInterfaceData = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.ConvertConstructorInterfaceData"/>.</em></p><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableConvertConstructorInterfaceData(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConvertConstructorInterfaceData = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.ConvertConstructorInterfaceData"/>.</em></p><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableConvertConstructorInterfaceData(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConvertConstructorInterfaceData = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.ConvertConstructorInterfaceData"/>.</em></p><p>Convert POJO objects in the constructor data to DTO instances (GenerateConstructorInterface must be enabled, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleConvertConstructorInterfaceData(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConvertConstructorInterfaceData = !toolSettings.ConvertConstructorInterfaceData;
            return toolSettings;
        }
        #endregion
        #region DateTimeType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.DateTimeType"/>.</em></p><p>The date time type ('Date', 'MomentJS', 'OffsetMomentJS', 'string').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetDateTimeType(this NSwagSwaggerToTypeScriptClientSettings toolSettings, TypeScriptDateTimeType dateTimeType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = dateTimeType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.DateTimeType"/>.</em></p><p>The date time type ('Date', 'MomentJS', 'OffsetMomentJS', 'string').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetDateTimeType(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DateTimeType = null;
            return toolSettings;
        }
        #endregion
        #region ExcludedTypeNames
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetExcludedTypeNames(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ExcludedTypeNames"/> to a new list.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetExcludedTypeNames(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal = excludedTypeNames.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddExcludedTypeNames(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddExcludedTypeNames(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.AddRange(excludedTypeNames);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToTypeScriptClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ClearExcludedTypeNames(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTypeNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveExcludedTypeNames(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.ExcludedTypeNames"/>.</em></p><p>The excluded DTO type names (must be defined in an import or other namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveExcludedTypeNames(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> excludedTypeNames)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTypeNames);
            toolSettings.ExcludedTypeNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExtendedClasses
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ExtendedClasses"/> to a new list.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetExtendedClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtendedClassesInternal = extendedClasses.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ExtendedClasses"/> to a new list.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetExtendedClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtendedClassesInternal = extendedClasses.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.ExtendedClasses"/>.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddExtendedClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtendedClassesInternal.AddRange(extendedClasses);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.ExtendedClasses"/>.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddExtendedClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtendedClassesInternal.AddRange(extendedClasses);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToTypeScriptClientSettings.ExtendedClasses"/>.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ClearExtendedClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtendedClassesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.ExtendedClasses"/>.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveExtendedClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extendedClasses);
            toolSettings.ExtendedClassesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.ExtendedClasses"/>.</em></p><p>The list of extended classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveExtendedClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> extendedClasses)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(extendedClasses);
            toolSettings.ExtendedClassesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExtensionCode
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ExtensionCode"/>.</em></p><p>The extension code (string or file path).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetExtensionCode(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string extensionCode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionCode = extensionCode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.ExtensionCode"/>.</em></p><p>The extension code (string or file path).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetExtensionCode(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExtensionCode = null;
            return toolSettings;
        }
        #endregion
        #region GenerateClientClasses
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetGenerateClientClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? generateClientClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = generateClientClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetGenerateClientClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableGenerateClientClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableGenerateClientClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateClientClasses"/>.</em></p><p>Specifies whether generate client classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleGenerateClientClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientClasses = !toolSettings.GenerateClientClasses;
            return toolSettings;
        }
        #endregion
        #region GenerateClientInterfaces
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetGenerateClientInterfaces(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? generateClientInterfaces)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = generateClientInterfaces;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetGenerateClientInterfaces(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableGenerateClientInterfaces(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableGenerateClientInterfaces(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateClientInterfaces"/>.</em></p><p>Specifies whether generate interfaces for the client classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleGenerateClientInterfaces(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateClientInterfaces = !toolSettings.GenerateClientInterfaces;
            return toolSettings;
        }
        #endregion
        #region GenerateCloneMethod
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateCloneMethod"/>.</em></p><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetGenerateCloneMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? generateCloneMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateCloneMethod = generateCloneMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateCloneMethod"/>.</em></p><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetGenerateCloneMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateCloneMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateCloneMethod"/>.</em></p><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableGenerateCloneMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateCloneMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateCloneMethod"/>.</em></p><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableGenerateCloneMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateCloneMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateCloneMethod"/>.</em></p><p>Specifies whether a clone() method should be generated in the DTO classes (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleGenerateCloneMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateCloneMethod = !toolSettings.GenerateCloneMethod;
            return toolSettings;
        }
        #endregion
        #region GenerateConstructorInterface
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateConstructorInterface"/>.</em></p><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetGenerateConstructorInterface(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? generateConstructorInterface)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateConstructorInterface = generateConstructorInterface;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateConstructorInterface"/>.</em></p><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetGenerateConstructorInterface(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateConstructorInterface = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateConstructorInterface"/>.</em></p><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableGenerateConstructorInterface(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateConstructorInterface = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateConstructorInterface"/>.</em></p><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableGenerateConstructorInterface(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateConstructorInterface = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateConstructorInterface"/>.</em></p><p>Generate an class interface which is used in the constructor to initialize the class (only available when TypeStyle is Class, default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleGenerateConstructorInterface(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateConstructorInterface = !toolSettings.GenerateConstructorInterface;
            return toolSettings;
        }
        #endregion
        #region GenerateDefaultValues
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetGenerateDefaultValues(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? generateDefaultValues)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = generateDefaultValues;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetGenerateDefaultValues(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableGenerateDefaultValues(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableGenerateDefaultValues(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateDefaultValues"/>.</em></p><p>Specifies whether to generate default values for properties (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleGenerateDefaultValues(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDefaultValues = !toolSettings.GenerateDefaultValues;
            return toolSettings;
        }
        #endregion
        #region GenerateDtoTypes
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetGenerateDtoTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? generateDtoTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = generateDtoTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetGenerateDtoTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableGenerateDtoTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableGenerateDtoTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateDtoTypes"/>.</em></p><p>Specifies whether to generate DTO classes.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleGenerateDtoTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateDtoTypes = !toolSettings.GenerateDtoTypes;
            return toolSettings;
        }
        #endregion
        #region GenerateOptionalParameters
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetGenerateOptionalParameters(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? generateOptionalParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = generateOptionalParameters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetGenerateOptionalParameters(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableGenerateOptionalParameters(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableGenerateOptionalParameters(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateOptionalParameters"/>.</em></p><p>Specifies whether to reorder parameters (required first, optional at the end) and generate optional parameters (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleGenerateOptionalParameters(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateOptionalParameters = !toolSettings.GenerateOptionalParameters;
            return toolSettings;
        }
        #endregion
        #region GenerateResponseClasses
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetGenerateResponseClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? generateResponseClasses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = generateResponseClasses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetGenerateResponseClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableGenerateResponseClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableGenerateResponseClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.GenerateResponseClasses"/>.</em></p><p>Specifies whether to generate response classes (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleGenerateResponseClasses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateResponseClasses = !toolSettings.GenerateResponseClasses;
            return toolSettings;
        }
        #endregion
        #region HandleReferences
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.HandleReferences"/>.</em></p><p>Handle JSON references (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetHandleReferences(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? handleReferences)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = handleReferences;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.HandleReferences"/>.</em></p><p>Handle JSON references (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetHandleReferences(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.HandleReferences"/>.</em></p><p>Handle JSON references (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableHandleReferences(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.HandleReferences"/>.</em></p><p>Handle JSON references (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableHandleReferences(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.HandleReferences"/>.</em></p><p>Handle JSON references (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleHandleReferences(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HandleReferences = !toolSettings.HandleReferences;
            return toolSettings;
        }
        #endregion
        #region HttpClass
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.HttpClass"/>.</em></p><p>The Angular HTTP service class (default 'Http', 'HttpClient').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetHttpClass(this NSwagSwaggerToTypeScriptClientSettings toolSettings, HttpClass httpClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpClass = httpClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.HttpClass"/>.</em></p><p>The Angular HTTP service class (default 'Http', 'HttpClient').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetHttpClass(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpClass = null;
            return toolSettings;
        }
        #endregion
        #region ImportRequiredTypes
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ImportRequiredTypes"/>.</em></p><p>Specifies whether required types should be imported (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetImportRequiredTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? importRequiredTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportRequiredTypes = importRequiredTypes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.ImportRequiredTypes"/>.</em></p><p>Specifies whether required types should be imported (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetImportRequiredTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportRequiredTypes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.ImportRequiredTypes"/>.</em></p><p>Specifies whether required types should be imported (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableImportRequiredTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportRequiredTypes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.ImportRequiredTypes"/>.</em></p><p>Specifies whether required types should be imported (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableImportRequiredTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportRequiredTypes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.ImportRequiredTypes"/>.</em></p><p>Specifies whether required types should be imported (default: true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleImportRequiredTypes(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportRequiredTypes = !toolSettings.ImportRequiredTypes;
            return toolSettings;
        }
        #endregion
        #region InjectionTokenType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.InjectionTokenType"/>.</em></p><p>The Angular injection token type (default 'OpaqueToken', 'InjectionToken').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetInjectionTokenType(this NSwagSwaggerToTypeScriptClientSettings toolSettings, InjectionTokenType injectionTokenType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectionTokenType = injectionTokenType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.InjectionTokenType"/>.</em></p><p>The Angular injection token type (default 'OpaqueToken', 'InjectionToken').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetInjectionTokenType(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InjectionTokenType = null;
            return toolSettings;
        }
        #endregion
        #region MarkOptionalProperties
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.MarkOptionalProperties"/>.</em></p><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetMarkOptionalProperties(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? markOptionalProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkOptionalProperties = markOptionalProperties;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.MarkOptionalProperties"/>.</em></p><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetMarkOptionalProperties(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkOptionalProperties = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.MarkOptionalProperties"/>.</em></p><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableMarkOptionalProperties(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkOptionalProperties = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.MarkOptionalProperties"/>.</em></p><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableMarkOptionalProperties(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkOptionalProperties = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.MarkOptionalProperties"/>.</em></p><p>Specifies whether to mark optional properties with ? (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleMarkOptionalProperties(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkOptionalProperties = !toolSettings.MarkOptionalProperties;
            return toolSettings;
        }
        #endregion
        #region ModuleName
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ModuleName"/>.</em></p><p>The TypeScript module name (default: '', no module).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetModuleName(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string moduleName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ModuleName = moduleName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.ModuleName"/>.</em></p><p>The TypeScript module name (default: '', no module).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetModuleName(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ModuleName = null;
            return toolSettings;
        }
        #endregion
        #region Namespace
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.Namespace"/>.</em></p><p>The TypeScript namespace (default: '', no namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetNamespace(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string @namespace)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Namespace = @namespace;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.Namespace"/>.</em></p><p>The TypeScript namespace (default: '', no namespace).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetNamespace(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Namespace = null;
            return toolSettings;
        }
        #endregion
        #region NullValue
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.NullValue"/>.</em></p><p>The null value used in object initializers (default 'Undefined', 'Null').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetNullValue(this NSwagSwaggerToTypeScriptClientSettings toolSettings, TypeScriptNullValue nullValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NullValue = nullValue;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.NullValue"/>.</em></p><p>The null value used in object initializers (default 'Undefined', 'Null').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetNullValue(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NullValue = null;
            return toolSettings;
        }
        #endregion
        #region OperationGenerationMode
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetOperationGenerationMode(this NSwagSwaggerToTypeScriptClientSettings toolSettings, OperationGenerationMode operationGenerationMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = operationGenerationMode;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.OperationGenerationMode"/>.</em></p><p>The operation generation mode ('SingleClientFromOperationId' or 'MultipleClientsFromPathSegments').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetOperationGenerationMode(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OperationGenerationMode = null;
            return toolSettings;
        }
        #endregion
        #region PromiseType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.PromiseType"/>.</em></p><p>The promise type ('Promise' or 'QPromise').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetPromiseType(this NSwagSwaggerToTypeScriptClientSettings toolSettings, PromiseType promiseType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PromiseType = promiseType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.PromiseType"/>.</em></p><p>The promise type ('Promise' or 'QPromise').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetPromiseType(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PromiseType = null;
            return toolSettings;
        }
        #endregion
        #region ProtectedMethods
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ProtectedMethods"/> to a new list.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetProtectedMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal = protectedMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ProtectedMethods"/> to a new list.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetProtectedMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal = protectedMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddProtectedMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.AddRange(protectedMethods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddProtectedMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.AddRange(protectedMethods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToTypeScriptClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ClearProtectedMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProtectedMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveProtectedMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(protectedMethods);
            toolSettings.ProtectedMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.ProtectedMethods"/>.</em></p><p>List of methods with a protected access modifier ('classname.methodname').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveProtectedMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> protectedMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(protectedMethods);
            toolSettings.ProtectedMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region QueryNullValue
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.QueryNullValue"/>.</em></p><p>The null value used for query parameters which are null (default: '').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetQueryNullValue(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string queryNullValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QueryNullValue = queryNullValue;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.QueryNullValue"/>.</em></p><p>The null value used for query parameters which are null (default: '').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetQueryNullValue(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QueryNullValue = null;
            return toolSettings;
        }
        #endregion
        #region ResponseClass
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetResponseClass(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string responseClass)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = responseClass;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.ResponseClass"/>.</em></p><p>The response class (default 'SwaggerResponse', may use '{controller}' placeholder).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetResponseClass(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResponseClass = null;
            return toolSettings;
        }
        #endregion
        #region RxJsVersion
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.RxJsVersion"/>.</em></p><p>The target RxJs version (default: 5.0).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetRxJsVersion(this NSwagSwaggerToTypeScriptClientSettings toolSettings, decimal? rxJsVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RxJsVersion = rxJsVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.RxJsVersion"/>.</em></p><p>The target RxJs version (default: 5.0).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetRxJsVersion(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RxJsVersion = null;
            return toolSettings;
        }
        #endregion
        #region Template
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.Template"/>.</em></p><p>The type of the asynchronism handling ('JQueryCallbacks', 'JQueryPromises', 'AngularJS', 'Angular', 'Fetch', 'Aurelia').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetTemplate(this NSwagSwaggerToTypeScriptClientSettings toolSettings, TypeScriptTemplate template)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Template = template;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.Template"/>.</em></p><p>The type of the asynchronism handling ('JQueryCallbacks', 'JQueryPromises', 'AngularJS', 'Angular', 'Fetch', 'Aurelia').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetTemplate(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Template = null;
            return toolSettings;
        }
        #endregion
        #region TypeScriptVersion
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.TypeScriptVersion"/>.</em></p><p>The target TypeScript version (default: 1.8).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetTypeScriptVersion(this NSwagSwaggerToTypeScriptClientSettings toolSettings, decimal? typeScriptVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeScriptVersion = typeScriptVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.TypeScriptVersion"/>.</em></p><p>The target TypeScript version (default: 1.8).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetTypeScriptVersion(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeScriptVersion = null;
            return toolSettings;
        }
        #endregion
        #region TypeStyle
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.TypeStyle"/>.</em></p><p>The type style (default: Class).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetTypeStyle(this NSwagSwaggerToTypeScriptClientSettings toolSettings, TypeScriptTypeStyle typeStyle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeStyle = typeStyle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.TypeStyle"/>.</em></p><p>The type style (default: Class).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetTypeStyle(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeStyle = null;
            return toolSettings;
        }
        #endregion
        #region UseGetBaseUrlMethod
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.UseGetBaseUrlMethod"/>.</em></p><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetUseGetBaseUrlMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? useGetBaseUrlMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseGetBaseUrlMethod = useGetBaseUrlMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.UseGetBaseUrlMethod"/>.</em></p><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetUseGetBaseUrlMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseGetBaseUrlMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.UseGetBaseUrlMethod"/>.</em></p><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableUseGetBaseUrlMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseGetBaseUrlMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.UseGetBaseUrlMethod"/>.</em></p><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableUseGetBaseUrlMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseGetBaseUrlMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.UseGetBaseUrlMethod"/>.</em></p><p>Specifies whether to use the 'getBaseUrl(defaultUrl: string)' method from the base class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleUseGetBaseUrlMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseGetBaseUrlMethod = !toolSettings.UseGetBaseUrlMethod;
            return toolSettings;
        }
        #endregion
        #region UseSingletonProvider
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.UseSingletonProvider"/>.</em></p><p>Specifies whether to use the Angular 6 Singleton Provider (Angular template only, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetUseSingletonProvider(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? useSingletonProvider)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSingletonProvider = useSingletonProvider;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.UseSingletonProvider"/>.</em></p><p>Specifies whether to use the Angular 6 Singleton Provider (Angular template only, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetUseSingletonProvider(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSingletonProvider = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.UseSingletonProvider"/>.</em></p><p>Specifies whether to use the Angular 6 Singleton Provider (Angular template only, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableUseSingletonProvider(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSingletonProvider = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.UseSingletonProvider"/>.</em></p><p>Specifies whether to use the Angular 6 Singleton Provider (Angular template only, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableUseSingletonProvider(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSingletonProvider = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.UseSingletonProvider"/>.</em></p><p>Specifies whether to use the Angular 6 Singleton Provider (Angular template only, default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleUseSingletonProvider(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseSingletonProvider = !toolSettings.UseSingletonProvider;
            return toolSettings;
        }
        #endregion
        #region UseTransformOptionsMethod
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.UseTransformOptionsMethod"/>.</em></p><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetUseTransformOptionsMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? useTransformOptionsMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformOptionsMethod = useTransformOptionsMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.UseTransformOptionsMethod"/>.</em></p><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetUseTransformOptionsMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformOptionsMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.UseTransformOptionsMethod"/>.</em></p><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableUseTransformOptionsMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformOptionsMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.UseTransformOptionsMethod"/>.</em></p><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableUseTransformOptionsMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformOptionsMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.UseTransformOptionsMethod"/>.</em></p><p>Call 'transformOptions' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleUseTransformOptionsMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformOptionsMethod = !toolSettings.UseTransformOptionsMethod;
            return toolSettings;
        }
        #endregion
        #region UseTransformResultMethod
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.UseTransformResultMethod"/>.</em></p><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetUseTransformResultMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? useTransformResultMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformResultMethod = useTransformResultMethod;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.UseTransformResultMethod"/>.</em></p><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetUseTransformResultMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformResultMethod = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.UseTransformResultMethod"/>.</em></p><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableUseTransformResultMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformResultMethod = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.UseTransformResultMethod"/>.</em></p><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableUseTransformResultMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformResultMethod = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.UseTransformResultMethod"/>.</em></p><p>Call 'transformResult' on the base class or extension class (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleUseTransformResultMethod(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseTransformResultMethod = !toolSettings.UseTransformResultMethod;
            return toolSettings;
        }
        #endregion
        #region WrapDtoExceptions
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetWrapDtoExceptions(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? wrapDtoExceptions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = wrapDtoExceptions;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetWrapDtoExceptions(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableWrapDtoExceptions(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableWrapDtoExceptions(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapDtoExceptions"/>.</em></p><p>Specifies whether DTO exceptions are wrapped in a SwaggerException instance (default: false).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleWrapDtoExceptions(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapDtoExceptions = !toolSettings.WrapDtoExceptions;
            return toolSettings;
        }
        #endregion
        #region WrapResponseMethods
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetWrapResponseMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponseMethods"/> to a new list.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetWrapResponseMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal = wrapResponseMethods.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddWrapResponseMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddWrapResponseMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.AddRange(wrapResponseMethods);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ClearWrapResponseMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponseMethodsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveWrapResponseMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponseMethods"/>.</em></p><p>List of methods where responses are wrapped ('ControllerName.MethodName', WrapResponses must be true).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveWrapResponseMethods(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> wrapResponseMethods)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(wrapResponseMethods);
            toolSettings.WrapResponseMethodsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WrapResponses
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetWrapResponses(this NSwagSwaggerToTypeScriptClientSettings toolSettings, bool? wrapResponses)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = wrapResponses;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetWrapResponses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings EnableWrapResponses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings DisableWrapResponses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NSwagSwaggerToTypeScriptClientSettings.WrapResponses"/>.</em></p><p>Specifies whether to wrap success responses to allow full response access (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ToggleWrapResponses(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WrapResponses = !toolSettings.WrapResponses;
            return toolSettings;
        }
        #endregion
        #region EnumNameGeneratorType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.EnumNameGeneratorType"/>.</em></p><p>The custom IEnumNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetEnumNameGeneratorType(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string enumNameGeneratorType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnumNameGeneratorType = enumNameGeneratorType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.EnumNameGeneratorType"/>.</em></p><p>The custom IEnumNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetEnumNameGeneratorType(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnumNameGeneratorType = null;
            return toolSettings;
        }
        #endregion
        #region PropertyNameGeneratorType
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.PropertyNameGeneratorType"/>.</em></p><p>The custom IPropertyNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetPropertyNameGeneratorType(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string propertyNameGeneratorType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertyNameGeneratorType = propertyNameGeneratorType;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.PropertyNameGeneratorType"/>.</em></p><p>The custom IPropertyNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetPropertyNameGeneratorType(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertyNameGeneratorType = null;
            return toolSettings;
        }
        #endregion
        #region TemplateDirectory
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetTemplateDirectory(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string templateDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = templateDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.TemplateDirectory"/>.</em></p><p>The Liquid template directory (experimental).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetTemplateDirectory(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateDirectory = null;
            return toolSettings;
        }
        #endregion
        #region TypeNameGenerator
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetTypeNameGenerator(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string typeNameGenerator)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = typeNameGenerator;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.TypeNameGenerator"/>.</em></p><p>The custom ITypeNameGenerator implementation type in the form 'assemblyName:fullTypeName' or 'fullTypeName').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetTypeNameGenerator(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TypeNameGenerator = null;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetInput(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string input)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.Input"/>.</em></p><p>A file path or URL to the data or the JSON data itself.</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetInput(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region ServiceHost
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetServiceHost(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string serviceHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = serviceHost;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.ServiceHost"/>.</em></p><p>Overrides the service host of the web document (optional, use '.' to remove the hostname).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetServiceHost(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceHost = null;
            return toolSettings;
        }
        #endregion
        #region ServiceSchemes
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetServiceSchemes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.ServiceSchemes"/> to a new list.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetServiceSchemes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal = serviceSchemes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddServiceSchemes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NSwagSwaggerToTypeScriptClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings AddServiceSchemes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.AddRange(serviceSchemes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NSwagSwaggerToTypeScriptClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ClearServiceSchemes(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceSchemesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveServiceSchemes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, params string[] serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NSwagSwaggerToTypeScriptClientSettings.ServiceSchemes"/>.</em></p><p>Overrides the allowed schemes of the web service (optional, comma separated, 'http', 'https', 'ws', 'wss').</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings RemoveServiceSchemes(this NSwagSwaggerToTypeScriptClientSettings toolSettings, IEnumerable<string> serviceSchemes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(serviceSchemes);
            toolSettings.ServiceSchemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="NSwagSwaggerToTypeScriptClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings SetOutput(this NSwagSwaggerToTypeScriptClientSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NSwagSwaggerToTypeScriptClientSettings.Output"/>.</em></p><p>The output file path (optional).</p></summary>
        [Pure]
        public static NSwagSwaggerToTypeScriptClientSettings ResetOutput(this NSwagSwaggerToTypeScriptClientSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region SchemaType
    /// <summary><p>Used within <see cref="NSwagTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class SchemaType : Enumeration
    {
        public static SchemaType JsonSchema = new SchemaType { Value = "JsonSchema" };
        public static SchemaType Swagger2 = new SchemaType { Value = "Swagger2" };
        public static SchemaType OpenApi3 = new SchemaType { Value = "OpenApi3" };
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
        public static CSharpClassStyle Prism = new CSharpClassStyle { Value = "Prism" };
        public static CSharpClassStyle Record = new CSharpClassStyle { Value = "Record" };
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
