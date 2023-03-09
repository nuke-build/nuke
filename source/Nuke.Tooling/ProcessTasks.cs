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

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class ProcessTasks
    {
        public static bool DefaultLogOutput = true;
        public static bool DefaultLogInvocation = true;
        public static bool LogWorkingDirectory = true;

        private static readonly char[] s_pathSeparators = { EnvironmentInfo.IsWin ? ';' : ':' };

        public static IProcess StartShell(
            string command,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool? logOutput = null,
            bool? logInvocation = null,
            Action<OutputType, string> customLogger = null,
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
                toolSettings.ProcessCustomLogger,
                arguments.FilterSecrets);
        }

#if NET6_0_OR_GREATER

        internal static IProcess StartProcess(
            string toolPath,
            ref ArgumentStringHandler arguments,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool? logOutput = null,
            bool? logInvocation = null,
            Action<OutputType, string> customLogger = null)
        {
            static Func<string, string> GetOutputFilterForArgumentStringHandler(ref ArgumentStringHandler arguments)
            {
                var redactedValues = arguments.SecretValues;
                return x => redactedValues.Aggregate(x, (arguments, value) => arguments.ReplaceRegex(value, _ => Arguments.Redacted));
            }

            return StartProcess(
                toolPath,
                arguments.ToStringAndClear(),
                workingDirectory,
                environmentVariables,
                timeout,
                logOutput,
                logInvocation,
                customLogger,
                GetOutputFilterForArgumentStringHandler(ref arguments));
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
            Action<OutputType, string> customLogger = null,
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

            outputFilter ??= x => x;
            Assert.FileExists(toolPath);
            if (logInvocation ?? DefaultLogInvocation)
            {
                // TODO: logging additional
                Log.Information("> {ToolPath} {Arguments}", Path.GetFullPath(toolPath).DoubleQuoteIfNeeded(), outputFilter(arguments));
                if (LogWorkingDirectory && workingDirectory != null)
                    Log.Information("@ {WorkingDirectory}", workingDirectory);
            }

            return StartProcessInternal(toolPath,
                arguments,
                workingDirectory,
                environmentVariables,
                timeout,
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
            [CanBeNull] string arguments,
            [CanBeNull] string workingDirectory,
            [CanBeNull] IReadOnlyDictionary<string, string> environmentVariables,
            int? timeout,
            [CanBeNull] Action<OutputType, string> logger,
            Func<string, string> outputFilter)
        {
            Assert.True(workingDirectory == null || Directory.Exists(workingDirectory), $"WorkingDirectory '{workingDirectory}' does not exist");

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

            var output = GetOutputCollection(process, logger, outputFilter);
            return new Process2(process, outputFilter, timeout, output);
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
            [CanBeNull] Action<OutputType, string> logger,
            Func<string, string> outputFilter)
        {
            var output = new BlockingCollection<Output>();

            process.OutputDataReceived += (_, e) =>
            {
                if (e.Data == null)
                    return;

                output.Add(new Output { Text = e.Data, Type = OutputType.Std });

                var filteredOutput = outputFilter(e.Data);
                logger?.Invoke(OutputType.Std, filteredOutput);
            };
            process.ErrorDataReceived += (_, e) =>
            {
                if (e.Data == null)
                    return;

                output.Add(new Output { Text = e.Data, Type = OutputType.Err });

                var filteredOutput = outputFilter(e.Data);
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

        private static void PrintEnvironmentVariables(ProcessStartInfo startInfo)
        {
            static void TraceItem(string key, string value) => Log.Verbose($"  - {key} = {value}");

            // TODO: logging additional
            Log.Verbose("Environment variables:");

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
            EnvironmentInfo.Variables
                .SingleOrDefault(x => x.Key.EqualsOrdinalIgnoreCase("path"))
                .Value.Split(s_pathSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(EnvironmentInfo.ExpandVariables)
                .Where(x => !Directory.Exists(x))
                .ForEach(x => Log.Warning("Path environment variable contains invalid or inaccessible path {Path}", x));
        }
    }
}
