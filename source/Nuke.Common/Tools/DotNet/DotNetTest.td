{
  "Reference": {
    "Url": "https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test",
    "HashCode": -1486743711,
    "XPath": ".//div[@class='content']"
  },
  "Help": "The <c>dotnet test</c> command is used to execute unit tests in a given project. Unit tests are console application projects that have dependencies on the unit test framework (for example, MSTest, NUnit, or xUnit) and the dotnet test runner for the unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.",
  "OfficialUrl": "https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run",
  "Alias": {
    "SkipAttributes": true,
    "TaskName": "DotNet",
    "MethodPostfix": "Test",
    "SettingsClass": "DotNetTestSettings",
    "OverloadArguments": []
  },
  "SettingsClass": {
    "Name": "DotNetTestSettings",
    "BaseClass": "DotNetSettings",
    "DefiniteArgument": "test",
    "Properties": [
      {
        "Name": "ProjectFile",
        "Type": "string",
        "Format": "{value}",
        "Help": "Specifies a path to the test project. If omitted, it defaults to current directory."
      },
      {
        "Name": "SettingsFile",
        "Type": "string",
        "Format": "--settings {value}",
        "Help": "Settings to use when running tests."
      },
      {
        "Name": "ListTests",
        "Type": "bool",
        "Format": "--list-tests",
        "Help": "List all of the discovered tests in the current project."
      },
      {
        "Name": "Filter",
        "Type": "string",
        "Format": "--filter {value}",
        "Help": "Filters out tests in the current project using the given expression. For more information, see the <a href=\"https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test#filter-option-details\">Filter option details</a> section. For additional information and examples on how to use selective unit test filtering, see <a href=\"https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests\">Running selective unit tests</a>."
      },
      {
        "Name": "TestAdapterPath",
        "Type": "string",
        "Format": "--test-adapter-path {value}",
        "Help": "Use the custom test adapters from the specified path in the test run."
      },
      {
        "Name": "Logger",
        "Type": "string",
        "Format": "--logger {value}",
        "Help": "Specifies a logger for test results."
      },
      {
        "Name": "Configuration",
        "Type": "string",
        "Format": "--configuration {value}",
        "Help": "Configuration under which to build. The default value is <c>Debug</c>, but your project's configuration could override this default SDK setting."
      },
      {
        "Name": "Framework",
        "Type": "string",
        "Format": "--framework {value}",
        "Help": "Looks for test binaries for a specific <a href=\"https://docs.microsoft.com/en-us/dotnet/standard/frameworks\">framework</a>."
      },
      {
        "Name": "Output",
        "Type": "string",
        "Format": "--output {value}",
        "Help": "Directory in which to find the binaries to run."
      },
      {
        "Name": "DiagnosticsFile",
        "Type": "string",
        "Format": "--diag {value}",
        "Help": "Enables diagnostic mode for the test platform and write diagnostic messages to the specified file."
      },
      {
        "Name": "NoBuild",
        "Type": "bool",
        "Format": "--no-build",
        "Help": "Does not build the test project prior to running it."
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
  "Enumerations": []
}