// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/GitReleaseManager/GitReleaseManager.json

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

namespace Nuke.Common.Tools.GitReleaseManager
{
    /// <summary>
    ///   <p>GitReleaseManager is a tool that will help create a set of release notes for your application/product. It does this using the collection of issues which are stored on the GitHub Issue Tracker for your application/product.<para/>By inspecting the issues that have been assigned to a particular milestone, GitReleaseManager creates a set of release notes, in markdown format, which are then used to create a Release on GitHub.<para/>In addition to creating a Release, GitReleaseManager can be used to publish a release, close a milestone, and also to export the complete set of release notes for your application/product.</p>
    ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(GitReleaseManagerPackageId)]
    public partial class GitReleaseManagerTasks
        : IRequireNuGetPackage
    {
        public const string GitReleaseManagerPackageId = "gitreleasemanager";
        /// <summary>
        ///   Path to the GitReleaseManager executable.
        /// </summary>
        public static string GitReleaseManagerPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("GITRELEASEMANAGER_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("gitreleasemanager", "GitReleaseManager.exe");
        public static Action<OutputType, string> GitReleaseManagerLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>GitReleaseManager is a tool that will help create a set of release notes for your application/product. It does this using the collection of issues which are stored on the GitHub Issue Tracker for your application/product.<para/>By inspecting the issues that have been assigned to a particular milestone, GitReleaseManager creates a set of release notes, in markdown format, which are then used to create a Release on GitHub.<para/>In addition to creating a Release, GitReleaseManager can be used to publish a release, close a milestone, and also to export the complete set of release notes for your application/product.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> GitReleaseManager(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(GitReleaseManagerPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? GitReleaseManagerLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Adds an asset to an existing release.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--assets</c> via <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></li>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerAddAssetsSettings.LogFilePath"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerAddAssetsSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryName"/></li>
        ///     <li><c>--tagName</c> via <see cref="GitReleaseManagerAddAssetsSettings.TagName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerAddAssetsSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerAddAssetsSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> GitReleaseManagerAddAssets(GitReleaseManagerAddAssetsSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new GitReleaseManagerAddAssetsSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Adds an asset to an existing release.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--assets</c> via <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></li>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerAddAssetsSettings.LogFilePath"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerAddAssetsSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryName"/></li>
        ///     <li><c>--tagName</c> via <see cref="GitReleaseManagerAddAssetsSettings.TagName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerAddAssetsSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerAddAssetsSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> GitReleaseManagerAddAssets(Configure<GitReleaseManagerAddAssetsSettings> configurator)
        {
            return GitReleaseManagerAddAssets(configurator(new GitReleaseManagerAddAssetsSettings()));
        }
        /// <summary>
        ///   <p>Adds an asset to an existing release.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--assets</c> via <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></li>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerAddAssetsSettings.LogFilePath"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerAddAssetsSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryName"/></li>
        ///     <li><c>--tagName</c> via <see cref="GitReleaseManagerAddAssetsSettings.TagName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerAddAssetsSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerAddAssetsSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(GitReleaseManagerAddAssetsSettings Settings, IReadOnlyCollection<Output> Output)> GitReleaseManagerAddAssets(CombinatorialConfigure<GitReleaseManagerAddAssetsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(GitReleaseManagerAddAssets, GitReleaseManagerLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Closes the milestone.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerCloseSettings.LogFilePath"/></li>
        ///     <li><c>--milestone</c> via <see cref="GitReleaseManagerCloseSettings.Milestone"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerCloseSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCloseSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerCloseSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> GitReleaseManagerClose(GitReleaseManagerCloseSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new GitReleaseManagerCloseSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Closes the milestone.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerCloseSettings.LogFilePath"/></li>
        ///     <li><c>--milestone</c> via <see cref="GitReleaseManagerCloseSettings.Milestone"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerCloseSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCloseSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerCloseSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> GitReleaseManagerClose(Configure<GitReleaseManagerCloseSettings> configurator)
        {
            return GitReleaseManagerClose(configurator(new GitReleaseManagerCloseSettings()));
        }
        /// <summary>
        ///   <p>Closes the milestone.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerCloseSettings.LogFilePath"/></li>
        ///     <li><c>--milestone</c> via <see cref="GitReleaseManagerCloseSettings.Milestone"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerCloseSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCloseSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerCloseSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(GitReleaseManagerCloseSettings Settings, IReadOnlyCollection<Output> Output)> GitReleaseManagerClose(CombinatorialConfigure<GitReleaseManagerCloseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(GitReleaseManagerClose, GitReleaseManagerLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Creates a draft release notes from a milestone.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--assets</c> via <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></li>
        ///     <li><c>--inputFilePath</c> via <see cref="GitReleaseManagerCreateSettings.InputFilePath"/></li>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerCreateSettings.LogFilePath"/></li>
        ///     <li><c>--milestone</c> via <see cref="GitReleaseManagerCreateSettings.Milestone"/></li>
        ///     <li><c>--name</c> via <see cref="GitReleaseManagerCreateSettings.Name"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerCreateSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="GitReleaseManagerCreateSettings.Prerelease"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryName"/></li>
        ///     <li><c>--targetcommitish</c> via <see cref="GitReleaseManagerCreateSettings.TargetCommitish"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCreateSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerCreateSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> GitReleaseManagerCreate(GitReleaseManagerCreateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new GitReleaseManagerCreateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Creates a draft release notes from a milestone.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--assets</c> via <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></li>
        ///     <li><c>--inputFilePath</c> via <see cref="GitReleaseManagerCreateSettings.InputFilePath"/></li>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerCreateSettings.LogFilePath"/></li>
        ///     <li><c>--milestone</c> via <see cref="GitReleaseManagerCreateSettings.Milestone"/></li>
        ///     <li><c>--name</c> via <see cref="GitReleaseManagerCreateSettings.Name"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerCreateSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="GitReleaseManagerCreateSettings.Prerelease"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryName"/></li>
        ///     <li><c>--targetcommitish</c> via <see cref="GitReleaseManagerCreateSettings.TargetCommitish"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCreateSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerCreateSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> GitReleaseManagerCreate(Configure<GitReleaseManagerCreateSettings> configurator)
        {
            return GitReleaseManagerCreate(configurator(new GitReleaseManagerCreateSettings()));
        }
        /// <summary>
        ///   <p>Creates a draft release notes from a milestone.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--assets</c> via <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></li>
        ///     <li><c>--inputFilePath</c> via <see cref="GitReleaseManagerCreateSettings.InputFilePath"/></li>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerCreateSettings.LogFilePath"/></li>
        ///     <li><c>--milestone</c> via <see cref="GitReleaseManagerCreateSettings.Milestone"/></li>
        ///     <li><c>--name</c> via <see cref="GitReleaseManagerCreateSettings.Name"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerCreateSettings.Password"/></li>
        ///     <li><c>--prerelease</c> via <see cref="GitReleaseManagerCreateSettings.Prerelease"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryName"/></li>
        ///     <li><c>--targetcommitish</c> via <see cref="GitReleaseManagerCreateSettings.TargetCommitish"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCreateSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerCreateSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(GitReleaseManagerCreateSettings Settings, IReadOnlyCollection<Output> Output)> GitReleaseManagerCreate(CombinatorialConfigure<GitReleaseManagerCreateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(GitReleaseManagerCreate, GitReleaseManagerLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Exports all the Release Notes in markdown format.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--fileOutputPath</c> via <see cref="GitReleaseManagerExportSettings.FileOutputPath"/></li>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerExportSettings.LogFilePath"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerExportSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerExportSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerExportSettings.RepositoryName"/></li>
        ///     <li><c>--tagName</c> via <see cref="GitReleaseManagerExportSettings.TagName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerExportSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerExportSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> GitReleaseManagerExport(GitReleaseManagerExportSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new GitReleaseManagerExportSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Exports all the Release Notes in markdown format.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--fileOutputPath</c> via <see cref="GitReleaseManagerExportSettings.FileOutputPath"/></li>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerExportSettings.LogFilePath"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerExportSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerExportSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerExportSettings.RepositoryName"/></li>
        ///     <li><c>--tagName</c> via <see cref="GitReleaseManagerExportSettings.TagName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerExportSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerExportSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> GitReleaseManagerExport(Configure<GitReleaseManagerExportSettings> configurator)
        {
            return GitReleaseManagerExport(configurator(new GitReleaseManagerExportSettings()));
        }
        /// <summary>
        ///   <p>Exports all the Release Notes in markdown format.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--fileOutputPath</c> via <see cref="GitReleaseManagerExportSettings.FileOutputPath"/></li>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerExportSettings.LogFilePath"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerExportSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerExportSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerExportSettings.RepositoryName"/></li>
        ///     <li><c>--tagName</c> via <see cref="GitReleaseManagerExportSettings.TagName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerExportSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerExportSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(GitReleaseManagerExportSettings Settings, IReadOnlyCollection<Output> Output)> GitReleaseManagerExport(CombinatorialConfigure<GitReleaseManagerExportSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(GitReleaseManagerExport, GitReleaseManagerLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Publishes the GitHub Release.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerPublishSettings.LogFilePath"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerPublishSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryName"/></li>
        ///     <li><c>--tagName</c> via <see cref="GitReleaseManagerPublishSettings.TagName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerPublishSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerPublishSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> GitReleaseManagerPublish(GitReleaseManagerPublishSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new GitReleaseManagerPublishSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Publishes the GitHub Release.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerPublishSettings.LogFilePath"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerPublishSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryName"/></li>
        ///     <li><c>--tagName</c> via <see cref="GitReleaseManagerPublishSettings.TagName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerPublishSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerPublishSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> GitReleaseManagerPublish(Configure<GitReleaseManagerPublishSettings> configurator)
        {
            return GitReleaseManagerPublish(configurator(new GitReleaseManagerPublishSettings()));
        }
        /// <summary>
        ///   <p>Publishes the GitHub Release.</p>
        ///   <p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--logFilePath</c> via <see cref="GitReleaseManagerPublishSettings.LogFilePath"/></li>
        ///     <li><c>--owner</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryOwner"/></li>
        ///     <li><c>--password</c> via <see cref="GitReleaseManagerPublishSettings.Password"/></li>
        ///     <li><c>--repository</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryName"/></li>
        ///     <li><c>--tagName</c> via <see cref="GitReleaseManagerPublishSettings.TagName"/></li>
        ///     <li><c>--targetDirectory</c> via <see cref="GitReleaseManagerPublishSettings.TargetDirectory"/></li>
        ///     <li><c>--username</c> via <see cref="GitReleaseManagerPublishSettings.UserName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(GitReleaseManagerPublishSettings Settings, IReadOnlyCollection<Output> Output)> GitReleaseManagerPublish(CombinatorialConfigure<GitReleaseManagerPublishSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(GitReleaseManagerPublish, GitReleaseManagerLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region GitReleaseManagerAddAssetsSettings
    /// <summary>
    ///   Used within <see cref="GitReleaseManagerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitReleaseManagerAddAssetsSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the GitReleaseManager executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GitReleaseManagerTasks.GitReleaseManagerPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? GitReleaseManagerTasks.GitReleaseManagerLogger;
        /// <summary>
        ///   Paths to the files to include in the release.
        /// </summary>
        public virtual IReadOnlyList<string> AssetPaths => AssetPathsInternal.AsReadOnly();
        internal List<string> AssetPathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   The name of the release. Typically this is the generated SemVer Version Number.
        /// </summary>
        public virtual string TagName { get; internal set; }
        /// <summary>
        ///   The username to access GitHub with.
        /// </summary>
        public virtual string UserName { get; internal set; }
        /// <summary>
        ///   The password to access GitHub with.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   The owner of the repository.
        /// </summary>
        public virtual string RepositoryOwner { get; internal set; }
        /// <summary>
        ///   The name of the repository.
        /// </summary>
        public virtual string RepositoryName { get; internal set; }
        /// <summary>
        ///   The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.
        /// </summary>
        public virtual string TargetDirectory { get; internal set; }
        /// <summary>
        ///   Path to where log file should be created. Defaults is <em>logging to console</em>.
        /// </summary>
        public virtual string LogFilePath { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("addasset")
              .Add("--assets {value}", AssetPaths, separator: ',')
              .Add("--tagName {value}", TagName)
              .Add("--username {value}", UserName)
              .Add("--password {value}", Password, secret: true)
              .Add("--owner {value}", RepositoryOwner)
              .Add("--repository {value}", RepositoryName)
              .Add("--targetDirectory {value}", TargetDirectory)
              .Add("--logFilePath {value}", LogFilePath);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region GitReleaseManagerCloseSettings
    /// <summary>
    ///   Used within <see cref="GitReleaseManagerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitReleaseManagerCloseSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the GitReleaseManager executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GitReleaseManagerTasks.GitReleaseManagerPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? GitReleaseManagerTasks.GitReleaseManagerLogger;
        /// <summary>
        ///   The milestone to use.
        /// </summary>
        public virtual string Milestone { get; internal set; }
        /// <summary>
        ///   The username to access GitHub with.
        /// </summary>
        public virtual string UserName { get; internal set; }
        /// <summary>
        ///   The password to access GitHub with.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   The owner of the repository.
        /// </summary>
        public virtual string RepositoryOwner { get; internal set; }
        /// <summary>
        ///   The name of the repository.
        /// </summary>
        public virtual string RepositoryName { get; internal set; }
        /// <summary>
        ///   The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.
        /// </summary>
        public virtual string TargetDirectory { get; internal set; }
        /// <summary>
        ///   Path to where log file should be created. Defaults is <em>logging to console</em>.
        /// </summary>
        public virtual string LogFilePath { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("close")
              .Add("--milestone {value}", Milestone)
              .Add("--username {value}", UserName)
              .Add("--password {value}", Password, secret: true)
              .Add("--owner {value}", RepositoryOwner)
              .Add("--repository {value}", RepositoryName)
              .Add("--targetDirectory {value}", TargetDirectory)
              .Add("--logFilePath {value}", LogFilePath);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region GitReleaseManagerCreateSettings
    /// <summary>
    ///   Used within <see cref="GitReleaseManagerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitReleaseManagerCreateSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the GitReleaseManager executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GitReleaseManagerTasks.GitReleaseManagerPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? GitReleaseManagerTasks.GitReleaseManagerLogger;
        /// <summary>
        ///   Paths to the files to include in the release.
        /// </summary>
        public virtual IReadOnlyList<string> AssetPaths => AssetPathsInternal.AsReadOnly();
        internal List<string> AssetPathsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   The commit to tag. Can be a branch or SHA. Defaults to repository's default branch.
        /// </summary>
        public virtual string TargetCommitish { get; internal set; }
        /// <summary>
        ///   The milestone to use.
        /// </summary>
        public virtual string Milestone { get; internal set; }
        /// <summary>
        ///   The name of the release. Typically this is the generated SemVer Version Number.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   The path to the file to be used as the content of the release notes.
        /// </summary>
        public virtual string InputFilePath { get; internal set; }
        /// <summary>
        ///   Creates the release as a pre-release.
        /// </summary>
        public virtual bool? Prerelease { get; internal set; }
        /// <summary>
        ///   The username to access GitHub with.
        /// </summary>
        public virtual string UserName { get; internal set; }
        /// <summary>
        ///   The password to access GitHub with.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   The owner of the repository.
        /// </summary>
        public virtual string RepositoryOwner { get; internal set; }
        /// <summary>
        ///   The name of the repository.
        /// </summary>
        public virtual string RepositoryName { get; internal set; }
        /// <summary>
        ///   The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.
        /// </summary>
        public virtual string TargetDirectory { get; internal set; }
        /// <summary>
        ///   Path to where log file should be created. Defaults is <em>logging to console</em>.
        /// </summary>
        public virtual string LogFilePath { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("create")
              .Add("--assets {value}", AssetPaths, separator: ',')
              .Add("--targetcommitish {value}", TargetCommitish)
              .Add("--milestone {value}", Milestone)
              .Add("--name {value}", Name)
              .Add("--inputFilePath {value}", InputFilePath)
              .Add("--prerelease", Prerelease)
              .Add("--username {value}", UserName)
              .Add("--password {value}", Password, secret: true)
              .Add("--owner {value}", RepositoryOwner)
              .Add("--repository {value}", RepositoryName)
              .Add("--targetDirectory {value}", TargetDirectory)
              .Add("--logFilePath {value}", LogFilePath);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region GitReleaseManagerExportSettings
    /// <summary>
    ///   Used within <see cref="GitReleaseManagerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitReleaseManagerExportSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the GitReleaseManager executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GitReleaseManagerTasks.GitReleaseManagerPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? GitReleaseManagerTasks.GitReleaseManagerLogger;
        /// <summary>
        ///   The name of the release. Typically this is the generated SemVer Version Number.
        /// </summary>
        public virtual string TagName { get; internal set; }
        /// <summary>
        ///   Path to the file export releases.
        /// </summary>
        public virtual string FileOutputPath { get; internal set; }
        /// <summary>
        ///   The username to access GitHub with.
        /// </summary>
        public virtual string UserName { get; internal set; }
        /// <summary>
        ///   The password to access GitHub with.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   The owner of the repository.
        /// </summary>
        public virtual string RepositoryOwner { get; internal set; }
        /// <summary>
        ///   The name of the repository.
        /// </summary>
        public virtual string RepositoryName { get; internal set; }
        /// <summary>
        ///   The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.
        /// </summary>
        public virtual string TargetDirectory { get; internal set; }
        /// <summary>
        ///   Path to where log file should be created. Defaults is <em>logging to console</em>.
        /// </summary>
        public virtual string LogFilePath { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("export")
              .Add("--tagName {value}", TagName)
              .Add("--fileOutputPath {value}", FileOutputPath)
              .Add("--username {value}", UserName)
              .Add("--password {value}", Password, secret: true)
              .Add("--owner {value}", RepositoryOwner)
              .Add("--repository {value}", RepositoryName)
              .Add("--targetDirectory {value}", TargetDirectory)
              .Add("--logFilePath {value}", LogFilePath);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region GitReleaseManagerPublishSettings
    /// <summary>
    ///   Used within <see cref="GitReleaseManagerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitReleaseManagerPublishSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the GitReleaseManager executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GitReleaseManagerTasks.GitReleaseManagerPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? GitReleaseManagerTasks.GitReleaseManagerLogger;
        /// <summary>
        ///   The name of the release. Typically this is the generated SemVer Version Number.
        /// </summary>
        public virtual string TagName { get; internal set; }
        /// <summary>
        ///   The username to access GitHub with.
        /// </summary>
        public virtual string UserName { get; internal set; }
        /// <summary>
        ///   The password to access GitHub with.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   The owner of the repository.
        /// </summary>
        public virtual string RepositoryOwner { get; internal set; }
        /// <summary>
        ///   The name of the repository.
        /// </summary>
        public virtual string RepositoryName { get; internal set; }
        /// <summary>
        ///   The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.
        /// </summary>
        public virtual string TargetDirectory { get; internal set; }
        /// <summary>
        ///   Path to where log file should be created. Defaults is <em>logging to console</em>.
        /// </summary>
        public virtual string LogFilePath { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("publish")
              .Add("--tagName {value}", TagName)
              .Add("--username {value}", UserName)
              .Add("--password {value}", Password, secret: true)
              .Add("--owner {value}", RepositoryOwner)
              .Add("--repository {value}", RepositoryName)
              .Add("--targetDirectory {value}", TargetDirectory)
              .Add("--logFilePath {value}", LogFilePath);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region GitReleaseManagerAddAssetsSettingsExtensions
    /// <summary>
    ///   Used within <see cref="GitReleaseManagerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitReleaseManagerAddAssetsSettingsExtensions
    {
        #region AssetPaths
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/> to a new list</em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T SetAssetPaths<T>(this T toolSettings, params string[] assetPaths) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetPathsInternal = assetPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/> to a new list</em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T SetAssetPaths<T>(this T toolSettings, IEnumerable<string> assetPaths) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetPathsInternal = assetPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T AddAssetPaths<T>(this T toolSettings, params string[] assetPaths) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetPathsInternal.AddRange(assetPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T AddAssetPaths<T>(this T toolSettings, IEnumerable<string> assetPaths) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetPathsInternal.AddRange(assetPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T ClearAssetPaths<T>(this T toolSettings) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T RemoveAssetPaths<T>(this T toolSettings, params string[] assetPaths) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assetPaths);
            toolSettings.AssetPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T RemoveAssetPaths<T>(this T toolSettings, IEnumerable<string> assetPaths) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assetPaths);
            toolSettings.AssetPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TagName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerAddAssetsSettings.TagName"/></em></p>
        ///   <p>The name of the release. Typically this is the generated SemVer Version Number.</p>
        /// </summary>
        [Pure]
        public static T SetTagName<T>(this T toolSettings, string tagName) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagName = tagName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerAddAssetsSettings.TagName"/></em></p>
        ///   <p>The name of the release. Typically this is the generated SemVer Version Number.</p>
        /// </summary>
        [Pure]
        public static T ResetTagName<T>(this T toolSettings) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagName = null;
            return toolSettings;
        }
        #endregion
        #region UserName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerAddAssetsSettings.UserName"/></em></p>
        ///   <p>The username to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T SetUserName<T>(this T toolSettings, string userName) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = userName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerAddAssetsSettings.UserName"/></em></p>
        ///   <p>The username to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T ResetUserName<T>(this T toolSettings) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerAddAssetsSettings.Password"/></em></p>
        ///   <p>The password to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerAddAssetsSettings.Password"/></em></p>
        ///   <p>The password to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryOwner
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerAddAssetsSettings.RepositoryOwner"/></em></p>
        ///   <p>The owner of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryOwner<T>(this T toolSettings, string repositoryOwner) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryOwner = repositoryOwner;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerAddAssetsSettings.RepositoryOwner"/></em></p>
        ///   <p>The owner of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryOwner<T>(this T toolSettings) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryOwner = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerAddAssetsSettings.RepositoryName"/></em></p>
        ///   <p>The name of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryName<T>(this T toolSettings, string repositoryName) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryName = repositoryName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerAddAssetsSettings.RepositoryName"/></em></p>
        ///   <p>The name of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryName<T>(this T toolSettings) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryName = null;
            return toolSettings;
        }
        #endregion
        #region TargetDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerAddAssetsSettings.TargetDirectory"/></em></p>
        ///   <p>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</p>
        /// </summary>
        [Pure]
        public static T SetTargetDirectory<T>(this T toolSettings, string targetDirectory) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = targetDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerAddAssetsSettings.TargetDirectory"/></em></p>
        ///   <p>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetDirectory<T>(this T toolSettings) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = null;
            return toolSettings;
        }
        #endregion
        #region LogFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerAddAssetsSettings.LogFilePath"/></em></p>
        ///   <p>Path to where log file should be created. Defaults is <em>logging to console</em>.</p>
        /// </summary>
        [Pure]
        public static T SetLogFilePath<T>(this T toolSettings, string logFilePath) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = logFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerAddAssetsSettings.LogFilePath"/></em></p>
        ///   <p>Path to where log file should be created. Defaults is <em>logging to console</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFilePath<T>(this T toolSettings) where T : GitReleaseManagerAddAssetsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region GitReleaseManagerCloseSettingsExtensions
    /// <summary>
    ///   Used within <see cref="GitReleaseManagerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitReleaseManagerCloseSettingsExtensions
    {
        #region Milestone
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCloseSettings.Milestone"/></em></p>
        ///   <p>The milestone to use.</p>
        /// </summary>
        [Pure]
        public static T SetMilestone<T>(this T toolSettings, string milestone) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Milestone = milestone;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCloseSettings.Milestone"/></em></p>
        ///   <p>The milestone to use.</p>
        /// </summary>
        [Pure]
        public static T ResetMilestone<T>(this T toolSettings) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Milestone = null;
            return toolSettings;
        }
        #endregion
        #region UserName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCloseSettings.UserName"/></em></p>
        ///   <p>The username to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T SetUserName<T>(this T toolSettings, string userName) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = userName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCloseSettings.UserName"/></em></p>
        ///   <p>The username to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T ResetUserName<T>(this T toolSettings) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCloseSettings.Password"/></em></p>
        ///   <p>The password to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCloseSettings.Password"/></em></p>
        ///   <p>The password to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryOwner
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCloseSettings.RepositoryOwner"/></em></p>
        ///   <p>The owner of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryOwner<T>(this T toolSettings, string repositoryOwner) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryOwner = repositoryOwner;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCloseSettings.RepositoryOwner"/></em></p>
        ///   <p>The owner of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryOwner<T>(this T toolSettings) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryOwner = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCloseSettings.RepositoryName"/></em></p>
        ///   <p>The name of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryName<T>(this T toolSettings, string repositoryName) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryName = repositoryName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCloseSettings.RepositoryName"/></em></p>
        ///   <p>The name of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryName<T>(this T toolSettings) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryName = null;
            return toolSettings;
        }
        #endregion
        #region TargetDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCloseSettings.TargetDirectory"/></em></p>
        ///   <p>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</p>
        /// </summary>
        [Pure]
        public static T SetTargetDirectory<T>(this T toolSettings, string targetDirectory) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = targetDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCloseSettings.TargetDirectory"/></em></p>
        ///   <p>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetDirectory<T>(this T toolSettings) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = null;
            return toolSettings;
        }
        #endregion
        #region LogFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCloseSettings.LogFilePath"/></em></p>
        ///   <p>Path to where log file should be created. Defaults is <em>logging to console</em>.</p>
        /// </summary>
        [Pure]
        public static T SetLogFilePath<T>(this T toolSettings, string logFilePath) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = logFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCloseSettings.LogFilePath"/></em></p>
        ///   <p>Path to where log file should be created. Defaults is <em>logging to console</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFilePath<T>(this T toolSettings) where T : GitReleaseManagerCloseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region GitReleaseManagerCreateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="GitReleaseManagerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitReleaseManagerCreateSettingsExtensions
    {
        #region AssetPaths
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.AssetPaths"/> to a new list</em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T SetAssetPaths<T>(this T toolSettings, params string[] assetPaths) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetPathsInternal = assetPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.AssetPaths"/> to a new list</em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T SetAssetPaths<T>(this T toolSettings, IEnumerable<string> assetPaths) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetPathsInternal = assetPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T AddAssetPaths<T>(this T toolSettings, params string[] assetPaths) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetPathsInternal.AddRange(assetPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T AddAssetPaths<T>(this T toolSettings, IEnumerable<string> assetPaths) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetPathsInternal.AddRange(assetPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T ClearAssetPaths<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T RemoveAssetPaths<T>(this T toolSettings, params string[] assetPaths) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assetPaths);
            toolSettings.AssetPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></em></p>
        ///   <p>Paths to the files to include in the release.</p>
        /// </summary>
        [Pure]
        public static T RemoveAssetPaths<T>(this T toolSettings, IEnumerable<string> assetPaths) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assetPaths);
            toolSettings.AssetPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TargetCommitish
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.TargetCommitish"/></em></p>
        ///   <p>The commit to tag. Can be a branch or SHA. Defaults to repository's default branch.</p>
        /// </summary>
        [Pure]
        public static T SetTargetCommitish<T>(this T toolSettings, string targetCommitish) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetCommitish = targetCommitish;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.TargetCommitish"/></em></p>
        ///   <p>The commit to tag. Can be a branch or SHA. Defaults to repository's default branch.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetCommitish<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetCommitish = null;
            return toolSettings;
        }
        #endregion
        #region Milestone
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.Milestone"/></em></p>
        ///   <p>The milestone to use.</p>
        /// </summary>
        [Pure]
        public static T SetMilestone<T>(this T toolSettings, string milestone) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Milestone = milestone;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.Milestone"/></em></p>
        ///   <p>The milestone to use.</p>
        /// </summary>
        [Pure]
        public static T ResetMilestone<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Milestone = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.Name"/></em></p>
        ///   <p>The name of the release. Typically this is the generated SemVer Version Number.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.Name"/></em></p>
        ///   <p>The name of the release. Typically this is the generated SemVer Version Number.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region InputFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.InputFilePath"/></em></p>
        ///   <p>The path to the file to be used as the content of the release notes.</p>
        /// </summary>
        [Pure]
        public static T SetInputFilePath<T>(this T toolSettings, string inputFilePath) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilePath = inputFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.InputFilePath"/></em></p>
        ///   <p>The path to the file to be used as the content of the release notes.</p>
        /// </summary>
        [Pure]
        public static T ResetInputFilePath<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InputFilePath = null;
            return toolSettings;
        }
        #endregion
        #region Prerelease
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.Prerelease"/></em></p>
        ///   <p>Creates the release as a pre-release.</p>
        /// </summary>
        [Pure]
        public static T SetPrerelease<T>(this T toolSettings, bool? prerelease) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = prerelease;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.Prerelease"/></em></p>
        ///   <p>Creates the release as a pre-release.</p>
        /// </summary>
        [Pure]
        public static T ResetPrerelease<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="GitReleaseManagerCreateSettings.Prerelease"/></em></p>
        ///   <p>Creates the release as a pre-release.</p>
        /// </summary>
        [Pure]
        public static T EnablePrerelease<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="GitReleaseManagerCreateSettings.Prerelease"/></em></p>
        ///   <p>Creates the release as a pre-release.</p>
        /// </summary>
        [Pure]
        public static T DisablePrerelease<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="GitReleaseManagerCreateSettings.Prerelease"/></em></p>
        ///   <p>Creates the release as a pre-release.</p>
        /// </summary>
        [Pure]
        public static T TogglePrerelease<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = !toolSettings.Prerelease;
            return toolSettings;
        }
        #endregion
        #region UserName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.UserName"/></em></p>
        ///   <p>The username to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T SetUserName<T>(this T toolSettings, string userName) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = userName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.UserName"/></em></p>
        ///   <p>The username to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T ResetUserName<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.Password"/></em></p>
        ///   <p>The password to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.Password"/></em></p>
        ///   <p>The password to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryOwner
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.RepositoryOwner"/></em></p>
        ///   <p>The owner of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryOwner<T>(this T toolSettings, string repositoryOwner) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryOwner = repositoryOwner;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.RepositoryOwner"/></em></p>
        ///   <p>The owner of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryOwner<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryOwner = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.RepositoryName"/></em></p>
        ///   <p>The name of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryName<T>(this T toolSettings, string repositoryName) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryName = repositoryName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.RepositoryName"/></em></p>
        ///   <p>The name of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryName<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryName = null;
            return toolSettings;
        }
        #endregion
        #region TargetDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.TargetDirectory"/></em></p>
        ///   <p>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</p>
        /// </summary>
        [Pure]
        public static T SetTargetDirectory<T>(this T toolSettings, string targetDirectory) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = targetDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.TargetDirectory"/></em></p>
        ///   <p>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetDirectory<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = null;
            return toolSettings;
        }
        #endregion
        #region LogFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerCreateSettings.LogFilePath"/></em></p>
        ///   <p>Path to where log file should be created. Defaults is <em>logging to console</em>.</p>
        /// </summary>
        [Pure]
        public static T SetLogFilePath<T>(this T toolSettings, string logFilePath) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = logFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerCreateSettings.LogFilePath"/></em></p>
        ///   <p>Path to where log file should be created. Defaults is <em>logging to console</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFilePath<T>(this T toolSettings) where T : GitReleaseManagerCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region GitReleaseManagerExportSettingsExtensions
    /// <summary>
    ///   Used within <see cref="GitReleaseManagerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitReleaseManagerExportSettingsExtensions
    {
        #region TagName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerExportSettings.TagName"/></em></p>
        ///   <p>The name of the release. Typically this is the generated SemVer Version Number.</p>
        /// </summary>
        [Pure]
        public static T SetTagName<T>(this T toolSettings, string tagName) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagName = tagName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerExportSettings.TagName"/></em></p>
        ///   <p>The name of the release. Typically this is the generated SemVer Version Number.</p>
        /// </summary>
        [Pure]
        public static T ResetTagName<T>(this T toolSettings) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagName = null;
            return toolSettings;
        }
        #endregion
        #region FileOutputPath
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerExportSettings.FileOutputPath"/></em></p>
        ///   <p>Path to the file export releases.</p>
        /// </summary>
        [Pure]
        public static T SetFileOutputPath<T>(this T toolSettings, string fileOutputPath) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileOutputPath = fileOutputPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerExportSettings.FileOutputPath"/></em></p>
        ///   <p>Path to the file export releases.</p>
        /// </summary>
        [Pure]
        public static T ResetFileOutputPath<T>(this T toolSettings) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileOutputPath = null;
            return toolSettings;
        }
        #endregion
        #region UserName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerExportSettings.UserName"/></em></p>
        ///   <p>The username to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T SetUserName<T>(this T toolSettings, string userName) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = userName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerExportSettings.UserName"/></em></p>
        ///   <p>The username to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T ResetUserName<T>(this T toolSettings) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerExportSettings.Password"/></em></p>
        ///   <p>The password to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerExportSettings.Password"/></em></p>
        ///   <p>The password to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryOwner
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerExportSettings.RepositoryOwner"/></em></p>
        ///   <p>The owner of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryOwner<T>(this T toolSettings, string repositoryOwner) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryOwner = repositoryOwner;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerExportSettings.RepositoryOwner"/></em></p>
        ///   <p>The owner of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryOwner<T>(this T toolSettings) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryOwner = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerExportSettings.RepositoryName"/></em></p>
        ///   <p>The name of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryName<T>(this T toolSettings, string repositoryName) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryName = repositoryName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerExportSettings.RepositoryName"/></em></p>
        ///   <p>The name of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryName<T>(this T toolSettings) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryName = null;
            return toolSettings;
        }
        #endregion
        #region TargetDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerExportSettings.TargetDirectory"/></em></p>
        ///   <p>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</p>
        /// </summary>
        [Pure]
        public static T SetTargetDirectory<T>(this T toolSettings, string targetDirectory) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = targetDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerExportSettings.TargetDirectory"/></em></p>
        ///   <p>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetDirectory<T>(this T toolSettings) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = null;
            return toolSettings;
        }
        #endregion
        #region LogFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerExportSettings.LogFilePath"/></em></p>
        ///   <p>Path to where log file should be created. Defaults is <em>logging to console</em>.</p>
        /// </summary>
        [Pure]
        public static T SetLogFilePath<T>(this T toolSettings, string logFilePath) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = logFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerExportSettings.LogFilePath"/></em></p>
        ///   <p>Path to where log file should be created. Defaults is <em>logging to console</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFilePath<T>(this T toolSettings) where T : GitReleaseManagerExportSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region GitReleaseManagerPublishSettingsExtensions
    /// <summary>
    ///   Used within <see cref="GitReleaseManagerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitReleaseManagerPublishSettingsExtensions
    {
        #region TagName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerPublishSettings.TagName"/></em></p>
        ///   <p>The name of the release. Typically this is the generated SemVer Version Number.</p>
        /// </summary>
        [Pure]
        public static T SetTagName<T>(this T toolSettings, string tagName) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagName = tagName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerPublishSettings.TagName"/></em></p>
        ///   <p>The name of the release. Typically this is the generated SemVer Version Number.</p>
        /// </summary>
        [Pure]
        public static T ResetTagName<T>(this T toolSettings) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagName = null;
            return toolSettings;
        }
        #endregion
        #region UserName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerPublishSettings.UserName"/></em></p>
        ///   <p>The username to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T SetUserName<T>(this T toolSettings, string userName) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = userName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerPublishSettings.UserName"/></em></p>
        ///   <p>The username to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T ResetUserName<T>(this T toolSettings) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UserName = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerPublishSettings.Password"/></em></p>
        ///   <p>The password to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerPublishSettings.Password"/></em></p>
        ///   <p>The password to access GitHub with.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryOwner
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerPublishSettings.RepositoryOwner"/></em></p>
        ///   <p>The owner of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryOwner<T>(this T toolSettings, string repositoryOwner) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryOwner = repositoryOwner;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerPublishSettings.RepositoryOwner"/></em></p>
        ///   <p>The owner of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryOwner<T>(this T toolSettings) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryOwner = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryName
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerPublishSettings.RepositoryName"/></em></p>
        ///   <p>The name of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryName<T>(this T toolSettings, string repositoryName) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryName = repositoryName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerPublishSettings.RepositoryName"/></em></p>
        ///   <p>The name of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryName<T>(this T toolSettings) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryName = null;
            return toolSettings;
        }
        #endregion
        #region TargetDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerPublishSettings.TargetDirectory"/></em></p>
        ///   <p>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</p>
        /// </summary>
        [Pure]
        public static T SetTargetDirectory<T>(this T toolSettings, string targetDirectory) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = targetDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerPublishSettings.TargetDirectory"/></em></p>
        ///   <p>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetDirectory<T>(this T toolSettings) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetDirectory = null;
            return toolSettings;
        }
        #endregion
        #region LogFilePath
        /// <summary>
        ///   <p><em>Sets <see cref="GitReleaseManagerPublishSettings.LogFilePath"/></em></p>
        ///   <p>Path to where log file should be created. Defaults is <em>logging to console</em>.</p>
        /// </summary>
        [Pure]
        public static T SetLogFilePath<T>(this T toolSettings, string logFilePath) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = logFilePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitReleaseManagerPublishSettings.LogFilePath"/></em></p>
        ///   <p>Path to where log file should be created. Defaults is <em>logging to console</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFilePath<T>(this T toolSettings) where T : GitReleaseManagerPublishSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFilePath = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
