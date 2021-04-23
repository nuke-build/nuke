// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Git;
using Nuke.Common.Tools.Git;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;
using static Nuke.Common.CI.BuildServerConfigurationGenerationAttributeBase;
using static Nuke.Common.CI.InvokeBuildServerConfigurationGenerationAttribute;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public class ArgumentsFromGitCommitMessageAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        private bool GenerationMode { get; } = EnvironmentInfo.GetParameter<string>(ConfigurationParameterName) != null;

        public string Prefix { get; set; } = "[nuke++]";

        public void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (GenerationMode)
                return;

            var commit = GitRepository.GetCommitFromCI();
            if (commit == null)
                return;

            var lastLine = GitTasks.Git($"show -s --format=%B {commit}", logInvocation: false, logOutput: false)
                .Select(x => x.Text)
                .Where(x => !x.IsNullOrEmpty())
                .LastOrDefault();
            if (!lastLine?.StartsWithOrdinalIgnoreCase(Prefix) ?? true)
                return;

            var arguments = EnvironmentInfo.ParseCommandLineArguments(lastLine.Substring(Prefix.Length).TrimStart());
            ParameterService.Instance.ArgumentsFromCommitMessageService = new ParameterService(() => arguments, () => throw new NotSupportedException());
        }
    }
}
