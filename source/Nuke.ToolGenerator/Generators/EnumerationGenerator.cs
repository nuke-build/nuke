// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Text;
using Nuke.ToolGenerator.Model;
using Nuke.ToolGenerator.Writers;

namespace Nuke.ToolGenerator.Generators
{
    public static class EnumerationGenerator
    {
        public static void Run (Enumeration enumeration, ToolWriter toolWriter)
        {
            var values = enumeration.Values.ToArray();
            for (var i = 0; i + 1 < values.Length; i++)
                values[i] += ",";

            toolWriter
                    .WriteSummary(enumeration)
                    .WriteLine("[PublicAPI]")
                    .WriteLineIfTrue(enumeration.IsFlags, "[Flags]")
                    .WriteLine($"public enum {enumeration.Name}")
                    .WriteBlock(w => w.ForEach(enumeration.Values, WriteValue));
        }

        private static void WriteValue (ToolWriter writer, string value)
        {
            var escapedValue = value.Aggregate(
                new StringBuilder(!char.IsLetter(value[index: 0]) ? "_" : string.Empty),
                (sb, c) => sb.Append(char.IsLetterOrDigit(c) ? c : '_'),
                sb => sb.ToString());

            if (escapedValue != value)
                writer.WriteLine($"[FriendlyString(\"{value}\")]");

            writer.WriteLine($"{escapedValue},");
        }
    }
}
