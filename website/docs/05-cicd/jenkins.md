---
title: Jenkins
---

Running on [Jenkins](https://www.jenkins.io/) will use the standard theming for your build log output.

:::info
Please refer to the official [Jenkins documentation](https://www.jenkins.io/doc/) for questions not covered here.
:::

## Environment Variables

You can access [predefined environment variables](https://wiki.jenkins.io/display/JENKINS/Building+a+software+project#Buildingasoftwareproject-belowJenkinsSetEnvironmentVariables) by using the `Jenkins` class:

```csharp
Jenkins Jenkins => Jenkins.Instance;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("Branch = {Branch}", Jenkins.GitBranch);
        Log.Information("Commit = {Commit}", Jenkins.GitCommit);
    });
```

<details>
<summary>Exhaustive list of strongly-typed properties</summary>

```csharp
class Jenkins
{
    string BranchName                  { get; }
    string BuilDisplayName             { get; }
    int    BuildNumber                 { get; }
    string BuildTag                    { get; }
    string ChangeId                    { get; }
    int    ExecutorNumber              { get; }
    string GitBranch                   { get; }
    string GitCommit                   { get; }
    string GitPreviousCommit           { get; }
    string GitPreviousSuccessfulCommit { get; }
    string GitUrl                      { get; }
    string JenkinsHome                 { get; }
    string JenkinsServerCookie         { get; }
    string JobBaseName                 { get; }
    string JobDisplayUrl               { get; }
    string JobName                     { get; }
    string NodeLabels                  { get; }
    string NodeName                    { get; }
    string RunChangesDisplayUrl        { get; }
    string RunDisplayUrl               { get; }
    string Workspace                   { get; }
}
```

</details>
