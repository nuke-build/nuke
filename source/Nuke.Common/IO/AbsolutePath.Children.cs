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
        public static IEnumerable<AbsolutePath> GetFiles(
            this AbsolutePath path,
            string pattern = "*",
            int depth = 1,
            FileAttributes attributes = 0)
        {
            Assert.True(depth >= 0);

            if (depth == 0)
                return Enumerable.Empty<AbsolutePath>();

            var directories = path.GetDirectories(depth: depth);

            return directories.SelectMany(x => Directory.EnumerateFiles(x, pattern, SearchOption.TopDirectoryOnly))
                .Where(x => (File.GetAttributes(x) & attributes) == 0)
                .Select(AbsolutePath.Create);
        }

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
                .Select(AbsolutePath.Create).ToList();

            return directories.Concat(directories.SelectMany(x => x.GetDirectories(pattern, depth - 1, attributes)));
        }
    }
}
