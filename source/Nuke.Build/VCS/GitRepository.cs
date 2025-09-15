// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.Git;

public enum GitProtocol
{
    Https,
    Ssh
}

[PublicAPI]
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class GitRepository
{
    private const string FallbackRemoteName = "origin";

    public static GitRepository FromUrl(string url, string branch = null)
    {
        var (protocol, endpoint, identifier) = GetRemoteConnectionFromUrl(url);
        return new GitRepository(
            protocol,
            endpoint,
            identifier,
            branch,
            localDirectory: null,
            head: null,
            commit: null,
            tags: null,
            remoteName: null,
            remoteBranch: null);
    }

    /// <summary>
    /// Obtains information from a local git repository.
    /// </summary>
    public static GitRepository FromLocalDirectory(AbsolutePath directory)
    {
        var metadata = GetGitMetadata(directory);

        var head = metadata.Head;
        var branch = (GetBranchFromCI() ?? GetHeadIfAttached(head))?.TrimStart("refs/heads/").TrimStart("origin/");
        var commit = GetCommitFromCI() ?? GetCommitFromHead(metadata.GitDirectory, head);
        var tags = GetTagsFromCommit(metadata.GitDirectory, commit);
        var (remoteName, remoteBranch) = GetRemoteNameAndBranch(metadata.GitDirectory, branch);
        var (protocol, endpoint, identifier) = GetRemoteConnectionFromConfig(metadata.GitDirectory, remoteName ?? FallbackRemoteName);

        return new GitRepository(
            protocol,
            endpoint,
            identifier,
            branch,
            metadata.RootDirectory,
            head,
            commit,
            tags,
            remoteName,
            remoteBranch);
    }

    /// <summary>
    /// Obtains information from a local git repository.
    /// </summary>
    private static GitMetadata GetGitMetadata(AbsolutePath directory)
    {
        var rootDirectory = directory.FindParentOrSelf(x => x.ContainsDirectory(".git"));

        if (rootDirectory is not null)
        {
            var gitDirectory = rootDirectory / ".git";
            var head = GetHead(gitDirectory);
            return new GitMetadata(rootDirectory, gitDirectory, head);
        }

        rootDirectory = directory.FindParentOrSelf(x => x.ContainsFile(".git"))
            .NotNull("No parent Git directory or file found");

        const string gitDirPrefix = "gitdir:";
        var gitFile = rootDirectory / ".git";

        var worktreeGitDirLine = ReadGitFileSecurely(gitFile, gitDirPrefix);
        var worktreeGitDir = ParseAndValidateWorktreeGitDir(worktreeGitDirLine, gitDirPrefix, rootDirectory);

        var mainWorktreeGitDir = worktreeGitDir
            .FindParentOrSelf(x => x.Name == ".git")
            .NotNull("Invalid worktree configuration: no parent Git directory found");

        var worktreeHead = GetHead(worktreeGitDir);
        return new GitMetadata(rootDirectory, mainWorktreeGitDir, worktreeHead);
    }

    private static string ReadGitFileSecurely(AbsolutePath gitFile, string expectedPrefix)
    {
        const int maxFileSize = 4096;

        if (!gitFile.Exists())
            throw new ArgumentException("Git file does not exist");

        var fileInfo = new FileInfo(gitFile);
        if (fileInfo.Length > maxFileSize)
            throw new ArgumentException($"Git file exceeds maximum size of {maxFileSize} bytes");

        var lines = gitFile.ReadAllLines();
        if (lines.Length == 0)
            throw new ArgumentException("Git file is empty");

        var targetLine = lines.FirstOrDefault(line =>
            !string.IsNullOrWhiteSpace(line) &&
            line.TrimStart().StartsWith(expectedPrefix, StringComparison.OrdinalIgnoreCase));

        if (string.IsNullOrEmpty(targetLine))
            throw new ArgumentException($"Required '{expectedPrefix}' entry not found in git file");

        return targetLine.Trim();
    }

    private static AbsolutePath ParseAndValidateWorktreeGitDir(string worktreeGitDirLine, string gitDirPrefix, AbsolutePath rootDirectory)
    {
        var gitDirPath = worktreeGitDirLine
            .Substring(gitDirPrefix.Length)
            .Trim();

        if (string.IsNullOrWhiteSpace(gitDirPath))
            throw new ArgumentException("Invalid git directory path: path is empty");

        if (gitDirPath.Contains('\0') || gitDirPath.Any(c => char.IsControl(c) && c != '\t'))
            throw new ArgumentException("Invalid git directory path: contains invalid characters");

        if (gitDirPath.Contains(".."))
            throw new ArgumentException("Invalid git directory path: contains path traversal");

        AbsolutePath worktreeGitDir;
        try
        {
            worktreeGitDir = AbsolutePath.Create(gitDirPath);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Invalid git directory path: path does not exist or is inaccessible", ex);
        }

        string canonicalPath;
        try
        {
            canonicalPath = Path.GetFullPath(worktreeGitDir);
            worktreeGitDir = AbsolutePath.Create(canonicalPath);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Invalid git directory path: path does not exist or is inaccessible", ex);
        }

        string mainRepoGitDirCanonicalPath;
        try
        {
            var mainRepoGitDir = worktreeGitDir
                .FindParentOrSelf(x => x.Name == ".git")
                .NotNull("Invalid worktree configuration: no parent Git directory found");
            mainRepoGitDirCanonicalPath = Path.GetFullPath(mainRepoGitDir);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Invalid git directory path: path does not exist or is inaccessible", ex);
        }

        if (!IsPathWithinAllowedScope(canonicalPath, mainRepoGitDirCanonicalPath))
            throw new ArgumentException("Invalid git directory path: outside allowed scope");

        if (!worktreeGitDir.Exists())
            throw new ArgumentException("Git directory does not exist");

        return worktreeGitDir;
    }

    internal static bool IsPathWithinAllowedScope(string targetPath, string basePath)
    {
        var targetParts = targetPath.Split(PathConstruction.AllSeparators)
            .Where(p => !string.IsNullOrEmpty(p))
            .ToArray();
        var baseParts = basePath.Split(PathConstruction.AllSeparators)
            .Where(p => !string.IsNullOrEmpty(p))
            .ToArray();

        if (targetParts.Contains(".."))
            return false;

        if (targetParts.Length < baseParts.Length)
            return false;

        for (var i = 0; i < baseParts.Length; i++)
        {
            if (!string.Equals(targetParts[i], baseParts[i], StringComparison.OrdinalIgnoreCase))
                return false;
        }

        return true;
    }

    private static (string Name, string Branch) GetRemoteNameAndBranch(AbsolutePath gitDirectory, [CanBeNull] string branch)
    {
        if (branch == null)
            return (null, null);

        var configFile = gitDirectory / "config";
        var configFileContent = configFile.ReadAllLines();
        var data = configFileContent
            .Select(x => x.Trim())
            .SkipWhile(x => x != $"[branch {branch.DoubleQuote()}]")
            .Skip(1)
            .TakeWhile(x => !x.StartsWith("["))
            .Select(x => x.Split('='))
            .ToDictionary(x => x.ElementAt(0).Trim(), x => x.ElementAt(1).Trim());
        return data.TryGetValue("remote", out var remote) && data.TryGetValue("merge", out var merge)
            ? (remote, merge.TrimStart("refs/heads/"))
            : (null, null);
    }

    internal static string GetHeadIfAttached(string head)
    {
        return head.StartsWith("refs/heads/") ? head : null;
    }

    internal static string GetCommitFromHead(AbsolutePath gitDirectory, string head)
    {
        if (!head.StartsWith("refs/heads/"))
            return head;

        var headRefFile = gitDirectory / head;
        if (headRefFile.Exists())
            return headRefFile.ReadAllLines().First();

        var commit = GetPackedRefs(gitDirectory)
            .Where(x => x.Reference == head)
            .Select(x => x.Commit)
            .FirstOrDefault();

        commit.NotNull("Could not find commit information");

        return commit;
    }

    private static string GetHead(AbsolutePath gitDirectory)
    {
        var headFile = gitDirectory / "HEAD";
        Assert.FileExists(headFile);
        return headFile.ReadAllText().TrimStart("ref: ").Trim();
    }

    [CanBeNull]
    internal static string GetBranchFromCI()
    {
        return (Host.Instance as IBuildServer)?.Branch;
    }

    [CanBeNull]
    internal static string GetCommitFromCI()
    {
        return (Host.Instance as IBuildServer)?.Commit;
    }

    private static IReadOnlyCollection<string> GetTagsFromCommit(AbsolutePath gitDirectory, string commit)
    {
        if (commit == null)
            return Array.Empty<string>();

        var packedTags = GetPackedRefs(gitDirectory)
            .Where(x => x.Commit == commit && x.Reference.StartsWithOrdinalIgnoreCase("refs/tags"))
            .Select(x => x.Reference.TrimStart("refs/tags/"));

        var tagsDirectory = gitDirectory / "refs" / "tags";
        var localTags = tagsDirectory
            .GlobFiles("**/*")
            .Where(x => x.ReadAllText().Trim() == commit)
            .Select(x => tagsDirectory.GetUnixRelativePathTo(x).ToString());

        return localTags.Concat(packedTags).ToList();
    }

    private static IEnumerable<(string Commit, string Reference)> GetPackedRefs(AbsolutePath gitDirectory)
    {
        var packedRefsFile = gitDirectory / "packed-refs";
        if (!packedRefsFile.Exists())
            return Array.Empty<(string Commit, string Reference)>();

        return packedRefsFile.ReadAllLines()
            .Where(x => !x.StartsWith("#") && !x.StartsWith("^"))
            .Select(x => x.Split(' '))
            .Select(x => (Commit: x[0], Reference: x[1]));
    }

    private static (GitProtocol Protocol, string Endpoint, string Identifier) GetRemoteConnectionFromUrl(string url)
    {
        var regex = new Regex(
            @"^(?'protocol'\w+)?(\:\/\/)?(?>(?'user'.*)@)?(?'endpoint'[^\/:]+)(?>\:(?'port'\d+))?[\/:](?'identifier'.*?)\/?(?>\.git)?$");
        var match = regex.Match(url.NotNull().Trim());

        Assert.True(match.Success, $"Url '{url}' could not be parsed.");
        var protocol = match.Groups["protocol"].Value.EqualsOrdinalIgnoreCase(GitProtocol.Https.ToString())
            ? GitProtocol.Https
            : GitProtocol.Ssh;
        return (protocol, match.Groups["endpoint"].Value, match.Groups["identifier"].Value);
    }

    private static (GitProtocol? Protocol, string Endpoint, string Identifier) GetRemoteConnectionFromConfig(
        AbsolutePath gitDirectory,
        string remote)
    {
        var configFile = gitDirectory / "config";
        var configFileContent = configFile.ReadAllLines();
        var url = configFileContent
            .Select(x => x.Trim())
            .SkipWhile(x => x != $"[remote {remote.DoubleQuote()}]")
            .Skip(1)
            .TakeWhile(x => !x.StartsWith("["))
            .SingleOrDefault(x => x.StartsWithOrdinalIgnoreCase("url = "))
            ?.Split('=').ElementAt(1)
            .Trim();

        if (url == null)
            return (null, null, null);

        return GetRemoteConnectionFromUrl(url);
    }

    public GitRepository(
        GitProtocol? protocol,
        string endpoint,
        string identifier,
        string branch,
        AbsolutePath localDirectory,
        string head,
        string commit,
        IReadOnlyCollection<string> tags,
        string remoteName,
        string remoteBranch)
    {
        Protocol = protocol;
        Endpoint = endpoint;
        Identifier = identifier;
        Branch = branch;
        LocalDirectory = localDirectory;
        Head = head;
        Commit = commit;
        Tags = tags;
        RemoteName = remoteName;
        RemoteBranch = remoteBranch;
    }

    /// <summary>Default protocol for the repository.</summary>
    public GitProtocol? Protocol { get; private set; }

    /// <summary>Endpoint for the repository. For instance <em>github.com</em>.</summary>
    public string Endpoint { get; private set; }

    /// <summary>Identifier of the repository.</summary>
    public string Identifier { get; private set; }

    /// <summary>Local path from which the repository was parsed.</summary>
    [CanBeNull]
    public AbsolutePath LocalDirectory { get; private set; }

    /// <summary>Current head; <c>null</c> if parsed from URL.</summary>
    [CanBeNull]
    public string Head { get; private set; }

    /// <summary>Current commit; <c>null</c> if parsed from URL.</summary>
    [CanBeNull]
    public string Commit { get; }

    /// <summary>List of tags; <c>null</c> if parsed from URL.</summary>
    public IReadOnlyCollection<string> Tags { get; }

    /// <summary>Name of the remote.</summary>
    [CanBeNull]
    public string RemoteName { get; }

    /// <summary>Name of the remote branch.</summary>
    [CanBeNull]
    public string RemoteBranch { get; }

    /// <summary>Current branch; <c>null</c> if head is detached.</summary>
    [CanBeNull]
    public string Branch { get; private set; }

    /// <summary>Url in the form of <c>https://endpoint/identifier.git</c></summary>
    [CanBeNull]
    public string HttpsUrl => Endpoint != null ? $"https://{Endpoint}/{Identifier}.git" : null;

    /// <summary>Url in the form of <c>git@endpoint:identifier.git</c></summary>
    [CanBeNull]
    public string SshUrl => Endpoint != null ? $"git@{Endpoint}:{Identifier}.git" : null;

    public GitRepository SetBranch(string branch)
    {
        return new GitRepository(
            Protocol,
            Endpoint,
            Identifier,
            branch,
            LocalDirectory,
            Head,
            Commit,
            Tags,
            RemoteName,
            RemoteBranch);
    }

    public override string ToString()
    {
        return (Protocol == GitProtocol.Https ? HttpsUrl : SshUrl).TrimEnd(".git");
    }

    private record GitMetadata(AbsolutePath RootDirectory, AbsolutePath GitDirectory, string Head);
}
