# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [vNext]
- Added GitHub Actions support for submodules and fetch-depth
- Added AppVeyor support for submodules

## [6.0.0] / 2022-01-07
- Removed `ToolSettings.ProcessLogFile` and `ProcessLogTimestamp`
- Removed `GitHub` prefix for `GitHubActions` environment variables
- Deprecated `Logger` in favor of `Serilog.Log`
- Deprecated `ControlFlow` asserts in favor of `Assert` class
- Changed `Nuke.GlobalTool` to enable `RollForward` with `LatestMajor`
- Changed default serialization settings for JSON and YAML in `SerializationTasks`
- Changed GitHub Actions generation to use default `GitHubActions.Token` through `EnableGitHubContext`
- Changed Azure Pipelines generation to use default `AzurePipelines.AccessToken` through `EnableAccessToken`
- Added shell-completion support for global tool builds
- Added `NukeBuild.ExecutionPlan` to public API
- Added `Partition.Part` and `Total` to public API
- Added `MSBuildToolPathResolver` support for Visual Studio 2022
- Added `XmlTasks` variants for `string` objects
- Added `AbsolutePath.Name` and `NameWithoutExtension` properties
- Added `AbsolutePath.Exists`, `FileExists`, and `DirectoryExists` extension methods
- Added `Project.HasPackageReference` and `GetPackageReferenceVersion`
- Added `UpdateFile` variants in `SerializationTasks`
- Added `StdToText` and `StdToJson` extension methods for `IEnumerable<Output>`
- Added newest worker images for Azure Pipelines, GitHub Actions, and AppVeyor generation
- Added Azure Pipelines generation for pull-request triggers, fetch depth, and clean checkout
- Added Space Automation support for secrets
- Added TeamCity support for GUID tokens
- Added `AzurePipelinesCachePaths` for common cache paths
- Added `AzurePipelines.PhaseName` property
- Added `GitHub.CreateComment` for issue and pull-request comments
- Added `TeamCity.AuthUserId` and `AuthPassword` properties
- Added `AppVeyorSecretAttribute` for generation of secret value entries
- Added `HttpClient`, `HttpRequest`, and `HttpResponse` extensions
- Added `XNode` extensions
- Added `LatestMavenVersionAttribute`
- Added `MauiCheckTasks`
- Added `MinVerTasks` and `MinVerAttribute`
- Added `PowerShellTasks`
- Added `BootsTasks`
- Added `NetlifyTasks`
- Fixed check for executables compiled with `PublishSingleFile`
- Fixed `MSBuild` localization using `MSBuildLocator`
- Fixed missing assertion for successful status code in `HttpTasks`
- Fixed Azure Pipelines caching
- Fixed `IBuildServer.Branch` for `AzurePipelines`
- Fixed `OctoVersionTasks` and `OctoVersionAttribute` for latest version
- Fixed `AzureSignToolTasks` to invoke `sign` command
- Fixed missing `Files` property in `AzureSignTool`
- Fixed missing `Blame*` properties in `DotNetTasks`
- Fixed property types in `ILRepackTasks`
- Fixed `UnityTasks` to auto-detect version
- Fixed quoting for `UnityTasks.LogFile`

## [5.3.0] / 2021-08-04
- Added LFS and Submodule settings in AzurePipelines configuration
- Added `OctoVersionTasks` and `OctoVersionAttribute`
- Added `AzureSignToolTasks`
- Added `ChocolateyTasks`
- Fixed invocations for PowerShell bootstrapping script
- Fixed retrieval of `version_dotnet_sdk` in telemetry
- Fixed solution serialization to show information about duplicated entries
- Fixed path construction to be lazy for in-memory solutions that get saved
- Fixed `GitHubTasks.GetGitHubBrowseUrl` to trim trailing slash
- Fixed `GitVersionAttribute.Framework` default value to `net5.0`
- Fixed URLs in `ChangeLogTasks`
- Fixed `DotNetTestSettings.Loggers` property to accept multiple values
- Fixed default value emission for `DotCoverTasks`
- Fixed missing properties for `GitVersionTasks`
- Fixed missing secret attributes in `SonarScannerTasks`
- Fixed `NerdbankGitVersioningFormat` enumeration to use lower-case

## [5.2.1] / 2021-06-18
- Fixed telemetry
- Fixed humanized string concatenation

## [5.2.0] / 2021-06-18
- Added telemetry data collection
- Added unified `NukeBuild.Partition` property
- Added `Rider`, `VisualStudio`, `VSCode` as `Host` implementations
- Added `GitRepository.IsOnMainBranch` and `IsOnMainOrMasterBranch`
- Added `AbsolutePath` equality operators
- Fixed SpaceAutomation to generate default `refSpec`
- Changed `Microsoft.CodeAnalysis.CSharp` package version to `3.9.0`
- Removed `Refit` reference and `ITeamCityRestClient` interface
- Removed `Colorful.Console` reference and embedded figlet fonts

## [5.1.4] / 2021-06-01
- Fixed `StronglyTypedSolutionGenerator` to resolve root directory only on demand
- Fixed `JetBrains.Annotations` to be packed with source generators
- Fixed missing SpaceAutomation configuration link

## [5.1.3] / 2021-05-31
- Fixed filtering explicitly overridden targets in build components

## [5.1.2] / 2021-05-18
- Fixed target duration to be measured immediately after execution
- Fixed build script invocation from global tool
- Fixed `AddPackage` command to allow explicit version parameter
- Fixed navigation methods to not be included in command list
- Fixed `StronglyTypedSolutionGenerator` to resolve root directory only on demand
- Fixed `EnvironmentInfo.Framework` to use entry assembly
- Fixed parsing of `GitRepository` remote
- Fixed missing pull-request properties in TeamCity
- Fixed `RunNumber` and `RunId` in `GitHubActions` to be of type `long`
- Fixed `GitVersionAttribute` to automatically populate `Git_Branch` on TeamCity

