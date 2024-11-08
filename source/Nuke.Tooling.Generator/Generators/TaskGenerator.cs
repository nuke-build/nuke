// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.CodeGeneration.Model;
using Nuke.CodeGeneration.Writers;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

// ReSharper disable UnusedMethodReturnValue.Local

namespace Nuke.CodeGeneration.Generators;

public static class TaskGenerator
{
    public static void Run(Tool tool, ToolWriter toolWriter)
    {
        if (tool.Tasks.Count == 0 && !tool.CustomExecutable && tool.PathExecutable == null && tool.NuGetPackageId == null)
            return;

        var baseClasses = new[]
        {
            "ToolTasks",
            tool.PathExecutable?.Apply(_ => "IRequirePathTool"),
            tool.NuGetPackageId?.Apply(_ => "IRequireNuGetPackage"),
            tool.AptGetPackageId?.Apply(_ => "IRequireAptGetPackage"),
            tool.NpmPackageId?.Apply(_ => "IRequireNpmPackage"),
        }.WhereNotNull();

        toolWriter
            .WriteSummary(tool)
            .WriteLine("[PublicAPI]")
            .WriteLine("[ExcludeFromCodeCoverage]")
            .WriteLineIfTrue(tool.NuGetPackageId != null, "[NuGetPackageRequirement(PackageId)]")
            .WriteLineIfTrue(tool.NuGetPackageId != null && tool.PackageExecutable == null, "[NuGetTool(Id = PackageId)]")
            .WriteLineIfTrue(tool.NuGetPackageId != null && tool.PackageExecutable != null, "[NuGetTool(Id = PackageId, Executable = PackageExecutable)]")
            .WriteLineIfTrue(tool.NpmPackageId != null, "[NpmPackageRequirement(PackageId)]")
            .WriteLineIfTrue(tool.AptGetPackageId != null, "[AptGetPackageRequirement(PackageId)]")
            .WriteLineIfTrue(tool.PathExecutable != null, "[PathToolRequirement(PathExecutable)]")
            .WriteLineIfTrue(tool.PathExecutable != null, "[PathTool(Executable = PathExecutable)]")
            .WriteLine($"public partial class {tool.GetClassName()} : {baseClasses.JoinCommaSpace()}")
            .WriteBlock(w =>
            {
                w
                    .WriteLine($"public static string {tool.Name}Path => new {tool.GetClassName()}().GetToolPath();")
                    .WriteLineIfTrue(tool.NuGetPackageId != null, $"public const string PackageId = {tool.NuGetPackageId.DoubleQuote()};")
                    .WriteLineIfTrue(tool.PackageExecutable != null, $"public const string PackageExecutable = {tool.PackageExecutable.DoubleQuote()};")
                    .WriteLineIfTrue(tool.NpmPackageId != null, $"public const string PackageId = {tool.NpmPackageId.DoubleQuote()};")
                    .WriteLineIfTrue(tool.AptGetPackageId != null, $"public const string PackageId = {tool.AptGetPackageId.DoubleQuote()};")
                    .WriteLineIfTrue(tool.PathExecutable != null, $"public const string PathExecutable = {tool.PathExecutable.DoubleQuote()};")
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
                             "ArgumentStringHandler arguments",
                             "string workingDirectory = null",
                             "IReadOnlyDictionary<string, string> environmentVariables = null",
                             "int? timeout = null",
                             "bool? logOutput = null",
                             "bool? logInvocation = null",
                             "Action<OutputType, string> logger = null",
                             "Func<IProcess, object> exitHandler = null"
                         };
        var arguments = new[]
                        {
                            "arguments",
                            "workingDirectory",
                            "environmentVariables",
                            "timeout",
                            "logOutput",
                            "logInvocation",
                            "logger",
                            "exitHandler"
                        };
        var signature = $"IReadOnlyCollection<Output> {tool.Name}({parameters.JoinCommaSpace()})";
        var invocation = $"new {tool.GetClassName()}().Run({arguments.JoinCommaSpace()})";
        writer
            .WriteSummary(tool)
            .WriteObsoleteAttributeWhenObsolete(tool)
            .WriteLine($"public static {signature} => {invocation};");
    }

    private static TaskWriter WriteToolSettingsTask(this TaskWriter writer)
    {
        var task = writer.Task;
        var returnType = !task.HasReturnValue()
            ? "IReadOnlyCollection<Output>"
            : $"({task.ReturnType} Result, IReadOnlyCollection<Output> Output)";
        var signature = $"{returnType} {task.GetTaskMethodName()}({task.SettingsClass.Name} options = null)";
        var invocation = !task.HasReturnValue()
            ? $"new {task.Tool.GetClassName()}().Run(options)"
            : $"new {task.Tool.GetClassName()}().Run<{task.ReturnType}>(options)";

        return writer
            .WriteSummary(task)
            .WriteRemarks(task)
            .WriteObsoleteAttributeWhenObsolete(task)
            .WriteLine($"public static {signature} => {invocation};");
    }

    private static TaskWriter WriteConfiguratorTask(this TaskWriter writer)
    {
        var task = writer.Task;
        var returnType = !task.HasReturnValue()
            ? "IReadOnlyCollection<Output>"
            : $"({task.ReturnType} Result, IReadOnlyCollection<Output> Output)";
        var signature = $"{returnType} {task.GetTaskMethodName()}(Configure<{task.SettingsClass.Name}> configurator)";
        var invocation = !task.HasReturnValue()
            ? $"new {task.Tool.GetClassName()}().Run(configurator.Invoke(new {task.SettingsClass.Name}()))"
            : $"new {task.Tool.GetClassName()}().Run<{task.ReturnType}>(configurator.Invoke(new {task.SettingsClass.Name}()))";

        return writer
            .WriteSummary(task)
            .WriteRemarks(task)
            .WriteObsoleteAttributeWhenObsolete(task)
            .WriteLine($"public static {signature} => {invocation};");
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
        var signature = $"{returnType} {task.GetTaskMethodName()}({parameters})";
        var invocation = $"configurator.Invoke({task.GetTaskMethodName()}, degreeOfParallelism, completeOnFailure)";

        return writer
            .WriteSummary(task)
            .WriteRemarks(task)
            .WriteObsoleteAttributeWhenObsolete(task)
            .WriteLine($"public static {signature} => {invocation};");
    }
}
