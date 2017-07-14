// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Glob;
using JetBrains.Annotations;
using Nuke.Core.Execution;
using Nuke.Core.IO;
using Nuke.Core.Utilities;
// ReSharper disable ArrangeMethodOrOperatorBody

[assembly: IconClass (typeof (PathConstruction), "price-tag2")]

namespace Nuke.Core.IO
{
    /// <summary>
    /// <p>Provides an abstraction for generating Windows/Unix/UNC-compliant
    /// file-system paths independently of the underlying operating system. Usages should be restricted to the moment
    /// of construction, i.e., avoid using it as part of an API.</p>
    /// <p>Casting a string with <c>(Relative)</c> will construct any intermediate part of a path using the specific separators
    /// for the currently running operating-system. By using <c>(WinRelative)</c> and <c>(UnixRelative)</c> other separators can be 
    /// used intentionally. Casting with <c>(Absolute)</c> ensures that the path is rooted as Windows/Unix/UNC-path. The operators
    /// <c>/</c> and <c>+</c> allow to append sub-directories.</p>
    /// <p>Resulting paths are automatically normalized if possible. So <c>C:\foo\..\bar\.</c> will become <c>C:\bar</c>.</p>
    /// </summary>
    /// <example>
    /// <code>
    /// string relativePath = (Relative) "foo" / "bar";
    /// // On Windows:   relativePath == "foo\bar"
    /// // On Unix:      relativePath == "foo/bar"
    /// </code>
    /// <code>
    /// string winPath = (WinPath) "foo" / "bar"; // "foo\bar";
    /// string unixPath = (UnixPath) "foo" / "bar";   // "foo/bar";
    /// </code>
    /// <code>
    /// string absolutePath1 = (Absolute) RootDirectory / "foo" / "bar";
    /// string absolutePath2 = (Absolute) "foo" / "bar"  // Throws exception
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


        private const char WinSeparator = '\\';
        private const char UncSeparator = '\\';
        private const char UnixSeparator = '/';

        private static bool IsSameDirectory ([CanBeNull] string pathPart)
            => pathPart?.Length == 1 &&
               pathPart[index: 0] == '.';

        private static bool IsUpwardsDirectory ([CanBeNull] string pathPart)
            => pathPart?.Length == 2 &&
               pathPart[index: 0] == '.' &&
               pathPart[index: 1] == '.';

        private static bool IsWinRoot ([CanBeNull] string root)
            => root?.Length == 2 &&
               char.IsLetter(root[index: 0]) &&
               root[index: 1] == ':';

        private static bool IsUnixRoot ([CanBeNull] string root)
            => root?.Length == 1 &&
               root[index: 0] == UnixSeparator;

        private static bool IsUncRoot ([CanBeNull] string root)
            => root?.Length >= 3 &&
               root[index: 0] == UncSeparator &&
               root[index: 1] == UncSeparator &&
               root.Skip(count: 2).All(char.IsLetterOrDigit);

        private static string GetHeadPart ([CanBeNull] string str, int count) => new string((str ?? string.Empty).Take(count).ToArray());

        private static bool HasUnixRoot ([CanBeNull] string path) => IsUnixRoot(GetHeadPart(path, count: 1));
        private static bool HasUncRoot ([CanBeNull] string path) => IsUncRoot(GetHeadPart(path, count: 3));
        private static bool HasWinRoot ([CanBeNull] string path) => IsWinRoot(GetHeadPart(path, count: 2));

        public static bool HasPathRoot ([CanBeNull] string path) => GetPathRoot(path) != null;

        [CanBeNull]
        public static string GetPathRoot ([CanBeNull] string path)
        {
            if (path == null)
                return null;

            if (HasUnixRoot(path))
                return GetHeadPart(path, count: 1);

            if (HasWinRoot(path))
                return GetHeadPart(path, count: 2);

            if (HasUncRoot(path))
            {
                var separatorIndex = path.IndexOf(UncSeparator, startIndex: 2);
                return separatorIndex == -1 ? path : GetHeadPart(path, separatorIndex);
            }

            return null;
        }


        public static string Combine ([CanBeNull] string path1, string path2, char? separator = null)
        {
            // TODO: better something like "SafeHandleRoots"?
            path1 = Trim(path1);
            path2 = Trim(path2);

            if (string.IsNullOrWhiteSpace(path1))
                return path2;
            if (string.IsNullOrWhiteSpace(path2))
                return !IsWinRoot(path1) ? path1 : $@"{path1}\";

            AssertSeparatorChoice(path1, separator);
            separator = separator ?? GetSeparator(path1);

            if (IsWinRoot(path1))
                return $@"{path1}\{path2}";
            if (IsUnixRoot(path1))
                return $"{path1}{path2}";
            if (IsUncRoot(path1))
                return $@"{path1}\{path2}";

            return $"{path1}{separator}{path2}";
        }

