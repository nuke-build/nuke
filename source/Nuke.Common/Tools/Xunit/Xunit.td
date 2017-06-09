{
  "Reference": {
    "Url": "https://raw.githubusercontent.com/xunit/xunit/master/src/xunit.console/Program.cs",
    "HashCode": 862844435
  },
  "Help": "xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the <a href=\"https://www.dotnetfoundation.org/\">.NET Foundation</a>, and operates under their <a href=\"https://www.dotnetfoundation.org/code-of-conduct\">code of conduct</a>. It is licensed under <a href=\"https://opensource.org/licenses/Apache-2.0\">Apache 2</a> (an OSI approved license).",
  "OfficialUrl": "https://xunit.github.io",
  "Alias": {
    "IconClass": "bug2",
    "TaskName": "Xunit",
    "MethodPostfix": "2",
    "CustomAssertion": true,
    "SettingsClass": "XunitSettings",
    "OverloadArguments": []
  },
  "SettingsClass": {
    "PackageId": "xunit.runner.console",
    "Name": "XunitSettings",
    "Properties": [
      {
        "Name": "TargetAssemblyWithConfigs",
        "Type": "LookupTable<string, string>",
        "Format": "{value}",
        "KeyValueSeparator": " ",
        "Help": "Assemblies to test, and their related related configuration files (ending with .json or .config)."
      },
      {
        "Name": "OutputPath",
        "Type": "string",
        "Format": "{value}",
        "Help": "The report file output path."
      },
      {
        "Name": "Logo",
        "Type": "bool",
        "Format": "-nologo",
        "Negate": true,
        "Help": "Show the copyright message."
      },
      {
        "Name": "Color",
        "Type": "bool",
        "Format": "-nocolor",
        "Negate": true,
        "Help": "Output results with colors."
      },
      {
        "Name": "AppDomain",
        "Type": "bool",
        "Format": "-noappdomain",
        "Negate": true,
        "Help": "Use app domains to run test code."
      },
      {
        "Name": "FailSkips",
        "Type": "bool",
        "Format": "-failskips",
        "Help": "Convert skipped tests into failures."
      },
      {
        "Name": "Parallel",
        "Type": "ParallelOption?",
        "Format": "-parallel {value}",
        "Help": "Set parallelization based on option:<ul><li><b>none:</b> turn off all parallelization</li><li><b>collections:</b> only parallelize collections</li><li><b>assemblies:</b> only parallelize assemblies</li><li><b>all:</b> parallelize assemblies &amp; collections</li></ul>"
      },
      {
        "Name": "MaxThreads",
        "Type": "int?",
        "Format": "-maxthreads {value}",
        "Help": "Maximum thread count for collection parallelization:<br/><ul><li><b>default:</b> run with default (1 thread per CPU thread)</li><li><b>unlimited:</b> run with unbounded thread count</li><li><b>(number):</b> limit task thread pool size to 'count'</li></ul>"
      },
      {
        "Name": "ShadowCopying",
        "Type": "bool",
        "Format": "-noshadow",
        "Negate": true,
        "Help": "Shadow copy assemblies."
      },
      {
        "Name": "Wait",
        "Type": "bool",
        "Format": "-wait",
        "Help": "Wait for input after completion."
      },
      {
        "Name": "Diagnostics",
        "Type": "bool",
        "Format": "-diagnostics",
        "Help": "Enable diagnostics messages for all test assemblies."
      },
      {
        "Name": "Debug",
        "Type": "bool",
        "Format": "-debug",
        "Help": "Launch the debugger to debug the tests."
      },
      {
        "Name": "Serialization",
        "Type": "bool",
        "Format": "-serialize",
        "Help": "Serialize all test cases (for diagnostic purposes only)."
      },
      {
        "Name": "Traits",
        "Type": "LookupTable<string, string>",
        "Format": "-trait {value}",
        "KeyValueSeparator": "=",
        "Help": "Only run tests with matching name/value traits."
      },
      {
        "Name": "ExcludedTraits",
        "Type": "LookupTable<string, string>",
        "Format": "-notrait {value}",
        "KeyValueSeparator": "=",
        "Help": "Do not run tests with matching name/value traits."
      },
      {
        "Name": "Methods",
        "Type": "List<string>",
        "Format": "-method {value}",
        "Help": "Run a given test method (should be fully specified; i.e., 'MyNamespace.MyClass.MyTestMethod')."
      },
      {
        "Name": "Classes",
        "Type": "List<string>",
        "Format": "-class {value}",
        "Help": "Run all methods in a given test class (should be fully specified; i.e., 'MyNamespace.MyClass')."
      },
      {
        "Name": "Namespaces",
        "Type": "List<string>",
        "Format": "-namespace {value}",
        "Help": "Run all methods in a given namespace (i.e., 'MyNamespace.MySubNamespace')."
      },
      {
        "Name": "AutoReporters",
        "Type": "bool",
        "Format": "-noautoreporters",
        "Negate": true,
        "Help": "Allow reporters to be auto-enabled by environment for example, auto-detecting TeamCity or AppVeyor)."
      },
      {
        "Name": "Reporter",
        "Type": "ReporterType?",
        "Format": "-{value}",
        "Help": "Reporters:<ul><li><c>-appveyor</c>: forces AppVeyor CI mode (normally auto-detected)</li><li><c>-json</c>: show progress messages in JSON format</li><li><c>-quiet</c>: do not show progress messages</li><li><c>-teamcity</c>: forces TeamCity mode (normally auto-detected)</li><li><c>-verbose</c>: show verbose progress messages</li></ul>"
      },
      {
        "Name": "ResultFormat",
        "Type": "ResultFormat?",
        "Format": "-{value}",
        "Help": "Result formats:<ul><li><c>-xml</c>: output results to xUnit.net v2 XML file</li><li><c>-xmlv1</c>: output results to xUnit.net v1 XML file</li><li><c>-nunit</c>: output results to NUnit v2.5 XML file</li><li><c>-html</c>: output results to HTML file</li></ul>"
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": [
    {
      "Name": "ReporterType",
      "Values": [
        "AppVeyor",
        "JSON",
        "Quiet",
        "TeamCity",
        "Verbose"
      ]
    },
    {
      "Name": "ResultFormat",
      "Values": [
        "Xml",
        "XmlV1",
        "NUnit",
        "HTML"
      ]
    },
    {
      "Name": "ParallelOption",
      "Values": [
        "None",
        "Collections",
        "Assemblies",
        "All"
      ]
    }
  ]
}