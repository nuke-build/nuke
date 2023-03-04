// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common.Utilities.Collections;

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

            var paths = new string[] { path };
            while (!paths.IsEmpty() && depth > 0)
            {
                var matchingDirectories = paths
                    .SelectMany(x => Directory.EnumerateDirectories(x, pattern, SearchOption.TopDirectoryOnly))
                    .Where(x => (File.GetAttributes(x) & attributes) == 0)
                    .OrderBy(x => x)
                    .Select(AbsolutePath.Create).ToList();
                
                foreach (var matchingDirectory in matchingDirectories)
                    yield return matchingDirectory;

                depth--;
                paths = paths.SelectMany(x => Directory.GetDirectories(x, "*", SearchOption.TopDirectoryOnly)).ToArray();
            }
        }
    }
}
