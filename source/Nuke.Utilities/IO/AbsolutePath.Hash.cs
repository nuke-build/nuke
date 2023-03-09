// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    partial class AbsolutePathExtensions
    {
        /// <summary>
        /// Calculates the MD5 hash of a file.
        /// </summary>
        [Pure]
        public static string GetFileHash(this AbsolutePath path)
        {
            Assert.True(path.FileExists());

            using var md5 = MD5.Create();
            using var stream = File.OpenRead(path);
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }

        /// <summary>
        /// Calculates the MD5 hash of a directory using <see cref="SearchOption.AllDirectories"/>.
        /// </summary>
        [Pure]
        public static string GetDirectoryHash(this AbsolutePath path, Func<AbsolutePath, bool> includeFile = null)
        {
            Assert.DirectoryExists(path);

            includeFile ??= _ => true;
            return Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                .Select(x => (AbsolutePath)x)
                .Where(includeFile)
                .GetFileSetHash(path);
        }

        /// <summary>
        /// Calculates the MD5 hash for a set of files in relation to a base directory.
        /// </summary>
        [Pure]
        public static string GetFileSetHash(this IEnumerable<AbsolutePath> paths, string baseDirectory)
        {
            using var md5 = MD5.Create();

            foreach (var path in paths.Distinct().OrderBy(x => x.ToString()))
            {
                Assert.True(path.FileExists());

                var relativePath = PathConstruction.GetRelativePath(baseDirectory, path);
                var unixNormalizedPath = PathConstruction.NormalizePath(relativePath, separator: '/');
                var pathBytes = Encoding.UTF8.GetBytes(unixNormalizedPath);
                md5.TransformBlock(pathBytes, inputOffset: 0, inputCount: pathBytes.Length, outputBuffer: pathBytes, outputOffset: 0);

                var contentBytes = File.ReadAllBytes(path);
                md5.TransformBlock(contentBytes, inputOffset: 0, inputCount: contentBytes.Length, outputBuffer: contentBytes, outputOffset: 0);
            }

            md5.TransformFinalBlock(new byte[0], inputOffset: 0, inputCount: 0);

            return BitConverter.ToString(md5.Hash).Replace("-", "").ToLower();
        }
    }
}
