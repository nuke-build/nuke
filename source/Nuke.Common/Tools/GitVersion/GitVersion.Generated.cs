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
        static partial void PreProcess (GitVersionSettings toolSettings);
        static partial void PostProcess (GitVersionSettings toolSettings);
        /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p><p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p></summary>
        public static void GitVersion (Configure<GitVersionSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new GitVersionSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
    }
    /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitVersionSettings : ToolSettings
    {
        /// <summary>Path of the executable to be invoked.</summary>
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
        /// <summary><p><em>Sets <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p></summary>
        [Pure]
        public static GitVersionSettings SetUpdateAssemblyInfo(this GitVersionSettings toolSettings, bool updateAssemblyInfo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = updateAssemblyInfo;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p></summary>
        [Pure]
        public static GitVersionSettings EnableUpdateAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p></summary>
        [Pure]
        public static GitVersionSettings DisableUpdateAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p></summary>
        [Pure]
        public static GitVersionSettings ToggleUpdateAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = !toolSettings.UpdateAssemblyInfo;
            return toolSettings;
        }
    }
}
