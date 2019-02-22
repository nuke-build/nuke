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
        void Execute(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets);
    }

    public interface IPreLogoBuildExtension : IBuildExtension
    {
    }
    
    public interface IPostLogoBuildExtension : IBuildExtension
    {
    }
}
