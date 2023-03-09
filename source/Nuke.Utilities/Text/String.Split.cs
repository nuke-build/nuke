// Copyright 2023 Maintainers of NUKE.
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

        /// <summary>
        /// Splits a given string by camel-humps while treating exclusions as single items.
        /// </summary>
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

        /// <summary>
        /// Splits a given string by new-lines with empty entries preserved.
        /// </summary>
        [Pure]
        public static string[] SplitLineBreaks(this string str)
        {
            return str.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        }

        /// <summary>
        /// Splits a given string by spaces with empty entries removed.
        /// </summary>
        [Pure]
        public static string[] SplitSpace(this string str)
        {
            return str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Splits a given string by camel-humps while treating known-words (e.g., <em>MSBuild</em> or <em>NuGet</em>) as single items.
        /// </summary>
        [Pure]
        public static IEnumerable<string> SplitCamelHumpsWithKnownWords(this string str)
        {
            return str.SplitCamelHumps(KnownWords);
        }
    }
}
