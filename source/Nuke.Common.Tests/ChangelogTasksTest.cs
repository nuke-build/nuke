// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using JetBrains.Annotations;
using Nuke.Common.ChangeLog;
using Nuke.Common.IO;
using VerifyXunit;
using Xunit;

namespace Nuke.Common.Tests
{
    [UsesVerify]
    public class ChangelogTasksTest
    {
        private static AbsolutePath RootDirectory => Constants.TryGetRootDirectoryFrom(EnvironmentInfo.WorkingDirectory).NotNull();

        private static AbsolutePath PathToChangelogReferenceFiles => RootDirectory / "source" / "Nuke.Common.Tests" / "ChangelogReferenceFiles";

        [Theory]
        [MemberData(nameof(AllChangelogReference_1_0_0_Files))]
        public void ReadReleaseNotes_ChangelogReferenceFile_ThrowsNoExceptions(AbsolutePath file)
        {
            Action act = () => ChangelogTasks.ReadReleaseNotes(file);

            act.Should().NotThrow();
        }

        [Theory]
        [MemberData(nameof(AllChangelogReference_1_0_0_Files))]
        public void ReadReleaseNotes_ChangelogReferenceFile_ReturnsAnyReleaseNotes(AbsolutePath file)
        {
            var releaseNotes = ChangelogTasks.ReadReleaseNotes(file);

            releaseNotes.Should().NotBeEmpty();
        }

        [Theory]
        [MemberData(nameof(AllChangelogReference_1_0_0_Files))]
        public void ReadChangelog_ChangelogReferenceFile_ThrowsNoExceptions(AbsolutePath file)
        {
            Action act = () => ChangelogTasks.ReadChangelog(file);

            act.Should().NotThrow();
        }

        [Theory]
        [MemberData(nameof(AllChangelogReference_1_0_0_Files))]
        public void ExtractChangelogSectionNotes_ChangelogReferenceFile_ThrowsNoExceptions(AbsolutePath file)
        {
            Action act = () => ChangelogTasks.ExtractChangelogSectionNotes(file);

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData("changelog_reference_1.0.0_variant_2.md")]
        [InlineData("changelog_reference_1.0.0_variant_3.md")]
        [InlineData("changelog_reference_1.0.0_variant_4.md")]
        public Task ReadReleaseNotes_ChangelogReferenceFile_HasParsedCorrectly(string fileName)
        {
            var changeLogFilePath = PathToChangelogReferenceFiles / fileName;

            var releaseNotes = ChangelogTasks.ReadReleaseNotes(changeLogFilePath);

            return Verifier.Verify(releaseNotes).UseDirectory(PathToChangelogReferenceFiles).UseFileName(changeLogFilePath.NameWithoutExtension);
        }

        [Fact]
        public void GetReleaseSections_ChangelogReferenceFileWithoutReleaseHead_ReturnsEmpty()
        {
            var changeLogFilePath = PathToChangelogReferenceFiles / "changelog_reference_invalid_variant_1.md";
            var lines = changeLogFilePath.ReadAllLines().ToList();

            ChangelogTasks.GetReleaseSections(lines).Should().BeEmpty();
        }

        [Theory]
        [InlineData("changelog_reference_1.0.0_variant_5.md", "0.2.3")]
        public Task ExtractChangelogSectionNotes_WithTag_ReturnsSectionThatMatchesProvidedTag(string fileName, string tag)
        {
            var changeLogFilePath = PathToChangelogReferenceFiles / fileName;
            var sectionNotes = ChangelogTasks.ExtractChangelogSectionNotes(changeLogFilePath, tag);

            return Verifier.Verify(sectionNotes).UseDirectory(PathToChangelogReferenceFiles)
                .UseFileName($"{changeLogFilePath.NameWithoutExtension}_section_{tag}");
        }

        [Theory]
        [InlineData("changelog_reference_1.0.0_variant_5.md", "0.0.0")]
        [InlineData("changelog_reference_1.0.0_variant_5.md", "9.9.9")]
        public void ExtractChangelogSection_WithNonExistingTag_ThrowsInformativeException(string fileName, string tag)
        {
            var changeLogFilePath = PathToChangelogReferenceFiles / fileName;

            Action act = () => ChangelogTasks.ExtractChangelogSectionNotes(changeLogFilePath, tag);

            act.Should().Throw<Exception>().Where(ex => ex.Message == $"Could not find release section for '{tag}'.");
        }

        [Theory]
        [InlineData("changelog_reference_invalid_variant_2.md")]
        public void ReadChangelog_ChangelogFileThatHasMultipleUnreleasedSection_ThrowsInformativeException(string fileName)
        {
            var changeLogFilePath = PathToChangelogReferenceFiles / fileName;

            Action act = () => ChangelogTasks.ReadChangelog(changeLogFilePath);

            act.Should().Throw<Exception>().Where(ex => ex.Message == "Changelog should have only one draft section");
        }

        [Theory]
        [InlineData("changelog_reference_invalid_variant_1.md")]
        public void ReadChangelog_EmptyChangelogFile_ThrowsInformativeException(string fileName)
        {
            var changeLogFilePath = PathToChangelogReferenceFiles / fileName;

            Action act = () => ChangelogTasks.ReadChangelog(changeLogFilePath);

            act.Should().Throw<Exception>().Where(ex => ex.Message == "Changelog should have at least one release note section");
        }

        [UsedImplicitly]
        public static IEnumerable<object[]> AllChangelogReference_1_0_0_Files
        {
            get => PathToChangelogReferenceFiles.GlobFiles("changelog_reference_1.0.0*.md").Select(file => new object[] { file });
        }
    }
}
