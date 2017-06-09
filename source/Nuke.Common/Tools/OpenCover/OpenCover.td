{
  "Reference": {
    "Url": "https://raw.githubusercontent.com/wiki/OpenCover/opencover/Usage.md",
    "HashCode": -381574320
  },
  "Help": "OpenCover is a code coverage tool for .NET 2 and above (Windows OSs only - no MONO), with support for 32 and 64 processes and covers both branch and sequence points.",
  "OfficialUrl": "https://github.com/OpenCover/opencover",
  "Alias": {
    "IconClass": "shield2",
    "TaskName": "OpenCover",
    "CustomStart": true,
    "SettingsClass": "OpenCoverSettings",
    "OverloadArguments": [
      "TestAction",
      "Output"
    ]
  },
  "SettingsClass": {
    "PackageId": "OpenCover",
    "PackageExecutable": "OpenCover.Console.exe",
    "Name": "OpenCoverSettings",
    "Properties": [
      {
        "Name": "TargetPath",
        "Type": "string",
        "Assertion": "File",
        "Format": "-target:{value}",
        "Help": "The name of the target application or service that will be started; this can also be a path to the target application."
      },
      {
        "Name": "TargetArguments",
        "Type": "string",
        "Format": "-targetargs:{value}",
        "Help": "Arguments to be passed to the target process."
      },
      {
        "Name": "TargetDirectory",
        "Type": "string",
        "Assertion": "DirectoryOrNull",
        "Format": "-targetdir:{value}",
        "Help": "The path to the target directory; if the target argument already contains a path then this argument can be used to provide an alternate path where PDB files may be found."
      },
      {
        "Name": "CoverByTests",
        "Type": "List<string>",
        "Format": "-coverbytest:{value}",
        "MainSeparator": ";",
        "Help": "Gather coverage by test by analyzing the assemblies that match these filters for Test methods. Currently only MSTest, XUnit, and NUnit tests are supported; other frameworks can be added on request - please raise support request on GitHub."
      },
      {
        "Name": "PerformanceCounters",
        "Type": "bool",
        "Format": "-enableperformancecounters",
        "Help": "<i>Administrator</i> privileges required. Allows the monitoring in <i>Performance Monitor</i> of the following values (they are usually cleared at the end of a performance run):<ul><li>messages remaining on the queue</li><li>number of messages processed</li></ul>"
      },
      {
        "Name": "ExcludeByAttributes",
        "Type": "List<string>",
        "Format": "-excludebyattribute:{value}",
        "MainSeparator": ";",
        "Help": "Exclude a class or method by filter(s) that match attributes that have been applied. An <c>*</c> can be used as a wildcard."
      },
      {
        "Name": "ExcludeByFile",
        "Type": "List<string>",
        "Format": "-excludebyfile:{value}",
        "MainSeparator": ";",
        "Help": "Exclude a class (or methods) by filter(s) that match the filenames. An <c>*</c> can be used as a wildcard."
      },
      {
        "Name": "ExcludeDirectories",
        "Type": "List<string>",
        "Format": "-excludedirs:{value}",
        "MainSeparator": ";",
        "Help": "Assemblies being loaded from these locations will be ignored."
      },
      {
        "Name": "Filters",
        "Type": "List<string>",
        "Format": "-filter:{value}",
        "MainSeparator": " ",
        "Help": "<p>A list of filters to apply to selectively include or exclude assemblies and classes from coverage results. Using PartCover syntax, where <c>(+|-)[Assembly-Filter]Type-Filter</c>. For example <c>+[Open*]*</c> includes all types in assemblies starting with <i>Open</i>, <c>-[*]Core.*</c> exclude all types in the <i>Core</i> namespace regardless of the assembly. If no filters are supplied then the default inclusive filter <c>+[*]*</c> is applied automatically. See Understanding Filters for more information.</p><ul><li>NOTE: Multiple filters can be applied by separating them with spaces and enclosing them with quotes: <c>-filter:\"+[*]* -[A*]Name.*\"</c></li><li>NOTE: Exclusion filters take precedence over inclusion filters.</li></ul>"
      },
      {
        "Name": "HideSkipped",
        "Type": "OpenCoverSkipping?",
        "Format": "-hideskipped:{value}",
        "Help": "Remove information from output file (-output:) that relates to classes/modules that have been skipped (filtered) due to the use of the switches <c>-excludebyfile</c>, <c>-excludebyattribute</c> and <c>-filter</c> or where the PDB is missing. Multiple arguments can be used by separating them with a semicolon, e.g. <c>-hideskipped:File;MissingPdb;Attribute</c>"
      },
      {
        "Name": "Verbosity",
        "Type": "OpenCoverVerbosity?",
        "Format": "-log:{value}",
        "Help": "Change the logging level, default is set to Info. Logging is based on log4net logging levels and appenders."
      },
      {
        "Name": "MergeByHash",
        "Type": "bool",
        "Format": "-mergebyhash",
        "Help": "Under some scenarios e.g. using MSTest, an assembly may be loaded many times from different locations. This option is used to merge the coverage results for an assembly regardless of where it was loaded assuming the assembly has the same file-hash in each location."
      },
      {
        "Name": "MergeOutput",
        "Type": "bool",
        "Format": "-mergeoutput",
        "Help": "Allow to merge the results with an existing file (specified by <c>-output</c> option). So the coverage from the output file will be loaded first (if exists)."
      },
      {
        "Name": "NoDefaultFilters",
        "Type": "bool",
        "Format": "-nodefaultfilters",
        "Help": "A list of default exclusion filters are usually applied, this option can be used to turn them off. The default filters are:<ul><li><c>-[System]*</c></li><li><c>-[System.*]*</c></li><li><c>-[mscorlib]*</c></li><li><c>-[mscorlib.*]*</c></li><li><c>-[Microsoft.VisualBasic]*</c></li></ul>"
      },
      {
        "Name": "OldStyle",
        "Type": "bool",
        "Format": "-oldStyle",
        "Help": "Use old style instrumentation - the instrumentation is not Silverlight friendly and is provided to support environments where mscorlib instrumentation is not working. <i>ONLY</i> use this option if you are encountering <see cref=\"MissingMethodException\"/> like errors when the code is run under OpenCover. The issue could be down to <i>ngen /Profile</i> of the mscorlib which then interferes with the instrumentation."
      },
      {
        "Name": "Output",
        "Type": "string",
        "Format": "-output:{value}",
        "Help": "The location and name of the output Xml file. If no value is supplied then the current directory will be used and the output filename will be <c>results.xml</c>."
      },
      {
        "Name": "SafeMode",
        "Type": "bool",
        "Format": "-safemode:{value}",
        "Help": "Enable or disable safemode - default is on/yes. When safemode is on OpenCover will use a common buffer for all threads in an instrumented process and this may have performance impacts depending on your code and its tests. Turning safemode off uses individual buffers for each thread but this may lead to data loss (uncovered code reported) if the runtime shuts down the instrumented process before the profiler has had time to retrieve the data and shunt it to the host for processing."
      },
      {
        "Name": "SearchDirectories",
        "Type": "List<string>",
        "Format": "-searchdirs:{value}",
        "MainSeparator": ";",
        "Help": "Alternative locations to look for PDBs."
      },
      {
        "Name": "Service",
        "Type": "bool",
        "Format": "-service",
        "Help": "The value provided in the target parameter is the name of a service rather than a name of a process. <i>Administrator</i> privileges recommended."
      },
      {
        "Name": "ShowUnvisited",
        "Type": "bool",
        "Format": "-showunvisited",
        "Help": "Show a list of unvisited methods and classes after the coverage run is finished and the results are presented."
      },
      {
        "Name": "SkipAutoProperties",
        "Type": "bool",
        "Format": "-skipautoprops",
        "Help": "Neither track nor record auto-implemented properties. That is, skip getters and setters like these: <c>public bool Service { get; set; }</c>"
      },
      {
        "Name": "MaximumVisitCount",
        "Type": "int?",
        "Format": "-threshold:{value}",
        "Help": "Limits the number of visit counts recorded/reported for an instrumentation point. May have some performance gains as it can reduce the number of messages sent from the profiler. Coverage results should not be affected but will have an obvious impact on the Visit Counts reported."
      },
      {
        "Name": "Registration",
        "Type": "RegistrationType?",
        "Format": "-register:{value}",
        "Help": "Use this switch to register and de-register the code coverage profiler. Alternatively use the optional user argument to do per-user registration where the user account does not have administrative permissions. Alternatively use an administrative account to register the profilers using the <i>regsvr32</i> utility. If you do not want to use the registry entries, use <c>-register:Path32</c> or <c>-register:Path64</c> to let opencover select the profiler for you. Depending on your choice it selects the <i>OpenCoverAssemblyLocation/x86/OpenCover.Profiler.dll</i> or <i>OpenCoverAssemblyLocation/x64/OpenCover.Profiler.dll</i>."
      },
      {
        "Name": "TargetExitCodeOffset",
        "Type": "int?",
        "Format": "-returntargetcode:{value}",
        "Help": "Return the target process exit code instead of the OpenCover console exit code. Use the offset to return the OpenCover console at a value outside the range returned by the target process."
      },
      {
        "Name": "TestAction",
        "Type": "Action",
        "Help": "The action that executes tests."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": [
    {
      "Name": "OpenCoverVerbosity",
      "Values": [
        "Off",
        "Fatal",
        "Error",
        "Warn",
        "Info",
        "Debug",
        "Verbose",
        "All"
      ]
    },
    {
      "Name": "OpenCoverSkipping",
      "IsFlags": true,
      "Values": [
        "File",
        "Filter",
        "Attribute",
        "MissingPdb",
        "All = File | Filter | Attribute | MissingPdb"
      ]
    },
    {
      "Name": "RegistrationType",
      "Values": [
        "User",
        "Path32",
        "Path64"
      ]
    }
  ]
}