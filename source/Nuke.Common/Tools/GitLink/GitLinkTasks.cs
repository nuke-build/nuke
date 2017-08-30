// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core;

namespace Nuke.Common.Tools.GitLink
{
    public static partial class GitLinkTasks
    {
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
