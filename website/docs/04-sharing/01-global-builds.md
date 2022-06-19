---
title: Global Builds
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';

Instead of adding and maintaining build projects in all your repositories, you can also build them by convention using a global build. Global builds are based on the concept of [.NET global tools](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools) and additionally include all the necessary tools referenced through NuGet packages. That means that for building one of your repositories, you only need to install and execute your pre-packaged build.

## Packaging

As a first step, you need to extend the build project file with the [necessary information for global tool packaging](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-create#setup-the-global-tool). Particularly, that includes the `PackAsTool` and `ToolCommandName` property:

```xml title="MyBuild.csproj"
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    // highlight-start
    <PackAsTool>true</PackAsTool>
    <ToolCommandName>my-build</ToolCommandName>
    // highlight-end
  </PropertyGroup>

</Project>
```

Afterwards, the project can be packaged and deployed as usual:

```powershell
# terminal-command
dotnet pack --version <version>
# terminal-command
dotnet nuget push MyBuild.<version>.nupkg --source <source> --api-key <token>
```

:::note
Currently, [single-file deployments](https://docs.microsoft.com/en-us/dotnet/core/deploying/single-file/overview) are not supported. That means that the operating system must have the .NET SDK installed. Feel free to track the [related GitHub issue](https://github.com/nuke-build/nuke/issues/822) for any updates.
:::

## Installation

Once the global build is packaged and deployed, you can install it either locally to a repository or globally on your development machine:

<Tabs groupId="tool-type">
  <TabItem value="local-tool" label="Local Tool" default>

```powershell
# terminal-command
dotnet new tool-manifest
# terminal-command
dotnet tool install MyBuild
```

  </TabItem>
  <TabItem value="global-tool" label="Global Tool">

```powershell
# terminal-command
dotnet tool install -g MyBuild
```

  </TabItem>
</Tabs>

:::tip
When you want to guarantee reproducibility, local tools are the better fit since the version is pinned individually for every repository. Global tools, on the other hand, provide more convenience in that you're always building with the same version. This is especially helpful when your conventions, like folder structure and namings, are already well evolved.
:::

## Execution

After installation, you can invoke the build through the command that you've specified in `ToolCommandName`. As per the example from above:

<Tabs groupId="tool-type">
  <TabItem value="local-tool" label="Local Tool" default>

```powershell
# terminal-command
dotnet my-build [args]
```

  </TabItem>
  <TabItem value="global-tool" label="Global Tool">

```powershell
# terminal-command
my-build [args]
```

  </TabItem>
</Tabs>
