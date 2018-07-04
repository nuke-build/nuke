// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, Version: Local.
// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/Octopus.json.

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Octopus
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctopusTasks
    {
        /// <summary><p>Path to the Octopus executable.</p></summary>
        public static string OctopusPath => ToolPathResolver.GetPackageExecutable("OctopusTools", "Octo.exe");
        /// <summary><p>Octopus Deploy is an automated deployment server, which you install yourself, much like you would install SQL Server, Team Foundation Server or JetBrains TeamCity. Octopus makes it easy to automate deployment of ASP.NET web applications and Windows Services into development, test and production environments.<para/>Along with the Octopus Deploy server, you'll also install a lightweight agent service on each of the machines that you plan to deploy to, for example your web and application servers. We call this the Tentacle agent; the idea being that one Octopus server controls many Tentacles, potentially a lot more than 8! With Octopus and Tentacle, you can easily deploy to your own servers, or cloud services from providers like Amazon Web Services or Microsoft Azure.</p></summary>
        public static IReadOnlyCollection<Output> Octopus(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(OctopusPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>The <c>Octo.exe pack</c> command provides a number of other useful parameters that can be used to customize the way your package gets created, such as output folder, files to include and release notes.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
        public static IProcess OctopusPack(Configure<OctopusPackSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new OctopusPackSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process;
        }
        /// <summary><p>The <c>Octo.exe push</c> command can push any of the supported packages types listed on this <a href="https://octopus.com/docs/packaging-applications/supported-packages">page</a>.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
        public static IProcess OctopusPush(Configure<OctopusPushSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new OctopusPushSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process;
        }
        /// <summary><p>The <c>Octo.exe create-release</c> can be used to automate the creation of releases. This allows you to easily integrate Octopus with other continuous integration servers.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
        public static IProcess OctopusCreateRelease(Configure<OctopusCreateReleaseSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new OctopusCreateReleaseSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process;
        }
        /// <summary><p>The <c>Octo.exe deploy-release</c> can be used to automate the deployment of releases to environments. This allows you to easily integrate Octopus with other continuous integration servers.</p><p>For more details, visit the <a href="https://octopus.com/">official website</a>.</p></summary>
        public static IProcess OctopusDeployRelease(Configure<OctopusDeployReleaseSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new OctopusDeployReleaseSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process;
        }
    }
    #region OctopusPackSettings
    /// <summary><p>Used within <see cref="OctopusTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctopusPackSettings : ToolSettings
    {
        /// <summary><p>Path to the Octopus executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? OctopusTasks.OctopusPath;
        /// <summary><p>The ID of the package. E.g. <c>MyCompany.MyApp</c>.</p></summary>
        public virtual string Id { get; internal set; }
        /// <summary><p>Package format. Options are: NuPkg, Zip. Defaults to NuPkg, though we recommend Zip going forward.</p></summary>
        public virtual OctopusPackFormat Format { get; internal set; }
        /// <summary><p>The version of the package; must be a valid SemVer. Defaults to a timestamp-based version.</p></summary>
        public virtual string Version { get; internal set; }
        /// <summary><p>The folder into which the generated NUPKG file will be written. Defaults to <c>.</c>.</p></summary>
        public virtual string OutputFolder { get; internal set; }
        /// <summary><p>The root folder containing files and folders to pack. Defaults to <c>.</c>.</p></summary>
        public virtual string BasePath { get; internal set; }
        /// <summary><p>List more detailed output. E.g. Which files are being added.</p></summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary><p>Add an author to the package metadata. Defaults to the current user.</p></summary>
        public virtual IReadOnlyList<string> Authors => AuthorsInternal.AsReadOnly();
        internal List<string> AuthorsInternal { get; set; } = new List<string>();
        /// <summary><p>The title of the package.</p></summary>
        public virtual string Title { get; internal set; }
        /// <summary><p>A description of the package. Defaults to a generic description.</p></summary>
        public virtual string Description { get; internal set; }
        /// <summary><p>Release notes for this version of the package.</p></summary>
        public virtual string ReleaseNotes { get; internal set; }
        /// <summary><p>A file containing release notes for this version of the package.</p></summary>
        public virtual string ReleaseNotesFile { get; internal set; }
        /// <summary><p>Add a file pattern to include, relative to the base path. E.g. <c>/bin/-*.dll</c> - if none are specified, defaults to <c>**</c>.</p></summary>
        public virtual string Include { get; internal set; }
        /// <summary><p>Allow an existing package file of the same ID/version to be overwritten.</p></summary>
        public virtual bool? Overwrite { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
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
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region OctopusPushSettings
    /// <summary><p>Used within <see cref="OctopusTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctopusPushSettings : ToolSettings
    {
        /// <summary><p>Path to the Octopus executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? OctopusTasks.OctopusPath;
        /// <summary><p>Package file to push.</p></summary>
        public virtual IReadOnlyList<string> Package => PackageInternal.AsReadOnly();
        internal List<string> PackageInternal { get; set; } = new List<string>();
        /// <summary><p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p></summary>
        public virtual bool? ReplaceExisting { get; internal set; }
        /// <summary><p>The base URL for your Octopus server - e.g., http://your-octopus/</p></summary>
        public virtual string Server { get; internal set; }
        /// <summary><p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p></summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary><p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p></summary>
        public virtual string Username { get; internal set; }
        /// <summary><p>Password to use when authenticating with the server.</p></summary>
        public virtual string Password { get; internal set; }
        /// <summary><p>Text file of default values, with one 'key = value' per line.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p>Enable debug logging.</p></summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        public virtual bool? IgnoreSslErrors { get; internal set; }
        /// <summary><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        public virtual bool? EnableServiceMessages { get; internal set; }
        /// <summary><p>Timeout in seconds for network operations. Default is 600.</p></summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary><p>The URI of the proxy to use, e.g., http://example.com:8080.</p></summary>
        public virtual string Proxy { get; internal set; }
        /// <summary><p>The username for the proxy.</p></summary>
        public virtual string ProxyUsername { get; internal set; }
        /// <summary><p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p></summary>
        public virtual string ProxyPassword { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
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
              .Add("--proxyPass={value}", ProxyPassword, secret: true);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region OctopusCreateReleaseSettings
    /// <summary><p>Used within <see cref="OctopusTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctopusCreateReleaseSettings : ToolSettings
    {
        /// <summary><p>Path to the Octopus executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? OctopusTasks.OctopusPath;
        /// <summary><p>Name of the project.</p></summary>
        public virtual string Project { get; internal set; }
        /// <summary><p>Default version number of all packages to use for this release.</p></summary>
        public virtual string DefaultPackageVersion { get; internal set; }
        /// <summary><p>Release number to use for the new release.</p></summary>
        public virtual string Version { get; internal set; }
        /// <summary><p>Channel to use for the new release. Omit this argument to automatically select the best channel.</p></summary>
        public virtual string Channel { get; internal set; }
        /// <summary><p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p></summary>
        public virtual IReadOnlyDictionary<string, string> PackageVersions => PackageVersionsInternal.AsReadOnly();
        internal Dictionary<string, string> PackageVersionsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>A folder containing NuGet packages from which we should get versions.</p></summary>
        public virtual string PackagesFolder { get; internal set; }
        /// <summary><p>Release Notes for the new release. Styling with Markdown is supported.</p></summary>
        public virtual string ReleaseNotes { get; internal set; }
        /// <summary><p>Path to a file that contains Release Notes for the new release. Supports Markdown files.</p></summary>
        public virtual string ReleaseNotesFile { get; internal set; }
        /// <summary><p>Don't create this release if there is already one with the same version number.</p></summary>
        public virtual bool? IgnoreExisting { get; internal set; }
        /// <summary><p>Create the release ignoring any version rules specified by the channel.</p></summary>
        public virtual bool? IgnoreChannelRules { get; internal set; }
        /// <summary><p>Pre-release for latest version of all packages to use for this release.</p></summary>
        public virtual string PackagePrerelease { get; internal set; }
        /// <summary><p>Perform a dry run but don't actually create/deploy release.</p></summary>
        public virtual bool? WhatIf { get; internal set; }
        /// <summary><p>Show progress of the deployment.</p></summary>
        public virtual bool? Progress { get; internal set; }
        /// <summary><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        public virtual bool? ForcePackageDownload { get; internal set; }
        /// <summary><p>Whether to wait synchronously for deployment to finish.</p></summary>
        public virtual bool? WaitForDepployment { get; internal set; }
        /// <summary><p>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>--waitfordeployment</c> parameter set.</p></summary>
        public virtual string DeploymentTimeout { get; internal set; }
        /// <summary><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        public virtual bool? CancelOnTimeout { get; internal set; }
        /// <summary><p>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</p></summary>
        public virtual string DeploymentCheckSleepCycle { get; internal set; }
        /// <summary><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        public virtual bool? GuidedFailure { get; internal set; }
        /// <summary><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        public virtual IReadOnlyList<string> SpecificMachines => SpecificMachinesInternal.AsReadOnly();
        internal List<string> SpecificMachinesInternal { get; set; } = new List<string>();
        /// <summary><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Skip a step by name.</p></summary>
        public virtual IReadOnlyList<string> Skip => SkipInternal.AsReadOnly();
        internal List<string> SkipInternal { get; set; } = new List<string>();
        /// <summary><p>Don't print the raw log of failed tasks.</p></summary>
        public virtual bool? NoRawLog { get; internal set; }
        /// <summary><p>Redirect the raw log of failed tasks to a file.</p></summary>
        public virtual string RawLogFile { get; internal set; }
        /// <summary><p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p></summary>
        public virtual IReadOnlyDictionary<string, string> Variables => VariablesInternal.AsReadOnly();
        internal Dictionary<string, string> VariablesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</p></summary>
        public virtual string DeployAt { get; internal set; }
        /// <summary><p>Environment to automatically deploy to, e.g., <c>Production</c>.</p></summary>
        public virtual string DeployTo { get; internal set; }
        /// <summary><p>A tenant the deployment will be performed for; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to tenants able to deploy.</p></summary>
        public virtual string Tenant { get; internal set; }
        /// <summary><p>A tenant tag used to match tenants that the deployment will be performed for; specify this argument multiple times to add multiple tenant tags.</p></summary>
        public virtual string TenantTag { get; internal set; }
        /// <summary><p>The base URL for your Octopus server - e.g., http://your-octopus/</p></summary>
        public virtual string Server { get; internal set; }
        /// <summary><p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p></summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary><p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p></summary>
        public virtual string Username { get; internal set; }
        /// <summary><p>Password to use when authenticating with the server.</p></summary>
        public virtual string Password { get; internal set; }
        /// <summary><p>Text file of default values, with one 'key = value' per line.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p>Enable debug logging.</p></summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        public virtual bool? IgnoreSslErrors { get; internal set; }
        /// <summary><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        public virtual bool? EnableServiceMessages { get; internal set; }
        /// <summary><p>Timeout in seconds for network operations. Default is 600.</p></summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary><p>The URI of the proxy to use, e.g., http://example.com:8080.</p></summary>
        public virtual string Proxy { get; internal set; }
        /// <summary><p>The username for the proxy.</p></summary>
        public virtual string ProxyUsername { get; internal set; }
        /// <summary><p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p></summary>
        public virtual string ProxyPassword { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
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
              .Add("--proxyPass={value}", ProxyPassword, secret: true);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region OctopusDeployReleaseSettings
    /// <summary><p>Used within <see cref="OctopusTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctopusDeployReleaseSettings : ToolSettings
    {
        /// <summary><p>Path to the Octopus executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? OctopusTasks.OctopusPath;
        /// <summary><p>Show progress of the deployment.</p></summary>
        public virtual bool? Progress { get; internal set; }
        /// <summary><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        public virtual bool? ForcePackageDownload { get; internal set; }
        /// <summary><p>Whether to wait synchronously for deployment to finish.</p></summary>
        public virtual bool? WaitForDepployment { get; internal set; }
        /// <summary><p>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>WaitForDeployment</c> parameter set.</p></summary>
        public virtual string DeploymentTimeout { get; internal set; }
        /// <summary><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        public virtual bool? CancelOnTimeout { get; internal set; }
        /// <summary><p>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</p></summary>
        public virtual string DeploymentCheckSleepCycle { get; internal set; }
        /// <summary><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        public virtual bool? GuidedFailure { get; internal set; }
        /// <summary><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        public virtual IReadOnlyList<string> SpecificMachines => SpecificMachinesInternal.AsReadOnly();
        internal List<string> SpecificMachinesInternal { get; set; } = new List<string>();
        /// <summary><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Skip a step by name.</p></summary>
        public virtual IReadOnlyList<string> Skip => SkipInternal.AsReadOnly();
        internal List<string> SkipInternal { get; set; } = new List<string>();
        /// <summary><p>Don't print the raw log of failed tasks.</p></summary>
        public virtual bool? NoRawLog { get; internal set; }
        /// <summary><p>Redirect the raw log of failed tasks to a file.</p></summary>
        public virtual string RawLogFile { get; internal set; }
        /// <summary><p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p></summary>
        public virtual IReadOnlyDictionary<string, string> Variables => VariablesInternal.AsReadOnly();
        internal Dictionary<string, string> VariablesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</p></summary>
        public virtual string DeployAt { get; internal set; }
        /// <summary><p>Create a deployment for this tenant; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to all tenants who are ready for this release (according to lifecycle).</p></summary>
        public virtual string Tenant { get; internal set; }
        /// <summary><p>Create a deployment for tenants matching this tag; specify this argument multiple times to build a query/filter with multiple tags, just like you can in the user interface.</p></summary>
        public virtual string TenantTag { get; internal set; }
        /// <summary><p>Name of the project.</p></summary>
        public virtual string Project { get; internal set; }
        /// <summary><p>Environment to deploy to, e.g. <c>Production</c>.</p></summary>
        public virtual string DeployTo { get; internal set; }
        /// <summary><p>Version number of the release to deploy. Or specify 'latest' for the latest release.</p></summary>
        public virtual string Version { get; internal set; }
        /// <summary><p>Channel to use when getting the release to deploy</p></summary>
        public virtual string Channel { get; internal set; }
        /// <summary><p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p></summary>
        public virtual bool? UpdateVariables { get; internal set; }
        /// <summary><p>The base URL for your Octopus server - e.g., http://your-octopus/</p></summary>
        public virtual string Server { get; internal set; }
        /// <summary><p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p></summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary><p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p></summary>
        public virtual string Username { get; internal set; }
        /// <summary><p>Password to use when authenticating with the server.</p></summary>
        public virtual string Password { get; internal set; }
        /// <summary><p>Text file of default values, with one 'key = value' per line.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p>Enable debug logging.</p></summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        public virtual bool? IgnoreSslErrors { get; internal set; }
        /// <summary><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        public virtual bool? EnableServiceMessages { get; internal set; }
        /// <summary><p>Timeout in seconds for network operations. Default is 600.</p></summary>
        public virtual int? Timeout { get; internal set; }
        /// <summary><p>The URI of the proxy to use, e.g., http://example.com:8080.</p></summary>
        public virtual string Proxy { get; internal set; }
        /// <summary><p>The username for the proxy.</p></summary>
        public virtual string ProxyUsername { get; internal set; }
        /// <summary><p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p></summary>
        public virtual string ProxyPassword { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
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
              .Add("--proxyPass={value}", ProxyPassword, secret: true);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region OctopusPackSettingsExtensions
    /// <summary><p>Used within <see cref="OctopusTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctopusPackSettingsExtensions
    {
        #region Id
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.Id"/>.</em></p><p>The ID of the package. E.g. <c>MyCompany.MyApp</c>.</p></summary>
        [Pure]
        public static OctopusPackSettings SetId(this OctopusPackSettings toolSettings, string id)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Id = id;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.Id"/>.</em></p><p>The ID of the package. E.g. <c>MyCompany.MyApp</c>.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetId(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Id = null;
            return toolSettings;
        }
        #endregion
        #region Format
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.Format"/>.</em></p><p>Package format. Options are: NuPkg, Zip. Defaults to NuPkg, though we recommend Zip going forward.</p></summary>
        [Pure]
        public static OctopusPackSettings SetFormat(this OctopusPackSettings toolSettings, OctopusPackFormat format)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = format;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.Format"/>.</em></p><p>Package format. Options are: NuPkg, Zip. Defaults to NuPkg, though we recommend Zip going forward.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetFormat(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.Version"/>.</em></p><p>The version of the package; must be a valid SemVer. Defaults to a timestamp-based version.</p></summary>
        [Pure]
        public static OctopusPackSettings SetVersion(this OctopusPackSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.Version"/>.</em></p><p>The version of the package; must be a valid SemVer. Defaults to a timestamp-based version.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetVersion(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region OutputFolder
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.OutputFolder"/>.</em></p><p>The folder into which the generated NUPKG file will be written. Defaults to <c>.</c>.</p></summary>
        [Pure]
        public static OctopusPackSettings SetOutputFolder(this OctopusPackSettings toolSettings, string outputFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = outputFolder;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.OutputFolder"/>.</em></p><p>The folder into which the generated NUPKG file will be written. Defaults to <c>.</c>.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetOutputFolder(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFolder = null;
            return toolSettings;
        }
        #endregion
        #region BasePath
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.BasePath"/>.</em></p><p>The root folder containing files and folders to pack. Defaults to <c>.</c>.</p></summary>
        [Pure]
        public static OctopusPackSettings SetBasePath(this OctopusPackSettings toolSettings, string basePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = basePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.BasePath"/>.</em></p><p>The root folder containing files and folders to pack. Defaults to <c>.</c>.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetBasePath(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = null;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.Verbose"/>.</em></p><p>List more detailed output. E.g. Which files are being added.</p></summary>
        [Pure]
        public static OctopusPackSettings SetVerbose(this OctopusPackSettings toolSettings, bool? verbose)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.Verbose"/>.</em></p><p>List more detailed output. E.g. Which files are being added.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetVerbose(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusPackSettings.Verbose"/>.</em></p><p>List more detailed output. E.g. Which files are being added.</p></summary>
        [Pure]
        public static OctopusPackSettings EnableVerbose(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusPackSettings.Verbose"/>.</em></p><p>List more detailed output. E.g. Which files are being added.</p></summary>
        [Pure]
        public static OctopusPackSettings DisableVerbose(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusPackSettings.Verbose"/>.</em></p><p>List more detailed output. E.g. Which files are being added.</p></summary>
        [Pure]
        public static OctopusPackSettings ToggleVerbose(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Authors
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.Authors"/> to a new list.</em></p><p>Add an author to the package metadata. Defaults to the current user.</p></summary>
        [Pure]
        public static OctopusPackSettings SetAuthors(this OctopusPackSettings toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal = authors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.Authors"/> to a new list.</em></p><p>Add an author to the package metadata. Defaults to the current user.</p></summary>
        [Pure]
        public static OctopusPackSettings SetAuthors(this OctopusPackSettings toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal = authors.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusPackSettings.Authors"/>.</em></p><p>Add an author to the package metadata. Defaults to the current user.</p></summary>
        [Pure]
        public static OctopusPackSettings AddAuthors(this OctopusPackSettings toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal.AddRange(authors);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusPackSettings.Authors"/>.</em></p><p>Add an author to the package metadata. Defaults to the current user.</p></summary>
        [Pure]
        public static OctopusPackSettings AddAuthors(this OctopusPackSettings toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal.AddRange(authors);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OctopusPackSettings.Authors"/>.</em></p><p>Add an author to the package metadata. Defaults to the current user.</p></summary>
        [Pure]
        public static OctopusPackSettings ClearAuthors(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AuthorsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusPackSettings.Authors"/>.</em></p><p>Add an author to the package metadata. Defaults to the current user.</p></summary>
        [Pure]
        public static OctopusPackSettings RemoveAuthors(this OctopusPackSettings toolSettings, params string[] authors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(authors);
            toolSettings.AuthorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusPackSettings.Authors"/>.</em></p><p>Add an author to the package metadata. Defaults to the current user.</p></summary>
        [Pure]
        public static OctopusPackSettings RemoveAuthors(this OctopusPackSettings toolSettings, IEnumerable<string> authors)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(authors);
            toolSettings.AuthorsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Title
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.Title"/>.</em></p><p>The title of the package.</p></summary>
        [Pure]
        public static OctopusPackSettings SetTitle(this OctopusPackSettings toolSettings, string title)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = title;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.Title"/>.</em></p><p>The title of the package.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetTitle(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Title = null;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.Description"/>.</em></p><p>A description of the package. Defaults to a generic description.</p></summary>
        [Pure]
        public static OctopusPackSettings SetDescription(this OctopusPackSettings toolSettings, string description)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.Description"/>.</em></p><p>A description of the package. Defaults to a generic description.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetDescription(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseNotes
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.ReleaseNotes"/>.</em></p><p>Release notes for this version of the package.</p></summary>
        [Pure]
        public static OctopusPackSettings SetReleaseNotes(this OctopusPackSettings toolSettings, string releaseNotes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = releaseNotes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.ReleaseNotes"/>.</em></p><p>Release notes for this version of the package.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetReleaseNotes(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseNotesFile
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.ReleaseNotesFile"/>.</em></p><p>A file containing release notes for this version of the package.</p></summary>
        [Pure]
        public static OctopusPackSettings SetReleaseNotesFile(this OctopusPackSettings toolSettings, string releaseNotesFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotesFile = releaseNotesFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.ReleaseNotesFile"/>.</em></p><p>A file containing release notes for this version of the package.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetReleaseNotesFile(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotesFile = null;
            return toolSettings;
        }
        #endregion
        #region Include
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.Include"/>.</em></p><p>Add a file pattern to include, relative to the base path. E.g. <c>/bin/-*.dll</c> - if none are specified, defaults to <c>**</c>.</p></summary>
        [Pure]
        public static OctopusPackSettings SetInclude(this OctopusPackSettings toolSettings, string include)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Include = include;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.Include"/>.</em></p><p>Add a file pattern to include, relative to the base path. E.g. <c>/bin/-*.dll</c> - if none are specified, defaults to <c>**</c>.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetInclude(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Include = null;
            return toolSettings;
        }
        #endregion
        #region Overwrite
        /// <summary><p><em>Sets <see cref="OctopusPackSettings.Overwrite"/>.</em></p><p>Allow an existing package file of the same ID/version to be overwritten.</p></summary>
        [Pure]
        public static OctopusPackSettings SetOverwrite(this OctopusPackSettings toolSettings, bool? overwrite)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = overwrite;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPackSettings.Overwrite"/>.</em></p><p>Allow an existing package file of the same ID/version to be overwritten.</p></summary>
        [Pure]
        public static OctopusPackSettings ResetOverwrite(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusPackSettings.Overwrite"/>.</em></p><p>Allow an existing package file of the same ID/version to be overwritten.</p></summary>
        [Pure]
        public static OctopusPackSettings EnableOverwrite(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusPackSettings.Overwrite"/>.</em></p><p>Allow an existing package file of the same ID/version to be overwritten.</p></summary>
        [Pure]
        public static OctopusPackSettings DisableOverwrite(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusPackSettings.Overwrite"/>.</em></p><p>Allow an existing package file of the same ID/version to be overwritten.</p></summary>
        [Pure]
        public static OctopusPackSettings ToggleOverwrite(this OctopusPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Overwrite = !toolSettings.Overwrite;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctopusPushSettingsExtensions
    /// <summary><p>Used within <see cref="OctopusTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctopusPushSettingsExtensions
    {
        #region Package
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.Package"/> to a new list.</em></p><p>Package file to push.</p></summary>
        [Pure]
        public static OctopusPushSettings SetPackage(this OctopusPushSettings toolSettings, params string[] package)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageInternal = package.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.Package"/> to a new list.</em></p><p>Package file to push.</p></summary>
        [Pure]
        public static OctopusPushSettings SetPackage(this OctopusPushSettings toolSettings, IEnumerable<string> package)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageInternal = package.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusPushSettings.Package"/>.</em></p><p>Package file to push.</p></summary>
        [Pure]
        public static OctopusPushSettings AddPackage(this OctopusPushSettings toolSettings, params string[] package)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageInternal.AddRange(package);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusPushSettings.Package"/>.</em></p><p>Package file to push.</p></summary>
        [Pure]
        public static OctopusPushSettings AddPackage(this OctopusPushSettings toolSettings, IEnumerable<string> package)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageInternal.AddRange(package);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OctopusPushSettings.Package"/>.</em></p><p>Package file to push.</p></summary>
        [Pure]
        public static OctopusPushSettings ClearPackage(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusPushSettings.Package"/>.</em></p><p>Package file to push.</p></summary>
        [Pure]
        public static OctopusPushSettings RemovePackage(this OctopusPushSettings toolSettings, params string[] package)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(package);
            toolSettings.PackageInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusPushSettings.Package"/>.</em></p><p>Package file to push.</p></summary>
        [Pure]
        public static OctopusPushSettings RemovePackage(this OctopusPushSettings toolSettings, IEnumerable<string> package)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(package);
            toolSettings.PackageInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ReplaceExisting
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.ReplaceExisting"/>.</em></p><p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p></summary>
        [Pure]
        public static OctopusPushSettings SetReplaceExisting(this OctopusPushSettings toolSettings, bool? replaceExisting)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReplaceExisting = replaceExisting;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.ReplaceExisting"/>.</em></p><p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetReplaceExisting(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReplaceExisting = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusPushSettings.ReplaceExisting"/>.</em></p><p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p></summary>
        [Pure]
        public static OctopusPushSettings EnableReplaceExisting(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReplaceExisting = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusPushSettings.ReplaceExisting"/>.</em></p><p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p></summary>
        [Pure]
        public static OctopusPushSettings DisableReplaceExisting(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReplaceExisting = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusPushSettings.ReplaceExisting"/>.</em></p><p>If the package already exists in the repository, the default behavior is to reject the new package being pushed. You can pass this flag to overwrite the existing package.</p></summary>
        [Pure]
        public static OctopusPushSettings ToggleReplaceExisting(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReplaceExisting = !toolSettings.ReplaceExisting;
            return toolSettings;
        }
        #endregion
        #region Server
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.Server"/>.</em></p><p>The base URL for your Octopus server - e.g., http://your-octopus/</p></summary>
        [Pure]
        public static OctopusPushSettings SetServer(this OctopusPushSettings toolSettings, string server)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = server;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.Server"/>.</em></p><p>The base URL for your Octopus server - e.g., http://your-octopus/</p></summary>
        [Pure]
        public static OctopusPushSettings ResetServer(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.ApiKey"/>.</em></p><p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p></summary>
        [Pure]
        public static OctopusPushSettings SetApiKey(this OctopusPushSettings toolSettings, string apiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.ApiKey"/>.</em></p><p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetApiKey(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.Username"/>.</em></p><p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p></summary>
        [Pure]
        public static OctopusPushSettings SetUsername(this OctopusPushSettings toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.Username"/>.</em></p><p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetUsername(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.Password"/>.</em></p><p>Password to use when authenticating with the server.</p></summary>
        [Pure]
        public static OctopusPushSettings SetPassword(this OctopusPushSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.Password"/>.</em></p><p>Password to use when authenticating with the server.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetPassword(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.ConfigFile"/>.</em></p><p>Text file of default values, with one 'key = value' per line.</p></summary>
        [Pure]
        public static OctopusPushSettings SetConfigFile(this OctopusPushSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.ConfigFile"/>.</em></p><p>Text file of default values, with one 'key = value' per line.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetConfigFile(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusPushSettings SetDebug(this OctopusPushSettings toolSettings, bool? debug)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetDebug(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusPushSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusPushSettings EnableDebug(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusPushSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusPushSettings DisableDebug(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusPushSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusPushSettings ToggleDebug(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region IgnoreSslErrors
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusPushSettings SetIgnoreSslErrors(this OctopusPushSettings toolSettings, bool? ignoreSslErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = ignoreSslErrors;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetIgnoreSslErrors(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusPushSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusPushSettings EnableIgnoreSslErrors(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusPushSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusPushSettings DisableIgnoreSslErrors(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusPushSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusPushSettings ToggleIgnoreSslErrors(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = !toolSettings.IgnoreSslErrors;
            return toolSettings;
        }
        #endregion
        #region EnableServiceMessages
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusPushSettings SetEnableServiceMessages(this OctopusPushSettings toolSettings, bool? enableServiceMessages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = enableServiceMessages;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetEnableServiceMessages(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusPushSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusPushSettings EnableEnableServiceMessages(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusPushSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusPushSettings DisableEnableServiceMessages(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusPushSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusPushSettings ToggleEnableServiceMessages(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = !toolSettings.EnableServiceMessages;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.Timeout"/>.</em></p><p>Timeout in seconds for network operations. Default is 600.</p></summary>
        [Pure]
        public static OctopusPushSettings SetTimeout(this OctopusPushSettings toolSettings, int? timeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.Timeout"/>.</em></p><p>Timeout in seconds for network operations. Default is 600.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetTimeout(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.Proxy"/>.</em></p><p>The URI of the proxy to use, e.g., http://example.com:8080.</p></summary>
        [Pure]
        public static OctopusPushSettings SetProxy(this OctopusPushSettings toolSettings, string proxy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.Proxy"/>.</em></p><p>The URI of the proxy to use, e.g., http://example.com:8080.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetProxy(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUsername
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.ProxyUsername"/>.</em></p><p>The username for the proxy.</p></summary>
        [Pure]
        public static OctopusPushSettings SetProxyUsername(this OctopusPushSettings toolSettings, string proxyUsername)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = proxyUsername;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.ProxyUsername"/>.</em></p><p>The username for the proxy.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetProxyUsername(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary><p><em>Sets <see cref="OctopusPushSettings.ProxyPassword"/>.</em></p><p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p></summary>
        [Pure]
        public static OctopusPushSettings SetProxyPassword(this OctopusPushSettings toolSettings, string proxyPassword)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusPushSettings.ProxyPassword"/>.</em></p><p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p></summary>
        [Pure]
        public static OctopusPushSettings ResetProxyPassword(this OctopusPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctopusCreateReleaseSettingsExtensions
    /// <summary><p>Used within <see cref="OctopusTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctopusCreateReleaseSettingsExtensions
    {
        #region Project
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Project"/>.</em></p><p>Name of the project.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetProject(this OctopusCreateReleaseSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Project"/>.</em></p><p>Name of the project.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetProject(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region DefaultPackageVersion
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/>.</em></p><p>Default version number of all packages to use for this release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetDefaultPackageVersion(this OctopusCreateReleaseSettings toolSettings, string defaultPackageVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPackageVersion = defaultPackageVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.DefaultPackageVersion"/>.</em></p><p>Default version number of all packages to use for this release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetDefaultPackageVersion(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPackageVersion = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Version"/>.</em></p><p>Release number to use for the new release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetVersion(this OctopusCreateReleaseSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Version"/>.</em></p><p>Release number to use for the new release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetVersion(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Channel
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Channel"/>.</em></p><p>Channel to use for the new release. Omit this argument to automatically select the best channel.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetChannel(this OctopusCreateReleaseSettings toolSettings, string channel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Channel = channel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Channel"/>.</em></p><p>Channel to use for the new release. Omit this argument to automatically select the best channel.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetChannel(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Channel = null;
            return toolSettings;
        }
        #endregion
        #region PackageVersions
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.PackageVersions"/> to a new dictionary.</em></p><p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetPackageVersions(this OctopusCreateReleaseSettings toolSettings, IDictionary<string, string> packageVersions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersionsInternal = packageVersions.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OctopusCreateReleaseSettings.PackageVersions"/>.</em></p><p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ClearPackageVersions(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersionsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="OctopusCreateReleaseSettings.PackageVersions"/>.</em></p><p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings AddPackageVersion(this OctopusCreateReleaseSettings toolSettings, string packageVersionKey, string packageVersionValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersionsInternal.Add(packageVersionKey, packageVersionValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="OctopusCreateReleaseSettings.PackageVersions"/>.</em></p><p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings RemovePackageVersion(this OctopusCreateReleaseSettings toolSettings, string packageVersionKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersionsInternal.Remove(packageVersionKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="OctopusCreateReleaseSettings.PackageVersions"/>.</em></p><p>Version number to use for a step or package in the release. Format: <c>--package=StepNameOrPackageId:Version</c>.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetPackageVersion(this OctopusCreateReleaseSettings toolSettings, string packageVersionKey, string packageVersionValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageVersionsInternal[packageVersionKey] = packageVersionValue;
            return toolSettings;
        }
        #endregion
        #region PackagesFolder
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.PackagesFolder"/>.</em></p><p>A folder containing NuGet packages from which we should get versions.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetPackagesFolder(this OctopusCreateReleaseSettings toolSettings, string packagesFolder)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesFolder = packagesFolder;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.PackagesFolder"/>.</em></p><p>A folder containing NuGet packages from which we should get versions.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetPackagesFolder(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesFolder = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseNotes
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.ReleaseNotes"/>.</em></p><p>Release Notes for the new release. Styling with Markdown is supported.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetReleaseNotes(this OctopusCreateReleaseSettings toolSettings, string releaseNotes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = releaseNotes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.ReleaseNotes"/>.</em></p><p>Release Notes for the new release. Styling with Markdown is supported.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetReleaseNotes(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotes = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseNotesFile
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/>.</em></p><p>Path to a file that contains Release Notes for the new release. Supports Markdown files.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetReleaseNotesFile(this OctopusCreateReleaseSettings toolSettings, string releaseNotesFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotesFile = releaseNotesFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.ReleaseNotesFile"/>.</em></p><p>Path to a file that contains Release Notes for the new release. Supports Markdown files.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetReleaseNotesFile(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNotesFile = null;
            return toolSettings;
        }
        #endregion
        #region IgnoreExisting
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/>.</em></p><p>Don't create this release if there is already one with the same version number.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetIgnoreExisting(this OctopusCreateReleaseSettings toolSettings, bool? ignoreExisting)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreExisting = ignoreExisting;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/>.</em></p><p>Don't create this release if there is already one with the same version number.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetIgnoreExisting(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreExisting = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/>.</em></p><p>Don't create this release if there is already one with the same version number.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableIgnoreExisting(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreExisting = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/>.</em></p><p>Don't create this release if there is already one with the same version number.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableIgnoreExisting(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreExisting = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.IgnoreExisting"/>.</em></p><p>Don't create this release if there is already one with the same version number.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleIgnoreExisting(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreExisting = !toolSettings.IgnoreExisting;
            return toolSettings;
        }
        #endregion
        #region IgnoreChannelRules
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/>.</em></p><p>Create the release ignoring any version rules specified by the channel.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetIgnoreChannelRules(this OctopusCreateReleaseSettings toolSettings, bool? ignoreChannelRules)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChannelRules = ignoreChannelRules;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/>.</em></p><p>Create the release ignoring any version rules specified by the channel.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetIgnoreChannelRules(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChannelRules = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/>.</em></p><p>Create the release ignoring any version rules specified by the channel.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableIgnoreChannelRules(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChannelRules = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/>.</em></p><p>Create the release ignoring any version rules specified by the channel.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableIgnoreChannelRules(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChannelRules = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.IgnoreChannelRules"/>.</em></p><p>Create the release ignoring any version rules specified by the channel.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleIgnoreChannelRules(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreChannelRules = !toolSettings.IgnoreChannelRules;
            return toolSettings;
        }
        #endregion
        #region PackagePrerelease
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.PackagePrerelease"/>.</em></p><p>Pre-release for latest version of all packages to use for this release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetPackagePrerelease(this OctopusCreateReleaseSettings toolSettings, string packagePrerelease)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagePrerelease = packagePrerelease;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.PackagePrerelease"/>.</em></p><p>Pre-release for latest version of all packages to use for this release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetPackagePrerelease(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagePrerelease = null;
            return toolSettings;
        }
        #endregion
        #region WhatIf
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.WhatIf"/>.</em></p><p>Perform a dry run but don't actually create/deploy release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetWhatIf(this OctopusCreateReleaseSettings toolSettings, bool? whatIf)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhatIf = whatIf;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.WhatIf"/>.</em></p><p>Perform a dry run but don't actually create/deploy release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetWhatIf(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhatIf = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.WhatIf"/>.</em></p><p>Perform a dry run but don't actually create/deploy release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableWhatIf(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhatIf = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.WhatIf"/>.</em></p><p>Perform a dry run but don't actually create/deploy release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableWhatIf(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhatIf = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.WhatIf"/>.</em></p><p>Perform a dry run but don't actually create/deploy release.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleWhatIf(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WhatIf = !toolSettings.WhatIf;
            return toolSettings;
        }
        #endregion
        #region Progress
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Progress"/>.</em></p><p>Show progress of the deployment.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetProgress(this OctopusCreateReleaseSettings toolSettings, bool? progress)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = progress;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Progress"/>.</em></p><p>Show progress of the deployment.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetProgress(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.Progress"/>.</em></p><p>Show progress of the deployment.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableProgress(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.Progress"/>.</em></p><p>Show progress of the deployment.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableProgress(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.Progress"/>.</em></p><p>Show progress of the deployment.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleProgress(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = !toolSettings.Progress;
            return toolSettings;
        }
        #endregion
        #region ForcePackageDownload
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/>.</em></p><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetForcePackageDownload(this OctopusCreateReleaseSettings toolSettings, bool? forcePackageDownload)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = forcePackageDownload;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/>.</em></p><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetForcePackageDownload(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/>.</em></p><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableForcePackageDownload(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/>.</em></p><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableForcePackageDownload(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.ForcePackageDownload"/>.</em></p><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleForcePackageDownload(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = !toolSettings.ForcePackageDownload;
            return toolSettings;
        }
        #endregion
        #region WaitForDepployment
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.WaitForDepployment"/>.</em></p><p>Whether to wait synchronously for deployment to finish.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetWaitForDepployment(this OctopusCreateReleaseSettings toolSettings, bool? waitForDepployment)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = waitForDepployment;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.WaitForDepployment"/>.</em></p><p>Whether to wait synchronously for deployment to finish.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetWaitForDepployment(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.WaitForDepployment"/>.</em></p><p>Whether to wait synchronously for deployment to finish.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableWaitForDepployment(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.WaitForDepployment"/>.</em></p><p>Whether to wait synchronously for deployment to finish.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableWaitForDepployment(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.WaitForDepployment"/>.</em></p><p>Whether to wait synchronously for deployment to finish.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleWaitForDepployment(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = !toolSettings.WaitForDepployment;
            return toolSettings;
        }
        #endregion
        #region DeploymentTimeout
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.DeploymentTimeout"/>.</em></p><p>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>--waitfordeployment</c> parameter set.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetDeploymentTimeout(this OctopusCreateReleaseSettings toolSettings, string deploymentTimeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentTimeout = deploymentTimeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.DeploymentTimeout"/>.</em></p><p>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>--waitfordeployment</c> parameter set.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetDeploymentTimeout(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CancelOnTimeout
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/>.</em></p><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetCancelOnTimeout(this OctopusCreateReleaseSettings toolSettings, bool? cancelOnTimeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = cancelOnTimeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/>.</em></p><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetCancelOnTimeout(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/>.</em></p><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableCancelOnTimeout(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/>.</em></p><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableCancelOnTimeout(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.CancelOnTimeout"/>.</em></p><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleCancelOnTimeout(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = !toolSettings.CancelOnTimeout;
            return toolSettings;
        }
        #endregion
        #region DeploymentCheckSleepCycle
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/>.</em></p><p>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetDeploymentCheckSleepCycle(this OctopusCreateReleaseSettings toolSettings, string deploymentCheckSleepCycle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentCheckSleepCycle = deploymentCheckSleepCycle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.DeploymentCheckSleepCycle"/>.</em></p><p>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetDeploymentCheckSleepCycle(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentCheckSleepCycle = null;
            return toolSettings;
        }
        #endregion
        #region GuidedFailure
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.GuidedFailure"/>.</em></p><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetGuidedFailure(this OctopusCreateReleaseSettings toolSettings, bool? guidedFailure)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = guidedFailure;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.GuidedFailure"/>.</em></p><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetGuidedFailure(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.GuidedFailure"/>.</em></p><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableGuidedFailure(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.GuidedFailure"/>.</em></p><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableGuidedFailure(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.GuidedFailure"/>.</em></p><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleGuidedFailure(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = !toolSettings.GuidedFailure;
            return toolSettings;
        }
        #endregion
        #region SpecificMachines
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.SpecificMachines"/> to a new list.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetSpecificMachines(this OctopusCreateReleaseSettings toolSettings, params string[] specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal = specificMachines.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.SpecificMachines"/> to a new list.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetSpecificMachines(this OctopusCreateReleaseSettings toolSettings, IEnumerable<string> specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal = specificMachines.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusCreateReleaseSettings.SpecificMachines"/>.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings AddSpecificMachines(this OctopusCreateReleaseSettings toolSettings, params string[] specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.AddRange(specificMachines);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusCreateReleaseSettings.SpecificMachines"/>.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings AddSpecificMachines(this OctopusCreateReleaseSettings toolSettings, IEnumerable<string> specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.AddRange(specificMachines);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OctopusCreateReleaseSettings.SpecificMachines"/>.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ClearSpecificMachines(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusCreateReleaseSettings.SpecificMachines"/>.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings RemoveSpecificMachines(this OctopusCreateReleaseSettings toolSettings, params string[] specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(specificMachines);
            toolSettings.SpecificMachinesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusCreateReleaseSettings.SpecificMachines"/>.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings RemoveSpecificMachines(this OctopusCreateReleaseSettings toolSettings, IEnumerable<string> specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(specificMachines);
            toolSettings.SpecificMachinesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Force"/>.</em></p><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetForce(this OctopusCreateReleaseSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Force"/>.</em></p><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetForce(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.Force"/>.</em></p><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableForce(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.Force"/>.</em></p><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableForce(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.Force"/>.</em></p><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleForce(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Skip
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Skip"/> to a new list.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetSkip(this OctopusCreateReleaseSettings toolSettings, params string[] skip)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal = skip.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Skip"/> to a new list.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetSkip(this OctopusCreateReleaseSettings toolSettings, IEnumerable<string> skip)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal = skip.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusCreateReleaseSettings.Skip"/>.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings AddSkip(this OctopusCreateReleaseSettings toolSettings, params string[] skip)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.AddRange(skip);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusCreateReleaseSettings.Skip"/>.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings AddSkip(this OctopusCreateReleaseSettings toolSettings, IEnumerable<string> skip)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.AddRange(skip);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OctopusCreateReleaseSettings.Skip"/>.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ClearSkip(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusCreateReleaseSettings.Skip"/>.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings RemoveSkip(this OctopusCreateReleaseSettings toolSettings, params string[] skip)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(skip);
            toolSettings.SkipInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusCreateReleaseSettings.Skip"/>.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings RemoveSkip(this OctopusCreateReleaseSettings toolSettings, IEnumerable<string> skip)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(skip);
            toolSettings.SkipInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoRawLog
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.NoRawLog"/>.</em></p><p>Don't print the raw log of failed tasks.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetNoRawLog(this OctopusCreateReleaseSettings toolSettings, bool? noRawLog)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = noRawLog;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.NoRawLog"/>.</em></p><p>Don't print the raw log of failed tasks.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetNoRawLog(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.NoRawLog"/>.</em></p><p>Don't print the raw log of failed tasks.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableNoRawLog(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.NoRawLog"/>.</em></p><p>Don't print the raw log of failed tasks.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableNoRawLog(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.NoRawLog"/>.</em></p><p>Don't print the raw log of failed tasks.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleNoRawLog(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = !toolSettings.NoRawLog;
            return toolSettings;
        }
        #endregion
        #region RawLogFile
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.RawLogFile"/>.</em></p><p>Redirect the raw log of failed tasks to a file.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetRawLogFile(this OctopusCreateReleaseSettings toolSettings, string rawLogFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawLogFile = rawLogFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.RawLogFile"/>.</em></p><p>Redirect the raw log of failed tasks to a file.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetRawLogFile(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawLogFile = null;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Variables"/> to a new dictionary.</em></p><p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetVariables(this OctopusCreateReleaseSettings toolSettings, IDictionary<string, string> variables)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal = variables.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OctopusCreateReleaseSettings.Variables"/>.</em></p><p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ClearVariables(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="OctopusCreateReleaseSettings.Variables"/>.</em></p><p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings AddVariable(this OctopusCreateReleaseSettings toolSettings, string variableKey, string variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Add(variableKey, variableValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="OctopusCreateReleaseSettings.Variables"/>.</em></p><p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings RemoveVariable(this OctopusCreateReleaseSettings toolSettings, string variableKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Remove(variableKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="OctopusCreateReleaseSettings.Variables"/>.</em></p><p>Values for any prompted variables in the format Label:Value. For JSON values, embedded quotation marks should be escaped with a backslash.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetVariable(this OctopusCreateReleaseSettings toolSettings, string variableKey, string variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal[variableKey] = variableValue;
            return toolSettings;
        }
        #endregion
        #region DeployAt
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.DeployAt"/>.</em></p><p>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetDeployAt(this OctopusCreateReleaseSettings toolSettings, string deployAt)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployAt = deployAt;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.DeployAt"/>.</em></p><p>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetDeployAt(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployAt = null;
            return toolSettings;
        }
        #endregion
        #region DeployTo
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.DeployTo"/>.</em></p><p>Environment to automatically deploy to, e.g., <c>Production</c>.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetDeployTo(this OctopusCreateReleaseSettings toolSettings, string deployTo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployTo = deployTo;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.DeployTo"/>.</em></p><p>Environment to automatically deploy to, e.g., <c>Production</c>.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetDeployTo(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployTo = null;
            return toolSettings;
        }
        #endregion
        #region Tenant
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Tenant"/>.</em></p><p>A tenant the deployment will be performed for; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to tenants able to deploy.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetTenant(this OctopusCreateReleaseSettings toolSettings, string tenant)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tenant = tenant;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Tenant"/>.</em></p><p>A tenant the deployment will be performed for; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to tenants able to deploy.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetTenant(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tenant = null;
            return toolSettings;
        }
        #endregion
        #region TenantTag
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.TenantTag"/>.</em></p><p>A tenant tag used to match tenants that the deployment will be performed for; specify this argument multiple times to add multiple tenant tags.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetTenantTag(this OctopusCreateReleaseSettings toolSettings, string tenantTag)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TenantTag = tenantTag;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.TenantTag"/>.</em></p><p>A tenant tag used to match tenants that the deployment will be performed for; specify this argument multiple times to add multiple tenant tags.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetTenantTag(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TenantTag = null;
            return toolSettings;
        }
        #endregion
        #region Server
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Server"/>.</em></p><p>The base URL for your Octopus server - e.g., http://your-octopus/</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetServer(this OctopusCreateReleaseSettings toolSettings, string server)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = server;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Server"/>.</em></p><p>The base URL for your Octopus server - e.g., http://your-octopus/</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetServer(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.ApiKey"/>.</em></p><p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetApiKey(this OctopusCreateReleaseSettings toolSettings, string apiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.ApiKey"/>.</em></p><p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetApiKey(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Username"/>.</em></p><p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetUsername(this OctopusCreateReleaseSettings toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Username"/>.</em></p><p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetUsername(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Password"/>.</em></p><p>Password to use when authenticating with the server.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetPassword(this OctopusCreateReleaseSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Password"/>.</em></p><p>Password to use when authenticating with the server.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetPassword(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.ConfigFile"/>.</em></p><p>Text file of default values, with one 'key = value' per line.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetConfigFile(this OctopusCreateReleaseSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.ConfigFile"/>.</em></p><p>Text file of default values, with one 'key = value' per line.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetConfigFile(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetDebug(this OctopusCreateReleaseSettings toolSettings, bool? debug)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetDebug(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableDebug(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableDebug(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleDebug(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region IgnoreSslErrors
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetIgnoreSslErrors(this OctopusCreateReleaseSettings toolSettings, bool? ignoreSslErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = ignoreSslErrors;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetIgnoreSslErrors(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableIgnoreSslErrors(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableIgnoreSslErrors(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleIgnoreSslErrors(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = !toolSettings.IgnoreSslErrors;
            return toolSettings;
        }
        #endregion
        #region EnableServiceMessages
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetEnableServiceMessages(this OctopusCreateReleaseSettings toolSettings, bool? enableServiceMessages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = enableServiceMessages;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetEnableServiceMessages(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings EnableEnableServiceMessages(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings DisableEnableServiceMessages(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusCreateReleaseSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ToggleEnableServiceMessages(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = !toolSettings.EnableServiceMessages;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Timeout"/>.</em></p><p>Timeout in seconds for network operations. Default is 600.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetTimeout(this OctopusCreateReleaseSettings toolSettings, int? timeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Timeout"/>.</em></p><p>Timeout in seconds for network operations. Default is 600.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetTimeout(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.Proxy"/>.</em></p><p>The URI of the proxy to use, e.g., http://example.com:8080.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetProxy(this OctopusCreateReleaseSettings toolSettings, string proxy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.Proxy"/>.</em></p><p>The URI of the proxy to use, e.g., http://example.com:8080.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetProxy(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUsername
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.ProxyUsername"/>.</em></p><p>The username for the proxy.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetProxyUsername(this OctopusCreateReleaseSettings toolSettings, string proxyUsername)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = proxyUsername;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.ProxyUsername"/>.</em></p><p>The username for the proxy.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetProxyUsername(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary><p><em>Sets <see cref="OctopusCreateReleaseSettings.ProxyPassword"/>.</em></p><p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings SetProxyPassword(this OctopusCreateReleaseSettings toolSettings, string proxyPassword)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusCreateReleaseSettings.ProxyPassword"/>.</em></p><p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p></summary>
        [Pure]
        public static OctopusCreateReleaseSettings ResetProxyPassword(this OctopusCreateReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctopusDeployReleaseSettingsExtensions
    /// <summary><p>Used within <see cref="OctopusTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctopusDeployReleaseSettingsExtensions
    {
        #region Progress
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Progress"/>.</em></p><p>Show progress of the deployment.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetProgress(this OctopusDeployReleaseSettings toolSettings, bool? progress)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = progress;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Progress"/>.</em></p><p>Show progress of the deployment.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetProgress(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.Progress"/>.</em></p><p>Show progress of the deployment.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableProgress(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.Progress"/>.</em></p><p>Show progress of the deployment.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableProgress(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.Progress"/>.</em></p><p>Show progress of the deployment.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleProgress(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Progress = !toolSettings.Progress;
            return toolSettings;
        }
        #endregion
        #region ForcePackageDownload
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/>.</em></p><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetForcePackageDownload(this OctopusDeployReleaseSettings toolSettings, bool? forcePackageDownload)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = forcePackageDownload;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/>.</em></p><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetForcePackageDownload(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/>.</em></p><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableForcePackageDownload(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/>.</em></p><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableForcePackageDownload(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.ForcePackageDownload"/>.</em></p><p>Whether to force downloading of already installed packages (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleForcePackageDownload(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForcePackageDownload = !toolSettings.ForcePackageDownload;
            return toolSettings;
        }
        #endregion
        #region WaitForDepployment
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/>.</em></p><p>Whether to wait synchronously for deployment to finish.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetWaitForDepployment(this OctopusDeployReleaseSettings toolSettings, bool? waitForDepployment)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = waitForDepployment;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/>.</em></p><p>Whether to wait synchronously for deployment to finish.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetWaitForDepployment(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/>.</em></p><p>Whether to wait synchronously for deployment to finish.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableWaitForDepployment(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/>.</em></p><p>Whether to wait synchronously for deployment to finish.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableWaitForDepployment(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.WaitForDepployment"/>.</em></p><p>Whether to wait synchronously for deployment to finish.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleWaitForDepployment(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WaitForDepployment = !toolSettings.WaitForDepployment;
            return toolSettings;
        }
        #endregion
        #region DeploymentTimeout
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.DeploymentTimeout"/>.</em></p><p>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>WaitForDeployment</c> parameter set.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetDeploymentTimeout(this OctopusDeployReleaseSettings toolSettings, string deploymentTimeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentTimeout = deploymentTimeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.DeploymentTimeout"/>.</em></p><p>Specifies maximum time (timespan format) that the console session will wait for the deployment to finish(default 00:10:00). This will not stop the deployment. Requires <c>WaitForDeployment</c> parameter set.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetDeploymentTimeout(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentTimeout = null;
            return toolSettings;
        }
        #endregion
        #region CancelOnTimeout
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/>.</em></p><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetCancelOnTimeout(this OctopusDeployReleaseSettings toolSettings, bool? cancelOnTimeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = cancelOnTimeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/>.</em></p><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetCancelOnTimeout(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/>.</em></p><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableCancelOnTimeout(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/>.</em></p><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableCancelOnTimeout(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.CancelOnTimeout"/>.</em></p><p>Whether to cancel the deployment if the deployment timeout is reached (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleCancelOnTimeout(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CancelOnTimeout = !toolSettings.CancelOnTimeout;
            return toolSettings;
        }
        #endregion
        #region DeploymentCheckSleepCycle
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/>.</em></p><p>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetDeploymentCheckSleepCycle(this OctopusDeployReleaseSettings toolSettings, string deploymentCheckSleepCycle)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentCheckSleepCycle = deploymentCheckSleepCycle;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.DeploymentCheckSleepCycle"/>.</em></p><p>Specifies how much time (timespan format) should elapse between deployment status checks (default 00:00:10).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetDeploymentCheckSleepCycle(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentCheckSleepCycle = null;
            return toolSettings;
        }
        #endregion
        #region GuidedFailure
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.GuidedFailure"/>.</em></p><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetGuidedFailure(this OctopusDeployReleaseSettings toolSettings, bool? guidedFailure)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = guidedFailure;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.GuidedFailure"/>.</em></p><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetGuidedFailure(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.GuidedFailure"/>.</em></p><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableGuidedFailure(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.GuidedFailure"/>.</em></p><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableGuidedFailure(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.GuidedFailure"/>.</em></p><p>Whether to use Guided Failure mode. (True or False. If not specified, will use default setting from environment).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleGuidedFailure(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GuidedFailure = !toolSettings.GuidedFailure;
            return toolSettings;
        }
        #endregion
        #region SpecificMachines
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.SpecificMachines"/> to a new list.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetSpecificMachines(this OctopusDeployReleaseSettings toolSettings, params string[] specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal = specificMachines.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.SpecificMachines"/> to a new list.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetSpecificMachines(this OctopusDeployReleaseSettings toolSettings, IEnumerable<string> specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal = specificMachines.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusDeployReleaseSettings.SpecificMachines"/>.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings AddSpecificMachines(this OctopusDeployReleaseSettings toolSettings, params string[] specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.AddRange(specificMachines);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusDeployReleaseSettings.SpecificMachines"/>.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings AddSpecificMachines(this OctopusDeployReleaseSettings toolSettings, IEnumerable<string> specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.AddRange(specificMachines);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OctopusDeployReleaseSettings.SpecificMachines"/>.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ClearSpecificMachines(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SpecificMachinesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusDeployReleaseSettings.SpecificMachines"/>.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings RemoveSpecificMachines(this OctopusDeployReleaseSettings toolSettings, params string[] specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(specificMachines);
            toolSettings.SpecificMachinesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusDeployReleaseSettings.SpecificMachines"/>.</em></p><p>A comma-separated list of machines names to target in the deployed environment. If not specified all machines in the environment will be considered.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings RemoveSpecificMachines(this OctopusDeployReleaseSettings toolSettings, IEnumerable<string> specificMachines)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(specificMachines);
            toolSettings.SpecificMachinesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Force"/>.</em></p><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetForce(this OctopusDeployReleaseSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Force"/>.</em></p><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetForce(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.Force"/>.</em></p><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableForce(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.Force"/>.</em></p><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableForce(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.Force"/>.</em></p><p>If a project is configured to skip packages with already-installed versions, override this setting to force re-deployment (flag, default false).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleForce(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Skip
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Skip"/> to a new list.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetSkip(this OctopusDeployReleaseSettings toolSettings, params string[] skip)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal = skip.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Skip"/> to a new list.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetSkip(this OctopusDeployReleaseSettings toolSettings, IEnumerable<string> skip)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal = skip.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusDeployReleaseSettings.Skip"/>.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings AddSkip(this OctopusDeployReleaseSettings toolSettings, params string[] skip)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.AddRange(skip);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="OctopusDeployReleaseSettings.Skip"/>.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings AddSkip(this OctopusDeployReleaseSettings toolSettings, IEnumerable<string> skip)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.AddRange(skip);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OctopusDeployReleaseSettings.Skip"/>.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ClearSkip(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusDeployReleaseSettings.Skip"/>.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings RemoveSkip(this OctopusDeployReleaseSettings toolSettings, params string[] skip)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(skip);
            toolSettings.SkipInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="OctopusDeployReleaseSettings.Skip"/>.</em></p><p>Skip a step by name.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings RemoveSkip(this OctopusDeployReleaseSettings toolSettings, IEnumerable<string> skip)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(skip);
            toolSettings.SkipInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoRawLog
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.NoRawLog"/>.</em></p><p>Don't print the raw log of failed tasks.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetNoRawLog(this OctopusDeployReleaseSettings toolSettings, bool? noRawLog)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = noRawLog;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.NoRawLog"/>.</em></p><p>Don't print the raw log of failed tasks.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetNoRawLog(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.NoRawLog"/>.</em></p><p>Don't print the raw log of failed tasks.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableNoRawLog(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.NoRawLog"/>.</em></p><p>Don't print the raw log of failed tasks.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableNoRawLog(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.NoRawLog"/>.</em></p><p>Don't print the raw log of failed tasks.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleNoRawLog(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRawLog = !toolSettings.NoRawLog;
            return toolSettings;
        }
        #endregion
        #region RawLogFile
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.RawLogFile"/>.</em></p><p>Redirect the raw log of failed tasks to a file.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetRawLogFile(this OctopusDeployReleaseSettings toolSettings, string rawLogFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawLogFile = rawLogFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.RawLogFile"/>.</em></p><p>Redirect the raw log of failed tasks to a file.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetRawLogFile(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RawLogFile = null;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Variables"/> to a new dictionary.</em></p><p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetVariables(this OctopusDeployReleaseSettings toolSettings, IDictionary<string, string> variables)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal = variables.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="OctopusDeployReleaseSettings.Variables"/>.</em></p><p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ClearVariables(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="OctopusDeployReleaseSettings.Variables"/>.</em></p><p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings AddVariable(this OctopusDeployReleaseSettings toolSettings, string variableKey, string variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Add(variableKey, variableValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="OctopusDeployReleaseSettings.Variables"/>.</em></p><p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings RemoveVariable(this OctopusDeployReleaseSettings toolSettings, string variableKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Remove(variableKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="OctopusDeployReleaseSettings.Variables"/>.</em></p><p>Values for any prompted variables. For JSON values, embedded quotation marks should be escaped with a backslash. </p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetVariable(this OctopusDeployReleaseSettings toolSettings, string variableKey, string variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal[variableKey] = variableValue;
            return toolSettings;
        }
        #endregion
        #region DeployAt
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.DeployAt"/>.</em></p><p>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetDeployAt(this OctopusDeployReleaseSettings toolSettings, string deployAt)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployAt = deployAt;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.DeployAt"/>.</em></p><p>Time at which deployment should start (scheduled deployment), specified as any valid DateTimeOffset format, and assuming the time zone is the current local time zone.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetDeployAt(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployAt = null;
            return toolSettings;
        }
        #endregion
        #region Tenant
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Tenant"/>.</em></p><p>Create a deployment for this tenant; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to all tenants who are ready for this release (according to lifecycle).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetTenant(this OctopusDeployReleaseSettings toolSettings, string tenant)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tenant = tenant;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Tenant"/>.</em></p><p>Create a deployment for this tenant; specify this argument multiple times to add multiple tenants or use <c>*</c> wildcard to deploy to all tenants who are ready for this release (according to lifecycle).</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetTenant(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tenant = null;
            return toolSettings;
        }
        #endregion
        #region TenantTag
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.TenantTag"/>.</em></p><p>Create a deployment for tenants matching this tag; specify this argument multiple times to build a query/filter with multiple tags, just like you can in the user interface.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetTenantTag(this OctopusDeployReleaseSettings toolSettings, string tenantTag)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TenantTag = tenantTag;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.TenantTag"/>.</em></p><p>Create a deployment for tenants matching this tag; specify this argument multiple times to build a query/filter with multiple tags, just like you can in the user interface.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetTenantTag(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TenantTag = null;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Project"/>.</em></p><p>Name of the project.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetProject(this OctopusDeployReleaseSettings toolSettings, string project)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Project"/>.</em></p><p>Name of the project.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetProject(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region DeployTo
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.DeployTo"/>.</em></p><p>Environment to deploy to, e.g. <c>Production</c>.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetDeployTo(this OctopusDeployReleaseSettings toolSettings, string deployTo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployTo = deployTo;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.DeployTo"/>.</em></p><p>Environment to deploy to, e.g. <c>Production</c>.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetDeployTo(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeployTo = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Version"/>.</em></p><p>Version number of the release to deploy. Or specify 'latest' for the latest release.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetVersion(this OctopusDeployReleaseSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Version"/>.</em></p><p>Version number of the release to deploy. Or specify 'latest' for the latest release.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetVersion(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Channel
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Channel"/>.</em></p><p>Channel to use when getting the release to deploy</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetChannel(this OctopusDeployReleaseSettings toolSettings, string channel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Channel = channel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Channel"/>.</em></p><p>Channel to use when getting the release to deploy</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetChannel(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Channel = null;
            return toolSettings;
        }
        #endregion
        #region UpdateVariables
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.UpdateVariables"/>.</em></p><p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetUpdateVariables(this OctopusDeployReleaseSettings toolSettings, bool? updateVariables)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateVariables = updateVariables;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.UpdateVariables"/>.</em></p><p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetUpdateVariables(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateVariables = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.UpdateVariables"/>.</em></p><p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableUpdateVariables(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateVariables = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.UpdateVariables"/>.</em></p><p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableUpdateVariables(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateVariables = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.UpdateVariables"/>.</em></p><p>Overwrite the variable snapshot for the release by re-importing the variables from the project</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleUpdateVariables(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateVariables = !toolSettings.UpdateVariables;
            return toolSettings;
        }
        #endregion
        #region Server
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Server"/>.</em></p><p>The base URL for your Octopus server - e.g., http://your-octopus/</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetServer(this OctopusDeployReleaseSettings toolSettings, string server)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = server;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Server"/>.</em></p><p>The base URL for your Octopus server - e.g., http://your-octopus/</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetServer(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Server = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.ApiKey"/>.</em></p><p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetApiKey(this OctopusDeployReleaseSettings toolSettings, string apiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.ApiKey"/>.</em></p><p>Your API key. Get this from the user profile page. Your must provide an apiKey or username and password. If the guest account is enabled, a key of API-GUEST can be used.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetApiKey(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Username"/>.</em></p><p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetUsername(this OctopusDeployReleaseSettings toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Username"/>.</em></p><p>Username to use when authenticating with the server. Your must provide an apiKey or username and password.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetUsername(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Password"/>.</em></p><p>Password to use when authenticating with the server.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetPassword(this OctopusDeployReleaseSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Password"/>.</em></p><p>Password to use when authenticating with the server.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetPassword(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.ConfigFile"/>.</em></p><p>Text file of default values, with one 'key = value' per line.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetConfigFile(this OctopusDeployReleaseSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.ConfigFile"/>.</em></p><p>Text file of default values, with one 'key = value' per line.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetConfigFile(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetDebug(this OctopusDeployReleaseSettings toolSettings, bool? debug)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetDebug(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableDebug(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableDebug(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.Debug"/>.</em></p><p>Enable debug logging.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleDebug(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region IgnoreSslErrors
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetIgnoreSslErrors(this OctopusDeployReleaseSettings toolSettings, bool? ignoreSslErrors)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = ignoreSslErrors;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetIgnoreSslErrors(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableIgnoreSslErrors(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableIgnoreSslErrors(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.IgnoreSslErrors"/>.</em></p><p>Set this flag if your Octopus server uses HTTPS but the certificate is not trusted on this machine. Any certificate errors will be ignored. WARNING: this option may create a security vulnerability.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleIgnoreSslErrors(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreSslErrors = !toolSettings.IgnoreSslErrors;
            return toolSettings;
        }
        #endregion
        #region EnableServiceMessages
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetEnableServiceMessages(this OctopusDeployReleaseSettings toolSettings, bool? enableServiceMessages)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = enableServiceMessages;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetEnableServiceMessages(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings EnableEnableServiceMessages(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings DisableEnableServiceMessages(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="OctopusDeployReleaseSettings.EnableServiceMessages"/>.</em></p><p>Enable TeamCity or Team Foundation Build service messages when logging.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ToggleEnableServiceMessages(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnableServiceMessages = !toolSettings.EnableServiceMessages;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Timeout"/>.</em></p><p>Timeout in seconds for network operations. Default is 600.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetTimeout(this OctopusDeployReleaseSettings toolSettings, int? timeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Timeout"/>.</em></p><p>Timeout in seconds for network operations. Default is 600.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetTimeout(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Proxy
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.Proxy"/>.</em></p><p>The URI of the proxy to use, e.g., http://example.com:8080.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetProxy(this OctopusDeployReleaseSettings toolSettings, string proxy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = proxy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.Proxy"/>.</em></p><p>The URI of the proxy to use, e.g., http://example.com:8080.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetProxy(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Proxy = null;
            return toolSettings;
        }
        #endregion
        #region ProxyUsername
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.ProxyUsername"/>.</em></p><p>The username for the proxy.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetProxyUsername(this OctopusDeployReleaseSettings toolSettings, string proxyUsername)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = proxyUsername;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.ProxyUsername"/>.</em></p><p>The username for the proxy.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetProxyUsername(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyUsername = null;
            return toolSettings;
        }
        #endregion
        #region ProxyPassword
        /// <summary><p><em>Sets <see cref="OctopusDeployReleaseSettings.ProxyPassword"/>.</em></p><p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings SetProxyPassword(this OctopusDeployReleaseSettings toolSettings, string proxyPassword)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = proxyPassword;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="OctopusDeployReleaseSettings.ProxyPassword"/>.</em></p><p>The password for the proxy. If both the username and password are omitted and proxyAddress is specified, the default credentials are used.</p></summary>
        [Pure]
        public static OctopusDeployReleaseSettings ResetProxyPassword(this OctopusDeployReleaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProxyPassword = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctopusPackFormat
    /// <summary><p>Used within <see cref="OctopusTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class OctopusPackFormat : Enumeration
    {
        public static OctopusPackFormat NuPkg = new OctopusPackFormat { Value = "NuPkg" };
        public static OctopusPackFormat Zip = new OctopusPackFormat { Value = "Zip" };
    }
    #endregion
}
