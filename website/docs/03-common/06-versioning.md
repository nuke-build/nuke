---
title: Versioning Artifacts
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';

Whenever a build produces artifacts, those should be identifiable with a unique version number. This avoids making wrong expectations about available features or fixed bugs, and allows for clear discussions between developers, QA team, and product users. The most common version approaches are are [semantic versioning](https://semver.org/) and [calendar versioning](https://calver.org/).

## Repository-based Versioning

NUKE supports 4 different tools that help generating version numbers from your repository and its commits. Each of these tools comes with its own attribute that populates the field with the information calculated:

<Tabs>
  <TabItem value="gitversion" label="GitVersion" default>

:::note
Please refer to the [GitVersion documentation](https://gitversion.net/docs/reference/configuration) for any questions.
:::

```bash title="Tool Installation"
nuke :add-package GitVersion.Tool
```

```csharp title="Build.cs"
[GitVersion]
readonly GitVersion GitVersion;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("GitVersion = {Value}", GitVersion.MajorMinorPatch);
    });
```

  </TabItem>
  <TabItem value="nerdbank" label="Nerdbank">

:::note
Please refer to the [Nerdbank.GitVersioning documentation](https://github.com/dotnet/Nerdbank.GitVersioning/blob/master/doc/versionJson.md) for any questions.
:::

```bash title="Tool Installation"
nuke :add-package Nerdbank.GitVersioning
```

```csharp title="Build.cs"
[NerdbankGitVersioning]
readonly NerdbankGitVersioning NerdbankVersioning;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("NerdbankVersioning = {Value}", NerdbankVersioning.SimpleVersion);
    });
```

  </TabItem>
  <TabItem value="octoversion" label="OctoVersion">

:::note
Please refer to the [OctoVersion documentation](https://github.com/OctopusDeploy/OctoVersion#configuration) for any questions.
:::

```bash title="Tool Installation"
nuke :add-package OctoVersion.Tool
```

```csharp title="Build.cs"
[OctoVersion]
readonly OctoVersionInfo OctoVersionInfo;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("OctoVersionInfo = {Value}", OctoVersionInfo.MajorMinorPatch);
    });
```

  </TabItem>
  <TabItem value="minver" label="MinVer">

:::note
Please refer to the [MinVer documentation](https://github.com/adamralph/minver#usage) for any questions.
:::

```bash title="Tool Installation"
nuke :add-package MinVer
```

```csharp title="Build.cs"
[MinVer]
readonly MinVer MinVer;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("MinVer = {Value}", MinVer.Version);
    });
```

  </TabItem>
</Tabs>

:::info
Note that when the versioning tool fails to calculate version numbers, a warning will be logged and the attributed field remains uninitialized. In that case, you can try executing the issued command manually or `nuke --verbosity verbose` to reveal more detailed information. In most cases, the repository is either not initialized, has no commits, or is missing the tool-specific configuration file.
:::

## Dependency-based Versioning

When your versioning is affected by external dependencies, NUKE provides another mechanism to load the latest version of those prior to build execution. Each attribute provides various properties to control which versions should be considered and how it should be transformed:

<Tabs>
  <TabItem value="nuget" label="NuGet&nbsp;Packages" default>

```csharp title="Build.cs"
[LatestNuGetVersion(
    packageId: "JetBrains.ReSharper.SDK",
    IncludePrerelease = true)]
readonly NuGetVersion ReSharperVersion;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("ReSharperVersion = {Value}", ReSharperVersion);
    });
```

  </TabItem>
  <TabItem value="github" label="GitHub&nbsp;Releases">

```csharp title="Build.cs"
[LatestGitHubRelease(
    identifier: "JetBrains/gradle-intellij-plugin",
    TrimPrefix = true)]
readonly string GradlePluginVersion;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("GradlePluginVersion = {Value}", GradlePluginVersion);
    });
```

  </TabItem>
  <TabItem value="myget" label="MyGet&nbsp;Feeds">

```csharp title="Build.cs"
[LatestMyGetVersion(
    feed: "rd-snapshots",
    package: "rd-gen")]
readonly string RdGenVersion;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("RdGenVersion = {Value}", RdGenVersion);
    });
```

  </TabItem>
  <TabItem value="maven" label="Maven&nbsp;Packages">

```csharp title="Build.cs"
[LatestMavenVersion(
    repository: "plugins.gradle.org",
    groupId: "org.jetbrains.kotlin.jvm",
    artifactId: "org.jetbrains.kotlin.jvm.gradle.plugin")]
readonly string KotlinJvmVersion;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("KotlinJvmVersion = {Value}", KotlinJvmVersion);
    });
```

  </TabItem>
</Tabs>

## Related Resources

You can learn more about different versioning aspects from the following resources:

- [Why I don't start versions at 0.x any more](https://codeblog.jonskeet.uk/2019/10/20/why-i-dont-start-versions-at-0-x-any-more/) by Jon Skeet
- [Versioning, and how it makes our heads hurt](https://www.youtube.com/watch?v=GLr72TnSnPw) by Jon Skeet
