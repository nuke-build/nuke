// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core;

namespace Nuke.Common.Tools.GitLink3
{
    public static partial class GitLink3Tasks
    {
        static partial void PreProcess (GitLink3Settings gitLink3Settings)
        {
            ControlFlow.AssertWarn(gitLink3Settings.ToolPath.Contains("gitlink\\3"), "gitLink3Settings.ToolPath.Contains('gitlink\\3')");
        }
    }
}
