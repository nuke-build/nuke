// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common
{
    public static partial class EnvironmentInfo
    {
        public static string NewLine => Environment.NewLine;
        public static string MachineName => Environment.MachineName;

        public static string WorkingDirectory
#if NETCORE
            => Directory.GetCurrentDirectory();
#else
            => Environment.CurrentDirectory;
#endif

        public static string ExpandVariables(string value)
        {
            string ExpandUnixEnvironmentVariables()
            {
                var regex = new Regex(@"\$([a-z_][a-z0-9_]*)", RegexOptions.IgnoreCase);
                return regex.Replace(value, x => Environment.GetEnvironmentVariable(x.Groups[1].Value));
            }

            return IsWin
                ? Environment.ExpandEnvironmentVariables(value)
                : ExpandUnixEnvironmentVariables();
        }

        internal static Dictionary<string, string> GetVariables()
        {
            var environmentVariables = Environment.GetEnvironmentVariables()
                .ToGeneric<string, string>(StringComparer.CurrentCulture);

            var groups = environmentVariables.GroupBy(x => x.Key, StringComparer.OrdinalIgnoreCase).ToList();
            foreach (var group in groups.Where(x => x.Count() > 1))
                Logger.Warn($"Environment variable '{group.Key}' exists multiple times with different casing. Falling back to case-sensitive.");

            return groups.Any(x => x.Count() > 1)
                ? environmentVariables
                : new Dictionary<string, string>(environmentVariables, StringComparer.OrdinalIgnoreCase);
        }
        private static Lazy<Dictionary<string, string>> s_variables = new Lazy<Dictionary<string, string>>(GetVariables);

        public static IReadOnlyDictionary<string, string> Variables => s_variables.Value.AsReadOnly();

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

        public static string[] ParseCommandLineArguments(string commandLine)
        {
            var inSingleQuotes = false;
            var inDoubleQuotes = false;
            var escaped = false;
            return commandLine.Split(x =>
                {
                    if (x == '\"' && !inSingleQuotes && !escaped)
                        inDoubleQuotes = !inDoubleQuotes;

                    if (x == '\'' && !inDoubleQuotes && !escaped)
                        inSingleQuotes = !inSingleQuotes;

                    escaped = x == '\\' && !escaped;

                    return x == ' ' && !(inDoubleQuotes || inSingleQuotes);
                })
                .Select(x => x.Trim().TrimMatchingDoubleQuotes().TrimMatchingQuotes().Replace("\\\"", "\"").Replace("\\\'", "'"))
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
        }
    }
}
