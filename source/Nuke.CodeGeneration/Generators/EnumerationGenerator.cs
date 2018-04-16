// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Text;
using Nuke.CodeGeneration.Model;
using Nuke.CodeGeneration.Writers;

namespace Nuke.CodeGeneration.Generators
{
    public static class EnumerationGenerator
    {
        public static void Run(Enumeration enumeration, ToolWriter toolWriter)
        {
            var values = enumeration.Values.ToArray();
            for (var i = 0; i + 1 < values.Length; i++)
                values[i] += ",";

            string GetIdentifier(string value)
                => value.Aggregate(
                    new StringBuilder(!char.IsLetter(value[index: 0]) ? "_" : string.Empty),
                    (sb, c) => sb.Append(char.IsLetterOrDigit(c) ? c : '_'),
                    sb => sb.ToString());

            toolWriter
                .WriteLine($"#region {enumeration.Name}")
                .WriteSummary(enumeration)
                .WriteLine("[PublicAPI]")
                .WriteLine("[Serializable]")
                .WriteLine($"public partial class {enumeration.Name} : Enumeration")
                .WriteBlock(w => w.ForEach(enumeration.Values,
                    x => w.WriteLine(
                        $"public static {enumeration.Name} {GetIdentifier(x)} = new {enumeration.Name.EscapeProperty()} {{ Value = {x.DoubleQuote()} }};")))
                .WriteLine("#endregion");
        }
    }
}
