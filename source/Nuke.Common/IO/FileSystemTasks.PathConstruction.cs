// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;

namespace Nuke.Common.IO
{
    public static partial class FileSystemTasks
    {
        internal static string Normalize ([CanBeNull] string path)
        {
            path = path ?? string.Empty;

            var root = Path.IsPathRooted(path) ? Path.GetPathRoot(path) : string.Empty;
            var rest = path.Substring(root.Length).Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            return Path.Combine(new[] { root }.Concat(rest).ToArray());
        }

        internal static string Combine (string path1, string path2)
        {
            ControlFlow.Assert(!Path.IsPathRooted(path2), $"Path '{path2}' must not be rooted.");
            return Path.Combine(path1, path2);
        }

        /// <summary>
        /// Provides an abstraction for generating file-system paths independently of the underlying operating system.
        /// Usages should be restricted to the moment of construction, i.e., avoid using it as part of an API.
        /// </summary>
        /// <example>
        /// <code>
        /// var directory = (PartialPath) "foo" / "bar";
        /// </code>
        /// </example>
        [PublicAPI]
        public class PartialPath
        {
            private readonly string _path;

            private PartialPath (string path)
            {
                _path = path;
            }

            public static explicit operator PartialPath ([CanBeNull] string path)
            {
                return new PartialPath(Normalize(path));
            }

            public static implicit operator string (PartialPath path)
            {
                return Path.IsPathRooted(path._path)
                    ? GetAbsolutePath(path._path)
                    : path._path;
            }

            public static PartialPath operator / (PartialPath path1, string path2)
            {
                return (PartialPath) Combine(path1, (PartialPath) path2);
            }

            public static PartialPath operator + (PartialPath path1, string path2)
            {
                return (PartialPath) Combine(path1, (PartialPath) path2);
            }
        }

        /// <summary>
        /// Provides an abstraction for generating file-system paths independently of the underlying operating system.
        /// Usages should be restricted to the moment of construction, i.e., avoid using it as part of an API.
        /// 
        /// The final output path is ensured to be an absolute path.
        /// </summary>
        /// <example>
        /// <code>
        /// var directory = (AbsolutePath) RootDirectory / "foo" / "bar";
        /// </code>
        /// </example>
        [PublicAPI]
        public class AbsolutePath
        {
            private readonly string _path;

            private AbsolutePath (string path)
            {
                _path = path;
            }

            public static explicit operator AbsolutePath ([CanBeNull] string path)
            {
                ControlFlow.Assert(Path.IsPathRooted(path), $"Path '{path}' must not be rooted.");
                return new AbsolutePath(Normalize(path));
            }

            public static implicit operator string (AbsolutePath path)
            {
                return GetAbsolutePath(path._path);
            }

            public static AbsolutePath operator / (AbsolutePath path1, string path2)
            {
                return (AbsolutePath) Combine(path1, path2);
            }

            public static AbsolutePath operator + (AbsolutePath path1, string path2)
            {
                return (AbsolutePath) Combine(path1, path2);
            }
        }
    }
}
