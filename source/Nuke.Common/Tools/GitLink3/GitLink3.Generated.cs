// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Auto-generated with Nuke.ToolGenerator.

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
    /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitLink3Settings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"gitlink", packageExecutable: $"GitLink.exe");
        /// <summary><p>The PDB to add source indexing to.</p></summary>
        public virtual string PdbFile { get; internal set; }
        /// <summary><p>The method for SRCSRV to retrieve source code. One of &lt;Http|Powershell&gt;. Default is Http.</p></summary>
        public virtual GitLinkSourceCodeRetrieval? Method { get; internal set; }
        /// <summary><p>Url to remote git repository.</p></summary>
        public virtual string RepositoryUrl { get; internal set; }
        /// <summary><p>The git ref to assume all the source code belongs to.</p></summary>
        public virtual string CommitSha { get; internal set; }
        /// <summary><p>The path to the root of the git repo.</p></summary>
        public virtual string BaseDirectory { get; internal set; }
        /// <summary><p>Skip verification that all source files are available in source control.</p></summary>
        public virtual bool SkipVerification { get; internal set; }
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
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitLink3SettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="GitLink3Settings.PdbFile"/>.</i></p><p>The PDB to add source indexing to.</p></summary>
        [Pure]
        public static GitLink3Settings SetPdbFile(this GitLink3Settings toolSettings, string pdbFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PdbFile = pdbFile;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="GitLink3Settings.Method"/>.</i></p><p>The method for SRCSRV to retrieve source code. One of &lt;Http|Powershell&gt;. Default is Http.</p></summary>
        [Pure]
        public static GitLink3Settings SetMethod(this GitLink3Settings toolSettings, GitLinkSourceCodeRetrieval? method)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Method = method;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="GitLink3Settings.RepositoryUrl"/>.</i></p><p>Url to remote git repository.</p></summary>
        [Pure]
        public static GitLink3Settings SetRepositoryUrl(this GitLink3Settings toolSettings, string repositoryUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryUrl = repositoryUrl;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="GitLink3Settings.CommitSha"/>.</i></p><p>The git ref to assume all the source code belongs to.</p></summary>
        [Pure]
        public static GitLink3Settings SetCommitSha(this GitLink3Settings toolSettings, string commitSha)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CommitSha = commitSha;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="GitLink3Settings.BaseDirectory"/>.</i></p><p>The path to the root of the git repo.</p></summary>
        [Pure]
        public static GitLink3Settings SetBaseDirectory(this GitLink3Settings toolSettings, string baseDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseDirectory = baseDirectory;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="GitLink3Settings.SkipVerification"/>.</i></p><p>Skip verification that all source files are available in source control.</p></summary>
        [Pure]
        public static GitLink3Settings SetSkipVerification(this GitLink3Settings toolSettings, bool skipVerification)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = skipVerification;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="GitLink3Settings.SkipVerification"/>.</i></p><p>Skip verification that all source files are available in source control.</p></summary>
        [Pure]
        public static GitLink3Settings EnableSkipVerification(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = true;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="GitLink3Settings.SkipVerification"/>.</i></p><p>Skip verification that all source files are available in source control.</p></summary>
        [Pure]
        public static GitLink3Settings DisableSkipVerification(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = false;
            return toolSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="GitLink3Settings.SkipVerification"/>.</i></p><p>Skip verification that all source files are available in source control.</p></summary>
        [Pure]
        public static GitLink3Settings ToggleSkipVerification(this GitLink3Settings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipVerification = !toolSettings.SkipVerification;
            return toolSettings;
        }
    }
    /// <summary><p>GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.</p></summary>
    [PublicAPI]
    public enum GitLinkSourceCodeRetrieval
    {
        Http,
        Powershell,
    }
}
