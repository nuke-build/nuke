// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;

namespace Nuke.Common.IO;

partial class AbsolutePathExtensions
{
    public static bool IsDotDirectory(this AbsolutePath path)
    {
        return path.DirectoryExists() && path.Name.StartsWith(".");
    }
}
