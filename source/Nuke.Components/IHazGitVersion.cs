// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tools.GitVersion;
using static Nuke.Common.ValueInjection.ValueInjectionUtility;

namespace Nuke.Components
{
    [PublicAPI]
    public interface IHazGitVersion : INukeBuild
    {
        [Required]
        [GitVersion(Framework = "netcoreapp3.1", NoFetch = true)]
        GitVersion Versioning => TryGetValue(() => Versioning);
    }
}
