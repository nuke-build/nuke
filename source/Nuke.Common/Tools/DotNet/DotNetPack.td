{
  "Reference": {
    "Url": "https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-pack",
    "HashCode": 1143925995,
    "XPath": ".//div[@class='content']"
  },
  "Help": "<p>The <c>dotnet pack</c> command builds the project and creates NuGet packages. The result of this command is a NuGet package. If the <c>--include-symbols</c> option is present, another package containing the debug symbols is created.</p><p>NuGet dependencies of the packed project are added to the <i>.nuspec</i> file, so they're properly resolved when the package is installed. Project-to-project references aren't packaged inside the project. Currently, you must have a package per project if you have project-to-project dependencies.</p><p>By default, <c>dotnet pack</c> builds the project first. If you wish to avoid this behavior, pass the <c>--no-build</c> option. This is often useful in Continuous Integration (CI) build scenarios where you know the code was previously built.</p><p>You can provide MSBuild properties to the <c>dotnet pack</c> command for the packing process. For more information, see <a href=\"https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties\">NuGet metadata properties</a> and the <a href=\"https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference\">MSBuild Command-Line Reference</a>.</p>",
  "OfficialUrl": "https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-pack",
  "Alias": {
    "SkipAttributes": true,
    "TaskName": "DotNet",
    "MethodPostfix": "Pack",
    "SettingsClass": "DotNetPackSettings",
    "OverloadArguments": [
      "Project"
    ]
  },
  "SettingsClass": {
    "Name": "DotNetPackSettings",
    "BaseClass": "DotNetSettings",
    "DefiniteArgument": "pack",
    "Properties": [
      {
        "Name": "Project",
        "Type": "string",
        "Format": "{value}",
        "Help": "The project to pack. It's either a path to a csproj file or to a directory. If omitted, it defaults to the current directory."
      },
      {
        "Name": "OutputDirectory",
        "Type": "string",
        "Format": "--output {value}",
        "Help": "Places the built packages in the directory specified."
      },
      {
        "Name": "NoBuild",
        "Type": "bool",
        "Format": "--no-build",
        "Help": "Don't build the project before packing."
      },
      {
        "Name": "IncludeSymbols",
        "Type": "bool",
        "Format": "--include-symbols",
        "Help": "Generates the symbols <c>nupkg</c>."
      },
      {
        "Name": "IncludeSource",
        "Type": "bool",
        "Format": "--include-source",
        "Help": "Includes the source files in the NuGet package. The sources files are included in the <c>src</c> folder within the <c>nupkg</c>."
      },
      {
        "Name": "Configuration",
        "Type": "string",
        "Format": "--configuration {value}",
        "Help": "Configuration to use when building the project. If not specified, configuration defaults to <c>Debug</c>."
      },
      {
        "Name": "VersionSuffix",
        "Type": "string",
        "Format": "--version-suffix {value}",
        "Help": "Defines the value for the <c>$(VersionSuffix)</c> MSBuild property in the project."
      },
      {
        "Name": "Serviceable",
        "Type": "bool",
        "Format": "--serviceable",
        "Help": "Sets the serviceable flag in the package. For more information, see <a href=\"https://aka.ms/nupkgservicing\">.NET Blog: .NET 4.5.1 Supports Microsoft Security Updates for .NET NuGet Libraries</a>."
      },
      {
        "Name": "Verbostiy",
        "Type": "DotNetVerbosity",
        "Format": "--verbosity {value}",
        "Help": "Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": []
}