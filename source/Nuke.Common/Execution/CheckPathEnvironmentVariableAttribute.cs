// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class)]
    public class CheckPathEnvironmentVariableAttribute : Attribute, IOnAfterLogo
    {
        public void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            ProcessTasks.CheckPathEnvironmentVariable();
        }
    }
}
