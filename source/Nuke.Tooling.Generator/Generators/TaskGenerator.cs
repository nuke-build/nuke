// Copyright 2023 Maintainers of NUKE.
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
            if (tool.Tasks.Count == 0 && !tool.CustomExecutable && tool.PathExecutable == null && tool.NuGetPackageId == null)
                return;

            toolWriter
                .WriteSummary(tool)
                .WriteLine("[PublicAPI]")
                .WriteLine("[ExcludeFromCodeCoverage]")
                .WriteLineIfTrue(tool.NuGetPackageId != null, $"[NuGetPackageRequirement({tool.Name}PackageId)]")
                .WriteLineIfTrue(tool.NpmPackageId != null, $"[NpmPackageRequirement({tool.Name}PackageId)]")
                .WriteLineIfTrue(tool.AptGetPackageId != null, $"[AptGetPackageRequirement({tool.Name}PackageId)]")
                .WriteLineIfTrue(tool.PathExecutable != null, $"[PathToolRequirement({tool.Name}PathExecutable)]")
                .WriteLine($"public partial class {tool.GetClassName()}")
                .WriteLineIfTrue(tool.NuGetPackageId != null, "    : IRequireNuGetPackage")
                .WriteLineIfTrue(tool.NpmPackageId != null, "    : IRequireNpmPackage")
                .WriteLineIfTrue(tool.AptGetPackageId != null, "    : IRequireAptGetPackage")
                .WriteLineIfTrue(tool.PathExecutable != null, "    : IRequirePathTool")
                .WriteBlock(w =>
                {
                    w
                        .WriteLineIfTrue(tool.NuGetPackageId != null, $"public const string {tool.Name}PackageId = {tool.NuGetPackageId.DoubleQuote()};")
                        .WriteLineIfTrue(tool.NpmPackageId != null, $"public const string {tool.Name}PackageId = {tool.NpmPackageId.DoubleQuote()};")
                        .WriteLineIfTrue(tool.AptGetPackageId != null, $"public const string {tool.Name}PackageId = {tool.AptGetPackageId.DoubleQuote()};")
                        .WriteLineIfTrue(tool.PathExecutable != null, $"public const string {tool.Name}PathExecutable = {tool.PathExecutable.DoubleQuote()};")
                        .WriteToolPath()
                        .WriteToolLogger()
                        .WriteGenericTask();

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
                                 "ref ArgumentStringHandler arguments",
                                 "string workingDirectory = null",
                                 "IReadOnlyDictionary<string, string> environmentVariables = null",
                                 "int? timeout = null",
                                 "bool? logOutput = null",
                                 "bool? logInvocation = null",
                                 "Action<OutputType, string> customLogger = null"
                             };
            var arguments = new[]
                            {
                                $"{tool.Name}Path",
                                "ref arguments",
                                "workingDirectory",
                                "environmentVariables",
                                "timeout",
                                "logOutput",
                                "logInvocation",
                                $"customLogger ?? {tool.Name}Logger"
                            };
            writer
                .WriteSummary(tool)
                .WriteObsoleteAttributeWhenObsolete(tool)
                .WriteLine($"public static IReadOnlyCollection<Output> {tool.Name}({parameters.JoinCommaSpace()})")
                .WriteBlock(w => w
                    .WriteLine($"using var process = ProcessTasks.StartProcess({arguments.JoinCommaSpace()});")
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
                .WriteRemarks(task)
                .WriteObsoleteAttributeWhenObsolete(task)
                .WriteLine($"public static {returnType} {task.GetTaskMethodName()}({task.SettingsClass.Name} toolSettings = null)")
                .WriteBlock(w => w
                    .WriteLine($"toolSettings = toolSettings ?? new {task.SettingsClass.Name}();")
                    .WriteLineIfTrue(task.PreProcess, "PreProcess(ref toolSettings);")
                    .WriteLine($"using var process = {GetProcessStart(task)};")
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
                .WriteRemarks(task)
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

            var parameters = new[]
                             {
                                 $"CombinatorialConfigure<{task.SettingsClass.Name}> configurator",
                                 "int degreeOfParallelism = 1",
                                 "bool completeOnFailure = false"
                             }.JoinCommaSpace();

            return writer
                .WriteSummary(task)
                .WriteRemarks(task)
                .WriteObsoleteAttributeWhenObsolete(task)
                .WriteLine($"public static {returnType} {task.GetTaskMethodName()}({parameters})")
                .WriteBlock(w => w
                    .WriteLine(
                        $"return configurator.Invoke({task.GetTaskMethodName()}, {task.Tool.Name}Logger, degreeOfParallelism, completeOnFailure);"));
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

            if (tool.NuGetPackageId != null && tool.PackageExecutable != null)
            {
                resolvers.Add("NuGetToolPathResolver.GetPackageExecutable(" +
                              $"{tool.NuGetPackageId.DoubleQuote()}, " +
                              $"{tool.PackageExecutable.DoubleQuote()})");
            }

            if (tool.NpmPackageId != null && tool.PackageExecutable != null)
            {
                resolvers.Add($"NpmToolPathResolver.GetNpmExecutable({tool.PackageExecutable.DoubleQuote()})");
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

        private static ToolWriter WriteToolLogger(this ToolWriter writer)
        {
            var tool = writer.Tool;
            var logger = tool.CustomLogger ? "CustomLogger" : "ProcessTasks.DefaultLogger";
            return writer
                .WriteLine($"public static Action<OutputType, string> {tool.Name}Logger {{ get; set; }} = {logger};");
        }
    }
}
