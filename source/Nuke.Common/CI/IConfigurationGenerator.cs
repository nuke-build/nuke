// Copyright 2021 Maintainers of NUKE.
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
        string DisplayName { get; }
        string HostName { get; }

        bool AutoGenerate { get; }
        Type HostType { get; }
        IEnumerable<string> GeneratedFiles { get; }

        void Generate(NukeBuild targets, IReadOnlyCollection<ExecutableTarget> executableTargets);
        void SerializeState();
    }
}
