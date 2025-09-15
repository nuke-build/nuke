// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Xunit;

namespace Nuke.Common.Tests;

public class GitRepositoryTest
{
    [Theory]
    [InlineData("https://github.com/nuke-build", "github.com", "nuke-build")]
    [InlineData("https://github.com/nuke-build/", "github.com", "nuke-build")]
    [InlineData("https://github.com/nuke-build/nuke", "github.com", "nuke-build/nuke")]
    [InlineData("https://github.com/nuke-build/nuke.git", "github.com", "nuke-build/nuke")]
    [InlineData("https://user:pass@github.com/nuke-build/nuke.git", "github.com", "nuke-build/nuke")]
    [InlineData(" https://github.com/TdMxm/nuke.git", "github.com", "TdMxm/nuke")]
    [InlineData("git@git.test.org:test", "git.test.org", "test")]
    [InlineData("git@git.test.org/test", "git.test.org", "test")]
    [InlineData("git@git.test.org/test/", "git.test.org", "test")]
    [InlineData("git@git.test.org/test.git", "git.test.org", "test")]
    [InlineData("ssh://git@git.test.org/test.git", "git.test.org", "test")]
    [InlineData("ssh://git@git.test.org:1234/test.git", "git.test.org", "test")]
    [InlineData("ssh://git.test.org/test/test", "git.test.org", "test/test")]
    [InlineData("ssh://git.test.org:1234/test/test", "git.test.org", "test/test")]
    [InlineData("https://git.test.org:1234/test/test", "git.test.org", "test/test")]
    [InlineData("git://git.test.org:1234/test/test", "git.test.org", "test/test")]
    [InlineData("git://git.test.org/test/test", "git.test.org", "test/test")]
    public void FromUrlTest(string url, string endpoint, string identifier)
    {
        var repository = GitRepository.FromUrl(url);
        repository.Endpoint.Should().Be(endpoint);
        repository.Identifier.Should().Be(identifier);
    }

    [Theory]
    [InlineData("https://github.com/nuke-build", GitProtocol.Https)]
    [InlineData("git@git.test.org:test", GitProtocol.Ssh)]
    [InlineData("ssh://git.test.org:1234/test/test", GitProtocol.Ssh)]
    [InlineData("git://git.test.org:1234/test/test", GitProtocol.Ssh)]
    public void FromUrlProtocolTest(string url, GitProtocol protocol)
    {
        var repository = GitRepository.FromUrl(url);
        repository.Protocol.Should().Be(protocol);
    }

    [Fact]
    public void FromDirectoryTest()
    {
        var repository = GitRepository.FromLocalDirectory(Directory.GetCurrentDirectory()).NotNull();
        repository.Endpoint.Should().NotBeNullOrEmpty();
        repository.Identifier.Should().NotBeNullOrEmpty();
        repository.LocalDirectory.Should().NotBeNull();
        repository.Head.Should().NotBeNullOrEmpty();
        repository.Commit.Should().NotBeNullOrEmpty();
        repository.Tags.Should().NotBeNull();
    }

    [Fact]
    public void FromDirectoryWorktreeTest()
    {
        var tempDir = GetTemporaryDirectory();
        const string worktreeName = "test-worktree";
        var worktreePath = CreateWorktree(tempDir, worktreeName, "git-worktree-support");

        try
        {
            var repository = GitRepository.FromLocalDirectory(worktreePath);
            var mainRepository = GitRepository.FromLocalDirectory(Directory.GetCurrentDirectory());

            AssertWorktreeRepository(repository, mainRepository, worktreePath);
        }
        finally
        {
            CleanupWorktree(worktreePath);
            CleanupTemporaryDirectory(tempDir);
        }
    }

    [Fact]
    public void FromDirectoryWorktreeWithDifferentBranchTest()
    {
        var tempDir = GetTemporaryDirectory();
        const string worktreeName = "test-branch-worktree";
        const string branchName = "develop";
        var worktreePath = CreateWorktree(tempDir, worktreeName, branchName);

        try
        {
            var repository = GitRepository.FromLocalDirectory(worktreePath);
            var mainRepository = GitRepository.FromLocalDirectory(Directory.GetCurrentDirectory());

            AssertWorktreeRepository(repository, mainRepository, worktreePath);
            repository.Branch.Should().StartWith($"{branchName}-test-"); // Branch name includes unique suffix
        }
        finally
        {
            CleanupWorktree(worktreePath);
            CleanupTemporaryDirectory(tempDir);
        }
    }

