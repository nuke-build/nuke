// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    public static partial class StringExtensions
    {
        [Pure]
        public static string GetDelimiterSeparated(this string str, string separator)
        {
            return str.SplitCamelHumps().Join(separator).ToLowerInvariant();
        }
    }
}
