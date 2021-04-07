// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;

namespace Nuke.Common.CI
{
    public interface IBuildServer
    {
        [CanBeNull]
        string Branch { get; }

        [CanBeNull]
        string Commit { get; }
    }
}
