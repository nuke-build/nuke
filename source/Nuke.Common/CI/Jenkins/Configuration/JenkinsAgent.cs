// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration
{
    /// <summary>
    /// Jenkins Agent, see <see href="https://www.jenkins.io/doc/book/pipeline/syntax/#agent">agent</see>.
    /// </summary>
    /// <remarks>One agent for the whole pipeline is supported yet.</remarks>
    public class JenkinsAgent : ConfigurationEntity
    {
        private readonly string _label;

        /// <summary>
        /// Jenkins Agent will be set to "any"
        /// </summary>
        public JenkinsAgent()
            : this("any")
        {
        }

        /// <summary>
        ///     Jenkins Agent will be set to "label $value$".
        /// </summary>
        /// <param name="label">Agent label.</param>
        public JenkinsAgent(string label)
        {
            _label = label;
        }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            if (string.IsNullOrEmpty(_label))
            {
                writer.WriteLine("agent any");
                return;
            }

            using (writer.WriteJenkinsPipelineBlock("agent"))
            {
                writer.WriteLine($"label {_label.SingleQuote()}");
            }
        }
    }
}