## [5.1.1] / 2021-04-23
- Fixed parameter loading with missing default parameters file
- Fixed visibility of `Directory.Build` files
- Fixed `ArgumentsFromCommitMessageAttribute` to require manual application
- Fixed summary reporting for exceptions to only include first line of message
- Fixed update notification
- Fixed PowerShell invocation from `build.cmd`
- Fixed `Update` and `Setup` command to not stage parameters file
- Fixed `Update` command for absent bootstrapping scripts
- Fixed skipping unhandled syntax fragments in Cake conversion
- Fixed missing `Instance` properties for `IBuildServer` implementations
- Fixed GitHubActions default cache path
- Fixed missing property for GitHubActions workflow inputs
- Fixed quoting in GitHubActions for included/excluded paths
- Fixed `XmlPoke` to allow specifying encoding
- Fixed `ExternalFilesTask` for single file browse-URL
- Fixed `ICompile`, `IPack`, `ITest` components to check against `SucceededTargets`
- Fixed setting `RepositoryUrl` in `IPack` component

## [5.1.0] / 2021-04-07
- Removed `:Fix` command from global tool (superseded by `:AddPackage`)
- Changed `.nuke` configuration file to `.nuke` directory
- Changed shell-completion to rely on `build.schema.json` file
- Changed default `DependencyBehavior` to `Skip`
- Changed `HostType` to `Host` base class
- Changed `ExecutionStatus` members `Executed` to `Succeeded`, and `Executing` to `Running`
- Changed `IBuildExtension` instances to be cached
- Changed `IOnBeforeLogo` and `IOnAfterLogo` extensions to `IOnBuildCreated` and `IOnBuildInitialized`
- Changed `IsSuccessful` to check for succeeded, skipped and collective targets
- Changed `ParameterAttribute` to allow external value providers with `ValueProviderType` and `ValueProviderMember`
- Changed GitHubActions secret names to split on camel-humps
- Added support for parameter files (profiles)
- Added source generator for strong-typed solutions
- Added shorthand dependencies for build components
- Added `ReportSummary` for summary extension to `NukeBuild` and `INukeBuild`
- Added exception reporting in summary
- Added `ParameterPrefixAttribute` for build components
- Added build extensions for `OnTargetSkipped`, `OnTargetRunning`, `OnTargetSucceeded`, and `OnTargetFailed`
- Added styling for unlisted targets in execution plan HTML
- Added `:Secrets` command to global tool and `SecretAttribute` for encryption in parameters files
- Added `:AddPackage` command to global tool
- Added `:GetConfiguration` command to global tool
- Added `:Update` command to global tool
- Added `:CakeConvert` and `:CakeClean` commands to global tool
- Added generation of `Directory.Build.props` and `Directory.Build.targets` files
- Added parameter resolution for root directory in global tool
- Added shell-navigation aliases `nuke/` and `nuke-`
- Added `ScheduledTargets`, `RunningTargets`, `AbortedTargets`, `FailedTargets`, `SucceededTargets` collections to `NukeBuild` and `INukeBuild`
- Added `ArgumentsFromCommitMessageAttribute` and `:Trigger` command to global tool
- Added `ExitCode` to `INukeBuild`
- Added `IsFinished` and `IsFailing` to `NukeBuild` and `INukeBuild`
- Added caching for `ValueInjectionUtility.TryGetValue`
- Added equality operators and implicit conversion to string for Enumeration
- Added `GetProject`, `GetSolutionFolder`, `Projects`, and `SolutionFolders` to `SolutionFolder`
- Added `GetRuntimeIdentifers` to `ProjectExtensions`
- Added string-escape extension for MSBuild in `DotNetTasks` and `MSBuildTasks`
- Added `EnsureExistingDirectory` and `EnsureExistingParentDirectory` overloads for `AbsolutePath`
- Added `XmlPeekElements` to `XmlTasks`
- Added `GitRepository` properties `RemoteName` and `RemoteBranch`
- Added support for `NerdbankGitVersioning`
- Added `NoCache` property to `GitVersionAttribute` with default value `true`
- Added `SendOrUpdateSlackMessage` to `SlackTasks`
- Added support for JetBrains SpaceAutomation
- Added support for GitHub Actions dispatch workflows
- Added support for GitLab CI
- Added support for multiple AppVeyor configurations
- Added support for AppVeyor secrets
- Added support for platform-independent TeamCity configurations
- Added TeamCity parameter to replace run-button caption
- Added `AddTeamCityLogger` for `DotNetTest` task
- Added `IsPersonalBuild` property to `TeamCity`
- Added caching for `AzurePipelinesAttribute` and `GitHubActionsAttribute`
- Added `SetVariable` to `AzurePipelines`
- Added `CodeMetricsTasks`
- Added `PulumiTasks`
- Added `CodecovTasks`
- Added `CorFlagsTasks`
- Added `FixieTasks`
- Added `ILRepackTasks`
- Fixed skip reason for targets skipped from `--skip` parameter
- Fixed execution plan legend
- Fixed execution plan highlighting for multiple default targets
- Fixed `ConsoleUtility` to allow full deletion of secret
- Fixed exception reporting for `ExecutableTargetFactory`
- Fixed handling of value types in `ValueInjectionUtility.TryGetValue`
- Fixed calculation of value sets for collection parameters
- Fixed compilation of legacy template
- Fixed `IsDescendantPath` to split path parts
- Fixed `MoveDirectory` with additional `deleteRemainingFiles` parameter
- Fixed `SwitchWorkingDirectory` to respect `allowCreate` parameter
- Fixed `ResponseArchive` in `ISignPackages` build component
- Fixed MSBuild path resolution to fallback to using `dotnet --list-sdks`
- Fixed client usage in `GitHubTasks`
- Fixed token ordering in `TemplateUtility`
- Fixed default value for collections in TeamCity configurations
- Fixed TeamCity composite configurations to propagate failures
- Fixed `TeamCity` and `AzurePipelines` to update build numbers in environment variables
- Fixed `TriggerBatch` in AzurePipelines generation
- Fixed condition in AppVeyor generation
- Fixed `FileFilters` property in `ReportGeneratorTasks`
- Fixed logger for `DocFXTasks`
- Fixed `Severity` property in `ReSharperTasks`
- Fixed missing `MSBuild` and `ToolRestore` task in `DotNetTasks`
- Fixed missing `Buildx` task in `DockerTasks`
- Fixed missing `CoverDotNet` task in `DotCoverTasks`
- Fixed missing `GenericCoveragePaths` property in `SonarScannerTasks`
- Fixed missing properties in `ReSharperTasks`
- Fixed missing properties in `TeamCity`, `GitHubActions`, and `AzurePipelines`
- Fixed missing `SignToolDigestAlgorithm` enumeration in `SignToolTasks`

