---
title: GitLab
---

Running on [GitLab](https://about.gitlab.com/) will automatically enable custom theming for your build log output including [collapsible sections](https://docs.gitlab.com/ee/ci/jobs/#expand-and-collapse-job-log-sections) for better structuring:

![GitLab Log Output](/img/docs/gitlab.png)

:::info
Please refer to the official [GitLab documentation](https://docs.gitlab.com/) for questions not covered here.
:::

## Environment Variables

You can access [predefined environment variables](https://docs.gitlab.com/ee/ci/variables/predefined_variables.html) by using the `GitLab` class:

```csharp
GitLab GitLab => GitLab.Instance;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("Branch = {Branch}", GitLab.CommitRefName);
        Log.Information("Commit = {Commit}", GitLab.CommitSha);
    });
```

<details>
<summary>Exhaustive list of strongly-typed properties</summary>

```csharp
class GitLab
{
    bool                    Ci                    { get; }
    string                  CommitRefName         { get; }
    string                  CommitRefSlug         { get; }
    string                  CommitSha             { get; }
    string                  CommitTag             { get; }
    string                  ConfigPath            { get; }
    bool                    DisposableEnvironment { get; }
    string                  GitLabUserEmail       { get; }
    long                    GitLabUserId          { get; }
    string                  GitLabUserLogin       { get; }
    string                  GitLabUserName        { get; }
    long                    JobId                 { get; }
    bool                    JobManual             { get; }
    string                  JobName               { get; }
    string                  JobStage              { get; }
    string                  JobToken              { get; }
    long                    PipelineId            { get; }
    string                  PipelineSource        { get; }
    bool                    PipelineTriggered     { get; }
    string                  ProjectDirectory      { get; }
    long                    ProjectId             { get; }
    string                  ProjectName           { get; }
    string                  ProjectNamespace      { get; }
    string                  ProjectPath           { get; }
    string                  ProjectPathSlug       { get; }
    string                  ProjectUrl            { get; }
    GitLabProjectVisibility ProjectVisibility     { get; }
    string                  Registry              { get; }
    string                  RegistryImage         { get; }
    string                  RegistryPassword      { get; }
    string                  RegistryUser          { get; }
    string                  RepositoryUrl         { get; }
    string                  RunnerDescription     { get; }
    long                    RunnerId              { get; }
    string                  RunnerTags            { get; }
    string                  ServerName            { get; }
    string                  ServerRevision        { get; }
    string                  ServerVersion         { get; }
}
```

</details>
