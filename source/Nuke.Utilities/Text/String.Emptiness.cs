// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;

namespace Nuke.Common.Utilities;

public static partial class StringExtensions
{
    /// <summary>
    /// Indicates whether a specified string is null or empty.
    /// </summary>
    [Pure]
    [ContractAnnotation("null => halt")]
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    /// <summary>
    /// Indicates whether a specified string is null, empty, or only white-space.
    /// </summary>
    [Pure]
    [ContractAnnotation("null => halt")]
    public static bool IsNullOrWhiteSpace(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    /// <summary>
    /// Returns <value>null</value> if the specified string is empty.
    /// </summary>
    [Pure]
    [ContractAnnotation("null => null")]
    public static string ToNullIfEmpty(this string str)
    {
        return str.IsNullOrEmpty() ? null : str;
    }

    /// <summary>
    /// Returns <value>null</value> if the specified string is empty or only white-space.
    /// </summary>
    [Pure]
    [ContractAnnotation("null => null")]
    public static string ToNullIfWhiteSpace(this string str)
    {
        return str.IsNullOrWhiteSpace() ? null : str;
    }
}
