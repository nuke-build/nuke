// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Git;
using Nuke.Common.Git.Url;
using Xunit;

namespace Nuke.Common.Tests
{
    public class GitRepositoryTest
    {
        [Theory]
        [InlineData("https://github.com/nuke-build", "github.com", "nuke-build", GitProtocol.https)]
        [InlineData("https://github.com/nuke-build/", "github.com", "nuke-build", GitProtocol.https)]
        [InlineData("https://github.com/nuke-build/nuke", "github.com", "nuke-build/nuke", GitProtocol.https)]
        [InlineData("https://github.com/nuke-build/nuke.git", "github.com", "nuke-build/nuke", GitProtocol.https)]
        [InlineData("https://user:pass@github.com/nuke-build/nuke.git", "github.com", "nuke-build/nuke", GitProtocol.https)]
        [InlineData(" https://github.com/TdMxm/nuke.git", "github.com", "TdMxm/nuke", GitProtocol.https)]
        [InlineData("git@git.test.org:test", "git.test.org", "test", GitProtocol.ssh)]
        [InlineData("git@git.test.org/test", "git.test.org", "test", GitProtocol.ssh)]
        [InlineData("git@git.test.org/test/", "git.test.org", "test", GitProtocol.ssh)]
        [InlineData("git@git.test.org/test.git", "git.test.org", "test", GitProtocol.ssh)]
        [InlineData("ssh://git@git.test.org/test.git", "git.test.org", "test", GitProtocol.ssh)]
        [InlineData("ssh://git@git.test.org:1234/test.git", "git.test.org", "test", GitProtocol.ssh)]
        [InlineData("ssh://git.test.org/test/test", "git.test.org", "test/test", GitProtocol.ssh)]
        [InlineData("ssh://git.test.org:1234/test/test", "git.test.org", "test/test", GitProtocol.ssh)]
        [InlineData("https://git.test.org:1234/test/test", "git.test.org", "test/test", GitProtocol.https)]
        [InlineData("git://git.test.org:1234/test/test", "git.test.org", "test/test", GitProtocol.git)]
        [InlineData("git://git.test.org/test/test", "git.test.org", "test/test", GitProtocol.git)]
        public void FromUrlTest(string url, string endpoint, string identifier, GitProtocol protocol)
        {
            var repository = GitRepository.FromUrl(url);
            repository.Url.Endpoint.Should().Be(endpoint);
            repository.Url.Identifier.Should().Be(identifier);
            repository.Url.Protocol.Should().Be(protocol);
        }

        [Fact]
        public void FromDirectoryTest()
        {
            var repository = GitRepository.FromLocalDirectory(Directory.GetCurrentDirectory()).NotNull();
            repository.Url.Endpoint.Should().NotBeNullOrEmpty();
            repository.Url.Identifier.Should().NotBeNullOrEmpty();
            repository.LocalDirectory.Should().NotBeNullOrEmpty();
            repository.Head.Should().NotBeNullOrEmpty();
        }
    }
}
