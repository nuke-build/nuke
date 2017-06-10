// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.ToolGenerator.Model;
using Nuke.ToolGenerator.Writers;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.ToolGenerator.Generators
{
    public static class AliasGenerator
    {
        public static void Run ([CanBeNull] Alias alias, ToolWriter toolWriter)
        {
            if (alias == null)
                return;

            var writer = new AliasWriter(alias, toolWriter);
            writer
                    .WriteLineIfTrue(!alias.SkipAttributes, "[PublicAPI]")
                    .WriteLineIfTrue(!alias.SkipAttributes, "[ExcludeFromCodeCoverage]")
                    .WriteLine($"public static partial class {alias.TaskName}Tasks")
                    .WriteBlock(w =>
                    {
                        WritePreAndPostProcess(w);
                        WriteMainAlias(w);
                        WriteAliasOverloads(w);
                    });
        }

        private static AliasWriter WriteAliasOverloads (AliasWriter writer, int index = 0)
        {
            var alias = writer.Alias;

            if (index == alias.OverloadArguments.Count)
                return writer;

            var settingsClass = writer.Tool.SettingsClass;
            var properties = alias.OverloadArguments.Take(index + 1).Select(x => settingsClass.Properties.Single(y => y.Name == x)).ToList();
            var additionalParameterDeclarations = properties.Select(x => $"{x.GetNullabilityAttribute()}{x.Type} {x.Name.ToInstance()}");

            var nextArguments = properties.AsEnumerable().Reverse().Skip(count: 1).Reverse().Select(x => x.Name.ToInstance());
            var configuratorName = "configurator";
            var currentArgument = properties.Last();
            var setter = $"x => {configuratorName}(x).Set{currentArgument.Name}({currentArgument.Name.ToInstance()})";
            var allArguments = nextArguments.Concat(new[] { setter });

            writer
                    .WriteSummary(writer.Tool)
                    .WriteLine(GetAliasSignature(writer.Alias, additionalParameterDeclarations))
                    .WriteBlock(w => w
                            .WriteLine("configurator = configurator ?? (x => x);")
                            .WriteLine($"{alias.GetTaskCommandMethodName()}({allArguments.Join()});"));

            return WriteAliasOverloads(writer, index + 1);
        }

        private static AliasWriter WriteMainAlias (this AliasWriter writer)
        {
            return writer
                    .WriteSummary(writer.Tool)
                    .WriteLine(GetAliasSignature(writer.Alias))
                    .WriteBlock(WriteMainAliasBlock);
        }

        private static string GetAliasSignature (Alias alias, IEnumerable<string> additionalParameterDeclarations = null)
        {
            var className = alias.SettingsClass;
            var parameterDeclarations =
                    (additionalParameterDeclarations ?? Enumerable.Empty<string>())
                    .Concat(new[]
                            {
                                $"Configure<{className}> configurator = null",
                                "ProcessSettings processSettings = null"
                            });

            return $"public static void {alias.GetTaskCommandMethodName()} ({parameterDeclarations.Join()})";
        }

        private static void WriteMainAliasBlock (AliasWriter writer)
        {
            var settingsClass = writer.Alias.SettingsClass;
            var settingsClassInstance = settingsClass.ToInstance();

            writer
                    .WriteLine("configurator = configurator ?? (x => x);")
                    .WriteLine($"var {settingsClassInstance} = new {settingsClass}();")
                    .WriteLine($"{settingsClassInstance} = configurator({settingsClassInstance});")
                    .WriteLine($"PreProcess({settingsClassInstance});")
                    .WriteLine($"var process = {GetProcessStart(writer.Alias)};")
                    .WriteLine(GetProcessAssertion(writer.Alias))
                    .WriteLine($"PostProcess({settingsClassInstance});");
        }

        public static string GetProcessStart(Alias alias)
        {
            return !alias.CustomStart
                ? $"ProcessTasks.StartProcess({alias.SettingsClass.ToInstance()}, processSettings)"
                : $"StartProcess({alias.SettingsClass.ToInstance()}, processSettings)";
        }

        public static string GetProcessAssertion (Alias alias)
        {
            return !alias.CustomAssertion
                ? "process.AssertZeroExitCode();"
                : $"AssertProcess(process, {alias.SettingsClass.ToInstance()});";
        }

        private static AliasWriter WritePreAndPostProcess (this AliasWriter writer)
        {
            var settingsClass = writer.Alias.SettingsClass;
            return writer
                    .WriteLine($"static partial void PreProcess ({settingsClass} {settingsClass.ToInstance()});")
                    .WriteLine($"static partial void PostProcess ({settingsClass} {settingsClass.ToInstance()});");
        }
    }
}
