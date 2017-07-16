// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.DotCover
{
    partial class DotCoverAnalyseSettingsExtensions
    {
        public static DotCoverAnalyseSettings NewInstance (this DotCoverAnalyseSettings toolSettings)
        {
            var newToolSettings = toolSettings.NewInstance<DotCoverAnalyseSettings>();
            newToolSettings._testAction = toolSettings._testAction;
            return newToolSettings;
        }

        public static DotCoverAnalyseSettings SetTestAction (this DotCoverAnalyseSettings toolSettings, Action testAction)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings._testAction = testAction;
            return toolSettings;
        }
    }
}
