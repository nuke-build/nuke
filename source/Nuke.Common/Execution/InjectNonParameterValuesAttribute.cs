// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    public class InjectNonParameterValuesAttribute : BuildExtensionAttributeBase, IOnAfterLogo
    {
        public void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            InjectionUtility.InjectValues(build, x => !(x is ParameterAttribute));
        }
    }
}
