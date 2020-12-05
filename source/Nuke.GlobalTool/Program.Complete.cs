// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
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
            var localParametersFile = GetLocalParametersFile(rootDirectory);
            if (!File.Exists(buildSchemaFile))
            {
                Build(buildScript.NotNull(), $"--{CompletionParameterName}");
                return 1;
            }

            var position = EnvironmentInfo.GetParameter<int?>("position");
            var completionItems = SchemaUtility.GetCompletionItems(buildSchemaFile, localParametersFile);
            foreach (var item in CompletionUtility.GetRelevantCompletionItems(words, completionItems))
                Console.WriteLine(item);

            return 0;
        }
    }
}
