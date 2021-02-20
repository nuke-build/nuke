// Copyright 2019 Maintainers of NUKE.
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

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class ProcessTasks
    {
        public static bool DefaultLogOutput = true;
        public static bool DefaultLogInvocation = true;
        public static bool DefaultLogTimestamp = false;
        public static bool LogWorkingDirectory = true;

        private static readonly char[] s_pathSeparators = { EnvironmentInfo.IsWin ? ';' : ':' };

        public static IProcess StartShell(
            string command,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool? logOutput = null,
            bool? logInvocation = null,
            bool? logTimestamp = null,
            string logFile = null,
            Action<OutputType, string> customLogger = null,
            Func<string, string> outputFilter = null)
        {
            return StartProcess(
                toolPath: ToolPathResolver.GetPathExecutable(EnvironmentInfo.IsWin ? "cmd" : "bash"),
                arguments: $"{(EnvironmentInfo.IsWin ? "/c" : "-c")} {command.DoubleQuote()}",
                workingDirectory,
                environmentVariables,
                timeout,
                logOutput,
                logInvocation,
                logTimestamp,
                logFile,
                customLogger,
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
                toolSettings.ProcessLogTimestamp,
                toolSettings.ProcessLogFile,
                toolSettings.ProcessCustomLogger,
                arguments.FilterSecrets);
        }

        public static IProcess StartProcess(
            string toolPath,
            string arguments = null,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool? logOutput = null,
            bool? logInvocation = null,
            bool? logTimestamp = null,
            string logFile = null,
            Action<OutputType, string> customLogger = null,
            Func<string, string> outputFilter = null)
        {
            ControlFlow.Assert(toolPath != null, "ToolPath was not set.");
            if (!Path.IsPathRooted(toolPath) && !toolPath.Contains(Path.DirectorySeparatorChar))
                toolPath = ToolPathResolver.GetPathExecutable(toolPath);

            var toolPathOverride = GetToolPathOverride(toolPath);
            if (!string.IsNullOrEmpty(toolPathOverride))
            {
                arguments = $"{toolPath.DoubleQuoteIfNeeded()} {arguments}".TrimEnd();
                toolPath = toolPathOverride;
            }

            outputFilter ??= x => x;
            ControlFlow.Assert(File.Exists(toolPath), $"ToolPath '{toolPath}' does not exist.");
            if (logInvocation ?? DefaultLogInvocation)
            {
                Logger.Info($"> {Path.GetFullPath(toolPath).DoubleQuoteIfNeeded()} {outputFilter(arguments)}");
                if (LogWorkingDirectory && workingDirectory != null)
                    Logger.Info($"@ {workingDirectory}");
            }

            return StartProcessInternal(toolPath,
                arguments,
                workingDirectory,
                environmentVariables,
                timeout,
                logTimestamp ?? DefaultLogTimestamp,
                logFile,
                logOutput ?? DefaultLogOutput
                    ? customLogger ?? DefaultLogger
                    : null,
                outputFilter);
        }

        [CanBeNull]
        private static string GetToolPathOverride(string toolPath)
        {
            if (toolPath.EndsWithOrdinalIgnoreCase(".dll"))
            {
                return ToolPathResolver.TryGetEnvironmentExecutable("DOTNET_EXE") ??
                       ToolPathResolver.GetPathExecutable("dotnet");
            }

#if NETCORE
            if (EnvironmentInfo.IsUnix &&
                toolPath.EndsWithOrdinalIgnoreCase(".exe") &&
                !EnvironmentInfo.IsWsl)
                return ToolPathResolver.GetPathExecutable("mono");
#endif

            return null;
        }

        // TODO: add default values
        [CanBeNull]
        private static IProcess StartProcessInternal(
            string toolPath,
            [CanBeNull] string arguments,
            [CanBeNull] string workingDirectory,
            [CanBeNull] IReadOnlyDictionary<string, string> environmentVariables,
            int? timeout,
            bool logTimestamp,
            [CanBeNull] string logFile,
            [CanBeNull] Action<OutputType, string> logger,
            Func<string, string> outputFilter)
        {
            ControlFlow.Assert(workingDirectory == null || Directory.Exists(workingDirectory),
                $"WorkingDirectory '{workingDirectory}' does not exist.");

            var startInfo = new ProcessStartInfo
                            {
                                FileName = toolPath,
                                Arguments = arguments ?? string.Empty,
                                WorkingDirectory = workingDirectory ?? EnvironmentInfo.WorkingDirectory,
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                UseShellExecute = false,
                                StandardErrorEncoding = Encoding.UTF8,
                                StandardOutputEncoding = Encoding.UTF8
                            };

            ApplyEnvironmentVariables(environmentVariables, startInfo);
            // PrintEnvironmentVariables(startInfo);

            var process = Process.Start(startInfo);
            if (process == null)
                return null;

            var logStream = logFile != null ? new StreamWriter(File.Open(logFile, FileMode.Create)) : null;
            var output = GetOutputCollection(process, logTimestamp, logger, logStream, outputFilter);
            return new Process2(process, outputFilter, timeout, logStream, output);
        }

        private static void ApplyEnvironmentVariables(
            [CanBeNull] IReadOnlyDictionary<string, string> environmentVariables,
            ProcessStartInfo startInfo)
        {
            if (environmentVariables == null)
                return;

            startInfo.Environment.Clear();

            foreach (var (key, value) in environmentVariables)
                startInfo.Environment[key] = value;
        }

        private static BlockingCollection<Output> GetOutputCollection(
            Process process,
            bool logTimestamp,
            [CanBeNull] Action<OutputType, string> logger,
            [CanBeNull] StreamWriter logFile,
            Func<string, string> outputFilter)
        {
            var output = new BlockingCollection<Output>();

            string GetProcessedOutput(string data)
                => logTimestamp
                    ? $"{DateTime.Now.ToLongTimeString()} {outputFilter.Invoke(data)}"
                    : outputFilter.Invoke(data);

            process.OutputDataReceived += (_, e) =>
            {
                if (e.Data == null)
                    return;

                output.Add(new Output { Text = e.Data, Type = OutputType.Std });

                var processedOutput = GetProcessedOutput(e.Data);
                logFile?.WriteLine($"[STD] {processedOutput}");
                logger?.Invoke(OutputType.Std, processedOutput);
            };
            process.ErrorDataReceived += (_, e) =>
            {
                if (e.Data == null)
                    return;

                output.Add(new Output { Text = e.Data, Type = OutputType.Err });

                var processedOutput = GetProcessedOutput(e.Data);
                logFile?.WriteLine($"[ERR] {processedOutput}");
                logger?.Invoke(OutputType.Err, processedOutput);
            };

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return output;
        }

        public static void DefaultLogger(OutputType type, string output)
        {
            if (type == OutputType.Std)
                Logger.Normal(output);
            else
                Logger.Error(output);
        }

        private static void PrintEnvironmentVariables(ProcessStartInfo startInfo)
        {
            static void TraceItem(string key, string value) => Logger.Trace($"  - {key} = {value}");

            Logger.Trace("Environment variables:");

            foreach (var (key, value) in startInfo.Environment.OrderBy(x => x.Key, StringComparer.OrdinalIgnoreCase))
            {
                if (key.EqualsOrdinalIgnoreCase("path"))
                {
                    var paths = value.Split(s_pathSeparators);
                    var padding = paths.Length.ToString().Length;

                    for (var i = 0; i < paths.Length; i++)
                        TraceItem($"{key}[{i.ToString().PadLeft(padding, paddingChar: '0')}]", paths[i]);
                }
                else
                {
                    TraceItem(key, value);
                }
            }
        }

        public static void CheckPathEnvironmentVariable()
        {
            if (Logger.LogLevel >= LogLevel.Normal)
                return;

            EnvironmentInfo.Variables
                .SingleOrDefault(x => x.Key.EqualsOrdinalIgnoreCase("path"))
                .Value.Split(s_pathSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(EnvironmentInfo.ExpandVariables)
                .Where(x => !Directory.Exists(x))
                .ForEach(x => Logger.Warn($"Path environment variable contains invalid or inaccessible path '{x}'."));
        }
    }
}
