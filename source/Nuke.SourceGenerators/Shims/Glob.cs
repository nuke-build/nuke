// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GlobExpressions
{
    public enum GlobOptions
    {
        None,
        CaseInsensitive
    }

    public static class Glob
    {
        public static IEnumerable<FileInfo> Files(DirectoryInfo directory, string pattern, GlobOptions options)
        {
            throw new NotSupportedException();
        }

        public static IEnumerable<DirectoryInfo> Directories(DirectoryInfo directory, string pattern, GlobOptions options)
        {
            throw new NotSupportedException();
        }
    }
}
