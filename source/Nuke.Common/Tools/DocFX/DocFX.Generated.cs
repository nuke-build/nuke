// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/DocFX.json

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

namespace Nuke.Common.Tools.DocFX
{
    /// <summary>
    ///   <p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <em>github.io</em>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p>
    ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXTasks
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public static string DocFXPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("DOCFX_EXE") ??
            ToolPathResolver.GetPackageExecutable("docfx.console", "docfx.exe");
        public static Action<OutputType, string> DocFXLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <em>github.io</em>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DocFX(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(DocFXPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, DocFXLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generate client-only website combining API in YAML files and conceptual files.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configFile&gt;</c> via <see cref="DocFXBuildSettings.ConfigFile"/></li>
        ///     <li><c>--changesFile</c> via <see cref="DocFXBuildSettings.ChangesFile"/></li>
        ///     <li><c>--cleanupCacheHistory</c> via <see cref="DocFXBuildSettings.CleanupCacheHistory"/></li>
        ///     <li><c>--content</c> via <see cref="DocFXBuildSettings.Content"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXBuildSettings.CorrelationId"/></li>
        ///     <li><c>--debug</c> via <see cref="DocFXBuildSettings.EnableDebugMode"/></li>
        ///     <li><c>--debugOutput</c> via <see cref="DocFXBuildSettings.OutputFolderForDebugFiles"/></li>
        ///     <li><c>--disableGitFeatures</c> via <see cref="DocFXBuildSettings.DisableGitFeatures"/></li>
        ///     <li><c>--dryRun</c> via <see cref="DocFXBuildSettings.DryRun"/></li>
        ///     <li><c>--exportRawModel</c> via <see cref="DocFXBuildSettings.ExportRawModel"/></li>
        ///     <li><c>--exportViewModel</c> via <see cref="DocFXBuildSettings.ExportViewModel"/></li>
        ///     <li><c>--falName</c> via <see cref="DocFXBuildSettings.FALName"/></li>
        ///     <li><c>--fileMetadataFile</c> via <see cref="DocFXBuildSettings.FileMetadataFilePath"/></li>
        ///     <li><c>--fileMetadataFiles</c> via <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></li>
        ///     <li><c>--force</c> via <see cref="DocFXBuildSettings.ForceRebuild"/></li>
        ///     <li><c>--forcePostProcess</c> via <see cref="DocFXBuildSettings.ForcePostProcess"/></li>
        ///     <li><c>--globalMetadata</c> via <see cref="DocFXBuildSettings.GlobalMetadata"/></li>
        ///     <li><c>--globalMetadataFile</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePath"/></li>
        ///     <li><c>--globalMetadataFiles</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXBuildSettings.PrintHelpMessage"/></li>
        ///     <li><c>--hostname</c> via <see cref="DocFXBuildSettings.Host"/></li>
        ///     <li><c>--intermediateFolder</c> via <see cref="DocFXBuildSettings.IntermediateFolder"/></li>
        ///     <li><c>--keepFileLink</c> via <see cref="DocFXBuildSettings.KeepFileLink"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXBuildSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXBuildSettings.LogLevel"/></li>
        ///     <li><c>--lruSize</c> via <see cref="DocFXBuildSettings.LruSize"/></li>
        ///     <li><c>--markdownEngineName</c> via <see cref="DocFXBuildSettings.MarkdownEngineName"/></li>
        ///     <li><c>--markdownEngineProperties</c> via <see cref="DocFXBuildSettings.MarkdownEngineProperties"/></li>
        ///     <li><c>--maxParallelism</c> via <see cref="DocFXBuildSettings.MaxParallelism"/></li>
        ///     <li><c>--noLangKeyword</c> via <see cref="DocFXBuildSettings.NoLangKeyword"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXBuildSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="DocFXBuildSettings.Overwrite"/></li>
        ///     <li><c>--port</c> via <see cref="DocFXBuildSettings.Port"/></li>
        ///     <li><c>--postProcessors</c> via <see cref="DocFXBuildSettings.PostProcessors"/></li>
        ///     <li><c>--rawModelOutputFolder</c> via <see cref="DocFXBuildSettings.RawModelOutputFolder"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXBuildSettings.RepoRoot"/></li>
        ///     <li><c>--resource</c> via <see cref="DocFXBuildSettings.Resource"/></li>
        ///     <li><c>--schemaLicense</c> via <see cref="DocFXBuildSettings.SchemaLicense"/></li>
        ///     <li><c>--serve</c> via <see cref="DocFXBuildSettings.Serve"/></li>
        ///     <li><c>--template</c> via <see cref="DocFXBuildSettings.Templates"/></li>
        ///     <li><c>--theme</c> via <see cref="DocFXBuildSettings.Themes"/></li>
        ///     <li><c>--viewModelOutputFolder</c> via <see cref="DocFXBuildSettings.ViewModelOutputFolder"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXBuildSettings.WarningsAsErrors"/></li>
        ///     <li><c>--xref</c> via <see cref="DocFXBuildSettings.XRefMaps"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXBuild(DocFXBuildSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DocFXBuildSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generate client-only website combining API in YAML files and conceptual files.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configFile&gt;</c> via <see cref="DocFXBuildSettings.ConfigFile"/></li>
        ///     <li><c>--changesFile</c> via <see cref="DocFXBuildSettings.ChangesFile"/></li>
        ///     <li><c>--cleanupCacheHistory</c> via <see cref="DocFXBuildSettings.CleanupCacheHistory"/></li>
        ///     <li><c>--content</c> via <see cref="DocFXBuildSettings.Content"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXBuildSettings.CorrelationId"/></li>
        ///     <li><c>--debug</c> via <see cref="DocFXBuildSettings.EnableDebugMode"/></li>
        ///     <li><c>--debugOutput</c> via <see cref="DocFXBuildSettings.OutputFolderForDebugFiles"/></li>
        ///     <li><c>--disableGitFeatures</c> via <see cref="DocFXBuildSettings.DisableGitFeatures"/></li>
        ///     <li><c>--dryRun</c> via <see cref="DocFXBuildSettings.DryRun"/></li>
        ///     <li><c>--exportRawModel</c> via <see cref="DocFXBuildSettings.ExportRawModel"/></li>
        ///     <li><c>--exportViewModel</c> via <see cref="DocFXBuildSettings.ExportViewModel"/></li>
        ///     <li><c>--falName</c> via <see cref="DocFXBuildSettings.FALName"/></li>
        ///     <li><c>--fileMetadataFile</c> via <see cref="DocFXBuildSettings.FileMetadataFilePath"/></li>
        ///     <li><c>--fileMetadataFiles</c> via <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></li>
        ///     <li><c>--force</c> via <see cref="DocFXBuildSettings.ForceRebuild"/></li>
        ///     <li><c>--forcePostProcess</c> via <see cref="DocFXBuildSettings.ForcePostProcess"/></li>
        ///     <li><c>--globalMetadata</c> via <see cref="DocFXBuildSettings.GlobalMetadata"/></li>
        ///     <li><c>--globalMetadataFile</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePath"/></li>
        ///     <li><c>--globalMetadataFiles</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXBuildSettings.PrintHelpMessage"/></li>
        ///     <li><c>--hostname</c> via <see cref="DocFXBuildSettings.Host"/></li>
        ///     <li><c>--intermediateFolder</c> via <see cref="DocFXBuildSettings.IntermediateFolder"/></li>
        ///     <li><c>--keepFileLink</c> via <see cref="DocFXBuildSettings.KeepFileLink"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXBuildSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXBuildSettings.LogLevel"/></li>
        ///     <li><c>--lruSize</c> via <see cref="DocFXBuildSettings.LruSize"/></li>
        ///     <li><c>--markdownEngineName</c> via <see cref="DocFXBuildSettings.MarkdownEngineName"/></li>
        ///     <li><c>--markdownEngineProperties</c> via <see cref="DocFXBuildSettings.MarkdownEngineProperties"/></li>
        ///     <li><c>--maxParallelism</c> via <see cref="DocFXBuildSettings.MaxParallelism"/></li>
        ///     <li><c>--noLangKeyword</c> via <see cref="DocFXBuildSettings.NoLangKeyword"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXBuildSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="DocFXBuildSettings.Overwrite"/></li>
        ///     <li><c>--port</c> via <see cref="DocFXBuildSettings.Port"/></li>
        ///     <li><c>--postProcessors</c> via <see cref="DocFXBuildSettings.PostProcessors"/></li>
        ///     <li><c>--rawModelOutputFolder</c> via <see cref="DocFXBuildSettings.RawModelOutputFolder"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXBuildSettings.RepoRoot"/></li>
        ///     <li><c>--resource</c> via <see cref="DocFXBuildSettings.Resource"/></li>
        ///     <li><c>--schemaLicense</c> via <see cref="DocFXBuildSettings.SchemaLicense"/></li>
        ///     <li><c>--serve</c> via <see cref="DocFXBuildSettings.Serve"/></li>
        ///     <li><c>--template</c> via <see cref="DocFXBuildSettings.Templates"/></li>
        ///     <li><c>--theme</c> via <see cref="DocFXBuildSettings.Themes"/></li>
        ///     <li><c>--viewModelOutputFolder</c> via <see cref="DocFXBuildSettings.ViewModelOutputFolder"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXBuildSettings.WarningsAsErrors"/></li>
        ///     <li><c>--xref</c> via <see cref="DocFXBuildSettings.XRefMaps"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXBuild(Configure<DocFXBuildSettings> configurator)
        {
            return DocFXBuild(configurator(new DocFXBuildSettings()));
        }
        /// <summary>
        ///   <p>Generate client-only website combining API in YAML files and conceptual files.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configFile&gt;</c> via <see cref="DocFXBuildSettings.ConfigFile"/></li>
        ///     <li><c>--changesFile</c> via <see cref="DocFXBuildSettings.ChangesFile"/></li>
        ///     <li><c>--cleanupCacheHistory</c> via <see cref="DocFXBuildSettings.CleanupCacheHistory"/></li>
        ///     <li><c>--content</c> via <see cref="DocFXBuildSettings.Content"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXBuildSettings.CorrelationId"/></li>
        ///     <li><c>--debug</c> via <see cref="DocFXBuildSettings.EnableDebugMode"/></li>
        ///     <li><c>--debugOutput</c> via <see cref="DocFXBuildSettings.OutputFolderForDebugFiles"/></li>
        ///     <li><c>--disableGitFeatures</c> via <see cref="DocFXBuildSettings.DisableGitFeatures"/></li>
        ///     <li><c>--dryRun</c> via <see cref="DocFXBuildSettings.DryRun"/></li>
        ///     <li><c>--exportRawModel</c> via <see cref="DocFXBuildSettings.ExportRawModel"/></li>
        ///     <li><c>--exportViewModel</c> via <see cref="DocFXBuildSettings.ExportViewModel"/></li>
        ///     <li><c>--falName</c> via <see cref="DocFXBuildSettings.FALName"/></li>
        ///     <li><c>--fileMetadataFile</c> via <see cref="DocFXBuildSettings.FileMetadataFilePath"/></li>
        ///     <li><c>--fileMetadataFiles</c> via <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></li>
        ///     <li><c>--force</c> via <see cref="DocFXBuildSettings.ForceRebuild"/></li>
        ///     <li><c>--forcePostProcess</c> via <see cref="DocFXBuildSettings.ForcePostProcess"/></li>
        ///     <li><c>--globalMetadata</c> via <see cref="DocFXBuildSettings.GlobalMetadata"/></li>
        ///     <li><c>--globalMetadataFile</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePath"/></li>
        ///     <li><c>--globalMetadataFiles</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXBuildSettings.PrintHelpMessage"/></li>
        ///     <li><c>--hostname</c> via <see cref="DocFXBuildSettings.Host"/></li>
        ///     <li><c>--intermediateFolder</c> via <see cref="DocFXBuildSettings.IntermediateFolder"/></li>
        ///     <li><c>--keepFileLink</c> via <see cref="DocFXBuildSettings.KeepFileLink"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXBuildSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXBuildSettings.LogLevel"/></li>
        ///     <li><c>--lruSize</c> via <see cref="DocFXBuildSettings.LruSize"/></li>
        ///     <li><c>--markdownEngineName</c> via <see cref="DocFXBuildSettings.MarkdownEngineName"/></li>
        ///     <li><c>--markdownEngineProperties</c> via <see cref="DocFXBuildSettings.MarkdownEngineProperties"/></li>
        ///     <li><c>--maxParallelism</c> via <see cref="DocFXBuildSettings.MaxParallelism"/></li>
        ///     <li><c>--noLangKeyword</c> via <see cref="DocFXBuildSettings.NoLangKeyword"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXBuildSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="DocFXBuildSettings.Overwrite"/></li>
        ///     <li><c>--port</c> via <see cref="DocFXBuildSettings.Port"/></li>
        ///     <li><c>--postProcessors</c> via <see cref="DocFXBuildSettings.PostProcessors"/></li>
        ///     <li><c>--rawModelOutputFolder</c> via <see cref="DocFXBuildSettings.RawModelOutputFolder"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXBuildSettings.RepoRoot"/></li>
        ///     <li><c>--resource</c> via <see cref="DocFXBuildSettings.Resource"/></li>
        ///     <li><c>--schemaLicense</c> via <see cref="DocFXBuildSettings.SchemaLicense"/></li>
        ///     <li><c>--serve</c> via <see cref="DocFXBuildSettings.Serve"/></li>
        ///     <li><c>--template</c> via <see cref="DocFXBuildSettings.Templates"/></li>
        ///     <li><c>--theme</c> via <see cref="DocFXBuildSettings.Themes"/></li>
        ///     <li><c>--viewModelOutputFolder</c> via <see cref="DocFXBuildSettings.ViewModelOutputFolder"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXBuildSettings.WarningsAsErrors"/></li>
        ///     <li><c>--xref</c> via <see cref="DocFXBuildSettings.XRefMaps"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DocFXBuildSettings Settings, IReadOnlyCollection<Output> Output)> DocFXBuild(CombinatorialConfigure<DocFXBuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DocFXBuild, DocFXLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Export dependency file.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;dependencyFile&gt;</c> via <see cref="DocFXDependencySettings.DependencyFile"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXDependencySettings.PrintHelpMessage"/></li>
        ///     <li><c>--intermediateFolder</c> via <see cref="DocFXDependencySettings.IntermediateFolder"/></li>
        ///     <li><c>--version</c> via <see cref="DocFXDependencySettings.VersionName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXDependency(DocFXDependencySettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DocFXDependencySettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Export dependency file.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;dependencyFile&gt;</c> via <see cref="DocFXDependencySettings.DependencyFile"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXDependencySettings.PrintHelpMessage"/></li>
        ///     <li><c>--intermediateFolder</c> via <see cref="DocFXDependencySettings.IntermediateFolder"/></li>
        ///     <li><c>--version</c> via <see cref="DocFXDependencySettings.VersionName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXDependency(Configure<DocFXDependencySettings> configurator)
        {
            return DocFXDependency(configurator(new DocFXDependencySettings()));
        }
        /// <summary>
        ///   <p>Export dependency file.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;dependencyFile&gt;</c> via <see cref="DocFXDependencySettings.DependencyFile"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXDependencySettings.PrintHelpMessage"/></li>
        ///     <li><c>--intermediateFolder</c> via <see cref="DocFXDependencySettings.IntermediateFolder"/></li>
        ///     <li><c>--version</c> via <see cref="DocFXDependencySettings.VersionName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DocFXDependencySettings Settings, IReadOnlyCollection<Output> Output)> DocFXDependency(CombinatorialConfigure<DocFXDependencySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DocFXDependency, DocFXLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Download remote xref map file and create an xref archive in local.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;archiveFile&gt;</c> via <see cref="DocFXDownloadSettings.ArchiveFile"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXDownloadSettings.PrintHelpMessage"/></li>
        ///     <li><c>--xref</c> via <see cref="DocFXDownloadSettings.Uri"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXDownload(DocFXDownloadSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DocFXDownloadSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Download remote xref map file and create an xref archive in local.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;archiveFile&gt;</c> via <see cref="DocFXDownloadSettings.ArchiveFile"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXDownloadSettings.PrintHelpMessage"/></li>
        ///     <li><c>--xref</c> via <see cref="DocFXDownloadSettings.Uri"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXDownload(Configure<DocFXDownloadSettings> configurator)
        {
            return DocFXDownload(configurator(new DocFXDownloadSettings()));
        }
        /// <summary>
        ///   <p>Download remote xref map file and create an xref archive in local.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;archiveFile&gt;</c> via <see cref="DocFXDownloadSettings.ArchiveFile"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXDownloadSettings.PrintHelpMessage"/></li>
        ///     <li><c>--xref</c> via <see cref="DocFXDownloadSettings.Uri"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DocFXDownloadSettings Settings, IReadOnlyCollection<Output> Output)> DocFXDownload(CombinatorialConfigure<DocFXDownloadSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DocFXDownload, DocFXLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Get an overall guide for the command and sub-commands.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;command&gt;</c> via <see cref="DocFXHelpSettings.Command"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXHelp(DocFXHelpSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DocFXHelpSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Get an overall guide for the command and sub-commands.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;command&gt;</c> via <see cref="DocFXHelpSettings.Command"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXHelp(Configure<DocFXHelpSettings> configurator)
        {
            return DocFXHelp(configurator(new DocFXHelpSettings()));
        }
        /// <summary>
        ///   <p>Get an overall guide for the command and sub-commands.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;command&gt;</c> via <see cref="DocFXHelpSettings.Command"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DocFXHelpSettings Settings, IReadOnlyCollection<Output> Output)> DocFXHelp(CombinatorialConfigure<DocFXHelpSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DocFXHelp, DocFXLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Generate an initial docfx.json following the instructions.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiGlobPattern</c> via <see cref="DocFXInitSettings.ApiSourceGlobPattern"/></li>
        ///     <li><c>--apiSourceFolder</c> via <see cref="DocFXInitSettings.ApiSourceFolder"/></li>
        ///     <li><c>--file</c> via <see cref="DocFXInitSettings.OnlyConfigFile"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXInitSettings.PrintHelpMessage"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXInitSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="DocFXInitSettings.Overwrite"/></li>
        ///     <li><c>--quiet</c> via <see cref="DocFXInitSettings.Quiet"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXInit(DocFXInitSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DocFXInitSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generate an initial docfx.json following the instructions.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiGlobPattern</c> via <see cref="DocFXInitSettings.ApiSourceGlobPattern"/></li>
        ///     <li><c>--apiSourceFolder</c> via <see cref="DocFXInitSettings.ApiSourceFolder"/></li>
        ///     <li><c>--file</c> via <see cref="DocFXInitSettings.OnlyConfigFile"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXInitSettings.PrintHelpMessage"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXInitSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="DocFXInitSettings.Overwrite"/></li>
        ///     <li><c>--quiet</c> via <see cref="DocFXInitSettings.Quiet"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXInit(Configure<DocFXInitSettings> configurator)
        {
            return DocFXInit(configurator(new DocFXInitSettings()));
        }
        /// <summary>
        ///   <p>Generate an initial docfx.json following the instructions.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiGlobPattern</c> via <see cref="DocFXInitSettings.ApiSourceGlobPattern"/></li>
        ///     <li><c>--apiSourceFolder</c> via <see cref="DocFXInitSettings.ApiSourceFolder"/></li>
        ///     <li><c>--file</c> via <see cref="DocFXInitSettings.OnlyConfigFile"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXInitSettings.PrintHelpMessage"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXInitSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="DocFXInitSettings.Overwrite"/></li>
        ///     <li><c>--quiet</c> via <see cref="DocFXInitSettings.Quiet"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DocFXInitSettings Settings, IReadOnlyCollection<Output> Output)> DocFXInit(CombinatorialConfigure<DocFXInitSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DocFXInit, DocFXLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Merge .net base API in YAML files and toc files.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configFile&gt;</c> via <see cref="DocFXMergeSettings.ConfigFile"/></li>
        ///     <li><c>--content</c> via <see cref="DocFXMergeSettings.Content"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXMergeSettings.CorrelationId"/></li>
        ///     <li><c>--fileMetadataFile</c> via <see cref="DocFXMergeSettings.FileMetadataFilePath"/></li>
        ///     <li><c>--globalMetadata</c> via <see cref="DocFXMergeSettings.GlobalMetadata"/></li>
        ///     <li><c>--globalMetadataFile</c> via <see cref="DocFXMergeSettings.GlobalMetadataFilePath"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXMergeSettings.PrintHelpMessage"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXMergeSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXMergeSettings.LogLevel"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXMergeSettings.RepoRoot"/></li>
        ///     <li><c>--tocMetadata</c> via <see cref="DocFXMergeSettings.TocMetadata"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXMergeSettings.WarningsAsErrors"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXMerge(DocFXMergeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DocFXMergeSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Merge .net base API in YAML files and toc files.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configFile&gt;</c> via <see cref="DocFXMergeSettings.ConfigFile"/></li>
        ///     <li><c>--content</c> via <see cref="DocFXMergeSettings.Content"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXMergeSettings.CorrelationId"/></li>
        ///     <li><c>--fileMetadataFile</c> via <see cref="DocFXMergeSettings.FileMetadataFilePath"/></li>
        ///     <li><c>--globalMetadata</c> via <see cref="DocFXMergeSettings.GlobalMetadata"/></li>
        ///     <li><c>--globalMetadataFile</c> via <see cref="DocFXMergeSettings.GlobalMetadataFilePath"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXMergeSettings.PrintHelpMessage"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXMergeSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXMergeSettings.LogLevel"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXMergeSettings.RepoRoot"/></li>
        ///     <li><c>--tocMetadata</c> via <see cref="DocFXMergeSettings.TocMetadata"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXMergeSettings.WarningsAsErrors"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXMerge(Configure<DocFXMergeSettings> configurator)
        {
            return DocFXMerge(configurator(new DocFXMergeSettings()));
        }
        /// <summary>
        ///   <p>Merge .net base API in YAML files and toc files.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configFile&gt;</c> via <see cref="DocFXMergeSettings.ConfigFile"/></li>
        ///     <li><c>--content</c> via <see cref="DocFXMergeSettings.Content"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXMergeSettings.CorrelationId"/></li>
        ///     <li><c>--fileMetadataFile</c> via <see cref="DocFXMergeSettings.FileMetadataFilePath"/></li>
        ///     <li><c>--globalMetadata</c> via <see cref="DocFXMergeSettings.GlobalMetadata"/></li>
        ///     <li><c>--globalMetadataFile</c> via <see cref="DocFXMergeSettings.GlobalMetadataFilePath"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXMergeSettings.PrintHelpMessage"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXMergeSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXMergeSettings.LogLevel"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXMergeSettings.RepoRoot"/></li>
        ///     <li><c>--tocMetadata</c> via <see cref="DocFXMergeSettings.TocMetadata"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXMergeSettings.WarningsAsErrors"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DocFXMergeSettings Settings, IReadOnlyCollection<Output> Output)> DocFXMerge(CombinatorialConfigure<DocFXMergeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DocFXMerge, DocFXLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Generate YAML files from source code.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projects&gt;</c> via <see cref="DocFXMetadataSettings.Projects"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXMetadataSettings.CorrelationId"/></li>
        ///     <li><c>--disableDefaultFilter</c> via <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></li>
        ///     <li><c>--disableGitFeatures</c> via <see cref="DocFXMetadataSettings.DisableGitFeatures"/></li>
        ///     <li><c>--filter</c> via <see cref="DocFXMetadataSettings.FilterConfigFile"/></li>
        ///     <li><c>--force</c> via <see cref="DocFXMetadataSettings.ForceRebuild"/></li>
        ///     <li><c>--globalNamespaceId</c> via <see cref="DocFXMetadataSettings.GlobalNamespaceId"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXMetadataSettings.PrintHelpMessage"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXMetadataSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXMetadataSettings.LogLevel"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXMetadataSettings.OutputFolder"/></li>
        ///     <li><c>--property</c> via <see cref="DocFXMetadataSettings.MSBuildProperties"/></li>
        ///     <li><c>--raw</c> via <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXMetadataSettings.RepoRoot"/></li>
        ///     <li><c>--shouldSkipMarkup</c> via <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXMetadataSettings.WarningsAsErrors"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXMetadata(DocFXMetadataSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DocFXMetadataSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generate YAML files from source code.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projects&gt;</c> via <see cref="DocFXMetadataSettings.Projects"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXMetadataSettings.CorrelationId"/></li>
        ///     <li><c>--disableDefaultFilter</c> via <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></li>
        ///     <li><c>--disableGitFeatures</c> via <see cref="DocFXMetadataSettings.DisableGitFeatures"/></li>
        ///     <li><c>--filter</c> via <see cref="DocFXMetadataSettings.FilterConfigFile"/></li>
        ///     <li><c>--force</c> via <see cref="DocFXMetadataSettings.ForceRebuild"/></li>
        ///     <li><c>--globalNamespaceId</c> via <see cref="DocFXMetadataSettings.GlobalNamespaceId"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXMetadataSettings.PrintHelpMessage"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXMetadataSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXMetadataSettings.LogLevel"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXMetadataSettings.OutputFolder"/></li>
        ///     <li><c>--property</c> via <see cref="DocFXMetadataSettings.MSBuildProperties"/></li>
        ///     <li><c>--raw</c> via <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXMetadataSettings.RepoRoot"/></li>
        ///     <li><c>--shouldSkipMarkup</c> via <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXMetadataSettings.WarningsAsErrors"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXMetadata(Configure<DocFXMetadataSettings> configurator)
        {
            return DocFXMetadata(configurator(new DocFXMetadataSettings()));
        }
        /// <summary>
        ///   <p>Generate YAML files from source code.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;projects&gt;</c> via <see cref="DocFXMetadataSettings.Projects"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXMetadataSettings.CorrelationId"/></li>
        ///     <li><c>--disableDefaultFilter</c> via <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></li>
        ///     <li><c>--disableGitFeatures</c> via <see cref="DocFXMetadataSettings.DisableGitFeatures"/></li>
        ///     <li><c>--filter</c> via <see cref="DocFXMetadataSettings.FilterConfigFile"/></li>
        ///     <li><c>--force</c> via <see cref="DocFXMetadataSettings.ForceRebuild"/></li>
        ///     <li><c>--globalNamespaceId</c> via <see cref="DocFXMetadataSettings.GlobalNamespaceId"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXMetadataSettings.PrintHelpMessage"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXMetadataSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXMetadataSettings.LogLevel"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXMetadataSettings.OutputFolder"/></li>
        ///     <li><c>--property</c> via <see cref="DocFXMetadataSettings.MSBuildProperties"/></li>
        ///     <li><c>--raw</c> via <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXMetadataSettings.RepoRoot"/></li>
        ///     <li><c>--shouldSkipMarkup</c> via <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXMetadataSettings.WarningsAsErrors"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DocFXMetadataSettings Settings, IReadOnlyCollection<Output> Output)> DocFXMetadata(CombinatorialConfigure<DocFXMetadataSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DocFXMetadata, DocFXLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Generate pdf file.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configFile&gt;</c> via <see cref="DocFXPdfSettings.ConfigFile"/></li>
        ///     <li><c>--basePath</c> via <see cref="DocFXPdfSettings.BasePath"/></li>
        ///     <li><c>--changesFile</c> via <see cref="DocFXPdfSettings.ChangesFile"/></li>
        ///     <li><c>--cleanupCacheHistory</c> via <see cref="DocFXPdfSettings.CleanupCacheHistory"/></li>
        ///     <li><c>--content</c> via <see cref="DocFXPdfSettings.Content"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXPdfSettings.CorrelationId"/></li>
        ///     <li><c>--css</c> via <see cref="DocFXPdfSettings.CssFilePath"/></li>
        ///     <li><c>--debug</c> via <see cref="DocFXPdfSettings.EnableDebugMode"/></li>
        ///     <li><c>--debugOutput</c> via <see cref="DocFXPdfSettings.OutputFolderForDebugFiles"/></li>
        ///     <li><c>--disableGitFeatures</c> via <see cref="DocFXPdfSettings.DisableGitFeatures"/></li>
        ///     <li><c>--dryRun</c> via <see cref="DocFXPdfSettings.DryRun"/></li>
        ///     <li><c>--errorHandling</c> via <see cref="DocFXPdfSettings.LoadErrorHandling"/></li>
        ///     <li><c>--excludedTocs</c> via <see cref="DocFXPdfSettings.ExcludedTocs"/></li>
        ///     <li><c>--exportRawModel</c> via <see cref="DocFXPdfSettings.ExportRawModel"/></li>
        ///     <li><c>--exportViewModel</c> via <see cref="DocFXPdfSettings.ExportViewModel"/></li>
        ///     <li><c>--falName</c> via <see cref="DocFXPdfSettings.FALName"/></li>
        ///     <li><c>--fileMetadataFile</c> via <see cref="DocFXPdfSettings.FileMetadataFilePath"/></li>
        ///     <li><c>--fileMetadataFiles</c> via <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></li>
        ///     <li><c>--force</c> via <see cref="DocFXPdfSettings.ForceRebuild"/></li>
        ///     <li><c>--forcePostProcess</c> via <see cref="DocFXPdfSettings.ForcePostProcess"/></li>
        ///     <li><c>--generatesAppendices</c> via <see cref="DocFXPdfSettings.GeneratesAppendices"/></li>
        ///     <li><c>--generatesExternalLink</c> via <see cref="DocFXPdfSettings.GeneratesExternalLink"/></li>
        ///     <li><c>--globalMetadata</c> via <see cref="DocFXPdfSettings.GlobalMetadata"/></li>
        ///     <li><c>--globalMetadataFile</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePath"/></li>
        ///     <li><c>--globalMetadataFiles</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXPdfSettings.PrintHelpMessage"/></li>
        ///     <li><c>--host</c> via <see cref="DocFXPdfSettings.PdfHost"/></li>
        ///     <li><c>--hostname</c> via <see cref="DocFXPdfSettings.Host"/></li>
        ///     <li><c>--intermediateFolder</c> via <see cref="DocFXPdfSettings.IntermediateFolder"/></li>
        ///     <li><c>--keepFileLink</c> via <see cref="DocFXPdfSettings.KeepFileLink"/></li>
        ///     <li><c>--keepRawFiles</c> via <see cref="DocFXPdfSettings.KeepRawFiles"/></li>
        ///     <li><c>--locale</c> via <see cref="DocFXPdfSettings.Locale"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXPdfSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXPdfSettings.LogLevel"/></li>
        ///     <li><c>--lruSize</c> via <see cref="DocFXPdfSettings.LruSize"/></li>
        ///     <li><c>--markdownEngineName</c> via <see cref="DocFXPdfSettings.MarkdownEngineName"/></li>
        ///     <li><c>--markdownEngineProperties</c> via <see cref="DocFXPdfSettings.MarkdownEngineProperties"/></li>
        ///     <li><c>--maxParallelism</c> via <see cref="DocFXPdfSettings.MaxParallelism"/></li>
        ///     <li><c>--name</c> via <see cref="DocFXPdfSettings.Name"/></li>
        ///     <li><c>--noLangKeyword</c> via <see cref="DocFXPdfSettings.NoLangKeyword"/></li>
        ///     <li><c>--noStdin</c> via <see cref="DocFXPdfSettings.NoInputStreamArgs"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXPdfSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="DocFXPdfSettings.Overwrite"/></li>
        ///     <li><c>--port</c> via <see cref="DocFXPdfSettings.Port"/></li>
        ///     <li><c>--postProcessors</c> via <see cref="DocFXPdfSettings.PostProcessors"/></li>
        ///     <li><c>--rawModelOutputFolder</c> via <see cref="DocFXPdfSettings.RawModelOutputFolder"/></li>
        ///     <li><c>--rawOutputFolder</c> via <see cref="DocFXPdfSettings.RawOutputFolder"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXPdfSettings.RepoRoot"/></li>
        ///     <li><c>--resource</c> via <see cref="DocFXPdfSettings.Resource"/></li>
        ///     <li><c>--schemaLicense</c> via <see cref="DocFXPdfSettings.SchemaLicense"/></li>
        ///     <li><c>--serve</c> via <see cref="DocFXPdfSettings.Serve"/></li>
        ///     <li><c>--template</c> via <see cref="DocFXPdfSettings.Templates"/></li>
        ///     <li><c>--theme</c> via <see cref="DocFXPdfSettings.Themes"/></li>
        ///     <li><c>--viewModelOutputFolder</c> via <see cref="DocFXPdfSettings.ViewModelOutputFolder"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXPdfSettings.WarningsAsErrors"/></li>
        ///     <li><c>--xref</c> via <see cref="DocFXPdfSettings.XRefMaps"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXPdf(DocFXPdfSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DocFXPdfSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generate pdf file.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configFile&gt;</c> via <see cref="DocFXPdfSettings.ConfigFile"/></li>
        ///     <li><c>--basePath</c> via <see cref="DocFXPdfSettings.BasePath"/></li>
        ///     <li><c>--changesFile</c> via <see cref="DocFXPdfSettings.ChangesFile"/></li>
        ///     <li><c>--cleanupCacheHistory</c> via <see cref="DocFXPdfSettings.CleanupCacheHistory"/></li>
        ///     <li><c>--content</c> via <see cref="DocFXPdfSettings.Content"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXPdfSettings.CorrelationId"/></li>
        ///     <li><c>--css</c> via <see cref="DocFXPdfSettings.CssFilePath"/></li>
        ///     <li><c>--debug</c> via <see cref="DocFXPdfSettings.EnableDebugMode"/></li>
        ///     <li><c>--debugOutput</c> via <see cref="DocFXPdfSettings.OutputFolderForDebugFiles"/></li>
        ///     <li><c>--disableGitFeatures</c> via <see cref="DocFXPdfSettings.DisableGitFeatures"/></li>
        ///     <li><c>--dryRun</c> via <see cref="DocFXPdfSettings.DryRun"/></li>
        ///     <li><c>--errorHandling</c> via <see cref="DocFXPdfSettings.LoadErrorHandling"/></li>
        ///     <li><c>--excludedTocs</c> via <see cref="DocFXPdfSettings.ExcludedTocs"/></li>
        ///     <li><c>--exportRawModel</c> via <see cref="DocFXPdfSettings.ExportRawModel"/></li>
        ///     <li><c>--exportViewModel</c> via <see cref="DocFXPdfSettings.ExportViewModel"/></li>
        ///     <li><c>--falName</c> via <see cref="DocFXPdfSettings.FALName"/></li>
        ///     <li><c>--fileMetadataFile</c> via <see cref="DocFXPdfSettings.FileMetadataFilePath"/></li>
        ///     <li><c>--fileMetadataFiles</c> via <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></li>
        ///     <li><c>--force</c> via <see cref="DocFXPdfSettings.ForceRebuild"/></li>
        ///     <li><c>--forcePostProcess</c> via <see cref="DocFXPdfSettings.ForcePostProcess"/></li>
        ///     <li><c>--generatesAppendices</c> via <see cref="DocFXPdfSettings.GeneratesAppendices"/></li>
        ///     <li><c>--generatesExternalLink</c> via <see cref="DocFXPdfSettings.GeneratesExternalLink"/></li>
        ///     <li><c>--globalMetadata</c> via <see cref="DocFXPdfSettings.GlobalMetadata"/></li>
        ///     <li><c>--globalMetadataFile</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePath"/></li>
        ///     <li><c>--globalMetadataFiles</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXPdfSettings.PrintHelpMessage"/></li>
        ///     <li><c>--host</c> via <see cref="DocFXPdfSettings.PdfHost"/></li>
        ///     <li><c>--hostname</c> via <see cref="DocFXPdfSettings.Host"/></li>
        ///     <li><c>--intermediateFolder</c> via <see cref="DocFXPdfSettings.IntermediateFolder"/></li>
        ///     <li><c>--keepFileLink</c> via <see cref="DocFXPdfSettings.KeepFileLink"/></li>
        ///     <li><c>--keepRawFiles</c> via <see cref="DocFXPdfSettings.KeepRawFiles"/></li>
        ///     <li><c>--locale</c> via <see cref="DocFXPdfSettings.Locale"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXPdfSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXPdfSettings.LogLevel"/></li>
        ///     <li><c>--lruSize</c> via <see cref="DocFXPdfSettings.LruSize"/></li>
        ///     <li><c>--markdownEngineName</c> via <see cref="DocFXPdfSettings.MarkdownEngineName"/></li>
        ///     <li><c>--markdownEngineProperties</c> via <see cref="DocFXPdfSettings.MarkdownEngineProperties"/></li>
        ///     <li><c>--maxParallelism</c> via <see cref="DocFXPdfSettings.MaxParallelism"/></li>
        ///     <li><c>--name</c> via <see cref="DocFXPdfSettings.Name"/></li>
        ///     <li><c>--noLangKeyword</c> via <see cref="DocFXPdfSettings.NoLangKeyword"/></li>
        ///     <li><c>--noStdin</c> via <see cref="DocFXPdfSettings.NoInputStreamArgs"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXPdfSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="DocFXPdfSettings.Overwrite"/></li>
        ///     <li><c>--port</c> via <see cref="DocFXPdfSettings.Port"/></li>
        ///     <li><c>--postProcessors</c> via <see cref="DocFXPdfSettings.PostProcessors"/></li>
        ///     <li><c>--rawModelOutputFolder</c> via <see cref="DocFXPdfSettings.RawModelOutputFolder"/></li>
        ///     <li><c>--rawOutputFolder</c> via <see cref="DocFXPdfSettings.RawOutputFolder"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXPdfSettings.RepoRoot"/></li>
        ///     <li><c>--resource</c> via <see cref="DocFXPdfSettings.Resource"/></li>
        ///     <li><c>--schemaLicense</c> via <see cref="DocFXPdfSettings.SchemaLicense"/></li>
        ///     <li><c>--serve</c> via <see cref="DocFXPdfSettings.Serve"/></li>
        ///     <li><c>--template</c> via <see cref="DocFXPdfSettings.Templates"/></li>
        ///     <li><c>--theme</c> via <see cref="DocFXPdfSettings.Themes"/></li>
        ///     <li><c>--viewModelOutputFolder</c> via <see cref="DocFXPdfSettings.ViewModelOutputFolder"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXPdfSettings.WarningsAsErrors"/></li>
        ///     <li><c>--xref</c> via <see cref="DocFXPdfSettings.XRefMaps"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXPdf(Configure<DocFXPdfSettings> configurator)
        {
            return DocFXPdf(configurator(new DocFXPdfSettings()));
        }
        /// <summary>
        ///   <p>Generate pdf file.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;configFile&gt;</c> via <see cref="DocFXPdfSettings.ConfigFile"/></li>
        ///     <li><c>--basePath</c> via <see cref="DocFXPdfSettings.BasePath"/></li>
        ///     <li><c>--changesFile</c> via <see cref="DocFXPdfSettings.ChangesFile"/></li>
        ///     <li><c>--cleanupCacheHistory</c> via <see cref="DocFXPdfSettings.CleanupCacheHistory"/></li>
        ///     <li><c>--content</c> via <see cref="DocFXPdfSettings.Content"/></li>
        ///     <li><c>--correlationId</c> via <see cref="DocFXPdfSettings.CorrelationId"/></li>
        ///     <li><c>--css</c> via <see cref="DocFXPdfSettings.CssFilePath"/></li>
        ///     <li><c>--debug</c> via <see cref="DocFXPdfSettings.EnableDebugMode"/></li>
        ///     <li><c>--debugOutput</c> via <see cref="DocFXPdfSettings.OutputFolderForDebugFiles"/></li>
        ///     <li><c>--disableGitFeatures</c> via <see cref="DocFXPdfSettings.DisableGitFeatures"/></li>
        ///     <li><c>--dryRun</c> via <see cref="DocFXPdfSettings.DryRun"/></li>
        ///     <li><c>--errorHandling</c> via <see cref="DocFXPdfSettings.LoadErrorHandling"/></li>
        ///     <li><c>--excludedTocs</c> via <see cref="DocFXPdfSettings.ExcludedTocs"/></li>
        ///     <li><c>--exportRawModel</c> via <see cref="DocFXPdfSettings.ExportRawModel"/></li>
        ///     <li><c>--exportViewModel</c> via <see cref="DocFXPdfSettings.ExportViewModel"/></li>
        ///     <li><c>--falName</c> via <see cref="DocFXPdfSettings.FALName"/></li>
        ///     <li><c>--fileMetadataFile</c> via <see cref="DocFXPdfSettings.FileMetadataFilePath"/></li>
        ///     <li><c>--fileMetadataFiles</c> via <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></li>
        ///     <li><c>--force</c> via <see cref="DocFXPdfSettings.ForceRebuild"/></li>
        ///     <li><c>--forcePostProcess</c> via <see cref="DocFXPdfSettings.ForcePostProcess"/></li>
        ///     <li><c>--generatesAppendices</c> via <see cref="DocFXPdfSettings.GeneratesAppendices"/></li>
        ///     <li><c>--generatesExternalLink</c> via <see cref="DocFXPdfSettings.GeneratesExternalLink"/></li>
        ///     <li><c>--globalMetadata</c> via <see cref="DocFXPdfSettings.GlobalMetadata"/></li>
        ///     <li><c>--globalMetadataFile</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePath"/></li>
        ///     <li><c>--globalMetadataFiles</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXPdfSettings.PrintHelpMessage"/></li>
        ///     <li><c>--host</c> via <see cref="DocFXPdfSettings.PdfHost"/></li>
        ///     <li><c>--hostname</c> via <see cref="DocFXPdfSettings.Host"/></li>
        ///     <li><c>--intermediateFolder</c> via <see cref="DocFXPdfSettings.IntermediateFolder"/></li>
        ///     <li><c>--keepFileLink</c> via <see cref="DocFXPdfSettings.KeepFileLink"/></li>
        ///     <li><c>--keepRawFiles</c> via <see cref="DocFXPdfSettings.KeepRawFiles"/></li>
        ///     <li><c>--locale</c> via <see cref="DocFXPdfSettings.Locale"/></li>
        ///     <li><c>--log</c> via <see cref="DocFXPdfSettings.LogFilePath"/></li>
        ///     <li><c>--logLevel</c> via <see cref="DocFXPdfSettings.LogLevel"/></li>
        ///     <li><c>--lruSize</c> via <see cref="DocFXPdfSettings.LruSize"/></li>
        ///     <li><c>--markdownEngineName</c> via <see cref="DocFXPdfSettings.MarkdownEngineName"/></li>
        ///     <li><c>--markdownEngineProperties</c> via <see cref="DocFXPdfSettings.MarkdownEngineProperties"/></li>
        ///     <li><c>--maxParallelism</c> via <see cref="DocFXPdfSettings.MaxParallelism"/></li>
        ///     <li><c>--name</c> via <see cref="DocFXPdfSettings.Name"/></li>
        ///     <li><c>--noLangKeyword</c> via <see cref="DocFXPdfSettings.NoLangKeyword"/></li>
        ///     <li><c>--noStdin</c> via <see cref="DocFXPdfSettings.NoInputStreamArgs"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXPdfSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="DocFXPdfSettings.Overwrite"/></li>
        ///     <li><c>--port</c> via <see cref="DocFXPdfSettings.Port"/></li>
        ///     <li><c>--postProcessors</c> via <see cref="DocFXPdfSettings.PostProcessors"/></li>
        ///     <li><c>--rawModelOutputFolder</c> via <see cref="DocFXPdfSettings.RawModelOutputFolder"/></li>
        ///     <li><c>--rawOutputFolder</c> via <see cref="DocFXPdfSettings.RawOutputFolder"/></li>
        ///     <li><c>--repositoryRoot</c> via <see cref="DocFXPdfSettings.RepoRoot"/></li>
        ///     <li><c>--resource</c> via <see cref="DocFXPdfSettings.Resource"/></li>
        ///     <li><c>--schemaLicense</c> via <see cref="DocFXPdfSettings.SchemaLicense"/></li>
        ///     <li><c>--serve</c> via <see cref="DocFXPdfSettings.Serve"/></li>
        ///     <li><c>--template</c> via <see cref="DocFXPdfSettings.Templates"/></li>
        ///     <li><c>--theme</c> via <see cref="DocFXPdfSettings.Themes"/></li>
        ///     <li><c>--viewModelOutputFolder</c> via <see cref="DocFXPdfSettings.ViewModelOutputFolder"/></li>
        ///     <li><c>--warningsAsErrors</c> via <see cref="DocFXPdfSettings.WarningsAsErrors"/></li>
        ///     <li><c>--xref</c> via <see cref="DocFXPdfSettings.XRefMaps"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DocFXPdfSettings Settings, IReadOnlyCollection<Output> Output)> DocFXPdf(CombinatorialConfigure<DocFXPdfSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DocFXPdf, DocFXLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Host a local static website.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;folder&gt;</c> via <see cref="DocFXServeSettings.Folder"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXServeSettings.PrintHelpMessage"/></li>
        ///     <li><c>--hostname</c> via <see cref="DocFXServeSettings.Host"/></li>
        ///     <li><c>--port</c> via <see cref="DocFXServeSettings.Port"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXServe(DocFXServeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DocFXServeSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Host a local static website.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;folder&gt;</c> via <see cref="DocFXServeSettings.Folder"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXServeSettings.PrintHelpMessage"/></li>
        ///     <li><c>--hostname</c> via <see cref="DocFXServeSettings.Host"/></li>
        ///     <li><c>--port</c> via <see cref="DocFXServeSettings.Port"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXServe(Configure<DocFXServeSettings> configurator)
        {
            return DocFXServe(configurator(new DocFXServeSettings()));
        }
        /// <summary>
        ///   <p>Host a local static website.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;folder&gt;</c> via <see cref="DocFXServeSettings.Folder"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXServeSettings.PrintHelpMessage"/></li>
        ///     <li><c>--hostname</c> via <see cref="DocFXServeSettings.Host"/></li>
        ///     <li><c>--port</c> via <see cref="DocFXServeSettings.Port"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DocFXServeSettings Settings, IReadOnlyCollection<Output> Output)> DocFXServe(CombinatorialConfigure<DocFXServeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DocFXServe, DocFXLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>List or export existing template.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;command&gt;</c> via <see cref="DocFXTemplateSettings.Command"/></li>
        ///     <li><c>--all</c> via <see cref="DocFXTemplateSettings.All"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXTemplateSettings.PrintHelpMessage"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXTemplateSettings.OutputFolder"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXTemplate(DocFXTemplateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DocFXTemplateSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>List or export existing template.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;command&gt;</c> via <see cref="DocFXTemplateSettings.Command"/></li>
        ///     <li><c>--all</c> via <see cref="DocFXTemplateSettings.All"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXTemplateSettings.PrintHelpMessage"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXTemplateSettings.OutputFolder"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DocFXTemplate(Configure<DocFXTemplateSettings> configurator)
        {
            return DocFXTemplate(configurator(new DocFXTemplateSettings()));
        }
        /// <summary>
        ///   <p>List or export existing template.</p>
        ///   <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;command&gt;</c> via <see cref="DocFXTemplateSettings.Command"/></li>
        ///     <li><c>--all</c> via <see cref="DocFXTemplateSettings.All"/></li>
        ///     <li><c>--help</c> via <see cref="DocFXTemplateSettings.PrintHelpMessage"/></li>
        ///     <li><c>--output</c> via <see cref="DocFXTemplateSettings.OutputFolder"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DocFXTemplateSettings Settings, IReadOnlyCollection<Output> Output)> DocFXTemplate(CombinatorialConfigure<DocFXTemplateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DocFXTemplate, DocFXLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region DocFXBuildSettings
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFXBuildSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DocFXTasks.DocFXPath;
        public override Action<OutputType, string> CustomLogger => DocFXTasks.DocFXLogger;
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Set changes file.
        /// </summary>
        public virtual string ChangesFile { get; internal set; }
        /// <summary>
        ///   If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.
        /// </summary>
        public virtual bool? CleanupCacheHistory { get; internal set; }
        /// <summary>
        ///   Specify content files for generating documentation.
        /// </summary>
        public virtual IReadOnlyList<string> Content => ContentInternal.AsReadOnly();
        internal List<string> ContentInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.
        /// </summary>
        public virtual bool? DisableGitFeatures { get; internal set; }
        /// <summary>
        ///   If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.
        /// </summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary>
        ///   Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.
        /// </summary>
        public virtual bool? EnableDebugMode { get; internal set; }
        /// <summary>
        ///   If set to true, data model to run template script will be extracted in .raw.model.json extension.
        /// </summary>
        public virtual bool? ExportRawModel { get; internal set; }
        /// <summary>
        ///   If set to true, data model to apply template will be extracted in .view.model.json extension.
        /// </summary>
        public virtual bool? ExportViewModel { get; internal set; }
        /// <summary>
        ///   Set the name of input file abstract layer builder.
        /// </summary>
        public virtual string FALName { get; internal set; }
        /// <summary>
        ///   Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.
        /// </summary>
        public virtual string FileMetadataFilePath { get; internal set; }
        /// <summary>
        ///   Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.
        /// </summary>
        public virtual IReadOnlyList<string> FileMetadataFilePaths => FileMetadataFilePathsInternal.AsReadOnly();
        internal List<string> FileMetadataFilePathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Force to re-process the documentation in post processors. It will be cascaded from force option.
        /// </summary>
        public virtual bool? ForcePostProcess { get; internal set; }
        /// <summary>
        ///   Force re-build all the documentation.
        /// </summary>
        public virtual bool? ForceRebuild { get; internal set; }
        /// <summary>
        ///   Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.
        /// </summary>
        public virtual string GlobalMetadata { get; internal set; }
        /// <summary>
        ///   Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.
        /// </summary>
        public virtual string GlobalMetadataFilePath { get; internal set; }
        /// <summary>
        ///   Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.
        /// </summary>
        public virtual IReadOnlyList<string> GlobalMetadataFilePaths => GlobalMetadataFilePathsInternal.AsReadOnly();
        internal List<string> GlobalMetadataFilePathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify the hostname of the hosted website (e.g., 'localhost' or '*').
        /// </summary>
        public virtual string Host { get; internal set; }
        /// <summary>
        ///   Set folder for intermediate build results.
        /// </summary>
        public virtual string IntermediateFolder { get; internal set; }
        /// <summary>
        ///   If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.
        /// </summary>
        public virtual bool? KeepFileLink { get; internal set; }
        /// <summary>
        ///   Set the LRU cached model count (approximately the same as the count of input files). By default, it is 8192 for 64bit and 3072 for 32bit process. With LRU cache enabled, memory usage decreases and time consumed increases. If set to 0, Lru cache is disabled.
        /// </summary>
        public virtual int? LruSize { get; internal set; }
        /// <summary>
        ///   Set the name of markdown engine, default is 'dfm'.
        /// </summary>
        public virtual string MarkdownEngineName { get; internal set; }
        /// <summary>
        ///   Set the parameters for markdown engine, value should be a JSON string.
        /// </summary>
        public virtual string MarkdownEngineProperties { get; internal set; }
        /// <summary>
        ///   Set the max parallelism, 0 is auto.
        /// </summary>
        public virtual int? MaxParallelism { get; internal set; }
        /// <summary>
        ///   Disable default lang keyword.
        /// </summary>
        public virtual bool? NoLangKeyword { get; internal set; }
        /// <summary>
        ///   Specify the output base directory.
        /// </summary>
        public virtual string OutputFolder { get; internal set; }
        /// <summary>
        ///   The output folder for files generated for debugging purpose when in debug mode. If not specified, it is ${TempPath}/docfx.
        /// </summary>
        public virtual string OutputFolderForDebugFiles { get; internal set; }
        /// <summary>
        ///   Specify overwrite files used by content files.
        /// </summary>
        public virtual IReadOnlyList<string> Overwrite => OverwriteInternal.AsReadOnly();
        internal List<string> OverwriteInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify the port of the hosted website.
        /// </summary>
        public virtual int? Port { get; internal set; }
        /// <summary>
        ///   Set the order of post processors in plugins.
        /// </summary>
        public virtual IReadOnlyList<string> PostProcessors => PostProcessorsInternal.AsReadOnly();
        internal List<string> PostProcessorsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Print help message for this sub-command.
        /// </summary>
        public virtual bool? PrintHelpMessage { get; internal set; }
        /// <summary>
        ///   Specify the output folder for the raw model. If not set, the raw model will be generated to the same folder as the output documentation.
        /// </summary>
        public virtual string RawModelOutputFolder { get; internal set; }
        /// <summary>
        ///   Specify resources used by content files.
        /// </summary>
        public virtual IReadOnlyList<string> Resource => ResourceInternal.AsReadOnly();
        internal List<string> ResourceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Please provide the license key for validating schema using NewtonsoftJson.Schema here.
        /// </summary>
        public virtual string SchemaLicense { get; internal set; }
        /// <summary>
        ///   Host the generated documentation to a website.
        /// </summary>
        public virtual bool? Serve { get; internal set; }
        /// <summary>
        ///   Specify the template name to apply to. If not specified, output YAML file will not be transformed.
        /// </summary>
        public virtual IReadOnlyList<string> Templates => TemplatesInternal.AsReadOnly();
        internal List<string> TemplatesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify which theme to use. By default 'default' theme is offered.
        /// </summary>
        public virtual IReadOnlyList<string> Themes => ThemesInternal.AsReadOnly();
        internal List<string> ThemesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify the output folder for the view model. If not set, the view model will be generated to the same folder as the output documentation.
        /// </summary>
        public virtual string ViewModelOutputFolder { get; internal set; }
        /// <summary>
        ///   Specify the urls of xrefmap used by content files.
        /// </summary>
        public virtual IReadOnlyList<string> XRefMaps => XRefMapsInternal.AsReadOnly();
        internal List<string> XRefMapsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify the correlation id used for logging.
        /// </summary>
        public virtual string CorrelationId { get; internal set; }
        /// <summary>
        ///   Specify the file name to save processing log.
        /// </summary>
        public virtual string LogFilePath { get; internal set; }
        /// <summary>
        ///   Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.
        /// </summary>
        public virtual DocFXLogLevel LogLevel { get; internal set; }
        /// <summary>
        ///   Specify the GIT repository root folder.
        /// </summary>
        public virtual string RepoRoot { get; internal set; }
        /// <summary>
        ///   Specify if warnings should be treated as errors.
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("build")
              .Add("{value}", ConfigFile)
              .Add("--changesFile={value}", ChangesFile)
              .Add("--cleanupCacheHistory", CleanupCacheHistory)
              .Add("--content={value}", Content, separator: ',')
              .Add("--disableGitFeatures", DisableGitFeatures)
              .Add("--dryRun", DryRun)
              .Add("--debug", EnableDebugMode)
              .Add("--exportRawModel", ExportRawModel)
              .Add("--exportViewModel", ExportViewModel)
              .Add("--falName={value}", FALName)
              .Add("--fileMetadataFile={value}", FileMetadataFilePath)
              .Add("--fileMetadataFiles={value}", FileMetadataFilePaths, separator: ',')
              .Add("--forcePostProcess", ForcePostProcess)
              .Add("--force", ForceRebuild)
              .Add("--globalMetadata={value}", GlobalMetadata)
              .Add("--globalMetadataFile={value}", GlobalMetadataFilePath)
              .Add("--globalMetadataFiles={value}", GlobalMetadataFilePaths, separator: ',')
              .Add("--hostname={value}", Host)
              .Add("--intermediateFolder={value}", IntermediateFolder)
              .Add("--keepFileLink", KeepFileLink)
              .Add("--lruSize={value}", LruSize)
              .Add("--markdownEngineName={value}", MarkdownEngineName)
              .Add("--markdownEngineProperties={value}", MarkdownEngineProperties)
              .Add("--maxParallelism={value}", MaxParallelism)
              .Add("--noLangKeyword", NoLangKeyword)
              .Add("--output={value}", OutputFolder)
              .Add("--debugOutput={value}", OutputFolderForDebugFiles)
              .Add("--overwrite={value}", Overwrite, separator: ',')
              .Add("--port={value}", Port)
              .Add("--postProcessors={value}", PostProcessors, separator: ',')
              .Add("--help", PrintHelpMessage)
              .Add("--rawModelOutputFolder={value}", RawModelOutputFolder)
              .Add("--resource={value}", Resource, separator: ',')
              .Add("--schemaLicense={value}", SchemaLicense)
              .Add("--serve", Serve)
              .Add("--template={value}", Templates, separator: ',')
              .Add("--theme={value}", Themes, separator: ',')
              .Add("--viewModelOutputFolder={value}", ViewModelOutputFolder)
              .Add("--xref={value}", XRefMaps, separator: ',')
              .Add("--correlationId={value}", CorrelationId)
              .Add("--log={value}", LogFilePath)
              .Add("--logLevel={value}", LogLevel)
              .Add("--repositoryRoot={value}", RepoRoot)
              .Add("--warningsAsErrors", WarningsAsErrors);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFXDependencySettings
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFXDependencySettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DocFXTasks.DocFXPath;
        public override Action<OutputType, string> CustomLogger => DocFXTasks.DocFXLogger;
        public virtual string DependencyFile { get; internal set; }
        /// <summary>
        ///   The intermediate folder that store cache files.
        /// </summary>
        public virtual string IntermediateFolder { get; internal set; }
        /// <summary>
        ///   Print help message for this sub-command.
        /// </summary>
        public virtual bool? PrintHelpMessage { get; internal set; }
        /// <summary>
        ///   The version name of the content.
        /// </summary>
        public virtual string VersionName { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("dependency")
              .Add("{value}", DependencyFile)
              .Add("--intermediateFolder={value}", IntermediateFolder)
              .Add("--help", PrintHelpMessage)
              .Add("--version={value}", VersionName);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFXDownloadSettings
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFXDownloadSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DocFXTasks.DocFXPath;
        public override Action<OutputType, string> CustomLogger => DocFXTasks.DocFXLogger;
        public virtual string ArchiveFile { get; internal set; }
        /// <summary>
        ///   Print help message for this sub-command.
        /// </summary>
        public virtual bool? PrintHelpMessage { get; internal set; }
        /// <summary>
        ///   Specify the url of xrefmap.
        /// </summary>
        public virtual string Uri { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("download")
              .Add("{value}", ArchiveFile)
              .Add("--help", PrintHelpMessage)
              .Add("--xref={value}", Uri);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFXHelpSettings
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFXHelpSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DocFXTasks.DocFXPath;
        public override Action<OutputType, string> CustomLogger => DocFXTasks.DocFXLogger;
        public virtual string Command { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("help")
              .Add("{value}", Command);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFXInitSettings
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFXInitSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DocFXTasks.DocFXPath;
        public override Action<OutputType, string> CustomLogger => DocFXTasks.DocFXLogger;
        /// <summary>
        ///   Specify the source working folder for source project files to start glob search.
        /// </summary>
        public virtual string ApiSourceFolder { get; internal set; }
        /// <summary>
        ///   Specify the source project files' glob pattern to generate metadata.
        /// </summary>
        public virtual string ApiSourceGlobPattern { get; internal set; }
        /// <summary>
        ///   Generate config file docfx.json only, no project folder will be generated.
        /// </summary>
        public virtual bool? OnlyConfigFile { get; internal set; }
        /// <summary>
        ///   Specify the output folder of the config file. If not specified, the config file will be saved to a new folder docfx_project.
        /// </summary>
        public virtual string OutputFolder { get; internal set; }
        /// <summary>
        ///   Specify if the current file will be overwritten if it exists.
        /// </summary>
        public virtual bool? Overwrite { get; internal set; }
        /// <summary>
        ///   Print help message for this sub-command.
        /// </summary>
        public virtual bool? PrintHelpMessage { get; internal set; }
        /// <summary>
        ///   Quietly generate the default docfx.json.
        /// </summary>
        public virtual bool? Quiet { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("init")
              .Add("--apiSourceFolder={value}", ApiSourceFolder)
              .Add("--apiGlobPattern={value}", ApiSourceGlobPattern)
              .Add("--file", OnlyConfigFile)
              .Add("--output={value}", OutputFolder)
              .Add("--overwrite", Overwrite)
              .Add("--help", PrintHelpMessage)
              .Add("--quiet", Quiet);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFXMergeSettings
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFXMergeSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DocFXTasks.DocFXPath;
        public override Action<OutputType, string> CustomLogger => DocFXTasks.DocFXLogger;
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Specifies content files for generating documentation.
        /// </summary>
        public virtual IReadOnlyList<string> Content => ContentInternal.AsReadOnly();
        internal List<string> ContentInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.
        /// </summary>
        public virtual string FileMetadataFilePath { get; internal set; }
        /// <summary>
        ///   Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.
        /// </summary>
        public virtual string GlobalMetadata { get; internal set; }
        /// <summary>
        ///   Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.
        /// </summary>
        public virtual string GlobalMetadataFilePath { get; internal set; }
        /// <summary>
        ///   Print help message for this sub-command.
        /// </summary>
        public virtual bool? PrintHelpMessage { get; internal set; }
        /// <summary>
        ///   Specify metadata names that need to be merged into toc file.
        /// </summary>
        public virtual IReadOnlyList<string> TocMetadata => TocMetadataInternal.AsReadOnly();
        internal List<string> TocMetadataInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify the correlation id used for logging.
        /// </summary>
        public virtual string CorrelationId { get; internal set; }
        /// <summary>
        ///   Specify the file name to save processing log.
        /// </summary>
        public virtual string LogFilePath { get; internal set; }
        /// <summary>
        ///   Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.
        /// </summary>
        public virtual DocFXLogLevel LogLevel { get; internal set; }
        /// <summary>
        ///   Specify the GIT repository root folder.
        /// </summary>
        public virtual string RepoRoot { get; internal set; }
        /// <summary>
        ///   Specify if warnings should be treated as errors.
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("merge")
              .Add("{value}", ConfigFile)
              .Add("--content={value}", Content, separator: ',')
              .Add("--fileMetadataFile={value}", FileMetadataFilePath)
              .Add("--globalMetadata={value}", GlobalMetadata)
              .Add("--globalMetadataFile={value}", GlobalMetadataFilePath)
              .Add("--help", PrintHelpMessage)
              .Add("--tocMetadata={value}", TocMetadata, separator: ',')
              .Add("--correlationId={value}", CorrelationId)
              .Add("--log={value}", LogFilePath)
              .Add("--logLevel={value}", LogLevel)
              .Add("--repositoryRoot={value}", RepoRoot)
              .Add("--warningsAsErrors", WarningsAsErrors);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFXMetadataSettings
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFXMetadataSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DocFXTasks.DocFXPath;
        public override Action<OutputType, string> CustomLogger => DocFXTasks.DocFXLogger;
        /// <summary>
        ///   The projects for which the metadata should be built.
        /// </summary>
        public virtual IReadOnlyList<string> Projects => ProjectsInternal.AsReadOnly();
        internal List<string> ProjectsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Disable the default API filter (default filter only generate public or protected APIs).
        /// </summary>
        public virtual bool? DisableDefaultFilter { get; internal set; }
        /// <summary>
        ///   Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.
        /// </summary>
        public virtual bool? DisableGitFeatures { get; internal set; }
        /// <summary>
        ///   Specify the filter config file.
        /// </summary>
        public virtual string FilterConfigFile { get; internal set; }
        /// <summary>
        ///   Force re-generate all the metadata.
        /// </summary>
        public virtual bool? ForceRebuild { get; internal set; }
        /// <summary>
        ///   Specify the name to use for the global namespace.
        /// </summary>
        public virtual string GlobalNamespaceId { get; internal set; }
        /// <summary>
        ///   --property &lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; An optional set of MSBuild properties used when interpreting project files. These are the same properties that are passed to msbuild via the /property:&lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; command line argument.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> MSBuildProperties => MSBuildPropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> MSBuildPropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Specify the output base directory.
        /// </summary>
        public virtual string OutputFolder { get; internal set; }
        /// <summary>
        ///   Preserve the existing xml comment tags inside 'summary' triple slash comments.
        /// </summary>
        public virtual bool? PreserveRawInlineComments { get; internal set; }
        /// <summary>
        ///   Print help message for this sub-command.
        /// </summary>
        public virtual bool? PrintHelpMessage { get; internal set; }
        /// <summary>
        ///   Skip to markup the triple slash comments.
        /// </summary>
        public virtual bool? ShouldSkipMarkup { get; internal set; }
        /// <summary>
        ///   Specify the correlation id used for logging.
        /// </summary>
        public virtual string CorrelationId { get; internal set; }
        /// <summary>
        ///   Specify the file name to save processing log.
        /// </summary>
        public virtual string LogFilePath { get; internal set; }
        /// <summary>
        ///   Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.
        /// </summary>
        public virtual DocFXLogLevel LogLevel { get; internal set; }
        /// <summary>
        ///   Specify the GIT repository root folder.
        /// </summary>
        public virtual string RepoRoot { get; internal set; }
        /// <summary>
        ///   Specify if warnings should be treated as errors.
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("metadata")
              .Add("{value}", Projects, separator: ' ')
              .Add("--disableDefaultFilter", DisableDefaultFilter)
              .Add("--disableGitFeatures", DisableGitFeatures)
              .Add("--filter={value}", FilterConfigFile)
              .Add("--force", ForceRebuild)
              .Add("--globalNamespaceId={value}", GlobalNamespaceId)
              .Add("--property={value}", MSBuildProperties, "{key}={value}", separator: ';')
              .Add("--output={value}", OutputFolder)
              .Add("--raw", PreserveRawInlineComments)
              .Add("--help", PrintHelpMessage)
              .Add("--shouldSkipMarkup", ShouldSkipMarkup)
              .Add("--correlationId={value}", CorrelationId)
              .Add("--log={value}", LogFilePath)
              .Add("--logLevel={value}", LogLevel)
              .Add("--repositoryRoot={value}", RepoRoot)
              .Add("--warningsAsErrors", WarningsAsErrors);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFXPdfSettings
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFXPdfSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DocFXTasks.DocFXPath;
        public override Action<OutputType, string> CustomLogger => DocFXTasks.DocFXLogger;
        /// <summary>
        ///   Specify the base path to generate external link, {host}/{locale}/{basePath}.
        /// </summary>
        public virtual string BasePath { get; internal set; }
        /// <summary>
        ///   Specify the path for the css to generate pdf, default value is styles/default.css.
        /// </summary>
        public virtual string CssFilePath { get; internal set; }
        /// <summary>
        ///   Specify the toc files to be excluded.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludedTocs => ExcludedTocsInternal.AsReadOnly();
        internal List<string> ExcludedTocsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify whether or not to generate appendices for not-in-TOC articles.
        /// </summary>
        public virtual bool? GeneratesAppendices { get; internal set; }
        /// <summary>
        ///   Specify whether or not to generate external links for PDF.
        /// </summary>
        public virtual bool? GeneratesExternalLink { get; internal set; }
        /// <summary>
        ///   Specify the hostname to link not-in-TOC articles.
        /// </summary>
        public virtual string PdfHost { get; internal set; }
        /// <summary>
        ///   Specify whether or not to keep the intermediate html files that used to generate the PDF file. It it usually used in debug purpose. By default the value is false.
        /// </summary>
        public virtual bool? KeepRawFiles { get; internal set; }
        /// <summary>
        ///   Specify how to handle pdf pages that fail to load: abort, ignore or skip(default abort), it is the same input as wkhtmltopdf --load-error-handling options.
        /// </summary>
        public virtual string LoadErrorHandling { get; internal set; }
        /// <summary>
        ///   Specify the locale of the pdf file.
        /// </summary>
        public virtual string Locale { get; internal set; }
        /// <summary>
        ///   Specify the name of the generated pdf.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   Do not use stdin when wkhtmltopdf is executed.
        /// </summary>
        public virtual bool? NoInputStreamArgs { get; internal set; }
        /// <summary>
        ///   Specify the output folder for the raw files, if not specified, raw files will by default be saved to _raw subfolder under output folder if keepRawFiles is set to true.
        /// </summary>
        public virtual string RawOutputFolder { get; internal set; }
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Set changes file.
        /// </summary>
        public virtual string ChangesFile { get; internal set; }
        /// <summary>
        ///   If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.
        /// </summary>
        public virtual bool? CleanupCacheHistory { get; internal set; }
        /// <summary>
        ///   Specify content files for generating documentation.
        /// </summary>
        public virtual IReadOnlyList<string> Content => ContentInternal.AsReadOnly();
        internal List<string> ContentInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.
        /// </summary>
        public virtual bool? DisableGitFeatures { get; internal set; }
        /// <summary>
        ///   If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.
        /// </summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary>
        ///   Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.
        /// </summary>
        public virtual bool? EnableDebugMode { get; internal set; }
        /// <summary>
        ///   If set to true, data model to run template script will be extracted in .raw.model.json extension.
        /// </summary>
        public virtual bool? ExportRawModel { get; internal set; }
        /// <summary>
        ///   If set to true, data model to apply template will be extracted in .view.model.json extension.
        /// </summary>
        public virtual bool? ExportViewModel { get; internal set; }
        /// <summary>
        ///   Set the name of input file abstract layer builder.
        /// </summary>
        public virtual string FALName { get; internal set; }
        /// <summary>
        ///   Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.
        /// </summary>
        public virtual string FileMetadataFilePath { get; internal set; }
        /// <summary>
        ///   Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.
        /// </summary>
        public virtual IReadOnlyList<string> FileMetadataFilePaths => FileMetadataFilePathsInternal.AsReadOnly();
        internal List<string> FileMetadataFilePathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Force to re-process the documentation in post processors. It will be cascaded from force option.
        /// </summary>
        public virtual bool? ForcePostProcess { get; internal set; }
        /// <summary>
        ///   Force re-build all the documentation.
        /// </summary>
        public virtual bool? ForceRebuild { get; internal set; }
        /// <summary>
        ///   Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.
        /// </summary>
        public virtual string GlobalMetadata { get; internal set; }
        /// <summary>
        ///   Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.
        /// </summary>
        public virtual string GlobalMetadataFilePath { get; internal set; }
        /// <summary>
        ///   Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.
        /// </summary>
        public virtual IReadOnlyList<string> GlobalMetadataFilePaths => GlobalMetadataFilePathsInternal.AsReadOnly();
        internal List<string> GlobalMetadataFilePathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify the hostname of the hosted website (e.g., 'localhost' or '*').
        /// </summary>
        public virtual string Host { get; internal set; }
        /// <summary>
        ///   Set folder for intermediate build results.
        /// </summary>
        public virtual string IntermediateFolder { get; internal set; }
        /// <summary>
        ///   If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.
        /// </summary>
        public virtual bool? KeepFileLink { get; internal set; }
        /// <summary>
        ///   Set the LRU cached model count (approximately the same as the count of input files). By default, it is 8192 for 64bit and 3072 for 32bit process. With LRU cache enabled, memory usage decreases and time consumed increases. If set to 0, Lru cache is disabled.
        /// </summary>
        public virtual int? LruSize { get; internal set; }
        /// <summary>
        ///   Set the name of markdown engine, default is 'dfm'.
        /// </summary>
        public virtual string MarkdownEngineName { get; internal set; }
        /// <summary>
        ///   Set the parameters for markdown engine, value should be a JSON string.
        /// </summary>
        public virtual string MarkdownEngineProperties { get; internal set; }
        /// <summary>
        ///   Set the max parallelism, 0 is auto.
        /// </summary>
        public virtual int? MaxParallelism { get; internal set; }
        /// <summary>
        ///   Disable default lang keyword.
        /// </summary>
        public virtual bool? NoLangKeyword { get; internal set; }
        /// <summary>
        ///   Specify the output base directory.
        /// </summary>
        public virtual string OutputFolder { get; internal set; }
        /// <summary>
        ///   The output folder for files generated for debugging purpose when in debug mode. If not specified, it is ${TempPath}/docfx.
        /// </summary>
        public virtual string OutputFolderForDebugFiles { get; internal set; }
        /// <summary>
        ///   Specify overwrite files used by content files.
        /// </summary>
        public virtual IReadOnlyList<string> Overwrite => OverwriteInternal.AsReadOnly();
        internal List<string> OverwriteInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify the port of the hosted website.
        /// </summary>
        public virtual int? Port { get; internal set; }
        /// <summary>
        ///   Set the order of post processors in plugins.
        /// </summary>
        public virtual IReadOnlyList<string> PostProcessors => PostProcessorsInternal.AsReadOnly();
        internal List<string> PostProcessorsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Print help message for this sub-command.
        /// </summary>
        public virtual bool? PrintHelpMessage { get; internal set; }
        /// <summary>
        ///   Specify the output folder for the raw model. If not set, the raw model will be generated to the same folder as the output documentation.
        /// </summary>
        public virtual string RawModelOutputFolder { get; internal set; }
        /// <summary>
        ///   Specify resources used by content files.
        /// </summary>
        public virtual IReadOnlyList<string> Resource => ResourceInternal.AsReadOnly();
        internal List<string> ResourceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Please provide the license key for validating schema using NewtonsoftJson.Schema here.
        /// </summary>
        public virtual string SchemaLicense { get; internal set; }
        /// <summary>
        ///   Host the generated documentation to a website.
        /// </summary>
        public virtual bool? Serve { get; internal set; }
        /// <summary>
        ///   Specify the template name to apply to. If not specified, output YAML file will not be transformed.
        /// </summary>
        public virtual IReadOnlyList<string> Templates => TemplatesInternal.AsReadOnly();
        internal List<string> TemplatesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify which theme to use. By default 'default' theme is offered.
        /// </summary>
        public virtual IReadOnlyList<string> Themes => ThemesInternal.AsReadOnly();
        internal List<string> ThemesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify the output folder for the view model. If not set, the view model will be generated to the same folder as the output documentation.
        /// </summary>
        public virtual string ViewModelOutputFolder { get; internal set; }
        /// <summary>
        ///   Specify the urls of xrefmap used by content files.
        /// </summary>
        public virtual IReadOnlyList<string> XRefMaps => XRefMapsInternal.AsReadOnly();
        internal List<string> XRefMapsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify the correlation id used for logging.
        /// </summary>
        public virtual string CorrelationId { get; internal set; }
        /// <summary>
        ///   Specify the file name to save processing log.
        /// </summary>
        public virtual string LogFilePath { get; internal set; }
        /// <summary>
        ///   Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.
        /// </summary>
        public virtual DocFXLogLevel LogLevel { get; internal set; }
        /// <summary>
        ///   Specify the GIT repository root folder.
        /// </summary>
        public virtual string RepoRoot { get; internal set; }
        /// <summary>
        ///   Specify if warnings should be treated as errors.
        /// </summary>
        public virtual bool? WarningsAsErrors { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("pdf")
              .Add("--basePath={value}", BasePath)
              .Add("--css={value}", CssFilePath)
              .Add("--excludedTocs={value}", ExcludedTocs)
              .Add("--generatesAppendices", GeneratesAppendices)
              .Add("--generatesExternalLink", GeneratesExternalLink)
              .Add("--host={value}", PdfHost)
              .Add("--keepRawFiles", KeepRawFiles)
              .Add("--errorHandling={value}", LoadErrorHandling)
              .Add("--locale={value}", Locale)
              .Add("--name={value}", Name)
              .Add("--noStdin", NoInputStreamArgs)
              .Add("--rawOutputFolder={value}", RawOutputFolder)
              .Add("{value}", ConfigFile)
              .Add("--changesFile={value}", ChangesFile)
              .Add("--cleanupCacheHistory", CleanupCacheHistory)
              .Add("--content={value}", Content, separator: ',')
              .Add("--disableGitFeatures", DisableGitFeatures)
              .Add("--dryRun", DryRun)
              .Add("--debug", EnableDebugMode)
              .Add("--exportRawModel", ExportRawModel)
              .Add("--exportViewModel", ExportViewModel)
              .Add("--falName={value}", FALName)
              .Add("--fileMetadataFile={value}", FileMetadataFilePath)
              .Add("--fileMetadataFiles={value}", FileMetadataFilePaths, separator: ',')
              .Add("--forcePostProcess", ForcePostProcess)
              .Add("--force", ForceRebuild)
              .Add("--globalMetadata={value}", GlobalMetadata)
              .Add("--globalMetadataFile={value}", GlobalMetadataFilePath)
              .Add("--globalMetadataFiles={value}", GlobalMetadataFilePaths, separator: ',')
              .Add("--hostname={value}", Host)
              .Add("--intermediateFolder={value}", IntermediateFolder)
              .Add("--keepFileLink", KeepFileLink)
              .Add("--lruSize={value}", LruSize)
              .Add("--markdownEngineName={value}", MarkdownEngineName)
              .Add("--markdownEngineProperties={value}", MarkdownEngineProperties)
              .Add("--maxParallelism={value}", MaxParallelism)
              .Add("--noLangKeyword", NoLangKeyword)
              .Add("--output={value}", OutputFolder)
              .Add("--debugOutput={value}", OutputFolderForDebugFiles)
              .Add("--overwrite={value}", Overwrite, separator: ',')
              .Add("--port={value}", Port)
              .Add("--postProcessors={value}", PostProcessors, separator: ',')
              .Add("--help", PrintHelpMessage)
              .Add("--rawModelOutputFolder={value}", RawModelOutputFolder)
              .Add("--resource={value}", Resource, separator: ',')
              .Add("--schemaLicense={value}", SchemaLicense)
              .Add("--serve", Serve)
              .Add("--template={value}", Templates, separator: ',')
              .Add("--theme={value}", Themes, separator: ',')
              .Add("--viewModelOutputFolder={value}", ViewModelOutputFolder)
              .Add("--xref={value}", XRefMaps, separator: ',')
              .Add("--correlationId={value}", CorrelationId)
              .Add("--log={value}", LogFilePath)
              .Add("--logLevel={value}", LogLevel)
              .Add("--repositoryRoot={value}", RepoRoot)
              .Add("--warningsAsErrors", WarningsAsErrors);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFXServeSettings
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFXServeSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DocFXTasks.DocFXPath;
        public override Action<OutputType, string> CustomLogger => DocFXTasks.DocFXLogger;
        public virtual string Folder { get; internal set; }
        /// <summary>
        ///   Specify the hostname of the hosted website [localhost].
        /// </summary>
        public virtual string Host { get; internal set; }
        /// <summary>
        ///   Specify the port of the hosted website [8080].
        /// </summary>
        public virtual int? Port { get; internal set; }
        /// <summary>
        ///   Print help message for this sub-command.
        /// </summary>
        public virtual bool? PrintHelpMessage { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("serve")
              .Add("{value}", Folder)
              .Add("--hostname={value}", Host)
              .Add("--port={value}", Port)
              .Add("--help", PrintHelpMessage);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFXTemplateSettings
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFXTemplateSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DocFX executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DocFXTasks.DocFXPath;
        public override Action<OutputType, string> CustomLogger => DocFXTasks.DocFXLogger;
        /// <summary>
        ///   The command to execute.
        /// </summary>
        public virtual string Command { get; internal set; }
        /// <summary>
        ///   If specified, all the available templates will be exported.
        /// </summary>
        public virtual bool? All { get; internal set; }
        /// <summary>
        ///   Specify the output folder path for the exported templates.
        /// </summary>
        public virtual string OutputFolder { get; internal set; }
        /// <summary>
        ///   Print help message for this sub-command.
        /// </summary>
        public virtual bool? PrintHelpMessage { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("template")
              .Add("{value}", Command, separator: ' ')
              .Add("--all", All)
              .Add("--output={value}", OutputFolder)
              .Add("--help", PrintHelpMessage);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFXBuildSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXBuildSettingsExtensions
    {
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.ConfigFile"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetConfigFile(this DocFXBuildSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.ConfigFile"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetConfigFile(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ChangesFile
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.ChangesFile"/></em></p>
        ///   <p>Set changes file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetChangesFile(this DocFXBuildSettings toolSettings, string changesFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangesFile = changesFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.ChangesFile"/></em></p>
        ///   <p>Set changes file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetChangesFile(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangesFile = null;
            return toolSettings;
        }
        #endregion
        #region CleanupCacheHistory
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.CleanupCacheHistory"/></em></p>
        ///   <p>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetCleanupCacheHistory(this DocFXBuildSettings toolSettings, bool? cleanupCacheHistory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupCacheHistory = cleanupCacheHistory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.CleanupCacheHistory"/></em></p>
        ///   <p>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetCleanupCacheHistory(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupCacheHistory = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.CleanupCacheHistory"/></em></p>
        ///   <p>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableCleanupCacheHistory(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupCacheHistory = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.CleanupCacheHistory"/></em></p>
        ///   <p>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableCleanupCacheHistory(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupCacheHistory = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.CleanupCacheHistory"/></em></p>
        ///   <p>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleCleanupCacheHistory(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupCacheHistory = !toolSettings.CleanupCacheHistory;
            return toolSettings;
        }
        #endregion
        #region Content
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Content"/> to a new list</em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetContent(this DocFXBuildSettings toolSettings, params string[] content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal = content.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Content"/> to a new list</em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetContent(this DocFXBuildSettings toolSettings, IEnumerable<string> content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal = content.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.Content"/></em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddContent(this DocFXBuildSettings toolSettings, params string[] content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal.AddRange(content);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.Content"/></em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddContent(this DocFXBuildSettings toolSettings, IEnumerable<string> content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal.AddRange(content);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXBuildSettings.Content"/></em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ClearContent(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.Content"/></em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveContent(this DocFXBuildSettings toolSettings, params string[] content)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(content);
            toolSettings.ContentInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.Content"/></em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveContent(this DocFXBuildSettings toolSettings, IEnumerable<string> content)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(content);
            toolSettings.ContentInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DisableGitFeatures
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetDisableGitFeatures(this DocFXBuildSettings toolSettings, bool? disableGitFeatures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = disableGitFeatures;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetDisableGitFeatures(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableDisableGitFeatures(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableDisableGitFeatures(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleDisableGitFeatures(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = !toolSettings.DisableGitFeatures;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.DryRun"/></em></p>
        ///   <p>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetDryRun(this DocFXBuildSettings toolSettings, bool? dryRun)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.DryRun"/></em></p>
        ///   <p>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetDryRun(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.DryRun"/></em></p>
        ///   <p>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableDryRun(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.DryRun"/></em></p>
        ///   <p>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableDryRun(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.DryRun"/></em></p>
        ///   <p>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleDryRun(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region EnableDebugMode
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.EnableDebugMode"/></em></p>
        ///   <p>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetEnableDebugMode(this DocFXBuildSettings toolSettings, bool? enableDebugMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableDebugMode = enableDebugMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.EnableDebugMode"/></em></p>
        ///   <p>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetEnableDebugMode(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableDebugMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.EnableDebugMode"/></em></p>
        ///   <p>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableEnableDebugMode(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableDebugMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.EnableDebugMode"/></em></p>
        ///   <p>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableEnableDebugMode(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableDebugMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.EnableDebugMode"/></em></p>
        ///   <p>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleEnableDebugMode(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableDebugMode = !toolSettings.EnableDebugMode;
            return toolSettings;
        }
        #endregion
        #region ExportRawModel
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.ExportRawModel"/></em></p>
        ///   <p>If set to true, data model to run template script will be extracted in .raw.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetExportRawModel(this DocFXBuildSettings toolSettings, bool? exportRawModel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportRawModel = exportRawModel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.ExportRawModel"/></em></p>
        ///   <p>If set to true, data model to run template script will be extracted in .raw.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetExportRawModel(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportRawModel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.ExportRawModel"/></em></p>
        ///   <p>If set to true, data model to run template script will be extracted in .raw.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableExportRawModel(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportRawModel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.ExportRawModel"/></em></p>
        ///   <p>If set to true, data model to run template script will be extracted in .raw.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableExportRawModel(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportRawModel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.ExportRawModel"/></em></p>
        ///   <p>If set to true, data model to run template script will be extracted in .raw.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleExportRawModel(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportRawModel = !toolSettings.ExportRawModel;
            return toolSettings;
        }
        #endregion
        #region ExportViewModel
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.ExportViewModel"/></em></p>
        ///   <p>If set to true, data model to apply template will be extracted in .view.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetExportViewModel(this DocFXBuildSettings toolSettings, bool? exportViewModel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportViewModel = exportViewModel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.ExportViewModel"/></em></p>
        ///   <p>If set to true, data model to apply template will be extracted in .view.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetExportViewModel(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportViewModel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.ExportViewModel"/></em></p>
        ///   <p>If set to true, data model to apply template will be extracted in .view.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableExportViewModel(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportViewModel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.ExportViewModel"/></em></p>
        ///   <p>If set to true, data model to apply template will be extracted in .view.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableExportViewModel(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportViewModel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.ExportViewModel"/></em></p>
        ///   <p>If set to true, data model to apply template will be extracted in .view.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleExportViewModel(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportViewModel = !toolSettings.ExportViewModel;
            return toolSettings;
        }
        #endregion
        #region FALName
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.FALName"/></em></p>
        ///   <p>Set the name of input file abstract layer builder.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetFALName(this DocFXBuildSettings toolSettings, string falname)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FALName = falname;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.FALName"/></em></p>
        ///   <p>Set the name of input file abstract layer builder.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetFALName(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FALName = null;
            return toolSettings;
        }
        #endregion
        #region FileMetadataFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.FileMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetFileMetadataFilePath(this DocFXBuildSettings toolSettings, string fileMetadataFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePath = fileMetadataFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.FileMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetFileMetadataFilePath(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePath = null;
            return toolSettings;
        }
        #endregion
        #region FileMetadataFilePaths
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.FileMetadataFilePaths"/> to a new list</em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetFileMetadataFilePaths(this DocFXBuildSettings toolSettings, params string[] fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePathsInternal = fileMetadataFilePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.FileMetadataFilePaths"/> to a new list</em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetFileMetadataFilePaths(this DocFXBuildSettings toolSettings, IEnumerable<string> fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePathsInternal = fileMetadataFilePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddFileMetadataFilePaths(this DocFXBuildSettings toolSettings, params string[] fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePathsInternal.AddRange(fileMetadataFilePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddFileMetadataFilePaths(this DocFXBuildSettings toolSettings, IEnumerable<string> fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePathsInternal.AddRange(fileMetadataFilePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ClearFileMetadataFilePaths(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveFileMetadataFilePaths(this DocFXBuildSettings toolSettings, params string[] fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fileMetadataFilePaths);
            toolSettings.FileMetadataFilePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveFileMetadataFilePaths(this DocFXBuildSettings toolSettings, IEnumerable<string> fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fileMetadataFilePaths);
            toolSettings.FileMetadataFilePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ForcePostProcess
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.ForcePostProcess"/></em></p>
        ///   <p>Force to re-process the documentation in post processors. It will be cascaded from force option.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetForcePostProcess(this DocFXBuildSettings toolSettings, bool? forcePostProcess)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePostProcess = forcePostProcess;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.ForcePostProcess"/></em></p>
        ///   <p>Force to re-process the documentation in post processors. It will be cascaded from force option.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetForcePostProcess(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePostProcess = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.ForcePostProcess"/></em></p>
        ///   <p>Force to re-process the documentation in post processors. It will be cascaded from force option.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableForcePostProcess(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePostProcess = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.ForcePostProcess"/></em></p>
        ///   <p>Force to re-process the documentation in post processors. It will be cascaded from force option.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableForcePostProcess(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePostProcess = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.ForcePostProcess"/></em></p>
        ///   <p>Force to re-process the documentation in post processors. It will be cascaded from force option.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleForcePostProcess(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePostProcess = !toolSettings.ForcePostProcess;
            return toolSettings;
        }
        #endregion
        #region ForceRebuild
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-build all the documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetForceRebuild(this DocFXBuildSettings toolSettings, bool? forceRebuild)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = forceRebuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-build all the documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetForceRebuild(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-build all the documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableForceRebuild(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-build all the documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableForceRebuild(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-build all the documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleForceRebuild(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = !toolSettings.ForceRebuild;
            return toolSettings;
        }
        #endregion
        #region GlobalMetadata
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.GlobalMetadata"/></em></p>
        ///   <p>Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetGlobalMetadata(this DocFXBuildSettings toolSettings, string globalMetadata)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadata = globalMetadata;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.GlobalMetadata"/></em></p>
        ///   <p>Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetGlobalMetadata(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadata = null;
            return toolSettings;
        }
        #endregion
        #region GlobalMetadataFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.GlobalMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetGlobalMetadataFilePath(this DocFXBuildSettings toolSettings, string globalMetadataFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePath = globalMetadataFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.GlobalMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetGlobalMetadataFilePath(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePath = null;
            return toolSettings;
        }
        #endregion
        #region GlobalMetadataFilePaths
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/> to a new list</em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetGlobalMetadataFilePaths(this DocFXBuildSettings toolSettings, params string[] globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePathsInternal = globalMetadataFilePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/> to a new list</em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetGlobalMetadataFilePaths(this DocFXBuildSettings toolSettings, IEnumerable<string> globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePathsInternal = globalMetadataFilePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddGlobalMetadataFilePaths(this DocFXBuildSettings toolSettings, params string[] globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePathsInternal.AddRange(globalMetadataFilePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddGlobalMetadataFilePaths(this DocFXBuildSettings toolSettings, IEnumerable<string> globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePathsInternal.AddRange(globalMetadataFilePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ClearGlobalMetadataFilePaths(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveGlobalMetadataFilePaths(this DocFXBuildSettings toolSettings, params string[] globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(globalMetadataFilePaths);
            toolSettings.GlobalMetadataFilePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveGlobalMetadataFilePaths(this DocFXBuildSettings toolSettings, IEnumerable<string> globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(globalMetadataFilePaths);
            toolSettings.GlobalMetadataFilePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Host
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Host"/></em></p>
        ///   <p>Specify the hostname of the hosted website (e.g., 'localhost' or '*').</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetHost(this DocFXBuildSettings toolSettings, string host)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Host = host;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.Host"/></em></p>
        ///   <p>Specify the hostname of the hosted website (e.g., 'localhost' or '*').</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetHost(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Host = null;
            return toolSettings;
        }
        #endregion
        #region IntermediateFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.IntermediateFolder"/></em></p>
        ///   <p>Set folder for intermediate build results.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetIntermediateFolder(this DocFXBuildSettings toolSettings, string intermediateFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntermediateFolder = intermediateFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.IntermediateFolder"/></em></p>
        ///   <p>Set folder for intermediate build results.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetIntermediateFolder(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntermediateFolder = null;
            return toolSettings;
        }
        #endregion
        #region KeepFileLink
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.KeepFileLink"/></em></p>
        ///   <p>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetKeepFileLink(this DocFXBuildSettings toolSettings, bool? keepFileLink)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFileLink = keepFileLink;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.KeepFileLink"/></em></p>
        ///   <p>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetKeepFileLink(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFileLink = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.KeepFileLink"/></em></p>
        ///   <p>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableKeepFileLink(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFileLink = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.KeepFileLink"/></em></p>
        ///   <p>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableKeepFileLink(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFileLink = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.KeepFileLink"/></em></p>
        ///   <p>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleKeepFileLink(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFileLink = !toolSettings.KeepFileLink;
            return toolSettings;
        }
        #endregion
        #region LruSize
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.LruSize"/></em></p>
        ///   <p>Set the LRU cached model count (approximately the same as the count of input files). By default, it is 8192 for 64bit and 3072 for 32bit process. With LRU cache enabled, memory usage decreases and time consumed increases. If set to 0, Lru cache is disabled.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetLruSize(this DocFXBuildSettings toolSettings, int? lruSize)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LruSize = lruSize;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.LruSize"/></em></p>
        ///   <p>Set the LRU cached model count (approximately the same as the count of input files). By default, it is 8192 for 64bit and 3072 for 32bit process. With LRU cache enabled, memory usage decreases and time consumed increases. If set to 0, Lru cache is disabled.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetLruSize(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LruSize = null;
            return toolSettings;
        }
        #endregion
        #region MarkdownEngineName
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.MarkdownEngineName"/></em></p>
        ///   <p>Set the name of markdown engine, default is 'dfm'.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetMarkdownEngineName(this DocFXBuildSettings toolSettings, string markdownEngineName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownEngineName = markdownEngineName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.MarkdownEngineName"/></em></p>
        ///   <p>Set the name of markdown engine, default is 'dfm'.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetMarkdownEngineName(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownEngineName = null;
            return toolSettings;
        }
        #endregion
        #region MarkdownEngineProperties
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.MarkdownEngineProperties"/></em></p>
        ///   <p>Set the parameters for markdown engine, value should be a JSON string.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetMarkdownEngineProperties(this DocFXBuildSettings toolSettings, string markdownEngineProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownEngineProperties = markdownEngineProperties;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.MarkdownEngineProperties"/></em></p>
        ///   <p>Set the parameters for markdown engine, value should be a JSON string.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetMarkdownEngineProperties(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownEngineProperties = null;
            return toolSettings;
        }
        #endregion
        #region MaxParallelism
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.MaxParallelism"/></em></p>
        ///   <p>Set the max parallelism, 0 is auto.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetMaxParallelism(this DocFXBuildSettings toolSettings, int? maxParallelism)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxParallelism = maxParallelism;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.MaxParallelism"/></em></p>
        ///   <p>Set the max parallelism, 0 is auto.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetMaxParallelism(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxParallelism = null;
            return toolSettings;
        }
        #endregion
        #region NoLangKeyword
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.NoLangKeyword"/></em></p>
        ///   <p>Disable default lang keyword.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetNoLangKeyword(this DocFXBuildSettings toolSettings, bool? noLangKeyword)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLangKeyword = noLangKeyword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.NoLangKeyword"/></em></p>
        ///   <p>Disable default lang keyword.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetNoLangKeyword(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLangKeyword = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.NoLangKeyword"/></em></p>
        ///   <p>Disable default lang keyword.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableNoLangKeyword(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLangKeyword = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.NoLangKeyword"/></em></p>
        ///   <p>Disable default lang keyword.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableNoLangKeyword(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLangKeyword = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.NoLangKeyword"/></em></p>
        ///   <p>Disable default lang keyword.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleNoLangKeyword(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLangKeyword = !toolSettings.NoLangKeyword;
            return toolSettings;
        }
        #endregion
        #region OutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.OutputFolder"/></em></p>
        ///   <p>Specify the output base directory.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetOutputFolder(this DocFXBuildSettings toolSettings, string outputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = outputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.OutputFolder"/></em></p>
        ///   <p>Specify the output base directory.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetOutputFolder(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region OutputFolderForDebugFiles
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.OutputFolderForDebugFiles"/></em></p>
        ///   <p>The output folder for files generated for debugging purpose when in debug mode. If not specified, it is ${TempPath}/docfx.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetOutputFolderForDebugFiles(this DocFXBuildSettings toolSettings, string outputFolderForDebugFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolderForDebugFiles = outputFolderForDebugFiles;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.OutputFolderForDebugFiles"/></em></p>
        ///   <p>The output folder for files generated for debugging purpose when in debug mode. If not specified, it is ${TempPath}/docfx.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetOutputFolderForDebugFiles(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolderForDebugFiles = null;
            return toolSettings;
        }
        #endregion
        #region Overwrite
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Overwrite"/> to a new list</em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetOverwrite(this DocFXBuildSettings toolSettings, params string[] overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteInternal = overwrite.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Overwrite"/> to a new list</em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetOverwrite(this DocFXBuildSettings toolSettings, IEnumerable<string> overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteInternal = overwrite.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.Overwrite"/></em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddOverwrite(this DocFXBuildSettings toolSettings, params string[] overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteInternal.AddRange(overwrite);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.Overwrite"/></em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddOverwrite(this DocFXBuildSettings toolSettings, IEnumerable<string> overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteInternal.AddRange(overwrite);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXBuildSettings.Overwrite"/></em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ClearOverwrite(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.Overwrite"/></em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveOverwrite(this DocFXBuildSettings toolSettings, params string[] overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(overwrite);
            toolSettings.OverwriteInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.Overwrite"/></em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveOverwrite(this DocFXBuildSettings toolSettings, IEnumerable<string> overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(overwrite);
            toolSettings.OverwriteInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Port
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Port"/></em></p>
        ///   <p>Specify the port of the hosted website.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetPort(this DocFXBuildSettings toolSettings, int? port)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = port;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.Port"/></em></p>
        ///   <p>Specify the port of the hosted website.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetPort(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = null;
            return toolSettings;
        }
        #endregion
        #region PostProcessors
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.PostProcessors"/> to a new list</em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetPostProcessors(this DocFXBuildSettings toolSettings, params string[] postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostProcessorsInternal = postProcessors.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.PostProcessors"/> to a new list</em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetPostProcessors(this DocFXBuildSettings toolSettings, IEnumerable<string> postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostProcessorsInternal = postProcessors.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.PostProcessors"/></em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddPostProcessors(this DocFXBuildSettings toolSettings, params string[] postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostProcessorsInternal.AddRange(postProcessors);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.PostProcessors"/></em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddPostProcessors(this DocFXBuildSettings toolSettings, IEnumerable<string> postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostProcessorsInternal.AddRange(postProcessors);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXBuildSettings.PostProcessors"/></em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ClearPostProcessors(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostProcessorsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.PostProcessors"/></em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemovePostProcessors(this DocFXBuildSettings toolSettings, params string[] postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(postProcessors);
            toolSettings.PostProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.PostProcessors"/></em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemovePostProcessors(this DocFXBuildSettings toolSettings, IEnumerable<string> postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(postProcessors);
            toolSettings.PostProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region PrintHelpMessage
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetPrintHelpMessage(this DocFXBuildSettings toolSettings, bool? printHelpMessage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = printHelpMessage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetPrintHelpMessage(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnablePrintHelpMessage(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisablePrintHelpMessage(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings TogglePrintHelpMessage(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = !toolSettings.PrintHelpMessage;
            return toolSettings;
        }
        #endregion
        #region RawModelOutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.RawModelOutputFolder"/></em></p>
        ///   <p>Specify the output folder for the raw model. If not set, the raw model will be generated to the same folder as the output documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetRawModelOutputFolder(this DocFXBuildSettings toolSettings, string rawModelOutputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawModelOutputFolder = rawModelOutputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.RawModelOutputFolder"/></em></p>
        ///   <p>Specify the output folder for the raw model. If not set, the raw model will be generated to the same folder as the output documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetRawModelOutputFolder(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawModelOutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region Resource
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Resource"/> to a new list</em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetResource(this DocFXBuildSettings toolSettings, params string[] resource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResourceInternal = resource.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Resource"/> to a new list</em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetResource(this DocFXBuildSettings toolSettings, IEnumerable<string> resource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResourceInternal = resource.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.Resource"/></em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddResource(this DocFXBuildSettings toolSettings, params string[] resource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResourceInternal.AddRange(resource);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.Resource"/></em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddResource(this DocFXBuildSettings toolSettings, IEnumerable<string> resource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResourceInternal.AddRange(resource);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXBuildSettings.Resource"/></em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ClearResource(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResourceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.Resource"/></em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveResource(this DocFXBuildSettings toolSettings, params string[] resource)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(resource);
            toolSettings.ResourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.Resource"/></em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveResource(this DocFXBuildSettings toolSettings, IEnumerable<string> resource)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(resource);
            toolSettings.ResourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SchemaLicense
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.SchemaLicense"/></em></p>
        ///   <p>Please provide the license key for validating schema using NewtonsoftJson.Schema here.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetSchemaLicense(this DocFXBuildSettings toolSettings, string schemaLicense)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SchemaLicense = schemaLicense;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.SchemaLicense"/></em></p>
        ///   <p>Please provide the license key for validating schema using NewtonsoftJson.Schema here.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetSchemaLicense(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SchemaLicense = null;
            return toolSettings;
        }
        #endregion
        #region Serve
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Serve"/></em></p>
        ///   <p>Host the generated documentation to a website.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetServe(this DocFXBuildSettings toolSettings, bool? serve)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = serve;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.Serve"/></em></p>
        ///   <p>Host the generated documentation to a website.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetServe(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.Serve"/></em></p>
        ///   <p>Host the generated documentation to a website.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableServe(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.Serve"/></em></p>
        ///   <p>Host the generated documentation to a website.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableServe(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.Serve"/></em></p>
        ///   <p>Host the generated documentation to a website.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleServe(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = !toolSettings.Serve;
            return toolSettings;
        }
        #endregion
        #region Templates
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Templates"/> to a new list</em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetTemplates(this DocFXBuildSettings toolSettings, params string[] templates)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplatesInternal = templates.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Templates"/> to a new list</em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetTemplates(this DocFXBuildSettings toolSettings, IEnumerable<string> templates)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplatesInternal = templates.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.Templates"/></em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddTemplates(this DocFXBuildSettings toolSettings, params string[] templates)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplatesInternal.AddRange(templates);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.Templates"/></em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddTemplates(this DocFXBuildSettings toolSettings, IEnumerable<string> templates)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplatesInternal.AddRange(templates);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXBuildSettings.Templates"/></em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ClearTemplates(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplatesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.Templates"/></em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveTemplates(this DocFXBuildSettings toolSettings, params string[] templates)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(templates);
            toolSettings.TemplatesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.Templates"/></em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveTemplates(this DocFXBuildSettings toolSettings, IEnumerable<string> templates)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(templates);
            toolSettings.TemplatesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Themes
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Themes"/> to a new list</em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetThemes(this DocFXBuildSettings toolSettings, params string[] themes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemesInternal = themes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.Themes"/> to a new list</em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetThemes(this DocFXBuildSettings toolSettings, IEnumerable<string> themes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemesInternal = themes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.Themes"/></em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddThemes(this DocFXBuildSettings toolSettings, params string[] themes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemesInternal.AddRange(themes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.Themes"/></em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddThemes(this DocFXBuildSettings toolSettings, IEnumerable<string> themes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemesInternal.AddRange(themes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXBuildSettings.Themes"/></em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ClearThemes(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.Themes"/></em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveThemes(this DocFXBuildSettings toolSettings, params string[] themes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(themes);
            toolSettings.ThemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.Themes"/></em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveThemes(this DocFXBuildSettings toolSettings, IEnumerable<string> themes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(themes);
            toolSettings.ThemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ViewModelOutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.ViewModelOutputFolder"/></em></p>
        ///   <p>Specify the output folder for the view model. If not set, the view model will be generated to the same folder as the output documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetViewModelOutputFolder(this DocFXBuildSettings toolSettings, string viewModelOutputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ViewModelOutputFolder = viewModelOutputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.ViewModelOutputFolder"/></em></p>
        ///   <p>Specify the output folder for the view model. If not set, the view model will be generated to the same folder as the output documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetViewModelOutputFolder(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ViewModelOutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region XRefMaps
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.XRefMaps"/> to a new list</em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetXRefMaps(this DocFXBuildSettings toolSettings, params string[] xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal = xrefMaps.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.XRefMaps"/> to a new list</em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetXRefMaps(this DocFXBuildSettings toolSettings, IEnumerable<string> xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal = xrefMaps.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.XRefMaps"/></em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddXRefMaps(this DocFXBuildSettings toolSettings, params string[] xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal.AddRange(xrefMaps);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXBuildSettings.XRefMaps"/></em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings AddXRefMaps(this DocFXBuildSettings toolSettings, IEnumerable<string> xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal.AddRange(xrefMaps);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXBuildSettings.XRefMaps"/></em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ClearXRefMaps(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.XRefMaps"/></em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveXRefMaps(this DocFXBuildSettings toolSettings, params string[] xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(xrefMaps);
            toolSettings.XRefMapsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXBuildSettings.XRefMaps"/></em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings RemoveXRefMaps(this DocFXBuildSettings toolSettings, IEnumerable<string> xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(xrefMaps);
            toolSettings.XRefMapsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region CorrelationId
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.CorrelationId"/></em></p>
        ///   <p>Specify the correlation id used for logging.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetCorrelationId(this DocFXBuildSettings toolSettings, string correlationId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CorrelationId = correlationId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.CorrelationId"/></em></p>
        ///   <p>Specify the correlation id used for logging.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetCorrelationId(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CorrelationId = null;
            return toolSettings;
        }
        #endregion
        #region LogFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.LogFilePath"/></em></p>
        ///   <p>Specify the file name to save processing log.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetLogFilePath(this DocFXBuildSettings toolSettings, string logFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = logFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.LogFilePath"/></em></p>
        ///   <p>Specify the file name to save processing log.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetLogFilePath(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = null;
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.LogLevel"/></em></p>
        ///   <p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetLogLevel(this DocFXBuildSettings toolSettings, DocFXLogLevel logLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.LogLevel"/></em></p>
        ///   <p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetLogLevel(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
        #region RepoRoot
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.RepoRoot"/></em></p>
        ///   <p>Specify the GIT repository root folder.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetRepoRoot(this DocFXBuildSettings toolSettings, string repoRoot)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoRoot = repoRoot;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.RepoRoot"/></em></p>
        ///   <p>Specify the GIT repository root folder.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetRepoRoot(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoRoot = null;
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXBuildSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings SetWarningsAsErrors(this DocFXBuildSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXBuildSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ResetWarningsAsErrors(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXBuildSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings EnableWarningsAsErrors(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXBuildSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings DisableWarningsAsErrors(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXBuildSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXBuildSettings ToggleWarningsAsErrors(this DocFXBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFXDependencySettingsExtensions
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXDependencySettingsExtensions
    {
        #region DependencyFile
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXDependencySettings.DependencyFile"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings SetDependencyFile(this DocFXDependencySettings toolSettings, string dependencyFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyFile = dependencyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXDependencySettings.DependencyFile"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings ResetDependencyFile(this DocFXDependencySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyFile = null;
            return toolSettings;
        }
        #endregion
        #region IntermediateFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXDependencySettings.IntermediateFolder"/></em></p>
        ///   <p>The intermediate folder that store cache files.</p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings SetIntermediateFolder(this DocFXDependencySettings toolSettings, string intermediateFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntermediateFolder = intermediateFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXDependencySettings.IntermediateFolder"/></em></p>
        ///   <p>The intermediate folder that store cache files.</p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings ResetIntermediateFolder(this DocFXDependencySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntermediateFolder = null;
            return toolSettings;
        }
        #endregion
        #region PrintHelpMessage
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXDependencySettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings SetPrintHelpMessage(this DocFXDependencySettings toolSettings, bool? printHelpMessage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = printHelpMessage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXDependencySettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings ResetPrintHelpMessage(this DocFXDependencySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXDependencySettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings EnablePrintHelpMessage(this DocFXDependencySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXDependencySettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings DisablePrintHelpMessage(this DocFXDependencySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXDependencySettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings TogglePrintHelpMessage(this DocFXDependencySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = !toolSettings.PrintHelpMessage;
            return toolSettings;
        }
        #endregion
        #region VersionName
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXDependencySettings.VersionName"/></em></p>
        ///   <p>The version name of the content.</p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings SetVersionName(this DocFXDependencySettings toolSettings, string versionName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionName = versionName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXDependencySettings.VersionName"/></em></p>
        ///   <p>The version name of the content.</p>
        /// </summary>
        [Pure]
        public static DocFXDependencySettings ResetVersionName(this DocFXDependencySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFXDownloadSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXDownloadSettingsExtensions
    {
        #region ArchiveFile
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXDownloadSettings.ArchiveFile"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXDownloadSettings SetArchiveFile(this DocFXDownloadSettings toolSettings, string archiveFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArchiveFile = archiveFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXDownloadSettings.ArchiveFile"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXDownloadSettings ResetArchiveFile(this DocFXDownloadSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArchiveFile = null;
            return toolSettings;
        }
        #endregion
        #region PrintHelpMessage
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXDownloadSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXDownloadSettings SetPrintHelpMessage(this DocFXDownloadSettings toolSettings, bool? printHelpMessage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = printHelpMessage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXDownloadSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXDownloadSettings ResetPrintHelpMessage(this DocFXDownloadSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXDownloadSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXDownloadSettings EnablePrintHelpMessage(this DocFXDownloadSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXDownloadSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXDownloadSettings DisablePrintHelpMessage(this DocFXDownloadSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXDownloadSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXDownloadSettings TogglePrintHelpMessage(this DocFXDownloadSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = !toolSettings.PrintHelpMessage;
            return toolSettings;
        }
        #endregion
        #region Uri
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXDownloadSettings.Uri"/></em></p>
        ///   <p>Specify the url of xrefmap.</p>
        /// </summary>
        [Pure]
        public static DocFXDownloadSettings SetUri(this DocFXDownloadSettings toolSettings, string uri)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uri = uri;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXDownloadSettings.Uri"/></em></p>
        ///   <p>Specify the url of xrefmap.</p>
        /// </summary>
        [Pure]
        public static DocFXDownloadSettings ResetUri(this DocFXDownloadSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uri = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFXHelpSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXHelpSettingsExtensions
    {
        #region Command
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXHelpSettings.Command"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXHelpSettings SetCommand(this DocFXHelpSettings toolSettings, string command)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXHelpSettings.Command"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXHelpSettings ResetCommand(this DocFXHelpSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFXInitSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXInitSettingsExtensions
    {
        #region ApiSourceFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXInitSettings.ApiSourceFolder"/></em></p>
        ///   <p>Specify the source working folder for source project files to start glob search.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings SetApiSourceFolder(this DocFXInitSettings toolSettings, string apiSourceFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiSourceFolder = apiSourceFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXInitSettings.ApiSourceFolder"/></em></p>
        ///   <p>Specify the source working folder for source project files to start glob search.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings ResetApiSourceFolder(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiSourceFolder = null;
            return toolSettings;
        }
        #endregion
        #region ApiSourceGlobPattern
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXInitSettings.ApiSourceGlobPattern"/></em></p>
        ///   <p>Specify the source project files' glob pattern to generate metadata.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings SetApiSourceGlobPattern(this DocFXInitSettings toolSettings, string apiSourceGlobPattern)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiSourceGlobPattern = apiSourceGlobPattern;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXInitSettings.ApiSourceGlobPattern"/></em></p>
        ///   <p>Specify the source project files' glob pattern to generate metadata.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings ResetApiSourceGlobPattern(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiSourceGlobPattern = null;
            return toolSettings;
        }
        #endregion
        #region OnlyConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXInitSettings.OnlyConfigFile"/></em></p>
        ///   <p>Generate config file docfx.json only, no project folder will be generated.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings SetOnlyConfigFile(this DocFXInitSettings toolSettings, bool? onlyConfigFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyConfigFile = onlyConfigFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXInitSettings.OnlyConfigFile"/></em></p>
        ///   <p>Generate config file docfx.json only, no project folder will be generated.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings ResetOnlyConfigFile(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyConfigFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXInitSettings.OnlyConfigFile"/></em></p>
        ///   <p>Generate config file docfx.json only, no project folder will be generated.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings EnableOnlyConfigFile(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyConfigFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXInitSettings.OnlyConfigFile"/></em></p>
        ///   <p>Generate config file docfx.json only, no project folder will be generated.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings DisableOnlyConfigFile(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyConfigFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXInitSettings.OnlyConfigFile"/></em></p>
        ///   <p>Generate config file docfx.json only, no project folder will be generated.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings ToggleOnlyConfigFile(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyConfigFile = !toolSettings.OnlyConfigFile;
            return toolSettings;
        }
        #endregion
        #region OutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXInitSettings.OutputFolder"/></em></p>
        ///   <p>Specify the output folder of the config file. If not specified, the config file will be saved to a new folder docfx_project.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings SetOutputFolder(this DocFXInitSettings toolSettings, string outputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = outputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXInitSettings.OutputFolder"/></em></p>
        ///   <p>Specify the output folder of the config file. If not specified, the config file will be saved to a new folder docfx_project.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings ResetOutputFolder(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region Overwrite
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXInitSettings.Overwrite"/></em></p>
        ///   <p>Specify if the current file will be overwritten if it exists.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings SetOverwrite(this DocFXInitSettings toolSettings, bool? overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = overwrite;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXInitSettings.Overwrite"/></em></p>
        ///   <p>Specify if the current file will be overwritten if it exists.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings ResetOverwrite(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXInitSettings.Overwrite"/></em></p>
        ///   <p>Specify if the current file will be overwritten if it exists.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings EnableOverwrite(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXInitSettings.Overwrite"/></em></p>
        ///   <p>Specify if the current file will be overwritten if it exists.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings DisableOverwrite(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXInitSettings.Overwrite"/></em></p>
        ///   <p>Specify if the current file will be overwritten if it exists.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings ToggleOverwrite(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = !toolSettings.Overwrite;
            return toolSettings;
        }
        #endregion
        #region PrintHelpMessage
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXInitSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings SetPrintHelpMessage(this DocFXInitSettings toolSettings, bool? printHelpMessage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = printHelpMessage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXInitSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings ResetPrintHelpMessage(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXInitSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings EnablePrintHelpMessage(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXInitSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings DisablePrintHelpMessage(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXInitSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings TogglePrintHelpMessage(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = !toolSettings.PrintHelpMessage;
            return toolSettings;
        }
        #endregion
        #region Quiet
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXInitSettings.Quiet"/></em></p>
        ///   <p>Quietly generate the default docfx.json.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings SetQuiet(this DocFXInitSettings toolSettings, bool? quiet)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = quiet;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXInitSettings.Quiet"/></em></p>
        ///   <p>Quietly generate the default docfx.json.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings ResetQuiet(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXInitSettings.Quiet"/></em></p>
        ///   <p>Quietly generate the default docfx.json.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings EnableQuiet(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXInitSettings.Quiet"/></em></p>
        ///   <p>Quietly generate the default docfx.json.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings DisableQuiet(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXInitSettings.Quiet"/></em></p>
        ///   <p>Quietly generate the default docfx.json.</p>
        /// </summary>
        [Pure]
        public static DocFXInitSettings ToggleQuiet(this DocFXInitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = !toolSettings.Quiet;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFXMergeSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXMergeSettingsExtensions
    {
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.ConfigFile"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetConfigFile(this DocFXMergeSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMergeSettings.ConfigFile"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ResetConfigFile(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Content
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.Content"/> to a new list</em></p>
        ///   <p>Specifies content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetContent(this DocFXMergeSettings toolSettings, params string[] content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal = content.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.Content"/> to a new list</em></p>
        ///   <p>Specifies content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetContent(this DocFXMergeSettings toolSettings, IEnumerable<string> content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal = content.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXMergeSettings.Content"/></em></p>
        ///   <p>Specifies content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings AddContent(this DocFXMergeSettings toolSettings, params string[] content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal.AddRange(content);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXMergeSettings.Content"/></em></p>
        ///   <p>Specifies content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings AddContent(this DocFXMergeSettings toolSettings, IEnumerable<string> content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal.AddRange(content);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXMergeSettings.Content"/></em></p>
        ///   <p>Specifies content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ClearContent(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXMergeSettings.Content"/></em></p>
        ///   <p>Specifies content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings RemoveContent(this DocFXMergeSettings toolSettings, params string[] content)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(content);
            toolSettings.ContentInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXMergeSettings.Content"/></em></p>
        ///   <p>Specifies content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings RemoveContent(this DocFXMergeSettings toolSettings, IEnumerable<string> content)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(content);
            toolSettings.ContentInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region FileMetadataFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.FileMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetFileMetadataFilePath(this DocFXMergeSettings toolSettings, string fileMetadataFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePath = fileMetadataFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMergeSettings.FileMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ResetFileMetadataFilePath(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePath = null;
            return toolSettings;
        }
        #endregion
        #region GlobalMetadata
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.GlobalMetadata"/></em></p>
        ///   <p>Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetGlobalMetadata(this DocFXMergeSettings toolSettings, string globalMetadata)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadata = globalMetadata;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMergeSettings.GlobalMetadata"/></em></p>
        ///   <p>Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ResetGlobalMetadata(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadata = null;
            return toolSettings;
        }
        #endregion
        #region GlobalMetadataFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.GlobalMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetGlobalMetadataFilePath(this DocFXMergeSettings toolSettings, string globalMetadataFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePath = globalMetadataFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMergeSettings.GlobalMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ResetGlobalMetadataFilePath(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePath = null;
            return toolSettings;
        }
        #endregion
        #region PrintHelpMessage
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetPrintHelpMessage(this DocFXMergeSettings toolSettings, bool? printHelpMessage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = printHelpMessage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMergeSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ResetPrintHelpMessage(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXMergeSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings EnablePrintHelpMessage(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXMergeSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings DisablePrintHelpMessage(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXMergeSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings TogglePrintHelpMessage(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = !toolSettings.PrintHelpMessage;
            return toolSettings;
        }
        #endregion
        #region TocMetadata
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.TocMetadata"/> to a new list</em></p>
        ///   <p>Specify metadata names that need to be merged into toc file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetTocMetadata(this DocFXMergeSettings toolSettings, params string[] tocMetadata)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TocMetadataInternal = tocMetadata.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.TocMetadata"/> to a new list</em></p>
        ///   <p>Specify metadata names that need to be merged into toc file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetTocMetadata(this DocFXMergeSettings toolSettings, IEnumerable<string> tocMetadata)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TocMetadataInternal = tocMetadata.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXMergeSettings.TocMetadata"/></em></p>
        ///   <p>Specify metadata names that need to be merged into toc file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings AddTocMetadata(this DocFXMergeSettings toolSettings, params string[] tocMetadata)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TocMetadataInternal.AddRange(tocMetadata);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXMergeSettings.TocMetadata"/></em></p>
        ///   <p>Specify metadata names that need to be merged into toc file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings AddTocMetadata(this DocFXMergeSettings toolSettings, IEnumerable<string> tocMetadata)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TocMetadataInternal.AddRange(tocMetadata);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXMergeSettings.TocMetadata"/></em></p>
        ///   <p>Specify metadata names that need to be merged into toc file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ClearTocMetadata(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TocMetadataInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXMergeSettings.TocMetadata"/></em></p>
        ///   <p>Specify metadata names that need to be merged into toc file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings RemoveTocMetadata(this DocFXMergeSettings toolSettings, params string[] tocMetadata)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(tocMetadata);
            toolSettings.TocMetadataInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXMergeSettings.TocMetadata"/></em></p>
        ///   <p>Specify metadata names that need to be merged into toc file.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings RemoveTocMetadata(this DocFXMergeSettings toolSettings, IEnumerable<string> tocMetadata)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(tocMetadata);
            toolSettings.TocMetadataInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region CorrelationId
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.CorrelationId"/></em></p>
        ///   <p>Specify the correlation id used for logging.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetCorrelationId(this DocFXMergeSettings toolSettings, string correlationId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CorrelationId = correlationId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMergeSettings.CorrelationId"/></em></p>
        ///   <p>Specify the correlation id used for logging.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ResetCorrelationId(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CorrelationId = null;
            return toolSettings;
        }
        #endregion
        #region LogFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.LogFilePath"/></em></p>
        ///   <p>Specify the file name to save processing log.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetLogFilePath(this DocFXMergeSettings toolSettings, string logFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = logFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMergeSettings.LogFilePath"/></em></p>
        ///   <p>Specify the file name to save processing log.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ResetLogFilePath(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = null;
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.LogLevel"/></em></p>
        ///   <p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetLogLevel(this DocFXMergeSettings toolSettings, DocFXLogLevel logLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMergeSettings.LogLevel"/></em></p>
        ///   <p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ResetLogLevel(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
        #region RepoRoot
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.RepoRoot"/></em></p>
        ///   <p>Specify the GIT repository root folder.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetRepoRoot(this DocFXMergeSettings toolSettings, string repoRoot)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoRoot = repoRoot;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMergeSettings.RepoRoot"/></em></p>
        ///   <p>Specify the GIT repository root folder.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ResetRepoRoot(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoRoot = null;
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMergeSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings SetWarningsAsErrors(this DocFXMergeSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMergeSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ResetWarningsAsErrors(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXMergeSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings EnableWarningsAsErrors(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXMergeSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings DisableWarningsAsErrors(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXMergeSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXMergeSettings ToggleWarningsAsErrors(this DocFXMergeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFXMetadataSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXMetadataSettingsExtensions
    {
        #region Projects
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.Projects"/> to a new list</em></p>
        ///   <p>The projects for which the metadata should be built.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetProjects(this DocFXMetadataSettings toolSettings, params string[] projects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectsInternal = projects.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.Projects"/> to a new list</em></p>
        ///   <p>The projects for which the metadata should be built.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetProjects(this DocFXMetadataSettings toolSettings, IEnumerable<string> projects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectsInternal = projects.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXMetadataSettings.Projects"/></em></p>
        ///   <p>The projects for which the metadata should be built.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings AddProjects(this DocFXMetadataSettings toolSettings, params string[] projects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectsInternal.AddRange(projects);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXMetadataSettings.Projects"/></em></p>
        ///   <p>The projects for which the metadata should be built.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings AddProjects(this DocFXMetadataSettings toolSettings, IEnumerable<string> projects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectsInternal.AddRange(projects);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXMetadataSettings.Projects"/></em></p>
        ///   <p>The projects for which the metadata should be built.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ClearProjects(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXMetadataSettings.Projects"/></em></p>
        ///   <p>The projects for which the metadata should be built.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings RemoveProjects(this DocFXMetadataSettings toolSettings, params string[] projects)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(projects);
            toolSettings.ProjectsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXMetadataSettings.Projects"/></em></p>
        ///   <p>The projects for which the metadata should be built.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings RemoveProjects(this DocFXMetadataSettings toolSettings, IEnumerable<string> projects)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(projects);
            toolSettings.ProjectsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DisableDefaultFilter
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></em></p>
        ///   <p>Disable the default API filter (default filter only generate public or protected APIs).</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetDisableDefaultFilter(this DocFXMetadataSettings toolSettings, bool? disableDefaultFilter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilter = disableDefaultFilter;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></em></p>
        ///   <p>Disable the default API filter (default filter only generate public or protected APIs).</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetDisableDefaultFilter(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilter = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></em></p>
        ///   <p>Disable the default API filter (default filter only generate public or protected APIs).</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings EnableDisableDefaultFilter(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilter = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></em></p>
        ///   <p>Disable the default API filter (default filter only generate public or protected APIs).</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings DisableDisableDefaultFilter(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilter = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></em></p>
        ///   <p>Disable the default API filter (default filter only generate public or protected APIs).</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ToggleDisableDefaultFilter(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableDefaultFilter = !toolSettings.DisableDefaultFilter;
            return toolSettings;
        }
        #endregion
        #region DisableGitFeatures
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetDisableGitFeatures(this DocFXMetadataSettings toolSettings, bool? disableGitFeatures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = disableGitFeatures;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetDisableGitFeatures(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXMetadataSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings EnableDisableGitFeatures(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXMetadataSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings DisableDisableGitFeatures(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXMetadataSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ToggleDisableGitFeatures(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = !toolSettings.DisableGitFeatures;
            return toolSettings;
        }
        #endregion
        #region FilterConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.FilterConfigFile"/></em></p>
        ///   <p>Specify the filter config file.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetFilterConfigFile(this DocFXMetadataSettings toolSettings, string filterConfigFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilterConfigFile = filterConfigFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.FilterConfigFile"/></em></p>
        ///   <p>Specify the filter config file.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetFilterConfigFile(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilterConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ForceRebuild
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetForceRebuild(this DocFXMetadataSettings toolSettings, bool? forceRebuild)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = forceRebuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetForceRebuild(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXMetadataSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings EnableForceRebuild(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXMetadataSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings DisableForceRebuild(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXMetadataSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ToggleForceRebuild(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = !toolSettings.ForceRebuild;
            return toolSettings;
        }
        #endregion
        #region GlobalNamespaceId
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.GlobalNamespaceId"/></em></p>
        ///   <p>Specify the name to use for the global namespace.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetGlobalNamespaceId(this DocFXMetadataSettings toolSettings, string globalNamespaceId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalNamespaceId = globalNamespaceId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.GlobalNamespaceId"/></em></p>
        ///   <p>Specify the name to use for the global namespace.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetGlobalNamespaceId(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalNamespaceId = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildProperties
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.MSBuildProperties"/> to a new dictionary</em></p>
        ///   <p>--property &lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; An optional set of MSBuild properties used when interpreting project files. These are the same properties that are passed to msbuild via the /property:&lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; command line argument.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetMSBuildProperties(this DocFXMetadataSettings toolSettings, IDictionary<string, string> msbuildProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPropertiesInternal = msbuildProperties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXMetadataSettings.MSBuildProperties"/></em></p>
        ///   <p>--property &lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; An optional set of MSBuild properties used when interpreting project files. These are the same properties that are passed to msbuild via the /property:&lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; command line argument.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ClearMSBuildProperties(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="DocFXMetadataSettings.MSBuildProperties"/></em></p>
        ///   <p>--property &lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; An optional set of MSBuild properties used when interpreting project files. These are the same properties that are passed to msbuild via the /property:&lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; command line argument.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings AddMSBuildProperty(this DocFXMetadataSettings toolSettings, string msbuildPropertyKey, string msbuildPropertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPropertiesInternal.Add(msbuildPropertyKey, msbuildPropertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="DocFXMetadataSettings.MSBuildProperties"/></em></p>
        ///   <p>--property &lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; An optional set of MSBuild properties used when interpreting project files. These are the same properties that are passed to msbuild via the /property:&lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; command line argument.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings RemoveMSBuildProperty(this DocFXMetadataSettings toolSettings, string msbuildPropertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPropertiesInternal.Remove(msbuildPropertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="DocFXMetadataSettings.MSBuildProperties"/></em></p>
        ///   <p>--property &lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; An optional set of MSBuild properties used when interpreting project files. These are the same properties that are passed to msbuild via the /property:&lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; command line argument.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetMSBuildProperty(this DocFXMetadataSettings toolSettings, string msbuildPropertyKey, string msbuildPropertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPropertiesInternal[msbuildPropertyKey] = msbuildPropertyValue;
            return toolSettings;
        }
        #endregion
        #region OutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.OutputFolder"/></em></p>
        ///   <p>Specify the output base directory.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetOutputFolder(this DocFXMetadataSettings toolSettings, string outputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = outputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.OutputFolder"/></em></p>
        ///   <p>Specify the output base directory.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetOutputFolder(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region PreserveRawInlineComments
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></em></p>
        ///   <p>Preserve the existing xml comment tags inside 'summary' triple slash comments.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetPreserveRawInlineComments(this DocFXMetadataSettings toolSettings, bool? preserveRawInlineComments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreserveRawInlineComments = preserveRawInlineComments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></em></p>
        ///   <p>Preserve the existing xml comment tags inside 'summary' triple slash comments.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetPreserveRawInlineComments(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreserveRawInlineComments = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></em></p>
        ///   <p>Preserve the existing xml comment tags inside 'summary' triple slash comments.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings EnablePreserveRawInlineComments(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreserveRawInlineComments = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></em></p>
        ///   <p>Preserve the existing xml comment tags inside 'summary' triple slash comments.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings DisablePreserveRawInlineComments(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreserveRawInlineComments = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></em></p>
        ///   <p>Preserve the existing xml comment tags inside 'summary' triple slash comments.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings TogglePreserveRawInlineComments(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreserveRawInlineComments = !toolSettings.PreserveRawInlineComments;
            return toolSettings;
        }
        #endregion
        #region PrintHelpMessage
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetPrintHelpMessage(this DocFXMetadataSettings toolSettings, bool? printHelpMessage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = printHelpMessage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetPrintHelpMessage(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXMetadataSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings EnablePrintHelpMessage(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXMetadataSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings DisablePrintHelpMessage(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXMetadataSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings TogglePrintHelpMessage(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = !toolSettings.PrintHelpMessage;
            return toolSettings;
        }
        #endregion
        #region ShouldSkipMarkup
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></em></p>
        ///   <p>Skip to markup the triple slash comments.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetShouldSkipMarkup(this DocFXMetadataSettings toolSettings, bool? shouldSkipMarkup)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShouldSkipMarkup = shouldSkipMarkup;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></em></p>
        ///   <p>Skip to markup the triple slash comments.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetShouldSkipMarkup(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShouldSkipMarkup = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></em></p>
        ///   <p>Skip to markup the triple slash comments.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings EnableShouldSkipMarkup(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShouldSkipMarkup = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></em></p>
        ///   <p>Skip to markup the triple slash comments.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings DisableShouldSkipMarkup(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShouldSkipMarkup = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></em></p>
        ///   <p>Skip to markup the triple slash comments.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ToggleShouldSkipMarkup(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShouldSkipMarkup = !toolSettings.ShouldSkipMarkup;
            return toolSettings;
        }
        #endregion
        #region CorrelationId
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.CorrelationId"/></em></p>
        ///   <p>Specify the correlation id used for logging.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetCorrelationId(this DocFXMetadataSettings toolSettings, string correlationId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CorrelationId = correlationId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.CorrelationId"/></em></p>
        ///   <p>Specify the correlation id used for logging.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetCorrelationId(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CorrelationId = null;
            return toolSettings;
        }
        #endregion
        #region LogFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.LogFilePath"/></em></p>
        ///   <p>Specify the file name to save processing log.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetLogFilePath(this DocFXMetadataSettings toolSettings, string logFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = logFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.LogFilePath"/></em></p>
        ///   <p>Specify the file name to save processing log.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetLogFilePath(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = null;
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.LogLevel"/></em></p>
        ///   <p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetLogLevel(this DocFXMetadataSettings toolSettings, DocFXLogLevel logLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.LogLevel"/></em></p>
        ///   <p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetLogLevel(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
        #region RepoRoot
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.RepoRoot"/></em></p>
        ///   <p>Specify the GIT repository root folder.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetRepoRoot(this DocFXMetadataSettings toolSettings, string repoRoot)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoRoot = repoRoot;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.RepoRoot"/></em></p>
        ///   <p>Specify the GIT repository root folder.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetRepoRoot(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoRoot = null;
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXMetadataSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings SetWarningsAsErrors(this DocFXMetadataSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXMetadataSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ResetWarningsAsErrors(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXMetadataSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings EnableWarningsAsErrors(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXMetadataSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings DisableWarningsAsErrors(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXMetadataSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXMetadataSettings ToggleWarningsAsErrors(this DocFXMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFXPdfSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXPdfSettingsExtensions
    {
        #region BasePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.BasePath"/></em></p>
        ///   <p>Specify the base path to generate external link, {host}/{locale}/{basePath}.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetBasePath(this DocFXPdfSettings toolSettings, string basePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = basePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.BasePath"/></em></p>
        ///   <p>Specify the base path to generate external link, {host}/{locale}/{basePath}.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetBasePath(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = null;
            return toolSettings;
        }
        #endregion
        #region CssFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.CssFilePath"/></em></p>
        ///   <p>Specify the path for the css to generate pdf, default value is styles/default.css.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetCssFilePath(this DocFXPdfSettings toolSettings, string cssFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CssFilePath = cssFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.CssFilePath"/></em></p>
        ///   <p>Specify the path for the css to generate pdf, default value is styles/default.css.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetCssFilePath(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CssFilePath = null;
            return toolSettings;
        }
        #endregion
        #region ExcludedTocs
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.ExcludedTocs"/> to a new list</em></p>
        ///   <p>Specify the toc files to be excluded.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetExcludedTocs(this DocFXPdfSettings toolSettings, params string[] excludedTocs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTocsInternal = excludedTocs.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.ExcludedTocs"/> to a new list</em></p>
        ///   <p>Specify the toc files to be excluded.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetExcludedTocs(this DocFXPdfSettings toolSettings, IEnumerable<string> excludedTocs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTocsInternal = excludedTocs.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.ExcludedTocs"/></em></p>
        ///   <p>Specify the toc files to be excluded.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddExcludedTocs(this DocFXPdfSettings toolSettings, params string[] excludedTocs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTocsInternal.AddRange(excludedTocs);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.ExcludedTocs"/></em></p>
        ///   <p>Specify the toc files to be excluded.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddExcludedTocs(this DocFXPdfSettings toolSettings, IEnumerable<string> excludedTocs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTocsInternal.AddRange(excludedTocs);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXPdfSettings.ExcludedTocs"/></em></p>
        ///   <p>Specify the toc files to be excluded.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ClearExcludedTocs(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludedTocsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.ExcludedTocs"/></em></p>
        ///   <p>Specify the toc files to be excluded.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveExcludedTocs(this DocFXPdfSettings toolSettings, params string[] excludedTocs)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTocs);
            toolSettings.ExcludedTocsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.ExcludedTocs"/></em></p>
        ///   <p>Specify the toc files to be excluded.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveExcludedTocs(this DocFXPdfSettings toolSettings, IEnumerable<string> excludedTocs)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludedTocs);
            toolSettings.ExcludedTocsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GeneratesAppendices
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.GeneratesAppendices"/></em></p>
        ///   <p>Specify whether or not to generate appendices for not-in-TOC articles.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetGeneratesAppendices(this DocFXPdfSettings toolSettings, bool? generatesAppendices)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratesAppendices = generatesAppendices;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.GeneratesAppendices"/></em></p>
        ///   <p>Specify whether or not to generate appendices for not-in-TOC articles.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetGeneratesAppendices(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratesAppendices = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.GeneratesAppendices"/></em></p>
        ///   <p>Specify whether or not to generate appendices for not-in-TOC articles.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableGeneratesAppendices(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratesAppendices = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.GeneratesAppendices"/></em></p>
        ///   <p>Specify whether or not to generate appendices for not-in-TOC articles.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableGeneratesAppendices(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratesAppendices = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.GeneratesAppendices"/></em></p>
        ///   <p>Specify whether or not to generate appendices for not-in-TOC articles.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleGeneratesAppendices(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratesAppendices = !toolSettings.GeneratesAppendices;
            return toolSettings;
        }
        #endregion
        #region GeneratesExternalLink
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.GeneratesExternalLink"/></em></p>
        ///   <p>Specify whether or not to generate external links for PDF.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetGeneratesExternalLink(this DocFXPdfSettings toolSettings, bool? generatesExternalLink)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratesExternalLink = generatesExternalLink;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.GeneratesExternalLink"/></em></p>
        ///   <p>Specify whether or not to generate external links for PDF.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetGeneratesExternalLink(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratesExternalLink = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.GeneratesExternalLink"/></em></p>
        ///   <p>Specify whether or not to generate external links for PDF.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableGeneratesExternalLink(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratesExternalLink = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.GeneratesExternalLink"/></em></p>
        ///   <p>Specify whether or not to generate external links for PDF.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableGeneratesExternalLink(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratesExternalLink = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.GeneratesExternalLink"/></em></p>
        ///   <p>Specify whether or not to generate external links for PDF.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleGeneratesExternalLink(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratesExternalLink = !toolSettings.GeneratesExternalLink;
            return toolSettings;
        }
        #endregion
        #region PdfHost
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.PdfHost"/></em></p>
        ///   <p>Specify the hostname to link not-in-TOC articles.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetPdfHost(this DocFXPdfSettings toolSettings, string pdfHost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdfHost = pdfHost;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.PdfHost"/></em></p>
        ///   <p>Specify the hostname to link not-in-TOC articles.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetPdfHost(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdfHost = null;
            return toolSettings;
        }
        #endregion
        #region KeepRawFiles
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.KeepRawFiles"/></em></p>
        ///   <p>Specify whether or not to keep the intermediate html files that used to generate the PDF file. It it usually used in debug purpose. By default the value is false.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetKeepRawFiles(this DocFXPdfSettings toolSettings, bool? keepRawFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepRawFiles = keepRawFiles;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.KeepRawFiles"/></em></p>
        ///   <p>Specify whether or not to keep the intermediate html files that used to generate the PDF file. It it usually used in debug purpose. By default the value is false.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetKeepRawFiles(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepRawFiles = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.KeepRawFiles"/></em></p>
        ///   <p>Specify whether or not to keep the intermediate html files that used to generate the PDF file. It it usually used in debug purpose. By default the value is false.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableKeepRawFiles(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepRawFiles = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.KeepRawFiles"/></em></p>
        ///   <p>Specify whether or not to keep the intermediate html files that used to generate the PDF file. It it usually used in debug purpose. By default the value is false.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableKeepRawFiles(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepRawFiles = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.KeepRawFiles"/></em></p>
        ///   <p>Specify whether or not to keep the intermediate html files that used to generate the PDF file. It it usually used in debug purpose. By default the value is false.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleKeepRawFiles(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepRawFiles = !toolSettings.KeepRawFiles;
            return toolSettings;
        }
        #endregion
        #region LoadErrorHandling
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.LoadErrorHandling"/></em></p>
        ///   <p>Specify how to handle pdf pages that fail to load: abort, ignore or skip(default abort), it is the same input as wkhtmltopdf --load-error-handling options.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetLoadErrorHandling(this DocFXPdfSettings toolSettings, string loadErrorHandling)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadErrorHandling = loadErrorHandling;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.LoadErrorHandling"/></em></p>
        ///   <p>Specify how to handle pdf pages that fail to load: abort, ignore or skip(default abort), it is the same input as wkhtmltopdf --load-error-handling options.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetLoadErrorHandling(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadErrorHandling = null;
            return toolSettings;
        }
        #endregion
        #region Locale
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Locale"/></em></p>
        ///   <p>Specify the locale of the pdf file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetLocale(this DocFXPdfSettings toolSettings, string locale)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Locale = locale;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.Locale"/></em></p>
        ///   <p>Specify the locale of the pdf file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetLocale(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Locale = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Name"/></em></p>
        ///   <p>Specify the name of the generated pdf.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetName(this DocFXPdfSettings toolSettings, string name)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.Name"/></em></p>
        ///   <p>Specify the name of the generated pdf.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetName(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region NoInputStreamArgs
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.NoInputStreamArgs"/></em></p>
        ///   <p>Do not use stdin when wkhtmltopdf is executed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetNoInputStreamArgs(this DocFXPdfSettings toolSettings, bool? noInputStreamArgs)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInputStreamArgs = noInputStreamArgs;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.NoInputStreamArgs"/></em></p>
        ///   <p>Do not use stdin when wkhtmltopdf is executed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetNoInputStreamArgs(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInputStreamArgs = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.NoInputStreamArgs"/></em></p>
        ///   <p>Do not use stdin when wkhtmltopdf is executed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableNoInputStreamArgs(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInputStreamArgs = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.NoInputStreamArgs"/></em></p>
        ///   <p>Do not use stdin when wkhtmltopdf is executed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableNoInputStreamArgs(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInputStreamArgs = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.NoInputStreamArgs"/></em></p>
        ///   <p>Do not use stdin when wkhtmltopdf is executed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleNoInputStreamArgs(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInputStreamArgs = !toolSettings.NoInputStreamArgs;
            return toolSettings;
        }
        #endregion
        #region RawOutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.RawOutputFolder"/></em></p>
        ///   <p>Specify the output folder for the raw files, if not specified, raw files will by default be saved to _raw subfolder under output folder if keepRawFiles is set to true.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetRawOutputFolder(this DocFXPdfSettings toolSettings, string rawOutputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawOutputFolder = rawOutputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.RawOutputFolder"/></em></p>
        ///   <p>Specify the output folder for the raw files, if not specified, raw files will by default be saved to _raw subfolder under output folder if keepRawFiles is set to true.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetRawOutputFolder(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawOutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.ConfigFile"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetConfigFile(this DocFXPdfSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.ConfigFile"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetConfigFile(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ChangesFile
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.ChangesFile"/></em></p>
        ///   <p>Set changes file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetChangesFile(this DocFXPdfSettings toolSettings, string changesFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangesFile = changesFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.ChangesFile"/></em></p>
        ///   <p>Set changes file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetChangesFile(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangesFile = null;
            return toolSettings;
        }
        #endregion
        #region CleanupCacheHistory
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.CleanupCacheHistory"/></em></p>
        ///   <p>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetCleanupCacheHistory(this DocFXPdfSettings toolSettings, bool? cleanupCacheHistory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupCacheHistory = cleanupCacheHistory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.CleanupCacheHistory"/></em></p>
        ///   <p>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetCleanupCacheHistory(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupCacheHistory = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.CleanupCacheHistory"/></em></p>
        ///   <p>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableCleanupCacheHistory(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupCacheHistory = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.CleanupCacheHistory"/></em></p>
        ///   <p>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableCleanupCacheHistory(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupCacheHistory = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.CleanupCacheHistory"/></em></p>
        ///   <p>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleCleanupCacheHistory(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupCacheHistory = !toolSettings.CleanupCacheHistory;
            return toolSettings;
        }
        #endregion
        #region Content
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Content"/> to a new list</em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetContent(this DocFXPdfSettings toolSettings, params string[] content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal = content.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Content"/> to a new list</em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetContent(this DocFXPdfSettings toolSettings, IEnumerable<string> content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal = content.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.Content"/></em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddContent(this DocFXPdfSettings toolSettings, params string[] content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal.AddRange(content);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.Content"/></em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddContent(this DocFXPdfSettings toolSettings, IEnumerable<string> content)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal.AddRange(content);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXPdfSettings.Content"/></em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ClearContent(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.Content"/></em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveContent(this DocFXPdfSettings toolSettings, params string[] content)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(content);
            toolSettings.ContentInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.Content"/></em></p>
        ///   <p>Specify content files for generating documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveContent(this DocFXPdfSettings toolSettings, IEnumerable<string> content)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(content);
            toolSettings.ContentInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DisableGitFeatures
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetDisableGitFeatures(this DocFXPdfSettings toolSettings, bool? disableGitFeatures)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = disableGitFeatures;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetDisableGitFeatures(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableDisableGitFeatures(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableDisableGitFeatures(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.DisableGitFeatures"/></em></p>
        ///   <p>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleDisableGitFeatures(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableGitFeatures = !toolSettings.DisableGitFeatures;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.DryRun"/></em></p>
        ///   <p>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetDryRun(this DocFXPdfSettings toolSettings, bool? dryRun)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.DryRun"/></em></p>
        ///   <p>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetDryRun(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.DryRun"/></em></p>
        ///   <p>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableDryRun(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.DryRun"/></em></p>
        ///   <p>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableDryRun(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.DryRun"/></em></p>
        ///   <p>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleDryRun(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region EnableDebugMode
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.EnableDebugMode"/></em></p>
        ///   <p>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetEnableDebugMode(this DocFXPdfSettings toolSettings, bool? enableDebugMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableDebugMode = enableDebugMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.EnableDebugMode"/></em></p>
        ///   <p>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetEnableDebugMode(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableDebugMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.EnableDebugMode"/></em></p>
        ///   <p>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableEnableDebugMode(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableDebugMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.EnableDebugMode"/></em></p>
        ///   <p>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableEnableDebugMode(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableDebugMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.EnableDebugMode"/></em></p>
        ///   <p>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleEnableDebugMode(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableDebugMode = !toolSettings.EnableDebugMode;
            return toolSettings;
        }
        #endregion
        #region ExportRawModel
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.ExportRawModel"/></em></p>
        ///   <p>If set to true, data model to run template script will be extracted in .raw.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetExportRawModel(this DocFXPdfSettings toolSettings, bool? exportRawModel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportRawModel = exportRawModel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.ExportRawModel"/></em></p>
        ///   <p>If set to true, data model to run template script will be extracted in .raw.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetExportRawModel(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportRawModel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.ExportRawModel"/></em></p>
        ///   <p>If set to true, data model to run template script will be extracted in .raw.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableExportRawModel(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportRawModel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.ExportRawModel"/></em></p>
        ///   <p>If set to true, data model to run template script will be extracted in .raw.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableExportRawModel(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportRawModel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.ExportRawModel"/></em></p>
        ///   <p>If set to true, data model to run template script will be extracted in .raw.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleExportRawModel(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportRawModel = !toolSettings.ExportRawModel;
            return toolSettings;
        }
        #endregion
        #region ExportViewModel
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.ExportViewModel"/></em></p>
        ///   <p>If set to true, data model to apply template will be extracted in .view.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetExportViewModel(this DocFXPdfSettings toolSettings, bool? exportViewModel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportViewModel = exportViewModel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.ExportViewModel"/></em></p>
        ///   <p>If set to true, data model to apply template will be extracted in .view.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetExportViewModel(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportViewModel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.ExportViewModel"/></em></p>
        ///   <p>If set to true, data model to apply template will be extracted in .view.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableExportViewModel(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportViewModel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.ExportViewModel"/></em></p>
        ///   <p>If set to true, data model to apply template will be extracted in .view.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableExportViewModel(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportViewModel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.ExportViewModel"/></em></p>
        ///   <p>If set to true, data model to apply template will be extracted in .view.model.json extension.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleExportViewModel(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportViewModel = !toolSettings.ExportViewModel;
            return toolSettings;
        }
        #endregion
        #region FALName
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.FALName"/></em></p>
        ///   <p>Set the name of input file abstract layer builder.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetFALName(this DocFXPdfSettings toolSettings, string falname)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FALName = falname;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.FALName"/></em></p>
        ///   <p>Set the name of input file abstract layer builder.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetFALName(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FALName = null;
            return toolSettings;
        }
        #endregion
        #region FileMetadataFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.FileMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetFileMetadataFilePath(this DocFXPdfSettings toolSettings, string fileMetadataFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePath = fileMetadataFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.FileMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetFileMetadataFilePath(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePath = null;
            return toolSettings;
        }
        #endregion
        #region FileMetadataFilePaths
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.FileMetadataFilePaths"/> to a new list</em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetFileMetadataFilePaths(this DocFXPdfSettings toolSettings, params string[] fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePathsInternal = fileMetadataFilePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.FileMetadataFilePaths"/> to a new list</em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetFileMetadataFilePaths(this DocFXPdfSettings toolSettings, IEnumerable<string> fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePathsInternal = fileMetadataFilePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddFileMetadataFilePaths(this DocFXPdfSettings toolSettings, params string[] fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePathsInternal.AddRange(fileMetadataFilePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddFileMetadataFilePaths(this DocFXPdfSettings toolSettings, IEnumerable<string> fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePathsInternal.AddRange(fileMetadataFilePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ClearFileMetadataFilePaths(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileMetadataFilePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveFileMetadataFilePaths(this DocFXPdfSettings toolSettings, params string[] fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fileMetadataFilePaths);
            toolSettings.FileMetadataFilePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveFileMetadataFilePaths(this DocFXPdfSettings toolSettings, IEnumerable<string> fileMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fileMetadataFilePaths);
            toolSettings.FileMetadataFilePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ForcePostProcess
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.ForcePostProcess"/></em></p>
        ///   <p>Force to re-process the documentation in post processors. It will be cascaded from force option.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetForcePostProcess(this DocFXPdfSettings toolSettings, bool? forcePostProcess)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePostProcess = forcePostProcess;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.ForcePostProcess"/></em></p>
        ///   <p>Force to re-process the documentation in post processors. It will be cascaded from force option.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetForcePostProcess(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePostProcess = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.ForcePostProcess"/></em></p>
        ///   <p>Force to re-process the documentation in post processors. It will be cascaded from force option.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableForcePostProcess(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePostProcess = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.ForcePostProcess"/></em></p>
        ///   <p>Force to re-process the documentation in post processors. It will be cascaded from force option.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableForcePostProcess(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePostProcess = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.ForcePostProcess"/></em></p>
        ///   <p>Force to re-process the documentation in post processors. It will be cascaded from force option.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleForcePostProcess(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePostProcess = !toolSettings.ForcePostProcess;
            return toolSettings;
        }
        #endregion
        #region ForceRebuild
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-build all the documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetForceRebuild(this DocFXPdfSettings toolSettings, bool? forceRebuild)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = forceRebuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-build all the documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetForceRebuild(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-build all the documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableForceRebuild(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-build all the documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableForceRebuild(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.ForceRebuild"/></em></p>
        ///   <p>Force re-build all the documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleForceRebuild(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceRebuild = !toolSettings.ForceRebuild;
            return toolSettings;
        }
        #endregion
        #region GlobalMetadata
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.GlobalMetadata"/></em></p>
        ///   <p>Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetGlobalMetadata(this DocFXPdfSettings toolSettings, string globalMetadata)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadata = globalMetadata;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.GlobalMetadata"/></em></p>
        ///   <p>Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetGlobalMetadata(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadata = null;
            return toolSettings;
        }
        #endregion
        #region GlobalMetadataFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.GlobalMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetGlobalMetadataFilePath(this DocFXPdfSettings toolSettings, string globalMetadataFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePath = globalMetadataFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.GlobalMetadataFilePath"/></em></p>
        ///   <p>Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetGlobalMetadataFilePath(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePath = null;
            return toolSettings;
        }
        #endregion
        #region GlobalMetadataFilePaths
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/> to a new list</em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetGlobalMetadataFilePaths(this DocFXPdfSettings toolSettings, params string[] globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePathsInternal = globalMetadataFilePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/> to a new list</em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetGlobalMetadataFilePaths(this DocFXPdfSettings toolSettings, IEnumerable<string> globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePathsInternal = globalMetadataFilePaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddGlobalMetadataFilePaths(this DocFXPdfSettings toolSettings, params string[] globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePathsInternal.AddRange(globalMetadataFilePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddGlobalMetadataFilePaths(this DocFXPdfSettings toolSettings, IEnumerable<string> globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePathsInternal.AddRange(globalMetadataFilePaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ClearGlobalMetadataFilePaths(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GlobalMetadataFilePathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveGlobalMetadataFilePaths(this DocFXPdfSettings toolSettings, params string[] globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(globalMetadataFilePaths);
            toolSettings.GlobalMetadataFilePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></em></p>
        ///   <p>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveGlobalMetadataFilePaths(this DocFXPdfSettings toolSettings, IEnumerable<string> globalMetadataFilePaths)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(globalMetadataFilePaths);
            toolSettings.GlobalMetadataFilePathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Host
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Host"/></em></p>
        ///   <p>Specify the hostname of the hosted website (e.g., 'localhost' or '*').</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetHost(this DocFXPdfSettings toolSettings, string host)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Host = host;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.Host"/></em></p>
        ///   <p>Specify the hostname of the hosted website (e.g., 'localhost' or '*').</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetHost(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Host = null;
            return toolSettings;
        }
        #endregion
        #region IntermediateFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.IntermediateFolder"/></em></p>
        ///   <p>Set folder for intermediate build results.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetIntermediateFolder(this DocFXPdfSettings toolSettings, string intermediateFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntermediateFolder = intermediateFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.IntermediateFolder"/></em></p>
        ///   <p>Set folder for intermediate build results.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetIntermediateFolder(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IntermediateFolder = null;
            return toolSettings;
        }
        #endregion
        #region KeepFileLink
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.KeepFileLink"/></em></p>
        ///   <p>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetKeepFileLink(this DocFXPdfSettings toolSettings, bool? keepFileLink)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFileLink = keepFileLink;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.KeepFileLink"/></em></p>
        ///   <p>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetKeepFileLink(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFileLink = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.KeepFileLink"/></em></p>
        ///   <p>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableKeepFileLink(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFileLink = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.KeepFileLink"/></em></p>
        ///   <p>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableKeepFileLink(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFileLink = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.KeepFileLink"/></em></p>
        ///   <p>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleKeepFileLink(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepFileLink = !toolSettings.KeepFileLink;
            return toolSettings;
        }
        #endregion
        #region LruSize
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.LruSize"/></em></p>
        ///   <p>Set the LRU cached model count (approximately the same as the count of input files). By default, it is 8192 for 64bit and 3072 for 32bit process. With LRU cache enabled, memory usage decreases and time consumed increases. If set to 0, Lru cache is disabled.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetLruSize(this DocFXPdfSettings toolSettings, int? lruSize)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LruSize = lruSize;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.LruSize"/></em></p>
        ///   <p>Set the LRU cached model count (approximately the same as the count of input files). By default, it is 8192 for 64bit and 3072 for 32bit process. With LRU cache enabled, memory usage decreases and time consumed increases. If set to 0, Lru cache is disabled.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetLruSize(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LruSize = null;
            return toolSettings;
        }
        #endregion
        #region MarkdownEngineName
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.MarkdownEngineName"/></em></p>
        ///   <p>Set the name of markdown engine, default is 'dfm'.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetMarkdownEngineName(this DocFXPdfSettings toolSettings, string markdownEngineName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownEngineName = markdownEngineName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.MarkdownEngineName"/></em></p>
        ///   <p>Set the name of markdown engine, default is 'dfm'.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetMarkdownEngineName(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownEngineName = null;
            return toolSettings;
        }
        #endregion
        #region MarkdownEngineProperties
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.MarkdownEngineProperties"/></em></p>
        ///   <p>Set the parameters for markdown engine, value should be a JSON string.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetMarkdownEngineProperties(this DocFXPdfSettings toolSettings, string markdownEngineProperties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownEngineProperties = markdownEngineProperties;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.MarkdownEngineProperties"/></em></p>
        ///   <p>Set the parameters for markdown engine, value should be a JSON string.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetMarkdownEngineProperties(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MarkdownEngineProperties = null;
            return toolSettings;
        }
        #endregion
        #region MaxParallelism
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.MaxParallelism"/></em></p>
        ///   <p>Set the max parallelism, 0 is auto.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetMaxParallelism(this DocFXPdfSettings toolSettings, int? maxParallelism)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxParallelism = maxParallelism;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.MaxParallelism"/></em></p>
        ///   <p>Set the max parallelism, 0 is auto.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetMaxParallelism(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxParallelism = null;
            return toolSettings;
        }
        #endregion
        #region NoLangKeyword
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.NoLangKeyword"/></em></p>
        ///   <p>Disable default lang keyword.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetNoLangKeyword(this DocFXPdfSettings toolSettings, bool? noLangKeyword)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLangKeyword = noLangKeyword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.NoLangKeyword"/></em></p>
        ///   <p>Disable default lang keyword.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetNoLangKeyword(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLangKeyword = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.NoLangKeyword"/></em></p>
        ///   <p>Disable default lang keyword.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableNoLangKeyword(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLangKeyword = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.NoLangKeyword"/></em></p>
        ///   <p>Disable default lang keyword.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableNoLangKeyword(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLangKeyword = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.NoLangKeyword"/></em></p>
        ///   <p>Disable default lang keyword.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleNoLangKeyword(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLangKeyword = !toolSettings.NoLangKeyword;
            return toolSettings;
        }
        #endregion
        #region OutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.OutputFolder"/></em></p>
        ///   <p>Specify the output base directory.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetOutputFolder(this DocFXPdfSettings toolSettings, string outputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = outputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.OutputFolder"/></em></p>
        ///   <p>Specify the output base directory.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetOutputFolder(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region OutputFolderForDebugFiles
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.OutputFolderForDebugFiles"/></em></p>
        ///   <p>The output folder for files generated for debugging purpose when in debug mode. If not specified, it is ${TempPath}/docfx.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetOutputFolderForDebugFiles(this DocFXPdfSettings toolSettings, string outputFolderForDebugFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolderForDebugFiles = outputFolderForDebugFiles;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.OutputFolderForDebugFiles"/></em></p>
        ///   <p>The output folder for files generated for debugging purpose when in debug mode. If not specified, it is ${TempPath}/docfx.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetOutputFolderForDebugFiles(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolderForDebugFiles = null;
            return toolSettings;
        }
        #endregion
        #region Overwrite
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Overwrite"/> to a new list</em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetOverwrite(this DocFXPdfSettings toolSettings, params string[] overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteInternal = overwrite.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Overwrite"/> to a new list</em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetOverwrite(this DocFXPdfSettings toolSettings, IEnumerable<string> overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteInternal = overwrite.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.Overwrite"/></em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddOverwrite(this DocFXPdfSettings toolSettings, params string[] overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteInternal.AddRange(overwrite);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.Overwrite"/></em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddOverwrite(this DocFXPdfSettings toolSettings, IEnumerable<string> overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteInternal.AddRange(overwrite);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXPdfSettings.Overwrite"/></em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ClearOverwrite(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.Overwrite"/></em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveOverwrite(this DocFXPdfSettings toolSettings, params string[] overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(overwrite);
            toolSettings.OverwriteInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.Overwrite"/></em></p>
        ///   <p>Specify overwrite files used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveOverwrite(this DocFXPdfSettings toolSettings, IEnumerable<string> overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(overwrite);
            toolSettings.OverwriteInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Port
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Port"/></em></p>
        ///   <p>Specify the port of the hosted website.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetPort(this DocFXPdfSettings toolSettings, int? port)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = port;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.Port"/></em></p>
        ///   <p>Specify the port of the hosted website.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetPort(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = null;
            return toolSettings;
        }
        #endregion
        #region PostProcessors
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.PostProcessors"/> to a new list</em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetPostProcessors(this DocFXPdfSettings toolSettings, params string[] postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostProcessorsInternal = postProcessors.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.PostProcessors"/> to a new list</em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetPostProcessors(this DocFXPdfSettings toolSettings, IEnumerable<string> postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostProcessorsInternal = postProcessors.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.PostProcessors"/></em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddPostProcessors(this DocFXPdfSettings toolSettings, params string[] postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostProcessorsInternal.AddRange(postProcessors);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.PostProcessors"/></em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddPostProcessors(this DocFXPdfSettings toolSettings, IEnumerable<string> postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostProcessorsInternal.AddRange(postProcessors);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXPdfSettings.PostProcessors"/></em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ClearPostProcessors(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostProcessorsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.PostProcessors"/></em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemovePostProcessors(this DocFXPdfSettings toolSettings, params string[] postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(postProcessors);
            toolSettings.PostProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.PostProcessors"/></em></p>
        ///   <p>Set the order of post processors in plugins.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemovePostProcessors(this DocFXPdfSettings toolSettings, IEnumerable<string> postProcessors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(postProcessors);
            toolSettings.PostProcessorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region PrintHelpMessage
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetPrintHelpMessage(this DocFXPdfSettings toolSettings, bool? printHelpMessage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = printHelpMessage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetPrintHelpMessage(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnablePrintHelpMessage(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisablePrintHelpMessage(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings TogglePrintHelpMessage(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = !toolSettings.PrintHelpMessage;
            return toolSettings;
        }
        #endregion
        #region RawModelOutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.RawModelOutputFolder"/></em></p>
        ///   <p>Specify the output folder for the raw model. If not set, the raw model will be generated to the same folder as the output documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetRawModelOutputFolder(this DocFXPdfSettings toolSettings, string rawModelOutputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawModelOutputFolder = rawModelOutputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.RawModelOutputFolder"/></em></p>
        ///   <p>Specify the output folder for the raw model. If not set, the raw model will be generated to the same folder as the output documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetRawModelOutputFolder(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawModelOutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region Resource
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Resource"/> to a new list</em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetResource(this DocFXPdfSettings toolSettings, params string[] resource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResourceInternal = resource.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Resource"/> to a new list</em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetResource(this DocFXPdfSettings toolSettings, IEnumerable<string> resource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResourceInternal = resource.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.Resource"/></em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddResource(this DocFXPdfSettings toolSettings, params string[] resource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResourceInternal.AddRange(resource);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.Resource"/></em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddResource(this DocFXPdfSettings toolSettings, IEnumerable<string> resource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResourceInternal.AddRange(resource);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXPdfSettings.Resource"/></em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ClearResource(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResourceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.Resource"/></em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveResource(this DocFXPdfSettings toolSettings, params string[] resource)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(resource);
            toolSettings.ResourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.Resource"/></em></p>
        ///   <p>Specify resources used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveResource(this DocFXPdfSettings toolSettings, IEnumerable<string> resource)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(resource);
            toolSettings.ResourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SchemaLicense
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.SchemaLicense"/></em></p>
        ///   <p>Please provide the license key for validating schema using NewtonsoftJson.Schema here.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetSchemaLicense(this DocFXPdfSettings toolSettings, string schemaLicense)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SchemaLicense = schemaLicense;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.SchemaLicense"/></em></p>
        ///   <p>Please provide the license key for validating schema using NewtonsoftJson.Schema here.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetSchemaLicense(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SchemaLicense = null;
            return toolSettings;
        }
        #endregion
        #region Serve
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Serve"/></em></p>
        ///   <p>Host the generated documentation to a website.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetServe(this DocFXPdfSettings toolSettings, bool? serve)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = serve;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.Serve"/></em></p>
        ///   <p>Host the generated documentation to a website.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetServe(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.Serve"/></em></p>
        ///   <p>Host the generated documentation to a website.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableServe(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.Serve"/></em></p>
        ///   <p>Host the generated documentation to a website.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableServe(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.Serve"/></em></p>
        ///   <p>Host the generated documentation to a website.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleServe(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = !toolSettings.Serve;
            return toolSettings;
        }
        #endregion
        #region Templates
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Templates"/> to a new list</em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetTemplates(this DocFXPdfSettings toolSettings, params string[] templates)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplatesInternal = templates.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Templates"/> to a new list</em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetTemplates(this DocFXPdfSettings toolSettings, IEnumerable<string> templates)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplatesInternal = templates.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.Templates"/></em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddTemplates(this DocFXPdfSettings toolSettings, params string[] templates)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplatesInternal.AddRange(templates);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.Templates"/></em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddTemplates(this DocFXPdfSettings toolSettings, IEnumerable<string> templates)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplatesInternal.AddRange(templates);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXPdfSettings.Templates"/></em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ClearTemplates(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplatesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.Templates"/></em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveTemplates(this DocFXPdfSettings toolSettings, params string[] templates)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(templates);
            toolSettings.TemplatesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.Templates"/></em></p>
        ///   <p>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveTemplates(this DocFXPdfSettings toolSettings, IEnumerable<string> templates)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(templates);
            toolSettings.TemplatesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Themes
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Themes"/> to a new list</em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetThemes(this DocFXPdfSettings toolSettings, params string[] themes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemesInternal = themes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.Themes"/> to a new list</em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetThemes(this DocFXPdfSettings toolSettings, IEnumerable<string> themes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemesInternal = themes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.Themes"/></em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddThemes(this DocFXPdfSettings toolSettings, params string[] themes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemesInternal.AddRange(themes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.Themes"/></em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddThemes(this DocFXPdfSettings toolSettings, IEnumerable<string> themes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemesInternal.AddRange(themes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXPdfSettings.Themes"/></em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ClearThemes(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ThemesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.Themes"/></em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveThemes(this DocFXPdfSettings toolSettings, params string[] themes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(themes);
            toolSettings.ThemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.Themes"/></em></p>
        ///   <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveThemes(this DocFXPdfSettings toolSettings, IEnumerable<string> themes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(themes);
            toolSettings.ThemesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ViewModelOutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.ViewModelOutputFolder"/></em></p>
        ///   <p>Specify the output folder for the view model. If not set, the view model will be generated to the same folder as the output documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetViewModelOutputFolder(this DocFXPdfSettings toolSettings, string viewModelOutputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ViewModelOutputFolder = viewModelOutputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.ViewModelOutputFolder"/></em></p>
        ///   <p>Specify the output folder for the view model. If not set, the view model will be generated to the same folder as the output documentation.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetViewModelOutputFolder(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ViewModelOutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region XRefMaps
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.XRefMaps"/> to a new list</em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetXRefMaps(this DocFXPdfSettings toolSettings, params string[] xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal = xrefMaps.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.XRefMaps"/> to a new list</em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetXRefMaps(this DocFXPdfSettings toolSettings, IEnumerable<string> xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal = xrefMaps.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.XRefMaps"/></em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddXRefMaps(this DocFXPdfSettings toolSettings, params string[] xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal.AddRange(xrefMaps);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DocFXPdfSettings.XRefMaps"/></em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings AddXRefMaps(this DocFXPdfSettings toolSettings, IEnumerable<string> xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal.AddRange(xrefMaps);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DocFXPdfSettings.XRefMaps"/></em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ClearXRefMaps(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.XRefMaps"/></em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveXRefMaps(this DocFXPdfSettings toolSettings, params string[] xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(xrefMaps);
            toolSettings.XRefMapsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DocFXPdfSettings.XRefMaps"/></em></p>
        ///   <p>Specify the urls of xrefmap used by content files.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings RemoveXRefMaps(this DocFXPdfSettings toolSettings, IEnumerable<string> xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(xrefMaps);
            toolSettings.XRefMapsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region CorrelationId
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.CorrelationId"/></em></p>
        ///   <p>Specify the correlation id used for logging.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetCorrelationId(this DocFXPdfSettings toolSettings, string correlationId)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CorrelationId = correlationId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.CorrelationId"/></em></p>
        ///   <p>Specify the correlation id used for logging.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetCorrelationId(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CorrelationId = null;
            return toolSettings;
        }
        #endregion
        #region LogFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.LogFilePath"/></em></p>
        ///   <p>Specify the file name to save processing log.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetLogFilePath(this DocFXPdfSettings toolSettings, string logFilePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = logFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.LogFilePath"/></em></p>
        ///   <p>Specify the file name to save processing log.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetLogFilePath(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = null;
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.LogLevel"/></em></p>
        ///   <p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetLogLevel(this DocFXPdfSettings toolSettings, DocFXLogLevel logLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.LogLevel"/></em></p>
        ///   <p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetLogLevel(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
        #region RepoRoot
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.RepoRoot"/></em></p>
        ///   <p>Specify the GIT repository root folder.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetRepoRoot(this DocFXPdfSettings toolSettings, string repoRoot)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoRoot = repoRoot;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.RepoRoot"/></em></p>
        ///   <p>Specify the GIT repository root folder.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetRepoRoot(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepoRoot = null;
            return toolSettings;
        }
        #endregion
        #region WarningsAsErrors
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXPdfSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings SetWarningsAsErrors(this DocFXPdfSettings toolSettings, bool? warningsAsErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = warningsAsErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXPdfSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ResetWarningsAsErrors(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXPdfSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings EnableWarningsAsErrors(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXPdfSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings DisableWarningsAsErrors(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXPdfSettings.WarningsAsErrors"/></em></p>
        ///   <p>Specify if warnings should be treated as errors.</p>
        /// </summary>
        [Pure]
        public static DocFXPdfSettings ToggleWarningsAsErrors(this DocFXPdfSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WarningsAsErrors = !toolSettings.WarningsAsErrors;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFXServeSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXServeSettingsExtensions
    {
        #region Folder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXServeSettings.Folder"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings SetFolder(this DocFXServeSettings toolSettings, string folder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Folder = folder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXServeSettings.Folder"/></em></p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings ResetFolder(this DocFXServeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Folder = null;
            return toolSettings;
        }
        #endregion
        #region Host
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXServeSettings.Host"/></em></p>
        ///   <p>Specify the hostname of the hosted website [localhost].</p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings SetHost(this DocFXServeSettings toolSettings, string host)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Host = host;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXServeSettings.Host"/></em></p>
        ///   <p>Specify the hostname of the hosted website [localhost].</p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings ResetHost(this DocFXServeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Host = null;
            return toolSettings;
        }
        #endregion
        #region Port
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXServeSettings.Port"/></em></p>
        ///   <p>Specify the port of the hosted website [8080].</p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings SetPort(this DocFXServeSettings toolSettings, int? port)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = port;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXServeSettings.Port"/></em></p>
        ///   <p>Specify the port of the hosted website [8080].</p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings ResetPort(this DocFXServeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = null;
            return toolSettings;
        }
        #endregion
        #region PrintHelpMessage
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXServeSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings SetPrintHelpMessage(this DocFXServeSettings toolSettings, bool? printHelpMessage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = printHelpMessage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXServeSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings ResetPrintHelpMessage(this DocFXServeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXServeSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings EnablePrintHelpMessage(this DocFXServeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXServeSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings DisablePrintHelpMessage(this DocFXServeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXServeSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXServeSettings TogglePrintHelpMessage(this DocFXServeSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = !toolSettings.PrintHelpMessage;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFXTemplateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFXTemplateSettingsExtensions
    {
        #region Command
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXTemplateSettings.Command"/></em></p>
        ///   <p>The command to execute.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings SetCommand(this DocFXTemplateSettings toolSettings, string command)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXTemplateSettings.Command"/></em></p>
        ///   <p>The command to execute.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings ResetCommand(this DocFXTemplateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = null;
            return toolSettings;
        }
        #endregion
        #region All
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXTemplateSettings.All"/></em></p>
        ///   <p>If specified, all the available templates will be exported.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings SetAll(this DocFXTemplateSettings toolSettings, bool? all)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = all;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXTemplateSettings.All"/></em></p>
        ///   <p>If specified, all the available templates will be exported.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings ResetAll(this DocFXTemplateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXTemplateSettings.All"/></em></p>
        ///   <p>If specified, all the available templates will be exported.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings EnableAll(this DocFXTemplateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXTemplateSettings.All"/></em></p>
        ///   <p>If specified, all the available templates will be exported.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings DisableAll(this DocFXTemplateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXTemplateSettings.All"/></em></p>
        ///   <p>If specified, all the available templates will be exported.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings ToggleAll(this DocFXTemplateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = !toolSettings.All;
            return toolSettings;
        }
        #endregion
        #region OutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXTemplateSettings.OutputFolder"/></em></p>
        ///   <p>Specify the output folder path for the exported templates.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings SetOutputFolder(this DocFXTemplateSettings toolSettings, string outputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = outputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXTemplateSettings.OutputFolder"/></em></p>
        ///   <p>Specify the output folder path for the exported templates.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings ResetOutputFolder(this DocFXTemplateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region PrintHelpMessage
        /// <summary>
        ///   <p><em>Sets <see cref="DocFXTemplateSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings SetPrintHelpMessage(this DocFXTemplateSettings toolSettings, bool? printHelpMessage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = printHelpMessage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DocFXTemplateSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings ResetPrintHelpMessage(this DocFXTemplateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DocFXTemplateSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings EnablePrintHelpMessage(this DocFXTemplateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DocFXTemplateSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings DisablePrintHelpMessage(this DocFXTemplateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DocFXTemplateSettings.PrintHelpMessage"/></em></p>
        ///   <p>Print help message for this sub-command.</p>
        /// </summary>
        [Pure]
        public static DocFXTemplateSettings TogglePrintHelpMessage(this DocFXTemplateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrintHelpMessage = !toolSettings.PrintHelpMessage;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFXLogLevel
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<DocFXLogLevel>))]
    public partial class DocFXLogLevel : Enumeration
    {
        public static DocFXLogLevel Diagnostic = (DocFXLogLevel) "Diagnostic";
        public static DocFXLogLevel Verbose = (DocFXLogLevel) "Verbose";
        public static DocFXLogLevel Info = (DocFXLogLevel) "Info";
        public static DocFXLogLevel Suggestion = (DocFXLogLevel) "Suggestion";
        public static DocFXLogLevel Warning = (DocFXLogLevel) "Warning";
        public static DocFXLogLevel Error = (DocFXLogLevel) "Error";
        public static explicit operator DocFXLogLevel(string value)
        {
            return new DocFXLogLevel { Value = value };
        }
    }
    #endregion
    #region DocFXTemplateCommand
    /// <summary>
    ///   Used within <see cref="DocFXTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<DocFXTemplateCommand>))]
    public partial class DocFXTemplateCommand : Enumeration
    {
        public static DocFXTemplateCommand Export = (DocFXTemplateCommand) "Export";
        public static DocFXTemplateCommand List = (DocFXTemplateCommand) "List";
        public static explicit operator DocFXTemplateCommand(string value)
        {
            return new DocFXTemplateCommand { Value = value };
        }
    }
    #endregion
}
