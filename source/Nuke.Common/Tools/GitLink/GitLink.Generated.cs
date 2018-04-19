// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, LOCAL VERSION.
// Generated from https://github.com/nuke-build/tools/blob/master/metadata/GitLink.json.

using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
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
    public static partial class GitLinkTasks
    {
        /// <summary><p>Path to the GitLink executable.</p></summary>
        public static string GitLinkPath => ToolPathResolver.GetPackageExecutable("gitlink", "GitLink.exe");
        static partial void PreProcess(GitLink2Settings toolSettings);
        static partial void PostProcess(GitLink2Settings toolSettings);
        /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
        public static void GitLink2(Configure<GitLink2Settings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new GitLink2Settings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(GitLink3Settings toolSettings);
        static partial void PostProcess(GitLink3Settings toolSettings);
        /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
        public static void GitLink3(Configure<GitLink3Settings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new GitLink3Settings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
    }
    #region GitLink2Settings
    /// <summary><p>Used within <see cref="GitLinkTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitLink2Settings : ToolSettings
    {
        /// <summary><p>Path to the GitLink executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GitLinkTasks.GitLinkPath;
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
        public virtual bool? UsePowershell { get; internal set; }
        /// <summary><p>Don't fail on errors, but treat them as warnings instead.</p></summary>
        public virtual bool? ErrorsAsWarnings { get; internal set; }
        /// <summary><p>Skip pdb verification in case it causes issues (it's a formality anyway)</p></summary>
        public virtual bool? SkipVerification { get; internal set; }
        /// <summary><p>Enables debug mode with special dumps of msbuild.</p></summary>
        public virtual bool? Debug { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
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
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region GitLink3Settings
    /// <summary><p>Used within <see cref="GitLinkTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitLink3Settings : ToolSettings
    {
        /// <summary><p>Path to the GitLink executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GitLinkTasks.GitLinkPath;
        /// <summary><p>The PDB to add source indexing to.</p></summary>
        public virtual string PdbFile { get; internal set; }
        /// <summary><p>The method for SRCSRV to retrieve source code. One of &lt;Http|Powershell&gt;. Default is Http.</p></summary>
        public virtual GitLinkSourceCodeRetrieval Method { get; internal set; }
        /// <summary><p>Url to remote git repository.</p></summary>
        public virtual string RepositoryUrl { get; internal set; }
        /// <summary><p>The git ref to assume all the source code belongs to.</p></summary>
        public virtual string CommitSha { get; internal set; }
        /// <summary><p>The path to the root of the git repo.</p></summary>
        public virtual string BaseDirectory { get; internal set; }
        /// <summary><p>Skip verification that all source files are available in source control.</p></summary>
        public virtual bool? SkipVerification { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", PdbFile)
              .Add("--method {value}", Method)
              .Add("--url {value}", RepositoryUrl)
              .Add("--commit {value}", CommitSha)
              .Add("--baseDir {value}", BaseDirectory)
              .Add("--skipVerify", SkipVerification);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region GitLink2SettingsExtensions
    /// <summary><p>Used within <see cref="GitLinkTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitLink2SettingsExtensions
    {
        #region SolutionDirectory
        /// <summary><p><em>Sets <see cref="GitLink2Settings.SolutionDirectory"/>.</em></p><p>The directory containing the solution with the pdb files.</p></summary>
        [Pure]
        public static GitLink2Settings SetSolutionDirectory(this GitLink2Settings toolSettings, string solutionDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionDirectory = solutionDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.SolutionDirectory"/>.</em></p><p>The directory containing the solution with the pdb files.</p></summary>
        [Pure]
        public static GitLink2Settings ResetSolutionDirectory(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionDirectory = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryUrl
        /// <summary><p><em>Sets <see cref="GitLink2Settings.RepositoryUrl"/>.</em></p><p>Url to remote git repository.</p></summary>
        [Pure]
        public static GitLink2Settings SetRepositoryUrl(this GitLink2Settings toolSettings, string repositoryUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryUrl = repositoryUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.RepositoryUrl"/>.</em></p><p>Url to remote git repository.</p></summary>
        [Pure]
        public static GitLink2Settings ResetRepositoryUrl(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryUrl = null;
            return toolSettings;
        }
        #endregion
        #region File
        /// <summary><p><em>Sets <see cref="GitLink2Settings.File"/>.</em></p><p>Solution file name.</p></summary>
        [Pure]
        public static GitLink2Settings SetFile(this GitLink2Settings toolSettings, string file)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.File"/>.</em></p><p>Solution file name.</p></summary>
        [Pure]
        public static GitLink2Settings ResetFile(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary><p><em>Sets <see cref="GitLink2Settings.Configuration"/>.</em></p><p>Name of the configuration, default value is 'Release'.</p></summary>
        [Pure]
        public static GitLink2Settings SetConfiguration(this GitLink2Settings toolSettings, string configuration)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.Configuration"/>.</em></p><p>Name of the configuration, default value is 'Release'.</p></summary>
        [Pure]
        public static GitLink2Settings ResetConfiguration(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region Platform
        /// <summary><p><em>Sets <see cref="GitLink2Settings.Platform"/>.</em></p><p>Name of the platform, default value is 'AnyCPU'.</p></summary>
        [Pure]
        public static GitLink2Settings SetPlatform(this GitLink2Settings toolSettings, string platform)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Platform = platform;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.Platform"/>.</em></p><p>Name of the platform, default value is 'AnyCPU'.</p></summary>
        [Pure]
        public static GitLink2Settings ResetPlatform(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Platform = null;
            return toolSettings;
        }
        #endregion
        #region BranchName
        /// <summary><p><em>Sets <see cref="GitLink2Settings.BranchName"/>.</em></p><p>Name of the branch to use on the remote repository.</p></summary>
        [Pure]
        public static GitLink2Settings SetBranchName(this GitLink2Settings toolSettings, string branchName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BranchName = branchName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.BranchName"/>.</em></p><p>Name of the branch to use on the remote repository.</p></summary>
        [Pure]
        public static GitLink2Settings ResetBranchName(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BranchName = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary><p><em>Sets <see cref="GitLink2Settings.LogFile"/>.</em></p><p>The log file to write to.</p></summary>
        [Pure]
        public static GitLink2Settings SetLogFile(this GitLink2Settings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.LogFile"/>.</em></p><p>The log file to write to.</p></summary>
        [Pure]
        public static GitLink2Settings ResetLogFile(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region CommitSha
        /// <summary><p><em>Sets <see cref="GitLink2Settings.CommitSha"/>.</em></p><p>The SHA-1 hash of the commit.</p></summary>
        [Pure]
        public static GitLink2Settings SetCommitSha(this GitLink2Settings toolSettings, string commitSha)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitSha = commitSha;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.CommitSha"/>.</em></p><p>The SHA-1 hash of the commit.</p></summary>
        [Pure]
        public static GitLink2Settings ResetCommitSha(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitSha = null;
            return toolSettings;
        }
        #endregion
        #region PdbDirectory
        /// <summary><p><em>Sets <see cref="GitLink2Settings.PdbDirectory"/>.</em></p><p>The directory where pdb files exists, default value is the normal project output directory.</p></summary>
        [Pure]
        public static GitLink2Settings SetPdbDirectory(this GitLink2Settings toolSettings, string pdbDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdbDirectory = pdbDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.PdbDirectory"/>.</em></p><p>The directory where pdb files exists, default value is the normal project output directory.</p></summary>
        [Pure]
        public static GitLink2Settings ResetPdbDirectory(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdbDirectory = null;
            return toolSettings;
        }
        #endregion
        #region UsePowershell
        /// <summary><p><em>Sets <see cref="GitLink2Settings.UsePowershell"/>.</em></p><p>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</p></summary>
        [Pure]
        public static GitLink2Settings SetUsePowershell(this GitLink2Settings toolSettings, bool? usePowershell)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UsePowershell = usePowershell;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.UsePowershell"/>.</em></p><p>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</p></summary>
        [Pure]
        public static GitLink2Settings ResetUsePowershell(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UsePowershell = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitLink2Settings.UsePowershell"/>.</em></p><p>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</p></summary>
        [Pure]
        public static GitLink2Settings EnableUsePowershell(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UsePowershell = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitLink2Settings.UsePowershell"/>.</em></p><p>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</p></summary>
        [Pure]
        public static GitLink2Settings DisableUsePowershell(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UsePowershell = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitLink2Settings.UsePowershell"/>.</em></p><p>Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead.</p></summary>
        [Pure]
        public static GitLink2Settings ToggleUsePowershell(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UsePowershell = !toolSettings.UsePowershell;
            return toolSettings;
        }
        #endregion
        #region ErrorsAsWarnings
        /// <summary><p><em>Sets <see cref="GitLink2Settings.ErrorsAsWarnings"/>.</em></p><p>Don't fail on errors, but treat them as warnings instead.</p></summary>
        [Pure]
        public static GitLink2Settings SetErrorsAsWarnings(this GitLink2Settings toolSettings, bool? errorsAsWarnings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorsAsWarnings = errorsAsWarnings;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.ErrorsAsWarnings"/>.</em></p><p>Don't fail on errors, but treat them as warnings instead.</p></summary>
        [Pure]
        public static GitLink2Settings ResetErrorsAsWarnings(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorsAsWarnings = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitLink2Settings.ErrorsAsWarnings"/>.</em></p><p>Don't fail on errors, but treat them as warnings instead.</p></summary>
        [Pure]
        public static GitLink2Settings EnableErrorsAsWarnings(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorsAsWarnings = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitLink2Settings.ErrorsAsWarnings"/>.</em></p><p>Don't fail on errors, but treat them as warnings instead.</p></summary>
        [Pure]
        public static GitLink2Settings DisableErrorsAsWarnings(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorsAsWarnings = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitLink2Settings.ErrorsAsWarnings"/>.</em></p><p>Don't fail on errors, but treat them as warnings instead.</p></summary>
        [Pure]
        public static GitLink2Settings ToggleErrorsAsWarnings(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ErrorsAsWarnings = !toolSettings.ErrorsAsWarnings;
            return toolSettings;
        }
        #endregion
        #region SkipVerification
        /// <summary><p><em>Sets <see cref="GitLink2Settings.SkipVerification"/>.</em></p><p>Skip pdb verification in case it causes issues (it's a formality anyway)</p></summary>
        [Pure]
        public static GitLink2Settings SetSkipVerification(this GitLink2Settings toolSettings, bool? skipVerification)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = skipVerification;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.SkipVerification"/>.</em></p><p>Skip pdb verification in case it causes issues (it's a formality anyway)</p></summary>
        [Pure]
        public static GitLink2Settings ResetSkipVerification(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitLink2Settings.SkipVerification"/>.</em></p><p>Skip pdb verification in case it causes issues (it's a formality anyway)</p></summary>
        [Pure]
        public static GitLink2Settings EnableSkipVerification(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitLink2Settings.SkipVerification"/>.</em></p><p>Skip pdb verification in case it causes issues (it's a formality anyway)</p></summary>
        [Pure]
        public static GitLink2Settings DisableSkipVerification(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitLink2Settings.SkipVerification"/>.</em></p><p>Skip pdb verification in case it causes issues (it's a formality anyway)</p></summary>
        [Pure]
        public static GitLink2Settings ToggleSkipVerification(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = !toolSettings.SkipVerification;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary><p><em>Sets <see cref="GitLink2Settings.Debug"/>.</em></p><p>Enables debug mode with special dumps of msbuild.</p></summary>
        [Pure]
        public static GitLink2Settings SetDebug(this GitLink2Settings toolSettings, bool? debug)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink2Settings.Debug"/>.</em></p><p>Enables debug mode with special dumps of msbuild.</p></summary>
        [Pure]
        public static GitLink2Settings ResetDebug(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitLink2Settings.Debug"/>.</em></p><p>Enables debug mode with special dumps of msbuild.</p></summary>
        [Pure]
        public static GitLink2Settings EnableDebug(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitLink2Settings.Debug"/>.</em></p><p>Enables debug mode with special dumps of msbuild.</p></summary>
        [Pure]
        public static GitLink2Settings DisableDebug(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitLink2Settings.Debug"/>.</em></p><p>Enables debug mode with special dumps of msbuild.</p></summary>
        [Pure]
        public static GitLink2Settings ToggleDebug(this GitLink2Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region GitLink3SettingsExtensions
    /// <summary><p>Used within <see cref="GitLinkTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitLink3SettingsExtensions
    {
        #region PdbFile
        /// <summary><p><em>Sets <see cref="GitLink3Settings.PdbFile"/>.</em></p><p>The PDB to add source indexing to.</p></summary>
        [Pure]
        public static GitLink3Settings SetPdbFile(this GitLink3Settings toolSettings, string pdbFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdbFile = pdbFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink3Settings.PdbFile"/>.</em></p><p>The PDB to add source indexing to.</p></summary>
        [Pure]
        public static GitLink3Settings ResetPdbFile(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdbFile = null;
            return toolSettings;
        }
        #endregion
        #region Method
        /// <summary><p><em>Sets <see cref="GitLink3Settings.Method"/>.</em></p><p>The method for SRCSRV to retrieve source code. One of &lt;Http|Powershell&gt;. Default is Http.</p></summary>
        [Pure]
        public static GitLink3Settings SetMethod(this GitLink3Settings toolSettings, GitLinkSourceCodeRetrieval method)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Method = method;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink3Settings.Method"/>.</em></p><p>The method for SRCSRV to retrieve source code. One of &lt;Http|Powershell&gt;. Default is Http.</p></summary>
        [Pure]
        public static GitLink3Settings ResetMethod(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Method = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryUrl
        /// <summary><p><em>Sets <see cref="GitLink3Settings.RepositoryUrl"/>.</em></p><p>Url to remote git repository.</p></summary>
        [Pure]
        public static GitLink3Settings SetRepositoryUrl(this GitLink3Settings toolSettings, string repositoryUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryUrl = repositoryUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink3Settings.RepositoryUrl"/>.</em></p><p>Url to remote git repository.</p></summary>
        [Pure]
        public static GitLink3Settings ResetRepositoryUrl(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryUrl = null;
            return toolSettings;
        }
        #endregion
        #region CommitSha
        /// <summary><p><em>Sets <see cref="GitLink3Settings.CommitSha"/>.</em></p><p>The git ref to assume all the source code belongs to.</p></summary>
        [Pure]
        public static GitLink3Settings SetCommitSha(this GitLink3Settings toolSettings, string commitSha)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitSha = commitSha;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink3Settings.CommitSha"/>.</em></p><p>The git ref to assume all the source code belongs to.</p></summary>
        [Pure]
        public static GitLink3Settings ResetCommitSha(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitSha = null;
            return toolSettings;
        }
        #endregion
        #region BaseDirectory
        /// <summary><p><em>Sets <see cref="GitLink3Settings.BaseDirectory"/>.</em></p><p>The path to the root of the git repo.</p></summary>
        [Pure]
        public static GitLink3Settings SetBaseDirectory(this GitLink3Settings toolSettings, string baseDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseDirectory = baseDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink3Settings.BaseDirectory"/>.</em></p><p>The path to the root of the git repo.</p></summary>
        [Pure]
        public static GitLink3Settings ResetBaseDirectory(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseDirectory = null;
            return toolSettings;
        }
        #endregion
        #region SkipVerification
        /// <summary><p><em>Sets <see cref="GitLink3Settings.SkipVerification"/>.</em></p><p>Skip verification that all source files are available in source control.</p></summary>
        [Pure]
        public static GitLink3Settings SetSkipVerification(this GitLink3Settings toolSettings, bool? skipVerification)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = skipVerification;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitLink3Settings.SkipVerification"/>.</em></p><p>Skip verification that all source files are available in source control.</p></summary>
        [Pure]
        public static GitLink3Settings ResetSkipVerification(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitLink3Settings.SkipVerification"/>.</em></p><p>Skip verification that all source files are available in source control.</p></summary>
        [Pure]
        public static GitLink3Settings EnableSkipVerification(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitLink3Settings.SkipVerification"/>.</em></p><p>Skip verification that all source files are available in source control.</p></summary>
        [Pure]
        public static GitLink3Settings DisableSkipVerification(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitLink3Settings.SkipVerification"/>.</em></p><p>Skip verification that all source files are available in source control.</p></summary>
        [Pure]
        public static GitLink3Settings ToggleSkipVerification(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = !toolSettings.SkipVerification;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region GitLinkSourceCodeRetrieval
    /// <summary><p>Used within <see cref="GitLinkTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class GitLinkSourceCodeRetrieval : Enumeration
    {
        public static GitLinkSourceCodeRetrieval Http = new GitLinkSourceCodeRetrieval { Value = "Http" };
        public static GitLinkSourceCodeRetrieval Powershell = new GitLinkSourceCodeRetrieval { Value = "Powershell" };
    }
    #endregion
}
