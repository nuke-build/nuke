// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling
{
    internal class ProcessManager : IProcessManager
    {
        public static IProcessManager Instance { get; private set; } = new ProcessManager();

        public CapturedProcessStartInfo CaptureProcessStartInfo(Action action)
        {
            var fakeProcessManager = new CapturingProcessManager();
            using (DelegateDisposable.CreateBracket(
                () => Instance = fakeProcessManager,
                () => Instance = this))
            {
                action();
                return fakeProcessManager.CapturedProcessStartInfo;
            }
        }

        public virtual IProcess StartProcess(ToolSettings toolSettings)
        {
            var toolPath = toolSettings.ToolPath;
            var arguments = toolSettings.GetArguments();
            var argumentsForExecution = arguments.RenderForExecution();
            var argumentsForOutput = arguments.RenderForOutput();

#if NETCORE
            if (EnvironmentInfo.IsUnix && toolPath.EndsWithOrdinalIgnoreCase("exe"))
            {
                argumentsForExecution = $"{toolPath.DoubleQuoteIfNeeded()} {argumentsForExecution}";
                argumentsForOutput = $"{toolPath.DoubleQuoteIfNeeded()} {argumentsForOutput}";
                toolPath = ToolPathResolver.GetPathExecutable("mono");
            }
#endif

            ControlFlow.Assert(toolPath != null, "ToolPath was not set.");
            ControlFlow.Assert(File.Exists(toolPath), $"ToolPath '{toolPath}' does not exist.");
            Logger.Info($"> {Path.GetFullPath(toolPath).DoubleQuoteIfNeeded()} {argumentsForOutput}");

            return StartProcessInternal(
                toolPath,
                argumentsForExecution,
                toolSettings.WorkingDirectory,
                toolSettings.EnvironmentVariables,
                toolSettings.ExecutionTimeout,
                toolSettings.LogOutput,
                arguments.Filter);
        }

        public virtual IProcess StartProcess(
            string toolPath,
            string arguments = null,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool logOutput = true,
            Func<string, string> outputFilter = null)
        {
            ControlFlow.Assert(toolPath != null, "ToolPath was not set.");
            if (!Path.IsPathRooted(toolPath) && !toolPath.Contains(Path.DirectorySeparatorChar))
                toolPath = ToolPathResolver.GetPathExecutable(toolPath);

            ControlFlow.Assert(File.Exists(toolPath), $"ToolPath '{toolPath}' does not exist.");
            Logger.Info($"> {Path.GetFullPath(toolPath).DoubleQuoteIfNeeded()} {arguments}");

            return StartProcessInternal(toolPath,
                arguments,
                workingDirectory,
                environmentVariables,
                timeout,
                logOutput,
                outputFilter ?? (x => x));
        }

        // TODO: add default values
        internal static IProcess StartProcessInternal(
            string toolPath,
            [CanBeNull] string arguments,
            [CanBeNull] string workingDirectory,
            [CanBeNull] IReadOnlyDictionary<string, string> environmentVariables,
            int? timeout,
            bool logOutput,
            [CanBeNull] Func<string, string> outputFilter)
        {
            ControlFlow.Assert(workingDirectory == null || Directory.Exists(workingDirectory),
                $"WorkingDirectory '{workingDirectory}' does not exist.");

            var startInfo = new ProcessStartInfo
                            {
                                FileName = toolPath,
                                Arguments = arguments ?? string.Empty,
                                WorkingDirectory = workingDirectory ?? string.Empty,
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                UseShellExecute = false
                            };

            ApplyEnvironmentVariables(environmentVariables, startInfo);
            if (NukeBuild.Instance?.CheckPath == true)
            {
                PrintEnvironmentVariables(startInfo);
                CheckPathEnvironmentVariable(startInfo);
            }

            var process = Process.Start(startInfo);
            if (process == null)
                return null;

            var output = GetOutputCollection(process, logOutput, outputFilter);
            return new Process2(process, timeout, output);
        }

        private static void ApplyEnvironmentVariables(
            [CanBeNull] IReadOnlyDictionary<string, string> environmentVariables,
            ProcessStartInfo startInfo)
        {
            if (environmentVariables == null)
                return;

            startInfo.Environment.Clear();

            foreach (var pair in environmentVariables)
                startInfo.Environment[pair.Key] = pair.Value;
        }

        private static BlockingCollection<Output> GetOutputCollection(Process process, bool logOutput, Func<string, string> outputFilter)
        {
            var output = new BlockingCollection<Output>();

            process.OutputDataReceived += (s, e) =>
            {
                if (e.Data == null)
                    return;
                
                output.Add(new Output { Text = e.Data, Type = OutputType.Std });
                
                if (logOutput)
                    Logger.Log(outputFilter(e.Data));
            };
            process.ErrorDataReceived += (s, e) =>
            {
                if (e.Data == null)
                    return;
                
                output.Add(new Output { Text = e.Data, Type = OutputType.Err });
                
                if (logOutput)
                    Logger.Error(outputFilter(e.Data));
            };
            
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return output;
        }

        private static void PrintEnvironmentVariables(ProcessStartInfo startInfo)
        {
            void TraceItem(string key, string value) => Logger.Trace($"  - {key} = {value}");

            Logger.Trace("Environment variables:");

            foreach (var pair in startInfo.Environment.OrderBy(x => x.Key, StringComparer.OrdinalIgnoreCase))
            {
                if (pair.Key.EqualsOrdinalIgnoreCase("path"))
                {
                    var paths = pair.Value.Split(';');
                    var padding = paths.Length.ToString().Length;

                    for (var i = 0; i < paths.Length; i++)
                        TraceItem($"{pair.Key}[{i.ToString().PadLeft(padding, paddingChar: '0')}]", paths[i]);
                }
                else
                {
                    TraceItem(pair.Key, pair.Value);
                }
            }
        }

        private static void CheckPathEnvironmentVariable(ProcessStartInfo startInfo)
        {
            startInfo.Environment
                .SingleOrDefault(x => x.Key.EqualsOrdinalIgnoreCase("path"))
                .Value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => !Directory.Exists(x))
                .ForEach(x => Logger.Warn($"Path environment variable contains invalid or inaccessible path '{x}'."));
        }
    }
}
