// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Execution
{
    public class InjectParameterValuesAttribute : BuildExtensionAttributeBase, IOnBeforeLogo
    {
        public void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            InjectionUtility.InjectValues(build, x => x is ParameterAttribute);
        }
    }
}
