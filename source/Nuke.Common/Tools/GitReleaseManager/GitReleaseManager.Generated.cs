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

namespace Nuke.Common.Tools.GitReleaseManager;

/// <summary><p>GitReleaseManager is a tool that will help create a set of release notes for your application/product. It does this using the collection of issues which are stored on the GitHub Issue Tracker for your application/product.<para/>By inspecting the issues that have been assigned to a particular milestone, GitReleaseManager creates a set of release notes, in markdown format, which are then used to create a Release on GitHub.<para/>In addition to creating a Release, GitReleaseManager can be used to publish a release, close a milestone, and also to export the complete set of release notes for your application/product.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class GitReleaseManagerTasks : ToolTasks, IRequireNuGetPackage
{
    public static string GitReleaseManagerPath => new GitReleaseManagerTasks().GetToolPath();
    public const string PackageId = "gitreleasemanager";
    public const string PackageExecutable = "GitReleaseManager.exe";
    /// <summary><p>GitReleaseManager is a tool that will help create a set of release notes for your application/product. It does this using the collection of issues which are stored on the GitHub Issue Tracker for your application/product.<para/>By inspecting the issues that have been assigned to a particular milestone, GitReleaseManager creates a set of release notes, in markdown format, which are then used to create a Release on GitHub.<para/>In addition to creating a Release, GitReleaseManager can be used to publish a release, close a milestone, and also to export the complete set of release notes for your application/product.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> GitReleaseManager(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new GitReleaseManagerTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Adds an asset to an existing release.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--assets</c> via <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></li><li><c>--logFilePath</c> via <see cref="GitReleaseManagerAddAssetsSettings.LogFilePath"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerAddAssetsSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryName"/></li><li><c>--tagName</c> via <see cref="GitReleaseManagerAddAssetsSettings.TagName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerAddAssetsSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerAddAssetsSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerAddAssetsSettings.UserName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitReleaseManagerAddAssets(GitReleaseManagerAddAssetsSettings options = null) => new GitReleaseManagerTasks().Run(options);
    /// <summary><p>Adds an asset to an existing release.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--assets</c> via <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></li><li><c>--logFilePath</c> via <see cref="GitReleaseManagerAddAssetsSettings.LogFilePath"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerAddAssetsSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryName"/></li><li><c>--tagName</c> via <see cref="GitReleaseManagerAddAssetsSettings.TagName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerAddAssetsSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerAddAssetsSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerAddAssetsSettings.UserName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitReleaseManagerAddAssets(Configure<GitReleaseManagerAddAssetsSettings> configurator) => new GitReleaseManagerTasks().Run(configurator.Invoke(new GitReleaseManagerAddAssetsSettings()));
    /// <summary><p>Adds an asset to an existing release.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--assets</c> via <see cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/></li><li><c>--logFilePath</c> via <see cref="GitReleaseManagerAddAssetsSettings.LogFilePath"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerAddAssetsSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerAddAssetsSettings.RepositoryName"/></li><li><c>--tagName</c> via <see cref="GitReleaseManagerAddAssetsSettings.TagName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerAddAssetsSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerAddAssetsSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerAddAssetsSettings.UserName"/></li></ul></remarks>
    public static IEnumerable<(GitReleaseManagerAddAssetsSettings Settings, IReadOnlyCollection<Output> Output)> GitReleaseManagerAddAssets(CombinatorialConfigure<GitReleaseManagerAddAssetsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(GitReleaseManagerAddAssets, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Closes the milestone.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--logFilePath</c> via <see cref="GitReleaseManagerCloseSettings.LogFilePath"/></li><li><c>--milestone</c> via <see cref="GitReleaseManagerCloseSettings.Milestone"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerCloseSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCloseSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerCloseSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerCloseSettings.UserName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitReleaseManagerClose(GitReleaseManagerCloseSettings options = null) => new GitReleaseManagerTasks().Run(options);
    /// <summary><p>Closes the milestone.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--logFilePath</c> via <see cref="GitReleaseManagerCloseSettings.LogFilePath"/></li><li><c>--milestone</c> via <see cref="GitReleaseManagerCloseSettings.Milestone"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerCloseSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCloseSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerCloseSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerCloseSettings.UserName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitReleaseManagerClose(Configure<GitReleaseManagerCloseSettings> configurator) => new GitReleaseManagerTasks().Run(configurator.Invoke(new GitReleaseManagerCloseSettings()));
    /// <summary><p>Closes the milestone.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--logFilePath</c> via <see cref="GitReleaseManagerCloseSettings.LogFilePath"/></li><li><c>--milestone</c> via <see cref="GitReleaseManagerCloseSettings.Milestone"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerCloseSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerCloseSettings.RepositoryName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCloseSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerCloseSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerCloseSettings.UserName"/></li></ul></remarks>
    public static IEnumerable<(GitReleaseManagerCloseSettings Settings, IReadOnlyCollection<Output> Output)> GitReleaseManagerClose(CombinatorialConfigure<GitReleaseManagerCloseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(GitReleaseManagerClose, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Creates a draft release notes from a milestone.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--assets</c> via <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></li><li><c>--inputFilePath</c> via <see cref="GitReleaseManagerCreateSettings.InputFilePath"/></li><li><c>--logFilePath</c> via <see cref="GitReleaseManagerCreateSettings.LogFilePath"/></li><li><c>--milestone</c> via <see cref="GitReleaseManagerCreateSettings.Milestone"/></li><li><c>--name</c> via <see cref="GitReleaseManagerCreateSettings.Name"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerCreateSettings.Password"/></li><li><c>--prerelease</c> via <see cref="GitReleaseManagerCreateSettings.Prerelease"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryName"/></li><li><c>--targetcommitish</c> via <see cref="GitReleaseManagerCreateSettings.TargetCommitish"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCreateSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerCreateSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerCreateSettings.UserName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitReleaseManagerCreate(GitReleaseManagerCreateSettings options = null) => new GitReleaseManagerTasks().Run(options);
    /// <summary><p>Creates a draft release notes from a milestone.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--assets</c> via <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></li><li><c>--inputFilePath</c> via <see cref="GitReleaseManagerCreateSettings.InputFilePath"/></li><li><c>--logFilePath</c> via <see cref="GitReleaseManagerCreateSettings.LogFilePath"/></li><li><c>--milestone</c> via <see cref="GitReleaseManagerCreateSettings.Milestone"/></li><li><c>--name</c> via <see cref="GitReleaseManagerCreateSettings.Name"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerCreateSettings.Password"/></li><li><c>--prerelease</c> via <see cref="GitReleaseManagerCreateSettings.Prerelease"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryName"/></li><li><c>--targetcommitish</c> via <see cref="GitReleaseManagerCreateSettings.TargetCommitish"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCreateSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerCreateSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerCreateSettings.UserName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitReleaseManagerCreate(Configure<GitReleaseManagerCreateSettings> configurator) => new GitReleaseManagerTasks().Run(configurator.Invoke(new GitReleaseManagerCreateSettings()));
    /// <summary><p>Creates a draft release notes from a milestone.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--assets</c> via <see cref="GitReleaseManagerCreateSettings.AssetPaths"/></li><li><c>--inputFilePath</c> via <see cref="GitReleaseManagerCreateSettings.InputFilePath"/></li><li><c>--logFilePath</c> via <see cref="GitReleaseManagerCreateSettings.LogFilePath"/></li><li><c>--milestone</c> via <see cref="GitReleaseManagerCreateSettings.Milestone"/></li><li><c>--name</c> via <see cref="GitReleaseManagerCreateSettings.Name"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerCreateSettings.Password"/></li><li><c>--prerelease</c> via <see cref="GitReleaseManagerCreateSettings.Prerelease"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerCreateSettings.RepositoryName"/></li><li><c>--targetcommitish</c> via <see cref="GitReleaseManagerCreateSettings.TargetCommitish"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerCreateSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerCreateSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerCreateSettings.UserName"/></li></ul></remarks>
    public static IEnumerable<(GitReleaseManagerCreateSettings Settings, IReadOnlyCollection<Output> Output)> GitReleaseManagerCreate(CombinatorialConfigure<GitReleaseManagerCreateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(GitReleaseManagerCreate, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Exports all the Release Notes in markdown format.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--fileOutputPath</c> via <see cref="GitReleaseManagerExportSettings.FileOutputPath"/></li><li><c>--logFilePath</c> via <see cref="GitReleaseManagerExportSettings.LogFilePath"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerExportSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerExportSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerExportSettings.RepositoryName"/></li><li><c>--tagName</c> via <see cref="GitReleaseManagerExportSettings.TagName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerExportSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerExportSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerExportSettings.UserName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitReleaseManagerExport(GitReleaseManagerExportSettings options = null) => new GitReleaseManagerTasks().Run(options);
    /// <summary><p>Exports all the Release Notes in markdown format.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--fileOutputPath</c> via <see cref="GitReleaseManagerExportSettings.FileOutputPath"/></li><li><c>--logFilePath</c> via <see cref="GitReleaseManagerExportSettings.LogFilePath"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerExportSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerExportSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerExportSettings.RepositoryName"/></li><li><c>--tagName</c> via <see cref="GitReleaseManagerExportSettings.TagName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerExportSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerExportSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerExportSettings.UserName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitReleaseManagerExport(Configure<GitReleaseManagerExportSettings> configurator) => new GitReleaseManagerTasks().Run(configurator.Invoke(new GitReleaseManagerExportSettings()));
    /// <summary><p>Exports all the Release Notes in markdown format.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--fileOutputPath</c> via <see cref="GitReleaseManagerExportSettings.FileOutputPath"/></li><li><c>--logFilePath</c> via <see cref="GitReleaseManagerExportSettings.LogFilePath"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerExportSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerExportSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerExportSettings.RepositoryName"/></li><li><c>--tagName</c> via <see cref="GitReleaseManagerExportSettings.TagName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerExportSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerExportSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerExportSettings.UserName"/></li></ul></remarks>
    public static IEnumerable<(GitReleaseManagerExportSettings Settings, IReadOnlyCollection<Output> Output)> GitReleaseManagerExport(CombinatorialConfigure<GitReleaseManagerExportSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(GitReleaseManagerExport, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Publishes the GitHub Release.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--logFilePath</c> via <see cref="GitReleaseManagerPublishSettings.LogFilePath"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerPublishSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryName"/></li><li><c>--tagName</c> via <see cref="GitReleaseManagerPublishSettings.TagName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerPublishSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerPublishSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerPublishSettings.UserName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitReleaseManagerPublish(GitReleaseManagerPublishSettings options = null) => new GitReleaseManagerTasks().Run(options);
    /// <summary><p>Publishes the GitHub Release.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--logFilePath</c> via <see cref="GitReleaseManagerPublishSettings.LogFilePath"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerPublishSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryName"/></li><li><c>--tagName</c> via <see cref="GitReleaseManagerPublishSettings.TagName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerPublishSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerPublishSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerPublishSettings.UserName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitReleaseManagerPublish(Configure<GitReleaseManagerPublishSettings> configurator) => new GitReleaseManagerTasks().Run(configurator.Invoke(new GitReleaseManagerPublishSettings()));
    /// <summary><p>Publishes the GitHub Release.</p><p>For more details, visit the <a href="https://gitreleasemanager.readthedocs.io">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--logFilePath</c> via <see cref="GitReleaseManagerPublishSettings.LogFilePath"/></li><li><c>--owner</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryOwner"/></li><li><c>--password</c> via <see cref="GitReleaseManagerPublishSettings.Password"/></li><li><c>--repository</c> via <see cref="GitReleaseManagerPublishSettings.RepositoryName"/></li><li><c>--tagName</c> via <see cref="GitReleaseManagerPublishSettings.TagName"/></li><li><c>--targetDirectory</c> via <see cref="GitReleaseManagerPublishSettings.TargetDirectory"/></li><li><c>--token</c> via <see cref="GitReleaseManagerPublishSettings.Token"/></li><li><c>--username</c> via <see cref="GitReleaseManagerPublishSettings.UserName"/></li></ul></remarks>
    public static IEnumerable<(GitReleaseManagerPublishSettings Settings, IReadOnlyCollection<Output> Output)> GitReleaseManagerPublish(CombinatorialConfigure<GitReleaseManagerPublishSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(GitReleaseManagerPublish, degreeOfParallelism, completeOnFailure);
}
#region GitReleaseManagerAddAssetsSettings
/// <summary>Used within <see cref="GitReleaseManagerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitReleaseManagerAddAssetsSettings>))]
[Command(Type = typeof(GitReleaseManagerTasks), Command = nameof(GitReleaseManagerTasks.GitReleaseManagerAddAssets), Arguments = "addasset")]
public partial class GitReleaseManagerAddAssetsSettings : ToolOptions
{
    /// <summary>Paths to the files to include in the release.</summary>
    [Argument(Format = "--assets {value}", Separator = ",")] public IReadOnlyList<string> AssetPaths => Get<List<string>>(() => AssetPaths);
    /// <summary>The name of the release. Typically this is the generated SemVer Version Number.</summary>
    [Argument(Format = "--tagName {value}")] public string TagName => Get<string>(() => TagName);
    /// <summary>The username to access GitHub with.</summary>
    [Argument(Format = "--username {value}")] public string UserName => Get<string>(() => UserName);
    /// <summary>The password to access GitHub with.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>The owner of the repository.</summary>
    [Argument(Format = "--owner {value}")] public string RepositoryOwner => Get<string>(() => RepositoryOwner);
    /// <summary>The name of the repository.</summary>
    [Argument(Format = "--repository {value}")] public string RepositoryName => Get<string>(() => RepositoryName);
    /// <summary>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</summary>
    [Argument(Format = "--targetDirectory {value}")] public string TargetDirectory => Get<string>(() => TargetDirectory);
    /// <summary>Path to where log file should be created. Defaults is <em>logging to console</em>.</summary>
    [Argument(Format = "--logFilePath {value}")] public string LogFilePath => Get<string>(() => LogFilePath);
    /// <summary>The access token to access GitHub with.</summary>
    [Argument(Format = "--token {value}")] public string Token => Get<string>(() => Token);
}
#endregion
#region GitReleaseManagerCloseSettings
/// <summary>Used within <see cref="GitReleaseManagerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitReleaseManagerCloseSettings>))]
[Command(Type = typeof(GitReleaseManagerTasks), Command = nameof(GitReleaseManagerTasks.GitReleaseManagerClose), Arguments = "close")]
public partial class GitReleaseManagerCloseSettings : ToolOptions
{
    /// <summary>The milestone to use.</summary>
    [Argument(Format = "--milestone {value}")] public string Milestone => Get<string>(() => Milestone);
    /// <summary>The username to access GitHub with.</summary>
    [Argument(Format = "--username {value}")] public string UserName => Get<string>(() => UserName);
    /// <summary>The password to access GitHub with.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>The owner of the repository.</summary>
    [Argument(Format = "--owner {value}")] public string RepositoryOwner => Get<string>(() => RepositoryOwner);
    /// <summary>The name of the repository.</summary>
    [Argument(Format = "--repository {value}")] public string RepositoryName => Get<string>(() => RepositoryName);
    /// <summary>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</summary>
    [Argument(Format = "--targetDirectory {value}")] public string TargetDirectory => Get<string>(() => TargetDirectory);
    /// <summary>Path to where log file should be created. Defaults is <em>logging to console</em>.</summary>
    [Argument(Format = "--logFilePath {value}")] public string LogFilePath => Get<string>(() => LogFilePath);
    /// <summary>The access token to access GitHub with.</summary>
    [Argument(Format = "--token {value}")] public string Token => Get<string>(() => Token);
}
#endregion
#region GitReleaseManagerCreateSettings
/// <summary>Used within <see cref="GitReleaseManagerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitReleaseManagerCreateSettings>))]
[Command(Type = typeof(GitReleaseManagerTasks), Command = nameof(GitReleaseManagerTasks.GitReleaseManagerCreate), Arguments = "create")]
public partial class GitReleaseManagerCreateSettings : ToolOptions
{
    /// <summary>Paths to the files to include in the release.</summary>
    [Argument(Format = "--assets {value}", Separator = ",")] public IReadOnlyList<string> AssetPaths => Get<List<string>>(() => AssetPaths);
    /// <summary>The commit to tag. Can be a branch or SHA. Defaults to repository's default branch.</summary>
    [Argument(Format = "--targetcommitish {value}")] public string TargetCommitish => Get<string>(() => TargetCommitish);
    /// <summary>The milestone to use.</summary>
    [Argument(Format = "--milestone {value}")] public string Milestone => Get<string>(() => Milestone);
    /// <summary>The name of the release. Typically this is the generated SemVer Version Number.</summary>
    [Argument(Format = "--name {value}")] public string Name => Get<string>(() => Name);
    /// <summary>The path to the file to be used as the content of the release notes.</summary>
    [Argument(Format = "--inputFilePath {value}")] public string InputFilePath => Get<string>(() => InputFilePath);
    /// <summary>Creates the release as a pre-release.</summary>
    [Argument(Format = "--prerelease")] public bool? Prerelease => Get<bool?>(() => Prerelease);
    /// <summary>The username to access GitHub with.</summary>
    [Argument(Format = "--username {value}")] public string UserName => Get<string>(() => UserName);
    /// <summary>The password to access GitHub with.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>The owner of the repository.</summary>
    [Argument(Format = "--owner {value}")] public string RepositoryOwner => Get<string>(() => RepositoryOwner);
    /// <summary>The name of the repository.</summary>
    [Argument(Format = "--repository {value}")] public string RepositoryName => Get<string>(() => RepositoryName);
    /// <summary>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</summary>
    [Argument(Format = "--targetDirectory {value}")] public string TargetDirectory => Get<string>(() => TargetDirectory);
    /// <summary>Path to where log file should be created. Defaults is <em>logging to console</em>.</summary>
    [Argument(Format = "--logFilePath {value}")] public string LogFilePath => Get<string>(() => LogFilePath);
    /// <summary>The access token to access GitHub with.</summary>
    [Argument(Format = "--token {value}")] public string Token => Get<string>(() => Token);
}
#endregion
#region GitReleaseManagerExportSettings
/// <summary>Used within <see cref="GitReleaseManagerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitReleaseManagerExportSettings>))]
[Command(Type = typeof(GitReleaseManagerTasks), Command = nameof(GitReleaseManagerTasks.GitReleaseManagerExport), Arguments = "export")]
public partial class GitReleaseManagerExportSettings : ToolOptions
{
    /// <summary>The name of the release. Typically this is the generated SemVer Version Number.</summary>
    [Argument(Format = "--tagName {value}")] public string TagName => Get<string>(() => TagName);
    /// <summary>Path to the file export releases.</summary>
    [Argument(Format = "--fileOutputPath {value}")] public string FileOutputPath => Get<string>(() => FileOutputPath);
    /// <summary>The username to access GitHub with.</summary>
    [Argument(Format = "--username {value}")] public string UserName => Get<string>(() => UserName);
    /// <summary>The password to access GitHub with.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>The owner of the repository.</summary>
    [Argument(Format = "--owner {value}")] public string RepositoryOwner => Get<string>(() => RepositoryOwner);
    /// <summary>The name of the repository.</summary>
    [Argument(Format = "--repository {value}")] public string RepositoryName => Get<string>(() => RepositoryName);
    /// <summary>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</summary>
    [Argument(Format = "--targetDirectory {value}")] public string TargetDirectory => Get<string>(() => TargetDirectory);
    /// <summary>Path to where log file should be created. Defaults is <em>logging to console</em>.</summary>
    [Argument(Format = "--logFilePath {value}")] public string LogFilePath => Get<string>(() => LogFilePath);
    /// <summary>The access token to access GitHub with.</summary>
    [Argument(Format = "--token {value}")] public string Token => Get<string>(() => Token);
}
#endregion
#region GitReleaseManagerPublishSettings
/// <summary>Used within <see cref="GitReleaseManagerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitReleaseManagerPublishSettings>))]
[Command(Type = typeof(GitReleaseManagerTasks), Command = nameof(GitReleaseManagerTasks.GitReleaseManagerPublish), Arguments = "publish")]
public partial class GitReleaseManagerPublishSettings : ToolOptions
{
    /// <summary>The name of the release. Typically this is the generated SemVer Version Number.</summary>
    [Argument(Format = "--tagName {value}")] public string TagName => Get<string>(() => TagName);
    /// <summary>The username to access GitHub with.</summary>
    [Argument(Format = "--username {value}")] public string UserName => Get<string>(() => UserName);
    /// <summary>The password to access GitHub with.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>The owner of the repository.</summary>
    [Argument(Format = "--owner {value}")] public string RepositoryOwner => Get<string>(() => RepositoryOwner);
    /// <summary>The name of the repository.</summary>
    [Argument(Format = "--repository {value}")] public string RepositoryName => Get<string>(() => RepositoryName);
    /// <summary>The directory on which GitReleaseManager should be executed. Default is <em>current directory</em>.</summary>
    [Argument(Format = "--targetDirectory {value}")] public string TargetDirectory => Get<string>(() => TargetDirectory);
    /// <summary>Path to where log file should be created. Defaults is <em>logging to console</em>.</summary>
    [Argument(Format = "--logFilePath {value}")] public string LogFilePath => Get<string>(() => LogFilePath);
    /// <summary>The access token to access GitHub with.</summary>
    [Argument(Format = "--token {value}")] public string Token => Get<string>(() => Token);
}
#endregion
#region GitReleaseManagerAddAssetsSettingsExtensions
/// <summary>Used within <see cref="GitReleaseManagerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class GitReleaseManagerAddAssetsSettingsExtensions
{
    #region AssetPaths
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.AssetPaths))]
    public static T SetAssetPaths<T>(this T o, params string[] v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Set(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.AssetPaths))]
    public static T SetAssetPaths<T>(this T o, IEnumerable<string> v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Set(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.AssetPaths))]
    public static T AddAssetPaths<T>(this T o, params string[] v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.AddCollection(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.AssetPaths))]
    public static T AddAssetPaths<T>(this T o, IEnumerable<string> v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.AddCollection(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.AssetPaths))]
    public static T RemoveAssetPaths<T>(this T o, params string[] v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.RemoveCollection(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.AssetPaths))]
    public static T RemoveAssetPaths<T>(this T o, IEnumerable<string> v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.RemoveCollection(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.AssetPaths))]
    public static T ClearAssetPaths<T>(this T o) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.ClearCollection(() => o.AssetPaths));
    #endregion
    #region TagName
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.TagName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.TagName))]
    public static T SetTagName<T>(this T o, string v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Set(() => o.TagName, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.TagName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.TagName))]
    public static T ResetTagName<T>(this T o) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Remove(() => o.TagName));
    #endregion
    #region UserName
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.UserName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.UserName))]
    public static T SetUserName<T>(this T o, string v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Set(() => o.UserName, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.UserName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.UserName))]
    public static T ResetUserName<T>(this T o) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Remove(() => o.UserName));
    #endregion
    #region Password
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region RepositoryOwner
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.RepositoryOwner"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.RepositoryOwner))]
    public static T SetRepositoryOwner<T>(this T o, string v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Set(() => o.RepositoryOwner, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.RepositoryOwner"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.RepositoryOwner))]
    public static T ResetRepositoryOwner<T>(this T o) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Remove(() => o.RepositoryOwner));
    #endregion
    #region RepositoryName
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.RepositoryName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.RepositoryName))]
    public static T SetRepositoryName<T>(this T o, string v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Set(() => o.RepositoryName, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.RepositoryName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.RepositoryName))]
    public static T ResetRepositoryName<T>(this T o) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Remove(() => o.RepositoryName));
    #endregion
    #region TargetDirectory
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.TargetDirectory))]
    public static T SetTargetDirectory<T>(this T o, string v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Set(() => o.TargetDirectory, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.TargetDirectory))]
    public static T ResetTargetDirectory<T>(this T o) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Remove(() => o.TargetDirectory));
    #endregion
    #region LogFilePath
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.LogFilePath))]
    public static T SetLogFilePath<T>(this T o, string v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Set(() => o.LogFilePath, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.LogFilePath))]
    public static T ResetLogFilePath<T>(this T o) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Remove(() => o.LogFilePath));
    #endregion
    #region Token
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.Token"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.Token))]
    public static T SetToken<T>(this T o, string v) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Set(() => o.Token, v));
    /// <inheritdoc cref="GitReleaseManagerAddAssetsSettings.Token"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerAddAssetsSettings), Property = nameof(GitReleaseManagerAddAssetsSettings.Token))]
    public static T ResetToken<T>(this T o) where T : GitReleaseManagerAddAssetsSettings => o.Modify(b => b.Remove(() => o.Token));
    #endregion
}
#endregion
#region GitReleaseManagerCloseSettingsExtensions
/// <summary>Used within <see cref="GitReleaseManagerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class GitReleaseManagerCloseSettingsExtensions
{
    #region Milestone
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.Milestone"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.Milestone))]
    public static T SetMilestone<T>(this T o, string v) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Set(() => o.Milestone, v));
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.Milestone"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.Milestone))]
    public static T ResetMilestone<T>(this T o) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Remove(() => o.Milestone));
    #endregion
    #region UserName
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.UserName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.UserName))]
    public static T SetUserName<T>(this T o, string v) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Set(() => o.UserName, v));
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.UserName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.UserName))]
    public static T ResetUserName<T>(this T o) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Remove(() => o.UserName));
    #endregion
    #region Password
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region RepositoryOwner
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.RepositoryOwner"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.RepositoryOwner))]
    public static T SetRepositoryOwner<T>(this T o, string v) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Set(() => o.RepositoryOwner, v));
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.RepositoryOwner"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.RepositoryOwner))]
    public static T ResetRepositoryOwner<T>(this T o) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Remove(() => o.RepositoryOwner));
    #endregion
    #region RepositoryName
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.RepositoryName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.RepositoryName))]
    public static T SetRepositoryName<T>(this T o, string v) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Set(() => o.RepositoryName, v));
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.RepositoryName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.RepositoryName))]
    public static T ResetRepositoryName<T>(this T o) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Remove(() => o.RepositoryName));
    #endregion
    #region TargetDirectory
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.TargetDirectory))]
    public static T SetTargetDirectory<T>(this T o, string v) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Set(() => o.TargetDirectory, v));
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.TargetDirectory))]
    public static T ResetTargetDirectory<T>(this T o) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Remove(() => o.TargetDirectory));
    #endregion
    #region LogFilePath
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.LogFilePath))]
    public static T SetLogFilePath<T>(this T o, string v) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Set(() => o.LogFilePath, v));
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.LogFilePath))]
    public static T ResetLogFilePath<T>(this T o) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Remove(() => o.LogFilePath));
    #endregion
    #region Token
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.Token"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.Token))]
    public static T SetToken<T>(this T o, string v) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Set(() => o.Token, v));
    /// <inheritdoc cref="GitReleaseManagerCloseSettings.Token"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCloseSettings), Property = nameof(GitReleaseManagerCloseSettings.Token))]
    public static T ResetToken<T>(this T o) where T : GitReleaseManagerCloseSettings => o.Modify(b => b.Remove(() => o.Token));
    #endregion
}
#endregion
#region GitReleaseManagerCreateSettingsExtensions
/// <summary>Used within <see cref="GitReleaseManagerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class GitReleaseManagerCreateSettingsExtensions
{
    #region AssetPaths
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.AssetPaths))]
    public static T SetAssetPaths<T>(this T o, params string[] v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.AssetPaths))]
    public static T SetAssetPaths<T>(this T o, IEnumerable<string> v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.AssetPaths))]
    public static T AddAssetPaths<T>(this T o, params string[] v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.AddCollection(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.AssetPaths))]
    public static T AddAssetPaths<T>(this T o, IEnumerable<string> v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.AddCollection(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.AssetPaths))]
    public static T RemoveAssetPaths<T>(this T o, params string[] v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.RemoveCollection(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.AssetPaths))]
    public static T RemoveAssetPaths<T>(this T o, IEnumerable<string> v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.RemoveCollection(() => o.AssetPaths, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.AssetPaths"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.AssetPaths))]
    public static T ClearAssetPaths<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.ClearCollection(() => o.AssetPaths));
    #endregion
    #region TargetCommitish
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.TargetCommitish"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.TargetCommitish))]
    public static T SetTargetCommitish<T>(this T o, string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.TargetCommitish, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.TargetCommitish"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.TargetCommitish))]
    public static T ResetTargetCommitish<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.TargetCommitish));
    #endregion
    #region Milestone
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Milestone"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Milestone))]
    public static T SetMilestone<T>(this T o, string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.Milestone, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Milestone"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Milestone))]
    public static T ResetMilestone<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.Milestone));
    #endregion
    #region Name
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Name"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Name"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Name))]
    public static T ResetName<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region InputFilePath
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.InputFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.InputFilePath))]
    public static T SetInputFilePath<T>(this T o, string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.InputFilePath, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.InputFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.InputFilePath))]
    public static T ResetInputFilePath<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.InputFilePath));
    #endregion
    #region Prerelease
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Prerelease))]
    public static T SetPrerelease<T>(this T o, bool? v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.Prerelease, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Prerelease))]
    public static T ResetPrerelease<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.Prerelease));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Prerelease))]
    public static T EnablePrerelease<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.Prerelease, true));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Prerelease))]
    public static T DisablePrerelease<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.Prerelease, false));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Prerelease))]
    public static T TogglePrerelease<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.Prerelease, !o.Prerelease));
    #endregion
    #region UserName
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.UserName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.UserName))]
    public static T SetUserName<T>(this T o, string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.UserName, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.UserName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.UserName))]
    public static T ResetUserName<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.UserName));
    #endregion
    #region Password
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region RepositoryOwner
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.RepositoryOwner"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.RepositoryOwner))]
    public static T SetRepositoryOwner<T>(this T o, string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.RepositoryOwner, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.RepositoryOwner"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.RepositoryOwner))]
    public static T ResetRepositoryOwner<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.RepositoryOwner));
    #endregion
    #region RepositoryName
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.RepositoryName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.RepositoryName))]
    public static T SetRepositoryName<T>(this T o, string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.RepositoryName, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.RepositoryName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.RepositoryName))]
    public static T ResetRepositoryName<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.RepositoryName));
    #endregion
    #region TargetDirectory
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.TargetDirectory))]
    public static T SetTargetDirectory<T>(this T o, string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.TargetDirectory, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.TargetDirectory))]
    public static T ResetTargetDirectory<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.TargetDirectory));
    #endregion
    #region LogFilePath
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.LogFilePath))]
    public static T SetLogFilePath<T>(this T o, string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.LogFilePath, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.LogFilePath))]
    public static T ResetLogFilePath<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.LogFilePath));
    #endregion
    #region Token
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Token"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Token))]
    public static T SetToken<T>(this T o, string v) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Set(() => o.Token, v));
    /// <inheritdoc cref="GitReleaseManagerCreateSettings.Token"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerCreateSettings), Property = nameof(GitReleaseManagerCreateSettings.Token))]
    public static T ResetToken<T>(this T o) where T : GitReleaseManagerCreateSettings => o.Modify(b => b.Remove(() => o.Token));
    #endregion
}
#endregion
#region GitReleaseManagerExportSettingsExtensions
/// <summary>Used within <see cref="GitReleaseManagerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class GitReleaseManagerExportSettingsExtensions
{
    #region TagName
    /// <inheritdoc cref="GitReleaseManagerExportSettings.TagName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.TagName))]
    public static T SetTagName<T>(this T o, string v) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Set(() => o.TagName, v));
    /// <inheritdoc cref="GitReleaseManagerExportSettings.TagName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.TagName))]
    public static T ResetTagName<T>(this T o) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Remove(() => o.TagName));
    #endregion
    #region FileOutputPath
    /// <inheritdoc cref="GitReleaseManagerExportSettings.FileOutputPath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.FileOutputPath))]
    public static T SetFileOutputPath<T>(this T o, string v) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Set(() => o.FileOutputPath, v));
    /// <inheritdoc cref="GitReleaseManagerExportSettings.FileOutputPath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.FileOutputPath))]
    public static T ResetFileOutputPath<T>(this T o) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Remove(() => o.FileOutputPath));
    #endregion
    #region UserName
    /// <inheritdoc cref="GitReleaseManagerExportSettings.UserName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.UserName))]
    public static T SetUserName<T>(this T o, string v) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Set(() => o.UserName, v));
    /// <inheritdoc cref="GitReleaseManagerExportSettings.UserName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.UserName))]
    public static T ResetUserName<T>(this T o) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Remove(() => o.UserName));
    #endregion
    #region Password
    /// <inheritdoc cref="GitReleaseManagerExportSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="GitReleaseManagerExportSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region RepositoryOwner
    /// <inheritdoc cref="GitReleaseManagerExportSettings.RepositoryOwner"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.RepositoryOwner))]
    public static T SetRepositoryOwner<T>(this T o, string v) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Set(() => o.RepositoryOwner, v));
    /// <inheritdoc cref="GitReleaseManagerExportSettings.RepositoryOwner"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.RepositoryOwner))]
    public static T ResetRepositoryOwner<T>(this T o) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Remove(() => o.RepositoryOwner));
    #endregion
    #region RepositoryName
    /// <inheritdoc cref="GitReleaseManagerExportSettings.RepositoryName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.RepositoryName))]
    public static T SetRepositoryName<T>(this T o, string v) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Set(() => o.RepositoryName, v));
    /// <inheritdoc cref="GitReleaseManagerExportSettings.RepositoryName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.RepositoryName))]
    public static T ResetRepositoryName<T>(this T o) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Remove(() => o.RepositoryName));
    #endregion
    #region TargetDirectory
    /// <inheritdoc cref="GitReleaseManagerExportSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.TargetDirectory))]
    public static T SetTargetDirectory<T>(this T o, string v) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Set(() => o.TargetDirectory, v));
    /// <inheritdoc cref="GitReleaseManagerExportSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.TargetDirectory))]
    public static T ResetTargetDirectory<T>(this T o) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Remove(() => o.TargetDirectory));
    #endregion
    #region LogFilePath
    /// <inheritdoc cref="GitReleaseManagerExportSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.LogFilePath))]
    public static T SetLogFilePath<T>(this T o, string v) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Set(() => o.LogFilePath, v));
    /// <inheritdoc cref="GitReleaseManagerExportSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.LogFilePath))]
    public static T ResetLogFilePath<T>(this T o) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Remove(() => o.LogFilePath));
    #endregion
    #region Token
    /// <inheritdoc cref="GitReleaseManagerExportSettings.Token"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.Token))]
    public static T SetToken<T>(this T o, string v) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Set(() => o.Token, v));
    /// <inheritdoc cref="GitReleaseManagerExportSettings.Token"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerExportSettings), Property = nameof(GitReleaseManagerExportSettings.Token))]
    public static T ResetToken<T>(this T o) where T : GitReleaseManagerExportSettings => o.Modify(b => b.Remove(() => o.Token));
    #endregion
}
#endregion
#region GitReleaseManagerPublishSettingsExtensions
/// <summary>Used within <see cref="GitReleaseManagerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class GitReleaseManagerPublishSettingsExtensions
{
    #region TagName
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.TagName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.TagName))]
    public static T SetTagName<T>(this T o, string v) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Set(() => o.TagName, v));
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.TagName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.TagName))]
    public static T ResetTagName<T>(this T o) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Remove(() => o.TagName));
    #endregion
    #region UserName
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.UserName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.UserName))]
    public static T SetUserName<T>(this T o, string v) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Set(() => o.UserName, v));
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.UserName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.UserName))]
    public static T ResetUserName<T>(this T o) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Remove(() => o.UserName));
    #endregion
    #region Password
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region RepositoryOwner
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.RepositoryOwner"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.RepositoryOwner))]
    public static T SetRepositoryOwner<T>(this T o, string v) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Set(() => o.RepositoryOwner, v));
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.RepositoryOwner"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.RepositoryOwner))]
    public static T ResetRepositoryOwner<T>(this T o) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Remove(() => o.RepositoryOwner));
    #endregion
    #region RepositoryName
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.RepositoryName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.RepositoryName))]
    public static T SetRepositoryName<T>(this T o, string v) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Set(() => o.RepositoryName, v));
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.RepositoryName"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.RepositoryName))]
    public static T ResetRepositoryName<T>(this T o) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Remove(() => o.RepositoryName));
    #endregion
    #region TargetDirectory
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.TargetDirectory))]
    public static T SetTargetDirectory<T>(this T o, string v) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Set(() => o.TargetDirectory, v));
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.TargetDirectory"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.TargetDirectory))]
    public static T ResetTargetDirectory<T>(this T o) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Remove(() => o.TargetDirectory));
    #endregion
    #region LogFilePath
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.LogFilePath))]
    public static T SetLogFilePath<T>(this T o, string v) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Set(() => o.LogFilePath, v));
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.LogFilePath"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.LogFilePath))]
    public static T ResetLogFilePath<T>(this T o) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Remove(() => o.LogFilePath));
    #endregion
    #region Token
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.Token"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.Token))]
    public static T SetToken<T>(this T o, string v) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Set(() => o.Token, v));
    /// <inheritdoc cref="GitReleaseManagerPublishSettings.Token"/>
    [Pure] [Builder(Type = typeof(GitReleaseManagerPublishSettings), Property = nameof(GitReleaseManagerPublishSettings.Token))]
    public static T ResetToken<T>(this T o) where T : GitReleaseManagerPublishSettings => o.Modify(b => b.Remove(() => o.Token));
    #endregion
}
#endregion
