---
title: Repository Insights
---

Having knowledge about the current branch, applied tags, and the repository origin is eminently important in various scenarios. For instance, the deployment destination for an application is different whether executed from a release or personal branch. An announcement target may only be executed when running on the main branch. And in many cases it is advisable to include repository metadata, like origin and commit hash, into the artifacts for better traceability.

You can use the `GitRepositoryAttribute` on a `GitRepository` field or property, to automatically load all relevant information for the current revision at the beginning of build execution:

<!-- snippet: repository-information -->
```cs
[GitRepository] readonly GitRepository Repository;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("Commit = {Value}", Repository.Commit);
        Log.Information("Branch = {Value}", Repository.Branch);
        Log.Information("Tags = {Value}", Repository.Tags);

        Log.Information("main branch = {Value}", Repository.IsOnMainBranch());
        Log.Information("main/master branch = {Value}", Repository.IsOnMainOrMasterBranch());
        Log.Information("release/* branch = {Value}", Repository.IsOnReleaseBranch());
        Log.Information("hotfix/* branch = {Value}", Repository.IsOnHotfixBranch());

        Log.Information("Https URL = {Value}", Repository.HttpsUrl);
        Log.Information("SSH URL = {Value}", Repository.SshUrl);
    });
```
<!-- endSnippet -->

:::tip
Repository insights allow you to design your targets in a flexible manner using [requirements](../02-fundamentals/05-targets.md#requirements), [conditional execution](../02-fundamentals/05-targets.md#conditional-execution), or hybrid implementations:

<!-- snippet: repository-information-use-cases -->
```cs
[GitRepository] readonly GitRepository Repository;
string OriginalRepositoryUrl => "https://github.com/nuke-build/nuke";

Target Deploy => _ => _
    .Requires(() => Repository.IsOnMainOrMasterBranch());

Target CheckMilestone => _ => _
    .OnlyWhenStatic(() => Repository.HttpsUrl.EqualsOrdinalIgnoreCase(OriginalRepositoryUrl));

Target Hotfix => _ => _
    .Executes(() =>
    {
        if (Repository.IsOnHotfixBranch())
            FinishHotfix();
        else
            CreateHotfix();
    });
```
<!-- endSnippet -->
:::tip

:::info
You can also manually create a `GitRepository` instance:

```c#
var repository1 = GitRepository.FromLocalDirectory(directory);
var repository2 = GitRepository.FromUrl(url);
```

The only difference between `FromUrl` and `FromLocalDirectory` is that the latter can initialize more properties, including `Commit`, `Tags`, and `RemoteBranch`.
:::

## GitHub Integration

As one of the most popular Git hosting services, NUKE provides several methods to retrieve specific **identifiers and links** from a repository:

<!-- snippet: repository-information-github -->
```cs
// Get repository owner and name
var (owner, name) = (Repository.GetGitHubOwner(), Repository.GetGitHubName());

// Get commit details URL when Repository is fully-synced
var commitUrl = Repository.GetGitHubCommitUrl(Repository.Commit);

// Get comparison URL between tags
var comparisonUrl = Repository.GetGitHubCompareTagsUrl("1.0.1", "1.0.2");

// Get file download URL
var downloadUrl = Repository.GetGitHubDownloadUrl(RootDirectory / "CHANGELOG.md", branch: "main");
```
<!-- endSnippet -->

You can also further interact with the repository using the [Octokit.NET](https://github.com/octokit/octokit.net) integration:

<!-- snippet: repository-information-github-octokit -->
```cs
// Get the default branch
var defaultBranch = Repository.GetDefaultBranch();

// Get the latest release
var latestRelease = Repository.GetLatestRelease(includePrerelease: false);
```
<!-- endSnippet -->

For certain operations you may initialize an **authorized client**:

<!-- snippet: repository-information-github-octokit-authed -->
```cs
// Set credentials for authorized actions
var credentials = new Credentials(GitHubActions.Instance.Token);
GitHubTasks.GitHubClient = new GitHubClient(
    new ProductHeaderValue(nameof(NukeBuild)),
    new InMemoryCredentialStore(credentials));

// Create and close a milestone
Repository.CreateGitHubMilestone("5.1.0");
Repository.CloseGitHubMilestone("5.1.0", enableIssueChecks: true);
```
<!-- endSnippet -->
