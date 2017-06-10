{
  "Reference": {
    "Url": "https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build",
    "HashCode": -2120219142,
    "XPath": ".//div[@class='content']"
  },
  "Help": "<p>The <c>dotnet build</c> command builds the project and its dependencies into a set of binaries. The binaries include the project's code in Intermediate Language (IL) files with a <i>.dll</i> extension and symbol files used for debugging with a <i>.pdb</i> extension. A dependencies JSON file (<i>.deps.json</i>) is produced that lists the dependencies of the application. A <i>.runtimeconfig.json</i> file is produced, which specifies the shared runtime and its version for the application.</p><p>If the project has third-party dependencies, such as libraries from NuGet, they're resolved from the NuGet cache and aren't available with the project's built output. With that in mind, the product of <c>dotnet build</c>d isn't ready to be transferred to another machine to run. This is in contrast to the behavior of the .NET Framework in which building an executable project (an application) produces output that's runnable on any machine where the .NET Framework is installed. To have a similar experience with .NET Core, you use the <a href=\"https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish\"><c>dotnet publish</c></a> command. For more information, see <a href=\"https://docs.microsoft.com/en-us/dotnet/core/deploying/index\">.NET Core Application Deployment</a>.</p><p>Building requires the <i>project.assets.json</i> file, which lists the dependencies of your application. The file is created when you execute <a href=\"https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore\"><c>dotnet restore</c></a> before building the project. Without the assets file in place, the tooling cannot resolve reference assemblies, which will result in errors.</p><p><c>dotnet build</c> uses MSBuild to build the project; thus, it supports both parallel and incremental builds. Refer to <a href=\"https://docs.microsoft.com/visualstudio/msbuild/incremental-builds\">Incremental Builds</a> for more information.</p><p>In addition to its options, the <c>dotnet build</c> command accepts MSBuild options, such as <c>/p</c> for setting properties or <c>/l</c> to define a logger. Learn more about these options in the <a href=\"https://docs.microsoft.com/visualstudio/msbuild/msbuild-command-line-reference\">MSBuild Command-Line Reference</a>.</p>",
  "OfficialUrl": "https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build",
  "Alias": {
    "SkipAttributes": true,
    "TaskName": "DotNet",
    "MethodPostfix": "Build",
    "SettingsClass": "DotNetBuildSettings",
    "OverloadArguments": [
      "ProjectFile"
    ]
  },
  "SettingsClass": {
    "Name": "DotNetBuildSettings",
    "BaseClass": "DotNetSettings",
    "DefiniteArgument": "build",
    "Properties": [
      {
        "Name": "ProjectFile",
        "Type": "string",
        "Format": "{value}",
        "Help": "The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file."
      },
      {
        "Name": "OutputDirectory",
        "Type": "string",
        "Format": "--output {value}",
        "Help": "Directory in which to place the built binaries. You also need to define <c>--framework</c> when you specify this option."
      },
      {
        "Name": "Framework",
        "Type": "string",
        "Format": "--framework {value}",
        "Help": "Compiles for a specific <a href=\"https://docs.microsoft.com/en-us/dotnet/standard/frameworks\">framework</a>. The framework must be defined in the <a href=\"https://docs.microsoft.com/en-us/dotnet/core/tools/csproj\">project file</a>."
      },
      {
        "Name": "Configuration",
        "Type": "string",
        "Format": "--configuration {value}",
        "Help": "Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration."
      },
      {
        "Name": "Runtime",
        "Type": "string",
        "Format": "--runtime {value}",
        "Help": "Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href=\"https://docs.microsoft.com/en-us/dotnet/core/rid-catalog\">RID catalog</a>."
      },
      {
        "Name": "VersionSuffix",
        "Type": "string",
        "Format": "--version-suffix {value}",
        "Help": "Defines the version suffix for an asterisk (<c>*</c>) in the version field of the project file. The format follows NuGet's version guidelines."
      },
      {
        "Name": "NoIncremental",
        "Type": "bool",
        "Format": "--no-incremental",
        "Help": "Marks the build as unsafe for incremental build. This turns off incremental compilation and forces a clean rebuild of the project's dependency graph."
      },
      {
        "Name": "NoDependencies",
        "Type": "bool",
        "Format": "--no-dependencies",
        "Help": "Ignores project-to-project (P2P) references and only builds the root project specified to build."
      },
      {
        "Name": "Verbosity",
        "Type": "DotNetVerbosity",
        "Format": "--verbosity {value}",
        "Help": "Sets the verbosity level of the command. Allowed values are <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": []
}