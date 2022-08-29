// Copyright 2022 Maintainers of NUKE.
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
        public static AbsolutePath CreateDirectory(this AbsolutePath path)
        {
            Directory.CreateDirectory(path);

            return path;
        }

        public static AbsolutePath CreateOrCleanDirectory(this AbsolutePath path)
        {
            path.DeleteDirectory();
            path.CreateDirectory();

            return path;
        }

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
