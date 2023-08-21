// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;
using Serilog.Events;

namespace Nuke.Common.Tooling;

[PublicAPI]
public static class ProcessTasks
{
    public static bool DefaultLogOutput = true;
    public static bool DefaultLogInvocation = true;
    public static bool LogWorkingDirectory = true;
    public static string DefaultWorkingDirectory = EnvironmentInfo.WorkingDirectory;

    private static readonly char[] s_pathSeparators = { EnvironmentInfo.IsWin ? ';' : ':' };
    private static readonly object s_lock = new();

    public static IProcess StartShell(
        string command,
        string workingDirectory = null,
        IReadOnlyDictionary<string, string> environmentVariables = null,
        int? timeout = null,
        bool? logOutput = null,
        bool? logInvocation = null,
        Action<OutputType, string> logger = null,
        Func<string, string> outputFilter = null)
    {
        // TODO: fallback to sh
        return StartProcess(
            toolPath: ToolPathResolver.GetPathExecutable(EnvironmentInfo.IsWin ? "cmd" : "bash"),
            arguments: $"{(EnvironmentInfo.IsWin ? "/c" : "-c")} {command.DoubleQuote()}",
            workingDirectory,
            environmentVariables,
            timeout,
            logOutput,
            logInvocation,
            logger,
            outputFilter);
    }

    public static IProcess StartProcess(ToolSettings toolSettings)
    {
        var arguments = toolSettings.GetProcessArguments();

        return StartProcess(
            toolSettings.ProcessToolPath,
            arguments.RenderForExecution(),
            toolSettings.ProcessWorkingDirectory,
            toolSettings.ProcessEnvironmentVariables,
            toolSettings.ProcessExecutionTimeout,
            toolSettings.ProcessLogOutput,
            toolSettings.ProcessLogInvocation,
            toolSettings.ProcessLogger,
            arguments.FilterSecrets);
    }

#if NET6_0_OR_GREATER

        public static IProcess StartProcess(
            string toolPath,
            ArgumentStringHandler arguments,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool? logOutput = null,
            bool? logInvocation = null,
            Action<OutputType, string> logger = null)
        {
            return StartProcess(
                toolPath,
                arguments.ToStringAndClear(),
                workingDirectory,
                environmentVariables,
                timeout,
                logOutput,
                logInvocation,
                logger,
                arguments.GetFilter());
        }

#endif

    public static IProcess StartProcess(
        string toolPath,
        string arguments = null,
        string workingDirectory = null,
        IReadOnlyDictionary<string, string> environmentVariables = null,
        int? timeout = null,
        bool? logOutput = null,
        bool? logInvocation = null,
        Action<OutputType, string> logger = null,
        Func<string, string> outputFilter = null)
    {
        Assert.True(toolPath != null);
        if (!Path.IsPathRooted(toolPath) && !toolPath.Contains(Path.DirectorySeparatorChar))
            toolPath = ToolPathResolver.GetPathExecutable(toolPath);

        var toolPathOverride = GetToolPathOverride(toolPath);
        if (!string.IsNullOrEmpty(toolPathOverride))
        {
            arguments = $"{toolPath.DoubleQuoteIfNeeded()} {arguments}".TrimEnd();
            toolPath = toolPathOverride;
        }

        return StartProcessInternal(
            toolPath,
            arguments ?? string.Empty,
            workingDirectory ?? DefaultWorkingDirectory,
            environmentVariables,
            timeout,
            logInvocation ?? DefaultLogInvocation,
            logOutput ?? DefaultLogOutput
                ? logger ?? DefaultLogger
                : null,
            outputFilter ?? (x => x));
    }

    [CanBeNull]
    private static string GetToolPathOverride(string toolPath)
    {
        if (toolPath.EndsWithOrdinalIgnoreCase(".dll"))
        {
            return ToolPathResolver.TryGetEnvironmentExecutable("DOTNET_EXE") ??
                   ToolPathResolver.GetPathExecutable("dotnet");
        }

        if (EnvironmentInfo.IsUnix &&
            toolPath.EndsWithOrdinalIgnoreCase(".exe") &&
            !EnvironmentInfo.IsWsl)
            return ToolPathResolver.GetPathExecutable("mono");

        return null;
    }

