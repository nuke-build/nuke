// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
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
        [Fact]
        public void GitHubRepositoryFromLocalDirectoryTest()
        {
            var rootDirectory = (AbsolutePath) Directory.GetCurrentDirectory() / ".." / ".." / ".." / ".." / "..";
            var repository = GitRepository.FromLocalDirectory(rootDirectory, "master").NotNull();

            var rawUrl = $"https://raw.githubusercontent.com/{repository.Url.Identifier}/{repository.Branch}";
            var blobUrl = $"https://github.com/{repository.Url.Identifier}/blob/{repository.Branch}";
            var treeUrl = $"https://github.com/{repository.Url.Identifier}/tree/{repository.Branch}";

            repository.GetGitHubDownloadUrl(rootDirectory / "LICENSE").Should().Be($"{rawUrl}/LICENSE");

            repository.GetGitHubBrowseUrl("LICENSE").Should().Be($"{blobUrl}/LICENSE");
            repository.GetGitHubBrowseUrl("source").Should().Be($"{treeUrl}/source");

            repository.GetGitHubBrowseUrl(rootDirectory / "LICENSE").Should().Be($"{blobUrl}/LICENSE");
            repository.GetGitHubBrowseUrl(rootDirectory / "source").Should().Be($"{treeUrl}/source");
            repository.GetGitHubBrowseUrl(rootDirectory / "source" / "Directory.Build.props").Should().Be($"{blobUrl}/source/Directory.Build.props");

            repository.GetGitHubBrowseUrl("directory", itemType: GitHubItemType.Directory).Should().Be($"{treeUrl}/directory");
            repository.GetGitHubBrowseUrl("dir/file", itemType: GitHubItemType.File).Should().Be($"{blobUrl}/dir/file");
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
