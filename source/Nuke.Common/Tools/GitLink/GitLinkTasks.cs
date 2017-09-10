// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.GitLink
{
    public static partial class GitLinkTasks
    {
        public static GitLink2Settings DefaultGitLink2 => new GitLink2Settings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                .SetSolutionDirectory(NukeBuild.Instance.SolutionDirectory)
                .SetConfiguration(NukeBuild.Instance.Configuration)
                .SetBranchName(GitVersionAttribute.Value?.BranchName)
                .SetRepositoryUrl(GitRepositoryAttribute.Value?.SvnUrl);

        public static GitLink3Settings DefaultGitLink3 => new GitLink3Settings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
                .SetBaseDirectory(NukeBuild.Instance.RootDirectory)
                .SetRepositoryUrl(GitRepositoryAttribute.Value?.SvnUrl);

        static partial void PreProcess (GitLink2Settings toolSettings)
        {
            ControlFlow.AssertWarn(toolSettings.ToolPath.Contains("gitlink\\2"), "toolSettings.ToolPath.Contains('gitlink\\2')");
        }

        static partial void PreProcess (GitLink3Settings toolSettings)
        {
            ControlFlow.AssertWarn(toolSettings.ToolPath.Contains("gitlink\\3"), "toolSettings.ToolPath.Contains('gitlink\\3')");
        }
    }
}
