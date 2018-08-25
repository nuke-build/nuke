// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

namespace Nuke.Common.ChangeLog
{
    using System;
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using NuGet.Versioning;

    [PublicAPI]
    public class ReleaseNotes
    {
        public bool IsEmpty => Notes.Count == 0;
        public bool Unreleased => Version == null;
        [CanBeNull] public NuGetVersion Version { get; }
        public IReadOnlyList<string> Notes { get; }
        public (int startIdx, int stopIdx) Section { get; }

        public ReleaseNotes([CanBeNull] NuGetVersion version, IReadOnlyList<string> notes, (int, int) section)
        {
            Version = version;
            Section = section;
            ControlFlow.Assert(notes != null && notes.Count > 0, "Release Notes should not be empty");
            Notes = notes;
        }
        
        public ReleaseNotes(IReadOnlyList<string> notes, (int, int) section) : this(version: null, notes, section) { }
        
        public override string ToString()
        {
            return string.Join(Environment.NewLine, Notes);
        }
    }
}