    // TODO: add default values
    [CanBeNull]
    private static IProcess StartProcessInternal(
        string toolPath,
        string arguments,
        string workingDirectory,
        [CanBeNull] IReadOnlyDictionary<string, string> environmentVariables,
        int? timeout,
        bool logInvocation,
        [CanBeNull] Action<OutputType, string> logger,
        Func<string, string> outputFilter)
    {
        Assert.FileExists(toolPath);
        Assert.DirectoryExists(workingDirectory);

        var startInfo = new ProcessStartInfo
                        {
                            FileName = toolPath,
                            Arguments = arguments ,
                            WorkingDirectory = workingDirectory,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            StandardErrorEncoding = Encoding.UTF8,
                            StandardOutputEncoding = Encoding.UTF8
                        };

        if (environmentVariables != null)
        {
            startInfo.Environment.Clear();
            foreach (var (key, value) in environmentVariables)
                startInfo.Environment[key] = value;
        }

        if (logInvocation)
            LogInvocation(startInfo, outputFilter, environmentVariables != null);

        var process = Process.Start(startInfo);
        if (process == null)
            return null;

        var output = GetOutputCollection(process, logger, outputFilter);
        return new Process2(process, outputFilter, timeout, output);
    }

    private static void LogInvocation(ProcessStartInfo startInfo, Func<string, string> outputFilter, bool hasEnvironmentVariables)
    {
        lock (s_lock)
        {
            // TODO: logging additional
            Log.Information("> {ToolPath} {Arguments}", startInfo.FileName.DoubleQuoteIfNeeded(), outputFilter(startInfo.Arguments));

            if (LogWorkingDirectory)
            {
                Log.Write(
                    startInfo.WorkingDirectory != DefaultWorkingDirectory
                        ? LogEventLevel.Information
                        : LogEventLevel.Verbose,
                    "@ {WorkingDirectory}",
                    startInfo.WorkingDirectory);
            }

            // if (hasEnvironmentVariables)
            //     PrintEnvironmentVariables(startInfo.Environment);
        }
    }

    private static BlockingCollection<Output> GetOutputCollection(
        Process process,
        [CanBeNull] Action<OutputType, string> logger,
        Func<string, string> outputFilter)
    {
        var output = new BlockingCollection<Output>();

        process.OutputDataReceived += (_, e) =>
        {
            if (e.Data == null)
                return;

            var filteredOutput = outputFilter(e.Data);
            output.Add(new Output { Text = filteredOutput, Type = OutputType.Std });
            logger?.Invoke(OutputType.Std, filteredOutput);
        };
        process.ErrorDataReceived += (_, e) =>
        {
            if (e.Data == null)
                return;

            var filteredOutput = outputFilter(e.Data);
            output.Add(new Output { Text = filteredOutput, Type = OutputType.Err });
            logger?.Invoke(OutputType.Err, filteredOutput);
        };

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        return output;
    }

    public static void DefaultLogger(OutputType type, string output)
    {
        if (type == OutputType.Std)
            Log.Debug(output);
        else
            Log.Error(output);
    }

    public static void DefaultExitHandler(ToolSettings toolSettings, IProcess process)
    {
        process.AssertZeroExitCode();
    }

    public static void PrintEnvironmentVariables()
    {
        PrintEnvironmentVariables(EnvironmentInfo.Variables.ToDictionary(x => x.Key, x => x.Value));
    }

    private static void PrintEnvironmentVariables(IDictionary<string, string> environmentVariables)
    {
        static IEnumerable<(string Key, string Value)> Split(KeyValuePair<string, string> pair)
        {
            var values = pair.Value.Split(s_pathSeparators, StringSplitOptions.RemoveEmptyEntries);
            var padding = values.Length.ToString().Length;

            return values.Length == 1
                ? new[] { (pair.Key, values.Single()) }
                : values.Select((x, i) => ($"{pair.Key}[{i.ToString().PadLeft(padding, paddingChar: '0')}]", x));
        }

        // TODO: logging additional
        environmentVariables
            .SelectMany(Split)
            .OrderBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
            .ForEach(x => Log.Verbose("$ {Key} = {Value}", x.Key, x.Value));
    }

    public static void CheckPathEnvironmentVariable()
    {
        EnvironmentInfo.Variables
            .SingleOrDefault(x => x.Key.EqualsOrdinalIgnoreCase("path"))
            .Value.Split(s_pathSeparators, StringSplitOptions.RemoveEmptyEntries)
            .Select(EnvironmentInfo.ExpandVariables)
            .Where(x => !Directory.Exists(x))
            .ForEach(x => Log.Warning("Path environment variable contains invalid or inaccessible path {Path}", x));
    }
}
