// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        private const string BUILD_PROJECT_FILE = nameof(BUILD_PROJECT_FILE);
        private const string TEMP_DIRECTORY = nameof(TEMP_DIRECTORY);
        private const string DOTNET_GLOBAL_FILE = nameof(DOTNET_GLOBAL_FILE);
        private const string DOTNET_INSTALL_URL = nameof(DOTNET_INSTALL_URL);
        private const string DOTNET_CHANNEL = nameof(DOTNET_CHANNEL);

        [UsedImplicitly]
        public static int GetConfiguration(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            var configuration = GetConfiguration(buildScript.NotNull(), evaluate: false);

            Host.Information($"Configuration from {buildScript}:");
            configuration.ForEach(x => Console.WriteLine($"{x.Key} = {x.Value}"));

            return 0;
        }

        private static Dictionary<string, string> GetConfiguration(AbsolutePath buildScript, bool evaluate)
        {
            string ReplaceScriptDirectory(string value)
                => evaluate
                    ? value
                        .Replace("$SCRIPT_DIR", buildScript.Parent)
                        .Replace("$PSScriptRoot", buildScript.Parent)
                    : value;

            return File.ReadAllLines(buildScript)
                .SkipWhile(x => !x.StartsWithOrdinalIgnoreCase("# CONFIGURATION"))
                .TakeWhile(x => !x.StartsWithOrdinalIgnoreCase("# EXECUTION"))
                .Where(x => !x.IsNullOrEmpty() && !x.StartsWithAny("#", "export ", "$env:"))
                .Select(ReplaceScriptDirectory)
                .Select(x => x.Split("="))
                .ToDictionary(
                    x => x.ElementAt(0).TrimStart("$").Trim().SplitCamelHumpsWithKnownWords().JoinUnderscore().ToUpperInvariant(),
                    x => x.ElementAt(1).Trim().TrimMatchingDoubleQuotes());
        }
    }
}
