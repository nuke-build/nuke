{
  "Reference": {
    "Url": "https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference",
    "HashCode": -18876796,
    "XPath": ".//table[12]"
  },
  "Help": "The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.",
  "OfficialUrl": "https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference",
  "Alias": {
    "SkipAttributes": true,
    "TaskName": "NuGet",
    "MethodPostfix": "Push",
    "SettingsClass": "NuGetPushSettings",
    "OverloadArguments": []
  },
  "SettingsClass": {
    "Name": "NuGetPushSettings",
    "BaseClass": "NuGetSettings",
    "DefiniteArgument": "push",
    "Properties": [
      {
        "Name": "TargetPath",
        "Type": "string",
        "Assertion": "File",
        "Format": "{value}",
        "Help": "Path of the package to push."
      },
      {
        "Name": "ApiKey",
        "Type": "string",
        "Format": "-ApiKey {value}",
        "Secret": true,
        "Help": "The API key for the target repository. If not present, the one specified in <i>%AppData%\\NuGet\\NuGet.Config</i> is used."
      },
      {
        "Name": "Source",
        "Type": "string",
        "Format": "-Source {value}",
        "Help": "Specifies the server URL. With NuGet 2.5+, NuGet will identify a UNC or local folder source and simply copy the file there instead of pushing it using HTTP. Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <i>NuGet.Config</i> file specifies a <i>DefaultPushSource</i> value."
      },
      {
        "Name": "SymbolSource",
        "Type": "string",
        "Format": "-SymbolSource {value}",
        "Help": "<i>(3.5+)</i> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org"
      },
      {
        "Name": "SymbolApiKey",
        "Type": "string",
        "Format": "-SymbolApiKey {value}",
        "Secret": true,
        "Help": "<i>(3.5+)</i> Specifies the API key for the URL specified in <c>-SymbolSource</c>."
      },
      {
        "Name": "Symbols",
        "Type": "bool",
        "Format": "-NoSymbols",
        "Negate": true,
        "Help": "<i>(3.5+)</i> If a symbols package exists, it will be pushed to a symbol server."
      },
      {
        "Name": "Buffering",
        "Type": "bool",
        "Format": "-DisableBuffering",
        "Negate": true,
        "Help": "Enables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work."
      },
      {
        "Name": "ConfigFile",
        "Type": "string",
        "Assertion": "FileOrNull",
        "Format": "-ConfigFile {value}",
        "Help": "<i>(2.5+)</i> The NuGet configuration file to apply. If not specified, <i>%AppData%\\NuGet\\NuGet.Config</i> is used."
      },
      {
        "Name": "Verbosity",
        "Type": "NuGetVerbosity?",
        "Format": "-Verbosity {value}",
        "Help": "<i>(2.5+)</i> Specifies the amount of details displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>."
      },
      {
        "Name": "ForceEnglishOutput",
        "Type": "bool",
        "Format": "-ForceEnglishOutput",
        "Help": "<i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture."
      },
      {
        "Name": "NonInteractive",
        "Type": "bool",
        "Format": "-NonInteractive",
        "Help": "Suppresses prompts for user input or confirmations."
      },
      {
        "Name": "Timeout",
        "Type": "int?",
        "Format": "-Timeout {value}",
        "Help": "Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes)."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": []
}