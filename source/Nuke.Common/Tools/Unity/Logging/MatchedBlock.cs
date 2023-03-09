// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.Unity.Logging
{
    internal class MatchedBlock
    {
        public BlockMatcher BlockMatcher { get; }
        public string Name { get; }
        public MatchType MatchType { get; }

        public MatchedBlock(BlockMatcher blockMatcher, string name, MatchType matchType)
        {
            BlockMatcher = blockMatcher;
            Name = name;
            MatchType = matchType;
        }

        public MatchType MatchesEnd(string message)
        {
            return BlockMatcher.MatchesEnd(message);
        }
    }
}
