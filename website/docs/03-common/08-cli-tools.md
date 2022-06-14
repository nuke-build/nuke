---
title: Invoking CLI Tools
keywords:
  - AzureSignTool
  - BenchmarkDotNet
  - Boots
  - Chocolatey
  - CloudFoundry
  - Codecov
  - CodeMetrics
  - CorFlags
  - CoverallsNet
  - Coverlet
  - DocFX
  - Docker
  - DotCover
  - DotNet
  - EntityFramework
  - Fixie
  - GitLink
  - GitReleaseManager
  - GitVersion
  - Helm
  - ILRepack
  - InnoSetup
  - Kubernetes
  - MauiCheck
  - MinVer
  - MSBuild
  - MSpec
  - NerdbankGitVersioning
  - Netlify
  - Npm
  - NSwag
  - NuGet
  - NUnit
  - Octopus
  - OctoVersion
  - OpenCover
  - Paket
  - PowerShell
  - Pulumi
  - ReportGenerator
  - ReSharper
  - SignClient
  - SignTool
  - SonarScanner
  - SpecFlow
  - Squirrel
  - TestCloud
  - Unity
  - VSTest
  - VSWhere
  - WebConfigTransformRunner
  - Xunit
---


Interacting with third-party command-line interface tools (CLIs) is an essential task in build automation. This includes a wide range of aspects, such as resolution of the tool path, construction of arguments to be passed, evaluation of the exit code and capturing of standard and error output. NUKE hides these concerns in dedicated auto-generated CLI task classes.

<details>
<summary>Exhaustive list of supported tools</summary>

