---
title: Bitbucket
---

Running on [Bitbucket](https://bitbucket.org/) will use the standard theming for your build log output.

:::info
Please refer to the official [Bitbucket documentation](https://confluence.atlassian.com/bitbucketserver/) for questions not covered here.
:::

## Environment Variables

You can access [predefined environment variables](https://support.atlassian.com/bitbucket-cloud/docs/variables-and-secrets/) by using the `Bitbucket` class:

```csharp
Bitbucket Bitbucket => Bitbucket.Instance;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("Branch = {Branch}", Bitbucket.Branch);
        Log.Information("Commit = {Commit}", Bitbucket.Commit);
    });
```

<details>
<summary>Exhaustive list of strongly-typed properties</summary>

```csharp
class Bitbucket
{
    string Bookmark                     { get; }
    string Branch                       { get; }
    long   BuildNumber                  { get; }
    string CloneDirectory               { get; }
    string Commit                       { get; }
    string DeploymentEnvironment        { get; }
    string DeploymentEnvironmentUuid    { get; }
    string ExitCode                     { get; }
    string GitHttpOrigin                { get; }
    string GitSshOrigin                 { get; }
    int    ParallelStep                 { get; }
    int    ParallelStepCount            { get; }
    string PipelineUuid                 { get; }
    string ProjectKey                   { get; }
    string ProjectUuid                  { get; }
    string PullRequestDestinationBranch { get; }
    int    PullRequestId                { get; }
    string RepositoryFullName           { get; }
    string RepositorySlug               { get; }
    string RepositoryUuid               { get; }
    string StepOidcToken                { get; }
    string StepTriggererUuid            { get; }
    string StepUuid                     { get; }
    string Tag                          { get; }
    string Workspace                    { get; }
}
```

</details>
