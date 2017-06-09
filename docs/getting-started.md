---
_disableBreadcrumb: true
jr.disableMetadata: true
jr.disableLeftMenu: true
jr.disableRightMenu: true
uid: getting-started
---

# Getting Started

This article will walk you through the most essential things to know when writing builds with Nuke. For missing or incomplete information, you can either improve the documentation following the link on the right-hand side, or just ping us on [Gitter](https://gitter.im/nuke-build/nuke).

## Build Setup

_Support for dotnet CLI is currently in progress._

We prepared setup scripts for [PowerShell](https://nuke.build/powershell) and [Bash](https://nuke.build/bash) to help you with the initial step of creating proper build scripts. During execution you'll be asked to provide the following information:

- Solution file selection (if multiple exist)
- Download URL for _nuget.exe_ (default: latest from nuget.org)
- Directory for your build project (default: _./build_)
- Name for your build project (default: _.build_; this way it's the first item in the SolutionExplorer)
- Project format. The old csproj format that is supported by all MSBuild versions, whereas the SDK-based is only supported by MSBuild 15.0.

Note that the current directory of execution is also the location the build scripts will be generated.

```powershell
# PowerShell
powershell -Command iwr https://nuke.build/powershell -OutFile setup.ps1
powershell -ExecutionPolicy ByPass -File ./setup.ps1
```

```bash
# Bash
curl -Lsfo setup.sh https://nuke.build/bash
chmod +x setup.sh; ./setup.sh
```

When executed, the setup scripts will:

- Generate a _.nuke_ configuration file in the root directory, which references the chosen solution file
- Generate a [_build.ps1_](https://raw.githubusercontent.com/nuke-build/nuke/master/bootstrapping/build.ps1) and [_build.sh_](https://raw.githubusercontent.com/nuke-build/nuke/master/bootstrapping/build.sh) in the current directory
- Copy templates for project file and minimal build file
- Add build project to the solution file (without build configuration)
- Download _nuget.exe_ from the provided URL
- Add the [MyGet source](https://www.myget.org/F/nukebuild/api/v3/index.json) used for Nuke dependencies to _NuGet.config_

For your own awareness, we recommend to review the applied changes using `git diff` or similar tools.

## Build Execution

Without further modifications, executing _build.ps1_ or _build.sh_ will:

1. Download or update the _nuget.exe_
3. Restore dependencies for the build project
2. Download and execute _Nuke.MSBuildLocator_ which locates the MSBuild executable (Windows only)
4. Compile and execute the build project

We also provide a couple of parameters, which can be applied using single or double dash (i.e., `-parameter value` or `--parameter value`):

- `target`: defines the target(s) to be executed; multiple targets are separater by plus sign (i.e., `-target compile+pack`); if no target is defined, the _default_ will be executed
- `configuration`: defines the configuration to build. Default is _debug_
- `verbosity`: supported values are `quiet`, `minimal`, `normal` and `verbose`
- `noinit`: will only compile and execute the build project for improved debugging
- `nodeps`: will only execute the provided targets and not their dependencies

You can also append custom arguments and access them in your build using the `EnvironmentInfo.Argument` alias.

At the end of the build execution, a detailed summary is provided:

```
========================================
Target              Status      Duration
----------------------------------------
Restore             Executed        0:02
Clean               Skipped         0:00
Compile             Executed        0:06
Link                Skipped         0:00
Pack                Executed        0:06
----------------------------------------
Total                               0:16
========================================

Finished build on 06/08/2017 08:50:38.
```

### Troubleshooting

Even before the actual targets are executed, failures are possible:

- _Circular dependencies between target definitions_: you will receive a list of the targets forming a cyclic dependency graph
- _Target with name '{targetName}' does not exist._: you will receive a list of all defined targets

## Build Authoring

Builds are written in classes. You should make advantage of static imports as much as possible. Most of the APIs are designed as fluent syntax that can be used inside lambdas, but this shouldn't prevent you from writing normal method bodies.

Target definitions are written like this:

```c#
Target MyTarget => _ => _
        .DependsOn(MyOtherTarget)
        .Executes(() => /* actions */);
```

Note that targets are actually expression-bodied properties, and therefore seamlessly provide navigation to themselves and dependent targets via _go to declaration_.

### Advanced Example

Let's write a more advanced example:

```c#
Target Publish => _ => _
        .OnlyWhen(() => IsServerBuild)
        .ContinuousOnFailure()
        .DependsOn(Pack)
        .Executes(() => GlobFiles(OutputDirectory, "*.nupkg")
                .ForEach(x => NuGetPush(s => s
                        .SetTargetPath(x)
                        .SetVerbosity(NuGetVerbosity.Detailed)
                        .SetApiKey(EnsureVariable("MYGET_API_KEY"))
                        .SetSource("https://www.myget.org/F/nukebuild/api/v2/package"))));
```

- `OnlyWhen`: the target is only executed when running on a server. The property `IsServerBuild` is provided from the `Build` base class, and checks whether any of the known build servers is currently hosting the process (i.e., TeamCity or Bitrise).
- `ContinuousOnFailure`: even when the executed actions are throwing an exception, the build continuous with further targets
- `DependsOn`: again, this target depends on another target called `Pack`. Multiple dependent targets can be separated by comma since the method accepts `params Target[] targets`.
- `Executes`:
  - Files are collected using the glob mechanism.
  - For each file, `NuGetPush` is executed with several options applied.
  - The API key is retrieved using `EnsureVariable`, which would fail the build, if it's not set.

In this example, we called a few methods from other classes, namely `FileSystemTasks.GlobFiles`, `NuGetTasks.NuGetPush` and `EnvironmentInfo.EnsureVariable`. For better readability, those classes should be imported using static imports:

```c#
using static Nuke.Common.FileSystem.FileSystemTasks;
using static Nuke.Common.Tools.NuGet.NuGetTasks;
using static Nuke.Core.EnvironmentInfo;
```

We will try to provide dedicated tooling for this, so that IntelliSense directly offers all `*Tasks` methods. Meanwhile, it's possible that your IDE provides a context action for transforming into a static import usage.

## Tool Orchestration

Many of the tasks provided are just wrappers around conventional command line tools. They are all shipped inside the `Nuke.Common.Tools` namespace. Note that the required dependencies are not automatically added. For instance, to use the `InspectCodeTasks` you need to add a package reference to `JetBrains.ReSharper.CommandLineTools`. Package references are handled the same way as for any other of your projects.

When executing a task, the logger will print the exact tool path and arguments, so that you can easily reproduce the invocation. Note that the message is logged as _information_. For `InspectCodeTasks` this would be:

```
> C:\Users\user\.nuget\packages\JetBrains.ReSharper.CommandLineTools\2017.1.20170407.131846\tools\inspectcode.exe C:\OSS\Nuke\source\Nuke.sln --output=C:\OSS\Nuke\output\inspectCode.xml
```

Are you missing some tools? Just navigate to our [FeatHub page](http://feathub.com/nuke-build/nuke) and suggest it for our next release. Supporting new tools is very easy, since we can utilize our powerful generator. Meanwhile you can still use the `ProcessTasks` class and its aliases.

## References

For more information check the [documentation section](/api/Nuke.Core.Build.html), ping us on [Gitter](https://gitter.im/nuke-build/nuke), or send a tweet to [@nukebuildnet](https://twitter.com/nukebuildnet).

Concluding, a few projects using Nuke:

- [NukeBuild](https://github.com/nuke-build/nuke/tree/master/build)
- &lt;your project&gt; :smile:

<br/>
<br/>
**Happy building!**