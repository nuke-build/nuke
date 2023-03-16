// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.IO
{
    public static partial class AbsolutePathExtensions
    {
        /// <summary>
        /// Indicates whether a file or directory exists. The variable or member should indicate whether it is a file (<c>*file</c>,
        /// <c>*executable</c>, <c>*exe</c>, <c>*script</c>), or a directory (<c>*directory</c>, <c>*dir</c>, <c>*folder</c>).
        /// </summary>
        [Pure]
        public static bool Exists(this AbsolutePath path, [CallerArgumentExpression("path")] string expression = null)
        {
            if (expression.EndsWithAnyOrdinalIgnoreCase("file", "executable", "exe", "script", "archive"))
                return path.FileExists();
            if (expression.EndsWithAnyOrdinalIgnoreCase("directory", "dir", "folder"))
                return path.DirectoryExists();

            throw new ArgumentException($"Cannot infer from argument '{expression}' if either file or directory must exist");
        }

        /// <summary>
        /// Indicates whether the file exists.
        /// </summary>
        [Pure]
        public static bool FileExists(this AbsolutePath path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Indicates whether the directory exists.
        /// </summary>
        [Pure]
        public static bool DirectoryExists(this AbsolutePath path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// Indicates whether the directory contains a file (<c>*</c> as wildcard) using <see cref="SearchOption.TopDirectoryOnly"/>.
        /// </summary>
        [Pure]
        public static bool ContainsFile(this AbsolutePath path, string pattern, SearchOption options = SearchOption.TopDirectoryOnly)
        {
            Assert.DirectoryExists(path);
            return path.ToDirectoryInfo().GetFiles(pattern, options).Any();
        }

        /// <summary>
        /// Indicates whether the directory contains a directory (<c>*</c> as wildcard) using <see cref="SearchOption.TopDirectoryOnly"/>.
        /// </summary>
        [Pure]
        public static bool ContainsDirectory(this AbsolutePath path, string pattern, SearchOption options = SearchOption.TopDirectoryOnly)
        {
            Assert.DirectoryExists(path);
            return path.ToDirectoryInfo().GetDirectories(pattern, SearchOption.TopDirectoryOnly).Any();
        }

        /// <summary>
        /// Returns the path if a file or directory exists. The variable or member should indicate whether it is a file (<c>*file</c>,
        /// <c>*executable</c>, <c>*exe</c>, <c>*script</c>), or a directory (<c>*directory</c>, <c>*dir</c>, <c>*folder</c>).
        /// </summary>
        [Pure]
        [CanBeNull]
        public static AbsolutePath Existing(this AbsolutePath path, [CallerArgumentExpression("path")] string expression = null)
        {
            return path.Exists(expression) ? path : null;
        }

        /// <summary>
        /// Returns the path if the file exists.
        /// </summary>
        [Pure]
        [CanBeNull]
        public static AbsolutePath ExistingFile(this AbsolutePath path)
        {
            return path.FileExists() ? path : null;
        }

        /// <summary>
        /// Returns the path if the directory exists.
        /// </summary>
        [Pure]
        [CanBeNull]
        public static AbsolutePath ExistingDirectory(this AbsolutePath path)
        {
            return path.DirectoryExists() ? path : null;
        }

        /// <summary>
        /// Returns all existing files.
        /// </summary>
        [Pure]
        public static IEnumerable<AbsolutePath> WhereFileExists(this IEnumerable<AbsolutePath> paths)
        {
            return paths.Where(x => x.FileExists());
        }

        /// <summary>
        /// Returns all existing directories.
        /// </summary>
        [Pure]
        public static IEnumerable<AbsolutePath> WhereDirectoryExists(this IEnumerable<AbsolutePath> paths)
        {
            return paths.Where(x => x.DirectoryExists());
        }
    }
}
