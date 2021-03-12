// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI.Jenkins.Configuration;
using Nuke.Common.CI.Jenkins.Configuration.Parameters;
using Nuke.Common.CI.Jenkins.Configuration.Steps;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.Jenkins
{
    [PublicAPI]
    public class JenkinsAttribute : ChainedConfigurationAttributeBase
    {
        public JenkinsAttribute(string jenkinsFileName = "Jenkinsfile")
        {
            ConfigurationFile = NukeBuild.RootDirectory / jenkinsFileName;
            GeneratedFiles = new[] { ConfigurationFile };
        }

        /// <summary>
        /// Targets to build - dependencies will be included as well
        /// </summary>
        public string[] TargetsToBuild { get; set; }

        /// <summary>
        /// Gets or sets the type of test framework results format to use to parse results.
        /// </summary>
        public JenkinsXUnitReportType XUnitReportType { get; set; } = JenkinsXUnitReportType.NUnit2;

        /// <summary>
        /// Gets or sets names of targets that generate test results.
        /// Report artifacts should be added to target's Produces method.
        /// Resulting files will be added as artifacts and will be also added as data to XUnit test results plugin
        /// </summary>
        public string[] TargetsWithTestResults { get; set; }

        /// <summary>
        /// Gets or sets th name of the agent that will be used to run the pipeline
        /// If not set, 'agent any' will be used , otherwise 'agent {label 'value'}' will be used
        /// </summary>
        public string AgentName { get; set; }

        /// <summary>
        /// Gets or sets whether to use git parameter (from git parameter plugin) in the pipeline parameters.
        /// If true, PT_BRANCH type will be used with branch filter set to "origin/(.*)"
        /// </summary>
        public bool UseGitParameterWithBranch { get; set; }

        /// <summary>
        /// Gets or sets default branch name for the git parameter - if used. <see cref="UseGitParameterWithBranch" />
        /// </summary>
        public string DefaultGitBranch { get; set; } = "master";

        /// <inheritdoc />
        public override Type HostType => typeof(Jenkins);

        /// <inheritdoc />
        public override IEnumerable<string> GeneratedFiles { get; }

        /// <inheritdoc />
        public override IEnumerable<string> RelevantTargetNames => TargetsToBuild;

        /// <inheritdoc />
        public sealed override string ConfigurationFile { get; }

        /// <inheritdoc />
        public override CustomFileWriter CreateWriter(StreamWriter streamWriter)
        {
            var writer = new CustomFileWriter(streamWriter, indentationFactor: 4, "//");
            return writer;
        }

        /// <inheritdoc />
        public override ConfigurationEntity GetConfiguration(NukeBuild build, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return GetPipeline(build, relevantTargets);
        }

        protected virtual JenkinsPipeline GetPipeline(NukeBuild build, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            var agent = new JenkinsAgent(AgentName);
            var parametersReader = new JenkinsParametersReader(build);
            var parameters = parametersReader.GetGlobalParameters(relevantTargets).ToList();

            if (UseGitParameterWithBranch)
            {
                var gitParameter = new JenkinsGitParameter("BRANCH", DefaultGitBranch, "Branch to use for checkout")
                                   {
                                       ParameterSelectedValue = JenkinsGitParameterSelectedValue.DEFAULT,
                                       GitParameterType = JenkinsGitParameterType.PT_BRANCH,
                                       BranchFilter = "origin/(.*)"
                                   };
                parameters.Add(gitParameter);
            }

            var lookupTable = new LookupTable<ExecutableTarget, JenkinsStage>();
            var jenkinsStages = relevantTargets
                .SelectMany(GetJenkinsStages, (x, y) => (ExecutableTarget: x, Stage: y))
                .ForEachLazy(x => lookupTable.Add(x.ExecutableTarget, x.Stage))
                .Select(x => x.Stage)
                .ToArray();

            return new JenkinsPipeline(agent, parameters, jenkinsStages);
        }

        private IEnumerable<JenkinsStage> GetJenkinsStages(ExecutableTarget executableTarget)
        {
            var buildCmdPath = BuildCmdPath;
            var factory = new JenkinsStageFactory(buildCmdPath);
            var producesTests = TargetsWithTestResults?.Any(x => x.Equals(executableTarget.Name, StringComparison.InvariantCultureIgnoreCase))
                                ?? false;
            yield return factory.Create(executableTarget, producesTests, XUnitReportType);
        }
    }
}
