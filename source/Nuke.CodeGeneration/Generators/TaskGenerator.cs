// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Nuke.CodeGeneration.Model;
using Nuke.CodeGeneration.Writers;
using Nuke.Common.Utilities;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.CodeGeneration.Generators
{
    public static class TaskGenerator
    {
        public static void Run(Tool tool, ToolWriter toolWriter)
        {
            if (tool.Tasks.Count == 0 && !tool.CustomExecutable && tool.PathExecutable == null && tool.PackageId == null)
                return;

            toolWriter
                .WriteLine("[PublicAPI]")
                .WriteLine("[ExcludeFromCodeCoverage]")
                .WriteLine($"public static partial class {tool.GetClassName()}")
                .WriteBlock(w =>
                {
                    w.WriteToolPath();
                    w.WriteGenericTask();
                    tool.Tasks.ForEach(x => new TaskWriter(x, toolWriter)
                        .WriteToolSettingsTask()
                        .WriteConfiguratorTask()
                        .WriteCombinatorialConfiguratorTask());
                });
        }

        private static void WriteGenericTask(this ToolWriter writer)
        {
            var tool = writer.Tool;
            var parameters = new[]
                             {
                                 "string arguments",
                                 "string workingDirectory = null",
                                 "IReadOnlyDictionary<string, string> environmentVariables = null",
                                 "int? timeout = null",
                                 "bool logOutput = true",
                                 "Func<string, string> outputFilter = null"
                             };
            var arguments = new[]
                            {
                                $"{tool.Name}Path",
                                "arguments",
                                "workingDirectory",
                                "environmentVariables",
                                "timeout",
                                "logOutput",
                                writer.Tool.LogLevelParsing ? "ParseLogLevel" : "null",
                                "outputFilter"
                            };
            writer
                .WriteSummary(tool.Help)
                .WriteObsoleteAttributeWhenObsolete(tool)
                .WriteLine($"public static IReadOnlyCollection<Output> {tool.Name}({parameters.JoinComma()})")
                .WriteBlock(w => w
                    .WriteLine($"var process = ProcessTasks.StartProcess({arguments.JoinComma()});")
                    .WriteLine("process.AssertZeroExitCode();")
                    .WriteLine("return process.Output;"));
        }

        private static TaskWriter WriteToolSettingsTask(this TaskWriter writer)
        {
            var task = writer.Task;
            var returnType = task.HasReturnValue()
                ? $"({task.ReturnType} Result, IReadOnlyCollection<Output> Output)"
                : "IReadOnlyCollection<Output>";

            return writer
                .WriteSummary(task)
                .WriteObsoleteAttributeWhenObsolete(task)
                .WriteLine($"public static {returnType} {task.GetTaskMethodName()}({task.SettingsClass.Name} toolSettings = null)")
                .WriteBlock(w => w
                    .WriteLine($"toolSettings = toolSettings ?? new {task.SettingsClass.Name}();")
                    .WriteLineIfTrue(task.PreProcess, "PreProcess(ref toolSettings);")
                    .WriteLine($"var process = {GetProcessStart(task)};")
                    .WriteLine(GetProcessAssertion(task))
                    .WriteLineIfTrue(task.PostProcess, "PostProcess(toolSettings);")
                    .WriteLine(task.HasReturnValue()
                        ? "return (GetResult(process, toolSettings), process.Output);"
                        : "return process.Output;"));
        }

        private static TaskWriter WriteConfiguratorTask(this TaskWriter writer)
        {
            var task = writer.Task;
            var returnType = task.HasReturnValue()
                ? $"({task.ReturnType} Result, IReadOnlyCollection<Output> Output)"
                : "IReadOnlyCollection<Output>";

            return writer
                .WriteSummary(task)
                .WriteObsoleteAttributeWhenObsolete(task)
                .WriteLine($"public static {returnType} {task.GetTaskMethodName()}(Configure<{task.SettingsClass.Name}> configurator)")
                .WriteBlock(w => w
                    .WriteLine($"return {task.GetTaskMethodName()}(configurator(new {task.SettingsClass.Name}()));"));
        }
        
        private static TaskWriter WriteCombinatorialConfiguratorTask(this TaskWriter writer)
        {
            var task = writer.Task;
            var returnType = !task.HasReturnValue()
                ? $"IEnumerable<({task.SettingsClass.Name} Settings, IReadOnlyCollection<Output> Output)>"
                : $"IEnumerable<({task.SettingsClass.Name} Settings, {task.ReturnType} Result, IReadOnlyCollection<Output> Output)>";
            var selector = !task.HasReturnValue()
                ? "(x.ToolSettings, x.ReturnValue)"
                : "(x.ToolSettings, x.ReturnValue.Result, x.ReturnValue.Output)";

            return writer
                .WriteSummary(task)
                .WriteObsoleteAttributeWhenObsolete(task)
                .WriteLine($"public static {returnType} {task.GetTaskMethodName()}(CombinatorialConfigure<{task.SettingsClass.Name}> configurator)")
                .WriteBlock(w => w
                    .WriteLine($"return configurator(new {task.SettingsClass.Name}())")
                    .WriteLine($"    .Select(x => (ToolSettings: x, ReturnValue: {task.GetTaskMethodName()}(x)))")
                    .WriteLine($"    .Select(x => {selector}).ToList();"));
        }

        private static string GetProcessStart(Task task)
        {
            return !task.CustomStart
                ? "ProcessTasks.StartProcess(toolSettings)"
                : "StartProcess(toolSettings)";
        }

        private static string GetProcessAssertion(Task task)
        {
            return !task.CustomAssertion
                ? "process.AssertZeroExitCode();"
                : "AssertProcess(process, toolSettings);";
        }

        private static ToolWriter WriteToolPath(this ToolWriter writer)
        {
            var tool = writer.Tool;
            var resolvers = new List<string>();

            if (tool.PackageId != null)
            {
                resolvers.Add("ToolPathResolver.GetPackageExecutable(" +
                              $"{tool.PackageId.DoubleQuote()}, " +
                              $"{tool.PackageExecutable?.DoubleQuote() ?? "GetPackageExecutable()"})");
            }

            if (tool.PathExecutable != null)
                resolvers.Add($"ToolPathResolver.GetPathExecutable({tool.PathExecutable.DoubleQuote()})");

            if (resolvers.Count == 0)
                resolvers.Add("GetToolPath()");

            Trace.Assert(resolvers.Count == 1, "resolvers.Count == 1");

            return writer
                .WriteSummary($"Path to the {tool.Name} executable.")
                .WriteLine($"public static string {tool.Name}Path =>")
                .WriteLine($"    ToolPathResolver.TryGetEnvironmentExecutable(\"{tool.Name.ToUpperInvariant()}_EXE\") ??")
                .WriteLine($"    {resolvers.Single()};");
        }
    }
}
