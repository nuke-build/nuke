// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class HandleHelpRequestAttribute : Attribute, IPostLogoBuildExtension
    {
        public void Execute(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            if (!NukeBuild.Help && executionPlan.Count > 0)
                return;

            Logger.Normal(HelpTextService.GetTargetsText(build.ExecutableTargets));
            Logger.Normal(HelpTextService.GetParametersText(build));

            Environment.Exit(exitCode: 0);
        }
    }
}
