// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.IO;
using Nuke.Common.Utilities.Collections;
using Nuke.Utilities;

namespace Nuke.Common.IO
{
    partial class AbsolutePathExtensions
    {
        /// <summary>
        /// Deletes the file when existent.
        /// </summary>
        [AdaptiveLogging]
        public static void DeleteFile(this AbsolutePath path)
        {
            if (!path.FileExists())
                return;

            AdaptiveLogger.Log("Deleting file {File}", path);
            File.SetAttributes(path, FileAttributes.Normal);
            File.Delete(path);
        }

        /// <summary>
        /// Deletes the directory recursively when existent.
        /// </summary>
        [AdaptiveLogging]
        public static void DeleteDirectory(this AbsolutePath path)
        {
            if (!path.DirectoryExists())
                return;

            AdaptiveLogger.Log("Deleting directory {Directory}", path);
            Directory.GetFiles(path, "*", SearchOption.AllDirectories).ForEach(x => File.SetAttributes(x, FileAttributes.Normal));
            Directory.Delete(path, recursive: true);
        }

        /// <summary>
        /// Deletes directories recursively when existent.
        /// </summary>
        public static void DeleteFiles(this IEnumerable<AbsolutePath> paths)
        {
            paths.ForEach(x => x.DeleteFile());
        }

        /// <summary>
        /// Deletes directories recursively when existent.
        /// </summary>
        public static void DeleteDirectories(this IEnumerable<AbsolutePath> paths)
        {
            paths.ForEach(x => x.DeleteDirectory());
        }
    }
}
