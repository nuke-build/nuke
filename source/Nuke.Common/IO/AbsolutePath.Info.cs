// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    partial class AbsolutePathExtensions
    {
        [Pure]
        [ContractAnnotation("null => null; => notnull")]
        public static FileInfo ToFileInfo(this AbsolutePath path)
        {
            return path is not null ? new FileInfo(path) : null;
        }

        [Pure]
        [ContractAnnotation("null => null; => notnull")]
        public static DirectoryInfo ToDirectoryInfo(this AbsolutePath path)
        {
            return path is not null ? new DirectoryInfo(path) : null;
        }
    }
}
