// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.IO;
using Nuke.Common.ValueInjection;
using static Nuke.Common.Constants;

namespace Nuke.Common.Execution
{
    internal class HandleShellCompletionAttribute : BuildExtensionAttributeBase, IOnBeforeLogo
    {
        public void OnBeforeLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var completionItems = new SortedDictionary<string, string[]>();

            var targets = build.ExecutableTargets.OrderBy(x => x.Name).ToList();
            completionItems[InvokedTargetsParameterName] = targets.Where(x => x.Listed).Select(x => x.Name).ToArray();
            completionItems[SkippedTargetsParameterName] = targets.Select(x => x.Name).ToArray();

            var parameters = ValueInjectionUtility.GetParameterMembers(build.GetType(), includeUnlisted: false);
            foreach (var parameter in parameters)
            {
                var parameterName = ParameterService.GetParameterMemberName(parameter);
                if (completionItems.ContainsKey(parameterName))
                    continue;

                var subItems = ParameterService.GetParameterValueSet(parameter, build)?.Select(x => x.Text);
                completionItems[parameterName] = subItems?.ToArray();
            }

            SerializationTasks.YamlSerializeToFile(completionItems, GetCompletionFile(NukeBuild.RootDirectory));

            if (EnvironmentInfo.GetParameter<bool>(CompletionParameterName))
                Environment.Exit(exitCode: 0);
        }
    }
}
