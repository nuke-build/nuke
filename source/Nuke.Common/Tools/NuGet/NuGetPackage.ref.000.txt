---
# required metadata

title: .nuspec File Reference for NuGet | Microsoft Docs
author: kraigb
ms.author: kraigb
manager: ghogen
ms.date: 7/25/2017
ms.topic: reference
ms.prod: nuget
#ms.service:
ms.technology: null
ms.assetid: d4a4db9b-5c2d-46aa-9107-d2b01733df7c

# optional metadata

description: The .nuspec file contains package metadata used when building a package and to provide information to package consumers.
keywords: nuspec reference, NuGet package metadata, NuGet package manifest, nuspec schema
#ROBOTS:
#audience:
#ms.devlang:
ms.reviewer:
- anangaur
- karann
- unnir
#ms.suite:
#ms.tgt_pltfrm:
#ms.custom:
---

# .nuspec reference

A `.nuspec` file is an XML manifest that contains package metadata. This manifest is used both to build the package and to provide information to consumers. The manifest is always included in a package.

In this topic:

- [General form and schema](#general-form-and-schema)
- [Replacement tokens](#replacement-tokens) (when used with a Visual Studio project)
- [Dependencies](#dependencies)
- [Explicit assembly references](#explicit-assembly-references)
- [Framework assembly references](#framework-assembly-references)
- [Including assembly files](#including-assembly-files)
- [Including content files](#including-content-files)
- [Examples](#examples)

## General form and schema

The current `nuspec.xsd` schema file can be found in the [NuGet GitHub repository](https://github.com/NuGet/NuGet.Client/blob/dev/src/NuGet.Core/NuGet.Packaging/compiler/resources/nuspec.xsd).

Within this schema, a `.nuspec` file has the following general form:

```xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
    <metadata>
        <!-- Required elements-->
        <id></id>
        <version></version>
        <description></description>
        <authors></authors>

        <!-- Optional elements -->
        <!-- ... -->
    </metadata>
    <!-- Optional 'files' node -->
</package>
```

For a clear visual representation of the schema, open the schema file in Visual Studio in Design mode and click on the **XML Schema Explorer** link. Alternately, open the file as code, right-click in the editor, and select **Show XML Schema Explorer**. Either way you get a view like the one below (when mostly expanded):

![Visual Studio Schema Explorer with nuspec.xsd open](media/SchemaExplorer.png)

### Required metadata elements

Although the following elements are the minimum requirements for a package, you should consider adding the [optional metadata elements](#optional-metadata-elements) to improve the overall experience developers have with your package.

These elements must appear within a `<metadata>` element.

| Element | Description |
| --- | --- |
| **id** | The case-insensitive package identifier, which must be unique across nuget.org or whatever gallery the package resides in. IDs may not contain spaces or characters that are not valid for a URL, and generally follow .NET namespace rules. See [Choosing a unique package identifier](../create-packages/creating-a-package.md#choosing-a-unique-package-identifier-and-setting-the-version-number) for guidance. |
| **version** | The version of the package, following the *major.minor.patch* pattern. Version numbers may include a pre-release suffix as described in [Package versioning](../reference/package-versioning.md#pre-release-versions). |
| **description** | A long description of the package for UI display. |
| **authors** | A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors. |

### Optional metadata elements

These elements must appear within a `<metadata>` element.

#### Single elements

| Element | Description |
| --- | --- |
| **title** | A human-friendly title of the package, typically used in UI displays as on nuget.org and the Package Manager in Visual Studio. If not specified, the package ID is used. |
| **owners** | A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in *authors*, and is ignored when uploading the package to nuget.org. See [Managing package owners on nuget.org](../create-packages/publish-a-package.md#managing-package-owners-on-nugetorg). |
| **projectUrl** | A URL for the package's home page, often shown in UI displays as well as nuget.org. |
| **licenseUrl** | A URL for the package's license, often shown in UI displays as well as nuget.org. |
| **iconUrl** | A URL for a 64x64 image with transparency background to use as the icon for the package in UI display. Be sure this element contains the *direct image URL* and not the URL of a web page containing the image. For example, to use an image from GitHub, use the raw file URL like `https://github.com/<username\>/<repsitory>/raw/<branch>/<logo.png>`. |
| **requireLicenseAcceptance** | A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package. |
| **developmentDependency** | *(2.8+)*  A Boolean value specifying whether the package is be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages. |
| **summary** | A short description of the package for UI display. If omitted, a truncated version of **description** is used. |
| **releaseNotes** | *(1.5+)* A description of the changes made in this release of the package, often used in UI like the **Updates** tab of the Visual Studio Package Manager in place of the package description. |
| **copyright** | *(1.5+)* Copyright details for the package. |
| **language** | The locale ID for the package. See [Creating localized packages](../create-packages/creating-localized-packages.md). |
| **tags** | A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering. |
| **serviceable** | *(3.3+)*For internal NuGet use only. |
| **minClientVersion** | *(2.5+)*  Specifies the minimum version of the NuGet client that can install this package, enforced by nuget.exe and the Visual Studio Package Manager. This is used whenever the package depends on specific features of the `.nuspec` file that were added in a particular version of the NuGet client. For example, a package using the `developmentDependency` attribute should specify "2.8" for `minClientVersion`. Similarly, a package using the `contentFiles` element (see the next section) should set `minClientVersion` to "3.3". Note also that because NuGet clients prior to 2.5 do not recognize this flag, they *always* refuse to install the package no matter what `minClientVersion` contains. |

#### Collection elements

| Element | Description |
| --- | --- |
**packageTypes** | *(3.3+)* A collection of zero or more `<packageType>` elements specifying the type of the package if other than a traditional dependency package. Each packageType has attributes of *name* and *version*. See [Setting a package type](../create-packages/creating-a-package.md#setting-a-package-type). |
| **dependencies** | A collection of zero or more `<dependency>` elements specifying the dependencies for the package. Each dependency has attributes of *id*, *version*, *include* (3.x+), and *exclude* (3.x+). See [Dependencies](#dependencies) below. |
| **frameworkAssemblies** | *(1.2+)* A collection of zero or more `<frameworkAssembly>` elements identifying .NET Framework assembly references that this package requires, which ensures that references are added to projects consuming the package. Each frameworkAssembly has *assemblyName* and *targetFramework* attributes. See [Specifying framework assembly references GAC](#specifying-framework-assembly-references-gac) below. |
| **references** | *(1.5+)* A collection of zero or more `<reference>` elements naming assemblies in the package's `lib` folder that are added as project references. Each reference has a *file* attribute. `<references>` can also contain a `<group>` element with a *targetFramework* attribute, that then contains `<reference>` elements. If omitted, all references in `lib` are included. See [Specifying explicit assembly references](#specifying-explicit-assembly-references) below. |
| **contentFiles** | *(3.3+)* A collection of `<files>` elements that identify content files to include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See [Specifying files to include in the package](#specifying-files-to-include-in-the-package) below. |

### Files element

The `<package>` node may contain a `<files>` or `<contentFiles>` node as siblings to `<metadata>` to specify which assembly and content files to include in the package. See [Including assembly files](#including-assembly-files) and [Including content files](#including-content-files) later in this topic for details.

## Replacement tokens

When creating a package, the [`nuget pack` command](../tools/nuget-exe-cli-reference.md#pack) replaces $-delimited tokens in the `.nuspec` file's `<metadata>` node with values that come from either a project file or the `pack` command's `-properties` switch.

On the command line, you specify token values with `nuget pack -properties <name>=<value>;<name>=<value>`. For example, you can use a token such as `$owners$` and `$desc$` in the `.nuspec` and provide the values at packing time as follows:

```
nuget pack MyProject.csproj -properties
    owners=janedoe,harikm,kimo,xiaop;desc="Awesome app logger utility"
```

To use values from a project, specify the tokens described in the table below (AssemblyInfo refers to the file in `Properties` such as `AssemblyInfo.cs` or `AssemblyInfo.vb`).

To use these tokens, run `nuget pack` with the project file rather than just the `.nuspec`. For example, when using the following command, the `$id$` and `$version$` tokens in a `.nuspec` file are replaced with the project's `AssemblyName` and `AssemblyVersion` values:

```
nuget pack MyProject.csproj
```

Typically, when you have a project, you create the `.nuspec` initially using `nuget spec MyProject.csproj` which automatically includes some of these standard tokens. However, if a project lacks values for required `.nuspec` elements, then `nuget pack` fails. Furthermore, if you change project values, be sure to rebuild before creating the package; this can be done conveniently with the pack command's `build` switch.

With the exception of `$configuration$`, values in the project are used in preference to any assigned to the same token on the command line.

| Token | Value source | Value
| --- | --- | ---
| **$id$** | Project file | AssemblyName from the project file |
| **$version$** | AssemblyInfo | AssemblyInformationalVersion if present, otherwise AssemblyVersion |
| **$author$** | AssemblyInfo | AssemblyCompany |
| **$description$** | AssemblyInfo | AssemblyDescription |
| **$copyright$** | AssemblyInfo | AssemblyCopyright |
| **$configuration$** | Assembly DLL | Configuration used to build the assembly, defaulting to Debug. Note that to create a package using a Release configuration, you always use `-properties Configuration=Release` on the command line. |

Tokens can also be used to resolve paths when you include [assembly files](#including-assembly-files) and [content files](#including-content-files). The tokens have the same names as the MSBuild properties, making it possible to select files to be included depending on the current build configuration. For example, if you use the following tokens in the `.nuspec` file:

```xml
<files>
    <file src="bin\$configuration$\$id$.pdb" target="lib\net40\" />
</files>
```

And you build an assembly whose `AssemblyName` is `LoggingLibrary` with the `Release` configuration in MSBuild, the resulting lines in the `.nuspec` file in the package is as follows:

```xml
<files>
    <file src="bin\Release\LoggingLibrary.pdb" target="lib\net40" />
</files>
```

## Dependencies

The `<dependencies>` element within `<metadata>` contains any number of `<dependency>` elements that identify other packages upon which the top-level package depends. The attributes for each `<dependency>` are as follows:

| Attribute | Description |
| --- | --- | 
| `id` | (Required) The package ID of the dependency. |
| `version` | (Required) The range of versions acceptable as a dependency. See [Package versioning](../reference/package-versioning.md#version-ranges-and-wildcards) for exact syntax. |

For example, the following lines indicate dependencies on `PackageA` version 1.1.0 or higher, and `PackageB` version 1.x.

```xml
<dependencies>
    <dependency id="PackageA" version="1.1.0" />
    <dependency id="PackageB" version="[1,2)" />
</dependencies>
```

When creating a `.nuspec` from a project using `nuget spec`, dependencies that exist in that project are automatically included in the resulting `.nuspec` file.

### Dependency groups

*Version 2.0+*

As an alternative to a single flat list, dependencies can be specified according to the framework profile of the target project using `<group>` elements within `<dependencies>`.

Each group has an attribute named `targetFramework` and contains zero or more `<dependency>` elements. Those dependencies are installed together when  the target framework is compatible with the project's framework profile.

The `<group>` element without a `targetFramework` attribute is used as the default or fallback list of dependencies. See [Target frameworks](../schema/target-frameworks.md) for the exact framework identifiers.

> [!Important]
> The group format cannot be intermixed with a flat list.

The following example shows different variations of the `<group>` element:

```xml
<dependencies>
    <group>
        <dependency id="RouteMagic" version="1.1.0" />
    </group>

    <group targetFramework="net40">
        <dependency id="jQuery" />
        <dependency id="WebActivator" />
    </group>

    <group targetFramework="sl30">
    </group>
</dependencies>
```

<a name="specifying-explicit-assembly-references"></a>

## Explicit assembly references

The `<references>` element explicitly specifies the assemblies that the target project should reference when using the package. When this element is present, NuGet add references to only the listed assemblies; it does not add references for any other assemblies in the package's `lib` folder.

For example, the following `<references>` element instructs NuGet to add references to only `xunit.dll` and `xunit.extensions.dll` even if there are additional assemblies in the package:

```xml
<references>
    <reference file="xunit.dll" />
    <reference file="xunit.extensions.dll" />
</references>
```

Explicit references are typically used for design-time only assemblies. When using [Code Contracts](https://docs.microsoft.com/dotnet/framework/debug-trace-profile/code-contracts), for example, contract assemblies need to be next to the runtime assemblies that they augment so that Visual Studio can find them, but the contract assemblies need not be referenced by the project or copied into the project's `bin` folder.

Similarly, explicit references can be used for unit test frameworks, such as XUnit, which needs its tools assemblies located next to the runtime assemblies, but does not need them included as project references.

### Reference groups

*Version 2.5+*

As an alternative to a single flat list, references can be specified according to the framework profile of the target project using `<group>` elements within `<references>`.

Each group has an attribute named `targetFramework` and contains zero or more `<reference>` elements. Those references are added to a project when the target framework is compatible with the project's framework profile.

The `<group>` element without a `targetFramework` attribute is used as the default or fallback list of references. See [Target frameworks](../schema/target-frameworks.md) for the exact framework identifiers.

> [!Important]
> The group format cannot be intermixed with a flat list.

The following example shows different variations of the `<group>` element:

```xml
<references>
    <group>
    <reference file="a.dll" />
    </group>

    <group targetFramework="net45">
        <reference file="b45.dll" />
    </group>

    <group targetFramework="netcore45">
    <reference file="bcore45.dll" />
    </group>
</references>
```

<a name="specifying-framework-assembly-references-gac"></a>

## Framework assembly references

Framework assemblies are those that are part of the .NET framework and should already be in the global assembly cache (GAC) for any given machine. By identifying those assemblies within the `<frameworkAssemblies>` element, a package can ensure that required references are added to a project in the event that the project doesn't have such references already. Such assemblies, of course, are not included in a package directly.

The `<frameworkAssemblies>` element contains zero or more `<frameworkAssembly>` elements, each of which specifies the following attributes:

| Attribute | Description |
| --- | --- |
| **assemblyName** | (Required) The fully qualified assembly name. |
| **targetFramework** | (Optional) Specifies the target framework to which this reference applies. If omitted, indicates that the reference applies to all frameworks. See [Target frameworks](../schema/target-frameworks.md) for the exact framework identifiers. |

The following example shows a reference to `System.Net` for all target frameworks, and a reference to `System.ServiceModel` for .NET Framework 4.0 only:

```xml
<frameworkAssemblies>
    <frameworkAssembly assemblyName="System.Net"  />

    <frameworkAssembly assemblyName="System.ServiceModel" targetFramework="net40" />
</frameworkAssemblies>
```

<a name="specifying-files-to-include-in-the-package"></a>

## Including assembly files

If you follow the conventions described in [Creating a Package](../create-packages/creating-a-package.md), you do not have to explicitly specify a list of files in the `.nuspec` file. The `nuget pack` command automatically picks up the necessary files.

> [!Important]
> When a package is installed into a project, NuGet automatically adds assembly references to the package's DLLs, *excluding* those that are named `.resources.dll` because they are assumed to be localized satellite assemblies. For this reason, avoid using `.resources.dll` for files that otherwise contain essential package code.

To bypass this automatic behavior and explicitly control which files are included in a package, place a `<files>` element as a child of `<package>` (and a sibling of `<metadata>`), identifying each file with a separate `<file>` element. For example:

```xml
<files>
    <file src="bin\Debug\*.dll" target="lib" />
    <file src="bin\Debug\*.pdb" target="lib" />
    <file src="tools\**\*.*" exclude="**\*.log" />
</files>
```

With NuGet 2.x and earlier, and projects using `packages.config`, the `<files>` element is also used to include immutable content files when a package is installed. With NuGet 3.3+ and projects using `project.json` pr PackageReference, the `<contentFiles>` element is used instead. See [Including content files](#including-content-files) below for details.

### File element attributes

Each `<file>` element specifies the following attributes:

| Attribute | Description |
| --- | --- |
| **src** | The location of the file or files to include, subject to exclusions specified by the `exclude` attribute. The path is relative to the `.nuspec` file unless an absolute path is specified. The wildcard character `*` is allowed, and the double wildcard `**` implies a recursive folder search. |
| **target** | The relative path to the folder within the package where the source files are placed, which must begin with `lib`, `content`, `build`, or `tools`. See [Creating a .nuspec from a convention-based working directory](../Create-Packages/Creating-a-Package.md#from-a-convention-based-working-directory). |
| **exclude** | A semicolon-delimited list of files or file patterns to exclude from the `src` location. The wildcard character `*` is allowed, and the double wildcard `**` implies a recursive folder search. |

### Examples

**Single assembly**

    Source file:
        library.dll

    .nuspec entry:
        <file src="library.dll" target="lib" />

    Packaged result:
        lib\library.dll

**Single assembly specific to a target framework**

    Source file:
        library.dll

    .nuspec entry:
        <file src="assemblies\net40\library.dll" target="lib\net40" />

    Packaged result:
        lib\net40\library.dll

**Set of DLLs using a wildcard**

    Source files:
        bin\release\libraryA.dll
        bin\release\libraryB.dll

    .nuspec entry:
        <file src="bin\release\*.dll" target="lib" />

    Packaged result:
        lib\libraryA.dll
        lib\libraryB.dll

**DLLs for different frameworks**

    Source files:
        lib\net40\library.dll
        lib\net20\library.dll

    .nuspec entry (using ** recursive search):
        <file src="lib\**" target="lib" />

    Packaged result:
        lib\net40\library.dll
        lib\net20\library.dll

**Excluding files**

    Source files:
        \tools\*.bak
        \tools\*.log
        \tools\build\*.log

    .nuspec entries:
        <file src="tools\*.*" target="tools" exclude="tools\*.bak" />
        <file src="tools\**\*.*" target="tools" exclude="**\*.log" />

    Package result:
        (no files)

## Including content files

Content files are immutable files that a package needs to include in a project. Being immutable, they are not intended to be modified by the consuming project. Example content files include:

- Images that are embedded as resources
- Source files that are already compiled
- Scripts that need to be included with the build output of the project
- Configuration files for the package that need to be included in the project but don't need any project-specific changes

Content files are included in a package using the `<files>` element, specifying the `content` folder in the `target` attribute. However, such files are ignored when the package is installed in a project using the `project.json` system in NuGet 3.3+ or PackageReference in NuGet 4+, which instead uses the `<contentFiles>` element.

For maximum compatibility with consuming projects, a package ideally specifies the content files in both elements.

### Using the files element for content files

For content files, simply use the same format as for assembly files, but specify `content` as the base folder in the `target` attribute as shown in the following examples.

**Basic content files**

    Source files:
        css\mobile\style1.css
        css\mobile\style2.css

    .nuspec entry:
        <file src="css\mobile\*.css" target="content\css\mobile" />

    Packaged result:
        content\css\mobile\style1.css
        content\css\mobile\style2.css

**Content files with directory structure**

    Source files:
        css\mobile\style.css
        css\mobile\wp7\style.css
        css\browser\style.css

    .nuspec entry:
        <file src="css\**\*.css" target="content\css" />

    Packaged result:
        content\css\mobile\style.css
        content\css\mobile\wp7\style.css
        content\css\browser\style.css

**Content file specific to a target framework**

    Source file:
        css\cool\style.css

    .nuspec entry
        <file src="css\cool\style.css" target="Content" />

    Packaged result:
        content\style.css

**Content file copied to a folder with dot in name**

In this case, NuGet sees that the extension in `target` does not match the extension in `src` and thus treats that part of the name in `target` as a folder:

    Source file:
        images\picture.png

    .nuspec entry:
        <file src="images\picture.png" target="Content\images\package.icons" />

    Packaged result:
        content\images\package.icons\picture.png

**Content files without extensions**

To include files without an extension, use the `*` or `**` wildcards:

    Source file:
        flags\installed

    .nuspec entry:
        <file src="flags\**" target="flags" />

    Packaged result:
        flags\installed

**Content files with deep path and deep target**

In this case, because the file extensions of the source and target match, NuGet assumes that the target is a file name and not a folder:

    Source file:
        css\cool\style.css

    .nuspec entry:
        <file src="css\cool\style.css" target="Content\css\cool" />
        or:
        <file src="css\cool\style.css" target="Content\css\cool\style.css" />

    Packaged result:
        content\css\cool\style.css

**Renaming a content file in the package**

    Source file:
        ie\css\style.css

    .nuspec entry:
        <file src="ie\css\style.css" target="Content\css\ie.css" />

    Packaged result:
        content\css\ie.css

**Excluding files**

    Source file:
        docs\*.txt (multiple files)

    .nuspec entry:
        <file src="docs\*.txt" target="content\docs" exclude="docs\admin.txt" />
        or
        <file src="*.txt" target="content\docs" exclude="admin.txt;log.txt" />

    Packaged result:
        All .txt files from docs except admin.txt (first example)
        All .txt files from docs except admin.txt and log.txt (second example)

<a name="using-contentfiles-element-for-content-files"></a>

### Using the contentFiles element for content files

*Version 3.3+ with project.json and 4.0+ with PackageReference*

By default, a package places content in a `contentFiles` folder (see below) and `nuget pack` included all files in that folder using default attributes. In this case it's not necessary to include a `contentFiles` node in the `.nuspec` at all.

To control which files are included, the `<contentFiles>` element specifies is a collection of `<files>` elements that identify the exact files include.

These files are specified with a set of attributes that describe how they should be used within the project system:

| Attribute | Description |
| --- | --- |
| **include** | (Required) The location of the file or files to include, subject to exclusions specified by the `exclude` attribute. The path is relative to the `.nuspec` file unless an absolute path is specified. The wildcard character `*` is allowed, and the double wildcard `**` implies a recursive folder search. |
| **exclude** | A semicolon-delimited list of files or file patterns to exclude from the `src` location. The wildcard character `*` is allowed, and the double wildcard `**` implies a recursive folder search. |
| **buildAction** | The build action to assign to the content item for MSBuild, such as `Content`, `None`, `Embedded Resource`, `Compile`, etc. The default is `Compile`. |
| **copyToOutput** | A Boolean indicating whether to copy content items to the build output folder. The default is false. |
| **flatten** | A Boolean indicating whether to copy content items to a single folder in the build output (true), or to preserve the folder structure in the package (false). The default is false. |

When installing a package, NuGet applies the child elements of `<contentFiles>` from top to bottom. If multiple entries match the same file then all entries are applied. The top-most entry overrides the lower entries if there is a conflict for the same attribute.

#### Package folder structure

The package project should structure content using the following pattern:

    /contentFiles/{codeLanguage}/{TxM}/{any?}

- `codeLanguages` may be `cs`, `vb`, `fs`, `any`, or the lowercase equivalent of a given `$(ProjectLanguage)`
- `TxM` is any legal target framework moniker that NuGet supports (see [Target frameworks](../schema/target-frameworks.md)).
- Any folder structure may be appended to the end of this syntax.

For example:

    Language- and framework-agnostic:
        /contentFiles/any/any/config.xml

    net45 content for all languages
        /contentFiles/any/net45/config.xml

    C#-specific content for net45 and up
        /contentFiles/cs/net45/sample.cs

Empty folders can use `.` to opt out of providing content for certain combinations of language and TxM, for example:

    /contentFiles/vb/any/code.vb
    /contentFiles/cs/any/.

#### Example contentFiles section

```xml
<contentFiles>
    <!-- Embed image resources -->
    <files include="any/any/images/dnf.png" buildAction="EmbeddedResource" />
    <files include="any/any/images/ui.png" buildAction="EmbeddedResource" />

    <!-- Embed all image resources under contentFiles/cs/ -->
    <files include="cs/**/*.png" buildAction="EmbeddedResource" />

    <!-- Copy config.xml to the root of the output folder -->
    <files include="cs/uap/config/config.xml" buildAction="None" copyToOutput="true" flatten="true" />

    <!-- Copy run.cmd to the output folder and keep the directory structure -->
    <files include="cs/commands/run.cmd" buildAction="None" copyToOutput="true" flatten="false" />

    <!-- Include everything in the scripts folder except exe files -->
    <files include="cs/net45/scripts/*" exclude="**/*.exe"  buildAction="None" copyToOutput="true" />
</contentFiles>
```

## Example .nuspec files

**A simple `.nuspec` that does not specify dependencies or files**

```xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
    <metadata>
    <id>sample</id>
    <version>1.2.3</version>
    <authors>Kim Abercrombie, Franck Halmaert</authors>
    <description>Sample exists only to show a sample .nuspec file.</description>
    <language>en-US</language>
    <projectUrl>http://xunit.codeplex.com/</projectUrl>
    <licenseUrl>http://xunit.codeplex.com/license</licenseUrl>
    </metadata>
</package>
```

**A `.nuspec` with dependencies**

```xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
    <metadata>
    <id>sample</id>
    <version>1.0.0</version>
    <authors>Microsoft</authors>
    <dependencies>
        <dependency id="another-package" version="3.0.0" />
        <dependency id="yet-another-package" version="1.0.0" />
    </dependencies>
    </metadata>
</package>
```

**A `.nuspec` with files**

```xml
<?xml version="1.0"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
    <metadata>
    <id>routedebugger</id>
    <version>1.0.0</version>
    <authors>Jay Hamlin</authors>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <description>Route Debugger is a little utility I wrote...</description>
    </metadata>
    <files>
    <file src="bin\Debug\*.dll" target="lib" />
    </files>
</package>
```

**A `.nuspec` with framework assemblies**

```xml
<?xml version="1.0"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
    <metadata>
    <id>PackageWithGacReferences</id>
    <version>1.0</version>
    <authors>Author here</authors>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <description>
        A package that has framework assemblyReferences depending
        on the target framework.
    </description>
    <frameworkAssemblies>
        <frameworkAssembly assemblyName="System.Web" targetFramework="net40" />
        <frameworkAssembly assemblyName="System.Net" targetFramework="net40-client, net40" />
        <frameworkAssembly assemblyName="Microsoft.Devices.Sensors" targetFramework="sl4-wp" />
        <frameworkAssembly assemblyName="System.Json" targetFramework="sl3" />
    </frameworkAssemblies>
    </metadata>
</package>
```

In this example, the following are installed for specific project targets:

- .NET4 -> `System.Web`, `System.Net`
- .NET4 Client Profile -> `System.Net`
- Silverlight 3 -> `System.Json`
- Silverlight 4 -> `System.Windows.Controls.DomainServices`
- WindowsPhone -> `Microsoft.Devices.Sensors`
