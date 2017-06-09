// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                        .ForEach(GetNamespaceImports(), x => writer.WriteLine($"using {x};"))
                        .WriteLine(string.Empty)
                        .WriteLine($"namespace {tool.GetNamespace()}")
                        .WriteBlock(w => w
                                .WriteAlias()
                                .WriteDataClasses()
                                .WriteEnumerations());
            }
        }

        private static ToolWriter WriteAlias (this ToolWriter writer)
        {
            AliasGenerator.Run(writer.Tool.Alias, writer);
            return writer;
        }

        private static ToolWriter WriteDataClasses (this ToolWriter writer)
        {
            var dataClasses = writer.Tool.DataClasses.ToList();
            if (writer.Tool.SettingsClass != null)
                dataClasses.Insert(index: 0, item: writer.Tool.SettingsClass);

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
