// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common
{
    public static partial class EnvironmentInfo
    {
        public static string NewLine => Environment.NewLine;
        public static string MachineName => Environment.MachineName;

        public static AbsolutePath WorkingDirectory
        {
#if NETCORE
            get => (AbsolutePath) Directory.GetCurrentDirectory();
            set => Directory.SetCurrentDirectory(value);
#else
            get => (AbsolutePath) Environment.CurrentDirectory;
            set => Environment.CurrentDirectory = value;
#endif
        }

        public static IDisposable SwitchWorkingDirectory(string workingDirectory, bool allowCreate = true)
        {
            if (allowCreate)
                FileSystemTasks.EnsureExistingDirectory(workingDirectory);

            var previousWorkingDirectory = WorkingDirectory;
            return DelegateDisposable.CreateBracket(
                () => WorkingDirectory = (AbsolutePath) workingDirectory,
                () => WorkingDirectory = previousWorkingDirectory);
        }

        public static string ExpandVariables(string value)
        {
            string ExpandUnixEnvironmentVariables()
                => value
                    .ReplaceRegex("^~", _ => Environment.GetEnvironmentVariable("HOME"))
                    .ReplaceRegex(@"\$([a-z_][a-z0-9_]*)", x => Environment.GetEnvironmentVariable(x.Groups[1].Value), RegexOptions.IgnoreCase);

            return IsWin
                ? Environment.ExpandEnvironmentVariables(value)
                : ExpandUnixEnvironmentVariables();
        }

        public static IReadOnlyDictionary<string, string> Variables
            => Environment.GetEnvironmentVariables().ToGeneric<string, string>(StringComparer.CurrentCulture);

        public static string[] CommandLineArguments { get; } = GetSurrogateArguments() ?? Environment.GetCommandLineArgs();

        private const string c_nukeTmpFileName = "nuke.tmp";

        [CanBeNull]
        private static string[] GetSurrogateArguments()
        {
            var entryAssemblyLocation = Assembly.GetEntryAssembly()?.Location;
            if (entryAssemblyLocation == null)
                return null;

            var assemblyDirectory = Path.GetDirectoryName(entryAssemblyLocation).NotNull();
            var argumentsFile = Path.Combine(assemblyDirectory, c_nukeTmpFileName);
            if (!File.Exists(argumentsFile))
                return null;

            var argumentLines = File.ReadAllLines(argumentsFile);
            var lastWriteTime = File.GetLastWriteTime(argumentsFile);

            ControlFlow.Assert(argumentLines.Length == 1, $"{c_nukeTmpFileName} must have only one single line");
            File.Delete(argumentsFile);
            if (lastWriteTime.AddMinutes(value: 1) < DateTime.Now)
            {
                Logger.Warn($"Last write time of '{c_nukeTmpFileName}' was '{lastWriteTime}'. Skipping...");
                return null;
            }

            var splittedArguments = ParseCommandLineArguments(argumentLines.Single());
            return new[] { entryAssemblyLocation }.Concat(splittedArguments).ToArray();
        }

        internal static string[] ParseCommandLineArguments(string commandLine)
        {
            var inSingleQuotes = false;
            var inDoubleQuotes = false;
            var escaped = false;
            return commandLine.Split((c, _) =>
                    {
                        if (c == '\"' && !inSingleQuotes && !escaped)
                            inDoubleQuotes = !inDoubleQuotes;

                        if (c == '\'' && !inDoubleQuotes && !escaped)
                            inSingleQuotes = !inSingleQuotes;

                        escaped = c == '\\' && !escaped;

                        return c == ' ' && !(inDoubleQuotes || inSingleQuotes);
                    },
                    includeSplitCharacter: true)
                .Select(x => x.Trim().TrimMatchingDoubleQuotes().TrimMatchingQuotes().Replace("\\\"", "\"").Replace("\\\'", "'"))
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
        }
    }
}
