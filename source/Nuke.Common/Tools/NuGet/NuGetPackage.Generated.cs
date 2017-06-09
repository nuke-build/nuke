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
    /// <summary>
    /// <p>A .nuspec file is an XML manifest that contains package metadata. This is used both to build the package and to provide information to consumers. The manifest is always included in a package.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec">official website</a>.</p>
    /// </summary>
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
        /// <summary><p><i>(2.8+)</i>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages.</p></summary>
        public virtual bool DevelopmentDependency { get; internal set; }
        /// <summary><p>A short description of the package for UI display. If omitted, a truncated version of the <see cref="NuGetPackage.Description"/> is used.</p></summary>
        public virtual string Summary { get; internal set; }
        /// <summary><p><i>(1.5+)</i> A description of the changes made in this release of the package, often used in UI like the Updates tab of the Visual Studio Package Manager in place of the package description.</p></summary>
        public virtual string ReleaseNotes { get; internal set; }
        /// <summary><p><i>(1.5+)</i> Copyright details for the package.</p></summary>
        public virtual string Copyright { get; internal set; }
        /// <summary><p>The locale ID for the package. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/creating-localized-packages">Creating localized packages</a>.</p></summary>
        public virtual string Language { get; internal set; }
        /// <summary><p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p></summary>
        public virtual IReadOnlyList<string> Tags => TagsInternal.AsReadOnly();
        internal List<string> TagsInternal { get; set; } = new List<string>();
        /// <summary><p><i>(3.3+)</i> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p></summary>
        public virtual IReadOnlyList<PackageContentFile> ContentFiles => ContentFilesInternal.AsReadOnly();
        internal List<PackageContentFile> ContentFilesInternal { get; set; } = new List<PackageContentFile>();
        public virtual IReadOnlyList<PackageDependency> DefaultDependencies => DefaultDependenciesInternal.AsReadOnly();
        internal List<PackageDependency> DefaultDependenciesInternal { get; set; } = new List<PackageDependency>();
        /// <summary><p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <i>id</i>, <i>version</i>, <i>include</i> (3.x+), and <i>exclude</i> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p></summary>
        public virtual IReadOnlyList<PackageDependencySet> DependencySets => DependencySetsInternal.AsReadOnly();
        internal List<PackageDependencySet> DependencySetsInternal { get; set; } = new List<PackageDependencySet>();
    }
    /// <summary>
    /// <p>A .nuspec file is an XML manifest that contains package metadata. This is used both to build the package and to provide information to consumers. The manifest is always included in a package.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PackageContentFile : ISettingsEntity
    {
        public virtual string Source { get; internal set; }
        public virtual string Target { get; internal set; }
        public virtual string Exclude { get; internal set; }
    }
    /// <summary>
    /// <p>A .nuspec file is an XML manifest that contains package metadata. This is used both to build the package and to provide information to consumers. The manifest is always included in a package.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PackageDependencySet : ISettingsEntity
    {
        public virtual string TargetFramework { get; internal set; }
        public virtual IReadOnlyList<PackageDependency> Dependencies => DependenciesInternal.AsReadOnly();
        internal List<PackageDependency> DependenciesInternal { get; set; } = new List<PackageDependency>();
    }
    /// <summary>
    /// <p>A .nuspec file is an XML manifest that contains package metadata. This is used both to build the package and to provide information to consumers. The manifest is always included in a package.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec">official website</a>.</p>
    /// </summary>
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
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Id"/>.</i></p>
        /// <p>The case-insensitive package identifier, which must be unique across nuget.org or whatever gallery the package will reside in. IDs may not contain spaces or characters that are not valid for a URL, and generally follow .NET namespace rules. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/creating-a-package#choosing-a-unique-package-identifier-and-setting-the-version-number">Choosing a unique package identifier</a> for guidance.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetId(this NuGetPackage nuGetPackage, string id)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.Id = id;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Version"/>.</i></p>
        /// <p>The version of the package, following the <c>major.minor.patch</c> pattern. Version numbers may include a pre-release suffix as described in <a href="https://docs.microsoft.com/en-us/nuget/create-packages/prerelease-packages#semantic-versioning">Prerelease Packages</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetVersion(this NuGetPackage nuGetPackage, string version)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.Version = version;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Description"/>.</i></p>
        /// <p>A long description of the package for UI display.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetDescription(this NuGetPackage nuGetPackage, string description)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.Description = description;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Authors"/> to a new list.</i></p>
        /// <p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetAuthors(this NuGetPackage nuGetPackage, params string[] authors)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.AuthorsInternal = authors.ToList();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Authors"/> to a new list.</i></p>
        /// <p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetAuthors(this NuGetPackage nuGetPackage, IEnumerable<string> authors)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.AuthorsInternal = authors.ToList();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding new authors to the existing <see cref="NuGetPackage.Authors"/>.</i></p>
        /// <p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddAuthors(this NuGetPackage nuGetPackage, params string[] authors)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.AuthorsInternal.AddRange(authors);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding new authors to the existing <see cref="NuGetPackage.Authors"/>.</i></p>
        /// <p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddAuthors(this NuGetPackage nuGetPackage, IEnumerable<string> authors)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.AuthorsInternal.AddRange(authors);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="NuGetPackage.Authors"/>.</i></p>
        /// <p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage ClearAuthors(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.AuthorsInternal.Clear();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single author to <see cref="NuGetPackage.Authors"/>.</i></p>
        /// <p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddAuthor(this NuGetPackage nuGetPackage, string author)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.AuthorsInternal.Add(author);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single author from <see cref="NuGetPackage.Authors"/>.</i></p>
        /// <p>A comma-separated list of packages authors, matching the profile names on nuget.org. These are displayed in the NuGet Gallery on nuget.org and are used to cross-reference packages by the same authors.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage RemoveAuthor(this NuGetPackage nuGetPackage, string author)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.AuthorsInternal.Remove(author);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Title"/>.</i></p>
        /// <p>A human-friendly title of the package, typically used in UI displays as on nuget.org and the Package Manager in Visual Studio. If not specified, the package ID is used instead.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetTitle(this NuGetPackage nuGetPackage, string title)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.Title = title;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Owners"/> to a new list.</i></p>
        /// <p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetOwners(this NuGetPackage nuGetPackage, params string[] owners)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.OwnersInternal = owners.ToList();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Owners"/> to a new list.</i></p>
        /// <p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetOwners(this NuGetPackage nuGetPackage, IEnumerable<string> owners)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.OwnersInternal = owners.ToList();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding new owners to the existing <see cref="NuGetPackage.Owners"/>.</i></p>
        /// <p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddOwners(this NuGetPackage nuGetPackage, params string[] owners)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.OwnersInternal.AddRange(owners);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding new owners to the existing <see cref="NuGetPackage.Owners"/>.</i></p>
        /// <p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddOwners(this NuGetPackage nuGetPackage, IEnumerable<string> owners)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.OwnersInternal.AddRange(owners);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="NuGetPackage.Owners"/>.</i></p>
        /// <p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage ClearOwners(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.OwnersInternal.Clear();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single owner to <see cref="NuGetPackage.Owners"/>.</i></p>
        /// <p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddOwner(this NuGetPackage nuGetPackage, string owner)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.OwnersInternal.Add(owner);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single owner from <see cref="NuGetPackage.Owners"/>.</i></p>
        /// <p>A comma-separated list of the package creators using profile names on nuget.org. This is often the same list as in authors, and is ignored when uploading the package to nuget.org. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package#managing-package-owners-on-nugetorg">Managing package owners on nuget.org</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage RemoveOwner(this NuGetPackage nuGetPackage, string owner)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.OwnersInternal.Remove(owner);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.ProjectUrl"/>.</i></p>
        /// <p>A URL for the package's home page, often shown in UI displays as well as nuget.org.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetProjectUrl(this NuGetPackage nuGetPackage, string projectUrl)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.ProjectUrl = projectUrl;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.LicenseUrl"/>.</i></p>
        /// <p>A URL for the package's license, often shown in UI displays as well as nuget.org.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetLicenseUrl(this NuGetPackage nuGetPackage, string licenseUrl)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.LicenseUrl = licenseUrl;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.IconUrl"/>.</i></p>
        /// <p>A URL for a 64x64 image with transparenty background to use as the icon for the package in UI display.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetIconUrl(this NuGetPackage nuGetPackage, string iconUrl)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.IconUrl = iconUrl;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.RequireLicenseAcceptance"/>.</i></p>
        /// <p>A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetRequireLicenseAcceptance(this NuGetPackage nuGetPackage, bool requireLicenseAcceptance)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.RequireLicenseAcceptance = requireLicenseAcceptance;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackage.RequireLicenseAcceptance"/>.</i></p>
        /// <p>A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage EnableRequireLicenseAcceptance(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.RequireLicenseAcceptance = true;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackage.RequireLicenseAcceptance"/>.</i></p>
        /// <p>A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage DisableRequireLicenseAcceptance(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.RequireLicenseAcceptance = false;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackage.RequireLicenseAcceptance"/>.</i></p>
        /// <p>A Boolean value specifying whether the client must prompt the consumer to accept the package license before installing the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage ToggleRequireLicenseAcceptance(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.RequireLicenseAcceptance = !nuGetPackage.RequireLicenseAcceptance;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.DevelopmentDependency"/>.</i></p>
        /// <p><i>(2.8+)</i>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetDevelopmentDependency(this NuGetPackage nuGetPackage, bool developmentDependency)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DevelopmentDependency = developmentDependency;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetPackage.DevelopmentDependency"/>.</i></p>
        /// <p><i>(2.8+)</i>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage EnableDevelopmentDependency(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DevelopmentDependency = true;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetPackage.DevelopmentDependency"/>.</i></p>
        /// <p><i>(2.8+)</i>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage DisableDevelopmentDependency(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DevelopmentDependency = false;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetPackage.DevelopmentDependency"/>.</i></p>
        /// <p><i>(2.8+)</i>  A Boolean value specifying whether the package will be marked as a development-only-dependency, which prevents the package from being included as a dependency in other packages.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage ToggleDevelopmentDependency(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DevelopmentDependency = !nuGetPackage.DevelopmentDependency;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Summary"/>.</i></p>
        /// <p>A short description of the package for UI display. If omitted, a truncated version of the <see cref="NuGetPackage.Description"/> is used.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetSummary(this NuGetPackage nuGetPackage, string summary)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.Summary = summary;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.ReleaseNotes"/>.</i></p>
        /// <p><i>(1.5+)</i> A description of the changes made in this release of the package, often used in UI like the Updates tab of the Visual Studio Package Manager in place of the package description.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetReleaseNotes(this NuGetPackage nuGetPackage, string releaseNotes)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.ReleaseNotes = releaseNotes;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Copyright"/>.</i></p>
        /// <p><i>(1.5+)</i> Copyright details for the package.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetCopyright(this NuGetPackage nuGetPackage, string copyright)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.Copyright = copyright;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Language"/>.</i></p>
        /// <p>The locale ID for the package. See <a href="https://docs.microsoft.com/en-us/nuget/create-packages/creating-localized-packages">Creating localized packages</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetLanguage(this NuGetPackage nuGetPackage, string language)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.Language = language;
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Tags"/> to a new list.</i></p>
        /// <p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetTags(this NuGetPackage nuGetPackage, params string[] tags)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.TagsInternal = tags.ToList();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.Tags"/> to a new list.</i></p>
        /// <p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetTags(this NuGetPackage nuGetPackage, IEnumerable<string> tags)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.TagsInternal = tags.ToList();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding new tags to the existing <see cref="NuGetPackage.Tags"/>.</i></p>
        /// <p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddTags(this NuGetPackage nuGetPackage, params string[] tags)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.TagsInternal.AddRange(tags);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding new tags to the existing <see cref="NuGetPackage.Tags"/>.</i></p>
        /// <p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddTags(this NuGetPackage nuGetPackage, IEnumerable<string> tags)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.TagsInternal.AddRange(tags);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="NuGetPackage.Tags"/>.</i></p>
        /// <p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage ClearTags(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.TagsInternal.Clear();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single tag to <see cref="NuGetPackage.Tags"/>.</i></p>
        /// <p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddTag(this NuGetPackage nuGetPackage, string tag)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.TagsInternal.Add(tag);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single tag from <see cref="NuGetPackage.Tags"/>.</i></p>
        /// <p>A space-delimited list of tags and keywords that describe the package and aid discoverability of packages through search and filtering mechanisms.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage RemoveTag(this NuGetPackage nuGetPackage, string tag)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.TagsInternal.Remove(tag);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.ContentFiles"/> to a new list.</i></p>
        /// <p><i>(3.3+)</i> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetContentFiles(this NuGetPackage nuGetPackage, params PackageContentFile[] contentFiles)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.ContentFilesInternal = contentFiles.ToList();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.ContentFiles"/> to a new list.</i></p>
        /// <p><i>(3.3+)</i> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetContentFiles(this NuGetPackage nuGetPackage, IEnumerable<PackageContentFile> contentFiles)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.ContentFilesInternal = contentFiles.ToList();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding new contentFiles to the existing <see cref="NuGetPackage.ContentFiles"/>.</i></p>
        /// <p><i>(3.3+)</i> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddContentFiles(this NuGetPackage nuGetPackage, params PackageContentFile[] contentFiles)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.ContentFilesInternal.AddRange(contentFiles);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding new contentFiles to the existing <see cref="NuGetPackage.ContentFiles"/>.</i></p>
        /// <p><i>(3.3+)</i> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddContentFiles(this NuGetPackage nuGetPackage, IEnumerable<PackageContentFile> contentFiles)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.ContentFilesInternal.AddRange(contentFiles);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="NuGetPackage.ContentFiles"/>.</i></p>
        /// <p><i>(3.3+)</i> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage ClearContentFiles(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.ContentFilesInternal.Clear();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single contentFile to <see cref="NuGetPackage.ContentFiles"/>.</i></p>
        /// <p><i>(3.3+)</i> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddContentFile(this NuGetPackage nuGetPackage, PackageContentFile contentFile)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.ContentFilesInternal.Add(contentFile);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single contentFile from <see cref="NuGetPackage.ContentFiles"/>.</i></p>
        /// <p><i>(3.3+)</i> A collection of &lt;files&gt; elements that identify content files that should be include in the consuming project. These files are specified with a set of attributes that describe how they should be used within the project system. See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#specifying-files-to-include-in-the-package">Specifying files to include in the package</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage RemoveContentFile(this NuGetPackage nuGetPackage, PackageContentFile contentFile)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.ContentFilesInternal.Remove(contentFile);
            return nuGetPackage;
        }
        [Pure]
        public static NuGetPackage SetDefaultDependencies(this NuGetPackage nuGetPackage, params PackageDependency[] defaultDependencies)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DefaultDependenciesInternal = defaultDependencies.ToList();
            return nuGetPackage;
        }
        [Pure]
        public static NuGetPackage SetDefaultDependencies(this NuGetPackage nuGetPackage, IEnumerable<PackageDependency> defaultDependencies)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DefaultDependenciesInternal = defaultDependencies.ToList();
            return nuGetPackage;
        }
        [Pure]
        public static NuGetPackage AddDefaultDependencies(this NuGetPackage nuGetPackage, params PackageDependency[] defaultDependencies)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DefaultDependenciesInternal.AddRange(defaultDependencies);
            return nuGetPackage;
        }
        [Pure]
        public static NuGetPackage AddDefaultDependencies(this NuGetPackage nuGetPackage, IEnumerable<PackageDependency> defaultDependencies)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DefaultDependenciesInternal.AddRange(defaultDependencies);
            return nuGetPackage;
        }
        [Pure]
        public static NuGetPackage ClearDefaultDependencies(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DefaultDependenciesInternal.Clear();
            return nuGetPackage;
        }
        [Pure]
        public static NuGetPackage AddDefaultDependency(this NuGetPackage nuGetPackage, PackageDependency defaultDependency)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DefaultDependenciesInternal.Add(defaultDependency);
            return nuGetPackage;
        }
        [Pure]
        public static NuGetPackage RemoveDefaultDependency(this NuGetPackage nuGetPackage, PackageDependency defaultDependency)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DefaultDependenciesInternal.Remove(defaultDependency);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.DependencySets"/> to a new list.</i></p>
        /// <p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <i>id</i>, <i>version</i>, <i>include</i> (3.x+), and <i>exclude</i> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetDependencySets(this NuGetPackage nuGetPackage, params PackageDependencySet[] dependencySets)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DependencySetsInternal = dependencySets.ToList();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetPackage.DependencySets"/> to a new list.</i></p>
        /// <p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <i>id</i>, <i>version</i>, <i>include</i> (3.x+), and <i>exclude</i> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage SetDependencySets(this NuGetPackage nuGetPackage, IEnumerable<PackageDependencySet> dependencySets)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DependencySetsInternal = dependencySets.ToList();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding new dependencySets to the existing <see cref="NuGetPackage.DependencySets"/>.</i></p>
        /// <p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <i>id</i>, <i>version</i>, <i>include</i> (3.x+), and <i>exclude</i> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddDependencySets(this NuGetPackage nuGetPackage, params PackageDependencySet[] dependencySets)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DependencySetsInternal.AddRange(dependencySets);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding new dependencySets to the existing <see cref="NuGetPackage.DependencySets"/>.</i></p>
        /// <p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <i>id</i>, <i>version</i>, <i>include</i> (3.x+), and <i>exclude</i> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddDependencySets(this NuGetPackage nuGetPackage, IEnumerable<PackageDependencySet> dependencySets)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DependencySetsInternal.AddRange(dependencySets);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="NuGetPackage.DependencySets"/>.</i></p>
        /// <p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <i>id</i>, <i>version</i>, <i>include</i> (3.x+), and <i>exclude</i> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage ClearDependencySets(this NuGetPackage nuGetPackage)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DependencySetsInternal.Clear();
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single dependencySet to <see cref="NuGetPackage.DependencySets"/>.</i></p>
        /// <p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <i>id</i>, <i>version</i>, <i>include</i> (3.x+), and <i>exclude</i> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage AddDependencySet(this NuGetPackage nuGetPackage, PackageDependencySet dependencySet)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DependencySetsInternal.Add(dependencySet);
            return nuGetPackage;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single dependencySet from <see cref="NuGetPackage.DependencySets"/>.</i></p>
        /// <p>A collection of zero or more &lt;dependency&gt; elements specifying the dependencies for the package. Each dependency has attributes of <i>id</i>, <i>version</i>, <i>include</i> (3.x+), and <i>exclude</i> (3.x+). See <a href="https://docs.microsoft.com/en-us/nuget/schema/nuspec#dependencies">Dependencies</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetPackage RemoveDependencySet(this NuGetPackage nuGetPackage, PackageDependencySet dependencySet)
        {
            nuGetPackage = nuGetPackage.NewInstance();
            nuGetPackage.DependencySetsInternal.Remove(dependencySet);
            return nuGetPackage;
        }
    }
}