- [AzureSignTool](https://github.com/vcsjones/AzureSignTool)
- [BenchmarkDotNet](https://benchmarkdotnet.org/)
- [Boots](https://github.com/jonathanpeppers/boots)
- [Chocolatey](https://chocolatey.org/)
- [CloudFoundry](https://docs.cloudfoundry.org/cf-cli/cf-help.html)
- [Codecov](https://about.codecov.io/)
- [CodeMetrics](https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-values)
- [CorFlags](https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool)
- [CoverallsNet](https://coverallsnet.readthedocs.io)
- [Coverlet](https://github.com/tonerdo/coverlet/)
- [DocFX](https://dotnet.github.io/docfx/)
- [Docker](https://www.docker.com/)
- [DotCover](https://www.jetbrains.com/dotcover)
- [DotNet](https://docs.microsoft.com/en-us/dotnet/core/tools/)
- [EntityFramework](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet)
- [Fixie](https://fixie.github.io/)
- [GitLink](https://github.com/GitTools/GitLink/)
- [GitReleaseManager](https://gitreleasemanager.readthedocs.io)
- [GitVersion](http://gitversion.readthedocs.io/en/stable/)
- [Helm](https://helm.sh/)
- [ILRepack](https://github.com/gluck/il-repack#readme)
- [InnoSetup](http://www.jrsoftware.org/isinfo.php)
- [Kubernetes](https://kubernetes.io/)
- [MauiCheck](https://github.com/Redth/dotnet-maui-check)
- [MinVer](https://github.com/adamralph/minver)
- [MSBuild](https://msdn.microsoft.com/en-us/library/ms164311.aspx)
- [MSpec](https://github.com/machine/machine.specifications)
- [NerdbankGitVersioning](https://github.com/AArnott/Nerdbank.GitVersioning)
- [Netlify](https://docs.netlify.com/cli/get-started/)
- [Npm](https://www.npmjs.com/)
- [NSwag](https://github.com/RSuter/NSwag)
- [NuGet](https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference)
- [NUnit](https://www.nunit.org/)
- [Octopus](https://octopus.com/)
- [OctoVersion](https://github.com/OctopusDeploy/OctoVersion)
- [OpenCover](https://github.com/OpenCover/opencover)
- [Paket](https://fsprojects.github.io/paket)
- [PowerShell](https://docs.microsoft.com/en-us/powershell/)
- [Pulumi](https://www.pulumi.com/)
- [ReportGenerator](https://github.com/danielpalme/ReportGenerator)
- [ReSharper](https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html)
- [SignClient](https://discoverdot.net/projects/sign-service)
- [SignTool](https://docs.microsoft.com/en-us/dotnet/framework/tools/signtool-exe)
- [SonarScanner](https://www.sonarqube.org/)
- [SpecFlow](https://specflow.org/)
- [Squirrel](https://github.com/Squirrel/Squirrel.Windows)
- [TestCloud](https://developer.xamarin.com/guides/testcloud/)
- [Unity](https://unity3d.com/)
- [VSTest](https://msdn.microsoft.com/en-us/library/jj155796.aspx)
- [VSWhere](https://github.com/Microsoft/vswhere)
- [WebConfigTransformRunner](https://github.com/erichexter/WebConfigTransformRunner)
- [Xunit](https://xunit.github.io)

</details>

Calling MSBuild can be done as follows:

```csharp
// using static Nuke.Common.Tools.MSBuild.MSBuildTasks;

MSBuild($"{SolutionFile} /target:Rebuild /p:Configuration={Configuration} /nr:false");
```

The returned object is a collection of standard and error output.

:::info
Many CLI tasks require to add a package reference to the build project file. For instance, when using `NUnitTasks` there should be one of the following entries to ensure the tool is available:

```xml
<ItemGroup>
    <PackageReference Include="NUnit.ConsoleRunner" Version="3.9.0" />
    <PackageDownload Include="NUnit.ConsoleRunner" Version="[3.9.0]" /> 
</ItemGroup>
```

While it would be possible to magically download required packages, this explicit approach ensures that your builds are reproducible at any time. If a package is not referenced, the resulting error message will include a command to [install the package via the global tool](../06-global-tool/01-packages.md).
:::

## Fluent API

While the example from above is quite easy to understand, it also illustrates certain weaknesses. What if `SolutionFile` contains a space? How can multiple targets be passed? Should the configuration really be injected as property or as dedicated argument? What does the `/nr` switch stand for? To solve this issues you can use the individual fluent interfaces:

```csharp
// using Nuke.Common.Tools.MSBuild;
// using static Nuke.Common.Tools.MSBuild.MSBuildTasks;

MSBuild(_ => _
    .SetTargetPath(SolutionFile)
    .SetTargets("Clean", "Build")
    .SetConfiguration(Configuration)
    .EnableNodeReuse());
```

You can also use the fluent interfaces to manipulate the process invocation, including tool path, arguments, working directory, timeout and environment variables.

:::info
All fluent interfaces implement a variation of the [builder pattern](https://en.wikipedia.org/wiki/Builder_pattern), in which every fluent call will create an immutable copy of the current `ToolSettings` instance with the intended changes applied. This enables great flexibility in composing similar process invocations.
:::

Using any IDE, an individual fluent interface can easily be discovered via code completion. Most importantly, you can look up the original documentation right from where you are:



### Conditional Modifications

In some cases you may want to apply certain options only when a particular condition is met. This can be done fluently too, by using the `When` extension:

```csharp
DotNetTest(_ => _
    .SetProjectFile(ProjectFile)
    .SetConfiguration(Configuration)
    .EnableNoBuild()
    .When(PublishTestResults, _ => _
        .SetLogger("trx")
        .SetResultsDirectory(TestResultsDirectory)));
```

### Combinatorial Modifications

A typical situation when using MSBuild for compilation, is to compile for different configurations, target frameworks or runtimes. You can use the `CombineWith` method to create different combinations for invocation:

```csharp
var publishCombinations =
    from project in new[] { FirstProject, SecondProject }
    from framework in project.GetTargetFrameworks()
    from runtime in new[] { "win10-x86", "osx-x64", "linux-x64" }
    select new { project, framework, runtime };

DotNetPublish(_ => _
    .EnableNoRestore()
    .SetConfiguration(Configuration)
    .CombineWith(publishCombinations, (_, v) => _
        .SetProject(v.project)
        .SetFramework(v.framework)
        .SetRuntime(v.runtime)));
```

### Multiple Invocations

Based on [combinatorial modifications](#combinatorial-modifications) it is possible to set a `degreeOfParallelism` (default `1`) and a flag to `continueOnFailure` (default `false`):

```csharp
DotNetNuGetPush(_ => _
        .SetSource(Source)
        .SetSymbolSource(SymbolSource)
        .SetApiKey(ApiKey)
        .CombineWith(
            OutputDirectory.GlobFiles("*.nupkg").NotEmpty(), (_, v) => _
                .SetTargetPath(v)),
    degreeOfParallelism: 5,
    continueOnFailure: true);
```

This example will always have 5 packages being pushed simultaneously. Possible exceptions, for instance when a package already exists, are accumulated to an `AggregateException` and thrown when all invocations have been processed. The console output is buffered until all invocations are completed.

### Custom Arguments

It may happen that certain arguments are not available from the fluent interface. In this case, the `SetArgumentConfigurator` method can be used to add them manually:

```csharp
MSBuild(_ => _
    .SetTargetPath(SolutionFile)
    .SetArgumentConfigurator(_ => _
        .Add("/r")));
```

<!--
    SetToolPath
    SetWorkingDirectory
    SetExecutionTimeout
    SetEnvironmentVariables
    LogOutput
    When
    SetArgumentConfigurator
-->

### Verbosity Mapping

Using the `VerbosityMappingAttribute`, it is possible to automatically map the verbosity passed via `--verbosity` to individual tools. The attribute must be applied on the build class level:

```csharp
[VerbosityMapping(typeof(MSBuildVerbosity),
    Quiet = nameof(MSBuildVerbosity.Quiet),
    Minimal = nameof(MSBuildVerbosity.Minimal),
    Normal = nameof(MSBuildVerbosity.Normal),
    Verbose = nameof(MSBuildVerbosity.Detailed))]
class Build : NukeBuild
{
    // ...
}
```

## Lightweight API

Many of the most popular tools are already implemented. In case a certain tool is not yet supported with a proper CLI task class, NUKE allows you to use the following **injection attributes** to load them:

<!-- snippet: tool-invocation-lightweight -->
```csharp
[PathExecutable]
readonly Tool Git;

[PackageExecutable(
    packageId: "Redth.Net.Maui.Check",
    packageExecutable: "MauiCheck.dll",
    // Must be set for tools shipping multiple versions
    Framework = "net6.0")]
readonly Tool MauiCheck;

[LocalExecutable("./tools/corflags.exe")]
readonly Tool CorFlags;
```
<!-- endSnippet -->

The injected `Tool` delegate allows passing arguments, working directory, environment variables and many more process-specific options:

<!-- snippet: tool-invocation-lightweight-usage -->
```csharp
// Pass arguments with string interpolation
Git($"checkout -b {Branch}");

// Change working directory and environment variables
CorFlags(
    arguments: "...",
    workingDirectory: SourceDirectory,
    environmentVariables: EnvironmentInfo.Variables
        .ToDictionary(x => x.Key, x => x.Value)
        .SetKeyValue("key", "value").AsReadOnly());

// Only execute when available
// Requires: <PackageDownload Include="Redth.Net.Maui.Check" Version="0.10.0" />
MauiCheck?.Invoke("--fix --preview");
```
<!-- endSnippet -->

