// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI;
using Nuke.Common.Git;
using Nuke.Common.Tools.Git;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;
using static Nuke.Common.CI.BuildServerConfigurationGenerationAttributeBase;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public class ArgumentsFromGitCommitMessageAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        public string Prefix { get; set; } = "[nuke++]";

        public void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (BuildServerConfigurationGeneration.IsActive)
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

            var arguments = lastLine.Substring(Prefix.Length).TrimStart();
            ParameterService.Instance.ArgumentsFromCommitMessageService = new ArgumentParser(arguments);
        }
    }
}
