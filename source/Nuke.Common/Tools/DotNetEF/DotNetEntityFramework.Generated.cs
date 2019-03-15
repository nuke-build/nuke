// Generated from https://github.com/RLittlesII/common/blob/master/build/specifications/DotNetEntityFramework.json
// Generated with Nuke.CodeGeneration version LOCAL (Windows,.NETStandard,Version=v2.0)

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

namespace Nuke.Common.Tools.DotNetEF
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetEFTasks
    {
        /// <summary>
        ///   Path to the DotNetEF executable.
        /// </summary>
        public static string DotNetEFPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("DOTNETEF_EXE") ??
            ToolPathResolver.GetPathExecutable("dotnet ef");
        public static Action<OutputType, string> DotNetEFLogger { get; set; } = CustomLogger;
        public static IReadOnlyCollection<Output> DotNetEF(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(DotNetEFPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, DotNetEFLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet ef database drop</c> command is used to drop the database.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotNetEFDatabaseDrop(DotNetEFDatabaseDropSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetEFDatabaseDropSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet ef database drop</c> command is used to drop the database.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFDatabaseDropSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDatabaseDropSettings.Context"/></li>
        ///     <li><c>--dry-run</c> via <see cref="DotNetEFDatabaseDropSettings.DryRun"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetEFDatabaseDropSettings.Force"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFDatabaseDropSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFDatabaseDropSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFDatabaseDropSettings.NoColor"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFDatabaseDropSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFDatabaseDropSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFDatabaseDropSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFDatabaseDropSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFDatabaseDropSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFDatabaseDropSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetEFDatabaseDrop(Configure<DotNetEFDatabaseDropSettings> configurator)
        {
            return DotNetEFDatabaseDrop(configurator(new DotNetEFDatabaseDropSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet ef database drop</c> command is used to drop the database.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFDatabaseDropSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDatabaseDropSettings.Context"/></li>
        ///     <li><c>--dry-run</c> via <see cref="DotNetEFDatabaseDropSettings.DryRun"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetEFDatabaseDropSettings.Force"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFDatabaseDropSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFDatabaseDropSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFDatabaseDropSettings.NoColor"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFDatabaseDropSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFDatabaseDropSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFDatabaseDropSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFDatabaseDropSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFDatabaseDropSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFDatabaseDropSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetEFDatabaseDropSettings Settings, IReadOnlyCollection<Output> Output)> DotNetEFDatabaseDrop(CombinatorialConfigure<DotNetEFDatabaseDropSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetEFDatabaseDrop, DotNetEFLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet ef database update</c> command is used to update the database to the last migration or to a specified migration.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotNetEFDatabaseUpdate(DotNetEFDatabaseUpdateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetEFDatabaseUpdateSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet ef database update</c> command is used to update the database to the last migration or to a specified migration.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;migration&gt;</c> via <see cref="DotNetEFDatabaseUpdateSettings.Migration"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFDatabaseUpdateSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDatabaseUpdateSettings.Context"/></li>
        ///     <li><c>--dry-run</c> via <see cref="DotNetEFDatabaseUpdateSettings.DryRun"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFDatabaseUpdateSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFDatabaseUpdateSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFDatabaseUpdateSettings.NoColor"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFDatabaseUpdateSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFDatabaseUpdateSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFDatabaseUpdateSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFDatabaseUpdateSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFDatabaseUpdateSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFDatabaseUpdateSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetEFDatabaseUpdate(Configure<DotNetEFDatabaseUpdateSettings> configurator)
        {
            return DotNetEFDatabaseUpdate(configurator(new DotNetEFDatabaseUpdateSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet ef database update</c> command is used to update the database to the last migration or to a specified migration.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;migration&gt;</c> via <see cref="DotNetEFDatabaseUpdateSettings.Migration"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFDatabaseUpdateSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDatabaseUpdateSettings.Context"/></li>
        ///     <li><c>--dry-run</c> via <see cref="DotNetEFDatabaseUpdateSettings.DryRun"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFDatabaseUpdateSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFDatabaseUpdateSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFDatabaseUpdateSettings.NoColor"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFDatabaseUpdateSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFDatabaseUpdateSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFDatabaseUpdateSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFDatabaseUpdateSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFDatabaseUpdateSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFDatabaseUpdateSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetEFDatabaseUpdateSettings Settings, IReadOnlyCollection<Output> Output)> DotNetEFDatabaseUpdate(CombinatorialConfigure<DotNetEFDatabaseUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetEFDatabaseUpdate, DotNetEFLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet ef dbcontext info</c> command is used to get information about a <c>DbContext</c> type.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotNetEFDbContextInfo(DotNetEFDbContextInfoSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetEFDbContextInfoSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet ef dbcontext info</c> command is used to get information about a <c>DbContext</c> type.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFDbContextInfoSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDbContextInfoSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFDbContextInfoSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFDbContextInfoSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFDbContextInfoSettings.NoColor"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFDbContextInfoSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFDbContextInfoSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFDbContextInfoSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFDbContextInfoSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFDbContextInfoSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFDbContextInfoSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetEFDbContextInfo(Configure<DotNetEFDbContextInfoSettings> configurator)
        {
            return DotNetEFDbContextInfo(configurator(new DotNetEFDbContextInfoSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet ef dbcontext info</c> command is used to get information about a <c>DbContext</c> type.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFDbContextInfoSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDbContextInfoSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFDbContextInfoSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFDbContextInfoSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFDbContextInfoSettings.NoColor"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFDbContextInfoSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFDbContextInfoSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFDbContextInfoSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFDbContextInfoSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFDbContextInfoSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFDbContextInfoSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetEFDbContextInfoSettings Settings, IReadOnlyCollection<Output> Output)> DotNetEFDbContextInfo(CombinatorialConfigure<DotNetEFDbContextInfoSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetEFDbContextInfo, DotNetEFLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet ef dbcontext list</c> command is used to list available <c>DbContext</c> types.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotNetEFDbContextList(DotNetEFDbContextListSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetEFDbContextListSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet ef dbcontext list</c> command is used to list available <c>DbContext</c> types.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFDbContextListSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDbContextListSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFDbContextListSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFDbContextListSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFDbContextListSettings.NoColor"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFDbContextListSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFDbContextListSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFDbContextListSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFDbContextListSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFDbContextListSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFDbContextListSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetEFDbContextList(Configure<DotNetEFDbContextListSettings> configurator)
        {
            return DotNetEFDbContextList(configurator(new DotNetEFDbContextListSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet ef dbcontext list</c> command is used to list available <c>DbContext</c> types.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFDbContextListSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDbContextListSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFDbContextListSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFDbContextListSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFDbContextListSettings.NoColor"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFDbContextListSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFDbContextListSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFDbContextListSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFDbContextListSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFDbContextListSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFDbContextListSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetEFDbContextListSettings Settings, IReadOnlyCollection<Output> Output)> DotNetEFDbContextList(CombinatorialConfigure<DotNetEFDbContextListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetEFDbContextList, DotNetEFLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet ef dbcontext scaffold</c> command is used to generate code for a <c>DbContext</c> and entity types for a database. In order for this command to generate an entity type, the database table must have a primary key.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotNetEFDbContextScaffold(DotNetEFDbContextScaffoldSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetEFDbContextScaffoldSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet ef dbcontext scaffold</c> command is used to generate code for a <c>DbContext</c> and entity types for a database. In order for this command to generate an entity type, the database table must have a primary key.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;connection&gt;</c> via <see cref="DotNetEFDbContextScaffoldSettings.Connection"/></li>
        ///     <li><c>&lt;provider&gt;</c> via <see cref="DotNetEFDbContextScaffoldSettings.Provider"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFDbContextScaffoldSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDbContextScaffoldSettings.Context"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDbContextScaffoldSettings.Context"/></li>
        ///     <li><c>--context-dir</c> via <see cref="DotNetEFDbContextScaffoldSettings.ContextDirectory"/></li>
        ///     <li><c>--data-annotations</c> via <see cref="DotNetEFDbContextScaffoldSettings.DataAnnotations"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetEFDbContextScaffoldSettings.Force"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFDbContextScaffoldSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFDbContextScaffoldSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFDbContextScaffoldSettings.NoColor"/></li>
        ///     <li><c>--output-dir</c> via <see cref="DotNetEFDbContextScaffoldSettings.OutputDirectory"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFDbContextScaffoldSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFDbContextScaffoldSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFDbContextScaffoldSettings.Runtime"/></li>
        ///     <li><c>--schema</c> via <see cref="DotNetEFDbContextScaffoldSettings.Schema"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFDbContextScaffoldSettings.StartupProject"/></li>
        ///     <li><c>--table</c> via <see cref="DotNetEFDbContextScaffoldSettings.Table"/></li>
        ///     <li><c>--use-database-names</c> via <see cref="DotNetEFDbContextScaffoldSettings.UseDatabaseNames"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFDbContextScaffoldSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFDbContextScaffoldSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetEFDbContextScaffold(Configure<DotNetEFDbContextScaffoldSettings> configurator)
        {
            return DotNetEFDbContextScaffold(configurator(new DotNetEFDbContextScaffoldSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet ef dbcontext scaffold</c> command is used to generate code for a <c>DbContext</c> and entity types for a database. In order for this command to generate an entity type, the database table must have a primary key.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;connection&gt;</c> via <see cref="DotNetEFDbContextScaffoldSettings.Connection"/></li>
        ///     <li><c>&lt;provider&gt;</c> via <see cref="DotNetEFDbContextScaffoldSettings.Provider"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFDbContextScaffoldSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDbContextScaffoldSettings.Context"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFDbContextScaffoldSettings.Context"/></li>
        ///     <li><c>--context-dir</c> via <see cref="DotNetEFDbContextScaffoldSettings.ContextDirectory"/></li>
        ///     <li><c>--data-annotations</c> via <see cref="DotNetEFDbContextScaffoldSettings.DataAnnotations"/></li>
        ///     <li><c>--force</c> via <see cref="DotNetEFDbContextScaffoldSettings.Force"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFDbContextScaffoldSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFDbContextScaffoldSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFDbContextScaffoldSettings.NoColor"/></li>
        ///     <li><c>--output-dir</c> via <see cref="DotNetEFDbContextScaffoldSettings.OutputDirectory"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFDbContextScaffoldSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFDbContextScaffoldSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFDbContextScaffoldSettings.Runtime"/></li>
        ///     <li><c>--schema</c> via <see cref="DotNetEFDbContextScaffoldSettings.Schema"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFDbContextScaffoldSettings.StartupProject"/></li>
        ///     <li><c>--table</c> via <see cref="DotNetEFDbContextScaffoldSettings.Table"/></li>
        ///     <li><c>--use-database-names</c> via <see cref="DotNetEFDbContextScaffoldSettings.UseDatabaseNames"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFDbContextScaffoldSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFDbContextScaffoldSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetEFDbContextScaffoldSettings Settings, IReadOnlyCollection<Output> Output)> DotNetEFDbContextScaffold(CombinatorialConfigure<DotNetEFDbContextScaffoldSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetEFDbContextScaffold, DotNetEFLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations add</c> command is used to add a new migration.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotNetEFMigrationsAdd(DotNetEFMigrationsAddSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetEFMigrationsAddSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations add</c> command is used to add a new migration.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="DotNetEFMigrationsAddSettings.Name"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFMigrationsAddSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFMigrationsAddSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFMigrationsAddSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFMigrationsAddSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFMigrationsAddSettings.NoColor"/></li>
        ///     <li><c>--output-dir</c> via <see cref="DotNetEFMigrationsAddSettings.OutputDirectory"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFMigrationsAddSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFMigrationsAddSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFMigrationsAddSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFMigrationsAddSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFMigrationsAddSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFMigrationsAddSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetEFMigrationsAdd(Configure<DotNetEFMigrationsAddSettings> configurator)
        {
            return DotNetEFMigrationsAdd(configurator(new DotNetEFMigrationsAddSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations add</c> command is used to add a new migration.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="DotNetEFMigrationsAddSettings.Name"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFMigrationsAddSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFMigrationsAddSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFMigrationsAddSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFMigrationsAddSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFMigrationsAddSettings.NoColor"/></li>
        ///     <li><c>--output-dir</c> via <see cref="DotNetEFMigrationsAddSettings.OutputDirectory"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFMigrationsAddSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFMigrationsAddSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFMigrationsAddSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFMigrationsAddSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFMigrationsAddSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFMigrationsAddSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetEFMigrationsAddSettings Settings, IReadOnlyCollection<Output> Output)> DotNetEFMigrationsAdd(CombinatorialConfigure<DotNetEFMigrationsAddSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetEFMigrationsAdd, DotNetEFLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations list</c> command is used to Lists available migrations.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotNetEFMigrationsList(DotNetEFMigrationsListSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetEFMigrationsListSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations list</c> command is used to Lists available migrations.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFMigrationsListSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFMigrationsListSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFMigrationsListSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFMigrationsListSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFMigrationsListSettings.NoColor"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFMigrationsListSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFMigrationsListSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFMigrationsListSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFMigrationsListSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFMigrationsListSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFMigrationsListSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetEFMigrationsList(Configure<DotNetEFMigrationsListSettings> configurator)
        {
            return DotNetEFMigrationsList(configurator(new DotNetEFMigrationsListSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations list</c> command is used to Lists available migrations.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFMigrationsListSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFMigrationsListSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFMigrationsListSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFMigrationsListSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFMigrationsListSettings.NoColor"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFMigrationsListSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFMigrationsListSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFMigrationsListSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFMigrationsListSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFMigrationsListSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFMigrationsListSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetEFMigrationsListSettings Settings, IReadOnlyCollection<Output> Output)> DotNetEFMigrationsList(CombinatorialConfigure<DotNetEFMigrationsListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetEFMigrationsList, DotNetEFLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations remove</c> command is used to Removes the last migration (rolls back the code changes that were done for the migration).</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotNetEFMigrationsRemove(DotNetEFMigrationsRemoveSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetEFMigrationsRemoveSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations remove</c> command is used to Removes the last migration (rolls back the code changes that were done for the migration).</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFMigrationsRemoveSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFMigrationsRemoveSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFMigrationsRemoveSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFMigrationsRemoveSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFMigrationsRemoveSettings.NoColor"/></li>
        ///     <li><c>--output-dir</c> via <see cref="DotNetEFMigrationsRemoveSettings.OutputDirectory"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFMigrationsRemoveSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFMigrationsRemoveSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFMigrationsRemoveSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFMigrationsRemoveSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFMigrationsRemoveSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFMigrationsRemoveSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetEFMigrationsRemove(Configure<DotNetEFMigrationsRemoveSettings> configurator)
        {
            return DotNetEFMigrationsRemove(configurator(new DotNetEFMigrationsRemoveSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations remove</c> command is used to Removes the last migration (rolls back the code changes that were done for the migration).</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFMigrationsRemoveSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFMigrationsRemoveSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFMigrationsRemoveSettings.Framework"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFMigrationsRemoveSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFMigrationsRemoveSettings.NoColor"/></li>
        ///     <li><c>--output-dir</c> via <see cref="DotNetEFMigrationsRemoveSettings.OutputDirectory"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFMigrationsRemoveSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFMigrationsRemoveSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFMigrationsRemoveSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFMigrationsRemoveSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFMigrationsRemoveSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFMigrationsRemoveSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetEFMigrationsRemoveSettings Settings, IReadOnlyCollection<Output> Output)> DotNetEFMigrationsRemove(CombinatorialConfigure<DotNetEFMigrationsRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetEFMigrationsRemove, DotNetEFLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations script</c> command is used to generate a SQL script from migrations.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DotNetEFMigrationsScript(DotNetEFMigrationsScriptSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetEFMigrationsScriptSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations script</c> command is used to generate a SQL script from migrations.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;from&gt;</c> via <see cref="DotNetEFMigrationsScriptSettings.From"/></li>
        ///     <li><c>&lt;to&gt;</c> via <see cref="DotNetEFMigrationsScriptSettings.To"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFMigrationsScriptSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFMigrationsScriptSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFMigrationsScriptSettings.Framework"/></li>
        ///     <li><c>--idempotent</c> via <see cref="DotNetEFMigrationsScriptSettings.Idempotent"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFMigrationsScriptSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFMigrationsScriptSettings.NoColor"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetEFMigrationsScriptSettings.Output"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFMigrationsScriptSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFMigrationsScriptSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFMigrationsScriptSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFMigrationsScriptSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFMigrationsScriptSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFMigrationsScriptSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetEFMigrationsScript(Configure<DotNetEFMigrationsScriptSettings> configurator)
        {
            return DotNetEFMigrationsScript(configurator(new DotNetEFMigrationsScriptSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet ef migrations script</c> command is used to generate a SQL script from migrations.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;from&gt;</c> via <see cref="DotNetEFMigrationsScriptSettings.From"/></li>
        ///     <li><c>&lt;to&gt;</c> via <see cref="DotNetEFMigrationsScriptSettings.To"/></li>
        ///     <li><c>--configuration</c> via <see cref="DotNetEFMigrationsScriptSettings.Configuration"/></li>
        ///     <li><c>--context</c> via <see cref="DotNetEFMigrationsScriptSettings.Context"/></li>
        ///     <li><c>--framework</c> via <see cref="DotNetEFMigrationsScriptSettings.Framework"/></li>
        ///     <li><c>--idempotent</c> via <see cref="DotNetEFMigrationsScriptSettings.Idempotent"/></li>
        ///     <li><c>--json</c> via <see cref="DotNetEFMigrationsScriptSettings.Json"/></li>
        ///     <li><c>--no-color</c> via <see cref="DotNetEFMigrationsScriptSettings.NoColor"/></li>
        ///     <li><c>--output</c> via <see cref="DotNetEFMigrationsScriptSettings.Output"/></li>
        ///     <li><c>--prefix-output</c> via <see cref="DotNetEFMigrationsScriptSettings.Prefix"/></li>
        ///     <li><c>--project</c> via <see cref="DotNetEFMigrationsScriptSettings.Project"/></li>
        ///     <li><c>--runtime</c> via <see cref="DotNetEFMigrationsScriptSettings.Runtime"/></li>
        ///     <li><c>--startup-project</c> via <see cref="DotNetEFMigrationsScriptSettings.StartupProject"/></li>
        ///     <li><c>--verbosity</c> via <see cref="DotNetEFMigrationsScriptSettings.Verbosity"/></li>
        ///     <li><c>--version</c> via <see cref="DotNetEFMigrationsScriptSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DotNetEFMigrationsScriptSettings Settings, IReadOnlyCollection<Output> Output)> DotNetEFMigrationsScript(CombinatorialConfigure<DotNetEFMigrationsScriptSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetEFMigrationsScript, DotNetEFLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region DotNetEFDatabaseDropSettings
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetEFDatabaseDropSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNetEF executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetEFTasks.DotNetEFPath;
        public override Action<OutputType, string> CustomLogger => DotNetEFTasks.DotNetEFLogger;
        /// <summary>
        ///   This option doesn't confirm the drop command.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   This option shows which database would be dropped, but doesn't drop it.
        /// </summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary>
        ///   Show JSON output.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the target project. Default value is the current folder.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the startup project. Default value is the current folder.
        /// </summary>
        public virtual string StartupProject { get; internal set; }
        /// <summary>
        ///   The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   The build configuration, for example: <c>Debug</c> or <c>Release.</c>
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Don't colorize output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Prefix output with level.
        /// </summary>
        public virtual bool? Prefix { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Gets the version.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("database drop")
              .Add("--force", Force)
              .Add("--dry-run", DryRun)
              .Add("--json", Json)
              .Add("--context {value}", Context)
              .Add("--project {value}", Project)
              .Add("--startup-project {value}", StartupProject)
              .Add("--framework {value}", Framework)
              .Add("--configuration {value}", Configuration)
              .Add("--runtime {value}", Runtime)
              .Add("--no-color", NoColor)
              .Add("--prefix-output", Prefix)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetEFDatabaseUpdateSettings
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetEFDatabaseUpdateSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNetEF executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetEFTasks.DotNetEFPath;
        public override Action<OutputType, string> CustomLogger => DotNetEFTasks.DotNetEFLogger;
        /// <summary>
        ///   This option doesn't confirm the drop command.
        /// </summary>
        public virtual string Migration { get; internal set; }
        /// <summary>
        ///   This option shows which database would be dropped, but doesn't drop it.
        /// </summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary>
        ///   Show JSON output.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the target project. Default value is the current folder.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the startup project. Default value is the current folder.
        /// </summary>
        public virtual string StartupProject { get; internal set; }
        /// <summary>
        ///   The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   The build configuration, for example: <c>Debug</c> or <c>Release.</c>
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Don't colorize output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Prefix output with level.
        /// </summary>
        public virtual bool? Prefix { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Gets the version.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("database update")
              .Add("{value}", Migration)
              .Add("--dry-run", DryRun)
              .Add("--json", Json)
              .Add("--context {value}", Context)
              .Add("--project {value}", Project)
              .Add("--startup-project {value}", StartupProject)
              .Add("--framework {value}", Framework)
              .Add("--configuration {value}", Configuration)
              .Add("--runtime {value}", Runtime)
              .Add("--no-color", NoColor)
              .Add("--prefix-output", Prefix)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetEFDbContextInfoSettings
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetEFDbContextInfoSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNetEF executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetEFTasks.DotNetEFPath;
        public override Action<OutputType, string> CustomLogger => DotNetEFTasks.DotNetEFLogger;
        /// <summary>
        ///   Show JSON output.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the target project. Default value is the current folder.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the startup project. Default value is the current folder.
        /// </summary>
        public virtual string StartupProject { get; internal set; }
        /// <summary>
        ///   The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   The build configuration, for example: <c>Debug</c> or <c>Release.</c>
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Don't colorize output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Prefix output with level.
        /// </summary>
        public virtual bool? Prefix { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Gets the version.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("info")
              .Add("--json", Json)
              .Add("--context {value}", Context)
              .Add("--project {value}", Project)
              .Add("--startup-project {value}", StartupProject)
              .Add("--framework {value}", Framework)
              .Add("--configuration {value}", Configuration)
              .Add("--runtime {value}", Runtime)
              .Add("--no-color", NoColor)
              .Add("--prefix-output", Prefix)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetEFDbContextListSettings
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetEFDbContextListSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNetEF executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetEFTasks.DotNetEFPath;
        public override Action<OutputType, string> CustomLogger => DotNetEFTasks.DotNetEFLogger;
        /// <summary>
        ///   Show JSON output.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the target project. Default value is the current folder.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the startup project. Default value is the current folder.
        /// </summary>
        public virtual string StartupProject { get; internal set; }
        /// <summary>
        ///   The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   The build configuration, for example: <c>Debug</c> or <c>Release.</c>
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Don't colorize output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Prefix output with level.
        /// </summary>
        public virtual bool? Prefix { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Gets the version.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("list")
              .Add("--json", Json)
              .Add("--context {value}", Context)
              .Add("--project {value}", Project)
              .Add("--startup-project {value}", StartupProject)
              .Add("--framework {value}", Framework)
              .Add("--configuration {value}", Configuration)
              .Add("--runtime {value}", Runtime)
              .Add("--no-color", NoColor)
              .Add("--prefix-output", Prefix)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetEFDbContextScaffoldSettings
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetEFDbContextScaffoldSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNetEF executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetEFTasks.DotNetEFPath;
        public override Action<OutputType, string> CustomLogger => DotNetEFTasks.DotNetEFLogger;
        /// <summary>
        ///   The connection string to the database. For ASP.NET Core 2.x projects, the value can be name=<name of connection string>. In that case the name comes from the configuration sources that are set up for the project.
        /// </summary>
        public virtual string Connection { get; internal set; }
        /// <summary>
        ///   The provider to use. Typically this is the name of the NuGet package, for example: <c>Microsoft.EntityFrameworkCore.SqlServer.</c>
        /// </summary>
        public virtual string Provider { get; internal set; }
        /// <summary>
        ///   Use attributes to configure the model (where possible). If this option is omitted, only the fluent API is used.
        /// </summary>
        public virtual bool? DataAnnotations { get; internal set; }
        /// <summary>
        ///   The name of the <c>DbContext</c> class to generate.
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///   The directory to put the <c>DbContext</c> class file in. Paths are relative to the project directory. Namespaces are derived from the folder names.
        /// </summary>
        public virtual string ContextDirectory { get; internal set; }
        /// <summary>
        ///   Overwrite existing files.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   The directory to put entity class files in. Paths are relative to the project directory.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   The schemas of tables to generate entity types for. To specify multiple schemas, repeat <c>--schema</c> for each one. If this option is omitted, all schemas are included.
        /// </summary>
        public virtual string Schema { get; internal set; }
        /// <summary>
        ///   The tables to generate entity types for. To specify multiple tables, repeat <c>-t</c> or <c>--table</c> for each one. If this option is omitted, all tables are included.
        /// </summary>
        public virtual string Table { get; internal set; }
        /// <summary>
        ///   Use table and column names exactly as they appear in the database. If this option is omitted, database names are changed to more closely conform to C# name style conventions.
        /// </summary>
        public virtual bool? UseDatabaseNames { get; internal set; }
        /// <summary>
        ///   Show JSON output.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the target project. Default value is the current folder.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the startup project. Default value is the current folder.
        /// </summary>
        public virtual string StartupProject { get; internal set; }
        /// <summary>
        ///   The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   The build configuration, for example: <c>Debug</c> or <c>Release.</c>
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Don't colorize output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Prefix output with level.
        /// </summary>
        public virtual bool? Prefix { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Gets the version.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("dbcontext scaffold")
              .Add("{value}", Connection)
              .Add("{value}", Provider)
              .Add("--data-annotations", DataAnnotations)
              .Add("--context {value}", Context)
              .Add("--context-dir {value}", ContextDirectory)
              .Add("--force", Force)
              .Add("--output-dir {value}", OutputDirectory)
              .Add("--schema {value}", Schema)
              .Add("--table {value}", Table)
              .Add("--use-database-names", UseDatabaseNames)
              .Add("--json", Json)
              .Add("--context {value}", Context)
              .Add("--project {value}", Project)
              .Add("--startup-project {value}", StartupProject)
              .Add("--framework {value}", Framework)
              .Add("--configuration {value}", Configuration)
              .Add("--runtime {value}", Runtime)
              .Add("--no-color", NoColor)
              .Add("--prefix-output", Prefix)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetEFMigrationsAddSettings
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetEFMigrationsAddSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNetEF executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetEFTasks.DotNetEFPath;
        public override Action<OutputType, string> CustomLogger => DotNetEFTasks.DotNetEFLogger;
        /// <summary>
        ///   The name of the migration.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   The directory (and sub-namespace) to use. Paths are relative to the project directory. Defaults to 'Migrations'.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Show JSON output.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the target project. Default value is the current folder.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the startup project. Default value is the current folder.
        /// </summary>
        public virtual string StartupProject { get; internal set; }
        /// <summary>
        ///   The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   The build configuration, for example: <c>Debug</c> or <c>Release.</c>
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Don't colorize output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Prefix output with level.
        /// </summary>
        public virtual bool? Prefix { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Gets the version.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("migrations add")
              .Add("{value}", Name)
              .Add("--output-dir {value}", OutputDirectory)
              .Add("--json", Json)
              .Add("--context {value}", Context)
              .Add("--project {value}", Project)
              .Add("--startup-project {value}", StartupProject)
              .Add("--framework {value}", Framework)
              .Add("--configuration {value}", Configuration)
              .Add("--runtime {value}", Runtime)
              .Add("--no-color", NoColor)
              .Add("--prefix-output", Prefix)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetEFMigrationsListSettings
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetEFMigrationsListSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNetEF executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetEFTasks.DotNetEFPath;
        public override Action<OutputType, string> CustomLogger => DotNetEFTasks.DotNetEFLogger;
        /// <summary>
        ///   Show JSON output.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the target project. Default value is the current folder.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the startup project. Default value is the current folder.
        /// </summary>
        public virtual string StartupProject { get; internal set; }
        /// <summary>
        ///   The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   The build configuration, for example: <c>Debug</c> or <c>Release.</c>
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Don't colorize output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Prefix output with level.
        /// </summary>
        public virtual bool? Prefix { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Gets the version.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("migrations list")
              .Add("--json", Json)
              .Add("--context {value}", Context)
              .Add("--project {value}", Project)
              .Add("--startup-project {value}", StartupProject)
              .Add("--framework {value}", Framework)
              .Add("--configuration {value}", Configuration)
              .Add("--runtime {value}", Runtime)
              .Add("--no-color", NoColor)
              .Add("--prefix-output", Prefix)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetEFMigrationsRemoveSettings
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetEFMigrationsRemoveSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNetEF executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetEFTasks.DotNetEFPath;
        public override Action<OutputType, string> CustomLogger => DotNetEFTasks.DotNetEFLogger;
        /// <summary>
        ///   The directory (and sub-namespace) to use. Paths are relative to the project directory. Defaults to 'Migrations'.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Show JSON output.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the target project. Default value is the current folder.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the startup project. Default value is the current folder.
        /// </summary>
        public virtual string StartupProject { get; internal set; }
        /// <summary>
        ///   The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   The build configuration, for example: <c>Debug</c> or <c>Release.</c>
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Don't colorize output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Prefix output with level.
        /// </summary>
        public virtual bool? Prefix { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Gets the version.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("migrations remove")
              .Add("--output-dir {value}", OutputDirectory)
              .Add("--json", Json)
              .Add("--context {value}", Context)
              .Add("--project {value}", Project)
              .Add("--startup-project {value}", StartupProject)
              .Add("--framework {value}", Framework)
              .Add("--configuration {value}", Configuration)
              .Add("--runtime {value}", Runtime)
              .Add("--no-color", NoColor)
              .Add("--prefix-output", Prefix)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetEFMigrationsScriptSettings
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetEFMigrationsScriptSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DotNetEF executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DotNetEFTasks.DotNetEFPath;
        public override Action<OutputType, string> CustomLogger => DotNetEFTasks.DotNetEFLogger;
        /// <summary>
        ///   The starting migration. Migrations may be identified by name or by ID. The number 0 is a special case that means before the first migration. Defaults to 0.
        /// </summary>
        public virtual string From { get; internal set; }
        /// <summary>
        ///   The ending migration. Defaults to the last migration.
        /// </summary>
        public virtual string To { get; internal set; }
        /// <summary>
        ///   The file to write the script to.
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   Generate a script that can be used on a database at any migration.
        /// </summary>
        public virtual bool? Idempotent { get; internal set; }
        /// <summary>
        ///   Show JSON output.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the target project. Default value is the current folder.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Relative path to the project folder of the startup project. Default value is the current folder.
        /// </summary>
        public virtual string StartupProject { get; internal set; }
        /// <summary>
        ///   The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   The build configuration, for example: <c>Debug</c> or <c>Release.</c>
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///   Don't colorize output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Prefix output with level.
        /// </summary>
        public virtual bool? Prefix { get; internal set; }
        /// <summary>
        ///   Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.
        /// </summary>
        public virtual DotNetVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   Gets the version.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("migrations script")
              .Add("{value}", From)
              .Add("{value}", To)
              .Add("--output {value}", Output)
              .Add("--idempotent", Idempotent)
              .Add("--json", Json)
              .Add("--context {value}", Context)
              .Add("--project {value}", Project)
              .Add("--startup-project {value}", StartupProject)
              .Add("--framework {value}", Framework)
              .Add("--configuration {value}", Configuration)
              .Add("--runtime {value}", Runtime)
              .Add("--no-color", NoColor)
              .Add("--prefix-output", Prefix)
              .Add("--verbosity {value}", Verbosity)
              .Add("--version", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DotNetEFDatabaseDropSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetEFDatabaseDropSettingsExtensions
    {
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.Force"/></em></p>
        ///   <p>This option doesn't confirm the drop command.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetForce(this DotNetEFDatabaseDropSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.Force"/></em></p>
        ///   <p>This option doesn't confirm the drop command.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetForce(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseDropSettings.Force"/></em></p>
        ///   <p>This option doesn't confirm the drop command.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings EnableForce(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseDropSettings.Force"/></em></p>
        ///   <p>This option doesn't confirm the drop command.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings DisableForce(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseDropSettings.Force"/></em></p>
        ///   <p>This option doesn't confirm the drop command.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ToggleForce(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.DryRun"/></em></p>
        ///   <p>This option shows which database would be dropped, but doesn't drop it.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetDryRun(this DotNetEFDatabaseDropSettings toolSettings, bool? dryRun)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.DryRun"/></em></p>
        ///   <p>This option shows which database would be dropped, but doesn't drop it.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetDryRun(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseDropSettings.DryRun"/></em></p>
        ///   <p>This option shows which database would be dropped, but doesn't drop it.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings EnableDryRun(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseDropSettings.DryRun"/></em></p>
        ///   <p>This option shows which database would be dropped, but doesn't drop it.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings DisableDryRun(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseDropSettings.DryRun"/></em></p>
        ///   <p>This option shows which database would be dropped, but doesn't drop it.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ToggleDryRun(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetJson(this DotNetEFDatabaseDropSettings toolSettings, bool? json)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetJson(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseDropSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings EnableJson(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseDropSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings DisableJson(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseDropSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ToggleJson(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Context
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetContext(this DotNetEFDatabaseDropSettings toolSettings, string context)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetContext(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetProject(this DotNetEFDatabaseDropSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetProject(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region StartupProject
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetStartupProject(this DotNetEFDatabaseDropSettings toolSettings, string startupProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = startupProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetStartupProject(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetFramework(this DotNetEFDatabaseDropSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetFramework(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetConfiguration(this DotNetEFDatabaseDropSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetConfiguration(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetRuntime(this DotNetEFDatabaseDropSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetRuntime(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetNoColor(this DotNetEFDatabaseDropSettings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetNoColor(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseDropSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings EnableNoColor(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseDropSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings DisableNoColor(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseDropSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ToggleNoColor(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Prefix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetPrefix(this DotNetEFDatabaseDropSettings toolSettings, bool? prefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = prefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetPrefix(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseDropSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings EnablePrefix(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseDropSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings DisablePrefix(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseDropSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings TogglePrefix(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = !toolSettings.Prefix;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetVerbosity(this DotNetEFDatabaseDropSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetVerbosity(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseDropSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings SetVersion(this DotNetEFDatabaseDropSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseDropSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ResetVersion(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseDropSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings EnableVersion(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseDropSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings DisableVersion(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseDropSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseDropSettings ToggleVersion(this DotNetEFDatabaseDropSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetEFDatabaseUpdateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetEFDatabaseUpdateSettingsExtensions
    {
        #region Migration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.Migration"/></em></p>
        ///   <p>This option doesn't confirm the drop command.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetMigration(this DotNetEFDatabaseUpdateSettings toolSettings, string migration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Migration = migration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.Migration"/></em></p>
        ///   <p>This option doesn't confirm the drop command.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetMigration(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Migration = null;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.DryRun"/></em></p>
        ///   <p>This option shows which database would be dropped, but doesn't drop it.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetDryRun(this DotNetEFDatabaseUpdateSettings toolSettings, bool? dryRun)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.DryRun"/></em></p>
        ///   <p>This option shows which database would be dropped, but doesn't drop it.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetDryRun(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseUpdateSettings.DryRun"/></em></p>
        ///   <p>This option shows which database would be dropped, but doesn't drop it.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings EnableDryRun(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseUpdateSettings.DryRun"/></em></p>
        ///   <p>This option shows which database would be dropped, but doesn't drop it.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings DisableDryRun(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseUpdateSettings.DryRun"/></em></p>
        ///   <p>This option shows which database would be dropped, but doesn't drop it.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ToggleDryRun(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetJson(this DotNetEFDatabaseUpdateSettings toolSettings, bool? json)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetJson(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseUpdateSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings EnableJson(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseUpdateSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings DisableJson(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseUpdateSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ToggleJson(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Context
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetContext(this DotNetEFDatabaseUpdateSettings toolSettings, string context)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetContext(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetProject(this DotNetEFDatabaseUpdateSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetProject(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region StartupProject
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetStartupProject(this DotNetEFDatabaseUpdateSettings toolSettings, string startupProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = startupProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetStartupProject(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetFramework(this DotNetEFDatabaseUpdateSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetFramework(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetConfiguration(this DotNetEFDatabaseUpdateSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetConfiguration(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetRuntime(this DotNetEFDatabaseUpdateSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetRuntime(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetNoColor(this DotNetEFDatabaseUpdateSettings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetNoColor(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseUpdateSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings EnableNoColor(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseUpdateSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings DisableNoColor(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseUpdateSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ToggleNoColor(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Prefix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetPrefix(this DotNetEFDatabaseUpdateSettings toolSettings, bool? prefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = prefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetPrefix(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseUpdateSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings EnablePrefix(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseUpdateSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings DisablePrefix(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseUpdateSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings TogglePrefix(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = !toolSettings.Prefix;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetVerbosity(this DotNetEFDatabaseUpdateSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetVerbosity(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDatabaseUpdateSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings SetVersion(this DotNetEFDatabaseUpdateSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDatabaseUpdateSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ResetVersion(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDatabaseUpdateSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings EnableVersion(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDatabaseUpdateSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings DisableVersion(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDatabaseUpdateSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDatabaseUpdateSettings ToggleVersion(this DotNetEFDatabaseUpdateSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetEFDbContextInfoSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetEFDbContextInfoSettingsExtensions
    {
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetJson(this DotNetEFDbContextInfoSettings toolSettings, bool? json)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetJson(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextInfoSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings EnableJson(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextInfoSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings DisableJson(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextInfoSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ToggleJson(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Context
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetContext(this DotNetEFDbContextInfoSettings toolSettings, string context)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetContext(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetProject(this DotNetEFDbContextInfoSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetProject(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region StartupProject
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetStartupProject(this DotNetEFDbContextInfoSettings toolSettings, string startupProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = startupProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetStartupProject(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetFramework(this DotNetEFDbContextInfoSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetFramework(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetConfiguration(this DotNetEFDbContextInfoSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetConfiguration(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetRuntime(this DotNetEFDbContextInfoSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetRuntime(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetNoColor(this DotNetEFDbContextInfoSettings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetNoColor(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextInfoSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings EnableNoColor(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextInfoSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings DisableNoColor(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextInfoSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ToggleNoColor(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Prefix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetPrefix(this DotNetEFDbContextInfoSettings toolSettings, bool? prefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = prefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetPrefix(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextInfoSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings EnablePrefix(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextInfoSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings DisablePrefix(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextInfoSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings TogglePrefix(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = !toolSettings.Prefix;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetVerbosity(this DotNetEFDbContextInfoSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetVerbosity(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextInfoSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings SetVersion(this DotNetEFDbContextInfoSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextInfoSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ResetVersion(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextInfoSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings EnableVersion(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextInfoSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings DisableVersion(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextInfoSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextInfoSettings ToggleVersion(this DotNetEFDbContextInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetEFDbContextListSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetEFDbContextListSettingsExtensions
    {
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetJson(this DotNetEFDbContextListSettings toolSettings, bool? json)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetJson(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextListSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings EnableJson(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextListSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings DisableJson(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextListSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ToggleJson(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Context
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetContext(this DotNetEFDbContextListSettings toolSettings, string context)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetContext(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetProject(this DotNetEFDbContextListSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetProject(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region StartupProject
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetStartupProject(this DotNetEFDbContextListSettings toolSettings, string startupProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = startupProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetStartupProject(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetFramework(this DotNetEFDbContextListSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetFramework(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetConfiguration(this DotNetEFDbContextListSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetConfiguration(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetRuntime(this DotNetEFDbContextListSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetRuntime(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetNoColor(this DotNetEFDbContextListSettings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetNoColor(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextListSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings EnableNoColor(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextListSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings DisableNoColor(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextListSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ToggleNoColor(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Prefix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetPrefix(this DotNetEFDbContextListSettings toolSettings, bool? prefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = prefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetPrefix(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextListSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings EnablePrefix(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextListSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings DisablePrefix(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextListSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings TogglePrefix(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = !toolSettings.Prefix;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetVerbosity(this DotNetEFDbContextListSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetVerbosity(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextListSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings SetVersion(this DotNetEFDbContextListSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextListSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ResetVersion(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextListSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings EnableVersion(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextListSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings DisableVersion(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextListSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextListSettings ToggleVersion(this DotNetEFDbContextListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetEFDbContextScaffoldSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetEFDbContextScaffoldSettingsExtensions
    {
        #region Connection
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Connection"/></em></p>
        ///   <p>The connection string to the database. For ASP.NET Core 2.x projects, the value can be name=<name of connection string>. In that case the name comes from the configuration sources that are set up for the project.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetConnection(this DotNetEFDbContextScaffoldSettings toolSettings, string connection)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Connection = connection;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Connection"/></em></p>
        ///   <p>The connection string to the database. For ASP.NET Core 2.x projects, the value can be name=<name of connection string>. In that case the name comes from the configuration sources that are set up for the project.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetConnection(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Connection = null;
            return toolSettings;
        }
        #endregion
        #region Provider
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Provider"/></em></p>
        ///   <p>The provider to use. Typically this is the name of the NuGet package, for example: <c>Microsoft.EntityFrameworkCore.SqlServer.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetProvider(this DotNetEFDbContextScaffoldSettings toolSettings, string provider)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Provider = provider;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Provider"/></em></p>
        ///   <p>The provider to use. Typically this is the name of the NuGet package, for example: <c>Microsoft.EntityFrameworkCore.SqlServer.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetProvider(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Provider = null;
            return toolSettings;
        }
        #endregion
        #region DataAnnotations
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.DataAnnotations"/></em></p>
        ///   <p>Use attributes to configure the model (where possible). If this option is omitted, only the fluent API is used.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetDataAnnotations(this DotNetEFDbContextScaffoldSettings toolSettings, bool? dataAnnotations)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataAnnotations = dataAnnotations;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.DataAnnotations"/></em></p>
        ///   <p>Use attributes to configure the model (where possible). If this option is omitted, only the fluent API is used.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetDataAnnotations(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataAnnotations = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextScaffoldSettings.DataAnnotations"/></em></p>
        ///   <p>Use attributes to configure the model (where possible). If this option is omitted, only the fluent API is used.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings EnableDataAnnotations(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataAnnotations = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextScaffoldSettings.DataAnnotations"/></em></p>
        ///   <p>Use attributes to configure the model (where possible). If this option is omitted, only the fluent API is used.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings DisableDataAnnotations(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataAnnotations = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextScaffoldSettings.DataAnnotations"/></em></p>
        ///   <p>Use attributes to configure the model (where possible). If this option is omitted, only the fluent API is used.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ToggleDataAnnotations(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataAnnotations = !toolSettings.DataAnnotations;
            return toolSettings;
        }
        #endregion
        #region Context
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Context"/></em></p>
        ///   <p>The name of the <c>DbContext</c> class to generate.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetContext(this DotNetEFDbContextScaffoldSettings toolSettings, string context)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Context"/></em></p>
        ///   <p>The name of the <c>DbContext</c> class to generate.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetContext(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = null;
            return toolSettings;
        }
        #endregion
        #region ContextDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.ContextDirectory"/></em></p>
        ///   <p>The directory to put the <c>DbContext</c> class file in. Paths are relative to the project directory. Namespaces are derived from the folder names.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetContextDirectory(this DotNetEFDbContextScaffoldSettings toolSettings, string contextDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContextDirectory = contextDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.ContextDirectory"/></em></p>
        ///   <p>The directory to put the <c>DbContext</c> class file in. Paths are relative to the project directory. Namespaces are derived from the folder names.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetContextDirectory(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContextDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Force"/></em></p>
        ///   <p>Overwrite existing files.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetForce(this DotNetEFDbContextScaffoldSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Force"/></em></p>
        ///   <p>Overwrite existing files.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetForce(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextScaffoldSettings.Force"/></em></p>
        ///   <p>Overwrite existing files.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings EnableForce(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextScaffoldSettings.Force"/></em></p>
        ///   <p>Overwrite existing files.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings DisableForce(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextScaffoldSettings.Force"/></em></p>
        ///   <p>Overwrite existing files.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ToggleForce(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.OutputDirectory"/></em></p>
        ///   <p>The directory to put entity class files in. Paths are relative to the project directory.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetOutputDirectory(this DotNetEFDbContextScaffoldSettings toolSettings, string outputDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.OutputDirectory"/></em></p>
        ///   <p>The directory to put entity class files in. Paths are relative to the project directory.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetOutputDirectory(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Schema
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Schema"/></em></p>
        ///   <p>The schemas of tables to generate entity types for. To specify multiple schemas, repeat <c>--schema</c> for each one. If this option is omitted, all schemas are included.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetSchema(this DotNetEFDbContextScaffoldSettings toolSettings, string schema)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Schema = schema;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Schema"/></em></p>
        ///   <p>The schemas of tables to generate entity types for. To specify multiple schemas, repeat <c>--schema</c> for each one. If this option is omitted, all schemas are included.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetSchema(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Schema = null;
            return toolSettings;
        }
        #endregion
        #region Table
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Table"/></em></p>
        ///   <p>The tables to generate entity types for. To specify multiple tables, repeat <c>-t</c> or <c>--table</c> for each one. If this option is omitted, all tables are included.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetTable(this DotNetEFDbContextScaffoldSettings toolSettings, string table)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Table = table;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Table"/></em></p>
        ///   <p>The tables to generate entity types for. To specify multiple tables, repeat <c>-t</c> or <c>--table</c> for each one. If this option is omitted, all tables are included.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetTable(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Table = null;
            return toolSettings;
        }
        #endregion
        #region UseDatabaseNames
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.UseDatabaseNames"/></em></p>
        ///   <p>Use table and column names exactly as they appear in the database. If this option is omitted, database names are changed to more closely conform to C# name style conventions.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetUseDatabaseNames(this DotNetEFDbContextScaffoldSettings toolSettings, bool? useDatabaseNames)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseDatabaseNames = useDatabaseNames;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.UseDatabaseNames"/></em></p>
        ///   <p>Use table and column names exactly as they appear in the database. If this option is omitted, database names are changed to more closely conform to C# name style conventions.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetUseDatabaseNames(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseDatabaseNames = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextScaffoldSettings.UseDatabaseNames"/></em></p>
        ///   <p>Use table and column names exactly as they appear in the database. If this option is omitted, database names are changed to more closely conform to C# name style conventions.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings EnableUseDatabaseNames(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseDatabaseNames = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextScaffoldSettings.UseDatabaseNames"/></em></p>
        ///   <p>Use table and column names exactly as they appear in the database. If this option is omitted, database names are changed to more closely conform to C# name style conventions.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings DisableUseDatabaseNames(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseDatabaseNames = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextScaffoldSettings.UseDatabaseNames"/></em></p>
        ///   <p>Use table and column names exactly as they appear in the database. If this option is omitted, database names are changed to more closely conform to C# name style conventions.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ToggleUseDatabaseNames(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseDatabaseNames = !toolSettings.UseDatabaseNames;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetJson(this DotNetEFDbContextScaffoldSettings toolSettings, bool? json)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetJson(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextScaffoldSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings EnableJson(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextScaffoldSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings DisableJson(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextScaffoldSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ToggleJson(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Context
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetContext(this DotNetEFDbContextScaffoldSettings toolSettings, string context)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetContext(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetProject(this DotNetEFDbContextScaffoldSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetProject(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region StartupProject
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetStartupProject(this DotNetEFDbContextScaffoldSettings toolSettings, string startupProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = startupProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetStartupProject(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetFramework(this DotNetEFDbContextScaffoldSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetFramework(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetConfiguration(this DotNetEFDbContextScaffoldSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetConfiguration(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetRuntime(this DotNetEFDbContextScaffoldSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetRuntime(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetNoColor(this DotNetEFDbContextScaffoldSettings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetNoColor(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextScaffoldSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings EnableNoColor(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextScaffoldSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings DisableNoColor(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextScaffoldSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ToggleNoColor(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Prefix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetPrefix(this DotNetEFDbContextScaffoldSettings toolSettings, bool? prefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = prefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetPrefix(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextScaffoldSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings EnablePrefix(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextScaffoldSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings DisablePrefix(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextScaffoldSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings TogglePrefix(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = !toolSettings.Prefix;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetVerbosity(this DotNetEFDbContextScaffoldSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetVerbosity(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFDbContextScaffoldSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings SetVersion(this DotNetEFDbContextScaffoldSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFDbContextScaffoldSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ResetVersion(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFDbContextScaffoldSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings EnableVersion(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFDbContextScaffoldSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings DisableVersion(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFDbContextScaffoldSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFDbContextScaffoldSettings ToggleVersion(this DotNetEFDbContextScaffoldSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetEFMigrationsAddSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetEFMigrationsAddSettingsExtensions
    {
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.Name"/></em></p>
        ///   <p>The name of the migration.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetName(this DotNetEFMigrationsAddSettings toolSettings, string name)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.Name"/></em></p>
        ///   <p>The name of the migration.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetName(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.OutputDirectory"/></em></p>
        ///   <p>The directory (and sub-namespace) to use. Paths are relative to the project directory. Defaults to 'Migrations'.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetOutputDirectory(this DotNetEFMigrationsAddSettings toolSettings, string outputDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.OutputDirectory"/></em></p>
        ///   <p>The directory (and sub-namespace) to use. Paths are relative to the project directory. Defaults to 'Migrations'.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetOutputDirectory(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetJson(this DotNetEFMigrationsAddSettings toolSettings, bool? json)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetJson(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsAddSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings EnableJson(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsAddSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings DisableJson(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsAddSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ToggleJson(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Context
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetContext(this DotNetEFMigrationsAddSettings toolSettings, string context)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetContext(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetProject(this DotNetEFMigrationsAddSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetProject(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region StartupProject
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetStartupProject(this DotNetEFMigrationsAddSettings toolSettings, string startupProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = startupProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetStartupProject(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetFramework(this DotNetEFMigrationsAddSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetFramework(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetConfiguration(this DotNetEFMigrationsAddSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetConfiguration(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetRuntime(this DotNetEFMigrationsAddSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetRuntime(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetNoColor(this DotNetEFMigrationsAddSettings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetNoColor(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsAddSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings EnableNoColor(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsAddSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings DisableNoColor(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsAddSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ToggleNoColor(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Prefix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetPrefix(this DotNetEFMigrationsAddSettings toolSettings, bool? prefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = prefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetPrefix(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsAddSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings EnablePrefix(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsAddSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings DisablePrefix(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsAddSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings TogglePrefix(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = !toolSettings.Prefix;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetVerbosity(this DotNetEFMigrationsAddSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetVerbosity(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsAddSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings SetVersion(this DotNetEFMigrationsAddSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsAddSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ResetVersion(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsAddSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings EnableVersion(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsAddSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings DisableVersion(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsAddSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsAddSettings ToggleVersion(this DotNetEFMigrationsAddSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetEFMigrationsListSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetEFMigrationsListSettingsExtensions
    {
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetJson(this DotNetEFMigrationsListSettings toolSettings, bool? json)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetJson(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsListSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings EnableJson(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsListSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings DisableJson(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsListSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ToggleJson(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Context
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetContext(this DotNetEFMigrationsListSettings toolSettings, string context)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetContext(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetProject(this DotNetEFMigrationsListSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetProject(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region StartupProject
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetStartupProject(this DotNetEFMigrationsListSettings toolSettings, string startupProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = startupProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetStartupProject(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetFramework(this DotNetEFMigrationsListSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetFramework(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetConfiguration(this DotNetEFMigrationsListSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetConfiguration(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetRuntime(this DotNetEFMigrationsListSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetRuntime(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetNoColor(this DotNetEFMigrationsListSettings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetNoColor(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsListSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings EnableNoColor(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsListSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings DisableNoColor(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsListSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ToggleNoColor(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Prefix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetPrefix(this DotNetEFMigrationsListSettings toolSettings, bool? prefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = prefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetPrefix(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsListSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings EnablePrefix(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsListSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings DisablePrefix(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsListSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings TogglePrefix(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = !toolSettings.Prefix;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetVerbosity(this DotNetEFMigrationsListSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetVerbosity(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsListSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings SetVersion(this DotNetEFMigrationsListSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsListSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ResetVersion(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsListSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings EnableVersion(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsListSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings DisableVersion(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsListSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsListSettings ToggleVersion(this DotNetEFMigrationsListSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetEFMigrationsRemoveSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetEFMigrationsRemoveSettingsExtensions
    {
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.OutputDirectory"/></em></p>
        ///   <p>The directory (and sub-namespace) to use. Paths are relative to the project directory. Defaults to 'Migrations'.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetOutputDirectory(this DotNetEFMigrationsRemoveSettings toolSettings, string outputDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.OutputDirectory"/></em></p>
        ///   <p>The directory (and sub-namespace) to use. Paths are relative to the project directory. Defaults to 'Migrations'.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetOutputDirectory(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetJson(this DotNetEFMigrationsRemoveSettings toolSettings, bool? json)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetJson(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsRemoveSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings EnableJson(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsRemoveSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings DisableJson(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsRemoveSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ToggleJson(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Context
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetContext(this DotNetEFMigrationsRemoveSettings toolSettings, string context)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetContext(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetProject(this DotNetEFMigrationsRemoveSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetProject(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region StartupProject
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetStartupProject(this DotNetEFMigrationsRemoveSettings toolSettings, string startupProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = startupProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetStartupProject(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetFramework(this DotNetEFMigrationsRemoveSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetFramework(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetConfiguration(this DotNetEFMigrationsRemoveSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetConfiguration(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetRuntime(this DotNetEFMigrationsRemoveSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetRuntime(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetNoColor(this DotNetEFMigrationsRemoveSettings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetNoColor(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsRemoveSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings EnableNoColor(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsRemoveSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings DisableNoColor(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsRemoveSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ToggleNoColor(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Prefix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetPrefix(this DotNetEFMigrationsRemoveSettings toolSettings, bool? prefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = prefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetPrefix(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsRemoveSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings EnablePrefix(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsRemoveSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings DisablePrefix(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsRemoveSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings TogglePrefix(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = !toolSettings.Prefix;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetVerbosity(this DotNetEFMigrationsRemoveSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetVerbosity(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsRemoveSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings SetVersion(this DotNetEFMigrationsRemoveSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsRemoveSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ResetVersion(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsRemoveSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings EnableVersion(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsRemoveSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings DisableVersion(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsRemoveSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsRemoveSettings ToggleVersion(this DotNetEFMigrationsRemoveSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DotNetEFMigrationsScriptSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DotNetEFTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetEFMigrationsScriptSettingsExtensions
    {
        #region From
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.From"/></em></p>
        ///   <p>The starting migration. Migrations may be identified by name or by ID. The number 0 is a special case that means before the first migration. Defaults to 0.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetFrom(this DotNetEFMigrationsScriptSettings toolSettings, string from)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.From = from;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.From"/></em></p>
        ///   <p>The starting migration. Migrations may be identified by name or by ID. The number 0 is a special case that means before the first migration. Defaults to 0.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetFrom(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.From = null;
            return toolSettings;
        }
        #endregion
        #region To
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.To"/></em></p>
        ///   <p>The ending migration. Defaults to the last migration.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetTo(this DotNetEFMigrationsScriptSettings toolSettings, string to)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.To = to;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.To"/></em></p>
        ///   <p>The ending migration. Defaults to the last migration.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetTo(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.To = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Output"/></em></p>
        ///   <p>The file to write the script to.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetOutput(this DotNetEFMigrationsScriptSettings toolSettings, string output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Output"/></em></p>
        ///   <p>The file to write the script to.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetOutput(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Idempotent
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Idempotent"/></em></p>
        ///   <p>Generate a script that can be used on a database at any migration.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetIdempotent(this DotNetEFMigrationsScriptSettings toolSettings, bool? idempotent)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Idempotent = idempotent;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Idempotent"/></em></p>
        ///   <p>Generate a script that can be used on a database at any migration.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetIdempotent(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Idempotent = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsScriptSettings.Idempotent"/></em></p>
        ///   <p>Generate a script that can be used on a database at any migration.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings EnableIdempotent(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Idempotent = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsScriptSettings.Idempotent"/></em></p>
        ///   <p>Generate a script that can be used on a database at any migration.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings DisableIdempotent(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Idempotent = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsScriptSettings.Idempotent"/></em></p>
        ///   <p>Generate a script that can be used on a database at any migration.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ToggleIdempotent(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Idempotent = !toolSettings.Idempotent;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetJson(this DotNetEFMigrationsScriptSettings toolSettings, bool? json)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetJson(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsScriptSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings EnableJson(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsScriptSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings DisableJson(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsScriptSettings.Json"/></em></p>
        ///   <p>Show JSON output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ToggleJson(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Context
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetContext(this DotNetEFMigrationsScriptSettings toolSettings, string context)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Context"/></em></p>
        ///   <p>The <c>DbContext</c> class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetContext(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetProject(this DotNetEFMigrationsScriptSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Project"/></em></p>
        ///   <p>Relative path to the project folder of the target project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetProject(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region StartupProject
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetStartupProject(this DotNetEFMigrationsScriptSettings toolSettings, string startupProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = startupProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.StartupProject"/></em></p>
        ///   <p>Relative path to the project folder of the startup project. Default value is the current folder.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetStartupProject(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProject = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetFramework(this DotNetEFMigrationsScriptSettings toolSettings, string framework)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Framework"/></em></p>
        ///   <p>The <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks#supported-target-framework-versions">Target Framework Moniker</a> for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">target framework</a>. Use when the project file specifies multiple target frameworks, and you want to select one of them.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetFramework(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetConfiguration(this DotNetEFMigrationsScriptSettings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Configuration"/></em></p>
        ///   <p>The build configuration, for example: <c>Debug</c> or <c>Release.</c></p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetConfiguration(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Runtime
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetRuntime(this DotNetEFMigrationsScriptSettings toolSettings, string runtime)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Runtime"/></em></p>
        ///   <p>The identifier of the target runtime to restore packages for. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetRuntime(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetNoColor(this DotNetEFMigrationsScriptSettings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetNoColor(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsScriptSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings EnableNoColor(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsScriptSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings DisableNoColor(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsScriptSettings.NoColor"/></em></p>
        ///   <p>Don't colorize output.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ToggleNoColor(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Prefix
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetPrefix(this DotNetEFMigrationsScriptSettings toolSettings, bool? prefix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = prefix;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetPrefix(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsScriptSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings EnablePrefix(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsScriptSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings DisablePrefix(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsScriptSettings.Prefix"/></em></p>
        ///   <p>Prefix output with level.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings TogglePrefix(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefix = !toolSettings.Prefix;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetVerbosity(this DotNetEFMigrationsScriptSettings toolSettings, DotNetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Verbosity"/></em></p>
        ///   <p>Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetVerbosity(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DotNetEFMigrationsScriptSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings SetVersion(this DotNetEFMigrationsScriptSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DotNetEFMigrationsScriptSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ResetVersion(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DotNetEFMigrationsScriptSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings EnableVersion(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DotNetEFMigrationsScriptSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings DisableVersion(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DotNetEFMigrationsScriptSettings.Version"/></em></p>
        ///   <p>Gets the version.</p>
        /// </summary>
        [Pure]
        public static DotNetEFMigrationsScriptSettings ToggleVersion(this DotNetEFMigrationsScriptSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
