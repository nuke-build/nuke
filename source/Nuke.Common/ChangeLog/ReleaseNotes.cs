// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NuGet.Versioning;

namespace Nuke.Common.ChangeLog
{
    [PublicAPI]
    public class ReleaseNotes
    {
        /// <summary>
        /// Gets a value indicating whether this release notes section contains notes.
        /// </summary>
        public bool IsEmpty => Notes.Count == 0;

        /// <summary>
        /// Gets a value indicating whether this release notes section is unreleased (vNext).
        /// </summary>
        public bool Unreleased => Version == null;

        /// <summary>
        /// The version of the release notes. Null if unreleased (vNext).
        /// </summary>
        [CanBeNull] public NuGetVersion Version { get; }

        /// <summary>
        /// The release notes in this release notes section.
        /// </summary>
        public IReadOnlyList<string> Notes { get; }

        /// <summary>
        /// The start index of this section in the changelog file.
        /// </summary>
        public int StartIndex { get; }

        /// <summary>
        /// The end index of this section in the changelog file.
        /// </summary>
        public int EndIndex { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReleaseNotes"/> class.
        /// </summary>
        /// <param name="version">The version of the release notes section.</param>
        /// <param name="notes">The release notes.</param>
        /// <param name="startIndex">The start index of the section in the changelog file.</param>
        /// <param name="endIndex">The end index of the section in the changelog file.</param>
        public ReleaseNotes(NuGetVersion version, IReadOnlyList<string> notes, int startIndex, int endIndex)
            : this(notes, startIndex, endIndex)
        {
            Version = version;
            Assert.True(notes.Count > 0, "Release Notes should not be empty");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReleaseNotes"/> class.
        /// </summary>
        /// <param name="notes">The release notes.</param>
        /// <param name="startIndex">The start index of the section in the changelog file.</param>
        /// <param name="endIndex">The end index of the section in the changelog file.</param>
        public ReleaseNotes(IReadOnlyList<string> notes, int startIndex, int endIndex)
        {
            Notes = notes;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

        public override string ToString()
        {
            return string.Join(EnvironmentInfo.NewLine, Notes);
        }
    }
}
