// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI
{
    public interface IConfigurationGenerator
    {
        string Name { get; }
        string Id { get; }
        bool AutoGenerate { get; }
        HostType HostType { get; }
        IEnumerable<string> GeneratedFiles { get; }
        IEnumerable<string> RelevantTargetNames { get; }
        IEnumerable<string> IrrelevantTargetNames { get; }
        CustomFileWriter CreateWriter();
        ConfigurationEntity GetConfiguration(NukeBuild build, IReadOnlyCollection<ExecutableTarget> relevantTargets);
        void SerializeState();
    }
}
