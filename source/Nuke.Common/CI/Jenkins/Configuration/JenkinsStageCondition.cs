// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration
{
    /// <summary>
    /// Represents a stage condition, see <see href="https://www.jenkins.io/doc/book/pipeline/syntax/#when">when</see>.
    /// </summary>
    public class JenkinsStageCondition : ConfigurationEntity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="JenkinsStageCondition"/> class.
        /// </summary>
        /// <param name="condition">Condition context.</param>
        public JenkinsStageCondition(string condition)
        {
            Condition = condition;
        }

        /// <summary>
        /// Condition context.
        /// </summary>
        public string Condition { get; }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            if (string.IsNullOrEmpty(Condition) || string.IsNullOrWhiteSpace(Condition))
            {
                return;
            }

            using (writer.WriteJenkinsPipelineBlock("when"))
            {
                writer.WriteLine($"{Condition}");
            }
        }
    }
}