## [5.0.2] / 2020-12-07
- Fixed `ChangelogTasks` to use HTTPS links in history
- Fixed `DotNetRun` and `DotNetTest` run settings
- Fixed conditions for informational text

## [5.0.1] / 2020-12-06
- Fixed configuration generation to wait for user input after file changes
- Fixed build summary for durations smaller than 1 second
- Fixed build summary and `IBuildExtension` instances to be skipped if no targets were started
- Fixed build summary to hide irrelevant durations
- Fixed setting of `EmbeddedPackagesDirectory` for global tools
- Fixed `PackPackageToolsTask` to use lower-case package ids
- Fixed `ParameterAttribute.ValueProvider` to allow members of type `IEnumerable<string>`
- Fixed `Logger` to remove `ControlFlow` from stacktrace
- Fixed assertion messages for warnings
- Fixed path and quoting in `build.cmd`
- Fixed `GitVersion.Tool` version in project templates
- Fixed `LatestMyGetVersionAttribute` to handle new RSS feed format
- Fixed missing arguments `PublishReadyToRun`, `PublishSingleFile`, `PublishTrimmed`, `PublishProfile`, `NoLogo` for `DotNetPublish`
- Fixed parameter name `Verbosity` in `DotNetPack`
- Fixed enumeration value `lcov` in `CoverletTasks`
- Fixed `ReSharperTasks` to use correct tool path
- Fixed `ChangelogTasks` to respect additional markdown-linting rules
- Fixed TeamCity generator to consider artifact products from all relevant targets
- Fixed condition for skipping lines in TeamCity parameter files

## [5.0.0] / 2020-11-12
- Fixed version number

## [0.25.0] / 2020-10-26
- Removed `Configuration` from `Nuke.Common` and moved it to template
- Changed `InjectionAttribute` to catch exceptions and report as warnings
- Changed `ToolPathResolver` to ignore casing
- Changed `ToolSettings` to prefix common properties with `Process`
- Changed property names in `Nuke.Common.targets`
- Changed `GitRepository` to trim `refs/heads/` and `origin/` from branch names
- Changed `ShutdownDotNetBuildServerOnFinish` to not log by default
- Changed `ShutdownDotNetBuildServerOnFinish` to only shutdown on server build
- Added support for interface default implementations
- Added `NukeBuild.ExitCode` for custom exit codes
- Added `ProcessTasks.StartShell` to invoke shell commands
- Added `ToolSettings.Apply` for fluent configurator invocation
- Added `ToolSettings.LogFile` and `LogTimestamp`
- Added `nuke :fix` command to `Nuke.GlobalTool` for adding missing package downloads
- Added `nuke :GetRootDirectory` and `nuke :GetParentRootDirectory` in `Nuke.GlobalTool`
- Added `LatestNuGetVersionAttribute`, `LatestGitHubReleaseAttribute`, `LatestMyGetVersionAttribute`
- Added `GitRepository.Protocol`, `Commit`, and `Tags` properties
- Added logger delegate to `ControlFlow.ExecuteWithRetry`
- Added `BuildExtensionAttributeBase` with `Priority` property
- Added `UnsetVisualStudioEnvironmentVariables` by default
- Added `TeamCity.BuildVcsNumber` property
- Added AzurePipelines variable groups, secret and access token import
- Added `AppVeyor.Url` and `PushArtifact` members
- Added warning when `GitVersion` is used with SSH endpoint and `NoFetch` is disabled
- Added consolidated `ReSharperTasks` for `CleanupCode`, `InspectCode`, and `DupFinder`
- Added `TeamsTasks`
- Added `SignPathTasks`
- Added `SignClientTasks`
- Added `BenchmarkDotNetTasks`
- Added `CleanupCodeTasks`
- Added `DotNetTasks.DotNetNuGetAddSource` task
- Added `OctopusTasks.OctopusBuildInformation` task
- Added missing properties in `SonarScannerTasks`
- Added verbosity mapping attributes for `NUnit`, `OpenCover`, and `ReportGenerator`
- Fixed version check in bootstrapping scripts to rely on dotnet CLI exit code
- Fixed deactivation of multi-level lookup in bootstrapping scripts
- Fixed deactivation of shared compilation in bootstrapping scripts
- Fixed `ToolPathResolver` to consider all package executable names
- Fixed `ToolPathResolver` to choose executable based on operating system
- Fixed output/input encoding to use `UTF-8`
- Fixed `NukeBuild.BuildProjectFile` property
- Fixed AppVeyor generation for Unix images
- Fixed `AzurePipelinensAttribute` to allow multiple use
- Fixed AzurePipelines to replace dots in stage name with underscore
- Fixed `AppVeyor.UpdateBuildVersion` to set environment variable
- Fixed `DupFinderTasks.DiscardCost` property
- Fixed `DotCoverTasks` to use double-dashes instead of slashes
- Fixed `NpmTasks.CustomLogger` to detect warnings in error output

