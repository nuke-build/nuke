// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    internal class CapturingProcessManager : ProcessManager
    {
        public CapturedProcessStartInfo CapturedProcessStartInfo { get; private set; }

        [NotNull]
        public override IProcess StartProcess(ToolSettings toolSettings)
        {
            var toolPath = toolSettings.ToolPath;
            var arguments = toolSettings.GetArguments();

            ControlFlow.Assert(toolPath != null, "ToolPath was not set.");
            ControlFlow.Assert(File.Exists(toolPath), $"ToolPath '{toolPath}' does not exist.");

            return StartProcess(
                toolPath,
                arguments.RenderForExecution(),
                toolSettings.WorkingDirectory,
                toolSettings.EnvironmentVariables,
                toolSettings.ExecutionTimeout,
                toolSettings.RedirectOutput,
                toolSettings.RedirectOutput ? new Func<string, string>(arguments.Filter) : null);
        }

        [NotNull]
        public override IProcess StartProcess(
            string toolPath,
            string arguments = null,
            string workingDirectory = null,
            IReadOnlyDictionary<string, string> environmentVariables = null,
            int? timeout = null,
            bool redirectOutput = false,
            Func<string, string> outputFilter = null)
        {
            // TODO: check environment variables
            //ControlFlow.Assert(environmentVariables == null, "environmentVariables == null");
            ControlFlow.Assert(timeout == null, "timeout == null");
            ControlFlow.Assert(!redirectOutput, "!redirectOutput");
            ControlFlow.Assert(outputFilter == null, "outputFilter == null");

            var fakeProcessStartInfo =
                new CapturedProcessStartInfo
                {
                    ToolPath = toolPath,
                    Arguments = arguments,
                    WorkingDirectory = workingDirectory
                };
            CapturedProcessStartInfo = fakeProcessStartInfo;
            return new FakeProcess();
        }
    }
}
