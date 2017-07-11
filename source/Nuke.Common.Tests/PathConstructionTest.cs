// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Core;
using Xunit;
using static Nuke.Core.IO.PathConstruction;

namespace Nuke.Common.Tests
{
    public class PathConstructionTest
    {
        [Fact]
        public void Test ()
        {
            void AssertPath (string actualPath, string expectedWindowsPath, string expectedUnixPath)
                => actualPath.Should().BeEquivalentTo(
                    EnvironmentInfo.IsWin
                        ? expectedWindowsPath
                        : expectedUnixPath);

            var programFiles = EnvironmentInfo.SpecialFolder(SpecialFolders.ProgramFilesX86);
            var system = EnvironmentInfo.SpecialFolder(SpecialFolders.System);

            AssertPath(
                (RelPath) "foo" / "bar",
                @"foo\bar",
                "foo/bar");

            AssertPath(
                (RelPath) programFiles / "foo" / "bar",
                @"C:\Program Files (x86)\foo\bar",
                "/user/bin/foo/bar");

            AssertPath(
                (RelPath) "foo" / null / "." / string.Empty / ".." / "bar",
                @"foo\.\..\bar",
                "foo/./../bar");

            AssertPath(
                (RelPath) system / "foo" / ".." / "bar",
                @"C:\WINDOWS\system32\bar",
                "/bin/bar");

            AssertPath(
                (AbsPath) system / "foo" / "bar",
                $@"{system}\foo\bar",
                $"{system}/foo/bar");

            var exception1 = Assert.Throws<Exception>(() => (RelPath) system / programFiles);
            exception1.Message.Should().Be($"Assertion failed: Path '{programFiles}' must not be rooted.");

            var exception2 = Assert.Throws<Exception>(() => (AbsPath) "foo" / "bar");
            exception2.Message.Should().Be("Assertion failed: Path 'foo' must be rooted.");
        }
    }
}
