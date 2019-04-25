// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class HandlePlanRequestAttribute : Attribute, IPostLogoBuildExtension
    {
        public void Execute(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (!NukeBuild.Plan)
                return;

            ExecutionPlanHtmlService.ShowPlan(build.ExecutableTargets);
            Environment.Exit(exitCode: 0);
        }
    }
}
