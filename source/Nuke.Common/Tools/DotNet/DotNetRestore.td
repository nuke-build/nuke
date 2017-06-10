{
  "Reference": {
    "Url": "https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore",
    "HashCode": -2126761269,
    "XPath": ".//div[@class='content']"
  },
  "Help": "<p>The <c>dotnet restore</c> command uses NuGet to restore dependencies as well as project-specific tools that are specified in the project file. By default, the restoration of dependencies and tools are performed in parallel.</p><p>In order to restore the dependencies, NuGet needs the feeds where the packages are located. Feeds are usually provided via the <i>NuGet.config</i> configuration file. A default configuration file is provided when the CLI tools are installed. You specify additional feeds by creating your own <i>NuGet.config</i> file in the project directory. You also specify additional feeds per invocation at a command prompt.</p><p>For dependencies, you specify where the restored packages are placed during the restore operation using the <c>--packages</c> argument. If not specified, the default NuGet package cache is used, which is found in the <c>.nuget/packages</c> directory in the user's home directory on all operating systems (for example, <i>/home/user1</i> on Linux or <i>C:\\Users\\user1</i> on Windows).</p><p>For project-specific tooling, <c>dotnet restore</c> first restores the package in which the tool is packed, and then proceeds to restore the tool's dependencies as specified in its project file.</p><p>The behavior of the <c>dotnet restore</c> command is affected by some of the settings in the <i>Nuget.Config</i> file, if present. For example, setting the <c>globalPackagesFolder</c> in <i>NuGet.Config</i> places the restored NuGet packages in the specified folder. This is an alternative to specifying the <c>--packages</c> option on the <c>dotnet restore</c> command. For more information, see the <a href=\"https://docs.microsoft.com/nuget/schema/nuget-config-file\">NuGet.Config reference</a>.</p>",
  "OfficialUrl": "https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore",
  "Alias": {
    "IconClass": "radio-checked2",
    "TaskName": "DotNet",
    "MethodPostfix": "Restore",
    "SettingsClass": "DotNetRestoreSettings",
    "OverloadArguments": [
      "ProjectFile"
    ]
  },
  "SettingsClass": {
    "Name": "DotNetRestoreSettings",
    "BaseClass": "DotNetSettings",
    "DefiniteArgument": "restore",
    "Properties": [
      {
        "Name": "ProjectFile",
        "Type": "string",
        "Format": "{value}",
        "Help": "Optional path to the project file to restore."
      },
      {
        "Name": "Source",
        "Type": "string",
        "Format": "--source {value}",
        "Help": "Specifies a NuGet package source to use during the restore operation. This overrides all of the sources specified in the <i>NuGet.config</i> file(s). Multiple sources can be provided by specifying this option multiple times."
      },
      {
        "Name": "Runtimes",
        "Type": "List<string>",
        "Format": "--runtime {value}",
        "Help": "Specifies a runtime for the package restore. This is used to restore packages for runtimes not explicitly listed in the <c>&lt;RuntimeIdentifiers&gt;</c> tag in the <i>.csproj</i> file. For a list of Runtime Identifiers (RIDs), see the <a href=\"https://docs.microsoft.com/en-us/dotnet/core/rid-catalog\">RID catalog</a>. Provide multiple RIDs by specifying this option multiple times."
      },
      {
        "Name": "PackageDirectory",
        "Type": "string",
        "Format": "--packages {value}",
        "Help": "Specifies the directory for restored packages."
      },
      {
        "Name": "DisableParallel",
        "Type": "bool",
        "Format": "--disable-parallel",
        "Help": "Disables restoring multiple projects in parallel."
      },
      {
        "Name": "NoCache",
        "Type": "bool",
        "Format": "--no-cache",
        "Help": "Specifies to not cache packages and HTTP requests."
      },
      {
        "Name": "ConfigFile",
        "Type": "string",
        "Format": "--configfile {value}",
        "Help": "The NuGet configuration file (<i>NuGet.config</i>) to use for the restore operation."
      },
      {
        "Name": "IgnoreFailedSources",
        "Type": "bool",
        "Format": "--ignore-failed-sources",
        "Help": "Only warn about failed sources if there are packages meeting the version requirement."
      },
      {
        "Name": "NoDependencies",
        "Type": "bool",
        "Format": "--no-dependencies",
        "Help": "When restoring a project with project-to-project (P2P) references, restore the root project and not the references."
      },
      {
        "Name": "Verbosity",
        "Type": "DotNetVerbosity?",
        "Format": "--verbosity {value}",
        "Help": "Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": [
    {
      "Name": "DotNetVerbosity",
      "Values": [
        "Quiet",
        "Minimal",
        "Normal",
        "Detailed",
        "Diagnostic"
      ]
    }
  ]
}