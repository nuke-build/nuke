// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tools.GitHub;
using Xunit;

namespace Nuke.Common.Tests
{
    public class GitHubTasksTest
    {
        private static AbsolutePath RootDirectory => Constants.TryGetRootDirectoryFrom(EnvironmentInfo.WorkingDirectory).NotNull();

        [Fact]
        public void GitHubRepositoryFromLocalDirectoryTest()
        {
            var repository = GitRepository.FromLocalDirectory(RootDirectory).NotNull();
            if (!repository.IsGitHubRepository())
                return;

            var rawUrl = $"https://raw.githubusercontent.com/{repository.Identifier}/{repository.Branch}";
            var blobUrl = $"https://github.com/{repository.Identifier}/blob/{repository.Branch}";
            var treeUrl = $"https://github.com/{repository.Identifier}/tree/{repository.Branch}";

            repository.GetGitHubDownloadUrl(RootDirectory / "LICENSE").Should().Be($"{rawUrl}/LICENSE");

            repository.GetGitHubBrowseUrl("LICENSE").Should().Be($"{blobUrl}/LICENSE");
            repository.GetGitHubBrowseUrl("source").Should().Be($"{treeUrl}/source");

            repository.GetGitHubBrowseUrl(RootDirectory / "LICENSE").Should().Be($"{blobUrl}/LICENSE");
            repository.GetGitHubBrowseUrl(RootDirectory / "source").Should().Be($"{treeUrl}/source");
            repository.GetGitHubBrowseUrl(RootDirectory / "source" / "Directory.Build.props").Should().Be($"{blobUrl}/source/Directory.Build.props");

            repository.GetGitHubBrowseUrl("directory", itemType: GitHubItemType.Directory).Should().Be($"{treeUrl}/directory");
            repository.GetGitHubBrowseUrl("dir/file", itemType: GitHubItemType.File).Should().Be($"{blobUrl}/dir/file");

            repository.GetGitHubBrowseUrl(branch: repository.Branch).Should().Be(treeUrl);
        }

        [Fact]
        public void GitHubRepositoryFromUrlTest()
        {
            var repository = GitRepository.FromUrl("https://github.com/nuke-build/nuke", "dev");

            repository.GetGitHubBrowseUrl("LICENSE", itemType: GitHubItemType.File).Should().Be($"{repository}/blob/dev/LICENSE");
            repository.GetGitHubBrowseUrl("source", itemType: GitHubItemType.Directory).Should().Be($"{repository}/tree/dev/source");
        }
    }
}
