// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NuGet.Versioning;
using Nuke.Common.IO;

namespace Nuke.Common.ChangeLog
{
    [PublicAPI]
    public class ChangeLog
    {
        /// <summary>
        /// The path to the changelog file.
        /// </summary>
        public AbsolutePath Path { get; }

        /// <summary>
        /// The unreleased release notes section.
        /// </summary>
        [CanBeNull] public ReleaseNotes Unreleased { get; }

        /// <summary>
        /// Release notes sorted by version.
        /// </summary>
        public IReadOnlyList<ReleaseNotes> ReleaseNotes { get; }

        /// <summary>
        /// The latest release notes section. Returns null if the changelog does not contain a release section.
        /// </summary>
        [CanBeNull] public NuGetVersion LatestVersion => ReleaseNotes.FirstOrDefault()?.Version;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeLog"/> class.
        /// </summary>
        /// <param name="path">The path to the changelog file.</param>
        /// <param name="unreleased">The unreleased notes sectioon.</param>
        /// <param name="releaseNotes">The release notes of the changelog.</param>
        public ChangeLog(string path, [CanBeNull] ReleaseNotes unreleased, IReadOnlyList<ReleaseNotes> releaseNotes)
        {
            Path = path;
            Unreleased = unreleased;
            ReleaseNotes = releaseNotes.Where(x => !x.Unreleased).OrderBy(x => x.Version).ToList().AsReadOnly();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeLog"/> class.
        /// </summary>
        /// <param name="path">The path to the changelog file.</param>
        /// <param name="releaseNotes">The release notes of the changelog.</param>
        public ChangeLog(string path, IReadOnlyList<ReleaseNotes> releaseNotes)
            : this(path, unreleased: null, releaseNotes)
        {
        }
    }
}
