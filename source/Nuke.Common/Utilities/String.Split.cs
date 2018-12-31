// Copyright 2018 Maintainers of NUKE.
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
        public static IEnumerable<string> Split(this string str, Func<char, bool> predicate, bool includeSplitCharacter = false)
        {
            var next = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (!predicate(str[i]))
                    continue;

                yield return str.Substring(next, i - next);
                next = i;
                if (!includeSplitCharacter)
                    next++;
            }

            yield return str.Substring(next);
        }

        [Pure]
        public static IEnumerable<string> SplitCamelHumps(this string str)
        {
            var hadLower = false;
            return str.Split(c =>
                {
                    var shouldSplit = hadLower && char.IsUpper(c);
                    hadLower = char.IsLower(c) && !shouldSplit;

                    return shouldSplit;
                },
                includeSplitCharacter: true);
        }
        
        [Pure]
        public static string SplitCamelHumpsWithSeparator(this string str, string separator)
        {
            return str.SplitCamelHumps().Join(separator).ToLowerInvariant();
        }
    }
}
