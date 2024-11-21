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

namespace Nuke.Common.Tools.StaticWebApps;

/// <summary><p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NpmPackageRequirement(PackageId)]
public partial class StaticWebAppsTasks : ToolTasks, IRequireNpmPackage
{
    public static string StaticWebAppsPath => new StaticWebAppsTasks().GetToolPath();
    public const string PackageExecutable = "swa";
    public const string PackageId = "@azure/static-web-apps-cli";
    /// <summary><p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> StaticWebApps(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new StaticWebAppsTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--api-location</c> via <see cref="StaticWebAppsStartSettings.ApiLocation"/></li><li><c>--api-port</c> via <see cref="StaticWebAppsStartSettings.ApiPort"/></li><li><c>--app-artifact-location</c> via <see cref="StaticWebAppsStartSettings.AppArtifactLocation"/></li><li><c>--app-location</c> via <see cref="StaticWebAppsStartSettings.AppLocation"/></li><li><c>--devserver-timeout</c> via <see cref="StaticWebAppsStartSettings.DevServerTimeout"/></li><li><c>--host</c> via <see cref="StaticWebAppsStartSettings.Host"/></li><li><c>--port</c> via <see cref="StaticWebAppsStartSettings.Port"/></li><li><c>--run</c> via <see cref="StaticWebAppsStartSettings.StartupScript"/></li><li><c>--ssl</c> via <see cref="StaticWebAppsStartSettings.Ssl"/></li><li><c>--ssl-cert</c> via <see cref="StaticWebAppsStartSettings.SslCertificate"/></li><li><c>--ssl-key</c> via <see cref="StaticWebAppsStartSettings.SslKey"/></li><li><c>--swa-config-location</c> via <see cref="StaticWebAppsStartSettings.ConfigLocation"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> StaticWebAppsStart(StaticWebAppsStartSettings options = null) => new StaticWebAppsTasks().Run(options);
    /// <summary><p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--api-location</c> via <see cref="StaticWebAppsStartSettings.ApiLocation"/></li><li><c>--api-port</c> via <see cref="StaticWebAppsStartSettings.ApiPort"/></li><li><c>--app-artifact-location</c> via <see cref="StaticWebAppsStartSettings.AppArtifactLocation"/></li><li><c>--app-location</c> via <see cref="StaticWebAppsStartSettings.AppLocation"/></li><li><c>--devserver-timeout</c> via <see cref="StaticWebAppsStartSettings.DevServerTimeout"/></li><li><c>--host</c> via <see cref="StaticWebAppsStartSettings.Host"/></li><li><c>--port</c> via <see cref="StaticWebAppsStartSettings.Port"/></li><li><c>--run</c> via <see cref="StaticWebAppsStartSettings.StartupScript"/></li><li><c>--ssl</c> via <see cref="StaticWebAppsStartSettings.Ssl"/></li><li><c>--ssl-cert</c> via <see cref="StaticWebAppsStartSettings.SslCertificate"/></li><li><c>--ssl-key</c> via <see cref="StaticWebAppsStartSettings.SslKey"/></li><li><c>--swa-config-location</c> via <see cref="StaticWebAppsStartSettings.ConfigLocation"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> StaticWebAppsStart(Configure<StaticWebAppsStartSettings> configurator) => new StaticWebAppsTasks().Run(configurator.Invoke(new StaticWebAppsStartSettings()));
    /// <summary><p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--api-location</c> via <see cref="StaticWebAppsStartSettings.ApiLocation"/></li><li><c>--api-port</c> via <see cref="StaticWebAppsStartSettings.ApiPort"/></li><li><c>--app-artifact-location</c> via <see cref="StaticWebAppsStartSettings.AppArtifactLocation"/></li><li><c>--app-location</c> via <see cref="StaticWebAppsStartSettings.AppLocation"/></li><li><c>--devserver-timeout</c> via <see cref="StaticWebAppsStartSettings.DevServerTimeout"/></li><li><c>--host</c> via <see cref="StaticWebAppsStartSettings.Host"/></li><li><c>--port</c> via <see cref="StaticWebAppsStartSettings.Port"/></li><li><c>--run</c> via <see cref="StaticWebAppsStartSettings.StartupScript"/></li><li><c>--ssl</c> via <see cref="StaticWebAppsStartSettings.Ssl"/></li><li><c>--ssl-cert</c> via <see cref="StaticWebAppsStartSettings.SslCertificate"/></li><li><c>--ssl-key</c> via <see cref="StaticWebAppsStartSettings.SslKey"/></li><li><c>--swa-config-location</c> via <see cref="StaticWebAppsStartSettings.ConfigLocation"/></li></ul></remarks>
    public static IEnumerable<(StaticWebAppsStartSettings Settings, IReadOnlyCollection<Output> Output)> StaticWebAppsStart(CombinatorialConfigure<StaticWebAppsStartSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(StaticWebAppsStart, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--api-location</c> via <see cref="StaticWebAppsDeploySettings.ApiLocation"/></li><li><c>--app-location</c> via <see cref="StaticWebAppsDeploySettings.AppLocation"/></li><li><c>--deployment-token</c> via <see cref="StaticWebAppsDeploySettings.DeploymentToken"/></li><li><c>--env</c> via <see cref="StaticWebAppsDeploySettings.Environment"/></li><li><c>--output-location</c> via <see cref="StaticWebAppsDeploySettings.OutputLocation"/></li><li><c>--swa-config-location</c> via <see cref="StaticWebAppsDeploySettings.ConfigLocation"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> StaticWebAppsDeploy(StaticWebAppsDeploySettings options = null) => new StaticWebAppsTasks().Run(options);
    /// <summary><p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--api-location</c> via <see cref="StaticWebAppsDeploySettings.ApiLocation"/></li><li><c>--app-location</c> via <see cref="StaticWebAppsDeploySettings.AppLocation"/></li><li><c>--deployment-token</c> via <see cref="StaticWebAppsDeploySettings.DeploymentToken"/></li><li><c>--env</c> via <see cref="StaticWebAppsDeploySettings.Environment"/></li><li><c>--output-location</c> via <see cref="StaticWebAppsDeploySettings.OutputLocation"/></li><li><c>--swa-config-location</c> via <see cref="StaticWebAppsDeploySettings.ConfigLocation"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> StaticWebAppsDeploy(Configure<StaticWebAppsDeploySettings> configurator) => new StaticWebAppsTasks().Run(configurator.Invoke(new StaticWebAppsDeploySettings()));
    /// <summary><p>The Static Web Apps CLI, also known as SWA CLI, serves as a local development tool for <a href="https://docs.microsoft.com/azure/static-web-apps">Azure Static Web Apps</a>. It can:<ul><li>Serve static app assets, or proxy to your app dev server</li><li>Serve API requests, or proxy to APIs running in Azure Functions Core Tools</li><li>Emulate authentication and authorization</li><li>Emulate Static Web Apps configuration, including routing</li></ul></p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/azure/static-web-apps/local-development">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--api-location</c> via <see cref="StaticWebAppsDeploySettings.ApiLocation"/></li><li><c>--app-location</c> via <see cref="StaticWebAppsDeploySettings.AppLocation"/></li><li><c>--deployment-token</c> via <see cref="StaticWebAppsDeploySettings.DeploymentToken"/></li><li><c>--env</c> via <see cref="StaticWebAppsDeploySettings.Environment"/></li><li><c>--output-location</c> via <see cref="StaticWebAppsDeploySettings.OutputLocation"/></li><li><c>--swa-config-location</c> via <see cref="StaticWebAppsDeploySettings.ConfigLocation"/></li></ul></remarks>
    public static IEnumerable<(StaticWebAppsDeploySettings Settings, IReadOnlyCollection<Output> Output)> StaticWebAppsDeploy(CombinatorialConfigure<StaticWebAppsDeploySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(StaticWebAppsDeploy, degreeOfParallelism, completeOnFailure);
}
#region StaticWebAppsStartSettings
/// <summary>Used within <see cref="StaticWebAppsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<StaticWebAppsStartSettings>))]
[Command(Type = typeof(StaticWebAppsTasks), Command = nameof(StaticWebAppsTasks.StaticWebAppsStart), Arguments = "start")]
public partial class StaticWebAppsStartSettings : ToolOptions
{
    /// <summary>Location for the static app source code (default: <c>./</c>)</summary>
    [Argument(Format = "--app-location {value}")] public string AppLocation => Get<string>(() => AppLocation);
    /// <summary>Location of the build output directory relative to the <c>--app-location</c>. (default: <c>./</c>)</summary>
    [Argument(Format = "--app-artifact-location {value}")] public string AppArtifactLocation => Get<string>(() => AppArtifactLocation);
    /// <summary>API folder or Azure Functions emulator address</summary>
    [Argument(Format = "--api-location {value}")] public string ApiLocation => Get<string>(() => ApiLocation);
    /// <summary>Directory where the <em>staticwebapp.config.json</em> file is found (default: <c>./</c>)</summary>
    [Argument(Format = "--swa-config-location {value}")] public string ConfigLocation => Get<string>(() => ConfigLocation);
    /// <summary>API backend port (default: <c>7071</c>)</summary>
    [Argument(Format = "--api-port {value}")] public int? ApiPort => Get<int?>(() => ApiPort);
    /// <summary>CLI host address (default: <c>localhost</c>)</summary>
    [Argument(Format = "--host {value}")] public string Host => Get<string>(() => Host);
    /// <summary>CLI port (default: <c>4280</c>)</summary>
    [Argument(Format = "--port {value}")] public int? Port => Get<int?>(() => Port);
    /// <summary>Serve the app and API over HTTPS (default: <c>false</c>)</summary>
    [Argument(Format = "--ssl")] public bool? Ssl => Get<bool?>(() => Ssl);
    /// <summary>SSL certificate (.crt) to use for serving HTTPS</summary>
    [Argument(Format = "--ssl-cert {value}")] public string SslCertificate => Get<string>(() => SslCertificate);
    /// <summary>SSL key (.key) to use for serving HTTPS</summary>
    [Argument(Format = "--ssl-key {value}")] public string SslKey => Get<string>(() => SslKey);
    /// <summary>Run a command at startup</summary>
    [Argument(Format = "--run {value}")] public string StartupScript => Get<string>(() => StartupScript);
    /// <summary>Time to wait(in ms) for the dev server to start (default: <c>30000</c>)</summary>
    [Argument(Format = "--devserver-timeout {value}")] public int? DevServerTimeout => Get<int?>(() => DevServerTimeout);
}
#endregion
#region StaticWebAppsDeploySettings
/// <summary>Used within <see cref="StaticWebAppsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<StaticWebAppsDeploySettings>))]
[Command(Type = typeof(StaticWebAppsTasks), Command = nameof(StaticWebAppsTasks.StaticWebAppsDeploy), Arguments = "deploy")]
public partial class StaticWebAppsDeploySettings : ToolOptions
{
    /// <summary>Directory containing the source code of the front-end application (default: <c>./</c>).</summary>
    [Argument(Format = "--app-location {value}")] public string AppLocation => Get<string>(() => AppLocation);
    /// <summary>Directory containing the source code of the API application.</summary>
    [Argument(Format = "--api-location {value}")] public string ApiLocation => Get<string>(() => ApiLocation);
    /// <summary>Directory containing the built source of the front-end application. The path is relative to <c>--app-location</c> (default: <c>./</c>).</summary>
    [Argument(Format = "--output-location {value}")] public string OutputLocation => Get<string>(() => OutputLocation);
    /// <summary>Directory where the <em>staticwebapp.config.json</em> file is found (default: <c>./</c>)</summary>
    [Argument(Format = "--swa-config-location {value}")] public string ConfigLocation => Get<string>(() => ConfigLocation);
    /// <summary>Secret token used to authenticate with the Static Web Apps</summary>
    [Argument(Format = "--deployment-token {value}", Secret = true)] public string DeploymentToken => Get<string>(() => DeploymentToken);
    /// <summary>Type of deployment environment where to deploy the project (default: <c>preview</c>).</summary>
    [Argument(Format = "--env {value}")] public string Environment => Get<string>(() => Environment);
}
#endregion
#region StaticWebAppsStartSettingsExtensions
/// <summary>Used within <see cref="StaticWebAppsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class StaticWebAppsStartSettingsExtensions
{
    #region AppLocation
    /// <inheritdoc cref="StaticWebAppsStartSettings.AppLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.AppLocation))]
    public static T SetAppLocation<T>(this T o, string v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.AppLocation, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.AppLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.AppLocation))]
    public static T ResetAppLocation<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.AppLocation));
    #endregion
    #region AppArtifactLocation
    /// <inheritdoc cref="StaticWebAppsStartSettings.AppArtifactLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.AppArtifactLocation))]
    public static T SetAppArtifactLocation<T>(this T o, string v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.AppArtifactLocation, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.AppArtifactLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.AppArtifactLocation))]
    public static T ResetAppArtifactLocation<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.AppArtifactLocation));
    #endregion
    #region ApiLocation
    /// <inheritdoc cref="StaticWebAppsStartSettings.ApiLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.ApiLocation))]
    public static T SetApiLocation<T>(this T o, string v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.ApiLocation, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.ApiLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.ApiLocation))]
    public static T ResetApiLocation<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.ApiLocation));
    #endregion
    #region ConfigLocation
    /// <inheritdoc cref="StaticWebAppsStartSettings.ConfigLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.ConfigLocation))]
    public static T SetConfigLocation<T>(this T o, string v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.ConfigLocation, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.ConfigLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.ConfigLocation))]
    public static T ResetConfigLocation<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.ConfigLocation));
    #endregion
    #region ApiPort
    /// <inheritdoc cref="StaticWebAppsStartSettings.ApiPort"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.ApiPort))]
    public static T SetApiPort<T>(this T o, int? v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.ApiPort, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.ApiPort"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.ApiPort))]
    public static T ResetApiPort<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.ApiPort));
    #endregion
    #region Host
    /// <inheritdoc cref="StaticWebAppsStartSettings.Host"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.Host))]
    public static T SetHost<T>(this T o, string v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.Host, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.Host"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.Host))]
    public static T ResetHost<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.Host));
    #endregion
    #region Port
    /// <inheritdoc cref="StaticWebAppsStartSettings.Port"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.Port))]
    public static T SetPort<T>(this T o, int? v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.Port, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.Port"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.Port))]
    public static T ResetPort<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.Port));
    #endregion
    #region Ssl
    /// <inheritdoc cref="StaticWebAppsStartSettings.Ssl"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.Ssl))]
    public static T SetSsl<T>(this T o, bool? v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.Ssl, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.Ssl"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.Ssl))]
    public static T ResetSsl<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.Ssl));
    /// <inheritdoc cref="StaticWebAppsStartSettings.Ssl"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.Ssl))]
    public static T EnableSsl<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.Ssl, true));
    /// <inheritdoc cref="StaticWebAppsStartSettings.Ssl"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.Ssl))]
    public static T DisableSsl<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.Ssl, false));
    /// <inheritdoc cref="StaticWebAppsStartSettings.Ssl"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.Ssl))]
    public static T ToggleSsl<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.Ssl, !o.Ssl));
    #endregion
    #region SslCertificate
    /// <inheritdoc cref="StaticWebAppsStartSettings.SslCertificate"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.SslCertificate))]
    public static T SetSslCertificate<T>(this T o, string v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.SslCertificate, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.SslCertificate"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.SslCertificate))]
    public static T ResetSslCertificate<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.SslCertificate));
    #endregion
    #region SslKey
    /// <inheritdoc cref="StaticWebAppsStartSettings.SslKey"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.SslKey))]
    public static T SetSslKey<T>(this T o, string v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.SslKey, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.SslKey"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.SslKey))]
    public static T ResetSslKey<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.SslKey));
    #endregion
    #region StartupScript
    /// <inheritdoc cref="StaticWebAppsStartSettings.StartupScript"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.StartupScript))]
    public static T SetStartupScript<T>(this T o, string v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.StartupScript, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.StartupScript"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.StartupScript))]
    public static T ResetStartupScript<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.StartupScript));
    #endregion
    #region DevServerTimeout
    /// <inheritdoc cref="StaticWebAppsStartSettings.DevServerTimeout"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.DevServerTimeout))]
    public static T SetDevServerTimeout<T>(this T o, int? v) where T : StaticWebAppsStartSettings => o.Modify(b => b.Set(() => o.DevServerTimeout, v));
    /// <inheritdoc cref="StaticWebAppsStartSettings.DevServerTimeout"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsStartSettings), Property = nameof(StaticWebAppsStartSettings.DevServerTimeout))]
    public static T ResetDevServerTimeout<T>(this T o) where T : StaticWebAppsStartSettings => o.Modify(b => b.Remove(() => o.DevServerTimeout));
    #endregion
}
#endregion
#region StaticWebAppsDeploySettingsExtensions
/// <summary>Used within <see cref="StaticWebAppsTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class StaticWebAppsDeploySettingsExtensions
{
    #region AppLocation
    /// <inheritdoc cref="StaticWebAppsDeploySettings.AppLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.AppLocation))]
    public static T SetAppLocation<T>(this T o, string v) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Set(() => o.AppLocation, v));
    /// <inheritdoc cref="StaticWebAppsDeploySettings.AppLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.AppLocation))]
    public static T ResetAppLocation<T>(this T o) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Remove(() => o.AppLocation));
    #endregion
    #region ApiLocation
    /// <inheritdoc cref="StaticWebAppsDeploySettings.ApiLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.ApiLocation))]
    public static T SetApiLocation<T>(this T o, string v) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Set(() => o.ApiLocation, v));
    /// <inheritdoc cref="StaticWebAppsDeploySettings.ApiLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.ApiLocation))]
    public static T ResetApiLocation<T>(this T o) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Remove(() => o.ApiLocation));
    #endregion
    #region OutputLocation
    /// <inheritdoc cref="StaticWebAppsDeploySettings.OutputLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.OutputLocation))]
    public static T SetOutputLocation<T>(this T o, string v) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Set(() => o.OutputLocation, v));
    /// <inheritdoc cref="StaticWebAppsDeploySettings.OutputLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.OutputLocation))]
    public static T ResetOutputLocation<T>(this T o) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Remove(() => o.OutputLocation));
    #endregion
    #region ConfigLocation
    /// <inheritdoc cref="StaticWebAppsDeploySettings.ConfigLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.ConfigLocation))]
    public static T SetConfigLocation<T>(this T o, string v) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Set(() => o.ConfigLocation, v));
    /// <inheritdoc cref="StaticWebAppsDeploySettings.ConfigLocation"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.ConfigLocation))]
    public static T ResetConfigLocation<T>(this T o) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Remove(() => o.ConfigLocation));
    #endregion
    #region DeploymentToken
    /// <inheritdoc cref="StaticWebAppsDeploySettings.DeploymentToken"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.DeploymentToken))]
    public static T SetDeploymentToken<T>(this T o, [Secret] string v) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Set(() => o.DeploymentToken, v));
    /// <inheritdoc cref="StaticWebAppsDeploySettings.DeploymentToken"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.DeploymentToken))]
    public static T ResetDeploymentToken<T>(this T o) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Remove(() => o.DeploymentToken));
    #endregion
    #region Environment
    /// <inheritdoc cref="StaticWebAppsDeploySettings.Environment"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.Environment))]
    public static T SetEnvironment<T>(this T o, string v) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Set(() => o.Environment, v));
    /// <inheritdoc cref="StaticWebAppsDeploySettings.Environment"/>
    [Pure] [Builder(Type = typeof(StaticWebAppsDeploySettings), Property = nameof(StaticWebAppsDeploySettings.Environment))]
    public static T ResetEnvironment<T>(this T o) where T : StaticWebAppsDeploySettings => o.Modify(b => b.Remove(() => o.Environment));
    #endregion
}
#endregion
