// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
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
            int? timeout = null,
            bool redirectOutput = false,
            Func<string, string> outputFilter = null)
        {
            FakeProcessStartInfo = new FakeProcessStartInfo
                                {
                                    ToolPath = toolPath,
                                    Arguments = arguments,
                                    WorkingDirectory = workingDirectory,
                                    OutputFilter = outputFilter
                                };
            return new FakeProcess();
        }
    }
}
