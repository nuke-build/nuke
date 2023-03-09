// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.CI;
using Nuke.Common.Utilities;
using static Nuke.Common.Constants;

namespace Nuke.Common.Execution
{
    internal class HandleShellCompletionAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (BuildServerConfigurationGeneration.IsActive)
                return;

            if (IsLegacy(Build.RootDirectory))
            {
                Host.Error(
                    new[]
                    {
                        "The old-style .nuke configuration is no longer supported.",
                        "You can convert to the new-style .nuke directory by calling:",
                        "   nuke :update"
                    }.JoinNewLine());
                Environment.Exit(exitCode: -1);
            }
            else if (Build.BuildProjectFile != null)
            {
                SchemaUtility.WriteBuildSchemaFile(Build);
                SchemaUtility.WriteDefaultParametersFile(Build);
            }
            else if (ParameterService.GetPositionalArgument<string>(0) == ":complete")
            {
                var schema = SchemaUtility.GetBuildSchema(Build);
                var profileNames = GetProfileNames(Build.RootDirectory);
                var completionItems = CompletionUtility.GetItemsFromSchema(schema, profileNames);

                var words = EnvironmentInfo.CommandLineArguments.Skip(2).JoinSpace();
                var relevantCompletionItems = CompletionUtility.GetRelevantItems(words, completionItems);
                foreach (var item in relevantCompletionItems)
                    Console.WriteLine(item);

                Environment.Exit(exitCode: 0);
            }

            if (ParameterService.GetParameter<bool>(CompletionParameterName))
                Environment.Exit(exitCode: 0);
        }
    }
}
