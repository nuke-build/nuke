// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    internal class HandleHelpRequestsAttribute : BuildExtensionAttributeBase, IOnBuildInitialized
    {
        public void OnBuildInitialized(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (build.Help || executionPlan.Count == 0)
            {
                Host.Debug(HelpTextService.GetTargetsText(build.ExecutableTargets));
                Host.Debug(HelpTextService.GetParametersText(build));
            }

            if (build.Plan)
                ExecutionPlanHtmlService.ShowPlan(build.ExecutableTargets);

            if (build.Help || executionPlan.Count == 0 || build.Plan)
                Environment.Exit(exitCode: 0);
        }
    }
}
