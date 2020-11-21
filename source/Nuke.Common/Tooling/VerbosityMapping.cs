// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tooling
{
    public static class VerbosityMapping
    {
        public static readonly LookupTable<Type, (Verbosity Verbosity, object MappedVerbosity)> Mappings
            = new LookupTable<Type, (Verbosity Verbosity, object MappedVerbosity)>();

        public static void Apply(object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                if (!Mappings.Contains(property.PropertyType))
                    continue;

                var mappings = Mappings[property.PropertyType];
                foreach (var (verbosity, mappedVerbosity) in mappings)
                {
                    if (verbosity == NukeBuild.Verbosity)
                        property.SetValue(obj, mappedVerbosity);
                }
            }
        }
    }
}
