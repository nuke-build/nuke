// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class ToolPathResolver
    {
        [CanBeNull]
        public static string TryGetEnvironmentExecutable(string environmentExecutable)
        {
            var environmentExecutablePath = EnvironmentInfo.GetVariable(environmentExecutable);
            if (environmentExecutablePath == null)
                return null;

            Assert.FileExists(environmentExecutablePath,
                $"Path '{environmentExecutablePath}' from environment variable '{environmentExecutable}' does not exist");
            return environmentExecutablePath;
        }

        public static string GetPathExecutable(string pathExecutable)
        {
            if (File.Exists(pathExecutable))
                return Path.GetFullPath(pathExecutable);

            var locateExecutable = EnvironmentInfo.IsWin
                ? @"C:\Windows\System32\where.exe"
                : "/usr/bin/which";

            if (!File.Exists(locateExecutable))
            {
                string GetExecutableFullPath(string path)
                    => Path.Combine(path,
                        Path.GetExtension(pathExecutable).IsNullOrEmpty() && EnvironmentInfo.IsWin
                            ? $"{pathExecutable}.exe"
                            : pathExecutable);

                var environmentVariable = Environment.GetEnvironmentVariable("PATH").NotNullOrEmpty("PATH variable not available");
                var paths = environmentVariable.Split(new[] { Path.PathSeparator }, StringSplitOptions.RemoveEmptyEntries);
                return paths.Select(GetExecutableFullPath).FirstOrDefault(File.Exists).NotNull($"Could not find '{pathExecutable}' on the PATH.");
            }

            var locateProcess = ProcessTasks.StartProcess(
                locateExecutable,
                pathExecutable,
                logOutput: false,
                logInvocation: false);
            locateProcess.AssertWaitForExit();

            return locateProcess.Output
                .Select(x => x.Text)
                .Where(x => EnvironmentInfo.IsWin && Path.HasExtension(x) || EnvironmentInfo.IsUnix)
                .FirstOrDefault(File.Exists)
                .NotNull($"Could not find '{pathExecutable}' via '{locateExecutable}'.");
        }
    }
}
