// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.ToolGenerator.Model;
using Nuke.ToolGenerator.Writers;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.ToolGenerator.Generators
{
    public static class TaskGenerator
    {
        public static void Run (Tool tool, ToolWriter toolWriter)
        {
            if (tool.Tasks.Count == 0)
                return;

            toolWriter
                    .WriteLine("[PublicAPI]")
                    .WriteLine("[ExcludeFromCodeCoverage]")
                    .WriteLine($"public static partial class {tool.GetClassName()}")
                    .WriteBlock(w => tool.Tasks.ForEach(x => new TaskWriter(x, toolWriter)
                            .WritePreAndPostProcess()
                            .WriteMainTask()
                            .WriteTaskOverloads()));
        }

        private static TaskWriter WriteTaskOverloads (this TaskWriter writer, int index = 0)
        {
            var task = writer.Task;
            var properties = task.SettingsClass.Properties.Where(x => x.CreateOverload).Take(index + 1).ToList();

            if (properties.Count == 0 || index >= properties.Count)
                return writer;

            var additionalParameterDeclarations = properties.Select(x => $"{x.GetNullabilityAttribute()}{x.Type} {x.Name.ToInstance()}");
            var nextArguments = properties.AsEnumerable().Reverse().Skip(count: 1).Reverse().Select(x => x.Name.ToInstance());
            var configuratorName = "configurator";
            var currentArgument = properties.Last();
            var setter = $"x => {configuratorName}(x).Set{currentArgument.Name}({currentArgument.Name.ToInstance()})";
            var allArguments = nextArguments.Concat(new[] { setter });

            writer
                    .WriteSummary(task)
                    .WriteLine(GetTaskSignature(writer.Task, additionalParameterDeclarations))
                    .WriteBlock(w => w
                            .WriteLine("configurator = configurator ?? (x => x);")
                            .WriteLine($"{task.GetTaskMethodName()}({allArguments.Join()});"));

            return writer.WriteTaskOverloads(index + 1);
        }

        private static TaskWriter WriteMainTask (this TaskWriter writer)
        {
            return writer
                    .WriteSummary(writer.Task)
                    .WriteLine(GetTaskSignature(writer.Task))
                    .WriteBlock(WriteMainTaskBlock);
        }

        private static string GetTaskSignature (Task task, IEnumerable<string> additionalParameterDeclarations = null)
        {
            var parameterDeclarations =
                    (additionalParameterDeclarations ?? Enumerable.Empty<string>())
                    .Concat(new[]
                            {
                                $"Configure<{task.SettingsClass.Name}> configurator = null",
                                "ProcessSettings processSettings = null"
                            });

            return $"public static void {task.GetTaskMethodName()} ({parameterDeclarations.Join()})";
        }

        private static void WriteMainTaskBlock (TaskWriter writer)
        {
            writer
                    .WriteLine($"var toolSettings = configurator.InvokeSafe(new {writer.Task.SettingsClass.Name}());")
                    .WriteLine($"PreProcess(toolSettings);")
                    .WriteLine($"var process = {GetProcessStart(writer.Task)};")
                    .WriteLine(GetProcessAssertion(writer.Task))
                    .WriteLine($"PostProcess(toolSettings);");
        }

        private static string GetProcessStart (Task task)
        {
            return !task.CustomStart
                ? "ProcessTasks.StartProcess(toolSettings, processSettings)"
                : "StartProcess(toolSettings, processSettings)";
        }

        private static string GetProcessAssertion (Task task)
        {
            return !task.CustomAssertion
                ? "process.AssertZeroExitCode();"
                : "AssertProcess(process, toolSettings);";
        }

        private static TaskWriter WritePreAndPostProcess (this TaskWriter writer)
        {
            var settingsClass = writer.Task.SettingsClass.Name;
            return writer
                    .WriteLine($"static partial void PreProcess ({settingsClass} toolSettings);")
                    .WriteLine($"static partial void PostProcess ({settingsClass} toolSettings);");
        }
    }
}
