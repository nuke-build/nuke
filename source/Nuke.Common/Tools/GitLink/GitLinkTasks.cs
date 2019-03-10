// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.GitLink
{
    public static partial class GitLinkTasks
    {
        private static void PreProcess(ref GitLink2Settings toolSettings)
        {
            ControlFlow.AssertWarn(toolSettings.ToolPath.Contains("gitlink\\2"), "toolSettings.ToolPath.Contains('gitlink\\2')");
        }

        private static void PreProcess(ref GitLink3Settings toolSettings)
        {
            ControlFlow.AssertWarn(toolSettings.ToolPath.Contains("gitlink\\3"), "toolSettings.ToolPath.Contains('gitlink\\3')");
        }
    }
}
