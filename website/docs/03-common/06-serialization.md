---
title: Data Serialization
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';

Structured data plays an essential role in build automation. You may want to read a list of repositories to be checked out, write data that's consumed by another tool, or update version numbers of SDKs and tools you consume. The central entry point for data serialization is the `SerializationTasks` class, which comes with support for JSON, XML, and YAML.

<Tabs groupId="serialization">
  <TabItem value="json" label="JSON" default>

:::note
Please read the [Newtonsoft.Json documentation](https://www.newtonsoft.com/json/help/html/Introduction.htm) before proceeding.
:::

  </TabItem>
  <TabItem value="xml" label="XML">

:::note
Please read the [XDocument documentation](https://docs.microsoft.com/en-us/dotnet/standard/linq/xdocument-class-overview) before proceeding.
:::

  </TabItem>
  <TabItem value="yaml" label="YAML">

:::note
Please read the [YamlDotNet documentation](https://github.com/aaubry/YamlDotNet/wiki) before proceeding.
:::

  </TabItem>
</Tabs>

## String Serialization

You can serialize data to strings and deserialize back from them as follows:

<Tabs groupId="serialization">
  <TabItem value="json" label="JSON" default>

```csharp title="Build.cs"
// using static Nuke.Common.IO.SerializationTasks;

// Strongly-typed
var configuration = JsonDeserialize<MyConfiguration>(json);
var json = JsonSerialize(configuration);

// Dynamically-typed
var jobject = JsonDeserialize(json);
```

  </TabItem>
  <TabItem value="xml" label="XML">

```csharp title="Build.cs"
// using static Nuke.Common.IO.SerializationTasks;

// Strongly-typed
var configuration = XmlDeserialize<MyConfiguration>(xml);
var xml = XmlSerialize(configuration);
```

  </TabItem>
  <TabItem value="yaml" label="YAML">

```csharp title="Build.cs"
// using static Nuke.Common.IO.SerializationTasks;

// Strongly-typed
var configuration = YamlDeserialize<MyConfiguration>(yaml);
var yaml = YamlSerialize(configuration);
```

  </TabItem>
</Tabs>

## File Serialization

You can serialize data to files and deserialize back from them as follows:

<Tabs groupId="serialization">
  <TabItem value="json" label="JSON" default>

```csharp title="Build.cs"
// using static Nuke.Common.IO.SerializationTasks;

// Strongly-typed
var configuration = JsonDeserializeFromFile<MyConfiguration>(jsonFile);
JsonSerializeToFile(configuration, jsonFile);

// Dynamically-typed
var jobject = JsonDeserializeFromFile(jsonFile);
```

  </TabItem>
  <TabItem value="xml" label="XML">

```csharp title="Build.cs"
// using static Nuke.Common.IO.SerializationTasks;

// Strongly-typed
var configuration = XmlDeserializeFromFile<MyConfiguration>(xmlFile);
XmlSerializeToFile(configuration, xmlFile);
```

  </TabItem>
  <TabItem value="yaml" label="YAML">

```csharp title="Build.cs"
// using static Nuke.Common.IO.SerializationTasks;

// Strongly-typed
var configuration = YamlDeserializeFromFile<MyConfiguration>(yamlFile);
YamlSerializeToFile(configuration, yamlFile);
```

  </TabItem>
</Tabs>

### Updating Files

Instead of reading, updating, and writing files in separated steps, you can also use the atomic functions below:

<Tabs groupId="serialization">
  <TabItem value="json" label="JSON" default>

```csharp title="Build.cs"
// using static Nuke.Common.IO.SerializationTasks;

JsonUpdateFile<MyConfiguration>(
    path: ConfigurationFile,
    update: x => x.Value = "new-value");
```

  </TabItem>
  <TabItem value="xml" label="XML">

```csharp title="Build.cs"
// using static Nuke.Common.IO.SerializationTasks;

XmlUpdateFile<MyConfiguration>(
    path: ConfigurationFile,
    update: x => x.Value = "new-value");
```

  </TabItem>
  <TabItem value="yaml" label="YAML">

```csharp title="Build.cs"
// using static Nuke.Common.IO.SerializationTasks;

YamlUpdateFile<MyConfiguration>(
    path: ConfigurationFile,
    update: x => x.Value = "new-value");
```

  </TabItem>
</Tabs>

