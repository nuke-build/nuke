// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;
using Xunit;
using Xunit.Abstractions;

namespace Nuke.Common.Tests;

public class MoveCopyTest : FileSystemDependentTest
{
    public MoveCopyTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
    {
        AbsolutePathExtensions.DefaultEofLineBreak = false;
    }

    [Fact]
    public void TestCopyFile()
    {
        var source = TestTempDirectory / "source.txt";
        source.WriteAllText("foobar");

        var target = TestTempDirectory / "target.txt";
        source.Copy(target);

        target.FileExists().Should().BeTrue();

        new Action(() => source.Copy(target))
            .Should().Throw<Exception>().WithMessage("* already exists");

        new Action(() => source.Copy(target, policy: ExistsPolicy.FileFail | ExistsPolicy.FileOverwrite))
            .Should().Throw<Exception>().WithMessage("Multiple file policies *");

        source.WriteAllText("fizzbuzz");
        source.Copy(target, policy: ExistsPolicy.FileOverwrite)
            .Should().Be(target);
        target.ReadAllText().Should().Be("fizzbuzz");
    }

    [Fact]
    public void TestMoveFile()
    {
        var source1 = TestTempDirectory / "source1.txt";
        var source2 = TestTempDirectory / "source2.txt";
        var source3 = TestTempDirectory / "source3.txt";
        source1.WriteAllText(nameof(source1));
        source2.WriteAllText(nameof(source2));
        source3.WriteAllText(nameof(source3));

        var target = TestTempDirectory / "target.txt";
        source2.Move(target);

        target.FileExists().Should().BeTrue();
        source2.FileExists().Should().BeFalse();

        new Action(() => source1.Move(target, policy: ExistsPolicy.FileFail))
            .Should().Throw<Exception>().WithMessage("* already exists");

        source1.Move(target, policy: ExistsPolicy.FileSkip).Should().Be(source1);
        source1.Move(target, policy: ExistsPolicy.FileOverwriteIfNewer).Should().Be(source1);
        source3.Move(target, policy: ExistsPolicy.FileOverwriteIfNewer).Should().Be(target);
    }

    [Fact]
    public void TestCopyDirectory()
    {
        var source = TestTempDirectory / "source";
        var sourceFiles = new[]
        {
            source / "source1.txt",
            source / "source2.txt",
            source / "sub" / "source3.txt",
            source / "sub" / "source4.txt",
        };
        sourceFiles.ForEach(x => x.WriteAllText("source"));

        var target = TestTempDirectory / "target";
        source.Copy(target);
        target.GetFiles(depth: int.MaxValue).Select(x => target.GetRelativePathTo(x).ToString())
            .Should().BeEquivalentTo(sourceFiles.Select(x => source.GetRelativePathTo(x).ToString()));

        target.CreateOrCleanDirectory();
        var target0 = (target / "source0.txt").TouchFile();
        var target3 = (target / "sub" / "source3.txt").WriteAllText("target");
        var target4 = (target / "sub" / "source4.txt").WriteAllText("target");
        (source / target.GetRelativePathTo(target4)).TouchFile();

        new Action(() => source.Copy(target, ExistsPolicy.DirectoryFail))
            .Should().Throw<Exception>().WithMessage("Policy disallows merging directories");
        target.GetFiles(depth: int.MaxValue).Should().HaveCount(3);

        source.Copy(target, ExistsPolicy.MergeAndSkip);
        target0.FileExists().Should().BeTrue();
        target3.ReadAllText().Should().Be("target");
        target4.ReadAllText().Should().Be("target");

        source.Copy(target, ExistsPolicy.MergeAndOverwriteIfNewer);
        target3.ReadAllText().Should().Be("target");
        target4.ReadAllText().Should().Be("source");

        source.Copy(target, ExistsPolicy.MergeAndOverwrite);
        target3.ReadAllText().Should().Be("source");
    }

    [Fact]
    public void TestMoveDirectory()
    {
        var source = TestTempDirectory / "source";
        var sourceFiles = new[]
                          {
                              source / "source1.txt",
                              source / "source2.txt",
                              source / "sub" / "source3.txt",
                              source / "sub" / "source4.txt",
                          };
        sourceFiles.ForEach(x => x.WriteAllText("source"));

        var target = TestTempDirectory / "target";
        (target / "source1.txt").TouchFile();
        (target / "sub" / "source3.txt").TouchFile();

        new Action(() => source.Move(target)).Should().Throw<Exception>();

        source.Move(target, ExistsPolicy.MergeAndSkip);
        source.GetFiles(depth: int.MaxValue).Should().HaveCount(2);

        source.Move(target, ExistsPolicy.MergeAndSkip, deleteRemainingFiles: true)
            .Should().Be(target);
        source.DirectoryExists().Should().BeFalse();
    }
}