## [0.24.11] / 2020-05-18
- Fixed transitive artifacts in configuration generation
- Fixed `StackOverflowException` in configuration generation
- Fixed `IsPackable` property default
- Fixed missing colon in GitHubActions triggers
- Fixed assertion message for finding Git directory
- Fixed assertion message for `teamcity.dotCover.home`

## [0.24.10] / 2020-04-24
- Fixed MSBuild targets to switch on `MSBuildRuntimeType` again
- Fixed default includes for `NukeSpecificationFiles` and `NukeExternalFiles`
- Fixed indentation for GitHubActions scheduled triggers
- Fixed assertion message for GitHubActions trigger definitions
- Fixed default `RootNamespace`

## [0.24.9] / 2020-04-16
- Fixed MSBuild targets directories

## [0.24.8] / 2020-04-12
- Fixed publishing of global tool for `netcoreapp3.1`
- Fixed .NET Core SDK install script URL
- Fixed trap error output in PowerShell bootstrapping
- Fixed AzurePipelines push triggers
- Fixed AzurePipelines configuration to allow overriding configuration directory
- Fixed previous constructor usages for `AzurePipelinesAttribute`
- Fixed PowerShell downloads to use TLS 1.2 security protocol
- Fixed unrecognized `Visible` attribute for `PackageDownload` item group

## [0.24.7] / 2020-03-26
- Fixed MSBuild targets for .NET Core
- Fixed `GitRepository.GetGitHubMilestone` to retrieve milestone independent of state

## [0.24.6] / 2020-03-25
- Fixed NuGet package resolution performance
- Fixed MSBuild integration
- Fixed TeamCity trace output to be dark gray
- Fixed missing using statement for `Nuke.Common.IO`

## [0.24.5] / 2020-03-24
- Fixed TeamCity configuration to use Bash script on Unix

## [0.24.4] / 2020-03-05
- Fixed Refit version
- Fixed conversion of `GitHubActionsTrigger`
- Fixed project default includes to check existence of files
- Fixed projects to target `netcoreapp2.1`
- Fixed configuration generation to allow multiple configurations per host type
- Fixed `AzurePipelinesAttribute` to allow setting a configuration suffix
- Fixed CI server detection to ignore empty environment variables
- Fixed `TeamCityOutputSink` to not report errors as build problems
- Fixed custom logger for `NpmTasks`
- Fixed custom logger for `DockerTasks`
- Fixed missing NuGet install task
- Fixed missing `Framework` property in `OctopusTasks`
- Fixed missing `ReportType` in `DotCoverTasks`
- Fixed missing properties in `DotNetTasks`
- Fixed Glob version
- Fixed `GitVersionAttribute` to avoid duplicated version numbers
- Fixed `System.ValueTuple` version

## [0.24.2] / 2020-02-15
- Fixed extension methods for settings with base type
- Fixed `SonarScannerTasks` to have `Framework` property
- Fixed generation of `shell-completion.yml` to exclude unlisted targets for invocation

## [0.24.1] / 2020-02-07
- Fixed `NuGetPackageResolver` to include dependencies during tool path resolution
- Fixed parsing of TeamCity environment variables
- Fixed execution flags for `build.sh` and `build.cmd` scripts during setup
- Fixed assertion message in `UnityTasks`
- Fixed `build.cmd` to have newline at end-of-file
- Fixed logo spacing

## [0.24.0] / 2020-02-02
- Removed `NuGetPackage` tasks and AutoMapper package reference
- Removed TeamCity definitions for `VcsRoot` and trigger timezones
- Changed `AbsolutePath`, `RelativePath`, `WinRelativePath` and `UnixRelativePath` to outer scope
- Changed default package for `DotCoverTasks` to `JetBrains.dotCover.DotNetCliTool`
- Changed default includes to be provided via `Nuke.Common.targets`
- Changed `ConfigurationGenerationAttributeBase` to `ConfigurationAttributeBase`
- Changed manually invoked targets to be TeamCity deployment configurations
- Changed `AzurePipelines` interface to use enumerations for test result type and code coverage tool type
- Changed package version for `Glob`, `Microsoft.IdentityModel.Clients.ActiveDirectory`, `Newtonsoft.Json`, `NuGet.Packaging`, `Refit`, `YamlDotNet`
- Added cross-platform `build.cmd` bootstrapping script
- Added build emotions
- Added update of build number for TeamCity, AppVeyor, and Azure Pipelines from `GitVersionAttribute`
- Added `AzureKeyVault` – previously available as addon
- Added `DocFXTasks`, `DockerTasks`, `HelmTasks`, `KubernetesTasks`, and `NSwagTasks` – previously available as addons
- Added TeamCity logger extension method for `DotNetBuildSettings`
- Added support for checkboxes in TeamCity configuration
- Added `GitHubTasks`
- Added `ProjectModelTasks.CreateSolution`
- Added `Solution.GetProject` and `GetSolutionFolder` overloads via `Guid`
- Added `TeamCity.NightlyBuildAlways` property
- Added detailed null-check for `teamcity.build.branch` configuration property
- Added Coverlet extension methods for `DotNetTest` task
- Added `AzurePipelines.PublishCodeCoverage`
- Added setters for `Project` properties
- Added `Solution.AddSolution` and `ProjectModelTask.CreateSolution` overload for creating global solutions
- Added path extension methods for `Get(Win|Unix)RelativePathTo`, `Contains`, and `To(Win|Unix)RelativePath`
- Added `NoFetch`, `Framework`, and `UpdateBuildNumber` properties to `GitVersionAttribute`
- Fixed directory creation in bootstrapping scripts
- Fixed artifact paths for TeamCity and Azure Pipelines
- Fixed path separators for AppVeyor and GitHubActions configurations
- Fixed `NSwag` to quote tool path
- Fixed `SolutionSerializer` to handle inconsistent whitespaces
- Fixed `NpmCi` task to include definite argument
- Fixed `VSTestSettings.TestCaseFilters` to be list of strings
- Fixed `EnvironmentInfo.FrameworkName`
- Fixed `cleanCheckoutDirectory` to be set for all TeamCity build types
- Fixed `AddTeamCityLogger` extension method
- Fixed `buildType` reference in TeamCity build-finished triggers
- Fixed `ReportGenerator` task to resolve `ReportGenerator.dll`
- Fixed sharing of artifacts between agents
- Fixed `GitVersionSettings.UpdateAssemblyInfoFileNames` to be an array

