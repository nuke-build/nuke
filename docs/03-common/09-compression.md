---
title: Archive Compression
---

In many situations you have to deal with compressed archives. Good examples are when you want to provide additional assets for your GitHub releases, or when you depend on other project's release assets yourself, and need to extract them before they can be used.

:::note
Please refer to the [SharpZipLib documentation](https://github.com/icsharpcode/SharpZipLib) for any questions.
:::

## Compressing Archives

You can create a compressed archive from a directory follows:

<Tabs groupId="compression">
  <TabItem value="zip" label="ZIP" default>

```csharp title="Build.cs"
PublishDirectory.ZipTo(
    ArchiveFile,
    filter: x => !x.HasExtension(ExcludedExtensions),
    compressionLevel: CompressionLevel.SmallestSize,
    fileMode: FileMode.CreateNew);
```

  </TabItem>
  <TabItem value="gzip" label="GZIP">

```csharp title="Build.cs"
PublishDirectory.TarGZipTo(
    ArchiveFile,
    filter: x => !x.HasExtension(ExcludedExtensions),
    fileMode: FileMode.CreateNew);
```

  </TabItem>
  <TabItem value="bzip" label="BZIP2">

```csharp title="Build.cs"
PublishDirectory.TarBZip2To(
    ArchiveFile,
    filter: x => !x.HasExtension(ExcludedExtensions),
    fileMode: FileMode.CreateNew);
```

  </TabItem>
</Tabs>

:::tip
If you want to allow your consumers to verify the integrity of your archive files, you can calculate their MD5 checksums and publish them publicly:

```
var checksum = ArchiveFile.GetFileHash();
```

:::

## Extracting Archives

You can extract an existing archive file to a directory:

<Tabs groupId="compression">
  <TabItem value="zip" label="ZIP" default>

```csharp title="Build.cs"
ArchiveFile.UnZipTo(PublishDirectory);
```

  </TabItem>
  <TabItem value="gzip" label="GZIP">

```csharp title="Build.cs"
ArchiveFile.UnTarGZip(PublishDirectory);
```

  </TabItem>
  <TabItem value="bzip" label="BZIP2">

```csharp title="Build.cs"
ArchiveFile.UnTarBZip2(PublishDirectory);
```

  </TabItem>
</Tabs>
