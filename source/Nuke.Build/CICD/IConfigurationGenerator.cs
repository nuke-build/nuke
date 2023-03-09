// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Execution;
using Nuke.Common.IO;

namespace Nuke.Common.CI
{
    public interface IConfigurationGenerator
    {
        string Id { get; }
        string DisplayName { get; }
        string HostName { get; }

        bool AutoGenerate { get; }
        Type HostType { get; }
        IEnumerable<AbsolutePath> GeneratedFiles { get; }

        void Generate(IReadOnlyCollection<ExecutableTarget> executableTargets);
        void SerializeState();
    }
}