## [0.23.7] / 2020-01-28
- Fixed summary alignment for hosts that trim whitespaces

## [0.23.6] / 2020-01-12
- Fixed `InspectCodeTasks` to use new plugin endpoint for downloading
- Fixed `AppVeyorOutputSink` to issue a warning when exceeding the default limit of 500 messages

## [0.23.5] / 2020-01-10
- Fixed CI integrations to use correct warning/error reporting infrastructure
- Fixed TeamCity configuration to use `UTF-8` encoding
- Fixed process encoding by setting `StandardOutputEncoding` and `StandardErrorEncoding` to `UTF-8`
- Fixed solution deserialization for missing configuration section
- Fixed logo spacing

## [0.23.4] / 2019-11-16
- Fixed assignment for `NuGetAssetsConfigFile` when `BuildProjectDirectory` is null
- Fixed `ToolPathResolver` to not require framework when only one file matches

## [0.23.3] / 2019-11-02
- Fixed separator in Azure Pipelines service messages

## [0.23.2] / 2019-11-02
- Fixed ensuring of existing directory for generation of configuration files
- Fixed packaging of `MSBuildTaskRunner` in `Nuke.Common`

## [0.23.1] / 2019-11-02
- Fixed checking hashes for non-existing configuration files
- Fixed null-reference exception for commands without message

## [0.23.0] / 2019-10-31
- Changed target frameworks to `netcoreapp3.0` and `net472`
- Changed `AzureDevOps` to `AzurePipelines`
- Changed `CheckBuildProjectConfigurationsAttribute` to skip dot-prefixed directories
- Removed `ProjectFromAttribute`
- Removed `MSBuildTasks.MSBuildParseProject`
- Removed `GitVersion.GetNormalizedAssemblyVersion` and `GetNormalizedFileVersion`
- Added NuGet package resolution from `project.assets.json` file
- Added CI interface resolution via `CIAttribute`
- Added `Bamboo` interface
- Added `TeamCityImportDotCoverPathAttribute` to address version mismatch
- Added `GitHubActionsAttribute` for configuration generation
- Added `AzurePipelinesAttribute` for configuration generation
- Added `AppVeyorAttribute` for configuration generation
- Added execution of `dotnet build-server shutdown` when build has finished
- Added `NpmCi` task
- Fixed `TeamCity` parameter dictionaries to use original keys
- Fixed NuGet package resolution for project files without `PackageReference` items
- Fixed code inspections in PowerShell script
- Fixed resolution for legacy package directories
- Fixed generation of `Partition` parameter and script paths
- Fixed `ToolPathResolver` to support global tool packages
- Fixed `ReportGeneratorTasks` and `GitVersionTasks` by providing `Framework` property

## [0.22.2] / 2019-09-29
- Fixed SourceLink integration

## [0.22.1] / 2019-09-21
- Fixed assertion message for missing packages

## [0.22.0] / 2019-09-17
- Changed `UnlistedAttribute` to `List` property on `ParameterAttribute`
- Changed summary to show aborted and not-run targets as warning
- Changed `TeamServices` to `AzureDevOps`
- Changed namespace `Nuke.Common.BuildServers` to `Nuke.Common.CI.*`
- Added support for multiple default targets
- Added support for `PackageDownload` item group
- Added support for hyphens in target names
- Added support for absolute paths in `LocalExecutableAttribute`
- Added support for `GitHubActions`
- Added TeamCity configuration generation via `TeamCityAttribute`
- Added XML serialization for .NET Core
- Added reporting of TeamCity statistical values
- Added additional methods for `CloudFoundryTasks`
- Added `ProjectType` for Docker and SQL projects
- Added implicit cast operator for generated enumerations
- Added `InnoSetupTasks`
- Added `TwitterTasks`
- Added `IOnBuildFinished` build extension
- Added missing arguments for `CoverletTasks`
- Fixed `--boot` in setup for .NET Framework/Mono support
- Fixed XML documentation for generated CLI tasks
- Fixed `MSBuildToolPathResolver` to consider preview editions
- Fixed `NuGetPackageResolver` to allow multiple versions of the same package
- Fixed `TeamCity.SetParameter` and `TeamCity.ImportData`
- Fixed `SolutionSerializer` to fall back to `ProjectConfiguration` section
- Fixed `MSBuildLocator` package to have `vswhere.exe` embedded

