// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.IO
{
    /// <summary>
    /// Represents a relative path with the separator of the current operating system.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [DebuggerDisplay("{" + nameof(_path) + "}")]
    public class RelativePath
    {
        private readonly string _path;
        private readonly char? _separator;

        protected RelativePath(string path, char? separator = null)
        {
            _path = path;
            _separator = separator;
        }

        public static explicit operator RelativePath([CanBeNull] string path)
        {
            if (path is null)
                return null;

            return new RelativePath(NormalizePath(path));
        }

        public static implicit operator string([CanBeNull] RelativePath path)
        {
            return path?._path;
        }

        public static RelativePath operator /(RelativePath left, [CanBeNull] string right)
        {
            var separator = left.NotNull()._separator;
            return new RelativePath(NormalizePath(Combine(left, (RelativePath) right, separator), separator), separator);
        }

        public override string ToString()
        {
            return _path;
        }
    }
}
