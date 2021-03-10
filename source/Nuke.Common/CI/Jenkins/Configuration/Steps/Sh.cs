// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Steps
{
    /// <summary>
    /// Calls a shell script, see <see href="https://www.jenkins.io/doc/pipeline/steps/workflow-durable-task-step/#sh-shell-script">sh</see>.
    /// </summary>
    internal class Sh : Batch
    {
        /// <inheritdoc />
        public Sh(string batchScript, bool returnStdOutput = false, bool returnExitCode = false)
            : base(batchScript, returnStdOutput, returnExitCode)
        {
        }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine(
                $"sh encoding: {Encoding.SingleQuote()}, returnStatus: {ReturnExitCode.ToString().ToLowerInvariant()}, returnStdout: {ReturnStdOutput.ToString().ToLowerInvariant()}, script: {BatchScript.DoubleQuote()}");
        }
    }
}
