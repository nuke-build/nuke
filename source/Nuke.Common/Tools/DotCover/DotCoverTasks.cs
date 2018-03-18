// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.DotCover
{
    partial class DotCoverTasks
    {
        [Obsolete("Use " + nameof(DotCoverAnalyseSettings) + "." + nameof(DotCoverAnalyseSettingsExtensions.SetTargetSettings) + " instead.")]
        public static void DotCoverAnalyse(
            Action testAction,
            Configure<DotCoverAnalyseSettings> configurator = null,
            ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DotCoverAnalyse(x => configurator(x).SetTestAction(testAction));
        }
    }
}
