// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Glob;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.IO;

[assembly: IconClass (typeof (PathConstruction), "price-tags")]

namespace Nuke.Core.IO
{
    /// <summary>
    /// <p>Provides <see cref="RelPath"/> and <see cref="AbsPath"/> as an abstraction for generating compliant
    /// file-system paths independently of the underlying operating system. Usages should be restricted to the moment
    /// of construction, i.e., avoid using it as part of an API.</p>
    /// <p><see cref="RelPath"/> can construct any intermediate part of a path, whereas <see cref="AbsPath"/>
    /// ensures that the path is rooted.</p>
    /// </summary>
    /// <example>
    /// <code>
    /// var absoluteDirectory = (AbsPath) RootDirectory / "foo" / "bar";
    /// var relativeFile = (RelPath) "foo" / "bar.txt";
    /// </code>
    /// </example>
    [PublicAPI]
    public static class PathConstruction
    {
        // TODO: check usages
        [Pure]
        public static string GetRelativePath (string basePath, string destinationPath)
        {
            return Uri.UnescapeDataString (new Uri ($@"{basePath}\").MakeRelativeUri (new Uri (destinationPath)).ToString ());
        }

        [Pure]
        public static string GetAbsolutePath (string path)
        {
            return Path.GetFullPath (path);
        }

        [Pure]
        public static IEnumerable<string> GlobFiles (string directory, params string[] globPatterns)
        {
            var directoryInfo = new DirectoryInfo (directory);
            return globPatterns.SelectMany (x => directoryInfo.GlobFiles (x)).Select (x => x.FullName);
        }

        [Pure]
        public static IEnumerable<string> GlobDirectories (string directory, params string[] globPatterns)
        {
            var directoryInfo = new DirectoryInfo (directory);
            return globPatterns.SelectMany (x => directoryInfo.GlobDirectories (x)).Select (x => x.FullName);
        }

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
        
        public class RelPath
        {
            private readonly string _path;

            private RelPath (string path)
            {
                _path = path;
            }

            public static explicit operator RelPath ([CanBeNull] string path)
            {
                return new RelPath(Normalize(path));
            }

            public static implicit operator string (RelPath path)
            {
                return Path.IsPathRooted(path._path)
                    ? GetAbsolutePath(path._path)
                    : path._path;
            }

            public static RelPath operator / (RelPath path1, string path2)
            {
                return (RelPath) Combine(path1, (RelPath) path2);
            }

            public static RelPath operator + (RelPath path1, string path2)
            {
                return (RelPath) Combine(path1, (RelPath) path2);
            }
        }

        public class AbsPath
        {
            private readonly string _path;

            private AbsPath (string path)
            {
                _path = path;
            }

            public static explicit operator AbsPath ([CanBeNull] string path)
            {
                ControlFlow.Assert(Path.IsPathRooted(path), $"Path '{path}' must be rooted.");
                return new AbsPath(Normalize(path));
            }

            public static implicit operator string (AbsPath path)
            {
                return GetAbsolutePath(path._path);
            }

            public static AbsPath operator / (AbsPath path1, string path2)
            {
                return (AbsPath) Combine(path1, path2);
            }

            public static AbsPath operator + (AbsPath path1, string path2)
            {
                return (AbsPath) Combine(path1, path2);
            }
        }
    }
}
