// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Common.IO;
using Xunit;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.Tests
{
    public class PathConstructionTest
    {
        [Theory]
        [InlineData("C:\\A\\B", "C:\\A")]
        [InlineData("C:\\", null)]
        [InlineData("\\\\server\\foo", "\\\\server")]
        [InlineData("\\\\server", null)]
        [InlineData("/foo", "/")]
        [InlineData("/", null)]
        public void TestParent(string path, string expected)
        {
            ((AbsolutePath) path).Parent.Should().Be((AbsolutePath) expected);
            ((string) ((AbsolutePath) path).Parent).Should().Be(expected);
        }

        [Theory]
        [InlineData("C:\\foo", "C:\\FOO", true)]
        [InlineData("/foo", "/FOO", false)]
        public void TestEquality(string path1, string path2, bool expected)
        {
            ((AbsolutePath) path1).Equals((AbsolutePath) path2).Should().Be(expected);
        }

        [Theory]
        [InlineData("C:\\A\\B\\C", "C:\\A\\B", "..")]
        [InlineData("C:\\A\\B\\", "C:\\A\\B\\C", "C")]
        [InlineData("C:\\A\\B\\C", "C:\\A\\B\\D\\E", "..\\D\\E")]
        [InlineData("C:\\A\\B\\C\\B", "C:\\A\\B\\D\\B", "..\\..\\D\\B")]
        [InlineData("/bin/etc", "/bin/tmp", "../tmp")]
        [InlineData("/bin/etc/bin", "/bin/tmp/bin", "../../tmp/bin")]
        [InlineData("/same1/diff1/same2", "/diff1/diff2/same2", "../../../diff1/diff2/same2")]
        public void TestGetRelativePath(string basePath, string destinationPath, string expected)
        {
            GetRelativePath(basePath, destinationPath).Should().Be(expected);
        }

        [Theory]
        [InlineData("C:\\A\\B", "C:\\A\\B\\C", true)]
        [InlineData("C:\\A\\B", "C:\\A\\B\\C\\", true)]
        [InlineData("C:\\A\\B", "C:\\A", false)]
        [InlineData("C:\\A\\B", "C:\\A\\C", false)]
        [InlineData("C:\\A\\B\\C", "C:\\A\\B", false)]
        [InlineData("C:\\A\\B\\C", "C:\\A\\B\\CD", false)]
        [InlineData("C:\\A\\B\\..\\C", "C:\\A\\B\\..\\C\\D", true)]
        [InlineData("/bin/etc", "/bin/etc/../etc/foo", true)]
        [InlineData("/bin/etc", "/bin/etc/../bar/foo", false)]
        public void TestIsDescendantPath(string basePath, string destinationPath, bool expected)
        {
            IsDescendantPath(basePath, destinationPath).Should().Be(expected);
        }

        [Theory]
        [InlineData("\\\\server", "\\\\server")]
        [InlineData("\\\\server\\", "\\\\server")]
        [InlineData("\\\\server\\foo\\bar", "\\\\server")]
        [InlineData("/", "/")]
        [InlineData("/bin/usr", "/")]
        [InlineData("C:\\", "C:")]
        [InlineData("C:\\foo\\bar", "C:")]
        public void TestGetPathRoot(string input, string expected)
        {
            GetPathRoot(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("\\\\server")]
        [InlineData("\\\\server\\foo\\bar")]
        [InlineData("/")]
        [InlineData("/bin/usr")]
        [InlineData("C:\\")]
        [InlineData("C:\\foo\\bar")]
        public void TestHasPathRoot_True(string input)
        {
            HasPathRoot(input).Should().BeTrue();
        }

        [Theory]
        [InlineData("foo")]
        [InlineData("foo\\bar")]
        [InlineData(".\\foo\\bar")]
        [InlineData("./foo/bar")]
        public void TestHasPathRoot_False(string input)
        {
            HasPathRoot(input).Should().BeFalse();
        }

        [Theory]
        [InlineData("foo", "bar", '/', "foo/bar")]
        [InlineData("foo", "bar", '\\', "foo\\bar")]
        [InlineData("C:", null, null, "C:\\")]
        [InlineData("C:\\", null, null, "C:\\")]
        [InlineData("C:\\", "foo", null, "C:\\foo")]
        [InlineData("C:", "foo", null, "C:\\foo")]
        [InlineData("C:\\foo", "bar", null, "C:\\foo\\bar")]
        [InlineData("/", null, null, "/")]
        [InlineData("/", "foo", null, "/foo")]
        [InlineData("/foo", "bar", null, "/foo/bar")]
        [InlineData("\\\\server", null, null, "\\\\server")]
        [InlineData("\\\\server", "foo", null, "\\\\server\\foo")]
        [InlineData("\\\\server\\foo", "bar", null, "\\\\server\\foo\\bar")]
        public void TestCombine(string path1, string path2, char? separator, string expected)
        {
            Combine(path1, path2, separator).Should().Be(expected);
        }

        [Theory]
        // TODO: Add tests for combining two roots
        [InlineData("C:", "foo", '/', "For Windows-rooted paths the separator must be '\\'")]
        [InlineData("\\\\server", "foo", '/', "For UNC-rooted paths the separator must be '\\'")]
        [InlineData("/", "foo", '\\', "For Unix-rooted paths the separator must be '/'")]
        [InlineData("C:\\", "C:\\", '\\', "Second path must not be rooted")]
        [InlineData("\\\\server", "\\\\server\\", '\\', "Second path must not be rooted")]
        [InlineData("/", "/", '/', "Second path must not be rooted")]
        public void TestCombine_Throws(string path1, string path2, char? separator, string expected)
        {
            Action action = () => Combine(path1, path2, separator);
            action.Should().Throw<Exception>().Which.Message.Should().StartWith(expected);
        }

        [Theory]
        [InlineData(null, null, "")]
        [InlineData("", null, "")]
        [InlineData("foo", null, "foo")]
        [InlineData("foo/", null, "foo")]
        [InlineData("./foo", null, "foo")]
        [InlineData("foo/bar", '/', "foo/bar")]
        [InlineData("../../bar", '/', "../../bar")]
        //[InlineData(@"C:", null, @"C:\")]
        [InlineData("C:", null, "C:\\")]
        [InlineData("C:\\foo/bar", null, "C:\\foo\\bar")]
        [InlineData("/", null, "/")] // Unix rooted
        [InlineData("/bin\\foo/bar", null, "/bin/foo/bar")]
        [InlineData("/bin/foo/.././/bar", null, "/bin/bar")]
        [InlineData("C:\\/foo/../.\\/bar", null, "C:\\bar")]
        public void TestNormalizePath(string input, char? separator, string expected)
        {
            NormalizePath(input, separator).Should().Be(expected);
        }

        [Theory]
        [InlineData("C:\\..", null, "Cannot normalize 'C:\\..' beyond path root")]
        [InlineData("\\\\server\\..", null, "Cannot normalize '\\\\server\\..' beyond path root")]
        [InlineData("/bin/../..", null, "Cannot normalize '/bin/../..' beyond path root")]
        [InlineData("C:\\foo", '/', "For Windows-rooted paths the separator must be '\\'")]
        [InlineData("\\\\server\\foo", '/', "For UNC-rooted paths the separator must be '\\'")]
        [InlineData("/bin/foo/bar", '\\', "For Unix-rooted paths the separator must be '/'")]
        public void TestNormalizePath_Throws(string input, char? separator, string message)
        {
            Action action = () => NormalizePath(input, separator);
            action.Should().Throw<Exception>().Which.Message.Should().StartWith(message);
        }

        [Theory]
        [InlineData(new object[] { "foo", "bar" }, "foo\\bar", "foo/bar")]
        [InlineData(new object[] { "./foo", "bar" }, "foo\\bar", "foo/bar")]
        [InlineData(new object[] { "foo", "..", ".", "", null, "bar", "foo" }, "bar\\foo", "bar/foo")]
        [InlineData(new object[] { "..", ".", "..", "foo" }, "..\\..\\foo", "../../foo")]
        public void RelativePath(object[] parts, string expectedWindows, string expectedUnix)
        {
            ParseRelativePath(parts).Should().Be(EnvironmentInfo.IsWin ? expectedWindows : expectedUnix);
        }

        [Theory]
        [InlineData(new object[] { "/bin", "foo", "..", "bar" }, "/bin/bar")]
        [InlineData(new object[] { "C:", "windows", "foo", "..", "bar" }, "C:\\windows\\bar")]
        [InlineData(new object[] { "\\\\server", "foo", "..", "bar" }, "\\\\server\\bar")]
        public void RelativePath_AsAbsolute(object[] parts, string expected)
        {
            ParseRelativePath(parts).Should().Be(expected);
        }

        [Theory]
        [InlineData(new object[] { "/bin", "foo", "..", "bar" }, "/bin/bar")]
        [InlineData(new object[] { "C:", "windows", "foo", "..", "bar" }, "C:\\windows\\bar")]
        [InlineData(new object[] { "C:" }, "C:\\")]
        [InlineData(new object[] { "C:\\", "windows" }, "C:\\windows")]
        [InlineData(new object[] { "\\\\server", "foo", "..", "bar" }, "\\\\server\\bar")]
        public void AbsolutePath(object[] parts, string expected)
        {
            ParseAbsolutePath(parts).Should().Be(expected);
        }

        [Theory]
        [InlineData(new object[] { "C:", "", "..", "bar" }, "Cannot normalize 'C:\\..' beyond path root")]
        [InlineData(new object[] { "/", "", "..", "bar" }, "Cannot normalize '/..' beyond path root")]
        [InlineData(new object[] { "\\\\server", "", "..", "bar" }, "Cannot normalize '\\\\server\\..' beyond path root")]
        [InlineData(new object[] { "foo", "bar" }, "Path 'foo' must be rooted")]
        public void AbsolutePath_Throws(object[] parts, string expected)
        {
            Action action = () => ParseAbsolutePath(parts);
            action.Should().Throw<Exception>().Which.Message.Should().StartWith(expected);
        }

        [Fact]
        public void RelativePath_Specific()
        {
            ((string) ((UnixRelativePath) "foo" / "bar")).Should().Be("foo/bar");
            ((string) ((WinRelativePath) "foo" / "bar")).Should().Be("foo\\bar");

            ((string) (UnixRelativePath) "foo\\bar").Should().Be("foo/bar");
            ((string) (WinRelativePath) "foo/bar").Should().Be("foo\\bar");
        }

        private static string ParseRelativePath(object[] parts)
        {
            return parts.Skip(count: 1).Aggregate((RelativePath) (string) parts[0], (rp, p) => rp / (string) p);
        }

        private static string ParseAbsolutePath(object[] parts)
        {
            return parts.Skip(count: 1).Aggregate((AbsolutePath) (string) parts[0], (rp, p) => rp / (string) p);
        }
    }
}
