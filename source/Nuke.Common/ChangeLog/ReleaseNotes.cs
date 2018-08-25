// Copyright 2018 Maintainers of NUKE.
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
        public bool IsEmpty => Notes.Count == 0;
        public bool Unreleased => Version == null;
        [CanBeNull] public NuGetVersion Version { get; }
        public IReadOnlyList<string> Notes { get; }
        public int StartIndex { get; }
        public int EndIndex { get; }

        public ReleaseNotes([CanBeNull] NuGetVersion version, IReadOnlyList<string> notes, int startIndex, int endIndex)
        {
            Version = version;
            ControlFlow.Assert(notes != null && notes.Count > 0, "Release Notes should not be empty");
            Notes = notes;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
        
        public ReleaseNotes(IReadOnlyList<string> notes, int startIndex, int endIndex) : this(version: null, notes, startIndex, endIndex) { }
        
        public override string ToString()
        {
            return string.Join(EnvironmentInfo.NewLine, Notes);
        }
    }
}
