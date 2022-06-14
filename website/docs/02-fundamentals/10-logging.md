---
title: Logging
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';
import CodeBlock from '@theme/CodeBlock';

As with any other application, good logging greatly reduces the time to detect the source of errors and fix them quickly. NUKE integrates with [Serilog](https://serilog.net/) and prepares a console and file logger for you. Most functions with side effects will automatically log their performed actions. This also includes [invocations of CLI tools](../03-common/08-cli-tools.md). Of course, you can also add your own log messages:

```csharp
// using Serilog;

Log.Verbose("This is a verbose message");
Log.Debug("This is a debug message");
Log.Information("This is an information message");
Log.Warning("This is a warning message");
Log.Error("This is an error message");
```

:::tip
For error messages, you most certainly want to use [assertions](14-assertions.md) instead to also fail the build.
:::

## Console Sink

Based on your IDE and CI/CD service, the console sink is automatically configured with the [best-looking themes](https://github.com/serilog/serilog-sinks-console#themes). When your terminal supports [ANSI colors](https://en.wikipedia.org/wiki/ANSI_escape_code) (`TERM=xterm`), an ANSI theme is chosen. Otherwise, a simple [system-color](https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor) theme is used.

:::info
Adaptive themes are particularly great for consistent colors in your CI/CD environment.
:::

Log messages are only written to console when the appropriate `LogLevel` is set. You can change it by passing the `--verbosity` parameter:

<Tabs groupId="logging">
  <TabItem value="trace" label="Verbose" default>
    <CodeBlock language="bash">nuke --verbosity verbose</CodeBlock>
  </TabItem>
  <TabItem value="normal" label="Normal" default>
    <CodeBlock language="bash">nuke --verbosity normal</CodeBlock>
  </TabItem>
  <TabItem value="warning" label="Minimal" default>
    <CodeBlock language="bash">nuke --verbosity minimal</CodeBlock>
  </TabItem>
  <TabItem value="error" label="Quiet" default>
    <CodeBlock language="bash">nuke --verbosity quiet</CodeBlock>
  </TabItem>
</Tabs>

Or by setting it directly in the build implementation:

<Tabs groupId="logging">
  <TabItem value="trace" label="Trace" default>

<!-- snippet: logging -->
```csharp
Logging.Level = LogLevel.Trace;
```
<!-- endSnippet -->

  </TabItem>
  <TabItem value="normal" label="Normal">

```csharp
Logging.Level = LogLevel.Normal;
```

  </TabItem>
  <TabItem value="warning" label="Warning">

```csharp
Logging.Level = LogLevel.Warning;
```

  </TabItem>
  <TabItem value="error" label="Error">

```csharp
Logging.Level = LogLevel.Error;
```

  </TabItem>
</Tabs>

In the following image you can see that the verbose message is hidden because the current log level was set to `Normal`:

<p style={{maxWidth:'380px'}}>

![Logging Output in Console](/img/docs/logging-console-light.png#gh-light-mode-only)
![Logging Output in Console](/img/docs/logging-console-dark.png#gh-dark-mode-only)

</p>

:::tip
Error and warning log messages are repeated right before the [build summary](../01-getting-started/03-execution.md#build-summary) to give you a quick-look at what went wrong.
:::

## File Sinks

For each build, a new log file is written to the temporary directory. The Serilog message template is pre-configured as:

```text title="Message Template"
{Timestamp:HH:mm:ss.fff} | {Level:u1} | {Target} | {Message:l}{{NewLine}{{Exception}
```

With the sample logging from above, the file would like roughly like this:

```log title=".nuke/temp/build.log"
03:57:38.208 | V | Compile | This is a verbose message
03:57:38.208 | D | Compile | This is a debug message
03:57:38.208 | I | Compile | This is an information message
03:57:38.208 | W | Compile | This is a warning message
03:57:38.208 | E | Compile | This is an error message
```

:::tip
With the [Ideolog plugin](https://plugins.jetbrains.com/plugin/9746-ideolog) for [JetBrains Rider](https://jetbrains.com/rider/) you can view and inspect log files more comfortably. It automatically highlights messages according to their log level, allows collapsing irrelevant messages based on search terms, and will enable navigation for exception stack traces.

<p style={{maxWidth:'680px',marginBottom:'-24px'}}>

![Ideolog plugin in JetBrains Rider](/img/docs/logging-ideolog-light.png#gh-light-mode-only)
![Ideolog plugin in JetBrains Rider](/img/docs/logging-ideolog-dark.png#gh-dark-mode-only)

</p>
:::

### Comparing Log Files

For the purpose of log comparison, local builds will create another log file with the current timestamp in its name but without the timestamp in the message template:

```text title="Message Template"
{Level:u1} | {Target} | {Message:l}{NewLine}{Exception}
```

:::info
Only the last 5 build logs are kept.
:::

With the same sample logging from above, the file now looks like this:

<CodeBlock title={".nuke/temp/build." + new Date().toISOString().substring(0,19).replace("T", "_").replaceAll(":", "-") + ".log"}>
{`
V | Compile | This is a verbose message
D | Compile | This is a debug message
I | Compile | This is an information message
W | Compile | This is a warning message
E | Compile | This is an error message
`.trim()}
</CodeBlock>

With the comparison tool of your choice, you can then select two files and compare them. For instance, when you remove the debug message and add another warning message, the comparison tool will show the following:

```diff title="Diff Output"
  V | Compile | This is a verbose message
- D | Compile | This is a debug message
  I | Compile | This is an information message
  W | Compile | This is a warning message
+ W | Compile | This is another warning message
  E | Compile | This is an error message
```
