// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Nuke.Common.Utilities
{
    public static partial class StringExtensions
    {
        public static string GetMD5Hash(this string str)
        {
            using var algorithm = MD5.Create();
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(str));
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
