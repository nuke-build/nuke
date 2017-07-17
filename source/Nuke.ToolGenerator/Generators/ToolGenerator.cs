// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.ToolGenerator.Model;
using Nuke.ToolGenerator.Writers;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.ToolGenerator.Generators
{
    public static class ToolGenerator
    {
        public static void Run (Tool tool, StreamWriter streamWriter)
        {
            using (var writer = new ToolWriter(tool, streamWriter))
            {
                writer
                        // TODO [3]: extract license from dotsettings file
                        .WriteLine("// Copyright Matthias Koch 2017.")
                        .WriteLine("// Distributed under the MIT License.")
                        .WriteLine("// https://github.com/nuke-build/nuke/blob/master/LICENSE")
                        .WriteLine(string.Empty)
                        .WriteLine("// Auto-generated with Nuke.ToolGenerator.")
                        .WriteLine(string.Empty)
                        .ForEach(GetNamespaceImports(), x => writer.WriteLine($"using {x};"))
                        .WriteLine(string.Empty)
                        .WriteLine(GetIconClassAttribute(tool))
                        .WriteLine($"namespace {tool.GetNamespace()}")
                        .WriteBlock(w => w
                                .WriteAlias()
                                .WriteDataClasses()
                                .WriteEnumerations());
            }
        }

        [CanBeNull]
        private static string GetIconClassAttribute (Tool tool)
        {
            if (tool.IconClass == null || tool.Tasks.Count == 0)
                return null;

            return $"[assembly: IconClass(typeof({tool.GetNamespace()}.{tool.GetClassName()}), \"{tool.IconClass}\")]"
                   + Environment.NewLine;
        }

        private static ToolWriter WriteAlias (this ToolWriter writer)
        {
            TaskGenerator.Run(writer.Tool, writer);
            return writer;
        }

        private static ToolWriter WriteDataClasses (this ToolWriter writer)
        {
            var dataClasses = writer.Tool.Tasks.Select(x => x.SettingsClass).Concat(writer.Tool.DataClasses).ToList();
            dataClasses.ForEach(x => DataClassGenerator.Run(x, writer));
            dataClasses.Where(x => !x.NoExtensionMethods).ForEach(x => DataClassExtensionGenerator.Run(x, writer));
            return writer;
        }

        private static ToolWriter WriteEnumerations (this ToolWriter writer)
        {
            writer.Tool.Enumerations.ForEach(x => EnumerationGenerator.Run(x, writer));
            return writer;
        }

        private static IEnumerable<string> GetNamespaceImports ()
        {
            return new[]
                   {
                       "JetBrains.Annotations",
                       "Nuke.Common.Tools",
                       "Nuke.Core",
                       "Nuke.Core.Execution",
                       "Nuke.Core.Tooling",
                       "Nuke.Core.Utilities.Collections",
                       "System",
                       "System.Collections.Generic",
                       "System.Collections.ObjectModel",
                       "System.Diagnostics.CodeAnalysis",
                       "System.IO",
                       "System.Linq",
                       "System.Text"
                   };
        }
    }
}
