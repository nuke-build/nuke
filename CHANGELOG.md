# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [vNext]

## [0.10.5] / 2018-10-10
- Fixed `--source` parameter for `DotNetRestore` to be collection

## [0.10.4] / 2018-10-10
- Fixed `GitRepository` when origin URL uses SSH without username

## [0.10.3] / 2018-10-05
- Fixed `WinRelativePath` and `UnixRelativePath` to use correct separator

## [0.10.2] / 2018-10-04
- Fixed `RequirementService` to also support shorthand for properties

## [0.10.1] / 2018-10-02
- Fixed wizard to pass definitions for project file template
- Fixed wizard to create source and tests directory if selected
- Fixed wizard to be disabled for legacy format

## [0.10.0] / 2018-10-02
- Removed `PathConstruction.GetRootRelativePath`
- Removed `License` from specification files
- Deprecated `NukeBuild.Configuration` which should belong to user-code
- Deprecated plus operator in `PathConstruction.AbsolutePath` and `RelativePath`
- Changed `SolutionAttribute` to resolve solution file via parameter
- Changed CLI wrapper tasks to attempt to resolve tool paths from `[TOOL]_EXE` environment variable
- Added `AbsolutePath.Parent` and equality members
- Added `TypeConverter` for `AbsolutePath` which allows passing paths as parameter
- Fixed detection of value types in specification files
- Fixed path variable check to split by specific separator

## [0.9.1] / 2018-09-26
- Fixed wrong assertions in global tool

## [0.9.0] / 2018-09-22
- Deprecated properties in `NukeBuild` which should belong to user-code
- Deprecated default settings which should belong to user-code
- Deprecated `DocFxTasks` which is moved to own package
- Added `SpecFlowTasks`
- Added `NukeBuild.OutputSink` property for custom logger implementation
- Fixed `MSBuildLocator` and `MSBuildToolPathResolver` to also consider `/usr/local/bin/msbuild`

## [0.8.0] / 2018-09-07
- Changed `ProcessTasks` to automatically invoke .NET Core DLLs with `dotnet.exe`
- Added `CoverletTask`
- Fixed exception in `ChangelogTasks.ReadChangelog` when `vNext` section was empty
- Fixed console output to use ASCII instead of Unicode
- Fixed `MSBuildLocator` to use fallbacks when no VS instance with .NET Core is installed

## [0.7.0] / 2018-08-29
- Changed assertion of `DataClass` properties print out value on failure
- Added `SquirrelTasks`
- Added `UnityTasks`
- Added tasks to update the changelog and get the latest version to `ChangeLogTasks`
- Fixed global tool to order solutions descending
- Fixed global tool setup to use correct definitions and error about broken solution
- Fixed validation of requirements of skipped targets
- Fixed double evaluation of conditions with `DependencyBehavior.Skip`

## [0.6.2] / 2018-08-18
- Fixed `MSBuildLocator` to not use `System.ValueTuple`
- Fixed typo in `OctopusCreateReleaseSettings`
- Fixed adaptation of solution file in global tool
- Fixed output of global tool on Windows

## [0.6.1] / 2018-08-09
- Fixed global tool to have 'same as global tool' as fallback version
- Fixed PowerShell invocation to use `-ExecutionPolicy ByPass` and `-NoProfile` 

## [0.6.0] / 2018-08-05
- Removed setup scripts in favor of `:setup` command in global tool
- Removed `ProcessSettings` in favor of integrating related properties into `ToolSettings`
- Removed deprecated APIs
- Changed tasks with return type to return value tuple
- Changed tasks to redirect output by default
- Added `ITargetDefinition.WhenSkipped` to specify dependency behavior for skipped targets
- Added `SlackTasks` and `VSWhereTasks`
- Added namespace support in `XmlTasks`
- Added `FileSystemTasks` for deleting, moving, copying and hash calculation
- Added support for loading external files
- Fixed various build server properties
- Fixed output color for `Logger.Info` to be `Console.ForegroundColor`
- Fixed naming of `VSTestTasks`
- Fixed build script to use VSWhere for locating MSBuild
- Fixed `NuGetPackageResolver` to determine `globalPackagesFolder` from config files
- Fixed `Xunit2Settings` to specify framework of console executable
- Fixed `DotNetRunSettings` to not quote `ApplicationArguments`

## [0.5.3] / 2018-06-12
- Fixed global tool to search build scripts also in current directory
- Fixed generic tasks to not redirect output by default

## [0.5.2] / 2018-06-11
- Changed build summary to log skipped and absent targets unconditionally
- Added `HttpTasks` and `FtpTasks` for `netstandard` target framework
- Fixed global tool to simply exit if script execution returns non-zero exit codes
- Fixed global tool to search build scripts only within 2-level non-system sub-directories
- Fixed build summary to treat `NotRun` as a failure

## [0.5.0] / 2018-06-05
- Changed build scripts to download .NET Core SDK only if local installation is missing or doesn't match expected version
- Added global tool for setup and build invocation
- Added version logging for PowerShell, Bash, NuGet and DotNet
- Added error output for CLT tasks when redirect output is enabled
- Added `[Tool]Tasks.[Tool](string arguments)` for all CLTs
- Added support for double-dashed arguments
- Fixed resolution of `Skip` parameter when using separators
- Fixed font resource resolution for deprecated namespace
- Fixed saving location of build scripts

