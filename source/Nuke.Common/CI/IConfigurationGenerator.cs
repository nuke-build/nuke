// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Execution;

namespace Nuke.Common.CI
{
    public interface IConfigurationGenerator
    {
        string Id { get; }
        string Name { get; }

        bool AutoGenerate { get; }
        HostType HostType { get; }
        IEnumerable<string> GeneratedFiles { get; }

        void Generate(NukeBuild targets, IReadOnlyCollection<ExecutableTarget> executableTargets);
        void SerializeState();
    }
}
