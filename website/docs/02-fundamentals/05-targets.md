---
title: Target Definitions
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';
import CodeBlock from '@theme/CodeBlock';

Inside a `Build` class, you can define your build steps as `Target` properties. The implementation for a build step is provided as a lambda function through the `Executes` method: 

<Tabs>
  <TabItem value="regular" label="Regular Targets">

```csharp title="Build.cs"
class Build : NukeBuild
{
    public static int Main() => Execute<Build>();

    Target MyTarget => _ => _
        .Executes(() =>
        {
            Console.WriteLine("Hello!");
        });
}
```

  </TabItem>

  <TabItem value="async" label="Async Targets">

```csharp title="Build.cs"
class Build : NukeBuild
{
    public static int Main() => Execute<Build>();

    Target MyTarget => _ => _
        .Executes(async () =>
        {
            await Console.Out.WriteLineAsync("Hello!");
        });
}
```

:::caution
Async targets are just a convenience feature that allows you using async APIs in a straightforward way. Behind the scenes, they are still run synchronously.
:::

  </TabItem>
</Tabs>

## Dependencies

Specifying dependencies is essential to let targets run in a meaningful and predictable order. There are 3 different types of dependencies, each of them can be defined from both directions.

<Tabs>
  <TabItem value="execution" label="Execution Dependencies">

<!--Execution dependencies define that one target _must_ run before another target (unless it is skipped):-->

Define that target `A` must run before target `B` unless `A` is skipped:

```csharp title="Build.cs"
class Build : NukeBuild
{
    Target A => _ => _
        // highlight-start
        .DependentFor(B)      // Choose this...
        // highlight-end
        .Executes(() => { });

    Target B => _ => _
        // highlight-start
        .DependsOn(A)         // ...or this!
        // highlight-end
        .Executes(() => { });
}
```

  </TabItem>
  <TabItem value="ordering" label="Ordering Dependencies">

<!--Ordering dependencies define that one target _should_ run before/after another target _if_ they're both scheduled:-->

Define that target `A` runs before target `B` if both are scheduled:

```csharp title="Build.cs"
class Build : NukeBuild
{
    Target A => _ => _
        // highlight-start
        .Before(B)            // Choose this...
        // highlight-end
        .Executes(() => { });

    Target B => _ => _
        // highlight-start
        .After(A)             // ...or this!
        // highlight-end
        .Executes(() => { });
}
```

  </TabItem>
  <TabItem value="triggers" label="Trigger Dependencies">

<!--Trigger dependencies define that one target _causes_ another target to run once it has succeeded:-->

Define that target `A` invokes target `B` once it completes:


```csharp title="Build.cs"
class Build : NukeBuild
{
    Target A => _ => _
        // highlight-start
        .Triggers(B)          // Choose this...
        // highlight-end
        .Executes(() => { });

    Target B => _ => _
        // highlight-start
        .TriggeredBy(A)       // ...or this!
        // highlight-end
        .Executes(() => { });
}
```

  </TabItem>
</Tabs>

:::tip
When choosing a direction, you should ask yourself which target should know about the existence of the other. For instance, should a `Release` target _trigger_ a `Tweet` target? Or should a `Tweet` target _be triggered_ by a `Release` target?

:::

:::caution

Dependencies between targets are solely defined between the individual targets and _not_ through the position they take in a dependency call. The following examples illustrates the difference between the **partial and total order** of targets:

<Tabs>
  <TabItem value="partial" label="Partial Order">

```csharp title="Build.cs"
class Build : NukeBuild
{
    Target A => _ => _
        .Executes(() => { });

    Target B => _ => _
        .Executes(() => { });

    Target C => _ => _
        // highlight-start
        .DependsOn(A, B)
        // highlight-end
        .Executes(() => { });
}
```

The execution is nondeterministic between `A->B->C` and `B->A->C`. This isn't necessarily problematic, but something to be aware of. In particular, it allows different targets to run in parallel (currently only in compatible CI/CD environments).

  </TabItem>
  <TabItem value="total" label="Total Order">

