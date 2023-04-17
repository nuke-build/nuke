// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;

namespace Nuke.Common.Utilities;

public static partial class StringExtensions
{
    [Pure]
    public static string Indent(this string text, int count)
    {
        return ' '.Repeat(count) + text;
    }
}