    [Fact]
    public void FromDirectoryNestedWorktreeTest()
    {
        var tempDir = GetTemporaryDirectory();
        const string worktreeName = "nested-worktree";
        var worktreePath = CreateWorktree(tempDir, worktreeName, "git-worktree-support");
        var nestedPath = Path.Combine(worktreePath, "nested", "deeply", "nested");
        Directory.CreateDirectory(nestedPath);

        try
        {
            var repository = GitRepository.FromLocalDirectory(nestedPath);
            var mainRepository = GitRepository.FromLocalDirectory(Directory.GetCurrentDirectory());

            AssertWorktreeRepository(repository, mainRepository, worktreePath);
        }
        finally
        {
            CleanupWorktree(worktreePath);
            CleanupTemporaryDirectory(tempDir);
        }
    }

    [Fact]
    public void FromDirectoryWorktreeDetachedHeadTest()
    {
        var tempDir = GetTemporaryDirectory();
        const string worktreeName = "detached-head-worktree";
        var worktreePath = CreateWorktree(tempDir, worktreeName, "git-worktree-support");

        try
        {
            // Get a commit hash to checkout
            var commitHash = ProcessTasks.StartProcess("git", "rev-parse HEAD~1", workingDirectory: worktreePath)
                .AssertZeroExitCode()
                .Output
                .First()
                .Text
                .Trim();

            // Checkout the commit to create detached HEAD
            ProcessTasks.StartProcess("git", $"checkout {commitHash}", workingDirectory: worktreePath)
                .AssertZeroExitCode();

            var repository = GitRepository.FromLocalDirectory(worktreePath);
            var mainRepository = GitRepository.FromLocalDirectory(Directory.GetCurrentDirectory());

            repository.Endpoint.Should().Be(mainRepository.Endpoint);
            repository.Identifier.Should().Be(mainRepository.Identifier);
            repository.LocalDirectory.Should().Be(AbsolutePath.Create(worktreePath));
            repository.Branch.Should().BeNull(); // Detached HEAD should have no branch
            repository.Head.Should().Be(commitHash);
            repository.Commit.Should().Be(commitHash);
        }
        finally
        {
            CleanupWorktree(worktreePath);
            CleanupTemporaryDirectory(tempDir);
        }
    }

    [Fact]
    public void FromDirectoryWorktreeInvalidGitFileTest()
    {
        var tempDir = GetTemporaryDirectory();
        var invalidGitDir = Path.Combine(tempDir, "invalid-git");
        Directory.CreateDirectory(invalidGitDir);

        try
        {
            // Create an invalid .git file
            var gitFile = Path.Combine(invalidGitDir, ".git");
            File.WriteAllText(gitFile, "invalid content without gitdir prefix");

            var act = () => GitRepository.FromLocalDirectory(invalidGitDir);
            act.Should().Throw<Exception>()
                .WithMessage("*gitdir:*");
        }
        finally
        {
            CleanupTemporaryDirectory(tempDir);
        }
    }

    // Helper methods
    private static string GetTemporaryDirectory()
    {
        var tempDir = Path.Combine(Path.GetTempPath(), "nuke-test-" + Guid.NewGuid().ToString("N")[..8]);
        Directory.CreateDirectory(tempDir);
        return tempDir;
    }

    private static string CreateWorktree(string tempDir, string worktreeName, string branchName)
    {
        var worktreePath = Path.Combine(tempDir, worktreeName);
        var uniqueBranchName = $"{branchName}-test-{Guid.NewGuid().ToString("N")[..8]}";

        // Create a new branch from the specified branch and checkout in worktree
        ProcessTasks.StartProcess("git", $"worktree add -b {uniqueBranchName} {worktreePath} {branchName}", workingDirectory: Directory.GetCurrentDirectory())
            .AssertZeroExitCode();

        return worktreePath;
    }

    private static void CleanupWorktree(string worktreePath)
    {
        if (!Directory.Exists(worktreePath))
            return;

        try
        {
            ProcessTasks.StartProcess("git", $"worktree remove {worktreePath}", workingDirectory: Directory.GetCurrentDirectory())
                .AssertZeroExitCode();
        }
        catch
        {
            // If git worktree remove fails, force delete the directory
            Directory.Delete(worktreePath, recursive: true);
        }
    }

    private static void CleanupTemporaryDirectory(string tempDir)
    {
        if (!Directory.Exists(tempDir))
            return;

        try
        {
            Directory.Delete(tempDir, recursive: true);
        }
        catch
        {
            // Ignore cleanup errors
        }
    }

    private static void AssertWorktreeRepository(GitRepository worktreeRepo, GitRepository mainRepo, string expectedWorktreePath)
    {
        worktreeRepo.Endpoint.Should().Be(mainRepo.Endpoint);
        worktreeRepo.Identifier.Should().Be(mainRepo.Identifier);
        worktreeRepo.LocalDirectory.Should().Be(AbsolutePath.Create(expectedWorktreePath));
        worktreeRepo.Head.Should().NotBeNullOrEmpty();
        worktreeRepo.Commit.Should().NotBeNullOrEmpty();
        worktreeRepo.Tags.Should().NotBeNull();
    }
}
