// Copyright 2019 Maintainers of NUKE.
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

namespace Nuke.GlobalTool
{
    partial class Program
    {
        private const string CommandName = "nuke";

        [UsedImplicitly]
        public static int Complete(string[] args, [CanBeNull] string rootDirectory, [CanBeNull] string buildScript)
        {
            var words = args.Single();
            if (!words.StartsWithOrdinalIgnoreCase(CommandName))
            {
                return 0;
            }

            words = words.Substring(CommandName.Length).TrimStart();

            if (rootDirectory == null)
            {
                // TODO: parse --root parameter
                return 0;
            }

            var completionFile = Constants.GetCompletionFile((AbsolutePath) rootDirectory);
            if (!File.Exists(completionFile))
            {
                Build(buildScript.NotNull(), $"--{Constants.CompletionParameterName}");
                return 1;
            }

            var position = EnvironmentInfo.GetParameter<int?>("position");
            var completionItems = SerializationTasks.YamlDeserializeFromFile<Dictionary<string, string[]>>(completionFile);
            foreach (var item in CompletionUtility.GetRelevantCompletionItems(words, completionItems))
                Console.WriteLine(item);

            return 0;
        }
    }
}
