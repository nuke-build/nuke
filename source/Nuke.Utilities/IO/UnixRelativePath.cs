// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.IO;

/// <summary>
/// Represents a relative path with the UNIX separator (forward slash).
/// </summary>
[PublicAPI]
[Serializable]
public class UnixRelativePath : RelativePath
{
    protected UnixRelativePath(string path, char? separator)
        : base(path, separator)
    {
    }

    public static explicit operator UnixRelativePath([CanBeNull] string path)
    {
        return new UnixRelativePath(NormalizePath(path, UnixSeparator), UnixSeparator);
    }
}
