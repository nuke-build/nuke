{
  "Reference": {
    "Url": "https://raw.githubusercontent.com/dotnet/docfx/dev/src/docfx/Models/BuildCommandOptions.cs",
    "HashCode": 1133038919
  },
  "Help": "DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <i>github.io</i>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href=\"http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html\">how to create custom template</a> to create custom templates.",
  "OfficialUrl": "https://dotnet.github.io/docfx/",
  "Alias": {
    "IconClass": "book",
    "TaskName": "DocFx",
    "MethodPostfix": "Build",
    "SettingsClass": "DocFxBuildSettings",
    "OverloadArguments": [
      "ConfigPath"
    ]
  },
  "SettingsClass": {
    "PackageId": "docfx.console",
    "PackageExecutable": "docfx.exe",
    "Name": "DocFxBuildSettings",
    "DefiniteArgument": "build",
    "Properties": [
      {
        "Name": "ConfigPath",
        "Type": "string",
        "Assertion": "FileOrNull",
        "Format": "{value}",
        "Help": "Path to the docfx.json configuration file."
      },
      {
        "Name": "Force",
        "Type": "bool",
        "Format": "--force",
        "Help": "Force re-generate all the metadata."
      },
      {
        "Name": "RepositoryRoot",
        "Type": "string",
        "Assertion": "DirectoryOrNull",
        "Format": "--repositoryRoot {value}",
        "Help": "Specify the GIT repository root folder."
      },
      {
        "Name": "Theme",
        "Type": "string",
        "Assertion": "DirectoryOrNull",
        "Format": "--theme {value}",
        "Help": "Specify which theme to use. By default 'default' theme is offered."
      },
      {
        "Name": "LogFile",
        "Type": "string",
        "Format": "--log {value}",
        "Help": "Specify the file name to save processing log."
      },
      {
        "Name": "LogLevel",
        "Type": "DocFxLogLevel?",
        "Format": "--logLevel {value}",
        "Help": "Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": []
}