﻿// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Steps
{
    /// <summary>
    /// Represents a script block, see <see href="https://www.jenkins.io/doc/book/pipeline/syntax/#script">script</see>.
    /// </summary>
    internal class JenkinsScript : JenkinsStep
    {
        private readonly JenkinsStep _stepToWrap;

        /// <summary>
        /// Initializes a new instance of <see cref="JenkinsScript"/> class.
        /// </summary>
        /// <param name="stepToWrap"></param>
        public JenkinsScript(JenkinsStep stepToWrap)
        {
            _stepToWrap = stepToWrap;
        }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteJenkinsPipelineBlock("script"))
            {
                _stepToWrap.Write(writer);
            }
        }
    }
}