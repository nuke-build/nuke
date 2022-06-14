---
title: TeamCity
---

Running on [TeamCity](https://www.jetbrains.com/teamcity/) will automatically enable custom theming for your build log output including [collapsible blocks](https://www.jetbrains.com/help/teamcity/service-messages.html#Blocks+of+Service+Messages) for better structuring:

![TeamCity Log Output](/img/docs/teamcity-light.png#gh-light-mode-only)
![TeamCity Log Output](/img/docs/teamcity-dark.png#gh-dark-mode-only)

:::info
Please refer to the official [TeamCity documentation](https://www.jetbrains.com/help/teamcity/teamcity-documentation.html) for questions not covered here.
:::

## Environment Variables

You can access [predefined parameters](https://www.jetbrains.com/help/teamcity/predefined-build-parameters.html) by using the `TeamCity` class:

```csharp
TeamCity TeamCity => TeamCity.Instance;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("Branch = {Branch}", TeamCity.BranchName);
        Log.Information("Commit = {Commit}", TeamCity.BuildVcsNumber);
    });
```

<details>
<summary>Exhaustive list of strongly-typed properties</summary>

```csharp
class TeamCity
{
    string                              AuthPassword            { get; }
    string                              AuthUserId              { get; }
    string                              BranchName              { get; }
    string                              BuildConfiguration      { get; }
    long                                BuildId                 { get; }
    string                              BuildNumber             { get; }
    string                              BuildTypeId             { get; }
    string                              BuildVcsNumber          { get; }
    IReadOnlyDictionary<string, string> ConfigurationProperties { get; }
    bool                                IsBuildPersonal         { get; }
    bool                                IsPullRequest           { get; }
    string                              ProjectId               { get; }
    string                              ProjectName             { get; }
    long?                               PullRequestNumber       { get; }
    string                              PullRequestSourceBranch { get; }
    string                              PullRequestTargetBranch { get; }
    string                              PullRequestTitle        { get; }
    IReadOnlyCollection<string>         RecentlyFailedTests     { get; }
    IReadOnlyDictionary<string, string> RunnerProperties        { get; }
    string                              ServerUrl               { get; }
    IReadOnlyDictionary<string, string> SystemProperties        { get; }
    string                              Version                 { get; }
}
```

</details>

## Configuration Generation

You can generate [build configuration files](https://www.jetbrains.com/help/teamcity/kotlin-dsl.html) from your existing target definitions by adding the `TeamCity` attribute. For instance, you can run the `Compile` target on every push with the latest Ubuntu image:

```csharp title="Build.cs"
[TeamCity(
    VcsTriggeredTargets = new[] { nameof(Compile) })]
class Build : NukeBuild { /* ... */ }
``` 

<details>
<summary>Generated output</summary>

```kotlin title=".teamcity/settings.kts"
project {
    buildType(Compile)
}

object Compile : BuildType({
    name = "Compile"
    vcs {
        root(DslContext.settingsRoot)
        cleanCheckout = true
    }
    steps {
        exec {
            path = "build.cmd"
            arguments = "Compile"
            conditions { contains("teamcity.agent.jvm.os.name", "Windows") }
        }
        exec {
            path = "build.sh"
            arguments = "Compile"
            conditions { doesNotContain("teamcity.agent.jvm.os.name", "Windows") }
        }
    }
    params {
        text(
            "teamcity.ui.runButton.caption",
            "Compile",
            display = ParameterDisplay.HIDDEN)
    }
    triggers {
        vcs {
            triggerRules = "+:**"
        }
    }
})
```

</details>

:::info
Whenever you make changes to the attribute, you have to [run the build](../01-getting-started/03-execution.md) at least once to regenerate the pipelines file.
:::

### Artifacts

If your targets produce artifacts, like packages or coverage reports, you can publish those directly from the target definition:

```csharp
Target Pack => _ => _
    .Produces(PackagesDirectory / "*.nupkg")
    .Executes(() => { /* Implementation */ });
```

<details>
<summary>Generated output</summary>

```kotlin title=".teamcity/settings.kts"
object Pack : BuildType({
    artifactRules = "output/packages/*.nupkg => output/packages"
}
```
</details>

After your build has finished, those artifacts will be listed under the artifacts tab:

<p style={{maxWidth:'780px'}}>

![TeamCity Artifacts Tab](/img/docs/teamcity-artifacts.png)

</p>

### Importing Secrets

If you want to use [secret variables](https://www.jetbrains.com/help/teamcity/storing-project-settings-in-version-control.html#Storing+Secure+Settings) from your TeamCity project, you can use the `ImportSecrets` property and `TeamCityToken` attribute to automatically load them into a [secret parameter](../02-fundamentals/06-parameters.md#secret-parameters) defined in your build:

```csharp title="Build.cs"
[TeamCity(
    // ...
    ImportSecrets = new[] { nameof(NuGetApiKey) })]
[TeamCityToken(nameof(NuGetApiKey), "<guid>")]
class Build : NukeBuild
{
    [Parameter] [Secret] readonly string NuGetApiKey;
}
```

<details>
<summary>Generated output</summary>

```yaml title=".teamcity/settings.kts"
project {
    params {
        password (
            "env.NuGetApiKey",
            label = "NuGetApiKey",
            value = "credentialsJSON:<guid>",
            display = ParameterDisplay.HIDDEN)
    }
}
```

</details>

:::note
If you're facing any issues, make sure that the name in the TeamCity settings is the same as generated into the pipelines file.
:::

## Using Credentials

For every build run, TeamCity generates a pair of [one-time credentials](https://www.jetbrains.com/help/teamcity/rest/teamcity-rest-api-documentation.html#REST+Authentication) that you can use to authenticate with the [TeamCity API](https://www.jetbrains.com/help/teamcity/rest/teamcity-rest-api-documentation.html):

```csharp title="Build.cs"
class Build : NukeBuild
{
    TeamCity TeamCity => TeamCity.Instance;

    Target Request => _ => _
        .Executes(() =>
        {
            Log.Information("UserId = {UserId}", TeamCity.AuthUserId);
            Log.Information("Password = {Password}", TeamCity.AuthPassword);
        });
}
```
