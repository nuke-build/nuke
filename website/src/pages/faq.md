---
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';
import CodeBlock from '@theme/CodeBlock';

# Frequently Asked Questions

On this page you can find a collection of questions that we frequently see across all our channels.

## General

<details>
<summary class="faq">Why is it called NUKE?</summary>

The name "NUKE" originates from a combination of the words _New_ and _Make_.

GNU Make can be considered the godfather of build automation tools that is based on the commonly known _makefile_.

_NU_ is a play on the word _New_, similar as in _Nu-Metal_. It also breaks the common naming pattern to be [AKEless](https://www.youtube.com/watch?v=_sZT0CpJ6Vo&t=216s) - as in "working without ache/pain" - since it doesn't come with the scripting heritage most developers expect from MAKE tools. Instead, it fully integrates with IDEs and other existing tooling, and makes build automation a breeze.

</details>


<details>
<summary class="faq">Can I use NUKE in other places than .NET?</summary>

Absolutely. We've heard plenty of stories where developers choose NUKE to kick off and extend their JavaScript/TypeScript or Gradle builds. Although pulling in the .NET SDK can be seen as an unnecessary dependency for the project, the gained comfort quickly outweighs this penalty.

</details>


<details>
<summary class="faq">How does NUKE compare to MSBuild?</summary>

While MSBuild is a powerful build system and definitely worth exploring for _some_ use-cases, it falls rather short when it comes to general build automation. The XML format makes it very verbose even for medium complex logic. Writing custom tasks in C# is a possible but not practical due to the maintenance costs and cumbersome debugging.

NUKE doesn't replace MSBuild though. Using the `DotNetTasks` and `MSBuildTasks`, it is still used to compile solutions and projects.

Our rule of thumb: when something is closely related to the compilation process and involved files, you should use MSBuild. When it's not, like packaging the output files, you could use NUKE.

</details>

<details>
<summary class="faq">How does NUKE compare to YAML?</summary>

Using YAML can be absolutely fine in many scenarios, particularly when you're sure that your build remains simple long-term. Once it gets more complex though, you will quickly realize that common control flow elements like if-statements or foreach-loops have no home in YAML files. In addition, you will fight some other [YAML issues](https://noyaml.com/), like repetitive formatting errors, inability for local troubleshooting, and missing refactoring tools.

NUKE doesn't replace YAML files though. Your respective CI/CD service still needs a YAML file (or similar configuration files), to invoke your NUKE build. 

</details>

<details>
<summary class="faq">How does NUKE compare to other build tools?</summary>

We encourage everyone to try and evaluate any of the other build automation options that exist in the .NET ecosystem. Some of the unique NUKE features from our point of view are:

- Targets (build steps) are declared as properties
- Common build automation helper functions included
- Consistent fluent API for all the major CLI tools
- Declarative build parameters (input values)
- Build sharing and build composition
- Generation of CI/CD configuration files (YAML, etc.)
- Native integration into IDEs with additional extensions

You can also read comparative articles by [Dennis Doomen](https://www.continuousimprover.com/2020/03/reasons-for-adopting-nuke.html) or [Laurent Kempé](https://laurentkempe.com/2022/02/02/automate-your-dotnet-project-builds-with-nuke-a-cross-platform-build-automation-solution/).

</details>


## Build Structure

<details>
<summary class="faq">Do I really need the <code>build.cmd</code>, <code>build.ps1</code>, and <code>build.sh</code> files?</summary>

Not necessarily. It's perfectly fine to remove them and call `dotnet run` on the build project. However, there are two situations when these files are really required:

1. They ensure the availability of the .NET SDK according to the `global.json` file. If there is no local installation, it will be downloaded to the temporary directory. This greatly simplifies execution on CI/CD environments and for anyone trying to contribute to your project.
2. They allow the Visual Studio and Visual Studio Code extensions to execute the build.

</details>



<details>
<summary class="faq">Do I really need the <code>.nuke</code> directory and contained files?</summary>

The `.nuke` directory allows to infer the root directory (i.e., `NukeBuild.RootDirectory`). Alternatively, you can invoke the build with the `--root` flag to indicate that the working directory should be used, or `--root <path>` to pass another directory.

The `build.schema.json` file is generated on each build execution. If you have configured [shell completion](/docs/global-tool/shell-completion), this file is used to provide completion results. If the file is not present, the first completion attempt (i.e., when hitting <kbd>TAB</kbd>) needs to compile your build project. Therefore, you only need to commit this file if you prefer immediate completion behavior.

<!--TODO-->
<!--The `parameters.json` file TODO-->
</details>

## Build Execution

<details>
<summary class="faq">Does every project contributor need to install the global tool?</summary>

No. The global tool is only required to [set up a build](/docs/getting-started/setup). Contributors can use the following commands to execute the build:

<Tabs>
  <TabItem value="dotnet" label=".NET CLI">
    <CodeBlock language="bash">dotnet run -- [args]</CodeBlock>
  </TabItem>
  <TabItem value="windows" label="Windows">
    <CodeBlock language="cmd">.\build.cmd [args]</CodeBlock>
  </TabItem>
  <TabItem value="linux" label="Linux">
    <CodeBlock language="bash">./build.sh [args]</CodeBlock>
  </TabItem>
</Tabs>

</details>

<details>
<summary class="faq">Why does my tool invocation log errors although it's successful?</summary>

Some tools are notoriously logging to the error stream. Most commonly, this includes Git and Docker. You can overwrite the tool-specific logger in your `Build` constructor and delegate to any of the [logging methods](/docs/fundamentals/logging):

<Tabs>
  <TabItem value="git" label="Git">

```
GitTasks.GitLogger = (type, text) => Log.Debug(text);
```

  </TabItem>
  <TabItem value="docker" label="Docker">

```
DockerTasks.DockerLogger = (type, text) => Log.Debug(text);
```

  </TabItem>
</Tabs>

As of now, we don't plan to introduce this as default, because you might miss imortant error messages.

</details>

<details>
<summary class="faq">Why does my build output show hieroglyphs?</summary>

You're most likely running the build in a terminal that isn't set to UTF-8 output. We can't give any more help here, but recommend to check on a suitable [StackExchange](https://stackexchange.com/sites) platform or ask our community on [Slack](https://communityinviter.com/apps/nukebuildnet/nuke).

</details>

## Public API

<details>
<summary class="faq">Why was the public API broken in a minor release?</summary>

Major versions are released alongside major .NET SDK releases. This is to reflect that our releases are compatible with a specific .NET SDK version. As a consequence, breaking changes may and will happen during minor releases for various reasons. Most often, it is to improve an API, fix legacy mistakes, or update a tool task to a new version.

If you can no longer find an API, proceed as follows:

- Check the [changelog](https://github.com/nuke-build/nuke/blob/develop/CHANGELOG.md)
- Try to fuzzy search in your IDE
- Reach out on [Slack](https://communityinviter.com/apps/nukebuildnet/nuke) or [Twitter](https://twitter.com/nukebuildnet)

Please remember that this is an open-source project.

</details>


<details>
<summary class="faq">Can you provide migration guides?</summary>

Most likely not, unless it is fundamental and would affect all users. It is in the interest of the project to dedicate our available time to implementing cool new features.

Please remember that this is an open-source project.

</details>

## Others

<details>
<summary class="faq">How can I restore packages from a private NuGet feed?</summary>

If you need to restore a private NuGet package as part of the build project compilation, you have to provide the feed password in your build environment and adapt the bootstrapping scripts as follows:

<Tabs>
  <TabItem value="powershell" label="PowerShell">

```powershell title="build.ps1"
###########################################################################
# CONFIGURATION
###########################################################################

...

// highlight-start
$env:FEED_SOURCE = "https://nuget.pkg.github.com/nuke-build/index.json"
$env:FEED_USERNAME = "nuke-bot"
// highlight-end

###########################################################################
# EXECUTION
###########################################################################

...

// highlight-start
if (Test-Path env:FEED_PASSWORD) {
    ExecSafe { & $env:DOTNET_EXE nuget add source $env:FEED_SOURCE --username $env:FEED_USERNAME --password $env:FEED_PASSWORD }
}
// highlight-end

Write-Output "Microsoft (R) .NET Core SDK version $(& $env:DOTNET_EXE --version)"

ExecSafe { & $env:DOTNET_EXE build $BuildProjectFile /nodeReuse:false /p:UseSharedCompilation=false -nologo -clp:NoSummary --verbosity quiet }
ExecSafe { & $env:DOTNET_EXE run --project $BuildProjectFile --no-build -- $BuildArguments }
```

  </TabItem>
  <TabItem value="bash" label="Bash">

```bash title="build.sh"
###########################################################################
# CONFIGURATION
###########################################################################

...

# highlight-start
export FEED_SOURCE="https://nuget.pkg.github.com/nuke-build/index.json"
export FEED_USERNAME="nuke-bot"
# highlight-end

###########################################################################
# EXECUTION
###########################################################################

...

# highlight-start
if [[ ! -z ${FEED_PASSWORD+x} && "$FEED_PASSWORD" != "" ]]; then
    "$DOTNET_EXE" nuget add source "$FEED_SOURCE" --username "$FEED_USERNAME" --password "$FEED_PASSWORD" --store-password-in-clear-text
fi
# highlight-end

echo "Microsoft (R) .NET SDK version $("$DOTNET_EXE" --version)"

"$DOTNET_EXE" build "$BUILD_PROJECT_FILE" /nodeReuse:false /p:UseSharedCompilation=false -nologo -clp:NoSummary --verbosity quiet
"$DOTNET_EXE" run --project "$BUILD_PROJECT_FILE" --no-build -- "$@"
```

  </TabItem>
</Tabs>

:::note
If your packages are not required for the build project, it is preferred to add the source from within the build project.
:::

</details>


