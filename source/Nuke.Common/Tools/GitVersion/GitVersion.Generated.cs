// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, Version: Local.
// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/GitVersion.json.

using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.GitVersion
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitVersionTasks
    {
        /// <summary><p>Path to the GitVersion executable.</p></summary>
        public static string GitVersionPath => ToolPathResolver.GetPackageExecutable("GitVersion.CommandLine", "GitVersion.exe");
        /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p></summary>
        public static IEnumerable<string> GitVersion(string arguments, string workingDirectory = null, ProcessSettings processSettings = null)
        {
            var process = ProcessTasks.StartProcess(GitVersionPath, arguments, workingDirectory, processSettings?.EnvironmentVariables, processSettings?.ExecutionTimeout, processSettings?.RedirectOutput ?? true);
            process.AssertZeroExitCode();
            return process.Output.Select(x => x.Text);
        }
        static partial void PreProcess(GitVersionSettings toolSettings);
        static partial void PostProcess(GitVersionSettings toolSettings);
        /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p><p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p></summary>
        public static GitVersion GitVersion(Configure<GitVersionSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new GitVersionSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
            return GetResult(process, toolSettings, processSettings);
        }
    }
    #region GitVersionSettings
    /// <summary><p>Used within <see cref="GitVersionTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitVersionSettings : ToolSettings
    {
        /// <summary><p>Path to the GitVersion executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GitVersionTasks.GitVersionPath;
        public virtual bool? UpdateAssemblyInfo { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("/updateassemblyinfo", UpdateAssemblyInfo);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region GitVersion
    /// <summary><p>Used within <see cref="GitVersionTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitVersion : ISettingsEntity
    {
        public virtual int Major { get; internal set; }
        public virtual int Minor { get; internal set; }
        public virtual int Patch { get; internal set; }
        public virtual string PreReleaseTag { get; internal set; }
        public virtual string PreReleaseTagWithDash { get; internal set; }
        public virtual string PreReleaseLabel { get; internal set; }
        public virtual string PreReleaseNumber { get; internal set; }
        public virtual string BuildMetaData { get; internal set; }
        public virtual string BuildMetaDataPadded { get; internal set; }
        public virtual string FullBuildMetaData { get; internal set; }
        public virtual string MajorMinorPatch { get; internal set; }
        public virtual string SemVer { get; internal set; }
        public virtual string LegacySemVer { get; internal set; }
        public virtual string LegacySemVerPadded { get; internal set; }
        public virtual string AssemblySemVer { get; internal set; }
        public virtual string FullSemVer { get; internal set; }
        public virtual string InformationalVersion { get; internal set; }
        public virtual string BranchName { get; internal set; }
        public virtual string Sha { get; internal set; }
        public virtual string NuGetVersionV2 { get; internal set; }
        public virtual string NuGetVersion { get; internal set; }
        public virtual string NuGetPreReleaseTagV2 { get; internal set; }
        public virtual string NuGetPreReleaseTag { get; internal set; }
        public virtual string CommitsSinceVersionSource { get; internal set; }
        public virtual string CommitsSinceVersionSourcePadded { get; internal set; }
        public virtual string CommitDate { get; internal set; }
    }
    #endregion
    #region GitVersionSettingsExtensions
    /// <summary><p>Used within <see cref="GitVersionTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitVersionSettingsExtensions
    {
        #region UpdateAssemblyInfo
        /// <summary><p><em>Sets <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p></summary>
        [Pure]
        public static GitVersionSettings SetUpdateAssemblyInfo(this GitVersionSettings toolSettings, bool? updateAssemblyInfo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = updateAssemblyInfo;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p></summary>
        [Pure]
        public static GitVersionSettings ResetUpdateAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = null;
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
        #endregion
    }
    #endregion
}
