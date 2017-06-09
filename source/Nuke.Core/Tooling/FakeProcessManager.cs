// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    public class FakeProcessManager : ProcessManager
    {
        public FakeProcessStartInfo FakeProcessStartInfo { get; private set; }

        [CanBeNull]
        public override IProcess StartProcess (
            string toolPath,
            string arguments = null,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool redirectOutput = false,
            Func<string, string> outputFilter = null)
        {
            ControlFlow.Assert(environmentVariables == null, "environmentVariables == null");
            ControlFlow.Assert(timeout == null, "timeout == null");
            ControlFlow.Assert(!redirectOutput, "!redirectOutput");
            ControlFlow.Assert(outputFilter == null, "outputFilter == null");

            var fakeProcessStartInfo =
                    new FakeProcessStartInfo
                    {
                        ToolPath = toolPath,
                        Arguments = arguments,
                        WorkingDirectory = workingDirectory,
                    };
            FakeProcessStartInfo = fakeProcessStartInfo;
            return new FakeProcess();
        }
    }
}
