{
  "Reference": {
    "Url": "https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference",
    "HashCode": -262611751,
    "XPath": ".//table[13]"
  },
  "Help": "The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.",
  "OfficialUrl": "https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference",
  "Alias": {
    "SkipAttributes": true,
    "TaskName": "NuGet",
    "MethodPostfix": "Restore",
    "SettingsClass": "NuGetRestoreSettings",
    "OverloadArguments": [
      "TargetPath"
    ]
  },
  "SettingsClass": {
    "Name": "NuGetRestoreSettings",
    "BaseClass": "NuGetSettings",
    "DefiniteArgument": "restore",
    "Properties": [
      {
        "Name": "TargetPath",
        "Type": "string",
        "Format": "{value}",
        "Help": "Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file."
      },
      {
        "Name": "ConfigFile",
        "Type": "string",
        "Format": "-ConfigFile {value}",
        "Help": "The NuGet configuration file to apply. If not specified, <i>%AppData%\\NuGet\\NuGet.Config</i> is used."
      },
      {
        "Name": "DirectDownload",
        "Type": "bool",
        "Format": "-DirectDownload",
        "Help": "<i>(4.0+)</i> Downloads packages directly without populating caches with any binaries or metadata."
      },
      {
        "Name": "ParallelProcessing",
        "Type": "bool",
        "Format": "-DisableParallelProcessing",
        "Negate": true,
        "Help": "Restore multiple packages in parallel."
      },
      {
        "Name": "FallbackSource",
        "Type": "List<string>",
        "Format": "-FallbackSource {value}",
        "MainSeparator": ";",
        "Help": "<i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source."
      },
      {
        "Name": "ForceEnglishOutput",
        "Type": "bool",
        "Format": "-ForceEnglishOutput",
        "Help": "<i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture."
      },
      {
        "Name": "MSBuildPath",
        "Type": "string",
        "Format": "-MSBuildPath {value}",
        "Help": "<i>(4.0+)</i> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>."
      },
      {
        "Name": "MSBuildVersion",
        "Type": "Nuke.Common.Tools.MSBuild.MSBuildVersion?",
        "Format": "-MSBuildVersion {value}",
        "Help": "<i>(3.2+)</i> Specifies the version of MSBuild to be used with this command. Supported values are <i>4</i>, <i>12</i>, <i>14</i>, <i>15</i>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild."
      },
      {
        "Name": "Cache",
        "Type": "bool",
        "Format": "-NoCache",
        "Negate": true,
        "Help": "Use packages from local machine caches."
      },
      {
        "Name": "NonInteractive",
        "Type": "bool",
        "Format": "-NonInteractive",
        "Help": "Suppresses prompts for user input or confirmations."
      },
      {
        "Name": "OutputDirectory",
        "Type": "string",
        "Format": "-OutputDirectory {value}",
        "Help": "Specifies the folder in which packages are installed. If no folder is specified, the current folder is used."
      },
      {
        "Name": "PackageSaveMode",
        "Type": "PackageSaveMode?",
        "Format": "-PackageSaveMode {value}",
        "CustomValue": true,
        "Help": "Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>."
      },
      {
        "Name": "PackagesDirectory",
        "Type": "string",
        "Format": "-PackagesDirectory {value}",
        "Help": "Same as <c>OutputDirectory</c>."
      },
      {
        "Name": "Project2ProjectTimeOut",
        "Type": "int?",
        "Format": "-Project2ProjectTimeOut {value}",
        "Help": "Timeout in seconds for resolving project-to-project references."
      },
      {
        "Name": "Recursive",
        "Type": "bool",
        "Format": "-Recursive",
        "Help": "<i>(4.0+)</i> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>."
      },
      {
        "Name": "RequireConsent",
        "Type": "bool",
        "Format": "-RequireConsent",
        "Help": "Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href=\"https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore\">Package Restore</a>."
      },
      {
        "Name": "SolutionDirectory",
        "Type": "string",
        "Format": "-SolutionDirectory {value}",
        "Help": "Specifies the solution folder. Not valid when restoring packages for a solution."
      },
      {
        "Name": "Source",
        "Type": "List<string>",
        "Format": "-Source {value}",
        "MainSeparator": ";",
        "Help": "Specifies list of package sources to use for the restore."
      },
      {
        "Name": "Verbosity",
        "Type": "NuGetVerbosity?",
        "Format": "-Verbosity {value}",
        "Help": "<i>(2.5+)</i> Specifies the amount of detail displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": [
    {
      "Name": "PackageSaveMode",
      "Values": [
        "Nuspec",
        "Nupkg",
        "NuspecAndNupkg"
      ]
    }
  ]
}