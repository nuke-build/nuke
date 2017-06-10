{
  "Reference": {
    "Url": "https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run",
    "HashCode": 1056187507,
    "XPath": ".//div[@class='content']"
  },
  "Help": "<p>The <c>dotnet run</c> command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the <a href=\"https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build\"><c>dotnet build</c></a> command to build the code. Any requirements for the build, such as that the project must be restored first, apply to <c>dotnet run</c> as well.</p><p>Output files are written into the default location, which is <c>bin/&lt;configuration&gt;/&lt;target&gt;</c>. For example if you have a <c>netcoreapp1.0</c> application and you run <c>dotnet run</c>, the output is placed in <c>bin/Debug/netcoreapp1.0</c>. Files are overwritten as needed. Temporary files are placed in the <c>obj</c> directory.</p><p>If the project specifies multiple frameworks, executing <c>dotnet run</c> results in an error unless the <c>-f|--framework &lt;FRAMEWORK&gt;</c> option is used to specify the framework.</p><p>The <c>dotnet run</c> command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use <a href=\"https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet\">dotnet</a> without a command. For example, to run <c>myapp.dll</c>, use: <c>dotnet myapp.dll</c></p><p>For more information on the <c>dotnet</c> driver, see the <a href=\"https://docs.microsoft.com/en-us/dotnet/core/tools/index\">.NET Core Command Line Tools (CLI)</a> topic.</p><p>In order to run the application, the <c>dotnet run</c> command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use <c>dotnet run</c> to run applications in production. Instead, <a href=\"https://docs.microsoft.com/en-us/dotnet/core/deploying/index\">create a deployment</a> using the <a href=\"https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish\"><c>dotnet publish</c></a> command and deploy the published output.</p>",
  "OfficialUrl": "https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run",
  "Alias": {
    "SkipAttributes": true,
    "TaskName": "DotNet",
    "MethodPostfix": "Run",
    "SettingsClass": "DotNetRunSettings",
    "OverloadArguments": []
  },
  "SettingsClass": {
    "Name": "DotNetRunSettings",
    "BaseClass": "DotNetSettings",
    "DefiniteArgument": "run",
    "Properties": [
      {
        "Name": "Configuration",
        "Type": "string",
        "Format": "--configuration {value}",
        "Help": "Configuration to use for building the project. The default value is Debug."
      },
      {
        "Name": "Framework",
        "Type": "string",
        "Format": "--framework {value}",
        "Help": "Builds and runs the app using the specified framework. The framework must be specified in the project file."
      },
      {
        "Name": "ProjectFile",
        "Type": "string",
        "Format": "--project {value}",
        "Help": "Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": []
}