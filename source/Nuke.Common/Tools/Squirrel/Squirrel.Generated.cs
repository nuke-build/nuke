// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, Version: Local.
// Generated from https://github.com/MarkusAmshove/nuke/blob/master/build/specifications/Squirrel.json.

using JetBrains.Annotations;
using Newtonsoft.Json;
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

namespace Nuke.Common.Tools.Squirrel
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SquirrelTasks
    {
        /// <summary><p>Path to the Squirrel executable.</p></summary>
        public static string SquirrelPath => ToolPathResolver.GetPackageExecutable("Squirrel.Windows", "Squirrel.exe");
        /// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p></summary>
        public static IReadOnlyCollection<Output> Squirrel(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(SquirrelPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, null, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p><p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> Squirrel(Configure<SquirrelSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new SquirrelSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
    }
    #region SquirrelSettings
    /// <summary><p>Used within <see cref="SquirrelTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SquirrelSettings : ToolSettings
    {
        /// <summary><p>Path to the Squirrel executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SquirrelTasks.SquirrelPath;
        /// <summary><p>Update or generate a releases directory with a given NuGet package.</p></summary>
        public virtual string Releasify { get; internal set; }
        /// <summary><p>Path to a release directory to use with releasify.</p></summary>
        public virtual string ReleaseDir { get; internal set; }
        /// <summary><p>Path to an ICO file that will be used for icon shortcuts.</p></summary>
        public virtual string Icon { get; internal set; }
        /// <summary><p>Path to an animated GIF to be displayed during installation.</p></summary>
        public virtual string LoadingGif { get; internal set; }
        /// <summary><p>Install the app whose package is in the specified directory.</p></summary>
        public virtual string Install { get; internal set; }
        /// <summary><p>Download the releases specified by the URL and write new results to stdout as JSON.</p></summary>
        public virtual string Download { get; internal set; }
        /// <summary><p>Check for one available update and writes new results to stdout as JSON</p></summary>
        public virtual string CheckForUpdate { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(Releasify), "File.Exists(Releasify)");
            ControlFlow.Assert(File.Exists(Icon) || Icon == null, "File.Exists(Icon) || Icon == null");
            ControlFlow.Assert(File.Exists(LoadingGif) || LoadingGif == null, "File.Exists(LoadingGif) || LoadingGif == null");
            ControlFlow.Assert(Directory.Exists(Install) || Install == null, "Directory.Exists(Install) || Install == null");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("--releasify={value}", Releasify)
              .Add("--releaseDir={value}", ReleaseDir)
              .Add("--icon={value}", Icon)
              .Add("--loadingGif={value}", LoadingGif)
              .Add("--install={value}", Install)
              .Add("--download={value}", Download)
              .Add("--checkForUpdate={value}", CheckForUpdate);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SquirrelSettingsExtensions
    /// <summary><p>Used within <see cref="SquirrelTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SquirrelSettingsExtensions
    {
        #region Releasify
        /// <summary><p><em>Sets <see cref="SquirrelSettings.Releasify"/>.</em></p><p>Update or generate a releases directory with a given NuGet package.</p></summary>
        [Pure]
        public static SquirrelSettings SetReleasify(this SquirrelSettings toolSettings, string releasify)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Releasify = releasify;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.Releasify"/>.</em></p><p>Update or generate a releases directory with a given NuGet package.</p></summary>
        [Pure]
        public static SquirrelSettings ResetReleasify(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Releasify = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseDir
        /// <summary><p><em>Sets <see cref="SquirrelSettings.ReleaseDir"/>.</em></p><p>Path to a release directory to use with releasify.</p></summary>
        [Pure]
        public static SquirrelSettings SetReleaseDir(this SquirrelSettings toolSettings, string releaseDir)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseDir = releaseDir;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.ReleaseDir"/>.</em></p><p>Path to a release directory to use with releasify.</p></summary>
        [Pure]
        public static SquirrelSettings ResetReleaseDir(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseDir = null;
            return toolSettings;
        }
        #endregion
        #region Icon
        /// <summary><p><em>Sets <see cref="SquirrelSettings.Icon"/>.</em></p><p>Path to an ICO file that will be used for icon shortcuts.</p></summary>
        [Pure]
        public static SquirrelSettings SetIcon(this SquirrelSettings toolSettings, string icon)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Icon = icon;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.Icon"/>.</em></p><p>Path to an ICO file that will be used for icon shortcuts.</p></summary>
        [Pure]
        public static SquirrelSettings ResetIcon(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Icon = null;
            return toolSettings;
        }
        #endregion
        #region LoadingGif
        /// <summary><p><em>Sets <see cref="SquirrelSettings.LoadingGif"/>.</em></p><p>Path to an animated GIF to be displayed during installation.</p></summary>
        [Pure]
        public static SquirrelSettings SetLoadingGif(this SquirrelSettings toolSettings, string loadingGif)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadingGif = loadingGif;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.LoadingGif"/>.</em></p><p>Path to an animated GIF to be displayed during installation.</p></summary>
        [Pure]
        public static SquirrelSettings ResetLoadingGif(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadingGif = null;
            return toolSettings;
        }
        #endregion
        #region Install
        /// <summary><p><em>Sets <see cref="SquirrelSettings.Install"/>.</em></p><p>Install the app whose package is in the specified directory.</p></summary>
        [Pure]
        public static SquirrelSettings SetInstall(this SquirrelSettings toolSettings, string install)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = install;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.Install"/>.</em></p><p>Install the app whose package is in the specified directory.</p></summary>
        [Pure]
        public static SquirrelSettings ResetInstall(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = null;
            return toolSettings;
        }
        #endregion
        #region Download
        /// <summary><p><em>Sets <see cref="SquirrelSettings.Download"/>.</em></p><p>Download the releases specified by the URL and write new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings SetDownload(this SquirrelSettings toolSettings, string download)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = download;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.Download"/>.</em></p><p>Download the releases specified by the URL and write new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings ResetDownload(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = null;
            return toolSettings;
        }
        #endregion
        #region CheckForUpdate
        /// <summary><p><em>Sets <see cref="SquirrelSettings.CheckForUpdate"/>.</em></p><p>Check for one available update and writes new results to stdout as JSON</p></summary>
        [Pure]
        public static SquirrelSettings SetCheckForUpdate(this SquirrelSettings toolSettings, string checkForUpdate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = checkForUpdate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.CheckForUpdate"/>.</em></p><p>Check for one available update and writes new results to stdout as JSON</p></summary>
        [Pure]
        public static SquirrelSettings ResetCheckForUpdate(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
