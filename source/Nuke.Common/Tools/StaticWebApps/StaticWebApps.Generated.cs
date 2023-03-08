// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/StaticWebApps/StaticWebApps.json

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

namespace Nuke.Common.Tools.StaticWebApps
{
    /// <summary>
    ///   <p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NpmPackageRequirement(StaticWebAppsPackageId)]
    public partial class StaticWebAppsTasks
        : IRequireNpmPackage
    {
        public const string StaticWebAppsPackageId = "@azure/static-web-apps-cli";
        /// <summary>
        ///   Path to the StaticWebApps executable.
        /// </summary>
        public static string StaticWebAppsPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("STATICWEBAPPS_EXE") ??
            NpmToolPathResolver.GetNpmExecutable("swa");
        public static Action<OutputType, string> StaticWebAppsLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> StaticWebApps(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(StaticWebAppsPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? StaticWebAppsLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--api-location</c> via <see cref="StaticWebAppsStartSettings.ApiLocation"/></li>
        ///     <li><c>--api-port</c> via <see cref="StaticWebAppsStartSettings.ApiPort"/></li>
        ///     <li><c>--app-artifact-location</c> via <see cref="StaticWebAppsStartSettings.AppArtifactLocation"/></li>
        ///     <li><c>--app-location</c> via <see cref="StaticWebAppsStartSettings.AppLocation"/></li>
        ///     <li><c>--devserver-timeout</c> via <see cref="StaticWebAppsStartSettings.DevServerTimeout"/></li>
        ///     <li><c>--host</c> via <see cref="StaticWebAppsStartSettings.Host"/></li>
        ///     <li><c>--port</c> via <see cref="StaticWebAppsStartSettings.Port"/></li>
        ///     <li><c>--run</c> via <see cref="StaticWebAppsStartSettings.StartupScript"/></li>
        ///     <li><c>--ssl</c> via <see cref="StaticWebAppsStartSettings.Ssl"/></li>
        ///     <li><c>--ssl-cert</c> via <see cref="StaticWebAppsStartSettings.SslCertificate"/></li>
        ///     <li><c>--ssl-key</c> via <see cref="StaticWebAppsStartSettings.SslKey"/></li>
        ///     <li><c>--swa-config-location</c> via <see cref="StaticWebAppsStartSettings.ConfigLocation"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> StaticWebAppsStart(StaticWebAppsStartSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new StaticWebAppsStartSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--api-location</c> via <see cref="StaticWebAppsStartSettings.ApiLocation"/></li>
        ///     <li><c>--api-port</c> via <see cref="StaticWebAppsStartSettings.ApiPort"/></li>
        ///     <li><c>--app-artifact-location</c> via <see cref="StaticWebAppsStartSettings.AppArtifactLocation"/></li>
        ///     <li><c>--app-location</c> via <see cref="StaticWebAppsStartSettings.AppLocation"/></li>
        ///     <li><c>--devserver-timeout</c> via <see cref="StaticWebAppsStartSettings.DevServerTimeout"/></li>
        ///     <li><c>--host</c> via <see cref="StaticWebAppsStartSettings.Host"/></li>
        ///     <li><c>--port</c> via <see cref="StaticWebAppsStartSettings.Port"/></li>
        ///     <li><c>--run</c> via <see cref="StaticWebAppsStartSettings.StartupScript"/></li>
        ///     <li><c>--ssl</c> via <see cref="StaticWebAppsStartSettings.Ssl"/></li>
        ///     <li><c>--ssl-cert</c> via <see cref="StaticWebAppsStartSettings.SslCertificate"/></li>
        ///     <li><c>--ssl-key</c> via <see cref="StaticWebAppsStartSettings.SslKey"/></li>
        ///     <li><c>--swa-config-location</c> via <see cref="StaticWebAppsStartSettings.ConfigLocation"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> StaticWebAppsStart(Configure<StaticWebAppsStartSettings> configurator)
        {
            return StaticWebAppsStart(configurator(new StaticWebAppsStartSettings()));
        }
        /// <summary>
        ///   <p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--api-location</c> via <see cref="StaticWebAppsStartSettings.ApiLocation"/></li>
        ///     <li><c>--api-port</c> via <see cref="StaticWebAppsStartSettings.ApiPort"/></li>
        ///     <li><c>--app-artifact-location</c> via <see cref="StaticWebAppsStartSettings.AppArtifactLocation"/></li>
        ///     <li><c>--app-location</c> via <see cref="StaticWebAppsStartSettings.AppLocation"/></li>
        ///     <li><c>--devserver-timeout</c> via <see cref="StaticWebAppsStartSettings.DevServerTimeout"/></li>
        ///     <li><c>--host</c> via <see cref="StaticWebAppsStartSettings.Host"/></li>
        ///     <li><c>--port</c> via <see cref="StaticWebAppsStartSettings.Port"/></li>
        ///     <li><c>--run</c> via <see cref="StaticWebAppsStartSettings.StartupScript"/></li>
        ///     <li><c>--ssl</c> via <see cref="StaticWebAppsStartSettings.Ssl"/></li>
        ///     <li><c>--ssl-cert</c> via <see cref="StaticWebAppsStartSettings.SslCertificate"/></li>
        ///     <li><c>--ssl-key</c> via <see cref="StaticWebAppsStartSettings.SslKey"/></li>
        ///     <li><c>--swa-config-location</c> via <see cref="StaticWebAppsStartSettings.ConfigLocation"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(StaticWebAppsStartSettings Settings, IReadOnlyCollection<Output> Output)> StaticWebAppsStart(CombinatorialConfigure<StaticWebAppsStartSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(StaticWebAppsStart, StaticWebAppsLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--api-location</c> via <see cref="StaticWebAppsDeploySettings.ApiLocation"/></li>
        ///     <li><c>--app-location</c> via <see cref="StaticWebAppsDeploySettings.AppLocation"/></li>
        ///     <li><c>--deployment-token</c> via <see cref="StaticWebAppsDeploySettings.DeploymentToken"/></li>
        ///     <li><c>--env</c> via <see cref="StaticWebAppsDeploySettings.Environment"/></li>
        ///     <li><c>--output-location</c> via <see cref="StaticWebAppsDeploySettings.OutputLocation"/></li>
        ///     <li><c>--swa-config-location</c> via <see cref="StaticWebAppsDeploySettings.ConfigLocation"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> StaticWebAppsDeploy(StaticWebAppsDeploySettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new StaticWebAppsDeploySettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--api-location</c> via <see cref="StaticWebAppsDeploySettings.ApiLocation"/></li>
        ///     <li><c>--app-location</c> via <see cref="StaticWebAppsDeploySettings.AppLocation"/></li>
        ///     <li><c>--deployment-token</c> via <see cref="StaticWebAppsDeploySettings.DeploymentToken"/></li>
        ///     <li><c>--env</c> via <see cref="StaticWebAppsDeploySettings.Environment"/></li>
        ///     <li><c>--output-location</c> via <see cref="StaticWebAppsDeploySettings.OutputLocation"/></li>
        ///     <li><c>--swa-config-location</c> via <see cref="StaticWebAppsDeploySettings.ConfigLocation"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> StaticWebAppsDeploy(Configure<StaticWebAppsDeploySettings> configurator)
        {
            return StaticWebAppsDeploy(configurator(new StaticWebAppsDeploySettings()));
        }
        /// <summary>
        ///   <p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--api-location</c> via <see cref="StaticWebAppsDeploySettings.ApiLocation"/></li>
        ///     <li><c>--app-location</c> via <see cref="StaticWebAppsDeploySettings.AppLocation"/></li>
        ///     <li><c>--deployment-token</c> via <see cref="StaticWebAppsDeploySettings.DeploymentToken"/></li>
        ///     <li><c>--env</c> via <see cref="StaticWebAppsDeploySettings.Environment"/></li>
        ///     <li><c>--output-location</c> via <see cref="StaticWebAppsDeploySettings.OutputLocation"/></li>
        ///     <li><c>--swa-config-location</c> via <see cref="StaticWebAppsDeploySettings.ConfigLocation"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(StaticWebAppsDeploySettings Settings, IReadOnlyCollection<Output> Output)> StaticWebAppsDeploy(CombinatorialConfigure<StaticWebAppsDeploySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(StaticWebAppsDeploy, StaticWebAppsLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region StaticWebAppsStartSettings
    /// <summary>
    ///   Used within <see cref="StaticWebAppsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class StaticWebAppsStartSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the StaticWebApps executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? StaticWebAppsTasks.StaticWebAppsPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? StaticWebAppsTasks.StaticWebAppsLogger;
        /// <summary>
        ///   Location for the static app source code (default: <c>./</c>)
        /// </summary>
        public virtual string AppLocation { get; internal set; }
        /// <summary>
        ///   Location of the build output directory relative to the <c>--app-location</c>. (default: <c>./</c>)
        /// </summary>
        public virtual string AppArtifactLocation { get; internal set; }
        /// <summary>
        ///   API folder or Azure Functions emulator address
        /// </summary>
        public virtual string ApiLocation { get; internal set; }
        /// <summary>
        ///   Directory where the <em>staticwebapp.config.json</em> file is found (default: <c>./</c>)
        /// </summary>
        public virtual string ConfigLocation { get; internal set; }
        /// <summary>
        ///   API backend port (default: <c>7071</c>)
        /// </summary>
        public virtual int? ApiPort { get; internal set; }
        /// <summary>
        ///   CLI host address (default: <c>localhost</c>)
        /// </summary>
        public virtual string Host { get; internal set; }
        /// <summary>
        ///   CLI port (default: <c>4280</c>)
        /// </summary>
        public virtual int? Port { get; internal set; }
        /// <summary>
        ///   Serve the app and API over HTTPS (default: <c>false</c>)
        /// </summary>
        public virtual bool? Ssl { get; internal set; }
        /// <summary>
        ///   SSL certificate (.crt) to use for serving HTTPS
        /// </summary>
        public virtual string SslCertificate { get; internal set; }
        /// <summary>
        ///   SSL key (.key) to use for serving HTTPS
        /// </summary>
        public virtual string SslKey { get; internal set; }
        /// <summary>
        ///   Run a command at startup
        /// </summary>
        public virtual string StartupScript { get; internal set; }
        /// <summary>
        ///   Time to wait(in ms) for the dev server to start (default: <c>30000</c>)
        /// </summary>
        public virtual int? DevServerTimeout { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("start")
              .Add("--app-location {value}", AppLocation)
              .Add("--app-artifact-location {value}", AppArtifactLocation)
              .Add("--api-location {value}", ApiLocation)
              .Add("--swa-config-location {value}", ConfigLocation)
              .Add("--api-port {value}", ApiPort)
              .Add("--host {value}", Host)
              .Add("--port {value}", Port)
              .Add("--ssl", Ssl)
              .Add("--ssl-cert {value}", SslCertificate)
              .Add("--ssl-key {value}", SslKey)
              .Add("--run {value}", StartupScript)
              .Add("--devserver-timeout {value}", DevServerTimeout);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region StaticWebAppsDeploySettings
    /// <summary>
    ///   Used within <see cref="StaticWebAppsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class StaticWebAppsDeploySettings : ToolSettings
    {
        /// <summary>
        ///   Path to the StaticWebApps executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? StaticWebAppsTasks.StaticWebAppsPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? StaticWebAppsTasks.StaticWebAppsLogger;
        /// <summary>
        ///   Directory containing the source code of the front-end application (default: <c>./</c>).
        /// </summary>
        public virtual string AppLocation { get; internal set; }
        /// <summary>
        ///   Directory containing the source code of the API application.
        /// </summary>
        public virtual string ApiLocation { get; internal set; }
        /// <summary>
        ///   Directory containing the built source of the front-end application. The path is relative to <c>--app-location</c> (default: <c>./</c>).
        /// </summary>
        public virtual string OutputLocation { get; internal set; }
        /// <summary>
        ///   Directory where the <em>staticwebapp.config.json</em> file is found (default: <c>./</c>)
        /// </summary>
        public virtual string ConfigLocation { get; internal set; }
        /// <summary>
        ///   Secret token used to authenticate with the Static Web Apps
        /// </summary>
        public virtual string DeploymentToken { get; internal set; }
        /// <summary>
        ///   Type of deployment environment where to deploy the project (default: <c>preview</c>).
        /// </summary>
        public virtual string Environment { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("deploy")
              .Add("--app-location {value}", AppLocation)
              .Add("--api-location {value}", ApiLocation)
              .Add("--output-location {value}", OutputLocation)
              .Add("--swa-config-location {value}", ConfigLocation)
              .Add("--deployment-token {value}", DeploymentToken, secret: true)
              .Add("--env {value}", Environment);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region StaticWebAppsStartSettingsExtensions
    /// <summary>
    ///   Used within <see cref="StaticWebAppsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class StaticWebAppsStartSettingsExtensions
    {
        #region AppLocation
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.AppLocation"/></em></p>
        ///   <p>Location for the static app source code (default: <c>./</c>)</p>
        /// </summary>
        [Pure]
        public static T SetAppLocation<T>(this T toolSettings, string appLocation) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppLocation = appLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.AppLocation"/></em></p>
        ///   <p>Location for the static app source code (default: <c>./</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetAppLocation<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppLocation = null;
            return toolSettings;
        }
        #endregion
        #region AppArtifactLocation
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.AppArtifactLocation"/></em></p>
        ///   <p>Location of the build output directory relative to the <c>--app-location</c>. (default: <c>./</c>)</p>
        /// </summary>
        [Pure]
        public static T SetAppArtifactLocation<T>(this T toolSettings, string appArtifactLocation) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppArtifactLocation = appArtifactLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.AppArtifactLocation"/></em></p>
        ///   <p>Location of the build output directory relative to the <c>--app-location</c>. (default: <c>./</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetAppArtifactLocation<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppArtifactLocation = null;
            return toolSettings;
        }
        #endregion
        #region ApiLocation
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.ApiLocation"/></em></p>
        ///   <p>API folder or Azure Functions emulator address</p>
        /// </summary>
        [Pure]
        public static T SetApiLocation<T>(this T toolSettings, string apiLocation) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiLocation = apiLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.ApiLocation"/></em></p>
        ///   <p>API folder or Azure Functions emulator address</p>
        /// </summary>
        [Pure]
        public static T ResetApiLocation<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiLocation = null;
            return toolSettings;
        }
        #endregion
        #region ConfigLocation
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.ConfigLocation"/></em></p>
        ///   <p>Directory where the <em>staticwebapp.config.json</em> file is found (default: <c>./</c>)</p>
        /// </summary>
        [Pure]
        public static T SetConfigLocation<T>(this T toolSettings, string configLocation) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigLocation = configLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.ConfigLocation"/></em></p>
        ///   <p>Directory where the <em>staticwebapp.config.json</em> file is found (default: <c>./</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetConfigLocation<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigLocation = null;
            return toolSettings;
        }
        #endregion
        #region ApiPort
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.ApiPort"/></em></p>
        ///   <p>API backend port (default: <c>7071</c>)</p>
        /// </summary>
        [Pure]
        public static T SetApiPort<T>(this T toolSettings, int? apiPort) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiPort = apiPort;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.ApiPort"/></em></p>
        ///   <p>API backend port (default: <c>7071</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetApiPort<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiPort = null;
            return toolSettings;
        }
        #endregion
        #region Host
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.Host"/></em></p>
        ///   <p>CLI host address (default: <c>localhost</c>)</p>
        /// </summary>
        [Pure]
        public static T SetHost<T>(this T toolSettings, string host) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Host = host;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.Host"/></em></p>
        ///   <p>CLI host address (default: <c>localhost</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetHost<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Host = null;
            return toolSettings;
        }
        #endregion
        #region Port
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.Port"/></em></p>
        ///   <p>CLI port (default: <c>4280</c>)</p>
        /// </summary>
        [Pure]
        public static T SetPort<T>(this T toolSettings, int? port) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = port;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.Port"/></em></p>
        ///   <p>CLI port (default: <c>4280</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetPort<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = null;
            return toolSettings;
        }
        #endregion
        #region Ssl
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.Ssl"/></em></p>
        ///   <p>Serve the app and API over HTTPS (default: <c>false</c>)</p>
        /// </summary>
        [Pure]
        public static T SetSsl<T>(this T toolSettings, bool? ssl) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Ssl = ssl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.Ssl"/></em></p>
        ///   <p>Serve the app and API over HTTPS (default: <c>false</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetSsl<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Ssl = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="StaticWebAppsStartSettings.Ssl"/></em></p>
        ///   <p>Serve the app and API over HTTPS (default: <c>false</c>)</p>
        /// </summary>
        [Pure]
        public static T EnableSsl<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Ssl = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="StaticWebAppsStartSettings.Ssl"/></em></p>
        ///   <p>Serve the app and API over HTTPS (default: <c>false</c>)</p>
        /// </summary>
        [Pure]
        public static T DisableSsl<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Ssl = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="StaticWebAppsStartSettings.Ssl"/></em></p>
        ///   <p>Serve the app and API over HTTPS (default: <c>false</c>)</p>
        /// </summary>
        [Pure]
        public static T ToggleSsl<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Ssl = !toolSettings.Ssl;
            return toolSettings;
        }
        #endregion
        #region SslCertificate
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.SslCertificate"/></em></p>
        ///   <p>SSL certificate (.crt) to use for serving HTTPS</p>
        /// </summary>
        [Pure]
        public static T SetSslCertificate<T>(this T toolSettings, string sslCertificate) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SslCertificate = sslCertificate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.SslCertificate"/></em></p>
        ///   <p>SSL certificate (.crt) to use for serving HTTPS</p>
        /// </summary>
        [Pure]
        public static T ResetSslCertificate<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SslCertificate = null;
            return toolSettings;
        }
        #endregion
        #region SslKey
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.SslKey"/></em></p>
        ///   <p>SSL key (.key) to use for serving HTTPS</p>
        /// </summary>
        [Pure]
        public static T SetSslKey<T>(this T toolSettings, string sslKey) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SslKey = sslKey;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.SslKey"/></em></p>
        ///   <p>SSL key (.key) to use for serving HTTPS</p>
        /// </summary>
        [Pure]
        public static T ResetSslKey<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SslKey = null;
            return toolSettings;
        }
        #endregion
        #region StartupScript
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.StartupScript"/></em></p>
        ///   <p>Run a command at startup</p>
        /// </summary>
        [Pure]
        public static T SetStartupScript<T>(this T toolSettings, string startupScript) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupScript = startupScript;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.StartupScript"/></em></p>
        ///   <p>Run a command at startup</p>
        /// </summary>
        [Pure]
        public static T ResetStartupScript<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupScript = null;
            return toolSettings;
        }
        #endregion
        #region DevServerTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsStartSettings.DevServerTimeout"/></em></p>
        ///   <p>Time to wait(in ms) for the dev server to start (default: <c>30000</c>)</p>
        /// </summary>
        [Pure]
        public static T SetDevServerTimeout<T>(this T toolSettings, int? devServerTimeout) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DevServerTimeout = devServerTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsStartSettings.DevServerTimeout"/></em></p>
        ///   <p>Time to wait(in ms) for the dev server to start (default: <c>30000</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetDevServerTimeout<T>(this T toolSettings) where T : StaticWebAppsStartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DevServerTimeout = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region StaticWebAppsDeploySettingsExtensions
    /// <summary>
    ///   Used within <see cref="StaticWebAppsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class StaticWebAppsDeploySettingsExtensions
    {
        #region AppLocation
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsDeploySettings.AppLocation"/></em></p>
        ///   <p>Directory containing the source code of the front-end application (default: <c>./</c>).</p>
        /// </summary>
        [Pure]
        public static T SetAppLocation<T>(this T toolSettings, string appLocation) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppLocation = appLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsDeploySettings.AppLocation"/></em></p>
        ///   <p>Directory containing the source code of the front-end application (default: <c>./</c>).</p>
        /// </summary>
        [Pure]
        public static T ResetAppLocation<T>(this T toolSettings) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppLocation = null;
            return toolSettings;
        }
        #endregion
        #region ApiLocation
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsDeploySettings.ApiLocation"/></em></p>
        ///   <p>Directory containing the source code of the API application.</p>
        /// </summary>
        [Pure]
        public static T SetApiLocation<T>(this T toolSettings, string apiLocation) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiLocation = apiLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsDeploySettings.ApiLocation"/></em></p>
        ///   <p>Directory containing the source code of the API application.</p>
        /// </summary>
        [Pure]
        public static T ResetApiLocation<T>(this T toolSettings) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiLocation = null;
            return toolSettings;
        }
        #endregion
        #region OutputLocation
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsDeploySettings.OutputLocation"/></em></p>
        ///   <p>Directory containing the built source of the front-end application. The path is relative to <c>--app-location</c> (default: <c>./</c>).</p>
        /// </summary>
        [Pure]
        public static T SetOutputLocation<T>(this T toolSettings, string outputLocation) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputLocation = outputLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsDeploySettings.OutputLocation"/></em></p>
        ///   <p>Directory containing the built source of the front-end application. The path is relative to <c>--app-location</c> (default: <c>./</c>).</p>
        /// </summary>
        [Pure]
        public static T ResetOutputLocation<T>(this T toolSettings) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputLocation = null;
            return toolSettings;
        }
        #endregion
        #region ConfigLocation
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsDeploySettings.ConfigLocation"/></em></p>
        ///   <p>Directory where the <em>staticwebapp.config.json</em> file is found (default: <c>./</c>)</p>
        /// </summary>
        [Pure]
        public static T SetConfigLocation<T>(this T toolSettings, string configLocation) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigLocation = configLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsDeploySettings.ConfigLocation"/></em></p>
        ///   <p>Directory where the <em>staticwebapp.config.json</em> file is found (default: <c>./</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetConfigLocation<T>(this T toolSettings) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigLocation = null;
            return toolSettings;
        }
        #endregion
        #region DeploymentToken
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsDeploySettings.DeploymentToken"/></em></p>
        ///   <p>Secret token used to authenticate with the Static Web Apps</p>
        /// </summary>
        [Pure]
        public static T SetDeploymentToken<T>(this T toolSettings, [Secret] string deploymentToken) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentToken = deploymentToken;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsDeploySettings.DeploymentToken"/></em></p>
        ///   <p>Secret token used to authenticate with the Static Web Apps</p>
        /// </summary>
        [Pure]
        public static T ResetDeploymentToken<T>(this T toolSettings) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeploymentToken = null;
            return toolSettings;
        }
        #endregion
        #region Environment
        /// <summary>
        ///   <p><em>Sets <see cref="StaticWebAppsDeploySettings.Environment"/></em></p>
        ///   <p>Type of deployment environment where to deploy the project (default: <c>preview</c>).</p>
        /// </summary>
        [Pure]
        public static T SetEnvironment<T>(this T toolSettings, string environment) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Environment = environment;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="StaticWebAppsDeploySettings.Environment"/></em></p>
        ///   <p>Type of deployment environment where to deploy the project (default: <c>preview</c>).</p>
        /// </summary>
        [Pure]
        public static T ResetEnvironment<T>(this T toolSettings) where T : StaticWebAppsDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Environment = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
