// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.Unity.Logging
{
    internal class BlockMatcher
    {
        public BlockMatcher(
            string name,
            string beginning,
            string end,
            MatchType beginMatchType = MatchType.Inclusive,
            MatchType endMatchType = MatchType.Inclusive)
        {
            Name = name;
            Beginning = beginning;
            End = end;
            BeginMatchType = beginMatchType;
            EndMatchType = endMatchType;
        }

        public string Name { get; }
        public string Beginning { get; }
        public string End { get; }
        public MatchType BeginMatchType { get; }
        public MatchType EndMatchType { get; }

        public MatchType MatchesEnd(string message)
        {
            var matches = Regex.Matches(message, End);
            return matches.Count != 0 ? EndMatchType : MatchType.None;
        }

        [CanBeNull]
        public MatchedBlock MatchesBeginning(string message)
        {
            var matches = Regex.Matches(message, Beginning);
            return matches.Count == 0 ? null : NewMatchedBlock(matches[i: 0]);
        }

        protected MatchedBlock NewMatchedBlock(Match match)
        {
            var name = Name;
            if (match.Groups.Count > 0)
                name += ": " + match.Groups[groupnum: 0];
            return new MatchedBlock(this, name, BeginMatchType);
        }
    }
}
