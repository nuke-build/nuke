// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Utilities.Text.Yaml;
using static Nuke.Common.Constants;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        private const string CommandName = "nuke";

        [UsedImplicitly]
        public static int Complete(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            if (rootDirectory == null)
                return 0;

            var words = args.Single();
            if (!words.StartsWithOrdinalIgnoreCase(CommandName))
                return 0;

            words = words.Substring(CommandName.Length).TrimStart();

            var buildSchemaFile = GetBuildSchemaFile(rootDirectory);
            var completionFile = GetCompletionFile(rootDirectory);
            if (!buildSchemaFile.Exists() && !completionFile.Exists())
            {
                Build(buildScript.NotNull(), $"--{CompletionParameterName}");
                return 1;
            }

            var position = EnvironmentInfo.GetNamedArgument<int?>("position");
            var completionItems = IsLegacy(rootDirectory)
                ? completionFile.ReadYaml<Dictionary<string, string[]>>()
                : CompletionUtility.GetItemsFromSchema(buildSchemaFile, GetProfileNames(rootDirectory));
            foreach (var item in CompletionUtility.GetRelevantItems(words, completionItems))
                Console.WriteLine(item);

            return 0;
        }
    }
}
