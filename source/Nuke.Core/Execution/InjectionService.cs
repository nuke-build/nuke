// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using Nuke.Core.Injection;

namespace Nuke.Core.Execution
{
    internal static class InjectionService
    {
        public static void InjectValues (NukeBuild build)
        {
            foreach (var field in build.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var attributes = field.GetCustomAttributes().OfType<InjectionAttributeBase>().ToList();
                if (attributes.Count == 0)
                    continue;
                ControlFlow.Assert(attributes.Count == 1, $"Field '{field.Name}' has multiple injection attributes applied.");

                Logger.Info($"Handling value injection for '{field.Name}'...");

                var attribute = attributes.Single();
                attribute.InjectValue(field, build);
            }
        }

    }
}
