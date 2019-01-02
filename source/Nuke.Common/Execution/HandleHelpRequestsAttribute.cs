// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Execution
{
    internal class HandleHelpRequestsAttribute : BuildExtensionAttributeBase
    {
        public override void PreInitialization(NukeBuild instance)
        {
            if (NukeBuild.Help)
            {
                Logger.Log(HelpTextService.GetTargetsText(instance));
                Logger.Log(HelpTextService.GetParametersText(instance));
            }

            if (NukeBuild.Graph)
                GraphService.ShowGraph(instance);

            if (NukeBuild.Help || NukeBuild.Graph)
                Environment.Exit(exitCode: 0);
        }
    }
}
