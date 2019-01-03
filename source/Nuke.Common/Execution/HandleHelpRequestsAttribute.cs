// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Execution
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class HandleHelpRequestsAttribute : Attribute, IPostLogoBuildExtension
    {
        public void Execute(NukeBuild instance)
        {
            if (NukeBuild.Help)
            {
                Logger.Log(HelpTextService.GetTargetsText(NukeBuild.ExecutableTargets));
                Logger.Log(HelpTextService.GetParametersText(instance, NukeBuild.ExecutableTargets));
            }

            if (NukeBuild.Graph)
                GraphService.ShowGraph(NukeBuild.ExecutableTargets);

            if (NukeBuild.Help || NukeBuild.Graph)
                Environment.Exit(exitCode: 0);
        }
    }
}
