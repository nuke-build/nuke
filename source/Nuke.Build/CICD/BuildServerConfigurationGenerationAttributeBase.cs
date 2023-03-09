// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nuke.Common.Execution;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI
{
    public class BuildServerConfigurationGenerationAttributeBase : BuildExtensionAttributeBase
    {
        protected static IEnumerable<IConfigurationGenerator> GetGenerators(INukeBuild build)
        {
            return build.GetType().GetCustomAttributes<ConfigurationAttributeBase>()
                .ForEachLazy(x => x.Build = build);
        }
    }
}
