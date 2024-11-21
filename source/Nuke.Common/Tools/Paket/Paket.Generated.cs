// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Paket/Paket.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Paket;

/// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class PaketTasks : ToolTasks, IRequireNuGetPackage
{
    public static string PaketPath => new PaketTasks().GetToolPath();
    public const string PackageId = "Paket";
    public const string PackageExecutable = "paket.exe";
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Paket(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new PaketTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;packageId&gt;</c> via <see cref="PaketUpdateSettings.PackageId"/></li><li><c>--clean-redirects</c> via <see cref="PaketUpdateSettings.CleanRedirects"/></li><li><c>--create-new-binding-files</c> via <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></li><li><c>--filter</c> via <see cref="PaketUpdateSettings.Filter"/></li><li><c>--force</c> via <see cref="PaketUpdateSettings.Force"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketUpdateSettings.FromBootstrapper"/></li><li><c>--group</c> via <see cref="PaketUpdateSettings.DependencyGroup"/></li><li><c>--keep-major</c> via <see cref="PaketUpdateSettings.KeepMajor"/></li><li><c>--keep-minor</c> via <see cref="PaketUpdateSettings.KeepMinor"/></li><li><c>--keep-patch</c> via <see cref="PaketUpdateSettings.KeepPatch"/></li><li><c>--log-file</c> via <see cref="PaketUpdateSettings.LogFile"/></li><li><c>--no-install</c> via <see cref="PaketUpdateSettings.NoInstall"/></li><li><c>--redirects</c> via <see cref="PaketUpdateSettings.Redirects"/></li><li><c>--silent</c> via <see cref="PaketUpdateSettings.Silent"/></li><li><c>--touch-affected-refs</c> via <see cref="PaketUpdateSettings.TouchAffectedReferences"/></li><li><c>--verbose</c> via <see cref="PaketUpdateSettings.Verbose"/></li><li><c>--version</c> via <see cref="PaketUpdateSettings.PackageVersion"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PaketUpdate(PaketUpdateSettings options = null) => new PaketTasks().Run(options);
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;packageId&gt;</c> via <see cref="PaketUpdateSettings.PackageId"/></li><li><c>--clean-redirects</c> via <see cref="PaketUpdateSettings.CleanRedirects"/></li><li><c>--create-new-binding-files</c> via <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></li><li><c>--filter</c> via <see cref="PaketUpdateSettings.Filter"/></li><li><c>--force</c> via <see cref="PaketUpdateSettings.Force"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketUpdateSettings.FromBootstrapper"/></li><li><c>--group</c> via <see cref="PaketUpdateSettings.DependencyGroup"/></li><li><c>--keep-major</c> via <see cref="PaketUpdateSettings.KeepMajor"/></li><li><c>--keep-minor</c> via <see cref="PaketUpdateSettings.KeepMinor"/></li><li><c>--keep-patch</c> via <see cref="PaketUpdateSettings.KeepPatch"/></li><li><c>--log-file</c> via <see cref="PaketUpdateSettings.LogFile"/></li><li><c>--no-install</c> via <see cref="PaketUpdateSettings.NoInstall"/></li><li><c>--redirects</c> via <see cref="PaketUpdateSettings.Redirects"/></li><li><c>--silent</c> via <see cref="PaketUpdateSettings.Silent"/></li><li><c>--touch-affected-refs</c> via <see cref="PaketUpdateSettings.TouchAffectedReferences"/></li><li><c>--verbose</c> via <see cref="PaketUpdateSettings.Verbose"/></li><li><c>--version</c> via <see cref="PaketUpdateSettings.PackageVersion"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PaketUpdate(Configure<PaketUpdateSettings> configurator) => new PaketTasks().Run(configurator.Invoke(new PaketUpdateSettings()));
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;packageId&gt;</c> via <see cref="PaketUpdateSettings.PackageId"/></li><li><c>--clean-redirects</c> via <see cref="PaketUpdateSettings.CleanRedirects"/></li><li><c>--create-new-binding-files</c> via <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></li><li><c>--filter</c> via <see cref="PaketUpdateSettings.Filter"/></li><li><c>--force</c> via <see cref="PaketUpdateSettings.Force"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketUpdateSettings.FromBootstrapper"/></li><li><c>--group</c> via <see cref="PaketUpdateSettings.DependencyGroup"/></li><li><c>--keep-major</c> via <see cref="PaketUpdateSettings.KeepMajor"/></li><li><c>--keep-minor</c> via <see cref="PaketUpdateSettings.KeepMinor"/></li><li><c>--keep-patch</c> via <see cref="PaketUpdateSettings.KeepPatch"/></li><li><c>--log-file</c> via <see cref="PaketUpdateSettings.LogFile"/></li><li><c>--no-install</c> via <see cref="PaketUpdateSettings.NoInstall"/></li><li><c>--redirects</c> via <see cref="PaketUpdateSettings.Redirects"/></li><li><c>--silent</c> via <see cref="PaketUpdateSettings.Silent"/></li><li><c>--touch-affected-refs</c> via <see cref="PaketUpdateSettings.TouchAffectedReferences"/></li><li><c>--verbose</c> via <see cref="PaketUpdateSettings.Verbose"/></li><li><c>--version</c> via <see cref="PaketUpdateSettings.PackageVersion"/></li></ul></remarks>
    public static IEnumerable<(PaketUpdateSettings Settings, IReadOnlyCollection<Output> Output)> PaketUpdate(CombinatorialConfigure<PaketUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PaketUpdate, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--fail-on-checks</c> via <see cref="PaketRestoreSettings.FailOnChecks"/></li><li><c>--force</c> via <see cref="PaketRestoreSettings.Force"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketRestoreSettings.FromBootstrapper"/></li><li><c>--group</c> via <see cref="PaketRestoreSettings.DependencyGroup"/></li><li><c>--ignore-checks</c> via <see cref="PaketRestoreSettings.IgnoreChecks"/></li><li><c>--log-file</c> via <see cref="PaketRestoreSettings.LogFile"/></li><li><c>--only-referenced</c> via <see cref="PaketRestoreSettings.OnlyReferenced"/></li><li><c>--project</c> via <see cref="PaketRestoreSettings.ProjectFile"/></li><li><c>--references-files</c> via <see cref="PaketRestoreSettings.ReferencesFiles"/></li><li><c>--silent</c> via <see cref="PaketRestoreSettings.Silent"/></li><li><c>--target-framework</c> via <see cref="PaketRestoreSettings.TargetFramework"/></li><li><c>--touch-affected-refs</c> via <see cref="PaketRestoreSettings.TouchAffectedRefs"/></li><li><c>--verbose</c> via <see cref="PaketRestoreSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PaketRestore(PaketRestoreSettings options = null) => new PaketTasks().Run(options);
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--fail-on-checks</c> via <see cref="PaketRestoreSettings.FailOnChecks"/></li><li><c>--force</c> via <see cref="PaketRestoreSettings.Force"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketRestoreSettings.FromBootstrapper"/></li><li><c>--group</c> via <see cref="PaketRestoreSettings.DependencyGroup"/></li><li><c>--ignore-checks</c> via <see cref="PaketRestoreSettings.IgnoreChecks"/></li><li><c>--log-file</c> via <see cref="PaketRestoreSettings.LogFile"/></li><li><c>--only-referenced</c> via <see cref="PaketRestoreSettings.OnlyReferenced"/></li><li><c>--project</c> via <see cref="PaketRestoreSettings.ProjectFile"/></li><li><c>--references-files</c> via <see cref="PaketRestoreSettings.ReferencesFiles"/></li><li><c>--silent</c> via <see cref="PaketRestoreSettings.Silent"/></li><li><c>--target-framework</c> via <see cref="PaketRestoreSettings.TargetFramework"/></li><li><c>--touch-affected-refs</c> via <see cref="PaketRestoreSettings.TouchAffectedRefs"/></li><li><c>--verbose</c> via <see cref="PaketRestoreSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PaketRestore(Configure<PaketRestoreSettings> configurator) => new PaketTasks().Run(configurator.Invoke(new PaketRestoreSettings()));
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--fail-on-checks</c> via <see cref="PaketRestoreSettings.FailOnChecks"/></li><li><c>--force</c> via <see cref="PaketRestoreSettings.Force"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketRestoreSettings.FromBootstrapper"/></li><li><c>--group</c> via <see cref="PaketRestoreSettings.DependencyGroup"/></li><li><c>--ignore-checks</c> via <see cref="PaketRestoreSettings.IgnoreChecks"/></li><li><c>--log-file</c> via <see cref="PaketRestoreSettings.LogFile"/></li><li><c>--only-referenced</c> via <see cref="PaketRestoreSettings.OnlyReferenced"/></li><li><c>--project</c> via <see cref="PaketRestoreSettings.ProjectFile"/></li><li><c>--references-files</c> via <see cref="PaketRestoreSettings.ReferencesFiles"/></li><li><c>--silent</c> via <see cref="PaketRestoreSettings.Silent"/></li><li><c>--target-framework</c> via <see cref="PaketRestoreSettings.TargetFramework"/></li><li><c>--touch-affected-refs</c> via <see cref="PaketRestoreSettings.TouchAffectedRefs"/></li><li><c>--verbose</c> via <see cref="PaketRestoreSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PaketRestoreSettings Settings, IReadOnlyCollection<Output> Output)> PaketRestore(CombinatorialConfigure<PaketRestoreSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PaketRestore, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--api-key</c> via <see cref="PaketPushSettings.ApiKey"/></li><li><c>--endpoint</c> via <see cref="PaketPushSettings.Endpoint"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketPushSettings.FromBootstrapper"/></li><li><c>--log-file</c> via <see cref="PaketPushSettings.LogFile"/></li><li><c>--silent</c> via <see cref="PaketPushSettings.Silent"/></li><li><c>--url</c> via <see cref="PaketPushSettings.Url"/></li><li><c>--verbose</c> via <see cref="PaketPushSettings.Verbose"/></li><li><c>file</c> via <see cref="PaketPushSettings.File"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PaketPush(PaketPushSettings options = null) => new PaketTasks().Run(options);
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--api-key</c> via <see cref="PaketPushSettings.ApiKey"/></li><li><c>--endpoint</c> via <see cref="PaketPushSettings.Endpoint"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketPushSettings.FromBootstrapper"/></li><li><c>--log-file</c> via <see cref="PaketPushSettings.LogFile"/></li><li><c>--silent</c> via <see cref="PaketPushSettings.Silent"/></li><li><c>--url</c> via <see cref="PaketPushSettings.Url"/></li><li><c>--verbose</c> via <see cref="PaketPushSettings.Verbose"/></li><li><c>file</c> via <see cref="PaketPushSettings.File"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PaketPush(Configure<PaketPushSettings> configurator) => new PaketTasks().Run(configurator.Invoke(new PaketPushSettings()));
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--api-key</c> via <see cref="PaketPushSettings.ApiKey"/></li><li><c>--endpoint</c> via <see cref="PaketPushSettings.Endpoint"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketPushSettings.FromBootstrapper"/></li><li><c>--log-file</c> via <see cref="PaketPushSettings.LogFile"/></li><li><c>--silent</c> via <see cref="PaketPushSettings.Silent"/></li><li><c>--url</c> via <see cref="PaketPushSettings.Url"/></li><li><c>--verbose</c> via <see cref="PaketPushSettings.Verbose"/></li><li><c>file</c> via <see cref="PaketPushSettings.File"/></li></ul></remarks>
    public static IEnumerable<(PaketPushSettings Settings, IReadOnlyCollection<Output> Output)> PaketPush(CombinatorialConfigure<PaketPushSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PaketPush, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;outputDirectory&gt;</c> via <see cref="PaketPackSettings.OutputDirectory"/></li><li><c>--build-config</c> via <see cref="PaketPackSettings.BuildConfiguration"/></li><li><c>--build-platform</c> via <see cref="PaketPackSettings.BuildPlatform"/></li><li><c>--exclude</c> via <see cref="PaketPackSettings.Exclude"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketPackSettings.FromBootstrapper"/></li><li><c>--include-referenced-projects</c> via <see cref="PaketPackSettings.IncludeReferencedProjects"/></li><li><c>--lock-dependencies</c> via <see cref="PaketPackSettings.LockDependencies"/></li><li><c>--log-file</c> via <see cref="PaketPackSettings.LogFile"/></li><li><c>--minimum-from-lock-file</c> via <see cref="PaketPackSettings.MinimumFromLockFile"/></li><li><c>--pin-project-references</c> via <see cref="PaketPackSettings.PinProjectReferences"/></li><li><c>--project-url</c> via <see cref="PaketPackSettings.ProjectUrl"/></li><li><c>--release-notes</c> via <see cref="PaketPackSettings.ReleaseNotes"/></li><li><c>--silent</c> via <see cref="PaketPackSettings.Silent"/></li><li><c>--specific-version</c> via <see cref="PaketPackSettings.SpecificVersions"/></li><li><c>--symbols</c> via <see cref="PaketPackSettings.Symbols"/></li><li><c>--template</c> via <see cref="PaketPackSettings.TemplateFile"/></li><li><c>--verbose</c> via <see cref="PaketPackSettings.Verbose"/></li><li><c>--version</c> via <see cref="PaketPackSettings.PackageVersion"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PaketPack(PaketPackSettings options = null) => new PaketTasks().Run(options);
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;outputDirectory&gt;</c> via <see cref="PaketPackSettings.OutputDirectory"/></li><li><c>--build-config</c> via <see cref="PaketPackSettings.BuildConfiguration"/></li><li><c>--build-platform</c> via <see cref="PaketPackSettings.BuildPlatform"/></li><li><c>--exclude</c> via <see cref="PaketPackSettings.Exclude"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketPackSettings.FromBootstrapper"/></li><li><c>--include-referenced-projects</c> via <see cref="PaketPackSettings.IncludeReferencedProjects"/></li><li><c>--lock-dependencies</c> via <see cref="PaketPackSettings.LockDependencies"/></li><li><c>--log-file</c> via <see cref="PaketPackSettings.LogFile"/></li><li><c>--minimum-from-lock-file</c> via <see cref="PaketPackSettings.MinimumFromLockFile"/></li><li><c>--pin-project-references</c> via <see cref="PaketPackSettings.PinProjectReferences"/></li><li><c>--project-url</c> via <see cref="PaketPackSettings.ProjectUrl"/></li><li><c>--release-notes</c> via <see cref="PaketPackSettings.ReleaseNotes"/></li><li><c>--silent</c> via <see cref="PaketPackSettings.Silent"/></li><li><c>--specific-version</c> via <see cref="PaketPackSettings.SpecificVersions"/></li><li><c>--symbols</c> via <see cref="PaketPackSettings.Symbols"/></li><li><c>--template</c> via <see cref="PaketPackSettings.TemplateFile"/></li><li><c>--verbose</c> via <see cref="PaketPackSettings.Verbose"/></li><li><c>--version</c> via <see cref="PaketPackSettings.PackageVersion"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PaketPack(Configure<PaketPackSettings> configurator) => new PaketTasks().Run(configurator.Invoke(new PaketPackSettings()));
    /// <summary><p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p><p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;outputDirectory&gt;</c> via <see cref="PaketPackSettings.OutputDirectory"/></li><li><c>--build-config</c> via <see cref="PaketPackSettings.BuildConfiguration"/></li><li><c>--build-platform</c> via <see cref="PaketPackSettings.BuildPlatform"/></li><li><c>--exclude</c> via <see cref="PaketPackSettings.Exclude"/></li><li><c>--from-bootstrapper</c> via <see cref="PaketPackSettings.FromBootstrapper"/></li><li><c>--include-referenced-projects</c> via <see cref="PaketPackSettings.IncludeReferencedProjects"/></li><li><c>--lock-dependencies</c> via <see cref="PaketPackSettings.LockDependencies"/></li><li><c>--log-file</c> via <see cref="PaketPackSettings.LogFile"/></li><li><c>--minimum-from-lock-file</c> via <see cref="PaketPackSettings.MinimumFromLockFile"/></li><li><c>--pin-project-references</c> via <see cref="PaketPackSettings.PinProjectReferences"/></li><li><c>--project-url</c> via <see cref="PaketPackSettings.ProjectUrl"/></li><li><c>--release-notes</c> via <see cref="PaketPackSettings.ReleaseNotes"/></li><li><c>--silent</c> via <see cref="PaketPackSettings.Silent"/></li><li><c>--specific-version</c> via <see cref="PaketPackSettings.SpecificVersions"/></li><li><c>--symbols</c> via <see cref="PaketPackSettings.Symbols"/></li><li><c>--template</c> via <see cref="PaketPackSettings.TemplateFile"/></li><li><c>--verbose</c> via <see cref="PaketPackSettings.Verbose"/></li><li><c>--version</c> via <see cref="PaketPackSettings.PackageVersion"/></li></ul></remarks>
    public static IEnumerable<(PaketPackSettings Settings, IReadOnlyCollection<Output> Output)> PaketPack(CombinatorialConfigure<PaketPackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PaketPack, degreeOfParallelism, completeOnFailure);
}
#region PaketUpdateSettings
/// <summary>Used within <see cref="PaketTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PaketUpdateSettings>))]
[Command(Type = typeof(PaketTasks), Command = nameof(PaketTasks.PaketUpdate), Arguments = "update")]
public partial class PaketUpdateSettings : ToolOptions
{
    /// <summary>NuGet package ID.</summary>
    [Argument(Format = "{value}", Position = 1)] public string PackageId => Get<string>(() => PackageId);
    /// <summary>Dependency version constraint.</summary>
    [Argument(Format = "--version {value}")] public string PackageVersion => Get<string>(() => PackageVersion);
    /// <summary>Dependency group to update. Default is <em>all groups</em>.</summary>
    [Argument(Format = "--group {value}")] public string DependencyGroup => Get<string>(() => DependencyGroup);
    /// <summary>Creates binding redirect files if needed.</summary>
    [Argument(Format = "--create-new-binding-files")] public bool? CreateNewBindingFiles => Get<bool?>(() => CreateNewBindingFiles);
    /// <summary>Force download and reinstallation of all dependencies.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Create binding redirects.</summary>
    [Argument(Format = "--redirects")] public bool? Redirects => Get<bool?>(() => Redirects);
    /// <summary>Remove binding redirects that were not created by Paket.</summary>
    [Argument(Format = "--clean-redirects")] public bool? CleanRedirects => Get<bool?>(() => CleanRedirects);
    /// <summary>Do not modify projects.</summary>
    [Argument(Format = "--no-install")] public bool? NoInstall => Get<bool?>(() => NoInstall);
    /// <summary>Only allow updates that preserve the major version.</summary>
    [Argument(Format = "--keep-major")] public bool? KeepMajor => Get<bool?>(() => KeepMajor);
    /// <summary>Only allow updates that preserve the minor version.</summary>
    [Argument(Format = "--keep-minor")] public bool? KeepMinor => Get<bool?>(() => KeepMinor);
    /// <summary>Only allow updates that preserve the patch version.</summary>
    [Argument(Format = "--keep-patch")] public bool? KeepPatch => Get<bool?>(() => KeepPatch);
    /// <summary>Treat the NuGet package ID as a regex to filter packages.</summary>
    [Argument(Format = "--filter")] public bool? Filter => Get<bool?>(() => Filter);
    /// <summary>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</summary>
    [Argument(Format = "--touch-affected-refs")] public bool? TouchAffectedReferences => Get<bool?>(() => TouchAffectedReferences);
    /// <summary>Suppress console output.</summary>
    [Argument(Format = "--silent")] public bool? Silent => Get<bool?>(() => Silent);
    /// <summary>Print detailed information to the console.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Print output to a file.</summary>
    [Argument(Format = "--log-file {value}")] public string LogFile => Get<string>(() => LogFile);
    /// <summary>Call coming from the <c>--run</c> feature of the bootstrapper.</summary>
    [Argument(Format = "--from-bootstrapper")] public bool? FromBootstrapper => Get<bool?>(() => FromBootstrapper);
}
#endregion
#region PaketRestoreSettings
/// <summary>Used within <see cref="PaketTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PaketRestoreSettings>))]
[Command(Type = typeof(PaketTasks), Command = nameof(PaketTasks.PaketRestore), Arguments = "restore")]
public partial class PaketRestoreSettings : ToolOptions
{
    /// <summary>Force download and reinstallation of all dependencies.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Only restore packages that are referenced by paket.references files.</summary>
    [Argument(Format = "--only-referenced")] public bool? OnlyReferenced => Get<bool?>(() => OnlyReferenced);
    /// <summary>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</summary>
    [Argument(Format = "--touch-affected-refs")] public bool? TouchAffectedRefs => Get<bool?>(() => TouchAffectedRefs);
    /// <summary>Do not check if paket.dependencies and paket.lock are in sync.</summary>
    [Argument(Format = "--ignore-checks")] public bool? IgnoreChecks => Get<bool?>(() => IgnoreChecks);
    /// <summary>Abort if any checks fail.</summary>
    [Argument(Format = "--fail-on-checks")] public bool? FailOnChecks => Get<bool?>(() => FailOnChecks);
    /// <summary>Restore dependencies of a single group.</summary>
    [Argument(Format = "--group {value}")] public string DependencyGroup => Get<string>(() => DependencyGroup);
    /// <summary>Restore dependencies of a single project.</summary>
    [Argument(Format = "--project {value}")] public string ProjectFile => Get<string>(() => ProjectFile);
    /// <summary>Restore packages from a paket.references file.</summary>
    [Argument(Format = "--references-files {value}")] public IReadOnlyList<string> ReferencesFiles => Get<List<string>>(() => ReferencesFiles);
    /// <summary>Restore only for the specified target framework.</summary>
    [Argument(Format = "--target-framework {value}")] public string TargetFramework => Get<string>(() => TargetFramework);
    /// <summary>Suppress console output.</summary>
    [Argument(Format = "--silent")] public bool? Silent => Get<bool?>(() => Silent);
    /// <summary>Print detailed information to the console.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Print output to a file.</summary>
    [Argument(Format = "--log-file {value}")] public string LogFile => Get<string>(() => LogFile);
    /// <summary>Call coming from the <c>--run</c> feature of the bootstrapper.</summary>
    [Argument(Format = "--from-bootstrapper")] public bool? FromBootstrapper => Get<bool?>(() => FromBootstrapper);
}
#endregion
#region PaketPushSettings
/// <summary>Used within <see cref="PaketTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PaketPushSettings>))]
[Command(Type = typeof(PaketTasks), Command = nameof(PaketTasks.PaketPush), Arguments = "push")]
public partial class PaketPushSettings : ToolOptions
{
    /// <summary>Path to the package.</summary>
    [Argument(Format = "file {value}")] public string File => Get<string>(() => File);
    /// <summary>URL of the NuGet feed.</summary>
    [Argument(Format = "--url {value}")] public string Url => Get<string>(() => Url);
    /// <summary>API key for the URL. Default is the <c>NUGET_KEY</c> environment variable.</summary>
    [Argument(Format = "--api-key {value}", Secret = true)] public string ApiKey => Get<string>(() => ApiKey);
    /// <summary>API endpoint to push to. Default is <em>/api/v2/package</em>.</summary>
    [Argument(Format = "--endpoint {value}")] public string Endpoint => Get<string>(() => Endpoint);
    /// <summary>Suppress console output.</summary>
    [Argument(Format = "--silent")] public bool? Silent => Get<bool?>(() => Silent);
    /// <summary>Print detailed information to the console.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Print output to a file.</summary>
    [Argument(Format = "--log-file {value}")] public string LogFile => Get<string>(() => LogFile);
    /// <summary>Call coming from the <c>--run</c> feature of the bootstrapper.</summary>
    [Argument(Format = "--from-bootstrapper")] public bool? FromBootstrapper => Get<bool?>(() => FromBootstrapper);
}
#endregion
#region PaketPackSettings
/// <summary>Used within <see cref="PaketTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PaketPackSettings>))]
[Command(Type = typeof(PaketTasks), Command = nameof(PaketTasks.PaketPack), Arguments = "pack")]
public partial class PaketPackSettings : ToolOptions
{
    /// <summary>Output directory for .nupkg files.</summary>
    [Argument(Format = "{value}", Position = 1)] public string OutputDirectory => Get<string>(() => OutputDirectory);
    /// <summary>Build configuration that should be packaged. Default is <em>Release</em>.</summary>
    [Argument(Format = "--build-config {value}")] public string BuildConfiguration => Get<string>(() => BuildConfiguration);
    /// <summary>Build platform that should be packaged. Default is <em>check all known platform targets</em>.</summary>
    [Argument(Format = "--build-platform {value}")] public string BuildPlatform => Get<string>(() => BuildPlatform);
    /// <summary>Version of the package.</summary>
    [Argument(Format = "--version {value}")] public string PackageVersion => Get<string>(() => PackageVersion);
    /// <summary>Pack a single paket.template file.</summary>
    [Argument(Format = "--template {value}")] public string TemplateFile => Get<string>(() => TemplateFile);
    /// <summary>Exclude paket.template file by package ID.</summary>
    [Argument(Format = "--exclude {value}")] public IReadOnlyList<string> Exclude => Get<List<string>>(() => Exclude);
    /// <summary>Package IDs with version numbers.</summary>
    [Argument(Format = "--specific-version {key} {value}")] public IReadOnlyDictionary<string, string> SpecificVersions => Get<Dictionary<string, string>>(() => SpecificVersions);
    /// <summary>Specify release notes for the package.</summary>
    [Argument(Format = "--release-notes {value}")] public string ReleaseNotes => Get<string>(() => ReleaseNotes);
    /// <summary>Use version requirements from paket.lock instead of paket.dependencies.</summary>
    [Argument(Format = "--lock-dependencies")] public bool? LockDependencies => Get<bool?>(() => LockDependencies);
    /// <summary>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</summary>
    [Argument(Format = "--minimum-from-lock-file")] public bool? MinimumFromLockFile => Get<bool?>(() => MinimumFromLockFile);
    /// <summary>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</summary>
    [Argument(Format = "--pin-project-references")] public bool? PinProjectReferences => Get<bool?>(() => PinProjectReferences);
    /// <summary>Build symbol/source packages in addition to library/content packages.</summary>
    [Argument(Format = "--symbols")] public bool? Symbols => Get<bool?>(() => Symbols);
    /// <summary>Include symbol/source from referenced projects.</summary>
    [Argument(Format = "--include-referenced-projects")] public bool? IncludeReferencedProjects => Get<bool?>(() => IncludeReferencedProjects);
    /// <summary>Url to the projects home page.</summary>
    [Argument(Format = "--project-url {value}")] public string ProjectUrl => Get<string>(() => ProjectUrl);
    /// <summary>Suppress console output.</summary>
    [Argument(Format = "--silent")] public bool? Silent => Get<bool?>(() => Silent);
    /// <summary>Print detailed information to the console.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Print output to a file.</summary>
    [Argument(Format = "--log-file {value}")] public string LogFile => Get<string>(() => LogFile);
    /// <summary>Call coming from the <c>--run</c> feature of the bootstrapper.</summary>
    [Argument(Format = "--from-bootstrapper")] public bool? FromBootstrapper => Get<bool?>(() => FromBootstrapper);
}
#endregion
#region PaketUpdateSettingsExtensions
/// <summary>Used within <see cref="PaketTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PaketUpdateSettingsExtensions
{
    #region PackageId
    /// <inheritdoc cref="PaketUpdateSettings.PackageId"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.PackageId))]
    public static T SetPackageId<T>(this T o, string v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.PackageId, v));
    /// <inheritdoc cref="PaketUpdateSettings.PackageId"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.PackageId))]
    public static T ResetPackageId<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.PackageId));
    #endregion
    #region PackageVersion
    /// <inheritdoc cref="PaketUpdateSettings.PackageVersion"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.PackageVersion))]
    public static T SetPackageVersion<T>(this T o, string v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.PackageVersion, v));
    /// <inheritdoc cref="PaketUpdateSettings.PackageVersion"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.PackageVersion))]
    public static T ResetPackageVersion<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.PackageVersion));
    #endregion
    #region DependencyGroup
    /// <inheritdoc cref="PaketUpdateSettings.DependencyGroup"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.DependencyGroup))]
    public static T SetDependencyGroup<T>(this T o, string v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.DependencyGroup, v));
    /// <inheritdoc cref="PaketUpdateSettings.DependencyGroup"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.DependencyGroup))]
    public static T ResetDependencyGroup<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.DependencyGroup));
    #endregion
    #region CreateNewBindingFiles
    /// <inheritdoc cref="PaketUpdateSettings.CreateNewBindingFiles"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.CreateNewBindingFiles))]
    public static T SetCreateNewBindingFiles<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.CreateNewBindingFiles, v));
    /// <inheritdoc cref="PaketUpdateSettings.CreateNewBindingFiles"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.CreateNewBindingFiles))]
    public static T ResetCreateNewBindingFiles<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.CreateNewBindingFiles));
    /// <inheritdoc cref="PaketUpdateSettings.CreateNewBindingFiles"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.CreateNewBindingFiles))]
    public static T EnableCreateNewBindingFiles<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.CreateNewBindingFiles, true));
    /// <inheritdoc cref="PaketUpdateSettings.CreateNewBindingFiles"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.CreateNewBindingFiles))]
    public static T DisableCreateNewBindingFiles<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.CreateNewBindingFiles, false));
    /// <inheritdoc cref="PaketUpdateSettings.CreateNewBindingFiles"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.CreateNewBindingFiles))]
    public static T ToggleCreateNewBindingFiles<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.CreateNewBindingFiles, !o.CreateNewBindingFiles));
    #endregion
    #region Force
    /// <inheritdoc cref="PaketUpdateSettings.Force"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="PaketUpdateSettings.Force"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Force))]
    public static T ResetForce<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="PaketUpdateSettings.Force"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Force))]
    public static T EnableForce<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="PaketUpdateSettings.Force"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Force))]
    public static T DisableForce<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="PaketUpdateSettings.Force"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region Redirects
    /// <inheritdoc cref="PaketUpdateSettings.Redirects"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Redirects))]
    public static T SetRedirects<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Redirects, v));
    /// <inheritdoc cref="PaketUpdateSettings.Redirects"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Redirects))]
    public static T ResetRedirects<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.Redirects));
    /// <inheritdoc cref="PaketUpdateSettings.Redirects"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Redirects))]
    public static T EnableRedirects<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Redirects, true));
    /// <inheritdoc cref="PaketUpdateSettings.Redirects"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Redirects))]
    public static T DisableRedirects<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Redirects, false));
    /// <inheritdoc cref="PaketUpdateSettings.Redirects"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Redirects))]
    public static T ToggleRedirects<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Redirects, !o.Redirects));
    #endregion
    #region CleanRedirects
    /// <inheritdoc cref="PaketUpdateSettings.CleanRedirects"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.CleanRedirects))]
    public static T SetCleanRedirects<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.CleanRedirects, v));
    /// <inheritdoc cref="PaketUpdateSettings.CleanRedirects"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.CleanRedirects))]
    public static T ResetCleanRedirects<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.CleanRedirects));
    /// <inheritdoc cref="PaketUpdateSettings.CleanRedirects"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.CleanRedirects))]
    public static T EnableCleanRedirects<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.CleanRedirects, true));
    /// <inheritdoc cref="PaketUpdateSettings.CleanRedirects"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.CleanRedirects))]
    public static T DisableCleanRedirects<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.CleanRedirects, false));
    /// <inheritdoc cref="PaketUpdateSettings.CleanRedirects"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.CleanRedirects))]
    public static T ToggleCleanRedirects<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.CleanRedirects, !o.CleanRedirects));
    #endregion
    #region NoInstall
    /// <inheritdoc cref="PaketUpdateSettings.NoInstall"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.NoInstall))]
    public static T SetNoInstall<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.NoInstall, v));
    /// <inheritdoc cref="PaketUpdateSettings.NoInstall"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.NoInstall))]
    public static T ResetNoInstall<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.NoInstall));
    /// <inheritdoc cref="PaketUpdateSettings.NoInstall"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.NoInstall))]
    public static T EnableNoInstall<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.NoInstall, true));
    /// <inheritdoc cref="PaketUpdateSettings.NoInstall"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.NoInstall))]
    public static T DisableNoInstall<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.NoInstall, false));
    /// <inheritdoc cref="PaketUpdateSettings.NoInstall"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.NoInstall))]
    public static T ToggleNoInstall<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.NoInstall, !o.NoInstall));
    #endregion
    #region KeepMajor
    /// <inheritdoc cref="PaketUpdateSettings.KeepMajor"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepMajor))]
    public static T SetKeepMajor<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepMajor, v));
    /// <inheritdoc cref="PaketUpdateSettings.KeepMajor"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepMajor))]
    public static T ResetKeepMajor<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.KeepMajor));
    /// <inheritdoc cref="PaketUpdateSettings.KeepMajor"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepMajor))]
    public static T EnableKeepMajor<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepMajor, true));
    /// <inheritdoc cref="PaketUpdateSettings.KeepMajor"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepMajor))]
    public static T DisableKeepMajor<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepMajor, false));
    /// <inheritdoc cref="PaketUpdateSettings.KeepMajor"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepMajor))]
    public static T ToggleKeepMajor<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepMajor, !o.KeepMajor));
    #endregion
    #region KeepMinor
    /// <inheritdoc cref="PaketUpdateSettings.KeepMinor"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepMinor))]
    public static T SetKeepMinor<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepMinor, v));
    /// <inheritdoc cref="PaketUpdateSettings.KeepMinor"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepMinor))]
    public static T ResetKeepMinor<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.KeepMinor));
    /// <inheritdoc cref="PaketUpdateSettings.KeepMinor"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepMinor))]
    public static T EnableKeepMinor<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepMinor, true));
    /// <inheritdoc cref="PaketUpdateSettings.KeepMinor"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepMinor))]
    public static T DisableKeepMinor<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepMinor, false));
    /// <inheritdoc cref="PaketUpdateSettings.KeepMinor"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepMinor))]
    public static T ToggleKeepMinor<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepMinor, !o.KeepMinor));
    #endregion
    #region KeepPatch
    /// <inheritdoc cref="PaketUpdateSettings.KeepPatch"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepPatch))]
    public static T SetKeepPatch<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepPatch, v));
    /// <inheritdoc cref="PaketUpdateSettings.KeepPatch"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepPatch))]
    public static T ResetKeepPatch<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.KeepPatch));
    /// <inheritdoc cref="PaketUpdateSettings.KeepPatch"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepPatch))]
    public static T EnableKeepPatch<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepPatch, true));
    /// <inheritdoc cref="PaketUpdateSettings.KeepPatch"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepPatch))]
    public static T DisableKeepPatch<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepPatch, false));
    /// <inheritdoc cref="PaketUpdateSettings.KeepPatch"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.KeepPatch))]
    public static T ToggleKeepPatch<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.KeepPatch, !o.KeepPatch));
    #endregion
    #region Filter
    /// <inheritdoc cref="PaketUpdateSettings.Filter"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Filter))]
    public static T SetFilter<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Filter, v));
    /// <inheritdoc cref="PaketUpdateSettings.Filter"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Filter))]
    public static T ResetFilter<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.Filter));
    /// <inheritdoc cref="PaketUpdateSettings.Filter"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Filter))]
    public static T EnableFilter<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Filter, true));
    /// <inheritdoc cref="PaketUpdateSettings.Filter"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Filter))]
    public static T DisableFilter<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Filter, false));
    /// <inheritdoc cref="PaketUpdateSettings.Filter"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Filter))]
    public static T ToggleFilter<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Filter, !o.Filter));
    #endregion
    #region TouchAffectedReferences
    /// <inheritdoc cref="PaketUpdateSettings.TouchAffectedReferences"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.TouchAffectedReferences))]
    public static T SetTouchAffectedReferences<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.TouchAffectedReferences, v));
    /// <inheritdoc cref="PaketUpdateSettings.TouchAffectedReferences"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.TouchAffectedReferences))]
    public static T ResetTouchAffectedReferences<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.TouchAffectedReferences));
    /// <inheritdoc cref="PaketUpdateSettings.TouchAffectedReferences"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.TouchAffectedReferences))]
    public static T EnableTouchAffectedReferences<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.TouchAffectedReferences, true));
    /// <inheritdoc cref="PaketUpdateSettings.TouchAffectedReferences"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.TouchAffectedReferences))]
    public static T DisableTouchAffectedReferences<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.TouchAffectedReferences, false));
    /// <inheritdoc cref="PaketUpdateSettings.TouchAffectedReferences"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.TouchAffectedReferences))]
    public static T ToggleTouchAffectedReferences<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.TouchAffectedReferences, !o.TouchAffectedReferences));
    #endregion
    #region Silent
    /// <inheritdoc cref="PaketUpdateSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Silent))]
    public static T SetSilent<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Silent, v));
    /// <inheritdoc cref="PaketUpdateSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Silent))]
    public static T ResetSilent<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.Silent));
    /// <inheritdoc cref="PaketUpdateSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Silent))]
    public static T EnableSilent<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Silent, true));
    /// <inheritdoc cref="PaketUpdateSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Silent))]
    public static T DisableSilent<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Silent, false));
    /// <inheritdoc cref="PaketUpdateSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Silent))]
    public static T ToggleSilent<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Silent, !o.Silent));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PaketUpdateSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PaketUpdateSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="PaketUpdateSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="PaketUpdateSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="PaketUpdateSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region LogFile
    /// <inheritdoc cref="PaketUpdateSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="PaketUpdateSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
    #region FromBootstrapper
    /// <inheritdoc cref="PaketUpdateSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.FromBootstrapper))]
    public static T SetFromBootstrapper<T>(this T o, bool? v) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, v));
    /// <inheritdoc cref="PaketUpdateSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.FromBootstrapper))]
    public static T ResetFromBootstrapper<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Remove(() => o.FromBootstrapper));
    /// <inheritdoc cref="PaketUpdateSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.FromBootstrapper))]
    public static T EnableFromBootstrapper<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, true));
    /// <inheritdoc cref="PaketUpdateSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.FromBootstrapper))]
    public static T DisableFromBootstrapper<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, false));
    /// <inheritdoc cref="PaketUpdateSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketUpdateSettings), Property = nameof(PaketUpdateSettings.FromBootstrapper))]
    public static T ToggleFromBootstrapper<T>(this T o) where T : PaketUpdateSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, !o.FromBootstrapper));
    #endregion
}
#endregion
#region PaketRestoreSettingsExtensions
/// <summary>Used within <see cref="PaketTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PaketRestoreSettingsExtensions
{
    #region Force
    /// <inheritdoc cref="PaketRestoreSettings.Force"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="PaketRestoreSettings.Force"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Force))]
    public static T ResetForce<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="PaketRestoreSettings.Force"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Force))]
    public static T EnableForce<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="PaketRestoreSettings.Force"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Force))]
    public static T DisableForce<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="PaketRestoreSettings.Force"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region OnlyReferenced
    /// <inheritdoc cref="PaketRestoreSettings.OnlyReferenced"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.OnlyReferenced))]
    public static T SetOnlyReferenced<T>(this T o, bool? v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.OnlyReferenced, v));
    /// <inheritdoc cref="PaketRestoreSettings.OnlyReferenced"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.OnlyReferenced))]
    public static T ResetOnlyReferenced<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.OnlyReferenced));
    /// <inheritdoc cref="PaketRestoreSettings.OnlyReferenced"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.OnlyReferenced))]
    public static T EnableOnlyReferenced<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.OnlyReferenced, true));
    /// <inheritdoc cref="PaketRestoreSettings.OnlyReferenced"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.OnlyReferenced))]
    public static T DisableOnlyReferenced<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.OnlyReferenced, false));
    /// <inheritdoc cref="PaketRestoreSettings.OnlyReferenced"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.OnlyReferenced))]
    public static T ToggleOnlyReferenced<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.OnlyReferenced, !o.OnlyReferenced));
    #endregion
    #region TouchAffectedRefs
    /// <inheritdoc cref="PaketRestoreSettings.TouchAffectedRefs"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.TouchAffectedRefs))]
    public static T SetTouchAffectedRefs<T>(this T o, bool? v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.TouchAffectedRefs, v));
    /// <inheritdoc cref="PaketRestoreSettings.TouchAffectedRefs"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.TouchAffectedRefs))]
    public static T ResetTouchAffectedRefs<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.TouchAffectedRefs));
    /// <inheritdoc cref="PaketRestoreSettings.TouchAffectedRefs"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.TouchAffectedRefs))]
    public static T EnableTouchAffectedRefs<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.TouchAffectedRefs, true));
    /// <inheritdoc cref="PaketRestoreSettings.TouchAffectedRefs"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.TouchAffectedRefs))]
    public static T DisableTouchAffectedRefs<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.TouchAffectedRefs, false));
    /// <inheritdoc cref="PaketRestoreSettings.TouchAffectedRefs"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.TouchAffectedRefs))]
    public static T ToggleTouchAffectedRefs<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.TouchAffectedRefs, !o.TouchAffectedRefs));
    #endregion
    #region IgnoreChecks
    /// <inheritdoc cref="PaketRestoreSettings.IgnoreChecks"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.IgnoreChecks))]
    public static T SetIgnoreChecks<T>(this T o, bool? v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.IgnoreChecks, v));
    /// <inheritdoc cref="PaketRestoreSettings.IgnoreChecks"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.IgnoreChecks))]
    public static T ResetIgnoreChecks<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.IgnoreChecks));
    /// <inheritdoc cref="PaketRestoreSettings.IgnoreChecks"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.IgnoreChecks))]
    public static T EnableIgnoreChecks<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.IgnoreChecks, true));
    /// <inheritdoc cref="PaketRestoreSettings.IgnoreChecks"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.IgnoreChecks))]
    public static T DisableIgnoreChecks<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.IgnoreChecks, false));
    /// <inheritdoc cref="PaketRestoreSettings.IgnoreChecks"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.IgnoreChecks))]
    public static T ToggleIgnoreChecks<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.IgnoreChecks, !o.IgnoreChecks));
    #endregion
    #region FailOnChecks
    /// <inheritdoc cref="PaketRestoreSettings.FailOnChecks"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.FailOnChecks))]
    public static T SetFailOnChecks<T>(this T o, bool? v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.FailOnChecks, v));
    /// <inheritdoc cref="PaketRestoreSettings.FailOnChecks"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.FailOnChecks))]
    public static T ResetFailOnChecks<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.FailOnChecks));
    /// <inheritdoc cref="PaketRestoreSettings.FailOnChecks"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.FailOnChecks))]
    public static T EnableFailOnChecks<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.FailOnChecks, true));
    /// <inheritdoc cref="PaketRestoreSettings.FailOnChecks"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.FailOnChecks))]
    public static T DisableFailOnChecks<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.FailOnChecks, false));
    /// <inheritdoc cref="PaketRestoreSettings.FailOnChecks"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.FailOnChecks))]
    public static T ToggleFailOnChecks<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.FailOnChecks, !o.FailOnChecks));
    #endregion
    #region DependencyGroup
    /// <inheritdoc cref="PaketRestoreSettings.DependencyGroup"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.DependencyGroup))]
    public static T SetDependencyGroup<T>(this T o, string v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.DependencyGroup, v));
    /// <inheritdoc cref="PaketRestoreSettings.DependencyGroup"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.DependencyGroup))]
    public static T ResetDependencyGroup<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.DependencyGroup));
    #endregion
    #region ProjectFile
    /// <inheritdoc cref="PaketRestoreSettings.ProjectFile"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.ProjectFile))]
    public static T SetProjectFile<T>(this T o, string v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.ProjectFile, v));
    /// <inheritdoc cref="PaketRestoreSettings.ProjectFile"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.ProjectFile))]
    public static T ResetProjectFile<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.ProjectFile));
    #endregion
    #region ReferencesFiles
    /// <inheritdoc cref="PaketRestoreSettings.ReferencesFiles"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.ReferencesFiles))]
    public static T SetReferencesFiles<T>(this T o, params string[] v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.ReferencesFiles, v));
    /// <inheritdoc cref="PaketRestoreSettings.ReferencesFiles"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.ReferencesFiles))]
    public static T SetReferencesFiles<T>(this T o, IEnumerable<string> v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.ReferencesFiles, v));
    /// <inheritdoc cref="PaketRestoreSettings.ReferencesFiles"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.ReferencesFiles))]
    public static T AddReferencesFiles<T>(this T o, params string[] v) where T : PaketRestoreSettings => o.Modify(b => b.AddCollection(() => o.ReferencesFiles, v));
    /// <inheritdoc cref="PaketRestoreSettings.ReferencesFiles"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.ReferencesFiles))]
    public static T AddReferencesFiles<T>(this T o, IEnumerable<string> v) where T : PaketRestoreSettings => o.Modify(b => b.AddCollection(() => o.ReferencesFiles, v));
    /// <inheritdoc cref="PaketRestoreSettings.ReferencesFiles"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.ReferencesFiles))]
    public static T RemoveReferencesFiles<T>(this T o, params string[] v) where T : PaketRestoreSettings => o.Modify(b => b.RemoveCollection(() => o.ReferencesFiles, v));
    /// <inheritdoc cref="PaketRestoreSettings.ReferencesFiles"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.ReferencesFiles))]
    public static T RemoveReferencesFiles<T>(this T o, IEnumerable<string> v) where T : PaketRestoreSettings => o.Modify(b => b.RemoveCollection(() => o.ReferencesFiles, v));
    /// <inheritdoc cref="PaketRestoreSettings.ReferencesFiles"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.ReferencesFiles))]
    public static T ClearReferencesFiles<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.ClearCollection(() => o.ReferencesFiles));
    #endregion
    #region TargetFramework
    /// <inheritdoc cref="PaketRestoreSettings.TargetFramework"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.TargetFramework))]
    public static T SetTargetFramework<T>(this T o, string v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.TargetFramework, v));
    /// <inheritdoc cref="PaketRestoreSettings.TargetFramework"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.TargetFramework))]
    public static T ResetTargetFramework<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.TargetFramework));
    #endregion
    #region Silent
    /// <inheritdoc cref="PaketRestoreSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Silent))]
    public static T SetSilent<T>(this T o, bool? v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Silent, v));
    /// <inheritdoc cref="PaketRestoreSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Silent))]
    public static T ResetSilent<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.Silent));
    /// <inheritdoc cref="PaketRestoreSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Silent))]
    public static T EnableSilent<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Silent, true));
    /// <inheritdoc cref="PaketRestoreSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Silent))]
    public static T DisableSilent<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Silent, false));
    /// <inheritdoc cref="PaketRestoreSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Silent))]
    public static T ToggleSilent<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Silent, !o.Silent));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PaketRestoreSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PaketRestoreSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="PaketRestoreSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="PaketRestoreSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="PaketRestoreSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region LogFile
    /// <inheritdoc cref="PaketRestoreSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="PaketRestoreSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
    #region FromBootstrapper
    /// <inheritdoc cref="PaketRestoreSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.FromBootstrapper))]
    public static T SetFromBootstrapper<T>(this T o, bool? v) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, v));
    /// <inheritdoc cref="PaketRestoreSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.FromBootstrapper))]
    public static T ResetFromBootstrapper<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Remove(() => o.FromBootstrapper));
    /// <inheritdoc cref="PaketRestoreSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.FromBootstrapper))]
    public static T EnableFromBootstrapper<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, true));
    /// <inheritdoc cref="PaketRestoreSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.FromBootstrapper))]
    public static T DisableFromBootstrapper<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, false));
    /// <inheritdoc cref="PaketRestoreSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketRestoreSettings), Property = nameof(PaketRestoreSettings.FromBootstrapper))]
    public static T ToggleFromBootstrapper<T>(this T o) where T : PaketRestoreSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, !o.FromBootstrapper));
    #endregion
}
#endregion
#region PaketPushSettingsExtensions
/// <summary>Used within <see cref="PaketTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PaketPushSettingsExtensions
{
    #region File
    /// <inheritdoc cref="PaketPushSettings.File"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.File))]
    public static T SetFile<T>(this T o, string v) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.File, v));
    /// <inheritdoc cref="PaketPushSettings.File"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.File))]
    public static T ResetFile<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Remove(() => o.File));
    #endregion
    #region Url
    /// <inheritdoc cref="PaketPushSettings.Url"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Url))]
    public static T SetUrl<T>(this T o, string v) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="PaketPushSettings.Url"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Url))]
    public static T ResetUrl<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Remove(() => o.Url));
    #endregion
    #region ApiKey
    /// <inheritdoc cref="PaketPushSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.ApiKey))]
    public static T SetApiKey<T>(this T o, [Secret] string v) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.ApiKey, v));
    /// <inheritdoc cref="PaketPushSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.ApiKey))]
    public static T ResetApiKey<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Remove(() => o.ApiKey));
    #endregion
    #region Endpoint
    /// <inheritdoc cref="PaketPushSettings.Endpoint"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Endpoint))]
    public static T SetEndpoint<T>(this T o, string v) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.Endpoint, v));
    /// <inheritdoc cref="PaketPushSettings.Endpoint"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Endpoint))]
    public static T ResetEndpoint<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Remove(() => o.Endpoint));
    #endregion
    #region Silent
    /// <inheritdoc cref="PaketPushSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Silent))]
    public static T SetSilent<T>(this T o, bool? v) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.Silent, v));
    /// <inheritdoc cref="PaketPushSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Silent))]
    public static T ResetSilent<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Remove(() => o.Silent));
    /// <inheritdoc cref="PaketPushSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Silent))]
    public static T EnableSilent<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.Silent, true));
    /// <inheritdoc cref="PaketPushSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Silent))]
    public static T DisableSilent<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.Silent, false));
    /// <inheritdoc cref="PaketPushSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Silent))]
    public static T ToggleSilent<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.Silent, !o.Silent));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PaketPushSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PaketPushSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="PaketPushSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="PaketPushSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="PaketPushSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region LogFile
    /// <inheritdoc cref="PaketPushSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="PaketPushSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
    #region FromBootstrapper
    /// <inheritdoc cref="PaketPushSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.FromBootstrapper))]
    public static T SetFromBootstrapper<T>(this T o, bool? v) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, v));
    /// <inheritdoc cref="PaketPushSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.FromBootstrapper))]
    public static T ResetFromBootstrapper<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Remove(() => o.FromBootstrapper));
    /// <inheritdoc cref="PaketPushSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.FromBootstrapper))]
    public static T EnableFromBootstrapper<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, true));
    /// <inheritdoc cref="PaketPushSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.FromBootstrapper))]
    public static T DisableFromBootstrapper<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, false));
    /// <inheritdoc cref="PaketPushSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketPushSettings), Property = nameof(PaketPushSettings.FromBootstrapper))]
    public static T ToggleFromBootstrapper<T>(this T o) where T : PaketPushSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, !o.FromBootstrapper));
    #endregion
}
#endregion
#region PaketPackSettingsExtensions
/// <summary>Used within <see cref="PaketTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PaketPackSettingsExtensions
{
    #region OutputDirectory
    /// <inheritdoc cref="PaketPackSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.OutputDirectory))]
    public static T SetOutputDirectory<T>(this T o, string v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.OutputDirectory, v));
    /// <inheritdoc cref="PaketPackSettings.OutputDirectory"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.OutputDirectory))]
    public static T ResetOutputDirectory<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.OutputDirectory));
    #endregion
    #region BuildConfiguration
    /// <inheritdoc cref="PaketPackSettings.BuildConfiguration"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.BuildConfiguration))]
    public static T SetBuildConfiguration<T>(this T o, string v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.BuildConfiguration, v));
    /// <inheritdoc cref="PaketPackSettings.BuildConfiguration"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.BuildConfiguration))]
    public static T ResetBuildConfiguration<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.BuildConfiguration));
    #endregion
    #region BuildPlatform
    /// <inheritdoc cref="PaketPackSettings.BuildPlatform"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.BuildPlatform))]
    public static T SetBuildPlatform<T>(this T o, string v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.BuildPlatform, v));
    /// <inheritdoc cref="PaketPackSettings.BuildPlatform"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.BuildPlatform))]
    public static T ResetBuildPlatform<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.BuildPlatform));
    #endregion
    #region PackageVersion
    /// <inheritdoc cref="PaketPackSettings.PackageVersion"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.PackageVersion))]
    public static T SetPackageVersion<T>(this T o, string v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.PackageVersion, v));
    /// <inheritdoc cref="PaketPackSettings.PackageVersion"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.PackageVersion))]
    public static T ResetPackageVersion<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.PackageVersion));
    #endregion
    #region TemplateFile
    /// <inheritdoc cref="PaketPackSettings.TemplateFile"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.TemplateFile))]
    public static T SetTemplateFile<T>(this T o, string v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.TemplateFile, v));
    /// <inheritdoc cref="PaketPackSettings.TemplateFile"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.TemplateFile))]
    public static T ResetTemplateFile<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.TemplateFile));
    #endregion
    #region Exclude
    /// <inheritdoc cref="PaketPackSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Exclude))]
    public static T SetExclude<T>(this T o, params string[] v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Exclude, v));
    /// <inheritdoc cref="PaketPackSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Exclude))]
    public static T SetExclude<T>(this T o, IEnumerable<string> v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Exclude, v));
    /// <inheritdoc cref="PaketPackSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Exclude))]
    public static T AddExclude<T>(this T o, params string[] v) where T : PaketPackSettings => o.Modify(b => b.AddCollection(() => o.Exclude, v));
    /// <inheritdoc cref="PaketPackSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Exclude))]
    public static T AddExclude<T>(this T o, IEnumerable<string> v) where T : PaketPackSettings => o.Modify(b => b.AddCollection(() => o.Exclude, v));
    /// <inheritdoc cref="PaketPackSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Exclude))]
    public static T RemoveExclude<T>(this T o, params string[] v) where T : PaketPackSettings => o.Modify(b => b.RemoveCollection(() => o.Exclude, v));
    /// <inheritdoc cref="PaketPackSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Exclude))]
    public static T RemoveExclude<T>(this T o, IEnumerable<string> v) where T : PaketPackSettings => o.Modify(b => b.RemoveCollection(() => o.Exclude, v));
    /// <inheritdoc cref="PaketPackSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Exclude))]
    public static T ClearExclude<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.ClearCollection(() => o.Exclude));
    #endregion
    #region SpecificVersions
    /// <inheritdoc cref="PaketPackSettings.SpecificVersions"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.SpecificVersions))]
    public static T SetSpecificVersions<T>(this T o, IDictionary<string, string> v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.SpecificVersions, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="PaketPackSettings.SpecificVersions"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.SpecificVersions))]
    public static T SetSpecificVersion<T>(this T o, string k, string v) where T : PaketPackSettings => o.Modify(b => b.SetDictionary(() => o.SpecificVersions, k, v));
    /// <inheritdoc cref="PaketPackSettings.SpecificVersions"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.SpecificVersions))]
    public static T AddSpecificVersion<T>(this T o, string k, string v) where T : PaketPackSettings => o.Modify(b => b.AddDictionary(() => o.SpecificVersions, k, v));
    /// <inheritdoc cref="PaketPackSettings.SpecificVersions"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.SpecificVersions))]
    public static T RemoveSpecificVersion<T>(this T o, string k) where T : PaketPackSettings => o.Modify(b => b.RemoveDictionary(() => o.SpecificVersions, k));
    /// <inheritdoc cref="PaketPackSettings.SpecificVersions"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.SpecificVersions))]
    public static T ClearSpecificVersions<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.ClearDictionary(() => o.SpecificVersions));
    #endregion
    #region ReleaseNotes
    /// <inheritdoc cref="PaketPackSettings.ReleaseNotes"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.ReleaseNotes))]
    public static T SetReleaseNotes<T>(this T o, string v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.ReleaseNotes, v));
    /// <inheritdoc cref="PaketPackSettings.ReleaseNotes"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.ReleaseNotes))]
    public static T ResetReleaseNotes<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.ReleaseNotes));
    #endregion
    #region LockDependencies
    /// <inheritdoc cref="PaketPackSettings.LockDependencies"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.LockDependencies))]
    public static T SetLockDependencies<T>(this T o, bool? v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.LockDependencies, v));
    /// <inheritdoc cref="PaketPackSettings.LockDependencies"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.LockDependencies))]
    public static T ResetLockDependencies<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.LockDependencies));
    /// <inheritdoc cref="PaketPackSettings.LockDependencies"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.LockDependencies))]
    public static T EnableLockDependencies<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.LockDependencies, true));
    /// <inheritdoc cref="PaketPackSettings.LockDependencies"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.LockDependencies))]
    public static T DisableLockDependencies<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.LockDependencies, false));
    /// <inheritdoc cref="PaketPackSettings.LockDependencies"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.LockDependencies))]
    public static T ToggleLockDependencies<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.LockDependencies, !o.LockDependencies));
    #endregion
    #region MinimumFromLockFile
    /// <inheritdoc cref="PaketPackSettings.MinimumFromLockFile"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.MinimumFromLockFile))]
    public static T SetMinimumFromLockFile<T>(this T o, bool? v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.MinimumFromLockFile, v));
    /// <inheritdoc cref="PaketPackSettings.MinimumFromLockFile"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.MinimumFromLockFile))]
    public static T ResetMinimumFromLockFile<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.MinimumFromLockFile));
    /// <inheritdoc cref="PaketPackSettings.MinimumFromLockFile"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.MinimumFromLockFile))]
    public static T EnableMinimumFromLockFile<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.MinimumFromLockFile, true));
    /// <inheritdoc cref="PaketPackSettings.MinimumFromLockFile"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.MinimumFromLockFile))]
    public static T DisableMinimumFromLockFile<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.MinimumFromLockFile, false));
    /// <inheritdoc cref="PaketPackSettings.MinimumFromLockFile"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.MinimumFromLockFile))]
    public static T ToggleMinimumFromLockFile<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.MinimumFromLockFile, !o.MinimumFromLockFile));
    #endregion
    #region PinProjectReferences
    /// <inheritdoc cref="PaketPackSettings.PinProjectReferences"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.PinProjectReferences))]
    public static T SetPinProjectReferences<T>(this T o, bool? v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.PinProjectReferences, v));
    /// <inheritdoc cref="PaketPackSettings.PinProjectReferences"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.PinProjectReferences))]
    public static T ResetPinProjectReferences<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.PinProjectReferences));
    /// <inheritdoc cref="PaketPackSettings.PinProjectReferences"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.PinProjectReferences))]
    public static T EnablePinProjectReferences<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.PinProjectReferences, true));
    /// <inheritdoc cref="PaketPackSettings.PinProjectReferences"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.PinProjectReferences))]
    public static T DisablePinProjectReferences<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.PinProjectReferences, false));
    /// <inheritdoc cref="PaketPackSettings.PinProjectReferences"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.PinProjectReferences))]
    public static T TogglePinProjectReferences<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.PinProjectReferences, !o.PinProjectReferences));
    #endregion
    #region Symbols
    /// <inheritdoc cref="PaketPackSettings.Symbols"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Symbols))]
    public static T SetSymbols<T>(this T o, bool? v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Symbols, v));
    /// <inheritdoc cref="PaketPackSettings.Symbols"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Symbols))]
    public static T ResetSymbols<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.Symbols));
    /// <inheritdoc cref="PaketPackSettings.Symbols"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Symbols))]
    public static T EnableSymbols<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Symbols, true));
    /// <inheritdoc cref="PaketPackSettings.Symbols"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Symbols))]
    public static T DisableSymbols<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Symbols, false));
    /// <inheritdoc cref="PaketPackSettings.Symbols"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Symbols))]
    public static T ToggleSymbols<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Symbols, !o.Symbols));
    #endregion
    #region IncludeReferencedProjects
    /// <inheritdoc cref="PaketPackSettings.IncludeReferencedProjects"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.IncludeReferencedProjects))]
    public static T SetIncludeReferencedProjects<T>(this T o, bool? v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.IncludeReferencedProjects, v));
    /// <inheritdoc cref="PaketPackSettings.IncludeReferencedProjects"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.IncludeReferencedProjects))]
    public static T ResetIncludeReferencedProjects<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.IncludeReferencedProjects));
    /// <inheritdoc cref="PaketPackSettings.IncludeReferencedProjects"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.IncludeReferencedProjects))]
    public static T EnableIncludeReferencedProjects<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.IncludeReferencedProjects, true));
    /// <inheritdoc cref="PaketPackSettings.IncludeReferencedProjects"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.IncludeReferencedProjects))]
    public static T DisableIncludeReferencedProjects<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.IncludeReferencedProjects, false));
    /// <inheritdoc cref="PaketPackSettings.IncludeReferencedProjects"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.IncludeReferencedProjects))]
    public static T ToggleIncludeReferencedProjects<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.IncludeReferencedProjects, !o.IncludeReferencedProjects));
    #endregion
    #region ProjectUrl
    /// <inheritdoc cref="PaketPackSettings.ProjectUrl"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.ProjectUrl))]
    public static T SetProjectUrl<T>(this T o, string v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.ProjectUrl, v));
    /// <inheritdoc cref="PaketPackSettings.ProjectUrl"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.ProjectUrl))]
    public static T ResetProjectUrl<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.ProjectUrl));
    #endregion
    #region Silent
    /// <inheritdoc cref="PaketPackSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Silent))]
    public static T SetSilent<T>(this T o, bool? v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Silent, v));
    /// <inheritdoc cref="PaketPackSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Silent))]
    public static T ResetSilent<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.Silent));
    /// <inheritdoc cref="PaketPackSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Silent))]
    public static T EnableSilent<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Silent, true));
    /// <inheritdoc cref="PaketPackSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Silent))]
    public static T DisableSilent<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Silent, false));
    /// <inheritdoc cref="PaketPackSettings.Silent"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Silent))]
    public static T ToggleSilent<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Silent, !o.Silent));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PaketPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PaketPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="PaketPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="PaketPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="PaketPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region LogFile
    /// <inheritdoc cref="PaketPackSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="PaketPackSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
    #region FromBootstrapper
    /// <inheritdoc cref="PaketPackSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.FromBootstrapper))]
    public static T SetFromBootstrapper<T>(this T o, bool? v) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, v));
    /// <inheritdoc cref="PaketPackSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.FromBootstrapper))]
    public static T ResetFromBootstrapper<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Remove(() => o.FromBootstrapper));
    /// <inheritdoc cref="PaketPackSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.FromBootstrapper))]
    public static T EnableFromBootstrapper<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, true));
    /// <inheritdoc cref="PaketPackSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.FromBootstrapper))]
    public static T DisableFromBootstrapper<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, false));
    /// <inheritdoc cref="PaketPackSettings.FromBootstrapper"/>
    [Pure] [Builder(Type = typeof(PaketPackSettings), Property = nameof(PaketPackSettings.FromBootstrapper))]
    public static T ToggleFromBootstrapper<T>(this T o) where T : PaketPackSettings => o.Modify(b => b.Set(() => o.FromBootstrapper, !o.FromBootstrapper));
    #endregion
}
#endregion
