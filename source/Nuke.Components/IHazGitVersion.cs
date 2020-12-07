using System;
using System.Linq;
using Nuke.Common.Tools.GitVersion;
using static Nuke.Common.ValueInjection.ValueInjectionUtility;

namespace Nuke.Components
{
    public interface IHazGitVersion
    {
        [GitVersion]
        GitVersion GitVersion => TryGetValue(() => GitVersion);

        string Version => GitVersion.NuGetVersionV2;
    }
}
