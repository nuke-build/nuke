// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using Nuke.Core;

namespace Nuke.Common.Tools.GitLink
{
    public static partial class GitLinkTasks
    {
        static partial void PreProcess (GitLink2Settings gitLink2Settings)
        {
            ControlFlow.Check(gitLink2Settings.ToolPath.Contains("gitlink\\2"), "gitLink2Settings.ToolPath.Contains('gitlink\\2')");
        }

        static partial void PreProcess (GitLink3Settings gitLink3Settings)
        {
            ControlFlow.Check (gitLink3Settings.ToolPath.Contains ("gitlink\\3"), "gitLink3Settings.ToolPath.Contains('gitlink\\3')");
        }
    }
}
