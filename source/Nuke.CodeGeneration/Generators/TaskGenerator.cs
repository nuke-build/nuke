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
                        .WriteMainTask()
                        .WriteTaskOverloads());
                });
        }

        private static TaskWriter WriteTaskOverloads(this TaskWriter writer, int index = 0)
        {
            var task = writer.Task;
            var properties = task.SettingsClass.Properties.Where(x => x.CreateOverload).Take(index + 1).ToList();

            if (properties.Count == 0 || index >= properties.Count)
                return writer;

            var additionalParameterDeclarations = properties.Select(x => $"{x.GetNullabilityAttribute()}{x.Type} {x.Name.ToInstance()}");
            var nextArguments = properties.AsEnumerable().Reverse().Skip(count: 1).Reverse().Select(x => x.Name.ToInstance());
            var currentArgument = properties.Last();
            var setter = $"x => configurator(x).Set{currentArgument.Name}({currentArgument.Name.ToInstance()})";
            var allArguments = nextArguments.Concat(new[] { setter });
            var taskCallPrefix = task.HasReturnValue() ? "return " : string.Empty;

            writer
                .WriteSummary(task)
                .WriteLine(GetTaskSignature(writer.Task, additionalParameterDeclarations))
                .WriteBlock(w => w
                    .WriteLine("configurator = configurator ?? (x => x);")
                    .WriteLine($"return {taskCallPrefix}{task.GetTaskMethodName()}({allArguments.JoinComma()});"));

            return writer.WriteTaskOverloads(index + 1);
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
                .WriteLine($"public static IReadOnlyCollection<Output> {tool.Name}({parameters.JoinComma()})")
                .WriteBlock(w => w
                    .WriteLine($"var process = ProcessTasks.StartProcess({arguments.JoinComma()});")
                    .WriteLine("process.AssertZeroExitCode();")
                    .WriteLine("return process.Output;"));
        }

        private static TaskWriter WriteMainTask(this TaskWriter writer)
        {
            return writer
                .WriteSummary(writer.Task)
                .WriteLine(GetTaskSignature(writer.Task))
                .WriteBlock(WriteMainTaskBlock);
        }

        private static string GetTaskSignature(Task task, IEnumerable<string> additionalParameterDeclarations = null)
        {
            var parameterDeclarations = new List<string>();
            parameterDeclarations.AddRange(additionalParameterDeclarations ?? new List<string>());
            parameterDeclarations.Add($"Configure<{task.SettingsClass.Name}> configurator = null");

            var returnType = task.HasReturnValue()
                ? $"({task.ReturnType} Result, IReadOnlyCollection<Output> Output)"
                : "IReadOnlyCollection<Output>";

            return $"public static {returnType} {task.GetTaskMethodName()}({parameterDeclarations.JoinComma()})";
        }

        private static void WriteMainTaskBlock(TaskWriter writer)
        {
            var task = writer.Task;
            writer
                .WriteLine($"var toolSettings = configurator.InvokeSafe(new {task.SettingsClass.Name}());")
                .WriteLineIfTrue(task.PreProcess, $"PreProcess(ref toolSettings);")
                .WriteLine($"var process = {GetProcessStart(task)};")
                .WriteLine(GetProcessAssertion(task))
                .WriteLineIfTrue(task.PostProcess, $"PostProcess(toolSettings);")
                .WriteLine(task.HasReturnValue()
                    ? "return (GetResult(process, toolSettings), process.Output);"
                    : "return process.Output;");
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

            if (tool.EnvironmentExecutable != null)
                resolvers.Add($"ToolPathResolver.GetEnvironmentExecutable({tool.EnvironmentExecutable.DoubleQuote()})");

            if (tool.PathExecutable != null)
                resolvers.Add($"ToolPathResolver.GetPathExecutable({tool.PathExecutable.DoubleQuote()})");

            if (resolvers.Count == 0)
                resolvers.Add("GetToolPath()");

            Trace.Assert(resolvers.Count == 1, "resolvers.Count == 1");

            return writer
                .WriteSummary($"Path to the {tool.Name} executable.")
                .WriteLine($"public static string {tool.Name}Path => {resolvers.Single()};");
        }
    }
}
