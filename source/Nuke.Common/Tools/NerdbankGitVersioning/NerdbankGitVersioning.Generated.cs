// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/NerdbankGitVersioning/NerdbankGitVersioning.json

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

namespace Nuke.Common.Tools.NerdbankGitVersioning
{
    /// <summary>
    ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(NerdbankGitVersioningPackageId)]
    public partial class NerdbankGitVersioningTasks
        : IRequireNuGetPackage
    {
        public const string NerdbankGitVersioningPackageId = "nbgv";
        /// <summary>
        ///   Path to the NerdbankGitVersioning executable.
        /// </summary>
        public static string NerdbankGitVersioningPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("NERDBANKGITVERSIONING_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("nbgv", "nbgv.dll");
        public static Action<OutputType, string> NerdbankGitVersioningLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> NerdbankGitVersioning(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(NerdbankGitVersioningPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? NerdbankGitVersioningLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Prepares a project to have version stamps applied using Nerdbank.GitVersioning.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--path</c> via <see cref="NerdbankGitVersioningInstallSettings.Path"/></li>
        ///     <li><c>--source</c> via <see cref="NerdbankGitVersioningInstallSettings.Sources"/></li>
        ///     <li><c>--version</c> via <see cref="NerdbankGitVersioningInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningInstall(NerdbankGitVersioningInstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NerdbankGitVersioningInstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Prepares a project to have version stamps applied using Nerdbank.GitVersioning.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--path</c> via <see cref="NerdbankGitVersioningInstallSettings.Path"/></li>
        ///     <li><c>--source</c> via <see cref="NerdbankGitVersioningInstallSettings.Sources"/></li>
        ///     <li><c>--version</c> via <see cref="NerdbankGitVersioningInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningInstall(Configure<NerdbankGitVersioningInstallSettings> configurator)
        {
            return NerdbankGitVersioningInstall(configurator(new NerdbankGitVersioningInstallSettings()));
        }
        /// <summary>
        ///   <p>Prepares a project to have version stamps applied using Nerdbank.GitVersioning.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--path</c> via <see cref="NerdbankGitVersioningInstallSettings.Path"/></li>
        ///     <li><c>--source</c> via <see cref="NerdbankGitVersioningInstallSettings.Sources"/></li>
        ///     <li><c>--version</c> via <see cref="NerdbankGitVersioningInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NerdbankGitVersioningInstallSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningInstall(CombinatorialConfigure<NerdbankGitVersioningInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NerdbankGitVersioningInstall, NerdbankGitVersioningLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Gets the version information for a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningGetVersionSettings.CommitIsh"/></li>
        ///     <li><c>--format</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Format"/></li>
        ///     <li><c>--metadata</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Metadata"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Project"/></li>
        ///     <li><c>--variable</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Variable"/></li>
        ///   </ul>
        /// </remarks>
        public static (NerdbankGitVersioning Result, IReadOnlyCollection<Output> Output) NerdbankGitVersioningGetVersion(NerdbankGitVersioningGetVersionSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NerdbankGitVersioningGetVersionSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return (GetResult(process, toolSettings), process.Output);
        }
        /// <summary>
        ///   <p>Gets the version information for a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningGetVersionSettings.CommitIsh"/></li>
        ///     <li><c>--format</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Format"/></li>
        ///     <li><c>--metadata</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Metadata"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Project"/></li>
        ///     <li><c>--variable</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Variable"/></li>
        ///   </ul>
        /// </remarks>
        public static (NerdbankGitVersioning Result, IReadOnlyCollection<Output> Output) NerdbankGitVersioningGetVersion(Configure<NerdbankGitVersioningGetVersionSettings> configurator)
        {
            return NerdbankGitVersioningGetVersion(configurator(new NerdbankGitVersioningGetVersionSettings()));
        }
        /// <summary>
        ///   <p>Gets the version information for a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningGetVersionSettings.CommitIsh"/></li>
        ///     <li><c>--format</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Format"/></li>
        ///     <li><c>--metadata</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Metadata"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Project"/></li>
        ///     <li><c>--variable</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Variable"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NerdbankGitVersioningGetVersionSettings Settings, NerdbankGitVersioning Result, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningGetVersion(CombinatorialConfigure<NerdbankGitVersioningGetVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NerdbankGitVersioningGetVersion, NerdbankGitVersioningLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Updates the version stamp that is applied to a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Version"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningSetVersion(NerdbankGitVersioningSetVersionSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NerdbankGitVersioningSetVersionSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Updates the version stamp that is applied to a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Version"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningSetVersion(Configure<NerdbankGitVersioningSetVersionSettings> configurator)
        {
            return NerdbankGitVersioningSetVersion(configurator(new NerdbankGitVersioningSetVersionSettings()));
        }
        /// <summary>
        ///   <p>Updates the version stamp that is applied to a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Version"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NerdbankGitVersioningSetVersionSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningSetVersion(CombinatorialConfigure<NerdbankGitVersioningSetVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NerdbankGitVersioningSetVersion, NerdbankGitVersioningLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Creates a git tag to mark a version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningTagSettings.VersionOrRef"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningTagSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningTag(NerdbankGitVersioningTagSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NerdbankGitVersioningTagSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Creates a git tag to mark a version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningTagSettings.VersionOrRef"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningTagSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningTag(Configure<NerdbankGitVersioningTagSettings> configurator)
        {
            return NerdbankGitVersioningTag(configurator(new NerdbankGitVersioningTagSettings()));
        }
        /// <summary>
        ///   <p>Creates a git tag to mark a version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningTagSettings.VersionOrRef"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningTagSettings.Project"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NerdbankGitVersioningTagSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningTag(CombinatorialConfigure<NerdbankGitVersioningTagSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NerdbankGitVersioningTag, NerdbankGitVersioningLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Gets the commit(s) that match a given version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Version"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Project"/></li>
        ///     <li><c>--quiet</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningGetCommits(NerdbankGitVersioningGetCommitsSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NerdbankGitVersioningGetCommitsSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Gets the commit(s) that match a given version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Version"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Project"/></li>
        ///     <li><c>--quiet</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningGetCommits(Configure<NerdbankGitVersioningGetCommitsSettings> configurator)
        {
            return NerdbankGitVersioningGetCommits(configurator(new NerdbankGitVersioningGetCommitsSettings()));
        }
        /// <summary>
        ///   <p>Gets the commit(s) that match a given version.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Version"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Project"/></li>
        ///     <li><c>--quiet</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NerdbankGitVersioningGetCommitsSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningGetCommits(CombinatorialConfigure<NerdbankGitVersioningGetCommitsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NerdbankGitVersioningGetCommits, NerdbankGitVersioningLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Communicates with the ambient cloud build to set the build number and/or other cloud build variables.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--all-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></li>
        ///     <li><c>--ci-system</c> via <see cref="NerdbankGitVersioningCloudSettings.CISystem"/></li>
        ///     <li><c>--common-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></li>
        ///     <li><c>--define</c> via <see cref="NerdbankGitVersioningCloudSettings.Variables"/></li>
        ///     <li><c>--metadata</c> via <see cref="NerdbankGitVersioningCloudSettings.Metadata"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningCloudSettings.Project"/></li>
        ///     <li><c>--version</c> via <see cref="NerdbankGitVersioningCloudSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningCloud(NerdbankGitVersioningCloudSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NerdbankGitVersioningCloudSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Communicates with the ambient cloud build to set the build number and/or other cloud build variables.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--all-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></li>
        ///     <li><c>--ci-system</c> via <see cref="NerdbankGitVersioningCloudSettings.CISystem"/></li>
        ///     <li><c>--common-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></li>
        ///     <li><c>--define</c> via <see cref="NerdbankGitVersioningCloudSettings.Variables"/></li>
        ///     <li><c>--metadata</c> via <see cref="NerdbankGitVersioningCloudSettings.Metadata"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningCloudSettings.Project"/></li>
        ///     <li><c>--version</c> via <see cref="NerdbankGitVersioningCloudSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningCloud(Configure<NerdbankGitVersioningCloudSettings> configurator)
        {
            return NerdbankGitVersioningCloud(configurator(new NerdbankGitVersioningCloudSettings()));
        }
        /// <summary>
        ///   <p>Communicates with the ambient cloud build to set the build number and/or other cloud build variables.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--all-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></li>
        ///     <li><c>--ci-system</c> via <see cref="NerdbankGitVersioningCloudSettings.CISystem"/></li>
        ///     <li><c>--common-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></li>
        ///     <li><c>--define</c> via <see cref="NerdbankGitVersioningCloudSettings.Variables"/></li>
        ///     <li><c>--metadata</c> via <see cref="NerdbankGitVersioningCloudSettings.Metadata"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningCloudSettings.Project"/></li>
        ///     <li><c>--version</c> via <see cref="NerdbankGitVersioningCloudSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NerdbankGitVersioningCloudSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningCloud(CombinatorialConfigure<NerdbankGitVersioningCloudSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NerdbankGitVersioningCloud, NerdbankGitVersioningLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Prepares a release by creating a release branch for the current version and adjusting the version on the current branch.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Tag"/></li>
        ///     <li><c>--nextVersion</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.NextVersion"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Project"/></li>
        ///     <li><c>--versionIncrement</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningPrepareRelease(NerdbankGitVersioningPrepareReleaseSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NerdbankGitVersioningPrepareReleaseSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Prepares a release by creating a release branch for the current version and adjusting the version on the current branch.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Tag"/></li>
        ///     <li><c>--nextVersion</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.NextVersion"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Project"/></li>
        ///     <li><c>--versionIncrement</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NerdbankGitVersioningPrepareRelease(Configure<NerdbankGitVersioningPrepareReleaseSettings> configurator)
        {
            return NerdbankGitVersioningPrepareRelease(configurator(new NerdbankGitVersioningPrepareReleaseSettings()));
        }
        /// <summary>
        ///   <p>Prepares a release by creating a release branch for the current version and adjusting the version on the current branch.</p>
        ///   <p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Tag"/></li>
        ///     <li><c>--nextVersion</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.NextVersion"/></li>
        ///     <li><c>--project</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Project"/></li>
        ///     <li><c>--versionIncrement</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NerdbankGitVersioningPrepareReleaseSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningPrepareRelease(CombinatorialConfigure<NerdbankGitVersioningPrepareReleaseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NerdbankGitVersioningPrepareRelease, NerdbankGitVersioningLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region NerdbankGitVersioningInstallSettings
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NerdbankGitVersioningInstallSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NerdbankGitVersioning executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NerdbankGitVersioningTasks.NerdbankGitVersioningPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NerdbankGitVersioningTasks.NerdbankGitVersioningLogger;
        /// <summary>
        ///   The path to the directory that should contain the version.json file. The default is the root of the git repo.
        /// </summary>
        public virtual string Path { get; internal set; }
        /// <summary>
        ///   The initial version to set. The default is <c>1.0-beta</c>.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The URI(s) of the NuGet package source(s) used to determine the latest stable version of the Nerdbank.GitVersioning package. This setting overrides all of the sources specified in the NuGet.Config files.
        /// </summary>
        public virtual IReadOnlyList<string> Sources => SourcesInternal.AsReadOnly();
        internal List<string> SourcesInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("install")
              .Add("--path {value}", Path)
              .Add("--version {value}", Version)
              .Add("--source {value}", Sources, separator: ' ');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NerdbankGitVersioningGetVersionSettings
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NerdbankGitVersioningGetVersionSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NerdbankGitVersioning executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NerdbankGitVersioningTasks.NerdbankGitVersioningPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NerdbankGitVersioningTasks.NerdbankGitVersioningLogger;
        /// <summary>
        ///   The path to the project or project directory. The default is the current directory.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Adds an identifier to the build metadata part of a semantic version.
        /// </summary>
        public virtual string Metadata { get; internal set; }
        /// <summary>
        ///   The format to write the version information. Allowed values are: <c>text</c>, <c>json</c>. The default is <c>text</c>.
        /// </summary>
        public virtual NerdbankGitVersioningFormat Format { get; internal set; }
        /// <summary>
        ///   The name of just one version property to print to stdout. When specified, the output is always in raw text. Useful in scripts.
        /// </summary>
        public virtual string Variable { get; internal set; }
        /// <summary>
        ///   The commit/ref to get the version information for. The default is <c>HEAD</c>.
        /// </summary>
        public virtual string CommitIsh { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("get-version")
              .Add("--project {value}", Project)
              .Add("--metadata {value}", Metadata)
              .Add("--format {value}", Format)
              .Add("--variable {value}", Variable)
              .Add("-- {value}", CommitIsh);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NerdbankGitVersioningSetVersionSettings
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NerdbankGitVersioningSetVersionSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NerdbankGitVersioning executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NerdbankGitVersioningTasks.NerdbankGitVersioningPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NerdbankGitVersioningTasks.NerdbankGitVersioningLogger;
        /// <summary>
        ///   The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   The version to set.
        /// </summary>
        public virtual string Version { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("set-version")
              .Add("--project {value}", Project)
              .Add("-- {value}", Version);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NerdbankGitVersioningTagSettings
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NerdbankGitVersioningTagSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NerdbankGitVersioning executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NerdbankGitVersioningTasks.NerdbankGitVersioningPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NerdbankGitVersioningTasks.NerdbankGitVersioningLogger;
        /// <summary>
        ///   The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   The <c>a.b.c[.d]</c> version or git ref to be tagged. If not specified, <c>HEAD</c> is used.
        /// </summary>
        public virtual string VersionOrRef { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("tag")
              .Add("--project {value}", Project)
              .Add("-- {value}", VersionOrRef);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NerdbankGitVersioningGetCommitsSettings
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NerdbankGitVersioningGetCommitsSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NerdbankGitVersioning executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NerdbankGitVersioningTasks.NerdbankGitVersioningPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NerdbankGitVersioningTasks.NerdbankGitVersioningLogger;
        /// <summary>
        ///   The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Use minimal output.
        /// </summary>
        public virtual bool? Quiet { get; internal set; }
        /// <summary>
        ///   The <c>a.b.c[.d]</c> version to find.
        /// </summary>
        public virtual string Version { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("get-commits")
              .Add("--project {value}", Project)
              .Add("--quiet", Quiet)
              .Add("-- {value}", Version);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NerdbankGitVersioningCloudSettings
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NerdbankGitVersioningCloudSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NerdbankGitVersioning executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NerdbankGitVersioningTasks.NerdbankGitVersioningPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NerdbankGitVersioningTasks.NerdbankGitVersioningLogger;
        /// <summary>
        ///   The path to the project or project directory used to calculate the version. The default is the current directory. Ignored if the <c>--version</c> option is specified.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Adds an identifier to the build metadata part of a semantic version.
        /// </summary>
        public virtual string Metadata { get; internal set; }
        /// <summary>
        ///   The string to use for the cloud build number. If not specified, the computed version will be used.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   Force activation for a particular CI system. If not specified, auto-detection will be used.
        /// </summary>
        public virtual NerdbankGitVersioningCISystem CISystem { get; internal set; }
        /// <summary>
        ///   Defines ALL version variables as cloud build variables, with a <c>NBGV_</c> prefix.
        /// </summary>
        public virtual bool? AllVars { get; internal set; }
        /// <summary>
        ///   Defines a few common version variables as cloud build variables, with a <c>Git</c> prefix (e.g. <c>GitBuildVersion</c>, <c>GitBuildVersionSimple</c>, <c>GitAssemblyInformationalVersion</c>)
        /// </summary>
        public virtual bool? CommonVars { get; internal set; }
        /// <summary>
        ///   Additional cloud build variables to define.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Variables => VariablesInternal.AsReadOnly();
        internal Dictionary<string,string> VariablesInternal { get; set; } = new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("cloud")
              .Add("--project {value}", Project)
              .Add("--metadata {value}", Metadata)
              .Add("--version {value}", Version)
              .Add("--ci-system {value}", CISystem)
              .Add("--all-vars", AllVars)
              .Add("--common-vars", CommonVars)
              .Add("--define {value}", Variables, "{key}={value}");
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NerdbankGitVersioningPrepareReleaseSettings
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NerdbankGitVersioningPrepareReleaseSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the NerdbankGitVersioning executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NerdbankGitVersioningTasks.NerdbankGitVersioningPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NerdbankGitVersioningTasks.NerdbankGitVersioningLogger;
        /// <summary>
        ///   The path to the project or project directory. The default is the current directory.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///    The version to set for the current branch. If omitted, the next version is determined automatically by incrementing the current version.
        /// </summary>
        public virtual string NextVersion { get; internal set; }
        /// <summary>
        ///   Overrides the 'versionIncrement' setting set in version.json for determining the next version of the current branch.
        /// </summary>
        public virtual string VersionIncrement { get; internal set; }
        /// <summary>
        ///   The prerelease tag to apply on the release branch (if any). If not specified, any existing prerelease tag will be removed. The preceding hyphen may be omitted.
        /// </summary>
        public virtual string Tag { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("prepare-release")
              .Add("--project {value}", Project)
              .Add("--nextVersion {value}", NextVersion)
              .Add("--versionIncrement {value}", VersionIncrement)
              .Add("-- {value}", Tag);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NerdbankGitVersioningInstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NerdbankGitVersioningInstallSettingsExtensions
    {
        #region Path
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningInstallSettings.Path"/></em></p>
        ///   <p>The path to the directory that should contain the version.json file. The default is the root of the git repo.</p>
        /// </summary>
        [Pure]
        public static T SetPath<T>(this T toolSettings, string path) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = path;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningInstallSettings.Path"/></em></p>
        ///   <p>The path to the directory that should contain the version.json file. The default is the root of the git repo.</p>
        /// </summary>
        [Pure]
        public static T ResetPath<T>(this T toolSettings) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningInstallSettings.Version"/></em></p>
        ///   <p>The initial version to set. The default is <c>1.0-beta</c>.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningInstallSettings.Version"/></em></p>
        ///   <p>The initial version to set. The default is <c>1.0-beta</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Sources
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningInstallSettings.Sources"/> to a new list</em></p>
        ///   <p>The URI(s) of the NuGet package source(s) used to determine the latest stable version of the Nerdbank.GitVersioning package. This setting overrides all of the sources specified in the NuGet.Config files.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, params string[] sources) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningInstallSettings.Sources"/> to a new list</em></p>
        ///   <p>The URI(s) of the NuGet package source(s) used to determine the latest stable version of the Nerdbank.GitVersioning package. This setting overrides all of the sources specified in the NuGet.Config files.</p>
        /// </summary>
        [Pure]
        public static T SetSources<T>(this T toolSettings, IEnumerable<string> sources) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal = sources.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NerdbankGitVersioningInstallSettings.Sources"/></em></p>
        ///   <p>The URI(s) of the NuGet package source(s) used to determine the latest stable version of the Nerdbank.GitVersioning package. This setting overrides all of the sources specified in the NuGet.Config files.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, params string[] sources) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="NerdbankGitVersioningInstallSettings.Sources"/></em></p>
        ///   <p>The URI(s) of the NuGet package source(s) used to determine the latest stable version of the Nerdbank.GitVersioning package. This setting overrides all of the sources specified in the NuGet.Config files.</p>
        /// </summary>
        [Pure]
        public static T AddSources<T>(this T toolSettings, IEnumerable<string> sources) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.AddRange(sources);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NerdbankGitVersioningInstallSettings.Sources"/></em></p>
        ///   <p>The URI(s) of the NuGet package source(s) used to determine the latest stable version of the Nerdbank.GitVersioning package. This setting overrides all of the sources specified in the NuGet.Config files.</p>
        /// </summary>
        [Pure]
        public static T ClearSources<T>(this T toolSettings) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourcesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NerdbankGitVersioningInstallSettings.Sources"/></em></p>
        ///   <p>The URI(s) of the NuGet package source(s) used to determine the latest stable version of the Nerdbank.GitVersioning package. This setting overrides all of the sources specified in the NuGet.Config files.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, params string[] sources) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="NerdbankGitVersioningInstallSettings.Sources"/></em></p>
        ///   <p>The URI(s) of the NuGet package source(s) used to determine the latest stable version of the Nerdbank.GitVersioning package. This setting overrides all of the sources specified in the NuGet.Config files.</p>
        /// </summary>
        [Pure]
        public static T RemoveSources<T>(this T toolSettings, IEnumerable<string> sources) where T : NerdbankGitVersioningInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(sources);
            toolSettings.SourcesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NerdbankGitVersioningGetVersionSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NerdbankGitVersioningGetVersionSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningGetVersionSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : NerdbankGitVersioningGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningGetVersionSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : NerdbankGitVersioningGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Metadata
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningGetVersionSettings.Metadata"/></em></p>
        ///   <p>Adds an identifier to the build metadata part of a semantic version.</p>
        /// </summary>
        [Pure]
        public static T SetMetadata<T>(this T toolSettings, string metadata) where T : NerdbankGitVersioningGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Metadata = metadata;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningGetVersionSettings.Metadata"/></em></p>
        ///   <p>Adds an identifier to the build metadata part of a semantic version.</p>
        /// </summary>
        [Pure]
        public static T ResetMetadata<T>(this T toolSettings) where T : NerdbankGitVersioningGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Metadata = null;
            return toolSettings;
        }
        #endregion
        #region Format
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningGetVersionSettings.Format"/></em></p>
        ///   <p>The format to write the version information. Allowed values are: <c>text</c>, <c>json</c>. The default is <c>text</c>.</p>
        /// </summary>
        [Pure]
        public static T SetFormat<T>(this T toolSettings, NerdbankGitVersioningFormat format) where T : NerdbankGitVersioningGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = format;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningGetVersionSettings.Format"/></em></p>
        ///   <p>The format to write the version information. Allowed values are: <c>text</c>, <c>json</c>. The default is <c>text</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetFormat<T>(this T toolSettings) where T : NerdbankGitVersioningGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = null;
            return toolSettings;
        }
        #endregion
        #region Variable
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningGetVersionSettings.Variable"/></em></p>
        ///   <p>The name of just one version property to print to stdout. When specified, the output is always in raw text. Useful in scripts.</p>
        /// </summary>
        [Pure]
        public static T SetVariable<T>(this T toolSettings, string variable) where T : NerdbankGitVersioningGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variable = variable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningGetVersionSettings.Variable"/></em></p>
        ///   <p>The name of just one version property to print to stdout. When specified, the output is always in raw text. Useful in scripts.</p>
        /// </summary>
        [Pure]
        public static T ResetVariable<T>(this T toolSettings) where T : NerdbankGitVersioningGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variable = null;
            return toolSettings;
        }
        #endregion
        #region CommitIsh
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningGetVersionSettings.CommitIsh"/></em></p>
        ///   <p>The commit/ref to get the version information for. The default is <c>HEAD</c>.</p>
        /// </summary>
        [Pure]
        public static T SetCommitIsh<T>(this T toolSettings, string commitIsh) where T : NerdbankGitVersioningGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitIsh = commitIsh;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningGetVersionSettings.CommitIsh"/></em></p>
        ///   <p>The commit/ref to get the version information for. The default is <c>HEAD</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetCommitIsh<T>(this T toolSettings) where T : NerdbankGitVersioningGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitIsh = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NerdbankGitVersioningSetVersionSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NerdbankGitVersioningSetVersionSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningSetVersionSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : NerdbankGitVersioningSetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningSetVersionSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : NerdbankGitVersioningSetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningSetVersionSettings.Version"/></em></p>
        ///   <p>The version to set.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : NerdbankGitVersioningSetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningSetVersionSettings.Version"/></em></p>
        ///   <p>The version to set.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : NerdbankGitVersioningSetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NerdbankGitVersioningTagSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NerdbankGitVersioningTagSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningTagSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : NerdbankGitVersioningTagSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningTagSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : NerdbankGitVersioningTagSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region VersionOrRef
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningTagSettings.VersionOrRef"/></em></p>
        ///   <p>The <c>a.b.c[.d]</c> version or git ref to be tagged. If not specified, <c>HEAD</c> is used.</p>
        /// </summary>
        [Pure]
        public static T SetVersionOrRef<T>(this T toolSettings, string versionOrRef) where T : NerdbankGitVersioningTagSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionOrRef = versionOrRef;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningTagSettings.VersionOrRef"/></em></p>
        ///   <p>The <c>a.b.c[.d]</c> version or git ref to be tagged. If not specified, <c>HEAD</c> is used.</p>
        /// </summary>
        [Pure]
        public static T ResetVersionOrRef<T>(this T toolSettings) where T : NerdbankGitVersioningTagSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionOrRef = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NerdbankGitVersioningGetCommitsSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NerdbankGitVersioningGetCommitsSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningGetCommitsSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : NerdbankGitVersioningGetCommitsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningGetCommitsSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : NerdbankGitVersioningGetCommitsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Quiet
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></em></p>
        ///   <p>Use minimal output.</p>
        /// </summary>
        [Pure]
        public static T SetQuiet<T>(this T toolSettings, bool? quiet) where T : NerdbankGitVersioningGetCommitsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = quiet;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></em></p>
        ///   <p>Use minimal output.</p>
        /// </summary>
        [Pure]
        public static T ResetQuiet<T>(this T toolSettings) where T : NerdbankGitVersioningGetCommitsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></em></p>
        ///   <p>Use minimal output.</p>
        /// </summary>
        [Pure]
        public static T EnableQuiet<T>(this T toolSettings) where T : NerdbankGitVersioningGetCommitsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></em></p>
        ///   <p>Use minimal output.</p>
        /// </summary>
        [Pure]
        public static T DisableQuiet<T>(this T toolSettings) where T : NerdbankGitVersioningGetCommitsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></em></p>
        ///   <p>Use minimal output.</p>
        /// </summary>
        [Pure]
        public static T ToggleQuiet<T>(this T toolSettings) where T : NerdbankGitVersioningGetCommitsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = !toolSettings.Quiet;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningGetCommitsSettings.Version"/></em></p>
        ///   <p>The <c>a.b.c[.d]</c> version to find.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : NerdbankGitVersioningGetCommitsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningGetCommitsSettings.Version"/></em></p>
        ///   <p>The <c>a.b.c[.d]</c> version to find.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : NerdbankGitVersioningGetCommitsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NerdbankGitVersioningCloudSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NerdbankGitVersioningCloudSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningCloudSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory used to calculate the version. The default is the current directory. Ignored if the <c>--version</c> option is specified.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningCloudSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory used to calculate the version. The default is the current directory. Ignored if the <c>--version</c> option is specified.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region Metadata
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningCloudSettings.Metadata"/></em></p>
        ///   <p>Adds an identifier to the build metadata part of a semantic version.</p>
        /// </summary>
        [Pure]
        public static T SetMetadata<T>(this T toolSettings, string metadata) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Metadata = metadata;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningCloudSettings.Metadata"/></em></p>
        ///   <p>Adds an identifier to the build metadata part of a semantic version.</p>
        /// </summary>
        [Pure]
        public static T ResetMetadata<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Metadata = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningCloudSettings.Version"/></em></p>
        ///   <p>The string to use for the cloud build number. If not specified, the computed version will be used.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningCloudSettings.Version"/></em></p>
        ///   <p>The string to use for the cloud build number. If not specified, the computed version will be used.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region CISystem
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningCloudSettings.CISystem"/></em></p>
        ///   <p>Force activation for a particular CI system. If not specified, auto-detection will be used.</p>
        /// </summary>
        [Pure]
        public static T SetCISystem<T>(this T toolSettings, NerdbankGitVersioningCISystem cisystem) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CISystem = cisystem;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningCloudSettings.CISystem"/></em></p>
        ///   <p>Force activation for a particular CI system. If not specified, auto-detection will be used.</p>
        /// </summary>
        [Pure]
        public static T ResetCISystem<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CISystem = null;
            return toolSettings;
        }
        #endregion
        #region AllVars
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></em></p>
        ///   <p>Defines ALL version variables as cloud build variables, with a <c>NBGV_</c> prefix.</p>
        /// </summary>
        [Pure]
        public static T SetAllVars<T>(this T toolSettings, bool? allVars) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVars = allVars;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></em></p>
        ///   <p>Defines ALL version variables as cloud build variables, with a <c>NBGV_</c> prefix.</p>
        /// </summary>
        [Pure]
        public static T ResetAllVars<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVars = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></em></p>
        ///   <p>Defines ALL version variables as cloud build variables, with a <c>NBGV_</c> prefix.</p>
        /// </summary>
        [Pure]
        public static T EnableAllVars<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVars = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></em></p>
        ///   <p>Defines ALL version variables as cloud build variables, with a <c>NBGV_</c> prefix.</p>
        /// </summary>
        [Pure]
        public static T DisableAllVars<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVars = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></em></p>
        ///   <p>Defines ALL version variables as cloud build variables, with a <c>NBGV_</c> prefix.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllVars<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllVars = !toolSettings.AllVars;
            return toolSettings;
        }
        #endregion
        #region CommonVars
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></em></p>
        ///   <p>Defines a few common version variables as cloud build variables, with a <c>Git</c> prefix (e.g. <c>GitBuildVersion</c>, <c>GitBuildVersionSimple</c>, <c>GitAssemblyInformationalVersion</c>)</p>
        /// </summary>
        [Pure]
        public static T SetCommonVars<T>(this T toolSettings, bool? commonVars) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonVars = commonVars;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></em></p>
        ///   <p>Defines a few common version variables as cloud build variables, with a <c>Git</c> prefix (e.g. <c>GitBuildVersion</c>, <c>GitBuildVersionSimple</c>, <c>GitAssemblyInformationalVersion</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetCommonVars<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonVars = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></em></p>
        ///   <p>Defines a few common version variables as cloud build variables, with a <c>Git</c> prefix (e.g. <c>GitBuildVersion</c>, <c>GitBuildVersionSimple</c>, <c>GitAssemblyInformationalVersion</c>)</p>
        /// </summary>
        [Pure]
        public static T EnableCommonVars<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonVars = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></em></p>
        ///   <p>Defines a few common version variables as cloud build variables, with a <c>Git</c> prefix (e.g. <c>GitBuildVersion</c>, <c>GitBuildVersionSimple</c>, <c>GitAssemblyInformationalVersion</c>)</p>
        /// </summary>
        [Pure]
        public static T DisableCommonVars<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonVars = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></em></p>
        ///   <p>Defines a few common version variables as cloud build variables, with a <c>Git</c> prefix (e.g. <c>GitBuildVersion</c>, <c>GitBuildVersionSimple</c>, <c>GitAssemblyInformationalVersion</c>)</p>
        /// </summary>
        [Pure]
        public static T ToggleCommonVars<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommonVars = !toolSettings.CommonVars;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningCloudSettings.Variables"/> to a new dictionary</em></p>
        ///   <p>Additional cloud build variables to define.</p>
        /// </summary>
        [Pure]
        public static T SetVariables<T>(this T toolSettings, IDictionary<string, string> variables) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal = variables.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="NerdbankGitVersioningCloudSettings.Variables"/></em></p>
        ///   <p>Additional cloud build variables to define.</p>
        /// </summary>
        [Pure]
        public static T ClearVariables<T>(this T toolSettings) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="NerdbankGitVersioningCloudSettings.Variables"/></em></p>
        ///   <p>Additional cloud build variables to define.</p>
        /// </summary>
        [Pure]
        public static T AddVariable<T>(this T toolSettings, string variableKey, string variableValue) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Add(variableKey, variableValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="NerdbankGitVersioningCloudSettings.Variables"/></em></p>
        ///   <p>Additional cloud build variables to define.</p>
        /// </summary>
        [Pure]
        public static T RemoveVariable<T>(this T toolSettings, string variableKey) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Remove(variableKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="NerdbankGitVersioningCloudSettings.Variables"/></em></p>
        ///   <p>Additional cloud build variables to define.</p>
        /// </summary>
        [Pure]
        public static T SetVariable<T>(this T toolSettings, string variableKey, string variableValue) where T : NerdbankGitVersioningCloudSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal[variableKey] = variableValue;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NerdbankGitVersioningPrepareReleaseSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NerdbankGitVersioningPrepareReleaseSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningPrepareReleaseSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : NerdbankGitVersioningPrepareReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningPrepareReleaseSettings.Project"/></em></p>
        ///   <p>The path to the project or project directory. The default is the current directory.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : NerdbankGitVersioningPrepareReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region NextVersion
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningPrepareReleaseSettings.NextVersion"/></em></p>
        ///   <p> The version to set for the current branch. If omitted, the next version is determined automatically by incrementing the current version.</p>
        /// </summary>
        [Pure]
        public static T SetNextVersion<T>(this T toolSettings, string nextVersion) where T : NerdbankGitVersioningPrepareReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NextVersion = nextVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningPrepareReleaseSettings.NextVersion"/></em></p>
        ///   <p> The version to set for the current branch. If omitted, the next version is determined automatically by incrementing the current version.</p>
        /// </summary>
        [Pure]
        public static T ResetNextVersion<T>(this T toolSettings) where T : NerdbankGitVersioningPrepareReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NextVersion = null;
            return toolSettings;
        }
        #endregion
        #region VersionIncrement
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement"/></em></p>
        ///   <p>Overrides the 'versionIncrement' setting set in version.json for determining the next version of the current branch.</p>
        /// </summary>
        [Pure]
        public static T SetVersionIncrement<T>(this T toolSettings, string versionIncrement) where T : NerdbankGitVersioningPrepareReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionIncrement = versionIncrement;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement"/></em></p>
        ///   <p>Overrides the 'versionIncrement' setting set in version.json for determining the next version of the current branch.</p>
        /// </summary>
        [Pure]
        public static T ResetVersionIncrement<T>(this T toolSettings) where T : NerdbankGitVersioningPrepareReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VersionIncrement = null;
            return toolSettings;
        }
        #endregion
        #region Tag
        /// <summary>
        ///   <p><em>Sets <see cref="NerdbankGitVersioningPrepareReleaseSettings.Tag"/></em></p>
        ///   <p>The prerelease tag to apply on the release branch (if any). If not specified, any existing prerelease tag will be removed. The preceding hyphen may be omitted.</p>
        /// </summary>
        [Pure]
        public static T SetTag<T>(this T toolSettings, string tag) where T : NerdbankGitVersioningPrepareReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tag = tag;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NerdbankGitVersioningPrepareReleaseSettings.Tag"/></em></p>
        ///   <p>The prerelease tag to apply on the release branch (if any). If not specified, any existing prerelease tag will be removed. The preceding hyphen may be omitted.</p>
        /// </summary>
        [Pure]
        public static T ResetTag<T>(this T toolSettings) where T : NerdbankGitVersioningPrepareReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tag = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NerdbankGitVersioningFormat
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<NerdbankGitVersioningFormat>))]
    public partial class NerdbankGitVersioningFormat : Enumeration
    {
        public static NerdbankGitVersioningFormat text = (NerdbankGitVersioningFormat) "text";
        public static NerdbankGitVersioningFormat json = (NerdbankGitVersioningFormat) "json";
        public static implicit operator NerdbankGitVersioningFormat(string value)
        {
            return new NerdbankGitVersioningFormat { Value = value };
        }
    }
    #endregion
    #region NerdbankGitVersioningCISystem
    /// <summary>
    ///   Used within <see cref="NerdbankGitVersioningTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<NerdbankGitVersioningCISystem>))]
    public partial class NerdbankGitVersioningCISystem : Enumeration
    {
        public static NerdbankGitVersioningCISystem AppVeyor = (NerdbankGitVersioningCISystem) "AppVeyor";
        public static NerdbankGitVersioningCISystem VisualStudioTeamServices = (NerdbankGitVersioningCISystem) "VisualStudioTeamServices";
        public static NerdbankGitVersioningCISystem GitHubActions = (NerdbankGitVersioningCISystem) "GitHubActions";
        public static NerdbankGitVersioningCISystem TeamCity = (NerdbankGitVersioningCISystem) "TeamCity";
        public static NerdbankGitVersioningCISystem AtlassianBamboo = (NerdbankGitVersioningCISystem) "AtlassianBamboo";
        public static NerdbankGitVersioningCISystem Jenkins = (NerdbankGitVersioningCISystem) "Jenkins";
        public static NerdbankGitVersioningCISystem GitLab = (NerdbankGitVersioningCISystem) "GitLab";
        public static NerdbankGitVersioningCISystem Travis = (NerdbankGitVersioningCISystem) "Travis";
        public static implicit operator NerdbankGitVersioningCISystem(string value)
        {
            return new NerdbankGitVersioningCISystem { Value = value };
        }
    }
    #endregion
}