## [0.21.2] / 2019-07-28
- Fixed validation to exclude requirements of skipped targets
- Fixed solution serialization to include malicious project GUID in error message

## [0.21.1] / 2019-07-19
- Fixed logging of warnings

## [0.21.0] / 2019-07-15
- Changed `ProjectModelTasks.ParseProject` to revert `MSBUILD_EXE_PATH` environment variable
- Added `CloudFoundryTasks`
- Added missing arguments for `SonarScannerTasks`
- Added missing arguments for `OctopusTasks`
- Added `Jenkins.BranchName` and `Jenkins.ChangeId`

## [0.20.1] / 2019-06-02
- Fixed MSBuild evaluation issues by updating NuGet.Packaging to v4.9.2

## [0.20.0] / 2019-05-29
- Changed `Solution.GetProject` to allow resolution from full path
- Changed HTML execution plan to be shown left-to-right
- Added `When` overload for combinatorial settings
- Added `Project.GetOutputType` method for convenience
- Added `GlobbingOptionsAttribute` for configuration of case-sensitivity
- Fixed casing of `NuGet.exe`
- Fixed `TeamServices` to resolve `BuildNumber` as `string`

## [0.19.2] / 2019-05-10
- Fixed `ProjectModelTasks` to use existing `MSBUILD_EXE_PATH` value
- Fixed `ParameterService` to consider nullable enum types in value set calculation
- Fixed compile errors in build template

## [0.19.1] / 2019-05-03
- Fixed `RequirementService` to check for `InjectionAttributeBase`

## [0.19.0] / 2019-05-03
- Changed MSBuild targets to be invoked with `Exec` task
- Changed `ProcessTasks` to avoid Mono when using WSL
- Added output for non-default working directories
- Added `GitVersion.VersionSourceSha`
- Added `ReportTypes.TeamCitySummary`
- Fixed parameter resolution to handle hyphens
- Fixed MSBuild resolution for Visual Studio 2019
- Fixed issues when build has no default target defined

## [0.18.0] / 2019-03-24
- Changed `ParameterService` to strip dashes when resolving value
- Changed formatting of skip reason
- Added `CompressionTasks`
- Added `EntityFrameworkTasks`
- Fixed `UnityTasks.UnityPath` for Windows
- Fixed `SystemColorOutputSink` to print warning and error details
- Fixed `SonarScannerTasks` to also resolve from netstandard package

## [0.17.7] / 2019-03-12
- Fixed `SystemColorOutputSink` to set `ForegroundColor`

## [0.17.6] / 2019-03-04
- Fixed `RequirementService` to check for `ParameterAttribute` when injecting values interactively

## [0.17.5] / 2019-03-03
- Fixed `GlobDirectories` and `GlobFiles` to not collect items lazily

## [0.17.4] / 2019-03-02
- Fixed bootstrapping script to not set `NUGET_XMLDOC_MODE`

## [0.17.3] / 2019-02-27
- Fixed documentation file generation
- Fixed `CheckBuildProjectConfigurationsAttribute.Timeout` to be settable

## [0.17.2] / 2019-02-24
- Fixed parsing of changelog

## [0.17.1] / 2019-02-23
- Fixed attributes in build tasks

## [0.17.0] / 2019-02-23
- Removed collection-based tasks in `FileSystemTasks`
- Changed `ContinueOnFailure` to `ProceedAfterFailure`
- Changed summary output to not include collective targets
- Added `logInvocation` parameter and `ToolSettings.LogInvocation` property
- Added interactive parameter resolution
- Added `RequiredAttribute` for globally required parameters
- Added skip reason to summary
- Added `FileGlobbingAttribute` and `DirectoryGlobbingAttribute`
- Added `GetProperty<T>`, `GetItems<T>`, and `GetItemMetadata<T>` as `ProjectExtensions`
- Added `Unlisted` for target declarations
- Added `ToolResolver` for custom delegate resolution
- Added `DotNetToolInstall`, `DotNetToolUninstall`, and `DotNetToolUpdate`
- Added `UnsetVisualStudioEnvironmentVariablesAttribute`
- Added universal log methods with severity as parameter
- Fixed parameter resolution for value types
- Fixed `AbsolutePath` to be serializable
- Fixed output for parallel task execution
- Fixed exit code for failing targets using `ProceedAfterFailure`
- Fixed exception message for circular dependencies

## [0.16.0] / 2019-01-30
- Changed setting of default working directory for process invocations
- Changed `Logger.Log` to `Logger.Normal`
- Added `NukeBuild.Execute` overload without default target
- Added `ContinueOnFailure` and `AssuredAfterFailure` as target definition methods
- Added `AbsolutePath` extensions for `GlobDirectories/Files`
- Added `AggregateException` handling to show number as prefix when flattening
- Added `AnsiColorOutputSink` for Bitrise, TeamCity, Travis, TeamServices
- Added `ProjectModelTasks.ParseProject` based on `Microsoft.Build` packages
- Added `LocalExecutableAttribute`
- Added `degreeOfParallelism` and `completeOnFailure` for combinatorial invocations
- Added `[Tool]Tasks.[Tool]Logger` as settable field for custom logging
- Added `VerbosityMappingAttribute`
- Added format-property map for CLI tasks
- Fixed `EnsureCleanDirectory` to only clean instead of delete and recreate
- Fixed `TeamCityOutputSink` to not report errors as build problems
- Fixed `SolutionAttribute` to resolve first by constructor argument
- Fixed `Xunit2ParallelOption` to use lower-case text

