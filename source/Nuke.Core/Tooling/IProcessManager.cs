// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    [PublicAPI]
    public interface IProcessManager
    {
        [CanBeNull]
        IProcess StartProcess (ToolSettings toolSettings, ProcessSettings processSettings = null);

        [CanBeNull]
        IProcess StartProcess (
            string toolPath,
            string arguments = null,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool redirectOutput = false,
            Func<string, string> outputFilter = null);
        
        FakeProcessStartInfo CaptureProcessStartInfo (Action action);
    }
}
