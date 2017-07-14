// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Auto-generated with Nuke.ToolGenerator.

using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.NuGet
{
    /// <summary><p>A .nuspec file is an XML manifest that contains package metadata. This is used both to build the package and to provide information to consumers. The manifest is always included in a package.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetPackage : ISettingsEntity
    {
        /// <summary><p>The case-insensitive package identifier, which must be unique across nuget.org or whatever gallery the package will reside in. IDs may not contain spaces or characters that are not valid for a URL, and generally follow .NET namespace rules. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/creating-a-package#choosing-a-unique-package-identifier-and-setting-the-version-number">Choosing a unique package identifier</a> for guidance.</p></summary>
        public virtual string Id { get; internal set; }
        /// <summary><p>The version of the package, following the <c>major.minor.patch</c> pattern. Version numbers may include a pre-release suffix as described in <a href="https://docs.microsoft.com/en-us/nuget/create-packages/prerelease-packages#semantic-versioning">Prerelease Packages</a>.</p></summary>
        public virtual string Version { get; internal set; }
        /// <summary><p>A long description of the package for UI display.</p></summary>
        public virtual string Description { get; internal set; }
        /// <summary><p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p></summary>
        public virtual IReadOnlyList<string> Authors => AuthorsInternal.AsReadOnly();
        internal List<string> AuthorsInternal { get; set; } = new List<string>();
        /// <summary><p>A human-friendly title of the package, typically used in UI displays as on nuget.org and the Package Manager in Visual Studio. If not specified, the package ID is used instead.</p></summary>
        public virtual string Title { get; internal set; }
        /// <summary><p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p></summary>
        public virtual IReadOnlyList<string> Owners => OwnersInternal.AsReadOnly();
        internal List<string> OwnersInternal { get; set; } = new List<string>();
        /// <summary><p>A URL for the package's home page, often shown in UI displays as well as nuget.org.</p></summary>
        public virtual string ProjectUrl { get; internal set; }
        /// <summary><p>A URL for the package's license, often shown in UI displays as well as nuget.org.</p></summary>
        public virtual string LicenseUrl { get; internal set; }
        /// <summary><p>A URL for a 64x64 image with transparenty background to use as the icon for the package in UI display.</p></summary>
        public virtual string IconUrl { get; internal set; }
        /// <summary><p>A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package.</p></summary>
        public virtual bool RequireLicenseAcceptance { get; internal set; }
        /// <summary><p><em>(2.8+)</em>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages.</p></summary>
        public virtual bool DevelopmentDependency { get; internal set; }
        /// <summary><p>A short description of the package for UI display. If omitted, a truncated version of the <see cref="NuGetPackage.Description"/> is used.</p></summary>
        public virtual string Summary { get; internal set; }
        /// <summary><p><em>(1.5+)</em> A description of the changes made in this release of the package, often used in UI like the Updates tab of the Visual Studio Package Manager in place of the package description.</p></summary>
        public virtual string ReleaseNotes { get; internal set; }
        /// <summary><p><em>(1.5+)</em> Copyright details for the package.</p></summary>
        public virtual string Copyright { get; internal set; }
        /// <summary><p>The locale ID for the package. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/creating-localized-packages">Creating localized packages</a>.</p></summary>
        public virtual string Language { get; internal set; }
        /// <summary><p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p></summary>
        public virtual IReadOnlyList<string> Tags => TagsInternal.AsReadOnly();
        internal List<string> TagsInternal { get; set; } = new List<string>();
        /// <summary><p><em>(3.3+)</em> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p></summary>
        public virtual IReadOnlyList<PackageContentFile> ContentFiles => ContentFilesInternal.AsReadOnly();
        internal List<PackageContentFile> ContentFilesInternal { get; set; } = new List<PackageContentFile>();
        public virtual IReadOnlyList<PackageDependency> DefaultDependencies => DefaultDependenciesInternal.AsReadOnly();
        internal List<PackageDependency> DefaultDependenciesInternal { get; set; } = new List<PackageDependency>();
        /// <summary><p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <em>id</em>, <em>version</em>, <em>include</em> (3.x+), and <em>exclude</em> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p></summary>
        public virtual IReadOnlyList<PackageDependencySet> DependencySets => DependencySetsInternal.AsReadOnly();
        internal List<PackageDependencySet> DependencySetsInternal { get; set; } = new List<PackageDependencySet>();
    }
    /// <summary><p>A .nuspec file is an XML manifest that contains package metadata. This is used both to build the package and to provide information to consumers. The manifest is always included in a package.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PackageContentFile : ISettingsEntity
    {
        public virtual string Source { get; internal set; }
        public virtual string Target { get; internal set; }
        public virtual string Exclude { get; internal set; }
    }
    /// <summary><p>A .nuspec file is an XML manifest that contains package metadata. This is used both to build the package and to provide information to consumers. The manifest is always included in a package.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PackageDependencySet : ISettingsEntity
    {
        public virtual string TargetFramework { get; internal set; }
        public virtual IReadOnlyList<PackageDependency> Dependencies => DependenciesInternal.AsReadOnly();
        internal List<PackageDependency> DependenciesInternal { get; set; } = new List<PackageDependency>();
    }
    /// <summary><p>A .nuspec file is an XML manifest that contains package metadata. This is used both to build the package and to provide information to consumers. The manifest is always included in a package.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PackageDependency : ISettingsEntity
    {
        public virtual string Id { get; internal set; }
        public virtual string Version { get; internal set; }
        public virtual string Include { get; internal set; }
        public virtual string Exclude { get; internal set; }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetPackageExtensions
    {
        /// <summary><p><em>Sets <see cref="NuGetPackage.Id"/>.</em></p><p>The case-insensitive package identifier, which must be unique across nuget.org or whatever gallery the package will reside in. IDs may not contain spaces or characters that are not valid for a URL, and generally follow .NET namespace rules. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/creating-a-package#choosing-a-unique-package-identifier-and-setting-the-version-number">Choosing a unique package identifier</a> for guidance.</p></summary>
        [Pure]
        public static NuGetPackage SetId(this NuGetPackage toolSettings, string id)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Id = id;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Version"/>.</em></p><p>The version of the package, following the <c>major.minor.patch</c> pattern. Version numbers may include a pre-release suffix as described in <a href="https://docs.microsoft.com/en-us/nuget/create-packages/prerelease-packages#semantic-versioning">Prerelease Packages</a>.</p></summary>
        [Pure]
        public static NuGetPackage SetVersion(this NuGetPackage toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Description"/>.</em></p><p>A long description of the package for UI display.</p></summary>
        [Pure]
        public static NuGetPackage SetDescription(this NuGetPackage toolSettings, string description)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Authors"/> to a new list.</em></p><p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p></summary>
        [Pure]
        public static NuGetPackage SetAuthors(this NuGetPackage toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal = authors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Authors"/> to a new list.</em></p><p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p></summary>
        [Pure]
        public static NuGetPackage SetAuthors(this NuGetPackage toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal = authors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a authors to the existing <see cref="NuGetPackage.Authors"/>.</em></p><p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p></summary>
        [Pure]
        public static NuGetPackage AddAuthors(this NuGetPackage toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal.AddRange(authors);
            return toolSettings;
        }
        /// <summary><p><em>Adds a authors to the existing <see cref="NuGetPackage.Authors"/>.</em></p><p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p></summary>
        [Pure]
        public static NuGetPackage AddAuthors(this NuGetPackage toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal.AddRange(authors);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NuGetPackage.Authors"/>.</em></p><p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p></summary>
        [Pure]
        public static NuGetPackage ClearAuthors(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single author to <see cref="NuGetPackage.Authors"/>.</em></p><p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p></summary>
        [Pure]
        public static NuGetPackage AddAuthor(this NuGetPackage toolSettings, string author, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (author != null || evenIfNull) toolSettings.AuthorsInternal.Add(author);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single author from <see cref="NuGetPackage.Authors"/>.</em></p><p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p></summary>
        [Pure]
        public static NuGetPackage RemoveAuthor(this NuGetPackage toolSettings, string author)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal = toolSettings.Authors.Where(x => x == author).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Title"/>.</em></p><p>A human-friendly title of the package, typically used in UI displays as on nuget.org and the Package Manager in Visual Studio. If not specified, the package ID is used instead.</p></summary>
        [Pure]
        public static NuGetPackage SetTitle(this NuGetPackage toolSettings, string title)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = title;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Owners"/> to a new list.</em></p><p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p></summary>
        [Pure]
        public static NuGetPackage SetOwners(this NuGetPackage toolSettings, params string[] owners)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OwnersInternal = owners.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Owners"/> to a new list.</em></p><p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p></summary>
        [Pure]
        public static NuGetPackage SetOwners(this NuGetPackage toolSettings, IEnumerable<string> owners)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OwnersInternal = owners.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a owners to the existing <see cref="NuGetPackage.Owners"/>.</em></p><p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p></summary>
        [Pure]
        public static NuGetPackage AddOwners(this NuGetPackage toolSettings, params string[] owners)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OwnersInternal.AddRange(owners);
            return toolSettings;
        }
        /// <summary><p><em>Adds a owners to the existing <see cref="NuGetPackage.Owners"/>.</em></p><p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p></summary>
        [Pure]
        public static NuGetPackage AddOwners(this NuGetPackage toolSettings, IEnumerable<string> owners)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OwnersInternal.AddRange(owners);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NuGetPackage.Owners"/>.</em></p><p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p></summary>
        [Pure]
        public static NuGetPackage ClearOwners(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OwnersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single owner to <see cref="NuGetPackage.Owners"/>.</em></p><p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p></summary>
        [Pure]
        public static NuGetPackage AddOwner(this NuGetPackage toolSettings, string owner, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (owner != null || evenIfNull) toolSettings.OwnersInternal.Add(owner);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single owner from <see cref="NuGetPackage.Owners"/>.</em></p><p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p></summary>
        [Pure]
        public static NuGetPackage RemoveOwner(this NuGetPackage toolSettings, string owner)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OwnersInternal = toolSettings.Owners.Where(x => x == owner).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.ProjectUrl"/>.</em></p><p>A URL for the package's home page, often shown in UI displays as well as nuget.org.</p></summary>
        [Pure]
        public static NuGetPackage SetProjectUrl(this NuGetPackage toolSettings, string projectUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectUrl = projectUrl;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.LicenseUrl"/>.</em></p><p>A URL for the package's license, often shown in UI displays as well as nuget.org.</p></summary>
        [Pure]
        public static NuGetPackage SetLicenseUrl(this NuGetPackage toolSettings, string licenseUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LicenseUrl = licenseUrl;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.IconUrl"/>.</em></p><p>A URL for a 64x64 image with transparenty background to use as the icon for the package in UI display.</p></summary>
        [Pure]
        public static NuGetPackage SetIconUrl(this NuGetPackage toolSettings, string iconUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IconUrl = iconUrl;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.RequireLicenseAcceptance"/>.</em></p><p>A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package.</p></summary>
        [Pure]
        public static NuGetPackage SetRequireLicenseAcceptance(this NuGetPackage toolSettings, bool requireLicenseAcceptance)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireLicenseAcceptance = requireLicenseAcceptance;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackage.RequireLicenseAcceptance"/>.</em></p><p>A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package.</p></summary>
        [Pure]
        public static NuGetPackage EnableRequireLicenseAcceptance(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireLicenseAcceptance = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackage.RequireLicenseAcceptance"/>.</em></p><p>A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package.</p></summary>
        [Pure]
        public static NuGetPackage DisableRequireLicenseAcceptance(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireLicenseAcceptance = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackage.RequireLicenseAcceptance"/>.</em></p><p>A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package.</p></summary>
        [Pure]
        public static NuGetPackage ToggleRequireLicenseAcceptance(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireLicenseAcceptance = !toolSettings.RequireLicenseAcceptance;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.DevelopmentDependency"/>.</em></p><p><em>(2.8+)</em>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages.</p></summary>
        [Pure]
        public static NuGetPackage SetDevelopmentDependency(this NuGetPackage toolSettings, bool developmentDependency)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DevelopmentDependency = developmentDependency;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackage.DevelopmentDependency"/>.</em></p><p><em>(2.8+)</em>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages.</p></summary>
        [Pure]
        public static NuGetPackage EnableDevelopmentDependency(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DevelopmentDependency = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackage.DevelopmentDependency"/>.</em></p><p><em>(2.8+)</em>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages.</p></summary>
        [Pure]
        public static NuGetPackage DisableDevelopmentDependency(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DevelopmentDependency = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackage.DevelopmentDependency"/>.</em></p><p><em>(2.8+)</em>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages.</p></summary>
        [Pure]
        public static NuGetPackage ToggleDevelopmentDependency(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DevelopmentDependency = !toolSettings.DevelopmentDependency;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Summary"/>.</em></p><p>A short description of the package for UI display. If omitted, a truncated version of the <see cref="NuGetPackage.Description"/> is used.</p></summary>
        [Pure]
        public static NuGetPackage SetSummary(this NuGetPackage toolSettings, string summary)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Summary = summary;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.ReleaseNotes"/>.</em></p><p><em>(1.5+)</em> A description of the changes made in this release of the package, often used in UI like the Updates tab of the Visual Studio Package Manager in place of the package description.</p></summary>
        [Pure]
        public static NuGetPackage SetReleaseNotes(this NuGetPackage toolSettings, string releaseNotes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = releaseNotes;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Copyright"/>.</em></p><p><em>(1.5+)</em> Copyright details for the package.</p></summary>
        [Pure]
        public static NuGetPackage SetCopyright(this NuGetPackage toolSettings, string copyright)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Copyright = copyright;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Language"/>.</em></p><p>The locale ID for the package. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/creating-localized-packages">Creating localized packages</a>.</p></summary>
        [Pure]
        public static NuGetPackage SetLanguage(this NuGetPackage toolSettings, string language)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Language = language;
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Tags"/> to a new list.</em></p><p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p></summary>
        [Pure]
        public static NuGetPackage SetTags(this NuGetPackage toolSettings, params string[] tags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal = tags.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.Tags"/> to a new list.</em></p><p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p></summary>
        [Pure]
        public static NuGetPackage SetTags(this NuGetPackage toolSettings, IEnumerable<string> tags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal = tags.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a tags to the existing <see cref="NuGetPackage.Tags"/>.</em></p><p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p></summary>
        [Pure]
        public static NuGetPackage AddTags(this NuGetPackage toolSettings, params string[] tags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal.AddRange(tags);
            return toolSettings;
        }
        /// <summary><p><em>Adds a tags to the existing <see cref="NuGetPackage.Tags"/>.</em></p><p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p></summary>
        [Pure]
        public static NuGetPackage AddTags(this NuGetPackage toolSettings, IEnumerable<string> tags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal.AddRange(tags);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NuGetPackage.Tags"/>.</em></p><p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p></summary>
        [Pure]
        public static NuGetPackage ClearTags(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single tag to <see cref="NuGetPackage.Tags"/>.</em></p><p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p></summary>
        [Pure]
        public static NuGetPackage AddTag(this NuGetPackage toolSettings, string tag, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (tag != null || evenIfNull) toolSettings.TagsInternal.Add(tag);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single tag from <see cref="NuGetPackage.Tags"/>.</em></p><p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p></summary>
        [Pure]
        public static NuGetPackage RemoveTag(this NuGetPackage toolSettings, string tag)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal = toolSettings.Tags.Where(x => x == tag).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.ContentFiles"/> to a new list.</em></p><p><em>(3.3+)</em> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p></summary>
        [Pure]
        public static NuGetPackage SetContentFiles(this NuGetPackage toolSettings, params PackageContentFile[] contentFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentFilesInternal = contentFiles.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.ContentFiles"/> to a new list.</em></p><p><em>(3.3+)</em> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p></summary>
        [Pure]
        public static NuGetPackage SetContentFiles(this NuGetPackage toolSettings, IEnumerable<PackageContentFile> contentFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentFilesInternal = contentFiles.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a contentFiles to the existing <see cref="NuGetPackage.ContentFiles"/>.</em></p><p><em>(3.3+)</em> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p></summary>
        [Pure]
        public static NuGetPackage AddContentFiles(this NuGetPackage toolSettings, params PackageContentFile[] contentFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentFilesInternal.AddRange(contentFiles);
            return toolSettings;
        }
        /// <summary><p><em>Adds a contentFiles to the existing <see cref="NuGetPackage.ContentFiles"/>.</em></p><p><em>(3.3+)</em> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p></summary>
        [Pure]
        public static NuGetPackage AddContentFiles(this NuGetPackage toolSettings, IEnumerable<PackageContentFile> contentFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentFilesInternal.AddRange(contentFiles);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NuGetPackage.ContentFiles"/>.</em></p><p><em>(3.3+)</em> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p></summary>
        [Pure]
        public static NuGetPackage ClearContentFiles(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single contentFile to <see cref="NuGetPackage.ContentFiles"/>.</em></p><p><em>(3.3+)</em> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p></summary>
        [Pure]
        public static NuGetPackage AddContentFile(this NuGetPackage toolSettings, PackageContentFile contentFile, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (contentFile != null || evenIfNull) toolSettings.ContentFilesInternal.Add(contentFile);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single contentFile from <see cref="NuGetPackage.ContentFiles"/>.</em></p><p><em>(3.3+)</em> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p></summary>
        [Pure]
        public static NuGetPackage RemoveContentFile(this NuGetPackage toolSettings, PackageContentFile contentFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContentFilesInternal = toolSettings.ContentFiles.Where(x => x == contentFile).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.DefaultDependencies"/> to a new list.</em></p></summary>
        [Pure]
        public static NuGetPackage SetDefaultDependencies(this NuGetPackage toolSettings, params PackageDependency[] defaultDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultDependenciesInternal = defaultDependencies.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.DefaultDependencies"/> to a new list.</em></p></summary>
        [Pure]
        public static NuGetPackage SetDefaultDependencies(this NuGetPackage toolSettings, IEnumerable<PackageDependency> defaultDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultDependenciesInternal = defaultDependencies.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a defaultDependencies to the existing <see cref="NuGetPackage.DefaultDependencies"/>.</em></p></summary>
        [Pure]
        public static NuGetPackage AddDefaultDependencies(this NuGetPackage toolSettings, params PackageDependency[] defaultDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultDependenciesInternal.AddRange(defaultDependencies);
            return toolSettings;
        }
        /// <summary><p><em>Adds a defaultDependencies to the existing <see cref="NuGetPackage.DefaultDependencies"/>.</em></p></summary>
        [Pure]
        public static NuGetPackage AddDefaultDependencies(this NuGetPackage toolSettings, IEnumerable<PackageDependency> defaultDependencies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultDependenciesInternal.AddRange(defaultDependencies);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NuGetPackage.DefaultDependencies"/>.</em></p></summary>
        [Pure]
        public static NuGetPackage ClearDefaultDependencies(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultDependenciesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single defaultDependency to <see cref="NuGetPackage.DefaultDependencies"/>.</em></p></summary>
        [Pure]
        public static NuGetPackage AddDefaultDependency(this NuGetPackage toolSettings, PackageDependency defaultDependency, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (defaultDependency != null || evenIfNull) toolSettings.DefaultDependenciesInternal.Add(defaultDependency);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single defaultDependency from <see cref="NuGetPackage.DefaultDependencies"/>.</em></p></summary>
        [Pure]
        public static NuGetPackage RemoveDefaultDependency(this NuGetPackage toolSettings, PackageDependency defaultDependency)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultDependenciesInternal = toolSettings.DefaultDependencies.Where(x => x == defaultDependency).ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.DependencySets"/> to a new list.</em></p><p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <em>id</em>, <em>version</em>, <em>include</em> (3.x+), and <em>exclude</em> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p></summary>
        [Pure]
        public static NuGetPackage SetDependencySets(this NuGetPackage toolSettings, params PackageDependencySet[] dependencySets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencySetsInternal = dependencySets.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetPackage.DependencySets"/> to a new list.</em></p><p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <em>id</em>, <em>version</em>, <em>include</em> (3.x+), and <em>exclude</em> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p></summary>
        [Pure]
        public static NuGetPackage SetDependencySets(this NuGetPackage toolSettings, IEnumerable<PackageDependencySet> dependencySets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencySetsInternal = dependencySets.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds a dependencySets to the existing <see cref="NuGetPackage.DependencySets"/>.</em></p><p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <em>id</em>, <em>version</em>, <em>include</em> (3.x+), and <em>exclude</em> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p></summary>
        [Pure]
        public static NuGetPackage AddDependencySets(this NuGetPackage toolSettings, params PackageDependencySet[] dependencySets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencySetsInternal.AddRange(dependencySets);
            return toolSettings;
        }
        /// <summary><p><em>Adds a dependencySets to the existing <see cref="NuGetPackage.DependencySets"/>.</em></p><p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <em>id</em>, <em>version</em>, <em>include</em> (3.x+), and <em>exclude</em> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p></summary>
        [Pure]
        public static NuGetPackage AddDependencySets(this NuGetPackage toolSettings, IEnumerable<PackageDependencySet> dependencySets)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencySetsInternal.AddRange(dependencySets);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NuGetPackage.DependencySets"/>.</em></p><p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <em>id</em>, <em>version</em>, <em>include</em> (3.x+), and <em>exclude</em> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p></summary>
        [Pure]
        public static NuGetPackage ClearDependencySets(this NuGetPackage toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencySetsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a single dependencySet to <see cref="NuGetPackage.DependencySets"/>.</em></p><p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <em>id</em>, <em>version</em>, <em>include</em> (3.x+), and <em>exclude</em> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p></summary>
        [Pure]
        public static NuGetPackage AddDependencySet(this NuGetPackage toolSettings, PackageDependencySet dependencySet, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (dependencySet != null || evenIfNull) toolSettings.DependencySetsInternal.Add(dependencySet);
            return toolSettings;
        }
        /// <summary><p><em>Removes a single dependencySet from <see cref="NuGetPackage.DependencySets"/>.</em></p><p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <em>id</em>, <em>version</em>, <em>include</em> (3.x+), and <em>exclude</em> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p></summary>
        [Pure]
        public static NuGetPackage RemoveDependencySet(this NuGetPackage toolSettings, PackageDependencySet dependencySet)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencySetsInternal = toolSettings.DependencySets.Where(x => x == dependencySet).ToList();
            return toolSettings;
        }
    }
}
