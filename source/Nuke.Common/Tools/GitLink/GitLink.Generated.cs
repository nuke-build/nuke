// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/GitLink/GitLink.json

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

namespace Nuke.Common.Tools.GitLink;

/// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class GitLinkTasks : ToolTasks, IRequireNuGetPackage
{
    public static string GitLinkPath => new GitLinkTasks().GetToolPath();
    public const string PackageId = "gitlink";
    public const string PackageExecutable = "GitLink.exe";
    /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> GitLink(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new GitLinkTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;solutionDirectory&gt;</c> via <see cref="GitLink2Settings.SolutionDirectory"/></li><li><c>-b</c> via <see cref="GitLink2Settings.BranchName"/></li><li><c>-c</c> via <see cref="GitLink2Settings.Configuration"/></li><li><c>-d</c> via <see cref="GitLink2Settings.PdbDirectory"/></li><li><c>-debug</c> via <see cref="GitLink2Settings.Debug"/></li><li><c>-errorsaswarnings</c> via <see cref="GitLink2Settings.ErrorsAsWarnings"/></li><li><c>-f</c> via <see cref="GitLink2Settings.File"/></li><li><c>-l</c> via <see cref="GitLink2Settings.LogFile"/></li><li><c>-p</c> via <see cref="GitLink2Settings.Platform"/></li><li><c>-powershell</c> via <see cref="GitLink2Settings.UsePowershell"/></li><li><c>-s</c> via <see cref="GitLink2Settings.CommitSha"/></li><li><c>-skipverify</c> via <see cref="GitLink2Settings.SkipVerification"/></li><li><c>-u</c> via <see cref="GitLink2Settings.RepositoryUrl"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitLink2(GitLink2Settings options = null) => new GitLinkTasks().Run(options);
    /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;solutionDirectory&gt;</c> via <see cref="GitLink2Settings.SolutionDirectory"/></li><li><c>-b</c> via <see cref="GitLink2Settings.BranchName"/></li><li><c>-c</c> via <see cref="GitLink2Settings.Configuration"/></li><li><c>-d</c> via <see cref="GitLink2Settings.PdbDirectory"/></li><li><c>-debug</c> via <see cref="GitLink2Settings.Debug"/></li><li><c>-errorsaswarnings</c> via <see cref="GitLink2Settings.ErrorsAsWarnings"/></li><li><c>-f</c> via <see cref="GitLink2Settings.File"/></li><li><c>-l</c> via <see cref="GitLink2Settings.LogFile"/></li><li><c>-p</c> via <see cref="GitLink2Settings.Platform"/></li><li><c>-powershell</c> via <see cref="GitLink2Settings.UsePowershell"/></li><li><c>-s</c> via <see cref="GitLink2Settings.CommitSha"/></li><li><c>-skipverify</c> via <see cref="GitLink2Settings.SkipVerification"/></li><li><c>-u</c> via <see cref="GitLink2Settings.RepositoryUrl"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitLink2(Configure<GitLink2Settings> configurator) => new GitLinkTasks().Run(configurator.Invoke(new GitLink2Settings()));
    /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;solutionDirectory&gt;</c> via <see cref="GitLink2Settings.SolutionDirectory"/></li><li><c>-b</c> via <see cref="GitLink2Settings.BranchName"/></li><li><c>-c</c> via <see cref="GitLink2Settings.Configuration"/></li><li><c>-d</c> via <see cref="GitLink2Settings.PdbDirectory"/></li><li><c>-debug</c> via <see cref="GitLink2Settings.Debug"/></li><li><c>-errorsaswarnings</c> via <see cref="GitLink2Settings.ErrorsAsWarnings"/></li><li><c>-f</c> via <see cref="GitLink2Settings.File"/></li><li><c>-l</c> via <see cref="GitLink2Settings.LogFile"/></li><li><c>-p</c> via <see cref="GitLink2Settings.Platform"/></li><li><c>-powershell</c> via <see cref="GitLink2Settings.UsePowershell"/></li><li><c>-s</c> via <see cref="GitLink2Settings.CommitSha"/></li><li><c>-skipverify</c> via <see cref="GitLink2Settings.SkipVerification"/></li><li><c>-u</c> via <see cref="GitLink2Settings.RepositoryUrl"/></li></ul></remarks>
    public static IEnumerable<(GitLink2Settings Settings, IReadOnlyCollection<Output> Output)> GitLink2(CombinatorialConfigure<GitLink2Settings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(GitLink2, degreeOfParallelism, completeOnFailure);
    /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;pdbFile&gt;</c> via <see cref="GitLink3Settings.PdbFile"/></li><li><c>--baseDir</c> via <see cref="GitLink3Settings.BaseDirectory"/></li><li><c>--commit</c> via <see cref="GitLink3Settings.CommitSha"/></li><li><c>--method</c> via <see cref="GitLink3Settings.Method"/></li><li><c>--skipVerify</c> via <see cref="GitLink3Settings.SkipVerification"/></li><li><c>--url</c> via <see cref="GitLink3Settings.RepositoryUrl"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitLink3(GitLink3Settings options = null) => new GitLinkTasks().Run(options);
    /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;pdbFile&gt;</c> via <see cref="GitLink3Settings.PdbFile"/></li><li><c>--baseDir</c> via <see cref="GitLink3Settings.BaseDirectory"/></li><li><c>--commit</c> via <see cref="GitLink3Settings.CommitSha"/></li><li><c>--method</c> via <see cref="GitLink3Settings.Method"/></li><li><c>--skipVerify</c> via <see cref="GitLink3Settings.SkipVerification"/></li><li><c>--url</c> via <see cref="GitLink3Settings.RepositoryUrl"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> GitLink3(Configure<GitLink3Settings> configurator) => new GitLinkTasks().Run(configurator.Invoke(new GitLink3Settings()));
    /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;pdbFile&gt;</c> via <see cref="GitLink3Settings.PdbFile"/></li><li><c>--baseDir</c> via <see cref="GitLink3Settings.BaseDirectory"/></li><li><c>--commit</c> via <see cref="GitLink3Settings.CommitSha"/></li><li><c>--method</c> via <see cref="GitLink3Settings.Method"/></li><li><c>--skipVerify</c> via <see cref="GitLink3Settings.SkipVerification"/></li><li><c>--url</c> via <see cref="GitLink3Settings.RepositoryUrl"/></li></ul></remarks>
    public static IEnumerable<(GitLink3Settings Settings, IReadOnlyCollection<Output> Output)> GitLink3(CombinatorialConfigure<GitLink3Settings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(GitLink3, degreeOfParallelism, completeOnFailure);
}
#region GitLink2Settings
/// <summary>Used within <see cref="GitLinkTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitLink2Settings>))]
[Command(Type = typeof(GitLinkTasks), Command = nameof(GitLinkTasks.GitLink2))]
public partial class GitLink2Settings : ToolOptions
{
    /// <summary>The directory containing the solution with the pdb files.</summary>
    [Argument(Format = "{value}", Position = 1)] public string SolutionDirectory => Get<string>(() => SolutionDirectory);
    /// <summary>Url to remote git repository.</summary>
    [Argument(Format = "-u {value}")] public string RepositoryUrl => Get<string>(() => RepositoryUrl);
    /// <summary>Solution file name.</summary>
    [Argument(Format = "-f {value}")] public string File => Get<string>(() => File);
    /// <summary>Name of the configuration, default value is 'Release'.</summary>
    [Argument(Format = "-c {value}")] public string Configuration => Get<string>(() => Configuration);
    /// <summary>Name of the platform, default value is 'AnyCPU'.</summary>
    [Argument(Format = "-p {value}")] public string Platform => Get<string>(() => Platform);
    /// <summary>Name of the branch to use on the remote repository.</summary>
    [Argument(Format = "-b {value}")] public string BranchName => Get<string>(() => BranchName);
    /// <summary>The log file to write to.</summary>
    [Argument(Format = "-l {value}")] public string LogFile => Get<string>(() => LogFile);
    /// <summary>The SHA-1 hash of the commit.</summary>
    [Argument(Format = "-s {value}")] public string CommitSha => Get<string>(() => CommitSha);
    /// <summary>The directory where pdb files exists, default value is the normal project output directory.</summary>
    [Argument(Format = "-d {value}")] public string PdbDirectory => Get<string>(() => PdbDirectory);
    /// <summary>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</summary>
    [Argument(Format = "-powershell")] public bool? UsePowershell => Get<bool?>(() => UsePowershell);
    /// <summary>Don't fail on errors, but treat them as warnings instead.</summary>
    [Argument(Format = "-errorsaswarnings")] public bool? ErrorsAsWarnings => Get<bool?>(() => ErrorsAsWarnings);
    /// <summary>Skip pdb verification in case it causes issues (it's a formality anyway)</summary>
    [Argument(Format = "-skipverify")] public bool? SkipVerification => Get<bool?>(() => SkipVerification);
    /// <summary>Enables debug mode with special dumps of msbuild.</summary>
    [Argument(Format = "-debug")] public bool? Debug => Get<bool?>(() => Debug);
}
#endregion
#region GitLink3Settings
/// <summary>Used within <see cref="GitLinkTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitLink3Settings>))]
[Command(Type = typeof(GitLinkTasks), Command = nameof(GitLinkTasks.GitLink3))]
public partial class GitLink3Settings : ToolOptions
{
    /// <summary>The PDB to add source indexing to.</summary>
    [Argument(Format = "{value}", Position = 1)] public string PdbFile => Get<string>(() => PdbFile);
    /// <summary>The method for SRCSRV to retrieve source code. One of &lt;Http|Powershell&gt;. Default is Http.</summary>
    [Argument(Format = "--method {value}")] public GitLinkSourceCodeRetrieval Method => Get<GitLinkSourceCodeRetrieval>(() => Method);
    /// <summary>Url to remote git repository.</summary>
    [Argument(Format = "--url {value}")] public string RepositoryUrl => Get<string>(() => RepositoryUrl);
    /// <summary>The git ref to assume all the source code belongs to.</summary>
    [Argument(Format = "--commit {value}")] public string CommitSha => Get<string>(() => CommitSha);
    /// <summary>The path to the root of the git repo.</summary>
    [Argument(Format = "--baseDir {value}")] public string BaseDirectory => Get<string>(() => BaseDirectory);
    /// <summary>Skip verification that all source files are available in source control.</summary>
    [Argument(Format = "--skipVerify")] public bool? SkipVerification => Get<bool?>(() => SkipVerification);
}
#endregion
#region GitLink2SettingsExtensions
/// <summary>Used within <see cref="GitLinkTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class GitLink2SettingsExtensions
{
    #region SolutionDirectory
    /// <inheritdoc cref="GitLink2Settings.SolutionDirectory"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.SolutionDirectory))]
    public static T SetSolutionDirectory<T>(this T o, string v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.SolutionDirectory, v));
    /// <inheritdoc cref="GitLink2Settings.SolutionDirectory"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.SolutionDirectory))]
    public static T ResetSolutionDirectory<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.SolutionDirectory));
    #endregion
    #region RepositoryUrl
    /// <inheritdoc cref="GitLink2Settings.RepositoryUrl"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.RepositoryUrl))]
    public static T SetRepositoryUrl<T>(this T o, string v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.RepositoryUrl, v));
    /// <inheritdoc cref="GitLink2Settings.RepositoryUrl"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.RepositoryUrl))]
    public static T ResetRepositoryUrl<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.RepositoryUrl));
    #endregion
    #region File
    /// <inheritdoc cref="GitLink2Settings.File"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.File))]
    public static T SetFile<T>(this T o, string v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.File, v));
    /// <inheritdoc cref="GitLink2Settings.File"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.File))]
    public static T ResetFile<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.File));
    #endregion
    #region Configuration
    /// <inheritdoc cref="GitLink2Settings.Configuration"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.Configuration))]
    public static T SetConfiguration<T>(this T o, string v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.Configuration, v));
    /// <inheritdoc cref="GitLink2Settings.Configuration"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.Configuration))]
    public static T ResetConfiguration<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.Configuration));
    #endregion
    #region Platform
    /// <inheritdoc cref="GitLink2Settings.Platform"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.Platform))]
    public static T SetPlatform<T>(this T o, string v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.Platform, v));
    /// <inheritdoc cref="GitLink2Settings.Platform"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.Platform))]
    public static T ResetPlatform<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.Platform));
    #endregion
    #region BranchName
    /// <inheritdoc cref="GitLink2Settings.BranchName"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.BranchName))]
    public static T SetBranchName<T>(this T o, string v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.BranchName, v));
    /// <inheritdoc cref="GitLink2Settings.BranchName"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.BranchName))]
    public static T ResetBranchName<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.BranchName));
    #endregion
    #region LogFile
    /// <inheritdoc cref="GitLink2Settings.LogFile"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="GitLink2Settings.LogFile"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
    #region CommitSha
    /// <inheritdoc cref="GitLink2Settings.CommitSha"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.CommitSha))]
    public static T SetCommitSha<T>(this T o, string v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.CommitSha, v));
    /// <inheritdoc cref="GitLink2Settings.CommitSha"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.CommitSha))]
    public static T ResetCommitSha<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.CommitSha));
    #endregion
    #region PdbDirectory
    /// <inheritdoc cref="GitLink2Settings.PdbDirectory"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.PdbDirectory))]
    public static T SetPdbDirectory<T>(this T o, string v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.PdbDirectory, v));
    /// <inheritdoc cref="GitLink2Settings.PdbDirectory"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.PdbDirectory))]
    public static T ResetPdbDirectory<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.PdbDirectory));
    #endregion
    #region UsePowershell
    /// <inheritdoc cref="GitLink2Settings.UsePowershell"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.UsePowershell))]
    public static T SetUsePowershell<T>(this T o, bool? v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.UsePowershell, v));
    /// <inheritdoc cref="GitLink2Settings.UsePowershell"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.UsePowershell))]
    public static T ResetUsePowershell<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.UsePowershell));
    /// <inheritdoc cref="GitLink2Settings.UsePowershell"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.UsePowershell))]
    public static T EnableUsePowershell<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.UsePowershell, true));
    /// <inheritdoc cref="GitLink2Settings.UsePowershell"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.UsePowershell))]
    public static T DisableUsePowershell<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.UsePowershell, false));
    /// <inheritdoc cref="GitLink2Settings.UsePowershell"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.UsePowershell))]
    public static T ToggleUsePowershell<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.UsePowershell, !o.UsePowershell));
    #endregion
    #region ErrorsAsWarnings
    /// <inheritdoc cref="GitLink2Settings.ErrorsAsWarnings"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.ErrorsAsWarnings))]
    public static T SetErrorsAsWarnings<T>(this T o, bool? v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.ErrorsAsWarnings, v));
    /// <inheritdoc cref="GitLink2Settings.ErrorsAsWarnings"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.ErrorsAsWarnings))]
    public static T ResetErrorsAsWarnings<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.ErrorsAsWarnings));
    /// <inheritdoc cref="GitLink2Settings.ErrorsAsWarnings"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.ErrorsAsWarnings))]
    public static T EnableErrorsAsWarnings<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.ErrorsAsWarnings, true));
    /// <inheritdoc cref="GitLink2Settings.ErrorsAsWarnings"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.ErrorsAsWarnings))]
    public static T DisableErrorsAsWarnings<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.ErrorsAsWarnings, false));
    /// <inheritdoc cref="GitLink2Settings.ErrorsAsWarnings"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.ErrorsAsWarnings))]
    public static T ToggleErrorsAsWarnings<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.ErrorsAsWarnings, !o.ErrorsAsWarnings));
    #endregion
    #region SkipVerification
    /// <inheritdoc cref="GitLink2Settings.SkipVerification"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.SkipVerification))]
    public static T SetSkipVerification<T>(this T o, bool? v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.SkipVerification, v));
    /// <inheritdoc cref="GitLink2Settings.SkipVerification"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.SkipVerification))]
    public static T ResetSkipVerification<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.SkipVerification));
    /// <inheritdoc cref="GitLink2Settings.SkipVerification"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.SkipVerification))]
    public static T EnableSkipVerification<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.SkipVerification, true));
    /// <inheritdoc cref="GitLink2Settings.SkipVerification"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.SkipVerification))]
    public static T DisableSkipVerification<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.SkipVerification, false));
    /// <inheritdoc cref="GitLink2Settings.SkipVerification"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.SkipVerification))]
    public static T ToggleSkipVerification<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.SkipVerification, !o.SkipVerification));
    #endregion
    #region Debug
    /// <inheritdoc cref="GitLink2Settings.Debug"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="GitLink2Settings.Debug"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.Debug))]
    public static T ResetDebug<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="GitLink2Settings.Debug"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.Debug))]
    public static T EnableDebug<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="GitLink2Settings.Debug"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.Debug))]
    public static T DisableDebug<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="GitLink2Settings.Debug"/>
    [Pure] [Builder(Type = typeof(GitLink2Settings), Property = nameof(GitLink2Settings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : GitLink2Settings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
}
#endregion
#region GitLink3SettingsExtensions
/// <summary>Used within <see cref="GitLinkTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class GitLink3SettingsExtensions
{
    #region PdbFile
    /// <inheritdoc cref="GitLink3Settings.PdbFile"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.PdbFile))]
    public static T SetPdbFile<T>(this T o, string v) where T : GitLink3Settings => o.Modify(b => b.Set(() => o.PdbFile, v));
    /// <inheritdoc cref="GitLink3Settings.PdbFile"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.PdbFile))]
    public static T ResetPdbFile<T>(this T o) where T : GitLink3Settings => o.Modify(b => b.Remove(() => o.PdbFile));
    #endregion
    #region Method
    /// <inheritdoc cref="GitLink3Settings.Method"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.Method))]
    public static T SetMethod<T>(this T o, GitLinkSourceCodeRetrieval v) where T : GitLink3Settings => o.Modify(b => b.Set(() => o.Method, v));
    /// <inheritdoc cref="GitLink3Settings.Method"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.Method))]
    public static T ResetMethod<T>(this T o) where T : GitLink3Settings => o.Modify(b => b.Remove(() => o.Method));
    #endregion
    #region RepositoryUrl
    /// <inheritdoc cref="GitLink3Settings.RepositoryUrl"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.RepositoryUrl))]
    public static T SetRepositoryUrl<T>(this T o, string v) where T : GitLink3Settings => o.Modify(b => b.Set(() => o.RepositoryUrl, v));
    /// <inheritdoc cref="GitLink3Settings.RepositoryUrl"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.RepositoryUrl))]
    public static T ResetRepositoryUrl<T>(this T o) where T : GitLink3Settings => o.Modify(b => b.Remove(() => o.RepositoryUrl));
    #endregion
    #region CommitSha
    /// <inheritdoc cref="GitLink3Settings.CommitSha"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.CommitSha))]
    public static T SetCommitSha<T>(this T o, string v) where T : GitLink3Settings => o.Modify(b => b.Set(() => o.CommitSha, v));
    /// <inheritdoc cref="GitLink3Settings.CommitSha"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.CommitSha))]
    public static T ResetCommitSha<T>(this T o) where T : GitLink3Settings => o.Modify(b => b.Remove(() => o.CommitSha));
    #endregion
    #region BaseDirectory
    /// <inheritdoc cref="GitLink3Settings.BaseDirectory"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.BaseDirectory))]
    public static T SetBaseDirectory<T>(this T o, string v) where T : GitLink3Settings => o.Modify(b => b.Set(() => o.BaseDirectory, v));
    /// <inheritdoc cref="GitLink3Settings.BaseDirectory"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.BaseDirectory))]
    public static T ResetBaseDirectory<T>(this T o) where T : GitLink3Settings => o.Modify(b => b.Remove(() => o.BaseDirectory));
    #endregion
    #region SkipVerification
    /// <inheritdoc cref="GitLink3Settings.SkipVerification"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.SkipVerification))]
    public static T SetSkipVerification<T>(this T o, bool? v) where T : GitLink3Settings => o.Modify(b => b.Set(() => o.SkipVerification, v));
    /// <inheritdoc cref="GitLink3Settings.SkipVerification"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.SkipVerification))]
    public static T ResetSkipVerification<T>(this T o) where T : GitLink3Settings => o.Modify(b => b.Remove(() => o.SkipVerification));
    /// <inheritdoc cref="GitLink3Settings.SkipVerification"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.SkipVerification))]
    public static T EnableSkipVerification<T>(this T o) where T : GitLink3Settings => o.Modify(b => b.Set(() => o.SkipVerification, true));
    /// <inheritdoc cref="GitLink3Settings.SkipVerification"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.SkipVerification))]
    public static T DisableSkipVerification<T>(this T o) where T : GitLink3Settings => o.Modify(b => b.Set(() => o.SkipVerification, false));
    /// <inheritdoc cref="GitLink3Settings.SkipVerification"/>
    [Pure] [Builder(Type = typeof(GitLink3Settings), Property = nameof(GitLink3Settings.SkipVerification))]
    public static T ToggleSkipVerification<T>(this T o) where T : GitLink3Settings => o.Modify(b => b.Set(() => o.SkipVerification, !o.SkipVerification));
    #endregion
}
#endregion
#region GitLinkSourceCodeRetrieval
/// <summary>Used within <see cref="GitLinkTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitLinkSourceCodeRetrieval>))]
public partial class GitLinkSourceCodeRetrieval : Enumeration
{
    public static GitLinkSourceCodeRetrieval Http = (GitLinkSourceCodeRetrieval) "Http";
    public static GitLinkSourceCodeRetrieval Powershell = (GitLinkSourceCodeRetrieval) "Powershell";
    public static implicit operator GitLinkSourceCodeRetrieval(string value)
    {
        return new GitLinkSourceCodeRetrieval { Value = value };
    }
}
#endregion
