// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Unity.Logging;
using Nuke.Common.Utilities;
using Nuke.Utilities.Text.Yaml;
using Serilog;

namespace Nuke.Common.Tools.Unity
{
    public partial class UnityTasks
    {
        [ThreadStatic]
        private static FileWatcher s_watcher;

        [ThreadStatic]
        private static LogParser s_logParser;

        private static bool s_minimalOutput;

        public static string GetToolPath(string hubVersion = null)
        {
            return hubVersion != null
                ? GetToolPathViaHubVersion(hubVersion)
                : GetToolPathViaManualInstallation();
        }

        private static AbsolutePath GetToolPathViaManualInstallation()
        {
            return EnvironmentInfo.Platform switch
            {
                PlatformFamily.Windows => $@"{GetProgramFiles()}\Unity\Editor\Unity.exe",
                PlatformFamily.OSX => "/Applications/Unity/Unity.app/Contents/MacOS/Unity",
                _ => null
            };
        }

        private static AbsolutePath GetToolPathViaHubVersion(string version)
        {
            return EnvironmentInfo.Platform switch
            {
                PlatformFamily.Windows => $@"{GetProgramFiles()}\Unity\Hub\Editor\{version}\Editor\Unity.exe",
                PlatformFamily.OSX => $"/Applications/Unity/Hub/Editor/{version}/Unity.app/Contents/MacOS/Unity",
                _ => throw new Exception($"Cannot determine Unity Hub installation path for '{version}'.")
            };
        }

        private static string GetProgramFiles()
        {
            return EnvironmentInfo.SpecialFolder(
                EnvironmentInfo.Is32Bit
                    ? SpecialFolders.ProgramFilesX86
                    : SpecialFolders.ProgramFiles);
        }

        private static void PreProcess(ref UnitySettings unitySettings)
        {
            if (unitySettings.ProjectPath == null)
                Log.Warning("ProjectPath is not set, using last opened/built project");

            DetectUnityVersion(ref unitySettings);
            PreProcess<UnitySettings>(ref unitySettings);
        }

        private static void DetectUnityVersion(ref UnitySettings unitySettings)
        {
            if (unitySettings.HubVersion != null ||
                unitySettings.ProjectPath == null)
                return;

            var editorVersion = ReadUnityEditorVersion(unitySettings.ProjectPath);
            var hubToolPath = GetToolPathViaHubVersion(editorVersion);
            if (hubToolPath.Exists())
            {
                unitySettings.HubVersion = editorVersion;
                return;
            }

            var manualInstallationToolPath = GetToolPathViaManualInstallation();
            Assert.FileExists(manualInstallationToolPath, $"Required Unity Hub installation for version '{editorVersion}' was not found");
        }

        private static string ReadUnityEditorVersion(AbsolutePath projectPath)
        {
            var projectVersionFile = projectPath / "ProjectSettings" / "ProjectVersion.txt";
            var properties = projectVersionFile.ReadYaml<Dictionary<string, string>>();
            return properties["m_EditorVersion"];
        }

        private static void PreProcess<T>(ref T unitySettings)
            where T : UnityBaseSettings
        {
            if (File.Exists(unitySettings.GetLogFile()))
                File.Delete(unitySettings.GetLogFile());
            s_minimalOutput = unitySettings.MinimalOutput.GetValueOrDefault(defaultValue: false);
            s_logParser = new LogParser(LogLine, LogBlockStart, LogBlockEnd);
            s_watcher = new FileWatcher(unitySettings.GetLogFile(), s_logParser.Log);
            s_watcher.Start();
        }

        [CanBeNull]
        private static IProcess StartProcess(UnityBaseSettings unitySettings)
        {
            try
            {
                return ProcessTasks.StartProcess(unitySettings);
            }
            catch (Exception)
            {
                AssertWatcherStopped();
                throw;
            }
        }

        private static void AssertWatcherStopped()
        {
            s_watcher?.AssertStopped();
            s_watcher = null;
        }

        private static void AssertProcess(IProcess process, UnityBaseSettings settings)
        {
            process.AssertWaitForExit();
            AssertWatcherStopped();
            if (process.ExitCode == 0)
                return;

            var message = new StringBuilder()
                .AppendLine($"Process '{Path.GetFileName(process.FileName)}' exited with code {process.ExitCode}. Verify the invocation.")
                .AppendLine($"> {process.FileName.DoubleQuoteIfNeeded()} {process.Arguments}")
                .ToString();

            if (settings.StableExitCodes.Any(x => x == process.ExitCode))
                Log.Warning(message);
            else
                Assert.Fail(message);
        }

        private static void LogLine(string message, Logging.LogLevel logLevel)
        {
            switch (logLevel)
            {
                case Logging.LogLevel.Normal:
                    if (!s_minimalOutput)
                        Log.Debug(message);
                    break;
                case Logging.LogLevel.Warning:
                    Log.Warning(message);
                    break;
                case Logging.LogLevel.Error:
                case Logging.LogLevel.Failure:
                    Log.Error(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, message: null);
            }
        }

        private static void LogBlockEnd(MatchedBlock block)
        {
            Log.Debug("End: {Block}", block.Name.TrimEnd('\r', '\n'));
        }

        private static void LogBlockStart(MatchedBlock block)
        {
            Log.Debug("Start: {Block}", block.Name.TrimEnd('\r', '\n'));
        }
    }
}
