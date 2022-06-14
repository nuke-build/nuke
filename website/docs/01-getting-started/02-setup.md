---
title: Build Setup
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';
import CodeBlock from '@theme/CodeBlock';
import AsciinemaPlayer from '../../src/components/AsciinemaPlayer';
import 'asciinema-player/dist/bundle/asciinema-player.css';

After [installing the NUKE global tool](01-installation.md), you can call it from anywhere on your machine to set up a new build:

```cmd
nuke :setup
```

:::tip
Preferably, you should run the setup from inside an existing repository. NUKE will search for the next upwards `.git` or `.svn` directory to determine the _build root directory_. If neither is found, it will use the current directory. You can also pass the `--root` parameter to specify that the current directory should be used as a root directory.
:::

During the setup, you'll be asked several questions to configure your build to your preferences:

<p style={{maxWidth:'700px'}}>
    <AsciinemaPlayer
        src="/casts/setup.cast"
        idleTimeLimit={2}
        // autoplay={true}
        poster="npt:5.715135"
        preload={true}
        // terminalFontFamily="'JetBrains Mono', Consolas, Menlo, 'Bitstream Vera Sans Mono', monospace"
        loop={true}/>
</p>

**Congratulations!** 🥳 Your first build has now been set up, and you can [run the build](03-execution.md) with the default implementation!

## Effective Changes

The setup will create a number of files in your repository and – if you've chosen so – add the build project to your solution file. Below, you can examine the structure  of added files and what they are used for:

```bash
<root-directory>
├── .nuke                           # Root directory marker
│   ├── build.schema.json           # Build schema file
│   └── parameters.json             # Default parameters file
│
├── build
│   ├── .editorconfig               # Common formatting
│   ├── _build.csproj               # Build project file
│   ├── _build.csproj.DotSettings   # ReSharper/Rider formatting
│   ├── Build.cs                    # Default build implementation
│   ├── Directory.Build.props       # MSBuild stop files
│   └── Directory.Build.targets
│
├── build.cmd                       # Cross-platform bootstrapping
├── build.ps1                       # Windows/PowerShell bootstrapping
└── build.sh                        # Linux/Shell bootstrapping
```

:::note
If you prefer, you _may_ choose to delete any of the bootstrapping scripts, MSBuild stop files, or formatting settings. For instance, when you're sure that no other MSBuild files will interfere with the build project, or you don't rely on either Roslyn or ReSharper/Rider for formatting. However, note that the **bootstrapping scripts play an essential role** in CI/CD environments, and are also used for the configuration generation feature.
:::

## Project Structure

While you can enjoy writing most build-relevant logic inside your build console applications, there is still a large number of files involved in the general process of build automation. NUKE organizes these files in different folders as linked files in the build project for you:

<Tabs>
  <TabItem value="config" label="Config" default>

```bash
<root-directory>
├── .nuke
│   ├── parameters.json      # Parameters files
│   └── parameters.*.json
│
├── GitVersion.yml           # GitVersion configuration
├── global.json              # SDK version
├── nuget.config             # NuGet feeds configuration
└── version.json             # Nerdbank GitVersioning configuration
```

  </TabItem>
  <TabItem value="ci" label="CI/CD">

```bash
<root-directory>
├── .github
│   └── workflows            # GitHub Actions
│       └── *.yml
│
├── .teamcity                # TeamCity
│   └── settings.kts
│
├── .gitlab-ci.yml           # GitLab CI
├── .space.kts               # JetBrains Space
├── .travis.yml              # Travis CI
├── appveyor.yml             # AppVeyor
├── appveyor.*.yml
├── azure-pipelines.yml      # Azure Pipelines
├── azure-pipelines.*.yml
└── bitrise.yml              # Bitrise
```

  </TabItem>
  <TabItem value="bootstrappers" label="Bootstrappers">

```bash
<root-directory>
├── build.cmd                # Cross-platform
├── build.ps1                # Windows/PowerShell
└── build.sh                 # Linux/Shell
```

  </TabItem>
  <TabItem value="auto-imports" label="MSBuild&nbsp;Auto&#8209;Imports">

```bash
<root-directory>
└── **
    ├── Directory.Build.props
    └── Directory.Build.targets
```

  </TabItem>
</Tabs>

:::info
You can deactivate linking of the above files by removing the `NukeRootDirectory` and `NukeScriptDirectory` properties from the build project file.

```xml title="_build.csproj"
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <!-- <NukeRootDirectory>..</NukeRootDirectory> -->
    <!-- <NukeScriptDirectory>..</NukeScriptDirectory> -->
  </PropertyGroup>

</Project>
```

:::

[^1]: Interface default members behave like explicit interface implementations, which means that to access their members, the `this` reference must be cast explicitly to the interface type. For instance, `((IComponent)this).Target`.
