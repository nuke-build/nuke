// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Execution;

namespace Nuke.Common.Tools.DotCover
{
    [PublicAPI]
    public class TeamCitySetDotCoverHomePathAttribute : BuildExtensionAttributeBase, IOnAfterLogo
    {
        public void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            ExecutionPlan executionPlan)
        {
            TeamCity.Instance?.SetConfigurationParameter("teamcity.dotCover.home", DotCoverTasks.DotCoverPath);
        }
    }
}
