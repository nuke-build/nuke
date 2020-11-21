// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nuke.Common.Execution;

namespace Nuke.Common.CI
{
    public class BuildServerConfigurationGenerationAttributeBase : BuildExtensionAttributeBase
    {
        public const string ConfigurationParameterName = "generate-configuration";

        protected static IEnumerable<IConfigurationGenerator> GetGenerators(NukeBuild build)
        {
            return build.GetType().GetCustomAttributes<ConfigurationAttributeBase>();
        }
    }
}
