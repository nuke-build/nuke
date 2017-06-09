{
  "Reference": {
    "Url": "https://raw.githubusercontent.com/NuGet/docs.microsoft.com-nuget/master/docs/Schema/nuspec.md",
    "HashCode": 975255048
  },
  "Help": "A .nuspec file is an XML manifest that contains package metadata. This is used both to build the package and to provide information to consumers. The manifest is always included in a package.",
  "OfficialUrl": "https://docs.microsoft.com/en-us/nuget/schema/nuspec",
  "DataClasses": [
    {
      "Name": "NuGetPackage",
      "Properties": [
        {
          "Name": "Id",
          "Type": "string",
          "Help": "The case-insensitive package identifier, which must be unique across nuget.org or whatever gallery the package will reside in. IDs may not contain spaces or characters that are not valid for a URL, and generally follow .NET namespace rules. See <a href=\"https://docs.microsoft.com/en-us/nuget/create-packages/creating-a-package#choosing-a-unique-package-identifier-and-setting-the-version-number\">Choosing a unique package identifier</a> for guidance."
        },
        {
          "Name": "Version",
          "Type": "string",
          "Help": "The version of the package, following the <c>major.minor.patch</c> pattern. Version numbers may include a pre-release suffix as described in <a href=\"https://docs.microsoft.com/en-us/nuget/create-packages/prerelease-packages#semantic-versioning\">Prerelease Packages</a>."
        },
        {
          "Name": "Description",
          "Type": "string",
          "Help": "A long description of the package for UI display."
        },
        {
          "Name": "Authors",
          "Type": "List<string>",
          "Help": "A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors."
        },
        {
          "Name": "Title",
          "Type": "string",
          "Help": "A human-friendly title of the package, typically used in UI displays as on nuget.org and the Package Manager in Visual Studio. If not specified, the package ID is used instead."
        },
        {
          "Name": "Owners",
          "Type": "List<string>",
          "Help": "A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href=\"https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg\">Managing package owners on nuget.org</a>."
        },
        {
          "Name": "ProjectUrl",
          "Type": "string",
          "Help": "A URL for the package's home page, often shown in UI displays as well as nuget.org."
        },
        {
          "Name": "LicenseUrl",
          "Type": "string",
          "Help": "A URL for the package's license, often shown in UI displays as well as nuget.org."
        },
        {
          "Name": "IconUrl",
          "Type": "string",
          "Help": "A URL for a 64x64 image with transparenty background to use as the icon for the package in UI display."
        },
        {
          "Name": "RequireLicenseAcceptance",
          "Type": "bool",
          "Help": "A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package."
        },
        {
          "Name": "DevelopmentDependency",
          "Type": "bool",
          "Help": "<i>(2.8+)</i>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages."
        },
        {
          "Name": "Summary",
          "Type": "string",
          "Help": "A short description of the package for UI display. If omitted, a truncated version of the <see cref=\"NuGetPackage.Description\"/> is used."
        },
        {
          "Name": "ReleaseNotes",
          "Type": "string",
          "Help": "<i>(1.5+)</i> A description of the changes made in this release of the package, often used in UI like the Updates tab of the Visual Studio Package Manager in place of the package description."
        },
        {
          "Name": "Copyright",
          "Type": "string",
          "Help": "<i>(1.5+)</i> Copyright details for the package."
        },
        {
          "Name": "Language",
          "Type": "string",
          "Help": "The locale ID for the package. See <a href=\"https://docs.microsoft.com/en-us/nuget/create-packages/creating-localized-packages\">Creating localized packages</a>."
        },
        {
          "Name": "Tags",
          "Type": "List<string>",
          "Help": "A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms."
        },
        {
          "Name": "ContentFiles",
          "Type": "List<PackageContentFile>",
          "Help": "<i>(3.3+)</i> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href=\"https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package\">Specifying files to include in the package</a>."
        },
        {
          "Name": "DefaultDependencies",
          "Type": "List<PackageDependency>"
        },
        {
          "Name": "DependencySets",
          "Type": "List<PackageDependencySet>",
          "Help": "A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <i>id</i>, <i>version</i>, <i>include</i> (3.x+), and <i>exclude</i> (3.x+). See <a href=\"https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies\">Dependencies</a>."
        }
      ]
    },
    {
      "Name": "PackageContentFile",
      "NoExtensionMethods": true,
      "Properties": [
        {
          "Name": "Source",
          "Type": "string"
        },
        {
          "Name": "Target",
          "Type": "string"
        },
        {
          "Name": "Exclude",
          "Type": "string"
        }
      ]
    },
    {
      "Name": "PackageDependencySet",
      "NoExtensionMethods": true,
      "Properties": [
        {
          "Name": "TargetFramework",
          "Type": "string"
        },
        {
          "Name": "Dependencies",
          "Type": "List<PackageDependency>"
        }
      ]
    },
    {
      "Name": "PackageDependency",
      "NoExtensionMethods": true,
      "Properties": [
        {
          "Name": "Id",
          "Type": "string"
        },
        {
          "Name": "Version",
          "Type": "string"
        },
        {
          "Name": "Include",
          "Type": "string"
        },
        {
          "Name": "Exclude",
          "Type": "string"
        }
      ]
    }
  ],
  "Enumerations": []
}