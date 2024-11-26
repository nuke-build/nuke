---
title: Constructing Paths
---

Referencing files and directories seems like a trivial task. Nevertheless, developers often run into problems where relative paths no longer match the current working directory, or find themselves fixing path separator issues that stem from [historical design decisions](https://www.youtube.com/watch?v=5T3IJfBfBmI). NUKE follows the approach to use absolute paths whenever possible, which ensures explicitness and allows copying [tool invocations](08-cli-tools.md) from the log and executing them from anywhere you are.

Central to the idea of absolute paths is the `AbsolutePath` type and the `NukeBuild.RootDirectory` property. From there on, you can easily construct paths through the [overloaded division operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading):

<!-- snippet: path-construction-basic -->
```cs
AbsolutePath SourceDirectory => RootDirectory / "src";
AbsolutePath OutputDirectory => RootDirectory / "output";
AbsolutePath IndexFile => RootDirectory / "docs" / "index.md";
```
<!-- endSnippet -->

## Common Methods

While `AbsolutePath` is agnostic to whether it points to a file or directory, it provides several commonly used methods for interaction:

<!-- snippet: path-construction-common-methods -->
```cs
// Get names
var nameWithExtension = IndexFile.Name;
var nameWithoutExtension = IndexFile.NameWithoutExtension;
var extensionWithDot = IndexFile.Extension;

// Get the parent directory
var parent1 = IndexFile.Parent;
var parent2 = IndexFile / ..;   // gets normalized
var parent3 = IndexFile / ".."; // gets normalized

// Check if one path contains another
var containsFile = SourceDirectory.Contains(IndexFile);

// Check if a directory or file exists
var directoryExists = SourceDirectory.DirectoryExists();
var fileExists = IndexFile.FileExists();
var pathExists = (RootDirectory / "dirOrFile").Exists(); // checks for both
```
<!-- endSnippet -->

## Relative Paths

Occasionally, you may actually want relative paths, for instance, to include them in manifest files that get shipped with your artifacts. In this case, you can make use of `RelativePath`, which uses the path separator dictated by the operating system, or one of types `WinRelativePath` or `UnixRelativePath`, which enforce using backslash or slash respectively:

<!-- snippet: path-construction-relative-paths -->
```cs
// Get the relative path to the index file
var indexRelativeFile = RootDirectory.GetRelativePathTo(IndexFile);

// Get relative path for Unix
var indexUnixRelativePath1 = RootDirectory.GetUnixRelativePathTo(IndexFile);
var indexUnixRelativePath2 = (UnixRelativePath)indexRelativeFile;
```
<!-- endSnippet -->

All relative path types support using the division operator.

## File-system Operations

Instances of the `AbsolutePath` type provide a wide range of file-system-related operations:

```cs
// Read/write file content
file.ReadAllText();
file.WriteAllLines(lines);

// Touch a file / create a directory
file.TouchFile();
directory.CreateDirectory();

// Rename a file or directory
file.RenameWithoutExtension($"archive-{DateTime.Now.Year}.tar");
directory.Rename(x => $"{x.Name}-final"); // combine previous name

// Move a file or directory
source.Move(target, ExistsPolicy.MergeAndSkip);

// Copy a file or directory (recursively) to another directory
source.CopyToDirectory(target, ExistsPolicy.DirectoryMerge | ExistsPolicy.FileFail);
```

## Globbing

Through the integrated [Glob](https://github.com/kthompson/glob) NuGet package, you can use [globbing patterns](https://en.wikipedia.org/wiki/Glob_(programming)) to collect files or directories from a base directory:

<!-- snippet: path-construction-globbing -->
```cs
// Collect all package files from the output directory
var packageFiles = OutputDirectory.GlobFiles("*.nupkg");

// Collect and delete all /obj and /bin directories in all sub-directories
SourceDirectory
    .GlobDirectories("**/{obj,bin}", otherPatterns)
    .DeleteDirectories();
```
<!-- endSnippet -->
