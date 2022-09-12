// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.IO
{
    public static partial class AbsolutePathExtensions
    {
        [Pure]
        public static bool Exists(this AbsolutePath path, [CallerArgumentExpression("path")] string expression = null)
        {
            if (expression.EndsWithAnyOrdinalIgnoreCase("file", "executable", "exe", "script"))
                return path.FileExists();
            if (expression.EndsWithAnyOrdinalIgnoreCase("directory", "dir", "folder"))
                return path.DirectoryExists();

            throw new ArgumentException($"Cannot infer from argument '{expression}' if either file or directory must exist");
        }

        [Pure]
        public static bool FileExists(this AbsolutePath path)
        {
            return File.Exists(path);
        }

        [Pure]
        public static bool DirectoryExists(this AbsolutePath path)
        {
            return Directory.Exists(path);
        }

        [Pure]
        public static bool ContainsFile(this AbsolutePath path, string pattern, SearchOption options = SearchOption.TopDirectoryOnly)
        {
            Assert.DirectoryExists(path);
            return path.ToDirectoryInfo().GetFiles(pattern, options).Any();
        }

        [Pure]
        public static bool ContainsDirectory(this AbsolutePath path, string pattern, SearchOption options = SearchOption.TopDirectoryOnly)
        {
            Assert.DirectoryExists(path);
            return path.ToDirectoryInfo().GetDirectories(pattern, SearchOption.TopDirectoryOnly).Any();
        }

        [Pure]
        [CanBeNull]
        public static AbsolutePath Existing(this AbsolutePath path, [CallerArgumentExpression("path")] string expression = null)
        {
            return path.Exists(expression) ? path : null;
        }

        [Pure]
        [CanBeNull]
        public static AbsolutePath ExistingFile(this AbsolutePath path)
        {
            return path.FileExists() ? path : null;
        }

        [Pure]
        [CanBeNull]
        public static AbsolutePath ExistingDirectory(this AbsolutePath path)
        {
            return path.DirectoryExists() ? path : null;
        }
    }
}
