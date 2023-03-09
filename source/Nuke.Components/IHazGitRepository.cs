// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Git;

namespace Nuke.Components
{
    [PublicAPI]
    public interface IHazGitRepository : INukeBuild
    {
        [GitRepository] [Required] GitRepository GitRepository => TryGetValue(() => GitRepository);
    }
}
