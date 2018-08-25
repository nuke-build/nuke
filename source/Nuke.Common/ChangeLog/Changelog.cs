// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

namespace Nuke.Common.ChangeLog
{
    using System.Collections.Generic;
    using System.Linq;
    using JetBrains.Annotations;
    using NuGet.Versioning;

    [PublicAPI]
    public class Changelog
    {
        public Changelog(string path, ReleaseNotes unreleased, IReadOnlyList<ReleaseNotes> releaseNotes)
        {
            Path = path;
            Unreleased = unreleased;
            ReleaseNotes = releaseNotes.Where(rn => !rn.Unreleased).OrderBy(rn => rn.Version).ToList().AsReadOnly();
        }

        public Changelog(string path, IReadOnlyList<ReleaseNotes> releaseNotes)
            : this(path, unreleased: null, releaseNotes)
        {
        }

        public string Path { get; }
        [CanBeNull] public ReleaseNotes Unreleased { get; }
        public IReadOnlyList<ReleaseNotes> ReleaseNotes { get; }
        public NuGetVersion LatestVersion => ReleaseNotes.First().Version;
    }
}
