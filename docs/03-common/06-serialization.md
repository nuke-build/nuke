---
title: Data Serialization
---

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
// Strongly-typed
var configuration = json.GetJson<Configuration>();
var json = configuration.ToJson();

// Dynamically-typed
var jobject = json.GetJson();
```

  </TabItem>
  <TabItem value="xml" label="XML">

```csharp title="Build.cs"
// Strongly-typed
var configuration = xml.GetXml<Configuration>();
var xml = configuration.ToXml();
```

  </TabItem>
  <TabItem value="yaml" label="YAML">

```csharp title="Build.cs"
// Strongly-typed
var configuration = yaml.GetYaml<Configuration>();
var yaml = configuration.ToYaml();
```

  </TabItem>
</Tabs>

## File Serialization

You can serialize data to files and deserialize back from them as follows:

<Tabs groupId="serialization">
  <TabItem value="json" label="JSON" default>

```csharp title="Build.cs"
// Strongly-typed
var configuration = jsonFile.ReadJson<Configuration>();
jsonFile.WriteJson(configuration);

// Dynamically-typed
var jobject = jsonFile.ReadJson();
```

  </TabItem>
  <TabItem value="xml" label="XML">

```csharp title="Build.cs"
// Strongly-typed
var configuration = xmlFile.ReadXml<Configuration>();
xmlFile.WriteXml(configuration);
```

  </TabItem>
  <TabItem value="yaml" label="YAML">

```csharp title="Build.cs"
// Strongly-typed
var configuration = yamlFile.ReadYaml<Configuration>();
yamlFile.WriteYaml(configuration);
```

  </TabItem>
</Tabs>

### Updating Files

Instead of reading, updating, and writing files in separated steps, you can also use the atomic functions below:

<Tabs groupId="serialization">
  <TabItem value="json" label="JSON" default>

```csharp title="Build.cs"
jsonFile.UpdateJson<Configuration>(
    update: x => x.Value = "new-value");
```

  </TabItem>
  <TabItem value="xml" label="XML">

```csharp title="Build.cs"
xmlFile.UpdateXml<Configuration>(
    update: x => x.Value = "new-value");
```

  </TabItem>
  <TabItem value="yaml" label="YAML">

```csharp title="Build.cs"
yamlFile.UpdateYaml<Configuration>(
    update: x => x.Value = "new-value");
```

  </TabItem>
</Tabs>
