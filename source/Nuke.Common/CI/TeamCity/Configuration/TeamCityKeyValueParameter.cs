// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    public class TeamCityKeyValueParameter : TeamCityParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine("param(");
            using (writer.Indent())
            {
                writer.WriteLine($"{Key.DoubleQuote()},");
                writer.WriteLine(Value.DoubleQuote());
            }

            writer.WriteLine(")");
        }
    }
}
