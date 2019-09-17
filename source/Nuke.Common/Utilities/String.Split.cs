// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    public static partial class StringExtensions
    {
        [Pure]
        public static IEnumerable<string> Split(this string str, Func<char, int, bool> predicate, bool includeSplitCharacter = false)
        {
            var next = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (!predicate(str[i], i))
                    continue;

                yield return str.Substring(next, i - next);
                next = i;
                if (!includeSplitCharacter)
                    next++;
            }

            yield return str.Substring(next);
        }

        [Pure]
        public static IEnumerable<string> SplitCamelHumps(this string str, params string[] exclusions)
        {
            var hadLower = false;
            var exclusionIndex = 0;
            return str.Split((c, i) =>
                {
                    var shouldSplit = hadLower && char.IsUpper(c);
                    hadLower = char.IsLower(c) && !shouldSplit;

                    if (exclusions.Length > 0 && i >= exclusionIndex)
                    {
                        var currentExclusions = exclusions
                            .Select(x => (Exclusion: x, Index: str.IndexOf(x, exclusionIndex, StringComparison.InvariantCultureIgnoreCase)))
                            .Where(x => x.Index == i).ToList();

                        if (currentExclusions.Any())
                        {
                            exclusionIndex = currentExclusions.Max(x => x.Index + x.Exclusion.Length - 1);
                            return i > 0;
                        }
                    }

                    return shouldSplit && i > exclusionIndex;
                },
                includeSplitCharacter: true);
        }

        public static string[] SplitLineBreaks(this string str)
        {
            return str.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        }

        [Pure]
        public static string SplitCamelHumpsWithSeparator(this string str, string separator, params string[] exclusions)
        {
            return str.SplitCamelHumps(exclusions).Join(separator);
        }
    }
}
