﻿// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public static IReadOnlyDictionary<string, string> Variables
            => Environment.GetEnvironmentVariables()
                .ToGeneric<string, string>(StringComparer.OrdinalIgnoreCase)
                .AsReadOnly();

        public static string[] CommandLineArguments { get; } = GetSurrogateArguments() ?? Environment.GetCommandLineArgs();
        
        private const string c_nukeTmpFileName = "nuke.tmp";
        
        [CanBeNull]
        private static string[] GetSurrogateArguments()
        {
            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).NotNull();
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
            return new[] { Assembly.GetEntryAssembly().Location }.Concat(splittedArguments).ToArray();
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
                .Select(x => x.TrimMatchingDoubleQuotes().TrimMatchingQuotes().Replace("\\\"", "\"").Replace("\\\'", "'"))
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
        }
    }
}
