// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/DocFX/DocFX.json

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

namespace Nuke.Common.Tools.DocFX;

/// <summary><p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <em>github.io</em>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class DocFXTasks : ToolTasks, IRequireNuGetPackage
{
    public static string DocFXPath => new DocFXTasks().GetToolPath();
    public const string PackageId = "docfx.console";
    public const string PackageExecutable = "docfx.exe";
    /// <summary><p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <em>github.io</em>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> DocFX(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new DocFXTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Generate client-only website combining API in YAML files and conceptual files.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configFile&gt;</c> via <see cref="DocFXBuildSettings.ConfigFile"/></li><li><c>--changesFile</c> via <see cref="DocFXBuildSettings.ChangesFile"/></li><li><c>--cleanupCacheHistory</c> via <see cref="DocFXBuildSettings.CleanupCacheHistory"/></li><li><c>--content</c> via <see cref="DocFXBuildSettings.Content"/></li><li><c>--correlationId</c> via <see cref="DocFXBuildSettings.CorrelationId"/></li><li><c>--debug</c> via <see cref="DocFXBuildSettings.EnableDebugMode"/></li><li><c>--debugOutput</c> via <see cref="DocFXBuildSettings.OutputFolderForDebugFiles"/></li><li><c>--disableGitFeatures</c> via <see cref="DocFXBuildSettings.DisableGitFeatures"/></li><li><c>--dryRun</c> via <see cref="DocFXBuildSettings.DryRun"/></li><li><c>--exportRawModel</c> via <see cref="DocFXBuildSettings.ExportRawModel"/></li><li><c>--exportViewModel</c> via <see cref="DocFXBuildSettings.ExportViewModel"/></li><li><c>--falName</c> via <see cref="DocFXBuildSettings.FALName"/></li><li><c>--fileMetadataFile</c> via <see cref="DocFXBuildSettings.FileMetadataFilePath"/></li><li><c>--fileMetadataFiles</c> via <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></li><li><c>--force</c> via <see cref="DocFXBuildSettings.ForceRebuild"/></li><li><c>--forcePostProcess</c> via <see cref="DocFXBuildSettings.ForcePostProcess"/></li><li><c>--globalMetadata</c> via <see cref="DocFXBuildSettings.GlobalMetadata"/></li><li><c>--globalMetadataFile</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePath"/></li><li><c>--globalMetadataFiles</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></li><li><c>--help</c> via <see cref="DocFXBuildSettings.PrintHelpMessage"/></li><li><c>--hostname</c> via <see cref="DocFXBuildSettings.Host"/></li><li><c>--intermediateFolder</c> via <see cref="DocFXBuildSettings.IntermediateFolder"/></li><li><c>--keepFileLink</c> via <see cref="DocFXBuildSettings.KeepFileLink"/></li><li><c>--log</c> via <see cref="DocFXBuildSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXBuildSettings.LogLevel"/></li><li><c>--lruSize</c> via <see cref="DocFXBuildSettings.LruSize"/></li><li><c>--markdownEngineName</c> via <see cref="DocFXBuildSettings.MarkdownEngineName"/></li><li><c>--markdownEngineProperties</c> via <see cref="DocFXBuildSettings.MarkdownEngineProperties"/></li><li><c>--maxParallelism</c> via <see cref="DocFXBuildSettings.MaxParallelism"/></li><li><c>--noLangKeyword</c> via <see cref="DocFXBuildSettings.NoLangKeyword"/></li><li><c>--output</c> via <see cref="DocFXBuildSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="DocFXBuildSettings.Overwrite"/></li><li><c>--port</c> via <see cref="DocFXBuildSettings.Port"/></li><li><c>--postProcessors</c> via <see cref="DocFXBuildSettings.PostProcessors"/></li><li><c>--rawModelOutputFolder</c> via <see cref="DocFXBuildSettings.RawModelOutputFolder"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXBuildSettings.RepoRoot"/></li><li><c>--resource</c> via <see cref="DocFXBuildSettings.Resource"/></li><li><c>--schemaLicense</c> via <see cref="DocFXBuildSettings.SchemaLicense"/></li><li><c>--serve</c> via <see cref="DocFXBuildSettings.Serve"/></li><li><c>--template</c> via <see cref="DocFXBuildSettings.Templates"/></li><li><c>--theme</c> via <see cref="DocFXBuildSettings.Themes"/></li><li><c>--viewModelOutputFolder</c> via <see cref="DocFXBuildSettings.ViewModelOutputFolder"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXBuildSettings.WarningsAsErrors"/></li><li><c>--xref</c> via <see cref="DocFXBuildSettings.XRefMaps"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXBuild(DocFXBuildSettings options = null) => new DocFXTasks().Run(options);
    /// <summary><p>Generate client-only website combining API in YAML files and conceptual files.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configFile&gt;</c> via <see cref="DocFXBuildSettings.ConfigFile"/></li><li><c>--changesFile</c> via <see cref="DocFXBuildSettings.ChangesFile"/></li><li><c>--cleanupCacheHistory</c> via <see cref="DocFXBuildSettings.CleanupCacheHistory"/></li><li><c>--content</c> via <see cref="DocFXBuildSettings.Content"/></li><li><c>--correlationId</c> via <see cref="DocFXBuildSettings.CorrelationId"/></li><li><c>--debug</c> via <see cref="DocFXBuildSettings.EnableDebugMode"/></li><li><c>--debugOutput</c> via <see cref="DocFXBuildSettings.OutputFolderForDebugFiles"/></li><li><c>--disableGitFeatures</c> via <see cref="DocFXBuildSettings.DisableGitFeatures"/></li><li><c>--dryRun</c> via <see cref="DocFXBuildSettings.DryRun"/></li><li><c>--exportRawModel</c> via <see cref="DocFXBuildSettings.ExportRawModel"/></li><li><c>--exportViewModel</c> via <see cref="DocFXBuildSettings.ExportViewModel"/></li><li><c>--falName</c> via <see cref="DocFXBuildSettings.FALName"/></li><li><c>--fileMetadataFile</c> via <see cref="DocFXBuildSettings.FileMetadataFilePath"/></li><li><c>--fileMetadataFiles</c> via <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></li><li><c>--force</c> via <see cref="DocFXBuildSettings.ForceRebuild"/></li><li><c>--forcePostProcess</c> via <see cref="DocFXBuildSettings.ForcePostProcess"/></li><li><c>--globalMetadata</c> via <see cref="DocFXBuildSettings.GlobalMetadata"/></li><li><c>--globalMetadataFile</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePath"/></li><li><c>--globalMetadataFiles</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></li><li><c>--help</c> via <see cref="DocFXBuildSettings.PrintHelpMessage"/></li><li><c>--hostname</c> via <see cref="DocFXBuildSettings.Host"/></li><li><c>--intermediateFolder</c> via <see cref="DocFXBuildSettings.IntermediateFolder"/></li><li><c>--keepFileLink</c> via <see cref="DocFXBuildSettings.KeepFileLink"/></li><li><c>--log</c> via <see cref="DocFXBuildSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXBuildSettings.LogLevel"/></li><li><c>--lruSize</c> via <see cref="DocFXBuildSettings.LruSize"/></li><li><c>--markdownEngineName</c> via <see cref="DocFXBuildSettings.MarkdownEngineName"/></li><li><c>--markdownEngineProperties</c> via <see cref="DocFXBuildSettings.MarkdownEngineProperties"/></li><li><c>--maxParallelism</c> via <see cref="DocFXBuildSettings.MaxParallelism"/></li><li><c>--noLangKeyword</c> via <see cref="DocFXBuildSettings.NoLangKeyword"/></li><li><c>--output</c> via <see cref="DocFXBuildSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="DocFXBuildSettings.Overwrite"/></li><li><c>--port</c> via <see cref="DocFXBuildSettings.Port"/></li><li><c>--postProcessors</c> via <see cref="DocFXBuildSettings.PostProcessors"/></li><li><c>--rawModelOutputFolder</c> via <see cref="DocFXBuildSettings.RawModelOutputFolder"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXBuildSettings.RepoRoot"/></li><li><c>--resource</c> via <see cref="DocFXBuildSettings.Resource"/></li><li><c>--schemaLicense</c> via <see cref="DocFXBuildSettings.SchemaLicense"/></li><li><c>--serve</c> via <see cref="DocFXBuildSettings.Serve"/></li><li><c>--template</c> via <see cref="DocFXBuildSettings.Templates"/></li><li><c>--theme</c> via <see cref="DocFXBuildSettings.Themes"/></li><li><c>--viewModelOutputFolder</c> via <see cref="DocFXBuildSettings.ViewModelOutputFolder"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXBuildSettings.WarningsAsErrors"/></li><li><c>--xref</c> via <see cref="DocFXBuildSettings.XRefMaps"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXBuild(Configure<DocFXBuildSettings> configurator) => new DocFXTasks().Run(configurator.Invoke(new DocFXBuildSettings()));
    /// <summary><p>Generate client-only website combining API in YAML files and conceptual files.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configFile&gt;</c> via <see cref="DocFXBuildSettings.ConfigFile"/></li><li><c>--changesFile</c> via <see cref="DocFXBuildSettings.ChangesFile"/></li><li><c>--cleanupCacheHistory</c> via <see cref="DocFXBuildSettings.CleanupCacheHistory"/></li><li><c>--content</c> via <see cref="DocFXBuildSettings.Content"/></li><li><c>--correlationId</c> via <see cref="DocFXBuildSettings.CorrelationId"/></li><li><c>--debug</c> via <see cref="DocFXBuildSettings.EnableDebugMode"/></li><li><c>--debugOutput</c> via <see cref="DocFXBuildSettings.OutputFolderForDebugFiles"/></li><li><c>--disableGitFeatures</c> via <see cref="DocFXBuildSettings.DisableGitFeatures"/></li><li><c>--dryRun</c> via <see cref="DocFXBuildSettings.DryRun"/></li><li><c>--exportRawModel</c> via <see cref="DocFXBuildSettings.ExportRawModel"/></li><li><c>--exportViewModel</c> via <see cref="DocFXBuildSettings.ExportViewModel"/></li><li><c>--falName</c> via <see cref="DocFXBuildSettings.FALName"/></li><li><c>--fileMetadataFile</c> via <see cref="DocFXBuildSettings.FileMetadataFilePath"/></li><li><c>--fileMetadataFiles</c> via <see cref="DocFXBuildSettings.FileMetadataFilePaths"/></li><li><c>--force</c> via <see cref="DocFXBuildSettings.ForceRebuild"/></li><li><c>--forcePostProcess</c> via <see cref="DocFXBuildSettings.ForcePostProcess"/></li><li><c>--globalMetadata</c> via <see cref="DocFXBuildSettings.GlobalMetadata"/></li><li><c>--globalMetadataFile</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePath"/></li><li><c>--globalMetadataFiles</c> via <see cref="DocFXBuildSettings.GlobalMetadataFilePaths"/></li><li><c>--help</c> via <see cref="DocFXBuildSettings.PrintHelpMessage"/></li><li><c>--hostname</c> via <see cref="DocFXBuildSettings.Host"/></li><li><c>--intermediateFolder</c> via <see cref="DocFXBuildSettings.IntermediateFolder"/></li><li><c>--keepFileLink</c> via <see cref="DocFXBuildSettings.KeepFileLink"/></li><li><c>--log</c> via <see cref="DocFXBuildSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXBuildSettings.LogLevel"/></li><li><c>--lruSize</c> via <see cref="DocFXBuildSettings.LruSize"/></li><li><c>--markdownEngineName</c> via <see cref="DocFXBuildSettings.MarkdownEngineName"/></li><li><c>--markdownEngineProperties</c> via <see cref="DocFXBuildSettings.MarkdownEngineProperties"/></li><li><c>--maxParallelism</c> via <see cref="DocFXBuildSettings.MaxParallelism"/></li><li><c>--noLangKeyword</c> via <see cref="DocFXBuildSettings.NoLangKeyword"/></li><li><c>--output</c> via <see cref="DocFXBuildSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="DocFXBuildSettings.Overwrite"/></li><li><c>--port</c> via <see cref="DocFXBuildSettings.Port"/></li><li><c>--postProcessors</c> via <see cref="DocFXBuildSettings.PostProcessors"/></li><li><c>--rawModelOutputFolder</c> via <see cref="DocFXBuildSettings.RawModelOutputFolder"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXBuildSettings.RepoRoot"/></li><li><c>--resource</c> via <see cref="DocFXBuildSettings.Resource"/></li><li><c>--schemaLicense</c> via <see cref="DocFXBuildSettings.SchemaLicense"/></li><li><c>--serve</c> via <see cref="DocFXBuildSettings.Serve"/></li><li><c>--template</c> via <see cref="DocFXBuildSettings.Templates"/></li><li><c>--theme</c> via <see cref="DocFXBuildSettings.Themes"/></li><li><c>--viewModelOutputFolder</c> via <see cref="DocFXBuildSettings.ViewModelOutputFolder"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXBuildSettings.WarningsAsErrors"/></li><li><c>--xref</c> via <see cref="DocFXBuildSettings.XRefMaps"/></li></ul></remarks>
    public static IEnumerable<(DocFXBuildSettings Settings, IReadOnlyCollection<Output> Output)> DocFXBuild(CombinatorialConfigure<DocFXBuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DocFXBuild, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Export dependency file.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;dependencyFile&gt;</c> via <see cref="DocFXDependencySettings.DependencyFile"/></li><li><c>--help</c> via <see cref="DocFXDependencySettings.PrintHelpMessage"/></li><li><c>--intermediateFolder</c> via <see cref="DocFXDependencySettings.IntermediateFolder"/></li><li><c>--version</c> via <see cref="DocFXDependencySettings.VersionName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXDependency(DocFXDependencySettings options = null) => new DocFXTasks().Run(options);
    /// <summary><p>Export dependency file.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;dependencyFile&gt;</c> via <see cref="DocFXDependencySettings.DependencyFile"/></li><li><c>--help</c> via <see cref="DocFXDependencySettings.PrintHelpMessage"/></li><li><c>--intermediateFolder</c> via <see cref="DocFXDependencySettings.IntermediateFolder"/></li><li><c>--version</c> via <see cref="DocFXDependencySettings.VersionName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXDependency(Configure<DocFXDependencySettings> configurator) => new DocFXTasks().Run(configurator.Invoke(new DocFXDependencySettings()));
    /// <summary><p>Export dependency file.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;dependencyFile&gt;</c> via <see cref="DocFXDependencySettings.DependencyFile"/></li><li><c>--help</c> via <see cref="DocFXDependencySettings.PrintHelpMessage"/></li><li><c>--intermediateFolder</c> via <see cref="DocFXDependencySettings.IntermediateFolder"/></li><li><c>--version</c> via <see cref="DocFXDependencySettings.VersionName"/></li></ul></remarks>
    public static IEnumerable<(DocFXDependencySettings Settings, IReadOnlyCollection<Output> Output)> DocFXDependency(CombinatorialConfigure<DocFXDependencySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DocFXDependency, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Download remote xref map file and create an xref archive in local.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;archiveFile&gt;</c> via <see cref="DocFXDownloadSettings.ArchiveFile"/></li><li><c>--help</c> via <see cref="DocFXDownloadSettings.PrintHelpMessage"/></li><li><c>--xref</c> via <see cref="DocFXDownloadSettings.Uri"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXDownload(DocFXDownloadSettings options = null) => new DocFXTasks().Run(options);
    /// <summary><p>Download remote xref map file and create an xref archive in local.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;archiveFile&gt;</c> via <see cref="DocFXDownloadSettings.ArchiveFile"/></li><li><c>--help</c> via <see cref="DocFXDownloadSettings.PrintHelpMessage"/></li><li><c>--xref</c> via <see cref="DocFXDownloadSettings.Uri"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXDownload(Configure<DocFXDownloadSettings> configurator) => new DocFXTasks().Run(configurator.Invoke(new DocFXDownloadSettings()));
    /// <summary><p>Download remote xref map file and create an xref archive in local.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;archiveFile&gt;</c> via <see cref="DocFXDownloadSettings.ArchiveFile"/></li><li><c>--help</c> via <see cref="DocFXDownloadSettings.PrintHelpMessage"/></li><li><c>--xref</c> via <see cref="DocFXDownloadSettings.Uri"/></li></ul></remarks>
    public static IEnumerable<(DocFXDownloadSettings Settings, IReadOnlyCollection<Output> Output)> DocFXDownload(CombinatorialConfigure<DocFXDownloadSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DocFXDownload, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Get an overall guide for the command and sub-commands.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;command&gt;</c> via <see cref="DocFXHelpSettings.Command"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXHelp(DocFXHelpSettings options = null) => new DocFXTasks().Run(options);
    /// <summary><p>Get an overall guide for the command and sub-commands.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;command&gt;</c> via <see cref="DocFXHelpSettings.Command"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXHelp(Configure<DocFXHelpSettings> configurator) => new DocFXTasks().Run(configurator.Invoke(new DocFXHelpSettings()));
    /// <summary><p>Get an overall guide for the command and sub-commands.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;command&gt;</c> via <see cref="DocFXHelpSettings.Command"/></li></ul></remarks>
    public static IEnumerable<(DocFXHelpSettings Settings, IReadOnlyCollection<Output> Output)> DocFXHelp(CombinatorialConfigure<DocFXHelpSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DocFXHelp, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Generate an initial docfx.json following the instructions.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiGlobPattern</c> via <see cref="DocFXInitSettings.ApiSourceGlobPattern"/></li><li><c>--apiSourceFolder</c> via <see cref="DocFXInitSettings.ApiSourceFolder"/></li><li><c>--file</c> via <see cref="DocFXInitSettings.OnlyConfigFile"/></li><li><c>--help</c> via <see cref="DocFXInitSettings.PrintHelpMessage"/></li><li><c>--output</c> via <see cref="DocFXInitSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="DocFXInitSettings.Overwrite"/></li><li><c>--quiet</c> via <see cref="DocFXInitSettings.Quiet"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXInit(DocFXInitSettings options = null) => new DocFXTasks().Run(options);
    /// <summary><p>Generate an initial docfx.json following the instructions.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiGlobPattern</c> via <see cref="DocFXInitSettings.ApiSourceGlobPattern"/></li><li><c>--apiSourceFolder</c> via <see cref="DocFXInitSettings.ApiSourceFolder"/></li><li><c>--file</c> via <see cref="DocFXInitSettings.OnlyConfigFile"/></li><li><c>--help</c> via <see cref="DocFXInitSettings.PrintHelpMessage"/></li><li><c>--output</c> via <see cref="DocFXInitSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="DocFXInitSettings.Overwrite"/></li><li><c>--quiet</c> via <see cref="DocFXInitSettings.Quiet"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXInit(Configure<DocFXInitSettings> configurator) => new DocFXTasks().Run(configurator.Invoke(new DocFXInitSettings()));
    /// <summary><p>Generate an initial docfx.json following the instructions.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiGlobPattern</c> via <see cref="DocFXInitSettings.ApiSourceGlobPattern"/></li><li><c>--apiSourceFolder</c> via <see cref="DocFXInitSettings.ApiSourceFolder"/></li><li><c>--file</c> via <see cref="DocFXInitSettings.OnlyConfigFile"/></li><li><c>--help</c> via <see cref="DocFXInitSettings.PrintHelpMessage"/></li><li><c>--output</c> via <see cref="DocFXInitSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="DocFXInitSettings.Overwrite"/></li><li><c>--quiet</c> via <see cref="DocFXInitSettings.Quiet"/></li></ul></remarks>
    public static IEnumerable<(DocFXInitSettings Settings, IReadOnlyCollection<Output> Output)> DocFXInit(CombinatorialConfigure<DocFXInitSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DocFXInit, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Merge .net base API in YAML files and toc files.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configFile&gt;</c> via <see cref="DocFXMergeSettings.ConfigFile"/></li><li><c>--content</c> via <see cref="DocFXMergeSettings.Content"/></li><li><c>--correlationId</c> via <see cref="DocFXMergeSettings.CorrelationId"/></li><li><c>--fileMetadataFile</c> via <see cref="DocFXMergeSettings.FileMetadataFilePath"/></li><li><c>--globalMetadata</c> via <see cref="DocFXMergeSettings.GlobalMetadata"/></li><li><c>--globalMetadataFile</c> via <see cref="DocFXMergeSettings.GlobalMetadataFilePath"/></li><li><c>--help</c> via <see cref="DocFXMergeSettings.PrintHelpMessage"/></li><li><c>--log</c> via <see cref="DocFXMergeSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXMergeSettings.LogLevel"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXMergeSettings.RepoRoot"/></li><li><c>--tocMetadata</c> via <see cref="DocFXMergeSettings.TocMetadata"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXMergeSettings.WarningsAsErrors"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXMerge(DocFXMergeSettings options = null) => new DocFXTasks().Run(options);
    /// <summary><p>Merge .net base API in YAML files and toc files.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configFile&gt;</c> via <see cref="DocFXMergeSettings.ConfigFile"/></li><li><c>--content</c> via <see cref="DocFXMergeSettings.Content"/></li><li><c>--correlationId</c> via <see cref="DocFXMergeSettings.CorrelationId"/></li><li><c>--fileMetadataFile</c> via <see cref="DocFXMergeSettings.FileMetadataFilePath"/></li><li><c>--globalMetadata</c> via <see cref="DocFXMergeSettings.GlobalMetadata"/></li><li><c>--globalMetadataFile</c> via <see cref="DocFXMergeSettings.GlobalMetadataFilePath"/></li><li><c>--help</c> via <see cref="DocFXMergeSettings.PrintHelpMessage"/></li><li><c>--log</c> via <see cref="DocFXMergeSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXMergeSettings.LogLevel"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXMergeSettings.RepoRoot"/></li><li><c>--tocMetadata</c> via <see cref="DocFXMergeSettings.TocMetadata"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXMergeSettings.WarningsAsErrors"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXMerge(Configure<DocFXMergeSettings> configurator) => new DocFXTasks().Run(configurator.Invoke(new DocFXMergeSettings()));
    /// <summary><p>Merge .net base API in YAML files and toc files.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configFile&gt;</c> via <see cref="DocFXMergeSettings.ConfigFile"/></li><li><c>--content</c> via <see cref="DocFXMergeSettings.Content"/></li><li><c>--correlationId</c> via <see cref="DocFXMergeSettings.CorrelationId"/></li><li><c>--fileMetadataFile</c> via <see cref="DocFXMergeSettings.FileMetadataFilePath"/></li><li><c>--globalMetadata</c> via <see cref="DocFXMergeSettings.GlobalMetadata"/></li><li><c>--globalMetadataFile</c> via <see cref="DocFXMergeSettings.GlobalMetadataFilePath"/></li><li><c>--help</c> via <see cref="DocFXMergeSettings.PrintHelpMessage"/></li><li><c>--log</c> via <see cref="DocFXMergeSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXMergeSettings.LogLevel"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXMergeSettings.RepoRoot"/></li><li><c>--tocMetadata</c> via <see cref="DocFXMergeSettings.TocMetadata"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXMergeSettings.WarningsAsErrors"/></li></ul></remarks>
    public static IEnumerable<(DocFXMergeSettings Settings, IReadOnlyCollection<Output> Output)> DocFXMerge(CombinatorialConfigure<DocFXMergeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DocFXMerge, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Generate YAML files from source code.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;projects&gt;</c> via <see cref="DocFXMetadataSettings.Projects"/></li><li><c>--correlationId</c> via <see cref="DocFXMetadataSettings.CorrelationId"/></li><li><c>--disableDefaultFilter</c> via <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></li><li><c>--disableGitFeatures</c> via <see cref="DocFXMetadataSettings.DisableGitFeatures"/></li><li><c>--filter</c> via <see cref="DocFXMetadataSettings.FilterConfigFile"/></li><li><c>--force</c> via <see cref="DocFXMetadataSettings.ForceRebuild"/></li><li><c>--globalNamespaceId</c> via <see cref="DocFXMetadataSettings.GlobalNamespaceId"/></li><li><c>--help</c> via <see cref="DocFXMetadataSettings.PrintHelpMessage"/></li><li><c>--log</c> via <see cref="DocFXMetadataSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXMetadataSettings.LogLevel"/></li><li><c>--output</c> via <see cref="DocFXMetadataSettings.OutputFolder"/></li><li><c>--property</c> via <see cref="DocFXMetadataSettings.MSBuildProperties"/></li><li><c>--raw</c> via <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXMetadataSettings.RepoRoot"/></li><li><c>--shouldSkipMarkup</c> via <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXMetadataSettings.WarningsAsErrors"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXMetadata(DocFXMetadataSettings options = null) => new DocFXTasks().Run(options);
    /// <summary><p>Generate YAML files from source code.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;projects&gt;</c> via <see cref="DocFXMetadataSettings.Projects"/></li><li><c>--correlationId</c> via <see cref="DocFXMetadataSettings.CorrelationId"/></li><li><c>--disableDefaultFilter</c> via <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></li><li><c>--disableGitFeatures</c> via <see cref="DocFXMetadataSettings.DisableGitFeatures"/></li><li><c>--filter</c> via <see cref="DocFXMetadataSettings.FilterConfigFile"/></li><li><c>--force</c> via <see cref="DocFXMetadataSettings.ForceRebuild"/></li><li><c>--globalNamespaceId</c> via <see cref="DocFXMetadataSettings.GlobalNamespaceId"/></li><li><c>--help</c> via <see cref="DocFXMetadataSettings.PrintHelpMessage"/></li><li><c>--log</c> via <see cref="DocFXMetadataSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXMetadataSettings.LogLevel"/></li><li><c>--output</c> via <see cref="DocFXMetadataSettings.OutputFolder"/></li><li><c>--property</c> via <see cref="DocFXMetadataSettings.MSBuildProperties"/></li><li><c>--raw</c> via <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXMetadataSettings.RepoRoot"/></li><li><c>--shouldSkipMarkup</c> via <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXMetadataSettings.WarningsAsErrors"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXMetadata(Configure<DocFXMetadataSettings> configurator) => new DocFXTasks().Run(configurator.Invoke(new DocFXMetadataSettings()));
    /// <summary><p>Generate YAML files from source code.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;projects&gt;</c> via <see cref="DocFXMetadataSettings.Projects"/></li><li><c>--correlationId</c> via <see cref="DocFXMetadataSettings.CorrelationId"/></li><li><c>--disableDefaultFilter</c> via <see cref="DocFXMetadataSettings.DisableDefaultFilter"/></li><li><c>--disableGitFeatures</c> via <see cref="DocFXMetadataSettings.DisableGitFeatures"/></li><li><c>--filter</c> via <see cref="DocFXMetadataSettings.FilterConfigFile"/></li><li><c>--force</c> via <see cref="DocFXMetadataSettings.ForceRebuild"/></li><li><c>--globalNamespaceId</c> via <see cref="DocFXMetadataSettings.GlobalNamespaceId"/></li><li><c>--help</c> via <see cref="DocFXMetadataSettings.PrintHelpMessage"/></li><li><c>--log</c> via <see cref="DocFXMetadataSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXMetadataSettings.LogLevel"/></li><li><c>--output</c> via <see cref="DocFXMetadataSettings.OutputFolder"/></li><li><c>--property</c> via <see cref="DocFXMetadataSettings.MSBuildProperties"/></li><li><c>--raw</c> via <see cref="DocFXMetadataSettings.PreserveRawInlineComments"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXMetadataSettings.RepoRoot"/></li><li><c>--shouldSkipMarkup</c> via <see cref="DocFXMetadataSettings.ShouldSkipMarkup"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXMetadataSettings.WarningsAsErrors"/></li></ul></remarks>
    public static IEnumerable<(DocFXMetadataSettings Settings, IReadOnlyCollection<Output> Output)> DocFXMetadata(CombinatorialConfigure<DocFXMetadataSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DocFXMetadata, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Generate pdf file.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configFile&gt;</c> via <see cref="DocFXPdfSettings.ConfigFile"/></li><li><c>--basePath</c> via <see cref="DocFXPdfSettings.BasePath"/></li><li><c>--changesFile</c> via <see cref="DocFXPdfSettings.ChangesFile"/></li><li><c>--cleanupCacheHistory</c> via <see cref="DocFXPdfSettings.CleanupCacheHistory"/></li><li><c>--content</c> via <see cref="DocFXPdfSettings.Content"/></li><li><c>--correlationId</c> via <see cref="DocFXPdfSettings.CorrelationId"/></li><li><c>--css</c> via <see cref="DocFXPdfSettings.CssFilePath"/></li><li><c>--debug</c> via <see cref="DocFXPdfSettings.EnableDebugMode"/></li><li><c>--debugOutput</c> via <see cref="DocFXPdfSettings.OutputFolderForDebugFiles"/></li><li><c>--disableGitFeatures</c> via <see cref="DocFXPdfSettings.DisableGitFeatures"/></li><li><c>--dryRun</c> via <see cref="DocFXPdfSettings.DryRun"/></li><li><c>--errorHandling</c> via <see cref="DocFXPdfSettings.LoadErrorHandling"/></li><li><c>--excludedTocs</c> via <see cref="DocFXPdfSettings.ExcludedTocs"/></li><li><c>--exportRawModel</c> via <see cref="DocFXPdfSettings.ExportRawModel"/></li><li><c>--exportViewModel</c> via <see cref="DocFXPdfSettings.ExportViewModel"/></li><li><c>--falName</c> via <see cref="DocFXPdfSettings.FALName"/></li><li><c>--fileMetadataFile</c> via <see cref="DocFXPdfSettings.FileMetadataFilePath"/></li><li><c>--fileMetadataFiles</c> via <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></li><li><c>--force</c> via <see cref="DocFXPdfSettings.ForceRebuild"/></li><li><c>--forcePostProcess</c> via <see cref="DocFXPdfSettings.ForcePostProcess"/></li><li><c>--generatesAppendices</c> via <see cref="DocFXPdfSettings.GeneratesAppendices"/></li><li><c>--generatesExternalLink</c> via <see cref="DocFXPdfSettings.GeneratesExternalLink"/></li><li><c>--globalMetadata</c> via <see cref="DocFXPdfSettings.GlobalMetadata"/></li><li><c>--globalMetadataFile</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePath"/></li><li><c>--globalMetadataFiles</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></li><li><c>--help</c> via <see cref="DocFXPdfSettings.PrintHelpMessage"/></li><li><c>--host</c> via <see cref="DocFXPdfSettings.PdfHost"/></li><li><c>--hostname</c> via <see cref="DocFXPdfSettings.Host"/></li><li><c>--intermediateFolder</c> via <see cref="DocFXPdfSettings.IntermediateFolder"/></li><li><c>--keepFileLink</c> via <see cref="DocFXPdfSettings.KeepFileLink"/></li><li><c>--keepRawFiles</c> via <see cref="DocFXPdfSettings.KeepRawFiles"/></li><li><c>--locale</c> via <see cref="DocFXPdfSettings.Locale"/></li><li><c>--log</c> via <see cref="DocFXPdfSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXPdfSettings.LogLevel"/></li><li><c>--lruSize</c> via <see cref="DocFXPdfSettings.LruSize"/></li><li><c>--markdownEngineName</c> via <see cref="DocFXPdfSettings.MarkdownEngineName"/></li><li><c>--markdownEngineProperties</c> via <see cref="DocFXPdfSettings.MarkdownEngineProperties"/></li><li><c>--maxParallelism</c> via <see cref="DocFXPdfSettings.MaxParallelism"/></li><li><c>--name</c> via <see cref="DocFXPdfSettings.Name"/></li><li><c>--noLangKeyword</c> via <see cref="DocFXPdfSettings.NoLangKeyword"/></li><li><c>--noStdin</c> via <see cref="DocFXPdfSettings.NoInputStreamArgs"/></li><li><c>--output</c> via <see cref="DocFXPdfSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="DocFXPdfSettings.Overwrite"/></li><li><c>--port</c> via <see cref="DocFXPdfSettings.Port"/></li><li><c>--postProcessors</c> via <see cref="DocFXPdfSettings.PostProcessors"/></li><li><c>--rawModelOutputFolder</c> via <see cref="DocFXPdfSettings.RawModelOutputFolder"/></li><li><c>--rawOutputFolder</c> via <see cref="DocFXPdfSettings.RawOutputFolder"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXPdfSettings.RepoRoot"/></li><li><c>--resource</c> via <see cref="DocFXPdfSettings.Resource"/></li><li><c>--schemaLicense</c> via <see cref="DocFXPdfSettings.SchemaLicense"/></li><li><c>--serve</c> via <see cref="DocFXPdfSettings.Serve"/></li><li><c>--template</c> via <see cref="DocFXPdfSettings.Templates"/></li><li><c>--theme</c> via <see cref="DocFXPdfSettings.Themes"/></li><li><c>--viewModelOutputFolder</c> via <see cref="DocFXPdfSettings.ViewModelOutputFolder"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXPdfSettings.WarningsAsErrors"/></li><li><c>--xref</c> via <see cref="DocFXPdfSettings.XRefMaps"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXPdf(DocFXPdfSettings options = null) => new DocFXTasks().Run(options);
    /// <summary><p>Generate pdf file.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configFile&gt;</c> via <see cref="DocFXPdfSettings.ConfigFile"/></li><li><c>--basePath</c> via <see cref="DocFXPdfSettings.BasePath"/></li><li><c>--changesFile</c> via <see cref="DocFXPdfSettings.ChangesFile"/></li><li><c>--cleanupCacheHistory</c> via <see cref="DocFXPdfSettings.CleanupCacheHistory"/></li><li><c>--content</c> via <see cref="DocFXPdfSettings.Content"/></li><li><c>--correlationId</c> via <see cref="DocFXPdfSettings.CorrelationId"/></li><li><c>--css</c> via <see cref="DocFXPdfSettings.CssFilePath"/></li><li><c>--debug</c> via <see cref="DocFXPdfSettings.EnableDebugMode"/></li><li><c>--debugOutput</c> via <see cref="DocFXPdfSettings.OutputFolderForDebugFiles"/></li><li><c>--disableGitFeatures</c> via <see cref="DocFXPdfSettings.DisableGitFeatures"/></li><li><c>--dryRun</c> via <see cref="DocFXPdfSettings.DryRun"/></li><li><c>--errorHandling</c> via <see cref="DocFXPdfSettings.LoadErrorHandling"/></li><li><c>--excludedTocs</c> via <see cref="DocFXPdfSettings.ExcludedTocs"/></li><li><c>--exportRawModel</c> via <see cref="DocFXPdfSettings.ExportRawModel"/></li><li><c>--exportViewModel</c> via <see cref="DocFXPdfSettings.ExportViewModel"/></li><li><c>--falName</c> via <see cref="DocFXPdfSettings.FALName"/></li><li><c>--fileMetadataFile</c> via <see cref="DocFXPdfSettings.FileMetadataFilePath"/></li><li><c>--fileMetadataFiles</c> via <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></li><li><c>--force</c> via <see cref="DocFXPdfSettings.ForceRebuild"/></li><li><c>--forcePostProcess</c> via <see cref="DocFXPdfSettings.ForcePostProcess"/></li><li><c>--generatesAppendices</c> via <see cref="DocFXPdfSettings.GeneratesAppendices"/></li><li><c>--generatesExternalLink</c> via <see cref="DocFXPdfSettings.GeneratesExternalLink"/></li><li><c>--globalMetadata</c> via <see cref="DocFXPdfSettings.GlobalMetadata"/></li><li><c>--globalMetadataFile</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePath"/></li><li><c>--globalMetadataFiles</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></li><li><c>--help</c> via <see cref="DocFXPdfSettings.PrintHelpMessage"/></li><li><c>--host</c> via <see cref="DocFXPdfSettings.PdfHost"/></li><li><c>--hostname</c> via <see cref="DocFXPdfSettings.Host"/></li><li><c>--intermediateFolder</c> via <see cref="DocFXPdfSettings.IntermediateFolder"/></li><li><c>--keepFileLink</c> via <see cref="DocFXPdfSettings.KeepFileLink"/></li><li><c>--keepRawFiles</c> via <see cref="DocFXPdfSettings.KeepRawFiles"/></li><li><c>--locale</c> via <see cref="DocFXPdfSettings.Locale"/></li><li><c>--log</c> via <see cref="DocFXPdfSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXPdfSettings.LogLevel"/></li><li><c>--lruSize</c> via <see cref="DocFXPdfSettings.LruSize"/></li><li><c>--markdownEngineName</c> via <see cref="DocFXPdfSettings.MarkdownEngineName"/></li><li><c>--markdownEngineProperties</c> via <see cref="DocFXPdfSettings.MarkdownEngineProperties"/></li><li><c>--maxParallelism</c> via <see cref="DocFXPdfSettings.MaxParallelism"/></li><li><c>--name</c> via <see cref="DocFXPdfSettings.Name"/></li><li><c>--noLangKeyword</c> via <see cref="DocFXPdfSettings.NoLangKeyword"/></li><li><c>--noStdin</c> via <see cref="DocFXPdfSettings.NoInputStreamArgs"/></li><li><c>--output</c> via <see cref="DocFXPdfSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="DocFXPdfSettings.Overwrite"/></li><li><c>--port</c> via <see cref="DocFXPdfSettings.Port"/></li><li><c>--postProcessors</c> via <see cref="DocFXPdfSettings.PostProcessors"/></li><li><c>--rawModelOutputFolder</c> via <see cref="DocFXPdfSettings.RawModelOutputFolder"/></li><li><c>--rawOutputFolder</c> via <see cref="DocFXPdfSettings.RawOutputFolder"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXPdfSettings.RepoRoot"/></li><li><c>--resource</c> via <see cref="DocFXPdfSettings.Resource"/></li><li><c>--schemaLicense</c> via <see cref="DocFXPdfSettings.SchemaLicense"/></li><li><c>--serve</c> via <see cref="DocFXPdfSettings.Serve"/></li><li><c>--template</c> via <see cref="DocFXPdfSettings.Templates"/></li><li><c>--theme</c> via <see cref="DocFXPdfSettings.Themes"/></li><li><c>--viewModelOutputFolder</c> via <see cref="DocFXPdfSettings.ViewModelOutputFolder"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXPdfSettings.WarningsAsErrors"/></li><li><c>--xref</c> via <see cref="DocFXPdfSettings.XRefMaps"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXPdf(Configure<DocFXPdfSettings> configurator) => new DocFXTasks().Run(configurator.Invoke(new DocFXPdfSettings()));
    /// <summary><p>Generate pdf file.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;configFile&gt;</c> via <see cref="DocFXPdfSettings.ConfigFile"/></li><li><c>--basePath</c> via <see cref="DocFXPdfSettings.BasePath"/></li><li><c>--changesFile</c> via <see cref="DocFXPdfSettings.ChangesFile"/></li><li><c>--cleanupCacheHistory</c> via <see cref="DocFXPdfSettings.CleanupCacheHistory"/></li><li><c>--content</c> via <see cref="DocFXPdfSettings.Content"/></li><li><c>--correlationId</c> via <see cref="DocFXPdfSettings.CorrelationId"/></li><li><c>--css</c> via <see cref="DocFXPdfSettings.CssFilePath"/></li><li><c>--debug</c> via <see cref="DocFXPdfSettings.EnableDebugMode"/></li><li><c>--debugOutput</c> via <see cref="DocFXPdfSettings.OutputFolderForDebugFiles"/></li><li><c>--disableGitFeatures</c> via <see cref="DocFXPdfSettings.DisableGitFeatures"/></li><li><c>--dryRun</c> via <see cref="DocFXPdfSettings.DryRun"/></li><li><c>--errorHandling</c> via <see cref="DocFXPdfSettings.LoadErrorHandling"/></li><li><c>--excludedTocs</c> via <see cref="DocFXPdfSettings.ExcludedTocs"/></li><li><c>--exportRawModel</c> via <see cref="DocFXPdfSettings.ExportRawModel"/></li><li><c>--exportViewModel</c> via <see cref="DocFXPdfSettings.ExportViewModel"/></li><li><c>--falName</c> via <see cref="DocFXPdfSettings.FALName"/></li><li><c>--fileMetadataFile</c> via <see cref="DocFXPdfSettings.FileMetadataFilePath"/></li><li><c>--fileMetadataFiles</c> via <see cref="DocFXPdfSettings.FileMetadataFilePaths"/></li><li><c>--force</c> via <see cref="DocFXPdfSettings.ForceRebuild"/></li><li><c>--forcePostProcess</c> via <see cref="DocFXPdfSettings.ForcePostProcess"/></li><li><c>--generatesAppendices</c> via <see cref="DocFXPdfSettings.GeneratesAppendices"/></li><li><c>--generatesExternalLink</c> via <see cref="DocFXPdfSettings.GeneratesExternalLink"/></li><li><c>--globalMetadata</c> via <see cref="DocFXPdfSettings.GlobalMetadata"/></li><li><c>--globalMetadataFile</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePath"/></li><li><c>--globalMetadataFiles</c> via <see cref="DocFXPdfSettings.GlobalMetadataFilePaths"/></li><li><c>--help</c> via <see cref="DocFXPdfSettings.PrintHelpMessage"/></li><li><c>--host</c> via <see cref="DocFXPdfSettings.PdfHost"/></li><li><c>--hostname</c> via <see cref="DocFXPdfSettings.Host"/></li><li><c>--intermediateFolder</c> via <see cref="DocFXPdfSettings.IntermediateFolder"/></li><li><c>--keepFileLink</c> via <see cref="DocFXPdfSettings.KeepFileLink"/></li><li><c>--keepRawFiles</c> via <see cref="DocFXPdfSettings.KeepRawFiles"/></li><li><c>--locale</c> via <see cref="DocFXPdfSettings.Locale"/></li><li><c>--log</c> via <see cref="DocFXPdfSettings.LogFilePath"/></li><li><c>--logLevel</c> via <see cref="DocFXPdfSettings.LogLevel"/></li><li><c>--lruSize</c> via <see cref="DocFXPdfSettings.LruSize"/></li><li><c>--markdownEngineName</c> via <see cref="DocFXPdfSettings.MarkdownEngineName"/></li><li><c>--markdownEngineProperties</c> via <see cref="DocFXPdfSettings.MarkdownEngineProperties"/></li><li><c>--maxParallelism</c> via <see cref="DocFXPdfSettings.MaxParallelism"/></li><li><c>--name</c> via <see cref="DocFXPdfSettings.Name"/></li><li><c>--noLangKeyword</c> via <see cref="DocFXPdfSettings.NoLangKeyword"/></li><li><c>--noStdin</c> via <see cref="DocFXPdfSettings.NoInputStreamArgs"/></li><li><c>--output</c> via <see cref="DocFXPdfSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="DocFXPdfSettings.Overwrite"/></li><li><c>--port</c> via <see cref="DocFXPdfSettings.Port"/></li><li><c>--postProcessors</c> via <see cref="DocFXPdfSettings.PostProcessors"/></li><li><c>--rawModelOutputFolder</c> via <see cref="DocFXPdfSettings.RawModelOutputFolder"/></li><li><c>--rawOutputFolder</c> via <see cref="DocFXPdfSettings.RawOutputFolder"/></li><li><c>--repositoryRoot</c> via <see cref="DocFXPdfSettings.RepoRoot"/></li><li><c>--resource</c> via <see cref="DocFXPdfSettings.Resource"/></li><li><c>--schemaLicense</c> via <see cref="DocFXPdfSettings.SchemaLicense"/></li><li><c>--serve</c> via <see cref="DocFXPdfSettings.Serve"/></li><li><c>--template</c> via <see cref="DocFXPdfSettings.Templates"/></li><li><c>--theme</c> via <see cref="DocFXPdfSettings.Themes"/></li><li><c>--viewModelOutputFolder</c> via <see cref="DocFXPdfSettings.ViewModelOutputFolder"/></li><li><c>--warningsAsErrors</c> via <see cref="DocFXPdfSettings.WarningsAsErrors"/></li><li><c>--xref</c> via <see cref="DocFXPdfSettings.XRefMaps"/></li></ul></remarks>
    public static IEnumerable<(DocFXPdfSettings Settings, IReadOnlyCollection<Output> Output)> DocFXPdf(CombinatorialConfigure<DocFXPdfSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DocFXPdf, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Host a local static website.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;folder&gt;</c> via <see cref="DocFXServeSettings.Folder"/></li><li><c>--help</c> via <see cref="DocFXServeSettings.PrintHelpMessage"/></li><li><c>--hostname</c> via <see cref="DocFXServeSettings.Host"/></li><li><c>--port</c> via <see cref="DocFXServeSettings.Port"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXServe(DocFXServeSettings options = null) => new DocFXTasks().Run(options);
    /// <summary><p>Host a local static website.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;folder&gt;</c> via <see cref="DocFXServeSettings.Folder"/></li><li><c>--help</c> via <see cref="DocFXServeSettings.PrintHelpMessage"/></li><li><c>--hostname</c> via <see cref="DocFXServeSettings.Host"/></li><li><c>--port</c> via <see cref="DocFXServeSettings.Port"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXServe(Configure<DocFXServeSettings> configurator) => new DocFXTasks().Run(configurator.Invoke(new DocFXServeSettings()));
    /// <summary><p>Host a local static website.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;folder&gt;</c> via <see cref="DocFXServeSettings.Folder"/></li><li><c>--help</c> via <see cref="DocFXServeSettings.PrintHelpMessage"/></li><li><c>--hostname</c> via <see cref="DocFXServeSettings.Host"/></li><li><c>--port</c> via <see cref="DocFXServeSettings.Port"/></li></ul></remarks>
    public static IEnumerable<(DocFXServeSettings Settings, IReadOnlyCollection<Output> Output)> DocFXServe(CombinatorialConfigure<DocFXServeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DocFXServe, degreeOfParallelism, completeOnFailure);
    /// <summary><p>List or export existing template.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;command&gt;</c> via <see cref="DocFXTemplateSettings.Command"/></li><li><c>--all</c> via <see cref="DocFXTemplateSettings.All"/></li><li><c>--help</c> via <see cref="DocFXTemplateSettings.PrintHelpMessage"/></li><li><c>--output</c> via <see cref="DocFXTemplateSettings.OutputFolder"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXTemplate(DocFXTemplateSettings options = null) => new DocFXTasks().Run(options);
    /// <summary><p>List or export existing template.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;command&gt;</c> via <see cref="DocFXTemplateSettings.Command"/></li><li><c>--all</c> via <see cref="DocFXTemplateSettings.All"/></li><li><c>--help</c> via <see cref="DocFXTemplateSettings.PrintHelpMessage"/></li><li><c>--output</c> via <see cref="DocFXTemplateSettings.OutputFolder"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> DocFXTemplate(Configure<DocFXTemplateSettings> configurator) => new DocFXTasks().Run(configurator.Invoke(new DocFXTemplateSettings()));
    /// <summary><p>List or export existing template.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;command&gt;</c> via <see cref="DocFXTemplateSettings.Command"/></li><li><c>--all</c> via <see cref="DocFXTemplateSettings.All"/></li><li><c>--help</c> via <see cref="DocFXTemplateSettings.PrintHelpMessage"/></li><li><c>--output</c> via <see cref="DocFXTemplateSettings.OutputFolder"/></li></ul></remarks>
    public static IEnumerable<(DocFXTemplateSettings Settings, IReadOnlyCollection<Output> Output)> DocFXTemplate(CombinatorialConfigure<DocFXTemplateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(DocFXTemplate, degreeOfParallelism, completeOnFailure);
}
#region DocFXBuildSettings
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXBuildSettings>))]
[Command(Type = typeof(DocFXTasks), Command = nameof(DocFXTasks.DocFXBuild), Arguments = "build")]
public partial class DocFXBuildSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Set changes file.</summary>
    [Argument(Format = "--changesFile={value}")] public string ChangesFile => Get<string>(() => ChangesFile);
    /// <summary>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</summary>
    [Argument(Format = "--cleanupCacheHistory")] public bool? CleanupCacheHistory => Get<bool?>(() => CleanupCacheHistory);
    /// <summary>Specify content files for generating documentation.</summary>
    [Argument(Format = "--content={value}", Separator = ",")] public IReadOnlyList<string> Content => Get<List<string>>(() => Content);
    /// <summary>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</summary>
    [Argument(Format = "--disableGitFeatures")] public bool? DisableGitFeatures => Get<bool?>(() => DisableGitFeatures);
    /// <summary>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</summary>
    [Argument(Format = "--dryRun")] public bool? DryRun => Get<bool?>(() => DryRun);
    /// <summary>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</summary>
    [Argument(Format = "--debug")] public bool? EnableDebugMode => Get<bool?>(() => EnableDebugMode);
    /// <summary>If set to true, data model to run template script will be extracted in .raw.model.json extension.</summary>
    [Argument(Format = "--exportRawModel")] public bool? ExportRawModel => Get<bool?>(() => ExportRawModel);
    /// <summary>If set to true, data model to apply template will be extracted in .view.model.json extension.</summary>
    [Argument(Format = "--exportViewModel")] public bool? ExportViewModel => Get<bool?>(() => ExportViewModel);
    /// <summary>Set the name of input file abstract layer builder.</summary>
    [Argument(Format = "--falName={value}")] public string FALName => Get<string>(() => FALName);
    /// <summary>Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.</summary>
    [Argument(Format = "--fileMetadataFile={value}")] public string FileMetadataFilePath => Get<string>(() => FileMetadataFilePath);
    /// <summary>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</summary>
    [Argument(Format = "--fileMetadataFiles={value}", Separator = ",")] public IReadOnlyList<string> FileMetadataFilePaths => Get<List<string>>(() => FileMetadataFilePaths);
    /// <summary>Force to re-process the documentation in post processors. It will be cascaded from force option.</summary>
    [Argument(Format = "--forcePostProcess")] public bool? ForcePostProcess => Get<bool?>(() => ForcePostProcess);
    /// <summary>Force re-build all the documentation.</summary>
    [Argument(Format = "--force")] public bool? ForceRebuild => Get<bool?>(() => ForceRebuild);
    /// <summary>Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.</summary>
    [Argument(Format = "--globalMetadata={value}")] public string GlobalMetadata => Get<string>(() => GlobalMetadata);
    /// <summary>Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.</summary>
    [Argument(Format = "--globalMetadataFile={value}")] public string GlobalMetadataFilePath => Get<string>(() => GlobalMetadataFilePath);
    /// <summary>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</summary>
    [Argument(Format = "--globalMetadataFiles={value}", Separator = ",")] public IReadOnlyList<string> GlobalMetadataFilePaths => Get<List<string>>(() => GlobalMetadataFilePaths);
    /// <summary>Specify the hostname of the hosted website (e.g., 'localhost' or '*').</summary>
    [Argument(Format = "--hostname={value}")] public string Host => Get<string>(() => Host);
    /// <summary>Set folder for intermediate build results.</summary>
    [Argument(Format = "--intermediateFolder={value}")] public string IntermediateFolder => Get<string>(() => IntermediateFolder);
    /// <summary>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</summary>
    [Argument(Format = "--keepFileLink")] public bool? KeepFileLink => Get<bool?>(() => KeepFileLink);
    /// <summary>Set the LRU cached model count (approximately the same as the count of input files). By default, it is 8192 for 64bit and 3072 for 32bit process. With LRU cache enabled, memory usage decreases and time consumed increases. If set to 0, Lru cache is disabled.</summary>
    [Argument(Format = "--lruSize={value}")] public int? LruSize => Get<int?>(() => LruSize);
    /// <summary>Set the name of markdown engine, default is 'dfm'.</summary>
    [Argument(Format = "--markdownEngineName={value}")] public string MarkdownEngineName => Get<string>(() => MarkdownEngineName);
    /// <summary>Set the parameters for markdown engine, value should be a JSON string.</summary>
    [Argument(Format = "--markdownEngineProperties={value}")] public string MarkdownEngineProperties => Get<string>(() => MarkdownEngineProperties);
    /// <summary>Set the max parallelism, 0 is auto.</summary>
    [Argument(Format = "--maxParallelism={value}")] public int? MaxParallelism => Get<int?>(() => MaxParallelism);
    /// <summary>Disable default lang keyword.</summary>
    [Argument(Format = "--noLangKeyword")] public bool? NoLangKeyword => Get<bool?>(() => NoLangKeyword);
    /// <summary>Specify the output base directory.</summary>
    [Argument(Format = "--output={value}")] public string OutputFolder => Get<string>(() => OutputFolder);
    /// <summary>The output folder for files generated for debugging purpose when in debug mode. If not specified, it is ${TempPath}/docfx.</summary>
    [Argument(Format = "--debugOutput={value}")] public string OutputFolderForDebugFiles => Get<string>(() => OutputFolderForDebugFiles);
    /// <summary>Specify overwrite files used by content files.</summary>
    [Argument(Format = "--overwrite={value}", Separator = ",")] public IReadOnlyList<string> Overwrite => Get<List<string>>(() => Overwrite);
    /// <summary>Specify the port of the hosted website.</summary>
    [Argument(Format = "--port={value}")] public int? Port => Get<int?>(() => Port);
    /// <summary>Set the order of post processors in plugins.</summary>
    [Argument(Format = "--postProcessors={value}", Separator = ",")] public IReadOnlyList<string> PostProcessors => Get<List<string>>(() => PostProcessors);
    /// <summary>Print help message for this sub-command.</summary>
    [Argument(Format = "--help")] public bool? PrintHelpMessage => Get<bool?>(() => PrintHelpMessage);
    /// <summary>Specify the output folder for the raw model. If not set, the raw model will be generated to the same folder as the output documentation.</summary>
    [Argument(Format = "--rawModelOutputFolder={value}")] public string RawModelOutputFolder => Get<string>(() => RawModelOutputFolder);
    /// <summary>Specify resources used by content files.</summary>
    [Argument(Format = "--resource={value}", Separator = ",")] public IReadOnlyList<string> Resource => Get<List<string>>(() => Resource);
    /// <summary>Please provide the license key for validating schema using NewtonsoftJson.Schema here.</summary>
    [Argument(Format = "--schemaLicense={value}")] public string SchemaLicense => Get<string>(() => SchemaLicense);
    /// <summary>Host the generated documentation to a website.</summary>
    [Argument(Format = "--serve")] public bool? Serve => Get<bool?>(() => Serve);
    /// <summary>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</summary>
    [Argument(Format = "--template={value}", Separator = ",")] public IReadOnlyList<string> Templates => Get<List<string>>(() => Templates);
    /// <summary>Specify which theme to use. By default 'default' theme is offered.</summary>
    [Argument(Format = "--theme={value}", Separator = ",")] public IReadOnlyList<string> Themes => Get<List<string>>(() => Themes);
    /// <summary>Specify the output folder for the view model. If not set, the view model will be generated to the same folder as the output documentation.</summary>
    [Argument(Format = "--viewModelOutputFolder={value}")] public string ViewModelOutputFolder => Get<string>(() => ViewModelOutputFolder);
    /// <summary>Specify the urls of xrefmap used by content files.</summary>
    [Argument(Format = "--xref={value}", Separator = ",")] public IReadOnlyList<string> XRefMaps => Get<List<string>>(() => XRefMaps);
    /// <summary>Specify the correlation id used for logging.</summary>
    [Argument(Format = "--correlationId={value}")] public string CorrelationId => Get<string>(() => CorrelationId);
    /// <summary>Specify the file name to save processing log.</summary>
    [Argument(Format = "--log={value}")] public string LogFilePath => Get<string>(() => LogFilePath);
    /// <summary>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</summary>
    [Argument(Format = "--logLevel={value}")] public DocFXLogLevel LogLevel => Get<DocFXLogLevel>(() => LogLevel);
    /// <summary>Specify the GIT repository root folder.</summary>
    [Argument(Format = "--repositoryRoot={value}")] public string RepoRoot => Get<string>(() => RepoRoot);
    /// <summary>Specify if warnings should be treated as errors.</summary>
    [Argument(Format = "--warningsAsErrors")] public bool? WarningsAsErrors => Get<bool?>(() => WarningsAsErrors);
}
#endregion
#region DocFXDependencySettings
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXDependencySettings>))]
[Command(Type = typeof(DocFXTasks), Command = nameof(DocFXTasks.DocFXDependency), Arguments = "dependency")]
public partial class DocFXDependencySettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string DependencyFile => Get<string>(() => DependencyFile);
    /// <summary>The intermediate folder that store cache files.</summary>
    [Argument(Format = "--intermediateFolder={value}")] public string IntermediateFolder => Get<string>(() => IntermediateFolder);
    /// <summary>Print help message for this sub-command.</summary>
    [Argument(Format = "--help")] public bool? PrintHelpMessage => Get<bool?>(() => PrintHelpMessage);
    /// <summary>The version name of the content.</summary>
    [Argument(Format = "--version={value}")] public string VersionName => Get<string>(() => VersionName);
}
#endregion
#region DocFXDownloadSettings
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXDownloadSettings>))]
[Command(Type = typeof(DocFXTasks), Command = nameof(DocFXTasks.DocFXDownload), Arguments = "download")]
public partial class DocFXDownloadSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string ArchiveFile => Get<string>(() => ArchiveFile);
    /// <summary>Print help message for this sub-command.</summary>
    [Argument(Format = "--help")] public bool? PrintHelpMessage => Get<bool?>(() => PrintHelpMessage);
    /// <summary>Specify the url of xrefmap.</summary>
    [Argument(Format = "--xref={value}")] public string Uri => Get<string>(() => Uri);
}
#endregion
#region DocFXHelpSettings
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXHelpSettings>))]
[Command(Type = typeof(DocFXTasks), Command = nameof(DocFXTasks.DocFXHelp), Arguments = "help")]
public partial class DocFXHelpSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string Command => Get<string>(() => Command);
}
#endregion
#region DocFXInitSettings
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXInitSettings>))]
[Command(Type = typeof(DocFXTasks), Command = nameof(DocFXTasks.DocFXInit), Arguments = "init")]
public partial class DocFXInitSettings : ToolOptions
{
    /// <summary>Specify the source working folder for source project files to start glob search.</summary>
    [Argument(Format = "--apiSourceFolder={value}")] public string ApiSourceFolder => Get<string>(() => ApiSourceFolder);
    /// <summary>Specify the source project files' glob pattern to generate metadata.</summary>
    [Argument(Format = "--apiGlobPattern={value}")] public string ApiSourceGlobPattern => Get<string>(() => ApiSourceGlobPattern);
    /// <summary>Generate config file docfx.json only, no project folder will be generated.</summary>
    [Argument(Format = "--file")] public bool? OnlyConfigFile => Get<bool?>(() => OnlyConfigFile);
    /// <summary>Specify the output folder of the config file. If not specified, the config file will be saved to a new folder docfx_project.</summary>
    [Argument(Format = "--output={value}")] public string OutputFolder => Get<string>(() => OutputFolder);
    /// <summary>Specify if the current file will be overwritten if it exists.</summary>
    [Argument(Format = "--overwrite")] public bool? Overwrite => Get<bool?>(() => Overwrite);
    /// <summary>Print help message for this sub-command.</summary>
    [Argument(Format = "--help")] public bool? PrintHelpMessage => Get<bool?>(() => PrintHelpMessage);
    /// <summary>Quietly generate the default docfx.json.</summary>
    [Argument(Format = "--quiet")] public bool? Quiet => Get<bool?>(() => Quiet);
}
#endregion
#region DocFXMergeSettings
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXMergeSettings>))]
[Command(Type = typeof(DocFXTasks), Command = nameof(DocFXTasks.DocFXMerge), Arguments = "merge")]
public partial class DocFXMergeSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Specifies content files for generating documentation.</summary>
    [Argument(Format = "--content={value}", Separator = ",")] public IReadOnlyList<string> Content => Get<List<string>>(() => Content);
    /// <summary>Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.</summary>
    [Argument(Format = "--fileMetadataFile={value}")] public string FileMetadataFilePath => Get<string>(() => FileMetadataFilePath);
    /// <summary>Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.</summary>
    [Argument(Format = "--globalMetadata={value}")] public string GlobalMetadata => Get<string>(() => GlobalMetadata);
    /// <summary>Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.</summary>
    [Argument(Format = "--globalMetadataFile={value}")] public string GlobalMetadataFilePath => Get<string>(() => GlobalMetadataFilePath);
    /// <summary>Print help message for this sub-command.</summary>
    [Argument(Format = "--help")] public bool? PrintHelpMessage => Get<bool?>(() => PrintHelpMessage);
    /// <summary>Specify metadata names that need to be merged into toc file.</summary>
    [Argument(Format = "--tocMetadata={value}", Separator = ",")] public IReadOnlyList<string> TocMetadata => Get<List<string>>(() => TocMetadata);
    /// <summary>Specify the correlation id used for logging.</summary>
    [Argument(Format = "--correlationId={value}")] public string CorrelationId => Get<string>(() => CorrelationId);
    /// <summary>Specify the file name to save processing log.</summary>
    [Argument(Format = "--log={value}")] public string LogFilePath => Get<string>(() => LogFilePath);
    /// <summary>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</summary>
    [Argument(Format = "--logLevel={value}")] public DocFXLogLevel LogLevel => Get<DocFXLogLevel>(() => LogLevel);
    /// <summary>Specify the GIT repository root folder.</summary>
    [Argument(Format = "--repositoryRoot={value}")] public string RepoRoot => Get<string>(() => RepoRoot);
    /// <summary>Specify if warnings should be treated as errors.</summary>
    [Argument(Format = "--warningsAsErrors")] public bool? WarningsAsErrors => Get<bool?>(() => WarningsAsErrors);
}
#endregion
#region DocFXMetadataSettings
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXMetadataSettings>))]
[Command(Type = typeof(DocFXTasks), Command = nameof(DocFXTasks.DocFXMetadata), Arguments = "metadata")]
public partial class DocFXMetadataSettings : ToolOptions
{
    /// <summary>The projects for which the metadata should be built.</summary>
    [Argument(Format = "{value}", Position = 1, Separator = " ")] public IReadOnlyList<string> Projects => Get<List<string>>(() => Projects);
    /// <summary>Disable the default API filter (default filter only generate public or protected APIs).</summary>
    [Argument(Format = "--disableDefaultFilter")] public bool? DisableDefaultFilter => Get<bool?>(() => DisableDefaultFilter);
    /// <summary>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</summary>
    [Argument(Format = "--disableGitFeatures")] public bool? DisableGitFeatures => Get<bool?>(() => DisableGitFeatures);
    /// <summary>Specify the filter config file.</summary>
    [Argument(Format = "--filter={value}")] public string FilterConfigFile => Get<string>(() => FilterConfigFile);
    /// <summary>Force re-generate all the metadata.</summary>
    [Argument(Format = "--force")] public bool? ForceRebuild => Get<bool?>(() => ForceRebuild);
    /// <summary>Specify the name to use for the global namespace.</summary>
    [Argument(Format = "--globalNamespaceId={value}")] public string GlobalNamespaceId => Get<string>(() => GlobalNamespaceId);
    /// <summary>--property &lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; An optional set of MSBuild properties used when interpreting project files. These are the same properties that are passed to msbuild via the /property:&lt;n1&gt;=&lt;v1&gt;;&lt;n2&gt;=&lt;v2&gt; command line argument.</summary>
    [Argument(Format = "--property {key}={value}", Separator = ";")] public IReadOnlyDictionary<string, string> MSBuildProperties => Get<Dictionary<string, string>>(() => MSBuildProperties);
    /// <summary>Specify the output base directory.</summary>
    [Argument(Format = "--output={value}")] public string OutputFolder => Get<string>(() => OutputFolder);
    /// <summary>Preserve the existing xml comment tags inside 'summary' triple slash comments.</summary>
    [Argument(Format = "--raw")] public bool? PreserveRawInlineComments => Get<bool?>(() => PreserveRawInlineComments);
    /// <summary>Print help message for this sub-command.</summary>
    [Argument(Format = "--help")] public bool? PrintHelpMessage => Get<bool?>(() => PrintHelpMessage);
    /// <summary>Skip to markup the triple slash comments.</summary>
    [Argument(Format = "--shouldSkipMarkup")] public bool? ShouldSkipMarkup => Get<bool?>(() => ShouldSkipMarkup);
    /// <summary>Specify the correlation id used for logging.</summary>
    [Argument(Format = "--correlationId={value}")] public string CorrelationId => Get<string>(() => CorrelationId);
    /// <summary>Specify the file name to save processing log.</summary>
    [Argument(Format = "--log={value}")] public string LogFilePath => Get<string>(() => LogFilePath);
    /// <summary>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</summary>
    [Argument(Format = "--logLevel={value}")] public DocFXLogLevel LogLevel => Get<DocFXLogLevel>(() => LogLevel);
    /// <summary>Specify the GIT repository root folder.</summary>
    [Argument(Format = "--repositoryRoot={value}")] public string RepoRoot => Get<string>(() => RepoRoot);
    /// <summary>Specify if warnings should be treated as errors.</summary>
    [Argument(Format = "--warningsAsErrors")] public bool? WarningsAsErrors => Get<bool?>(() => WarningsAsErrors);
}
#endregion
#region DocFXPdfSettings
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXPdfSettings>))]
[Command(Type = typeof(DocFXTasks), Command = nameof(DocFXTasks.DocFXPdf), Arguments = "pdf")]
public partial class DocFXPdfSettings : ToolOptions
{
    /// <summary>Specify the base path to generate external link, {host}/{locale}/{basePath}.</summary>
    [Argument(Format = "--basePath={value}")] public string BasePath => Get<string>(() => BasePath);
    /// <summary>Specify the path for the css to generate pdf, default value is styles/default.css.</summary>
    [Argument(Format = "--css={value}")] public string CssFilePath => Get<string>(() => CssFilePath);
    /// <summary>Specify the toc files to be excluded.</summary>
    [Argument(Format = "--excludedTocs={value}")] public IReadOnlyList<string> ExcludedTocs => Get<List<string>>(() => ExcludedTocs);
    /// <summary>Specify whether or not to generate appendices for not-in-TOC articles.</summary>
    [Argument(Format = "--generatesAppendices")] public bool? GeneratesAppendices => Get<bool?>(() => GeneratesAppendices);
    /// <summary>Specify whether or not to generate external links for PDF.</summary>
    [Argument(Format = "--generatesExternalLink")] public bool? GeneratesExternalLink => Get<bool?>(() => GeneratesExternalLink);
    /// <summary>Specify the hostname to link not-in-TOC articles.</summary>
    [Argument(Format = "--host={value}")] public string PdfHost => Get<string>(() => PdfHost);
    /// <summary>Specify whether or not to keep the intermediate html files that used to generate the PDF file. It it usually used in debug purpose. By default the value is false.</summary>
    [Argument(Format = "--keepRawFiles")] public bool? KeepRawFiles => Get<bool?>(() => KeepRawFiles);
    /// <summary>Specify how to handle pdf pages that fail to load: abort, ignore or skip(default abort), it is the same input as wkhtmltopdf --load-error-handling options.</summary>
    [Argument(Format = "--errorHandling={value}")] public string LoadErrorHandling => Get<string>(() => LoadErrorHandling);
    /// <summary>Specify the locale of the pdf file.</summary>
    [Argument(Format = "--locale={value}")] public string Locale => Get<string>(() => Locale);
    /// <summary>Specify the name of the generated pdf.</summary>
    [Argument(Format = "--name={value}")] public string Name => Get<string>(() => Name);
    /// <summary>Do not use stdin when wkhtmltopdf is executed.</summary>
    [Argument(Format = "--noStdin")] public bool? NoInputStreamArgs => Get<bool?>(() => NoInputStreamArgs);
    /// <summary>Specify the output folder for the raw files, if not specified, raw files will by default be saved to _raw subfolder under output folder if keepRawFiles is set to true.</summary>
    [Argument(Format = "--rawOutputFolder={value}")] public string RawOutputFolder => Get<string>(() => RawOutputFolder);
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Set changes file.</summary>
    [Argument(Format = "--changesFile={value}")] public string ChangesFile => Get<string>(() => ChangesFile);
    /// <summary>If set to true, docfx create a new intermediate folder for cache files, historical cache data will be cleaned up.</summary>
    [Argument(Format = "--cleanupCacheHistory")] public bool? CleanupCacheHistory => Get<bool?>(() => CleanupCacheHistory);
    /// <summary>Specify content files for generating documentation.</summary>
    [Argument(Format = "--content={value}", Separator = ",")] public IReadOnlyList<string> Content => Get<List<string>>(() => Content);
    /// <summary>Disable fetching Git related information for articles. By default it is enabled and may have side effect on performance when the repo is large.</summary>
    [Argument(Format = "--disableGitFeatures")] public bool? DisableGitFeatures => Get<bool?>(() => DisableGitFeatures);
    /// <summary>If set to true, template will not be actually applied to the documents. This option is always used with --exportRawModel or --exportViewModel is set so that only raw model files or view model files are generated.</summary>
    [Argument(Format = "--dryRun")] public bool? DryRun => Get<bool?>(() => DryRun);
    /// <summary>Run in debug mode. With debug mode, raw model and view model will be exported automatically when it encounters error when applying templates. If not specified, it is false.</summary>
    [Argument(Format = "--debug")] public bool? EnableDebugMode => Get<bool?>(() => EnableDebugMode);
    /// <summary>If set to true, data model to run template script will be extracted in .raw.model.json extension.</summary>
    [Argument(Format = "--exportRawModel")] public bool? ExportRawModel => Get<bool?>(() => ExportRawModel);
    /// <summary>If set to true, data model to apply template will be extracted in .view.model.json extension.</summary>
    [Argument(Format = "--exportViewModel")] public bool? ExportViewModel => Get<bool?>(() => ExportViewModel);
    /// <summary>Set the name of input file abstract layer builder.</summary>
    [Argument(Format = "--falName={value}")] public string FALName => Get<string>(() => FALName);
    /// <summary>Specify a JSON file path containing fileMetadata settings, as similar to {"fileMetadata":{"key":"value"}}. It overrides the fileMetadata settings from the config file.</summary>
    [Argument(Format = "--fileMetadataFile={value}")] public string FileMetadataFilePath => Get<string>(() => FileMetadataFilePath);
    /// <summary>Specify a list of JSON file path containing fileMetadata settings, as similar to {"key":"value"}. It overrides the fileMetadata settings from the config file.</summary>
    [Argument(Format = "--fileMetadataFiles={value}", Separator = ",")] public IReadOnlyList<string> FileMetadataFilePaths => Get<List<string>>(() => FileMetadataFilePaths);
    /// <summary>Force to re-process the documentation in post processors. It will be cascaded from force option.</summary>
    [Argument(Format = "--forcePostProcess")] public bool? ForcePostProcess => Get<bool?>(() => ForcePostProcess);
    /// <summary>Force re-build all the documentation.</summary>
    [Argument(Format = "--force")] public bool? ForceRebuild => Get<bool?>(() => ForceRebuild);
    /// <summary>Specify global metadata key-value pair in json format. It overrides the globalMetadata settings from the config file.</summary>
    [Argument(Format = "--globalMetadata={value}")] public string GlobalMetadata => Get<string>(() => GlobalMetadata);
    /// <summary>Specify a JSON file path containing globalMetadata settings, as similar to {"globalMetadata":{"key":"value"}}. It overrides the globalMetadata settings from the config file.</summary>
    [Argument(Format = "--globalMetadataFile={value}")] public string GlobalMetadataFilePath => Get<string>(() => GlobalMetadataFilePath);
    /// <summary>Specify a list of JSON file path containing globalMetadata settings, as similar to {"key":"value"}. It overrides the globalMetadata settings from the config file.</summary>
    [Argument(Format = "--globalMetadataFiles={value}", Separator = ",")] public IReadOnlyList<string> GlobalMetadataFilePaths => Get<List<string>>(() => GlobalMetadataFilePaths);
    /// <summary>Specify the hostname of the hosted website (e.g., 'localhost' or '*').</summary>
    [Argument(Format = "--hostname={value}")] public string Host => Get<string>(() => Host);
    /// <summary>Set folder for intermediate build results.</summary>
    [Argument(Format = "--intermediateFolder={value}")] public string IntermediateFolder => Get<string>(() => IntermediateFolder);
    /// <summary>If set to true, docfx does not dereference (aka. copy) file to the output folder, instead, it saves a link_to_path property inside mainfiest.json to indicate the physical location of that file.</summary>
    [Argument(Format = "--keepFileLink")] public bool? KeepFileLink => Get<bool?>(() => KeepFileLink);
    /// <summary>Set the LRU cached model count (approximately the same as the count of input files). By default, it is 8192 for 64bit and 3072 for 32bit process. With LRU cache enabled, memory usage decreases and time consumed increases. If set to 0, Lru cache is disabled.</summary>
    [Argument(Format = "--lruSize={value}")] public int? LruSize => Get<int?>(() => LruSize);
    /// <summary>Set the name of markdown engine, default is 'dfm'.</summary>
    [Argument(Format = "--markdownEngineName={value}")] public string MarkdownEngineName => Get<string>(() => MarkdownEngineName);
    /// <summary>Set the parameters for markdown engine, value should be a JSON string.</summary>
    [Argument(Format = "--markdownEngineProperties={value}")] public string MarkdownEngineProperties => Get<string>(() => MarkdownEngineProperties);
    /// <summary>Set the max parallelism, 0 is auto.</summary>
    [Argument(Format = "--maxParallelism={value}")] public int? MaxParallelism => Get<int?>(() => MaxParallelism);
    /// <summary>Disable default lang keyword.</summary>
    [Argument(Format = "--noLangKeyword")] public bool? NoLangKeyword => Get<bool?>(() => NoLangKeyword);
    /// <summary>Specify the output base directory.</summary>
    [Argument(Format = "--output={value}")] public string OutputFolder => Get<string>(() => OutputFolder);
    /// <summary>The output folder for files generated for debugging purpose when in debug mode. If not specified, it is ${TempPath}/docfx.</summary>
    [Argument(Format = "--debugOutput={value}")] public string OutputFolderForDebugFiles => Get<string>(() => OutputFolderForDebugFiles);
    /// <summary>Specify overwrite files used by content files.</summary>
    [Argument(Format = "--overwrite={value}", Separator = ",")] public IReadOnlyList<string> Overwrite => Get<List<string>>(() => Overwrite);
    /// <summary>Specify the port of the hosted website.</summary>
    [Argument(Format = "--port={value}")] public int? Port => Get<int?>(() => Port);
    /// <summary>Set the order of post processors in plugins.</summary>
    [Argument(Format = "--postProcessors={value}", Separator = ",")] public IReadOnlyList<string> PostProcessors => Get<List<string>>(() => PostProcessors);
    /// <summary>Print help message for this sub-command.</summary>
    [Argument(Format = "--help")] public bool? PrintHelpMessage => Get<bool?>(() => PrintHelpMessage);
    /// <summary>Specify the output folder for the raw model. If not set, the raw model will be generated to the same folder as the output documentation.</summary>
    [Argument(Format = "--rawModelOutputFolder={value}")] public string RawModelOutputFolder => Get<string>(() => RawModelOutputFolder);
    /// <summary>Specify resources used by content files.</summary>
    [Argument(Format = "--resource={value}", Separator = ",")] public IReadOnlyList<string> Resource => Get<List<string>>(() => Resource);
    /// <summary>Please provide the license key for validating schema using NewtonsoftJson.Schema here.</summary>
    [Argument(Format = "--schemaLicense={value}")] public string SchemaLicense => Get<string>(() => SchemaLicense);
    /// <summary>Host the generated documentation to a website.</summary>
    [Argument(Format = "--serve")] public bool? Serve => Get<bool?>(() => Serve);
    /// <summary>Specify the template name to apply to. If not specified, output YAML file will not be transformed.</summary>
    [Argument(Format = "--template={value}", Separator = ",")] public IReadOnlyList<string> Templates => Get<List<string>>(() => Templates);
    /// <summary>Specify which theme to use. By default 'default' theme is offered.</summary>
    [Argument(Format = "--theme={value}", Separator = ",")] public IReadOnlyList<string> Themes => Get<List<string>>(() => Themes);
    /// <summary>Specify the output folder for the view model. If not set, the view model will be generated to the same folder as the output documentation.</summary>
    [Argument(Format = "--viewModelOutputFolder={value}")] public string ViewModelOutputFolder => Get<string>(() => ViewModelOutputFolder);
    /// <summary>Specify the urls of xrefmap used by content files.</summary>
    [Argument(Format = "--xref={value}", Separator = ",")] public IReadOnlyList<string> XRefMaps => Get<List<string>>(() => XRefMaps);
    /// <summary>Specify the correlation id used for logging.</summary>
    [Argument(Format = "--correlationId={value}")] public string CorrelationId => Get<string>(() => CorrelationId);
    /// <summary>Specify the file name to save processing log.</summary>
    [Argument(Format = "--log={value}")] public string LogFilePath => Get<string>(() => LogFilePath);
    /// <summary>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</summary>
    [Argument(Format = "--logLevel={value}")] public DocFXLogLevel LogLevel => Get<DocFXLogLevel>(() => LogLevel);
    /// <summary>Specify the GIT repository root folder.</summary>
    [Argument(Format = "--repositoryRoot={value}")] public string RepoRoot => Get<string>(() => RepoRoot);
    /// <summary>Specify if warnings should be treated as errors.</summary>
    [Argument(Format = "--warningsAsErrors")] public bool? WarningsAsErrors => Get<bool?>(() => WarningsAsErrors);
}
#endregion
#region DocFXServeSettings
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXServeSettings>))]
[Command(Type = typeof(DocFXTasks), Command = nameof(DocFXTasks.DocFXServe), Arguments = "serve")]
public partial class DocFXServeSettings : ToolOptions
{
    /// <summary></summary>
    [Argument(Format = "{value}", Position = 1)] public string Folder => Get<string>(() => Folder);
    /// <summary>Specify the hostname of the hosted website [localhost].</summary>
    [Argument(Format = "--hostname={value}")] public string Host => Get<string>(() => Host);
    /// <summary>Specify the port of the hosted website [8080].</summary>
    [Argument(Format = "--port={value}")] public int? Port => Get<int?>(() => Port);
    /// <summary>Print help message for this sub-command.</summary>
    [Argument(Format = "--help")] public bool? PrintHelpMessage => Get<bool?>(() => PrintHelpMessage);
}
#endregion
#region DocFXTemplateSettings
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXTemplateSettings>))]
[Command(Type = typeof(DocFXTasks), Command = nameof(DocFXTasks.DocFXTemplate), Arguments = "template")]
public partial class DocFXTemplateSettings : ToolOptions
{
    /// <summary>The command to execute.</summary>
    [Argument(Format = "{value}", Position = 1, Separator = " ")] public string Command => Get<string>(() => Command);
    /// <summary>If specified, all the available templates will be exported.</summary>
    [Argument(Format = "--all")] public bool? All => Get<bool?>(() => All);
    /// <summary>Specify the output folder path for the exported templates.</summary>
    [Argument(Format = "--output={value}")] public string OutputFolder => Get<string>(() => OutputFolder);
    /// <summary>Print help message for this sub-command.</summary>
    [Argument(Format = "--help")] public bool? PrintHelpMessage => Get<bool?>(() => PrintHelpMessage);
}
#endregion
#region DocFXBuildSettingsExtensions
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DocFXBuildSettingsExtensions
{
    #region ConfigFile
    /// <inheritdoc cref="DocFXBuildSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="DocFXBuildSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ChangesFile
    /// <inheritdoc cref="DocFXBuildSettings.ChangesFile"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ChangesFile))]
    public static T SetChangesFile<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ChangesFile, v));
    /// <inheritdoc cref="DocFXBuildSettings.ChangesFile"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ChangesFile))]
    public static T ResetChangesFile<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.ChangesFile));
    #endregion
    #region CleanupCacheHistory
    /// <inheritdoc cref="DocFXBuildSettings.CleanupCacheHistory"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.CleanupCacheHistory))]
    public static T SetCleanupCacheHistory<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.CleanupCacheHistory, v));
    /// <inheritdoc cref="DocFXBuildSettings.CleanupCacheHistory"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.CleanupCacheHistory))]
    public static T ResetCleanupCacheHistory<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.CleanupCacheHistory));
    /// <inheritdoc cref="DocFXBuildSettings.CleanupCacheHistory"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.CleanupCacheHistory))]
    public static T EnableCleanupCacheHistory<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.CleanupCacheHistory, true));
    /// <inheritdoc cref="DocFXBuildSettings.CleanupCacheHistory"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.CleanupCacheHistory))]
    public static T DisableCleanupCacheHistory<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.CleanupCacheHistory, false));
    /// <inheritdoc cref="DocFXBuildSettings.CleanupCacheHistory"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.CleanupCacheHistory))]
    public static T ToggleCleanupCacheHistory<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.CleanupCacheHistory, !o.CleanupCacheHistory));
    #endregion
    #region Content
    /// <inheritdoc cref="DocFXBuildSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Content))]
    public static T SetContent<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Content, v));
    /// <inheritdoc cref="DocFXBuildSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Content))]
    public static T SetContent<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Content, v));
    /// <inheritdoc cref="DocFXBuildSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Content))]
    public static T AddContent<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXBuildSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Content))]
    public static T AddContent<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXBuildSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Content))]
    public static T RemoveContent<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXBuildSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Content))]
    public static T RemoveContent<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXBuildSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Content))]
    public static T ClearContent<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.ClearCollection(() => o.Content));
    #endregion
    #region DisableGitFeatures
    /// <inheritdoc cref="DocFXBuildSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.DisableGitFeatures))]
    public static T SetDisableGitFeatures<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, v));
    /// <inheritdoc cref="DocFXBuildSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.DisableGitFeatures))]
    public static T ResetDisableGitFeatures<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.DisableGitFeatures));
    /// <inheritdoc cref="DocFXBuildSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.DisableGitFeatures))]
    public static T EnableDisableGitFeatures<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, true));
    /// <inheritdoc cref="DocFXBuildSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.DisableGitFeatures))]
    public static T DisableDisableGitFeatures<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, false));
    /// <inheritdoc cref="DocFXBuildSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.DisableGitFeatures))]
    public static T ToggleDisableGitFeatures<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, !o.DisableGitFeatures));
    #endregion
    #region DryRun
    /// <inheritdoc cref="DocFXBuildSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.DryRun))]
    public static T SetDryRun<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.DryRun, v));
    /// <inheritdoc cref="DocFXBuildSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.DryRun))]
    public static T ResetDryRun<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.DryRun));
    /// <inheritdoc cref="DocFXBuildSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.DryRun))]
    public static T EnableDryRun<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.DryRun, true));
    /// <inheritdoc cref="DocFXBuildSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.DryRun))]
    public static T DisableDryRun<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.DryRun, false));
    /// <inheritdoc cref="DocFXBuildSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.DryRun))]
    public static T ToggleDryRun<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.DryRun, !o.DryRun));
    #endregion
    #region EnableDebugMode
    /// <inheritdoc cref="DocFXBuildSettings.EnableDebugMode"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.EnableDebugMode))]
    public static T SetEnableDebugMode<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.EnableDebugMode, v));
    /// <inheritdoc cref="DocFXBuildSettings.EnableDebugMode"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.EnableDebugMode))]
    public static T ResetEnableDebugMode<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.EnableDebugMode));
    /// <inheritdoc cref="DocFXBuildSettings.EnableDebugMode"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.EnableDebugMode))]
    public static T EnableEnableDebugMode<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.EnableDebugMode, true));
    /// <inheritdoc cref="DocFXBuildSettings.EnableDebugMode"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.EnableDebugMode))]
    public static T DisableEnableDebugMode<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.EnableDebugMode, false));
    /// <inheritdoc cref="DocFXBuildSettings.EnableDebugMode"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.EnableDebugMode))]
    public static T ToggleEnableDebugMode<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.EnableDebugMode, !o.EnableDebugMode));
    #endregion
    #region ExportRawModel
    /// <inheritdoc cref="DocFXBuildSettings.ExportRawModel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ExportRawModel))]
    public static T SetExportRawModel<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ExportRawModel, v));
    /// <inheritdoc cref="DocFXBuildSettings.ExportRawModel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ExportRawModel))]
    public static T ResetExportRawModel<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.ExportRawModel));
    /// <inheritdoc cref="DocFXBuildSettings.ExportRawModel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ExportRawModel))]
    public static T EnableExportRawModel<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ExportRawModel, true));
    /// <inheritdoc cref="DocFXBuildSettings.ExportRawModel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ExportRawModel))]
    public static T DisableExportRawModel<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ExportRawModel, false));
    /// <inheritdoc cref="DocFXBuildSettings.ExportRawModel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ExportRawModel))]
    public static T ToggleExportRawModel<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ExportRawModel, !o.ExportRawModel));
    #endregion
    #region ExportViewModel
    /// <inheritdoc cref="DocFXBuildSettings.ExportViewModel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ExportViewModel))]
    public static T SetExportViewModel<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ExportViewModel, v));
    /// <inheritdoc cref="DocFXBuildSettings.ExportViewModel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ExportViewModel))]
    public static T ResetExportViewModel<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.ExportViewModel));
    /// <inheritdoc cref="DocFXBuildSettings.ExportViewModel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ExportViewModel))]
    public static T EnableExportViewModel<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ExportViewModel, true));
    /// <inheritdoc cref="DocFXBuildSettings.ExportViewModel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ExportViewModel))]
    public static T DisableExportViewModel<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ExportViewModel, false));
    /// <inheritdoc cref="DocFXBuildSettings.ExportViewModel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ExportViewModel))]
    public static T ToggleExportViewModel<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ExportViewModel, !o.ExportViewModel));
    #endregion
    #region FALName
    /// <inheritdoc cref="DocFXBuildSettings.FALName"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FALName))]
    public static T SetFALName<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.FALName, v));
    /// <inheritdoc cref="DocFXBuildSettings.FALName"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FALName))]
    public static T ResetFALName<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.FALName));
    #endregion
    #region FileMetadataFilePath
    /// <inheritdoc cref="DocFXBuildSettings.FileMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FileMetadataFilePath))]
    public static T SetFileMetadataFilePath<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.FileMetadataFilePath, v));
    /// <inheritdoc cref="DocFXBuildSettings.FileMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FileMetadataFilePath))]
    public static T ResetFileMetadataFilePath<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.FileMetadataFilePath));
    #endregion
    #region FileMetadataFilePaths
    /// <inheritdoc cref="DocFXBuildSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FileMetadataFilePaths))]
    public static T SetFileMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FileMetadataFilePaths))]
    public static T SetFileMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FileMetadataFilePaths))]
    public static T AddFileMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FileMetadataFilePaths))]
    public static T AddFileMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FileMetadataFilePaths))]
    public static T RemoveFileMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FileMetadataFilePaths))]
    public static T RemoveFileMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.FileMetadataFilePaths))]
    public static T ClearFileMetadataFilePaths<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.ClearCollection(() => o.FileMetadataFilePaths));
    #endregion
    #region ForcePostProcess
    /// <inheritdoc cref="DocFXBuildSettings.ForcePostProcess"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ForcePostProcess))]
    public static T SetForcePostProcess<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ForcePostProcess, v));
    /// <inheritdoc cref="DocFXBuildSettings.ForcePostProcess"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ForcePostProcess))]
    public static T ResetForcePostProcess<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.ForcePostProcess));
    /// <inheritdoc cref="DocFXBuildSettings.ForcePostProcess"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ForcePostProcess))]
    public static T EnableForcePostProcess<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ForcePostProcess, true));
    /// <inheritdoc cref="DocFXBuildSettings.ForcePostProcess"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ForcePostProcess))]
    public static T DisableForcePostProcess<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ForcePostProcess, false));
    /// <inheritdoc cref="DocFXBuildSettings.ForcePostProcess"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ForcePostProcess))]
    public static T ToggleForcePostProcess<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ForcePostProcess, !o.ForcePostProcess));
    #endregion
    #region ForceRebuild
    /// <inheritdoc cref="DocFXBuildSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ForceRebuild))]
    public static T SetForceRebuild<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ForceRebuild, v));
    /// <inheritdoc cref="DocFXBuildSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ForceRebuild))]
    public static T ResetForceRebuild<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.ForceRebuild));
    /// <inheritdoc cref="DocFXBuildSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ForceRebuild))]
    public static T EnableForceRebuild<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ForceRebuild, true));
    /// <inheritdoc cref="DocFXBuildSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ForceRebuild))]
    public static T DisableForceRebuild<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ForceRebuild, false));
    /// <inheritdoc cref="DocFXBuildSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ForceRebuild))]
    public static T ToggleForceRebuild<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ForceRebuild, !o.ForceRebuild));
    #endregion
    #region GlobalMetadata
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadata))]
    public static T SetGlobalMetadata<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.GlobalMetadata, v));
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadata))]
    public static T ResetGlobalMetadata<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.GlobalMetadata));
    #endregion
    #region GlobalMetadataFilePath
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadataFilePath))]
    public static T SetGlobalMetadataFilePath<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.GlobalMetadataFilePath, v));
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadataFilePath))]
    public static T ResetGlobalMetadataFilePath<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.GlobalMetadataFilePath));
    #endregion
    #region GlobalMetadataFilePaths
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadataFilePaths))]
    public static T SetGlobalMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadataFilePaths))]
    public static T SetGlobalMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadataFilePaths))]
    public static T AddGlobalMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadataFilePaths))]
    public static T AddGlobalMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadataFilePaths))]
    public static T RemoveGlobalMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadataFilePaths))]
    public static T RemoveGlobalMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXBuildSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.GlobalMetadataFilePaths))]
    public static T ClearGlobalMetadataFilePaths<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.ClearCollection(() => o.GlobalMetadataFilePaths));
    #endregion
    #region Host
    /// <inheritdoc cref="DocFXBuildSettings.Host"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Host))]
    public static T SetHost<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Host, v));
    /// <inheritdoc cref="DocFXBuildSettings.Host"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Host))]
    public static T ResetHost<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.Host));
    #endregion
    #region IntermediateFolder
    /// <inheritdoc cref="DocFXBuildSettings.IntermediateFolder"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.IntermediateFolder))]
    public static T SetIntermediateFolder<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.IntermediateFolder, v));
    /// <inheritdoc cref="DocFXBuildSettings.IntermediateFolder"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.IntermediateFolder))]
    public static T ResetIntermediateFolder<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.IntermediateFolder));
    #endregion
    #region KeepFileLink
    /// <inheritdoc cref="DocFXBuildSettings.KeepFileLink"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.KeepFileLink))]
    public static T SetKeepFileLink<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.KeepFileLink, v));
    /// <inheritdoc cref="DocFXBuildSettings.KeepFileLink"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.KeepFileLink))]
    public static T ResetKeepFileLink<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.KeepFileLink));
    /// <inheritdoc cref="DocFXBuildSettings.KeepFileLink"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.KeepFileLink))]
    public static T EnableKeepFileLink<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.KeepFileLink, true));
    /// <inheritdoc cref="DocFXBuildSettings.KeepFileLink"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.KeepFileLink))]
    public static T DisableKeepFileLink<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.KeepFileLink, false));
    /// <inheritdoc cref="DocFXBuildSettings.KeepFileLink"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.KeepFileLink))]
    public static T ToggleKeepFileLink<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.KeepFileLink, !o.KeepFileLink));
    #endregion
    #region LruSize
    /// <inheritdoc cref="DocFXBuildSettings.LruSize"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.LruSize))]
    public static T SetLruSize<T>(this T o, int? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.LruSize, v));
    /// <inheritdoc cref="DocFXBuildSettings.LruSize"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.LruSize))]
    public static T ResetLruSize<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.LruSize));
    #endregion
    #region MarkdownEngineName
    /// <inheritdoc cref="DocFXBuildSettings.MarkdownEngineName"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.MarkdownEngineName))]
    public static T SetMarkdownEngineName<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.MarkdownEngineName, v));
    /// <inheritdoc cref="DocFXBuildSettings.MarkdownEngineName"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.MarkdownEngineName))]
    public static T ResetMarkdownEngineName<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.MarkdownEngineName));
    #endregion
    #region MarkdownEngineProperties
    /// <inheritdoc cref="DocFXBuildSettings.MarkdownEngineProperties"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.MarkdownEngineProperties))]
    public static T SetMarkdownEngineProperties<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.MarkdownEngineProperties, v));
    /// <inheritdoc cref="DocFXBuildSettings.MarkdownEngineProperties"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.MarkdownEngineProperties))]
    public static T ResetMarkdownEngineProperties<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.MarkdownEngineProperties));
    #endregion
    #region MaxParallelism
    /// <inheritdoc cref="DocFXBuildSettings.MaxParallelism"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.MaxParallelism))]
    public static T SetMaxParallelism<T>(this T o, int? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.MaxParallelism, v));
    /// <inheritdoc cref="DocFXBuildSettings.MaxParallelism"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.MaxParallelism))]
    public static T ResetMaxParallelism<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.MaxParallelism));
    #endregion
    #region NoLangKeyword
    /// <inheritdoc cref="DocFXBuildSettings.NoLangKeyword"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.NoLangKeyword))]
    public static T SetNoLangKeyword<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.NoLangKeyword, v));
    /// <inheritdoc cref="DocFXBuildSettings.NoLangKeyword"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.NoLangKeyword))]
    public static T ResetNoLangKeyword<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.NoLangKeyword));
    /// <inheritdoc cref="DocFXBuildSettings.NoLangKeyword"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.NoLangKeyword))]
    public static T EnableNoLangKeyword<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.NoLangKeyword, true));
    /// <inheritdoc cref="DocFXBuildSettings.NoLangKeyword"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.NoLangKeyword))]
    public static T DisableNoLangKeyword<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.NoLangKeyword, false));
    /// <inheritdoc cref="DocFXBuildSettings.NoLangKeyword"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.NoLangKeyword))]
    public static T ToggleNoLangKeyword<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.NoLangKeyword, !o.NoLangKeyword));
    #endregion
    #region OutputFolder
    /// <inheritdoc cref="DocFXBuildSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.OutputFolder))]
    public static T SetOutputFolder<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.OutputFolder, v));
    /// <inheritdoc cref="DocFXBuildSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.OutputFolder))]
    public static T ResetOutputFolder<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.OutputFolder));
    #endregion
    #region OutputFolderForDebugFiles
    /// <inheritdoc cref="DocFXBuildSettings.OutputFolderForDebugFiles"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.OutputFolderForDebugFiles))]
    public static T SetOutputFolderForDebugFiles<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.OutputFolderForDebugFiles, v));
    /// <inheritdoc cref="DocFXBuildSettings.OutputFolderForDebugFiles"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.OutputFolderForDebugFiles))]
    public static T ResetOutputFolderForDebugFiles<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.OutputFolderForDebugFiles));
    #endregion
    #region Overwrite
    /// <inheritdoc cref="DocFXBuildSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Overwrite))]
    public static T SetOverwrite<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXBuildSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Overwrite))]
    public static T SetOverwrite<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXBuildSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Overwrite))]
    public static T AddOverwrite<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXBuildSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Overwrite))]
    public static T AddOverwrite<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXBuildSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Overwrite))]
    public static T RemoveOverwrite<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXBuildSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Overwrite))]
    public static T RemoveOverwrite<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXBuildSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Overwrite))]
    public static T ClearOverwrite<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.ClearCollection(() => o.Overwrite));
    #endregion
    #region Port
    /// <inheritdoc cref="DocFXBuildSettings.Port"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Port))]
    public static T SetPort<T>(this T o, int? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Port, v));
    /// <inheritdoc cref="DocFXBuildSettings.Port"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Port))]
    public static T ResetPort<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.Port));
    #endregion
    #region PostProcessors
    /// <inheritdoc cref="DocFXBuildSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PostProcessors))]
    public static T SetPostProcessors<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXBuildSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PostProcessors))]
    public static T SetPostProcessors<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXBuildSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PostProcessors))]
    public static T AddPostProcessors<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXBuildSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PostProcessors))]
    public static T AddPostProcessors<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXBuildSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PostProcessors))]
    public static T RemovePostProcessors<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXBuildSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PostProcessors))]
    public static T RemovePostProcessors<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXBuildSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PostProcessors))]
    public static T ClearPostProcessors<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.ClearCollection(() => o.PostProcessors));
    #endregion
    #region PrintHelpMessage
    /// <inheritdoc cref="DocFXBuildSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PrintHelpMessage))]
    public static T SetPrintHelpMessage<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, v));
    /// <inheritdoc cref="DocFXBuildSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PrintHelpMessage))]
    public static T ResetPrintHelpMessage<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.PrintHelpMessage));
    /// <inheritdoc cref="DocFXBuildSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PrintHelpMessage))]
    public static T EnablePrintHelpMessage<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, true));
    /// <inheritdoc cref="DocFXBuildSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PrintHelpMessage))]
    public static T DisablePrintHelpMessage<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, false));
    /// <inheritdoc cref="DocFXBuildSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.PrintHelpMessage))]
    public static T TogglePrintHelpMessage<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, !o.PrintHelpMessage));
    #endregion
    #region RawModelOutputFolder
    /// <inheritdoc cref="DocFXBuildSettings.RawModelOutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.RawModelOutputFolder))]
    public static T SetRawModelOutputFolder<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.RawModelOutputFolder, v));
    /// <inheritdoc cref="DocFXBuildSettings.RawModelOutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.RawModelOutputFolder))]
    public static T ResetRawModelOutputFolder<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.RawModelOutputFolder));
    #endregion
    #region Resource
    /// <inheritdoc cref="DocFXBuildSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Resource))]
    public static T SetResource<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Resource, v));
    /// <inheritdoc cref="DocFXBuildSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Resource))]
    public static T SetResource<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Resource, v));
    /// <inheritdoc cref="DocFXBuildSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Resource))]
    public static T AddResource<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.Resource, v));
    /// <inheritdoc cref="DocFXBuildSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Resource))]
    public static T AddResource<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.Resource, v));
    /// <inheritdoc cref="DocFXBuildSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Resource))]
    public static T RemoveResource<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Resource, v));
    /// <inheritdoc cref="DocFXBuildSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Resource))]
    public static T RemoveResource<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Resource, v));
    /// <inheritdoc cref="DocFXBuildSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Resource))]
    public static T ClearResource<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.ClearCollection(() => o.Resource));
    #endregion
    #region SchemaLicense
    /// <inheritdoc cref="DocFXBuildSettings.SchemaLicense"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.SchemaLicense))]
    public static T SetSchemaLicense<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.SchemaLicense, v));
    /// <inheritdoc cref="DocFXBuildSettings.SchemaLicense"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.SchemaLicense))]
    public static T ResetSchemaLicense<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.SchemaLicense));
    #endregion
    #region Serve
    /// <inheritdoc cref="DocFXBuildSettings.Serve"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Serve))]
    public static T SetServe<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Serve, v));
    /// <inheritdoc cref="DocFXBuildSettings.Serve"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Serve))]
    public static T ResetServe<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.Serve));
    /// <inheritdoc cref="DocFXBuildSettings.Serve"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Serve))]
    public static T EnableServe<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Serve, true));
    /// <inheritdoc cref="DocFXBuildSettings.Serve"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Serve))]
    public static T DisableServe<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Serve, false));
    /// <inheritdoc cref="DocFXBuildSettings.Serve"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Serve))]
    public static T ToggleServe<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Serve, !o.Serve));
    #endregion
    #region Templates
    /// <inheritdoc cref="DocFXBuildSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Templates))]
    public static T SetTemplates<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Templates, v));
    /// <inheritdoc cref="DocFXBuildSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Templates))]
    public static T SetTemplates<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Templates, v));
    /// <inheritdoc cref="DocFXBuildSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Templates))]
    public static T AddTemplates<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.Templates, v));
    /// <inheritdoc cref="DocFXBuildSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Templates))]
    public static T AddTemplates<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.Templates, v));
    /// <inheritdoc cref="DocFXBuildSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Templates))]
    public static T RemoveTemplates<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Templates, v));
    /// <inheritdoc cref="DocFXBuildSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Templates))]
    public static T RemoveTemplates<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Templates, v));
    /// <inheritdoc cref="DocFXBuildSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Templates))]
    public static T ClearTemplates<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.ClearCollection(() => o.Templates));
    #endregion
    #region Themes
    /// <inheritdoc cref="DocFXBuildSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Themes))]
    public static T SetThemes<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Themes, v));
    /// <inheritdoc cref="DocFXBuildSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Themes))]
    public static T SetThemes<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.Themes, v));
    /// <inheritdoc cref="DocFXBuildSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Themes))]
    public static T AddThemes<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.Themes, v));
    /// <inheritdoc cref="DocFXBuildSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Themes))]
    public static T AddThemes<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.Themes, v));
    /// <inheritdoc cref="DocFXBuildSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Themes))]
    public static T RemoveThemes<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Themes, v));
    /// <inheritdoc cref="DocFXBuildSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Themes))]
    public static T RemoveThemes<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.Themes, v));
    /// <inheritdoc cref="DocFXBuildSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.Themes))]
    public static T ClearThemes<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.ClearCollection(() => o.Themes));
    #endregion
    #region ViewModelOutputFolder
    /// <inheritdoc cref="DocFXBuildSettings.ViewModelOutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ViewModelOutputFolder))]
    public static T SetViewModelOutputFolder<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.ViewModelOutputFolder, v));
    /// <inheritdoc cref="DocFXBuildSettings.ViewModelOutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.ViewModelOutputFolder))]
    public static T ResetViewModelOutputFolder<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.ViewModelOutputFolder));
    #endregion
    #region XRefMaps
    /// <inheritdoc cref="DocFXBuildSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.XRefMaps))]
    public static T SetXRefMaps<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXBuildSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.XRefMaps))]
    public static T SetXRefMaps<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXBuildSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.XRefMaps))]
    public static T AddXRefMaps<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXBuildSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.XRefMaps))]
    public static T AddXRefMaps<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.AddCollection(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXBuildSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.XRefMaps))]
    public static T RemoveXRefMaps<T>(this T o, params string[] v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXBuildSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.XRefMaps))]
    public static T RemoveXRefMaps<T>(this T o, IEnumerable<string> v) where T : DocFXBuildSettings => o.Modify(b => b.RemoveCollection(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXBuildSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.XRefMaps))]
    public static T ClearXRefMaps<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.ClearCollection(() => o.XRefMaps));
    #endregion
    #region CorrelationId
    /// <inheritdoc cref="DocFXBuildSettings.CorrelationId"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.CorrelationId))]
    public static T SetCorrelationId<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.CorrelationId, v));
    /// <inheritdoc cref="DocFXBuildSettings.CorrelationId"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.CorrelationId))]
    public static T ResetCorrelationId<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.CorrelationId));
    #endregion
    #region LogFilePath
    /// <inheritdoc cref="DocFXBuildSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.LogFilePath))]
    public static T SetLogFilePath<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.LogFilePath, v));
    /// <inheritdoc cref="DocFXBuildSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.LogFilePath))]
    public static T ResetLogFilePath<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.LogFilePath));
    #endregion
    #region LogLevel
    /// <inheritdoc cref="DocFXBuildSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.LogLevel))]
    public static T SetLogLevel<T>(this T o, DocFXLogLevel v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.LogLevel, v));
    /// <inheritdoc cref="DocFXBuildSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.LogLevel))]
    public static T ResetLogLevel<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.LogLevel));
    #endregion
    #region RepoRoot
    /// <inheritdoc cref="DocFXBuildSettings.RepoRoot"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.RepoRoot))]
    public static T SetRepoRoot<T>(this T o, string v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.RepoRoot, v));
    /// <inheritdoc cref="DocFXBuildSettings.RepoRoot"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.RepoRoot))]
    public static T ResetRepoRoot<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.RepoRoot));
    #endregion
    #region WarningsAsErrors
    /// <inheritdoc cref="DocFXBuildSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.WarningsAsErrors))]
    public static T SetWarningsAsErrors<T>(this T o, bool? v) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, v));
    /// <inheritdoc cref="DocFXBuildSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.WarningsAsErrors))]
    public static T ResetWarningsAsErrors<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Remove(() => o.WarningsAsErrors));
    /// <inheritdoc cref="DocFXBuildSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.WarningsAsErrors))]
    public static T EnableWarningsAsErrors<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, true));
    /// <inheritdoc cref="DocFXBuildSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.WarningsAsErrors))]
    public static T DisableWarningsAsErrors<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, false));
    /// <inheritdoc cref="DocFXBuildSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXBuildSettings), Property = nameof(DocFXBuildSettings.WarningsAsErrors))]
    public static T ToggleWarningsAsErrors<T>(this T o) where T : DocFXBuildSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, !o.WarningsAsErrors));
    #endregion
}
#endregion
#region DocFXDependencySettingsExtensions
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DocFXDependencySettingsExtensions
{
    #region DependencyFile
    /// <inheritdoc cref="DocFXDependencySettings.DependencyFile"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.DependencyFile))]
    public static T SetDependencyFile<T>(this T o, string v) where T : DocFXDependencySettings => o.Modify(b => b.Set(() => o.DependencyFile, v));
    /// <inheritdoc cref="DocFXDependencySettings.DependencyFile"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.DependencyFile))]
    public static T ResetDependencyFile<T>(this T o) where T : DocFXDependencySettings => o.Modify(b => b.Remove(() => o.DependencyFile));
    #endregion
    #region IntermediateFolder
    /// <inheritdoc cref="DocFXDependencySettings.IntermediateFolder"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.IntermediateFolder))]
    public static T SetIntermediateFolder<T>(this T o, string v) where T : DocFXDependencySettings => o.Modify(b => b.Set(() => o.IntermediateFolder, v));
    /// <inheritdoc cref="DocFXDependencySettings.IntermediateFolder"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.IntermediateFolder))]
    public static T ResetIntermediateFolder<T>(this T o) where T : DocFXDependencySettings => o.Modify(b => b.Remove(() => o.IntermediateFolder));
    #endregion
    #region PrintHelpMessage
    /// <inheritdoc cref="DocFXDependencySettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.PrintHelpMessage))]
    public static T SetPrintHelpMessage<T>(this T o, bool? v) where T : DocFXDependencySettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, v));
    /// <inheritdoc cref="DocFXDependencySettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.PrintHelpMessage))]
    public static T ResetPrintHelpMessage<T>(this T o) where T : DocFXDependencySettings => o.Modify(b => b.Remove(() => o.PrintHelpMessage));
    /// <inheritdoc cref="DocFXDependencySettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.PrintHelpMessage))]
    public static T EnablePrintHelpMessage<T>(this T o) where T : DocFXDependencySettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, true));
    /// <inheritdoc cref="DocFXDependencySettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.PrintHelpMessage))]
    public static T DisablePrintHelpMessage<T>(this T o) where T : DocFXDependencySettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, false));
    /// <inheritdoc cref="DocFXDependencySettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.PrintHelpMessage))]
    public static T TogglePrintHelpMessage<T>(this T o) where T : DocFXDependencySettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, !o.PrintHelpMessage));
    #endregion
    #region VersionName
    /// <inheritdoc cref="DocFXDependencySettings.VersionName"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.VersionName))]
    public static T SetVersionName<T>(this T o, string v) where T : DocFXDependencySettings => o.Modify(b => b.Set(() => o.VersionName, v));
    /// <inheritdoc cref="DocFXDependencySettings.VersionName"/>
    [Pure] [Builder(Type = typeof(DocFXDependencySettings), Property = nameof(DocFXDependencySettings.VersionName))]
    public static T ResetVersionName<T>(this T o) where T : DocFXDependencySettings => o.Modify(b => b.Remove(() => o.VersionName));
    #endregion
}
#endregion
#region DocFXDownloadSettingsExtensions
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DocFXDownloadSettingsExtensions
{
    #region ArchiveFile
    /// <inheritdoc cref="DocFXDownloadSettings.ArchiveFile"/>
    [Pure] [Builder(Type = typeof(DocFXDownloadSettings), Property = nameof(DocFXDownloadSettings.ArchiveFile))]
    public static T SetArchiveFile<T>(this T o, string v) where T : DocFXDownloadSettings => o.Modify(b => b.Set(() => o.ArchiveFile, v));
    /// <inheritdoc cref="DocFXDownloadSettings.ArchiveFile"/>
    [Pure] [Builder(Type = typeof(DocFXDownloadSettings), Property = nameof(DocFXDownloadSettings.ArchiveFile))]
    public static T ResetArchiveFile<T>(this T o) where T : DocFXDownloadSettings => o.Modify(b => b.Remove(() => o.ArchiveFile));
    #endregion
    #region PrintHelpMessage
    /// <inheritdoc cref="DocFXDownloadSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXDownloadSettings), Property = nameof(DocFXDownloadSettings.PrintHelpMessage))]
    public static T SetPrintHelpMessage<T>(this T o, bool? v) where T : DocFXDownloadSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, v));
    /// <inheritdoc cref="DocFXDownloadSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXDownloadSettings), Property = nameof(DocFXDownloadSettings.PrintHelpMessage))]
    public static T ResetPrintHelpMessage<T>(this T o) where T : DocFXDownloadSettings => o.Modify(b => b.Remove(() => o.PrintHelpMessage));
    /// <inheritdoc cref="DocFXDownloadSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXDownloadSettings), Property = nameof(DocFXDownloadSettings.PrintHelpMessage))]
    public static T EnablePrintHelpMessage<T>(this T o) where T : DocFXDownloadSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, true));
    /// <inheritdoc cref="DocFXDownloadSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXDownloadSettings), Property = nameof(DocFXDownloadSettings.PrintHelpMessage))]
    public static T DisablePrintHelpMessage<T>(this T o) where T : DocFXDownloadSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, false));
    /// <inheritdoc cref="DocFXDownloadSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXDownloadSettings), Property = nameof(DocFXDownloadSettings.PrintHelpMessage))]
    public static T TogglePrintHelpMessage<T>(this T o) where T : DocFXDownloadSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, !o.PrintHelpMessage));
    #endregion
    #region Uri
    /// <inheritdoc cref="DocFXDownloadSettings.Uri"/>
    [Pure] [Builder(Type = typeof(DocFXDownloadSettings), Property = nameof(DocFXDownloadSettings.Uri))]
    public static T SetUri<T>(this T o, string v) where T : DocFXDownloadSettings => o.Modify(b => b.Set(() => o.Uri, v));
    /// <inheritdoc cref="DocFXDownloadSettings.Uri"/>
    [Pure] [Builder(Type = typeof(DocFXDownloadSettings), Property = nameof(DocFXDownloadSettings.Uri))]
    public static T ResetUri<T>(this T o) where T : DocFXDownloadSettings => o.Modify(b => b.Remove(() => o.Uri));
    #endregion
}
#endregion
#region DocFXHelpSettingsExtensions
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DocFXHelpSettingsExtensions
{
    #region Command
    /// <inheritdoc cref="DocFXHelpSettings.Command"/>
    [Pure] [Builder(Type = typeof(DocFXHelpSettings), Property = nameof(DocFXHelpSettings.Command))]
    public static T SetCommand<T>(this T o, string v) where T : DocFXHelpSettings => o.Modify(b => b.Set(() => o.Command, v));
    /// <inheritdoc cref="DocFXHelpSettings.Command"/>
    [Pure] [Builder(Type = typeof(DocFXHelpSettings), Property = nameof(DocFXHelpSettings.Command))]
    public static T ResetCommand<T>(this T o) where T : DocFXHelpSettings => o.Modify(b => b.Remove(() => o.Command));
    #endregion
}
#endregion
#region DocFXInitSettingsExtensions
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DocFXInitSettingsExtensions
{
    #region ApiSourceFolder
    /// <inheritdoc cref="DocFXInitSettings.ApiSourceFolder"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.ApiSourceFolder))]
    public static T SetApiSourceFolder<T>(this T o, string v) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.ApiSourceFolder, v));
    /// <inheritdoc cref="DocFXInitSettings.ApiSourceFolder"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.ApiSourceFolder))]
    public static T ResetApiSourceFolder<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Remove(() => o.ApiSourceFolder));
    #endregion
    #region ApiSourceGlobPattern
    /// <inheritdoc cref="DocFXInitSettings.ApiSourceGlobPattern"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.ApiSourceGlobPattern))]
    public static T SetApiSourceGlobPattern<T>(this T o, string v) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.ApiSourceGlobPattern, v));
    /// <inheritdoc cref="DocFXInitSettings.ApiSourceGlobPattern"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.ApiSourceGlobPattern))]
    public static T ResetApiSourceGlobPattern<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Remove(() => o.ApiSourceGlobPattern));
    #endregion
    #region OnlyConfigFile
    /// <inheritdoc cref="DocFXInitSettings.OnlyConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.OnlyConfigFile))]
    public static T SetOnlyConfigFile<T>(this T o, bool? v) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.OnlyConfigFile, v));
    /// <inheritdoc cref="DocFXInitSettings.OnlyConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.OnlyConfigFile))]
    public static T ResetOnlyConfigFile<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Remove(() => o.OnlyConfigFile));
    /// <inheritdoc cref="DocFXInitSettings.OnlyConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.OnlyConfigFile))]
    public static T EnableOnlyConfigFile<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.OnlyConfigFile, true));
    /// <inheritdoc cref="DocFXInitSettings.OnlyConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.OnlyConfigFile))]
    public static T DisableOnlyConfigFile<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.OnlyConfigFile, false));
    /// <inheritdoc cref="DocFXInitSettings.OnlyConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.OnlyConfigFile))]
    public static T ToggleOnlyConfigFile<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.OnlyConfigFile, !o.OnlyConfigFile));
    #endregion
    #region OutputFolder
    /// <inheritdoc cref="DocFXInitSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.OutputFolder))]
    public static T SetOutputFolder<T>(this T o, string v) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.OutputFolder, v));
    /// <inheritdoc cref="DocFXInitSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.OutputFolder))]
    public static T ResetOutputFolder<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Remove(() => o.OutputFolder));
    #endregion
    #region Overwrite
    /// <inheritdoc cref="DocFXInitSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.Overwrite))]
    public static T SetOverwrite<T>(this T o, bool? v) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXInitSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.Overwrite))]
    public static T ResetOverwrite<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Remove(() => o.Overwrite));
    /// <inheritdoc cref="DocFXInitSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.Overwrite))]
    public static T EnableOverwrite<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.Overwrite, true));
    /// <inheritdoc cref="DocFXInitSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.Overwrite))]
    public static T DisableOverwrite<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.Overwrite, false));
    /// <inheritdoc cref="DocFXInitSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.Overwrite))]
    public static T ToggleOverwrite<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.Overwrite, !o.Overwrite));
    #endregion
    #region PrintHelpMessage
    /// <inheritdoc cref="DocFXInitSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.PrintHelpMessage))]
    public static T SetPrintHelpMessage<T>(this T o, bool? v) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, v));
    /// <inheritdoc cref="DocFXInitSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.PrintHelpMessage))]
    public static T ResetPrintHelpMessage<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Remove(() => o.PrintHelpMessage));
    /// <inheritdoc cref="DocFXInitSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.PrintHelpMessage))]
    public static T EnablePrintHelpMessage<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, true));
    /// <inheritdoc cref="DocFXInitSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.PrintHelpMessage))]
    public static T DisablePrintHelpMessage<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, false));
    /// <inheritdoc cref="DocFXInitSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.PrintHelpMessage))]
    public static T TogglePrintHelpMessage<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, !o.PrintHelpMessage));
    #endregion
    #region Quiet
    /// <inheritdoc cref="DocFXInitSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.Quiet))]
    public static T SetQuiet<T>(this T o, bool? v) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.Quiet, v));
    /// <inheritdoc cref="DocFXInitSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.Quiet))]
    public static T ResetQuiet<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Remove(() => o.Quiet));
    /// <inheritdoc cref="DocFXInitSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.Quiet))]
    public static T EnableQuiet<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.Quiet, true));
    /// <inheritdoc cref="DocFXInitSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.Quiet))]
    public static T DisableQuiet<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.Quiet, false));
    /// <inheritdoc cref="DocFXInitSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(DocFXInitSettings), Property = nameof(DocFXInitSettings.Quiet))]
    public static T ToggleQuiet<T>(this T o) where T : DocFXInitSettings => o.Modify(b => b.Set(() => o.Quiet, !o.Quiet));
    #endregion
}
#endregion
#region DocFXMergeSettingsExtensions
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DocFXMergeSettingsExtensions
{
    #region ConfigFile
    /// <inheritdoc cref="DocFXMergeSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="DocFXMergeSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Content
    /// <inheritdoc cref="DocFXMergeSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.Content))]
    public static T SetContent<T>(this T o, params string[] v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.Content, v));
    /// <inheritdoc cref="DocFXMergeSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.Content))]
    public static T SetContent<T>(this T o, IEnumerable<string> v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.Content, v));
    /// <inheritdoc cref="DocFXMergeSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.Content))]
    public static T AddContent<T>(this T o, params string[] v) where T : DocFXMergeSettings => o.Modify(b => b.AddCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXMergeSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.Content))]
    public static T AddContent<T>(this T o, IEnumerable<string> v) where T : DocFXMergeSettings => o.Modify(b => b.AddCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXMergeSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.Content))]
    public static T RemoveContent<T>(this T o, params string[] v) where T : DocFXMergeSettings => o.Modify(b => b.RemoveCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXMergeSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.Content))]
    public static T RemoveContent<T>(this T o, IEnumerable<string> v) where T : DocFXMergeSettings => o.Modify(b => b.RemoveCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXMergeSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.Content))]
    public static T ClearContent<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.ClearCollection(() => o.Content));
    #endregion
    #region FileMetadataFilePath
    /// <inheritdoc cref="DocFXMergeSettings.FileMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.FileMetadataFilePath))]
    public static T SetFileMetadataFilePath<T>(this T o, string v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.FileMetadataFilePath, v));
    /// <inheritdoc cref="DocFXMergeSettings.FileMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.FileMetadataFilePath))]
    public static T ResetFileMetadataFilePath<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Remove(() => o.FileMetadataFilePath));
    #endregion
    #region GlobalMetadata
    /// <inheritdoc cref="DocFXMergeSettings.GlobalMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.GlobalMetadata))]
    public static T SetGlobalMetadata<T>(this T o, string v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.GlobalMetadata, v));
    /// <inheritdoc cref="DocFXMergeSettings.GlobalMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.GlobalMetadata))]
    public static T ResetGlobalMetadata<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Remove(() => o.GlobalMetadata));
    #endregion
    #region GlobalMetadataFilePath
    /// <inheritdoc cref="DocFXMergeSettings.GlobalMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.GlobalMetadataFilePath))]
    public static T SetGlobalMetadataFilePath<T>(this T o, string v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.GlobalMetadataFilePath, v));
    /// <inheritdoc cref="DocFXMergeSettings.GlobalMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.GlobalMetadataFilePath))]
    public static T ResetGlobalMetadataFilePath<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Remove(() => o.GlobalMetadataFilePath));
    #endregion
    #region PrintHelpMessage
    /// <inheritdoc cref="DocFXMergeSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.PrintHelpMessage))]
    public static T SetPrintHelpMessage<T>(this T o, bool? v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, v));
    /// <inheritdoc cref="DocFXMergeSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.PrintHelpMessage))]
    public static T ResetPrintHelpMessage<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Remove(() => o.PrintHelpMessage));
    /// <inheritdoc cref="DocFXMergeSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.PrintHelpMessage))]
    public static T EnablePrintHelpMessage<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, true));
    /// <inheritdoc cref="DocFXMergeSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.PrintHelpMessage))]
    public static T DisablePrintHelpMessage<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, false));
    /// <inheritdoc cref="DocFXMergeSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.PrintHelpMessage))]
    public static T TogglePrintHelpMessage<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, !o.PrintHelpMessage));
    #endregion
    #region TocMetadata
    /// <inheritdoc cref="DocFXMergeSettings.TocMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.TocMetadata))]
    public static T SetTocMetadata<T>(this T o, params string[] v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.TocMetadata, v));
    /// <inheritdoc cref="DocFXMergeSettings.TocMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.TocMetadata))]
    public static T SetTocMetadata<T>(this T o, IEnumerable<string> v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.TocMetadata, v));
    /// <inheritdoc cref="DocFXMergeSettings.TocMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.TocMetadata))]
    public static T AddTocMetadata<T>(this T o, params string[] v) where T : DocFXMergeSettings => o.Modify(b => b.AddCollection(() => o.TocMetadata, v));
    /// <inheritdoc cref="DocFXMergeSettings.TocMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.TocMetadata))]
    public static T AddTocMetadata<T>(this T o, IEnumerable<string> v) where T : DocFXMergeSettings => o.Modify(b => b.AddCollection(() => o.TocMetadata, v));
    /// <inheritdoc cref="DocFXMergeSettings.TocMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.TocMetadata))]
    public static T RemoveTocMetadata<T>(this T o, params string[] v) where T : DocFXMergeSettings => o.Modify(b => b.RemoveCollection(() => o.TocMetadata, v));
    /// <inheritdoc cref="DocFXMergeSettings.TocMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.TocMetadata))]
    public static T RemoveTocMetadata<T>(this T o, IEnumerable<string> v) where T : DocFXMergeSettings => o.Modify(b => b.RemoveCollection(() => o.TocMetadata, v));
    /// <inheritdoc cref="DocFXMergeSettings.TocMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.TocMetadata))]
    public static T ClearTocMetadata<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.ClearCollection(() => o.TocMetadata));
    #endregion
    #region CorrelationId
    /// <inheritdoc cref="DocFXMergeSettings.CorrelationId"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.CorrelationId))]
    public static T SetCorrelationId<T>(this T o, string v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.CorrelationId, v));
    /// <inheritdoc cref="DocFXMergeSettings.CorrelationId"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.CorrelationId))]
    public static T ResetCorrelationId<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Remove(() => o.CorrelationId));
    #endregion
    #region LogFilePath
    /// <inheritdoc cref="DocFXMergeSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.LogFilePath))]
    public static T SetLogFilePath<T>(this T o, string v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.LogFilePath, v));
    /// <inheritdoc cref="DocFXMergeSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.LogFilePath))]
    public static T ResetLogFilePath<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Remove(() => o.LogFilePath));
    #endregion
    #region LogLevel
    /// <inheritdoc cref="DocFXMergeSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.LogLevel))]
    public static T SetLogLevel<T>(this T o, DocFXLogLevel v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.LogLevel, v));
    /// <inheritdoc cref="DocFXMergeSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.LogLevel))]
    public static T ResetLogLevel<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Remove(() => o.LogLevel));
    #endregion
    #region RepoRoot
    /// <inheritdoc cref="DocFXMergeSettings.RepoRoot"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.RepoRoot))]
    public static T SetRepoRoot<T>(this T o, string v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.RepoRoot, v));
    /// <inheritdoc cref="DocFXMergeSettings.RepoRoot"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.RepoRoot))]
    public static T ResetRepoRoot<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Remove(() => o.RepoRoot));
    #endregion
    #region WarningsAsErrors
    /// <inheritdoc cref="DocFXMergeSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.WarningsAsErrors))]
    public static T SetWarningsAsErrors<T>(this T o, bool? v) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, v));
    /// <inheritdoc cref="DocFXMergeSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.WarningsAsErrors))]
    public static T ResetWarningsAsErrors<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Remove(() => o.WarningsAsErrors));
    /// <inheritdoc cref="DocFXMergeSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.WarningsAsErrors))]
    public static T EnableWarningsAsErrors<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, true));
    /// <inheritdoc cref="DocFXMergeSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.WarningsAsErrors))]
    public static T DisableWarningsAsErrors<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, false));
    /// <inheritdoc cref="DocFXMergeSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXMergeSettings), Property = nameof(DocFXMergeSettings.WarningsAsErrors))]
    public static T ToggleWarningsAsErrors<T>(this T o) where T : DocFXMergeSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, !o.WarningsAsErrors));
    #endregion
}
#endregion
#region DocFXMetadataSettingsExtensions
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DocFXMetadataSettingsExtensions
{
    #region Projects
    /// <inheritdoc cref="DocFXMetadataSettings.Projects"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.Projects))]
    public static T SetProjects<T>(this T o, params string[] v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.Projects, v));
    /// <inheritdoc cref="DocFXMetadataSettings.Projects"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.Projects))]
    public static T SetProjects<T>(this T o, IEnumerable<string> v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.Projects, v));
    /// <inheritdoc cref="DocFXMetadataSettings.Projects"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.Projects))]
    public static T AddProjects<T>(this T o, params string[] v) where T : DocFXMetadataSettings => o.Modify(b => b.AddCollection(() => o.Projects, v));
    /// <inheritdoc cref="DocFXMetadataSettings.Projects"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.Projects))]
    public static T AddProjects<T>(this T o, IEnumerable<string> v) where T : DocFXMetadataSettings => o.Modify(b => b.AddCollection(() => o.Projects, v));
    /// <inheritdoc cref="DocFXMetadataSettings.Projects"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.Projects))]
    public static T RemoveProjects<T>(this T o, params string[] v) where T : DocFXMetadataSettings => o.Modify(b => b.RemoveCollection(() => o.Projects, v));
    /// <inheritdoc cref="DocFXMetadataSettings.Projects"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.Projects))]
    public static T RemoveProjects<T>(this T o, IEnumerable<string> v) where T : DocFXMetadataSettings => o.Modify(b => b.RemoveCollection(() => o.Projects, v));
    /// <inheritdoc cref="DocFXMetadataSettings.Projects"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.Projects))]
    public static T ClearProjects<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.ClearCollection(() => o.Projects));
    #endregion
    #region DisableDefaultFilter
    /// <inheritdoc cref="DocFXMetadataSettings.DisableDefaultFilter"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.DisableDefaultFilter))]
    public static T SetDisableDefaultFilter<T>(this T o, bool? v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilter, v));
    /// <inheritdoc cref="DocFXMetadataSettings.DisableDefaultFilter"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.DisableDefaultFilter))]
    public static T ResetDisableDefaultFilter<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.DisableDefaultFilter));
    /// <inheritdoc cref="DocFXMetadataSettings.DisableDefaultFilter"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.DisableDefaultFilter))]
    public static T EnableDisableDefaultFilter<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilter, true));
    /// <inheritdoc cref="DocFXMetadataSettings.DisableDefaultFilter"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.DisableDefaultFilter))]
    public static T DisableDisableDefaultFilter<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilter, false));
    /// <inheritdoc cref="DocFXMetadataSettings.DisableDefaultFilter"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.DisableDefaultFilter))]
    public static T ToggleDisableDefaultFilter<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.DisableDefaultFilter, !o.DisableDefaultFilter));
    #endregion
    #region DisableGitFeatures
    /// <inheritdoc cref="DocFXMetadataSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.DisableGitFeatures))]
    public static T SetDisableGitFeatures<T>(this T o, bool? v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, v));
    /// <inheritdoc cref="DocFXMetadataSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.DisableGitFeatures))]
    public static T ResetDisableGitFeatures<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.DisableGitFeatures));
    /// <inheritdoc cref="DocFXMetadataSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.DisableGitFeatures))]
    public static T EnableDisableGitFeatures<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, true));
    /// <inheritdoc cref="DocFXMetadataSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.DisableGitFeatures))]
    public static T DisableDisableGitFeatures<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, false));
    /// <inheritdoc cref="DocFXMetadataSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.DisableGitFeatures))]
    public static T ToggleDisableGitFeatures<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, !o.DisableGitFeatures));
    #endregion
    #region FilterConfigFile
    /// <inheritdoc cref="DocFXMetadataSettings.FilterConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.FilterConfigFile))]
    public static T SetFilterConfigFile<T>(this T o, string v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.FilterConfigFile, v));
    /// <inheritdoc cref="DocFXMetadataSettings.FilterConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.FilterConfigFile))]
    public static T ResetFilterConfigFile<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.FilterConfigFile));
    #endregion
    #region ForceRebuild
    /// <inheritdoc cref="DocFXMetadataSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.ForceRebuild))]
    public static T SetForceRebuild<T>(this T o, bool? v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.ForceRebuild, v));
    /// <inheritdoc cref="DocFXMetadataSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.ForceRebuild))]
    public static T ResetForceRebuild<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.ForceRebuild));
    /// <inheritdoc cref="DocFXMetadataSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.ForceRebuild))]
    public static T EnableForceRebuild<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.ForceRebuild, true));
    /// <inheritdoc cref="DocFXMetadataSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.ForceRebuild))]
    public static T DisableForceRebuild<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.ForceRebuild, false));
    /// <inheritdoc cref="DocFXMetadataSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.ForceRebuild))]
    public static T ToggleForceRebuild<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.ForceRebuild, !o.ForceRebuild));
    #endregion
    #region GlobalNamespaceId
    /// <inheritdoc cref="DocFXMetadataSettings.GlobalNamespaceId"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.GlobalNamespaceId))]
    public static T SetGlobalNamespaceId<T>(this T o, string v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.GlobalNamespaceId, v));
    /// <inheritdoc cref="DocFXMetadataSettings.GlobalNamespaceId"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.GlobalNamespaceId))]
    public static T ResetGlobalNamespaceId<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.GlobalNamespaceId));
    #endregion
    #region MSBuildProperties
    /// <inheritdoc cref="DocFXMetadataSettings.MSBuildProperties"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.MSBuildProperties))]
    public static T SetMSBuildProperties<T>(this T o, IDictionary<string, string> v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.MSBuildProperties, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="DocFXMetadataSettings.MSBuildProperties"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.MSBuildProperties))]
    public static T SetMSBuildProperty<T>(this T o, string k, string v) where T : DocFXMetadataSettings => o.Modify(b => b.SetDictionary(() => o.MSBuildProperties, k, v));
    /// <inheritdoc cref="DocFXMetadataSettings.MSBuildProperties"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.MSBuildProperties))]
    public static T AddMSBuildProperty<T>(this T o, string k, string v) where T : DocFXMetadataSettings => o.Modify(b => b.AddDictionary(() => o.MSBuildProperties, k, v));
    /// <inheritdoc cref="DocFXMetadataSettings.MSBuildProperties"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.MSBuildProperties))]
    public static T RemoveMSBuildProperty<T>(this T o, string k) where T : DocFXMetadataSettings => o.Modify(b => b.RemoveDictionary(() => o.MSBuildProperties, k));
    /// <inheritdoc cref="DocFXMetadataSettings.MSBuildProperties"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.MSBuildProperties))]
    public static T ClearMSBuildProperties<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.ClearDictionary(() => o.MSBuildProperties));
    #endregion
    #region OutputFolder
    /// <inheritdoc cref="DocFXMetadataSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.OutputFolder))]
    public static T SetOutputFolder<T>(this T o, string v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.OutputFolder, v));
    /// <inheritdoc cref="DocFXMetadataSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.OutputFolder))]
    public static T ResetOutputFolder<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.OutputFolder));
    #endregion
    #region PreserveRawInlineComments
    /// <inheritdoc cref="DocFXMetadataSettings.PreserveRawInlineComments"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.PreserveRawInlineComments))]
    public static T SetPreserveRawInlineComments<T>(this T o, bool? v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.PreserveRawInlineComments, v));
    /// <inheritdoc cref="DocFXMetadataSettings.PreserveRawInlineComments"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.PreserveRawInlineComments))]
    public static T ResetPreserveRawInlineComments<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.PreserveRawInlineComments));
    /// <inheritdoc cref="DocFXMetadataSettings.PreserveRawInlineComments"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.PreserveRawInlineComments))]
    public static T EnablePreserveRawInlineComments<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.PreserveRawInlineComments, true));
    /// <inheritdoc cref="DocFXMetadataSettings.PreserveRawInlineComments"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.PreserveRawInlineComments))]
    public static T DisablePreserveRawInlineComments<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.PreserveRawInlineComments, false));
    /// <inheritdoc cref="DocFXMetadataSettings.PreserveRawInlineComments"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.PreserveRawInlineComments))]
    public static T TogglePreserveRawInlineComments<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.PreserveRawInlineComments, !o.PreserveRawInlineComments));
    #endregion
    #region PrintHelpMessage
    /// <inheritdoc cref="DocFXMetadataSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.PrintHelpMessage))]
    public static T SetPrintHelpMessage<T>(this T o, bool? v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, v));
    /// <inheritdoc cref="DocFXMetadataSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.PrintHelpMessage))]
    public static T ResetPrintHelpMessage<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.PrintHelpMessage));
    /// <inheritdoc cref="DocFXMetadataSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.PrintHelpMessage))]
    public static T EnablePrintHelpMessage<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, true));
    /// <inheritdoc cref="DocFXMetadataSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.PrintHelpMessage))]
    public static T DisablePrintHelpMessage<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, false));
    /// <inheritdoc cref="DocFXMetadataSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.PrintHelpMessage))]
    public static T TogglePrintHelpMessage<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, !o.PrintHelpMessage));
    #endregion
    #region ShouldSkipMarkup
    /// <inheritdoc cref="DocFXMetadataSettings.ShouldSkipMarkup"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.ShouldSkipMarkup))]
    public static T SetShouldSkipMarkup<T>(this T o, bool? v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.ShouldSkipMarkup, v));
    /// <inheritdoc cref="DocFXMetadataSettings.ShouldSkipMarkup"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.ShouldSkipMarkup))]
    public static T ResetShouldSkipMarkup<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.ShouldSkipMarkup));
    /// <inheritdoc cref="DocFXMetadataSettings.ShouldSkipMarkup"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.ShouldSkipMarkup))]
    public static T EnableShouldSkipMarkup<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.ShouldSkipMarkup, true));
    /// <inheritdoc cref="DocFXMetadataSettings.ShouldSkipMarkup"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.ShouldSkipMarkup))]
    public static T DisableShouldSkipMarkup<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.ShouldSkipMarkup, false));
    /// <inheritdoc cref="DocFXMetadataSettings.ShouldSkipMarkup"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.ShouldSkipMarkup))]
    public static T ToggleShouldSkipMarkup<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.ShouldSkipMarkup, !o.ShouldSkipMarkup));
    #endregion
    #region CorrelationId
    /// <inheritdoc cref="DocFXMetadataSettings.CorrelationId"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.CorrelationId))]
    public static T SetCorrelationId<T>(this T o, string v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.CorrelationId, v));
    /// <inheritdoc cref="DocFXMetadataSettings.CorrelationId"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.CorrelationId))]
    public static T ResetCorrelationId<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.CorrelationId));
    #endregion
    #region LogFilePath
    /// <inheritdoc cref="DocFXMetadataSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.LogFilePath))]
    public static T SetLogFilePath<T>(this T o, string v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.LogFilePath, v));
    /// <inheritdoc cref="DocFXMetadataSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.LogFilePath))]
    public static T ResetLogFilePath<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.LogFilePath));
    #endregion
    #region LogLevel
    /// <inheritdoc cref="DocFXMetadataSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.LogLevel))]
    public static T SetLogLevel<T>(this T o, DocFXLogLevel v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.LogLevel, v));
    /// <inheritdoc cref="DocFXMetadataSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.LogLevel))]
    public static T ResetLogLevel<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.LogLevel));
    #endregion
    #region RepoRoot
    /// <inheritdoc cref="DocFXMetadataSettings.RepoRoot"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.RepoRoot))]
    public static T SetRepoRoot<T>(this T o, string v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.RepoRoot, v));
    /// <inheritdoc cref="DocFXMetadataSettings.RepoRoot"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.RepoRoot))]
    public static T ResetRepoRoot<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.RepoRoot));
    #endregion
    #region WarningsAsErrors
    /// <inheritdoc cref="DocFXMetadataSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.WarningsAsErrors))]
    public static T SetWarningsAsErrors<T>(this T o, bool? v) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, v));
    /// <inheritdoc cref="DocFXMetadataSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.WarningsAsErrors))]
    public static T ResetWarningsAsErrors<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Remove(() => o.WarningsAsErrors));
    /// <inheritdoc cref="DocFXMetadataSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.WarningsAsErrors))]
    public static T EnableWarningsAsErrors<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, true));
    /// <inheritdoc cref="DocFXMetadataSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.WarningsAsErrors))]
    public static T DisableWarningsAsErrors<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, false));
    /// <inheritdoc cref="DocFXMetadataSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXMetadataSettings), Property = nameof(DocFXMetadataSettings.WarningsAsErrors))]
    public static T ToggleWarningsAsErrors<T>(this T o) where T : DocFXMetadataSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, !o.WarningsAsErrors));
    #endregion
}
#endregion
#region DocFXPdfSettingsExtensions
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DocFXPdfSettingsExtensions
{
    #region BasePath
    /// <inheritdoc cref="DocFXPdfSettings.BasePath"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.BasePath))]
    public static T SetBasePath<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.BasePath, v));
    /// <inheritdoc cref="DocFXPdfSettings.BasePath"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.BasePath))]
    public static T ResetBasePath<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.BasePath));
    #endregion
    #region CssFilePath
    /// <inheritdoc cref="DocFXPdfSettings.CssFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.CssFilePath))]
    public static T SetCssFilePath<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.CssFilePath, v));
    /// <inheritdoc cref="DocFXPdfSettings.CssFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.CssFilePath))]
    public static T ResetCssFilePath<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.CssFilePath));
    #endregion
    #region ExcludedTocs
    /// <inheritdoc cref="DocFXPdfSettings.ExcludedTocs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExcludedTocs))]
    public static T SetExcludedTocs<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ExcludedTocs, v));
    /// <inheritdoc cref="DocFXPdfSettings.ExcludedTocs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExcludedTocs))]
    public static T SetExcludedTocs<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ExcludedTocs, v));
    /// <inheritdoc cref="DocFXPdfSettings.ExcludedTocs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExcludedTocs))]
    public static T AddExcludedTocs<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.ExcludedTocs, v));
    /// <inheritdoc cref="DocFXPdfSettings.ExcludedTocs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExcludedTocs))]
    public static T AddExcludedTocs<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.ExcludedTocs, v));
    /// <inheritdoc cref="DocFXPdfSettings.ExcludedTocs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExcludedTocs))]
    public static T RemoveExcludedTocs<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludedTocs, v));
    /// <inheritdoc cref="DocFXPdfSettings.ExcludedTocs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExcludedTocs))]
    public static T RemoveExcludedTocs<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludedTocs, v));
    /// <inheritdoc cref="DocFXPdfSettings.ExcludedTocs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExcludedTocs))]
    public static T ClearExcludedTocs<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.ClearCollection(() => o.ExcludedTocs));
    #endregion
    #region GeneratesAppendices
    /// <inheritdoc cref="DocFXPdfSettings.GeneratesAppendices"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GeneratesAppendices))]
    public static T SetGeneratesAppendices<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GeneratesAppendices, v));
    /// <inheritdoc cref="DocFXPdfSettings.GeneratesAppendices"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GeneratesAppendices))]
    public static T ResetGeneratesAppendices<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.GeneratesAppendices));
    /// <inheritdoc cref="DocFXPdfSettings.GeneratesAppendices"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GeneratesAppendices))]
    public static T EnableGeneratesAppendices<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GeneratesAppendices, true));
    /// <inheritdoc cref="DocFXPdfSettings.GeneratesAppendices"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GeneratesAppendices))]
    public static T DisableGeneratesAppendices<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GeneratesAppendices, false));
    /// <inheritdoc cref="DocFXPdfSettings.GeneratesAppendices"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GeneratesAppendices))]
    public static T ToggleGeneratesAppendices<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GeneratesAppendices, !o.GeneratesAppendices));
    #endregion
    #region GeneratesExternalLink
    /// <inheritdoc cref="DocFXPdfSettings.GeneratesExternalLink"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GeneratesExternalLink))]
    public static T SetGeneratesExternalLink<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GeneratesExternalLink, v));
    /// <inheritdoc cref="DocFXPdfSettings.GeneratesExternalLink"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GeneratesExternalLink))]
    public static T ResetGeneratesExternalLink<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.GeneratesExternalLink));
    /// <inheritdoc cref="DocFXPdfSettings.GeneratesExternalLink"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GeneratesExternalLink))]
    public static T EnableGeneratesExternalLink<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GeneratesExternalLink, true));
    /// <inheritdoc cref="DocFXPdfSettings.GeneratesExternalLink"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GeneratesExternalLink))]
    public static T DisableGeneratesExternalLink<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GeneratesExternalLink, false));
    /// <inheritdoc cref="DocFXPdfSettings.GeneratesExternalLink"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GeneratesExternalLink))]
    public static T ToggleGeneratesExternalLink<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GeneratesExternalLink, !o.GeneratesExternalLink));
    #endregion
    #region PdfHost
    /// <inheritdoc cref="DocFXPdfSettings.PdfHost"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PdfHost))]
    public static T SetPdfHost<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.PdfHost, v));
    /// <inheritdoc cref="DocFXPdfSettings.PdfHost"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PdfHost))]
    public static T ResetPdfHost<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.PdfHost));
    #endregion
    #region KeepRawFiles
    /// <inheritdoc cref="DocFXPdfSettings.KeepRawFiles"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.KeepRawFiles))]
    public static T SetKeepRawFiles<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.KeepRawFiles, v));
    /// <inheritdoc cref="DocFXPdfSettings.KeepRawFiles"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.KeepRawFiles))]
    public static T ResetKeepRawFiles<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.KeepRawFiles));
    /// <inheritdoc cref="DocFXPdfSettings.KeepRawFiles"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.KeepRawFiles))]
    public static T EnableKeepRawFiles<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.KeepRawFiles, true));
    /// <inheritdoc cref="DocFXPdfSettings.KeepRawFiles"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.KeepRawFiles))]
    public static T DisableKeepRawFiles<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.KeepRawFiles, false));
    /// <inheritdoc cref="DocFXPdfSettings.KeepRawFiles"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.KeepRawFiles))]
    public static T ToggleKeepRawFiles<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.KeepRawFiles, !o.KeepRawFiles));
    #endregion
    #region LoadErrorHandling
    /// <inheritdoc cref="DocFXPdfSettings.LoadErrorHandling"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.LoadErrorHandling))]
    public static T SetLoadErrorHandling<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.LoadErrorHandling, v));
    /// <inheritdoc cref="DocFXPdfSettings.LoadErrorHandling"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.LoadErrorHandling))]
    public static T ResetLoadErrorHandling<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.LoadErrorHandling));
    #endregion
    #region Locale
    /// <inheritdoc cref="DocFXPdfSettings.Locale"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Locale))]
    public static T SetLocale<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Locale, v));
    /// <inheritdoc cref="DocFXPdfSettings.Locale"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Locale))]
    public static T ResetLocale<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.Locale));
    #endregion
    #region Name
    /// <inheritdoc cref="DocFXPdfSettings.Name"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="DocFXPdfSettings.Name"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Name))]
    public static T ResetName<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region NoInputStreamArgs
    /// <inheritdoc cref="DocFXPdfSettings.NoInputStreamArgs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.NoInputStreamArgs))]
    public static T SetNoInputStreamArgs<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.NoInputStreamArgs, v));
    /// <inheritdoc cref="DocFXPdfSettings.NoInputStreamArgs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.NoInputStreamArgs))]
    public static T ResetNoInputStreamArgs<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.NoInputStreamArgs));
    /// <inheritdoc cref="DocFXPdfSettings.NoInputStreamArgs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.NoInputStreamArgs))]
    public static T EnableNoInputStreamArgs<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.NoInputStreamArgs, true));
    /// <inheritdoc cref="DocFXPdfSettings.NoInputStreamArgs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.NoInputStreamArgs))]
    public static T DisableNoInputStreamArgs<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.NoInputStreamArgs, false));
    /// <inheritdoc cref="DocFXPdfSettings.NoInputStreamArgs"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.NoInputStreamArgs))]
    public static T ToggleNoInputStreamArgs<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.NoInputStreamArgs, !o.NoInputStreamArgs));
    #endregion
    #region RawOutputFolder
    /// <inheritdoc cref="DocFXPdfSettings.RawOutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.RawOutputFolder))]
    public static T SetRawOutputFolder<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.RawOutputFolder, v));
    /// <inheritdoc cref="DocFXPdfSettings.RawOutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.RawOutputFolder))]
    public static T ResetRawOutputFolder<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.RawOutputFolder));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="DocFXPdfSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="DocFXPdfSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ChangesFile
    /// <inheritdoc cref="DocFXPdfSettings.ChangesFile"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ChangesFile))]
    public static T SetChangesFile<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ChangesFile, v));
    /// <inheritdoc cref="DocFXPdfSettings.ChangesFile"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ChangesFile))]
    public static T ResetChangesFile<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.ChangesFile));
    #endregion
    #region CleanupCacheHistory
    /// <inheritdoc cref="DocFXPdfSettings.CleanupCacheHistory"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.CleanupCacheHistory))]
    public static T SetCleanupCacheHistory<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.CleanupCacheHistory, v));
    /// <inheritdoc cref="DocFXPdfSettings.CleanupCacheHistory"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.CleanupCacheHistory))]
    public static T ResetCleanupCacheHistory<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.CleanupCacheHistory));
    /// <inheritdoc cref="DocFXPdfSettings.CleanupCacheHistory"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.CleanupCacheHistory))]
    public static T EnableCleanupCacheHistory<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.CleanupCacheHistory, true));
    /// <inheritdoc cref="DocFXPdfSettings.CleanupCacheHistory"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.CleanupCacheHistory))]
    public static T DisableCleanupCacheHistory<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.CleanupCacheHistory, false));
    /// <inheritdoc cref="DocFXPdfSettings.CleanupCacheHistory"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.CleanupCacheHistory))]
    public static T ToggleCleanupCacheHistory<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.CleanupCacheHistory, !o.CleanupCacheHistory));
    #endregion
    #region Content
    /// <inheritdoc cref="DocFXPdfSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Content))]
    public static T SetContent<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Content, v));
    /// <inheritdoc cref="DocFXPdfSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Content))]
    public static T SetContent<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Content, v));
    /// <inheritdoc cref="DocFXPdfSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Content))]
    public static T AddContent<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXPdfSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Content))]
    public static T AddContent<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXPdfSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Content))]
    public static T RemoveContent<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXPdfSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Content))]
    public static T RemoveContent<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.Content, v));
    /// <inheritdoc cref="DocFXPdfSettings.Content"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Content))]
    public static T ClearContent<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.ClearCollection(() => o.Content));
    #endregion
    #region DisableGitFeatures
    /// <inheritdoc cref="DocFXPdfSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.DisableGitFeatures))]
    public static T SetDisableGitFeatures<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, v));
    /// <inheritdoc cref="DocFXPdfSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.DisableGitFeatures))]
    public static T ResetDisableGitFeatures<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.DisableGitFeatures));
    /// <inheritdoc cref="DocFXPdfSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.DisableGitFeatures))]
    public static T EnableDisableGitFeatures<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, true));
    /// <inheritdoc cref="DocFXPdfSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.DisableGitFeatures))]
    public static T DisableDisableGitFeatures<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, false));
    /// <inheritdoc cref="DocFXPdfSettings.DisableGitFeatures"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.DisableGitFeatures))]
    public static T ToggleDisableGitFeatures<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.DisableGitFeatures, !o.DisableGitFeatures));
    #endregion
    #region DryRun
    /// <inheritdoc cref="DocFXPdfSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.DryRun))]
    public static T SetDryRun<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.DryRun, v));
    /// <inheritdoc cref="DocFXPdfSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.DryRun))]
    public static T ResetDryRun<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.DryRun));
    /// <inheritdoc cref="DocFXPdfSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.DryRun))]
    public static T EnableDryRun<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.DryRun, true));
    /// <inheritdoc cref="DocFXPdfSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.DryRun))]
    public static T DisableDryRun<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.DryRun, false));
    /// <inheritdoc cref="DocFXPdfSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.DryRun))]
    public static T ToggleDryRun<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.DryRun, !o.DryRun));
    #endregion
    #region EnableDebugMode
    /// <inheritdoc cref="DocFXPdfSettings.EnableDebugMode"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.EnableDebugMode))]
    public static T SetEnableDebugMode<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.EnableDebugMode, v));
    /// <inheritdoc cref="DocFXPdfSettings.EnableDebugMode"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.EnableDebugMode))]
    public static T ResetEnableDebugMode<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.EnableDebugMode));
    /// <inheritdoc cref="DocFXPdfSettings.EnableDebugMode"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.EnableDebugMode))]
    public static T EnableEnableDebugMode<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.EnableDebugMode, true));
    /// <inheritdoc cref="DocFXPdfSettings.EnableDebugMode"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.EnableDebugMode))]
    public static T DisableEnableDebugMode<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.EnableDebugMode, false));
    /// <inheritdoc cref="DocFXPdfSettings.EnableDebugMode"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.EnableDebugMode))]
    public static T ToggleEnableDebugMode<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.EnableDebugMode, !o.EnableDebugMode));
    #endregion
    #region ExportRawModel
    /// <inheritdoc cref="DocFXPdfSettings.ExportRawModel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExportRawModel))]
    public static T SetExportRawModel<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ExportRawModel, v));
    /// <inheritdoc cref="DocFXPdfSettings.ExportRawModel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExportRawModel))]
    public static T ResetExportRawModel<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.ExportRawModel));
    /// <inheritdoc cref="DocFXPdfSettings.ExportRawModel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExportRawModel))]
    public static T EnableExportRawModel<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ExportRawModel, true));
    /// <inheritdoc cref="DocFXPdfSettings.ExportRawModel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExportRawModel))]
    public static T DisableExportRawModel<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ExportRawModel, false));
    /// <inheritdoc cref="DocFXPdfSettings.ExportRawModel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExportRawModel))]
    public static T ToggleExportRawModel<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ExportRawModel, !o.ExportRawModel));
    #endregion
    #region ExportViewModel
    /// <inheritdoc cref="DocFXPdfSettings.ExportViewModel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExportViewModel))]
    public static T SetExportViewModel<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ExportViewModel, v));
    /// <inheritdoc cref="DocFXPdfSettings.ExportViewModel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExportViewModel))]
    public static T ResetExportViewModel<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.ExportViewModel));
    /// <inheritdoc cref="DocFXPdfSettings.ExportViewModel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExportViewModel))]
    public static T EnableExportViewModel<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ExportViewModel, true));
    /// <inheritdoc cref="DocFXPdfSettings.ExportViewModel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExportViewModel))]
    public static T DisableExportViewModel<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ExportViewModel, false));
    /// <inheritdoc cref="DocFXPdfSettings.ExportViewModel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ExportViewModel))]
    public static T ToggleExportViewModel<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ExportViewModel, !o.ExportViewModel));
    #endregion
    #region FALName
    /// <inheritdoc cref="DocFXPdfSettings.FALName"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FALName))]
    public static T SetFALName<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.FALName, v));
    /// <inheritdoc cref="DocFXPdfSettings.FALName"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FALName))]
    public static T ResetFALName<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.FALName));
    #endregion
    #region FileMetadataFilePath
    /// <inheritdoc cref="DocFXPdfSettings.FileMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FileMetadataFilePath))]
    public static T SetFileMetadataFilePath<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.FileMetadataFilePath, v));
    /// <inheritdoc cref="DocFXPdfSettings.FileMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FileMetadataFilePath))]
    public static T ResetFileMetadataFilePath<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.FileMetadataFilePath));
    #endregion
    #region FileMetadataFilePaths
    /// <inheritdoc cref="DocFXPdfSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FileMetadataFilePaths))]
    public static T SetFileMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FileMetadataFilePaths))]
    public static T SetFileMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FileMetadataFilePaths))]
    public static T AddFileMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FileMetadataFilePaths))]
    public static T AddFileMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FileMetadataFilePaths))]
    public static T RemoveFileMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FileMetadataFilePaths))]
    public static T RemoveFileMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.FileMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.FileMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.FileMetadataFilePaths))]
    public static T ClearFileMetadataFilePaths<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.ClearCollection(() => o.FileMetadataFilePaths));
    #endregion
    #region ForcePostProcess
    /// <inheritdoc cref="DocFXPdfSettings.ForcePostProcess"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ForcePostProcess))]
    public static T SetForcePostProcess<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ForcePostProcess, v));
    /// <inheritdoc cref="DocFXPdfSettings.ForcePostProcess"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ForcePostProcess))]
    public static T ResetForcePostProcess<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.ForcePostProcess));
    /// <inheritdoc cref="DocFXPdfSettings.ForcePostProcess"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ForcePostProcess))]
    public static T EnableForcePostProcess<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ForcePostProcess, true));
    /// <inheritdoc cref="DocFXPdfSettings.ForcePostProcess"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ForcePostProcess))]
    public static T DisableForcePostProcess<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ForcePostProcess, false));
    /// <inheritdoc cref="DocFXPdfSettings.ForcePostProcess"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ForcePostProcess))]
    public static T ToggleForcePostProcess<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ForcePostProcess, !o.ForcePostProcess));
    #endregion
    #region ForceRebuild
    /// <inheritdoc cref="DocFXPdfSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ForceRebuild))]
    public static T SetForceRebuild<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ForceRebuild, v));
    /// <inheritdoc cref="DocFXPdfSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ForceRebuild))]
    public static T ResetForceRebuild<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.ForceRebuild));
    /// <inheritdoc cref="DocFXPdfSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ForceRebuild))]
    public static T EnableForceRebuild<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ForceRebuild, true));
    /// <inheritdoc cref="DocFXPdfSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ForceRebuild))]
    public static T DisableForceRebuild<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ForceRebuild, false));
    /// <inheritdoc cref="DocFXPdfSettings.ForceRebuild"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ForceRebuild))]
    public static T ToggleForceRebuild<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ForceRebuild, !o.ForceRebuild));
    #endregion
    #region GlobalMetadata
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadata))]
    public static T SetGlobalMetadata<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GlobalMetadata, v));
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadata"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadata))]
    public static T ResetGlobalMetadata<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.GlobalMetadata));
    #endregion
    #region GlobalMetadataFilePath
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadataFilePath))]
    public static T SetGlobalMetadataFilePath<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GlobalMetadataFilePath, v));
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadataFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadataFilePath))]
    public static T ResetGlobalMetadataFilePath<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.GlobalMetadataFilePath));
    #endregion
    #region GlobalMetadataFilePaths
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadataFilePaths))]
    public static T SetGlobalMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadataFilePaths))]
    public static T SetGlobalMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadataFilePaths))]
    public static T AddGlobalMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadataFilePaths))]
    public static T AddGlobalMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadataFilePaths))]
    public static T RemoveGlobalMetadataFilePaths<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadataFilePaths))]
    public static T RemoveGlobalMetadataFilePaths<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.GlobalMetadataFilePaths, v));
    /// <inheritdoc cref="DocFXPdfSettings.GlobalMetadataFilePaths"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.GlobalMetadataFilePaths))]
    public static T ClearGlobalMetadataFilePaths<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.ClearCollection(() => o.GlobalMetadataFilePaths));
    #endregion
    #region Host
    /// <inheritdoc cref="DocFXPdfSettings.Host"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Host))]
    public static T SetHost<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Host, v));
    /// <inheritdoc cref="DocFXPdfSettings.Host"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Host))]
    public static T ResetHost<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.Host));
    #endregion
    #region IntermediateFolder
    /// <inheritdoc cref="DocFXPdfSettings.IntermediateFolder"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.IntermediateFolder))]
    public static T SetIntermediateFolder<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.IntermediateFolder, v));
    /// <inheritdoc cref="DocFXPdfSettings.IntermediateFolder"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.IntermediateFolder))]
    public static T ResetIntermediateFolder<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.IntermediateFolder));
    #endregion
    #region KeepFileLink
    /// <inheritdoc cref="DocFXPdfSettings.KeepFileLink"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.KeepFileLink))]
    public static T SetKeepFileLink<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.KeepFileLink, v));
    /// <inheritdoc cref="DocFXPdfSettings.KeepFileLink"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.KeepFileLink))]
    public static T ResetKeepFileLink<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.KeepFileLink));
    /// <inheritdoc cref="DocFXPdfSettings.KeepFileLink"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.KeepFileLink))]
    public static T EnableKeepFileLink<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.KeepFileLink, true));
    /// <inheritdoc cref="DocFXPdfSettings.KeepFileLink"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.KeepFileLink))]
    public static T DisableKeepFileLink<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.KeepFileLink, false));
    /// <inheritdoc cref="DocFXPdfSettings.KeepFileLink"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.KeepFileLink))]
    public static T ToggleKeepFileLink<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.KeepFileLink, !o.KeepFileLink));
    #endregion
    #region LruSize
    /// <inheritdoc cref="DocFXPdfSettings.LruSize"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.LruSize))]
    public static T SetLruSize<T>(this T o, int? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.LruSize, v));
    /// <inheritdoc cref="DocFXPdfSettings.LruSize"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.LruSize))]
    public static T ResetLruSize<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.LruSize));
    #endregion
    #region MarkdownEngineName
    /// <inheritdoc cref="DocFXPdfSettings.MarkdownEngineName"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.MarkdownEngineName))]
    public static T SetMarkdownEngineName<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.MarkdownEngineName, v));
    /// <inheritdoc cref="DocFXPdfSettings.MarkdownEngineName"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.MarkdownEngineName))]
    public static T ResetMarkdownEngineName<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.MarkdownEngineName));
    #endregion
    #region MarkdownEngineProperties
    /// <inheritdoc cref="DocFXPdfSettings.MarkdownEngineProperties"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.MarkdownEngineProperties))]
    public static T SetMarkdownEngineProperties<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.MarkdownEngineProperties, v));
    /// <inheritdoc cref="DocFXPdfSettings.MarkdownEngineProperties"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.MarkdownEngineProperties))]
    public static T ResetMarkdownEngineProperties<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.MarkdownEngineProperties));
    #endregion
    #region MaxParallelism
    /// <inheritdoc cref="DocFXPdfSettings.MaxParallelism"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.MaxParallelism))]
    public static T SetMaxParallelism<T>(this T o, int? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.MaxParallelism, v));
    /// <inheritdoc cref="DocFXPdfSettings.MaxParallelism"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.MaxParallelism))]
    public static T ResetMaxParallelism<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.MaxParallelism));
    #endregion
    #region NoLangKeyword
    /// <inheritdoc cref="DocFXPdfSettings.NoLangKeyword"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.NoLangKeyword))]
    public static T SetNoLangKeyword<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.NoLangKeyword, v));
    /// <inheritdoc cref="DocFXPdfSettings.NoLangKeyword"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.NoLangKeyword))]
    public static T ResetNoLangKeyword<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.NoLangKeyword));
    /// <inheritdoc cref="DocFXPdfSettings.NoLangKeyword"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.NoLangKeyword))]
    public static T EnableNoLangKeyword<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.NoLangKeyword, true));
    /// <inheritdoc cref="DocFXPdfSettings.NoLangKeyword"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.NoLangKeyword))]
    public static T DisableNoLangKeyword<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.NoLangKeyword, false));
    /// <inheritdoc cref="DocFXPdfSettings.NoLangKeyword"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.NoLangKeyword))]
    public static T ToggleNoLangKeyword<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.NoLangKeyword, !o.NoLangKeyword));
    #endregion
    #region OutputFolder
    /// <inheritdoc cref="DocFXPdfSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.OutputFolder))]
    public static T SetOutputFolder<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.OutputFolder, v));
    /// <inheritdoc cref="DocFXPdfSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.OutputFolder))]
    public static T ResetOutputFolder<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.OutputFolder));
    #endregion
    #region OutputFolderForDebugFiles
    /// <inheritdoc cref="DocFXPdfSettings.OutputFolderForDebugFiles"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.OutputFolderForDebugFiles))]
    public static T SetOutputFolderForDebugFiles<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.OutputFolderForDebugFiles, v));
    /// <inheritdoc cref="DocFXPdfSettings.OutputFolderForDebugFiles"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.OutputFolderForDebugFiles))]
    public static T ResetOutputFolderForDebugFiles<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.OutputFolderForDebugFiles));
    #endregion
    #region Overwrite
    /// <inheritdoc cref="DocFXPdfSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Overwrite))]
    public static T SetOverwrite<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXPdfSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Overwrite))]
    public static T SetOverwrite<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXPdfSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Overwrite))]
    public static T AddOverwrite<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXPdfSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Overwrite))]
    public static T AddOverwrite<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXPdfSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Overwrite))]
    public static T RemoveOverwrite<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXPdfSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Overwrite))]
    public static T RemoveOverwrite<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.Overwrite, v));
    /// <inheritdoc cref="DocFXPdfSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Overwrite))]
    public static T ClearOverwrite<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.ClearCollection(() => o.Overwrite));
    #endregion
    #region Port
    /// <inheritdoc cref="DocFXPdfSettings.Port"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Port))]
    public static T SetPort<T>(this T o, int? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Port, v));
    /// <inheritdoc cref="DocFXPdfSettings.Port"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Port))]
    public static T ResetPort<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.Port));
    #endregion
    #region PostProcessors
    /// <inheritdoc cref="DocFXPdfSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PostProcessors))]
    public static T SetPostProcessors<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXPdfSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PostProcessors))]
    public static T SetPostProcessors<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXPdfSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PostProcessors))]
    public static T AddPostProcessors<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXPdfSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PostProcessors))]
    public static T AddPostProcessors<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXPdfSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PostProcessors))]
    public static T RemovePostProcessors<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXPdfSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PostProcessors))]
    public static T RemovePostProcessors<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.PostProcessors, v));
    /// <inheritdoc cref="DocFXPdfSettings.PostProcessors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PostProcessors))]
    public static T ClearPostProcessors<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.ClearCollection(() => o.PostProcessors));
    #endregion
    #region PrintHelpMessage
    /// <inheritdoc cref="DocFXPdfSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PrintHelpMessage))]
    public static T SetPrintHelpMessage<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, v));
    /// <inheritdoc cref="DocFXPdfSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PrintHelpMessage))]
    public static T ResetPrintHelpMessage<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.PrintHelpMessage));
    /// <inheritdoc cref="DocFXPdfSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PrintHelpMessage))]
    public static T EnablePrintHelpMessage<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, true));
    /// <inheritdoc cref="DocFXPdfSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PrintHelpMessage))]
    public static T DisablePrintHelpMessage<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, false));
    /// <inheritdoc cref="DocFXPdfSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.PrintHelpMessage))]
    public static T TogglePrintHelpMessage<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, !o.PrintHelpMessage));
    #endregion
    #region RawModelOutputFolder
    /// <inheritdoc cref="DocFXPdfSettings.RawModelOutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.RawModelOutputFolder))]
    public static T SetRawModelOutputFolder<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.RawModelOutputFolder, v));
    /// <inheritdoc cref="DocFXPdfSettings.RawModelOutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.RawModelOutputFolder))]
    public static T ResetRawModelOutputFolder<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.RawModelOutputFolder));
    #endregion
    #region Resource
    /// <inheritdoc cref="DocFXPdfSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Resource))]
    public static T SetResource<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Resource, v));
    /// <inheritdoc cref="DocFXPdfSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Resource))]
    public static T SetResource<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Resource, v));
    /// <inheritdoc cref="DocFXPdfSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Resource))]
    public static T AddResource<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.Resource, v));
    /// <inheritdoc cref="DocFXPdfSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Resource))]
    public static T AddResource<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.Resource, v));
    /// <inheritdoc cref="DocFXPdfSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Resource))]
    public static T RemoveResource<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.Resource, v));
    /// <inheritdoc cref="DocFXPdfSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Resource))]
    public static T RemoveResource<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.Resource, v));
    /// <inheritdoc cref="DocFXPdfSettings.Resource"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Resource))]
    public static T ClearResource<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.ClearCollection(() => o.Resource));
    #endregion
    #region SchemaLicense
    /// <inheritdoc cref="DocFXPdfSettings.SchemaLicense"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.SchemaLicense))]
    public static T SetSchemaLicense<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.SchemaLicense, v));
    /// <inheritdoc cref="DocFXPdfSettings.SchemaLicense"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.SchemaLicense))]
    public static T ResetSchemaLicense<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.SchemaLicense));
    #endregion
    #region Serve
    /// <inheritdoc cref="DocFXPdfSettings.Serve"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Serve))]
    public static T SetServe<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Serve, v));
    /// <inheritdoc cref="DocFXPdfSettings.Serve"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Serve))]
    public static T ResetServe<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.Serve));
    /// <inheritdoc cref="DocFXPdfSettings.Serve"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Serve))]
    public static T EnableServe<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Serve, true));
    /// <inheritdoc cref="DocFXPdfSettings.Serve"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Serve))]
    public static T DisableServe<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Serve, false));
    /// <inheritdoc cref="DocFXPdfSettings.Serve"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Serve))]
    public static T ToggleServe<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Serve, !o.Serve));
    #endregion
    #region Templates
    /// <inheritdoc cref="DocFXPdfSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Templates))]
    public static T SetTemplates<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Templates, v));
    /// <inheritdoc cref="DocFXPdfSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Templates))]
    public static T SetTemplates<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Templates, v));
    /// <inheritdoc cref="DocFXPdfSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Templates))]
    public static T AddTemplates<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.Templates, v));
    /// <inheritdoc cref="DocFXPdfSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Templates))]
    public static T AddTemplates<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.Templates, v));
    /// <inheritdoc cref="DocFXPdfSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Templates))]
    public static T RemoveTemplates<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.Templates, v));
    /// <inheritdoc cref="DocFXPdfSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Templates))]
    public static T RemoveTemplates<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.Templates, v));
    /// <inheritdoc cref="DocFXPdfSettings.Templates"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Templates))]
    public static T ClearTemplates<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.ClearCollection(() => o.Templates));
    #endregion
    #region Themes
    /// <inheritdoc cref="DocFXPdfSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Themes))]
    public static T SetThemes<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Themes, v));
    /// <inheritdoc cref="DocFXPdfSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Themes))]
    public static T SetThemes<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.Themes, v));
    /// <inheritdoc cref="DocFXPdfSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Themes))]
    public static T AddThemes<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.Themes, v));
    /// <inheritdoc cref="DocFXPdfSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Themes))]
    public static T AddThemes<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.Themes, v));
    /// <inheritdoc cref="DocFXPdfSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Themes))]
    public static T RemoveThemes<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.Themes, v));
    /// <inheritdoc cref="DocFXPdfSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Themes))]
    public static T RemoveThemes<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.Themes, v));
    /// <inheritdoc cref="DocFXPdfSettings.Themes"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.Themes))]
    public static T ClearThemes<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.ClearCollection(() => o.Themes));
    #endregion
    #region ViewModelOutputFolder
    /// <inheritdoc cref="DocFXPdfSettings.ViewModelOutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ViewModelOutputFolder))]
    public static T SetViewModelOutputFolder<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.ViewModelOutputFolder, v));
    /// <inheritdoc cref="DocFXPdfSettings.ViewModelOutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.ViewModelOutputFolder))]
    public static T ResetViewModelOutputFolder<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.ViewModelOutputFolder));
    #endregion
    #region XRefMaps
    /// <inheritdoc cref="DocFXPdfSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.XRefMaps))]
    public static T SetXRefMaps<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXPdfSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.XRefMaps))]
    public static T SetXRefMaps<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXPdfSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.XRefMaps))]
    public static T AddXRefMaps<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXPdfSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.XRefMaps))]
    public static T AddXRefMaps<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.AddCollection(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXPdfSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.XRefMaps))]
    public static T RemoveXRefMaps<T>(this T o, params string[] v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXPdfSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.XRefMaps))]
    public static T RemoveXRefMaps<T>(this T o, IEnumerable<string> v) where T : DocFXPdfSettings => o.Modify(b => b.RemoveCollection(() => o.XRefMaps, v));
    /// <inheritdoc cref="DocFXPdfSettings.XRefMaps"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.XRefMaps))]
    public static T ClearXRefMaps<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.ClearCollection(() => o.XRefMaps));
    #endregion
    #region CorrelationId
    /// <inheritdoc cref="DocFXPdfSettings.CorrelationId"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.CorrelationId))]
    public static T SetCorrelationId<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.CorrelationId, v));
    /// <inheritdoc cref="DocFXPdfSettings.CorrelationId"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.CorrelationId))]
    public static T ResetCorrelationId<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.CorrelationId));
    #endregion
    #region LogFilePath
    /// <inheritdoc cref="DocFXPdfSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.LogFilePath))]
    public static T SetLogFilePath<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.LogFilePath, v));
    /// <inheritdoc cref="DocFXPdfSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.LogFilePath))]
    public static T ResetLogFilePath<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.LogFilePath));
    #endregion
    #region LogLevel
    /// <inheritdoc cref="DocFXPdfSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.LogLevel))]
    public static T SetLogLevel<T>(this T o, DocFXLogLevel v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.LogLevel, v));
    /// <inheritdoc cref="DocFXPdfSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.LogLevel))]
    public static T ResetLogLevel<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.LogLevel));
    #endregion
    #region RepoRoot
    /// <inheritdoc cref="DocFXPdfSettings.RepoRoot"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.RepoRoot))]
    public static T SetRepoRoot<T>(this T o, string v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.RepoRoot, v));
    /// <inheritdoc cref="DocFXPdfSettings.RepoRoot"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.RepoRoot))]
    public static T ResetRepoRoot<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.RepoRoot));
    #endregion
    #region WarningsAsErrors
    /// <inheritdoc cref="DocFXPdfSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.WarningsAsErrors))]
    public static T SetWarningsAsErrors<T>(this T o, bool? v) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, v));
    /// <inheritdoc cref="DocFXPdfSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.WarningsAsErrors))]
    public static T ResetWarningsAsErrors<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Remove(() => o.WarningsAsErrors));
    /// <inheritdoc cref="DocFXPdfSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.WarningsAsErrors))]
    public static T EnableWarningsAsErrors<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, true));
    /// <inheritdoc cref="DocFXPdfSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.WarningsAsErrors))]
    public static T DisableWarningsAsErrors<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, false));
    /// <inheritdoc cref="DocFXPdfSettings.WarningsAsErrors"/>
    [Pure] [Builder(Type = typeof(DocFXPdfSettings), Property = nameof(DocFXPdfSettings.WarningsAsErrors))]
    public static T ToggleWarningsAsErrors<T>(this T o) where T : DocFXPdfSettings => o.Modify(b => b.Set(() => o.WarningsAsErrors, !o.WarningsAsErrors));
    #endregion
}
#endregion
#region DocFXServeSettingsExtensions
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DocFXServeSettingsExtensions
{
    #region Folder
    /// <inheritdoc cref="DocFXServeSettings.Folder"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.Folder))]
    public static T SetFolder<T>(this T o, string v) where T : DocFXServeSettings => o.Modify(b => b.Set(() => o.Folder, v));
    /// <inheritdoc cref="DocFXServeSettings.Folder"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.Folder))]
    public static T ResetFolder<T>(this T o) where T : DocFXServeSettings => o.Modify(b => b.Remove(() => o.Folder));
    #endregion
    #region Host
    /// <inheritdoc cref="DocFXServeSettings.Host"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.Host))]
    public static T SetHost<T>(this T o, string v) where T : DocFXServeSettings => o.Modify(b => b.Set(() => o.Host, v));
    /// <inheritdoc cref="DocFXServeSettings.Host"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.Host))]
    public static T ResetHost<T>(this T o) where T : DocFXServeSettings => o.Modify(b => b.Remove(() => o.Host));
    #endregion
    #region Port
    /// <inheritdoc cref="DocFXServeSettings.Port"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.Port))]
    public static T SetPort<T>(this T o, int? v) where T : DocFXServeSettings => o.Modify(b => b.Set(() => o.Port, v));
    /// <inheritdoc cref="DocFXServeSettings.Port"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.Port))]
    public static T ResetPort<T>(this T o) where T : DocFXServeSettings => o.Modify(b => b.Remove(() => o.Port));
    #endregion
    #region PrintHelpMessage
    /// <inheritdoc cref="DocFXServeSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.PrintHelpMessage))]
    public static T SetPrintHelpMessage<T>(this T o, bool? v) where T : DocFXServeSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, v));
    /// <inheritdoc cref="DocFXServeSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.PrintHelpMessage))]
    public static T ResetPrintHelpMessage<T>(this T o) where T : DocFXServeSettings => o.Modify(b => b.Remove(() => o.PrintHelpMessage));
    /// <inheritdoc cref="DocFXServeSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.PrintHelpMessage))]
    public static T EnablePrintHelpMessage<T>(this T o) where T : DocFXServeSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, true));
    /// <inheritdoc cref="DocFXServeSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.PrintHelpMessage))]
    public static T DisablePrintHelpMessage<T>(this T o) where T : DocFXServeSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, false));
    /// <inheritdoc cref="DocFXServeSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXServeSettings), Property = nameof(DocFXServeSettings.PrintHelpMessage))]
    public static T TogglePrintHelpMessage<T>(this T o) where T : DocFXServeSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, !o.PrintHelpMessage));
    #endregion
}
#endregion
#region DocFXTemplateSettingsExtensions
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class DocFXTemplateSettingsExtensions
{
    #region Command
    /// <inheritdoc cref="DocFXTemplateSettings.Command"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.Command))]
    public static T SetCommand<T>(this T o, string v) where T : DocFXTemplateSettings => o.Modify(b => b.Set(() => o.Command, v));
    /// <inheritdoc cref="DocFXTemplateSettings.Command"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.Command))]
    public static T ResetCommand<T>(this T o) where T : DocFXTemplateSettings => o.Modify(b => b.Remove(() => o.Command));
    #endregion
    #region All
    /// <inheritdoc cref="DocFXTemplateSettings.All"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.All))]
    public static T SetAll<T>(this T o, bool? v) where T : DocFXTemplateSettings => o.Modify(b => b.Set(() => o.All, v));
    /// <inheritdoc cref="DocFXTemplateSettings.All"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.All))]
    public static T ResetAll<T>(this T o) where T : DocFXTemplateSettings => o.Modify(b => b.Remove(() => o.All));
    /// <inheritdoc cref="DocFXTemplateSettings.All"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.All))]
    public static T EnableAll<T>(this T o) where T : DocFXTemplateSettings => o.Modify(b => b.Set(() => o.All, true));
    /// <inheritdoc cref="DocFXTemplateSettings.All"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.All))]
    public static T DisableAll<T>(this T o) where T : DocFXTemplateSettings => o.Modify(b => b.Set(() => o.All, false));
    /// <inheritdoc cref="DocFXTemplateSettings.All"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.All))]
    public static T ToggleAll<T>(this T o) where T : DocFXTemplateSettings => o.Modify(b => b.Set(() => o.All, !o.All));
    #endregion
    #region OutputFolder
    /// <inheritdoc cref="DocFXTemplateSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.OutputFolder))]
    public static T SetOutputFolder<T>(this T o, string v) where T : DocFXTemplateSettings => o.Modify(b => b.Set(() => o.OutputFolder, v));
    /// <inheritdoc cref="DocFXTemplateSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.OutputFolder))]
    public static T ResetOutputFolder<T>(this T o) where T : DocFXTemplateSettings => o.Modify(b => b.Remove(() => o.OutputFolder));
    #endregion
    #region PrintHelpMessage
    /// <inheritdoc cref="DocFXTemplateSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.PrintHelpMessage))]
    public static T SetPrintHelpMessage<T>(this T o, bool? v) where T : DocFXTemplateSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, v));
    /// <inheritdoc cref="DocFXTemplateSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.PrintHelpMessage))]
    public static T ResetPrintHelpMessage<T>(this T o) where T : DocFXTemplateSettings => o.Modify(b => b.Remove(() => o.PrintHelpMessage));
    /// <inheritdoc cref="DocFXTemplateSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.PrintHelpMessage))]
    public static T EnablePrintHelpMessage<T>(this T o) where T : DocFXTemplateSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, true));
    /// <inheritdoc cref="DocFXTemplateSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.PrintHelpMessage))]
    public static T DisablePrintHelpMessage<T>(this T o) where T : DocFXTemplateSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, false));
    /// <inheritdoc cref="DocFXTemplateSettings.PrintHelpMessage"/>
    [Pure] [Builder(Type = typeof(DocFXTemplateSettings), Property = nameof(DocFXTemplateSettings.PrintHelpMessage))]
    public static T TogglePrintHelpMessage<T>(this T o) where T : DocFXTemplateSettings => o.Modify(b => b.Set(() => o.PrintHelpMessage, !o.PrintHelpMessage));
    #endregion
}
#endregion
#region DocFXLogLevel
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
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
    public static implicit operator DocFXLogLevel(string value)
    {
        return new DocFXLogLevel { Value = value };
    }
}
#endregion
#region DocFXTemplateCommand
/// <summary>Used within <see cref="DocFXTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DocFXTemplateCommand>))]
public partial class DocFXTemplateCommand : Enumeration
{
    public static DocFXTemplateCommand Export = (DocFXTemplateCommand) "Export";
    public static DocFXTemplateCommand List = (DocFXTemplateCommand) "List";
    public static implicit operator DocFXTemplateCommand(string value)
    {
        return new DocFXTemplateCommand { Value = value };
    }
}
#endregion
