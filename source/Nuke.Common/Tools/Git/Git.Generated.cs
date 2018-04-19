// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, LOCAL VERSION.
// Generated from https://github.com/nuke-build/tools/blob/master/metadata/Git.json.

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

namespace Nuke.Common.Tools.Git
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitTasks
    {
        /// <summary><p>Path to the Git executable.</p></summary>
        public static string GitPath => ToolPathResolver.GetPathExecutable("git");
        static partial void PreProcess(GitSettings toolSettings);
        static partial void PostProcess(GitSettings toolSettings);
        /// <summary><p>Git is a <a href="https://git-scm.com/about/free-and-open-source">free and open source</a> distributed version control system designed to handle everything from small to very large projects with speed and efficiency. Git is <a href="https://git-scm.com/documentation">easy to learn</a> and has a <a href="https://git-scm.com/about/small-and-fast">tiny footprint with lightning fast performance</a>. It outclasses SCM tools like Subversion, CVS, Perforce, and ClearCase with features like <a href="https://git-scm.com/about/branching-and-merging">cheap local branching</a>, convenient <a href="https://git-scm.com/about/staging-area">staging areas</a>, and <a href="https://git-scm.com/about/distributed">multiple workflows</a>.</p><p>For more details, visit the <a href="https://git-scm.com/">official website</a>.</p></summary>
        public static void Git(Configure<GitSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new GitSettings());
            PreProcess(toolSettings);
            var process = StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>Git is a <a href="https://git-scm.com/about/free-and-open-source">free and open source</a> distributed version control system designed to handle everything from small to very large projects with speed and efficiency. Git is <a href="https://git-scm.com/documentation">easy to learn</a> and has a <a href="https://git-scm.com/about/small-and-fast">tiny footprint with lightning fast performance</a>. It outclasses SCM tools like Subversion, CVS, Perforce, and ClearCase with features like <a href="https://git-scm.com/about/branching-and-merging">cheap local branching</a>, convenient <a href="https://git-scm.com/about/staging-area">staging areas</a>, and <a href="https://git-scm.com/about/distributed">multiple workflows</a>.</p><p>For more details, visit the <a href="https://git-scm.com/">official website</a>.</p></summary>
        public static void Git(string arguments, Configure<GitSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            Git(x => configurator(x).SetArguments(arguments));
        }
    }
    #region GitSettings
    /// <summary><p>Used within <see cref="GitTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitSettings : ToolSettings
    {
        /// <summary><p>Path to the Git executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GitTasks.GitPath;
        public virtual string Arguments { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", Arguments);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region GitSettingsExtensions
    /// <summary><p>Used within <see cref="GitTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitSettingsExtensions
    {
        #region Arguments
        /// <summary><p><em>Sets <see cref="GitSettings.Arguments"/>.</em></p></summary>
        [Pure]
        public static GitSettings SetArguments(this GitSettings toolSettings, string arguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Arguments = arguments;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitSettings.Arguments"/>.</em></p></summary>
        [Pure]
        public static GitSettings ResetArguments(this GitSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Arguments = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
