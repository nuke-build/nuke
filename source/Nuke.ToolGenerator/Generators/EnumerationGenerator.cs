using System;
using System.Linq;
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
                    .WriteSummary(toolWriter.Tool)
                    .WriteLine("[PublicAPI]")
                    .WriteLineIfTrue(enumeration.IsFlags, "[Flags]")
                    .WriteLine($"public enum {enumeration.Name}")
                    .WriteBlock(w => values.ForEach(x => w.WriteLine(x)));
        }
    }
}
