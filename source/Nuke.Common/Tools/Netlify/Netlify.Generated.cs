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

namespace Nuke.Common.Tools.Netlify
{
    /// <summary>
    ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
    ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [PathToolRequirement(NetlifyPathExecutable)]
    public partial class NetlifyTasks
        : IRequirePathTool
    {
        public const string NetlifyPathExecutable = "npx";
        /// <summary>
        ///   Path to the Netlify executable.
        /// </summary>
        public static string NetlifyPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("NETLIFY_EXE") ??
            ToolPathResolver.GetPathExecutable("npx");
        public static Action<OutputType, string> NetlifyLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Netlify(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(NetlifyPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? NetlifyLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--alias</c> via <see cref="NetlifyDeploySettings.Alias"/></li>
        ///     <li><c>--auth</c> via <see cref="NetlifyDeploySettings.Auth"/></li>
        ///     <li><c>--branch</c> via <see cref="NetlifyDeploySettings.Branch"/></li>
        ///     <li><c>--build</c> via <see cref="NetlifyDeploySettings.Build"/></li>
        ///     <li><c>--debug</c> via <see cref="NetlifyDeploySettings.Debug"/></li>
        ///     <li><c>--dir</c> via <see cref="NetlifyDeploySettings.Directory"/></li>
        ///     <li><c>--functions</c> via <see cref="NetlifyDeploySettings.Functions"/></li>
        ///     <li><c>--httpProxy</c> via <see cref="NetlifyDeploySettings.HttpProxy"/></li>
        ///     <li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifyDeploySettings.HttpProxyCertificateFileName"/></li>
        ///     <li><c>--json</c> via <see cref="NetlifyDeploySettings.Json"/></li>
        ///     <li><c>--message</c> via <see cref="NetlifyDeploySettings.Message"/></li>
        ///     <li><c>--open</c> via <see cref="NetlifyDeploySettings.Open"/></li>
        ///     <li><c>--prod</c> via <see cref="NetlifyDeploySettings.Production"/></li>
        ///     <li><c>--prodIfUnlocked</c> via <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></li>
        ///     <li><c>--site</c> via <see cref="NetlifyDeploySettings.Site"/></li>
        ///     <li><c>--timeout</c> via <see cref="NetlifyDeploySettings.Timeout"/></li>
        ///     <li><c>--trigger</c> via <see cref="NetlifyDeploySettings.Trigger"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NetlifyDeploy(NetlifyDeploySettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NetlifyDeploySettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--alias</c> via <see cref="NetlifyDeploySettings.Alias"/></li>
        ///     <li><c>--auth</c> via <see cref="NetlifyDeploySettings.Auth"/></li>
        ///     <li><c>--branch</c> via <see cref="NetlifyDeploySettings.Branch"/></li>
        ///     <li><c>--build</c> via <see cref="NetlifyDeploySettings.Build"/></li>
        ///     <li><c>--debug</c> via <see cref="NetlifyDeploySettings.Debug"/></li>
        ///     <li><c>--dir</c> via <see cref="NetlifyDeploySettings.Directory"/></li>
        ///     <li><c>--functions</c> via <see cref="NetlifyDeploySettings.Functions"/></li>
        ///     <li><c>--httpProxy</c> via <see cref="NetlifyDeploySettings.HttpProxy"/></li>
        ///     <li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifyDeploySettings.HttpProxyCertificateFileName"/></li>
        ///     <li><c>--json</c> via <see cref="NetlifyDeploySettings.Json"/></li>
        ///     <li><c>--message</c> via <see cref="NetlifyDeploySettings.Message"/></li>
        ///     <li><c>--open</c> via <see cref="NetlifyDeploySettings.Open"/></li>
        ///     <li><c>--prod</c> via <see cref="NetlifyDeploySettings.Production"/></li>
        ///     <li><c>--prodIfUnlocked</c> via <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></li>
        ///     <li><c>--site</c> via <see cref="NetlifyDeploySettings.Site"/></li>
        ///     <li><c>--timeout</c> via <see cref="NetlifyDeploySettings.Timeout"/></li>
        ///     <li><c>--trigger</c> via <see cref="NetlifyDeploySettings.Trigger"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NetlifyDeploy(Configure<NetlifyDeploySettings> configurator)
        {
            return NetlifyDeploy(configurator(new NetlifyDeploySettings()));
        }
        /// <summary>
        ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--alias</c> via <see cref="NetlifyDeploySettings.Alias"/></li>
        ///     <li><c>--auth</c> via <see cref="NetlifyDeploySettings.Auth"/></li>
        ///     <li><c>--branch</c> via <see cref="NetlifyDeploySettings.Branch"/></li>
        ///     <li><c>--build</c> via <see cref="NetlifyDeploySettings.Build"/></li>
        ///     <li><c>--debug</c> via <see cref="NetlifyDeploySettings.Debug"/></li>
        ///     <li><c>--dir</c> via <see cref="NetlifyDeploySettings.Directory"/></li>
        ///     <li><c>--functions</c> via <see cref="NetlifyDeploySettings.Functions"/></li>
        ///     <li><c>--httpProxy</c> via <see cref="NetlifyDeploySettings.HttpProxy"/></li>
        ///     <li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifyDeploySettings.HttpProxyCertificateFileName"/></li>
        ///     <li><c>--json</c> via <see cref="NetlifyDeploySettings.Json"/></li>
        ///     <li><c>--message</c> via <see cref="NetlifyDeploySettings.Message"/></li>
        ///     <li><c>--open</c> via <see cref="NetlifyDeploySettings.Open"/></li>
        ///     <li><c>--prod</c> via <see cref="NetlifyDeploySettings.Production"/></li>
        ///     <li><c>--prodIfUnlocked</c> via <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></li>
        ///     <li><c>--site</c> via <see cref="NetlifyDeploySettings.Site"/></li>
        ///     <li><c>--timeout</c> via <see cref="NetlifyDeploySettings.Timeout"/></li>
        ///     <li><c>--trigger</c> via <see cref="NetlifyDeploySettings.Trigger"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NetlifyDeploySettings Settings, IReadOnlyCollection<Output> Output)> NetlifyDeploy(CombinatorialConfigure<NetlifyDeploySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NetlifyDeploy, NetlifyLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--account-slug</c> via <see cref="NetlifySitesCreateSettings.AccountSlug"/></li>
        ///     <li><c>--debug</c> via <see cref="NetlifySitesCreateSettings.Debug"/></li>
        ///     <li><c>--httpProxy</c> via <see cref="NetlifySitesCreateSettings.HttpProxy"/></li>
        ///     <li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesCreateSettings.HttpProxyCertificateFileName"/></li>
        ///     <li><c>--manual</c> via <see cref="NetlifySitesCreateSettings.Manual"/></li>
        ///     <li><c>--name</c> via <see cref="NetlifySitesCreateSettings.Name"/></li>
        ///     <li><c>--with-ci</c> via <see cref="NetlifySitesCreateSettings.WithCI"/></li>
        ///   </ul>
        /// </remarks>
        public static (string Result, IReadOnlyCollection<Output> Output) NetlifySitesCreate(NetlifySitesCreateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NetlifySitesCreateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return (GetResult(process, toolSettings), process.Output);
        }
        /// <summary>
        ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--account-slug</c> via <see cref="NetlifySitesCreateSettings.AccountSlug"/></li>
        ///     <li><c>--debug</c> via <see cref="NetlifySitesCreateSettings.Debug"/></li>
        ///     <li><c>--httpProxy</c> via <see cref="NetlifySitesCreateSettings.HttpProxy"/></li>
        ///     <li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesCreateSettings.HttpProxyCertificateFileName"/></li>
        ///     <li><c>--manual</c> via <see cref="NetlifySitesCreateSettings.Manual"/></li>
        ///     <li><c>--name</c> via <see cref="NetlifySitesCreateSettings.Name"/></li>
        ///     <li><c>--with-ci</c> via <see cref="NetlifySitesCreateSettings.WithCI"/></li>
        ///   </ul>
        /// </remarks>
        public static (string Result, IReadOnlyCollection<Output> Output) NetlifySitesCreate(Configure<NetlifySitesCreateSettings> configurator)
        {
            return NetlifySitesCreate(configurator(new NetlifySitesCreateSettings()));
        }
        /// <summary>
        ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--account-slug</c> via <see cref="NetlifySitesCreateSettings.AccountSlug"/></li>
        ///     <li><c>--debug</c> via <see cref="NetlifySitesCreateSettings.Debug"/></li>
        ///     <li><c>--httpProxy</c> via <see cref="NetlifySitesCreateSettings.HttpProxy"/></li>
        ///     <li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesCreateSettings.HttpProxyCertificateFileName"/></li>
        ///     <li><c>--manual</c> via <see cref="NetlifySitesCreateSettings.Manual"/></li>
        ///     <li><c>--name</c> via <see cref="NetlifySitesCreateSettings.Name"/></li>
        ///     <li><c>--with-ci</c> via <see cref="NetlifySitesCreateSettings.WithCI"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NetlifySitesCreateSettings Settings, string Result, IReadOnlyCollection<Output> Output)> NetlifySitesCreate(CombinatorialConfigure<NetlifySitesCreateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NetlifySitesCreate, NetlifyLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;siteId&gt;</c> via <see cref="NetlifySitesDeleteSettings.SiteId"/></li>
        ///     <li><c>--debug</c> via <see cref="NetlifySitesDeleteSettings.Debug"/></li>
        ///     <li><c>--force</c> via <see cref="NetlifySitesDeleteSettings.Force"/></li>
        ///     <li><c>--httpProxy</c> via <see cref="NetlifySitesDeleteSettings.HttpProxy"/></li>
        ///     <li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesDeleteSettings.HttpProxyCertificateFileName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NetlifySitesDelete(NetlifySitesDeleteSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new NetlifySitesDeleteSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;siteId&gt;</c> via <see cref="NetlifySitesDeleteSettings.SiteId"/></li>
        ///     <li><c>--debug</c> via <see cref="NetlifySitesDeleteSettings.Debug"/></li>
        ///     <li><c>--force</c> via <see cref="NetlifySitesDeleteSettings.Force"/></li>
        ///     <li><c>--httpProxy</c> via <see cref="NetlifySitesDeleteSettings.HttpProxy"/></li>
        ///     <li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesDeleteSettings.HttpProxyCertificateFileName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> NetlifySitesDelete(Configure<NetlifySitesDeleteSettings> configurator)
        {
            return NetlifySitesDelete(configurator(new NetlifySitesDeleteSettings()));
        }
        /// <summary>
        ///   <p>Netlify’s command line interface (CLI) lets you configure <a href="https://docs.netlify.com/cli/get-started/#continuous-deployment">continuous deployment</a> straight from the command line. You can use Netlify CLI to <a href="https://docs.netlify.com/cli/get-started/#run-a-local-development-environment">run a local development server</a> that you can share with others, <a href="https://docs.netlify.com/cli/get-started/#run-builds-locally">run a local build and plugins</a>, and <a href="https://docs.netlify.com/cli/get-started/#manual-deploys">deploy your site</a>.</p>
        ///   <p>For more details, visit the <a href="https://docs.netlify.com/cli/get-started/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;siteId&gt;</c> via <see cref="NetlifySitesDeleteSettings.SiteId"/></li>
        ///     <li><c>--debug</c> via <see cref="NetlifySitesDeleteSettings.Debug"/></li>
        ///     <li><c>--force</c> via <see cref="NetlifySitesDeleteSettings.Force"/></li>
        ///     <li><c>--httpProxy</c> via <see cref="NetlifySitesDeleteSettings.HttpProxy"/></li>
        ///     <li><c>--httpProxyCertificateFilename</c> via <see cref="NetlifySitesDeleteSettings.HttpProxyCertificateFileName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(NetlifySitesDeleteSettings Settings, IReadOnlyCollection<Output> Output)> NetlifySitesDelete(CombinatorialConfigure<NetlifySitesDeleteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(NetlifySitesDelete, NetlifyLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region NetlifyDeploySettings
    /// <summary>
    ///   Used within <see cref="NetlifyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NetlifyDeploySettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Netlify executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NetlifyTasks.NetlifyPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NetlifyTasks.NetlifyLogger;
        /// <summary>
        ///   Specify a folder to deploy.
        /// </summary>
        public virtual string Directory { get; internal set; }
        /// <summary>
        ///   Specify a functions folder to deploy.
        /// </summary>
        public virtual string Functions { get; internal set; }
        /// <summary>
        ///   Deploy to production.
        /// </summary>
        public virtual bool? Production { get; internal set; }
        /// <summary>
        ///   Deploy to production if unlocked, create a draft otherwise.
        /// </summary>
        public virtual bool? ProductionIfUnlocked { get; internal set; }
        /// <summary>
        ///   Specifies the alias for deployment, the string at the beginning of the deploy subdomain. Useful for creating predictable deployment URLs. Avoid setting an alias string to the same value as a deployed branch. <code>alias doesn’t</code> create a branch deploy and can’t be used in conjunction with the branch subdomain feature. Maximum 37 characters.
        /// </summary>
        public virtual string Alias { get; internal set; }
        /// <summary>
        ///   Serves the same functionality as --alias. Deprecated and will be removed in future versions.
        /// </summary>
        public virtual string Branch { get; internal set; }
        /// <summary>
        ///   Open site after deploy.
        /// </summary>
        public virtual bool? Open { get; internal set; }
        /// <summary>
        ///   A short message to include in the deploy log.
        /// </summary>
        public virtual string Message { get; internal set; }
        /// <summary>
        ///   Netlify auth token to deploy with.
        /// </summary>
        public virtual string Auth { get; internal set; }
        /// <summary>
        ///   Netlify auth token to deploy with.
        /// </summary>
        public virtual string Site { get; internal set; }
        /// <summary>
        ///   Output deployment data as JSON.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   Timeout to wait for deployment to finish.
        /// </summary>
        public virtual string Timeout { get; internal set; }
        /// <summary>
        ///   Trigger a new build of your site on Netlify without uploading local files.
        /// </summary>
        public virtual bool? Trigger { get; internal set; }
        /// <summary>
        ///   Run build command before deploying.
        /// </summary>
        public virtual bool? Build { get; internal set; }
        /// <summary>
        ///   Print debugging information.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Proxy server address to route requests through.
        /// </summary>
        public virtual string HttpProxy { get; internal set; }
        /// <summary>
        ///   Certificate file to use when connecting using a proxy server.
        /// </summary>
        public virtual string HttpProxyCertificateFileName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("netlify deploy")
              .Add("--dir {value}", Directory)
              .Add("--functions {value}", Functions)
              .Add("--prod", Production)
              .Add("--prodIfUnlocked", ProductionIfUnlocked)
              .Add("--alias {value}", Alias)
              .Add("--branch {value}", Branch)
              .Add("--open", Open)
              .Add("--message {value}", Message)
              .Add("--auth {value}", Auth, secret: true)
              .Add("--site {value}", Site)
              .Add("--json", Json)
              .Add("--timeout {value}", Timeout)
              .Add("--trigger", Trigger)
              .Add("--build", Build)
              .Add("--debug", Debug)
              .Add("--httpProxy {value}", HttpProxy)
              .Add("--httpProxyCertificateFilename {value}", HttpProxyCertificateFileName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NetlifySitesCreateSettings
    /// <summary>
    ///   Used within <see cref="NetlifyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NetlifySitesCreateSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Netlify executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NetlifyTasks.NetlifyPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NetlifyTasks.NetlifyLogger;
        /// <summary>
        ///   Name of site.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   Account slug to create the site under.
        /// </summary>
        public virtual string AccountSlug { get; internal set; }
        /// <summary>
        ///   Initialize CI hooks during site creation.
        /// </summary>
        public virtual bool? WithCI { get; internal set; }
        /// <summary>
        ///   Force manual CI setup. Used <code>--with-ci</code> flag.
        /// </summary>
        public virtual bool? Manual { get; internal set; }
        /// <summary>
        ///   Print debugging information.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Proxy server address to route requests through.
        /// </summary>
        public virtual string HttpProxy { get; internal set; }
        /// <summary>
        ///   Certificate file to use when connecting using a proxy server.
        /// </summary>
        public virtual string HttpProxyCertificateFileName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("netlify sites:create")
              .Add("--name {value}", Name)
              .Add("--account-slug {value}", AccountSlug)
              .Add("--with-ci", WithCI)
              .Add("--manual", Manual)
              .Add("--debug", Debug)
              .Add("--httpProxy {value}", HttpProxy)
              .Add("--httpProxyCertificateFilename {value}", HttpProxyCertificateFileName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NetlifySitesDeleteSettings
    /// <summary>
    ///   Used within <see cref="NetlifyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NetlifySitesDeleteSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Netlify executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? NetlifyTasks.NetlifyPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? NetlifyTasks.NetlifyLogger;
        /// <summary>
        ///   Site ID to delete.
        /// </summary>
        public virtual string SiteId { get; internal set; }
        /// <summary>
        ///   Delete without prompting (useful for CI).
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Print debugging information.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Proxy server address to route requests through.
        /// </summary>
        public virtual string HttpProxy { get; internal set; }
        /// <summary>
        ///   Certificate file to use when connecting using a proxy server.
        /// </summary>
        public virtual string HttpProxyCertificateFileName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("netlify sites:delete")
              .Add("{value}", SiteId)
              .Add("--force", Force)
              .Add("--debug", Debug)
              .Add("--httpProxy {value}", HttpProxy)
              .Add("--httpProxyCertificateFilename {value}", HttpProxyCertificateFileName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region NetlifyDeploySettingsExtensions
    /// <summary>
    ///   Used within <see cref="NetlifyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NetlifyDeploySettingsExtensions
    {
        #region Directory
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Directory"/></em></p>
        ///   <p>Specify a folder to deploy.</p>
        /// </summary>
        [Pure]
        public static T SetDirectory<T>(this T toolSettings, string directory) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Directory = directory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Directory"/></em></p>
        ///   <p>Specify a folder to deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetDirectory<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Directory = null;
            return toolSettings;
        }
        #endregion
        #region Functions
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Functions"/></em></p>
        ///   <p>Specify a functions folder to deploy.</p>
        /// </summary>
        [Pure]
        public static T SetFunctions<T>(this T toolSettings, string functions) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Functions = functions;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Functions"/></em></p>
        ///   <p>Specify a functions folder to deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetFunctions<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Functions = null;
            return toolSettings;
        }
        #endregion
        #region Production
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Production"/></em></p>
        ///   <p>Deploy to production.</p>
        /// </summary>
        [Pure]
        public static T SetProduction<T>(this T toolSettings, bool? production) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = production;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Production"/></em></p>
        ///   <p>Deploy to production.</p>
        /// </summary>
        [Pure]
        public static T ResetProduction<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifyDeploySettings.Production"/></em></p>
        ///   <p>Deploy to production.</p>
        /// </summary>
        [Pure]
        public static T EnableProduction<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifyDeploySettings.Production"/></em></p>
        ///   <p>Deploy to production.</p>
        /// </summary>
        [Pure]
        public static T DisableProduction<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifyDeploySettings.Production"/></em></p>
        ///   <p>Deploy to production.</p>
        /// </summary>
        [Pure]
        public static T ToggleProduction<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Production = !toolSettings.Production;
            return toolSettings;
        }
        #endregion
        #region ProductionIfUnlocked
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></em></p>
        ///   <p>Deploy to production if unlocked, create a draft otherwise.</p>
        /// </summary>
        [Pure]
        public static T SetProductionIfUnlocked<T>(this T toolSettings, bool? productionIfUnlocked) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductionIfUnlocked = productionIfUnlocked;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></em></p>
        ///   <p>Deploy to production if unlocked, create a draft otherwise.</p>
        /// </summary>
        [Pure]
        public static T ResetProductionIfUnlocked<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductionIfUnlocked = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></em></p>
        ///   <p>Deploy to production if unlocked, create a draft otherwise.</p>
        /// </summary>
        [Pure]
        public static T EnableProductionIfUnlocked<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductionIfUnlocked = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></em></p>
        ///   <p>Deploy to production if unlocked, create a draft otherwise.</p>
        /// </summary>
        [Pure]
        public static T DisableProductionIfUnlocked<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductionIfUnlocked = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifyDeploySettings.ProductionIfUnlocked"/></em></p>
        ///   <p>Deploy to production if unlocked, create a draft otherwise.</p>
        /// </summary>
        [Pure]
        public static T ToggleProductionIfUnlocked<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductionIfUnlocked = !toolSettings.ProductionIfUnlocked;
            return toolSettings;
        }
        #endregion
        #region Alias
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Alias"/></em></p>
        ///   <p>Specifies the alias for deployment, the string at the beginning of the deploy subdomain. Useful for creating predictable deployment URLs. Avoid setting an alias string to the same value as a deployed branch. <code>alias doesn’t</code> create a branch deploy and can’t be used in conjunction with the branch subdomain feature. Maximum 37 characters.</p>
        /// </summary>
        [Pure]
        public static T SetAlias<T>(this T toolSettings, string alias) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Alias = alias;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Alias"/></em></p>
        ///   <p>Specifies the alias for deployment, the string at the beginning of the deploy subdomain. Useful for creating predictable deployment URLs. Avoid setting an alias string to the same value as a deployed branch. <code>alias doesn’t</code> create a branch deploy and can’t be used in conjunction with the branch subdomain feature. Maximum 37 characters.</p>
        /// </summary>
        [Pure]
        public static T ResetAlias<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Alias = null;
            return toolSettings;
        }
        #endregion
        #region Branch
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Branch"/></em></p>
        ///   <p>Serves the same functionality as --alias. Deprecated and will be removed in future versions.</p>
        /// </summary>
        [Pure]
        public static T SetBranch<T>(this T toolSettings, string branch) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Branch = branch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Branch"/></em></p>
        ///   <p>Serves the same functionality as --alias. Deprecated and will be removed in future versions.</p>
        /// </summary>
        [Pure]
        public static T ResetBranch<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Branch = null;
            return toolSettings;
        }
        #endregion
        #region Open
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Open"/></em></p>
        ///   <p>Open site after deploy.</p>
        /// </summary>
        [Pure]
        public static T SetOpen<T>(this T toolSettings, bool? open) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Open = open;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Open"/></em></p>
        ///   <p>Open site after deploy.</p>
        /// </summary>
        [Pure]
        public static T ResetOpen<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Open = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifyDeploySettings.Open"/></em></p>
        ///   <p>Open site after deploy.</p>
        /// </summary>
        [Pure]
        public static T EnableOpen<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Open = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifyDeploySettings.Open"/></em></p>
        ///   <p>Open site after deploy.</p>
        /// </summary>
        [Pure]
        public static T DisableOpen<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Open = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifyDeploySettings.Open"/></em></p>
        ///   <p>Open site after deploy.</p>
        /// </summary>
        [Pure]
        public static T ToggleOpen<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Open = !toolSettings.Open;
            return toolSettings;
        }
        #endregion
        #region Message
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Message"/></em></p>
        ///   <p>A short message to include in the deploy log.</p>
        /// </summary>
        [Pure]
        public static T SetMessage<T>(this T toolSettings, string message) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Message = message;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Message"/></em></p>
        ///   <p>A short message to include in the deploy log.</p>
        /// </summary>
        [Pure]
        public static T ResetMessage<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Message = null;
            return toolSettings;
        }
        #endregion
        #region Auth
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Auth"/></em></p>
        ///   <p>Netlify auth token to deploy with.</p>
        /// </summary>
        [Pure]
        public static T SetAuth<T>(this T toolSettings, [Secret] string auth) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Auth = auth;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Auth"/></em></p>
        ///   <p>Netlify auth token to deploy with.</p>
        /// </summary>
        [Pure]
        public static T ResetAuth<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Auth = null;
            return toolSettings;
        }
        #endregion
        #region Site
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Site"/></em></p>
        ///   <p>Netlify auth token to deploy with.</p>
        /// </summary>
        [Pure]
        public static T SetSite<T>(this T toolSettings, string site) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Site = site;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Site"/></em></p>
        ///   <p>Netlify auth token to deploy with.</p>
        /// </summary>
        [Pure]
        public static T ResetSite<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Site = null;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Json"/></em></p>
        ///   <p>Output deployment data as JSON.</p>
        /// </summary>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Json"/></em></p>
        ///   <p>Output deployment data as JSON.</p>
        /// </summary>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifyDeploySettings.Json"/></em></p>
        ///   <p>Output deployment data as JSON.</p>
        /// </summary>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifyDeploySettings.Json"/></em></p>
        ///   <p>Output deployment data as JSON.</p>
        /// </summary>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifyDeploySettings.Json"/></em></p>
        ///   <p>Output deployment data as JSON.</p>
        /// </summary>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Timeout"/></em></p>
        ///   <p>Timeout to wait for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, string timeout) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Timeout"/></em></p>
        ///   <p>Timeout to wait for deployment to finish.</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Trigger
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Trigger"/></em></p>
        ///   <p>Trigger a new build of your site on Netlify without uploading local files.</p>
        /// </summary>
        [Pure]
        public static T SetTrigger<T>(this T toolSettings, bool? trigger) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trigger = trigger;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Trigger"/></em></p>
        ///   <p>Trigger a new build of your site on Netlify without uploading local files.</p>
        /// </summary>
        [Pure]
        public static T ResetTrigger<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trigger = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifyDeploySettings.Trigger"/></em></p>
        ///   <p>Trigger a new build of your site on Netlify without uploading local files.</p>
        /// </summary>
        [Pure]
        public static T EnableTrigger<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trigger = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifyDeploySettings.Trigger"/></em></p>
        ///   <p>Trigger a new build of your site on Netlify without uploading local files.</p>
        /// </summary>
        [Pure]
        public static T DisableTrigger<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trigger = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifyDeploySettings.Trigger"/></em></p>
        ///   <p>Trigger a new build of your site on Netlify without uploading local files.</p>
        /// </summary>
        [Pure]
        public static T ToggleTrigger<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Trigger = !toolSettings.Trigger;
            return toolSettings;
        }
        #endregion
        #region Build
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Build"/></em></p>
        ///   <p>Run build command before deploying.</p>
        /// </summary>
        [Pure]
        public static T SetBuild<T>(this T toolSettings, bool? build) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = build;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Build"/></em></p>
        ///   <p>Run build command before deploying.</p>
        /// </summary>
        [Pure]
        public static T ResetBuild<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifyDeploySettings.Build"/></em></p>
        ///   <p>Run build command before deploying.</p>
        /// </summary>
        [Pure]
        public static T EnableBuild<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifyDeploySettings.Build"/></em></p>
        ///   <p>Run build command before deploying.</p>
        /// </summary>
        [Pure]
        public static T DisableBuild<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifyDeploySettings.Build"/></em></p>
        ///   <p>Run build command before deploying.</p>
        /// </summary>
        [Pure]
        public static T ToggleBuild<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = !toolSettings.Build;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifyDeploySettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifyDeploySettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifyDeploySettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region HttpProxy
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.HttpProxy"/></em></p>
        ///   <p>Proxy server address to route requests through.</p>
        /// </summary>
        [Pure]
        public static T SetHttpProxy<T>(this T toolSettings, string httpProxy) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxy = httpProxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.HttpProxy"/></em></p>
        ///   <p>Proxy server address to route requests through.</p>
        /// </summary>
        [Pure]
        public static T ResetHttpProxy<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxy = null;
            return toolSettings;
        }
        #endregion
        #region HttpProxyCertificateFileName
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifyDeploySettings.HttpProxyCertificateFileName"/></em></p>
        ///   <p>Certificate file to use when connecting using a proxy server.</p>
        /// </summary>
        [Pure]
        public static T SetHttpProxyCertificateFileName<T>(this T toolSettings, string httpProxyCertificateFileName) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxyCertificateFileName = httpProxyCertificateFileName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifyDeploySettings.HttpProxyCertificateFileName"/></em></p>
        ///   <p>Certificate file to use when connecting using a proxy server.</p>
        /// </summary>
        [Pure]
        public static T ResetHttpProxyCertificateFileName<T>(this T toolSettings) where T : NetlifyDeploySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxyCertificateFileName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NetlifySitesCreateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NetlifyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NetlifySitesCreateSettingsExtensions
    {
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesCreateSettings.Name"/></em></p>
        ///   <p>Name of site.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesCreateSettings.Name"/></em></p>
        ///   <p>Name of site.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region AccountSlug
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesCreateSettings.AccountSlug"/></em></p>
        ///   <p>Account slug to create the site under.</p>
        /// </summary>
        [Pure]
        public static T SetAccountSlug<T>(this T toolSettings, string accountSlug) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AccountSlug = accountSlug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesCreateSettings.AccountSlug"/></em></p>
        ///   <p>Account slug to create the site under.</p>
        /// </summary>
        [Pure]
        public static T ResetAccountSlug<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AccountSlug = null;
            return toolSettings;
        }
        #endregion
        #region WithCI
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesCreateSettings.WithCI"/></em></p>
        ///   <p>Initialize CI hooks during site creation.</p>
        /// </summary>
        [Pure]
        public static T SetWithCI<T>(this T toolSettings, bool? withCI) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WithCI = withCI;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesCreateSettings.WithCI"/></em></p>
        ///   <p>Initialize CI hooks during site creation.</p>
        /// </summary>
        [Pure]
        public static T ResetWithCI<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WithCI = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifySitesCreateSettings.WithCI"/></em></p>
        ///   <p>Initialize CI hooks during site creation.</p>
        /// </summary>
        [Pure]
        public static T EnableWithCI<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WithCI = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifySitesCreateSettings.WithCI"/></em></p>
        ///   <p>Initialize CI hooks during site creation.</p>
        /// </summary>
        [Pure]
        public static T DisableWithCI<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WithCI = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifySitesCreateSettings.WithCI"/></em></p>
        ///   <p>Initialize CI hooks during site creation.</p>
        /// </summary>
        [Pure]
        public static T ToggleWithCI<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WithCI = !toolSettings.WithCI;
            return toolSettings;
        }
        #endregion
        #region Manual
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesCreateSettings.Manual"/></em></p>
        ///   <p>Force manual CI setup. Used <code>--with-ci</code> flag.</p>
        /// </summary>
        [Pure]
        public static T SetManual<T>(this T toolSettings, bool? manual) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manual = manual;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesCreateSettings.Manual"/></em></p>
        ///   <p>Force manual CI setup. Used <code>--with-ci</code> flag.</p>
        /// </summary>
        [Pure]
        public static T ResetManual<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manual = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifySitesCreateSettings.Manual"/></em></p>
        ///   <p>Force manual CI setup. Used <code>--with-ci</code> flag.</p>
        /// </summary>
        [Pure]
        public static T EnableManual<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manual = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifySitesCreateSettings.Manual"/></em></p>
        ///   <p>Force manual CI setup. Used <code>--with-ci</code> flag.</p>
        /// </summary>
        [Pure]
        public static T DisableManual<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manual = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifySitesCreateSettings.Manual"/></em></p>
        ///   <p>Force manual CI setup. Used <code>--with-ci</code> flag.</p>
        /// </summary>
        [Pure]
        public static T ToggleManual<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manual = !toolSettings.Manual;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesCreateSettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesCreateSettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifySitesCreateSettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifySitesCreateSettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifySitesCreateSettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region HttpProxy
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesCreateSettings.HttpProxy"/></em></p>
        ///   <p>Proxy server address to route requests through.</p>
        /// </summary>
        [Pure]
        public static T SetHttpProxy<T>(this T toolSettings, string httpProxy) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxy = httpProxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesCreateSettings.HttpProxy"/></em></p>
        ///   <p>Proxy server address to route requests through.</p>
        /// </summary>
        [Pure]
        public static T ResetHttpProxy<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxy = null;
            return toolSettings;
        }
        #endregion
        #region HttpProxyCertificateFileName
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesCreateSettings.HttpProxyCertificateFileName"/></em></p>
        ///   <p>Certificate file to use when connecting using a proxy server.</p>
        /// </summary>
        [Pure]
        public static T SetHttpProxyCertificateFileName<T>(this T toolSettings, string httpProxyCertificateFileName) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxyCertificateFileName = httpProxyCertificateFileName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesCreateSettings.HttpProxyCertificateFileName"/></em></p>
        ///   <p>Certificate file to use when connecting using a proxy server.</p>
        /// </summary>
        [Pure]
        public static T ResetHttpProxyCertificateFileName<T>(this T toolSettings) where T : NetlifySitesCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxyCertificateFileName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NetlifySitesDeleteSettingsExtensions
    /// <summary>
    ///   Used within <see cref="NetlifyTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NetlifySitesDeleteSettingsExtensions
    {
        #region SiteId
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesDeleteSettings.SiteId"/></em></p>
        ///   <p>Site ID to delete.</p>
        /// </summary>
        [Pure]
        public static T SetSiteId<T>(this T toolSettings, string siteId) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SiteId = siteId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesDeleteSettings.SiteId"/></em></p>
        ///   <p>Site ID to delete.</p>
        /// </summary>
        [Pure]
        public static T ResetSiteId<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SiteId = null;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesDeleteSettings.Force"/></em></p>
        ///   <p>Delete without prompting (useful for CI).</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesDeleteSettings.Force"/></em></p>
        ///   <p>Delete without prompting (useful for CI).</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifySitesDeleteSettings.Force"/></em></p>
        ///   <p>Delete without prompting (useful for CI).</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifySitesDeleteSettings.Force"/></em></p>
        ///   <p>Delete without prompting (useful for CI).</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifySitesDeleteSettings.Force"/></em></p>
        ///   <p>Delete without prompting (useful for CI).</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesDeleteSettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesDeleteSettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="NetlifySitesDeleteSettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="NetlifySitesDeleteSettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="NetlifySitesDeleteSettings.Debug"/></em></p>
        ///   <p>Print debugging information.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region HttpProxy
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesDeleteSettings.HttpProxy"/></em></p>
        ///   <p>Proxy server address to route requests through.</p>
        /// </summary>
        [Pure]
        public static T SetHttpProxy<T>(this T toolSettings, string httpProxy) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxy = httpProxy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesDeleteSettings.HttpProxy"/></em></p>
        ///   <p>Proxy server address to route requests through.</p>
        /// </summary>
        [Pure]
        public static T ResetHttpProxy<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxy = null;
            return toolSettings;
        }
        #endregion
        #region HttpProxyCertificateFileName
        /// <summary>
        ///   <p><em>Sets <see cref="NetlifySitesDeleteSettings.HttpProxyCertificateFileName"/></em></p>
        ///   <p>Certificate file to use when connecting using a proxy server.</p>
        /// </summary>
        [Pure]
        public static T SetHttpProxyCertificateFileName<T>(this T toolSettings, string httpProxyCertificateFileName) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxyCertificateFileName = httpProxyCertificateFileName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="NetlifySitesDeleteSettings.HttpProxyCertificateFileName"/></em></p>
        ///   <p>Certificate file to use when connecting using a proxy server.</p>
        /// </summary>
        [Pure]
        public static T ResetHttpProxyCertificateFileName<T>(this T toolSettings) where T : NetlifySitesDeleteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpProxyCertificateFileName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
