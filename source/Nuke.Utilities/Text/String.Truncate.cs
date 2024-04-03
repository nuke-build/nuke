// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Utilities;

partial class StringExtensions
{
    public static string Truncate(this string str, int maxChars)
    {
        return str.Length <= maxChars ? str : str.Substring(0, maxChars) + "…";
    }
}
