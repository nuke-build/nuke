// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Unity.Logging;
using Nuke.Common.Utilities;
using Nuke.Utilities.Text.Yaml;
using Serilog;
using Serilog.Events;

namespace Nuke.Common.Tools.Unity;

partial class UnityTasks
{
    [ThreadStatic]
    private static FileWatcher s_watcher;

    [ThreadStatic]
    private static LogParser s_logParser;

    private static bool s_minimalOutput;

    protected override string GetToolPath(ToolOptions options = null)
    {
        var unityOptions = options as UnityOptionsBase;
        var programFiles = EnvironmentInfo.IsWin
            ? EnvironmentInfo.SpecialFolder(EnvironmentInfo.Is32Bit ? SpecialFolders.ProgramFilesX86 : SpecialFolders.ProgramFiles)
            : null;
        return unityOptions?.HubVersion ?? GetEditorVersionFromProject() switch
        {
            { } version => EnvironmentInfo.Platform switch
            {
                PlatformFamily.Windows => $@"{programFiles}\Unity\Hub\Editor\{version}\Editor\Unity.exe",
                PlatformFamily.OSX => $"/Applications/Unity/Hub/Editor/{version}/Unity.app/Contents/MacOS/Unity",
                _ => throw new Exception($"Cannot determine Unity Hub installation path for '{version}'.")
            },
            null => EnvironmentInfo.Platform switch
            {
                PlatformFamily.Windows => $@"{programFiles}\Unity\Editor\Unity.exe",
                PlatformFamily.OSX => "/Applications/Unity/Unity.app/Contents/MacOS/Unity",
                _ => null
            }
        };

        string GetEditorVersionFromProject()
        {
            if (options is not UnitySettings projectOptions)
                return null;

            var projectVersionFile = (AbsolutePath)projectOptions.ProjectPath / "ProjectSettings" / "ProjectVersion.txt";
            var properties = projectVersionFile.ReadYaml<Dictionary<string, string>>();
            return properties["m_EditorVersion"];
        }
    }

    protected override ToolOptions PreProcess(ToolOptions options)
    {
        var unityOptions = (UnityOptionsBase)options;
        var logFile = (AbsolutePath)unityOptions.LogFile ?? NukeBuild.TemporaryDirectory / "unity.log";
        logFile.DeleteFile();

        s_minimalOutput = unityOptions.MinimalOutput ?? false;
        s_logParser = new LogParser(LogLine, LogBlockStart, LogBlockEnd);
        s_watcher = new FileWatcher(logFile, s_logParser.Log);
        s_watcher.Start();

        return options;
    }

    protected override IReadOnlyCollection<Output> Run<T>(ToolOptions options = null)
    {
        try
        {
            return base.Run<T>(options);
        }
        catch (Exception)
        {
            AssertWatcherStopped();
            throw;
        }
    }

    protected override Func<ToolOptions, IProcess, object> GetExitHandler(ToolOptions options)
    {
        var unityOptions = options as UnityOptionsBase;
        return (_, p) =>
        {
            AssertWatcherStopped();
            if (p.ExitCode == 0)
                return null;

            var message = new StringBuilder()
                .AppendLine($"Process '{Path.GetFileName(p.FileName)}' exited with code {p.ExitCode}. Verify the invocation.")
                .AppendLine($"> {p.FileName.DoubleQuoteIfNeeded()} {p.Arguments}")
                .ToString();

            if (unityOptions?.StableExitCodes.Any(x => x == p.ExitCode) ?? false)
                Log.Warning(message);
            else
                Assert.Fail(message);

            return null;
        };
    }

    private static void AssertWatcherStopped()
    {
        s_watcher?.AssertStopped();
        s_watcher = null;
    }

    private static void LogLine(string message, Logging.LogLevel logLevel)
    {
        Log.Write(
            logLevel switch
            {
                Logging.LogLevel.Normal => LogEventLevel.Debug,
                Logging.LogLevel.Warning => LogEventLevel.Warning,
                Logging.LogLevel.Error or Logging.LogLevel.Failure => LogEventLevel.Error,
                _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null)
            },
            message);
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
