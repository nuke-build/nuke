// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities;

public static partial class StringExtensions
{
    /// <summary>
    /// Calculates the MD5 hash for a given string.
    /// </summary>
    [Pure]
    public static string GetMD5Hash(this string str)
    {
        using var algorithm = MD5.Create();
        var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(str));
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }

    /// <summary>
    /// Calculates the SHA256 hash for a given string.
    /// </summary>
    [Pure]
    public static string GetSHA256Hash(this string str)
    {
        using var algorithm = SHA256.Create();
        var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(str));
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }

    public static string GetHMACSHA256Hash<T>(this string str, string key)
        where T : Encoding, new()
    {
        using var hmacsha256 = new HMACSHA256(new T().GetBytes(key));
        var hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(str));
        return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
    }

    public static string GetHMACSHA1Hash(this string str, string key)
    {
        using var hmacsha1 = new HMACSHA1(Encoding.UTF8.GetBytes(key));
        var hash = hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(str));
        return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
    }
}
