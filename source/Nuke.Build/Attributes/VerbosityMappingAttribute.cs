// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public class VerbosityMappingAttribute : BuildExtensionAttributeBase, IOnBuildInitialized
    {
        private readonly Type _targetType;

        public VerbosityMappingAttribute(Type targetType)
        {
            _targetType = targetType;
        }

        public string Quiet { get; set; }
        public string Minimal { get; set; }
        public string Normal { get; set; }
        public string Verbose { get; set; }

        public void OnBuildInitialized(
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            object GetMappedValue(string name)
                => _targetType
                    .GetField(name)
                    .NotNull($"Type {_targetType} doesn't have a field {name}.")
                    .GetValue(obj: null);

            if (Quiet != null)
                VerbosityMapping.Mappings.Add(_targetType, (Verbosity.Quiet, GetMappedValue(Quiet)));
            if (Minimal != null)
                VerbosityMapping.Mappings.Add(_targetType, (Verbosity.Minimal, GetMappedValue(Minimal)));
            if (Normal != null)
                VerbosityMapping.Mappings.Add(_targetType, (Verbosity.Normal, GetMappedValue(Normal)));
            if (Verbose != null)
                VerbosityMapping.Mappings.Add(_targetType, (Verbosity.Verbose, GetMappedValue(Verbose)));
        }
    }

    internal static class VerbosityMapping
    {
        public static readonly LookupTable<Type, (Verbosity Verbosity, object MappedVerbosity)> Mappings = new();

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
