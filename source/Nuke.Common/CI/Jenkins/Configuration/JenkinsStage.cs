﻿// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.CI.Jenkins.Configuration.Steps;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.Jenkins.Configuration
{
    /// <summary>
    /// Represents a Jenkins stage, see <see href="https://www.jenkins.io/doc/pipeline/steps/pipeline-stage-step/#stage-stage">stage</see>
    /// </summary>
    public class JenkinsStage : ConfigurationEntity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="JenkinsStage"/> class.
        /// </summary>
        /// <param name="name">Stage name.</param>
        /// <param name="steps">List of steps.</param>
        /// <param name="condition">Stage condition.</param>
        public JenkinsStage(string name, IEnumerable<JenkinsStep> steps, JenkinsStageCondition condition = null)
        {
            Name = name;
            Steps = steps;
            Condition = condition;
        }

        /// <summary>
        /// Stage condition.
        /// </summary>
        public JenkinsStageCondition Condition { get; }

        /// <summary>
        /// Stage name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// List of steps.
        /// </summary>
        public IEnumerable<JenkinsStep> Steps { get; }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteJenkinsPipelineBlock($"stage({Name.DoubleQuote()})"))
            {
                Condition?.Write(writer);
                using (writer.WriteJenkinsPipelineBlock("steps"))
                {
                    Steps.ForEach(x => x.Write(writer));
                }
            }
        }
    }
}