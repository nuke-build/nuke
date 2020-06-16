// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Execution;

namespace Nuke.Common.ValueInjection
{
    public class InjectParameterValuesAttribute : BuildExtensionAttributeBase, IOnBeforeLogo
    {
        public void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            ValueInjectionUtility.InjectValues(build, x => x is ParameterAttribute);
        }
    }
}
