// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NuGet.Versioning;

namespace Nuke.Common.ChangeLog
{
    [PublicAPI]
    public class ChangeLog
    {
        public ChangeLog(string path, [CanBeNull] ReleaseNotes unreleased, IReadOnlyList<ReleaseNotes> releaseNotes)
        {
            Path = path;
            Unreleased = unreleased;
            ReleaseNotes = releaseNotes.Where(x => !x.Unreleased).OrderBy(x => x.Version).ToList().AsReadOnly();
        }

        public ChangeLog(string path, IReadOnlyList<ReleaseNotes> releaseNotes)
            : this(path, unreleased: null, releaseNotes)
        {
        }

        public string Path { get; }
        [CanBeNull] public ReleaseNotes Unreleased { get; }
        public IReadOnlyList<ReleaseNotes> ReleaseNotes { get; }
        public NuGetVersion LatestVersion => ReleaseNotes.First().Version;
    }
}
