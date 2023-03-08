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

namespace Nuke.Common.Tools.Paket
{
    /// <summary>
    ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
    ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(PaketPackageId)]
    public partial class PaketTasks
        : IRequireNuGetPackage
    {
        public const string PaketPackageId = "Paket";
        /// <summary>
        ///   Path to the Paket executable.
        /// </summary>
        public static string PaketPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("PAKET_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("Paket", "paket.exe");
        public static Action<OutputType, string> PaketLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Paket(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(PaketPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? PaketLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageId&gt;</c> via <see cref="PaketUpdateSettings.PackageId"/></li>
        ///     <li><c>--clean-redirects</c> via <see cref="PaketUpdateSettings.CleanRedirects"/></li>
        ///     <li><c>--create-new-binding-files</c> via <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></li>
        ///     <li><c>--filter</c> via <see cref="PaketUpdateSettings.Filter"/></li>
        ///     <li><c>--force</c> via <see cref="PaketUpdateSettings.Force"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketUpdateSettings.FromBootstrapper"/></li>
        ///     <li><c>--group</c> via <see cref="PaketUpdateSettings.DependencyGroup"/></li>
        ///     <li><c>--keep-major</c> via <see cref="PaketUpdateSettings.KeepMajor"/></li>
        ///     <li><c>--keep-minor</c> via <see cref="PaketUpdateSettings.KeepMinor"/></li>
        ///     <li><c>--keep-patch</c> via <see cref="PaketUpdateSettings.KeepPatch"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketUpdateSettings.LogFile"/></li>
        ///     <li><c>--no-install</c> via <see cref="PaketUpdateSettings.NoInstall"/></li>
        ///     <li><c>--redirects</c> via <see cref="PaketUpdateSettings.Redirects"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketUpdateSettings.Silent"/></li>
        ///     <li><c>--touch-affected-refs</c> via <see cref="PaketUpdateSettings.TouchAffectedReferences"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketUpdateSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="PaketUpdateSettings.PackageVersion"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PaketUpdate(PaketUpdateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new PaketUpdateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageId&gt;</c> via <see cref="PaketUpdateSettings.PackageId"/></li>
        ///     <li><c>--clean-redirects</c> via <see cref="PaketUpdateSettings.CleanRedirects"/></li>
        ///     <li><c>--create-new-binding-files</c> via <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></li>
        ///     <li><c>--filter</c> via <see cref="PaketUpdateSettings.Filter"/></li>
        ///     <li><c>--force</c> via <see cref="PaketUpdateSettings.Force"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketUpdateSettings.FromBootstrapper"/></li>
        ///     <li><c>--group</c> via <see cref="PaketUpdateSettings.DependencyGroup"/></li>
        ///     <li><c>--keep-major</c> via <see cref="PaketUpdateSettings.KeepMajor"/></li>
        ///     <li><c>--keep-minor</c> via <see cref="PaketUpdateSettings.KeepMinor"/></li>
        ///     <li><c>--keep-patch</c> via <see cref="PaketUpdateSettings.KeepPatch"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketUpdateSettings.LogFile"/></li>
        ///     <li><c>--no-install</c> via <see cref="PaketUpdateSettings.NoInstall"/></li>
        ///     <li><c>--redirects</c> via <see cref="PaketUpdateSettings.Redirects"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketUpdateSettings.Silent"/></li>
        ///     <li><c>--touch-affected-refs</c> via <see cref="PaketUpdateSettings.TouchAffectedReferences"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketUpdateSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="PaketUpdateSettings.PackageVersion"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PaketUpdate(Configure<PaketUpdateSettings> configurator)
        {
            return PaketUpdate(configurator(new PaketUpdateSettings()));
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;packageId&gt;</c> via <see cref="PaketUpdateSettings.PackageId"/></li>
        ///     <li><c>--clean-redirects</c> via <see cref="PaketUpdateSettings.CleanRedirects"/></li>
        ///     <li><c>--create-new-binding-files</c> via <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></li>
        ///     <li><c>--filter</c> via <see cref="PaketUpdateSettings.Filter"/></li>
        ///     <li><c>--force</c> via <see cref="PaketUpdateSettings.Force"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketUpdateSettings.FromBootstrapper"/></li>
        ///     <li><c>--group</c> via <see cref="PaketUpdateSettings.DependencyGroup"/></li>
        ///     <li><c>--keep-major</c> via <see cref="PaketUpdateSettings.KeepMajor"/></li>
        ///     <li><c>--keep-minor</c> via <see cref="PaketUpdateSettings.KeepMinor"/></li>
        ///     <li><c>--keep-patch</c> via <see cref="PaketUpdateSettings.KeepPatch"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketUpdateSettings.LogFile"/></li>
        ///     <li><c>--no-install</c> via <see cref="PaketUpdateSettings.NoInstall"/></li>
        ///     <li><c>--redirects</c> via <see cref="PaketUpdateSettings.Redirects"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketUpdateSettings.Silent"/></li>
        ///     <li><c>--touch-affected-refs</c> via <see cref="PaketUpdateSettings.TouchAffectedReferences"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketUpdateSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="PaketUpdateSettings.PackageVersion"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(PaketUpdateSettings Settings, IReadOnlyCollection<Output> Output)> PaketUpdate(CombinatorialConfigure<PaketUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(PaketUpdate, PaketLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--fail-on-checks</c> via <see cref="PaketRestoreSettings.FailOnChecks"/></li>
        ///     <li><c>--force</c> via <see cref="PaketRestoreSettings.Force"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketRestoreSettings.FromBootstrapper"/></li>
        ///     <li><c>--group</c> via <see cref="PaketRestoreSettings.DependencyGroup"/></li>
        ///     <li><c>--ignore-checks</c> via <see cref="PaketRestoreSettings.IgnoreChecks"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketRestoreSettings.LogFile"/></li>
        ///     <li><c>--only-referenced</c> via <see cref="PaketRestoreSettings.OnlyReferenced"/></li>
        ///     <li><c>--project</c> via <see cref="PaketRestoreSettings.ProjectFile"/></li>
        ///     <li><c>--references-files</c> via <see cref="PaketRestoreSettings.ReferencesFiles"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketRestoreSettings.Silent"/></li>
        ///     <li><c>--target-framework</c> via <see cref="PaketRestoreSettings.TargetFramework"/></li>
        ///     <li><c>--touch-affected-refs</c> via <see cref="PaketRestoreSettings.TouchAffectedRefs"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketRestoreSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PaketRestore(PaketRestoreSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new PaketRestoreSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--fail-on-checks</c> via <see cref="PaketRestoreSettings.FailOnChecks"/></li>
        ///     <li><c>--force</c> via <see cref="PaketRestoreSettings.Force"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketRestoreSettings.FromBootstrapper"/></li>
        ///     <li><c>--group</c> via <see cref="PaketRestoreSettings.DependencyGroup"/></li>
        ///     <li><c>--ignore-checks</c> via <see cref="PaketRestoreSettings.IgnoreChecks"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketRestoreSettings.LogFile"/></li>
        ///     <li><c>--only-referenced</c> via <see cref="PaketRestoreSettings.OnlyReferenced"/></li>
        ///     <li><c>--project</c> via <see cref="PaketRestoreSettings.ProjectFile"/></li>
        ///     <li><c>--references-files</c> via <see cref="PaketRestoreSettings.ReferencesFiles"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketRestoreSettings.Silent"/></li>
        ///     <li><c>--target-framework</c> via <see cref="PaketRestoreSettings.TargetFramework"/></li>
        ///     <li><c>--touch-affected-refs</c> via <see cref="PaketRestoreSettings.TouchAffectedRefs"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketRestoreSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PaketRestore(Configure<PaketRestoreSettings> configurator)
        {
            return PaketRestore(configurator(new PaketRestoreSettings()));
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--fail-on-checks</c> via <see cref="PaketRestoreSettings.FailOnChecks"/></li>
        ///     <li><c>--force</c> via <see cref="PaketRestoreSettings.Force"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketRestoreSettings.FromBootstrapper"/></li>
        ///     <li><c>--group</c> via <see cref="PaketRestoreSettings.DependencyGroup"/></li>
        ///     <li><c>--ignore-checks</c> via <see cref="PaketRestoreSettings.IgnoreChecks"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketRestoreSettings.LogFile"/></li>
        ///     <li><c>--only-referenced</c> via <see cref="PaketRestoreSettings.OnlyReferenced"/></li>
        ///     <li><c>--project</c> via <see cref="PaketRestoreSettings.ProjectFile"/></li>
        ///     <li><c>--references-files</c> via <see cref="PaketRestoreSettings.ReferencesFiles"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketRestoreSettings.Silent"/></li>
        ///     <li><c>--target-framework</c> via <see cref="PaketRestoreSettings.TargetFramework"/></li>
        ///     <li><c>--touch-affected-refs</c> via <see cref="PaketRestoreSettings.TouchAffectedRefs"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketRestoreSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(PaketRestoreSettings Settings, IReadOnlyCollection<Output> Output)> PaketRestore(CombinatorialConfigure<PaketRestoreSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(PaketRestore, PaketLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--api-key</c> via <see cref="PaketPushSettings.ApiKey"/></li>
        ///     <li><c>--endpoint</c> via <see cref="PaketPushSettings.Endpoint"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketPushSettings.FromBootstrapper"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketPushSettings.LogFile"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketPushSettings.Silent"/></li>
        ///     <li><c>--url</c> via <see cref="PaketPushSettings.Url"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketPushSettings.Verbose"/></li>
        ///     <li><c>file</c> via <see cref="PaketPushSettings.File"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PaketPush(PaketPushSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new PaketPushSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--api-key</c> via <see cref="PaketPushSettings.ApiKey"/></li>
        ///     <li><c>--endpoint</c> via <see cref="PaketPushSettings.Endpoint"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketPushSettings.FromBootstrapper"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketPushSettings.LogFile"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketPushSettings.Silent"/></li>
        ///     <li><c>--url</c> via <see cref="PaketPushSettings.Url"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketPushSettings.Verbose"/></li>
        ///     <li><c>file</c> via <see cref="PaketPushSettings.File"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PaketPush(Configure<PaketPushSettings> configurator)
        {
            return PaketPush(configurator(new PaketPushSettings()));
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--api-key</c> via <see cref="PaketPushSettings.ApiKey"/></li>
        ///     <li><c>--endpoint</c> via <see cref="PaketPushSettings.Endpoint"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketPushSettings.FromBootstrapper"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketPushSettings.LogFile"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketPushSettings.Silent"/></li>
        ///     <li><c>--url</c> via <see cref="PaketPushSettings.Url"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketPushSettings.Verbose"/></li>
        ///     <li><c>file</c> via <see cref="PaketPushSettings.File"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(PaketPushSettings Settings, IReadOnlyCollection<Output> Output)> PaketPush(CombinatorialConfigure<PaketPushSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(PaketPush, PaketLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;outputDirectory&gt;</c> via <see cref="PaketPackSettings.OutputDirectory"/></li>
        ///     <li><c>--build-config</c> via <see cref="PaketPackSettings.BuildConfiguration"/></li>
        ///     <li><c>--build-platform</c> via <see cref="PaketPackSettings.BuildPlatform"/></li>
        ///     <li><c>--exclude</c> via <see cref="PaketPackSettings.Exclude"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketPackSettings.FromBootstrapper"/></li>
        ///     <li><c>--include-referenced-projects</c> via <see cref="PaketPackSettings.IncludeReferencedProjects"/></li>
        ///     <li><c>--lock-dependencies</c> via <see cref="PaketPackSettings.LockDependencies"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketPackSettings.LogFile"/></li>
        ///     <li><c>--minimum-from-lock-file</c> via <see cref="PaketPackSettings.MinimumFromLockFile"/></li>
        ///     <li><c>--pin-project-references</c> via <see cref="PaketPackSettings.PinProjectReferences"/></li>
        ///     <li><c>--project-url</c> via <see cref="PaketPackSettings.ProjectUrl"/></li>
        ///     <li><c>--release-notes</c> via <see cref="PaketPackSettings.ReleaseNotes"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketPackSettings.Silent"/></li>
        ///     <li><c>--specific-version</c> via <see cref="PaketPackSettings.SpecificVersions"/></li>
        ///     <li><c>--symbols</c> via <see cref="PaketPackSettings.Symbols"/></li>
        ///     <li><c>--template</c> via <see cref="PaketPackSettings.TemplateFile"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketPackSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="PaketPackSettings.PackageVersion"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PaketPack(PaketPackSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new PaketPackSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;outputDirectory&gt;</c> via <see cref="PaketPackSettings.OutputDirectory"/></li>
        ///     <li><c>--build-config</c> via <see cref="PaketPackSettings.BuildConfiguration"/></li>
        ///     <li><c>--build-platform</c> via <see cref="PaketPackSettings.BuildPlatform"/></li>
        ///     <li><c>--exclude</c> via <see cref="PaketPackSettings.Exclude"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketPackSettings.FromBootstrapper"/></li>
        ///     <li><c>--include-referenced-projects</c> via <see cref="PaketPackSettings.IncludeReferencedProjects"/></li>
        ///     <li><c>--lock-dependencies</c> via <see cref="PaketPackSettings.LockDependencies"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketPackSettings.LogFile"/></li>
        ///     <li><c>--minimum-from-lock-file</c> via <see cref="PaketPackSettings.MinimumFromLockFile"/></li>
        ///     <li><c>--pin-project-references</c> via <see cref="PaketPackSettings.PinProjectReferences"/></li>
        ///     <li><c>--project-url</c> via <see cref="PaketPackSettings.ProjectUrl"/></li>
        ///     <li><c>--release-notes</c> via <see cref="PaketPackSettings.ReleaseNotes"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketPackSettings.Silent"/></li>
        ///     <li><c>--specific-version</c> via <see cref="PaketPackSettings.SpecificVersions"/></li>
        ///     <li><c>--symbols</c> via <see cref="PaketPackSettings.Symbols"/></li>
        ///     <li><c>--template</c> via <see cref="PaketPackSettings.TemplateFile"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketPackSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="PaketPackSettings.PackageVersion"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> PaketPack(Configure<PaketPackSettings> configurator)
        {
            return PaketPack(configurator(new PaketPackSettings()));
        }
        /// <summary>
        ///   <p>Paket is a dependency manager for .NET and mono projects, which is designed to work well with <a href="https://www.nuget.org/">NuGet</a> packages and also enables referencing files directly from <a href="https://fsprojects.github.io/Paket/git-dependencies.html">Git repositories</a> or any <a href="https://fsprojects.github.io/Paket/http-dependencies.html">HTTP resource</a>. It enables precise and predictable control over what packages the projects within your application reference.</p><p>If you want to learn how to use Paket then read the <a href="https://fsprojects.github.io/Paket/getting-started.html"><em>Getting started</em> tutorial</a> and take a look at the <a href="https://fsprojects.github.io/Paket/faq.html">FAQs</a>.</p><p>If you are already using NuGet for package management in your solution then you can learn about the upgrade process in the <a href="https://fsprojects.github.io/Paket/getting-started.html#Automatic-NuGet-conversion">convert from NuGet</a> section.</p>
        ///   <p>For more details, visit the <a href="https://fsprojects.github.io/paket">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;outputDirectory&gt;</c> via <see cref="PaketPackSettings.OutputDirectory"/></li>
        ///     <li><c>--build-config</c> via <see cref="PaketPackSettings.BuildConfiguration"/></li>
        ///     <li><c>--build-platform</c> via <see cref="PaketPackSettings.BuildPlatform"/></li>
        ///     <li><c>--exclude</c> via <see cref="PaketPackSettings.Exclude"/></li>
        ///     <li><c>--from-bootstrapper</c> via <see cref="PaketPackSettings.FromBootstrapper"/></li>
        ///     <li><c>--include-referenced-projects</c> via <see cref="PaketPackSettings.IncludeReferencedProjects"/></li>
        ///     <li><c>--lock-dependencies</c> via <see cref="PaketPackSettings.LockDependencies"/></li>
        ///     <li><c>--log-file</c> via <see cref="PaketPackSettings.LogFile"/></li>
        ///     <li><c>--minimum-from-lock-file</c> via <see cref="PaketPackSettings.MinimumFromLockFile"/></li>
        ///     <li><c>--pin-project-references</c> via <see cref="PaketPackSettings.PinProjectReferences"/></li>
        ///     <li><c>--project-url</c> via <see cref="PaketPackSettings.ProjectUrl"/></li>
        ///     <li><c>--release-notes</c> via <see cref="PaketPackSettings.ReleaseNotes"/></li>
        ///     <li><c>--silent</c> via <see cref="PaketPackSettings.Silent"/></li>
        ///     <li><c>--specific-version</c> via <see cref="PaketPackSettings.SpecificVersions"/></li>
        ///     <li><c>--symbols</c> via <see cref="PaketPackSettings.Symbols"/></li>
        ///     <li><c>--template</c> via <see cref="PaketPackSettings.TemplateFile"/></li>
        ///     <li><c>--verbose</c> via <see cref="PaketPackSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="PaketPackSettings.PackageVersion"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(PaketPackSettings Settings, IReadOnlyCollection<Output> Output)> PaketPack(CombinatorialConfigure<PaketPackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(PaketPack, PaketLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region PaketUpdateSettings
    /// <summary>
    ///   Used within <see cref="PaketTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketUpdateSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Paket executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? PaketTasks.PaketPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? PaketTasks.PaketLogger;
        /// <summary>
        ///   NuGet package ID.
        /// </summary>
        public virtual string PackageId { get; internal set; }
        /// <summary>
        ///   Dependency version constraint.
        /// </summary>
        public virtual string PackageVersion { get; internal set; }
        /// <summary>
        ///   Dependency group to update. Default is <em>all groups</em>.
        /// </summary>
        public virtual string DependencyGroup { get; internal set; }
        /// <summary>
        ///   Creates binding redirect files if needed.
        /// </summary>
        public virtual bool? CreateNewBindingFiles { get; internal set; }
        /// <summary>
        ///   Force download and reinstallation of all dependencies.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Create binding redirects.
        /// </summary>
        public virtual bool? Redirects { get; internal set; }
        /// <summary>
        ///   Remove binding redirects that were not created by Paket.
        /// </summary>
        public virtual bool? CleanRedirects { get; internal set; }
        /// <summary>
        ///   Do not modify projects.
        /// </summary>
        public virtual bool? NoInstall { get; internal set; }
        /// <summary>
        ///   Only allow updates that preserve the major version.
        /// </summary>
        public virtual bool? KeepMajor { get; internal set; }
        /// <summary>
        ///   Only allow updates that preserve the minor version.
        /// </summary>
        public virtual bool? KeepMinor { get; internal set; }
        /// <summary>
        ///   Only allow updates that preserve the patch version.
        /// </summary>
        public virtual bool? KeepPatch { get; internal set; }
        /// <summary>
        ///   Treat the NuGet package ID as a regex to filter packages.
        /// </summary>
        public virtual bool? Filter { get; internal set; }
        /// <summary>
        ///   Touch project files referencing affected dependencies, to help incremental build tools detecting the change.
        /// </summary>
        public virtual bool? TouchAffectedReferences { get; internal set; }
        /// <summary>
        ///   Suppress console output.
        /// </summary>
        public virtual bool? Silent { get; internal set; }
        /// <summary>
        ///   Print detailed information to the console.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Print output to a file.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        /// <summary>
        ///   Call coming from the <c>--run</c> feature of the bootstrapper.
        /// </summary>
        public virtual bool? FromBootstrapper { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("update")
              .Add("{value}", PackageId)
              .Add("--version {value}", PackageVersion)
              .Add("--group {value}", DependencyGroup)
              .Add("--create-new-binding-files", CreateNewBindingFiles)
              .Add("--force", Force)
              .Add("--redirects", Redirects)
              .Add("--clean-redirects", CleanRedirects)
              .Add("--no-install", NoInstall)
              .Add("--keep-major", KeepMajor)
              .Add("--keep-minor", KeepMinor)
              .Add("--keep-patch", KeepPatch)
              .Add("--filter", Filter)
              .Add("--touch-affected-refs", TouchAffectedReferences)
              .Add("--silent", Silent)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--from-bootstrapper", FromBootstrapper);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region PaketRestoreSettings
    /// <summary>
    ///   Used within <see cref="PaketTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketRestoreSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Paket executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? PaketTasks.PaketPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? PaketTasks.PaketLogger;
        /// <summary>
        ///   Force download and reinstallation of all dependencies.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Only restore packages that are referenced by paket.references files.
        /// </summary>
        public virtual bool? OnlyReferenced { get; internal set; }
        /// <summary>
        ///   Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.
        /// </summary>
        public virtual bool? TouchAffectedRefs { get; internal set; }
        /// <summary>
        ///   Do not check if paket.dependencies and paket.lock are in sync.
        /// </summary>
        public virtual bool? IgnoreChecks { get; internal set; }
        /// <summary>
        ///   Abort if any checks fail.
        /// </summary>
        public virtual bool? FailOnChecks { get; internal set; }
        /// <summary>
        ///   Restore dependencies of a single group.
        /// </summary>
        public virtual string DependencyGroup { get; internal set; }
        /// <summary>
        ///   Restore dependencies of a single project.
        /// </summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary>
        ///   Restore packages from a paket.references file.
        /// </summary>
        public virtual IReadOnlyList<string> ReferencesFiles => ReferencesFilesInternal.AsReadOnly();
        internal List<string> ReferencesFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Restore only for the specified target framework.
        /// </summary>
        public virtual string TargetFramework { get; internal set; }
        /// <summary>
        ///   Suppress console output.
        /// </summary>
        public virtual bool? Silent { get; internal set; }
        /// <summary>
        ///   Print detailed information to the console.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Print output to a file.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        /// <summary>
        ///   Call coming from the <c>--run</c> feature of the bootstrapper.
        /// </summary>
        public virtual bool? FromBootstrapper { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("restore")
              .Add("--force", Force)
              .Add("--only-referenced", OnlyReferenced)
              .Add("--touch-affected-refs", TouchAffectedRefs)
              .Add("--ignore-checks", IgnoreChecks)
              .Add("--fail-on-checks", FailOnChecks)
              .Add("--group {value}", DependencyGroup)
              .Add("--project {value}", ProjectFile)
              .Add("--references-files {value}", ReferencesFiles)
              .Add("--target-framework {value}", TargetFramework)
              .Add("--silent", Silent)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--from-bootstrapper", FromBootstrapper);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region PaketPushSettings
    /// <summary>
    ///   Used within <see cref="PaketTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketPushSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Paket executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? PaketTasks.PaketPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? PaketTasks.PaketLogger;
        /// <summary>
        ///   Path to the package.
        /// </summary>
        public virtual string File { get; internal set; }
        /// <summary>
        ///   URL of the NuGet feed.
        /// </summary>
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   API key for the URL. Default is the <c>NUGET_KEY</c> environment variable.
        /// </summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary>
        ///   API endpoint to push to. Default is <em>/api/v2/package</em>.
        /// </summary>
        public virtual string Endpoint { get; internal set; }
        /// <summary>
        ///   Suppress console output.
        /// </summary>
        public virtual bool? Silent { get; internal set; }
        /// <summary>
        ///   Print detailed information to the console.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Print output to a file.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        /// <summary>
        ///   Call coming from the <c>--run</c> feature of the bootstrapper.
        /// </summary>
        public virtual bool? FromBootstrapper { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("push")
              .Add("file {value}", File)
              .Add("--url {value}", Url)
              .Add("--api-key {value}", ApiKey, secret: true)
              .Add("--endpoint {value}", Endpoint)
              .Add("--silent", Silent)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--from-bootstrapper", FromBootstrapper);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region PaketPackSettings
    /// <summary>
    ///   Used within <see cref="PaketTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class PaketPackSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Paket executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? PaketTasks.PaketPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? PaketTasks.PaketLogger;
        /// <summary>
        ///   Output directory for .nupkg files.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Build configuration that should be packaged. Default is <em>Release</em>.
        /// </summary>
        public virtual string BuildConfiguration { get; internal set; }
        /// <summary>
        ///   Build platform that should be packaged. Default is <em>check all known platform targets</em>.
        /// </summary>
        public virtual string BuildPlatform { get; internal set; }
        /// <summary>
        ///   Version of the package.
        /// </summary>
        public virtual string PackageVersion { get; internal set; }
        /// <summary>
        ///   Pack a single paket.template file.
        /// </summary>
        public virtual string TemplateFile { get; internal set; }
        /// <summary>
        ///   Exclude paket.template file by package ID.
        /// </summary>
        public virtual IReadOnlyList<string> Exclude => ExcludeInternal.AsReadOnly();
        internal List<string> ExcludeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Package IDs with version numbers.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> SpecificVersions => SpecificVersionsInternal.AsReadOnly();
        internal Dictionary<string, string> SpecificVersionsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Specify release notes for the package.
        /// </summary>
        public virtual string ReleaseNotes { get; internal set; }
        /// <summary>
        ///   Use version requirements from paket.lock instead of paket.dependencies.
        /// </summary>
        public virtual bool? LockDependencies { get; internal set; }
        /// <summary>
        ///   Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.
        /// </summary>
        public virtual bool? MinimumFromLockFile { get; internal set; }
        /// <summary>
        ///   Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.
        /// </summary>
        public virtual bool? PinProjectReferences { get; internal set; }
        /// <summary>
        ///   Build symbol/source packages in addition to library/content packages.
        /// </summary>
        public virtual bool? Symbols { get; internal set; }
        /// <summary>
        ///   Include symbol/source from referenced projects.
        /// </summary>
        public virtual bool? IncludeReferencedProjects { get; internal set; }
        /// <summary>
        ///   Url to the projects home page.
        /// </summary>
        public virtual string ProjectUrl { get; internal set; }
        /// <summary>
        ///   Suppress console output.
        /// </summary>
        public virtual bool? Silent { get; internal set; }
        /// <summary>
        ///   Print detailed information to the console.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Print output to a file.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        /// <summary>
        ///   Call coming from the <c>--run</c> feature of the bootstrapper.
        /// </summary>
        public virtual bool? FromBootstrapper { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("pack")
              .Add("{value}", OutputDirectory)
              .Add("--build-config {value}", BuildConfiguration)
              .Add("--build-platform {value}", BuildPlatform)
              .Add("--version {value}", PackageVersion)
              .Add("--template {value}", TemplateFile)
              .Add("--exclude {value}", Exclude)
              .Add("--specific-version {value}", SpecificVersions, "{key} {value}")
              .Add("--release-notes {value}", ReleaseNotes)
              .Add("--lock-dependencies", LockDependencies)
              .Add("--minimum-from-lock-file", MinimumFromLockFile)
              .Add("--pin-project-references", PinProjectReferences)
              .Add("--symbols", Symbols)
              .Add("--include-referenced-projects", IncludeReferencedProjects)
              .Add("--project-url {value}", ProjectUrl)
              .Add("--silent", Silent)
              .Add("--verbose", Verbose)
              .Add("--log-file {value}", LogFile)
              .Add("--from-bootstrapper", FromBootstrapper);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region PaketUpdateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="PaketTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketUpdateSettingsExtensions
    {
        #region PackageId
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.PackageId"/></em></p>
        ///   <p>NuGet package ID.</p>
        /// </summary>
        [Pure]
        public static T SetPackageId<T>(this T toolSettings, string packageId) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageId = packageId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.PackageId"/></em></p>
        ///   <p>NuGet package ID.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageId<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageId = null;
            return toolSettings;
        }
        #endregion
        #region PackageVersion
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.PackageVersion"/></em></p>
        ///   <p>Dependency version constraint.</p>
        /// </summary>
        [Pure]
        public static T SetPackageVersion<T>(this T toolSettings, string packageVersion) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersion = packageVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.PackageVersion"/></em></p>
        ///   <p>Dependency version constraint.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageVersion<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersion = null;
            return toolSettings;
        }
        #endregion
        #region DependencyGroup
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.DependencyGroup"/></em></p>
        ///   <p>Dependency group to update. Default is <em>all groups</em>.</p>
        /// </summary>
        [Pure]
        public static T SetDependencyGroup<T>(this T toolSettings, string dependencyGroup) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyGroup = dependencyGroup;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.DependencyGroup"/></em></p>
        ///   <p>Dependency group to update. Default is <em>all groups</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetDependencyGroup<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyGroup = null;
            return toolSettings;
        }
        #endregion
        #region CreateNewBindingFiles
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></em></p>
        ///   <p>Creates binding redirect files if needed.</p>
        /// </summary>
        [Pure]
        public static T SetCreateNewBindingFiles<T>(this T toolSettings, bool? createNewBindingFiles) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNewBindingFiles = createNewBindingFiles;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></em></p>
        ///   <p>Creates binding redirect files if needed.</p>
        /// </summary>
        [Pure]
        public static T ResetCreateNewBindingFiles<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNewBindingFiles = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></em></p>
        ///   <p>Creates binding redirect files if needed.</p>
        /// </summary>
        [Pure]
        public static T EnableCreateNewBindingFiles<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNewBindingFiles = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></em></p>
        ///   <p>Creates binding redirect files if needed.</p>
        /// </summary>
        [Pure]
        public static T DisableCreateNewBindingFiles<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNewBindingFiles = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.CreateNewBindingFiles"/></em></p>
        ///   <p>Creates binding redirect files if needed.</p>
        /// </summary>
        [Pure]
        public static T ToggleCreateNewBindingFiles<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNewBindingFiles = !toolSettings.CreateNewBindingFiles;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.Force"/></em></p>
        ///   <p>Force download and reinstallation of all dependencies.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.Force"/></em></p>
        ///   <p>Force download and reinstallation of all dependencies.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.Force"/></em></p>
        ///   <p>Force download and reinstallation of all dependencies.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.Force"/></em></p>
        ///   <p>Force download and reinstallation of all dependencies.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.Force"/></em></p>
        ///   <p>Force download and reinstallation of all dependencies.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Redirects
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.Redirects"/></em></p>
        ///   <p>Create binding redirects.</p>
        /// </summary>
        [Pure]
        public static T SetRedirects<T>(this T toolSettings, bool? redirects) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Redirects = redirects;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.Redirects"/></em></p>
        ///   <p>Create binding redirects.</p>
        /// </summary>
        [Pure]
        public static T ResetRedirects<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Redirects = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.Redirects"/></em></p>
        ///   <p>Create binding redirects.</p>
        /// </summary>
        [Pure]
        public static T EnableRedirects<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Redirects = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.Redirects"/></em></p>
        ///   <p>Create binding redirects.</p>
        /// </summary>
        [Pure]
        public static T DisableRedirects<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Redirects = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.Redirects"/></em></p>
        ///   <p>Create binding redirects.</p>
        /// </summary>
        [Pure]
        public static T ToggleRedirects<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Redirects = !toolSettings.Redirects;
            return toolSettings;
        }
        #endregion
        #region CleanRedirects
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.CleanRedirects"/></em></p>
        ///   <p>Remove binding redirects that were not created by Paket.</p>
        /// </summary>
        [Pure]
        public static T SetCleanRedirects<T>(this T toolSettings, bool? cleanRedirects) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanRedirects = cleanRedirects;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.CleanRedirects"/></em></p>
        ///   <p>Remove binding redirects that were not created by Paket.</p>
        /// </summary>
        [Pure]
        public static T ResetCleanRedirects<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanRedirects = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.CleanRedirects"/></em></p>
        ///   <p>Remove binding redirects that were not created by Paket.</p>
        /// </summary>
        [Pure]
        public static T EnableCleanRedirects<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanRedirects = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.CleanRedirects"/></em></p>
        ///   <p>Remove binding redirects that were not created by Paket.</p>
        /// </summary>
        [Pure]
        public static T DisableCleanRedirects<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanRedirects = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.CleanRedirects"/></em></p>
        ///   <p>Remove binding redirects that were not created by Paket.</p>
        /// </summary>
        [Pure]
        public static T ToggleCleanRedirects<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanRedirects = !toolSettings.CleanRedirects;
            return toolSettings;
        }
        #endregion
        #region NoInstall
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.NoInstall"/></em></p>
        ///   <p>Do not modify projects.</p>
        /// </summary>
        [Pure]
        public static T SetNoInstall<T>(this T toolSettings, bool? noInstall) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInstall = noInstall;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.NoInstall"/></em></p>
        ///   <p>Do not modify projects.</p>
        /// </summary>
        [Pure]
        public static T ResetNoInstall<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInstall = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.NoInstall"/></em></p>
        ///   <p>Do not modify projects.</p>
        /// </summary>
        [Pure]
        public static T EnableNoInstall<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInstall = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.NoInstall"/></em></p>
        ///   <p>Do not modify projects.</p>
        /// </summary>
        [Pure]
        public static T DisableNoInstall<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInstall = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.NoInstall"/></em></p>
        ///   <p>Do not modify projects.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoInstall<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoInstall = !toolSettings.NoInstall;
            return toolSettings;
        }
        #endregion
        #region KeepMajor
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.KeepMajor"/></em></p>
        ///   <p>Only allow updates that preserve the major version.</p>
        /// </summary>
        [Pure]
        public static T SetKeepMajor<T>(this T toolSettings, bool? keepMajor) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMajor = keepMajor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.KeepMajor"/></em></p>
        ///   <p>Only allow updates that preserve the major version.</p>
        /// </summary>
        [Pure]
        public static T ResetKeepMajor<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMajor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.KeepMajor"/></em></p>
        ///   <p>Only allow updates that preserve the major version.</p>
        /// </summary>
        [Pure]
        public static T EnableKeepMajor<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMajor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.KeepMajor"/></em></p>
        ///   <p>Only allow updates that preserve the major version.</p>
        /// </summary>
        [Pure]
        public static T DisableKeepMajor<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMajor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.KeepMajor"/></em></p>
        ///   <p>Only allow updates that preserve the major version.</p>
        /// </summary>
        [Pure]
        public static T ToggleKeepMajor<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMajor = !toolSettings.KeepMajor;
            return toolSettings;
        }
        #endregion
        #region KeepMinor
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.KeepMinor"/></em></p>
        ///   <p>Only allow updates that preserve the minor version.</p>
        /// </summary>
        [Pure]
        public static T SetKeepMinor<T>(this T toolSettings, bool? keepMinor) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMinor = keepMinor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.KeepMinor"/></em></p>
        ///   <p>Only allow updates that preserve the minor version.</p>
        /// </summary>
        [Pure]
        public static T ResetKeepMinor<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMinor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.KeepMinor"/></em></p>
        ///   <p>Only allow updates that preserve the minor version.</p>
        /// </summary>
        [Pure]
        public static T EnableKeepMinor<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMinor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.KeepMinor"/></em></p>
        ///   <p>Only allow updates that preserve the minor version.</p>
        /// </summary>
        [Pure]
        public static T DisableKeepMinor<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMinor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.KeepMinor"/></em></p>
        ///   <p>Only allow updates that preserve the minor version.</p>
        /// </summary>
        [Pure]
        public static T ToggleKeepMinor<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepMinor = !toolSettings.KeepMinor;
            return toolSettings;
        }
        #endregion
        #region KeepPatch
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.KeepPatch"/></em></p>
        ///   <p>Only allow updates that preserve the patch version.</p>
        /// </summary>
        [Pure]
        public static T SetKeepPatch<T>(this T toolSettings, bool? keepPatch) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepPatch = keepPatch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.KeepPatch"/></em></p>
        ///   <p>Only allow updates that preserve the patch version.</p>
        /// </summary>
        [Pure]
        public static T ResetKeepPatch<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepPatch = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.KeepPatch"/></em></p>
        ///   <p>Only allow updates that preserve the patch version.</p>
        /// </summary>
        [Pure]
        public static T EnableKeepPatch<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepPatch = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.KeepPatch"/></em></p>
        ///   <p>Only allow updates that preserve the patch version.</p>
        /// </summary>
        [Pure]
        public static T DisableKeepPatch<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepPatch = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.KeepPatch"/></em></p>
        ///   <p>Only allow updates that preserve the patch version.</p>
        /// </summary>
        [Pure]
        public static T ToggleKeepPatch<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepPatch = !toolSettings.KeepPatch;
            return toolSettings;
        }
        #endregion
        #region Filter
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.Filter"/></em></p>
        ///   <p>Treat the NuGet package ID as a regex to filter packages.</p>
        /// </summary>
        [Pure]
        public static T SetFilter<T>(this T toolSettings, bool? filter) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.Filter"/></em></p>
        ///   <p>Treat the NuGet package ID as a regex to filter packages.</p>
        /// </summary>
        [Pure]
        public static T ResetFilter<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.Filter"/></em></p>
        ///   <p>Treat the NuGet package ID as a regex to filter packages.</p>
        /// </summary>
        [Pure]
        public static T EnableFilter<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.Filter"/></em></p>
        ///   <p>Treat the NuGet package ID as a regex to filter packages.</p>
        /// </summary>
        [Pure]
        public static T DisableFilter<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.Filter"/></em></p>
        ///   <p>Treat the NuGet package ID as a regex to filter packages.</p>
        /// </summary>
        [Pure]
        public static T ToggleFilter<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = !toolSettings.Filter;
            return toolSettings;
        }
        #endregion
        #region TouchAffectedReferences
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.TouchAffectedReferences"/></em></p>
        ///   <p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p>
        /// </summary>
        [Pure]
        public static T SetTouchAffectedReferences<T>(this T toolSettings, bool? touchAffectedReferences) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedReferences = touchAffectedReferences;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.TouchAffectedReferences"/></em></p>
        ///   <p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p>
        /// </summary>
        [Pure]
        public static T ResetTouchAffectedReferences<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedReferences = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.TouchAffectedReferences"/></em></p>
        ///   <p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p>
        /// </summary>
        [Pure]
        public static T EnableTouchAffectedReferences<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedReferences = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.TouchAffectedReferences"/></em></p>
        ///   <p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p>
        /// </summary>
        [Pure]
        public static T DisableTouchAffectedReferences<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedReferences = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.TouchAffectedReferences"/></em></p>
        ///   <p>Touch project files referencing affected dependencies, to help incremental build tools detecting the change.</p>
        /// </summary>
        [Pure]
        public static T ToggleTouchAffectedReferences<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedReferences = !toolSettings.TouchAffectedReferences;
            return toolSettings;
        }
        #endregion
        #region Silent
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T SetSilent<T>(this T toolSettings, bool? silent) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = silent;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T ResetSilent<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T EnableSilent<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T DisableSilent<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T ToggleSilent<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = !toolSettings.Silent;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.LogFile"/></em></p>
        ///   <p>Print output to a file.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.LogFile"/></em></p>
        ///   <p>Print output to a file.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region FromBootstrapper
        /// <summary>
        ///   <p><em>Sets <see cref="PaketUpdateSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T SetFromBootstrapper<T>(this T toolSettings, bool? fromBootstrapper) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = fromBootstrapper;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketUpdateSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T ResetFromBootstrapper<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketUpdateSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T EnableFromBootstrapper<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketUpdateSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T DisableFromBootstrapper<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketUpdateSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T ToggleFromBootstrapper<T>(this T toolSettings) where T : PaketUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = !toolSettings.FromBootstrapper;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region PaketRestoreSettingsExtensions
    /// <summary>
    ///   Used within <see cref="PaketTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketRestoreSettingsExtensions
    {
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.Force"/></em></p>
        ///   <p>Force download and reinstallation of all dependencies.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.Force"/></em></p>
        ///   <p>Force download and reinstallation of all dependencies.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketRestoreSettings.Force"/></em></p>
        ///   <p>Force download and reinstallation of all dependencies.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketRestoreSettings.Force"/></em></p>
        ///   <p>Force download and reinstallation of all dependencies.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketRestoreSettings.Force"/></em></p>
        ///   <p>Force download and reinstallation of all dependencies.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region OnlyReferenced
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.OnlyReferenced"/></em></p>
        ///   <p>Only restore packages that are referenced by paket.references files.</p>
        /// </summary>
        [Pure]
        public static T SetOnlyReferenced<T>(this T toolSettings, bool? onlyReferenced) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyReferenced = onlyReferenced;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.OnlyReferenced"/></em></p>
        ///   <p>Only restore packages that are referenced by paket.references files.</p>
        /// </summary>
        [Pure]
        public static T ResetOnlyReferenced<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyReferenced = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketRestoreSettings.OnlyReferenced"/></em></p>
        ///   <p>Only restore packages that are referenced by paket.references files.</p>
        /// </summary>
        [Pure]
        public static T EnableOnlyReferenced<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyReferenced = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketRestoreSettings.OnlyReferenced"/></em></p>
        ///   <p>Only restore packages that are referenced by paket.references files.</p>
        /// </summary>
        [Pure]
        public static T DisableOnlyReferenced<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyReferenced = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketRestoreSettings.OnlyReferenced"/></em></p>
        ///   <p>Only restore packages that are referenced by paket.references files.</p>
        /// </summary>
        [Pure]
        public static T ToggleOnlyReferenced<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OnlyReferenced = !toolSettings.OnlyReferenced;
            return toolSettings;
        }
        #endregion
        #region TouchAffectedRefs
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.TouchAffectedRefs"/></em></p>
        ///   <p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p>
        /// </summary>
        [Pure]
        public static T SetTouchAffectedRefs<T>(this T toolSettings, bool? touchAffectedRefs) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedRefs = touchAffectedRefs;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.TouchAffectedRefs"/></em></p>
        ///   <p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p>
        /// </summary>
        [Pure]
        public static T ResetTouchAffectedRefs<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedRefs = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketRestoreSettings.TouchAffectedRefs"/></em></p>
        ///   <p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p>
        /// </summary>
        [Pure]
        public static T EnableTouchAffectedRefs<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedRefs = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketRestoreSettings.TouchAffectedRefs"/></em></p>
        ///   <p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p>
        /// </summary>
        [Pure]
        public static T DisableTouchAffectedRefs<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedRefs = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketRestoreSettings.TouchAffectedRefs"/></em></p>
        ///   <p>Touches project files referencing packages which are being restored, to help incremental build tools detecting the change.</p>
        /// </summary>
        [Pure]
        public static T ToggleTouchAffectedRefs<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TouchAffectedRefs = !toolSettings.TouchAffectedRefs;
            return toolSettings;
        }
        #endregion
        #region IgnoreChecks
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.IgnoreChecks"/></em></p>
        ///   <p>Do not check if paket.dependencies and paket.lock are in sync.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreChecks<T>(this T toolSettings, bool? ignoreChecks) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChecks = ignoreChecks;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.IgnoreChecks"/></em></p>
        ///   <p>Do not check if paket.dependencies and paket.lock are in sync.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreChecks<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChecks = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketRestoreSettings.IgnoreChecks"/></em></p>
        ///   <p>Do not check if paket.dependencies and paket.lock are in sync.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreChecks<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChecks = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketRestoreSettings.IgnoreChecks"/></em></p>
        ///   <p>Do not check if paket.dependencies and paket.lock are in sync.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreChecks<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChecks = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketRestoreSettings.IgnoreChecks"/></em></p>
        ///   <p>Do not check if paket.dependencies and paket.lock are in sync.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreChecks<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChecks = !toolSettings.IgnoreChecks;
            return toolSettings;
        }
        #endregion
        #region FailOnChecks
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.FailOnChecks"/></em></p>
        ///   <p>Abort if any checks fail.</p>
        /// </summary>
        [Pure]
        public static T SetFailOnChecks<T>(this T toolSettings, bool? failOnChecks) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnChecks = failOnChecks;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.FailOnChecks"/></em></p>
        ///   <p>Abort if any checks fail.</p>
        /// </summary>
        [Pure]
        public static T ResetFailOnChecks<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnChecks = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketRestoreSettings.FailOnChecks"/></em></p>
        ///   <p>Abort if any checks fail.</p>
        /// </summary>
        [Pure]
        public static T EnableFailOnChecks<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnChecks = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketRestoreSettings.FailOnChecks"/></em></p>
        ///   <p>Abort if any checks fail.</p>
        /// </summary>
        [Pure]
        public static T DisableFailOnChecks<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnChecks = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketRestoreSettings.FailOnChecks"/></em></p>
        ///   <p>Abort if any checks fail.</p>
        /// </summary>
        [Pure]
        public static T ToggleFailOnChecks<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FailOnChecks = !toolSettings.FailOnChecks;
            return toolSettings;
        }
        #endregion
        #region DependencyGroup
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.DependencyGroup"/></em></p>
        ///   <p>Restore dependencies of a single group.</p>
        /// </summary>
        [Pure]
        public static T SetDependencyGroup<T>(this T toolSettings, string dependencyGroup) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyGroup = dependencyGroup;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.DependencyGroup"/></em></p>
        ///   <p>Restore dependencies of a single group.</p>
        /// </summary>
        [Pure]
        public static T ResetDependencyGroup<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyGroup = null;
            return toolSettings;
        }
        #endregion
        #region ProjectFile
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.ProjectFile"/></em></p>
        ///   <p>Restore dependencies of a single project.</p>
        /// </summary>
        [Pure]
        public static T SetProjectFile<T>(this T toolSettings, string projectFile) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.ProjectFile"/></em></p>
        ///   <p>Restore dependencies of a single project.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectFile<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }
        #endregion
        #region ReferencesFiles
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.ReferencesFiles"/> to a new list</em></p>
        ///   <p>Restore packages from a paket.references file.</p>
        /// </summary>
        [Pure]
        public static T SetReferencesFiles<T>(this T toolSettings, params string[] referencesFiles) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencesFilesInternal = referencesFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.ReferencesFiles"/> to a new list</em></p>
        ///   <p>Restore packages from a paket.references file.</p>
        /// </summary>
        [Pure]
        public static T SetReferencesFiles<T>(this T toolSettings, IEnumerable<string> referencesFiles) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencesFilesInternal = referencesFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="PaketRestoreSettings.ReferencesFiles"/></em></p>
        ///   <p>Restore packages from a paket.references file.</p>
        /// </summary>
        [Pure]
        public static T AddReferencesFiles<T>(this T toolSettings, params string[] referencesFiles) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencesFilesInternal.AddRange(referencesFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="PaketRestoreSettings.ReferencesFiles"/></em></p>
        ///   <p>Restore packages from a paket.references file.</p>
        /// </summary>
        [Pure]
        public static T AddReferencesFiles<T>(this T toolSettings, IEnumerable<string> referencesFiles) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencesFilesInternal.AddRange(referencesFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="PaketRestoreSettings.ReferencesFiles"/></em></p>
        ///   <p>Restore packages from a paket.references file.</p>
        /// </summary>
        [Pure]
        public static T ClearReferencesFiles<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferencesFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="PaketRestoreSettings.ReferencesFiles"/></em></p>
        ///   <p>Restore packages from a paket.references file.</p>
        /// </summary>
        [Pure]
        public static T RemoveReferencesFiles<T>(this T toolSettings, params string[] referencesFiles) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencesFiles);
            toolSettings.ReferencesFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="PaketRestoreSettings.ReferencesFiles"/></em></p>
        ///   <p>Restore packages from a paket.references file.</p>
        /// </summary>
        [Pure]
        public static T RemoveReferencesFiles<T>(this T toolSettings, IEnumerable<string> referencesFiles) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referencesFiles);
            toolSettings.ReferencesFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TargetFramework
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.TargetFramework"/></em></p>
        ///   <p>Restore only for the specified target framework.</p>
        /// </summary>
        [Pure]
        public static T SetTargetFramework<T>(this T toolSettings, string targetFramework) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetFramework = targetFramework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.TargetFramework"/></em></p>
        ///   <p>Restore only for the specified target framework.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetFramework<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetFramework = null;
            return toolSettings;
        }
        #endregion
        #region Silent
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T SetSilent<T>(this T toolSettings, bool? silent) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = silent;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T ResetSilent<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketRestoreSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T EnableSilent<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketRestoreSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T DisableSilent<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketRestoreSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T ToggleSilent<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = !toolSettings.Silent;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketRestoreSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketRestoreSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketRestoreSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.LogFile"/></em></p>
        ///   <p>Print output to a file.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.LogFile"/></em></p>
        ///   <p>Print output to a file.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region FromBootstrapper
        /// <summary>
        ///   <p><em>Sets <see cref="PaketRestoreSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T SetFromBootstrapper<T>(this T toolSettings, bool? fromBootstrapper) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = fromBootstrapper;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketRestoreSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T ResetFromBootstrapper<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketRestoreSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T EnableFromBootstrapper<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketRestoreSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T DisableFromBootstrapper<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketRestoreSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T ToggleFromBootstrapper<T>(this T toolSettings) where T : PaketRestoreSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = !toolSettings.FromBootstrapper;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region PaketPushSettingsExtensions
    /// <summary>
    ///   Used within <see cref="PaketTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketPushSettingsExtensions
    {
        #region File
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPushSettings.File"/></em></p>
        ///   <p>Path to the package.</p>
        /// </summary>
        [Pure]
        public static T SetFile<T>(this T toolSettings, string file) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPushSettings.File"/></em></p>
        ///   <p>Path to the package.</p>
        /// </summary>
        [Pure]
        public static T ResetFile<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPushSettings.Url"/></em></p>
        ///   <p>URL of the NuGet feed.</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPushSettings.Url"/></em></p>
        ///   <p>URL of the NuGet feed.</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPushSettings.ApiKey"/></em></p>
        ///   <p>API key for the URL. Default is the <c>NUGET_KEY</c> environment variable.</p>
        /// </summary>
        [Pure]
        public static T SetApiKey<T>(this T toolSettings, [Secret] string apiKey) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPushSettings.ApiKey"/></em></p>
        ///   <p>API key for the URL. Default is the <c>NUGET_KEY</c> environment variable.</p>
        /// </summary>
        [Pure]
        public static T ResetApiKey<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Endpoint
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPushSettings.Endpoint"/></em></p>
        ///   <p>API endpoint to push to. Default is <em>/api/v2/package</em>.</p>
        /// </summary>
        [Pure]
        public static T SetEndpoint<T>(this T toolSettings, string endpoint) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Endpoint = endpoint;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPushSettings.Endpoint"/></em></p>
        ///   <p>API endpoint to push to. Default is <em>/api/v2/package</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetEndpoint<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Endpoint = null;
            return toolSettings;
        }
        #endregion
        #region Silent
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPushSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T SetSilent<T>(this T toolSettings, bool? silent) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = silent;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPushSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T ResetSilent<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPushSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T EnableSilent<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPushSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T DisableSilent<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPushSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T ToggleSilent<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = !toolSettings.Silent;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPushSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPushSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPushSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPushSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPushSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPushSettings.LogFile"/></em></p>
        ///   <p>Print output to a file.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPushSettings.LogFile"/></em></p>
        ///   <p>Print output to a file.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region FromBootstrapper
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPushSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T SetFromBootstrapper<T>(this T toolSettings, bool? fromBootstrapper) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = fromBootstrapper;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPushSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T ResetFromBootstrapper<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPushSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T EnableFromBootstrapper<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPushSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T DisableFromBootstrapper<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPushSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T ToggleFromBootstrapper<T>(this T toolSettings) where T : PaketPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = !toolSettings.FromBootstrapper;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region PaketPackSettingsExtensions
    /// <summary>
    ///   Used within <see cref="PaketTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class PaketPackSettingsExtensions
    {
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.OutputDirectory"/></em></p>
        ///   <p>Output directory for .nupkg files.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDirectory<T>(this T toolSettings, string outputDirectory) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.OutputDirectory"/></em></p>
        ///   <p>Output directory for .nupkg files.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDirectory<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region BuildConfiguration
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.BuildConfiguration"/></em></p>
        ///   <p>Build configuration that should be packaged. Default is <em>Release</em>.</p>
        /// </summary>
        [Pure]
        public static T SetBuildConfiguration<T>(this T toolSettings, string buildConfiguration) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildConfiguration = buildConfiguration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.BuildConfiguration"/></em></p>
        ///   <p>Build configuration that should be packaged. Default is <em>Release</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetBuildConfiguration<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildConfiguration = null;
            return toolSettings;
        }
        #endregion
        #region BuildPlatform
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.BuildPlatform"/></em></p>
        ///   <p>Build platform that should be packaged. Default is <em>check all known platform targets</em>.</p>
        /// </summary>
        [Pure]
        public static T SetBuildPlatform<T>(this T toolSettings, string buildPlatform) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildPlatform = buildPlatform;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.BuildPlatform"/></em></p>
        ///   <p>Build platform that should be packaged. Default is <em>check all known platform targets</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetBuildPlatform<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildPlatform = null;
            return toolSettings;
        }
        #endregion
        #region PackageVersion
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.PackageVersion"/></em></p>
        ///   <p>Version of the package.</p>
        /// </summary>
        [Pure]
        public static T SetPackageVersion<T>(this T toolSettings, string packageVersion) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersion = packageVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.PackageVersion"/></em></p>
        ///   <p>Version of the package.</p>
        /// </summary>
        [Pure]
        public static T ResetPackageVersion<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersion = null;
            return toolSettings;
        }
        #endregion
        #region TemplateFile
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.TemplateFile"/></em></p>
        ///   <p>Pack a single paket.template file.</p>
        /// </summary>
        [Pure]
        public static T SetTemplateFile<T>(this T toolSettings, string templateFile) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateFile = templateFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.TemplateFile"/></em></p>
        ///   <p>Pack a single paket.template file.</p>
        /// </summary>
        [Pure]
        public static T ResetTemplateFile<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TemplateFile = null;
            return toolSettings;
        }
        #endregion
        #region Exclude
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.Exclude"/> to a new list</em></p>
        ///   <p>Exclude paket.template file by package ID.</p>
        /// </summary>
        [Pure]
        public static T SetExclude<T>(this T toolSettings, params string[] exclude) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.Exclude"/> to a new list</em></p>
        ///   <p>Exclude paket.template file by package ID.</p>
        /// </summary>
        [Pure]
        public static T SetExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="PaketPackSettings.Exclude"/></em></p>
        ///   <p>Exclude paket.template file by package ID.</p>
        /// </summary>
        [Pure]
        public static T AddExclude<T>(this T toolSettings, params string[] exclude) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="PaketPackSettings.Exclude"/></em></p>
        ///   <p>Exclude paket.template file by package ID.</p>
        /// </summary>
        [Pure]
        public static T AddExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="PaketPackSettings.Exclude"/></em></p>
        ///   <p>Exclude paket.template file by package ID.</p>
        /// </summary>
        [Pure]
        public static T ClearExclude<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="PaketPackSettings.Exclude"/></em></p>
        ///   <p>Exclude paket.template file by package ID.</p>
        /// </summary>
        [Pure]
        public static T RemoveExclude<T>(this T toolSettings, params string[] exclude) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="PaketPackSettings.Exclude"/></em></p>
        ///   <p>Exclude paket.template file by package ID.</p>
        /// </summary>
        [Pure]
        public static T RemoveExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region SpecificVersions
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.SpecificVersions"/> to a new dictionary</em></p>
        ///   <p>Package IDs with version numbers.</p>
        /// </summary>
        [Pure]
        public static T SetSpecificVersions<T>(this T toolSettings, IDictionary<string, string> specificVersions) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificVersionsInternal = specificVersions.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="PaketPackSettings.SpecificVersions"/></em></p>
        ///   <p>Package IDs with version numbers.</p>
        /// </summary>
        [Pure]
        public static T ClearSpecificVersions<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificVersionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="PaketPackSettings.SpecificVersions"/></em></p>
        ///   <p>Package IDs with version numbers.</p>
        /// </summary>
        [Pure]
        public static T AddSpecificVersion<T>(this T toolSettings, string specificVersionKey, string specificVersionValue) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificVersionsInternal.Add(specificVersionKey, specificVersionValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="PaketPackSettings.SpecificVersions"/></em></p>
        ///   <p>Package IDs with version numbers.</p>
        /// </summary>
        [Pure]
        public static T RemoveSpecificVersion<T>(this T toolSettings, string specificVersionKey) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificVersionsInternal.Remove(specificVersionKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="PaketPackSettings.SpecificVersions"/></em></p>
        ///   <p>Package IDs with version numbers.</p>
        /// </summary>
        [Pure]
        public static T SetSpecificVersion<T>(this T toolSettings, string specificVersionKey, string specificVersionValue) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificVersionsInternal[specificVersionKey] = specificVersionValue;
            return toolSettings;
        }
        #endregion
        #region ReleaseNotes
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.ReleaseNotes"/></em></p>
        ///   <p>Specify release notes for the package.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseNotes<T>(this T toolSettings, string releaseNotes) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = releaseNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.ReleaseNotes"/></em></p>
        ///   <p>Specify release notes for the package.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseNotes<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = null;
            return toolSettings;
        }
        #endregion
        #region LockDependencies
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.LockDependencies"/></em></p>
        ///   <p>Use version requirements from paket.lock instead of paket.dependencies.</p>
        /// </summary>
        [Pure]
        public static T SetLockDependencies<T>(this T toolSettings, bool? lockDependencies) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockDependencies = lockDependencies;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.LockDependencies"/></em></p>
        ///   <p>Use version requirements from paket.lock instead of paket.dependencies.</p>
        /// </summary>
        [Pure]
        public static T ResetLockDependencies<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockDependencies = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPackSettings.LockDependencies"/></em></p>
        ///   <p>Use version requirements from paket.lock instead of paket.dependencies.</p>
        /// </summary>
        [Pure]
        public static T EnableLockDependencies<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockDependencies = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPackSettings.LockDependencies"/></em></p>
        ///   <p>Use version requirements from paket.lock instead of paket.dependencies.</p>
        /// </summary>
        [Pure]
        public static T DisableLockDependencies<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockDependencies = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPackSettings.LockDependencies"/></em></p>
        ///   <p>Use version requirements from paket.lock instead of paket.dependencies.</p>
        /// </summary>
        [Pure]
        public static T ToggleLockDependencies<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockDependencies = !toolSettings.LockDependencies;
            return toolSettings;
        }
        #endregion
        #region MinimumFromLockFile
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.MinimumFromLockFile"/></em></p>
        ///   <p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p>
        /// </summary>
        [Pure]
        public static T SetMinimumFromLockFile<T>(this T toolSettings, bool? minimumFromLockFile) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumFromLockFile = minimumFromLockFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.MinimumFromLockFile"/></em></p>
        ///   <p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p>
        /// </summary>
        [Pure]
        public static T ResetMinimumFromLockFile<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumFromLockFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPackSettings.MinimumFromLockFile"/></em></p>
        ///   <p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p>
        /// </summary>
        [Pure]
        public static T EnableMinimumFromLockFile<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumFromLockFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPackSettings.MinimumFromLockFile"/></em></p>
        ///   <p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p>
        /// </summary>
        [Pure]
        public static T DisableMinimumFromLockFile<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumFromLockFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPackSettings.MinimumFromLockFile"/></em></p>
        ///   <p>Use version requirements from paket.lock instead of paket.dependencies, and add them as a minimum version. <c>--lock-dependencies</c> will over-ride this option.</p>
        /// </summary>
        [Pure]
        public static T ToggleMinimumFromLockFile<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimumFromLockFile = !toolSettings.MinimumFromLockFile;
            return toolSettings;
        }
        #endregion
        #region PinProjectReferences
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.PinProjectReferences"/></em></p>
        ///   <p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p>
        /// </summary>
        [Pure]
        public static T SetPinProjectReferences<T>(this T toolSettings, bool? pinProjectReferences) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PinProjectReferences = pinProjectReferences;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.PinProjectReferences"/></em></p>
        ///   <p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p>
        /// </summary>
        [Pure]
        public static T ResetPinProjectReferences<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PinProjectReferences = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPackSettings.PinProjectReferences"/></em></p>
        ///   <p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p>
        /// </summary>
        [Pure]
        public static T EnablePinProjectReferences<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PinProjectReferences = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPackSettings.PinProjectReferences"/></em></p>
        ///   <p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p>
        /// </summary>
        [Pure]
        public static T DisablePinProjectReferences<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PinProjectReferences = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPackSettings.PinProjectReferences"/></em></p>
        ///   <p>Pin dependencies generated from project references (=) instead of using minimum (>=) for version specification.  If <c>--lock-dependencies</c> is specified, project references will be pinned even if this option is not specified.</p>
        /// </summary>
        [Pure]
        public static T TogglePinProjectReferences<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PinProjectReferences = !toolSettings.PinProjectReferences;
            return toolSettings;
        }
        #endregion
        #region Symbols
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.Symbols"/></em></p>
        ///   <p>Build symbol/source packages in addition to library/content packages.</p>
        /// </summary>
        [Pure]
        public static T SetSymbols<T>(this T toolSettings, bool? symbols) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = symbols;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.Symbols"/></em></p>
        ///   <p>Build symbol/source packages in addition to library/content packages.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbols<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPackSettings.Symbols"/></em></p>
        ///   <p>Build symbol/source packages in addition to library/content packages.</p>
        /// </summary>
        [Pure]
        public static T EnableSymbols<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPackSettings.Symbols"/></em></p>
        ///   <p>Build symbol/source packages in addition to library/content packages.</p>
        /// </summary>
        [Pure]
        public static T DisableSymbols<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPackSettings.Symbols"/></em></p>
        ///   <p>Build symbol/source packages in addition to library/content packages.</p>
        /// </summary>
        [Pure]
        public static T ToggleSymbols<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = !toolSettings.Symbols;
            return toolSettings;
        }
        #endregion
        #region IncludeReferencedProjects
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.IncludeReferencedProjects"/></em></p>
        ///   <p>Include symbol/source from referenced projects.</p>
        /// </summary>
        [Pure]
        public static T SetIncludeReferencedProjects<T>(this T toolSettings, bool? includeReferencedProjects) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = includeReferencedProjects;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.IncludeReferencedProjects"/></em></p>
        ///   <p>Include symbol/source from referenced projects.</p>
        /// </summary>
        [Pure]
        public static T ResetIncludeReferencedProjects<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPackSettings.IncludeReferencedProjects"/></em></p>
        ///   <p>Include symbol/source from referenced projects.</p>
        /// </summary>
        [Pure]
        public static T EnableIncludeReferencedProjects<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPackSettings.IncludeReferencedProjects"/></em></p>
        ///   <p>Include symbol/source from referenced projects.</p>
        /// </summary>
        [Pure]
        public static T DisableIncludeReferencedProjects<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPackSettings.IncludeReferencedProjects"/></em></p>
        ///   <p>Include symbol/source from referenced projects.</p>
        /// </summary>
        [Pure]
        public static T ToggleIncludeReferencedProjects<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = !toolSettings.IncludeReferencedProjects;
            return toolSettings;
        }
        #endregion
        #region ProjectUrl
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.ProjectUrl"/></em></p>
        ///   <p>Url to the projects home page.</p>
        /// </summary>
        [Pure]
        public static T SetProjectUrl<T>(this T toolSettings, string projectUrl) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectUrl = projectUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.ProjectUrl"/></em></p>
        ///   <p>Url to the projects home page.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectUrl<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectUrl = null;
            return toolSettings;
        }
        #endregion
        #region Silent
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T SetSilent<T>(this T toolSettings, bool? silent) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = silent;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T ResetSilent<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPackSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T EnableSilent<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPackSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T DisableSilent<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPackSettings.Silent"/></em></p>
        ///   <p>Suppress console output.</p>
        /// </summary>
        [Pure]
        public static T ToggleSilent<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = !toolSettings.Silent;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPackSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPackSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPackSettings.Verbose"/></em></p>
        ///   <p>Print detailed information to the console.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.LogFile"/></em></p>
        ///   <p>Print output to a file.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.LogFile"/></em></p>
        ///   <p>Print output to a file.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region FromBootstrapper
        /// <summary>
        ///   <p><em>Sets <see cref="PaketPackSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T SetFromBootstrapper<T>(this T toolSettings, bool? fromBootstrapper) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = fromBootstrapper;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="PaketPackSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T ResetFromBootstrapper<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="PaketPackSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T EnableFromBootstrapper<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="PaketPackSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T DisableFromBootstrapper<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="PaketPackSettings.FromBootstrapper"/></em></p>
        ///   <p>Call coming from the <c>--run</c> feature of the bootstrapper.</p>
        /// </summary>
        [Pure]
        public static T ToggleFromBootstrapper<T>(this T toolSettings) where T : PaketPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromBootstrapper = !toolSettings.FromBootstrapper;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
