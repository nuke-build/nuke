// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Steps
{
    /// <summary>
    /// Represents a catch error block, see <see href="https://www.jenkins.io/doc/pipeline/steps/workflow-basic-steps/#catcherror-catch-error-and-set-build-result-to-failure">catchError</see>.
    /// </summary>
    internal class CatchError : Step
    {
        private readonly Step _stepDefinition;

        /// <summary>
        /// Initializes a new instance of <see cref="CatchError"/> class.
        /// </summary>
        /// <param name="stepDefinition"></param>
        public CatchError(Step stepDefinition)
        {
            _stepDefinition = stepDefinition;
        }

        /// <summary>
        /// Build result.
        /// </summary>
        public BuildResult BuildResult { get; set; } = BuildResult.Unstable;

        /// <summary>
        /// Stage result.
        /// </summary>
        public StageResult StageResult { get; set; } = StageResult.Failure;

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            var buildResult = BuildResult.ToString().ToUpper().SingleQuote();
            var stageResult = StageResult.ToString().ToUpper().SingleQuote();
            using (writer.WriteBlock($"catchError(buildResult: {buildResult}, stageResult:{stageResult})"))
            {
                _stepDefinition.Write(writer);
            }
        }
    }

    internal enum BuildResult
    {
        Success,
        Unstable,
        Failure,
        Not_built,
        Aborted
    }

    internal enum StageResult
    {
        Success,
        Unstable,
        Failure,
        Not_built,
        Aborted
    }
}