```csharp title="Build.cs"
class Build : NukeBuild
{
    Target A => _ => _
        .Executes(() => { });

    Target B => _ => _
        // highlight-start
        .DependsOn(A)
        // highlight-end
        .Executes(() => { });

    Target C => _ => _
        // highlight-start
        .DependsOn(B)
        // highlight-end
        .Executes(() => { });
}
```

The execution is always deterministic with `A->B->C`.

  </TabItem>
</Tabs>

:::

## Conditional Execution

Apart from [skipping targets manually](../01-getting-started/03-execution.md#skipping-targets), you can also programmatically decide whether a target should be skipped. Depending on the use-case, you can choose between dynamic and static conditions.

<Tabs>
  <TabItem value="dynamic-conditions" label="Dynamic Conditions">

Define a condition that is checked right before target `B` executes:

```csharp
class Build : NukeBuild
{
    readonly List<string> Data = new();

    Target A => _ => _
        .Executes(() => { /* Populate Data */ });

    Target B => _ => _
        .DependsOn(A)
        // highlight-start
        .OnlyWhenDynamic(() => Data.Any())
        // highlight-end
        .Execute(() => { });
}
```

  </TabItem>
  <TabItem value="static-conditions" label="Static Conditions">

Define a condition that is checked before target `A` and `B` execute:

```csharp
class Build : NukeBuild
{
    Target A => _ => _
        .Executes(() => { });

    Target B => _ => _
        // highlight-start
        .OnlyWhenStatic(() => IsLocalBuild)
        // By default, dependencies are skipped
        .WhenSkipped(DependencyBehavior.Execute)
        // highlight-end
        .DependsOn(A)
        .Execute(() => { });
}
```

  </TabItem>
</Tabs>

:::tip
When a condition is not met, the exception message is created from the boolean expression. For more complex conditions, you can extract the logic into a separate method or property to make the message more readable.
:::

## Requirements

You can define target requirements that are checked right at the beginning of the build execution before any other targets are executed:

```csharp
class Build : NukeBuild
{
    Target A => _ => _
        // highlight-start
        .Requires(() => IsServerBuild)
        // highlight-end
        .Executes(() => { });
}
```

:::note
Target requirements are an important aspect to achieve a [fail-fast behavior](https://en.wikipedia.org/wiki/Fail-fast). Preceding targets won't waste any execution time only to discover that a condition that was known right from the beginning was not met.
:::

:::tip
When a requirement is not met, the exception message is created from the boolean expression. For more complex requirements, you can extract the logic into a separate method or property to make the message more readable.
:::

## Failure Handling

Not every failing target should immediately stop the build. Targets that are not essential could allow to continue the execution, while other targets are important to run even if another target has failed. For these use-cases, you can configure the failure handling. 

<Tabs>
  <TabItem value="proceed" label="Proceeded Execution">

Define that execution continues after target `A` throws:

```csharp
class Build : NukeBuild
{
    Target A => _ => _
        // highlight-start
        .ProceedAfterFailure()
        // highlight-end
        .Executes(() =>
        {
            Assert.Fail("error");
        });

    Target B => _ => _
        .DependsOn(A)
        .Execute(() => { });
}
```

  </TabItem>
  <TabItem value="assured" label="Assured Execution">

Define that target `B` executes even if another target fails:

```csharp
class Build : NukeBuild
{
    Target A => _ => _
        .Executes(() =>
        {
            Assert.Fail("error");
        });

    Target B => _ => _
        // highlight-start
        .AssuredAfterFailure()
        // highlight-end
        .DependsOn(A)
        .Execute(() => { });
}
```

  </TabItem>
</Tabs>

## Unlisting Targets

It is good practice to follow the [single-responsibility principle](https://en.wikipedia.org/wiki/Single-responsibility_principle) when implementing targets. However, you may not want to expose every target through the [build help text](../01-getting-started/03-execution.md#help-text). For cases like this, you can un-list a target:

```csharp
class Build : NukeBuild
{
    Target A => _ => _
        // highlight-start
        .Unlisted()
        // highlight-end
        .Executes(() => { });
}
```
