---
title: Build Execution
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';
import CodeBlock from '@theme/CodeBlock';
import AsciinemaPlayer from '../../src/components/AsciinemaPlayer';
import 'asciinema-player/dist/bundle/asciinema-player.css';

After you've [set up a build](02-setup.md) you can run it either through the global tool or one of the installed bootstrapping scripts:

<Tabs>
  <TabItem value="global-tool" label="Global Tool" default>
    <CodeBlock>nuke [arguments]</CodeBlock>
  </TabItem>
  <TabItem value="windows" label="Windows" default>
    <CodeBlock>.\build.cmd [arguments]</CodeBlock>
  </TabItem>
  <TabItem value="linux" label="Linux" default>
    <CodeBlock>./build.sh [arguments]</CodeBlock>
  </TabItem>
</Tabs>

:::info
This document discusses the default build arguments (also referred to as parameters). You will learn how to [define custom parameters](../02-fundamentals/06-parameters.md) in a following chapter.
:::

:::tip
The global tool makes running builds a lot easier. Once you've configured the [shell completion](../06-global-tool/00-shell-completion.md), you can enter arguments much faster and avoid any typos. It also allows you to run a build from anywhere below the root directory without having to go back to where the bootstrapping scripts are located.
:::

## Build Summary

Once a build has finished running an execution plan, it will print a comprehensive summary with all involved targets, their outcome, duration, and additional metadata:

<CodeBlock>
═══════════════════════════════════════{'\n'}
Target             Status      Duration{'\n'}
───────────────────────────────────────{'\n'}
Restore            Succeeded       0:16{'\n'}
Compile            Succeeded       0:59   // Version: 5.3.0-alpha.35{'\n'}
Test               Succeeded       0:41   // Passed: 327, Skipped: 6{'\n'}
Pack               Succeeded       0:10   // Packages: 4{'\n'}
───────────────────────────────────────{'\n'}
Total                              2:08{'\n'}
═══════════════════════════════════════{'\n'}
{'\n'}
Build succeeded on {new Date().toLocaleString()}. ＼（＾ᴗ＾）／
</CodeBlock>

[//]: # (## Default Parameters)
[//]: # ()
[//]: # (| Parameter     | Comment                                                   |)
[//]: # (|:--------------|:----------------------------------------------------------|)
[//]: # (| `--target`    | List of targets to be invoked                             |)
[//]: # (| `--skip`      | List of targets to be skipped &#40;empty for all non-invoked&#41; |)
[//]: # (| `--help`      | Shows the help text                                       |)
[//]: # (| `--host`      | Forcefully sets the `Host` implementation                 |)
[//]: # (| `--profile`   | List of `parameters.<name>.json` files to load            |)
[//]: # (| `--plan`      | Shows the HTML dependency graph                           |)
[//]: # (| `--verbosity` | Sets the verbosity used for logging                       |)
[//]: # (| `--continue`  | Continues the build from last point of failure            |)
[//]: # (| `--root`      | Forcefully sets the root directory                        |)

## Invoking Targets

You can invoke a single target or a set of targets either through positional or named arguments:

<Tabs>
  <TabItem value="positional-argument" label="Positional Argument" default>
    <CodeBlock>nuke &lt;target&gt; [other-targets...]</CodeBlock>
  </TabItem>
  <TabItem value="named-argument" label="Named Argument">
    <CodeBlock>nuke [arguments...] --targets &lt;target&gt; [other-targets...]</CodeBlock>
  </TabItem>
</Tabs>

:::tip
Passing targets as named arguments allows you to quickly overwrite the invoked targets without moving the caret to the front of a long invocation command.
:::

## Skipping Targets

You can skip all or individual targets from the execution plan that are not specifically invoked:

<Tabs>
    <TabItem value="skip-all" label="Skipping All Targets" default>
        <CodeBlock>nuke [targets] --skip</CodeBlock>
    </TabItem>
    <TabItem value="skip-individual" label="Skipping Individual Targets">
        <CodeBlock>nuke [targets] --skip &lt;other-targets...&gt;</CodeBlock>
    </TabItem>
</Tabs>

:::tip
Skipping targets can greatly improve your troubleshooting experience. Irrelevant targets won't waste execution time and there is no need to temporarily change dependencies between targets.
:::

## Aborting Builds

At any moment during execution, you can hit `Ctrl-C` to abort the build with a [SIGINT signal](https://docs.microsoft.com/en-us/windows/console/ctrl-c-and-ctrl-break-signals). Targets that were running at the time will be marked with the `Aborted` status:

```
═══════════════════════════════════════
Target             Status      Duration
───────────────────────────────────────
Restore            Succeeded       0:16
Compile            Aborted         0:01
Pack               NotRun
───────────────────────────────────────
Total                              0:17
═══════════════════════════════════════
```

## Continuing Builds

You can continue a failed or aborted build from the first point of failure:

```
nuke [arguments...] --continue
```

All previously succeeded targets will be skipped automatically, which can save a lot of unnecessary execution time:

```
═══════════════════════════════════════
Target             Status      Duration
───────────────────────────────────────
Restore            Skipped
Compile            Succeeded       0:15
Pack               Succeeded       0:05
───────────────────────────────────────
Total                              0:20
═══════════════════════════════════════
```

:::tip
When you combine the `--continue` argument with the [`dotnet watch`](https://docs.microsoft.com/dotnet/core/tools/dotnet-watch) command, you can establish a very tight feedback loop while working on your target implementation. Just go to the build project directory and call:

```
dotnet watch run -- [arguments..] --continue
```
:::

:::caution
The state of the build instance is NOT serialized. I.e., if a succeeded target produced data for a failed target, that data won't be available during the continuation of the build.

Moreover, a build can only reliably continue when the invocation is the same as in the previous attempt. That means that you can only add the `--continue` switch but not change any other arguments. If this rule is violated, the build will start from the very beginning.
:::

## Help Text

When you're coming back to a repository or build you haven't worked on in a while, you can bring up the integrated help text by calling:

```
nuke --help
```

This allows you to inspect all available targets with their direct dependencies as well as parameters with their descriptions:

```text
Targets (with their direct dependencies):

  Clean
  Restore
  Compile (default)    -> Restore

Parameters:

  --configuration         Configuration to build - Default is 'Debug' (local) or
                          'Release' (server).

  --continue              Indicates to continue a previously failed build attempt.
  --help                  Shows the help text for this build assembly.
  --host                  Host for execution. Default is 'automatic'.
  --no-logo               Disables displaying the NUKE logo.
  --plan                  Shows the execution plan (HTML).
  --profile               Defines the profiles to load.
  --root                  Root directory during build execution.
  --skip                  List of targets to be skipped. Empty list skips all
                          dependencies.
  --target                List of targets to be invoked. Default is 'Compile'.
  --verbosity             Logging verbosity during build execution. Default is
                          'Normal'.
```

## Execution Plans

In order to get a better understanding of how your builds are structured, you can load a visual representation of the different execution plans by calling:

```
nuke --plan
```

Hovering a target will show its individual execution plan, that means, all targets that are going to be executed when one specific target is invoked. The style of an edge (solid/dashed/yellow) between two targets indicates their [dependency relation](../02-fundamentals/05-targets.md#dependencies) (execution/ordering/trigger):   

<img src="/img/docs/plan.gif" alt="Setting up a new build" />

:::info

When no targets are hovered, the execution plan for the [default targets](../02-fundamentals/04-builds.md) is highlighted.

:::
