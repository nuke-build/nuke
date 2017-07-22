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
        private const BindingFlags c_bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        public static void InjectValues (NukeBuild build)
        {
            foreach (var field in build.GetType().GetFields(c_bindingFlags))
            {
                var attributes = field.GetCustomAttributes().OfType<InjectionAttributeBase>().ToList();
                if (attributes.Count == 0)
                    continue;
                ControlFlow.Assert(attributes.Count == 1, $"Field '{field.Name}' has multiple injection attributes applied.");

                Logger.Info($"Handling value injection for '{field.Name}'...");

                var attribute = attributes.Single();
                var value = attribute.GetValue(field, build);
                if (value == null)
                    continue;

                var valueType = value.GetType();
                ControlFlow.Assert(field.FieldType.IsAssignableFrom(valueType),
                    $"Field '{field.Name}' must be of type '{valueType.Name}' to get its valued injected from '{attribute.GetType().Name}'.");

                field.SetValue(build, value);
            }
        }
    }
}
