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
        private const string c_commandName = "nuke";

        [UsedImplicitly]
        public static int Complete(string[] args, [CanBeNull] string rootDirectory, [CanBeNull] string buildScript)
        {
            if (rootDirectory == null)
                return 0;

            var words = args.Single();
            if (!words.StartsWithOrdinalIgnoreCase(c_commandName))
                return 0;

            words = words.Substring(c_commandName.Length).TrimStart();

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