## [0.15.0] / 2019-01-16
- Changed `OnlyWhen` to `OnlyWhenStatic` and `OnlyWhenDynamic`
- Changed `graph` parameter to `plan`
- Added `DependentFor`, `Triggers` and `TriggeredBy` for target declarations
- Added `ToolSettings.CombineWith` for combinatorial invocations
- Added several `FileSystemTasks` methods
- Added `TemplateUtility.FillTemplateDirectory` and `FillTemplateFile`
- Added highlighting of execution plans in HTML representation
- Added process cancellation handler to always show summary
- Added `NuGetTasks` to add, remove, update, enable, disable and list sources
- Added `TravisOutputSink`
- Added path resolution for `VSTestTasks`
- Added caching of `MSBuild` path in `GetMSBuidProject`
- Fixed `GitRepository.IsOnDevelopBranch` to recognize `develop` and `development`
- Fixed shell-completion for PowerShell

## [0.14.1] / 2018-12-31
- Fixed package reference versions
- Fixed `SolutionSerializer` to handle empty lines

## [0.14.0] / 2018-12-31
- Removed named target dependencies
- Removed choice of target framework in setup
- Changed setup to write solution file reference to configuration file again
- Added extended solution parsing with integration for `Microsoft.Build`
- Added `Configuration` type
- Added `continue` parameter
- Added checking for active build project configurations in solution files
- Added highlighting for default target in HTML graph
- Added `SonarScannerTasks`
- Added `EnvironmentInfo.SwitchWorkingDirectory`
- Added `SymbolPackageFormat` property for `DotNetTasks`, `MSBuildTasks`, and `NuGetTasks`
- Fixed bootstrapping scripts not to leave DotNet processes behind
- Fixed bootstrapping scripts to correctly quote arguments
- Fixed overload of tool path for .NET Core executables
- Fixed default value not to be hidden by cursor
- Fixed `ToolSettingsExtensions.When` to have generic constraint on `ToolSettings`
- Fixed `InspectCodeTasks` to use deterministic hashing
- Fixed `ChangelogTasks` to correctly parse empty sections at end of file
- Fixed `InjectionAttributeBase` to express implicit assignment only
- Fixed `ExternalFilesTask` to be executed before `Restore` target

## [0.13.0] / 2018-12-10
- Changed verification of PATH environment variable to be executed only with `Trace` log level
- Added `ToolSettings.When` for conditional fluent modifications
- Added `.editorconfig` file in setup to avoid formatting issues
- Added `DotMemoryUnitTasks`
- Added missing properties in `DotNetCleanSettings`, `DotNetRestoreSettings` and `MSBuildSettings.Restore`

## [0.12.4] / 2018-12-02
- Fixed `SolutionAttribute` to handle empty configuration file

## [0.12.3] / 2018-11-29
- Fixed `EnvironmentInfo.Variables` not to be cached
- Fixed `Glob` package reference in legacy template
- Fixed error message for unresolvable root directory
- Fixed global tool setup to hide choice of bootstrapping by default
- Fixed `NuGetPackageResolver` assertion for dependency resolution

## [0.12.2] / 2018-11-27
- Fixed globbing related issues
- Fixed shell-completion to not split common names
- Fixed bootstrapping scripts to guard extraction of SDK version
- Fixed help text to be printed before value injection

## [0.12.1] / 2018-11-24
- Fixed bootstrapping scripts to exit without closing PowerShell
- Fixed expansion for Unix environment variables
- Fixed separator for target parameters
- Fixed `ToolPathResolver` to resolve decidedly
- Fixed `GitVersionTasks` to resolve based on `GitVersion.CommandLine.DotNetCore` package
- Fixed `InjectionAttributeBase` to pass build instance
- Fixed `ReflectionService` to be public to allow usage in addons
- Fixed `DotNetTasks` to expose `restore` related parameters for `test`, `build`, `publish`, `pack`, `run`

## [0.12.0] / 2018-11-15
- Changed `NukeBuild` properties to be static
- Changed `NukeBuild.RootDirectory` to allow resolution from parameter
- Added package resolution for Paket
- Added shell-completion for global tool
- Added parameter resolution for `Enumeration` subclasses
- Added `PathExecutableAttribute` and `PackageExecutableAttribute` for `Tool` delegate resolution
- Added `PackPackageToolsTask` for global tool packaging
- Added `MSpecTasks`
- Fixed bootstrapping scripts to install by channel instead of latest version
- Fixed Glob package version to 0.3.2
- Fixed `Arguments` passing of `secret` parameter

## [0.11.1] / 2018-10-17
- Security: Updated YamlDotNet version

## [0.11.0] / 2018-10-11
- Removed deprecated APIs
- Added event methods `OnBuildCreated`, `OnBuildInitialized`, `OnBuildFinished`, `OnTargetStart`, `OnTargetAbsent`, `OnTargetSkipped`, `OnTargetExecuted` and `OnTargetFailed`

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
- Fixed `PathConstruction.GetRelativePath` to work with Unix paths
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

