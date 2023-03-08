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

namespace Nuke.Common.Tools.NuGet
{
    /// <summary>
    ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(NuGetPackageId)]
    public partial class NuGetTasks
        : IRequireNuGetPackage
    {
        public const string NuGetPackageId = "NuGet.CommandLine";
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public static string NuGetPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("NUGET_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("NuGet.CommandLine", "NuGet.exe");
        public static Action<OutputType, string> NuGetLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> NuGet(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(NuGetPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? NuGetLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPushSettings.TargetPath"/></li>
        ///     <li><c>-ApiKey</c> via <see cref="NuGetPushSettings.ApiKey"/></li>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetPushSettings.ConfigFile"/></li>
        ///     <li><c>-DisableBuffering</c> via <see cref="NuGetPushSettings.DisableBuffering"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetPushSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetPushSettings.NonInteractive"/></li>
        ///     <li><c>-NoSymbols</c> via <see cref="NuGetPushSettings.NoSymbols"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetPushSettings.Source"/></li>
        ///     <li><c>-SymbolApiKey</c> via <see cref="NuGetPushSettings.SymbolApiKey"/></li>
        ///     <li><c>-SymbolSource</c> via <see cref="NuGetPushSettings.SymbolSource"/></li>
        ///     <li><c>-Timeout</c> via <see cref="NuGetPushSettings.Timeout"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetPushSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetPush(NuGetPushSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NuGetPushSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPushSettings.TargetPath"/></li>
        ///     <li><c>-ApiKey</c> via <see cref="NuGetPushSettings.ApiKey"/></li>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetPushSettings.ConfigFile"/></li>
        ///     <li><c>-DisableBuffering</c> via <see cref="NuGetPushSettings.DisableBuffering"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetPushSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetPushSettings.NonInteractive"/></li>
        ///     <li><c>-NoSymbols</c> via <see cref="NuGetPushSettings.NoSymbols"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetPushSettings.Source"/></li>
        ///     <li><c>-SymbolApiKey</c> via <see cref="NuGetPushSettings.SymbolApiKey"/></li>
        ///     <li><c>-SymbolSource</c> via <see cref="NuGetPushSettings.SymbolSource"/></li>
        ///     <li><c>-Timeout</c> via <see cref="NuGetPushSettings.Timeout"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetPushSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetPush(Configure<NuGetPushSettings> configurator)
        {
            return NuGetPush(configurator(new NuGetPushSettings()));
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPushSettings.TargetPath"/></li>
        ///     <li><c>-ApiKey</c> via <see cref="NuGetPushSettings.ApiKey"/></li>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetPushSettings.ConfigFile"/></li>
        ///     <li><c>-DisableBuffering</c> via <see cref="NuGetPushSettings.DisableBuffering"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetPushSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetPushSettings.NonInteractive"/></li>
        ///     <li><c>-NoSymbols</c> via <see cref="NuGetPushSettings.NoSymbols"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetPushSettings.Source"/></li>
        ///     <li><c>-SymbolApiKey</c> via <see cref="NuGetPushSettings.SymbolApiKey"/></li>
        ///     <li><c>-SymbolSource</c> via <see cref="NuGetPushSettings.SymbolSource"/></li>
        ///     <li><c>-Timeout</c> via <see cref="NuGetPushSettings.Timeout"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetPushSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NuGetPushSettings Settings, IReadOnlyCollection<Output> Output)> NuGetPush(CombinatorialConfigure<NuGetPushSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NuGetPush, NuGetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPackSettings.TargetPath"/></li>
        ///     <li><c>-BasePath</c> via <see cref="NuGetPackSettings.BasePath"/></li>
        ///     <li><c>-Build</c> via <see cref="NuGetPackSettings.Build"/></li>
        ///     <li><c>-Exclude</c> via <see cref="NuGetPackSettings.Exclude"/></li>
        ///     <li><c>-ExcludeEmptyDirectories</c> via <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetPackSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-IncludeReferencedProjects</c> via <see cref="NuGetPackSettings.IncludeReferencedProjects"/></li>
        ///     <li><c>-MinClientVersion</c> via <see cref="NuGetPackSettings.MinClientVersion"/></li>
        ///     <li><c>-MSBuildPath</c> via <see cref="NuGetPackSettings.MSBuildPath"/></li>
        ///     <li><c>-MSBuildVersion</c> via <see cref="NuGetPackSettings.MSBuildVersion"/></li>
        ///     <li><c>-NoDefaultExcludes</c> via <see cref="NuGetPackSettings.NoDefaultExcludes"/></li>
        ///     <li><c>-NoPackageAnalysis</c> via <see cref="NuGetPackSettings.NoPackageAnalysis"/></li>
        ///     <li><c>-OutputDirectory</c> via <see cref="NuGetPackSettings.OutputDirectory"/></li>
        ///     <li><c>-Properties</c> via <see cref="NuGetPackSettings.Properties"/></li>
        ///     <li><c>-Suffix</c> via <see cref="NuGetPackSettings.Suffix"/></li>
        ///     <li><c>-SymbolPackageFormat</c> via <see cref="NuGetPackSettings.SymbolPackageFormat"/></li>
        ///     <li><c>-Symbols</c> via <see cref="NuGetPackSettings.Symbols"/></li>
        ///     <li><c>-Tool</c> via <see cref="NuGetPackSettings.Tool"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetPackSettings.Verbosity"/></li>
        ///     <li><c>-Version</c> via <see cref="NuGetPackSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetPack(NuGetPackSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NuGetPackSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPackSettings.TargetPath"/></li>
        ///     <li><c>-BasePath</c> via <see cref="NuGetPackSettings.BasePath"/></li>
        ///     <li><c>-Build</c> via <see cref="NuGetPackSettings.Build"/></li>
        ///     <li><c>-Exclude</c> via <see cref="NuGetPackSettings.Exclude"/></li>
        ///     <li><c>-ExcludeEmptyDirectories</c> via <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetPackSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-IncludeReferencedProjects</c> via <see cref="NuGetPackSettings.IncludeReferencedProjects"/></li>
        ///     <li><c>-MinClientVersion</c> via <see cref="NuGetPackSettings.MinClientVersion"/></li>
        ///     <li><c>-MSBuildPath</c> via <see cref="NuGetPackSettings.MSBuildPath"/></li>
        ///     <li><c>-MSBuildVersion</c> via <see cref="NuGetPackSettings.MSBuildVersion"/></li>
        ///     <li><c>-NoDefaultExcludes</c> via <see cref="NuGetPackSettings.NoDefaultExcludes"/></li>
        ///     <li><c>-NoPackageAnalysis</c> via <see cref="NuGetPackSettings.NoPackageAnalysis"/></li>
        ///     <li><c>-OutputDirectory</c> via <see cref="NuGetPackSettings.OutputDirectory"/></li>
        ///     <li><c>-Properties</c> via <see cref="NuGetPackSettings.Properties"/></li>
        ///     <li><c>-Suffix</c> via <see cref="NuGetPackSettings.Suffix"/></li>
        ///     <li><c>-SymbolPackageFormat</c> via <see cref="NuGetPackSettings.SymbolPackageFormat"/></li>
        ///     <li><c>-Symbols</c> via <see cref="NuGetPackSettings.Symbols"/></li>
        ///     <li><c>-Tool</c> via <see cref="NuGetPackSettings.Tool"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetPackSettings.Verbosity"/></li>
        ///     <li><c>-Version</c> via <see cref="NuGetPackSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetPack(Configure<NuGetPackSettings> configurator)
        {
            return NuGetPack(configurator(new NuGetPackSettings()));
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="NuGetPackSettings.TargetPath"/></li>
        ///     <li><c>-BasePath</c> via <see cref="NuGetPackSettings.BasePath"/></li>
        ///     <li><c>-Build</c> via <see cref="NuGetPackSettings.Build"/></li>
        ///     <li><c>-Exclude</c> via <see cref="NuGetPackSettings.Exclude"/></li>
        ///     <li><c>-ExcludeEmptyDirectories</c> via <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetPackSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-IncludeReferencedProjects</c> via <see cref="NuGetPackSettings.IncludeReferencedProjects"/></li>
        ///     <li><c>-MinClientVersion</c> via <see cref="NuGetPackSettings.MinClientVersion"/></li>
        ///     <li><c>-MSBuildPath</c> via <see cref="NuGetPackSettings.MSBuildPath"/></li>
        ///     <li><c>-MSBuildVersion</c> via <see cref="NuGetPackSettings.MSBuildVersion"/></li>
        ///     <li><c>-NoDefaultExcludes</c> via <see cref="NuGetPackSettings.NoDefaultExcludes"/></li>
        ///     <li><c>-NoPackageAnalysis</c> via <see cref="NuGetPackSettings.NoPackageAnalysis"/></li>
        ///     <li><c>-OutputDirectory</c> via <see cref="NuGetPackSettings.OutputDirectory"/></li>
        ///     <li><c>-Properties</c> via <see cref="NuGetPackSettings.Properties"/></li>
        ///     <li><c>-Suffix</c> via <see cref="NuGetPackSettings.Suffix"/></li>
        ///     <li><c>-SymbolPackageFormat</c> via <see cref="NuGetPackSettings.SymbolPackageFormat"/></li>
        ///     <li><c>-Symbols</c> via <see cref="NuGetPackSettings.Symbols"/></li>
        ///     <li><c>-Tool</c> via <see cref="NuGetPackSettings.Tool"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetPackSettings.Verbosity"/></li>
        ///     <li><c>-Version</c> via <see cref="NuGetPackSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NuGetPackSettings Settings, IReadOnlyCollection<Output> Output)> NuGetPack(CombinatorialConfigure<NuGetPackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NuGetPack, NuGetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="NuGetRestoreSettings.TargetPath"/></li>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetRestoreSettings.ConfigFile"/></li>
        ///     <li><c>-DirectDownload</c> via <see cref="NuGetRestoreSettings.DirectDownload"/></li>
        ///     <li><c>-DisableParallelProcessing</c> via <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></li>
        ///     <li><c>-FallbackSource</c> via <see cref="NuGetRestoreSettings.FallbackSource"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-MSBuildPath</c> via <see cref="NuGetRestoreSettings.MSBuildPath"/></li>
        ///     <li><c>-MSBuildVersion</c> via <see cref="NuGetRestoreSettings.MSBuildVersion"/></li>
        ///     <li><c>-NoCache</c> via <see cref="NuGetRestoreSettings.NoCache"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetRestoreSettings.NonInteractive"/></li>
        ///     <li><c>-OutputDirectory</c> via <see cref="NuGetRestoreSettings.OutputDirectory"/></li>
        ///     <li><c>-PackageSaveMode</c> via <see cref="NuGetRestoreSettings.PackageSaveMode"/></li>
        ///     <li><c>-PackagesDirectory</c> via <see cref="NuGetRestoreSettings.PackagesDirectory"/></li>
        ///     <li><c>-Project2ProjectTimeOut</c> via <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/></li>
        ///     <li><c>-Recursive</c> via <see cref="NuGetRestoreSettings.Recursive"/></li>
        ///     <li><c>-RequireConsent</c> via <see cref="NuGetRestoreSettings.RequireConsent"/></li>
        ///     <li><c>-SolutionDirectory</c> via <see cref="NuGetRestoreSettings.SolutionDirectory"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetRestoreSettings.Source"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetRestoreSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetRestore(NuGetRestoreSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NuGetRestoreSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="NuGetRestoreSettings.TargetPath"/></li>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetRestoreSettings.ConfigFile"/></li>
        ///     <li><c>-DirectDownload</c> via <see cref="NuGetRestoreSettings.DirectDownload"/></li>
        ///     <li><c>-DisableParallelProcessing</c> via <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></li>
        ///     <li><c>-FallbackSource</c> via <see cref="NuGetRestoreSettings.FallbackSource"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-MSBuildPath</c> via <see cref="NuGetRestoreSettings.MSBuildPath"/></li>
        ///     <li><c>-MSBuildVersion</c> via <see cref="NuGetRestoreSettings.MSBuildVersion"/></li>
        ///     <li><c>-NoCache</c> via <see cref="NuGetRestoreSettings.NoCache"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetRestoreSettings.NonInteractive"/></li>
        ///     <li><c>-OutputDirectory</c> via <see cref="NuGetRestoreSettings.OutputDirectory"/></li>
        ///     <li><c>-PackageSaveMode</c> via <see cref="NuGetRestoreSettings.PackageSaveMode"/></li>
        ///     <li><c>-PackagesDirectory</c> via <see cref="NuGetRestoreSettings.PackagesDirectory"/></li>
        ///     <li><c>-Project2ProjectTimeOut</c> via <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/></li>
        ///     <li><c>-Recursive</c> via <see cref="NuGetRestoreSettings.Recursive"/></li>
        ///     <li><c>-RequireConsent</c> via <see cref="NuGetRestoreSettings.RequireConsent"/></li>
        ///     <li><c>-SolutionDirectory</c> via <see cref="NuGetRestoreSettings.SolutionDirectory"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetRestoreSettings.Source"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetRestoreSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetRestore(Configure<NuGetRestoreSettings> configurator)
        {
            return NuGetRestore(configurator(new NuGetRestoreSettings()));
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="NuGetRestoreSettings.TargetPath"/></li>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetRestoreSettings.ConfigFile"/></li>
        ///     <li><c>-DirectDownload</c> via <see cref="NuGetRestoreSettings.DirectDownload"/></li>
        ///     <li><c>-DisableParallelProcessing</c> via <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></li>
        ///     <li><c>-FallbackSource</c> via <see cref="NuGetRestoreSettings.FallbackSource"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-MSBuildPath</c> via <see cref="NuGetRestoreSettings.MSBuildPath"/></li>
        ///     <li><c>-MSBuildVersion</c> via <see cref="NuGetRestoreSettings.MSBuildVersion"/></li>
        ///     <li><c>-NoCache</c> via <see cref="NuGetRestoreSettings.NoCache"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetRestoreSettings.NonInteractive"/></li>
        ///     <li><c>-OutputDirectory</c> via <see cref="NuGetRestoreSettings.OutputDirectory"/></li>
        ///     <li><c>-PackageSaveMode</c> via <see cref="NuGetRestoreSettings.PackageSaveMode"/></li>
        ///     <li><c>-PackagesDirectory</c> via <see cref="NuGetRestoreSettings.PackagesDirectory"/></li>
        ///     <li><c>-Project2ProjectTimeOut</c> via <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/></li>
        ///     <li><c>-Recursive</c> via <see cref="NuGetRestoreSettings.Recursive"/></li>
        ///     <li><c>-RequireConsent</c> via <see cref="NuGetRestoreSettings.RequireConsent"/></li>
        ///     <li><c>-SolutionDirectory</c> via <see cref="NuGetRestoreSettings.SolutionDirectory"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetRestoreSettings.Source"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetRestoreSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NuGetRestoreSettings Settings, IReadOnlyCollection<Output> Output)> NuGetRestore(CombinatorialConfigure<NuGetRestoreSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NuGetRestore, NuGetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageID&gt;</c> via <see cref="NuGetInstallSettings.PackageID"/></li>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetInstallSettings.ConfigFile"/></li>
        ///     <li><c>-DependencyVersion</c> via <see cref="NuGetInstallSettings.DependencyVersion"/></li>
        ///     <li><c>-DisableParallelProcessing</c> via <see cref="NuGetInstallSettings.DisableParallelProcessing"/></li>
        ///     <li><c>-ExcludeVersion</c> via <see cref="NuGetInstallSettings.ExcludeVersion"/></li>
        ///     <li><c>-FallbackSource</c> via <see cref="NuGetInstallSettings.FallbackSource"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetInstallSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Framework</c> via <see cref="NuGetInstallSettings.Framework"/></li>
        ///     <li><c>-NoCache</c> via <see cref="NuGetInstallSettings.NoCache"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetInstallSettings.NonInteractive"/></li>
        ///     <li><c>-OutputDirectory</c> via <see cref="NuGetInstallSettings.OutputDirectory"/></li>
        ///     <li><c>-PackageSaveMode</c> via <see cref="NuGetInstallSettings.PackageSaveMode"/></li>
        ///     <li><c>-PreRelease</c> via <see cref="NuGetInstallSettings.PreRelease"/></li>
        ///     <li><c>-RequireConsent</c> via <see cref="NuGetInstallSettings.RequireConsent"/></li>
        ///     <li><c>-SolutionDirectory</c> via <see cref="NuGetInstallSettings.SolutionDirectory"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetInstallSettings.Source"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetInstallSettings.Verbosity"/></li>
        ///     <li><c>-Version</c> via <see cref="NuGetInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetInstall(NuGetInstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NuGetInstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageID&gt;</c> via <see cref="NuGetInstallSettings.PackageID"/></li>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetInstallSettings.ConfigFile"/></li>
        ///     <li><c>-DependencyVersion</c> via <see cref="NuGetInstallSettings.DependencyVersion"/></li>
        ///     <li><c>-DisableParallelProcessing</c> via <see cref="NuGetInstallSettings.DisableParallelProcessing"/></li>
        ///     <li><c>-ExcludeVersion</c> via <see cref="NuGetInstallSettings.ExcludeVersion"/></li>
        ///     <li><c>-FallbackSource</c> via <see cref="NuGetInstallSettings.FallbackSource"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetInstallSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Framework</c> via <see cref="NuGetInstallSettings.Framework"/></li>
        ///     <li><c>-NoCache</c> via <see cref="NuGetInstallSettings.NoCache"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetInstallSettings.NonInteractive"/></li>
        ///     <li><c>-OutputDirectory</c> via <see cref="NuGetInstallSettings.OutputDirectory"/></li>
        ///     <li><c>-PackageSaveMode</c> via <see cref="NuGetInstallSettings.PackageSaveMode"/></li>
        ///     <li><c>-PreRelease</c> via <see cref="NuGetInstallSettings.PreRelease"/></li>
        ///     <li><c>-RequireConsent</c> via <see cref="NuGetInstallSettings.RequireConsent"/></li>
        ///     <li><c>-SolutionDirectory</c> via <see cref="NuGetInstallSettings.SolutionDirectory"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetInstallSettings.Source"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetInstallSettings.Verbosity"/></li>
        ///     <li><c>-Version</c> via <see cref="NuGetInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetInstall(Configure<NuGetInstallSettings> configurator)
        {
            return NuGetInstall(configurator(new NuGetInstallSettings()));
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageID&gt;</c> via <see cref="NuGetInstallSettings.PackageID"/></li>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetInstallSettings.ConfigFile"/></li>
        ///     <li><c>-DependencyVersion</c> via <see cref="NuGetInstallSettings.DependencyVersion"/></li>
        ///     <li><c>-DisableParallelProcessing</c> via <see cref="NuGetInstallSettings.DisableParallelProcessing"/></li>
        ///     <li><c>-ExcludeVersion</c> via <see cref="NuGetInstallSettings.ExcludeVersion"/></li>
        ///     <li><c>-FallbackSource</c> via <see cref="NuGetInstallSettings.FallbackSource"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetInstallSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Framework</c> via <see cref="NuGetInstallSettings.Framework"/></li>
        ///     <li><c>-NoCache</c> via <see cref="NuGetInstallSettings.NoCache"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetInstallSettings.NonInteractive"/></li>
        ///     <li><c>-OutputDirectory</c> via <see cref="NuGetInstallSettings.OutputDirectory"/></li>
        ///     <li><c>-PackageSaveMode</c> via <see cref="NuGetInstallSettings.PackageSaveMode"/></li>
        ///     <li><c>-PreRelease</c> via <see cref="NuGetInstallSettings.PreRelease"/></li>
        ///     <li><c>-RequireConsent</c> via <see cref="NuGetInstallSettings.RequireConsent"/></li>
        ///     <li><c>-SolutionDirectory</c> via <see cref="NuGetInstallSettings.SolutionDirectory"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetInstallSettings.Source"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetInstallSettings.Verbosity"/></li>
        ///     <li><c>-Version</c> via <see cref="NuGetInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NuGetInstallSettings Settings, IReadOnlyCollection<Output> Output)> NuGetInstall(CombinatorialConfigure<NuGetInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NuGetInstall, NuGetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesAddSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesAddSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesAddSettings.NonInteractive"/></li>
        ///     <li><c>-Password</c> via <see cref="NuGetSourcesAddSettings.Password"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetSourcesAddSettings.Source"/></li>
        ///     <li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></li>
        ///     <li><c>-UserName</c> via <see cref="NuGetSourcesAddSettings.UserName"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesAddSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesAdd(NuGetSourcesAddSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NuGetSourcesAddSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesAddSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesAddSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesAddSettings.NonInteractive"/></li>
        ///     <li><c>-Password</c> via <see cref="NuGetSourcesAddSettings.Password"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetSourcesAddSettings.Source"/></li>
        ///     <li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></li>
        ///     <li><c>-UserName</c> via <see cref="NuGetSourcesAddSettings.UserName"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesAddSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesAdd(Configure<NuGetSourcesAddSettings> configurator)
        {
            return NuGetSourcesAdd(configurator(new NuGetSourcesAddSettings()));
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesAddSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesAddSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesAddSettings.NonInteractive"/></li>
        ///     <li><c>-Password</c> via <see cref="NuGetSourcesAddSettings.Password"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetSourcesAddSettings.Source"/></li>
        ///     <li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></li>
        ///     <li><c>-UserName</c> via <see cref="NuGetSourcesAddSettings.UserName"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesAddSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NuGetSourcesAddSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesAdd(CombinatorialConfigure<NuGetSourcesAddSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NuGetSourcesAdd, NuGetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesUpdateSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesUpdateSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></li>
        ///     <li><c>-Password</c> via <see cref="NuGetSourcesUpdateSettings.Password"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetSourcesUpdateSettings.Source"/></li>
        ///     <li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></li>
        ///     <li><c>-UserName</c> via <see cref="NuGetSourcesUpdateSettings.UserName"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesUpdateSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesUpdate(NuGetSourcesUpdateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NuGetSourcesUpdateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesUpdateSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesUpdateSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></li>
        ///     <li><c>-Password</c> via <see cref="NuGetSourcesUpdateSettings.Password"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetSourcesUpdateSettings.Source"/></li>
        ///     <li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></li>
        ///     <li><c>-UserName</c> via <see cref="NuGetSourcesUpdateSettings.UserName"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesUpdateSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesUpdate(Configure<NuGetSourcesUpdateSettings> configurator)
        {
            return NuGetSourcesUpdate(configurator(new NuGetSourcesUpdateSettings()));
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesUpdateSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesUpdateSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></li>
        ///     <li><c>-Password</c> via <see cref="NuGetSourcesUpdateSettings.Password"/></li>
        ///     <li><c>-Source</c> via <see cref="NuGetSourcesUpdateSettings.Source"/></li>
        ///     <li><c>-StorePasswordInClearText</c> via <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></li>
        ///     <li><c>-UserName</c> via <see cref="NuGetSourcesUpdateSettings.UserName"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesUpdateSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NuGetSourcesUpdateSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesUpdate(CombinatorialConfigure<NuGetSourcesUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NuGetSourcesUpdate, NuGetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesRemoveSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesRemoveSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesRemoveSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesRemove(NuGetSourcesRemoveSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NuGetSourcesRemoveSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesRemoveSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesRemoveSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesRemoveSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesRemove(Configure<NuGetSourcesRemoveSettings> configurator)
        {
            return NuGetSourcesRemove(configurator(new NuGetSourcesRemoveSettings()));
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesRemoveSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesRemoveSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesRemoveSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NuGetSourcesRemoveSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesRemove(CombinatorialConfigure<NuGetSourcesRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NuGetSourcesRemove, NuGetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesEnableSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesEnableSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesEnableSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesEnableSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesEnable(NuGetSourcesEnableSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NuGetSourcesEnableSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesEnableSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesEnableSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesEnableSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesEnableSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesEnable(Configure<NuGetSourcesEnableSettings> configurator)
        {
            return NuGetSourcesEnable(configurator(new NuGetSourcesEnableSettings()));
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesEnableSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesEnableSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesEnableSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesEnableSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NuGetSourcesEnableSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesEnable(CombinatorialConfigure<NuGetSourcesEnableSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NuGetSourcesEnable, NuGetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesDisableSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesDisableSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesDisableSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesDisableSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesDisable(NuGetSourcesDisableSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NuGetSourcesDisableSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesDisableSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesDisableSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesDisableSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesDisableSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesDisable(Configure<NuGetSourcesDisableSettings> configurator)
        {
            return NuGetSourcesDisable(configurator(new NuGetSourcesDisableSettings()));
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesDisableSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Name</c> via <see cref="NuGetSourcesDisableSettings.Name"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesDisableSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesDisableSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NuGetSourcesDisableSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesDisable(CombinatorialConfigure<NuGetSourcesDisableSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NuGetSourcesDisable, NuGetLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesListSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Format</c> via <see cref="NuGetSourcesListSettings.Format"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesListSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesListSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesList(NuGetSourcesListSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NuGetSourcesListSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesListSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Format</c> via <see cref="NuGetSourcesListSettings.Format"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesListSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesListSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NuGetSourcesList(Configure<NuGetSourcesListSettings> configurator)
        {
            return NuGetSourcesList(configurator(new NuGetSourcesListSettings()));
        }
        /// <summary>
        ///   <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-ConfigFile</c> via <see cref="NuGetSourcesListSettings.ConfigFile"/></li>
        ///     <li><c>-ForceEnglishOutput</c> via <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></li>
        ///     <li><c>-Format</c> via <see cref="NuGetSourcesListSettings.Format"/></li>
        ///     <li><c>-NonInteractive</c> via <see cref="NuGetSourcesListSettings.NonInteractive"/></li>
        ///     <li><c>-Verbosity</c> via <see cref="NuGetSourcesListSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NuGetSourcesListSettings Settings, IReadOnlyCollection<Output> Output)> NuGetSourcesList(CombinatorialConfigure<NuGetSourcesListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NuGetSourcesList, NuGetLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region NuGetPushSettings
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetPushSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NuGetTasks.NuGetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NuGetTasks.NuGetLogger;
        /// <summary>
        ///   Path of the package to push.
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   The API key for the target repository. If not present, the one specified in <em>%AppData%\NuGet\NuGet.Config</em> is used.
        /// </summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary>
        ///   Specifies the server URL. NuGet identifies a UNC or local folder source and simply copies the file there instead of pushing it using HTTP.  Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <em>NuGet.Config</em> file specifies a <em>DefaultPushSource</em> value (see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>).
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org
        /// </summary>
        public virtual string SymbolSource { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Specifies the API key for the URL specified in <c>-SymbolSource</c>.
        /// </summary>
        public virtual string SymbolApiKey { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.
        /// </summary>
        public virtual bool? NoSymbols { get; internal set; }
        /// <summary>
        ///   Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.
        /// </summary>
        public virtual bool? DisableBuffering { get; internal set; }
        /// <summary>
        ///   The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.
        /// </summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   Suppresses prompts for user input or confirmations.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).
        /// </summary>
        public virtual int? Timeout { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("push")
              .Add("{value}", TargetPath)
              .Add("-ApiKey {value}", ApiKey, secret: true)
              .Add("-Source {value}", Source)
              .Add("-SymbolSource {value}", SymbolSource)
              .Add("-SymbolApiKey {value}", SymbolApiKey, secret: true)
              .Add("-NoSymbols", NoSymbols)
              .Add("-DisableBuffering", DisableBuffering)
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-NonInteractive", NonInteractive)
              .Add("-Timeout {value}", Timeout);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NuGetPackSettings
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetPackSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NuGetTasks.NuGetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NuGetTasks.NuGetLogger;
        /// <summary>
        ///   The <c>.nuspec</c> or <c>.csproj</c> file.
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   Sets the base path of the files defined in the <c>.nuspec</c> file.
        /// </summary>
        public virtual string BasePath { get; internal set; }
        /// <summary>
        ///   Specifies that the project should be built before building the package.
        /// </summary>
        public virtual bool? Build { get; internal set; }
        /// <summary>
        ///   Specifies one or more wildcard patterns to exclude when creating a package. To specify more than one pattern, repeat the <c>-Exclude</c> flag.
        /// </summary>
        public virtual string Exclude { get; internal set; }
        /// <summary>
        ///   Prevent inclusion of empty directories when building the package.
        /// </summary>
        public virtual bool? ExcludeEmptyDirectories { get; internal set; }
        /// <summary>
        ///   Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.
        /// </summary>
        public virtual bool? IncludeReferencedProjects { get; internal set; }
        /// <summary>
        ///   Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.
        /// </summary>
        public virtual bool? MinClientVersion { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   <em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.
        /// </summary>
        public virtual string MSBuildPath { get; internal set; }
        /// <summary>
        ///   <em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.
        /// </summary>
        public virtual NuGetMSBuildVersion MSBuildVersion { get; internal set; }
        /// <summary>
        ///   Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.
        /// </summary>
        public virtual bool? NoDefaultExcludes { get; internal set; }
        /// <summary>
        ///   Specifies that pack should not run package analysis after building the package.
        /// </summary>
        public virtual bool? NoPackageAnalysis { get; internal set; }
        /// <summary>
        ///   Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   <em>(3.4.4+)</em> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.
        /// </summary>
        public virtual string Suffix { get; internal set; }
        /// <summary>
        ///   Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.
        /// </summary>
        public virtual bool? Symbols { get; internal set; }
        /// <summary>
        ///   Specifies that the output files of the project should be placed in the <c>tool</c> folder.
        /// </summary>
        public virtual bool? Tool { get; internal set; }
        /// <summary>
        ///   Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.
        /// </summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Overrides the version number from the <c>.nuspec</c> file.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   Format for packaging symbols.
        /// </summary>
        public virtual NuGetSymbolPackageFormat SymbolPackageFormat { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("pack")
              .Add("{value}", TargetPath)
              .Add("-BasePath {value}", BasePath)
              .Add("-Build", Build)
              .Add("-Exclude {value}", Exclude)
              .Add("-ExcludeEmptyDirectories", ExcludeEmptyDirectories)
              .Add("-IncludeReferencedProjects", IncludeReferencedProjects)
              .Add("-MinClientVersion", MinClientVersion)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-MSBuildPath {value}", MSBuildPath)
              .Add("-MSBuildVersion {value}", MSBuildVersion)
              .Add("-NoDefaultExcludes", NoDefaultExcludes)
              .Add("-NoPackageAnalysis", NoPackageAnalysis)
              .Add("-OutputDirectory {value}", OutputDirectory)
              .Add("-Properties {value}", Properties, "{key}={value}", separator: ';')
              .Add("-Suffix {value}", Suffix)
              .Add("-Symbols", Symbols)
              .Add("-Tool", Tool)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-Version {value}", Version)
              .Add("-SymbolPackageFormat {value}", SymbolPackageFormat);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NuGetRestoreSettings
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetRestoreSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NuGetTasks.NuGetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NuGetTasks.NuGetLogger;
        /// <summary>
        ///   Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   <em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.
        /// </summary>
        public virtual bool? DirectDownload { get; internal set; }
        /// <summary>
        ///   Disables restoring multiple packages in parallel.
        /// </summary>
        public virtual bool? DisableParallelProcessing { get; internal set; }
        /// <summary>
        ///   <em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.
        /// </summary>
        public virtual IReadOnlyList<string> FallbackSource => FallbackSourceInternal.AsReadOnly();
        internal List<string> FallbackSourceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   <em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   <em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.
        /// </summary>
        public virtual string MSBuildPath { get; internal set; }
        /// <summary>
        ///   <em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>, <em>15</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.
        /// </summary>
        public virtual NuGetMSBuildVersion MSBuildVersion { get; internal set; }
        /// <summary>
        ///   Prevents NuGet from using packages from local machine caches.
        /// </summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary>
        ///   Suppresses prompts for user input or confirmations.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.
        /// </summary>
        public virtual IReadOnlyList<PackageSaveMode> PackageSaveMode => PackageSaveModeInternal.AsReadOnly();
        internal List<PackageSaveMode> PackageSaveModeInternal { get; set; } = new List<PackageSaveMode>();
        /// <summary>
        ///   Same as <c>OutputDirectory</c>.
        /// </summary>
        public virtual string PackagesDirectory { get; internal set; }
        /// <summary>
        ///   Timeout in seconds for resolving project-to-project references.
        /// </summary>
        public virtual int? Project2ProjectTimeOut { get; internal set; }
        /// <summary>
        ///   <em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.
        /// </summary>
        public virtual bool? Recursive { get; internal set; }
        /// <summary>
        ///   Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.
        /// </summary>
        public virtual bool? RequireConsent { get; internal set; }
        /// <summary>
        ///   Specifies the solution folder. Not valid when restoring packages for a solution.
        /// </summary>
        public virtual string SolutionDirectory { get; internal set; }
        /// <summary>
        ///   Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.
        /// </summary>
        public virtual IReadOnlyList<string> Source => SourceInternal.AsReadOnly();
        internal List<string> SourceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.
        /// </summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("restore")
              .Add("{value}", TargetPath)
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-DirectDownload", DirectDownload)
              .Add("-DisableParallelProcessing", DisableParallelProcessing)
              .Add("-FallbackSource {value}", FallbackSource, separator: ';')
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-MSBuildPath {value}", MSBuildPath)
              .Add("-MSBuildVersion {value}", MSBuildVersion)
              .Add("-NoCache", NoCache)
              .Add("-NonInteractive", NonInteractive)
              .Add("-OutputDirectory {value}", OutputDirectory)
              .Add("-PackageSaveMode {value}", PackageSaveMode, separator: ';')
              .Add("-PackagesDirectory {value}", PackagesDirectory)
              .Add("-Project2ProjectTimeOut {value}", Project2ProjectTimeOut)
              .Add("-Recursive", Recursive)
              .Add("-RequireConsent", RequireConsent)
              .Add("-SolutionDirectory {value}", SolutionDirectory)
              .Add("-Source {value}", Source, separator: ';')
              .Add("-Verbosity {value}", Verbosity);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NuGetInstallSettings
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetInstallSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NuGetTasks.NuGetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NuGetTasks.NuGetLogger;
        /// <summary>
        ///   Name of the package to install.
        /// </summary>
        public virtual string PackageID { get; internal set; }
        /// <summary>
        ///   <em>(4.4+)</em> The version of the dependency packages to use, which can be one of the following: <ul><li><c>Lowest</c>: (default) the lowest version.</li> <li><c>HighestPatch</c>: the version with the lowest major, lowest minor, highest patch.</li> <li><c>HighestMinor</c>: the version with the lowest major, highest minor, highest patch.</li> <li><c>Highest</c>: the highest version.</li> <li><c>Ignore</c>: No dependency packages will be used.</li></ul>
        /// </summary>
        public virtual DependencyVersion DependencyVersion { get; internal set; }
        /// <summary>
        ///   Disables installing multiple packages in parallel.
        /// </summary>
        public virtual bool? DisableParallelProcessing { get; internal set; }
        /// <summary>
        ///   Installs the package to a folder named with only the package name and not the version number.
        /// </summary>
        public virtual bool? ExcludeVersion { get; internal set; }
        /// <summary>
        ///   <em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.
        /// </summary>
        public virtual IReadOnlyList<string> FallbackSource => FallbackSourceInternal.AsReadOnly();
        internal List<string> FallbackSourceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   <em>(4.4+)</em> Target framework used for selecting dependencies. Defaults to 'Any' if not specified.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   Prevents NuGet from using cached packages. See <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/managing-the-global-packages-and-cache-folders">Managing the global packages and cache folders</a>.
        /// </summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary>
        ///   Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.
        /// </summary>
        public virtual IReadOnlyList<PackageSaveMode> PackageSaveMode => PackageSaveModeInternal.AsReadOnly();
        internal List<PackageSaveMode> PackageSaveModeInternal { get; set; } = new List<PackageSaveMode>();
        /// <summary>
        ///   Allows prerelease packages to be installed. This flag is not required when restoring packages with <c>packages.config</c>.
        /// </summary>
        public virtual bool? PreRelease { get; internal set; }
        /// <summary>
        ///   Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.
        /// </summary>
        public virtual bool? RequireConsent { get; internal set; }
        /// <summary>
        ///   Specifies root folder of the solution for which to restore packages.
        /// </summary>
        public virtual string SolutionDirectory { get; internal set; }
        /// <summary>
        ///   Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Common NuGet configurations</a>.
        /// </summary>
        public virtual IReadOnlyList<string> Source => SourceInternal.AsReadOnly();
        internal List<string> SourceInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specifies the version of the package to install.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   Suppresses prompts for user input or confirmations.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.
        /// </summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("install")
              .Add("{value}", PackageID)
              .Add("-DependencyVersion {value}", DependencyVersion)
              .Add("-DisableParallelProcessing", DisableParallelProcessing)
              .Add("-ExcludeVersion", ExcludeVersion)
              .Add("-FallbackSource {value}", FallbackSource, separator: ';')
              .Add("-Framework {value}", Framework)
              .Add("-NoCache", NoCache)
              .Add("-OutputDirectory {value}", OutputDirectory)
              .Add("-PackageSaveMode {value}", PackageSaveMode, separator: ';')
              .Add("-PreRelease", PreRelease)
              .Add("-RequireConsent", RequireConsent)
              .Add("-SolutionDirectory {value}", SolutionDirectory)
              .Add("-Source {value}", Source, separator: ';')
              .Add("-Version {value}", Version)
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-NonInteractive", NonInteractive)
              .Add("-Verbosity {value}", Verbosity);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NuGetSourcesAddSettings
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetSourcesAddSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NuGetTasks.NuGetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NuGetTasks.NuGetLogger;
        /// <summary>
        ///   The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   Suppresses prompts for user input or confirmations.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.
        /// </summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Name of the source.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   URL of the source.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   Specifies the password for authenticating with the source.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.
        /// </summary>
        public virtual bool? StorePasswordInClearText { get; internal set; }
        /// <summary>
        ///   Specifies the user name for authenticating with the source.
        /// </summary>
        public virtual string UserName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("sources add")
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-NonInteractive", NonInteractive)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-Name {value}", Name)
              .Add("-Source {value}", Source)
              .Add("-Password {value}", Password, secret: true)
              .Add("-StorePasswordInClearText", StorePasswordInClearText)
              .Add("-UserName {value}", UserName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NuGetSourcesUpdateSettings
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetSourcesUpdateSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NuGetTasks.NuGetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NuGetTasks.NuGetLogger;
        /// <summary>
        ///   The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   Suppresses prompts for user input or confirmations.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.
        /// </summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Name of the source.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   URL of the source.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   Specifies the password for authenticating with the source.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.
        /// </summary>
        public virtual bool? StorePasswordInClearText { get; internal set; }
        /// <summary>
        ///   Specifies the user name for authenticating with the source.
        /// </summary>
        public virtual string UserName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("sources update")
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-NonInteractive", NonInteractive)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-Name {value}", Name)
              .Add("-Source {value}", Source)
              .Add("-Password {value}", Password, secret: true)
              .Add("-StorePasswordInClearText", StorePasswordInClearText)
              .Add("-UserName {value}", UserName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NuGetSourcesRemoveSettings
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetSourcesRemoveSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NuGetTasks.NuGetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NuGetTasks.NuGetLogger;
        /// <summary>
        ///   The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   Suppresses prompts for user input or confirmations.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.
        /// </summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Name of the source.
        /// </summary>
        public virtual string Name { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("sources remove")
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-NonInteractive", NonInteractive)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-Name {value}", Name);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NuGetSourcesEnableSettings
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetSourcesEnableSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NuGetTasks.NuGetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NuGetTasks.NuGetLogger;
        /// <summary>
        ///   The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   Suppresses prompts for user input or confirmations.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.
        /// </summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Name of the source.
        /// </summary>
        public virtual string Name { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("sources enable")
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-NonInteractive", NonInteractive)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-Name {value}", Name);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NuGetSourcesDisableSettings
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetSourcesDisableSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NuGetTasks.NuGetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NuGetTasks.NuGetLogger;
        /// <summary>
        ///   The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   Suppresses prompts for user input or confirmations.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.
        /// </summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Name of the source.
        /// </summary>
        public virtual string Name { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("sources disable")
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-NonInteractive", NonInteractive)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-Name {value}", Name);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NuGetSourcesListSettings
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetSourcesListSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NuGet executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NuGetTasks.NuGetPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NuGetTasks.NuGetLogger;
        /// <summary>
        ///   Can be <c>Detailed</c> (the default) or <c>Short</c>.
        /// </summary>
        public virtual NuGetSourcesListFormat Format { get; internal set; }
        /// <summary>
        ///   The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   <em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.
        /// </summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary>
        ///   Suppresses prompts for user input or confirmations.
        /// </summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary>
        ///   Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.
        /// </summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("sources list")
              .Add("-Format {value}", Format)
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-NonInteractive", NonInteractive)
              .Add("-Verbosity {value}", Verbosity);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NuGetPushSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetPushSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.TargetPath"/></em></p>
        ///   <p>Path of the package to push.</p>
        /// </summary>
        [Pure]
        public static T SetTargetPath<T>(this T toolSettings, string targetPath) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.TargetPath"/></em></p>
        ///   <p>Path of the package to push.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPath<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.ApiKey"/></em></p>
        ///   <p>The API key for the target repository. If not present, the one specified in <em>%AppData%\NuGet\NuGet.Config</em> is used.</p>
        /// </summary>
        [Pure]
        public static T SetApiKey<T>(this T toolSettings, [Secret] string apiKey) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.ApiKey"/></em></p>
        ///   <p>The API key for the target repository. If not present, the one specified in <em>%AppData%\NuGet\NuGet.Config</em> is used.</p>
        /// </summary>
        [Pure]
        public static T ResetApiKey<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.Source"/></em></p>
        ///   <p>Specifies the server URL. NuGet identifies a UNC or local folder source and simply copies the file there instead of pushing it using HTTP.  Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <em>NuGet.Config</em> file specifies a <em>DefaultPushSource</em> value (see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>).</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.Source"/></em></p>
        ///   <p>Specifies the server URL. NuGet identifies a UNC or local folder source and simply copies the file there instead of pushing it using HTTP.  Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <em>NuGet.Config</em> file specifies a <em>DefaultPushSource</em> value (see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>).</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region SymbolSource
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.SymbolSource"/></em></p>
        ///   <p><em>(3.5+)</em> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p>
        /// </summary>
        [Pure]
        public static T SetSymbolSource<T>(this T toolSettings, string symbolSource) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSource = symbolSource;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.SymbolSource"/></em></p>
        ///   <p><em>(3.5+)</em> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolSource<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSource = null;
            return toolSettings;
        }
        #endregion
        #region SymbolApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.SymbolApiKey"/></em></p>
        ///   <p><em>(3.5+)</em> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolApiKey<T>(this T toolSettings, [Secret] string symbolApiKey) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolApiKey = symbolApiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.SymbolApiKey"/></em></p>
        ///   <p><em>(3.5+)</em> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolApiKey<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolApiKey = null;
            return toolSettings;
        }
        #endregion
        #region NoSymbols
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.NoSymbols"/></em></p>
        ///   <p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p>
        /// </summary>
        [Pure]
        public static T SetNoSymbols<T>(this T toolSettings, bool? noSymbols) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = noSymbols;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.NoSymbols"/></em></p>
        ///   <p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p>
        /// </summary>
        [Pure]
        public static T ResetNoSymbols<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPushSettings.NoSymbols"/></em></p>
        ///   <p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p>
        /// </summary>
        [Pure]
        public static T EnableNoSymbols<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPushSettings.NoSymbols"/></em></p>
        ///   <p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p>
        /// </summary>
        [Pure]
        public static T DisableNoSymbols<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPushSettings.NoSymbols"/></em></p>
        ///   <p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoSymbols<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = !toolSettings.NoSymbols;
            return toolSettings;
        }
        #endregion
        #region DisableBuffering
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.DisableBuffering"/></em></p>
        ///   <p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p>
        /// </summary>
        [Pure]
        public static T SetDisableBuffering<T>(this T toolSettings, bool? disableBuffering) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = disableBuffering;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.DisableBuffering"/></em></p>
        ///   <p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableBuffering<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPushSettings.DisableBuffering"/></em></p>
        ///   <p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableBuffering<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPushSettings.DisableBuffering"/></em></p>
        ///   <p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableBuffering<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPushSettings.DisableBuffering"/></em></p>
        ///   <p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableBuffering<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = !toolSettings.DisableBuffering;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, NuGetVerbosity verbosity) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPushSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPushSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPushSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPushSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPushSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPushSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPushSettings.Timeout"/></em></p>
        ///   <p>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, int? timeout) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPushSettings.Timeout"/></em></p>
        ///   <p>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : NuGetPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetPackSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetPackSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.TargetPath"/></em></p>
        ///   <p>The <c>.nuspec</c> or <c>.csproj</c> file.</p>
        /// </summary>
        [Pure]
        public static T SetTargetPath<T>(this T toolSettings, string targetPath) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.TargetPath"/></em></p>
        ///   <p>The <c>.nuspec</c> or <c>.csproj</c> file.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPath<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region BasePath
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.BasePath"/></em></p>
        ///   <p>Sets the base path of the files defined in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static T SetBasePath<T>(this T toolSettings, string basePath) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = basePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.BasePath"/></em></p>
        ///   <p>Sets the base path of the files defined in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static T ResetBasePath<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = null;
            return toolSettings;
        }
        #endregion
        #region Build
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.Build"/></em></p>
        ///   <p>Specifies that the project should be built before building the package.</p>
        /// </summary>
        [Pure]
        public static T SetBuild<T>(this T toolSettings, bool? build) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = build;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.Build"/></em></p>
        ///   <p>Specifies that the project should be built before building the package.</p>
        /// </summary>
        [Pure]
        public static T ResetBuild<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPackSettings.Build"/></em></p>
        ///   <p>Specifies that the project should be built before building the package.</p>
        /// </summary>
        [Pure]
        public static T EnableBuild<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPackSettings.Build"/></em></p>
        ///   <p>Specifies that the project should be built before building the package.</p>
        /// </summary>
        [Pure]
        public static T DisableBuild<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPackSettings.Build"/></em></p>
        ///   <p>Specifies that the project should be built before building the package.</p>
        /// </summary>
        [Pure]
        public static T ToggleBuild<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = !toolSettings.Build;
            return toolSettings;
        }
        #endregion
        #region Exclude
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.Exclude"/></em></p>
        ///   <p>Specifies one or more wildcard patterns to exclude when creating a package. To specify more than one pattern, repeat the <c>-Exclude</c> flag.</p>
        /// </summary>
        [Pure]
        public static T SetExclude<T>(this T toolSettings, string exclude) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exclude = exclude;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.Exclude"/></em></p>
        ///   <p>Specifies one or more wildcard patterns to exclude when creating a package. To specify more than one pattern, repeat the <c>-Exclude</c> flag.</p>
        /// </summary>
        [Pure]
        public static T ResetExclude<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exclude = null;
            return toolSettings;
        }
        #endregion
        #region ExcludeEmptyDirectories
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></em></p>
        ///   <p>Prevent inclusion of empty directories when building the package.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeEmptyDirectories<T>(this T toolSettings, bool? excludeEmptyDirectories) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = excludeEmptyDirectories;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></em></p>
        ///   <p>Prevent inclusion of empty directories when building the package.</p>
        /// </summary>
        [Pure]
        public static T ResetExcludeEmptyDirectories<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></em></p>
        ///   <p>Prevent inclusion of empty directories when building the package.</p>
        /// </summary>
        [Pure]
        public static T EnableExcludeEmptyDirectories<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></em></p>
        ///   <p>Prevent inclusion of empty directories when building the package.</p>
        /// </summary>
        [Pure]
        public static T DisableExcludeEmptyDirectories<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/></em></p>
        ///   <p>Prevent inclusion of empty directories when building the package.</p>
        /// </summary>
        [Pure]
        public static T ToggleExcludeEmptyDirectories<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = !toolSettings.ExcludeEmptyDirectories;
            return toolSettings;
        }
        #endregion
        #region IncludeReferencedProjects
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.IncludeReferencedProjects"/></em></p>
        ///   <p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p>
        /// </summary>
        [Pure]
        public static T SetIncludeReferencedProjects<T>(this T toolSettings, bool? includeReferencedProjects) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = includeReferencedProjects;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.IncludeReferencedProjects"/></em></p>
        ///   <p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p>
        /// </summary>
        [Pure]
        public static T ResetIncludeReferencedProjects<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPackSettings.IncludeReferencedProjects"/></em></p>
        ///   <p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p>
        /// </summary>
        [Pure]
        public static T EnableIncludeReferencedProjects<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPackSettings.IncludeReferencedProjects"/></em></p>
        ///   <p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p>
        /// </summary>
        [Pure]
        public static T DisableIncludeReferencedProjects<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPackSettings.IncludeReferencedProjects"/></em></p>
        ///   <p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p>
        /// </summary>
        [Pure]
        public static T ToggleIncludeReferencedProjects<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = !toolSettings.IncludeReferencedProjects;
            return toolSettings;
        }
        #endregion
        #region MinClientVersion
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.MinClientVersion"/></em></p>
        ///   <p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static T SetMinClientVersion<T>(this T toolSettings, bool? minClientVersion) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = minClientVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.MinClientVersion"/></em></p>
        ///   <p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static T ResetMinClientVersion<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPackSettings.MinClientVersion"/></em></p>
        ///   <p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static T EnableMinClientVersion<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPackSettings.MinClientVersion"/></em></p>
        ///   <p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static T DisableMinClientVersion<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPackSettings.MinClientVersion"/></em></p>
        ///   <p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static T ToggleMinClientVersion<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = !toolSettings.MinClientVersion;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPackSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPackSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPackSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region MSBuildPath
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.MSBuildPath"/></em></p>
        ///   <p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p>
        /// </summary>
        [Pure]
        public static T SetMSBuildPath<T>(this T toolSettings, string msbuildPath) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPath = msbuildPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.MSBuildPath"/></em></p>
        ///   <p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetMSBuildPath<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPath = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildVersion
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.MSBuildVersion"/></em></p>
        ///   <p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p>
        /// </summary>
        [Pure]
        public static T SetMSBuildVersion<T>(this T toolSettings, NuGetMSBuildVersion msbuildVersion) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = msbuildVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.MSBuildVersion"/></em></p>
        ///   <p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p>
        /// </summary>
        [Pure]
        public static T ResetMSBuildVersion<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = null;
            return toolSettings;
        }
        #endregion
        #region NoDefaultExcludes
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.NoDefaultExcludes"/></em></p>
        ///   <p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p>
        /// </summary>
        [Pure]
        public static T SetNoDefaultExcludes<T>(this T toolSettings, bool? noDefaultExcludes) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = noDefaultExcludes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.NoDefaultExcludes"/></em></p>
        ///   <p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetNoDefaultExcludes<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPackSettings.NoDefaultExcludes"/></em></p>
        ///   <p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableNoDefaultExcludes<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPackSettings.NoDefaultExcludes"/></em></p>
        ///   <p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableNoDefaultExcludes<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPackSettings.NoDefaultExcludes"/></em></p>
        ///   <p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoDefaultExcludes<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = !toolSettings.NoDefaultExcludes;
            return toolSettings;
        }
        #endregion
        #region NoPackageAnalysis
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.NoPackageAnalysis"/></em></p>
        ///   <p>Specifies that pack should not run package analysis after building the package.</p>
        /// </summary>
        [Pure]
        public static T SetNoPackageAnalysis<T>(this T toolSettings, bool? noPackageAnalysis) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = noPackageAnalysis;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.NoPackageAnalysis"/></em></p>
        ///   <p>Specifies that pack should not run package analysis after building the package.</p>
        /// </summary>
        [Pure]
        public static T ResetNoPackageAnalysis<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPackSettings.NoPackageAnalysis"/></em></p>
        ///   <p>Specifies that pack should not run package analysis after building the package.</p>
        /// </summary>
        [Pure]
        public static T EnableNoPackageAnalysis<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPackSettings.NoPackageAnalysis"/></em></p>
        ///   <p>Specifies that pack should not run package analysis after building the package.</p>
        /// </summary>
        [Pure]
        public static T DisableNoPackageAnalysis<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPackSettings.NoPackageAnalysis"/></em></p>
        ///   <p>Specifies that pack should not run package analysis after building the package.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoPackageAnalysis<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = !toolSettings.NoPackageAnalysis;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.OutputDirectory"/></em></p>
        ///   <p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDirectory<T>(this T toolSettings, string outputDirectory) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.OutputDirectory"/></em></p>
        ///   <p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDirectory<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NuGetPackSettings.Properties"/></em></p>
        ///   <p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="NuGetPackSettings.Properties"/></em></p>
        ///   <p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="NuGetPackSettings.Properties"/></em></p>
        ///   <p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="NuGetPackSettings.Properties"/></em></p>
        ///   <p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <c>Configuration</c> in <see cref="NuGetPackSettings.Properties"/></em></p>
        ///   <p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Configuration"] = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <c>Configuration</c> in <see cref="NuGetPackSettings.Properties"/></em></p>
        ///   <p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Configuration");
            return toolSettings;
        }
        #endregion
        #endregion
        #region Suffix
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.Suffix"/></em></p>
        ///   <p><em>(3.4.4+)</em> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p>
        /// </summary>
        [Pure]
        public static T SetSuffix<T>(this T toolSettings, string suffix) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Suffix = suffix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.Suffix"/></em></p>
        ///   <p><em>(3.4.4+)</em> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p>
        /// </summary>
        [Pure]
        public static T ResetSuffix<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Suffix = null;
            return toolSettings;
        }
        #endregion
        #region Symbols
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.Symbols"/></em></p>
        ///   <p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p>
        /// </summary>
        [Pure]
        public static T SetSymbols<T>(this T toolSettings, bool? symbols) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = symbols;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.Symbols"/></em></p>
        ///   <p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbols<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPackSettings.Symbols"/></em></p>
        ///   <p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p>
        /// </summary>
        [Pure]
        public static T EnableSymbols<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPackSettings.Symbols"/></em></p>
        ///   <p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p>
        /// </summary>
        [Pure]
        public static T DisableSymbols<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPackSettings.Symbols"/></em></p>
        ///   <p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p>
        /// </summary>
        [Pure]
        public static T ToggleSymbols<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = !toolSettings.Symbols;
            return toolSettings;
        }
        #endregion
        #region Tool
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.Tool"/></em></p>
        ///   <p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p>
        /// </summary>
        [Pure]
        public static T SetTool<T>(this T toolSettings, bool? tool) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = tool;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.Tool"/></em></p>
        ///   <p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p>
        /// </summary>
        [Pure]
        public static T ResetTool<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetPackSettings.Tool"/></em></p>
        ///   <p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p>
        /// </summary>
        [Pure]
        public static T EnableTool<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetPackSettings.Tool"/></em></p>
        ///   <p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p>
        /// </summary>
        [Pure]
        public static T DisableTool<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetPackSettings.Tool"/></em></p>
        ///   <p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p>
        /// </summary>
        [Pure]
        public static T ToggleTool<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = !toolSettings.Tool;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, NuGetVerbosity verbosity) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.Version"/></em></p>
        ///   <p>Overrides the version number from the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.Version"/></em></p>
        ///   <p>Overrides the version number from the <c>.nuspec</c> file.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region SymbolPackageFormat
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetPackSettings.SymbolPackageFormat"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolPackageFormat<T>(this T toolSettings, NuGetSymbolPackageFormat symbolPackageFormat) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolPackageFormat = symbolPackageFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetPackSettings.SymbolPackageFormat"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolPackageFormat<T>(this T toolSettings) where T : NuGetPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolPackageFormat = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetRestoreSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetRestoreSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.TargetPath"/></em></p>
        ///   <p>Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.</p>
        /// </summary>
        [Pure]
        public static T SetTargetPath<T>(this T toolSettings, string targetPath) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.TargetPath"/></em></p>
        ///   <p>Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPath<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region DirectDownload
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.DirectDownload"/></em></p>
        ///   <p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p>
        /// </summary>
        [Pure]
        public static T SetDirectDownload<T>(this T toolSettings, bool? directDownload) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = directDownload;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.DirectDownload"/></em></p>
        ///   <p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p>
        /// </summary>
        [Pure]
        public static T ResetDirectDownload<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetRestoreSettings.DirectDownload"/></em></p>
        ///   <p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p>
        /// </summary>
        [Pure]
        public static T EnableDirectDownload<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetRestoreSettings.DirectDownload"/></em></p>
        ///   <p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p>
        /// </summary>
        [Pure]
        public static T DisableDirectDownload<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetRestoreSettings.DirectDownload"/></em></p>
        ///   <p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p>
        /// </summary>
        [Pure]
        public static T ToggleDirectDownload<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = !toolSettings.DirectDownload;
            return toolSettings;
        }
        #endregion
        #region DisableParallelProcessing
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></em></p>
        ///   <p>Disables restoring multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static T SetDisableParallelProcessing<T>(this T toolSettings, bool? disableParallelProcessing) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = disableParallelProcessing;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></em></p>
        ///   <p>Disables restoring multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableParallelProcessing<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></em></p>
        ///   <p>Disables restoring multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableParallelProcessing<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></em></p>
        ///   <p>Disables restoring multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableParallelProcessing<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetRestoreSettings.DisableParallelProcessing"/></em></p>
        ///   <p>Disables restoring multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableParallelProcessing<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = !toolSettings.DisableParallelProcessing;
            return toolSettings;
        }
        #endregion
        #region FallbackSource
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.FallbackSource"/> to a new list</em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T SetFallbackSource<T>(this T toolSettings, params string[] fallbackSource) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal = fallbackSource.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.FallbackSource"/> to a new list</em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T SetFallbackSource<T>(this T toolSettings, IEnumerable<string> fallbackSource) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal = fallbackSource.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetRestoreSettings.FallbackSource"/></em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T AddFallbackSource<T>(this T toolSettings, params string[] fallbackSource) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetRestoreSettings.FallbackSource"/></em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T AddFallbackSource<T>(this T toolSettings, IEnumerable<string> fallbackSource) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NuGetRestoreSettings.FallbackSource"/></em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T ClearFallbackSource<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetRestoreSettings.FallbackSource"/></em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T RemoveFallbackSource<T>(this T toolSettings, params string[] fallbackSource) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fallbackSource);
            toolSettings.FallbackSourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetRestoreSettings.FallbackSource"/></em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T RemoveFallbackSource<T>(this T toolSettings, IEnumerable<string> fallbackSource) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fallbackSource);
            toolSettings.FallbackSourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetRestoreSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region MSBuildPath
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.MSBuildPath"/></em></p>
        ///   <p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p>
        /// </summary>
        [Pure]
        public static T SetMSBuildPath<T>(this T toolSettings, string msbuildPath) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPath = msbuildPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.MSBuildPath"/></em></p>
        ///   <p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetMSBuildPath<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPath = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildVersion
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.MSBuildVersion"/></em></p>
        ///   <p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>, <em>15</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p>
        /// </summary>
        [Pure]
        public static T SetMSBuildVersion<T>(this T toolSettings, NuGetMSBuildVersion msbuildVersion) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = msbuildVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.MSBuildVersion"/></em></p>
        ///   <p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>, <em>15</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p>
        /// </summary>
        [Pure]
        public static T ResetMSBuildVersion<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = null;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.NoCache"/></em></p>
        ///   <p>Prevents NuGet from using packages from local machine caches.</p>
        /// </summary>
        [Pure]
        public static T SetNoCache<T>(this T toolSettings, bool? noCache) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.NoCache"/></em></p>
        ///   <p>Prevents NuGet from using packages from local machine caches.</p>
        /// </summary>
        [Pure]
        public static T ResetNoCache<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetRestoreSettings.NoCache"/></em></p>
        ///   <p>Prevents NuGet from using packages from local machine caches.</p>
        /// </summary>
        [Pure]
        public static T EnableNoCache<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetRestoreSettings.NoCache"/></em></p>
        ///   <p>Prevents NuGet from using packages from local machine caches.</p>
        /// </summary>
        [Pure]
        public static T DisableNoCache<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetRestoreSettings.NoCache"/></em></p>
        ///   <p>Prevents NuGet from using packages from local machine caches.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoCache<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetRestoreSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetRestoreSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetRestoreSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.OutputDirectory"/></em></p>
        ///   <p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDirectory<T>(this T toolSettings, string outputDirectory) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.OutputDirectory"/></em></p>
        ///   <p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDirectory<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region PackageSaveMode
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.PackageSaveMode"/> to a new list</em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T SetPackageSaveMode<T>(this T toolSettings, params PackageSaveMode[] packageSaveMode) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal = packageSaveMode.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.PackageSaveMode"/> to a new list</em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T SetPackageSaveMode<T>(this T toolSettings, IEnumerable<PackageSaveMode> packageSaveMode) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal = packageSaveMode.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetRestoreSettings.PackageSaveMode"/></em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T AddPackageSaveMode<T>(this T toolSettings, params PackageSaveMode[] packageSaveMode) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal.AddRange(packageSaveMode);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetRestoreSettings.PackageSaveMode"/></em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T AddPackageSaveMode<T>(this T toolSettings, IEnumerable<PackageSaveMode> packageSaveMode) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal.AddRange(packageSaveMode);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NuGetRestoreSettings.PackageSaveMode"/></em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearPackageSaveMode<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetRestoreSettings.PackageSaveMode"/></em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T RemovePackageSaveMode<T>(this T toolSettings, params PackageSaveMode[] packageSaveMode) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<PackageSaveMode>(packageSaveMode);
            toolSettings.PackageSaveModeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetRestoreSettings.PackageSaveMode"/></em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T RemovePackageSaveMode<T>(this T toolSettings, IEnumerable<PackageSaveMode> packageSaveMode) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<PackageSaveMode>(packageSaveMode);
            toolSettings.PackageSaveModeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region PackagesDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.PackagesDirectory"/></em></p>
        ///   <p>Same as <c>OutputDirectory</c>.</p>
        /// </summary>
        [Pure]
        public static T SetPackagesDirectory<T>(this T toolSettings, string packagesDirectory) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesDirectory = packagesDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.PackagesDirectory"/></em></p>
        ///   <p>Same as <c>OutputDirectory</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetPackagesDirectory<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Project2ProjectTimeOut
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/></em></p>
        ///   <p>Timeout in seconds for resolving project-to-project references.</p>
        /// </summary>
        [Pure]
        public static T SetProject2ProjectTimeOut<T>(this T toolSettings, int? project2ProjectTimeOut) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project2ProjectTimeOut = project2ProjectTimeOut;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/></em></p>
        ///   <p>Timeout in seconds for resolving project-to-project references.</p>
        /// </summary>
        [Pure]
        public static T ResetProject2ProjectTimeOut<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project2ProjectTimeOut = null;
            return toolSettings;
        }
        #endregion
        #region Recursive
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.Recursive"/></em></p>
        ///   <p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static T SetRecursive<T>(this T toolSettings, bool? recursive) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = recursive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.Recursive"/></em></p>
        ///   <p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetRecursive<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetRestoreSettings.Recursive"/></em></p>
        ///   <p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableRecursive<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetRestoreSettings.Recursive"/></em></p>
        ///   <p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableRecursive<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetRestoreSettings.Recursive"/></em></p>
        ///   <p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleRecursive<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = !toolSettings.Recursive;
            return toolSettings;
        }
        #endregion
        #region RequireConsent
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.RequireConsent"/></em></p>
        ///   <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static T SetRequireConsent<T>(this T toolSettings, bool? requireConsent) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = requireConsent;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.RequireConsent"/></em></p>
        ///   <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetRequireConsent<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetRestoreSettings.RequireConsent"/></em></p>
        ///   <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableRequireConsent<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetRestoreSettings.RequireConsent"/></em></p>
        ///   <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableRequireConsent<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetRestoreSettings.RequireConsent"/></em></p>
        ///   <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleRequireConsent<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = !toolSettings.RequireConsent;
            return toolSettings;
        }
        #endregion
        #region SolutionDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.SolutionDirectory"/></em></p>
        ///   <p>Specifies the solution folder. Not valid when restoring packages for a solution.</p>
        /// </summary>
        [Pure]
        public static T SetSolutionDirectory<T>(this T toolSettings, string solutionDirectory) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionDirectory = solutionDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.SolutionDirectory"/></em></p>
        ///   <p>Specifies the solution folder. Not valid when restoring packages for a solution.</p>
        /// </summary>
        [Pure]
        public static T ResetSolutionDirectory<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.Source"/> to a new list</em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, params string[] source) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.Source"/> to a new list</em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, IEnumerable<string> source) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetRestoreSettings.Source"/></em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p>
        /// </summary>
        [Pure]
        public static T AddSource<T>(this T toolSettings, params string[] source) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetRestoreSettings.Source"/></em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p>
        /// </summary>
        [Pure]
        public static T AddSource<T>(this T toolSettings, IEnumerable<string> source) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NuGetRestoreSettings.Source"/></em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p>
        /// </summary>
        [Pure]
        public static T ClearSource<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetRestoreSettings.Source"/></em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p>
        /// </summary>
        [Pure]
        public static T RemoveSource<T>(this T toolSettings, params string[] source) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetRestoreSettings.Source"/></em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p>
        /// </summary>
        [Pure]
        public static T RemoveSource<T>(this T toolSettings, IEnumerable<string> source) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetRestoreSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, NuGetVerbosity verbosity) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetRestoreSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : NuGetRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetInstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetInstallSettingsExtensions
    {
        #region PackageID
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.PackageID"/></em></p>
        ///   <p>Name of the package to install.</p>
        /// </summary>
        [Pure]
        public static T SetPackageID<T>(this T toolSettings, string packageID) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageID = packageID;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.PackageID"/></em></p>
        ///   <p>Name of the package to install.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageID<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageID = null;
            return toolSettings;
        }
        #endregion
        #region DependencyVersion
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.DependencyVersion"/></em></p>
        ///   <p><em>(4.4+)</em> The version of the dependency packages to use, which can be one of the following: <ul><li><c>Lowest</c>: (default) the lowest version.</li> <li><c>HighestPatch</c>: the version with the lowest major, lowest minor, highest patch.</li> <li><c>HighestMinor</c>: the version with the lowest major, highest minor, highest patch.</li> <li><c>Highest</c>: the highest version.</li> <li><c>Ignore</c>: No dependency packages will be used.</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetDependencyVersion<T>(this T toolSettings, DependencyVersion dependencyVersion) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyVersion = dependencyVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.DependencyVersion"/></em></p>
        ///   <p><em>(4.4+)</em> The version of the dependency packages to use, which can be one of the following: <ul><li><c>Lowest</c>: (default) the lowest version.</li> <li><c>HighestPatch</c>: the version with the lowest major, lowest minor, highest patch.</li> <li><c>HighestMinor</c>: the version with the lowest major, highest minor, highest patch.</li> <li><c>Highest</c>: the highest version.</li> <li><c>Ignore</c>: No dependency packages will be used.</li></ul></p>
        /// </summary>
        [Pure]
        public static T ResetDependencyVersion<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyVersion = null;
            return toolSettings;
        }
        #endregion
        #region DisableParallelProcessing
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.DisableParallelProcessing"/></em></p>
        ///   <p>Disables installing multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static T SetDisableParallelProcessing<T>(this T toolSettings, bool? disableParallelProcessing) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = disableParallelProcessing;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.DisableParallelProcessing"/></em></p>
        ///   <p>Disables installing multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableParallelProcessing<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetInstallSettings.DisableParallelProcessing"/></em></p>
        ///   <p>Disables installing multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableParallelProcessing<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetInstallSettings.DisableParallelProcessing"/></em></p>
        ///   <p>Disables installing multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableParallelProcessing<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetInstallSettings.DisableParallelProcessing"/></em></p>
        ///   <p>Disables installing multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableParallelProcessing<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = !toolSettings.DisableParallelProcessing;
            return toolSettings;
        }
        #endregion
        #region ExcludeVersion
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.ExcludeVersion"/></em></p>
        ///   <p>Installs the package to a folder named with only the package name and not the version number.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeVersion<T>(this T toolSettings, bool? excludeVersion) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeVersion = excludeVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.ExcludeVersion"/></em></p>
        ///   <p>Installs the package to a folder named with only the package name and not the version number.</p>
        /// </summary>
        [Pure]
        public static T ResetExcludeVersion<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeVersion = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetInstallSettings.ExcludeVersion"/></em></p>
        ///   <p>Installs the package to a folder named with only the package name and not the version number.</p>
        /// </summary>
        [Pure]
        public static T EnableExcludeVersion<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeVersion = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetInstallSettings.ExcludeVersion"/></em></p>
        ///   <p>Installs the package to a folder named with only the package name and not the version number.</p>
        /// </summary>
        [Pure]
        public static T DisableExcludeVersion<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeVersion = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetInstallSettings.ExcludeVersion"/></em></p>
        ///   <p>Installs the package to a folder named with only the package name and not the version number.</p>
        /// </summary>
        [Pure]
        public static T ToggleExcludeVersion<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeVersion = !toolSettings.ExcludeVersion;
            return toolSettings;
        }
        #endregion
        #region FallbackSource
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.FallbackSource"/> to a new list</em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T SetFallbackSource<T>(this T toolSettings, params string[] fallbackSource) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal = fallbackSource.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.FallbackSource"/> to a new list</em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T SetFallbackSource<T>(this T toolSettings, IEnumerable<string> fallbackSource) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal = fallbackSource.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetInstallSettings.FallbackSource"/></em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T AddFallbackSource<T>(this T toolSettings, params string[] fallbackSource) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetInstallSettings.FallbackSource"/></em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T AddFallbackSource<T>(this T toolSettings, IEnumerable<string> fallbackSource) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NuGetInstallSettings.FallbackSource"/></em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T ClearFallbackSource<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetInstallSettings.FallbackSource"/></em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T RemoveFallbackSource<T>(this T toolSettings, params string[] fallbackSource) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fallbackSource);
            toolSettings.FallbackSourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetInstallSettings.FallbackSource"/></em></p>
        ///   <p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static T RemoveFallbackSource<T>(this T toolSettings, IEnumerable<string> fallbackSource) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fallbackSource);
            toolSettings.FallbackSourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.Framework"/></em></p>
        ///   <p><em>(4.4+)</em> Target framework used for selecting dependencies. Defaults to 'Any' if not specified.</p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.Framework"/></em></p>
        ///   <p><em>(4.4+)</em> Target framework used for selecting dependencies. Defaults to 'Any' if not specified.</p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.NoCache"/></em></p>
        ///   <p>Prevents NuGet from using cached packages. See <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/managing-the-global-packages-and-cache-folders">Managing the global packages and cache folders</a>.</p>
        /// </summary>
        [Pure]
        public static T SetNoCache<T>(this T toolSettings, bool? noCache) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.NoCache"/></em></p>
        ///   <p>Prevents NuGet from using cached packages. See <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/managing-the-global-packages-and-cache-folders">Managing the global packages and cache folders</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetNoCache<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetInstallSettings.NoCache"/></em></p>
        ///   <p>Prevents NuGet from using cached packages. See <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/managing-the-global-packages-and-cache-folders">Managing the global packages and cache folders</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableNoCache<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetInstallSettings.NoCache"/></em></p>
        ///   <p>Prevents NuGet from using cached packages. See <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/managing-the-global-packages-and-cache-folders">Managing the global packages and cache folders</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableNoCache<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetInstallSettings.NoCache"/></em></p>
        ///   <p>Prevents NuGet from using cached packages. See <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/managing-the-global-packages-and-cache-folders">Managing the global packages and cache folders</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoCache<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.OutputDirectory"/></em></p>
        ///   <p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDirectory<T>(this T toolSettings, string outputDirectory) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.OutputDirectory"/></em></p>
        ///   <p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDirectory<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region PackageSaveMode
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.PackageSaveMode"/> to a new list</em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T SetPackageSaveMode<T>(this T toolSettings, params PackageSaveMode[] packageSaveMode) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal = packageSaveMode.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.PackageSaveMode"/> to a new list</em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T SetPackageSaveMode<T>(this T toolSettings, IEnumerable<PackageSaveMode> packageSaveMode) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal = packageSaveMode.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetInstallSettings.PackageSaveMode"/></em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T AddPackageSaveMode<T>(this T toolSettings, params PackageSaveMode[] packageSaveMode) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal.AddRange(packageSaveMode);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetInstallSettings.PackageSaveMode"/></em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T AddPackageSaveMode<T>(this T toolSettings, IEnumerable<PackageSaveMode> packageSaveMode) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal.AddRange(packageSaveMode);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NuGetInstallSettings.PackageSaveMode"/></em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearPackageSaveMode<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetInstallSettings.PackageSaveMode"/></em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T RemovePackageSaveMode<T>(this T toolSettings, params PackageSaveMode[] packageSaveMode) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<PackageSaveMode>(packageSaveMode);
            toolSettings.PackageSaveModeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetInstallSettings.PackageSaveMode"/></em></p>
        ///   <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static T RemovePackageSaveMode<T>(this T toolSettings, IEnumerable<PackageSaveMode> packageSaveMode) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<PackageSaveMode>(packageSaveMode);
            toolSettings.PackageSaveModeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region PreRelease
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.PreRelease"/></em></p>
        ///   <p>Allows prerelease packages to be installed. This flag is not required when restoring packages with <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static T SetPreRelease<T>(this T toolSettings, bool? preRelease) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreRelease = preRelease;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.PreRelease"/></em></p>
        ///   <p>Allows prerelease packages to be installed. This flag is not required when restoring packages with <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetPreRelease<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreRelease = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetInstallSettings.PreRelease"/></em></p>
        ///   <p>Allows prerelease packages to be installed. This flag is not required when restoring packages with <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static T EnablePreRelease<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreRelease = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetInstallSettings.PreRelease"/></em></p>
        ///   <p>Allows prerelease packages to be installed. This flag is not required when restoring packages with <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static T DisablePreRelease<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreRelease = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetInstallSettings.PreRelease"/></em></p>
        ///   <p>Allows prerelease packages to be installed. This flag is not required when restoring packages with <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static T TogglePreRelease<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreRelease = !toolSettings.PreRelease;
            return toolSettings;
        }
        #endregion
        #region RequireConsent
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.RequireConsent"/></em></p>
        ///   <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static T SetRequireConsent<T>(this T toolSettings, bool? requireConsent) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = requireConsent;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.RequireConsent"/></em></p>
        ///   <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetRequireConsent<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetInstallSettings.RequireConsent"/></em></p>
        ///   <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableRequireConsent<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetInstallSettings.RequireConsent"/></em></p>
        ///   <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableRequireConsent<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetInstallSettings.RequireConsent"/></em></p>
        ///   <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleRequireConsent<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = !toolSettings.RequireConsent;
            return toolSettings;
        }
        #endregion
        #region SolutionDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.SolutionDirectory"/></em></p>
        ///   <p>Specifies root folder of the solution for which to restore packages.</p>
        /// </summary>
        [Pure]
        public static T SetSolutionDirectory<T>(this T toolSettings, string solutionDirectory) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionDirectory = solutionDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.SolutionDirectory"/></em></p>
        ///   <p>Specifies root folder of the solution for which to restore packages.</p>
        /// </summary>
        [Pure]
        public static T ResetSolutionDirectory<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.Source"/> to a new list</em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Common NuGet configurations</a>.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, params string[] source) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.Source"/> to a new list</em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Common NuGet configurations</a>.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, IEnumerable<string> source) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetInstallSettings.Source"/></em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Common NuGet configurations</a>.</p>
        /// </summary>
        [Pure]
        public static T AddSource<T>(this T toolSettings, params string[] source) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NuGetInstallSettings.Source"/></em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Common NuGet configurations</a>.</p>
        /// </summary>
        [Pure]
        public static T AddSource<T>(this T toolSettings, IEnumerable<string> source) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NuGetInstallSettings.Source"/></em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Common NuGet configurations</a>.</p>
        /// </summary>
        [Pure]
        public static T ClearSource<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetInstallSettings.Source"/></em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Common NuGet configurations</a>.</p>
        /// </summary>
        [Pure]
        public static T RemoveSource<T>(this T toolSettings, params string[] source) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NuGetInstallSettings.Source"/></em></p>
        ///   <p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Common NuGet configurations</a>.</p>
        /// </summary>
        [Pure]
        public static T RemoveSource<T>(this T toolSettings, IEnumerable<string> source) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.Version"/></em></p>
        ///   <p>Specifies the version of the package to install.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.Version"/></em></p>
        ///   <p>Specifies the version of the package to install.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetInstallSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetInstallSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetInstallSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetInstallSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetInstallSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetInstallSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetInstallSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, NuGetVerbosity verbosity) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetInstallSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : NuGetInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetSourcesAddSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetSourcesAddSettingsExtensions
    {
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesAddSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesAddSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesAddSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesAddSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesAddSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesAddSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesAddSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesAddSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesAddSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, NuGetVerbosity verbosity) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesAddSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesAddSettings.Name"/></em></p>
        ///   <p>Name of the source.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesAddSettings.Name"/></em></p>
        ///   <p>Name of the source.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesAddSettings.Source"/></em></p>
        ///   <p>URL of the source.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesAddSettings.Source"/></em></p>
        ///   <p>URL of the source.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesAddSettings.Password"/></em></p>
        ///   <p>Specifies the password for authenticating with the source.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesAddSettings.Password"/></em></p>
        ///   <p>Specifies the password for authenticating with the source.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region StorePasswordInClearText
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></em></p>
        ///   <p>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</p>
        /// </summary>
        [Pure]
        public static T SetStorePasswordInClearText<T>(this T toolSettings, bool? storePasswordInClearText) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StorePasswordInClearText = storePasswordInClearText;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></em></p>
        ///   <p>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</p>
        /// </summary>
        [Pure]
        public static T ResetStorePasswordInClearText<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StorePasswordInClearText = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></em></p>
        ///   <p>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</p>
        /// </summary>
        [Pure]
        public static T EnableStorePasswordInClearText<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StorePasswordInClearText = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></em></p>
        ///   <p>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</p>
        /// </summary>
        [Pure]
        public static T DisableStorePasswordInClearText<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StorePasswordInClearText = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesAddSettings.StorePasswordInClearText"/></em></p>
        ///   <p>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</p>
        /// </summary>
        [Pure]
        public static T ToggleStorePasswordInClearText<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StorePasswordInClearText = !toolSettings.StorePasswordInClearText;
            return toolSettings;
        }
        #endregion
        #region UserName
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesAddSettings.UserName"/></em></p>
        ///   <p>Specifies the user name for authenticating with the source.</p>
        /// </summary>
        [Pure]
        public static T SetUserName<T>(this T toolSettings, string userName) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = userName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesAddSettings.UserName"/></em></p>
        ///   <p>Specifies the user name for authenticating with the source.</p>
        /// </summary>
        [Pure]
        public static T ResetUserName<T>(this T toolSettings) where T : NuGetSourcesAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetSourcesUpdateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetSourcesUpdateSettingsExtensions
    {
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesUpdateSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesUpdateSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesUpdateSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesUpdateSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesUpdateSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, NuGetVerbosity verbosity) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesUpdateSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesUpdateSettings.Name"/></em></p>
        ///   <p>Name of the source.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesUpdateSettings.Name"/></em></p>
        ///   <p>Name of the source.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesUpdateSettings.Source"/></em></p>
        ///   <p>URL of the source.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesUpdateSettings.Source"/></em></p>
        ///   <p>URL of the source.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesUpdateSettings.Password"/></em></p>
        ///   <p>Specifies the password for authenticating with the source.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesUpdateSettings.Password"/></em></p>
        ///   <p>Specifies the password for authenticating with the source.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region StorePasswordInClearText
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></em></p>
        ///   <p>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</p>
        /// </summary>
        [Pure]
        public static T SetStorePasswordInClearText<T>(this T toolSettings, bool? storePasswordInClearText) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StorePasswordInClearText = storePasswordInClearText;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></em></p>
        ///   <p>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</p>
        /// </summary>
        [Pure]
        public static T ResetStorePasswordInClearText<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StorePasswordInClearText = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></em></p>
        ///   <p>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</p>
        /// </summary>
        [Pure]
        public static T EnableStorePasswordInClearText<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StorePasswordInClearText = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></em></p>
        ///   <p>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</p>
        /// </summary>
        [Pure]
        public static T DisableStorePasswordInClearText<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StorePasswordInClearText = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesUpdateSettings.StorePasswordInClearText"/></em></p>
        ///   <p>Indicates to store the password in unencrypted text instead of the default behavior of storing an encrypted form.</p>
        /// </summary>
        [Pure]
        public static T ToggleStorePasswordInClearText<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StorePasswordInClearText = !toolSettings.StorePasswordInClearText;
            return toolSettings;
        }
        #endregion
        #region UserName
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesUpdateSettings.UserName"/></em></p>
        ///   <p>Specifies the user name for authenticating with the source.</p>
        /// </summary>
        [Pure]
        public static T SetUserName<T>(this T toolSettings, string userName) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = userName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesUpdateSettings.UserName"/></em></p>
        ///   <p>Specifies the user name for authenticating with the source.</p>
        /// </summary>
        [Pure]
        public static T ResetUserName<T>(this T toolSettings) where T : NuGetSourcesUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetSourcesRemoveSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetSourcesRemoveSettingsExtensions
    {
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesRemoveSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesRemoveSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesRemoveSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesRemoveSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesRemoveSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, NuGetVerbosity verbosity) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesRemoveSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesRemoveSettings.Name"/></em></p>
        ///   <p>Name of the source.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesRemoveSettings.Name"/></em></p>
        ///   <p>Name of the source.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : NuGetSourcesRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetSourcesEnableSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetSourcesEnableSettingsExtensions
    {
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesEnableSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesEnableSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesEnableSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesEnableSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesEnableSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesEnableSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesEnableSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesEnableSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesEnableSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, NuGetVerbosity verbosity) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesEnableSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesEnableSettings.Name"/></em></p>
        ///   <p>Name of the source.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesEnableSettings.Name"/></em></p>
        ///   <p>Name of the source.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : NuGetSourcesEnableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetSourcesDisableSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetSourcesDisableSettingsExtensions
    {
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesDisableSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesDisableSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesDisableSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesDisableSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesDisableSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesDisableSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesDisableSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesDisableSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesDisableSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, NuGetVerbosity verbosity) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesDisableSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesDisableSettings.Name"/></em></p>
        ///   <p>Name of the source.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesDisableSettings.Name"/></em></p>
        ///   <p>Name of the source.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : NuGetSourcesDisableSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetSourcesListSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetSourcesListSettingsExtensions
    {
        #region Format
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesListSettings.Format"/></em></p>
        ///   <p>Can be <c>Detailed</c> (the default) or <c>Short</c>.</p>
        /// </summary>
        [Pure]
        public static T SetFormat<T>(this T toolSettings, NuGetSourcesListFormat format) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = format;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesListSettings.Format"/></em></p>
        ///   <p>Can be <c>Detailed</c> (the default) or <c>Short</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetFormat<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesListSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesListSettings.ConfigFile"/></em></p>
        ///   <p>The NuGet configuration file to apply. If not specified, <c>%AppData%\NuGet\NuGet.Config</c> (Windows) or <c>~/.nuget/NuGet/NuGet.Config</c> (Mac/Linux) is used.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T SetForceEnglishOutput<T>(this T toolSettings, bool? forceEnglishOutput) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ResetForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T EnableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T DisableForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesListSettings.ForceEnglishOutput"/></em></p>
        ///   <p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceEnglishOutput<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesListSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T SetNonInteractive<T>(this T toolSettings, bool? nonInteractive) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesListSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ResetNonInteractive<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NuGetSourcesListSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T EnableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NuGetSourcesListSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T DisableNonInteractive<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NuGetSourcesListSettings.NonInteractive"/></em></p>
        ///   <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static T ToggleNonInteractive<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="NuGetSourcesListSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, NuGetVerbosity verbosity) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NuGetSourcesListSettings.Verbosity"/></em></p>
        ///   <p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : NuGetSourcesListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetVerbosity
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="NuGetTasks"/>.
    /// </summary>
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
}
