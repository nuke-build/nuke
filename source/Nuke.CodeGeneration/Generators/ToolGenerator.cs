// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.CodeGeneration.Model;
using Nuke.CodeGeneration.Writers;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.CodeGeneration.Generators
{
    public static class ToolGenerator
    {
        private static readonly Assembly s_assembly = typeof(ToolGenerator).GetTypeInfo().Assembly;

        public static void Run(Tool tool, [CanBeNull] string @namespace, StreamWriter streamWriter)
        {
            using (var writer = new ToolWriter(tool, streamWriter))
            {
                writer
                    // TODO [3]: extract license from dotsettings file
                    .WriteLine($"// Copyright Matthias Koch, Sebastian Karasek {DateTime.Now.Year}.")
                    .WriteLine("// Distributed under the MIT License.")
                    .WriteLine("// https://github.com/nuke-build/nuke/blob/master/LICENSE")
                    .WriteLine(string.Empty)
                    .WriteLine($"// Generated with {s_assembly.GetName().Name}, Version: {s_assembly.GetVersionText()}.")
                    .WriteLineIfTrue(tool.RepositoryUrl != null, $"// Generated from {tool.RepositoryUrl}.")
                    .WriteLine(string.Empty)
                    .ForEach(GetNamespaceImports(), x => writer.WriteLine($"using {x};"))
                    .WriteLine(string.Empty)
                    .WriteLineIfTrue(@namespace != null, $"namespace {@namespace}");

                if (!string.IsNullOrEmpty(@namespace))
                    writer.WriteBlock(x => x.WriteAll());
                else
                    writer.WriteAll();
            }
        }

        private static ToolWriter WriteAll(this ToolWriter w)
        {
            return w
                .WriteAlias()
                .WriteDataClasses()
                .WriteEnumerations();
        }

        private static ToolWriter WriteAlias(this ToolWriter writer)
        {
            TaskGenerator.Run(writer.Tool, writer);
            return writer;
        }

        private static ToolWriter WriteDataClasses(this ToolWriter writer)
        {
            var dataClasses = writer.Tool.Tasks.Select(x => x.SettingsClass).Concat(writer.Tool.DataClasses).ToList();
            dataClasses.ForEach(x => DataClassGenerator.Run(x, writer));
            dataClasses.Where(x => !x.NoExtensionMethods).ForEach(x => DataClassExtensionGenerator.Run(x, writer));
            return writer;
        }

        private static ToolWriter WriteEnumerations(this ToolWriter writer)
        {
            writer.Tool.Enumerations.ForEach(x => EnumerationGenerator.Run(x, writer));
            return writer;
        }

        private static IEnumerable<string> GetNamespaceImports()
        {
            return new[]
                   {
                       "JetBrains.Annotations",
                       "Nuke.Common",
                       "Nuke.Common.Execution",
                       "Nuke.Common.Tooling",
                       "Nuke.Common.Tools",
                       "Nuke.Common.Utilities.Collections",
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
