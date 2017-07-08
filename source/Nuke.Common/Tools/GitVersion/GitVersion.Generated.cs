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

[assembly: IconClass(typeof(Nuke.Common.Tools.GitVersion.GitVersionTasks), "podium")]

namespace Nuke.Common.Tools.GitVersion
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitVersionTasks
    {
        static partial void PreProcess (GitVersionSettings gitVersionSettings);
        static partial void PostProcess (GitVersionSettings gitVersionSettings);
        /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p><p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p></summary>
        public static void GitVersion (Configure<GitVersionSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var gitVersionSettings = new GitVersionSettings();
            gitVersionSettings = configurator(gitVersionSettings);
            PreProcess(gitVersionSettings);
            var process = ProcessTasks.StartProcess(gitVersionSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(gitVersionSettings);
        }
    }
    /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitVersionSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"GitVersion.CommandLine", packageExecutable: $"GitVersion.exe");
        public virtual bool UpdateAssemblyInfo { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("/updateassemblyinfo", UpdateAssemblyInfo);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitVersionSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</i></p></summary>
        [Pure]
        public static GitVersionSettings SetUpdateAssemblyInfo(this GitVersionSettings gitVersionSettings, bool updateAssemblyInfo)
        {
            gitVersionSettings = gitVersionSettings.NewInstance();
            gitVersionSettings.UpdateAssemblyInfo = updateAssemblyInfo;
            return gitVersionSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</i></p></summary>
        [Pure]
        public static GitVersionSettings EnableUpdateAssemblyInfo(this GitVersionSettings gitVersionSettings)
        {
            gitVersionSettings = gitVersionSettings.NewInstance();
            gitVersionSettings.UpdateAssemblyInfo = true;
            return gitVersionSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</i></p></summary>
        [Pure]
        public static GitVersionSettings DisableUpdateAssemblyInfo(this GitVersionSettings gitVersionSettings)
        {
            gitVersionSettings = gitVersionSettings.NewInstance();
            gitVersionSettings.UpdateAssemblyInfo = false;
            return gitVersionSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</i></p></summary>
        [Pure]
        public static GitVersionSettings ToggleUpdateAssemblyInfo(this GitVersionSettings gitVersionSettings)
        {
            gitVersionSettings = gitVersionSettings.NewInstance();
            gitVersionSettings.UpdateAssemblyInfo = !gitVersionSettings.UpdateAssemblyInfo;
            return gitVersionSettings;
        }
    }
}
