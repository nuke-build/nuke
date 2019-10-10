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
    [AttributeUsage(AttributeTargets.Class)]
    public class TeamCityImportDotCoverPathAttribute : Attribute, IOnAfterLogo
    {
        public void OnAfterLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets, IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            TeamCity.Instance?.SetConfigurationParameter("TEAMCITY_DOTCOVER_HOME", DotCoverTasks.DotCoverPath);
        }
    }
}
