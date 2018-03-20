// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Git;
using Nuke.Core;
using Nuke.Core.IO;
using Xunit;

namespace Nuke.Common.Tests
{
    public class GitRepositoryTest
    {
        [Theory]
        [InlineData("https://github.com/nuke-build", "github.com", "nuke-build")]
        [InlineData("https://github.com/nuke-build", "github.com", "nuke-build")]
        [InlineData("https://github.com/nuke-build/", "github.com", "nuke-build")]
        [InlineData("https://github.com/nuke-build/nuke", "github.com", "nuke-build/nuke")]
        [InlineData("https://github.com/nuke-build/nuke.git", "github.com", "nuke-build/nuke")]
        [InlineData(" https://github.com/TdMxm/nuke.git", "github.com", "TdMxm/nuke")]
        [InlineData("git@git.test.org:test", "git.test.org", "test")]
        [InlineData("git@git.test.org/test", "git.test.org", "test")]
        [InlineData("git@git.test.org/test/", "git.test.org", "test")]
        [InlineData("git@git.test.org/test.git", "git.test.org", "test")]
        [InlineData("ssh://git@git.test.org/test.git", "git.test.org", "test")]
        public void FromUrlTest(string url, string endpoint, string identifier)
        {
            var repository = GitRepository.FromUrl(url);
            repository.Endpoint.Should().Be(endpoint);
            repository.Identifier.Should().Be(identifier);
        }

        [Fact]
        public void FromDirectoryTest()
        {
            var repository = GitRepository.FromLocalDirectory(Directory.GetCurrentDirectory()).NotNull();
            repository.Endpoint.Should().NotBeNullOrEmpty();
            repository.Identifier.Should().NotBeNullOrEmpty();
            repository.LocalDirectory.Should().NotBeNullOrEmpty();
            repository.Head.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GitHubRepositoryFromLocalDirectoryTest()
        {
            var rootDirectory = (PathConstruction.AbsolutePath) Directory.GetCurrentDirectory() / ".." / ".." / ".." / ".." / "..";
            var repository = GitRepository.FromLocalDirectory(rootDirectory, "master").NotNull();

            var rawUrl = $"https://raw.githubusercontent.com/{repository.Identifier}/{repository.Branch}";
            var blobUrl = $"https://github.com/{repository.Identifier}/blob/{repository.Branch}";
            var treeUrl = $"https://github.com/{repository.Identifier}/tree/{repository.Branch}";

            repository.GetGitHubDownloadUrl(rootDirectory / "LICENSE").Should().Be($"{rawUrl}/LICENSE");

            repository.GetGitHubBrowseUrl("LICENSE").Should().Be($"{blobUrl}/LICENSE");
            repository.GetGitHubBrowseUrl("bootstrapping").Should().Be($"{treeUrl}/bootstrapping");

            repository.GetGitHubBrowseUrl(rootDirectory / "LICENSE").Should().Be($"{blobUrl}/LICENSE");
            repository.GetGitHubBrowseUrl(rootDirectory / "bootstrapping").Should().Be($"{treeUrl}/bootstrapping");
            repository.GetGitHubBrowseUrl(rootDirectory / "bootstrapping" / "setup.sh").Should().Be($"{blobUrl}/bootstrapping/setup.sh");

            repository.GetGitHubBrowseUrl("directory", itemType: GitHubItemType.Directory).Should().Be($"{treeUrl}/directory");
            repository.GetGitHubBrowseUrl("dir/file", itemType: GitHubItemType.File).Should().Be($"{blobUrl}/dir/file");
        }

        [Fact]
        public void GitHubRepositoryFromUrlTest()
        {
            var repository = GitRepository.FromUrl("https://github.com/nuke-build/nuke", "dev");

            repository.GetGitHubBrowseUrl("LICENSE", itemType: GitHubItemType.File).Should().Be($"{repository}/blob/dev/LICENSE");
            repository.GetGitHubBrowseUrl("bootstrapping", itemType: GitHubItemType.Directory).Should().Be($"{repository}/tree/dev/bootstrapping");
        }
    }
}
