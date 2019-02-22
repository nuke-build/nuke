// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class HandleHelpRequestsAttribute : Attribute, IPostLogoBuildExtension
    {
        public void Execute(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (NukeBuild.Help)
            {
                Logger.Normal(HelpTextService.GetTargetsText(build.ExecutableTargets));
                Logger.Normal(HelpTextService.GetParametersText(build));
            }

            if (NukeBuild.Plan)
                ExecutionPlanHtmlService.ShowPlan(build.ExecutableTargets);

            if (NukeBuild.Help || NukeBuild.Plan)
                Environment.Exit(exitCode: 0);
        }
    }
}
