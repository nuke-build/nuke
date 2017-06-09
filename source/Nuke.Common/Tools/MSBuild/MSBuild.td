{
  "Reference": {
    "Url": "https://msdn.microsoft.com/en-us/library/ms164311.aspx",
    "HashCode": 1581898612,
    "XPath": ".//div[@id='mainBody']"
  },
  "Help": "The Microsoft Build Engine is a platform for building applications. This engine, which is also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but it doesn't depend on Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed. Visual Studio uses MSBuild to load and build managed projects. The project files in Visual Studio (.csproj,.vbproj, vcxproj, and others) contain MSBuild XML code that executes when you build a project by using the IDE. Visual Studio projects import all the necessary settings and build processes to do typical development work, but you can extend or modify them from within Visual Studio or by using an XML editor.",
  "OfficialUrl": "https://msdn.microsoft.com/en-us/library/ms164311.aspx",
  "Alias": {
    "IconClass": "download2",
    "TaskName": "MSBuild",
    "SettingsClass": "MSBuildSettings",
    "OverloadArguments": [
      "TargetPath"
    ]
  },
  "SettingsClass": {
    "CustomExecutable": "MSBuildToolPathResolver.Resolve(MSBuildVersion, MSBuildPlatform)",
    "Name": "MSBuildSettings",
    "Properties": [
      {
        "Name": "TargetPath",
        "Type": "string",
        "Assertion": "FileOrNull",
        "Format": "{value}",
        "Help": "The solution or project file on which MSBuild is executed."
      },
      {
        "Name": "DetailedSummary",
        "Type": "bool",
        "Format": "/detailedsummary",
        "Help": "Show detailed information at the end of the build log about the configurations that were built and how they were scheduled to nodes."
      },
      {
        "Name": "MaxCpuCount",
        "Type": "int?",
        "Format": "/maxcpucount:{value}",
        "Help": "<p>Specifies the maximum number of concurrent processes to use when building. If you don't include this switch, the default value is 1. If you include this switch without specifying a value, MSBuild will use up to the number of processors in the computer. For more information, see <a href=\"https://msdn.microsoft.com/en-us/library/bb651793.aspx\">Building Multiple Projects in Parallel</a>.</p><p>The following example instructs MSBuild to build using three MSBuild processes, which allows three projects to build at the same time:</p><p><c>msbuild myproject.proj /maxcpucount:3</c></p>"
      },
      {
        "Name": "NodeReuse",
        "Type": "bool?",
        "Format": "/nodeReuse:{value}",
        "Help": "<p>Enable or disable the re-use of MSBuild nodes. You can specify the following values: <ul><li><c>true</c>: Nodes remain after the build finishes so that subsequent builds can use them (default).</li><li><c>false</c>. Nodes don't remain after the build completes.</li></ul></p><p>A node corresponds to a project that's executing. If you include the <c>/maxcpucount</c> switch, multiple nodes can execute concurrently.</p>"
      },
      {
        "Name": "Logo",
        "Type": "bool",
        "Format": "/nologo",
        "Negate": true,
        "Help": "Display the startup banner or the copyright message."
      },
      {
        "Name": "Properties",
        "Type": "Dictionary<string, string>",
        "Format": "/property:{value}",
        "KeyValueSeparator": "=",
        "Help": "<p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\\Debug</c></p>"
      },
      {
        "Name": "Targets",
        "Type": "List<string>",
        "Format": "/target:{value}",
        "MainSeparator": ";",
        "Help": "<p>Build the specified targets in the project. Specify each target separately, or use a semicolon or comma to separate multiple targets, as the following example shows:<br/><c>/target:Resources;Compile</c></p><p>If you specify any targets by using this switch, they are run instead of any targets in the DefaultTargets attribute in the project file. For more information, see <a href=\"https://msdn.microsoft.com/en-us/library/ee216359.aspx\">Target Build Order</a> and <a href=\"https://msdn.microsoft.com/en-us/library/ms171463.aspx\">How to: Specify Which Target to Build First</a>.</p><p>A target is a group of tasks. For more information, see <a href=\"https://msdn.microsoft.com/en-us/library/ms171462.aspx\">Targets</a>.</p>"
      },
      {
        "Name": "ToolsVersion",
        "Type": "MSBuildToolsVersion?",
        "Format": "/toolsversion:{value}",
        "CustomValue": true,
        "Help": "<p>Specifies the version of the Toolset to use to build the project, as the following example shows: <c>/toolsversion:3.5</c></p><p>By using this switch, you can build a project and specify a version that differs from the version that's specified in the <a href=\"https://msdn.microsoft.com/en-us/library/bcxfsh87.aspx\">Project Element (MSBuild)</a>. For more information, see <a href=\"https://msdn.microsoft.com/en-us/library/bb383985.aspx\">Overriding ToolsVersion Settings</a>.</p><p>For MSBuild 4.5, you can specify the following values for version: 2.0, 3.5, and 4.0. If you specify 4.0, the VisualStudioVersion build property specifies which sub-toolset to use. For more information, see the Sub-toolsets section of <a href=\"https://msdn.microsoft.com/en-us/library/bb383796.aspx\">Toolset (ToolsVersion)</a>.</p><p>A Toolset consists of tasks, targets, and tools that are used to build an application. The tools include compilers such as csc.exe and vbc.exe. For more information about Toolsets, see <a href=\"https://msdn.microsoft.com/en-us/library/bb383796.aspx\">Toolset (ToolsVersion)</a>, <a href=\"https://msdn.microsoft.com/en-us/library/bb397428.aspx\">Standard and Custom Toolset Configurations</a>, and <a href=\"https://msdn.microsoft.com/en-us/library/hh264223.aspx\">Multitargeting</a>. Note: The toolset version isn't the same as the target framework, which is the version of the .NET Framework on which a project is built to run. For more information, see <a href=\"https://msdn.microsoft.com/en-us/library/hh264221.aspx\">Target Framework and Target Platform</a>.</p>"
      },
      {
        "Name": "MSBuildVersion",
        "Type": "MSBuildVersion?",
        "Help": "Specifies the version of MSBuild for building."
      },
      {
        "Name": "Verbosity",
        "Type": "MSBuildVerbosity?",
        "Format": "/verbosity:{value}",
        "Help": "<p>Specifies the amount of information to display in the build log. Each logger displays events based on the verbosity level that you set for that logger.</p><p>You can specify the following verbosity levels: <c>q[uiet]</c>, <c>m[inimal]</c>, <c>n[ormal]</c>, <c>d[etailed]</c>, and <c>diag[nostic]</c>.</p><p>The following setting is an example: <c>/verbosity:quiet</c></p>"
      },
      {
        "Name": "MSBuildPlatform",
        "Type": "MSBuildPlatform?",
        "Help": "Specifies the platform to use when building."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": [
    {
      "Name": "MSBuildToolsVersion",
      "Values": [
        "_15_0",
        "_14_0",
        "_12_0"
      ]
    },
    {
      "Name": "MSBuildVerbosity",
      "Values": [
        "Quiet",
        "Minimal",
        "Normal",
        "Detailed",
        "Diagnostic"
      ]
    },
    {
      "Name": "TargetPlatform",
      "Values": [
        "MSIL",
        "x86",
        "x64",
        "arm",
        "Win32"
      ]
    }
  ]
}