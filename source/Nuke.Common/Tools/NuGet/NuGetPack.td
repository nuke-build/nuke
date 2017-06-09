{
  "Reference": {
    "Url": "https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference",
    "HashCode": -1234028507,
    "XPath": ".//table[11]"
  },
  "Help": "The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.",
  "OfficialUrl": "https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference",
  "Alias": {
    "IconClass": "box",
    "TaskName": "NuGet",
    "MethodPostfix": "Pack",
    "SettingsClass": "NuGetPackSettings",
    "OverloadArguments": [
      "TargetPath",
      "Version"
    ]
  },
  "SettingsClass": {
    "Name": "NuGetPackSettings",
    "BaseClass": "NuGetSettings",
    "DefiniteArgument": "pack",
    "Properties": [
      {
        "Name": "TargetPath",
        "Type": "string",
        "Assertion": "File",
        "Format": "{value}",
        "Help": "The <c>.nuspec</c> or <c>.csproj</c> file."
      },
      {
        "Name": "BasePath",
        "Type": "string",
        "Assertion": "Directory",
        "Format": "-BasePath {value}",
        "Help": "Sets the base path of the files defined in the <c>.nuspec</c> file."
      },
      {
        "Name": "Build",
        "Type": "bool",
        "Format": "-Build",
        "Help": "Specifies that the project should be built before building the package."
      },
      {
        "Name": "Exclude",
        "Type": "string",
        "Format": "-Exclude {value}",
        "Help": "Specifies one or more wildcard patterns to exclude when creating a package."
      },
      {
        "Name": "ExcludeEmptyDirectories",
        "Type": "bool",
        "Format": "-ExcludeEmptyDirectories",
        "Help": "Prevent inclusion of empty directories when building the package."
      },
      {
        "Name": "IncludeReferencedProjects",
        "Type": "bool",
        "Format": "-IncludeReferencedProjects",
        "Help": "Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package."
      },
      {
        "Name": "MinClientVersion",
        "Type": "bool",
        "Format": "-MinClientVersion",
        "Help": "Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file."
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
        "CustomValue": true,
        "Help": "<i>(3.2+)</i> Specifies the version of MSBuild to be used with this command. Supported values are <i>4</i>, <i>12</i>, <i>14</i>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild."
      },
      {
        "Name": "NoDefaultExcludes",
        "Type": "bool",
        "Format": "-NoDefaultExcludes",
        "Help": "Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>."
      },
      {
        "Name": "NoPackageAnalysis",
        "Type": "bool",
        "Format": "-NoPackageAnalysis",
        "Help": "Specifies that pack should not run package analysis after building the package."
      },
      {
        "Name": "OutputDirectory",
        "Type": "string",
        "Format": "-OutputDirectory {value}",
        "Help": "Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used."
      },
      {
        "Name": "Properties",
        "Type": "Dictionary<string, string>",
        "Format": "-Properties {value}",
        "CustomValue": true,
        "Help": "Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks."
      },
      {
        "Name": "Suffix",
        "Type": "string",
        "Format": "-Suffix {value}",
        "Help": "<i>(3.4.4+)</i> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager."
      },
      {
        "Name": "Symbols",
        "Type": "bool",
        "Format": "-Symbols",
        "Help": "Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package."
      },
      {
        "Name": "Tool",
        "Type": "bool",
        "Format": "-Tool",
        "Help": "Specifies that the output files of the project should be placed in the <c>tool</c> folder."
      },
      {
        "Name": "Verbosity",
        "Type": "NuGetVerbosity?",
        "Format": "-Verbosity {value}",
        "Help": "<i>(2.5+)</i> Specifies the amount of details displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>."
      },
      {
        "Name": "Version",
        "Type": "string",
        "Format": "-Version {value}",
        "Help": "Overrides the version number from the <c>.nuspec</c> file."
      },
      {
        "Name": "Configuration",
        "Type": "string"
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": [
    {
      "Name": "NuGetVerbosity",
      "Values": [
        "Normal",
        "Quiet",
        "Detailed"
      ]
    }
  ]
}