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

    public interface IPreLogoBuildExtension : IBuildExtension
    {
        void PreLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets);
    }

    public interface IPostLogoBuildExtension : IBuildExtension
    {
        void PostLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets, IReadOnlyCollection<ExecutableTarget> executionPlan);
    }
}
