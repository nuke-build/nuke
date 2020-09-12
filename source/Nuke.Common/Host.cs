// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Nuke.Common.Execution;
using Nuke.Common.OutputSinks;
using Nuke.Common.Utilities;

namespace Nuke.Common
{
    [TypeConverter(typeof(TypeConverter))]
    public class Host
    {
        private class TypeConverter : System.ComponentModel.TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is string stringValue)
                {
                    var matchingHosts = AvailableTypes
                        .Where(x => x.FullName.EndsWithOrdinalIgnoreCase(stringValue)).ToList();
                    ControlFlow.Assert(matchingHosts.Count == 1, "matchingHost.Count == 1");

                    return CreateHost(matchingHosts.Single());
                }

                return base.ConvertFrom(context, culture, value);
            }
        }

        public static Host Instance { get; private set; }

        public static Host Default =>
            AvailableTypes
                .OrderByDescending(x => x != typeof(Terminal))
                .Where(IsRunning)
                .Select(CreateHost)
                .First();

        private static IEnumerable<Type> AvailableTypes
            => AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.IsSubclassOf(typeof(Host)));

        private static bool IsRunning(Type hostType)
        {
            var propertyName = $"IsRunning{hostType.Name}";
            var member = hostType.GetProperty(propertyName, ReflectionService.Static);
            ControlFlow.Assert(member != null, $"Host type '{hostType.Name}' does not define a property '{propertyName}'.");
            return member.GetValue<bool>();
        }

        private static Host CreateHost(Type hostType)
        {
            return (Host) Activator.CreateInstance(hostType, nonPublic: true);
        }

        protected Host()
        {
            ControlFlow.Assert(Instance == null, "Instance == null");
            Instance = this;
        }

        protected internal virtual OutputSink OutputSink => OutputSink.Default;
    }
}
