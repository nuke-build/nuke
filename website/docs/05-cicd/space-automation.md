---
title: Space Automation
---

Running on [JetBrains Space](https://www.jetbrains.com/space/) will use the standard theming for your build log output:

![Space Automation Log Output](/img/docs/space-automation-light.png#gh-light-mode-only)
![Space Automation Log Output](/img/docs/space-automation-dark.png#gh-dark-mode-only)

:::info
Please refer to the official [Space Automation documentation](https://www.jetbrains.com/help/space/getting-started.html) for questions not covered here.
:::

## Environment Variables

You can access [predefined environment variables](https://www.jetbrains.com/help/space/automation-environment-variables.html) by using the `SpaceAutomation` class:

```csharp
SpaceAutomation SpaceAutomation => SpaceAutomation.Instance;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("Branch = {Branch}", SpaceAutomation.GitBranch);
        Log.Information("Commit = {Commit}", SpaceAutomation.GitRevision);
    });
```

<details>
<summary>Exhaustive list of strongly-typed properties</summary>

```csharp
class SpaceAutomation
{
    string ApiUrl          { get; }
    string ClientId        { get; }
    string ClientSecret    { get; }
    string ExecutionNumber { get; }
    string GitBranch       { get; }
    string GitRevision     { get; }
    string ProjectKey      { get; }
    string RepositoryName  { get; }
}
```

</details>
