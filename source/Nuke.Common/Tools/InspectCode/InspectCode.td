{
  "Reference": {
    "Url": "https://www.jetbrains.com/help/resharper/InspectCode.html",
    "HashCode": -1221302360,
    "XPath": ".//article[@class='article']"
  },
  "Help": "One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.",
  "OfficialUrl": "https://www.jetbrains.com/help/resharper/InspectCode.html/",
  "Alias": {
    "IconClass": "code",
    "TaskName": "InspectCode",
    "SettingsClass": "InspectCodeSettings",
    "OverloadArguments": [
      "TargetPath",
      "Output"
    ]
  },
  "SettingsClass": {
    "PackageId": "JetBrains.ReSharper.CommandLineTools",
    "Name": "InspectCodeSettings",
    "Properties": [
      {
        "Name": "TargetPath",
        "Type": "string",
        "Assertion": "File",
        "Format": "{value}",
        "Help": "Target path."
      },
      {
        "Name": "Output",
        "Type": "string",
        "Assertion": "NotNull",
        "Format": "--output={value}",
        "Help": "Lets you set the output file. By default, the output file is saved in the <i>%TEMP%</i> directory."
      },
      {
        "Name": "NoSwea",
        "Type": "bool",
        "Format": "--no-swea",
        "Help": "Disables solution-wide analysis."
      },
      {
        "Name": "Profile",
        "Type": "string",
        "Format": "--profile={value}",
        "Help": "Specifies an additional .DotSettings file used for inspection settings."
      },
      {
        "Name": "Project",
        "Type": "string",
        "Format": "--project={value}",
        "Help": "Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c>"
      },
      {
        "Name": "DisableSettingsLayers",
        "Type": "bool",
        "Format": "--disable-settings-layers={value}",
        "Help": "Disables specified <a href=\"https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers\">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>."
      },
      {
        "Name": "NoBuiltinSettings",
        "Type": "bool",
        "Format": "--no-buildin-settings",
        "Help": "Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c>"
      },
      {
        "Name": "CachesHome",
        "Type": "string",
        "Format": "--caches-home={value}",
        "Help": "Lets you specify a custom location for the data that InspectCode caches. By default, the <i>%LOCALAPPDATA%</i> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place."
      },
      {
        "Name": "Extensions",
        "Type": "List<string>",
        "Help": "Allows using ReSharper extensions that affect code analysis. To use an extension, specify its ID, which you can find by opening the extension package page in the <a href=\"http://resharper-plugins.jetbrains.com/\">ReSharper Gallery</a>, and then the Package Statistics page. Multiple values are separated with the semicolon."
      },
      {
        "Name": "Properties",
        "Type": "Dictionary<string, string>",
        "Format": "--properties={value}",
        "MainSeparator": ";",
        "KeyValueSeparator": "=",
        "Help": "Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters."
      },
      {
        "Name": "DumpIssuesTypes",
        "Type": "bool",
        "Format": "--dumpIssuesTypes",
        "Help": "Use this option to dump all existing <a href=\"https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html\">code inspections</a> to the <a href=\"https://www.jetbrains.com/help/resharper/InspectCode.html#output\">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument."
      },
      {
        "Name": "Toolset",
        "Type": "string",
        "Format": "--toolset={value}",
        "Help": "Explicitly specified MsBuild Toolset version (12.0, 14.0, 15.0). For example, <c>--toolset=12.0</c>."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": [
    {
      "Name": "SettingsLayers",
      "IsFlags": true,
      "Values": [
        "GlobalAll",
        "GlobalPerProduct",
        "SolutionShared",
        "SolutionPersonal"
      ]
    }
  ]
}