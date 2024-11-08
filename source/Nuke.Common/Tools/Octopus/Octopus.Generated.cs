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

namespace Nuke.Common.Tools.Octopus;

/// <summary><p>Octopus Deploy is an automated deployment server, which you install yourself, much like you would install SQL Server, Team Foundation Server or JetBrains TeamCity. Octopus makes it easy to automate deployment of ASP.NET web applications and Windows Services into development, test and production environments.<para/>Along with the Octopus Deploy server, you'll also install a lightweight agent service on each of the machines that you plan to deploy to, for example your web and application servers. We call this the Tentacle agent; the idea being that one Octopus server controls many Tentacles, potentially a lot more than 8! With Octopus and Tentacle, you can easily deploy to your own servers, or cloud services from providers like Amazon Web Services or Microsoft Azure.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class OctopusTasks : ToolTasks, IRequireNuGetPackage
{
    public static string OctopusPath => new OctopusTasks().GetToolPath();
    public const string PackageId = "Octopus.DotNet.Cli";
    public const string PackageExecutable = "OctoVersion.Tool.dll";
    /// <summary><p>Octopus Deploy is an automated deployment server, which you install yourself, much like you would install SQL Server, Team Foundation Server or JetBrains TeamCity. Octopus makes it easy to automate deployment of ASP.NET web applications and Windows Services into development, test and production environments.<para/>Along with the Octopus Deploy server, you'll also install a lightweight agent service on each of the machines that you plan to deploy to, for example your web and application servers. We call this the Tentacle agent; the idea being that one Octopus server controls many Tentacles, potentially a lot more than 8! With Octopus and Tentacle, you can easily deploy to your own servers, or cloud services from providers like Amazon Web Services or Microsoft Azure.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Octopus(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new OctopusTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>The <c>Octo.exe pack</c> command provides a number of other useful parameters that can be used to customize the way your package gets created, such as output folder, files to include and release notes.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--author</c> via <see cref="OctopusPackSettings.Authors"/></li><li><c>--basePath</c> via <see cref="OctopusPackSettings.BasePath"/></li><li><c>--description</c> via <see cref="OctopusPackSettings.Description"/></li><li><c>--format</c> via <see cref="OctopusPackSettings.Format"/></li><li><c>--id</c> via <see cref="OctopusPackSettings.Id"/></li><li><c>--include</c> via <see cref="OctopusPackSettings.Include"/></li><li><c>--outFolder</c> via <see cref="OctopusPackSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="OctopusPackSettings.Overwrite"/></li><li><c>--releaseNotes</c> via <see cref="OctopusPackSettings.ReleaseNotes"/></li><li><c>--releaseNotesFile</c> via <see cref="OctopusPackSettings.ReleaseNotesFile"/></li><li><c>--title</c> via <see cref="OctopusPackSettings.Title"/></li><li><c>--verbose</c> via <see cref="OctopusPackSettings.Verbose"/></li><li><c>--version</c> via <see cref="OctopusPackSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctopusPack(OctopusPackSettings options = null) => new OctopusTasks().Run(options);
    /// <summary><p>The <c>Octo.exe pack</c> command provides a number of other useful parameters that can be used to customize the way your package gets created, such as output folder, files to include and release notes.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--author</c> via <see cref="OctopusPackSettings.Authors"/></li><li><c>--basePath</c> via <see cref="OctopusPackSettings.BasePath"/></li><li><c>--description</c> via <see cref="OctopusPackSettings.Description"/></li><li><c>--format</c> via <see cref="OctopusPackSettings.Format"/></li><li><c>--id</c> via <see cref="OctopusPackSettings.Id"/></li><li><c>--include</c> via <see cref="OctopusPackSettings.Include"/></li><li><c>--outFolder</c> via <see cref="OctopusPackSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="OctopusPackSettings.Overwrite"/></li><li><c>--releaseNotes</c> via <see cref="OctopusPackSettings.ReleaseNotes"/></li><li><c>--releaseNotesFile</c> via <see cref="OctopusPackSettings.ReleaseNotesFile"/></li><li><c>--title</c> via <see cref="OctopusPackSettings.Title"/></li><li><c>--verbose</c> via <see cref="OctopusPackSettings.Verbose"/></li><li><c>--version</c> via <see cref="OctopusPackSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctopusPack(Configure<OctopusPackSettings> configurator) => new OctopusTasks().Run(configurator.Invoke(new OctopusPackSettings()));
    /// <summary><p>The <c>Octo.exe pack</c> command provides a number of other useful parameters that can be used to customize the way your package gets created, such as output folder, files to include and release notes.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--author</c> via <see cref="OctopusPackSettings.Authors"/></li><li><c>--basePath</c> via <see cref="OctopusPackSettings.BasePath"/></li><li><c>--description</c> via <see cref="OctopusPackSettings.Description"/></li><li><c>--format</c> via <see cref="OctopusPackSettings.Format"/></li><li><c>--id</c> via <see cref="OctopusPackSettings.Id"/></li><li><c>--include</c> via <see cref="OctopusPackSettings.Include"/></li><li><c>--outFolder</c> via <see cref="OctopusPackSettings.OutputFolder"/></li><li><c>--overwrite</c> via <see cref="OctopusPackSettings.Overwrite"/></li><li><c>--releaseNotes</c> via <see cref="OctopusPackSettings.ReleaseNotes"/></li><li><c>--releaseNotesFile</c> via <see cref="OctopusPackSettings.ReleaseNotesFile"/></li><li><c>--title</c> via <see cref="OctopusPackSettings.Title"/></li><li><c>--verbose</c> via <see cref="OctopusPackSettings.Verbose"/></li><li><c>--version</c> via <see cref="OctopusPackSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(OctopusPackSettings Settings, IReadOnlyCollection<Output> Output)> OctopusPack(CombinatorialConfigure<OctopusPackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(OctopusPack, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The <c>Octo.exe push</c> command can push any of the supported packages types listed on this <a href="https://octopus.com/docs/packaging-applications/supported-packages">page</a>.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusPushSettings.ApiKey"/></li><li><c>--configFile</c> via <see cref="OctopusPushSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusPushSettings.Debug"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusPushSettings.EnableServiceMessages"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusPushSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusPushSettings.LogLevel"/></li><li><c>--package</c> via <see cref="OctopusPushSettings.Package"/></li><li><c>--pass</c> via <see cref="OctopusPushSettings.Password"/></li><li><c>--proxy</c> via <see cref="OctopusPushSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusPushSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusPushSettings.ProxyUsername"/></li><li><c>--replace-existing</c> via <see cref="OctopusPushSettings.ReplaceExisting"/></li><li><c>--server</c> via <see cref="OctopusPushSettings.Server"/></li><li><c>--space</c> via <see cref="OctopusPushSettings.Space"/></li><li><c>--timeout</c> via <see cref="OctopusPushSettings.Timeout"/></li><li><c>--user</c> via <see cref="OctopusPushSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctopusPush(OctopusPushSettings options = null) => new OctopusTasks().Run(options);
    /// <summary><p>The <c>Octo.exe push</c> command can push any of the supported packages types listed on this <a href="https://octopus.com/docs/packaging-applications/supported-packages">page</a>.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusPushSettings.ApiKey"/></li><li><c>--configFile</c> via <see cref="OctopusPushSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusPushSettings.Debug"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusPushSettings.EnableServiceMessages"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusPushSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusPushSettings.LogLevel"/></li><li><c>--package</c> via <see cref="OctopusPushSettings.Package"/></li><li><c>--pass</c> via <see cref="OctopusPushSettings.Password"/></li><li><c>--proxy</c> via <see cref="OctopusPushSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusPushSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusPushSettings.ProxyUsername"/></li><li><c>--replace-existing</c> via <see cref="OctopusPushSettings.ReplaceExisting"/></li><li><c>--server</c> via <see cref="OctopusPushSettings.Server"/></li><li><c>--space</c> via <see cref="OctopusPushSettings.Space"/></li><li><c>--timeout</c> via <see cref="OctopusPushSettings.Timeout"/></li><li><c>--user</c> via <see cref="OctopusPushSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctopusPush(Configure<OctopusPushSettings> configurator) => new OctopusTasks().Run(configurator.Invoke(new OctopusPushSettings()));
    /// <summary><p>The <c>Octo.exe push</c> command can push any of the supported packages types listed on this <a href="https://octopus.com/docs/packaging-applications/supported-packages">page</a>.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusPushSettings.ApiKey"/></li><li><c>--configFile</c> via <see cref="OctopusPushSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusPushSettings.Debug"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusPushSettings.EnableServiceMessages"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusPushSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusPushSettings.LogLevel"/></li><li><c>--package</c> via <see cref="OctopusPushSettings.Package"/></li><li><c>--pass</c> via <see cref="OctopusPushSettings.Password"/></li><li><c>--proxy</c> via <see cref="OctopusPushSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusPushSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusPushSettings.ProxyUsername"/></li><li><c>--replace-existing</c> via <see cref="OctopusPushSettings.ReplaceExisting"/></li><li><c>--server</c> via <see cref="OctopusPushSettings.Server"/></li><li><c>--space</c> via <see cref="OctopusPushSettings.Space"/></li><li><c>--timeout</c> via <see cref="OctopusPushSettings.Timeout"/></li><li><c>--user</c> via <see cref="OctopusPushSettings.Username"/></li></ul></remarks>
    public static IEnumerable<(OctopusPushSettings Settings, IReadOnlyCollection<Output> Output)> OctopusPush(CombinatorialConfigure<OctopusPushSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(OctopusPush, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The <c>Octo.exe create-release</c> can be used to automate the creation of releases. This allows you to easily integrate Octopus with other continuous integration servers.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusCreateReleaseSettings.ApiKey"/></li><li><c>--cancelontimeout</c> via <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></li><li><c>--channel</c> via <see cref="OctopusCreateReleaseSettings.Channel"/></li><li><c>--configFile</c> via <see cref="OctopusCreateReleaseSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusCreateReleaseSettings.Debug"/></li><li><c>--deployat</c> via <see cref="OctopusCreateReleaseSettings.DeployAt"/></li><li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/></li><li><c>--deploymenttimeout</c> via <see cref="OctopusCreateReleaseSettings.DeploymentTimeout"/></li><li><c>--deployto</c> via <see cref="OctopusCreateReleaseSettings.DeployTo"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></li><li><c>--force</c> via <see cref="OctopusCreateReleaseSettings.Force"/></li><li><c>--forcepackagedownload</c> via <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></li><li><c>--gitCommit</c> via <see cref="OctopusCreateReleaseSettings.GitCommit"/></li><li><c>--gitRef</c> via <see cref="OctopusCreateReleaseSettings.GitRef"/></li><li><c>--guidedfailure</c> via <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></li><li><c>--ignorechannelrules</c> via <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></li><li><c>--ignoreexisting</c> via <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusCreateReleaseSettings.LogLevel"/></li><li><c>--norawlog</c> via <see cref="OctopusCreateReleaseSettings.NoRawLog"/></li><li><c>--package</c> via <see cref="OctopusCreateReleaseSettings.PackageVersions"/></li><li><c>--packageprerelease</c> via <see cref="OctopusCreateReleaseSettings.PackagePrerelease"/></li><li><c>--packagesFolder</c> via <see cref="OctopusCreateReleaseSettings.PackagesFolder"/></li><li><c>--packageversion</c> via <see cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/></li><li><c>--pass</c> via <see cref="OctopusCreateReleaseSettings.Password"/></li><li><c>--progress</c> via <see cref="OctopusCreateReleaseSettings.Progress"/></li><li><c>--project</c> via <see cref="OctopusCreateReleaseSettings.Project"/></li><li><c>--proxy</c> via <see cref="OctopusCreateReleaseSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusCreateReleaseSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusCreateReleaseSettings.ProxyUsername"/></li><li><c>--rawlogfile</c> via <see cref="OctopusCreateReleaseSettings.RawLogFile"/></li><li><c>--releasenotes</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotes"/></li><li><c>--releasenotesfile</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/></li><li><c>--server</c> via <see cref="OctopusCreateReleaseSettings.Server"/></li><li><c>--skip</c> via <see cref="OctopusCreateReleaseSettings.Skip"/></li><li><c>--space</c> via <see cref="OctopusCreateReleaseSettings.Space"/></li><li><c>--specificmachines</c> via <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></li><li><c>--tenant</c> via <see cref="OctopusCreateReleaseSettings.Tenant"/></li><li><c>--tenanttag</c> via <see cref="OctopusCreateReleaseSettings.TenantTag"/></li><li><c>--timeout</c> via <see cref="OctopusCreateReleaseSettings.Timeout"/></li><li><c>--user</c> via <see cref="OctopusCreateReleaseSettings.Username"/></li><li><c>--variable</c> via <see cref="OctopusCreateReleaseSettings.Variables"/></li><li><c>--version</c> via <see cref="OctopusCreateReleaseSettings.Version"/></li><li><c>--waitfordeployment</c> via <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></li><li><c>--whatif</c> via <see cref="OctopusCreateReleaseSettings.WhatIf"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctopusCreateRelease(OctopusCreateReleaseSettings options = null) => new OctopusTasks().Run(options);
    /// <summary><p>The <c>Octo.exe create-release</c> can be used to automate the creation of releases. This allows you to easily integrate Octopus with other continuous integration servers.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusCreateReleaseSettings.ApiKey"/></li><li><c>--cancelontimeout</c> via <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></li><li><c>--channel</c> via <see cref="OctopusCreateReleaseSettings.Channel"/></li><li><c>--configFile</c> via <see cref="OctopusCreateReleaseSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusCreateReleaseSettings.Debug"/></li><li><c>--deployat</c> via <see cref="OctopusCreateReleaseSettings.DeployAt"/></li><li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/></li><li><c>--deploymenttimeout</c> via <see cref="OctopusCreateReleaseSettings.DeploymentTimeout"/></li><li><c>--deployto</c> via <see cref="OctopusCreateReleaseSettings.DeployTo"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></li><li><c>--force</c> via <see cref="OctopusCreateReleaseSettings.Force"/></li><li><c>--forcepackagedownload</c> via <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></li><li><c>--gitCommit</c> via <see cref="OctopusCreateReleaseSettings.GitCommit"/></li><li><c>--gitRef</c> via <see cref="OctopusCreateReleaseSettings.GitRef"/></li><li><c>--guidedfailure</c> via <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></li><li><c>--ignorechannelrules</c> via <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></li><li><c>--ignoreexisting</c> via <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusCreateReleaseSettings.LogLevel"/></li><li><c>--norawlog</c> via <see cref="OctopusCreateReleaseSettings.NoRawLog"/></li><li><c>--package</c> via <see cref="OctopusCreateReleaseSettings.PackageVersions"/></li><li><c>--packageprerelease</c> via <see cref="OctopusCreateReleaseSettings.PackagePrerelease"/></li><li><c>--packagesFolder</c> via <see cref="OctopusCreateReleaseSettings.PackagesFolder"/></li><li><c>--packageversion</c> via <see cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/></li><li><c>--pass</c> via <see cref="OctopusCreateReleaseSettings.Password"/></li><li><c>--progress</c> via <see cref="OctopusCreateReleaseSettings.Progress"/></li><li><c>--project</c> via <see cref="OctopusCreateReleaseSettings.Project"/></li><li><c>--proxy</c> via <see cref="OctopusCreateReleaseSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusCreateReleaseSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusCreateReleaseSettings.ProxyUsername"/></li><li><c>--rawlogfile</c> via <see cref="OctopusCreateReleaseSettings.RawLogFile"/></li><li><c>--releasenotes</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotes"/></li><li><c>--releasenotesfile</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/></li><li><c>--server</c> via <see cref="OctopusCreateReleaseSettings.Server"/></li><li><c>--skip</c> via <see cref="OctopusCreateReleaseSettings.Skip"/></li><li><c>--space</c> via <see cref="OctopusCreateReleaseSettings.Space"/></li><li><c>--specificmachines</c> via <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></li><li><c>--tenant</c> via <see cref="OctopusCreateReleaseSettings.Tenant"/></li><li><c>--tenanttag</c> via <see cref="OctopusCreateReleaseSettings.TenantTag"/></li><li><c>--timeout</c> via <see cref="OctopusCreateReleaseSettings.Timeout"/></li><li><c>--user</c> via <see cref="OctopusCreateReleaseSettings.Username"/></li><li><c>--variable</c> via <see cref="OctopusCreateReleaseSettings.Variables"/></li><li><c>--version</c> via <see cref="OctopusCreateReleaseSettings.Version"/></li><li><c>--waitfordeployment</c> via <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></li><li><c>--whatif</c> via <see cref="OctopusCreateReleaseSettings.WhatIf"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctopusCreateRelease(Configure<OctopusCreateReleaseSettings> configurator) => new OctopusTasks().Run(configurator.Invoke(new OctopusCreateReleaseSettings()));
    /// <summary><p>The <c>Octo.exe create-release</c> can be used to automate the creation of releases. This allows you to easily integrate Octopus with other continuous integration servers.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusCreateReleaseSettings.ApiKey"/></li><li><c>--cancelontimeout</c> via <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/></li><li><c>--channel</c> via <see cref="OctopusCreateReleaseSettings.Channel"/></li><li><c>--configFile</c> via <see cref="OctopusCreateReleaseSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusCreateReleaseSettings.Debug"/></li><li><c>--deployat</c> via <see cref="OctopusCreateReleaseSettings.DeployAt"/></li><li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/></li><li><c>--deploymenttimeout</c> via <see cref="OctopusCreateReleaseSettings.DeploymentTimeout"/></li><li><c>--deployto</c> via <see cref="OctopusCreateReleaseSettings.DeployTo"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/></li><li><c>--force</c> via <see cref="OctopusCreateReleaseSettings.Force"/></li><li><c>--forcepackagedownload</c> via <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/></li><li><c>--gitCommit</c> via <see cref="OctopusCreateReleaseSettings.GitCommit"/></li><li><c>--gitRef</c> via <see cref="OctopusCreateReleaseSettings.GitRef"/></li><li><c>--guidedfailure</c> via <see cref="OctopusCreateReleaseSettings.GuidedFailure"/></li><li><c>--ignorechannelrules</c> via <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/></li><li><c>--ignoreexisting</c> via <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusCreateReleaseSettings.LogLevel"/></li><li><c>--norawlog</c> via <see cref="OctopusCreateReleaseSettings.NoRawLog"/></li><li><c>--package</c> via <see cref="OctopusCreateReleaseSettings.PackageVersions"/></li><li><c>--packageprerelease</c> via <see cref="OctopusCreateReleaseSettings.PackagePrerelease"/></li><li><c>--packagesFolder</c> via <see cref="OctopusCreateReleaseSettings.PackagesFolder"/></li><li><c>--packageversion</c> via <see cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/></li><li><c>--pass</c> via <see cref="OctopusCreateReleaseSettings.Password"/></li><li><c>--progress</c> via <see cref="OctopusCreateReleaseSettings.Progress"/></li><li><c>--project</c> via <see cref="OctopusCreateReleaseSettings.Project"/></li><li><c>--proxy</c> via <see cref="OctopusCreateReleaseSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusCreateReleaseSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusCreateReleaseSettings.ProxyUsername"/></li><li><c>--rawlogfile</c> via <see cref="OctopusCreateReleaseSettings.RawLogFile"/></li><li><c>--releasenotes</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotes"/></li><li><c>--releasenotesfile</c> via <see cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/></li><li><c>--server</c> via <see cref="OctopusCreateReleaseSettings.Server"/></li><li><c>--skip</c> via <see cref="OctopusCreateReleaseSettings.Skip"/></li><li><c>--space</c> via <see cref="OctopusCreateReleaseSettings.Space"/></li><li><c>--specificmachines</c> via <see cref="OctopusCreateReleaseSettings.SpecificMachines"/></li><li><c>--tenant</c> via <see cref="OctopusCreateReleaseSettings.Tenant"/></li><li><c>--tenanttag</c> via <see cref="OctopusCreateReleaseSettings.TenantTag"/></li><li><c>--timeout</c> via <see cref="OctopusCreateReleaseSettings.Timeout"/></li><li><c>--user</c> via <see cref="OctopusCreateReleaseSettings.Username"/></li><li><c>--variable</c> via <see cref="OctopusCreateReleaseSettings.Variables"/></li><li><c>--version</c> via <see cref="OctopusCreateReleaseSettings.Version"/></li><li><c>--waitfordeployment</c> via <see cref="OctopusCreateReleaseSettings.WaitForDeployment"/></li><li><c>--whatif</c> via <see cref="OctopusCreateReleaseSettings.WhatIf"/></li></ul></remarks>
    public static IEnumerable<(OctopusCreateReleaseSettings Settings, IReadOnlyCollection<Output> Output)> OctopusCreateRelease(CombinatorialConfigure<OctopusCreateReleaseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(OctopusCreateRelease, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The <c>Octo.exe deploy-release</c> can be used to automate the deployment of releases to environments. This allows you to easily integrate Octopus with other continuous integration servers.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusDeployReleaseSettings.ApiKey"/></li><li><c>--cancelontimeout</c> via <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></li><li><c>--channel</c> via <see cref="OctopusDeployReleaseSettings.Channel"/></li><li><c>--configFile</c> via <see cref="OctopusDeployReleaseSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusDeployReleaseSettings.Debug"/></li><li><c>--deployat</c> via <see cref="OctopusDeployReleaseSettings.DeployAt"/></li><li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/></li><li><c>--deploymenttimeout</c> via <see cref="OctopusDeployReleaseSettings.DeploymentTimeout"/></li><li><c>--deployto</c> via <see cref="OctopusDeployReleaseSettings.DeployTo"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></li><li><c>--force</c> via <see cref="OctopusDeployReleaseSettings.Force"/></li><li><c>--forcepackagedownload</c> via <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></li><li><c>--guidedfailure</c> via <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusDeployReleaseSettings.LogLevel"/></li><li><c>--norawlog</c> via <see cref="OctopusDeployReleaseSettings.NoRawLog"/></li><li><c>--pass</c> via <see cref="OctopusDeployReleaseSettings.Password"/></li><li><c>--progress</c> via <see cref="OctopusDeployReleaseSettings.Progress"/></li><li><c>--project</c> via <see cref="OctopusDeployReleaseSettings.Project"/></li><li><c>--proxy</c> via <see cref="OctopusDeployReleaseSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusDeployReleaseSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusDeployReleaseSettings.ProxyUsername"/></li><li><c>--rawlogfile</c> via <see cref="OctopusDeployReleaseSettings.RawLogFile"/></li><li><c>--server</c> via <see cref="OctopusDeployReleaseSettings.Server"/></li><li><c>--skip</c> via <see cref="OctopusDeployReleaseSettings.Skip"/></li><li><c>--space</c> via <see cref="OctopusDeployReleaseSettings.Space"/></li><li><c>--specificmachines</c> via <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></li><li><c>--tenant</c> via <see cref="OctopusDeployReleaseSettings.Tenant"/></li><li><c>--tenanttag</c> via <see cref="OctopusDeployReleaseSettings.TenantTag"/></li><li><c>--timeout</c> via <see cref="OctopusDeployReleaseSettings.Timeout"/></li><li><c>--updateVariables</c> via <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></li><li><c>--user</c> via <see cref="OctopusDeployReleaseSettings.Username"/></li><li><c>--variable</c> via <see cref="OctopusDeployReleaseSettings.Variables"/></li><li><c>--version</c> via <see cref="OctopusDeployReleaseSettings.Version"/></li><li><c>--waitfordeployment</c> via <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctopusDeployRelease(OctopusDeployReleaseSettings options = null) => new OctopusTasks().Run(options);
    /// <summary><p>The <c>Octo.exe deploy-release</c> can be used to automate the deployment of releases to environments. This allows you to easily integrate Octopus with other continuous integration servers.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusDeployReleaseSettings.ApiKey"/></li><li><c>--cancelontimeout</c> via <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></li><li><c>--channel</c> via <see cref="OctopusDeployReleaseSettings.Channel"/></li><li><c>--configFile</c> via <see cref="OctopusDeployReleaseSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusDeployReleaseSettings.Debug"/></li><li><c>--deployat</c> via <see cref="OctopusDeployReleaseSettings.DeployAt"/></li><li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/></li><li><c>--deploymenttimeout</c> via <see cref="OctopusDeployReleaseSettings.DeploymentTimeout"/></li><li><c>--deployto</c> via <see cref="OctopusDeployReleaseSettings.DeployTo"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></li><li><c>--force</c> via <see cref="OctopusDeployReleaseSettings.Force"/></li><li><c>--forcepackagedownload</c> via <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></li><li><c>--guidedfailure</c> via <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusDeployReleaseSettings.LogLevel"/></li><li><c>--norawlog</c> via <see cref="OctopusDeployReleaseSettings.NoRawLog"/></li><li><c>--pass</c> via <see cref="OctopusDeployReleaseSettings.Password"/></li><li><c>--progress</c> via <see cref="OctopusDeployReleaseSettings.Progress"/></li><li><c>--project</c> via <see cref="OctopusDeployReleaseSettings.Project"/></li><li><c>--proxy</c> via <see cref="OctopusDeployReleaseSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusDeployReleaseSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusDeployReleaseSettings.ProxyUsername"/></li><li><c>--rawlogfile</c> via <see cref="OctopusDeployReleaseSettings.RawLogFile"/></li><li><c>--server</c> via <see cref="OctopusDeployReleaseSettings.Server"/></li><li><c>--skip</c> via <see cref="OctopusDeployReleaseSettings.Skip"/></li><li><c>--space</c> via <see cref="OctopusDeployReleaseSettings.Space"/></li><li><c>--specificmachines</c> via <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></li><li><c>--tenant</c> via <see cref="OctopusDeployReleaseSettings.Tenant"/></li><li><c>--tenanttag</c> via <see cref="OctopusDeployReleaseSettings.TenantTag"/></li><li><c>--timeout</c> via <see cref="OctopusDeployReleaseSettings.Timeout"/></li><li><c>--updateVariables</c> via <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></li><li><c>--user</c> via <see cref="OctopusDeployReleaseSettings.Username"/></li><li><c>--variable</c> via <see cref="OctopusDeployReleaseSettings.Variables"/></li><li><c>--version</c> via <see cref="OctopusDeployReleaseSettings.Version"/></li><li><c>--waitfordeployment</c> via <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctopusDeployRelease(Configure<OctopusDeployReleaseSettings> configurator) => new OctopusTasks().Run(configurator.Invoke(new OctopusDeployReleaseSettings()));
    /// <summary><p>The <c>Octo.exe deploy-release</c> can be used to automate the deployment of releases to environments. This allows you to easily integrate Octopus with other continuous integration servers.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusDeployReleaseSettings.ApiKey"/></li><li><c>--cancelontimeout</c> via <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/></li><li><c>--channel</c> via <see cref="OctopusDeployReleaseSettings.Channel"/></li><li><c>--configFile</c> via <see cref="OctopusDeployReleaseSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusDeployReleaseSettings.Debug"/></li><li><c>--deployat</c> via <see cref="OctopusDeployReleaseSettings.DeployAt"/></li><li><c>--deploymentchecksleepcycle</c> via <see cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/></li><li><c>--deploymenttimeout</c> via <see cref="OctopusDeployReleaseSettings.DeploymentTimeout"/></li><li><c>--deployto</c> via <see cref="OctopusDeployReleaseSettings.DeployTo"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/></li><li><c>--force</c> via <see cref="OctopusDeployReleaseSettings.Force"/></li><li><c>--forcepackagedownload</c> via <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/></li><li><c>--guidedfailure</c> via <see cref="OctopusDeployReleaseSettings.GuidedFailure"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusDeployReleaseSettings.LogLevel"/></li><li><c>--norawlog</c> via <see cref="OctopusDeployReleaseSettings.NoRawLog"/></li><li><c>--pass</c> via <see cref="OctopusDeployReleaseSettings.Password"/></li><li><c>--progress</c> via <see cref="OctopusDeployReleaseSettings.Progress"/></li><li><c>--project</c> via <see cref="OctopusDeployReleaseSettings.Project"/></li><li><c>--proxy</c> via <see cref="OctopusDeployReleaseSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusDeployReleaseSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusDeployReleaseSettings.ProxyUsername"/></li><li><c>--rawlogfile</c> via <see cref="OctopusDeployReleaseSettings.RawLogFile"/></li><li><c>--server</c> via <see cref="OctopusDeployReleaseSettings.Server"/></li><li><c>--skip</c> via <see cref="OctopusDeployReleaseSettings.Skip"/></li><li><c>--space</c> via <see cref="OctopusDeployReleaseSettings.Space"/></li><li><c>--specificmachines</c> via <see cref="OctopusDeployReleaseSettings.SpecificMachines"/></li><li><c>--tenant</c> via <see cref="OctopusDeployReleaseSettings.Tenant"/></li><li><c>--tenanttag</c> via <see cref="OctopusDeployReleaseSettings.TenantTag"/></li><li><c>--timeout</c> via <see cref="OctopusDeployReleaseSettings.Timeout"/></li><li><c>--updateVariables</c> via <see cref="OctopusDeployReleaseSettings.UpdateVariables"/></li><li><c>--user</c> via <see cref="OctopusDeployReleaseSettings.Username"/></li><li><c>--variable</c> via <see cref="OctopusDeployReleaseSettings.Variables"/></li><li><c>--version</c> via <see cref="OctopusDeployReleaseSettings.Version"/></li><li><c>--waitfordeployment</c> via <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/></li></ul></remarks>
    public static IEnumerable<(OctopusDeployReleaseSettings Settings, IReadOnlyCollection<Output> Output)> OctopusDeployRelease(CombinatorialConfigure<OctopusDeployReleaseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(OctopusDeployRelease, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The <c>Octo.exe build-information</c> command push build information to Octopus Server.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusBuildInformationSettings.ApiKey"/></li><li><c>--configFile</c> via <see cref="OctopusBuildInformationSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusBuildInformationSettings.Debug"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></li><li><c>--file</c> via <see cref="OctopusBuildInformationSettings.File"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusBuildInformationSettings.LogLevel"/></li><li><c>--overwrite-mode</c> via <see cref="OctopusBuildInformationSettings.OverwriteMode"/></li><li><c>--package-id</c> via <see cref="OctopusBuildInformationSettings.PackageId"/></li><li><c>--pass</c> via <see cref="OctopusBuildInformationSettings.Password"/></li><li><c>--proxy</c> via <see cref="OctopusBuildInformationSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusBuildInformationSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusBuildInformationSettings.ProxyUsername"/></li><li><c>--server</c> via <see cref="OctopusBuildInformationSettings.Server"/></li><li><c>--space</c> via <see cref="OctopusBuildInformationSettings.Space"/></li><li><c>--timeout</c> via <see cref="OctopusBuildInformationSettings.Timeout"/></li><li><c>--user</c> via <see cref="OctopusBuildInformationSettings.Username"/></li><li><c>--version</c> via <see cref="OctopusBuildInformationSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctopusBuildInformation(OctopusBuildInformationSettings options = null) => new OctopusTasks().Run(options);
    /// <summary><p>The <c>Octo.exe build-information</c> command push build information to Octopus Server.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusBuildInformationSettings.ApiKey"/></li><li><c>--configFile</c> via <see cref="OctopusBuildInformationSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusBuildInformationSettings.Debug"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></li><li><c>--file</c> via <see cref="OctopusBuildInformationSettings.File"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusBuildInformationSettings.LogLevel"/></li><li><c>--overwrite-mode</c> via <see cref="OctopusBuildInformationSettings.OverwriteMode"/></li><li><c>--package-id</c> via <see cref="OctopusBuildInformationSettings.PackageId"/></li><li><c>--pass</c> via <see cref="OctopusBuildInformationSettings.Password"/></li><li><c>--proxy</c> via <see cref="OctopusBuildInformationSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusBuildInformationSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusBuildInformationSettings.ProxyUsername"/></li><li><c>--server</c> via <see cref="OctopusBuildInformationSettings.Server"/></li><li><c>--space</c> via <see cref="OctopusBuildInformationSettings.Space"/></li><li><c>--timeout</c> via <see cref="OctopusBuildInformationSettings.Timeout"/></li><li><c>--user</c> via <see cref="OctopusBuildInformationSettings.Username"/></li><li><c>--version</c> via <see cref="OctopusBuildInformationSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctopusBuildInformation(Configure<OctopusBuildInformationSettings> configurator) => new OctopusTasks().Run(configurator.Invoke(new OctopusBuildInformationSettings()));
    /// <summary><p>The <c>Octo.exe build-information</c> command push build information to Octopus Server.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--apiKey</c> via <see cref="OctopusBuildInformationSettings.ApiKey"/></li><li><c>--configFile</c> via <see cref="OctopusBuildInformationSettings.ConfigFile"/></li><li><c>--debug</c> via <see cref="OctopusBuildInformationSettings.Debug"/></li><li><c>--enableServiceMessages</c> via <see cref="OctopusBuildInformationSettings.EnableServiceMessages"/></li><li><c>--file</c> via <see cref="OctopusBuildInformationSettings.File"/></li><li><c>--ignoreSslErrors</c> via <see cref="OctopusBuildInformationSettings.IgnoreSslErrors"/></li><li><c>--logLevel</c> via <see cref="OctopusBuildInformationSettings.LogLevel"/></li><li><c>--overwrite-mode</c> via <see cref="OctopusBuildInformationSettings.OverwriteMode"/></li><li><c>--package-id</c> via <see cref="OctopusBuildInformationSettings.PackageId"/></li><li><c>--pass</c> via <see cref="OctopusBuildInformationSettings.Password"/></li><li><c>--proxy</c> via <see cref="OctopusBuildInformationSettings.Proxy"/></li><li><c>--proxyPass</c> via <see cref="OctopusBuildInformationSettings.ProxyPassword"/></li><li><c>--proxyUser</c> via <see cref="OctopusBuildInformationSettings.ProxyUsername"/></li><li><c>--server</c> via <see cref="OctopusBuildInformationSettings.Server"/></li><li><c>--space</c> via <see cref="OctopusBuildInformationSettings.Space"/></li><li><c>--timeout</c> via <see cref="OctopusBuildInformationSettings.Timeout"/></li><li><c>--user</c> via <see cref="OctopusBuildInformationSettings.Username"/></li><li><c>--version</c> via <see cref="OctopusBuildInformationSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(OctopusBuildInformationSettings Settings, IReadOnlyCollection<Output> Output)> OctopusBuildInformation(CombinatorialConfigure<OctopusBuildInformationSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(OctopusBuildInformation, degreeOfParallelism, completeOnFailure);
}
#region OctopusPackSettings
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OctopusPackSettings>))]
[Command(Type = typeof(OctopusTasks), Command = nameof(OctopusTasks.OctopusPack), Arguments = "pack")]
public partial class OctopusPackSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>The ID of the package. E.g. <c>MyCompany.MyApp</c>.</summary>
    [Argument(Format = "--id={value}")] public string Id => Get<string>(() => Id);
    /// <summary>Package format. Options are: NuPkg, Zip. Defaults to NuPkg, though we recommend Zip going forward.</summary>
    [Argument(Format = "--format={value}")] public OctopusPackFormat Format => Get<OctopusPackFormat>(() => Format);
    /// <summary>The version of the package; must be a valid SemVer. Defaults to a timestamp-based version.</summary>
    [Argument(Format = "--version={value}")] public string Version => Get<string>(() => Version);
    /// <summary>The folder into which the generated NUPKG file will be written. Defaults to <c>.</c>.</summary>
    [Argument(Format = "--outFolder={value}")] public string OutputFolder => Get<string>(() => OutputFolder);
    /// <summary>The root folder containing files and folders to pack. Defaults to <c>.</c>.</summary>
    [Argument(Format = "--basePath={value}")] public string BasePath => Get<string>(() => BasePath);
    /// <summary>List more detailed output. E.g. Which files are being added.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary>Add an author to the package metadata. Defaults to the current user.</summary>
    [Argument(Format = "--author={value}")] public IReadOnlyList<string> Authors => Get<List<string>>(() => Authors);
    /// <summary>The title of the package.</summary>
    [Argument(Format = "--title={value}")] public string Title => Get<string>(() => Title);
    /// <summary>A description of the package. Defaults to a generic description.</summary>
    [Argument(Format = "--description={value}")] public string Description => Get<string>(() => Description);
    /// <summary>Release notes for this version of the package.</summary>
    [Argument(Format = "--releaseNotes={value}")] public string ReleaseNotes => Get<string>(() => ReleaseNotes);
    /// <summary>A file containing release notes for this version of the package.</summary>
    [Argument(Format = "--releaseNotesFile={value}")] public string ReleaseNotesFile => Get<string>(() => ReleaseNotesFile);
    /// <summary>Add a file pattern to include, relative to the base path. E.g. <c>/bin/-*.dll</c> - if none are specified, defaults to <c>**</c>.</summary>
    [Argument(Format = "--include={value}")] public IReadOnlyList<string> Include => Get<List<string>>(() => Include);
    /// <summary>Allow an existing package file of the same ID/version to be overwritten.</summary>
    [Argument(Format = "--overwrite")] public bool? Overwrite => Get<bool?>(() => Overwrite);
    /// <summary></summary>
    public string Framework => Get<string>(() => Framework);
}
#endregion
#region OctopusPushSettings
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OctopusPushSettings>))]
[Command(Type = typeof(OctopusTasks), Command = nameof(OctopusTasks.OctopusPush), Arguments = "push")]
public partial class OctopusPushSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>Package file to push.</summary>
    [Argument(Format = "--package={value}")] public IReadOnlyList<string> Package => Get<List<string>>(() => Package);
    /// <summary>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</summary>
    [Argument(Format = "--replace-existing")] public bool? ReplaceExisting => Get<bool?>(() => ReplaceExisting);
    /// <summary>The base URL for your Octopus server - e.g., http://your-octopus/</summary>
    [Argument(Format = "--server={value}")] public string Server => Get<string>(() => Server);
    /// <summary>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</summary>
    [Argument(Format = "--apiKey={value}", Secret = true)] public string ApiKey => Get<string>(() => ApiKey);
    /// <summary>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</summary>
    [Argument(Format = "--user={value}")] public string Username => Get<string>(() => Username);
    /// <summary>Password to use when authenticating with the server.</summary>
    [Argument(Format = "--pass={value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Text file of default values, with one 'key = value' per line.</summary>
    [Argument(Format = "--configFile={value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Enable debug logging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</summary>
    [Argument(Format = "--ignoreSslErrors")] public bool? IgnoreSslErrors => Get<bool?>(() => IgnoreSslErrors);
    /// <summary>Enable TeamCity or Team Foundation Build service messages when logging.</summary>
    [Argument(Format = "--enableServiceMessages")] public bool? EnableServiceMessages => Get<bool?>(() => EnableServiceMessages);
    /// <summary>Timeout in seconds for network operations. Default is 600.</summary>
    [Argument(Format = "--timeout={value}")] public int? Timeout => Get<int?>(() => Timeout);
    /// <summary>The URI of the proxy to use, e.g., http://example.com:8080.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>The username for the proxy.</summary>
    [Argument(Format = "--proxyUser={value}")] public string ProxyUsername => Get<string>(() => ProxyUsername);
    /// <summary>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</summary>
    [Argument(Format = "--proxyPass={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>The name of a space within which this command will be executed. The default space will be used if it is omitted.</summary>
    [Argument(Format = "--space={value}")] public string Space => Get<string>(() => Space);
    /// <summary>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</summary>
    [Argument(Format = "--logLevel={value}")] public string LogLevel => Get<string>(() => LogLevel);
}
#endregion
#region OctopusCreateReleaseSettings
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OctopusCreateReleaseSettings>))]
[Command(Type = typeof(OctopusTasks), Command = nameof(OctopusTasks.OctopusCreateRelease), Arguments = "create-release")]
public partial class OctopusCreateReleaseSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>Name of the project.</summary>
    [Argument(Format = "--project={value}")] public string Project => Get<string>(() => Project);
    /// <summary>Default version number of all packages to use for this release.</summary>
    [Argument(Format = "--packageversion={value}")] public string DefaultPackageVersion => Get<string>(() => DefaultPackageVersion);
    /// <summary>Git commit to use when creating the release. Use in conjunction with the --gitRef parameter to select any previous commit.</summary>
    [Argument(Format = "--gitCommit={value}")] public string GitCommit => Get<string>(() => GitCommit);
    /// <summary>Git reference to use when creating the release.</summary>
    [Argument(Format = "--gitRef={value}")] public string GitRef => Get<string>(() => GitRef);
    /// <summary>Release number to use for the new release.</summary>
    [Argument(Format = "--version={value}")] public string Version => Get<string>(() => Version);
    /// <summary>Channel to use for the new release. Omit this argument to automatically select the best channel.</summary>
    [Argument(Format = "--channel={value}")] public string Channel => Get<string>(() => Channel);
    /// <summary>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</summary>
    [Argument(Format = "--package={key}:{value}")] public IReadOnlyDictionary<string, string> PackageVersions => Get<Dictionary<string, string>>(() => PackageVersions);
    /// <summary>A folder containing NuGet packages from which we should get versions.</summary>
    [Argument(Format = "--packagesFolder={value}")] public string PackagesFolder => Get<string>(() => PackagesFolder);
    /// <summary>Release Notes for the new release. Styling with Markdown is supported.</summary>
    [Argument(Format = "--releasenotes={value}")] public string ReleaseNotes => Get<string>(() => ReleaseNotes);
    /// <summary>Path to a file that contains Release Notes for the new release. Supports Markdown files.</summary>
    [Argument(Format = "--releasenotesfile={value}")] public string ReleaseNotesFile => Get<string>(() => ReleaseNotesFile);
    /// <summary>Don't create this release if there is already one with the same version number.</summary>
    [Argument(Format = "--ignoreexisting")] public bool? IgnoreExisting => Get<bool?>(() => IgnoreExisting);
    /// <summary>Create the release ignoring any version rules specified by the channel.</summary>
    [Argument(Format = "--ignorechannelrules")] public bool? IgnoreChannelRules => Get<bool?>(() => IgnoreChannelRules);
    /// <summary>Pre-release for latest version of all packages to use for this release.</summary>
    [Argument(Format = "--packageprerelease={value}")] public string PackagePrerelease => Get<string>(() => PackagePrerelease);
    /// <summary>Perform a dry run but don't actually create/deploy release.</summary>
    [Argument(Format = "--whatif")] public bool? WhatIf => Get<bool?>(() => WhatIf);
    /// <summary>Show progress of the deployment.</summary>
    [Argument(Format = "--progress")] public bool? Progress => Get<bool?>(() => Progress);
    /// <summary>Whether to force downloading of already installed packages (flag, default false).</summary>
    [Argument(Format = "--forcepackagedownload")] public bool? ForcePackageDownload => Get<bool?>(() => ForcePackageDownload);
    /// <summary>Whether to wait synchronously for deployment to finish.</summary>
    [Argument(Format = "--waitfordeployment")] public bool? WaitForDeployment => Get<bool?>(() => WaitForDeployment);
    /// <summary>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>--waitfordeployment</c> parameter set.</summary>
    [Argument(Format = "--deploymenttimeout={value}")] public string DeploymentTimeout => Get<string>(() => DeploymentTimeout);
    /// <summary>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</summary>
    [Argument(Format = "--cancelontimeout")] public bool? CancelOnTimeout => Get<bool?>(() => CancelOnTimeout);
    /// <summary>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</summary>
    [Argument(Format = "--deploymentchecksleepcycle={value}")] public string DeploymentCheckSleepCycle => Get<string>(() => DeploymentCheckSleepCycle);
    /// <summary>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</summary>
    [Argument(Format = "--guidedfailure={value}")] public bool? GuidedFailure => Get<bool?>(() => GuidedFailure);
    /// <summary>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</summary>
    [Argument(Format = "--specificmachines={value}")] public IReadOnlyList<string> SpecificMachines => Get<List<string>>(() => SpecificMachines);
    /// <summary>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Skip a step by name.</summary>
    [Argument(Format = "--skip={value}")] public IReadOnlyList<string> Skip => Get<List<string>>(() => Skip);
    /// <summary>Don't print the raw log of failed tasks.</summary>
    [Argument(Format = "--norawlog")] public bool? NoRawLog => Get<bool?>(() => NoRawLog);
    /// <summary>Redirect the raw log of failed tasks to a file.</summary>
    [Argument(Format = "--rawlogfile={value}")] public string RawLogFile => Get<string>(() => RawLogFile);
    /// <summary>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</summary>
    [Argument(Format = "--variable={key}:{value}")] public IReadOnlyDictionary<string, string> Variables => Get<Dictionary<string, string>>(() => Variables);
    /// <summary>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</summary>
    [Argument(Format = "--deployat={value}")] public string DeployAt => Get<string>(() => DeployAt);
    /// <summary>Environment to automatically deploy to, e.g., <c>Production</c>.</summary>
    [Argument(Format = "--deployto={value}")] public string DeployTo => Get<string>(() => DeployTo);
    /// <summary>A tenant the deployment will be performed for; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to tenants able to deploy.</summary>
    [Argument(Format = "--tenant={value}")] public string Tenant => Get<string>(() => Tenant);
    /// <summary>A tenant tag used to match tenants that the deployment will be performed for; specify this argument multiple times to add multiple tenant tags.</summary>
    [Argument(Format = "--tenanttag={value}")] public string TenantTag => Get<string>(() => TenantTag);
    /// <summary>The base URL for your Octopus server - e.g., http://your-octopus/</summary>
    [Argument(Format = "--server={value}")] public string Server => Get<string>(() => Server);
    /// <summary>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</summary>
    [Argument(Format = "--apiKey={value}", Secret = true)] public string ApiKey => Get<string>(() => ApiKey);
    /// <summary>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</summary>
    [Argument(Format = "--user={value}")] public string Username => Get<string>(() => Username);
    /// <summary>Password to use when authenticating with the server.</summary>
    [Argument(Format = "--pass={value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Text file of default values, with one 'key = value' per line.</summary>
    [Argument(Format = "--configFile={value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Enable debug logging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</summary>
    [Argument(Format = "--ignoreSslErrors")] public bool? IgnoreSslErrors => Get<bool?>(() => IgnoreSslErrors);
    /// <summary>Enable TeamCity or Team Foundation Build service messages when logging.</summary>
    [Argument(Format = "--enableServiceMessages")] public bool? EnableServiceMessages => Get<bool?>(() => EnableServiceMessages);
    /// <summary>Timeout in seconds for network operations. Default is 600.</summary>
    [Argument(Format = "--timeout={value}")] public int? Timeout => Get<int?>(() => Timeout);
    /// <summary>The URI of the proxy to use, e.g., http://example.com:8080.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>The username for the proxy.</summary>
    [Argument(Format = "--proxyUser={value}")] public string ProxyUsername => Get<string>(() => ProxyUsername);
    /// <summary>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</summary>
    [Argument(Format = "--proxyPass={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>The name of a space within which this command will be executed. The default space will be used if it is omitted.</summary>
    [Argument(Format = "--space={value}")] public string Space => Get<string>(() => Space);
    /// <summary>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</summary>
    [Argument(Format = "--logLevel={value}")] public string LogLevel => Get<string>(() => LogLevel);
}
#endregion
#region OctopusDeployReleaseSettings
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OctopusDeployReleaseSettings>))]
[Command(Type = typeof(OctopusTasks), Command = nameof(OctopusTasks.OctopusDeployRelease), Arguments = "deploy-release")]
public partial class OctopusDeployReleaseSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>Show progress of the deployment.</summary>
    [Argument(Format = "--progress")] public bool? Progress => Get<bool?>(() => Progress);
    /// <summary>Whether to force downloading of already installed packages (flag, default false).</summary>
    [Argument(Format = "--forcepackagedownload")] public bool? ForcePackageDownload => Get<bool?>(() => ForcePackageDownload);
    /// <summary>Whether to wait synchronously for deployment to finish.</summary>
    [Argument(Format = "--waitfordeployment")] public bool? WaitForDepployment => Get<bool?>(() => WaitForDepployment);
    /// <summary>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>WaitForDeployment</c> parameter set.</summary>
    [Argument(Format = "--deploymenttimeout={value}")] public string DeploymentTimeout => Get<string>(() => DeploymentTimeout);
    /// <summary>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</summary>
    [Argument(Format = "--cancelontimeout")] public bool? CancelOnTimeout => Get<bool?>(() => CancelOnTimeout);
    /// <summary>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</summary>
    [Argument(Format = "--deploymentchecksleepcycle={value}")] public string DeploymentCheckSleepCycle => Get<string>(() => DeploymentCheckSleepCycle);
    /// <summary>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</summary>
    [Argument(Format = "--guidedfailure={value}")] public bool? GuidedFailure => Get<bool?>(() => GuidedFailure);
    /// <summary>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</summary>
    [Argument(Format = "--specificmachines={value}")] public IReadOnlyList<string> SpecificMachines => Get<List<string>>(() => SpecificMachines);
    /// <summary>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Skip a step by name.</summary>
    [Argument(Format = "--skip={value}")] public IReadOnlyList<string> Skip => Get<List<string>>(() => Skip);
    /// <summary>Don't print the raw log of failed tasks.</summary>
    [Argument(Format = "--norawlog")] public bool? NoRawLog => Get<bool?>(() => NoRawLog);
    /// <summary>Redirect the raw log of failed tasks to a file.</summary>
    [Argument(Format = "--rawlogfile={value}")] public string RawLogFile => Get<string>(() => RawLogFile);
    /// <summary>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </summary>
    [Argument(Format = "--variable={key}:{value}")] public IReadOnlyDictionary<string, string> Variables => Get<Dictionary<string, string>>(() => Variables);
    /// <summary>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</summary>
    [Argument(Format = "--deployat={value}")] public string DeployAt => Get<string>(() => DeployAt);
    /// <summary>Create a deployment for this tenant; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to all tenants who are ready for this release (according to lifecycle).</summary>
    [Argument(Format = "--tenant={value}")] public string Tenant => Get<string>(() => Tenant);
    /// <summary>Create a deployment for tenants matching this tag; specify this argument multiple times to build a query/filter with multiple tags, just like you can in the user interface.</summary>
    [Argument(Format = "--tenanttag={value}")] public string TenantTag => Get<string>(() => TenantTag);
    /// <summary>Name of the project.</summary>
    [Argument(Format = "--project={value}")] public string Project => Get<string>(() => Project);
    /// <summary>Environment to deploy to, e.g. <c>Production</c>.</summary>
    [Argument(Format = "--deployto={value}")] public string DeployTo => Get<string>(() => DeployTo);
    /// <summary>Version number of the release to deploy. Or specify 'latest' for the latest release.</summary>
    [Argument(Format = "--version={value}")] public string Version => Get<string>(() => Version);
    /// <summary>Channel to use when getting the release to deploy</summary>
    [Argument(Format = "--channel={value}")] public string Channel => Get<string>(() => Channel);
    /// <summary>Overwrite the variable snapshot for the release by re-importing the variables from the project</summary>
    [Argument(Format = "--updateVariables")] public bool? UpdateVariables => Get<bool?>(() => UpdateVariables);
    /// <summary>The base URL for your Octopus server - e.g., http://your-octopus/</summary>
    [Argument(Format = "--server={value}")] public string Server => Get<string>(() => Server);
    /// <summary>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</summary>
    [Argument(Format = "--apiKey={value}", Secret = true)] public string ApiKey => Get<string>(() => ApiKey);
    /// <summary>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</summary>
    [Argument(Format = "--user={value}")] public string Username => Get<string>(() => Username);
    /// <summary>Password to use when authenticating with the server.</summary>
    [Argument(Format = "--pass={value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Text file of default values, with one 'key = value' per line.</summary>
    [Argument(Format = "--configFile={value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Enable debug logging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</summary>
    [Argument(Format = "--ignoreSslErrors")] public bool? IgnoreSslErrors => Get<bool?>(() => IgnoreSslErrors);
    /// <summary>Enable TeamCity or Team Foundation Build service messages when logging.</summary>
    [Argument(Format = "--enableServiceMessages")] public bool? EnableServiceMessages => Get<bool?>(() => EnableServiceMessages);
    /// <summary>Timeout in seconds for network operations. Default is 600.</summary>
    [Argument(Format = "--timeout={value}")] public int? Timeout => Get<int?>(() => Timeout);
    /// <summary>The URI of the proxy to use, e.g., http://example.com:8080.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>The username for the proxy.</summary>
    [Argument(Format = "--proxyUser={value}")] public string ProxyUsername => Get<string>(() => ProxyUsername);
    /// <summary>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</summary>
    [Argument(Format = "--proxyPass={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>The name of a space within which this command will be executed. The default space will be used if it is omitted.</summary>
    [Argument(Format = "--space={value}")] public string Space => Get<string>(() => Space);
    /// <summary>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</summary>
    [Argument(Format = "--logLevel={value}")] public string LogLevel => Get<string>(() => LogLevel);
}
#endregion
#region OctopusBuildInformationSettings
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OctopusBuildInformationSettings>))]
[Command(Type = typeof(OctopusTasks), Command = nameof(OctopusTasks.OctopusBuildInformation), Arguments = "build-information")]
public partial class OctopusBuildInformationSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>Id of the package.</summary>
    [Argument(Format = "--package-id={value}")] public IReadOnlyList<string> PackageId => Get<List<string>>(() => PackageId);
    /// <summary>Version number of the package.</summary>
    [Argument(Format = "--version={value}")] public string Version => Get<string>(() => Version);
    /// <summary>Octopus build information json file.</summary>
    [Argument(Format = "--file={value}")] public string File => Get<string>(() => File);
    /// <summary>Overwrite policy when the information already exists.</summary>
    [Argument(Format = "--overwrite-mode={value}")] public OctopusOverwriteMode OverwriteMode => Get<OctopusOverwriteMode>(() => OverwriteMode);
    /// <summary>The base URL for your Octopus server - e.g., http://your-octopus/</summary>
    [Argument(Format = "--server={value}")] public string Server => Get<string>(() => Server);
    /// <summary>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</summary>
    [Argument(Format = "--apiKey={value}", Secret = true)] public string ApiKey => Get<string>(() => ApiKey);
    /// <summary>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</summary>
    [Argument(Format = "--user={value}")] public string Username => Get<string>(() => Username);
    /// <summary>Password to use when authenticating with the server.</summary>
    [Argument(Format = "--pass={value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Text file of default values, with one 'key = value' per line.</summary>
    [Argument(Format = "--configFile={value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Enable debug logging.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</summary>
    [Argument(Format = "--ignoreSslErrors")] public bool? IgnoreSslErrors => Get<bool?>(() => IgnoreSslErrors);
    /// <summary>Enable TeamCity or Team Foundation Build service messages when logging.</summary>
    [Argument(Format = "--enableServiceMessages")] public bool? EnableServiceMessages => Get<bool?>(() => EnableServiceMessages);
    /// <summary>Timeout in seconds for network operations. Default is 600.</summary>
    [Argument(Format = "--timeout={value}")] public int? Timeout => Get<int?>(() => Timeout);
    /// <summary>The URI of the proxy to use, e.g., http://example.com:8080.</summary>
    [Argument(Format = "--proxy={value}")] public string Proxy => Get<string>(() => Proxy);
    /// <summary>The username for the proxy.</summary>
    [Argument(Format = "--proxyUser={value}")] public string ProxyUsername => Get<string>(() => ProxyUsername);
    /// <summary>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</summary>
    [Argument(Format = "--proxyPass={value}", Secret = true)] public string ProxyPassword => Get<string>(() => ProxyPassword);
    /// <summary>The name of a space within which this command will be executed. The default space will be used if it is omitted.</summary>
    [Argument(Format = "--space={value}")] public string Space => Get<string>(() => Space);
    /// <summary>The log level. Valid options are verbose, debug, information, warning, error and fatal. Defaults to 'debug'.</summary>
    [Argument(Format = "--logLevel={value}")] public string LogLevel => Get<string>(() => LogLevel);
}
#endregion
#region OctopusPackSettingsExtensions
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class OctopusPackSettingsExtensions
{
    #region Id
    /// <inheritdoc cref="OctopusPackSettings.Id"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Id))]
    public static T SetId<T>(this T o, string v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Id, v));
    /// <inheritdoc cref="OctopusPackSettings.Id"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Id))]
    public static T ResetId<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.Id));
    #endregion
    #region Format
    /// <inheritdoc cref="OctopusPackSettings.Format"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Format))]
    public static T SetFormat<T>(this T o, OctopusPackFormat v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Format, v));
    /// <inheritdoc cref="OctopusPackSettings.Format"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Format))]
    public static T ResetFormat<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.Format));
    #endregion
    #region Version
    /// <inheritdoc cref="OctopusPackSettings.Version"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="OctopusPackSettings.Version"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region OutputFolder
    /// <inheritdoc cref="OctopusPackSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.OutputFolder))]
    public static T SetOutputFolder<T>(this T o, string v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.OutputFolder, v));
    /// <inheritdoc cref="OctopusPackSettings.OutputFolder"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.OutputFolder))]
    public static T ResetOutputFolder<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.OutputFolder));
    #endregion
    #region BasePath
    /// <inheritdoc cref="OctopusPackSettings.BasePath"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.BasePath))]
    public static T SetBasePath<T>(this T o, string v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.BasePath, v));
    /// <inheritdoc cref="OctopusPackSettings.BasePath"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.BasePath))]
    public static T ResetBasePath<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.BasePath));
    #endregion
    #region Verbose
    /// <inheritdoc cref="OctopusPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="OctopusPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="OctopusPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="OctopusPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="OctopusPackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Authors
    /// <inheritdoc cref="OctopusPackSettings.Authors"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Authors))]
    public static T SetAuthors<T>(this T o, params string[] v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Authors, v));
    /// <inheritdoc cref="OctopusPackSettings.Authors"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Authors))]
    public static T SetAuthors<T>(this T o, IEnumerable<string> v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Authors, v));
    /// <inheritdoc cref="OctopusPackSettings.Authors"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Authors))]
    public static T AddAuthors<T>(this T o, params string[] v) where T : OctopusPackSettings => o.Modify(b => b.AddCollection(() => o.Authors, v));
    /// <inheritdoc cref="OctopusPackSettings.Authors"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Authors))]
    public static T AddAuthors<T>(this T o, IEnumerable<string> v) where T : OctopusPackSettings => o.Modify(b => b.AddCollection(() => o.Authors, v));
    /// <inheritdoc cref="OctopusPackSettings.Authors"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Authors))]
    public static T RemoveAuthors<T>(this T o, params string[] v) where T : OctopusPackSettings => o.Modify(b => b.RemoveCollection(() => o.Authors, v));
    /// <inheritdoc cref="OctopusPackSettings.Authors"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Authors))]
    public static T RemoveAuthors<T>(this T o, IEnumerable<string> v) where T : OctopusPackSettings => o.Modify(b => b.RemoveCollection(() => o.Authors, v));
    /// <inheritdoc cref="OctopusPackSettings.Authors"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Authors))]
    public static T ClearAuthors<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.ClearCollection(() => o.Authors));
    #endregion
    #region Title
    /// <inheritdoc cref="OctopusPackSettings.Title"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Title))]
    public static T SetTitle<T>(this T o, string v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Title, v));
    /// <inheritdoc cref="OctopusPackSettings.Title"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Title))]
    public static T ResetTitle<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.Title));
    #endregion
    #region Description
    /// <inheritdoc cref="OctopusPackSettings.Description"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Description))]
    public static T SetDescription<T>(this T o, string v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="OctopusPackSettings.Description"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Description))]
    public static T ResetDescription<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region ReleaseNotes
    /// <inheritdoc cref="OctopusPackSettings.ReleaseNotes"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.ReleaseNotes))]
    public static T SetReleaseNotes<T>(this T o, string v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.ReleaseNotes, v));
    /// <inheritdoc cref="OctopusPackSettings.ReleaseNotes"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.ReleaseNotes))]
    public static T ResetReleaseNotes<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.ReleaseNotes));
    #endregion
    #region ReleaseNotesFile
    /// <inheritdoc cref="OctopusPackSettings.ReleaseNotesFile"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.ReleaseNotesFile))]
    public static T SetReleaseNotesFile<T>(this T o, string v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.ReleaseNotesFile, v));
    /// <inheritdoc cref="OctopusPackSettings.ReleaseNotesFile"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.ReleaseNotesFile))]
    public static T ResetReleaseNotesFile<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.ReleaseNotesFile));
    #endregion
    #region Include
    /// <inheritdoc cref="OctopusPackSettings.Include"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Include))]
    public static T SetInclude<T>(this T o, params string[] v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Include, v));
    /// <inheritdoc cref="OctopusPackSettings.Include"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Include))]
    public static T SetInclude<T>(this T o, IEnumerable<string> v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Include, v));
    /// <inheritdoc cref="OctopusPackSettings.Include"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Include))]
    public static T AddInclude<T>(this T o, params string[] v) where T : OctopusPackSettings => o.Modify(b => b.AddCollection(() => o.Include, v));
    /// <inheritdoc cref="OctopusPackSettings.Include"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Include))]
    public static T AddInclude<T>(this T o, IEnumerable<string> v) where T : OctopusPackSettings => o.Modify(b => b.AddCollection(() => o.Include, v));
    /// <inheritdoc cref="OctopusPackSettings.Include"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Include))]
    public static T RemoveInclude<T>(this T o, params string[] v) where T : OctopusPackSettings => o.Modify(b => b.RemoveCollection(() => o.Include, v));
    /// <inheritdoc cref="OctopusPackSettings.Include"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Include))]
    public static T RemoveInclude<T>(this T o, IEnumerable<string> v) where T : OctopusPackSettings => o.Modify(b => b.RemoveCollection(() => o.Include, v));
    /// <inheritdoc cref="OctopusPackSettings.Include"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Include))]
    public static T ClearInclude<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.ClearCollection(() => o.Include));
    #endregion
    #region Overwrite
    /// <inheritdoc cref="OctopusPackSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Overwrite))]
    public static T SetOverwrite<T>(this T o, bool? v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Overwrite, v));
    /// <inheritdoc cref="OctopusPackSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Overwrite))]
    public static T ResetOverwrite<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.Overwrite));
    /// <inheritdoc cref="OctopusPackSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Overwrite))]
    public static T EnableOverwrite<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Overwrite, true));
    /// <inheritdoc cref="OctopusPackSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Overwrite))]
    public static T DisableOverwrite<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Overwrite, false));
    /// <inheritdoc cref="OctopusPackSettings.Overwrite"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Overwrite))]
    public static T ToggleOverwrite<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Overwrite, !o.Overwrite));
    #endregion
    #region Framework
    /// <inheritdoc cref="OctopusPackSettings.Framework"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Framework))]
    public static T SetFramework<T>(this T o, string v) where T : OctopusPackSettings => o.Modify(b => b.Set(() => o.Framework, v));
    /// <inheritdoc cref="OctopusPackSettings.Framework"/>
    [Pure] [Builder(Type = typeof(OctopusPackSettings), Property = nameof(OctopusPackSettings.Framework))]
    public static T ResetFramework<T>(this T o) where T : OctopusPackSettings => o.Modify(b => b.Remove(() => o.Framework));
    #endregion
}
#endregion
#region OctopusPushSettingsExtensions
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class OctopusPushSettingsExtensions
{
    #region Package
    /// <inheritdoc cref="OctopusPushSettings.Package"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Package))]
    public static T SetPackage<T>(this T o, params string[] v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Package, v));
    /// <inheritdoc cref="OctopusPushSettings.Package"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Package))]
    public static T SetPackage<T>(this T o, IEnumerable<string> v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Package, v));
    /// <inheritdoc cref="OctopusPushSettings.Package"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Package))]
    public static T AddPackage<T>(this T o, params string[] v) where T : OctopusPushSettings => o.Modify(b => b.AddCollection(() => o.Package, v));
    /// <inheritdoc cref="OctopusPushSettings.Package"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Package))]
    public static T AddPackage<T>(this T o, IEnumerable<string> v) where T : OctopusPushSettings => o.Modify(b => b.AddCollection(() => o.Package, v));
    /// <inheritdoc cref="OctopusPushSettings.Package"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Package))]
    public static T RemovePackage<T>(this T o, params string[] v) where T : OctopusPushSettings => o.Modify(b => b.RemoveCollection(() => o.Package, v));
    /// <inheritdoc cref="OctopusPushSettings.Package"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Package))]
    public static T RemovePackage<T>(this T o, IEnumerable<string> v) where T : OctopusPushSettings => o.Modify(b => b.RemoveCollection(() => o.Package, v));
    /// <inheritdoc cref="OctopusPushSettings.Package"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Package))]
    public static T ClearPackage<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.ClearCollection(() => o.Package));
    #endregion
    #region ReplaceExisting
    /// <inheritdoc cref="OctopusPushSettings.ReplaceExisting"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ReplaceExisting))]
    public static T SetReplaceExisting<T>(this T o, bool? v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.ReplaceExisting, v));
    /// <inheritdoc cref="OctopusPushSettings.ReplaceExisting"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ReplaceExisting))]
    public static T ResetReplaceExisting<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.ReplaceExisting));
    /// <inheritdoc cref="OctopusPushSettings.ReplaceExisting"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ReplaceExisting))]
    public static T EnableReplaceExisting<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.ReplaceExisting, true));
    /// <inheritdoc cref="OctopusPushSettings.ReplaceExisting"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ReplaceExisting))]
    public static T DisableReplaceExisting<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.ReplaceExisting, false));
    /// <inheritdoc cref="OctopusPushSettings.ReplaceExisting"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ReplaceExisting))]
    public static T ToggleReplaceExisting<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.ReplaceExisting, !o.ReplaceExisting));
    #endregion
    #region Server
    /// <inheritdoc cref="OctopusPushSettings.Server"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Server))]
    public static T SetServer<T>(this T o, string v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Server, v));
    /// <inheritdoc cref="OctopusPushSettings.Server"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Server))]
    public static T ResetServer<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.Server));
    #endregion
    #region ApiKey
    /// <inheritdoc cref="OctopusPushSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ApiKey))]
    public static T SetApiKey<T>(this T o, [Secret] string v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.ApiKey, v));
    /// <inheritdoc cref="OctopusPushSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ApiKey))]
    public static T ResetApiKey<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.ApiKey));
    #endregion
    #region Username
    /// <inheritdoc cref="OctopusPushSettings.Username"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="OctopusPushSettings.Username"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Password
    /// <inheritdoc cref="OctopusPushSettings.Password"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="OctopusPushSettings.Password"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="OctopusPushSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="OctopusPushSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Debug
    /// <inheritdoc cref="OctopusPushSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="OctopusPushSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="OctopusPushSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="OctopusPushSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="OctopusPushSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region IgnoreSslErrors
    /// <inheritdoc cref="OctopusPushSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.IgnoreSslErrors))]
    public static T SetIgnoreSslErrors<T>(this T o, bool? v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, v));
    /// <inheritdoc cref="OctopusPushSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.IgnoreSslErrors))]
    public static T ResetIgnoreSslErrors<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.IgnoreSslErrors));
    /// <inheritdoc cref="OctopusPushSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.IgnoreSslErrors))]
    public static T EnableIgnoreSslErrors<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, true));
    /// <inheritdoc cref="OctopusPushSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.IgnoreSslErrors))]
    public static T DisableIgnoreSslErrors<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, false));
    /// <inheritdoc cref="OctopusPushSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.IgnoreSslErrors))]
    public static T ToggleIgnoreSslErrors<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, !o.IgnoreSslErrors));
    #endregion
    #region EnableServiceMessages
    /// <inheritdoc cref="OctopusPushSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.EnableServiceMessages))]
    public static T SetEnableServiceMessages<T>(this T o, bool? v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, v));
    /// <inheritdoc cref="OctopusPushSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.EnableServiceMessages))]
    public static T ResetEnableServiceMessages<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.EnableServiceMessages));
    /// <inheritdoc cref="OctopusPushSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.EnableServiceMessages))]
    public static T EnableEnableServiceMessages<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, true));
    /// <inheritdoc cref="OctopusPushSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.EnableServiceMessages))]
    public static T DisableEnableServiceMessages<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, false));
    /// <inheritdoc cref="OctopusPushSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.EnableServiceMessages))]
    public static T ToggleEnableServiceMessages<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, !o.EnableServiceMessages));
    #endregion
    #region Timeout
    /// <inheritdoc cref="OctopusPushSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Timeout))]
    public static T SetTimeout<T>(this T o, int? v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="OctopusPushSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Proxy
    /// <inheritdoc cref="OctopusPushSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="OctopusPushSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUsername
    /// <inheritdoc cref="OctopusPushSettings.ProxyUsername"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ProxyUsername))]
    public static T SetProxyUsername<T>(this T o, string v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.ProxyUsername, v));
    /// <inheritdoc cref="OctopusPushSettings.ProxyUsername"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ProxyUsername))]
    public static T ResetProxyUsername<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.ProxyUsername));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="OctopusPushSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="OctopusPushSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region Space
    /// <inheritdoc cref="OctopusPushSettings.Space"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Space))]
    public static T SetSpace<T>(this T o, string v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.Space, v));
    /// <inheritdoc cref="OctopusPushSettings.Space"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.Space))]
    public static T ResetSpace<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.Space));
    #endregion
    #region LogLevel
    /// <inheritdoc cref="OctopusPushSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.LogLevel))]
    public static T SetLogLevel<T>(this T o, string v) where T : OctopusPushSettings => o.Modify(b => b.Set(() => o.LogLevel, v));
    /// <inheritdoc cref="OctopusPushSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(OctopusPushSettings), Property = nameof(OctopusPushSettings.LogLevel))]
    public static T ResetLogLevel<T>(this T o) where T : OctopusPushSettings => o.Modify(b => b.Remove(() => o.LogLevel));
    #endregion
}
#endregion
#region OctopusCreateReleaseSettingsExtensions
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class OctopusCreateReleaseSettingsExtensions
{
    #region Project
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Project"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Project"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Project))]
    public static T ResetProject<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region DefaultPackageVersion
    /// <inheritdoc cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.DefaultPackageVersion))]
    public static T SetDefaultPackageVersion<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.DefaultPackageVersion, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.DefaultPackageVersion))]
    public static T ResetDefaultPackageVersion<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.DefaultPackageVersion));
    #endregion
    #region GitCommit
    /// <inheritdoc cref="OctopusCreateReleaseSettings.GitCommit"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.GitCommit))]
    public static T SetGitCommit<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.GitCommit, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.GitCommit"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.GitCommit))]
    public static T ResetGitCommit<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.GitCommit));
    #endregion
    #region GitRef
    /// <inheritdoc cref="OctopusCreateReleaseSettings.GitRef"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.GitRef))]
    public static T SetGitRef<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.GitRef, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.GitRef"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.GitRef))]
    public static T ResetGitRef<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.GitRef));
    #endregion
    #region Version
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Version"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Version"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Channel
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Channel"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Channel))]
    public static T SetChannel<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Channel, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Channel"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Channel))]
    public static T ResetChannel<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Channel));
    #endregion
    #region PackageVersions
    /// <inheritdoc cref="OctopusCreateReleaseSettings.PackageVersions"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.PackageVersions))]
    public static T SetPackageVersions<T>(this T o, IDictionary<string, string> v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.PackageVersions, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.PackageVersions"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.PackageVersions))]
    public static T SetPackageVersion<T>(this T o, string k, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.SetDictionary(() => o.PackageVersions, k, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.PackageVersions"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.PackageVersions))]
    public static T AddPackageVersion<T>(this T o, string k, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.AddDictionary(() => o.PackageVersions, k, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.PackageVersions"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.PackageVersions))]
    public static T RemovePackageVersion<T>(this T o, string k) where T : OctopusCreateReleaseSettings => o.Modify(b => b.RemoveDictionary(() => o.PackageVersions, k));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.PackageVersions"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.PackageVersions))]
    public static T ClearPackageVersions<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.ClearDictionary(() => o.PackageVersions));
    #endregion
    #region PackagesFolder
    /// <inheritdoc cref="OctopusCreateReleaseSettings.PackagesFolder"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.PackagesFolder))]
    public static T SetPackagesFolder<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.PackagesFolder, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.PackagesFolder"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.PackagesFolder))]
    public static T ResetPackagesFolder<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.PackagesFolder));
    #endregion
    #region ReleaseNotes
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ReleaseNotes"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ReleaseNotes))]
    public static T SetReleaseNotes<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.ReleaseNotes, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ReleaseNotes"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ReleaseNotes))]
    public static T ResetReleaseNotes<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.ReleaseNotes));
    #endregion
    #region ReleaseNotesFile
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ReleaseNotesFile))]
    public static T SetReleaseNotesFile<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.ReleaseNotesFile, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ReleaseNotesFile))]
    public static T ResetReleaseNotesFile<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.ReleaseNotesFile));
    #endregion
    #region IgnoreExisting
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreExisting"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreExisting))]
    public static T SetIgnoreExisting<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreExisting, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreExisting"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreExisting))]
    public static T ResetIgnoreExisting<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.IgnoreExisting));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreExisting"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreExisting))]
    public static T EnableIgnoreExisting<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreExisting, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreExisting"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreExisting))]
    public static T DisableIgnoreExisting<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreExisting, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreExisting"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreExisting))]
    public static T ToggleIgnoreExisting<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreExisting, !o.IgnoreExisting));
    #endregion
    #region IgnoreChannelRules
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreChannelRules))]
    public static T SetIgnoreChannelRules<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreChannelRules, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreChannelRules))]
    public static T ResetIgnoreChannelRules<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.IgnoreChannelRules));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreChannelRules))]
    public static T EnableIgnoreChannelRules<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreChannelRules, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreChannelRules))]
    public static T DisableIgnoreChannelRules<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreChannelRules, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreChannelRules))]
    public static T ToggleIgnoreChannelRules<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreChannelRules, !o.IgnoreChannelRules));
    #endregion
    #region PackagePrerelease
    /// <inheritdoc cref="OctopusCreateReleaseSettings.PackagePrerelease"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.PackagePrerelease))]
    public static T SetPackagePrerelease<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.PackagePrerelease, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.PackagePrerelease"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.PackagePrerelease))]
    public static T ResetPackagePrerelease<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.PackagePrerelease));
    #endregion
    #region WhatIf
    /// <inheritdoc cref="OctopusCreateReleaseSettings.WhatIf"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.WhatIf))]
    public static T SetWhatIf<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.WhatIf, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.WhatIf"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.WhatIf))]
    public static T ResetWhatIf<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.WhatIf));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.WhatIf"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.WhatIf))]
    public static T EnableWhatIf<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.WhatIf, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.WhatIf"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.WhatIf))]
    public static T DisableWhatIf<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.WhatIf, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.WhatIf"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.WhatIf))]
    public static T ToggleWhatIf<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.WhatIf, !o.WhatIf));
    #endregion
    #region Progress
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Progress"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Progress))]
    public static T SetProgress<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Progress, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Progress"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Progress))]
    public static T ResetProgress<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Progress));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Progress"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Progress))]
    public static T EnableProgress<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Progress, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Progress"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Progress))]
    public static T DisableProgress<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Progress, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Progress"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Progress))]
    public static T ToggleProgress<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Progress, !o.Progress));
    #endregion
    #region ForcePackageDownload
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ForcePackageDownload"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ForcePackageDownload))]
    public static T SetForcePackageDownload<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.ForcePackageDownload, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ForcePackageDownload"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ForcePackageDownload))]
    public static T ResetForcePackageDownload<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.ForcePackageDownload));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ForcePackageDownload"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ForcePackageDownload))]
    public static T EnableForcePackageDownload<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.ForcePackageDownload, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ForcePackageDownload"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ForcePackageDownload))]
    public static T DisableForcePackageDownload<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.ForcePackageDownload, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ForcePackageDownload"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ForcePackageDownload))]
    public static T ToggleForcePackageDownload<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.ForcePackageDownload, !o.ForcePackageDownload));
    #endregion
    #region WaitForDeployment
    /// <inheritdoc cref="OctopusCreateReleaseSettings.WaitForDeployment"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.WaitForDeployment))]
    public static T SetWaitForDeployment<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.WaitForDeployment, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.WaitForDeployment"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.WaitForDeployment))]
    public static T ResetWaitForDeployment<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.WaitForDeployment));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.WaitForDeployment"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.WaitForDeployment))]
    public static T EnableWaitForDeployment<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.WaitForDeployment, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.WaitForDeployment"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.WaitForDeployment))]
    public static T DisableWaitForDeployment<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.WaitForDeployment, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.WaitForDeployment"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.WaitForDeployment))]
    public static T ToggleWaitForDeployment<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.WaitForDeployment, !o.WaitForDeployment));
    #endregion
    #region DeploymentTimeout
    /// <inheritdoc cref="OctopusCreateReleaseSettings.DeploymentTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.DeploymentTimeout))]
    public static T SetDeploymentTimeout<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.DeploymentTimeout, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.DeploymentTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.DeploymentTimeout))]
    public static T ResetDeploymentTimeout<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.DeploymentTimeout));
    #endregion
    #region CancelOnTimeout
    /// <inheritdoc cref="OctopusCreateReleaseSettings.CancelOnTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.CancelOnTimeout))]
    public static T SetCancelOnTimeout<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.CancelOnTimeout, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.CancelOnTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.CancelOnTimeout))]
    public static T ResetCancelOnTimeout<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.CancelOnTimeout));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.CancelOnTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.CancelOnTimeout))]
    public static T EnableCancelOnTimeout<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.CancelOnTimeout, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.CancelOnTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.CancelOnTimeout))]
    public static T DisableCancelOnTimeout<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.CancelOnTimeout, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.CancelOnTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.CancelOnTimeout))]
    public static T ToggleCancelOnTimeout<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.CancelOnTimeout, !o.CancelOnTimeout));
    #endregion
    #region DeploymentCheckSleepCycle
    /// <inheritdoc cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.DeploymentCheckSleepCycle))]
    public static T SetDeploymentCheckSleepCycle<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.DeploymentCheckSleepCycle, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.DeploymentCheckSleepCycle))]
    public static T ResetDeploymentCheckSleepCycle<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.DeploymentCheckSleepCycle));
    #endregion
    #region GuidedFailure
    /// <inheritdoc cref="OctopusCreateReleaseSettings.GuidedFailure"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.GuidedFailure))]
    public static T SetGuidedFailure<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.GuidedFailure, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.GuidedFailure"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.GuidedFailure))]
    public static T ResetGuidedFailure<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.GuidedFailure));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.GuidedFailure"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.GuidedFailure))]
    public static T EnableGuidedFailure<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.GuidedFailure, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.GuidedFailure"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.GuidedFailure))]
    public static T DisableGuidedFailure<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.GuidedFailure, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.GuidedFailure"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.GuidedFailure))]
    public static T ToggleGuidedFailure<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.GuidedFailure, !o.GuidedFailure));
    #endregion
    #region SpecificMachines
    /// <inheritdoc cref="OctopusCreateReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.SpecificMachines))]
    public static T SetSpecificMachines<T>(this T o, params string[] v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.SpecificMachines))]
    public static T SetSpecificMachines<T>(this T o, IEnumerable<string> v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.SpecificMachines))]
    public static T AddSpecificMachines<T>(this T o, params string[] v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.AddCollection(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.SpecificMachines))]
    public static T AddSpecificMachines<T>(this T o, IEnumerable<string> v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.AddCollection(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.SpecificMachines))]
    public static T RemoveSpecificMachines<T>(this T o, params string[] v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.RemoveCollection(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.SpecificMachines))]
    public static T RemoveSpecificMachines<T>(this T o, IEnumerable<string> v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.RemoveCollection(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.SpecificMachines))]
    public static T ClearSpecificMachines<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.ClearCollection(() => o.SpecificMachines));
    #endregion
    #region Force
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Force"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Force"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Force))]
    public static T ResetForce<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Force"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Force))]
    public static T EnableForce<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Force"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Force))]
    public static T DisableForce<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Force"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region Skip
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Skip))]
    public static T SetSkip<T>(this T o, params string[] v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Skip, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Skip))]
    public static T SetSkip<T>(this T o, IEnumerable<string> v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Skip, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Skip))]
    public static T AddSkip<T>(this T o, params string[] v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.AddCollection(() => o.Skip, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Skip))]
    public static T AddSkip<T>(this T o, IEnumerable<string> v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.AddCollection(() => o.Skip, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Skip))]
    public static T RemoveSkip<T>(this T o, params string[] v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.RemoveCollection(() => o.Skip, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Skip))]
    public static T RemoveSkip<T>(this T o, IEnumerable<string> v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.RemoveCollection(() => o.Skip, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Skip))]
    public static T ClearSkip<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.ClearCollection(() => o.Skip));
    #endregion
    #region NoRawLog
    /// <inheritdoc cref="OctopusCreateReleaseSettings.NoRawLog"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.NoRawLog))]
    public static T SetNoRawLog<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.NoRawLog, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.NoRawLog"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.NoRawLog))]
    public static T ResetNoRawLog<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.NoRawLog));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.NoRawLog"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.NoRawLog))]
    public static T EnableNoRawLog<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.NoRawLog, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.NoRawLog"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.NoRawLog))]
    public static T DisableNoRawLog<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.NoRawLog, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.NoRawLog"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.NoRawLog))]
    public static T ToggleNoRawLog<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.NoRawLog, !o.NoRawLog));
    #endregion
    #region RawLogFile
    /// <inheritdoc cref="OctopusCreateReleaseSettings.RawLogFile"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.RawLogFile))]
    public static T SetRawLogFile<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.RawLogFile, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.RawLogFile"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.RawLogFile))]
    public static T ResetRawLogFile<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.RawLogFile));
    #endregion
    #region Variables
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Variables"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Variables))]
    public static T SetVariables<T>(this T o, IDictionary<string, string> v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Variables, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Variables"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Variables))]
    public static T SetVariable<T>(this T o, string k, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.SetDictionary(() => o.Variables, k, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Variables"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Variables))]
    public static T AddVariable<T>(this T o, string k, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.AddDictionary(() => o.Variables, k, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Variables"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Variables))]
    public static T RemoveVariable<T>(this T o, string k) where T : OctopusCreateReleaseSettings => o.Modify(b => b.RemoveDictionary(() => o.Variables, k));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Variables"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Variables))]
    public static T ClearVariables<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.ClearDictionary(() => o.Variables));
    #endregion
    #region DeployAt
    /// <inheritdoc cref="OctopusCreateReleaseSettings.DeployAt"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.DeployAt))]
    public static T SetDeployAt<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.DeployAt, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.DeployAt"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.DeployAt))]
    public static T ResetDeployAt<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.DeployAt));
    #endregion
    #region DeployTo
    /// <inheritdoc cref="OctopusCreateReleaseSettings.DeployTo"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.DeployTo))]
    public static T SetDeployTo<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.DeployTo, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.DeployTo"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.DeployTo))]
    public static T ResetDeployTo<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.DeployTo));
    #endregion
    #region Tenant
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Tenant"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Tenant))]
    public static T SetTenant<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Tenant, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Tenant"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Tenant))]
    public static T ResetTenant<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Tenant));
    #endregion
    #region TenantTag
    /// <inheritdoc cref="OctopusCreateReleaseSettings.TenantTag"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.TenantTag))]
    public static T SetTenantTag<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.TenantTag, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.TenantTag"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.TenantTag))]
    public static T ResetTenantTag<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.TenantTag));
    #endregion
    #region Server
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Server"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Server))]
    public static T SetServer<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Server, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Server"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Server))]
    public static T ResetServer<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Server));
    #endregion
    #region ApiKey
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ApiKey))]
    public static T SetApiKey<T>(this T o, [Secret] string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.ApiKey, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ApiKey))]
    public static T ResetApiKey<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.ApiKey));
    #endregion
    #region Username
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Username"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Username"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Password
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Password"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Password"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Debug
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region IgnoreSslErrors
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreSslErrors))]
    public static T SetIgnoreSslErrors<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreSslErrors))]
    public static T ResetIgnoreSslErrors<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.IgnoreSslErrors));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreSslErrors))]
    public static T EnableIgnoreSslErrors<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreSslErrors))]
    public static T DisableIgnoreSslErrors<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.IgnoreSslErrors))]
    public static T ToggleIgnoreSslErrors<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, !o.IgnoreSslErrors));
    #endregion
    #region EnableServiceMessages
    /// <inheritdoc cref="OctopusCreateReleaseSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.EnableServiceMessages))]
    public static T SetEnableServiceMessages<T>(this T o, bool? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.EnableServiceMessages))]
    public static T ResetEnableServiceMessages<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.EnableServiceMessages));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.EnableServiceMessages))]
    public static T EnableEnableServiceMessages<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, true));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.EnableServiceMessages))]
    public static T DisableEnableServiceMessages<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, false));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.EnableServiceMessages))]
    public static T ToggleEnableServiceMessages<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, !o.EnableServiceMessages));
    #endregion
    #region Timeout
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Timeout))]
    public static T SetTimeout<T>(this T o, int? v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Proxy
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUsername
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ProxyUsername"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ProxyUsername))]
    public static T SetProxyUsername<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.ProxyUsername, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ProxyUsername"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ProxyUsername))]
    public static T ResetProxyUsername<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.ProxyUsername));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region Space
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Space"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Space))]
    public static T SetSpace<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.Space, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.Space"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.Space))]
    public static T ResetSpace<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.Space));
    #endregion
    #region LogLevel
    /// <inheritdoc cref="OctopusCreateReleaseSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.LogLevel))]
    public static T SetLogLevel<T>(this T o, string v) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Set(() => o.LogLevel, v));
    /// <inheritdoc cref="OctopusCreateReleaseSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(OctopusCreateReleaseSettings), Property = nameof(OctopusCreateReleaseSettings.LogLevel))]
    public static T ResetLogLevel<T>(this T o) where T : OctopusCreateReleaseSettings => o.Modify(b => b.Remove(() => o.LogLevel));
    #endregion
}
#endregion
#region OctopusDeployReleaseSettingsExtensions
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class OctopusDeployReleaseSettingsExtensions
{
    #region Progress
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Progress"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Progress))]
    public static T SetProgress<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Progress, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Progress"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Progress))]
    public static T ResetProgress<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Progress));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Progress"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Progress))]
    public static T EnableProgress<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Progress, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Progress"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Progress))]
    public static T DisableProgress<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Progress, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Progress"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Progress))]
    public static T ToggleProgress<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Progress, !o.Progress));
    #endregion
    #region ForcePackageDownload
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ForcePackageDownload"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ForcePackageDownload))]
    public static T SetForcePackageDownload<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.ForcePackageDownload, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ForcePackageDownload"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ForcePackageDownload))]
    public static T ResetForcePackageDownload<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.ForcePackageDownload));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ForcePackageDownload"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ForcePackageDownload))]
    public static T EnableForcePackageDownload<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.ForcePackageDownload, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ForcePackageDownload"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ForcePackageDownload))]
    public static T DisableForcePackageDownload<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.ForcePackageDownload, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ForcePackageDownload"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ForcePackageDownload))]
    public static T ToggleForcePackageDownload<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.ForcePackageDownload, !o.ForcePackageDownload));
    #endregion
    #region WaitForDepployment
    /// <inheritdoc cref="OctopusDeployReleaseSettings.WaitForDepployment"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.WaitForDepployment))]
    public static T SetWaitForDepployment<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.WaitForDepployment, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.WaitForDepployment"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.WaitForDepployment))]
    public static T ResetWaitForDepployment<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.WaitForDepployment));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.WaitForDepployment"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.WaitForDepployment))]
    public static T EnableWaitForDepployment<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.WaitForDepployment, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.WaitForDepployment"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.WaitForDepployment))]
    public static T DisableWaitForDepployment<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.WaitForDepployment, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.WaitForDepployment"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.WaitForDepployment))]
    public static T ToggleWaitForDepployment<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.WaitForDepployment, !o.WaitForDepployment));
    #endregion
    #region DeploymentTimeout
    /// <inheritdoc cref="OctopusDeployReleaseSettings.DeploymentTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.DeploymentTimeout))]
    public static T SetDeploymentTimeout<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.DeploymentTimeout, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.DeploymentTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.DeploymentTimeout))]
    public static T ResetDeploymentTimeout<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.DeploymentTimeout));
    #endregion
    #region CancelOnTimeout
    /// <inheritdoc cref="OctopusDeployReleaseSettings.CancelOnTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.CancelOnTimeout))]
    public static T SetCancelOnTimeout<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.CancelOnTimeout, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.CancelOnTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.CancelOnTimeout))]
    public static T ResetCancelOnTimeout<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.CancelOnTimeout));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.CancelOnTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.CancelOnTimeout))]
    public static T EnableCancelOnTimeout<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.CancelOnTimeout, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.CancelOnTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.CancelOnTimeout))]
    public static T DisableCancelOnTimeout<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.CancelOnTimeout, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.CancelOnTimeout"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.CancelOnTimeout))]
    public static T ToggleCancelOnTimeout<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.CancelOnTimeout, !o.CancelOnTimeout));
    #endregion
    #region DeploymentCheckSleepCycle
    /// <inheritdoc cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.DeploymentCheckSleepCycle))]
    public static T SetDeploymentCheckSleepCycle<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.DeploymentCheckSleepCycle, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.DeploymentCheckSleepCycle))]
    public static T ResetDeploymentCheckSleepCycle<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.DeploymentCheckSleepCycle));
    #endregion
    #region GuidedFailure
    /// <inheritdoc cref="OctopusDeployReleaseSettings.GuidedFailure"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.GuidedFailure))]
    public static T SetGuidedFailure<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.GuidedFailure, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.GuidedFailure"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.GuidedFailure))]
    public static T ResetGuidedFailure<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.GuidedFailure));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.GuidedFailure"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.GuidedFailure))]
    public static T EnableGuidedFailure<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.GuidedFailure, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.GuidedFailure"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.GuidedFailure))]
    public static T DisableGuidedFailure<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.GuidedFailure, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.GuidedFailure"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.GuidedFailure))]
    public static T ToggleGuidedFailure<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.GuidedFailure, !o.GuidedFailure));
    #endregion
    #region SpecificMachines
    /// <inheritdoc cref="OctopusDeployReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.SpecificMachines))]
    public static T SetSpecificMachines<T>(this T o, params string[] v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.SpecificMachines))]
    public static T SetSpecificMachines<T>(this T o, IEnumerable<string> v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.SpecificMachines))]
    public static T AddSpecificMachines<T>(this T o, params string[] v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.AddCollection(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.SpecificMachines))]
    public static T AddSpecificMachines<T>(this T o, IEnumerable<string> v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.AddCollection(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.SpecificMachines))]
    public static T RemoveSpecificMachines<T>(this T o, params string[] v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.RemoveCollection(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.SpecificMachines))]
    public static T RemoveSpecificMachines<T>(this T o, IEnumerable<string> v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.RemoveCollection(() => o.SpecificMachines, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.SpecificMachines"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.SpecificMachines))]
    public static T ClearSpecificMachines<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.ClearCollection(() => o.SpecificMachines));
    #endregion
    #region Force
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Force"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Force"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Force))]
    public static T ResetForce<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Force"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Force))]
    public static T EnableForce<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Force"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Force))]
    public static T DisableForce<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Force"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region Skip
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Skip))]
    public static T SetSkip<T>(this T o, params string[] v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Skip, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Skip))]
    public static T SetSkip<T>(this T o, IEnumerable<string> v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Skip, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Skip))]
    public static T AddSkip<T>(this T o, params string[] v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.AddCollection(() => o.Skip, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Skip))]
    public static T AddSkip<T>(this T o, IEnumerable<string> v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.AddCollection(() => o.Skip, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Skip))]
    public static T RemoveSkip<T>(this T o, params string[] v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.RemoveCollection(() => o.Skip, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Skip))]
    public static T RemoveSkip<T>(this T o, IEnumerable<string> v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.RemoveCollection(() => o.Skip, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Skip"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Skip))]
    public static T ClearSkip<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.ClearCollection(() => o.Skip));
    #endregion
    #region NoRawLog
    /// <inheritdoc cref="OctopusDeployReleaseSettings.NoRawLog"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.NoRawLog))]
    public static T SetNoRawLog<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.NoRawLog, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.NoRawLog"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.NoRawLog))]
    public static T ResetNoRawLog<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.NoRawLog));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.NoRawLog"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.NoRawLog))]
    public static T EnableNoRawLog<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.NoRawLog, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.NoRawLog"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.NoRawLog))]
    public static T DisableNoRawLog<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.NoRawLog, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.NoRawLog"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.NoRawLog))]
    public static T ToggleNoRawLog<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.NoRawLog, !o.NoRawLog));
    #endregion
    #region RawLogFile
    /// <inheritdoc cref="OctopusDeployReleaseSettings.RawLogFile"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.RawLogFile))]
    public static T SetRawLogFile<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.RawLogFile, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.RawLogFile"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.RawLogFile))]
    public static T ResetRawLogFile<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.RawLogFile));
    #endregion
    #region Variables
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Variables"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Variables))]
    public static T SetVariables<T>(this T o, IDictionary<string, string> v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Variables, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Variables"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Variables))]
    public static T SetVariable<T>(this T o, string k, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.SetDictionary(() => o.Variables, k, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Variables"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Variables))]
    public static T AddVariable<T>(this T o, string k, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.AddDictionary(() => o.Variables, k, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Variables"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Variables))]
    public static T RemoveVariable<T>(this T o, string k) where T : OctopusDeployReleaseSettings => o.Modify(b => b.RemoveDictionary(() => o.Variables, k));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Variables"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Variables))]
    public static T ClearVariables<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.ClearDictionary(() => o.Variables));
    #endregion
    #region DeployAt
    /// <inheritdoc cref="OctopusDeployReleaseSettings.DeployAt"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.DeployAt))]
    public static T SetDeployAt<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.DeployAt, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.DeployAt"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.DeployAt))]
    public static T ResetDeployAt<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.DeployAt));
    #endregion
    #region Tenant
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Tenant"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Tenant))]
    public static T SetTenant<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Tenant, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Tenant"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Tenant))]
    public static T ResetTenant<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Tenant));
    #endregion
    #region TenantTag
    /// <inheritdoc cref="OctopusDeployReleaseSettings.TenantTag"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.TenantTag))]
    public static T SetTenantTag<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.TenantTag, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.TenantTag"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.TenantTag))]
    public static T ResetTenantTag<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.TenantTag));
    #endregion
    #region Project
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Project"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Project"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Project))]
    public static T ResetProject<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region DeployTo
    /// <inheritdoc cref="OctopusDeployReleaseSettings.DeployTo"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.DeployTo))]
    public static T SetDeployTo<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.DeployTo, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.DeployTo"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.DeployTo))]
    public static T ResetDeployTo<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.DeployTo));
    #endregion
    #region Version
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Version"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Version"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Channel
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Channel"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Channel))]
    public static T SetChannel<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Channel, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Channel"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Channel))]
    public static T ResetChannel<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Channel));
    #endregion
    #region UpdateVariables
    /// <inheritdoc cref="OctopusDeployReleaseSettings.UpdateVariables"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.UpdateVariables))]
    public static T SetUpdateVariables<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.UpdateVariables, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.UpdateVariables"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.UpdateVariables))]
    public static T ResetUpdateVariables<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.UpdateVariables));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.UpdateVariables"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.UpdateVariables))]
    public static T EnableUpdateVariables<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.UpdateVariables, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.UpdateVariables"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.UpdateVariables))]
    public static T DisableUpdateVariables<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.UpdateVariables, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.UpdateVariables"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.UpdateVariables))]
    public static T ToggleUpdateVariables<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.UpdateVariables, !o.UpdateVariables));
    #endregion
    #region Server
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Server"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Server))]
    public static T SetServer<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Server, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Server"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Server))]
    public static T ResetServer<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Server));
    #endregion
    #region ApiKey
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ApiKey))]
    public static T SetApiKey<T>(this T o, [Secret] string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.ApiKey, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ApiKey))]
    public static T ResetApiKey<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.ApiKey));
    #endregion
    #region Username
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Username"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Username"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Password
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Password"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Password"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Debug
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region IgnoreSslErrors
    /// <inheritdoc cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.IgnoreSslErrors))]
    public static T SetIgnoreSslErrors<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.IgnoreSslErrors))]
    public static T ResetIgnoreSslErrors<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.IgnoreSslErrors));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.IgnoreSslErrors))]
    public static T EnableIgnoreSslErrors<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.IgnoreSslErrors))]
    public static T DisableIgnoreSslErrors<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.IgnoreSslErrors))]
    public static T ToggleIgnoreSslErrors<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, !o.IgnoreSslErrors));
    #endregion
    #region EnableServiceMessages
    /// <inheritdoc cref="OctopusDeployReleaseSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.EnableServiceMessages))]
    public static T SetEnableServiceMessages<T>(this T o, bool? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.EnableServiceMessages))]
    public static T ResetEnableServiceMessages<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.EnableServiceMessages));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.EnableServiceMessages))]
    public static T EnableEnableServiceMessages<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, true));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.EnableServiceMessages))]
    public static T DisableEnableServiceMessages<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, false));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.EnableServiceMessages))]
    public static T ToggleEnableServiceMessages<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, !o.EnableServiceMessages));
    #endregion
    #region Timeout
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Timeout))]
    public static T SetTimeout<T>(this T o, int? v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Proxy
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUsername
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ProxyUsername"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ProxyUsername))]
    public static T SetProxyUsername<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.ProxyUsername, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ProxyUsername"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ProxyUsername))]
    public static T ResetProxyUsername<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.ProxyUsername));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region Space
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Space"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Space))]
    public static T SetSpace<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.Space, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.Space"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.Space))]
    public static T ResetSpace<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.Space));
    #endregion
    #region LogLevel
    /// <inheritdoc cref="OctopusDeployReleaseSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.LogLevel))]
    public static T SetLogLevel<T>(this T o, string v) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Set(() => o.LogLevel, v));
    /// <inheritdoc cref="OctopusDeployReleaseSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(OctopusDeployReleaseSettings), Property = nameof(OctopusDeployReleaseSettings.LogLevel))]
    public static T ResetLogLevel<T>(this T o) where T : OctopusDeployReleaseSettings => o.Modify(b => b.Remove(() => o.LogLevel));
    #endregion
}
#endregion
#region OctopusBuildInformationSettingsExtensions
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class OctopusBuildInformationSettingsExtensions
{
    #region PackageId
    /// <inheritdoc cref="OctopusBuildInformationSettings.PackageId"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.PackageId))]
    public static T SetPackageId<T>(this T o, params string[] v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.PackageId, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.PackageId"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.PackageId))]
    public static T SetPackageId<T>(this T o, IEnumerable<string> v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.PackageId, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.PackageId"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.PackageId))]
    public static T AddPackageId<T>(this T o, params string[] v) where T : OctopusBuildInformationSettings => o.Modify(b => b.AddCollection(() => o.PackageId, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.PackageId"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.PackageId))]
    public static T AddPackageId<T>(this T o, IEnumerable<string> v) where T : OctopusBuildInformationSettings => o.Modify(b => b.AddCollection(() => o.PackageId, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.PackageId"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.PackageId))]
    public static T RemovePackageId<T>(this T o, params string[] v) where T : OctopusBuildInformationSettings => o.Modify(b => b.RemoveCollection(() => o.PackageId, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.PackageId"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.PackageId))]
    public static T RemovePackageId<T>(this T o, IEnumerable<string> v) where T : OctopusBuildInformationSettings => o.Modify(b => b.RemoveCollection(() => o.PackageId, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.PackageId"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.PackageId))]
    public static T ClearPackageId<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.ClearCollection(() => o.PackageId));
    #endregion
    #region Version
    /// <inheritdoc cref="OctopusBuildInformationSettings.Version"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Version"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region File
    /// <inheritdoc cref="OctopusBuildInformationSettings.File"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.File))]
    public static T SetFile<T>(this T o, string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.File, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.File"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.File))]
    public static T ResetFile<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.File));
    #endregion
    #region OverwriteMode
    /// <inheritdoc cref="OctopusBuildInformationSettings.OverwriteMode"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.OverwriteMode))]
    public static T SetOverwriteMode<T>(this T o, OctopusOverwriteMode v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.OverwriteMode, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.OverwriteMode"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.OverwriteMode))]
    public static T ResetOverwriteMode<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.OverwriteMode));
    #endregion
    #region Server
    /// <inheritdoc cref="OctopusBuildInformationSettings.Server"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Server))]
    public static T SetServer<T>(this T o, string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Server, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Server"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Server))]
    public static T ResetServer<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.Server));
    #endregion
    #region ApiKey
    /// <inheritdoc cref="OctopusBuildInformationSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.ApiKey))]
    public static T SetApiKey<T>(this T o, [Secret] string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.ApiKey, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.ApiKey"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.ApiKey))]
    public static T ResetApiKey<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.ApiKey));
    #endregion
    #region Username
    /// <inheritdoc cref="OctopusBuildInformationSettings.Username"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Username"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Password
    /// <inheritdoc cref="OctopusBuildInformationSettings.Password"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Password"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="OctopusBuildInformationSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Debug
    /// <inheritdoc cref="OctopusBuildInformationSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Debug"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region IgnoreSslErrors
    /// <inheritdoc cref="OctopusBuildInformationSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.IgnoreSslErrors))]
    public static T SetIgnoreSslErrors<T>(this T o, bool? v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.IgnoreSslErrors))]
    public static T ResetIgnoreSslErrors<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.IgnoreSslErrors));
    /// <inheritdoc cref="OctopusBuildInformationSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.IgnoreSslErrors))]
    public static T EnableIgnoreSslErrors<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, true));
    /// <inheritdoc cref="OctopusBuildInformationSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.IgnoreSslErrors))]
    public static T DisableIgnoreSslErrors<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, false));
    /// <inheritdoc cref="OctopusBuildInformationSettings.IgnoreSslErrors"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.IgnoreSslErrors))]
    public static T ToggleIgnoreSslErrors<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.IgnoreSslErrors, !o.IgnoreSslErrors));
    #endregion
    #region EnableServiceMessages
    /// <inheritdoc cref="OctopusBuildInformationSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.EnableServiceMessages))]
    public static T SetEnableServiceMessages<T>(this T o, bool? v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.EnableServiceMessages))]
    public static T ResetEnableServiceMessages<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.EnableServiceMessages));
    /// <inheritdoc cref="OctopusBuildInformationSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.EnableServiceMessages))]
    public static T EnableEnableServiceMessages<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, true));
    /// <inheritdoc cref="OctopusBuildInformationSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.EnableServiceMessages))]
    public static T DisableEnableServiceMessages<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, false));
    /// <inheritdoc cref="OctopusBuildInformationSettings.EnableServiceMessages"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.EnableServiceMessages))]
    public static T ToggleEnableServiceMessages<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.EnableServiceMessages, !o.EnableServiceMessages));
    #endregion
    #region Timeout
    /// <inheritdoc cref="OctopusBuildInformationSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Timeout))]
    public static T SetTimeout<T>(this T o, int? v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Proxy
    /// <inheritdoc cref="OctopusBuildInformationSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Proxy))]
    public static T SetProxy<T>(this T o, string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Proxy, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Proxy"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Proxy))]
    public static T ResetProxy<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.Proxy));
    #endregion
    #region ProxyUsername
    /// <inheritdoc cref="OctopusBuildInformationSettings.ProxyUsername"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.ProxyUsername))]
    public static T SetProxyUsername<T>(this T o, string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.ProxyUsername, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.ProxyUsername"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.ProxyUsername))]
    public static T ResetProxyUsername<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.ProxyUsername));
    #endregion
    #region ProxyPassword
    /// <inheritdoc cref="OctopusBuildInformationSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.ProxyPassword))]
    public static T SetProxyPassword<T>(this T o, [Secret] string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.ProxyPassword, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.ProxyPassword"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.ProxyPassword))]
    public static T ResetProxyPassword<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.ProxyPassword));
    #endregion
    #region Space
    /// <inheritdoc cref="OctopusBuildInformationSettings.Space"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Space))]
    public static T SetSpace<T>(this T o, string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.Space, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.Space"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.Space))]
    public static T ResetSpace<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.Space));
    #endregion
    #region LogLevel
    /// <inheritdoc cref="OctopusBuildInformationSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.LogLevel))]
    public static T SetLogLevel<T>(this T o, string v) where T : OctopusBuildInformationSettings => o.Modify(b => b.Set(() => o.LogLevel, v));
    /// <inheritdoc cref="OctopusBuildInformationSettings.LogLevel"/>
    [Pure] [Builder(Type = typeof(OctopusBuildInformationSettings), Property = nameof(OctopusBuildInformationSettings.LogLevel))]
    public static T ResetLogLevel<T>(this T o) where T : OctopusBuildInformationSettings => o.Modify(b => b.Remove(() => o.LogLevel));
    #endregion
}
#endregion
#region OctopusPackFormat
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
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
/// <summary>Used within <see cref="OctopusTasks"/>.</summary>
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
