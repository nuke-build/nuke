---
title: Converting from Cake
---

Over the years, the .NET community has come up with a lot of great build automation tools, including [FAKE](https://fake.build/), [Cake](https://cakebuild.net/), [FlubuCore](https://flubucore.dotnetcore.xyz/), and [BullsEye](https://github.com/adamralph/bullseye). When coming from Cake Scripting, the time for converting build scripts can be greatly reduced with a best-effort approach using [Roslyn](https://github.com/dotnet/roslyn) and its [syntax transformation](https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/get-started/syntax-transformation) capabilities.

:::caution
The resulting source code is **expected to contain compilation errors** since there is no direct API mapping between Cake and NUKE. Most notably, the order of `IsDependentOn` on a single target in Cake reflects the order of execution of these dependencies, whereas in NUKE the dependencies are solely defined between the individual targets.
:::

## Conversion

You can start the conversion by calling:

```cmd
nuke :cake-convert
```

The global tool searches for all `*.cake` and converts them to `*.cs` files. During this process it transforms:

- Target definitions
- Default targets
- Parameter declarations
- Path usages
- Globbing patterns
- Tool invocations

Additionally – if you choose to create a build project file – it will collect NuGet packages from `#addin` and `#tool` directives, and add them as `PackageReference` and `PackageDownload` respectively.

## Cleanup

After you've fully verified the conversion, you can clear all `*.cake` files by calling:

```cmd
nuke :cake-clean
```
