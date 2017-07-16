// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.OpenCover
{
    partial class OpenCoverSettingsExtensions
    {
        public static OpenCoverSettings NewInstance (this OpenCoverSettings toolSettings)
        {
            var newToolSettings = toolSettings.NewInstance<OpenCoverSettings>();
            newToolSettings._testAction = toolSettings._testAction;
            return newToolSettings;
        }

        public static OpenCoverSettings SetTestAction (this OpenCoverSettings toolSettings, Action testAction)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings._testAction = testAction;
            return toolSettings;
        }
    }
}