[vNext]: https://github.com/nuke-build/nuke/compare/6.0.0...HEAD
[6.0.0]: https://github.com/nuke-build/nuke/compare/5.3.0...6.0.0
[5.3.0]: https://github.com/nuke-build/nuke/compare/5.2.1...5.3.0
[5.2.1]: https://github.com/nuke-build/nuke/compare/5.2.0...5.2.1
[5.2.0]: https://github.com/nuke-build/nuke/compare/5.1.4...5.2.0
[5.1.4]: https://github.com/nuke-build/nuke/compare/5.1.3...5.1.4
[5.1.3]: https://github.com/nuke-build/nuke/compare/5.1.2...5.1.3
[5.1.2]: https://github.com/nuke-build/nuke/compare/5.1.1...5.1.2
[5.1.1]: https://github.com/nuke-build/nuke/compare/5.1.0...5.1.1
[5.1.0]: https://github.com/nuke-build/nuke/compare/5.0.2...5.1.0
[5.0.2]: https://github.com/nuke-build/nuke/compare/5.0.1...5.0.2
[5.0.1]: https://github.com/nuke-build/nuke/compare/5.0.0...5.0.1
[5.0.0]: https://github.com/nuke-build/nuke/compare/0.25.0...5.0.0
[0.25.0]: https://github.com/nuke-build/nuke/compare/0.24.11...0.25.0
[0.24.11]: https://github.com/nuke-build/nuke/compare/0.24.10...0.24.11
[0.24.10]: https://github.com/nuke-build/nuke/compare/0.24.9...0.24.10
[0.24.9]: https://github.com/nuke-build/nuke/compare/0.24.8...0.24.9
[0.24.8]: https://github.com/nuke-build/nuke/compare/0.24.7...0.24.8
[0.24.7]: https://github.com/nuke-build/nuke/compare/0.24.6...0.24.7
[0.24.6]: https://github.com/nuke-build/nuke/compare/0.24.5...0.24.6
[0.24.5]: https://github.com/nuke-build/nuke/compare/0.24.4...0.24.5
[0.24.4]: https://github.com/nuke-build/nuke/compare/0.24.2...0.24.4
[0.24.2]: https://github.com/nuke-build/nuke/compare/0.24.1...0.24.2
[0.24.1]: https://github.com/nuke-build/nuke/compare/0.24.0...0.24.1
[0.24.0]: https://github.com/nuke-build/nuke/compare/0.23.7...0.24.0
[0.23.7]: https://github.com/nuke-build/nuke/compare/0.23.6...0.23.7
[0.23.6]: https://github.com/nuke-build/nuke/compare/0.23.5...0.23.6
[0.23.5]: https://github.com/nuke-build/nuke/compare/0.23.4...0.23.5
[0.23.4]: https://github.com/nuke-build/nuke/compare/0.23.3...0.23.4
[0.23.3]: https://github.com/nuke-build/nuke/compare/0.23.2...0.23.3
[0.23.2]: https://github.com/nuke-build/nuke/compare/0.23.1...0.23.2
[0.23.1]: https://github.com/nuke-build/nuke/compare/0.23.0...0.23.1
[0.23.0]: https://github.com/nuke-build/nuke/compare/0.22.2...0.23.0
[0.22.2]: https://github.com/nuke-build/nuke/compare/0.22.1...0.22.2
[0.22.1]: https://github.com/nuke-build/nuke/compare/0.22.0...0.22.1
[0.22.0]: https://github.com/nuke-build/nuke/compare/0.21.2...0.22.0
[0.21.2]: https://github.com/nuke-build/nuke/compare/0.21.1...0.21.2
[0.21.1]: https://github.com/nuke-build/nuke/compare/0.21.0...0.21.1
[0.21.0]: https://github.com/nuke-build/nuke/compare/0.20.1...0.21.0
[0.20.1]: https://github.com/nuke-build/nuke/compare/0.20.0...0.20.1
[0.20.0]: https://github.com/nuke-build/nuke/compare/0.19.2...0.20.0
[0.19.2]: https://github.com/nuke-build/nuke/compare/0.19.1...0.19.2
[0.19.1]: https://github.com/nuke-build/nuke/compare/0.19.0...0.19.1
[0.19.0]: https://github.com/nuke-build/nuke/compare/0.18.0...0.19.0
[0.18.0]: https://github.com/nuke-build/nuke/compare/0.17.7...0.18.0
[0.17.7]: https://github.com/nuke-build/nuke/compare/0.17.6...0.17.7
[0.17.6]: https://github.com/nuke-build/nuke/compare/0.17.5...0.17.6
[0.17.5]: https://github.com/nuke-build/nuke/compare/0.17.4...0.17.5
[0.17.4]: https://github.com/nuke-build/nuke/compare/0.17.3...0.17.4
[0.17.3]: https://github.com/nuke-build/nuke/compare/0.17.2...0.17.3
[0.17.2]: https://github.com/nuke-build/nuke/compare/0.17.1...0.17.2
[0.17.1]: https://github.com/nuke-build/nuke/compare/0.17.0...0.17.1
[0.17.0]: https://github.com/nuke-build/nuke/compare/0.16.0...0.17.0
[0.16.0]: https://github.com/nuke-build/nuke/compare/0.15.0...0.16.0
[0.15.0]: https://github.com/nuke-build/nuke/compare/0.14.1...0.15.0
[0.14.1]: https://github.com/nuke-build/nuke/compare/0.14.0...0.14.1
[0.14.0]: https://github.com/nuke-build/nuke/compare/0.13.0...0.14.0
[0.13.0]: https://github.com/nuke-build/nuke/compare/0.12.4...0.13.0
[0.12.4]: https://github.com/nuke-build/nuke/compare/0.12.3...0.12.4
[0.12.3]: https://github.com/nuke-build/nuke/compare/0.12.2...0.12.3
[0.12.2]: https://github.com/nuke-build/nuke/compare/0.12.1...0.12.2
[0.12.1]: https://github.com/nuke-build/nuke/compare/0.12.0...0.12.1
[0.12.0]: https://github.com/nuke-build/nuke/compare/0.11.1...0.12.0
[0.11.1]: https://github.com/nuke-build/nuke/compare/0.11.0...0.11.1
[0.11.0]: https://github.com/nuke-build/nuke/compare/0.10.5...0.11.0
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

