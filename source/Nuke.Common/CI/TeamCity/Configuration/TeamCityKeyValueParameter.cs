// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    [PublicAPI]
    public class TeamCityKeyValueParameter : TeamCityParameter
    {
        public TeamCityKeyValueParameter(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("text(");
            using (writer.Indent())
            {
                writer.WriteLine($"{Key.DoubleQuote()},");
                writer.WriteLine($"{Value.DoubleQuote()},");
                writer.WriteLine($"display = ParameterDisplay.{TeamCityParameterDisplay.Hidden.ToString().ToUpperInvariant()})");
            }
        }
    }
}
