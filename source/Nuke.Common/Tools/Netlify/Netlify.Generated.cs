// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Netlify/Netlify.json

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

namespace Nuke.Common.Tools.Netlify;

/// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathToolRequirement(PathExecutable)]
[PathTool(Executable = PathExecutable)]
public partial class NetlifyTasks : ToolTasks, IRequirePathTool
{
    public static string NetlifyPath => new NetlifyTasks().GetToolPath();
    public const string PathExecutable = "npx";
    /// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Netlify(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new NetlifyTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--alias</c> via <see cref="NetlifyDeploySettings.Alias"/></li><li><c>--auth</c> via <see cref="NetlifyDeploySettings.Auth"/></li><li><c>--branch</c> via <see cref="NetlifyDeploySettings.Branch"/></li><li><c>--build</c> via <see cref="NetlifyDeploySettings.Build"/></li><li><c>--debug</c> via <see cref="NetlifyDeploySettings.Debug"/></li><li><c>--dir</c> via <see cref="NetlifyDeploySettings.Directory"/></li><li><c>--functions</c> via <see cref="NetlifyDeploySettings.Functions"/></li><li><c>--httpProxy</c> via <see cref="NetlifyDeploySettings.HttpProxy"/></li><li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifyDeploySettings.HttpProxyCertificateFileName"/></li><li><c>--json</c> via <see cref="NetlifyDeploySettings.Json"/></li><li><c>--message</c> via <see cref="NetlifyDeploySettings.Message"/></li><li><c>--open</c> via <see cref="NetlifyDeploySettings.Open"/></li><li><c>--prod</c> via <see cref="NetlifyDeploySettings.Production"/></li><li><c>--prodIfUnlocked</c> via <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></li><li><c>--site</c> via <see cref="NetlifyDeploySettings.Site"/></li><li><c>--timeout</c> via <see cref="NetlifyDeploySettings.Timeout"/></li><li><c>--trigger</c> via <see cref="NetlifyDeploySettings.Trigger"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NetlifyDeploy(NetlifyDeploySettings options = null) => new NetlifyTasks().Run(options);
    /// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--alias</c> via <see cref="NetlifyDeploySettings.Alias"/></li><li><c>--auth</c> via <see cref="NetlifyDeploySettings.Auth"/></li><li><c>--branch</c> via <see cref="NetlifyDeploySettings.Branch"/></li><li><c>--build</c> via <see cref="NetlifyDeploySettings.Build"/></li><li><c>--debug</c> via <see cref="NetlifyDeploySettings.Debug"/></li><li><c>--dir</c> via <see cref="NetlifyDeploySettings.Directory"/></li><li><c>--functions</c> via <see cref="NetlifyDeploySettings.Functions"/></li><li><c>--httpProxy</c> via <see cref="NetlifyDeploySettings.HttpProxy"/></li><li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifyDeploySettings.HttpProxyCertificateFileName"/></li><li><c>--json</c> via <see cref="NetlifyDeploySettings.Json"/></li><li><c>--message</c> via <see cref="NetlifyDeploySettings.Message"/></li><li><c>--open</c> via <see cref="NetlifyDeploySettings.Open"/></li><li><c>--prod</c> via <see cref="NetlifyDeploySettings.Production"/></li><li><c>--prodIfUnlocked</c> via <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></li><li><c>--site</c> via <see cref="NetlifyDeploySettings.Site"/></li><li><c>--timeout</c> via <see cref="NetlifyDeploySettings.Timeout"/></li><li><c>--trigger</c> via <see cref="NetlifyDeploySettings.Trigger"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NetlifyDeploy(Configure<NetlifyDeploySettings> configurator) => new NetlifyTasks().Run(configurator.Invoke(new NetlifyDeploySettings()));
    /// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--alias</c> via <see cref="NetlifyDeploySettings.Alias"/></li><li><c>--auth</c> via <see cref="NetlifyDeploySettings.Auth"/></li><li><c>--branch</c> via <see cref="NetlifyDeploySettings.Branch"/></li><li><c>--build</c> via <see cref="NetlifyDeploySettings.Build"/></li><li><c>--debug</c> via <see cref="NetlifyDeploySettings.Debug"/></li><li><c>--dir</c> via <see cref="NetlifyDeploySettings.Directory"/></li><li><c>--functions</c> via <see cref="NetlifyDeploySettings.Functions"/></li><li><c>--httpProxy</c> via <see cref="NetlifyDeploySettings.HttpProxy"/></li><li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifyDeploySettings.HttpProxyCertificateFileName"/></li><li><c>--json</c> via <see cref="NetlifyDeploySettings.Json"/></li><li><c>--message</c> via <see cref="NetlifyDeploySettings.Message"/></li><li><c>--open</c> via <see cref="NetlifyDeploySettings.Open"/></li><li><c>--prod</c> via <see cref="NetlifyDeploySettings.Production"/></li><li><c>--prodIfUnlocked</c> via <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></li><li><c>--site</c> via <see cref="NetlifyDeploySettings.Site"/></li><li><c>--timeout</c> via <see cref="NetlifyDeploySettings.Timeout"/></li><li><c>--trigger</c> via <see cref="NetlifyDeploySettings.Trigger"/></li></ul></remarks>
    public static IEnumerable<(NetlifyDeploySettings Settings, IReadOnlyCollection<Output> Output)> NetlifyDeploy(CombinatorialConfigure<NetlifyDeploySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NetlifyDeploy, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--account-slug</c> via <see cref="NetlifySitesCreateSettings.AccountSlug"/></li><li><c>--debug</c> via <see cref="NetlifySitesCreateSettings.Debug"/></li><li><c>--httpProxy</c> via <see cref="NetlifySitesCreateSettings.HttpProxy"/></li><li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesCreateSettings.HttpProxyCertificateFileName"/></li><li><c>--manual</c> via <see cref="NetlifySitesCreateSettings.Manual"/></li><li><c>--name</c> via <see cref="NetlifySitesCreateSettings.Name"/></li><li><c>--with-ci</c> via <see cref="NetlifySitesCreateSettings.WithCI"/></li></ul></remarks>
    public static (string Result, IReadOnlyCollection<Output> Output) NetlifySitesCreate(NetlifySitesCreateSettings options = null) => new NetlifyTasks().Run<string>(options);
    /// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--account-slug</c> via <see cref="NetlifySitesCreateSettings.AccountSlug"/></li><li><c>--debug</c> via <see cref="NetlifySitesCreateSettings.Debug"/></li><li><c>--httpProxy</c> via <see cref="NetlifySitesCreateSettings.HttpProxy"/></li><li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesCreateSettings.HttpProxyCertificateFileName"/></li><li><c>--manual</c> via <see cref="NetlifySitesCreateSettings.Manual"/></li><li><c>--name</c> via <see cref="NetlifySitesCreateSettings.Name"/></li><li><c>--with-ci</c> via <see cref="NetlifySitesCreateSettings.WithCI"/></li></ul></remarks>
    public static (string Result, IReadOnlyCollection<Output> Output) NetlifySitesCreate(Configure<NetlifySitesCreateSettings> configurator) => new NetlifyTasks().Run<string>(configurator.Invoke(new NetlifySitesCreateSettings()));
    /// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--account-slug</c> via <see cref="NetlifySitesCreateSettings.AccountSlug"/></li><li><c>--debug</c> via <see cref="NetlifySitesCreateSettings.Debug"/></li><li><c>--httpProxy</c> via <see cref="NetlifySitesCreateSettings.HttpProxy"/></li><li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesCreateSettings.HttpProxyCertificateFileName"/></li><li><c>--manual</c> via <see cref="NetlifySitesCreateSettings.Manual"/></li><li><c>--name</c> via <see cref="NetlifySitesCreateSettings.Name"/></li><li><c>--with-ci</c> via <see cref="NetlifySitesCreateSettings.WithCI"/></li></ul></remarks>
    public static IEnumerable<(NetlifySitesCreateSettings Settings, string Result, IReadOnlyCollection<Output> Output)> NetlifySitesCreate(CombinatorialConfigure<NetlifySitesCreateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NetlifySitesCreate, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;siteId&gt;</c> via <see cref="NetlifySitesDeleteSettings.SiteId"/></li><li><c>--debug</c> via <see cref="NetlifySitesDeleteSettings.Debug"/></li><li><c>--force</c> via <see cref="NetlifySitesDeleteSettings.Force"/></li><li><c>--httpProxy</c> via <see cref="NetlifySitesDeleteSettings.HttpProxy"/></li><li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesDeleteSettings.HttpProxyCertificateFileName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NetlifySitesDelete(NetlifySitesDeleteSettings options = null) => new NetlifyTasks().Run(options);
    /// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;siteId&gt;</c> via <see cref="NetlifySitesDeleteSettings.SiteId"/></li><li><c>--debug</c> via <see cref="NetlifySitesDeleteSettings.Debug"/></li><li><c>--force</c> via <see cref="NetlifySitesDeleteSettings.Force"/></li><li><c>--httpProxy</c> via <see cref="NetlifySitesDeleteSettings.HttpProxy"/></li><li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesDeleteSettings.HttpProxyCertificateFileName"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> NetlifySitesDelete(Configure<NetlifySitesDeleteSettings> configurator) => new NetlifyTasks().Run(configurator.Invoke(new NetlifySitesDeleteSettings()));
    /// <summary><p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p><p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;siteId&gt;</c> via <see cref="NetlifySitesDeleteSettings.SiteId"/></li><li><c>--debug</c> via <see cref="NetlifySitesDeleteSettings.Debug"/></li><li><c>--force</c> via <see cref="NetlifySitesDeleteSettings.Force"/></li><li><c>--httpProxy</c> via <see cref="NetlifySitesDeleteSettings.HttpProxy"/></li><li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesDeleteSettings.HttpProxyCertificateFileName"/></li></ul></remarks>
    public static IEnumerable<(NetlifySitesDeleteSettings Settings, IReadOnlyCollection<Output> Output)> NetlifySitesDelete(CombinatorialConfigure<NetlifySitesDeleteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(NetlifySitesDelete, degreeOfParallelism, completeOnFailure);
}
#region NetlifyDeploySettings
/// <summary>Used within <see cref="NetlifyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NetlifyDeploySettings>))]
[Command(Type = typeof(NetlifyTasks), Command = nameof(NetlifyTasks.NetlifyDeploy), Arguments = "netlify deploy")]
public partial class NetlifyDeploySettings : ToolOptions
{
    /// <summary>Specify a folder to deploy.</summary>
    [Argument(Format = "--dir {value}")] public string Directory => Get<string>(() => Directory);
    /// <summary>Specify a functions folder to deploy.</summary>
    [Argument(Format = "--functions {value}")] public string Functions => Get<string>(() => Functions);
    /// <summary>Deploy to production.</summary>
    [Argument(Format = "--prod")] public bool? Production => Get<bool?>(() => Production);
    /// <summary>Deploy to production if unlocked, create a draft otherwise.</summary>
    [Argument(Format = "--prodIfUnlocked")] public bool? ProductionIfUnlocked => Get<bool?>(() => ProductionIfUnlocked);
    /// <summary>Specifies the alias for deployment, the string at the beginning of the deploy subdomain. Useful for creating predictable deployment URLs. Avoid setting an alias string to the same value as a deployed branch. <code>alias doesn’t</code> create a branch deploy and can’t be used in conjunction with the branch subdomain feature. Maximum 37 characters.</summary>
    [Argument(Format = "--alias {value}")] public string Alias => Get<string>(() => Alias);
    /// <summary>Serves the same functionality as --alias. Deprecated and will be removed in future versions.</summary>
    [Argument(Format = "--branch {value}")] public string Branch => Get<string>(() => Branch);
    /// <summary>Open site after deploy.</summary>
    [Argument(Format = "--open")] public bool? Open => Get<bool?>(() => Open);
    /// <summary>A short message to include in the deploy log.</summary>
    [Argument(Format = "--message {value}")] public string Message => Get<string>(() => Message);
    /// <summary>Netlify auth token to deploy with.</summary>
    [Argument(Format = "--auth {value}", Secret = true)] public string Auth => Get<string>(() => Auth);
    /// <summary>Netlify auth token to deploy with.</summary>
    [Argument(Format = "--site {value}")] public string Site => Get<string>(() => Site);
    /// <summary>Output deployment data as JSON.</summary>
    [Argument(Format = "--json")] public bool? Json => Get<bool?>(() => Json);
    /// <summary>Timeout to wait for deployment to finish.</summary>
    [Argument(Format = "--timeout {value}")] public string Timeout => Get<string>(() => Timeout);
    /// <summary>Trigger a new build of your site on Netlify without uploading local files.</summary>
    [Argument(Format = "--trigger")] public bool? Trigger => Get<bool?>(() => Trigger);
    /// <summary>Run build command before deploying.</summary>
    [Argument(Format = "--build")] public bool? Build => Get<bool?>(() => Build);
    /// <summary>Print debugging information.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Proxy server address to route requests through.</summary>
    [Argument(Format = "--httpProxy {value}")] public string HttpProxy => Get<string>(() => HttpProxy);
    /// <summary>Certificate file to use when connecting using a proxy server.</summary>
    [Argument(Format = "--httpProxyCertificateFilename {value}")] public string HttpProxyCertificateFileName => Get<string>(() => HttpProxyCertificateFileName);
}
#endregion
#region NetlifySitesCreateSettings
/// <summary>Used within <see cref="NetlifyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NetlifySitesCreateSettings>))]
[Command(Type = typeof(NetlifyTasks), Command = nameof(NetlifyTasks.NetlifySitesCreate), Arguments = "netlify sites:create")]
public partial class NetlifySitesCreateSettings : ToolOptions
{
    /// <summary>Name of site.</summary>
    [Argument(Format = "--name {value}")] public string Name => Get<string>(() => Name);
    /// <summary>Account slug to create the site under.</summary>
    [Argument(Format = "--account-slug {value}")] public string AccountSlug => Get<string>(() => AccountSlug);
    /// <summary>Initialize CI hooks during site creation.</summary>
    [Argument(Format = "--with-ci")] public bool? WithCI => Get<bool?>(() => WithCI);
    /// <summary>Force manual CI setup. Used <code>--with-ci</code> flag.</summary>
    [Argument(Format = "--manual")] public bool? Manual => Get<bool?>(() => Manual);
    /// <summary>Print debugging information.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Proxy server address to route requests through.</summary>
    [Argument(Format = "--httpProxy {value}")] public string HttpProxy => Get<string>(() => HttpProxy);
    /// <summary>Certificate file to use when connecting using a proxy server.</summary>
    [Argument(Format = "--httpProxyCertificateFilename {value}")] public string HttpProxyCertificateFileName => Get<string>(() => HttpProxyCertificateFileName);
}
#endregion
#region NetlifySitesDeleteSettings
/// <summary>Used within <see cref="NetlifyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<NetlifySitesDeleteSettings>))]
[Command(Type = typeof(NetlifyTasks), Command = nameof(NetlifyTasks.NetlifySitesDelete), Arguments = "netlify sites:delete")]
public partial class NetlifySitesDeleteSettings : ToolOptions
{
    /// <summary>Site ID to delete.</summary>
    [Argument(Format = "{value}", Position = 1)] public string SiteId => Get<string>(() => SiteId);
    /// <summary>Delete without prompting (useful for CI).</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Print debugging information.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Proxy server address to route requests through.</summary>
    [Argument(Format = "--httpProxy {value}")] public string HttpProxy => Get<string>(() => HttpProxy);
    /// <summary>Certificate file to use when connecting using a proxy server.</summary>
    [Argument(Format = "--httpProxyCertificateFilename {value}")] public string HttpProxyCertificateFileName => Get<string>(() => HttpProxyCertificateFileName);
}
#endregion
#region NetlifyDeploySettingsExtensions
/// <summary>Used within <see cref="NetlifyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NetlifyDeploySettingsExtensions
{
    #region Directory
    /// <inheritdoc cref="NetlifyDeploySettings.Directory"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Directory))]
    public static T SetDirectory<T>(this T o, string v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Directory, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Directory"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Directory))]
    public static T ResetDirectory<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Directory));
    #endregion
    #region Functions
    /// <inheritdoc cref="NetlifyDeploySettings.Functions"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Functions))]
    public static T SetFunctions<T>(this T o, string v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Functions, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Functions"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Functions))]
    public static T ResetFunctions<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Functions));
    #endregion
    #region Production
    /// <inheritdoc cref="NetlifyDeploySettings.Production"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Production))]
    public static T SetProduction<T>(this T o, bool? v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Production, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Production"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Production))]
    public static T ResetProduction<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Production));
    /// <inheritdoc cref="NetlifyDeploySettings.Production"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Production))]
    public static T EnableProduction<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Production, true));
    /// <inheritdoc cref="NetlifyDeploySettings.Production"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Production))]
    public static T DisableProduction<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Production, false));
    /// <inheritdoc cref="NetlifyDeploySettings.Production"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Production))]
    public static T ToggleProduction<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Production, !o.Production));
    #endregion
    #region ProductionIfUnlocked
    /// <inheritdoc cref="NetlifyDeploySettings.ProductionIfUnlocked"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.ProductionIfUnlocked))]
    public static T SetProductionIfUnlocked<T>(this T o, bool? v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.ProductionIfUnlocked, v));
    /// <inheritdoc cref="NetlifyDeploySettings.ProductionIfUnlocked"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.ProductionIfUnlocked))]
    public static T ResetProductionIfUnlocked<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.ProductionIfUnlocked));
    /// <inheritdoc cref="NetlifyDeploySettings.ProductionIfUnlocked"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.ProductionIfUnlocked))]
    public static T EnableProductionIfUnlocked<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.ProductionIfUnlocked, true));
    /// <inheritdoc cref="NetlifyDeploySettings.ProductionIfUnlocked"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.ProductionIfUnlocked))]
    public static T DisableProductionIfUnlocked<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.ProductionIfUnlocked, false));
    /// <inheritdoc cref="NetlifyDeploySettings.ProductionIfUnlocked"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.ProductionIfUnlocked))]
    public static T ToggleProductionIfUnlocked<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.ProductionIfUnlocked, !o.ProductionIfUnlocked));
    #endregion
    #region Alias
    /// <inheritdoc cref="NetlifyDeploySettings.Alias"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Alias))]
    public static T SetAlias<T>(this T o, string v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Alias, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Alias"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Alias))]
    public static T ResetAlias<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Alias));
    #endregion
    #region Branch
    /// <inheritdoc cref="NetlifyDeploySettings.Branch"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Branch))]
    public static T SetBranch<T>(this T o, string v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Branch, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Branch"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Branch))]
    public static T ResetBranch<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Branch));
    #endregion
    #region Open
    /// <inheritdoc cref="NetlifyDeploySettings.Open"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Open))]
    public static T SetOpen<T>(this T o, bool? v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Open, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Open"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Open))]
    public static T ResetOpen<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Open));
    /// <inheritdoc cref="NetlifyDeploySettings.Open"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Open))]
    public static T EnableOpen<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Open, true));
    /// <inheritdoc cref="NetlifyDeploySettings.Open"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Open))]
    public static T DisableOpen<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Open, false));
    /// <inheritdoc cref="NetlifyDeploySettings.Open"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Open))]
    public static T ToggleOpen<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Open, !o.Open));
    #endregion
    #region Message
    /// <inheritdoc cref="NetlifyDeploySettings.Message"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Message))]
    public static T SetMessage<T>(this T o, string v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Message, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Message"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Message))]
    public static T ResetMessage<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Message));
    #endregion
    #region Auth
    /// <inheritdoc cref="NetlifyDeploySettings.Auth"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Auth))]
    public static T SetAuth<T>(this T o, [Secret] string v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Auth, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Auth"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Auth))]
    public static T ResetAuth<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Auth));
    #endregion
    #region Site
    /// <inheritdoc cref="NetlifyDeploySettings.Site"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Site))]
    public static T SetSite<T>(this T o, string v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Site, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Site"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Site))]
    public static T ResetSite<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Site));
    #endregion
    #region Json
    /// <inheritdoc cref="NetlifyDeploySettings.Json"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Json))]
    public static T SetJson<T>(this T o, bool? v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Json, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Json"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Json))]
    public static T ResetJson<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Json));
    /// <inheritdoc cref="NetlifyDeploySettings.Json"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Json))]
    public static T EnableJson<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Json, true));
    /// <inheritdoc cref="NetlifyDeploySettings.Json"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Json))]
    public static T DisableJson<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Json, false));
    /// <inheritdoc cref="NetlifyDeploySettings.Json"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Json))]
    public static T ToggleJson<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Json, !o.Json));
    #endregion
    #region Timeout
    /// <inheritdoc cref="NetlifyDeploySettings.Timeout"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Timeout))]
    public static T SetTimeout<T>(this T o, string v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Timeout"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Trigger
    /// <inheritdoc cref="NetlifyDeploySettings.Trigger"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Trigger))]
    public static T SetTrigger<T>(this T o, bool? v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Trigger, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Trigger"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Trigger))]
    public static T ResetTrigger<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Trigger));
    /// <inheritdoc cref="NetlifyDeploySettings.Trigger"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Trigger))]
    public static T EnableTrigger<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Trigger, true));
    /// <inheritdoc cref="NetlifyDeploySettings.Trigger"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Trigger))]
    public static T DisableTrigger<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Trigger, false));
    /// <inheritdoc cref="NetlifyDeploySettings.Trigger"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Trigger))]
    public static T ToggleTrigger<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Trigger, !o.Trigger));
    #endregion
    #region Build
    /// <inheritdoc cref="NetlifyDeploySettings.Build"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Build))]
    public static T SetBuild<T>(this T o, bool? v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Build, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Build"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Build))]
    public static T ResetBuild<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Build));
    /// <inheritdoc cref="NetlifyDeploySettings.Build"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Build))]
    public static T EnableBuild<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Build, true));
    /// <inheritdoc cref="NetlifyDeploySettings.Build"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Build))]
    public static T DisableBuild<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Build, false));
    /// <inheritdoc cref="NetlifyDeploySettings.Build"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Build))]
    public static T ToggleBuild<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Build, !o.Build));
    #endregion
    #region Debug
    /// <inheritdoc cref="NetlifyDeploySettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="NetlifyDeploySettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="NetlifyDeploySettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="NetlifyDeploySettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="NetlifyDeploySettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region HttpProxy
    /// <inheritdoc cref="NetlifyDeploySettings.HttpProxy"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.HttpProxy))]
    public static T SetHttpProxy<T>(this T o, string v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.HttpProxy, v));
    /// <inheritdoc cref="NetlifyDeploySettings.HttpProxy"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.HttpProxy))]
    public static T ResetHttpProxy<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.HttpProxy));
    #endregion
    #region HttpProxyCertificateFileName
    /// <inheritdoc cref="NetlifyDeploySettings.HttpProxyCertificateFileName"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.HttpProxyCertificateFileName))]
    public static T SetHttpProxyCertificateFileName<T>(this T o, string v) where T : NetlifyDeploySettings => o.Modify(b => b.Set(() => o.HttpProxyCertificateFileName, v));
    /// <inheritdoc cref="NetlifyDeploySettings.HttpProxyCertificateFileName"/>
    [Pure] [Builder(Type = typeof(NetlifyDeploySettings), Property = nameof(NetlifyDeploySettings.HttpProxyCertificateFileName))]
    public static T ResetHttpProxyCertificateFileName<T>(this T o) where T : NetlifyDeploySettings => o.Modify(b => b.Remove(() => o.HttpProxyCertificateFileName));
    #endregion
}
#endregion
#region NetlifySitesCreateSettingsExtensions
/// <summary>Used within <see cref="NetlifyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NetlifySitesCreateSettingsExtensions
{
    #region Name
    /// <inheritdoc cref="NetlifySitesCreateSettings.Name"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="NetlifySitesCreateSettings.Name"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Name))]
    public static T ResetName<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region AccountSlug
    /// <inheritdoc cref="NetlifySitesCreateSettings.AccountSlug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.AccountSlug))]
    public static T SetAccountSlug<T>(this T o, string v) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.AccountSlug, v));
    /// <inheritdoc cref="NetlifySitesCreateSettings.AccountSlug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.AccountSlug))]
    public static T ResetAccountSlug<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Remove(() => o.AccountSlug));
    #endregion
    #region WithCI
    /// <inheritdoc cref="NetlifySitesCreateSettings.WithCI"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.WithCI))]
    public static T SetWithCI<T>(this T o, bool? v) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.WithCI, v));
    /// <inheritdoc cref="NetlifySitesCreateSettings.WithCI"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.WithCI))]
    public static T ResetWithCI<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Remove(() => o.WithCI));
    /// <inheritdoc cref="NetlifySitesCreateSettings.WithCI"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.WithCI))]
    public static T EnableWithCI<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.WithCI, true));
    /// <inheritdoc cref="NetlifySitesCreateSettings.WithCI"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.WithCI))]
    public static T DisableWithCI<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.WithCI, false));
    /// <inheritdoc cref="NetlifySitesCreateSettings.WithCI"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.WithCI))]
    public static T ToggleWithCI<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.WithCI, !o.WithCI));
    #endregion
    #region Manual
    /// <inheritdoc cref="NetlifySitesCreateSettings.Manual"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Manual))]
    public static T SetManual<T>(this T o, bool? v) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.Manual, v));
    /// <inheritdoc cref="NetlifySitesCreateSettings.Manual"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Manual))]
    public static T ResetManual<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Remove(() => o.Manual));
    /// <inheritdoc cref="NetlifySitesCreateSettings.Manual"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Manual))]
    public static T EnableManual<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.Manual, true));
    /// <inheritdoc cref="NetlifySitesCreateSettings.Manual"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Manual))]
    public static T DisableManual<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.Manual, false));
    /// <inheritdoc cref="NetlifySitesCreateSettings.Manual"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Manual))]
    public static T ToggleManual<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.Manual, !o.Manual));
    #endregion
    #region Debug
    /// <inheritdoc cref="NetlifySitesCreateSettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="NetlifySitesCreateSettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="NetlifySitesCreateSettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="NetlifySitesCreateSettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="NetlifySitesCreateSettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region HttpProxy
    /// <inheritdoc cref="NetlifySitesCreateSettings.HttpProxy"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.HttpProxy))]
    public static T SetHttpProxy<T>(this T o, string v) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.HttpProxy, v));
    /// <inheritdoc cref="NetlifySitesCreateSettings.HttpProxy"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.HttpProxy))]
    public static T ResetHttpProxy<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Remove(() => o.HttpProxy));
    #endregion
    #region HttpProxyCertificateFileName
    /// <inheritdoc cref="NetlifySitesCreateSettings.HttpProxyCertificateFileName"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.HttpProxyCertificateFileName))]
    public static T SetHttpProxyCertificateFileName<T>(this T o, string v) where T : NetlifySitesCreateSettings => o.Modify(b => b.Set(() => o.HttpProxyCertificateFileName, v));
    /// <inheritdoc cref="NetlifySitesCreateSettings.HttpProxyCertificateFileName"/>
    [Pure] [Builder(Type = typeof(NetlifySitesCreateSettings), Property = nameof(NetlifySitesCreateSettings.HttpProxyCertificateFileName))]
    public static T ResetHttpProxyCertificateFileName<T>(this T o) where T : NetlifySitesCreateSettings => o.Modify(b => b.Remove(() => o.HttpProxyCertificateFileName));
    #endregion
}
#endregion
#region NetlifySitesDeleteSettingsExtensions
/// <summary>Used within <see cref="NetlifyTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class NetlifySitesDeleteSettingsExtensions
{
    #region SiteId
    /// <inheritdoc cref="NetlifySitesDeleteSettings.SiteId"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.SiteId))]
    public static T SetSiteId<T>(this T o, string v) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.SiteId, v));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.SiteId"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.SiteId))]
    public static T ResetSiteId<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Remove(() => o.SiteId));
    #endregion
    #region Force
    /// <inheritdoc cref="NetlifySitesDeleteSettings.Force"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.Force"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.Force))]
    public static T ResetForce<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.Force"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.Force))]
    public static T EnableForce<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.Force"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.Force))]
    public static T DisableForce<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.Force"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region Debug
    /// <inheritdoc cref="NetlifySitesDeleteSettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.Debug"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region HttpProxy
    /// <inheritdoc cref="NetlifySitesDeleteSettings.HttpProxy"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.HttpProxy))]
    public static T SetHttpProxy<T>(this T o, string v) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.HttpProxy, v));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.HttpProxy"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.HttpProxy))]
    public static T ResetHttpProxy<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Remove(() => o.HttpProxy));
    #endregion
    #region HttpProxyCertificateFileName
    /// <inheritdoc cref="NetlifySitesDeleteSettings.HttpProxyCertificateFileName"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.HttpProxyCertificateFileName))]
    public static T SetHttpProxyCertificateFileName<T>(this T o, string v) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Set(() => o.HttpProxyCertificateFileName, v));
    /// <inheritdoc cref="NetlifySitesDeleteSettings.HttpProxyCertificateFileName"/>
    [Pure] [Builder(Type = typeof(NetlifySitesDeleteSettings), Property = nameof(NetlifySitesDeleteSettings.HttpProxyCertificateFileName))]
    public static T ResetHttpProxyCertificateFileName<T>(this T o) where T : NetlifySitesDeleteSettings => o.Modify(b => b.Remove(() => o.HttpProxyCertificateFileName));
    #endregion
}
#endregion
