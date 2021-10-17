// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;

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
            NukeBuild build,
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
}
