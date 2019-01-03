// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.IO;
using Nuke.Common.Tooling;

namespace Nuke.Common.Execution
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class HandleShellCompletionAttribute : Attribute, IPreLogoBuildExtension
    {
        public void Execute(NukeBuild instance)
        {
            var completionItems = new SortedDictionary<string, string[]>();

            var targetNames = NukeBuild.ExecutableTargets.Select(x => x.Name).OrderBy(x => x).ToList();
            completionItems[Constants.InvokedTargetsParameterName] = targetNames.ToArray();
            completionItems[Constants.SkippedTargetsParameterName] = targetNames.ToArray();

            string[] GetSubItems(Type type)
            {
                if (type.IsEnum)
                    return type.GetEnumNames();
                if (type.IsSubclassOf(typeof(Enumeration)))
                    return type.GetFields(ReflectionService.Static).Select(x => x.Name).ToArray();
                return null;
            }

            foreach (var parameter in InjectionUtility.GetParameterMembers(instance.GetType()))
            {
                var parameterName = ParameterService.Instance.GetParameterName(parameter);
                if (completionItems.ContainsKey(parameterName))
                    continue;

                completionItems[parameterName] = GetSubItems(parameter.GetFieldOrPropertyType())?.OrderBy(x => x).ToArray();
            }

            SerializationTasks.YamlSerializeToFile(completionItems, Constants.GetCompletionFile(NukeBuild.RootDirectory));

            if (EnvironmentInfo.ParameterSwitch(Constants.CompletionParameterName))
                Environment.Exit(exitCode: 0);
        }
    }
}
