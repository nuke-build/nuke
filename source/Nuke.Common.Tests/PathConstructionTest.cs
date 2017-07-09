// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Core;
using Xunit;
using static Nuke.Common.IO.FileSystemTasks;

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
                (PartialPath) "foo" / "bar",
                @"foo\bar",
                "foo/bar");

            AssertPath(
                (PartialPath) programFiles / "foo" / "bar",
                @"C:\Program Files (x86)\foo\bar",
                "/user/bin/foo/bar");

            AssertPath(
                (PartialPath) "foo" / null / "." / string.Empty / ".." / "bar",
                @"foo\.\..\bar",
                "foo/./../bar");

            AssertPath(
                (PartialPath) system / "foo" / ".." / "bar",
                @"C:\WINDOWS\system32\bar",
                "/bin/bar");

            AssertPath(
                (AbsolutePath) system / "foo" / "bar",
                $@"{system}\foo\bar",
                $"{system}/foo/bar");

            var exception1 = Assert.Throws<Exception>(() => (PartialPath) system / programFiles);
            exception1.Message.Should().Be($"Assertion failed: Path '{programFiles}' must not be rooted.");

            var exception2 = Assert.Throws<Exception>(() => (AbsolutePath) "foo" / "bar");
            exception2.Message.Should().Be("Assertion failed: Path 'foo' is not rooted.");
        }
    }
}
