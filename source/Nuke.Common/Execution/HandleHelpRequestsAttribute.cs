// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    internal class HandleHelpRequestsAttribute : BuildExtensionAttributeBase, IOnAfterLogo
    {
        public void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (NukeBuild.Help || executionPlan.Count == 0)
            {
                Logger.Normal(HelpTextService.GetTargetsText(build.ExecutableTargets));
                Logger.Normal(HelpTextService.GetParametersText(build));
            }

            if (NukeBuild.Plan)
                ExecutionPlanHtmlService.ShowPlan(build.ExecutableTargets);

            if (NukeBuild.Help || executionPlan.Count == 0 || NukeBuild.Plan)
                Environment.Exit(exitCode: 0);
        }
    }
}
