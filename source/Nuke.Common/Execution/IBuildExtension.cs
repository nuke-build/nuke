// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    public interface IBuildExtension
    {
    }

    public interface IOnBeforeLogo : IBuildExtension
    {
        void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets);
    }

    public interface IOnAfterLogo : IBuildExtension
    {
        void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            ExecutionPlan executionPlan);
    }

    public interface IOnBuildFinished : IBuildExtension
    {
        void OnBuildFinished(NukeBuild build);
    }
}
