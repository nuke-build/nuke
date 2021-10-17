// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.IO;
using Xunit;
using Xunit.Abstractions;

namespace Nuke.Common.Tests
{
    public class CompressionTasksTest : FileSystemDependentTest
    {
        public CompressionTasksTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        [Theory]
        [InlineData("archive.zip")]
        [InlineData("archive.tar.gz")]
        [InlineData("archive.tar.bz2")]
        public void Test(string archiveFile)
        {
            var rootFile = Path.Combine(TestTempDirectory, "rootfile.txt");
            var nestedFile = Path.Combine(TestTempDirectory, "a", "b", "c", "nestedfile.txt");

            TextTasks.WriteAllText(rootFile, "root");
            TextTasks.WriteAllText(nestedFile, "nested");

            var archive = Path.Combine(TestTempDirectory, archiveFile);
            CompressionTasks.Compress(TestTempDirectory, archive);
            File.Exists(archive).Should().BeTrue();

            File.Delete(rootFile);
            File.Delete(nestedFile);
            Directory.GetFiles(TestTempDirectory, "*").Should().HaveCount(1);

            CompressionTasks.Uncompress(archive, TestTempDirectory);
            File.Exists(rootFile).Should().BeTrue();
            File.ReadAllText(rootFile).Should().Be("root");
            File.Exists(nestedFile).Should().BeTrue();
            File.ReadAllText(nestedFile).Should().Be("nested");
        }
    }
}
