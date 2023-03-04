// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nuke.Common.IO
{
    partial class AbsolutePathExtensions
    {
        /// <summary>
        /// Returns all files below the directory.
        /// </summary>
        public static IEnumerable<AbsolutePath> GetFiles(
            this AbsolutePath path,
            string pattern = "*",
            int depth = 1,
            FileAttributes attributes = 0)
        {
            Assert.True(depth >= 0);

            if (depth == 0)
                return Enumerable.Empty<AbsolutePath>();

            var files = Directory.EnumerateFiles(path, pattern, SearchOption.TopDirectoryOnly)
                .Where(x => (File.GetAttributes(x) & attributes) == 0)
                .OrderBy(x => x)
                .Select(AbsolutePath.Create);

            return files.Concat(path.GetDirectories(depth: depth - 1).SelectMany(x => x.GetFiles(pattern, attributes: attributes)));
        }

        /// <summary>
        /// Returns all directories below the directory.
        /// </summary>
        public static IEnumerable<AbsolutePath> GetDirectories(
            this AbsolutePath path,
            string pattern = "*",
            int depth = 1,
            FileAttributes attributes = 0)
        {
            Assert.True(depth >= 0);

            if (depth == 0)
                return Enumerable.Empty<AbsolutePath>();

            var directories = Directory.EnumerateDirectories(path, pattern, SearchOption.TopDirectoryOnly)
                .Where(x => (File.GetAttributes(x) & attributes) == 0)
                .OrderBy(x => x)
                .Select(AbsolutePath.Create);

            return directories.Concat(path.GetDirectories(depth: depth - 1).SelectMany(x => x.GetDirectories(pattern, attributes: attributes)));
        }
    }
}
