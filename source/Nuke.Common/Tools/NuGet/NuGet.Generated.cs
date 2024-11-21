// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/NuGet/NuGet.json

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

namespace Nuke.Common.Tools.NuGet;

/// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class NuGetTasks : ToolTasks, IRequireNuGetPackage
{
    public static string NuGetPath => new NuGetTasks().GetToolPath();
    public const string PackageId = "NuGet.CommandLine";
    public const string PackageExecutable = "NuGet.exe";
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> NuGet(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new NuGetTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPushSettings.TargetPath"/></li><li><c>-ApiKey</c> via <see cref="NuGetPushSettings.ApiKey"/></li><li><c>-ConfigFile</c> via <see cref="NuGetPushSettings.ConfigFile"/></li><li><c>-DisableBuffering</c> via <see cref="NuGetPushSettings.DisableBuffering"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetPushSettings.ForceEnglishOutput"/></li><li><c>-NonInteractive</c> via <see cref="NuGetPushSettings.NonInteractive"/></li><li><c>-NoSymbols</c> via <see cref="NuGetPushSettings.NoSymbols"/></li><li><c>-Source</c> via <see cref="NuGetPushSettings.Source"/></li><li><c>-SymbolApiKey</c> via <see cref="NuGetPushSettings.SymbolApiKey"/></li><li><c>-SymbolSource</c> via <see cref="NuGetPushSettings.SymbolSource"/></li><li><c>-Timeout</c> via <see cref="NuGetPushSettings.Timeout"/></li><li><c>-Verbosity</c> via <see cref="NuGetPushSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetPush(NuGetPushSettings options = null) => new NuGetTasks().Run(options);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPushSettings.TargetPath"/></li><li><c>-ApiKey</c> via <see cref="NuGetPushSettings.ApiKey"/></li><li><c>-ConfigFile</c> via <see cref="NuGetPushSettings.ConfigFile"/></li><li><c>-DisableBuffering</c> via <see cref="NuGetPushSettings.DisableBuffering"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetPushSettings.ForceEnglishOutput"/></li><li><c>-NonInteractive</c> via <see cref="NuGetPushSettings.NonInteractive"/></li><li><c>-NoSymbols</c> via <see cref="NuGetPushSettings.NoSymbols"/></li><li><c>-Source</c> via <see cref="NuGetPushSettings.Source"/></li><li><c>-SymbolApiKey</c> via <see cref="NuGetPushSettings.SymbolApiKey"/></li><li><c>-SymbolSource</c> via <see cref="NuGetPushSettings.SymbolSource"/></li><li><c>-Timeout</c> via <see cref="NuGetPushSettings.Timeout"/></li><li><c>-Verbosity</c> via <see cref="NuGetPushSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetPush(Configure<NuGetPushSettings> configurator) => new NuGetTasks().Run(configurator.Invoke(new NuGetPushSettings()));
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPushSettings.TargetPath"/></li><li><c>-ApiKey</c> via <see cref="NuGetPushSettings.ApiKey"/></li><li><c>-ConfigFile</c> via <see cref="NuGetPushSettings.ConfigFile"/></li><li><c>-DisableBuffering</c> via <see cref="NuGetPushSettings.DisableBuffering"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetPushSettings.ForceEnglishOutput"/></li><li><c>-NonInteractive</c> via <see cref="NuGetPushSettings.NonInteractive"/></li><li><c>-NoSymbols</c> via <see cref="NuGetPushSettings.NoSymbols"/></li><li><c>-Source</c> via <see cref="NuGetPushSettings.Source"/></li><li><c>-SymbolApiKey</c> via <see cref="NuGetPushSettings.SymbolApiKey"/></li><li><c>-SymbolSource</c> via <see cref="NuGetPushSettings.SymbolSource"/></li><li><c>-Timeout</c> via <see cref="NuGetPushSettings.Timeout"/></li><li><c>-Verbosity</c> via <see cref="NuGetPushSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(NuGetPushSettings Settings, IReadOnlyCollection<Output> Output)> NuGetPush(CombinatorialConfigure<NuGetPushSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetPush, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPackSettings.TargetPath"/></li><li><c>-BasePath</c> via <see cref="NuGetPackSettings.BasePath"/></li><li><c>-Build</c> via <see cref="NuGetPackSettings.Build"/></li><li><c>-Exclude</c> via <see cref="NuGetPackSettings.Exclude"/></li><li><c>-ExcludeEmptyDirectories</c> via <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetPackSettings.ForceEnglishOutput"/></li><li><c>-IncludeReferencedProjects</c> via <see cref="NuGetPackSettings.IncludeReferencedProjects"/></li><li><c>-MinClientVersion</c> via <see cref="NuGetPackSettings.MinClientVersion"/></li><li><c>-MSBuildPath</c> via <see cref="NuGetPackSettings.MSBuildPath"/></li><li><c>-MSBuildVersion</c> via <see cref="NuGetPackSettings.MSBuildVersion"/></li><li><c>-NoDefaultExcludes</c> via <see cref="NuGetPackSettings.NoDefaultExcludes"/></li><li><c>-NoPackageAnalysis</c> via <see cref="NuGetPackSettings.NoPackageAnalysis"/></li><li><c>-OutputDirectory</c> via <see cref="NuGetPackSettings.OutputDirectory"/></li><li><c>-Properties</c> via <see cref="NuGetPackSettings.Properties"/></li><li><c>-Suffix</c> via <see cref="NuGetPackSettings.Suffix"/></li><li><c>-SymbolPackageFormat</c> via <see cref="NuGetPackSettings.SymbolPackageFormat"/></li><li><c>-Symbols</c> via <see cref="NuGetPackSettings.Symbols"/></li><li><c>-Tool</c> via <see cref="NuGetPackSettings.Tool"/></li><li><c>-Verbosity</c> via <see cref="NuGetPackSettings.Verbosity"/></li><li><c>-Version</c> via <see cref="NuGetPackSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetPack(NuGetPackSettings options = null) => new NuGetTasks().Run(options);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPackSettings.TargetPath"/></li><li><c>-BasePath</c> via <see cref="NuGetPackSettings.BasePath"/></li><li><c>-Build</c> via <see cref="NuGetPackSettings.Build"/></li><li><c>-Exclude</c> via <see cref="NuGetPackSettings.Exclude"/></li><li><c>-ExcludeEmptyDirectories</c> via <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetPackSettings.ForceEnglishOutput"/></li><li><c>-IncludeReferencedProjects</c> via <see cref="NuGetPackSettings.IncludeReferencedProjects"/></li><li><c>-MinClientVersion</c> via <see cref="NuGetPackSettings.MinClientVersion"/></li><li><c>-MSBuildPath</c> via <see cref="NuGetPackSettings.MSBuildPath"/></li><li><c>-MSBuildVersion</c> via <see cref="NuGetPackSettings.MSBuildVersion"/></li><li><c>-NoDefaultExcludes</c> via <see cref="NuGetPackSettings.NoDefaultExcludes"/></li><li><c>-NoPackageAnalysis</c> via <see cref="NuGetPackSettings.NoPackageAnalysis"/></li><li><c>-OutputDirectory</c> via <see cref="NuGetPackSettings.OutputDirectory"/></li><li><c>-Properties</c> via <see cref="NuGetPackSettings.Properties"/></li><li><c>-Suffix</c> via <see cref="NuGetPackSettings.Suffix"/></li><li><c>-SymbolPackageFormat</c> via <see cref="NuGetPackSettings.SymbolPackageFormat"/></li><li><c>-Symbols</c> via <see cref="NuGetPackSettings.Symbols"/></li><li><c>-Tool</c> via <see cref="NuGetPackSettings.Tool"/></li><li><c>-Verbosity</c> via <see cref="NuGetPackSettings.Verbosity"/></li><li><c>-Version</c> via <see cref="NuGetPackSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetPack(Configure<NuGetPackSettings> configurator) => new NuGetTasks().Run(configurator.Invoke(new NuGetPackSettings()));
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPackSettings.TargetPath"/></li><li><c>-BasePath</c> via <see cref="NuGetPackSettings.BasePath"/></li><li><c>-Build</c> via <see cref="NuGetPackSettings.Build"/></li><li><c>-Exclude</c> via <see cref="NuGetPackSettings.Exclude"/></li><li><c>-ExcludeEmptyDirectories</c> via <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetPackSettings.ForceEnglishOutput"/></li><li><c>-IncludeReferencedProjects</c> via <see cref="NuGetPackSettings.IncludeReferencedProjects"/></li><li><c>-MinClientVersion</c> via <see cref="NuGetPackSettings.MinClientVersion"/></li><li><c>-MSBuildPath</c> via <see cref="NuGetPackSettings.MSBuildPath"/></li><li><c>-MSBuildVersion</c> via <see cref="NuGetPackSettings.MSBuildVersion"/></li><li><c>-NoDefaultExcludes</c> via <see cref="NuGetPackSettings.NoDefaultExcludes"/></li><li><c>-NoPackageAnalysis</c> via <see cref="NuGetPackSettings.NoPackageAnalysis"/></li><li><c>-OutputDirectory</c> via <see cref="NuGetPackSettings.OutputDirectory"/></li><li><c>-Properties</c> via <see cref="NuGetPackSettings.Properties"/></li><li><c>-Suffix</c> via <see cref="NuGetPackSettings.Suffix"/></li><li><c>-SymbolPackageFormat</c> via <see cref="NuGetPackSettings.SymbolPackageFormat"/></li><li><c>-Symbols</c> via <see cref="NuGetPackSettings.Symbols"/></li><li><c>-Tool</c> via <see cref="NuGetPackSettings.Tool"/></li><li><c>-Verbosity</c> via <see cref="NuGetPackSettings.Verbosity"/></li><li><c>-Version</c> via <see cref="NuGetPackSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(NuGetPackSettings Settings, IReadOnlyCollection<Output> Output)> NuGetPack(CombinatorialConfigure<NuGetPackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetPack, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="NuGetRestoreSettings.TargetPath"/></li><li><c>-ConfigFile</c> via <see cref="NuGetRestoreSettings.ConfigFile"/></li><li><c>-DirectDownload</c> via <see cref="NuGetRestoreSettings.DirectDownload"/></li><li><c>-DisableParallelProcessing</c> via <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></li><li><c>-FallbackSource</c> via <see cref="NuGetRestoreSettings.FallbackSource"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></li><li><c>-MSBuildPath</c> via <see cref="NuGetRestoreSettings.MSBuildPath"/></li><li><c>-MSBuildVersion</c> via <see cref="NuGetRestoreSettings.MSBuildVersion"/></li><li><c>-NoCache</c> via <see cref="NuGetRestoreSettings.NoCache"/></li><li><c>-NonInteractive</c> via <see cref="NuGetRestoreSettings.NonInteractive"/></li><li><c>-OutputDirectory</c> via <see cref="NuGetRestoreSettings.OutputDirectory"/></li><li><c>-PackageSaveMode</c> via <see cref="NuGetRestoreSettings.PackageSaveMode"/></li><li><c>-PackagesDirectory</c> via <see cref="NuGetRestoreSettings.PackagesDirectory"/></li><li><c>-Project2ProjectTimeOut</c> via <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/></li><li><c>-Recursive</c> via <see cref="NuGetRestoreSettings.Recursive"/></li><li><c>-RequireConsent</c> via <see cref="NuGetRestoreSettings.RequireConsent"/></li><li><c>-SolutionDirectory</c> via <see cref="NuGetRestoreSettings.SolutionDirectory"/></li><li><c>-Source</c> via <see cref="NuGetRestoreSettings.Source"/></li><li><c>-Verbosity</c> via <see cref="NuGetRestoreSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetRestore(NuGetRestoreSettings options = null) => new NuGetTasks().Run(options);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="NuGetRestoreSettings.TargetPath"/></li><li><c>-ConfigFile</c> via <see cref="NuGetRestoreSettings.ConfigFile"/></li><li><c>-DirectDownload</c> via <see cref="NuGetRestoreSettings.DirectDownload"/></li><li><c>-DisableParallelProcessing</c> via <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></li><li><c>-FallbackSource</c> via <see cref="NuGetRestoreSettings.FallbackSource"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></li><li><c>-MSBuildPath</c> via <see cref="NuGetRestoreSettings.MSBuildPath"/></li><li><c>-MSBuildVersion</c> via <see cref="NuGetRestoreSettings.MSBuildVersion"/></li><li><c>-NoCache</c> via <see cref="NuGetRestoreSettings.NoCache"/></li><li><c>-NonInteractive</c> via <see cref="NuGetRestoreSettings.NonInteractive"/></li><li><c>-OutputDirectory</c> via <see cref="NuGetRestoreSettings.OutputDirectory"/></li><li><c>-PackageSaveMode</c> via <see cref="NuGetRestoreSettings.PackageSaveMode"/></li><li><c>-PackagesDirectory</c> via <see cref="NuGetRestoreSettings.PackagesDirectory"/></li><li><c>-Project2ProjectTimeOut</c> via <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/></li><li><c>-Recursive</c> via <see cref="NuGetRestoreSettings.Recursive"/></li><li><c>-RequireConsent</c> via <see cref="NuGetRestoreSettings.RequireConsent"/></li><li><c>-SolutionDirectory</c> via <see cref="NuGetRestoreSettings.SolutionDirectory"/></li><li><c>-Source</c> via <see cref="NuGetRestoreSettings.Source"/></li><li><c>-Verbosity</c> via <see cref="NuGetRestoreSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetRestore(Configure<NuGetRestoreSettings> configurator) => new NuGetTasks().Run(configurator.Invoke(new NuGetRestoreSettings()));
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="NuGetRestoreSettings.TargetPath"/></li><li><c>-ConfigFile</c> via <see cref="NuGetRestoreSettings.ConfigFile"/></li><li><c>-DirectDownload</c> via <see cref="NuGetRestoreSettings.DirectDownload"/></li><li><c>-DisableParallelProcessing</c> via <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></li><li><c>-FallbackSource</c> via <see cref="NuGetRestoreSettings.FallbackSource"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></li><li><c>-MSBuildPath</c> via <see cref="NuGetRestoreSettings.MSBuildPath"/></li><li><c>-MSBuildVersion</c> via <see cref="NuGetRestoreSettings.MSBuildVersion"/></li><li><c>-NoCache</c> via <see cref="NuGetRestoreSettings.NoCache"/></li><li><c>-NonInteractive</c> via <see cref="NuGetRestoreSettings.NonInteractive"/></li><li><c>-OutputDirectory</c> via <see cref="NuGetRestoreSettings.OutputDirectory"/></li><li><c>-PackageSaveMode</c> via <see cref="NuGetRestoreSettings.PackageSaveMode"/></li><li><c>-PackagesDirectory</c> via <see cref="NuGetRestoreSettings.PackagesDirectory"/></li><li><c>-Project2ProjectTimeOut</c> via <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/></li><li><c>-Recursive</c> via <see cref="NuGetRestoreSettings.Recursive"/></li><li><c>-RequireConsent</c> via <see cref="NuGetRestoreSettings.RequireConsent"/></li><li><c>-SolutionDirectory</c> via <see cref="NuGetRestoreSettings.SolutionDirectory"/></li><li><c>-Source</c> via <see cref="NuGetRestoreSettings.Source"/></li><li><c>-Verbosity</c> via <see cref="NuGetRestoreSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(NuGetRestoreSettings Settings, IReadOnlyCollection<Output> Output)> NuGetRestore(CombinatorialConfigure<NuGetRestoreSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetRestore, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;packageID&gt;</c> via <see cref="NuGetInstallSettings.PackageID"/></li><li><c>-ConfigFile</c> via <see cref="NuGetInstallSettings.ConfigFile"/></li><li><c>-DependencyVersion</c> via <see cref="NuGetInstallSettings.DependencyVersion"/></li><li><c>-DisableParallelProcessing</c> via <see cref="NuGetInstallSettings.DisableParallelProcessing"/></li><li><c>-ExcludeVersion</c> via <see cref="NuGetInstallSettings.ExcludeVersion"/></li><li><c>-FallbackSource</c> via <see cref="NuGetInstallSettings.FallbackSource"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetInstallSettings.ForceEnglishOutput"/></li><li><c>-Framework</c> via <see cref="NuGetInstallSettings.Framework"/></li><li><c>-NoCache</c> via <see cref="NuGetInstallSettings.NoCache"/></li><li><c>-NonInteractive</c> via <see cref="NuGetInstallSettings.NonInteractive"/></li><li><c>-OutputDirectory</c> via <see cref="NuGetInstallSettings.OutputDirectory"/></li><li><c>-PackageSaveMode</c> via <see cref="NuGetInstallSettings.PackageSaveMode"/></li><li><c>-PreRelease</c> via <see cref="NuGetInstallSettings.PreRelease"/></li><li><c>-RequireConsent</c> via <see cref="NuGetInstallSettings.RequireConsent"/></li><li><c>-SolutionDirectory</c> via <see cref="NuGetInstallSettings.SolutionDirectory"/></li><li><c>-Source</c> via <see cref="NuGetInstallSettings.Source"/></li><li><c>-Verbosity</c> via <see cref="NuGetInstallSettings.Verbosity"/></li><li><c>-Version</c> via <see cref="NuGetInstallSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetInstall(NuGetInstallSettings options = null) => new NuGetTasks().Run(options);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;packageID&gt;</c> via <see cref="NuGetInstallSettings.PackageID"/></li><li><c>-ConfigFile</c> via <see cref="NuGetInstallSettings.ConfigFile"/></li><li><c>-DependencyVersion</c> via <see cref="NuGetInstallSettings.DependencyVersion"/></li><li><c>-DisableParallelProcessing</c> via <see cref="NuGetInstallSettings.DisableParallelProcessing"/></li><li><c>-ExcludeVersion</c> via <see cref="NuGetInstallSettings.ExcludeVersion"/></li><li><c>-FallbackSource</c> via <see cref="NuGetInstallSettings.FallbackSource"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetInstallSettings.ForceEnglishOutput"/></li><li><c>-Framework</c> via <see cref="NuGetInstallSettings.Framework"/></li><li><c>-NoCache</c> via <see cref="NuGetInstallSettings.NoCache"/></li><li><c>-NonInteractive</c> via <see cref="NuGetInstallSettings.NonInteractive"/></li><li><c>-OutputDirectory</c> via <see cref="NuGetInstallSettings.OutputDirectory"/></li><li><c>-PackageSaveMode</c> via <see cref="NuGetInstallSettings.PackageSaveMode"/></li><li><c>-PreRelease</c> via <see cref="NuGetInstallSettings.PreRelease"/></li><li><c>-RequireConsent</c> via <see cref="NuGetInstallSettings.RequireConsent"/></li><li><c>-SolutionDirectory</c> via <see cref="NuGetInstallSettings.SolutionDirectory"/></li><li><c>-Source</c> via <see cref="NuGetInstallSettings.Source"/></li><li><c>-Verbosity</c> via <see cref="NuGetInstallSettings.Verbosity"/></li><li><c>-Version</c> via <see cref="NuGetInstallSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetInstall(Configure<NuGetInstallSettings> configurator) => new NuGetTasks().Run(configurator.Invoke(new NuGetInstallSettings()));
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;packageID&gt;</c> via <see cref="NuGetInstallSettings.PackageID"/></li><li><c>-ConfigFile</c> via <see cref="NuGetInstallSettings.ConfigFile"/></li><li><c>-DependencyVersion</c> via <see cref="NuGetInstallSettings.DependencyVersion"/></li><li><c>-DisableParallelProcessing</c> via <see cref="NuGetInstallSettings.DisableParallelProcessing"/></li><li><c>-ExcludeVersion</c> via <see cref="NuGetInstallSettings.ExcludeVersion"/></li><li><c>-FallbackSource</c> via <see cref="NuGetInstallSettings.FallbackSource"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetInstallSettings.ForceEnglishOutput"/></li><li><c>-Framework</c> via <see cref="NuGetInstallSettings.Framework"/></li><li><c>-NoCache</c> via <see cref="NuGetInstallSettings.NoCache"/></li><li><c>-NonInteractive</c> via <see cref="NuGetInstallSettings.NonInteractive"/></li><li><c>-OutputDirectory</c> via <see cref="NuGetInstallSettings.OutputDirectory"/></li><li><c>-PackageSaveMode</c> via <see cref="NuGetInstallSettings.PackageSaveMode"/></li><li><c>-PreRelease</c> via <see cref="NuGetInstallSettings.PreRelease"/></li><li><c>-RequireConsent</c> via <see cref="NuGetInstallSettings.RequireConsent"/></li><li><c>-SolutionDirectory</c> via <see cref="NuGetInstallSettings.SolutionDirectory"/></li><li><c>-Source</c> via <see cref="NuGetInstallSettings.Source"/></li><li><c>-Verbosity</c> via <see cref="NuGetInstallSettings.Verbosity"/></li><li><c>-Version</c> via <see cref="NuGetInstallSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(NuGetInstallSettings Settings, IReadOnlyCollection<Output> Output)> NuGetInstall(CombinatorialConfigure<NuGetInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetInstall, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesAddSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesAddSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesAddSettings.NonInteractive"/></li><li><c>-Password</c> via <see cref="NuGetSourcesAddSettings.Password"/></li><li><c>-Source</c> via <see cref="NuGetSourcesAddSettings.Source"/></li><li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></li><li><c>-UserName</c> via <see cref="NuGetSourcesAddSettings.UserName"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesAddSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesAdd(NuGetSourcesAddSettings options = null) => new NuGetTasks().Run(options);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesAddSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesAddSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesAddSettings.NonInteractive"/></li><li><c>-Password</c> via <see cref="NuGetSourcesAddSettings.Password"/></li><li><c>-Source</c> via <see cref="NuGetSourcesAddSettings.Source"/></li><li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></li><li><c>-UserName</c> via <see cref="NuGetSourcesAddSettings.UserName"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesAddSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesAdd(Configure<NuGetSourcesAddSettings> configurator) => new NuGetTasks().Run(configurator.Invoke(new NuGetSourcesAddSettings()));
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesAddSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesAddSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesAddSettings.NonInteractive"/></li><li><c>-Password</c> via <see cref="NuGetSourcesAddSettings.Password"/></li><li><c>-Source</c> via <see cref="NuGetSourcesAddSettings.Source"/></li><li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></li><li><c>-UserName</c> via <see cref="NuGetSourcesAddSettings.UserName"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesAddSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(NuGetSourcesAddSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesAdd(CombinatorialConfigure<NuGetSourcesAddSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetSourcesAdd, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesUpdateSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesUpdateSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></li><li><c>-Password</c> via <see cref="NuGetSourcesUpdateSettings.Password"/></li><li><c>-Source</c> via <see cref="NuGetSourcesUpdateSettings.Source"/></li><li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></li><li><c>-UserName</c> via <see cref="NuGetSourcesUpdateSettings.UserName"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesUpdateSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesUpdate(NuGetSourcesUpdateSettings options = null) => new NuGetTasks().Run(options);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesUpdateSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesUpdateSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></li><li><c>-Password</c> via <see cref="NuGetSourcesUpdateSettings.Password"/></li><li><c>-Source</c> via <see cref="NuGetSourcesUpdateSettings.Source"/></li><li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></li><li><c>-UserName</c> via <see cref="NuGetSourcesUpdateSettings.UserName"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesUpdateSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesUpdate(Configure<NuGetSourcesUpdateSettings> configurator) => new NuGetTasks().Run(configurator.Invoke(new NuGetSourcesUpdateSettings()));
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesUpdateSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesUpdateSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></li><li><c>-Password</c> via <see cref="NuGetSourcesUpdateSettings.Password"/></li><li><c>-Source</c> via <see cref="NuGetSourcesUpdateSettings.Source"/></li><li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></li><li><c>-UserName</c> via <see cref="NuGetSourcesUpdateSettings.UserName"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesUpdateSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(NuGetSourcesUpdateSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesUpdate(CombinatorialConfigure<NuGetSourcesUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetSourcesUpdate, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesRemoveSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesRemoveSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesRemoveSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesRemove(NuGetSourcesRemoveSettings options = null) => new NuGetTasks().Run(options);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesRemoveSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesRemoveSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesRemoveSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesRemove(Configure<NuGetSourcesRemoveSettings> configurator) => new NuGetTasks().Run(configurator.Invoke(new NuGetSourcesRemoveSettings()));
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesRemoveSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesRemoveSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesRemoveSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(NuGetSourcesRemoveSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesRemove(CombinatorialConfigure<NuGetSourcesRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetSourcesRemove, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesEnableSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesEnableSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesEnableSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesEnableSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesEnable(NuGetSourcesEnableSettings options = null) => new NuGetTasks().Run(options);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesEnableSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesEnableSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesEnableSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesEnableSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesEnable(Configure<NuGetSourcesEnableSettings> configurator) => new NuGetTasks().Run(configurator.Invoke(new NuGetSourcesEnableSettings()));
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesEnableSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesEnableSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesEnableSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesEnableSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(NuGetSourcesEnableSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesEnable(CombinatorialConfigure<NuGetSourcesEnableSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetSourcesEnable, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesDisableSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesDisableSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesDisableSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesDisableSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesDisable(NuGetSourcesDisableSettings options = null) => new NuGetTasks().Run(options);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesDisableSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesDisableSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesDisableSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesDisableSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesDisable(Configure<NuGetSourcesDisableSettings> configurator) => new NuGetTasks().Run(configurator.Invoke(new NuGetSourcesDisableSettings()));
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesDisableSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></li><li><c>-Name</c> via <see cref="NuGetSourcesDisableSettings.Name"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesDisableSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesDisableSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(NuGetSourcesDisableSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesDisable(CombinatorialConfigure<NuGetSourcesDisableSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetSourcesDisable, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesListSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></li><li><c>-Format</c> via <see cref="NuGetSourcesListSettings.Format"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesListSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesListSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesList(NuGetSourcesListSettings options = null) => new NuGetTasks().Run(options);
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesListSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></li><li><c>-Format</c> via <see cref="NuGetSourcesListSettings.Format"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesListSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesListSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NuGetSourcesList(Configure<NuGetSourcesListSettings> configurator) => new NuGetTasks().Run(configurator.Invoke(new NuGetSourcesListSettings()));
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-ConfigFile</c> via <see cref="NuGetSourcesListSettings.ConfigFile"/></li><li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></li><li><c>-Format</c> via <see cref="NuGetSourcesListSettings.Format"/></li><li><c>-NonInteractive</c> via <see cref="NuGetSourcesListSettings.NonInteractive"/></li><li><c>-Verbosity</c> via <see cref="NuGetSourcesListSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(NuGetSourcesListSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesList(CombinatorialConfigure<NuGetSourcesListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NuGetSourcesList, degreeOfParallelism, completeOnFailure);
}
#region NuGetPushSettings
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetPushSettings>))]
[Command(Type = typeof(NuGetTasks), Command = nameof(NuGetTasks.NuGetPush), Arguments = "push")]
public partial class NuGetPushSettings : ToolOptions
{
    /// <summary>Path of the package to push.</summary>
    [Argument(Format = "{value}", Position = 1)] public string TargetPath => Get<string>(() => TargetPath);
    /// <summary>The API key for the target repository. If not present, the one specified in <em>%AppData%\NuGet\NuGet.Config</em> is used.</summary>
    [Argument(Format = "-ApiKey {value}", Secret = true)] public string ApiKey => Get<string>(() => ApiKey);
    /// <summary>Specifies the server URL. NuGet identifies a UNC or local folder source and simply copies the file there instead of pushing it using HTTP.  Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <em>NuGet.Config</em> file specifies a <em>DefaultPushSource</em> value (see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>).</summary>
    [Argument(Format = "-Source {value}")] public string Source => Get<string>(() => Source);
    /// <summary><em>(3.5+)</em> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</summary>
    [Argument(Format = "-SymbolSource {value}")] public string SymbolSource => Get<string>(() => SymbolSource);
    /// <summary><em>(3.5+)</em> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</summary>
    [Argument(Format = "-SymbolApiKey {value}", Secret = true)] public string SymbolApiKey => Get<string>(() => SymbolApiKey);
    /// <summary><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</summary>
    [Argument(Format = "-NoSymbols")] public bool? NoSymbols => Get<bool?>(() => NoSymbols);
    /// <summary>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</summary>
    [Argument(Format = "-DisableBuffering")] public bool? DisableBuffering => Get<bool?>(() => DisableBuffering);
    /// <summary>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</summary>
    [Argument(Format = "-ConfigFile {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</summary>
    [Argument(Format = "-Verbosity {value}")] public NuGetVerbosity Verbosity => Get<NuGetVerbosity>(() => Verbosity);
    /// <summary><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</summary>
    [Argument(Format = "-ForceEnglishOutput")] public bool? ForceEnglishOutput => Get<bool?>(() => ForceEnglishOutput);
    /// <summary>Suppresses prompts for user input or confirmations.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</summary>
    [Argument(Format = "-Timeout {value}")] public int? Timeout => Get<int?>(() => Timeout);
}
#endregion
#region NuGetPackSettings
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetPackSettings>))]
[Command(Type = typeof(NuGetTasks), Command = nameof(NuGetTasks.NuGetPack), Arguments = "pack")]
public partial class NuGetPackSettings : ToolOptions
{
    /// <summary>The <c>.nuspec</c> or <c>.csproj</c> file.</summary>
    [Argument(Format = "{value}", Position = 1)] public string TargetPath => Get<string>(() => TargetPath);
    /// <summary>Sets the base path of the files defined in the <c>.nuspec</c> file.</summary>
    [Argument(Format = "-BasePath {value}")] public string BasePath => Get<string>(() => BasePath);
    /// <summary>Specifies that the project should be built before building the package.</summary>
    [Argument(Format = "-Build")] public bool? Build => Get<bool?>(() => Build);
    /// <summary>Specifies one or more wildcard patterns to exclude when creating a package. To specify more than one pattern, repeat the <c>-Exclude</c> flag.</summary>
    [Argument(Format = "-Exclude {value}")] public string Exclude => Get<string>(() => Exclude);
    /// <summary>Prevent inclusion of empty directories when building the package.</summary>
    [Argument(Format = "-ExcludeEmptyDirectories")] public bool? ExcludeEmptyDirectories => Get<bool?>(() => ExcludeEmptyDirectories);
    /// <summary>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</summary>
    [Argument(Format = "-IncludeReferencedProjects")] public bool? IncludeReferencedProjects => Get<bool?>(() => IncludeReferencedProjects);
    /// <summary>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</summary>
    [Argument(Format = "-MinClientVersion")] public bool? MinClientVersion => Get<bool?>(() => MinClientVersion);
    /// <summary><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</summary>
    [Argument(Format = "-ForceEnglishOutput")] public bool? ForceEnglishOutput => Get<bool?>(() => ForceEnglishOutput);
    /// <summary><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</summary>
    [Argument(Format = "-MSBuildPath {value}")] public string MSBuildPath => Get<string>(() => MSBuildPath);
    /// <summary><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</summary>
    [Argument(Format = "-MSBuildVersion {value}")] public NuGetMSBuildVersion MSBuildVersion => Get<NuGetMSBuildVersion>(() => MSBuildVersion);
    /// <summary>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</summary>
    [Argument(Format = "-NoDefaultExcludes")] public bool? NoDefaultExcludes => Get<bool?>(() => NoDefaultExcludes);
    /// <summary>Specifies that pack should not run package analysis after building the package.</summary>
    [Argument(Format = "-NoPackageAnalysis")] public bool? NoPackageAnalysis => Get<bool?>(() => NoPackageAnalysis);
    /// <summary>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</summary>
    [Argument(Format = "-OutputDirectory {value}")] public string OutputDirectory => Get<string>(() => OutputDirectory);
    /// <summary>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</summary>
    [Argument(Format = "-Properties {key}={value}", Separator = ";")] public IReadOnlyDictionary<string, object> Properties => Get<Dictionary<string, object>>(() => Properties);
    /// <summary><em>(3.4.4+)</em> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</summary>
    [Argument(Format = "-Suffix {value}")] public string Suffix => Get<string>(() => Suffix);
    /// <summary>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</summary>
    [Argument(Format = "-Symbols")] public bool? Symbols => Get<bool?>(() => Symbols);
    /// <summary>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</summary>
    [Argument(Format = "-Tool")] public bool? Tool => Get<bool?>(() => Tool);
    /// <summary>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</summary>
    [Argument(Format = "-Verbosity {value}")] public NuGetVerbosity Verbosity => Get<NuGetVerbosity>(() => Verbosity);
    /// <summary>Overrides the version number from the <c>.nuspec</c> file.</summary>
    [Argument(Format = "-Version {value}")] public string Version => Get<string>(() => Version);
    /// <summary>Format for packaging symbols.</summary>
    [Argument(Format = "-SymbolPackageFormat {value}")] public NuGetSymbolPackageFormat SymbolPackageFormat => Get<NuGetSymbolPackageFormat>(() => SymbolPackageFormat);
}
#endregion
#region NuGetRestoreSettings
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetRestoreSettings>))]
[Command(Type = typeof(NuGetTasks), Command = nameof(NuGetTasks.NuGetRestore), Arguments = "restore")]
public partial class NuGetRestoreSettings : ToolOptions
{
    /// <summary>Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.</summary>
    [Argument(Format = "{value}", Position = 1)] public string TargetPath => Get<string>(() => TargetPath);
    /// <summary>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</summary>
    [Argument(Format = "-ConfigFile {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</summary>
    [Argument(Format = "-DirectDownload")] public bool? DirectDownload => Get<bool?>(() => DirectDownload);
    /// <summary>Disables restoring multiple packages in parallel.</summary>
    [Argument(Format = "-DisableParallelProcessing")] public bool? DisableParallelProcessing => Get<bool?>(() => DisableParallelProcessing);
    /// <summary><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</summary>
    [Argument(Format = "-FallbackSource {value}", Separator = ";")] public IReadOnlyList<string> FallbackSource => Get<List<string>>(() => FallbackSource);
    /// <summary><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</summary>
    [Argument(Format = "-ForceEnglishOutput")] public bool? ForceEnglishOutput => Get<bool?>(() => ForceEnglishOutput);
    /// <summary><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</summary>
    [Argument(Format = "-MSBuildPath {value}")] public string MSBuildPath => Get<string>(() => MSBuildPath);
    /// <summary><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>, <em>15</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</summary>
    [Argument(Format = "-MSBuildVersion {value}")] public NuGetMSBuildVersion MSBuildVersion => Get<NuGetMSBuildVersion>(() => MSBuildVersion);
    /// <summary>Prevents NuGet from using packages from local machine caches.</summary>
    [Argument(Format = "-NoCache")] public bool? NoCache => Get<bool?>(() => NoCache);
    /// <summary>Suppresses prompts for user input or confirmations.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</summary>
    [Argument(Format = "-OutputDirectory {value}")] public string OutputDirectory => Get<string>(() => OutputDirectory);
    /// <summary>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</summary>
    [Argument(Format = "-PackageSaveMode {value}", Separator = ";")] public IReadOnlyList<PackageSaveMode> PackageSaveMode => Get<List<PackageSaveMode>>(() => PackageSaveMode);
    /// <summary>Same as <c>OutputDirectory</c>.</summary>
    [Argument(Format = "-PackagesDirectory {value}")] public string PackagesDirectory => Get<string>(() => PackagesDirectory);
    /// <summary>Timeout in seconds for resolving project-to-project references.</summary>
    [Argument(Format = "-Project2ProjectTimeOut {value}")] public int? Project2ProjectTimeOut => Get<int?>(() => Project2ProjectTimeOut);
    /// <summary><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</summary>
    [Argument(Format = "-Recursive")] public bool? Recursive => Get<bool?>(() => Recursive);
    /// <summary>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</summary>
    [Argument(Format = "-RequireConsent")] public bool? RequireConsent => Get<bool?>(() => RequireConsent);
    /// <summary>Specifies the solution folder. Not valid when restoring packages for a solution.</summary>
    [Argument(Format = "-SolutionDirectory {value}")] public string SolutionDirectory => Get<string>(() => SolutionDirectory);
    /// <summary>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</summary>
    [Argument(Format = "-Source {value}", Separator = ";")] public IReadOnlyList<string> Source => Get<List<string>>(() => Source);
    /// <summary>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</summary>
    [Argument(Format = "-Verbosity {value}")] public NuGetVerbosity Verbosity => Get<NuGetVerbosity>(() => Verbosity);
}
#endregion
#region NuGetInstallSettings
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetInstallSettings>))]
[Command(Type = typeof(NuGetTasks), Command = nameof(NuGetTasks.NuGetInstall), Arguments = "install")]
public partial class NuGetInstallSettings : ToolOptions
{
    /// <summary>Name of the package to install.</summary>
    [Argument(Format = "{value}", Position = 1)] public string PackageID => Get<string>(() => PackageID);
    /// <summary><em>(4.4+)</em> The version of the dependency packages to use, which can be one of the following: <ul><li><c>Lowest</c>: (default) the lowest version.</li> <li><c>HighestPatch</c>: the version with the lowest major, lowest minor, highest patch.</li> <li><c>HighestMinor</c>: the version with the lowest major, highest minor, highest patch.</li> <li><c>Highest</c>: the highest version.</li> <li><c>Ignore</c>: No dependency packages will be used.</li></ul></summary>
    [Argument(Format = "-DependencyVersion {value}")] public DependencyVersion DependencyVersion => Get<DependencyVersion>(() => DependencyVersion);
    /// <summary>Disables installing multiple packages in parallel.</summary>
    [Argument(Format = "-DisableParallelProcessing")] public bool? DisableParallelProcessing => Get<bool?>(() => DisableParallelProcessing);
    /// <summary>Installs the package to a folder named with only the package name and not the version number.</summary>
    [Argument(Format = "-ExcludeVersion")] public bool? ExcludeVersion => Get<bool?>(() => ExcludeVersion);
    /// <summary><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</summary>
    [Argument(Format = "-FallbackSource {value}", Separator = ";")] public IReadOnlyList<string> FallbackSource => Get<List<string>>(() => FallbackSource);
    /// <summary><em>(4.4+)</em> Target framework used for selecting dependencies. Defaults to 'Any' if not specified.</summary>
    [Argument(Format = "-Framework {value}")] public string Framework => Get<string>(() => Framework);
    /// <summary>Prevents NuGet from using cached packages. See <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/managing-the-global-packages-and-cache-folders">Managing the global packages and cache folders</a>.</summary>
    [Argument(Format = "-NoCache")] public bool? NoCache => Get<bool?>(() => NoCache);
    /// <summary>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</summary>
    [Argument(Format = "-OutputDirectory {value}")] public string OutputDirectory => Get<string>(() => OutputDirectory);
    /// <summary>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</summary>
    [Argument(Format = "-PackageSaveMode {value}", Separator = ";")] public IReadOnlyList<PackageSaveMode> PackageSaveMode => Get<List<PackageSaveMode>>(() => PackageSaveMode);
    /// <summary>Allows prerelease packages to be installed. This flag is not required when restoring packages with <c>packages.config</c>.</summary>
    [Argument(Format = "-PreRelease")] public bool? PreRelease => Get<bool?>(() => PreRelease);
    /// <summary>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</summary>
    [Argument(Format = "-RequireConsent")] public bool? RequireConsent => Get<bool?>(() => RequireConsent);
    /// <summary>Specifies root folder of the solution for which to restore packages.</summary>
    [Argument(Format = "-SolutionDirectory {value}")] public string SolutionDirectory => Get<string>(() => SolutionDirectory);
    /// <summary>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Common NuGet configurations</a>.</summary>
    [Argument(Format = "-Source {value}", Separator = ";")] public IReadOnlyList<string> Source => Get<List<string>>(() => Source);
    /// <summary>Specifies the version of the package to install.</summary>
    [Argument(Format = "-Version {value}")] public string Version => Get<string>(() => Version);
    /// <summary>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</summary>
    [Argument(Format = "-ConfigFile {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</summary>
    [Argument(Format = "-ForceEnglishOutput")] public bool? ForceEnglishOutput => Get<bool?>(() => ForceEnglishOutput);
    /// <summary>Suppresses prompts for user input or confirmations.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</summary>
    [Argument(Format = "-Verbosity {value}")] public NuGetVerbosity Verbosity => Get<NuGetVerbosity>(() => Verbosity);
}
#endregion
#region NuGetSourcesAddSettings
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetSourcesAddSettings>))]
[Command(Type = typeof(NuGetTasks), Command = nameof(NuGetTasks.NuGetSourcesAdd), Arguments = "sources add")]
public partial class NuGetSourcesAddSettings : ToolOptions
{
    /// <summary>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</summary>
    [Argument(Format = "-ConfigFile {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</summary>
    [Argument(Format = "-ForceEnglishOutput")] public bool? ForceEnglishOutput => Get<bool?>(() => ForceEnglishOutput);
    /// <summary>Suppresses prompts for user input or confirmations.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</summary>
    [Argument(Format = "-Verbosity {value}")] public NuGetVerbosity Verbosity => Get<NuGetVerbosity>(() => Verbosity);
    /// <summary>Name of the source.</summary>
    [Argument(Format = "-Name {value}")] public string Name => Get<string>(() => Name);
    /// <summary>URL of the source.</summary>
    [Argument(Format = "-Source {value}")] public string Source => Get<string>(() => Source);
    /// <summary>Specifies the password for authenticating with the source.</summary>
    [Argument(Format = "-Password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</summary>
    [Argument(Format = "-StorePasswordInClearText", Secret = false)] public bool? StorePasswordInClearText => Get<bool?>(() => StorePasswordInClearText);
    /// <summary>Specifies the user name for authenticating with the source.</summary>
    [Argument(Format = "-UserName {value}")] public string UserName => Get<string>(() => UserName);
}
#endregion
#region NuGetSourcesUpdateSettings
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetSourcesUpdateSettings>))]
[Command(Type = typeof(NuGetTasks), Command = nameof(NuGetTasks.NuGetSourcesUpdate), Arguments = "sources update")]
public partial class NuGetSourcesUpdateSettings : ToolOptions
{
    /// <summary>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</summary>
    [Argument(Format = "-ConfigFile {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</summary>
    [Argument(Format = "-ForceEnglishOutput")] public bool? ForceEnglishOutput => Get<bool?>(() => ForceEnglishOutput);
    /// <summary>Suppresses prompts for user input or confirmations.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</summary>
    [Argument(Format = "-Verbosity {value}")] public NuGetVerbosity Verbosity => Get<NuGetVerbosity>(() => Verbosity);
    /// <summary>Name of the source.</summary>
    [Argument(Format = "-Name {value}")] public string Name => Get<string>(() => Name);
    /// <summary>URL of the source.</summary>
    [Argument(Format = "-Source {value}")] public string Source => Get<string>(() => Source);
    /// <summary>Specifies the password for authenticating with the source.</summary>
    [Argument(Format = "-Password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</summary>
    [Argument(Format = "-StorePasswordInClearText", Secret = false)] public bool? StorePasswordInClearText => Get<bool?>(() => StorePasswordInClearText);
    /// <summary>Specifies the user name for authenticating with the source.</summary>
    [Argument(Format = "-UserName {value}")] public string UserName => Get<string>(() => UserName);
}
#endregion
#region NuGetSourcesRemoveSettings
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetSourcesRemoveSettings>))]
[Command(Type = typeof(NuGetTasks), Command = nameof(NuGetTasks.NuGetSourcesRemove), Arguments = "sources remove")]
public partial class NuGetSourcesRemoveSettings : ToolOptions
{
    /// <summary>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</summary>
    [Argument(Format = "-ConfigFile {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</summary>
    [Argument(Format = "-ForceEnglishOutput")] public bool? ForceEnglishOutput => Get<bool?>(() => ForceEnglishOutput);
    /// <summary>Suppresses prompts for user input or confirmations.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</summary>
    [Argument(Format = "-Verbosity {value}")] public NuGetVerbosity Verbosity => Get<NuGetVerbosity>(() => Verbosity);
    /// <summary>Name of the source.</summary>
    [Argument(Format = "-Name {value}")] public string Name => Get<string>(() => Name);
}
#endregion
#region NuGetSourcesEnableSettings
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetSourcesEnableSettings>))]
[Command(Type = typeof(NuGetTasks), Command = nameof(NuGetTasks.NuGetSourcesEnable), Arguments = "sources enable")]
public partial class NuGetSourcesEnableSettings : ToolOptions
{
    /// <summary>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</summary>
    [Argument(Format = "-ConfigFile {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</summary>
    [Argument(Format = "-ForceEnglishOutput")] public bool? ForceEnglishOutput => Get<bool?>(() => ForceEnglishOutput);
    /// <summary>Suppresses prompts for user input or confirmations.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</summary>
    [Argument(Format = "-Verbosity {value}")] public NuGetVerbosity Verbosity => Get<NuGetVerbosity>(() => Verbosity);
    /// <summary>Name of the source.</summary>
    [Argument(Format = "-Name {value}")] public string Name => Get<string>(() => Name);
}
#endregion
#region NuGetSourcesDisableSettings
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetSourcesDisableSettings>))]
[Command(Type = typeof(NuGetTasks), Command = nameof(NuGetTasks.NuGetSourcesDisable), Arguments = "sources disable")]
public partial class NuGetSourcesDisableSettings : ToolOptions
{
    /// <summary>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</summary>
    [Argument(Format = "-ConfigFile {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</summary>
    [Argument(Format = "-ForceEnglishOutput")] public bool? ForceEnglishOutput => Get<bool?>(() => ForceEnglishOutput);
    /// <summary>Suppresses prompts for user input or confirmations.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</summary>
    [Argument(Format = "-Verbosity {value}")] public NuGetVerbosity Verbosity => Get<NuGetVerbosity>(() => Verbosity);
    /// <summary>Name of the source.</summary>
    [Argument(Format = "-Name {value}")] public string Name => Get<string>(() => Name);
}
#endregion
#region NuGetSourcesListSettings
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetSourcesListSettings>))]
[Command(Type = typeof(NuGetTasks), Command = nameof(NuGetTasks.NuGetSourcesList), Arguments = "sources list")]
public partial class NuGetSourcesListSettings : ToolOptions
{
    /// <summary>Can be <c>Detailed</c> (the default) or <c>Short</c>.</summary>
    [Argument(Format = "-Format {value}")] public NuGetSourcesListFormat Format => Get<NuGetSourcesListFormat>(() => Format);
    /// <summary>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</summary>
    [Argument(Format = "-ConfigFile {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</summary>
    [Argument(Format = "-ForceEnglishOutput")] public bool? ForceEnglishOutput => Get<bool?>(() => ForceEnglishOutput);
    /// <summary>Suppresses prompts for user input or confirmations.</summary>
    [Argument(Format = "-NonInteractive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</summary>
    [Argument(Format = "-Verbosity {value}")] public NuGetVerbosity Verbosity => Get<NuGetVerbosity>(() => Verbosity);
}
#endregion
#region NuGetPushSettingsExtensions
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetPushSettingsExtensions
{
    #region TargetPath
    /// <inheritdoc cref="NuGetPushSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.TargetPath))]
    public static T SetTargetPath<T>(this T o, string v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.TargetPath, v));
    /// <inheritdoc cref="NuGetPushSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.TargetPath))]
    public static T ResetTargetPath<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.TargetPath));
    #endregion
    #region ApiKey
    /// <inheritdoc cref="NuGetPushSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.ApiKey))]
    public static T SetApiKey<T>(this T o, [Secret] string v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.ApiKey, v));
    /// <inheritdoc cref="NuGetPushSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.ApiKey))]
    public static T ResetApiKey<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.ApiKey));
    #endregion
    #region Source
    /// <inheritdoc cref="NuGetPushSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.Source))]
    public static T SetSource<T>(this T o, string v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="NuGetPushSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.Source))]
    public static T ResetSource<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.Source));
    #endregion
    #region SymbolSource
    /// <inheritdoc cref="NuGetPushSettings.SymbolSource"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.SymbolSource))]
    public static T SetSymbolSource<T>(this T o, string v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.SymbolSource, v));
    /// <inheritdoc cref="NuGetPushSettings.SymbolSource"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.SymbolSource))]
    public static T ResetSymbolSource<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.SymbolSource));
    #endregion
    #region SymbolApiKey
    /// <inheritdoc cref="NuGetPushSettings.SymbolApiKey"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.SymbolApiKey))]
    public static T SetSymbolApiKey<T>(this T o, [Secret] string v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.SymbolApiKey, v));
    /// <inheritdoc cref="NuGetPushSettings.SymbolApiKey"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.SymbolApiKey))]
    public static T ResetSymbolApiKey<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.SymbolApiKey));
    #endregion
    #region NoSymbols
    /// <inheritdoc cref="NuGetPushSettings.NoSymbols"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.NoSymbols))]
    public static T SetNoSymbols<T>(this T o, bool? v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.NoSymbols, v));
    /// <inheritdoc cref="NuGetPushSettings.NoSymbols"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.NoSymbols))]
    public static T ResetNoSymbols<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.NoSymbols));
    /// <inheritdoc cref="NuGetPushSettings.NoSymbols"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.NoSymbols))]
    public static T EnableNoSymbols<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.NoSymbols, true));
    /// <inheritdoc cref="NuGetPushSettings.NoSymbols"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.NoSymbols))]
    public static T DisableNoSymbols<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.NoSymbols, false));
    /// <inheritdoc cref="NuGetPushSettings.NoSymbols"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.NoSymbols))]
    public static T ToggleNoSymbols<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.NoSymbols, !o.NoSymbols));
    #endregion
    #region DisableBuffering
    /// <inheritdoc cref="NuGetPushSettings.DisableBuffering"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.DisableBuffering))]
    public static T SetDisableBuffering<T>(this T o, bool? v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.DisableBuffering, v));
    /// <inheritdoc cref="NuGetPushSettings.DisableBuffering"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.DisableBuffering))]
    public static T ResetDisableBuffering<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.DisableBuffering));
    /// <inheritdoc cref="NuGetPushSettings.DisableBuffering"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.DisableBuffering))]
    public static T EnableDisableBuffering<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.DisableBuffering, true));
    /// <inheritdoc cref="NuGetPushSettings.DisableBuffering"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.DisableBuffering))]
    public static T DisableDisableBuffering<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.DisableBuffering, false));
    /// <inheritdoc cref="NuGetPushSettings.DisableBuffering"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.DisableBuffering))]
    public static T ToggleDisableBuffering<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.DisableBuffering, !o.DisableBuffering));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="NuGetPushSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="NuGetPushSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="NuGetPushSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, NuGetVerbosity v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="NuGetPushSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region ForceEnglishOutput
    /// <inheritdoc cref="NuGetPushSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.ForceEnglishOutput))]
    public static T SetForceEnglishOutput<T>(this T o, bool? v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, v));
    /// <inheritdoc cref="NuGetPushSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.ForceEnglishOutput))]
    public static T ResetForceEnglishOutput<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.ForceEnglishOutput));
    /// <inheritdoc cref="NuGetPushSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.ForceEnglishOutput))]
    public static T EnableForceEnglishOutput<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, true));
    /// <inheritdoc cref="NuGetPushSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.ForceEnglishOutput))]
    public static T DisableForceEnglishOutput<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, false));
    /// <inheritdoc cref="NuGetPushSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.ForceEnglishOutput))]
    public static T ToggleForceEnglishOutput<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, !o.ForceEnglishOutput));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="NuGetPushSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="NuGetPushSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="NuGetPushSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="NuGetPushSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="NuGetPushSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Timeout
    /// <inheritdoc cref="NuGetPushSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.Timeout))]
    public static T SetTimeout<T>(this T o, int? v) where T : NuGetPushSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="NuGetPushSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(NuGetPushSettings), Property = nameof(NuGetPushSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : NuGetPushSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
}
#endregion
#region NuGetPackSettingsExtensions
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetPackSettingsExtensions
{
    #region TargetPath
    /// <inheritdoc cref="NuGetPackSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.TargetPath))]
    public static T SetTargetPath<T>(this T o, string v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.TargetPath, v));
    /// <inheritdoc cref="NuGetPackSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.TargetPath))]
    public static T ResetTargetPath<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.TargetPath));
    #endregion
    #region BasePath
    /// <inheritdoc cref="NuGetPackSettings.BasePath"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.BasePath))]
    public static T SetBasePath<T>(this T o, string v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.BasePath, v));
    /// <inheritdoc cref="NuGetPackSettings.BasePath"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.BasePath))]
    public static T ResetBasePath<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.BasePath));
    #endregion
    #region Build
    /// <inheritdoc cref="NuGetPackSettings.Build"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Build))]
    public static T SetBuild<T>(this T o, bool? v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Build, v));
    /// <inheritdoc cref="NuGetPackSettings.Build"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Build))]
    public static T ResetBuild<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.Build));
    /// <inheritdoc cref="NuGetPackSettings.Build"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Build))]
    public static T EnableBuild<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Build, true));
    /// <inheritdoc cref="NuGetPackSettings.Build"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Build))]
    public static T DisableBuild<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Build, false));
    /// <inheritdoc cref="NuGetPackSettings.Build"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Build))]
    public static T ToggleBuild<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Build, !o.Build));
    #endregion
    #region Exclude
    /// <inheritdoc cref="NuGetPackSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Exclude))]
    public static T SetExclude<T>(this T o, string v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Exclude, v));
    /// <inheritdoc cref="NuGetPackSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Exclude))]
    public static T ResetExclude<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.Exclude));
    #endregion
    #region ExcludeEmptyDirectories
    /// <inheritdoc cref="NuGetPackSettings.ExcludeEmptyDirectories"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.ExcludeEmptyDirectories))]
    public static T SetExcludeEmptyDirectories<T>(this T o, bool? v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.ExcludeEmptyDirectories, v));
    /// <inheritdoc cref="NuGetPackSettings.ExcludeEmptyDirectories"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.ExcludeEmptyDirectories))]
    public static T ResetExcludeEmptyDirectories<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.ExcludeEmptyDirectories));
    /// <inheritdoc cref="NuGetPackSettings.ExcludeEmptyDirectories"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.ExcludeEmptyDirectories))]
    public static T EnableExcludeEmptyDirectories<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.ExcludeEmptyDirectories, true));
    /// <inheritdoc cref="NuGetPackSettings.ExcludeEmptyDirectories"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.ExcludeEmptyDirectories))]
    public static T DisableExcludeEmptyDirectories<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.ExcludeEmptyDirectories, false));
    /// <inheritdoc cref="NuGetPackSettings.ExcludeEmptyDirectories"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.ExcludeEmptyDirectories))]
    public static T ToggleExcludeEmptyDirectories<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.ExcludeEmptyDirectories, !o.ExcludeEmptyDirectories));
    #endregion
    #region IncludeReferencedProjects
    /// <inheritdoc cref="NuGetPackSettings.IncludeReferencedProjects"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.IncludeReferencedProjects))]
    public static T SetIncludeReferencedProjects<T>(this T o, bool? v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.IncludeReferencedProjects, v));
    /// <inheritdoc cref="NuGetPackSettings.IncludeReferencedProjects"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.IncludeReferencedProjects))]
    public static T ResetIncludeReferencedProjects<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.IncludeReferencedProjects));
    /// <inheritdoc cref="NuGetPackSettings.IncludeReferencedProjects"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.IncludeReferencedProjects))]
    public static T EnableIncludeReferencedProjects<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.IncludeReferencedProjects, true));
    /// <inheritdoc cref="NuGetPackSettings.IncludeReferencedProjects"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.IncludeReferencedProjects))]
    public static T DisableIncludeReferencedProjects<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.IncludeReferencedProjects, false));
    /// <inheritdoc cref="NuGetPackSettings.IncludeReferencedProjects"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.IncludeReferencedProjects))]
    public static T ToggleIncludeReferencedProjects<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.IncludeReferencedProjects, !o.IncludeReferencedProjects));
    #endregion
    #region MinClientVersion
    /// <inheritdoc cref="NuGetPackSettings.MinClientVersion"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.MinClientVersion))]
    public static T SetMinClientVersion<T>(this T o, bool? v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.MinClientVersion, v));
    /// <inheritdoc cref="NuGetPackSettings.MinClientVersion"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.MinClientVersion))]
    public static T ResetMinClientVersion<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.MinClientVersion));
    /// <inheritdoc cref="NuGetPackSettings.MinClientVersion"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.MinClientVersion))]
    public static T EnableMinClientVersion<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.MinClientVersion, true));
    /// <inheritdoc cref="NuGetPackSettings.MinClientVersion"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.MinClientVersion))]
    public static T DisableMinClientVersion<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.MinClientVersion, false));
    /// <inheritdoc cref="NuGetPackSettings.MinClientVersion"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.MinClientVersion))]
    public static T ToggleMinClientVersion<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.MinClientVersion, !o.MinClientVersion));
    #endregion
    #region ForceEnglishOutput
    /// <inheritdoc cref="NuGetPackSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.ForceEnglishOutput))]
    public static T SetForceEnglishOutput<T>(this T o, bool? v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, v));
    /// <inheritdoc cref="NuGetPackSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.ForceEnglishOutput))]
    public static T ResetForceEnglishOutput<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.ForceEnglishOutput));
    /// <inheritdoc cref="NuGetPackSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.ForceEnglishOutput))]
    public static T EnableForceEnglishOutput<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, true));
    /// <inheritdoc cref="NuGetPackSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.ForceEnglishOutput))]
    public static T DisableForceEnglishOutput<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, false));
    /// <inheritdoc cref="NuGetPackSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.ForceEnglishOutput))]
    public static T ToggleForceEnglishOutput<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, !o.ForceEnglishOutput));
    #endregion
    #region MSBuildPath
    /// <inheritdoc cref="NuGetPackSettings.MSBuildPath"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.MSBuildPath))]
    public static T SetMSBuildPath<T>(this T o, string v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.MSBuildPath, v));
    /// <inheritdoc cref="NuGetPackSettings.MSBuildPath"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.MSBuildPath))]
    public static T ResetMSBuildPath<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.MSBuildPath));
    #endregion
    #region MSBuildVersion
    /// <inheritdoc cref="NuGetPackSettings.MSBuildVersion"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.MSBuildVersion))]
    public static T SetMSBuildVersion<T>(this T o, NuGetMSBuildVersion v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.MSBuildVersion, v));
    /// <inheritdoc cref="NuGetPackSettings.MSBuildVersion"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.MSBuildVersion))]
    public static T ResetMSBuildVersion<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.MSBuildVersion));
    #endregion
    #region NoDefaultExcludes
    /// <inheritdoc cref="NuGetPackSettings.NoDefaultExcludes"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.NoDefaultExcludes))]
    public static T SetNoDefaultExcludes<T>(this T o, bool? v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.NoDefaultExcludes, v));
    /// <inheritdoc cref="NuGetPackSettings.NoDefaultExcludes"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.NoDefaultExcludes))]
    public static T ResetNoDefaultExcludes<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.NoDefaultExcludes));
    /// <inheritdoc cref="NuGetPackSettings.NoDefaultExcludes"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.NoDefaultExcludes))]
    public static T EnableNoDefaultExcludes<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.NoDefaultExcludes, true));
    /// <inheritdoc cref="NuGetPackSettings.NoDefaultExcludes"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.NoDefaultExcludes))]
    public static T DisableNoDefaultExcludes<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.NoDefaultExcludes, false));
    /// <inheritdoc cref="NuGetPackSettings.NoDefaultExcludes"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.NoDefaultExcludes))]
    public static T ToggleNoDefaultExcludes<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.NoDefaultExcludes, !o.NoDefaultExcludes));
    #endregion
    #region NoPackageAnalysis
    /// <inheritdoc cref="NuGetPackSettings.NoPackageAnalysis"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.NoPackageAnalysis))]
    public static T SetNoPackageAnalysis<T>(this T o, bool? v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.NoPackageAnalysis, v));
    /// <inheritdoc cref="NuGetPackSettings.NoPackageAnalysis"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.NoPackageAnalysis))]
    public static T ResetNoPackageAnalysis<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.NoPackageAnalysis));
    /// <inheritdoc cref="NuGetPackSettings.NoPackageAnalysis"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.NoPackageAnalysis))]
    public static T EnableNoPackageAnalysis<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.NoPackageAnalysis, true));
    /// <inheritdoc cref="NuGetPackSettings.NoPackageAnalysis"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.NoPackageAnalysis))]
    public static T DisableNoPackageAnalysis<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.NoPackageAnalysis, false));
    /// <inheritdoc cref="NuGetPackSettings.NoPackageAnalysis"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.NoPackageAnalysis))]
    public static T ToggleNoPackageAnalysis<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.NoPackageAnalysis, !o.NoPackageAnalysis));
    #endregion
    #region OutputDirectory
    /// <inheritdoc cref="NuGetPackSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.OutputDirectory))]
    public static T SetOutputDirectory<T>(this T o, string v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.OutputDirectory, v));
    /// <inheritdoc cref="NuGetPackSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.OutputDirectory))]
    public static T ResetOutputDirectory<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.OutputDirectory));
    #endregion
    #region Properties
    /// <inheritdoc cref="NuGetPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Properties))]
    public static T SetProperties<T>(this T o, IDictionary<string, object> v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Properties, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="NuGetPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Properties))]
    public static T SetProperty<T>(this T o, string k, object v) where T : NuGetPackSettings => o.Modify(b => b.SetDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="NuGetPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Properties))]
    public static T AddProperty<T>(this T o, string k, object v) where T : NuGetPackSettings => o.Modify(b => b.AddDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="NuGetPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Properties))]
    public static T RemoveProperty<T>(this T o, string k) where T : NuGetPackSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, k));
    /// <inheritdoc cref="NuGetPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Properties))]
    public static T ClearProperties<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.ClearDictionary(() => o.Properties));
    #region Configuration
    /// <inheritdoc cref="NuGetPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Properties))]
    public static T SetConfiguration<T>(this T o, string v) where T : NuGetPackSettings => o.Modify(b => b.SetDictionary(() => o.Properties, "Configuration", v));
    /// <inheritdoc cref="NuGetPackSettings.Properties"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Properties))]
    public static T ResetConfiguration<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, "Configuration"));
    #endregion
    #endregion
    #region Suffix
    /// <inheritdoc cref="NuGetPackSettings.Suffix"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Suffix))]
    public static T SetSuffix<T>(this T o, string v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Suffix, v));
    /// <inheritdoc cref="NuGetPackSettings.Suffix"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Suffix))]
    public static T ResetSuffix<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.Suffix));
    #endregion
    #region Symbols
    /// <inheritdoc cref="NuGetPackSettings.Symbols"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Symbols))]
    public static T SetSymbols<T>(this T o, bool? v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Symbols, v));
    /// <inheritdoc cref="NuGetPackSettings.Symbols"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Symbols))]
    public static T ResetSymbols<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.Symbols));
    /// <inheritdoc cref="NuGetPackSettings.Symbols"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Symbols))]
    public static T EnableSymbols<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Symbols, true));
    /// <inheritdoc cref="NuGetPackSettings.Symbols"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Symbols))]
    public static T DisableSymbols<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Symbols, false));
    /// <inheritdoc cref="NuGetPackSettings.Symbols"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Symbols))]
    public static T ToggleSymbols<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Symbols, !o.Symbols));
    #endregion
    #region Tool
    /// <inheritdoc cref="NuGetPackSettings.Tool"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Tool))]
    public static T SetTool<T>(this T o, bool? v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Tool, v));
    /// <inheritdoc cref="NuGetPackSettings.Tool"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Tool))]
    public static T ResetTool<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.Tool));
    /// <inheritdoc cref="NuGetPackSettings.Tool"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Tool))]
    public static T EnableTool<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Tool, true));
    /// <inheritdoc cref="NuGetPackSettings.Tool"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Tool))]
    public static T DisableTool<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Tool, false));
    /// <inheritdoc cref="NuGetPackSettings.Tool"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Tool))]
    public static T ToggleTool<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Tool, !o.Tool));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="NuGetPackSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, NuGetVerbosity v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="NuGetPackSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region Version
    /// <inheritdoc cref="NuGetPackSettings.Version"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="NuGetPackSettings.Version"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region SymbolPackageFormat
    /// <inheritdoc cref="NuGetPackSettings.SymbolPackageFormat"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.SymbolPackageFormat))]
    public static T SetSymbolPackageFormat<T>(this T o, NuGetSymbolPackageFormat v) where T : NuGetPackSettings => o.Modify(b => b.Set(() => o.SymbolPackageFormat, v));
    /// <inheritdoc cref="NuGetPackSettings.SymbolPackageFormat"/>
    [Pure] [Builder(Type = typeof(NuGetPackSettings), Property = nameof(NuGetPackSettings.SymbolPackageFormat))]
    public static T ResetSymbolPackageFormat<T>(this T o) where T : NuGetPackSettings => o.Modify(b => b.Remove(() => o.SymbolPackageFormat));
    #endregion
}
#endregion
#region NuGetRestoreSettingsExtensions
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetRestoreSettingsExtensions
{
    #region TargetPath
    /// <inheritdoc cref="NuGetRestoreSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.TargetPath))]
    public static T SetTargetPath<T>(this T o, string v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.TargetPath, v));
    /// <inheritdoc cref="NuGetRestoreSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.TargetPath))]
    public static T ResetTargetPath<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.TargetPath));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="NuGetRestoreSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="NuGetRestoreSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region DirectDownload
    /// <inheritdoc cref="NuGetRestoreSettings.DirectDownload"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.DirectDownload))]
    public static T SetDirectDownload<T>(this T o, bool? v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.DirectDownload, v));
    /// <inheritdoc cref="NuGetRestoreSettings.DirectDownload"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.DirectDownload))]
    public static T ResetDirectDownload<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.DirectDownload));
    /// <inheritdoc cref="NuGetRestoreSettings.DirectDownload"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.DirectDownload))]
    public static T EnableDirectDownload<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.DirectDownload, true));
    /// <inheritdoc cref="NuGetRestoreSettings.DirectDownload"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.DirectDownload))]
    public static T DisableDirectDownload<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.DirectDownload, false));
    /// <inheritdoc cref="NuGetRestoreSettings.DirectDownload"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.DirectDownload))]
    public static T ToggleDirectDownload<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.DirectDownload, !o.DirectDownload));
    #endregion
    #region DisableParallelProcessing
    /// <inheritdoc cref="NuGetRestoreSettings.DisableParallelProcessing"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.DisableParallelProcessing))]
    public static T SetDisableParallelProcessing<T>(this T o, bool? v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.DisableParallelProcessing, v));
    /// <inheritdoc cref="NuGetRestoreSettings.DisableParallelProcessing"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.DisableParallelProcessing))]
    public static T ResetDisableParallelProcessing<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.DisableParallelProcessing));
    /// <inheritdoc cref="NuGetRestoreSettings.DisableParallelProcessing"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.DisableParallelProcessing))]
    public static T EnableDisableParallelProcessing<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.DisableParallelProcessing, true));
    /// <inheritdoc cref="NuGetRestoreSettings.DisableParallelProcessing"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.DisableParallelProcessing))]
    public static T DisableDisableParallelProcessing<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.DisableParallelProcessing, false));
    /// <inheritdoc cref="NuGetRestoreSettings.DisableParallelProcessing"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.DisableParallelProcessing))]
    public static T ToggleDisableParallelProcessing<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.DisableParallelProcessing, !o.DisableParallelProcessing));
    #endregion
    #region FallbackSource
    /// <inheritdoc cref="NuGetRestoreSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.FallbackSource))]
    public static T SetFallbackSource<T>(this T o, params string[] v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetRestoreSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.FallbackSource))]
    public static T SetFallbackSource<T>(this T o, IEnumerable<string> v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetRestoreSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.FallbackSource))]
    public static T AddFallbackSource<T>(this T o, params string[] v) where T : NuGetRestoreSettings => o.Modify(b => b.AddCollection(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetRestoreSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.FallbackSource))]
    public static T AddFallbackSource<T>(this T o, IEnumerable<string> v) where T : NuGetRestoreSettings => o.Modify(b => b.AddCollection(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetRestoreSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.FallbackSource))]
    public static T RemoveFallbackSource<T>(this T o, params string[] v) where T : NuGetRestoreSettings => o.Modify(b => b.RemoveCollection(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetRestoreSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.FallbackSource))]
    public static T RemoveFallbackSource<T>(this T o, IEnumerable<string> v) where T : NuGetRestoreSettings => o.Modify(b => b.RemoveCollection(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetRestoreSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.FallbackSource))]
    public static T ClearFallbackSource<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.ClearCollection(() => o.FallbackSource));
    #endregion
    #region ForceEnglishOutput
    /// <inheritdoc cref="NuGetRestoreSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.ForceEnglishOutput))]
    public static T SetForceEnglishOutput<T>(this T o, bool? v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, v));
    /// <inheritdoc cref="NuGetRestoreSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.ForceEnglishOutput))]
    public static T ResetForceEnglishOutput<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.ForceEnglishOutput));
    /// <inheritdoc cref="NuGetRestoreSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.ForceEnglishOutput))]
    public static T EnableForceEnglishOutput<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, true));
    /// <inheritdoc cref="NuGetRestoreSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.ForceEnglishOutput))]
    public static T DisableForceEnglishOutput<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, false));
    /// <inheritdoc cref="NuGetRestoreSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.ForceEnglishOutput))]
    public static T ToggleForceEnglishOutput<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, !o.ForceEnglishOutput));
    #endregion
    #region MSBuildPath
    /// <inheritdoc cref="NuGetRestoreSettings.MSBuildPath"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.MSBuildPath))]
    public static T SetMSBuildPath<T>(this T o, string v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.MSBuildPath, v));
    /// <inheritdoc cref="NuGetRestoreSettings.MSBuildPath"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.MSBuildPath))]
    public static T ResetMSBuildPath<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.MSBuildPath));
    #endregion
    #region MSBuildVersion
    /// <inheritdoc cref="NuGetRestoreSettings.MSBuildVersion"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.MSBuildVersion))]
    public static T SetMSBuildVersion<T>(this T o, NuGetMSBuildVersion v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.MSBuildVersion, v));
    /// <inheritdoc cref="NuGetRestoreSettings.MSBuildVersion"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.MSBuildVersion))]
    public static T ResetMSBuildVersion<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.MSBuildVersion));
    #endregion
    #region NoCache
    /// <inheritdoc cref="NuGetRestoreSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.NoCache))]
    public static T SetNoCache<T>(this T o, bool? v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.NoCache, v));
    /// <inheritdoc cref="NuGetRestoreSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.NoCache))]
    public static T ResetNoCache<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.NoCache));
    /// <inheritdoc cref="NuGetRestoreSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.NoCache))]
    public static T EnableNoCache<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.NoCache, true));
    /// <inheritdoc cref="NuGetRestoreSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.NoCache))]
    public static T DisableNoCache<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.NoCache, false));
    /// <inheritdoc cref="NuGetRestoreSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.NoCache))]
    public static T ToggleNoCache<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.NoCache, !o.NoCache));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="NuGetRestoreSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="NuGetRestoreSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="NuGetRestoreSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="NuGetRestoreSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="NuGetRestoreSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region OutputDirectory
    /// <inheritdoc cref="NuGetRestoreSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.OutputDirectory))]
    public static T SetOutputDirectory<T>(this T o, string v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.OutputDirectory, v));
    /// <inheritdoc cref="NuGetRestoreSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.OutputDirectory))]
    public static T ResetOutputDirectory<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.OutputDirectory));
    #endregion
    #region PackageSaveMode
    /// <inheritdoc cref="NuGetRestoreSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.PackageSaveMode))]
    public static T SetPackageSaveMode<T>(this T o, params PackageSaveMode[] v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetRestoreSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.PackageSaveMode))]
    public static T SetPackageSaveMode<T>(this T o, IEnumerable<PackageSaveMode> v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetRestoreSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.PackageSaveMode))]
    public static T AddPackageSaveMode<T>(this T o, params PackageSaveMode[] v) where T : NuGetRestoreSettings => o.Modify(b => b.AddCollection(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetRestoreSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.PackageSaveMode))]
    public static T AddPackageSaveMode<T>(this T o, IEnumerable<PackageSaveMode> v) where T : NuGetRestoreSettings => o.Modify(b => b.AddCollection(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetRestoreSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.PackageSaveMode))]
    public static T RemovePackageSaveMode<T>(this T o, params PackageSaveMode[] v) where T : NuGetRestoreSettings => o.Modify(b => b.RemoveCollection(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetRestoreSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.PackageSaveMode))]
    public static T RemovePackageSaveMode<T>(this T o, IEnumerable<PackageSaveMode> v) where T : NuGetRestoreSettings => o.Modify(b => b.RemoveCollection(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetRestoreSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.PackageSaveMode))]
    public static T ClearPackageSaveMode<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.ClearCollection(() => o.PackageSaveMode));
    #endregion
    #region PackagesDirectory
    /// <inheritdoc cref="NuGetRestoreSettings.PackagesDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.PackagesDirectory))]
    public static T SetPackagesDirectory<T>(this T o, string v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.PackagesDirectory, v));
    /// <inheritdoc cref="NuGetRestoreSettings.PackagesDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.PackagesDirectory))]
    public static T ResetPackagesDirectory<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.PackagesDirectory));
    #endregion
    #region Project2ProjectTimeOut
    /// <inheritdoc cref="NuGetRestoreSettings.Project2ProjectTimeOut"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Project2ProjectTimeOut))]
    public static T SetProject2ProjectTimeOut<T>(this T o, int? v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.Project2ProjectTimeOut, v));
    /// <inheritdoc cref="NuGetRestoreSettings.Project2ProjectTimeOut"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Project2ProjectTimeOut))]
    public static T ResetProject2ProjectTimeOut<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.Project2ProjectTimeOut));
    #endregion
    #region Recursive
    /// <inheritdoc cref="NuGetRestoreSettings.Recursive"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Recursive))]
    public static T SetRecursive<T>(this T o, bool? v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.Recursive, v));
    /// <inheritdoc cref="NuGetRestoreSettings.Recursive"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Recursive))]
    public static T ResetRecursive<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.Recursive));
    /// <inheritdoc cref="NuGetRestoreSettings.Recursive"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Recursive))]
    public static T EnableRecursive<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.Recursive, true));
    /// <inheritdoc cref="NuGetRestoreSettings.Recursive"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Recursive))]
    public static T DisableRecursive<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.Recursive, false));
    /// <inheritdoc cref="NuGetRestoreSettings.Recursive"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Recursive))]
    public static T ToggleRecursive<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.Recursive, !o.Recursive));
    #endregion
    #region RequireConsent
    /// <inheritdoc cref="NuGetRestoreSettings.RequireConsent"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.RequireConsent))]
    public static T SetRequireConsent<T>(this T o, bool? v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.RequireConsent, v));
    /// <inheritdoc cref="NuGetRestoreSettings.RequireConsent"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.RequireConsent))]
    public static T ResetRequireConsent<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.RequireConsent));
    /// <inheritdoc cref="NuGetRestoreSettings.RequireConsent"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.RequireConsent))]
    public static T EnableRequireConsent<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.RequireConsent, true));
    /// <inheritdoc cref="NuGetRestoreSettings.RequireConsent"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.RequireConsent))]
    public static T DisableRequireConsent<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.RequireConsent, false));
    /// <inheritdoc cref="NuGetRestoreSettings.RequireConsent"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.RequireConsent))]
    public static T ToggleRequireConsent<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.RequireConsent, !o.RequireConsent));
    #endregion
    #region SolutionDirectory
    /// <inheritdoc cref="NuGetRestoreSettings.SolutionDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.SolutionDirectory))]
    public static T SetSolutionDirectory<T>(this T o, string v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.SolutionDirectory, v));
    /// <inheritdoc cref="NuGetRestoreSettings.SolutionDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.SolutionDirectory))]
    public static T ResetSolutionDirectory<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.SolutionDirectory));
    #endregion
    #region Source
    /// <inheritdoc cref="NuGetRestoreSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Source))]
    public static T SetSource<T>(this T o, params string[] v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="NuGetRestoreSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Source))]
    public static T SetSource<T>(this T o, IEnumerable<string> v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="NuGetRestoreSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Source))]
    public static T AddSource<T>(this T o, params string[] v) where T : NuGetRestoreSettings => o.Modify(b => b.AddCollection(() => o.Source, v));
    /// <inheritdoc cref="NuGetRestoreSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Source))]
    public static T AddSource<T>(this T o, IEnumerable<string> v) where T : NuGetRestoreSettings => o.Modify(b => b.AddCollection(() => o.Source, v));
    /// <inheritdoc cref="NuGetRestoreSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Source))]
    public static T RemoveSource<T>(this T o, params string[] v) where T : NuGetRestoreSettings => o.Modify(b => b.RemoveCollection(() => o.Source, v));
    /// <inheritdoc cref="NuGetRestoreSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Source))]
    public static T RemoveSource<T>(this T o, IEnumerable<string> v) where T : NuGetRestoreSettings => o.Modify(b => b.RemoveCollection(() => o.Source, v));
    /// <inheritdoc cref="NuGetRestoreSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Source))]
    public static T ClearSource<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.ClearCollection(() => o.Source));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="NuGetRestoreSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, NuGetVerbosity v) where T : NuGetRestoreSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="NuGetRestoreSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetRestoreSettings), Property = nameof(NuGetRestoreSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : NuGetRestoreSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
}
#endregion
#region NuGetInstallSettingsExtensions
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetInstallSettingsExtensions
{
    #region PackageID
    /// <inheritdoc cref="NuGetInstallSettings.PackageID"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PackageID))]
    public static T SetPackageID<T>(this T o, string v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.PackageID, v));
    /// <inheritdoc cref="NuGetInstallSettings.PackageID"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PackageID))]
    public static T ResetPackageID<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.PackageID));
    #endregion
    #region DependencyVersion
    /// <inheritdoc cref="NuGetInstallSettings.DependencyVersion"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.DependencyVersion))]
    public static T SetDependencyVersion<T>(this T o, DependencyVersion v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.DependencyVersion, v));
    /// <inheritdoc cref="NuGetInstallSettings.DependencyVersion"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.DependencyVersion))]
    public static T ResetDependencyVersion<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.DependencyVersion));
    #endregion
    #region DisableParallelProcessing
    /// <inheritdoc cref="NuGetInstallSettings.DisableParallelProcessing"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.DisableParallelProcessing))]
    public static T SetDisableParallelProcessing<T>(this T o, bool? v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.DisableParallelProcessing, v));
    /// <inheritdoc cref="NuGetInstallSettings.DisableParallelProcessing"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.DisableParallelProcessing))]
    public static T ResetDisableParallelProcessing<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.DisableParallelProcessing));
    /// <inheritdoc cref="NuGetInstallSettings.DisableParallelProcessing"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.DisableParallelProcessing))]
    public static T EnableDisableParallelProcessing<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.DisableParallelProcessing, true));
    /// <inheritdoc cref="NuGetInstallSettings.DisableParallelProcessing"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.DisableParallelProcessing))]
    public static T DisableDisableParallelProcessing<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.DisableParallelProcessing, false));
    /// <inheritdoc cref="NuGetInstallSettings.DisableParallelProcessing"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.DisableParallelProcessing))]
    public static T ToggleDisableParallelProcessing<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.DisableParallelProcessing, !o.DisableParallelProcessing));
    #endregion
    #region ExcludeVersion
    /// <inheritdoc cref="NuGetInstallSettings.ExcludeVersion"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ExcludeVersion))]
    public static T SetExcludeVersion<T>(this T o, bool? v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.ExcludeVersion, v));
    /// <inheritdoc cref="NuGetInstallSettings.ExcludeVersion"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ExcludeVersion))]
    public static T ResetExcludeVersion<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.ExcludeVersion));
    /// <inheritdoc cref="NuGetInstallSettings.ExcludeVersion"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ExcludeVersion))]
    public static T EnableExcludeVersion<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.ExcludeVersion, true));
    /// <inheritdoc cref="NuGetInstallSettings.ExcludeVersion"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ExcludeVersion))]
    public static T DisableExcludeVersion<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.ExcludeVersion, false));
    /// <inheritdoc cref="NuGetInstallSettings.ExcludeVersion"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ExcludeVersion))]
    public static T ToggleExcludeVersion<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.ExcludeVersion, !o.ExcludeVersion));
    #endregion
    #region FallbackSource
    /// <inheritdoc cref="NuGetInstallSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.FallbackSource))]
    public static T SetFallbackSource<T>(this T o, params string[] v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetInstallSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.FallbackSource))]
    public static T SetFallbackSource<T>(this T o, IEnumerable<string> v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetInstallSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.FallbackSource))]
    public static T AddFallbackSource<T>(this T o, params string[] v) where T : NuGetInstallSettings => o.Modify(b => b.AddCollection(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetInstallSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.FallbackSource))]
    public static T AddFallbackSource<T>(this T o, IEnumerable<string> v) where T : NuGetInstallSettings => o.Modify(b => b.AddCollection(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetInstallSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.FallbackSource))]
    public static T RemoveFallbackSource<T>(this T o, params string[] v) where T : NuGetInstallSettings => o.Modify(b => b.RemoveCollection(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetInstallSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.FallbackSource))]
    public static T RemoveFallbackSource<T>(this T o, IEnumerable<string> v) where T : NuGetInstallSettings => o.Modify(b => b.RemoveCollection(() => o.FallbackSource, v));
    /// <inheritdoc cref="NuGetInstallSettings.FallbackSource"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.FallbackSource))]
    public static T ClearFallbackSource<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.ClearCollection(() => o.FallbackSource));
    #endregion
    #region Framework
    /// <inheritdoc cref="NuGetInstallSettings.Framework"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Framework))]
    public static T SetFramework<T>(this T o, string v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.Framework, v));
    /// <inheritdoc cref="NuGetInstallSettings.Framework"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Framework))]
    public static T ResetFramework<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.Framework));
    #endregion
    #region NoCache
    /// <inheritdoc cref="NuGetInstallSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.NoCache))]
    public static T SetNoCache<T>(this T o, bool? v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.NoCache, v));
    /// <inheritdoc cref="NuGetInstallSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.NoCache))]
    public static T ResetNoCache<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.NoCache));
    /// <inheritdoc cref="NuGetInstallSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.NoCache))]
    public static T EnableNoCache<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.NoCache, true));
    /// <inheritdoc cref="NuGetInstallSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.NoCache))]
    public static T DisableNoCache<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.NoCache, false));
    /// <inheritdoc cref="NuGetInstallSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.NoCache))]
    public static T ToggleNoCache<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.NoCache, !o.NoCache));
    #endregion
    #region OutputDirectory
    /// <inheritdoc cref="NuGetInstallSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.OutputDirectory))]
    public static T SetOutputDirectory<T>(this T o, string v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.OutputDirectory, v));
    /// <inheritdoc cref="NuGetInstallSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.OutputDirectory))]
    public static T ResetOutputDirectory<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.OutputDirectory));
    #endregion
    #region PackageSaveMode
    /// <inheritdoc cref="NuGetInstallSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PackageSaveMode))]
    public static T SetPackageSaveMode<T>(this T o, params PackageSaveMode[] v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetInstallSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PackageSaveMode))]
    public static T SetPackageSaveMode<T>(this T o, IEnumerable<PackageSaveMode> v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetInstallSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PackageSaveMode))]
    public static T AddPackageSaveMode<T>(this T o, params PackageSaveMode[] v) where T : NuGetInstallSettings => o.Modify(b => b.AddCollection(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetInstallSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PackageSaveMode))]
    public static T AddPackageSaveMode<T>(this T o, IEnumerable<PackageSaveMode> v) where T : NuGetInstallSettings => o.Modify(b => b.AddCollection(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetInstallSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PackageSaveMode))]
    public static T RemovePackageSaveMode<T>(this T o, params PackageSaveMode[] v) where T : NuGetInstallSettings => o.Modify(b => b.RemoveCollection(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetInstallSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PackageSaveMode))]
    public static T RemovePackageSaveMode<T>(this T o, IEnumerable<PackageSaveMode> v) where T : NuGetInstallSettings => o.Modify(b => b.RemoveCollection(() => o.PackageSaveMode, v));
    /// <inheritdoc cref="NuGetInstallSettings.PackageSaveMode"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PackageSaveMode))]
    public static T ClearPackageSaveMode<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.ClearCollection(() => o.PackageSaveMode));
    #endregion
    #region PreRelease
    /// <inheritdoc cref="NuGetInstallSettings.PreRelease"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PreRelease))]
    public static T SetPreRelease<T>(this T o, bool? v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.PreRelease, v));
    /// <inheritdoc cref="NuGetInstallSettings.PreRelease"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PreRelease))]
    public static T ResetPreRelease<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.PreRelease));
    /// <inheritdoc cref="NuGetInstallSettings.PreRelease"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PreRelease))]
    public static T EnablePreRelease<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.PreRelease, true));
    /// <inheritdoc cref="NuGetInstallSettings.PreRelease"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PreRelease))]
    public static T DisablePreRelease<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.PreRelease, false));
    /// <inheritdoc cref="NuGetInstallSettings.PreRelease"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.PreRelease))]
    public static T TogglePreRelease<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.PreRelease, !o.PreRelease));
    #endregion
    #region RequireConsent
    /// <inheritdoc cref="NuGetInstallSettings.RequireConsent"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.RequireConsent))]
    public static T SetRequireConsent<T>(this T o, bool? v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.RequireConsent, v));
    /// <inheritdoc cref="NuGetInstallSettings.RequireConsent"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.RequireConsent))]
    public static T ResetRequireConsent<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.RequireConsent));
    /// <inheritdoc cref="NuGetInstallSettings.RequireConsent"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.RequireConsent))]
    public static T EnableRequireConsent<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.RequireConsent, true));
    /// <inheritdoc cref="NuGetInstallSettings.RequireConsent"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.RequireConsent))]
    public static T DisableRequireConsent<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.RequireConsent, false));
    /// <inheritdoc cref="NuGetInstallSettings.RequireConsent"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.RequireConsent))]
    public static T ToggleRequireConsent<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.RequireConsent, !o.RequireConsent));
    #endregion
    #region SolutionDirectory
    /// <inheritdoc cref="NuGetInstallSettings.SolutionDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.SolutionDirectory))]
    public static T SetSolutionDirectory<T>(this T o, string v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.SolutionDirectory, v));
    /// <inheritdoc cref="NuGetInstallSettings.SolutionDirectory"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.SolutionDirectory))]
    public static T ResetSolutionDirectory<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.SolutionDirectory));
    #endregion
    #region Source
    /// <inheritdoc cref="NuGetInstallSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Source))]
    public static T SetSource<T>(this T o, params string[] v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="NuGetInstallSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Source))]
    public static T SetSource<T>(this T o, IEnumerable<string> v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="NuGetInstallSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Source))]
    public static T AddSource<T>(this T o, params string[] v) where T : NuGetInstallSettings => o.Modify(b => b.AddCollection(() => o.Source, v));
    /// <inheritdoc cref="NuGetInstallSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Source))]
    public static T AddSource<T>(this T o, IEnumerable<string> v) where T : NuGetInstallSettings => o.Modify(b => b.AddCollection(() => o.Source, v));
    /// <inheritdoc cref="NuGetInstallSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Source))]
    public static T RemoveSource<T>(this T o, params string[] v) where T : NuGetInstallSettings => o.Modify(b => b.RemoveCollection(() => o.Source, v));
    /// <inheritdoc cref="NuGetInstallSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Source))]
    public static T RemoveSource<T>(this T o, IEnumerable<string> v) where T : NuGetInstallSettings => o.Modify(b => b.RemoveCollection(() => o.Source, v));
    /// <inheritdoc cref="NuGetInstallSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Source))]
    public static T ClearSource<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.ClearCollection(() => o.Source));
    #endregion
    #region Version
    /// <inheritdoc cref="NuGetInstallSettings.Version"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="NuGetInstallSettings.Version"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="NuGetInstallSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="NuGetInstallSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ForceEnglishOutput
    /// <inheritdoc cref="NuGetInstallSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ForceEnglishOutput))]
    public static T SetForceEnglishOutput<T>(this T o, bool? v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, v));
    /// <inheritdoc cref="NuGetInstallSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ForceEnglishOutput))]
    public static T ResetForceEnglishOutput<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.ForceEnglishOutput));
    /// <inheritdoc cref="NuGetInstallSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ForceEnglishOutput))]
    public static T EnableForceEnglishOutput<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, true));
    /// <inheritdoc cref="NuGetInstallSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ForceEnglishOutput))]
    public static T DisableForceEnglishOutput<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, false));
    /// <inheritdoc cref="NuGetInstallSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.ForceEnglishOutput))]
    public static T ToggleForceEnglishOutput<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, !o.ForceEnglishOutput));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="NuGetInstallSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="NuGetInstallSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="NuGetInstallSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="NuGetInstallSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="NuGetInstallSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="NuGetInstallSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, NuGetVerbosity v) where T : NuGetInstallSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="NuGetInstallSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetInstallSettings), Property = nameof(NuGetInstallSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : NuGetInstallSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
}
#endregion
#region NuGetSourcesAddSettingsExtensions
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetSourcesAddSettingsExtensions
{
    #region ConfigFile
    /// <inheritdoc cref="NuGetSourcesAddSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="NuGetSourcesAddSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ForceEnglishOutput
    /// <inheritdoc cref="NuGetSourcesAddSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.ForceEnglishOutput))]
    public static T SetForceEnglishOutput<T>(this T o, bool? v) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, v));
    /// <inheritdoc cref="NuGetSourcesAddSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.ForceEnglishOutput))]
    public static T ResetForceEnglishOutput<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Remove(() => o.ForceEnglishOutput));
    /// <inheritdoc cref="NuGetSourcesAddSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.ForceEnglishOutput))]
    public static T EnableForceEnglishOutput<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, true));
    /// <inheritdoc cref="NuGetSourcesAddSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.ForceEnglishOutput))]
    public static T DisableForceEnglishOutput<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, false));
    /// <inheritdoc cref="NuGetSourcesAddSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.ForceEnglishOutput))]
    public static T ToggleForceEnglishOutput<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, !o.ForceEnglishOutput));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="NuGetSourcesAddSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="NuGetSourcesAddSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="NuGetSourcesAddSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="NuGetSourcesAddSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="NuGetSourcesAddSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="NuGetSourcesAddSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, NuGetVerbosity v) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="NuGetSourcesAddSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region Name
    /// <inheritdoc cref="NuGetSourcesAddSettings.Name"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="NuGetSourcesAddSettings.Name"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.Name))]
    public static T ResetName<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Source
    /// <inheritdoc cref="NuGetSourcesAddSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.Source))]
    public static T SetSource<T>(this T o, string v) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="NuGetSourcesAddSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.Source))]
    public static T ResetSource<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Remove(() => o.Source));
    #endregion
    #region Password
    /// <inheritdoc cref="NuGetSourcesAddSettings.Password"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="NuGetSourcesAddSettings.Password"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region StorePasswordInClearText
    /// <inheritdoc cref="NuGetSourcesAddSettings.StorePasswordInClearText"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.StorePasswordInClearText))]
    public static T SetStorePasswordInClearText<T>(this T o, bool? v) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.StorePasswordInClearText, v));
    /// <inheritdoc cref="NuGetSourcesAddSettings.StorePasswordInClearText"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.StorePasswordInClearText))]
    public static T ResetStorePasswordInClearText<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Remove(() => o.StorePasswordInClearText));
    /// <inheritdoc cref="NuGetSourcesAddSettings.StorePasswordInClearText"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.StorePasswordInClearText))]
    public static T EnableStorePasswordInClearText<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.StorePasswordInClearText, true));
    /// <inheritdoc cref="NuGetSourcesAddSettings.StorePasswordInClearText"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.StorePasswordInClearText))]
    public static T DisableStorePasswordInClearText<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.StorePasswordInClearText, false));
    /// <inheritdoc cref="NuGetSourcesAddSettings.StorePasswordInClearText"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.StorePasswordInClearText))]
    public static T ToggleStorePasswordInClearText<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.StorePasswordInClearText, !o.StorePasswordInClearText));
    #endregion
    #region UserName
    /// <inheritdoc cref="NuGetSourcesAddSettings.UserName"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.UserName))]
    public static T SetUserName<T>(this T o, string v) where T : NuGetSourcesAddSettings => o.Modify(b => b.Set(() => o.UserName, v));
    /// <inheritdoc cref="NuGetSourcesAddSettings.UserName"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesAddSettings), Property = nameof(NuGetSourcesAddSettings.UserName))]
    public static T ResetUserName<T>(this T o) where T : NuGetSourcesAddSettings => o.Modify(b => b.Remove(() => o.UserName));
    #endregion
}
#endregion
#region NuGetSourcesUpdateSettingsExtensions
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetSourcesUpdateSettingsExtensions
{
    #region ConfigFile
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ForceEnglishOutput
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.ForceEnglishOutput))]
    public static T SetForceEnglishOutput<T>(this T o, bool? v) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, v));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.ForceEnglishOutput))]
    public static T ResetForceEnglishOutput<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Remove(() => o.ForceEnglishOutput));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.ForceEnglishOutput))]
    public static T EnableForceEnglishOutput<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, true));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.ForceEnglishOutput))]
    public static T DisableForceEnglishOutput<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, false));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.ForceEnglishOutput))]
    public static T ToggleForceEnglishOutput<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, !o.ForceEnglishOutput));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, NuGetVerbosity v) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region Name
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.Name"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.Name"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.Name))]
    public static T ResetName<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Source
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.Source))]
    public static T SetSource<T>(this T o, string v) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.Source"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.Source))]
    public static T ResetSource<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Remove(() => o.Source));
    #endregion
    #region Password
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.Password"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.Password"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region StorePasswordInClearText
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.StorePasswordInClearText))]
    public static T SetStorePasswordInClearText<T>(this T o, bool? v) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.StorePasswordInClearText, v));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.StorePasswordInClearText))]
    public static T ResetStorePasswordInClearText<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Remove(() => o.StorePasswordInClearText));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.StorePasswordInClearText))]
    public static T EnableStorePasswordInClearText<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.StorePasswordInClearText, true));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.StorePasswordInClearText))]
    public static T DisableStorePasswordInClearText<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.StorePasswordInClearText, false));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.StorePasswordInClearText))]
    public static T ToggleStorePasswordInClearText<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.StorePasswordInClearText, !o.StorePasswordInClearText));
    #endregion
    #region UserName
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.UserName"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.UserName))]
    public static T SetUserName<T>(this T o, string v) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Set(() => o.UserName, v));
    /// <inheritdoc cref="NuGetSourcesUpdateSettings.UserName"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesUpdateSettings), Property = nameof(NuGetSourcesUpdateSettings.UserName))]
    public static T ResetUserName<T>(this T o) where T : NuGetSourcesUpdateSettings => o.Modify(b => b.Remove(() => o.UserName));
    #endregion
}
#endregion
#region NuGetSourcesRemoveSettingsExtensions
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetSourcesRemoveSettingsExtensions
{
    #region ConfigFile
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ForceEnglishOutput
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.ForceEnglishOutput))]
    public static T SetForceEnglishOutput<T>(this T o, bool? v) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, v));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.ForceEnglishOutput))]
    public static T ResetForceEnglishOutput<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Remove(() => o.ForceEnglishOutput));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.ForceEnglishOutput))]
    public static T EnableForceEnglishOutput<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, true));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.ForceEnglishOutput))]
    public static T DisableForceEnglishOutput<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, false));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.ForceEnglishOutput))]
    public static T ToggleForceEnglishOutput<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, !o.ForceEnglishOutput));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, NuGetVerbosity v) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region Name
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.Name"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="NuGetSourcesRemoveSettings.Name"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesRemoveSettings), Property = nameof(NuGetSourcesRemoveSettings.Name))]
    public static T ResetName<T>(this T o) where T : NuGetSourcesRemoveSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
}
#endregion
#region NuGetSourcesEnableSettingsExtensions
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetSourcesEnableSettingsExtensions
{
    #region ConfigFile
    /// <inheritdoc cref="NuGetSourcesEnableSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ForceEnglishOutput
    /// <inheritdoc cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.ForceEnglishOutput))]
    public static T SetForceEnglishOutput<T>(this T o, bool? v) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, v));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.ForceEnglishOutput))]
    public static T ResetForceEnglishOutput<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Remove(() => o.ForceEnglishOutput));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.ForceEnglishOutput))]
    public static T EnableForceEnglishOutput<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, true));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.ForceEnglishOutput))]
    public static T DisableForceEnglishOutput<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, false));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.ForceEnglishOutput))]
    public static T ToggleForceEnglishOutput<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, !o.ForceEnglishOutput));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="NuGetSourcesEnableSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="NuGetSourcesEnableSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, NuGetVerbosity v) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region Name
    /// <inheritdoc cref="NuGetSourcesEnableSettings.Name"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="NuGetSourcesEnableSettings.Name"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesEnableSettings), Property = nameof(NuGetSourcesEnableSettings.Name))]
    public static T ResetName<T>(this T o) where T : NuGetSourcesEnableSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
}
#endregion
#region NuGetSourcesDisableSettingsExtensions
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetSourcesDisableSettingsExtensions
{
    #region ConfigFile
    /// <inheritdoc cref="NuGetSourcesDisableSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ForceEnglishOutput
    /// <inheritdoc cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.ForceEnglishOutput))]
    public static T SetForceEnglishOutput<T>(this T o, bool? v) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, v));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.ForceEnglishOutput))]
    public static T ResetForceEnglishOutput<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Remove(() => o.ForceEnglishOutput));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.ForceEnglishOutput))]
    public static T EnableForceEnglishOutput<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, true));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.ForceEnglishOutput))]
    public static T DisableForceEnglishOutput<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, false));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.ForceEnglishOutput))]
    public static T ToggleForceEnglishOutput<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, !o.ForceEnglishOutput));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="NuGetSourcesDisableSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="NuGetSourcesDisableSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, NuGetVerbosity v) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region Name
    /// <inheritdoc cref="NuGetSourcesDisableSettings.Name"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="NuGetSourcesDisableSettings.Name"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesDisableSettings), Property = nameof(NuGetSourcesDisableSettings.Name))]
    public static T ResetName<T>(this T o) where T : NuGetSourcesDisableSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
}
#endregion
#region NuGetSourcesListSettingsExtensions
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NuGetSourcesListSettingsExtensions
{
    #region Format
    /// <inheritdoc cref="NuGetSourcesListSettings.Format"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.Format))]
    public static T SetFormat<T>(this T o, NuGetSourcesListFormat v) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.Format, v));
    /// <inheritdoc cref="NuGetSourcesListSettings.Format"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.Format))]
    public static T ResetFormat<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Remove(() => o.Format));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="NuGetSourcesListSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="NuGetSourcesListSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ForceEnglishOutput
    /// <inheritdoc cref="NuGetSourcesListSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.ForceEnglishOutput))]
    public static T SetForceEnglishOutput<T>(this T o, bool? v) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, v));
    /// <inheritdoc cref="NuGetSourcesListSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.ForceEnglishOutput))]
    public static T ResetForceEnglishOutput<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Remove(() => o.ForceEnglishOutput));
    /// <inheritdoc cref="NuGetSourcesListSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.ForceEnglishOutput))]
    public static T EnableForceEnglishOutput<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, true));
    /// <inheritdoc cref="NuGetSourcesListSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.ForceEnglishOutput))]
    public static T DisableForceEnglishOutput<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, false));
    /// <inheritdoc cref="NuGetSourcesListSettings.ForceEnglishOutput"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.ForceEnglishOutput))]
    public static T ToggleForceEnglishOutput<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.ForceEnglishOutput, !o.ForceEnglishOutput));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="NuGetSourcesListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="NuGetSourcesListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="NuGetSourcesListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="NuGetSourcesListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="NuGetSourcesListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="NuGetSourcesListSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, NuGetVerbosity v) where T : NuGetSourcesListSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="NuGetSourcesListSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(NuGetSourcesListSettings), Property = nameof(NuGetSourcesListSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : NuGetSourcesListSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
}
#endregion
#region NuGetVerbosity
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetVerbosity>))]
public partial class NuGetVerbosity : Enumeration
{
    public static NuGetVerbosity Normal = (NuGetVerbosity) "Normal";
    public static NuGetVerbosity Quiet = (NuGetVerbosity) "Quiet";
    public static NuGetVerbosity Detailed = (NuGetVerbosity) "Detailed";
    public static implicit operator NuGetVerbosity(string value)
    {
        return new NuGetVerbosity { Value = value };
    }
}
#endregion
#region PackageSaveMode
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PackageSaveMode>))]
public partial class PackageSaveMode : Enumeration
{
    public static PackageSaveMode Nuspec = (PackageSaveMode) "Nuspec";
    public static PackageSaveMode Nupkg = (PackageSaveMode) "Nupkg";
    public static implicit operator PackageSaveMode(string value)
    {
        return new PackageSaveMode { Value = value };
    }
}
#endregion
#region NuGetMSBuildVersion
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetMSBuildVersion>))]
public partial class NuGetMSBuildVersion : Enumeration
{
    public static NuGetMSBuildVersion _4 = (NuGetMSBuildVersion) "4";
    public static NuGetMSBuildVersion _12 = (NuGetMSBuildVersion) "12";
    public static NuGetMSBuildVersion _14 = (NuGetMSBuildVersion) "14";
    public static implicit operator NuGetMSBuildVersion(string value)
    {
        return new NuGetMSBuildVersion { Value = value };
    }
}
#endregion
#region NuGetSymbolPackageFormat
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetSymbolPackageFormat>))]
public partial class NuGetSymbolPackageFormat : Enumeration
{
    public static NuGetSymbolPackageFormat symbols_nupkg = (NuGetSymbolPackageFormat) "symbols.nupkg";
    public static NuGetSymbolPackageFormat snupkg = (NuGetSymbolPackageFormat) "snupkg";
    public static implicit operator NuGetSymbolPackageFormat(string value)
    {
        return new NuGetSymbolPackageFormat { Value = value };
    }
}
#endregion
#region NuGetSourcesListFormat
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NuGetSourcesListFormat>))]
public partial class NuGetSourcesListFormat : Enumeration
{
    public static NuGetSourcesListFormat Detailed = (NuGetSourcesListFormat) "Detailed";
    public static NuGetSourcesListFormat Short = (NuGetSourcesListFormat) "Short";
    public static implicit operator NuGetSourcesListFormat(string value)
    {
        return new NuGetSourcesListFormat { Value = value };
    }
}
#endregion
#region DependencyVersion
/// <summary>Used within <see cref="NuGetTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<DependencyVersion>))]
public partial class DependencyVersion : Enumeration
{
    public static DependencyVersion Lowest = (DependencyVersion) "Lowest";
    public static DependencyVersion HighestPatch = (DependencyVersion) "HighestPatch";
    public static DependencyVersion HighestMinor = (DependencyVersion) "HighestMinor";
    public static DependencyVersion Highest = (DependencyVersion) "Highest";
    public static DependencyVersion Ignore = (DependencyVersion) "Ignore";
    public static implicit operator DependencyVersion(string value)
    {
        return new DependencyVersion { Value = value };
    }
}
#endregion
