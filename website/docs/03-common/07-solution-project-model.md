---
title: Solution & Project Model
---

import TOCInline from '@theme/TOCInline';

Particularly when building .NET applications, your build may require information related to solution or project files. Such information is often duplicated with string literals and quickly becomes out-of-date. For instance, when publishing a project you want to build for every target framework that is defined in the project file. NUKE has best-in-class support to read and modify the .NET solution and project model.

## Working with Solutions

The easiest way to load your solution is to create a new `Solution` field, add the `SolutionAttribute`, and define the file path into the default [parameters file](../02-fundamentals/06-parameters.md#passing-values-through-parameter-files):

```csharp
[Solution]
readonly Solution Solution;

Target Print => _ => _
    .Executes(() =>
    {
        Log.Information("Solution path = {Value}", Solution);
        Log.Information("Solution directory = {Value}", Solution.Directory);
    });
```

You can also manually load solutions with the `ProjectModelTasks`:

```csharp
var solution = ProjectModelTasks.ParseSolution("/path/to/file");
```

### Read & Write

With an instance of the `Solution` type you can **read and write the solution** in regards to projects, solution folders, items, and build configurations:

```csharp
// Gather projects
var globalToolProject = Solution.GetProject("Nuke.GlobalTool");
var testProjects = Solution.GetProjects("*.Tests");

// Gather all solution items
var allItems = Solution.AllSolutionFolders.SelectMany(x => x.Items);

// Add a new project to solution
var project = Solution.AddProject(
    name: "DummyProject",
    typeId: ProjectType.CSharpProject,
    path: RootDirectory / "DummyProject.csproj");
Solution.Save();
```

### Strong-Typed Project Access

Using the `GenerateProjects` property you can enable a [source generator](https://devblogs.microsoft.com/dotnet/introducing-c-source-generators/) that provides **strong-typed access to the solution structure**. This greatly improves how you can reference individual projects:

```csharp
[Solution(GenerateProjects = true)]
readonly Solution Solution;

Project GlobalToolProject => Solution.Nuke_GlobalTool;
```

:::info
For every `SolutionAttribute` with the `GenerateProjects` property enabled, the source generator will create a new type with the same name as the field. In the example above, the type `Nuke.Common.ProjectModel.Solution` is silently replaced by a new type `global::Solution` that is local to your project. Therefore, the field name and type must always be the same.
:::

### Creating Solutions

Apart from reading and writing from existing solutions, you can also **create new solution files**. This can be very helpful to generate a global solution for many decoupled solutions in different repositories:

```csharp
var globalSolution = CreateSolution(
    fileName: "global.generated.sln",
    solutions: new[] { MainSolution }.Concat(ExternalSolutions),
    folderNameProvider: x => x == Solution ? null : x.Name);

globalSolution.Save();
```

## Working with Projects through MSBuild

Apart from reading the path and directory of a project through a `Solution` object, you can also use the [Microsoft.Build](https://www.nuget.org/packages/Microsoft.Build) integration to access the MSBuild project model:

```csharp
var msbuildProject = project.GetMSBuildProject();
```

Again, you can also manually load the project using:

```csharp
var msbuildProject = ProjectModelTasks.ParseProject("/path/to/file");
```

Some of the most important information, like target frameworks, runtime identifiers, output type, properties, and item groups can also be retrieved with **predefined helper methods**:

```csharp
var targetFrameworks = project.GetTargetFrameworks();
var runtimeIdentifiers = project.GetRuntimeIdentifiers();
var outputType = project.GetOutputType();

var isPackable = project.GetProperty<bool>("IsPackable");
var compiledFiles = project.GetItems<AbsolutePath>("Compile");
```

However, behind the scenes, these methods will still load the project through the `Microsoft.Build` package.

:::caution
It is **strongly discouraged** to use anything but MSBuild to examine project files. Other approaches, like reading and parsing the XML, are very fragile against the complex evaluation logic that is inherent for project files.
:::