## [0.4.0] / 2018-05-02
- Deprecated `Nuke.Core` namespace. All types have been moved to `Nuke.Common`
- Changed parameter binding to allow lisp-cased arguments (dashes for camel-humps)
- Changed build execution to automatically unwrap `AggregateException` and `TargetInvocationException`
- Changed build server instances to access variables in non-ensured way
- Changed `GitRepository.FromLocalDirectory` to not return null but fail instead
- Changed reference from `NuGet.Client` to `NuGet.Packaging`
- Changed summary output to use `Trace`, `Error`, `Success` methods of `Logger`
- Added integration infrastructure for ReSharper plugin
- Added typo-checking for arguments that should be bound via `ParameterAttribute`
- Added automatic retrieval of `GitRepositoryAttribute.BranchName` from build server instances
- Added `Logger.Success` method
- Fixed `GitRepository.ParseUrl` to strip username and password
- Fixed nullable properties in `TeamServices` and `Bitrise`
- Fixed host simulation
- Fixed environment variable parsing when case-insensitive duplicates are found

## [0.3.1] / 2018-03-26
- Deprecated `Action` usages in `DotCoverTasks` and `OpenCoverTasks` in favor of `SetTargetSettings`
- Added `ProjectModelTasks` with matching `SolutionAttribute` for auto-injection
- Added `[Tool]Tasks.[Tool]Path` property for better accessibility
- Added `DotCoverTasks` aliases for `cover`, `delete`, `merge`, `report` and `zip`
- Added `ArrayExtensions` for deconstruction
- Changed `NukeBuild.Configuration` to be overridable but still injectable
- Fixed `ProcessManager` to resolve `toolPath` from environment
- Fixed `ProcessManager` to filter executable based on operating system and file extensions
- Fixed `DeleteDirectory` for non-existent sub-directories at time of deletion
- Fixed line-endings in setup scripts

## [0.2.10] / 2018-03-05
- Fixed handling of `Graph` switch
- Fixed logging in Nuke.CodeGenerator
- Fixed temporary directory path in setup and bootstrapping scripts
- Fixed `NuGetSettings` to resolve tool path from `NuGet.CommandLine` package
- Fixed `Invoke-WebRequest` when InternetExplorer's first-launch configuration was not completed
- Fixed resolution of relative paths to be minimal
- Fixed `PathConstruction.GetRelativePath` to work with UNIX paths
- Fixed argument formatting for boolean values
- Fixed enumeration of modified collection

## [0.2.0] / 2018-02-26
- Deprecated `Target` parameter in favor of passing targets as first argument to the bootstrapping scripts
- Deprecated `NoDeps` parameter in favor of new `Skip` parameter that takes a separated list
- Deprecated `DefaultSettings` which are now exposed in each task class individually
- Changed default values for `AssemblyVersion` to `{major}.{minor}.0` and `FileVersion` to `{major}.{minor}.{patch}`
- Added possibility to use `ParameterAttribute` in other injection attributes
- Added `GitVersionAttribute.Bump` parameter for bumping major/minor versions
- Added `GitVersionAttribute.DisableOnUnix` property since GitVersion is not working consistently
- Added `ChangelogTasks.FinalizeChangelog` for finalizing unpublished changes to a certain version
- Added `ChangelogTasks.ExtractChangelogSectionNotes` for extracting release data for a specified tag
- Added `NukeBuild.InvokedTargets` which exposes targets passed from command-line
- Added `NukeBuild.ExecutingTargets` which exposes targets that will be executed
- Added `NukeBuild.SkippedTargets` which exposes targets that will be skipped
- Added `GitRepository.IsGitHubRepository` extension method
- Added `GitRepositoryAttribute.Branch` and `GitRepositoryAttribute.Remote` properties for pass-through
- Added `build.cmd` in setup for easier invocation on Windows
- Added CLT tasks for Git
- Fixed background color in console output

[vNext]: https://github.com/nuke-build/nuke/compare/0.10.5...HEAD
[0.10.5]: https://github.com/nuke-build/nuke/compare/0.10.4...0.10.5
[0.10.4]: https://github.com/nuke-build/nuke/compare/0.10.3...0.10.4
[0.10.3]: https://github.com/nuke-build/nuke/compare/0.10.2...0.10.3
[0.10.2]: https://github.com/nuke-build/nuke/compare/0.10.1...0.10.2
[0.10.1]: https://github.com/nuke-build/nuke/compare/0.10.0...0.10.1
[0.10.0]: https://github.com/nuke-build/nuke/compare/0.9.1...0.10.0
[0.9.1]: https://github.com/nuke-build/nuke/compare/0.9.0...0.9.1
[0.9.0]: https://github.com/nuke-build/nuke/compare/0.8.0...0.9.0
[0.8.0]: https://github.com/nuke-build/nuke/compare/0.7.0...0.8.0
[0.7.0]: https://github.com/nuke-build/nuke/compare/0.6.2...0.7.0
[0.6.2]: https://github.com/nuke-build/nuke/compare/0.6.1...0.6.2
[0.6.1]: https://github.com/nuke-build/nuke/compare/0.6.0...0.6.1
[0.6.0]: https://github.com/nuke-build/nuke/compare/0.5.3...0.6.0
[0.5.3]: https://github.com/nuke-build/nuke/compare/0.5.2...0.5.3
[0.5.2]: https://github.com/nuke-build/nuke/compare/0.5.0...0.5.2
[0.5.0]: https://github.com/nuke-build/nuke/compare/0.4.0...0.5.0
[0.4.0]: https://github.com/nuke-build/nuke/compare/0.3.1...0.4.0
[0.3.1]: https://github.com/nuke-build/nuke/compare/0.2.10...0.3.1
[0.2.10]: https://github.com/nuke-build/nuke/compare/0.2.0...0.2.10
[0.2.0]: https://github.com/nuke-build/nuke/tree/0.2.0

