// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Octopus/Octopus.json

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

namespace Nuke.Common.Tools.Octopus
{
    /// <summary>
    ///   <p>Octopus Deploy is an automated deployment server, which you install yourself, much like you would install SQL Server, Team Foundation Server or JetBrains TeamCity. Octopus makes it easy to automate deployment of ASP.NET web applications and Windows Services into development, test and production environments.<para/>Along with the Octopus Deploy server, you'll also install a lightweight agent service on each of the machines that you plan to deploy to, for example your web and application servers. We call this the Tentacle agent; the idea being that one Octopus server controls many Tentacles, potentially a lot more than 8! With Octopus and Tentacle, you can easily deploy to your own servers, or cloud services from providers like Amazon Web Services or Microsoft Azure.</p>
    ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(OctopusPackageId)]
    public partial class OctopusTasks
        : IRequireNuGetPackage
    {
        public const string OctopusPackageId = "Octopus.DotNet.Cli";
        /// <summary>
        ///   Path to the Octopus executable.
        /// </summary>
        public static string OctopusPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("OCTOPUS_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> OctopusLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Octopus Deploy is an automated deployment server, which you install yourself, much like you would install SQL Server, Team Foundation Server or JetBrains TeamCity. Octopus makes it easy to automate deployment of ASP.NET web applications and Windows Services into development, test and production environments.<para/>Along with the Octopus Deploy server, you'll also install a lightweight agent service on each of the machines that you plan to deploy to, for example your web and application servers. We call this the Tentacle agent; the idea being that one Octopus server controls many Tentacles, potentially a lot more than 8! With Octopus and Tentacle, you can easily deploy to your own servers, or cloud services from providers like Amazon Web Services or Microsoft Azure.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Octopus(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(OctopusPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? OctopusLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>Octo.exe pack</c> command provides a number of other useful parameters that can be used to customize the way your package gets created, such as output folder, files to include and release notes.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--author</c> via <see cref="OctopusPackSettings.Authors"/></li>
        ///     <li><c>--basePath</c> via <see cref="OctopusPackSettings.BasePath"/></li>
        ///     <li><c>--description</c> via <see cref="OctopusPackSettings.Description"/></li>
        ///     <li><c>--format</c> via <see cref="OctopusPackSettings.Format"/></li>
        ///     <li><c>--id</c> via <see cref="OctopusPackSettings.Id"/></li>
        ///     <li><c>--include</c> via <see cref="OctopusPackSettings.Include"/></li>
        ///     <li><c>--outFolder</c> via <see cref="OctopusPackSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="OctopusPackSettings.Overwrite"/></li>
        ///     <li><c>--releaseNotes</c> via <see cref="OctopusPackSettings.ReleaseNotes"/></li>
        ///     <li><c>--releaseNotesFile</c> via <see cref="OctopusPackSettings.ReleaseNotesFile"/></li>
        ///     <li><c>--title</c> via <see cref="OctopusPackSettings.Title"/></li>
        ///     <li><c>--verbose</c> via <see cref="OctopusPackSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusPackSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctopusPack(OctopusPackSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new OctopusPackSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>Octo.exe pack</c> command provides a number of other useful parameters that can be used to customize the way your package gets created, such as output folder, files to include and release notes.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--author</c> via <see cref="OctopusPackSettings.Authors"/></li>
        ///     <li><c>--basePath</c> via <see cref="OctopusPackSettings.BasePath"/></li>
        ///     <li><c>--description</c> via <see cref="OctopusPackSettings.Description"/></li>
        ///     <li><c>--format</c> via <see cref="OctopusPackSettings.Format"/></li>
        ///     <li><c>--id</c> via <see cref="OctopusPackSettings.Id"/></li>
        ///     <li><c>--include</c> via <see cref="OctopusPackSettings.Include"/></li>
        ///     <li><c>--outFolder</c> via <see cref="OctopusPackSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="OctopusPackSettings.Overwrite"/></li>
        ///     <li><c>--releaseNotes</c> via <see cref="OctopusPackSettings.ReleaseNotes"/></li>
        ///     <li><c>--releaseNotesFile</c> via <see cref="OctopusPackSettings.ReleaseNotesFile"/></li>
        ///     <li><c>--title</c> via <see cref="OctopusPackSettings.Title"/></li>
        ///     <li><c>--verbose</c> via <see cref="OctopusPackSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusPackSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctopusPack(Configure<OctopusPackSettings> configurator)
        {
            return OctopusPack(configurator(new OctopusPackSettings()));
        }
        /// <summary>
        ///   <p>The <c>Octo.exe pack</c> command provides a number of other useful parameters that can be used to customize the way your package gets created, such as output folder, files to include and release notes.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--author</c> via <see cref="OctopusPackSettings.Authors"/></li>
        ///     <li><c>--basePath</c> via <see cref="OctopusPackSettings.BasePath"/></li>
        ///     <li><c>--description</c> via <see cref="OctopusPackSettings.Description"/></li>
        ///     <li><c>--format</c> via <see cref="OctopusPackSettings.Format"/></li>
        ///     <li><c>--id</c> via <see cref="OctopusPackSettings.Id"/></li>
        ///     <li><c>--include</c> via <see cref="OctopusPackSettings.Include"/></li>
        ///     <li><c>--outFolder</c> via <see cref="OctopusPackSettings.OutputFolder"/></li>
        ///     <li><c>--overwrite</c> via <see cref="OctopusPackSettings.Overwrite"/></li>
        ///     <li><c>--releaseNotes</c> via <see cref="OctopusPackSettings.ReleaseNotes"/></li>
        ///     <li><c>--releaseNotesFile</c> via <see cref="OctopusPackSettings.ReleaseNotesFile"/></li>
        ///     <li><c>--title</c> via <see cref="OctopusPackSettings.Title"/></li>
        ///     <li><c>--verbose</c> via <see cref="OctopusPackSettings.Verbose"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusPackSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(OctopusPackSettings Settings, IReadOnlyCollection<Output> Output)> OctopusPack(CombinatorialConfigure<OctopusPackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(OctopusPack, OctopusLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>Octo.exe push</c> command can push any of the supported packages types listed on this <a href="https://octopus.com/docs/packaging-applications/supported-packages">page</a>.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusPushSettings.ApiKey"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusPushSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusPushSettings.Debug"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusPushSettings.EnableServiceMessages"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusPushSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusPushSettings.LogLevel"/></li>
        ///     <li><c>--package</c> via <see cref="OctopusPushSettings.Package"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusPushSettings.Password"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusPushSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusPushSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusPushSettings.ProxyUsername"/></li>
        ///     <li><c>--replace-existing</c> via <see cref="OctopusPushSettings.ReplaceExisting"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusPushSettings.Server"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusPushSettings.Space"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusPushSettings.Timeout"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusPushSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctopusPush(OctopusPushSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new OctopusPushSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>Octo.exe push</c> command can push any of the supported packages types listed on this <a href="https://octopus.com/docs/packaging-applications/supported-packages">page</a>.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusPushSettings.ApiKey"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusPushSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusPushSettings.Debug"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusPushSettings.EnableServiceMessages"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusPushSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusPushSettings.LogLevel"/></li>
        ///     <li><c>--package</c> via <see cref="OctopusPushSettings.Package"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusPushSettings.Password"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusPushSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusPushSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusPushSettings.ProxyUsername"/></li>
        ///     <li><c>--replace-existing</c> via <see cref="OctopusPushSettings.ReplaceExisting"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusPushSettings.Server"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusPushSettings.Space"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusPushSettings.Timeout"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusPushSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctopusPush(Configure<OctopusPushSettings> configurator)
        {
            return OctopusPush(configurator(new OctopusPushSettings()));
        }
        /// <summary>
        ///   <p>The <c>Octo.exe push</c> command can push any of the supported packages types listed on this <a href="https://octopus.com/docs/packaging-applications/supported-packages">page</a>.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusPushSettings.ApiKey"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusPushSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusPushSettings.Debug"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusPushSettings.EnableServiceMessages"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusPushSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusPushSettings.LogLevel"/></li>
        ///     <li><c>--package</c> via <see cref="OctopusPushSettings.Package"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusPushSettings.Password"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusPushSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusPushSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusPushSettings.ProxyUsername"/></li>
        ///     <li><c>--replace-existing</c> via <see cref="OctopusPushSettings.ReplaceExisting"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusPushSettings.Server"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusPushSettings.Space"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusPushSettings.Timeout"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusPushSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(OctopusPushSettings Settings, IReadOnlyCollection<Output> Output)> OctopusPush(CombinatorialConfigure<OctopusPushSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(OctopusPush, OctopusLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>Octo.exe create-release</c> can be used to automate the creation of releases. This allows you to easily integrate Octopus with other continuous integration servers.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusCreateReleaseSettings.ApiKey"/></li>
        ///     <li><c>--cancelontimeout</c> via <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></li>
        ///     <li><c>--channel</c> via <see cref="OctopusCreateReleaseSettings.Channel"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusCreateReleaseSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusCreateReleaseSettings.Debug"/></li>
        ///     <li><c>--deployat</c> via <see cref="OctopusCreateReleaseSettings.DeployAt"/></li>
        ///     <li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/></li>
        ///     <li><c>--deploymenttimeout</c> via <see cref="OctopusCreateReleaseSettings.DeploymentTimeout"/></li>
        ///     <li><c>--deployto</c> via <see cref="OctopusCreateReleaseSettings.DeployTo"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></li>
        ///     <li><c>--force</c> via <see cref="OctopusCreateReleaseSettings.Force"/></li>
        ///     <li><c>--forcepackagedownload</c> via <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></li>
        ///     <li><c>--guidedfailure</c> via <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></li>
        ///     <li><c>--ignorechannelrules</c> via <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></li>
        ///     <li><c>--ignoreexisting</c> via <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusCreateReleaseSettings.LogLevel"/></li>
        ///     <li><c>--norawlog</c> via <see cref="OctopusCreateReleaseSettings.NoRawLog"/></li>
        ///     <li><c>--package</c> via <see cref="OctopusCreateReleaseSettings.PackageVersions"/></li>
        ///     <li><c>--packageprerelease</c> via <see cref="OctopusCreateReleaseSettings.PackagePrerelease"/></li>
        ///     <li><c>--packagesFolder</c> via <see cref="OctopusCreateReleaseSettings.PackagesFolder"/></li>
        ///     <li><c>--packageversion</c> via <see cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusCreateReleaseSettings.Password"/></li>
        ///     <li><c>--progress</c> via <see cref="OctopusCreateReleaseSettings.Progress"/></li>
        ///     <li><c>--project</c> via <see cref="OctopusCreateReleaseSettings.Project"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusCreateReleaseSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusCreateReleaseSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusCreateReleaseSettings.ProxyUsername"/></li>
        ///     <li><c>--rawlogfile</c> via <see cref="OctopusCreateReleaseSettings.RawLogFile"/></li>
        ///     <li><c>--releasenotes</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotes"/></li>
        ///     <li><c>--releasenotesfile</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusCreateReleaseSettings.Server"/></li>
        ///     <li><c>--skip</c> via <see cref="OctopusCreateReleaseSettings.Skip"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusCreateReleaseSettings.Space"/></li>
        ///     <li><c>--specificmachines</c> via <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></li>
        ///     <li><c>--tenant</c> via <see cref="OctopusCreateReleaseSettings.Tenant"/></li>
        ///     <li><c>--tenanttag</c> via <see cref="OctopusCreateReleaseSettings.TenantTag"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusCreateReleaseSettings.Timeout"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusCreateReleaseSettings.Username"/></li>
        ///     <li><c>--variable</c> via <see cref="OctopusCreateReleaseSettings.Variables"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusCreateReleaseSettings.Version"/></li>
        ///     <li><c>--waitfordeployment</c> via <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></li>
        ///     <li><c>--whatif</c> via <see cref="OctopusCreateReleaseSettings.WhatIf"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctopusCreateRelease(OctopusCreateReleaseSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new OctopusCreateReleaseSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>Octo.exe create-release</c> can be used to automate the creation of releases. This allows you to easily integrate Octopus with other continuous integration servers.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusCreateReleaseSettings.ApiKey"/></li>
        ///     <li><c>--cancelontimeout</c> via <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></li>
        ///     <li><c>--channel</c> via <see cref="OctopusCreateReleaseSettings.Channel"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusCreateReleaseSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusCreateReleaseSettings.Debug"/></li>
        ///     <li><c>--deployat</c> via <see cref="OctopusCreateReleaseSettings.DeployAt"/></li>
        ///     <li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/></li>
        ///     <li><c>--deploymenttimeout</c> via <see cref="OctopusCreateReleaseSettings.DeploymentTimeout"/></li>
        ///     <li><c>--deployto</c> via <see cref="OctopusCreateReleaseSettings.DeployTo"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></li>
        ///     <li><c>--force</c> via <see cref="OctopusCreateReleaseSettings.Force"/></li>
        ///     <li><c>--forcepackagedownload</c> via <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></li>
        ///     <li><c>--guidedfailure</c> via <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></li>
        ///     <li><c>--ignorechannelrules</c> via <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></li>
        ///     <li><c>--ignoreexisting</c> via <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusCreateReleaseSettings.LogLevel"/></li>
        ///     <li><c>--norawlog</c> via <see cref="OctopusCreateReleaseSettings.NoRawLog"/></li>
        ///     <li><c>--package</c> via <see cref="OctopusCreateReleaseSettings.PackageVersions"/></li>
        ///     <li><c>--packageprerelease</c> via <see cref="OctopusCreateReleaseSettings.PackagePrerelease"/></li>
        ///     <li><c>--packagesFolder</c> via <see cref="OctopusCreateReleaseSettings.PackagesFolder"/></li>
        ///     <li><c>--packageversion</c> via <see cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusCreateReleaseSettings.Password"/></li>
        ///     <li><c>--progress</c> via <see cref="OctopusCreateReleaseSettings.Progress"/></li>
        ///     <li><c>--project</c> via <see cref="OctopusCreateReleaseSettings.Project"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusCreateReleaseSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusCreateReleaseSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusCreateReleaseSettings.ProxyUsername"/></li>
        ///     <li><c>--rawlogfile</c> via <see cref="OctopusCreateReleaseSettings.RawLogFile"/></li>
        ///     <li><c>--releasenotes</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotes"/></li>
        ///     <li><c>--releasenotesfile</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusCreateReleaseSettings.Server"/></li>
        ///     <li><c>--skip</c> via <see cref="OctopusCreateReleaseSettings.Skip"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusCreateReleaseSettings.Space"/></li>
        ///     <li><c>--specificmachines</c> via <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></li>
        ///     <li><c>--tenant</c> via <see cref="OctopusCreateReleaseSettings.Tenant"/></li>
        ///     <li><c>--tenanttag</c> via <see cref="OctopusCreateReleaseSettings.TenantTag"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusCreateReleaseSettings.Timeout"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusCreateReleaseSettings.Username"/></li>
        ///     <li><c>--variable</c> via <see cref="OctopusCreateReleaseSettings.Variables"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusCreateReleaseSettings.Version"/></li>
        ///     <li><c>--waitfordeployment</c> via <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></li>
        ///     <li><c>--whatif</c> via <see cref="OctopusCreateReleaseSettings.WhatIf"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctopusCreateRelease(Configure<OctopusCreateReleaseSettings> configurator)
        {
            return OctopusCreateRelease(configurator(new OctopusCreateReleaseSettings()));
        }
        /// <summary>
        ///   <p>The <c>Octo.exe create-release</c> can be used to automate the creation of releases. This allows you to easily integrate Octopus with other continuous integration servers.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusCreateReleaseSettings.ApiKey"/></li>
        ///     <li><c>--cancelontimeout</c> via <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></li>
        ///     <li><c>--channel</c> via <see cref="OctopusCreateReleaseSettings.Channel"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusCreateReleaseSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusCreateReleaseSettings.Debug"/></li>
        ///     <li><c>--deployat</c> via <see cref="OctopusCreateReleaseSettings.DeployAt"/></li>
        ///     <li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/></li>
        ///     <li><c>--deploymenttimeout</c> via <see cref="OctopusCreateReleaseSettings.DeploymentTimeout"/></li>
        ///     <li><c>--deployto</c> via <see cref="OctopusCreateReleaseSettings.DeployTo"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></li>
        ///     <li><c>--force</c> via <see cref="OctopusCreateReleaseSettings.Force"/></li>
        ///     <li><c>--forcepackagedownload</c> via <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></li>
        ///     <li><c>--guidedfailure</c> via <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></li>
        ///     <li><c>--ignorechannelrules</c> via <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></li>
        ///     <li><c>--ignoreexisting</c> via <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusCreateReleaseSettings.LogLevel"/></li>
        ///     <li><c>--norawlog</c> via <see cref="OctopusCreateReleaseSettings.NoRawLog"/></li>
        ///     <li><c>--package</c> via <see cref="OctopusCreateReleaseSettings.PackageVersions"/></li>
        ///     <li><c>--packageprerelease</c> via <see cref="OctopusCreateReleaseSettings.PackagePrerelease"/></li>
        ///     <li><c>--packagesFolder</c> via <see cref="OctopusCreateReleaseSettings.PackagesFolder"/></li>
        ///     <li><c>--packageversion</c> via <see cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusCreateReleaseSettings.Password"/></li>
        ///     <li><c>--progress</c> via <see cref="OctopusCreateReleaseSettings.Progress"/></li>
        ///     <li><c>--project</c> via <see cref="OctopusCreateReleaseSettings.Project"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusCreateReleaseSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusCreateReleaseSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusCreateReleaseSettings.ProxyUsername"/></li>
        ///     <li><c>--rawlogfile</c> via <see cref="OctopusCreateReleaseSettings.RawLogFile"/></li>
        ///     <li><c>--releasenotes</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotes"/></li>
        ///     <li><c>--releasenotesfile</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusCreateReleaseSettings.Server"/></li>
        ///     <li><c>--skip</c> via <see cref="OctopusCreateReleaseSettings.Skip"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusCreateReleaseSettings.Space"/></li>
        ///     <li><c>--specificmachines</c> via <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></li>
        ///     <li><c>--tenant</c> via <see cref="OctopusCreateReleaseSettings.Tenant"/></li>
        ///     <li><c>--tenanttag</c> via <see cref="OctopusCreateReleaseSettings.TenantTag"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusCreateReleaseSettings.Timeout"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusCreateReleaseSettings.Username"/></li>
        ///     <li><c>--variable</c> via <see cref="OctopusCreateReleaseSettings.Variables"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusCreateReleaseSettings.Version"/></li>
        ///     <li><c>--waitfordeployment</c> via <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></li>
        ///     <li><c>--whatif</c> via <see cref="OctopusCreateReleaseSettings.WhatIf"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(OctopusCreateReleaseSettings Settings, IReadOnlyCollection<Output> Output)> OctopusCreateRelease(CombinatorialConfigure<OctopusCreateReleaseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(OctopusCreateRelease, OctopusLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>Octo.exe deploy-release</c> can be used to automate the deployment of releases to environments. This allows you to easily integrate Octopus with other continuous integration servers.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusDeployReleaseSettings.ApiKey"/></li>
        ///     <li><c>--cancelontimeout</c> via <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></li>
        ///     <li><c>--channel</c> via <see cref="OctopusDeployReleaseSettings.Channel"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusDeployReleaseSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusDeployReleaseSettings.Debug"/></li>
        ///     <li><c>--deployat</c> via <see cref="OctopusDeployReleaseSettings.DeployAt"/></li>
        ///     <li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/></li>
        ///     <li><c>--deploymenttimeout</c> via <see cref="OctopusDeployReleaseSettings.DeploymentTimeout"/></li>
        ///     <li><c>--deployto</c> via <see cref="OctopusDeployReleaseSettings.DeployTo"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></li>
        ///     <li><c>--force</c> via <see cref="OctopusDeployReleaseSettings.Force"/></li>
        ///     <li><c>--forcepackagedownload</c> via <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></li>
        ///     <li><c>--guidedfailure</c> via <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusDeployReleaseSettings.LogLevel"/></li>
        ///     <li><c>--norawlog</c> via <see cref="OctopusDeployReleaseSettings.NoRawLog"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusDeployReleaseSettings.Password"/></li>
        ///     <li><c>--progress</c> via <see cref="OctopusDeployReleaseSettings.Progress"/></li>
        ///     <li><c>--project</c> via <see cref="OctopusDeployReleaseSettings.Project"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusDeployReleaseSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusDeployReleaseSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusDeployReleaseSettings.ProxyUsername"/></li>
        ///     <li><c>--rawlogfile</c> via <see cref="OctopusDeployReleaseSettings.RawLogFile"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusDeployReleaseSettings.Server"/></li>
        ///     <li><c>--skip</c> via <see cref="OctopusDeployReleaseSettings.Skip"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusDeployReleaseSettings.Space"/></li>
        ///     <li><c>--specificmachines</c> via <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></li>
        ///     <li><c>--tenant</c> via <see cref="OctopusDeployReleaseSettings.Tenant"/></li>
        ///     <li><c>--tenanttag</c> via <see cref="OctopusDeployReleaseSettings.TenantTag"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusDeployReleaseSettings.Timeout"/></li>
        ///     <li><c>--updateVariables</c> via <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusDeployReleaseSettings.Username"/></li>
        ///     <li><c>--variable</c> via <see cref="OctopusDeployReleaseSettings.Variables"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusDeployReleaseSettings.Version"/></li>
        ///     <li><c>--waitfordeployment</c> via <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctopusDeployRelease(OctopusDeployReleaseSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new OctopusDeployReleaseSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>Octo.exe deploy-release</c> can be used to automate the deployment of releases to environments. This allows you to easily integrate Octopus with other continuous integration servers.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusDeployReleaseSettings.ApiKey"/></li>
        ///     <li><c>--cancelontimeout</c> via <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></li>
        ///     <li><c>--channel</c> via <see cref="OctopusDeployReleaseSettings.Channel"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusDeployReleaseSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusDeployReleaseSettings.Debug"/></li>
        ///     <li><c>--deployat</c> via <see cref="OctopusDeployReleaseSettings.DeployAt"/></li>
        ///     <li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/></li>
        ///     <li><c>--deploymenttimeout</c> via <see cref="OctopusDeployReleaseSettings.DeploymentTimeout"/></li>
        ///     <li><c>--deployto</c> via <see cref="OctopusDeployReleaseSettings.DeployTo"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></li>
        ///     <li><c>--force</c> via <see cref="OctopusDeployReleaseSettings.Force"/></li>
        ///     <li><c>--forcepackagedownload</c> via <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></li>
        ///     <li><c>--guidedfailure</c> via <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusDeployReleaseSettings.LogLevel"/></li>
        ///     <li><c>--norawlog</c> via <see cref="OctopusDeployReleaseSettings.NoRawLog"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusDeployReleaseSettings.Password"/></li>
        ///     <li><c>--progress</c> via <see cref="OctopusDeployReleaseSettings.Progress"/></li>
        ///     <li><c>--project</c> via <see cref="OctopusDeployReleaseSettings.Project"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusDeployReleaseSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusDeployReleaseSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusDeployReleaseSettings.ProxyUsername"/></li>
        ///     <li><c>--rawlogfile</c> via <see cref="OctopusDeployReleaseSettings.RawLogFile"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusDeployReleaseSettings.Server"/></li>
        ///     <li><c>--skip</c> via <see cref="OctopusDeployReleaseSettings.Skip"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusDeployReleaseSettings.Space"/></li>
        ///     <li><c>--specificmachines</c> via <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></li>
        ///     <li><c>--tenant</c> via <see cref="OctopusDeployReleaseSettings.Tenant"/></li>
        ///     <li><c>--tenanttag</c> via <see cref="OctopusDeployReleaseSettings.TenantTag"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusDeployReleaseSettings.Timeout"/></li>
        ///     <li><c>--updateVariables</c> via <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusDeployReleaseSettings.Username"/></li>
        ///     <li><c>--variable</c> via <see cref="OctopusDeployReleaseSettings.Variables"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusDeployReleaseSettings.Version"/></li>
        ///     <li><c>--waitfordeployment</c> via <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctopusDeployRelease(Configure<OctopusDeployReleaseSettings> configurator)
        {
            return OctopusDeployRelease(configurator(new OctopusDeployReleaseSettings()));
        }
        /// <summary>
        ///   <p>The <c>Octo.exe deploy-release</c> can be used to automate the deployment of releases to environments. This allows you to easily integrate Octopus with other continuous integration servers.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusDeployReleaseSettings.ApiKey"/></li>
        ///     <li><c>--cancelontimeout</c> via <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></li>
        ///     <li><c>--channel</c> via <see cref="OctopusDeployReleaseSettings.Channel"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusDeployReleaseSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusDeployReleaseSettings.Debug"/></li>
        ///     <li><c>--deployat</c> via <see cref="OctopusDeployReleaseSettings.DeployAt"/></li>
        ///     <li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/></li>
        ///     <li><c>--deploymenttimeout</c> via <see cref="OctopusDeployReleaseSettings.DeploymentTimeout"/></li>
        ///     <li><c>--deployto</c> via <see cref="OctopusDeployReleaseSettings.DeployTo"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></li>
        ///     <li><c>--force</c> via <see cref="OctopusDeployReleaseSettings.Force"/></li>
        ///     <li><c>--forcepackagedownload</c> via <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></li>
        ///     <li><c>--guidedfailure</c> via <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusDeployReleaseSettings.LogLevel"/></li>
        ///     <li><c>--norawlog</c> via <see cref="OctopusDeployReleaseSettings.NoRawLog"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusDeployReleaseSettings.Password"/></li>
        ///     <li><c>--progress</c> via <see cref="OctopusDeployReleaseSettings.Progress"/></li>
        ///     <li><c>--project</c> via <see cref="OctopusDeployReleaseSettings.Project"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusDeployReleaseSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusDeployReleaseSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusDeployReleaseSettings.ProxyUsername"/></li>
        ///     <li><c>--rawlogfile</c> via <see cref="OctopusDeployReleaseSettings.RawLogFile"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusDeployReleaseSettings.Server"/></li>
        ///     <li><c>--skip</c> via <see cref="OctopusDeployReleaseSettings.Skip"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusDeployReleaseSettings.Space"/></li>
        ///     <li><c>--specificmachines</c> via <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></li>
        ///     <li><c>--tenant</c> via <see cref="OctopusDeployReleaseSettings.Tenant"/></li>
        ///     <li><c>--tenanttag</c> via <see cref="OctopusDeployReleaseSettings.TenantTag"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusDeployReleaseSettings.Timeout"/></li>
        ///     <li><c>--updateVariables</c> via <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusDeployReleaseSettings.Username"/></li>
        ///     <li><c>--variable</c> via <see cref="OctopusDeployReleaseSettings.Variables"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusDeployReleaseSettings.Version"/></li>
        ///     <li><c>--waitfordeployment</c> via <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(OctopusDeployReleaseSettings Settings, IReadOnlyCollection<Output> Output)> OctopusDeployRelease(CombinatorialConfigure<OctopusDeployReleaseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(OctopusDeployRelease, OctopusLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The <c>Octo.exe build-information</c> command push build information to Octopus Server.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusBuildInformationSettings.ApiKey"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusBuildInformationSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusBuildInformationSettings.Debug"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></li>
        ///     <li><c>--file</c> via <see cref="OctopusBuildInformationSettings.File"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusBuildInformationSettings.LogLevel"/></li>
        ///     <li><c>--overwrite-mode</c> via <see cref="OctopusBuildInformationSettings.OverwriteMode"/></li>
        ///     <li><c>--package-id</c> via <see cref="OctopusBuildInformationSettings.PackageId"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusBuildInformationSettings.Password"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusBuildInformationSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusBuildInformationSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusBuildInformationSettings.ProxyUsername"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusBuildInformationSettings.Server"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusBuildInformationSettings.Space"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusBuildInformationSettings.Timeout"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusBuildInformationSettings.Username"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusBuildInformationSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctopusBuildInformation(OctopusBuildInformationSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new OctopusBuildInformationSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>Octo.exe build-information</c> command push build information to Octopus Server.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusBuildInformationSettings.ApiKey"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusBuildInformationSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusBuildInformationSettings.Debug"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></li>
        ///     <li><c>--file</c> via <see cref="OctopusBuildInformationSettings.File"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusBuildInformationSettings.LogLevel"/></li>
        ///     <li><c>--overwrite-mode</c> via <see cref="OctopusBuildInformationSettings.OverwriteMode"/></li>
        ///     <li><c>--package-id</c> via <see cref="OctopusBuildInformationSettings.PackageId"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusBuildInformationSettings.Password"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusBuildInformationSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusBuildInformationSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusBuildInformationSettings.ProxyUsername"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusBuildInformationSettings.Server"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusBuildInformationSettings.Space"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusBuildInformationSettings.Timeout"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusBuildInformationSettings.Username"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusBuildInformationSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctopusBuildInformation(Configure<OctopusBuildInformationSettings> configurator)
        {
            return OctopusBuildInformation(configurator(new OctopusBuildInformationSettings()));
        }
        /// <summary>
        ///   <p>The <c>Octo.exe build-information</c> command push build information to Octopus Server.</p>
        ///   <p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--apiKey</c> via <see cref="OctopusBuildInformationSettings.ApiKey"/></li>
        ///     <li><c>--configFile</c> via <see cref="OctopusBuildInformationSettings.ConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="OctopusBuildInformationSettings.Debug"/></li>
        ///     <li><c>--enableServiceMessages</c> via <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></li>
        ///     <li><c>--file</c> via <see cref="OctopusBuildInformationSettings.File"/></li>
        ///     <li><c>--ignoreSslErrors</c> via <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></li>
        ///     <li><c>--logLevel</c> via <see cref="OctopusBuildInformationSettings.LogLevel"/></li>
        ///     <li><c>--overwrite-mode</c> via <see cref="OctopusBuildInformationSettings.OverwriteMode"/></li>
        ///     <li><c>--package-id</c> via <see cref="OctopusBuildInformationSettings.PackageId"/></li>
        ///     <li><c>--pass</c> via <see cref="OctopusBuildInformationSettings.Password"/></li>
        ///     <li><c>--proxy</c> via <see cref="OctopusBuildInformationSettings.Proxy"/></li>
        ///     <li><c>--proxyPass</c> via <see cref="OctopusBuildInformationSettings.ProxyPassword"/></li>
        ///     <li><c>--proxyUser</c> via <see cref="OctopusBuildInformationSettings.ProxyUsername"/></li>
        ///     <li><c>--server</c> via <see cref="OctopusBuildInformationSettings.Server"/></li>
        ///     <li><c>--space</c> via <see cref="OctopusBuildInformationSettings.Space"/></li>
        ///     <li><c>--timeout</c> via <see cref="OctopusBuildInformationSettings.Timeout"/></li>
        ///     <li><c>--user</c> via <see cref="OctopusBuildInformationSettings.Username"/></li>
        ///     <li><c>--version</c> via <see cref="OctopusBuildInformationSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(OctopusBuildInformationSettings Settings, IReadOnlyCollection<Output> Output)> OctopusBuildInformation(CombinatorialConfigure<OctopusBuildInformationSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(OctopusBuildInformation, OctopusLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region OctopusPackSettings
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctopusPackSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Octopus executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? OctopusTasks.OctopusLogger;
        /// <summary>
        ///   The ID of the package. E.g. <c>MyCompany.MyApp</c>.
        /// </summary>
        public virtual string Id { get; internal set; }
        /// <summary>
        ///   Package format. Options are: NuPkg, Zip. Defaults to NuPkg, though we recommend Zip going forward.
        /// </summary>
        public virtual OctopusPackFormat Format { get; internal set; }
        /// <summary>
        ///   The version of the package; must be a valid SemVer. Defaults to a timestamp-based version.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The folder into which the generated NUPKG file will be written. Defaults to <c>.</c>.
        /// </summary>
        public virtual string OutputFolder { get; internal set; }
        /// <summary>
        ///   The root folder containing files and folders to pack. Defaults to <c>.</c>.
        /// </summary>
        public virtual string BasePath { get; internal set; }
        /// <summary>
        ///   List more detailed output. E.g. Which files are being added.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Add an author to the package metadata. Defaults to the current user.
        /// </summary>
        public virtual IReadOnlyList<string> Authors => AuthorsInternal.AsReadOnly();
        internal List<string> AuthorsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   The title of the package.
        /// </summary>
        public virtual string Title { get; internal set; }
        /// <summary>
        ///   A description of the package. Defaults to a generic description.
        /// </summary>
        public virtual string Description { get; internal set; }
        /// <summary>
        ///   Release notes for this version of the package.
        /// </summary>
        public virtual string ReleaseNotes { get; internal set; }
        /// <summary>
        ///   A file containing release notes for this version of the package.
        /// </summary>
        public virtual string ReleaseNotesFile { get; internal set; }
        /// <summary>
        ///   Add a file pattern to include, relative to the base path. E.g. <c>/bin/-*.dll</c> - if none are specified, defaults to <c>**</c>.
        /// </summary>
        public virtual string Include { get; internal set; }
        /// <summary>
        ///   Allow an existing package file of the same ID/version to be overwritten.
        /// </summary>
        public virtual bool? Overwrite { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("pack")
              .Add("--id={value}", Id)
              .Add("--format={value}", Format)
              .Add("--version={value}", Version)
              .Add("--outFolder={value}", OutputFolder)
              .Add("--basePath={value}", BasePath)
              .Add("--verbose", Verbose)
              .Add("--author={value}", Authors)
              .Add("--title={value}", Title)
              .Add("--description={value}", Description)
              .Add("--releaseNotes={value}", ReleaseNotes)
              .Add("--releaseNotesFile={value}", ReleaseNotesFile)
              .Add("--include={value}", Include)
              .Add("--overwrite", Overwrite);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region OctopusPushSettings
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctopusPushSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Octopus executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? OctopusTasks.OctopusLogger;
        /// <summary>
        ///   Package file to push.
        /// </summary>
        public virtual IReadOnlyList<string> Package => PackageInternal.AsReadOnly();
        internal List<string> PackageInternal { get; set; } = new List<string>();
        /// <summary>
        ///   If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.
        /// </summary>
        public virtual bool? ReplaceExisting { get; internal set; }
        /// <summary>
        ///   The base URL for your Octopus server - e.g., http://your-octopus/
        /// </summary>
        public virtual string Server { get; internal set; }
        /// <summary>
        ///   Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.
        /// </summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary>
        ///   Username to use when authenticating with the server. Your must provide an apiKey or username and password.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Password to use when authenticating with the server.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Text file of default values, with one 'key = value' per line.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Enable debug logging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.
        /// </summary>
        public virtual bool? IgnoreSslErrors { get; internal set; }
        /// <summary>
        ///   Enable TeamCity or Team Foundation Build service messages when logging.
        /// </summary>
        public virtual bool? EnableServiceMessages { get; internal set; }
        /// <summary>
        ///   Timeout in seconds for network operations. Default is 600.
        /// </summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary>
        ///   The URI of the proxy to use, e.g., http://example.com:8080.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   The username for the proxy.
        /// </summary>
        public virtual string ProxyUsername { get; internal set; }
        /// <summary>
        ///   The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   The name of a space within which this command will be executed. The default space will be used if it is omitted.
        /// </summary>
        public virtual string Space { get; internal set; }
        /// <summary>
        ///   The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.
        /// </summary>
        public virtual string LogLevel { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("push")
              .Add("--package={value}", Package)
              .Add("--replace-existing", ReplaceExisting)
              .Add("--server={value}", Server)
              .Add("--apiKey={value}", ApiKey, secret: true)
              .Add("--user={value}", Username)
              .Add("--pass={value}", Password, secret: true)
              .Add("--configFile={value}", ConfigFile)
              .Add("--debug", Debug)
              .Add("--ignoreSslErrors", IgnoreSslErrors)
              .Add("--enableServiceMessages", EnableServiceMessages)
              .Add("--timeout={value}", Timeout)
              .Add("--proxy={value}", Proxy)
              .Add("--proxyUser={value}", ProxyUsername)
              .Add("--proxyPass={value}", ProxyPassword, secret: true)
              .Add("--space={value}", Space)
              .Add("--logLevel={value}", LogLevel);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region OctopusCreateReleaseSettings
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctopusCreateReleaseSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Octopus executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? OctopusTasks.OctopusLogger;
        /// <summary>
        ///   Name of the project.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Default version number of all packages to use for this release.
        /// </summary>
        public virtual string DefaultPackageVersion { get; internal set; }
        /// <summary>
        ///   Release number to use for the new release.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   Channel to use for the new release. Omit this argument to automatically select the best channel.
        /// </summary>
        public virtual string Channel { get; internal set; }
        /// <summary>
        ///   Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> PackageVersions => PackageVersionsInternal.AsReadOnly();
        internal Dictionary<string, string> PackageVersionsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   A folder containing NuGet packages from which we should get versions.
        /// </summary>
        public virtual string PackagesFolder { get; internal set; }
        /// <summary>
        ///   Release Notes for the new release. Styling with Markdown is supported.
        /// </summary>
        public virtual string ReleaseNotes { get; internal set; }
        /// <summary>
        ///   Path to a file that contains Release Notes for the new release. Supports Markdown files.
        /// </summary>
        public virtual string ReleaseNotesFile { get; internal set; }
        /// <summary>
        ///   Don't create this release if there is already one with the same version number.
        /// </summary>
        public virtual bool? IgnoreExisting { get; internal set; }
        /// <summary>
        ///   Create the release ignoring any version rules specified by the channel.
        /// </summary>
        public virtual bool? IgnoreChannelRules { get; internal set; }
        /// <summary>
        ///   Pre-release for latest version of all packages to use for this release.
        /// </summary>
        public virtual string PackagePrerelease { get; internal set; }
        /// <summary>
        ///   Perform a dry run but don't actually create/deploy release.
        /// </summary>
        public virtual bool? WhatIf { get; internal set; }
        /// <summary>
        ///   Show progress of the deployment.
        /// </summary>
        public virtual bool? Progress { get; internal set; }
        /// <summary>
        ///   Whether to force downloading of already installed packages (flag, default false).
        /// </summary>
        public virtual bool? ForcePackageDownload { get; internal set; }
        /// <summary>
        ///   Whether to wait synchronously for deployment to finish.
        /// </summary>
        public virtual bool? WaitForDeployment { get; internal set; }
        /// <summary>
        ///   Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>--waitfordeployment</c> parameter set.
        /// </summary>
        public virtual string DeploymentTimeout { get; internal set; }
        /// <summary>
        ///   Whether to cancel the deployment if the deployment timeout is reached (flag, default false).
        /// </summary>
        public virtual bool? CancelOnTimeout { get; internal set; }
        /// <summary>
        ///   Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).
        /// </summary>
        public virtual string DeploymentCheckSleepCycle { get; internal set; }
        /// <summary>
        ///   Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).
        /// </summary>
        public virtual bool? GuidedFailure { get; internal set; }
        /// <summary>
        ///   A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.
        /// </summary>
        public virtual IReadOnlyList<string> SpecificMachines => SpecificMachinesInternal.AsReadOnly();
        internal List<string> SpecificMachinesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Skip a step by name.
        /// </summary>
        public virtual IReadOnlyList<string> Skip => SkipInternal.AsReadOnly();
        internal List<string> SkipInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Don't print the raw log of failed tasks.
        /// </summary>
        public virtual bool? NoRawLog { get; internal set; }
        /// <summary>
        ///   Redirect the raw log of failed tasks to a file.
        /// </summary>
        public virtual string RawLogFile { get; internal set; }
        /// <summary>
        ///   Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Variables => VariablesInternal.AsReadOnly();
        internal Dictionary<string, string> VariablesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.
        /// </summary>
        public virtual string DeployAt { get; internal set; }
        /// <summary>
        ///   Environment to automatically deploy to, e.g., <c>Production</c>.
        /// </summary>
        public virtual string DeployTo { get; internal set; }
        /// <summary>
        ///   A tenant the deployment will be performed for; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to tenants able to deploy.
        /// </summary>
        public virtual string Tenant { get; internal set; }
        /// <summary>
        ///   A tenant tag used to match tenants that the deployment will be performed for; specify this argument multiple times to add multiple tenant tags.
        /// </summary>
        public virtual string TenantTag { get; internal set; }
        /// <summary>
        ///   The base URL for your Octopus server - e.g., http://your-octopus/
        /// </summary>
        public virtual string Server { get; internal set; }
        /// <summary>
        ///   Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.
        /// </summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary>
        ///   Username to use when authenticating with the server. Your must provide an apiKey or username and password.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Password to use when authenticating with the server.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Text file of default values, with one 'key = value' per line.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Enable debug logging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.
        /// </summary>
        public virtual bool? IgnoreSslErrors { get; internal set; }
        /// <summary>
        ///   Enable TeamCity or Team Foundation Build service messages when logging.
        /// </summary>
        public virtual bool? EnableServiceMessages { get; internal set; }
        /// <summary>
        ///   Timeout in seconds for network operations. Default is 600.
        /// </summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary>
        ///   The URI of the proxy to use, e.g., http://example.com:8080.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   The username for the proxy.
        /// </summary>
        public virtual string ProxyUsername { get; internal set; }
        /// <summary>
        ///   The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   The name of a space within which this command will be executed. The default space will be used if it is omitted.
        /// </summary>
        public virtual string Space { get; internal set; }
        /// <summary>
        ///   The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.
        /// </summary>
        public virtual string LogLevel { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("create-release")
              .Add("--project={value}", Project)
              .Add("--packageversion={value}", DefaultPackageVersion)
              .Add("--version={value}", Version)
              .Add("--channel={value}", Channel)
              .Add("--package={value}", PackageVersions, "{key}:{value}")
              .Add("--packagesFolder={value}", PackagesFolder)
              .Add("--releasenotes={value}", ReleaseNotes)
              .Add("--releasenotesfile={value}", ReleaseNotesFile)
              .Add("--ignoreexisting", IgnoreExisting)
              .Add("--ignorechannelrules", IgnoreChannelRules)
              .Add("--packageprerelease={value}", PackagePrerelease)
              .Add("--whatif", WhatIf)
              .Add("--progress", Progress)
              .Add("--forcepackagedownload", ForcePackageDownload)
              .Add("--waitfordeployment", WaitForDeployment)
              .Add("--deploymenttimeout={value}", DeploymentTimeout)
              .Add("--cancelontimeout", CancelOnTimeout)
              .Add("--deploymentchecksleepcycle={value}", DeploymentCheckSleepCycle)
              .Add("--guidedfailure={value}", GuidedFailure)
              .Add("--specificmachines={value}", SpecificMachines)
              .Add("--force", Force)
              .Add("--skip={value}", Skip)
              .Add("--norawlog", NoRawLog)
              .Add("--rawlogfile={value}", RawLogFile)
              .Add("--variable={value}", Variables, "{key}:{value}")
              .Add("--deployat={value}", DeployAt)
              .Add("--deployto={value}", DeployTo)
              .Add("--tenant={value}", Tenant)
              .Add("--tenanttag={value}", TenantTag)
              .Add("--server={value}", Server)
              .Add("--apiKey={value}", ApiKey, secret: true)
              .Add("--user={value}", Username)
              .Add("--pass={value}", Password, secret: true)
              .Add("--configFile={value}", ConfigFile)
              .Add("--debug", Debug)
              .Add("--ignoreSslErrors", IgnoreSslErrors)
              .Add("--enableServiceMessages", EnableServiceMessages)
              .Add("--timeout={value}", Timeout)
              .Add("--proxy={value}", Proxy)
              .Add("--proxyUser={value}", ProxyUsername)
              .Add("--proxyPass={value}", ProxyPassword, secret: true)
              .Add("--space={value}", Space)
              .Add("--logLevel={value}", LogLevel);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region OctopusDeployReleaseSettings
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctopusDeployReleaseSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Octopus executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? OctopusTasks.OctopusLogger;
        /// <summary>
        ///   Show progress of the deployment.
        /// </summary>
        public virtual bool? Progress { get; internal set; }
        /// <summary>
        ///   Whether to force downloading of already installed packages (flag, default false).
        /// </summary>
        public virtual bool? ForcePackageDownload { get; internal set; }
        /// <summary>
        ///   Whether to wait synchronously for deployment to finish.
        /// </summary>
        public virtual bool? WaitForDepployment { get; internal set; }
        /// <summary>
        ///   Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>WaitForDeployment</c> parameter set.
        /// </summary>
        public virtual string DeploymentTimeout { get; internal set; }
        /// <summary>
        ///   Whether to cancel the deployment if the deployment timeout is reached (flag, default false).
        /// </summary>
        public virtual bool? CancelOnTimeout { get; internal set; }
        /// <summary>
        ///   Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).
        /// </summary>
        public virtual string DeploymentCheckSleepCycle { get; internal set; }
        /// <summary>
        ///   Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).
        /// </summary>
        public virtual bool? GuidedFailure { get; internal set; }
        /// <summary>
        ///   A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.
        /// </summary>
        public virtual IReadOnlyList<string> SpecificMachines => SpecificMachinesInternal.AsReadOnly();
        internal List<string> SpecificMachinesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Skip a step by name.
        /// </summary>
        public virtual IReadOnlyList<string> Skip => SkipInternal.AsReadOnly();
        internal List<string> SkipInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Don't print the raw log of failed tasks.
        /// </summary>
        public virtual bool? NoRawLog { get; internal set; }
        /// <summary>
        ///   Redirect the raw log of failed tasks to a file.
        /// </summary>
        public virtual string RawLogFile { get; internal set; }
        /// <summary>
        ///   Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. 
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Variables => VariablesInternal.AsReadOnly();
        internal Dictionary<string, string> VariablesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.
        /// </summary>
        public virtual string DeployAt { get; internal set; }
        /// <summary>
        ///   Create a deployment for this tenant; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to all tenants who are ready for this release (according to lifecycle).
        /// </summary>
        public virtual string Tenant { get; internal set; }
        /// <summary>
        ///   Create a deployment for tenants matching this tag; specify this argument multiple times to build a query/filter with multiple tags, just like you can in the user interface.
        /// </summary>
        public virtual string TenantTag { get; internal set; }
        /// <summary>
        ///   Name of the project.
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Environment to deploy to, e.g. <c>Production</c>.
        /// </summary>
        public virtual string DeployTo { get; internal set; }
        /// <summary>
        ///   Version number of the release to deploy. Or specify 'latest' for the latest release.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   Channel to use when getting the release to deploy
        /// </summary>
        public virtual string Channel { get; internal set; }
        /// <summary>
        ///   Overwrite the variable snapshot for the release by re-importing the variables from the project
        /// </summary>
        public virtual bool? UpdateVariables { get; internal set; }
        /// <summary>
        ///   The base URL for your Octopus server - e.g., http://your-octopus/
        /// </summary>
        public virtual string Server { get; internal set; }
        /// <summary>
        ///   Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.
        /// </summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary>
        ///   Username to use when authenticating with the server. Your must provide an apiKey or username and password.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Password to use when authenticating with the server.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Text file of default values, with one 'key = value' per line.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Enable debug logging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.
        /// </summary>
        public virtual bool? IgnoreSslErrors { get; internal set; }
        /// <summary>
        ///   Enable TeamCity or Team Foundation Build service messages when logging.
        /// </summary>
        public virtual bool? EnableServiceMessages { get; internal set; }
        /// <summary>
        ///   Timeout in seconds for network operations. Default is 600.
        /// </summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary>
        ///   The URI of the proxy to use, e.g., http://example.com:8080.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   The username for the proxy.
        /// </summary>
        public virtual string ProxyUsername { get; internal set; }
        /// <summary>
        ///   The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   The name of a space within which this command will be executed. The default space will be used if it is omitted.
        /// </summary>
        public virtual string Space { get; internal set; }
        /// <summary>
        ///   The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.
        /// </summary>
        public virtual string LogLevel { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("deploy-release")
              .Add("--progress", Progress)
              .Add("--forcepackagedownload", ForcePackageDownload)
              .Add("--waitfordeployment", WaitForDepployment)
              .Add("--deploymenttimeout={value}", DeploymentTimeout)
              .Add("--cancelontimeout", CancelOnTimeout)
              .Add("--deploymentchecksleepcycle={value}", DeploymentCheckSleepCycle)
              .Add("--guidedfailure={value}", GuidedFailure)
              .Add("--specificmachines={value}", SpecificMachines)
              .Add("--force", Force)
              .Add("--skip={value}", Skip)
              .Add("--norawlog", NoRawLog)
              .Add("--rawlogfile={value}", RawLogFile)
              .Add("--variable={value}", Variables, "{key}:{value}")
              .Add("--deployat={value}", DeployAt)
              .Add("--tenant={value}", Tenant)
              .Add("--tenanttag={value}", TenantTag)
              .Add("--project={value}", Project)
              .Add("--deployto={value}", DeployTo)
              .Add("--version={value}", Version)
              .Add("--channel={value}", Channel)
              .Add("--updateVariables", UpdateVariables)
              .Add("--server={value}", Server)
              .Add("--apiKey={value}", ApiKey, secret: true)
              .Add("--user={value}", Username)
              .Add("--pass={value}", Password, secret: true)
              .Add("--configFile={value}", ConfigFile)
              .Add("--debug", Debug)
              .Add("--ignoreSslErrors", IgnoreSslErrors)
              .Add("--enableServiceMessages", EnableServiceMessages)
              .Add("--timeout={value}", Timeout)
              .Add("--proxy={value}", Proxy)
              .Add("--proxyUser={value}", ProxyUsername)
              .Add("--proxyPass={value}", ProxyPassword, secret: true)
              .Add("--space={value}", Space)
              .Add("--logLevel={value}", LogLevel);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region OctopusBuildInformationSettings
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctopusBuildInformationSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Octopus executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? OctopusTasks.OctopusLogger;
        /// <summary>
        ///   Id of the package.
        /// </summary>
        public virtual IReadOnlyList<string> PackageId => PackageIdInternal.AsReadOnly();
        internal List<string> PackageIdInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Version number of the package.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   Octopus build information json file.
        /// </summary>
        public virtual string File { get; internal set; }
        /// <summary>
        ///   Overwrite policy when the information already exists.
        /// </summary>
        public virtual OctopusOverwriteMode OverwriteMode { get; internal set; }
        /// <summary>
        ///   The base URL for your Octopus server - e.g., http://your-octopus/
        /// </summary>
        public virtual string Server { get; internal set; }
        /// <summary>
        ///   Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.
        /// </summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary>
        ///   Username to use when authenticating with the server. Your must provide an apiKey or username and password.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Password to use when authenticating with the server.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Text file of default values, with one 'key = value' per line.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   Enable debug logging.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.
        /// </summary>
        public virtual bool? IgnoreSslErrors { get; internal set; }
        /// <summary>
        ///   Enable TeamCity or Team Foundation Build service messages when logging.
        /// </summary>
        public virtual bool? EnableServiceMessages { get; internal set; }
        /// <summary>
        ///   Timeout in seconds for network operations. Default is 600.
        /// </summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary>
        ///   The URI of the proxy to use, e.g., http://example.com:8080.
        /// </summary>
        public virtual string Proxy { get; internal set; }
        /// <summary>
        ///   The username for the proxy.
        /// </summary>
        public virtual string ProxyUsername { get; internal set; }
        /// <summary>
        ///   The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.
        /// </summary>
        public virtual string ProxyPassword { get; internal set; }
        /// <summary>
        ///   The name of a space within which this command will be executed. The default space will be used if it is omitted.
        /// </summary>
        public virtual string Space { get; internal set; }
        /// <summary>
        ///   The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.
        /// </summary>
        public virtual string LogLevel { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("build-information")
              .Add("--package-id={value}", PackageId)
              .Add("--version={value}", Version)
              .Add("--file={value}", File)
              .Add("--overwrite-mode={value}", OverwriteMode)
              .Add("--server={value}", Server)
              .Add("--apiKey={value}", ApiKey, secret: true)
              .Add("--user={value}", Username)
              .Add("--pass={value}", Password, secret: true)
              .Add("--configFile={value}", ConfigFile)
              .Add("--debug", Debug)
              .Add("--ignoreSslErrors", IgnoreSslErrors)
              .Add("--enableServiceMessages", EnableServiceMessages)
              .Add("--timeout={value}", Timeout)
              .Add("--proxy={value}", Proxy)
              .Add("--proxyUser={value}", ProxyUsername)
              .Add("--proxyPass={value}", ProxyPassword, secret: true)
              .Add("--space={value}", Space)
              .Add("--logLevel={value}", LogLevel);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region OctopusPackSettingsExtensions
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctopusPackSettingsExtensions
    {
        #region Id
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Id"/></em></p>
        ///   <p>The ID of the package. E.g. <c>MyCompany.MyApp</c>.</p>
        /// </summary>
        [Pure]
        public static T SetId<T>(this T toolSettings, string id) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Id = id;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.Id"/></em></p>
        ///   <p>The ID of the package. E.g. <c>MyCompany.MyApp</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetId<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Id = null;
            return toolSettings;
        }
        #endregion
        #region Format
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Format"/></em></p>
        ///   <p>Package format. Options are: NuPkg, Zip. Defaults to NuPkg, though we recommend Zip going forward.</p>
        /// </summary>
        [Pure]
        public static T SetFormat<T>(this T toolSettings, OctopusPackFormat format) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = format;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.Format"/></em></p>
        ///   <p>Package format. Options are: NuPkg, Zip. Defaults to NuPkg, though we recommend Zip going forward.</p>
        /// </summary>
        [Pure]
        public static T ResetFormat<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Version"/></em></p>
        ///   <p>The version of the package; must be a valid SemVer. Defaults to a timestamp-based version.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.Version"/></em></p>
        ///   <p>The version of the package; must be a valid SemVer. Defaults to a timestamp-based version.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region OutputFolder
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.OutputFolder"/></em></p>
        ///   <p>The folder into which the generated NUPKG file will be written. Defaults to <c>.</c>.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFolder<T>(this T toolSettings, string outputFolder) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = outputFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.OutputFolder"/></em></p>
        ///   <p>The folder into which the generated NUPKG file will be written. Defaults to <c>.</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFolder<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region BasePath
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.BasePath"/></em></p>
        ///   <p>The root folder containing files and folders to pack. Defaults to <c>.</c>.</p>
        /// </summary>
        [Pure]
        public static T SetBasePath<T>(this T toolSettings, string basePath) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = basePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.BasePath"/></em></p>
        ///   <p>The root folder containing files and folders to pack. Defaults to <c>.</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetBasePath<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = null;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Verbose"/></em></p>
        ///   <p>List more detailed output. E.g. Which files are being added.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.Verbose"/></em></p>
        ///   <p>List more detailed output. E.g. Which files are being added.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusPackSettings.Verbose"/></em></p>
        ///   <p>List more detailed output. E.g. Which files are being added.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusPackSettings.Verbose"/></em></p>
        ///   <p>List more detailed output. E.g. Which files are being added.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusPackSettings.Verbose"/></em></p>
        ///   <p>List more detailed output. E.g. Which files are being added.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Authors
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Authors"/> to a new list</em></p>
        ///   <p>Add an author to the package metadata. Defaults to the current user.</p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, params string[] authors) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal = authors.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Authors"/> to a new list</em></p>
        ///   <p>Add an author to the package metadata. Defaults to the current user.</p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal = authors.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusPackSettings.Authors"/></em></p>
        ///   <p>Add an author to the package metadata. Defaults to the current user.</p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, params string[] authors) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal.AddRange(authors);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusPackSettings.Authors"/></em></p>
        ///   <p>Add an author to the package metadata. Defaults to the current user.</p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal.AddRange(authors);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctopusPackSettings.Authors"/></em></p>
        ///   <p>Add an author to the package metadata. Defaults to the current user.</p>
        /// </summary>
        [Pure]
        public static T ClearAuthors<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusPackSettings.Authors"/></em></p>
        ///   <p>Add an author to the package metadata. Defaults to the current user.</p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, params string[] authors) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(authors);
            toolSettings.AuthorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusPackSettings.Authors"/></em></p>
        ///   <p>Add an author to the package metadata. Defaults to the current user.</p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(authors);
            toolSettings.AuthorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Title
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Title"/></em></p>
        ///   <p>The title of the package.</p>
        /// </summary>
        [Pure]
        public static T SetTitle<T>(this T toolSettings, string title) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = title;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.Title"/></em></p>
        ///   <p>The title of the package.</p>
        /// </summary>
        [Pure]
        public static T ResetTitle<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = null;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Description"/></em></p>
        ///   <p>A description of the package. Defaults to a generic description.</p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.Description"/></em></p>
        ///   <p>A description of the package. Defaults to a generic description.</p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseNotes
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.ReleaseNotes"/></em></p>
        ///   <p>Release notes for this version of the package.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseNotes<T>(this T toolSettings, string releaseNotes) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = releaseNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.ReleaseNotes"/></em></p>
        ///   <p>Release notes for this version of the package.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseNotes<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseNotesFile
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.ReleaseNotesFile"/></em></p>
        ///   <p>A file containing release notes for this version of the package.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseNotesFile<T>(this T toolSettings, string releaseNotesFile) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotesFile = releaseNotesFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.ReleaseNotesFile"/></em></p>
        ///   <p>A file containing release notes for this version of the package.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseNotesFile<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotesFile = null;
            return toolSettings;
        }
        #endregion
        #region Include
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Include"/></em></p>
        ///   <p>Add a file pattern to include, relative to the base path. E.g. <c>/bin/-*.dll</c> - if none are specified, defaults to <c>**</c>.</p>
        /// </summary>
        [Pure]
        public static T SetInclude<T>(this T toolSettings, string include) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Include = include;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.Include"/></em></p>
        ///   <p>Add a file pattern to include, relative to the base path. E.g. <c>/bin/-*.dll</c> - if none are specified, defaults to <c>**</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetInclude<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Include = null;
            return toolSettings;
        }
        #endregion
        #region Overwrite
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Overwrite"/></em></p>
        ///   <p>Allow an existing package file of the same ID/version to be overwritten.</p>
        /// </summary>
        [Pure]
        public static T SetOverwrite<T>(this T toolSettings, bool? overwrite) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = overwrite;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.Overwrite"/></em></p>
        ///   <p>Allow an existing package file of the same ID/version to be overwritten.</p>
        /// </summary>
        [Pure]
        public static T ResetOverwrite<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusPackSettings.Overwrite"/></em></p>
        ///   <p>Allow an existing package file of the same ID/version to be overwritten.</p>
        /// </summary>
        [Pure]
        public static T EnableOverwrite<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusPackSettings.Overwrite"/></em></p>
        ///   <p>Allow an existing package file of the same ID/version to be overwritten.</p>
        /// </summary>
        [Pure]
        public static T DisableOverwrite<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusPackSettings.Overwrite"/></em></p>
        ///   <p>Allow an existing package file of the same ID/version to be overwritten.</p>
        /// </summary>
        [Pure]
        public static T ToggleOverwrite<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = !toolSettings.Overwrite;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPackSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPackSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : OctopusPackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctopusPushSettingsExtensions
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctopusPushSettingsExtensions
    {
        #region Package
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.Package"/> to a new list</em></p>
        ///   <p>Package file to push.</p>
        /// </summary>
        [Pure]
        public static T SetPackage<T>(this T toolSettings, params string[] package) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageInternal = package.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.Package"/> to a new list</em></p>
        ///   <p>Package file to push.</p>
        /// </summary>
        [Pure]
        public static T SetPackage<T>(this T toolSettings, IEnumerable<string> package) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageInternal = package.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusPushSettings.Package"/></em></p>
        ///   <p>Package file to push.</p>
        /// </summary>
        [Pure]
        public static T AddPackage<T>(this T toolSettings, params string[] package) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageInternal.AddRange(package);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusPushSettings.Package"/></em></p>
        ///   <p>Package file to push.</p>
        /// </summary>
        [Pure]
        public static T AddPackage<T>(this T toolSettings, IEnumerable<string> package) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageInternal.AddRange(package);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctopusPushSettings.Package"/></em></p>
        ///   <p>Package file to push.</p>
        /// </summary>
        [Pure]
        public static T ClearPackage<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusPushSettings.Package"/></em></p>
        ///   <p>Package file to push.</p>
        /// </summary>
        [Pure]
        public static T RemovePackage<T>(this T toolSettings, params string[] package) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(package);
            toolSettings.PackageInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusPushSettings.Package"/></em></p>
        ///   <p>Package file to push.</p>
        /// </summary>
        [Pure]
        public static T RemovePackage<T>(this T toolSettings, IEnumerable<string> package) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(package);
            toolSettings.PackageInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ReplaceExisting
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.ReplaceExisting"/></em></p>
        ///   <p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p>
        /// </summary>
        [Pure]
        public static T SetReplaceExisting<T>(this T toolSettings, bool? replaceExisting) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReplaceExisting = replaceExisting;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.ReplaceExisting"/></em></p>
        ///   <p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p>
        /// </summary>
        [Pure]
        public static T ResetReplaceExisting<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReplaceExisting = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusPushSettings.ReplaceExisting"/></em></p>
        ///   <p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p>
        /// </summary>
        [Pure]
        public static T EnableReplaceExisting<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReplaceExisting = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusPushSettings.ReplaceExisting"/></em></p>
        ///   <p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p>
        /// </summary>
        [Pure]
        public static T DisableReplaceExisting<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReplaceExisting = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusPushSettings.ReplaceExisting"/></em></p>
        ///   <p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p>
        /// </summary>
        [Pure]
        public static T ToggleReplaceExisting<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReplaceExisting = !toolSettings.ReplaceExisting;
            return toolSettings;
        }
        #endregion
        #region Server
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.Server"/></em></p>
        ///   <p>The base URL for your Octopus server - e.g., http://your-octopus/</p>
        /// </summary>
        [Pure]
        public static T SetServer<T>(this T toolSettings, string server) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = server;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.Server"/></em></p>
        ///   <p>The base URL for your Octopus server - e.g., http://your-octopus/</p>
        /// </summary>
        [Pure]
        public static T ResetServer<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.ApiKey"/></em></p>
        ///   <p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p>
        /// </summary>
        [Pure]
        public static T SetApiKey<T>(this T toolSettings, [Secret] string apiKey) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.ApiKey"/></em></p>
        ///   <p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p>
        /// </summary>
        [Pure]
        public static T ResetApiKey<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.Username"/></em></p>
        ///   <p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.Username"/></em></p>
        ///   <p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.Password"/></em></p>
        ///   <p>Password to use when authenticating with the server.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.Password"/></em></p>
        ///   <p>Password to use when authenticating with the server.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.ConfigFile"/></em></p>
        ///   <p>Text file of default values, with one 'key = value' per line.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.ConfigFile"/></em></p>
        ///   <p>Text file of default values, with one 'key = value' per line.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusPushSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusPushSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusPushSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region IgnoreSslErrors
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreSslErrors<T>(this T toolSettings, bool? ignoreSslErrors) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = ignoreSslErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreSslErrors<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusPushSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreSslErrors<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusPushSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreSslErrors<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusPushSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreSslErrors<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = !toolSettings.IgnoreSslErrors;
            return toolSettings;
        }
        #endregion
        #region EnableServiceMessages
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T SetEnableServiceMessages<T>(this T toolSettings, bool? enableServiceMessages) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = enableServiceMessages;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T ResetEnableServiceMessages<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusPushSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T EnableEnableServiceMessages<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusPushSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T DisableEnableServiceMessages<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusPushSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T ToggleEnableServiceMessages<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = !toolSettings.EnableServiceMessages;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.Timeout"/></em></p>
        ///   <p>Timeout in seconds for network operations. Default is 600.</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, int? timeout) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.Timeout"/></em></p>
        ///   <p>Timeout in seconds for network operations. Default is 600.</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.Proxy"/></em></p>
        ///   <p>The URI of the proxy to use, e.g., http://example.com:8080.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.Proxy"/></em></p>
        ///   <p>The URI of the proxy to use, e.g., http://example.com:8080.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUsername
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.ProxyUsername"/></em></p>
        ///   <p>The username for the proxy.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUsername<T>(this T toolSettings, string proxyUsername) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = proxyUsername;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.ProxyUsername"/></em></p>
        ///   <p>The username for the proxy.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUsername<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.ProxyPassword"/></em></p>
        ///   <p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.ProxyPassword"/></em></p>
        ///   <p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region Space
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.Space"/></em></p>
        ///   <p>The name of a space within which this command will be executed. The default space will be used if it is omitted.</p>
        /// </summary>
        [Pure]
        public static T SetSpace<T>(this T toolSettings, string space) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = space;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.Space"/></em></p>
        ///   <p>The name of a space within which this command will be executed. The default space will be used if it is omitted.</p>
        /// </summary>
        [Pure]
        public static T ResetSpace<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = null;
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.LogLevel"/></em></p>
        ///   <p>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</p>
        /// </summary>
        [Pure]
        public static T SetLogLevel<T>(this T toolSettings, string logLevel) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.LogLevel"/></em></p>
        ///   <p>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</p>
        /// </summary>
        [Pure]
        public static T ResetLogLevel<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusPushSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusPushSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : OctopusPushSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctopusCreateReleaseSettingsExtensions
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctopusCreateReleaseSettingsExtensions
    {
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Project"/></em></p>
        ///   <p>Name of the project.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Project"/></em></p>
        ///   <p>Name of the project.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region DefaultPackageVersion
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/></em></p>
        ///   <p>Default version number of all packages to use for this release.</p>
        /// </summary>
        [Pure]
        public static T SetDefaultPackageVersion<T>(this T toolSettings, string defaultPackageVersion) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPackageVersion = defaultPackageVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/></em></p>
        ///   <p>Default version number of all packages to use for this release.</p>
        /// </summary>
        [Pure]
        public static T ResetDefaultPackageVersion<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPackageVersion = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Version"/></em></p>
        ///   <p>Release number to use for the new release.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Version"/></em></p>
        ///   <p>Release number to use for the new release.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Channel
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Channel"/></em></p>
        ///   <p>Channel to use for the new release. Omit this argument to automatically select the best channel.</p>
        /// </summary>
        [Pure]
        public static T SetChannel<T>(this T toolSettings, string channel) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Channel = channel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Channel"/></em></p>
        ///   <p>Channel to use for the new release. Omit this argument to automatically select the best channel.</p>
        /// </summary>
        [Pure]
        public static T ResetChannel<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Channel = null;
            return toolSettings;
        }
        #endregion
        #region PackageVersions
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.PackageVersions"/> to a new dictionary</em></p>
        ///   <p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p>
        /// </summary>
        [Pure]
        public static T SetPackageVersions<T>(this T toolSettings, IDictionary<string, string> packageVersions) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersionsInternal = packageVersions.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctopusCreateReleaseSettings.PackageVersions"/></em></p>
        ///   <p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearPackageVersions<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="OctopusCreateReleaseSettings.PackageVersions"/></em></p>
        ///   <p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p>
        /// </summary>
        [Pure]
        public static T AddPackageVersion<T>(this T toolSettings, string packageVersionKey, string packageVersionValue) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersionsInternal.Add(packageVersionKey, packageVersionValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="OctopusCreateReleaseSettings.PackageVersions"/></em></p>
        ///   <p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p>
        /// </summary>
        [Pure]
        public static T RemovePackageVersion<T>(this T toolSettings, string packageVersionKey) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersionsInternal.Remove(packageVersionKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="OctopusCreateReleaseSettings.PackageVersions"/></em></p>
        ///   <p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p>
        /// </summary>
        [Pure]
        public static T SetPackageVersion<T>(this T toolSettings, string packageVersionKey, string packageVersionValue) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersionsInternal[packageVersionKey] = packageVersionValue;
            return toolSettings;
        }
        #endregion
        #region PackagesFolder
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.PackagesFolder"/></em></p>
        ///   <p>A folder containing NuGet packages from which we should get versions.</p>
        /// </summary>
        [Pure]
        public static T SetPackagesFolder<T>(this T toolSettings, string packagesFolder) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesFolder = packagesFolder;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.PackagesFolder"/></em></p>
        ///   <p>A folder containing NuGet packages from which we should get versions.</p>
        /// </summary>
        [Pure]
        public static T ResetPackagesFolder<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesFolder = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseNotes
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.ReleaseNotes"/></em></p>
        ///   <p>Release Notes for the new release. Styling with Markdown is supported.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseNotes<T>(this T toolSettings, string releaseNotes) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = releaseNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.ReleaseNotes"/></em></p>
        ///   <p>Release Notes for the new release. Styling with Markdown is supported.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseNotes<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseNotesFile
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/></em></p>
        ///   <p>Path to a file that contains Release Notes for the new release. Supports Markdown files.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseNotesFile<T>(this T toolSettings, string releaseNotesFile) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotesFile = releaseNotesFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/></em></p>
        ///   <p>Path to a file that contains Release Notes for the new release. Supports Markdown files.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseNotesFile<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotesFile = null;
            return toolSettings;
        }
        #endregion
        #region IgnoreExisting
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></em></p>
        ///   <p>Don't create this release if there is already one with the same version number.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreExisting<T>(this T toolSettings, bool? ignoreExisting) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreExisting = ignoreExisting;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></em></p>
        ///   <p>Don't create this release if there is already one with the same version number.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreExisting<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreExisting = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></em></p>
        ///   <p>Don't create this release if there is already one with the same version number.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreExisting<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreExisting = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></em></p>
        ///   <p>Don't create this release if there is already one with the same version number.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreExisting<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreExisting = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></em></p>
        ///   <p>Don't create this release if there is already one with the same version number.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreExisting<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreExisting = !toolSettings.IgnoreExisting;
            return toolSettings;
        }
        #endregion
        #region IgnoreChannelRules
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></em></p>
        ///   <p>Create the release ignoring any version rules specified by the channel.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreChannelRules<T>(this T toolSettings, bool? ignoreChannelRules) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChannelRules = ignoreChannelRules;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></em></p>
        ///   <p>Create the release ignoring any version rules specified by the channel.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreChannelRules<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChannelRules = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></em></p>
        ///   <p>Create the release ignoring any version rules specified by the channel.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreChannelRules<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChannelRules = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></em></p>
        ///   <p>Create the release ignoring any version rules specified by the channel.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreChannelRules<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChannelRules = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></em></p>
        ///   <p>Create the release ignoring any version rules specified by the channel.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreChannelRules<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChannelRules = !toolSettings.IgnoreChannelRules;
            return toolSettings;
        }
        #endregion
        #region PackagePrerelease
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.PackagePrerelease"/></em></p>
        ///   <p>Pre-release for latest version of all packages to use for this release.</p>
        /// </summary>
        [Pure]
        public static T SetPackagePrerelease<T>(this T toolSettings, string packagePrerelease) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagePrerelease = packagePrerelease;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.PackagePrerelease"/></em></p>
        ///   <p>Pre-release for latest version of all packages to use for this release.</p>
        /// </summary>
        [Pure]
        public static T ResetPackagePrerelease<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagePrerelease = null;
            return toolSettings;
        }
        #endregion
        #region WhatIf
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.WhatIf"/></em></p>
        ///   <p>Perform a dry run but don't actually create/deploy release.</p>
        /// </summary>
        [Pure]
        public static T SetWhatIf<T>(this T toolSettings, bool? whatIf) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhatIf = whatIf;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.WhatIf"/></em></p>
        ///   <p>Perform a dry run but don't actually create/deploy release.</p>
        /// </summary>
        [Pure]
        public static T ResetWhatIf<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhatIf = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.WhatIf"/></em></p>
        ///   <p>Perform a dry run but don't actually create/deploy release.</p>
        /// </summary>
        [Pure]
        public static T EnableWhatIf<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhatIf = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.WhatIf"/></em></p>
        ///   <p>Perform a dry run but don't actually create/deploy release.</p>
        /// </summary>
        [Pure]
        public static T DisableWhatIf<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhatIf = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.WhatIf"/></em></p>
        ///   <p>Perform a dry run but don't actually create/deploy release.</p>
        /// </summary>
        [Pure]
        public static T ToggleWhatIf<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhatIf = !toolSettings.WhatIf;
            return toolSettings;
        }
        #endregion
        #region Progress
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Progress"/></em></p>
        ///   <p>Show progress of the deployment.</p>
        /// </summary>
        [Pure]
        public static T SetProgress<T>(this T toolSettings, bool? progress) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = progress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Progress"/></em></p>
        ///   <p>Show progress of the deployment.</p>
        /// </summary>
        [Pure]
        public static T ResetProgress<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.Progress"/></em></p>
        ///   <p>Show progress of the deployment.</p>
        /// </summary>
        [Pure]
        public static T EnableProgress<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.Progress"/></em></p>
        ///   <p>Show progress of the deployment.</p>
        /// </summary>
        [Pure]
        public static T DisableProgress<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.Progress"/></em></p>
        ///   <p>Show progress of the deployment.</p>
        /// </summary>
        [Pure]
        public static T ToggleProgress<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = !toolSettings.Progress;
            return toolSettings;
        }
        #endregion
        #region ForcePackageDownload
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></em></p>
        ///   <p>Whether to force downloading of already installed packages (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T SetForcePackageDownload<T>(this T toolSettings, bool? forcePackageDownload) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = forcePackageDownload;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></em></p>
        ///   <p>Whether to force downloading of already installed packages (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ResetForcePackageDownload<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></em></p>
        ///   <p>Whether to force downloading of already installed packages (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T EnableForcePackageDownload<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></em></p>
        ///   <p>Whether to force downloading of already installed packages (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T DisableForcePackageDownload<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></em></p>
        ///   <p>Whether to force downloading of already installed packages (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ToggleForcePackageDownload<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = !toolSettings.ForcePackageDownload;
            return toolSettings;
        }
        #endregion
        #region WaitForDeployment
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></em></p>
        ///   <p>Whether to wait synchronously for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T SetWaitForDeployment<T>(this T toolSettings, bool? waitForDeployment) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDeployment = waitForDeployment;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></em></p>
        ///   <p>Whether to wait synchronously for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T ResetWaitForDeployment<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDeployment = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></em></p>
        ///   <p>Whether to wait synchronously for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T EnableWaitForDeployment<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDeployment = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></em></p>
        ///   <p>Whether to wait synchronously for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T DisableWaitForDeployment<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDeployment = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></em></p>
        ///   <p>Whether to wait synchronously for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T ToggleWaitForDeployment<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDeployment = !toolSettings.WaitForDeployment;
            return toolSettings;
        }
        #endregion
        #region DeploymentTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.DeploymentTimeout"/></em></p>
        ///   <p>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>--waitfordeployment</c> parameter set.</p>
        /// </summary>
        [Pure]
        public static T SetDeploymentTimeout<T>(this T toolSettings, string deploymentTimeout) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentTimeout = deploymentTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.DeploymentTimeout"/></em></p>
        ///   <p>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>--waitfordeployment</c> parameter set.</p>
        /// </summary>
        [Pure]
        public static T ResetDeploymentTimeout<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CancelOnTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></em></p>
        ///   <p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T SetCancelOnTimeout<T>(this T toolSettings, bool? cancelOnTimeout) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = cancelOnTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></em></p>
        ///   <p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ResetCancelOnTimeout<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></em></p>
        ///   <p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T EnableCancelOnTimeout<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></em></p>
        ///   <p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T DisableCancelOnTimeout<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></em></p>
        ///   <p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ToggleCancelOnTimeout<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = !toolSettings.CancelOnTimeout;
            return toolSettings;
        }
        #endregion
        #region DeploymentCheckSleepCycle
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/></em></p>
        ///   <p>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</p>
        /// </summary>
        [Pure]
        public static T SetDeploymentCheckSleepCycle<T>(this T toolSettings, string deploymentCheckSleepCycle) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentCheckSleepCycle = deploymentCheckSleepCycle;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/></em></p>
        ///   <p>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</p>
        /// </summary>
        [Pure]
        public static T ResetDeploymentCheckSleepCycle<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentCheckSleepCycle = null;
            return toolSettings;
        }
        #endregion
        #region GuidedFailure
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></em></p>
        ///   <p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p>
        /// </summary>
        [Pure]
        public static T SetGuidedFailure<T>(this T toolSettings, bool? guidedFailure) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = guidedFailure;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></em></p>
        ///   <p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p>
        /// </summary>
        [Pure]
        public static T ResetGuidedFailure<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></em></p>
        ///   <p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p>
        /// </summary>
        [Pure]
        public static T EnableGuidedFailure<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></em></p>
        ///   <p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p>
        /// </summary>
        [Pure]
        public static T DisableGuidedFailure<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></em></p>
        ///   <p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p>
        /// </summary>
        [Pure]
        public static T ToggleGuidedFailure<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = !toolSettings.GuidedFailure;
            return toolSettings;
        }
        #endregion
        #region SpecificMachines
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.SpecificMachines"/> to a new list</em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T SetSpecificMachines<T>(this T toolSettings, params string[] specificMachines) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal = specificMachines.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.SpecificMachines"/> to a new list</em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T SetSpecificMachines<T>(this T toolSettings, IEnumerable<string> specificMachines) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal = specificMachines.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T AddSpecificMachines<T>(this T toolSettings, params string[] specificMachines) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.AddRange(specificMachines);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T AddSpecificMachines<T>(this T toolSettings, IEnumerable<string> specificMachines) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.AddRange(specificMachines);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T ClearSpecificMachines<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T RemoveSpecificMachines<T>(this T toolSettings, params string[] specificMachines) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(specificMachines);
            toolSettings.SpecificMachinesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T RemoveSpecificMachines<T>(this T toolSettings, IEnumerable<string> specificMachines) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(specificMachines);
            toolSettings.SpecificMachinesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Force"/></em></p>
        ///   <p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Force"/></em></p>
        ///   <p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.Force"/></em></p>
        ///   <p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.Force"/></em></p>
        ///   <p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.Force"/></em></p>
        ///   <p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Skip
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Skip"/> to a new list</em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T SetSkip<T>(this T toolSettings, params string[] skip) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal = skip.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Skip"/> to a new list</em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T SetSkip<T>(this T toolSettings, IEnumerable<string> skip) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal = skip.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusCreateReleaseSettings.Skip"/></em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T AddSkip<T>(this T toolSettings, params string[] skip) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.AddRange(skip);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusCreateReleaseSettings.Skip"/></em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T AddSkip<T>(this T toolSettings, IEnumerable<string> skip) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.AddRange(skip);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctopusCreateReleaseSettings.Skip"/></em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T ClearSkip<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusCreateReleaseSettings.Skip"/></em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T RemoveSkip<T>(this T toolSettings, params string[] skip) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(skip);
            toolSettings.SkipInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusCreateReleaseSettings.Skip"/></em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T RemoveSkip<T>(this T toolSettings, IEnumerable<string> skip) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(skip);
            toolSettings.SkipInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoRawLog
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.NoRawLog"/></em></p>
        ///   <p>Don't print the raw log of failed tasks.</p>
        /// </summary>
        [Pure]
        public static T SetNoRawLog<T>(this T toolSettings, bool? noRawLog) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = noRawLog;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.NoRawLog"/></em></p>
        ///   <p>Don't print the raw log of failed tasks.</p>
        /// </summary>
        [Pure]
        public static T ResetNoRawLog<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.NoRawLog"/></em></p>
        ///   <p>Don't print the raw log of failed tasks.</p>
        /// </summary>
        [Pure]
        public static T EnableNoRawLog<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.NoRawLog"/></em></p>
        ///   <p>Don't print the raw log of failed tasks.</p>
        /// </summary>
        [Pure]
        public static T DisableNoRawLog<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.NoRawLog"/></em></p>
        ///   <p>Don't print the raw log of failed tasks.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoRawLog<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = !toolSettings.NoRawLog;
            return toolSettings;
        }
        #endregion
        #region RawLogFile
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.RawLogFile"/></em></p>
        ///   <p>Redirect the raw log of failed tasks to a file.</p>
        /// </summary>
        [Pure]
        public static T SetRawLogFile<T>(this T toolSettings, string rawLogFile) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawLogFile = rawLogFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.RawLogFile"/></em></p>
        ///   <p>Redirect the raw log of failed tasks to a file.</p>
        /// </summary>
        [Pure]
        public static T ResetRawLogFile<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawLogFile = null;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Variables"/> to a new dictionary</em></p>
        ///   <p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p>
        /// </summary>
        [Pure]
        public static T SetVariables<T>(this T toolSettings, IDictionary<string, string> variables) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal = variables.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctopusCreateReleaseSettings.Variables"/></em></p>
        ///   <p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p>
        /// </summary>
        [Pure]
        public static T ClearVariables<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="OctopusCreateReleaseSettings.Variables"/></em></p>
        ///   <p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p>
        /// </summary>
        [Pure]
        public static T AddVariable<T>(this T toolSettings, string variableKey, string variableValue) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Add(variableKey, variableValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="OctopusCreateReleaseSettings.Variables"/></em></p>
        ///   <p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p>
        /// </summary>
        [Pure]
        public static T RemoveVariable<T>(this T toolSettings, string variableKey) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Remove(variableKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="OctopusCreateReleaseSettings.Variables"/></em></p>
        ///   <p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p>
        /// </summary>
        [Pure]
        public static T SetVariable<T>(this T toolSettings, string variableKey, string variableValue) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal[variableKey] = variableValue;
            return toolSettings;
        }
        #endregion
        #region DeployAt
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.DeployAt"/></em></p>
        ///   <p>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</p>
        /// </summary>
        [Pure]
        public static T SetDeployAt<T>(this T toolSettings, string deployAt) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployAt = deployAt;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.DeployAt"/></em></p>
        ///   <p>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</p>
        /// </summary>
        [Pure]
        public static T ResetDeployAt<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployAt = null;
            return toolSettings;
        }
        #endregion
        #region DeployTo
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.DeployTo"/></em></p>
        ///   <p>Environment to automatically deploy to, e.g., <c>Production</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDeployTo<T>(this T toolSettings, string deployTo) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployTo = deployTo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.DeployTo"/></em></p>
        ///   <p>Environment to automatically deploy to, e.g., <c>Production</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDeployTo<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployTo = null;
            return toolSettings;
        }
        #endregion
        #region Tenant
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Tenant"/></em></p>
        ///   <p>A tenant the deployment will be performed for; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to tenants able to deploy.</p>
        /// </summary>
        [Pure]
        public static T SetTenant<T>(this T toolSettings, string tenant) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tenant = tenant;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Tenant"/></em></p>
        ///   <p>A tenant the deployment will be performed for; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to tenants able to deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetTenant<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tenant = null;
            return toolSettings;
        }
        #endregion
        #region TenantTag
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.TenantTag"/></em></p>
        ///   <p>A tenant tag used to match tenants that the deployment will be performed for; specify this argument multiple times to add multiple tenant tags.</p>
        /// </summary>
        [Pure]
        public static T SetTenantTag<T>(this T toolSettings, string tenantTag) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TenantTag = tenantTag;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.TenantTag"/></em></p>
        ///   <p>A tenant tag used to match tenants that the deployment will be performed for; specify this argument multiple times to add multiple tenant tags.</p>
        /// </summary>
        [Pure]
        public static T ResetTenantTag<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TenantTag = null;
            return toolSettings;
        }
        #endregion
        #region Server
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Server"/></em></p>
        ///   <p>The base URL for your Octopus server - e.g., http://your-octopus/</p>
        /// </summary>
        [Pure]
        public static T SetServer<T>(this T toolSettings, string server) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = server;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Server"/></em></p>
        ///   <p>The base URL for your Octopus server - e.g., http://your-octopus/</p>
        /// </summary>
        [Pure]
        public static T ResetServer<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.ApiKey"/></em></p>
        ///   <p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p>
        /// </summary>
        [Pure]
        public static T SetApiKey<T>(this T toolSettings, [Secret] string apiKey) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.ApiKey"/></em></p>
        ///   <p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p>
        /// </summary>
        [Pure]
        public static T ResetApiKey<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Username"/></em></p>
        ///   <p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Username"/></em></p>
        ///   <p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Password"/></em></p>
        ///   <p>Password to use when authenticating with the server.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Password"/></em></p>
        ///   <p>Password to use when authenticating with the server.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.ConfigFile"/></em></p>
        ///   <p>Text file of default values, with one 'key = value' per line.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.ConfigFile"/></em></p>
        ///   <p>Text file of default values, with one 'key = value' per line.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region IgnoreSslErrors
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreSslErrors<T>(this T toolSettings, bool? ignoreSslErrors) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = ignoreSslErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreSslErrors<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreSslErrors<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreSslErrors<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreSslErrors<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = !toolSettings.IgnoreSslErrors;
            return toolSettings;
        }
        #endregion
        #region EnableServiceMessages
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T SetEnableServiceMessages<T>(this T toolSettings, bool? enableServiceMessages) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = enableServiceMessages;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T ResetEnableServiceMessages<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T EnableEnableServiceMessages<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T DisableEnableServiceMessages<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T ToggleEnableServiceMessages<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = !toolSettings.EnableServiceMessages;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Timeout"/></em></p>
        ///   <p>Timeout in seconds for network operations. Default is 600.</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, int? timeout) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Timeout"/></em></p>
        ///   <p>Timeout in seconds for network operations. Default is 600.</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Proxy"/></em></p>
        ///   <p>The URI of the proxy to use, e.g., http://example.com:8080.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Proxy"/></em></p>
        ///   <p>The URI of the proxy to use, e.g., http://example.com:8080.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUsername
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.ProxyUsername"/></em></p>
        ///   <p>The username for the proxy.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUsername<T>(this T toolSettings, string proxyUsername) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = proxyUsername;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.ProxyUsername"/></em></p>
        ///   <p>The username for the proxy.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUsername<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.ProxyPassword"/></em></p>
        ///   <p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.ProxyPassword"/></em></p>
        ///   <p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region Space
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Space"/></em></p>
        ///   <p>The name of a space within which this command will be executed. The default space will be used if it is omitted.</p>
        /// </summary>
        [Pure]
        public static T SetSpace<T>(this T toolSettings, string space) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = space;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Space"/></em></p>
        ///   <p>The name of a space within which this command will be executed. The default space will be used if it is omitted.</p>
        /// </summary>
        [Pure]
        public static T ResetSpace<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = null;
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.LogLevel"/></em></p>
        ///   <p>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</p>
        /// </summary>
        [Pure]
        public static T SetLogLevel<T>(this T toolSettings, string logLevel) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.LogLevel"/></em></p>
        ///   <p>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</p>
        /// </summary>
        [Pure]
        public static T ResetLogLevel<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusCreateReleaseSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusCreateReleaseSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : OctopusCreateReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctopusDeployReleaseSettingsExtensions
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctopusDeployReleaseSettingsExtensions
    {
        #region Progress
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Progress"/></em></p>
        ///   <p>Show progress of the deployment.</p>
        /// </summary>
        [Pure]
        public static T SetProgress<T>(this T toolSettings, bool? progress) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = progress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Progress"/></em></p>
        ///   <p>Show progress of the deployment.</p>
        /// </summary>
        [Pure]
        public static T ResetProgress<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.Progress"/></em></p>
        ///   <p>Show progress of the deployment.</p>
        /// </summary>
        [Pure]
        public static T EnableProgress<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.Progress"/></em></p>
        ///   <p>Show progress of the deployment.</p>
        /// </summary>
        [Pure]
        public static T DisableProgress<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.Progress"/></em></p>
        ///   <p>Show progress of the deployment.</p>
        /// </summary>
        [Pure]
        public static T ToggleProgress<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = !toolSettings.Progress;
            return toolSettings;
        }
        #endregion
        #region ForcePackageDownload
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></em></p>
        ///   <p>Whether to force downloading of already installed packages (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T SetForcePackageDownload<T>(this T toolSettings, bool? forcePackageDownload) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = forcePackageDownload;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></em></p>
        ///   <p>Whether to force downloading of already installed packages (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ResetForcePackageDownload<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></em></p>
        ///   <p>Whether to force downloading of already installed packages (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T EnableForcePackageDownload<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></em></p>
        ///   <p>Whether to force downloading of already installed packages (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T DisableForcePackageDownload<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></em></p>
        ///   <p>Whether to force downloading of already installed packages (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ToggleForcePackageDownload<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = !toolSettings.ForcePackageDownload;
            return toolSettings;
        }
        #endregion
        #region WaitForDepployment
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></em></p>
        ///   <p>Whether to wait synchronously for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T SetWaitForDepployment<T>(this T toolSettings, bool? waitForDepployment) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = waitForDepployment;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></em></p>
        ///   <p>Whether to wait synchronously for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T ResetWaitForDepployment<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></em></p>
        ///   <p>Whether to wait synchronously for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T EnableWaitForDepployment<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></em></p>
        ///   <p>Whether to wait synchronously for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T DisableWaitForDepployment<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></em></p>
        ///   <p>Whether to wait synchronously for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T ToggleWaitForDepployment<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = !toolSettings.WaitForDepployment;
            return toolSettings;
        }
        #endregion
        #region DeploymentTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.DeploymentTimeout"/></em></p>
        ///   <p>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>WaitForDeployment</c> parameter set.</p>
        /// </summary>
        [Pure]
        public static T SetDeploymentTimeout<T>(this T toolSettings, string deploymentTimeout) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentTimeout = deploymentTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.DeploymentTimeout"/></em></p>
        ///   <p>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>WaitForDeployment</c> parameter set.</p>
        /// </summary>
        [Pure]
        public static T ResetDeploymentTimeout<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CancelOnTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></em></p>
        ///   <p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T SetCancelOnTimeout<T>(this T toolSettings, bool? cancelOnTimeout) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = cancelOnTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></em></p>
        ///   <p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ResetCancelOnTimeout<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></em></p>
        ///   <p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T EnableCancelOnTimeout<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></em></p>
        ///   <p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T DisableCancelOnTimeout<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></em></p>
        ///   <p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ToggleCancelOnTimeout<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = !toolSettings.CancelOnTimeout;
            return toolSettings;
        }
        #endregion
        #region DeploymentCheckSleepCycle
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/></em></p>
        ///   <p>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</p>
        /// </summary>
        [Pure]
        public static T SetDeploymentCheckSleepCycle<T>(this T toolSettings, string deploymentCheckSleepCycle) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentCheckSleepCycle = deploymentCheckSleepCycle;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/></em></p>
        ///   <p>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</p>
        /// </summary>
        [Pure]
        public static T ResetDeploymentCheckSleepCycle<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentCheckSleepCycle = null;
            return toolSettings;
        }
        #endregion
        #region GuidedFailure
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></em></p>
        ///   <p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p>
        /// </summary>
        [Pure]
        public static T SetGuidedFailure<T>(this T toolSettings, bool? guidedFailure) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = guidedFailure;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></em></p>
        ///   <p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p>
        /// </summary>
        [Pure]
        public static T ResetGuidedFailure<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></em></p>
        ///   <p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p>
        /// </summary>
        [Pure]
        public static T EnableGuidedFailure<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></em></p>
        ///   <p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p>
        /// </summary>
        [Pure]
        public static T DisableGuidedFailure<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></em></p>
        ///   <p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p>
        /// </summary>
        [Pure]
        public static T ToggleGuidedFailure<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = !toolSettings.GuidedFailure;
            return toolSettings;
        }
        #endregion
        #region SpecificMachines
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.SpecificMachines"/> to a new list</em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T SetSpecificMachines<T>(this T toolSettings, params string[] specificMachines) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal = specificMachines.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.SpecificMachines"/> to a new list</em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T SetSpecificMachines<T>(this T toolSettings, IEnumerable<string> specificMachines) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal = specificMachines.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T AddSpecificMachines<T>(this T toolSettings, params string[] specificMachines) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.AddRange(specificMachines);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T AddSpecificMachines<T>(this T toolSettings, IEnumerable<string> specificMachines) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.AddRange(specificMachines);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T ClearSpecificMachines<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T RemoveSpecificMachines<T>(this T toolSettings, params string[] specificMachines) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(specificMachines);
            toolSettings.SpecificMachinesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></em></p>
        ///   <p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p>
        /// </summary>
        [Pure]
        public static T RemoveSpecificMachines<T>(this T toolSettings, IEnumerable<string> specificMachines) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(specificMachines);
            toolSettings.SpecificMachinesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Force"/></em></p>
        ///   <p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Force"/></em></p>
        ///   <p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.Force"/></em></p>
        ///   <p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.Force"/></em></p>
        ///   <p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.Force"/></em></p>
        ///   <p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Skip
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Skip"/> to a new list</em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T SetSkip<T>(this T toolSettings, params string[] skip) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal = skip.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Skip"/> to a new list</em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T SetSkip<T>(this T toolSettings, IEnumerable<string> skip) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal = skip.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusDeployReleaseSettings.Skip"/></em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T AddSkip<T>(this T toolSettings, params string[] skip) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.AddRange(skip);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusDeployReleaseSettings.Skip"/></em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T AddSkip<T>(this T toolSettings, IEnumerable<string> skip) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.AddRange(skip);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctopusDeployReleaseSettings.Skip"/></em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T ClearSkip<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusDeployReleaseSettings.Skip"/></em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T RemoveSkip<T>(this T toolSettings, params string[] skip) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(skip);
            toolSettings.SkipInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusDeployReleaseSettings.Skip"/></em></p>
        ///   <p>Skip a step by name.</p>
        /// </summary>
        [Pure]
        public static T RemoveSkip<T>(this T toolSettings, IEnumerable<string> skip) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(skip);
            toolSettings.SkipInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoRawLog
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.NoRawLog"/></em></p>
        ///   <p>Don't print the raw log of failed tasks.</p>
        /// </summary>
        [Pure]
        public static T SetNoRawLog<T>(this T toolSettings, bool? noRawLog) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = noRawLog;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.NoRawLog"/></em></p>
        ///   <p>Don't print the raw log of failed tasks.</p>
        /// </summary>
        [Pure]
        public static T ResetNoRawLog<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.NoRawLog"/></em></p>
        ///   <p>Don't print the raw log of failed tasks.</p>
        /// </summary>
        [Pure]
        public static T EnableNoRawLog<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.NoRawLog"/></em></p>
        ///   <p>Don't print the raw log of failed tasks.</p>
        /// </summary>
        [Pure]
        public static T DisableNoRawLog<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.NoRawLog"/></em></p>
        ///   <p>Don't print the raw log of failed tasks.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoRawLog<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = !toolSettings.NoRawLog;
            return toolSettings;
        }
        #endregion
        #region RawLogFile
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.RawLogFile"/></em></p>
        ///   <p>Redirect the raw log of failed tasks to a file.</p>
        /// </summary>
        [Pure]
        public static T SetRawLogFile<T>(this T toolSettings, string rawLogFile) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawLogFile = rawLogFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.RawLogFile"/></em></p>
        ///   <p>Redirect the raw log of failed tasks to a file.</p>
        /// </summary>
        [Pure]
        public static T ResetRawLogFile<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawLogFile = null;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Variables"/> to a new dictionary</em></p>
        ///   <p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p>
        /// </summary>
        [Pure]
        public static T SetVariables<T>(this T toolSettings, IDictionary<string, string> variables) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal = variables.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctopusDeployReleaseSettings.Variables"/></em></p>
        ///   <p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p>
        /// </summary>
        [Pure]
        public static T ClearVariables<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="OctopusDeployReleaseSettings.Variables"/></em></p>
        ///   <p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p>
        /// </summary>
        [Pure]
        public static T AddVariable<T>(this T toolSettings, string variableKey, string variableValue) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Add(variableKey, variableValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="OctopusDeployReleaseSettings.Variables"/></em></p>
        ///   <p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p>
        /// </summary>
        [Pure]
        public static T RemoveVariable<T>(this T toolSettings, string variableKey) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Remove(variableKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="OctopusDeployReleaseSettings.Variables"/></em></p>
        ///   <p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p>
        /// </summary>
        [Pure]
        public static T SetVariable<T>(this T toolSettings, string variableKey, string variableValue) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal[variableKey] = variableValue;
            return toolSettings;
        }
        #endregion
        #region DeployAt
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.DeployAt"/></em></p>
        ///   <p>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</p>
        /// </summary>
        [Pure]
        public static T SetDeployAt<T>(this T toolSettings, string deployAt) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployAt = deployAt;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.DeployAt"/></em></p>
        ///   <p>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</p>
        /// </summary>
        [Pure]
        public static T ResetDeployAt<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployAt = null;
            return toolSettings;
        }
        #endregion
        #region Tenant
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Tenant"/></em></p>
        ///   <p>Create a deployment for this tenant; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to all tenants who are ready for this release (according to lifecycle).</p>
        /// </summary>
        [Pure]
        public static T SetTenant<T>(this T toolSettings, string tenant) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tenant = tenant;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Tenant"/></em></p>
        ///   <p>Create a deployment for this tenant; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to all tenants who are ready for this release (according to lifecycle).</p>
        /// </summary>
        [Pure]
        public static T ResetTenant<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tenant = null;
            return toolSettings;
        }
        #endregion
        #region TenantTag
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.TenantTag"/></em></p>
        ///   <p>Create a deployment for tenants matching this tag; specify this argument multiple times to build a query/filter with multiple tags, just like you can in the user interface.</p>
        /// </summary>
        [Pure]
        public static T SetTenantTag<T>(this T toolSettings, string tenantTag) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TenantTag = tenantTag;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.TenantTag"/></em></p>
        ///   <p>Create a deployment for tenants matching this tag; specify this argument multiple times to build a query/filter with multiple tags, just like you can in the user interface.</p>
        /// </summary>
        [Pure]
        public static T ResetTenantTag<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TenantTag = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Project"/></em></p>
        ///   <p>Name of the project.</p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Project"/></em></p>
        ///   <p>Name of the project.</p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region DeployTo
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.DeployTo"/></em></p>
        ///   <p>Environment to deploy to, e.g. <c>Production</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDeployTo<T>(this T toolSettings, string deployTo) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployTo = deployTo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.DeployTo"/></em></p>
        ///   <p>Environment to deploy to, e.g. <c>Production</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDeployTo<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployTo = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Version"/></em></p>
        ///   <p>Version number of the release to deploy. Or specify 'latest' for the latest release.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Version"/></em></p>
        ///   <p>Version number of the release to deploy. Or specify 'latest' for the latest release.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Channel
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Channel"/></em></p>
        ///   <p>Channel to use when getting the release to deploy</p>
        /// </summary>
        [Pure]
        public static T SetChannel<T>(this T toolSettings, string channel) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Channel = channel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Channel"/></em></p>
        ///   <p>Channel to use when getting the release to deploy</p>
        /// </summary>
        [Pure]
        public static T ResetChannel<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Channel = null;
            return toolSettings;
        }
        #endregion
        #region UpdateVariables
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></em></p>
        ///   <p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p>
        /// </summary>
        [Pure]
        public static T SetUpdateVariables<T>(this T toolSettings, bool? updateVariables) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateVariables = updateVariables;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></em></p>
        ///   <p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p>
        /// </summary>
        [Pure]
        public static T ResetUpdateVariables<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateVariables = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></em></p>
        ///   <p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p>
        /// </summary>
        [Pure]
        public static T EnableUpdateVariables<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateVariables = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></em></p>
        ///   <p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p>
        /// </summary>
        [Pure]
        public static T DisableUpdateVariables<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateVariables = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></em></p>
        ///   <p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p>
        /// </summary>
        [Pure]
        public static T ToggleUpdateVariables<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateVariables = !toolSettings.UpdateVariables;
            return toolSettings;
        }
        #endregion
        #region Server
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Server"/></em></p>
        ///   <p>The base URL for your Octopus server - e.g., http://your-octopus/</p>
        /// </summary>
        [Pure]
        public static T SetServer<T>(this T toolSettings, string server) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = server;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Server"/></em></p>
        ///   <p>The base URL for your Octopus server - e.g., http://your-octopus/</p>
        /// </summary>
        [Pure]
        public static T ResetServer<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.ApiKey"/></em></p>
        ///   <p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p>
        /// </summary>
        [Pure]
        public static T SetApiKey<T>(this T toolSettings, [Secret] string apiKey) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.ApiKey"/></em></p>
        ///   <p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p>
        /// </summary>
        [Pure]
        public static T ResetApiKey<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Username"/></em></p>
        ///   <p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Username"/></em></p>
        ///   <p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Password"/></em></p>
        ///   <p>Password to use when authenticating with the server.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Password"/></em></p>
        ///   <p>Password to use when authenticating with the server.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.ConfigFile"/></em></p>
        ///   <p>Text file of default values, with one 'key = value' per line.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.ConfigFile"/></em></p>
        ///   <p>Text file of default values, with one 'key = value' per line.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region IgnoreSslErrors
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreSslErrors<T>(this T toolSettings, bool? ignoreSslErrors) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = ignoreSslErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreSslErrors<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreSslErrors<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreSslErrors<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreSslErrors<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = !toolSettings.IgnoreSslErrors;
            return toolSettings;
        }
        #endregion
        #region EnableServiceMessages
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T SetEnableServiceMessages<T>(this T toolSettings, bool? enableServiceMessages) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = enableServiceMessages;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T ResetEnableServiceMessages<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T EnableEnableServiceMessages<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T DisableEnableServiceMessages<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T ToggleEnableServiceMessages<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = !toolSettings.EnableServiceMessages;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Timeout"/></em></p>
        ///   <p>Timeout in seconds for network operations. Default is 600.</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, int? timeout) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Timeout"/></em></p>
        ///   <p>Timeout in seconds for network operations. Default is 600.</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Proxy"/></em></p>
        ///   <p>The URI of the proxy to use, e.g., http://example.com:8080.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Proxy"/></em></p>
        ///   <p>The URI of the proxy to use, e.g., http://example.com:8080.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUsername
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.ProxyUsername"/></em></p>
        ///   <p>The username for the proxy.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUsername<T>(this T toolSettings, string proxyUsername) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = proxyUsername;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.ProxyUsername"/></em></p>
        ///   <p>The username for the proxy.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUsername<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.ProxyPassword"/></em></p>
        ///   <p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.ProxyPassword"/></em></p>
        ///   <p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region Space
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Space"/></em></p>
        ///   <p>The name of a space within which this command will be executed. The default space will be used if it is omitted.</p>
        /// </summary>
        [Pure]
        public static T SetSpace<T>(this T toolSettings, string space) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = space;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Space"/></em></p>
        ///   <p>The name of a space within which this command will be executed. The default space will be used if it is omitted.</p>
        /// </summary>
        [Pure]
        public static T ResetSpace<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = null;
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.LogLevel"/></em></p>
        ///   <p>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</p>
        /// </summary>
        [Pure]
        public static T SetLogLevel<T>(this T toolSettings, string logLevel) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.LogLevel"/></em></p>
        ///   <p>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</p>
        /// </summary>
        [Pure]
        public static T ResetLogLevel<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusDeployReleaseSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusDeployReleaseSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : OctopusDeployReleaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctopusBuildInformationSettingsExtensions
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctopusBuildInformationSettingsExtensions
    {
        #region PackageId
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.PackageId"/> to a new list</em></p>
        ///   <p>Id of the package.</p>
        /// </summary>
        [Pure]
        public static T SetPackageId<T>(this T toolSettings, params string[] packageId) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageIdInternal = packageId.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.PackageId"/> to a new list</em></p>
        ///   <p>Id of the package.</p>
        /// </summary>
        [Pure]
        public static T SetPackageId<T>(this T toolSettings, IEnumerable<string> packageId) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageIdInternal = packageId.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusBuildInformationSettings.PackageId"/></em></p>
        ///   <p>Id of the package.</p>
        /// </summary>
        [Pure]
        public static T AddPackageId<T>(this T toolSettings, params string[] packageId) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageIdInternal.AddRange(packageId);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctopusBuildInformationSettings.PackageId"/></em></p>
        ///   <p>Id of the package.</p>
        /// </summary>
        [Pure]
        public static T AddPackageId<T>(this T toolSettings, IEnumerable<string> packageId) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageIdInternal.AddRange(packageId);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctopusBuildInformationSettings.PackageId"/></em></p>
        ///   <p>Id of the package.</p>
        /// </summary>
        [Pure]
        public static T ClearPackageId<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageIdInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusBuildInformationSettings.PackageId"/></em></p>
        ///   <p>Id of the package.</p>
        /// </summary>
        [Pure]
        public static T RemovePackageId<T>(this T toolSettings, params string[] packageId) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(packageId);
            toolSettings.PackageIdInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctopusBuildInformationSettings.PackageId"/></em></p>
        ///   <p>Id of the package.</p>
        /// </summary>
        [Pure]
        public static T RemovePackageId<T>(this T toolSettings, IEnumerable<string> packageId) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(packageId);
            toolSettings.PackageIdInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.Version"/></em></p>
        ///   <p>Version number of the package.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.Version"/></em></p>
        ///   <p>Version number of the package.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region File
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.File"/></em></p>
        ///   <p>Octopus build information json file.</p>
        /// </summary>
        [Pure]
        public static T SetFile<T>(this T toolSettings, string file) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.File"/></em></p>
        ///   <p>Octopus build information json file.</p>
        /// </summary>
        [Pure]
        public static T ResetFile<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region OverwriteMode
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.OverwriteMode"/></em></p>
        ///   <p>Overwrite policy when the information already exists.</p>
        /// </summary>
        [Pure]
        public static T SetOverwriteMode<T>(this T toolSettings, OctopusOverwriteMode overwriteMode) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteMode = overwriteMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.OverwriteMode"/></em></p>
        ///   <p>Overwrite policy when the information already exists.</p>
        /// </summary>
        [Pure]
        public static T ResetOverwriteMode<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OverwriteMode = null;
            return toolSettings;
        }
        #endregion
        #region Server
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.Server"/></em></p>
        ///   <p>The base URL for your Octopus server - e.g., http://your-octopus/</p>
        /// </summary>
        [Pure]
        public static T SetServer<T>(this T toolSettings, string server) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = server;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.Server"/></em></p>
        ///   <p>The base URL for your Octopus server - e.g., http://your-octopus/</p>
        /// </summary>
        [Pure]
        public static T ResetServer<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.ApiKey"/></em></p>
        ///   <p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p>
        /// </summary>
        [Pure]
        public static T SetApiKey<T>(this T toolSettings, [Secret] string apiKey) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.ApiKey"/></em></p>
        ///   <p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p>
        /// </summary>
        [Pure]
        public static T ResetApiKey<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.Username"/></em></p>
        ///   <p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.Username"/></em></p>
        ///   <p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.Password"/></em></p>
        ///   <p>Password to use when authenticating with the server.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.Password"/></em></p>
        ///   <p>Password to use when authenticating with the server.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.ConfigFile"/></em></p>
        ///   <p>Text file of default values, with one 'key = value' per line.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.ConfigFile"/></em></p>
        ///   <p>Text file of default values, with one 'key = value' per line.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusBuildInformationSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusBuildInformationSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusBuildInformationSettings.Debug"/></em></p>
        ///   <p>Enable debug logging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region IgnoreSslErrors
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreSslErrors<T>(this T toolSettings, bool? ignoreSslErrors) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = ignoreSslErrors;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreSslErrors<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreSslErrors<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreSslErrors<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></em></p>
        ///   <p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreSslErrors<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = !toolSettings.IgnoreSslErrors;
            return toolSettings;
        }
        #endregion
        #region EnableServiceMessages
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T SetEnableServiceMessages<T>(this T toolSettings, bool? enableServiceMessages) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = enableServiceMessages;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T ResetEnableServiceMessages<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T EnableEnableServiceMessages<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T DisableEnableServiceMessages<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></em></p>
        ///   <p>Enable TeamCity or Team Foundation Build service messages when logging.</p>
        /// </summary>
        [Pure]
        public static T ToggleEnableServiceMessages<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = !toolSettings.EnableServiceMessages;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.Timeout"/></em></p>
        ///   <p>Timeout in seconds for network operations. Default is 600.</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, int? timeout) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.Timeout"/></em></p>
        ///   <p>Timeout in seconds for network operations. Default is 600.</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.Proxy"/></em></p>
        ///   <p>The URI of the proxy to use, e.g., http://example.com:8080.</p>
        /// </summary>
        [Pure]
        public static T SetProxy<T>(this T toolSettings, string proxy) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.Proxy"/></em></p>
        ///   <p>The URI of the proxy to use, e.g., http://example.com:8080.</p>
        /// </summary>
        [Pure]
        public static T ResetProxy<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUsername
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.ProxyUsername"/></em></p>
        ///   <p>The username for the proxy.</p>
        /// </summary>
        [Pure]
        public static T SetProxyUsername<T>(this T toolSettings, string proxyUsername) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = proxyUsername;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.ProxyUsername"/></em></p>
        ///   <p>The username for the proxy.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyUsername<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.ProxyPassword"/></em></p>
        ///   <p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p>
        /// </summary>
        [Pure]
        public static T SetProxyPassword<T>(this T toolSettings, [Secret] string proxyPassword) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.ProxyPassword"/></em></p>
        ///   <p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p>
        /// </summary>
        [Pure]
        public static T ResetProxyPassword<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
        #region Space
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.Space"/></em></p>
        ///   <p>The name of a space within which this command will be executed. The default space will be used if it is omitted.</p>
        /// </summary>
        [Pure]
        public static T SetSpace<T>(this T toolSettings, string space) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = space;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.Space"/></em></p>
        ///   <p>The name of a space within which this command will be executed. The default space will be used if it is omitted.</p>
        /// </summary>
        [Pure]
        public static T ResetSpace<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = null;
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.LogLevel"/></em></p>
        ///   <p>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</p>
        /// </summary>
        [Pure]
        public static T SetLogLevel<T>(this T toolSettings, string logLevel) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.LogLevel"/></em></p>
        ///   <p>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</p>
        /// </summary>
        [Pure]
        public static T ResetLogLevel<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="OctopusBuildInformationSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctopusBuildInformationSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : OctopusBuildInformationSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctopusPackFormat
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<OctopusPackFormat>))]
    public partial class OctopusPackFormat : Enumeration
    {
        public static OctopusPackFormat NuPkg = (OctopusPackFormat) "NuPkg";
        public static OctopusPackFormat Zip = (OctopusPackFormat) "Zip";
        public static implicit operator OctopusPackFormat(string value)
        {
            return new OctopusPackFormat { Value = value };
        }
    }
    #endregion
    #region OctopusOverwriteMode
    /// <summary>
    ///   Used within <see cref="OctopusTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<OctopusOverwriteMode>))]
    public partial class OctopusOverwriteMode : Enumeration
    {
        public static OctopusOverwriteMode FailIfExists = (OctopusOverwriteMode) "FailIfExists";
        public static OctopusOverwriteMode OverwriteExisting = (OctopusOverwriteMode) "OverwriteExisting";
        public static OctopusOverwriteMode IgnoreIfExists = (OctopusOverwriteMode) "IgnoreIfExists";
        public static implicit operator OctopusOverwriteMode(string value)
        {
            return new OctopusOverwriteMode { Value = value };
        }
    }
    #endregion
}
