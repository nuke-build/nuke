---
title: Assertions
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';
import CodeBlock from '@theme/CodeBlock';

As in any other codebase, it is good practice to assert assumptions before continuing with more heavy procedures in your build automation. When an assertion is violated, it usually entails that the build should fail immediately.

In the most simple form, you can fail a build by calling:

```csharp
Assert.Fail("This was unexpected!");
```

Furthermore, you can use one of the following more specific assertion methods:

<Tabs groupId="logging">
  <TabItem value="nullness" label="Nullness" default>

```csharp
// Assert not-null fluently
obj.NotNull().ToString();

// Assert not-null explicitly
Assert.NotNull(obj);
```

  </TabItem>
  <TabItem value="conditions" label="Conditions">

```csharp
// Assert true condition
Assert.True(response.IsSuccessStatusCode);

// Assert false condition
Assert.False(repository.IsOnMainBranch());
```

  </TabItem>
  <TabItem value="collections" label="Collections">

```csharp
// Assert collection is not empty or empty
Assert.NotEmpty(releaseNotes);
Assert.Empty(errors);

// Assert collection count
Assert.Count(packages, length: 5);
Assert.HasSingleItem(matchingEntries);
```

  </TabItem>
  <TabItem value="files-directories" label="Files &amp; Directories">

```csharp
// Assert file exists
Assert.FileExists(file);

// Assert directory exists
Assert.DirectoryExists(directory);
```

  </TabItem>
</Tabs>

:::info
Each of the above methods uses the [`CallerArgumentExpressionAttribute`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/caller-argument-expression) to capture usage details from the call-site. If you want to provide a more comprehensive explanation, you can pass the `message` parameter instead.
:::
