// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated from https://github.com/nuke-build/tools/blob/master/GitLink3.json with Nuke.ToolGenerator.

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

[assembly: IconClass(typeof(Nuke.Common.Tools.GitLink3.GitLink3Tasks), "link")]

namespace Nuke.Common.Tools.GitLink3
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitLink3Tasks
    {
        static partial void PreProcess (GitLink3Settings toolSettings);
        static partial void PostProcess (GitLink3Settings toolSettings);
        /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p><p>For more details, visit the <a href="https://github.com/GitTools/GitLink/">official website</a>.</p></summary>
        public static void GitLink3 (Configure<GitLink3Settings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new GitLink3Settings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
    }
    #region GitLink3Settings
    /// <summary><p>Used within <see cref="GitLink3Tasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitLink3Settings : ToolSettings
    {
        /// <summary><p>Path to the GitLink3 executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetPackageExecutable($"gitlink", $"GitLink.exe");
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
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("{value}", PdbFile)
              .Add("--method {value}", Method)
              .Add("--url {value}", RepositoryUrl)
              .Add("--commit {value}", CommitSha)
              .Add("--baseDir {value}", BaseDirectory)
              .Add("--skipVerify", SkipVerification);
        }
    }
    #endregion
    #region GitLink3SettingsExtensions
    /// <summary><p>Used within <see cref="GitLink3Tasks"/>.</p></summary>
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
    /// <summary><p>Used within <see cref="GitLink3Tasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class GitLinkSourceCodeRetrieval : Enumeration
    {
        public static GitLinkSourceCodeRetrieval Http = new GitLinkSourceCodeRetrieval { Value = "Http" };
        public static GitLinkSourceCodeRetrieval Powershell = new GitLinkSourceCodeRetrieval { Value = "Powershell" };
    }
    #endregion
}
