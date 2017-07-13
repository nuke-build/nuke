// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Core.Utilities;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Common.Tools.MSBuild
{
    public static partial class MSBuildSettingsExtensions
    {
        /// <summary><em>Sets <see cref="MSBuildSettings.TargetPath" />.</em></summary>
        public static MSBuildSettings SetSolutionFile (this MSBuildSettings toolSettings, string solutionFile)
        {
            return toolSettings.SetTargetPath(solutionFile);
        }

        /// <summary><em>Sets <see cref="MSBuildSettings.TargetPath" />.</em></summary>
        public static MSBuildSettings SetProjectFile (this MSBuildSettings toolSettings, string projectFile)
        {
            return toolSettings.SetTargetPath(projectFile);
        }

        #region NoWarn

        private const string c_noWarn = "NoWarn";

        /// <summary><em>Sets <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/> to a new list.</em></summary>
        public static MSBuildSettings SetNoWarns(this MSBuildSettings toolSettings, params int[] codes)
        {
            return toolSettings.SetNoWarns(codes.AsEnumerable());
        }

        /// <summary><em>Sets <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/> to a new list.</em></summary>
        public static MSBuildSettings SetNoWarns(this MSBuildSettings toolSettings, IEnumerable<int> codes)
        {
            return toolSettings.SetProperty(c_noWarn, string.Join(";", codes));
        }

        /// <summary><em>Clears <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings ClearNoWarns(this MSBuildSettings toolSettings)
        {
            return toolSettings.RemoveProperty(c_noWarn);
        }

        /// <summary><em>Adds a value to <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings AddNoWarns(this MSBuildSettings toolSettings, IEnumerable<int> codes)
        {
            return toolSettings.SetNoWarns(
                toolSettings.Properties.TryGetValue(c_noWarn, out var existingCodes)
                    ? existingCodes.Split(';').Select(int.Parse).Concat(codes)
                    : codes);
        }
        
        /// <summary><em>Removes a single value in <c>NoWarn</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings RemoveNoWarn(this MSBuildSettings toolSettings, int code)
        {
            return toolSettings.Properties.TryGetValue(c_noWarn, out var existingCodes)
                ? toolSettings.SetNoWarns(existingCodes.Split(';').Select(int.Parse).Where(x => x != code).ToList())
                : toolSettings.ClearNoWarns();
        }

        #endregion

        #region WarningLevel
        
        private const string c_warningLevel = "WarningLevel";

        /// <summary><em>Sets <c>WarningLevel</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings SetWarningLevel(this MSBuildSettings toolSettings, int warningLevel)
        {
            return toolSettings.SetProperty(c_warningLevel, warningLevel.ToString());
        }

        /// <summary><em>Removes <c>WarningLevel</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings RemoveWarningLevel(this MSBuildSettings toolSettings)
        {
            return toolSettings.RemoveProperty(c_warningLevel);
        }
        
        #endregion

        #region Configuration

        private const string c_configuration = "Configuration";

        /// <summary><em>Sets <c>Configuration</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings SetConfiguration (this MSBuildSettings toolSettings, string configuration)
        {
            return toolSettings.SetProperty(c_configuration, configuration);
        }

        /// <summary><em>Removes <c>Configuration</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings RemoveConfiguration (this MSBuildSettings toolSettings)
        {
            return toolSettings.RemoveProperty(c_configuration);
        }

        #endregion

        #region TreatWarningsAsErrors

        private const string c_treatWarningsAsErrors = "TreatWarningsAsErrors";

        /// <summary><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings SetTreatWarningsAsErrors (this MSBuildSettings toolSettings, bool treatWarningsAsErrors)
        {
            return toolSettings.SetProperty(c_treatWarningsAsErrors, treatWarningsAsErrors.ToString());
        }

        /// <summary><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings EnableTreatWarningsAsErrors (this MSBuildSettings toolSettings)
        {
            return toolSettings.SetProperty(c_treatWarningsAsErrors, true.ToString());
        }

        /// <summary><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings DisableTreatWarningsAsErrors (this MSBuildSettings toolSettings)
        {
            return toolSettings.SetProperty(c_treatWarningsAsErrors, false.ToString());
        }

        /// <summary><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings ToggleTreatWarningsAsErrors (this MSBuildSettings toolSettings)
        {
            // TODO: test
            var valueOrDefault = toolSettings.PropertiesInternal.GetValueOrDefault(c_treatWarningsAsErrors, false.ToString());
            return toolSettings.SetProperty(c_treatWarningsAsErrors, (!bool.Parse(valueOrDefault)).ToString());
        }

        /// <summary><em>Removes <c>TreatWarningsAsErrors</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings RemoveTreatWarningsAsErrors (this MSBuildSettings toolSettings)
        {
            return toolSettings.RemoveProperty(c_treatWarningsAsErrors);
        }

        #endregion

        #region RunCodeAnalysis

        private const string c_runCodeAnalysis = "RunCodeAnalysis";

        /// <summary><em>Sets <c>RunCodeAnalysis</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings SetRunCodeAnalysis (this MSBuildSettings toolSettings, bool runCodeAnalysis)
        {
            return toolSettings.SetProperty(c_runCodeAnalysis, runCodeAnalysis.ToString());
        }

        /// <summary><em>Enables <c>RunCodeAnalysis</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings EnableRunCodeAnalysis (this MSBuildSettings toolSettings)
        {
            return toolSettings.SetProperty(c_runCodeAnalysis, true.ToString());
        }

        /// <summary><em>Disables <c>RunCodeAnalysis</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings DisableRunCodeAnalysis (this MSBuildSettings toolSettings)
        {
            return toolSettings.SetProperty(c_runCodeAnalysis, false.ToString());
        }

        /// <summary><em>Toggles <c>RunCodeAnalysis</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings ToggleRunCodeAnalysis (this MSBuildSettings toolSettings)
        {
            // TODO: test
            var valueOrDefault = toolSettings.PropertiesInternal.GetValueOrDefault(c_runCodeAnalysis, false.ToString());
            return toolSettings.SetProperty(c_runCodeAnalysis, (!bool.Parse(valueOrDefault)).ToString());
        }

        /// <summary><em>Removes <c>RunCodeAnalysis</c> in <see cref="MSBuildSettings.Properties"/>.</em></summary>
        public static MSBuildSettings RemoveRunCodeAnalysis (this MSBuildSettings toolSettings)
        {
            return toolSettings.RemoveProperty(c_runCodeAnalysis);
        }

        #endregion

        // TODO: WarningsAsErrors
    }
}
