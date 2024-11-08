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

namespace Nuke.Common.Tools.NerdbankGitVersioning;

/// <summary><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class NerdbankGitVersioningTasks : ToolTasks, IRequireNuGetPackage
{
    public static string NerdbankGitVersioningPath => new NerdbankGitVersioningTasks().GetToolPath();
    public const string PackageId = "nbgv";
    public const string PackageExecutable = "nbgv.dll";
    /// <summary><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> NerdbankGitVersioning(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new NerdbankGitVersioningTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Prepares a project to have version stamps applied using Nerdbank.GitVersioning.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--path</c> via <see cref="NerdbankGitVersioningInstallSettings.Path"/></li><li><c>--source</c> via <see cref="NerdbankGitVersioningInstallSettings.Sources"/></li><li><c>--version</c> via <see cref="NerdbankGitVersioningInstallSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningInstall(NerdbankGitVersioningInstallSettings options = null) => new NerdbankGitVersioningTasks().Run(options);
    /// <summary><p>Prepares a project to have version stamps applied using Nerdbank.GitVersioning.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--path</c> via <see cref="NerdbankGitVersioningInstallSettings.Path"/></li><li><c>--source</c> via <see cref="NerdbankGitVersioningInstallSettings.Sources"/></li><li><c>--version</c> via <see cref="NerdbankGitVersioningInstallSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningInstall(Configure<NerdbankGitVersioningInstallSettings> configurator) => new NerdbankGitVersioningTasks().Run(configurator.Invoke(new NerdbankGitVersioningInstallSettings()));
    /// <summary><p>Prepares a project to have version stamps applied using Nerdbank.GitVersioning.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--path</c> via <see cref="NerdbankGitVersioningInstallSettings.Path"/></li><li><c>--source</c> via <see cref="NerdbankGitVersioningInstallSettings.Sources"/></li><li><c>--version</c> via <see cref="NerdbankGitVersioningInstallSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(NerdbankGitVersioningInstallSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningInstall(CombinatorialConfigure<NerdbankGitVersioningInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NerdbankGitVersioningInstall, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Gets the version information for a project.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningGetVersionSettings.CommitIsh"/></li><li><c>--format</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Format"/></li><li><c>--metadata</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Metadata"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Project"/></li><li><c>--variable</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Variable"/></li></ul></remarks>
    public static (NerdbankGitVersioning Result, IReadOnlyCollection<Output> Output) NerdbankGitVersioningGetVersion(NerdbankGitVersioningGetVersionSettings options = null) => new NerdbankGitVersioningTasks().Run<NerdbankGitVersioning>(options);
    /// <summary><p>Gets the version information for a project.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningGetVersionSettings.CommitIsh"/></li><li><c>--format</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Format"/></li><li><c>--metadata</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Metadata"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Project"/></li><li><c>--variable</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Variable"/></li></ul></remarks>
    public static (NerdbankGitVersioning Result, IReadOnlyCollection<Output> Output) NerdbankGitVersioningGetVersion(Configure<NerdbankGitVersioningGetVersionSettings> configurator) => new NerdbankGitVersioningTasks().Run<NerdbankGitVersioning>(configurator.Invoke(new NerdbankGitVersioningGetVersionSettings()));
    /// <summary><p>Gets the version information for a project.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningGetVersionSettings.CommitIsh"/></li><li><c>--format</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Format"/></li><li><c>--metadata</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Metadata"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Project"/></li><li><c>--variable</c> via <see cref="NerdbankGitVersioningGetVersionSettings.Variable"/></li></ul></remarks>
    public static IEnumerable<(NerdbankGitVersioningGetVersionSettings Settings, NerdbankGitVersioning Result, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningGetVersion(CombinatorialConfigure<NerdbankGitVersioningGetVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NerdbankGitVersioningGetVersion, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Updates the version stamp that is applied to a project.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Version"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Project"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningSetVersion(NerdbankGitVersioningSetVersionSettings options = null) => new NerdbankGitVersioningTasks().Run(options);
    /// <summary><p>Updates the version stamp that is applied to a project.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Version"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Project"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningSetVersion(Configure<NerdbankGitVersioningSetVersionSettings> configurator) => new NerdbankGitVersioningTasks().Run(configurator.Invoke(new NerdbankGitVersioningSetVersionSettings()));
    /// <summary><p>Updates the version stamp that is applied to a project.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Version"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningSetVersionSettings.Project"/></li></ul></remarks>
    public static IEnumerable<(NerdbankGitVersioningSetVersionSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningSetVersion(CombinatorialConfigure<NerdbankGitVersioningSetVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NerdbankGitVersioningSetVersion, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Creates a git tag to mark a version.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningTagSettings.VersionOrRef"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningTagSettings.Project"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningTag(NerdbankGitVersioningTagSettings options = null) => new NerdbankGitVersioningTasks().Run(options);
    /// <summary><p>Creates a git tag to mark a version.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningTagSettings.VersionOrRef"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningTagSettings.Project"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningTag(Configure<NerdbankGitVersioningTagSettings> configurator) => new NerdbankGitVersioningTasks().Run(configurator.Invoke(new NerdbankGitVersioningTagSettings()));
    /// <summary><p>Creates a git tag to mark a version.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningTagSettings.VersionOrRef"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningTagSettings.Project"/></li></ul></remarks>
    public static IEnumerable<(NerdbankGitVersioningTagSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningTag(CombinatorialConfigure<NerdbankGitVersioningTagSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NerdbankGitVersioningTag, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Gets the commit(s) that match a given version.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Version"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Project"/></li><li><c>--quiet</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningGetCommits(NerdbankGitVersioningGetCommitsSettings options = null) => new NerdbankGitVersioningTasks().Run(options);
    /// <summary><p>Gets the commit(s) that match a given version.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Version"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Project"/></li><li><c>--quiet</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningGetCommits(Configure<NerdbankGitVersioningGetCommitsSettings> configurator) => new NerdbankGitVersioningTasks().Run(configurator.Invoke(new NerdbankGitVersioningGetCommitsSettings()));
    /// <summary><p>Gets the commit(s) that match a given version.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Version"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Project"/></li><li><c>--quiet</c> via <see cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/></li></ul></remarks>
    public static IEnumerable<(NerdbankGitVersioningGetCommitsSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningGetCommits(CombinatorialConfigure<NerdbankGitVersioningGetCommitsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NerdbankGitVersioningGetCommits, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Communicates with the ambient cloud build to set the build number and/or other cloud build variables.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--all-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></li><li><c>--ci-system</c> via <see cref="NerdbankGitVersioningCloudSettings.CISystem"/></li><li><c>--common-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></li><li><c>--define</c> via <see cref="NerdbankGitVersioningCloudSettings.Variables"/></li><li><c>--metadata</c> via <see cref="NerdbankGitVersioningCloudSettings.Metadata"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningCloudSettings.Project"/></li><li><c>--version</c> via <see cref="NerdbankGitVersioningCloudSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningCloud(NerdbankGitVersioningCloudSettings options = null) => new NerdbankGitVersioningTasks().Run(options);
    /// <summary><p>Communicates with the ambient cloud build to set the build number and/or other cloud build variables.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--all-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></li><li><c>--ci-system</c> via <see cref="NerdbankGitVersioningCloudSettings.CISystem"/></li><li><c>--common-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></li><li><c>--define</c> via <see cref="NerdbankGitVersioningCloudSettings.Variables"/></li><li><c>--metadata</c> via <see cref="NerdbankGitVersioningCloudSettings.Metadata"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningCloudSettings.Project"/></li><li><c>--version</c> via <see cref="NerdbankGitVersioningCloudSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningCloud(Configure<NerdbankGitVersioningCloudSettings> configurator) => new NerdbankGitVersioningTasks().Run(configurator.Invoke(new NerdbankGitVersioningCloudSettings()));
    /// <summary><p>Communicates with the ambient cloud build to set the build number and/or other cloud build variables.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--all-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.AllVars"/></li><li><c>--ci-system</c> via <see cref="NerdbankGitVersioningCloudSettings.CISystem"/></li><li><c>--common-vars</c> via <see cref="NerdbankGitVersioningCloudSettings.CommonVars"/></li><li><c>--define</c> via <see cref="NerdbankGitVersioningCloudSettings.Variables"/></li><li><c>--metadata</c> via <see cref="NerdbankGitVersioningCloudSettings.Metadata"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningCloudSettings.Project"/></li><li><c>--version</c> via <see cref="NerdbankGitVersioningCloudSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(NerdbankGitVersioningCloudSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningCloud(CombinatorialConfigure<NerdbankGitVersioningCloudSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NerdbankGitVersioningCloud, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Prepares a release by creating a release branch for the current version and adjusting the version on the current branch.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Tag"/></li><li><c>--nextVersion</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.NextVersion"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Project"/></li><li><c>--versionIncrement</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningPrepareRelease(NerdbankGitVersioningPrepareReleaseSettings options = null) => new NerdbankGitVersioningTasks().Run(options);
    /// <summary><p>Prepares a release by creating a release branch for the current version and adjusting the version on the current branch.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Tag"/></li><li><c>--nextVersion</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.NextVersion"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Project"/></li><li><c>--versionIncrement</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NerdbankGitVersioningPrepareRelease(Configure<NerdbankGitVersioningPrepareReleaseSettings> configurator) => new NerdbankGitVersioningTasks().Run(configurator.Invoke(new NerdbankGitVersioningPrepareReleaseSettings()));
    /// <summary><p>Prepares a release by creating a release branch for the current version and adjusting the version on the current branch.</p><p>For more details, visit the <a href="https://github.com/AArnott/Nerdbank.GitVersioning">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Tag"/></li><li><c>--nextVersion</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.NextVersion"/></li><li><c>--project</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.Project"/></li><li><c>--versionIncrement</c> via <see cref="NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement"/></li></ul></remarks>
    public static IEnumerable<(NerdbankGitVersioningPrepareReleaseSettings Settings, IReadOnlyCollection<Output> Output)> NerdbankGitVersioningPrepareRelease(CombinatorialConfigure<NerdbankGitVersioningPrepareReleaseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NerdbankGitVersioningPrepareRelease, degreeOfParallelism, completeOnFailure);
}
#region NerdbankGitVersioningInstallSettings
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NerdbankGitVersioningInstallSettings>))]
[Command(Type = typeof(NerdbankGitVersioningTasks), Command = nameof(NerdbankGitVersioningTasks.NerdbankGitVersioningInstall), Arguments = "install")]
public partial class NerdbankGitVersioningInstallSettings : ToolOptions
{
    /// <summary>The path to the directory that should contain the version.json file. The default is the root of the git repo.</summary>
    [Argument(Format = "--path {value}")] public string Path => Get<string>(() => Path);
    /// <summary>The initial version to set. The default is <c>1.0-beta</c>.</summary>
    [Argument(Format = "--version {value}")] public string Version => Get<string>(() => Version);
    /// <summary>The URI(s) of the NuGet package source(s) used to determine the latest stable version of the Nerdbank.GitVersioning package. This setting overrides all of the sources specified in the NuGet.Config files.</summary>
    [Argument(Format = "--source {value}", Separator = " ")] public IReadOnlyList<string> Sources => Get<List<string>>(() => Sources);
}
#endregion
#region NerdbankGitVersioningGetVersionSettings
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NerdbankGitVersioningGetVersionSettings>))]
[Command(Type = typeof(NerdbankGitVersioningTasks), Command = nameof(NerdbankGitVersioningTasks.NerdbankGitVersioningGetVersion), Arguments = "get-version")]
public partial class NerdbankGitVersioningGetVersionSettings : ToolOptions
{
    /// <summary>The path to the project or project directory. The default is the current directory.</summary>
    [Argument(Format = "--project {value}")] public string Project => Get<string>(() => Project);
    /// <summary>Adds an identifier to the build metadata part of a semantic version.</summary>
    [Argument(Format = "--metadata {value}")] public string Metadata => Get<string>(() => Metadata);
    /// <summary>The format to write the version information. Allowed values are: <c>text</c>, <c>json</c>. The default is <c>text</c>.</summary>
    [Argument(Format = "--format {value}")] public NerdbankGitVersioningFormat Format => Get<NerdbankGitVersioningFormat>(() => Format);
    /// <summary>The name of just one version property to print to stdout. When specified, the output is always in raw text. Useful in scripts.</summary>
    [Argument(Format = "--variable {value}")] public string Variable => Get<string>(() => Variable);
    /// <summary>The commit/ref to get the version information for. The default is <c>HEAD</c>.</summary>
    [Argument(Format = "-- {value}")] public string CommitIsh => Get<string>(() => CommitIsh);
}
#endregion
#region NerdbankGitVersioningSetVersionSettings
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NerdbankGitVersioningSetVersionSettings>))]
[Command(Type = typeof(NerdbankGitVersioningTasks), Command = nameof(NerdbankGitVersioningTasks.NerdbankGitVersioningSetVersion), Arguments = "set-version")]
public partial class NerdbankGitVersioningSetVersionSettings : ToolOptions
{
    /// <summary>The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.</summary>
    [Argument(Format = "--project {value}")] public string Project => Get<string>(() => Project);
    /// <summary>The version to set.</summary>
    [Argument(Format = "-- {value}")] public string Version => Get<string>(() => Version);
}
#endregion
#region NerdbankGitVersioningTagSettings
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NerdbankGitVersioningTagSettings>))]
[Command(Type = typeof(NerdbankGitVersioningTasks), Command = nameof(NerdbankGitVersioningTasks.NerdbankGitVersioningTag), Arguments = "tag")]
public partial class NerdbankGitVersioningTagSettings : ToolOptions
{
    /// <summary>The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.</summary>
    [Argument(Format = "--project {value}")] public string Project => Get<string>(() => Project);
    /// <summary>The <c>a.b.c[.d]</c> version or git ref to be tagged. If not specified, <c>HEAD</c> is used.</summary>
    [Argument(Format = "-- {value}")] public string VersionOrRef => Get<string>(() => VersionOrRef);
}
#endregion
#region NerdbankGitVersioningGetCommitsSettings
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NerdbankGitVersioningGetCommitsSettings>))]
[Command(Type = typeof(NerdbankGitVersioningTasks), Command = nameof(NerdbankGitVersioningTasks.NerdbankGitVersioningGetCommits), Arguments = "get-commits")]
public partial class NerdbankGitVersioningGetCommitsSettings : ToolOptions
{
    /// <summary>The path to the project or project directory. The default is the root directory of the repo that spans the current directory, or an existing version.json file, if applicable.</summary>
    [Argument(Format = "--project {value}")] public string Project => Get<string>(() => Project);
    /// <summary>Use minimal output.</summary>
    [Argument(Format = "--quiet")] public bool? Quiet => Get<bool?>(() => Quiet);
    /// <summary>The <c>a.b.c[.d]</c> version to find.</summary>
    [Argument(Format = "-- {value}")] public string Version => Get<string>(() => Version);
}
#endregion
#region NerdbankGitVersioningCloudSettings
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NerdbankGitVersioningCloudSettings>))]
[Command(Type = typeof(NerdbankGitVersioningTasks), Command = nameof(NerdbankGitVersioningTasks.NerdbankGitVersioningCloud), Arguments = "cloud")]
public partial class NerdbankGitVersioningCloudSettings : ToolOptions
{
    /// <summary>The path to the project or project directory used to calculate the version. The default is the current directory. Ignored if the <c>--version</c> option is specified.</summary>
    [Argument(Format = "--project {value}")] public string Project => Get<string>(() => Project);
    /// <summary>Adds an identifier to the build metadata part of a semantic version.</summary>
    [Argument(Format = "--metadata {value}")] public string Metadata => Get<string>(() => Metadata);
    /// <summary>The string to use for the cloud build number. If not specified, the computed version will be used.</summary>
    [Argument(Format = "--version {value}")] public string Version => Get<string>(() => Version);
    /// <summary>Force activation for a particular CI system. If not specified, auto-detection will be used.</summary>
    [Argument(Format = "--ci-system {value}")] public NerdbankGitVersioningCISystem CISystem => Get<NerdbankGitVersioningCISystem>(() => CISystem);
    /// <summary>Defines ALL version variables as cloud build variables, with a <c>NBGV_</c> prefix.</summary>
    [Argument(Format = "--all-vars")] public bool? AllVars => Get<bool?>(() => AllVars);
    /// <summary>Defines a few common version variables as cloud build variables, with a <c>Git</c> prefix (e.g. <c>GitBuildVersion</c>, <c>GitBuildVersionSimple</c>, <c>GitAssemblyInformationalVersion</c>)</summary>
    [Argument(Format = "--common-vars")] public bool? CommonVars => Get<bool?>(() => CommonVars);
    /// <summary>Additional cloud build variables to define.</summary>
    [Argument(Format = "--define {key}={value}")] public IReadOnlyDictionary<string, string> Variables => Get<Dictionary<string, string>>(() => Variables);
}
#endregion
#region NerdbankGitVersioningPrepareReleaseSettings
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NerdbankGitVersioningPrepareReleaseSettings>))]
[Command(Type = typeof(NerdbankGitVersioningTasks), Command = nameof(NerdbankGitVersioningTasks.NerdbankGitVersioningPrepareRelease), Arguments = "prepare-release")]
public partial class NerdbankGitVersioningPrepareReleaseSettings : ToolOptions
{
    /// <summary>The path to the project or project directory. The default is the current directory.</summary>
    [Argument(Format = "--project {value}")] public string Project => Get<string>(() => Project);
    /// <summary> The version to set for the current branch. If omitted, the next version is determined automatically by incrementing the current version.</summary>
    [Argument(Format = "--nextVersion {value}")] public string NextVersion => Get<string>(() => NextVersion);
    /// <summary>Overrides the 'versionIncrement' setting set in version.json for determining the next version of the current branch.</summary>
    [Argument(Format = "--versionIncrement {value}")] public string VersionIncrement => Get<string>(() => VersionIncrement);
    /// <summary>The prerelease tag to apply on the release branch (if any). If not specified, any existing prerelease tag will be removed. The preceding hyphen may be omitted.</summary>
    [Argument(Format = "-- {value}")] public string Tag => Get<string>(() => Tag);
}
#endregion
#region NerdbankGitVersioningInstallSettingsExtensions
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NerdbankGitVersioningInstallSettingsExtensions
{
    #region Path
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Path"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Path))]
    public static T SetPath<T>(this T o, string v) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.Set(() => o.Path, v));
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Path"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Path))]
    public static T ResetPath<T>(this T o) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.Remove(() => o.Path));
    #endregion
    #region Version
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Version"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Version"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Sources
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Sources"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Sources))]
    public static T SetSources<T>(this T o, params string[] v) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.Set(() => o.Sources, v));
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Sources"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Sources))]
    public static T SetSources<T>(this T o, IEnumerable<string> v) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.Set(() => o.Sources, v));
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Sources"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Sources))]
    public static T AddSources<T>(this T o, params string[] v) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.AddCollection(() => o.Sources, v));
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Sources"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Sources))]
    public static T AddSources<T>(this T o, IEnumerable<string> v) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.AddCollection(() => o.Sources, v));
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Sources"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Sources))]
    public static T RemoveSources<T>(this T o, params string[] v) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.RemoveCollection(() => o.Sources, v));
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Sources"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Sources))]
    public static T RemoveSources<T>(this T o, IEnumerable<string> v) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.RemoveCollection(() => o.Sources, v));
    /// <inheritdoc cref="NerdbankGitVersioningInstallSettings.Sources"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningInstallSettings), Property = nameof(NerdbankGitVersioningInstallSettings.Sources))]
    public static T ClearSources<T>(this T o) where T : NerdbankGitVersioningInstallSettings => o.Modify(b => b.ClearCollection(() => o.Sources));
    #endregion
}
#endregion
#region NerdbankGitVersioningGetVersionSettingsExtensions
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NerdbankGitVersioningGetVersionSettingsExtensions
{
    #region Project
    /// <inheritdoc cref="NerdbankGitVersioningGetVersionSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetVersionSettings), Property = nameof(NerdbankGitVersioningGetVersionSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : NerdbankGitVersioningGetVersionSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="NerdbankGitVersioningGetVersionSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetVersionSettings), Property = nameof(NerdbankGitVersioningGetVersionSettings.Project))]
    public static T ResetProject<T>(this T o) where T : NerdbankGitVersioningGetVersionSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region Metadata
    /// <inheritdoc cref="NerdbankGitVersioningGetVersionSettings.Metadata"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetVersionSettings), Property = nameof(NerdbankGitVersioningGetVersionSettings.Metadata))]
    public static T SetMetadata<T>(this T o, string v) where T : NerdbankGitVersioningGetVersionSettings => o.Modify(b => b.Set(() => o.Metadata, v));
    /// <inheritdoc cref="NerdbankGitVersioningGetVersionSettings.Metadata"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetVersionSettings), Property = nameof(NerdbankGitVersioningGetVersionSettings.Metadata))]
    public static T ResetMetadata<T>(this T o) where T : NerdbankGitVersioningGetVersionSettings => o.Modify(b => b.Remove(() => o.Metadata));
    #endregion
    #region Format
    /// <inheritdoc cref="NerdbankGitVersioningGetVersionSettings.Format"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetVersionSettings), Property = nameof(NerdbankGitVersioningGetVersionSettings.Format))]
    public static T SetFormat<T>(this T o, NerdbankGitVersioningFormat v) where T : NerdbankGitVersioningGetVersionSettings => o.Modify(b => b.Set(() => o.Format, v));
    /// <inheritdoc cref="NerdbankGitVersioningGetVersionSettings.Format"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetVersionSettings), Property = nameof(NerdbankGitVersioningGetVersionSettings.Format))]
    public static T ResetFormat<T>(this T o) where T : NerdbankGitVersioningGetVersionSettings => o.Modify(b => b.Remove(() => o.Format));
    #endregion
    #region Variable
    /// <inheritdoc cref="NerdbankGitVersioningGetVersionSettings.Variable"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetVersionSettings), Property = nameof(NerdbankGitVersioningGetVersionSettings.Variable))]
    public static T SetVariable<T>(this T o, string v) where T : NerdbankGitVersioningGetVersionSettings => o.Modify(b => b.Set(() => o.Variable, v));
    /// <inheritdoc cref="NerdbankGitVersioningGetVersionSettings.Variable"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetVersionSettings), Property = nameof(NerdbankGitVersioningGetVersionSettings.Variable))]
    public static T ResetVariable<T>(this T o) where T : NerdbankGitVersioningGetVersionSettings => o.Modify(b => b.Remove(() => o.Variable));
    #endregion
    #region CommitIsh
    /// <inheritdoc cref="NerdbankGitVersioningGetVersionSettings.CommitIsh"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetVersionSettings), Property = nameof(NerdbankGitVersioningGetVersionSettings.CommitIsh))]
    public static T SetCommitIsh<T>(this T o, string v) where T : NerdbankGitVersioningGetVersionSettings => o.Modify(b => b.Set(() => o.CommitIsh, v));
    /// <inheritdoc cref="NerdbankGitVersioningGetVersionSettings.CommitIsh"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetVersionSettings), Property = nameof(NerdbankGitVersioningGetVersionSettings.CommitIsh))]
    public static T ResetCommitIsh<T>(this T o) where T : NerdbankGitVersioningGetVersionSettings => o.Modify(b => b.Remove(() => o.CommitIsh));
    #endregion
}
#endregion
#region NerdbankGitVersioningSetVersionSettingsExtensions
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NerdbankGitVersioningSetVersionSettingsExtensions
{
    #region Project
    /// <inheritdoc cref="NerdbankGitVersioningSetVersionSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningSetVersionSettings), Property = nameof(NerdbankGitVersioningSetVersionSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : NerdbankGitVersioningSetVersionSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="NerdbankGitVersioningSetVersionSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningSetVersionSettings), Property = nameof(NerdbankGitVersioningSetVersionSettings.Project))]
    public static T ResetProject<T>(this T o) where T : NerdbankGitVersioningSetVersionSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region Version
    /// <inheritdoc cref="NerdbankGitVersioningSetVersionSettings.Version"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningSetVersionSettings), Property = nameof(NerdbankGitVersioningSetVersionSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : NerdbankGitVersioningSetVersionSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="NerdbankGitVersioningSetVersionSettings.Version"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningSetVersionSettings), Property = nameof(NerdbankGitVersioningSetVersionSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : NerdbankGitVersioningSetVersionSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
}
#endregion
#region NerdbankGitVersioningTagSettingsExtensions
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NerdbankGitVersioningTagSettingsExtensions
{
    #region Project
    /// <inheritdoc cref="NerdbankGitVersioningTagSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningTagSettings), Property = nameof(NerdbankGitVersioningTagSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : NerdbankGitVersioningTagSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="NerdbankGitVersioningTagSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningTagSettings), Property = nameof(NerdbankGitVersioningTagSettings.Project))]
    public static T ResetProject<T>(this T o) where T : NerdbankGitVersioningTagSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region VersionOrRef
    /// <inheritdoc cref="NerdbankGitVersioningTagSettings.VersionOrRef"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningTagSettings), Property = nameof(NerdbankGitVersioningTagSettings.VersionOrRef))]
    public static T SetVersionOrRef<T>(this T o, string v) where T : NerdbankGitVersioningTagSettings => o.Modify(b => b.Set(() => o.VersionOrRef, v));
    /// <inheritdoc cref="NerdbankGitVersioningTagSettings.VersionOrRef"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningTagSettings), Property = nameof(NerdbankGitVersioningTagSettings.VersionOrRef))]
    public static T ResetVersionOrRef<T>(this T o) where T : NerdbankGitVersioningTagSettings => o.Modify(b => b.Remove(() => o.VersionOrRef));
    #endregion
}
#endregion
#region NerdbankGitVersioningGetCommitsSettingsExtensions
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NerdbankGitVersioningGetCommitsSettingsExtensions
{
    #region Project
    /// <inheritdoc cref="NerdbankGitVersioningGetCommitsSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetCommitsSettings), Property = nameof(NerdbankGitVersioningGetCommitsSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : NerdbankGitVersioningGetCommitsSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="NerdbankGitVersioningGetCommitsSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetCommitsSettings), Property = nameof(NerdbankGitVersioningGetCommitsSettings.Project))]
    public static T ResetProject<T>(this T o) where T : NerdbankGitVersioningGetCommitsSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region Quiet
    /// <inheritdoc cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetCommitsSettings), Property = nameof(NerdbankGitVersioningGetCommitsSettings.Quiet))]
    public static T SetQuiet<T>(this T o, bool? v) where T : NerdbankGitVersioningGetCommitsSettings => o.Modify(b => b.Set(() => o.Quiet, v));
    /// <inheritdoc cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetCommitsSettings), Property = nameof(NerdbankGitVersioningGetCommitsSettings.Quiet))]
    public static T ResetQuiet<T>(this T o) where T : NerdbankGitVersioningGetCommitsSettings => o.Modify(b => b.Remove(() => o.Quiet));
    /// <inheritdoc cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetCommitsSettings), Property = nameof(NerdbankGitVersioningGetCommitsSettings.Quiet))]
    public static T EnableQuiet<T>(this T o) where T : NerdbankGitVersioningGetCommitsSettings => o.Modify(b => b.Set(() => o.Quiet, true));
    /// <inheritdoc cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetCommitsSettings), Property = nameof(NerdbankGitVersioningGetCommitsSettings.Quiet))]
    public static T DisableQuiet<T>(this T o) where T : NerdbankGitVersioningGetCommitsSettings => o.Modify(b => b.Set(() => o.Quiet, false));
    /// <inheritdoc cref="NerdbankGitVersioningGetCommitsSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetCommitsSettings), Property = nameof(NerdbankGitVersioningGetCommitsSettings.Quiet))]
    public static T ToggleQuiet<T>(this T o) where T : NerdbankGitVersioningGetCommitsSettings => o.Modify(b => b.Set(() => o.Quiet, !o.Quiet));
    #endregion
    #region Version
    /// <inheritdoc cref="NerdbankGitVersioningGetCommitsSettings.Version"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetCommitsSettings), Property = nameof(NerdbankGitVersioningGetCommitsSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : NerdbankGitVersioningGetCommitsSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="NerdbankGitVersioningGetCommitsSettings.Version"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningGetCommitsSettings), Property = nameof(NerdbankGitVersioningGetCommitsSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : NerdbankGitVersioningGetCommitsSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
}
#endregion
#region NerdbankGitVersioningCloudSettingsExtensions
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NerdbankGitVersioningCloudSettingsExtensions
{
    #region Project
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Project))]
    public static T ResetProject<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region Metadata
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Metadata"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Metadata))]
    public static T SetMetadata<T>(this T o, string v) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.Metadata, v));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Metadata"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Metadata))]
    public static T ResetMetadata<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Remove(() => o.Metadata));
    #endregion
    #region Version
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Version"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Version"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region CISystem
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.CISystem"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.CISystem))]
    public static T SetCISystem<T>(this T o, NerdbankGitVersioningCISystem v) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.CISystem, v));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.CISystem"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.CISystem))]
    public static T ResetCISystem<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Remove(() => o.CISystem));
    #endregion
    #region AllVars
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.AllVars"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.AllVars))]
    public static T SetAllVars<T>(this T o, bool? v) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.AllVars, v));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.AllVars"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.AllVars))]
    public static T ResetAllVars<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Remove(() => o.AllVars));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.AllVars"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.AllVars))]
    public static T EnableAllVars<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.AllVars, true));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.AllVars"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.AllVars))]
    public static T DisableAllVars<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.AllVars, false));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.AllVars"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.AllVars))]
    public static T ToggleAllVars<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.AllVars, !o.AllVars));
    #endregion
    #region CommonVars
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.CommonVars"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.CommonVars))]
    public static T SetCommonVars<T>(this T o, bool? v) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.CommonVars, v));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.CommonVars"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.CommonVars))]
    public static T ResetCommonVars<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Remove(() => o.CommonVars));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.CommonVars"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.CommonVars))]
    public static T EnableCommonVars<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.CommonVars, true));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.CommonVars"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.CommonVars))]
    public static T DisableCommonVars<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.CommonVars, false));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.CommonVars"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.CommonVars))]
    public static T ToggleCommonVars<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.CommonVars, !o.CommonVars));
    #endregion
    #region Variables
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Variables"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Variables))]
    public static T SetVariables<T>(this T o, IDictionary<string, string> v) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.Set(() => o.Variables, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Variables"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Variables))]
    public static T SetVariable<T>(this T o, string k, string v) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.SetDictionary(() => o.Variables, k, v));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Variables"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Variables))]
    public static T AddVariable<T>(this T o, string k, string v) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.AddDictionary(() => o.Variables, k, v));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Variables"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Variables))]
    public static T RemoveVariable<T>(this T o, string k) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.RemoveDictionary(() => o.Variables, k));
    /// <inheritdoc cref="NerdbankGitVersioningCloudSettings.Variables"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningCloudSettings), Property = nameof(NerdbankGitVersioningCloudSettings.Variables))]
    public static T ClearVariables<T>(this T o) where T : NerdbankGitVersioningCloudSettings => o.Modify(b => b.ClearDictionary(() => o.Variables));
    #endregion
}
#endregion
#region NerdbankGitVersioningPrepareReleaseSettingsExtensions
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NerdbankGitVersioningPrepareReleaseSettingsExtensions
{
    #region Project
    /// <inheritdoc cref="NerdbankGitVersioningPrepareReleaseSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningPrepareReleaseSettings), Property = nameof(NerdbankGitVersioningPrepareReleaseSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : NerdbankGitVersioningPrepareReleaseSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="NerdbankGitVersioningPrepareReleaseSettings.Project"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningPrepareReleaseSettings), Property = nameof(NerdbankGitVersioningPrepareReleaseSettings.Project))]
    public static T ResetProject<T>(this T o) where T : NerdbankGitVersioningPrepareReleaseSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region NextVersion
    /// <inheritdoc cref="NerdbankGitVersioningPrepareReleaseSettings.NextVersion"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningPrepareReleaseSettings), Property = nameof(NerdbankGitVersioningPrepareReleaseSettings.NextVersion))]
    public static T SetNextVersion<T>(this T o, string v) where T : NerdbankGitVersioningPrepareReleaseSettings => o.Modify(b => b.Set(() => o.NextVersion, v));
    /// <inheritdoc cref="NerdbankGitVersioningPrepareReleaseSettings.NextVersion"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningPrepareReleaseSettings), Property = nameof(NerdbankGitVersioningPrepareReleaseSettings.NextVersion))]
    public static T ResetNextVersion<T>(this T o) where T : NerdbankGitVersioningPrepareReleaseSettings => o.Modify(b => b.Remove(() => o.NextVersion));
    #endregion
    #region VersionIncrement
    /// <inheritdoc cref="NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningPrepareReleaseSettings), Property = nameof(NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement))]
    public static T SetVersionIncrement<T>(this T o, string v) where T : NerdbankGitVersioningPrepareReleaseSettings => o.Modify(b => b.Set(() => o.VersionIncrement, v));
    /// <inheritdoc cref="NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningPrepareReleaseSettings), Property = nameof(NerdbankGitVersioningPrepareReleaseSettings.VersionIncrement))]
    public static T ResetVersionIncrement<T>(this T o) where T : NerdbankGitVersioningPrepareReleaseSettings => o.Modify(b => b.Remove(() => o.VersionIncrement));
    #endregion
    #region Tag
    /// <inheritdoc cref="NerdbankGitVersioningPrepareReleaseSettings.Tag"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningPrepareReleaseSettings), Property = nameof(NerdbankGitVersioningPrepareReleaseSettings.Tag))]
    public static T SetTag<T>(this T o, string v) where T : NerdbankGitVersioningPrepareReleaseSettings => o.Modify(b => b.Set(() => o.Tag, v));
    /// <inheritdoc cref="NerdbankGitVersioningPrepareReleaseSettings.Tag"/>
    [Pure] [Builder(Type = typeof(NerdbankGitVersioningPrepareReleaseSettings), Property = nameof(NerdbankGitVersioningPrepareReleaseSettings.Tag))]
    public static T ResetTag<T>(this T o) where T : NerdbankGitVersioningPrepareReleaseSettings => o.Modify(b => b.Remove(() => o.Tag));
    #endregion
}
#endregion
#region NerdbankGitVersioningFormat
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
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
/// <summary>Used within <see cref="NerdbankGitVersioningTasks"/>.</summary>
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
