// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Steps
{
    /// <summary>
    /// Calls a batch script, see <see href="https://www.jenkins.io/doc/pipeline/steps/workflow-durable-task-step/#bat-windows-batch-script">bat</see>.
    /// </summary>
    internal class JenkinsBatch : JenkinsStep
    {
        protected readonly string BatchScript;
        protected readonly bool ReturnStdOutput;
        protected readonly bool ReturnExitCode;

        /// <summary>
        /// Initializes a new instance of <see cref="JenkinsBatch"/> class.
        /// </summary>
        /// <param name="batchScript">Name of batch script.</param>
        /// <param name="returnStdOutput">Return std output.</param>
        /// <param name="returnExitCode">Return exit code.</param>
        public JenkinsBatch(string batchScript, bool returnStdOutput = false, bool returnExitCode = false)
        {
            BatchScript = batchScript;
            ReturnStdOutput = returnStdOutput;
            ReturnExitCode = returnExitCode;
        }

        /// <summary>
        /// Bat encoding.
        /// </summary>
        public string Encoding { get; set; } = "UTF-8";

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine(
                $"bat encoding: {Encoding.SingleQuote()}, returnStatus: {ReturnExitCode.ToString().ToLowerInvariant()}, returnStdout: {ReturnStdOutput.ToString().ToLowerInvariant()}, script: {BatchScript.DoubleQuote()}");
        }
    }
}
