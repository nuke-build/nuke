<h1>Using SqlPackage Tool Wrapper</h1>

<h2>Overview</h2>

<p>The [SqlPackage](https://learn.microsoft.com/en-us/sql/tools/sqlpackage/sqlpackage) is a command-line utility that automates the following database development tasks by exposing some of the public Data-Tier Application Framework (DacFx) APIs. </p>

<p>This package wraps [SqlPackage Global .NET Tool](https://learn.microsoft.com/en-us/sql/tools/sqlpackage/sqlpackage-download) Nuget package into Nuke tasks</p>


<h2>Usage</h2>

Install SqlPackage Global tool into Nuke build project. 

    nuke :add-package Microsoft.SqlPackage --version <Version>

SqlPackage as a Nuke Task (SqlPackageTasks) uses Microsoft.SqlPackage location to find entry point executable. 
