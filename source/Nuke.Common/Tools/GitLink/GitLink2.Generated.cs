using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.GitLink
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [IconClass("link")]
    public static partial class GitLinkTasks
    {
        static partial void PreProcess (GitLink2Settings gitLink2Settings);
        static partial void PostProcess (GitLink2Settings gitLink2Settings);
        /// <summary>
        /// <p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p>
        /// <p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p>
        /// </summary>
        public static void GitLink2 (Configure<GitLink2Settings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var gitLink2Settings = new GitLink2Settings();
            gitLink2Settings = configurator(gitLink2Settings);
            PreProcess(gitLink2Settings);
            var process = ProcessManager.Instance.StartProcess(gitLink2Settings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(gitLink2Settings);
        }
    }
    /// <summary>
    /// <p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p>
    /// <p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitLink2Settings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? NuGetPackageResolver.GetToolPath($"gitlink", $"GitLink.exe");
        /// <summary><p>The directory containing the solution with the pdb files.</p></summary>
        public virtual string SolutionDirectory { get; internal set; }
        /// <summary><p>Url to remote git repository.</p></summary>
        public virtual string RepositoryUrl { get; internal set; }
        /// <summary><p>Solution file name.</p></summary>
        public virtual string File { get; internal set; }
        /// <summary><p>Name of the configuration, default value is 'Release'.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Name of the platform, default value is 'AnyCPU'.</p></summary>
        public virtual string Platform { get; internal set; }
        /// <summary><p>Name of the branch to use on the remote repository.</p></summary>
        public virtual string BranchName { get; internal set; }
        /// <summary><p>The log file to write to.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>The SHA-1 hash of the commit.</p></summary>
        public virtual string CommitSha { get; internal set; }
        /// <summary><p>The directory where pdb files exists, default value is the normal project output directory.</p></summary>
        public virtual string PdbDirectory { get; internal set; }
        /// <summary><p>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</p></summary>
        public virtual bool UsePowershell { get; internal set; }
        /// <summary><p>Don't fail on errors, but treat them as warnings instead.</p></summary>
        public virtual bool ErrorsAsWarnings { get; internal set; }
        /// <summary><p>Skip pdb verification in case it causes issues (it's a formality anyway)</p></summary>
        public virtual bool SkipVerification { get; internal set; }
        /// <summary><p>Enables debug mode with special dumps of msbuild.</p></summary>
        public virtual bool Debug { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("{value}", SolutionDirectory)
              .Add("-u {value}", RepositoryUrl)
              .Add("-f {value}", File)
              .Add("-c {value}", Configuration)
              .Add("-p {value}", Platform)
              .Add("-b {value}", BranchName)
              .Add("-l {value}", LogFile)
              .Add("-s {value}", CommitSha)
              .Add("-d {value}", PdbDirectory)
              .Add("-powershell", UsePowershell)
              .Add("-errorsaswarnings", ErrorsAsWarnings)
              .Add("-skipverify", SkipVerification)
              .Add("-debug", Debug);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitLink2SettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.SolutionDirectory"/>.</i></p>
        /// <p>The directory containing the solution with the pdb files.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetSolutionDirectory(this GitLink2Settings gitLink2Settings, string solutionDirectory)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.SolutionDirectory = solutionDirectory;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.RepositoryUrl"/>.</i></p>
        /// <p>Url to remote git repository.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetRepositoryUrl(this GitLink2Settings gitLink2Settings, string repositoryUrl)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.RepositoryUrl = repositoryUrl;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.File"/>.</i></p>
        /// <p>Solution file name.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetFile(this GitLink2Settings gitLink2Settings, string file)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.File = file;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.Configuration"/>.</i></p>
        /// <p>Name of the configuration, default value is 'Release'.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetConfiguration(this GitLink2Settings gitLink2Settings, string configuration)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.Configuration = configuration;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.Platform"/>.</i></p>
        /// <p>Name of the platform, default value is 'AnyCPU'.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetPlatform(this GitLink2Settings gitLink2Settings, string platform)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.Platform = platform;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.BranchName"/>.</i></p>
        /// <p>Name of the branch to use on the remote repository.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetBranchName(this GitLink2Settings gitLink2Settings, string branchName)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.BranchName = branchName;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.LogFile"/>.</i></p>
        /// <p>The log file to write to.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetLogFile(this GitLink2Settings gitLink2Settings, string logFile)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.LogFile = logFile;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.CommitSha"/>.</i></p>
        /// <p>The SHA-1 hash of the commit.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetCommitSha(this GitLink2Settings gitLink2Settings, string commitSha)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.CommitSha = commitSha;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.PdbDirectory"/>.</i></p>
        /// <p>The directory where pdb files exists, default value is the normal project output directory.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetPdbDirectory(this GitLink2Settings gitLink2Settings, string pdbDirectory)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.PdbDirectory = pdbDirectory;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.UsePowershell"/>.</i></p>
        /// <p>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetUsePowershell(this GitLink2Settings gitLink2Settings, bool usePowershell)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.UsePowershell = usePowershell;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="GitLink2Settings.UsePowershell"/>.</i></p>
        /// <p>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings EnableUsePowershell(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.UsePowershell = true;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="GitLink2Settings.UsePowershell"/>.</i></p>
        /// <p>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings DisableUsePowershell(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.UsePowershell = false;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="GitLink2Settings.UsePowershell"/>.</i></p>
        /// <p>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings ToggleUsePowershell(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.UsePowershell = !gitLink2Settings.UsePowershell;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.ErrorsAsWarnings"/>.</i></p>
        /// <p>Don't fail on errors, but treat them as warnings instead.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetErrorsAsWarnings(this GitLink2Settings gitLink2Settings, bool errorsAsWarnings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.ErrorsAsWarnings = errorsAsWarnings;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="GitLink2Settings.ErrorsAsWarnings"/>.</i></p>
        /// <p>Don't fail on errors, but treat them as warnings instead.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings EnableErrorsAsWarnings(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.ErrorsAsWarnings = true;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="GitLink2Settings.ErrorsAsWarnings"/>.</i></p>
        /// <p>Don't fail on errors, but treat them as warnings instead.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings DisableErrorsAsWarnings(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.ErrorsAsWarnings = false;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="GitLink2Settings.ErrorsAsWarnings"/>.</i></p>
        /// <p>Don't fail on errors, but treat them as warnings instead.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings ToggleErrorsAsWarnings(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.ErrorsAsWarnings = !gitLink2Settings.ErrorsAsWarnings;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.SkipVerification"/>.</i></p>
        /// <p>Skip pdb verification in case it causes issues (it's a formality anyway)</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetSkipVerification(this GitLink2Settings gitLink2Settings, bool skipVerification)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.SkipVerification = skipVerification;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="GitLink2Settings.SkipVerification"/>.</i></p>
        /// <p>Skip pdb verification in case it causes issues (it's a formality anyway)</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings EnableSkipVerification(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.SkipVerification = true;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="GitLink2Settings.SkipVerification"/>.</i></p>
        /// <p>Skip pdb verification in case it causes issues (it's a formality anyway)</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings DisableSkipVerification(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.SkipVerification = false;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="GitLink2Settings.SkipVerification"/>.</i></p>
        /// <p>Skip pdb verification in case it causes issues (it's a formality anyway)</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings ToggleSkipVerification(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.SkipVerification = !gitLink2Settings.SkipVerification;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="GitLink2Settings.Debug"/>.</i></p>
        /// <p>Enables debug mode with special dumps of msbuild.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings SetDebug(this GitLink2Settings gitLink2Settings, bool debug)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.Debug = debug;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="GitLink2Settings.Debug"/>.</i></p>
        /// <p>Enables debug mode with special dumps of msbuild.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings EnableDebug(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.Debug = true;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="GitLink2Settings.Debug"/>.</i></p>
        /// <p>Enables debug mode with special dumps of msbuild.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings DisableDebug(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.Debug = false;
            return gitLink2Settings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="GitLink2Settings.Debug"/>.</i></p>
        /// <p>Enables debug mode with special dumps of msbuild.</p>
        /// </summary>
        [Pure]
        public static GitLink2Settings ToggleDebug(this GitLink2Settings gitLink2Settings)
        {
            gitLink2Settings = gitLink2Settings.NewInstance();
            gitLink2Settings.Debug = !gitLink2Settings.Debug;
            return gitLink2Settings;
        }
    }
}
