// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core;

namespace Nuke.Common.Tools.GitLink2
{
    public static partial class GitLink2Tasks
    {
        static partial void PreProcess (GitLink2Settings gitLink2Settings)
        {
            ControlFlow.AssertWarn(gitLink2Settings.ToolPath.Contains("gitlink\\2"), "gitLink2Settings.ToolPath.Contains('gitlink\\2')");
        }
    }
}
