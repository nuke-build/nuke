// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static partial class AbsolutePathExtensions
    {
        /// <summary>
        /// Creates the directory.
        /// </summary>
        public static AbsolutePath CreateDirectory(this AbsolutePath path)
        {
            Directory.CreateDirectory(path);

            return path;
        }

        /// <summary>
        /// Creates or cleans the directory.
        /// </summary>
        public static AbsolutePath CreateOrCleanDirectory(this AbsolutePath path)
        {
            path.DeleteDirectory();
            path.CreateDirectory();

            return path;
        }

        /// <summary>
        /// Creates (touches) the file. Similar to the UNIX command, the last-write time is updated.
        /// </summary>
        public static AbsolutePath TouchFile(this AbsolutePath path, DateTime? time = null, bool createDirectories = true)
        {
            if (createDirectories)
                path.Parent.CreateDirectory();

            if (!File.Exists(path))
                File.WriteAllBytes(path, new byte[0]);

            File.SetLastWriteTime(path, time ?? DateTime.Now);

            return path;
        }
    }
}