        // ReSharper disable once CyclomaticComplexity
        public static string NormalizePath ([CanBeNull] string path, char? separator = null)
        {
            AssertSeparatorChoice (path, separator);

            path = path ?? string.Empty;
            separator = separator ?? GetSeparator(path);
            var root = GetPathRoot(path);

            var tail = root == null ? path : path.Substring(root.Length);
            var tailParts = tail.Split(new[] { WinSeparator, UncSeparator, UnixSeparator }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (var i = 0; i < tailParts.Count;)
            {
                var part = tailParts[i];
                if (IsUpwardsDirectory(part))
                {
                    if (tailParts.Take(i).All(IsUpwardsDirectory))
                    {
                        ControlFlow.Assert(i > 0 || root == null, $"Cannot normalize '{path}' beyond path root.");
                        i++;
                        continue;
                    }

                    tailParts.RemoveAt(i);
                    tailParts.RemoveAt(i - 1);
                    i--;
                    continue;
                }

                if (IsSameDirectory(part))
                {
                    tailParts.RemoveAt(i);
                    continue;
                }

                i++;
            }

            return Combine(root, tailParts.Join(separator.ToString()), separator);
        }


        private static char GetSeparator ([CanBeNull] string path)
        {
            var root = GetPathRoot(path);
            if (root != null)
            {
                if (IsWinRoot(root))
                    return WinSeparator;

                if (IsUncRoot(root))
                    return UncSeparator;

                if (IsUnixRoot(root))
                    return UnixSeparator;
            }

            return Path.DirectorySeparatorChar;
        }

        private static void AssertSeparatorChoice ([CanBeNull] string path, char? separator)
        {
            if (separator == null)
                return;

            var root = GetPathRoot(path);
            if (root == null)
                return;

            ControlFlow.Assert(!IsWinRoot(root) || separator == WinSeparator, $"For Windows-rooted paths the separator must be '{WinSeparator}'.");
            ControlFlow.Assert(!IsUncRoot(root) || separator == UncSeparator, $"For UNC-rooted paths the separator must be '{UncSeparator}'.");
            ControlFlow.Assert(!IsUnixRoot(root) || separator == UnixSeparator, $"For Unix-rooted paths the separator must be '{UnixSeparator}'.");
        }

        [ContractAnnotation("null => null; notnull => notnull")]
        private static string Trim([CanBeNull] string path)
        {
            if (path == null)
                return null;

            return IsUnixRoot(path) // TODO: "//" ?
                ? path
                : path.TrimEnd(WinSeparator, UnixSeparator, UncSeparator);
        }
        

        [DebuggerDisplay("{" + nameof(_path) + "}")]
        public class Relative
        {
            private readonly string _path;
            private readonly char? _separator;

            protected Relative (string path, char? separator = null)
            {
                _path = path;
                _separator = separator;
            }

            public static explicit operator Relative ([CanBeNull] string path)
            {
                return new Relative(NormalizePath(path));
            }

            public static implicit operator string (Relative path)
            {
                return path._path;
            }

            public static Relative operator / (Relative path1, string path2)
            {
                var separator = path1._separator;
                return new Relative(NormalizePath(Combine(path1, (Relative) path2, separator), separator), separator);
            }

            public static Relative operator + (Relative path1, string path2)
            {
                return path1 / path2;
            }
        }

        public class UnixRelative : Relative
        {
            protected UnixRelative (string path, char? separator)
                : base(path, separator)
            {
            }

            public static explicit operator UnixRelative ([CanBeNull] string path)
            {
                return new UnixRelative(NormalizePath(path), UnixSeparator);
            }
        }

        public class WinRelative : Relative
        {
            protected WinRelative (string path, char? separator)
                : base(path, separator)
            {
            }

            public static explicit operator WinRelative ([CanBeNull] string path)
            {
                return new WinRelative(NormalizePath(path), WinSeparator);
            }
        }

        [DebuggerDisplay("{" + nameof(_path) + "}")]
        public class Absolute
        {
            private readonly string _path;

            private Absolute (string path)
            {
                _path = path;
            }

            public static explicit operator Absolute ([CanBeNull] string path)
            {
                ControlFlow.Assert(HasPathRoot(path), $"Path '{path}' must be rooted.");
                return new Absolute(NormalizePath(path));
            }

            public static implicit operator string (Absolute path)
            {
                return NormalizePath(path._path);
            }

            public static Absolute operator / (Absolute path1, string path2)
            {
                return new Absolute(Combine(path1, path2));
            }

            public static Absolute operator + (Absolute path1, string path2)
            {
                return path1 / path2;
            }
        }
    }
}
