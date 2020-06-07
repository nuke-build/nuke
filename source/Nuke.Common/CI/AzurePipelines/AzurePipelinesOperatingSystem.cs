// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.CI.AzurePipelines
{
    [TypeConverter(typeof(TypeConverter<AzurePipelinesOperatingSystem>))]
    public class AzurePipelinesOperatingSystem : Enumeration
    {
        public static AzurePipelinesOperatingSystem Parse(string value)
        {
            if (value.Equals("Windows_NT", StringComparison.OrdinalIgnoreCase))
                return Windows;
            if (value.Equals("Darwin", StringComparison.OrdinalIgnoreCase))
                return MacOS;
            if (value.Equals("Linux", StringComparison.OrdinalIgnoreCase))
                return Linux;
            return new AzurePipelinesOperatingSystem() {  Value = value};
        }
        public static AzurePipelinesOperatingSystem Windows { get; } = new AzurePipelinesOperatingSystem() { Value = "Windows_NT" };
        public static AzurePipelinesOperatingSystem MacOS { get; } = new AzurePipelinesOperatingSystem() { Value = "Darwin" };
        public static AzurePipelinesOperatingSystem Linux { get; } = new AzurePipelinesOperatingSystem() { Value = "Linux" };

        public static implicit operator string(AzurePipelinesOperatingSystem configuration)
        {
            return configuration.Value;
        }
    }
}

    
