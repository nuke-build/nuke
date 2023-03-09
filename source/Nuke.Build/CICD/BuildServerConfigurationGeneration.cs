// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.CI
{
    public static class BuildServerConfigurationGeneration
    {
        public static bool IsActive { get; } = ParameterService.GetParameter<string>(ConfigurationParameterName) != null;

        public const string ConfigurationParameterName = "generate-configuration";
    }
}
