// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nuke.Common.Utilities
{
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        ///     Returns an enumerable collection of file information that matches a search pattern in all directories of a given
        ///     depth.
        ///     <para>System and hidden directories are skipped.</para>
        /// </summary>
        /// <param name="directoryInfo">The root directory to start the search.</param>
        /// <param name="searchPattern">
        ///     The search string to match against the names of files. This parameter can contain a combination of valid literal
        ///     path and wildcard (* and ?) characters (see Remarks), but doesn't support regular expressions.
        ///     The default pattern is "*", which returns all files.
        /// </param>
        /// <param name="maxDepth">The maximum depth to descend into directories to look for files.</param>
        /// <returns>An enumerable collection of files that matches <paramref name="searchPattern" />.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="searchPattern" /> is <see langword="null" />. </exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     The path encapsulated in the <see cref="DirectoryInfo" />
        ///     object is invalid, (for example, it is on an unmapped drive).
        /// </exception>
        public static IEnumerable<FileInfo> EnumerateFiles(this DirectoryInfo directoryInfo, string searchPattern, int maxDepth)
        {
            if (maxDepth == 0)
                return Enumerable.Empty<FileInfo>();

            var subDirectories = directoryInfo.EnumerateDirectories()
                .Where(x => (x.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0);
            return directoryInfo.EnumerateFiles(searchPattern, SearchOption.TopDirectoryOnly)
                .Concat(subDirectories.SelectMany(x => x.EnumerateFiles(searchPattern, maxDepth - 1)));
        }
    }
}
