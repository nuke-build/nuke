using System;
using System.Linq;
using Nuke.Common.Git;
using static Nuke.Common.ValueInjection.ValueInjectionUtility;

namespace Nuke.Components
{
    public interface IHazGitRepository
    {
        [GitRepository]
        GitRepository GitRepository => TryGetValue(() => GitRepository);
    }
}
