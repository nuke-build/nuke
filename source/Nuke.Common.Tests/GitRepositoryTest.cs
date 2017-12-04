// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Git;
using Nuke.Core.IO;
using Nuke.Core.Utilities;
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
        public void FromUrlTest (string url, string endpoint, string identifier)
        {
            var repository = GitRepository.FromUrl(url);
            repository.Endpoint.Should().Be(endpoint);
            repository.Identifier.Should().Be(identifier);
        }

        [Fact]
        public void FromDirectoryTest ()
        {
            var repository = GitRepository.FromLocalDirectory(Directory.GetCurrentDirectory());
            repository.Endpoint.Should().NotBeNullOrEmpty();
            repository.Identifier.Should().NotBeNullOrEmpty();
            repository.LocalDirectory.Should().NotBeNullOrEmpty();
            repository.Head.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void GitHubRepositoryFromLocalDirectoryTest ()
        {
            var rootDirectory = (PathConstruction.AbsolutePath) Directory.GetCurrentDirectory() / ".." / ".." / ".." / ".." / "..";
            var repository = GitRepository.FromLocalDirectory(rootDirectory);
            var httpsUrl = repository.HttpsUrl.TrimEnd(".git");
            var branch = repository.Branch ?? "master";

            repository.GetGitHubBrowseUrl("LICENSE").Should().Be($"{httpsUrl}/blob/{branch}/LICENSE");
            repository.GetGitHubBrowseUrl("bootstrapping").Should().Be($"{httpsUrl}/tree/{branch}/bootstrapping");

            repository.GetGitHubBrowseUrl(rootDirectory / "LICENSE").Should().Be($"{httpsUrl}/blob/{branch}/LICENSE");
            repository.GetGitHubBrowseUrl(rootDirectory / "bootstrapping").Should().Be($"{httpsUrl}/tree/{branch}/bootstrapping");

            repository.GetGitHubBrowseUrl("directory", itemType: GitHubItemType.Directory).Should().Be($"{httpsUrl}/tree/{branch}/directory");
            repository.GetGitHubBrowseUrl("dir/file", itemType: GitHubItemType.File).Should().Be($"{httpsUrl}/blob/{branch}/dir/file");

            var rawUrl = $"https://raw.githubusercontent.com/{repository.Identifier}";
            repository.GetGitHubDownloadUrl(rootDirectory / "LICENSE").Should().Be($"{rawUrl}/blob/master/LICENSE");
        }

        [Fact]
        public void GitHubRepositoryFromUrlTest ()
        {
            var repository = GitRepository.FromUrl("https://github.com/nuke-build/nuke");
            var httpsUrl = repository.HttpsUrl.TrimEnd(".git");
            var branch = "dev";

            repository.GetGitHubBrowseUrl("LICENSE", branch, GitHubItemType.File).Should().Be($"{httpsUrl}/blob/{branch}/LICENSE");
            repository.GetGitHubBrowseUrl("bootstrapping", branch, GitHubItemType.Directory).Should().Be($"{httpsUrl}/tree/{branch}/bootstrapping");
        }
    }
}
