---
title: Build Anatomy
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';
import CodeBlock from '@theme/CodeBlock';

A build project is a regular .NET console application. However, unlike regular console applications, NUKE chooses to name the main class `Build` instead of `Program`. This establishes a convention and allows easier navigation in your solution. The `Build` class must inherit from the `NukeBuild` base class and define a `Main` method to invoke the build execution and define any number of default targets:

<Tabs>
  <TabItem value="single" label="Single Default&nbsp;Target">

```csharp title="Build.cs"
class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Compile);

    // Target definitions
}
```

  </TabItem>
  <TabItem value="multiple" label="Multiple Default&nbsp;Targets">

```csharp title="Build.cs"
class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Test, x => x.Pack);

    // Target definitions
}
```

  </TabItem>
  <TabItem value="none" label="No Default&nbsp;Target">

```csharp title="Build.cs"
class Build : NukeBuild
{
    public static int Main() => Execute<Build>();

    // Target definitions
}
```

  </TabItem>
</Tabs>

:::info
You will learn how to [write target definitions](05-targets.md) in the next chapter.
:::

## Base Properties

With the `NukeBuild` base class you gain access to a lot of properties that provide information about the build environment and build status:

<Tabs>
  <TabItem value="build-environment" label="Build Environment">

```csharp title="NukeBuild.cs"
abstract class NukeBuild
{
    static Host Host { get; }
    static bool IsLocalBuild { get; }
    static bool IsServerBuild { get; }

    static AbsolutePath RootDirectory { get; }
    static AbsolutePath TemporaryDirectory { get; }

    static AbsolutePath BuildAssemblyFile { get; }
    static AbsolutePath BuildAssemblyDirectory { get; }
    static AbsolutePath BuildProjectFile { get; }
    static AbsolutePath BuildProjectDirectory { get; }
}
```

:::tip
With the `Host` property you can determine the running environment, for instance with `Host is TeamCity`. Make sure to explore other implementations of the `Host` base class through your IDE.

---

Since `Host`, `IsLocalBuild`, and `IsServerBuild` are static properties, you can conveniently use them in [static conditions](05-targets.md#conditional-execution) to skip targets (including their dependencies) in local or server builds.
:::

:::info
Learn more about the `AbsolutePath` class and how it's used for [path construction](../03-common/03-paths.md).
:::

  </TabItem>
  <TabItem value="build-status" label="Build Status">

```csharp title="NukeBuild.cs"
abstract class NukeBuild
{
    IReadOnlyCollection<ExecutableTarget> InvokedTargets { get; }
    IReadOnlyCollection<ExecutableTarget> SkippedTargets { get; }

    bool IsSuccessful { get; }
    bool IsFailing { get; }
    bool IsFinished { get; }
    int? ExitCode { get; set; }

    IReadOnlyCollection<ExecutableTarget> ExecutionPlan { get; }

    IReadOnlyCollection<ExecutableTarget> ScheduledTargets { get; }
    IReadOnlyCollection<ExecutableTarget> RunningTargets { get; }
    IReadOnlyCollection<ExecutableTarget> AbortedTargets { get; }
    IReadOnlyCollection<ExecutableTarget> FailedTargets { get; }
    IReadOnlyCollection<ExecutableTarget> SucceededTargets { get; }
    IReadOnlyCollection<ExecutableTarget> FinishedTargets { get; }
}
```

:::tip
You can examine the status of targets by using any of the appropriate `ICollection<ExecutableTarget>`. For instance, to check if a target has failed, you can write `FailedTargets.Contains(MyTarget)`. This pattern is especially useful with [dynamic conditions](05-targets.md#conditional-execution).
:::

  </TabItem>
</Tabs>

## Build Events

For implementing cross-cutting concerns, like telemetry and similar, you can hook into various build events:

```csharp title="NukeBuild.cs"
abstract class NukeBuild
{
    virtual void OnBuildCreated();
    virtual void OnBuildInitialized();
    virtual void OnBuildFinished();

    virtual void OnTargetRunning(string target);
    virtual void OnTargetSkipped(string target);
    virtual void OnTargetFailed(string target);
    virtual void OnTargetSucceeded(string target);
}
```
