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
    /// Creates a <see cref="Stage"/> class.
    /// </summary>
    internal class StageFactory
    {
        private readonly string _buildCmdPath;

        /// <summary>
        /// Initializes a new instance of <see cref="StageFactory"/> class.
        /// </summary>
        /// <param name="buildCmdPath">Path to build command.</param>
        public StageFactory(string buildCmdPath)
        {
            _buildCmdPath = buildCmdPath;
        }

        /// <summary>
        /// Creates a new <see cref="Stage"/> class.
        /// </summary>
        /// <param name="target">Executable target.</param>
        /// <param name="producesTestResults">Produces test results.</param>
        /// <param name="reportType">Report type.</param>
        /// <returns></returns>
        public Stage Create(ExecutableTarget target, bool producesTestResults, XUnitReportType reportType)
        {
            var steps = new List<Step>();

            var batchStep = new Batch($"{_buildCmdPath} {target.Name} --skip --no-logo", returnStdOutput: false, returnExitCode: false);
            var shStep = new Sh($"{_buildCmdPath.Replace(".cmd", ".sh")} {target.Name} --skip --no-logo",
                returnStdOutput: false,
                returnExitCode: false);

            var ifElseConditionStep = new IfElseScripted("isUnix()", shStep, batchStep);
            var scriptedStep = new Script(ifElseConditionStep);

            steps.Add(target.ProceedAfterFailure ? new CatchError(scriptedStep) : scriptedStep);

            var artifacts = ArtifactExtensions.ArtifactProducts[target.Definition];
            var artifactRules = artifacts.Select(GetArtifactPath).ToList();

            steps.AddRange(artifactRules.Select(x => new ArchiveArtifacts(GetArtifactPath(x))));
            if (producesTestResults)
            {
                steps.Add(new Xunit(reportType, string.Join(",", artifactRules)));
            }

            return new Stage(target.Name, steps);
        }

        private static string GetArtifactPath(string source)
        {
            return !NukeBuild.RootDirectory.Contains(source) ? source : PathConstruction.GetUnixRelativePath(NukeBuild.RootDirectory, source);
        }
    }
}
