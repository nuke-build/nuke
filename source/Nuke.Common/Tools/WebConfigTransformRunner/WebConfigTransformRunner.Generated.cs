// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, LOCAL VERSION.
// Generated from https://github.com/nuke-build/tools/blob/master/metadata/WebConfigTransformRunner.json.

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

namespace Nuke.Common.Tools.WebConfigTransformRunner
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WebConfigTransformRunnerTasks
    {
        static partial void PreProcess (WebConfigTransformRunnerSettings toolSettings);
        static partial void PostProcess (WebConfigTransformRunnerSettings toolSettings);
        /// <summary><p>This is a commandline tool to run an ASP.Net web.config tranformation.</p><p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p></summary>
        public static void WebConfigTransformRunner (Configure<WebConfigTransformRunnerSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new WebConfigTransformRunnerSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
    }
    #region WebConfigTransformRunnerSettings
    /// <summary><p>Used within <see cref="WebConfigTransformRunnerTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WebConfigTransformRunnerSettings : ToolSettings
    {
        /// <summary><p>Path to the WebConfigTransformRunner executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetPackageExecutable($"WebConfigTransformRunner", $"WebConfigTransformRunner.exe");
        /// <summary><p>The base web.config file</p></summary>
        public virtual string WebConfigFilename  { get; internal set; }
        /// <summary><p>The transformation web.config file</p></summary>
        public virtual string TransformFilename { get; internal set; }
        /// <summary><p>The path to the output web.config file</p></summary>
        public virtual string OutputFilename { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(WebConfigFilename ), "File.Exists(WebConfigFilename )");
            ControlFlow.Assert(File.Exists(TransformFilename), "File.Exists(TransformFilename)");
            ControlFlow.Assert(OutputFilename != null, "OutputFilename != null");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", WebConfigFilename )
              .Add("{value}", TransformFilename)
              .Add("{value}", OutputFilename);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WebConfigTransformRunnerSettingsExtensions
    /// <summary><p>Used within <see cref="WebConfigTransformRunnerTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WebConfigTransformRunnerSettingsExtensions
    {
        #region WebConfigFilename 
        /// <summary><p><em>Sets <see cref="WebConfigTransformRunnerSettings.WebConfigFilename "/>.</em></p><p>The base web.config file</p></summary>
        [Pure]
        public static WebConfigTransformRunnerSettings SetWebConfigFilename (this WebConfigTransformRunnerSettings toolSettings, string webConfigFilename )
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WebConfigFilename  = webConfigFilename ;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="WebConfigTransformRunnerSettings.WebConfigFilename "/>.</em></p><p>The base web.config file</p></summary>
        [Pure]
        public static WebConfigTransformRunnerSettings ResetWebConfigFilename (this WebConfigTransformRunnerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WebConfigFilename  = null;
            return toolSettings;
        }
        #endregion
        #region TransformFilename
        /// <summary><p><em>Sets <see cref="WebConfigTransformRunnerSettings.TransformFilename"/>.</em></p><p>The transformation web.config file</p></summary>
        [Pure]
        public static WebConfigTransformRunnerSettings SetTransformFilename(this WebConfigTransformRunnerSettings toolSettings, string transformFilename)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TransformFilename = transformFilename;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="WebConfigTransformRunnerSettings.TransformFilename"/>.</em></p><p>The transformation web.config file</p></summary>
        [Pure]
        public static WebConfigTransformRunnerSettings ResetTransformFilename(this WebConfigTransformRunnerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TransformFilename = null;
            return toolSettings;
        }
        #endregion
        #region OutputFilename
        /// <summary><p><em>Sets <see cref="WebConfigTransformRunnerSettings.OutputFilename"/>.</em></p><p>The path to the output web.config file</p></summary>
        [Pure]
        public static WebConfigTransformRunnerSettings SetOutputFilename(this WebConfigTransformRunnerSettings toolSettings, string outputFilename)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFilename = outputFilename;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="WebConfigTransformRunnerSettings.OutputFilename"/>.</em></p><p>The path to the output web.config file</p></summary>
        [Pure]
        public static WebConfigTransformRunnerSettings ResetOutputFilename(this WebConfigTransformRunnerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFilename = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
