// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.CI.Jenkins.Configuration.Steps;
using Nuke.Common.Execution;
using Nuke.Common.IO;

namespace Nuke.Common.CI.Jenkins.Configuration
{
    /// <summary>
    /// Creates a <see cref="JenkinsStage"/> class.
    /// </summary>
    internal class JenkinsStageFactory
    {
        private readonly string _buildCmdPath;

        /// <summary>
        /// Initializes a new instance of <see cref="JenkinsStageFactory"/> class.
        /// </summary>
        /// <param name="buildCmdPath">Path to build command.</param>
        public JenkinsStageFactory(string buildCmdPath)
        {
            _buildCmdPath = buildCmdPath;
        }

        /// <summary>
        /// Creates a new <see cref="JenkinsStage"/> class.
        /// </summary>
        /// <param name="target">Executable target.</param>
        /// <param name="producesTestResults">Produces test results.</param>
        /// <param name="reportType">Report type.</param>
        /// <returns></returns>
        public JenkinsStage Create(ExecutableTarget target, bool producesTestResults, JenkinsXUnitReportType reportType)
        {
            var steps = new List<JenkinsStep>();

            var batchStep = new JenkinsBatch($"{_buildCmdPath} {target.Name} --skip --no-logo", returnStdOutput: false, returnExitCode: false);
            var shStep = new JenkinsSh($"{_buildCmdPath.Replace(".cmd", ".sh")} {target.Name} --skip --no-logo",
                returnStdOutput: false,
                returnExitCode: false);

            var ifElseConditionStep = new JenkinsIfElseScripted("isUnix()", shStep, batchStep);
            var scriptedStep = new JenkinsScript(ifElseConditionStep);

            steps.Add(target.ProceedAfterFailure ? new JenkinsCatchError(scriptedStep) : scriptedStep);

            var artifacts = ArtifactExtensions.ArtifactProducts[target.Definition];
            var artifactRules = artifacts.Select(GetArtifactPath).ToList();

            steps.AddRange(artifactRules.Select(x => new JenkinsArchiveArtifacts(GetArtifactPath(x))));
            if (producesTestResults)
            {
                steps.Add(new JenkinsXunit(reportType, string.Join(",", artifactRules)));
            }

            return new JenkinsStage(target.Name, steps);
        }

        private static string GetArtifactPath(string source)
        {
            return !NukeBuild.RootDirectory.Contains(source) ? source : PathConstruction.GetUnixRelativePath(NukeBuild.RootDirectory, source);
        }
    }
}
